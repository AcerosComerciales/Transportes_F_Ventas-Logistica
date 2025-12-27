Imports ACETransporte
Imports ACBTransporte
Imports ACEVentas
Imports C1.Win.C1FlexGrid

Public Class CFletesCancelados
#Region " Variables "
   Private m_btran_fletes As BTRAN_Fletes
   Private bs_tran_fletes As BindingSource
   Private bs_tdocbus As BindingSource
   Private managerGenerarDocsVenta As BGenerarDocsVentaTrans

   Enum Opcion
      Fletes = 0
      DocVenta = 1
   End Enum

   Enum OpcionFecha
      FecSalida = 0
      FecLlegada = 1
   End Enum

   Enum OpcionFletes
      CodFlete = 0
      Cliente = 1
      Viaje = 2
   End Enum
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         m_btran_fletes = New BTRAN_Fletes
         managerGenerarDocsVenta = New BGenerarDocsVentaTrans(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)

         cargarCombos()
         formatearGrilla()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub cargarCombos()
      Try
         '' Documento de Venta 
         Dim listDoc As New List(Of ETipos)
         Dim listDocBus As New List(Of ETipos)
         For Each Item As ETipos In Colecciones.TiposDocComprobante()
            listDoc.Add(Item.Clone)
            listDocBus.Add(Item.Clone)
         Next
         bs_tdocbus = New BindingSource() : bs_tdocbus.DataSource = listDocBus : AddHandler bs_tdocbus.CurrentChanged, AddressOf bs_tdocbus_CurrentChanged
         bs_tdocbus_CurrentChanged(Nothing, Nothing)

         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoDocumento, bs_tdocbus, "TIPOS_Descripcion", "TIPOS_Codigo")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 13, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cotizador", "Usuario", "Usuario", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Cliente", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cliente", "ENTID_Cliente", "ENTID_Cliente", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Total Pagar", "DOCVE_TotalPagar", "DOCVE_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Condición", "TIPOS_CondicionPago", "TIPOS_CondicionPago", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCVE_Estado", "DOCVE_Estado", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "DOCVE_Estado_Text", "DOCVE_Estado_Text", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Vendedor", "ENTID_Vendedor", "ENTID_Vendedor", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Facturar", "PEDID_ParaFacturar", "PEDID_ParaFacturar", 150, False, False, "System.Boolean") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.AutoResize = True
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

   Private Function getOpcion() As Opcion
      If rbtnFletes.Checked Then
         Return Opcion.Fletes
      Else
         Return Opcion.DocVenta
      End If
   End Function

   Private Function getOpFecha() As OpcionFecha
      If rbtnFecSalida.Checked Then
         Return OpcionFecha.FecSalida
      Else
         Return OpcionFecha.FecLlegada
      End If
   End Function

   Private Function getOpViaje() As OpcionFletes
      If rbtnCodFlete.Checked Then
         Return OpcionFletes.CodFlete
      ElseIf rbtnCliente.Checked Then
         Return OpcionFletes.Cliente
      ElseIf rbtnGlosa.Checked Then
         Return OpcionFletes.Viaje
      Else
         Return OpcionFletes.Viaje
      End If
   End Function
#End Region

#Region " Metodos de Controles"

   Private Sub bs_tdocbus_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_tdocbus.Current) Then
            '' Cargar las series
            If managerGenerarDocsVenta.GetSeries(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, CType(bs_tdocbus.Current, ETipos).TIPOS_Codigo, GApp.Aplicacion) Then
               ACFramework.ACUtilitarios.ACCargaCombo(ComboBox2, managerGenerarDocsVenta.ListVENT_PVentDocumento, "PVDOCU_Serie", "PVDOCU_Serie")
               ComboBox2.Enabled = True
            Else
               ComboBox2.SelectedIndex = -1
               ComboBox2.Enabled = False
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If getOpcion() = Opcion.Fletes Then
            If Not m_btran_fletes.ConsultaFletes(txtBusqueda.Text, getOpViaje(), getOpFecha(), acFecha.ACFecha_De.Value.Date, acFecha.ACFecha_A.Value.Date) Then
               m_btran_fletes.ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            End If
         Else
            If Not m_btran_fletes.ConsultaFletesDoc(cmbTipoDocumento.SelectedValue, ComboBox2.SelectedValue, txtBusNumero.Text) Then
               m_btran_fletes.ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            End If
         End If
         bs_tran_fletes = New BindingSource
         bs_tran_fletes.DataSource = m_btran_fletes.ListTRAN_Fletes
         c1grdBusqueda.DataSource = bs_tran_fletes
         bnavBusqueda.BindingSource = bs_tran_fletes

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Consultar"), ex)
      End Try
   End Sub
#End Region


   Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

   End Sub
End Class