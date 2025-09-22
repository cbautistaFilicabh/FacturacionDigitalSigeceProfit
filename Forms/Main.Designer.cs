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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            dgvDocs = new Bunifu.UI.WinForms.BunifuDataGridView();
            topbar = new FlowLayoutPanel();
            lblTitle = new Bunifu.UI.WinForms.BunifuLabel();
            txtSearch = new Bunifu.UI.WinForms.BunifuTextBox();
            cmbTypeDoc = new Bunifu.UI.WinForms.BunifuDropdown();
            dateStart = new Bunifu.UI.WinForms.BunifuDatePicker();
            dateEnd = new Bunifu.UI.WinForms.BunifuDatePicker();
            btnSend = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            ((System.ComponentModel.ISupportInitialize)dgvDocs).BeginInit();
            topbar.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDocs
            // 
            dgvDocs.AllowCustomTheming = false;
            dgvDocs.AllowUserToAddRows = false;
            dgvDocs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 251, 255);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvDocs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDocs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvDocs.BackgroundColor = Color.White;
            dgvDocs.BorderStyle = BorderStyle.None;
            dgvDocs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDocs.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dgvDocs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 11.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(24, 115, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDocs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDocs.ColumnHeadersHeight = 40;
            dgvDocs.CurrentTheme.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 251, 255);
            dgvDocs.CurrentTheme.AlternatingRowsStyle.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dgvDocs.CurrentTheme.AlternatingRowsStyle.ForeColor = Color.Black;
            dgvDocs.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(210, 232, 255);
            dgvDocs.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = Color.Black;
            dgvDocs.CurrentTheme.BackColor = Color.White;
            dgvDocs.CurrentTheme.GridColor = Color.FromArgb(221, 238, 255);
            dgvDocs.CurrentTheme.HeaderStyle.BackColor = Color.DodgerBlue;
            dgvDocs.CurrentTheme.HeaderStyle.Font = new Font("Segoe UI Semibold", 11.75F, FontStyle.Bold);
            dgvDocs.CurrentTheme.HeaderStyle.ForeColor = Color.White;
            dgvDocs.CurrentTheme.HeaderStyle.SelectionBackColor = Color.FromArgb(24, 115, 204);
            dgvDocs.CurrentTheme.HeaderStyle.SelectionForeColor = Color.White;
            dgvDocs.CurrentTheme.Name = null;
            dgvDocs.CurrentTheme.RowsStyle.BackColor = Color.White;
            dgvDocs.CurrentTheme.RowsStyle.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dgvDocs.CurrentTheme.RowsStyle.ForeColor = Color.Black;
            dgvDocs.CurrentTheme.RowsStyle.SelectionBackColor = Color.FromArgb(210, 232, 255);
            dgvDocs.CurrentTheme.RowsStyle.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(210, 232, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDocs.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDocs.Dock = DockStyle.Fill;
            dgvDocs.EnableHeadersVisualStyles = false;
            dgvDocs.GridColor = Color.FromArgb(221, 238, 255);
            dgvDocs.HeaderBackColor = Color.DodgerBlue;
            dgvDocs.HeaderBgColor = Color.Empty;
            dgvDocs.HeaderForeColor = Color.White;
            dgvDocs.Location = new Point(8, 109);
            dgvDocs.Name = "dgvDocs";
            dgvDocs.RowHeadersVisible = false;
            dgvDocs.RowTemplate.Height = 40;
            dgvDocs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocs.Size = new Size(923, 416);
            dgvDocs.TabIndex = 0;
            dgvDocs.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // topbar
            // 
            topbar.AutoSize = true;
            topbar.BackColor = Color.Transparent;
            topbar.Controls.Add(lblTitle);
            topbar.Controls.Add(txtSearch);
            topbar.Controls.Add(cmbTypeDoc);
            topbar.Controls.Add(dateStart);
            topbar.Controls.Add(dateEnd);
            topbar.Controls.Add(btnSend);
            topbar.Dock = DockStyle.Top;
            topbar.Location = new Point(8, 8);
            topbar.Margin = new Padding(0);
            topbar.Name = "topbar";
            topbar.Padding = new Padding(4);
            topbar.Size = new Size(923, 101);
            topbar.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AllowParentOverrides = false;
            lblTitle.Anchor = AnchorStyles.Left;
            lblTitle.AutoEllipsis = false;
            lblTitle.CursorType = Cursors.Default;
            lblTitle.Font = new Font("Segoe UI", 14F);
            lblTitle.Location = new Point(8, 15);
            lblTitle.Margin = new Padding(4);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(106, 25);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Documentos";
            lblTitle.TextAlignment = ContentAlignment.TopLeft;
            lblTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtSearch
            // 
            txtSearch.AcceptsReturn = false;
            txtSearch.AcceptsTab = false;
            txtSearch.Anchor = AnchorStyles.Left;
            txtSearch.AnimationSpeed = 200;
            txtSearch.AutoCompleteMode = AutoCompleteMode.None;
            txtSearch.AutoCompleteSource = AutoCompleteSource.None;
            txtSearch.AutoSizeHeight = true;
            txtSearch.BackColor = Color.Transparent;
            txtSearch.BackgroundImage = (Image)resources.GetObject("txtSearch.BackgroundImage");
            txtSearch.BorderColorActive = Color.DodgerBlue;
            txtSearch.BorderColorDisabled = Color.FromArgb(204, 204, 204);
            txtSearch.BorderColorHover = Color.FromArgb(105, 181, 255);
            txtSearch.BorderColorIdle = Color.Silver;
            txtSearch.BorderRadius = 16;
            txtSearch.BorderThickness = 1;
            txtSearch.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            txtSearch.CharacterCasing = CharacterCasing.Normal;
            txtSearch.DefaultFont = new Font("Segoe UI", 11F);
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.White;
            txtSearch.HideSelection = true;
            txtSearch.IconLeft = null;
            txtSearch.IconLeftCursor = Cursors.IBeam;
            txtSearch.IconPadding = 10;
            txtSearch.IconRight = Properties.Resources.search_50_light;
            txtSearch.IconRightCursor = Cursors.IBeam;
            txtSearch.Location = new Point(122, 8);
            txtSearch.Margin = new Padding(4);
            txtSearch.MaxLength = 32767;
            txtSearch.MinimumSize = new Size(1, 1);
            txtSearch.Modified = false;
            txtSearch.Multiline = false;
            txtSearch.Name = "txtSearch";
            stateProperties1.BorderColor = Color.DodgerBlue;
            stateProperties1.FillColor = Color.Empty;
            stateProperties1.ForeColor = Color.Empty;
            stateProperties1.PlaceholderForeColor = Color.Empty;
            txtSearch.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = Color.FromArgb(204, 204, 204);
            stateProperties2.FillColor = Color.FromArgb(240, 240, 240);
            stateProperties2.ForeColor = Color.FromArgb(109, 109, 109);
            stateProperties2.PlaceholderForeColor = Color.DarkGray;
            txtSearch.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = Color.FromArgb(105, 181, 255);
            stateProperties3.FillColor = Color.Empty;
            stateProperties3.ForeColor = Color.Empty;
            stateProperties3.PlaceholderForeColor = Color.Empty;
            txtSearch.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = Color.Silver;
            stateProperties4.FillColor = Color.White;
            stateProperties4.ForeColor = Color.Empty;
            stateProperties4.PlaceholderForeColor = Color.Empty;
            txtSearch.OnIdleState = stateProperties4;
            txtSearch.Padding = new Padding(3);
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderForeColor = Color.Silver;
            txtSearch.PlaceholderText = "Buscar...";
            txtSearch.ReadOnly = false;
            txtSearch.ScrollBars = ScrollBars.None;
            txtSearch.SelectedText = "";
            txtSearch.SelectionLength = 0;
            txtSearch.SelectionStart = 0;
            txtSearch.ShortcutsEnabled = true;
            txtSearch.Size = new Size(260, 40);
            txtSearch.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            txtSearch.TabIndex = 0;
            txtSearch.TextAlign = HorizontalAlignment.Left;
            txtSearch.TextMarginBottom = 0;
            txtSearch.TextMarginLeft = 3;
            txtSearch.TextMarginTop = 1;
            txtSearch.TextPlaceholder = "Buscar...";
            txtSearch.UseSystemPasswordChar = false;
            txtSearch.WordWrap = true;
            // 
            // cmbTypeDoc
            // 
            cmbTypeDoc.BackColor = Color.Transparent;
            cmbTypeDoc.BackgroundColor = Color.White;
            cmbTypeDoc.BorderColor = Color.Silver;
            cmbTypeDoc.BorderRadius = 8;
            cmbTypeDoc.Color = Color.Silver;
            cmbTypeDoc.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            cmbTypeDoc.DisabledBackColor = Color.FromArgb(240, 240, 240);
            cmbTypeDoc.DisabledBorderColor = Color.FromArgb(204, 204, 204);
            cmbTypeDoc.DisabledColor = Color.FromArgb(240, 240, 240);
            cmbTypeDoc.DisabledForeColor = Color.FromArgb(109, 109, 109);
            cmbTypeDoc.DisabledIndicatorColor = Color.DarkGray;
            cmbTypeDoc.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTypeDoc.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            cmbTypeDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeDoc.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            cmbTypeDoc.FillDropDown = true;
            cmbTypeDoc.FillIndicator = false;
            cmbTypeDoc.FlatStyle = FlatStyle.Flat;
            cmbTypeDoc.Font = new Font("Segoe UI", 11F);
            cmbTypeDoc.ForeColor = Color.Black;
            cmbTypeDoc.FormattingEnabled = true;
            cmbTypeDoc.Icon = null;
            cmbTypeDoc.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            cmbTypeDoc.IndicatorColor = Color.DarkGray;
            cmbTypeDoc.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            cmbTypeDoc.IndicatorThickness = 2;
            cmbTypeDoc.IsDropdownOpened = false;
            cmbTypeDoc.ItemBackColor = Color.White;
            cmbTypeDoc.ItemBorderColor = Color.White;
            cmbTypeDoc.ItemForeColor = Color.Black;
            cmbTypeDoc.ItemHeight = 32;
            cmbTypeDoc.ItemHighLightColor = Color.DodgerBlue;
            cmbTypeDoc.ItemHighLightForeColor = Color.White;
            cmbTypeDoc.ItemTopMargin = 3;
            cmbTypeDoc.Location = new Point(390, 8);
            cmbTypeDoc.Margin = new Padding(4);
            cmbTypeDoc.Name = "cmbTypeDoc";
            cmbTypeDoc.Size = new Size(162, 38);
            cmbTypeDoc.TabIndex = 1;
            cmbTypeDoc.Text = null;
            cmbTypeDoc.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            cmbTypeDoc.TextLeftMargin = 5;
            cmbTypeDoc.SelectedValueChanged += cmbTypeDoc_SelectedValueChanged;
            // 
            // dateStart
            // 
            dateStart.Anchor = AnchorStyles.Left;
            dateStart.BackColor = Color.Transparent;
            dateStart.BorderColor = Color.Silver;
            dateStart.BorderRadius = 8;
            dateStart.Color = Color.Silver;
            dateStart.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            dateStart.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            dateStart.DisabledColor = Color.Gray;
            dateStart.DisplayWeekNumbers = false;
            dateStart.DPHeight = 0;
            dateStart.DropDownAlign = LeftRightAlignment.Right;
            dateStart.FillDatePicker = false;
            dateStart.Font = new Font("Segoe UI", 11F);
            dateStart.ForeColor = Color.Black;
            dateStart.Format = DateTimePickerFormat.Short;
            dateStart.Icon = (Image)resources.GetObject("dateStart.Icon");
            dateStart.IconColor = Color.Gray;
            dateStart.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            dateStart.LeftTextMargin = 5;
            dateStart.Location = new Point(560, 9);
            dateStart.Margin = new Padding(4);
            dateStart.MinimumSize = new Size(0, 38);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(134, 38);
            dateStart.TabIndex = 2;
            dateStart.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dateEnd
            // 
            dateEnd.Anchor = AnchorStyles.Left;
            dateEnd.BackColor = Color.Transparent;
            dateEnd.BorderColor = Color.Silver;
            dateEnd.BorderRadius = 8;
            dateEnd.Color = Color.Silver;
            dateEnd.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            dateEnd.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            dateEnd.DisabledColor = Color.Gray;
            dateEnd.DisplayWeekNumbers = false;
            dateEnd.DPHeight = 0;
            dateEnd.DropDownAlign = LeftRightAlignment.Right;
            dateEnd.FillDatePicker = false;
            dateEnd.Font = new Font("Segoe UI", 11F);
            dateEnd.ForeColor = Color.Black;
            dateEnd.Format = DateTimePickerFormat.Short;
            dateEnd.Icon = (Image)resources.GetObject("dateEnd.Icon");
            dateEnd.IconColor = Color.Gray;
            dateEnd.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            dateEnd.LeftTextMargin = 5;
            dateEnd.Location = new Point(702, 9);
            dateEnd.Margin = new Padding(4);
            dateEnd.MinimumSize = new Size(0, 38);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(134, 38);
            dateEnd.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.AllowAnimations = true;
            btnSend.AllowMouseEffects = true;
            btnSend.AllowToggling = false;
            btnSend.Anchor = AnchorStyles.Left;
            btnSend.AnimationSpeed = 200;
            btnSend.AutoGenerateColors = false;
            btnSend.AutoRoundBorders = false;
            btnSend.AutoSizeLeftIcon = true;
            btnSend.AutoSizeRightIcon = true;
            btnSend.BackColor = Color.Transparent;
            btnSend.BackColor1 = Color.FromArgb(51, 122, 183);
            btnSend.BackgroundImage = (Image)resources.GetObject("btnSend.BackgroundImage");
            btnSend.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnSend.ButtonText = "Enviar";
            btnSend.ButtonTextMarginLeft = 0;
            btnSend.ColorContrastOnClick = 45;
            btnSend.ColorContrastOnHover = 45;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            btnSend.CustomizableEdges = borderEdges1;
            btnSend.DialogResult = DialogResult.None;
            btnSend.DisabledBorderColor = Color.FromArgb(191, 191, 191);
            btnSend.DisabledFillColor = Color.Empty;
            btnSend.DisabledForecolor = Color.Empty;
            btnSend.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            btnSend.Font = new Font("Segoe UI", 9F);
            btnSend.ForeColor = Color.White;
            btnSend.IconLeft = null;
            btnSend.IconLeftAlign = ContentAlignment.MiddleLeft;
            btnSend.IconLeftCursor = Cursors.Default;
            btnSend.IconLeftPadding = new Padding(11, 3, 3, 3);
            btnSend.IconMarginLeft = 11;
            btnSend.IconPadding = 10;
            btnSend.IconRight = null;
            btnSend.IconRightAlign = ContentAlignment.MiddleRight;
            btnSend.IconRightCursor = Cursors.Default;
            btnSend.IconRightPadding = new Padding(3, 3, 7, 3);
            btnSend.IconSize = 25;
            btnSend.IdleBorderColor = Color.Empty;
            btnSend.IdleBorderRadius = 0;
            btnSend.IdleBorderThickness = 0;
            btnSend.IdleFillColor = Color.Empty;
            btnSend.IdleIconLeftImage = null;
            btnSend.IdleIconRightImage = null;
            btnSend.IndicateFocus = false;
            btnSend.Location = new Point(7, 55);
            btnSend.Name = "btnSend";
            btnSend.OnDisabledState.BorderColor = Color.FromArgb(191, 191, 191);
            btnSend.OnDisabledState.BorderRadius = 34;
            btnSend.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnSend.OnDisabledState.BorderThickness = 1;
            btnSend.OnDisabledState.FillColor = Color.FromArgb(204, 204, 204);
            btnSend.OnDisabledState.ForeColor = Color.FromArgb(168, 160, 168);
            btnSend.OnDisabledState.IconLeftImage = null;
            btnSend.OnDisabledState.IconRightImage = null;
            btnSend.onHoverState.BorderColor = Color.FromArgb(30, 150, 255);
            btnSend.onHoverState.BorderRadius = 34;
            btnSend.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnSend.onHoverState.BorderThickness = 1;
            btnSend.onHoverState.FillColor = Color.FromArgb(30, 150, 255);
            btnSend.onHoverState.ForeColor = Color.White;
            btnSend.onHoverState.IconLeftImage = null;
            btnSend.onHoverState.IconRightImage = null;
            btnSend.OnIdleState.BorderColor = Color.DodgerBlue;
            btnSend.OnIdleState.BorderRadius = 34;
            btnSend.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnSend.OnIdleState.BorderThickness = 1;
            btnSend.OnIdleState.FillColor = Color.DodgerBlue;
            btnSend.OnIdleState.ForeColor = Color.White;
            btnSend.OnIdleState.IconLeftImage = null;
            btnSend.OnIdleState.IconRightImage = null;
            btnSend.OnPressedState.BorderColor = Color.FromArgb(40, 96, 144);
            btnSend.OnPressedState.BorderRadius = 34;
            btnSend.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            btnSend.OnPressedState.BorderThickness = 1;
            btnSend.OnPressedState.FillColor = Color.FromArgb(40, 96, 144);
            btnSend.OnPressedState.ForeColor = Color.White;
            btnSend.OnPressedState.IconLeftImage = null;
            btnSend.OnPressedState.IconRightImage = null;
            btnSend.Size = new Size(99, 39);
            btnSend.TabIndex = 4;
            btnSend.TextAlign = ContentAlignment.MiddleCenter;
            btnSend.TextAlignment = HorizontalAlignment.Center;
            btnSend.TextMarginLeft = 0;
            btnSend.TextPadding = new Padding(0);
            btnSend.UseDefaultRadiusAndThickness = true;
            btnSend.Click += btnSend_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(939, 533);
            Controls.Add(dgvDocs);
            Controls.Add(topbar);
            Name = "Main";
            Padding = new Padding(8);
            Text = "Main";
            Resize += Main_Resize;
            ((System.ComponentModel.ISupportInitialize)dgvDocs).EndInit();
            topbar.ResumeLayout(false);
            topbar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDataGridView dgvDocs;
        private FlowLayoutPanel topbar;
        private Bunifu.UI.WinForms.BunifuTextBox txtSearch;
        private Bunifu.UI.WinForms.BunifuDropdown cmbTypeDoc;
        private Bunifu.UI.WinForms.BunifuDatePicker dateStart;
        private Bunifu.UI.WinForms.BunifuDatePicker dateEnd;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnSend;
        private Bunifu.UI.WinForms.BunifuLabel lblTitle;
    }
}