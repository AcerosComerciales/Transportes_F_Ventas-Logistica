Imports ACBTransporte
Imports ACETransporte
Imports ACEVentas

Imports ACFramework

Public Class FFlete
#Region " Variables "
    Private managerTRAN_Fletes As BTRAN_Fletes
    Private managerTRAN_VehiculosConductores As BTRAN_VehiculosConductores
    Private managerTRAN_Rutas As BTRAN_Rutas
    Private managerAdministracionViajes As BAdministracionViajes
    Private m_etran_fletes As ETRAN_Fletes
    Private m_listBindHelper As List(Of ACBindHelper)
    Private m_opcion As TipoIni
    Private m_viaje As ETRAN_Viajes




    'BindingsSource --------------------------------------------------------
    Private bs_btran_vehiculos As BindingSource
    Private bs_btran_neumaticos As BindingSource

    Private bs_btran_ViajesNeumaticos As BindingSource 'Variable  para el BindingSource de ViajesNeumaticos


    Private bs_bATRAN_Ranflas As BindingSource
    Private bs_bATRAN_Neumaticos As BindingSource 'NEUMATICOS Bindings A  Source
    Private bs_bDTRAN_Ranflas As BindingSource
    Private bs_bDTRAN_Neumaticos As BindingSource 'Nuematicos Bindings D Sources 
    Private bs_bHTRAN_Ranflas As BindingSource

    '   Private bs_bDTRAN_Neumaticos As BindingSource 'NEUMATICOS BINGINDG SOURCCES 

    Private bs_bATRAN_Conductores As BindingSource
    Private bs_bDTRAN_Conductores As BindingSource
    Private bs_bHTRAN_Conductores As BindingSource

    Private bs_btran_mantenimientos As BindingSource
    Private bs_btran_combustibleconsumo As BindingSource
    Private bs_btran_incidenciasvehiculos As BindingSource
    Private bs_btran_segurosvehiculos As BindingSource


    '-----------------------------------------------------------------------

    Private managerTRAN_Vehiculos As BTRAN_Vehiculos
    Private managerTRAN_Ranflas As BTRAN_Ranflas
    '   Private managerTRAN_VehiculosConductores As BTRAN_VehiculosConductores ya esta declarado
    Private managerTRAN_VehiculosMantenimiento As BTRAN_VehiculosMantenimiento
    Private managerTRAN_VehiculosRanflas As BTRAN_VehiculosRanflas

    Private managerTRAN_IncidenciasVehiculos As BTRAN_VehiculosIncidencias
    Private managerTRAN_TRAN_VehiculosSeguros As BTRAN_VehiculosSeguros

    Private managerTRAN_Neumaticos As BTRAN_Neumaticos 'se usa para los Neumaticos 
    Private m_etran_Neumaticos As ETRAN_Neumaticos
    Private managerTRAN_ViajesNeumaticos As BTRAN_ViajesNeumaticos

    Private m_etran_ViajesNuematicos As ETRAN_ViajesNeumaticos 'Viaje Neumaticos 



    Private m_etran_vehiculos As ETRAN_Vehiculos
    Private m_etran_incidenciasvehiculos As ETRAN_VehiculosIncidencias
    Private m_etran_segurosvehiculos As ETRAN_VehiculosSeguros

    Private m_tipoedicion As TipoEdicion


    Enum TipoEdicion
        Normal
        Ranflas
        Conductores
        Incidencias
        Seguros
    End Enum


    Enum ConductoresGrilla
        Todos
        Disponibles
        Asignados
        Historial
    End Enum


    Enum NeumaticoTipoGrilla
        Todos
        Disponibles
        Asignados
        Historial
    End Enum
    '-----------------------------------------------------------------------

    Enum TipoIni
        Normal
        OrdToFlete
        AgregarFlete
    End Enum



    'VARIABLES PARA COMBOBOX  ================
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
    Public Property TRAN_Fletes() As ETRAN_Fletes
        Get
            Return m_etran_fletes
        End Get
        Set(ByVal value As ETRAN_Fletes)
            m_etran_fletes = value
        End Set
    End Property

#End Region

#Region " Constructores "
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            'tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            'tabMantenimiento.SelectedTab = tabBusqueda

            managerTRAN_Fletes = New BTRAN_Fletes
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            acTool.ACBtnBuscarVisible = False
            m_opcion = TipoIni.Normal
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

    Public Sub New(ByVal x_tran_cotizaciones As ETRAN_Cotizaciones)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            setInicio(x_tran_cotizaciones)
            tabMantenimiento.TabPages.Remove(tabBusqueda)
            m_opcion = TipoIni.OrdToFlete
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

    Public Sub New(ByVal x_viaje As ETRAN_Viajes, ByVal x_tran_cotizaciones As ETRAN_Cotizaciones, ByVal x_tran_vehiculo As ETRAN_Vehiculos,
                  ByVal x_conductor As EEntidades, ByVal x_vhcon_id As Long)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            setInicio(x_tran_cotizaciones)

            actxaCodVehiculo.ACAyuda.Enabled = False
            actxaCodVehiculo.ReadOnly = True
            actxaCodVehiculo.Text = x_tran_vehiculo.VEHIC_Codigo
            actxaCodVehiculo.ACActivarAyuda = False
            actxaPlaca.ACAyuda.Enabled = False
            actxaPlaca.ReadOnly = True
            actxaPlaca.Text = x_tran_vehiculo.VEHIC_Placa
            actxaPlaca.ACActivarAyuda = False
            m_etran_fletes.VHCON_Id = x_vhcon_id
            m_opcion = TipoIni.AgregarFlete

            actxaCodVehiculo.Text = x_tran_vehiculo.VEHIC_Id
            actxaPlaca.Text = x_tran_vehiculo.VEHIC_Placa

            txtViaje.Text = x_viaje.VIAJE_Id
            txtIdConductor.Text = x_viaje.VIAJE_IdxConductor
            txtGlosa.Text = x_viaje.VIAJE_Descripcion

            txtCodConductor.Text = x_conductor.ENTID_Codigo
            txtConductor.Text = x_conductor.ENTID_RazonSocial
            txtCodCliente.Text = x_tran_cotizaciones.ENTID_Codigo.Substring(1)
            txtRuta.Text = x_tran_cotizaciones.RUTAS_Nombre
            actxtdireccion_origen.Text = x_tran_cotizaciones.COTIZ_DireccionPuntoOrigen
            actxtdireccion_destino.Text = x_tran_cotizaciones.COTIZ_DireccionPuntoDestino


            actxnTotalValorReferencial.Text = x_tran_cotizaciones.COTIZ_TotalValorReferencial


            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            acTool.ACBtnSalirVisible = False
            acTool.ACBtnCancelarVisible = False

            m_viaje = x_viaje
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

#End Region
#Region "Cargar Combobox"
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

                If actxtdireccion_origen.Text = CType(bd_direcciones_origen.Current, EDirecciones).DIREC_Id Then
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

                If actxtdireccion_destino.Text = CType(bd_direcciones_destino.Current, EDirecciones).DIREC_Id Then
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

    Private Sub setInicio(ByVal x_tran_cotizaciones As ETRAN_Cotizaciones)
        Try
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabDatos

            managerTRAN_Fletes = New BTRAN_Fletes
            managerAdministracionViajes = New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            managerTRAN_VehiculosConductores = New BTRAN_VehiculosConductores
            managerTRAN_Rutas = New BTRAN_Rutas

            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            acTool.ACBtnBuscarVisible = False

            cargarCombos()
            'CargarCombosUbigeosOrigen()
            'CargarCombosUbigeosDestino()
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)

            m_etran_fletes = New ETRAN_Fletes()
            m_etran_fletes.Instanciar(ACEInstancia.Nuevo)
            m_etran_fletes.ENTID_Codigo = x_tran_cotizaciones.ENTID_Codigo
            m_etran_fletes.COTIZ_Codigo = x_tran_cotizaciones.COTIZ_Codigo
            m_etran_fletes.RUTAS_Id = x_tran_cotizaciones.RUTAS_Id
            m_etran_fletes.FLETE_TotIngreso = x_tran_cotizaciones.COTIZ_Monto
            m_etran_fletes.FLETE_MontoPorTM = x_tran_cotizaciones.COTIZ_MontoPorTM
            m_etran_fletes.FLETE_Monto = x_tran_cotizaciones.COTIZ_Monto
            m_etran_fletes.FLETE_PesoEnTM = x_tran_cotizaciones.COTIZ_PesoEnTM
            m_etran_fletes.FLETE_ImporteIgv = x_tran_cotizaciones.COTIZ_ImporteIgv
            m_etran_fletes.TIPOS_CodTipoMoneda = x_tran_cotizaciones.TIPOS_CodTipoMoneda
            m_etran_fletes.FLETE_FechaTransaccion = x_tran_cotizaciones.COTIZ_FechaFlete

            m_etran_fletes.FLETE_ValorReferencial = x_tran_cotizaciones.COTIZ_ValorReferencial
            m_etran_fletes.FLETE_TotalValorReferencial = x_tran_cotizaciones.COTIZ_TotalValorReferencial

            actxtdireccion_origen.Text = x_tran_cotizaciones.COTIZ_DireccionPuntoOrigen
            actxtdireccion_destino.Text = x_tran_cotizaciones.COTIZ_DireccionPuntoDestino


            dtpFecLlegada.Value = x_tran_cotizaciones.COTIZ_FechaFlete
            dtpFecProgramada.Value = x_tran_cotizaciones.COTIZ_FechaFlete
            dtpFecSalida.Value = x_tran_cotizaciones.COTIZ_FechaFlete

            '' Cargar Rutas
            Dim _join As New List(Of ACJoin)()
            _join.Add(New ACJoin(EUbigeos.Esquema, EUbigeos.Tabla, "UOri", ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("UBIGO_Codigo", "UBIGO_CODORIGEN")} _
                                 , New ACCampos() {New ACCampos("UBIGO_Descripcion", "UBIGO_Origen")}))
            _join.Add(New ACJoin(EUbigeos.Esquema, EUbigeos.Tabla, "UDes", ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("UBIGO_Codigo", "UBIGO_CODDESTINO")} _
                                 , New ACCampos() {New ACCampos("UBIGO_Descripcion", "UBIGO_Destino")}))
            Dim _where As New Hashtable()
            _where.Add("RUTAS_Id", New ACWhere(m_etran_fletes.RUTAS_Id, ACWhere.TipoWhere.Igual))
            If managerTRAN_Rutas.Cargar(_join, _where) Then
                m_etran_fletes.UBIGO_ORIGEN = managerTRAN_Rutas.TRAN_Rutas.UBIGO_Origen
                m_etran_fletes.UBIGO_DESTINO = managerTRAN_Rutas.TRAN_Rutas.UBIGO_Destino
                txtOrigen.Text = m_etran_fletes.UBIGO_ORIGEN
                txtUbiOrigen.Text = managerTRAN_Rutas.TRAN_Rutas.UBIGO_CodOrigen
                txtDestino.Text = m_etran_fletes.UBIGO_DESTINO
                txtUbiDestino.Text = managerTRAN_Rutas.TRAN_Rutas.UBIGO_CodDestino




                txtCliente.Text = x_tran_cotizaciones.COTIZ_NombreCliente
                txtCodCliente.Text = x_tran_cotizaciones.ENTID_NroDocumento
                txtRuta.Text = x_tran_cotizaciones.RUTAS_Nombre
                txtCodRuta.Text = x_tran_cotizaciones.RUTAS_Id
                actxnMonto.Text = x_tran_cotizaciones.COTIZ_Monto
                actxnTotalValorReferencial.Text = x_tran_cotizaciones.COTIZ_TotalValorReferencial
                cmbTipoMoneda.SelectedValue = x_tran_cotizaciones.TIPOS_CodTipoMoneda




                AsignarBinding()

                eprError.SetError(grpVehiculo, "Campo Obligatorio")
                eprError.SetError(dtpFecLlegada, "Campo Obligatorio")
                eprError.SetError(dtpFecProgramada, "Campo Obligatorio")
                eprError.SetError(dtpFecSalida, "Campo Obligatorio")
                eprError.SetError(dtpHorLlegada, "Campo Obligatorio")
                eprError.SetError(dtpHorProgramada, "Campo Obligatorio")
                eprError.SetError(dtpHorSalida, "Campo Obligatorio")
            End If
            Me.KeyPreview = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " Metodos "

    Private Sub AsignarBinding()
        Try
            m_listBindHelper = New List(Of ACBindHelper)()
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnMonto, "Text", m_etran_fletes, "FLETE_TotIngreso"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotalValorReferencial, "Text", m_etran_fletes, "FLETE_TotalValorReferencial"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cargarCombos()
        Try
            ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AyudaVehiCond(ByVal x_cadena As String, ByVal x_campo As String)
        Try
            If managerTRAN_VehiculosConductores.CargarAyuda(x_cadena, x_campo) Then
                Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Vehiculo", managerTRAN_VehiculosConductores.DTTRAN_VehiculosConductores, False)
                If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    m_etran_fletes.VHCON_Id = Ayuda.Respuesta.Rows(0)("Interno")
                    actxaCodVehiculo.Text = Ayuda.Respuesta.Rows(0)("Cod. Vehiculo").ToString()
                    actxaPlaca.Text = Ayuda.Respuesta.Rows(0)("Placa").ToString()
                    txtCodConductor.Text = Ayuda.Respuesta.Rows(0)("Licencia").ToString()
                    txtConductor.Text = Ayuda.Respuesta.Rows(0)("Conductor").ToString()
                    txtSigla.Text = Ayuda.Respuesta.Rows(0)("Sigla").ToString()
                    txtvehic_mtc.Text = Ayuda.Respuesta.Rows(0)("VEHIC_Certificado").ToString() 'Agregado frank 
                    m_etran_fletes.CONDU_Sigla = txtSigla.Text

                    Dim _tran_viajes As New BTRAN_Viajes
                    txtIdConductor.Text = _tran_viajes.CorrelativoXconductor(Ayuda.Respuesta.Rows(0)("Codigo").ToString(), chkFleteLocal.Checked)
                    txtGlosa.Text = String.Format("Viaje {0} / {3} / {2} : {1} ", txtIdConductor.Text, txtRuta.Text, actxaPlaca.Text, m_etran_fletes.CONDU_Sigla)
                    txtViaje.Text = _tran_viajes.getCorrelativo()

                    Me.KeyPreview = False
                    acTool.Focus()
                    acTool.ACBtnGrabar.Select()
                Else
                    m_etran_fletes.VHCON_Id = 0
                    actxaCodVehiculo.Text = String.Empty
                    actxaPlaca.Text = String.Empty
                End If
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar la ayuda, posiblemente no haya datos que mostrar")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Metodos de Controles"
    Private Function grabar() As Boolean
        Dim msg As String = String.Empty
        Try
            If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) Then
                m_etran_fletes.SUCUR_Id = GApp.Sucursal
                m_etran_fletes.ZONAS_Codigo = GApp.Zona
                m_etran_fletes.PVENT_Id = GApp.PuntoVenta
                If dtpFecLlegada.Checked Then
                    m_etran_fletes.FLETE_FecLlegada = ACFramework.ACUtilitarios.getFecha(dtpFecLlegada.Value, dtpHorLlegada.Value)
                End If
                m_etran_fletes.FLETE_FecProgramada = ACFramework.ACUtilitarios.getFecha(dtpFecProgramada.Value, dtpHorProgramada.Value)
                m_etran_fletes.FLETE_FecSalida = ACFramework.ACUtilitarios.getFecha(dtpFecSalida.Value, dtpHorSalida.Value)
                m_etran_fletes.FLETE_Id = managerTRAN_Fletes.getCorrelativo()
                m_etran_fletes.FLETE_NombreRuta = txtRuta.Text
                m_etran_fletes.FLETE_TotalValorReferencial = actxnTotalValorReferencial.Text
                m_etran_fletes.Flete_DireccionPuntoOrigen = actxtdireccion_origen.Text
                m_etran_fletes.Flete_DireccionPuntoDestino = actxtdireccion_destino.Text
                m_etran_fletes.VEHIC_Certificado = txtvehic_mtc.Text

                If (globales_.x_rutas_id = 0) Then
                Else
                    m_etran_fletes.RUTAS_Id = globales_.x_rutas_id 'AGREGADO FRANK 
                End If
                m_etran_fletes.Ubigo_CodOrigen = txtUbiOrigen.Text 'asiganamos parametros para el Flete
                m_etran_fletes.Ubigo_CodDestino = txtUbiDestino.Text
                managerAdministracionViajes.TRAN_Fletes = m_etran_fletes
                Dim _cviaje As Integer = 1
                Try
                    _cviaje = txtIdConductor.Text
                Catch ex As Exception
                End Try
                Dim _rpta As Boolean
                Select Case m_opcion
                    Case TipoIni.Normal

                    Case TipoIni.OrdToFlete
                        Dim _viaje_id As Long : Dim _flete_id As Long
                        '----------------------------------GUARDAR_FLETE-----------------------------------
                        _rpta = managerAdministracionViajes.GuardarFlete(GApp.Usuario, GApp.FechaProceso.Year.ToString(), False, True, _cviaje, _viaje_id, _flete_id, chkFleteLocal.Checked)
                        Dim _frm As New PGuiasTransporte(_viaje_id, _flete_id) With {.StartPosition = FormStartPosition.CenterScreen, .MaximizeBox = False}
                        'MessageBox.Show(managerTRAN_Fletes.ListTRAN_Fletes.ToString())
                        If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        End If
                    Case TipoIni.AgregarFlete
                        '----------------------------------GUARDAR_FLETE-----------------------------------
                        _rpta = managerAdministracionViajes.GuardarFlete(GApp.Usuario, GApp.FechaProceso.Year.ToString(), m_viaje.VIAJE_Id, True)
                        'MessageBox.Show(managerTRAN_Fletes.ListTRAN_Fletes.ToString())
                End Select
                If _rpta Then
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                    Return True
                Else
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar{0}", msg))
                End If
            Else
                acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar, por que hay campos obligatorios vacios: {0}", msg))
            End If
            Return False
        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
        End Try
    End Function

#Region "ToolBar"
    Public Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
        Dim msg As String = String.Empty
        Try
            Me.KeyPreview = False
            If grabar() Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede grabar", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub acTool_ACBtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click, acTool.ACBtnSalir_Click
        Try
            Me.KeyPreview = False
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cancelar", ex)
        End Try
    End Sub
#End Region

    Private Sub actxaCodVehiculo_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCodVehiculo.ACAyudaClick
        Try
            AyudaVehiCond(actxaCodVehiculo.Text, "VEHIC_Codigo")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Ayuda de Vehiculo", ex)
        End Try
    End Sub

    Private Sub actxaPlaca_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaPlaca.ACAyudaClick
        Try
            AyudaVehiCond(actxaPlaca.Text, "VEHIC_Placa")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Ayuda de Vehiculo", ex)
        End Try
    End Sub

    Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Enter Then
            If sender.Name = "txtBusqueda" Then
                Exit Sub
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCodConductor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodConductor.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.KeyPreview = False
                acTool.Focus()
                acTool.ACBtnGrabar.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region



    Private Sub FFlete_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub actxnTotalValorReferencial_TextChanged(sender As Object, e As EventArgs) Handles actxnTotalValorReferencial.TextChanged

    End Sub

    Private Sub acTool_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles acTool.ItemClicked

    End Sub
End Class