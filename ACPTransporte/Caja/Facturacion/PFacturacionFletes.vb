Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports System.Text
Imports ACBVentas
Imports ACEVentas
Imports C1.Win.C1FlexGrid
Imports ACSeguridad
Imports ZXing
Imports System.Drawing 'Libreria para la Capturad de Pabntalla 
Imports System.Windows.Forms 'Esto tambien 
Imports System.IO


Public Class PFacturacionFletes

    'FACTURACION DE FLETES   ME FALTA 
    ' , (((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
    ' * ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,Fechas,,,,,,,,,,,,,,,
    '   ,Opciones de Busqueda                                                                                                                  Cliente **Consultar,@,,#De: < / / >,A: < / / >*,.,,,,*.    ..,
    '   ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,Codigo ,,,,,,,,,..........,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
    '   .       (                                                   ,              .                           .                               **************************************************************
    '   .Fecha     Codigo    Documento   NumeroDoc.Cli.      Cliente     Moneda   Condicion     Total a Pagar    Cod Flete    Estado   Sunat   **************************************************************
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
    ' % # @(.NUEVO, @ IMPRIMIR   @  PREVISUALIZAR                                                                                                                   SALIR                                                  
    '&&  &&&*&&&&..&&& **&&..*&& /*&&%(%&&&%&&&&( &&&(&&&&.*&&%**%%&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& &&#(&,,&&&&&&&&&  &&


#Region " Variables "
    Private managerEntidades As BEntidades
    Private managerGenerarDocsVenta As BGenerarDocsVentaTrans
    Private managerTRAN_Cotizaciones As BTRAN_Cotizaciones
    Private managerGenerarDocRelacion As BVENT_DocsRelacion
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
    Private bs_viajesventas As BindingSource
    Private bs_viajesguias As BindingSource
    Private bs_viajesguiasdetalle As BindingSource
    Private bs_notasNCredito As BindingSource
    Private bs_documentosPagos As BindingSource
    Private m_eentidades As EEntidades

    Dim magen_qr As PictureBox
    Dim cont As Integer

    Private m_listBindHelper As List(Of ACBindHelper)

    Private m_order As Integer = 1
    Private m_modArticulo As Boolean = False
    Private m_elifacturas As Boolean = False

    Private x_imprimir As Boolean = False
    Private x_anular As Boolean = False

    Private x_valor_REFERENCIAL As Decimal = 0 'Valor general para alex ... para se inserte en LA CABECERA EL VALOR REFERENCIAL
    Private m_tinicio As TInicio

    Private _frmViajes As CViajes

    Enum TInicio
        Normal
        Busqueda
    End Enum


    Enum TInicioCotizacion
        Nuevo
        Editar
        Eliminar

    End Enum




    'Region VARIABELS PARA COMBOBOX 

    Private bd_direcciones_origen As BindingSource
    Private bd_direcciones_destino As BindingSource

    Private bs_departamento_origen As BindingSource

    Private bs_departamento_destino As BindingSource


    Private bs_provincia_origen As BindingSource
    Private bs_provincia_destino As BindingSource
    Private bs_distrito_origen As BindingSource
    Private bs_distrito_destino As BindingSource

    Private m_ubigeoorigen As String = Nothing
    Private m_ubigeodestino As String = Nothing

    Private m_vauldireccionorigen As String = ""
    Private m_vauldirecciondestino As String = ""


    Private m_vauldireccionprovincia As String = ""
    Private m_vauldirecciondistritio As String = ""


#End Region

#Region " Propiedades "

    Public Property VENT_DocsVenta() As EVENT_DocsVenta
        Get
            Return managerGenerarDocsVenta.VENT_DocsVenta
        End Get
        Set(ByVal value As EVENT_DocsVenta)
            managerGenerarDocsVenta.VENT_DocsVenta = value
        End Set
    End Property

#End Region

#Region " Constructores "
    Public Sub New(ByVal x_tinicio As TInicio)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda

            managerEntidades = New BEntidades
            managerVENT_DocsVenta = New BVENT_DocsVenta
            managerGenerarDocsVenta = New BGenerarDocsVentaTrans(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
            managerTRAN_Cotizaciones = New BTRAN_Cotizaciones
            managerFletes = New BTRAN_Fletes
            acpnlTitulo.ACCaption = "Facturacion de Fletes - Division de Transportes "
            cargarCombos()
            formatearGrilla()

            acTool.ACBtnSalirVisible = True
            acTool.ACBtnRehusarVisible = False

            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)

            bnavBusqueda.Visible = True
            bnavFletes.Visible = True
            bnavProductos.Visible = True
            tstFletes.Visible = True
            tstFletes.Enabled = True

            GApp.DataUsuario.PROC_Codigo = Procesos.getProceso(Procesos.TipoProcesos.PermitirFacturarFechaAnterior)
            Dim _validate As New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarProceso)
            chkPermiteFecha.Visible = _validate.ACProceso

            GApp.DataUsuario.PROC_Codigo = Procesos.getProceso(Procesos.TipoProcesos.EliminarFacturas)
            _validate = New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarProceso)
            m_elifacturas = _validate.ACProceso



            m_tinicio = x_tinicio
            Select Case m_tinicio
                Case TInicio.Normal

                Case TInicio.Busqueda
                    acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolSalir
                    acbtnSeleccionar.Visible = True
                    actsbtnPrevisualizar.Visible = True
                    actsbtnModFecha.Visible = False
                    acbtnCreaAnulado.Visible = False
                    acTool.ACBtnEliminar.Visible = False


            End Select

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
                _detDocsVenta.DOCVD_Unidad = cmbProdUnidad.Text
                '  _detDocsVenta.DOCVD_Unidad = txtProdUnidad.Text
                _detDocsVenta.DOCVD_Item = managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Count() + 1
                _detDocsVenta.DOCVD_Detalle = txtProdDescripcion.Text

                _detDocsVenta.DOCVD_ValorReferencial = actxnValorReferencial.Text

                ' _detDocsVenta.DOCVD_ValorReferencial = managerFletes.TRAN_Fletes.FLETE_TotalValorReferencial


                '' Actualizar contenido
                Dim _igv As Decimal = 1 + (Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100)
                If chkIlncluidoIGV.Checked Then
                    _detDocsVenta.DOCVD_PrecioUnitarioPrecIncIGV = actxnPrecio.Text
                    _detDocsVenta.DOCVD_PrecioUnitario = Math.Round(_detDocsVenta.DOCVD_PrecioUnitarioPrecIncIGV / _igv, 4, MidpointRounding.AwayFromZero)
                    _detDocsVenta.DOCVD_SubImporteVenta = _detDocsVenta.DOCVD_PrecioUnitario * _detDocsVenta.DOCVD_Cantidad
                    c1grdDetalle.Cols("DOCVD_PrecioUnitario").Visible = False
                    c1grdDetalle.Cols("DOCVD_PrecioUnitarioPrecIncIGV").Visible = True
                Else
                    _detDocsVenta.DOCVD_PrecioUnitarioPrecIncIGV = 0
                    _detDocsVenta.DOCVD_PrecioUnitario = actxnPrecio.Text
                    _detDocsVenta.DOCVD_SubImporteVenta = _detDocsVenta.DOCVD_PrecioUnitario * _detDocsVenta.DOCVD_Cantidad
                    c1grdDetalle.Cols("DOCVD_PrecioUnitario").Visible = True
                    c1grdDetalle.Cols("DOCVD_PrecioUnitarioPrecIncIGV").Visible = False
                End If
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
                actxnValorReferencial.Text = "0.00"
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
            If managerVENT_DocsVenta.getCliente(x_cadena, "ENTID_Nombres", chkTodos.Checked, True,
                                                AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date.AddDays(1), GApp.PuntoVenta) Then
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
                '' Cargar los Fletes
                If managerGenerarDocsVenta.CargarFletes(x_codigo) Then
                    actxaFlete.Text = managerGenerarDocsVenta.ListTRAN_ViajesVentas(0).FLETE_Id
                    actxaCotiz.Text = managerGenerarDocsVenta.VENT_DocsVenta.COTIZ_Codigo
                    If IsNothing(managerGenerarDocsVenta.TRAN_Cotizaciones) Then
                        actxaCotiz.Clear()
                    Else
                        actxaCotiz.Text = managerGenerarDocsVenta.TRAN_Cotizaciones.COTIZ_Codigo
                    End If
                    actxaCliRuc.Text = managerGenerarDocsVenta.VENT_DocsVenta.ENTID_NroDocumento
                End If
                bs_viajesventas = New BindingSource
                bs_viajesventas.DataSource = managerGenerarDocsVenta.ListTRAN_ViajesVentas
                actxaCotiz.Text = managerGenerarDocsVenta.VENT_DocsVenta.COTIZ_Codigo
                c1grdFletes.DataSource = bs_viajesventas
                bnavFletes.BindingSource = bs_viajesventas
                spcCabecera.Panel2Collapsed = False

                txtDireccion.Text = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente
                txtobservacionanulacion.Text = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_MotivoAnulacion
                'cmbDirecciones.SelectedText = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente
                cmbDocumentoFacturar.SelectedValue = managerVENT_DocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento
                cmbSerieFacturar.SelectedValue = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Serie
                actxnNumeroFacturar.Text = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Numero
                'EN CASO DE ANULACION QUE SE CAMBIE PARA DIFERENCIAR  :  FRANK

                '***************************************estado documento
                ColoresAnulados(managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Estado)
                '****************************************estado documento }

                '**************************CARGAMOS NOTAS DE CREDITO ***********
                If managerVENT_DocsVenta.DocumentosRelacionados(x_codigo) Then
                    bs_notasNCredito = New BindingSource
                    bs_notasNCredito.DataSource = managerVENT_DocsVenta.ListVENT_DocsVenta

                    c1grdNCreditos.DataSource = bs_notasNCredito

                    'c1grdNCreditos.DataSource =

                End If
                '============================================CARGAMOS LOS PAGOS DE ESTA FACTURAS ============
                If managerVENT_DocsVenta.VENT_DOCSVESS_RELACIONADOSPAGOS(x_codigo) Then
                    bs_documentosPagos = New BindingSource
                    bs_documentosPagos.DataSource = managerVENT_DocsVenta.ListTESO_DocsPagos
                    c1grdPagos.DataSource = bs_documentosPagos

                    'c1grdPagos.Subtotal(AggregateEnum.Sum, 2, 2, 1, "Item:{0}") 'Mostrar la suma de toda la factura by frank
                    'c1grdPagos.Subtotal(AggregateEnum.None, 1, 1, 3, "Cod.Cotizacion: {0}") 'agrupar por vehiculos
                    c1grdPagos.Subtotal(AggregateEnum.None, 1, 2, 0, "Suma:{0}")
                    c1grdPagos.Subtotal(AggregateEnum.Sum, 1, 2, 6, "{0}") 'suma de item para separarlos 

                End If



                Dim _filter As New ACFiltrador(Of ETipos)
                _filter.ACFiltro = String.Format("TIPOS_Codigo={0}", managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoMoneda)
                _filter.ACFiltrar(Colecciones.Tipos)
                If _filter.ACListaFiltrada.Count > 0 Then
                    tslblSon.Text = ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, _filter.ACListaFiltrada(0).TIPOS_Descripcion)
                Else
                    tslblSon.Text = ACUtilitarios.NumPalabra(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar, "NUEVOS SOLES")
                End If
                c1grdDetalle.AutoSizeRows()
                c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 2, "Total")
                c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 3, "Total")

                Select Case m_tinicio
                    Case TInicio.Normal

                    Case TInicio.Busqueda
                        acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolSalir
                        acbtnSeleccionar.Visible = True
                        acTool.ACBtnCancelarVisible = True
                End Select
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
            AcPanelCaption2.BackColor = Color.DarkRed
            AcPanelCaption4.BackColor = Color.DarkRed
            AcPanelCaption1.InactiveGradientHighColor = Color.DimGray
            AcPanelCaption1.InactiveGradientLowColor = Color.DarkRed
            acpnlTitulo.InactiveGradientHighColor = Color.DimGray
            acpnlTitulo.InactiveGradientLowColor = Color.DarkRed
            grpFlete.BackColor = Color.DarkRed
            grpDetPago.BackColor = Color.DarkRed
            pnlPie.BackColor = Color.DarkRed
            Label20.Visible = True
            txtobservacionanulacion.Visible = True
            acTool.ACBtnAnular.Visible = False
            grpCabCuerpo.BackColor = Color.DarkRed
        Else
            pnlCabecera.BackColor = Color.MidnightBlue '
            pnlItem.BackColor = Color.FromArgb(3, 55, 145) '
            AcPanelCaption2.BackColor = Color.DarkRed
            AcPanelCaption4.BackColor = Color.DarkRed
            AcPanelCaption1.InactiveGradientHighColor = Color.FromArgb(90, 135, 215) '
            AcPanelCaption1.InactiveGradientLowColor = Color.FromArgb(3, 55, 145) '
            acpnlTitulo.InactiveGradientHighColor = Color.FromArgb(90, 135, 215) '
            acpnlTitulo.InactiveGradientLowColor = Color.FromArgb(3, 55, 145) '
            grpFlete.BackColor = Color.FromArgb(3, 55, 145) '
            grpDetPago.BackColor = Color.FromArgb(3, 55, 145) '
            Label20.Visible = False
            txtobservacionanulacion.Visible = False
            pnlPie.BackColor = Color.LightSteelBlue
            grpCabCuerpo.BackColor = Color.LightSteelBlue
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
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_TotalPagar
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_NotaPie = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_NotaPie
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_FechaDocumento
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Guias = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Guia
                managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PrecIncIVG = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_PrecIncIGV

                managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)

                If managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PrecIncIVG Then
                    c1grdDetalle.Cols("DOCVD_PrecioUnitario").Visible = False
                    c1grdDetalle.Cols("DOCVD_PrecioUnitarioPrecIncIGV").Visible = True
                Else
                    c1grdDetalle.Cols("DOCVD_PrecioUnitario").Visible = True
                    c1grdDetalle.Cols("DOCVD_PrecioUnitarioPrecIncIGV").Visible = False
                End If

                For Each item As ETRAN_CotizacionesDetalle In managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle
                    Dim m_event_docsventadetalle As New EVENT_DocsVentaDetalle()
                    m_event_docsventadetalle.DOCVD_Cantidad = item.COTDT_Cantidad
                    m_event_docsventadetalle.DOCVD_Item = item.COTDT_Item
                    m_event_docsventadetalle.DOCVD_Unidad = item.COTDT_Unidad
                    m_event_docsventadetalle.DOCVD_Detalle = item.COTDT_Detalle
                    m_event_docsventadetalle.DOCVD_PrecioUnitario = item.COTDT_PrecioUnitario
                    m_event_docsventadetalle.DOCVD_PrecioUnitarioPrecIncIGV = item.COTDT_PrecioUnitarioPrecIncIGV
                    m_event_docsventadetalle.DOCVD_PrecIncIGV = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PrecIncIVG
                    m_event_docsventadetalle.DOCVD_SubImporteVenta = item.COTDT_SubImporteVenta

                    managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(m_event_docsventadetalle)
                Next

                Dim _where As New Hashtable
                _where.Add("COTIZ_Codigo", New ACWhere(x_cotiz_codigo))
                Dim _joinCF As New List(Of ACJoin)
                _joinCF.Add(New ACJoin(ETRAN_Fletes.Esquema, ETRAN_Fletes.Tabla, "Cot", ACJoin.TipoJoin.Inner _
                             , New ACCampos() {New ACCampos("FLETE_Id", "FLETE_Id")} _
                             , New ACCampos() {New ACCampos("FLETE_Glosa", "FLETE_Glosa") _
                                               , New ACCampos("FLETE_TotIngreso", "FLETE_TotIngreso") _
                                               , New ACCampos("FLETE_PesoEnTM", "FLETE_PesoEnTM") _
                                               , New ACCampos("FLETE_RazonSocial", "ENTID_RazonSocial")}))
                _joinCF.Add(New ACJoin(ETRAN_Viajes.Esquema, ETRAN_Viajes.Tabla, "Viaje", ACJoin.TipoJoin.Left _
                         , New ACCampos() {New ACCampos("VIAJE_Id", "VIAJE_Id")} _
                         , New ACCampos() {New ACCampos("VIAJE_Descripcion", "VIAJE_Descripcion")}))
                Dim _btran_cotizacionesfletes As New BTRAN_CotizacionesFletes
                If _btran_cotizacionesfletes.CargarTodos(_joinCF, _where) Then
                    managerGenerarDocsVenta.ListTRAN_ViajesVentas = New List(Of ETRAN_ViajesVentas)
                    For Each item As ETRAN_CotizacionesFletes In _btran_cotizacionesfletes.ListTRAN_CotizacionesFletes
                        Dim _etran_viajesventas As New ETRAN_ViajesVentas
                        _etran_viajesventas.FLETE_Id = item.FLETE_Id
                        _etran_viajesventas.VIAJE_Id = item.VIAJE_Id
                        _etran_viajesventas.VIAJE_Descripcion = item.VIAJE_Descripcion
                        _etran_viajesventas.FLETE_Glosa = item.FLETE_Glosa
                        _etran_viajesventas.FLETE_TotIngreso = item.FLETE_TotIngreso
                        _etran_viajesventas.FLETE_PesoEnTM = item.FLETE_PesoEnTM
                        managerGenerarDocsVenta.ListTRAN_ViajesVentas.Add(_etran_viajesventas)
                    Next
                    actxaFlete.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.FLETE_Id

                End If
                bs_viajesventas = New BindingSource
                bs_viajesventas.DataSource = managerGenerarDocsVenta.ListTRAN_ViajesVentas
                c1grdFletes.DataSource = bs_viajesventas
                bnavFletes.BindingSource = bs_viajesventas


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

    Private Sub CargarGuias()
        Try
            Dim _cadenas As String = ""

            For Each item As ETRAN_ViajesVentas In managerGenerarDocsVenta.ListTRAN_ViajesVentas
                _cadenas &= String.Format("{0},", item.FLETE_Id)
            Next
            _cadenas = _cadenas.Substring(0, _cadenas.Length - 1)
            bs_viajesguias = New BindingSource
            If Not managerTRAN_Cotizaciones.ObtenerGuias(_cadenas) Then
                managerTRAN_Cotizaciones.ListTRAN_ViajesGuiasRemision = New List(Of ETRAN_ViajesGuiasRemision)
            End If
            If managerTRAN_Cotizaciones.ListTRAN_ViajesGuiasRemision.Count > 0 Then
                bs_viajesguias.DataSource = managerTRAN_Cotizaciones.ListTRAN_ViajesGuiasRemision
                c1grdEmpresas.DataSource = bs_viajesguias
                AddHandler bs_viajesguias.CurrentChanged, AddressOf bs_viajesguias_CurrentChanged
                bs_viajesguias_CurrentChanged(Nothing, Nothing)
            Else
                spcDetalle.Panel2Collapsed = True
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
            acTool.ACBtnImprimirEnabled = False
            acTool.ACBtnAnularVisible = False
            acTool.ACBtnAnular.Visible = False
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
                    ACUtilitarios.ACLimpiaVar(grpCabCuerpo)
                    ACUtilitarios.ACSetControl(pnlCabecera, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
                    ACUtilitarios.ACLimpiaVar(pnlPie)
                    SetControles(True)
                    actsbtnPrevisualizar.Visible = False
                    '=================BOTON ANULAR FRANK=================
                    acTool.ACBtnAnularVisible = False
                    '==============================================
                    acTool.ACBtnEliminarVisible = False
                    pnlItem.Enabled = True
                    pnlCabecera.Enabled = True
                    setEtiqueta(ETipos.TipoMoneda.Soles)
                    cmbDirecciones.DataSource = Nothing
                    pnlPie.Enabled = True
                    txtDireccion.Visible = False
                    cmbDirecciones.Visible = True
                    spcCabecera.Panel2Collapsed = True
                    spcDetalle.Panel2Collapsed = True
                    actxaFlete.Enabled = True
                    Label14.Enabled = True
                    actxtDireccionOrigen.Enabled = False
                    actxtDireccionDestino.Enabled = False

                    managerGenerarDocsVenta.ListTRAN_ViajesVentas = New List(Of ETRAN_ViajesVentas)
                    bs_viajesventas = New BindingSource
                    bs_viajesventas.DataSource = managerGenerarDocsVenta.ListTRAN_ViajesVentas
                    c1grdFletes.DataSource = bs_viajesventas
                    bnavFletes.BindingSource = bs_viajesventas
                    spcCabecera.Panel2Collapsed = False
                    grpFlete.Enabled = True
                    grpCabCuerpo.Enabled = True
                    tstFletes.Enabled = True

                    ' chkIlncluidoIGV.Enabled = True
                    'Set a los Colores del Formulario  Frank
                    pnlCabecera.BackColor = Color.MidnightBlue '
                    pnlItem.BackColor = Color.FromArgb(3, 55, 145) '
                    AcPanelCaption2.BackColor = Color.DarkRed
                    AcPanelCaption4.BackColor = Color.DarkRed
                    AcPanelCaption1.InactiveGradientHighColor = Color.FromArgb(90, 135, 215) '
                    AcPanelCaption1.InactiveGradientLowColor = Color.FromArgb(3, 55, 145) '
                    acpnlTitulo.InactiveGradientHighColor = Color.FromArgb(90, 135, 215) '
                    acpnlTitulo.InactiveGradientLowColor = Color.FromArgb(3, 55, 145) '
                    grpFlete.BackColor = Color.FromArgb(3, 55, 145) '
                    grpDetPago.BackColor = Color.FromArgb(3, 55, 145) '
                    Label20.Visible = False
                    txtobservacionanulacion.Visible = False

                Case ACUtilitarios.ACSetInstancia.Modificado

                Case ACUtilitarios.ACSetInstancia.Guardar
                    txtBusqueda.Focus()
                Case ACUtilitarios.ACSetInstancia.Deshacer
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                    acTool.ACBtnBuscarVisible = False
                    actsbtnPrevisualizar.Visible = True

                    tabMantenimiento.SelectedTab = tabBusqueda



                    txtphantom_ubigo_origen.Text = Nothing
                    txtphantom_ubigo_destino.Text = Nothing
                    txtphantom_rutas_nombre.Text = Nothing

                    m_vauldirecciondestino = Nothing
                    actxtDireccionDestino.Text = Nothing
                    actxtDireccionOrigen.Text = Nothing




                    acTool.ACBtnEliminarVisible = False
                    pnlPie.Enabled = False
                    pnlItem.Enabled = False
                    txtDireccion.Visible = False
                    cmbDirecciones.Visible = True
                    acTool.ACBtnAnularVisible = False
                    acpnlTitulo.InactiveGradientHighColor = Color.FromArgb(90, 135, 215)
                    acpnlTitulo.InactiveGradientLowColor = Color.FromArgb(3, 55, 145)
                    '***Limpiamos la tabla nota creditos
                    Dim index As Integer = 1
                    index = 1
                    ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdNCreditos, 1, 1, 8, 1, 0)
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "Documento", "DOCVE_Codigo", "DOCVE_Codigo", 250, True, False, "System.String", "0000000") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "Tipo-Documento", "TIPOS_TipoDocCorta", "TIPOS_TipoDocCorta", 110, True, False, "System.String") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "DOCVE_Numero", "DOCVE_Numero", "DOCVE_Numero", 110, True, False, "System.String") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "FechaDocumento", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 250, True, False, "System.DateTime") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "RUC-Cliente", "ENTID_CodigoCliente", "ENTID_CodigoCliente", 250, True, False, "System.String") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "Razon-Social", "DOCVE_DescripcionCliente", "DOCVE_DescripcionCliente", 150, True, False, "System.String") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "Total a Pagar", "DOCVE_TotalPagar", "DOCVE_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1


                    c1grdNCreditos.AllowEditing = False
                    c1grdNCreditos.AutoResize = True
                    c1grdNCreditos.Cols(0).Width = 18
                    c1grdNCreditos.Styles.Alternate.BackColor = Color.WhiteSmoke
                    c1grdNCreditos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
                    c1grdNCreditos.Styles.Highlight.BackColor = Color.Gray
                    c1grdNCreditos.SelectionMode = SelectionModeEnum.Row
                    c1grdNCreditos.AllowResizing = AllowResizingEnum.Rows
                    c1grdNCreditos.AllowAddNew = False

                    '***end set 
                    If m_tinicio = TInicio.Normal Then acTool.ACBtnEliminarVisible = m_elifacturas
                Case ACUtilitarios.ACSetInstancia.Previsualizar
                    ACFramework.ACUtilitarios.ACSetControl(grpCabCuerpo, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
                    actxaCliRazonSocial.ACAyuda.Enabled = False
                    actxaCliRazonSocial.ACActivarAyuda = False

                    actxaCliRuc.ACAyuda.Enabled = False
                    acTool.ACBtnEliminarVisible = False
                    actxaCliRuc.ACActivarAyuda = False
                    grpFlete.Enabled = False
                    pnlCabecera.Enabled = False
                    tstFletes.Enabled = True
                    pnlPie.Enabled = False
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                    acTool.ACBtnGrabarVisible = False
                    actsbtnPrevisualizar.Visible = False
                    SetControles(False)
                    pnlItem.Enabled = False
                    txtDireccion.Visible = True
                    cmbDirecciones.Visible = False
                    acTool.ACBtnImprimirVisible = x_imprimir
                    acTool.ACBtnImprimirEnabled = x_imprimir
                    acTool.ACBtnAnularEnabled = x_anular
                    acTool.ACBtnAnularVisible = x_anular
                    '=========controles para anulacion observaciones 
                    txtObservaciones.Visible = True
                    Label20.Visible = False
                    '===============================================
                    '  chkIlncluidoIGV.Enabled = False

                    acTool.ACBtnEliminarVisible = m_elifacturas
                    spcDetalle.Panel2Collapsed = True
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
        cmbDocumentoFacturar.Enabled = x_opcion
        cmbSerieFacturar.Enabled = x_opcion
        actxnNumeroFacturar.Enabled = x_opcion

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
            For Each Item As ETipos In Colecciones.TiposDocCompFacturacion()
                listDoc.Add(Item.Clone)
                listDocBus.Add(Item.Clone)
            Next
            bs_tdoc = New BindingSource() : bs_tdoc.DataSource = listDoc : AddHandler bs_tdoc.CurrentChanged, AddressOf bs_tdoc_CurrentChanged
            bs_tdocbus = New BindingSource() : bs_tdocbus.DataSource = listDocBus : AddHandler bs_tdocbus.CurrentChanged, AddressOf bs_tdocbus_CurrentChanged
            bs_tdoc_CurrentChanged(Nothing, Nothing)
            bs_tdocbus_CurrentChanged(Nothing, Nothing)

            ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumentoFacturar, bs_tdoc, "TIPOS_Descripcion", "TIPOS_Codigo")
            ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoDocumento, bs_tdocbus, "TIPOS_Descripcion", "TIPOS_Codigo")
            '' Resto
            ACFramework.ACUtilitarios.ACCargaCombo(cmbEntrega, Colecciones.ListEstadoEntrega, ACLista.Descripcion, ACLista.Codigo)
            'COMBO PARA LAS UNIDADES 
            ACFramework.ACUtilitarios.ACCargaCombo(cmbProdUnidad, Colecciones.TiposUnidad_Toneladas, "TIPOS_Desc2", "TIPOS_Codigo")

            ' bs_condicionpago = New BindingSource() : bs_condicionpago.DataSource = Colecciones.Tipos(ETipos.MyTipos.CondicionPago)
            '' Cargar Impresoras

            Dim _existe As Boolean = False
            tscmbImpresora.Text = Parametros.GetParametro("pg_ImpFacturas", _existe)

            ''Detraccion predeterminado 4%
            cmbDetraccion.SelectedIndex = 1

            '' Condicion de Pago
            bs_condicionpago = New BindingSource() : bs_condicionpago.DataSource = Colecciones.Tipos(ETipos.MyTipos.CondicionPago)
            ACFramework.ACUtilitarios.ACCargaCombo(cmbCondicionPago, bs_condicionpago, "TIPOS_Descripcion", "TIPOS_Codigo")
            AddHandler bs_condicionpago.CurrentChanged, AddressOf bs_condicionpago_CurrentChanged
            bs_condicionpago_CurrentChanged(Nothing, Nothing)

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
                    lblTotalDetraccion.Text = String.Format("Detraccion: {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
                    lbligv.Text = String.Format("I.G.V. : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
                    'SE CREO UNA REGION PARA ESO CON LAS CONSTACNTES Y DENTRO DE ELLAS HAY UNA MONEDA QUE TOMA 
                    'COMO CONDICIONAL CASE : SI ETipos.TipoMoneda.Soles : "Coinciden entonces que apararesca el signo de S/." ELSE Tipo de Moneda Dolares 
                    lblImporte.Text = String.Format("Importe : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
                    lblTotalPagar.Text = String.Format("Total Pagar : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
                Case ETipos.TipoMoneda.Dolares
                    lblTotalDetraccion.Text = String.Format("Detraccion: {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Dolares))
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
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 14, 1, 1)
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
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Sunat", "generado", "generado", 150, True, False, "System.String") : index += 1

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
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdFletes, 1, 1, 8, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Flete", "FLETE_Id", "FLETE_Id", 250, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Peso (TNE)", "FLETE_PesoEnTNE", "FLETE_PesoEnTM", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Importe", "FLETE_TotIngreso", "FLETE_TotIngreso", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Viaje", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Descripción", "FLETE_Glosa", "FLETE_Glosa", 250, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Glosa de Viaje", "VIAJE_Descripcion", "VIAJE_Descripcion", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Razon Social", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
            c1grdFletes.AllowEditing = False
            c1grdFletes.AutoResize = True
            c1grdFletes.Cols(0).Width = 18
            c1grdFletes.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdFletes.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdFletes.Styles.Highlight.BackColor = Color.Gray
            c1grdFletes.SelectionMode = SelectionModeEnum.Row
            c1grdFletes.AllowResizing = AllowResizingEnum.Rows
            c1grdFletes.AllowAddNew = False

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdGuias, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "X", "Seleccion", "Seleccion", 250, True, True, "System.Boolean") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Tipo", "TIPOS_TipoDocumento", "TIPOS_TipoDocumento", 250, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Serie-Numero", "Documento", "Documento", 250, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Observacion", "VEGRE_Observacion", "VEGRE_Observacion", 250, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Viaje", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Flete", "FLETE_Id", "FLETE_Id", 250, True, False, "System.String", "0000000") : index += 1
            c1grdGuias.AllowEditing = True
            c1grdGuias.AutoResize = True
            c1grdGuias.Cols(0).Width = 18
            c1grdGuias.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdGuias.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdGuias.Styles.Highlight.BackColor = Color.Gray
            c1grdGuias.SelectionMode = SelectionModeEnum.Row
            c1grdGuias.AllowResizing = AllowResizingEnum.Rows
            c1grdGuias.AllowAddNew = False

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdEmpresas, 1, 1, 2, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdEmpresas, index, "Empresa", "Empresa", "Empresa", 250, True, False, "System.String") : index += 1
            c1grdEmpresas.AllowEditing = False
            c1grdEmpresas.AutoResize = True
            c1grdEmpresas.Cols(0).Width = 18
            c1grdEmpresas.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdEmpresas.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdEmpresas.Styles.Highlight.BackColor = Color.Gray
            c1grdEmpresas.SelectionMode = SelectionModeEnum.Row
            c1grdEmpresas.AllowResizing = AllowResizingEnum.Rows
            c1grdEmpresas.AllowAddNew = False




            '**********************************FORMATEO DE TABLA NOTAS DE CREDITO Frank*******************************************
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdNCreditos, 1, 1, 8, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "Documento", "DOCVE_Codigo", "DOCVE_Codigo", 250, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "Tipo-Documento", "TIPOS_TipoDocCorta", "TIPOS_TipoDocCorta", 110, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "DOCVE_Numero", "DOCVE_Numero", "DOCVE_Numero", 110, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "FechaDocumento", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 250, True, False, "System.DateTime") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "RUC-Cliente", "ENTID_CodigoCliente", "ENTID_CodigoCliente", 250, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "Razon-Social", "DOCVE_DescripcionCliente", "DOCVE_DescripcionCliente", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNCreditos, index, "Total a Pagar", "DOCVE_TotalPagar", "DOCVE_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1


            c1grdNCreditos.AllowEditing = False
            c1grdNCreditos.AutoResize = True
            c1grdNCreditos.Cols(0).Width = 18
            c1grdNCreditos.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdNCreditos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdNCreditos.Styles.Highlight.BackColor = Color.Gray
            c1grdNCreditos.SelectionMode = SelectionModeEnum.Row
            c1grdNCreditos.AllowResizing = AllowResizingEnum.Rows
            c1grdNCreditos.AllowAddNew = False



            '=========================tabla para los Pagos Frank ============================
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdPagos, 1, 1, 12, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "N°Factura", "DOCVE_Codigo", "DOCVE_Codigo", 250, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Doc. Cliente", "ENTID_Codigo", "ENTID_Codigo", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Moneda", "TIPOS_CodTipoMoneda", "TIPOS_CodTipoMoneda", 110, True, False, "System.String") : index += 1
            'ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Moneda", "Tipos_CodTransaccion", "Tipos_CodTransaccion", 250, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Fecha-Creacion", "DPAGO_FecCrea", "DPAGO_FecCrea", 250, True, False, "System.DateTime") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Fecha-Vencimiento", "DPAGO_FechaVenc", "DPAGO_FechaVenc", 250, True, False, "System.DateTime") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Importe", "DPAGO_Importe", "DPAGO_Importe", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Pago.", "TIPOC_VentaSunat", "TIPOC_VentaSunat", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Estado", "DPAGO_Estado", "DPAGO_Estado", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Glosa", "DPAGO_Glosa", "DPAGO_Glosa", 250, True, False, "System.String") : index += 1 'CAJA_AnuladoCaja
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Anulado", "CAJA_AnuladoCaja", "CAJA_AnuladoCaja", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Creado.Por", "DPAGO_UsrCrea", "DPAGO_UsrCrea", 150, True, False, "System.String") : index += 1


            c1grdPagos.AllowEditing = False
            c1grdPagos.AutoResize = True
            c1grdPagos.Cols(0).Width = 18
            c1grdPagos.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdPagos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdPagos.Styles.Highlight.BackColor = Color.Gray
            c1grdPagos.SelectionMode = SelectionModeEnum.Row
            c1grdPagos.AllowResizing = AllowResizingEnum.Rows
            c1grdPagos.AllowAddNew = False



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
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodTipoMoneda")) 'CREO QUE ERA TIPO DE MONEDA AQUI 
            'INTENTAR 
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbEntrega, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_EstEntrega"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumeroFacturar, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Numero"))

            m_listBindHelper.Add(ACBindHelper.ACBind(cmbCondicionPago, "SelectedValue", managerGenerarDocsVenta.VENT_DocsVenta, "TIPOS_CodCondicionPago"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnPlazo, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Plazo"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxnImporte, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_ImporteVenta"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnIGV, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_ImporteIgv"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotalPagar, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TotalPagar"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxaCliRazonSocial, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_DescripcionCliente"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(txtDireccion, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_DireccionCliente"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTipoCambio, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TipoCambio"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTCVentaSunat, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_TipoCambioSunat"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtNotaPie, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_NotaPie"))
            ' m_listBindHelper.Add(ACBindHelper.ACBind(txtGuias, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Guias"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtObservaciones, "Text", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_Observaciones")) 'aca para el VALOR DE VALOREFERENCIAL Y EL NUMERO

            m_listBindHelper.Add(ACBindHelper.ACBind(chkIlncluidoIGV, "Checked", managerGenerarDocsVenta.VENT_DocsVenta, "DOCVE_PrecIncIVG"))


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

    Private Function Validar(ByRef m_msg As String, ByRef x_bauditoria As BAuditoria) As Boolean
        Try
            'managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.Contado)
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
            '' Validar Total de Factura con Total de Fletes
            Dim _total As Decimal = 0
            Dim _tfactura As Decimal = actxnTotalPagar.Text
            For Each item As ETRAN_ViajesVentas In managerGenerarDocsVenta.ListTRAN_ViajesVentas
                _total += item.FLETE_TotIngreso
            Next
            If _total <> _tfactura Then
                'Comentado por Frank ...--> 01-04-2025 dejar como estaba 
                'Dim x_autorizacion As Boolean = x_bauditoria.VerificarAutorizacion(BConstantes.APLIC_Codigo, BConstantes.ZONAS_Codigo,
                '                                                          GApp.Sucursal, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.CotizacionTransporte),
                '                                                          actxaCotiz.Text, ETipos.getTipo(ETipos.TipoAuditoria.FacturaDiferido))
                'If Not x_autorizacion Then
                '    m_msg &= String.Format("- El Total de la Factura ({0}) No coincide con el total de Fletes ({1}), si desea continuar solicite una autorización al Administrador", _tfactura, _total, vbNewLine)
                'End If
            End If

            'If _tfactura > 400 And cmbDocumentoFacturar.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura ) Then '700  Then
            '    If chkDetraccion.Checked = False Then
            '        m_msg &= String.Format("La factura es mayor a 700, debe tener detraccion ", vbNewLine)
            '    End If
            'End If
            'If _tfactura < 400 And cmbDocumentoFacturar.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura) Then '700  Then
            '    If chkDetraccion.Checked = True Then
            '        m_msg &= String.Format("La factura es menor a 700,NO debe tener detraccion ", vbNewLine)
            '    End If
            'End If
            'si es boleta
            If cmbDocumentoFacturar.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Boleta) Then
                If chkDetraccion.Checked = True Then
                    m_msg &= String.Format("Una Boleta, NO debe tener detraccion ", vbNewLine)
                End If
            End If

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

            tabMantenimiento.SelectedTab = tabDatos : cmbDocumentoFacturar.Focus()
            cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles)
            spcCabecera.Panel2Collapsed = True
            _frmViajes = Nothing

            cmbDocumentoFacturar.SelectedIndex = 0
            bs_tdoc_CurrentChanged(Nothing, Nothing)
            cmbEntrega.SelectedIndex = 0
            m_modArticulo = False


            txtphantom_rutas_nombre.Text = Nothing
            txtphantom_ubigo_destino.Text = Nothing
            txtphantom_ubigo_origen.Text = Nothing




            chkDetraccion.Checked = True
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
                actxnNumeroFacturar.Text = (x_numero + 1).ToString()
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
                        actxnPlazo.Text = managerEntidades.Cliente.CLIEN_PlazoCredito
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
                    ACFramework.ACUtilitarios.ACCargaCombo(cmbSerieFacturar, bs_series, "PVDOCU_Serie", "PVDOCU_Serie", _default)
                    AddHandler bs_series.CurrentChanged, AddressOf bs_series_CurrentChanged
                    bs_series_CurrentChanged(Nothing, Nothing)
                    dtpFecFacturacion.Value = DateTime.Now
                    cmbSerieFacturar.Enabled = True
                Else
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar las series, posiblemente no tenga series asignadas")
                    cmbSerieFacturar.Enabled = False
                    cmbSerieFacturar.SelectedIndex = -1
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

    Private Sub bs_viajesguias_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            bs_viajesguiasdetalle = New BindingSource
            If Not IsNothing(bs_viajesguias) Then
                bs_viajesguiasdetalle.DataSource = CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).ListETRAN_ViajesGuiasRemision
                c1grdGuias.DataSource = bs_viajesguiasdetalle
                bnavGuias.BindingSource = bs_viajesguiasdetalle
                tsbtnGenerar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cambiar Empresa", ex)
        End Try
    End Sub

    Private Sub calcular(Optional ByVal x_moneda As Boolean = False)
        Try
            If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta) Then
                If Not IsNothing(managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle) Then
                    If managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Count > 0 Then
                        Dim _importeTotal As Decimal = 0
                        Dim _importeTotalVR As Decimal = 0
                        Dim _pesoTotal As Decimal = 0
                        Dim _igv As Decimal = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
                        Dim _totalPagar As Decimal = 0
                        Dim _cantidad As Decimal = 0
                        Dim _totalDetraccion As Decimal = 0
                        Dim _porcentajeDetraccion As Decimal = 0
                        Dim _tipocambio As Decimal = actxnTipoCambio.Text
                        For Each Item As EVENT_DocsVentaDetalle In managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle

                            '_importeTotal += Math.Round(Item.DOCVD_PrecioUnitario * Item.DOCVD_Cantidad, 2, MidpointRounding.AwayFromZero)
                            _importeTotal += Item.DOCVD_PrecioUnitario * Item.DOCVD_Cantidad
                            _pesoTotal += Item.DOCVD_PesoUnitario * Item.DOCVD_Cantidad
                            _cantidad += Item.DOCVD_Cantidad
                            ''____ valor referencial
                            If Item.DOCVD_ValorReferencial > (Item.DOCVD_PrecioUnitario * Item.DOCVD_Cantidad) Then
                                _importeTotalVR += Item.DOCVD_ValorReferencial
                            Else
                                _importeTotalVR += Item.DOCVD_PrecioUnitario * Item.DOCVD_Cantidad
                            End If

                        Next
                        x_valor_REFERENCIAL = _importeTotalVR
                        Dim _total As Decimal = Math.Round(_importeTotal, 2, MidpointRounding.AwayFromZero) '--Math.Round(_importeTotal * ((_igv / 100) + 1), 2, MidpointRounding.AwayFromZero)
                        'Dim _total As Decimal = _importeTotal * ((_igv / 100) + 1)
                        Dim _importeIgv As Decimal = Math.Round(_total - (_importeTotal / ((_igv / 100) + 1)), 2, MidpointRounding.AwayFromZero)

                        actxnImporte.Text = Math.Round(_importeTotal / ((_igv / 100) + 1), 2, MidpointRounding.AwayFromZero) : actxnImporte.Formatear()
                        actxnIGV.Text = _importeIgv : actxnIGV.Formatear()
                        _totalPagar = _total

                        'modificado para dos decimales
                        Dim _Decimal As Decimal = Mid(_total - Fix(_total), 2, 3) 'Esto nos devolverá: 0.6
                        _totalPagar = Fix(_total) + _Decimal


                        If _totalPagar < 400 And _importeTotalVR > 400 And cmbDocumentoFacturar.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura) Then
                            '===============================================================================================================================================
                            '======================SI EL VALOR REFERENCIAL ES MAYOR A 400 ENTONCES QUE SI APLIQUE LA DETRACCION ==============================
                            _porcentajeDetraccion = Convert.ToDecimal(cmbDetraccion.Text)

                            '_totalDetraccion = _totalPagar * ((_porcentajeDetraccion / 100))
                            _totalDetraccion = _importeTotalVR * ((_porcentajeDetraccion / 100))
                            _totalDetraccion = CLng(_totalDetraccion)
                            _actxnTotalDetraccion.Text = _totalDetraccion : _actxnTotalDetraccion.Formatear()
                            'DE AQUI SACA EL VALOR REFERENCIAL FRANK 29-05-2023
                            Dim SignoMoneda As String = ""
                            SignoMoneda = ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles).ToString
                            txtObservaciones.Text = String.Format("VALOR REFERENCIAL :  {0}{1}", SignoMoneda, Format$(_importeTotalVR, "####.00")) 'ETipos.TipoMoneda 
                            '    'MessageBox.Show(_importeTotalVR)
                            '    '   MessageBox.Show(ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
                            '700 Then
                        ElseIf _totalPagar > 400 And cmbDocumentoFacturar.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura) Then
                            '============================================================================================================================
                            '=============SI EL VALOR DE LA FACTURA MISMA ES MAYOR A 400 ENTONCES QUE TAMBIEN APLIQUE LA DETRACCION ====================================
                            _porcentajeDetraccion = Convert.ToDecimal(cmbDetraccion.Text)

                            '_totalDetraccion = _totalPagar * ((_porcentajeDetraccion / 100))
                            _totalDetraccion = _importeTotalVR * ((_porcentajeDetraccion / 100))
                            _totalDetraccion = CLng(_totalDetraccion)
                            _actxnTotalDetraccion.Text = _totalDetraccion : _actxnTotalDetraccion.Formatear()
                            'DE AQUI SACA EL VALOR REFERENCIAL FRANK 29-05-2023
                            Dim SignoMoneda As String = ""
                            SignoMoneda = ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles).ToString
                            txtObservaciones.Text = String.Format("VALOR REFERENCIAL :  {0}{1}", SignoMoneda, Format$(_importeTotalVR, "####.00")) 'ETipos.TipoMoneda 
                            'MessageBox.Show(_importeTotalVR)
                            '    '   MessageBox.Show(ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
                            txtNotaPie.Text = Parametros.GetParametro("pg_FacDetCtaCte", True)

                        Else

                            _totalDetraccion = Convert.ToDecimal("0.00")
                            _actxnTotalDetraccion.Text = _totalDetraccion : _actxnTotalDetraccion.Formatear()
                            txtObservaciones.Text = String.Format("NO APLICA VR")
                            txtNotaPie.Text = Parametros.GetParametro("pg_FacDetCtaCte", True)
                        End If


                        ''''
                        'actxnTotalPagar.Text = Format$(_totalPagar, "#.00")': actxnTotalPagar.Formatear()
                        actxnTotalPagar.Text = _totalPagar : actxnTotalPagar.Formatear()





                        'If chkIlncluidoIGV.Checked Then
                        '   For Each Item As EVENT_DocsVentaDetalle In managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                        '      _importeTotal += Math.Round(Item.DOCVD_PrecioUnitarioPrecIncIGV * Item.DOCVD_Cantidad, 2)
                        '      _pesoTotal += Item.DOCVD_PesoUnitario * Item.DOCVD_Cantidad
                        '      _cantidad += Item.DOCVD_Cantidad
                        '   Next

                        '   Dim _total As Decimal = Math.Round(_importeTotal, 2, MidpointRounding.AwayFromZero)
                        '   Dim _importeIgv As Decimal = Math.Round(_total / (1 + ((_igv / 100))), 3, MidpointRounding.AwayFromZero)

                        '   actxnImporte.Text = Math.Round(_importeIgv, 2, MidpointRounding.AwayFromZero) : actxnImporte.Formatear()
                        '          actxnIGV.Text = _total - _importeIgv : actxnIGV.Formatear()
                        '   _totalPagar = _total
                        '   actxnTotalPagar.Text = _totalPagar : actxnTotalPagar.Formatear()

                        'Else
                        '          For Each Item As EVENT_DocsVentaDetalle In managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle

                        '              '_importeTotal += Math.Round(Item.DOCVD_PrecioUnitario * Item.DOCVD_Cantidad, 2, MidpointRounding.AwayFromZero)
                        '              _importeTotal += Item.DOCVD_PrecioUnitario * Item.DOCVD_Cantidad
                        '              _pesoTotal += Item.DOCVD_PesoUnitario * Item.DOCVD_Cantidad
                        '              _cantidad += Item.DOCVD_Cantidad
                        '          Next

                        '          Dim _total As Decimal = Math.Round(_importeTotal, 2, MidpointRounding.AwayFromZero) '--Math.Round(_importeTotal * ((_igv / 100) + 1), 2, MidpointRounding.AwayFromZero)
                        '          'Dim _total As Decimal = _importeTotal * ((_igv / 100) + 1)
                        '   Dim _importeIgv As Decimal = Math.Round(_total - _importeTotal, 2, MidpointRounding.AwayFromZero)

                        '   actxnImporte.Text = Math.Round(_importeTotal, 2, MidpointRounding.AwayFromZero) : actxnImporte.Formatear()
                        '   actxnIGV.Text = _importeIgv : actxnIGV.Formatear()
                        '          _totalPagar = _total

                        ' 'modificado para dos decimales
                        '  Dim _Decimal As Decimal = Mid(_total - Fix(_total),2, 3) 'Esto nos devolverá: 0.6
                        '  _totalPagar=Fix(_total) + _Decimal
                        '  ''''
                        '          'actxnTotalPagar.Text = Format$(_totalPagar, "#.00")': actxnTotalPagar.Formatear()
                        '          actxnTotalPagar.Text = _totalPagar : actxnTotalPagar.Formatear()
                        '   tslblSon.Text = String.Format("Son: {0}", ACUtilitarios.NumPalabra(_totalPagar, cmbMoneda.Text))
                        'End If
                        tslblSon.Text = String.Format("Son: {0}", ACUtilitarios.NumPalabra(_totalPagar, cmbMoneda.Text))
                        Dim _existe As Boolean
                        '   If _totalPagar >= Convert.ToDecimal(Parametros.GetParametro("pg_PreLimBoleta", _existe)) Then
                        'MessageBox.Show(Convert.ToDecimal(Parametros.GetParametro("pg_PreLimBoleta", _existe)))
                        txtNotaPie.Text = Parametros.GetParametro("pg_FacDetCtaCte", _existe)
                        ' Else
                        ' txtNotaPie.Text = ""
                        'End If
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

#Region "Cargar Combobox para Direcciones"

    'Private Function CargarCombosUbigeosOrigen()
    '    '' Cargar Ubigeos
    '    Dim m_listDep As New List(Of EUbigeos)
    '    For Each item As EUbigeos In Colecciones.Ubigeos
    '        If item.UBIGO_Codigo.Length = 2 And item.UBIGO_Codigo <> "00" Then
    '            m_listDep.Add(item.Clone())
    '        End If
    '    Next
    '    ''''Departamentos
    '    bs_departamento_origen = New BindingSource()
    '    bs_departamento_origen.DataSource = m_listDep
    '    ACFramework.ACUtilitarios.ACCargaCombo(cmbOrigenDepartamento, bs_departamento_origen, "UBIGO_Descripcion", "UBIGO_Codigo")
    '    AddHandler bs_departamento_origen.CurrentChanged, AddressOf bs_departamento_Origen_CurrentChanged
    '    bs_departamento_Origen_CurrentChanged(Nothing, Nothing)
    'End Function
    'Private Function CargarCombosUbigeosDestino()
    '    '' Cargar Ubigeos
    '    Dim m_listDep As New List(Of EUbigeos)
    '    For Each item As EUbigeos In Colecciones.Ubigeos
    '        If item.UBIGO_Codigo.Length = 2 And item.UBIGO_Codigo <> "00" Then
    '            m_listDep.Add(item.Clone())
    '        End If
    '    Next
    '    ''''Departamentos
    '    bs_departamento_destino = New BindingSource()
    '    bs_departamento_destino.DataSource = m_listDep
    '    ACFramework.ACUtilitarios.ACCargaCombo(cmbDestinoDepartamento, bs_departamento_destino, "UBIGO_Descripcion", "UBIGO_Codigo")
    '    AddHandler bs_departamento_destino.CurrentChanged, AddressOf bs_departamento_Destino_CurrentChanged
    '    bs_departamento_Destino_CurrentChanged(Nothing, Nothing)
    'End Function

    Private Sub bd_direcciones_Origen_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not IsNothing(bd_direcciones_origen) Then

                If actxtDireccionOrigen.Text = CType(bd_direcciones_origen.Current, EDirecciones).DIREC_Id Then
                    ' actxaCodDirDestino.Text = actxtDireccionOrigen.SelectedValue --> descomentar
                    'm_ubigeodestino = CType(bd_direcciones_origen.Current, EDirecciones).UBIGO_Codigo
                    If IsNothing(CType(bd_direcciones_origen.Current, EDirecciones).UBIGO_Codigo) Then

                    Else
                        m_ubigeodestino = CType(bd_direcciones_origen.Current, EDirecciones).UBIGO_Codigo
                    End If
                Else
                    '  actxaCodDirDestino.Text = -1
                End If



            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso cambiar direccion", ex)
        End Try
    End Sub

    Private Sub bd_direcciones_Destino_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not IsNothing(bd_direcciones_destino) Then

                If actxtDireccionDestino.Text = CType(bd_direcciones_destino.Current, EDirecciones).DIREC_Id Then
                    ' actxaCodDirDestino.Text = actxtDireccionOrigen.SelectedValue --> descomentar
                    'm_ubigeodestino = CType(bd_direcciones_origen.Current, EDirecciones).UBIGO_Codigo
                    If IsNothing(CType(bd_direcciones_destino.Current, EDirecciones).UBIGO_Codigo) Then

                    Else
                        m_ubigeodestino = CType(bd_direcciones_destino.Current, EDirecciones).UBIGO_Codigo
                    End If
                Else
                    '  actxaCodDirDestino.Text = -1
                End If



            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso cambiar direccion", ex)
        End Try
    End Sub

    'Private Sub bs_provincia_Origen_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim _filter As New ACFiltrador(Of EUbigeos)(String.Format("UBIGO_CodPadre={0}", CType(bs_provincia_origen.Current, EUbigeos).UBIGO_Codigo))
    '        bs_distrito_origen = New BindingSource
    '        bs_distrito_origen.DataSource = _filter.ACFiltrar(Colecciones.Ubigeos)
    '        ACFramework.ACUtilitarios.ACCargaCombo(cmbOrigenDistrito, bs_distrito_origen, "UBIGO_Descripcion", "UBIGO_Codigo")

    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
    '    End Try
    'End Sub
    'Private Sub bs_provincia_Destino_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim _filter As New ACFiltrador(Of EUbigeos)(String.Format("UBIGO_CodPadre={0}", CType(bs_provincia_destino.Current, EUbigeos).UBIGO_Codigo))
    '        bs_distrito_destino = New BindingSource
    '        bs_distrito_destino.DataSource = _filter.ACFiltrar(Colecciones.Ubigeos)
    '        ACFramework.ACUtilitarios.ACCargaCombo(cmbDestinoDistrito, bs_distrito_destino, "UBIGO_Descripcion", "UBIGO_Codigo")

    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
    '    End Try
    'End Sub


    'Private Sub bs_departamento_Origen_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try

    '        Dim _filter As New ACFiltrador(Of EUbigeos)(String.Format("UBIGO_CodPadre={0}", CType(bs_departamento_origen.Current, EUbigeos).UBIGO_Codigo))
    '        bs_provincia_origen = New BindingSource
    '        bs_provincia_origen.DataSource = _filter.ACFiltrar(Colecciones.Ubigeos)
    '        ACFramework.ACUtilitarios.ACCargaCombo(cmbOrigenProvincia, bs_provincia_origen, "UBIGO_Descripcion", "UBIGO_Codigo")
    '        AddHandler bs_provincia_origen.CurrentChanged, AddressOf bs_provincia_Origen_CurrentChanged
    '        bs_provincia_Origen_CurrentChanged(Nothing, Nothing)

    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
    '    End Try
    'End Sub
    'Private Sub bs_departamento_Destino_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try

    '        Dim _filter As New ACFiltrador(Of EUbigeos)(String.Format("UBIGO_CodPadre={0}", CType(bs_departamento_destino.Current, EUbigeos).UBIGO_Codigo))
    '        bs_provincia_destino = New BindingSource
    '        bs_provincia_destino.DataSource = _filter.ACFiltrar(Colecciones.Ubigeos)
    '        ACFramework.ACUtilitarios.ACCargaCombo(cmbDestinoProvincia, bs_provincia_destino, "UBIGO_Descripcion", "UBIGO_Codigo")
    '        AddHandler bs_provincia_destino.CurrentChanged, AddressOf bs_provincia_Destino_CurrentChanged
    '        bs_provincia_Destino_CurrentChanged(Nothing, Nothing)

    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
    '    End Try
    'End Sub



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

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            If rbtnCliente.Checked Then
                txtBusqueda_ACAyudaClick(Nothing, Nothing)
            ElseIf rbtnNroCotizacion.Checked Then
                txtBusNumero_ACAyudaClick(Nothing, Nothing)
            End If
            If m_tinicio = TInicio.Normal Then
                acTool.ACBtnEliminarVisible = m_elifacturas
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
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso seleccionar tipo de consulta", ex)
        End Try
    End Sub

    Private Sub c1grdBusqueda_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdBusqueda.DoubleClick
        If actsbtnPrevisualizar.Enabled Then
            actsbtnPrevisualizar_Click(Nothing, Nothing)
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

    Private Sub tsbtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub acbtnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acbtnSeleccionar.Click
        Try
            If IsNothing(managerGenerarDocsVenta.VENT_DocsVenta) Then managerGenerarDocsVenta.VENT_DocsVenta = CType(bs_documentos.Current, EVENT_DocsVenta)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error al Seleccionar Factura", ex)
        End Try
    End Sub

    Private Sub actxaFlete_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaFlete.ACAyudaClick
        Try
            Dim _frm As New CFletes("", CFletes.TAyuda.RazonSocial) With {.StartPosition = FormStartPosition.CenterScreen}
            If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                actxaFlete.Text = _frm.TRAN_Fletes.FLETE_Id
                'asignamos  datos del Flete a Para los ubigeos 



                spcCabecera.Panel2Collapsed = False
                spcDetalle.Panel2Collapsed = False

                '' Cargar los detalles del flete
                Dim _join As New List(Of ACJoin)
                _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner,
                                     New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")},
                                     New ACCampos() {New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
                _join.Add(New ACJoin(ETRAN_Rutas.Esquema, ETRAN_Rutas.Tabla, "Rut", ACJoin.TipoJoin.Inner,
                                     New ACCampos() {New ACCampos("RUTAS_Id", "RUTAS_Id")},
                                     New ACCampos() {New ACCampos("RUTAS_Nombre", "RUTAS_Nombre")}))
                Dim _where As New Hashtable()
                _where.Add("FLETE_Id", New ACWhere(_frm.TRAN_Fletes.FLETE_Id))
                If managerFletes.Cargar(_join, _where) Then
                    actxaCliRuc.Text = managerFletes.TRAN_Fletes.ENTID_Codigo

                    'Asignamos los Ubigeos del Flete a los Textbox no visibles para luego --> asignarlos al Documento de factura 
                    txtphantom_ubigo_origen.Text = managerFletes.TRAN_Fletes.Ubigo_CodOrigen
                    txtphantom_ubigo_destino.Text = managerFletes.TRAN_Fletes.Ubigo_CodDestino
                    txtphantom_rutas_nombre.Text = managerFletes.TRAN_Fletes.RUTAS_Nombre
                    txtphantom_RUTAS_ID.Text = managerFletes.TRAN_Fletes.RUTAS_Id

                    actxtDireccionOrigen.Text = managerFletes.TRAN_Fletes.FLETE_DireccionPuntoOrigen
                    actxtDireccionDestino.Text = managerFletes.TRAN_Fletes.FLETE_DireccionPuntoDestino
                    txtVEHIC_Certificado.Text = managerFletes.TRAN_Fletes.VEHIC_Certificado
                    actxaCotiz.Text = managerFletes.TRAN_Fletes.COTIZ_Codigo


                    txtProdUnidad.Text = "T.M."
                    If managerFletes.TRAN_Fletes.FLETE_ImporteIgv = 0 Then
                        actxnPrecio.Text = Math.Round(managerFletes.TRAN_Fletes.FLETE_MontoPorTM / (Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100 + 1), 4)
                    Else
                        actxnPrecio.Text = managerFletes.TRAN_Fletes.FLETE_MontoPorTM
                    End If

                    actxnPrecio_LostFocus(Nothing, Nothing)

                    cmbMoneda.SelectedValue = managerFletes.TRAN_Fletes.TIPOS_CodTipoMoneda
                    cmbEntrega.SelectedIndex = 0
                    actxnProdCantidad.Text = managerFletes.TRAN_Fletes.FLETE_PesoEnTM
                    txtProdUnidad.Text = "T.M."
                    actxnValorReferencial.Text = managerFletes.TRAN_Fletes.FLETE_TotalValorReferencial
                    actxnPrecio.Text = managerFletes.TRAN_Fletes.FLETE_MontoPorTM
                    actxnPrecio_LostFocus(Nothing, Nothing)
                    'managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_UBIGOCodigoOrigen = managerFletes.TRAN_Fletes.Ubigo_CodOrigen
                    'managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_UBIGOCodigoDestino = managerFletes.TRAN_Fletes.Ubigo_CodDestino

                    setCliente()

                    Dim _filter As New ACFiltrador(Of ETRAN_ViajesVentas)(String.Format("FLETE_Id={0}", managerFletes.TRAN_Fletes.FLETE_Id))
                    If Not _filter.ACFiltrar(managerGenerarDocsVenta.ListTRAN_ViajesVentas).Count > 0 Then
                        Dim _cfletes As New ETRAN_ViajesVentas
                        _cfletes.FLETE_Id = managerFletes.TRAN_Fletes.FLETE_Id
                        _cfletes.FLETE_Glosa = managerFletes.TRAN_Fletes.FLETE_Glosa
                        _cfletes.VIAJE_Id = managerFletes.TRAN_Fletes.VIAJE_Id
                        _cfletes.VIAJE_Descripcion = _frm.TRAN_Fletes.VIAJE_Descripcion
                        _cfletes.ENTID_RazonSocial = _frm.TRAN_Fletes.ENTID_RazonSocial
                        _cfletes.FLETE_TotIngreso = managerFletes.TRAN_Fletes.FLETE_TotIngreso
                        _cfletes.FLETE_PesoEnTM = managerFletes.TRAN_Fletes.FLETE_PesoEnTM
                        _cfletes.TIPOS_TipoMoneda = _frm.TRAN_Fletes.TIPOS_TipoMoneda
                        _cfletes.TIPOS_CodTipoMoneda = managerFletes.TRAN_Fletes.TIPOS_CodTipoMoneda
                        _cfletes.ENTID_NroDocumento = managerFletes.TRAN_Fletes.ENTID_NroDocumento
                        _cfletes.FLETE_TotalValorReferencial = managerFletes.TRAN_Fletes.FLETE_TotalValorReferencial

                        managerGenerarDocsVenta.ListTRAN_ViajesVentas.Add(_cfletes)
                    End If
                    bs_viajesventas.ResetBindings(False)
                    pnlItem.Enabled = True
                    '' Cargar los Guias por Fletes
                    CargarGuias()


                    '================================================================comenta esto si no lo quieres=====================
                    'txtProdDescripcion.Text = String.Format("{1}{0}{0}{2}{0}{0}Ruta: {3}{0}V.R.: {4}", vbNewLine, managerFletes.TRAN_Fletes.FLETE_Glosa,
                    '                                   txtTexto.Text.Trim(), managerFletes.TRAN_Fletes.RUTAS_Nombre, managerFletes.TRAN_Fletes.FLETE_TotalValorReferencial).ToUpper()

                    txtProdDescripcion.Text = String.Format("{1}{0}{0}{2}{0}{0}Ruta: {3}{0}", vbNewLine, managerFletes.TRAN_Fletes.FLETE_Glosa,
                                              txtTexto.Text.Trim(), managerFletes.TRAN_Fletes.RUTAS_Nombre).ToUpper()
                    '     txtProdDescripcion.Text = String.Format("{1}{0}{0}{2}{0}{0}Ruta: {3}", managerFletes.TRAN_Fletes.FLETE_Glosa,
                    'txtTexto.Text.Trim(), managerFletes.TRAN_Fletes.RUTAS_Nombre).ToUpper()

                    '===================================================CREADOR FRANK ================================QUITAR EL ORDENAMIENTO 
                    'txtProdDescripcion.Text = String.Format("{0}{1}{1}{2}{3}{4}", managerFletes.TRAN_Fletes.FLETE_Glosa,
                    ' txtTexto.Text.Trim(), Environment.NewLine, "Ruta: ", managerFletes.TRAN_Fletes.RUTAS_Nombre).ToUpper()



                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar Flete"), ex)
        End Try
    End Sub

    Private Sub tsbtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGenerar.Click
        Try
            Dim _cadena As String = ""
            Dim _serie As String = ""
            If CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).ListETRAN_ViajesGuiasRemision.Count > 0 Then
                _serie = CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).ListETRAN_ViajesGuiasRemision(0).Serie
                _cadena = String.Format("Guia(s) de {0}: {1}-", CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).Empresa, _serie)
                Dim i As Integer = 0
                For Each item As ETRAN_ViajesGuiasRemision In CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).ListETRAN_ViajesGuiasRemision
                    If item.Seleccion Then
                        If _serie = item.Serie Then
                            If i = 0 Then
                                _cadena &= String.Format("{0},", item.Numero_text)
                            Else
                                _cadena &= String.Format(" {0},", item.Numero_text)
                            End If
                            i += 1
                        Else
                            _serie = item.Serie
                            _cadena &= String.Format(" {0}-{1}", _serie, item.Numero_text)
                        End If
                    End If
                Next
                txtTexto.Text = _cadena.Substring(0, _cadena.Length - 1) & "."
            Else
                txtTexto.Text = ""
            End If

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Generar Texto Glosa"), ex)
        End Try
    End Sub

    Private Sub tsbtnAddFletes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAddFletes.Click
        Try
            If IsNothing(_frmViajes) Then _frmViajes = New CViajes With {.WindowState = FormWindowState.Normal, .StartPosition = FormStartPosition.CenterScreen}
            If _frmViajes.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Dim _join As New List(Of ACJoin)
                _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner,
                                     New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")},
                                     New ACCampos() {New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
                _join.Add(New ACJoin(ETRAN_Rutas.Esquema, ETRAN_Rutas.Tabla, "Rut", ACJoin.TipoJoin.Inner,
                                     New ACCampos() {New ACCampos("RUTAS_Id", "RUTAS_Id")},
                                     New ACCampos() {New ACCampos("RUTAS_Nombre", "RUTAS_Nombre")}))
                Dim _where As New Hashtable()
                _where.Add("FLETE_Id", New ACWhere(_frmViajes.TRAN_Viajes.ListTRAN_Fletes(0).FLETE_Id))
                If managerFletes.Cargar(_join, _where) Then
                    ' actxaCliRuc.Text = managerFletes.TRAN_Fletes.ENTID_NroDocumento



                    txtProdUnidad.Text = "T.M."
                    If managerFletes.TRAN_Fletes.FLETE_ImporteIgv = 0 Then
                        actxnPrecio.Text = Math.Round(managerFletes.TRAN_Fletes.FLETE_MontoPorTM / (Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100 + 1), 4)
                    Else
                        actxnPrecio.Text = managerFletes.TRAN_Fletes.FLETE_MontoPorTM
                    End If

                    actxnPrecio_LostFocus(Nothing, Nothing)
                    'cmbMoneda.SelectedValue = managerFletes.TRAN_Fletes.TIPOS_CodTipoMoneda
                    'cmbEntrega.SelectedIndex = 0
                    actxnProdCantidad.Text = managerFletes.TRAN_Fletes.FLETE_PesoEnTM
                    txtProdUnidad.Text = "T.M."
                    actxnPrecio.Text = managerFletes.TRAN_Fletes.FLETE_MontoPorTM
                    actxnPrecio_LostFocus(Nothing, Nothing)

                    For Each item As ETRAN_Fletes In _frmViajes.TRAN_Viajes.ListTRAN_Fletes
                        Dim _filter As New ACFiltrador(Of ETRAN_ViajesVentas)(String.Format("FLETE_Id={0}", item.FLETE_Id))
                        If Not _filter.ACFiltrar(managerGenerarDocsVenta.ListTRAN_ViajesVentas).Count > 0 Then
                            Dim _cfletes As New ETRAN_ViajesVentas
                            _cfletes.VIAJE_Id = item.VIAJE_Id
                            _cfletes.FLETE_Id = item.FLETE_Id
                            _cfletes.ENTID_RazonSocial = item.ENTID_RazonSocial
                            _cfletes.FLETE_Glosa = item.FLETE_Glosa
                            _cfletes.FLETE_TotIngreso = item.FLETE_TotIngreso
                            _cfletes.FLETE_PesoEnTM = item.FLETE_PesoEnTM
                            _cfletes.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                            _cfletes.TIPOS_TipoMoneda = item.TIPOS_TipoMoneda
                            _cfletes.VIAJE_Descripcion = _frmViajes.TRAN_Viajes.VIAJE_Descripcion
                            _cfletes.ENTID_NroDocumento = item.ENTID_NroDocumento
                            _cfletes.FLETE_TotalValorReferencial = managerFletes.TRAN_Fletes.FLETE_TotalValorReferencial
                            managerGenerarDocsVenta.ListTRAN_ViajesVentas.Add(_cfletes)
                        End If
                    Next


                    '' Cargar los Guias por Fletes
                    CargarGuias()

                    'txtProdDescripcion.Text = String.Format("{1}{0}{0}{2}{0}{0}Ruta: {3}{0}V.R.: {4}", vbNewLine, managerFletes.TRAN_Fletes.FLETE_Glosa, _
                    '                                           txtTexto.Text.Trim(), managerFletes.TRAN_Fletes.RUTAS_Nombre, managerFletes.TRAN_Fletes.FLETE_TotalValorReferencial).ToUpper()
                    txtProdDescripcion.Text = String.Format("{1}{0}{0}{2}{0}{0}Ruta: {3}{0}", vbNewLine, managerFletes.TRAN_Fletes.FLETE_Glosa,
                                                              txtTexto.Text.Trim(), managerFletes.TRAN_Fletes.RUTAS_Nombre).ToUpper()


                    bs_viajesventas.ResetBindings(False)
                    c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 2, "Total")
                    c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 4, "Total")
                    c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, c1grdFletes.Cols("FLETE_TotIngreso").Index, "Total")
                    If managerGenerarDocsVenta.ListTRAN_ViajesVentas.Count = 1 Then
                        'managerTRAN_Cotizaciones.TRAN_Cotizaciones.FLETE_Id = _frmViajes.TRAN_Viajes.ListTRAN_Fletes(0).FLETE_Id
                        'managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id = _frmViajes.TRAN_Viajes.ListTRAN_Fletes(0).RUTAS_Id
                        'actxaFlete.Text = _frmViajes.TRAN_Viajes.ListTRAN_Fletes(0).FLETE_Id
                    End If
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Seleccionar Viaje/Flete"), ex)
        End Try
    End Sub

    Private Sub tsbtnQuitarFletes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnQuitarFletes.Click
        Try
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Registro: {0}", Me.Text) _
                         , String.Format("Desea eliminar el registro del Flete: {0}", CType(bs_viajesventas.Current, ETRAN_CotizacionesFletes).FLETE_Id) _
                         , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletesLiberados.Add(CType(bs_viajesventas.Current, ETRAN_CotizacionesFletes).Clone)
                managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes.Remove(CType(bs_viajesventas.Current, ETRAN_CotizacionesFletes))
                bs_viajesventas.ResetBindings(False)
                c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 2, "Total")
                c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 4, "Total")
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Quitar Fletes"), ex)
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
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Documento de Venta: {0}", Me.Text) _
                , String.Format("Desea anular el documento: {0}", CType(bs_documentos.Current, EVENT_DocsVenta).Documento) _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                Dim _cotizacion As String = ""
                ' Dim form_anulacion As New TMotivo_anulacion() 'FORMULARIO PARA ANULACION 
                Dim form_anulacion As New TMotivo_anulacion(TMotivo_anulacion.TDocumento.Factura) With {.StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Normal}
                If form_anulacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim _motivo As String = String.Format("Usuario: {1} {0} - Fecha: {2:dd/MM/yyyy HH:mm} {0} Motivo: {3} {0} Equipo: {4}-{5}",
                                                            vbNewLine, GApp.EUsuario.USER_CodUsr, DateTime.Now,
                                                            form_anulacion.Motivo, GApp.BaseDatos, GApp.Servidor)
                    'ENTRA PARA CONFIRMACION
                    If Not IsNothing(managerGenerarDocsVenta.TRAN_Cotizaciones) Then _cotizacion = managerGenerarDocsVenta.TRAN_Cotizaciones.COTIZ_Codigo

                    'managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_MotivoAnulacion = _motivo
                    'Falt Pasar parametros para darle el motivo de anulacion a ANular Documento
                    If managerGenerarDocsVenta.AnularDocumento(CType(bs_documentos.Current, EVENT_DocsVenta), _cotizacion, GApp.Usuario, _motivo) Then
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

    Private Sub acTool_ACBtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnEliminar_Click
        Try

            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Registro: {0}", Me.Text) _
                         , String.Format("Desea Eliminar el registro del Documento de Venta: {0}", CType(bs_documentos.Current, EVENT_DocsVenta).Documento) _
                         , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                If managerGenerarDocsVenta.EliminarDocumento(CType(bs_documentos.Current, EVENT_DocsVenta), GApp.Usuario) Then
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Eliminado satisfactoriamente")
                    btnConsultar_Click(Nothing, Nothing)
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
                        Dim x_numero As Integer = actxnNumeroFacturar.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.ZONAS_Codigo = GApp.Zona
                        managerGenerarDocsVenta.VENT_DocsVenta.SUCUR_Id = GApp.Sucursal
                        'managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagado = actxnTotalPagar.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento = cmbDocumentoFacturar.SelectedValue
                        managerGenerarDocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = cmbCondicionPago.SelectedValue
                        managerGenerarDocsVenta.VENT_DocsVenta.PVENT_Id = GApp.PuntoVenta
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_EstEntrega = cmbEntrega.SelectedValue
                        managerGenerarDocsVenta.VENT_DocsVenta.ENTID_RazonSocial = actxaCliRazonSocial.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.ENTID_CodigoVendedor = GApp.EUsuarioEntidad.ENTID_Codigo
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente = cmbDirecciones.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PorcentajeIGV = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalVenta = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_TotalPagar
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_AfectoDetraccion = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_AfectoDetraccion
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PorcentajeDetraccion = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PorcentajeDetraccion
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_ImporteDetraccion = managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_ImporteDetraccion
                        Dim x_valor_ref As Decimal = Decimal.Round(x_valor_REFERENCIAL, 2) 'SE PUSO ESTO PARA EVITAR QUE SE AUMENTEN 2 CEROS AL FUNAL 
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Referencia = x_valor_ref
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Observaciones = txtObservaciones.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_ValorReferencial = x_valor_ref
                        managerGenerarDocsVenta.VENT_DocsVenta.UBIGO_CodigoOrigen = txtphantom_ubigo_origen.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.UBIGO_CodigoDestino = txtphantom_ubigo_destino.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_RutasDescripcion = txtphantom_rutas_nombre.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_RUTASId = txtphantom_RUTAS_ID.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionPuntoOrigen = actxtDireccionOrigen.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_DireccionPuntoDestino = actxtDireccionDestino.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.COTIZ_Codigo = actxaCotiz.Text

                        '' Plazo de Pago
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_PlazoFecha = dtpFecPlazo.Value
                        managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Plazo = actxnPlazo.Text
                        managerGenerarDocsVenta.VENT_DocsVenta.VEHIC_Certificado = txtVEHIC_Certificado.Text

                        '' Generar documento de Venta
                        If managerGenerarDocsVenta.generarDocumento(GApp.Usuario, actxaCotiz.Text, dtpFecFacturacion.Value,
                                                                    CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_Serie, x_numero, cmbEntrega.SelectedValue, m_msg, x_bauditoria) Then
                            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Imprimir Documento de Venta: {0}", Me.Text) _
                                   , String.Format("Documento {0} con el numero {1}-{2} Grabado satisfactoriamente, desea Imprimir el Documento", cmbDocumentoFacturar.Text, cmbSerieFacturar.Text, actxnNumeroFacturar.Text.PadLeft(7, "0")) _
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
                                    'If _print.Print_FacturaTransportista(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo, managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie,chkspot.Checked) Then
                                    '   ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Impreso satisfactoriamente", cmbDocumentoFacturar.Text, cmbSerieFacturar.Text, actxnNumeroFacturar.Text.PadLeft(7, "0")), m_msg)
                                    'Else
                                  

                                    If _print.Print_FacturaTermica(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo, managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie,
                                                                   chkspot.Checked,
                                                                     PrintDocument1,
                                                        CType(cmbSerieFacturar.SelectedItem, EVENT_PVentDocumento).PVDOCU_NroLineas) Then
                                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Impreso satisfactoriamente", cmbDocumentoFacturar.Text, cmbSerieFacturar.Text, actxnNumeroFacturar.Text.PadLeft(7, "0")), m_msg)

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
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Imprimir Factura: {0}", Me.Text) _
                , String.Format("Desea imprimir la Factura ") _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                Dim _print As New Impresion(tscmbImpresora.Text)
                'Dim x_docve_codigo As String = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Codigo
                'Dim x_serie As String = CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Serie
                'If _print.Print_FacturaTransportista(x_docve_codigo, x_serie,chkspot.Checked) Then
                '   ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento {0} con el numero {1}-{2} Impreso satisfactoriamente", cmbDocumentoFacturar.Text, cmbSerieFacturar.Text, actxnNumeroFacturar.Text.PadLeft(7, "0")))
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

                'funcion imprimir no lo usa
                '_print.ImpresionFrank(managerGenerarDocsVenta.VENT_DocsVenta,"Microsoft Print to PDF")

                'If _print.Print_FacturaFrank(managerGenerarDocsVenta.VENT_DocsVenta ) Then

                If _print.Print_FacturaTermica(managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Codigo, managerGenerarDocsVenta.VENT_DocsVenta.DOCVE_Serie,
                                                                     chkspot.Checked,
                                                                    PrintDocument1,
                                                          CType(cmbSerieFacturar.SelectedItem, EVENT_PVentDocumento).PVDOCU_NroLineas) Then
                   ' MessageBox.Show("Se Imprimio Correctamente")
                    'COMENTADO FRANK PARA PRUEBAS EL 05-11-2025 ===>  
                   ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Impreso satisfactoriamente")
                End If
            End If 
                'End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Imprimir Guia", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnNuevo_Click
        Try
            nueva()
            '' Activar las opciones generales del teclado
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
            Select Case e.KeyChar
                Case "+"c
                    If m_modArticulo Then
                        e.Handled = True
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Cantidad = actxnProdCantidad.Text
                        CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_Unidad = txtProdUnidad.Text

                        Dim _igv As Decimal = 1 + (Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100)
                        If chkIlncluidoIGV.Checked Then
                            CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitarioPrecIncIGV = actxnPrecio.Text
                            CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitario = Math.Round(CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitarioPrecIncIGV / _igv, 4, MidpointRounding.AwayFromZero)
                            c1grdDetalle.Cols("DOCVD_PrecioUnitario").Visible = False
                            c1grdDetalle.Cols("DOCVD_PrecioUnitarioPrecIncIGV").Visible = True
                        Else
                            CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitarioPrecIncIGV = 0
                            CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle).DOCVD_PrecioUnitario = actxnPrecio.Text
                            c1grdDetalle.Cols("DOCVD_PrecioUnitario").Visible = True
                            c1grdDetalle.Cols("DOCVD_PrecioUnitarioPrecIncIGV").Visible = False
                        End If

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

    Private Sub actxaCotiz_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCotiz.ACAyudaClick
        Dim frmAyuda As New PCotizacionesFletes(PCotizacionesFletes.Inicio.Busqueda)
        If frmAyuda.ShowDialog = Windows.Forms.DialogResult.OK Then
            setCotizToFactura(frmAyuda.TRAN_Cotizaciones.COTIZ_Codigo)
            actxaCotiz.Text = frmAyuda.TRAN_Cotizaciones.COTIZ_Codigo
            pnlItem.Enabled = False
            grpFlete.Enabled = True
            actxaFlete.Enabled = False
            Label14.Enabled = False
            tstFletes.Enabled = False
            cmbDocumentoFacturar.Focus()
            c1grdDetalle.AutoSizeRows()
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 2, "Total")
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 3, "Total")
            KeyPreview = True
            spcCabecera.Panel2Collapsed = False
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
                        '' Plazo de pago   Credito 15 dias 
                        Dim diasPlazo As Integer = CInt(CType(bs_condicionpago.Current, ETipos).TIPOS_Numero)

                        'actxnPlazo.Text = CInt(CType(bs_condicionpago.Current, ETipos).TIPOS_Numero) 'managerEntidades.Cliente.CLIEN_PlazoCredito
                        actxnPlazo.Text = diasPlazo.ToString()


                        Dim fechaActual As DateTime = DateTime.Now
                        Dim fechaPlazo As DateTime = fechaActual.AddDays(diasPlazo)

                        ' dtpFecPlazo.Value = DateTime.Now.AddDays(managerEntidades.Cliente.CLIEN_PlazoCredito)
                        dtpFecPlazo.Value = fechaPlazo 'ESTO SERIA LA FECHA DE PLAZO QUE APLICARIAMOS 

                    Else
                        'si es al Contado entonces la FechaPlazo es el Dia de HOy ()
                        cmbCondicionPago.SelectedValue = ETipos.getCondicionPago(ETipos.TipoPago.Contado)
                        'cmbCondicionPago.Enabled = m_pmcondpago
                        '' Plazo de pago
                        actxnPlazo.Text = 0
                        dtpFecPlazo.Value = DateTime.Now
                    End If
                Else
                    'Comentado Frank 
                    If CType(cmbCondicionPago.SelectedItem, ETipos).TIPOS_Numero > 0 Then
                        ' MsgBox("El Cliente no tiene el credito")
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "El cliente" + managerEntidades.Cliente.ENTID_Codigo + " No tiene  Acceso al Credito")

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

            ACControles.ACDialogos.ACMostrarMensajeInformacion("Falta Datos ", "Aviso", "El sistema no pudo encontrar datos de Credito en Clientes o Simplemente no Existe en Clientes")

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
#End Region

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim tipo As String
        'str As String
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
        Dim ypieesp As Double = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts1 + ts5 + 2)


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

    'aca esta comprobando si EL DETRACCCION ESTA MARCADO O NO TRUE O FALSE 
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


    Private Sub cmbCondicionPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCondicionPago.SelectedIndexChanged

    End Sub

    Private Sub PFacturacionFletes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub acTool_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles acTool.ItemClicked

    End Sub

    Private Sub actsbtn_CapturaPantalla_Click(sender As Object, e As EventArgs) Handles actsbtn_CapturaPantalla.Click
        'AL PRESIONAR ESTE BOTON SE TOMARA UN CAPTURA DE PANTALLA DE LO QUE HAYA 
        Dim FechaActual As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim NombreFoto As String = "Captura"

        Try

            Dim userFolderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 'Especificamos La Ubicacion para  


            ' Crear una ruta completa para el archivo de captura de pantalla
            Dim screenshotPath As String = Path.Combine(userFolderPath, Environment.MachineName + NombreFoto & "_" & FechaActual & ".png") 'Cambiar 


            ' Tomar una captura de pantalla
            Dim screenshot As Image = ScreenCapture.CaptureScreen()

            ' Guardar la captura de pantalla en la carpeta personal del usuario
            screenshot.Save(screenshotPath, Imaging.ImageFormat.Png)
            screenshot.Dispose() 'esot es para liberar memoria

            ' Mostrar un mensaje de éxito
            MessageBox.Show("Captura de pantalla guardada en " & screenshotPath, "Captura de pantalla",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Class ScreenCapture 'Se crea una Clase Aparte solo Para almacenar la Imagen 
        Public Shared Function CaptureScreen() As Image 'Esta sera un functuion public  
            Dim screenSize As Size = Screen.PrimaryScreen.Bounds.Size
            Dim screenshot As New Bitmap(screenSize.Width, screenSize.Height, Imaging.PixelFormat.Format32bppArgb)

            Using g As Graphics = Graphics.FromImage(screenshot)
                g.CopyFromScreen(0, 0, 0, 0, screenSize)
            End Using

            Return screenshot
        End Function
    End Class

    Private Sub chkEditarFactura_Click(sender As Object, e As EventArgs) Handles chkEditarFactura.Click
        'Permite Modificar Direccion de Punto Origen y Punto Llegada  desde La Cotizacion 

        If (actxaCotiz.Text <> "") Then

            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Edicion de Direcciones: {0}", Me.Text) _
                                , String.Format("Deseas Modificar el Punto de Origen o Llegada de la Cotizacion  ?", actxaCotiz.Text) _
                                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then


                Dim form_cotizaciones As New FCotizaciones(TInicioCotizacion.Editar, actxaCotiz.Text) With {.StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}

                form_cotizaciones.Show()
                Me.Close()
            Else



            End If



        Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion("Informacion", "No Hay Cotizacion Amarrada en Esta Factura")

        End If




    End Sub



    'Private Sub cmbDestinoDistrito_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    'AL MOMENTO DE HACER CLICK ESTO TIENE QUE CARGAR UBIGEOS 
    '    If cmbDestinoDepartamento.SelectedIndex <> -1 AndAlso cmbDestinoProvincia.SelectedIndex <> -1 AndAlso cmbDestinoDistrito.SelectedIndex <> -1 Then
    '        ' Concatenar los valores y asignarlos al TextBox
    '        actxtDireccionDestino.Text = Nothing
    '        actxtDireccionDestino.Text = m_vauldirecciondestino + " / " + cmbDestinoDepartamento.Text & " / " & cmbDestinoProvincia.Text & " / " & cmbDestinoDistrito.Text
    '    End If


    'End Sub

    'Private Sub cmbOrigenDistrito_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    'alm momento de hacer click carga y reemplza los ubigeos 
    '    If cmbOrigenDepartamento.SelectedIndex <> -1 AndAlso cmbOrigenProvincia.SelectedIndex <> -1 AndAlso cmbOrigenDistrito.SelectedIndex <> -1 Then
    '        ' Concatenar los valores y asignarlos al TextBox
    '        actxtDireccionOrigen.Text = Nothing
    '        actxtDireccionOrigen.Text = m_vauldireccionorigen + " / " + cmbOrigenDepartamento.Text & " / " & cmbOrigenProvincia.Text & " / " & cmbOrigenDistrito.Text
    '    End If


    'End Sub
End Class