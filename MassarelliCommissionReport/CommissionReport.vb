Public Class CommissionReport

    Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillToolStripButton.Click
        Try
            Me.SpARGetCommissionReport_MAZTableAdapter.Fill(Me.CommissionDataNEW.spARGetCommissionReport_MAZ, New System.Nullable(Of Integer)(CType(CommdateToolStripTextBox.Text, Integer)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
