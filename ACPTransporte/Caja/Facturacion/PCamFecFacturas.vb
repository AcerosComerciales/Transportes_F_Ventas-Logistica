Imports ACBTransporte
Imports ACETransporte
Imports C1.Win.C1FlexGrid
Imports ACEVentas
Imports ACFramework

Public Class PCamFecFacturas
#Region " Variables "
   Private managerTRAN_Documentos As BTRAN_Documentos
   Private bs_documentos As BindingSource
   Private bs_moneda As BindingSource
   Private bs_tdocbus As BindingSource

   Private m_listBindHelper As List(Of ACBindHelper)

   Private m_order As Integer = 1
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         managerTRAN_Documentos = New BTRAN_Documentos

         actxaCliRuc.ACAyuda.Enabled = False
         actxaCliRazonSocial.ACAyuda.Enabled = False
         cargarCombos()
         formatearGrilla()
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)

         acTool.ACBtnSalirVisible = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
#Region " Utilitarios "
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 11, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "DOCUS_Fecha", "DOCUS_Fecha", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Cliente", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cliente", "ENTID_Cliente", "ENTID_Cliente", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Total Pagar", "DOCUS_TotalPago", "DOCUS_TotalPago", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCUS_Estado", "DOCUS_Estado", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCUS_Estado_Text", "DOCUS_Estado_Text", 150, True, False, "System.String") : index += 1
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

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargarCombos()
      Try
         bs_moneda = New BindingSource() : bs_moneda.DataSource = Colecciones.Tipos(ETipos.MyTipos.TipoMoneda)
         ACUtilitarios.ACCargaCombo(cmbMoneda, bs_moneda, "TIPOS_Descripcion", "TIPOS_Codigo")

         bs_tdocbus = New BindingSource() : bs_tdocbus.DataSource = Colecciones.TiposDocComprobante()
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, bs_tdocbus, "TIPOS_Descripcion", "TIPOS_Codigo")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
      Try

         Select Case _opcion
            Case ACUtilitarios.ACSetInstancia.Nuevo
               ACUtilitarios.ACSetControl(pnlCabecera, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
            Case ACUtilitarios.ACSetInstancia.Deshacer
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               acTool.ACBtnBuscarVisible = False
               actsbtnCancelacion.Visible = True
               acTool.ACBtnImprimirVisible = False
               tabMantenimiento.SelectedTab = tabBusqueda
               acTool.ACBtnImprimirEnabled = True
               txtDireccion.Visible = False
               cmbDirecciones.Visible = True
               actsbtnCancelacion.Visible = False
            Case ACUtilitarios.ACSetInstancia.Modificado
               ACFramework.ACUtilitarios.ACSetControl(grpCabCuerpo, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
               actxaCliRazonSocial.ACAyuda.Enabled = False
               actxaCliRazonSocial.ACActivarAyuda = False
               acTool.ACBtnImprimirVisible = True
               actxaCliRuc.ACAyuda.Enabled = False
               actxaCliRuc.ACActivarAyuda = False
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               acTool.ACBtnGrabarVisible = False
               txtDireccion.Visible = True
               cmbDirecciones.Visible = False
               tabMantenimiento.SelectedTab = tabDatos
               actsbtnCancelacion.Visible = True
               acTool.ACBtnImprimirVisible = False
               DateTimePicker1.Enabled = True
         End Select

      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbDocumento, "SelectedValue", managerTRAN_Documentos.TRAN_Documentos, "TIPOS_CodTipoDocumento"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", managerTRAN_Documentos.TRAN_Documentos, "TIPOS_CodTipoMoneda"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtSerie, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_Serie"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_Numero"))
         If managerTRAN_Documentos.TRAN_Documentos.DOCUS_Fecha.Year < 1700 Then managerTRAN_Documentos.TRAN_Documentos.DOCUS_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecFacturacion, "Value", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_Fecha"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnImporte, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_Importe"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnIGV, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_ImporteIGV"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotalPagar, "Text", managerTRAN_Documentos.TRAN_Documentos, "DOCUS_TotalPago"))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function busquedaCliente(ByVal x_cadena As String) As Boolean
      Try
         Dim m_return As Boolean
         'If txtBusqueda.ACEstadoAutoAyuda Then
         If managerTRAN_Documentos.getCliente(x_cadena, "ENTID_Nombres", chkTodos.Checked, True, AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date.AddDays(1)) Then
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
            bs_documentos.DataSource = managerTRAN_Documentos.ListTRAN_Documentos
         Else
            managerTRAN_Documentos.ListTRAN_Documentos = New List(Of ETRAN_Documentos)
            bs_documentos.DataSource = managerTRAN_Documentos.ListTRAN_Documentos
         End If
         c1grdBusqueda.DataSource = bs_documentos
         bnavBusqueda.BindingSource = bs_documentos
         AddHandler bs_documentos.CurrentChanged, AddressOf bs_tran_documentos_CurrentChanged
         bs_tran_documentos_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of ETRAN_Documentos)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_documentos.DataSource, List(Of ETRAN_Documentos)).Sort(_ordenador)
         c1grdBusqueda.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
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

   Private Sub c1grdBusqueda_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdBusqueda.OwnerDrawCell
      Try
         If e.Row < c1grdBusqueda.Rows.Fixed OrElse e.Col < c1grdBusqueda.Cols.Fixed Then Return
         If c1grdBusqueda.Rows(e.Row)("DOCUS_Estado") = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado) Then
            e.Style = c1grdBusqueda.Styles("Anulado")
         End If
         If c1grdBusqueda.Rows(e.Row)("DOCUS_Estado") = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Confirmado) Then
            e.Style = c1grdBusqueda.Styles("Facturar")
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         txtBusqueda_ACAyudaClick(Nothing, Nothing)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso consultar documentos", ex)
      End Try
   End Sub

   Private Sub bs_tran_documentos_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_documentos.Current) Then
            If CType(bs_documentos.Current, ETRAN_Documentos).DOCUS_Estado = ETRAN_Documentos.getEstado(ETRAN_Documentos.Estado.Anulado) Then
               acTool.ACBtnAnularEnabled = False
            Else
               acTool.ACBtnAnularEnabled = True
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub c1grdBusqueda_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdBusqueda.BeforeSort
      Try
         Ordenar(c1grdBusqueda.Cols(e.Col).UserData)
         c1grdBusqueda.Subtotal(AggregateEnum.Clear)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click
      setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
      Try

      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Generar Documento de Venta", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnModificar_Click
      Try
         cargar(CType(bs_documentos.Current, ETRAN_Documentos).DOCUS_Codigo, CType(bs_documentos.Current, ETRAN_Documentos).ENTID_Codigo)
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Generar Documento de Venta", ex)
      End Try
   End Sub

   Private Sub cargar(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String)
      Try
         If managerTRAN_Documentos.CargarDocumento(x_docus_codigo, x_entid_codigo, False) Then
            AsignarBinding()
            actxaCliRuc.Text = managerTRAN_Documentos.TRAN_Documentos.ENTID_NroDocumento
            actxaCliRazonSocial.Text = managerTRAN_Documentos.TRAN_Documentos.ENTID_Cliente
            txtDireccion.Text = managerTRAN_Documentos.TRAN_Documentos.ENTID_Direccion
            setInstancia(ACUtilitarios.ACSetInstancia.Modificado)
         Else
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("01005")))
         End If
      Catch ex As Exception
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
         Throw ex
      End Try
   End Sub

   Private Sub actsbtnCancelacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actsbtnCancelacion.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Generar Cancelación: {0}", Me.Text) _
                                        , String.Format("¿Generar la Cancelación de los Documentos Seleccionados? ") _
                                        , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            If managerTRAN_Documentos.GenCancelacion(GApp.Usuario, DateTimePicker1.Value) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("01000")))
               setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
               btnConsultar_Click(Nothing, Nothing)
            Else
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), "Grabar, existen errores"))
            End If
         End If
      Catch ex As Exception
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Grabar Cancelación", ex)
      End Try
   End Sub

   Private Sub c1grdBusqueda_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdBusqueda.DoubleClick
      acTool_ACBtnModificar_Click(Nothing, Nothing)
      acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
      acTool.ACBtnGrabarVisible = False
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


   Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub
End Class