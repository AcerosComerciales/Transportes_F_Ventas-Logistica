Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid
Imports ACEVentas

Public Class FConsultaNeumaticos

#Region " Variables "
   Private managerTRAN_Neumaticos As BTRAN_Neumaticos
   Private managerMovimientosNeumaticos As BMovimientosNeumaticos

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_etran_neumaticos As ETRAN_Neumaticos
   Private bs_btran_neumaticos As BindingSource
   Private bs_movimientosneumatico As BindingSource
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
         managerMovimientosNeumaticos = New BMovimientosNeumaticos

         txtBusqueda.Focus()

         acTool.ACBtnEliminarEnabled = False
         acTool.ACBtnModificarEnabled = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdMovimientosNeumaticos, 1, 1, 10, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Tipo Ubicacion", "Destino", "Destino", 100, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Codigo Ubicacion", "TIPOS_CodDestino", "TIPOS_CodDestino", 100, False, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Ubicación", "MOVNM_UbicacionOrigen", "MOVNM_UbicacionOrigen", 250, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Destino", "MOVNM_UbicacionDestino", "MOVNM_UbicacionDestino", 250, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Glosa", "MOVNM_UbicacionDestino", "MOVNM_UbicacionDestino", 250, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Motivo", "MOVNM_Motivo", "MOVNM_Motivo", 250, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Fec. Asignacion", "MOVNM_FECASIGNACION_Text", "MOVNM_FECASIGNACION_Text", 100, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Fec. Retiro", "MOVNM_FECRETIRO_Text", "MOVNM_FECRETIRO_Text", 100, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdMovimientosNeumaticos, index, "Estado", "MOVNM_ESTADO_Text", "MOVNM_ESTADO_Text", 100, True, False, "System.String", "") : index += 1
         c1grdMovimientosNeumaticos.AllowEditing = False
         c1grdMovimientosNeumaticos.Styles.Highlight.BackColor = Color.Gray
         c1grdMovimientosNeumaticos.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdMovimientosNeumaticos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdMovimientosNeumaticos.SelectionMode = SelectionModeEnum.Row
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

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
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            ACFramework.ACUtilitarios.ACLimpiaVar(pnlDatos)
            'txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, True)
            'txtCodigo.Enabled = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

         Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer

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
            'managerTRAN_Neumaticos.Cargar(x_codigo)
            managerMovimientosNeumaticos.cargarMovimientos(x_codigo)
            m_etran_neumaticos = CType(bs_btran_neumaticos.Current, ETRAN_Neumaticos)
            AsignarBinding()

            bs_movimientosneumatico = New BindingSource()
            bs_movimientosneumatico.DataSource = managerMovimientosNeumaticos.ListMovimientosNeumaticos
            c1grdMovimientosNeumaticos.DataSource = bs_movimientosneumatico
            bnavMovimientosNeumaticos.BindingSource = bs_movimientosneumatico

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
            If managerTRAN_Neumaticos.Busqueda(x_cadena, getCampo(), chkTodos.Checked) Then
                acTool.ACBtnEliminarEnabled = True
                acTool.ACBtnModificarEnabled = True
            Else
                acTool.ACBtnEliminarEnabled = False
                acTool.ACBtnModificarEnabled = False
            End If
         cargarDatos()
         Return acTool.ACBtnModificarEnabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar la ayuda de los conductores", ex)
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
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cancelar Neumatico", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
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
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Me.Text)), "No se puede cargar el registro seleccionado", ex)
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

   Private Sub acTool_ACBtnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnReporte_Click
      Try
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         acTool.ACBtnEliminarVisible = False
         acTool.ACBtnGrabarVisible = False
         acTool.ACBtnReporteVisible = False
         acTool.ACBtnBuscarVisible = False
         cargar()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Revisando los Movimientos", ex)
      End Try
   End Sub
#End Region

    Private Sub tabMantenimiento_SelectionChanged(sender As Crownwood.DotNetMagic.Controls.TabControl, oldPage As Crownwood.DotNetMagic.Controls.TabPage, newPage As Crownwood.DotNetMagic.Controls.TabPage) Handles tabMantenimiento.SelectionChanged

    End Sub
End Class