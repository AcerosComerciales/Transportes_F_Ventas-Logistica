Imports ACBTransporte
Imports ACBVentas
Imports ACETransporte
Imports ACFramework
Imports C1.Win.C1FlexGrid


Public Class PGuiasTransporte

#Region " Variables "
   Private managerAdministracionViajes As BAdministracionViajes
   Private bs_tran_viajeguias As BindingSource
   Private m_viaje_id As Long
   Private m_flete_id As Long
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_viaje_id As Long, ByVal x_flete_id As Long)

      ' This call is required by the designer.
      InitializeComponent()

      cmbGEmpresa.Visible = False
      ' Add any initialization after the InitializeComponent() call.
      Try
         m_viaje_id = x_viaje_id
         m_flete_id = x_flete_id
         formatearGrilla_GuiasRemision()

         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoGuia, Colecciones.TiposDocsTraslado(), "TIPOS_Descripcion", "TIPOS_Codigo")
         Dim _lista As New List(Of ACLista)
         _lista.Add(New ACLista("I", "Ida"))
         _lista.Add(New ACLista("V", "Vuelta"))
         ACFramework.ACUtilitarios.ACCargaCombo(cmbCondicion, _lista, ACLista.Descripcion, ACLista.Codigo)

         Dim _bfletes As New BTRAN_Fletes() : _bfletes.Cargar(x_flete_id)
         Dim _bentidad As New BEntidades() : _bentidad.Cargar(_bfletes.TRAN_Fletes.ENTID_Codigo)

         Dim x_cliente As String = _bentidad.Entidades.ENTID_RazonSocial
         Dim x_ruccliente As String = _bfletes.TRAN_Fletes.ENTID_Codigo

         Dim _listaE As New List(Of ACLista)
         _listaE.Add(New ACLista(GApp.EmpresaRUC.Trim, GApp.EEmpresa.EMPR_Desc))
         _listaE.Add(New ACLista(x_ruccliente, x_cliente))
         ACFramework.ACUtilitarios.ACCargaCombo(cmbGEmpresa, _listaE, ACLista.Descripcion, ACLista.Codigo)

         managerAdministracionViajes = New BAdministracionViajes(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
         managerAdministracionViajes.ListTRAN_ViajesGuiasRemision = New List(Of ETRAN_ViajesGuiasRemision)

         bs_tran_viajeguias = New BindingSource()
         bs_tran_viajeguias.DataSource = managerAdministracionViajes.ListTRAN_ViajesGuiasRemision
         c1grdGuiaRemision.DataSource = bs_tran_viajeguias
         bnavGuiaRemision.BindingSource = bs_tran_viajeguias

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub formatearGrilla_GuiasRemision()
      Try
         Dim index As Integer = 1
         'Definicion de grilla de Ingresos
         '' Conbustible Consumo
         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdGuiaRemision, 1, 1, 8, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaRemision, index, "Codigo", "GTRAN_Codigo", "GTRAN_Codigo", 50, False, False, "System.Integer", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaRemision, index, "Serie", "Serie", "Serie", 30, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaRemision, index, "Numero", "Numero", "Numero", 80, True, True, "System.Integer", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaRemision, index, "Tipo Doc", "TIPOS_CodTipoDocumento_Text", "TIPOS_CodTipoDocumento_Text", 200, True, True, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaRemision, index, "Condicion", "VEGRE_Condicion_Text", "VEGRE_Condicion_Text", 150, True, True, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaRemision, index, "Empresa", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, True, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuiaRemision, index, "Observación", "VEGRE_Observacion", "VEGRE_Observacion", 250, True, True, "System.String") : index += 1

         c1grdGuiaRemision.AllowEditing = True
         c1grdGuiaRemision.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdGuiaRemision.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdGuiaRemision.Styles.Highlight.BackColor = Color.Gray
         c1grdGuiaRemision.SelectionMode = SelectionModeEnum.Default

         c1grdGuiaRemision.Cols("TIPOS_CodTipoDocumento_Text").Editor = cmbTipoGuia
         c1grdGuiaRemision.Cols("VEGRE_Condicion_Text").Editor = cmbCondicion
         c1grdGuiaRemision.Cols("ENTID_RazonSocial").Editor = cmbGEmpresa
         'c1grdGuiaRemision.AutoSizeCols()

         cmbTipoGuia.Enabled = True : cmbTipoGuia.Visible = False
         cmbCondicion.Enabled = True : cmbCondicion.Visible = False
         cmbGEmpresa.Enabled = True : cmbGEmpresa.Visible = False

      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub tsbtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAceptar.Click
      Try
         c1grdGuiaRemision.FinishEditing()

         For Each item As ETRAN_ViajesGuiasRemision In managerAdministracionViajes.ListTRAN_ViajesGuiasRemision
            item.FLETE_Id = m_flete_id
         Next
         If managerAdministracionViajes.GuardarGuiaRemision(m_viaje_id, GApp.Usuario) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Grabar Guias de Remisión", ex)
      End Try
   End Sub

   Private Sub cmbTipoGuia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoGuia.SelectedIndexChanged
      Try
         If Not IsNothing(cmbTipoGuia.SelectedValue) Then
            If Not IsNothing(bs_tran_viajeguias) Then
               CType(bs_tran_viajeguias.Current, ETRAN_ViajesGuiasRemision).TIPOS_CodTipoDocumento = cmbTipoGuia.SelectedValue
               c1grdGuiaRemision.AutoSizeCols()
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Seleccionar Item")
      End Try
   End Sub

   Private Sub cmbCondicion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCondicion.SelectedIndexChanged
      Try
         If Not IsNothing(cmbCondicion.SelectedValue) Then
            If Not IsNothing(bs_tran_viajeguias) Then
               CType(bs_tran_viajeguias.Current, ETRAN_ViajesGuiasRemision).VEGRE_Condicion = cmbCondicion.SelectedValue
               c1grdGuiaRemision.AutoSizeCols()
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Seleccionar Item")
      End Try
   End Sub

   Private Sub cmbGEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGEmpresa.SelectedIndexChanged
      Try
         If Not IsNothing(cmbTipoGuia.SelectedValue) Then
            If Not IsNothing(bs_tran_viajeguias) Then
               CType(bs_tran_viajeguias.Current, ETRAN_ViajesGuiasRemision).ENTID_Codigo = cmbGEmpresa.SelectedValue
               c1grdGuiaRemision.AutoSizeCols()
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Seleccionar Item")
      End Try
   End Sub
#End Region

   Private Sub tsbtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnCancelar.Click
      Me.Close()
   End Sub

   Private Sub tsbtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSalir.Click
      Me.Close()
   End Sub


    Private Sub PGuiasTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class