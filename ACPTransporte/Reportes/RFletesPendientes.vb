Imports ACBTransporte
Imports ACBVentas
Imports ACFramework
Imports C1.Win.C1FlexGrid

Public Class RFletesPendientes
#Region "Variables"
   Private m_btran_fletes As BTRAN_Fletes

   Private bs_tran_fletes As BindingSource
#End Region

#Region "Propiedades"

#End Region

#Region "Contructores"
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Try
         m_btran_fletes = New BTRAN_Fletes

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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdReporte, 1, 1, 13, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cod. Viaje", "VIAJE_Id", "VIAJE_Id", 60, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cod. Flete", "FLETE_Id", "FLETE_Id", 60, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Documento", "Documento", "Documento", 110, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Importe", "FLETE_TotIngreso", "FLETE_TotIngreso", 90, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Pago", "Pago", "Pago", 90, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Pendiente", "Pendiente", "Pendiente", 90, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "T. Pago", "TipoTransaccion", "TipoTransaccion", 120, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "R.U.C.", "ENTID_NroDocumento", "ENTID_NroDocumento", 90, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cliente", "ENTID_RazonSocial", "ENTID_RazonSocial", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Glosa", "FLETE_Glosa", "FLETE_Glosa", 300, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Fec. Salida", "FecLlegada", "FecLlegada", 110, True, False, "System.DateTime", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Fec. Llegada", "FecSalida", "FecSalida", 110, True, False, "System.DateTime", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

         c1grdReporte.AllowEditing = False
         c1grdReporte.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdReporte.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdReporte.Styles.Highlight.BackColor = Color.Gray
         c1grdReporte.SelectionMode = SelectionModeEnum.Row
         c1grdReporte.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdReporte.AutoResize = False
         c1grdReporte.AllowResizing = AllowResizingEnum.Both
         c1grdReporte.Cols("FLETE_Glosa").StyleDisplay.WordWrap = True
         c1grdReporte.Cols("ENTID_RazonSocial").StyleDisplay.WordWrap = True

         Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Facturado")
         t.BackColor = Color.LightGreen
         t.ForeColor = Color.DarkBlue
         t.Font = New Font(c1grdReporte.Font, FontStyle.Regular)

         Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Facturar")
         u.BackColor = Color.Green
         u.ForeColor = Color.White
         u.Font = New Font(c1grdReporte.Font, FontStyle.Regular)

         Dim j As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Pagar")
         j.BackColor = Color.DarkBlue
         j.ForeColor = Color.White
         j.Font = New Font(c1grdReporte.Font, FontStyle.Bold)

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
         'If c1grdReporte.Rows(e.Row)("Pendiente") <> 0 Then
         '   e.Style = c1grdReporte.Styles("Facturado")
         'End If
         If c1grdReporte.Cols(e.Col).Name = "Pendiente" Then
            If c1grdReporte.Rows(e.Row)("Pendiente") <> 0 Then
               e.Style = c1grdReporte.Styles("Anulado")
            End If
         End If

         If c1grdReporte.Cols(e.Col).Name = "FLETE_TotIngreso" Then
            If c1grdReporte.Rows(e.Row)("FLETE_TotIngreso") > 0 Then
               e.Style = c1grdReporte.Styles("Pagar")
            End If
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub AcFecha_ACFecIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecIni_KeyDown
      If e.KeyData = Keys.Enter Then
         AcFecha.ACDtpFecha_A.Focus()
      End If
   End Sub

   Private Sub AcFecha_ACFecFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecFin_KeyDown
      If e.KeyData = Keys.Enter Then
         btnProcesar_Click(Nothing, Nothing)
      End If
   End Sub
#End Region

   Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      bs_tran_fletes = New BindingSource
      Try
         If m_btran_fletes.Reporte_PendienteFletes(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date) Then
            'formatearGrilla()
            bs_tran_fletes.DataSource = m_btran_fletes.ListTRAN_Fletes
            c1grdReporte.DataSource = bs_tran_fletes
            bnavReporte.BindingSource = bs_tran_fletes
            c1grdReporte.AutoSizeRows()
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