Imports ComponentFactory.Krypton.Toolkit
Imports ACBAppMovil
Imports ACEAppMovil
Imports ACFramework
'Libererias para Encriptacion 
Imports System.Security.Cryptography
Imports System.Text
Imports ACBVentas
Imports ACEVentas
Imports ZXing


Public Class Administracion_AppMovil_Usuarios
    Inherits KryptonForm
    Private managerTRANGUIAS_Usuarios As BTRANGUIAS_Usuarios
    Private managerETRANGuias_Usuario As ETRANGUIAS_Usuarios
    Private managerETRANGuias_Entidades As ETRANGUIAS_Entidades
    Private managerBTRANGuias_Entidades As BTRANGUIAS_Entidades

    Private managerBConductores As BConductores
    Private mangerBEntidades As BEntidades


    Private managerETRANGuias_Tipos As ETRANGUIAS_Tipos
    Private ManagerGUIASTipos As BTRANGUIAS_Tipos
    Private BindingUsuarios As BindingSource

    Private managerEListBTRANGUIAS_Tipos As List(Of ETRANGUIAS_Tipos)

    Private managerEntidades As BEntidades
    Private managerEEntidades As EEntidades

    'vARIABLES ADICONALES 


    Private managerEncryptation As EncryptationHash
    'Variables para accion del Formulario 

    Private _accionActual As AccionFormulario = AccionFormulario.Ninguna
    Private km As KryptonManager


    Dim ENTID_Codigo As String = ""
    Dim X_Dni As String = ""

    Public Enum AccionFormulario
        IniciarForm = 0

        Ninguna = 1
        Nuevo = 2
        Modificar = 3
        Eliminar = 4
        Guardar = 5
        Deshacer = 6
        GrabarOtro = 7
    End Enum


    Private Sub EjecutarToolsStripAControles()
        ToolTipMensajeBusquedaDni.SetToolTip(KryTextBusqUsuario, "Dale Enter Papu ")
        ToolTipMensajeDniUsuario.SetToolTip(KryTxtDni, "Date Enter Papu")

    End Sub


    Private Sub Administracion_AppMovil_Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        km = New KryptonManager()
        km.GlobalPaletteMode = PaletteModeManager.Office2010Blue
        _accionActual = AccionFormulario.IniciarForm
        FormateosdeGrilla()
        CentrarGroupBox()
        EjecutarToolsStripAControles()
        '1 =======================================================================+
        Instancia(_accionActual)

    End Sub
    'Funcion para centrar el KryptonGroup al panel 
    Private Sub CentrarGroupBox()
        KryptonGroup3.Left = (KryptonGroupBox7.Width - KryptonGroup3.Width) \ 2
        KryptonGroup3.Top = (KryptonGroupBox7.Height - KryptonGroup3.Height) \ 2
    End Sub

    'iNICIALIZAD EL MOENSAJE 
    Private Function InicializarNotify()
        NotifyAlert = New NotifyIcon()
        NotifyAlert.Icon = SystemIcons.Information ' Puedes cambiarlo
        NotifyAlert.Visible = True
        Return True
    End Function
    'Mensaje de Confirmacino Para usuarios 

    'Aqui hago una funcion 

    Private Sub MostrarNotificacionConfirmacion()
        Try
            NotifyAlert.Icon = SystemIcons.Information ' O tu propio icono
            NotifyAlert.Visible = True
            NotifyAlert.Text = "Informacion"
            NotifyAlert.BalloonTipText = "El Usuario se Grabo Correctamente"
            NotifyAlert.BalloonTipIcon = ToolTipIcon.Info
            NotifyAlert.ShowBalloonTip(5000)
        Catch ex As NullReferenceException
            Debug.WriteLine("SE CERROE STO PONGO ESTO PARA QUE NO ME SLAE ")
        End Try
    End Sub
    Private Sub MostrarNotificacionErrorRepetidos()
        Try
            NotifyAlert.Icon = SystemIcons.Error ' O tu propio icono
            NotifyAlert.Visible = True
            NotifyAlert.Text = "Alert"
            NotifyAlert.BalloonTipText = "El Usuario ya esta Registrado"
            NotifyAlert.BalloonTipIcon = ToolTipIcon.Info
            NotifyAlert.ShowBalloonTip(5000)
        Catch ex As NullReferenceException
            Debug.WriteLine("SE CERROE STO PONGO ESTO PARA QUE NO ME SLAE ")
        End Try

        ' Duración en milisegundos'System.NullReferenceException: 'Referencia a objeto no establecida como instancia de un objeto.'

    End Sub


    Private Sub MostrarMensajePersonalizado(ByVal Mensaje As String)
        Try
            NotifyAlert.Icon = SystemIcons.Information ' O tu propio icono
            NotifyAlert.Visible = True
            NotifyAlert.Text = "Alert"
            NotifyAlert.BalloonTipText = Mensaje
            NotifyAlert.BalloonTipIcon = ToolTipIcon.Info
            NotifyAlert.ShowBalloonTip(5000)
        Catch ex As NullReferenceException
            Debug.WriteLine("SE CERROE STO PONGO ESTO PARA QUE NO ME SLAE ")
        End Try

        ' Duración en milisegundos'System.NullReferenceException: 'Referencia a objeto no establecida como instancia de un objeto.'

    End Sub

    Private Sub MostrarNotificacionEliminado()
        Try
            NotifyAlert.Icon = SystemIcons.Exclamation ' O tu propio icono
            NotifyAlert.Visible = True
            NotifyAlert.Text = "Alerta"
            NotifyAlert.BalloonTipText = "Se Elimino el Usuario "
            NotifyAlert.BalloonTipIcon = ToolTipIcon.Info
            NotifyAlert.ShowBalloonTip(5000)
        Catch ex As NullReferenceException
            Debug.WriteLine("SE CERROE STO PONGO ESTO PARA QUE NO ME SLAE ")
        End Try


        ' Duración en milisegundos'System.NullReferenceException: 'Referencia a objeto no establecida como instancia de un objeto.'

    End Sub
    Private Sub MostrarNotificacionUpdate()
        Try
            NotifyAlert.Icon = SystemIcons.Information ' O tu propio icono
            NotifyAlert.Visible = True
            NotifyAlert.Text = "Alerta"
            NotifyAlert.BalloonTipText = "Se Actualizo El Usuario "
            NotifyAlert.BalloonTipIcon = ToolTipIcon.Info
            NotifyAlert.ShowBalloonTip(5000)
        Catch ex As NullReferenceException
            Debug.WriteLine("SE CERROE STO PONGO ESTO PARA QUE NO ME SLAE ")
        End Try


        ' Duración en milisegundos'System.NullReferenceException: 'Referencia a objeto no establecida como instancia de un objeto.'

    End Sub

    Private Function Instancia(ByVal Acccion As AccionFormulario) 'Instancia para las acciones del formulario
        Select Case Acccion
            Case AccionFormulario.IniciarForm 'Recuerda papu no metas limpieza e formulario aqui .. me desordenas todo .. en la funcion controles haces estooooo 
                Controles(AccionFormulario.IniciarForm)
                LoadAllUsersActivos()

            Case AccionFormulario.Guardar
                Controles(AccionFormulario.Guardar)
                LoadAllUsersActivos()

            Case AccionFormulario.Nuevo
                Controles(AccionFormulario.Nuevo)
                'LoadAllUsersActivos()

                CargarCombobox() 'Funcion para iniciarliar Combobox 
            Case AccionFormulario.Modificar
                Controles(AccionFormulario.Modificar)
                IniciarProcesoModificacionUsuario()
                CargarCombox_Tipo_X_Usuario()

            Case AccionFormulario.Deshacer

                Controles(AccionFormulario.Deshacer)

            Case AccionFormulario.GrabarOtro
                Controles(AccionFormulario.GrabarOtro)

            Case AccionFormulario.Eliminar

                Controles(AccionFormulario.Eliminar)


        End Select
        'Public Shared Sub ACCargaCombo(ByRef x_combo As ComboBox, x_lista As Object, x_campoDescripcion As String, x_campoCodigo As String)

    End Function

    Public Function Controles(ByVal Acccion As AccionFormulario)
        Select Case Acccion
            Case AccionFormulario.IniciarForm
                KryBtnNuevo.Enabled = True
                KryBtnVolver.Enabled = False
                KryRbtnNatural.Checked = True
                KryBtnDelete.Enabled = False
                KryBtnUpdateUser.Enabled = False
                KryBtnDeleteUser.Enabled = False
                KryDataGrid_Usuarios.ReadOnly = True
                KryCmbTipoEntidad.DropDownStyle = ComboBoxStyle.DropDownList 'Desactivamos la edicion del Dropdown 
                KryCmbTypeUser.DropDownStyle = ComboBoxStyle.DropDownList
                'Funciones de Form 
                KryptonNavUsuarios.Pages("KrpPagUsuario").Visible = False
                KryptonNavUsuarios.Pages("KrptpagAdministradorUsuarios").Visible = True
                'KryBtnDeleteUser.Enabled = False

            Case AccionFormulario.Guardar
                KryBtnNuevo.Enabled = True
                KryBtnVolver.Enabled = False
                KryBtnDelete.Enabled = False
                KryDataGrid_Usuarios.ReadOnly = True
                'KryBtnDeleteUser.Enabled = False
                'Funciones de Form 
                KryptonNavUsuarios.Pages("KrpPagUsuario").Visible = False
                KryptonNavUsuarios.Pages("KrptpagAdministradorUsuarios").Visible = True

            Case AccionFormulario.Nuevo
                KryBtnNuevo.Enabled = False
                KryBtnVolver.Enabled = True
                KryptonNavUsuarios.Pages("KrpPagUsuario").Visible = True
                KryptonNavUsuarios.Pages("KrptpagAdministradorUsuarios").Visible = False
                KryBtnGrabar.Enabled = True
                KryBtnDelete.Enabled = False
                KryBtnUpdate.Enabled = False
                KryDataGrid_Usuarios.ReadOnly = True
                'Agregamos evento al textbusqueda para que busque pe pap u 


                AddHandler KryTxtDni.KeyDown, AddressOf KryTxtDni_KeyDown

                limpiarFormulario()

            Case AccionFormulario.Modificar
                KryptonNavUsuarios.Pages("KrpPagUsuario").Visible = True
                KryptonNavUsuarios.Pages("KrptpagAdministradorUsuarios").Visible = False
                KryBtnNuevo.Enabled = False
                KryBtnVolver.Enabled = True
                KryBtnGrabar.Enabled = False
                KryBtnUpdate.Enabled = True
                KryBtnDelete.Enabled = False
                KryDataGrid_Usuarios.ReadOnly = True
                GenerarCodigoBarra()

                'Devinculamos el Enter yaq ue ya esta grabado 

                RemoveHandler KryTxtDni.KeyDown, AddressOf KryTxtDni_KeyDown
                CargarCombobox_Tipo_Documento_X_Usuario()
                CargarCombox_Tipo_X_Usuario()
                'KryBtnDeleteUser.Enabled = False

            Case AccionFormulario.Deshacer
                KryptonNavUsuarios.Pages("KrpPagUsuario").Visible = False
                KryptonNavUsuarios.Pages("KrptpagAdministradorUsuarios").Visible = True
                KryBtnNuevo.Enabled = True
                KryBtnVolver.Enabled = False
                KryDataGrid_Usuarios.ReadOnly = True

                KryBtnUpdateUser.Enabled = False
                KryBtnDeleteUser.Enabled = False
                'KryBtnDeleteUser.Enabled = False
                limpiarFormulario()

            Case AccionFormulario.GrabarOtro

                KryBtnNuevo.Enabled = False
                KryBtnVolver.Enabled = True
                KryDataGrid_Usuarios.ReadOnly = True
                AddHandler KryTxtDni.KeyDown, AddressOf KryTxtDni_KeyDown
                'KryBtnDeleteUser.Enabled = False
                limpiarFormulario()


            Case AccionFormulario.Eliminar

                KryBtnNuevo.Enabled = True
                KryBtnVolver.Enabled = False
                limpiarFormulario()
                LoadAllUsersActivos()

        End Select
    End Function

    Private Function CargarCombobox()
        Colecciones.Cargar_TRANGUIAS_Tipos()
        ManagerGUIASTipos = New BTRANGUIAS_Tipos()
        ManagerGUIASTipos.CargarTodos()
        ACUtilitarios.ACCargaCombo(KryCmbTypeUser, Colecciones.FiltrarTipos_RolENTIDADES(ManagerGUIASTipos.ListTipos), "TipoDescripcion", "TipoAbreviatura")
        ACUtilitarios.ACCargaCombo(KryCmbTipoEntidad, Colecciones.FiltrarTipos_ENTIDADES(ManagerGUIASTipos.ListTipos), "TipoDescripcion", "TipoAbreviatura")
    End Function

    Private Function CargarCombox_Tipo_X_Usuario() 'Carga roles conducto o Usuario general de acerudo al ruc o dni 

        Try
            Colecciones.Cargar_TRANGUIAS_Tipos()
            ManagerGUIASTipos = New BTRANGUIAS_Tipos
            managerEListBTRANGUIAS_Tipos = New List(Of ETRANGUIAS_Tipos)

            If (ManagerGUIASTipos.BusquedaTiposPorUsuarios(managerEListBTRANGUIAS_Tipos, ENTID_Codigo)) Then


                ACUtilitarios.ACCargaCombo(KryCmbTypeUser, ManagerGUIASTipos.ListTipos, "TipoDescripcion", "TipoAbreviatura")
                'ACUtilitarios.ACCargaCombo(KryCmbTipoEntidad, Colecciones.FiltrarTipos_ENTIDADES(ManagerGUIASTipos.ListTipos), "TipoDescripcion", "TipoAbreviatura")


            End If

        Catch ex As Exception
            KryptonMessageBox.Show("Error : => " + ex.Message)
        End Try



    End Function

    Private Function CargarCombobox_Tipo_Documento_X_Usuario() 'Carga Tipos de usuario si es ruc dni extranjero etc 

        Try
            Colecciones.Cargar_TRANGUIAS_Tipos()
            ManagerGUIASTipos = New BTRANGUIAS_Tipos
            managerEListBTRANGUIAS_Tipos = New List(Of ETRANGUIAS_Tipos)

            If (ManagerGUIASTipos.Busq_GUIAS_TIPOS_Entidad_X_Usuario(managerEListBTRANGUIAS_Tipos, ENTID_Codigo)) Then
                ACUtilitarios.ACCargaCombo(KryCmbTipoEntidad, ManagerGUIASTipos.ListTipos, "TipoDescripcion", "TipoAbreviatura")
                'ACUtilitarios.ACCargaCombo(KryCmbTipoEntidad, Colecciones.FiltrarTipos_ENTIDADES(ManagerGUIASTipos.ListTipos), "TipoDescripcion", "TipoAbreviatura")
            End If
        Catch ex As Exception
            KryptonMessageBox.Show("Error : => " + ex.Message)
        End Try
    End Function
    Private Function CargarCombox_Rol_X_Usuario() 'carga el tipo en general esto se usar para cuando un usuario  es nuevo entonces es necesario cargar todos

        Colecciones.Cargar_TRANGUIAS_Tipos()
        ManagerGUIASTipos = New BTRANGUIAS_Tipos()
        ManagerGUIASTipos.CargarTodos()
        ACUtilitarios.ACCargaCombo(KryCmbTypeUser, Colecciones.FiltrarTipos_ENTIDADES(ManagerGUIASTipos.ListTipos), "TipoDescripcion", "TipoAbreviatura")
        ACUtilitarios.ACCargaCombo(KryCmbTipoEntidad, Colecciones.FiltrarTipos_ENTIDADES(ManagerGUIASTipos.ListTipos), "TipoDescripcion", "TipoAbreviatura")

    End Function


    Private Sub IniciarProcesoModificacionUsuario()
        Try
            'KryBtnNuevo.Visible = False

            X_Dni = CType(BindingUsuarios.Current, ETRANGUIAS_Usuarios).ENTID_CodigoFk



            If TRAN_GUIAS_BusqUsuarioIindividual(X_Dni) Then
                KryptonNavUsuarios.Pages("KrpPagUsuario").Visible = True
                KryptonNavUsuarios.Pages("KrptpagAdministradorUsuarios").Visible = False

            Else
                KryptonMessageBox.Show("El usuario :" + X_Dni + "Fue Mal Creado o los Ruc o Dni No coinciden ")

                KryptonNavUsuarios.Pages("KrpPagUsuario").Visible = False

                KryptonNavUsuarios.Pages("KrptpagAdministradorUsuarios").Visible = True
            End If
        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Function LoadAllUsersActivos()
        Try
            managerTRANGUIAS_Usuarios = New BTRANGUIAS_Usuarios
            BindingUsuarios = New BindingSource()

            Dim _join As New List(Of ACJoin)()
            _join.Add(New ACJoin(ETRANGUIAS_Entidades.Esquema, ETRANGUIAS_Entidades.Tabla, "VTipos", ACJoin.TipoJoin.Inner _
                , New ACCampos() {New ACCampos("EntiDocumento", "ENTID_CodigoFk")})) 'ENTID_CodigoFk
            Dim x_where As New Hashtable()
            x_where.Add("GtusEstado", New ACWhere("1", ACWhere.TipoWhere.Igual))

            If (managerTRANGUIAS_Usuarios.CargarTodos(_join, x_where)) Then '  If (managerTRANGUIAS_Usuarios.CargarTodos(x_where)) Then
                BindingUsuarios.DataSource = managerTRANGUIAS_Usuarios.ListUsuariosApp
                KryDataGrid_Usuarios.DataSource = BindingUsuarios
            End If
            KryDataGrid_Usuarios.DataSource = BindingUsuarios
        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message)
        End Try
    End Function

    Private Function LoadAllUsers() 'Busca  a Los usuario sin importar nada 
        Try
            managerTRANGUIAS_Usuarios = New BTRANGUIAS_Usuarios
            BindingUsuarios = New BindingSource()

            Dim _join As New List(Of ACJoin)()
            _join.Add(New ACJoin(ETRANGUIAS_Entidades.Esquema, ETRANGUIAS_Entidades.Tabla, "VTipos", ACJoin.TipoJoin.Inner _
                , New ACCampos() {New ACCampos("EntiDocumento", "ENTID_CodigoFk")})) 'ENTID_CodigoFk
            Dim x_where As New Hashtable()
            x_where.Add("GtusId", New ACWhere(0, ACWhere.TipoWhere.MayorIgual))

            If (managerTRANGUIAS_Usuarios.CargarTodos(_join, x_where)) Then '  If (managerTRANGUIAS_Usuarios.CargarTodos(x_where)) Then
                BindingUsuarios.DataSource = managerTRANGUIAS_Usuarios.ListUsuariosApp
                KryDataGrid_Usuarios.DataSource = BindingUsuarios
            End If
            KryDataGrid_Usuarios.DataSource = BindingUsuarios
        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message)
        End Try
    End Function




    'Funcionaes para formatear el formulario para grabar a tros usuarios 


    Sub limpiarFormulario()


        KrytxtName.Clear()
        KryTxtDni.Clear()
        KrytxtPassword.Clear()
        KryChkActivo.Checked = False
        KryTxtUser.Clear()
        KryTxtRazonSocial.Clear()
        'Formateando CARD 

        KryLabelCardName.Text = "X"
        KryLabelCardRazonSocial.Text = "X"
        KryLabelCardTypeUser.Text = "X"
        KryLabelCardDate.Text = "X"

        KryTextBusqUsuario.Clear()
        KrytxtDireccion.Clear()

        'lIMPIEAMOS VARIABLES GLOBALES 
        X_Dni = ""
        ENTID_Codigo = ""

    End Sub

#Region "Limpiar Uduario"

#End Region
    ' Función para agregar columnas a un KryptonDataGridView con formato
    Public Sub AgregarColumna(
        grid As KryptonDataGridView,
        nombre As String,
        dataProperty As String,
        cabecera As String,
        ancho As Integer,
        visible As Boolean,
        formato As String)
        Dim col As New DataGridViewTextBoxColumn()
        col.Name = nombre
        col.DataPropertyName = dataProperty
        col.HeaderText = cabecera
        col.Width = ancho
        col.Visible = visible

        '  formato ( "dd/MM/yyyy HH:mm" o "N2")
        If Not String.IsNullOrEmpty(formato) Then
            col.DefaultCellStyle.Format = formato
        End If

        grid.Columns.Add(col)
    End Sub
    Public Sub AgregarColumnaCheck(
        grid As KryptonDataGridView,
        nombre As String,
        dataProperty As String,
        cabecera As String,
        ancho As Integer,
        visible As Boolean)

        Dim col As New DataGridViewCheckBoxColumn()
        col.Name = nombre
        col.DataPropertyName = dataProperty
        col.HeaderText = cabecera
        col.Width = ancho
        col.Visible = visible
        col.ThreeState = False  ' solo True/False

        grid.Columns.Add(col)
    End Sub
    Private Sub KryDataGrid_Usuarios_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
    Handles KryDataGrid_Usuarios.CellFormatting

        If KryDataGrid_Usuarios.Columns(e.ColumnIndex).Name = "TipoDoc" Then
            If e.Value IsNot Nothing Then
                Select Case CInt(e.Value)
                    Case 1 : e.Value = "Administrador"
                    Case 2 : e.Value = "Usuario normal"
                End Select
                e.FormattingApplied = True
            End If
        End If
    End Sub


    Private Function FormateosdeGrilla()
        KryDataGrid_Usuarios.AutoGenerateColumns = False
        Dim index As Integer = 1
        Try
            KryDataGrid_Usuarios.Columns.Clear()
            AgregarColumna(KryDataGrid_Usuarios, "Codigo", "ENTID_CodigoFk", "Codigo", 150, True, "########0")
            AgregarColumna(KryDataGrid_Usuarios, "Usuario", "GtusUsuario", "Usuario", 250, True, "")
            AgregarColumna(KryDataGrid_Usuarios, "TipoDoc", "TiposUsuariosFk", "TipoDoc", 100, True, "")
            AgregarColumnaCheck(KryDataGrid_Usuarios, "EstadoUsuario", "GtusEstado", "EstadoUsuario", 150, True)
            AgregarColumna(KryDataGrid_Usuarios, "Creado .El", "GtusFecCreacion", "Creado .El", 150, True, "dd/MM/yyyy HH:mm")
            AgregarColumna(KryDataGrid_Usuarios, "Creado.Por", "GtusUsrCreacion", "Creado.Por", 120, True, "")
            AgregarColumna(KryDataGrid_Usuarios, "Ultima.Modificacion", "Ultima.Modificacion", "GtusFecModificacion", 150, True, "dd/MM/yyyy HH:mm")
            AgregarColumna(KryDataGrid_Usuarios, "Modificado.Por", "GtusUsrModificacion", "Modificado.Por ", 300, True, "")

        Catch ex As Exception

            KryptonMessageBox.Show("Error papu en La grilla", ex.Message)
            ' ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
        End Try

    End Function


    Private Sub KryDataGrid_Usuarios_Click(sender As Object, e As EventArgs) Handles KryDataGrid_Usuarios.Click
        'Efecto de Modificar --> 
        ' Verificamos que haya una celda activa

        KryBtnUpdateUser.Enabled = True
        KryBtnDeleteUser.Enabled = True


        Try
            If KryDataGrid_Usuarios.CurrentCell IsNot Nothing Then

                ' Buscar la columna por nombre
                Dim colIndex As Integer = KryDataGrid_Usuarios.Columns("Codigo").Index

                If colIndex = -1 Then
                    KryptonMessageBox.Show("Columna no encontrada")
                Else
                    ' Nos aseguramos que no sea cabecera
                    If KryDataGrid_Usuarios.CurrentRow.Index > -1 Then

                        Dim fila As Integer = KryDataGrid_Usuarios.CurrentRow.Index
                        Dim columna As Integer = KryDataGrid_Usuarios.CurrentCell.ColumnIndex

                        ' Obtenemos el valor
                        ENTID_Codigo = KryDataGrid_Usuarios.Rows(fila).Cells(colIndex).Value

                        'MessageBox.Show("Valor: " & ENTID_Codigo.ToString())
                    End If
                End If
            Else
                KryptonMessageBox.Show("No hay celda seleccionada")
            End If
        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function EventPressSearchForEntidCodigo(ByVal TipoUsuario As TipoBusqueda)

        Try
            If (KryTextBusqUsuario.Text <> " ") Then
                managerTRANGUIAS_Usuarios = New BTRANGUIAS_Usuarios
                BindingUsuarios = New BindingSource
                If (managerTRANGUIAS_Usuarios.TRAN_GUIAS_TRANSPORTISTA_BusqUsuarioXNumDocumento(KryTextBusqUsuario.Text, KryTextBusqUsuario.Text, TipoUsuario)) Then
                    BindingUsuarios.DataSource = managerTRANGUIAS_Usuarios.ListUsuariosApp
                    KryDataGrid_Usuarios.DataSource = BindingUsuarios

                End If
            End If
            Return True
        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message)
        End Try
    End Function


    Enum TipoBusqueda
        NumDocumento = 1
        RazonSocial = 2
    End Enum

    Private Sub KryTextBusqUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles KryTextBusqUsuario.KeyDown
        Dim X_NumeroDocumento As String = ""
        If (e.KeyCode = Keys.Enter) Then

            If (KryRbtDni.Checked) Then

                EventPressSearchForEntidCodigo(TipoBusqueda.NumDocumento)
            ElseIf (KryRbtRazSocial.Checked) Then
                EventPressSearchForEntidCodigo(TipoBusqueda.RazonSocial)
            End If
        End If
    End Sub

    Private Sub KryBtnCleanDni_Click(sender As Object, e As EventArgs) Handles KryBtnCleanDni.Click
        KryTxtDni.Clear()
    End Sub

    Private Sub KryBtnCleanName_Click(sender As Object, e As EventArgs) Handles KryBtnCleanName.Click
        KrytxtName.Clear()
    End Sub

    Private Sub KryBtnCleanPassword_Click(sender As Object, e As EventArgs) Handles KryBtnCleanPassword.Click
        KrytxtPassword.Clear()
    End Sub

    Private Sub KryBtnUpdateUser_Click(sender As Object, e As EventArgs) Handles KryBtnUpdateUser.Click
        _accionActual = AccionFormulario.Modificar
        Instancia(AccionFormulario.Modificar)
        IniciarProcesoModificacionUsuario()
    End Sub
    Private Function TRAN_GUIAS_BusqUsuarioIindividual(ByVal x_Dni As String)
        Try
            managerTRANGUIAS_Usuarios = New BTRANGUIAS_Usuarios()
            managerBTRANGuias_Entidades = New BTRANGUIAS_Entidades()
            mangerBEntidades = New BEntidades()


            Dim _join As New List(Of ACJoin)()
            _join.Add(New ACJoin(ETRANGUIAS_Usuarios.Esquema, ETRANGUIAS_Tipos.Tabla, "VTipos", ACJoin.TipoJoin.Inner _
                , New ACCampos() {New ACCampos("TiposGeneralFk", "TiposUsuariosFk")}))
            'Condicion para usuarios papuuuu
            Dim x_where As New Hashtable()
            x_where.Add("ENTID_CodigoFk", New ACWhere(x_Dni, ACWhere.TipoWhere.Igual))

            'Condiciones para entidades 
            Dim _x_where As New Hashtable()
            _x_where.Add("EntiDocumento", New ACWhere(x_Dni, ACWhere.TipoWhere.Igual))



            Dim x_where_entidad As New Hashtable()
            x_where_entidad.Add("ENTID_Codigo", New ACWhere(x_Dni, ACWhere.TipoWhere.Igual))


            If (mangerBEntidades.Cargar(x_where_entidad)) Then
            Else
            End If
            If (managerTRANGUIAS_Usuarios.Cargar(_join, x_where)) Then 'hacemos join papu

                If (managerBTRANGuias_Entidades.Cargar(_x_where)) Then
                    TRAN_GUIAS_RecibeParametrosEdicionUsuario(managerTRANGUIAS_Usuarios.ETRAN_GUIAS_Usuarios, managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades, mangerBEntidades.Entidades)

                End If


                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function TRAN_GUIAS_RecibeParametrosEdicionUsuario(ByVal X_DatosUsuario As ETRANGUIAS_Usuarios, ByVal x_DatosEntidadesUsuario As ETRANGUIAS_Entidades, x_datosEntidades As EEntidades)

        'Lleamos datos de l usuario 
        KryTxtDni.Text = x_DatosEntidadesUsuario.EntiDocumento

        KrytxtName.Text = x_DatosEntidadesUsuario.EntiRazonSocial
        KryChkActivo.Checked = X_DatosUsuario.GtusEstado



        KryTxtUser.Text = X_DatosUsuario.GtusUsuario

        KrytxtPassword.PasswordChar = X_DatosUsuario.GtusContraseña
        '    'Lllenamos la CARD 
        KryLabelCardName.Text = X_DatosUsuario.GtusUsuario
        KryLabelCardDate.Text = X_DatosUsuario.GtusFecCreacion
        KryLabelCardRazonSocial.Text = x_DatosEntidadesUsuario.EntiRazonSocial


        'Llenamos datos de entidades 


        KrytxtDireccion.Text = x_DatosEntidadesUsuario.EntiDireccion



    End Function

    Private Sub KryBtnVolver_Click(sender As Object, e As EventArgs) Handles KryBtnVolver.Click
        'Regresa al Anterior Formulario
        KryptonNavUsuarios.Pages("KrpPagUsuario").Visible = False
        KryptonNavUsuarios.Pages("KrptpagAdministradorUsuarios").Visible = True
        Instancia(AccionFormulario.Deshacer)
    End Sub

    Private Sub KryBtnNuevo_Click(sender As Object, e As EventArgs) Handles KryBtnNuevo.Click
        'Acciones.Nuevo
        _accionActual = AccionFormulario.Nuevo
        Instancia(_accionActual)
    End Sub

    Private Sub KryBtnGrabar_Click(sender As Object, e As EventArgs) Handles KryBtnGrabar.Click
        Try

            managerETRANGuias_Usuario = New ETRANGUIAS_Usuarios()
            managerBTRANGuias_Entidades = New BTRANGUIAS_Entidades()
            managerETRANGuias_Tipos = New ETRANGUIAS_Tipos()
            managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios = New ETRANGUIAS_Usuarios()
            managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades = New ETRANGUIAS_Entidades()

            managerEncryptation = New EncryptationHash()
            'Comprobamos si el Usuario existe ya en la bd para el aplicativo 

            Dim where As New Hashtable()

            where.Add("EntiDocumento", New ACWhere((Trim(KryTxtDni.Text)), ACWhere.TipoWhere.Igual))
            If managerBTRANGuias_Entidades.Cargar(where) Then 'Comprobacion de repiticion de usuarios 

                'KryptonMessageBox.Show("Este Usuario ya Existe ")
                MostrarNotificacionErrorRepetidos()


            Else

                '1 Entidades 
                Dim tipoSelTipoDoc As ETRANGUIAS_Tipos = DirectCast(KryCmbTipoEntidad.SelectedItem, ETRANGUIAS_Tipos)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiDocumento = Trim(KryTxtDni.Text)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.TipoDocumentoFk = tipoSelTipoDoc.TipoId



                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiRazonSocial = Trim(KryTxtRazonSocial.Text)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiDireccion = (KrytxtDireccion.Text)

                'managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiEstado = 1 'Trim(KryTxtDni.Text)

                '2 Usuarios 
                Dim tipoSel As ETRANGUIAS_Tipos = DirectCast(KryCmbTypeUser.SelectedItem, ETRANGUIAS_Tipos)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.TiposUsuariosFk = tipoSel.TipoId
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.ENTID_CodigoFk = Trim(KryTxtDni.Text)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusUsuario = KryTxtUser.Text
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusContraseña = KrytxtPassword.Text


                Select Case KryChkActivo.Checked
                    Case True
                        managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiEstado = 1

                        managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusEstado = 1


                    Case False
                        managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusEstado = 0
                        managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiEstado = 0
                End Select


                'Encryptacion de usuarios  
                Dim salt As Byte() = managerEncryptation.GenerarSalt

                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusSalt = Convert.ToBase64String(salt)

                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusHash = managerEncryptation.HashPassword(Trim(KrytxtPassword.Text), salt)  '


                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusContraseña  = Trim(KrytxtPassword.Text)

                'prueba de Desencriptacion de Hash '


                'If (managerEncryptation.VerificarPassword(Trim(KrytxtPassword.Text), salt, managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusHash)) Then

                '    Debug.WriteLine("EXISTO")
                'End If



                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.Instanciar(ACEInstancia.Nuevo)
                    managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.Instanciar(ACEInstancia.Nuevo)

                    If managerBTRANGuias_Entidades.Guardar(GApp.Usuario) Then 'en esta fucion hace ambos insert 
                        'Tanto en Entidades como en Usuariso 
                        'Mensaje de confirmascion 
                        'Para que usuario quiera seguir grabando mas 
                        Dim Respuesta As DialogResult = KryptonMessageBox.Show("Se Grabo El usuario " + KryTxtUser.Text + "¿Quieres Grabar Otro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        MostrarNotificacionConfirmacion()
                        NotifyAlert.Visible = False

                        If (Respuesta = DialogResult.Yes) Then
                            _accionActual = AccionFormulario.GrabarOtro

                            Instancia(AccionFormulario.GrabarOtro)

                        ElseIf (Respuesta = DialogResult.No) Then
                            _accionActual = AccionFormulario.Guardar
                            Instancia(AccionFormulario.Guardar)


                        End If

                    Else
                        KryptonMessageBox.Show("Algo paso papu !! ")
                    End If


                End If




        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub KryRbtnNatural_Click(sender As Object, e As EventArgs) Handles KryRbtnNatural.Click
        If (KryRbtnNatural.Checked = True) Then
            KryRbtnJuridica.Checked = False
        ElseIf (KryRbtnJuridica.Checked = True) Then
            KryRbtnNatural.Checked = False

        End If

    End Sub

    Private Sub KryRbtnJuridica_Click(sender As Object, e As EventArgs) Handles KryRbtnJuridica.Click
        If (KryRbtnNatural.Checked = True) Then
            KryRbtnNatural.Checked = False
        ElseIf (KryRbtnJuridica.Checked = True) Then
            KryRbtnNatural.Checked = False

        End If

    End Sub

    Private Sub KryBtnDelete_Click(sender As Object, e As EventArgs) Handles KryBtnDelete.Click
        limpiarFormulario()
    End Sub

    Private Sub KryBtnUpdate_Click(sender As Object, e As EventArgs) Handles KryBtnUpdate.Click
        'modificacion de usuarios entidad 
        Try

            managerETRANGuias_Usuario = New ETRANGUIAS_Usuarios()
            managerBTRANGuias_Entidades = New BTRANGUIAS_Entidades()
            managerETRANGuias_Tipos = New ETRANGUIAS_Tipos()
            'managerTRANGUIAS_Usuarios = New BTRANGUIAS_Usuarios()
            managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios = New ETRANGUIAS_Usuarios()
            managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades = New ETRANGUIAS_Entidades()
            managerEncryptation = New EncryptationHash()



            If (managerBTRANGuias_Entidades.CargarEntidad(X_Dni, True)) Then 'hacemos  papu

                managerEncryptation = New EncryptationHash()

                '1 Entidades 
                Dim tipoSelTipoDoc As ETRANGUIAS_Tipos = DirectCast(KryCmbTipoEntidad.SelectedItem, ETRANGUIAS_Tipos)
                'managerTRANGUIAS_Usuarios.ETRAN_GUIAS_Usuarios.GtusId = managerTRANGUIAS_Usuarios.getCorrelativo()
                'managerETRANGuias_Usuario.TiposUsuariosFk = KryCmbTypeUser.SelectedItem


                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiDocumento = Trim(KryTxtDni.Text)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.TipoDocumentoFk = tipoSelTipoDoc.TipoId

                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiDocumento = Trim(KryTxtDni.Text)

                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiRazonSocial = Trim(KryTxtRazonSocial.Text)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiDireccion = (KrytxtDireccion.Text)

                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiEstado = Trim(KryTxtDni.Text)

                '2 Usuarios 
                Dim tipoSel As ETRANGUIAS_Tipos = DirectCast(KryCmbTypeUser.SelectedItem, ETRANGUIAS_Tipos)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.TiposUsuariosFk = tipoSel.TipoId
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.ENTID_CodigoFk = Trim(KryTxtDni.Text)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusUsuario = KryTxtUser.Text
                'Validacion de estados 
                Select Case KryChkActivo.Checked
                    Case True
                        managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiEstado = 1

                        managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusEstado = 1


                    Case False
                        managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusEstado = 0
                        managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.EntiEstado = 0
                End Select


                'Encryptacion de usuarios  
                Dim salt As Byte() = managerEncryptation.GenerarSalt

                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusSalt = Convert.ToBase64String(salt)

                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.GtusHash = managerEncryptation.HashPassword(Trim(KrytxtPassword.Text), salt)  '


                'managerTRANGUIAS_Usuarios.ETRAN_GUIAS_Usuarios.GtusContrasena = managerEncryptation.VerificarPassword()
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades.Instanciar(ACEInstancia.Modificado)
                managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios.Instanciar(ACEInstancia.Modificado)

                If managerBTRANGuias_Entidades.Guardar(GApp.Usuario) Then 'en esta fucion hace ambos insert 
                    'Tanto en Entidades como en Usuariso 
                    'Mensaje de confirmascion 
                    'Para que usuario quiera seguir grabando mas 
                    'Dim Respuesta As DialogResult = KryptonMessageBox.Show("Se Grabo El usuario " + KryTxtUser.Text + "¿Quieres Grabar Otro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    MostrarNotificacionUpdate()
                    NotifyAlert.Visible = False
                    Instancia(AccionFormulario.Guardar)
                    'If (Respuesta = DialogResult.Yes) Then
                    '    _accionActual = AccionFormulario.GrabarOtro

                    '    Instancia(AccionFormulario.GrabarOtro)

                    'ElseIf (Respuesta = DialogResult.No) Then
                    '    _accionActual = AccionFormulario.Guardar
                    '    


                    'End If

                Else
                    KryptonMessageBox.Show("Algo paso papu !! al momento de grabar  ")
                End If


            End If
        Catch ex As Exception
            KryptonMessageBox.Show("Hay un ERROR papu" + ex.Message)
        End Try


    End Sub

    Private Sub KryBtnDeleteUser_Click(sender As Object, e As EventArgs) Handles KryBtnDeleteUser.Click
        Try
            managerTRANGUIAS_Usuarios = New BTRANGUIAS_Usuarios
            managerBTRANGuias_Entidades = New BTRANGUIAS_Entidades
            managerETRANGuias_Entidades = New ETRANGUIAS_Entidades
            managerBTRANGuias_Entidades.ETRAN_GUIAS_Usuarios = New ETRANGUIAS_Usuarios
            managerBTRANGuias_Entidades.ETRAN_GUIAS_Entidades = New ETRANGUIAS_Entidades
            managerTRANGUIAS_Usuarios = New BTRANGUIAS_Usuarios()
            managerBTRANGuias_Entidades = New BTRANGUIAS_Entidades
            'dECLARACION DE VARIABLES PARA ESCRIPCION
            managerEncryptation = New EncryptationHash

            If (managerBTRANGuias_Entidades.CargarEntidadXEliminacion(ENTID_Codigo, True)) Then
                'If managerBConductores.Cargar(ENTID_Codigo) Then
                KryptonMessageBox.Show("El Usuario Ya esta Ligado a Conductores Elimine el Usuario e Intentelo de Nuevo " + X_Dni)
                'Else

            Else
                'End If
                'Mensajer de Pregunta ==============================================
                Dim Respuesta As DialogResult = KryptonMessageBox.Show("Quieres Eliminar el Usuario " + X_Dni, "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If (Respuesta = DialogResult.Yes) Then

                    'If managerBTRANGuias_Entidades.ComprobarExistsConductor(ENTID_Codigo) Then 'buscar si encuentra ---> retorna y no elimina
                    '    Return 
                    'End If

                        If managerBTRANGuias_Entidades.Eliminar(ENTID_Codigo) Then
                        KryptonMessageBox.Show("Se Elimino el Usuario " + X_Dni)

                        Instancia(AccionFormulario.Eliminar)
                        MostrarNotificacionEliminado()
                        NotifyAlert.Visible = False
                    Else
                        KryptonMessageBox.Show("No se pudo Eliminar el Usuario " + X_Dni)
                    End If

                Else





                End If

            End If

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub KryCmbTypeUser_Click(sender As Object, e As EventArgs) Handles KryCmbTypeUser.Click
        'Cuando se haga un click entonces se vaa cargar de nuevo todas las listas 


        Colecciones.Cargar_TRANGUIAS_Tipos()
        ManagerGUIASTipos = New BTRANGUIAS_Tipos()
        ManagerGUIASTipos.CargarTodos()
        ACUtilitarios.ACCargaCombo(KryCmbTypeUser, Colecciones.FiltrarTipos_RolENTIDADES(ManagerGUIASTipos.ListTipos), "TipoDescripcion", "TipoAbreviatura")

    End Sub

    Private Sub KryCmbTipoEntidad_Click(sender As Object, e As EventArgs) Handles KryCmbTipoEntidad.Click
        'Cuando se haga un click entonces se vaa car gar denuevo todas las listas del comobobx 

        Colecciones.Cargar_TRANGUIAS_Tipos()
        ManagerGUIASTipos = New BTRANGUIAS_Tipos()
        ManagerGUIASTipos.CargarTodos()
        ACUtilitarios.ACCargaCombo(KryCmbTipoEntidad, Colecciones.FiltrarTipos_ENTIDADES(ManagerGUIASTipos.ListTipos), "TipoDescripcion", "TipoAbreviatura")


    End Sub


    Private Sub KryTxtDni_KeyDown(sender As Object, e As KeyEventArgs) Handles KryTxtDni.KeyDown
        Try
            'comprobamos si el usuario ya existe 
            managerEntidades = New BEntidades
            managerEEntidades = New EEntidades
            Dim X_WHERE As New Hashtable()

            X_WHERE.Add("ENTID_Codigo", New ACWhere(Trim(KryTxtDni.Text), ACWhere.TipoWhere.Igual))
            If e.KeyCode = Keys.Enter Then
                If (managerEntidades.Cargar(X_WHERE)) Then
                    LLenadoDeInformacionAutomatico(managerEntidades.Entidades)
                    GenerarCodigoBarra()
                Else
                    MostrarMensajePersonalizado("El Usuario No existe")
                End If
            Else


            End If
        Catch ex As Exception
            KryptonMessageBox.Show("Error:" + ex.Message)
        End Try



    End Sub

    Private Function LLenadoDeInformacionAutomatico(ByVal VariablesUsuario As EEntidades)

        '1 Entidades 


        KrytxtName.Text = VariablesUsuario.ENTID_RazonSocial
        KryTxtDni.Text = VariablesUsuario.ENTID_Codigo
        KryTxtRazonSocial.Text = VariablesUsuario.ENTID_RazonSocial
        KrytxtDireccion.Text = VariablesUsuario.ENTID_Direccion
        KryTxtUser.Text = VariablesUsuario.ENTID_CodUsuario
        'Usuarios card 
        KryLabelCardName.Text = VariablesUsuario.ENTID_CodUsuario
        KryLabelCardRazonSocial.Text = VariablesUsuario.ENTID_RazonSocial
        KryLabelCardTypeUser.Text = ""
        KryLabelCardDate.Text = VariablesUsuario.ENTID_FecCrea
        KryTxtUsuario.Text = VariablesUsuario.ENTID_Nombres

        Return True
    End Function


    Private Sub KryTxtDni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles KryTxtDni.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub KryBtnCleanDireccion_Click(sender As Object, e As EventArgs) Handles KryBtnCleanDireccion.Click
        KrytxtDireccion.Clear()
    End Sub

    Private Sub KryBtnCleanRazonSocial_Click(sender As Object, e As EventArgs) Handles KryBtnCleanRazonSocial.Click
        KryTxtRazonSocial.Clear()
    End Sub

    Private Sub KryBtnCleanUsuario_Click(sender As Object, e As EventArgs) Handles KryBtnCleanUsuario.Click
        KryTxtUser.Clear()
    End Sub

    Private Sub KryptonGroupBox7_Resize(sender As Object, e As EventArgs) Handles KryptonGroupBox7.Resize

        CentrarGroupBox()

    End Sub



    'Funciones para Codigo de Barras =========================>By frnak 

    Private Sub GenerarCodigoBarra()
        Try
            Dim writer As New BarcodeWriter()
            writer.Format = BarcodeFormat.CODE_128 ' Tipo de código de barras
            writer.Options = New ZXing.Common.EncodingOptions With {
            .Width = 300,
            .Height = 100,
            .Margin = 2
        }
            Dim resultado As String = If(String.IsNullOrEmpty(ENTID_Codigo), Trim(KryTxtDni.Text), ENTID_Codigo)

            Dim img As Bitmap = writer.Write(Trim(resultado))
            PictureBoxBarraUsuario.Image = img  ' Mostrar en KryptonPictureBox
        Catch ex As Exception
            KryptonMessageBox.Show("Error en Proceso de Generacionacion de Codigo Barras   ", ex.Message)
        End Try
    End Sub

    Private Sub KryButtonLimpiaTxt_Click(sender As Object, e As EventArgs) Handles KryButtonLimpiaTxt.Click
        KryTextBusqUsuario.Clear()
    End Sub


    'Eventos ToolStrip 
    Private Sub KryTextBusqUsuario_MouseHover(sender As Object, e As EventArgs) Handles KryTextBusqUsuario.MouseHover
        ToolTipMensajeBusquedaDni.Show("Dale Enter Papu!!", KryTextBusqUsuario)
    End Sub

    Private Sub KryTextBusqUsuario_MouseLeave(sender As Object, e As EventArgs) Handles KryTextBusqUsuario.MouseLeave
        ToolTipMensajeBusquedaDni.Hide(KryTextBusqUsuario)
    End Sub

    Private Sub KryTxtDni_MouseHover(sender As Object, e As EventArgs) Handles KryTxtDni.MouseHover
        ToolTipMensajeDniUsuario.Show("Dale Enter Papu!!", KryTxtDni)
    End Sub

    Private Sub KryTxtDni_MouseLeave(sender As Object, e As EventArgs) Handles KryTxtDni.MouseLeave
        ToolTipMensajeDniUsuario.Hide(KryTxtDni)
    End Sub

    'Funcion Busqueda por activos o Inactivos 
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        managerTRANGUIAS_Usuarios = New BTRANGUIAS_Usuarios
        BindingUsuarios = New BindingSource
        If (managerTRANGUIAS_Usuarios.TRAN_GUIAS_TRANSPORTISTA_BusqUsuariosActivosInactivos(KryChkViewAll.Checked)) Then
            BindingUsuarios.DataSource = managerTRANGUIAS_Usuarios.ListUsuariosApp
            KryDataGrid_Usuarios.DataSource = BindingUsuarios
        End If
        'managerTRANGUIAS_Usuarios.TRAN_GUIAS_TRANSPORTISTA_BusqUsuariosActivosInactivos()
    End Sub
End Class

'si solo quieres un keypress para numeros papu usa esto .... de nada by frank 

'Private Sub KryptonTextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles KryptonTextBox2.KeyPress
'    ' Permitir letras, espacio y la tecla Backspace
'    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
'        e.Handled = True
'    End If
'End Sub
'si solo queres un decimales papu esto 

'Private Sub KryptonTextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles KryptonTextBox3.KeyPress
'    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
'        e.Handled = True
'    End If

'    ' Solo permitir un punto decimal
'    If e.KeyChar = "."c AndAlso DirectCast(sender, KryptonTextBox).Text.Contains(".") Then
'        e.Handled = True
'    End If
'End Sub






'31 MAYO