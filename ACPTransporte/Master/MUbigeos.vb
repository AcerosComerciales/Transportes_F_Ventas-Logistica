Imports ACBVentas
Imports ACEVentas
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid

Public Class MUbigeos
#Region " Variables "
   Private managerUbigeos As BUbigeos
   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_eubigeos As EUbigeos
   Private bs_bubigeos As BindingSource
   Private frmUbigeos As ACControles.ACAyudaTreeView
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

         managerUbigeos = New BUbigeos
         acTool.ACBtnEliminar.Enabled = False
         acTool.ACBtnModificar.Enabled = False

         txtBusqueda.ACActivarAyudaAuto = True
         txtBusqueda.ACLongitudAceptada = Parametros.GetParametro(EParametros.TipoParametros.pg_LongTexAyuda)
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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 4, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "UBIGO_Codigo", "UBIGO_Codigo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Padre", "UPADRE_DESCRIPCION", "UPADRE_DESCRIPCION", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Descripción", "UBIGO_Descripcion", "UBIGO_Descripcion", 150, True, False, "System.String", "") : index += 1

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
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, False, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
            txtUbigeoPadre.ReadOnly = True
            acTool.ACBtnGrabar.Enabled = True
            txtCodigo.Mask = "00.00.00"
         Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, False, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
            txtUbigeoPadre.ReadOnly = True
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
         bs_bubigeos = New BindingSource()
         bs_bubigeos.DataSource = managerUbigeos.getListUbigeos
         c1grdBusqueda.DataSource = bs_bubigeos
         bnavBusqueda.BindingSource = bs_bubigeos
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
         m_listBindHelper.Add(ACBindHelper.ACBind(txtCodigo, "Text", m_eubigeos, "UBIGO_Codigo"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxaCodPadre, "Text", m_eubigeos, "UBIGO_CodPadre"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDescripcion, "Text", m_eubigeos, "UBIGO_Descripcion"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDescCorta, "Text", m_eubigeos, "UBIGO_DescCorta"))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar()
      Try
         If bs_bubigeos.Current IsNot Nothing Then
            Dim x_codigo As String = CType(bs_bubigeos.Current, EUbigeos).UBIGO_Codigo
            managerUbigeos.Cargar(x_codigo)
            m_eubigeos = managerUbigeos.getUbigeos()
            txtUbigeoPadre.Text = CType(bs_bubigeos.Current, EUbigeos).UPADRE_DESCRIPCION
            If (m_eubigeos.UBIGO_Codigo.Trim().Length = 2) Then
               txtCodigo.Mask = "00"
            ElseIf (m_eubigeos.UBIGO_Codigo.Length = 5) Then
               txtCodigo.Mask = "00.00"
            ElseIf (m_eubigeos.UBIGO_Codigo.Length = 5) Then
               txtCodigo.Mask = "00.00.00"
            End If
            AsignarBinding()
            If (m_eubigeos.UBIGO_PROTEGIDO) Then
               acTool.ACBtnGrabar.Enabled = False
               ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
            Else
               acTool.ACBtnGrabar.Enabled = True
            End If
            tabMantenimiento.SelectedTab = tabDatos
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
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
         If txtBusqueda.ACEstadoAutoAyuda Then
            If managerUbigeos.Busqueda(x_cadena) Then
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
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

#End Region
#End Region

#Region "Procesos"
   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of EUbigeos)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_bubigeos.DataSource, List(Of EUbigeos)).Sort(_ordenador)
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

         m_eubigeos = New EUbigeos()
         m_eubigeos.Instanciar(ACEInstancia.Nuevo)
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         AsignarBinding()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Ubigeo", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         For Each Item As ACBindHelper In m_listBindHelper
            Item.ACUnBind()
         Next
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Ubigeo", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnModificar_Click
      Try
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         cargar()
         tabMantenimiento.SelectedTab = tabDatos
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar Ubigeo", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
            managerUbigeos.setUbigeos(m_eubigeos)
            If (m_eubigeos.UBIGO_Codigo(m_eubigeos.UBIGO_Codigo.Length - 1) = ".") Then
               m_eubigeos.UBIGO_Codigo = m_eubigeos.UBIGO_Codigo.Substring(0, m_eubigeos.UBIGO_Codigo.Length - 1)
            End If
            If managerUbigeos.Guardar(GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
               tabMantenimiento.SelectedTab = tabBusqueda
               acTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabIni
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
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Registro: {0}", Convert.ToString(Me.Text)), String.Format("Desea eliminar el registro: {0}?", CType(bs_bubigeos.Current, EUbigeos).UBIGO_Descripcion), ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            If Not CType(bs_bubigeos.Current, EUbigeos).UBIGO_PROTEGIDO Then
               m_eubigeos = CType(bs_bubigeos.Current, EUbigeos)
               m_eubigeos.Instanciar(ACEInstancia.Eliminado)
               managerUbigeos.setUbigeos(m_eubigeos)
               managerUbigeos.Guardar(GApp.Usuario)
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Convert.ToString(Me.Text)), "Eliminado satisfactoriamente")
               busqueda(txtBusqueda.Text)
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede eliminar por que es un campo protegido")
            End If
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
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede cargar el registro seleccionado", ex)
      End Try

   End Sub
#End Region

   Private Sub actxaCodPadre_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCodPadre.ACAyudaClick
      Try
         If IsNothing(frmUbigeos) Then
            frmUbigeos = New ACControles.ACAyudaTreeView(Colecciones.UbigeosDT, "Ubigeos", True, "Ubigeos", True)
         End If
         If frmUbigeos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If frmUbigeos.Codigo = "" Then
               txtUbigeoPadre.Text = ""
               actxaCodPadre.Text = ""
            Else
               If (frmUbigeos.Codigo.Length = 2) Then
                  txtUbigeoPadre.Text = frmUbigeos.Desc
                  actxaCodPadre.Text = frmUbigeos.Codigo
                  txtCodigo.Text = frmUbigeos.Codigo
                  txtCodigo.Mask = "00.00"
               ElseIf (frmUbigeos.Codigo.Length = 5) Then
                  txtUbigeoPadre.Text = frmUbigeos.Desc
                  actxaCodPadre.Text = frmUbigeos.Codigo
                  txtCodigo.Text = frmUbigeos.Codigo
                  txtCodigo.Mask = "00.00.00"
               ElseIf (frmUbigeos.Codigo.Length > 7) Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No se puede colocar como padre a: {0}", frmUbigeos.Desc))
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Ubigeos Destino", ex)
      End Try
   End Sub

   Private Sub c1grdBusqueda_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdBusqueda.BeforeSort
      Try
         Ordenar(c1grdBusqueda.Cols(e.Col).UserData)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub

End Class