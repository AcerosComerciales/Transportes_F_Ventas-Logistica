Imports ACFramework
Imports ACEVentas
Imports ACBVentas
Imports ACETransporte
Imports ACBTransporte
Imports C1.Win.C1FlexGrid

Public Class PViajesVentas
#Region " Variables "
   Private managerAdministracionViajes As BAdministracionViajes
   Private managerGenerarDocsVenta As BGenerarDocsVentaTrans
   Private managerVENT_DocsVenta As BVENT_DocsVenta
   Private managerEntidades As BEntidades
   Private m_eentidades As EEntidades

   Private bs_moneda As BindingSource
   Private bs_series As BindingSource
   Private bs_documentos As BindingSource
   Private bs_tdoc As BindingSource
   Private bs_tdocbus As BindingSource
   Private bs_viajesventas As BindingSource

   Private m_order As Integer = 1

   Private _frmViajes As CViajes
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         setInicio(False)
         cargarCombos()
         formatearGrilla()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
#Region " Utilitarios "
   Private Sub cargarCombos()
      Try
         '' Moneda
         bs_moneda = New BindingSource() : bs_moneda.DataSource = Colecciones.Tipos(ETipos.MyTipos.TipoMoneda)
         ACUtilitarios.ACCargaCombo(cmbMoneda, bs_moneda, "TIPOS_Descripcion", "TIPOS_Codigo")

         '' Documento de Venta 
         Dim listDoc As New List(Of ETipos)
         Dim listDocBus As New List(Of ETipos)
         For Each Item As ETipos In Colecciones.TiposDocComprobante()
            listDoc.Add(Item.Clone)
            listDocBus.Add(Item.Clone)
         Next
         bs_tdoc = New BindingSource() : bs_tdoc.DataSource = listDoc
         bs_tdocbus = New BindingSource() : bs_tdocbus.DataSource = listDocBus : AddHandler bs_tdocbus.CurrentChanged, AddressOf bs_tdocbus_CurrentChanged
         bs_tdocbus_CurrentChanged(Nothing, Nothing)

         ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, bs_tdoc, "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoDocumento, bs_tdocbus, "TIPOS_Descripcion", "TIPOS_Codigo")
         '' Resto
         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.Admin_16x16.GetHicon)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 13, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cotizador", "Usuario", "Usuario", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Cliente", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cliente", "ENTID_Cliente", "ENTID_Cliente", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Total Pagar", "DOCVE_TotalPagar", "DOCVE_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Condición", "TIPOS_CondicionPago", "TIPOS_CondicionPago", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCVE_Estado", "DOCVE_Estado", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCVE_Estado_Text", "DOCVE_Estado_Text", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Vendedor", "ENTID_Vendedor", "ENTID_Vendedor", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Facturar", "PEDID_ParaFacturar", "PEDID_ParaFacturar", 150, False, False, "System.Boolean") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.AutoResize = True
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         'c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdBusqueda.AllowResizing = AllowResizingEnum.Columns

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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 12, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Viaje", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Código", "FLETE_Id", "FLETE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Cliente", "ENTID_RazonSocial", "ENTID_RazonSocial", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Peso T.M.", "FLETE_PesoEnTM", "FLETE_PesoEnTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Monto x TM", "FLETE_MontoPorTM", "FLETE_MontoPorTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "I.G.V.", "FLETE_ImporteIgv", "FLETE_ImporteIgv", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Total Flete", "FLETE_TotIngreso", "FLETE_TotIngreso", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Salida", "FLETE_FecSalida", "FLETE_FecSalida", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Llegada", "FLETE_FecLlegada", "FLETE_FecLlegada", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Descripción", "FLETE_Glosa", "FLETE_Glosa", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Viaje", "VIAJE_Descripcion", "VIAJE_Descripcion", 250, True, False, "System.String") : index += 1
         c1grdDetalle.AllowEditing = False
         c1grdDetalle.AutoResize = True
         c1grdDetalle.Cols(0).Width = 18
         c1grdDetalle.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDetalle.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDetalle.Styles.Highlight.BackColor = Color.Gray
         c1grdDetalle.SelectionMode = SelectionModeEnum.Row
         c1grdDetalle.AllowResizing = AllowResizingEnum.Columns
         'c1grdDetalle.VisualStyle = VisualStyle.Office2007Blue
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
      Try
         acTool.ACBtnRehusarVisible = False
         acTool.ACBtnImprimirVisible = False
         Select Case _opcion
            Case ACUtilitarios.ACSetInstancia.Nuevo
              
            Case ACUtilitarios.ACSetInstancia.Modificado
               ACUtilitarios.ACLimpiaVar(pnlCabecera)
               ACTool.ACBtnImprimirVisible = False
               ACTool.ACBtnAnularVisible = False
               ACTool.ACBtnImprimirVisible = False

               cmbDirecciones.DataSource = Nothing
               txtDireccion.Visible = False
               cmbDirecciones.Visible = True
               tabMantenimiento.SelectedTab = tabDatos
            Case ACUtilitarios.ACSetInstancia.Guardar
               txtBusqueda.Focus()
            Case ACUtilitarios.ACSetInstancia.Deshacer
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               ACTool.ACBtnBuscarVisible = False
               'actsbtnPrevisualizar.Visible = True
               ACTool.ACBtnImprimirVisible = False
               tabMantenimiento.SelectedTab = tabBusqueda
               acTool.ACBtnImprimirEnabled = True
               txtDireccion.Visible = False
               cmbDirecciones.Visible = True
               ACTool.ACBtnModificarVisible = True
               tabMantenimiento.SelectedTab = tabBusqueda
               _frmViajes = Nothing
            Case ACUtilitarios.ACSetInstancia.Previsualizar
               actxaCliRazonSocial.ACAyuda.Enabled = False
               actxaCliRazonSocial.ACActivarAyuda = False
               acTool.ACBtnImprimirVisible = True
               actxaCliRuc.ACAyuda.Enabled = False
               actxaCliRuc.ACActivarAyuda = False
               ACTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               acTool.ACBtnGrabarVisible = False
               'actsbtnPrevisualizar.Visible = False
               txtDireccion.Visible = True
               cmbDirecciones.Visible = False
         End Select
         ACTool.ACBtnNuevoVisible = False
         ACTool.ACBtnEliminarVisible = False
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of EVENT_DocsVenta)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_documentos.DataSource, List(Of EVENT_DocsVenta)).Sort(_ordenador)
         c1grdBusqueda.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

   Private Sub setInicio(ByVal x_opcion As Boolean)
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         managerEntidades = New BEntidades
         managerAdministracionViajes = New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
         managerGenerarDocsVenta = New BGenerarDocsVentaTrans(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
         managerVENT_DocsVenta = New BVENT_DocsVenta

         ACUtilitarios.ACSetControl(pnlCabecera, Not x_opcion, ACUtilitarios.TipoPropiedad.ACReadOnly)
         actxaCliRazonSocial.ACAyuda.Enabled = x_opcion
         actxaCliRuc.ACAyuda.Enabled = x_opcion

         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function busquedaCliente(ByVal x_cadena As String) As Boolean
      Try
         Dim m_return As Boolean
         'If txtBusqueda.ACEstadoAutoAyuda Then
         If managerVENT_DocsVenta.getCliente(x_cadena, "ENTID_Nombres", chkTodos.Checked, True, AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date.AddDays(1), GApp.PuntoVenta) Then
            cargarDatos(True)
         Else
            cargarDatos(False)
         End If
         'End If
         Return m_return
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Sub cargarDatos(ByVal x_opcion As Boolean)
      Try
         bs_documentos = New BindingSource()
         If x_opcion Then
            bs_documentos.DataSource = managerVENT_DocsVenta.ListVENT_DocsVenta
         Else
            managerVENT_DocsVenta.ListVENT_DocsVenta = New List(Of EVENT_DocsVenta)
            bs_documentos.DataSource = managerVENT_DocsVenta.ListVENT_DocsVenta
         End If
         c1grdBusqueda.DataSource = bs_documentos
         bnavBusqueda.BindingSource = bs_documentos
         AddHandler bs_documentos.CurrentChanged, AddressOf bs_docsventa_CurrentChanged
         bs_docsventa_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function busquedaDocumentos(ByVal x_cadena As String) As Boolean
      Try
         Dim m_return As Boolean
         'If txtBusqueda.ACEstadoAutoAyuda Then
         If managerVENT_DocsVenta.getDocumentos(ComboBox2.SelectedValue, IIf(txtBusNumero.Text.Equals(""), "0", txtBusNumero.Text), chkTodos.Checked, cmbTipoDocumento.SelectedValue) Then
            cargarDatos(True)
         Else
            cargarDatos(False)
         End If
         'End If
         Return m_return
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function
#End Region

#Region " Metodos de Controles"
#Region " Ayudas "
   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busquedaCliente(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de clientes", ex)
      End Try
   End Sub
#End Region

#Region " Binding "
   Private Sub bs_docsventa_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_documentos.Current) Then
            If CType(bs_documentos.Current, EVENT_DocsVenta).DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado) Then
               acTool.ACBtnAnularEnabled = False
            Else
               acTool.ACBtnAnularEnabled = True
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub bs_tdocbus_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_tdocbus.Current) Then
            '' Cargar las series
            If managerGenerarDocsVenta.GetSeries(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, CType(bs_tdocbus.Current, ETipos).TIPOS_Codigo, GApp.Aplicacion) Then
               ACFramework.ACUtilitarios.ACCargaCombo(ComboBox2, managerGenerarDocsVenta.ListVENT_PVentDocumento, "PVDOCU_Serie", "PVDOCU_Serie")
               ComboBox2.Enabled = True
            Else
               ComboBox2.SelectedIndex = -1
               ComboBox2.Enabled = False
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub
#End Region

#Region " Grillas "
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
         If c1grdBusqueda.Rows(e.Row)("DOCVE_Estado") = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado) Then
            e.Style = c1grdBusqueda.Styles("Anulado")
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub c1grdDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1grdDetalle.KeyDown
      Try
         Select Case e.KeyCode
            'Case Keys.Delete
            '   If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
            '       , String.Format("¿Desea quitar el Registro Seleccionado?") _
            '       , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            '      Dim m_det As EVENT_DocsVentaDetalle = CType(bs_detdocumentoventa.Current, EVENT_DocsVentaDetalle)
            '      managerGenerarDocsVenta.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Remove(m_det)
            '      bs_detdocumentoventa.ResetBindings(False)
            '      calcular()
            '   End If
            'Case Keys.Enter
            '   SubirItem()
            '   'SendKeys.Send("{F4}")
            '   c1grdDetalle.Enabled = False
            '   lblCantidad.Focus()
            '   m_modArticulo = True
            'Case Else
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede calcular carga el Item", ex)
      End Try
   End Sub
#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If rbtnCliente.Checked Then
            txtBusqueda_ACAyudaClick(Nothing, Nothing)
         ElseIf rbtnNroCotizacion.Checked Then
            txtBusNumero_ACAyudaClick(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso consultar documentos", ex)
      End Try
   End Sub

   Private Sub txtBusNumero_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusNumero.ACAyudaClick
      Try
         busquedaDocumentos(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de documentos", ex)
      End Try
   End Sub

   Private Sub AcFecha_ACFecIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecIni_KeyDown
      If e.KeyData = Keys.Enter Then
         AcFecha.ACDtpFecha_A.Focus()
      End If
   End Sub

   Private Sub AcFecha_ACFecFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecFin_KeyDown
      If e.KeyData = Keys.Enter Then
         btnConsultar_Click(Nothing, Nothing)
      End If
   End Sub
#End Region

   Private Sub ACTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ACTool.ACBtnCancelar_Click
      setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
   End Sub

   Private Sub ACTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ACTool.ACBtnGrabar_Click
      Try
         If managerAdministracionViajes.GuardarVentasFletes(GApp.Usuario) Then
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
            ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("01000"))) '
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Grabar"), ex)
      End Try
   End Sub

   Private Sub ACTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ACTool.ACBtnModificar_Click
      Try
         If Not IsNothing(bs_documentos) Then
            If Not IsNothing(bs_documentos.Current) Then
               Cargar()
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar Factura", ex)
      End Try
   End Sub

   Private Sub Cargar()
      Try
         setInstancia(ACUtilitarios.ACSetInstancia.Modificado)
         managerAdministracionViajes.VENT_DocsVenta = New EVENT_DocsVenta
         managerAdministracionViajes.VENT_DocsVenta = CType(bs_documentos.Current, EVENT_DocsVenta)
         managerAdministracionViajes.ListTRAN_ViajesVentas = New List(Of ETRAN_ViajesVentas)
         managerAdministracionViajes.cargarVentasFletes()
         'formatearGrilla()

         bs_viajesventas = New BindingSource
         bs_viajesventas.DataSource = managerAdministracionViajes.ListTRAN_ViajesVentas
         c1grdDetalle.DataSource = bs_viajesventas
         bnavViajesVentas.BindingSource = bs_viajesventas

         managerVENT_DocsVenta.VENT_DocsVenta = New EVENT_DocsVenta
         managerVENT_DocsVenta.VENT_DocsVenta = CType(bs_documentos.Current, EVENT_DocsVenta)

         setCliente(managerAdministracionViajes.VENT_DocsVenta.ENTID_NroDocumento)

         c1grdDetalle.Subtotal(AggregateEnum.Sum, 0, -1, 4, "Total")
         c1grdDetalle.Subtotal(AggregateEnum.Sum, 0, -1, 7, "Total")

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setCliente(ByVal x_codigo As String)
      '' Cargar datos adicionales cliente
      If x_codigo.Length > 0 Then
         If managerEntidades.CargarDocIden(x_codigo, EEntidades.TipoInicializacion.Direcciones) Then
            '' Cargar datos del cliente
            m_eentidades = managerEntidades.Entidades

            Dim x_direcciones As New EDirecciones
            x_direcciones.DIREC_Id = 0
            x_direcciones.Direccion = managerEntidades.Entidades.Direccion
            x_direcciones.UBIGO_Codigo = managerEntidades.Entidades.UBIGO_Codigo
            If IsNothing(managerEntidades.Entidades.ListDirecciones) Then managerEntidades.Entidades.ListDirecciones = New List(Of EDirecciones)()
            managerEntidades.Entidades.ListDirecciones.Insert(0, x_direcciones)

            ACFramework.ACUtilitarios.ACCargaCombo(cmbDirecciones, managerEntidades.Entidades.ListDirecciones, "Direccion", "DIREC_Id")
            If managerEntidades.Entidades.ListDirecciones.Count > 0 Then
               cmbDirecciones.SelectedValue = managerEntidades.Entidades.ListDirecciones(0).DIREC_Id
            End If

            dtpFecFacturacion.Value = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento
            actxaCliRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
            actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
            cmbDirecciones.Text = managerEntidades.Entidades.ENTID_Direccion
            txtDocumento.Text = String.Format("{0}-{1:0000000}", managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Serie, managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Numero)
            actxnTotalPagar.Text = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_TotalPagar
            actxnTotalPagar.Formatear()
            lblMoneda.Focus()
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), "Cargar el Cliente"))
         End If
      End If
   End Sub

   Private Sub ACTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ACTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub tsbtnAddFlete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAddFlete.Click
      Try
         If IsNothing(_frmViajes) Then _frmViajes = New CViajes With {.WindowState = FormWindowState.Normal, .StartPosition = FormStartPosition.CenterScreen}
         If _frmViajes.ShowDialog() = Windows.Forms.DialogResult.OK Then

            For Each item As ETRAN_Fletes In _frmViajes.TRAN_Viajes.ListTRAN_Fletes
               Dim _vventas As New ETRAN_ViajesVentas
               _vventas.VIAJE_Id = item.VIAJE_Id
               _vventas.FLETE_Id = item.FLETE_Id
               _vventas.VINGR_Id = item.VINGR_Id
               _vventas.FLETE_PesoEnTM = item.FLETE_PesoEnTM
               _vventas.FLETE_MontoPorTM = item.FLETE_MontoPorTM
               _vventas.FLETE_ImporteIgv = item.FLETE_ImporteIgv
               _vventas.VIAJE_Descripcion = _frmViajes.TRAN_Viajes.VIAJE_Descripcion
               _vventas.DOCVE_Codigo = managerAdministracionViajes.VENT_DocsVenta.DOCVE_Codigo
               _vventas.ENTID_RazonSocial = item.ENTID_RazonSocial
               _vventas.FLETE_Glosa = item.FLETE_Glosa
               _vventas.FLETE_FecLlegada = item.FLETE_FecLlegada
               _vventas.FLETE_FecSalida = item.FLETE_FecSalida
               _vventas.FLETE_TotIngreso = item.FLETE_TotIngreso
               managerAdministracionViajes.ListTRAN_ViajesVentas.Add(_vventas)
            Next
            bs_viajesventas.ResetBindings(False)
            c1grdDetalle.Subtotal(AggregateEnum.Sum, 0, -1, 4, "Total")
            c1grdDetalle.Subtotal(AggregateEnum.Sum, 0, -1, 7, "Total")
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Seleccionar Viaje/Flete"), ex)
      End Try
   End Sub

   Private Sub c1grdBusqueda_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdBusqueda.DoubleClick
      ACTool_ACBtnModificar_Click(Nothing, Nothing)
      ACTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
   End Sub

   Private Sub rbtnCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCliente.CheckedChanged
      Try
         grpDocumentos.Enabled = rbtnNroCotizacion.Checked
         grpCliente.Enabled = rbtnCliente.Checked
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso seleccionar tipo de consulta", ex)
      End Try
   End Sub

   Private Sub txtBusqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnConsultar_Click(Nothing, Nothing)
      End If
   End Sub

   Private Sub txtBusNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusNumero.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnConsultar_Click(Nothing, Nothing)
      End If
   End Sub

   Private Sub tsbtnQuitarFlete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnQuitarFlete.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Registro: {0}", Me.Text) _
                      , String.Format("Desea eliminar el registro seleccionado, Flete Codigo: {0:0000000}", CType(bs_viajesventas.Current, ETRAN_ViajesVentas).FLETE_Id) _
                      , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            If managerAdministracionViajes.eliminarFlete(CType(bs_viajesventas.Current, ETRAN_ViajesVentas)) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Eliminado satisfactoriamente")
               managerAdministracionViajes.ListTRAN_ViajesVentas = New List(Of ETRAN_ViajesVentas)
               managerAdministracionViajes.cargarVentasFletes()
               'formatearGrilla()

               bs_viajesventas = New BindingSource
               bs_viajesventas.DataSource = managerAdministracionViajes.ListTRAN_ViajesVentas
               c1grdDetalle.DataSource = bs_viajesventas
               bnavViajesVentas.BindingSource = bs_viajesventas
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso quitar Flete", ex)
      End Try
   End Sub
End Class
