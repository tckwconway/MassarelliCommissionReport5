<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveAs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveAs))
        Me.SavedCommFileDateObjDataGridView = New System.Windows.Forms.DataGridView()
        Me.DraftID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DraftName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblUSAorCAN = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxFileName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxPaymentDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picUSAorCAN = New System.Windows.Forms.PictureBox()
        Me.ButtonAddPaymentDatePrefix = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.DraftIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DraftNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepGroupDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalesPersonNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalesPersonNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShipToNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShipToStateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillToStateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShipDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FreightAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FreightPercentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NetSalesAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiscountAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PickupAllowanceAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmountPaidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommissionPercentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SS12DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommissionAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CusNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CusNoStrippedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSalesAmtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BatchIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BatchIDStrippedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SavedCommFileDateObjBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.SavedCommFileDateObjDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picUSAorCAN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SavedCommFileDateObjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SavedCommFileDateObjDataGridView
        '
        Me.SavedCommFileDateObjDataGridView.AllowUserToAddRows = False
        Me.SavedCommFileDateObjDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SavedCommFileDateObjDataGridView.AutoGenerateColumns = False
        Me.SavedCommFileDateObjDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SavedCommFileDateObjDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DraftID, Me.DraftName, Me.PaymentDate, Me.UserDate, Me.DraftIDDataGridViewTextBoxColumn, Me.UserDateDataGridViewTextBoxColumn, Me.DraftNameDataGridViewTextBoxColumn, Me.RepGroupDataGridViewTextBoxColumn, Me.SalesPersonNumberDataGridViewTextBoxColumn, Me.SalesPersonNameDataGridViewTextBoxColumn, Me.InvoiceNumberDataGridViewTextBoxColumn, Me.ShipToNameDataGridViewTextBoxColumn, Me.ShipToStateDataGridViewTextBoxColumn, Me.BillToStateDataGridViewTextBoxColumn, Me.OrderDateDataGridViewTextBoxColumn, Me.ShipDateDataGridViewTextBoxColumn, Me.PaymentDateDataGridViewTextBoxColumn, Me.FreightAmountDataGridViewTextBoxColumn, Me.FreightPercentDataGridViewTextBoxColumn, Me.NetSalesAmountDataGridViewTextBoxColumn, Me.DiscountAmountDataGridViewTextBoxColumn, Me.PickupAllowanceAmountDataGridViewTextBoxColumn, Me.AmountPaidDataGridViewTextBoxColumn, Me.CommissionPercentDataGridViewTextBoxColumn, Me.SS12DataGridViewTextBoxColumn, Me.CommissionAmountDataGridViewTextBoxColumn, Me.ReferenceDataGridViewTextBoxColumn, Me.CommIDDataGridViewTextBoxColumn, Me.CusNoDataGridViewTextBoxColumn, Me.CusNoStrippedDataGridViewTextBoxColumn, Me.TotalSalesAmtDataGridViewTextBoxColumn, Me.BatchIDDataGridViewTextBoxColumn, Me.BatchIDStrippedDataGridViewTextBoxColumn})
        Me.SavedCommFileDateObjDataGridView.DataSource = Me.SavedCommFileDateObjBindingSource
        Me.SavedCommFileDateObjDataGridView.Location = New System.Drawing.Point(8, 36)
        Me.SavedCommFileDateObjDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.SavedCommFileDateObjDataGridView.Name = "SavedCommFileDateObjDataGridView"
        Me.SavedCommFileDateObjDataGridView.RowHeadersWidth = 22
        Me.SavedCommFileDateObjDataGridView.Size = New System.Drawing.Size(741, 236)
        Me.SavedCommFileDateObjDataGridView.TabIndex = 1
        '
        'DraftID
        '
        Me.DraftID.DataPropertyName = "DraftID"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DraftID.DefaultCellStyle = DataGridViewCellStyle1
        Me.DraftID.HeaderText = "Draft ID"
        Me.DraftID.Name = "DraftID"
        Me.DraftID.Visible = False
        Me.DraftID.Width = 80
        '
        'DraftName
        '
        Me.DraftName.DataPropertyName = "DraftName"
        Me.DraftName.HeaderText = "DraftName"
        Me.DraftName.Name = "DraftName"
        Me.DraftName.Width = 250
        '
        'PaymentDate
        '
        Me.PaymentDate.DataPropertyName = "PaymentDate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "MM/dd/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PaymentDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.PaymentDate.HeaderText = "PaymentDate"
        Me.PaymentDate.Name = "PaymentDate"
        Me.PaymentDate.Width = 80
        '
        'UserDate
        '
        Me.UserDate.DataPropertyName = "UserDate"
        DataGridViewCellStyle3.Format = "g"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.UserDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.UserDate.HeaderText = "Create Date/Time"
        Me.UserDate.Name = "UserDate"
        Me.UserDate.Width = 120
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ButtonAddPaymentDatePrefix)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBoxFileName)
        Me.GroupBox1.Controls.Add(Me.ButtonCancel)
        Me.GroupBox1.Controls.Add(Me.ButtonSave)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 280)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(741, 113)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblUSAorCAN)
        Me.GroupBox2.Controls.Add(Me.picUSAorCAN)
        Me.GroupBox2.Location = New System.Drawing.Point(621, 12)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(112, 36)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'lblUSAorCAN
        '
        Me.lblUSAorCAN.AutoSize = True
        Me.lblUSAorCAN.Location = New System.Drawing.Point(40, 14)
        Me.lblUSAorCAN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUSAorCAN.Name = "lblUSAorCAN"
        Me.lblUSAorCAN.Size = New System.Drawing.Size(0, 17)
        Me.lblUSAorCAN.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 62)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(286, 25)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "AUTO-Insert Commission Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Save Commission Name"
        '
        'TextBoxFileName
        '
        Me.TextBoxFileName.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFileName.Location = New System.Drawing.Point(302, 17)
        Me.TextBoxFileName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxFileName.MaxLength = 30
        Me.TextBoxFileName.Name = "TextBoxFileName"
        Me.TextBoxFileName.Size = New System.Drawing.Size(311, 31)
        Me.TextBoxFileName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(478, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Payment Date: "
        '
        'TextBoxPaymentDate
        '
        Me.TextBoxPaymentDate.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxPaymentDate.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPaymentDate.Location = New System.Drawing.Point(629, 1)
        Me.TextBoxPaymentDate.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPaymentDate.Name = "TextBoxPaymentDate"
        Me.TextBoxPaymentDate.ReadOnly = True
        Me.TextBoxPaymentDate.Size = New System.Drawing.Size(120, 31)
        Me.TextBoxPaymentDate.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 4)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(247, 25)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Existing Draft Commissions"
        '
        'picUSAorCAN
        '
        Me.picUSAorCAN.Image = Global.MassarelliCommissionReport.My.Resources.Resources.USFlag4
        Me.picUSAorCAN.Location = New System.Drawing.Point(11, 12)
        Me.picUSAorCAN.Margin = New System.Windows.Forms.Padding(4)
        Me.picUSAorCAN.Name = "picUSAorCAN"
        Me.picUSAorCAN.Size = New System.Drawing.Size(27, 16)
        Me.picUSAorCAN.TabIndex = 12
        Me.picUSAorCAN.TabStop = False
        '
        'ButtonAddPaymentDatePrefix
        '
        Me.ButtonAddPaymentDatePrefix.Image = Global.MassarelliCommissionReport.My.Resources.Resources.InsertName
        Me.ButtonAddPaymentDatePrefix.Location = New System.Drawing.Point(302, 50)
        Me.ButtonAddPaymentDatePrefix.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAddPaymentDatePrefix.Name = "ButtonAddPaymentDatePrefix"
        Me.ButtonAddPaymentDatePrefix.Size = New System.Drawing.Size(50, 46)
        Me.ButtonAddPaymentDatePrefix.TabIndex = 2
        Me.ButtonAddPaymentDatePrefix.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancel.Image = Global.MassarelliCommissionReport.My.Resources.Resources.Cancel3232
        Me.ButtonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancel.Location = New System.Drawing.Point(621, 50)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(112, 46)
        Me.ButtonCancel.TabIndex = 4
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSave.Image = Global.MassarelliCommissionReport.My.Resources.Resources.Save3232
        Me.ButtonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSave.Location = New System.Drawing.Point(501, 50)
        Me.ButtonSave.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(112, 46)
        Me.ButtonSave.TabIndex = 3
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'DraftIDDataGridViewTextBoxColumn
        '
        Me.DraftIDDataGridViewTextBoxColumn.DataPropertyName = "DraftID"
        Me.DraftIDDataGridViewTextBoxColumn.HeaderText = "DraftID"
        Me.DraftIDDataGridViewTextBoxColumn.Name = "DraftIDDataGridViewTextBoxColumn"
        '
        'UserDateDataGridViewTextBoxColumn
        '
        Me.UserDateDataGridViewTextBoxColumn.DataPropertyName = "UserDate"
        Me.UserDateDataGridViewTextBoxColumn.HeaderText = "UserDate"
        Me.UserDateDataGridViewTextBoxColumn.Name = "UserDateDataGridViewTextBoxColumn"
        '
        'DraftNameDataGridViewTextBoxColumn
        '
        Me.DraftNameDataGridViewTextBoxColumn.DataPropertyName = "DraftName"
        Me.DraftNameDataGridViewTextBoxColumn.HeaderText = "DraftName"
        Me.DraftNameDataGridViewTextBoxColumn.Name = "DraftNameDataGridViewTextBoxColumn"
        '
        'RepGroupDataGridViewTextBoxColumn
        '
        Me.RepGroupDataGridViewTextBoxColumn.DataPropertyName = "RepGroup"
        Me.RepGroupDataGridViewTextBoxColumn.HeaderText = "RepGroup"
        Me.RepGroupDataGridViewTextBoxColumn.Name = "RepGroupDataGridViewTextBoxColumn"
        '
        'SalesPersonNumberDataGridViewTextBoxColumn
        '
        Me.SalesPersonNumberDataGridViewTextBoxColumn.DataPropertyName = "SalesPersonNumber"
        Me.SalesPersonNumberDataGridViewTextBoxColumn.HeaderText = "SalesPersonNumber"
        Me.SalesPersonNumberDataGridViewTextBoxColumn.Name = "SalesPersonNumberDataGridViewTextBoxColumn"
        '
        'SalesPersonNameDataGridViewTextBoxColumn
        '
        Me.SalesPersonNameDataGridViewTextBoxColumn.DataPropertyName = "SalesPersonName"
        Me.SalesPersonNameDataGridViewTextBoxColumn.HeaderText = "SalesPersonName"
        Me.SalesPersonNameDataGridViewTextBoxColumn.Name = "SalesPersonNameDataGridViewTextBoxColumn"
        '
        'InvoiceNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn.Name = "InvoiceNumberDataGridViewTextBoxColumn"
        '
        'ShipToNameDataGridViewTextBoxColumn
        '
        Me.ShipToNameDataGridViewTextBoxColumn.DataPropertyName = "ShipToName"
        Me.ShipToNameDataGridViewTextBoxColumn.HeaderText = "ShipToName"
        Me.ShipToNameDataGridViewTextBoxColumn.Name = "ShipToNameDataGridViewTextBoxColumn"
        '
        'ShipToStateDataGridViewTextBoxColumn
        '
        Me.ShipToStateDataGridViewTextBoxColumn.DataPropertyName = "ShipToState"
        Me.ShipToStateDataGridViewTextBoxColumn.HeaderText = "ShipToState"
        Me.ShipToStateDataGridViewTextBoxColumn.Name = "ShipToStateDataGridViewTextBoxColumn"
        '
        'BillToStateDataGridViewTextBoxColumn
        '
        Me.BillToStateDataGridViewTextBoxColumn.DataPropertyName = "BillToState"
        Me.BillToStateDataGridViewTextBoxColumn.HeaderText = "BillToState"
        Me.BillToStateDataGridViewTextBoxColumn.Name = "BillToStateDataGridViewTextBoxColumn"
        '
        'OrderDateDataGridViewTextBoxColumn
        '
        Me.OrderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate"
        Me.OrderDateDataGridViewTextBoxColumn.HeaderText = "OrderDate"
        Me.OrderDateDataGridViewTextBoxColumn.Name = "OrderDateDataGridViewTextBoxColumn"
        '
        'ShipDateDataGridViewTextBoxColumn
        '
        Me.ShipDateDataGridViewTextBoxColumn.DataPropertyName = "ShipDate"
        Me.ShipDateDataGridViewTextBoxColumn.HeaderText = "ShipDate"
        Me.ShipDateDataGridViewTextBoxColumn.Name = "ShipDateDataGridViewTextBoxColumn"
        '
        'PaymentDateDataGridViewTextBoxColumn
        '
        Me.PaymentDateDataGridViewTextBoxColumn.DataPropertyName = "PaymentDate"
        Me.PaymentDateDataGridViewTextBoxColumn.HeaderText = "PaymentDate"
        Me.PaymentDateDataGridViewTextBoxColumn.Name = "PaymentDateDataGridViewTextBoxColumn"
        '
        'FreightAmountDataGridViewTextBoxColumn
        '
        Me.FreightAmountDataGridViewTextBoxColumn.DataPropertyName = "FreightAmount"
        Me.FreightAmountDataGridViewTextBoxColumn.HeaderText = "FreightAmount"
        Me.FreightAmountDataGridViewTextBoxColumn.Name = "FreightAmountDataGridViewTextBoxColumn"
        '
        'FreightPercentDataGridViewTextBoxColumn
        '
        Me.FreightPercentDataGridViewTextBoxColumn.DataPropertyName = "FreightPercent"
        Me.FreightPercentDataGridViewTextBoxColumn.HeaderText = "FreightPercent"
        Me.FreightPercentDataGridViewTextBoxColumn.Name = "FreightPercentDataGridViewTextBoxColumn"
        '
        'NetSalesAmountDataGridViewTextBoxColumn
        '
        Me.NetSalesAmountDataGridViewTextBoxColumn.DataPropertyName = "NetSalesAmount"
        Me.NetSalesAmountDataGridViewTextBoxColumn.HeaderText = "NetSalesAmount"
        Me.NetSalesAmountDataGridViewTextBoxColumn.Name = "NetSalesAmountDataGridViewTextBoxColumn"
        '
        'DiscountAmountDataGridViewTextBoxColumn
        '
        Me.DiscountAmountDataGridViewTextBoxColumn.DataPropertyName = "DiscountAmount"
        Me.DiscountAmountDataGridViewTextBoxColumn.HeaderText = "DiscountAmount"
        Me.DiscountAmountDataGridViewTextBoxColumn.Name = "DiscountAmountDataGridViewTextBoxColumn"
        '
        'PickupAllowanceAmountDataGridViewTextBoxColumn
        '
        Me.PickupAllowanceAmountDataGridViewTextBoxColumn.DataPropertyName = "PickupAllowanceAmount"
        Me.PickupAllowanceAmountDataGridViewTextBoxColumn.HeaderText = "PickupAllowanceAmount"
        Me.PickupAllowanceAmountDataGridViewTextBoxColumn.Name = "PickupAllowanceAmountDataGridViewTextBoxColumn"
        '
        'AmountPaidDataGridViewTextBoxColumn
        '
        Me.AmountPaidDataGridViewTextBoxColumn.DataPropertyName = "AmountPaid"
        Me.AmountPaidDataGridViewTextBoxColumn.HeaderText = "AmountPaid"
        Me.AmountPaidDataGridViewTextBoxColumn.Name = "AmountPaidDataGridViewTextBoxColumn"
        '
        'CommissionPercentDataGridViewTextBoxColumn
        '
        Me.CommissionPercentDataGridViewTextBoxColumn.DataPropertyName = "CommissionPercent"
        Me.CommissionPercentDataGridViewTextBoxColumn.HeaderText = "CommissionPercent"
        Me.CommissionPercentDataGridViewTextBoxColumn.Name = "CommissionPercentDataGridViewTextBoxColumn"
        '
        'SS12DataGridViewTextBoxColumn
        '
        Me.SS12DataGridViewTextBoxColumn.DataPropertyName = "SS12"
        Me.SS12DataGridViewTextBoxColumn.HeaderText = "SS12"
        Me.SS12DataGridViewTextBoxColumn.Name = "SS12DataGridViewTextBoxColumn"
        '
        'CommissionAmountDataGridViewTextBoxColumn
        '
        Me.CommissionAmountDataGridViewTextBoxColumn.DataPropertyName = "CommissionAmount"
        Me.CommissionAmountDataGridViewTextBoxColumn.HeaderText = "CommissionAmount"
        Me.CommissionAmountDataGridViewTextBoxColumn.Name = "CommissionAmountDataGridViewTextBoxColumn"
        '
        'ReferenceDataGridViewTextBoxColumn
        '
        Me.ReferenceDataGridViewTextBoxColumn.DataPropertyName = "Reference"
        Me.ReferenceDataGridViewTextBoxColumn.HeaderText = "Reference"
        Me.ReferenceDataGridViewTextBoxColumn.Name = "ReferenceDataGridViewTextBoxColumn"
        '
        'CommIDDataGridViewTextBoxColumn
        '
        Me.CommIDDataGridViewTextBoxColumn.DataPropertyName = "CommID"
        Me.CommIDDataGridViewTextBoxColumn.HeaderText = "CommID"
        Me.CommIDDataGridViewTextBoxColumn.Name = "CommIDDataGridViewTextBoxColumn"
        '
        'CusNoDataGridViewTextBoxColumn
        '
        Me.CusNoDataGridViewTextBoxColumn.DataPropertyName = "CusNo"
        Me.CusNoDataGridViewTextBoxColumn.HeaderText = "CusNo"
        Me.CusNoDataGridViewTextBoxColumn.Name = "CusNoDataGridViewTextBoxColumn"
        '
        'CusNoStrippedDataGridViewTextBoxColumn
        '
        Me.CusNoStrippedDataGridViewTextBoxColumn.DataPropertyName = "CusNo_Stripped"
        Me.CusNoStrippedDataGridViewTextBoxColumn.HeaderText = "CusNo_Stripped"
        Me.CusNoStrippedDataGridViewTextBoxColumn.Name = "CusNoStrippedDataGridViewTextBoxColumn"
        '
        'TotalSalesAmtDataGridViewTextBoxColumn
        '
        Me.TotalSalesAmtDataGridViewTextBoxColumn.DataPropertyName = "TotalSalesAmt"
        Me.TotalSalesAmtDataGridViewTextBoxColumn.HeaderText = "TotalSalesAmt"
        Me.TotalSalesAmtDataGridViewTextBoxColumn.Name = "TotalSalesAmtDataGridViewTextBoxColumn"
        '
        'BatchIDDataGridViewTextBoxColumn
        '
        Me.BatchIDDataGridViewTextBoxColumn.DataPropertyName = "BatchID"
        Me.BatchIDDataGridViewTextBoxColumn.HeaderText = "BatchID"
        Me.BatchIDDataGridViewTextBoxColumn.Name = "BatchIDDataGridViewTextBoxColumn"
        '
        'BatchIDStrippedDataGridViewTextBoxColumn
        '
        Me.BatchIDStrippedDataGridViewTextBoxColumn.DataPropertyName = "BatchID_Stripped"
        Me.BatchIDStrippedDataGridViewTextBoxColumn.HeaderText = "BatchID_Stripped"
        Me.BatchIDStrippedDataGridViewTextBoxColumn.Name = "BatchIDStrippedDataGridViewTextBoxColumn"
        '
        'SavedCommFileDateObjBindingSource
        '
        Me.SavedCommFileDateObjBindingSource.DataSource = GetType(BOCommissionReport.DraftCommissionHdrObj)
        '
        'SaveAs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 397)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxPaymentDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SavedCommFileDateObjDataGridView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SaveAs"
        Me.Text = "Save As Draft Commission"
        CType(Me.SavedCommFileDateObjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picUSAorCAN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SavedCommFileDateObjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SavedCommFileDateObjBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SavedCommFileDateObjDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFileName As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPaymentDate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonAddPaymentDatePrefix As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DraftID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DraftName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DraftIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DraftNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepGroupDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesPersonNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesPersonNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToStateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillToStateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightPercentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NetSalesAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickupAllowanceAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountPaidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommissionPercentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SS12DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommissionAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CusNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CusNoStrippedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSalesAmtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchIDStrippedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUSAorCAN As System.Windows.Forms.Label
    Friend WithEvents picUSAorCAN As System.Windows.Forms.PictureBox
End Class
