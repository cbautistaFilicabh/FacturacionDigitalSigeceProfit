namespace FacturacionDigital_SIGECE
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            txtUser = new Bunifu.UI.WinForms.BunifuTextBox();
            lblUser = new Bunifu.UI.WinForms.BunifuLabel();
            btnLogIn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            lblPassword = new Bunifu.UI.WinForms.BunifuLabel();
            txtPassword = new Bunifu.UI.WinForms.BunifuTextBox();
            bunifuLoader1 = new Bunifu.UI.WinForms.BunifuLoader();
            SuspendLayout();
            // 
            // txtUser
            // 
            txtUser.AcceptsReturn = false;
            txtUser.AcceptsTab = false;
            txtUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUser.AnimationSpeed = 200;
            txtUser.AutoCompleteMode = AutoCompleteMode.None;
            txtUser.AutoCompleteSource = AutoCompleteSource.None;
            txtUser.AutoSize = true;
            txtUser.AutoSizeHeight = true;
            txtUser.BackColor = Color.Transparent;
            txtUser.BackgroundImage = (Image)resources.GetObject("txtUser.BackgroundImage");
            txtUser.BorderColorActive = Color.DodgerBlue;
            txtUser.BorderColorDisabled = Color.FromArgb(204, 204, 204);
            txtUser.BorderColorHover = Color.FromArgb(105, 181, 255);
            txtUser.BorderColorIdle = Color.Silver;
            txtUser.BorderRadius = 16;
            txtUser.BorderThickness = 1;
            txtUser.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            txtUser.CharacterCasing = CharacterCasing.Normal;
            txtUser.DefaultFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUser.DefaultText = "";
            txtUser.FillColor = Color.White;
            txtUser.HideSelection = true;
            txtUser.IconLeft = null;
            txtUser.IconLeftCursor = Cursors.IBeam;
            txtUser.IconPadding = 10;
            txtUser.IconRight = null;
            txtUser.IconRightCursor = Cursors.IBeam;
            txtUser.Location = new Point(12, 79);
            txtUser.MaxLength = 32767;
            txtUser.MinimumSize = new Size(1, 1);
            txtUser.Modified = false;
            txtUser.Multiline = false;
            txtUser.Name = "txtUser";
            stateProperties1.BorderColor = Color.DodgerBlue;
            stateProperties1.FillColor = Color.Empty;
            stateProperties1.ForeColor = Color.Empty;
            stateProperties1.PlaceholderForeColor = Color.Empty;
            txtUser.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = Color.FromArgb(204, 204, 204);
            stateProperties2.FillColor = Color.FromArgb(240, 240, 240);
            stateProperties2.ForeColor = Color.FromArgb(109, 109, 109);
            stateProperties2.PlaceholderForeColor = Color.DarkGray;
            txtUser.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = Color.FromArgb(105, 181, 255);
            stateProperties3.FillColor = Color.Empty;
            stateProperties3.ForeColor = Color.Empty;
            stateProperties3.PlaceholderForeColor = Color.Empty;
            txtUser.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = Color.Silver;
            stateProperties4.FillColor = Color.White;
            stateProperties4.ForeColor = Color.Empty;
            stateProperties4.PlaceholderForeColor = Color.Empty;
            txtUser.OnIdleState = stateProperties4;
            txtUser.Padding = new Padding(3);
            txtUser.PasswordChar = '\0';
            txtUser.PlaceholderForeColor = Color.Silver;
            txtUser.PlaceholderText = "Ingrese su correo electrónico";
            txtUser.ReadOnly = false;
            txtUser.ScrollBars = ScrollBars.None;
            txtUser.SelectedText = "";
            txtUser.SelectionLength = 0;
            txtUser.SelectionStart = 0;
            txtUser.ShortcutsEnabled = true;
            txtUser.Size = new Size(312, 42);
            txtUser.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            txtUser.TabIndex = 0;
            txtUser.TextAlign = HorizontalAlignment.Left;
            txtUser.TextMarginBottom = 0;
            txtUser.TextMarginLeft = 3;
            txtUser.TextMarginTop = 1;
            txtUser.TextPlaceholder = "Ingrese su correo electrónico";
            txtUser.UseSystemPasswordChar = false;
            txtUser.WordWrap = true;
            // 
            // lblUser
            // 
            lblUser.AllowParentOverrides = false;
            lblUser.Anchor = AnchorStyles.Left;
            lblUser.AutoEllipsis = false;
            lblUser.CursorType = Cursors.Default;
            lblUser.Font = new Font("Segoe UI", 11F);
            lblUser.Location = new Point(12, 53);
            lblUser.Name = "lblUser";
            lblUser.RightToLeft = RightToLeft.No;
            lblUser.Size = new Size(123, 20);
            lblUser.TabIndex = 1;
            lblUser.Text = "Correo Electrónico";
            lblUser.TextAlignment = ContentAlignment.TopLeft;
            lblUser.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnLogIn
            // 
            btnLogIn.AllowAnimations = true;
            btnLogIn.AllowMouseEffects = true;
            btnLogIn.AllowToggling = false;
            btnLogIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogIn.AnimationSpeed = 200;
            btnLogIn.AutoGenerateColors = false;
            btnLogIn.AutoRoundBorders = false;
            btnLogIn.AutoSizeLeftIcon = true;
            btnLogIn.AutoSizeRightIcon = true;
            btnLogIn.BackColor = Color.Transparent;
            btnLogIn.BackColor1 = Color.FromArgb(51, 122, 183);
            btnLogIn.BackgroundImage = (Image)resources.GetObject("btnLogIn.BackgroundImage");
            btnLogIn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnLogIn.ButtonText = "Log In";
            btnLogIn.ButtonTextMarginLeft = 0;
            btnLogIn.ColorContrastOnClick = 45;
            btnLogIn.ColorContrastOnHover = 45;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            btnLogIn.CustomizableEdges = borderEdges1;
            btnLogIn.DialogResult = DialogResult.None;
            btnLogIn.DisabledBorderColor = Color.FromArgb(191, 191, 191);
            btnLogIn.DisabledFillColor = Color.Empty;
            btnLogIn.DisabledForecolor = Color.Empty;
            btnLogIn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            btnLogIn.Font = new Font("Segoe UI", 9F);
            btnLogIn.ForeColor = Color.White;
            btnLogIn.IconLeft = null;
            btnLogIn.IconLeftAlign = ContentAlignment.MiddleLeft;
            btnLogIn.IconLeftCursor = Cursors.Default;
            btnLogIn.IconLeftPadding = new Padding(11, 3, 3, 3);
            btnLogIn.IconMarginLeft = 11;
            btnLogIn.IconPadding = 10;
            btnLogIn.IconRight = null;
            btnLogIn.IconRightAlign = ContentAlignment.MiddleRight;
            btnLogIn.IconRightCursor = Cursors.Default;
            btnLogIn.IconRightPadding = new Padding(3, 3, 7, 3);
            btnLogIn.IconSize = 25;
            btnLogIn.IdleBorderColor = Color.Empty;
            btnLogIn.IdleBorderRadius = 0;
            btnLogIn.IdleBorderThickness = 0;
            btnLogIn.IdleFillColor = Color.Empty;
            btnLogIn.IdleIconLeftImage = null;
            btnLogIn.IdleIconRightImage = null;
            btnLogIn.IndicateFocus = false;
            btnLogIn.Location = new Point(93, 232);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.OnDisabledState.BorderColor = Color.FromArgb(191, 191, 191);
            btnLogIn.OnDisabledState.BorderRadius = 16;
            btnLogIn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnLogIn.OnDisabledState.BorderThickness = 1;
            btnLogIn.OnDisabledState.FillColor = Color.FromArgb(204, 204, 204);
            btnLogIn.OnDisabledState.ForeColor = Color.FromArgb(168, 160, 168);
            btnLogIn.OnDisabledState.IconLeftImage = null;
            btnLogIn.OnDisabledState.IconRightImage = null;
            btnLogIn.onHoverState.BorderColor = Color.FromArgb(30, 150, 255);
            btnLogIn.onHoverState.BorderRadius = 16;
            btnLogIn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnLogIn.onHoverState.BorderThickness = 1;
            btnLogIn.onHoverState.FillColor = Color.FromArgb(30, 150, 255);
            btnLogIn.onHoverState.ForeColor = Color.White;
            btnLogIn.onHoverState.IconLeftImage = null;
            btnLogIn.onHoverState.IconRightImage = null;
            btnLogIn.OnIdleState.BorderColor = Color.DodgerBlue;
            btnLogIn.OnIdleState.BorderRadius = 16;
            btnLogIn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnLogIn.OnIdleState.BorderThickness = 1;
            btnLogIn.OnIdleState.FillColor = Color.DodgerBlue;
            btnLogIn.OnIdleState.ForeColor = Color.White;
            btnLogIn.OnIdleState.IconLeftImage = null;
            btnLogIn.OnIdleState.IconRightImage = null;
            btnLogIn.OnPressedState.BorderColor = Color.FromArgb(40, 96, 144);
            btnLogIn.OnPressedState.BorderRadius = 16;
            btnLogIn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnLogIn.OnPressedState.BorderThickness = 1;
            btnLogIn.OnPressedState.FillColor = Color.FromArgb(40, 96, 144);
            btnLogIn.OnPressedState.ForeColor = Color.White;
            btnLogIn.OnPressedState.IconLeftImage = null;
            btnLogIn.OnPressedState.IconRightImage = null;
            btnLogIn.Size = new Size(150, 39);
            btnLogIn.TabIndex = 2;
            btnLogIn.TextAlign = ContentAlignment.MiddleCenter;
            btnLogIn.TextAlignment = HorizontalAlignment.Center;
            btnLogIn.TextMarginLeft = 0;
            btnLogIn.TextPadding = new Padding(0);
            btnLogIn.UseDefaultRadiusAndThickness = true;
            // 
            // lblPassword
            // 
            lblPassword.AllowParentOverrides = false;
            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.AutoEllipsis = false;
            lblPassword.CursorType = Cursors.Default;
            lblPassword.Font = new Font("Segoe UI", 11F);
            lblPassword.Location = new Point(12, 139);
            lblPassword.Name = "lblPassword";
            lblPassword.RightToLeft = RightToLeft.No;
            lblPassword.Size = new Size(74, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Contraseña";
            lblPassword.TextAlignment = ContentAlignment.TopLeft;
            lblPassword.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtPassword
            // 
            txtPassword.AcceptsReturn = false;
            txtPassword.AcceptsTab = false;
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.AnimationSpeed = 200;
            txtPassword.AutoCompleteMode = AutoCompleteMode.None;
            txtPassword.AutoCompleteSource = AutoCompleteSource.None;
            txtPassword.AutoSize = true;
            txtPassword.AutoSizeHeight = true;
            txtPassword.BackColor = Color.Transparent;
            txtPassword.BackgroundImage = (Image)resources.GetObject("txtPassword.BackgroundImage");
            txtPassword.BorderColorActive = Color.DodgerBlue;
            txtPassword.BorderColorDisabled = Color.FromArgb(204, 204, 204);
            txtPassword.BorderColorHover = Color.FromArgb(105, 181, 255);
            txtPassword.BorderColorIdle = Color.Silver;
            txtPassword.BorderRadius = 16;
            txtPassword.BorderThickness = 1;
            txtPassword.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            txtPassword.CharacterCasing = CharacterCasing.Normal;
            txtPassword.DefaultFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.DefaultText = "";
            txtPassword.FillColor = Color.White;
            txtPassword.HideSelection = true;
            txtPassword.IconLeft = null;
            txtPassword.IconLeftCursor = Cursors.IBeam;
            txtPassword.IconPadding = 10;
            txtPassword.IconRight = Properties.Resources.visibility_50_light;
            txtPassword.IconRightCursor = Cursors.IBeam;
            txtPassword.Location = new Point(12, 165);
            txtPassword.MaxLength = 32767;
            txtPassword.MinimumSize = new Size(1, 1);
            txtPassword.Modified = false;
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            stateProperties5.BorderColor = Color.DodgerBlue;
            stateProperties5.FillColor = Color.Empty;
            stateProperties5.ForeColor = Color.Empty;
            stateProperties5.PlaceholderForeColor = Color.Empty;
            txtPassword.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = Color.FromArgb(204, 204, 204);
            stateProperties6.FillColor = Color.FromArgb(240, 240, 240);
            stateProperties6.ForeColor = Color.FromArgb(109, 109, 109);
            stateProperties6.PlaceholderForeColor = Color.DarkGray;
            txtPassword.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = Color.FromArgb(105, 181, 255);
            stateProperties7.FillColor = Color.Empty;
            stateProperties7.ForeColor = Color.Empty;
            stateProperties7.PlaceholderForeColor = Color.Empty;
            txtPassword.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = Color.Silver;
            stateProperties8.FillColor = Color.White;
            stateProperties8.ForeColor = Color.Empty;
            stateProperties8.PlaceholderForeColor = Color.Empty;
            txtPassword.OnIdleState = stateProperties8;
            txtPassword.Padding = new Padding(3);
            txtPassword.PasswordChar = '\0';
            txtPassword.PlaceholderForeColor = Color.Silver;
            txtPassword.PlaceholderText = "Ingrese su contraseña";
            txtPassword.ReadOnly = false;
            txtPassword.ScrollBars = ScrollBars.None;
            txtPassword.SelectedText = "";
            txtPassword.SelectionLength = 0;
            txtPassword.SelectionStart = 0;
            txtPassword.ShortcutsEnabled = true;
            txtPassword.Size = new Size(312, 42);
            txtPassword.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            txtPassword.TabIndex = 3;
            txtPassword.TextAlign = HorizontalAlignment.Left;
            txtPassword.TextMarginBottom = 0;
            txtPassword.TextMarginLeft = 3;
            txtPassword.TextMarginTop = 1;
            txtPassword.TextPlaceholder = "Ingrese su contraseña";
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.WordWrap = true;
            txtPassword.OnIconRightClick += txtPassword_OnIconRightClick;
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
            bunifuLoader1.Location = new Point(152, 282);
            bunifuLoader1.Name = "bunifuLoader1";
            bunifuLoader1.NoRounding = false;
            bunifuLoader1.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Solid;
            bunifuLoader1.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Solid;
            bunifuLoader1.ShowText = false;
            bunifuLoader1.Size = new Size(32, 32);
            bunifuLoader1.Speed = 7;
            bunifuLoader1.TabIndex = 5;
            bunifuLoader1.Text = "bunifuLoader1";
            bunifuLoader1.TextPadding = new Padding(0);
            bunifuLoader1.Thickness = 5;
            bunifuLoader1.Transparent = true;
            bunifuLoader1.Visible = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(336, 326);
            Controls.Add(bunifuLoader1);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogIn);
            Controls.Add(lblUser);
            Controls.Add(txtUser);
            Name = "FormLogin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Bunifu.UI.WinForms.BunifuTextBox txtUser;
        private Bunifu.UI.WinForms.BunifuLabel lblUser;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnLogIn;
        private Bunifu.UI.WinForms.BunifuLabel lblPassword;
        private Bunifu.UI.WinForms.BunifuTextBox txtPassword;
        private Bunifu.UI.WinForms.BunifuLoader bunifuLoader1;
    }
}
