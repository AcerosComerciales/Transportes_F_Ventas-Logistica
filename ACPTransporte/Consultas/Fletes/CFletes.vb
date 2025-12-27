Imports ACBTransporte
Imports ACETransporte
Imports ACEVentas
Imports C1.Win.C1FlexGrid

Public Class CFletes
#Region " Variables "
   Private m_btran_fletes As BTRAN_Fletes
   Private bs_tran_fletes As BindingSource
   Private m_etran_fletes As ETRAN_Fletes

   Enum TAyuda
      RazonSocial = 0
      NroDocumento = 1
      GlosaViaje = 2
   End Enum

#End Region

#Region " Propiedades "

   Public ReadOnly Property TRAN_Fletes() As ETRAN_Fletes
      Get
         Return m_etran_fletes
      End Get
   End Property

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_cadena As String, ByVal x_opcion As TAyuda)

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         formatearGrilla()
         rbtnGlosaViaje.Checked = True
         m_btran_fletes = New BTRAN_Fletes

         CargarRegistros(x_cadena, x_opcion, DateTime.Now.Date, DateTime.Now.Date)

         AcFecha.ACDtpFecha_De.Value = DateTime.Now.AddDays(-1 * DateTime.Now.Day + 1)
         chkTodos.Checked = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 10, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fkec. Salida", "FLETE_FecSalida", "FLETE_FecSalida", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Llegada", "FLETE_FecLlegada", "FLETE_FecLlegada", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cod. Viaje", "VIAJE_Id", "VIAJE_Id", 150, True, False, "System.String", "######0") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cod. Flete", "FLETE_Id", "FLETE_Id", 150, True, False, "System.String", "######0") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Razon Social", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Glosa de Viaje", "VIAJE_Descripcion", "VIAJE_Descripcion", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Glosa Flete", "FLETE_Glosa", "FLETE_Glosa", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Total Pagar", "FLETE_TotIngreso", "FLETE_TotIngreso", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         c1grdBusqueda.AllowEditing = False
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
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Function CargarRegistros(ByVal x_cadena As String, ByVal x_opcion As TAyuda, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime)
      bs_tran_fletes = New BindingSource
      Try
         Dim _rpta As Boolean = False
         If m_btran_fletes.TRAN_FLETESS_Ayuda(x_cadena, x_opcion, x_fecini, x_fecfin) Then
            _rpta = True
         Else
            m_btran_fletes.ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            _rpta = False
         End If

         bs_tran_fletes.DataSource = m_btran_fletes.ListTRAN_Fletes
         c1grdBusqueda.DataSource = bs_tran_fletes
         bnavBusqueda.BindingSource = bs_tran_fletes

         Return _rpta
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function GetTipoOpcion() As TAyuda
      If rbtnRazSocial.Checked Then
         Return TAyuda.RazonSocial
      ElseIf rbtnDocIden.Checked Then
         Return TAyuda.NroDocumento
      ElseIf rbtnGlosaViaje.Checked Then
         Return TAyuda.GlosaViaje
      End If
   End Function
#End Region

#Region " Metodos de Controles"
   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If CargarRegistros(txtBusqueda.Text.Trim(), GetTipoOpcion(), AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date) Then
            'ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("01012")))
         Else
            ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("01013")))
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Consultar"), ex)
      End Try
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


   Private Sub acbtnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acbtnSeleccionar.Click
      Try
         If Not IsNothing(bs_tran_fletes) Then
            If Not IsNothing(bs_tran_fletes.Current) Then
               m_etran_fletes = New ETRAN_Fletes
               m_etran_fletes = CType(bs_tran_fletes.Current, ETRAN_Fletes)

               Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), "Seleccionar, no hay registos"))
         End If
         
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Seleccionar Flete"), ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub c1grdBusqueda_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdBusqueda.DoubleClick
      acbtnSeleccionar_Click(Nothing, Nothing)
   End Sub

   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.ACAyudaClick
      btnConsultar_Click(Nothing, Nothing)
   End Sub

    Private Sub txtBusqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnConsultar_Click(Nothing, Nothing)
        End If
    End Sub
End Class