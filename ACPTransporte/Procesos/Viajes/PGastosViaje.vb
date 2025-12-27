Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports ACEVentas
Imports ACBVentas

Imports C1.Win.C1FlexGrid

Public Class PGastosViaje

#Region " Variables "
   Private managerTRAN_ViajesGastos As BTRAN_ViajesGastos
   Private managerEntidades As BEntidades

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_etran_viajesgastos As ETRAN_ViajesGastos
   Private bs_btran_viajesgastos As BindingSource
   Private m_opcion As Origen
   Private m_recib_codigo As String
   Private m_caja_id As Long

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
         setInicio(Origen.Normal, 0, DateTime.Now)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Public Sub New(ByVal x_viajes_id As Long, ByVal x_fecha As DateTime)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         setInicio(Origen.Viajes, x_viajes_id, x_fecha)
         m_etran_viajesgastos.VIAJE_Id = x_viajes_id

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Public Sub New(ByVal x_vgast_id As Long, ByVal x_viajes_id As Long, ByVal x_fecha As DateTime, ByVal x_recib_codigo As String, ByVal x_caja_id As Long)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         m_caja_id = x_caja_id
         m_recib_codigo = x_recib_codigo
         setInicio(Origen.Viajes, x_viajes_id, x_fecha)
         If managerTRAN_ViajesGastos.Cargar(x_viajes_id, x_vgast_id, True) Then
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)
            m_etran_viajesgastos = managerTRAN_ViajesGastos.TRAN_ViajesGastos
            acTool.ACBtnEliminarEnabled = False
            acTool.ACBtnModificarEnabled = False
            AsignarBinding()
            actxaNroDocProveedor.Text = m_etran_viajesgastos.ENTID_NroDocumento
            If Not IsNothing(m_etran_viajesgastos.TRAN_Documentos) Then
               If Not IsNothing(m_etran_viajesgastos.TRAN_Documentos.DOCUS_Codigo) Then
                  chkComprobante.Checked = True
                  actxaDescProveedor.Text = m_etran_viajesgastos.ENTID_RazonSocial
               End If
               setInstancia(ACUtilitarios.ACSetInstancia.Modificado)
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub setInicio(ByVal x_opcion As Origen, ByVal x_viaje_id As Long, ByVal x_fecha As DateTime)
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         managerTRAN_ViajesGastos = New BTRAN_ViajesGastos(GApp.Aplicacion, GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
         managerEntidades = New BEntidades

         formatearGrilla()
         cargarCombos(x_viaje_id)
         m_opcion = x_opcion
         Select Case x_opcion
            Case Origen.Normal
               dtpFecha.Value = x_fecha
            Case Origen.Viajes
               Nuevo(x_viaje_id)
               dtpFecha.Value = x_fecha
               dtpFecViaje.Value = x_fecha
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            Case Else
               setInicio(Origen.Normal, 0, DateTime.Now)
         End Select
         acTool.ACBtnEliminarEnabled = False
         acTool.ACBtnModificarEnabled = False
         chkComprobante.Checked = False
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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 5, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Gasto", "TIPOS_Gastos", "TIPOS_Gastos", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Descripcion", "VINGR_Descripcion", "VINGR_Descripcion", 250, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_Descripcion", "TIPOS_Descripcion", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Monto", "VINGR_Monto", "VINGR_Monto", 150, True, False, "System.String", "") : index += 1
         c1grdBusqueda.AllowEditing = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub cargarCombos(ByVal x_viaje_id As Long)
      Try
         ACUtilitarios.ACCargaCombo(cmbTipoGasto, Colecciones.Tipos(ETipos.MyTipos.TipoGasto), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbTipoMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbGuia, Colecciones.TiposDocFactGastos(), "TIPOS_Descripcion", "TIPOS_Codigo")

         Dim _badministracionviajes As New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
         _badministracionviajes.TRAN_Viajes = New ETRAN_Viajes
         _badministracionviajes.TRAN_Viajes.VIAJE_Id = x_viaje_id
         _badministracionviajes.GastosViajeInicial()
         ACUtilitarios.ACCargaCombo(cmbPendiente, _badministracionviajes.ListTESO_Caja, "CAJA_GlosaImporte", "RECIB_Codigo")

      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

   Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)

      Select Case _opcion
         Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
            tabMantenimiento.SelectedTab = tabDatos
            'txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            grpComprobante.Enabled = False
            chkComprobante.Enabled = False
            'txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

         Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

      End Select

   End Sub

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
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoGasto, "SelectedValue", m_etran_viajesgastos, "TIPOS_CodTipoGasto"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoMoneda, "SelectedValue", m_etran_viajesgastos, "TIPOS_CodTipoMoneda"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnMonto, "Text", m_etran_viajesgastos, "VGAST_Monto"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDescripcion, "Text", m_etran_viajesgastos, "VGAST_Descripcion"))
         If m_etran_viajesgastos.VGAST_Fecha.Year < 1700 Then m_etran_viajesgastos.VGAST_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecha, "Value", m_etran_viajesgastos, "VGAST_Fecha"))
         m_listBindHelper.Add(ACBindHelper.ACBind(CheckBox1, "Checked", m_etran_viajesgastos, "VGAST_Comprobantes"))
         If m_etran_viajesgastos.VGAST_FechaViaje.Year < 1700 Then m_etran_viajesgastos.VGAST_FechaViaje = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecViaje, "Value", m_etran_viajesgastos, "VGAST_FechaViaje"))
         '' Comprobante
         'm_listBindHelper.Add(ACBindHelper.ACBind(actxaNroDocProveedor, "Text", m_etran_viajesgastos, "ENTID_CodigoProveedor"))
         If Not IsNothing(m_etran_viajesgastos.TRAN_Documentos) Then
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbGuia, "SelectedValue", m_etran_viajesgastos.TRAN_Documentos, "TIPOS_CodTipoDocumento"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtSerie, "Text", m_etran_viajesgastos.TRAN_Documentos, "DOCUS_Serie"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", m_etran_viajesgastos.TRAN_Documentos, "DOCUS_Numero"))
         End If
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

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         Select Case x_opcion
            Case EEntidades.TipoEntidad.Proveedores
               Dim _where As New Hashtable
               _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
               If managerEntidades.Ayuda(_where, x_opcion) Then
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Proveedor", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     '' Cargar datos del cliente
                     actxaNroDocProveedor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     m_etran_viajesgastos.ENTID_CodigoProveedor = Ayuda.Respuesta.Rows(0)("Codigo")
                     actxaDescProveedor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")

                     If managerEntidades.Cargar(m_etran_viajesgastos.ENTID_CodigoProveedor, EEntidades.TipoInicializacion.Proveedor) Then
                        lblTipoDocumento.Focus()
                     End If
                  End If
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
               End If
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub NuevaEntidad(ByVal x_entid_nrodocumento As String, ByVal x_tipoentidad As EEntidades.TipoEntidad)
      Try
         Dim frmEntidad As New MEntidad(MEntidad.Inicio.NuevaEntidad, x_tipoentidad)
         frmEntidad.StartPosition = FormStartPosition.CenterScreen
         If x_entid_nrodocumento.Length > 0 Then
            frmEntidad.EEntidad.ENTID_NroDocumento = x_entid_nrodocumento
            frmEntidad.lblNombres.Focus()
         End If
         If frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Select Case x_tipoentidad
               Case EEntidades.TipoEntidad.Proveedores
                  If managerEntidades.Cargar(frmEntidad.EEntidad.ENTID_Codigo, EEntidades.TipoInicializacion.Direcciones) Then
                     actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     m_etran_viajesgastos.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                  End If
            End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
      End Try
   End Sub

   Private Sub Nuevo(ByVal x_viajes_id As Long)
      Try
         tabMantenimiento.SelectedTab = tabDatos

         m_etran_viajesgastos = New ETRAN_ViajesGastos()
         m_etran_viajesgastos.VIAJE_Id = x_viajes_id
         m_etran_viajesgastos.Instanciar(ACEInstancia.Nuevo)
         m_etran_viajesgastos.TRAN_Documentos = New ETRAN_Documentos()
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         AsignarBinding()
         cmbTipoGasto.Focus()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Nuevo Vehiculo", ex)
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
#Region " Tool Bar "
   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         tabMantenimiento.SelectedTab = tabDatos

         m_etran_viajesgastos = New ETRAN_ViajesGastos()
         m_etran_viajesgastos.Instanciar(ACEInstancia.Nuevo)
         m_etran_viajesgastos.TRAN_Documentos = New ETRAN_Documentos()
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         AsignarBinding()
         cmbTipoGasto.Focus()
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
            If chkComprobante.Checked Then
               If Not ACFramework.ACUtilitarios.ACDatosOk(grpComprobante, msg) Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No puede guardar" + msg)
                  acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                  Exit Sub
               End If
            End If
            m_etran_viajesgastos.SUCUR_Id = GApp.Sucursal
            m_etran_viajesgastos.ZONAS_Codigo = GApp.Zona
            Dim _where As New Hashtable : _where.Add("VIAJE_Id", New ACWhere(m_etran_viajesgastos.VIAJE_Id))
            If m_etran_viajesgastos.Nuevo Then m_etran_viajesgastos.VGAST_Id = managerTRAN_ViajesGastos.getCorrelativo("VGAST_Id", _where)
            managerTRAN_ViajesGastos.TRAN_ViajesGastos = m_etran_viajesgastos
            If managerTRAN_ViajesGastos.Guardar(GApp.Usuario, chkComprobante.Checked, Parametros.GetParametro(EParametros.TipoParametros.Empresa), cmbPendiente.SelectedValue, _
                                                m_recib_codigo, m_caja_id) Then
               tabMantenimiento.SelectedTab = tabBusqueda
               busqueda(txtBusqueda.Text)
               Me.KeyPreview = False
               txtBusqueda.Focus()
               Select Case m_opcion
                  Case Origen.Viajes
                     Me.DialogResult = Windows.Forms.DialogResult.OK
                     Me.Close()
                  Case Else
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
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
         If sender.Name = "acTool" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub

   Private Sub btnNueProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNueProveedor.Click
      NuevaEntidad("", EEntidades.TipoEntidad.Proveedores)
   End Sub

   Private Sub actxaNroDocProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaNroDocProveedor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaNroDocProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocProveedor.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocProveedor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocProveedor.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocProveedor.Text, EEntidades.TipoInicializacion.Direcciones) Then
                     actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     m_etran_viajesgastos.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo

                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial

                     Label7.Focus()
                  Else
                     If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                     , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaNroDocProveedor.Text) _
                                     , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        NuevaEntidad(actxaNroDocProveedor.Text, EEntidades.TipoEntidad.Proveedores)
                     Else
                        actxaNroDocProveedor.Clear()
                        actxaDescProveedor.Clear()
                        lblProveedor.Focus()
                     End If
                  End If
               End If
            Else
               If actxaNroDocProveedor.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocProveedor.Text))
                  actxaNroDocProveedor.Clear()
                  actxaDescProveedor.Clear()
                  lblProveedor.Focus()
               End If

            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub chkComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComprobante.CheckedChanged
      grpComprobante.Enabled = chkComprobante.Checked
      CheckBox1.Checked = chkComprobante.Checked
      Me.KeyPreview = chkComprobante.Checked
   End Sub

   Private Sub actxaDescCliente_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaDescProveedor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub txtSerie_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress
      'If Char.IsDigit(e.KeyChar) Then
      '   e.Handled = False
      'ElseIf Char.IsControl(e.KeyChar) Then
      '   e.Handled = False
      'Else
      '   e.Handled = True
      'End If
   End Sub

#End Region

   Private Sub chkComprobante_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkComprobante.KeyDown
      Try
         If Not grpComprobante.Enabled Then
            If e.KeyCode = Keys.Enter Then
               KeyPreview = False
               acTool.Focus()
               acTool.ACBtnGrabar.Select()
            End If
         End If
      Catch ex As Exception

      End Try
   End Sub

   Private Sub actxnNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxnNumero.KeyDown
      If e.KeyData = Keys.Enter Then
         KeyPreview = False
         acTool.Focus()
         acTool.ACBtnGrabar.Select()
      End If
   End Sub

    Private Sub acTool_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles acTool.ItemClicked

    End Sub

Private Sub txtSerie_TextChanged( sender As Object,  e As EventArgs) Handles txtSerie.TextChanged

End Sub
End Class