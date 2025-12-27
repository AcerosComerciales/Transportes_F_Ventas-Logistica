Imports ACBTransporte
Imports ACEVentas

Imports ACFramework
Imports C1.Win.C1FlexGrid

Public Class PIngresosOtros
#Region " Variables "
   Dim m_badministracioncaja As BAdministracionCaja
   Dim m_tipo As ACETransporte.Constantes.TipoIngEgre

   Private bs_teso_caja As New BindingSource
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_tipo As ACETransporte.Constantes.TipoIngEgre)
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Try
         Inicializar(x_tipo)
         Me.KeyPreview = True
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
         If m_tipo = ACETransporte.Constantes.TipoIngEgre.Ingreso Then
            AcPanelCaption1.ACCaption = String.Format("Ingresos de la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
            Me.Text = String.Format("Ingreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
            acpnlTitulo.ACCaption = String.Format("Ingreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
         Else
            AcPanelCaption1.ACCaption = String.Format("Egresos de la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
            Me.Text = String.Format("Egreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
            acpnlTitulo.ACCaption = String.Format("Egreso en Efectivo a la Fecha {0:dd/MM/yyyy}", dtpFecha.Value)
         End If
      Catch ex As Exception
         Throw ex
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
         End If
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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(C1FlexGrid1, 1, 1, 6, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Codigo", "CAJA_Id", "CAJA_Id", 150, True, False, "System.String", "000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Importe", "CAJA_Importe", "CAJA_Importe", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Descripción", "TIPOS_Transaccion", "TIPOS_Transaccion", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Glosa", "CAJA_Glosa", "CAJA_Glosa", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(C1FlexGrid1, index, "Usuario", "Usuario", "Usuario", 150, True, False, "System.String") : index += 1

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

   Private Sub actxnImporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxnImporte.KeyDown
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
               If (m_badministracioncaja.GuardarOtrosIngreso(GApp.Usuario, m_tipo)) Then
                  ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
                  ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
                  CargarIngresos()
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

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub
#End Region

End Class