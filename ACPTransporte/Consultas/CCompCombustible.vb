Imports ACBTransporte
Imports ACFramework
Imports C1.Win.C1FlexGrid

Public Class CCompCombustible
#Region " Variables "
   Private managerTRAN_Viajes As BTRAN_Viajes

   Private bs_tran_viajes As BindingSource

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_icono As System.Drawing.Bitmap)

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         managerTRAN_Viajes = New BTRAN_Viajes
         formatearGrilla()

         If Not IsNothing(x_icono) Then Me.Icon = Icon.FromHandle(x_icono.GetHicon)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try

   End Sub
#End Region

#Region " Metodos "
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         'Deficion de grilla de Viajes
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 16, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "VIAJE_Descripcion", "VIAJE_Descripcion", "VIAJE_Descripcion", 250, FALSE, False, "System.String") : index += 1        
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Código", "COMCO_Id", "COMCO_Id", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Recibo", "Referencia", "Referencia", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "RUC", "ENTID_CodigoProveedor", "ENTID_CodigoProveedor", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Proveedor", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
        ' ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Modo Pago", "TIPOS_ModoPago", "TIPOS_ModoPago", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "T. Combustible", "TIPOS_TipoCombustible", "TIPOS_TipoCombustible", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Precio Galon", "COMCO_PrecioGalon", "COMCO_PrecioGalon", 100, True, False,  "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Consumo (GLS)", "COMCO_GalonesConsumidos", "COMCO_GalonesConsumidos", 100, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Precio Total", "COMCO_Total", "COMCO_Total", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha Viaje", "COMCO_FechaViaje", "COMCO_FechaViaje", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Documento", "DOCUS_Codigo", "DOCUS_Codigo", 150, True, False, "System.DateTime") :  index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Km. Marcado", "VIAVE_Kilometraje", "VIAVE_Kilometraje", 150, True, False,"System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo4d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Km. Anterior", "VIAVE_KmAnterior", "VIAVE_KmAnterior", 150, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo4d)) : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Km. Recorrido", "Kilometraje", "Kilometraje", 150, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ''ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Creación", "VIAJE_FecCrea", "VIAJE_FecCrea", 100, True, False, "System.DateTime") : index += 1
         c1grdBusqueda.AllowEditing = True
         c1grdBusqueda.AutoResize = True
         c1grdBusqueda.AllowResizing = True
         c1grdBusqueda.Cols(0).Width = 15
         c1grdBusqueda.ExtendLastCol = False
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn

         c1grdBusqueda.Styles.Alternate.BackColor = Color.LightGray
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         c1grdBusqueda.AllowResizing = AllowResizingEnum.Columns
         c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
         c1grdBusqueda.Tree.Column = 1

         Dim s As CellStyle = c1grdBusqueda.Styles(CellStyleEnum.Subtotal0)
         s.BackColor = Color.Black
         s.ForeColor = Color.White
         s.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)

         s = c1grdBusqueda.Styles(CellStyleEnum.Subtotal1)
         s.BackColor = Color.DarkBlue
         ''S.
         s.ForeColor = Color.White
         s = c1grdBusqueda.Styles(CellStyleEnum.Subtotal2)
         s.BackColor = Color.DarkRed
         s.ForeColor = Color.White

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
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   ' <summary>
   ' Ejecutar la busqueda de una cadena en la tabla Neumaticos
   ' </summary>
   ' <param name="x_cadena">Cadena objetivo</param>
   ' <remarks></remarks>
   ' 
   Private Function busqueda(ByVal x_cadena As String) As Boolean
      Try
         If Not managerTRAN_Viajes.CuadroComparativoCombustible(x_cadena, getCampo(), getCampoFecha(), acFecha.ACFecha_De.Value.Date _
                                                            , acFecha.ACFecha_A.Value.Date, chkTodos.Checked, GApp.PuntoVenta) Then
            managerTRAN_Viajes.ListTRAN_ViajesCombustibles = New List(Of ACETransporte.ETRAN_CombustibleConsumo)
         End If
         bs_tran_viajes = New BindingSource()
         bs_tran_viajes.DataSource = managerTRAN_Viajes.getListTRAN_ViajesCombustibles

         c1grdBusqueda.DataSource = bs_tran_viajes
         bnavBusqueda.BindingSource = bs_tran_viajes

         ''''''ARBOL
             
            c1grdBusqueda.Tree.Column = 5
            c1grdBusqueda.SubtotalPosition = SubtotalPositionEnum.AboveData
            c1grdBusqueda.Subtotal(AggregateEnum.Sum, 1, 1, 1, c1grdBusqueda.Cols("COMCO_GalonesConsumidos").Index, "Viaje. {0}")
            c1grdBusqueda.Subtotal(AggregateEnum.Sum, 1, 1, 1, c1grdBusqueda.Cols("COMCO_Total").Index, "Viaje. {0}")
           c1grdBusqueda.AutoSizeCols()



         cargarDatos()
         Return True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

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

   ' <summary>
   ' Cargar los datos en el control Visual C1FlexGrid
   ' </summary>
   Private Sub cargarDatos()
      Try
         

      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      txtBusqueda_ACAyudaClick(Nothing, Nothing)
   End Sub

   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
   End Sub
#End Region

   Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
      Try
         Utilitarios.ExportarXLS(c1grdBusqueda, "Consumo Combustible")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso enviar a excel", ex)
      End Try
   End Sub
End Class