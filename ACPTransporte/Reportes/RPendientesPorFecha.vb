Imports ACBTransporte
Imports ACBVentas
Imports ACFramework
Imports C1.Win.C1FlexGrid

Public Class RPendientesPorFecha
#Region "Variables"
   Private m_btran_viajes As BTRAN_Viajes

   Private bs_tran_viajes As BindingSource
#End Region

#Region "Propiedades"

#End Region

#Region "Contructores"
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Try
         m_btran_viajes = New BTRAN_Viajes

         formatearGrilla()

         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACReporte_16x16.GetHicon)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub
#End Region

#Region "Metodos"
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdReporte, 1, 1, 8, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cod. Viaje", "VIAJE_Id", "VIAJE_Id", 120, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Pendiente", "Pendiente", "Pendiente", 120, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "descripción", "VIAJE_Descripcion", "VIAJE_Descripcion", 120, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Conductor", "Conductor", "Conductor", 120, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 120, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Fec. Salida", "VIAJE_FecSalida", "VIAJE_FecSalida", 120, True, False, "System.DateTime", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Fec. Llegada", "VIAJE_FecLlegada", "VIAJE_FecLlegada", 120, True, False, "System.DateTime", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

         c1grdReporte.AllowEditing = False
         c1grdReporte.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdReporte.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdReporte.Styles.Highlight.BackColor = Color.Gray
         c1grdReporte.SelectionMode = SelectionModeEnum.Row
         c1grdReporte.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdReporte.AutoResize = True

         Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Facturado")
         t.BackColor = Color.LightGreen
         t.ForeColor = Color.DarkBlue
         t.Font = New Font(c1grdReporte.Font, FontStyle.Regular)

         Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Facturar")
         u.BackColor = Color.Green
         u.ForeColor = Color.White
         u.Font = New Font(c1grdReporte.Font, FontStyle.Regular)

         Dim d As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Anulado")
         d.BackColor = Color.Red
         d.ForeColor = Color.White
         d.Font = New Font(c1grdReporte.Font, FontStyle.Bold)
         c1grdReporte.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region "Metodos de Controles"
   Private Sub c1grdReporte_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdReporte.OwnerDrawCell
      Try
         If e.Row < c1grdReporte.Rows.Fixed OrElse e.Col < c1grdReporte.Cols.Fixed Then Return
         If c1grdReporte.Rows(e.Row)("Pendiente") <> 0 Then
            e.Style = c1grdReporte.Styles("Facturado")
         End If
         If c1grdReporte.Cols(e.Col).Name = "Pendiente" Then
            If c1grdReporte.Rows(e.Row)("Pendiente") <> 0 Then
               e.Style = c1grdReporte.Styles("Anulado")
            End If
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub
#End Region

   Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      bs_tran_viajes = New BindingSource
      Try
         If m_btran_viajes.Reporte_PendientePorViaje(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date) Then
            bs_tran_viajes.DataSource = m_btran_viajes.ListTRAN_Viajes
            c1grdReporte.DataSource = bs_tran_viajes
            bnavReporte.BindingSource = bs_tran_viajes
            btnExcel.Enabled = True
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error al Procesar Reporte", ex)
      End Try
   End Sub

   Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
      Try
         Utilitarios.ExportarXLS(c1grdReporte, "Fletes Pendientes")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso enviar a excel", ex)
      End Try
   End Sub
End Class