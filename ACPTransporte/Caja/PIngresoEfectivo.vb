Imports ACBTransporte
Imports ACEVentas

Imports ACFramework
Imports C1.Win.C1FlexGrid
Imports ACSeguridad

Public Class PIngresoEfectivo
#Region " Variables "
   Private m_badministracioncaja As BAdministracionCaja
   Private m_tipo As ACETransporte.Constantes.TipoIngEgre

   Private bs_teso_caja As New BindingSource
   Private m_reimprimir As Boolean = False
   Private m_anular As Boolean = False
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_tipo As ACETransporte.Constantes.TipoIngEgre)

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         tsbtnAnular.Visible = False
         Inicializar(x_tipo)
         Me.KeyPreview = True
         Dim _existe As Boolean = False
         tscmbImpresora.Text = Parametros.GetParametro("pg_ImpRecibos", _existe)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub CargarIngresos()
      Try
         bs_teso_caja = New BindingSource
         If Not m_badministracioncaja.MovimientoSencillo(dtpFecha.Value.Date, GApp.PuntoVenta) Then
            m_badministracioncaja.ListTESO_Caja = New List(Of ETESO_Caja)
         End If
         bs_teso_caja.DataSource = m_badministracioncaja.ListTESO_Caja
         C1FlexGrid1.DataSource = bs_teso_caja
         BindingNavigator1.BindingSource = bs_teso_caja
         AddHandler bs_teso_caja.CurrentChanged, AddressOf bs_teso_caja_CurrentChanged
         bs_teso_caja_CurrentChanged(Nothing, Nothing)
         AcPanelCaption1.ACCaption = String.Format("Ingresos de la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
         If m_tipo = ACETransporte.Constantes.TipoIngEgre.Ingreso Then
            Me.Text = String.Format("Ingreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
            acpnlTitulo.ACCaption = String.Format("Ingreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
         Else
            Me.Text = String.Format("Egreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
            acpnlTitulo.ACCaption = String.Format("Egreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
         End If
         tsbtnAnular.Visible = m_anular
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_teso_caja_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_teso_caja.Current) Then
            If CType(bs_teso_caja.Current, ETESO_Caja).RECIB_Impresiones > 0 Then
               tsbtnImprimir.Enabled = m_reimprimir
            Else
               tsbtnImprimir.Enabled = True
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub Inicializar(ByVal x_tipo As ACETransporte.Constantes.TipoIngEgre)
      Try

         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabDatos
         tabMantenimiento.TabPages.Remove(tabBusqueda)

         formatearGrilla()

         m_badministracioncaja = New BAdministracionCaja(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta)
         txtNroRegistro.ReadOnly = True
         txtNroRegistro.Text = m_badministracioncaja.GetCorrelativo()
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)

         CargarCombos()
         CargarIngresos()

         cmbTipo.Enabled = False
         Label5.Enabled = False

         m_badministracioncaja.TESO_Caja = New ETESO_Caja
         m_badministracioncaja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)

         dtpFecha.Enabled = True

         m_tipo = x_tipo
         If x_tipo = ACETransporte.Constantes.TipoIngEgre.Ingreso Then
            m_badministracioncaja.TESO_Caja.CAJA_Serie = ACETransporte.Constantes.CAJA_SerieIngreso
            cmbTipo.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.IngresoEfectivo)
            Me.Text = String.Format("Ingreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
            acpnlTitulo.ACCaption = String.Format("Ingreso en Efectivo")
         Else
            m_badministracioncaja.TESO_Caja.CAJA_Serie = ACETransporte.Constantes.CAJA_SerieEgreso
            cmbTipo.SelectedValue = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.EgresoEfectivo)
            Me.Text = String.Format("Egreso en Efectivo")
            acpnlTitulo.ACCaption = String.Format("Egreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
            txtRecibiDe.Text = GApp.EEmpresa.EMPR_Desc
         End If

         Dim _validate As New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarProceso)
         'm_proceso_modificar = _validate.ACProceso
         _validate = New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarVariosProcesos)
         For Each item As ACSeguridad.EProcesos In _validate.ListProcesos
            Select Case item.PROC_Codigo
               Case Procesos.getProceso(Procesos.TipoProcesos.RIngEgre_Reimprimir)
                  m_reimprimir = True
               Case Procesos.getProceso(Procesos.TipoProcesos.CajaAnularIngresoEgresosEfectivo)
                  m_anular = True
            End Select
         Next
         tsbtnImprimir.Enabled = m_reimprimir
         tsbtnAnular.Visible = m_anular

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub CargarCombos()
      Try '' Documento de Venta 
         ACFramework.ACUtilitarios.ACCargaCombo(cmbMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipo, Colecciones.TiposIngEgre(), "TIPOS_Descripcion", "TIPOS_Codigo")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(C1FlexGrid1, 1, 1, 9, 1, 3)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Cod.Recibo", "RECIB_Codigo", "RECIB_Codigo", 150, True, False, "System.String", "000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "x", "RECIB_Impresa", "RECIB_Impresa", 150, True, False, "System.Boolean") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "N", "RECIB_Impresiones", "RECIB_Impresiones", 150, True, False, "System.Integer") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Importe", "CAJA_Importe", "CAJA_Importe", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Descripción", "TIPOS_Transaccion", "TIPOS_Transaccion", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Glosa", "CAJA_Glosa", "CAJA_Glosa", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Usuario", "Usuario", "Usuario", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "C.I.", "CAJA_Id", "CAJA_Id", 150, True, False, "System.String", "000000") : index += 1

         C1FlexGrid1.AllowEditing = False
         C1FlexGrid1.AutoResize = True
         C1FlexGrid1.Styles.Alternate.BackColor = Color.WhiteSmoke
         C1FlexGrid1.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         C1FlexGrid1.Styles.Highlight.BackColor = Color.Gray
         C1FlexGrid1.SelectionMode = SelectionModeEnum.Row
         C1FlexGrid1.AllowSorting = AllowSortingEnum.SingleColumn

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub

   Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
      Try
         CargarIngresos()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub

   Private Sub actxnImporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyDown
      If e.KeyData = Keys.Enter Then
         KeyPreview = False
         acTool.Focus()
         acTool.ACBtnGrabar.Select()
      End If
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click
      Me.Close()
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim _msg As String = ""
      Try
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         If ACFramework.ACUtilitarios.ACDatosOk(pnlDatos, _msg) Then
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Grabar Registro: {0}", Me.Text) _
             , "Desea grabar el registro " _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
               m_badministracioncaja.TESO_Caja.PVENT_Id = GApp.PuntoVenta
               m_badministracioncaja.TESO_Caja.ENTID_Codigo = Parametros.GetParametro(EParametros.TipoParametros.Empresa)
               m_badministracioncaja.TESO_Caja.CAJA_Fecha = dtpFecha.Value
               m_badministracioncaja.TESO_Caja.TIPOS_CodTipoMoneda = cmbMoneda.SelectedValue
               m_badministracioncaja.TESO_Caja.CAJA_Importe = actxnImporte.Text
               m_badministracioncaja.TESO_Caja.CAJA_Glosa = txtDetalle.Text
               m_badministracioncaja.TESO_Caja.TIPOS_CodTipoDocumento = cmbTipo.SelectedValue
               m_badministracioncaja.TESO_Caja.RECIB_Nombre = txtNombre.Text
               m_badministracioncaja.TESO_Caja.RECIB_Direccion = txtDireccion.Text
               m_badministracioncaja.TESO_Caja.RECIB_Documento = txtDNI.Text
               m_badministracioncaja.TESO_Caja.RECIB_De = txtRecibiDe.Text
               If (m_badministracioncaja.GuardarIngreso(GApp.Usuario, m_tipo)) Then
                  ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
                  ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                        'CargarIngresos()
                        Dim _Imprimir As New Impresion(tscmbImpresora.Text)
                        ' If _Imprimir.Print_Recibos(CType(bs_teso_caja.Current, ETESO_Caja).CAJA_NroDocumento) Then
                        If _Imprimir.Print_Recibos(m_badministracioncaja.TESO_Caja.CAJA_NroDocumento, PrintDocument1) Then

                            ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Impreso Satisfactoriamente")
                            tsbtnImprimir.Enabled = m_reimprimir
                            CargarIngresos()
                        End If
                        If Not m_tipo = ACETransporte.Constantes.TipoIngEgre.Ingreso Then
                            txtRecibiDe.Text = GApp.EEmpresa.EMPR_Desc
                        End If
                    End If
                Else

                End If
                Label3.Focus()
                Me.KeyPreview = True
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), "Completar el proceso Guardar"), _msg)
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim s As String = globales_.cabecera
        Dim s1 As String = globales_.cuerpo
        ' Dim s2 As String = globales_.pie

        'Dim MyLetraNormal As New Font("Segoe UI Light", 8) '("Lucida Sans Typewriter", 8)'Segoe UI Light
        Dim MyLetraNormal As New Font("DotumChe", 9)

        'lineas
        Dim ts As Double = s.ToString().Split(vbCrLf).Length
        Dim ts1 As Double = s1.ToString().Split(vbCrLf).Length
        'Dim ts2 As Double = s2.ToString().Split(vbCrLf).Length

        Dim y As Double = (MyLetraNormal.GetHeight(e.Graphics)) * ts
        Dim y1 As Double = (MyLetraNormal.GetHeight(e.Graphics)) * (ts + ts1)

        e.Graphics.DrawString(s, MyLetraNormal, Brushes.Black, 0, 0)
        e.Graphics.DrawString(s1, MyLetraNormal, Brushes.Black, 0, y)
        ' e.Graphics.DrawString(s2, MyLetraNormal, Brushes.Black, 0, y1)


    End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub cmbImpresora_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmbImpresora.DropDown
      Try
         If IsNothing(Colecciones.ListPrinter) Then
            Colecciones.CargarImpresoras()
         End If
         ACFramework.ACUtilitarios.ACCargaCombo(tscmbImpresora, Colecciones.ListPrinter, "DeviceName", "DeviceName")
      Catch ex As Exception

      End Try
   End Sub
#End Region

   Private Sub tsbtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAnular.Click
      Try
         m_badministracioncaja.TESO_Caja = New ETESO_Caja
         m_badministracioncaja.TESO_Caja = CType(bs_teso_caja.Current, ETESO_Caja)
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Anular Registro: {0}", Me.Text) _
             , String.Format("Desea eliminar el registro: {0} - {1}", CType(bs_teso_caja.Current, ETESO_Caja).CAJA_Id, CType(bs_teso_caja.Current, ETESO_Caja).CAJA_Glosa) _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            If m_badministracioncaja.AnularIngreso(GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Anulado satisfactoriamente")
               CargarIngresos()
            Else
               Throw New Exception("No se puede anular el registro, consulte con su administrador del sistema")
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Anular Documento"), ex)
      End Try
   End Sub

   Private Sub tsbtnImprimir_Click(sender As Object, e As EventArgs) Handles tsbtnImprimir.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Imprimir Registro: {0}", Me.Text) _
                                     , String.Format("Desea Imprimir el registro: {0}", CType(bs_teso_caja.Current, ETESO_Caja).RECIB_Codigo) _
                                     , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            Dim _Imprimir As New Impresion(tscmbImpresora.Text)
                If _Imprimir.Print_Recibos(CType(bs_teso_caja.Current, ETESO_Caja).CAJA_NroDocumento, PrintDocument1) Then
                    ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Impreso Satisfactoriamente")
                    tsbtnImprimir.Enabled = m_reimprimir
                    CargarIngresos()
                End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Imprimir Documento"), ex)
      End Try
   End Sub

    Private Sub tsbtnToExcel_Click(sender As Object, e As EventArgs) Handles tsbtnToExcel.Click
        Try
            Utilitarios.ExportarXLS(C1FlexGrid1, "Reporte Pagos")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No completar el proceso de exportar a Excel", ex)
        End Try
    End Sub

    Private Sub tscmbImpresora_Click(sender As Object, e As EventArgs) Handles tscmbImpresora.Click

    End Sub

    Private Sub acTool_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles acTool.ItemClicked

    End Sub

    Private Sub PIngresoEfectivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class