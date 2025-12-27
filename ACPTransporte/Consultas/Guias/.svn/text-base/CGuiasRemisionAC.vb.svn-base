Imports ACEVentas
Imports ACFramework
Imports DAConexion

Imports ACBTransporte
Imports ACETransporte
Imports ACBVentas
Imports C1.Win.C1FlexGrid

Public Class CGuiasRemisionAC
#Region " Variables "
   Dim m_btran_guiastransportista As BTRAN_GuiasTransportista
   Private managerEntidades As BEntidades
   Private bs_guias As BindingSource
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         formatearGrilla()
         CargarCombos()
         m_btran_guiastransportista = New BTRAN_GuiasTransportista
         managerEntidades = New BEntidades
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub CargarCombos()
      Try
         ACFramework.ACUtilitarios.ACCargaCombo(cmbPuntoVenta, Colecciones.PuntosVenta, "PVENT_Descripcion", "PVENT_Id")

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdReporte, 1, 1, 12, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Codigo", "GTRAN_Codigo", "GTRAN_Codigo", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Serie-Numero", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Venta", "DocVenta", "DocVenta", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Cod. Proveedor", "GTRAN_RucProveedor", "GTRAN_RucProveedor", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Fecha Emision", "GTRAN_Fecha", "GTRAN_Fecha", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Direccion Entrega", "GTRAN_DireccionDestinatario", "GTRAN_DireccionDestinatario", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Peso Total", "GTRAN_PesoTotal", "GTRAN_PesoTotal", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Estado", "GTRAN_Estado_Text", "GTRAN_Estado_Text", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Impresa", "Impresa", "Impresa", 150, False, False, "System.Boolean") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Transportista", "GTRAN_DescripcionVehiculo", "GTRAN_DescripcionVehiculo", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Estado", "GTRAN_Estado", "GTRAN_Estado", 150, False, False, "System.String") : index += 1


         c1grdReporte.AllowEditing = False
         c1grdReporte.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdReporte.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdReporte.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdReporte.Styles.Highlight.BackColor = Color.Gray
         c1grdReporte.SelectionMode = SelectionModeEnum.Row
         'c1grdReporte.VisualStyle = VisualStyle.Office2007Blue

         Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Facturado")
         t.BackColor = Color.LightGreen
         t.ForeColor = Color.DarkBlue
         t.Font = New Font(c1grdReporte.Font, FontStyle.Regular)

         Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Facturar")
         u.BackColor = Color.Green
         u.ForeColor = Color.White
         u.Font = New Font(c1grdReporte.Font, FontStyle.Regular)

         Dim d As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Anulado")
         d.BackColor = Color.Red
         d.ForeColor = Color.White
         d.Font = New Font(c1grdReporte.Font, FontStyle.Bold)
         c1grdReporte.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try

   End Sub

   Private Sub c1grdGuias_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdReporte.OwnerDrawCell
      Try
         If e.Row < c1grdReporte.Rows.Fixed OrElse e.Col < c1grdReporte.Cols.Fixed Then Return
         If c1grdReporte.Rows(e.Row)("GTRAN_Estado") = ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Anulado) Then
            e.Style = c1grdReporte.Styles("Anulado")
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         Select Case x_opcion
            Case EEntidades.TipoEntidad.Clientes
               Dim _where As New Hashtable
               _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
               If managerEntidades.Ayuda(_where, x_opcion) Then
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Cliente", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     '' Cargar datos del cliente
                     actxaNroDocProveedor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     actxaDescProveedor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                  End If
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
               End If
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub actxaNroDocProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaNroDocProveedor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Clientes)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaDescProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescProveedor.ACAyudaClick
      Try
         AyudaEntidad(actxaDescProveedor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Clientes)
         btnProcesar.Focus()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaNroDocProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocProveedor.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocProveedor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocProveedor.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocProveedor.Text, EEntidades.TipoInicializacion.Direcciones) Then
                     actxaNroDocProveedor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     actxaDescProveedor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                     btnProcesar.Focus()
                  Else
                     actxaNroDocProveedor.Clear()
                     actxaDescProveedor.Clear()
                     lblNroDocumento.Focus()
                  End If
               End If
            Else
               If actxaNroDocProveedor.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocProveedor.Text))
                  actxaNroDocProveedor.Clear()
                  actxaDescProveedor.Clear()
                  lblNroDocumento.Focus()
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub AcFecha_ACFecIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecIni_KeyDown
      If e.KeyData = Keys.Enter Then
         AcFecha.ACDtpFecha_A.Focus()
      End If
   End Sub

   Private Sub AcFecha_ACFecFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecFin_KeyDown
      If e.KeyData = Keys.Enter Then
         actxaNroDocProveedor.Focus()
      End If
   End Sub
#End Region

   Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      Try
         Dim _puntoventa As New EPuntoVenta
         _puntoventa = CType(cmbPuntoVenta.SelectedItem, EPuntoVenta)
         If ACUtilitarios.ACCrearCadena("StrConn", _puntoventa.PVENT_DireccionIPAC, _puntoventa.PVENT_BaseDatosAC) Then
            DAEnterprise.Instanciar("StrConn", True)
            Dim ok As Boolean = True
            If Not m_btran_guiastransportista.GetGuiasRemision(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date, actxaNroDocProveedor.Text) Then
               m_btran_guiastransportista.ListTRAN_GuiasTransportista = New List(Of ETRAN_GuiasTransportista)
               ok = False
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede mostrar los registro, posiblemente no haya datos que mostrar")
            End If
            bs_guias = New BindingSource
            bs_guias.DataSource = m_btran_guiastransportista.ListTRAN_GuiasTransportista
            c1grdReporte.DataSource = bs_guias
            bnavReporte.BindingSource = bs_guias
            'c1grdReporte.AutoSizeCol(9)
            If ACUtilitarios.ACCrearCadena("StrConn", GApp.Servidor, GApp.BaseDatos) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
            If ok Then ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Cargado satisfactoriamente")
         Else
            If ACUtilitarios.ACCrearCadena("StrConn", GApp.Servidor, GApp.BaseDatos) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
            Throw New Exception("No se puede establecer Conexión")
         End If
      Catch ex As Exception
         If ACUtilitarios.ACCrearCadena("StrConn", GApp.Servidor, GApp.BaseDatos) Then
            DAEnterprise.Instanciar("StrConn", True)
         End If
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Procesar Consulta"), ex)
      End Try
   End Sub

   Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
      Try
         Utilitarios.ExportarXLS(c1grdReporte, "Guias de Remisión")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso enviar a excel", ex)
      End Try
   End Sub


End Class