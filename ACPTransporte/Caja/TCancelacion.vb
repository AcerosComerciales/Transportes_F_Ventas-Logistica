Imports ACBVentas
Imports ACEVentas
Imports ACBTransporte
Imports ACETransporte

Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid
Imports System.ComponentModel

Imports Crownwood.DotNetMagic.Docking
Imports Crownwood.DotNetMagic.Controls
Imports System.Xml

Public Class TCancelacion
#Region " Variables "
    Private managerVENT_PVentDocumento As BVENT_PVentDocumento
    Private managerDTESO_Recibos As ETESO_Recibos
    Private managerGenerarCancelacion As BGCancelacion
   Private managerTESO_DocsPagos As BTESO_DocsPagos
   Private managerEntidades As BEntidades
   Private m_badministracioncaja As BAdministracionCaja
   Private bs_entidades As BindingSource : Private bs_facturas As BindingSource : Private bs_docsapagar As BindingSource
   Private bs_moneda As BindingSource : Private bs_docspago As BindingSource
   Private bs_tipopago As BindingSource
   Private bs_fletes As BindingSource
    Private bs_pagos As BindingSource
    Private bs_tipopagoxfraccionamiento As BindingSource
    Private bs_SaldosAFavor As BindingSource
    Private managerAdministracionCajas As BAdminCaja

    Private m_dockingManager As DockingManager

   Private m_tipopago As ETipos.TipoDePago

    Private m_bandera_detraccion_Aviso As Boolean = False  
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      Try
         Inicializacion()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Public Sub New(ByVal x_docve_codigo As String)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      Try
         Inicializacion()
            m_bandera_detraccion_Aviso = False 
         Me.MaximizeBox = False
         cargar(x_docve_codigo)
         actool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolSalir
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

    Private Sub Inicializacion()
        Try
            'InitDocket()

            tabMantenimiento.HideTabsMode = HideTabsModes.HideAlways
            tabMantenimiento.SelectedTab = tabBusqueda
            'DESABILITAMOS EL BOTON DE CHECK DEL FRACCIONAMIENTO DEL DEPOSITO
            ' chkFraccionado.Enabled = False
            managerAdministracionCajas = New BAdminCaja(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo)
            m_badministracioncaja = New BAdministracionCaja(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta)
            managerVENT_PVentDocumento = New BVENT_PVentDocumento()
            managerEntidades = New BEntidades()
            managerGenerarCancelacion = New BGCancelacion(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
            managerTESO_DocsPagos = New BTESO_DocsPagos(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)

            formatearGrilla()
            CargarCombos()
            CargarPermisos()
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)

            cmbMoneda.Enabled = False
            'cmbFracionarPago.Enabled = False
            'chkFraccionado.Enabled = False

            Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACMoney_16x16.GetHicon)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function CargarPermisos()
        Dim _validacion As ACSeguridad.ACValidarUsuario 'Creacion de objeto valicaico 

        _validacion = New ACSeguridad.ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACSeguridad.ACValidarUsuario.Operacion.ValidarVariosProcesos)

        For Each item As ACSeguridad.EProcesos In _validacion.ListProcesos

            Select Case item.PROC_Codigo
                Case Procesos.getProceso(Procesos.TipoProcesos.PermitirFraccionarPago)
                    chkFraccionado.Enabled = True
                    cmbFracionarPago.Enabled = True
            End Select
        Next

    End Function

    Private Sub InitDocket()
      allowContextMenu = True
      customContextMenu = True
      captionBars = True
      closeButtons = False
      ignoreClose = 0
      '' Docking
      m_dockingManager = New DockingManager(tscBase.ContentPanel, VisualStyle.Office2007Black)
      AddHandler m_dockingManager.ContextMenu, AddressOf OnContextMenu
      AddHandler m_dockingManager.ContentShown, AddressOf OnContentShown
      AddHandler m_dockingManager.ContentHidden, AddressOf OnContentHidden
      AddHandler m_dockingManager.ContentHiding, AddressOf OnContentHiding
      AddHandler m_dockingManager.ContentAutoHideOpening, AddressOf OnContentAutoHideOpening
      AddHandler m_dockingManager.ContentAutoHideClosed, AddressOf OnContentAutoHideClosed

      AddHandler m_dockingManager.LayoutChanged, AddressOf OnLayoutChanged

      '// Ensure correct inner and outer values for correct window positioning
      m_dockingManager.InnerControl = SplitContainer3

      '// Setup custom config handling
      AddHandler m_dockingManager.SaveCustomConfig, AddressOf OnSaveConfig
      AddHandler m_dockingManager.LoadCustomConfig, AddressOf OnLoadConfig

      menuCreate3AutoHidden_Click(Me, EventArgs.Empty)
      '' End Docking
      pnlDocking.BackColor = Color.White
   End Sub
#End Region

#Region " Metodos "

#Region " Docked "

   Private allowContextMenu As Boolean
   Private customContextMenu As Boolean
   Private captionBars As Boolean
   Private closeButtons As Boolean
   Private ignoreClose As Integer
   Private count As Integer = 0

#Region " Eventos "
   Private Sub OnContextMenu(ByVal cc As ContentCollection, ByVal cms As ContextMenuStrip, ByVal cea As CancelEventArgs)
      ' Show the PopupMenu be cancelled and not shown?
      If Not allowContextMenu Then
         cea.Cancel = True
      Else
         If customContextMenu Then
            ' Remove the Show All and Hide All commands
            cms.Items.RemoveAt(cms.Items.Count - 1)
            cms.Items.RemoveAt(cms.Items.Count - 1)

            ' Add a custom entry at the start
            cms.Items.Insert(0, New ToolStripMenuItem("Custom 1"))
            cms.Items.Insert(1, New ToolStripSeparator())

            ' Add a couple of custom commands at the end
            cms.Items.Add(New ToolStripMenuItem("Custom 2"))
            cms.Items.Add(New ToolStripMenuItem("Custom 3"))
         End If
      End If
   End Sub

   Protected Sub OnContentShown(ByVal c As Content, ByVal cea As EventArgs)
      Console.WriteLine("OnContentShown {0}", c.Title)
   End Sub

   Protected Sub OnContentHidden(ByVal c As Content, ByVal cea As EventArgs)
      Console.WriteLine("OnContentHidden {0}", c.Title)
   End Sub

   Protected Sub OnContentHiding(ByVal c As Content, ByVal cea As CancelEventArgs)
      Console.WriteLine("OnContentHiding {0}", c.Title)

      Select Case ignoreClose
         Case 0
            ' Allow all, do nothing
            Exit Select
         Case 1
            ' Ignore TreeControl
            cea.Cancel = TypeOf c.Control Is TreeControl
            Exit Select
         Case 2
            ' Ignore TextBox
            cea.Cancel = TypeOf c.Control Is TextBox
            Exit Select
         Case 3
            ' Ignore ExampleForm
            'cea.Cancel = TypeOf c.Control Is ExampleForm
            Exit Select
         Case 4
            ' Ignore all, cancel
            cea.Cancel = True
            Exit Select
      End Select
   End Sub

   Protected Sub OnContentAutoHideOpening(ByVal c As Content, ByVal cea As EventArgs)
      Console.WriteLine("OnContentAutoHideOpening {0}", c.Title)
   End Sub

   Protected Sub OnContentAutoHideClosed(ByVal c As Content, ByVal cea As EventArgs)
      Console.WriteLine("OnContentAutoHideClosed {0}", c.Title)
   End Sub

   Protected Sub OnLayoutChanged(ByVal sender As Object, ByVal e As EventArgs)
      Console.WriteLine("Docking layout changed")
   End Sub

   Private Sub OnSaveConfig(ByVal xmlOut As XmlTextWriter)
      ' Add an extra node into the config to store some useless information
      xmlOut.WriteStartElement("MyCustomElement")
      xmlOut.WriteAttributeString("UselessData1", "Hello")
      xmlOut.WriteAttributeString("UselessData2", "World!")
      xmlOut.WriteEndElement()
   End Sub

   Private Sub OnLoadConfig(ByVal xmlIn As XmlTextReader)
      ' We are expecting our custom element to be the current one
      If xmlIn.Name = "MyCustomElement" Then
         ' Read in both the expected attributes
         Dim attr1 As String = xmlIn.GetAttribute(0)
         Dim attr2 As String = xmlIn.GetAttribute(1)

         ' Must move past our element
         xmlIn.Read()
      End If
   End Sub
#End Region

   Private Sub InitializeContent(ByVal c As Content)
      c.CaptionBar = captionBars
      c.CloseButton = closeButtons
      ' Definir el tamaño del panel que se muestra al pasar el mouse
      c.AutoHideSize = New Size(230, c.AutoHideSize.Height)
   End Sub

   Private Function CreateTextBoxContent() As Content
      ' Create the TextBox for use in the new docking window
      Dim tb As New TextBox()
      tb.Text = "A simple TextBox instance."
      tb.BorderStyle = BorderStyle.None
      tb.Multiline = True

      ' Create a new docking Content instance with our new TextBox
      Return m_dockingManager.Contents.Add(tb, "TextBox " & count, imageList, System.Math.Max(System.Threading.Interlocked.Increment(count), count - 1) Mod 6)
   End Function

   Private Function CreatePanelContent() As Content
      ' Create a new docking Content instance with our new TextBox
      Dim c As Content = m_dockingManager.Contents.Add(pnlDocking, "Datos Adicionales", ImageList, 0)
      pnlDocking.Dock = DockStyle.Fill
      c.FloatingSize = New Size(220, c.FloatingSize.Height)
      Return c
   End Function

#Region " AutoHidden "
   Private Sub menuCreate3AutoHidden_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      ' Create three different content instances
      'Dim cB As Content = CreateTextBoxContent()
      Dim cA As Content = CreatePanelContent()
      cA.DisplaySize = New Size(220, cA.DisplaySize.Height)
      cA.FloatingSize = New Size(220, cA.DisplaySize.Height)
      ' Setup initial state to match menu selections
      InitializeContent(cA)
      'InitializeContent(cB)

      ' Prevent flicker where the contents are added and display and then a fraction of a 
      ' second later they become auto hidden. By suspending and then resuming the layout this
      ' small flicker can be avoided.
      Me.SuspendLayout()

      ' Request a new Docking window be created for the first content on the right edge
      Dim wc As WindowContent = TryCast(m_dockingManager.AddContentWithState(cA, Crownwood.DotNetMagic.Docking.State.DockRight), WindowContent)

      ' Add two other content into the same WindowContent
      m_dockingManager.AddContentToWindowContent(cA, wc)
      '' Mostrar el control fijando en el lado designado
      m_dockingManager.ShowContent(cA)

      ' Ocultar los contenidos, dockeandolos a un lado del control
      'm_dockingManager.ToggleContentAutoHide(cA)

      Me.ResumeLayout()
   End Sub

#End Region
#End Region

#Region " Utilitarios "

   Private Sub setInstancia(ByVal x_opcion As ACFramework.ACUtilitarios.ACSetInstancia)
      Try
         Select Case x_opcion
            Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
               tabMantenimiento.SelectedTab = tabDatos
               actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               actool.ACBtnModificarVisible = False
               actsbtnCancelar.Visible = False
               SplitContainer2.Panel2Collapsed = True
               cmbPago.SelectedIndex = 0
               AcFecha.ACDtpFecha_A.Value = Date.Now
               AcFecha.ACDtpFecha_De.Value = Date.Now
               dtpFechaEmision.Value = Date.Now
                    m_bandera_detraccion_Aviso = False
            Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar

            Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
               tabMantenimiento.SelectedTab = tabDatos
               actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               actool.ACBtnModificarVisible = False
               actsbtnCancelar.Visible = False
            Case ACFramework.ACUtilitarios.ACSetInstancia.Previsualizar

               actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               actool.ACBtnGrabarVisible = False
                      m_bandera_detraccion_Aviso = False
            Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer
               tabMantenimiento.SelectedTab = tabBusqueda

               actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               actsbtnCancelar.Visible = True 
                    txtCancelacionDetraccion.Text = "" 
            Case Else

         End Select
         actool.ACBtnModificarVisible = False
         actool.ACBtnReporteVisible = False
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 9, 1, 2)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "ENTID_Codigo", "ENTID_Codigo", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Razon Social", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "E-Mail", "ENTID_EMail", "ENTID_EMail", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Dirección", "ENTID_Direccion", "ENTID_Direccion", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Telefono 1", "ENTID_Telefono1", "ENTID_Telefono1", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Telefono 2", "ENTID_Telefono2", "ENTID_Telefono2", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fax", "ENTID_Fax", "ENTID_Fax", 150, True, False, "System.String", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1

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
         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDocsPendientes, 1, 1, 11, 1, 2)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "Codigo", "DOCVE_Codigo", "DOCVE_Codigo", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "Fecha", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "Total Pagar", "DOCVE_TotalPagar", "DOCVE_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "Total Pagado", "DOCVE_TotalPagado", "DOCVE_TotalPagado", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "Pendiente", "SaldoPendiente", "SaldoPendiente", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "Detraccion", "DOCVE_ImporteDetraccion", "DOCVE_ImporteDetraccion", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "Cotizador", "Usuario", "Usuario", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPendientes, index, "X", "Seleccionar", "Seleccionar", 150, True, False, "System.Boolean") : index += 1

         c1grdDocsPendientes.AllowEditing = False
         c1grdDocsPendientes.AutoResize = True
         c1grdDocsPendientes.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDocsPendientes.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDocsPendientes.Styles.Highlight.BackColor = Color.Gray
         c1grdDocsPendientes.SelectionMode = SelectionModeEnum.Row
         'c1grdDocsPendientes.VisualStyle = VisualStyle.Office2007Blue
         c1grdDocsPendientes.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdDocsPendientes.DrawMode = DrawModeEnum.OwnerDraw

         Dim s As C1.Win.C1FlexGrid.CellStyle = c1grdDocsPendientes.Styles.Add("Resaltar")
         s.BackColor = Color.Green
         s.ForeColor = Color.White
         Dim l As C1.Win.C1FlexGrid.CellStyle = c1grdDocsPendientes.Styles.Add("Pendiente")
         l.BackColor = Color.Blue
         l.ForeColor = Color.White
         l.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)
         Dim j As C1.Win.C1FlexGrid.CellStyle = c1grdDocsPendientes.Styles.Add("Pagar")
         j.BackColor = Color.DarkBlue
         j.ForeColor = Color.White
         j.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)
         Dim k As C1.Win.C1FlexGrid.CellStyle = c1grdDocsPendientes.Styles.Add("Pagado")
         k.BackColor = Color.Red
         k.ForeColor = Color.White
         k.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDocsPagar, 1, 1, 7, 1, 2)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPagar, index, "Fecha", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPagar, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPagar, index, "Importe Documento", "DOCVE_TotalPagar", "DOCVE_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPagar, index, "Importe Cobrar", "ImportePagar", "DOCVE_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPagar, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPagar, index, "Seleccionado", "Seleccionar", "Seleccionar", 150, False, False, "System.Boolean") : index += 1

         c1grdDocsPagar.AllowEditing = False
         c1grdDocsPagar.AutoResize = True
         c1grdDocsPagar.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDocsPagar.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDocsPagar.Styles.Highlight.BackColor = Color.Gray
         c1grdDocsPagar.SelectionMode = SelectionModeEnum.Row
         'c1grdDocsPagar.VisualStyle = VisualStyle.Office2007Blue
         c1grdDocsPagar.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdDocsPagar.DrawMode = DrawModeEnum.OwnerDraw

         Dim jj As C1.Win.C1FlexGrid.CellStyle = c1grdDocsPagar.Styles.Add("Pagar")
         jj.BackColor = Color.DarkBlue
         jj.ForeColor = Color.White
         jj.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDocsPago, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Tipo Doc.", "TIPOS_TipoDocumento", "TIPOS_TipoDocumento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Importe", "DPAGO_Importe", "DPAGO_Importe", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Usado", "ImporteUsado", "ImporteUsado", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Numero", "DPAGO_Numero", "DPAGO_Numero", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Fecha Giro/Deposito", "DPAGO_Fecha", "DPAGO_Fecha", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Fecha Cobro/Venc.", "DPAGO_FechaVenc", "DPAGO_FechaVenc", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Banco", "BANCO_Descripcion", "BANCO_Descripcion", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Nro. Cuenta", "CUENT_Numero", "CUENT_Numero", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDocsPago, index, "Tipo Cuenta", "TIPOS_TipoCuenta", "TIPOS_TipoCuenta", 150, True, False, "System.String") : index += 1

         c1grdDocsPago.AllowEditing = True
         c1grdDocsPago.AutoResize = True
         c1grdDocsPago.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDocsPago.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDocsPago.Styles.Highlight.BackColor = Color.Gray
         c1grdDocsPago.SelectionMode = SelectionModeEnum.Row
         c1grdDocsPago.VisualStyle = VisualStyle.Office2007Blue
         c1grdDocsPago.AllowSorting = AllowSortingEnum.SingleColumn
         'c1grdDocsPago.DrawMode = DrawModeEnum.OwnerDraw

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdFletes, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Viaje", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Código", "FLETE_Id", "FLETE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Viaje", "VIAJE_Descripcion", "VIAJE_Descripcion", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Descripción", "FLETE_Glosa", "FLETE_Glosa", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Peso T.M.", "FLETE_PesoEnTM", "FLETE_PesoEnTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Monto x TM", "FLETE_MontoPorTM", "FLETE_MontoPorTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "I.G.V.", "FLETE_ImporteIgv", "FLETE_ImporteIgv", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Total Flete", "FLETE_TotIngreso", "FLETE_TotIngreso", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Salida", "FLETE_FecSalida", "FLETE_FecSalida", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Llegada", "FLETE_FecLlegada", "FLETE_FecLlegada", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1

         c1grdFletes.AllowEditing = False
         c1grdFletes.AutoResize = True
         c1grdFletes.Cols(0).Width = 18
         c1grdFletes.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdFletes.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdFletes.Styles.Highlight.BackColor = Color.Gray
         c1grdFletes.SelectionMode = SelectionModeEnum.Row
         c1grdFletes.AllowResizing = AllowResizingEnum.Rows

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdPagos, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Cod. Caja", "CAJA_Id", "CAJA_Id", 80, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Documento", "Documento", "Documento", 80, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Orden Doc.", "CAJA_OrdenDocumento", "CAJA_OrdenDocumento", 90, True, False, "System.Integer") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Fecha", "CAJA_Fecha", "CAJA_Fecha", 350, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Fecha Proceso", "CAJA_FechaPago", "CAJA_FechaPago", 350, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Importe", "CAJA_Importe", "CAJA_Importe", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Transacción", "TIPOS_Transaccion", "TIPOS_Transaccion", 80, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 80, True, False, "System.String") : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Glosa", "Glosa", "Glosa", 80, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Fecha", "DPAGO_Fecha", "DPAGO_Fecha", 80, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1

         c1grdPagos.AllowEditing = False
         c1grdPagos.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdPagos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdPagos.Styles.Highlight.BackColor = Color.Gray
         c1grdPagos.SelectionMode = SelectionModeEnum.Row
         c1grdPagos.AutoResize = True
         c1grdPagos.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         Dim t2 As C1.Win.C1FlexGrid.CellStyle = c1grdPagos.Styles.Add("Facturado")
         t2.BackColor = Color.LightGreen
         t2.ForeColor = Color.DarkBlue
         t2.Font = New Font(c1grdPagos.Font, FontStyle.Regular)

         Dim u2 As C1.Win.C1FlexGrid.CellStyle = c1grdPagos.Styles.Add("Facturar")
         u2.BackColor = Color.Green
         u2.ForeColor = Color.White
         u2.Font = New Font(c1grdPagos.Font, FontStyle.Regular)

         Dim j2 As C1.Win.C1FlexGrid.CellStyle = c1grdPagos.Styles.Add("Pagar")
         j2.BackColor = Color.DarkBlue
         j2.ForeColor = Color.White
         j2.Font = New Font(c1grdPagos.Font, FontStyle.Bold)

         Dim d3 As C1.Win.C1FlexGrid.CellStyle = c1grdPagos.Styles.Add("Anulado")
         d3.BackColor = Color.Red
         d3.ForeColor = Color.White
         d3.Font = New Font(c1grdPagos.Font, FontStyle.Bold)
         c1grdPagos.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub CargarCombos()
      Try '' Documento de Venta 
         Dim listDoc As New List(Of ETipos)
         Dim listDocBus As New List(Of ETipos)
         For Each Item As ETipos In Colecciones.TiposDocComprobante()
            listDoc.Add(Item.Clone)
            listDocBus.Add(Item.Clone)
         Next

         bs_moneda = New BindingSource() : bs_moneda.DataSource = Colecciones.Tipos(ETipos.MyTipos.TipoMoneda)
         ACFramework.ACUtilitarios.ACCargaCombo(cmbMoneda, bs_moneda, "TIPOS_DescCorta", "TIPOS_Codigo")
         AddHandler bs_moneda.CurrentChanged, AddressOf bs_moneda_CurrentChanged

         bs_tipopago = New BindingSource
            bs_tipopago.DataSource = Colecciones.TiposDePago()

            bs_tipopagoxfraccionamiento = New BindingSource
            bs_tipopagoxfraccionamiento.DataSource = Colecciones.TipoPagoXFraccionamiento()
            ACFramework.ACUtilitarios.ACCargaCombo(cmbPago, bs_tipopago, "TIPOS_Descripcion", "TIPOS_Codigo")
            'Cargar el Combobox para mostrar tipos de recibos  
            ACFramework.ACUtilitarios.ACCargaCombo(cmbFracionarPago, bs_tipopagoxfraccionamiento, "TIPOS_Descripcion", "TIPOS_Codigo")
            cmbFracionarPago.Font = New Font(cmbFracionarPago.Font.FontFamily, 7, cmbFracionarPago.Font.Style)
            cmbFracionarPago.Visible = False 'Inicializamos el comobobox de pagos para saldos a favor ya que no en todas las cancelacioen sse usan 
            cmbFracionarPago.DropDownStyle = ComboBoxStyle.DropDownList

            AddHandler bs_tipopago.CurrentChanged, AddressOf bs_tipopago_CurrentChanged
         bs_tipopago_CurrentChanged(Nothing, Nothing)

         Dim managerGenerarDocsVenta As New BGenerarDocsVenta(GApp.PuntoVenta, GApp.Periodo, GApp.Zona, GApp.Sucursal)
         If managerGenerarDocsVenta.GetSeries(GApp.Aplicacion, GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Caja)) Then
            txtSerie.Text = managerGenerarDocsVenta.ListVENT_PVentDocumento(0).PVDOCU_Serie
         End If

         'ACFramework.ACUtilitarios.ACCargaCombo(tscmbDocsPago.ComboBox, Colecciones.Tipos(ETipos.MyTipos.TipoDocumentoPago), "TIPOS_Descripcion", "TIPOS_Codigo")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

#Region " Cargar Datos "
   Private Sub cargar(ByVal x_entid_codigo As String)
      Try
         If managerGenerarCancelacion.CargarFacturasXCancelar(x_entid_codigo, GApp.PuntoVenta) Then
            '' Setear Valores
            txtDocumento.Text = CType(bs_entidades.Current, EEntidades).ENTID_NroDocumento
            txtRazonSoc.Text = CType(bs_entidades.Current, EEntidades).ENTID_RazonSocial
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
            '' Cargar
            bs_facturas = New BindingSource()
            bs_facturas.DataSource = managerGenerarCancelacion.ListVENT_DocsVenta
            c1grdDocsPendientes.DataSource = bs_facturas
            bnavDocsPendientes.BindingSource = bs_facturas
            AddHandler bs_facturas.CurrentChanged, AddressOf bs_docsventa_CurrentChanged : bs_docsventa_CurrentChanged(Nothing, Nothing)
            ''
            Dim _total As Decimal = 0
            For Each item As EVENT_DocsVenta In managerGenerarCancelacion.ListVENT_DocsVenta
               _total += item.Saldo
            Next
            tstxtDeudaTotal.Text = _total.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
         Else
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar, posiblemente no tenga documentos pendientes")
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

    Private Sub cargarDatos(ByVal x_opcion As Boolean) 'al principio es para cargar y biscar 
        Try
            RemoveHandler txtBusqueda.KeyDown, AddressOf txtBusqueda_KeyDown
            bs_entidades = New BindingSource()
            If x_opcion Then
                bs_entidades.DataSource = managerGenerarCancelacion.ListEntidades
            Else
                bs_entidades.DataSource = managerGenerarCancelacion.ListEntidades
                'managerVENT_DocsVenta.ListVENT_DocsVenta = New List(Of EVENT_DocsVenta)
                'bs_documentos.DataSource = managerVENT_DocsVenta.ListVENT_DocsVenta
            End If
            c1grdBusqueda.DataSource = bs_entidades
            bnavBusqueda.BindingSource = bs_entidades
            AddHandler txtBusqueda.KeyDown, AddressOf txtBusqueda_KeyDown
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

   Private Function busquedaCliente(ByVal x_cadena As String) As Boolean
      Try
         Dim m_return As Boolean
         If managerGenerarCancelacion.getPendiente(x_cadena, "ENTID_Nombres", chkTodos.Checked) Then
            cargarDatos(True)
         Else
            cargarDatos(False)
         End If
         Return m_return
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

#End Region

   Private Sub CalcularSeleccion()
      Try
         Dim _total As Decimal = 0
         For Each item As EVENT_DocsVenta In managerGenerarCancelacion.ListVENT_PagosFacturas
            _total += item.ImportePagar
         Next
         tstxnTotalPagar.Text = _total.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_docsventa_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_facturas.Current) Then
            actxnImporte.Text = CType(bs_facturas.Current, EVENT_DocsVenta).Saldo
            actxnImporte.Formatear()
            cmbMoneda.SelectedValue = CType(bs_facturas.Current, EVENT_DocsVenta).TIPOS_CodTipoMoneda
            bs_moneda_CurrentChanged(Nothing, Nothing)
              'pasar detraccion ==> 
                txtCancelacionDetraccion.Text = CType(bs_facturas.Current,EVENT_DocsVenta).DOCVE_ImporteDetraccion
            tbcViajePagos.SelectedTab = tpgFletes

            Dim _codigo As String = CType(bs_facturas.Current, EVENT_DocsVenta).DOCVE_Codigo

            If Not m_badministracioncaja.FletesXFacturas(_codigo) Then
               m_badministracioncaja.ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            End If
            bs_fletes = New BindingSource
            bs_fletes.DataSource = m_badministracioncaja.ListTRAN_Fletes
            c1grdFletes.DataSource = bs_fletes
            bnavFletes.BindingSource = bs_fletes
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 5, "Total")
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 8, "Total")

            If Not m_badministracioncaja.CuadreCajaPagos(False, _codigo) Then
               m_badministracioncaja.ListTESO_CajaPagos = New List(Of ETESO_Caja)
            End If
            bs_pagos = New BindingSource
            bs_pagos.DataSource = m_badministracioncaja.ListTESO_CajaPagos
            c1grdPagos.DataSource = bs_pagos
            bnavPagos.BindingSource = bs_pagos
            c1grdPagos.Subtotal(AggregateEnum.Sum, 0, -1, 6, "Total")

         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub bs_moneda_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_moneda.Current) Then
            Dim importe As Double = actxnImporte.Text
            Dim tcambio As Double = actxnTipoCambio.Text
            If CType(bs_moneda.Current, ETipos).TIPOS_Codigo.Equals(ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Dolares)) Then
               actxnPago.Text = importe * tcambio
               actxnTotal.Text = importe * tcambio
            Else
               actxnPago.Text = importe
               actxnTotal.Text = importe
            End If
            actxnPago.Formatear()
            actxnTotal.Formatear()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso de cambio de moneda", ex)
      End Try
   End Sub

   Private Sub bs_tipopago_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         pnlDocking.Enabled = True
         SplitContainer2.Panel2Collapsed = False
         If Not IsNothing(bs_tipopago.Current) Then
            Select Case CType(bs_tipopago.Current, ETipos).TIPOS_Codigo
               Case ETipos.getTipo(ETipos.TipoDePago.Efectivo)
                  pnlDocking.Enabled = False
                  SplitContainer2.Panel2Collapsed = True
                  m_tipopago = ETipos.TipoDePago.Efectivo
                  chkFraccionado.Checked = False
                        chkFraccionado.Visible = False
                        cmbFracionarPago.Visible = False
                    Case ETipos.getTipo(ETipos.TipoDePago.DepositoBancario)
                  m_tipopago = ETipos.TipoDePago.DepositoBancario
                        chkFraccionado.Visible = True
                        cmbFracionarPago.Visible = True'Combo de pago fraccionado 

                    Case ETipos.getTipo(ETipos.TipoDePago.NotaCredito)
                  m_tipopago = ETipos.TipoDePago.NotaCredito
                  chkFraccionado.Visible = True
               Case ETipos.getTipo(ETipos.TipoDePago.Detraccion)

                        m_bandera_detraccion_Aviso = True 
                  m_tipopago = ETipos.TipoDePago.Detraccion
                  chkFraccionado.Checked = False
                  chkFraccionado.Visible = False
               Case ETipos.getTipo(ETipos.TipoDePago.RecEgreInterno)
                  m_tipopago = ETipos.TipoDePago.RecEgreInterno
                  chkFraccionado.Visible = True
               Case Else
                  m_tipopago = ETipos.TipoDePago.Efectivo
                  chkFraccionado.Checked = False
                  chkFraccionado.Visible = False
            End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso de cambio de moneda", ex)
      End Try
   End Sub

   Dim m_order As Integer
   Private Sub OrdenarPendientes(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of EVENT_DocsVenta)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_facturas.DataSource, List(Of EVENT_DocsVenta)).Sort(_ordenador)
         c1grdDocsPendientes.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub c1grdDocsPendientes_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdDocsPendientes.BeforeSort
      Try
         OrdenarPendientes(c1grdDocsPendientes.Cols(e.Col).UserData)
         c1grdDocsPendientes.Subtotal(AggregateEnum.Clear)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If rbtnCliente.Checked Then
            txtBusqueda_ACAyudaClick(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso consultar documentos", ex)
      End Try
   End Sub

   Private Sub actsbtnCancelarDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actsbtnCancelar.Click
      Try
         If Not IsNothing(bs_entidades) Then
            If Not IsNothing(bs_entidades.Current) Then
               '' Codigo
               Dim x_entid_codigo As String = CType(bs_entidades.Current, EEntidades).ENTID_Codigo
               cargar(x_entid_codigo)
               actxnTipoCambio.Text = managerGenerarCancelacion.getTipoCambioSunat(DateTime.Now.Date)
               actxnTCSunat.Text = managerGenerarCancelacion.TipoCambioSunat.TIPOC_VentaSunat
               actxnTCAceros.Text = managerGenerarCancelacion.getUltimoTipoCambioOficina
               managerGenerarCancelacion.ListVENT_PagosFacturas = New List(Of EVENT_DocsVenta)() : bs_docsapagar = New BindingSource()
               bs_docsapagar.DataSource = managerGenerarCancelacion.ListVENT_PagosFacturas : c1grdDocsPagar.DataSource = bs_docsapagar : bnavDocsPagar.BindingSource = bs_docsapagar

               actxnNumero.Text = managerGenerarCancelacion.getNroTransaccion(GApp.PuntoVenta, txtSerie.Text)

               managerGenerarCancelacion.ListTESO_DocsPagos = New List(Of ETESO_DocsPagos) : bs_docspago = New BindingSource()
               bs_docspago.DataSource = managerGenerarCancelacion.ListTESO_DocsPagos : c1grdDocsPago.DataSource = bs_docspago : bnavDocsPago.BindingSource = bs_docspago

               



            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar, por que no ha cargado a un Cliente/Entidad ")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede, por que no ha cargado a un Cliente/Entidad ")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cancelar documento", ex)
      End Try
   End Sub

   Private Sub actool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnCancelar_Click
      Try
         actool.ACBtnModificarVisible = False
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Cancelar Operación: {0}", Me.Text) _
             , "Desea cancelar la operación?" _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
         Else
            actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cancelar operación", ex)
      End Try
   End Sub

   Private Sub btnConAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConAsignar.Click
      Try
         If Not IsNothing(bs_facturas.Current) Then
            If Not CType(bs_facturas.Current, EVENT_DocsVenta).Seleccionar Then
               'Dim _docsVenta As New EVENT_DocsVenta
               '_docsVenta = CType(bs_docsventa.Current, EVENT_DocsVenta)
               If CType(actxnPago.Text, Decimal) > 0 Then
                  CType(bs_facturas.Current, EVENT_DocsVenta).Seleccionar = True
                  CType(bs_facturas.Current, EVENT_DocsVenta).ImportePagar = actxnPago.Text
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja = New ETESO_Caja()
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.CAJA_Serie = txtSerie.Text
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.CAJA_Numero = actxnNumero.Text
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.CAJA_Fecha = dtpFechaEmision.Value.Date
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.CAJA_FechaPago = dtpFechaEmision.Value.Date
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.CAJA_Hora = dtpFechaEmision.Value
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.PVENT_Id = GApp.PuntoVenta
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.TIPOS_CodMonedaPago = cmbMoneda.SelectedValue
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.CAJA_TCSunatVenta = actxnTCSunat.Text
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.CAJA_TCambio = actxnTCAceros.Text
                  CType(bs_facturas.Current, EVENT_DocsVenta).TESO_Caja.CAJA_TCOficinaVenta = actxnTipoCambio.Text

                  managerGenerarCancelacion.ListVENT_PagosFacturas.Add(CType(bs_facturas.Current, EVENT_DocsVenta))
                  bs_docsapagar.ResetBindings(True)
                  bs_facturas.ResetBindings(True)
                  CalcularSeleccion()
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), "Ingresar un monto Cero"))
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso asignar producto.", ex)
      End Try
   End Sub

   Private Sub c1grdDocsPagar_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdDocsPagar.OwnerDrawCell
      Try
         If e.Row < c1grdDocsPagar.Rows.Fixed OrElse e.Col < c1grdDocsPagar.Cols.Fixed Then Return
         If c1grdDocsPagar.Cols(e.Col).Name = "ImportePagar" Then
            If c1grdDocsPagar.Rows(e.Row)("ImportePagar") > 0 Then
               e.Style = c1grdDocsPagar.Styles("Pagar")
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub c1grdDocsPendientes_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdDocsPendientes.OwnerDrawCell
      Try
         If e.Row < c1grdDocsPendientes.Rows.Fixed OrElse e.Col < c1grdDocsPendientes.Cols.Fixed Then Return
         If c1grdDocsPendientes.Cols(e.Col).Name = "Seleccionar" Then
            If Not c1grdDocsPendientes.Rows(e.Row)("Seleccionar").Equals(True) Then
               e.Style = c1grdDocsPendientes.Styles("Pagado")
            End If
         End If
         If c1grdDocsPendientes.Cols(e.Col).Name = "DOCVE_TotalPagar" Then
            If c1grdDocsPendientes.Rows(e.Row)("DOCVE_TotalPagar") > 0 Then
               e.Style = c1grdDocsPendientes.Styles("Pagar")
            End If
         End If
         If c1grdDocsPendientes.Cols(e.Col).Name = "DOCVE_TotalPagado" Then
            If c1grdDocsPendientes.Rows(e.Row)("DOCVE_TotalPagado") >= 0 Then
               e.Style = c1grdDocsPendientes.Styles("Pagado")
            End If
         End If
         If c1grdDocsPendientes.Cols(e.Col).Name = "SaldoPendiente" Then
            If c1grdDocsPendientes.Rows(e.Row)("SaldoPendiente") >= 0 Then
               e.Style = c1grdDocsPendientes.Styles("Pendiente")
            End If
         End If
         If CType(c1grdDocsPendientes.Rows(e.Row)("Seleccionar"), Boolean) Then
            e.Style = c1grdDocsPendientes.Styles("Resaltar")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub actool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub btnConAsigTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConAsigTodos.Click
      Try
         If Not IsNothing(bs_facturas.Current) Then
            For Each Item As EVENT_DocsVenta In CType(bs_facturas.DataSource, List(Of EVENT_DocsVenta))
               If Not Item.Seleccionar Then
                  Item.Seleccionar = True
                  Item.ImportePagar = Item.SaldoPendiente
                  Item.TESO_Caja = New ETESO_Caja()
                  Item.TESO_Caja.CAJA_Serie = txtSerie.Text
                  Item.TESO_Caja.CAJA_Numero = actxnNumero.Text
                  Item.TESO_Caja.CAJA_Fecha = dtpFechaEmision.Value.Date
                  Item.TESO_Caja.CAJA_FechaPago = dtpFechaEmision.Value.Date
                  Item.TESO_Caja.CAJA_Hora = dtpFechaEmision.Value
                  Item.TESO_Caja.PVENT_Id = GApp.PuntoVenta
                  Item.TESO_Caja.TIPOS_CodMonedaPago = cmbMoneda.SelectedValue
                  Item.TESO_Caja.CAJA_TCSunatVenta = actxnTCSunat.Text
                  Item.TESO_Caja.CAJA_TCambio = actxnTCAceros.Text
                  Item.TESO_Caja.CAJA_TCOficinaVenta = actxnTipoCambio.Text
                  managerGenerarCancelacion.ListVENT_PagosFacturas.Add(Item)
               End If
            Next
            bs_docsapagar.ResetBindings(True)
            bs_facturas.ResetBindings(True)
            CalcularSeleccion()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso asignar todos producto.", ex)
      End Try
   End Sub

   Private Sub btnConQuiTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConQuiTodos.Click
      Try
         If Not IsNothing(bs_docsapagar) Then
            managerGenerarCancelacion.ListVENT_PagosFacturas = New List(Of EVENT_DocsVenta)
            For Each Item As EVENT_DocsVenta In CType(bs_facturas.DataSource, List(Of EVENT_DocsVenta))
               Item.Seleccionar = False
            Next
            bs_docsapagar.DataSource = managerGenerarCancelacion.ListVENT_PagosFacturas
            bs_docsapagar.ResetBindings(True)
            bs_facturas.ResetBindings(True)
            CalcularSeleccion()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso quitar todo producto.", ex)
      End Try
   End Sub

   Private Sub btnConQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConQuitar.Click
      Try
         If Not IsNothing(bs_docsapagar.Current) Then
            CType(bs_docsapagar.Current, EVENT_DocsVenta).Seleccionar = False
            managerGenerarCancelacion.ListVENT_PagosFacturas.Remove(CType(bs_docsapagar.Current, EVENT_DocsVenta))
            bs_docsapagar.ResetBindings(True)
            bs_facturas.ResetBindings(True)
            CalcularSeleccion()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso quitar todo producto.", ex)
      End Try
   End Sub

   Private Sub tsbtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAgregarTPago.Click
      Try
            'If Not managerGenerarCancelacion.ListTESO_DocsPagos.Count < 1 Then
            '   ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se permite agregar mas documentos de pagos")
            '   Return
            'End If
            If Not IsNothing(bs_tipopago.Current) Then
            Select Case CType(bs_tipopago.Current, ETipos).TIPOS_Codigo
               Case ETipos.getTipo(ETipos.TipoDePago.NotaCredito)

                        If managerGenerarCancelacion.AyudaNC(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date, CType(bs_facturas.Current, EVENT_DocsVenta).ENTID_Codigo, CType(bs_facturas.Current, EVENT_DocsVenta).DOCVE_Codigo) Then
                            Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Documento de Pago", managerGenerarCancelacion.DTGCancelacion, False)
                            If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                Dim m_edocpago As New ETESO_DocsPagos


                                m_edocpago.TIPOS_TipoDocumento = "Nota de Credito"
                                m_edocpago.TIPOS_TipoMoneda = cmbMoneda.Text
                                m_edocpago.BANCO_Descripcion = " - "
                                m_edocpago.TIPOS_TipoCuenta = "Nota de Credito"
                                m_edocpago.TIPOS_CodModoPago = "MPG999"
                                m_edocpago.TIPOS_CodTipoDocumento = ETipos.getTipoDocPago(ETipos.TipoDocPago.NotaCredito)

                                m_edocpago.VENT_DocsVenta = CType(bs_facturas.Current, EVENT_DocsVenta)


                                m_edocpago.VENT_DocsVenta.ZONAS_Codigo = GApp.Zona
                                m_edocpago.VENT_DocsVenta.SUCUR_Id = GApp.Sucursal
                                m_edocpago.VENT_DocsVenta.PVENT_Id = GApp.PuntoVenta
                                m_edocpago.PVENT_Id = GApp.PuntoVenta

                                If cmbMoneda.SelectedValue = "MND1" Then
                                    m_edocpago.VENT_DocsVenta.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles)
                                    m_edocpago.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles)
                                Else
                                    m_edocpago.VENT_DocsVenta.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares)
                                    m_edocpago.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares)
                                End If

                                m_edocpago.VENT_DocsVenta.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.Contado)
                                m_edocpago.VENT_DocsVenta.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura) 'Nothing
                                'm_edocpago.TESO_Caja.CAJA_Serie = Mid(Ayuda.Respuesta.Rows(0)("NC"), 3, 3) 'CType(bs_facturas.Current, EVENT_DocsVenta).DOCVE_Serie 'txtSerie.Text
                                'm_edocpago.TESO_Caja.CAJA_Numero = Mid(Ayuda.Respuesta.Rows(0)("NC"), 8, 5) 'CType(bs_facturas.Current, EVENT_DocsVenta).DOCVE_Numero 'actxnNumero.Text
                                m_edocpago.DPAGO_Numero = 1 'Mid(Ayuda.Respuesta.Rows(0)("NC"), 9, 4)
                                m_edocpago.VENT_DocsVenta.DOCVE_FechaDocumento = CType(bs_facturas.Current, EVENT_DocsVenta).DOCVE_FechaDocumento 'AcFecha.ACDtpFecha_De.Value '.Date 'Ayuda.Respuesta.Rows(0)("DOCRE_FecCrea") '
                                m_edocpago.DPAGO_FecCrea = AcFecha.ACDtpFecha_De.Value
                                m_edocpago.DPAGO_Fecha = AcFecha.ACDtpFecha_De.Value
                                m_edocpago.DPAGO_FechaVenc = AcFecha.ACDtpFecha_De.Value
                                m_edocpago.VENT_DocsVenta.ENTID_CodigoVendedor = GApp.EUsuarioEntidad.ENTID_Codigo
                                m_edocpago.VENT_DocsVenta.DOCVE_PorcentajeIGV = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
                                If CType(Ayuda.Respuesta.Rows(0)("DOCRE_NCImporte"), Double) < 0 Then
                                    m_edocpago.DPAGO_Importe = CType(Ayuda.Respuesta.Rows(0)("DOCRE_NCImporte"), Double) * -1
                                Else
                                    m_edocpago.DPAGO_Importe = CType(Ayuda.Respuesta.Rows(0)("DOCRE_NCImporte"), Double)
                                End If
                                'CType(bs_facturas.Current, EVENT_DocsVenta).DOCVE_TotalPagar
                                m_edocpago.VENT_DocsVenta.DOCVE_TotalVenta = CType(Ayuda.Respuesta.Rows(0)("DOCRE_NCImporte"), Double) 'CType(bs_facturas.Current, EVENT_DocsVenta).DOCVE_TotalPagar
                                m_edocpago.VENT_DocsVenta.DOCVE_ImporteVenta = m_edocpago.VENT_DocsVenta.DPAGO_Importe / (1 + m_edocpago.VENT_DocsVenta.DOCVE_PorcentajeIGV / 100)
                                m_edocpago.VENT_DocsVenta.DOCVE_ImporteIgv = m_edocpago.VENT_DocsVenta.DPAGO_Importe - m_edocpago.VENT_DocsVenta.DOCVE_ImporteVenta


                                m_edocpago.DPAGO_Id = CType(Ayuda.Respuesta.Rows(0)("DOCRE_NCImporte"), Double) * -1

                                m_edocpago.ImporteUsado = CType(m_edocpago.DPAGO_Importe, Double)
                                managerTESO_DocsPagos.TESO_DocsPagos = m_edocpago


                                managerGenerarCancelacion.ListTESO_DocsPagos.Add(m_edocpago)
                                bs_docspago.ResetBindings(False)
                                Dim _importe As Decimal = 0
                                Dim _tcambio As Decimal = actxnTipoCambio.Text
                                For Each item As ETESO_DocsPagos In managerGenerarCancelacion.ListTESO_DocsPagos
                                    If cmbMoneda.SelectedValue = item.TIPOS_CodTipoMoneda Then
                                        _importe += item.DPAGO_Importe
                                    ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                                        If item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                                            _importe += item.DPAGO_Importe
                                        ElseIf item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                                            _importe += item.DPAGO_Importe * _tcambio
                                        End If
                                    ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                                        If item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                                            _importe += item.DPAGO_Importe / _tcambio
                                        ElseIf item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                                            _importe += item.DPAGO_Importe
                                        End If
                                    End If
                                Next
                                'actxnPago.Text = _importe
                                txnTotalDocPago.Text = _importe.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
                            Else
                                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el documento de pago")
                            End If
                        End If
                        'If 
                        '  /*_M*/
                    Case Else

                        If (chkFraccionado.Checked) Then 'Si el checkFraccionado esta activaod 
                            '               managerAdministracionCajas.ListTESO_DocsPagos = New List(Of ETESO_DocsPagos)
                            Dim _doc As String = IIf(CheckAllClient.Checked, Nothing, txtDocumento.Text)

                            'managerGenerarCancelacion
                            If managerGenerarCancelacion.Ayuda(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date, txtDocumento.Text) Then
                                '  If managerAdministracionCajas.Ayuda(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date, txtDocumento.Text) Then
                                Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Documento de Pago", managerGenerarCancelacion.DTGCancelacion, False)
                                If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                        Dim x_interno As Long = Ayuda.Respuesta.Rows(0)("Interno")
                                        Dim _doc_m As String
                                        If (CheckAllClient.Checked) Then
                                            _doc_m = Ayuda.Respuesta.Rows(0)("RUC / DNI")
                                        Else

                                            _doc_m = txtDocumento.Text
                                        End If

                                        If managerTESO_DocsPagos.CargarDocumento(x_interno, _doc_m) Then


                                            managerTESO_DocsPagos.TESO_DocsPagos.ImporteUsado = Ayuda.Respuesta.Rows(0)("Importe Usado") - Ayuda.Respuesta.Rows(0)("Importe Pendiente")
                                            managerTESO_DocsPagos.TESO_DocsPagos.DPAGO_Importe = Ayuda.Respuesta.Rows(0)("Importe Pendiente")

                                        managerGenerarCancelacion.ListTESO_DocsPagos.Add(managerTESO_DocsPagos.TESO_DocsPagos)
                                        bs_docspago.ResetBindings(False)

                                            Dim _importe As Decimal = 0
                                            Dim _tcambio As Decimal = actxnTipoCambio.Text
                                        For Each item As ETESO_DocsPagos In managerGenerarCancelacion.ListTESO_DocsPagos
                                            '_importe += item.DPAGO_Importe
                                            If cmbMoneda.SelectedValue = item.TIPOS_CodTipoMoneda Then
                                                _importe += item.DPAGO_Importe
                                            ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                                                If item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                                                    _importe += item.DPAGO_Importe
                                                ElseIf item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                                                    _importe += item.DPAGO_Importe * _tcambio
                                                End If
                                            ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                                                If item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                                                    _importe += item.DPAGO_Importe / _tcambio
                                                ElseIf item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                                                    _importe += item.DPAGO_Importe
                                                End If
                                            End If
                                        Next
                                        'Dim _pendiente As Decimal = Ayuda.Respuesta.Rows(0)("Importe Pendiente")
                                        txnTotalDocPago.Text = _importe.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))

                                        actxnPago.Focus()
                                        Else
                                            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el documento de pago")
                                        End If
                                    End If
                                Else
                                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar la ayuda, posiblemente no haya datos que mostrar")
                                End If

                            Else
                                Dim _doc As String = txtDocumento.Text 'IIf(chkBuscarTodosClientes.Checked, Nothing, txtDocumento.Text)
                            If managerGenerarCancelacion.Ayuda(AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date, txtDocumento.Text) Then
                                Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Documento de Pago", managerGenerarCancelacion.DTGCancelacion, False)
                                If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                    Dim x_interno As Long = Ayuda.Respuesta.Rows(0)("Interno")
                                    If managerTESO_DocsPagos.CargarDocumento(x_interno, _doc) Then
                                        managerTESO_DocsPagos.TESO_DocsPagos.ImporteUsado = Ayuda.Respuesta.Rows(0)("Importe Usado")
                                        managerTESO_DocsPagos.TESO_DocsPagos.DPAGO_Importe -= Ayuda.Respuesta.Rows(0)("Importe Usado")
                                        managerGenerarCancelacion.ListTESO_DocsPagos.Add(managerTESO_DocsPagos.TESO_DocsPagos)
                                        bs_docspago.ResetBindings(False)
                                        actxnPago.Focus()

                                        Dim _importe As Decimal = 0
                                        Dim _tcambio As Decimal = actxnTipoCambio.Text
                                        For Each item As ETESO_DocsPagos In managerGenerarCancelacion.ListTESO_DocsPagos
                                            If cmbMoneda.SelectedValue = item.TIPOS_CodTipoMoneda Then
                                                _importe += item.DPAGO_Importe
                                            ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                                                If item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                                                    _importe += item.DPAGO_Importe
                                                ElseIf item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                                                    _importe += item.DPAGO_Importe * _tcambio
                                                End If
                                            ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                                                If item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                                                    _importe += item.DPAGO_Importe / _tcambio
                                                ElseIf item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                                                    _importe += item.DPAGO_Importe
                                                End If
                                            End If
                                        Next
                                        'actxnPago.Text = _importe
                                        txnTotalDocPago.Text = _importe.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
                                    Else
                                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el documento de pago")
                                    End If
                                End If
                            Else
                                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar la ayuda, posiblemente no haya datos que mostrar")
                            End If

                        End If


                End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Documento de Pago", ex)
      End Try
   End Sub

   Private Sub txtBusqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Try
            Select Case e.KeyCode
                Case Keys.Down
                    bs_entidades.Position += 1
                    e.Handled = True
                    Exit Select
                Case Keys.Up
                    bs_entidades.Position -= 1
                    e.Handled = True
                    Exit Select
                Case Keys.PageDown
                    bs_entidades.Position += 10
                    e.Handled = True
                    e.Handled = True
                    Exit Select
                Case Keys.PageUp
                    bs_entidades.Position -= 10
                    e.Handled = True
                    e.Handled = True
                    Exit Select
            End Select
        Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No puede completar el proceso ejecutado por el teclado", ex)
      End Try
   End Sub

   Private Sub txtBusqueda_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBusqueda.KeyUp
      Try
         If e.KeyCode = Keys.Enter Then
            txtBusqueda_ACAyudaClick(Nothing, Nothing)
         ElseIf e.KeyCode = Keys.F4 Then
            If Not IsNothing(bs_entidades) Then
               actsbtnCancelarDocs_Click(Nothing, Nothing)
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No puede completar el proceso ejecutado por el teclado", ex)
      End Try
   End Sub

   Private Sub c1grdBusqueda_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdBusqueda.DoubleClick
      actsbtnCancelarDocs_Click(Nothing, Nothing)
   End Sub

   Private Sub txtBusNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Try
         Select Case e.KeyCode
            Case Keys.Down
               bs_entidades.Position += 1
               e.Handled = True
               Exit Select
            Case Keys.Up
               bs_entidades.Position -= 1
               e.Handled = True
               Exit Select
            Case Keys.PageDown
               bs_entidades.Position += 10
               e.Handled = True
               e.Handled = True
               Exit Select
            Case Keys.PageUp
               bs_entidades.Position -= 10
               e.Handled = True
               e.Handled = True
               Exit Select
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No puede completar el proceso ejecutado por el teclado", ex)
      End Try
   End Sub

   Private Sub c1grdDocsPendientes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdDocsPendientes.DoubleClick
      btnConAsignar_Click(Nothing, Nothing)
   End Sub

   Private Sub c1grdDocsPagar_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdDocsPagar.DoubleClick
      btnConQuitar_Click(Nothing, Nothing)
   End Sub

#Region " Ayudas "


    Private Sub txtBusqueda_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.ACAyudaClick
        Try
            busquedaCliente(txtBusqueda.Text)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de clientes", ex)
        End Try
    End Sub

#End Region
#End Region

   Private Sub actool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnGrabar_Click
        Dim _msg As String = ""
        Dim _redondeo As BAdminCaja.TRedondeo
        Dim NroDocumentoCliente As String = txtDocumento.Text
        Try

            If m_bandera_detraccion_Aviso  = True  Then
                  'ESTO SOLO ES UN AVISO ================================================NO AFECTA EN COMO SE MANEJA EL GUARDADO 15-11-2025 FRANK          
                If  ComprobacionMontosDetraccion(CType(bs_facturas.Current,EVENT_DocsVenta).DOCVE_ImporteDetraccion,globales_.x_MontoDetraccionAGrabar) Then
                    'NO MUESTRA NADA ..--->  Coincide -->                           
              Else 
                       If ( MostrarMensajeAdvertencia()) then 
                    Else  
              'SI GUE COMO SI NADA 
                    Return
                        End If 
                End If

                Else 


            End If

         

            If Validar(_msg, _redondeo) Then
                Dim _cadena As String = ""
                Dim _cad As String = String.Format("Documentos a ser Cancelados:{0}", vbNewLine)
                For Each item As EVENT_DocsVenta In managerGenerarCancelacion.ListVENT_DocsVenta
                    If item.Seleccionar Then
                        _cadena &= String.Format(" {0},", item.Documento)
                        _cad &= String.Format("- {0} Importe: {1} {2}.{3}", item.Documento, item.TIPOS_TipoMoneda, item.ImportePagar, vbNewLine)
                    End If
                Next
                _cadena = _cadena.Substring(0, _cadena.Length - 1)
                

                    If _cadena.Length > 20 Then _cadena = ""

                If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Generar Cancelación: {0}", Me.Text) _
                                            , String.Format("¿Generar la Cancelación de los Documentos Seleccionados: {0}. Con un total de: {1} {2}?", _cadena, CType(bs_moneda.Current, ETipos).TIPOS_DescCorta, tstxnTotalPagar.Text) _
                                            , _cad, ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                    If managerGenerarCancelacion.GrabarPagos(GApp.Usuario, m_tipopago, txtSerie.Text, dtpFechaEmision.Value, actxnTipoCambio.Text, _redondeo, chkFraccionado.CheckState, CType(cmbFracionarPago.SelectedItem, ETipos), NroDocumentoCliente) Then 'Agregado check estate by frank 
                        ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Cargado Satisfactoriamente")) '
                        actsbtnCancelarDocs_Click(Nothing, Nothing)
                    Else
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), "Grabar, existen errores"), _msg)
                    End If
                Else
                    setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                End If
            Else
                setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), "Grabar, existen errores, revise el detalle"), _msg)
            End If
        Catch ex As Exception
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Grabar Cancelación", ex)
      End Try
   End Sub

    Private Function Validar(ByRef x_msg As String, ByRef x_redondear As BAdminCaja.TRedondeo)
        x_msg = ""
        Try
            If Not managerGenerarCancelacion.ListVENT_PagosFacturas.Count > 0 Then x_msg &= String.Format("- No se ha seleccionado ningun documento para realizar su cancelación{0}", vbNewLine)
            Select Case m_tipopago
                Case ETipos.TipoDePago.Efectivo
                   'actxnTotal =Total Pendiente a Pagar 
                Case ETipos.TipoDePago.Detraccion
                    Dim _pagar As Decimal = tstxnTotalPagar.Text
                    Dim _docpago As Decimal = txnTotalDocPago.Text
                    Dim tcambio As Decimal = actxnTipoCambio.Text
                    If cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                        If managerGenerarCancelacion.ListTESO_DocsPagos(0).TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                            If _pagar <> _docpago Then
                                x_msg &= String.Format("- El documento de pago tiene un importe diferente al los documentos que se desean pagar{0}", vbNewLine)
                            End If
                        End If
                    ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                        If managerGenerarCancelacion.ListTESO_DocsPagos(0).TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                            'Dim _npagar As Decimal = Math.Round(_pagar * tcambio, 2)
                            If _pagar <> _docpago Then
                                x_msg &= String.Format("- El documento de pago tiene un importe diferente al los documentos que se desean pagar{0}, Importe de Documentos: {1}, Importe a Pagar: {2}", vbNewLine, _docpago, _pagar)
                            End If
                        End If
                    End If
                    'Falta poner un condicion para Detraccion 
                Case Else
                    Dim _pagar As Decimal = tstxnTotalPagar.Text
                    Dim _docpago As Decimal = txnTotalDocPago.Text
                    If _pagar <> _docpago Then
                        Dim _existe As Boolean
                        Dim _limiteimporte As Decimal = Parametros.GetParametro("pg_LimitRedonde", _existe)
                        If Math.Abs(_pagar - _docpago) < _limiteimporte Then
                            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Redondear Registro: {0}", Me.Text) _
                                            , String.Format("El Importe del Documento de Venta es {0:#,###,##0.00} y el Documento de Pago es {1:#,###,##0.00}, no son iguales, ¿desea redondear el importe a pagar, para cancelar el documento de forma total?", _pagar, _docpago) _
                                            , "Si considera redondear el pago el sistema tomara de forma automatica y generara un pago para realizar el redondeo de pago." _
                                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                                If _docpago > _pagar Then
                                    x_redondear = BAdminCaja.TRedondeo.PorExcesoPago
                                Else : x_redondear = BAdminCaja.TRedondeo.PorFaltaPago
                                End If
                            End If
                        Else
                            If (chkFraccionado.Checked) Then 'Si el Check esta fraacccionado osea el pago por partes 
                                x_redondear = BAdminCaja.TRedondeo.SinRedondeo


                            Else
                                x_redondear = BAdminCaja.TRedondeo.SinRedondeo
                                x_msg &= String.Format("- El documento de pago tiene un importe diferente al los documentos que se desean pagar{0}", vbNewLine)


                            End If
                        End If
                    End If
            End Select

            Return Not x_msg.Length > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   'Private Sub actxnPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles actxnPago.LostFocus
   '   Try
   '      Dim _importe As Decimal = actxnPago.Text
   '      Dim _usado As Decimal = 0
   '      If Not IsNothing(managerGenerarCancelacion.ListTESO_DocsPagos) Then
   '         For Each item As ETESO_DocsPagos In managerGenerarCancelacion.ListTESO_DocsPagos
   '            If (_importe - _usado) > item.DPAGO_Importe Then
   '               item.ImporteUsado = item.DPAGO_Importe
   '               _usado += item.ImporteUsado
   '            Else
   '               item.ImporteUsado = _importe - _usado
   '            End If
   '         Next
   '      End If
   '   Catch ex As Exception
   '      ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Calcular Importe Usado", ex)
   '   End Try
   'End Sub

#Region " Botones Add "

#End Region

   Private Sub tsbtnNuevoTPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnNuevoTPago.Click
        Try
            'Aca Ingresar para Generar La cancelacion del Pago ==> Ventana 
            If Not managerGenerarCancelacion.ListTESO_DocsPagos.Count < 1 Then
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se permite agregar mas documentos de pagos")
                Return
            End If
            Dim m_eteso_docspagos As MDocsPago
            Select Case m_tipopago
                Case ETipos.TipoDePago.DepositoBancario
                    m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.Deposito, False, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
                Case ETipos.TipoDePago.Letra
                    m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.Letra, False, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
                Case ETipos.TipoDePago.NotaCredito
                    m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.NotaCredito, False, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
                Case ETipos.TipoDePago.Detraccion


                    m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.Detraccion, False, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
                Case ETipos.TipoDePago.RecEgreInterno
                    m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.RecEgreInterno, False, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
                Case Else
                    m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.Deposito, False, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
            End Select
            If m_eteso_docspagos.ShowDialog() = Windows.Forms.DialogResult.OK Then
                managerGenerarCancelacion.ListTESO_DocsPagos.Add(m_eteso_docspagos.TESO_DocsPagos)
                bs_docspago.ResetBindings(False)
                Dim _importe As Decimal = 0
                Dim _tcambio As Decimal = actxnTipoCambio.Text
                For Each item As ETESO_DocsPagos In managerGenerarCancelacion.ListTESO_DocsPagos
                    If cmbMoneda.SelectedValue = item.TIPOS_CodTipoMoneda Then
                        _importe += item.ImporteUsado
                    ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                        If item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                            _importe += item.ImporteUsado
                        ElseIf item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                            _importe += item.ImporteUsado * _tcambio
                        End If
                    ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                        If item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                            _importe += item.ImporteUsado / _tcambio
                        ElseIf item.TIPOS_CodTipoMoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                            _importe += item.ImporteUsado
                        End If
                    End If
                Next
                'actxnPago.Text = _importe
                txnTotalDocPago.Text = _importe.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No de Puede Crear un Documento de Pago", ex)
      End Try
   End Sub

   Private Sub tsbtnAgregarTPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim m_eteso_docspagos As MDocsPago
         Select Case m_tipopago
            Case ETipos.TipoDePago.DepositoBancario
               m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.Deposito, True, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
            Case ETipos.TipoDePago.Letra
               m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.Letra, True, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
            Case ETipos.TipoDePago.NotaCredito
               m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.Deposito, True, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
            Case Else
               m_eteso_docspagos = New MDocsPago(ETipos.TipoDocPago.Deposito, True, MDocsPago.TipoInicio.Dialogo) With {.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle, .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.CenterScreen}
         End Select
         If m_eteso_docspagos.ShowDialog() Then
            managerGenerarCancelacion.ListTESO_DocsPagos.Add(m_eteso_docspagos.TESO_DocsPagos)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No de Puede Agregar un Documento de Pago", ex)
      End Try
   End Sub

   Private Sub tsbtnQuitarTPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnQuitarTPago.Click
      Try
         If Not IsNothing(bs_docspago) Then
            If Not IsNothing(bs_docspago.Current) Then
               '' Codigo
               managerGenerarCancelacion.ListTESO_DocsPagos.Remove(CType(bs_docspago.Current, ETESO_DocsPagos))
               bs_docspago.ResetBindings(False)
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede <<Mensaje>> ")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede <<Mensaje>> ")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No de Puede Quitar un Documento de Pago", ex)
      End Try
   End Sub

   Private Sub AcFecha_ACFecIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecIni_KeyDown
      If e.KeyData = Keys.Enter Then
         AcFecha.ACDtpFecha_A.Focus()
      End If
   End Sub

   Private Sub AcFecha_ACFecFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecFin_KeyDown
      If e.KeyData = Keys.Enter Then
         tsbtnAgregar_Click(Nothing, Nothing)
      End If
   End Sub

   Private Sub actxnPago_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxnPago.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnConAsignar.Focus()
      End If
   End Sub


   Private Sub chkFraccionado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFraccionado.CheckedChanged
      txnTotalDocPago.ReadOnly = Not chkFraccionado.Checked
   End Sub
Private function ComprobacionMontosDetraccion (Byval x_MontoDetraccion1 , ByVal x_x_MontoDetraccion2) As Boolean
        If (Convert.ToDecimal(x_MontoDetraccion1) =   Convert.ToDecimal( globales_.x_MontoDetraccionAGrabar) ) Then
            Return True 
            Else
            Return False
        End If  
End function

    Public Function MostrarMensajeAdvertencia() 
    If ACControles.ACDialogos.ACMostrarMensajePregunta(
        String.Format("Seguro que quieres continuar? {0}", Me.Text),
        String.Format("Atención: {0}{1}{2}",
                      "El monto del depósito no coincide: ",
                      CType(bs_facturas.Current, EVENT_DocsVenta).DOCVE_ImporteDetraccion,
                      " - Detracción: " & globales_.x_MontoDetraccionAGrabar.ToString()),
        ACControles.ACDialogos.LabelBotom.Si_No
    ) = DialogResult.Yes Then


            
            Return True 

             '   If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Cancelar Operación: {0}", Me.Text) _
             ', "Desea cancelar la operación?" _
             ', ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
         Else
            Return False 

         End If      
    End Function
   
End Class