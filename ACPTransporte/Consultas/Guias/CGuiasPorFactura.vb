Imports ACBTransporte
Imports ACETransporte

Imports C1.Win.C1FlexGrid

Public Class CGuiasPorFactura
#Region " Variables "

   Private m_btran_guiastransportista As BTRAN_GuiasTransportista

   Private bs_guias As BindingSource

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         m_btran_guiastransportista = New BTRAN_GuiasTransportista()
         formatearGrilla()

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 2, 2, 20, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Factura", "DocCompra", "DocCompra", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "DOCCO_FechaDocumento", "DOCCO_FechaDocumento", 250, True, False, "System.String", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cant. Comprada", "CanComprada", "CanComprada", 250, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro. SAP", "GTRAN_NroPedido", "GTRAN_NroPedido", 250, True, False, "System.String") : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Guia", "NroGuia", "NroGuia", 250, True, False, "System.String") : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "R.U.C.", "GTRAN_RucProveedor", "GTRAN_RucProveedor", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Razon Social", "ENTID_RazonSocialProveedor", "ENTID_RazonSocialProveedor", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Dirección", "GTRAN_DireccionProveedor", "GTRAN_DireccionProveedor", 250, True, False, "System.String") : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "R.U.C.", "ENTID_CodigoDestinatario", "ENTID_CodigoDestinatario", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Razon Social", "ENTID_RazonSocialDestinatario", "ENTID_RazonSocialDestinatario", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Dirección", "GTRAN_DireccionDestinatario", "GTRAN_DireccionDestinatario", 250, True, False, "System.String") : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "R.U.C.", "ENTID_CodigoTransportista", "ENTID_CodigoTransportista", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Razon Social", "ENTID_RazonSocialTransportista", "ENTID_RazonSocialTransportista", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Cond", "ENTID_CodigoConductor", "ENTID_CodigoConductor", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Conductor", "ENTID_RazonSocialConductor", "ENTID_RazonSocialConductor", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Vehiculo", "GTRAN_DescripcionVehiculo", "GTRAN_DescripcionVehiculo", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Certificados", "GTRAN_CertificadosVehiculo", "GTRAN_CertificadosVehiculo", 250, True, False, "System.String") : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cantidad", "Cantidad", "Cantidad", 250, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Peso", "GTRAN_PesoTotal", "GTRAN_PesoTotal", 250, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo4d)) : index += 1

         For i As Integer = 1 To c1grdBusqueda.Cols.Count - 1
            c1grdBusqueda.Rows(1)(i) = c1grdBusqueda.Rows(0)(i)
         Next

         c1grdBusqueda.Rows(0).AllowMerging = True
         c1grdBusqueda.Rows(0).AllowMerging = True

         Dim rg As CellRange = c1grdBusqueda.GetCellRange(0, c1grdBusqueda.Cols("GTRAN_NroPedido").Index, 0, c1grdBusqueda.Cols("DocCompra").Index)
         rg.Data = "Compra"
         c1grdBusqueda.MergedRanges.Add(rg)

         rg = c1grdBusqueda.GetCellRange(0, c1grdBusqueda.Cols("GTRAN_DireccionProveedor").Index, 0, c1grdBusqueda.Cols("GTRAN_RucProveedor").Index)
         rg.Data = "Proveedor"
         c1grdBusqueda.MergedRanges.Add(rg)

         rg = c1grdBusqueda.GetCellRange(0, c1grdBusqueda.Cols("GTRAN_DireccionDestinatario").Index, 0, c1grdBusqueda.Cols("ENTID_CodigoDestinatario").Index)
         rg.Data = "Destinatario"
         c1grdBusqueda.MergedRanges.Add(rg)

         rg = c1grdBusqueda.GetCellRange(0, c1grdBusqueda.Cols("GTRAN_CertificadosVehiculo").Index, 0, c1grdBusqueda.Cols("ENTID_CodigoTransportista").Index)
         rg.Data = "Transportista"
         c1grdBusqueda.MergedRanges.Add(rg)

         rg = c1grdBusqueda.GetCellRange(0, c1grdBusqueda.Cols("Cantidad").Index, 1, c1grdBusqueda.Cols("Cantidad").Index)
         c1grdBusqueda.MergedRanges.Add(rg)

         rg = c1grdBusqueda.GetCellRange(0, c1grdBusqueda.Cols("GTRAN_PesoTotal").Index, 1, c1grdBusqueda.Cols("GTRAN_PesoTotal").Index)
         c1grdBusqueda.MergedRanges.Add(rg)

         rg = c1grdBusqueda.GetCellRange(0, c1grdBusqueda.Cols("NroGuia").Index, 1, c1grdBusqueda.Cols("NroGuia").Index)
         c1grdBusqueda.MergedRanges.Add(rg)

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdBusqueda.Tree.Column = 1

         Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Facturado")
         t.BackColor = Color.LightGreen
         t.ForeColor = Color.DarkBlue
         t.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

         Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Facturar")
         u.BackColor = Color.Green
         u.ForeColor = Color.White
         u.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

         Dim d As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Anulado")
         d.BackColor = Color.Red
         d.ForeColor = Color.White
         d.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)
         c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         c1grdBusqueda.AutoSizeCols()
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function getOpcion() As Short
      If RadioButton1.Checked Then
         Return 1
      ElseIf RadioButton2.Checked Then
         Return 0
      Else
         Return 1
      End If
   End Function
#End Region

#Region " Metodos de Controles"
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
      Try
         bs_guias = New BindingSource
         If Not m_btran_guiastransportista.TRAN_GUIASS_RepRecCemento(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date, getOpcion) Then
            m_btran_guiastransportista.ListTRAN_GuiasTransportista = New List(Of ETRAN_GuiasTransportista)
         End If
         bs_guias.DataSource = m_btran_guiastransportista.ListTRAN_GuiasTransportista
         c1grdBusqueda.DataSource = bs_guias
         bnavReporte.BindingSource = bs_guias

         c1grdBusqueda.Subtotal(AggregateEnum.Sum, 1, 1, c1grdBusqueda.Cols("Cantidad").Index, "Documento {0}")
         c1grdBusqueda.Subtotal(AggregateEnum.Sum, 1, 1, c1grdBusqueda.Cols("GTRAN_PesoTotal").Index, "Documento {0}")
         c1grdBusqueda.Subtotal(AggregateEnum.Sum, 0, -1, c1grdBusqueda.Cols("Cantidad").Index, "Total")
         c1grdBusqueda.Subtotal(AggregateEnum.Sum, 0, -1, c1grdBusqueda.Cols("GTRAN_PesoTotal").Index, "Total")

         c1grdBusqueda.AutoSizeCols()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Procesar las Guias de Remision"), ex)
      End Try
   End Sub

   Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
      Try
         Utilitarios.ExportarXLS(c1grdBusqueda, "Guias Remision")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Procesar Documento Excel"), ex)
      End Try
   End Sub

   Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
      Try
         Dim _reporte As New Reporte()
         If _reporte.CuadreCaja(AcFecha.ACFecha_De.Value.Date, AcFecha.ACFecha_A.Value.Date, False) Then

         End If
      Catch ex As Exception

      End Try
   End Sub
End Class