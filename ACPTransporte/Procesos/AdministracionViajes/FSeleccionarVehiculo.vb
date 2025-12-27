Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration

Public Class FSeleccionarVehiculo

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
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdConsultaVehiculos, 1, 1, 8, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsultaVehiculos, index, "Marca", "COTIZ_FECHA", "COTIZ_FECHA", 100, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsultaVehiculos, index, "Modelo", "COTIZ_NOMBRECLIENTE", "COTIZ_NOMBRECLIENTE", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsultaVehiculos, index, "Placa", "COTIZ_NOMBRECLIENTE", "COTIZ_NOMBRECLIENTE", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsultaVehiculos, index, "Estado", "COTIZ_MONTO", "COTIZ_MONTO", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsultaVehiculos, index, "Ubicacion", "COTIZ_CARGA", "COTIZ_CARGA", 250, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsultaVehiculos, index, "Fec. Ubicacion", "COTIZ_CARGA", "COTIZ_CARGA", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsultaVehiculos, index, "Ref. Orden Trans.", "COTIZ_CARGA", "COTIZ_CARGA", 100, True, False, "System.String", "") : index += 1
            c1grdConsultaVehiculos.AllowEditing = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim fOrdenMantenimiento As New FOrdenMantenimiento()
        fOrdenMantenimiento.StartPosition = FormStartPosition.CenterScreen
        fOrdenMantenimiento.Show()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        'Dim fViaje As New FViajes()
        'fViaje.StartPosition = FormStartPosition.CenterScreen
        'fViaje.Show()
        Dim fFlete As New FFlete()
        fFlete.StartPosition = FormStartPosition.CenterScreen
        fFlete.Show()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
End Class