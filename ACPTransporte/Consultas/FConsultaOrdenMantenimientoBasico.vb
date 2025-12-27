Public Class FConsultaOrdenMantenimientoBasico

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
    ' <summary>
    ' Dar Formato a la grilla de busqueda
    ' </summary>
    ' <remarks></remarks>
    Private Sub formatearGrilla()
        Dim index As Integer = 1
        Try
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdOrdenesMantenimiento, 1, 1, 5, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdOrdenesMantenimiento, index, "Vehiculo", "COTIZ_Carga", "COTIZ_Carga", 250, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdOrdenesMantenimiento, index, "Fec. Asignacion", "COTIZ_NombreCliente", "COTIZ_NombreCliente", 100, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdOrdenesMantenimiento, index, "Fec. Termino", "COTIZ_Monto", "COTIZ_Monto", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdOrdenesMantenimiento, index, "Estado", "COTIZ_FECHA", "COTIZ_FECHA", 100, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
            c1grdOrdenesMantenimiento.AllowEditing = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub AcToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcToolStripButton1.Click
        Dim fInformeMantenimiento As New FInformeMantenimiento()
        fInformeMantenimiento.StartPosition = FormStartPosition.CenterScreen
        If fInformeMantenimiento.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Ingresar funcionalidad que inserta objeto con datos para los datos del Flete
        End If
    End Sub
End Class