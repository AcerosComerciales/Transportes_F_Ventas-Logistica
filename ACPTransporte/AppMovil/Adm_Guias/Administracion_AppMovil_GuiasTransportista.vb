Public Class Administracion_AppMovil_GuiasTransportista

   '    Public Sub New()
   '   ' This call is required by the Windows Form Designer.
   '   InitializeComponent()

   '   Try
   '      Inicializacion()
   '      acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Guia de Traslado Interno - Salida por Transferencia")

   '   Catch ex As Exception
   '      ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
   '   End Try
   'End Sub

   'Private Sub Inicializacion()
   '   Try
   '      tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
   '      tabMantenimiento.SelectedTab = tabBusqueda

   '      managerEntidades = New BEntidades
   '      managerTRAN_Vehiculos = New BTRAN_Vehiculos
   '      managerGenerarGuias = New ACBTransporte.BGenerarGuias
   '      managerVENT_PVentDocumento = New BVENT_PVentDocumento
   '      managerConsultaArticulos = New BConsultaArticulos(GApp.Periodo)

   '      formatearGrilla()
   '      cargarCombos()

   '      setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)

   '      btnModConductor.Enabled = False
   '      btnModificar.Enabled = False
   '      Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACGuiaProc_16x16.GetHicon)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Sub


   '     Private Function nuevaGuia() As Boolean
   '   Try
   '      '' Cargar los detalles del producto
   '      m_etran_guiastransportista = New ETRAN_GuiasTransportista
   '      m_etran_guiastransportista.Instanciar(ACEInstancia.Nuevo)
   '      m_etran_guiastransportista.GTRAN_Estado = ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Ingresado)
   '      setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)

   '      AsignarBinding()
   '      '' Cargar direcciones destino
   '      m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles = New List(Of ETRAN_GuiasTransportistaDetalles)
   '      bs_etran_guiastransportistadetalle = New BindingSource
   '      bs_etran_guiastransportistadetalle.DataSource = m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles
   '      bnavProductos.BindingSource = bs_etran_guiastransportistadetalle
   '      c1grdDetalle.DataSource = bs_etran_guiastransportistadetalle
   '      '' Obtener el numero de serie y de guia correspondiente
   '      bs_series_CurrentChanged(Nothing, Nothing)
   '      cmbGuia.SelectedValue = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionTransportista)
   '      '' Dar la instancia de los controles de la interfaz segun el proceso
   '      tabMantenimiento.SelectedTab = tabDatos
   '      bs_almacenOrigen_CurrentChanged(Nothing, Nothing)
   '      'txtAlmaDirDestino.Clear()

   '         'cmbDirDestino.SelectedValue = GApp.ESucursal.SUCUR_Direccion
   '      'bs_almacenesDestino_CurrentChanged(Nothing, Nothing)
   '      'cmbDestinoDepartamento.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo.Substring(0, 2)
   '      'cmbDestinoProvincia.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo.Substring(0, 5)
   '      'cmbDestinoDistrito.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo

   '      Label23.Focus()
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function




   ' #Region "Formateo de grilla"

    
   ' Private Sub formatearGrilla()
   '   Dim index As Integer = 1
   '   Try
   '      ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 17, 1, 1)
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha Emisión", "GTRAN_Fecha", "GTRAN_Fecha", 150, True, False, "System.DateTime") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "GTRAN_Codigo", "GTRAN_Codigo", 150, False, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro. Guia", "NroGuia", "NroGuia", 150, True, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Comprobante", "DocComprobante", "TipoComprobante", 150, True, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha Traslado", "GTRAN_FechaTraslado", "GTRAN_FechaTraslado", 150, True, False, "System.DateTime") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Direccion Partida", "GTRAN_DireccionProveedor", "GTRAN_DireccionProveedor", 150, False, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Direccion Llegada", "GTRAN_DireccionDestinatario", "GTRAN_DireccionDestinatario", 150, False, False, "System.String") : index += 1
   '         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Remitente", "ENTID_CodigoRemitente", "ENTID_CodigoRemitente", 150, True, False, "System.String") : index += 1
   '         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Remitente", "GTRAN_DescEntidadRemitente", "GTRAN_DescEntidadRemitente", 150, True, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Transportista", "ENTID_Transportista", "ENTID_Transportista", 150, True, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Conductor", "ENTID_Conductor", "ENTID_Conductor", 150, True, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Vehiculo", "GTRAN_DescripcionVehiculo", "GTRAN_DescripcionVehiculo", 150, True, False, "System.String") : index += 1
   '         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Relacionado", "GTRAN_NroComprobantePago", "GTRAN_NroComprobantePago", 150, True, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Total Peso", "GTRAN_PesoTotal", "GTRAN_PesoTotal", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "GTRAN_Estado_Text", "GTRAN_Estado_Text", 150, True, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "GTRAN_Estado", "GTRAN_Estado", 150, False, False, "System.String") : index += 1

   '      c1grdBusqueda.AllowEditing = False
   '      c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
   '      c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
   '      c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
   '      c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
   '      c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
   '      'c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue
   '      c1grdBusqueda.SubtotalPosition = SubtotalPositionEnum.AboveData
   '      c1grdBusqueda.Tree.Column = 2

   '      Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Facturado")
   '      t.BackColor = Color.LightGreen
   '      t.ForeColor = Color.DarkBlue
   '      t.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

   '      Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Facturar")
   '      u.BackColor = Color.Green
   '      u.ForeColor = Color.White
   '      u.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

   '      Dim d As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Anulado")
   '      d.BackColor = Color.Red
   '      d.ForeColor = Color.White
   '      d.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)
   '      c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

   '      index = 1
   '      ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 6, 1, 0)
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Codigo", "ARTIC_Codigo", "ARTIC_Codigo", 110, True, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Descripción", "GTDET_Descripcion", "GTDET_Descripcion", 454, True, False, "System.String") : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Unidad", "GTDET_Unidad", "GTDET_Unidad", 80, True, False, "System.String") : index += 1
   '         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Peso", "GTDET_Peso", "GTDET_Peso", 80, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
   '      ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Cantidad", "GTDET_Cantidad", "GTDET_Cantidad", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
   '      c1grdDetalle.AllowEditing = True
   '      c1grdDetalle.AutoResize = False
   '      c1grdDetalle.Cols(0).Width = 15
   '      c1grdDetalle.ExtendLastCol = False
   '      c1grdDetalle.VisualStyle = VisualStyle.Office2007Blue
   '      c1grdDetalle.AllowSorting = AllowSortingEnum.SingleColumn

   '      c1grdDetalle.Styles.Alternate.BackColor = Color.WhiteSmoke
   '      c1grdDetalle.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
   '      c1grdDetalle.Styles.Highlight.BackColor = Color.Gray
   '      c1grdDetalle.SelectionMode = SelectionModeEnum.Row
   '      c1grdDetalle.AllowResizing = AllowResizingEnum.None
   '   Catch ex As Exception
   '      ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
   '   End Try

   'End Sub



'#End Region

End Class