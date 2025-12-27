Imports ACBVentas
Imports ACEVentas
Imports ACFramework
Imports C1.Win.C1FlexGrid

Public Class MAdministracionUsuarios
#Region " Variables "
    Private managerVENT_UsuariosPorPuntoVenta As BUsuariosPorPuntoVenta
    Private managerEntidades As BEntidades
    Private bs_sucursales As BindingSource
    Private bs_puntoventa As BindingSource
    Private bs_usuarios As BindingSource
    Private bs_zonas As BindingSource
    Private m_listBindHelper As List(Of ACBindHelper)
    Private m_ealmacen As EAlmacenes

#End Region


#Region "Inicializacion"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Try
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda
            formatearGrilla()
            managerVENT_UsuariosPorPuntoVenta = New BUsuariosPorPuntoVenta()
            managerEntidades = New BEntidades()
            cargarCombos()
            m_listBindHelper = New List(Of ACBindHelper)()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "Ocurrio un error en el proceso Inicio de controles primarios", ex)
        End Try
    End Sub


#End Region


#Region "Obtencion de Registros"

    Private Sub cargarCombos()
        Try
            bs_zonas = New BindingSource()
            bs_zonas.DataSource = Colecciones.Zonas
            ACUtilitarios.ACCargaCombo(cmbZona, bs_zonas, "ZONAS_Descripcion", "ZONAS_Codigo", GApp.Zona)
            AddHandler bs_zonas.CurrentChanged, AddressOf bs_zonas_CurrentChanged
            bs_zonas_CurrentChanged(Nothing, Nothing)

            cmbZona.Enabled = False
            'bs_sucursales = New BindingSource
            'bs_sucursales.DataSource = Colecciones.Sucursales

            'ACFramework.ACUtilitarios.ACCargaCombo(cmbSucursal, bs_sucursales, "SUCUR_Nombre", "SUCUR_Id")
            'AddHandler bs_sucursales.CurrentChanged, AddressOf bs_sucursales_CurrentChanged
            'bs_sucursales_CurrentChanged(Nothing, Nothing)

            'Me.Icon = Icon.FromHandle(ACPVentas.My.Resources.SucursalSeguridad_16x16.GetHicon)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "Iniciar Instancias "
    Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)

        Select Case _opcion
            Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
                ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
                ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
            Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
                ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

            Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

        End Select

    End Sub
#End Region


#Region "BindingSources"
    Private Sub bs_zonas_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Obtencion de las Zonas 
        Try
            If Not IsNothing(bs_zonas) Then
                If CType(bs_zonas.DataSource, List(Of EZonas)).Count > 0 Then
                    Dim x_zona As String = cmbZona.SelectedValue
                    Dim _filter As New ACFiltrador(Of ESucursales)() With {.ACFiltro = String.Format("ZONAS_Codigo={0}", x_zona)}
                    bs_sucursales = New BindingSource()
                    bs_sucursales.DataSource = _filter.ACFiltrar(Colecciones.Sucursales)
                    ACUtilitarios.ACCargaCombo(cmbSucursal, bs_sucursales, "SUCUR_Nombre", "SUCUR_Id", GApp.Sucursal)

                    AddHandler bs_sucursales.CurrentChanged, AddressOf bs_sucursales_CurrentChanged
                    bs_sucursales_CurrentChanged(Nothing, Nothing)

                    cmbSucursal.Enabled = False
                End If
            End If

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Sucursales", ex)
        End Try
    End Sub
    Private Sub bs_sucursales_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Obtencion de sucursales 
        Try
            Dim _filter As New ACFiltrador(Of EPuntoVenta)
            _filter.ACFiltro = String.Format("ZONAS_Codigo={0} AND SUCUR_Id={1}", cmbZona.SelectedValue, cmbSucursal.SelectedValue)

            bs_puntoventa = New BindingSource
            bs_puntoventa.DataSource = _filter.ACFiltrar(Colecciones.PuntosVenta)
            c1grdPuntoVenta.DataSource = bs_puntoventa
            bnavPuntoVenta.BindingSource = bs_puntoventa
            AddHandler bs_puntoventa.CurrentChanged, AddressOf bs_puntoventa_CurrentChanged
            bs_puntoventa_CurrentChanged(Nothing, Nothing)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cambiar sucursales", ex)
        End Try
    End Sub
    Private Sub bs_puntoventa_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Obtencion de Puntos 
        Try
            If Not IsNothing(bs_puntoventa.Current) Then
                If Not managerEntidades.getListUsuariosXPuntoVenta(CType(bs_puntoventa.Current, EPuntoVenta).PVENT_Id) Then
                    managerEntidades.ListEntidades = New List(Of EEntidades)
                End If
            Else
                managerEntidades.ListEntidades = New List(Of EEntidades)
            End If
            bs_usuarios = New BindingSource
            bs_usuarios.DataSource = managerEntidades.ListEntidades
            c1grdUsuarios.DataSource = bs_usuarios
            bnavUsuarios.BindingSource = bs_usuarios
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cambiar Punto de Venta", ex)
        End Try
    End Sub


#End Region

#Region "Eventos Botones "
    Private Sub tsbtnAgregar_Click(sender As Object, e As EventArgs) Handles tsbtnAgregar.Click
        'Funcion agregar Rgistros a Punto transportes 
        Try
            Dim m_datos As New DataTable
            If managerEntidades.getUsuarios(GApp.BaseDatosAdmin, m_datos) Then
                Dim frmAyuda As New ACControlesC1.ACAyudaFlex("Usuarios Disponibles", m_datos, False)
                If frmAyuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim m_userporpvent As New EUsuariosPorPuntoVenta()
                    m_userporpvent.ENTID_Codigo = CType(frmAyuda.Respuesta.Rows(0)("Código"), Long)
                    m_userporpvent.PVENT_Id = CType(bs_puntoventa.Current, EPuntoVenta).PVENT_Id
                    m_userporpvent.SUCUR_Id = cmbSucursal.SelectedValue
                    m_userporpvent.ZONAS_Codigo = cmbZona.SelectedValue
                    m_userporpvent.Instanciar(ACEInstancia.Nuevo)
                    managerVENT_UsuariosPorPuntoVenta.setUsuariosPorPuntoVenta(m_userporpvent)
                    managerVENT_UsuariosPorPuntoVenta.Guardar(GApp.Usuario)
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Agregado satisfactoriamente")
                    bs_puntoventa_CurrentChanged(Nothing, Nothing)
                End If
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No hay usuarios disponibles ")
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso buscar usuario disponible", ex)
        End Try
    End Sub

    Private Sub tsbtnQuitar_Click(sender As Object, e As EventArgs) Handles tsbtnQuitar.Click
        'Funcion quitar Registros a Punto transportes
        Try
            If Not IsNothing(bs_usuarios.Current) Then
                Dim m_userporpvent As New EUsuariosPorPuntoVenta()
                m_userporpvent.ENTID_Codigo = CType(bs_usuarios.Current, EEntidades).ENTID_Codigo
                m_userporpvent.PVENT_Id = CType(bs_puntoventa.Current, EPuntoVenta).PVENT_Id
                m_userporpvent.SUCUR_Id = CType(bs_puntoventa.Current, EPuntoVenta).SUCUR_Id
                m_userporpvent.ZONAS_Codigo = CType(bs_puntoventa.Current, EPuntoVenta).ZONAS_Codigo
                m_userporpvent.Instanciar(ACEInstancia.Eliminado)
                managerVENT_UsuariosPorPuntoVenta.setUsuariosPorPuntoVenta(m_userporpvent)
                managerVENT_UsuariosPorPuntoVenta.Guardar(GApp.Usuario)
                ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Eliminado satisfactoriamente")
                bs_puntoventa_CurrentChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso quitar usuario", ex)
        End Try
    End Sub

#End Region


#Region "Efector UI"


#End Region
#Region "Formateo de Grillas"
    Private Sub formatearGrilla()
        Dim index As Integer = 1
        Try
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdPuntoVenta, 1, 1, 4, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPuntoVenta, index, "Codigo", "PVENT_Id", "PVENT_Id", 150, True, False, "System.Integer", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPuntoVenta, index, "Descripción", "PVENT_Descripcion", "PVENT_Descripcion", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPuntoVenta, index, "Almacen", "ALMAC_Nombre", "ALMAC_Nombre", 150, True, False, "System.String", "") : index += 1

            c1grdPuntoVenta.AllowEditing = False
            c1grdPuntoVenta.Styles.Alternate.BackColor = Color.LightGray
            c1grdPuntoVenta.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdPuntoVenta.Styles.Highlight.BackColor = Color.Gray
            c1grdPuntoVenta.SelectionMode = SelectionModeEnum.Row

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdUsuarios, 1, 1, 6, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdUsuarios, index, "Codigo", "ENTID_Codigo", "ENTID_Codigo", 150, True, False, "System.Integer", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdUsuarios, index, "Nombre", "ENTID_Nombres", "ENTID_Nombres", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdUsuarios, index, "D.N.I.", "USUAR_Codigo", "USUAR_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdUsuarios, index, "EMail", "ENTID_EMail", "ENTID_EMail", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdUsuarios, index, "Interno", "ENTID_Id", "ENTID_Id", 150, True, False, "System.String", "") : index += 1

            c1grdUsuarios.AllowEditing = False
            c1grdUsuarios.Styles.Alternate.BackColor = Color.LightGray
            c1grdUsuarios.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdUsuarios.Styles.Highlight.BackColor = Color.Gray
            c1grdUsuarios.SelectionMode = SelectionModeEnum.Row

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
        End Try
    End Sub


#End Region

End Class