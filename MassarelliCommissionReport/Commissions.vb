Public Class Commissions

    Private Sub ARCOMWRK_MAZBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARCOMWRK_MAZBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ARCOMWRK_MAZBindingSource.EndEdit()
        Me.ARCOMWRK_MAZTableAdapter.Update(Me.ARCOMWRK_MAZ._ARCOMWRK_MAZ)

    End Sub

    Private Sub Commissions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ARCOMWRK_MAZ._ARCOMWRK_MAZ' table. You can move, or remove it, as needed.
        Me.ARCOMWRK_MAZTableAdapter.Fill(Me.ARCOMWRK_MAZ._ARCOMWRK_MAZ)
        MacStartup()
    End Sub

    Private Sub ToolStripButtonGetCommisonData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonGetCommisonData.Click
        BusObj.GetCommissionData(CInt(ToolStripTextBoxCommisionDate.Text), cn)
        Me.ARCOMWRK_MAZTableAdapter.ClearBeforeFill = True
        Me.ARCOMWRK_MAZTableAdapter.Fill(Me.ARCOMWRK_MAZ._ARCOMWRK_MAZ)
    End Sub
End Class