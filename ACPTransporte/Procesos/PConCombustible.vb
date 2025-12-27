Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports C1.Win.C1FlexGrid
Imports ACBVentas
Imports ACEVentas

Public Class PConCombustible
#Region " Variables "
   Private managerTRAN_Vehiculos As BTRAN_Vehiculos
   Private managerTRAN_CombustibleConsumo As BTRAN_CombustibleConsumo
   Private managerEntidades As BEntidades

   Private m_listBindHelper As List(Of ACBindHelper)
   Private bs_btran_vehiculos As BindingSource
   Private m_opcion As Origen

   Private bs_consumos As BindingSource
   Private bs_busconsumos As BindingSource

    Private m_etran_combustibleconsumo As ETRAN_CombustibleConsumo

   Private m_fecha As DateTime

   Enum Origen
      Registro
      Modificar
   End Enum

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         setInicio(Origen.Registro)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Public Sub New(ByVal x_opcion As Origen)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         setInicio(x_opcion)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub setInicio(ByVal x_opcion As Origen)
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         formatearGrilla()
         cargarCombos()
         managerTRAN_Vehiculos = New BTRAN_Vehiculos
         managerTRAN_CombustibleConsumo = New BTRAN_CombustibleConsumo(GApp.PuntoVenta, GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
         managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo = New ETRAN_CombustibleConsumo
         managerEntidades = New BEntidades
         m_opcion = x_opcion
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
         Select Case x_opcion
            Case Origen.Registro
               acTool.ACBtnNuevoEnabled = False
               tabMantenimiento.SelectedTab = tabBusqueda
               Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACFuelRed_16x16.GetHicon)
               Me.Text = "Busqueda de Vehiculos"
               AcPanelCaption1.Text = "Registro de Consumo de Combustible"
            Case Origen.Modificar
               tabMantenimiento.SelectedTab = tabBusConsumos
               Me.KeyPreview = True
               Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACFuelBlack_16x16.GetHicon)
               Me.Text = "Busqueda de Consumo de Combustible"
               AcPanelCaption1.Text = "Modificar Registro de Consumo de Combustible"
            Case Else
               setInicio(Origen.Registro)
         End Select
         acTool.ACBtnEliminarEnabled = False
         acTool.ACBtnModificarEnabled = False
         m_fecha = managerTRAN_CombustibleConsumo.GetFecha()
      Catch ex As Exception
         Throw ex
      End Try
   End Sub


#End Region

#Region " Metodos "
#Region " Utilitarios "
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 7, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "VEHIC_Codigo", "VEHIC_Codigo", 150, True, False, "System.String", "") : index += 1
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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdConsumos, 1, 1, 13, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Codigo", "COMCO_Id", "COMCO_Id", 150, True, False, "System.String", "000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Galones", "COMCO_GalonesConsumidos", "COMCO_GalonesConsumidos", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "K.M.", "COMCO_Kilometraje", "COMCO_Kilometraje", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Fecha", "COMCO_Fecha", "COMCO_Fecha", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Fecha Consumo", "COMCO_FechaConsumo", "COMCO_FechaConsumo", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Conductor", "Conductor", "Conductor", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Documento", "CompDocumento", "CompDocumento", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Proveedor", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Importe", "COMCO_Total", "COMCO_Total", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdConsumos, index, "Considerar en Caja", "COMCO_CCaja", "COMCO_CCaja", 150, True, False, "System.Boolean", "") : index += 1

         c1grdConsumos.AllowEditing = False
         c1grdConsumos.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdConsumos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdConsumos.Styles.Highlight.BackColor = Color.Gray
         c1grdConsumos.SelectionMode = SelectionModeEnum.Row

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusConsumos, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "Codigo", "COMCO_Id", "COMCO_Id", 150, True, False, "System.String", "000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "Conductor", "Conductor", "Conductor", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "Proveedor", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "Galones", "COMCO_GalonesConsumidos", "COMCO_GalonesConsumidos", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "K.M.", "COMCO_Kilometraje", "COMCO_Kilometraje", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "Fecha", "COMCO_Fecha", "COMCO_Fecha", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "Fecha Consumo", "COMCO_FechaConsumo", "COMCO_FechaConsumo", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusConsumos, index, "Importe", "COMCO_Total", "COMCO_Total", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         c1grdBusConsumos.AllowEditing = False
         c1grdBusConsumos.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusConsumos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusConsumos.Styles.Highlight.BackColor = Color.Gray
         c1grdBusConsumos.SelectionMode = SelectionModeEnum.Row
        
       

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

    private sub cargar_grillaDocs
          Dim index As Integer = 1

         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDocsPago, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Documento", "Documento", "Documento", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "RUC", "Entid_Codigo", "Entid_Codigo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Proveedor", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Sub Total", "DOCUS_Importe", "DOCUS_Importe", 150, True, False, "System.Decimal", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Igv", "DOCUS_ImporteIGV", "DOCUS_ImporteIGV", 150, True, False, "System.Decimal", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Total", "DOCUS_TotalPago", "DOCUS_TotalPago", 150, True, False, "System.Decimal", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Fecha", "DOCUS_Fecha", "DOCUS_Fecha", 150, True, False, "System.DateTime", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Doc", "DOCUS_Codigo", "DOCUS_Codigo", 150, false, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "serie", "DOCUS_Serie", "DOCUS_Serie", 150, false, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Doc", "DOCUS_Numero", "DOCUS_Numero", 150, false, False, "System.String", "") : index += 1

         c1grdDocsPago.AllowEditing = False
         c1grdDocsPago.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDocsPago.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDocsPago.Styles.Highlight.BackColor = Color.Gray
         c1grdDocsPago.SelectionMode = SelectionModeEnum.Row


    End Sub

   Private Sub cargarCombos()
      Try
         ACUtilitarios.ACCargaCombo(cmbComTipoCombustible, Colecciones.Tipos(ETipos.MyTipos.TipoCombustible), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbTipoMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbGuia, Colecciones.TiposDocMerTransito(), "TIPOS_Descripcion", "TIPOS_Codigo", ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)
      Select Case m_opcion
         Case Origen.Registro
            tabMantenimiento.SelectedTab = tabBusqueda
            Select Case _opcion
               Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
                  ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
                  ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)

                  'txtCodigo.Enabled = False
               Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
                  ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
                  actxaDescProveedor.Enabled = False
                  actxaNroDocProveedor.Enabled = False
                  btnNueProveedor.Enabled = False
                  lblProveedor.Enabled = False
               Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

               Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

            End Select
            actxaCodVehiculo.Enabled = False
            actxaDescVehiculo.Enabled = False
            acTool.ACBtnModificarVisible = False
         Case Origen.Modificar
            tabMantenimiento.SelectedTab = tabBusConsumos
            acTool.ACBtnNuevoVisible = False
            Select Case _opcion
               Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
                  ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
                  ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
                  actxaCodConductor.Enabled = False
                  actxaDescConductor.Enabled = False
                  actxaCodVehiculo.Enabled = False
                  actxaDescVehiculo.Enabled = False
                  actxaDescProveedor.Enabled = False
                  actxaNroDocProveedor.Enabled = False
                  actxnNumero.Enabled = False
                  cmbComTipoCombustible.Enabled = False
            End Select
         Case Else
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
      End Select
      acTool.ACBtnVolverVisible = False
   End Sub
#End Region

#Region " Cargar Datos "
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


   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbComTipoCombustible, "SelectedValue", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo, "TIPOS_CodTipoCombustible"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnComPrecGalon, "Text", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo, "COMCO_PrecioGalon"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotal, "Text", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo, "COMCO_Total"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnComLitConsumidos, "Text", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo, "COMCO_GalonesConsumidos"))

         If managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_Fecha.Year < 1700 Then managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_Fecha = DateTime.Now

         If managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_Fecha.Year < 1700 Then managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecViaje, "Value", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo, "COMCO_Fecha"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoMoneda, "SelectedValue", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo, "TIPOS_CodTipoMoneda"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo, "COMCO_CodigoVale"))

         If managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_FechaConsumo.Year < 1700 Then managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_FechaConsumo = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecConsumo, "Value", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo, "COMCO_FechaConsumo"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxnKilometraje, "Text", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo, "COMCO_Kilometraje"))

         If IsNothing(managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.TRAN_Documentos) Then
            managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.TRAN_Documentos = New ETRAN_Documentos
         End If
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbGuia, "SelectedValue", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.TRAN_Documentos, "TIPOS_CodTipoDocumento"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtSerie, "Text", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.TRAN_Documentos, "DOCUS_Serie"))
         m_listBindHelper.Add(ACBindHelper.ACBind(AcTextBoxNumerico1, "Text", managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.TRAN_Documentos, "DOCUS_Numero"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtnumeroentero,"Text",managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.TRAN_Documentos,"DOCUS_Codigo"))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar()
      Try
         If Not IsNothing(bs_btran_vehiculos) Then
            If bs_btran_vehiculos.Current IsNot Nothing Then
               Dim x_codigo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
               managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo = New ETRAN_CombustibleConsumo()
               managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.TRAN_Documentos = New ETRAN_Documentos
               managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.Instanciar(ACEInstancia.Nuevo)
               managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.VEHIC_Id = x_codigo
               actxaCodVehiculo.Enabled = False
               actxaDescVehiculo.Enabled = False
               AsignarBinding()
               tabMantenimiento.SelectedTab = tabDatos
               CargarVehiculo(x_codigo)
               '' Cargar 5 Ultimos Consumos
               CargarConsumos()
            End If
         Else
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Modificar)
            managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo = New ETRAN_CombustibleConsumo()
            managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.TRAN_Documentos = New ETRAN_Documentos
            managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.Instanciar(ACEInstancia.Nuevo)
            AsignarBinding()
            tabMantenimiento.SelectedTab = tabDatos
         End If
         actxaNroDocProveedor.Text = Parametros.GetOnlyParametro("pg_RUCCombustib")
         AyudaEntidad(actxaNroDocProveedor, EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Sub

   Private Sub bs_consumos_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If CType(bs_consumos.Current, ETRAN_CombustibleConsumo).COMCO_CCaja Then
            tsbtnAnularRegistro.Enabled = False
         Else
            tsbtnAnularRegistro.Enabled = True
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub CargarVehiculo(ByVal x_vehic_id As Long)
      Try
         If managerTRAN_Vehiculos.Cargar(x_vehic_id) Then
            actxaCodVehiculo.Text = managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Id
            actxaDescVehiculo.Text = managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Placa
            cmbComTipoCombustible.SelectedValue = managerTRAN_Vehiculos.TRAN_Vehiculos.TIPOS_CodTipoCombustible
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

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
         Dim _where As New Hashtable
         _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
         If managerEntidades.Ayuda(_where, x_opcion) Then
         Select x_opcion
               Case EEntidades.TipoEntidad.Proveedores
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Proveedor", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     '' Cargar datos del cliente
                     actxaNroDocProveedor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_CodigoProveedor = Ayuda.Respuesta.Rows(0)("Codigo")
                     actxaDescProveedor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                     If managerEntidades.Cargar(managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_CodigoProveedor, EEntidades.TipoInicializacion.Proveedor) Then
                        Label7.Focus()
                     End If
                  End If
            Case EEntidades.TipoEntidad.Conductores
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Conductor", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     '' Cargar datos del cliente
                     actxaCodConductor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_CodigoConductor = Ayuda.Respuesta.Rows(0)("Codigo")
                     actxaDescConductor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                     If managerEntidades.Cargar(managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_CodigoConductor, EEntidades.TipoInicializacion.Conductor) Then
                        Label4.Focus()
                     End If
                  End If
            End Select
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AyudaEntidad(ByRef x_textayuda As ACControles.ACTextBoxAyuda, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         If x_textayuda.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
            '' Cargar datos adicionales cliente
            If x_textayuda.ACAyuda.Enabled = True Then
               If managerEntidades.CargarDocIden(x_textayuda.Text, EEntidades.TipoInicializacion.Direcciones) Then
                  x_textayuda.Text = managerEntidades.Entidades.ENTID_NroDocumento
                  Select Case x_opcion
                     Case EEntidades.TipoEntidad.Proveedores
                        managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                        actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                        Label7.Focus()
                     Case EEntidades.TipoEntidad.Conductores
                        managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_CodigoConductor = managerEntidades.Entidades.ENTID_Codigo
                        actxaDescConductor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                        Label4.Focus()
                     Case Else

                  End Select
               Else
                  If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                  , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", x_textayuda.Text) _
                                  , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                     NuevaEntidad(x_textayuda.Text, x_opcion)
                  Else
                     x_textayuda.Clear()
                     Select Case x_opcion
                        Case EEntidades.TipoEntidad.Proveedores
                           Label7.Focus()
                           actxaDescProveedor.Clear()
                        Case EEntidades.TipoEntidad.Conductores
                           actxaDescConductor.Clear()
                           Label4.Focus()
                     End Select

                  End If
               End If
            End If
         Else
            If x_textayuda.Text.Trim().Length > 0 Then
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", x_textayuda.Text))
               x_textayuda.Clear()
               Select Case x_opcion
                  Case EEntidades.TipoEntidad.Proveedores
                     actxaDescProveedor.Clear()
                     Label7.Focus()
                  Case EEntidades.TipoEntidad.Conductores
                     actxaDescConductor.Clear()
                     Label4.Focus()
               End Select
            End If
         End If
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
                     managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_CodigoProveedor = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                  End If
            End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
      End Try
   End Sub

   Private Sub AyudaVehiculo(ByVal x_cadena As String, ByVal x_opcion As Short)
      Try
         Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Vehiculo", managerTRAN_Vehiculos.DTTRAN_Vehiculos, False)
         If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
            actxaCodConductor.Text = Ayuda.Respuesta.Rows(0)("Codigo")
            actxaDescConductor.Text = Ayuda.Respuesta.Rows(0)("Placa")
            lblTipoCombustible.Focus()
         Else
            Label4.Focus()
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub CargarConsumos()
      Try
         Dim _consumo As New BTRAN_CombustibleConsumo
         bs_consumos = New BindingSource
         If Not _consumo.ConsumosXVehiculo(managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.VEHIC_Id) Then
            _consumo.ListTRAN_CombustibleConsumo = New List(Of ETRAN_CombustibleConsumo)
         End If
         bs_consumos.DataSource = _consumo.ListTRAN_CombustibleConsumo
         bnavConsumos.BindingSource = bs_consumos
         c1grdConsumos.DataSource = bs_consumos

         AddHandler bs_consumos.CurrentChanged, AddressOf bs_consumos_CurrentChanged
         bs_consumos_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
#Region " Tool Bar "

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnModificar_Click
      Try
         If Not IsNothing(bs_busconsumos) Then
            If Not IsNothing(bs_busconsumos.Current) Then
               setInstancia(ACUtilitarios.ACSetInstancia.Modificado)
               tabMantenimiento.SelectedTab = tabDatos
               If managerTRAN_CombustibleConsumo.Cargar(CType(bs_busconsumos.Current, ETRAN_CombustibleConsumo).COMCO_Id, True) Then
                  RemoveHandler actxnComLitConsumidos.LostFocus, AddressOf actxnComLitConsumidos_LostFocus
                  AsignarBinding()
                  actxaCodConductor.Text = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_NroDocConductor
                  actxaDescConductor.Text = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.Conductor
                  actxaCodVehiculo.Text = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.VEHIC_Id
                  actxaDescVehiculo.Text = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.VEHIC_Placa
                  actxaNroDocProveedor.Text = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_NroDocProveedor
                  actxaDescProveedor.Text = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ENTID_RazonSocial
                  '' Cargar 5 Ultimos Consumos
                  CargarConsumos()
                  If managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.TRAN_Documentos.DOCUS_Numero > 0 Then
                     CheckBox1.Checked = True
                     CheckBox1.Enabled = False
                     GroupBox2.Enabled = False
                  End If
                  AddHandler actxnComLitConsumidos.LostFocus, AddressOf actxnComLitConsumidos_LostFocus
               End If
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede ")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede ")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar Consumo de Combustible", ex)
      End Try
   End Sub
   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         RemoveHandler actxnComLitConsumidos.LostFocus, AddressOf actxnComLitConsumidos_LostFocus
         tabMantenimiento.SelectedTab = tabDatos
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         cargar()
         Label2.Focus()
         GroupBox2.Enabled = False
         CheckBox1.Checked = False
         AddHandler actxnComLitConsumidos.LostFocus, AddressOf actxnComLitConsumidos_LostFocus
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Consumo de Combustible", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
      Try
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
             cargar_grillaDocs()
                    actxtsub.Clear()
                    actxtotal.Clear()
                    txtnumeroentero.Clear()
         For Each Item As ACBindHelper In m_listBindHelper
            Item.ACUnBind()
         Next
         Me.KeyPreview = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Consumo de Combustible", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.SUCUR_Id = GApp.ESucursal.SUCUR_Id
         If managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_PrecioGalon = 0 Then
            If managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_GalonesConsumidos > 0 Then
               managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_PrecioGalon = managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_Total / managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_GalonesConsumidos
            End If
         End If
         If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, msg) = True Then
            If managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.Nuevo Then managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.COMCO_Id = managerTRAN_CombustibleConsumo.getCorrelativo()
            managerTRAN_CombustibleConsumo.TRAN_CombustibleConsumo.ZONAS_Codigo = GApp.Zona
            If managerTRAN_CombustibleConsumo.GuardarConsumo_mod(GApp.Usuario) Then
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                    cargar_grillaDocs()
                    actxtsub.Clear()
                    actxtotal.Clear()
                    txtnumeroentero.Clear()
            End If
            Select Case m_opcion
               Case Origen.Registro
                  acTool.ACBtnModificar.Visible = False
                  acTool.ACBtnNuevoVisible = True
                  tabMantenimiento.SelectedTab = tabBusqueda
               Case Origen.Modificar
                  acTool.ACBtnModificar.Visible = True
                  acTool.ACBtnNuevoVisible = False
                  tabMantenimiento.SelectedTab = tabBusConsumos
               Case Else
                  tabMantenimiento.SelectedTab = tabBusqueda
            End Select
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No puede guardar, por que hay campos obligatorios vacios: " + msg)
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
         acTool_ACBtnNuevo_Click(Nothing, Nothing)
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar el registro seleccionado", ex)
      End Try

   End Sub

   Private Sub actxaNroDocProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaNroDocProveedor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Proveedor", ex)
      End Try
   End Sub

   Private Sub actxaDescProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaDescProveedor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Proveedor", ex)
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

   Private Sub txtSerie_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      If Char.IsDigit(e.KeyChar) Then
         e.Handled = False
      ElseIf Char.IsControl(e.KeyChar) Then
         e.Handled = False
      Else
         e.Handled = True
      End If
   End Sub

   Private Sub actxaNroDocProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocProveedor.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            AyudaEntidad(actxaNroDocProveedor, EEntidades.TipoEntidad.Proveedores)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxnComLitConsumidos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         If Convert.ToDecimal(actxnComPrecGalon.Text) = 0 And Convert.ToDecimal(actxnComLitConsumidos.Text) <> 0 Then
            actxnComPrecGalon.Text = Math.Round(Convert.ToDecimal(actxnTotal.Text) / Convert.ToDecimal(actxnComLitConsumidos.Text), 2, MidpointRounding.AwayFromZero)
         ElseIf Convert.ToDecimal(actxnComPrecGalon.Text) <> 0 And Convert.ToDecimal(actxnComLitConsumidos.Text) <> 0 Then
            actxnTotal.Text = Math.Round(Convert.ToDecimal(actxnComPrecGalon.Text) * Convert.ToDecimal(actxnComLitConsumidos.Text), 2, MidpointRounding.AwayFromZero)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error calculando el precio por galon", ex)
      End Try
   End Sub

   Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      txtBusqueda_ACAyudaClick(Nothing, Nothing)
   End Sub

   Private Sub actxaCodConductor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCodConductor.ACAyudaClick
      Try
         AyudaEntidad(actxaCodConductor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Conductores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Conductor", ex)
      End Try
   End Sub

   Private Sub actxaDescConductor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescConductor.ACAyudaClick
      Try
         AyudaEntidad(actxaDescConductor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Conductores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Conductor", ex)
      End Try
   End Sub

   Private Sub actxaCodVehiculo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaCodVehiculo.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            Dim _id As Long
            Try
               _id = actxaCodVehiculo.Text
            Catch ex As Exception
               Return
            End Try
            If managerTRAN_Vehiculos.Cargar(CType(_id, Long), False) Then
               actxaCodVehiculo.Text = managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Id
               actxaDescVehiculo.Text = managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Placa
               lblTipoCombustible.Focus()
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaCodConductor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaCodConductor.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            AyudaEntidad(actxaCodConductor, EEntidades.TipoEntidad.Conductores)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaCodVehiculo_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCodVehiculo.ACAyudaClick
      Try
         AyudaVehiculo(actxaCodConductor.Text, 0)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Ayuda Vehiculo", ex)
      End Try
   End Sub

   Private Sub actxaDescVehiculo_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescVehiculo.ACAyudaClick
      Try
         AyudaVehiculo(actxaDescConductor.Text, 1)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Ayuda Vehiculo", ex)
      End Try
   End Sub

   Private Sub bs_busconsumos_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_busconsumos.Current) Then
            If CType(bs_busconsumos.Current, ETRAN_CombustibleConsumo).COMCO_Fecha.Date = m_fecha.Date Then
               If Not CType(bs_busconsumos.Current, ETRAN_CombustibleConsumo).COMCO_CCaja Then
                  acTool.ACBtnModificarEnabled = True
               Else
                  acTool.ACBtnModificarEnabled = False
               End If
            Else
               acTool.ACBtnModificarEnabled = False
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub
#End Region

   Private Function getOpcion() As Integer
      If rbtnConductor.Checked Then
         Return 0
      ElseIf rbtnPlacaVehiculo.Checked Then
         Return 1
      ElseIf rbtnProveedor.Checked Then
         Return 2
      End If
   End Function

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         bs_busconsumos = New BindingSource
         formatearGrilla()
         acTool.ACBtnModificarEnabled = True
         If Not managerTRAN_CombustibleConsumo.Consumos(AcFecha.ACFecha_De.Value.Date, AcFecha.ACFecha_A.Value.Date, actxaBusqueda.Text, getOpcion()) Then
            managerTRAN_CombustibleConsumo.ListTRAN_CombustibleConsumo = New List(Of ETRAN_CombustibleConsumo)
            acTool.ACBtnModificarEnabled = False
         End If
         bs_busconsumos.DataSource = managerTRAN_CombustibleConsumo.ListTRAN_CombustibleConsumo
         c1grdBusConsumos.DataSource = bs_busconsumos
         bnavBusConsumos.BindingSource = bs_busconsumos
         AddHandler bs_busconsumos.CurrentChanged, AddressOf bs_busconsumos_CurrentChanged
         bs_busconsumos_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Consumos de Combustible", ex)
      End Try
   End Sub

  

   Private Sub AcTextBoxNumerico1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcTextBoxNumerico1.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            Me.KeyPreview = False
            acTool.Focus()
            acTool.ACBtnGrabar.Select()
         End If
      Catch ex As Exception

      End Try
   End Sub

   Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
      PANEL4.Enabled = CheckBox1.Checked
   End Sub

   Private Sub CheckBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckBox1.KeyDown
      Try
         If Not GroupBox2.Enabled Then
            If e.KeyCode = Keys.Enter Then
               KeyPreview = False
               acTool.Focus()
               acTool.ACBtnGrabar.Select()
            End If
         End If
      Catch ex As Exception

      End Try
   End Sub


Private Sub tsbtnExcel_Click( sender As Object,  e As EventArgs) Handles tsbtnExcel.Click
          Try
         Utilitarios.ExportarXLS(c1grdConsumos, "Consumos")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error enviar a excel", ex)
      End Try
End Sub

Private Sub tsbtnAnularRegistro_Click( sender As Object,  e As EventArgs) Handles tsbtnAnularRegistro.Click
         Try
         If Not IsNothing(bs_consumos) Then
            If Not IsNothing(bs_consumos.Current) Then
               If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Anular Registro: {0}", Me.Text) _
                               , "Desea Anular el registro Seleccionado " _
                               , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                  '' Codigo
                  Dim _consumo As New BTRAN_CombustibleConsumo
                  _consumo.TRAN_CombustibleConsumo = CType(bs_consumos.Current, ETRAN_CombustibleConsumo)
                  If _consumo.AnularRegistro(ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Anulado), GApp.Usuario) Then
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Anulado satisfactoriamente")
                     CargarConsumos()
                  Else
                     ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se pudo Anular")
                  End If
               End If
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede <<Mensaje>> ")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede <<Mensaje>> ")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Anular Registro", ex)
      End Try
End Sub
    private sub cargar_documentos()
        cargar_grillaDocs()
            
            Dim _i As Integer =1
        
            If managerTRAN_CombustibleConsumo.doc_compra_pro(actxaNroDocProveedor.Text) Then

            c1grdDocsPago.Rows.Count = managerTRAN_CombustibleConsumo.DTTabla_com_pro.Rows.Count + 1
         
           
            For Each item As DataRow In managerTRAN_CombustibleConsumo.DTTabla_com_pro.Rows
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

Private Sub tsbtnAgregarTPago_Click( sender As Object,  e As EventArgs) Handles tsbtnAgregarTPago.Click
        cargar_documentos()
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
        AcTextBoxNumerico1.Text=c1grdDocsPago.Rows(index).Item(10).ToString()
        txtnumeroentero.Text=c1grdDocsPago.Rows(index).Item(8).ToString()
        Next
            
            Dim _i as Integer=1
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

    Private Sub tsbtnNuevoTPago_Click(sender As Object, e As EventArgs) Handles tsbtnNuevoTPago.Click

        Dim frmCC As New ConsultasViajes(0, "tpdetalle")
        frmCC.ShowDialog()
    End Sub

End Class