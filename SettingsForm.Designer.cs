namespace TekstilCekiHazirlama
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCompanyName;
        private TextBox txtCompanyName;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblLogo;
        private TextBox txtLogo;
        private Button btnBrowseLogo;
        private Button btnClearLogo;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblCompanyName = new Label();
            txtCompanyName = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblLogo = new Label();
            txtLogo = new TextBox();
            btnBrowseLogo = new Button();
            btnSave = new Button();
            btnCancel = new Button();

            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new System.Drawing.Point(20, 20);
            lblCompanyName.Text = "Firma Adı";

            txtCompanyName.Location = new System.Drawing.Point(20, 45);
            txtCompanyName.Width = 420;

            lblAddress.AutoSize = true;
            lblAddress.Location = new System.Drawing.Point(20, 85);
            lblAddress.Text = "Adres";

            txtAddress.Location = new System.Drawing.Point(20, 110);
            txtAddress.Width = 420;
            txtAddress.Height = 60;
            txtAddress.Multiline = true;

            lblPhone.AutoSize = true;
            lblPhone.Location = new System.Drawing.Point(20, 185);
            lblPhone.Text = "Telefon";

            txtPhone.Location = new System.Drawing.Point(20, 210);
            txtPhone.Width = 420;

            lblLogo.AutoSize = true;
            lblLogo.Location = new System.Drawing.Point(20, 245);
            lblLogo.Text = "Logo";

            txtLogo.Location = new System.Drawing.Point(20, 270);
            txtLogo.Width = 240;
            txtLogo.ReadOnly = true;
 
            btnBrowseLogo.Location = new System.Drawing.Point(270, 268);
            btnBrowseLogo.Size = new System.Drawing.Size(80, 26);
            btnBrowseLogo.Text = "Gözat...";
 
            btnClearLogo = new Button();
            btnClearLogo.Location = new System.Drawing.Point(360, 268);
            btnClearLogo.Size = new System.Drawing.Size(80, 26);
            btnClearLogo.Text = "Kaldır";
            btnClearLogo.BackColor = System.Drawing.Color.FromArgb(109, 109, 109);
            btnClearLogo.ForeColor = System.Drawing.Color.White;
            btnClearLogo.FlatStyle = FlatStyle.Flat;
            btnClearLogo.FlatAppearance.BorderSize = 0;

            btnSave.Location = new System.Drawing.Point(270, 315);
            btnSave.Size = new System.Drawing.Size(90, 34);
            btnSave.Text = "Kaydet";
            btnSave.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnCancel.Location = new System.Drawing.Point(370, 315);
            btnCancel.Size = new System.Drawing.Size(90, 34);
            btnCancel.Text = "İptal";
            btnCancel.BackColor = System.Drawing.Color.FromArgb(109, 109, 109);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            ClientSize = new System.Drawing.Size(470, 370);
            Controls.Add(lblCompanyName);
            Controls.Add(txtCompanyName);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblLogo);
            Controls.Add(txtLogo);
            Controls.Add(btnBrowseLogo);
            Controls.Add(btnClearLogo);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ayarlar";
        }
    }
}
