Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports ACBVentas
Imports ACEVentas
Imports ACSeguridad
Imports C1.Win.C1FlexGrid
Imports ZXing

Public Class PFacturacionSimple

#Region " Variables "
    Private managerEntidades As BEntidades
    Private managerGenerarDocsVenta As BGenerarDocsVentaTrans
    Private managerTRAN_Cotizaciones As BTRAN_Cotizaciones
    Private managerVENT_DocsVenta As BVENT_DocsVenta
    Private managerFletes As BTRAN_Fletes

    Private bs_etran_docsventadetalle As BindingSource
    Private bs_condicionpago As BindingSource
    Private bs_detdocumentoventa As BindingSource
    Private bs_series As BindingSource
    Private bs_documentos As BindingSource
    Private bs_tdoc As BindingSource
    Private bs_tdocbus As BindingSource
    Private bs_moneda As BindingSource

    Dim magen_qr As PictureBox
    Dim cont As Integer
    Private m_eentidades As EEntidades

    Private m_listBindHelper As List(Of ACBindHelper)

    Private m_order As Integer = 1
    Private m_modArticulo As Boolean = False

    Private x_imprimir As Boolean = False
    Private x_anular As Boolean = False
    Private x_checked_spot As Boolean = False  'Variable creado frank 

    Private x_valor_REFERENCIAL As Decimal = 0 'Valor general para alex ... para se inserte en LA CABECERA EL VALOR REFERENCIAL
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda

            managerEntidades = New BEntidades
            managerVENT_DocsVenta = New BVENT_DocsVenta
            managerGenerarDocsVenta = New BGenerarDocsVentaTrans(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
            managerTRAN_Cotizaciones = New BTRAN_Cotizaciones

            cargarCombos()
            formatearGrilla()
            acpnlTitulo.ACCaption = "Facturacion Simple - División Transportes "
            bnavBusqueda.Visible = True
            bnavProductos.Visible = True
            chkspot.Enabled = True
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)

            bnavBusqueda.Visible = True
            bnavProductos.Visible = True
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub
#End Region

#Region " Metodos "

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

    Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
        Try
            Dim _where As New Hashtable
            _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
            If managerEntidades.Ayuda(_where, x_opcion) Then
                Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerEntidades.DTEntidades, False)
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
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede mostrar la ayuda, posiblemente no haya datos que mostrar")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function addDetalle() As Boolean
        Dim _detDocsVenta As New EVENT_DocsVentaDetalle
        Try
            Dim _cantidad As Decimal = actxnProdCantidad.Text
            Dim _precio As Decimal = actxnPrecio.Text
            If (_cantidad * _precio) > 0 Then

                _detDocsVenta.DOCVD_Cantidad = actxnProdCantidad.Text
                _detDocsVenta.DOCVD_PrecioUnitario = actxnPrecio.Text
                _detDocsVenta.DOCVD_Unidad = cmbProdUnidad.Text
                ' _detDocsVenta.DOCVD_Unidad = txtProdUnidad.Text
                _detDocsVenta.DOCVD_Item = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Count() + 1
                _detDocsVenta.DOCVD_SubImporteVenta = _detDocsVenta.DOCVD_PrecioUnitario * _detDocsVenta.DOCVD_Cantidad
                _detDocsVenta.DOCVD_Detalle = txtProdDescripcion.Text
                '' Actualizar contenido
                managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(_detDocsVenta)
                bs_detdocumentoventa.ResetBindings(False)

                calcular()
                c1grdDetalle.AutoSizeRows()
                c1grdDetalle.AutoSizeCols()
                Return True
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede agregar el producto, por la Cantida/Precio es incorrecto, corrija y vuelva a intentarlo ")
                If _detDocsVenta.DOCVD_Cantidad = 0 Then
                    actxnProdCantidad.Focus()
                ElseIf _detDocsVenta.DOCVD_PrecioUnitario = 0 Then
                    actxnPrecio.Focus()
                End If
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub setProducto(ByVal x_opcion As Boolean)
        Try
            If x_opcion Then
                txtProdDescripcion.Focus()
            Else
                txtProdDescripcion.Clear()
                actxnProdCantidad.Text = "0.00"
                actxnSubImporte.Text = "0.00"
                actxnPrecio.Text = "0.00"
                txtProdUnidad.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function busquedaCliente(ByVal x_cadena As String) As Boolean
        Try
            Dim m_return As Boolean
            'If txtBusqueda.ACEstadoAutoAyuda Then
            If managerVENT_DocsVenta.getCliente(x_cadena, "ENTID_Nombres", chkTodos.Checked, True, AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date.AddDays(1), GApp.PuntoVenta) Then
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
            If managerVENT_DocsVenta.getDocumentos(ComboBox2.SelectedValue, IIf(txtBusNumero.Text.Equals(""), "0", txtBusNumero.Text), chkTodos.Checked, cmbTipoDocumento.SelectedValue) Then
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
                bs_documentos.DataSource = managerVENT_DocsVenta.ListVENT_DocsVenta
            Else
                managerVENT_DocsVenta.ListVENT_DocsVenta = New List(Of EVENT_DocsVenta)
                bs_documentos.DataSource = managerVENT_DocsVenta.ListVENT_DocsVenta
            End If
            c1grdBusqueda.DataSource = bs_documentos
            bnavBusqueda.BindingSource = bs_documentos
            AddHandler bs_documentos.CurrentChanged, AddressOf bs_docsventa_CurrentChanged
            bs_docsventa_CurrentChanged(Nothing, Nothing)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function cargar(ByVal x_codigo As String) As Boolean
        Try
            If managerVENT_DocsVenta.CargarSinArticulos(x_codigo, True) Then
                '' Setear Valores
                setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Previsualizar)
                managerGenerarDocsVenta.VENT_DocsVenta = managerVENT_DocsVenta.VENT_DocsVenta
                '' Cargar
                AsignarBinding()
                bs_detdocumentoventa = New BindingSource()
                bs_detdocumentoventa.DataSource = managerVENT_DocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                c1grdDetalle.DataSource = bs_detdocumentoventa
                bnavProductos.BindingSource = bs_detdocumentoventa
                tabMantenimiento.SelectedTab = tabDatos
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
                actxaCliRuc.Text = managerVENT_DocsVenta.VENT_DocsVenta.ENTID_CodigoCliente
                'cmbDirecciones.SelectedText = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente
                cmbDocumento.SelectedValue = managerVENT_DocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento
                cmbSerie.SelectedValue = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Serie
                actxnNumero.Text = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Numero
                txtobservacionanulacion.Text = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_MotivoAnulacion
                'EN CASO DE ANULACION QUE SE CAMBIE PARA DIFERENCIAR  :  FRANK

                '***************************Funcion para el Color de anulados
                ColoresAnulados(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Estado)

                '***************************Funcion para el Color de anulados


                Dim _filter As New ACFiltrador(Of ETipos)
                _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoMoneda)
                _filter.ACFiltrar(Colecciones.Tipos)
                If _filter.ACListaFiltrada.Count > 0 Then
                    tslblSon.Text = ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, _filter.ACListaFiltrada(0).TIPOS_Descripcion)
                Else
                    tslblSon.Text = ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, "NUEVOS SOLES")
                End If
                c1grdDetalle.AutoSizeRows()
                'tslblSon.Text = String.Format("Son: {0}", ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, "NUEVOS SOLES"))
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub ColoresAnulados(ByVal x_docve_estado As String)
        If (x_docve_estado = "X") Then

            pnlCabecera.BackColor = Color.DarkRed
            pnlItem.BackColor = Color.DarkRed
            pnlCabHeader.BackColor = Color.DarkRed
            pnlItem.BackColor = Color.DarkRed
            acpnlTitulo.InactiveGradientHighColor = Color.DimGray
            acpnlTitulo.InactiveGradientLowColor = Color.DarkRed
            grpDetPago.BackColor = Color.DarkRed
            pnlPie.BackColor = Color.DarkRed
            acTool.ACBtnAnular.Visible = False
            grpDocumento.BackColor = Color.DimGray
            txtobservacionanulacion.Visible = True
            Label14.Visible = True
        Else
            pnlCabecera.BackColor = Color.MidnightBlue '
            pnlItem.BackColor = Color.FromArgb(3, 55, 145) '
            acpnlTitulo.InactiveGradientHighColor = Color.FromArgb(90, 135, 215) '
            acpnlTitulo.InactiveGradientLowColor = Color.FromArgb(3, 55, 145) '
            grpDetPago.BackColor = Color.FromArgb(3, 55, 145) '
            pnlPie.BackColor = Color.LightSteelBlue
            grpDocumento.BackColor = Color.MidnightBlue
            grpCabCuerpo.BackColor = Color.LightSteelBlue
            txtobservacionanulacion.Visible = False
            Label14.Visible = False
            pnlCabHeader.BackColor = Color.MidnightBlue
            'acTool.ACBtnAnular.Visible = True
        End If
    End Sub


    Private Sub cargarCliente(ByVal x_entid_codigo As String)
        Try
            managerEntidades.Cargar(x_entid_codigo)
            actxaCliRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
            actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SubirItem()
        Try
            If Not IsNothing(bs_detdocumentoventa.Current) Then
                '' Cargar Producto
                txtProdDescripcion.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Detalle
                actxnProdCantidad.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Cantidad
                actxnPrecio.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitario
                actxnSubImporte.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Importe
                txtProdUnidad.Text = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Unidad
                setProducto(True)
            Else
                setProducto(False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub setCotizToFactura(ByVal x_cotiz_codigo As String)
        Try
            If managerTRAN_Cotizaciones.Cargar(x_cotiz_codigo, True) Then
                managerGenerarDocsVenta.VENT_DocsVenta.ENTID_Codigo = managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo
                managerGenerarDocsVenta.VENT_DocsVenta.ENTID_Cliente = managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Cliente
                managerGenerarDocsVenta.VENT_DocsVenta.ENTID_NroDocumento = managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_NroDocumento
                managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoMoneda = managerTRAN_Cotizaciones.TRAN_Cotizaciones.TIPOS_CodTipoMoneda
                managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = managerTRAN_Cotizaciones.TRAN_Cotizaciones.TIPOS_CodCondicionPago
                managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento = managerTRAN_Cotizaciones.TRAN_Cotizaciones.TIPOS_CodTipoDocumento
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DescripcionCliente = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_NombreCliente


                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionCliente

                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_ImporteVenta = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_ImporteVenta
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_ImporteIgv = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_ImporteIgv
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_TotalVenta
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_NotaPie = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_NotaPie
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_FechaDocumento
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Guias = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Guia
                managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)

                For Each item As ETRAN_CotizacionesDetalle In managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle
                    Dim m_event_docsventadetalle As New EVENT_DocsVentaDetalle()
                    m_event_docsventadetalle.DOCVD_Cantidad = item.COTDT_Cantidad
                    m_event_docsventadetalle.DOCVD_Item = item.COTDT_Item
                    m_event_docsventadetalle.DOCVD_Unidad = item.COTDT_Unidad
                    m_event_docsventadetalle.DOCVD_Detalle = item.COTDT_Detalle
                    m_event_docsventadetalle.DOCVD_PrecioUnitario = item.COTDT_PrecioUnitario
                    m_event_docsventadetalle.DOCVD_SubImporteVenta = item.COTDT_SubImporteVenta
                    managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(m_event_docsventadetalle)
                Next

                managerGenerarDocsVenta.ListTRAN_ViajesVentas = New List(Of ETRAN_ViajesVentas)
                Dim _etran_viajesventas As New ETRAN_ViajesVentas
                _etran_viajesventas.VIAJE_Id = managerTRAN_Cotizaciones.TRAN_Cotizaciones.VIAJE_Id
                _etran_viajesventas.FLETE_Id = managerTRAN_Cotizaciones.TRAN_Cotizaciones.FLETE_Id
                managerGenerarDocsVenta.ListTRAN_ViajesVentas.Add(_etran_viajesventas)

                bs_detdocumentoventa = New BindingSource
                bs_detdocumentoventa.DataSource = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                c1grdDetalle.DataSource = bs_detdocumentoventa
                bnavProductos.BindingSource = bs_detdocumentoventa
            End If
            actxaCliRuc.Text = managerGenerarDocsVenta.VENT_DocsVenta.ENTID_NroDocumento
            setCliente()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region " Utilitarios "
    Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
        Try
            acTool.ACBtnRehusarVisible = False
            '-- acTool.ACBtnImprimirVisible = False
            Dim _validate As ACValidarUsuario
            _validate = New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarVariosProcesos)
            For Each item As ACSeguridad.EProcesos In _validate.ListProcesos
                Select Case item.PROC_Codigo

                    Case Procesos.getProceso(Procesos.TipoProcesos.ReimprimirFacturas)
                        x_imprimir = True 'este essss
                    Case Procesos.getProceso(Procesos.TipoProcesos.AnularFacturas)
                        x_anular = True
                End Select
            Next
            Select Case _opcion
                Case ACUtilitarios.ACSetInstancia.Nuevo
                    ACUtilitarios.ACLimpiaVar(pnlCabecera)
                    ACUtilitarios.ACLimpiaVar(pnlItem)
                    ACUtilitarios.ACSetControl(pnlCabecera, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
                    ACUtilitarios.ACLimpiaVar(pnlPie)
                    SetControles(True)
                    acTool.ACBtnImprimirVisible = False
                    actsbtnPrevisualizar.Visible = False
                    acTool.ACBtnAnularVisible = False
                    acTool.ACBtnImprimirEnabled = False
                    pnlItem.Enabled = True
                    pnlCabHeader.Enabled = True
                    setEtiqueta(ETipos.TipoMoneda.Soles)
                    cmbDirecciones.DataSource = Nothing
                    pnlPie.Enabled = True
                    txtDireccion.Visible = False
                    cmbDirecciones.Visible = True
                    Label14.Visible = False
                    txtobservacionanulacion.Visible = False

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
                    txtDireccion.Visible = False
                    cmbDirecciones.Visible = True
                    acpnlTitulo.InactiveGradientHighColor = Color.FromArgb(90, 135, 215)
                    acpnlTitulo.InactiveGradientLowColor = Color.FromArgb(3, 55, 145)
                    chkspot.Checked = False
                Case ACUtilitarios.ACSetInstancia.Previsualizar
                    ACFramework.ACUtilitarios.ACSetControl(grpCabCuerpo, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
                    actxaCliRazonSocial.ACAyuda.Enabled = False
                    actxaCliRazonSocial.ACActivarAyuda = False
                    acTool.ACBtnImprimirVisible = x_imprimir
                    actxaCliRuc.ACAyuda.Enabled = False
                    actxaCliRuc.ACActivarAyuda = False
                    pnlCabHeader.Enabled = False
                    pnlPie.Enabled = False
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                    acTool.ACBtnGrabarVisible = False
                    actsbtnPrevisualizar.Visible = False
                    chkspot.Checked = True
                    SetControles(False)
                    pnlItem.Enabled = False
                    txtDireccion.Visible = True
                    cmbDirecciones.Visible = False
                    Label14.Visible = True
                    txtobservacionanulacion.Visible = True
            End Select
            acTool.ACBtnModificarVisible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetControles(ByVal x_opcion As Boolean)
        cmbDocumento.Enabled = x_opcion

        actxaCliRazonSocial.ACActivarAyuda = x_opcion : actxaCliRazonSocial.ACAyuda.Enabled = x_opcion
        actxaCliRuc.ACActivarAyuda = x_opcion : actxaCliRuc.ACAyuda.Enabled = x_opcion
        grpDocumento.Enabled = x_opcion

        dtpFecFacturacion.Enabled = x_opcion

        pnlItem.Enabled = x_opcion

        btnNuevoCliente.Enabled = x_opcion : btnClean.Enabled = x_opcion
    End Sub

    Private Sub cargarCombos()
        Try
            '' Moneda
            bs_moneda = New BindingSource() : bs_moneda.DataSource = Colecciones.Tipos(ETipos.MyTipos.TipoMoneda)
            AddHandler bs_moneda.CurrentChanged, AddressOf bs_monedas_CurrentChanged
            ACUtilitarios.ACCargaCombo(cmbMoneda, bs_moneda, "TIPOS_Descripcion", "TIPOS_Codigo")

            '' Documento de Venta 
            Dim listDoc As New List(Of ETipos)
            Dim listDocBus As New List(Of ETipos)
            For Each Item As ETipos In Colecciones.TiposDocComprobante()
                listDoc.Add(Item.Clone)
                listDocBus.Add(Item.Clone)
            Next
            bs_tdoc = New BindingSource() : bs_tdoc.DataSource = listDoc : AddHandler bs_tdoc.CurrentChanged, AddressOf bs_tdoc_CurrentChanged
            bs_tdocbus = New BindingSource() : bs_tdocbus.DataSource = listDocBus : AddHandler bs_tdocbus.CurrentChanged, AddressOf bs_tdocbus_CurrentChanged
            bs_tdoc_CurrentChanged(Nothing, Nothing)
            bs_tdocbus_CurrentChanged(Nothing, Nothing)

            ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, bs_tdoc, "TIPOS_Descripcion", "TIPOS_Codigo")
            ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoDocumento, bs_tdocbus, "TIPOS_Descripcion", "TIPOS_Codigo")
            '' Resto
            ACFramework.ACUtilitarios.ACCargaCombo(cmbEntrega, Colecciones.ListEstadoEntrega, ACLista.Descripcion, ACLista.Codigo)
            'COMBO PARA LAS UNIDADES 
            ACFramework.ACUtilitarios.ACCargaCombo(cmbProdUnidad, Colecciones.TiposUnidad_Toneladas, "TIPOS_Desc2", "TIPOS_Codigo")
            'bs_condicionpago = New BindingSource() : bs_condicionpago.DataSource = Colecciones.Tipos(ETipos.MyTipos.CondicionPago)
            '' Condicion de Pago
            bs_condicionpago = New BindingSource() : bs_condicionpago.DataSource = Colecciones.Tipos(ETipos.MyTipos.CondicionPago)
            ACFramework.ACUtilitarios.ACCargaCombo(cmbCondicionPago, bs_condicionpago, "TIPOS_Descripcion", "TIPOS_Codigo")
            AddHandler bs_condicionpago.CurrentChanged, AddressOf bs_condicionpago_CurrentChanged
            bs_condicionpago_CurrentChanged(Nothing, Nothing)

            Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACSales_16x16.GetHicon)
        Catch ex As Exception
            Throw ex
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
                    lbligv.Text = String.Format("I.G.V. : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
                    lblImporte.Text = String.Format("Importe : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
                    lblTotalPagar.Text = String.Format("Total Pagar : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
                Case ETipos.TipoMoneda.Dolares
                    lbligv.Text = String.Format("I.G.V. : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Dolares))
                    lblImporte.Text = String.Format("Importe : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Dolares))
                    lblTotalPagar.Text = String.Format("Total Pagar : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Dolares))
                Case Else
                    setEtiqueta(ETipos.TipoMoneda.Soles)
            End Select
        Catch ex As Exception
            Throw ex
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
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Id", "DOCVD_Item", "DOCVD_Item", 110, True, False, "System.Int") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Detalle", "DOCVD_Detalle", "DOCVD_Detalle", 160, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Unidad", "DOCVD_Unidad", "DOCVD_Unidad", 160, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Peso", "DOCVD_Cantidad", "DOCVD_Cantidad", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo3d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Precio", "DOCVD_PrecioUnitario", "DOCVD_PrecioUnitario", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
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
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
        End Try
    End Sub
#End Region

#Region " Procesos "

    Private Sub AsignarBinding()
        Try
            m_listBindHelper = New List(Of ACBindHelper)()
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbDocumento, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodTipoDocumento"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodTipoMoneda"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbEntrega, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_EstEntrega"))

            m_listBindHelper.Add(ACBindHelper.ACBind(cmbCondicionPago, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodCondicionPago"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnPlazo, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Plazo"))


            m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Numero"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxnImporte, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_ImporteVenta"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnIGV, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_ImporteIgv"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotalPagar, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TotalPagar"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxaCliRazonSocial, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_DescripcionCliente"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(txtDireccion, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_DireccionCliente"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTipoCambio, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TipoCambio"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTCVentaSunat, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TipoCambioSunat"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtNotaPie, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_NotaPie"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtGuias, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Guias"))


            m_listBindHelper.Add(ACBindHelper.ACBind(chkDetraccion, "Checked", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_AfectoDetraccion"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbDetraccion, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_PorcentajeDetraccion"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotalDetraccion, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_ImporteDetraccion"))

            If managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento.Year < 1700 Then managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento = DateTime.Now
            m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecFacturacion, "Value", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_FechaDocumento"))

            If managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PlazoFecha.Year < 1700 Then managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PlazoFecha = DateTime.Now
            m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecPlazo, "Value", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_PlazoFecha"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Validar(ByRef m_msg As String) As Boolean
        Try
            'managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.Contado)
            Dim _msg As String = ""
            If Not ACUtilitarios.ACDatosOk(pnlCabecera, _msg) Then
                m_msg &= _msg
                Return False
            End If
            '' Validar Detalle
            bs_detdocumentoventa.ResetBindings(False)
            ''
            If Not managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Count > 0 Then
                m_msg = "- NO se ha ingresado items para este documento"
            End If
            '' Valida que la cantidad y el precio es superior a 0
            For Each Item As EVENT_DocsVentaDetalle In managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                If Not Item.DOCVD_Cantidad > 0 And Item.DOCVD_PrecioUnitario > 0 Then
                    m_msg &= String.Format("- El Producto tiene como cantidad {0} y el precio {1}, no es aceptable", Item.DOCVD_Cantidad, Item.DOCVD_PrecioUnitario, vbNewLine)
                End If
            Next

            Dim _tfactura As Decimal = actxnTotalPagar.Text
            'si la factura es simple y tiene 
            'If _tfactura > 700 Then
            '    If chkDetraccion.Checked = False Then
            '        m_msg &= String.Format("La factura es mayor a 700, debe tener detraccion ", vbNewLine)
            '    End If
            'End If
            '' Verificar si hay pedidos
            Return Not (m_msg.Length > 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function NuevaFactura() As Boolean
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
            actxnTCVentaSunat.Text = managerGenerarDocsVenta.TipoCambio.TIPOC_VentaSunat
            '' Para Cargar detalle del producto
            bs_detdocumentoventa = New BindingSource

            managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
            bs_detdocumentoventa.DataSource = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
            c1grdDetalle.DataSource = bs_detdocumentoventa
            bnavProductos.BindingSource = bs_detdocumentoventa

            tabMantenimiento.SelectedTab = tabDatos : cmbDocumento.Focus()
            cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles)

            cmbDocumento.SelectedIndex = 0
            bs_tdoc_CurrentChanged(Nothing, Nothing)
            cmbEntrega.SelectedIndex = 0

            chkDetraccion.Checked = False
            cmbDetraccion.SelectedIndex = 0
            Return True
        Catch ex As Exception
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
            Throw ex
        End Try
    End Function

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
    Private Sub bs_condicionpago_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            If Not IsNothing(bs_condicionpago) Then
                If CType(bs_condicionpago.Current, ETipos).TIPOS_Numero = 0 Then
                    actxnPlazo.Text = 0
                    'actxnPlazo.ReadOnly = True
                Else
                    'actxnPlazo.ReadOnly = False
                    If Not IsNothing(managerEntidades.Cliente) Then
                        '  actxnPlazo.Text = CInt(CType(bs_condicionpago.Current, ETipos).TIPOS_Numero) 'managerEntidades.Cliente.CLIEN_PlazoCredito

                        Dim diasPlazo As Integer = CInt(CType(bs_condicionpago.Current, ETipos).TIPOS_Numero)

                        'actxnPlazo.Text = CInt(CType(bs_condicionpago.Current, ETipos).TIPOS_Numero) 'managerEntidades.Cliente.CLIEN_PlazoCredito
                        actxnPlazo.Text = diasPlazo.ToString()


                        Dim fechaActual As DateTime = DateTime.Now
                        Dim fechaPlazo As DateTime = fechaActual.AddDays(diasPlazo)

                        ' dtpFecPlazo.Value = DateTime.Now.AddDays(managerEntidades.Cliente.CLIEN_PlazoCredito)
                        dtpFecPlazo.Value = fechaPlazo 'ESTO SERIA LA FECHA DE PLAZO QUE APLICARIAMOS 
                    Else
                        actxnPlazo.Clear()
                    End If

                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso cargar la condicion de pago", ex)
        End Try
    End Sub

    Private Sub bs_docsventa_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not IsNothing(bs_documentos.Current) Then
                If CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado) Then
                    acTool.ACBtnAnularEnabled = False
                    actsbtnModFecha.Enabled = True
                    actsbtnModFecha.Visible = True
                Else
                    acTool.ACBtnAnularEnabled = True
                    actsbtnModFecha.Enabled = False
                    actsbtnModFecha.Visible = False
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
        End Try
    End Sub

    Private Sub bs_tdoc_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not IsNothing(bs_tdoc.Current) Then
                '' Cargar las series
                If managerGenerarDocsVenta.GetSeries(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, CType(bs_tdoc.Current, ETipos).TIPOS_Codigo, GApp.Aplicacion) Then
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
                If managerGenerarDocsVenta.GetSeries(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, CType(bs_tdocbus.Current, ETipos).TIPOS_Codigo, GApp.Aplicacion) Then
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

    Private Sub bs_monedas_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            setProducto(False)
            CambiarMoneda()
            calcular()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
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
                        Dim _totalDetraccion As Decimal = 0
                        Dim _porcentajeDetraccion As Decimal = 0
                        Dim _tipocambio As Decimal = actxnTipoCambio.Text

                        '' Calcular los precios con percepcion
                        '' Calcular totales
                        For Each Item As EVENT_DocsVentaDetalle In managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                            _importeTotal += Item.DOCVD_PrecioUnitario * Item.DOCVD_Cantidad
                            _pesoTotal += Item.DOCVD_PesoUnitario * Item.DOCVD_Cantidad
                            _cantidad += Item.DOCVD_Cantidad
                        Next

                        Dim _total As Decimal = Math.Round(_importeTotal, 2) '+ Math.Round(_importeIgv, 2, MidpointRounding.AwayFromZero)
                        actxnImporte.Text = Math.Round(_importeTotal / 1.18, 2, MidpointRounding.AwayFromZero) : actxnImporte.Formatear()
                        Dim _importeIgv As Decimal = Math.Round((_importeTotal / 1.18) * (_igv / 100), 2, MidpointRounding.AwayFromZero)

                        actxnIGV.Text = _importeIgv : actxnIGV.Formatear()
                        _totalPagar = _total
                        actxnTotalPagar.Text = _totalPagar : actxnTotalPagar.Formatear()
                        '***********************************************************************************************************************************************
                        If _totalPagar > 700 And cmbDetraccion.Text = "0" Then
                            'If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Advertencia: {0}", Me.Text), String.Format("Tu Factura ya Supero los 700 y no Agregaste la Detraccion Quieres Continuar ?  ", ""), ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

                            '***********************************************************************************************************************************************
                            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Advertencia : {0} ", Me.Text), String.Format("Tu factura Ya supero los 700 y no Agregaste la Detraccion 👀"))
                            'If _totalPagar > 700 Then 'ERA 700 pero que aplique ahora a los 400
                            '    _porcentajeDetraccion = Convert.ToDecimal(cmbDetraccion.Text)
                            '    _totalDetraccion = _totalPagar * ((_porcentajeDetraccion / 100))
                            '    _totalDetraccion = CLng(_totalDetraccion)
                            '    _actxnTotalDetraccion.Text = _totalDetraccion : _actxnTotalDetraccion.Formatear()
                            '    txtNotaPie.Text = Parametros.GetParametro("pg_FacDetCtaCte", True) 'agregado frank 
                            'Else

                            '    _totalDetraccion = Convert.ToDecimal("0.00")

                            '    _actxnTotalDetraccion.Text = _totalDetraccion : _actxnTotalDetraccion.Formatear()
                            'End If

                            '***********************************************************************************************************************************************
                            'Else
                            '    Dim m_det As EVENT_DocsVentaDetalle = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle)
                            '    managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Remove(m_det)
                            '    bs_detdocumentoventa.ResetBindings(False)
                            '    'calcular()
                            '    ACControles.ACDialogos.ACMostrarMensajeInformacion("Aviso   ", "Cancelaste la Operacion")
                            'End If
                            '***********************************************************************************************************************************************
                        Else
                            If _totalPagar > 700 And cmbDetraccion.Text <> "0" Then 'ERA 700 pero que aplique ahora a los 400
                                _porcentajeDetraccion = Convert.ToDecimal(cmbDetraccion.Text)
                                _totalDetraccion = _totalPagar * ((_porcentajeDetraccion / 100))
                                _totalDetraccion = CLng(_totalDetraccion)
                                _actxnTotalDetraccion.Text = _totalDetraccion : _actxnTotalDetraccion.Formatear()
                                txtNotaPie.Text = Parametros.GetParametro("pg_FacDetCtaCte", True) 'agregado frank 
                                chkspot.Checked = True 'Esto se se toma encuenta para Hacer un cambio en la impresion defacturas 
                                x_checked_spot = True
                            Else
                                If _totalPagar > 400 Then
                                    txtNotaPie.Text = Parametros.GetParametro("pg_FacDetCtaCte", True)
                                    _totalDetraccion = Convert.ToDecimal("0.00")
                                    chkspot.Checked = True 'Esto se se toma encuenta para Hacer un cambio en la impresion defacturas
                                Else
                                    _totalDetraccion = Convert.ToDecimal("0.00")
                                    chkspot.Checked = False
                                    x_checked_spot = False
                                    txtNotaPie.Clear()
                                End If
                                _actxnTotalDetraccion.Text = _totalDetraccion : _actxnTotalDetraccion.Formatear()
                            End If
                        End If
                        '***********************************************************************************************************************************************
                        tslblSon.Text = String.Format("Son: {0}", ACUtilitarios.NumPalabra(_totalPagar, cmbMoneda.Text))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Ordenar(ByVal x_columna As String)
        Dim _ordenador As New ACOrdenador(Of EVENT_DocsVenta)
        Try
            If m_order = 2 Then x_columna += " DESC"
            _ordenador.ACOrdenamiento = x_columna
            CType(bs_documentos.DataSource, List(Of EVENT_DocsVenta)).Sort(_ordenador)
            c1grdBusqueda.Refresh()
            m_order = IIf(m_order = 1, 2, 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#End Region

#Region " Metodos de Controles"

    Private Sub btnNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            NuevoCliente("")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Cliente", ex)
        End Try
    End Sub

    Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            If rbtnCliente.Checked Then
                txtBusqueda_ACAyudaClick(Nothing, Nothing)
            ElseIf rbtnNroCotizacion.Checked Then
                txtBusNumero_ACAyudaClick(Nothing, Nothing)
            End If
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

    Private Sub rbtnCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCliente.CheckedChanged
        Try
            grpDocumentos.Enabled = rbtnNroCotizacion.Checked
            grpCliente.Enabled = rbtnCliente.Checked
            AcFecha.Enabled = rbtnCliente.Checked
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso seleccionar tipo de consulta", ex)
        End Try
    End Sub

    Private Sub c1grdBusqueda_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdBusqueda.DoubleClick
        If actsbtnPrevisualizar.Enabled Then
            actsbtnPrevisualizar_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub chkDetraccion_CheckedChanged(sender As Object, e As EventArgs) Handles chkDetraccion.CheckedChanged
        Try
            If chkDetraccion.Checked Then
                cmbDetraccion.Enabled = True
                cmbDetraccion.SelectedIndex = 1
            Else
                cmbDetraccion.Enabled = False
                cmbDetraccion.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

#Region " Ayudas "
    Private Sub txtBusqueda_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.ACAyudaClick
        Try
            busquedaCliente(txtBusqueda.Text)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de clientes", ex)
        End Try
    End Sub

#End Region

#Region " ToolBox "
    Private Sub acTool_ACBtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnAnular_Click
        Try
            Dim x_motivo As String = ""
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Documento de Venta: {0}", Me.Text) _
                , String.Format("Desea anular el documento: ", CType(bs_documentos.Current, EVENT_DocsVenta).Documento) _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                Dim form_anulacion As New TMotivo_anulacion(TMotivo_anulacion.TDocumento.Factura) With {.StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Normal}
                If form_anulacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim _motivo As String = String.Format("Usuario: {1} {0} - Fecha: {2:dd/MM/yyyy HH:mm} {0} Motivo: {3} {0} Equipo: {4}-{5}",
                                                            vbNewLine, GApp.EUsuario.USER_CodUsr, DateTime.Now,
                                                            form_anulacion.Motivo, GApp.BaseDatos, GApp.Servidor)
                    If managerGenerarDocsVenta.AnularDocumento(CType(bs_documentos.Current, EVENT_DocsVenta), GApp.Usuario, _motivo) Then
                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Anulado satisfactoriamente")
                        acTool_ACBtnCancelar_Click(Nothing, Nothing)
                        btnConsultar_Click(Nothing, Nothing)
                    Else
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede anular el documento")
                    End If
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso anular factura", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click
        setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
    End Sub


    '********************************************************************************************************************
    'Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
    '    GenerarDocumentoVenta()
    'End Sub
    'Private Sub GenerarDocumentoVenta()
    '    Dim m_msg As String = ""
    '    Try
    '        If IsNothing(managerGenerarDocsVenta.VENT_DocsVenta) Then
    '            MostrarMensajeError("No se puede grabar el documento, revise los detalles")
    '            Return
    '        End If

    '        If Not Validar(m_msg) Then
    '            MostrarMensajeError("No se puede grabar el documento de venta, revise los detalles")
    '            Return
    '        End If

    '        managerGenerarDocsVenta.VENT_DocsVenta.ENTID_Cliente = actxaCliRazonSocial.Text

    '        If MostrarMensajePregunta("Generar Documento de Venta", $"¿Generar {cmbDocumento.Text} del cliente: {managerGenerarDocsVenta.VENT_DocsVenta.ENTID_Cliente}?") <> DialogResult.Yes Then
    '            Return
    '        End If

    '        ' Asignar valores a las propiedades
    '        AsignarValoresDocumento()

    '        ' Generar documento de venta
    '        If Not managerGenerarDocsVenta.generarDocumentoSimple(GApp.Usuario, dtpFecFacturacion.Value, CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_Serie, actxnNumero.Text, cmbEntrega.SelectedValue, m_msg, chkspot.Checked) Then 'x_checked_spot
    '            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
    '            MostrarMensajeInformacion("No se puede grabar el documento, revise los detalles")
    '            Return
    '        End If

    '        If MostrarMensajePregunta("Imprimir Documento de Venta", $"Documento {cmbDocumento.Text} con el numero {cmbSerie.Text}-{actxnNumero.Text.PadLeft(7, "0")} grabado satisfactoriamente, ¿desea imprimir el documento?") = DialogResult.Yes Then
    '            ImprimirDocumento()
    '        End If

    '        setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
    '        btnConsultar_Click(Nothing, Nothing)

    '    Catch ex As Exception
    '        MostrarMensajeError("Ocurrió un error en el proceso Generar Documento de Venta", ex)
    '    End Try
    'End Sub

    'Private Sub AsignarValoresDocumento()
    '    With managerGenerarDocsVenta.VENT_DocsVenta
    '        .ZONAS_Codigo = GApp.Zona
    '        .SUCUR_Id = GApp.Sucursal
    '        .TIPOS_CodTipoDocumento = cmbDocumento.SelectedValue
    '        .TIPOS_CodCondicionPago = cmbCondicionPago.SelectedValue
    '        .PVENT_Id = GApp.PuntoVenta
    '        .DOCVE_EstEntrega = cmbEntrega.SelectedValue
    '        .ENTID_CodigoVendedor = GApp.EUsuarioEntidad.ENTID_Codigo
    '        .DOCVE_DireccionCliente = cmbDirecciones.Text
    '        .DOCVE_PorcentajeIGV = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
    '        .DOCVE_TotalVenta = .DOCVE_TotalPagar
    '        .DOCVE_AfectoDetraccion = .DOCVE_AfectoDetraccion
    '        .DOCVE_PorcentajeDetraccion = .DOCVE_PorcentajeDetraccion
    '        .DOCVE_ImporteDetraccion = .DOCVE_ImporteDetraccion
    '        '.DOCVE_Referencia = Decimal.Round(x_valor_REFERENCIAL, 2)
    '        .DOCVE_PlazoFecha = dtpFecPlazo.Value
    '        .DOCVE_Plazo = actxnPlazo.Text
    '        .DOCVE_NotaPie = txtNotaPie.Text
    '    End With
    'End Sub

    'Private Sub ImprimirDocumento()
    '    Try
    '        Dim _print As New Impresion(tscmbImpresora.Text)
    '        Dim _btran As New ACBVentas.BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
    '        _btran.REPOS_Fac(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo)

    '        Dim fecha As Date = Format(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento, "yyyy-MM-dd")
    '        Dim _qr As String = $"{GApp.EmpresaRUC}|{_btran.VENT_DocsVenta.COD_Documento}|{managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie}|{managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Numero}|{managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_ImporteIgv}|{managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar}|{fecha}|{_btran.VENT_DocsVenta.tipodocumento}|{managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoCliente}"

    '        Dim magen_qr As New PictureBox With {
    '        .Size = New Point(140, 140),
    '        .SizeMode = PictureBoxSizeMode.StretchImage,
    '        .Image = GenerarQR(_qr)
    '    }

    '        If _print.Print_FacturaTermica(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo, managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie, chkspot.Checked, PrintDocument1, CType(cmbSerie.SelectedItem, EVENT_PVentDocumento).PVDOCU_NroLineas) Then
    '            MostrarMensajeSatisfactorio("Documento impreso satisfactoriamente")
    '        Else
    '            MostrarMensajeInformacion("No se puede imprimir el documento")
    '        End If
    '    Catch ex As Exception
    '        MostrarMensajeError("Ocurrió un error al imprimir el documento", ex)
    '    End Try
    'End Sub

    'Private Function GenerarQR(data As String) As Bitmap
    '    Dim bw As New BarcodeWriter
    '    bw.Options = New ZXing.Common.EncodingOptions() With {
    '    .Width = 140,
    '    .Height = 140,
    '    .Margin = 0
    '}
    '    bw.Format = ZXing.BarcodeFormat.QR_CODE
    '    Return New Bitmap(bw.Write(data))
    'End Function

    'Private Sub MostrarMensajeError(mensaje As String, Optional ex As Exception = Nothing)
    '    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
    '    ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), mensaje, ex)
    'End Sub

    'Private Function MostrarMensajePregunta(titulo As String, mensaje As String) As DialogResult
    '    Return ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("{0}: {1}", titulo, Me.Text), mensaje, ACControles.ACDialogos.LabelBotom.Si_No)
    'End Function

    'Private Sub MostrarMensajeInformacion(mensaje As String)
    '    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
    '    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), mensaje, "")
    'End Sub

    'Private Sub MostrarMensajeSatisfactorio(mensaje As String)
    '    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), mensaje, "")
    'End Sub
    '********************************************************************************************************************

    Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
        Dim m_msg As String = ""


        Try
            If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta) Then
                If Validar(m_msg) Then
                    managerGenerarDocsVenta.VENT_DocsVenta.ENTID_Cliente = actxaCliRazonSocial.Text
                    If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Generar Documento de Venta: {0}", Me.Text) _
                                 , String.Format("¿Generar {0} del cliente: {1}? ", cmbDocumento.Text, managerGenerarDocsVenta.VENT_DocsVenta.ENTID_Cliente) _
                                 , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        Dim x_numero As Integer = actxnNumero.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.ZONAS_Codigo = GApp.Zona
                        managerGenerarDocsVenta.VENT_DocsVenta.SUCUR_Id = GApp.Sucursal
                        'managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagado = actxnTotalPagar.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento = cmbDocumento.SelectedValue
                        managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = cmbCondicionPago.SelectedValue
                        managerGenerarDocsVenta.VENT_DocsVenta.PVENT_Id = GApp.PuntoVenta
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_EstEntrega = cmbEntrega.SelectedValue
                        managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoVendedor = GApp.EUsuarioEntidad.ENTID_Codigo
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente = cmbDirecciones.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PorcentajeIGV = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalVenta = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar

                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_AfectoDetraccion = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_AfectoDetraccion
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PorcentajeDetraccion = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PorcentajeDetraccion
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_ImporteDetraccion = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_ImporteDetraccion
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_NotaPie = txtNotaPie.Text
                        '' Plazo de Pago
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PlazoFecha = dtpFecPlazo.Value
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Plazo = actxnPlazo.Text

                        ''Generar documento de Venta
                        If managerGenerarDocsVenta.generarDocumentoSimple(GApp.Usuario, dtpFecFacturacion.Value, CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_Serie, x_numero, cmbEntrega.SelectedValue, m_msg) Then

                            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Imprimir Documento de Venta: {0}", Me.Text) _
                                   , String.Format("Documento {0} con el numero {1}-{2} Grabado satisfactoriamente, desea Imprimir el Documento", cmbDocumento.Text, cmbSerie.Text, actxnNumero.Text.PadLeft(7, "0")) _
                                   , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                                '' Imprimir
                                Dim _print As New Impresion(tscmbImpresora.Text)

                                Dim _btran As New ACBVentas.BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
                                _btran.REPOS_Fac(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo)


                                Dim fecha As Date
                                fecha = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento
                                fecha = Format(fecha, "yyyy-MM-dd")
                                Dim _qr As String = GApp.EmpresaRUC & "|" & _btran.VENT_DocsVenta.COD_Documento & "|" & managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie & "|" & managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Numero & "|" & managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_ImporteIgv & "|" & managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar & "|" & fecha & "|" & _btran.VENT_DocsVenta.tipodocumento & "|" & managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoCliente
                                magen_qr = New PictureBox()
                                magen_qr.Size = New Point(140, 140)
                                magen_qr.SizeMode = PictureBoxSizeMode.StretchImage

                                '
                                Dim bw As BarcodeWriter = New ZXing.BarcodeWriter
                                Dim encOptions = New ZXing.Common.EncodingOptions()
                                encOptions.Width = 140
                                encOptions.Height = 140
                                encOptions.Margin = 0

                                bw.Options = encOptions

                                bw.Format = ZXing.BarcodeFormat.QR_CODE
                                Dim result = New Bitmap(bw.Write(_qr))
                                magen_qr.Image = result

                                cont = 1
                                Try
                                    'If _print.Print_FacturaTransportistaSimple(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo, managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie,True) Then
                                    '   ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Impreso satisfactoriamente", cmbDocumento.Text, cmbSerie.Text, actxnNumero.Text.PadLeft(7, "0")), m_msg)
                                    'Else
                                    '   ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede imprimir el documento", m_msg)
                                    'End If
                                    If _print.Print_FacturaTermica(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo, managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie,
                                                                  chkspot.Checked,
                                                                    PrintDocument1,
                                                       CType(cmbSerie.SelectedItem, EVENT_PVentDocumento).PVDOCU_NroLineas) Then
                                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Impreso satisfactoriamente", cmbDocumento.Text, cmbSerie.Text, actxnNumero.Text.PadLeft(7, "0")), m_msg)

                                    Else
                                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede imprimir el documento", m_msg)
                                    End If
                                Catch ex As Exception
                                    ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error al imprimir el documento", ex)
                                End Try
                                setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
                                btnConsultar_Click(Nothing, Nothing)
                            Else
                                setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
                                btnConsultar_Click(Nothing, Nothing)
                            End If
                        Else
                            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
                            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede grabar el documento, revise los detalles", m_msg)
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

    Private Sub acTool_ACBtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnImprimir_Click
        Try
            Dim x_docve_codigo As String = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Codigo
            Dim x_serie As String = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Serie
            Dim x_numero As Integer = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Numero
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Imprimir Factura: {0}", Me.Text) _
                , String.Format("Desea imprimir la Factura: {0}-{1:0000000}", x_serie, x_numero) _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                Dim _print As New Impresion(tscmbImpresora.Text)
                'If _print.Print_FacturaTransportistaSimple(x_docve_codigo, x_serie,True) Then
                '   ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Impreso satisfactoriamente", cmbDocumento.Text, cmbSerie.Text, actxnNumero.Text.PadLeft(7, "0")))
                'Else
                '   ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede imprimir el documento")
                'End If
                Dim _btran As New ACBVentas.BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
                _btran.REPOS_Fac(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo)

                Dim fecha As Date
                fecha = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento
                fecha = Format(fecha, "yyyy-MM-dd")
                Dim _qr As String = GApp.EmpresaRUC & "|" & _btran.VENT_DocsVenta.COD_Documento & "|" & managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Serie & "|" & managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Numero & "|" & managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_ImporteIgv & "|" & managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_TotalPagar & "|" & fecha & "|" & _btran.VENT_DocsVenta.tipodocumento & "|" & managerVENT_DocsVenta.VENT_DocsVenta.ENTID_CodigoCliente
                magen_qr = New PictureBox()
                magen_qr.Size = New Point(140, 140)
                magen_qr.SizeMode = PictureBoxSizeMode.StretchImage

                '
                Dim bw As BarcodeWriter = New ZXing.BarcodeWriter
                Dim encOptions = New ZXing.Common.EncodingOptions()
                encOptions.Width = 140
                encOptions.Height = 140
                encOptions.Margin = 0

                bw.Options = encOptions
                bw.Format = ZXing.BarcodeFormat.QR_CODE
                Dim result = New Bitmap(bw.Write(_qr))
                magen_qr.Image = result

                cont = 1
                If _print.Print_FacturaTermica(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo, managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie,
                                                                     chkspot.Checked, 'Cambiado x Frank 
                                                         PrintDocument1,
                                                          CType(cmbSerie.SelectedItem, EVENT_PVentDocumento).PVDOCU_NroLineas) Then


                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Impreso satisfactoriamente")
                End If
            End If

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Imprimir Guia", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnNuevo_Click
        Try
            NuevaFactura()
            '' Activar las opciones generales del teclado
            KeyPreview = True

            '' Campos Obligatorios
            'txtCodigo.Focus()
            eprError.SetError(Me.cmbDocumento, "Campo Obligatorio")
            eprError.SetError(Me.actxaCliRuc, "Campo Obligatorio")
            eprError.SetError(Me.actxaCliRazonSocial, "Campo Obligatorio")
            Me.KeyPreview = True

        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nueva Factura", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub

    Private Sub actsbtnPrevisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actsbtnPrevisualizar.Click
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
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso previsualizar", ex)
        End Try
    End Sub
#End Region

#Region " Textos "
    Private Sub txtOpcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpcion.KeyPress
        Try
            Select Case e.KeyChar
                Case "+"c
                    If m_modArticulo Then
                        e.Handled = True
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Cantidad = actxnProdCantidad.Text
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitario = actxnPrecio.Text
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_SubImporteVenta = actxnSubImporte.Text
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Detalle = txtProdDescripcion.Text
                        setProducto(False)
                        calcular()
                        c1grdDetalle.Enabled = True
                        Me.KeyPreview = False
                        m_modArticulo = False
                    Else
                        e.Handled = True
                        If addDetalle() Then
                            lblCantidad.Focus()
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

    Private Sub txtOpcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOpcion.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    addDetalle()
                    setProducto(False)
                    Me.KeyPreview = True
                Case Keys.Escape
                    setProducto(False)
                    c1grdDetalle.Enabled = True
                    Me.KeyPreview = False
                Case Else

            End Select
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede procesar", ex)
        End Try
    End Sub

    Private Sub actxnProdCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles actxnProdCantidad.LostFocus
        Try
            Dim _cantidad As Decimal = actxnProdCantidad.Text
            Dim _importe As Decimal = actxnPrecio.Text
            actxnSubImporte.Text = _cantidad * _importe : actxnSubImporte.Formatear()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso calcular Sub-Importe", ex)
        End Try
    End Sub

    Private Sub actxnPrecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles actxnPrecio.LostFocus
        Try
            Dim _cantidad As Decimal = actxnProdCantidad.Text
            Dim _importe As Decimal = actxnPrecio.Text
            actxnSubImporte.Text = _cantidad * _importe : actxnSubImporte.Formatear()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso calcular Sub-Importe", ex)
        End Try
    End Sub

    Private Sub txtProdDescripcion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProdDescripcion.GotFocus
        Me.KeyPreview = False
    End Sub

    Private Sub txtProdDescripcion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProdDescripcion.LostFocus
        Me.KeyPreview = True
    End Sub

    Private Sub actxaCotiz_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCotiz.ACAyudaClick
        Dim frmAyuda As New PCotizaciones(PCotizaciones.Inicio.Busqueda)
        If frmAyuda.ShowDialog = Windows.Forms.DialogResult.OK Then
            setCotizToFactura(frmAyuda.TRAN_Cotizaciones.COTIZ_Codigo)
            actxaCotiz.Text = frmAyuda.TRAN_Cotizaciones.COTIZ_Codigo
            pnlItem.Enabled = False
            cmbDocumento.Focus()
            c1grdDetalle.AutoSizeRows()

            KeyPreview = True
        End If
    End Sub
#End Region

#Region " Grillas "
    Private Sub c1grdBusqueda_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdBusqueda.BeforeSort
        Try
            Ordenar(c1grdBusqueda.Cols(e.Col).UserData)
            c1grdBusqueda.Subtotal(AggregateEnum.Clear)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
        End Try
    End Sub

    Private Sub c1grdBusqueda_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdBusqueda.OwnerDrawCell
        Try
            If e.Row < c1grdBusqueda.Rows.Fixed OrElse e.Col < c1grdBusqueda.Cols.Fixed Then Return
            If c1grdBusqueda.Rows(e.Row)("DOCVE_Estado") = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado) Then
                e.Style = c1grdBusqueda.Styles("Anulado")
            End If

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
        End Try
    End Sub

    Private Sub c1grdDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1grdDetalle.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Delete
                    If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
                        , String.Format("¿Desea quitar el Registro Seleccionado?") _
                        , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        Dim m_det As EVENT_DocsVentaDetalle = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle)
                        managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Remove(m_det)
                        bs_detdocumentoventa.ResetBindings(False)
                        calcular()
                    End If
                Case Keys.Enter
                    SubirItem()
                    'SendKeys.Send("{F4}")
                    c1grdDetalle.Enabled = False
                    lblCantidad.Focus()
                    m_modArticulo = True
                Case Else
            End Select
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede calcular carga el Item", ex)
        End Try
    End Sub
#End Region

#Region " Ayuda para Cliente "
    Private Sub setCliente()
        '' Cargar datos adicionales cliente
        If actxaCliRuc.ACAyuda.Enabled = True Then
            If managerEntidades.CargarDocIden(actxaCliRuc.Text, EEntidades.TipoInicializacion.Direcciones) Then
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

                'cargar cliente credito
                If managerEntidades.CargarCliente() Then
                    If managerEntidades.Cliente.CLIEN_Credito Then
                        cmbCondicionPago.SelectedValue = managerEntidades.Cliente.CLIEN_CodCondicionPago  ''ETipos.getCondicionPago('ETipos.TipoPago.Credito)
                        'cmbCondicionPago.Enabled = m_pmcondpago
                        ' Plazo de pago
                        '  actxnPlazo.Text = managerEntidades.Cliente.CLIEN_PlazoCredito
                        ' dtpFecPlazo.Value = DateTime.Now.AddDays(managerEntidades.Cliente.CLIEN_PlazoCredito)
                        Dim diasPlazo As Integer = CInt(CType(bs_condicionpago.Current, ETipos).TIPOS_Numero)

                        'actxnPlazo.Text = CInt(CType(bs_condicionpago.Current, ETipos).TIPOS_Numero) 'managerEntidades.Cliente.CLIEN_PlazoCredito
                        actxnPlazo.Text = diasPlazo.ToString()


                        Dim fechaActual As DateTime = DateTime.Now
                        Dim fechaPlazo As DateTime = fechaActual.AddDays(diasPlazo)

                        ' dtpFecPlazo.Value = DateTime.Now.AddDays(managerEntidades.Cliente.CLIEN_PlazoCredito)
                        dtpFecPlazo.Value = fechaPlazo 'ESTO SERIA LA FECHA DE PLAZO QUE APLICARIAMOS 
                    Else
                        cmbCondicionPago.SelectedValue = ETipos.getCondicionPago(ETipos.TipoPago.Contado)
                        'cmbCondicionPago.Enabled = m_pmcondpago
                        ' Plazo de pago
                        actxnPlazo.Text = 0
                        dtpFecPlazo.Value = DateTime.Now
                    End If
                Else
                    If CType(cmbCondicionPago.SelectedItem, ETipos).TIPOS_Numero > 0 Then
                        MsgBox("El Cliente no tiene el credito")

                    End If

                    cmbCondicionPago.Enabled = False
                    'cmbCondicionPago.SelectedIndex = 0
                End If

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

        Catch ex As NullReferenceException
            ACControles.ACDialogos.ACMostrarMensajeInformacion("Falta Datos ", Me.Text, "El sistema no pudo encontrar datos de Credito en Clientes o Simplemente no Existe en Clientes")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
        End Try
    End Sub

    Private Sub actxaCliRazonSocial_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliRazonSocial.ACAyudaClick
        Try
            AyudaEntidad(actxaCliRazonSocial.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Clientes)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso busqueda de cliente por Nombre/Razon Social", ex)
        End Try
    End Sub

    Private Sub actxaCliRuc_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliRuc.ACAyudaClick
        Try
            AyudaEntidad(actxaCliRuc.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Clientes)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Documento de Identidad", ex)
        End Try
    End Sub

#End Region

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

    Private Sub AcFecha_ACFecIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecIni_KeyDown
        If e.KeyData = Keys.Enter Then
            AcFecha.ACDtpFecha_A.Focus()
        End If
    End Sub

    Private Sub AcFecha_ACFecFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecFin_KeyDown
        If e.KeyData = Keys.Enter Then
            btnConsultar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtBusqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnConsultar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtBusNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnConsultar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub actsbtnModFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actsbtnModFecha.Click
        Try
            Dim _frm As New PModDocFecha(CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Codigo) With {.StartPosition = FormStartPosition.CenterScreen, .MaximizeBox = False, .MinimizeBox = False, .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog}
            If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                btnConsultar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso modificar Fecha", ex)
        End Try
    End Sub

    Private Sub acbtnCreaAnulado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acbtnCreaAnulado.Click
        Try
            Dim _frm As New PCreaFactAnulado()
            _frm.StartPosition = FormStartPosition.CenterScreen
            If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                btnConsultar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Crear Anulado / En Blanco", ex)
        End Try
    End Sub

    Private Sub btnMas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMas.Click
        txtProdDescripcion.Font = New Font(txtProdDescripcion.Font.FontFamily, txtProdDescripcion.Font.Size + 1)
    End Sub

    Private Sub btnMenos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenos.Click
        txtProdDescripcion.Font = New Font(txtProdDescripcion.Font.FontFamily, txtProdDescripcion.Font.Size - 1)
    End Sub

    Private Sub tsbtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExcel.Click
        Try
            Utilitarios.ExportarXLS(c1grdBusqueda, "Facturas")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso enviar a excel", ex)
        End Try
    End Sub

    Private Sub tscmbImpresora_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmbImpresora.DropDown
        Try
            If IsNothing(Colecciones.ListPrinter) Then
                Colecciones.CargarImpresoras()
            End If
            ACFramework.ACUtilitarios.ACCargaCombo(tscmbImpresora.ComboBox, Colecciones.ListPrinter, "DeviceName", "DeviceName")
        Catch ex As Exception

        End Try
    End Sub
#End Region


    Private Sub PFacturacionSimple_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFecFacturacion.Value = DateTime.Now
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim tipo As String 'str As String



        Dim s As String = globales_.cabecera
        Dim s4 As String = globales_.cabecera1
        Dim s1 As String = globales_.cuerpo
        Dim s2 As String = globales_.cuerpoprecios
        Dim esp As String = globales_.cuerpoespacio
        Dim pieesp As String = globales_.Pieespacios
        Dim s3 As String = globales_.pie
        Dim s5 As String = globales_.pie1
        Dim s6 As String = globales_.cuerpo1
        Dim tam As Integer = globales_.tamdeta

        If cont = 1 Then
            tipo = "Cliente"
            cont = cont + 1
        Else
            tipo = "Control"
        End If



        'Dim MyLetraNormal As New Font("Courier New", 8)
        'Dim MyLetraNormal As New Font("Lucida Sans Typewriter", 8)
        Dim MyLetraNormal As New Font("Lucida Sans Typewriter", 8)
        'lineas
        Dim ts As Double = s.ToString().Split(vbCrLf).Length
        Dim ts1 As Double = s1.ToString().Split(vbCrLf).Length
        Dim ts3 As Double = s3.ToString().Split(vbCrLf).Length
        Dim ts4 As Double = esp.ToString().Split(vbCrLf).Length
        Dim ts5 As Double = pieesp.ToString().Split(vbCrLf).Length
        'y
        Dim y As Double = (MyLetraNormal.GetHeight(e.Graphics)) * ts
        Dim yesp As Double = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts4)
        Dim y1 As Double = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts1)
        Dim y2 As Integer = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts1 + ts3)
        Dim y3 As Double = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts1 + ts3 + 13) '->imagen
        'Dim y4 As Double = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts1 + 23)
        Dim y4 As Double = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts1 + 24.5)
        Dim ypieesp As Double = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts1 + ts5)


        ' e.Graphics.DrawString(s4, New Font("Microsoft Tai Le", 12, FontStyle.Bold), Brushes.Black, 0, 0)
        e.Graphics.DrawString(s4, New Font("Lucida Sans Typewriter", 9, FontStyle.Bold), Brushes.Black, 0, 0)
        e.Graphics.DrawString(s, MyLetraNormal, Brushes.Black, 0, 18)
        e.Graphics.DrawString(s1, MyLetraNormal, Brushes.Black, 0, y)
        e.Graphics.DrawString(s6, New Font("Lucida Sans Typewriter", 8, FontStyle.Bold), Brushes.Black, 0, yesp)
        e.Graphics.DrawString(s3, MyLetraNormal, Brushes.Black, 0, y1 - 10)
        e.Graphics.DrawString(s5, MyLetraNormal, Brushes.Black, 0, ypieesp)
        'e.Graphics.DrawString(s5, New Font("Microsoft Tai Le", 10, FontStyle.Bold), Brushes.Black, 0, y4)

        'metodo2
        e.Graphics.DrawString(tipo, New Font("Lucida Sans Typewriter", 9, FontStyle.Bold), Brushes.Black, 220, y3) 'TAMF + 210)
        ' e.Graphics.DrawString(tipo, MyLetraNormal, Brushes.Black, 220, y3) 'TAMF + 210)
        'metodo1 señora sonia
        'e.Graphics.DrawString(tipo, MyLetraNormal, Brushes.Black, 50, 220)
        '''''''''''''''''
        'metodo2
        e.Graphics.DrawImage(magen_qr.Image, 70, y2) ' TAMF) 'CREA UN DOCUMENTO IMPRIMIBLE CON LA IMAGEN SITUADA EN EL ORIGEN (0,0) DEL DOCUMENTO 
        'metodo1
        'e.Graphics.DrawImage(magen_qr.Image, 30, 0)

    End Sub

    Private Sub acTool_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles acTool.ItemClicked

    End Sub
End Class