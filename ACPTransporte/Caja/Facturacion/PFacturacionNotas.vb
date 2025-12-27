Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports System.Text
Imports ACBVentas
Imports ACEVentas
Imports C1.Win.C1FlexGrid
Imports ACSeguridad

Public Class PFacturacionNotas

    'NOTAS DE DEBITO 
    '  %&&  %  ,.   *. %(*                                                                                                                                                                                *(*
    ' , (((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
    ' * ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,Fechas,,,,,,,,,,,,,,,
    '   ,Opciones de Busqueda                            Fecha   De:<   / /  >            A : <  /   /  >              Cliente                 ,@,,#De: < / / >,A: < / / >*.         ,.,,,,*.         ..,
    '   Cliente ____________     Nº Documento                      ____________
    '   .      !____________!      NOTA DE CREDITO           F10  !____________!          Mostrar Todos                                                                                      **Consultar.        
    '   .Documento     Fecha    Doc.Cliente        Cliente     Moneda        Total a Pagar    Condicion    Estado                              **************************************************************
    '   .                                                     (                                                                                **************************************************************
    '   .   %* ,/, , /..#@ .  **,# @(@ ( .%   /./#.   .*  /(*  .      /, .# / / /.     .* .(* , ..*/ ***  ( *& * /* * /#*                 %    **************************************************************
    '   .   * .  . / /.  % @  #/&,, *. / / **,/,. *   ,# @. #  .,    # . **   (      . ,  #/# # ,*/# (*/ @,// .  /* / //.                   */ **************************************************************
    '   .                                                                    # /                                                               **************************************************************
    '   .                                                                                                                                      **************************************************************
    '   .                                                                                                                                      **************************************************************
    '   .   %* ,/,   /(. %    (  ,  *(   *%.,*/        ,,##  / .     .%, .# / / /.     .* .(* , ..*/ ***  ( *& * /* * /#*                 %    **************************************************************
    '   .   * .  .@/ /. # , ,  *(  ., *.,              *. . (/.      ,/  **   (      .   .* . . /.*@     .,#/    **    */   # .,            */ **************************************************************
    '   .                                                                    # /                                                               **************************************************************
    '   .                                                                                                                                      **************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************


    '   ,   , (     #/      , ,          &(                                                                                                                                                              #(  
    '   ,                                                                                                                                                                                                    
    ' % # @(.NUEVO     @  PREVISUALIZAR                                                                                                                   SALIR                                                  
    '&&  &&&*&&&&..&&& **&&..*&& /*&&%(%&&&%&&&&( &&&(&&&&.*&&%**%%&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& &&#(&,,&&&&&&&&&  &&

#Region " Variables "
    Private managerEntidades As BEntidades
    Private managerGenerarDocsVenta As BGenerarDocsVentaTrans
    Private managerVENT_DocsVenta As BVENT_DocsVenta

    Dim _CodigoReferencia As String
    Dim _CodigoRefer As String


    Private bs_etran_docsventadetalle As BindingSource
    Private bs_detdocumentoventa As BindingSource
    Private bs_series As BindingSource
    Private bs_documentos As BindingSource
    Private bs_tdoc As BindingSource
    Private bs_tdocbus As BindingSource
    Private bs_moneda As BindingSource
    Private bs_motivonotacredito As BindingSource
    Private bs_docsventa As BindingSource
    Private bs_docsventarelacionados As BindingSource
    Private m_eentidades As EEntidades

    Private m_listBindHelper As List(Of ACBindHelper)

    Private m_order As Integer = 1
    Private m_modArticulo As Boolean = False
    Private m_elifacturas As Boolean = False

    Private m_tnota As TNota

    Private m_frmfacturacion As PFacturacionFletes

    Enum TNota
        Credito
        Debito
    End Enum

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
    Public Sub New(ByVal x_tnota As TNota)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda

            m_tnota = x_tnota

            If m_tnota = TNota.Debito Then
                Me.Text = String.Format(Me.Text, "Débito")
                acpnlTitulo.ACCaption = String.Format(Me.Text, "Débito")
            ElseIf m_tnota = TNota.Credito Then
                Me.Text = String.Format(Me.Text, "Crédito")
                acpnlTitulo.ACCaption = String.Format(Me.Text, "Crédito")
            End If

            managerEntidades = New BEntidades
            managerVENT_DocsVenta = New BVENT_DocsVenta
            managerGenerarDocsVenta = New BGenerarDocsVentaTrans(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)

            cargarCombos()
            formatearGrilla()

            acTool.ACBtnSalirVisible = True

            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)

            bnavBusqueda.Visible = True
            bnavFacturas.Visible = True
            bnavProductos.Visible = True
            tstFletes.Visible = True

            GApp.DataUsuario.PROC_Codigo = Procesos.getProceso(Procesos.TipoProcesos.PermitirFacturarFechaAnterior)
            Dim _validate As New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarProceso)
            chkPermiteFecha.Visible = _validate.ACProceso

            GApp.DataUsuario.PROC_Codigo = Procesos.getProceso(Procesos.TipoProcesos.EliminarFacturas)
            _validate = New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarProceso)
            m_elifacturas = _validate.ACProceso

            Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACSales_16x16.GetHicon)
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
                _detDocsVenta.DOCVD_Unidad = txtProdUnidad.Text
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

    Private Function busquedaCliente(ByVal x_cadena As String) As Boolean 'Funcion que devuelve true o false con Parametro x_Cadena 
        Try
            Dim m_return As Boolean
            'If txtBusqueda.ACEstadoAutoAyuda Then
            Dim _in As String = String.Format("'{0}'", ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.NotaCredito))
            If managerVENT_DocsVenta.getCliente(x_cadena, "ENTID_Nombres", chkTodos.Checked, True, _
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
            If managerVENT_DocsVenta.getDocumentos(ComboBox2.SelectedValue, IIf(txtBusNumero.Text.Equals(""), "0", txtBusNumero.Text), chkTodos.Checked, cmbDocumentoFacturar.SelectedValue) Then
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
                actxaCliRuc.Text = managerVENT_DocsVenta.VENT_DocsVenta.ENTID_Codigo
                txtDireccion.Text = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente
                'cmbDirecciones.SelectedText = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente
                cmbDocumentoFacturar.SelectedValue = managerVENT_DocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento
                txtMotivo.Text = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Motivo

                cmbSerie.SelectedValue = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Serie
                actxnNumero.Text = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Numero
                '' Cargar Facturas Relacionadas
                If managerGenerarDocsVenta.DocumentosRelacionados(x_codigo) Then
                    'If managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoMotivo = ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.DevolucionItem) Or managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoMotivo = ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.DevolucionTotal) Then
                    '    cmbRefDocumento.SelectedValue = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta(0).TIPOS_CodTipoDocumento
                    '    cmbRefSerie.SelectedValue = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta(0).DOCVE_Serie
                    '    actxaNroDocumento.Text = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta(0).DOCVE_Numero
                    '    _CodigoReferencia = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta(0).DOCVE_Codigo
                    'Else
                    bs_docsventarelacionados = New BindingSource
                    bs_docsventarelacionados.DataSource = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta
                    c1grdFacturas.DataSource = bs_docsventarelacionados
                    bnavFacturas.BindingSource = bs_docsventarelacionados
                    _CodigoReferencia = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta(0).DOCVE_Codigo
                    'End If
                End If
                Dim _filter As New ACFiltrador(Of ETipos)
                _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoMoneda)
                _filter.ACFiltrar(Colecciones.Tipos)
                If _filter.ACListaFiltrada.Count > 0 Then
                    Dim Total As Double
                    Total = (managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar * -1)
                    tslblSon.Text = ACUtilitarios.NumPalabra(Total, _filter.ACListaFiltrada(0).TIPOS_Descripcion)
                Else
                    tslblSon.Text = ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, "NUEVOS SOLES")
                End If
                c1grdDetalle.AutoSizeRows()
                c1grdFacturas.Subtotal(AggregateEnum.Sum, 0, -1, 2, "Total")
                c1grdFacturas.Subtotal(AggregateEnum.Sum, 0, -1, 3, "Total")
                'tslblSon.Text = String.Format("Son: {0}", ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, "NUEVOS SOLES"))
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

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

#Region " Utilitarios "
    Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
        Try
            acTool.ACBtnRehusarVisible = False
            acTool.ACBtnImprimirVisible = False
            acTool.ACBtnAnularVisible = False
            acTool.ACBtnAnular.Visible = False
            Select Case _opcion
                Case ACUtilitarios.ACSetInstancia.Nuevo
                    ACUtilitarios.ACLimpiaVar(pnlCabecera)
                    ACUtilitarios.ACLimpiaVar(pnlItem)
                    ACUtilitarios.ACLimpiaVar(grpCabCuerpo)
                    ACUtilitarios.ACSetControl(pnlCabecera, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
                    ACUtilitarios.ACLimpiaVar(pnlPie)
                    chkIlncluidoIGV.Enabled = False
                    SetControles(True)
                    actsbtnPrevisualizar.Visible = False
                    acTool.ACBtnImprimirVisible = False
                    acTool.ACBtnAnularVisible = False
                    acTool.ACBtnImprimirEnabled = False
                    acTool.ACBtnEliminarVisible = False
                    pnlItem.Enabled = True
                    pnlCabHeader.Enabled = True
                    setEtiqueta(ETipos.TipoMoneda.Soles)
                    cmbDirecciones.DataSource = Nothing
                    pnlPie.Enabled = True
                    txtDireccion.Visible = False
                    cmbDirecciones.Visible = True
                    'tstFletes.Enabled = True

                    managerGenerarDocsVenta.ListTRAN_ViajesVentas = New List(Of ETRAN_ViajesVentas)

                    spcCabecera.Panel2Collapsed = False
                    grpCabCuerpo.Enabled = True
                    tstFletes.Enabled = True

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
                    acTool.ACBtnAnularVisible = False
                    acTool.ACBtnEliminarVisible = m_elifacturas
                Case ACUtilitarios.ACSetInstancia.Previsualizar
                    ACFramework.ACUtilitarios.ACSetControl(grpCabCuerpo, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
                    actxaCliRazonSocial.ACAyuda.Enabled = False
                    actxaCliRazonSocial.ACActivarAyuda = False
                    acTool.ACBtnImprimirVisible = True
                    actxaCliRuc.ACAyuda.Enabled = False
                    actxaCliRuc.ACActivarAyuda = False
                    pnlCabHeader.Enabled = False
                    tstFletes.Enabled = False
                    pnlPie.Enabled = False
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                    acTool.ACBtnGrabarVisible = False
                    actsbtnPrevisualizar.Visible = False
                    SetControles(False)
                    pnlItem.Enabled = False
                    txtDireccion.Visible = True
                    cmbDirecciones.Visible = False
                    acTool.ACBtnImprimirVisible = True
                    chkIlncluidoIGV.Enabled = False
                    acTool.ACBtnAnularVisible = True
                    acTool.ACBtnEliminarVisible = m_elifacturas
                    tstFletes.Enabled = False
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
            'Nota de Credito
            '' Moneda
            bs_motivonotacredito = New BindingSource
            bs_motivonotacredito.DataSource = Colecciones.TiposMotivoNotaCredito
            ACFramework.ACUtilitarios.ACCargaCombo(cmbMotivo, bs_motivonotacredito, "TIPOS_Descripcion", "TIPOS_Codigo")
            AddHandler bs_motivonotacredito.CurrentChanged, AddressOf bs_motivonotacredito_CurrentChanged
            bs_motivonotacredito_CurrentChanged(Nothing, Nothing)


            '' Documento de Venta 
            Dim listDoc As New List(Of ETipos)
            Dim listDocBus As New List(Of ETipos)
            If TNota.Debito = True Then
                For Each Item As ETipos In Colecciones.TiposDocNotasDebito()
                    listDoc.Add(Item.Clone)
                    listDocBus.Add(Item.Clone)
                Next
            Else
                'notas de credito
                For Each Item As ETipos In Colecciones.TiposDocNotasCredito()
                    listDoc.Add(Item.Clone)
                    listDocBus.Add(Item.Clone)
                Next
            End If
            bs_tdoc = New BindingSource() : bs_tdoc.DataSource = listDoc : AddHandler bs_tdoc.CurrentChanged, AddressOf bs_tdoc_CurrentChanged
            bs_tdocbus = New BindingSource() : bs_tdocbus.DataSource = listDocBus : AddHandler bs_tdocbus.CurrentChanged, AddressOf bs_tdocbus_CurrentChanged
            bs_tdoc_CurrentChanged(Nothing, Nothing)
            bs_tdocbus_CurrentChanged(Nothing, Nothing)

            '' Cargar Impresoras

            tscmbImpresora.Text = CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_DispositivoImpresion

            ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumentoFacturar, bs_tdoc, "TIPOS_Descripcion", "TIPOS_Codigo")
            ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoDocumento, bs_tdocbus, "TIPOS_Descripcion", "TIPOS_Codigo")
            'ACFramework.ACUtilitarios.ACCargaCombo(cmbMotivo, bs_tdocbus, "TIPOS_Descripcion", "TIPOS_Codigo")
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
    Private Sub bs_motivonotacredito_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not IsNothing(bs_motivonotacredito.Current) Then
                'If CType(bs_motivonotacredito.Current, ETipos).TIPOS_Codigo = ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.DevolucionItem) Or CType(bs_motivonotacredito.Current, ETipos).TIPOS_Codigo = ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.DevolucionTotal) Or CType(bs_motivonotacredito.Current, ETipos).TIPOS_Codigo = ETipos.getMotivoNotaCredito(ETipos.MotivoNotaCredito.AnulacionOperacion) Then
                '    tabRelacionados.SelectedTab = tpgUnico
                '    If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta) Then
                '        If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta) Then
                '            managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVenta.Clear()
                '        End If
                '    End If
                'Else
                '    tabRelacionados.SelectedTab = tpgVarias
                'End If
                If Not IsNothing(bs_tdocbus) Then bs_tdocbus.ResetBindings(False)
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
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Id", "DOCVD_Item", "DOCVD_Item", 110, True, False, "System.Int") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Detalle", "DOCVD_Detalle", "DOCVD_Detalle", 160, True, False, "System.String") : index += 1
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
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Doc. Cliente", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Cliente", "ENTID_Cliente", "ENTID_Cliente", 150, True, False, "System.String") : index += 1
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


#End Region

#Region " Procesos "

    Private Sub AsignarBinding()
        Try
            m_listBindHelper = New List(Of ACBindHelper)()
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbDocumentoFacturar, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodTipoDocumento"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodTipoMoneda"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbMotivo, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodTipoMotivo"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Numero"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxnImporte, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_ImporteVenta"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnIGV, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_ImporteIgv"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotalPagar, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TotalPagar"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxaCliRazonSocial, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_DescripcionCliente"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(txtDireccion, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_DireccionCliente"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTipoCambio, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TipoCambio"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTCVentaSunat, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TipoCambioSunat"))

            m_listBindHelper.Add(ACBindHelper.ACBind(chkIlncluidoIGV, "Checked", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_PrecIncIVG"))

            If managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento.Year < 1700 Then managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento = DateTime.Now
            m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecFacturacion, "Value", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_FechaDocumento"))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Validar(ByRef m_msg As String, ByRef x_bauditoria As BAuditoria) As Boolean
        Try
            managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.Contado)
            Dim _msg As String = ""
            If Not ACUtilitarios.ACDatosOk(pnlCabecera, _msg) Then
                m_msg &= _msg
                Return False
            End If
            '' Validar la fecha de la factura
            If Not chkPermiteFecha.Checked Then
                Dim _bventas As New BVENT_DocsVenta
                If _bventas.ObtenerUltimaFecha(cmbDocumentoFacturar.SelectedValue) Then
                    If dtpFecFacturacion.Value.Date < _bventas.VENT_DocsVenta.DOCVE_FechaDocumento.Date Then
                        m_msg = String.Format("- Ya existe un factura con fecha: {1:dd/MM/yyyy}, para continuar debe activar la opcion de administracion para permitir una facturacion con una fecha no adecuada.{0}", vbNewLine, _bventas.VENT_DocsVenta.DOCVE_FechaDocumento)
                    End If
                End If
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
            '' Verificar si hay pedidos
            Return Not (m_msg.Length > 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

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
            actxnTCVentaSunat.Text = managerGenerarDocsVenta.TipoCambio.TIPOC_VentaSunat
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
            bnavFacturas.BindingSource = bs_docsventarelacionados

            managerGenerarDocsVenta.ListVENT_DocsVenta = New List(Of EVENT_DocsVenta)
            bs_docsventa = New BindingSource
            bs_docsventa.DataSource = managerGenerarDocsVenta.ListVENT_DocsVenta
            c1grdFacturas.DataSource = bs_docsventa
            bnavFacturas.BindingSource = bs_docsventa

            tabMantenimiento.SelectedTab = tabDatos : cmbDocumentoFacturar.Focus()
            cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles)

            cmbDocumentoFacturar.SelectedIndex = 0
            bs_tdoc_CurrentChanged(Nothing, Nothing)
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
                        Dim _tipocambio As Decimal = actxnTipoCambio.Text

                        '' Calcular los precios con percepcion
                        '' Calcular totales
                        For Each Item As EVENT_DocsVentaDetalle In managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                            _importeTotal += Math.Round(Item.DOCVD_PrecioUnitario * Item.DOCVD_Cantidad, 2)
                            _pesoTotal += Item.DOCVD_PesoUnitario * Item.DOCVD_Cantidad
                            _cantidad += Item.DOCVD_Cantidad
                        Next

                        'Dim _importeIgv As Decimal = Math.Round(_importeTotal * (_igv / 100), 2, MidpointRounding.AwayFromZero)
                        'Dim _total As Decimal = Math.Round(_importeTotal, 2) + Math.Round(_importeIgv, 2, MidpointRounding.AwayFromZero)
                        Dim _total As Decimal = Math.Round(_importeTotal, 2, MidpointRounding.AwayFromZero)
                        Dim _importeIgv As Decimal = Math.Round(_total - (_importeTotal / ((_igv / 100) + 1)), 2, MidpointRounding.AwayFromZero)

                        actxnImporte.Text = Math.Round(_importeTotal / ((_igv / 100) + 1), 2, MidpointRounding.AwayFromZero) : actxnImporte.Formatear()
                        actxnIGV.Text = _importeIgv : actxnIGV.Formatear()
                        _totalPagar = _total
                        actxnTotalPagar.Text = _totalPagar : actxnTotalPagar.Formatear()

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

    Private Sub btnMas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMas.Click
        txtProdDescripcion.Font = New Font(txtProdDescripcion.Font.FontFamily, txtProdDescripcion.Font.Size + 1)
    End Sub

    Private Sub btnMenos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenos.Click
        txtProdDescripcion.Font = New Font(txtProdDescripcion.Font.FontFamily, txtProdDescripcion.Font.Size - 1)
    End Sub

    Private Sub btnNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            NuevoCliente("")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Cliente", ex)
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

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click 'Botont de Consultar 

        Try
            If rbtnCliente.Checked Then 'aca Pregunta si el RadioButton de cliente esta Marcado entonces en TextboxBusqueda_AcAyudaClick()
                txtBusqueda_ACAyudaClick(Nothing, Nothing)
            ElseIf rbtnNroCotizacion.Checked Then 'Aca Pregunta si el radio Button NroCotizacion Esta Marcado entonces en TextoBusNumero_ACaYUDA le pasamos estos parametros 
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

    Private Sub rbtnCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCliente.CheckedChanged
        Try
            grpDocumentos.Enabled = rbtnNroCotizacion.Checked
            grpCliente.Enabled = rbtnCliente.Checked
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso seleccionar tipo de consulta", ex)
        End Try
    End Sub

    Private Sub c1grdBusqueda_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdBusqueda.DoubleClick
        If actsbtnPrevisualizar.Enabled Then
            actsbtnPrevisualizar_Click(Nothing, Nothing)
        End If
    End Sub

#Region " Ayudas "
    Private Sub txtBusqueda_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.ACAyudaClick
        Try
            busquedaCliente(txtBusqueda.Text) 'TxtBusqueda es el Mas Largo en el Formulario 
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de clientes", ex)
        End Try
    End Sub

#End Region

#Region " ToolBox "
    Private Sub acTool_ACBtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnAnular_Click
        Try
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Documento de Venta: {0}", Me.Text) _
                , String.Format("Desea anular el documento: ", CType(bs_documentos.Current, EVENT_DocsVenta).Documento) _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                If managerGenerarDocsVenta.AnularDocumento(CType(bs_documentos.Current, EVENT_DocsVenta), managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo, GApp.Usuario) Then
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Anulado satisfactoriamente")
                    acTool_ACBtnCancelar_Click(Nothing, Nothing)
                    btnConsultar_Click(Nothing, Nothing)
                Else
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede anular el documento")
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso anular factura", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click
        setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
    End Sub

    Private Sub acTool_ACBtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnEliminar_Click
        Try

            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Registro: {0}", Me.Text) _
                         , String.Format("Desea Eliminar el registro del Documento de Venta: {0}", CType(bs_documentos.Current, EVENT_DocsVenta).Documento) _
                         , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                If managerGenerarDocsVenta.EliminarDocumento(CType(bs_documentos.Current, EVENT_DocsVenta), GApp.Usuario) Then
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Eliminado satisfactoriamente")
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Eliminar Factura"), ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
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
                        managerGenerarDocsVenta.VENT_DocsVenta.ENTID_RazonSocial = actxaCliRazonSocial.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoVendedor = GApp.EUsuarioEntidad.ENTID_Codigo
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente = cmbDirecciones.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PorcentajeIGV = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalVenta = (managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar) * -1
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Motivo = txtMotivo.Text
                        '' Generar documento de Venta
                        If managerGenerarDocsVenta.generarDocumentoNotaCredito_(GApp.Usuario, dtpFecFacturacion.Value, _
                                                              CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_Serie, x_numero, m_msg, x_bauditoria, _CodigoRefer) Then

                            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Imprimir Documento de Venta: {0}", Me.Text) _
                           , String.Format("Documento {0} con el numero {1}-{2} Grabado satisfactoriamente, desea Imprimir el Documento", cmbDocumentoFacturar.Text, cmbSerie.Text, actxnNumero.Text.PadLeft(7, "0")) _
                           , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                                '' Imprimir
                                Dim _print As New Impresion(tscmbImpresora.Text)
                                Try
                                    'If _print.Print_NotaCre(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo, managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie) Then
                                    '    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Impreso satisfactoriamente", cmbDocumentoFacturar.Text, cmbSerie.Text, actxnNumero.Text.PadLeft(7, "0")), m_msg)
                                    'Else
                                    '    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede imprimir el documento", m_msg)
                                    'End If
                                    Dim x_docve_codigo As String = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Codigo
                                    Dim x_serie As String = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Serie
                                    If _print.Print_FacturaTransportista(x_docve_codigo, x_serie, False) Then
                                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Impreso satisfactoriamente", cmbDocumentoFacturar.Text, cmbSerie.Text, actxnNumero.Text.PadLeft(7, "0")))
                                    Else
                                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede imprimir el documento")
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

    Private Sub acTool_ACBtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnImprimir_Click
        Try
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Imprimir Factura: {0}", Me.Text) _
                , String.Format("Desea imprimir la Factura: ") _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                Dim _print As New Impresion(tscmbImpresora.Text)
                Dim x_docve_codigo As String = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Codigo
                Dim x_serie As String = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Serie
                If _print.Print_FacturaTransportista(x_docve_codigo, x_serie, False) Then
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Impreso satisfactoriamente", cmbDocumentoFacturar.Text, cmbSerie.Text, actxnNumero.Text.PadLeft(7, "0")))
                Else
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede imprimir el documento")
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Imprimir Guia", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnNuevo_Click
        Try
            nueva()
            '' Activar las opciones generales del teclado
            m_frmfacturacion = Nothing
            KeyPreview = True

            '' Campos Obligatorios
            'txtCodigo.Focus()
            eprError.SetError(Me.cmbDocumentoFacturar, "Campo Obligatorio")
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
            Dim _igv As Decimal = 1 + (Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100)
            Select Case e.KeyChar
                Case "+"c
                    If m_modArticulo Then
                        e.Handled = True
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Cantidad = actxnProdCantidad.Text
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitario = actxnPrecio.Text
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Unidad = txtProdUnidad.Text
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_SubImporteVenta = (actxnSubImporte.Text / (_igv / 100) + 1)
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
    Private Sub SetMotivo()
        Try
            'Dim TipDocumento As String = m_frmfacturacion.VENT_DocsVenta.TIPOS_CodTipoDocumento
            Dim refSerieDocumento As String = m_frmfacturacion.VENT_DocsVenta.DOCVE_Serie
            Dim refNumDocumento As String = m_frmfacturacion.VENT_DocsVenta.DOCVE_Numero
            Dim refFecDocumento As Date = m_frmfacturacion.VENT_DocsVenta.DOCVE_FechaDocumento
            Dim _motivo As String = String.Format("Por la {0}, correspondiente a la F/{1}-{2} del {3}", _
                                                  cmbMotivo.Text, refSerieDocumento, refNumDocumento, _
                                                  refFecDocumento)
            txtMotivo.Text = _motivo
        Catch ex As Exception
            Throw ex
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

    Private Sub acbtnCreaAnulado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
#End Region

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
            Dim _frm As New PModDocFecha(CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Codigo)
            _frm.StartPosition = FormStartPosition.CenterScreen
            If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                btnConsultar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso modificar Fecha", ex)
        End Try
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

    Private Sub tsbtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnImprimir.Click
        Try
            Dim _text As New StringBuilder
            ACFramework.ACUtilitarios.ImprimeLinBlanco(_text, 5)
            _text.Append(String.Format("{0}Viajes Realizados{1}", Space(5), vbNewLine))
            _text.Append(String.Format("{0}====== =========={1}", Space(5), vbNewLine))
            For Each item As ETRAN_ViajesVentas In managerGenerarDocsVenta.ListTRAN_ViajesVentas
                _text.Append(String.Format("{0}{1}{2}", Space(5), item.VIAJE_Descripcion, vbNewLine))
            Next
            Dim _impresion As New Impresion(tscmbImpresora.Text)
            If _impresion.ImprimirLista(_text) Then
                ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Impreso satisfactoriamente")
            End If

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error al imprimir el listado de viajes", ex)
        End Try
    End Sub

    Private Sub tsbtnAddFacturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAddFacturas.Click
        Try
            If IsNothing(m_frmfacturacion) Then m_frmfacturacion = New PFacturacionFletes(PFacturacionFletes.TInicio.Busqueda) With {.StartPosition = FormStartPosition.CenterScreen}
            If m_frmfacturacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If managerGenerarDocsVenta.ListVENT_DocsVenta.Count = 0 Then
                    actxaCliRuc.Text = m_frmfacturacion.VENT_DocsVenta.ENTID_CodigoCliente
                    setCliente()
                    SetMotivo()
                End If
                managerGenerarDocsVenta.ListVENT_DocsVenta.Add(m_frmfacturacion.VENT_DocsVenta)
                bs_docsventa.ResetBindings(False)
                _CodigoRefer = m_frmfacturacion.VENT_DocsVenta.DOCVE_Codigo
                m_frmfacturacion.VENT_DocsVenta = Nothing
            End If
            actxnProdCantidad.Text = "1.00"
            txtProdDescripcion.Text = "Operaciones por nota de credito"

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Agregar Facturas"), ex)
        End Try
    End Sub

    Private Sub tsbtnQuitarFacturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnQuitarFacturas.Click
        Try

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Quitar Facturas"), ex)
        End Try
    End Sub

    Private Sub btnNuevoCliente_Click_1(sender As Object, e As EventArgs) Handles btnNuevoCliente.Click

    End Sub

    Private Sub tabMantenimiento_SelectionChanged(sender As Crownwood.DotNetMagic.Controls.TabControl, oldPage As Crownwood.DotNetMagic.Controls.TabPage, newPage As Crownwood.DotNetMagic.Controls.TabPage) Handles tabMantenimiento.SelectionChanged

    End Sub

End Class