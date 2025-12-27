Imports System.Drawing.Printing
Imports ACBTransporte
Imports ACBVentas
Imports ACETransporte
Imports ACEVentas
Imports ACFramework

Public Class PConsumoAdBlue
#Region " Variables "
    Private managerTRAN_Vehiculos As BTRAN_Vehiculos
    Private managerTRAN_CombustibleConsumo As BTRAN_CombustibleConsumo
    Private managerEntidades As BEntidades
    Private managerReportes As New BTRAN_CombustibleConsumo

    Private m_btran_documentos As New BTRAN_Documentos()
    Private m_listBindHelper As List(Of ACBindHelper)
    Private m_etran_combustibleconsumo As ETRAN_CombustibleConsumo
    Private bs_btran_vehiculos As BindingSource
    Private bs_compras As BindingSource
    Private m_opcion As Origen
    Dim _i As Integer = 1
    Enum Origen
        Normal
        Viajes
    End Enum


#End Region
#Region " Constructores "
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_btran_documentos = New BTRAN_Documentos()
        Try
            setInicio(Origen.Normal, DateTime.Now, 0)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

    Public Sub New(ByVal x_viajes_id As Long, ByVal x_vehic_id As Long, ByVal x_fecha As DateTime)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            setInicio(Origen.Viajes, x_fecha, x_viajes_id)
            m_etran_combustibleconsumo.VIAJE_Id = x_viajes_id
            m_etran_combustibleconsumo.VEHIC_Id = x_vehic_id
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

    Public Sub New(ByVal x_comco_id As Long)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            setInicio(Origen.Viajes, DateTime.Now, 0)
            If managerTRAN_CombustibleConsumo.ObtConCombustible(x_comco_id) Then
                acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)
                m_etran_combustibleconsumo = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo
                AsignarBinding()
                actxaNroDocProveedor.Text = m_etran_combustibleconsumo.ENTID_CodigoProveedor
                actxaDescProveedor.Text = m_etran_combustibleconsumo.ENTID_RazonSocial
                cmbTipoDocumento.SelectedValue = m_etran_combustibleconsumo.TIPOS_CodTipoDocumento
                setInstancia(ACUtilitarios.ACSetInstancia.Modificado)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub
    Private Sub setInicio(ByVal x_opcion As Origen, ByVal x_fecha As DateTime, ByVal x_viajes_id As Long)
        Try
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            'tabMantenimiento.SelectedTab = tabBusqueda
            'formatearGrilla()
            cargarCombos(x_viajes_id)
            managerTRAN_Vehiculos = New BTRAN_Vehiculos
            managerTRAN_CombustibleConsumo = New BTRAN_CombustibleConsumo(GApp.Aplicacion, GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            managerEntidades = New BEntidades

            m_opcion = x_opcion
            Select Case x_opcion
                Case Origen.Normal
                    acTool.ACBtnNuevoEnabled = False
                    dtpComFecha.Value = x_fecha
                Case Origen.Viajes
                    acTool_ACBtnNuevo_Click(Nothing, Nothing)
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                    dtpComFecha.Value = x_fecha
                    'dtpFecViaje.Value = x_fecha
                    'cmbComModoPago.SelectedIndex = 0
                    'cmbComTipoCombustible.SelectedIndex = 0
                    'cmbGuia.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura)
                    'cmbTipoMoneda.SelectedIndex = 0
                    chkComprobante.Checked = False
                    Me.KeyPreview = True
                Case Else
                    setInicio(Origen.Normal, DateTime.Now, 0)
            End Select

            'Cargar Correlativo

            Dim _where As New Hashtable
            _where.Add("TIPOS_CodTipoConsumo", New ACWhere(ETipos.getTipoConsumo(ETipos.TipoConsumo.AdBlue))) '2
            ' _where.Add("TIPOS_CodTipoConsumo", New ACWhere("CNS02", ACWhere.TipoWhere.Igual))'CNS02
            actxnNumero.Text = managerTRAN_CombustibleConsumo.getCorrelativo("COMCO_CodigoVale", _where)

            acTool.ACBtnEliminarEnabled = False
            acTool.ACBtnModificarEnabled = False

            'Cargar ComboCodigoCombustible 

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region
#Region "Utilitarios"
    Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)

        Select Case _opcion
            Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
                ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
                ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
                'txtCodigo.Enabled = False
                txtSerie.Enabled = False
                _actxnNumero.Enabled = False
            Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
                ACFramework.ACUtilitarios.ACSetControl(pnlDatos, False)
                'txtCodigo.Enabled = False
            Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

            Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

        End Select
    End Sub
#End Region
    Private Sub cargarCombos(ByVal x_viaje_id As Long)
        Try
            Dim tipoCombustible As String = "CNS02" 'Variable Creado  para el Combustible 
            Dim _badministracionviajes As New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            _badministracionviajes.TRAN_Viajes = New ETRAN_Viajes
            _badministracionviajes.TRAN_Viajes.VIAJE_Id = x_viaje_id
            _badministracionviajes.GastosViajeInicial()
            ACUtilitarios.ACCargaCombo(cmbPendiente, _badministracionviajes.ListTESO_Caja, "CAJA_GlosaImporte", "RECIB_Codigo")

            ACUtilitarios.ACCargaCombo(cmbTipoDocumento, Colecciones.TiposDocFacturacion(), "TIPOS_Descripcion", "TIPOS_Codigo", ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura))

            tscmbImpresora.Text = Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_ImpDefault)

            cmbConsumibles.Text = tipoCombustible
            '---- QUITAR cmbConsumibles
            '  ACUtilitarios.ACCargaCombo(cmbConsumibles, Colecciones.TiposCombustible, "TIPOS_Codigo", "TIPOS_Codigo", ETipos.getTipoConsumo(ETipos.TipoConsumo.AdBlue))
            cmbConsumibles.Enabled = False

            tscmbImpresora.Text = Parametros.GetParametro("pg_ImpFacturas", False)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbImpresora_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmbImpresora.DropDown
        Try
            If IsNothing(Colecciones.ListPrinter) Then
                Colecciones.CargarImpresoras()
            End If
            ACFramework.ACUtilitarios.ACCargaCombo(tscmbImpresora, Colecciones.ListPrinter, "DeviceName", "DeviceName")
        Catch ex As Exception

        End Try
    End Sub

    ' <summary>
    ' Realiza el enlace de los controles visuales con la clase esquema
    ' </summary>
    Private Sub AsignarBinding()
        Try
            m_listBindHelper = New List(Of ACBindHelper)()
            'm_listBindHelper.Add(ACBindHelper.ACBind(cmbComTipoCombustible, "SelectedValue", m_etran_combustibleconsumo, "TIPOS_CodTipoCombustible"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnPrecioUnit, "Text", m_etran_combustibleconsumo, "COMCO_PrecioGalon"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotal, "Text", m_etran_combustibleconsumo, "COMCO_Total"))
            '  m_listBindHelper.Add(ACBindHelper.ACBind(actxnKilometraje, "Text", m_etran_combustibleconsumo, "COMCO_Kilometraje"))
            m_listBindHelper.Add(ACBindHelper.ACBind(_actxnGalonesConsumidos, "Text", m_etran_combustibleconsumo, "COMCO_GalonesConsumidos"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", m_etran_combustibleconsumo, "COMCO_CodigoVale"))
            ' m_listBindHelper.Add(ACBindHelper.ACBind(cmbComModoPago, "SelectedValue", m_etran_combustibleconsumo, "TIPOS_CodModoPago"))
            If m_etran_combustibleconsumo.COMCO_Fecha.Year < 1700 Then m_etran_combustibleconsumo.COMCO_Fecha = DateTime.Now
            m_listBindHelper.Add(ACBindHelper.ACBind(dtpComFecha, "Value", m_etran_combustibleconsumo, "COMCO_Fecha"))
            If m_etran_combustibleconsumo.COMCO_FechaViaje.Year < 1700 Then m_etran_combustibleconsumo.COMCO_FechaViaje = DateTime.Now
            m_listBindHelper.Add(ACBindHelper.ACBind(dtpComFecha, "Value", m_etran_combustibleconsumo, "COMCO_FechaViaje"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoDocumento, "SelectedValue", m_etran_combustibleconsumo, "TIPOS_CodTipoDocumento"))
            ' m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoMoneda, "SelectedValue", m_etran_combustibleconsumo, "TIPOS_CodTipoMoneda"))
            m_listBindHelper.Add(ACBindHelper.ACBind(chkCCaja, "Checked", m_etran_combustibleconsumo, "COMCO_CCaja"))

            m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoDocumento, "SelectedValue", m_etran_combustibleconsumo.TRAN_Documentos, "TIPOS_CodTipoDocumento"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtSeriecomp, "Text", m_etran_combustibleconsumo.TRAN_Documentos, "DOCUS_Serie"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumComprobante, "Text", m_etran_combustibleconsumo.TRAN_Documentos, "DOCUS_Numero"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(txtnumeroentero, "Text", m_etran_combustibleconsumo.TRAN_Documentos, "DOCUS_Codigo"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cargar()
        Try
            If Not IsNothing(bs_btran_vehiculos) Then
                If bs_btran_vehiculos.Current IsNot Nothing Then
                    Dim x_codigo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
                    m_etran_combustibleconsumo = New ETRAN_CombustibleConsumo()
                    m_etran_combustibleconsumo.TRAN_Documentos = New ETRAN_Documentos
                    m_etran_combustibleconsumo.Instanciar(ACEInstancia.Nuevo)
                    m_etran_combustibleconsumo.VEHIC_Id = x_codigo
                    AsignarBinding()
                    tabMantenimiento.SelectedTab = tabDatos
                    acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
                End If
            Else
                Select Case m_opcion
                    Case Origen.Viajes
                        m_etran_combustibleconsumo = New ETRAN_CombustibleConsumo()
                        m_etran_combustibleconsumo.Instanciar(ACEInstancia.Nuevo)
                        m_etran_combustibleconsumo.TRAN_Documentos = New ETRAN_Documentos
                        m_etran_combustibleconsumo.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)
                        AsignarBinding()
                        tabMantenimiento.SelectedTab = tabDatos
                        acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
                        cmbTipoDocumento.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura)

                End Select
            End If
        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            Throw ex
        End Try
    End Sub




    Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
        Try
            Select Case x_opcion
                Case EEntidades.TipoEntidad.Proveedores
                    Dim _where As New Hashtable
                    _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
                    If managerEntidades.Ayuda(_where, x_opcion) Then
                        Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Cliente", managerEntidades.DTEntidades, False)
                        If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            '' Cargar datos del cliente
                            actxaNroDocProveedor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                            m_etran_combustibleconsumo.ENTID_CodigoProveedor = Ayuda.Respuesta.Rows(0)("Codigo")
                            actxaDescProveedor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                            If managerEntidades.Cargar(m_etran_combustibleconsumo.ENTID_CodigoProveedor, EEntidades.TipoInicializacion.Proveedor) Then
                                dtpComprobanteFecha.Focus()
                            End If
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
                            m_etran_combustibleconsumo.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                            actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                        End If
                End Select
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
        End Try
    End Sub
    Private Sub actxaNroDocProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles actxaNroDocProveedor.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                If actxaNroDocProveedor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
                    '' Cargar datos adicionales cliente
                    If actxaNroDocProveedor.ACAyuda.Enabled = True Then
                        If managerEntidades.CargarDocIden(actxaNroDocProveedor.Text, EEntidades.TipoInicializacion.Direcciones) Then
                            actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento

                            actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial

                            Label7.Focus()
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

#Region " Metodos de Controles"

#Region " Tool Bar "
    Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnNuevo_Click
        Try
            RemoveHandler actxnLitrosConsumidos.LostFocus, AddressOf actxnLitrosConsumidos_LostFocus
            tabMantenimiento.SelectedTab = tabDatos

            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
            cargar()
            chkCCaja.Checked = False
            txtSerie.Text = "009"
            chkComprobante.Checked = True
            AddHandler actxnLitrosConsumidos.LostFocus, AddressOf actxnLitrosConsumidos_LostFocus
            Me.KeyPreview = True
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Consumo de Combustible", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
        Try
            'tabMantenimiento.SelectedTab = tabBusqueda
            For Each Item As ACBindHelper In m_listBindHelper
                Item.ACUnBind()
            Next
            Select Case m_opcion
                Case Origen.Viajes
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
            End Select
            Me.KeyPreview = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Consumo de Combustible", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
        Dim msg As String = ""
        Try
            If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
                If chkComprobante.Checked Then
                    If Not ACFramework.ACUtilitarios.ACDatosOk(grpComprobante, msg) Then
                        ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No puede guardar" + msg)
                        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                        Exit Sub
                    End If
                    m_etran_combustibleconsumo.ENTID_CodigoProveedor = actxaNroDocProveedor.Text
                    ' m_etran_combustibleconsumo.DOCUS_Codigo = cmbTipoDocumento
                Else
                    m_etran_combustibleconsumo.ENTID_CodigoProveedor = GApp.EmpresaRUC
                End If



                m_etran_combustibleconsumo.SUCUR_Id = GApp.ESucursal.SUCUR_Id
                m_etran_combustibleconsumo.TIPOS_CodTipoCombustible = cmbConsumibles.Text 'igualamos el TIPO DE COMBUSTIBLE 
                m_etran_combustibleconsumo.COMCO_LitrosConsumidos = actxnLitrosConsumidos.Text 'Igualamos el litro en la descripcion ya que no hay columna para eso 
                If m_etran_combustibleconsumo.COMCO_PrecioGalon = 0 Then
                    If m_etran_combustibleconsumo.COMCO_GalonesConsumidos > 0 Then
                        m_etran_combustibleconsumo.COMCO_PrecioGalon = m_etran_combustibleconsumo.COMCO_Total / m_etran_combustibleconsumo.COMCO_GalonesConsumidos
                    End If
                End If

                ''tipo consumo
                m_etran_combustibleconsumo.TIPOS_CodTipoConsumo = ETipos.getTipoConsumo(ETipos.TipoConsumo.AdBlue) '


                If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
                    If m_etran_combustibleconsumo.Nuevo Then m_etran_combustibleconsumo.COMCO_Id = managerTRAN_CombustibleConsumo.getCorrelativo()
                    m_etran_combustibleconsumo.ZONAS_Codigo = GApp.Zona
                    managerTRAN_CombustibleConsumo.setTRAN_CombustibleConsumo(m_etran_combustibleconsumo)

                    If ImpresoraListaParaImprimir(tscmbImpresora.Text) Then
                        If managerTRAN_CombustibleConsumo.GuardarCCAdBlue(GApp.Usuario, chkComprobante.Checked, cmbPendiente.SelectedValue, chkCCaja.Checked) Then
                            Dim _Imprimir As New Impresion(tscmbImpresora.Text)

                            
                            ' If _Imprimir.Print_Recibos(CType(bs_teso_caja.Current, ETESO_Caja).CAJA_NroDocumento) Then
                            If _Imprimir.Print_ConsumoAdBlue(managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_Id, PrintDocument1) Then
                                 globales_.x_BanderGrabarAdBlue = True
                                globales_.x_BanderGrabarCombustible   = false   
                                ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Impreso Satisfactoriamente")
                                'tsbtnImprimir.Enabled = m_reimprimir
                                'CargarIngresos()
                            End If
                            ' tabMantenimiento.SelectedTab = tabBusqueda
                            'acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                            Select Case m_opcion
                                Case Origen.Viajes
                                    Me.DialogResult = Windows.Forms.DialogResult.OK
                                    Me.Close()
                                Case Else
                                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                            End Select

                        End If

                    End If
                    'ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se pudo grabar tu regitro por favor revisa si La impresora es La correcta ")
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                Else
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No puede guardar, por que hay campos obligatorios vacios: " + msg)
                End If
            End If
        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
        End Try
    End Sub

    Private Function ImpresoraListaParaImprimir(ByVal nombreImpresora As String) As Boolean
        ' Aquí debes implementar la lógica para verificar si la impresora está lista para imprimir
        ' Por ejemplo, puedes usar el objeto PrinterSettings para obtener información sobre la impresora
        Dim settings As New PrinterSettings()
        settings.PrinterName = nombreImpresora
        Return settings.IsValid
    End Function

    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub
    Private Sub actxnLitrosConsumidos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Convert.ToDecimal(actxnGalonesConsumidos.Text) = 0 And Convert.ToDecimal(_actxnLitrosConsumidos.Text) <> 0 Then
                actxnGalonesConsumidos.Text = Math.Round(Convert.ToDecimal(actxnLitrosConsumidos.Text) / 3.785, 2, MidpointRounding.AwayFromZero)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error calculando el precio por galon", ex)
        End Try
    End Sub
#End Region

    Private Sub chkComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chkComprobante.CheckedChanged
        grpComprobante.Enabled = chkComprobante.Checked
        Me.KeyPreview = chkComprobante.Checked
    End Sub
#End Region

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim s As String = globales_.cabecera
        Dim s1 As String = globales_.cuerpo
        ' Dim s2 As String = globales_.pie

        'Dim MyLetraNormal As New Font("Segoe UI Light", 8) '("Lucida Sans Typewriter", 8)'Segoe UI Light
        Dim MyLetraNormal As New Font("Lucida Sans Typewriter", 8)

        'lineas
        Dim ts As Double = s.ToString().Split(vbCrLf).Length
        Dim ts1 As Double = s1.ToString().Split(vbCrLf).Length
        'Dim ts2 As Double = s2.ToString().Split(vbCrLf).Length

        Dim y As Double = (MyLetraNormal.GetHeight(e.Graphics)) * ts
        Dim y1 As Double = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts1)

        e.Graphics.DrawString(s, MyLetraNormal, Brushes.Black, 0, 0)
        e.Graphics.DrawString(s1, MyLetraNormal, Brushes.Black, 0, y)
        ' e.Graphics.DrawString(s2, MyLetraNormal, Brushes.Black, 0, y1)


    End Sub

    Private Sub actxaNroDocProveedor_ACAyudaClick(sender As Object, e As EventArgs) Handles actxaNroDocProveedor.ACAyudaClick

        Try
            AyudaEntidad(actxaNroDocProveedor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Proveedores)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
        End Try
    End Sub


    Private Sub actxaNroDocProveedor_TextChanged(sender As Object, e As EventArgs) Handles actxaNroDocProveedor.TextChanged

    End Sub

    Private Sub actxaDescProveedor_ACAyudaClick(sender As Object, e As EventArgs) Handles actxaDescProveedor.ACAyudaClick
        Try
            AyudaEntidad(actxaDescProveedor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Proveedores)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
        End Try
    End Sub

    Private Sub actxnPrecioUnit_LostFocus(sender As Object, e As EventArgs) Handles actxnPrecioUnit.LostFocus
        Try
            If Convert.ToDecimal(actxnTotal.Text) = 0 And Convert.ToDecimal(_actxnGalonesConsumidos.Text) <> 0 Then
                actxnTotal.Text = Math.Round(Convert.ToDecimal(actxnPrecioUnit.Text) * Convert.ToDecimal(actxnGalonesConsumidos.Text), 2, MidpointRounding.AwayFromZero)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error calculando el precio por galon", ex)
        End Try
    End Sub
End Class