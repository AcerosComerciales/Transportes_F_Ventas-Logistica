Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid
Imports ACEVentas

Public Class MRamflas
#Region " Variables "
   Private managerTRAN_Ranflas As BTRAN_Ranflas
   Private bs_btran_ranflas As BindingSource
   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_etran_ranflas As ETRAN_Ranflas
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
         cargarCombos()
         managerTRAN_Ranflas = New BTRAN_Ranflas

         eprError.SetError(txtCodigo, "Campo Obligatorio")
         eprError.SetError(cmbMarca, "Campo Obligatorio")
         eprError.SetError(txtPlaca, "Campo Obligatorio")

         acTool.ACBtnEliminar.Enabled = False
         acTool.ACBtnModificar.Enabled = False

         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACRanfla_16x16.GetHicon)
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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 6, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "RANFL_Id", "RANFL_Id", 150, True, False, "System.Integer", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Marca", "TIPOS_Marca", "TIPOS_Marca", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Placa", "RANFL_Placa", "RANFL_Placa", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Certificado", "RANFL_Certificado", "RANFL_Certificado", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Adquisición", "RANFL_FecAdquisicion", "RANFL_FecAdquisicion", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub cargarCombos()
      Try
         ACFramework.ACUtilitarios.ACCargaCombo(cmbMarca, Colecciones.Tipos(ETipos.MyTipos.MarcasRanflas), "TIPOS_Descripcion", "TIPOS_Codigo")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

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

#Region " Cargar Datos "
   ' <summary>
   ' Cargar los datos en el control Visual C1FlexGrid
   ' </summary>
   Private Sub cargarDatos()
      Try
         bs_btran_ranflas = New BindingSource()
         bs_btran_ranflas.DataSource = managerTRAN_Ranflas.getListTRAN_Ranflas()
         c1grdBusqueda.DataSource = bs_btran_ranflas
         bnavBusqueda.BindingSource = bs_btran_ranflas
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
         m_listBindHelper.Add(ACBindHelper.ACBind(txtCodigo, "Text", m_etran_ranflas, "RANFL_Id"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbMarca, "SelectedValue", m_etran_ranflas, "TIPOS_CodMarca"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtModelo, "Text", m_etran_ranflas, "RANFL_Modelo"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtCertificado, "Text", m_etran_ranflas, "RANFL_Certificado"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtPlaca, "Text", m_etran_ranflas, "RANFL_Placa"))
         If (m_etran_ranflas.RANFL_FecAdquisicion.Year < 1700) Then m_etran_ranflas.RANFL_FecAdquisicion = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecAdquicision, "Value", m_etran_ranflas, "RANFL_FecAdquisicion"))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar()
      Try
         If bs_btran_ranflas.Current IsNot Nothing Then
            Dim x_codigo As Integer = CType(bs_btran_ranflas.Current, ETRAN_Ranflas).RANFL_Id
            managerTRAN_Ranflas.Cargar(x_codigo)
            m_etran_ranflas = managerTRAN_Ranflas.getTRAN_Ranflas()
            AsignarBinding()
            tabMantenimiento.SelectedTab = tabDatos
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Sub
#End Region

   ' <summary>
   ' Ejecutar la busqueda de una cadena en la tabla conductores
   ' </summary>
   ' <param name="x_cadena">Cadena objetivo</param>
   ' <returns></returns>
   Private Function busqueda(ByVal x_cadena As String) As Boolean
      Try
            If managerTRAN_Ranflas.Busqueda(x_cadena, getCampo(), chkTodos.Checked) Then
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

   Private Function getCampo() As String
      Try
         If (rbtnCodigo.Checked) Then
            Return "RANFL_Codigo"
         ElseIf rbtnPlaca.Checked Then
            Return "RANFL_Placa"
         Else
            Return "RANFL_Codigo"
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos de Controles"
#Region " Tool Bar "
   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         tabMantenimiento.SelectedTab = tabDatos

         m_etran_ranflas = New ETRAN_Ranflas()
         m_etran_ranflas.Instanciar(ACEInstancia.Nuevo)
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         AsignarBinding()
         txtCodigo.Focus()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nueva Ranfla", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         For Each Item As ACBindHelper In m_listBindHelper
            Item.ACUnBind()
         Next
         txtBusqueda.Focus()
         Me.KeyPreview = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Ranfla", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnModificar_Click
      Try
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         cargar()
         tabMantenimiento.SelectedTab = tabDatos
         txtCodigo.Focus()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar Ranfla", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) Then
            'managerTRAN_Ranflas.setTRAN_Ranflas(m_etran_ranflas)

            If m_etran_ranflas.Nuevo = True Then
               ''Correlativo
               m_etran_ranflas.RANFL_Id = managerTRAN_Ranflas.getCorrelativo()
            End If

            managerTRAN_Ranflas.setTRAN_Ranflas(m_etran_ranflas)


            If managerTRAN_Ranflas.Guardar(GApp.Usuario, True) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
               tabMantenimiento.SelectedTab = tabBusqueda
               acTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabIni
               txtBusqueda.Focus()
               busqueda(txtBusqueda.Text)
               Me.KeyPreview = False
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar{0}", msg))
               acTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabFin
            End If
         Else
            acTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabFin
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar, por que hay campos obligatorios vacios: {0}", msg))
         End If
      Catch ex As Exception
         acTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabFin
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub acTool_ACBtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnEliminar_Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Registro: {0}", Convert.ToString(Me.Text)), String.Format("Desea eliminar el registro: {0}?", CType(bs_btran_ranflas.Current, ETRAN_Ranflas).RANFL_Codigo), ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            m_etran_ranflas = CType(bs_btran_ranflas.Current, ETRAN_Ranflas)
            m_etran_ranflas.Instanciar(ACEInstancia.Eliminado)
            managerTRAN_Ranflas.setTRAN_Ranflas(m_etran_ranflas)
            managerTRAN_Ranflas.Guardar(GApp.Usuario)
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

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub
#End Region

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            busqueda(txtBusqueda.Text)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
        End Try
    End Sub
End Class