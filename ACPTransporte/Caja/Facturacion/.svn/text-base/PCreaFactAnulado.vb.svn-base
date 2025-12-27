Imports ACBVentas
Imports ACEVentas
Imports ACBTransporte

Public Class PCreaFactAnulado
#Region " Variables "
   Private managerVENT_DocsVenta As BVENT_DocsVenta
   Private managerEntidades As BEntidades
   Private managerGenerarDocsVenta As BGenerarDocsVentaTrans
   Private bs_series As BindingSource
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         managerVENT_DocsVenta = New BVENT_DocsVenta
         managerEntidades = New BEntidades

         dtpFecFacturacion.Enabled = True

         cargarCombos()
         managerGenerarDocsVenta = New BGenerarDocsVentaTrans(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
         If managerGenerarDocsVenta.GetSeries(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura), GApp.Aplicacion) Then
            bs_series = New BindingSource
            bs_series.DataSource = managerGenerarDocsVenta.ListVENT_PVentDocumento
            Dim _default As String = ""
            For Each Item As EVENT_PVentDocumento In managerGenerarDocsVenta.ListVENT_PVentDocumento
               If Item.PVDOCU_Predeterminado Then
                  _default = Item.PVDOCU_Serie
                  Exit For
               End If
            Next
            ACFramework.ACUtilitarios.ACCargaCombo(cmbSerie, bs_series, "PVDOCU_Serie", "PVDOCU_Serie", _default)
            AddHandler bs_series.CurrentChanged, AddressOf bs_series_CurrentChanged
            bs_series_CurrentChanged(Nothing, Nothing)
            dtpFecFacturacion.Value = DateTime.Now
            cmbSerie.Enabled = True
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar las series, posiblemente no tenga series asignadas")
            cmbSerie.Enabled = False
            cmbSerie.SelectedIndex = -1
         End If

         managerVENT_DocsVenta = New BVENT_DocsVenta
         managerVENT_DocsVenta.VENT_DocsVenta = New EVENT_DocsVenta
         managerVENT_DocsVenta.VENT_DocsVenta.Instanciar(ACFramework.ACEInstancia.Nuevo)

         '' Set Cliente
         Dim _bentidades As New BEntidades
         If _bentidades.Cargar(IIf(rbtnAnulado.Checked, ACETransporte.Constantes.ClienteAnulado, ACETransporte.Constantes.ClienteBlanco)) Then
            managerVENT_DocsVenta.VENT_DocsVenta.ENTID_CodigoCliente = IIf(rbtnAnulado.Checked, ACETransporte.Constantes.ClienteAnulado, ACETransporte.Constantes.ClienteBlanco)
            actxaCliRuc.Text = _bentidades.Entidades.ENTID_NroDocumento
            actxaCliRazonSocial.Text = _bentidades.Entidades.ENTID_RazonSocial
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub bs_series_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_series.Current) Then
            Dim x_numero As Integer = managerGenerarDocsVenta.getNumero(CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_Serie, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura))
            actxnNumero.Text = (x_numero + 1).ToString()
            'If Not IsNothing(CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_DispositivoImpresion) Then
            '   tscmbImpresora.Text = CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_DispositivoImpresion
            'End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub cargarCombos()
      Try
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, Colecciones.TiposDocComprobante(), "TIPOS_Descripcion", "TIPOS_Codigo")

      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"

   Private Sub tsbtGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtGuardar.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Modificar Documento de Venta: {0}", Me.Text) _
                            , String.Format("¿Grabar {0} del cliente: {1}? ", cmbDocumento.Text, managerVENT_DocsVenta.VENT_DocsVenta.ENTID_Cliente) _
                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

            managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento = dtpFecFacturacion.Value
            managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_FechaTransaccion = dtpFecFacturacion.Value
            managerVENT_DocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento = cmbDocumento.SelectedValue
            managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Serie = cmbSerie.Text
            managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Numero = actxnNumero.Text
            managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado)
            managerVENT_DocsVenta.VENT_DocsVenta.ZONAS_Codigo = GApp.Zona
            managerVENT_DocsVenta.VENT_DocsVenta.SUCUR_Id = GApp.Sucursal
            managerVENT_DocsVenta.VENT_DocsVenta.PVENT_Id = GApp.PuntoVenta
            managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_EstEntrega = "E"
            managerVENT_DocsVenta.VENT_DocsVenta.ENTID_CodigoVendedor = Parametros.GetParametro(EParametros.TipoParametros.pg_VendedorDefa)
            managerVENT_DocsVenta.VENT_DocsVenta.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles)
            managerVENT_DocsVenta.VENT_DocsVenta.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.Contado)
            managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Id = managerVENT_DocsVenta.getCorrelativo("DOCVE_Id")
            managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Codigo = managerVENT_DocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento.Substring(3, 2) & managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Serie & managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Numero.ToString().PadLeft(7, "0")

            If managerVENT_DocsVenta.Guardar(GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("01000"))) '
               Me.DialogResult = Windows.Forms.DialogResult.OK
               Me.Close()
            Else
               Throw New Exception("No Se puede Guardar el documento")
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Grabar Fecha"), ex)
      End Try
   End Sub

   Private Sub tsbtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Abort
      Me.Close()
   End Sub

   Private Sub tsbtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSalir.Click
      Me.DialogResult = Windows.Forms.DialogResult.Abort
      Me.Close()
   End Sub
#End Region

   Private Sub rbtnAnulado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAnulado.CheckedChanged
      Try
         If Not IsNothing(managerVENT_DocsVenta) Then
            If rbtnAnulado.Checked Then
               managerVENT_DocsVenta.VENT_DocsVenta.ENTID_CodigoCliente = ACETransporte.Constantes.ClienteAnulado
            Else
               managerVENT_DocsVenta.VENT_DocsVenta.ENTID_CodigoCliente = ACETransporte.Constantes.ClienteBlanco
            End If
            Dim _bentidades As New BEntidades
            If _bentidades.Cargar(IIf(rbtnAnulado.Checked, ACETransporte.Constantes.ClienteAnulado, ACETransporte.Constantes.ClienteBlanco)) Then
               managerVENT_DocsVenta.VENT_DocsVenta.ENTID_Codigo = IIf(rbtnAnulado.Checked, ACETransporte.Constantes.ClienteAnulado, ACETransporte.Constantes.ClienteBlanco)
               actxaCliRuc.Text = _bentidades.Entidades.ENTID_NroDocumento
               actxaCliRazonSocial.Text = _bentidades.Entidades.ENTID_RazonSocial
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar Cliente"), ex)
      End Try
   End Sub
End Class