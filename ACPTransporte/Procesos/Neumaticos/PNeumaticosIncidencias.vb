Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports ACBVentas
Imports ACEVentas

Imports C1.Win.C1FlexGrid

Public Class PNeumaticosIncidencias

#Region " Variables "
   Private managerTRAN_NeumaticosIncidencias As BTRAN_NeumaticosIncidencias
   Private managerEntidades As BEntidades
   Private managerTRAN_Neumaticos As BTRAN_Neumaticos

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_etran_incidenciasneumaticos As ETRAN_NeumaticosIncidencias
   Private m_etran_neumaticos As ETRAN_Neumaticos
   Private m_opcion As Origen

   Private bs_btran_incidenciasneumaticos As BindingSource
   Private bs_incidencias As BindingSource

   Private bs_btran_neumaticos As BindingSource

   Private m_origen As Origen

   Enum Origen
      Normal
      Viajes
   End Enum

#End Region

#Region " Propiedades "

   Public Property TRAN_IncidenciasNeumaticos() As ETRAN_NeumaticosIncidencias
      Get
         Return m_etran_incidenciasneumaticos
      End Get
      Set(ByVal value As ETRAN_NeumaticosIncidencias)
         m_etran_incidenciasneumaticos = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         managerTRAN_NeumaticosIncidencias = New BTRAN_NeumaticosIncidencias
         managerTRAN_Neumaticos = New BTRAN_Neumaticos
         managerEntidades = New BEntidades

         formatearGrilla()
         cargarCombos()

         m_origen = Origen.Normal
         setInicio(Origen.Normal, 0, 0)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Public Sub New(ByVal x_viajes_id As Long, ByVal x_neuma_id As Long)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         managerTRAN_NeumaticosIncidencias = New BTRAN_NeumaticosIncidencias
         managerTRAN_Neumaticos = New BTRAN_Neumaticos
         managerEntidades = New BEntidades

         m_origen = Origen.Viajes
         setInicio(Origen.Viajes, x_viajes_id, x_neuma_id)
         m_etran_incidenciasneumaticos.VIAJE_Id = x_viajes_id
         m_etran_incidenciasneumaticos.NEUMA_Id = x_neuma_id

         formatearGrilla()
         cargarCombos()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub setInicio(ByVal x_opcion As Origen, ByVal x_viajes_id As Long, ByVal x_neuma_id As Long)
      Try
         m_opcion = x_opcion
         Select Case x_opcion
            Case Origen.Normal

            Case Origen.Viajes
               Nuevo(x_viajes_id, x_neuma_id)
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            Case Else
               setInicio(Origen.Normal, x_viajes_id, x_neuma_id)
         End Select
         acTool.ACBtnEliminarEnabled = False
         acTool.ACBtnModificarEnabled = False
      Catch ex As Exception
         Throw ex
      End Try
   End Sub


#End Region

#Region " Metodos "

   Private Sub Nuevo(ByVal x_viajes_id As Long, ByVal x_neuma_id As Long)
      Try
         managerTRAN_Neumaticos.Cargar(x_neuma_id)
         m_etran_neumaticos = managerTRAN_Neumaticos.getTRAN_Neumaticos()

         tabMantenimiento.SelectedTab = tabDatos

         m_etran_incidenciasneumaticos = New ETRAN_NeumaticosIncidencias()
         m_etran_incidenciasneumaticos.NEUMA_Id = x_neuma_id
         m_etran_incidenciasneumaticos.TRAN_Documentos = New ETRAN_Documentos()
         m_etran_incidenciasneumaticos.Instanciar(ACEInstancia.Nuevo)
         m_etran_incidenciasneumaticos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         AsignarBinding()
         txtDescripcion.Focus()
         Me.KeyPreview = True
         tbcIncidencias.SelectedTab = tbpRegistro
         AddHandler tbcIncidencias.SelectionChanged, AddressOf TabAdicionales_SelectionChanged
         
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Nuevo Vehiculo", ex)
      End Try
   End Sub
#Region " Utilitarios "
   ' <summary>
   ' Dar Formato a la grilla de busqueda
   ' </summary>
   ' <remarks></remarks>
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         'Definicion de grilla de Fletes
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 8, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "NEUMA_Codigo", "NEUMA_Codigo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Sucursal", "SUCUR_Nombre", "SUCUR_Nombre", 150, False, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Marca", "TIPO_Marca", "TIPO_Marca", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "T. Neumatico", "TIPO_Llanta", "TIPO_Llanta", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Modelo", "NEUMA_Modelo", "NEUMA_Modelo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Compra", "NEUMA_FecCompra", "NEUMA_FecCompra", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Kilometraje", "NEUMA_TiempoVidaUtil", "NEUMA_TiempoVidaUtil", 150, True, False, "System.Decimal", "") : index += 1
         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdIncidencias, 1, 1, 10, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncidencias, index, "Codigo", "INCNU_Id", "INCNU_Id", 150, True, False, "System.Integer", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncidencias, index, "Tipo", "TIPOS_TipoIncidencia", "TIPOS_TipoIncidencia", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncidencias, index, "Descripción", "INCNU_Descripcion", "INCNU_Descripcion", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncidencias, index, "Fecha", "INCNU_Fecha", "INCNU_Fecha", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncidencias, index, "Cod. Viaje", "VIAJE_Id_Text", "VIAJE_Id_Text", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncidencias, index, "Documento", "Documento", "Documento", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncidencias, index, "Proveedor", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncidencias, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdIncidencias, index, "Importe", "INCNU_Pago", "INCNU_Pago", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         c1grdIncidencias.AllowEditing = False
         c1grdIncidencias.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdIncidencias.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdIncidencias.Styles.Highlight.BackColor = Color.Gray
         c1grdIncidencias.SelectionMode = SelectionModeEnum.Row
         c1grdIncidencias.VisualStyle = VisualStyle.Office2007Blue
         c1grdIncidencias.AllowSorting = AllowSortingEnum.SingleColumn

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)
      acTool.ACBtnModificarVisible = False
      Select Case _opcion
         Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
            ACFramework.ACUtilitarios.ACLimpiaVar(grpComprobante)
            chkComprobante.Checked = False
            'txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            'txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

         Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

      End Select

   End Sub

   Private Sub cargarCombos()
      Try
         ACUtilitarios.ACCargaCombo(cmbGuia, Colecciones.TiposDocMerTransito(), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbTipoIncidencia, Colecciones.Tipos(ETipos.MyTipos.TipoIncidenciaNeumatico), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbTipoMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")

         ACUtilitarios.ACCargaCombo(cmbMarca, Colecciones.Tipos(ETipos.MyTipos.MarcasNeumaticos), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbTipoLlanta, Colecciones.Tipos(ETipos.MyTipos.TipoNeumatico), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbTipoVehiculo, Colecciones.Tipos(ETipos.MyTipos.TipoVehiculos), "TIPOS_Descripcion", "TIPOS_Codigo")

         acTool.ACBtnModificarVisible = False
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

   

   ' <summary>
   ' Realiza el enlace de los controles visuales con la clase esquema
   ' </summary>
   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDescripcion, "Text", m_etran_incidenciasneumaticos, "INCNU_Descripcion"))
         If m_etran_incidenciasneumaticos.INCNU_Fecha.Year < 1700 Then m_etran_incidenciasneumaticos.INCNU_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecha, "Value", m_etran_incidenciasneumaticos, "INCNU_Fecha"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtAccion, "Text", m_etran_incidenciasneumaticos, "INCNU_AccionRealizada"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoMoneda, "SelectedValue", m_etran_incidenciasneumaticos, "TIPOS_CodTipoMoneda"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnMonto, "Text", m_etran_incidenciasneumaticos, "INCNU_Pago"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoIncidencia, "SelectedValue", m_etran_incidenciasneumaticos, "TIPOS_CodTipoIncidencia"))
         '' Comprobante
         m_listBindHelper.Add(ACBindHelper.ACBind(actxaNroDocProveedor, "Text", m_etran_incidenciasneumaticos, "ENTID_CodigoProveedor"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbGuia, "SelectedValue", m_etran_incidenciasneumaticos.TRAN_Documentos, "TIPOS_CodTipoDocumento"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtSerie, "Text", m_etran_incidenciasneumaticos.TRAN_Documentos, "DOCUS_Serie"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", m_etran_incidenciasneumaticos.TRAN_Documentos, "DOCUS_Numero"))
         ' Neumatico
         m_listBindHelper.Add(ACBindHelper.ACBind(txtCodigo, "Text", m_etran_neumaticos, "NEUMA_Codigo"))
         'm_listBindHelper.Add(ACBindHelper.ACBind(cmbSucursal, "SelectedValue", m_etran_neumaticos, "SUCUR_Id"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbMarca, "SelectedValue", m_etran_neumaticos, "TIPOS_CodMarca"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtModelo, "Text", m_etran_neumaticos, "NEUMA_Modelo"))

         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoLlanta, "SelectedValue", m_etran_neumaticos, "TIPOS_CodTipoLlanta"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtTamano, "Text", m_etran_neumaticos, "NEUMA_Tamano"))

         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoVehiculo, "SelectedValue", m_etran_neumaticos, "TIPOS_CodTipoVehiculo"))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar()
      Try
         AsignarBinding()
         tabMantenimiento.SelectedTab = tabDatos
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Sub

   ' <summary>
   ' Cargar los datos en el control Visual C1FlexGrid
   ' </summary>
   Private Sub cargarDatos()
      Try
         bs_btran_neumaticos = New BindingSource()
         bs_btran_neumaticos.DataSource = managerTRAN_Neumaticos.getListTRAN_Neumaticos
         c1grdBusqueda.DataSource = bs_btran_neumaticos
         bnavBusqueda.BindingSource = bs_btran_neumaticos
      Catch ex As Exception
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
            If managerTRAN_Neumaticos.Busqueda(x_cadena, getCampo(), True) Then
                acTool.ACBtnEliminarEnabled = True
                acTool.ACBtnModificarEnabled = True
            Else
                acTool.ACBtnEliminarEnabled = False
                acTool.ACBtnModificarEnabled = False
            End If
         cargarDatos()
         'End If
         Return acTool.ACBtnEliminarEnabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Function getCampo() As String
      Try
         Return "NEUMA_Codigo"
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
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Cliente", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     '' Cargar datos del cliente
                     actxaNroDocProveedor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     m_etran_incidenciasneumaticos.ENTID_CodigoProveedor = Ayuda.Respuesta.Rows(0)("Codigo")
                     actxaDescProveedor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                     If managerEntidades.Cargar(m_etran_incidenciasneumaticos.ENTID_CodigoProveedor, EEntidades.TipoInicializacion.Proveedor) Then
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
                     m_etran_incidenciasneumaticos.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                  End If
            End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
      End Try
   End Sub

   Private Sub CargarIncidencias()
      bs_incidencias = New BindingSource
      Try
         If Not managerTRAN_NeumaticosIncidencias.Incidencias(m_etran_incidenciasneumaticos.NEUMA_Id) Then
            managerTRAN_NeumaticosIncidencias.ListTRAN_NeumaticosIncidencias = New List(Of ETRAN_NeumaticosIncidencias)()
         End If
         bs_incidencias.DataSource = managerTRAN_NeumaticosIncidencias.ListTRAN_NeumaticosIncidencias
         c1grdIncidencias.DataSource = bs_incidencias
         bnavIncidencias.BindingSource = bs_incidencias
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
#Region " Tool Bar "
   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         If bs_btran_neumaticos.Current IsNot Nothing Then
            Dim x_codigo As Integer = CType(bs_btran_neumaticos.Current, ETRAN_Neumaticos).NEUMA_Id
            managerTRAN_Neumaticos.Cargar(x_codigo)
            m_etran_neumaticos = managerTRAN_Neumaticos.getTRAN_Neumaticos()

            tabMantenimiento.SelectedTab = tabDatos

            m_etran_incidenciasneumaticos = New ETRAN_NeumaticosIncidencias()
            m_etran_incidenciasneumaticos.NEUMA_Id = x_codigo
            m_etran_incidenciasneumaticos.TRAN_Documentos = New ETRAN_Documentos()
            m_etran_incidenciasneumaticos.Instanciar(ACEInstancia.Nuevo)
            m_etran_incidenciasneumaticos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
            AsignarBinding()
            txtDescripcion.Focus()
            Me.KeyPreview = True
            tbcIncidencias.SelectedTab = tbpRegistro
            AddHandler tbcIncidencias.SelectionChanged, AddressOf TabAdicionales_SelectionChanged

         End If
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
      RemoveHandler tbcIncidencias.SelectionChanged, AddressOf TabAdicionales_SelectionChanged
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
            m_etran_incidenciasneumaticos.SUCUR_Id = GApp.Sucursal
            Dim _where As New Hashtable() : _where.Add("NEUMA_Id", New ACWhere(m_etran_incidenciasneumaticos.NEUMA_Id))
            m_etran_incidenciasneumaticos.INCNU_Id = managerTRAN_NeumaticosIncidencias.getCorrelativo("INCNU_Id", _where)
            managerTRAN_NeumaticosIncidencias.setTRAN_NeumaticosIncidencias(m_etran_incidenciasneumaticos)

            Dim _result As Boolean = False
            Select Case m_origen
               Case Origen.Normal
                  If managerTRAN_NeumaticosIncidencias.Guardar(GApp.Usuario, chkComprobante.Checked) Then
                     _result = True
                  End If
               Case Origen.Viajes
                  If managerTRAN_NeumaticosIncidencias.GuardarIngreso(GApp.Usuario, chkComprobante.Checked) Then
                     _result = True
                  End If
            End Select
            If _result Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Grabado satisfactoriamente")
               tabMantenimiento.SelectedTab = tabBusqueda
               busqueda(txtBusqueda.Text)
               Me.KeyPreview = False
               txtBusqueda.Focus()

               Select Case m_opcion
                  Case Origen.Viajes
                     Me.DialogResult = Windows.Forms.DialogResult.OK
                     Me.Close()
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
      RemoveHandler tbcIncidencias.SelectionChanged, AddressOf TabAdicionales_SelectionChanged
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

#Region "Ayudas"
   Private Sub actxaNroDocProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaNroDocProveedor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaDescProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaDescProveedor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
      End Try
   End Sub

#End Region

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
            acTool_ACBtnNuevo_Click(Nothing, Nothing)
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
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

   Private Sub chkComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComprobante.CheckedChanged
      grpComprobante.Enabled = chkComprobante.Checked
   End Sub

   Private Sub actxaNroDocProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocProveedor.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocProveedor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocProveedor.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocProveedor.Text, EEntidades.TipoInicializacion.Direcciones) Then
                     actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     m_etran_incidenciasneumaticos.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                     lblTipoDocumento.Focus()
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

   Private Sub txtSerie_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress
      If Char.IsDigit(e.KeyChar) Then
         e.Handled = False
      ElseIf Char.IsControl(e.KeyChar) Then
         e.Handled = False
      Else
         e.Handled = True
      End If
   End Sub

   Private Sub btnNueTransportista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNueTransportista.Click
      NuevaEntidad("", EEntidades.TipoEntidad.Proveedores)
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      txtBusqueda_ACAyudaClick(Nothing, Nothing)
   End Sub

   Private Sub TabAdicionales_SelectionChanged(ByVal sender As Crownwood.DotNetMagic.Controls.TabControl, ByVal oldPage As Crownwood.DotNetMagic.Controls.TabPage, ByVal newPage As Crownwood.DotNetMagic.Controls.TabPage)
      Try
         Select Case sender.SelectedTab.Name.ToString()
            Case "tbpConsulta"
               CargarIncidencias()
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Cargar {0}", sender.SelectedTab), ex)
      End Try
   End Sub

#End Region


End Class
