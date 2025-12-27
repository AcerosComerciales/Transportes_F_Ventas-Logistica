Imports ACBVentas
Imports ACEVentas


Public Class PModDocFecha
#Region " Variables "
   Private managerVENT_DocsVenta As BVENT_DocsVenta
   Private managerEntidades As BEntidades

   Private m_docve_codigo As String
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_docv_codigo As String)

      ' This call is required by the designer.
      InitializeComponent()

      m_docve_codigo = x_docv_codigo
      ' Add any initialization after the InitializeComponent() call.
      Try
         managerVENT_DocsVenta = New BVENT_DocsVenta
         managerEntidades = New BEntidades

         cargarCombos()

         If managerVENT_DocsVenta.CargarSinArticulos(x_docv_codigo, True) Then

            cmbDocumento.SelectedValue = managerVENT_DocsVenta.VENT_DocsVenta.TIPOS_CodTipoDocumento
            txtSerie.Text = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Serie
            actxnNumero.Text = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_Numero
            txtDireccion.Text = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_DireccionCliente

            If managerEntidades.Cargar(managerVENT_DocsVenta.VENT_DocsVenta.ENTID_CodigoCliente, EEntidades.TipoInicializacion.Direcciones) Then
               actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
               actxaCliRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
            End If

            dtpFecFacturacion.Value = managerVENT_DocsVenta.VENT_DocsVenta.DOCVE_FechaDocumento

            dtpFecFacturacion.Enabled = True
            actxaCliRazonSocial.ACAyuda.Enabled = False
            actxaCliRuc.ACAyuda.Enabled = False
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub cargarCombos()
      Try
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDocumento, Colecciones.TiposDocComprobante(), "TIPOS_Descripcion", "TIPOS_Codigo")

      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"

   Private Sub tsbtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAceptar.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Modificar Documento de Venta: {0}", Me.Text) _
                            , String.Format("¿Grabar {0} del cliente: {1}? ", cmbDocumento.Text, managerVENT_DocsVenta.VENT_DocsVenta.ENTID_Cliente) _
                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

            Dim _bdocsventa As New BVENT_DocsVenta
            _bdocsventa.VENT_DocsVenta = New EVENT_DocsVenta
            _bdocsventa.VENT_DocsVenta.Instanciar(ACFramework.ACEInstancia.Modificado)
            _bdocsventa.VENT_DocsVenta.DOCVE_FechaDocumento = dtpFecFacturacion.Value
            _bdocsventa.VENT_DocsVenta.DOCVE_Codigo = m_docve_codigo
            If _bdocsventa.Guardar(GApp.Usuario) Then
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

End Class