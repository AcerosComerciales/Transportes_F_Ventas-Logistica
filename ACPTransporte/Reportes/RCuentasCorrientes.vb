Imports ACBVentas
Imports ACEVentas
Imports C1.Win.C1FlexGrid
Imports ACFramework

Public Class RCuentasCorrientes
#Region " Variables "
   Private managerEntidades As BEntidades
   Private managerReporte As Reporte

   Private m_entid_codigocliente As String
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_icono As System.Drawing.Bitmap)

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         managerEntidades = New BEntidades
         managerReporte = New Reporte()

         If Not IsNothing(x_icono) Then Me.Icon = Icon.FromHandle(x_icono.GetHicon)

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_descripcion As String, ByVal x_opcion As Short, ByVal x_opcionentidad As EEntidades.TipoEntidad)
      Try
         Dim _where As New Hashtable
         _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
         If x_cadenas.Length = 0 Then
            Dim _campos() As ACCampos = {New ACCampos("@Opcion", x_opcion.ToString()), New ACCampos("@Cadena", x_cadenas), New ACCampos("@ROLES_Id", x_opcionentidad.GetHashCode.ToString())}
            Dim _busqueda As New ACCampos("@Cadena", x_descripcion)
            Dim AyudaText As New ACControlesC1.ACAyudaTextFlex("Buscar Entidad", "ENTISS_TodosAyuda", _campos, _busqueda, False)
            If AyudaText.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Select Case x_opcionentidad
                  Case EEntidades.TipoEntidad.Clientes
                     '' Cargar datos del cliente
                     m_entid_codigocliente = AyudaText.Respuesta.Rows(0)("Codigo")
                     actxaDescCliente.Text = AyudaText.Respuesta.Rows(0)("Razon Social").ToString()
                     actxaCodCliente.Text = AyudaText.Respuesta.Rows(0)("Doc./R.U.C.").ToString()
                     btnProcesar.Focus()
                  Case EEntidades.TipoEntidad.Vendedores
                  
               End Select
            End If
         Else
            If managerEntidades.Ayuda(_where, x_opcionentidad) Then
               Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerEntidades.DTEntidades, False)
               If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  Select Case x_opcionentidad
                     Case EEntidades.TipoEntidad.Clientes
                        '' Cargar datos del cliente
                        m_entid_codigocliente = Ayuda.Respuesta.Rows(0)("Codigo")
                        actxaDescCliente.Text = Ayuda.Respuesta.Rows(0)("Razon Social").ToString()
                        actxaCodCliente.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.").ToString()
                        btnProcesar.Focus()
                     Case EEntidades.TipoEntidad.Vendedores
                  
                  End Select
               End If
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede mostrar la ayuda, posiblemente no haya datos que mostrar")
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setEntidad(ByVal x_entid_codigo As String)
      '' Cargar datos adicionales cliente
      If managerEntidades.CargarDocIden(x_entid_codigo, EEntidades.TipoInicializacion.Direcciones) Then
         '' Cargar datos del cliente

         actxaDescCliente.Text = managerEntidades.Entidades.ENTID_RazonSocial
         actxaCodCliente.Text = managerEntidades.Entidades.ENTID_NroDocumento
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Documento de Identidad: {0}", Me.Text) _
                         , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", x_entid_codigo) _
                         )

         btnCleanCliente_Click(Nothing, Nothing)
         actxaCodCliente.Focus()
      End If
   End Sub
#End Region

#Region " Metodos de Controles"

   Private Sub actxaCodCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaCodCliente.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaCodCliente.Text.ToString().Length >= ACEVentas.Constantes.LongitudCodigo Then
               setEntidad(actxaCodCliente.Text)
            Else
               If actxaCodCliente.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaCodCliente.Text))
                  btnCleanCliente_Click(Nothing, Nothing)
                  actxaCodCliente.Focus()
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaCodCliente_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCodCliente.ACAyudaClick
      Try
         AyudaEntidad(actxaCodCliente.Text, "ENTID_NroDocumento", "Razon Social", 1, EEntidades.TipoEntidad.Clientes)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Documento de Identidad", ex)
      End Try
   End Sub

   Private Sub actxaDescCliente_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescCliente.ACAyudaClick
      Try
         AyudaEntidad(actxaDescCliente.Text, "ENTID_RazonSocial", "Razon Social", 1, EEntidades.TipoEntidad.Clientes)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso busqueda de cliente por Nombre/Razon Social", ex)
      End Try
   End Sub

   Private Sub btnCleanCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleanCliente.Click
      Try
         actxaDescCliente.Clear()
         actxaCodCliente.Clear()
         actxaCodCliente.Focus()
         m_entid_codigocliente = Nothing
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Limpiar Entidad", ex)
      End Try
   End Sub

#End Region

   Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
      Try
         m_entid_codigocliente = Nothing
         If actxaCodCliente.Text.Length > 0 Then m_entid_codigocliente = actxaCodCliente.Text
         Dim _fecini As Date = DateTime.Now.Date : Dim _fecfin As Date = DateTime.Now.Date
         If AcFecha.ACFechaChecked Then
            _fecini = AcFecha.ACFecha_De.Value.Date
            _fecfin = AcFecha.ACFecha_A.Value.Date
         End If
         If managerReporte.RCuentaCorriente(_fecini, _fecfin, AcFecha.ACFechaChecked, m_entid_codigocliente) Then
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "Probablemente no existan datos para mostrar en este punto de Venta")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
End Class