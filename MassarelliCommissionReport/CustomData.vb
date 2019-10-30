<Serializable()> _
Public Class CustomData

    Private Shared _format As DataFormats.Format

    Private _rowlist As DataTable

    Shared Sub New()

        ' Registers a new data format with the windows Clipboard

        _format = DataFormats.GetFormat(GetType(CustomData).FullName)

    End Sub

    Public Sub New()

        MyBase.New()

    End Sub

    Public Shared ReadOnly Property Format() As DataFormats.Format

        Get

            Return _format

        End Get

    End Property

    Public Property rowlist() As DataTable

        Get

            Return _rowlist

        End Get

        Set(ByVal value As DataTable)

            _rowlist = value

        End Set

    End Property

    Public Overrides Function ToString() As String

        Return "customized format"

    End Function

End Class