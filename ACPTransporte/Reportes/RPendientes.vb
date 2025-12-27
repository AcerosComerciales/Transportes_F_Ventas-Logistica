Imports ACBTransporte
Imports ACETransporte
Imports ACEVentas
Imports C1.Win.C1FlexGrid

Imports ACFramework

Public Class RPendientes
#Region " Variables "
   Private m_badministracioncaja As BAdministracionCaja

   Private bs_reporte As BindingSource
   Private bs_egresos As BindingSource
   Private bs_pendientes As BindingSource
   Private bs_pagos As BindingSource
   Private bs_efectivo As BindingSource
   Private bs_pendientespagados As BindingSource
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
         btnExcel.Enabled = False

         actxnPagado.ReadOnly = True
         actxnPendiente.ReadOnly = True

         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACReporte_16x16.GetHicon)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   ' <summary>
   ' Dar Formato a la grilla de busqueda
   ' </summary>
   ' <remarks></remarks>
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdReporte, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cod. Viaje", "VIAJE_Id", "VIAJE_Id", 80, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cod. Flete", "FLETE_Id", "FLETE_Id", 80, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Documento", "Documento", "Documento", 110, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "R.U.C.", "ENTID_NroDocumento", "ENTID_NroDocumento", 90, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cliente", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Glosa", "FLETE_Glosa", "FLETE_Glosa", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Fec. Salida", "FLETE_FecSalida", "FLETE_FecSalida", 80, True, False, "System.DateTime", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         'ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Fec. Llegada", "FecSalida", "FecSalida", 80, True, False, "System.DateTime", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Importe", "FLETE_TotIngreso", "FLETE_TotIngreso", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Pago", "Pago", "Pago", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Pendiente", "Pendiente", "Pendiente", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         c1grdReporte.AllowEditing = False
         c1grdReporte.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdReporte.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdReporte.Styles.Highlight.BackColor = Color.Gray
         c1grdReporte.SelectionMode = SelectionModeEnum.Row
         c1grdReporte.AutoResize = False
         c1grdReporte.AllowResizing = AllowResizingEnum.Both
         c1grdReporte.Cols("FLETE_Glosa").StyleDisplay.WordWrap = True
         c1grdReporte.Cols("ENTID_RazonSocial").StyleDisplay.WordWrap = True
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

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private m_order As Integer = 1
   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of ETRAN_Fletes)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_reporte.DataSource, List(Of ETRAN_Fletes)).Sort(_ordenador)
         c1grdReporte.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
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

   Private Sub c1grdReporte_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdReporte.BeforeSort
      Try
         Ordenar(c1grdReporte.Cols(e.Col).UserData)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub
#End Region

   Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      bs_reporte = New BindingSource
      bs_egresos = New BindingSource
      bs_pendientes = New BindingSource
      Try
         'formatearGrilla()
         btnExcel.Enabled = True
         Dim _reporte As New ETRAN_Fletes
         If Not m_badministracioncaja.Pendientes(AcFecha.ACFecha_De.Value.Date, AcFecha.ACFecha_A.Value.Date) Then
            actxnPagado.Text = "0.00"
            actxnPendiente.Text = "0.00"
            m_badministracioncaja.ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            btnExcel.Enabled = False
         End If

         bs_reporte.DataSource = m_badministracioncaja.ListTRAN_Fletes
         c1grdReporte.DataSource = bs_reporte
         bnavReporte.BindingSource = bs_reporte
         AddHandler bs_reporte.CurrentChanged, AddressOf bs_reporte_CurrentChanged
         bs_reporte_CurrentChanged(Nothing, Nothing)
         actxnPendiente.Text = CalcularSaldo()
         c1grdReporte.AutoSizeRows()
         actxnPendiente.Formatear()

         c1grdReporte.Subtotal(AggregateEnum.Sum, 0, -1, 9, "Total")
         c1grdReporte.Subtotal(AggregateEnum.Sum, 0, -1, 8, "Total")
         c1grdReporte.Subtotal(AggregateEnum.Sum, 0, -1, 10, "Total")

         AcPanelCaption1.ACCaption = String.Format("Reporte de Cuadre de Caja: {0:dd/MM/yyyy} Al {1:dd/MM/yyyy}", AcFecha.ACDtpFecha_De.Value, AcFecha.ACDtpFecha_A.Value)

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar el Reporte"), ex)
      End Try
   End Sub

   Private Function CalcularSaldo() As Decimal
      Try
         Dim _saldo As Decimal = 0
         Dim _pagado As Decimal = 0
         For Each item As ETRAN_Fletes In m_badministracioncaja.ListTRAN_Fletes
            _saldo += item.Pendiente
            _pagado += item.Pago
         Next
         actxnPagado.Text = _pagado : actxnPagado.Formatear()

         Return _saldo
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   Private Sub bs_reporte_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      bs_pagos = New BindingSource
      Try
         If Not IsNothing(bs_reporte.Current) Then
            'If Not m_badministracioncaja.CuadreCajaPagos(CType(bs_reporte.Current, ETRAN_Fletes).FLETE_Id) Then
            '   m_badministracioncaja.ListTESO_CajaPagos = New List(Of ETESO_Caja)
            'End If
            'bs_pagos.DataSource = m_badministracioncaja.ListTESO_CajaPagos
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
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

   Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
      Try
         Utilitarios.ExportarXLS(c1grdReporte, "Pendientes")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso enviar a excel", ex)
      End Try
   End Sub
End Class