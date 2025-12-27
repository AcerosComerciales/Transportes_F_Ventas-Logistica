Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration

Public Class FAsignacionItemDocPagDet

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
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdGuiaTransportistaDet, 1, 1, 6, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaTransportistaDet, index, "Codigo", "GTDET_CODIGO", "GTDET_CODIGO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaTransportistaDet, index, "Descripcion", "GTDET_DESCRIPCION", "GTDET_DESCRIPCION", 300, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaTransportistaDet, index, "Unidad", "GTDET_UNIDAD", "GTDET_UNIDAD", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaTransportistaDet, index, "Peso", "GTDET_PESO", "GTDET_PESO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaTransportistaDet, index, "Cantidad", "GTDET_CANTIDAD", "GTDET_CANTIDAD", 100, True, False, "System.String", "") : index += 1
            c1grdGuiaTransportistaDet.AllowEditing = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region


    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub
End Class