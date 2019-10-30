<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveAsPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveAsPassword))
        Me.TextBoxUserName = New System.Windows.Forms.TextBox
        Me.TextBoxPassword = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonSavePassword = New System.Windows.Forms.Button
        Me.ButtonOpenPassword = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBoxUserName
        '
        Me.TextBoxUserName.Location = New System.Drawing.Point(80, 26)
        Me.TextBoxUserName.Name = "TextBoxUserName"
        Me.TextBoxUserName.Size = New System.Drawing.Size(148, 20)
        Me.TextBoxUserName.TabIndex = 1
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(80, 52)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(148, 20)
        Me.TextBoxPassword.TabIndex = 2
        Me.TextBoxPassword.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "User name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        '
        'ButtonSavePassword
        '
        Me.ButtonSavePassword.Location = New System.Drawing.Point(241, 25)
        Me.ButtonSavePassword.Name = "ButtonSavePassword"
        Me.ButtonSavePassword.Size = New System.Drawing.Size(42, 21)
        Me.ButtonSavePassword.TabIndex = 3
        Me.ButtonSavePassword.Text = "Save"
        Me.ButtonSavePassword.UseVisualStyleBackColor = True
        Me.ButtonSavePassword.Visible = False
        '
        'ButtonOpenPassword
        '
        Me.ButtonOpenPassword.Location = New System.Drawing.Point(241, 51)
        Me.ButtonOpenPassword.Name = "ButtonOpenPassword"
        Me.ButtonOpenPassword.Size = New System.Drawing.Size(42, 21)
        Me.ButtonOpenPassword.TabIndex = 4
        Me.ButtonOpenPassword.Text = "Open"
        Me.ButtonOpenPassword.UseVisualStyleBackColor = True
        '
        'SaveAsPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 93)
        Me.Controls.Add(Me.ButtonOpenPassword)
        Me.Controls.Add(Me.ButtonSavePassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.TextBoxUserName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SaveAsPassword"
        Me.Text = "Final Commission Overwrite"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxUserName As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonSavePassword As System.Windows.Forms.Button
    Friend WithEvents ButtonOpenPassword As System.Windows.Forms.Button
End Class
