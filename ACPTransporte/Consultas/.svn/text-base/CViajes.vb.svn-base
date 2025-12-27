Imports ACEVentas
Imports ACETransporte
Imports ACBTransporte
Imports C1.Win.C1FlexGrid

Public Class CViajes
#Region " Variables "
   Private managerTRAN_Viajes As BTRAN_Viajes
   Private m_etran_viajes As ETRAN_Viajes

   Private bs_tran_viajes As BindingSource
   Private bs_tran_fletes As BindingSource

#End Region

#Region " Propiedades "
   Public ReadOnly Property TRAN_Viajes() As ETRAN_Viajes
      Get
         Return m_etran_viajes
      End Get
   End Property

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         SetInicio()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub SetInicio()
      Try
         managerTRAN_Viajes = New BTRAN_Viajes

         cargarCombos()
         txtBusqueda.Focus()
         formatearGrilla()
         acFecha.ACDtpFecha_De.Value = DateTime.Now.AddDays(-1 * DateTime.Now.Day + 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos "
#Region " Utilitarios "
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         'Deficion de grilla de Viajes
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 12, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Código", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Viaje x Veh.", "VIAJE_IdxVehiculo", "VIAJE_IdxVehiculo", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Viaje x Cond.", "VIAJE_IdxConductor", "VIAJE_IdxConductor", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Descripción", "VIAJE_Descripcion", "VIAJE_Descripcion", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Salida", "VIAJE_FecSalida", "VIAJE_FecSalida", 100, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FFechaHora)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. LLegada", "VIAJE_FecLlegada", "VIAJE_FecLlegada", 100, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FFechaHora)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Vehiculo", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Ranfla", "RANFL_Placa", "RANFL_Placa", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Conductor", "ENTID_Nombres", "ENTID_Nombres", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "VIAJE_Estado_Text", "VIAJE_Estado_Text", 100, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FFechaHora)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "VIAJE_Estado", "VIAJE_Estado", 100, False, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FFechaHora)) : index += 1
         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
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

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdFletes, 1, 1, 11, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Seleccionar", "Seleccionar", "Seleccionar", 30, True, True, "System.Boolean") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Código", "FLETE_Id", "FLETE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Cotización", "COTIZ_Codigo", "COTIZ_Codigo", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Cliente", "ENTID_RazonSocial", "ENTID_RazonSocial", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Peso(T.M.)", "FLETE_PesoEnTM", "FLETE_PesoEnTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Mon.", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Ingreso", "FLETE_TotIngreso", "FLETE_TotIngreso", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Salida", "FLETE_FecSalida", "FLETE_FecSalida", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Llegada", "FLETE_FecLlegada", "FLETE_FecLlegada", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Descripción", "FLETE_Glosa", "FLETE_Glosa", 250, True, False, "System.String") : index += 1

         c1grdFletes.AllowEditing = True
         c1grdFletes.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdFletes.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdFletes.Styles.Highlight.BackColor = Color.Gray
         c1grdFletes.SelectionMode = SelectionModeEnum.Row
         c1grdFletes.AllowSorting = AllowSortingEnum.SingleColumn
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Function getCampo() As Integer
      Try
         If (rbtnCodigo.Checked) Then
            'Return "VIAJE_Id"
            Return 0
         ElseIf rbtnDescripcion.Checked Then
            'Return "VIAJE_Descripcion"
            Return 1
         ElseIf rbtnPlacaTracto.Checked Then
            'Return "VEHIC_Placa"
            Return 2
         Else
            'Return "VIAJE_Id"
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub cargarCombos()
      Try
         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACViajes_16x16.GetHicon)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function getCampoFecha() As Integer
      Try
         If (rbtnFecLlegada.Checked) Then
            'Return "VIAJE_FecLlegada"
            Return 0
         ElseIf rbtnFecSalida.Checked Then
            'Return "VIAJE_FecSalida"
            Return 1
         Else
            'Return "VIAJE_FecLlegada"
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

   Private Function busqueda(ByVal x_cadena As String) As Boolean
      Try
         If managerTRAN_Viajes.Busqueda(x_cadena, getCampo(), getCampoFecha(), acFecha.ACFecha_De.Value.Date _
                                        , acFecha.ACFecha_A.Value.Date.AddDays(1), chkTodos.Checked, GApp.PuntoVenta) Then
            ACTool.ACBtnEliminarEnabled = True
            ACTool.ACBtnModificarEnabled = True
         Else
            ACTool.ACBtnEliminarEnabled = False
            ACTool.ACBtnModificarEnabled = False
         End If
         cargarDatos()
         Return ACTool.ACBtnModificarEnabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Sub cargarDatos()
      Try
         bs_tran_viajes = New BindingSource()
         bs_tran_viajes.DataSource = managerTRAN_Viajes.getListTRAN_Viajes
         AddHandler bs_tran_viajes.CurrentChanged, AddressOf bs_tran_viajes_CurrentChanged
         bs_tran_viajes_CurrentChanged(Nothing, Nothing)
         c1grdBusqueda.DataSource = bs_tran_viajes
         bnavBusqueda.BindingSource = bs_tran_viajes
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"

#Region " Textos "

   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
   End Sub

   Private Sub txtBusqueda_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBusqueda.KeyUp
      Try
         If e.KeyCode = Keys.Enter Then
            busqueda(txtBusqueda.Text)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

#Region " Binding "

   Private Sub bs_tran_viajes_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_tran_viajes.Current) Then
            bs_tran_fletes = New BindingSource
            If Not managerTRAN_Viajes.CargarFletes(CType(bs_tran_viajes.Current, ETRAN_Viajes)) Then
               CType(bs_tran_viajes.Current, ETRAN_Viajes).ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            End If
            bs_tran_fletes.DataSource = CType(bs_tran_viajes.Current, ETRAN_Viajes).ListTRAN_Fletes
            c1grdFletes.DataSource = bs_tran_fletes
            bnavFletes.BindingSource = bs_tran_fletes

            If CType(bs_tran_viajes.Current, ETRAN_Viajes).VIAJE_Estado.Equals(ETRAN_Viajes.getEstado(ETRAN_Viajes.EstadosViajes.Anulado)) Then
               ACTool.ACBtnModificar.Enabled = False
            Else
               ACTool.ACBtnModificar.Enabled = True
            End If
         Else
            ACTool.ACBtnModificar.Enabled = False
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      txtBusqueda_ACAyudaClick(Nothing, Nothing)
   End Sub
#End Region

   Private Sub AcFecha_ACFecIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles acFecha.ACFecIni_KeyDown
      If e.KeyData = Keys.Enter Then
         AcFecha.ACDtpFecha_A.Focus()
      End If
   End Sub

   Private Sub AcFecha_ACFecFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles acFecha.ACFecFin_KeyDown
      If e.KeyData = Keys.Enter Then
         btnConsultar_Click(Nothing, Nothing)
      End If
   End Sub

   Private Sub ACTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ACTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub acbtnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acbtnSeleccionar.Click
      Dim _msg As String = ""
      Try
         c1grdFletes.FinishEditing()
         If Validar(_msg) Then
            managerTRAN_Viajes.TRAN_Viajes = CType(bs_tran_viajes.Current, ETRAN_Viajes)
            m_etran_viajes = managerTRAN_Viajes.TRAN_Viajes.Clone()
            m_etran_viajes.ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            For Each item As ETRAN_Fletes In CType(bs_tran_viajes.Current, ETRAN_Viajes).ListTRAN_Fletes
               If item.Seleccionar Then
                  m_etran_viajes.ListTRAN_Fletes.Add(item)
               End If
            Next
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), ""), _msg)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Seleccionar Fletes"), ex)
      End Try
   End Sub

   Private Function Validar(ByRef x_msg As String)
      Dim i As Integer = 0
      Try
         For Each item As ETRAN_Fletes In CType(bs_tran_viajes.Current, ETRAN_Viajes).ListTRAN_Fletes
            If item.Seleccionar Then i += 1
         Next
         If Not i > 0 Then x_msg &= String.Format("- No ha seleccionado ningun flete{0}", vbNewLine)

         Return Not x_msg.Length > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

End Class