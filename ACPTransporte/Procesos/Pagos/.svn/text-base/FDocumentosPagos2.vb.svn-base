Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration

Public Class FDocumentosPagos2

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
            'Definicion de grilla de Fletes
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDocumentosPagos, 1, 1, 7, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentosPagos, index, "Flete", "FLETE_Codigo", "FLETE_Codigo", 70, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentosPagos, index, "Tipo Documento", "TIPOS_Descripcion", "TIPOS_Descripcion", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentosPagos, index, "Nro", "DOCPF_NRO", "DOCPF_NRO", 70, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentosPagos, index, "Descripcion", "DOCPF_DESCRIPCION", "DOCPF_DESCRIPCION", 200, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentosPagos, index, "Fecha", "DOCPF_FECHA", "DOCPF_FECHA", 100, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocumentosPagos, index, "Valor Total", "DOCPF_VALORTOTAL", "DOCPF_VALORTOTAL", 100, True, False, "System.String", "") : index += 1
            c1grdDocumentosPagos.AllowEditing = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region


    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub
End Class