Imports ACBVentas
Imports ACEVentas
Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports System
Imports System.Collections.Generic
Imports C1.Win.C1FlexGrid

Public Class CPagosPorDepositos
#Region " Variables "
   Private managerBDocsPago As BTESO_DocsPagos
   Private m_badministracioncaja As BAdministracionCaja
   Private m_tesocaja As BTESO_Caja
   Private bs_docsPago As BindingSource
   Private bs_facturas As BindingSource
   Private bs_fletes As BindingSource
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         managerBDocsPago = New BTESO_DocsPagos(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
         m_badministracioncaja = New BAdministracionCaja(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta)
         m_tesocaja = New BTESO_Caja
         formatearGrilla()

         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACCalculadora_16x16.GetHicon)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso inicial de la interfaz", ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Function busqueda(ByVal x_cadena As String, ByVal x_opcion As Short) As Boolean
      Try
         If managerBDocsPago.ObtenerDocPagos(acFecha.ACDtpFecha_De.Value.Date, acFecha.ACDtpFecha_A.Value.Date, x_opcion, x_cadena, getOpcionFecha()) Then '

         Else
            managerBDocsPago.ListTESO_DocsPagos = New List(Of ETESO_DocsPagos)
         End If
         cargarDatos()
         Return True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de Docs de Pago", ex)
      End Try
      Return False
   End Function

   Private Sub cargarDatos()
      Try
         bs_docsPago = New BindingSource()
         bs_docsPago.DataSource = managerBDocsPago.ListTESO_DocsPagos
         c1grdBusqueda.DataSource = bs_docsPago
         bnavBusqueda.BindingSource = bs_docsPago

         AddHandler bs_docsPago.CurrentChanged, AddressOf bs_docsPago_CurrentChanged
         bs_docsPago_CurrentChanged(Nothing, Nothing)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_docsPago_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      bs_facturas = New BindingSource
      Try
         If Not IsNothing(bs_docsPago.Current) Then
            Dim _codigo As Long = CType(bs_docsPago.Current, ETESO_DocsPagos).DPAGO_Id
            tsbtnAnularPago.Enabled = True
            If Not m_tesocaja.ObtenerDocPagosDetalle(_codigo) Then
               m_tesocaja.ListTESO_Caja = New List(Of ETESO_Caja)
            End If
            bs_facturas.DataSource = m_tesocaja.ListTESO_Caja
            c1grdDocAfectados.DataSource = bs_facturas
            bnavPagos.BindingSource = bs_facturas
            c1grdDocAfectados.Subtotal(AggregateEnum.Sum, 0, -1, c1grdDocAfectados.Cols("CAJA_Importe").Index, "Total")

            AddHandler bs_facturas.CurrentChanged, AddressOf bs_fletes_CurrentChanged
            bs_fletes_CurrentChanged(Nothing, Nothing)
         Else
            m_tesocaja.ListTESO_Caja = New List(Of ETESO_Caja)
            bs_facturas.DataSource = m_tesocaja.ListTESO_Caja
            c1grdDocAfectados.DataSource = bs_facturas
            bnavPagos.BindingSource = bs_facturas
            bs_fletes_CurrentChanged(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub bs_fletes_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      bs_fletes = New BindingSource
      Try
         If Not IsNothing(bs_facturas.Current) Then
            Dim _codigo As String = CType(bs_facturas.Current, ETESO_Caja).CAJA_NroDocumento

            If Not m_badministracioncaja.FletesXFacturas(_codigo) Then
               m_badministracioncaja.ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            End If
            bs_fletes.DataSource = m_badministracioncaja.ListTRAN_Fletes
            c1grdFletes.DataSource = bs_fletes
            bnavFletes.BindingSource = bs_fletes
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, c1grdFletes.Cols("FLETE_PesoEnTM").Index, "Total")
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, c1grdFletes.Cols("FLETE_TotIngreso").Index, "Total")
         Else
            m_badministracioncaja.ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            bs_fletes.DataSource = m_badministracioncaja.ListTRAN_Fletes
            c1grdFletes.DataSource = bs_fletes
            bnavFletes.BindingSource = bs_fletes
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub formatearGrilla()
      Try
         ''Depositos
         Dim index As Integer = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 14, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "DPAGO_Id", "DPAGO_Id", 150, True, False, "System.String", "0000#") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "T. Documento", "TIPOS_TipoDocumento", "TIPOS_TipoDocumento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cliente", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro Operacion", "DPAGO_Numero", "DPAGO_Numero", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "DPAGO_Fecha", "DPAGO_Fecha", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha V", "DPAGO_FechaVenc", "DPAGO_FechaVenc", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Banco", "BANCO_Descripcion", "BANCO_Descripcion", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Importe", "DPAGO_Importe", "DPAGO_Importe", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_CodTipoMoneda_Text", "TIPOS_CodTipoMoneda_Text", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo_Moneda", "TIPOS_CodTipoMoneda", "TIPOS_CodTipoMoneda", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DPAGO_Estado_Text", "DPAGO_Estado_Text", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DPAGO_Estado", "DPAGO_Estado", 150, False, False, "System.String") : index += 1

         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.AutoResize = True
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         c1grdBusqueda.Tree.Column = 2

         Dim ude As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("DolaresDe")
         ude.BackColor = Color.Green
         ude.ForeColor = Color.White
         ude.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

         Dim dde As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("SolesDe")
         c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         Dim ade As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Anulado")
         ade.BackColor = Color.Red
         ade.ForeColor = Color.White
         ade.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)
         c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDocAfectados, 1, 1, 6, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocAfectados, index, "Codigo", "CAJA_Id", "CAJA_Id", 150, True, False, "System.String", "0000#") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocAfectados, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocAfectados, index, "Fecha", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocAfectados, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocAfectados, index, "Importe", "CAJA_Importe", "CAJA_Importe", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         c1grdDocAfectados.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdDocAfectados.AllowEditing = False
         c1grdDocAfectados.AutoResize = True
         c1grdDocAfectados.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDocAfectados.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDocAfectados.Styles.Highlight.BackColor = Color.Gray
         c1grdDocAfectados.SelectionMode = SelectionModeEnum.Row


         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdFletes, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Viaje", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Código", "FLETE_Id", "FLETE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Viaje", "VIAJE_Descripcion", "VIAJE_Descripcion", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Peso T.M.", "FLETE_PesoEnTM", "FLETE_PesoEnTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Monto x TM", "FLETE_MontoPorTM", "FLETE_MontoPorTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "I.G.V.", "FLETE_ImporteIgv", "FLETE_ImporteIgv", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Total Flete", "FLETE_TotIngreso", "FLETE_TotIngreso", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Salida", "FLETE_FecSalida", "FLETE_FecSalida", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Llegada", "FLETE_FecLlegada", "FLETE_FecLlegada", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Descripción", "FLETE_Glosa", "FLETE_Glosa", 250, True, False, "System.String") : index += 1

         c1grdFletes.AllowEditing = False
         c1grdFletes.AutoResize = True
         c1grdFletes.Cols(0).Width = 18
         c1grdFletes.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdFletes.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdFletes.Styles.Highlight.BackColor = Color.Gray
         c1grdFletes.SelectionMode = SelectionModeEnum.Row
         c1grdFletes.AllowResizing = AllowResizingEnum.Rows


      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Function getOpcion() As Short
      If rbtnCliente.Checked Then
         Return 0
      ElseIf rbtnNroOperacion.Checked Then
         Return 1
      ElseIf rbtnGlosa.Checked Then
         Return 2
      ElseIf rbtnBanco.Checked Then
         Return 3
      Else
         Return 1
      End If
   End Function

   Private Function getOpcionFecha() As Short
      If rbtnDocPago.Checked Then
         Return 0
      ElseIf rbtnDePago.Checked Then
         Return 1
      Else
         Return 0
      End If
   End Function
#End Region

#Region " Metodos de Controles"
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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If rbtnCliente.Checked Then
            busqueda(txtCliente.Text, getOpcion())
         Else
            busqueda(txtBusqueda.Text, getOpcion())
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar la Busqueda de documentos"), ex)
      End Try
   End Sub

   Private Sub rbtnDatos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnDatos.CheckedChanged
      grpCliente.Enabled = rbtnCliente.Checked
      grpDocPago.Enabled = rbtnDatos.Checked
   End Sub

   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.ACAyudaClick
      busqueda(txtBusqueda.Text, getOpcion())
   End Sub

   Private Sub txtCliente_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.ACAyudaClick
      busqueda(txtCliente.Text, getOpcion())
   End Sub

   Private Sub txtBusqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
      If e.KeyData = Keys.Enter Then
         busqueda(txtBusqueda.Text, getOpcion())
      End If
   End Sub

   Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
      If e.KeyData = Keys.Enter Then
         busqueda(txtCliente.Text, getOpcion())
      End If
   End Sub

#End Region
End Class