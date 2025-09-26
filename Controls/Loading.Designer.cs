namespace FacturacionDigital_SIGECE.Controls
{
    partial class Loading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            bunifuLoader1 = new Bunifu.UI.WinForms.BunifuLoader();
            lblText = new Bunifu.UI.WinForms.BunifuLabel();
            SuspendLayout();
            // 
            // bunifuLoader1
            // 
            bunifuLoader1.AllowStylePresets = true;
            bunifuLoader1.BackColor = Color.Transparent;
            bunifuLoader1.CapStyle = Bunifu.UI.WinForms.BunifuLoader.CapStyles.Round;
            bunifuLoader1.Color = Color.DodgerBlue;
            bunifuLoader1.Customization = "";
            bunifuLoader1.DashWidth = 0.5F;
            bunifuLoader1.Font = new Font("Segoe UI", 9F);
            bunifuLoader1.Image = null;
            bunifuLoader1.Location = new Point(115, 45);
            bunifuLoader1.Name = "bunifuLoader1";
            bunifuLoader1.NoRounding = false;
            bunifuLoader1.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Solid;
            bunifuLoader1.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Solid;
            bunifuLoader1.ShowText = false;
            bunifuLoader1.Size = new Size(116, 116);
            bunifuLoader1.Speed = 7;
            bunifuLoader1.TabIndex = 0;
            bunifuLoader1.Text = "bunifuLoader1";
            bunifuLoader1.TextPadding = new Padding(0);
            bunifuLoader1.Thickness = 15;
            bunifuLoader1.Transparent = true;
            // 
            // lblText
            // 
            lblText.AllowParentOverrides = false;
            lblText.AutoEllipsis = false;
            lblText.CursorType = Cursors.Default;
            lblText.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.Location = new Point(72, 182);
            lblText.Name = "lblText";
            lblText.RightToLeft = RightToLeft.No;
            lblText.Size = new Size(203, 23);
            lblText.TabIndex = 1;
            lblText.Text = "Procesando Documentos...";
            lblText.TextAlignment = ContentAlignment.TopLeft;
            lblText.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Loading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(347, 250);
            Controls.Add(lblText);
            Controls.Add(bunifuLoader1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Loading";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLoader bunifuLoader1;
        private Bunifu.UI.WinForms.BunifuLabel lblText;
    }
}