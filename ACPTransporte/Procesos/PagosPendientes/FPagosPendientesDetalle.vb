Public Class FPagosPendientesDetalle

#Region " Constructores "
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Try
            formatearGrilla()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

#End Region

#Region " Utilitarios "
    ''' <summary>
    ''' Dar Formato a la grilla de busqueda
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub formatearGrilla()
        Dim index As Integer = 1
        Try
            'Deficion de grilla de Viajes
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdPagoPendienteDet, 1, 1, 5, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagoPendienteDet, index, "Unidad", "DPDET_UNIDAD", "DPDET_UNIDAD", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagoPendienteDet, index, "Detalle", "DPDET_DETALLE", "DPDET_DETALLE", 300, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagoPendienteDet, index, "Valor Unitario", "DPDET_VALORUNITARIO", "DPDET_VALORUNITARIO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagoPendienteDet, index, "Cantidad", "DPDET_CANTIDAD", "DPDET_CANTIDAD", 100, True, False, "System.String", "") : index += 1
            c1grdPagoPendienteDet.AllowEditing = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region

    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub

    Private Sub acTool_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.Load

    End Sub
End Class