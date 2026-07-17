using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuestPDF.Fluent;

namespace TekstilCekiHazirlama
{
    public partial class Form1 : Form
    {
        private int _currentNoteId;
        private AppSettings _settings = new();
        private List<string> _customerNameSuggestions = new();
        private List<string> _productNameSuggestions = new();

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            Load += Form1_Load;
            menuNew.Click += MenuNew_Click;
            menuHistory.Click += MenuHistory_Click;
            menuSettings.Click += MenuSettings_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            dgvHistory.CellDoubleClick += DgvHistory_CellDoubleClick;
            dgvHistory.CellMouseDown += DgvHistory_CellMouseDown;
            btnSave.Click += BtnSave_Click;
            btnPreview.Click += BtnPreview_Click;
            btnSavePdf.Click += BtnSavePdf_Click;
            btnPrint.Click += BtnPrint_Click;
            dgvItems.CellEndEdit += DgvItems_CellEndEdit;
            dgvItems.RowsAdded += DgvItems_RowsAdded;
            dgvItems.UserDeletedRow += DgvItems_UserDeletedRow;
            dgvItems.DefaultValuesNeeded += DgvItems_DefaultValuesNeeded;
            dgvItems.CellFormatting += DgvItems_CellFormatting;
            dgvItems.EditingControlShowing += DgvItems_EditingControlShowing;
            FormClosed += Form1_FormClosed;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            DataService.EnsureDatabase();
            _settings = AppSettingsService.Load();
            ApplySettingsToUi();
            LoadPastNotes();
            RefreshSuggestionLists();
            SwitchToNewNote();
        }

        private void ApplySettingsToUi()
        {
            lblCompanyName.Text = _settings.CompanyName;
        }

        private void DgvItems_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[colLineNo.Name].Value = dgvItems.Rows.Count;
            e.Row.Cells[colRollCount.Name].Value = 0;
            e.Row.Cells[colKg.Name].Value = 0m;
            e.Row.Cells[colUnitPrice.Name].Value = 0m;
            e.Row.Cells[colAmount.Name].Value = 0m;
        }

        private void DgvItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateRowNumbers();
            UpdateTotals();
        }

        private void DgvItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateRowNumbers();
            UpdateTotals();
        }

        private void DgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvItems.Rows[e.RowIndex];
            if (row.IsNewRow)
                return;

            var kg = ParseDecimal(row.Cells[colKg.Name].Value);
            var price = ParseDecimal(row.Cells[colUnitPrice.Name].Value);
            var rollCount = ParseInt(row.Cells[colRollCount.Name].Value);
            var amount = kg * price;

            row.Cells[colAmount.Name].Value = amount;
            if (rollCount <= 0 && !string.IsNullOrWhiteSpace(row.Cells[colProductName.Name].Value?.ToString()))
            {
                row.Cells[colRollCount.Name].Value = 1;
            }

            UpdateTotals();
        }

        private void DgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvItems.Columns[e.ColumnIndex] == colKg || dgvItems.Columns[e.ColumnIndex] == colUnitPrice || dgvItems.Columns[e.ColumnIndex] == colAmount)
            {
                if (e.Value is decimal decimalValue)
                {
                    e.Value = decimalValue.ToString("N2");
                    e.FormattingApplied = true;
                }
                else if (decimal.TryParse(Convert.ToString(e.Value), out decimalValue))
                {
                    e.Value = decimalValue.ToString("N2");
                    e.FormattingApplied = true;
                }
            }
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            LoadPastNotes(txtSearch.Text);
        }

        private void DgvHistory_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvHistory.Rows[e.RowIndex].Tag is DeliveryNote note)
            {
                LoadDeliveryNoteToForm(note);
                SwitchToNewNote();
                lblPanelTitle.Text = "Eski Çeki Detay";

            }
        }

        private void MenuNew_Click(object? sender, EventArgs e)
        {
            InitializeNewNote();
            SwitchToNewNote();
        }

        private void MenuHistory_Click(object? sender, EventArgs e)
        {
            SwitchToHistory();
        }

        private void MenuSettings_Click(object? sender, EventArgs e)
        {
            using var settingsForm = new SettingsForm(_settings);
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                _settings = AppSettingsService.Load();
                ApplySettingsToUi();
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            SaveCurrentNote();
        }

        private void BtnPreview_Click(object? sender, EventArgs e)
        {
            var note = BuildDeliveryNoteFromForm();
            if (note is null)
                return;

            if (SaveFormNoteIfNeeded(note))
            {
                var tempFile = Path.Combine(Path.GetTempPath(), $"KumasCeki_{note.DocumentNo}.pdf");
                GeneratePdf(note, tempFile);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo(tempFile)
                    {
                        UseShellExecute = true,
                        Verb = "open"
                    };
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch
                {
                    MessageBox.Show("PDF önizlemesi açılamadı. Lütfen kaydetmeyi deneyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnSavePdf_Click(object? sender, EventArgs e)
        {
            var note = BuildDeliveryNoteFromForm();
            if (note is null)
                return;

            using var dialog = new SaveFileDialog
            {
                Filter = "PDF Dosyası (*.pdf)|*.pdf",
                FileName = $"KumasCeki_{note.DocumentNo}.pdf",
                Title = "PDF Kaydet"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            if (SaveFormNoteIfNeeded(note))
            {
                GeneratePdf(note, dialog.FileName);
                MessageBox.Show("PDF başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPrint_Click(object? sender, EventArgs e)
        {
            var note = BuildDeliveryNoteFromForm();
            if (note is null)
                return;
 
            if (!SaveFormNoteIfNeeded(note))
                return;
 
            var tempFile = Path.Combine(Path.GetTempPath(), $"KumasCeki_{note.DocumentNo}.pdf");
            GeneratePdf(note, tempFile);
 
            using var printDialog = new PrintDialog
            {
                AllowSomePages = false,
                AllowSelection = false,
                UseEXDialog = true,
                PrinterSettings = new System.Drawing.Printing.PrinterSettings()
            };
 
            if (printDialog.ShowDialog(this) != DialogResult.OK)
                return;
 
            var printerName = printDialog.PrinterSettings.PrinterName;
            if (string.IsNullOrWhiteSpace(printerName))
            {
                MessageBox.Show("Lütfen yazıcı seçiniz.", "Yazdırma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
 
            if (!TryPrintPdf(tempFile, printerName))
            {
                if (MessageBox.Show("Seçilen yazıcıyla yazdırma başlatılamadı. PDF dosyasını açmak ister misiniz?", "Yazdırma Hatası", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    OpenPdfFile(tempFile);
                }
            }
        }

        private bool TryPrintPdf(string filePath, string printerName)
        {
            if (TryPrintToSpecificPrinter(filePath, printerName))
                return true;
 
            return TryPrintWithDefaultApplication(filePath);
        }

        private bool TryPrintToSpecificPrinter(string filePath, string printerName)
        {
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo(filePath)
                {
                    UseShellExecute = true,
                    Verb = "printto",
                    Arguments = $"\"{printerName}\"",
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                };

                var process = System.Diagnostics.Process.Start(startInfo);
                return process != null;
            }
            catch
            {
                return false;
            }
        }

        private bool TryPrintWithDefaultApplication(string filePath)
        {
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo(filePath)
                {
                    UseShellExecute = true,
                    Verb = "print",
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                };

                var process = System.Diagnostics.Process.Start(startInfo);
                return process != null;
            }
            catch
            {
                return false;
            }
        }

        private void OpenPdfFile(string filePath)
        {
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo(filePath)
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PDF açılırken bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _settings = AppSettingsService.Load();
            AppSettingsService.Save(_settings);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                InitializeNewNote();
                SwitchToNewNote();
                return true;
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveCurrentNote();
                return true;
            }
            if (keyData == (Keys.Control | Keys.P))
            {
                BtnPrint_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SwitchToNewNote()
        {
            panelNewNote.Visible = true;
            panelHistory.Visible = false;
            panelNewNote.BringToFront();
            lblPanelTitle.Text = "Yeni Çeki";
            if (_currentNoteId == 0)
                InitializeNewNote();
        }

        private void SwitchToHistory()
        {
            panelNewNote.Visible = false;
            panelHistory.Visible = true;
            panelHistory.BringToFront();
            lblPanelTitle.Text = "Geçmiş Çekiler";
            LoadPastNotes(txtSearch.Text);
        }

        private void InitializeNewNote()
        {
            _currentNoteId = 0;
            txtDocumentNo.Text = DataService.CreateNextDocumentNo();
            dtpDate.Value = DateTime.Today;
            txtCustomerName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtReceiverName.Text = string.Empty;
            dgvItems.Rows.Clear();
            UpdateTotals();
        }

        private void LoadPastNotes(string search = "")
        {
            dgvHistory.Rows.Clear();
            var notes = DataService.GetDeliveryNotes(search);
            foreach (var note in notes)
            {
                var rowIndex = dgvHistory.Rows.Add(note.DocumentNo, note.Date.ToString("dd.MM.yyyy"), note.CustomerName, note.TotalKg.ToString("N2"), note.TotalAmount.ToString("N2"));
                dgvHistory.Rows[rowIndex].Tag = note;
            }
        }

        private void DgvHistory_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvHistory.ClearSelection();
                dgvHistory.Rows[e.RowIndex].Selected = true;
            }
        }

        private void MenuDeleteNote_Click(object? sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
                return;

            var row = dgvHistory.SelectedRows[0];
            if (row.Tag is not DeliveryNote note)
                return;

            var deleteConfirm = MessageBox.Show($"{note.DocumentNo} numaralı çeki silmek istediğinize emin misiniz?", "Çeki Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (deleteConfirm != DialogResult.Yes)
                return;

            try
            {
                DataService.DeleteDeliveryNote(note.Id);
                LoadPastNotes(txtSearch.Text);
                RefreshSuggestionLists();
                MessageBox.Show("Çeki başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çeki silme sırasında bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshSuggestionLists()
        {
            _customerNameSuggestions = DataService.GetCustomerNames();
            txtCustomerName.Items.Clear();
            txtCustomerName.Items.AddRange(_customerNameSuggestions.ToArray());
            txtCustomerName.AutoCompleteCustomSource.Clear();
            txtCustomerName.AutoCompleteCustomSource.AddRange(_customerNameSuggestions.ToArray());

            _productNameSuggestions = DataService.GetProductNames();
        }

        private void DgvItems_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox editingTextBox)
            {
                if (dgvItems.CurrentCell?.OwningColumn == colProductName)
                {
                    editingTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    editingTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    var autoCompleteSource = new AutoCompleteStringCollection();
                    autoCompleteSource.AddRange(_productNameSuggestions.ToArray());
                    editingTextBox.AutoCompleteCustomSource = autoCompleteSource;
                }
                else
                {
                    editingTextBox.AutoCompleteMode = AutoCompleteMode.None;
                    editingTextBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                }
            }
        }

        private void LoadDeliveryNoteToForm(DeliveryNote note)
        {
            lblPanelTitle.Text = "Eski Çeki Detay";
            _currentNoteId = note.Id;
            txtDocumentNo.Text = note.DocumentNo;
            dtpDate.Value = note.Date == DateTime.MinValue ? DateTime.Today : note.Date;
            txtCustomerName.Text = note.CustomerName;
            txtAddress.Text = note.Address;
            txtPhone.Text = note.Phone;
            txtReceiverName.Text = note.ReceiverName;
            dgvItems.Rows.Clear();

            foreach (var item in note.Items.OrderBy(i => i.LineNo))
            {
                dgvItems.Rows.Add(item.LineNo, item.ProductName, item.Description, item.RollCount, item.Kg, item.UnitPrice, item.Amount);
            }

            UpdateRowNumbers();
            UpdateTotals();
        }

        private void UpdateRowNumbers()
        {
            for (var i = 0; i < dgvItems.Rows.Count; i++)
            {
                var row = dgvItems.Rows[i];
                if (row.IsNewRow)
                    continue;
                row.Cells[colLineNo.Name].Value = i + 1;
            }
        }

        private void UpdateTotals()
        {
            var totalRoll = 0;
            var totalKg = 0m;
            var totalAmount = 0m;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow)
                    continue;

                totalRoll += ParseInt(row.Cells[colRollCount.Name].Value);
                totalKg += ParseDecimal(row.Cells[colKg.Name].Value);
                totalAmount += ParseDecimal(row.Cells[colAmount.Name].Value);
            }

            lblTotalRoll.Text = totalRoll.ToString();
            lblTotalKg.Text = totalKg.ToString("N2");
            lblTotalAmount.Text = totalAmount.ToString("N2");
        }

        private void SaveCurrentNote()
        {
            var note = BuildDeliveryNoteFromForm();
            if (note is null)
                return;

            if (!SaveFormNoteIfNeeded(note))
                return;

            MessageBox.Show("Çeki kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPastNotes(txtSearch.Text);
            RefreshSuggestionLists();
        }

        private bool SaveFormNoteIfNeeded(DeliveryNote note)
        {
            try
            {
                note.CreatedDate = note.CreatedDate == default ? DateTime.Now : note.CreatedDate;
                DataService.SaveDeliveryNote(note);
                _currentNoteId = note.Id;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kaydetme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private DeliveryNote? BuildDeliveryNoteFromForm()
        {
            if (string.IsNullOrWhiteSpace(txtDocumentNo.Text))
            {
                MessageBox.Show("Belge No boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var note = new DeliveryNote
            {
                Id = _currentNoteId,
                DocumentNo = txtDocumentNo.Text.Trim(),
                Date = dtpDate.Value.Date,
                CustomerName = txtCustomerName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                ReceiverName = txtReceiverName.Text.Trim(),
                Items = new List<DeliveryNoteItem>()
            };

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var productName = row.Cells[colProductName.Name].Value?.ToString()?.Trim() ?? string.Empty;
                var description = row.Cells[colDescription.Name].Value?.ToString()?.Trim() ?? string.Empty;
                var rollCount = ParseInt(row.Cells[colRollCount.Name].Value);
                var kg = ParseDecimal(row.Cells[colKg.Name].Value);
                var unitPrice = ParseDecimal(row.Cells[colUnitPrice.Name].Value);
                var amount = ParseDecimal(row.Cells[colAmount.Name].Value);

                if (string.IsNullOrWhiteSpace(productName) && string.IsNullOrWhiteSpace(description))
                    continue;

                note.Items.Add(new DeliveryNoteItem
                {
                    LineNo = ParseInt(row.Cells[colLineNo.Name].Value),
                    ProductName = productName,
                    Description = description,
                    RollCount = rollCount,
                    Kg = kg,
                    UnitPrice = unitPrice,
                    Amount = amount
                });
            }

            note.TotalRoll = note.Items.Sum(x => x.RollCount);
            note.TotalKg = note.Items.Sum(x => x.Kg);
            note.TotalAmount = note.Items.Sum(x => x.Amount);

            return note;
        }

        private void GeneratePdf(DeliveryNote note, string filePath)
        {
            var pdfDoc = new DeliveryNoteDocument(note, _settings);
            pdfDoc.GeneratePdf(filePath);
        }

        private static decimal ParseDecimal(object? value)
        {
            if (value is decimal decimalValue)
                return decimalValue;

            if (value is double doubleValue)
                return Convert.ToDecimal(doubleValue);

            if (value is float floatValue)
                return Convert.ToDecimal(floatValue);

            if (value is int intValue)
                return intValue;

            var stringValue = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (decimal.TryParse(stringValue, NumberStyles.Any, CultureInfo.CurrentCulture, out var parsed))
                return parsed;

            return 0m;
        }

        private static int ParseInt(object? value)
        {
            if (value is int intValue)
                return intValue;

            if (value is long longValue)
                return (int)longValue;

            if (value is decimal decimalValue)
                return (int)decimalValue;

            var stringValue = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (int.TryParse(stringValue, NumberStyles.Any, CultureInfo.CurrentCulture, out var parsed))
                return parsed;

            return 0;
        }
    }
}
