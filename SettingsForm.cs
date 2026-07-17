using System;
using System.IO;
using System.Windows.Forms;

namespace TekstilCekiHazirlama
{
    public partial class SettingsForm : Form
    {
        private readonly AppSettings _settings;

        public SettingsForm(AppSettings settings)
        {
            _settings = settings;
            InitializeComponent();
            Load += SettingsForm_Load;
            btnBrowseLogo.Click += BtnBrowseLogo_Click;
            btnClearLogo.Click += BtnClearLogo_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void SettingsForm_Load(object? sender, EventArgs e)
        {
            txtCompanyName.Text = _settings.CompanyName;
            txtAddress.Text = _settings.CompanyAddress;
            txtPhone.Text = _settings.CompanyPhone;
            txtLogo.Text = _settings.LogoPath ?? string.Empty;
        }

        private void BtnBrowseLogo_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Resim Dosyası (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
                Title = "Logo Seç"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            txtLogo.Text = dialog.FileName;
        }

        private void BtnClearLogo_Click(object? sender, EventArgs e)
        {
            txtLogo.Text = string.Empty;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            _settings.CompanyName = txtCompanyName.Text.Trim();
            _settings.CompanyAddress = txtAddress.Text.Trim();
            _settings.CompanyPhone = txtPhone.Text.Trim();
            _settings.LogoPath = string.IsNullOrWhiteSpace(txtLogo.Text) ? null : txtLogo.Text.Trim();

            AppSettingsService.Save(_settings);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
