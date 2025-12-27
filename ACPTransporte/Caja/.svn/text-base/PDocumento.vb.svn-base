Imports ACEVentas
Imports ACBVentas
Imports ACFramework

Public Class PDocumento
#Region " Variables "
   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_teso_cajachicapagos As BTESO_CajaChicaPagos
   Private managerEntidades As BEntidades

   Private m_importe As Decimal
   Private m_pagado As Decimal
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_cajac_id As Long, ByVal x_moneda As String, ByVal x_importe As Decimal, ByVal x_pagado As Decimal)

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)

         managerEntidades = New BEntidades
         m_importe = x_importe
         m_pagado = x_pagado
         CargarCombos()
         m_teso_cajachicapagos = New BTESO_CajaChicaPagos
         m_teso_cajachicapagos.TESO_CajaChicaPagos = New ETESO_CajaChicaPagos
         m_teso_cajachicapagos.TESO_CajaChicaPagos.Instanciar(ACEInstancia.Nuevo)
         m_teso_cajachicapagos.TESO_CajaChicaPagos.CAJAC_Id = x_cajac_id
         m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos = New ETESO_Documentos
         m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.Instanciar(ACEInstancia.Nuevo)
         m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.TIPOS_CodTipoMoneda = x_moneda

         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub CargarCombos()
      Try
         ACUtilitarios.ACCargaCombo(cmbTipoMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbTDevolucion, Colecciones.Tipos(ETipos.MyTipos.TipoDevCajaChica), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbTipoDocumento, Colecciones.TiposDocFactGastos(), "TIPOS_Descripcion", "TIPOS_Codigo")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         Select Case x_opcion
            Case EEntidades.TipoEntidad.Proveedores
               Dim _where As New Hashtable
               _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
               If managerEntidades.Ayuda(_where, x_opcion) Then
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Proveedor", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     '' Cargar datos del cliente
                     actxaNroDocProveedor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     actxaDescProveedor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")

                     If managerEntidades.Cargar(actxaNroDocProveedor.Text, EEntidades.TipoInicializacion.Proveedor) Then
                        lblTipoDocumento.Focus()
                     End If
                  End If
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
               End If
         End Select
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
                     m_teso_cajachicapagos.TESO_CajaChicaPagos.ENTID_Codigo = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                  End If
            End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub chkComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComprobante.CheckedChanged
      grpComprobante.Enabled = chkComprobante.Checked
      Me.KeyPreview = chkComprobante.Checked
   End Sub
   Private Sub actxnNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxnNumero.KeyDown
      If e.KeyData = Keys.Enter Then
         KeyPreview = False
         acTool.Focus()
         acTool.ACBtnGrabar.Select()
      End If
   End Sub
   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         If TypeOf ActiveControl Is ACControles.ACTextBoxAyuda And ActiveControl.Name = "actxaProdCodigo" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub
#End Region

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click
      Me.Close()
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
      Try
         m_teso_cajachicapagos.TESO_CajaChicaPagos.PVENT_Id = GApp.PuntoVenta
         m_teso_cajachicapagos.TESO_CajaChicaPagos.ENTID_Codigo = actxaNroDocProveedor.Text
         m_teso_cajachicapagos.TESO_CajaChicaPagos.CAJAP_Fecha = dtpFechaPago.Value
         m_teso_cajachicapagos.TESO_CajaChicaPagos.CAJAP_Importe = actxnMonto.Text
         m_teso_cajachicapagos.TESO_CajaChicaPagos.CAJAP_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
         m_teso_cajachicapagos.TESO_CajaChicaPagos.CAJAP_Descripcion = txtDescripcion.Text
         m_teso_cajachicapagos.TESO_CajaChicaPagos.TIPOS_CodTipoPago = cmbTDevolucion.SelectedValue

         Dim _tpagado As Decimal = m_pagado + m_teso_cajachicapagos.TESO_CajaChicaPagos.CAJAP_Importe
         If _tpagado > m_importe Then
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            Throw New Exception(String.Format("No puede completar el pago por que el importe total pagado {0} excede al importe pendiente {1}", _
                                m_teso_cajachicapagos.TESO_CajaChicaPagos.CAJAP_Importe, (m_importe - m_pagado)))
         End If

         If chkComprobante.Checked Then
            m_teso_cajachicapagos.TESO_CajaChicaPagos.ENTID_RazonSocial = actxaDescProveedor.Text
            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.ENTID_Codigo = actxaNroDocProveedor.Text
            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_Serie = txtSerie.Text
            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_Numero = actxnNumero.Text
            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_Fecha = dtpFecha.Value
            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.TIPOS_CodTipoMoneda = cmbTipoMoneda.SelectedValue
            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.TIPOS_CodTipoDocumento = cmbTipoDocumento.SelectedValue

            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_TotalPago = actxnMonto.Text
            Dim _igv As Decimal = Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100
            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_Importe = m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_TotalPago / (1 + _igv)
            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_ImporteIGV = m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_TotalPago - m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_Importe
            m_teso_cajachicapagos.TESO_CajaChicaPagos.TESO_Documentos.DOCUS_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
         End If
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Cancelar Pendiente: {0}", Me.Text) _
             , "Desea Agregar Pago: " _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            If m_teso_cajachicapagos.Guardar(GApp.Usuario, chkComprobante.Checked) Then

               Me.DialogResult = Windows.Forms.DialogResult.OK
               Me.Close()
            End If
         End If



      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Grabar"), ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub actxaNroDocProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocProveedor.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocProveedor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocProveedor.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocProveedor.Text, EEntidades.TipoInicializacion.Direcciones) Then
                     actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     m_teso_cajachicapagos.TESO_CajaChicaPagos.ENTID_Codigo = managerEntidades.Entidades.ENTID_Codigo

                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial

                     Label7.Focus()
                  Else
                     If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                     , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaNroDocProveedor.Text) _
                                     , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        NuevaEntidad(actxaNroDocProveedor.Text, EEntidades.TipoEntidad.Proveedores)
                     Else
                        actxaNroDocProveedor.Clear()
                        actxaDescProveedor.Clear()
                        lblProveedor.Focus()
                     End If
                  End If
               End If
            Else
               If actxaNroDocProveedor.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocProveedor.Text))
                  actxaNroDocProveedor.Clear()
                  actxaDescProveedor.Clear()
                  lblProveedor.Focus()
               End If

            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaNroDocProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaNroDocProveedor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaDescProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaDescProveedor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Proveedores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub chkComprobante_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkComprobante.KeyDown
      If Not chkComprobante.Checked Then
         If e.KeyData = Keys.Enter Then
            KeyPreview = False
            acTool.Focus()
            acTool.ACBtnGrabar.Select()
         End If
      End If
   End Sub
End Class