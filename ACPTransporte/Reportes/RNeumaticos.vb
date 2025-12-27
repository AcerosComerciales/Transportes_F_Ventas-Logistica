Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports C1.Win.C1FlexGrid
Imports ACReporteador
Imports C1.C1Preview
Imports ACEVentas

Public Class RNeumaticos

#Region " Variables "
   Private managerTRAN_Neumaticos As BTRAN_Neumaticos
   Private managerAdministracionNeumaticos As BAdministracionNeumaticos

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_etran_neumaticos As ETRAN_Neumaticos
   Private bs_btran_neumaticos As BindingSource
   Private bs_viajesneumaticos As BindingSource
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda
         tabBusqueda.Focus()
         formatearGrilla()
         cargarCombos()
         m_listBindHelper = New List(Of ACBindHelper)()
         managerTRAN_Neumaticos = New BTRAN_Neumaticos
         managerAdministracionNeumaticos = New BAdministracionNeumaticos

         txtBusqueda.Focus()

         acTool.ACBtnEliminarEnabled = False
         acTool.ACBtnModificarEnabled = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

#End Region

#Region " Metodos "

#Region " Utilitarios "
   ' <summary>
   ' Dar Formato a la grilla de busqueda
   ' </summary>
   ' <remarks></remarks>
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         'Deficion de grilla de Busqueda Neumaticos
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 9, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "NEUMA_Codigo", "NEUMA_Codigo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Sucursal", "SUCUR_Nombre", "SUCUR_Nombre", 150, False, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Marca", "TIPO_Marca", "TIPO_Marca", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "T. Neumatico", "TIPO_Llanta", "TIPO_Llanta", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Modelo", "NEUMA_Modelo", "NEUMA_Modelo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Compra", "NEUMA_FecCompra", "NEUMA_FecCompra", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Kilometraje", "NEUMA_KmVidaUtil", "NEUMA_KmVidaUtil", 150, True, False, "System.Decimal", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Interno", "NEUMA_Id", "NEUMA_Id", 150, True, False, "System.Integer", "") : index += 1
         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row

         'Deficion de grilla de Movimientos Neumaticos

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdMovimientosNeumaticos, 2, 2, 7, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Codigo", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Descripción", "VIAJE_Descripcion", "VIAJE_Descripcion", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Salida", "VIAJE_FecSalida", "VIAJE_FecSalida", 250, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Llegada", "VIAJE_FecLlegada", "VIAJE_FecLlegada", 250, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Viaje", "VIAJE_Id", "VIAJE_Id", 250, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Kilometraje", "NEUMF_Km", "NEUMF_Km", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         c1grdMovimientosNeumaticos.AllowEditing = False
         c1grdMovimientosNeumaticos.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdMovimientosNeumaticos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdMovimientosNeumaticos.Styles.Highlight.BackColor = Color.Gray
         c1grdMovimientosNeumaticos.SelectionMode = SelectionModeEnum.Row


         For i As Integer = 1 To c1grdMovimientosNeumaticos.Cols.Count - 1
            c1grdMovimientosNeumaticos.Rows(1)(i) = c1grdMovimientosNeumaticos.Rows(0)(i)
         Next
         c1grdMovimientosNeumaticos.AllowMerging = AllowMergingEnum.Custom
         c1grdMovimientosNeumaticos.Cols(0).AllowMerging = True
         c1grdMovimientosNeumaticos.Cols(5).AllowMerging = True
         c1grdMovimientosNeumaticos.Cols(6).AllowMerging = True
         c1grdMovimientosNeumaticos.Rows(0).AllowMerging = True
         c1grdMovimientosNeumaticos.Rows(1).AllowMerging = True
         Dim rg As CellRange = c1grdMovimientosNeumaticos.GetCellRange(0, 1, 0, 4)
         rg.Data = "Viajes"
         c1grdMovimientosNeumaticos.MergedRanges.Add(rg)
         rg = c1grdMovimientosNeumaticos.GetCellRange(0, 0, 1, 0)
         rg.Data = ""
         c1grdMovimientosNeumaticos.MergedRanges.Add(rg)
         rg = c1grdMovimientosNeumaticos.GetCellRange(0, 5, 1, 5)
         'rg.Data = ""
         c1grdMovimientosNeumaticos.MergedRanges.Add(rg)
         rg = c1grdMovimientosNeumaticos.GetCellRange(0, 6, 1, 6)
         'rg.Data = ""
         c1grdMovimientosNeumaticos.MergedRanges.Add(rg)

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   ' <summary>
   ' Carga los combos de la interfaz de datos
   ' </summary>
   ' <remarks></remarks>
   Private Sub cargarCombos()
      Try
         ACFramework.ACUtilitarios.ACCargaCombo(cmbMarca, Colecciones.Tipos(ETipos.MyTipos.MarcasNeumaticos), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoLlanta, Colecciones.Tipos(ETipos.MyTipos.TipoNeumatico), "TIPOS_Descripcion", "TIPOS_Codigo")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)

      Select Case _opcion
         Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo

         Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            tsbtnPreview.Visible = True

         Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

         Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer
            tsbtnPreview.Visible = False
      End Select

   End Sub
#End Region

#Region " Cargar Datos "
   ' <summary>
   ' Cargar los datos en el control Visual C1FlexGrid
   ' </summary>
   Private Sub cargarDatos()
      Try
         bs_btran_neumaticos = New BindingSource()
         bs_btran_neumaticos.DataSource = managerTRAN_Neumaticos.getListTRAN_Neumaticos
         c1grdBusqueda.DataSource = bs_btran_neumaticos
         bnavBusqueda.BindingSource = bs_btran_neumaticos
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ' <summary>
   ' Realiza el enlace de los controles visuales con la clase esquema
   ' </summary>
   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(txtCodigo, "Text", m_etran_neumaticos, "NEUMA_Codigo"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbMarca, "SelectedValue", m_etran_neumaticos, "TIPOS_CodMarca"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtModelo, "Text", m_etran_neumaticos, "NEUMA_Modelo"))

         'If m_etran_neumaticos.NEUMA_FechaGarantia.Year < 1700 Then m_etran_neumaticos.NEUMA_FechaGarantia = DateTime.Now
         'm_listBindHelper.Add(ACBindHelper.ACBind(dtpFecGarantia, "Value", m_etran_neumaticos, "NEUMA_FechaGarantia"))
         'If m_etran_neumaticos.NEUMA_FecCompra.Year < 1700 Then m_etran_neumaticos.NEUMA_FecCompra = DateTime.Now
         'm_listBindHelper.Add(ACBindHelper.ACBind(dtpFecCompra, "Value", m_etran_neumaticos, "NEUMA_FecCompra"))
         'If m_etran_neumaticos.NEUMA_TiempoVidaUtil.Year < 1700 Then m_etran_neumaticos.NEUMA_TiempoVidaUtil = DateTime.Now
         'm_listBindHelper.Add(ACBindHelper.ACBind(dtpVidaUtil, "Value", m_etran_neumaticos, "NEUMA_TiempoVidaUtil"))

         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoLlanta, "SelectedValue", m_etran_neumaticos, "TIPOS_CodTipoLlanta"))
         'm_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", m_etran_neumaticos, "TIPOS_CodMoneda"))
         'm_listBindHelper.Add(ACBindHelper.ACBind(actxnPrecio, "Text", m_etran_neumaticos, "NEUMA_Precio"))
         'm_listBindHelper.Add(ACBindHelper.ACBind(actxnKilomUtil, "Text", m_etran_neumaticos, "NEUMA_KmVidaUtil"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtTamanho, "Text", m_etran_neumaticos, "NEUMA_Tamano"))

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar()
      Try
         If bs_btran_neumaticos.Current IsNot Nothing Then
            Dim x_codigo As Integer = CType(bs_btran_neumaticos.Current, ETRAN_Neumaticos).NEUMA_Id
            managerAdministracionNeumaticos.CargarHistorialNeumatico(x_codigo)
            m_etran_neumaticos = CType(bs_btran_neumaticos.Current, ETRAN_Neumaticos)
            AsignarBinding()

            bs_viajesneumaticos = New BindingSource()
            bs_viajesneumaticos.DataSource = managerAdministracionNeumaticos.ListTRAN_ViajesNeumaticos
            c1grdMovimientosNeumaticos.DataSource = bs_viajesneumaticos
            bnavMovimientosNeumaticos.BindingSource = bs_viajesneumaticos

            c1grdMovimientosNeumaticos.Subtotal(AggregateEnum.Sum, 0, -1, 6, "Total")
            tabMantenimiento.SelectedTab = tabDatos

         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Sub

   ' <summary>
   ' Ejecutar la busqueda de una cadena en la tabla Neumaticos
   ' </summary>
   ' <param name="x_cadena">Cadena objetivo</param>
   ' <returns></returns>
   Private Function busqueda(ByVal x_cadena As String) As Boolean
      Try
            If managerTRAN_Neumaticos.Busqueda(x_cadena, getCampo(), True) Then
                acTool.ACBtnEliminarEnabled = True
                acTool.ACBtnModificarEnabled = True
            Else
                acTool.ACBtnEliminarEnabled = False
                acTool.ACBtnModificarEnabled = False
            End If
         cargarDatos()
         Return acTool.ACBtnModificarEnabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

#End Region

   Private Function getCampo() As String
      Try
         If (rbtnCodigo.Checked) Then
            Return "NEUMA_Codigo"
         ElseIf rbtnModelo.Checked Then
            Return "NEUMA_Modelo"
         Else
            Return "NEUMA_Codigo"
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos de Controles"

#Region " Tool Bar "

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
         acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolReporte
         Me.KeyPreview = False
         For Each Item As ACBindHelper In m_listBindHelper
            Item.ACUnBind()
         Next
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Neumatico", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub acTool_ACBtnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnReporte_Click
      Try
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         acTool.ACBtnEliminarVisible = False
         acTool.ACBtnGrabarVisible = False
         acTool.ACBtnReporteVisible = False
         acTool.ACBtnBuscarVisible = False
         cargar()
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Revisando los Movimientos", ex)
      End Try
   End Sub

#End Region

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

   Private Sub c1grdDetalle_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles c1grdBusqueda.MouseDoubleClick
      Try
         If e.X > c1grdBusqueda.Rows.Fixed Then
            acTool_ACBtnReporte_Click(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar el registro seleccionado", ex)
      End Try

   End Sub

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub


#End Region

   Private Sub tsbtnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnPreview.Click
      Try
         Dim m_listFlex As New ACListaFlex()
         m_listFlex.Add(c1grdMovimientosNeumaticos)
         Dim _sub() As ACTexto = {New ACTexto(String.Format("Codigo: {0}", m_etran_neumaticos.NEUMA_Codigo), New Font(Me.Font.FontFamily, 8, FontStyle.Regular)) _
                               , New ACTexto(String.Format("Marca: {0}", cmbMarca.Text), New Font(Me.Font.FontFamily, 8, FontStyle.Regular)) _
                               , New ACTexto(String.Format("Modelo: {0}", m_etran_neumaticos.NEUMA_Modelo), New Font(Me.Font.FontFamily, 8, FontStyle.Regular)) _
                               , New ACTexto(String.Format("Tipo Neumaticos: {0}", cmbTipoLlanta.Text), New Font(Me.Font.FontFamily, 8, FontStyle.Regular)) _
                               , New ACTexto(String.Format("Tamaño: {0}", m_etran_neumaticos.NEUMA_Tamano), New Font(Me.Font.FontFamily, 8, FontStyle.Regular))}
         Dim x As New ACPreview(m_listFlex, New ACCabecera(New ACTexto("Reporte de Viajes", New Font(Me.Font.FontFamily, 14, FontStyle.Bold)), GApp.ESucursal.SUCUR_Nombre, "", _sub, New Font(Me.Font.FontFamily, 8, FontStyle.Bold)))
         x.setCabecera(New ACTexto() {New ACTexto("Ingresos y Egresos", New Font(Me.Font.FontFamily, 12, FontStyle.Regular))})
         x.setMargen(20.0, 3.0, 8.0, 20.0, UnitTypeEnum.Mm)
         x.setEstilo(ACEEstilo.elegant, False)
         x.setEstiloLinea(New LineDef("2pt", Color.Black))
         x.setFuente(New Font("Courier New", 7.5, FontStyle.Regular))

         x.ACTextoLista = New ACTextoLista()
         x.ACTextoLista.Add(New ACTexto(String.Format("{0}Historial{0}", vbNewLine), New Font(Me.Font.FontFamily, 10, FontStyle.Bold)))

         ''
         x.ACColumnasLista = New ACColumnaAlineacionLista()
         x.ACColumnasLista.Add(New ACColumnaAlineacion(New Unit() {New C1.C1Preview.Unit(0, UnitTypeEnum.Mm) _
                                                                 , New C1.C1Preview.Unit(17, UnitTypeEnum.Mm) _
                                                                 , New C1.C1Preview.Unit(100, UnitTypeEnum.Mm) _
                                                                 , New C1.C1Preview.Unit(21, UnitTypeEnum.Mm) _
                                                                 , New C1.C1Preview.Unit(21, UnitTypeEnum.Mm) _
                                                                 , New C1.C1Preview.Unit(0, UnitTypeEnum.Mm) _
                                                                 , New C1.C1Preview.Unit(23, UnitTypeEnum.Mm)}))
         x.setEstiloLinea(New LineDef(New Unit(0.5, UnitTypeEnum.Mm), Color.Black))

         x.ACEjecutar()
         x.ShowDialog()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Previsualizar Reporte", ex)
      End Try
   End Sub
End Class