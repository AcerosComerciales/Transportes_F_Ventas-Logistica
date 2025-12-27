Imports ACBTransporte
Imports C1.Win.C1FlexGrid
Imports ACETransporte
Imports ACFramework
Imports ACEVentas
Imports ACBVentas

Imports CrystalDecisions.Shared.Json



Public Class ConsultasViajes
    Private importe as Decimal
    private m_btran_documentos As New BTRAN_Documentos()
    private managerReportes as new BTRAN_CombustibleConsumo
    Private managerEntidades As BEntidades
    Private m_etran_combustibleconsumo As ETRAN_CombustibleConsumo
    Private managerGenerarDocumentoDetalle As BTRAN_DocumentosDetalle
    Private bs_detabas_Documentos As BindingSource
    Private managerTRAN_CombustibleConsumo As BTRAN_CombustibleConsumo
    Private m_listBindHelper As List(Of ACBindHelper)
    DIM bs_btran_vehiculos As BindingSource
    Dim docu As String
    Dim _i As Integer = 0
    Dim a As Decimal
    Private m_modArticulo As Boolean = False
       Private m_opcion As Origen

   Enum Origen
      Normal
      Viajes
    End Enum
  


    #Region " Constructores "
   Public Sub New(documento As String, tab As String)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()
        bs_detabas_Documentos = new BindingSource
         managerEntidades = New BEntidades
        
        m_btran_documentos.TRAN_Documentos = New ETRAN_Documentos()
       m_etran_combustibleconsumo= New ETRAN_CombustibleConsumo()
        m_etran_combustibleconsumo.TRAN_Documentos= New ETRAN_Documentos()
        managerGenerarDocumentoDetalle= New BTRAN_DocumentosDetalle()
        managerTRAN_CombustibleConsumo = New BTRAN_CombustibleConsumo(GApp.Aplicacion, GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
        managerGenerarDocumentoDetalle.ListTRAN_DocumentosDetalle=New List(Of ETRAN_DocumentosDetalle)()
        m_etran_combustibleconsumo.TRAN_Documentos.ListETRAN_DocumentosDetalle = New List(Of ETRAN_DocumentosDetalle)()
        TabControl1.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
        
        If (tab ="tpdetalle") Then
         TabControl1.SelectedTab = tpdetalle
            acTool.ACBtnGrabar.Visible=True
            acTool.ACBtnGrabar.Enabled=True
            acTool.ACBtnSalir.Visible=False
            acTool.ACBtnNuevo.Visible=False
            acTool.ACBtnModificar.Visible=False
            acToolTipAceptar.Visible=false
        Else 
         TabControl1.SelectedTab = tpbusqueda
            acTool.ACBtnGrabar.Visible=False
            acTool.ACBtnSalir.Visible=False
            acToolTipAceptar.Visible=True
            acTool.ACBtnNuevo.Visible=False
            acTool.ACBtnModificar.Visible=False
        End If

        cargarCombos()

        ''bindear
          AsignarBinding()

        
        ''''''''''''''''NUEVO
         cargar()
         Me.KeyPreview = True
        '''''''''''''''''
        
      Try
         docu=documento
         formatearGrilla()
        


            If managerReportes.consumo_combustibless(docu) Then

            grddocumentoscombustible.Rows.Count = managerReportes.DTTabla.Rows.Count + 1
         
           
            For Each item As DataRow In managerReportes.DTTabla.Rows
               grddocumentoscombustible.Rows(_i)("id_consumos") = item("id_consumos")
               grddocumentoscombustible.Rows(_i)("VEHIC_Placa") = item("VEHIC_Placa")
               grddocumentoscombustible.Rows(_i)("ENTID_Nombres") = item("ENTID_Nombres")
               grddocumentoscombustible.Rows(_i)("COMCO_PrecioGalon") = item("COMCO_PrecioGalon")
               grddocumentoscombustible.Rows(_i)("COMCO_GalonesConsumidos") = item("COMCO_GalonesConsumidos")
               grddocumentoscombustible.Rows(_i)("COMCO_Total") = item("COMCO_Total")
              _i =+ item("COMCO_Total")
             
            Next
            grddocumentoscombustible.AutoSizeCols()
         End If
             setInicio(Origen.Viajes, DateTime.Now, 0)



            Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub
 
   


    Public Sub New(ByVal x_comco_id As Long)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         setInicio(Origen.Viajes, DateTime.Now, 0)
         If managerTRAN_CombustibleConsumo.ObtConCombustible(x_comco_id) Then
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
          m_etran_combustibleconsumo = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo
            AsignarBinding()
            actxaNroDocProveedor.Text = m_etran_combustibleconsumo.ENTID_CodigoProveedor
            actxaDescProveedor.Text = m_etran_combustibleconsumo.ENTID_RazonSocial
          End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

    Public Sub New(ByVal x_viajes_id As Long, ByVal x_vehic_id As Long, ByVal x_fecha As DateTime)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         setInicio(Origen.Viajes, x_fecha, x_viajes_id)
         m_etran_combustibleconsumo.VIAJE_Id = x_viajes_id
         m_etran_combustibleconsumo.VEHIC_Id = x_vehic_id
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub


    #End Region
  
    Private Sub ConsultasViajes_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtdocu.Text=docu
    End Sub
    Private Sub setInicio(ByVal x_opcion As Origen, ByVal x_fecha As DateTime, ByVal x_viajes_id As Long)
      Try
        
         formatearGrilla()
         cargarCombos()
        managerTRAN_CombustibleConsumo = New BTRAN_CombustibleConsumo(GApp.Aplicacion, GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
         managerEntidades = New BEntidades

         m_opcion = x_opcion
         Select Case x_opcion
            Case Origen.Normal
               acTool.ACBtnNuevoEnabled = False
          Case Origen.Viajes
              acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               dtpFecViaje.Value = x_fecha
               cmbGuia.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura)
               cmbTipoMoneda.SelectedIndex = 0
               Me.KeyPreview = True
            Case Else
               setInicio(Origen.Normal, DateTime.Now, 0)
         End Select
         acTool.ACBtnEliminarEnabled = False
         acTool.ACBtnModificarEnabled = False
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
    Private Sub cargarCombos()
      Try
        
         ACUtilitarios.ACCargaCombo(cmbGuia, Colecciones.TiposDocFacturacion(), "TIPOS_Descripcion", "TIPOS_Codigo", ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura))
            ACUtilitarios.ACCargaCombo(cmbTipoMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
        Catch ex As Exception
         Throw ex
      End Try
   End Sub

    Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(grddocumentoscombustible, 1, 1, 7, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(grddocumentoscombustible, index, "Id", "id_consumos", "id_consumos", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(grddocumentoscombustible, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(grddocumentoscombustible, index, "Conductor", "ENTID_Nombres", "ENTID_Nombres", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(grddocumentoscombustible, index, "Precio Unitario", "COMCO_PrecioGalon", "COMCO_PrecioGalon", 150, True, False, "System.Decimal", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(grddocumentoscombustible, index, "Galones Cosnumidos", "COMCO_GalonesConsumidos", "COMCO_GalonesConsumidos", 150, True, False, "System.Decimal", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(grddocumentoscombustible, index, "Sub Total", "COMCO_Total", "COMCO_Total", 150, True, False, "System.Decimal", "") : index += 1
         

         grddocumentoscombustible.AllowEditing = False
         grddocumentoscombustible.Styles.Alternate.BackColor = Color.WhiteSmoke
         grddocumentoscombustible.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         grddocumentoscombustible.Styles.Highlight.BackColor = Color.Gray
         grddocumentoscombustible.SelectionMode = SelectionModeEnum.Row

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 7, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Item", "DCDET_Item", "DCDET_Item", 110, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Descripción", "DCDET_Descripcion", "DCDET_Descripcion", 90, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Precio", "DCDET_Precio", "DCDET_Precio", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Cantidad", "DCDET_Cantidad", "DCDET_Cantidad", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Sub-Importe", "DCDET_SubImporte", "DCDET_SubImporte", 100, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Importe", "DCDET_Importe", "DCDET_Importe", 100, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         
         c1grdDetalle.AllowEditing = False
         c1grdDetalle.AutoResize = True
         c1grdDetalle.Cols(0).Width = 18
         c1grdDetalle.Styles.Alternate.BackColor = Color.LightGray
         c1grdDetalle.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDetalle.Styles.Highlight.BackColor = Color.Gray
         c1grdDetalle.SelectionMode = SelectionModeEnum.Row
         c1grdDetalle.AllowResizing = AllowResizingEnum.None
         
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub



Private Sub TabControl1_SelectionChanged( sender As Crownwood.DotNetMagic.Controls.TabControl,  oldPage As Crownwood.DotNetMagic.Controls.TabPage,  newPage As Crownwood.DotNetMagic.Controls.TabPage) Handles TabControl1.SelectionChanged

End Sub

Private Sub actxaNroDocProveedor_ACAyudaClick( sender As Object,  e As EventArgs) Handles actxaNroDocProveedor.ACAyudaClick
          Try
         AyudaEntidad(actxaNroDocProveedor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
End Sub

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
                     m_etran_combustibleconsumo.ENTID_CodigoProveedor = Ayuda.Respuesta.Rows(0)("Codigo")
                     actxaDescProveedor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                     If managerEntidades.Cargar(m_etran_combustibleconsumo.ENTID_CodigoProveedor, EEntidades.TipoInicializacion.Proveedor) Then
                        
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


Private Sub actxaNroDocProveedor_KeyDown( sender As Object,  e As KeyEventArgs) Handles actxaNroDocProveedor.KeyDown
         Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocProveedor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocProveedor.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocProveedor.Text, EEntidades.TipoInicializacion.Direcciones) Then
                     actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     m_etran_combustibleconsumo.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                     
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
                     m_etran_combustibleconsumo.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                  End If
            End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
      End Try
   End Sub

Private Sub txtdescripcion_KeyDown( sender As Object,  e As KeyEventArgs) Handles txtdescripcion.KeyDown
         If e.KeyData = Keys.Enter Then
         actxnProdCantidad.Focus()
         End If
End Sub

Private Sub actxnProdCantidad_KeyDown( sender As Object,  e As KeyEventArgs) Handles actxnProdCantidad.KeyDown
         If e.KeyData = Keys.Enter Then
         actxnProdprecio.Focus()
         End If
End Sub

Private Sub actxnProdprecio_KeyDown( sender As Object,  e As KeyEventArgs) Handles actxnProdprecio.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim b As Decimal= actxnProdprecio.Text
            Dim a As Decimal = actxnProdCantidad.Text
            Dim c As Decimal =a*b
        actxnSubImporte.Text=c

         actxnSubImporte.Focus()
         End If
End Sub


Private Sub txtOpcion_KeyDown( sender As Object,  e As KeyEventArgs) Handles txtOpcion.KeyDown
         Try
         Select Case e.KeyData
            Case Keys.Enter
               If Not m_modArticulo Then
                  
                  addDetalle()
                  setProducto(False)
                  m_modArticulo = False
                 
               Else
                  'ModificarArticulo()
                  Label2.Focus()
               End If
               c1grdDetalle.AutoSizeCols()
               Me.KeyPreview = True
            
            Case Else

         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede procesar", ex)
      End Try
End Sub
Private Function addDetalle() As Boolean
      Try
        
        dim _detDocumentoDetalle as New ETRAN_DocumentosDetalle
         
         _detDocumentoDetalle.DCDET_Cantidad = actxnProdCantidad.Text
         _detDocumentoDetalle.DCDET_Descripcion = txtdescripcion.Text
         _detDocumentoDetalle.DCDET_Importe = actxnProdprecio.Text
         _detDocumentoDetalle.DCDET_Precio= actxnProdprecio.Text
         _detDocumentoDetalle.DCDET_SubImporte = Math.Round(actxnSubImporte.Text/1.18,2)
         _detDocumentoDetalle.DCDET_Item= managerGenerarDocumentoDetalle.ListTRAN_DocumentosDetalle.Count + 1
         _detDocumentoDetalle.DCDET_Importe=actxnSubImporte.Text

         '   managerGenerarDocumentoDetalle.ListTRAN_DocumentosDetalle.Add(_detDocumentoDetalle)
         m_btran_documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle=managerGenerarDocumentoDetalle.ListTRAN_DocumentosDetalle
         m_btran_documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle.Add(_detDocumentoDetalle)
       bs_detabas_Documentos.ResetBindings(True)
            


          
         bs_detabas_Documentos = New BindingSource
         bs_detabas_Documentos.DataSource = managerGenerarDocumentoDetalle.ListTRAN_DocumentosDetalle
         c1grdDetalle.DataSource=bs_detabas_Documentos
         bnavProductos.BindingSource = bs_detabas_Documentos
            
            
            a +=actxnSubImporte.Text
            txtsubimporte.Text=a/1.18:txtsubimporte.Formatear()
            txtigv.Text=a-txtsubimporte.Text:txtigv.Formatear()
            txttotalpagar.Text = a : txttotalpagar.Formatear()
            '_M
            If txtDescuentoGlobal.Text > 0 Then

                txtTotalDscto.Text = a * (txtDescuentoGlobal.Text / 100) : txtTotalDscto.Formatear()
                txtTotalFinal.Text = a - txtTotalDscto.Text : txtTotalFinal.Formatear()
            Else
                If txtTotalDscto.Text > 0 Then

                    txtTotalFinal.Text = a - txtTotalDscto.Text : txtTotalFinal.Formatear()
                Else
                    txtTotalDscto.Text = 0.0
                    txtTotalFinal.Text = txttotalpagar.Text : txtTotalFinal.Formatear()
                End If

            End If
            importe = txttotalpagar.Text

            Return True
        Catch ex As Exception
            Throw ex
        End Try
   End Function
     
Private Sub setProducto(ByVal x_opcion As Boolean)
      Try
         If x_opcion Then
          
         Else
            actxnProdCantidad.Text = "0.00"
            txtdescripcion.Clear()
            actxnProdprecio.Text = "0.00"
            actxnSubImporte.Text = "0.00"
            txtdescripcion.Focus()
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
    Private sub limpiar()
        actxaNroDocProveedor.Clear()
        actxaDescProveedor.Clear()
        txtSerie.Clear()
        actxnNumero.Clear()
        txtsubimporte.Formatear()
        txtigv.Formatear()
        txttotalpagar.formatear()
    End Sub

    Private Sub actxnSubImporte_KeyDown_1( sender As Object,  e As KeyEventArgs) Handles actxnSubImporte.KeyDown
         If e.KeyData = Keys.Enter Then
         txtOpcion.Focus()
         End If
    End Sub

    Private Sub acTool_ACBtnGrabar_Click( sender As Object,  e As EventArgs) Handles acTool.ACBtnGrabar_Click
         Dim msg As String = ""
      Try
         m_etran_combustibleconsumo.SUCUR_Id = GApp.ESucursal.SUCUR_Id
         If m_etran_combustibleconsumo.COMCO_PrecioGalon = 0 Then
            If m_etran_combustibleconsumo.COMCO_GalonesConsumidos > 0 Then
               m_etran_combustibleconsumo.COMCO_PrecioGalon = m_etran_combustibleconsumo.COMCO_Total / m_etran_combustibleconsumo.COMCO_GalonesConsumidos
            End If
         End If
       If m_etran_combustibleconsumo.Nuevo Then m_etran_combustibleconsumo.COMCO_Id = managerTRAN_CombustibleConsumo.getCorrelativo()
            m_etran_combustibleconsumo.ZONAS_Codigo = GApp.Zona
            managerTRAN_CombustibleConsumo.setTRAN_CombustibleConsumo(m_etran_combustibleconsumo)
            m_etran_combustibleconsumo.Instanciar(ACEInstancia.Nuevo)
            If managerTRAN_CombustibleConsumo.Guardar_doc(GApp.Usuario, True, 1,m_btran_documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle) Then
               'tabMantenimiento.SelectedTab = tabBusqueda
               'acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               'Select Case m_opcion
               '   Case Origen.Viajes
               '      Me.DialogResult = Windows.Forms.DialogResult.OK
               '      Me.Close()
               '   Case Else
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
 
                Me.Close()
                'Dim frm As New PConsumoCombustible()
                'frm.AcFecha.ACDtpFecha_De.Value=dtpFecViaje.Value
                'frm.AcFecha.ACDtpFecha_A.Value=dtpFecViaje.Value
                'frm.cargar_documentos()   
                formatearGrilla()
                limpiar()
                'End Select

            Else 

            Dim docu As String
           
            docu=m_etran_combustibleconsumo.TRAN_Documentos.DOCUS_Codigo
          
            Dim frmCC As New ConsultasViajes(docu,Nothing)
          frmCC.ShowDialog()
            'If frmCC.ShowDialog() = Windows.Forms.DialogResult.OK Then
          
            'End If


            End If

      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
      End Try
    End Sub

    Private Sub cargar()
     Try
         If Not IsNothing(bs_btran_vehiculos) Then
            If bs_btran_vehiculos.Current IsNot Nothing Then
               Dim x_codigo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
               m_etran_combustibleconsumo = New ETRAN_CombustibleConsumo()
               m_etran_combustibleconsumo.TRAN_Documentos = New ETRAN_Documentos
               m_etran_combustibleconsumo.Instanciar(ACEInstancia.Nuevo)
               m_etran_combustibleconsumo.VEHIC_Id = x_codigo
               AsignarBinding()
               acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Nuevo)
            End If
         Else
            Select Case m_opcion
               Case Origen.Viajes
                  m_etran_combustibleconsumo = New ETRAN_CombustibleConsumo()
                  m_etran_combustibleconsumo.Instanciar(ACEInstancia.Nuevo)
                  m_etran_combustibleconsumo.TRAN_Documentos = New ETRAN_Documentos
                  m_etran_combustibleconsumo.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)
                  AsignarBinding()
                  acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Nuevo)
            End Select
         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Sub




       Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         
         m_listBindHelper.Add(ACBindHelper.ACBind(actxaNroDocProveedor, "Text", m_etran_combustibleconsumo, "ENTID_CodigoProveedor"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txttotalpagar, "Text", m_etran_combustibleconsumo, "COMCO_Total"))
         If m_etran_combustibleconsumo.COMCO_Fecha.Year < 1700 Then m_etran_combustibleconsumo.COMCO_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecViaje, "Value", m_etran_combustibleconsumo, "COMCO_Fecha"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbGuia, "SelectedValue", m_etran_combustibleconsumo.TRAN_Documentos, "TIPOS_CodTipoDocumento"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoMoneda, "SelectedValue", m_etran_combustibleconsumo, "TIPOS_CodTipoMoneda"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtSerie, "Text", m_etran_combustibleconsumo.TRAN_Documentos, "DOCUS_Serie"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", m_etran_combustibleconsumo.TRAN_Documentos, "DOCUS_Numero"))
 
            
      Catch ex As Exception
         Throw ex
      End Try
   End Sub



    Private Sub txtOpcion_TextChanged(sender As Object, e As EventArgs) Handles txtOpcion.TextChanged

    End Sub

    Private Sub txtTotalDscto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalDscto.KeyDown
        If e.KeyData = Keys.Enter Then

            txtTotalFinal.Text = txttotalpagar.Text - txtTotalDscto.Text ': txtTotalFinal.Formatear()

            txtTotalFinal.Focus()
        End If
    End Sub

End Class