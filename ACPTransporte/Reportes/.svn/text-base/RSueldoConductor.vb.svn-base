Imports ACBTransporte
Imports ACETransporte
Imports ACEVentas
Imports C1.Win.C1FlexGrid

Imports ACFramework

Public Class RSueldoConductor
#Region " Variables "
   Private m_badministracioncaja As BAdministracionCaja
   Private managerAdministracionViajes As BAdministracionViajes

   Private bs_reporte As BindingSource
   Private bs_tran_fletes As BindingSource
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         formatearGrilla()
         m_badministracioncaja = New BAdministracionCaja(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta)
         managerAdministracionViajes = New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
         btnExcel.Enabled = False

         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACReporte_16x16.GetHicon)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdReporte, 1, 1, 12, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Conductor", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cod. Viaje", "VIAJE_Id", "VIAJE_Id", 80, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "R.U.C.", "ENTID_NroDocumento", "ENTID_NroDocumento", 90, True, False, "System.String") : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Viaje", "VIAJE_IdxConductor", "VIAJE_IdxConductor", 250, True, False, "System.Decimal") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Sigla", "CONDU_Sigla", "CONDU_Sigla", 250, True, False, "System.String") : index += 1
         
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Pago", "VIAJE_PagoConductor", "VIAJE_PagoConductor", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Saldo", "VIAJE_SaldoConductor", "VIAJE_SaldoConductor", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Pendiente", "Pendiente", "Pendiente", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Salida", "VIAJE_FecSalida", "VIAJE_FecSalida", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Llegada", "VIAJE_FecLlegada", "VIAJE_FecLlegada", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Descripción", "VIAJE_Descripcion", "VIAJE_Descripcion", 150, True, False, "System.String") : index += 1


         c1grdReporte.AllowEditing = False
         c1grdReporte.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdReporte.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdReporte.Styles.Highlight.BackColor = Color.Gray
         c1grdReporte.SelectionMode = SelectionModeEnum.Row
         c1grdReporte.AutoResize = True
         c1grdReporte.AllowResizing = AllowResizingEnum.Both
         'c1grdReporte.Cols("ENTID_RazonSocial").StyleDisplay.WordWrap = True
         c1grdReporte.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdReporte.Tree.Column = 1

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

         Dim s As CellStyle = c1grdReporte.Styles(CellStyleEnum.Subtotal0)
         s.BackColor = Color.Black
         s.ForeColor = Color.White
         s.Font = New Font(c1grdReporte.Font, FontStyle.Bold)

         s = c1grdReporte.Styles(CellStyleEnum.Subtotal1)
         s.BackColor = Color.DarkBlue
         s.ForeColor = Color.White
         s = c1grdReporte.Styles(CellStyleEnum.Subtotal2)
         s.BackColor = Color.DarkRed
         s.ForeColor = Color.White

         formatearGrilla_Fletes()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      bs_reporte = New BindingSource
      Try
         'formatearGrilla()
         btnExcel.Enabled = True
         Dim _reporte As New ETRAN_Fletes
         btnExcel.Enabled = True
         If Not m_badministracioncaja.SueldoConductor(AcFecha.ACFecha_De.Value.Date, AcFecha.ACFecha_A.Value.Date) Then
            m_badministracioncaja.ListTRAN_ViajesConductor = New List(Of ETRAN_Viajes)
            btnExcel.Enabled = False
         End If

         bs_reporte.DataSource = m_badministracioncaja.ListTRAN_ViajesConductor
         c1grdReporte.DataSource = bs_reporte
         bnavReporte.BindingSource = bs_reporte

         AddHandler bs_reporte.CurrentChanged, AddressOf bs_reporte_CurrentChanged
         bs_reporte_CurrentChanged(Nothing, Nothing)
         
         'c1grdReporte.AutoSizeRows()

         c1grdReporte.Subtotal(AggregateEnum.Sum, 1, 1, 8, "Viaje de: {0}")
         c1grdReporte.Subtotal(AggregateEnum.Sum, 1, 1, 7, "Viaje de: {0}")
         c1grdReporte.Subtotal(AggregateEnum.Sum, 1, 1, 6, "Viaje de: {0}")
         c1grdReporte.Subtotal(AggregateEnum.Count, 1, 1, 4, "Total Viajes: {0}")

         c1grdReporte.AutoSizeCols()


      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar el Reporte"), ex)
      End Try
   End Sub

   Private Sub bs_reporte_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         cargarFletes(CType(bs_reporte.Current, ETRAN_Viajes).VIAJE_Id)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub
#End Region

   Private Sub cargarFletes(ByVal x_viaje_id As Long)
      Try
         '' Cargar Los fletes asociados
         managerAdministracionViajes.CargarFletes(x_viaje_id)
         bs_tran_fletes = New BindingSource()
         bs_tran_fletes.DataSource = managerAdministracionViajes.ListTRAN_Fletes
         c1grdFletes.DataSource = bs_tran_fletes
         bnavFletes.BindingSource = bs_tran_fletes

         c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 7, "Total")
         c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 10, "Total")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub formatearGrilla_Fletes()
      Try
         Dim index As Integer = 1
         'Definicion de grilla de Fletes
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdFletes, 1, 1, 13, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Código", "FLETE_Id", "FLETE_Id", 250, True, False, "System.String", "000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Ruta", "RUTAS_Nombre", "RUTAS_Nombre", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "R.U.C.", "ENTID_NroDocumento", "ENTID_NroDocumento", 250, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Cliente", "ENTID_Nombres", "ENTID_Nombres", 250, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Fec. Salida", "FLETE_FecSalida", "FLETE_FecSalida", 100, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Fec. LLegada", "FLETE_FecLlegada", "FLETE_FecLlegada", 100, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Peso T.M.", "FLETE_PesoEnTM", "FLETE_PesoEnTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Monto Por TM.", "FLETE_MontoPorTM", "FLETE_MontoPorTM", 250, True, False, "System.Decial", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "I.G.V.", "FLETE_ImporteIgv", "FLETE_ImporteIgv", 250, True, False, "System.Decial", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Ingreso", "FLETE_TotIngreso", "FLETE_TotIngreso", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Pagado", "Pago", "Pago", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Glosa", "FLETE_Glosa", "FLETE_Glosa", 250, True, False, "System.String") : index += 1
         c1grdFletes.AllowEditing = False
         c1grdFletes.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdFletes.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdFletes.Styles.Highlight.BackColor = Color.Gray
         c1grdFletes.SelectionMode = SelectionModeEnum.Row
         c1grdFletes.AutoClipboard = True

         Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdFletes.Styles.Add("Facturado")
         t.BackColor = Color.LightGreen
         t.ForeColor = Color.DarkBlue
         t.Font = New Font(c1grdFletes.Font, FontStyle.Regular)

         Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdFletes.Styles.Add("Facturar")
         u.BackColor = Color.Green
         u.ForeColor = Color.White
         u.Font = New Font(c1grdFletes.Font, FontStyle.Regular)

         Dim d1 As C1.Win.C1FlexGrid.CellStyle = c1grdFletes.Styles.Add("Anulado")
         d1.BackColor = Color.Red
         d1.ForeColor = Color.White
         d1.Font = New Font(c1grdFletes.Font, FontStyle.Bold)

         Dim j1 As C1.Win.C1FlexGrid.CellStyle = c1grdFletes.Styles.Add("Pagar")
         j1.BackColor = Color.DarkBlue
         j1.ForeColor = Color.White
         j1.Font = New Font(c1grdFletes.Font, FontStyle.Bold)

         Dim s As CellStyle = c1grdFletes.Styles(CellStyleEnum.Subtotal0)
         s.BackColor = Color.Black
         s.ForeColor = Color.White
         s.Font = New Font(c1grdFletes.Font, FontStyle.Bold)

         s = c1grdFletes.Styles(CellStyleEnum.Subtotal1)
         s.BackColor = Color.DarkBlue
         s.ForeColor = Color.White
         s = c1grdFletes.Styles(CellStyleEnum.Subtotal2)
         s.BackColor = Color.DarkRed
         s.ForeColor = Color.White

         c1grdFletes.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
      Try
         Utilitarios.ExportarXLS(c1grdReporte, "Reporte de Sueldos")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso enviar a excel", ex)
      End Try
   End Sub

End Class