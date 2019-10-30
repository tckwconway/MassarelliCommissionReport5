<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Search))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonClear = New System.Windows.Forms.Button
        Me.ButtonSearch = New System.Windows.Forms.Button
        Me.ButtonResetForm = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Labelcust = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxInvoiceNo = New System.Windows.Forms.TextBox
        Me.TextBoxOrderNo = New System.Windows.Forms.TextBox
        Me.TextBoxCustomerNo = New System.Windows.Forms.TextBox
        Me.TextBoxShipToNo = New System.Windows.Forms.TextBox
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonDelete2 = New System.Windows.Forms.Button
        Me.ButtonDelete1 = New System.Windows.Forms.Button
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ButtonSalesGroup = New System.Windows.Forms.Button
        Me.ListViewRepGroup2 = New System.Windows.Forms.ListView
        Me.ListViewRepGroup1 = New System.Windows.Forms.ListView
        Me.Splitter3 = New System.Windows.Forms.Splitter
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ButtonSalesRep = New System.Windows.Forms.Button
        Me.ListViewRep2 = New System.Windows.Forms.ListView
        Me.ListViewRep1 = New System.Windows.Forms.ListView
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonClear)
        Me.Panel1.Controls.Add(Me.ButtonSearch)
        Me.Panel1.Controls.Add(Me.ButtonResetForm)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(502, 154)
        Me.Panel1.TabIndex = 8
        '
        'ButtonClear
        '
        Me.ButtonClear.Image = Global.MassarelliCommissionReport.My.Resources.Resources.ClearGrid_05
        Me.ButtonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClear.Location = New System.Drawing.Point(12, 11)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(97, 26)
        Me.ButtonClear.TabIndex = 4
        Me.ButtonClear.Text = "Clear Criteria"
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Image = Global.MassarelliCommissionReport.My.Resources.Resources.Search_16x16
        Me.ButtonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSearch.Location = New System.Drawing.Point(390, 11)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(97, 26)
        Me.ButtonSearch.TabIndex = 3
        Me.ButtonSearch.Text = "Search"
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'ButtonResetForm
        '
        Me.ButtonResetForm.Image = Global.MassarelliCommissionReport.My.Resources.Resources.Switchview
        Me.ButtonResetForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonResetForm.Location = New System.Drawing.Point(117, 11)
        Me.ButtonResetForm.Name = "ButtonResetForm"
        Me.ButtonResetForm.Size = New System.Drawing.Size(97, 26)
        Me.ButtonResetForm.TabIndex = 2
        Me.ButtonResetForm.Text = "Reset Form"
        Me.ButtonResetForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonResetForm.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Labelcust)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.TextBoxInvoiceNo)
        Me.GroupBox4.Controls.Add(Me.TextBoxOrderNo)
        Me.GroupBox4.Controls.Add(Me.TextBoxCustomerNo)
        Me.GroupBox4.Controls.Add(Me.TextBoxShipToNo)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(477, 106)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Single Value: Ship-to, Customer, Invoice and Order #"
        '
        'Labelcust
        '
        Me.Labelcust.AutoSize = True
        Me.Labelcust.Location = New System.Drawing.Point(248, 54)
        Me.Labelcust.Name = "Labelcust"
        Me.Labelcust.Size = New System.Drawing.Size(0, 13)
        Me.Labelcust.TabIndex = 8
        Me.Labelcust.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(168, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Invoice Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Order Number"
        Me.Label4.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Customer Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(168, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ship-to Name"
        '
        'TextBoxInvoiceNo
        '
        Me.TextBoxInvoiceNo.Location = New System.Drawing.Point(271, 77)
        Me.TextBoxInvoiceNo.Name = "TextBoxInvoiceNo"
        Me.TextBoxInvoiceNo.Size = New System.Drawing.Size(196, 20)
        Me.TextBoxInvoiceNo.TabIndex = 3
        '
        'TextBoxOrderNo
        '
        Me.TextBoxOrderNo.Location = New System.Drawing.Point(9, 19)
        Me.TextBoxOrderNo.Name = "TextBoxOrderNo"
        Me.TextBoxOrderNo.Size = New System.Drawing.Size(38, 20)
        Me.TextBoxOrderNo.TabIndex = 2
        Me.TextBoxOrderNo.Visible = False
        '
        'TextBoxCustomerNo
        '
        Me.TextBoxCustomerNo.Location = New System.Drawing.Point(271, 51)
        Me.TextBoxCustomerNo.Name = "TextBoxCustomerNo"
        Me.TextBoxCustomerNo.Size = New System.Drawing.Size(196, 20)
        Me.TextBoxCustomerNo.TabIndex = 2
        '
        'TextBoxShipToNo
        '
        Me.TextBoxShipToNo.Location = New System.Drawing.Point(271, 25)
        Me.TextBoxShipToNo.Name = "TextBoxShipToNo"
        Me.TextBoxShipToNo.Size = New System.Drawing.Size(196, 20)
        Me.TextBoxShipToNo.TabIndex = 1
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 154)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(502, 10)
        Me.Splitter1.TabIndex = 9
        Me.Splitter1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 164)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(502, 88)
        Me.Panel2.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ButtonDelete2)
        Me.GroupBox2.Controls.Add(Me.ButtonDelete1)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerTo)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerFrom)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(478, 76)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment Date Range"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Select single date or range"
        '
        'ButtonDelete2
        '
        Me.ButtonDelete2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDelete2.Image = Global.MassarelliCommissionReport.My.Resources.Resources.Delete_X_1818
        Me.ButtonDelete2.Location = New System.Drawing.Point(446, 45)
        Me.ButtonDelete2.Name = "ButtonDelete2"
        Me.ButtonDelete2.Size = New System.Drawing.Size(21, 20)
        Me.ButtonDelete2.TabIndex = 12
        Me.ButtonDelete2.UseVisualStyleBackColor = True
        '
        'ButtonDelete1
        '
        Me.ButtonDelete1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDelete1.Image = Global.MassarelliCommissionReport.My.Resources.Resources.Delete_X_1818
        Me.ButtonDelete1.Location = New System.Drawing.Point(446, 19)
        Me.ButtonDelete1.Name = "ButtonDelete1"
        Me.ButtonDelete1.Size = New System.Drawing.Size(21, 20)
        Me.ButtonDelete1.TabIndex = 11
        Me.ButtonDelete1.UseVisualStyleBackColor = True
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(322, 45)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.Size = New System.Drawing.Size(115, 20)
        Me.DateTimePickerTo.TabIndex = 6
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(322, 19)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(115, 20)
        Me.DateTimePickerFrom.TabIndex = 4
        '
        'Splitter2
        '
        Me.Splitter2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(0, 252)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(502, 10)
        Me.Splitter2.TabIndex = 11
        Me.Splitter2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 262)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(502, 163)
        Me.Panel3.TabIndex = 12
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ButtonSalesGroup)
        Me.GroupBox3.Controls.Add(Me.ListViewRepGroup2)
        Me.GroupBox3.Controls.Add(Me.ListViewRepGroup1)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(478, 145)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sales Group"
        '
        'ButtonSalesGroup
        '
        Me.ButtonSalesGroup.Image = Global.MassarelliCommissionReport.My.Resources.Resources.GetData
        Me.ButtonSalesGroup.Location = New System.Drawing.Point(239, 62)
        Me.ButtonSalesGroup.Name = "ButtonSalesGroup"
        Me.ButtonSalesGroup.Size = New System.Drawing.Size(24, 21)
        Me.ButtonSalesGroup.TabIndex = 19
        Me.ButtonSalesGroup.UseVisualStyleBackColor = True
        '
        'ListViewRepGroup2
        '
        Me.ListViewRepGroup2.AllowDrop = True
        Me.ListViewRepGroup2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewRepGroup2.Location = New System.Drawing.Point(271, 14)
        Me.ListViewRepGroup2.Name = "ListViewRepGroup2"
        Me.ListViewRepGroup2.Size = New System.Drawing.Size(196, 122)
        Me.ListViewRepGroup2.TabIndex = 8
        Me.ListViewRepGroup2.UseCompatibleStateImageBehavior = False
        Me.ListViewRepGroup2.View = System.Windows.Forms.View.List
        '
        'ListViewRepGroup1
        '
        Me.ListViewRepGroup1.AllowDrop = True
        Me.ListViewRepGroup1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewRepGroup1.Location = New System.Drawing.Point(11, 14)
        Me.ListViewRepGroup1.Name = "ListViewRepGroup1"
        Me.ListViewRepGroup1.Size = New System.Drawing.Size(224, 122)
        Me.ListViewRepGroup1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewRepGroup1.TabIndex = 7
        Me.ListViewRepGroup1.UseCompatibleStateImageBehavior = False
        Me.ListViewRepGroup1.View = System.Windows.Forms.View.List
        '
        'Splitter3
        '
        Me.Splitter3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter3.Location = New System.Drawing.Point(0, 425)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(502, 10)
        Me.Splitter3.TabIndex = 13
        Me.Splitter3.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 435)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(502, 162)
        Me.Panel4.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ButtonSalesRep)
        Me.GroupBox1.Controls.Add(Me.ListViewRep2)
        Me.GroupBox1.Controls.Add(Me.ListViewRep1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(478, 147)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Sales Rep"
        '
        'ButtonSalesRep
        '
        Me.ButtonSalesRep.Image = Global.MassarelliCommissionReport.My.Resources.Resources.GetData
        Me.ButtonSalesRep.Location = New System.Drawing.Point(239, 65)
        Me.ButtonSalesRep.Name = "ButtonSalesRep"
        Me.ButtonSalesRep.Size = New System.Drawing.Size(24, 21)
        Me.ButtonSalesRep.TabIndex = 20
        Me.ButtonSalesRep.UseVisualStyleBackColor = True
        '
        'ListViewRep2
        '
        Me.ListViewRep2.AllowDrop = True
        Me.ListViewRep2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewRep2.Location = New System.Drawing.Point(271, 16)
        Me.ListViewRep2.Name = "ListViewRep2"
        Me.ListViewRep2.Size = New System.Drawing.Size(196, 122)
        Me.ListViewRep2.TabIndex = 10
        Me.ListViewRep2.UseCompatibleStateImageBehavior = False
        Me.ListViewRep2.View = System.Windows.Forms.View.List
        '
        'ListViewRep1
        '
        Me.ListViewRep1.AllowDrop = True
        Me.ListViewRep1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewRep1.Location = New System.Drawing.Point(11, 16)
        Me.ListViewRep1.Name = "ListViewRep1"
        Me.ListViewRep1.Size = New System.Drawing.Size(224, 122)
        Me.ListViewRep1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewRep1.TabIndex = 9
        Me.ListViewRep1.UseCompatibleStateImageBehavior = False
        Me.ListViewRep1.View = System.Windows.Forms.View.List
        '
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 597)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Splitter3)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Search"
        Me.Text = "Search"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCustomerNo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxShipToNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonDelete2 As System.Windows.Forms.Button
    Friend WithEvents ButtonDelete1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ListViewRepGroup2 As System.Windows.Forms.ListView
    Friend WithEvents ListViewRepGroup1 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListViewRep2 As System.Windows.Forms.ListView
    Friend WithEvents ListViewRep1 As System.Windows.Forms.ListView
    Friend WithEvents ButtonResetForm As System.Windows.Forms.Button
    Friend WithEvents ButtonSearch As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Labelcust As System.Windows.Forms.Label
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents ButtonSalesGroup As System.Windows.Forms.Button
    Friend WithEvents ButtonSalesRep As System.Windows.Forms.Button
End Class
