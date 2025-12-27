Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid
Imports ACEVentas
Imports ACBVentas

Public Class PVehiculos

#Region " Variables "
    Private managerTRAN_Vehiculos As BTRAN_Vehiculos
    Private managerTRAN_Ranflas As BTRAN_Ranflas
    Private managerTRAN_VehiculosConductores As BTRAN_VehiculosConductores
    Private managerTRAN_VehiculosMantenimiento As BTRAN_VehiculosMantenimiento
    Private managerTRAN_VehiculosRanflas As BTRAN_VehiculosRanflas

    Private managerTRAN_IncidenciasVehiculos As BTRAN_VehiculosIncidencias
    Private managerTRAN_TRAN_VehiculosSeguros As BTRAN_VehiculosSeguros
    '=====================Documentos=================================================
    Private managerTRAN_Documentos As BTRAN_Documentos
    '===============================================================================
    Private m_listBindHelper As List(Of ACBindHelper)
    Private m_listBHRanflas As List(Of ACBindHelper)
    Private m_listBHIncidencias As List(Of ACBindHelper)
    Private m_listBHSeguros As List(Of ACBindHelper)

    '========='Binding para Mantenimiento FRANK ================================================
    Private m_listBHMantenimientos As List(Of ACBindHelper)
    '===========================================================================================
    Private m_etran_vehiculos As ETRAN_Vehiculos
    Private m_etran_incidenciasvehiculos As ETRAN_VehiculosIncidencias
    Private m_etran_segurosvehiculos As ETRAN_VehiculosSeguros
    'variabte para mantenimeintos frank +
    Private m_etran_mantenimientosPrev_vehiculos As ETRAN_VehiculosMantenimiento

    Private bs_btran_vehiculos As BindingSource

    Private bs_bATRAN_Ranflas As BindingSource
    Private bs_bDTRAN_Ranflas As BindingSource
    Private bs_bHTRAN_Ranflas As BindingSource

    Private bs_bATRAN_Conductores As BindingSource
    Private bs_bDTRAN_Conductores As BindingSource
    Private bs_bHTRAN_Conductores As BindingSource

    Private bs_btran_mantenimientosPreventivo As BindingSource
    Private bs_btran_mantenimientosCorrectivo As BindingSource
    Private bs_btran_combustibleconsumo As BindingSource
    Private bs_btran_incidenciasvehiculos As BindingSource
    Private bs_btran_segurosvehiculos As BindingSource

    Private m_nroConductores As Integer

    Private m_tipoedicion As TipoEdicion
    '====vARIABLES PARA LOS PERMISOS ==== 
    '====    Private x_imprimir As Boolean = False
    Private x_imprimir As Boolean = False
    Private x_anular As Boolean = False
    Private x_eliminar As Boolean = False

    Enum RanflaTipoGrilla
        Todos
        Disponibles
        Asignados
        Historial
    End Enum

    Enum ConductoresGrilla
        Todos
        Disponibles
        Asignados
        Historial
    End Enum

    Enum MantenimientoTipo
        Todos
        Mantenimiento
        MatenimientoPreventivo
        MantenimientoCorrectivo
        Nada
    End Enum

    Enum ConsumoCombustible
        Todos
        Consumo
    End Enum

    Enum Incidencias
        Todos
        Incidencias
    End Enum

    Enum Seguros
        Todos
        Seguros
    End Enum

    Enum TipoEdicion
        Normal
        Ranflas
        Conductores
        Incidencias
        MantenimientoTipo
        MantenimientoPreventivo
        Seguros
        Mantenimiento

    End Enum

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            setInicio(TipoEdicion.Ranflas)

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

    Public Sub New(ByVal x_opcion As TipoEdicion)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            setInicio(x_opcion)
            setInstanciaPermisos(ACFramework.ACEInstancia.Nuevo) 'Creado Frank
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

    Private Sub setInicio(ByVal x_opcion As TipoEdicion)
        Try
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda
            TabAdicionales.SelectedTab = TabRanflas

            formatearGrilla()
            cargarCombos()

            '' Inicializacion de Propiedades adicionales del vehiculo
            managerTRAN_Vehiculos = New BTRAN_Vehiculos
            managerTRAN_Ranflas = New BTRAN_Ranflas

            managerTRAN_VehiculosConductores = New BTRAN_VehiculosConductores
            managerTRAN_VehiculosRanflas = New BTRAN_VehiculosRanflas
            managerTRAN_VehiculosMantenimiento = New BTRAN_VehiculosMantenimiento
            managerTRAN_TRAN_VehiculosSeguros = New BTRAN_VehiculosSeguros
            managerTRAN_IncidenciasVehiculos = New BTRAN_VehiculosIncidencias

            m_nroConductores = CType(Parametros.GetParametro(EParametros.TipoParametros.pg_CondXVehi), Integer)
            m_tipoedicion = x_opcion
            txtMantenimientoPrevTiposCod.Enabled = False
            ComboBoxPrevTipMantenimiento.DropDownStyle = ComboBoxStyle.DropDownList
            txtMantenimientoPrevTiposCod.Text = "MNT002"
            acTool.ACBtnEliminarEnabled = False
            acTool.ACBtnModificarEnabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Metodos "
#Region " Utilitarios "



    Private Sub setInstanciaPermisos(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)
        Try
            'acTool.ACBtnRehusarVisible = False
            'acTool.ACBtnImprimirVisible = False
            'acTool.ACBtnImprimirEnabled = False
            AcToolBarMantPrev.ACBtnEliminar.Visible = False
            'acTool.ACBtnAnular.Visible = False
            Dim _validate As ACSeguridad.ACValidarUsuario
            _validate = New ACSeguridad.ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACSeguridad.ACValidarUsuario.Operacion.ValidarVariosProcesos)
            For Each item As ACSeguridad.EProcesos In _validate.ListProcesos 'Itera el Permiso para dar Propiedades a cada Boton de un Grupo frank
                Select Case item.PROC_Codigo
                    Case Procesos.getProceso(Procesos.TipoProcesos.ViajeEliminarMantenimiento_SNFactura)
                        x_eliminar = True
                        AcToolBarMantPrev.ACVisibleBtnEliminar = True

                End Select
            Next
            Select Case _opcion 'ESTO SE USA MAS ADELANTE PARA CUANDO SE PASA UNA INSTANCIA DE NUEVO ETC FRANK 
                Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
                    ' chkIlncluidoIGV.Enabled = True
                Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado

                Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

                Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

                Case ACFramework.ACUtilitarios.ACSetInstancia.Previsualizar

            End Select


            '  acTool.ACBtnModificarVisible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub formatearGrilla()
        Dim index As Integer = 1
        Try
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 9, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "VEHIC_Id", "VEHIC_Id", 150, True, False, "System.Integer", "00000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String", "") : index += 1
            'ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Sucursal", "SUCUR_Nombre", "SUCUR_Nombre", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Vehiculo", "TIPOS_Vehiculo", "TIPOS_Vehiculo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Marca", "TIPOS_Marca", "TIPOS_Marca", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Modelo", "VEHIC_Modelo", "VEHIC_Modelo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Adq.", "VEHIC_FecAdquisicion", "VEHIC_FecAdquisicion", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Conductor", "Conductor", "Conductor", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Ranfla", "RANFL_Placa", "RANFL_Placa", 150, True, False, "System.String", "") : index += 1
            c1grdBusqueda.AllowEditing = False
            c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
            c1grdBusqueda.SelectionMode = SelectionModeEnum.Row


            '/*****************************************************************************************************************/
            '' Ranflas
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdRanAsignadas, 1, 1, 6, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanAsignadas, index, "Codigo", "RANFL_Codigo", "RANFL_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanAsignadas, index, "Placa", "RANFL_Placa", "VEHIC_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanAsignadas, index, "Adquisición", "RANFL_FecAdquisicion", "RANFL_FecAdquisicion", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanAsignadas, index, "Inicio", "VEHRN_FECASIGNACION_Fecha", "VEHRN_FECASIGNACION_Fecha", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanAsignadas, index, "Termino", "VEHRN_FECDESASIGNACION_Fecha", "VEHRN_FECDESASIGNACION_Fecha", 150, True, False, "System.String") : index += 1

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdRanDisponibles, 1, 1, 4, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanDisponibles, index, "Codigo", "RANFL_Codigo", "RANFL_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanDisponibles, index, "Placa", "RANFL_Placa", "VEHIC_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanDisponibles, index, "Adquisición", "RANFL_FecAdquisicion", "RANFL_FecAdquisicion", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdRanHistorial, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanHistorial, index, "Interno", "VEHRN_Id", "VEHRN_Id", 150, True, False, "System.Integer", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanHistorial, index, "Codigo", "RANFL_Codigo", "RANFL_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanHistorial, index, "Placa", "RANFL_Placa", "VEHIC_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanHistorial, index, "Adquisición", "RANFL_FecAdquisicion", "RANFL_FecAdquisicion", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanHistorial, index, "Asig. Desde", "VEHRN_FecAsignacion", "VEHRN_FecDesasignacion", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRanHistorial, index, "Asig. Hasta", "VEHRN_FecDesasignacion", "VEHRN_FecDesasignacion", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            '/*****************************************************************************************************************/
            '' Mantenimientos
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdManPrevRealizados, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdManPrevRealizados, index, "Interno", "VMAN_Id", "VMAN_Id", 150, True, False, "System.Integer", "") : index += 1
            '  ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdManPrevRealizados, index, "Proveedor", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdManPrevRealizados, index, "Creador por ", "ENTID_CodigoResponsable", "ENTID_CodigoResponsable", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdManPrevRealizados, index, "Tipo Mantenimiento", "TIPOS_TipoMantenimiento", "TIPOS_TipoMantenimiento", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdManPrevRealizados, index, "Fecha", "VMAN_FecRealizacion", "VMAN_FecRealizacion", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdManPrevRealizados, index, "Observaciones", "VMAN_Observaciones", "VMAN_Observaciones", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdManPrevRealizados, index, "Kilometros", "VMAN_Km", "VMAN_Km", 150, True, False, "System.String") : index += 1
            '/*****************************************************************************************************************/
            '' Conbustible Consumo
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdComConsumido, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdComConsumido, index, "Interno", "COMCO_Id", "COMCO_Id", 150, True, False, "System.Integer", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdComConsumido, index, "Modo Pago", "TIPOS_ModoPago", "TIPOS_ModoPago", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdComConsumido, index, "Combustible", "TIPOS_TipoCombustible", "TIPOS_TipoCombustible", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdComConsumido, index, "Fecha", "COMCO_Fecha", "COMCO_Fecha", 150, True, False, "System.DateTime", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdComConsumido, index, "Prec. Galon", "COMCO_PrecioGalon", "COMCO_PrecioGalon", 150, True, False, "System.Decimal", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdComConsumido, index, "Consumo", "COMCO_GalonesConsumidos", "COMCO_GalonesConsumidos", 150, True, False, "System.Decimal", "") : index += 1
            'ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdComConsumido, index, "Estimación", "COMCO_ESTIMACIONCONSUMO", "COMCO_ESTIMACIONCONSUMO", 150, True, False, "System.String", "") : index += 1
            '/*****************************************************************************************************************/
            '' Incidencias
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdIncRealizadas, 1, 1, 5, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncRealizadas, index, "Interno", "INCVE_Id", "INCVE_Id", 150, True, False, "System.Integer", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncRealizadas, index, "Tipo Incidencia", "TIPOS_TipoIncidencia", "TIPOS_TipoIncidencia", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncRealizadas, index, "Descripción", "INCVE_Descripcion", "INCVE_Descripcion", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncRealizadas, index, "Fecha", "INCVE_Fecha", "INCVE_Fecha", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
            '/*****************************************************************************************************************/
            '' Seguros
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdSegAsignados, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSegAsignados, index, "Interno", "SEGVH_Id", "SEGVH_Id", 150, True, False, "System.Integer", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSegAsignados, index, "Descripción", "SEGVH_Descripcion", "SEGVH_Descripcion", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSegAsignados, index, "Fec. Inicio", "SEGVH_FecInicio", "SEGVH_FecInicio", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSegAsignados, index, "Fec. Fin", "SEGVH_FecFin", "SEGVH_FecFin", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSegAsignados, index, "Aseguradora", "SEGVH_EmpresaAseguradora", "SEGVH_EmpresaAseguradora", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSegAsignados, index, "Adquisición", "SEGVH_FecAdquisicion", "SEGVH_FecAdquisicion", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            '/*****************************************************************************************************************/
            '' Conductores
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdConAsignadas, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConAsignadas, index, "Interno", "VHCON_Id", "VHCON_Id", 150, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConAsignadas, index, "Documento", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConAsignadas, index, "Nombres", "ENTID_Nombres", "ENTID_Nombres", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConAsignadas, index, "Fec. Nac.", "ENTID_FecNacimiento", "ENTID_FecNacimiento", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConAsignadas, index, "Inicio", "VHCON_FECDESDE_Fecha", "VHCON_FECDESDE_Fecha", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConAsignadas, index, "Termino", "VEHRN_FECDESASIGNACION_Fecha", "VEHRN_FECDESASIGNACION_Fecha", 150, True, False, "System.String") : index += 1

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdConDisponibles, 1, 1, 4, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConDisponibles, index, "Documento", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConDisponibles, index, "Nombres", "ENTID_Nombres", "ENTID_Nombres", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConDisponibles, index, "Fec. Nac.", "ENTID_FecNacimiento", "ENTID_FecNacimiento", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdConHistorial, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConHistorial, index, "Interno", "VHCON_Id", "VHCON_Id", 150, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConHistorial, index, "Documento", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConHistorial, index, "Nombre", "ENTID_Nombres", "VEHIC_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConHistorial, index, "Fec. Nacimiento", "ENTID_FecNacimiento", "ENTID_FecNacimiento", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConHistorial, index, "Asig. Desde", "VHCON_FecDesde", "VHCON_FecDesde", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConHistorial, index, "Asig. Hasta", "VHCON_FecHasta", "VHCON_FecHasta", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub

    Private Sub cargarCombos()
        Try
            ACFramework.ACUtilitarios.ACCargaCombo(cmbMarca, Colecciones.Tipos(ETipos.MyTipos.MarcasVehiculos), "TIPOS_Descripcion", "TIPOS_Codigo")
            ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoVehiculo, Colecciones.Tipos(ETipos.MyTipos.TipoVehiculos), "TIPOS_Descripcion", "TIPOS_Codigo")
            ' ACFramework.ACUtilitarios.ACCargaCombo(cmbProdUnidad, Colecciones.TiposUnidad_Toneladas, "TIPOS_Desc2", "TIPOS_Codigo")
            'Cargar los Combos de los Mantenimientos Preventivos 
            ACFramework.ACUtilitarios.ACCargaCombo(ComboBoxPrevTipMantenimiento, Colecciones.TiposMantenimientosPrev_Corre_Pred, "TIPOS_Descripcion", "TIPOS_Codigo")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)

        Select Case _opcion
            Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
                'ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
                ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
            'txtCodigo.Enabled = False
            Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            'ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            'txtCodigo.Enabled = False


            Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

            Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

        End Select

    End Sub

    Private Sub setAsigRanflas(ByVal x_opcion As Boolean)
        btnRanQuitar.Enabled = x_opcion
        btnRanQuitarTodos.Enabled = x_opcion
        btnRanAsignar.Enabled = x_opcion
        btnRanAsignarTodos.Enabled = x_opcion
    End Sub

    Private Sub setAsigConductores(ByVal x_opcion As Boolean)
        btnConQuitar.Enabled = x_opcion
        btnConQuiTodos.Enabled = x_opcion
        btnConAsignar.Enabled = x_opcion
        btnConAsigTodos.Enabled = x_opcion
    End Sub
#End Region

#Region " Cargar Datos "

    ' <summary>
    ' Cargar los datos en el control Visual C1FlexGrid
    ' </summary>
    Private Sub cargarDatos()
        Try
            bs_btran_vehiculos = New BindingSource()
            bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos 'PASO DE PARAMETROS DE ListVEHICULOS-- > A LA TABLA de los automobiles 
            c1grdBusqueda.DataSource = bs_btran_vehiculos
            bnavBusqueda.BindingSource = bs_btran_vehiculos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' <summary>
    ' Cargar los datos del vehiculo, su primera carga es la Ranfla
    ' Union entre Vehiculo y Ranfla  GGGG .. MAS FACIL NO  ? 
    ' si lees estoy estoy en Marte 
    '  atte.tu Papi FOMF 
    ' </summary>
    ' <remarks></remarks>
    Private Sub cargar()
        Try
            If bs_btran_vehiculos.Current IsNot Nothing Then
                Dim x_codigo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
                managerTRAN_Vehiculos.Cargar(x_codigo, ETRAN_Vehiculos.Inicializacion.Ranflas) 'LE PASA EL ID DEL VEHICULO DE ACUERDO A LO QUE CAMBIA 
                m_etran_vehiculos = managerTRAN_Vehiculos.getTRAN_Vehiculos()
                ' AsignarBinding()
                '' Cargar las ranflas disponibles
                managerTRAN_VehiculosRanflas.CargarTodos(False)
                setDatos(RanflaTipoGrilla.Todos)
                setAsigRanflas(True)

                txtPlaca.Text = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Placa
                txtModelo.Text = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Modelo
                txtCodigo.Text = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Codigo

                managerTRAN_VehiculosConductores.CargarTodos(False, EEntidades.TipoEntidad.Conductores)
                Dim _order As New ACOrdenador(Of ETRAN_VehiculosConductores)("ENTID_Nombres ASC")

                managerTRAN_VehiculosConductores.ListTRAN_VehiculosConductores.Sort(_order)
                setDatos(ConductoresGrilla.Todos)
                setAsigConductores(True)

                '' Asignar valores a los tools
                tabMantenimiento.SelectedTab = tabDatos
                acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                acTool.ACBtnGrabarVisible = False
                acTool.ACBtnBuscarVisible = False

                Select Case m_tipoedicion
                    Case TipoEdicion.Ranflas
                        TabAdicionales.SelectedTab = TabRanflas
                    Case TipoEdicion.Conductores
                        managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Conductores)
                        setDatos(ConductoresGrilla.Todos)
                        TabAdicionales.SelectedTab = TabConductores
                    Case TipoEdicion.Incidencias
                        managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Incidencias)
                        TabAdicionales.SelectedTab = TabIncidencias
                        setDatos(Incidencias.Todos)
                        '*************mantenimientos *********Frank 
                    'Case TipoEdicion.Mantenimiento
                    '    managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Mantenimiento)
                    '    TabAdicionales.SelectedTab = TabMantVehiculo_Preventivo
                    '    setDatos(MantenimientoTipo.Todos)
                    '===================mantenimientos preventivos
                    Case TipoEdicion.Mantenimiento
                        managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.MantenimientoPreventivo)
                        TabAdicionales.SelectedTab = TabMantVehiculo_Preventivo
                        setDatos(MantenimientoTipo.MatenimientoPreventivo)
                    Case TipoEdicion.Seguros
                        managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Seguros)
                        setDatos(Seguros.Todos)
                        TabAdicionales.SelectedTab = TabSeguros
                    Case Else
                        TabAdicionales.SelectedTab = TabRanflas
                End Select
                AddHandler TabAdicionales.SelectionChanged, AddressOf TabAdicionales_SelectionChanged
            End If
        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            Throw ex
        End Try
    End Sub

    ' <summary>
    ' Ranflas
    ' </summary>
    ' <param name="x_opcion"></param>
    ' <remarks></remarks>
    ' 


    Private Sub setDatos(ByVal x_opcion As RanflaTipoGrilla)
        Try
            '''''''''''''''''''''''''''
            '' Cargar las ranflas
            If (x_opcion = RanflaTipoGrilla.Todos Or x_opcion = RanflaTipoGrilla.Asignados) Then
                '' Ranflas Asignadas
                bs_bATRAN_Ranflas = New BindingSource()
                bs_bATRAN_Ranflas.DataSource = m_etran_vehiculos.ListATRAN_Ranflas
                c1grdRanAsignadas.DataSource = bs_bATRAN_Ranflas
                bnavRanAsignadas.BindingSource = bs_bATRAN_Ranflas
            End If
            If (x_opcion = RanflaTipoGrilla.Todos Or x_opcion = RanflaTipoGrilla.Disponibles) Then
                '' Ranflas Disponibles
                bs_bDTRAN_Ranflas = New BindingSource()
                bs_bDTRAN_Ranflas.DataSource = managerTRAN_VehiculosRanflas.ListTRAN_VehiculosRanflas
                c1grdRanDisponibles.DataSource = bs_bDTRAN_Ranflas
                bnavRanDisponibles.BindingSource = bs_bDTRAN_Ranflas
            End If
            If (x_opcion = RanflaTipoGrilla.Todos Or x_opcion = RanflaTipoGrilla.Historial) Then
                '' Historial de Ranflas
                bs_bHTRAN_Ranflas = New BindingSource()
                bs_bHTRAN_Ranflas.DataSource = m_etran_vehiculos.ListTRAN_HRanflas
                c1grdRanHistorial.DataSource = bs_bHTRAN_Ranflas
                bnavHRanflas.BindingSource = bs_bHTRAN_Ranflas
            End If
            '''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub setDatos(ByVal x_opcion As Incidencias)
        Try
            bs_btran_incidenciasvehiculos = New BindingSource()
            bs_btran_incidenciasvehiculos.DataSource = managerTRAN_Vehiculos.TRAN_Vehiculos.ListVIncidencias
            c1grdIncRealizadas.DataSource = bs_btran_incidenciasvehiculos
            bnavIncRegistradas.BindingSource = bs_btran_incidenciasvehiculos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' <summary>
    ' Conductores
    ' </summary>
    ' <param name="x_opcion"></param>
    ' <remarks></remarks>
    Private Sub setDatos(ByVal x_opcion As ConductoresGrilla)
        Try
            '''''''''''''''''''''''''''
            '' Cargar los Conductores
            If (x_opcion = ConductoresGrilla.Todos Or x_opcion = ConductoresGrilla.Asignados) Then
                '' Ranflas Asignadas
                bs_bATRAN_Conductores = New BindingSource()
                bs_bATRAN_Conductores.DataSource = m_etran_vehiculos.ListATRAN_Conductores
                c1grdConAsignadas.DataSource = bs_bATRAN_Conductores
                bnavConAsignados.BindingSource = bs_bATRAN_Conductores
            End If
            If (x_opcion = ConductoresGrilla.Todos Or x_opcion = ConductoresGrilla.Disponibles) Then
                '' Ranflas Disponibles
                bs_bDTRAN_Conductores = New BindingSource()
                bs_bDTRAN_Conductores.DataSource = managerTRAN_VehiculosConductores.ListTRAN_VehiculosConductores
                c1grdConDisponibles.DataSource = bs_bDTRAN_Conductores
                bnavConDisponibles.BindingSource = bs_bDTRAN_Conductores
            End If
            If (x_opcion = ConductoresGrilla.Todos Or x_opcion = ConductoresGrilla.Historial) Then
                '' Historial de Ranflas
                bs_bHTRAN_Conductores = New BindingSource()
                bs_bHTRAN_Conductores.DataSource = m_etran_vehiculos.ListTRAN_HConductores
                c1grdConHistorial.DataSource = bs_bHTRAN_Conductores
                bnavHConductores.BindingSource = bs_bHTRAN_Conductores
            End If
            '''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' <summary>
    ' Mantenimientos
    ' </summary>
    ' <param name="x_opcion"></param>
    ' <remarks></remarks>
    'Mantenimiento Preventivo envio de Datos a Tabla 
    Private Sub setDatos(ByVal x_opcion As MantenimientoTipo)
        Try 'Si es Mantenimiento Preventivo que pase datos aqui 
            If (x_opcion = MantenimientoTipo.Todos Or x_opcion = MantenimientoTipo.MatenimientoPreventivo) Then
                bs_btran_mantenimientosPreventivo = New BindingSource()
                bs_btran_mantenimientosPreventivo.DataSource = m_etran_vehiculos.ListVMantenimiento
                c1grdManPrevRealizados.DataSource = bs_btran_mantenimientosPreventivo
                bnavManRealizados.BindingSource = bs_btran_mantenimientosPreventivo
                '============================cargamos los tipos de mantenimiento ====================

                '  ComboBoxPrevTipMantenimiento =CType()
            ElseIf (x_opcion = MantenimientoTipo.Todos Or x_opcion = MantenimientoTipo.MantenimientoCorrectivo) Then
                bs_btran_mantenimientosCorrectivo = New BindingSource()
                bs_btran_mantenimientosCorrectivo.DataSource = m_etran_vehiculos.ListVMantenimiento
                c1grdManCorrRealizados.DataSource = bs_btran_mantenimientosCorrectivo
                bnavManRealizados.BindingSource = bs_btran_mantenimientosCorrectivo
            ElseIf (x_opcion = MantenimientoTipo.Nada) Then 'bOTA NADA PORQUE NO DEBERIA DEJAR  DE REGISTRAR MAS DE UN MANTENIMEINTO
                'bs_btran_mantenimientosCorrectivo = New BindingSource()
                'm_etran_vehiculos = New ETRAN_Vehiculos
                'bs_btran_mantenimientosCorrectivo.DataSource = m_etran_vehiculos.ListVMantenimiento

                'c1grdManPrevRealizados.DataSource = bs_btran_mantenimientosCorrectivo
                'bnavManRealizados.BindingSource = bs_btran_mantenimientosCorrectivo
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' <summary>
    ' Seguros
    ' </summary>
    ' <param name="x_opcion"></param>
    ' <remarks></remarks>
    Private Sub setDatos(ByVal x_opcion As Seguros)
        Try
            If (x_opcion = Seguros.Todos Or x_opcion = Seguros.Seguros) Then
                bs_btran_segurosvehiculos = New BindingSource()
                bs_btran_segurosvehiculos.DataSource = m_etran_vehiculos.ListVSeguros
                c1grdSegAsignados.DataSource = bs_btran_segurosvehiculos
                bnavSegAsignados.BindingSource = bs_btran_segurosvehiculos
                AddHandler bs_btran_segurosvehiculos.CurrentChanged, AddressOf bs_SegurosVehiculos_CurrentChanged
                bs_SegurosVehiculos_CurrentChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' <summary>
    ' Consumo de Combustible
    ' </summary>
    ' <param name="x_opcion"></param>
    ' <remarks></remarks>
    Private Sub setDatos(ByVal x_opcion As ConsumoCombustible)
        Try
            If (x_opcion = ConsumoCombustible.Todos Or x_opcion = ConsumoCombustible.Consumo) Then
                bs_btran_combustibleconsumo = New BindingSource()
                bs_btran_combustibleconsumo.DataSource = m_etran_vehiculos.ListVConCombustible
                c1grdComConsumido.DataSource = bs_btran_combustibleconsumo
                bnavComConsumido.BindingSource = bs_btran_combustibleconsumo
            End If
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
            m_listBindHelper.Add(ACBindHelper.ACBind(txtCodigo, "Text", m_etran_vehiculos, "VEHIC_Codigo"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtModelo, "Text", m_etran_vehiculos, "VEHIC_Modelo"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbMarca, "SelectedValue", m_etran_vehiculos, "TIPOS_CodMarca"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoVehiculo, "SelectedValue", m_etran_vehiculos, "TIPOS_CodTipoVehiculo"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ABSeguros()
        Try
            m_listBHSeguros = New List(Of ACBindHelper)()
            m_listBHSeguros.Add(ACBindHelper.ACBind(txtSegDescripcion, "Text", m_etran_segurosvehiculos, "SEGVH_Descripcion"))
            m_listBHSeguros.Add(ACBindHelper.ACBind(txtSegAseguradora, "Text", m_etran_segurosvehiculos, "SEGVH_EmpresaAseguradora"))
            If m_etran_segurosvehiculos.SEGVH_FecInicio.Year < 1700 Then m_etran_segurosvehiculos.SEGVH_FecInicio = DateTime.Now
            dtpSegFecInicio.Value = m_etran_segurosvehiculos.SEGVH_FecInicio
            'm_listBHSeguros.Add(ACBindHelper.ACBind(dtpSegFecInicio, "Value", m_etran_segurosvehiculos, "SEGVH_FecInicio"))
            If m_etran_segurosvehiculos.SEGVH_FecFin.Year < 1700 Then m_etran_segurosvehiculos.SEGVH_FecFin = DateTime.Now
            dtpSegFecFin.Value = m_etran_segurosvehiculos.SEGVH_FecFin
            'm_listBHSeguros.Add(ACBindHelper.ACBind(dtpSegFecFin, "Value", m_etran_segurosvehiculos, "SEGVH_FecFin"))
            If m_etran_segurosvehiculos.SEGVH_FecAdquisicion.Year < 1700 Then m_etran_segurosvehiculos.SEGVH_FecAdquisicion = DateTime.Now
            dtpSegFecAdquisicion.Value = m_etran_segurosvehiculos.SEGVH_FecAdquisicion
            'm_listBHSeguros.Add(ACBindHelper.ACBind(dtpSegFecAdquisicion, "Value", m_etran_segurosvehiculos, "SEGVH_FecAdquisicion"))
            m_listBHSeguros.Add(ACBindHelper.ACBind(actxnSegPrecio, "Text", m_etran_segurosvehiculos, "SEGVH_Precio"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ABMantenimientoPrev()
        Try
            m_listBHMantenimientos = New List(Of ACBindHelper)()
            m_listBHMantenimientos.Add(ACBindHelper.ACBind(txtMantenimientoPrevDescripcion, "Text", m_etran_mantenimientosPrev_vehiculos, "VMAN_Observaciones"))
            m_listBHMantenimientos.Add(ACBindHelper.ACBind(txtMantenimientoPrevKm, "Text", m_etran_mantenimientosPrev_vehiculos, "VMAN_Km"))
            'If m_etran_mantenimientosPrev_vehiculos..Year < 1700 Then m_etran_mantenimientosPrev_vehiculos.VMAN_FecCrea = DateTime.Now
            'dtpSegFecInicio.Value = m_etran_segurosvehiculos.SEGVH_FecInicio
            'm_listBHSeguros.Add(ACBindHelper.ACBind(dtpSegFecInicio, "Value", m_etran_segurosvehiculos, "SEGVH_FecInicio"))
            'If m_etran_mantenimientosPrev_vehiculos.SEGVH_FecFin.Year < 1700 Then m_etran_mantenimientosPrev_vehiculos.SEGVH_FecFin = DateTime.Now
            'dtpSegFecFin.Value = m_etran_segurosvehiculos.SEGVH_FecFin
            'm_listBHSeguros.Add(ACBindHelper.ACBind(dtpSegFecFin, "Value", m_etran_segurosvehiculos, "SEGVH_FecFin"))
            If m_etran_mantenimientosPrev_vehiculos.VMAN_FecCrea.Year < 1700 Then m_etran_mantenimientosPrev_vehiculos.VMAN_FecCrea = DateTime.Now
            ' dtpSegFecAdquisicion.Value = m_etran_segurosvehiculos.SEGVH_FecAdquisicion
            'm_listBHSeguros.Add(ACBindHelper.ACBind(dtpSegFecAdquisicion, "Value", m_etran_segurosvehiculos, "SEGVH_FecAdquisicion"))
            'm_listBHMantenimientos.Add(ACBindHelper.ACBind(actxnSegPrecio, "Text", m_etran_mantenimientosPrev_vehiculos, "SEGVH_Precio"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UBIncidencias()
        If IsNothing(m_listBHIncidencias) Then m_listBHIncidencias = New List(Of ACBindHelper)
        For Each Item As ACBindHelper In m_listBHIncidencias
            Item.ACUnBind()
        Next
        m_listBHIncidencias = New List(Of ACBindHelper)()
    End Sub

    Private Sub UBSeguros()
        If IsNothing(m_listBHSeguros) Then m_listBHSeguros = New List(Of ACBindHelper)
        For Each Item As ACBindHelper In m_listBHSeguros
            Item.ACUnBind()
        Next
        m_listBHSeguros = New List(Of ACBindHelper)()
    End Sub
    Private Sub UBMantenimientos()
        'SI LA LISTA ESTA VACIO ENTONCES QUE  NO ME BOTE ERROR 
        'NO ME BOTE  ERRRO POR FALTA DE DATOS 
        If IsNothing(m_listBHMantenimientos) Then m_listBHMantenimientos = New List(Of ACBindHelper)
        For Each item As ACBindHelper In m_listBHMantenimientos
            item.ACUnBind()
        Next
        m_listBHMantenimientos = New List(Of ACBindHelper)()
    End Sub

    ' <summary>
    ' Ejecutar la busqueda de una cadena en la tabla Neumaticos
    ' </summary>
    ' <param name="x_cadena">Cadena objetivo</param>
    ' <returns></returns>
    Private Function busqueda(ByVal x_cadena As String) As Boolean
        Try
            If managerTRAN_Vehiculos.Busqueda(GApp.PuntoVenta, x_cadena, getCampo()) Then
                acTool.ACBtnEliminarEnabled = True
                acTool.ACBtnModificarEnabled = True
            Else
                acTool.ACBtnEliminarEnabled = False
                acTool.ACBtnModificarEnabled = False
            End If
            cargarDatos()
            Return acTool.ACBtnModificarEnabled
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
        End Try
        Return False
    End Function

    Private Sub setInstanciaSeguros(ByVal x_opcion As Boolean)
        dtpSegFecAdquisicion.Enabled = x_opcion
        dtpSegFecFin.Enabled = x_opcion
        dtpSegFecInicio.Enabled = x_opcion
        ACFramework.ACUtilitarios.ACSetControl(pnlSeguros, Not x_opcion, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
    End Sub
    Private Sub setInstanciaMantenimientoPrev(ByVal x_opcion As Boolean)
        DP_MantPrevFecRealizacion.Enabled = x_opcion
        DP_MantPrevFecFin.Enabled = x_opcion
        DP_MantPrevFecRealizacion.Enabled = x_opcion
        ACFramework.ACUtilitarios.ACSetControl(Panel_MantenimientoPrev, Not x_opcion, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)

    End Sub
    Private Sub setInstanciaLimpiarControlesMantenimento()
        'PORQUE SE CREO ESTO  Y NO SE USO EL LIMPIARpANEL ? el otro te limpia todo .. y no se quiere eso 
        txtMantenimientoPrevDescripcion.Clear()
        txtMantenimientoPrevKm.Clear()
    End Sub
#End Region

    Private Sub bs_SegurosVehiculos_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not IsNothing(bs_btran_segurosvehiculos.Current) Then
                m_etran_segurosvehiculos = CType(bs_btran_segurosvehiculos.Current, ETRAN_VehiculosSeguros).Clone()
                ACFramework.ACUtilitarios.ACSetControl(pnlSeguros, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
                ACFramework.ACUtilitarios.ACLimpiaVar(pnlSeguros)
                ABSeguros()
                UBSeguros()
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cargar Incidencia", ex)
        End Try
    End Sub
    Private Sub bs_MantenimientosPrevVehiculos_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'panel _ manteniemintos 
            'Panel_MantenimientoPrev
            If Not IsNothing(bs_btran_mantenimientosPreventivo.Current) Then
                m_etran_mantenimientosPrev_vehiculos = CType(bs_btran_mantenimientosPreventivo.Current, ETRAN_VehiculosMantenimiento).Clone()
                ACFramework.ACUtilitarios.ACSetControl(Panel_MantenimientoPrev, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
                ACFramework.ACUtilitarios.ACLimpiaVar(Panel_MantenimientoPrev)
                'ABSeguros()
                ABMantenimientoPrev()
                'UBSeguros()
                UBMantenimientos()
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cargar Incidencia", ex)
        End Try
    End Sub

    Private Function getCampo() As Integer
        Try
            If (rbtnCodigo.Checked) Then
                Return 1
            ElseIf rbtnPlaca.Checked Then
                Return 0
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Metodos de Controles"

#Region " Tool Bar "
    Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
        Try

            If Not IsNothing(bs_btran_vehiculos) Then

                tabMantenimiento.SelectedTab = tabBusqueda
                RemoveHandler TabAdicionales.SelectionChanged, AddressOf TabAdicionales_SelectionChanged
                For Each Item As ACBindHelper In m_listBindHelper
                    Item.ACUnBind()
                Next
            End If
        Catch ex As Exception
            'ACControles.ACDialogos.ACMostrarMensajeInformacion("Mensaje " & Me.Text, "Lo siento amigo Hombres Trabajando ")
        End Try
    End Sub

    Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnModificar_Click
        Try
            If Not IsNothing(bs_btran_vehiculos) Then
                setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                cargar()
                tabMantenimiento.SelectedTab = tabDatos
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeInformacion("Mensaje " & Me.Text, "Lo siento amigo Hombres Trabajando ")
        End Try
    End Sub

    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub
    'Eliminar ---> Seguro
#Region " ToolBar de Seguros "
    Private Sub AcToolSeg_ACBtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcToolSeg.ACBtnEliminar_Click
        Try
            '  
            If Not IsNothing(bs_btran_segurosvehiculos.Current) Then
                If ACControles.ACDialogos.ACMostrarMensajePregunta("Eliminar Registro: " & Convert.ToString(Me.Text) _
                   , "Desea eliminar el registro Nro : " & CType(bs_btran_mantenimientosPreventivo.Current, ETRAN_VehiculosMantenimiento).VMAN_Id.ToString() _
                   , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

                    'Era EKliminar pero lo cambie a modificar frank 
                    'managerTRAN_TRAN_VehiculosSeguros.TRAN_VehiculosSeguros.SEGVH_Estado = "X"
                    m_etran_segurosvehiculos.Instanciar(ACEInstancia.Modificado)
                    m_etran_segurosvehiculos.SEGVH_Estado = "X"
                    managerTRAN_TRAN_VehiculosSeguros.setTRAN_VehiculosSeguros(m_etran_segurosvehiculos)
                    ' CType(bs_btran_segurosvehiculos.Current, ETRAN_VehiculosSeguros).SEGVH_Estado = "X"
                    If managerTRAN_TRAN_VehiculosSeguros.Guardar(GApp.Usuario) Then
                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Eliminado satisfactoriamente")
                        managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Seguros)
                        setDatos(Seguros.Todos)
                    End If
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Anular Incidencia", ex)
        End Try
    End Sub
    'Nuevo Seguro -- > FRANK 
    Private Sub AcToolSeg_ACBtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcToolSeg.ACBtnNuevo_Click
        Try
            UBSeguros()
            RemoveHandler bs_btran_segurosvehiculos.CurrentChanged, AddressOf bs_SegurosVehiculos_CurrentChanged
            m_etran_segurosvehiculos = New ETRAN_VehiculosSeguros()
            m_etran_segurosvehiculos.Instanciar(ACEInstancia.Nuevo)
            m_etran_segurosvehiculos.VEHIC_Id = m_etran_vehiculos.VEHIC_Id
            ACFramework.ACUtilitarios.ACSetControl(pnlSeguros, False, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
            ACFramework.ACUtilitarios.ACLimpiaVar(pnlSeguros)
            setInstanciaSeguros(True)
            ABSeguros()
            AcToolSeg.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Nuevo)
            'AcToolSeg.ACBtnCancelar.Visible=False
        Catch ex As Exception
            AcToolSeg.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Ingresar Incidencia", ex)
        End Try
    End Sub
    'Modificar Seguros- - > Frank 
    Private Sub AcToolSeg_ACBtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcToolSeg.ACBtnModificar_Click
        Try
            If Not IsNothing(bs_btran_segurosvehiculos.Current) Then
                UBSeguros()
                RemoveHandler bs_btran_segurosvehiculos.CurrentChanged, AddressOf bs_SegurosVehiculos_CurrentChanged
                m_etran_segurosvehiculos = CType(bs_btran_segurosvehiculos.Current, ETRAN_VehiculosSeguros)
                ACFramework.ACUtilitarios.ACSetControl(pnlSeguros, False, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
                ACFramework.ACUtilitarios.ACLimpiaVar(pnlSeguros)
                setInstanciaSeguros(True)
                ABSeguros()
                AcToolSeg.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
            Else
                AcToolSeg.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Modificar Incidencia", ex)
        End Try
    End Sub
    ' ===================================================Grabar Seguros --> frank 
    Private Sub AcToolSeg_ACBtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcToolSeg.ACBtnGrabar_Click
        Dim msg As String = ""
        Try
            If ACFramework.ACUtilitarios.DatosOk(pnlSeguros, msg) Then
                m_etran_segurosvehiculos.SEGVH_FecAdquisicion = dtpSegFecAdquisicion.Value
                m_etran_segurosvehiculos.SEGVH_FecFin = dtpSegFecFin.Value
                m_etran_segurosvehiculos.SEGVH_Estado = "I"
                m_etran_segurosvehiculos.SEGVH_FecInicio = dtpSegFecInicio.Value
                m_etran_segurosvehiculos.SEGVH_Id = managerTRAN_TRAN_VehiculosSeguros.getCorrelativo()
                managerTRAN_TRAN_VehiculosSeguros.setTRAN_VehiculosSeguros(m_etran_segurosvehiculos)
                If managerTRAN_TRAN_VehiculosSeguros.Guardar(GApp.Usuario) Then
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Grabado satisfactoriamente")
                    AcToolSeg.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Guardar)
                    If managerTRAN_TRAN_VehiculosSeguros.getTRAN_VehiculosSeguros.Nuevo Then
                        m_etran_vehiculos.ListVSeguros.Add(managerTRAN_TRAN_VehiculosSeguros.getTRAN_VehiculosSeguros)
                        setDatos(Seguros.Todos)
                    End If
                    setInstanciaSeguros(False)
                    AddHandler bs_btran_segurosvehiculos.CurrentChanged, AddressOf bs_SegurosVehiculos_CurrentChanged
                    bs_SegurosVehiculos_CurrentChanged(Nothing, Nothing)
                End If
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No se puede Grabar la Incidencia por que existen campos obligatorios vacios", msg)
            End If
        Catch ex As Exception
            AcToolSeg.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Grabar Incidencia", ex)
        End Try
    End Sub

    Private Sub AcToolSeg_ACBtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcToolSeg.ACBtnCancelar_Click
        Try
            UBSeguros()
            m_etran_segurosvehiculos = CType(bs_btran_segurosvehiculos.Current, ETRAN_VehiculosSeguros)
            ACFramework.ACUtilitarios.ACSetControl(pnlSeguros, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
            ACFramework.ACUtilitarios.ACLimpiaVar(pnlSeguros)
            setInstanciaSeguros(False)
            AddHandler bs_btran_segurosvehiculos.CurrentChanged, AddressOf bs_SegurosVehiculos_CurrentChanged
            bs_SegurosVehiculos_CurrentChanged(Nothing, Nothing)
            ABSeguros()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cancelar Ingreso de Incidencia", ex)
        End Try
    End Sub
#End Region
#End Region

#Region " Botones de asignación Ranflas "
    Private Sub btnRanAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRanAsignar.Click
        Try
            If Not IsNothing(bs_bDTRAN_Ranflas.Current) Then
                CType(bs_bDTRAN_Ranflas.Current, ETRAN_VehiculosRanflas).VEHRN_FecDesasignacion = Nothing
                CType(bs_bDTRAN_Ranflas.Current, ETRAN_VehiculosRanflas).VEHRN_FecAsignacion = DateTime.Now
                CType(bs_bDTRAN_Ranflas.Current, ETRAN_VehiculosRanflas).VEHRN_Estado = BConstantes.getEstado(BConstantes.EstadoRelacionados.Activo)
                CType(bs_bDTRAN_Ranflas.Current, ETRAN_VehiculosRanflas).VEHIC_Id = m_etran_vehiculos.VEHIC_Id
                CType(bs_bDTRAN_Ranflas.Current, ETRAN_VehiculosRanflas).VEHRN_Id = managerTRAN_VehiculosRanflas.getCorrelativo()
                CType(bs_bDTRAN_Ranflas.Current, ETRAN_VehiculosRanflas).Instanciar(ACEInstancia.Nuevo)
                managerTRAN_VehiculosRanflas.setTRAN_VehiculosRanflas(CType(bs_bDTRAN_Ranflas.Current, ETRAN_VehiculosRanflas))
                If managerTRAN_VehiculosRanflas.Guardar(GApp.Usuario) Then
                    m_etran_vehiculos.ListATRAN_Ranflas.Add(CType(bs_bDTRAN_Ranflas.Current, ETRAN_VehiculosRanflas))
                    CType(bs_bDTRAN_Ranflas.DataSource, List(Of ETRAN_VehiculosRanflas)).Remove(CType(bs_bDTRAN_Ranflas.Current, ETRAN_VehiculosRanflas))
                    setDatos(RanflaTipoGrilla.Todos)
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Asignar Ranfla", ex)
        End Try
    End Sub

    Private Sub btnRanQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRanQuitar.Click
        Try
            If Not IsNothing(bs_bDTRAN_Ranflas) And Not IsNothing(bs_bATRAN_Ranflas.Current) Then
                CType(bs_bATRAN_Ranflas.Current, ETRAN_VehiculosRanflas).VEHRN_FecDesasignacion = DateTime.Now
                CType(bs_bATRAN_Ranflas.Current, ETRAN_VehiculosRanflas).VEHRN_Estado = BConstantes.getEstado(BConstantes.EstadoRelacionados.Inactivo)
                CType(bs_bATRAN_Ranflas.Current, ETRAN_VehiculosRanflas).Instanciar(ACEInstancia.Modificado)
                CType(bs_bATRAN_Ranflas.Current, ETRAN_VehiculosRanflas).VEHIC_Id = m_etran_vehiculos.VEHIC_Id
                managerTRAN_VehiculosRanflas.setTRAN_VehiculosRanflas(CType(bs_bATRAN_Ranflas.Current, ETRAN_VehiculosRanflas))
                If managerTRAN_VehiculosRanflas.Guardar(GApp.Usuario) Then
                    CType(bs_bDTRAN_Ranflas.DataSource, List(Of ETRAN_VehiculosRanflas)).Add(CType(bs_bATRAN_Ranflas.Current, ETRAN_VehiculosRanflas))
                    m_etran_vehiculos.ListATRAN_Ranflas.Remove(CType(bs_bATRAN_Ranflas.Current, ETRAN_VehiculosRanflas))
                    managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Ranflas)
                    setDatos(RanflaTipoGrilla.Todos)
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Quitar Ranfla asignada", ex)
        End Try
    End Sub
#End Region

#Region " Botones de asignación Conductores "
    Private Sub btnCondAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConAsignar.Click
        Try
            If Not IsNothing(bs_bDTRAN_Conductores.Current) Then
                If m_etran_vehiculos.ListATRAN_Conductores.Count >= m_nroConductores Then
                    ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, String.Format("No se puede Agregar mas de {0} Conductores", m_nroConductores))
                    btnConAsignar.Enabled = False
                    Return
                End If
                btnConQuitar.Enabled = True

                CType(bs_bDTRAN_Conductores.Current, ETRAN_VehiculosConductores).VHCON_FecHasta = Nothing
                CType(bs_bDTRAN_Conductores.Current, ETRAN_VehiculosConductores).VHCON_FecDesde = DateTime.Now
                CType(bs_bDTRAN_Conductores.Current, ETRAN_VehiculosConductores).VHCON_Estado = BConstantes.getEstado(BConstantes.EstadoRelacionados.Activo)
                CType(bs_bDTRAN_Conductores.Current, ETRAN_VehiculosConductores).VEHIC_Id = m_etran_vehiculos.VEHIC_Id

                managerTRAN_VehiculosConductores.setTRAN_VehiculosConductores(CType(bs_bDTRAN_Conductores.Current, ETRAN_VehiculosConductores))
                CType(bs_bDTRAN_Conductores.Current, ETRAN_VehiculosConductores).Instanciar(ACEInstancia.Nuevo)
                managerTRAN_VehiculosConductores.TRAN_VehiculosConductores.VHCON_Id = managerTRAN_VehiculosConductores.getCorrelativo()
                If managerTRAN_VehiculosConductores.Guardar(GApp.Usuario) Then
                    If IsNothing(m_etran_vehiculos.ListATRAN_Conductores) Then m_etran_vehiculos.ListATRAN_Conductores = New List(Of ETRAN_VehiculosConductores)()
                    m_etran_vehiculos.ListATRAN_Conductores.Add(CType(bs_bDTRAN_Conductores.Current, ETRAN_VehiculosConductores))
                    CType(bs_bDTRAN_Conductores.DataSource, List(Of ETRAN_VehiculosConductores)).Remove(CType(bs_bDTRAN_Conductores.Current, ETRAN_VehiculosConductores))
                    setDatos(ConductoresGrilla.Todos)
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Asignar Ranfla", ex)
        End Try
    End Sub

    Private Sub btnCondQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConQuitar.Click
        Try
            If Not IsNothing(bs_bDTRAN_Conductores) And Not IsNothing(bs_bATRAN_Conductores.Current) Then
                CType(bs_bATRAN_Conductores.Current, ETRAN_VehiculosConductores).VHCON_FecHasta = DateTime.Now
                CType(bs_bATRAN_Conductores.Current, ETRAN_VehiculosConductores).VHCON_Estado = BConstantes.getEstado(BConstantes.EstadoRelacionados.Inactivo)
                CType(bs_bATRAN_Conductores.Current, ETRAN_VehiculosConductores).Instanciar(ACEInstancia.Modificado)
                CType(bs_bATRAN_Conductores.Current, ETRAN_VehiculosConductores).VEHIC_Id = m_etran_vehiculos.VEHIC_Id
                managerTRAN_VehiculosConductores.setTRAN_VehiculosConductores(CType(bs_bATRAN_Conductores.Current, ETRAN_VehiculosConductores))
                If managerTRAN_VehiculosConductores.Guardar(GApp.Usuario) Then
                    CType(bs_bDTRAN_Conductores.DataSource, List(Of ETRAN_VehiculosConductores)).Add(CType(bs_bATRAN_Conductores.Current, ETRAN_VehiculosConductores))
                    m_etran_vehiculos.ListATRAN_Conductores.Remove(CType(bs_bATRAN_Conductores.Current, ETRAN_VehiculosConductores))
                    managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Conductores)
                    setDatos(ConductoresGrilla.Todos)
                End If
                If m_etran_vehiculos.ListATRAN_Conductores.Count >= m_nroConductores Then
                    btnConQuitar.Enabled = False
                    Return
                End If
                btnConAsignar.Enabled = True
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Quitar Ranfla asignada", ex)
        End Try
    End Sub
#End Region

    Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
        Try
            busqueda(txtBusqueda.Text)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
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
                setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                cargar()
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar el registro seleccionado", ex)
        End Try

    End Sub

    Private Sub TabAdicionales_SelectionChanged(ByVal sender As Crownwood.DotNetMagic.Controls.TabControl, ByVal oldPage As Crownwood.DotNetMagic.Controls.TabPage, ByVal newPage As Crownwood.DotNetMagic.Controls.TabPage)
        Try
            Select Case sender.SelectedTab.Name.ToString()
                Case "TabMantVehiculo"
                    managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Mantenimiento)
                    setDatos(MantenimientoTipo.Todos)
                Case "TabConductores"
                    managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Conductores)
                    setDatos(ConductoresGrilla.Todos)
                    setAsigConductores(True)
                Case "TabCCombustible"
                    managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Combustible)
                    setDatos(ConsumoCombustible.Todos)
                Case "TabMantVehiculo_Preventivo" 'Mantenimiento Preventivo cuando se Presione el tab del panel
                    managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.MantenimientoPreventivo)
                    setDatos(MantenimientoTipo.Todos)
                Case "TabIncidencias"
                    managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Incidencias)
                    setDatos(Incidencias.Todos)
                Case "TabSeguros"
                    managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Seguros)
                    setDatos(Seguros.Todos)
                    setInstanciaSeguros(False)
                    ACFramework.ACUtilitarios.ACSetControl(pnlSeguros, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
            End Select
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cargar " & sender.SelectedTab.ToString(), ex)
        End Try
    End Sub
#End Region

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        txtBusqueda_ACAyudaClick(sender, e)
    End Sub

    Private Sub tsbtnAddIncidencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAddIncidencia.Click
        Try
            Dim frmIncVehic As New PVehiculosIncidencias(m_etran_vehiculos.VEHIC_Id)
            If frmIncVehic.ShowDialog() = Windows.Forms.DialogResult.OK Then
                managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Incidencias)
                setDatos(Incidencias.Todos)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Agregar Ingreso de Viaje", ex)
        End Try
    End Sub

    Private Sub tsbtnQuitIncidencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnQuitIncidencia.Click
        Try
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar el ingreso de viaje: {0}", Me.Text) _
                , "¿Desea quitar el ingreso de viaje seleccionado? " _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                'managerAdministracionViajes.eliminarViajesIngresos(CType(bs_tran_viajesingresos.Current, ETRAN_ViajesIngresos).VINGR_ID)
                ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Eliminado satisfactoriamente")

            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Quitar Incidencia de Viaje", ex)
        End Try
    End Sub

    Private Sub tsbtnEnviarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnEnviarExcel.Click
        Utilitarios.ExportarXLS(c1grdBusqueda, String.Format("Vehiculos"))
    End Sub

    Private Sub ToolStripButton28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton28.Click
        Utilitarios.ExportarXLS(c1grdComConsumido, String.Format("Consumo"))
    End Sub

#Region "ToolbarDeMatenimientoPreventivo"
    Private Sub AcToolBarMantPrevVertical1_ACBtnNuevo_Click(sender As Object, e As EventArgs) Handles AcToolBarMantPrev.ACBtnNuevo_Click
        'Nuevo para el Mantenimiento de Mantenimientos Preventivos 
        'UBMantenimientos()
        Try
            ' UBSeguros()
            UBMantenimientos()
            RemoveHandler bs_btran_mantenimientosPreventivo.CurrentChanged, AddressOf bs_MantenimientosPrevVehiculos_CurrentChanged
            m_etran_mantenimientosPrev_vehiculos = New ETRAN_VehiculosMantenimiento()
            m_etran_mantenimientosPrev_vehiculos.Instanciar(ACEInstancia.Nuevo)
            m_etran_mantenimientosPrev_vehiculos.VEHIC_Id = m_etran_vehiculos.VEHIC_Id
            ACFramework.ACUtilitarios.ACSetControl(Panel_MantenimientoPrev, False, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
            ACFramework.ACUtilitarios.ACLimpiaVar(Panel_MantenimientoPrev)
            setInstanciaMantenimientoPrev(True)
            txtMantenimientoPrevTiposCod.Text = "MNT002"
            ABMantenimientoPrev()
            AcToolBarMantPrev.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Nuevo)
            'AcToolSeg.ACBtnCancelar.Visible=False
        Catch ex As Exception
            AcToolBarMantPrev.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Ingresar Mantenimientos :)", ex)
        End Try
    End Sub

    Private Sub AcToolBarMantPrev_ACBtnCancelar_Click(sender As Object, e As EventArgs) Handles AcToolBarMantPrev.ACBtnCancelar_Click
        'evento cancelar para Mantenimineto Preventivo 
        Try
            UBMantenimientos()
            m_etran_mantenimientosPrev_vehiculos = CType(bs_btran_mantenimientosPreventivo.Current, ETRAN_VehiculosMantenimiento)
            ACFramework.ACUtilitarios.ACSetControl(Panel_MantenimientoPrev, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
            ACFramework.ACUtilitarios.ACLimpiaVar(Panel_MantenimientoPrev)
            setInstanciaMantenimientoPrev(False)
            setInstanciaLimpiarControlesMantenimento()
            AddHandler bs_btran_mantenimientosPreventivo.CurrentChanged, AddressOf bs_MantenimientosPrevVehiculos_CurrentChanged
            bs_MantenimientosPrevVehiculos_CurrentChanged(Nothing, Nothing)
            ABMantenimientoPrev()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cancelar Ingreso de Mantenimiento", ex)
        End Try
    End Sub

    Private Sub AcToolBarMantPrev_ACBtnModificar_Click(sender As Object, e As EventArgs) Handles AcToolBarMantPrev.ACBtnModificar_Click
        Try
            If Not IsNothing(bs_btran_mantenimientosPreventivo.Current) Then
                UBMantenimientos()
                RemoveHandler bs_btran_mantenimientosPreventivo.CurrentChanged, AddressOf bs_MantenimientosPrevVehiculos_CurrentChanged
                m_etran_mantenimientosPrev_vehiculos = CType(bs_btran_mantenimientosPreventivo.Current, ETRAN_VehiculosMantenimiento)
                ACFramework.ACUtilitarios.ACSetControl(Panel_MantenimientoPrev, False, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
                ACFramework.ACUtilitarios.ACLimpiaVar(Panel_MantenimientoPrev)
                setInstanciaMantenimientoPrev(True)
                ABMantenimientoPrev()
                AcToolBarMantPrev.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
            Else
                AcToolBarMantPrev.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Modificar Incidencia", ex)
        End Try
    End Sub

    Private Sub AcToolBarMantPrev_ACBtnGrabar_Click(sender As Object, e As EventArgs) Handles AcToolBarMantPrev.ACBtnGrabar_Click
        'Funcion para Grabar Los Mantenimientos  Preventivo

        'Funcion para Grabar Los Mantenimientos  Preventivo
        '======================================================================
        'Dim managerETRANDocumento As New ETRAN_Documentos
        'Dim managerTRAN_Documentos As New BTRAN_Documentos
        'managerETRANDocumento = New ETRAN_Documentos
        'managerTRAN_Documentos = New BTRAN_Documentos
        'Dim managerBTRAN_DocumentosDetalles As New BTRAN_DocumentosDetalle
        'managerBTRAN_DocumentosDetalles = New BTRAN_DocumentosDetalle
        'managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle = New ETRAN_DocumentosDetalle
        'Dim managerETRAN_VehiculosMantenimiento As New ETRAN_VehiculosMantenimiento

        'Dim msg As String = ""
        'Try
        '    If ACFramework.ACUtilitarios.DatosOk(Panel_MantenimientoPrev, msg) Then
        '        'Sacando Correlativo para Documento  
        '        _numero_correlativo_documento = managerTRAN_Documentos.getCorrelativo_DocusCodigo("DOCUS_Codigo")
        '        'CV4080000345   = este es el numero maximo creado no se cuando .. OJO  .. ya estaba creado asi Frank 
        '        Dim prefijo As String = _numero_correlativo_documento.Substring(0, 2)
        '        Dim parteNumerica As Integer = Integer.Parse(_numero_correlativo_documento.Substring(3))
        '        ' Incrementar la parte numérica
        '        parteNumerica += 1
        '        Dim nuevoCodigo As String = prefijo & parteNumerica.ToString("D10")

        '        '*****************************detalles_documentos********************************
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DOCUS_Codigo = nuevoCodigo
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DCDET_Cantidad = 1
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DCDET_Descripcion = "MNT_Creado para Viajes sin Items"
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DCDET_Estado = "I"
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DCDET_FecCrea = Date.Now()
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DCDET_Importe = 1
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DCDET_Item = 1
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DCDET_Precio = 1
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DCDET_SubImporte = 1
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.DCDET_UsrCrea = GApp.DataUsuario.USER_DNI
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.ENTID_Codigo = GApp.DataUsuario.USER_DNI
        '        managerBTRAN_DocumentosDetalles.TRAN_DocumentosDetalle.ENTID_RazonSocial = GApp.DataUsuario.USER_Nombre
        '        managerTRAN_Documentos.TRAN_Documentos = New ETRAN_Documentos()
        '        managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento = New ETRAN_VehiculosMantenimiento()
        '        managerTRAN_Documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}", nuevoCodigo)
        '        managerETRANDocumento.DOCUS_Codigo = String.Format("{0}", nuevoCodigo)

        '        '==================================================managerTRAN_Documentos ====================================================================================
        '        managerTRAN_Documentos.TRAN_Documentos.PVENT_Id = GApp.PuntoVenta
        '        managerTRAN_Documentos.TRAN_Documentos.ENTID_Codigo = GApp.DataUsuario.USER_DNI
        '        managerTRAN_Documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = Colecciones.Tipos(ETipos.MyTipos.TipoMoneda)(0).TIPOS_Codigo
        '        managerTRAN_Documentos.TRAN_Documentos.TIPOS_CodTipoDocumento = Colecciones.Tipos(ETipos.MyTipos.TipoDocComprobante)(0).TIPOS_Codigo
        '        'managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ENTID_CodigoResponsable = GApp.DataUsuario.USER_DNI
        '        managerTRAN_Documentos.TRAN_Documentos.DOCUS_Serie = "0000"
        '        managerTRAN_Documentos.TRAN_Documentos.DOCUS_Numero = parteNumerica
        '        managerTRAN_Documentos.TRAN_Documentos.DOCUS_Fecha = DateTimePicker1.Value
        '        managerTRAN_Documentos.TRAN_Documentos.DOCUS_TotalPago = 1
        '        managerTRAN_Documentos.TRAN_Documentos.DOCUS_Importe = 1
        '        managerTRAN_Documentos.TRAN_Documentos.DOCUS_ImporteIGV = 1
        '        managerTRAN_Documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)
        '        MessageBox.Show("Grabado supuestamente")
        '        If managerTRAN_Documentos.Guardar(GApp.Usuario, True, True) Then
        '            m_etran_mantenimientosPrev_vehiculos = New ETRAN_VehiculosMantenimiento
        '            m_etran_mantenimientosPrev_vehiculos.Instanciar(ACEInstancia.Nuevo)
        '            m_etran_mantenimientosPrev_vehiculos.VMAN_FecRealizacion = dtpSegFecAdquisicion.Value

        '            m_etran_mantenimientosPrev_vehiculos.VMAN_Estado = "I"
        '            m_etran_mantenimientosPrev_vehiculos.VMAN_Km = txtMantenimientoPrevKm.Text
        '            m_etran_mantenimientosPrev_vehiculos.VMAN_Observaciones = txtMantenimientoPrevDescripcion.Text
        '            m_etran_mantenimientosPrev_vehiculos.ENTID_CodigoResponsable = GApp.DataUsuario.USER_DNI

        '            m_etran_mantenimientosPrev_vehiculos.ENTID_Codigo = GApp.DataUsuario.USER_DNI
        '            m_etran_mantenimientosPrev_vehiculos.ENTID_Proveedor = GApp.DataUsuario.USER_DNI
        '            m_etran_mantenimientosPrev_vehiculos.ENTID_RazonSocial = GApp.DataUsuario.USER_Nombre
        '            m_etran_mantenimientosPrev_vehiculos.VEHIC_Id = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
        '            m_etran_mantenimientosPrev_vehiculos.VEHIC_Placa = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Placa
        '            'm_etran_mantenimientosPrev_vehiculos.VMAN_Item = 99 'le ponemos 0 porque esto no influencia ... a diferencia del otro que amarra por factura 
        '            m_etran_mantenimientosPrev_vehiculos.VMAN_Item = managerTRAN_VehiculosViajesMantenimiento.getCorrelativoSelectId_Max_VmanItem("VMAN_Item", m_etran_mantenimientosPrev_vehiculos.VEHIC_Id)
        '            m_etran_mantenimientosPrev_vehiculos.TIPOS_CodTipoMantenimiento = txtMantenimientoPrevTiposCod.Text
        '            m_etran_mantenimientosPrev_vehiculos.VMAN_Viaje = True ' ESTO SE PUESO PARA VER SI ESTE DATO SE RESTA CON EL VIAJE 

        '            managerTRAN_VehiculosMantenimiento.setTRAN_VehiculosMantenimientos(m_etran_mantenimientosPrev_vehiculos)
        '            If managerTRAN_VehiculosMantenimiento.Guardar(GApp.Usuario, True) Then
        '                ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
        '                setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
        '            End If
        '        End If



        '    Else
        '        ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No se puede Grabar el Mantenimiento por que existen campos obligatorios vacios", msg)
        '    End If
        'Catch ex As Exception
        '    AcToolBarMantPrev.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
        '    ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Grabar Mantenimiento", ex)
        'End Try

        '**********************************************************************GRABADO ANTERIOR *********************************
        Try

            m_etran_mantenimientosPrev_vehiculos = New ETRAN_VehiculosMantenimiento
            managerTRAN_VehiculosMantenimiento = New BTRAN_VehiculosMantenimiento
            m_etran_mantenimientosPrev_vehiculos.Instanciar(ACEInstancia.Nuevo)
            m_etran_mantenimientosPrev_vehiculos.VMAN_FecRealizacion = dtpSegFecAdquisicion.Value
            m_etran_mantenimientosPrev_vehiculos.VMAN_Estado = "I"
            m_etran_mantenimientosPrev_vehiculos.VMAN_Km = txtMantenimientoPrevKm.Text
            m_etran_mantenimientosPrev_vehiculos.VMAN_Observaciones = txtMantenimientoPrevDescripcion.Text
            m_etran_mantenimientosPrev_vehiculos.ENTID_CodigoResponsable = GApp.DataUsuario.USER_DNI
            m_etran_mantenimientosPrev_vehiculos.ENTID_Codigo = GApp.DataUsuario.USER_DNI
            m_etran_mantenimientosPrev_vehiculos.ENTID_Proveedor = GApp.DataUsuario.USER_DNI
            m_etran_mantenimientosPrev_vehiculos.ENTID_RazonSocial = GApp.DataUsuario.USER_Nombre
            m_etran_mantenimientosPrev_vehiculos.VEHIC_Id = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
            m_etran_mantenimientosPrev_vehiculos.VEHIC_Placa = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Placa
            'm_etran_mantenimientosPrev_vehiculos.VMAN_Item = 99 'le ponemos 0 porque esto no influencia ... a diferencia del otro que amarra por factura 
            m_etran_mantenimientosPrev_vehiculos.VMAN_Item = managerTRAN_VehiculosMantenimiento.getCorrelativoSelectId_Max_VmanItem("VMAN_Item", m_etran_mantenimientosPrev_vehiculos.VEHIC_Id)
            m_etran_mantenimientosPrev_vehiculos.TIPOS_CodTipoMantenimiento = txtMantenimientoPrevTiposCod.Text
            m_etran_mantenimientosPrev_vehiculos.VMAN_Viaje = True ' ESTO SE PUESO PARA VER SI ESTE DATO SE RESTA CON EL VIAJE 
            managerTRAN_VehiculosMantenimiento.setTRAN_VehiculosMantenimientos(m_etran_mantenimientosPrev_vehiculos)
            If managerTRAN_VehiculosMantenimiento.Guardar(GApp.Usuario) Then
                ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Grabado satisfactoriamente")
                AcToolBarMantPrev.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Guardar)
                If managerTRAN_VehiculosMantenimiento.getTRAN_VehiculosMantenimiento.Nuevo Then
                    m_etran_vehiculos.ListVMantenimiento.Add(managerTRAN_VehiculosMantenimiento.getTRAN_VehiculosMantenimiento)
                    setDatos(MantenimientoTipo.MatenimientoPreventivo)
                End If

                setInstanciaMantenimientoPrev(False)
                AddHandler bs_btran_mantenimientosPreventivo.CurrentChanged, AddressOf bs_MantenimientosPrevVehiculos_CurrentChanged
                bs_MantenimientosPrevVehiculos_CurrentChanged(Nothing, Nothing)
            End If

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Grabar Mantenimiento", ex)
        End Try
        '    Else
        '            ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No se puede Grabar el Mantenimiento por que existen campos obligatorios vacios", msg)
        '    End If
        'Catch ex As Exception
        '    AcToolBarMantPrev.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
        '    ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Grabar Mantenimiento", ex)
        'End Try
    End Sub

    Private Sub AcToolBarMantPrev_ACBtnEliminar_Click(sender As Object, e As EventArgs) Handles AcToolBarMantPrev.ACBtnEliminar_Click
        'evento para eliminar un Mantenimiento cosa que no deberia ser asi porque siempre debe haber un 
        Try

            ' FALTA TERMINAR EL BORRADO DEL MANTENIMEINTOS POR FRANK 
            If Not IsNothing(bs_btran_mantenimientosPreventivo.Current) Then
                If ACControles.ACDialogos.ACMostrarMensajePregunta("Eliminar Registro: " & Convert.ToString(Me.Text) _
                   , "Desea eliminar el registro Nro : " & CType(bs_btran_mantenimientosPreventivo.Current, ETRAN_VehiculosMantenimiento).VMAN_Id.ToString() _
                   , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

                    'Era EKliminar pero lo cambie a modificar frank 
                    m_etran_mantenimientosPrev_vehiculos = CType(bs_btran_mantenimientosPreventivo.Current, ETRAN_VehiculosMantenimiento)
                    m_etran_mantenimientosPrev_vehiculos.VMAN_Estado = "X"
                    managerTRAN_VehiculosMantenimiento.setTRAN_VehiculosMantenimientos(m_etran_mantenimientosPrev_vehiculos)
                    m_etran_mantenimientosPrev_vehiculos.Instanciar(ACEInstancia.Eliminado)
                    If managerTRAN_VehiculosMantenimiento.Guardar(GApp.Usuario) Then
                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Eliminado satisfactoriamente")
                        'managerTRAN_VehiculosMantenimiento.CargarSinDetalle(m_etran_mantenimientosPrev_vehiculos.VMAN_Id, m_etran_vehiculos.VEHIC_Id) 'x_mantid y el xvehi_id
                        'setDatos(MantenimientoTipo.MatenimientoPreventivo)
                        managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.MantenimientoPreventivo)
                        setDatos(MantenimientoTipo.Todos)
                    End If
                End If
            End If

            'If Not IsNothing(bs_btran_segurosvehiculos.Current) Then
            '    If ACControles.ACDialogos.ACMostrarMensajePregunta("Eliminar Registro: " & Convert.ToString(Me.Text) _
            '       , "Desea eliminar el registro Nro : " & CType(bs_btran_mantenimientosPreventivo.Current, ETRAN_VehiculosMantenimiento).VMAN_Id.ToString() _
            '       , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

            '        'Era EKliminar pero lo cambie a modificar frank 
            '        'managerTRAN_TRAN_VehiculosSeguros.TRAN_VehiculosSeguros.SEGVH_Estado = "X"
            '        m_etran_segurosvehiculos.Instanciar(ACEInstancia.Modificado)
            '        m_etran_segurosvehiculos.SEGVH_Estado = "X"
            '        managerTRAN_TRAN_VehiculosSeguros.setTRAN_VehiculosSeguros(m_etran_segurosvehiculos)
            '        ' CType(bs_btran_segurosvehiculos.Current, ETRAN_VehiculosSeguros).SEGVH_Estado = "X"
            '        If managerTRAN_TRAN_VehiculosSeguros.Guardar(GApp.Usuario) Then
            '            ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Eliminado satisfactoriamente")
            '            managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Seguros)
            '            setDatos(Seguros.Todos)
            '        End If
            '    End If
            'End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Anular Incidencia", ex)
        End Try
    End Sub

    Private Sub ComboBoxPrevTipMantenimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPrevTipMantenimiento.SelectedIndexChanged
        If (ComboBoxPrevTipMantenimiento.Text = "MANTTO PREVENTIVO") Then
            txtMantenimientoPrevTiposCod.Text = "MNT002"
        ElseIf (ComboBoxPrevTipMantenimiento.Text = "MANTTO CORRECTIVO") Then
            txtMantenimientoPrevTiposCod.Text = "MNT003"
        ElseIf (ComboBoxPrevTipMantenimiento.Text = "MANTTO PREDICTIVO") Then
            txtMantenimientoPrevTiposCod.Text = "MNT004"
        Else
            txtMantenimientoPrevTiposCod.Text = "MNT002"
        End If
    End Sub

    Private Sub BtnInfoMantenimiento_MouseHover(sender As Object, e As EventArgs)
        'ToolTip_infoMantenimientoPrev.Active = True
        'ToolTip_infoMantenimientoPrev.text = ""
    End Sub

    'Private Sub actxaBusquedaXNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles actxaBusquedaXNombre.KeyPress
    '    'Busqueda ... por nombres 


    'End Sub

    Private Sub BtnConductorReset_Click(sender As Object, e As EventArgs) Handles BtnConductorReset.Click
        'Reset VOLVER A Mostrar todos los Conductores  '08-11-2025 
                        managerTRAN_Vehiculos.Cargar(ETRAN_Vehiculos.Inicializacion.Conductores)
                        setDatos(ConductoresGrilla.Todos)
                        TabAdicionales.SelectedTab = TabConductores
          actxaBusquedaXNombre.Clear()
    End Sub
    Private Sub actxaBusquedaXNombre_KeyUp(sender As Object, e As KeyEventArgs) Handles actxaBusquedaXNombre.KeyUp
              Try

                       
        Dim x_nombreABuscar As String  =  actxaBusquedaXNombre.Text
               'managerTRAN_Vehiculos.Cargar(x_codigo, ETRAN_Vehiculos.Inicializacion.)
        Dim BINDING_Conductores As  New  BindingSource()
         managerTRAN_Vehiculos.CargarConductorXNombre(x_nombreABuscar)
                      '  TabAdicionales.SelectedTab = TabMantVehiculo_Preventivo
                       ' setDatos(MantenimientoTipo.MatenimientoPreventivo)
           binding_Conductores.DataSource = managerTRAN_Vehiculos.TRAN_Vehiculos.ListATRAN_Conductores
        c1grdConDisponibles.DataSource = binding_Conductores 
Catch ex As Exception
            MessageBox.Show(ex.Message)
End Try
    End Sub
#End Region
End Class