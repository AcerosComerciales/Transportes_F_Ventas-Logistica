Imports ACBVentas
Imports ACEVentas
Imports C1.Win.C1FlexGrid

Public Class CDocsPago
#Region " Variables "
   Private m_opcion As ETipos.TipoDocPago
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
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   ' <summary>
   ' Dar Formato a la grilla de busqueda
   ' </summary>
   ' <remarks></remarks>
   Private Sub formatearGrilla()
      Try
         Select Case m_opcion
            Case ETipos.TipoDocPago.Cheque

               ''Cheque
               Dim index As Integer = 1

               ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 11, 1, 0)
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Banco", "BANCO_Descripcion", "BANCO_Descripcion", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro Cuenta", "DPAGO_Numero", "DPAGO_Numero", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro Cheque", "DPAGO_NumeroCheque", "DPAGO_NumeroCheque", 150, True, False, "System.String", "") : index += 1

               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo Girador", "DPAGO_CodigoGirador", "DPAGO_CodigoGirador", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Depositante", "DPAGO_Depositante", "DPAGO_Depositante", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha Giro", "DPAGO_Fecha", "DPAGO_Fecha", 150, True, False, "System.String", "") : index += 1

               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha Cobro Deposito", "DPAGO_FechaVenc", "DPAGO_FechaVenc", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo Cuenta", "CUENT_Id", "CUENT_Id", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_CodTipoMoneda_Text", "TIPOS_CodTipoMoneda_Text", 150, True, False, "System.String") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo_Moneda", "TIPOS_CodTipoMoneda", "TIPOS_CodTipoMoneda", 150, False, False, "System.String") : index += 1

               c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
               c1grdBusqueda.AllowEditing = False 'True 
               c1grdBusqueda.AutoResize = True
               c1grdBusqueda.AllowAddNew = False
               c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
               c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
               c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
               c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
               c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue
               c1grdBusqueda.Tree.Column = 2

               Dim uch As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("DolaresChe")
               uch.BackColor = Color.Green
               uch.ForeColor = Color.White
               uch.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

               Dim dch As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("SolesChe")
               c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

            Case ETipos.TipoDocPago.Deposito
               ''Depositos
               Dim index As Integer = 1
               ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 7, 1, 0)
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Banco", "BANCO_Descripcion", "BANCO_Descripcion", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro Cuenta", "DPAGO_Numero", "DPAGO_Numero", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Importe", "DPAGO_Importe", "DPAGO_Importe", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_CodTipoMoneda_Text", "TIPOS_CodTipoMoneda_Text", 150, True, False, "System.String") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo_Moneda", "TIPOS_CodTipoMoneda", "TIPOS_CodTipoMoneda", 150, False, False, "System.String") : index += 1

               c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
               c1grdBusqueda.AllowEditing = False
               c1grdBusqueda.AutoResize = True
               c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
               c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
               c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
               c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
               c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue
               c1grdBusqueda.Tree.Column = 2

               Dim ude As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("DolaresDe")
               ude.BackColor = Color.Green
               ude.ForeColor = Color.White
               ude.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

               Dim dde As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("SolesDe")
               c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

            Case ETipos.TipoDocPago.Letra
               ''Letra
               Dim index As Integer = 1
               ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 15, 1, 0)
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Banco", "BANCO_Descripcion", "BANCO_Descripcion", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro Cuenta", "DPAGO_Numero", "DPAGO_Numero", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Importe", "DPAGO_Importe", "DPAGO_Importe", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String", "") : index += 1

               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Lugar Giro", "DPAGO_LugarGiro", "DPAGO_LugarGiro", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Glosa", "DPAGO_Glosa", "DPAGO_Glosa", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Aceptante", "DPAGO_Aceptante", "DPAGO_Aceptante", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Domicilio", "DPAGO_Domicilio", "DPAGO_Domicilio", 150, True, False, "System.String", "") : index += 1

               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Localidad", "DPAGO_Localidad", "DPAGO_Localidad", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "RUC", "DPAGO_RUC", "DPAGO_RUC", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Telefono", "DPAGO_Telefono", "DPAGO_Telefono", 150, True, False, "System.String", "") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Girador", "DPAGO_RefGirador", "DPAGO_RefGirador", 150, True, False, "System.String", "") : index += 1

               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_CodTipoMoneda_Text", "TIPOS_CodTipoMoneda_Text", 150, True, False, "System.String") : index += 1
               ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo_Moneda", "TIPOS_CodTipoMoneda", "TIPOS_CodTipoMoneda", 150, False, False, "System.String") : index += 1

               c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
               c1grdBusqueda.AllowEditing = False 'True
               c1grdBusqueda.AutoResize = True
               'c1grdBusqueda.AllowAddNew = False
               c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
               c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
               c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
               c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
               c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue
               c1grdBusqueda.Tree.Column = 2

               Dim ule As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("DolaresLe")
               ule.BackColor = Color.Green
               ule.ForeColor = Color.White
               ule.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

               Dim dle As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("SolesLe")
               c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         End Select

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

   End Sub
End Class