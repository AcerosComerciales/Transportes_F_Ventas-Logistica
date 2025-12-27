Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1
Imports C1.Win.C1FlexGrid
Imports ACBVentas
Imports ACEVentas

Public Class MVehiculosMantenimiento
#Region " Variables "
    Private managerTRAN_Vehiculos As BTRAN_Vehiculos
    Private managerTRAN_VehiculosMantenimiento As BTRAN_VehiculosMantenimiento
    Private managerTRAN_VehiculosMantenimientoDetalle As BTRAN_VehiculosMantenimientoDetalle 'Creado frank para Detalles 
    Private managerETRAN_VehiculosMantenimientoDetalle As ETRAN_VehiculosMantenimientoDetalle
    Private managerETRAN_EVehiculosMantenimiento As ETRAN_VehiculosMantenimiento
    Private managerETRAN_VehiculosMantenimiendo As ETRAN_VehiculosMantenimiento
    Private managerTRAN_VehiculosMatenimientoDocCompra As BTRAN_VehiculosMantenimientoDocCompra 'Compra amarrado a VehiculoMantenimiento
    Private managerETRAN_VehiculosMatenimientoDocCompra As BTRAN_VehiculosMantenimientoDocCompra
    Private managerEntidades As BEntidades

    Private m_listBindHelper As List(Of ACBindHelper)
    Private m_listBindHelper2 As List(Of ACBindHelper)
    Private bs_btran_vehiculos As BindingSource
    Private bs_btran_mantenimiento_vehiculos As BindingSource
    Private bs_btran_documentos_detalle As BindingSource
    Private bs_piezas As BindingSource
    Private bs_facturas As BindingSource
    Private m_opcion As TMante

    'Nuevas Variables 
    '   Private managerEntidades As BEntidades
    Private managerTRAN_Documentos As BTRAN_Documentos
    Private managerBTRAN_DocumentosDetalles As BTRAN_DocumentosDetalle 'DocumentoDetalles
    Private managerETRAN_DocumentosDetalles As ETRAN_DocumentosDetalle
    Private managerETRAN_Documentos As ETRAN_Documentos

    Private bs_tipodocumento As BindingSource
    Private bs_moneda As BindingSource

    Private bs_documentos As BindingSource
    Private bs_documentosdetalle As BindingSource
    '   Private m_listBindHelper As List(Of ACBindHelper)

    Private m_modArticulo As Boolean = False
    Private m_tran_piezas As ETRAN_Piezas
    ' Dim contador_detalle_mantenimiento As Integer = 0
    Dim _numero_correlativo_documento As Integer = 0
    Private x_eliminar As Boolean = False
    Private lockedTab As TabPage 'Variable para Bloquear un tab 
    Enum TMante
        Nuevo
        Modificar
        Eliminar
    End Enum


    Enum TPiezas
        Codigo = 0
        Nombre = 1
    End Enum

    Enum TInicio
        Normal
        Busqueda
    End Enum
    Public ReadOnly Property TRAN_Documentos() As ETRAN_Documentos
        Get
            Return managerTRAN_Documentos.TRAN_Documentos
        End Get
    End Property

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
    Public Sub New(Optional ByVal x_opcion As TMante = TMante.Nuevo)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            m_opcion = x_opcion
            managerTRAN_Documentos = New BTRAN_Documentos
            managerEntidades = New BEntidades

            Select Case m_opcion
                Case TMante.Nuevo
                    'setInstanciaPermisos(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo) 'Creado Frank
                    acTool.ACBtnModificarVisible = False
                    AcFecha.Visible = False
                    '=============================INSTANCIA DE LOS EVENTOS DE LOS PRECIOS POR CADA PRODUCTO=============================================================================
                    AddHandler actxnPrecIGV.LostFocus, AddressOf actxnProdCantidad_LostFocus
                    AddHandler actxnProdCantidad.LostFocus, AddressOf actxnProdCantidad_LostFocus
                    AddHandler actxnDescuento.LostFocus, AddressOf actxnProdCantidad_LostFocus
                    AddHandler actxnPrecio.LostFocus, AddressOf actxnPrecio_LostFocus
                    AddHandler chkPrecIGV.LostFocus, AddressOf actxnPrecio_LostFocus

                    AddHandler c1grdDetalle_piezas.KeyDown, AddressOf c1grdDetalle_KeyDown

                    ACFramework.ACUtilitarios.ACLimpiaVar(pnlCabecera)
                    ACFramework.ACUtilitarios.ACLimpiaVar(pnlItem)
                    ACFramework.ACUtilitarios.ACLimpiaVar(pnlPie)
                    tabMantenimiento.SelectedTab = tabDatos
                    '===================================================================================================================================================================
                Case TMante.Modificar
                    '   setInstanciaPermisos(ACFramework.ACUtilitarios.ACSetInstancia.Modificado) 'Creado Frank
                    acTool.ACBtnModificarVisible = True
                    acTool.ACBtnNuevo.Enabled = False
                    acTool.ACBtnNuevoVisible = False
                    AcFecha.Visible = True
                    '=========================================INSTANCIA DE OBJETOS AL MODIFICAR ===================================
                    pnlItem.Enabled = True
                    c1grdDetalle_piezas.Focus()
                    acpnlTitulo.ACCaption = "Modificacion de Mantenimiento de Vehiculos"

                    ' actsbtnSeleccionar.Visible = True
                    'actsbtnSeleccionar.Visible = False
                    '==============================================================================================================
                Case Else
                    '=============================caso de nada =========================================================================
                    '===================================================================================================================
            End Select
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda
            formatearGrilla()
            cargarCombos()
            managerTRAN_Vehiculos = New BTRAN_Vehiculos
            managerTRAN_VehiculosMantenimiento = New BTRAN_VehiculosMantenimiento
            managerEntidades = New BEntidades
            acTool.ACBtnNuevoEnabled = False
            'acTool.ACBtnEliminar.Enabled = False ---DESABILITADO BOTON DE ELIMINAR FRANK 
            acTool.ACBtnModificar.Enabled = False
            txtVehicPlaca.ReadOnly = True
            txtVehiDescripcion.ReadOnly = True
            Me.KeyPreview = True
            spcBase.Panel2Collapsed = True
            'Parametros para los controles 
            chkPrecIGV.Enabled = False
            acTool.ACBtnSalirVisible = True
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

#End Region

#Region "Metodos Permiso"


    Private Sub setInstanciaPermisos(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)
        Try
            'acTool.ACBtnRehusarVisible = False
            'acTool.ACBtnImprimirVisible = False
            'acTool.ACBtnImprimirEnabled = False
            acTool.ACBtnEliminarVisible = False
            'acTool.ACBtnAnular.Visible = False

            Select Case _opcion 'ESTO SE USA MAS ADELANTE PARA CUANDO SE PASA UNA INSTANCIA DE NUEVO ETC FRANK 
                Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
                    ' chkIlncluidoIGV.Enabled = True
                Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
                    Dim _validate As ACSeguridad.ACValidarUsuario
                    _validate = New ACSeguridad.ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACSeguridad.ACValidarUsuario.Operacion.ValidarVariosProcesos)
                    For Each item As ACSeguridad.EProcesos In _validate.ListProcesos 'Itera el Permiso para dar Propiedades a cada Boton de un Grupo frank
                        Select Case item.PROC_Codigo
                            Case Procesos.getProceso(Procesos.TipoProcesos.Mantenimiento_EliminarMantenimiento)
                                x_eliminar = True
                                acTool.ACBtnEliminarVisible = True
                        End Select
                    Next
                Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

                Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

                Case ACFramework.ACUtilitarios.ACSetInstancia.Previsualizar

            End Select


            '  acTool.ACBtnModificarVisible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Metodos "
#Region " Utilitarios "

    Private Sub formatearGrilla()
        Dim index As Integer = 1
        Try
            Select Case m_opcion
                Case TMante.Nuevo
                    ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 7, 1, 0)
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "VEHIC_Codigo", "VEHIC_Codigo", 150, True, False, "System.String", "") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String", "") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Marca", "TIPOS_Marca", "TIPOS_Marca", 150, True, False, "System.String", "") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Modelo", "VEHIC_Modelo", "VEHIC_Modelo", 150, True, False, "System.String", "") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Vehiculo", "TIPOS_Vehiculo", "TIPOS_Vehiculo", 150, True, False, "System.String", "") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Adq.", "VEHIC_FecAdquisicion", "VEHIC_FecAdquisicion", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
                Case TMante.Modificar
                    ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 7, 1, 0)
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cod. Mant.", "VMAN_Id", "VMAN_Id", 150, True, False, "System.String", "") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "VMAN_FecRealizacion", "VMAN_FecRealizacion", 150, True, False, "System.Datetime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String", "") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "K.M.", "VMAN_Km", "VMAN_Km", 150, True, False, "System.String", "") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Responsable", "ENTID_Responsable", "ENTID_Responsable", 150, True, False, "System.String", "") : index += 1
                    ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Proveedor", "ENTID_Proveedor", "ENTID_Proveedor", 150, True, False, "System.String", "") : index += 1
            End Select

            c1grdBusqueda.AllowEditing = False
            c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
            c1grdBusqueda.SelectionMode = SelectionModeEnum.Row

            index = 1

            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle_piezas, 1, 1, 6, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle_piezas, index, "Codigo", "PIEZA_Codigo", "PIEZA_Codigo", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle_piezas, index, "Nombre", "PIEZA_Descripcion", "PIEZA_Descripcion", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle_piezas, index, "Tipo Repuesto", "TIPOS_TipoRepuesto", "TIPOS_TipoRepuesto", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle_piezas, index, "Cantidad", "VMDET_Cantidad", "VMDET_Cantidad", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle_piezas, index, "Responsable", "VMDET_Responsable", "VMDET_Responsable", 150, True, False, "System.String") : index += 1

            c1grdDetalle_piezas.AllowEditing = False
            c1grdDetalle_piezas.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdDetalle_piezas.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdDetalle_piezas.Styles.Highlight.BackColor = Color.Gray
            c1grdDetalle_piezas.SelectionMode = SelectionModeEnum.Row

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdFacturas, 1, 1, 6, 1, 1)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Fecha", "DOCUS_Fecha", "DOCUS_Fecha", 150, True, False, "System.DateTime") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "RUC", "ENTID_Codigo", "ENTID_Codigo", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Razon Social", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFacturas, index, "Total", "DOCUS_TotalPago", "DOCUS_TotalPago", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1

            c1grdFacturas.AllowEditing = False
            c1grdFacturas.Styles.Alternate.BackColor = Color.LightGray
            c1grdFacturas.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdFacturas.Styles.Highlight.BackColor = Color.Gray
            c1grdFacturas.SelectionMode = SelectionModeEnum.Row
            c1grdFacturas.AllowSorting = AllowSortingEnum.SingleColumn
            c1grdFacturas.AllowResizing = AllowResizingEnum.Columns

            Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdFacturas.Styles.Add("Facturado")
            t.BackColor = Color.LightGreen
            t.ForeColor = Color.DarkBlue
            t.Font = New Font(c1grdFacturas.Font, FontStyle.Regular)

            Dim t1 As C1.Win.C1FlexGrid.CellStyle = c1grdFacturas.Styles.Add("Rehuzado")
            t1.BackColor = Color.LightSalmon
            t1.ForeColor = Color.DarkBlue
            t1.Font = New Font(c1grdFacturas.Font, FontStyle.Regular)

            Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdFacturas.Styles.Add("Facturar")
            u.BackColor = Color.Green
            u.ForeColor = Color.White
            u.Font = New Font(c1grdFacturas.Font, FontStyle.Regular)

            Dim d As C1.Win.C1FlexGrid.CellStyle = c1grdFacturas.Styles.Add("Anulado")
            d.BackColor = Color.Red
            d.ForeColor = Color.White
            d.Font = New Font(c1grdFacturas.Font, FontStyle.Bold)
            c1grdFacturas.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

            'Formateando el GRID _ DETALLES _Al ingreso de los Items 
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Item", "DCDET_Item", "DCDET_Item", 110, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Codigo", "PIEZA_Id", "PIEZA_Id", 110, True, False, "System.Integer") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Cantidad", "DCDET_Cantidad", "DCDET_Cantidad", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Descripción", "DCDET_Descripcion", "DCDET_Descripcion", 90, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Precio", "DCDET_Importe", "DCDET_Importe", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Sub-Importe", "DCDET_SubImporte", "DCDET_SubImporte", 100, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1


            c1grdDetalle.AllowEditing = False
            c1grdDetalle.AutoResize = True
            c1grdDetalle.Cols(0).Width = 18
            c1grdDetalle.Styles.Alternate.BackColor = Color.LightGray
            c1grdDetalle.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdDetalle.Styles.Highlight.BackColor = Color.Gray
            c1grdDetalle.SelectionMode = SelectionModeEnum.Row
            c1grdDetalle.AllowResizing = AllowResizingEnum.None


        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
        End Try
    End Sub

    Private Sub cargarCombos()
        Try
            ACFramework.ACUtilitarios.ACCargaCombo(cmbManTipoMantenimiento, Colecciones.Tipos(ETipos.MyTipos.TipoMantenimiento), "TIPOS_Descripcion", "TIPOS_Codigo")
            bs_tipodocumento = New BindingSource
            bs_tipodocumento.DataSource = Colecciones.TiposDocCompFacturacion()
            ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, bs_tipodocumento, "TIPOS_Descripcion", "TIPOS_Codigo")
            '' Moneda
            bs_moneda = New BindingSource() : bs_moneda.DataSource = Colecciones.Tipos(ETipos.MyTipos.TipoMoneda)
            ACFramework.ACUtilitarios.ACCargaCombo(cmbMoneda, bs_moneda, "TIPOS_DescCorta", "TIPOS_Codigo")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '============EVENTO CREADO PARA QUE BUSQUE SOLO SIN NECEDIDAD DE UN BOTON =======================================================================================
    'Private Sub btnConsultar_Click()
    '    Try
    '        bs_documentos = New BindingSource
    '        If managerTRAN_Documentos.TRAN_ObtenerDocumentosCompra(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date, GApp.PuntoVenta, 1, txtBusqueda.Text, True) Then 'chkTodos.Checked  = true se cambio 
    '            managerTRAN_Documentos.ListTRAN_Documentos = New List(Of ACETransporte.ETRAN_Documentos)
    '        End If
    '        bs_documentos.DataSource = managerTRAN_Documentos.ListTRAN_Documentos
    '        c1grdBusqueda.DataSource = bs_documentos
    '        bnavBusqueda.BindingSource = bs_documentos

    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Buscando Documentos"), ex)
    '    End Try
    'End Sub
    '==============================================================================================
    Private Sub HabilitacionControls(flag As Boolean)
        'actxaCodResponsable.Enabled = flag

    End Sub

    Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)

        Select Case _opcion
            Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
                'Estos eventos son Para Que luego de grabar se le asigne evento de calculos con el Tab 
                'a los inputs de precio y cantidad 
                AddHandler actxnPrecIGV.LostFocus, AddressOf actxnProdCantidad_LostFocus
                AddHandler actxnProdCantidad.LostFocus, AddressOf actxnProdCantidad_LostFocus
                AddHandler actxnDescuento.LostFocus, AddressOf actxnProdCantidad_LostFocus
                AddHandler actxnPrecio.LostFocus, AddressOf actxnPrecio_LostFocus
                AddHandler chkPrecIGV.LostFocus, AddressOf actxnPrecio_LostFocus

                AddHandler c1grdDetalle.KeyDown, AddressOf c1grdDetalle_KeyDown
                ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
                ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
              '  contador_detalle_mantenimiento = 0
             'txtCodigo.Enabled = False
            Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
                ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            'txtCodigo.Enabled = False
            Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar
                txtBusqueda.Focus()

                tabMantenimiento.SelectedTab = tabBusqueda
            Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer
                tabMantenimiento.SelectedTab = tabBusqueda
                'contador_detalle_mantenimiento = 0
                'actsbtnSeleccionar.Visible = True
                acTool.ACBtnImprimirVisible = False
                acTool.ACBtnAnularVisible = False
                acTool.ACBtnRehusarVisible = False

                c1grdDetalle.Enabled = True

                Me.KeyPreview = False
                RemoveHandler actxnPrecIGV.LostFocus, AddressOf actxnProdCantidad_LostFocus
                RemoveHandler actxnProdCantidad.LostFocus, AddressOf actxnProdCantidad_LostFocus
                RemoveHandler actxnDescuento.LostFocus, AddressOf actxnProdCantidad_LostFocus
                RemoveHandler actxnPrecio.LostFocus, AddressOf actxnPrecio_LostFocus
                RemoveHandler chkPrecIGV.LostFocus, AddressOf actxnPrecio_LostFocus

                RemoveHandler c1grdDetalle.KeyDown, AddressOf c1grdDetalle_KeyDown
            Case ACFramework.ACUtilitarios.ACSetInstancia.Previsualizar
        End Select

    End Sub
#End Region

#Region " Cargar Datos "
    ' <summary>
    ' Cargar los datos en el control Visual C1FlexGrid
    ' </summary>
    Private Sub cargarDatos()
        Try
            bs_btran_vehiculos = New BindingSource()

            Select Case m_opcion
                Case TMante.Nuevo
                    bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos

                Case TMante.Modificar
                    bs_btran_vehiculos.DataSource = managerTRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimiento
                Case Else

            End Select


            c1grdBusqueda.DataSource = bs_btran_vehiculos
            bnavBusqueda.BindingSource = bs_btran_vehiculos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' <summary>
    ' Realiza el enlace de los controles visuales con la clase esquema
    ' </summary>
    Private Sub AsignarBinding()
        Try
            m_listBindHelper = New List(Of ACBindHelper)()
            m_listBindHelper2 = New List(Of ACBindHelper)()
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbManTipoMantenimiento, "SelectedValue", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "TIPOS_CodTipoMantenimiento"))
            If managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.VMAN_FecRealizacion.Year < 1700 Then managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.VMAN_FecRealizacion = DateTime.Now
            m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecMantenimiento, "Value", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "VMAN_FecRealizacion"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtManObservacion, "Text", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "VMAN_Observaciones"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnManKilometraje, "Text", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "VMAN_Km"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxaNroDocProveedor, "Text", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "ENTID_Codigo"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(actxaCodResponsable, "Text", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "ENTID_CodigoResponsable"))
            ' no se usa --- > m_listBindHelper.Add(ACBindHelper.ACBind(txt, "Text", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "ENTID_CodigoResponsable"))
            '==================================Datos si es que se lleva Documentos=====================================================================================================================================================================================
            '  m_listBindHelper2.Add(ACBindHelper.ACBind(actxaNroDocProveedor, "Text", managerTRAN_Documentos.TRAN_Documentos, "ENTID_Codigo")) 'Comentado frank 
            'm_listBindHelper2.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", managerTRAN_Documentos.TRAN_Documentos, "TIPOS_CodTipoMoneda"))
            'm_listBindHelper2.Add(ACBindHelper.ACBind(cmbDocumento, "SelectedValue", managerTRAN_Documentos.TRAN_Documentos, "TIPOS_CodTipoDocumento"))
            'm_listBindHelper2.Add(ACBindHelper.ACBind(txtSerie, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_Serie"))
            'm_listBindHelper2.Add(ACBindHelper.ACBind(actxnNumero, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_Numero"))
            'm_listBindHelper2.Add(ACBindHelper.ACBind(actxnImporte, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_Importe"))
            'm_listBindHelper2.Add(ACBindHelper.ACBind(actxnIGV, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_ImporteIGV"))
            'm_listBindHelper2.Add(ACBindHelper.ACBind(actxnTotalPagar, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_TotalPago"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(actxaNroDocProveedor, "Text", managerTRAN_Documentos.TRAN_Documentos, "ENTID_Codigo"))
            'If managerTRAN_Documentos.TRAN_Documentos.DOCUS_Fecha.Year < 1700 Then managerTRAN_Documentos.TRAN_Documentos.DOCUS_Fecha = DateTime.Now
            'm_listBindHelper2.Add(ACBindHelper.ACBind(dtpFecEmision, "Value", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_Fecha"))
            'If managerTRAN_Documentos.TRAN_Documentos.DOCUS_FechaIngreso.Year < 1700 Then managerTRAN_Documentos.TRAN_Documentos.DOCUS_FechaIngreso = DateTime.Now
            'm_listBindHelper2.Add(ACBindHelper.ACBind(dtpFecIngreso, "Value", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_FechaIngreso"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '========Funcion Nueva Instancia ============================================================================================

    '============================================================================================================================
    Private Sub cargar()
        Try
            '========Funcion Para Cargar los datos ya sea modificado o no  ============================================================================================

            '============================================================================================================================
            If bs_btran_vehiculos.Current IsNot Nothing Then
                Dim x_codigo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_VehiculosMantenimiento).VMAN_Id
                If managerTRAN_VehiculosMantenimiento.Cargar(x_codigo) Then
                    AsignarBinding()
                    managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.Instanciar(ACEInstancia.Modificado)
                    actxaDescProveedor.Text = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ENTID_Proveedor
                    txtVehicPlaca.Text = CType(bs_btran_vehiculos.Current, ETRAN_VehiculosMantenimiento).VEHIC_Placa
                    txtVehiDescripcion.Text = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.VEHIC_Modelo

                    'actxaNomResponsable.Text = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ENTID_Responsable
                    tabMantenimiento.SelectedTab = tabDatos

                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)

                    bs_piezas = New BindingSource
                    bs_piezas.DataSource = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle
                    c1grdDetalle_piezas.DataSource = bs_piezas
                    bnavDetalle.BindingSource = bs_piezas

                    bs_facturas = New BindingSource
                    bs_facturas.DataSource = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos
                    Dim x_docus_codigo As String = CType(bs_facturas.Current, ETRAN_Documentos).DOCUS_Codigo
                    Dim x_entid_codigo As String = CType(bs_facturas.Current, ETRAN_Documentos).ENTID_Codigo

                    bs_documentosdetalle = New BindingSource
                    c1grdFacturas.DataSource = bs_facturas
                    bnavFacturas.BindingSource = bs_facturas
                    managerBTRAN_DocumentosDetalles = New BTRAN_DocumentosDetalle
                    If managerBTRAN_DocumentosDetalles.TRAN_VMAN_ObtenerMantenimientosDocumentos_Detalle(x_docus_codigo, x_entid_codigo) Then
                        bs_documentosdetalle.DataSource = managerBTRAN_DocumentosDetalles.ListTRAN_DocumentosDetalle
                    End If
                Else
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar ")
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                End If
            End If
        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
            Throw ex
        End Try
    End Sub
    'Funcion averiguar para que es  pdd .frank 
    Private Function getOpcion() As Integer
        If rbtnCodigo.Checked Then
            Return 1
        ElseIf rbtnPlaca.Checked Then
            Return 0
        Else
            Return 0
        End If
    End Function

    ' <summary>
    ' Ejecutar la busqueda de una cadena en la tabla Neumaticos
    ' </summary>
    ' <param name="x_cadena">Cadena objetivo</param>
    ' <returns></returns>
    Private Function busqueda(ByVal x_cadena As String) As Boolean
        Try
            Select Case m_opcion
                Case TMante.Nuevo
                    If managerTRAN_Vehiculos.Busqueda(getCampo(), x_cadena) Then
                        acTool.ACBtnNuevoEnabled = True
                        acTool.ACBtnEliminar.Enabled = True
                        acTool.ACBtnModificar.Enabled = True
                    Else
                        acTool.ACBtnNuevoEnabled = False
                        acTool.ACBtnEliminar.Enabled = False
                        acTool.ACBtnModificar.Enabled = False
                    End If
                    'Comentado por Frank error en GetOpcion()
                Case TMante.Modificar
                    If managerTRAN_VehiculosMantenimiento.TRAN_VMAN_ObtenerMantenimientos(AcFecha.ACFecha_De.Value.Date, AcFecha.ACFecha_A.Value.Date, getOpcion(), x_cadena, False) Then
                        acTool.ACBtnModificarVisible = True
                        acTool.ACBtnModificar.Enabled = True

                    Else
                        acTool.ACBtnModificarVisible = False
                        acTool.ACBtnModificar.Enabled = False

                    End If
                    bs_btran_mantenimiento_vehiculos = New BindingSource
                    bs_btran_mantenimiento_vehiculos.DataSource = managerTRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimiento

                    'Detalles de los Mantenimientos 


                Case Else
                    'Nada   
            End Select
            cargarDatos()
            '  cargar()
            'bs_btran_documentos_detalle = New BindingSource()
            ' bs_btran_documentos_detalle.DataSource = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle


            Return acTool.ACBtnNuevoEnabled
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
        End Try
        Return False
    End Function

#End Region

    Private Function getCampoModificar() As String
        Try
            If (rbtnCodigo.Checked) Then
                Return "VEHIC_Id"
            ElseIf rbtnPlaca.Checked Then
                Return "VEHIC_Placa"
            Else
                Return "VEHIC_Placa"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getCampo() As Short
        Try
            If (rbtnCodigo.Checked) Then
                Return 0
            ElseIf rbtnPlaca.Checked Then
                Return 1
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
        Try
            Select Case x_opcion
                Case EEntidades.TipoEntidad.Proveedores
                    Dim _where As New Hashtable
                    _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
                    If managerEntidades.Ayuda(_where, x_opcion) Then
                        Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Proveedor", managerEntidades.DTEntidades, False)
                        If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            '' Cargar datos del cliente
                            actxaNroDocProveedor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                            actxaDescProveedor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                            actxaNroDocProveedor_2.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                            AcTextBoxAyuda1.Text = Ayuda.Respuesta.Rows(0)("Razon Social")

                        End If
                    Else
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
                    End If
                Case EEntidades.TipoEntidad.Usuarios
                    Dim _where As New Hashtable
                    _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
                    If managerEntidades.Ayuda(_where, x_opcion) Then
                        Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Usuario", managerEntidades.DTEntidades, False)
                        If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            '' Cargar datos del cliente
                            'actxaCodResponsable.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                            'actxaNomResponsable.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                        End If
                    Else
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
                    End If
                Case Else
                    Dim _where As New Hashtable
                    _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
                    If managerEntidades.Ayuda(_where, x_opcion) Then
                        Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Usuario", managerEntidades.DTEntidades, False)
                        If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            '' Cargar datos del cliente
                            '  actxaCodResponsable.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                            ' actxaNomResponsable.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                        End If
                    Else
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NuevaEntidad(ByVal x_entid_nrodocumento As String, ByVal x_tipoentidad As EEntidades.TipoEntidad)
        Try
            Dim frmEntidad As New MEntidad(MEntidad.Inicio.NuevaEntidad, x_tipoentidad)
            frmEntidad.StartPosition = FormStartPosition.CenterScreen
            If x_entid_nrodocumento.Length > 0 Then
                frmEntidad.EEntidad.ENTID_NroDocumento = x_entid_nrodocumento
                frmEntidad.lblNombres.Focus()
            End If
            If frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Select Case x_tipoentidad
                    Case EEntidades.TipoEntidad.Proveedores
                        If managerEntidades.Cargar(frmEntidad.EEntidad.ENTID_Codigo, EEntidades.TipoInicializacion.Direcciones) Then
                            actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                            actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                        End If
                End Select
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
        End Try
    End Sub
#End Region

#Region " Metodos de Controles"

#Region " Tool Bar "
    Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnRehusar_Click, acTool.ACBtnNuevo_Click
        Try
            'creamos nueovs parametros 
            KeyPreview = True
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)

            managerTRAN_Documentos.TRAN_Documentos = New ETRAN_Documentos
            managerTRAN_Documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)
            managerTRAN_Documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle = New List(Of ETRAN_DocumentosDetalle)
            'setInstancia(ACPTransportes.Nuevo)
            bs_documentosdetalle = New BindingSource
            bs_documentosdetalle.DataSource = managerTRAN_Documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle

            c1grdDetalle.DataSource = bs_documentosdetalle
            bnavProductos.BindingSource = bs_documentosdetalle
            '===========================================================================
            tabMantenimiento.SelectedTab = tabDatos


            managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento = New ETRAN_VehiculosMantenimiento()
            managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.VEHIC_Id = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
            managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle = New List(Of ETRAN_VehiculosMantenimientoDetalle)
            managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos = New List(Of ETRAN_Documentos)

            txtVehicPlaca.Text = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Placa
            txtVehiDescripcion.Text = String.Format("{0} / {1}", CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Certificado, CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).TIPOS_Marca)

            bs_piezas = New BindingSource
            bs_piezas.DataSource = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle
            c1grdDetalle_piezas.DataSource = bs_piezas
            bnavDetalle.BindingSource = bs_piezas

            bs_facturas = New BindingSource
            bs_facturas.DataSource = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos
            c1grdFacturas.DataSource = bs_facturas
            bnavFacturas.BindingSource = bs_facturas

            'TabControl1.SelectedTab = tpgFacturas
            TabControl1.SelectedTab = IngresoFac
            managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.Instanciar(ACEInstancia.Nuevo)


            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
            AsignarBinding()
        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Mantenimiento de Vehiculo", ex)
        End Try
    End Sub
    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs)
        ' Si el TabPage que se intenta seleccionar es el bloqueado, cancela la selección
        If e.TabPage Is lockedTab Then
            e.Cancel = True
            ' ACControles.ACDialogos.ACMostrarMensajeInformacion("Espera..", "La Ventana se Encuentra Bloqueada  :)")
            MessageBox.Show("Esta pestaña está bloqueada.")
        End If
    End Sub

    Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
        Try
            tabMantenimiento.SelectedTab = tabBusqueda
            If (TMante.Modificar) Then
                acTool.ACBtnNuevoVisible = False
            End If


            For Each Item As ACBindHelper In m_listBindHelper
                Item.ACUnBind()
            Next
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Mantenimiento de Vehiculo", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnModificar_Click
        Try
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
            cargar()
            'Cuando ya cargue 
            'If managerTRAN_VehiculosMantenimiento.TRAN_VMAN_ObtenerMantenimientos_Detalle(CType(bs_btran_mantenimiento_vehiculos.Current, ETRAN_VehiculosMantenimiento).VEHIC_Id, CType(bs_btran_mantenimiento_vehiculos.Current, ETRAN_VehiculosMantenimiento).VMAN_Item, Nothing, 1) Then
            '    'MessageBox.Show("Encontro Detalles")
            '    'Este para los Detalles de la Cabecera

            'Else
            '    ACControles.ACDialogos.ACMostrarMensajeInformacion("No se Encontro Detalles", "No pudimos encontrar Detalles de ese Mantenimiento")
            'End If
            'If managerTRAN_VehiculosMantenimiento.TRAN_VMAN_ObtenerMantenimientosDocumentos_Detalle(CType(bs_facturas.Current, ETRAN_Documentos).DOCUS_Codigo) Then

            'End If
            setInstanciaPermisos(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
            tabMantenimiento.SelectedTab = tabDatos
            'Inicializamos el Tab de Mantenimeintso y Bloqueamos para que no se pueda entrar 
            TabControl1.SelectedTab = tpgFacturas
            lockedTab = TabControl1.TabPages(0)
            AddHandler TabControl1.Selecting, AddressOf TabControl1_Selecting

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar Mantenimiento de Vehiculo", ex)
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
        End Try
    End Sub

    Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
        Dim msg As String = ""
        Dim _msg As String = ""

        Try
            Select Case m_opcion
                Case TMante.Nuevo
                    Dim managerETRANDocumento As New ETRAN_Documentos
                    Dim managerETRAN_VehiculosMantenimiento As New ETRAN_VehiculosMantenimiento
                    '==========================================si Mant is Nuevo grabar 
                    If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then

                        If Validar(_msg) Then
                            '=============================CORRELATIVO=========================================================================================================
                            _numero_correlativo_documento = actxnNumero.Text

                            managerTRAN_Documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", cmbDocumento.SelectedValue.ToString.Substring(3, 2),
                                                                                    txtSerie.Text.ToString.PadLeft(4, "0"), _numero_correlativo_documento.ToString.PadLeft(7, "0"))
                            managerETRANDocumento.DOCUS_Codigo = String.Format("{0}{1}{2}", cmbDocumento.SelectedValue.ToString.Substring(3, 2),
                                                                                    txtSerie.Text.ToString.PadLeft(4, "0"), _numero_correlativo_documento.ToString.PadLeft(7, "0"))

                            '=============================CORRELATIVO managerETRAN_Documentos=========================================================================================================
                            'managerETRANDocumento.DOCUS_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Ingresado)
                            managerETRANDocumento.ENTID_Codigo = actxaNroDocProveedor.Text
                            ' managerETRANDocumento.PVENT_Id = GApp.PuntoVenta
                            '==================================================managerTRAN_Documentos ====================================================================================
                            managerTRAN_Documentos.TRAN_Documentos.PVENT_Id = GApp.PuntoVenta
                            managerTRAN_Documentos.TRAN_Documentos.ENTID_Codigo = actxaNroDocProveedor.Text
                            managerTRAN_Documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = Colecciones.Tipos(ETipos.MyTipos.TipoMoneda)(0).TIPOS_Codigo
                            managerTRAN_Documentos.TRAN_Documentos.TIPOS_CodTipoDocumento = Colecciones.Tipos(ETipos.MyTipos.TipoDocComprobante)(0).TIPOS_Codigo
                            managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ENTID_CodigoResponsable = GApp.DataUsuario.USER_DNI
                            managerTRAN_Documentos.TRAN_Documentos.DOCUS_Serie = _numero_correlativo_documento
                            managerTRAN_Documentos.TRAN_Documentos.DOCUS_Numero = actxnNumero.Text
                            managerTRAN_Documentos.TRAN_Documentos.DOCUS_Fecha = dtpFecEmision.Value
                            managerTRAN_Documentos.TRAN_Documentos.DOCUS_TotalPago = Convert.ToDecimal(actxnTotalPagar.Text)
                            managerTRAN_Documentos.TRAN_Documentos.DOCUS_Importe = Convert.ToDecimal(actxnImporte.Text)
                            managerTRAN_Documentos.TRAN_Documentos.DOCUS_ImporteIGV = Convert.ToDecimal(actxnIGV.Text)

                            managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos.Add(managerETRANDocumento)
                            managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.VMAN_Viaje = False

                            If managerTRAN_Documentos.Guardar(GApp.Usuario, True, True) Then
                                'ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                                tabMantenimiento.SelectedTab = tabBusqueda
                                ' acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                                'Grabando Documentos de Compra 
                                'If managerTRAN_VehiculosMatenimientoDocCompra.Guardar() Then

                                'End If
                                If managerTRAN_VehiculosMantenimiento.Guardar(GApp.Usuario, True) Then
                                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                                    setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)

                                End If

                            Else
                                Throw New Exception("No se completo el proceso de grabación")
                            End If

                        End If
                    Else
                        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar, por que hay campos obligatorios vacios: {0}", msg))
                    End If

                Case TMante.Modificar
                    Dim msg_ As String = ""
                    '   If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg_) = True Then
                    If managerTRAN_VehiculosMantenimiento.Guardar(GApp.Usuario, True) Then
                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                        tabMantenimiento.SelectedTab = tabBusqueda
                        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                    Else
                        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                        Throw New Exception("No se completo el proceso de grabación")

                    End If
                    ' Else

                    '    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar, por que hay campos obligatorios vacios: {0}", msg))
                    'End If

            End Select


            '===========================================si Mant is modificar =======================

        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
        End Try
    End Sub

    'Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
    '    Dim msg As String = ""
    '    Dim _msg As String = ""
    '    Dim managerETRANDocumento As New ETRAN_Documentos
    '    Dim managerETRAN_VehiculosMantenimiento As New ETRAN_VehiculosMantenimiento
    '    Try
    '        If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then

    '            If Validar(_msg) Then
    '                '=============================CORRELATIVO=========================================================================================================
    '                _numero_correlativo_documento = actxnNumero.Text

    '                managerTRAN_Documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", cmbDocumento.SelectedValue.ToString.Substring(3, 2),
    '                                                                            txtSerie.Text.ToString.PadLeft(5, "0"), _numero_correlativo_documento.ToString.PadLeft(2, "0"))
    '                managerETRANDocumento.DOCUS_Codigo = String.Format("{0}{1}{2}", cmbDocumento.SelectedValue.ToString.Substring(3, 2),
    '                                                                            txtSerie.Text.ToString.PadLeft(5, "0"), _numero_correlativo_documento.ToString.PadLeft(2, "0"))
    '                '=============================CORRELATIVO=========================================================================================================
    '                managerETRANDocumento.DOCUS_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Ingresado)
    '                managerETRANDocumento.ENTID_Codigo = actxaNroDocProveedor.Text
    '                managerETRANDocumento.PVENT_Id = GApp.PuntoVenta
    '                managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ENTID_CodigoResponsable = GApp.DataUsuario.USER_DNI
    '                managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos.Add(managerETRANDocumento)

    '                If managerTRAN_Documentos.Guardar(GApp.Usuario, True, True) Then
    '                    'ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
    '                    tabMantenimiento.SelectedTab = tabBusqueda
    '                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
    '                    'Grabando Documentos de Compra 
    '                    'If managerTRAN_VehiculosMatenimientoDocCompra.Guardar() Then

    '                    'End If

    '                    If managerTRAN_VehiculosMantenimiento.Guardar(GApp.Usuario, True) Then
    '                            ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
    '                        setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)

    '                    End If

    '                    Else
    '                        Throw New Exception("No se completo el proceso de grabación")
    '                End If

    '            End If
    '        Else
    '            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
    '            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar, por que hay campos obligatorios vacios: {0}", msg))
    '        End If
    '    Catch ex As Exception
    '        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
    '        ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
    '    End Try
    'End Sub

    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub

    Private Sub acTool_ACBtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnEliminar_Click
        Try

            'BOTON PARA ELIMINAR REGISTRO DE MANTENIMEINETOS
            If ACControles.ACDialogos.ACMostrarMensajePregunta(
                     String.Format("Eliminar Definitivamente el Registro: {0}", CType(bs_btran_vehiculos.Current, ETRAN_VehiculosMantenimiento).VEHIC_Placa),
                     "Registros Involucrados : Documentos , Mantenimiento + Detalle  ,  DocumentodeCompra + Detalles "
                 ) = DialogResult.OK Then

                managerTRAN_VehiculosMantenimientoDetalle = New BTRAN_VehiculosMantenimientoDetalle
                managerTRAN_VehiculosMantenimientoDetalle.ListTRAN_VehiculosMantenimientoDetalle = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle
                managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento = CType(bs_btran_vehiculos.Current, ETRAN_VehiculosMantenimiento)
                '========================================1 . Motivo Anulacion ====================================================
                Dim form_anulacion As New TMotivo_eliminacion(TMotivo_anulacion.TDocumento.Mantenimiento) With {.StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Normal}
                If form_anulacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    '======================================================almacenando motivo anulacion ====================================================
                    Dim _motivo As String = String.Format("Usuario: {1} {0} - Fecha: {2:dd/MM/yyyy HH:mm} {0} Motivo: {3} {0} Equipo: {4}-{5}",
                                                            vbNewLine, GApp.EUsuario.USER_CodUsr, DateTime.Now,
                                                            form_anulacion.Motivo, GApp.BaseDatos, GApp.Servidor)


                    ' ====================2.ANULANDO DOCUMENTO  + DETALLES = PARA QUE QUEDE REGISTRO DEL DOCUMENTO 
                    '======solo cabecera del Documento 
                    managerTRAN_Documentos = New BTRAN_Documentos
                    managerTRAN_Documentos.AnularDocumento(GApp.Usuario, CType(bs_facturas.Current, ETRAN_Documentos).DOCUS_Codigo, CType(bs_facturas.Current, ETRAN_Documentos).ENTID_Codigo, Date.Now(), _motivo)
                    'managerTRAN_Documentos.EliminarDocumento(CType(bs_facturas.Current, ETRAN_Documentos).DOCUS_Codigo, CType(bs_facturas.Current, ETRAN_Documentos).ENTID_Codigo, True)
                    If managerBTRAN_DocumentosDetalles.ListTRAN_DocumentosDetalle IsNot Nothing Then
                        If managerBTRAN_DocumentosDetalles.ListTRAN_DocumentosDetalle.Count > 0 Then
                            For Each item As ETRAN_DocumentosDetalle In managerBTRAN_DocumentosDetalles.ListTRAN_DocumentosDetalle
                                Dim managerETRAN_DocumentosDetalles As New ETRAN_DocumentosDetalle
                                Dim managerTRAN_DocumentosDetalles As New BTRAN_DocumentosDetalle()
                                ' Crear una nueva instancia de ETRAN_DocumentosDetalle asignarla a TRAN_DocumentosDetalle
                                managerTRAN_DocumentosDetalles.TRAN_DocumentosDetalle = New ETRAN_DocumentosDetalle With {
                                .DOCUS_Codigo = item.DOCUS_Codigo,
                                .ENTID_Codigo = item.ENTID_Codigo,
                                .DCDET_Item = item.DCDET_Item,
                                .DCDET_Estado = "X"
                            }
                                managerETRAN_DocumentosDetalles.Instanciar(ACEInstancia.Eliminado)
                                managerTRAN_DocumentosDetalles.Guardar(GApp.Usuario)
                            Next
                        End If
                    End If
                    '=============================3 .ELIMINANDO MANTENIMIENTO DETALLE (iteracion - detalles)==============================
                    ' Verificar si la lista tiene elementos
                    If managerTRAN_VehiculosMantenimientoDetalle.ListTRAN_VehiculosMantenimientoDetalle IsNot Nothing Then
                        If managerTRAN_VehiculosMantenimientoDetalle.ListTRAN_VehiculosMantenimientoDetalle.Count > 0 Then
                            For Each item As ETRAN_VehiculosMantenimientoDetalle In managerTRAN_VehiculosMantenimientoDetalle.ListTRAN_VehiculosMantenimientoDetalle
                                ' Aquí puedes realizar las operaciones necesarias con cada 'item'
                                Dim ManagerTRAN_VehiculosMantenimientoDetalle As New BTRAN_VehiculosMantenimientoDetalle
                                ManagerTRAN_VehiculosMantenimientoDetalle = New BTRAN_VehiculosMantenimientoDetalle
                                ' Inicializar la propiedad TRAN_VehiculosMantenimientoDetalle
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle = New ETRAN_VehiculosMantenimientoDetalle
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.DCDET_Item = item.DCDET_Item
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.DOCUS_Codigo = item.DOCUS_Codigo
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.ENTID_Codigo = item.ENTID_Codigo
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.PIEZA_Codigo = item.PIEZA_Codigo
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.PIEZA_Descripcion = item.PIEZA_Descripcion
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.PIEZA_Id = item.PIEZA_Id
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.TIPOS_CodTipoRepuesto = item.TIPOS_CodTipoRepuesto
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.TIPOS_TipoRepuesto = item.TIPOS_TipoRepuesto
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.VEHIC_Id = item.VEHIC_Id
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.VMAN_Item = item.VMAN_Item
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.VMDET_Cantidad = item.VMDET_Cantidad
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.VMDET_Estado = item.VMDET_Estado
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.VMDET_Item = item.VMDET_Item
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.VMDET_Procedimiento = item.VMDET_Procedimiento
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.VMDET_Responsable = item.VMDET_Responsable
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.VMDET_UsrCrea = item.VMDET_UsrCrea
                                ManagerTRAN_VehiculosMantenimientoDetalle.TRAN_VehiculosMantenimientoDetalle.Instanciar(ACEInstancia.Eliminado)
                                ManagerTRAN_VehiculosMantenimientoDetalle.Guardar(GApp.Usuario) 'Nota falta traer los detalles a la tabla para eliminar detalles
                            Next
                        Else
                            MessageBox.Show("La lista está inicializada pero está vacía.")
                        End If
                        '=====================================================DOSCCOMPRA ====================================================
                        For Each item As ETRAN_VehiculosMantenimientoDetalle In managerTRAN_VehiculosMantenimientoDetalle.ListTRAN_VehiculosMantenimientoDetalle
                            Dim ManagerBTRAN_VehiculosMatenimientoDocCompra As New BTRAN_VehiculosMantenimientoDocCompra
                            ManagerBTRAN_VehiculosMatenimientoDocCompra = New BTRAN_VehiculosMantenimientoDocCompra()
                            ''================Igualamos los mismo para Transportes.TRAN_VehiculosMantenimientoDocCompra (Esto no funciono pipip)===========================================
                            'ManagerBTRAN_VehiculosMatenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra = New ETRAN_VehiculosMantenimientoDocCompra
                            'ManagerBTRAN_VehiculosMatenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.VEHIC_Id = item.VEHIC_Id
                            'ManagerBTRAN_VehiculosMatenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.VMAN_Item = item.VMAN_Item
                            'ManagerBTRAN_VehiculosMatenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.DOCUS_Codigo = item.DOCUS_Codigo
                            '' ManagerBTRAN_VehiculosMatenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.VMDCO_Estado = "X"
                            ''4 .Eliminando Documento de Compra 
                            'ManagerBTRAN_VehiculosMatenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.Instanciar(ACEInstancia.Eliminado)
                            'ManagerBTRAN_VehiculosMatenimientoDocCompra.Guardar(GApp.Usuario)
                            ManagerBTRAN_VehiculosMatenimientoDocCompra.TRAN_VMAN_ObtenerMantenimientosDeleteDocCompra(item.VEHIC_Id, item.DOCUS_Codigo, item.VMAN_Item)
                            Exit For
                        Next
                        ' 5 .ELIMINADO MANTENIMIENTO CABECERA
                        managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.Instanciar(ACEInstancia.Eliminado)
                        managerTRAN_VehiculosMantenimiento.Guardar(GApp.Usuario, Date.Now())
                        'En total son 4 Documentos que se Amarran para La Eliminacion Total de estos
                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Convert.ToString(Me.Text)), "Eliminado satisfactoriamente")
                        busqueda(txtBusqueda.Text)
                        tabMantenimiento.SelectedTab = tabBusqueda
                    Else
                        ACControles.ACDialogos.ACMostrarMensajeInformacion("Espera...", "Tu Mantenimiento no Tiene Detalles o La Lista de Los Detalles esta VACIO ")
                    End If
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede Eliminar", ex)
        End Try
    End Sub
#End Region
    Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        'EVENTO PARA EL TAB PARA FORMULAR EL CALCULO CANTIDAD X PRECIO 
        If e.KeyCode = Keys.Enter Then
            If sender.Name = "txtBusqueda" Then
                Exit Sub
            End If
            If sender.Name = "acTool" Then
                Exit Sub
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
        Try
            busqueda(txtBusqueda.Text)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
        End Try
    End Sub

    Private Sub txtBusqueda_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBusqueda.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                busqueda(txtBusqueda.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub c1grdDetalle_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles c1grdBusqueda.MouseDoubleClick
        Try
            If e.X > c1grdBusqueda.Rows.Fixed Then
                Select Case m_opcion
                    Case TMante.Nuevo
                        acTool_ACBtnNuevo_Click(Nothing, Nothing)
                        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                    Case TMante.Modificar
                        acTool_ACBtnModificar_Click(Nothing, Nothing)
                        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                End Select
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar el registro seleccionado", ex)
        End Try
    End Sub

    Private Sub actxaProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocProveedor.ACAyudaClick
        Try
            AyudaEntidad(actxaNroDocProveedor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Proveedores)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Ayuda de Proveedores", ex)
        End Try
    End Sub

    Private Sub actxaRazonSocial_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescProveedor.ACAyudaClick
        Try
            AyudaEntidad(actxaDescProveedor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Proveedores)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Ayuda de Proveedores", ex)
        End Try
    End Sub
    '=====================================SE BORRO EL INPUT PARA EL Responsable porque jalamos de Gapp El Dni==================================
    'Private Sub actxaNomResponsable_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        AyudaEntidad(actxaNomResponsable.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Todos)
    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Ayuda de Usuarios", ex)
    '    End Try
    'End Sub
    'Private Sub actxaCodResponsable_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        AyudaEntidad(actxaCodResponsable.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Todos)
    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Ayuda de Usuarios", ex)
    '    End Try
    'End Sub

    'Private Sub actxaNroDocProveedor_2_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocProveedor.ACAyudaClick
    '    Try
    '        AyudaEntidad(actxaNroDocProveedor_2.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Proveedores)
    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
    '    End Try
    'End Sub

    Private Sub actxaNroDocProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocProveedor.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                If actxaNroDocProveedor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
                    '' Cargar datos adicionales cliente
                    If actxaNroDocProveedor.ACAyuda.Enabled = True Then
                        If managerEntidades.CargarDocIden(actxaNroDocProveedor.Text, EEntidades.TipoInicializacion.Direcciones) Then
                            actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                            actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                            actxaNroDocProveedor_2.Text = managerEntidades.Entidades.ENTID_NroDocumento
                            AcTextBoxAyuda1.Text = managerEntidades.Entidades.ENTID_RazonSocial

                            'Label2.Focus()
                        Else
                            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                     , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaNroDocProveedor.Text) _
                                     , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                                NuevaEntidad(actxaNroDocProveedor.Text, EEntidades.TipoEntidad.Proveedores)
                            Else
                                actxaNroDocProveedor.Clear()
                                actxaDescProveedor.Clear()
                                lblProveedor.Focus()
                            End If
                        End If
                    End If
                Else
                    If actxaNroDocProveedor.Text.Trim().Length > 0 Then
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocProveedor.Text))
                        actxaNroDocProveedor.Clear()
                        actxaDescProveedor.Clear()
                        lblProveedor.Focus()
                    End If

                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
        End Try
    End Sub

#End Region
    '=====================================SE BORRO EL INPUT PARA EL Responsable porque jalamos de Gapp El Dni 
    'Private Sub actxaCodResponsable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If e.KeyData = Keys.Enter Then
    '            If actxaCodResponsable.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
    '                '' Cargar datos adicionales cliente
    '                If actxaCodResponsable.ACAyuda.Enabled = True Then
    '                    If managerEntidades.CargarDocIden(actxaCodResponsable.Text, EEntidades.TipoInicializacion.Direcciones) Then
    '                        actxaCodResponsable.Text = managerEntidades.Entidades.ENTID_NroDocumento
    '                        actxaNomResponsable.Text = managerEntidades.Entidades.ENTID_RazonSocial
    '                        Label6.Focus()
    '                    Else
    '                        If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
    '                                        , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaCodResponsable.Text) _
    '                                        , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
    '                            NuevaEntidad(actxaCodResponsable.Text, EEntidades.TipoEntidad.Proveedores)
    '                        Else
    '                            actxaCodResponsable.Clear()
    '                            actxaNomResponsable.Clear()
    '                            Label2.Focus()
    '                        End If
    '                    End If
    '                End If
    '            Else
    '                If actxaCodResponsable.Text.Trim().Length > 0 Then
    '                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocProveedor.Text))
    '                    actxaCodResponsable.Clear()
    '                    actxaNomResponsable.Clear()
    '                    Label2.Focus()
    '                End If

    '            End If
    '        End If
    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
    '    End Try
    'End Sub



    Private Sub actxnManKilometraje_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxnManKilometraje.KeyDown
        If e.KeyCode = Keys.Enter Then
            KeyPreview = False
            tool.Focus()
            tsbtnAgregar.Select()
        End If
    End Sub

    Private Sub tsbtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAgregar.Click
        Try
            If Not managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos.Count > 0 Then
                Throw New Exception("Debe Ingresar Documentos de Compra para continuar")
            End If
            Dim frmpartes As New MPartesMant(managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos) With {.WindowState = FormWindowState.Normal, .StartPosition = FormStartPosition.CenterScreen}
            If frmpartes.ShowDialog() = Windows.Forms.DialogResult.OK Then
                managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle.Add(frmpartes.TRAN_VehiculosMantenimientoDetalle)
                bs_piezas.ResetBindings(False)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Agregar Parte"), ex)
        End Try
    End Sub

    Private Sub tsbtnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnQuitar.Click
        Try
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
             , "Desea eliminar el registro: " _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle.Remove(CType(bs_piezas.Current, ETRAN_VehiculosMantenimientoDetalle))
                bs_piezas.ResetBindings(False)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Quitar Parte"), ex)
        End Try
    End Sub

    Private Sub tsbtnAgregarFacturas_Click(sender As Object, e As EventArgs) Handles tsbtnAgregarFacturas.Click
        Try
            Dim _doccompra As New MDocumentosCompra(Nothing, MDocumentosCompra.TInicio.Busqueda)
            If _doccompra.ShowDialog() = Windows.Forms.DialogResult.OK Then
                managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos.Add(_doccompra.TRAN_Documentos)
                bs_facturas.ResetBindings(False)
                If managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos.Count > 0 Then
                    Dim _documentos As New BTRAN_Documentos
                    Dim x_condicion As String = ""
                    Dim _uno As Boolean = True
                    For Each item As ETRAN_Documentos In managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos
                        If _uno Then
                            x_condicion &= String.Format("'{0}{1}'", item.DOCUS_Codigo, item.ENTID_Codigo) : _uno = False
                        Else
                            x_condicion &= String.Format(",'{0}{1}'", item.DOCUS_Codigo, item.ENTID_Codigo)
                        End If
                    Next
                    If _documentos.CargarDetalle(x_condicion) Then
                        For Each item As ETRAN_DocumentosDetalle In _documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle
                            Dim _filter As New ACFiltrador(Of ETRAN_VehiculosMantenimientoDetalle)
                            _filter.ACFiltro = String.Format("DOCUS_Codigo={0} AND ENTID_Codigo={1} AND PIEZA_Codigo={2}", item.DOCUS_Codigo, item.ENTID_Codigo, item.PIEZA_Codigo)
                            If Not _filter.ACFiltrar(managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle).Count > 0 Then
                                Dim _detalle As New ETRAN_VehiculosMantenimientoDetalle
                                _detalle.DOCUS_Codigo = item.DOCUS_Codigo
                                _detalle.ENTID_Codigo = item.ENTID_Codigo
                                _detalle.PIEZA_Codigo = item.PIEZA_Codigo
                                _detalle.PIEZA_Descripcion = item.DCDET_Descripcion
                                _detalle.VMDET_Cantidad = item.DCDET_Cantidad
                                _detalle.PIEZA_Id = item.PIEZA_Id
                                _detalle.TIPOS_CodTipoRepuesto = Colecciones.Tipos(ETipos.MyTipos.TipoRepuesto)(0).TIPOS_Codigo
                                _detalle.TIPOS_TipoRepuesto = Colecciones.Tipos(ETipos.MyTipos.TipoRepuesto)(0).TIPOS_Descripcion
                                _detalle.VMDET_Responsable = "-"
                                '_detalle.PIEZA_Descripcion = item.DOCUS_Estado
                                managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle.Add(_detalle)
                            End If
                        Next
                        bs_piezas.ResetBindings(False)
                    End If
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Agregar Factura de Compra"), ex)
        End Try
    End Sub

    Private Sub tsbtnQuitarFacturas_Click(sender As Object, e As EventArgs) Handles tsbtnQuitarFacturas.Click
        Try
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
             , "Desea eliminar el registro: " _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos.Remove(CType(bs_facturas.Current, ETRAN_Documentos))
                bs_facturas.ResetBindings(False)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Quitar Parte"), ex)
        End Try
    End Sub

    Private Sub tsbtnModificarPieza_Click(sender As Object, e As EventArgs) Handles tsbtnModificarPieza.Click
        Try
            If Not managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos.Count > 0 Then
                Throw New Exception("Debe Ingresar Documentos de Compra para continuar")
            End If
            Dim frmpartes As New MPartesMant(CType(bs_piezas.Current, ETRAN_VehiculosMantenimientoDetalle), managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos) With {.WindowState = FormWindowState.Normal, .StartPosition = FormStartPosition.CenterScreen}
            If frmpartes.ShowDialog() = Windows.Forms.DialogResult.OK Then
                bs_piezas.ResetBindings(False)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Agregar Parte"), ex)
        End Try
    End Sub


    '===================Funcionalidad para la Carga de Los Articulos =========================================================================

    'Private Sub actxaProdCodigo_ACAyudaClick(sender As Object, e As EventArgs)
    '    CargarParte(TPiezas.Codigo, actxaProdCodigo.Text)
    '    'EVENTO _ PARA BUSCAR LAS PIEZAS 
    'End Sub
    'Private Sub actxaDescripcion_ACAyudaClick(sender As Object, e As EventArgs) Handles actxaDescripcion.ACAyudaClick
    '    CargarParte(TPiezas.Nombre, actxaDescripcion.Text)
    'End Sub
    'Private Sub CargarParte(ByVal x_opcion As TPiezas, ByVal x_cadena As String)
    '    Try

    '        Select Case x_opcion
    '            Case TPiezas.Codigo 'No se necesita x_opcion = 0
    '                Busqueda_x_CodigoPieza(x_opcion, "PIEZA_Codigo", x_cadena)

    '            Case TPiezas.Nombre 'No se necesita x_opcion = 1
    '                Busqueda_x_DescripcionPieza(x_opcion, "PIEZA_Descripcion", x_cadena)

    '        End Select
    '        Me.KeyPreview = True

    '    Catch ex As Exception
    '        'Throw ex
    '        ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el Proceso de Busqueda de Partes", ex)
    '    End Try
    'End Sub
#Region "Busquedas de Piezas"
    'Se creo estas dos funciones para tener mas ordenas las condicionales by frank 
    'Private Sub Busqueda_x_CodigoPieza(ByVal x_opcion As TPiezas, ByVal x_name_Campo As String, ByVal x_cadena As String)
    '    Try
    '        Dim m_piezas As New BTRAN_Piezas

    '        Dim x_campo As String = x_name_Campo 'Escogemos que campo de la tabla queremos  buscar by frank 
    '        Dim _where As New Hashtable
    '        _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))

    '        If (m_piezas.Cargar_x_Descripcion(x_cadena, _where)) Then 'si al buscar .. no existe entonces que bote mensaje de si quiere crear 
    '            If m_piezas.Ayuda(x_opcion, x_cadena) Then
    '                Dim _campo As String = x_name_Campo
    '                Dim _campos() As ACCampos = {New ACCampos("@Pieza_Codigo", actxaProdCodigo.Text)}
    '                Dim x_busqueda As ACCampos = New ACCampos("@Pieza_Codigo", x_cadena)
    '                ' Dim _busqueda As New ACCampos("@Neuma_Codigo", x_busqueda) 
    '                '  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Proveedor", m_piezas.Datos.Tables(0), False) 'Comentador Frank 
    '                Dim Ayuda As New ACControlesC1.ACAyudaTextFlex("Buscar Piezas", "AYUDASS_BusquedaCodigo_piezas", _campos, x_busqueda, False)
    '                If Ayuda.ShowDialog = Windows.Forms.DialogResult.OK Then
    '                    '' Cargar datos del cliente
    '                    actxaProdCodigo.Text = Ayuda.Respuesta.Rows(0)("Codigo")
    '                    actxaDescripcion.Text = Ayuda.Respuesta.Rows(0)("Descripcion")
    '                    m_tran_piezas = New ETRAN_Piezas
    '                    m_tran_piezas.PIEZA_Id = Ayuda.Respuesta.Rows(0)("Id")
    '                    m_tran_piezas.PIEZA_Codigo = Ayuda.Respuesta.Rows(0)("Codigo")
    '                    m_tran_piezas.PIEZA_Descripcion = Ayuda.Respuesta.Rows(0)("Descripcion")
    '                End If
    '            End If
    '        Else
    '            'Ventana para Crear Pieza 
    '            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Registro de Piezas: {0}", Me.Text) _
    '                  , String.Format("No se Pudo encontrar la Pieza que Busca ¿ Deseas Registrar la PIEZA ahora?") _
    '                  , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
    '                Dim frmPiezas As New MPiezas(actxaProdCodigo.Text)
    '                frmPiezas.Show()
    '            Else
    '                '  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
    '            End If
    '            Me.KeyPreview = True
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub Busqueda_x_DescripcionPieza(ByVal x_opcion As TPiezas, ByVal x_name_Campo As String, ByVal x_cadena As String)
    '    Try
    '        Dim m_piezas As New BTRAN_Piezas

    '        Dim x_campo As String = x_name_Campo 'Escogemos que campo de la tabla queremos  buscar by frank 
    '        Dim _where As New Hashtable
    '        _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))

    '        If (m_piezas.Cargar_x_Descripcion(x_cadena, _where)) Then 'si al buscar .. no existe entonces que bote mensaje de si quiere crear 
    '            If m_piezas.Ayuda(x_opcion, x_cadena) Then
    '                Dim _campo As String = x_name_Campo
    '                Dim _campos() As ACCampos = {New ACCampos("@Pieza_Descripcion", actxaDescripcion.Text)}
    '                Dim x_busqueda As ACCampos = New ACCampos("@Pieza_Descripcion", x_cadena)
    '                ' Dim _busqueda As New ACCampos("@Neuma_Codigo", x_busqueda) 
    '                '  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Proveedor", m_piezas.Datos.Tables(0), False) 'Comentador Frank 
    '                Dim Ayuda As New ACControlesC1.ACAyudaTextFlex("Buscar Piezas", "AYUDASS_BusquedaDescription_piezas", _campos, x_busqueda, False)
    '                If Ayuda.ShowDialog = Windows.Forms.DialogResult.OK Then
    '                    '' Cargar datos del cliente
    '                    'actxaProdCodigo.Text = Ayuda.Respuesta.Rows(0)("Codigo")
    '                    actxaDescripcion.Text = Ayuda.Respuesta.Rows(0)("Descripcion")
    '                    m_tran_piezas = New ETRAN_Piezas
    '                    m_tran_piezas.PIEZA_Id = Ayuda.Respuesta.Rows(0)("Id")
    '                    m_tran_piezas.PIEZA_Codigo = Ayuda.Respuesta.Rows(0)("Codigo")
    '                    m_tran_piezas.PIEZA_Descripcion = Ayuda.Respuesta.Rows(0)("Descripcion")
    '                End If
    '            End If
    '        Else
    '            'Ventana para Crear Pieza 
    '            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Registro de Piezas: {0}", Me.Text) _
    '                                      , String.Format("No se Pudo encontrar la Pieza que Busca ¿ Deseas Registrar la PIEZA ahora?") _
    '                  , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
    '                Dim frmPiezas As New MPiezas(actxaDescripcion.Text)
    '                frmPiezas.Show()
    '            Else
    '                '  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
    '            End If
    '            Me.KeyPreview = True
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
#End Region
    Private Sub subirItem()
        Try
            ' actxaProdCodigo.Text = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).PIEZA_Codigo
            actxnProdCantidad.Text = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_Cantidad
            actxaDescripcion.Text = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_Descripcion
            actxnPrecio.Text = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_Precio
            chkPrecIGV.Checked = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_IncGV
            actxnPrecIGV.Text = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_Importe
            m_tran_piezas.PIEZA_Id = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).PIEZA_Id
            m_tran_piezas.PIEZA_Codigo = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).PIEZA_Codigo
            m_tran_piezas.PIEZA_Descripcion = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_Descripcion

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub setProducto(ByVal x_opcion As Boolean)
        Try
            If x_opcion Then

            Else
                'actxaProdCodigo.Clear()
                actxaDescripcion.Clear()
                actxnProdCantidad.Text = "0.00"
                actxnDescuento.Text = "0.00"
                actxnPrecio.Text = "0.00"
                actxnPrecIGV.Text = "0.00"
                actxnSubImporte.Text = "0.00"
                m_tran_piezas = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ModificarArticulo()
        Try
            ' CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).PIEZA_Codigo = actxaProdCodigo.Text
            CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).PIEZA_Id = m_tran_piezas.PIEZA_Id
            CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_Descripcion = actxaDescripcion.Text
            CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_Precio = actxnPrecio.Text
            CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_IncGV = chkPrecIGV.Checked
            CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_Importe = actxnPrecIGV.Text
            CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_SubImporte = actxnSubImporte.Text
            setProducto(False)
            calcular()
            c1grdDetalle_piezas.Enabled = True
            Me.KeyPreview = False
            m_modArticulo = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Supuestamente esto Es para que Cuando un Documento de Compra 
    'Que trae del Otro formulario por ende se esta borrando 
    'Private Function getOpcion() As Integer

    '    If rbtnProveedor.Checked Then
    '        Return 0
    '    ElseIf rbtnNroDocumento.Checked Then
    '        Return 1
    '    Else
    '        Return 0
    '    End If
    'End Function
    Private Sub calcular(Optional ByVal x_moneda As Boolean = False)
        Try
            Dim _total As Decimal = 0
            For Each item As ETRAN_DocumentosDetalle In managerTRAN_Documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle
                _total += item.DCDET_SubImporte
            Next
            Dim _igv As Decimal = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
            Dim _subimporte As Decimal = Math.Round(_total / ((100 + _igv) / 100), 2)
            actxnTotalPagar.Text = _total : actxnTotalPagar.Formatear()
            actxnImporte.Text = _subimporte : actxnImporte.Formatear()
            actxnIGV.Text = _total - _subimporte : actxnIGV.Formatear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function addDetallePedido() As Boolean
        Try
            _numero_correlativo_documento = actxnNumero.Text 'Validamos 
            If _numero_correlativo_documento = 0 Or actxnNumero.Text = " " Then
                ACControles.ACDialogos.ACMostrarMensajeInformacion("Faltan Datos", "Antes de Ingresar Items Necesitas Ingresar el Numero del Documento")
            Else
                'Comentado para pruebas sin pieza codigo 
                Dim _detDocumentos As New ETRAN_DocumentosDetalle
                _detDocumentos.Instanciar(ACEInstancia.Nuevo)
                '_detDocumentos.PIEZA_Id = m_tran_piezas.PIEZA_Id 'COMENTADO FRANK 
                _detDocumentos.PIEZA_Codigo = actxaDescripcion.Text 'Comentado frank 
                _detDocumentos.DCDET_Descripcion = actxaDescripcion.Text
                _detDocumentos.DCDET_Precio = actxnPrecio.Text
                _detDocumentos.DCDET_Importe = actxnPrecIGV.Text
                _detDocumentos.DCDET_Descuento = actxnDescuento.Text
                _detDocumentos.DCDET_SubImporte = actxnSubImporte.Text
                _detDocumentos.DCDET_Cantidad = actxnProdCantidad.Text
                managerTRAN_Documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle.Add(_detDocumentos)
                Dim _detMantenimiento As New ETRAN_VehiculosMantenimientoDetalle
                _detMantenimiento.Instanciar(ACEInstancia.Nuevo)
                _detMantenimiento.VEHIC_Id = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id

                ' _detMantenimiento.PIEZA_Id = m_tran_piezas.PIEZA_Id 'comentado frank 
                _detMantenimiento.TIPOS_CodTipoRepuesto = Colecciones.Tipos(ETipos.MyTipos.TipoRepuesto)(0).TIPOS_Codigo
                ' _detalle.TIPOS_TipoRepuesto = Colecciones.Tipos(ETipos.MyTipos.TipoRepuesto)(0).TIPOS_Descripcion
                _detMantenimiento.PIEZA_Codigo = actxaDescripcion.Text
                _detMantenimiento.VMDET_Cantidad = actxnProdCantidad.Text
                _detMantenimiento.VMDET_Responsable = GApp.EUsuario.USER_DNI
                _detMantenimiento.VMDET_Procedimiento = actxaDescripcion.Text
                _detMantenimiento.VMDET_UsrCrea = GApp.EUsuario.USER_DNI
                _detMantenimiento.VMDET_FecCrea = Date.Now()

                _detMantenimiento.DOCUS_Codigo = String.Format("{0}{1}{2}", cmbDocumento.SelectedValue.ToString.Substring(3, 2), txtSerie.Text.ToString.PadLeft(4, "0"), _numero_correlativo_documento.ToString.PadLeft(7, "0")) ' managerTRAN_Documentos.TRAN_Documentos.DOCUS_Codigo
                _detMantenimiento.ENTID_Codigo = actxaNroDocProveedor.Text
                '_detMantenimiento.DCDET_Item = contador_detalle_mantenimiento + 1
                managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle.Add(_detMantenimiento)
                'Dim managerETRAN_Mantenimiento As New ETRAN_VehiculosMantenimiento
                'managerTRAN_VehiculosMatenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.DOCUS_Codigo = _numero_correlativo_documento
                'managerTRAN_VehiculosMatenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.ENTID_Codigo = actxaNroDocProveedor.Text
                'managerTRAN_MantenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.VEHIC_Id = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
                'managerTRAN_MantenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.VMDCO_UsrCrea = GApp.DataUsuario.USER_DNI
                'managerTRAN_MantenimientoDocCompra.TRAN_VehiculosMantenimientoDocCompra.VMDCO_FecCrea = Date.Now()
                calcular()
                setProducto(False)
                bs_documentosdetalle.ResetBindings(False)
            End If
            'VEHIC_Id
            ' VMAN_Item
            ' VMDET_Item
            ' PIEZA_Id
            ' TIPOS_CodTipoRepuesto
            ' VMDET_Cantidad
            ' VMDET_Responsable
            ' VMDET_Procedimiento VMDET_Estado    
            ' VMDET_UsrCrea
            ' VMDET_FecCrea   VMDET_UsrMod
            'VMDET_FecMod
            ' DOCUS_Codigo
            ' ENTID_Codigo
            ' DCDET_Item

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub txtOpcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpcion.KeyPress
        Try
            Select Case e.KeyChar
                Case vbCr '"+"c
                    ' Case ChrW(Keys.Enter)
                    If m_modArticulo Then
                        e.Handled = True
                        ModificarArticulo()
                        c1grdDetalle_piezas.AutoSizeCols()
                    Else
                        e.Handled = True
                        If addDetallePedido() Then
                            '  actxaProdCodigo.Focus()
                            txtOpcion.Text = ""
                            txtOpcion.SelectAll()
                            setProducto(False)
                        End If
                    End If
                    c1grdDetalle_piezas.AutoSizeCols()
                    'lblCodigo.Focus()
                Case "-"c
                    e.Handled = True
                    c1grdDetalle_piezas.AutoSizeCols()
                Case Else
                    e.Handled = True
            End Select
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso opciones", ex)
        End Try
    End Sub
    Private Sub c1grdDetalle_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdDetalle_piezas.Enter
        Me.KeyPreview = False
    End Sub

    Private Sub c1grdDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            e.SuppressKeyPress = True
            Select Case e.KeyCode
                Case Keys.Enter
                    subirItem()
                    c1grdDetalle_piezas.Enabled = False
                    actxnProdCantidad.Focus()
                    m_modArticulo = True
                    Me.KeyPreview = True
                Case Keys.Delete
                    If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
                  , String.Format("Desea quitar el Articulo : {0} ", CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle).DCDET_Descripcion) _
                  , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        Dim m_det As ETRAN_DocumentosDetalle = CType(bs_documentosdetalle.Current, ETRAN_DocumentosDetalle)
                        managerTRAN_Documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle.Remove(m_det)
                        bs_documentosdetalle.ResetBindings(False)
                        calcular()
                    End If
                Case Else
                    e.Handled = False
            End Select
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede calcular carga el Item", ex)
        End Try
    End Sub
    Private Sub actxnPrecio_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim _precio As Decimal = CType(actxnPrecio.Text, Decimal)
            Dim _igv As Decimal = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
            If chkPrecIGV.Checked Then
                actxnPrecIGV.Text = _precio * (100 + _igv) / 100
            Else
                actxnPrecIGV.Text = _precio
            End If
            actxnPrecIGV.Formatear()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede calcular el Precio", ex)
        End Try
    End Sub

    Private Sub actxnProdCantidad_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.KeyPreview = True
            Dim _cantidad As Decimal
            Dim _descuento As Decimal
            Try
                _cantidad = CType(actxnProdCantidad.Text, Decimal)
                _descuento = CType(actxnDescuento.Text, Decimal)

            Catch ex As Exception
                _cantidad = 0
            End Try
            Dim _igv As Decimal = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
            If _cantidad > 0 Then

                Dim _precioUnitario As Double
                Try
                    _precioUnitario = CType(actxnPrecio.Text, Decimal)

                Catch ex As Exception
                    _precioUnitario = 0
                End Try
                Dim _total As Double = _cantidad * _precioUnitario * ((100 - _descuento) / 100)
                If chkIncluidoIGV.Checked Then
                    actxnSubImporte.Text = (_total * (100 + _igv) / 100).ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
                Else
                    actxnSubImporte.Text = _total.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
                End If

            Else
                '   actxnProdCantidad.Focus()
                '  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "Es necesario que ingrese una cantidad mayor a 0")
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede calcular el Sub-Importe", ex)
        End Try
    End Sub


    '==================================================================================================
    '=======================================validando la tabla para el Ingreso de Compras=================================================================
    Private Function Validar(ByRef x_msg As String) As Boolean
        Try
            If Not ACFramework.ACUtilitarios.ACDatosOk(pnlCabecera, x_msg) Then
                Return False
            End If
            If Not managerTRAN_Documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle.Count > 0 Then
                x_msg &= String.Format("{0}- No se ha ingresado ningun Item.", vbNewLine)
            End If
            Return Not x_msg.Length > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '===========================================validando MODIFICADO ==========================
    Private Function ValidarModificado(ByRef x_msg As String) As Boolean
        Try

            'If Not managerTRAN_Documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle.Count > 0 Then
            '    x_msg &= String.Format("{0}- No se ha ingresado ningun Item.", vbNewLine)
            'End If
            Return True 'Not x_msg.Length > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub chkIncluidoIGV_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluidoIGV.CheckedChanged
        chkPrecIGV.Checked = chkIncluidoIGV.Checked
    End Sub

    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged

    End Sub




    'Private Sub actxnProdCantidad_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    'COMENTADO PORQUE SE REPETIAN 
    '        Me.KeyPreview = True
    '        Dim _cantidad As Decimal
    '        Dim _descuento As Decimal
    '        Try
    '            _cantidad = CType(actxnProdCantidad.Text, Decimal)
    '            _descuento = CType(actxnDescuento.Text, Decimal)

    '        Catch ex As Exception
    '            _cantidad = 0
    '        End Try
    '        Dim _igv As Decimal = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
    '        If _cantidad > 0 Then

    '            Dim _precioUnitario As Double
    '            Try
    '                _precioUnitario = CType(actxnPrecio.Text, Decimal)

    '            Catch ex As Exception
    '                _precioUnitario = 0
    '            End Try
    '            Dim _total As Double = _cantidad * _precioUnitario * ((100 - _descuento) / 100)
    '            If chkIncluidoIGV.Checked Then
    '                actxnSubImporte.Text = (_total * (100 + _igv) / 100).ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
    '            Else
    '                actxnSubImporte.Text = _total.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
    '            End If

    '        Else
    '            '   actxnProdCantidad.Focus()
    '            '  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "Es necesario que ingrese una cantidad mayor a 0")
    '        End If
    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede calcular el Sub-Importe", ex)
    '    End Try
    'End Sub
    'Private Sub actsbtnSeleccionar_Click(sender As Object, e As EventArgs) Handles actsbtnSeleccionar.Click
    '    Try
    '        If Not IsNothing(bs_documentos.Current) Then
    '            If CType(bs_documentos.Current, ETRAN_Documentos).DOCUS_Estado <> ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Anulado) Then
    '                managerTRAN_Documentos.TRAN_Documentos = CType(bs_documentos.Current, ETRAN_Documentos)
    '                Me.DialogResult = Windows.Forms.DialogResult.OK
    '                Me.Close()
    '            Else
    '                Throw New Exception("No se puede agregar un documento que fue anulado")
    '            End If
    '        Else
    '            Throw New Exception("No ha cargado ningun documento, vuelva a probar la busqueda e intente de nuevo")
    '        End If
    '    Catch ex As Exception
    '        ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Seleccionar Documento de Compra"), ex)
    '    End Try
    'End Sub
    '========================================================================================================
End Class