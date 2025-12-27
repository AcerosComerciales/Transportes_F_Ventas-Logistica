Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Public Class PIncidenciaViajes

#Region " Variables "
   Private managerTRAN_IncidenciasViajes As BTRAN_IncidenciasViajes

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_etran_incidenciasviajes As ETRAN_IncidenciasViajes
   Private bs_btran_incidenciasviajes As BindingSource
   Private m_opcion As Origen

   Enum Origen
      Normal
      Viajes
   End Enum

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

         managerTRAN_IncidenciasViajes = New BTRAN_IncidenciasViajes

         formatearGrilla()

         setInicio(Origen.Normal)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Public Sub New(ByVal x_viajes_id As Long)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         managerTRAN_IncidenciasViajes = New BTRAN_IncidenciasViajes

         setInicio(Origen.Viajes)
         m_etran_incidenciasviajes.VIAJE_Id = x_viajes_id

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub setInicio(ByVal x_opcion As Origen)
      Try
         m_opcion = x_opcion
         Select Case x_opcion
            Case Origen.Normal

            Case Origen.Viajes
               acTool_ACBtnNuevo_Click(Nothing, Nothing)
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            Case Else
               setInicio(Origen.Normal)
         End Select
         acTool.ACBtnEliminarEnabled = False
         acTool.ACBtnModificarEnabled = False
      Catch ex As Exception
         Throw ex
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
         'Definicion de grilla de Fletes
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 3, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Descripcion", "INCIV_Descripcion", "INCIV_Descripcion", 350, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "INCIV_Fecha", "INCIV_Fecha", 100, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         c1grdBusqueda.AllowEditing = False

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
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
#End Region

   ' <summary>
   ' Cargar los datos en el control Visual C1FlexGrid
   ' </summary>
   Private Sub cargarDatos()
      Try
         'bs_btran_vehiculos = New BindingSource()
         'bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos
         'c1grdBusqueda.DataSource = bs_btran_vehiculos
         'bnavBusqueda.BindingSource = bs_btran_vehiculos
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
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDescripcion, "Text", m_etran_incidenciasviajes, "INCIV_Descripcion"))
         If m_etran_incidenciasviajes.INCIV_Fecha.Year < 1700 Then m_etran_incidenciasviajes.INCIV_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecha, "Value", m_etran_incidenciasviajes, "INCIV_Fecha"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtAccion, "Text", m_etran_incidenciasviajes, "INCIV_AccionRealizada"))

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar()
      Try
         'If bs_btran_vehiculos.Current IsNot Nothing Then
         '   Dim x_codigo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
         '   managerTRAN_Vehiculos.Cargar(x_codigo)
         '   m_etran_vehiculos = managerTRAN_Vehiculos.getTRAN_Vehiculos()
         AsignarBinding()
         tabMantenimiento.SelectedTab = tabDatos
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
         'End If
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
         Dim rpta As Boolean '= managerTRAN_Vehiculos.Busqueda(x_cadena, getCampo())
         cargarDatos()
         Return rpta
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Function getCampo() As String
      Try
         'If (rbtnCodigo.Checked) Then
         '   Return "VEHIC_Codigo"
         'ElseIf rbtnPlaca.Checked Then
         '   Return "VEHIC_Placa"
         'Else
         Return "VEHIC_Codigo"
         'End If
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

         m_etran_incidenciasviajes = New ETRAN_IncidenciasViajes()
         m_etran_incidenciasviajes.Instanciar(ACEInstancia.Nuevo)
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         AsignarBinding()
         txtDescripcion.Focus()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Nuevo Vehiculo", ex)
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
         Select Case m_opcion
            Case Origen.Viajes
               Me.DialogResult = Windows.Forms.DialogResult.Cancel
               Me.Close()
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cancelar Vehiculo", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnModificar_Click
      Try
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         cargar()
         tabMantenimiento.SelectedTab = tabDatos
         txtDescripcion.Focus()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Modificar Vehiculo", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
            m_etran_incidenciasviajes.SUCUR_Id = GApp.Sucursal
            m_etran_incidenciasviajes.INCIV_Id = managerTRAN_IncidenciasViajes.getCorrelativo()
            m_etran_incidenciasviajes.ZONAS_Codigo = GApp.Zona
            managerTRAN_IncidenciasViajes.setTRAN_IncidenciasViajes(m_etran_incidenciasviajes)
            If managerTRAN_IncidenciasViajes.Guardar(GApp.Usuario) Then
               tabMantenimiento.SelectedTab = tabBusqueda
               busqueda(txtBusqueda.Text)
               Me.KeyPreview = False
               txtBusqueda.Focus()

               Select Case m_opcion
                  Case Origen.Viajes
                     Me.DialogResult = Windows.Forms.DialogResult.OK
                     Me.Close()
                  Case Else
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Grabado satisfactoriamente")
               End Select
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No puede guardar" + msg)
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            End If
         Else
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No puede guardar, por que hay campos obligatorios vacios: " + msg)
         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede grabar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub acTool_ACBtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnEliminar_Click
      Try
         'If ACControles.ACDialogos.ACMostrarMensajePregunta("Eliminar Registro: " & Convert.ToString(Me.Text), "Desea eliminar el registro: " + CType(bs_btran_vehiculos.Current, ETRAN_Neumaticos).NEUMA_Codigo & "?", ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
         '   m_etran_vehiculos = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos)
         '   m_etran_vehiculos.Instanciar(ACEInstancia.Eliminado)
         '   managerTRAN_Vehiculos.setTRAN_Vehiculos(m_etran_vehiculos)
         '   managerTRAN_Vehiculos.Guardar(GApp.Usuario)
         '   ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " & Convert.ToString(Me.Text), "Eliminado satisfactoriamente")
         '   busqueda(txtBusqueda.Text)
         'End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede Eliminar", ex)
      End Try
   End Sub

#End Region

   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
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
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar el registro seleccionado", ex)
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

End Class