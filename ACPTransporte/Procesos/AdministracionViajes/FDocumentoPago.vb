Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration

Public Class FDocumentoPago

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
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDocumentoPagoDet, 1, 1, 5, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentoPagoDet, index, "Unidad", "DPDET_UNIDAD", "DPDET_UNIDAD", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentoPagoDet, index, "Detalle", "DPDET_DETALLE", "DPDET_DETALLE", 300, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentoPagoDet, index, "Valor Unitario", "DPDET_VALORUNITARIO", "DPDET_VALORUNITARIO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentoPagoDet, index, "Cantidad", "DPDET_CANTIDAD", "DPDET_CANTIDAD", 100, True, False, "System.String", "") : index += 1
            c1grdDocumentoPagoDet.AllowEditing = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region

    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim fDocumentoPagoDetalle As New FDocumentoPagoDetalle()
        fDocumentoPagoDetalle.StartPosition = FormStartPosition.CenterScreen
        If fDocumentoPagoDetalle.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Ingresar funcionalidad que inserta objeto con datos para el documento pago detalle
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim fAsignacionItemDocPagDet As New FAsignacionItemDocPagDet()
        fAsignacionItemDocPagDet.StartPosition = FormStartPosition.CenterScreen
        If fAsignacionItemDocPagDet.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Ingresar funcionalidad que inserta objeto con datos para el documento pago detalle
        End If
    End Sub
End Class