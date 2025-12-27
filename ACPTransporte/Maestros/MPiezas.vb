Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports C1.Win.C1FlexGrid
Imports ACEVentas

Public Class MPiezas
#Region " Variables "
   Private managerTRAN_Piezas As BTRAN_Piezas
   Private m_tran_piezas As ETRAN_Piezas

   Private bs_btran_piezas As BindingSource
   Private m_listBindHelper As List(Of ACBindHelper)

   Private m_inicio As TPieza

   Enum TPieza
      Nueva
      Modificar
      Normal
   End Enum
#End Region

#Region " Propiedades "


   Public Property TRAN_Piezas() As ETRAN_Piezas
      Get
         Return m_tran_piezas
      End Get
      Set(ByVal value As ETRAN_Piezas)
         m_tran_piezas = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      Try
         Inicio()
         m_inicio = TPieza.Normal
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub

    Public Sub New(ByVal x_inicio As TPieza)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            Inicio()
            m_inicio = x_inicio
            acTool_ACBtnNuevo_Click(Nothing, Nothing)
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Nuevo)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub

    Public Sub New(ByVal x_Descripcion As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            Inicio()
            'm_inicio = x_inicio
            txtDescripcion.Text = x_Descripcion
            acTool_ACBtnNuevo_Click(Nothing, Nothing)
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Nuevo)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar los controles iniciales", ex)
        End Try
    End Sub




#End Region

#Region " Metodos "
    Private Sub Inicio()
      tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
      tabMantenimiento.SelectedTab = tabBusqueda
      formatearGrilla()
      managerTRAN_Piezas = New BTRAN_Piezas

      acTool.ACBtnEliminar.Enabled = False
      acTool.ACBtnModificar.Enabled = False

      txtBusqueda.ACActivarAyudaAuto = True
      txtBusqueda.ACLongitudAceptada = Parametros.GetParametro(EParametros.TipoParametros.pg_LongTexAyuda)

      Dim _tran As New BTRAN_Vehiculos
      _tran.TRAN_ObtenerModelosVehiculos(GApp.PuntoVenta)
      ACUtilitarios.ACCargaCombo(cmbClasificacion, _tran.DTTRAN_Vehiculos, "VEHIC_Modelo", "VEHIC_Modelo")


      Me.KeyPreview = True
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 5, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Id", "PIEZA_Id", "PIEZA_Id", 150, True, False, "System.Integer") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "PIEZA_Codigo", "PIEZA_Codigo", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nombre", "PIEZA_Descripcion", "PIEZA_Descripcion", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Clasificación", "PIEZA_Clasificacion", "PIEZA_Clasificacion", 150, True, False, "System.String") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)

      Select Case _opcion
         Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
            'txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            'txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

         Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

      End Select

   End Sub

   ' <summary>
   ' Realiza el enlace de los controles visuales con la clase esquema
   ' </summary>
   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(txtCodigo, "Text", managerTRAN_Piezas.TRAN_Piezas, "PIEZA_Codigo"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDescripcion, "Text", managerTRAN_Piezas.TRAN_Piezas, "PIEZA_Descripcion"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtMarca, "Text", managerTRAN_Piezas.TRAN_Piezas, "PIEZA_Marca"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbClasificacion, "Text", managerTRAN_Piezas.TRAN_Piezas, "PIEZA_Clasificacion"))

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar(ByVal x_codigo As String)
      Try
         If managerTRAN_Piezas.Cargar(x_codigo, True) Then
            AsignarBinding()
            tabMantenimiento.SelectedTab = tabDatos
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Sub

   Private Sub cargarDatos()
      Try
         bs_btran_piezas = New BindingSource()
         bs_btran_piezas.DataSource = managerTRAN_Piezas.ListTRAN_Piezas
         c1grdBusqueda.DataSource = bs_btran_piezas
         bnavBusqueda.BindingSource = bs_btran_piezas
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function busqueda(ByVal x_cadena As String) As Boolean
      Try
         If txtBusqueda.ACEstadoAutoAyuda Then
            If managerTRAN_Piezas.Busqueda(x_cadena) Then
               acTool.ACBtnEliminar.Enabled = True
               acTool.ACBtnModificar.Enabled = True
            Else
               acTool.ACBtnEliminar.Enabled = False
               acTool.ACBtnModificar.Enabled = False
            End If
            cargarDatos()
         End If
         Return acTool.ACBtnModificar.Enabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function
#End Region

#Region " Metodos de Controles"
#Region " Toolbar "
   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         tabMantenimiento.SelectedTab = tabDatos

         managerTRAN_Piezas.TRAN_Piezas = New ETRAN_Piezas()
         managerTRAN_Piezas.TRAN_Piezas.Instanciar(ACEInstancia.Nuevo)
         managerTRAN_Piezas.TRAN_Piezas.PIEZA_Estado = ETRAN_Piezas.getEstado(ETRAN_Piezas.Estado.Ingresado)
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         AsignarBinding()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nueva Ruta", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         For Each Item As ACBindHelper In m_listBindHelper
            Item.ACUnBind()
         Next
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Ruta", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnModificar_Click
      Try
         If bs_btran_piezas.Current IsNot Nothing Then
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
            Dim x_codigo As String = CType(bs_btran_piezas.Current, ETRAN_Piezas).PIEZA_Codigo
            cargar(x_codigo)
            tabMantenimiento.SelectedTab = tabDatos
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar Ruta", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) Then
            If managerTRAN_Piezas.Guardar(GApp.Usuario, True) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
               tabMantenimiento.SelectedTab = tabBusqueda
               acTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabIni
               busqueda(txtBusqueda.Text)

               Select Case m_inicio
                  Case TPieza.Nueva
                     Me.DialogResult = Windows.Forms.DialogResult.OK
                     Me.Close()
                  Case TPieza.Modificar
                     Me.DialogResult = Windows.Forms.DialogResult.OK
                     Me.Close()
               End Select
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No se puede grabar, faltan datos obligatorios: {0}", msg))
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

#End Region

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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
            acTool_ACBtnModificar_Click(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar el registro seleccionado", ex)
      End Try
   End Sub
#End Region
End Class