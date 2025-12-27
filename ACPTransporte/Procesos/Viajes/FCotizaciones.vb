Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid
Imports ACBVentas
Imports ACControles
Imports ACEVentas

Public Class FCotizaciones

    'COTIZACIONES DE TRANSPORTES 
    '  %&&  %  ,.   *. %(*                                                                                                                                                                                *(*
    ' , (((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
    ' * ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,Fechas,,,,,,,,,,,,,,,,,,
    '   ,Opciones de Busqueda                                                                                                                  Cliente                 **Consultar,@,,#De: < / / >,A: < / / >*.         ,.,,,,*.         ..,
    '   ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,Codigo ,,,,,,,,,..........,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
    '   .       (                                                   ,              .                           .                               **************************************************************
    '   .Codigo      RUC   Cliente        Ruta      Monto        Fecha         Carga         Estado                                                                                                                                       **************************************************************
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
    ' % # @(.NUEVO, @ MODIFICAR  (%/ANULAR    /#,&  GENERAR FLETE Y VIAJE/&.,%(  .%(,./.,.  ,,&  %#%%/*.  ,. @#,./ ., /  %  .( **(                                                     SALIR                                                  
    '&&  &&&*&&&&..&&& **&&..*&& /*&&%(%&&&%&&&&( &&&(&&&&.*&&%**%%&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& &&#(&,,&&&&&&&&&  &&

#Region " Variables "
    Private managerTRAN_Cotizaciones As BTRAN_Cotizaciones
    Private managerAdministracionViajes As BAdministracionViajes
    Private managerAdministracionViajesModificacion As BAdministracionViajes
    Private managerBTRAN_Viajes As BTRAN_Viajes
    Private managerETRAN_Viajes As ETRAN_Viajes
    Private managerTRAN_Rutas As BTRAN_Rutas
    Private managerEntidades As BEntidades


    Dim b_Direccion As BDirecciones

    Private bs_btran_cotizaciones As BindingSource
    Private m_listBindHelper As List(Of ACBindHelper)

    Private bd_direcciones_origen As BindingSource
    Private bd_direcciones_destino As BindingSource

    Private bs_departamento_origen As BindingSource

    Private bs_departamento_destino As BindingSource


    Private bs_direcciones_busq As BindingSource


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

    Private m_e_cotizacion As ETRAN_Cotizaciones
    Dim X_GLOBAL_COTIZACION As String

    Private m_dialog As Boolean = False

    Enum InicioEntidad
        Normal
        NuevaEntidad
        ModificarEntidad
    End Enum
    Enum Inicio
        Normal
        NuevaEntidad
        ModificarEntidad
    End Enum

    Enum TInicioCotizacion
        Nuevo
        Editar
        Eliminar

    End Enum
    Enum TInicio
        Normal
        Busqueda
    End Enum


#End Region

#Region " Propiedades "

    Public ReadOnly Property TRAN_Cotizaciones() As ETRAN_Cotizaciones
        Get
            Return managerAdministracionViajes.TRAN_Cotizaciones
        End Get
    End Property

    Public ReadOnly Property TRAN_OrdenesTransportes() As ETRAN_OrdenesTransportes
        Get
            Return managerAdministracionViajes.TRAN_OrdenesTransportes
        End Get
    End Property

#End Region

#Region " Constructores "

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Try
            Inicializacion()

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub
    Public Sub New(ByVal x_opcion As TInicioCotizacion, ByVal x_numfac As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Select Case x_opcion
            Case TInicioCotizacion.Nuevo


            Case TInicioCotizacion.Editar
                acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)

                setInicio(TInicioCotizacion.Editar)
                acTool_ACBtnModificarDesdeFactura_Click(x_numfac, Nothing, Nothing)
                'cargar(x_numfac, TInicioCotizacion.Editar)
                'AsignarBinding()

            Case TInicioCotizacion.Eliminar
        End Select
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal x_empresa As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Try
            Inicializacion()
            tabMantenimiento.SelectedTab = tabDatos
            acTool_ACBtnNuevo_Click(Nothing, Nothing)
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            If x_empresa.Equals("ACERO") Then
                actxaCliRuc.Text = GApp.EmpresaRUC
                setCliente()
                actxnMontoXTm.Text = ACETransporte.Constantes.ImporteInterno
                txtCarga.Text = ACETransporte.Constantes.ProductoInterno
                actxaCodRuta.Focus()

                m_dialog = True
            ElseIf x_empresa.Equals("JRANC") Then
                actxaCliRuc.Text = GApp.EmpresaRUC
                setCliente()
                actxnMontoXTm.Text = ACETransporte.Constantes.ImporteInterno
                txtCarga.Text = ACETransporte.Constantes.ProductoInterno
                actxaCodRuta.Focus()

                m_dialog = True
            Else
                actxaCliRuc.Text = GApp.EmpresaRUC
                setCliente()
                actxnMontoXTm.Text = ACETransporte.Constantes.ImporteInterno
                txtCarga.Text = ACETransporte.Constantes.ProductoInterno
                actxaCodRuta.Focus()

                m_dialog = True
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

    Private Sub setInicio(m_opcion As TInicioCotizacion)
        Try
            '    managerEntidades = New BEntidades
            Select Case m_opcion
                Case TInicioCotizacion.Nuevo
                    tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
                    tabMantenimiento.SelectedTab = tabBusqueda
                    formatearGrilla()

                Case TInicioCotizacion.Editar
                    tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
                    formatearGrilla()
                    InicializacionXFacturacion()
                    'acTool_ACBtnNuevo_Click(Nothing, Nothing)
                    'acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
                Case TInicioCotizacion.Eliminar
                    'setInicio()
                    formatearGrilla()

                Case Else
                    Close()
                    '8888
            End Select
            acTool.ACBtnEliminar.Enabled = False
            acTool.ACBtnModificar.Enabled = False

            txtBusqueda.ACActivarAyudaAuto = True
            txtBusqueda.ACLongitudAceptada = Parametros.GetParametro(EParametros.TipoParametros.pg_LongTexAyuda)



        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cargar(ByVal x_codigo As String, ByVal x_tipocotizacion As TInicioCotizacion)
        Try
            managerTRAN_Cotizaciones = New BTRAN_Cotizaciones()
            managerTRAN_Cotizaciones.Cargar(x_codigo, True) 'Tiene que recibir un  numero de cotizacion
            m_e_cotizacion = managerTRAN_Cotizaciones.getTRAN_Cotizaciones()
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)

            AsignarBinding()
            '' Cargar datos adicionales segun el perfil cargado
            Select Case x_tipocotizacion
                Case TInicioCotizacion.Nuevo
                    'managerEntidades.CargarCliente(x_codigo)
                    'ABCliente()
                Case TInicioCotizacion.Editar
                    'Inicializacion()
                    AsignarDatosDeCotizacion(m_e_cotizacion)

                Case TInicioCotizacion.Eliminar

            End Select


            tabMantenimiento.SelectedTab = tabDatos
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub AsignarDatosDeCotizacion(ByVal X_Lista_cotizacion As ETRAN_Cotizaciones)


        ACFramework.ACUtilitarios.ACCargaCombo(cmbMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
        ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, Colecciones.TiposDocComprobante(), "TIPOS_Descripcion", "TIPOS_Codigo")
        AsignarBinding()

    End Sub

    Private Sub Inicializacion()
        Try
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda
            formatearGrilla()

            managerTRAN_Cotizaciones = New BTRAN_Cotizaciones
            managerAdministracionViajes = New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            managerAdministracionViajesModificacion = New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            managerBTRAN_Viajes = New BTRAN_Viajes()
            managerETRAN_Viajes = New ETRAN_Viajes()
            managerTRAN_Rutas = New BTRAN_Rutas
            managerEntidades = New BEntidades

            'Muestra Ubigo Origene y dESTINO INABILITADO
            actxtUbigoOrigen.Enabled = False
            actxtUbigoDestino.Enabled = False
            btnModificarDesdeFactura.Visible = False


            acTool.ACBtnAnularEnabled = False
            acTool.ACBtnModificarEnabled = False
            AcFecha.ACValidarFecha = False

            Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACGuiaProc_16x16.GetHicon)

            actxnIGV.Enabled = False
            actxnValorReferencialXTm.Enabled = False
            actxnTotalValorReferencial.Enabled = False

            ACFramework.ACUtilitarios.ACCargaCombo(cmbMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
            ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, Colecciones.TiposDocComprobante(), "TIPOS_Descripcion", "TIPOS_Codigo")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InicializacionXFacturacion()
        Try
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda
            formatearGrilla()

            managerTRAN_Cotizaciones = New BTRAN_Cotizaciones
            managerAdministracionViajes = New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            managerAdministracionViajesModificacion = New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            managerBTRAN_Viajes = New BTRAN_Viajes()
            managerETRAN_Viajes = New ETRAN_Viajes()
            managerTRAN_Rutas = New BTRAN_Rutas
            managerEntidades = New BEntidades

            'Muestra Ubigo Origene y dESTINO INABILITADO
            actxtUbigoOrigen.Enabled = False
            actxtUbigoDestino.Enabled = False
            acTool.ACBtnGrabar.Visible = False
            acTool.ACBtnGrabarEnabled = False
            acTool.ACBtnGrabarVisible = False
            btnModificarDesdeFactura.Visible = True
            actxaCodRuta.Enabled = True 'Habilitamos controles solo para la edicion de rutas 
            cmbDireccionOrigen.Enabled = True
            cmbDireccionDestino.Enabled = True
            actextBusqDescripcion.Enabled = True

            acTool.ACBtnAnularEnabled = False
            acTool.ACBtnModificarEnabled = False
            AcFecha.ACValidarFecha = False

            Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACGuiaProc_16x16.GetHicon)

            actxnIGV.Enabled = False
            actxnValorReferencialXTm.Enabled = False
            actxnTotalValorReferencial.Enabled = False

            ACFramework.ACUtilitarios.ACCargaCombo(cmbMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
            ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, Colecciones.TiposDocComprobante(), "TIPOS_Descripcion", "TIPOS_Codigo")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Utilitarios "

    ' <summary>
    ' Ejecutar la busqueda de una cadena en la tabla conductores
    ' </summary>
    ' <param name="x_cadena">Cadena objetivo</param>
    ' <returns></returns>
    Private Function busqueda(ByVal x_cadena As String) As Boolean
        Try
            If managerTRAN_Cotizaciones.Busqueda(x_cadena, getCampo(), chkMostrarTodos.Checked, AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date.AddDays(1), GApp.PuntoVenta) Then
                acTool.ACBtnAnularEnabled = False
                acTool.ACBtnModificarEnabled = True
            Else
                acTool.ACBtnAnularEnabled = False
                acTool.ACBtnModificarEnabled = False
            End If
            cargarDatos()
            Return acTool.ACBtnModificarEnabled
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
        End Try
        Return False
    End Function

    Private Function getCampo() As String
        Try
            If (rbtnCodigo.Checked) Then
                Return "COTIZ_Id"
            ElseIf rbtnCliente.Checked Then
                Return "COTIZ_NombreCliente"
            Else
                Return "COTIZ_Id"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function



#Region "Busqueda por Direccion con variable entidad "
    Private Function BusquedaDireccionXEntidades(ByVal x_entid_codigo As String) As Boolean

        Dim b_Direcciones As New BDirecciones()

        Dim bs_direcciones_busq = New BindingSource()
        If b_Direcciones.AYUDASS_Busq_X_UBIGEOS(x_entid_codigo) Then

            b_Direcciones.CargarTodos()
            ACFramework.ACUtilitarios.ACCargaCombo(cmbDireccionOrigen, Colecciones.TiposDireccionesOrigen(b_Direcciones.ListDirecciones, x_entid_codigo), "DIREC_Direccion", "DIREC_Direccion")
            ACFramework.ACUtilitarios.ACCargaCombo(cmbDireccionDestino, Colecciones.TiposDireccionesDestino(b_Direcciones.ListDirecciones, x_entid_codigo), "DIREC_Direccion", "DIREC_Direccion")

        Else
            ' Preguntamos si quiere crear una direccion  ya que no tiene una direccion 

            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Generacion de Direccion Del Cliente {0}", Me.Text) _
            , String.Format("NO SE Encontro Direcciones Deseas Generar La Direccion para Este Cliente {0}", actxaCliRuc.Text) _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

                Dim form_Entidades As New MEntidad(actxaCliRuc.Text, Inicio.ModificarEntidad, EEntidades.TipoEntidad.Clientes) With {.StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Normal}

                '==========================ENTIDADES BUSQUEDA ==========================

                If form_Entidades.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    BusquedaDireccionXEntidades(actxaCliRuc.Text)
                    Return True

                End If
            Else
                Return False



            End If

        End If

    End Function

#End Region




    ' <summary>
    ' Dar Formato a la grilla de busqueda
    ' </summary>
    ' <remarks></remarks>
    Private Sub formatearGrilla()
        Dim index As Integer = 1
        Try
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 10, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "COTIZ_Codigo", "COTIZ_Codigo", 250, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "R.U.C.", "ENTID_NroDocumento", "ENTID_NroDocumento", 250, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cliente", "COTIZ_NombreCliente", "COTIZ_NombreCliente", 250, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Ruta", "RUTAS_Nombre", "RUTAS_Nombre", 250, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Monto", "COTIZ_Monto", "COTIZ_Monto", 100, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "COTIZ_FechaFlete", "COTIZ_FechaFlete", 100, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Carga", "COTIZ_Carga", "COTIZ_Carga", 250, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "COTIZ_Estado", "COTIZ_Estado", "COTIZ_Estado", 250, False, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "COTIZ_ESTADO_Text", "COTIZ_ESTADO_Text", 250, True, False, "System.String", "") : index += 1
            c1grdBusqueda.AllowEditing = False
            c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
            c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
            c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

            Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Facturar")
            u.BackColor = Color.Green
            u.ForeColor = Color.White
            u.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

            Dim d As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Anulado")
            d.BackColor = Color.Red
            d.ForeColor = Color.White
            d.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub

    Private Sub c1grdBusqueda_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdBusqueda.OwnerDrawCell
        Try
            If e.Row < c1grdBusqueda.Rows.Fixed OrElse e.Col < c1grdBusqueda.Cols.Fixed Then Return
            If c1grdBusqueda.Rows(e.Row)("COTIZ_Estado") = ETRAN_OrdenesTransportes.getEstado(ETRAN_OrdenesTransportes.Estado.Recibido) Then
                e.Style = c1grdBusqueda.Styles("Facturar")
            End If
            If c1grdBusqueda.Rows(e.Row)("COTIZ_Estado") = ETRAN_OrdenesTransportes.getEstado(ETRAN_OrdenesTransportes.Estado.Anulado) Then
                e.Style = c1grdBusqueda.Styles("Anulado")
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
        End Try
    End Sub

    Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)
        acTool.ACBtnGrabar.Enabled = True
        dtpFecha.Enabled = True
        Select Case _opcion
            Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
                ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
                ACFramework.ACUtilitarios.ACSetControl(pnlDatos, False, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
                ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
                acTool.ACBtnBuscarVisible = False
                ' acTool.ACBtnEliminarVisible = False
                acbtnRecOrden.Visible = False
                actxaCliente.ACAyuda.Enabled = True
                actxaCliRuc.ACAyuda.Enabled = True
                actxaCodRuta.ACAyuda.Enabled = True
                actxaRuta.ACAyuda.Enabled = True

                btnNuevo.Enabled = True
                btnEditar.Enabled = True
                btnClean.Enabled = True
                btnRNuevo.Enabled = True
                btnREditar.Enabled = True
                btnRClean.Enabled = True
                chkIGV.Checked = False
                actxnValorReferencialXTm.Enabled = False
                actxnTotalValorReferencial.Enabled = False
                actxtUbigoOrigen.Enabled = False
                actxtUbigoDestino.Enabled = False
                'Cargamos ubigeos de Origen y destino 
                'CargarCombosUbigeosOrigen()
                'CargarCombosUbigeosDestino()
                'Limpiado Valores 
                m_vauldirecciondestino = Nothing
                'cmbDireccionDestino.Text = "-"
                'cmbDireccionOrigen.Text = "-"


                'Habilitacmos edicion de combobox de ORIGEN Y DESTINOS 

                cmbDireccionOrigen.DropDownStyle = ComboBoxStyle.DropDown
                cmbDireccionDestino.DropDownStyle = ComboBoxStyle.DropDown
                'cmbDireccionDestino.Items.Clear()
                'cmbDireccionOrigen.Items.Clear()


                '

            Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
                acTool.ACBtnBuscarVisible = False
                acTool.ACBtnAnularVisible = True
                acbtnRecOrden.Visible = False
                acTool.ACBtnGrabar.Enabled = True
                acTool.ACBtnAnular.Enabled = True
                dtpFecha.Enabled = False
                actxaCliente.ACAyuda.Enabled = False
                actxaCliRuc.ACAyuda.Enabled = False
                actxaCodRuta.ACAyuda.Enabled = False
                actxaRuta.ACAyuda.Enabled = False
                btnNuevo.Enabled = False
                btnEditar.Enabled = False
                btnClean.Enabled = False
                btnRNuevo.Enabled = False
                btnREditar.Enabled = False
                btnRClean.Enabled = False
                acTool.ACBtnImprimir.Visible = True
                acTool.ACBtnImprimir.Enabled = True
                cmbDireccionOrigen.DropDownStyle = ComboBoxStyle.DropDown
                cmbDireccionDestino.DropDownStyle = ComboBoxStyle.DropDown
                cmbDireccionOrigen.Enabled = True
                cmbDireccionDestino.Enabled = True
                actextBusqDescripcion.Enabled = True
                actxaCodRuta.Enabled = True
                'txtCodigo.Enabled = False
            Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar, ACFramework.ACUtilitarios.ACSetInstancia.Deshacer
                tabMantenimiento.SelectedTab = tabBusqueda
                acbtnRecOrden.Visible = True
                m_vauldirecciondestino = Nothing


        End Select

    End Sub
#End Region

#Region " Cargar Datos "

    Private Sub cargarDatos()
        Try
            bs_btran_cotizaciones = New BindingSource()
            bs_btran_cotizaciones.DataSource = managerTRAN_Cotizaciones.getListTRAN_Cotizaciones()
            c1grdBusqueda.DataSource = bs_btran_cotizaciones
            bnavBusqueda.BindingSource = bs_btran_cotizaciones
            AddHandler bs_btran_cotizaciones.CurrentChanged, AddressOf bs_cotizaciones_CurrentChanged
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
            If Not IsNothing(managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo) Then
                txtCodigo.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_CODIGO_Cod
                actxaCodRuta.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id
            End If
            'actxaCliRuc
            m_listBindHelper.Add(ACBindHelper.ACBind(actxaCliente, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_NombreCliente"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxaCliRuc, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "ENTID_Codigo"))

            If (managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_FechaFlete.Year < 1700) Then managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_FechaFlete = DateTime.Now
            m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecha, "Value", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_FechaFlete"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnPeso, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_PesoEnTM"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnIGV, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_ImporteIgv"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnMontoXTm, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_MontoPorTM"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnMonto, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_Monto"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnValorReferencialXTm, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_ValorReferencial"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotalValorReferencial, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_TotalValorReferencial"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtCarga, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_Carga"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxtUbigoOrigen, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "UBIGO_CodigoOrigen"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxtUbigoDestino, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "UBIGO_CodigoDestino"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "TIPOS_CodTipoMoneda"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbDocumento, "SelectedValue", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "TIPOS_CodTipoDocumento"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(cmbDireccionDestino, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_DireccionPuntoDestino"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(cmbDireccionOrigen, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_DireccionPuntoOrigen"))


            'cmbDireccionDestino
            actxaCodRuta.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Codigo
            actxaRuta.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Nombre
            cmbDireccionOrigen.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoOrigen
            cmbDireccionDestino.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoDestino
        Catch ex As Exception
            Throw ex
        End Try
    End Sub








    Private Sub cargar()
        Try
            If Not IsNothing(bs_btran_cotizaciones) Then
                If bs_btran_cotizaciones.Current IsNot Nothing Then
                    Dim x_codigo As Integer = CType(bs_btran_cotizaciones.Current, ETRAN_Cotizaciones).COTIZ_Id
                    Dim _join As New List(Of ACJoin)()
                    _join.Add(New ACJoin("Transportes", "TRAN_Rutas", ACJoin.TipoJoin.Left _
                                         , New ACCampos() {New ACCampos("RUTAS_Id", "RUTAS_Id")} _
                                         , New ACCampos() {New ACCampos("RUTAS_Nombre", "RUTAS_Nombre") _
                                                           , New ACCampos("RUTAS_Codigo", "RUTAS_Codigo")}))
                    Dim _where As New Hashtable()
                    _where.Add("COTIZ_Id", New ACWhere(x_codigo.ToString(), ACWhere.TipoWhere.Igual))
                    If managerTRAN_Cotizaciones.Cargar(_join, _where) Then
                        If managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Recibido) And
                           managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Recibido) Then
                            actxnIGV.Enabled = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_ImporteIgv > 0
                            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)

                            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                        Else
                            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
                        End If
                        AsignarBinding()
                        tabMantenimiento.SelectedTab = tabDatos
                    Else
                        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro")
                    End If
                Else
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro")
                End If
            Else
                acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro por que no existe")
            End If
        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            Throw ex
        End Try
    End Sub

    'Cargar datos de Cotizacion pero con numero de cotizcodigo

    Private Sub cargar(x_COTIZ_codigo As String)
        Try
            Dim managerTRAN_Cotizaciones As New BTRAN_Cotizaciones()
            'If Not IsNothing(bs_btran_cotizaciones) Then
            '    If bs_btran_cotizaciones.Current IsNot Nothing Then
            'Dim x_codigo As Integer = CType(bs_btran_cotizaciones.Current, ETRAN_Cotizaciones).COTIZ_Id
            Dim _join As New List(Of ACJoin)()
            _join.Add(New ACJoin("Transportes", "TRAN_Rutas", ACJoin.TipoJoin.Left _
                                 , New ACCampos() {New ACCampos("RUTAS_Id", "RUTAS_Id")} _
                                 , New ACCampos() {New ACCampos("RUTAS_Nombre", "RUTAS_Nombre") _
                                                   , New ACCampos("RUTAS_Codigo", "RUTAS_Codigo")}))
            Dim _where As New Hashtable()
            _where.Add("COTIZ_Codigo", New ACWhere(x_COTIZ_codigo, ACWhere.TipoWhere.Igual))
            If managerTRAN_Cotizaciones.Cargar(_join, _where) Then
                actxnIGV.Enabled = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_ImporteIgv > 0
                'ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)

                setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)


                'AsignarBinding()

                ACFramework.ACUtilitarios.ACCargaCombo(cmbMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
                ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, Colecciones.TiposDocComprobante(), "TIPOS_Descripcion", "TIPOS_Codigo")
                txtCodigo.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_CODIGO_Cod
                actxaCodRuta.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id
                actxaCliRuc.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo
                actxaCliente.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_NombreCliente
                cmbDireccionOrigen.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoOrigen
                cmbDireccionDestino.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoDestino
                dtpFecha.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_FecCrea
                actxnMontoXTm.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_MontoPorTM
                actxnIGV.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_ImporteIgv
                actxnPeso.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_PesoEnTM
                actxnMonto.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Monto
                'cmbDireccionDestino
                'actxaCodRuta.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Codigo
                actxaRuta.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Nombre
                cmbDireccionOrigen.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoOrigen
                cmbDireccionDestino.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoDestino

                actxnValorReferencialXTm.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_ValorReferencial

                actxnTotalValorReferencial.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_TotalValorReferencial
                actxtUbigoOrigen.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.UBIGO_CodigoOrigen
                actxtUbigoDestino.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.UBIGO_CodigoDestino

                txtCarga.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Carga
                tabMantenimiento.SelectedTab = tabDatos
            Else
                acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro")
            End If
            '    Else
            '        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
            '        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro")
            '    End If
            'Else
            '    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
            '    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro por que no existe")
            'End If
        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            Throw ex
        End Try
    End Sub 'Esto ya no porque estamos usando otra forma pero tambien funciona 


#End Region

#Region " Ayudas "

    Private Sub AyudaRutas(ByVal x_cadenas As String, ByVal x_campo As String)
        Try
            Dim _where As New Hashtable()
            _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
            If managerTRAN_Rutas.Ayuda(_where) Then
                Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Ruta", managerTRAN_Rutas.DTTRAN_Rutas, False)
                If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    actxaCodRuta.Text = Ayuda.Respuesta.Rows(0)("Codigo").ToString()
                    actxaRuta.Text = Ayuda.Respuesta.Rows(0)("Nombre").ToString()
                    actxnValorReferencialXTm.Text = Ayuda.Respuesta.Rows(0)("ValorReferencial").ToString()
                    actxtUbigoOrigen.Text = Ayuda.Respuesta.Rows(0)("UBIGO_CodOrigen").ToString()
                    actxtUbigoDestino.Text = Ayuda.Respuesta.Rows(0)("UBIGO_CodDestino").ToString()
                    managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id = Ayuda.Respuesta.Rows(0)("Codigo").ToString()

                    lblFecha.Focus()
                End If
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar la ayuda, posiblemente no haya datos que mostrar")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AyudaCliente(ByVal x_cadenas As String, ByVal x_campo As String)
        Try
            Dim _where As New Hashtable
            _where.Add(x_campo, New ACFramework.ACWhere(x_cadenas, ACFramework.ACWhere.TipoWhere._Like))
            If managerEntidades.Ayuda(_where, EEntidades.TipoEntidad.Clientes) Then
                Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerEntidades.DTEntidades, False)
                If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo = Ayuda.Respuesta.Rows(0)("Codigo")
                    actxaCliRuc.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.").ToString()
                    actxaCliente.Text = Ayuda.Respuesta.Rows(0)("Razon Social").ToString()

                    If BusquedaDireccionXEntidades(actxaCliRuc.Text) Then
                        cmbDireccionDestino.Text = Ayuda.Respuesta.Rows(0)("Dirección").ToString() 'Direccion con tilde ?? pendejo 
                        cmbDireccionOrigen.Text = GApp.EPuntoVenta.PVENT_Direccion
                        m_vauldirecciondestino = Ayuda.Respuesta.Rows(0)("Dirección").ToString()
                    Else
                        'cmbDireccionOrigen.Text = GApp.EPuntoVenta.PVENT_Direccion

                    End If




                    lblRuta.Focus()
                End If
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar la ayuda, posiblemente no haya datos que mostrar")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    Private Sub bs_cotizaciones_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If CType(bs_btran_cotizaciones.Current, ETRAN_Cotizaciones).COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Recibido) Then
                acbtnRecOrden.Enabled = False
            Else
                acbtnRecOrden.Enabled = True
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
        End Try
    End Sub

    Private Sub setCliente()
        Try
            If managerEntidades.CargarDocIden(actxaCliRuc.Text, EEntidades.TipoInicializacion.Cliente) Then
                '' Cargar datos del cliente
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo = managerEntidades.Entidades.ENTID_Codigo

                actxaCliente.Text = managerEntidades.Entidades.ENTID_RazonSocial
                actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
                lblRuta.Focus()
            Else
                If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaCliRuc.Text) _
                                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                    NuevaEntidad(actxaCliRuc.Text)
                    Label1.Focus()
                Else
                    btnClean_Click(Nothing, Nothing)
                    lblNroDocumento.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NuevaEntidad(ByVal x_entid_nrodocumento As String)
        Try
            Dim frmEntidad As New MEntidad(MEntidad.Inicio.NuevaEntidad, ACEVentas.EEntidades.TipoEntidad.Clientes)
            frmEntidad.StartPosition = FormStartPosition.CenterScreen
            If x_entid_nrodocumento.Length > 0 Then
                frmEntidad.EEntidad.ENTID_NroDocumento = x_entid_nrodocumento
                frmEntidad.lblNombres.Focus()
            End If
            If frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo = frmEntidad.EEntidad.ENTID_Codigo
                managerEntidades.Entidades = frmEntidad.EEntidad
                actxaCliente.Text = managerEntidades.Entidades.ENTID_RazonSocial
                actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Metodos de Controles"

#Region " Tool Bar "
    Private Sub acTool_ACBtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnNuevo_Click
        Try
            tabMantenimiento.SelectedTab = tabDatos

            managerTRAN_Cotizaciones.TRAN_Cotizaciones = New ETRAN_Cotizaciones()
            managerTRAN_Cotizaciones.TRAN_Cotizaciones.Instanciar(ACEInstancia.Nuevo)
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
            AsignarBinding()
            actxaCliente.Focus()
            Me.KeyPreview = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub acTool_ACBtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
        Dim msg As String = ""
        Try
            If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.SUCUR_Id = GApp.Sucursal
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.ZONAS_Codigo = GApp.Zona
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.PVENT_Id = GApp.PuntoVenta
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Id = managerTRAN_Cotizaciones.getCorrelativo("COTIZ_Id")
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Nombre = actxaRuta.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_ValorReferencial = actxnValorReferencialXTm.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_TotalValorReferencial = actxnTotalValorReferencial.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.UBIGO_CodigoOrigen = actxtUbigoOrigen.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.UBIGO_CodigoDestino = actxtUbigoDestino.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoOrigen = cmbDireccionOrigen.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoDestino = cmbDireccionDestino.Text

                managerAdministracionViajes.TRAN_Cotizaciones = managerTRAN_Cotizaciones.TRAN_Cotizaciones



                'globales_.x_rutas_id = Integer.Parse(actxaCodRuta.Text)

                If managerAdministracionViajes.GuardarCotizacion(GApp.Usuario, GApp.FechaProceso.Year.ToString()) Then
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                    tabMantenimiento.SelectedTab = tabBusqueda
                    busqueda(txtBusqueda.Text)
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                    Me.KeyPreview = False
                    txtBusqueda.Focus()
                    setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Guardar)
                    Me.KeyPreview = False

                    If m_dialog Then
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Generar Viaje: {0}", Me.Text) _
                                                                        , String.Format("Desea generar el Viaje de la cotización: {0}?", managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo) _
                                                                        , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                            'managerTRAN_Cotizaciones.TRAN_Cotizaciones = CType(bs_btran_cotizaciones.Current, ETRAN_Cotizaciones)
                            managerAdministracionViajes.TRAN_Cotizaciones = managerTRAN_Cotizaciones.TRAN_Cotizaciones
                            Dim _fflete As New FFlete(managerAdministracionViajes.TRAN_Cotizaciones) With {.StartPosition = FormStartPosition.CenterScreen}
                            Select Case _fflete.ShowDialog()
                                Case Windows.Forms.DialogResult.OK
                                    busqueda(txtBusqueda.Text)
                                Case Windows.Forms.DialogResult.Yes
                                    Dim frmViajes As New FViajes(FViajes.TipoCarga.Base)
                                    frmViajes.MdiParent = Me.MdiParent
                                    frmViajes.StartPosition = FormStartPosition.CenterScreen
                                    frmViajes.Show()
                                Case Else
                                    busqueda(txtBusqueda.Text)
                            End Select
                        End If
                    End If
                Else
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar{0}", msg))
                End If
            Else
                acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar, por que hay campos obligatorios vacios: {0}", msg))
            End If



        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnAnular_Click
        Try
            If ACControles.ACDialogos.ACMostrarMensajePregunta("Anular Registro: " & Convert.ToString(Me.Text), "Desea Anular el registro: " + CType(bs_btran_cotizaciones.Current, ETRAN_Cotizaciones).COTIZ_CODIGO_Cod & "?", ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                managerTRAN_Cotizaciones.TRAN_Cotizaciones = CType(bs_btran_cotizaciones.Current, ETRAN_Cotizaciones)
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.Instanciar(ACFramework.ACEInstancia.Modificado)
                managerTRAN_Cotizaciones.setTRAN_Cotizaciones(managerTRAN_Cotizaciones.TRAN_Cotizaciones)


                If managerTRAN_Cotizaciones.AnularDocumento(CType(bs_btran_cotizaciones.Current, ETRAN_Cotizaciones).COTIZ_Codigo, GApp.Usuario) Then
                    ' managerTRAN_Cotizaciones.Guardar(GApp.Usuario)
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " & Convert.ToString(Me.Text), "Anulado satisfactoriamente")
                    busqueda(txtBusqueda.Text)
                Else
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede anular el documento")
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede Anular", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub

    Private Sub acTool_ACBtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnModificar_Click
        Try
            If Not IsNothing(bs_btran_cotizaciones) Then
                If Not IsNothing(bs_btran_cotizaciones.Current) Then
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
                    setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                    cargar()
                    Me.KeyPreview = True
                Else
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                    ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No se puede modificar si no se ha cargado ningun registro")
                End If
            Else
                acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No se puede modificar si no se ha cargado ningun registro")
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede Eliminar", ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnModificarDesdeFactura_Click(x_CotizCodigo As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
                    setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
            cargar(x_CotizCodigo)
            X_GLOBAL_COTIZACION = x_CotizCodigo
            Me.KeyPreview = True

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede Eliminar", ex)
        End Try
    End Sub



    Private Sub acTool_ACBtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click
        Try
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
            Me.KeyPreview = False
            If m_dialog Then Me.Close()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede Eliminar", ex)
        End Try
    End Sub
    Private Sub acTool_ACBtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnImprimir_Click
        Try
            Dim ptimp As New PImpresion(managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo) With {.StartPosition = FormStartPosition.CenterScreen, .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog}
            ptimp.ShowDialog()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Imprimir Guia", ex)
        End Try
    End Sub
#End Region

#Region " Text de Ayuda "
    Private Sub actxaCodCliente_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliRuc.ACAyudaClick
        Try
            If actxaCliRuc.ACAyuda.Enabled Then
                AyudaCliente(actxaCliRuc.Text, "ENTID_Id")
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los clientes por codigo", ex)
        End Try
    End Sub

    Private Sub actxaCliente_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliente.ACAyudaClick
        Try
            If actxaCliente.ACAyuda.Enabled Then AyudaCliente(actxaCliente.Text, "ENTID_Nombres")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los clientes por nombre", ex)
        End Try
    End Sub

    Private Sub actxaCodRuta_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCodRuta.ACAyudaClick
        Try
            If actxaCodRuta.ACAyuda.Enabled Then AyudaRutas(actxaCodRuta.Text, "RUTAS_Id")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de las rutas", ex)
        End Try
    End Sub



    Private Sub actxaRuta_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaRuta.ACAyudaClick
        Try
            If actxaCodRuta.ACAyuda.Enabled Then AyudaRutas(actxaRuta.Text, "RUTAS_Nombre")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de las rutas", ex)
        End Try
    End Sub

    Private Sub actxaCodCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaCliRuc.KeyDown
        Try
            If actxaCliRuc.ACAyuda.Enabled Then
                If e.KeyData = Keys.Enter Then
                    If actxaCliRuc.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
                        '' Cargar datos adicionales cliente
                        If actxaCliRuc.ACAyuda.Enabled = True Then
                            setCliente()
                        End If
                    Else
                        If actxaCliRuc.Text.Trim().Length > 0 Then
                            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaCliRuc.Text))
                            btnClean_Click(Nothing, Nothing)
                            lblNroDocumento.Focus()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
        End Try
    End Sub

    Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
        Try
            busqueda(txtBusqueda.Text)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
        End Try
    End Sub

    Private Sub actxnMontoXTm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles actxnMontoXTm.LostFocus,
                                                                                                     actxnPeso.LostFocus,
                                                                                                     actxnMontoXTm.LostFocus,
                                                                                                     actxnIGV.LostFocus
        Calcular()
    End Sub
#End Region

    Private Sub Calcular()
        Try
            Dim _monto As Decimal = Math.Round(Convert.ToDouble(actxnMontoXTm.Text), 6, MidpointRounding.AwayFromZero)
            Dim _peso As Decimal = actxnPeso.Text
            Dim _igv As Decimal = actxnIGV.Text


            If (Convert.ToDecimal(_peso) < 21.00) Then
                actxnMonto.Text = (_monto + _igv) * _peso : actxnMonto.Formatear()
                actxnTotalValorReferencial.Text = Math.Round(Convert.ToDouble(actxnValorReferencialXTm.Text) * 21, 2, MidpointRounding.AwayFromZero) * _peso : actxnTotalValorReferencial.Formatear()
                       Dim    A AS INTEGER= Math.Round(Convert.ToDouble(actxnValorReferencialXTm.Text) * 21, 2, MidpointRounding.AwayFromZero) * _peso : actxnTotalValorReferencial.Formatear()

            Else

                actxnMonto.Text = (_monto + _igv) * _peso : actxnMonto.Formatear()
            actxnTotalValorReferencial.Text = Math.Round(Convert.ToDouble(actxnValorReferencialXTm.Text) , 2, MidpointRounding.AwayFromZero) * _peso : actxnTotalValorReferencial.Formatear()


            End If

        Catch ex As Exception
            actxnMonto.Text = "0.00"
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
                acTool_ACBtnModificar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar el registro seleccionado", ex)
        End Try

    End Sub

    Private Sub _gotfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCarga.GotFocus
        Me.KeyPreview = False
    End Sub

    Private Sub _lostfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCarga.LostFocus
        Me.KeyPreview = True
    End Sub

    Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Enter Then
            If sender.Name = "txtBusqueda" Then
                Exit Sub
            ElseIf sender.name = "txtCarga" Then
                Exit Sub
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        txtBusqueda_ACAyudaClick(Nothing, Nothing)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            NuevaEntidad("")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Cliente", ex)
        End Try
    End Sub

    Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClean.Click
        Try
            managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo = ""
            actxaCliente.Clear()
            actxaCliRuc.Clear()
            actxaCliRuc.Focus()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Limpiar Entidad", ex)
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            If Not IsNothing(managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo) Then
                Dim frmEntidad As New MEntidad(managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo, MEntidad.Inicio.ModificarEntidad, ACEVentas.EEntidades.TipoEntidad.Clientes)
                frmEntidad.StartPosition = FormStartPosition.CenterScreen
                frmEntidad.lblNombres.Focus()

                If frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo = frmEntidad.EEntidad.ENTID_Codigo
                    managerEntidades.Entidades = frmEntidad.EEntidad
                    actxaCliente.Text = managerEntidades.Entidades.ENTID_RazonSocial
                    actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Editar el cliente", ex)
        End Try
    End Sub

    Private Sub btnRNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRNuevo.Click
        Try
            Dim frmRuta As New MRutas(MRutas.TRuta.Nueva) With {.StartPosition = FormStartPosition.CenterScreen}
            If frmRuta.ShowDialog() = Windows.Forms.DialogResult.OK Then
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id = frmRuta.TRAN_Rutas.RUTAS_Id
                actxaCodRuta.Text = frmRuta.TRAN_Rutas.RUTAS_Id
                actxaRuta.Text = frmRuta.TRAN_Rutas.RUTAS_Nombre
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnREditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnREditar.Click
        Try
            If managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id > 0 Then
                Dim frmRuta As New MRutas(managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id) With {.StartPosition = FormStartPosition.CenterScreen}
                If frmRuta.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id = frmRuta.TRAN_Rutas.RUTAS_Id
                    actxaCodRuta.Text = frmRuta.TRAN_Rutas.RUTAS_Id
                    actxaRuta.Text = frmRuta.TRAN_Rutas.RUTAS_Nombre
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Editar la Ruta", ex)
        End Try
    End Sub

    Private Sub btnRClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRClean.Click
        Try
            managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Codigo = ""
            actxaRuta.Clear()
            actxaCodRuta.Clear()
            actxaCodRuta.Focus()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Limpiar la Ruta", ex)
        End Try
    End Sub

    Private Sub acbtnRecOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acbtnRecOrden.Click
        Try
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Generar Viaje: {0}", Me.Text) _
                , String.Format("Desea generar el Viaje de la cotización: {0}?", CType(bs_btran_cotizaciones.Current, ETRAN_Cotizaciones).COTIZ_Codigo) _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                managerTRAN_Cotizaciones.TRAN_Cotizaciones = CType(bs_btran_cotizaciones.Current, ETRAN_Cotizaciones)
                managerAdministracionViajes.TRAN_Cotizaciones = managerTRAN_Cotizaciones.TRAN_Cotizaciones
                Dim _fflete As New FFlete(managerAdministracionViajes.TRAN_Cotizaciones) With {.StartPosition = FormStartPosition.CenterScreen}
                Select Case _fflete.ShowDialog()
                    Case Windows.Forms.DialogResult.OK
                        busqueda(txtBusqueda.Text)
                    Case Windows.Forms.DialogResult.Yes
                        Dim frmViajes As New FViajes(FViajes.TipoCarga.Base)
                        frmViajes.MdiParent = Me.MdiParent
                        frmViajes.StartPosition = FormStartPosition.CenterScreen
                        frmViajes.Show()
                    Case Else
                        busqueda(txtBusqueda.Text)
                End Select
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Generar y Recepcionar Orden de Transporte", ex)
        End Try
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
#End Region

    Private Sub cmbMoneda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbMoneda.KeyDown
        If e.KeyData = Keys.Enter Then
            KeyPreview = False
            acTool.Focus()
            acTool.ACBtnGrabar.Select()
        End If
    End Sub

    Private Sub chkIGV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIGV.CheckedChanged
        actxnIGV.Enabled = chkIGV.Checked
        Try
            If chkIGV.Checked Then
                Dim _igv As Decimal = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
                Dim _monto As Decimal = actxnMontoXTm.Text
                actxnIGV.Text = _monto * (_igv / 100)
                actxnIGV.Formatear()
            Else
                actxnIGV.Text = "0.00"
            End If
            Calcular()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub actxaCodRuta_KeyDown(sender As Object, e As KeyEventArgs) Handles actxaCodRuta.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                If actxaCodRuta.Text.Length > 0 Then
                    If IsNumeric(actxaCodRuta.Text) Then
                        If managerTRAN_Rutas.Cargar(actxaCodRuta.Text) Then
                            actxaCodRuta.Text = managerTRAN_Rutas.TRAN_Rutas.RUTAS_Id
                            actxaRuta.Text = managerTRAN_Rutas.TRAN_Rutas.RUTAS_Nombre
                            actxtUbigoOrigen.Text = managerTRAN_Rutas.TRAN_Rutas.UBIGO_CodOrigen
                            actxtUbigoDestino.Text = managerTRAN_Rutas.TRAN_Rutas.UBIGO_CodDestino
                            lblFecha.Focus()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar Codigo de Ruta"), ex)
        End Try
    End Sub

    Private Sub FCotizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub acTool_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles acTool.ItemClicked

    End Sub

    Private Sub actextBusqDescripcion_ACAyudaClick(sender As Object, e As EventArgs) Handles actextBusqDescripcion.ACAyudaClick
        'Busqueda por Descripcion 

        Try
            Dim b_Direcciones As New BDirecciones()

            Dim bs_direccion = New BindingSource()
            Dim bs_direccion_ As List(Of EDirecciones)
            Dim direccion = New BindingSource()
            If (b_Direcciones.AYUDASS_Busq_X_UBIGEOS_Descripcion(actextBusqDescripcion.Text)) Then

                bs_direccion_ = b_Direcciones.ListDirecciones()

                ' Cargar la lista modificada al ComboBox
                ACFramework.ACUtilitarios.ACCargaCombo(cmbDireccionDestino, Colecciones.TiposDireccionesXVariableDestino(b_Direcciones.ListDirecciones, actxaCliRuc.Text, actextBusqDescripcion.Text), "DIREC_Direccion", "DIREC_Direccion")
            Else

                MessageBox.Show("No hay direcciones ")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub btnModificarDesdeFactura_Click(sender As Object, e As EventArgs) Handles btnModificarDesdeFactura.Click
        'Modificamos todo desde la Factura 
        Dim msg As String = ""

        Try
            If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
                Dim managerTRAN_Cotizaciones = New BTRAN_Cotizaciones()

                managerTRAN_Cotizaciones.TRAN_Cotizaciones = New ETRAN_Cotizaciones()

                managerTRAN_Cotizaciones.TRAN_Cotizaciones.SUCUR_Id = GApp.Sucursal
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.ZONAS_Codigo = GApp.Zona
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.PVENT_Id = GApp.PuntoVenta
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Id = managerTRAN_Cotizaciones.getCorrelativo("COTIZ_Id")
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Nombre = actxaRuta.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_ValorReferencial = actxnValorReferencialXTm.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_TotalValorReferencial = actxnTotalValorReferencial.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.UBIGO_CodigoOrigen = actxtUbigoOrigen.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.UBIGO_CodigoDestino = actxtUbigoDestino.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoOrigen = cmbDireccionOrigen.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoDestino = cmbDireccionDestino.Text
                managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo = X_GLOBAL_COTIZACION
                managerAdministracionViajesModificacion.TRAN_Cotizaciones = managerTRAN_Cotizaciones.TRAN_Cotizaciones

                'globales_.x_rutas_id = Integer.Parse(actxaCodRuta.Text)
                If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Modificacion de COTIZACION Y FLETE {0}", Me.Text) _
            , String.Format("ESTA ACCION MODIFICARA LOS PUNTOS DE ORIGEN Y LLEGADA (UBIGEOS) EN LA COTIZACION Y EL FLETE  {0}", actxaCliRuc.Text) _
                , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then


                    setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                    If managerAdministracionViajesModificacion.GuardarCotizacion(GApp.Usuario, GApp.FechaProceso.Year.ToString()) Then
                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                        tabMantenimiento.SelectedTab = tabBusqueda
                        busqueda(txtBusqueda.Text)
                        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                        Me.KeyPreview = False
                        txtBusqueda.Focus()
                        setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                        Me.KeyPreview = False
                        setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                        managerAdministracionViajesModificacion.GuardarFleteXCotizacion(GApp.Usuario, actxaRuta.Text, X_GLOBAL_COTIZACION, True)
                        'Cerramos el Formulario de Cotizacion ... y abrimos de nuevo el Form de Facturacion 
                        Me.Close()
                        'Abrirmos el nuevo Form de Facturacion 
                        Dim form_facturacionFletes As New PFacturacionFletes(TInicio.Normal) With {.StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Normal}
                        form_facturacionFletes.Show()
                    Else
                        acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar{0}", msg))
                    End If
                Else
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar, por que hay campos obligatorios vacios: {0}", msg))
                End If


            Else

                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("Se cancelo La Operacion ", msg))

            End If

        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
        End Try
    End Sub

    Private Sub cmbDireccionOrigen_Click(sender As Object, e As EventArgs) Handles cmbDireccionOrigen.Click
        'Al momento de hacer click se le va a desglozar todos  las Direcciones de Origenes 
        Try
            Dim b_Direcciones As New BDirecciones()

            Dim bs_direccion = New BindingSource()
            Dim bs_direccion_ As List(Of EDirecciones)
            Dim direccion = New BindingSource()
            If (b_Direcciones.AYUDASS_Busq_X_UBIGEOS(actxaCliRuc.Text)) Then

                bs_direccion_ = b_Direcciones.ListDirecciones()

                ' Cargar la lista modificada al ComboBox
                ACFramework.ACUtilitarios.ACCargaCombo(cmbDireccionOrigen, Colecciones.TiposDireccionesXVariableOrigen(b_Direcciones.ListDirecciones, actxaCliRuc.Text, actextBusqDescripcion.Text), "DIREC_Direccion", "DIREC_Direccion")
            Else

                MessageBox.Show("No hay direcciones  ")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbDireccionDestino_Click(sender As Object, e As EventArgs) Handles cmbDireccionDestino.Click
        'Al momento de hacer click se le va a desglozar todos  las Direcciones de Destinos 
        Try
            Dim b_Direcciones As New BDirecciones()

            Dim bs_direccion = New BindingSource()
            Dim bs_direccion_ As List(Of EDirecciones)
            Dim direccion = New BindingSource()
            If (b_Direcciones.AYUDASS_Busq_X_UBIGEOS(actxaCliRuc.Text)) Then

                bs_direccion_ = b_Direcciones.ListDirecciones()

                ' Cargar la lista modificada al ComboBox
                ACFramework.ACUtilitarios.ACCargaCombo(cmbDireccionDestino, Colecciones.TiposDireccionesXVariableDestino(b_Direcciones.ListDirecciones, actxaCliRuc.Text, actextBusqDescripcion.Text), "DIREC_Direccion", "DIREC_Direccion")
            Else

                MessageBox.Show("No hay direcciones ")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub actextBusqDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles actextBusqDescripcion.KeyDown
        If e.KeyData = Keys.Enter Then
            If actextBusqDescripcion.Text.Length > 0 Then
                Try
                    Dim b_Direcciones As New BDirecciones()

                    Dim bs_direccion = New BindingSource()
                    Dim bs_direccion_ As List(Of EDirecciones)
                    Dim direccion = New BindingSource()
                    If (b_Direcciones.AYUDASS_Busq_X_UBIGEOS(actxaCliRuc.Text)) Then

                        bs_direccion_ = b_Direcciones.ListDirecciones()

                        ' Cargar la lista modificada al ComboBox
                        ACFramework.ACUtilitarios.ACCargaCombo(cmbDireccionDestino, Colecciones.TiposDireccionesXVariableDestino(b_Direcciones.ListDirecciones, actxaCliRuc.Text, actextBusqDescripcion.Text), "DIREC_Direccion", "DIREC_Direccion")
                    Else

                        MessageBox.Show("No hay Direcciones de Destinos Amarrados a Este Ruc ")

                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub

    'Private Sub cmbDestinoDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDestinoDepartamento.SelectedIndexChanged
    '    'Cada que Haga cLICK SE CONCATENA CON LO QUE TIENE LA DIRECCION CLIENTE 
    '    Dim x_direccionOrigen As String = ""
    '    Dim direccion As String = m_vauldirecciondestino + "/" + cmbDestinoDepartamento.Text + "/" '+ cmbDestinoProvincia.Text + "/" + cmbDestinoDistrito.Text
    '    m_vauldirecciondestino = direccion
    '    cmbDireccionDestino.Text = direccion

    'End Sub

    'Private Sub cmbDestinoProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDestinoProvincia.SelectedIndexChanged
    '    'Cada click se concatena con l oque tiene la direccion cliente 

    '    Dim x_direccionOrigen As String = ""
    '    Dim direccion As String = m_vauldirecciondestino + cmbDestinoDepartamento.Text + "/" '+ cmbDestinoProvincia.Text '+ "/" + cmbDestinoDistrito.Text
    '    m_vauldirecciondestino = direccion
    '    cmbDireccionDestino.Text = direccion


    'End Sub


End Class