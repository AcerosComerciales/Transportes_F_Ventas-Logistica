Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports C1.Win.C1FlexGrid
Imports ACBVentas
Imports ACEVentas
Imports CrystalDecisions.Shared.Json

Public Class PConsumoCombustible
#Region " Variables "
   Private managerTRAN_Vehiculos As BTRAN_Vehiculos
   Private managerTRAN_CombustibleConsumo As BTRAN_CombustibleConsumo
   Private managerEntidades As BEntidades
    Private managerReportes as New BTRAN_CombustibleConsumo

     private m_btran_documentos As New BTRAN_Documentos()
    Private m_listBindHelper As List(Of ACBindHelper)
   Private m_etran_combustibleconsumo As ETRAN_CombustibleConsumo
   Private bs_btran_vehiculos As BindingSource
    private bs_compras as BindingSource
   Private m_opcion As Origen
    Dim _i As Integer = 1
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
        m_btran_documentos = NEW BTRAN_Documentos()
      Try
         setInicio(Origen.Normal, DateTime.Now, 0)
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

   Public Sub New(ByVal x_comco_id As Long)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         setInicio(Origen.Viajes, DateTime.Now, 0)
         If managerTRAN_CombustibleConsumo.ObtConCombustible(x_comco_id) Then
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)
            m_etran_combustibleconsumo = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo
            AsignarBinding()
            actxaNroDocProveedor.Text = m_etran_combustibleconsumo.ENTID_CodigoProveedor
            actxaDescProveedor.Text = m_etran_combustibleconsumo.ENTID_RazonSocial
            setInstancia(ACUtilitarios.ACSetInstancia.Modificado)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub setInicio(ByVal x_opcion As Origen, ByVal x_fecha As DateTime, ByVal x_viajes_id As Long)
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda
         formatearGrilla()
         cargarCombos(x_viajes_id)
         managerTRAN_Vehiculos = New BTRAN_Vehiculos
         managerTRAN_CombustibleConsumo = New BTRAN_CombustibleConsumo(GApp.Aplicacion, GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
         managerEntidades = New BEntidades

         m_opcion = x_opcion
         Select Case x_opcion
            Case Origen.Normal
                    acTool.ACBtnNuevoEnabled = False
               dtpComFecha.Value = x_fecha
            Case Origen.Viajes
               acTool_ACBtnNuevo_Click(Nothing, Nothing)
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               dtpComFecha.Value = x_fecha
               dtpFecViaje.Value = x_fecha
               cmbComModoPago.SelectedIndex = 0
               cmbComTipoCombustible.SelectedIndex = 0
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

#End Region

    private sub cargar_documentos()
        formatearGrilla()
            
            _i=1
        
            If managerReportes.doc_compra(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date.AddDays(1),actxaNroDocProveedor.Text) Then

            c1grdDocsPago.Rows.Count = managerReportes.DTTabla_com.Rows.Count + 1
         
           
            For Each item As DataRow In managerReportes.DTTabla_com.Rows
               c1grdDocsPago.Rows(_i)("Documento") = item("Documento")
               c1grdDocsPago.Rows(_i)("ENTID_Codigo") = item("Entid_Codigo")
               c1grdDocsPago.Rows(_i)("ENTID_RazonSocial") = item("ENTID_RazonSocial")
               c1grdDocsPago.Rows(_i)("DOCUS_Importe") = item("DOCUS_Importe")
               c1grdDocsPago.Rows(_i)("DOCUS_ImporteIGV") = item("DOCUS_ImporteIGV")
               c1grdDocsPago.Rows(_i)("DOCUS_TotalPago") = item("DOCUS_TotalPago")
               c1grdDocsPago.Rows(_i)("DOCUS_Fecha") = item("DOCUS_Fecha")
                c1grdDocsPago.Rows(_i)("DOCUS_Codigo") = item("DOCUS_Codigo")
                c1grdDocsPago.Rows(_i)("DOCUS_Serie") = item("DOCUS_Serie")
                c1grdDocsPago.Rows(_i)("DOCUS_Numero") = item("DOCUS_Numero")
              _i += 1
             
            Next
            c1grdDocsPago.AutoSizeCols()
         End If

    End Sub


#Region " Metodos "
#Region " Utilitarios "
    ' <summary>
    ' Dar Formato a la grilla de busqueda
    ' </summary>
    ' <remarks></remarks>
    Private Sub formatearGrilla()
        Dim index As Integer = 1
        Try
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 8, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "VEHIC_Codigo", "VEHIC_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Sucursal", "SUCUR_Nombre", "SUCUR_Nombre", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Vehiculo", "TIPOS_Vehiculo", "TIPOS_Vehiculo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Marca", "TIPOS_Marca", "TIPOS_Marca", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Modelo", "VEHIC_Modelo", "VEHIC_Modelo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Adq.", "VEHIC_FecAdquisicion", "VEHIC_FecAdquisicion", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1

            c1grdBusqueda.AllowEditing = False
            c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
            c1grdBusqueda.SelectionMode = SelectionModeEnum.Row


            index = 1

            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDocsPago, 1, 1, 11, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Documento", "Documento", "Documento", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "RUC", "Entid_Codigo", "Entid_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Proveedor", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Sub Total", "DOCUS_Importe", "DOCUS_Importe", 150, True, False, "System.Decimal", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Igv", "DOCUS_ImporteIGV", "DOCUS_ImporteIGV", 150, True, False, "System.Decimal", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Total", "DOCUS_TotalPago", "DOCUS_TotalPago", 150, True, False, "System.Decimal", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Fecha", "DOCUS_Fecha", "DOCUS_Fecha", 150, True, False, "System.DateTime", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Doc", "DOCUS_Codigo", "DOCUS_Codigo", 150, False, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "serie", "DOCUS_Serie", "DOCUS_Serie", 150, False, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Doc", "DOCUS_Numero", "DOCUS_Numero", 150, False, False, "System.String", "") : index += 1

            c1grdDocsPago.AllowEditing = False
            c1grdDocsPago.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdDocsPago.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdDocsPago.Styles.Highlight.BackColor = Color.Gray
            c1grdDocsPago.SelectionMode = SelectionModeEnum.Row



        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
        End Try
    End Sub

    Private Sub cargarCombos(ByVal x_viaje_id As Long)
        Try
            ACUtilitarios.ACCargaCombo(cmbComTipoCombustible, Colecciones.Tipos(ETipos.MyTipos.TipoCombustible), "TIPOS_Descripcion", "TIPOS_Codigo")
            ACUtilitarios.ACCargaCombo(cmbComModoPago, Colecciones.Tipos(ETipos.MyTipos.ModoPago), "TIPOS_Descripcion", "TIPOS_Codigo")
            ACUtilitarios.ACCargaCombo(cmbGuia, Colecciones.TiposDocFacturacion(), "TIPOS_Descripcion", "TIPOS_Codigo", ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura))
            ACUtilitarios.ACCargaCombo(cmbTipoMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")

            Dim _badministracionviajes As New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            _badministracionviajes.TRAN_Viajes = New ETRAN_Viajes
            _badministracionviajes.TRAN_Viajes.VIAJE_Id = x_viaje_id
            _badministracionviajes.GastosViajeInicial()
            ACUtilitarios.ACCargaCombo(cmbPendiente, _badministracionviajes.ListTESO_Caja, "CAJA_GlosaImporte", "RECIB_Codigo")



        Catch ex As Exception
            Throw ex
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
                actxaDescProveedor.Enabled = True
                actxaNroDocProveedor.Enabled = True
                btnNueTransportista.Enabled = False
                lblProveedor.Enabled = False
                GroupBox1.Enabled = True
                ACFramework.ACUtilitarios.ACSetControl(pnlDatos, False, ACUtilitarios.TipoPropiedad.ACEnabled)
            'txtCodigo.Enabled = False

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
            bs_btran_vehiculos = New BindingSource()
            bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos
            c1grdBusqueda.DataSource = bs_btran_vehiculos
            bnavBusqueda.BindingSource = bs_btran_vehiculos


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cargar_com()
        Try
            bs_compras = New BindingSource()
            bs_compras.DataSource = c1grdDocsPago.DataSource

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
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbComTipoCombustible, "SelectedValue", m_etran_combustibleconsumo, "TIPOS_CodTipoCombustible"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnComPrecGalon, "Text", m_etran_combustibleconsumo, "COMCO_PrecioGalon"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotal, "Text", m_etran_combustibleconsumo, "COMCO_Total"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnKilometraje, "Text", m_etran_combustibleconsumo, "COMCO_Kilometraje"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnComLitConsumidos, "Text", m_etran_combustibleconsumo, "COMCO_GalonesConsumidos"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtcoigo_vale, "Text", m_etran_combustibleconsumo, "COMCO_CodigoVale"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbComModoPago, "SelectedValue", m_etran_combustibleconsumo, "TIPOS_CodModoPago"))
            If m_etran_combustibleconsumo.COMCO_Fecha.Year < 1700 Then m_etran_combustibleconsumo.COMCO_Fecha = DateTime.Now
            m_listBindHelper.Add(ACBindHelper.ACBind(dtpComFecha, "Value", m_etran_combustibleconsumo, "COMCO_Fecha"))
            If m_etran_combustibleconsumo.COMCO_FechaViaje.Year < 1700 Then m_etran_combustibleconsumo.COMCO_FechaViaje = DateTime.Now
            m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecViaje, "Value", m_etran_combustibleconsumo, "COMCO_FechaViaje"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbGuia, "SelectedValue", m_etran_combustibleconsumo, "TIPOS_CodTipoDocumento"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoMoneda, "SelectedValue", m_etran_combustibleconsumo, "TIPOS_CodTipoMoneda"))
            m_listBindHelper.Add(ACBindHelper.ACBind(chkCCaja, "Checked", m_etran_combustibleconsumo, "COMCO_CCaja"))

            m_listBindHelper.Add(ACBindHelper.ACBind(cmbGuia, "SelectedValue", m_etran_combustibleconsumo.TRAN_Documentos, "TIPOS_CodTipoDocumento"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtSerie, "Text", m_etran_combustibleconsumo.TRAN_Documentos, "DOCUS_Serie"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", m_etran_combustibleconsumo.TRAN_Documentos, "DOCUS_Numero"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtnumeroentero, "Text", m_etran_combustibleconsumo.TRAN_Documentos, "DOCUS_Codigo"))
        Catch ex As Exception
            Throw ex
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
                    tabMantenimiento.SelectedTab = tabDatos
                    acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
                End If
            Else
                Select Case m_opcion
                    Case Origen.Viajes
                        m_etran_combustibleconsumo = New ETRAN_CombustibleConsumo()
                        m_etran_combustibleconsumo.Instanciar(ACEInstancia.Nuevo)
                        m_etran_combustibleconsumo.TRAN_Documentos = New ETRAN_Documentos
                        m_etran_combustibleconsumo.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)
                        AsignarBinding()
                        tabMantenimiento.SelectedTab = tabDatos
                        acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
                End Select
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
         If managerTRAN_Vehiculos.Busqueda(getCampo(), x_cadena) Then
            acTool.ACBtnNuevoEnabled = True
            acTool.ACBtnEliminarEnabled = True
            acTool.ACBtnModificarEnabled = True
         Else
            acTool.ACBtnNuevoEnabled = False
            acTool.ACBtnEliminarEnabled = False
            acTool.ACBtnModificarEnabled = False
         End If
         cargarDatos()
         Return acTool.ACBtnModificarEnabled
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
                        lblTipoCombustible.Focus()
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
                     m_etran_combustibleconsumo.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                  End If
            End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
#Region " Tool Bar "
   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         RemoveHandler actxnComLitConsumidos.LostFocus, AddressOf actxnComLitConsumidos_LostFocus
         tabMantenimiento.SelectedTab = tabDatos
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         cargar()
         chkCCaja.Checked = True
         AddHandler actxnComLitConsumidos.LostFocus, AddressOf actxnComLitConsumidos_LostFocus
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Consumo de Combustible", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         For Each Item As ACBindHelper In m_listBindHelper
            Item.ACUnBind()
         Next
         Select Case m_opcion
            Case Origen.Viajes
               Me.DialogResult = Windows.Forms.DialogResult.Cancel
               Me.Close()
         End Select
         Me.KeyPreview = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Consumo de Combustible", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         m_etran_combustibleconsumo.SUCUR_Id = GApp.ESucursal.SUCUR_Id
            If m_etran_combustibleconsumo.COMCO_PrecioGalon = 0 Then
                If m_etran_combustibleconsumo.COMCO_GalonesConsumidos > 0 Then
                    m_etran_combustibleconsumo.COMCO_PrecioGalon = m_etran_combustibleconsumo.COMCO_Total / m_etran_combustibleconsumo.COMCO_GalonesConsumidos
                End If
            End If
            'Validando nos datos
            If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
            If m_etran_combustibleconsumo.Nuevo Then m_etran_combustibleconsumo.COMCO_Id = managerTRAN_CombustibleConsumo.getCorrelativo()
            m_etran_combustibleconsumo.ZONAS_Codigo = GApp.Zona
            managerTRAN_CombustibleConsumo.setTRAN_CombustibleConsumo(m_etran_combustibleconsumo)
            

          
            
            If managerTRAN_CombustibleConsumo.Guardar_todo(GApp.Usuario, True, cmbPendiente.SelectedValue) Then
               tabMantenimiento.SelectedTab = tabBusqueda 'aca cambia a tab busqueda =======================> busquda frank 06-11-2025
                   '=================================BANDERA AGREGADO 07-11-2025 ==========================================================================
                    globales_.x_BanderGrabarCombustible = True 'Bandera creado para guardar 
                        '===========================================================================================================

               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               Select Case m_opcion
                  Case Origen.Viajes
                     Me.DialogResult = Windows.Forms.DialogResult.OK
                     Me.Close()
                  Case Else
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
               End Select
                    
            Else 

            Dim docu As String
           
            docu=m_etran_combustibleconsumo.TRAN_Documentos.DOCUS_Codigo
          
            Dim frmCC As New ConsultasViajes(docu,Nothing)
          frmCC.ShowDialog()
            'If frmCC.ShowDialog() = Windows.Forms.DialogResult.OK Then
          
            'End If


            End If



         Else
                If m_etran_combustibleconsumo.Nuevo Then m_etran_combustibleconsumo.COMCO_Id = managerTRAN_CombustibleConsumo.getCorrelativo()
                m_etran_combustibleconsumo.ZONAS_Codigo = GApp.Zona
                managerTRAN_CombustibleConsumo.setTRAN_CombustibleConsumo(m_etran_combustibleconsumo)




                If managerTRAN_CombustibleConsumo.Guardar_todo(GApp.Usuario, True, cmbPendiente.SelectedValue) Then
                    tabMantenimiento.SelectedTab = tabBusqueda '======================2. MANDA ACCCION TAB FRANK===================================
                    '=============MANDA ACCION PARA LOS TABS =============07-11-2025=============================================================

                    globales_.x_BanderGrabarCombustible = True
                    globales_.x_BanderGrabarAdBlue = False 
                    '====================================================================================================================
                    acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                    Select Case m_opcion
                        Case Origen.Viajes
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()
                        Case Else
                            ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                    End Select

                Else

                    Dim docu As String

                    docu = m_etran_combustibleconsumo.TRAN_Documentos.DOCUS_Codigo

                    Dim frmCC As New ConsultasViajes(docu, Nothing)
                    frmCC.ShowDialog()
                    'If frmCC.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    'End If


                End If

                ' ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No puede guardar, por que hay campos obligatorios vacios: " + msg)
            End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede grabar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
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

   'Private Sub txtSerie_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress
   '   If Char.IsDigit(e.KeyChar) Then
   '      e.Handled = False
   '   ElseIf Char.IsControl(e.KeyChar) Then
   '      e.Handled = False
   '   Else
   '      e.Handled = True
   '   End If
   'End Sub

   Private Sub actxaNroDocProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocProveedor.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocProveedor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocProveedor.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocProveedor.Text, EEntidades.TipoInicializacion.Direcciones) Then
                     actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     m_etran_combustibleconsumo.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                     lblTipoCombustible.Focus()
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

   Private Sub actxnComLitConsumidos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         If Convert.ToDecimal(actxnComPrecGalon.Text) = 0 And Convert.ToDecimal(actxnComLitConsumidos.Text) <> 0 Then
            actxnComPrecGalon.Text = Math.Round(Convert.ToDecimal(actxnTotal.Text) / Convert.ToDecimal(actxnComLitConsumidos.Text), 2, MidpointRounding.AwayFromZero)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error calculando el precio por galon", ex)
      End Try
   End Sub
#End Region

   Private Sub actxnNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxnNumero.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            Me.KeyPreview = False
            acTool.Focus()
            


            acTool.ACBtnGrabar.Select()
         End If
      Catch ex As Exception

      End Try
   End Sub

   Private Sub actxnNumero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles actxnNumero.KeyPress
    
   End Sub


Private Sub chkdocus_CheckedChanged( sender As Object,  e As EventArgs) Handles chkdocus.CheckedChanged
            If(chkdocus.Checked)
            GroupBox1.Enabled=True
            'dtpComFecha.Enabled=True
            'cmbGuia.Enabled=True
            'txtSerie.Enabled=True
            'actxnNumero.Enabled=True
            Else 
            GroupBox1.Enabled=false
            'dtpComFecha.Enabled=False
            'cmbGuia.Enabled=False
            'txtSerie.Enabled=False
            'actxnNumero.Enabled=False
            End If
End Sub

Private Sub tsbtnNuevoTPago_Click( sender As Object,  e As EventArgs) Handles tsbtnNuevoTPago.Click
        Dim docu As String
           
            docu=m_etran_combustibleconsumo.TRAN_Documentos.DOCUS_Codigo
          
            Dim frmCC As New ConsultasViajes(docu,"tpdetalle")
          frmCC.ShowDialog()
End Sub

Private Sub tsbtnAgregarTPago_Click( sender As Object,  e As EventArgs) Handles tsbtnAgregarTPago.Click

        'A PRUEBA para visualizar los viajes 
        'Dim frmCC As New ConsultasViajes(m_etran_combustibleconsumo.TRAN_Documentos.DOCUS_Codigo,"tpbusqueda")
        'frmCC.ShowDialog()

        cargar_documentos()



End Sub

Private Sub c1grdDocsPago_MouseClick( sender As Object,  e As MouseEventArgs) Handles c1grdDocsPago.MouseClick
 
End Sub

Private Sub c1grdDocsPago_Click( sender As Object,  e As EventArgs) Handles c1grdDocsPago.Click
         Dim index As Integer
        Dim fac as String
        Dim pro as String
        Try

        For index = 1 To c1grdDocsPago.Row.ToString

        
        actxtotal.Text = c1grdDocsPago.Rows(index).Item(6).ToString()
        fac=c1grdDocsPago.Rows(index).Item(8).ToString()
        pro=c1grdDocsPago.Rows(index).Item(2).ToString()
        txtSerie.Text =c1grdDocsPago.Rows(index).Item(9).ToString()
        actxnNumero.Text=c1grdDocsPago.Rows(index).Item(10).ToString()
        txtnumeroentero.Text=c1grdDocsPago.Rows(index).Item(8).ToString()
        Next
            
            _i=1
             If managerTRAN_CombustibleConsumo.doc_compra_validar(fac,pro) Then
                dim consumos as Decimal
                Dim row As DataRow = managerTRAN_CombustibleConsumo.DTTabla_com_val.Rows(managerTRAN_CombustibleConsumo.DTTabla_com_val.Rows.Count - 1)
            consumos = CStr(row(6))
         actxtsub.text=actxtotal.Text- consumos
             else
          
             actxtsub.text=actxtotal.Text
       
            End If


        Catch e1 As Exception
        End Try
   
End Sub

Private Sub c1grdDocsPago_RowColChange( sender As Object,  e As EventArgs) Handles c1grdDocsPago.RowColChange
        'Dim index As Integer
        'Dim fac as String
        'Dim pro as String
        'Try

        'For index = 1 To c1grdDocsPago.Row.ToString

        
        'actxtotal.Text = c1grdDocsPago.Rows(index).Item(6).ToString()
        'fac=c1grdDocsPago.Rows(index).Item(8).ToString()
        'pro=c1grdDocsPago.Rows(index).Item(2).ToString()
        'txtSerie.Text =c1grdDocsPago.Rows(index).Item(9).ToString()
        'actxnNumero.Text=c1grdDocsPago.Rows(index).Item(10).ToString()
        'txtnumeroentero.Text=c1grdDocsPago.Rows(index).Item(8).ToString()
        'Next
            
        '    _i=1
        '     If managerTRAN_CombustibleConsumo.doc_compra_validar(fac,pro) Then
        '        dim consumos as Decimal
        '        Dim row As DataRow = managerTRAN_CombustibleConsumo.DTTabla_com_val.Rows(managerTRAN_CombustibleConsumo.DTTabla_com_val.Rows.Count - 1)
        '    consumos = CStr(row(6))
        ' actxtsub.text=actxtotal.Text- consumos
        '     else
          
        '     actxtsub.text=actxtotal.Text
       
        '    End If


        'Catch e1 As Exception
        'End Try

End Sub

    Private Sub acTool_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles acTool.ItemClicked

    End Sub

    Private Sub PConsumoCombustible_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkCCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chkCCaja.CheckedChanged

    End Sub
End Class
