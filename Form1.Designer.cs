namespace TekstilCekiHazirlama
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuNew;
        private ToolStripMenuItem menuHistory;
        private ToolStripMenuItem menuSettings;
        private Panel panelHeader;
        private Label lblCompanyName;
        private Label lblPanelTitle;
        private Panel panelMain;
        private Panel panelNewNote;
        private Panel panelHistory;
        private TextBox txtDocumentNo;
        private DateTimePicker dtpDate;
        private ComboBox txtCustomerName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtReceiverName;
        private DataGridView dgvItems;
        private DataGridViewTextBoxColumn colLineNo;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colRollCount;
        private DataGridViewTextBoxColumn colKg;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colAmount;
        private Label lblTotalRoll;
        private Label lblTotalKg;
        private Label lblTotalAmount;
        private Button btnSave;
        private Button btnPreview;
        private Button btnSavePdf;
        private Button btnPrint;
        private ContextMenuStrip historyContextMenu;
        private ToolStripMenuItem menuDeleteNote;
        private Label lblDocumentNo;
        private Label lblDate;
        private Label lblCustomerName;
        private Label lblAddress;
        private Label lblPhone;
        private Label lblReceiverName;
        private Label lblTotalRollText;
        private Label lblTotalKgText;
        private Label lblTotalAmountText;
        private GroupBox groupLines;
        private TextBox txtSearch;
        private Label lblSearch;
        private DataGridView dgvHistory;
        private DataGridViewTextBoxColumn colHistoryDocumentNo;
        private DataGridViewTextBoxColumn colHistoryDate;
        private DataGridViewTextBoxColumn colHistoryCustomer;
        private DataGridViewTextBoxColumn colHistoryTotalKg;
        private DataGridViewTextBoxColumn colHistoryTotalAmount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip = new MenuStrip();
            menuNew = new ToolStripMenuItem();
            menuHistory = new ToolStripMenuItem();
            menuSettings = new ToolStripMenuItem();
            panelHeader = new Panel();
            lblCompanyName = new Label();
            lblPanelTitle = new Label();
            panelMain = new Panel();
            panelNewNote = new Panel();
            lblDocumentNo = new Label();
            txtDocumentNo = new TextBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblCustomerName = new Label();
            txtCustomerName = new ComboBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblReceiverName = new Label();
            txtReceiverName = new TextBox();
            groupLines = new GroupBox();
            dgvItems = new DataGridView();
            colLineNo = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colRollCount = new DataGridViewTextBoxColumn();
            colKg = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            lblTotalRollText = new Label();
            lblTotalKgText = new Label();
            lblTotalAmountText = new Label();
            lblTotalRoll = new Label();
            lblTotalKg = new Label();
            lblTotalAmount = new Label();
            btnSave = new Button();
            btnPreview = new Button();
            btnSavePdf = new Button();
            btnPrint = new Button();
            panelHistory = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            dgvHistory = new DataGridView();
            colHistoryDocumentNo = new DataGridViewTextBoxColumn();
            colHistoryDate = new DataGridViewTextBoxColumn();
            colHistoryCustomer = new DataGridViewTextBoxColumn();
            colHistoryTotalKg = new DataGridViewTextBoxColumn();
            colHistoryTotalAmount = new DataGridViewTextBoxColumn();
            historyContextMenu = new ContextMenuStrip(components);
            menuDeleteNote = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelNewNote.SuspendLayout();
            groupLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            panelHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            historyContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { menuNew, menuHistory, menuSettings });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1000, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // menuNew
            // 
            menuNew.Name = "menuNew";
            menuNew.Size = new Size(67, 20);
            menuNew.Text = "Yeni Çeki";
            // 
            // menuHistory
            // 
            menuHistory.Name = "menuHistory";
            menuHistory.Size = new Size(97, 20);
            menuHistory.Text = "Geçmiş Çekiler";
            // 
            // menuSettings
            // 
            menuSettings.Name = "menuSettings";
            menuSettings.Size = new Size(56, 20);
            menuSettings.Text = "Ayarlar";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(33, 37, 41);
            panelHeader.Controls.Add(lblCompanyName);
            panelHeader.Controls.Add(lblPanelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 90);
            panelHeader.TabIndex = 1;
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCompanyName.ForeColor = Color.White;
            lblCompanyName.Location = new Point(20, 20);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(97, 25);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "Firma Adı";
            // 
            // lblPanelTitle
            // 
            lblPanelTitle.AutoSize = true;
            lblPanelTitle.Font = new Font("Segoe UI", 12F);
            lblPanelTitle.ForeColor = Color.WhiteSmoke;
            lblPanelTitle.Location = new Point(20, 55);
            lblPanelTitle.Name = "lblPanelTitle";
            lblPanelTitle.Size = new Size(73, 21);
            lblPanelTitle.TabIndex = 1;
            lblPanelTitle.Text = "Yeni Çeki";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.WhiteSmoke;
            panelMain.Controls.Add(panelNewNote);
            panelMain.Controls.Add(panelHistory);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 114);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(1000, 586);
            panelMain.TabIndex = 0;
            // 
            // panelNewNote
            // 
            panelNewNote.BackColor = Color.White;
            panelNewNote.BorderStyle = BorderStyle.FixedSingle;
            panelNewNote.Controls.Add(lblDocumentNo);
            panelNewNote.Controls.Add(txtDocumentNo);
            panelNewNote.Controls.Add(lblDate);
            panelNewNote.Controls.Add(dtpDate);
            panelNewNote.Controls.Add(lblCustomerName);
            panelNewNote.Controls.Add(txtCustomerName);
            panelNewNote.Controls.Add(lblAddress);
            panelNewNote.Controls.Add(txtAddress);
            panelNewNote.Controls.Add(lblPhone);
            panelNewNote.Controls.Add(txtPhone);
            panelNewNote.Controls.Add(lblReceiverName);
            panelNewNote.Controls.Add(txtReceiverName);
            panelNewNote.Controls.Add(groupLines);
            panelNewNote.Controls.Add(lblTotalRollText);
            panelNewNote.Controls.Add(lblTotalKgText);
            panelNewNote.Controls.Add(lblTotalAmountText);
            panelNewNote.Controls.Add(lblTotalRoll);
            panelNewNote.Controls.Add(lblTotalKg);
            panelNewNote.Controls.Add(lblTotalAmount);
            panelNewNote.Controls.Add(btnSave);
            panelNewNote.Controls.Add(btnPreview);
            panelNewNote.Controls.Add(btnSavePdf);
            panelNewNote.Controls.Add(btnPrint);
            panelNewNote.Dock = DockStyle.Fill;
            panelNewNote.Location = new Point(20, 20);
            panelNewNote.Name = "panelNewNote";
            panelNewNote.Size = new Size(960, 546);
            panelNewNote.TabIndex = 0;
            // 
            // lblDocumentNo
            // 
            lblDocumentNo.AutoSize = true;
            lblDocumentNo.Location = new Point(20, 20);
            lblDocumentNo.Name = "lblDocumentNo";
            lblDocumentNo.Size = new Size(55, 15);
            lblDocumentNo.TabIndex = 0;
            lblDocumentNo.Text = "Belge No";
            // 
            // txtDocumentNo
            // 
            txtDocumentNo.BackColor = Color.WhiteSmoke;
            txtDocumentNo.Location = new Point(20, 40);
            txtDocumentNo.Name = "txtDocumentNo";
            txtDocumentNo.ReadOnly = true;
            txtDocumentNo.Size = new Size(240, 23);
            txtDocumentNo.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(280, 20);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(33, 15);
            lblDate.TabIndex = 2;
            lblDate.Text = "Tarih";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(280, 40);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(180, 23);
            dtpDate.TabIndex = 3;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(20, 80);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(35, 15);
            lblCustomerName.TabIndex = 4;
            lblCustomerName.Text = "Sayın";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomerName.FormattingEnabled = true;
            txtCustomerName.Location = new Point(20, 100);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(935, 23);
            txtCustomerName.TabIndex = 5;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(20, 140);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(37, 15);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Adres";
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.Location = new Point(20, 160);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(935, 60);
            txtAddress.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(20, 230);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(46, 15);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Telefon";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(20, 250);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 23);
            txtPhone.TabIndex = 9;
            // 
            // lblReceiverName
            // 
            lblReceiverName.AutoSize = true;
            lblReceiverName.Location = new Point(240, 230);
            lblReceiverName.Name = "lblReceiverName";
            lblReceiverName.Size = new Size(68, 15);
            lblReceiverName.TabIndex = 10;
            lblReceiverName.Text = "Teslim Alan";
            // 
            // txtReceiverName
            // 
            txtReceiverName.Location = new Point(240, 250);
            txtReceiverName.Name = "txtReceiverName";
            txtReceiverName.Size = new Size(304, 23);
            txtReceiverName.TabIndex = 11;
            // 
            // groupLines
            // 
            groupLines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupLines.Controls.Add(dgvItems);
            groupLines.Location = new Point(20, 290);
            groupLines.Name = "groupLines";
            groupLines.Size = new Size(1698, 724);
            groupLines.TabIndex = 12;
            groupLines.TabStop = false;
            groupLines.Text = "Ürün Tablosu";
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToResizeRows = false;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { colLineNo, colProductName, colDescription, colRollCount, colKg, colUnitPrice, colAmount });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvItems.DefaultCellStyle = dataGridViewCellStyle2;
            dgvItems.Dock = DockStyle.Fill;
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.GridColor = Color.LightGray;
            dgvItems.Location = new Point(3, 19);
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersVisible = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(1692, 702);
            dgvItems.TabIndex = 0;
            // 
            // colLineNo
            // 
            colLineNo.FillWeight = 20F;
            colLineNo.HeaderText = "Sıra";
            colLineNo.Name = "colLineNo";
            colLineNo.ReadOnly = true;
            colLineNo.Width = 50;
            // 
            // colProductName
            // 
            colProductName.HeaderText = "Cinsi";
            colProductName.Name = "colProductName";
            colProductName.Width = 200;
            // 
            // colDescription
            // 
            colDescription.HeaderText = "Açıklama";
            colDescription.Name = "colDescription";
            colDescription.Width = 280;
            // 
            // colRollCount
            // 
            colRollCount.HeaderText = "Adet";
            colRollCount.Name = "colRollCount";
            colRollCount.Width = 70;
            // 
            // colKg
            // 
            colKg.HeaderText = "KG";
            colKg.Name = "colKg";
            colKg.Width = 80;
            // 
            // colUnitPrice
            // 
            colUnitPrice.HeaderText = "Fiyat";
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.Width = 90;
            // 
            // colAmount
            // 
            colAmount.HeaderText = "Tutar";
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;
            colAmount.Width = 90;
            // 
            // lblTotalRollText
            // 
            lblTotalRollText.AutoSize = true;
            lblTotalRollText.Location = new Point(550, 230);
            lblTotalRollText.Name = "lblTotalRollText";
            lblTotalRollText.Size = new Size(78, 15);
            lblTotalRollText.TabIndex = 13;
            lblTotalRollText.Text = "Toplam Adet:";
            // 
            // lblTotalKgText
            // 
            lblTotalKgText.AutoSize = true;
            lblTotalKgText.Location = new Point(550, 250);
            lblTotalKgText.Name = "lblTotalKgText";
            lblTotalKgText.Size = new Size(67, 15);
            lblTotalKgText.TabIndex = 14;
            lblTotalKgText.Text = "Toplam KG:";
            // 
            // lblTotalAmountText
            // 
            lblTotalAmountText.AutoSize = true;
            lblTotalAmountText.Location = new Point(550, 270);
            lblTotalAmountText.Name = "lblTotalAmountText";
            lblTotalAmountText.Size = new Size(83, 15);
            lblTotalAmountText.TabIndex = 15;
            lblTotalAmountText.Text = "Genel Toplam:";
            // 
            // lblTotalRoll
            // 
            lblTotalRoll.AutoSize = true;
            lblTotalRoll.Location = new Point(650, 230);
            lblTotalRoll.Name = "lblTotalRoll";
            lblTotalRoll.Size = new Size(13, 15);
            lblTotalRoll.TabIndex = 16;
            lblTotalRoll.Text = "0";
            // 
            // lblTotalKg
            // 
            lblTotalKg.AutoSize = true;
            lblTotalKg.Location = new Point(650, 250);
            lblTotalKg.Name = "lblTotalKg";
            lblTotalKg.Size = new Size(28, 15);
            lblTotalKg.TabIndex = 17;
            lblTotalKg.Text = "0,00";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(650, 270);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(28, 15);
            lblTotalAmount.TabIndex = 18;
            lblTotalAmount.Text = "0,00";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(0, 120, 215);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(537, 33);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 19;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnPreview
            // 
            btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPreview.BackColor = Color.FromArgb(0, 120, 215);
            btnPreview.FlatAppearance.BorderSize = 0;
            btnPreview.FlatStyle = FlatStyle.Flat;
            btnPreview.ForeColor = Color.White;
            btnPreview.Location = new Point(855, 33);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(100, 35);
            btnPreview.TabIndex = 20;
            btnPreview.Text = "PDF Önizleme";
            btnPreview.UseVisualStyleBackColor = false;
            // 
            // btnSavePdf
            // 
            btnSavePdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSavePdf.BackColor = Color.FromArgb(0, 120, 215);
            btnSavePdf.FlatAppearance.BorderSize = 0;
            btnSavePdf.FlatStyle = FlatStyle.Flat;
            btnSavePdf.ForeColor = Color.White;
            btnSavePdf.Location = new Point(749, 33);
            btnSavePdf.Name = "btnSavePdf";
            btnSavePdf.Size = new Size(100, 35);
            btnSavePdf.TabIndex = 21;
            btnSavePdf.Text = "PDF Kaydet";
            btnSavePdf.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrint.BackColor = Color.FromArgb(0, 120, 215);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(643, 33);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(100, 35);
            btnPrint.TabIndex = 22;
            btnPrint.Text = "Yazdır";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // panelHistory
            // 
            panelHistory.BackColor = Color.White;
            panelHistory.BorderStyle = BorderStyle.FixedSingle;
            panelHistory.Controls.Add(lblSearch);
            panelHistory.Controls.Add(txtSearch);
            panelHistory.Controls.Add(dgvHistory);
            panelHistory.Dock = DockStyle.Fill;
            panelHistory.Location = new Point(20, 20);
            panelHistory.Name = "panelHistory";
            panelHistory.Size = new Size(960, 546);
            panelHistory.TabIndex = 1;
            panelHistory.Visible = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(20, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(160, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Ara (Belge No / Sayın / Tarih)";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(460, 23);
            txtSearch.TabIndex = 1;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AllowUserToResizeRows = false;
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colHistoryDocumentNo, colHistoryDate, colHistoryCustomer, colHistoryTotalKg, colHistoryTotalAmount });
            dgvHistory.ContextMenuStrip = historyContextMenu;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle4;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.GridColor = Color.LightGray;
            dgvHistory.Location = new Point(20, 85);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(1698, 874);
            dgvHistory.TabIndex = 2;
            // 
            // colHistoryDocumentNo
            // 
            colHistoryDocumentNo.HeaderText = "Belge No";
            colHistoryDocumentNo.Name = "colHistoryDocumentNo";
            colHistoryDocumentNo.Width = 160;
            // 
            // colHistoryDate
            // 
            colHistoryDate.HeaderText = "Tarih";
            colHistoryDate.Name = "colHistoryDate";
            colHistoryDate.Width = 120;
            // 
            // colHistoryCustomer
            // 
            colHistoryCustomer.HeaderText = "Sayın";
            colHistoryCustomer.Name = "colHistoryCustomer";
            colHistoryCustomer.Width = 260;
            // 
            // colHistoryTotalKg
            // 
            colHistoryTotalKg.HeaderText = "Toplam KG";
            colHistoryTotalKg.Name = "colHistoryTotalKg";
            colHistoryTotalKg.Width = 120;
            // 
            // colHistoryTotalAmount
            // 
            colHistoryTotalAmount.HeaderText = "Toplam Tutar";
            colHistoryTotalAmount.Name = "colHistoryTotalAmount";
            colHistoryTotalAmount.Width = 120;
            // 
            // historyContextMenu
            // 
            historyContextMenu.Items.AddRange(new ToolStripItem[] { menuDeleteNote });
            historyContextMenu.Name = "historyContextMenu";
            historyContextMenu.Size = new Size(113, 26);
            // 
            // menuDeleteNote
            // 
            menuDeleteNote.Name = "menuDeleteNote";
            menuDeleteNote.Size = new Size(112, 22);
            menuDeleteNote.Text = "Çeki Sil";
            menuDeleteNote.Click += MenuDeleteNote_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1000, 700);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(980, 680);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Çeki Hazırla";
            WindowState = FormWindowState.Maximized;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelNewNote.ResumeLayout(false);
            panelNewNote.PerformLayout();
            groupLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            panelHistory.ResumeLayout(false);
            panelHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            historyContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
