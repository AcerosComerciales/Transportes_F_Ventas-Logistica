Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration

Public Class FSaldosClientes

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
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdClienteSaldos, 1, 1, 8, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdClienteSaldos, index, "Fecha", "GTDET_CODIGO", "GTDET_CODIGO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdClienteSaldos, index, "Tipo Documento", "DOCPF_NRO", "DOCPF_NRO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdClienteSaldos, index, "Nro Documento", "DOCPF_NRO", "DOCPF_NRO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdClienteSaldos, index, "Detalle", "DOCPF_DESCRIPCION", "DOCPF_DESCRIPCION", 250, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdClienteSaldos, index, "Ingreso", "DOCPF_DESCRIPCION", "DOCPF_DESCRIPCION", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdClienteSaldos, index, "Salida", "DOCPF_DESCRIPCION", "DOCPF_DESCRIPCION", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdClienteSaldos, index, "Saldo", "DOCPF_DESCRIPCION", "DOCPF_DESCRIPCION", 100, True, False, "System.String", "") : index += 1
            c1grdClienteSaldos.AllowEditing = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region

End Class