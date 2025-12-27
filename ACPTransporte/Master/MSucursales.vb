Imports ACBVentas
Imports ACEVentas
Imports ACFramework

Imports C1.Win.C1FlexGrid

Public Class MSucursales
#Region " Variables "
   Private managerSucursales As BSucursales
   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_esucursales As ESucursales
   Private bs_bsucursales As BindingSource
   Private m_order As Integer = 1
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda
         formatearGrilla()
         managerSucursales = New BSucursales

         acTool.ACBtnEliminar.Enabled = False
         acTool.ACBtnModificar.Enabled = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

#End Region

#Region " Metodos "
#Region " Utilitarios "
   ' <summary>
   ' Dar Formato a la grilla de busqueda
   ' </summary>
   ' <remarks></remarks>
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 5, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "SUCUR_Id", "SUCUR_Id", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nombre", "SUCUR_Nombre", "SUCUR_Nombre", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Dirección", "SUCUR_Direccion", "SUCUR_Direccion", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Telefono", "SUCUR_Telefono", "SUCUR_Telefono", 150, True, False, "System.String", "") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)

      Select Case _opcion
         Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
            txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar
         Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

      End Select

   End Sub
#End Region

#Region " Cargar Datos "
   ' <summary>
   ' Cargar los datos en el control Visual C1FlexGrid
   ' </summary>
   Private Sub cargarDatos()
      Try
         bs_bsucursales = New BindingSource()
         bs_bsucursales.DataSource = managerSucursales.getListSucursales
         c1grdBusqueda.DataSource = bs_bsucursales
         bnavBusqueda.BindingSource = bs_bsucursales
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
         m_listBindHelper.Add(ACBindHelper.ACBind(txtCodigo, "Text", m_esucursales, "SUCUR_Id"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtNombre, "Text", m_esucursales, "SUCUR_Nombre"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDireccion, "Text", m_esucursales, "SUCUR_Direccion"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtTelefono, "Text", m_esucursales, "SUCUR_Telefono"))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar()
      Try
         If bs_bsucursales.Current IsNot Nothing Then
            Dim x_codigo As Integer = CType(bs_bsucursales.Current, ESucursales).SUCUR_Id
            Dim x_zona As String = CType(bs_bsucursales.Current, ESucursales).ZONAS_Codigo
            If managerSucursales.Cargar(x_zona, x_codigo) Then
               m_esucursales = managerSucursales.getSucursales()
               AsignarBinding()
               tabMantenimiento.SelectedTab = tabDatos
               acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
            Else
               tabMantenimiento.SelectedTab = tabBusqueda
               acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro ")
            End If
         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Sub

   ' <summary>
   ' Ejecutar la busqueda de una cadena en la tabla Neumaticos
   ' </summary>
   ' <param name="x_cadena">Cadena objetivo</param>
   ' <returns></returns>
   Private Function busqueda(ByVal x_cadena As String) As Boolean
      Try
         If managerSucursales.Busqueda(x_cadena) Then
            acTool.ACBtnEliminar.Enabled = True
            acTool.ACBtnModificar.Enabled = True
         Else
            acTool.ACBtnEliminar.Enabled = False
            acTool.ACBtnModificar.Enabled = False
         End If
         cargarDatos()
         Return acTool.ACBtnModificar.Enabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

#End Region
#End Region

#Region "Procesos"
   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of ESucursales)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_bsucursales.DataSource, List(Of ESucursales)).Sort(_ordenador)
         c1grdBusqueda.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
#Region " Tool Bar "
   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         tabMantenimiento.SelectedTab = tabDatos
         m_esucursales = New ESucursales()
         m_esucursales.Instanciar(ACEInstancia.Nuevo)
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         AsignarBinding()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nueva Sucursal", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         For Each Item As ACBindHelper In m_listBindHelper
            Item.ACUnBind()
         Next
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Sucursal", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnModificar_Click
      Try
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         cargar()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar Sucursal", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
            If m_esucursales.Nuevo Then
               m_esucursales.EMPRE_Codigo = GApp.Empresa
               m_esucursales.ZONAS_Codigo = GApp.Zona
            End If
            managerSucursales.setSucursales(m_esucursales)
            If managerSucursales.Guardar(GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
               tabMantenimiento.SelectedTab = tabBusqueda
               acTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabIni
               busqueda(txtBusqueda.Text)
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar, por que hay campos obligatorios vacios: {0}", msg))
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub acTool_ACBtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnEliminar_Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Registro: {0}", Convert.ToString(Me.Text)), String.Format("Desea eliminar el registro: {0}?", CType(bs_bsucursales.Current, ESucursales).SUCUR_Nombre), ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            m_esucursales = CType(bs_bsucursales.Current, ESucursales)
            m_esucursales.Instanciar(ACEInstancia.Eliminado)
            managerSucursales.setSucursales(m_esucursales)
            managerSucursales.Guardar(GApp.Usuario)
            ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Convert.ToString(Me.Text)), "Eliminado satisfactoriamente")
            busqueda(txtBusqueda.Text)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede Eliminar", ex)
      End Try
   End Sub
#End Region

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
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
            cargar()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar el registro seleccionado", ex)
      End Try

   End Sub
#End Region

   Private Sub c1grdBusqueda_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdBusqueda.BeforeSort
      Try
         Ordenar(c1grdBusqueda.Cols(e.Col).UserData)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub

End Class