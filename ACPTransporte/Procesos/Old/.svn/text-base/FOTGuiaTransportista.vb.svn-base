Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports ACEVentas
Imports ACBVentas
Imports ACELogistica

Imports C1.Win.C1FlexGrid


Public Class FOTGuiaTransportista

#Region " Variables "
   Private managerVENT_PVentDocumento As BVENT_PVentDocumento
   Private managerEntidades As BEntidades
   Private managerTRAN_Vehiculos As BTRAN_Vehiculos
   Private managerConsultaArticulos As BConsultaArticulos
   Private managerGenerarGuias As ACBTransporte.BGenerarGuias

   Private m_listSalDep As List(Of EUbigeos) : Private m_listDesDep As List(Of EUbigeos)
   Private bs_SalDep As BindingSource : Private bs_DesDep As BindingSource
   Private m_listSalPro As List(Of EUbigeos) : Private m_listDesPro As List(Of EUbigeos)
   Private bs_SalPro As BindingSource : Private bs_DesPro As BindingSource
   Private m_listSalDis As List(Of EUbigeos) : Private m_listDesDis As List(Of EUbigeos)
   Private bs_SalDis As BindingSource : Private bs_DesDis As BindingSource

   Private bs_almacenesOrigen As BindingSource
   Private bs_almacenesDestino As BindingSource
   Private bs_etran_guiastransportistadetalle As BindingSource
   Private bs_puntoventa As BindingSource
   Private bs_eabas_docscompra As BindingSource
   Private bs_series As BindingSource
   Private bs_sucursales As BindingSource
   Private bs_tipodocumento As BindingSource

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_earticulos As EArticulos
   Private m_etran_guiastransportista As ETRAN_GuiasTransportista

   Private frmCons As CProductos

   Private m_order As Integer = 1
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         Inicializacion()
         acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Guia de Traslado Interno - Salida por Transferencia")

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub Inicializacion()
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         managerEntidades = New BEntidades
         managerTRAN_Vehiculos = New BTRAN_Vehiculos
         managerGenerarGuias = New ACBTransporte.BGenerarGuias
         managerVENT_PVentDocumento = New BVENT_PVentDocumento
         managerConsultaArticulos = New BConsultaArticulos(GApp.Periodo)

         formatearGrilla()
         cargarCombos()

         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Procesos "

   Private Function nuevaGuia() As Boolean
      m_etran_guiastransportista = New ETRAN_GuiasTransportista
      Try
         If managerGenerarGuias.cargarDocsCompra(CType(bs_eabas_docscompra.Current, EABAS_DocsCompra).DOCCO_Codigo, _
                                                 CType(bs_eabas_docscompra.Current, EABAS_DocsCompra).ENTID_CodigoProveedor, True) Then
            setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)
            m_etran_guiastransportista = managerGenerarGuias.TRAN_GuiasTransportista
            '' Cargar Datos de la Empresa
            m_etran_guiastransportista.Instanciar(ACEInstancia.Nuevo)
            m_etran_guiastransportista.GTRAN_Estado = ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Ingresado)
          
            '' Cargar Proveedor
            If managerEntidades.Cargar(m_etran_guiastransportista.ENTID_Codigo, EEntidades.TipoInicializacion.Direcciones) Then
               Dim x_direcciones As New EDirecciones
               x_direcciones.DIREC_Id = 0
               x_direcciones.DIREC_Direccion = managerEntidades.Entidades.ENTID_Direccion
               x_direcciones.UBIGO_Codigo = managerEntidades.Entidades.UBIGO_Codigo
               If IsNothing(managerEntidades.Entidades.ListDirecciones) Then managerEntidades.Entidades.ListDirecciones = New List(Of EDirecciones)()
               managerEntidades.Entidades.ListDirecciones.Insert(0, x_direcciones)

               ACFramework.ACUtilitarios.ACCargaCombo(cmbDirOrigen, managerEntidades.Entidades.ListDirecciones, "DIREC_Direccion", "DIREC_Id")
               If managerEntidades.Entidades.ListDirecciones.Count > 0 Then
                  cmbDirOrigen.SelectedValue = managerEntidades.Entidades.ListDirecciones(0).DIREC_Id
                  If Not IsNothing(CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo) Then
                     cmbOrigenDepartamento.SelectedValue = CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 2)
                     cmbOrigenProvincia.SelectedValue = CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 5)
                     cmbOrigenDistrito.SelectedValue = CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo
                  End If
               End If
            End If
            '' Comprobante de Pago
            If Not IsNothing(m_etran_guiastransportista.GTRAN_NroComprobantePago) Then
               cmbDocVenta.SelectedValue = String.Format("{0}{1}", ETipos.getCodTipo(ETipos.MyTipos.TipoDocComprobante), m_etran_guiastransportista.GTRAN_NroComprobantePago.Substring(0, 2))
               txtDVSerie.Text = m_etran_guiastransportista.GTRAN_NroComprobantePago.Substring(2, 3)
               actxnDVNumero.Text = m_etran_guiastransportista.GTRAN_NroComprobantePago.Substring(5)
            End If
            '' 
            AsignarBinding()
            '            txtCodProveedor.Text = m_etran_guiastransportista.gtran
            m_etran_guiastransportista.ENTID_CodigoDestinatario = Parametros.GetParametro(EParametros.TipoParametros.Empresa)
            actxaRucDestinatario.Text = GApp.EmpresaRUC
            actxaRazSocDestinatario.Text = GApp.EEmpresa.EMPR_Desc
            '' Cargar direcciones destino
            bs_etran_guiastransportistadetalle = New BindingSource
            bs_etran_guiastransportistadetalle.DataSource = m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles
            bnavProductos.BindingSource = bs_etran_guiastransportistadetalle
            c1grdDetalle.DataSource = bs_etran_guiastransportistadetalle
            '' Obtener el numero de serie y de guia correspondiente
            bs_series_CurrentChanged(Nothing, Nothing)
            cmbGuia.SelectedValue = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
            '' Dar la instancia de los controles de la interfaz segun el proceso
            tabMantenimiento.SelectedTab = tabDatos
            bs_almacenOrigen_CurrentChanged(Nothing, Nothing)
            'txtAlmaDirDestino.Clear()

            cmbDirDestino.SelectedValue = GApp.ESucursal.SUCUR_Direccion
            cmbDestinoDepartamento.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo.Substring(0, 2)
            cmbDestinoProvincia.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo.Substring(0, 5)
            cmbDestinoDistrito.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo

            Label23.Focus()
            calcular()
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos "
   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of EABAS_DocsCompra)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_eabas_docscompra.DataSource, List(Of EABAS_DocsCompra)).Sort(_ordenador)
         c1grdBusqueda.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
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
               Case EEntidades.TipoEntidad.Transportista
                  actxaNroDocTransportista.Text = frmEntidad.EEntidad.ENTID_NroDocumento
                  actxaDescTransportista.Text = frmEntidad.EEntidad.ENTID_RazonSocial
                  m_etran_guiastransportista.ENTID_CodigoTransportista = frmEntidad.EEntidad.ENTID_Codigo
                  lblNomConductor.Focus()
               Case EEntidades.TipoEntidad.Conductores
                  actxaNroDocConductor.Text = frmEntidad.EEntidad.ENTID_NroDocumento
                  actxaDescConductor.Text = frmEntidad.EEntidad.ENTID_RazonSocial
                  m_etran_guiastransportista.ENTID_CodigoConductor = frmEntidad.EEntidad.ENTID_Codigo
                  lblDescVehiculo.Focus()
            End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
      End Try
   End Sub

#Region " Utilitarios "

   Private Sub calcular(Optional ByVal x_moneda As Boolean = False)
      Try
         If Not IsNothing(m_etran_guiastransportista) Then
            If Not IsNothing(m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles) Then
               If m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles.Count > 0 Then
                  Dim _pesoTotal As Decimal = 0 : Dim _cantidad As Decimal = 0
                  '' Calcular totales
                  For Each Item As ETRAN_GuiasTransportistaDetalles In m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles
                     _pesoTotal += Item.GTDET_Peso * Item.GTDET_Cantidad
                     _cantidad += Item.GTDET_Cantidad
                  Next
                  actxnPesoTotal.Text = _pesoTotal : actxnPesoTotal.Formatear()
               End If
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function busqueda(ByVal x_cadena As String, Optional ByVal x_documento As Boolean = False) As Boolean
      Try
         If x_documento Then
            If managerGenerarGuias.Busqueda(cmbTipoDocumento.SelectedValue, txtCSerie.Text, txtBusNumero.Text, GApp.Sucursal, chkTodos.Checked, acFecha.ACDtpFecha_De.Value.Date, acFecha.ACDtpFecha_A.Value.Date.AddDays(1)) Then
               actool.ACBtnEliminarEnabled = True
               actool.ACBtnModificarEnabled = True
            Else
               actool.ACBtnEliminarEnabled = False
               actool.ACBtnModificarEnabled = False
            End If
            cargarDatos()
         Else
            'If txtBusqueda.ACEstadoAutoAyuda Then
            If managerGenerarGuias.BusFacturas(x_cadena, getCampo(), chkTodos.Checked, acFecha.ACDtpFecha_De.Value.Date, acFecha.ACDtpFecha_A.Value.Date.AddDays(1)) Then
               actool.ACBtnEliminarEnabled = True
               actool.ACBtnModificarEnabled = True
            Else
               actool.ACBtnEliminarEnabled = False
               actool.ACBtnModificarEnabled = False
            End If
            cargarDatos()
            'End If
            Return actool.ACBtnEliminarEnabled
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Function getCampo() As String
      Try
         If (rbtnProveedor.Checked) Then
            Return "ENTID_RazonSocial"
         ElseIf rbtnNroOrdenCompra.Checked Then
            Return "ENTID_CodigoProveedor"
         Else
            Return "ENTID_RazonSocial"
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function Validar(ByRef msg As String) As Boolean
      Dim i As Integer = 0
      Dim j As Decimal = 0
      Try
         For Each Item As ETRAN_GuiasTransportistaDetalles In m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles
            i += Item.GTDET_Cantidad
            j += Item.GTDET_Peso * Item.GTDET_Cantidad
         Next

         If j >= CType(Parametros.GetParametro("pg_CargaMax", True), Decimal) Then
            msg &= String.Format("- El peso excede el limite establecido, {2}Peso Actual: {0} kg.,{2}Peso Establecido: {1} kg.{2}" _
                                 , j.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) _
                                 , CType(Parametros.GetParametro("pg_CargaMax", True), Decimal).ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) _
                                 , vbNewLine)
         End If

         If Not i > 0 Then msg &= "- La Cantidad debe ser superior a 0" & vbNewLine
         If Not m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles.Count > 0 Then msg &= "- Debe ingresar al menos un Item" & vbNewLine

         Return Not msg.Length > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub cargarCombos()
      Try
         ACUtilitarios.ACCargaCombo(cmbDocVenta, Colecciones.TiposDocMerTransito(), "TIPOS_Descripcion", "TIPOS_Codigo")
         Dim list As New List(Of ETipos)()
         For Each Item As ETipos In Colecciones.TiposDocMerTransito()
            list.Add(Item.Clone())
         Next
         list.Insert(0, New ETipos("", "<< Todos >>"))
         '' Cargar Direcciones de los almacenes como direccion de origen
         bs_sucursales = New BindingSource() : bs_sucursales.DataSource = Colecciones.Sucursales
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDirDestino, bs_sucursales, "SUCUR_Direccion", "SUCUR_Direccion")
         AddHandler bs_sucursales.CurrentChanged, AddressOf bs_sucursales_CurrentChanged : bs_sucursales_CurrentChanged(Nothing, Nothing)
         '' Documentos de Traslados
         Dim listDT As New List(Of ETipos) : Dim listBus As New List(Of ETipos)
         For Each Item As ETipos In Colecciones.TiposDocsTraslado
            listDT.Add(Item.Clone()) : listBus.Add(Item.Clone())
         Next
         bs_tipodocumento = New BindingSource() : bs_tipodocumento.DataSource = listDT
         ACFramework.ACUtilitarios.ACCargaCombo(cmbGuia, bs_tipodocumento, "TIPOS_Descripcion", "TIPOS_Codigo")
         AddHandler bs_tipodocumento.CurrentChanged, AddressOf bs_tipodocumento_CurrentChanged : bs_tipodocumento_CurrentChanged(Nothing, Nothing)
         listBus.Insert(0, New ETipos("", "<< Todos >>"))
         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoDocumento, listBus, "TIPOS_Descripcion", "TIPOS_Codigo")
         '' Tipo de Traslado
         ACFramework.ACUtilitarios.ACCargaCombo(cmbMotivoTraslado, Colecciones.Tipos(ETipos.MyTipos.MotivoTraslado), "TIPOS_Descripcion", "TIPOS_Codigo", ETipos.getMotivoTraslado(ETipos.MotivoTraslado.Compra))
         '' Cargar Ubigeos
         m_listSalDep = New List(Of EUbigeos) : m_listDesDep = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Departamentos
            If Not Item.UBIGO_Codigo.Equals("00") Then
               m_listSalDep.Add(Item.Clone) : m_listDesDep.Add(Item.Clone)
            End If
         Next
         bs_SalDep = New BindingSource() : bs_SalDep.DataSource = m_listSalDep : AddHandler bs_SalDep.CurrentChanged, AddressOf bs_saldep_CurrentChanged : bs_saldep_CurrentChanged(Nothing, Nothing)
         bs_DesDep = New BindingSource() : bs_DesDep.DataSource = m_listDesDep : AddHandler bs_DesDep.CurrentChanged, AddressOf bs_desdep_CurrentChanged : bs_desdep_CurrentChanged(Nothing, Nothing)
         '' Ubigeos
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDestinoDepartamento, bs_SalDep, "UBIGO_Descripcion", "UBIGO_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbOrigenDepartamento, bs_DesDep, "UBIGO_Descripcion", "UBIGO_Codigo")

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
      Try
         actool.ACBtnRehusarVisible = False
         actool.ACBtnModificarVisible = False
         Select Case _opcion
            Case ACUtilitarios.ACSetInstancia.Nuevo
               ACUtilitarios.ACLimpiaVar(pnlCabecera)
               txtNumeroPedido.Clear()
               actxnDVNumero.Clear()
               SetControles(True)
               actool.ACBtnImprimirVisible = False
               actsbtnPrevisualizar.Visible = False
               actool.ACBtnAnularVisible = False
               actool.ACBtnImprimirEnabled = False
            Case ACUtilitarios.ACSetInstancia.Modificado

            Case ACUtilitarios.ACSetInstancia.Guardar
               txtBusqueda.Focus()
            Case ACUtilitarios.ACSetInstancia.Deshacer
               actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               actool.ACBtnModificarVisible = False
               actool.ACBtnBuscarVisible = False
               actsbtnPrevisualizar.Visible = True
               actool.ACBtnImprimirVisible = False
               tabMantenimiento.SelectedTab = tabBusqueda
               actool.ACBtnImprimirEnabled = True
            Case ACUtilitarios.ACSetInstancia.Previsualizar
               actool.ACBtnImprimirVisible = True
               ACUtilitarios.ACLimpiaVar(pnlCabecera)
               ACUtilitarios.ACSetControl(pnlCabecera, True, ACUtilitarios.TipoPropiedad.ACReadOnly)
               actool.ACBtnGrabarVisible = False
               actsbtnPrevisualizar.Visible = False
               actool.ACBtnRehusarVisible = True
               actool.ACBtnImprimirEnabled = True
               SetControles(False)
         End Select
      Catch ex As Exception
         Throw ex
      End Try
      actool.ACBtnAnularVisible = False
   End Sub

   Private Sub SetControles(ByVal x_opcion As Boolean)
      cmbDirDestino.Enabled = x_opcion
      cmbDirOrigen.Enabled = x_opcion
      cmbGuia.Enabled = x_opcion

      actxaDescTransportista.ACActivarAyuda = x_opcion : actxaDescTransportista.ACAyuda.Enabled = x_opcion
      actxaNroDocTransportista.ACActivarAyuda = x_opcion : actxaNroDocTransportista.ACAyuda.Enabled = x_opcion
      actxaDescConductor.ACActivarAyuda = x_opcion : actxaDescConductor.ACAyuda.Enabled = x_opcion
      actxaNroDocConductor.ACActivarAyuda = x_opcion : actxaNroDocConductor.ACAyuda.Enabled = x_opcion
      actxaDescVehiculo.ACActivarAyuda = x_opcion : actxaDescVehiculo.ACAyuda.Enabled = x_opcion
      actxaCodVehiculo.ACActivarAyuda = x_opcion : actxaCodVehiculo.ACAyuda.Enabled = x_opcion
      grpDocumento.Enabled = x_opcion
      dtpFechaEmision.Enabled = x_opcion
      dtpFechaTraslado.Enabled = x_opcion

      txtNumeroPedido.ReadOnly = Not x_opcion
      btnNueTransportista.Enabled = x_opcion : btnNuevConductor.Enabled = x_opcion

      actxaRucDestinatario.ACAyuda.Enabled = False
      actxaRazSocDestinatario.ACAyuda.Enabled = False
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 12, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "DOCCO_FechaDocumento", "DOCCO_FechaDocumento", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "DOCCO_Codigo", "DOCCO_Codigo", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Orden", "CodigoOrden", "CodigoOrden", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cod. Proveedor", "ENTID_CodigoProveedor", "ENTID_CodigoProveedor", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Proveedor", "ENTID_Proveedor", "ENTID_Proveedor", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Total Compra", "DOCCO_TotalCompra", "DOCCO_TotalCompra", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Pago", "TIPOS_TipoPago", "TIPOS_TipoPago", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCCO_Estado_Text", "DOCCO_Estado_Text", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCCO_Estado", "DOCCO_Estado", 150, False, False, "System.String") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue

         Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Facturado")
         t.BackColor = Color.LightGreen
         t.ForeColor = Color.DarkBlue
         t.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

         Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Facturar")
         u.BackColor = Color.Green
         u.ForeColor = Color.White
         u.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

         Dim d As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Anulado")
         d.BackColor = Color.Red
         d.ForeColor = Color.White
         d.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)
         c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 10, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Codigo", "ARTIC_Codigo", "ARTIC_Codigo", 110, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Descripción", "GTDET_Descripcion", "GTDET_Descripcion", 454, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Unidad", "GTDET_Unidad", "GTDET_Unidad", 80, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Peso", "GTDET_Peso", "GTDET_Peso", 80, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Total Doc.", "TotalDoc", "TotalDoc", 75, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Entregado", "Entregado", "Entregado", 75, True, False, "System.Double", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Diferencia", "Diferencia", "Diferencia", 75, False, False, "System.Double", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Cantidad", "GTDET_Cantidad", "GTDET_Cantidad", 110, True, True, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Peso Doc.", "SubPeso", "SubPeso", 75, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         c1grdDetalle.AllowEditing = True
         c1grdDetalle.AutoResize = False
         c1grdDetalle.Cols(0).Width = 15
         c1grdDetalle.ExtendLastCol = False
         'c1grdDetalle.VisualStyle = VisualStyle.Office2007Blue
         c1grdDetalle.AllowSorting = AllowSortingEnum.SingleColumn

         c1grdDetalle.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDetalle.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDetalle.Styles.Highlight.BackColor = Color.Gray
         c1grdDetalle.SelectionMode = SelectionModeEnum.Row
         c1grdDetalle.AllowResizing = AllowResizingEnum.None

         Dim tt As C1.Win.C1FlexGrid.CellStyle = c1grdDetalle.Styles.Add("Facturado")
         tt.BackColor = Color.LightGreen
         tt.ForeColor = Color.DarkBlue
         tt.Font = New Font(c1grdDetalle.Font, FontStyle.Regular)

         Dim uu As C1.Win.C1FlexGrid.CellStyle = c1grdDetalle.Styles.Add("Cantidad")
         uu.BackColor = Color.Green
         uu.ForeColor = Color.White
         uu.Font = New Font(c1grdDetalle.Font, FontStyle.Regular)

         Dim dd As C1.Win.C1FlexGrid.CellStyle = c1grdDetalle.Styles.Add("Total")
         dd.BackColor = Color.Red
         dd.ForeColor = Color.White
         dd.Font = New Font(c1grdDetalle.Font, FontStyle.Bold)
         c1grdDetalle.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try

   End Sub

#End Region

#Region " Cargar Datos "

   Private Sub bs_series_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_series.Current) Then
            Dim x_numero As Integer = managerGenerarGuias.getNumero(CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_Serie, ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente))
            actxnNumero.Text = (x_numero + 1).ToString()
            tscmbImpresora.Text = CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_DispositivoImpresion
         Else
            actxnNumero.Clear()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub bs_tipodocumento_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not (bs_tipodocumento.Current Is Nothing) Then
            '' Series por documento
            managerVENT_PVentDocumento.GetSeries(GApp.Zona, GApp.Sucursal, cmbGuia.SelectedValue)
            Dim _serie As String = ""
            For Each item As EVENT_PVentDocumento In managerVENT_PVentDocumento.ListVENT_PVentDocumento
               If item.PVDOCU_PredetGuiaRemisRemitTransportista Then
                  _serie = item.PVDOCU_Serie
               End If
            Next
            bs_series = New BindingSource() : bs_series.DataSource = managerVENT_PVentDocumento.ListVENT_PVentDocumento
            If _serie.Equals("") Then
               ACFramework.ACUtilitarios.ACCargaCombo(cmbSerie, bs_series, "PVDOCU_Serie", "PVDOCU_Serie")
            Else : ACFramework.ACUtilitarios.ACCargaCombo(cmbSerie, bs_series, "PVDOCU_Serie", "PVDOCU_Serie", _serie)
            End If
            AddHandler bs_series.CurrentChanged, AddressOf bs_series_CurrentChanged : bs_series_CurrentChanged(Nothing, Nothing)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_sucursales_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_sucursales.Current) Then
            If IsNothing(CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo) Then
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "La dirección actual no tiene un ubigeo definido, por favor selecione uno para su impresión")
            Else
               cmbDestinoDepartamento.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo.Substring(0, 2)
               cmbDestinoProvincia.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo.Substring(0, 5)
               cmbDestinoDistrito.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

#Region " Ubigeos "
   Private Sub bs_saldep_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_ubigeo As String = CType(bs_SalDep.Current, EUbigeos).UBIGO_Codigo
         m_listSalPro = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Provincias
            If x_ubigeo.Equals(Item.UBIGO_CodPadre) Then
               m_listSalPro.Add(Item.Clone)
            End If
         Next
         bs_SalPro = New BindingSource() : bs_SalPro.DataSource = m_listSalPro : AddHandler bs_SalPro.CurrentChanged, AddressOf bs_salpro_CurrentChanged
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDestinoProvincia, bs_SalPro, "UBIGO_Descripcion", "UBIGO_Codigo")
         bs_salpro_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso actualizar departamento", ex)
      End Try
   End Sub

   Private Sub bs_salpro_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_ubigeo As String = CType(bs_SalPro.Current, EUbigeos).UBIGO_Codigo
         m_listSalDis = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Distritos
            If x_ubigeo.Equals(Item.UBIGO_CodPadre) Then
               m_listSalDis.Add(Item.Clone)
            End If
         Next
         bs_SalDis = New BindingSource() : bs_SalDis.DataSource = m_listSalDis
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDestinoDistrito, bs_SalDis, "UBIGO_Descripcion", "UBIGO_Codigo")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso actualizar provincia", ex)
      End Try
   End Sub

   Private Sub bs_desdep_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_ubigeo As String = CType(bs_DesDep.Current, EUbigeos).UBIGO_Codigo
         m_listDesPro = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Provincias
            If x_ubigeo.Equals(Item.UBIGO_CodPadre) Then
               m_listDesPro.Add(Item.Clone)
            End If
         Next
         bs_DesPro = New BindingSource() : bs_DesPro.DataSource = m_listDesPro : AddHandler bs_DesPro.CurrentChanged, AddressOf bs_despro_CurrentChanged
         ACFramework.ACUtilitarios.ACCargaCombo(cmbOrigenProvincia, bs_DesPro, "UBIGO_Descripcion", "UBIGO_Codigo")
         bs_despro_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso actualizar departamento", ex)
      End Try
   End Sub

   Private Sub bs_despro_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_ubigeo As String = CType(bs_DesPro.Current, EUbigeos).UBIGO_Codigo
         m_listDesDis = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Distritos
            If x_ubigeo.Equals(Item.UBIGO_CodPadre) Then
               m_listDesDis.Add(Item.Clone)
            End If
         Next
         bs_DesDis = New BindingSource() : bs_DesDis.DataSource = m_listDesDis
         ACFramework.ACUtilitarios.ACCargaCombo(cmbOrigenDistrito, bs_DesDis, "UBIGO_Descripcion", "UBIGO_Codigo")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso actualizar provincia", ex)
      End Try
   End Sub

#End Region

   Private Sub bs_abas_dosccompra_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_eabas_docscompra) Then
            If Not IsNothing(bs_eabas_docscompra.Current) Then
               If CType(bs_eabas_docscompra.Current, EABAS_DocsCompra).DOCCO_Estado = EABAS_DocsCompra.getEstado(EABAS_DocsCompra.Estado.Ingresado) Then
                  actool.ACBtnAnularEnabled = True
                  actool.ACBtnImprimirEnabled = True
               Else
                  actool.ACBtnAnularEnabled = False
                  actool.ACBtnImprimirEnabled = False
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Propiedades del Cotización/Pedido", ex)
      End Try
   End Sub

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         Select Case x_opcion
            Case EEntidades.TipoEntidad.Transportista
               Dim _where As New Hashtable
               _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
               If managerEntidades.Ayuda(_where, x_opcion) Then
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Transportista", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     '' Cargar datos del cliente
                     actxaNroDocTransportista.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     actxaDescTransportista.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                     m_etran_guiastransportista.ENTID_CodigoTransportista = Ayuda.Respuesta.Rows(0)("Codigo")
                     lblNomConductor.Focus()
                  End If
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
               End If
            Case EEntidades.TipoEntidad.Conductores
               If managerEntidades.AyudaConductores(m_etran_guiastransportista.ENTID_CodigoTransportista, x_cadenas, x_campo, x_opcion) Then
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Conductores", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     actxaNroDocConductor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     actxaDescConductor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                     m_etran_guiastransportista.ENTID_CodigoConductor = Ayuda.Respuesta.Rows(0)("Codigo")
                     managerEntidades.Entidades = New EEntidades()
                     If managerEntidades.CargarConductor(m_etran_guiastransportista.ENTID_CodigoConductor) Then
                        txtLicencia.Text = managerEntidades.Entidades.Conductor.CONDU_Licencia
                     End If
                     lblDescVehiculo.Focus()
                  End If
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
               End If
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AyudaVehiculo(ByVal x_cadenas As String, ByVal x_campos As String)
      Try
         If managerTRAN_Vehiculos.Ayuda(m_etran_guiastransportista.ENTID_CodigoTransportista, x_cadenas, x_campos) Then
            Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerTRAN_Vehiculos.DTTRAN_Vehiculos, False)
            If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
               actxaCodVehiculo.Text = Ayuda.Respuesta.Rows(0)("Interno")
               If Ayuda.Respuesta.Rows(0)("Marca Ranfla") Is DBNull.Value Then
                  actxaDescVehiculo.Text = String.Format("{0}/{1}", Ayuda.Respuesta.Rows(0)("Marca"), Ayuda.Respuesta.Rows(0)("Placa"))
               Else
                  actxaDescVehiculo.Text = String.Format("{0}-{1}/{2},{3}", Ayuda.Respuesta.Rows(0)("Marca"), Ayuda.Respuesta.Rows(0)("Marca Ranfla"), Ayuda.Respuesta.Rows(0)("Placa"), Ayuda.Respuesta.Rows(0)("Placa Ranfla"))
               End If
               If Ayuda.Respuesta.Rows(0)("Certificado Ranfla") Is DBNull.Value Then
                  txtCertificado.Text = String.Format("{0}", Ayuda.Respuesta.Rows(0)("Certificado"))
               Else
                  txtCertificado.Text = String.Format("{0}/{1}", Ayuda.Respuesta.Rows(0)("Certificado"), Ayuda.Respuesta.Rows(0)("Certificado Ranfla"))
               End If

               'txtLicencia.Text = Ayuda.Respuesta.Rows(0)("Licencia")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar la ayuda, posiblemente no hay datos que mostrar")
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_almacenesDestino_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_almacen As Short = cmbDirOrigen.SelectedValue
         'txtAlmaDirDestino.Text = CType(bs_almacenesDestino.Current, EAlmacenes).ALMAC_Descripcion
         Dim _filter As New ACFiltrador(Of EPuntoVenta)() With {.ACFiltro = String.Format("ALMAC_Id={0}", x_almacen.ToString())}
         bs_puntoventa = New BindingSource()
         bs_puntoventa.DataSource = _filter.ACFiltrar(Colecciones.PuntosVenta)
         'ACUtilitarios.ACCargaCombo(cmbPuntoVentaDestino, bs_puntoventa, "PVENT_Descripcion", "PVENT_Id")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_almacenOrigen_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         'txtAlmaDirOrigen.Text = CType(bs_almacenesOrigen.Current, EAlmacenes).ALMAC_Descripcion
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbSerie, "Text", m_etran_guiastransportista, "GTRAN_Serie"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", m_etran_guiastransportista, "GTRAN_Numero"))
         If m_etran_guiastransportista.GTRAN_Fecha.Year < 1700 Then m_etran_guiastransportista.GTRAN_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFechaEmision, "Value", m_etran_guiastransportista, "GTRAN_Fecha"))
         If m_etran_guiastransportista.GTRAN_FechaTraslado.Year < 1700 Then m_etran_guiastransportista.GTRAN_FechaTraslado = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFechaTraslado, "Value", m_etran_guiastransportista, "GTRAN_FechaTraslado"))

         m_listBindHelper.Add(ACBindHelper.ACBind(txtCodProveedor, "Text", m_etran_guiastransportista, "GTRAN_RucProveedor"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDescProveedor, "Text", m_etran_guiastransportista, "GTRAN_DescEntidadProveedor"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtZonaOrigen, "Text", m_etran_guiastransportista, "GTRAN_ZonaProveedor"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbDirOrigen, "Text", m_etran_guiastransportista, "GTRAN_DireccionProveedor"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbOrigenDistrito, "SelectedValue", m_etran_guiastransportista, "UBIGO_CodigoProveedor"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxaRucDestinatario, "Text", m_etran_guiastransportista, "GTRAN_RUCDestinatario"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxaRazSocDestinatario, "Text", m_etran_guiastransportista, "GTRAN_DesEntidadDestinatario"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtZonaDestino, "Text", m_etran_guiastransportista, "GTRAN_ZonaDestinatario"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbDirDestino, "Text", m_etran_guiastransportista, "GTRAN_DireccionDestinatario"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbDestinoDistrito, "SelectedValue", m_etran_guiastransportista, "UBIGO_CodigoDestinatario"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxaCodVehiculo, "Text", m_etran_guiastransportista, "VEHIC_Id"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxaDescVehiculo, "Text", m_etran_guiastransportista, "GTRAN_DescripcionVehiculo"))
         'm_listBindHelper.Add(ACBindHelper.ACBind(cmbMotivoTraslado, "SelectedValue", m_etran_guiastransportista, "TIPOS_CodMotivoTraslado"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnPesoTotal, "Text", m_etran_guiastransportista, "GTRAN_PesoTotal"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtNumeroPedido, "Text", m_etran_guiastransportista, "GTRAN_NroPedido"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDescProveedor, "Text", m_etran_guiastransportista, "GTRAN_DescEntidadProveedor"))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargarDatos()
      Try
         bs_eabas_docscompra = New BindingSource()
         bs_eabas_docscompra.DataSource = managerGenerarGuias.ListABAS_DocsCompra
         c1grdBusqueda.DataSource = bs_eabas_docscompra
         bnavBusqueda.BindingSource = bs_eabas_docscompra
         AddHandler bs_eabas_docscompra.CurrentChanged, AddressOf bs_abas_dosccompra_CurrentChanged
         bs_abas_dosccompra_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region
#End Region

#Region " Metodos de Controles"

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If rbtnDatos.Checked Then
            txtBusqueda_ACAyudaClick(Nothing, Nothing)
         ElseIf rbtnDocVenta.Checked Then
            txtBusNumero_ACAyudaClick(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede realizar la consulta", ex)
      End Try
   End Sub

   Private Sub rbtnDatos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnDatos.CheckedChanged
      grpCliente.Enabled = rbtnDatos.Checked
      grpDocumentos.Enabled = rbtnDocVenta.Checked
   End Sub

   Private Sub actool_ACBtnRehusar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnRehusar_Click
      Try
         SetControles(True)
         ACUtilitarios.ACSetControl(pnlCabecera, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         actool.ACBtnRehusarVisible = False
         bs_series_CurrentChanged(Nothing, Nothing)
         m_etran_guiastransportista.Instanciar(ACEInstancia.Nuevo)
         m_etran_guiastransportista.GTRAN_Estado = ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Ingresado)
         txtDVSerie.Clear()
         actxnDVNumero.Clear()
         actool.ACBtnImprimirEnabled = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Rehusar Documento", ex)
      End Try
   End Sub

 
#Region "Ayudas"

   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda para los registros de compra", ex)
      End Try
   End Sub

   Private Sub txtBusNumero_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusNumero.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text, True)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda para los registros de compra", ex)
      End Try
   End Sub

   Private Sub actxaDescConductor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescConductor.ACAyudaClick
      Try
         AyudaEntidad(actxaDescConductor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Conductores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar conductoR", ex)
      End Try
   End Sub

   Private Sub actxaCodVehiculo_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCodVehiculo.ACAyudaClick
      'Try
      '   AyudaVehiculo(actxaCodVehiculo.Text, "VEHIC_Id")
      'Catch ex As Exception
      '   ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Vehiculo", ex)
      'End Try
   End Sub

   Private Sub actxaDescVehiculo_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescVehiculo.ACAyudaClick
      Try
         AyudaVehiculo(actxaDescVehiculo.Text, "VEHIC_Placa")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar veHiculo", ex)
      End Try
   End Sub

   Private Sub actxaCodConductor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocConductor.ACAyudaClick
      Try
         AyudaEntidad(actxaDescConductor.Text, "ENTID_Codigo", EEntidades.TipoEntidad.Conductores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Conductor", ex)
      End Try
   End Sub

   Private Sub actxaDescTransportista_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescTransportista.ACAyudaClick
      Try
         AyudaEntidad(actxaDescTransportista.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Transportista)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Transportista", ex)
      End Try
   End Sub

   Private Sub actxaCodTransportista_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocTransportista.ACAyudaClick
      Try
         AyudaEntidad(actxaNroDocTransportista.Text, "ENTID_Codigo", EEntidades.TipoEntidad.Transportista)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar transportista", ex)
      End Try
   End Sub

#End Region

#Region "toolbar"

   Private Sub actool_ACBtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnImprimir_Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Imprimir Guia: {0}", Me.Text) _
             , String.Format("Desea imprimir la Guia: {0}-{1}", m_etran_guiastransportista.GTRAN_Serie, m_etran_guiastransportista.GTRAN_Numero.ToString("0000000")) _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            Dim _print As New Impresion(tscmbImpresora.Text)
            _print.Print_GuiaTransportista(CType(bs_eabas_docscompra.Current, ETRAN_GuiasTransportista).GTRAN_Codigo)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Imprimir Guia", ex)
      End Try
   End Sub

   Private Sub actsbtnPrevisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actsbtnPrevisualizar.Click
      Try
         Dim x_gtran_codigo As String = CType(bs_eabas_docscompra.Current, ETRAN_GuiasTransportista).GTRAN_Codigo
         Dim m_bGenerarGuias As New ACBTransporte.BGenerarGuias()
         If m_bGenerarGuias.GuiaTransportista(x_gtran_codigo, ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Anulado)) Then
            Dim m_bdetaguia As New BTRAN_GuiasTransportistaDetalles()
            Dim _detwhere As New Hashtable()
            _detwhere.Add("GTRAN_Codigo", New ACWhere(x_gtran_codigo, ACWhere.TipoWhere.Igual))
            If m_bdetaguia.CargarTodos(_detwhere) Then
               m_bGenerarGuias.TRAN_GuiasTransportista.ListETRAN_GuiasTransportistaDetalles = m_bdetaguia.ListTRAN_GuiasTransportistaDetalles
               m_etran_guiastransportista = m_bGenerarGuias.TRAN_GuiasTransportista

               actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               setInstancia(ACUtilitarios.ACSetInstancia.Previsualizar)

               tabMantenimiento.SelectedTab = tabDatos

               cmbDestinoDepartamento.SelectedValue = m_etran_guiastransportista.UBIGO_CodigoDestinatario.Substring(0, 2)
               cmbDestinoProvincia.SelectedValue = m_etran_guiastransportista.UBIGO_CodigoDestinatario.Substring(0, 5)

               cmbOrigenDepartamento.SelectedValue = m_etran_guiastransportista.UBIGO_CodigoDestinatario.Substring(0, 2)
               cmbOrigenProvincia.SelectedValue = m_etran_guiastransportista.UBIGO_CodigoDestinatario.Substring(0, 5)

               If Not IsNothing(m_etran_guiastransportista.GTRAN_NroComprobantePago) Then
                  cmbDocVenta.SelectedValue = String.Format("{0}{1}", ETipos.getCodTipo(ETipos.MyTipos.TipoDocComprobante), m_etran_guiastransportista.GTRAN_NroComprobantePago.Substring(0, 2))
                  txtDVSerie.Text = m_etran_guiastransportista.GTRAN_NroComprobantePago.Substring(2, 3)
                  actxnDVNumero.Text = m_etran_guiastransportista.GTRAN_NroComprobantePago.Substring(5)
               End If

               actxaDescTransportista.Text = m_etran_guiastransportista.ENTID_Transportista
               actxaDescConductor.Text = m_etran_guiastransportista.ENTID_Conductor
               txtLicencia.Text = m_etran_guiastransportista.CONDU_Licencia
               If IsNothing(m_etran_guiastransportista.RANFL_Certificado) Then
                  txtCertificado.Text = String.Format("{0}", m_etran_guiastransportista.VEHIC_Certificado)
               Else
                  txtCertificado.Text = String.Format("{0}/{1}", m_etran_guiastransportista.VEHIC_Certificado, m_etran_guiastransportista.RANFL_Certificado)
               End If

               actxaDescVehiculo.Text = m_etran_guiastransportista.GTRAN_DescripcionVehiculo

               actxaRucDestinatario.Text = Parametros.GetParametro(EParametros.TipoParametros.Empresa)
               actxaRazSocDestinatario.Text = Parametros.GetParametro(EParametros.TipoParametros.EmpresaRS)

               AsignarBinding()

               bs_etran_guiastransportistadetalle = New BindingSource
               bs_etran_guiastransportistadetalle.DataSource = m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles
               bnavProductos.BindingSource = bs_etran_guiastransportistadetalle
               c1grdDetalle.DataSource = bs_etran_guiastransportistadetalle
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro, posiblemente haya errores en su creacion")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro, posiblemente haya errores en su creacion")
         End If
      Catch ex As Exception
         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso previsualizar", ex)
      End Try
   End Sub

   Private Sub actool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If ACUtilitarios.ACDatosOk(pnlDatos, msg) And Validar(msg) Then
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Grabar Registro: {0}", Me.Text) _
                         , String.Format("Desea Grabar la Guia de Remision : {0}-{1}, por un peso de : {2} Kg.", cmbSerie.Text _
                                         , actxnNumero.Text.PadLeft(7, "0"), actxnPesoTotal.Text) _
                         , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
               m_etran_guiastransportista.TIPOS_CodTipoDocumento = cmbGuia.SelectedValue
               m_etran_guiastransportista.GTRAN_Codigo = String.Format("{0}{1}{2}", m_etran_guiastransportista.TIPOS_CodTipoDocumento.Substring(3), m_etran_guiastransportista.GTRAN_Serie, m_etran_guiastransportista.GTRAN_Numero.ToString("0000000"))
               m_etran_guiastransportista.SUCUR_Id = GApp.Sucursal
               m_etran_guiastransportista.ZONAS_Codigo = GApp.Zona
               m_etran_guiastransportista.GTRAN_Serie = cmbSerie.SelectedValue
               m_etran_guiastransportista.GTRAN_DireccionDestinatario = cmbDirDestino.Text
               If Not IsNothing(cmbDocVenta.SelectedValue) Then
                  m_etran_guiastransportista.GTRAN_NroComprobantePago = String.Format("{0}{1}{2}", cmbDocVenta.SelectedValue.ToString().Substring(3, 2) _
                                                                                   , txtDVSerie.Text.PadLeft(3, "0"), actxnDVNumero.Text.ToString().PadLeft(7, "0"))
               End If

               managerGenerarGuias.TRAN_GuiasTransportista = m_etran_guiastransportista
               If managerGenerarGuias.Guardar(GApp.Usuario) Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("Se va ha imprimir la Guia Nro: {0}, coloque la guia en la impresora: {1}", m_etran_guiastransportista.NroGuia, tscmbImpresora.Text))
                  Dim _print As New Impresion(tscmbImpresora.Text)
                  Try
                     If _print.Print_GuiaTransportista(m_etran_guiastransportista.GTRAN_Codigo) Then
                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado/Impreso satisfactoriamente")
                     Else
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente", "No se Imprimio el documento, puede intentarlo nuevamente")
                     End If
                  Catch ex As Exception
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente", "No se Imprimio el documento, puede intentarlo nuevamente" & vbNewLine & ex.Message)
                  End Try
                  actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
                  setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
                  tabMantenimiento.SelectedTab = tabBusqueda

                  btnConsultar_Click(Nothing, Nothing)
               End If
            Else
               actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            End If
         Else
            actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede grabar", msg)
         End If
      Catch ex As Exception
         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso grabar Guia de Remision", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cancelar la Cotización/Pedido", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actool.ACBtnNuevo_Click
      Try
         If Not nuevaGuia() Then
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede generar una nueva Guia de Remision")
         End If
         '' Activar las opciones generales del teclado
         KeyPreview = True
      Catch ex As Exception
         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nueva Cotización/Pedido", ex)
      End Try
   End Sub

#End Region

#Region " Textos "
   Private Sub actxaNroDocTransportista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocTransportista.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocTransportista.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocTransportista.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocTransportista.Text, EEntidades.TipoInicializacion.Transportista) Then
                     actxaNroDocTransportista.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     m_etran_guiastransportista.ENTID_CodigoTransportista = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescTransportista.Text = managerEntidades.Entidades.ENTID_RazonSocial
                     lblNomConductor.Focus()
                  Else
                     If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                     , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaNroDocTransportista.Text) _
                                     , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        NuevaEntidad(actxaNroDocTransportista.Text, EEntidades.TipoEntidad.Transportista)
                     Else
                        actxaNroDocTransportista.Clear() : actxaDescTransportista.Clear() : lblNomConductor.Focus()
                     End If
                  End If
               End If
            Else
               If actxaNroDocTransportista.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocTransportista.Text))
                  lblNomConductor.Focus()
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaNroDocConductor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocConductor.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocConductor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocConductor.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocConductor.Text, EEntidades.TipoInicializacion.Transportista) Then
                     actxaNroDocConductor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     m_etran_guiastransportista.ENTID_CodigoConductor = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescConductor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                     lblDescVehiculo.Focus()
                  Else
                     If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                     , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaNroDocTransportista.Text) _
                                     , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        NuevaEntidad(actxaNroDocTransportista.Text, EEntidades.TipoEntidad.Conductores)
                     Else
                        actxaNroDocConductor.Clear() : actxaDescConductor.Clear() : lblDescVehiculo.Focus()
                     End If
                  End If
               End If
            Else
               If actxaNroDocConductor.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocConductor.Text))
                  lblNomConductor.Focus()
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

#End Region

#Region " Grillas "
   Private Sub c1grdBusqueda_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles c1grdBusqueda.MouseDoubleClick
      If Not CType(bs_eabas_docscompra.Current, EABAS_DocsCompra).DOCCO_Estado = EABAS_DocsCompra.getEstado(EABAS_DocsCompra.Estado.Anulado) Then
         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         acTool_ACBtnNuevo_Click(Nothing, Nothing)
      End If

   End Sub

   Private Sub c1grdBusqueda_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdBusqueda.BeforeSort
      Try
         Ordenar(c1grdBusqueda.Cols(e.Col).UserData)
         c1grdBusqueda.Subtotal(AggregateEnum.Clear)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub

   Private Sub c1grdBusqueda_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdBusqueda.OwnerDrawCell
      Try
         If e.Row < c1grdBusqueda.Rows.Fixed OrElse e.Col < c1grdBusqueda.Cols.Fixed Then Return
         If c1grdBusqueda.Rows(e.Row)("DOCCO_Estado") = EABAS_DocsCompra.getEstado(EABAS_DocsCompra.Estado.Anulado) Then
            e.Style = c1grdBusqueda.Styles("Anulado")
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub c1grdDetalle_AfterEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles c1grdDetalle.AfterEdit
      Try
         Me.KeyPreview = False
         If c1grdDetalle.Cols(e.Col).Name = "GTDET_Cantidad" And e.Row > (c1grdDetalle.Rows.Fixed - 1) Then
            If IsNumeric(c1grdDetalle.Rows(e.Row)(e.Col).ToString()) Then
               Dim _act As Boolean = False
               Dim _cantidad As Decimal = c1grdDetalle.Rows(e.Row)("GTDET_Cantidad")
               'Dim _cantidadTotal As Decimal = c1grdDetalle.Rows(e.Row)("INGCD_CantidadTotal")
               Dim _pendiente As Decimal = c1grdDetalle.Rows(e.Row)("Diferencia")
               If _cantidad = _pendiente Then
                  _act = True
                  CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Cantidad = _cantidad
               ElseIf _cantidad > _pendiente Then
                  c1grdDetalle.Rows(e.Row)("GTDET_Cantidad") = c1grdDetalle.Rows(e.Row)("Diferencia")
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "La cantidad supera el maximo definido")
               ElseIf _cantidad > 0 And _cantidad <= _pendiente Then
                  _act = True
                  CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Cantidad = _cantidad
               ElseIf _cantidad < 0 Then
                  c1grdDetalle.Rows(e.Row)("Diferencia") = 0
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "La cantidad supera el minimo definido")
               End If
               calcular()
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso verificar cantidad registrada", ex)
      End Try
   End Sub

   Private Sub c1grdDetalle_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdDetalle.OwnerDrawCell
      Try
         If e.Row < c1grdDetalle.Rows.Fixed OrElse e.Col < c1grdDetalle.Cols.Fixed Then Return
         If c1grdDetalle.Cols(e.Col).Name = "TotalDoc" Then
            e.Style = c1grdDetalle.Styles("Total")
         End If
         If c1grdDetalle.Cols(e.Col).Name = "GTDET_Cantidad" Then
            e.Style = c1grdDetalle.Styles("Cantidad")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso colorear columna", ex)
      End Try
   End Sub
#End Region

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         'If sender.Name = "txtBusqueda" Then
         '   Exit Sub
         'End If
         'If TypeOf ActiveControl Is ACControles.ACTextBoxAyuda Then
         '   Exit Sub
         'End If
         SendKeys.Send("{TAB}")
      End If
   End Sub

   Private Sub btnNueTransportista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNueTransportista.Click
      NuevaEntidad("", EEntidades.TipoEntidad.Transportista)
   End Sub

   Private Sub btnNuevConductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevConductor.Click
      NuevaEntidad("", EEntidades.TipoEntidad.Conductores)
   End Sub


#End Region

   Private Sub txtNumeroPedido_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         actool_ACBtnGrabar_Click(Nothing, Nothing)
      End If
   End Sub

   Private Sub c1grdDetalle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1grdDetalle.LostFocus
      Me.KeyPreview = True
   End Sub

   Private Sub tscmbImpresora_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmbImpresora.DropDown
      Try
         If IsNothing(Colecciones.ListPrinter) Then
            Colecciones.CargarImpresoras()
         End If
         ACFramework.ACUtilitarios.ACCargaCombo(tscmbImpresora.ComboBox, Colecciones.ListPrinter, "DeviceName", "DeviceName")
      Catch ex As Exception

      End Try
   End Sub

End Class