Imports ACBVentas
Imports ACEVentas
Imports ACFramework
Imports System.Text
Imports C1.Win.C1FlexGrid
Imports ACSeguridad

Public Class TNotasCredito
#Region " Variables "
    Private managerGenerarDocsVenta As BGenerarDocsVenta

    Dim managerbadministracioncaja As BAdminCaja
   Private managerEntidades As BEntidades

   Private m_earticulos As EArticulos
    Private m_eentidades As EEntidades
    Private m_estado As String '_M

   Private bs_etran_docsventadetalle As BindingSource
   Private bs_series As BindingSource
   Private bs_documentos As BindingSource
   Private bs_tdoc As BindingSource
   Private bs_tdocbus As BindingSource
   Private bs_moneda As BindingSource
   Private bs_docsventarelacionados As BindingSource
   Private bs_detdocumentoventa As BindingSource
   Private bs_motivonotacredito As BindingSource

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_listvent_pventdocumento As List(Of EVENT_PVentDocumento)
   Private m_modArticulo As Boolean = False
   Private m_elifacturas As Boolean = False

   Private frmCons As CProductos
    'Private m_frmcventas As New CVentas
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_icono As System.Drawing.Bitmap)
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         tabRelacionados.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabRelacionados.SelectedTab = tpgVarias

         managerGenerarDocsVenta = New BGenerarDocsVenta(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
         managerEntidades = New BEntidades

         cargarCombos()
         formatearGrilla()

         acTool.ACBtnSalirVisible = True

         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
         Me.Text = String.Format(Me.Text, "Nota de Crédito")
         ACPanel.ACCaption = Me.Text

         If Not IsNothing(x_icono) Then
            Me.Icon = Icon.FromHandle(x_icono.GetHicon)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub cargarCombos()
      Try
         '' Moneda
         bs_moneda = New BindingSource() : bs_moneda.DataSource = Colecciones.Tipos(ETipos.MyTipos.TipoMoneda)
         AddHandler bs_moneda.CurrentChanged, AddressOf bs_monedas_CurrentChanged
         ACUtilitarios.ACCargaCombo(cmbMoneda, bs_moneda, "TIPOS_DescCorta", "TIPOS_Codigo")

         '' Documento de Venta 
         Dim listDoc As New List(Of ETipos)
         Dim listDocBus As New List(Of ETipos)
         For Each Item As ETipos In Colecciones.TiposDocNotasCredito()
            listDoc.Add(Item.Clone)
            listDocBus.Add(Item.Clone)
         Next
         bs_tdoc = New BindingSource() : bs_tdoc.DataSource = listDoc : AddHandler bs_tdoc.CurrentChanged, AddressOf bs_tdoc_CurrentChanged
         bs_tdocbus = New BindingSource() : bs_tdocbus.DataSource = listDocBus : AddHandler bs_tdocbus.CurrentChanged, AddressOf bs_tdocbus_CurrentChanged
         bs_tdoc_CurrentChanged(Nothing, Nothing)
         bs_tdocbus_CurrentChanged(Nothing, Nothing)

         ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumentoFacturar, bs_tdoc, "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoDocumento, bs_tdocbus, "TIPOS_Descripcion", "TIPOS_Codigo")

         bs_motivonotacredito = New BindingSource
         bs_motivonotacredito.DataSource = Colecciones.TiposMotivoNotaCredito
         ACFramework.ACUtilitarios.ACCargaCombo(cmbMotivo, bs_motivonotacredito, "TIPOS_Descripcion", "TIPOS_Codigo")
         AddHandler bs_motivonotacredito.CurrentChanged, AddressOf bs_motivonotacredito_CurrentChanged
         bs_motivonotacredito_CurrentChanged(Nothing, Nothing)

         bs_docsventarelacionados = New BindingSource
         bs_docsventarelacionados.DataSource = Colecciones.TiposDocComprobante
         ACFramework.ACUtilitarios.ACCargaCombo(cmbRefDocumento, bs_docsventarelacionados, "TIPOS_Descripcion", "TIPOS_Codigo")
         Dim _series As New BVENT_PVentDocumento
         If _series.CargarTodos() Then
            m_listvent_pventdocumento = _series.ListVENT_PVentDocumento
         End If
         AddHandler bs_docsventarelacionados.CurrentChanged, AddressOf bs_docsventarelacionados_CurrentChanged
         bs_docsventarelacionados_CurrentChanged(Nothing, Nothing)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_docsventarelacionados_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_docsventarelacionados.Current) Then
            Dim _filter As New ACFiltrador(Of EVENT_PVentDocumento)(String.Format("TIPOS_CodTipoDocumento={0}", CType(bs_docsventarelacionados.Current, ETipos).TIPOS_Codigo))
            _filter.ACFiltrar(m_listvent_pventdocumento)
            ACFramework.ACUtilitarios.ACCargaCombo(cmbRefSerie, _filter.ACListaFiltrada, "PVDOCU_Serie", "PVDOCU_Serie")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub bs_motivonotacredito_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_motivonotacredito.Current) Then
            If CType(bs_motivonotacredito.Current, ETipos).TIPOS_Codigo = ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.Devoluciones) Then
               tabRelacionados.SelectedTab = tpgUnico
               If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta) Then
                  If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta) Then
                     managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta.Clear()
                  End If
               End If
            Else
               tabRelacionados.SelectedTab = tpgVarias
            End If
            If Not IsNothing(bs_docsventarelacionados) Then bs_docsventarelacionados.ResetBindings(False)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 13, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cotizador", "Usuario", "Usuario", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Cliente", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cliente", "ENTID_Cliente", "ENTID_Cliente", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Total Pagar", "DOCVE_TotalPagar", "DOCVE_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Condición", "TIPOS_CondicionPago", "TIPOS_CondicionPago", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCVE_Estado", "DOCVE_Estado", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCVE_Estado_Text", "DOCVE_Estado_Text", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Vendedor", "ENTID_Vendedor", "ENTID_Vendedor", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Facturar", "PEDID_ParaFacturar", "PEDID_ParaFacturar", 150, False, False, "System.Boolean") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.AutoResize = True
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         'c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn

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

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 8, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Codigo", "ARTIC_Codigo", "ARTIC_Codigo", 110, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Detalle", "ARTIC_Descripcion", "ARTIC_Descripcion", 160, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Unidad", "DOCVD_Unidad", "DOCVD_Unidad", 160, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Cantidad", "DOCVD_Cantidad", "DOCVD_Cantidad", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Precio", "DOCVD_PrecioUnitario", "DOCVD_PrecioUnitario", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Precio", "DOCVD_PrecioUnitarioPrecIncIGV", "DOCVD_PrecioUnitarioPrecIncIGV", 110, False, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Sub-Importe", "DOCVD_SubImporteVenta", "DOCVD_SubImporteVenta", 100, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         c1grdDetalle.AllowEditing = False
         c1grdDetalle.AutoResize = True
         c1grdDetalle.Cols(0).Width = 18
         c1grdDetalle.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDetalle.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDetalle.Styles.Highlight.BackColor = Color.Gray
         c1grdDetalle.SelectionMode = SelectionModeEnum.Row
         c1grdDetalle.AllowResizing = AllowResizingEnum.Rows
         'c1grdDetalle.VisualStyle = VisualStyle.Office2007Blue

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdFacturas, 1, 1, 6, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Fecha", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Doc. Cliente", "ENTID_CodigoCliente", "ENTID_CodigoCliente", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Cliente", "DOCVE_DescripcionCliente", "DOCVE_DescripcionCliente", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Total Pagar", "DOCVE_TotalPagar", "DOCVE_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         c1grdFacturas.AllowEditing = False
         c1grdFacturas.AutoResize = True
         c1grdFacturas.Cols(0).Width = 18
         c1grdFacturas.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdFacturas.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdFacturas.Styles.Highlight.BackColor = Color.Gray
         c1grdFacturas.SelectionMode = SelectionModeEnum.Row
         c1grdFacturas.AllowResizing = AllowResizingEnum.Rows
         c1grdFacturas.AllowAddNew = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
      Try
         acTool.ACBtnRehusarVisible = False
         acTool.ACBtnImprimirVisible = False
         acTool.ACBtnAnularVisible = False
         acTool.ACBtnAnular.Visible = False

         RemoveHandler c1grdDetalle.KeyDown, AddressOf c1grdDetalle_KeyDown

         Select Case _opcion
            Case ACUtilitarios.ACSetInstancia.Nuevo
               ACUtilitarios.ACSetControl(pnlCuerpo, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
               tabMantenimiento.SelectedTab = tabDatos
               ACUtilitarios.ACLimpiaVar(pnlItem)
               ACUtilitarios.ACLimpiaVar(pnlCabecera)
               ACUtilitarios.ACLimpiaVar(pnlCuerpo)
               ACUtilitarios.ACLimpiaVar(pnlPie)
               chkIlncluidoIGV.Enabled = False
               SetControles(True)
               actsbtnPrevisualizar.Visible = False
               acTool.ACBtnImprimirVisible = False
               acTool.ACBtnAnularVisible = False
               acTool.ACBtnImprimirEnabled = False
               acTool.ACBtnEliminarVisible = False
               pnlItem.Enabled = True
               setEtiqueta(ETipos.TipoMoneda.Soles)
               pnlPie.Enabled = True
               actxaNroDocumento.Clear()
               lblFecha.Text = ""
               cmbSerie.Enabled = True
               actxnNumero.Enabled = True
               AddHandler c1grdDetalle.KeyDown, AddressOf c1grdDetalle_KeyDown
               cmbMotivo.SelectedIndex = 0
               tabRelacionados.SelectedTab = tpgVarias
               cmbRefDocumento.Enabled = True
               cmbRefSerie.Enabled = True
               actxaNroDocumento.Enabled = True
               dtpFecTramite.Enabled = True

            Case ACUtilitarios.ACSetInstancia.Modificado

            Case ACUtilitarios.ACSetInstancia.Guardar
               txtBusqueda.Focus()
            Case ACUtilitarios.ACSetInstancia.Deshacer
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               acTool.ACBtnBuscarVisible = False
               actsbtnPrevisualizar.Visible = True
               acTool.ACBtnImprimirVisible = False
               tabMantenimiento.SelectedTab = tabBusqueda
               acTool.ACBtnImprimirEnabled = True
               pnlPie.Enabled = False
               pnlItem.Enabled = False
               acTool.ACBtnAnularVisible = False

            Case ACUtilitarios.ACSetInstancia.Previsualizar
               ACUtilitarios.ACSetControl(pnlCuerpo, True, ACUtilitarios.TipoPropiedad.ACReadOnly)
               actxaCliRazonSocial.ACAyuda.Enabled = False
               actxaCliRazonSocial.ACActivarAyuda = False
               acTool.ACBtnImprimirVisible = True
               actxaCliRuc.ACAyuda.Enabled = False
               actxaCliRuc.ACActivarAyuda = False
               pnlPie.Enabled = False
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               acTool.ACBtnGrabarVisible = False
               actsbtnPrevisualizar.Visible = False
               SetControles(False)
               pnlItem.Enabled = False
               acTool.ACBtnImprimirVisible = True
               chkIlncluidoIGV.Enabled = False
               acTool.ACBtnAnularVisible = True
               cmbSerie.Enabled = False
               actxnNumero.Enabled = False
               cmbRefDocumento.Enabled = False
               cmbRefSerie.Enabled = False
               actxaNroDocumento.Enabled = False
               dtpFecTramite.Enabled = False
         End Select
         acTool.ACBtnModificarVisible = False
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub SetControles(ByVal x_opcion As Boolean)
      cmbDocumentoFacturar.Enabled = x_opcion

      actxaCliRazonSocial.ACActivarAyuda = x_opcion : actxaCliRazonSocial.ACAyuda.Enabled = x_opcion
      actxaCliRuc.ACActivarAyuda = x_opcion : actxaCliRuc.ACAyuda.Enabled = x_opcion

      dtpFecFacturacion.Enabled = x_opcion

      pnlItem.Enabled = x_opcion

      btnNuevoCliente.Enabled = x_opcion : btnClean.Enabled = x_opcion
   End Sub

   Private Sub setProducto(ByVal x_opcion As Boolean)
      Try
         'RemoveHandler actxnProdCantidad.LostFocus, AddressOf actxnProdCantidad_LostFocus
         If x_opcion Then
            actxaProdCodigo.Text = m_earticulos.ARTIC_Codigo
            txtProdDescripcion.Text = m_earticulos.ARTIC_Descripcion
            Dim _tipocambio As Double = actxnTipoCambio.Text
            actxnPrecio.Text = m_earticulos.ListPPrecios(0).PrecioCalculado.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
            txtProdDescripcion.Focus()
            txtProdUnidad.Text = m_earticulos.TIPOS_UnidadMedida
            'AddHandler actxnProdCantidad.LostFocus, AddressOf actxnProdCantidad_LostFocus
         Else
            actxaProdCodigo.Clear()
            txtProdDescripcion.Clear()
            actxnProdCantidad.Text = "0.00"
            actxnSubImporte.Text = "0.00"
            actxnPrecio.Text = "0.00"
            txtProdUnidad.Clear()
            m_earticulos = Nothing
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub actxnProdCantidad_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxnProdCantidad.LostFocus, actxnPrecio.LostFocus
      Try
         Me.KeyPreview = True
         Dim _cantidad As Double
         Try
            _cantidad = CType(actxnProdCantidad.Text, Decimal)
         Catch ex As Exception
            _cantidad = 0
         End Try
         If _cantidad > 0 Then

            Dim _precioUnitario As Double
            Try
               _precioUnitario = actxnPrecio.Text
            Catch ex As Exception
               _precioUnitario = 0
            End Try
            Dim _total As Double = _cantidad * _precioUnitario
            actxnSubImporte.Text = _total
            actxnSubImporte.Formatear()
         Else
            '   actxnProdCantidad.Focus()
            '  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "Es necesario que ingrese una cantidad mayor a 0")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede calcular el Sub-Importe", ex)
      End Try
   End Sub

   Private Sub CambiarMoneda()
      Try
         Dim _tipocambio As Double = actxnTipoCambio.Text
         '' Calcular totales
         If IsNothing(managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Count > 0) Then
            For Each Item As EVENT_DocsVentaDetalle In managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
               If cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                  Item.DOCVD_PrecioUnitario = Item.DOCVD_PrecioUnitario * _tipocambio
                  setEtiqueta(ETipos.TipoMoneda.Soles)
               ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                  Item.DOCVD_PrecioUnitario = Item.DOCVD_PrecioUnitario / _tipocambio
                  setEtiqueta(ETipos.TipoMoneda.Dolares)
               Else
                  Item.DOCVD_PrecioUnitario = Item.DOCVD_PrecioUnitario * _tipocambio
                  setEtiqueta(ETipos.TipoMoneda.Soles)
               End If
            Next
         Else
            If cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
               setEtiqueta(ETipos.TipoMoneda.Soles)
            ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
               setEtiqueta(ETipos.TipoMoneda.Dolares)
            Else
               setEtiqueta(ETipos.TipoMoneda.Soles)
            End If
         End If
         If Not IsNothing(bs_etran_docsventadetalle) Then bs_etran_docsventadetalle.ResetBindings(False)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setEtiqueta(ByVal x_moneda As ETipos.TipoMoneda)
      Try
         Select Case x_moneda
            Case ETipos.TipoMoneda.Soles
               lbligv.Text = String.Format("I.G.V. : {0}", Constantes.Moneda(ETipos.TipoMoneda.Soles))
               lblImporte.Text = String.Format("Importe : {0}", Constantes.Moneda(ETipos.TipoMoneda.Soles))
               lblTotalPagar.Text = String.Format("Total Pagar : {0}", Constantes.Moneda(ETipos.TipoMoneda.Soles))
            Case ETipos.TipoMoneda.Dolares
               lbligv.Text = String.Format("I.G.V. : {0}", Constantes.Moneda(ETipos.TipoMoneda.Dolares))
               lblImporte.Text = String.Format("Importe : {0}", Constantes.Moneda(ETipos.TipoMoneda.Dolares))
               lblTotalPagar.Text = String.Format("Total Pagar : {0}", Constantes.Moneda(ETipos.TipoMoneda.Dolares))
            Case Else
               setEtiqueta(ETipos.TipoMoneda.Soles)
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub calcular(Optional ByVal x_moneda As Boolean = False)
      Try
         If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta) Then
            If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle) Then
               If managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Count > 0 Then
                  Dim _importeTotal As Double = 0
                  Dim _pesoTotal As Decimal = 0
                  Dim _igv As Double = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
                  Dim _totalPagar As Decimal = 0
                  Dim _cantidad As Decimal = 0
                  Dim _tipocambio As Decimal = actxnTipoCambio.Text

                  '' Calcular los precios con percepcion
                  '' Calcular totales
                  For Each Item As EVENT_DocsVentaDetalle In managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                     _importeTotal += Math.Round(Item.DOCVD_PrecioUnitario * Item.DOCVD_Cantidad, 4)
                     _pesoTotal += Item.DOCVD_PesoUnitario * Item.DOCVD_Cantidad
                     _cantidad += Item.DOCVD_Cantidad
                  Next

                  Dim _total As Double = _importeTotal
                  _importeTotal = _importeTotal / ((_igv + 100) / 100)
                  Dim _importeIgv As Double = _total - _importeTotal

                  actxnImporte.Text = -1 * Math.Round(_importeTotal, 2, MidpointRounding.AwayFromZero) : actxnImporte.Formatear()
                  actxnIGV.Text = -1 * _importeIgv : actxnIGV.Formatear()
                  _totalPagar = _total
                  actxnTotalPagar.Text = -1 * _total : actxnTotalPagar.Formatear()

                  tslblSon.Text = String.Format("Son: {0}", ACUtilitarios.NumPalabra(_totalPagar, cmbMoneda.Text))
               End If
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function nueva() As Boolean
      managerGenerarDocsVenta.VENT_DocsVenta = New EVENT_DocsVenta
      Try
         '' Inicializar clase Pedido
         managerGenerarDocsVenta.VENT_DocsVenta.Instanciar(ACEInstancia.Nuevo)
         managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Ingresado)
         '' Instanciar clase
         AsignarBinding()
         setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)
         '' Obtener el tipo de cambio
         managerGenerarDocsVenta.getTipoCambio()
         actxnTipoCambio.Text = managerGenerarDocsVenta.TipoCambio.TIPOC_VentaOficina
         'actxnTCVentaSunat.Text = managerGenerarDocsVenta.TipoCambio.TIPOC_VentaSunat
         '' Para Cargar detalle del producto
         bs_detdocumentoventa = New BindingSource

         managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
         bs_detdocumentoventa.DataSource = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
         c1grdDetalle.DataSource = bs_detdocumentoventa
         bnavProductos.BindingSource = bs_detdocumentoventa

         managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta = New List(Of EVENT_DocsVenta)
         bs_docsventarelacionados = New BindingSource
         bs_docsventarelacionados.DataSource = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta
         c1grdFacturas.DataSource = bs_docsventarelacionados
         bnavRelacionados.BindingSource = bs_docsventarelacionados

         tabMantenimiento.SelectedTab = tabDatos : cmbDocumentoFacturar.Focus()
         cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles)

         cmbDocumentoFacturar.SelectedIndex = 0
         bs_tdoc_CurrentChanged(Nothing, Nothing)
         m_frmcventas = Nothing

         Dim _btipocambio As New BTipoCambio
         If _btipocambio.getUltTipoCambioOficina() Then
            actxnTipoCambio.Text = _btipocambio.TipoCambio.TIPOC_VentaOficina
         End If
         If _btipocambio.getTipoCambioSunat() Then
            actxnTipoCambioSunat.Text = _btipocambio.TipoCambio.TIPOC_VentaSunat
         End If

         Return True
      Catch ex As Exception
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Function

   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbDocumentoFacturar, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodTipoDocumento"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodTipoMoneda"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbMotivo, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodTipoMotivo"))

         m_listBindHelper.Add(ACBindHelper.ACBind(txtMotivo, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Motivo"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Numero"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxnImporte, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_ImporteVenta"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnIGV, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_ImporteIgv"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotalPagar, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TotalPagar"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxaCliRazonSocial, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_DescripcionCliente"))
         'm_listBindHelper.Add(ACBindHelper.ACBind(txtDireccion, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_DireccionCliente"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxnTipoCambio, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TipoCambio"))
         'm_listBindHelper.Add(ACBindHelper.ACBind(actxnTCVentaSunat, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TipoCambioSunat"))

         m_listBindHelper.Add(ACBindHelper.ACBind(chkIlncluidoIGV, "Checked", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_PrecIncIVG"))

         If managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento.Year < 1700 Then managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecFacturacion, "Value", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_FechaDocumento"))

         If managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaTransaccion.Year < 1700 Then managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaTransaccion = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecTramite, "Value", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_FechaTransaccion"))

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function Validar(ByRef m_msg As String, ByRef x_bauditoria As BAuditoria) As Boolean
      Try
         managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.Contado)
         Dim _msg As String = ""
         If Not ACUtilitarios.ACDatosOk(pnlCuerpo, _msg) Or Not ACUtilitarios.ACDatosOk(pnlCabecera, _msg) Then
            m_msg &= _msg
            Return False
         End If
         '' Validar Detalle
         bs_detdocumentoventa.ResetBindings(False)
         ''
         If Not managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Count > 0 Then
            m_msg = String.Format("- NO se ha ingresado items para este documento {0}", vbNewLine)
         End If
         '' Valida que la cantidad y el precio es superior a 0
         For Each Item As EVENT_DocsVentaDetalle In managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
            If Not Item.DOCVD_Cantidad > 0 And Item.DOCVD_PrecioUnitario > 0 Then
               m_msg &= String.Format("- El Producto tiene como cantidad {0} y el precio {1}, no es aceptable", Item.DOCVD_Cantidad, Item.DOCVD_PrecioUnitario, vbNewLine)
            End If
            Next
            '    'VALIDAR DOCUMENTO CANCELADO _M
            ', _cmbRefDocumento.Text.Substring(0, 1), cmbRefSerie.Text, actxaNroDocumento.Text,lblFecha.Tag.ToString())
            'Dim _codigo As String = CType(bs_docsventarelacionados.List, EVENT_DocsRelacion).DOCVE_Codigo
            ' Dim _codigo As String = bs_docsventarelacionados.DataSource("DOCVE_Codigo")  'CType(bs_docsventarelacionados.Current, EVENT_DocsRelacion).DOCVE_CodReferencia

            managerbadministracioncaja = New BAdminCaja(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            If Not managerbadministracioncaja.VENT_DOCVESS_CajaPagos(m_estado) Then

            Else
                ' x_saldoafavor = True
                m_msg = String.Format(" - El Documento esta cancelado - Quitar el Pago", vbNewLine)
                End If
         '' Verificar si hay pedidos
         Return Not (m_msg.Length > 0)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function addDetallePedido() As Boolean
      Try
         If Not IsNothing(m_earticulos) Then
            Dim _detPedido As New EVENT_DocsVentaDetalle
            _detPedido.ARTIC_Codigo = m_earticulos.ARTIC_Codigo
            _detPedido.DOCVD_Cantidad = actxnProdCantidad.Text
            _detPedido.DOCVD_PrecioUnitario = actxnPrecio.Text
            _detPedido.DOCVD_CostoUnitario = m_earticulos.PRECI_Precio
            _detPedido.DOCVD_PesoUnitario = m_earticulos.ARTIC_Peso
            _detPedido.DOCVD_SubImporteVenta = -1 * _detPedido.DOCVD_PrecioUnitario * _detPedido.DOCVD_Cantidad
            _detPedido.DOCVD_Unidad = m_earticulos.TIPOS_UnidadMedida
            _detPedido.ARTIC_Descripcion = m_earticulos.ARTIC_Descripcion
            _detPedido.ALMAC_Id = GApp.Almacen
            If _detPedido.DOCVD_PrecioUnitario * _detPedido.DOCVD_Cantidad > 0 Then
               '' Calcular la lista de precios
               For Each Item As EPPrecios In m_earticulos.ListPPrecios
                  If _detPedido.DOCVD_PrecioUnitario >= Math.Round(Item.PrecioCalculado, 2) Then
                     _detPedido.LPREC_Id = Item.LPREC_Id
                  End If
               Next
               '' Actualizar contenido
               managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(_detPedido)
               bs_detdocumentoventa.ResetBindings(False)
               calcular()
               Return True
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede agregar el producto, por la Cantida/Precio es incorrecto, corrija y vuelva a intentarlo ")
               If _detPedido.DOCVD_Cantidad = 0 Then
                  actxnProdCantidad.Focus()
               ElseIf _detPedido.DOCVD_PrecioUnitario = 0 Then
                  actxnPrecio.Focus()
               End If
               Return False
            End If
         Else
            Dim _detPedido As New EVENT_DocsVentaDetalle
            _detPedido.ARTIC_Codigo = Nothing
            _detPedido.DOCVD_Cantidad = actxnProdCantidad.Text
            _detPedido.DOCVD_PrecioUnitario = actxnPrecio.Text
            _detPedido.DOCVD_CostoUnitario = 0
            _detPedido.DOCVD_PesoUnitario = 0
            _detPedido.DOCVD_SubImporteVenta = -1 * _detPedido.DOCVD_PrecioUnitario * _detPedido.DOCVD_Cantidad
            _detPedido.DOCVD_Unidad = " -"
            _detPedido.ARTIC_Descripcion = " - "
            _detPedido.ALMAC_Id = GApp.Almacen
            managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(_detPedido)
            bs_detdocumentoventa.ResetBindings(False)
            calcular()
            Return True
         End If
         c1grdDetalle.AutoSizeCols()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub SetMotivo()
      Try
         Dim _motivo As String = String.Format("Por la devolución del material, correspondiente a la {0}/{1}-{2} del {3}", _
                                               cmbRefDocumento.Text.Substring(0, 1), cmbRefSerie.Text, actxaNroDocumento.Text, _
                                               lblFecha.Tag.ToString())
         txtMotivo.Text = _motivo
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#Region " Binding Source"

   Private Sub bs_tdoc_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_tdoc.Current) Then
            '' Cargar las series
            If managerGenerarDocsVenta.GetSeries(CType(bs_tdoc.Current, ETipos).TIPOS_Codigo) Then
               bs_series = New BindingSource
               bs_series.DataSource = managerGenerarDocsVenta.ListVENT_PVentDocumento
               Dim _default As String = ""
               For Each Item As EVENT_PVentDocumento In managerGenerarDocsVenta.ListVENT_PVentDocumento
                  If Item.PVDOCU_Predeterminado Then
                     _default = Item.PVDOCU_Serie
                     Exit For
                  End If
               Next
               ACFramework.ACUtilitarios.ACCargaCombo(cmbSerie, bs_series, "PVDOCU_Serie", "PVDOCU_Serie", _default)
               AddHandler bs_series.CurrentChanged, AddressOf bs_series_CurrentChanged
               bs_series_CurrentChanged(Nothing, Nothing)
               dtpFecFacturacion.Value = DateTime.Now
               cmbSerie.Enabled = True
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar las series, posiblemente no tenga series asignadas")
               cmbSerie.Enabled = False
               cmbSerie.SelectedIndex = -1
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub bs_tdocbus_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_tdocbus.Current) Then
            '' Cargar las series
            If managerGenerarDocsVenta.GetSeries(CType(bs_tdocbus.Current, ETipos).TIPOS_Codigo) Then
               ACFramework.ACUtilitarios.ACCargaCombo(ComboBox2, managerGenerarDocsVenta.ListVENT_PVentDocumento, "PVDOCU_Serie", "PVDOCU_Serie")
               ComboBox2.Enabled = True
            Else
               ComboBox2.SelectedIndex = -1
               ComboBox2.Enabled = False
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub bs_series_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_series.Current) Then
            Dim x_numero As Integer = managerGenerarDocsVenta.getNumero(CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_Serie, CType(bs_tdoc.Current, ETipos).TIPOS_Codigo)
            actxnNumero.Text = (x_numero + 1).ToString()
            If Not IsNothing(CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_DispositivoImpresion) Then
               tscmbImpresora.Text = CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_DispositivoImpresion
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub bs_monedas_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         setProducto(False)
         CambiarMoneda()
         calcular()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub bs_docsventa_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_documentos.Current) Then
            If CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado) Then
               acTool.ACBtnAnular.Enabled = False
               actsbtnModFecha.Enabled = True
               actsbtnModFecha.Visible = True
            Else
               acTool.ACBtnAnular.Enabled = True
               actsbtnModFecha.Enabled = False
               actsbtnModFecha.Visible = False
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub


#End Region

   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busquedaCliente(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de clientes", ex)
      End Try
   End Sub

   Private Function busquedaCliente(ByVal x_cadena As String) As Boolean
      Try
         Dim m_return As Boolean
         'If txtBusqueda.ACEstadoAutoAyuda Then
         Dim _in As String = String.Format("'{0}'", ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.NotaCredito))
         If managerGenerarDocsVenta.getCliente(x_cadena, "ENTID_Nombres", chkTodos.Checked, True, _
                                             AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date.AddDays(1), GApp.PuntoVenta, _in) Then
            cargarDatos(True)
         Else
            cargarDatos(False)
         End If
         'End If
         Return m_return
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Function busquedaDocumentos(ByVal x_cadena As String) As Boolean
      Try
         Dim m_return As Boolean
         'If txtBusqueda.ACEstadoAutoAyuda Then
         If managerGenerarDocsVenta.getDocumentos(ComboBox2.SelectedValue, IIf(txtBusNumero.Text.Equals(""), "0", txtBusNumero.Text), chkTodos.Checked, cmbDocumentoFacturar.SelectedValue) Then
            cargarDatos(True)
         Else
            cargarDatos(False)
         End If
         'End If
         Return m_return
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Sub cargarDatos(ByVal x_opcion As Boolean)
      Try
         bs_documentos = New BindingSource()
         If x_opcion Then
            bs_documentos.DataSource = managerGenerarDocsVenta.ListVENT_DocsVenta
         Else
            managerGenerarDocsVenta.ListVENT_DocsVenta = New List(Of EVENT_DocsVenta)
            bs_documentos.DataSource = managerGenerarDocsVenta.ListVENT_DocsVenta
         End If
         c1grdBusqueda.DataSource = bs_documentos
         bnavBusqueda.BindingSource = bs_documentos
         AddHandler bs_documentos.CurrentChanged, AddressOf bs_docsventa_CurrentChanged
         bs_docsventa_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setCliente()
      '' Cargar datos adicionales cliente
      If actxaCliRuc.ACAyuda.Enabled = True Then
         If managerEntidades.CargarDocIden(actxaCliRuc.Text, EEntidades.TipoInicializacion.Cliente) Then
            '' Cargar datos del cliente
            managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoCliente = managerEntidades.Entidades.ENTID_Codigo
            m_eentidades = managerEntidades.Entidades

            Dim x_direcciones As New EDirecciones
            x_direcciones.DIREC_Id = 0
            x_direcciones.Direccion = managerEntidades.Entidades.Direccion
            x_direcciones.UBIGO_Codigo = managerEntidades.Entidades.UBIGO_Codigo
            If IsNothing(managerEntidades.Entidades.ListDirecciones) Then managerEntidades.Entidades.ListDirecciones = New List(Of EDirecciones)()
            managerEntidades.Entidades.ListDirecciones.Insert(0, x_direcciones)

            ACFramework.ACUtilitarios.ACCargaCombo(cmbDirecciones, managerEntidades.Entidades.ListDirecciones, "Direccion", "DIREC_Id")
            If managerEntidades.Entidades.ListDirecciones.Count > 0 Then
               cmbDirecciones.SelectedValue = managerEntidades.Entidades.ListDirecciones(0).DIREC_Id
            End If
            pnlItem.Enabled = True


            actxaCliRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
            actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
            cmbDirecciones.Text = managerEntidades.Entidades.ENTID_Direccion
            pnlItem.Enabled = True
            calcular()
            lblMoneda.Focus()
         Else
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                            , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaCliRuc.Text) _
                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
               NuevoCliente(actxaCliRuc.Text)
               lblMoneda.Focus()
            Else
               btnClean_Click(Nothing, Nothing)
               lblNroDocumento.Focus()
            End If
         End If
      End If
   End Sub

   Private Sub NuevoCliente(ByVal x_entid_nrodocumento As String)
      Try
         Dim frmEntidad As New MEntidad(MEntidad.Inicio.NuevaEntidad, ACEVentas.EEntidades.TipoEntidad.Clientes)
         frmEntidad.StartPosition = FormStartPosition.CenterScreen
         If x_entid_nrodocumento.Length > 0 Then
            frmEntidad.EEntidad.ENTID_NroDocumento = x_entid_nrodocumento
            frmEntidad.lblNombres.Focus()
         End If
         If frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_eentidades = frmEntidad.EEntidad
            managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoCliente = m_eentidades.ENTID_Codigo

            Dim l_Tipos As New List(Of ETipos)(Colecciones.GetTipos(m_eentidades.Cliente.TIPOS_CodTipoPercepcion))
            Dim pPercepcion As Double
            If l_Tipos.Count > 0 Then
               pPercepcion = l_Tipos(0).TIPOS_Numero
            End If
            m_eentidades.Cliente.Percepcion = pPercepcion
            managerEntidades.Entidades = m_eentidades
            managerEntidades.Cliente = m_eentidades.Cliente
            actxaCliRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
            actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
            cmbDirecciones.Text = managerEntidades.Entidades.ENTID_Direccion

            pnlItem.Enabled = True
            calcular()
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As Short, ByVal x_descripcion As String, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         Dim _campos() As ACCampos = {New ACCampos("@Opcion", x_campo), _
                                      New ACCampos("@Cadena", x_cadenas), _
                                      New ACCampos("@ROLES_Id", x_opcion.GetHashCode.ToString())}
         Dim _busqueda As New ACCampos("@Cadena", x_descripcion)

         'Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerEntidades.DTEntidades, False)
         Dim Ayuda As New ACControlesC1.ACAyudaTextFlex("Buscar Entidad", "ENTISS_TodosAyuda", _campos, _busqueda, False)
         If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Select Case x_opcion
               Case EEntidades.TipoEntidad.Clientes
                  '' Cargar datos del cliente
                  managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoCliente = Ayuda.Respuesta.Rows(0)("Codigo")
                  managerGenerarDocsVenta.VENT_DocsVenta.ENTID_Codigo = Ayuda.Respuesta.Rows(0)("Codigo").ToString()
                  actxaCliRazonSocial.Text = Ayuda.Respuesta.Rows(0)("Razon Social").ToString()
                  actxaCliRuc.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.").ToString()
                  cmbDirecciones.Text = Ayuda.Respuesta.Rows(0)("Dirección").ToString()
                  setCliente()
               Case EEntidades.TipoEntidad.Vendedores
                  Dim x_entid_codigo As String = Ayuda.Respuesta.Rows(0)("Codigo")
            End Select
         End If
         'Else
         'ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede mostrar la ayuda, posiblemente no haya datos que mostrar")
         'End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function cargar(ByVal x_codigo As String) As Boolean
      Try
         If managerGenerarDocsVenta.CargarSinArticulos(x_codigo, True) Then
            '' Setear Valores
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Previsualizar)
            '' Cargar
            AsignarBinding()
            bs_detdocumentoventa = New BindingSource()
            bs_detdocumentoventa.DataSource = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
            c1grdDetalle.DataSource = bs_detdocumentoventa
            bnavProductos.BindingSource = bs_detdocumentoventa
            tabMantenimiento.SelectedTab = tabDatos
            actxaCliRuc.Text = managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoCliente
            '' Cargar Cliente
            If managerEntidades.Cargar(managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoCliente, EEntidades.TipoInicializacion.Direcciones) Then
               Dim x_direcciones As New EDirecciones
               x_direcciones.DIREC_Id = 0
               x_direcciones.DIREC_Direccion = managerEntidades.Entidades.ENTID_Direccion
               x_direcciones.UBIGO_Codigo = managerEntidades.Entidades.UBIGO_Codigo
               If IsNothing(managerEntidades.Entidades.ListDirecciones) Then managerEntidades.Entidades.ListDirecciones = New List(Of EDirecciones)()
               managerEntidades.Entidades.ListDirecciones.Insert(0, x_direcciones)

               ACFramework.ACUtilitarios.ACCargaCombo(cmbDirecciones, managerEntidades.Entidades.ListDirecciones, "DIREC_Direccion", "DIREC_Id")
               If managerEntidades.Entidades.ListDirecciones.Count > 0 Then
                  cmbDirecciones.Text = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente
               End If
            End If
            txtDireccion.Text = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente
            cmbDirecciones.SelectedText = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente
            cmbDocumentoFacturar.SelectedValue = managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento
            cmbSerie.SelectedValue = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie
            actxnNumero.Text = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Numero
            '' Cargar Facturas Relacionadas
            If managerGenerarDocsVenta.DocumentosRelacionados(x_codigo) Then
               If managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoMotivo = ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.Devoluciones) Then
                  cmbRefDocumento.SelectedValue = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta(0).TIPOS_CodTipoDocumento
                  cmbRefSerie.SelectedValue = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta(0).DOCVE_Serie
                  actxaNroDocumento.Text = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta(0).DOCVE_Numero
               Else
                  bs_docsventarelacionados = New BindingSource
                  bs_docsventarelacionados.DataSource = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta
                  c1grdFacturas.DataSource = bs_docsventarelacionados
                  bnavRelacionados.BindingSource = bs_docsventarelacionados
               End If
            End If
            c1grdFacturas.Subtotal(AggregateEnum.Clear)
            c1grdFacturas.Subtotal(AggregateEnum.Sum, 0, -1, c1grdFacturas.Cols("DOCVE_TotalPagar").Index, "Total")
            

            '' Cargar la Moneda en texto
            Dim _filter As New ACFiltrador(Of ETipos)
            _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoMoneda)
            _filter.ACFiltrar(Colecciones.Tipos)
            If _filter.ACListaFiltrada.Count > 0 Then
               tslblSon.Text = ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, _filter.ACListaFiltrada(0).TIPOS_Descripcion)
            Else
               tslblSon.Text = ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, "NUEVOS SOLES")
            End If
            c1grdDetalle.AutoSizeRows()

            tslblSon.Text = String.Format("Son: {0}", ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, "NUEVOS SOLES"))
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub subirItem()
      Try
         If IsNothing(CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).Articulo) Then
            '' Cargar Producto
            actxaProdCodigo.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).ARTIC_Codigo
            txtProdDescripcion.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).ARTIC_Descripcion
            actxnProdCantidad.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Cantidad
            '' Cargar Precios
            m_earticulos = New EArticulos()
            actxnPrecio.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitario
            actxnSubImporte.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_SubImporteVenta

            '' Asignar Metodos a controles
         Else
            m_earticulos = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).Articulo
            setProducto(True)
            actxnProdCantidad.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Cantidad
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         If TypeOf ActiveControl Is ACControles.ACTextBoxAyuda And ActiveControl.Name = "actxaProdCodigo" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub


   Private Sub txtOpcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOpcion.KeyDown
      Try
         Select Case e.KeyData
            Case Keys.Enter
               If managerGenerarDocsVenta.ListVENT_DocsVenta.Count >= CType(bs_tdoc.Current, ETipos).TIPOS_Items Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede agregar mas articulos para este tipo de documento {0}", cmbDocumentoFacturar.Text))
                  Return
               End If
               If Not m_modArticulo Then
                  addDetallePedido()
                  setProducto(False)
                  Me.KeyPreview = True
                  m_modArticulo = False
                  pnlItem.Focus()
               Else
                  CType(bs_detdocumentoventa.Current, EVENT_PedidosDetalle).PDDET_Cantidad = actxnProdCantidad.Text
                  CType(bs_detdocumentoventa.Current, EVENT_PedidosDetalle).PDDET_PrecioUnitario = actxnPrecio.Text
                  CType(bs_detdocumentoventa.Current, EVENT_PedidosDetalle).PDDET_SubImporteVenta = actxnSubImporte.Text
                  setProducto(False)
                  calcular()
                  c1grdDetalle.Enabled = True
                  m_modArticulo = False
                  Label2.Focus()
               End If

            Case Keys.Escape
               setProducto(False)
               c1grdDetalle.Enabled = True
               Me.KeyPreview = False
               m_modArticulo = False
            Case Else
               c1grdDetalle.AutoSizeCols()
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede procesar", ex)
      End Try
   End Sub

   Private Sub txtOpcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpcion.KeyPress
      Try
         Select Case e.KeyChar
            Case "+"c
               If m_modArticulo Then
                  e.Handled = True
                  CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Cantidad = actxnProdCantidad.Text
                  CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitario = actxnPrecio.Text
                  CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_SubImporteVenta = actxnSubImporte.Text
                  setProducto(False)
                  calcular()
                  c1grdDetalle.Enabled = True
                  Me.KeyPreview = False
                  m_modArticulo = False
               Else
                  e.Handled = True
                  If managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Count >= CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_NroLineas Then
                     ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede agregar mas articulos para este tipo de documento {0}", actxnPrecio.Text))
                     Return
                  End If
                  If addDetallePedido() Then
                     actxaProdCodigo.Focus()
                     txtOpcion.Text = ""
                     txtOpcion.SelectAll()
                     setProducto(False)
                  End If
               End If
            Case "-"c
               e.Handled = True
            Case Else
               e.Handled = True
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso opciones", ex)
      End Try
   End Sub

   Private Sub c1grdDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Try
         e.SuppressKeyPress = True
         Select Case e.KeyCode
            Case Keys.Enter
               subirItem()
               'SendKeys.Send("{F4}")
               c1grdDetalle.Enabled = False
               Label14.Focus()
               m_modArticulo = True
               Me.KeyPreview = True
            Case Keys.Delete
               If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
             , String.Format("Desea quitar el Articulo : {0} ", CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).ARTIC_Descripcion) _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                  Dim m_det As EVENT_DocsVentaDetalle = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle)
                  managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Remove(m_det)
                  bs_detdocumentoventa.ResetBindings(False)
                  calcular()
               End If
            Case Else
               e.Handled = False
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede calcular carga el Item", ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         If rbtnCliente.Checked Then
            txtBusqueda_ACAyudaClick(Nothing, Nothing)
         ElseIf rbtnNroCotizacion.Checked Then
            txtBusNumero_ACAyudaClick(Nothing, Nothing)
         End If
         acTool.ACBtnEliminarVisible = m_elifacturas
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso consultar documentos", ex)
      End Try
   End Sub

   Private Sub txtBusNumero_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusNumero.ACAyudaClick
      Try
         busquedaDocumentos(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de documentos", ex)
      End Try
   End Sub

   Private Sub actsbtnModFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actsbtnModFecha.Click
      Try
         Dim _frm As New TModificarFechaFactura(CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Codigo)
         _frm.StartPosition = FormStartPosition.CenterScreen
         If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            btnConsultar_Click(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso modificar Fecha", ex)
      End Try
   End Sub

   Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClean.Click
      Try
         managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoCliente = ""
         m_eentidades = New EEntidades
         actxaCliRazonSocial.Clear()
         actxaCliRuc.Clear()
         cmbDirecciones.Items.Clear()
         pnlItem.Enabled = False
         actxaCliRuc.Focus()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Limpiar Entidad", ex)
      End Try
   End Sub

   Private Sub actxaCliRuc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaCliRuc.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaCliRuc.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               setCliente()
            Else
               If actxaCliRuc.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaCliRuc.Text))
                  btnClean_Click(Nothing, Nothing)
                  lblNroDocumento.Focus()
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaCliRazonSocial_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliRazonSocial.ACAyudaClick
      Try
         AyudaEntidad(actxaCliRazonSocial.Text, 1, "Razon Social", EEntidades.TipoEntidad.Clientes)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso busqueda de cliente por Nombre/Razon Social", ex)
      End Try
   End Sub

   Private Sub actxaCliRuc_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliRuc.ACAyudaClick
      Try
         AyudaEntidad(actxaCliRuc.Text, 0, "R.U.C.", EEntidades.TipoEntidad.Clientes)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Documento de Identidad", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(sender As Object, e As EventArgs) Handles acTool.ACBtnCancelar_Click
      setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(sender As Object, e As EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim m_msg As String = ""
      Dim x_bauditoria As New BAuditoria()
      acTool.ACBtnImprimirVisible = False
      actsbtnPrevisualizar.Visible = False
      acTool.ACBtnAnularVisible = False
      acTool.ACBtnImprimirEnabled = False
      acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
      Try
         If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta) Then
            If Validar(m_msg, x_bauditoria) Then
               managerGenerarDocsVenta.VENT_DocsVenta.ENTID_Cliente = actxaCliRazonSocial.Text
               If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Generar Documento de Venta: {0}", Me.Text) _
                            , String.Format("¿Generar {0} del cliente: {1}? ", cmbDocumentoFacturar.Text, managerGenerarDocsVenta.VENT_DocsVenta.ENTID_Cliente) _
                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                  Dim x_numero As Integer = actxnNumero.Text
                  managerGenerarDocsVenta.VENT_DocsVenta.ZONAS_Codigo = GApp.Zona
                  managerGenerarDocsVenta.VENT_DocsVenta.SUCUR_Id = GApp.Sucursal
                  'managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagado = actxnTotalPagar.Text
                  managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento = cmbDocumentoFacturar.SelectedValue
                  managerGenerarDocsVenta.VENT_DocsVenta.PVENT_Id = GApp.PuntoVenta
                  managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente = cmbDirecciones.Text
                  managerGenerarDocsVenta.VENT_DocsVenta.ENTID_RazonSocial = actxaCliRazonSocial.Text

                  managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoVendedor = managerEntidades.Cliente.ENTID_CodigoVendedor

                  managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PorcentajeIGV = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
                  managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalVenta = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar
                  '' Generar documento de Venta
                  If managerGenerarDocsVenta.generarDocumentoNotaCredito(GApp.Usuario, dtpFecFacturacion.Value, _
                                                              CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_Serie, x_numero, m_msg, x_bauditoria) Then

                     setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Generado Satisfactoriamente", cmbDocumentoFacturar.Text, cmbSerie.Text, actxnNumero.Text.PadLeft(7, "0")), m_msg)
                     btnConsultar_Click(Nothing, Nothing)
                     acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)

                  End If
               End If
            Else
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Grabar el documento de venta, revise los detalles", m_msg)
            End If
         Else
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede grabar el documento, revise los detalles", m_msg)
         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Generar Documento de Venta", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnNuevo_Click(sender As Object, e As EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         nueva()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Crear nuevo registro"), ex)
      End Try
   End Sub

    'Private Sub actxaProdCodigo_ACAyudaClick(sender As Object, e As EventArgs) Handles actxaProdCodigo.ACAyudaClick
    '   Try
    '      If IsNothing(frmCons) Then
    '         frmCons = New CProductos(CProductos.TOrigen.StockLocal) With {.StartPosition = FormStartPosition.CenterScreen}
    '      End If
    '      Me.KeyPreview = False
    '      If frmCons.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '         m_earticulos = frmCons.Articulo
    '         setProducto(True)
    '         Dim _filter As New ACFiltrador(Of ETipos)
    '         _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", m_earticulos.TIPOS_CodUnidadMedida)
    '         If _filter.ACFiltrar(Colecciones.TiposUniMedDecimal).Count > 0 Then
    '            actxnProdCantidad.ACDecimales = 2
    '         Else
    '            actxnProdCantidad.ACDecimales = 0
    '         End If
    '         actxnPrecio.Enabled = True
    '         Me.KeyPreview = True
    '      End If
    '   Catch ex As Exception
    '      ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar productos", ex)
    '   End Try
    'End Sub

   Private Sub acTool_ACBtnSalir_Click(sender As Object, e As EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub actxaNroDocumento_ACAyudaClick(sender As Object, e As EventArgs) Handles actxaNroDocumento.ACAyudaClick
      Try
         Dim _frmCVentas As New CVentas(actxaCliRazonSocial.Text)
         If _frmCVentas.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cmbRefDocumento.SelectedValue = _frmCVentas.VENT_DocsVenta.TIPOS_CodTipoDocumento
            cmbRefSerie.SelectedValue = _frmCVentas.VENT_DocsVenta.DOCVE_Serie
            actxaNroDocumento.Text = _frmCVentas.VENT_DocsVenta.DOCVE_Numero
            lblFecha.Text = String.Format("Fecha: {0}", _frmCVentas.VENT_DocsVenta.DOCVE_FechaDocumento.ToString("dd/MM/yyyy"))
                lblFecha.Tag = _frmCVentas.VENT_DocsVenta.DOCVE_FechaDocumento.ToString("dd/MM/yyyy")

            Dim _docsventas As New BVENT_DocsVenta
                If _docsventas.CargarDetalle(_frmCVentas.VENT_DocsVenta.DOCVE_Codigo) Then

                    _docsventas.VENT_DocsVenta.DOCVE_Referenciado = _frmCVentas.VENT_DocsVenta.DOCVE_Codigo
                    managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle = _docsventas.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                    bs_detdocumentoventa.DataSource = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                    c1grdDetalle.DataSource = bs_detdocumentoventa
                    bnavProductos.BindingSource = bs_detdocumentoventa
                    calcular()
                End If
            managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta.Add(_frmCVentas.VENT_DocsVenta)
            SetMotivo()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar el Documento relacionado"), ex)
      End Try
   End Sub
#End Region

   Private Sub tsbtnAgregar_Click(sender As Object, e As EventArgs) Handles tsbtnAgregar.Click
      Try
         If IsNothing(m_frmcventas) Then m_frmcventas = New CVentas(actxaCliRazonSocial.Text)
         If m_frmcventas.ShowDialog() = Windows.Forms.DialogResult.OK Then
            managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta.Add(m_frmcventas.VENT_DocsVenta)
            bs_docsventarelacionados.ResetBindings(False)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Agregar Documento"), ex)
      End Try
   End Sub

   Private Sub tsbtnQuitar_Click(sender As Object, e As EventArgs) Handles tsbtnQuitar.Click
      Try
         If Not IsNothing(bs_docsventarelacionados) Then
            If Not IsNothing(bs_docsventarelacionados.Current) Then
               '' Codigo
               Dim _relacion As EVENT_DocsVenta = CType(bs_docsventarelacionados.Current, EVENT_DocsVenta)
               managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta.Remove(_relacion)
               bs_docsventarelacionados.ResetBindings(False)
            Else
               Throw New Exception("No se puede cargar el documento")
            End If
         Else
            Throw New Exception("No se puede cargar el documento")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Quitar Documento"), ex)
      End Try
   End Sub

   Private Sub actsbtnPrevisualizar_Click(sender As Object, e As EventArgs) Handles actsbtnPrevisualizar.Click
      Try
         If Not IsNothing(bs_documentos) Then
            If Not IsNothing(bs_documentos.Current) Then
               '' Codigo
               Dim x_codigo As String = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Codigo
               If Not cargar(x_codigo) Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro")
               End If
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede por que no se ha seleccionado ningun registro")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede continuar por que no se ha cargado ningun registro ")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Revisar el Documento"), ex)
      End Try
   End Sub

  
End Class