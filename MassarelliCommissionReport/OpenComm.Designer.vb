<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenComm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpenComm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridViewDraftCommission = New System.Windows.Forms.DataGridView()
        Me.DataGridViewFinalCommission = New System.Windows.Forms.DataGridView()
        Me.SelectedFinal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonFinalCommission = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDraftCommission = New System.Windows.Forms.RadioButton()
        Me.lblCommisionsExistNotice = New System.Windows.Forms.Label()
        Me.optExistingCommission = New System.Windows.Forms.RadioButton()
        Me.lblFinalCommission = New System.Windows.Forms.Label()
        Me.lblDraftCommission = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBoxCommDraftName = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonNewCommission = New System.Windows.Forms.RadioButton()
        Me.TextBoxPaymentDate = New System.Windows.Forms.TextBox()
        Me.SelectedDraft = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.optCanada = New System.Windows.Forms.RadioButton()
        Me.optUSA = New System.Windows.Forms.RadioButton()
        Me.ButtonOpenCommission = New System.Windows.Forms.Button()
        Me.ButtonFillGrids = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.OpenCommBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DraftID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DraftName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DraftPaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DraftUserDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BindingSourceDraftCommission = New System.Windows.Forms.BindingSource(Me.components)
        Me.FinalID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinalName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinalPaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinalUserDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BindingSourceFinalCommission = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridViewDraftCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewFinalCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OpenCommBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceDraftCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceFinalCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DataGridViewDraftCommission)
        Me.GroupBox1.Controls.Add(Me.DataGridViewFinalCommission)
        Me.GroupBox1.Controls.Add(Me.ButtonFillGrids)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(971, 401)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(8, 194)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Draft Commission"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Final Commission"
        '
        'DataGridViewDraftCommission
        '
        Me.DataGridViewDraftCommission.AllowUserToAddRows = False
        Me.DataGridViewDraftCommission.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewDraftCommission.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDraftCommission.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewDraftCommission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDraftCommission.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DraftID, Me.DraftName, Me.DraftPaymentDate, Me.DraftUserDate, Me.SelectedDraft})
        Me.DataGridViewDraftCommission.DataSource = Me.BindingSourceDraftCommission
        Me.DataGridViewDraftCommission.Location = New System.Drawing.Point(8, 221)
        Me.DataGridViewDraftCommission.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewDraftCommission.Name = "DataGridViewDraftCommission"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDraftCommission.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewDraftCommission.RowHeadersWidth = 22
        Me.DataGridViewDraftCommission.Size = New System.Drawing.Size(950, 173)
        Me.DataGridViewDraftCommission.TabIndex = 3
        '
        'DataGridViewFinalCommission
        '
        Me.DataGridViewFinalCommission.AllowUserToAddRows = False
        Me.DataGridViewFinalCommission.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewFinalCommission.AutoGenerateColumns = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewFinalCommission.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewFinalCommission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewFinalCommission.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FinalID, Me.FinalName, Me.FinalPaymentDate, Me.FinalUserDate, Me.SelectedFinal})
        Me.DataGridViewFinalCommission.DataSource = Me.BindingSourceFinalCommission
        Me.DataGridViewFinalCommission.Location = New System.Drawing.Point(8, 42)
        Me.DataGridViewFinalCommission.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewFinalCommission.Name = "DataGridViewFinalCommission"
        Me.DataGridViewFinalCommission.ReadOnly = True
        Me.DataGridViewFinalCommission.RowHeadersWidth = 22
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewFinalCommission.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewFinalCommission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewFinalCommission.Size = New System.Drawing.Size(950, 148)
        Me.DataGridViewFinalCommission.TabIndex = 2
        '
        'SelectedFinal
        '
        Me.SelectedFinal.HeaderText = ""
        Me.SelectedFinal.Name = "SelectedFinal"
        Me.SelectedFinal.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.lblCommisionsExistNotice)
        Me.GroupBox2.Controls.Add(Me.optExistingCommission)
        Me.GroupBox2.Controls.Add(Me.lblFinalCommission)
        Me.GroupBox2.Controls.Add(Me.lblDraftCommission)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.TextBoxCommDraftName)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.RadioButtonNewCommission)
        Me.GroupBox2.Controls.Add(Me.TextBoxPaymentDate)
        Me.GroupBox2.Controls.Add(Me.ButtonOpenCommission)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 409)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(971, 162)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.RadioButtonFinalCommission)
        Me.GroupBox5.Controls.Add(Me.RadioButtonDraftCommission)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(385, 81)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(176, 71)
        Me.GroupBox5.TabIndex = 17
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Visible = False
        '
        'RadioButtonFinalCommission
        '
        Me.RadioButtonFinalCommission.AutoSize = True
        Me.RadioButtonFinalCommission.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RadioButtonFinalCommission.Enabled = False
        Me.RadioButtonFinalCommission.Location = New System.Drawing.Point(9, 41)
        Me.RadioButtonFinalCommission.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButtonFinalCommission.Name = "RadioButtonFinalCommission"
        Me.RadioButtonFinalCommission.Size = New System.Drawing.Size(165, 27)
        Me.RadioButtonFinalCommission.TabIndex = 8
        Me.RadioButtonFinalCommission.Text = "Final Commission"
        Me.RadioButtonFinalCommission.UseVisualStyleBackColor = False
        '
        'RadioButtonDraftCommission
        '
        Me.RadioButtonDraftCommission.AutoSize = True
        Me.RadioButtonDraftCommission.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RadioButtonDraftCommission.Enabled = False
        Me.RadioButtonDraftCommission.Location = New System.Drawing.Point(8, 13)
        Me.RadioButtonDraftCommission.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButtonDraftCommission.Name = "RadioButtonDraftCommission"
        Me.RadioButtonDraftCommission.Size = New System.Drawing.Size(168, 27)
        Me.RadioButtonDraftCommission.TabIndex = 7
        Me.RadioButtonDraftCommission.Text = "Draft Commission"
        Me.RadioButtonDraftCommission.UseVisualStyleBackColor = False
        '
        'lblCommisionsExistNotice
        '
        Me.lblCommisionsExistNotice.AutoSize = True
        Me.lblCommisionsExistNotice.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCommisionsExistNotice.Location = New System.Drawing.Point(585, 95)
        Me.lblCommisionsExistNotice.Name = "lblCommisionsExistNotice"
        Me.lblCommisionsExistNotice.Size = New System.Drawing.Size(169, 17)
        Me.lblCommisionsExistNotice.TabIndex = 16
        Me.lblCommisionsExistNotice.Text = "COMMISSIONS EXIST "
        '
        'optExistingCommission
        '
        Me.optExistingCommission.AutoSize = True
        Me.optExistingCommission.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.optExistingCommission.Enabled = False
        Me.optExistingCommission.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optExistingCommission.Location = New System.Drawing.Point(373, 58)
        Me.optExistingCommission.Margin = New System.Windows.Forms.Padding(4)
        Me.optExistingCommission.Name = "optExistingCommission"
        Me.optExistingCommission.Size = New System.Drawing.Size(188, 27)
        Me.optExistingCommission.TabIndex = 15
        Me.optExistingCommission.Text = "Existing Commission"
        Me.optExistingCommission.UseVisualStyleBackColor = False
        '
        'lblFinalCommission
        '
        Me.lblFinalCommission.AutoSize = True
        Me.lblFinalCommission.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinalCommission.Location = New System.Drawing.Point(585, 103)
        Me.lblFinalCommission.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFinalCommission.Name = "lblFinalCommission"
        Me.lblFinalCommission.Size = New System.Drawing.Size(0, 17)
        Me.lblFinalCommission.TabIndex = 14
        '
        'lblDraftCommission
        '
        Me.lblDraftCommission.AutoSize = True
        Me.lblDraftCommission.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDraftCommission.Location = New System.Drawing.Point(585, 103)
        Me.lblDraftCommission.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDraftCommission.Name = "lblDraftCommission"
        Me.lblDraftCommission.Size = New System.Drawing.Size(0, 17)
        Me.lblDraftCommission.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Enter Date as YYYYMMDD"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optCanada)
        Me.GroupBox4.Controls.Add(Me.optUSA)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.Location = New System.Drawing.Point(575, 9)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(107, 78)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        '
        'TextBoxCommDraftName
        '
        Me.TextBoxCommDraftName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OpenCommBindingSource, "CommDraftID", True))
        Me.TextBoxCommDraftName.Location = New System.Drawing.Point(12, 165)
        Me.TextBoxCommDraftName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxCommDraftName.Name = "TextBoxCommDraftName"
        Me.TextBoxCommDraftName.Size = New System.Drawing.Size(263, 22)
        Me.TextBoxCommDraftName.TabIndex = 9
        Me.TextBoxCommDraftName.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(352, 9)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(3, 143)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'RadioButtonNewCommission
        '
        Me.RadioButtonNewCommission.AutoSize = True
        Me.RadioButtonNewCommission.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RadioButtonNewCommission.Enabled = False
        Me.RadioButtonNewCommission.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.RadioButtonNewCommission.FlatAppearance.BorderSize = 10
        Me.RadioButtonNewCommission.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.RadioButtonNewCommission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RadioButtonNewCommission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.RadioButtonNewCommission.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonNewCommission.Location = New System.Drawing.Point(373, 25)
        Me.RadioButtonNewCommission.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButtonNewCommission.Name = "RadioButtonNewCommission"
        Me.RadioButtonNewCommission.Size = New System.Drawing.Size(164, 27)
        Me.RadioButtonNewCommission.TabIndex = 4
        Me.RadioButtonNewCommission.Text = "New Commission"
        Me.RadioButtonNewCommission.UseVisualStyleBackColor = False
        '
        'TextBoxPaymentDate
        '
        Me.TextBoxPaymentDate.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPaymentDate.Location = New System.Drawing.Point(228, 20)
        Me.TextBoxPaymentDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPaymentDate.Name = "TextBoxPaymentDate"
        Me.TextBoxPaymentDate.Size = New System.Drawing.Size(116, 30)
        Me.TextBoxPaymentDate.TabIndex = 1
        '
        'SelectedDraft
        '
        Me.SelectedDraft.HeaderText = ""
        Me.SelectedDraft.Name = "SelectedDraft"
        Me.SelectedDraft.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SelectedDraft.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'optCanada
        '
        Me.optCanada.AutoSize = True
        Me.optCanada.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optCanada.Image = Global.MassarelliCommissionReport.My.Resources.Resources.CAFlag4
        Me.optCanada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.optCanada.Location = New System.Drawing.Point(15, 44)
        Me.optCanada.Margin = New System.Windows.Forms.Padding(4)
        Me.optCanada.Name = "optCanada"
        Me.optCanada.Size = New System.Drawing.Size(85, 27)
        Me.optCanada.TabIndex = 3
        Me.optCanada.Text = "    CAD"
        Me.optCanada.UseVisualStyleBackColor = True
        '
        'optUSA
        '
        Me.optUSA.AutoSize = True
        Me.optUSA.Checked = True
        Me.optUSA.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optUSA.Image = Global.MassarelliCommissionReport.My.Resources.Resources.USFlag41
        Me.optUSA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.optUSA.Location = New System.Drawing.Point(15, 16)
        Me.optUSA.Margin = New System.Windows.Forms.Padding(4)
        Me.optUSA.Name = "optUSA"
        Me.optUSA.Size = New System.Drawing.Size(83, 27)
        Me.optUSA.TabIndex = 2
        Me.optUSA.TabStop = True
        Me.optUSA.Text = "    USA"
        Me.optUSA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optUSA.UseVisualStyleBackColor = True
        '
        'ButtonOpenCommission
        '
        Me.ButtonOpenCommission.Enabled = False
        Me.ButtonOpenCommission.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOpenCommission.Image = Global.MassarelliCommissionReport.My.Resources.Resources.folder_action_open3232
        Me.ButtonOpenCommission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonOpenCommission.Location = New System.Drawing.Point(696, 21)
        Me.ButtonOpenCommission.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonOpenCommission.Name = "ButtonOpenCommission"
        Me.ButtonOpenCommission.Size = New System.Drawing.Size(102, 60)
        Me.ButtonOpenCommission.TabIndex = 7
        Me.ButtonOpenCommission.Text = "Open"
        Me.ButtonOpenCommission.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonOpenCommission.UseVisualStyleBackColor = True
        '
        'ButtonFillGrids
        '
        Me.ButtonFillGrids.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFillGrids.Image = Global.MassarelliCommissionReport.My.Resources.Resources.LoadAllItems02
        Me.ButtonFillGrids.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonFillGrids.Location = New System.Drawing.Point(753, 9)
        Me.ButtonFillGrids.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonFillGrids.Name = "ButtonFillGrids"
        Me.ButtonFillGrids.Size = New System.Drawing.Size(205, 31)
        Me.ButtonFillGrids.TabIndex = 8
        Me.ButtonFillGrids.Text = "Refresh Grids"
        Me.ButtonFillGrids.UseVisualStyleBackColor = True
        Me.ButtonFillGrids.Visible = False
        '
        'OpenCommBindingSource
        '
        Me.OpenCommBindingSource.DataSource = GetType(MassarelliCommissionReport.OpenComm)
        '
        'DraftID
        '
        Me.DraftID.DataPropertyName = "DraftID"
        Me.DraftID.HeaderText = "Draft ID"
        Me.DraftID.Name = "DraftID"
        Me.DraftID.Visible = False
        Me.DraftID.Width = 120
        '
        'DraftName
        '
        Me.DraftName.DataPropertyName = "DraftName"
        Me.DraftName.HeaderText = "Draft Name"
        Me.DraftName.Name = "DraftName"
        Me.DraftName.Width = 250
        '
        'DraftPaymentDate
        '
        Me.DraftPaymentDate.DataPropertyName = "PaymentDate"
        Me.DraftPaymentDate.HeaderText = "Payment Date"
        Me.DraftPaymentDate.Name = "DraftPaymentDate"
        Me.DraftPaymentDate.Width = 150
        '
        'DraftUserDate
        '
        Me.DraftUserDate.DataPropertyName = "UserDate"
        Me.DraftUserDate.HeaderText = "User Date"
        Me.DraftUserDate.Name = "DraftUserDate"
        Me.DraftUserDate.Width = 150
        '
        'BindingSourceDraftCommission
        '
        Me.BindingSourceDraftCommission.DataSource = GetType(BOCommissionReport.DraftCommissionHdrObj)
        '
        'FinalID
        '
        Me.FinalID.DataPropertyName = "DraftID"
        Me.FinalID.HeaderText = "Comm ID"
        Me.FinalID.Name = "FinalID"
        Me.FinalID.ReadOnly = True
        Me.FinalID.Visible = False
        Me.FinalID.Width = 120
        '
        'FinalName
        '
        Me.FinalName.DataPropertyName = "DraftName"
        Me.FinalName.HeaderText = "Commission Name"
        Me.FinalName.Name = "FinalName"
        Me.FinalName.ReadOnly = True
        Me.FinalName.Width = 250
        '
        'FinalPaymentDate
        '
        Me.FinalPaymentDate.DataPropertyName = "PaymentDate"
        Me.FinalPaymentDate.HeaderText = "Payment Date"
        Me.FinalPaymentDate.Name = "FinalPaymentDate"
        Me.FinalPaymentDate.ReadOnly = True
        Me.FinalPaymentDate.Width = 150
        '
        'FinalUserDate
        '
        Me.FinalUserDate.DataPropertyName = "UserDate"
        Me.FinalUserDate.HeaderText = "Create Date"
        Me.FinalUserDate.Name = "FinalUserDate"
        Me.FinalUserDate.ReadOnly = True
        Me.FinalUserDate.Width = 150
        '
        'BindingSourceFinalCommission
        '
        Me.BindingSourceFinalCommission.DataSource = GetType(BOCommissionReport.DraftCommissionHdrObj)
        '
        'OpenComm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 612)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "OpenComm"
        Me.Text = "Open Commission"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridViewDraftCommission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewFinalCommission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OpenCommBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceDraftCommission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceFinalCommission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSourceDraftCommission As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSourceFinalCommission As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewDraftCommission As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewFinalCommission As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxPaymentDate As System.Windows.Forms.TextBox
    Friend WithEvents ButtonOpenCommission As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonNewCommission As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonFillGrids As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents TextBoxCommDraftName As System.Windows.Forms.TextBox
    Friend WithEvents OpenCommBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents optCanada As System.Windows.Forms.RadioButton
    Friend WithEvents optUSA As System.Windows.Forms.RadioButton
    Friend WithEvents lblFinalCommission As System.Windows.Forms.Label
    Friend WithEvents lblDraftCommission As System.Windows.Forms.Label
    Friend WithEvents optExistingCommission As System.Windows.Forms.RadioButton
    Friend WithEvents lblCommisionsExistNotice As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonFinalCommission As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDraftCommission As System.Windows.Forms.RadioButton
    Friend WithEvents FinalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinalName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinalPaymentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinalUserDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectedFinal As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DraftID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DraftName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DraftPaymentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DraftUserDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectedDraft As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
