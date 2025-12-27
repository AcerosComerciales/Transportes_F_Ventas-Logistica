Public Class FPlanillasConductores

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
            'Deficion de grilla de Busqueda Neumaticos
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdPlanillasConductores, 1, 1, 6, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPlanillasConductores, index, "Conductor", "NEUMA_Codigo", "NEUMA_Codigo", 300, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPlanillasConductores, index, "Cod. Viaje", "TIPOS_CodMarca", "TIPOS_CodMarca", 100, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPlanillasConductores, index, "Banco", "TIPOS_CodTipoLlanta", "TIPOS_CodTipoLlanta", 200, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPlanillasConductores, index, "Importe", "NEUMA_Modelo", "NEUMA_Modelo", 100, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPlanillasConductores, index, "Total", "NEUMA_Modelo", "NEUMA_Modelo", 100, True, False, "System.String", "") : index += 1
            c1grdPlanillasConductores.AllowEditing = False

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region

End Class