Imports ACBTransporte
Imports ACETransporte
Imports ACEVentas
Imports C1.Win.C1FlexGrid

Imports ACFramework


Public Class RRecibos
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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdReporte, 1, 1, 9, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Viaje", "Recibo", "Recibo", 80, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Estado", "FLETE_Glosa", "FLETE_Glosa", 110, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Descripción Viaje", "VIAJE_Descripcion", "VIAJE_Descripcion", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Importe", "Importe", "Importe", 90, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Documento", "Documento", "Documento", 110, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cod. Viaje", "VIAJE_Id", "VIAJE_Id", 80, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Glosa", "VGAST_Descripcion", "VGAST_Descripcion", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Fecha", "VGAST_Fecha", "VGAST_Fecha", 90, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

         c1grdReporte.AllowEditing = False
         c1grdReporte.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdReporte.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdReporte.Styles.Highlight.BackColor = Color.Gray
         c1grdReporte.SelectionMode = SelectionModeEnum.Row
         c1grdReporte.AutoResize = False
         c1grdReporte.AllowResizing = AllowResizingEnum.Both
         c1grdReporte.Cols("VGAST_Descripcion").StyleDisplay.WordWrap = True
         c1grdReporte.Tree.Column = 1
         c1grdReporte.SubtotalPosition = SubtotalPositionEnum.AboveData

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
         'If c1grdReporte.Rows(e.Row)("Importe") <> 0 Then
         '   e.Style = c1grdReporte.Styles("Facturado")
         'End If
         If c1grdReporte.Cols(e.Col).Name = "Importe" Then
            If c1grdReporte.Rows(e.Row)("Importe") <> 0 And Not IsNothing(c1grdReporte.Rows(e.Row)("FLETE_Glosa")) Then
               e.Style = c1grdReporte.Styles("Anulado")
            End If
         End If

         'If c1grdReporte.Cols(e.Col).Name = "FLETE_TotIngreso" Then
         '   If c1grdReporte.Rows(e.Row)("FLETE_TotIngreso") > 0 Then
         '      e.Style = c1grdReporte.Styles("Pagar")
         '   End If
         'End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub c1grdReporte_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs)
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
         If Not m_badministracioncaja.GenerarRecibos(AcFecha.ACFecha_De.Value.Date, AcFecha.ACFecha_A.Value.Date) Then
            btnExcel.Enabled = False
            m_badministracioncaja.ListTRAN_ViajesGastos = New List(Of ETRAN_ViajesGastos)
         End If

         bs_reporte.DataSource = m_badministracioncaja.ListTRAN_ViajesGastos
         c1grdReporte.DataSource = bs_reporte
         bnavReporte.BindingSource = bs_reporte
         AddHandler bs_reporte.CurrentChanged, AddressOf bs_reporte_CurrentChanged
         bs_reporte_CurrentChanged(Nothing, Nothing)
         c1grdReporte.AutoSizeRows()

         c1grdReporte.Subtotal(AggregateEnum.None, 1, 1, 0, "Viaje: {0}")
         c1grdReporte.Subtotal(AggregateEnum.Sum, 2, 2, 4, "{0}")
         c1grdReporte.AutoSizeCols(1)

         AcPanelCaption1.ACCaption = String.Format("Reporte de Cuadre de Caja: {0:dd/MM/yyyy} Al {1:dd/MM/yyyy}", AcFecha.ACDtpFecha_De.Value, AcFecha.ACDtpFecha_A.Value)

         btnExcel.Enabled = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar el Reporte"), ex)
      End Try
   End Sub



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
         Utilitarios.ExportarXLS(c1grdReporte, "Recibos de Viajes")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso enviar a excel", ex)
      End Try
   End Sub



End Class