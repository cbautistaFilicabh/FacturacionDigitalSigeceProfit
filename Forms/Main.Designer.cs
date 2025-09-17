namespace FacturacionDigital_SIGECE.Forms
{
    partial class Main
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
            Utilities.BunifuPages.BunifuAnimatorNS.Animation animation1 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            bunifuPages1 = new Bunifu.UI.WinForms.BunifuPages();
            tabPage1 = new TabPage();
            send = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            salida = new Bunifu.UI.WinForms.BunifuLabel();
            txtInput = new Bunifu.UI.WinForms.BunifuTextBox();
            tabPage2 = new TabPage();
            bunifuPages1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // bunifuPages1
            // 
            bunifuPages1.Alignment = TabAlignment.Bottom;
            bunifuPages1.AllowTransitions = false;
            bunifuPages1.Controls.Add(tabPage1);
            bunifuPages1.Controls.Add(tabPage2);
            bunifuPages1.Dock = DockStyle.Fill;
            bunifuPages1.Location = new Point(0, 0);
            bunifuPages1.Multiline = true;
            bunifuPages1.Name = "bunifuPages1";
            bunifuPages1.Page = tabPage1;
            bunifuPages1.PageIndex = 0;
            bunifuPages1.PageName = "tabPage1";
            bunifuPages1.PageTitle = "tabPage1";
            bunifuPages1.SelectedIndex = 0;
            bunifuPages1.Size = new Size(800, 450);
            bunifuPages1.TabIndex = 0;
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = (PointF)resources.GetObject("animation1.BlindCoeff");
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = (PointF)resources.GetObject("animation1.MosaicCoeff");
            animation1.MosaicShift = (PointF)resources.GetObject("animation1.MosaicShift");
            animation1.MosaicSize = 0;
            animation1.Padding = new Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = (PointF)resources.GetObject("animation1.ScaleCoeff");
            animation1.SlideCoeff = (PointF)resources.GetObject("animation1.SlideCoeff");
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            bunifuPages1.Transition = animation1;
            bunifuPages1.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(send);
            tabPage1.Controls.Add(salida);
            tabPage1.Controls.Add(txtInput);
            tabPage1.Location = new Point(4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // send
            // 
            send.AllowAnimations = true;
            send.AllowMouseEffects = true;
            send.AllowToggling = false;
            send.AnimationSpeed = 200;
            send.AutoGenerateColors = false;
            send.AutoRoundBorders = false;
            send.AutoSizeLeftIcon = true;
            send.AutoSizeRightIcon = true;
            send.BackColor = Color.Transparent;
            send.BackColor1 = Color.FromArgb(51, 122, 183);
            send.BackgroundImage = (Image)resources.GetObject("send.BackgroundImage");
            send.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            send.ButtonText = "send";
            send.ButtonTextMarginLeft = 0;
            send.ColorContrastOnClick = 45;
            send.ColorContrastOnHover = 45;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            send.CustomizableEdges = borderEdges1;
            send.DialogResult = DialogResult.None;
            send.DisabledBorderColor = Color.FromArgb(191, 191, 191);
            send.DisabledFillColor = Color.Empty;
            send.DisabledForecolor = Color.Empty;
            send.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            send.Font = new Font("Segoe UI", 9F);
            send.ForeColor = Color.White;
            send.IconLeft = null;
            send.IconLeftAlign = ContentAlignment.MiddleLeft;
            send.IconLeftCursor = Cursors.Default;
            send.IconLeftPadding = new Padding(11, 3, 3, 3);
            send.IconMarginLeft = 11;
            send.IconPadding = 10;
            send.IconRight = null;
            send.IconRightAlign = ContentAlignment.MiddleRight;
            send.IconRightCursor = Cursors.Default;
            send.IconRightPadding = new Padding(3, 3, 7, 3);
            send.IconSize = 25;
            send.IdleBorderColor = Color.Empty;
            send.IdleBorderRadius = 0;
            send.IdleBorderThickness = 0;
            send.IdleFillColor = Color.Empty;
            send.IdleIconLeftImage = null;
            send.IdleIconRightImage = null;
            send.IndicateFocus = false;
            send.Location = new Point(336, 368);
            send.Name = "send";
            send.OnDisabledState.BorderColor = Color.FromArgb(191, 191, 191);
            send.OnDisabledState.BorderRadius = 1;
            send.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            send.OnDisabledState.BorderThickness = 1;
            send.OnDisabledState.FillColor = Color.FromArgb(204, 204, 204);
            send.OnDisabledState.ForeColor = Color.FromArgb(168, 160, 168);
            send.OnDisabledState.IconLeftImage = null;
            send.OnDisabledState.IconRightImage = null;
            send.onHoverState.BorderColor = Color.FromArgb(30, 150, 255);
            send.onHoverState.BorderRadius = 1;
            send.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            send.onHoverState.BorderThickness = 1;
            send.onHoverState.FillColor = Color.FromArgb(30, 150, 255);
            send.onHoverState.ForeColor = Color.White;
            send.onHoverState.IconLeftImage = null;
            send.onHoverState.IconRightImage = null;
            send.OnIdleState.BorderColor = Color.DodgerBlue;
            send.OnIdleState.BorderRadius = 1;
            send.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            send.OnIdleState.BorderThickness = 1;
            send.OnIdleState.FillColor = Color.DodgerBlue;
            send.OnIdleState.ForeColor = Color.White;
            send.OnIdleState.IconLeftImage = null;
            send.OnIdleState.IconRightImage = null;
            send.OnPressedState.BorderColor = Color.FromArgb(40, 96, 144);
            send.OnPressedState.BorderRadius = 1;
            send.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            send.OnPressedState.BorderThickness = 1;
            send.OnPressedState.FillColor = Color.FromArgb(40, 96, 144);
            send.OnPressedState.ForeColor = Color.White;
            send.OnPressedState.IconLeftImage = null;
            send.OnPressedState.IconRightImage = null;
            send.Size = new Size(128, 39);
            send.TabIndex = 2;
            send.TextAlign = ContentAlignment.MiddleCenter;
            send.TextAlignment = HorizontalAlignment.Center;
            send.TextMarginLeft = 0;
            send.TextPadding = new Padding(0);
            send.UseDefaultRadiusAndThickness = true;
            send.Click += send_Click;
            // 
            // salida
            // 
            salida.AllowParentOverrides = false;
            salida.AutoEllipsis = false;
            salida.AutoSize = false;
            salida.CursorType = Cursors.Default;
            salida.Dock = DockStyle.Right;
            salida.Font = new Font("Segoe UI", 9F);
            salida.Location = new Point(483, 3);
            salida.Name = "salida";
            salida.RightToLeft = RightToLeft.No;
            salida.Size = new Size(306, 416);
            salida.TabIndex = 1;
            salida.TextAlignment = ContentAlignment.TopLeft;
            salida.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtInput
            // 
            txtInput.AcceptsReturn = false;
            txtInput.AcceptsTab = false;
            txtInput.AnimationSpeed = 200;
            txtInput.AutoCompleteMode = AutoCompleteMode.None;
            txtInput.AutoCompleteSource = AutoCompleteSource.None;
            txtInput.AutoSizeHeight = true;
            txtInput.BackColor = Color.Transparent;
            txtInput.BackgroundImage = (Image)resources.GetObject("txtInput.BackgroundImage");
            txtInput.BorderColorActive = Color.DodgerBlue;
            txtInput.BorderColorDisabled = Color.FromArgb(204, 204, 204);
            txtInput.BorderColorHover = Color.FromArgb(105, 181, 255);
            txtInput.BorderColorIdle = Color.Silver;
            txtInput.BorderRadius = 1;
            txtInput.BorderThickness = 1;
            txtInput.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            txtInput.CharacterCasing = CharacterCasing.Normal;
            txtInput.DefaultFont = new Font("Segoe UI", 9.25F);
            txtInput.DefaultText = "";
            txtInput.Dock = DockStyle.Left;
            txtInput.FillColor = Color.White;
            txtInput.HideSelection = true;
            txtInput.IconLeft = null;
            txtInput.IconLeftCursor = Cursors.IBeam;
            txtInput.IconPadding = 10;
            txtInput.IconRight = null;
            txtInput.IconRightCursor = Cursors.IBeam;
            txtInput.Location = new Point(3, 3);
            txtInput.MaxLength = 32767;
            txtInput.MinimumSize = new Size(1, 1);
            txtInput.Modified = false;
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            stateProperties1.BorderColor = Color.DodgerBlue;
            stateProperties1.FillColor = Color.Empty;
            stateProperties1.ForeColor = Color.Empty;
            stateProperties1.PlaceholderForeColor = Color.Empty;
            txtInput.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = Color.FromArgb(204, 204, 204);
            stateProperties2.FillColor = Color.FromArgb(240, 240, 240);
            stateProperties2.ForeColor = Color.FromArgb(109, 109, 109);
            stateProperties2.PlaceholderForeColor = Color.DarkGray;
            txtInput.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = Color.FromArgb(105, 181, 255);
            stateProperties3.FillColor = Color.Empty;
            stateProperties3.ForeColor = Color.Empty;
            stateProperties3.PlaceholderForeColor = Color.Empty;
            txtInput.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = Color.Silver;
            stateProperties4.FillColor = Color.White;
            stateProperties4.ForeColor = Color.Empty;
            stateProperties4.PlaceholderForeColor = Color.Empty;
            txtInput.OnIdleState = stateProperties4;
            txtInput.Padding = new Padding(3);
            txtInput.PasswordChar = '\0';
            txtInput.PlaceholderForeColor = Color.Silver;
            txtInput.PlaceholderText = "Enter text";
            txtInput.ReadOnly = false;
            txtInput.ScrollBars = ScrollBars.None;
            txtInput.SelectedText = "";
            txtInput.SelectionLength = 0;
            txtInput.SelectionStart = 0;
            txtInput.ShortcutsEnabled = true;
            txtInput.Size = new Size(312, 416);
            txtInput.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            txtInput.TabIndex = 0;
            txtInput.TextAlign = HorizontalAlignment.Left;
            txtInput.TextMarginBottom = 0;
            txtInput.TextMarginLeft = 3;
            txtInput.TextMarginTop = 1;
            txtInput.TextPlaceholder = "Enter text";
            txtInput.UseSystemPasswordChar = false;
            txtInput.WordWrap = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bunifuPages1);
            Name = "Main";
            Text = "Main";
            bunifuPages1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPages bunifuPages1;
        private TabPage tabPage1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 send;
        private Bunifu.UI.WinForms.BunifuLabel salida;
        private Bunifu.UI.WinForms.BunifuTextBox txtInput;
        private TabPage tabPage2;
    }
}