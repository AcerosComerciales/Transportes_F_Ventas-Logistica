Imports ACBTransporte
Imports ACETransporte
Imports C1.Win.C1FlexGrid
Imports ACFramework
Imports ACBVentas

Public Class RMantenimiento
#Region " Variables "
    Private managerTRAN_Vehiculos As BTRAN_Vehiculos
    Private managerInventarios As BAdministracionInventarios

    Private bs_btran_vehiculos As BindingSource
    Private bs_inventario As BindingSource



    Private managerTRAN_VehiculosMantenimiento As BTRAN_VehiculosMantenimiento
    Private managerTRAN_VehiculosMantenimientoDetalle As BTRAN_VehiculosMantenimientoDetalle 'Creado frank para Detalles 
    Private managerETRAN_VehiculosMantenimientoDetalle As ETRAN_VehiculosMantenimientoDetalle
    Private managerETRAN_EVehiculosMantenimiento As ETRAN_VehiculosMantenimiento

    Private managerTRAN_VehiculosMatenimientoDocCompra As BTRAN_VehiculosMantenimientoDocCompra 'Compra amarrado a VehiculoMantenimiento
    Private managerETRAN_VehiculosMatenimientoDocCompra As BTRAN_VehiculosMantenimientoDocCompra
    Private managerEntidades As BEntidades

    Private m_listBindHelper As List(Of ACBindHelper)
    Private m_listBindHelper2 As List(Of ACBindHelper)
    ' Private bs_btran_vehiculos As BindingSource
    Private bs_btran_mantenimiento_vehiculos As BindingSource
    Private bs_btran_mantenimiento_vehiculos_Detalles As BindingSource
    Private bs_btran_documentos_detalle As BindingSource
    Private bs_piezas As BindingSource
    Private bs_facturas As BindingSource

    '
    Private x_eliminar As Boolean = False
    Private lockedTab As TabPage 'Variable para Bloquear un tab frank
#End Region

#Region " Propiedades "

#End Region
    Enum Busqueda_Report_Mantenimiento 'create by frank
        Codigo = 0
        Placa = 1
        Usuario = 2

    End Enum
#Region " Constructores "
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            managerTRAN_Vehiculos = New BTRAN_Vehiculos
            managerInventarios = New BAdministracionInventarios
            tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda



            'EventosCalendar() 'Evento para manejar los checkets by frank 


            formatearGrilla()
            'Inicializando pantalla de Carga 
            ProgressReportMantenimiento.Minimum = 0

            acTool.ACBtnSalirVisible = True
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
        End Try
    End Sub
#End Region

#Region " Metodos "
    Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
        Select Case _opcion
            Case ACUtilitarios.ACSetInstancia.Nuevo
                tabMantenimiento.SelectedTab = tabDatos
                actsbtnPrevisualizar.Visible = False
            Case ACUtilitarios.ACSetInstancia.Deshacer
                tabMantenimiento.SelectedTab = tabBusqueda
                actsbtnPrevisualizar.Visible = True
            Case ACUtilitarios.ACSetInstancia.Guardar
            Case ACUtilitarios.ACSetInstancia.Modificado
            Case ACUtilitarios.ACSetInstancia.Previsualizar
        End Select
        acTool.ACBtnModificarVisible = False
        acTool.ACBtnImprimirVisible = False
    End Sub
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

    Private Sub formatearGrilla()
        Dim index As Integer = 1
        Try
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 17, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "VEHIC_Id", "VEHIC_Id", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "VMAN_ITEM", "VMAN_Item", "VMAN_Item", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "VMDET_ITEM", "VMDET_Item", "VMDET_Item", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Descripcion Mant.", "VMDET_Procedimiento", "VMDET_Procedimiento", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Piz Marca", "PIEZA_Marca", "PIEZA_Marca", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Responsable", "VMDET_Responsable", "VMDET_Responsable", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cantidad", "VMDET_Cantidad", "VMDET_Cantidad", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Ruc", "ENTID_Codigo", "ENTID_Codigo", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Raz.Social", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "N° Factura", "DOCUS_Codigo", "DOCUS_Codigo", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Detalles", "VMAN_Observaciones", "VMAN_Observaciones", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Precio", "DCDET_Precio", "DCDET_Precio", 150, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Descuento", "DCDET_Descuento", "DCDET_Descuento", 150, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Costo", "DCDET_Precio", "DCDET_Precio", 150, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec.Creacion", "VMDET_FecCrea", "VMDET_FecCrea", 150, True, False, "System.DateTime", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

            'ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Conductor", "Conductor", "Conductor", 150, True, False, "System.String", "") : index += 1
            c1grdBusqueda.AllowEditing = False
            c1grdBusqueda.AutoResize = True
            c1grdBusqueda.AllowResizing = True
            c1grdBusqueda.Cols(0).Width = 15
            c1grdBusqueda.ExtendLastCol = False
            c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn

            c1grdBusqueda.Styles.Alternate.BackColor = Color.LightGray
            c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
            c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
            c1grdBusqueda.AllowResizing = AllowResizingEnum.None

            '============================nuevos estilos frank=============================================================================================
            c1grdBusqueda.AllowEditing = False
            c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
            c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
            c1grdBusqueda.AutoResize = False
            c1grdBusqueda.AllowResizing = AllowResizingEnum.Both
            c1grdBusqueda.Cols("VEHIC_Placa").StyleDisplay.WordWrap = True
            c1grdBusqueda.Tree.Column = 1
            c1grdBusqueda.SubtotalPosition = SubtotalPositionEnum.AboveData


            Dim s As CellStyle = c1grdBusqueda.Styles(CellStyleEnum.Subtotal0)
            s.BackColor = Color.Black
            s.ForeColor = Color.White
            s.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)

            s = c1grdBusqueda.Styles(CellStyleEnum.Subtotal1)
            s.BackColor = Color.DarkBlue
            s.ForeColor = Color.White
            s = c1grdBusqueda.Styles(CellStyleEnum.Subtotal2)
            s.BackColor = Color.DarkRed
            s.ForeColor = Color.White


            '/*******************************************************************************************************************

            '/*****************************************************************************************************************/
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 5, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Existe", "VEHID_Existe", "VEHID_Existe", 150, True, True, "System.Boolean") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Codigo", "TIPOS_CodObjeto", "TIPOS_CodObjeto", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Categoria", "TIPOS_Categoria", "TIPOS_Categoria", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Desc. Objeto", "TIPOS_Objeto", "TIPOS_Objeto", 150, True, False, "System.String") : index += 1

            c1grdDetalle.AllowEditing = True
            c1grdDetalle.AutoResize = True
            c1grdDetalle.AllowResizing = True
            c1grdDetalle.Cols(0).Width = 15
            c1grdDetalle.ExtendLastCol = False
            c1grdDetalle.AllowSorting = AllowSortingEnum.SingleColumn

            c1grdDetalle.Styles.Alternate.BackColor = Color.LightGray
            c1grdDetalle.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdDetalle.Styles.Highlight.BackColor = Color.Gray
            c1grdDetalle.SelectionMode = SelectionModeEnum.Row
            c1grdDetalle.AllowResizing = AllowResizingEnum.None
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub

    Private Function busquedaXDescripcion(ByVal x_cadena As String) As Boolean
        Try
            'CUANDO EL BUSQUEDA TRAIGA LSO DATOS RECIEN LLAMAMOS AL PROCEDIMIENTO 
            'DE HAY LLENAMOS LA TABLA 
            bs_btran_vehiculos = New BindingSource()
            bs_btran_mantenimiento_vehiculos_Detalles = New BindingSource()
            bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos
            '   Dim x_vehic_id As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
            managerTRAN_VehiculosMantenimiento = New BTRAN_VehiculosMantenimiento()
            managerTRAN_VehiculosMantenimientoDetalle = New BTRAN_VehiculosMantenimientoDetalle()

            If managerTRAN_VehiculosMantenimiento.TRAN_REPOSS_VehiculoMantenimientos(getCampo(), x_cadena, AcFecha.ACDtpFecha_De.Value, AcFecha.ACDtpFecha_A.Value) Then
                acTool.ACBtnEliminarEnabled = True
                acTool.ACBtnModificarEnabled = True
            Else
                acTool.ACBtnEliminarEnabled = False
                acTool.ACBtnModificarEnabled = False
            End If
            ' managerTRAN_VehiculosMantenimiento.TRAN_REPOSS_VehiculoMantenimientos(AcFecha.ACFecha_De.Value, AcFecha.ACFecha_A.Value)

            cargarDatos()
            Return acTool.ACBtnModificarEnabled
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los datos para los Mantenimientos", ex)
        End Try
        Return False
    End Function

    Private Function getCampo() As Short
        Try
            If (rbtnDescripcion.Checked) Then
                Return 2
            ElseIf rbtnPlaca.Checked Then
                Return 1
            ElseIf rbtnProveedor.Checked Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function EventosCalendar()
        'evento Fechas by frank 
        If AcFecha.ACFechaChecked = False Then
            rbtnPlaca.Checked = True
        ElseIf AcFecha.ACFechaChecked = True Then
            rbtnPlaca.Checked = False
            rbtnDescripcion.Checked = False
        End If

    End Function

    Private Sub cargarDatos()
        Try
            'Aqui llamamos al procedimiento Almacenado 
            bs_btran_vehiculos = New BindingSource()
            bs_btran_mantenimiento_vehiculos_Detalles = New BindingSource()
            bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos
            ' Dim x_vehic_id As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
            'managerTRAN_VehiculosMantenimiento = New BTRAN_VehiculosMantenimiento()
            'managerTRAN_VehiculosMantenimientoDetalle = New BTRAN_VehiculosMantenimientoDetalle()
            'managerTRAN_VehiculosMantenimiento.TRAN_REPOSS_VehiculoMantenimientos(AcFecha.ACFecha_De.Value, AcFecha.ACFecha_A.Value)
            For index As Integer = 1 To 99
                ProgressReportMantenimiento.Value = index + 1
            Next

            bs_btran_mantenimiento_vehiculos_Detalles.DataSource = managerTRAN_VehiculosMantenimiento.getTRAN_VehiculosMantenimientoDetalle()

            c1grdBusqueda.DataSource = bs_btran_mantenimiento_vehiculos_Detalles


            c1grdBusqueda.Subtotal(AggregateEnum.Sum, 2, 2, 13, "SubTotal:{0}") 'Mostrar la suma de toda la factura by frank
            c1grdBusqueda.Subtotal(AggregateEnum.None, 1, 2, 0, "Vehiculo: {0}") 'agrupar por vehiculos
            c1grdBusqueda.Subtotal(AggregateEnum.None, 1, 3, 0, "Items:{0}")
            c1grdBusqueda.Subtotal(AggregateEnum.Sum, 2, 2, 3, "{0}") 'suma de item para separarlos 

            c1grdBusqueda.AutoSizeCols(1)
            ' c1grdBusqueda.DataSource = bs_btran_vehiculos
            'bnavBusqueda.BindingSource = bs_btran_vehiculos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region " Metodos de Controles"

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

    Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
        Try
            If rbtnPlaca.Checked Then
                BusquedaXPlaca(txtBusqueda.Text)
            ElseIf rbtnDescripcion.Checked Then
                busquedaXDescripcion(txtBusqueda.Text)
            ElseIf rbtnProveedor.Checked Then
                BusquedaXProveedor(txtBusqueda.Text)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
        End Try
    End Sub

    'Private Sub c1grdLista_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles c1grdDetalle.MouseClick
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        If c1grdDetalle.Rows.Count > 0 Then
    '            CMSSeleccionar.ACMostrar(c1grdDetalle, Windows.Forms.Cursor.Position, "VEHID_Existe")
    '        End If
    '    End If
    'End Sub
#End Region

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        txtBusqueda_ACAyudaClick(sender, e)
    End Sub


    Private Function BusquedaXProveedor(ByVal x_placa As String) As Boolean
        Try
            Dim m_return As Boolean
            'If txtBusqueda.ACEstadoAutoAyuda Then
            bs_btran_vehiculos = New BindingSource()
            bs_btran_mantenimiento_vehiculos_Detalles = New BindingSource()
            bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos
            '   Dim x_vehic_id As Integer =     CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
            managerTRAN_VehiculosMantenimiento = New BTRAN_VehiculosMantenimiento()
            managerTRAN_VehiculosMantenimientoDetalle = New BTRAN_VehiculosMantenimientoDetalle()



            If managerTRAN_VehiculosMantenimiento.TRAN_REPOSS_VehiculoMantenimientos(getCampo(), x_placa, AcFecha.ACDtpFecha_De.Value, AcFecha.ACDtpFecha_A.Value) Then
                acTool.ACBtnEliminarEnabled = True
                acTool.ACBtnModificarEnabled = True
            Else
                acTool.ACBtnEliminarEnabled = False
                acTool.ACBtnModificarEnabled = False
            End If
            cargarDatos()
            'End If
            Return m_return
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
        End Try
        Return False

    End Function
    Private Function BusquedaXPlaca(ByVal x_placa As String) As Boolean
        Try
            Dim m_return As Boolean
            'If txtBusqueda.ACEstadoAutoAyuda Then
            bs_btran_vehiculos = New BindingSource()
            bs_btran_mantenimiento_vehiculos_Detalles = New BindingSource()
            bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos
            '   Dim x_vehic_id As Integer =     CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
            managerTRAN_VehiculosMantenimiento = New BTRAN_VehiculosMantenimiento()
            managerTRAN_VehiculosMantenimientoDetalle = New BTRAN_VehiculosMantenimientoDetalle()



            If managerTRAN_VehiculosMantenimiento.TRAN_REPOSS_VehiculoMantenimientos(getCampo(), x_placa, AcFecha.ACDtpFecha_De.Value, AcFecha.ACDtpFecha_A.Value) Then
                acTool.ACBtnEliminarEnabled = True
                acTool.ACBtnModificarEnabled = True
            Else
                acTool.ACBtnEliminarEnabled = False
                acTool.ACBtnModificarEnabled = False
            End If
            cargarDatos()
            'End If
            Return m_return
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
        End Try
        Return False

    End Function
    Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click
        Try
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
            Me.KeyPreview = False
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cancelar Operación"), ex)
        End Try
    End Sub

    Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
        Try
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Grabar Registro: {0}", Me.Text) _
                                        , "Desea grabar el Inventario Actual: " _
                                        , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                c1grdDetalle.FinishEditing()


                managerInventarios.TRAN_VehiculosInventario.VEHIN_Estado = Constantes.getEstado(Constantes.EstadoDocVta.Ingresado)
                If managerInventarios.GrabarInventario(GApp.Usuario) Then
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("01000"))) '
                End If
                setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
            End If

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Grabar Registro"), ex)
        End Try
    End Sub

    ' <summary>
    ' Realiza el enlace de los controles visuales con la clase esquema
    ' </summary>
    Private Sub AsignarBinding()
        Try
            'Comentado pero se si va 
            'm_listBindHelper = New List(Of ACBindHelper)()
            'm_listBindHelper2 = New List(Of ACBindHelper)()
            'm_listBindHelper.Add(ACBindHelper.ACBind(cmbManTipoMantenimiento, "SelectedValue", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "TIPOS_CodTipoMantenimiento"))
            'If managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.VMAN_FecRealizacion.Year < 1700 Then managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.VMAN_FecRealizacion = DateTime.Now
            'm_listBindHelper.Add(ACBindHelper.ACBind(dtpFecMantenimiento, "Value", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "VMAN_FecRealizacion"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(txtManObservacion, "Text", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "VMAN_Observaciones"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(actxnManKilometraje, "Text", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "VMAN_Km"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(actxaNroDocProveedor, "Text", managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento, "ENTID_Codigo"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cargar()
        Try
            If bs_btran_vehiculos.Current IsNot Nothing Then
                Dim x_codigo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_VehiculosMantenimiento).VMAN_Id
                If managerTRAN_VehiculosMantenimiento.Cargar(x_codigo) Then
                    AsignarBinding()
                    managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.Instanciar(ACEInstancia.Modificado)
                    'actxaDescProveedor.Text = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ENTID_Proveedor
                    'txtVehicPlaca.Text = CType(bs_btran_vehiculos.Current, ETRAN_VehiculosMantenimiento).VEHIC_Placa
                    'txtVehiDescripcion.Text = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.VEHIC_Modelo

                    'actxaNomResponsable.Text = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ENTID_Responsable
                    tabMantenimiento.SelectedTab = tabDatos

                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)

                    bs_piezas = New BindingSource
                    bs_piezas.DataSource = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimientoDetalle
                    'c1grdDetalle_piezas.DataSource = bs_piezas 'Piezas normales comentado por frank
                    'bnavDetalle.BindingSource = bs_piezas '

                    bs_facturas = New BindingSource
                    bs_facturas.DataSource = managerTRAN_VehiculosMantenimiento.TRAN_VehiculosMantenimiento.ListTRAN_Documentos

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
    Private Sub acTool_ACBtnModificar_Click(sender As Object, e As EventArgs) Handles acTool.ACBtnModificar_Click
        'Nuevo modificar FRA
        Try
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
            cargar()
            'AQUI UN PROCEDIIENTO ALMACENADO PARA QUE BOTE LOS DATOS 
            '===========================================================

            setInstanciaPermisos(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
            tabMantenimiento.SelectedTab = tabDatos
            'Inicializamos el Tab de Mantenimeintso y Bloqueamos para que no se pueda entrar 
            tabMantenimiento.SelectedTab = tabBusqueda
            'lockedTab = tabMantenimiento.TabPages(1)
            'AddHandler tabMantenimiento.SelectedIndex(0), AddressOf tabMantenimiento_Selecting

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar Mantenimiento de Vehiculo", ex)
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
        End Try
    End Sub
    'Private Sub tabMantenimiento_Selecting(sender As Object, e As TabControlCancelEventArgs)
    '    ' Si el TabPage que se intenta seleccionar es el bloqueado, cancela la selección
    '    If e.TabPage Is lockedTab Then
    '        e.Cancel = True
    '        ' ACControles.ACDialogos.ACMostrarMensajeInformacion("Espera..", "La Ventana se Encuentra Bloqueada  :)")
    '        MessageBox.Show("Esta pestaña está bloqueada.")
    '    End If
    'End Sub

    Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnNuevo_Click
        Try
            If Not IsNothing(bs_btran_vehiculos) Then
                If Not IsNothing(bs_btran_vehiculos.Current) Then
                    '' Codigo
                    'RemoveHandler txtAccObservacion.LostFocus, AddressOf txtAccObservacion_LostFocus
                    setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)
                    Me.KeyPreview = True
                    managerInventarios.TRAN_VehiculosInventario = New ETRAN_VehiculosInventario
                    managerInventarios.TRAN_VehiculosInventario.Instanciar(ACEInstancia.Nuevo)
                    'txtPlaca.Text = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Placa
                    'txtCodigo.Text = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id.ToString("00000")
                    managerInventarios.TRAN_VehiculosInventario.VEHIC_Id = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
                    bs_inventario = New BindingSource
                    If managerInventarios.GetObjetosInventario(CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id) Then
                        bs_inventario.DataSource = managerInventarios.ListETRAN_VehiculosInventarioDetalle
                    End If
                    c1grdDetalle.DataSource = bs_inventario
                    bnavProductos.BindingSource = bs_inventario
                Else
                    Throw New Exception("No se puede cargar el documento")
                End If
            Else
                Throw New Exception("No se puede cargar el documento")
            End If


        Catch ex As Exception
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Nuevo Registro"), ex)
        End Try
    End Sub



    Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub

    Private Sub tsbtnAddFletes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim _codigos As String = ""
            Dim i As Integer = 0
            For Each item As ETRAN_VehiculosInventarioDetalle In managerInventarios.TRAN_VehiculosInventario.ListTRAN_VehiculosInventarioDetalle
                If i = 0 Then
                    _codigos &= "'" + item.TIPOS_CodObjeto + "'"
                Else
                    _codigos &= ",'" + item.TIPOS_CodObjeto + "'"
                End If
                i += 1
            Next

            managerInventarios.GetInventarios(_codigos)
            'Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerEntidades.DTEntidades, False)


        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Agregar Accesorio"), ex)
        End Try
    End Sub

    Private Sub tsbtnQuitarFletes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Quitar Accesorio"), ex)
        End Try
    End Sub




    Private Sub c1grdBusqueda_DoubleClick(sender As Object, e As MouseEventArgs) Handles c1grdBusqueda.DoubleClick
        'Doble click para el 
        Try
            If e.X > c1grdBusqueda.Rows.Fixed Then
                acTool_ACBtnModificar_Click(Nothing, Nothing)
                acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar el registro seleccionado", ex)
        End Try
    End Sub

    Private Sub c1grdBusqueda_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles c1grdBusqueda.OwnerDrawCell

    End Sub
End Class