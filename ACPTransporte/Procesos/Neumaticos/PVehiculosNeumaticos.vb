Imports System
Imports System.Collections.Generic
Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid
Imports ACEVentas
Imports ACBVentas


Public Class PNeumaticosVehiculos

#Region " Variables "
   Private managerTRAN_Vehiculos As BTRAN_Vehiculos
   Private managerTRAN_Ranflas As BTRAN_Ranflas
   Private managerTRAN_Neumaticos As BTRAN_Neumaticos
    Private managerTRAN_VehiculosNeumaticos As BTRAN_VehiculosNeumaticos
    Private m_etran_vehiculosNeumaticos As ETRAN_VehiculosNeumaticos


    Private managerAdministracionNeumaticos As BAdministracionNeumaticos

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_etran_vehiculos As ETRAN_Vehiculos
   Private bs_btran_vehiculos As BindingSource
    Private bs_btran_neumaticos As BindingSource
    Private bs_btran_neuamticosRanflas As BindingSource
    Private bs_bMostrarAsignados_vehi_neumaticos As BindingSource
    Private c As BindingSource

    Private m_etran_ranflas As ETRAN_Ranflas
   Private bs_btran_ranflas As BindingSource

    Private bs_seleccionados As BindingSource
    Private bs_seleccionados_quedan As BindingSource

    Private m_listNeuDelanteros As List(Of ENeumaticos)
   Private m_listNeuPosteriores As List(Of ENeumaticos)
   Private m_listNRepuesto As List(Of ETRAN_Neumaticos)
   Private m_listNeumaticos As List(Of ETRAN_Neumaticos)

   Private bs_neuDelanteros As BindingSource
   Private bs_neuPosteriores As BindingSource
   Private bs_neuRepuesto As BindingSource
   Private bs_neumaticos As BindingSource
    Private bs_vehicId As BindingSource
    Private m_edocumentos As EDocumentos

    'Bandera creado por frank 
    Private ejecutado As Boolean = False

    Private m_unidad As TipoUnidad

   Enum TipoInicio
      Normal
      Neumaticos
      NeumaticosDetalle
      NeumaticosDetalleBarra
   End Enum

   Enum TipoUnidad
      Vehiculos
      Ranflas
   End Enum

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

   Public Sub New(ByVal x_opcion As TipoInicio, ByVal x_vehic_id As Long, Optional ByVal x_unidad As TipoUnidad = TipoUnidad.Ranflas)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Try
         setInicio(x_opcion)
         m_unidad = x_unidad

         tabMantenimiento.SelectedTab = tabDatos
         Select Case x_opcion
            Case TipoInicio.Neumaticos
               pnlNeumaticos.Visible = True
               pnlSeleccionados.Visible = False
               acToolH.Visible = False
               Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
               Me.WindowState = FormWindowState.Maximized
            Case TipoInicio.NeumaticosDetalle
               pnlNeumaticos.Visible = True
               pnlSeleccionados.Visible = True
               acToolH.Visible = False
            Case Else
               pnlNeumaticos.Visible = True
               pnlSeleccionados.Visible = False
               acToolH.Visible = False
         End Select
         formatearGrilla()
         cargarCombos()
         m_listBindHelper = New List(Of ACBindHelper)()
         cargar(x_vehic_id)

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Public Sub New(Optional ByVal x_unidad As TipoUnidad = TipoUnidad.Vehiculos)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         m_unidad = x_unidad
         setInicio(TipoInicio.Normal)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub setInicio(ByVal x_opcion As TipoInicio)
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         If x_opcion = TipoInicio.Normal Then
            tabMantenimiento.SelectedTab = tabBusqueda
            formatearGrilla()
            cargarCombos()
            m_listBindHelper = New List(Of ACBindHelper)()
         End If
         managerTRAN_Vehiculos = New BTRAN_Vehiculos
         managerTRAN_Neumaticos = New BTRAN_Neumaticos
         managerTRAN_VehiculosNeumaticos = New BTRAN_VehiculosNeumaticos
         managerTRAN_Ranflas = New BTRAN_Ranflas

         managerAdministracionNeumaticos = New BAdministracionNeumaticos

         Select Case m_unidad
            Case TipoUnidad.Ranflas
               acpnlTitulo.ACCaption = "Neumaticos: Ranflas"
               Me.Text = "Neumaticos: Ranflas"
            Case TipoUnidad.Vehiculos
               acpnlTitulo.ACCaption = "Neumaticos: Vehiculos"
               Me.Text = "Neumaticos: Vehiculos"
            Case Else
               acpnlTitulo.ACCaption = "Neumaticos: Vehiculos"
               Me.Text = "Neumaticos: Vehiculos"
         End Select
         acToolH.ACBtnModificarEnabled = False
      Catch ex As Exception
         Throw ex
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
            Select Case m_unidad
                Case TipoUnidad.Vehiculos
                    formatearGrilla_Vehiculos()
                Case TipoUnidad.Ranflas
                    formatearGrilla_Ranflas()
            End Select
            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdSeleccionados, 1, 1, 14, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Codigo", "NEUMA_Codigo", "NEUMA_Codigo", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Orden", "VNEUM_Orden", "VNEUM_Orden", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Sección", "VNEUM_SECCION_Text", "VNEUM_SECCION_Text", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Posición", "VNEUM_OrdenPosicion", "VNEUM_OrdenPosicion", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Lado", "VNEUM_LADO_Text", "VNEUM_LADO_Text", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Interno/Externo", "VNEUM_INTERNOEXTERNO_Text", "VNEUM_INTERNOEXTERNO_Text", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Marca", "TIPO_Marca", "TIPO_Marca", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Modelo", "NEUMA_Modelo", "NEUMA_Modelo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Tipo Llanda", "TIPO_Llanta", "TIPO_Llanta", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Tamaño Neumatico", "Neuma_Tamano", "Neuma_Tamano", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Neumatico Precio", "Neuma_precio", "Neuma_precio", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Kilometraje", "NEUMA_KmVidaUtil", "NEUMA_KmVidaUtil", 100, True, True, "System.Decimal", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdSeleccionados, index, "Compra", "NEUMA_FecCompra", "NEUMA_FecCompra", 100, True, True, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

            c1grdSeleccionados.AllowEditing = False
            c1grdSeleccionados.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdSeleccionados.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdSeleccionados.Styles.Highlight.BackColor = Color.Gray

            c1grdSeleccionados.AutoResize = True
            ''*****************************************************************************************************

            formatearGrilla_Neumaticos()
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
        End Try
    End Sub

    Private Sub formatearGrilla_Vehiculos()
        Dim index As Integer = 1
        Try
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 8, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "VEHIC_Codigo", "VEHIC_Codigo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Placa", "VEHIC_Placa", "VEHIC_Placa", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Sucursal", "SUCUR_Nombre", "SUCUR_Nombre", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Tipo Vehiculo", "TIPOS_Vehiculo", "TIPOS_Vehiculo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Marca", "TIPOS_Marca", "TIPOS_Marca", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Modelo", "VEHIC_Modelo", "VEHIC_Modelo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Adq.", "VEHIC_FecAdquisicion", "VEHIC_FecAdquisicion", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

            c1grdBusqueda.AllowEditing = False
            c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
            c1grdBusqueda.SelectionMode = SelectionModeEnum.Row

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub formatearGrilla_Ranflas()
        Dim index As Integer = 1
        Try
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 7, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "RANFL_Codigo", "RANFL_Codigo", 150, True, False, "System.Integer", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Sucursal", "SUCUR_Nombre", "SUCUR_Nombre", 150, False, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Marca", "TIPOS_Marca", "TIPOS_Marca", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Placa", "RANFL_Placa", "RANFL_Placa", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Certificado", "RANFL_Certificado", "RANFL_Certificado", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fec. Adquisición", "RANFL_FecAdquisicion", "RANFL_FecAdquisicion", 150, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1

            c1grdBusqueda.AllowEditing = False
            c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
            c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub formatearGrilla_Neumaticos()
        Dim index As Integer = 1
        Try
            '' Neumaticos
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdNDIzquierdo, 1, 1, 3, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNDIzquierdo, index, "Lado Externo", "IZQ_EXT_NEUMA_CODIGO", "IZQ_EXT_VNEUM_CODIGO", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNDIzquierdo, index, "Lado Interno", "IZQ_INT_NEUMA_CODIGO", "IZQ_INT_NEUMA_CODIGO", 100, True, True, "System.String", "") : index += 1
            c1grdNDIzquierdo.AllowAddNew = True
            c1grdNDIzquierdo.AutoResize = False
            c1grdNDIzquierdo.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdNDIzquierdo.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdNDDerecho, 1, 1, 3, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNDDerecho, index, "Lado Interno", "DER_INT_NEUMA_CODIGO", "DER_INT_NEUMA_CODIGO", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNDDerecho, index, "Lado Externo", "DER_EXT_NEUMA_CODIGO", "DER_EXT_NEUMA_CODIGO", 100, True, True, "System.String", "") : index += 1
            c1grdNDDerecho.AllowAddNew = True
            c1grdNDDerecho.AutoResize = False
            c1grdNDDerecho.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdNDDerecho.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdNPIzquierdo, 1, 1, 3, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNPIzquierdo, index, "Lado Externo", "IZQ_EXT_NEUMA_CODIGO", "IZQ_EXT_NEUMA_CODIGO", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNPIzquierdo, index, "Lado Interno", "IZQ_INT_NEUMA_CODIGO", "IZQ_INT_NEUMA_CODIGO", 100, True, True, "System.String", "") : index += 1
            c1grdNPIzquierdo.AllowAddNew = True
            c1grdNPIzquierdo.AutoResize = False
            c1grdNPIzquierdo.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdNPIzquierdo.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdNPDerecho, 1, 1, 3, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNPDerecho, index, "Lado Interno", "DER_INT_NEUMA_CODIGO", "DER_INT_NEUMA_CODIGO", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNPDerecho, index, "Lado Externo", "DER_EXT_NEUMA_CODIGO", "DER_EXT_NEUMA_CODIGO", 100, True, True, "System.String", "") : index += 1
            c1grdNPDerecho.AllowAddNew = True
            c1grdNPDerecho.AutoResize = False
            c1grdNPDerecho.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdNPDerecho.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            index = 1
            ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdNRepuesto, 1, 1, 5, 1, 0)
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNRepuesto, index, "Codigo", "NEUMA_Codigo", "NEUMA_Codigo", 100, True, True, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNRepuesto, index, "Marca", "TIPO_Marca", "TIPO_Marca", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNRepuesto, index, "Modelo", "NEUMA_Modelo", "NEUMA_Modelo", 150, True, False, "System.String", "") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNRepuesto, index, "Tipo Llanta", "TIPO_Llanta", "TIPO_Llanta", 150, True, False, "System.String", "") : index += 1

            c1grdNRepuesto.AllowAddNew = True
            c1grdNRepuesto.AutoResize = False
            c1grdNRepuesto.Styles.Alternate.BackColor = Color.WhiteSmoke
            c1grdNRepuesto.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            'c1grdDetalle.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

            Dim csNDIzquierdo As CellStyle
            csNDIzquierdo = c1grdNDIzquierdo.Styles.Add("NDIzquierdo")
            csNDIzquierdo.ComboList = "..."
            'csNDIzquierdo.Font = New Font(csNDIzquierdo.Font.Name, csNDIzquierdo.Font.Size, FontStyle.Regular)
            c1grdNDIzquierdo.Cols("IZQ_INT_NEUMA_CODIGO").Style = csNDIzquierdo
            c1grdNDIzquierdo.Cols("IZQ_EXT_NEUMA_CODIGO").Style = csNDIzquierdo

            Dim csNDDerecho As CellStyle
            csNDDerecho = c1grdNDDerecho.Styles.Add("NDIDerecho")
            csNDDerecho.ComboList = "..."
            'csNDDerecho.Font = New Font(csNDDerecho.Font.Name, csNDDerecho.Font.Size, FontStyle.Regular)
            c1grdNDDerecho.Cols("DER_INT_NEUMA_CODIGO").Style = csNDDerecho
            c1grdNDDerecho.Cols("DER_EXT_NEUMA_CODIGO").Style = csNDDerecho

            Dim csNPIzquierdo As CellStyle
            csNPIzquierdo = c1grdNPIzquierdo.Styles.Add("NPIzquierdo")
            csNPIzquierdo.ComboList = "..."
            'csNPIzquierdo.Font = New Font(csNPIzquierdo.Font.Name, csNPIzquierdo.Font.Size, FontStyle.Regular)
            c1grdNPIzquierdo.Cols("IZQ_INT_NEUMA_CODIGO").Style = csNPIzquierdo
            c1grdNPIzquierdo.Cols("IZQ_EXT_NEUMA_CODIGO").Style = csNPIzquierdo

            Dim csNPDerecho As CellStyle
            csNPDerecho = c1grdNDDerecho.Styles.Add("NPIDerecho")
            csNPDerecho.ComboList = "..."
            'csNPDerecho.Font = New Font(csNPDerecho.Font.Name, csNPDerecho.Font.Size, FontStyle.Regular)
            c1grdNPDerecho.Cols("DER_INT_NEUMA_CODIGO").Style = csNPDerecho
            c1grdNPDerecho.Cols("DER_EXT_NEUMA_CODIGO").Style = csNPDerecho

            Dim csRepuesto As CellStyle
            csRepuesto = c1grdNDDerecho.Styles.Add("NRepuesto")
            csRepuesto.ComboList = "..."
            'csNPDerecho.Font = New Font(csNPDerecho.Font.Name, csNPDerecho.Font.Size, FontStyle.Regular)
            c1grdNRepuesto.Cols("NEUMA_Codigo").Style = csNPDerecho

            c1grdNDIzquierdo.ShowButtons = ShowButtonsEnum.Always
            c1grdNDIzquierdo.Styles.Highlight.BackColor = Color.Gray

            c1grdNDDerecho.ShowButtons = ShowButtonsEnum.Always
            c1grdNDDerecho.Styles.Highlight.BackColor = Color.Gray

            c1grdNPIzquierdo.ShowButtons = ShowButtonsEnum.Always
            c1grdNPIzquierdo.Styles.Highlight.BackColor = Color.Gray

            c1grdNPDerecho.ShowButtons = ShowButtonsEnum.Always
            c1grdNPDerecho.Styles.Highlight.BackColor = Color.Gray

            AddHandler c1grdNDIzquierdo.CellButtonClick, AddressOf c1grdDelanteras_CellButtonClick
            AddHandler c1grdNDDerecho.CellButtonClick, AddressOf c1grdDelanteras_CellButtonClick

            AddHandler c1grdNPIzquierdo.CellButtonClick, AddressOf c1grdPosteriores_CellButtonClick
            AddHandler c1grdNPDerecho.CellButtonClick, AddressOf c1grdPosteriores_CellButtonClick

            AddHandler c1grdNRepuesto.CellButtonClick, AddressOf c1grdNRepuesto_CellButtonClick
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cargarCombos()
        Try
            'ACFramework.ACUtilitarios.ACCargaCombo(cmbMarca, Colecciones.Tipos(ETipos.MyTipos.MarcasNeumaticos), "TIPOS_Descripcion", "TIPOS_Codigo")
            'ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoLlanta, Colecciones.Tipos(ETipos.MyTipos.TipoNeumatico), "TIPOS_Descripcion", "TIPOS_Codigo")
            'ACFramework.ACUtilitarios.ACCargaCombo(cmbMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_Descripcion", "TIPOS_Codigo")
            'ACFramework.ACUtilitarios.ACCargaCombo(cmbSucursal, Colecciones.Sucursales, "SUCUR_Nombre", "SUCUR_Id")
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

    Private Sub setBlankDelanteros(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
        Try
            If c1grdNDIzquierdo.Cols(e.Col).Name = "IZQ_EXT_NEUMA_CODIGO" And sender.Name = "c1grdNDIzquierdo" Then
                CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_EXT_VNEUM_ID = 0
                CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_EXT_NEUMA_CODIGO = Nothing
            End If
            If c1grdNDIzquierdo.Cols(e.Col).Name = "IZQ_INT_NEUMA_CODIGO" And sender.Name = "c1grdNDIzquierdo" Then
                CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_INT_VNEUM_ID = 0
                CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_INT_NEUMA_CODIGO = Nothing
            End If
            If c1grdNDDerecho.Cols(e.Col).Name = "DER_INT_NEUMA_CODIGO" And sender.Name = "c1grdNDDerecho" Then
                CType(bs_neuDelanteros.Current, ENeumaticos).DER_INT_VNEUM_ID = 0
                CType(bs_neuDelanteros.Current, ENeumaticos).DER_INT_NEUMA_CODIGO = Nothing
            End If
            If c1grdNDDerecho.Cols(e.Col).Name = "DER_EXT_NEUMA_CODIGO" And sender.Name = "c1grdNDDerecho" Then
                CType(bs_neuDelanteros.Current, ENeumaticos).DER_EXT_VNEUM_ID = 0
                CType(bs_neuDelanteros.Current, ENeumaticos).DER_EXT_NEUMA_CODIGO = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub setBlankPosteriores(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
        Try
            If c1grdNPIzquierdo.Cols(e.Col).Name = "IZQ_EXT_NEUMA_CODIGO" And sender.Name = "c1grdNPIzquierdo" Then
                CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_EXT_VNEUM_ID = 0
                CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_EXT_NEUMA_CODIGO = Nothing
            End If
            If c1grdNPIzquierdo.Cols(e.Col).Name = "IZQ_INT_NEUMA_CODIGO" And sender.Name = "c1grdNPIzquierdo" Then
                CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_INT_VNEUM_ID = 0
                CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_INT_NEUMA_CODIGO = Nothing
            End If
            If c1grdNPDerecho.Cols(e.Col).Name = "DER_INT_NEUMA_CODIGO" And sender.Name = "c1grdNPDerecho" Then
                CType(bs_neuPosteriores.Current, ENeumaticos).DER_INT_VNEUM_ID = 0
                CType(bs_neuPosteriores.Current, ENeumaticos).DER_INT_NEUMA_CODIGO = Nothing
            End If
            If c1grdNPDerecho.Cols(e.Col).Name = "DER_EXT_NEUMA_CODIGO" And sender.Name = "c1grdNPDerecho" Then
                CType(bs_neuPosteriores.Current, ENeumaticos).DER_EXT_VNEUM_ID = 0
                CType(bs_neuPosteriores.Current, ENeumaticos).DER_EXT_NEUMA_CODIGO = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Cargar Datos "
    ' <summary>
    ' Cargar los datos en el control Visual C1FlexGrid
    ' </summary>
    Private Sub cargarDatos()
        Try
            Select Case m_unidad
                Case TipoUnidad.Vehiculos
                    bs_btran_vehiculos = New BindingSource()
                    bs_btran_vehiculos.DataSource = managerTRAN_Vehiculos.getListTRAN_Vehiculos
                    c1grdBusqueda.DataSource = bs_btran_vehiculos
                    bnavBusqueda.BindingSource = bs_btran_vehiculos
                Case TipoUnidad.Ranflas
                    bs_btran_ranflas = New BindingSource()
                    bs_btran_ranflas.DataSource = managerTRAN_Ranflas.getListTRAN_Ranflas
                    c1grdBusqueda.DataSource = bs_btran_ranflas
                    bnavBusqueda.BindingSource = bs_btran_ranflas
            End Select
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
            'm_listBindHelper.Add(ACBindHelper.ACBind(txtCodigo, "Text", m_etran_neumaticos, "NEUMA_Codigo"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(cmbSucursal, "SelectedValue", m_etran_neumaticos, "SUCUR_Id"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(cmbMarca, "SelectedValue", m_etran_neumaticos, "TIPOS_CodMarca"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(txtModelo, "Text", m_etran_neumaticos, "NEUMA_Modelo"))

            'If m_etran_neumaticos.NEUMA_FechaGarantia.Year < 1700 Then m_etran_neumaticos.NEUMA_FechaGarantia = DateTime.Now
            'm_listBindHelper.Add(ACBindHelper.ACBind(dtpFecGarantia, "Value", m_etran_neumaticos, "NEUMA_FechaGarantia"))
            'If m_etran_neumaticos.NEUMA_FecCompra.Year < 1700 Then m_etran_neumaticos.NEUMA_FecCompra = DateTime.Now
            'm_listBindHelper.Add(ACBindHelper.ACBind(dtpFecCompra, "Value", m_etran_neumaticos, "NEUMA_FecCompra"))
            'If m_etran_neumaticos.NEUMA_TiempoVidaUtil.Year < 1700 Then m_etran_neumaticos.NEUMA_TiempoVidaUtil = DateTime.Now
            'm_listBindHelper.Add(ACBindHelper.ACBind(dtpVidaUtil, "Value", m_etran_neumaticos, "NEUMA_TiempoVidaUtil"))

            'm_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoLlanta, "SelectedValue", m_etran_neumaticos, "TIPOS_CodTipoLlanta"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", m_etran_neumaticos, "TIPOS_CodMoneda"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(actxnPrecio, "Text", m_etran_neumaticos, "NEUMA_Precio"))
            'm_listBindHelper.Add(ACBindHelper.ACBind(actxnKilomUtil, "Text", m_etran_neumaticos, "NEUMA_KmVidaUtil"))


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cargar()
        Try
            Select Case m_unidad
                Case TipoUnidad.Vehiculos
                    If Not IsNothing(bs_btran_vehiculos) Then
                        If Not IsNothing(bs_btran_vehiculos.Current) Then
                            Dim x_codigo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
                            cargar(x_codigo)
                        End If
                    End If
                Case TipoUnidad.Ranflas
                    If Not IsNothing(bs_btran_ranflas) Then
                        If Not IsNothing(bs_btran_ranflas.Current) Then
                            Dim x_codigo As Integer = CType(bs_btran_ranflas.Current, ETRAN_Ranflas).RANFL_Id
                            cargar(x_codigo)
                        End If
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cargar(ByVal x_codigo As Long)
        Try
            'Iiniciando por Primera vez Buscando las LLantas 
            m_listNeuDelanteros = New List(Of ENeumaticos)()
            m_listNeuPosteriores = New List(Of ENeumaticos)()
            m_listNeumaticos = New List(Of ETRAN_Neumaticos)
            m_listNRepuesto = New List(Of ETRAN_Neumaticos)
            Select Case m_unidad
                Case TipoUnidad.Vehiculos
                    If Not managerAdministracionNeumaticos.CargarTodosVehiculos(x_codigo) Then
                        'SI NO HAY NEUMATICOS ASIGNADOS AL VEHICULO 
                        setActive(True)
                    End If
                    'SI YA TIENE UN NEUMATICO ASIGNADO
                    'Independientemente de si es o no 
                    setActive(True)
                    managerTRAN_Vehiculos.Cargar(x_codigo)
                    m_etran_vehiculos = managerTRAN_Vehiculos.getTRAN_Vehiculos()
                Case TipoUnidad.Ranflas
                    pnlFrontales.Visible = False
                    If Not managerAdministracionNeumaticos.CargarTodosRanflas(x_codigo) Then
                        setActive(True)
                    End If
                    managerTRAN_Ranflas.Cargar(x_codigo)
                    m_etran_ranflas = managerTRAN_Ranflas.getTRAN_Ranflas()
            End Select
            If managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos.Count > 0 Then
                For Each Item As ETRAN_VehiculosNeumaticos In managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos
                    m_listNeumaticos.Add(New ETRAN_Neumaticos(Item.NEUMA_Id, Item.NEUMA_Codigo, Item.NEUMA_Modelo _
                                                            , Item.TIPO_Llanta, Item.TIPO_Marca, Item.NEUMA_FecCompra, Item.NEUMA_KmVidaUtil _
                                                            , Item.VNEUM_Seccion, Item.VNEUM_Lado, Item.VNEUM_OrdenPosicion, Item.VNEUM_Orden _
                                                            , Item.VNEUM_InternoExterno, False))
                Next
                cargarInterfaz()
                ' setActive(False) esto esta en False 
                setActive(True)

                c1grdNDDerecho.AutoSizeCols()
                c1grdNDIzquierdo.AutoSizeCols()
                c1grdNPDerecho.AutoSizeCols()
                c1grdNPIzquierdo.AutoSizeCols()

                acToolH.ACBtnGrabarVisible = True 'Habilitamos esto ya se va volver a grabar neumaticos y esto tien que ser visiable
            Else
                setActive(True)
            End If
            setData()
            tabMantenimiento.SelectedTab = tabDatos
        Catch ex As Exception
            acToolH.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            Throw ex
        End Try
    End Sub

    Private Sub setActive(ByVal x_opcion As Boolean)
        c1grdNDDerecho.AllowEditing = x_opcion
        c1grdNDDerecho.EditMask = True
        c1grdNDIzquierdo.AllowEditing = x_opcion
        'ahora aqui se va a poner la condicion si es rangla o si es vehiculo 
        'porque cuando es ranfla si tiene que tener sus cuatro ruedas 
        Select Case m_unidad
            Case TipoUnidad.Vehiculos
                c1grdNDIzquierdo.Cols(2).Visible = False
                c1grdNDIzquierdo.Cols(1).Caption = "Delantero Izquierdo"

                c1grdNDDerecho.Cols(1).Visible = False
                c1grdNDDerecho.Cols(1).Caption = "Delantero Derecho"

            Case TipoUnidad.Ranflas
                c1grdNDIzquierdo.Cols(2).Visible = True
                c1grdNDDerecho.Cols(2).Visible = True
        End Select

        c1grdNRepuesto.AllowEditing = x_opcion

        c1grdNPDerecho.AllowEditing = x_opcion
        c1grdNPIzquierdo.AllowEditing = x_opcion

        c1grdNDDerecho.AllowAddNew = x_opcion
        c1grdNDIzquierdo.AllowAddNew = x_opcion

        c1grdNPDerecho.AllowAddNew = x_opcion
        c1grdNPIzquierdo.AllowAddNew = x_opcion

        c1grdNRepuesto.AllowAddNew = x_opcion

    End Sub

    Private Sub setData()
        Try
            'aca se envia datos a las tablas segun los datos de 
            'de los Binding 
            bs_neuDelanteros = New BindingSource()
            bs_neuDelanteros.DataSource = m_listNeuDelanteros
            c1grdNDIzquierdo.DataSource = bs_neuDelanteros
            c1grdNDDerecho.DataSource = bs_neuDelanteros
            bnavNDelanteros.BindingSource = bs_neuDelanteros

            bs_neuPosteriores = New BindingSource()
            bs_neuPosteriores.DataSource = m_listNeuPosteriores
            c1grdNPIzquierdo.DataSource = bs_neuPosteriores
            c1grdNPDerecho.DataSource = bs_neuPosteriores
            bnavNPosteriores.BindingSource = bs_neuPosteriores

            bs_neumaticos = New BindingSource()
            bs_neumaticos.DataSource = m_listNeumaticos
            ' bs_seleccionados_queda
            c1grdSeleccionados.DataSource = bs_neumaticos
            If (m_listNeumaticos.Count = 0) Then
                c1grdSeleccionados.Enabled = False
            Else
                c1grdSeleccionados.Enabled = True
            End If


            bnavNeumaticos.BindingSource = bs_neumaticos
            '----------------------------------------------------------------NO MODIFICAR ESTO SE EJECUTA LA PRIMERA VEZ 
            bs_neuRepuesto = New BindingSource
            bs_neuRepuesto.DataSource = m_listNRepuesto
            c1grdNRepuesto.DataSource = bs_neuRepuesto
            bnavRepuesto.BindingSource = bs_neuRepuesto
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    ' <summary>
    ' Ejecutar la busqueda de una cadena en la tabla Neumaticos
    ' </summary>
    ' <param name="x_cadena">Cadena objetivo</param>
    ' <returns></returns>
    Private Function busqueda(ByVal x_cadena As String) As Boolean
      Try
         Select Case m_unidad
            Case TipoUnidad.Vehiculos
               If managerTRAN_Vehiculos.Busqueda(getCampo(), x_cadena) Then
                  acToolH.ACBtnModificarEnabled = True
               Else
                  acToolH.ACBtnModificarEnabled = False
               End If
                Case TipoUnidad.Ranflas
                    If managerTRAN_Ranflas.Busqueda(x_cadena, getCampo(), chkTodos.Checked) Then
                        acToolH.ACBtnModificarEnabled = True
                    Else
                        acToolH.ACBtnModificarEnabled = False
                    End If
            End Select
         cargarDatos()
         Return acToolH.ACBtnModificarEnabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Sub cargarInterfaz()
      Try
         Dim _maxD As Integer = 0
         Dim _maxP As Integer = 0
         Dim _maxR As Integer = 0
            For Each Item As ETRAN_Neumaticos In m_listNeumaticos
                If _maxD < Item.VNEUM_OrdenPosicion And Item.VNEUM_Seccion.Equals(ACETransporte.Constantes.getSeccionNeumatico(ACETransporte.Constantes.SeccionNeumatico.Delanteros)) Then _maxD = Item.VNEUM_OrdenPosicion
                If _maxP < Item.VNEUM_OrdenPosicion And Item.VNEUM_Seccion.Equals(ACETransporte.Constantes.getSeccionNeumatico(ACETransporte.Constantes.SeccionNeumatico.Posteriores)) Then _maxP = Item.VNEUM_OrdenPosicion
                If _maxR < Item.VNEUM_OrdenPosicion And Item.VNEUM_Seccion.Equals(ACETransporte.Constantes.getSeccionNeumatico(ACETransporte.Constantes.SeccionNeumatico.Posteriores)) Then _maxR = Item.VNEUM_OrdenPosicion
            Next
            '' Neumaticos Delanteros
            m_listNeuDelanteros = New List(Of ENeumaticos)(_maxD)
         Dim _pos As Integer = 0
         For index As Integer = 1 To _maxD
            Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
            _filter.ACFiltro = "VNEUM_OrdenPosicion=" & index.ToString()
            _filter.ACFiltrar(m_listNeumaticos)
            If _filter.ACListaFiltrada.Count > 0 Then
               m_listNeuDelanteros.Add(New ENeumaticos)
               For Each Item As ETRAN_Neumaticos In _filter.ACListaFiltrada
                  If Item.VNEUM_Lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Izquierdo) Then
                     If Item.VNEUM_InternoExterno = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Interno) Then
                        m_listNeuDelanteros(_pos).IZQ_INT_NEUMA_CODIGO = Item.NEUMA_Codigo
                        m_listNeuDelanteros(_pos).IZQ_INT_VNEUM_ID = Item.NEUMA_Id
                     ElseIf Item.VNEUM_InternoExterno = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Externo) Then
                        m_listNeuDelanteros(_pos).IZQ_EXT_NEUMA_CODIGO = Item.NEUMA_Codigo
                        m_listNeuDelanteros(_pos).IZQ_EXT_VNEUM_ID = Item.NEUMA_Id
                     End If
                  ElseIf Item.VNEUM_Lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Derecho) Then
                     If Item.VNEUM_InternoExterno = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Interno) Then
                        m_listNeuDelanteros(_pos).DER_INT_NEUMA_CODIGO = Item.NEUMA_Codigo
                        m_listNeuDelanteros(_pos).DER_INT_VNEUM_ID = Item.NEUMA_Id
                     ElseIf Item.VNEUM_InternoExterno = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Externo) Then
                        m_listNeuDelanteros(_pos).DER_EXT_NEUMA_CODIGO = Item.NEUMA_Codigo
                        m_listNeuDelanteros(_pos).DER_EXT_VNEUM_ID = Item.NEUMA_Id
                     End If
                  End If
               Next
               _pos += 1
            End If
         Next
         _maxD += _pos
         _pos = 0
         '' Neumaticos Posteriores
         For index As Integer = _maxD To _maxP
            Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
            _filter.ACFiltro = "VNEUM_OrdenPosicion=" & index.ToString()
            _filter.ACFiltrar(m_listNeumaticos)
            If _filter.ACListaFiltrada.Count > 0 Then
               m_listNeuPosteriores.Add(New ENeumaticos)

               For Each Item As ETRAN_Neumaticos In _filter.ACListaFiltrada
                  If Item.VNEUM_Lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Izquierdo) Then
                     If Item.VNEUM_InternoExterno = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Interno) Then
                        m_listNeuPosteriores(_pos).IZQ_INT_NEUMA_CODIGO = Item.NEUMA_Codigo
                        m_listNeuPosteriores(_pos).IZQ_INT_VNEUM_ID = Item.NEUMA_Id
                     ElseIf Item.VNEUM_InternoExterno = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Externo) Then
                        m_listNeuPosteriores(_pos).IZQ_EXT_NEUMA_CODIGO = Item.NEUMA_Codigo
                        m_listNeuPosteriores(_pos).IZQ_EXT_VNEUM_ID = Item.NEUMA_Id
                     End If
                  ElseIf Item.VNEUM_Lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Derecho) Then
                     If Item.VNEUM_InternoExterno = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Interno) Then
                        m_listNeuPosteriores(_pos).DER_INT_NEUMA_CODIGO = Item.NEUMA_Codigo
                        m_listNeuPosteriores(_pos).DER_INT_VNEUM_ID = Item.NEUMA_Id
                     ElseIf Item.VNEUM_InternoExterno = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Externo) Then
                        m_listNeuPosteriores(_pos).DER_EXT_NEUMA_CODIGO = Item.NEUMA_Codigo
                        m_listNeuPosteriores(_pos).DER_EXT_VNEUM_ID = Item.NEUMA_Id
                     End If
                  End If
               Next
               _pos += 1
            End If
         Next
         '' Neumaticos de Repuesto
         For index As Integer = _maxP To _maxR
            m_listNRepuesto.Add(m_listNeumaticos(index))
         Next

      Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
   End Sub

   Private Sub c1grdDelanteras_CellButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
      Dim rcI As Rectangle = c1grdNDIzquierdo.GetCellRect(e.Row, e.Col)
      Dim rcD As Rectangle = c1grdNDDerecho.GetCellRect(e.Row, e.Col)
      rcI.Offset(0, rcI.Height)
      rcD.Offset(0, rcD.Height)
      Try

         Dim _neuma_id As Long = -1
         Dim _orden As Long = -1
         Dim _edit As Boolean = False
            If sender.Name = "c1grdNDIzquierdo" Then
                If Not IsNothing(c1grdNDIzquierdo.Rows(e.Row)(e.Col)) Then
                    If Not c1grdNDIzquierdo.Rows(e.Row)(e.Col).ToString().Equals("") Then
                        _edit = True
                        If c1grdNDIzquierdo.Cols(e.Col).Name = "IZQ_EXT_NEUMA_CODIGO" Then
                            _neuma_id = CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_EXT_VNEUM_ID
                        ElseIf c1grdNDIzquierdo.Cols(e.Col).Name = "IZQ_INT_NEUMA_CODIGO" Then
                            _neuma_id = CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_INT_VNEUM_ID
                        End If
                        _orden = 1
                    End If
                End If
            ElseIf sender.Name = "c1grdNDDerecho" Then
                If Not IsNothing(c1grdNDDerecho.Rows(e.Row)(e.Col)) Then
                    If Not c1grdNDDerecho.Rows(e.Row)(e.Col).ToString().Equals("") Then
                        _edit = True
                        If c1grdNDDerecho.Cols(e.Col).Name = "DER_INT_NEUMA_CODIGO" Then
                            _neuma_id = CType(bs_neuDelanteros.Current, ENeumaticos).DER_INT_VNEUM_ID
                        ElseIf c1grdNDDerecho.Cols(e.Col).Name = "DER_EXT_NEUMA_CODIGO" Then
                            _neuma_id = CType(bs_neuDelanteros.Current, ENeumaticos).DER_EXT_VNEUM_ID
                        End If
                        _orden = 2
                    End If
                End If
            End If
            '_edit = True
            If _edit Then
            Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
            _filter.ACFiltro = "NEUMA_Id=" & _neuma_id.ToString()
            If _filter.ACFiltrar(m_listNeumaticos).Count > 0 Then
               m_listNeumaticos.Remove(_filter.ACListaFiltrada(0))
            End If
            bs_neumaticos.ResetBindings(False)
         End If
            'Comentados por Frank para evitar que no muestre los nuematicos 
            Dim _where As New Hashtable()
            '_where.Add("TIPOS_CodTipoLlanta", New ACFramework.ACWhere("'" & ACETransporte.Constantes.getTipoLlanta(ACETransporte.Constantes.TipoLlanta.Lineal) & "','" & ACETransporte.Constantes.getTipoLlanta(ACETransporte.Constantes.TipoLlanta.TodasPosiciones) & "'", ACFramework.ACWhere.TipoWhere._In))
            'Hasta aqui .....
            '_where.Add("NEUMA_Id", New ACFramework.ACWhere("Select NEUMA_Id From Transportes.TRAN_VehiculosNeumaticos Where VNEUM_Estado = 'A'", ACFramework.ACWhere.TipoWhere._NotIn))
            '_where.Add("NEUMA_Id", New ACFramework.ACWhere("(Select NEUMA_Id From Transportes.TRAN_VehiculosNeumaticos Where VNEUM_Estado = 'A')", ACFramework.ACWhere.TipoWhere._NotIn))
            If m_listNeumaticos.Count > 0 Then
            Dim _sel As String = ""
            For Each item As ETRAN_Neumaticos In m_listNeumaticos
               If _sel.Length = 0 Then
                  _sel &= String.Format("{0}", item.NEUMA_Id)
               Else
                  _sel &= String.Format(",{0}", item.NEUMA_Id)
               End If
            Next
                _where.Add("Neu.NEUMA_Id", New ACFramework.ACWhere(_sel, ACFramework.ACWhere.TipoWhere._NotIn))
            End If
            '*

            'Dim _campos() As ACCampos = {New ACCampos("@Opcion", x_campo)}
            '                             New ACCampos("@Cadena", x_cadenas),
            '                             New ACCampos("@ROLES_Id", x_opcion.GetHashCode.ToString())}
            'Dim _busqueda As New ACCampos("@Cadena", x_descripcion)

            'Dim Ayuda As New ACControlesC1.ACAyudaTextFlex("Buscar Entidad", "ENTISS_TodosAyuda", _campos, _busqueda, False)
            '/
            '

            'ANTIGUO ======================================================================================================================================================
            managerTRAN_Neumaticos.CargarAyuda(_where)
            'Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Neumatico", managerTRAN_Neumaticos.DTTRAN_Neumaticos, False)
            '==================================================================================================================================
            '==============================================BUSQUEDA POR CODIGO DE NEUMATICOS AGREGADO FRANK =======================
            Dim x_campo As String = "0"
            Dim x_busqueda As String = " "
            Dim _campos() As ACCampos = {New ACCampos("@Neuma_Codigo", x_campo)}
            Dim _busqueda As New ACCampos("@Neuma_Codigo", x_busqueda)
            'Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Neumaticos", managerTRAN_Neumaticos.DTTRAN_Neumaticos, False)
            Dim Ayuda As New ACControlesC1.ACAyudaTextFlex("Buscar Entidad", "AYUDASS_TodosNeumaticos", _campos, _busqueda, False)
            If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Dim _interno As Integer = Ayuda.Respuesta.Rows(0)("Interno") 'id_neumatico
                Dim _codigo As String = Ayuda.Respuesta.Rows(0)("Codigo").ToString()
                Dim _ranfla_id As Integer = Ayuda.Respuesta.Rows(0)("RANFL_Id")
                Dim _vehiculo_id As Integer = Ayuda.Respuesta.Rows(0)("VEHIC_Id")
                Dim _asignaciones As String = Ayuda.Respuesta.Rows(0)("Asignaciones")

                Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
            _filter.ACFiltro = "NEUMA_Id=" & _interno.ToString()

            If _filter.ACFiltrar(m_listNeumaticos).Count > 0 Then
               setBlankDelanteros(sender, e)
               ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, String.Format("El Neumatico: {0}  seleccionado ya fue asignado, seleccione otro", _codigo))
            Else
               Dim _lado As String = "E"
               Dim _seccion As String = "D"
               Dim _ordenposicion As Short = e.Row
               Dim _intext As String = "D"
               If c1grdNDIzquierdo.Cols(e.Col).Name = "IZQ_EXT_NEUMA_CODIGO" And sender.Name = "c1grdNDIzquierdo" Then
                  CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_EXT_VNEUM_ID = _interno
                  CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_EXT_NEUMA_CODIGO = _codigo
                  _lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Izquierdo)
                  _intext = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Externo)
                  _orden = 1
               End If
               If c1grdNDIzquierdo.Cols(e.Col).Name = "IZQ_INT_NEUMA_CODIGO" And sender.Name = "c1grdNDIzquierdo" Then
                  CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_INT_VNEUM_ID = _interno
                  CType(bs_neuDelanteros.Current, ENeumaticos).IZQ_INT_NEUMA_CODIGO = _codigo
                  _lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Izquierdo)
                  _intext = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Interno)
                  _orden = 1
               End If
               If c1grdNDDerecho.Cols(e.Col).Name = "DER_INT_NEUMA_CODIGO" And sender.Name = "c1grdNDDerecho" Then
                  CType(bs_neuDelanteros.Current, ENeumaticos).DER_INT_VNEUM_ID = _interno
                  CType(bs_neuDelanteros.Current, ENeumaticos).DER_INT_NEUMA_CODIGO = _codigo
                  _lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Derecho)
                  _intext = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Interno)
                  _orden = 2
               End If
                    If c1grdNDDerecho.Cols(e.Col).Name = "DER_EXT_NEUMA_CODIGO" And sender.Name = "c1grdNDDerecho" Then
                        CType(bs_neuDelanteros.Current, ENeumaticos).DER_EXT_VNEUM_ID = _interno
                        CType(bs_neuDelanteros.Current, ENeumaticos).DER_EXT_NEUMA_CODIGO = _codigo
                        _lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Derecho)
                        _intext = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Externo)
                        _orden = 2
                    End If
                    'poner la funcion que buscar los asignados a otros vehiculos  creado frank 
                    '--------------------------------------------------------------------------------------------------------------------
                    '   BuscarNeumaticosAsignadosAOtros(_interno, _vehiculo_id, _ranfla_id)

                    'If (managerAdministracionNeumaticos.TRAN_Neuma_buscarRepetidos(_interno, _vehiculo_id, _ranfla_id)) Then
                    '    '  ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, String.Format("El Neumatico: {0} seleccionado ya fue asignado a otro Vehiculo/Ranfla, seleccione otro"), _asignaciones)
                    '    ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, String.Format("El Neumático: {0} seleccionado ya fue asignado a otro Vehículo/Ranfla, seleccione otro", _asignaciones))
                    '            setBlankDelanteros(sender, e)
                    'Else
                    m_listNeumaticos.Add(New ETRAN_Neumaticos(_interno, _codigo _
                              , Ayuda.Respuesta.Rows(0)("Modelo"), Ayuda.Respuesta.Rows(0)("Tipo Llanta") _
                              , Ayuda.Respuesta.Rows(0)("Marca"), Ayuda.Respuesta.Rows(0)("Fec. Compra") _
                              , IIf(Ayuda.Respuesta.Rows(0)("Kilometraje") Is System.DBNull.Value, 0, Ayuda.Respuesta.Rows(0)("Kilometraje")) _
                              , _seccion, _lado, _ordenposicion, _orden, _intext))
                    'End If
                    '--------------------------------------------------------------------------------------------------------------------

                    enumerarLista()
               bs_neumaticos.ResetBindings(False)
            End If
         Else
            setBlankDelanteros(sender, e)
         End If
         bs_neuDelanteros.ResetBindings(False)
      Catch ex As Exception
         ACControles.ACDialogos.MostrarMensajeError("Error: " & Me.Text, "Ha ocurrido un error en el proceso Cargar Programacion", ex)
      End Try
   End Sub
    'Funcion creada por frank esto es para que si hay un neumaticos asignaco a una ranfla o vehiculo que no deje agregarlo 

    'Private Function BuscarNeumaticosAsignadosAOtros(ByVal x_neuma_id As Integer, ByVal x_vehic_id As Integer, ByVal x_ranfla_id As Integer)
    '    If (managerAdministracionNeumaticos.TRAN_Neuma_buscarRepetidos(x_neuma_id, x_vehic_id, x_ranfla_id)) Then
    '        ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, String.Format("El Neumatico: seleccionado ya fue asignado, seleccione otro"))
    '    End If

    'End Function

    Private Sub c1grdPosteriores_CellButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
      Dim rcI As Rectangle = c1grdNDIzquierdo.GetCellRect(e.Row, e.Col)
      Dim rcD As Rectangle = c1grdNDDerecho.GetCellRect(e.Row, e.Col)
      rcI.Offset(0, rcI.Height)
      rcD.Offset(0, rcD.Height)
      Try

         Dim _neuma_id As Long = -1
         Dim _orden As Long = 1
         Dim _edit As Boolean = False
         If sender.Name = "c1grdNPIzquierdo" Then
            If Not IsNothing(c1grdNPIzquierdo.Rows(e.Row)(e.Col)) Then
               If Not c1grdNPIzquierdo.Rows(e.Row)(e.Col).ToString().Equals("") Then
                  _edit = True
                  If c1grdNPIzquierdo.Cols(e.Col).Name = "IZQ_EXT_NEUMA_CODIGO" Then
                     _neuma_id = CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_EXT_VNEUM_ID
                     If e.Row = 1 Then
                        _orden = 3
                     Else
                        _orden = (e.Row - 1) * 4 + 3
                     End If
                  ElseIf c1grdNPIzquierdo.Cols(e.Col).Name = "IZQ_INT_NEUMA_CODIGO" Then
                     _neuma_id = CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_INT_VNEUM_ID
                     If e.Row = 1 Then
                        _orden = 4
                     Else
                        _orden = (e.Row - 1) * 4 + 4
                     End If
                  End If
               End If
            End If
         ElseIf sender.Name = "c1grdNPDerecho" Then
            If Not IsNothing(c1grdNPDerecho.Rows(e.Row)(e.Col)) Then
               If Not c1grdNPDerecho.Rows(e.Row)(e.Col).ToString().Equals("") Then
                  _edit = True
                  If c1grdNPDerecho.Cols(e.Col).Name = "DER_INT_NEUMA_CODIGO" Then
                     _neuma_id = CType(bs_neuPosteriores.Current, ENeumaticos).DER_INT_VNEUM_ID
                     If e.Row = 1 Then
                        _orden = 5
                     Else
                        _orden = (e.Row - 1) * 4 + 5
                     End If
                  ElseIf c1grdNPDerecho.Cols(e.Col).Name = "DER_EXT_NEUMA_CODIGO" Then
                     _neuma_id = CType(bs_neuPosteriores.Current, ENeumaticos).DER_EXT_VNEUM_ID
                     If e.Row = 1 Then
                        _orden = 6
                     Else
                        _orden = (e.Row - 1) * 4 + 6
                     End If
                  End If
               End If
            End If
         End If
         If _edit Then
            Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
            _filter.ACFiltro = "NEUMA_Id=" & _neuma_id.ToString()
            If _filter.ACFiltrar(m_listNeumaticos).Count > 0 Then
               m_listNeumaticos.Remove(_filter.ACListaFiltrada(0))
            End If
            bs_neumaticos.ResetBindings(False)
         End If

         Dim _where As New Hashtable()
         If m_unidad = TipoUnidad.Vehiculos Then
            _where.Add("TIPOS_CodTipoLlanta", New ACFramework.ACWhere("'" & ACETransporte.Constantes.getTipoLlanta(ACETransporte.Constantes.TipoLlanta.DeTraccion) & "','" & ACETransporte.Constantes.getTipoLlanta(ACETransporte.Constantes.TipoLlanta.TodasPosiciones) & "'", ACFramework.ACWhere.TipoWhere._In))
         Else
            _where.Add("TIPOS_CodTipoLlanta", New ACFramework.ACWhere("'" & ACETransporte.Constantes.getTipoLlanta(ACETransporte.Constantes.TipoLlanta.Lineal) & "','" & ACETransporte.Constantes.getTipoLlanta(ACETransporte.Constantes.TipoLlanta.TodasPosiciones) & "'", ACFramework.ACWhere.TipoWhere._In))
         End If
         '_where.Add("NEUMA_Id", New ACFramework.ACWhere("Select NEUMA_Id From Transportes.TRAN_VehiculosNeumaticos Where VNEUM_Estado = 'A'", ACFramework.ACWhere.TipoWhere._NotIn))
         If m_listNeumaticos.Count > 0 Then
            Dim _sel As String = ""
            For Each item As ETRAN_Neumaticos In m_listNeumaticos
               If _sel.Length = 0 Then
                  _sel &= String.Format("{0}", item.NEUMA_Id)
               Else
                  _sel &= String.Format(",{0}", item.NEUMA_Id)
               End If
            Next
                _where.Add("Neu.NEUMA_Id", New ACFramework.ACWhere(_sel, ACFramework.ACWhere.TipoWhere._NotIn))
            End If
            managerTRAN_Neumaticos.CargarAyuda(_where)
            Dim x_campo As String = "0"
            Dim x_busqueda As String = " "
            Dim _campos() As ACCampos = {New ACCampos("@Neuma_Codigo", x_campo)}
            Dim _busqueda As New ACCampos("@Neuma_Codigo", x_busqueda)
            'Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Neumaticos", managerTRAN_Neumaticos.DTTRAN_Neumaticos, False)
            Dim Ayuda As New ACControlesC1.ACAyudaTextFlex("Buscar Entidad", "AYUDASS_TodosNeumaticos", _campos, _busqueda, False)
            'Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Neumatico", managerTRAN_Neumaticos.DTTRAN_Neumaticos, False)
            If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim _interno As Integer = Ayuda.Respuesta.Rows(0)("Interno")
                Dim _codigo As String = Ayuda.Respuesta.Rows(0)("Codigo").ToString()
                Dim _ranfla_id As Integer = Ayuda.Respuesta.Rows(0)("RANFL_Id")
                Dim _vehiculo_id As Integer = Ayuda.Respuesta.Rows(0)("VEHIC_Id")
                Dim _asignaciones As String = Ayuda.Respuesta.Rows(0)("Asignaciones")

                Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
            _filter.ACFiltro = "NEUMA_Id=" & _interno.ToString()

            If _filter.ACFiltrar(m_listNeumaticos).Count > 0 Then
               setBlankPosteriores(sender, e)
               ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, String.Format("El Neumatico: {0}  seleccionado ya fue asignado, seleccione otro", _codigo))
            Else
               Dim _lado As String = "D"
               Dim _seccion As String = "P"
               Dim _intext As String = "E"
               Dim _ordenposicion As Short = e.Row + m_listNeuDelanteros.Count
               If c1grdNPIzquierdo.Cols(e.Col).Name = "IZQ_EXT_NEUMA_CODIGO" And sender.Name = "c1grdNPIzquierdo" Then
                  CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_EXT_VNEUM_ID = _interno
                  CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_EXT_NEUMA_CODIGO = _codigo
                  _lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Izquierdo)
                  _intext = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Externo)
                  Dim m_or As Short = 3 : If m_unidad = TipoUnidad.Ranflas Then m_or = 1
                  If e.Row = 1 Then
                     _orden = m_or
                  Else
                     _orden = (e.Row - 1) * 4 + m_or
                  End If
               End If
               If c1grdNPIzquierdo.Cols(e.Col).Name = "IZQ_INT_NEUMA_CODIGO" And sender.Name = "c1grdNPIzquierdo" Then
                  CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_INT_VNEUM_ID = _interno
                  CType(bs_neuPosteriores.Current, ENeumaticos).IZQ_INT_NEUMA_CODIGO = _codigo
                  _lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Izquierdo)
                  _intext = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Interno)
                  Dim m_or As Short = 4 : If m_unidad = TipoUnidad.Ranflas Then m_or = 2
                  If e.Row = 1 Then
                     _orden = m_or
                  Else
                     _orden = (e.Row - 1) * 4 + m_or
                  End If
               End If
               If c1grdNPDerecho.Cols(e.Col).Name = "DER_INT_NEUMA_CODIGO" And sender.Name = "c1grdNPDerecho" Then
                  CType(bs_neuPosteriores.Current, ENeumaticos).DER_INT_VNEUM_ID = _interno
                  CType(bs_neuPosteriores.Current, ENeumaticos).DER_INT_NEUMA_CODIGO = _codigo
                  _lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Derecho)
                  _intext = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Interno)
                  Dim m_or As Short = 5 : If m_unidad = TipoUnidad.Ranflas Then m_or = 3
                  If e.Row = 1 Then
                     _orden = m_or
                  Else
                     _orden = (e.Row - 1) * 4 + m_or
                  End If
               End If
                    If c1grdNPDerecho.Cols(e.Col).Name = "DER_EXT_NEUMA_CODIGO" And sender.Name = "c1grdNPDerecho" Then
                        CType(bs_neuPosteriores.Current, ENeumaticos).DER_EXT_VNEUM_ID = _interno
                        CType(bs_neuPosteriores.Current, ENeumaticos).DER_EXT_NEUMA_CODIGO = _codigo
                        _lado = ACETransporte.Constantes.getLadoNeumatico(ACETransporte.Constantes.LadoNeumatico.Derecho)
                        _intext = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Externo)
                        Dim m_or As Short = 6 : If m_unidad = TipoUnidad.Ranflas Then m_or = 4
                        If e.Row = 1 Then
                            _orden = m_or
                        Else
                            _orden = (e.Row - 1) * 4 + m_or
                        End If
                    End If


                    'If (managerAdministracionNeumaticos.TRAN_Neuma_buscarRepetidos(_interno, _vehiculo_id, _ranfla_id)) Then
                    '    '  ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, String.Format("El Neumatico: {0} seleccionado ya fue asignado a otro Vehiculo/Ranfla, seleccione otro"), _asignaciones)
                    '    ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, String.Format("El Neumático: {0} seleccionado ya fue asignado a otro Vehículo/Ranfla, seleccione otro", _asignaciones))
                    '    setBlankPosteriores(sender, e)
                    'Else
                    m_listNeumaticos.Add(New ETRAN_Neumaticos(_interno, _codigo _
                     , Ayuda.Respuesta.Rows(0)("Modelo"), Ayuda.Respuesta.Rows(0)("Tipo Llanta") _
                     , Ayuda.Respuesta.Rows(0)("Marca"), Ayuda.Respuesta.Rows(0)("Fec. Compra") _
                     , IIf(Ayuda.Respuesta.Rows(0)("Kilometraje") Is System.DBNull.Value, 0, Ayuda.Respuesta.Rows(0)("Kilometraje")) _
                     , _seccion, _lado, _ordenposicion, _orden, _intext))
                    'End If


                    enumerarLista()
               bs_neumaticos.ResetBindings(False)
            End If
         Else
                setBlankPosteriores(sender, e)
            End If
         bs_neuPosteriores.ResetBindings(False)
      Catch ex As Exception
         ACControles.ACDialogos.MostrarMensajeError("Error: " & Me.Text, "Ha ocurrido un error en el proceso Cargar Programacion", ex)
      End Try
   End Sub

   Private Sub c1grdNRepuesto_CellButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
      Try
         Dim rcR As Rectangle = c1grdNRepuesto.GetCellRect(e.Row, e.Col)
         Dim _neuma_id As Long = -1
         Dim _orden As Long
         Dim _edit As Boolean = False

         '' Eliminar Registro si Existe
         If Not IsNothing(c1grdNRepuesto.Rows(e.Row)(e.Col)) Then
            If Not c1grdNRepuesto.Rows(e.Row)(e.Col).ToString().Equals("") Then
               _neuma_id = CType(bs_neuRepuesto.Current, ETRAN_Neumaticos).NEUMA_Id
               Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
               _filter.ACFiltro = "NEUMA_Id=" & _neuma_id.ToString()
               If _filter.ACFiltrar(m_listNeumaticos).Count > 0 Then
                  m_listNeumaticos.Remove(_filter.ACListaFiltrada(0))
               End If
               bs_neumaticos.ResetBindings(False)
            End If
         End If

         Dim _where As Hashtable
            If m_listNeumaticos.Count > 0 Then
                Dim _sel As String = ""
                For Each item As ETRAN_Neumaticos In m_listNeumaticos
                    If _sel.Length = 0 Then
                        _sel &= String.Format("{0}", item.NEUMA_Id)
                    Else
                        _sel &= String.Format(",{0}", item.NEUMA_Id)
                    End If
                Next
                _where = New Hashtable
                _where.Add("NEUMA_Id", New ACFramework.ACWhere(_sel, ACFramework.ACWhere.TipoWhere._NotIn))
            End If
            'busqueda de neumaticos en los repuestos agregado frank 
            Dim x_campo As String = "0"
            Dim x_busqueda As String = " "
            Dim _campos() As ACCampos = {New ACCampos("@Neuma_Codigo", x_campo)}
            Dim _busqueda As New ACCampos("@Neuma_Codigo", x_busqueda)
            'Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Neumaticos", managerTRAN_Neumaticos.DTTRAN_Neumaticos, False)
            Dim Ayuda As New ACControlesC1.ACAyudaTextFlex("Buscar Entidad", "AYUDASS_TodosNeumaticos", _campos, _busqueda, False)
            '===========================================================================================================
            '   managerTRAN_Neumaticos.CargarAyuda(_where)

            'Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Neumatico", managerTRAN_Neumaticos.DTTRAN_Neumaticos, False)
            '===========================================================================================================
            If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim _or As Integer = 0
            If m_unidad = TipoUnidad.Ranflas Then
               _or = 13
            Else
               _or = 11
            End If
            If e.Row = 1 Then
               _orden = _or
            Else
               _orden = _or + (e.Row - 1)
            End If

            Dim _interno As Integer = Ayuda.Respuesta.Rows(0)("Interno")
                Dim _codigo As String = Ayuda.Respuesta.Rows(0)("Codigo").ToString()
                Dim _ranfla_id As Integer = Ayuda.Respuesta.Rows(0)("RANFL_Id")
                Dim _vehiculo_id As Integer = Ayuda.Respuesta.Rows(0)("VEHIC_Id")
                Dim _asignaciones As String = Ayuda.Respuesta.Rows(0)("Asignaciones")
                Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
            _filter.ACFiltro = "NEUMA_Id=" & _interno.ToString()
            Dim _lado As String = "R"
            Dim _seccion As String = "R"
            Dim _intext As String = "R"
            Dim _ordenposicion As Short = 0

            CType(bs_neuRepuesto.Current, ETRAN_Neumaticos).NEUMA_Codigo = _codigo
            CType(bs_neuRepuesto.Current, ETRAN_Neumaticos).NEUMA_Id = _interno
            CType(bs_neuRepuesto.Current, ETRAN_Neumaticos).TIPO_Marca = Ayuda.Respuesta.Rows(0)("Marca")
            CType(bs_neuRepuesto.Current, ETRAN_Neumaticos).TIPO_Llanta = Ayuda.Respuesta.Rows(0)("Tipo Llanta")
            CType(bs_neuRepuesto.Current, ETRAN_Neumaticos).NEUMA_Modelo = Ayuda.Respuesta.Rows(0)("Modelo")

                bs_neuRepuesto.ResetBindings(False)

                m_listNeumaticos.Add(New ETRAN_Neumaticos(_interno, _codigo _
                                 , Ayuda.Respuesta.Rows(0)("Modelo"), Ayuda.Respuesta.Rows(0)("Tipo Llanta") _
                                 , Ayuda.Respuesta.Rows(0)("Marca"), Ayuda.Respuesta.Rows(0)("Fec. Compra") _
                                 , IIf(Ayuda.Respuesta.Rows(0)("Kilometraje") Is System.DBNull.Value, 0, Ayuda.Respuesta.Rows(0)("Kilometraje")) _
                                 , _seccion, _lado, _ordenposicion, _orden, _intext))

            enumerarLista()
            bs_neumaticos.ResetBindings(False)
         Else
            Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
                _filter.ACFiltro = "NEUMA_Id=" & _neuma_id.ToString()
                '_filter.ACFiltro = "" 'fALTA PONER UN fILTRO 
                If _filter.ACFiltrar(m_listNRepuesto).Count > 0 Then
               m_listNRepuesto.Remove(_filter.ACListaFiltrada(0))
            End If
            bs_neuRepuesto.ResetBindings(False)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.MostrarMensajeError("Error: " & Me.Text, "Ha ocurrido un error en el proceso Cargar Programacion", ex)
      End Try
   End Sub

   Private Function getCampo() As String
      Try
         Select Case m_unidad
            Case TipoUnidad.Vehiculos
               If (rbtnCodigo.Checked) Then
                  Return 0
               ElseIf rbtnPlaca.Checked Then
                  Return 1
               Else
                  Return 1
               End If
            Case TipoUnidad.Ranflas
               If (rbtnCodigo.Checked) Then
                  Return "RANFL_Codigo"
               ElseIf rbtnPlaca.Checked Then
                  Return "RANFL_Placa"
               Else
                  Return "RANFL_Codigo"
               End If
            Case Else
               Return "VEHIC_Codigo"
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function validar() As Boolean
      Try

      Catch ex As Exception
         Throw ex
      End Try
      Return True
   End Function

   Private Sub enumerarLista()
      Try
         Dim _ordenador As New ACFramework.ACOrdenador(Of ETRAN_Neumaticos)
         _ordenador.ACOrdenamiento = "VNEUM_Orden ASC, VNEUM_Seccion ASC, VNEUM_OrdenPosicion ASC"
         m_listNeumaticos.Sort(AddressOf _ordenador.ACCompare)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
#Region " Tool Bar "
   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acToolH.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         txtBusqueda.Focus()
         Me.KeyPreview = False
      Catch ex As Exception
         tabMantenimiento.SelectedTab = tabDatos
         Throw ex
      End Try
   End Sub

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acToolH.ACBtnModificar_Click
      Try
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         acToolH.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
         cargar()
         tabMantenimiento.SelectedTab = tabDatos

         Me.KeyPreview = True
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acToolH.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If validar() Then
            managerAdministracionNeumaticos.setListTRAN_Neumaticos(m_listNeumaticos)
            m_edocumentos = New EDocumentos()
            m_edocumentos.SUCUR_Id = GApp.Sucursal
            m_edocumentos.DOCMT_De = GApp.EUsuarioEntidad.ENTID_Id
            m_edocumentos.TIPOS_CodTipoDocumento = BConstantes.getDoc_OrdenMovimiento()
            m_edocumentos.DOCMT_Descripcion = "Movimiento Inicial de Asignación"
            m_edocumentos.DOCMT_Contenido = "Movimiento Inicial de Asignación"

            Select Case m_unidad
               Case TipoUnidad.Vehiculos
                  If managerAdministracionNeumaticos.GuardarAsignados(m_etran_vehiculos, m_edocumentos, GApp.FechaProceso.Year.ToString(), GApp.Usuario) Then
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Grabado satisfactoriamente")
                     tabMantenimiento.SelectedTab = tabBusqueda
                  End If
               Case TipoUnidad.Ranflas
                  If managerAdministracionNeumaticos.GuardarAsignados(m_etran_ranflas, m_edocumentos, GApp.FechaProceso.Year.ToString(), GApp.Usuario) Then
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Grabado satisfactoriamente")
                     tabMantenimiento.SelectedTab = tabBusqueda
                  End If
            End Select
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No se puede Grabar, revise los datos y vuelva a intentarlo", msg)
         End If
         Me.KeyPreview = False
      Catch ex As Exception
         acToolH.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede grabar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acToolH.ACBtnSalir_Click
      Me.Close()
   End Sub

#End Region

   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
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
                'Esta línea verifica si el valor de la posición X del evento del mouse (e.X) 
                '       es mayor que el número de filas fijas (Rows.Fixed) en el control c1grdBusqueda. 
                '      si es así, significa que el clic ocurrió en una fila que no es una fila fija
                '     (como una fila de encabezado) y se procede a ejecutar el código dentro del bloque If.
                setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                acToolH.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
                cargar()
            End If
        Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar el registro seleccionado", ex)
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

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            busqueda(txtBusqueda.Text)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
        End Try
    End Sub
    '---------------------------------------------------------------------------------------------------------------------------------------------
    'quitando los neumaticos de las Ranflas o Vehiculos 
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub c1grdSeleccionados_DoubleClick(sender As Object, e As EventArgs) Handles c1grdSeleccionados.DoubleClick
        'EVENTO DOBLE CLICK SOBRE EL ELEMENTO DE LA TABLA 

        Try
            ' bs_bMostrarAsignados_vehi_neumaticos = New BindingSource()
            ' bs_bMostrarAsignados_vehi_neumaticos.DataSource = managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos
            ' Dim cod As String = CType(bs_bMostrarAsignados_vehi_neumaticos.Current, ETRAN_VehiculosNeumaticos).NEUMA_Codigo
            If bs_neumaticos.Count > 0 Then
                If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar el Neumatico {0}{1}", Me.Text, CType(bs_neumaticos.Current, ETRAN_Neumaticos).NEUMA_Codigo) _
             , "¿Desea quitar el Neumatico 😀? " _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

                    Cargar_Neumatico_Salida()
                    '   ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Se quito ")
                Else
                End If
            Else

            End If


        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Quitar El neumatico del Vehiculo / Ranfla 😅", ex)
        End Try

    End Sub
    Private Sub Cargar_Neumatico_Salida() 'Creado frank 
        Try
            Select Case m_unidad
                Case TipoUnidad.Vehiculos 'En caso de que sea Vehiculo
                    If Not IsNothing(bs_btran_vehiculos) Then
                        If Not IsNothing(bs_neumaticos.Current) Then
                            '  Dim x_codigo_neumatico As Integer = CType(bs_btran_neumaticos.Current, ETRAN_Neumaticos).NEUMA_Id
                            Dim x_codigo_vehiculo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
                            Dim x_id_neumatico As Integer = CType(bs_neumaticos.Current, ETRAN_Neumaticos).NEUMA_Id
                            Buscar_Neumatico_Salida(x_codigo_vehiculo, x_id_neumatico) '
                        End If
                    End If
                Case TipoUnidad.Ranflas 'En caso de Que sea Ranfla ->Frank
                    If Not IsNothing(bs_btran_ranflas) Then
                        If Not IsNothing(bs_neumaticos.Current) Then
                            '  Dim x_codigo_neumatico As Integer = CType(bs_btran_neumaticos.Current, ETRAN_Neumaticos).NEUMA_Id
                            Dim x_codigo_vehiculo As Integer = CType(bs_btran_vehiculos.Current, ETRAN_Vehiculos).VEHIC_Id
                            Dim x_id_neumatico As Integer = CType(bs_neumaticos.Current, ETRAN_Neumaticos).NEUMA_Id
                            Buscar_Neumatico_Salida(x_codigo_vehiculo, x_id_neumatico) '
                        End If
                    End If
            End Select

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede Quitar este Neumatico", ex)
        End Try
    End Sub


    Private Sub Buscar_Neumatico_Salida(x_codigo_vehiculo, x_codigo_neumatico)
        Try
            'Estamos Inicializando la Lista de Cero  
            'Sobre las 4 o mas ruedas que apareces 
            m_listNeuDelanteros = New List(Of ENeumaticos)()
            m_listNeuPosteriores = New List(Of ENeumaticos)()
            m_listNeumaticos = New List(Of ETRAN_Neumaticos)
            m_listNRepuesto = New List(Of ETRAN_Neumaticos)
            bs_btran_neumaticos = New BindingSource()
            bs_btran_neuamticosRanflas = New BindingSource()



            Select Case m_unidad
                Case TipoUnidad.Vehiculos
                    '    m_etran_vehiculos = managerTRAN_Vehiculos.getTRAN_Vehiculos()
                    bs_btran_neumaticos.DataSource = managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos
                    If managerAdministracionNeumaticos.CargarTodosVehiculos(x_codigo_vehiculo) Then
                        'SI NO HAY NEUMATICOS ASIGNADOS AL VEHICULO 
                        CType(bs_btran_neumaticos.Current, ETRAN_VehiculosNeumaticos).VNEUM_FecMod = DateTime.Now
                        CType(bs_btran_neumaticos.Current, ETRAN_VehiculosNeumaticos).VNEUM_Estado = BConstantes.getEstado(BConstantes.Estados.Inactivo)
                        CType(bs_btran_neumaticos.Current, ETRAN_VehiculosNeumaticos).NEUMA_Id = x_codigo_neumatico

                        CType(bs_btran_neumaticos.Current, ETRAN_VehiculosNeumaticos).Instanciar(ACEInstancia.Eliminado)
                        managerTRAN_VehiculosNeumaticos.setTRAN_VehiculosNeumaticos(CType(bs_btran_neumaticos.Current, ETRAN_VehiculosNeumaticos))
                        If managerTRAN_VehiculosNeumaticos.Guardar(GApp.Usuario) Then
                            managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos.Remove(CType(bs_btran_neumaticos.Current, ETRAN_VehiculosNeumaticos))
                            managerTRAN_VehiculosNeumaticos.Cargar(ETRAN_Neumaticos.TipoInicializacion.Todos)
                        End If

                        setActive(True)
                        'En caso de que sean Vehiculos carga denuevo todos los nuemuaticos amarrados a ese Neumatico 
                        managerTRAN_Vehiculos.Cargar(x_codigo_vehiculo)
                        m_etran_vehiculos = managerTRAN_Vehiculos.getTRAN_Vehiculos()

                        bs_bMostrarAsignados_vehi_neumaticos = New BindingSource()
                        managerAdministracionNeumaticos.CargarTodosVehiculos(x_codigo_vehiculo) 'Cargamos lOS nUEVOS Neumaticos 
                        bs_bMostrarAsignados_vehi_neumaticos.DataSource = managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos
                    End If
                    'SI YA TIENE UN NEUMATICO ASIGNADO
                    ' managerTRAN_Vehiculos.Cargar(x_codigo) 'ESTA BUSCANDO EL VEHICULO POR EL ID DEL NEUMATICO NO ES NECESARIO 
                    'm_etran_vehiculos = managerTRAN_Vehiculos.getTRAN_Vehiculos()'E
                Case TipoUnidad.Ranflas
                    pnlFrontales.Visible = False
                    bs_btran_neuamticosRanflas.DataSource = managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos
                    If managerAdministracionNeumaticos.CargarTodosRanflas(x_codigo_vehiculo) Then
                        CType(bs_btran_neuamticosRanflas.Current, ETRAN_VehiculosNeumaticos).VNEUM_FecMod = DateTime.Now
                        CType(bs_btran_neuamticosRanflas.Current, ETRAN_VehiculosNeumaticos).VNEUM_Estado = BConstantes.getEstado(BConstantes.Estados.Inactivo)
                        CType(bs_btran_neuamticosRanflas.Current, ETRAN_VehiculosNeumaticos).Instanciar(ACEInstancia.Eliminado)
                        managerTRAN_VehiculosNeumaticos.setTRAN_VehiculosNeumaticos(CType(bs_btran_neuamticosRanflas.Current, ETRAN_VehiculosNeumaticos))
                        If managerTRAN_VehiculosNeumaticos.Guardar(GApp.Usuario) Then
                            managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos.Remove(CType(bs_btran_neuamticosRanflas.Current, ETRAN_VehiculosNeumaticos))
                            managerTRAN_VehiculosNeumaticos.Cargar(ETRAN_Neumaticos.TipoInicializacion.Todos)
                        End If
                        setActive(True)
                    End If
                    managerTRAN_Ranflas.Cargar(x_codigo_vehiculo)
                    m_etran_ranflas = managerTRAN_Ranflas.getTRAN_Ranflas()
                    'En caso de que sean ranflas carga denuevo todos los nuemuaticos amarrados a esa ranfla 
                    bs_bMostrarAsignados_vehi_neumaticos = New BindingSource()
                    managerAdministracionNeumaticos.CargarTodosRanflas(x_codigo_vehiculo) 'Cargamos lOS nUEVOS Neumaticos 
                    bs_bMostrarAsignados_vehi_neumaticos.DataSource = managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos
            End Select
            'lO PONEMOS AQUI PARA QUE BUSQUE DENUEVO LOS QUE ESTAN ASIGNADOS YA Y QUE QUITE LOS QUE YA ESTAN ASIGNADOS


            If managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos.Count > 0 Then
                For Each Item As ETRAN_VehiculosNeumaticos In managerAdministracionNeumaticos.ListTRAN_VehiculosNeumaticos
                    m_listNeumaticos.Add(New ETRAN_Neumaticos(Item.NEUMA_Id, Item.NEUMA_Codigo, Item.NEUMA_Modelo _
                                                        , Item.TIPO_Llanta, Item.TIPO_Marca, Item.NEUMA_FecCompra, Item.NEUMA_KmVidaUtil _
                                                        , Item.VNEUM_Seccion, Item.VNEUM_Lado, Item.VNEUM_OrdenPosicion, Item.VNEUM_Orden _
                                                        , Item.VNEUM_InternoExterno, False))
                Next
                cargarInterfaz()
                '  setActive(False) 'Esta en false 
                setActive(True)

                c1grdNDDerecho.AutoSizeCols()
                c1grdNDIzquierdo.AutoSizeCols()
                c1grdNPDerecho.AutoSizeCols()
                c1grdNPIzquierdo.AutoSizeCols()

                acToolH.ACBtnGrabarVisible = True 'Este boton esta en Veremeos 

            Else
                setActive(True)
            End If


            SetData_NeumaticosRestante()
            'setData() 'Enviando Datos de los Neumaticos a Cada Columna 
            tabMantenimiento.SelectedTab = tabDatos
        Catch ex As Exception
            acToolH.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            Throw ex
        End Try
    End Sub

    Private Sub SetData_NeumaticosRestante() 'fuNCION cREADO fRANK 
        'ESTO SE EJECUTA CADA VEZ QUE TU SELECIONAS ESTO MUESTRA EL CAMBIO QUE SE HIZO AL QUITAR DE LA LISTA EN LA TABLA DEL LADO DERECHO 

        Try
            'aca se envia datos a las tablas segun los datos de 
            'de los Binding 
            bs_neuDelanteros = New BindingSource()
            bs_neuDelanteros.DataSource = m_listNeuDelanteros
            c1grdNDIzquierdo.DataSource = bs_neuDelanteros
            c1grdNDDerecho.DataSource = bs_neuDelanteros
            bnavNDelanteros.BindingSource = bs_neuDelanteros

            bs_neuPosteriores = New BindingSource()
            bs_neuPosteriores.DataSource = m_listNeuPosteriores
            c1grdNPIzquierdo.DataSource = bs_neuPosteriores
            c1grdNPDerecho.DataSource = bs_neuPosteriores
            bnavNPosteriores.BindingSource = bs_neuPosteriores

            bs_neumaticos = New BindingSource()
            bs_seleccionados = New BindingSource()
            bs_neumaticos.DataSource = m_listNeumaticos
            '  bs_neumaticos.DataSource = m_etran_vehiculosNeumaticos 'Creado
            ' c1grdSeleccionados.DataSource = bs_neumaticos

            If bs_bMostrarAsignados_vehi_neumaticos Is Nothing Then
                ' bs_bMostrarAsignados_vehi_neumaticos = New BindingSource()
                c1grdSeleccionados.DataSource = m_listNeumaticos
            Else
                c1grdSeleccionados.DataSource = bs_bMostrarAsignados_vehi_neumaticos
            End If
            'c1grdSeleccionados.DataSource = bs_bMostrarAsignados_vehi_neumaticos 'este binding esta mas arriba hay se llama 
            'bnavNeumaticos.BindingSource = bs_neumaticos

            bs_neuRepuesto = New BindingSource
            bs_neuRepuesto.DataSource = m_listNRepuesto
            c1grdNRepuesto.DataSource = bs_neuRepuesto
            bnavRepuesto.BindingSource = bs_neuRepuesto
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class