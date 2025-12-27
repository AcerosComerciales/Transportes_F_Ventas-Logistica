Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration

Public Class FPagosPendientes

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
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdPagosPendientes, 1, 1, 6, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagosPendientes, index, "Tipo Documento", "GTDET_CODIGO", "GTDET_CODIGO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagosPendientes, index, "Nro Documento", "DOCPF_NRO", "DOCPF_NRO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagosPendientes, index, "Descripcion", "DOCPF_DESCRIPCION", "DOCPF_DESCRIPCION", 250, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagosPendientes, index, "Fec. Pago Acordado", "DOCPF_FECPAGOACORDADO", "DOCPF_FECPAGOACORDADO", 100, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagosPendientes, index, "Cancelado", "DOCPF_CANCELADO", "DOCPF_CANCELADO", 100, True, False, "System.String", "") : index += 1
            c1grdPagosPendientes.AllowEditing = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region

    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub

    Private Sub acTool_ACBtnRehusar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnRehusar_Click
        Dim fPagoPendientesDetalle As New FPagosPendientesDetalle()
        fPagoPendientesDetalle.StartPosition = FormStartPosition.CenterScreen
        If fPagoPendientesDetalle.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Ingresar funcionalidad que inserta objeto con datos para el documento pago detalle
        End If
    End Sub

   
End Class