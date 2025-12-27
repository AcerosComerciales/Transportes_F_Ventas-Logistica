Imports ACBVentas
Imports ACEVentas
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid
Imports ACBTransporte
Imports ACETransporte

Public Class MVehiculos

#Region "Variables"

   Private managerTRAN_Vehiculos As BTRAN_Vehiculos 'o
   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_etran_vehiculos As ETRAN_Vehiculos
   Private bs_btran_vehiculos As BindingSource

   Private managerEntidades As BEntidades
   Private m_order As Integer = 1

#End Region

#Region "Propiedades"

#End Region

#Region "Constructores"
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda
         AcTool.ACMostrarTabs = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways

         formatearGrilla()
         cargarCombos()

         managerTRAN_Vehiculos = New BTRAN_Vehiculos
         managerEntidades = New BEntidades

         eprError.SetError(cmbMarca, "Campo Obligatorio")
         eprError.SetError(cmbTipVehiculo, "Campo Obligatorio")

         AcTool.ACBtnEliminar.Enabled = False
         AcTool.ACBtnModificar.Enabled = False
         bnavBusqueda.Visible = True

         txtBusqueda.ACActivarAyudaAuto = False
         'txtBusqueda.ACLongitudAceptada = Parametros.GetParametro(EParametros.TipoParametros.pg_LongTexAyuda)

         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.Ttruck_blue_16x16.GetHicon)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub
#End Region

#Region "Metodos"

#Region "Utilitarios"
   ' <summary>
   ' Dar Formato a la grilla de busqueda
   ' </summary>
   ' <remarks></remarks>
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 15, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "VehiculoID", "VEHIC_Id", "VEHIC_Id", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Marca", "TIPOS_Marca", "TIPOS_Marca", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Vehiculo", "TIPOS_Vehiculo", "TIPOS_Vehiculo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Modelo", "VEHIC_Modelo", "VEHIC_Modelo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Transportista", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Combustible", "TIPOS_TipoCombustible", "TIPOS_TipoCombustible", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Capac Combustible", "VEHIC_Combustible", "VEHIC_Combustible", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Adq.", "VEHIC_FecAdquisicion", "VEHIC_FecAdquisicion", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro Ejes", "VEHIC_NumeroEjes", "VEHIC_NumeroEjes", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro Neumaticos", "VEHIC_NroNeumaticos", "VEHIC_NroNeumaticos", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Km Inicial", "VEHIC_KmInicial", "VEHIC_KmInicial", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Km Actual", "VEHIC_KmActual", "VEHIC_KmActual", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Certificado", "VEHIC_Certificado", "VEHIC_Certificado", 150, True, False, "System.String", "") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
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
         ACFramework.ACUtilitarios.ACCargaCombo(cmbMarca, Colecciones.Tipos(ETipos.MyTipos.MarcasVehiculos), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipVehiculo, Colecciones.Tipos(ETipos.MyTipos.TipoVehiculos), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbCombustible, Colecciones.Tipos(ETipos.MyTipos.TipoCombustible), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbPuntoVenta, Colecciones.PuntosVenta, "PVENT_Descripcion", "PVENT_Id")

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)
      Select Case _opcion
         Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
            txtVehiculoID.Enabled = False
            chkAnulado.Checked = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            txtVehiculoID.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar
         Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

      End Select
   End Sub

#End Region

#Region "Cargar Datos"
   ' <summary>
   ' Cargar los datos en el control Visual C1FlexGrid
   ' </summary>
   Private Sub cargarDatos()
      Try
         bs_btran_vehiculos = New BindingSource()
         bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos
         c1grdBusqueda.DataSource = bs_btran_vehiculos
         bnavBusqueda.BindingSource = bs_btran_vehiculos

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
         m_listBindHelper.Add(ACBindHelper.ACBind(txtVehiculoID, "Text", m_etran_vehiculos, "VEHIC_Id"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtPlaca, "Text", m_etran_vehiculos, "VEHIC_Placa"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbMarca, "SelectedValue", m_etran_vehiculos, "TIPOS_CodMarca"))

         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipVehiculo, "SelectedValue", m_etran_vehiculos, "TIPOS_CodTipoVehiculo"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtModelo, "Text", m_etran_vehiculos, "VEHIC_Modelo"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbCombustible, "SelectedValue", m_etran_vehiculos, "TIPOS_CodTipoCombustible"))

         m_listBindHelper.Add(ACBindHelper.ACBind(txtVehiCombustible, "Text", m_etran_vehiculos, "VEHIC_Combustible"))
         If m_etran_vehiculos.VEHIC_FecAdquisicion.Year < 1700 Then m_etran_vehiculos.VEHIC_FecAdquisicion = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecAdquisicion, "Value", m_etran_vehiculos, "VEHIC_FecAdquisicion"))

         m_listBindHelper.Add(ACBindHelper.ACBind(txtNroEjes, "Text", m_etran_vehiculos, "VEHIC_NumeroEjes"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtNroNeumaticos, "Text", m_etran_vehiculos, "VEHIC_NroNeumaticos"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnKilomInicial, "Text", m_etran_vehiculos, "VEHIC_KmInicial"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxnKilomActual, "Text", m_etran_vehiculos, "VEHIC_KmActual"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtCertificado, "Text", m_etran_vehiculos, "VEHIC_Certificado"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxaCodTransportista, "Text", m_etran_vehiculos, "ENTID_CodigoTransportista"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbPuntoVenta, "SelectedValue", m_etran_vehiculos, "PVENT_Id"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxnCargaMax, "Text", m_etran_vehiculos, "VEHIC_CargaMax"))

         m_listBindHelper.Add(ACBindHelper.ACBind(chkVehiculos, "Checked", m_etran_vehiculos, "VEHIC_GeneraViajes"))

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar()
      Try
         If bs_btran_vehiculos.Current IsNot Nothing Then
            Dim x_codvehi As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id

            If managerTRAN_Vehiculos.Cargar(x_codvehi, True) Then
               m_etran_vehiculos = managerTRAN_Vehiculos.TRAN_Vehiculos
               AsignarBinding()
               chkAnulado.Checked = (m_etran_vehiculos.VEHIC_Estado = ETRAN_Vehiculos.getEstado(ETRAN_Vehiculos.Estado.Anulado))
               actxaDescTransportista.Text = m_etran_vehiculos.ENTID_RazonSocial
               tabMantenimiento.SelectedTab = tabDatos
               AcTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
            End If
         End If

      Catch ex As Exception
         AcTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
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
         'If txtBusqueda.ACEstadoAutoAyuda Then
         If managerTRAN_Vehiculos.Busqueda(getCampo(), x_cadena) Then
            AcTool.ACBtnEliminar.Enabled = True
            AcTool.ACBtnModificar.Enabled = True
         Else
            AcTool.ACBtnEliminar.Enabled = False
            AcTool.ACBtnModificar.Enabled = False
         End If
         cargarDatos()
         'End If
         Return AcTool.ACBtnModificar.Enabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

#End Region

   Private Function getCampo() As Short
      Try
         If (rbtnCodigo.Checked) Then
            Return 0
         ElseIf rbtnPlaca.Checked Then
            Return 1
         Else
            Return 1
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         Dim _where As New Hashtable
         _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
         managerEntidades.Ayuda(_where, x_opcion)
         Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerEntidades.DTEntidades, False)
         If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Select Case x_opcion
               Case EEntidades.TipoEntidad.Transportista
                  '' Cargar datos del cliente
                  actxaCodTransportista.Text = Ayuda.Respuesta.Rows(0)("Codigo")
                  actxaDescTransportista.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                  If Not m_etran_vehiculos.Nuevo Then
                     m_etran_vehiculos.Instanciar(ACEInstancia.Modificado)
                  End If
               Case EEntidades.TipoEntidad.Conductores

            End Select
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

#Region "Procesos"

   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of ETRAN_Vehiculos)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_btran_vehiculos.DataSource, List(Of ETRAN_Vehiculos)).Sort(_ordenador)
         c1grdBusqueda.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region "Metodos Controles"

#Region "Tool Bars"

   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AcTool.ACBtnNuevo_Click
      Try
         tabMantenimiento.SelectedTab = tabDatos

         m_etran_vehiculos = New ETRAN_Vehiculos()
         m_etran_vehiculos.Instanciar(ACEInstancia.Nuevo)
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         AsignarBinding()
         txtVehiculoID.Focus()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Vehiculo", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AcTool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         For Each Item As ACBindHelper In m_listBindHelper
            Item.ACUnBind()
         Next
         txtBusqueda.Focus()
         Me.KeyPreview = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Vehiculo", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AcTool.ACBtnModificar_Click
      Try
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         cargar()
         tabMantenimiento.SelectedTab = tabDatos
         txtVehiculoID.Focus()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar Vehiculo", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AcTool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
            If m_etran_vehiculos.Nuevo Then m_etran_vehiculos.VEHIC_Id = managerTRAN_Vehiculos.getCorrelativo()
            managerTRAN_Vehiculos.TRAN_Vehiculos = m_etran_vehiculos
            managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Estado = IIf(chkAnulado.Checked, ETRAN_Vehiculos.getEstado(ETRAN_Vehiculos.Estado.Anulado), ETRAN_Vehiculos.getEstado(ETRAN_Vehiculos.Estado.Activo))
            If managerTRAN_Vehiculos.Guardar(GApp.Usuario, True) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
               tabMantenimiento.SelectedTab = tabBusqueda
               busqueda(txtBusqueda.Text)
               Me.KeyPreview = False
               txtBusqueda.Focus()
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar{0}", msg))
               AcTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabFin
            End If
         Else
            AcTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabFin
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("No puede guardar, por que hay campos obligatorios vacios: {0}", msg))
         End If
      Catch ex As Exception
         AcTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabFin
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub acTool_ACBtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcTool.ACBtnEliminar_Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Registro: {0}", Convert.ToString(Me.Text)), String.Format("Desea eliminar el registro: {0}?", CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Placa), ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            m_etran_vehiculos = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos)
            m_etran_vehiculos.Instanciar(ACEInstancia.Eliminado)
            managerTRAN_Vehiculos.setTRAN_Vehiculos(m_etran_vehiculos)
            managerTRAN_Vehiculos.Guardar(GApp.Usuario)
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

   Private Sub actxaDescTransportista_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescTransportista.ACAyudaClick
      Try
         AyudaEntidad(actxaDescTransportista.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Transportista)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar transportista", ex)
      End Try
   End Sub

   Private Sub actxaCodTransportista_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles actxaCodTransportista.ACAyudaClick
      Try
         AyudaEntidad(actxaCodTransportista.Text, "ENTID_Codigo", EEntidades.TipoEntidad.Transportista)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar transportista", ex)
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

   Private Sub c1grdBusqueda_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdBusqueda.BeforeSort
      Try
         Ordenar(c1grdBusqueda.Cols(e.Col).UserData)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub

#End Region

   Private Sub txtBusqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
      Try
         Select Case e.KeyCode
            Case Keys.Down
               bs_btran_vehiculos.Position += 1
               e.Handled = True
               Exit Select
            Case Keys.Up
               bs_btran_vehiculos.Position -= 1
               e.Handled = True
               Exit Select
            Case Keys.PageDown
               bs_btran_vehiculos.Position += 10
               e.Handled = True
               e.Handled = True
               Exit Select
            Case Keys.PageUp
               bs_btran_vehiculos.Position -= 10
               e.Handled = True
               e.Handled = True
               Exit Select
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No puede completar el proceso ejecutado por el teclado", ex)
      End Try
   End Sub


   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      txtBusqueda_ACAyudaClick(sender, e)
   End Sub

   Private Sub tsbtnEnviarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnEnviarExcel.Click
      Utilitarios.ExportarXLS(c1grdBusqueda, String.Format("Vehiculos"))
   End Sub
End Class