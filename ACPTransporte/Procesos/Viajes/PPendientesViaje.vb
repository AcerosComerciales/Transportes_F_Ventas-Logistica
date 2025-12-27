Imports ACFramework

Imports ACBVentas
Imports ACEVentas

Imports ACBTransporte
Imports ACETransporte

Public Class PPendientesViaje
#Region " Variables "
   Private managerGenerarCancelacion As BGCancelacion

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_tipo As Tipo
   Private bs_tipogasto As BindingSource

   Enum Tipo
      Nuevo
      Modificar
   End Enum

#End Region

#Region " Propiedades "

   Public ReadOnly Property TESO_Caja() As ETESO_Caja
      Get
         Return managerGenerarCancelacion.TESO_Caja
      End Get
   End Property

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_fecini As DateTime, ByVal x_descripcion As String)

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         acpnlTitulo.Text = String.Format(acpnlTitulo.Text, x_descripcion)
         Inicializar()
         dtpFecha.Value = x_fecini
         m_tipo = Tipo.Nuevo
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub

   Public Sub New(x_pvent_id As Long, ByVal x_caja_id As Long, ByVal x_descripcion As String)

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         acpnlTitulo.Text = String.Format(acpnlTitulo.Text, x_descripcion)
         Inicializar()
         m_tipo = Tipo.Modificar
         managerGenerarCancelacion.CargarCaja(x_pvent_id, x_caja_id)
         AsignarBinding()
         'actxnNumero.Text = managerGenerarCancelacion.TESO_Caja.CAJA_Id
         cmbTipoGasto.Enabled = True
         cmbTipoMoneda.Enabled = False
         cmbTipoTransaccion.Enabled = True

         txtSerie.Enabled = False
         txtGlosa.Enabled = False
         actxnNumero.Enabled = False
         actxnMonto.Enabled = True

         Label14.Focus()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub

   Private Sub Inicializar()
      managerGenerarCancelacion = New BGCancelacion(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
      managerGenerarCancelacion.TESO_Caja = New ETESO_Caja()
      Try
         CargarCombos()

         managerGenerarCancelacion.TESO_Caja.Instanciar(ACEInstancia.Nuevo)

         AsignarBinding()

         Dim managerGenerarDocsVenta As New BGenerarDocsVenta(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)

         txtSerie.Text = ACETransporte.Constantes.CAJA_SerieEgreso
         actxnNumero.Text = managerGenerarCancelacion.getNroTransaccion(GApp.PuntoVenta, txtSerie.Text)

         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)

         Me.KeyPreview = True

      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos "
#Region "Utiles"
   Private Sub CargarCombos()
      Try
         bs_tipogasto = New BindingSource
         bs_tipogasto.DataSource = Colecciones.TiposDocGastos()
         ACUtilitarios.ACCargaCombo(cmbTipoGasto, bs_tipogasto, "TIPOS_Descripcion", "TIPOS_Codigo")
         AddHandler bs_tipogasto.CurrentChanged, AddressOf bs_tipogasto_CurrentChanged
         bs_tipogasto_CurrentChanged(Nothing, Nothing)
         ACUtilitarios.ACCargaCombo(cmbTipoTransaccion, Colecciones.Tipos(ACEVentas.ETipos.MyTipos.TipoPago), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbTipoMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_tipogasto_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         txtGlosa.Text = CType(bs_tipogasto.Current, ETipos).TIPOS_Descripcion
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso", ex)
      End Try
   End Sub
#End Region

   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()

         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoGasto, "SelectedValue", managerGenerarCancelacion.TESO_Caja, "TIPOS_CodTipoDocumento"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoTransaccion, "SelectedValue", managerGenerarCancelacion.TESO_Caja, "TIPOS_CodTransaccion"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoMoneda, "SelectedValue", managerGenerarCancelacion.TESO_Caja, "TIPOS_CodTipoMoneda"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtSerie, "Text", managerGenerarCancelacion.TESO_Caja, "CAJA_Serie"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", managerGenerarCancelacion.TESO_Caja, "CAJA_Numero"))
         If managerGenerarCancelacion.TESO_Caja.CAJA_Fecha.Year < 1700 Then managerGenerarCancelacion.TESO_Caja.CAJA_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecha, "Value", managerGenerarCancelacion.TESO_Caja, "CAJA_Fecha"))

         m_listBindHelper.Add(ACBindHelper.ACBind(txtGlosa, "Text", managerGenerarCancelacion.TESO_Caja, "CAJA_Glosa"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnMonto, "Text", managerGenerarCancelacion.TESO_Caja, "CAJA_Importe"))

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

#Region " Metodos de Controles"
   Private Sub actool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnCancelar_Click
      Me.Close()
   End Sub

   Private Sub actool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnGrabar_Click
      Try
         managerGenerarCancelacion.TESO_Caja.CAJA_OrdenDocumento = 1
         managerGenerarCancelacion.TESO_Caja.CAJA_Pase = ACEVentas.Constantes.GetPase(ACEVentas.Constantes.Pase.Pendiente)
         managerGenerarCancelacion.TESO_Caja.PVENT_Id = GApp.PuntoVenta
         managerGenerarCancelacion.TESO_Caja.ENTID_Codigo = Parametros.GetParametro(EParametros.TipoParametros.Empresa)
         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         Select m_tipo
            Case Tipo.Nuevo
               Me.DialogResult = Windows.Forms.DialogResult.OK
               Me.Close()
               If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Agregar Registro: {0}", Me.Text) _
                            , "Desea Grabar el Gasto de Viaje: " _
                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                  Me.DialogResult = Windows.Forms.DialogResult.OK
                  Me.Close()
               End If
            Case Tipo.Modificar
               If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Modificar Registro: {0}", Me.Text) _
                            , "Desea Modificar la Fecha del Gasto de Viaje: " _
                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                  managerGenerarCancelacion.ModificarFecha(dtpFecha.Value, actxnMonto.Text, GApp.Usuario)
                  Me.DialogResult = Windows.Forms.DialogResult.OK
                  Me.Close()
               End If
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Grabar el Pago"), ex)
      End Try
   End Sub

   Private Sub actool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnSalir_Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub
#End Region

  
   Private Sub dtpFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
      If e.KeyData = Keys.Enter Then
         KeyPreview = False
         actool.Focus()
         actool.ACBtnGrabar.Select()
      End If
   End Sub
End Class