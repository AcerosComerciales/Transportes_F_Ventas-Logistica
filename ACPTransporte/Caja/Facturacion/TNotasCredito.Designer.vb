<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TNotasCredito
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TNotasCredito))
        Me.ACPanel = New ACControles.ACPanelCaption()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.actsbtnModFecha = New ACControles.ACToolStripButton(Me.components)
        Me.actsbtnPrevisualizar = New ACControles.ACToolStripButton(Me.components)
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.SContenedor = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        Me.cmbDirecciones = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.chkIlncluidoIGV = New System.Windows.Forms.CheckBox()
        Me.lblNroDocumento = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.actxaCliRazonSocial = New ACControles.ACTextBoxAyuda()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbMotivo = New System.Windows.Forms.ComboBox()
        Me.actxaCliRuc = New ACControles.ACTextBoxAyuda()
        Me.actxnTipoCambioSunat = New ACControles.ACTextBoxNumerico()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.dtpFecFacturacion = New System.Windows.Forms.DateTimePicker()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.actxnTipoCambio = New ACControles.ACTextBoxNumerico()
        Me.btnNuevoCliente = New System.Windows.Forms.Button()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.tabRelacionados = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tpgVarias = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlPanel1 = New System.Windows.Forms.Panel()
        Me.c1grdFacturas = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavRelacionados = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAgregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnQuitar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption3 = New ACControles.ACPanelCaption()
        Me.tpgUnico = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.actxaNroDocumento = New ACControles.ACTextBoxAyuda()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbRefDocumento = New System.Windows.Forms.ComboBox()
        Me.cmbRefSerie = New System.Windows.Forms.ComboBox()
        Me.lblRefNroDocumento = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.c1grdDetalle = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pnlItem = New System.Windows.Forms.Panel()
        Me.actxnPrecio = New ACControles.ACTextBoxNumerico()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProdUnidad = New System.Windows.Forms.TextBox()
        Me.actxnSubImporte = New ACControles.ACTextBoxNumerico()
        Me.actxnProdCantidad = New ACControles.ACTextBoxNumerico()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtProdDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.actxaProdCodigo = New ACControles.ACTextBoxAyuda()
        Me.txtOpcion = New System.Windows.Forms.TextBox()
        Me.bnavProductos = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslblSon = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbImpresora = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lblTotalPagar = New System.Windows.Forms.Label()
        Me.lbligv = New System.Windows.Forms.Label()
        Me.actxnImporte = New ACControles.ACTextBoxNumerico()
        Me.actxnIGV = New ACControles.ACTextBoxNumerico()
        Me.chkDescuento = New System.Windows.Forms.CheckBox()
        Me.actxnTotalPagar = New ACControles.ACTextBoxNumerico()
        Me.chkAnulada = New System.Windows.Forms.CheckBox()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbDocumentoFacturar = New System.Windows.Forms.ComboBox()
        Me.actxnNumero = New ACControles.ACTextBoxNumerico()
        Me.cmbSerie = New System.Windows.Forms.ComboBox()
        Me.lblFecTramite = New System.Windows.Forms.Label()
        Me.dtpFecTramite = New System.Windows.Forms.DateTimePicker()
        Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.c1grdBusqueda = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grpBusqueda = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.rbtnNroCotizacion = New System.Windows.Forms.RadioButton()
        Me.rbtnCliente = New System.Windows.Forms.RadioButton()
        Me.grpCliente = New System.Windows.Forms.GroupBox()
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.grpDocumentos = New System.Windows.Forms.GroupBox()
        Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.txtBusNumero = New ACControles.ACTextBoxAyuda()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.AcFecha = New ACControles.ACFecha(Me.components)
        Me.bnavBusqueda = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.acTool.SuspendLayout()
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        CType(Me.SContenedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SContenedor.Panel1.SuspendLayout()
        Me.SContenedor.Panel2.SuspendLayout()
        Me.SContenedor.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlCuerpo.SuspendLayout()
        Me.tabRelacionados.SuspendLayout()
        Me.tpgVarias.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlPanel1.SuspendLayout()
        CType(Me.c1grdFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavRelacionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavRelacionados.SuspendLayout()
        Me.tpgUnico.SuspendLayout()
        Me.pnlDetalle.SuspendLayout()
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlItem.SuspendLayout()
        CType(Me.bnavProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavProductos.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.tabBusqueda.SuspendLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBusqueda.SuspendLayout()
        Me.grpCliente.SuspendLayout()
        Me.grpDocumentos.SuspendLayout()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'ACPanel
        '
        Me.ACPanel.ACCaption = "Facturación de Notas {0} - División de Transportes"
        Me.ACPanel.ActiveGradientHighColor = System.Drawing.Color.Red
        Me.ACPanel.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ACPanel.ActiveTextColor = System.Drawing.Color.White
        Me.ACPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ACPanel.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.ACPanel.Location = New System.Drawing.Point(0, 0)
        Me.ACPanel.Name = "ACPanel"
        Me.ACPanel.Size = New System.Drawing.Size(884, 40)
        Me.ACPanel.TabIndex = 3
        '
        'acTool
        '
        Me.acTool.ACBtnBuscarEnabled = False
        Me.acTool.ACBtnBuscarVisible = False
        Me.acTool.ACBtnCancelarEnabled = False
        Me.acTool.ACBtnCancelarVisible = False
        Me.acTool.ACBtnEliminarEnabled = False
        Me.acTool.ACBtnEliminarVisible = False
        Me.acTool.ACBtnGrabarEnabled = False
        Me.acTool.ACBtnGrabarVisible = False
        Me.acTool.ACBtnRehusarEnabled = False
        Me.acTool.ACBtnRehusarVisible = False
        Me.acTool.ACBtnReporteEnabled = False
        Me.acTool.ACBtnReporteVisible = False
        Me.acTool.ACBtnSalirEnabled = False
        Me.acTool.ACBtnSalirText = "&Salir"
        Me.acTool.ACBtnSalirVisible = False
        Me.acTool.ACBtnVolverEnabled = False
        Me.acTool.ACBtnVolverVisible = False
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabarAnularImprimir
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.actsbtnModFecha, Me.actsbtnPrevisualizar})
        Me.acTool.Location = New System.Drawing.Point(0, 506)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(884, 56)
        Me.acTool.TabIndex = 4
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'actsbtnModFecha
        '
        Me.actsbtnModFecha.AutoSize = False
        Me.actsbtnModFecha.Image = Global.ACPTransportes.My.Resources.Resources.EditPaper_32x32
        Me.actsbtnModFecha.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.actsbtnModFecha.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.actsbtnModFecha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.actsbtnModFecha.Name = "tsbBoton"
        Me.actsbtnModFecha.Size = New System.Drawing.Size(102, 53)
        Me.actsbtnModFecha.Text = "Modificar Fecha"
        Me.actsbtnModFecha.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.actsbtnModFecha.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.actsbtnModFecha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.actsbtnModFecha.Visible = False
        '
        'actsbtnPrevisualizar
        '
        Me.actsbtnPrevisualizar.AutoSize = False
        Me.actsbtnPrevisualizar.Image = Global.ACPTransportes.My.Resources.Resources.Buscar2_32x32
        Me.actsbtnPrevisualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.actsbtnPrevisualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.actsbtnPrevisualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.actsbtnPrevisualizar.Name = "tsbBoton"
        Me.actsbtnPrevisualizar.Size = New System.Drawing.Size(84, 53)
        Me.actsbtnPrevisualizar.Text = "Revisar"
        Me.actsbtnPrevisualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.actsbtnPrevisualizar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.actsbtnPrevisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.actsbtnPrevisualizar.Visible = False
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 40)
        Me.tabMantenimiento.MediaPlayerDockSides = False
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = False
        Me.tabMantenimiento.SelectedIndex = 0
        Me.tabMantenimiento.ShowDropSelect = False
        Me.tabMantenimiento.Size = New System.Drawing.Size(884, 466)
        Me.tabMantenimiento.TabIndex = 5
        Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos, Me.tabBusqueda})
        Me.tabMantenimiento.TextTips = True
        '
        'tabDatos
        '
        Me.tabDatos.Controls.Add(Me.pnlDatos)
        Me.tabDatos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Location = New System.Drawing.Point(1, 1)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Size = New System.Drawing.Size(882, 441)
        Me.tabDatos.TabIndex = 2
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.SContenedor)
        Me.pnlDatos.Controls.Add(Me.pnlPie)
        Me.pnlDatos.Controls.Add(Me.pnlCabecera)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(882, 441)
        Me.pnlDatos.TabIndex = 1
        '
        'SContenedor
        '
        Me.SContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SContenedor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SContenedor.Location = New System.Drawing.Point(0, 37)
        Me.SContenedor.Name = "SContenedor"
        Me.SContenedor.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SContenedor.Panel1
        '
        Me.SContenedor.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SContenedor.Panel2
        '
        Me.SContenedor.Panel2.Controls.Add(Me.pnlDetalle)
        Me.SContenedor.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SContenedor.Size = New System.Drawing.Size(882, 368)
        Me.SContenedor.SplitterDistance = 176
        Me.SContenedor.SplitterWidth = 6
        Me.SContenedor.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlCuerpo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabRelacionados)
        Me.SplitContainer1.Size = New System.Drawing.Size(882, 176)
        Me.SplitContainer1.SplitterDistance = 559
        Me.SplitContainer1.TabIndex = 12
        '
        'pnlCuerpo
        '
        Me.pnlCuerpo.Controls.Add(Me.cmbDirecciones)
        Me.pnlCuerpo.Controls.Add(Me.Label5)
        Me.pnlCuerpo.Controls.Add(Me.txtDireccion)
        Me.pnlCuerpo.Controls.Add(Me.chkIlncluidoIGV)
        Me.pnlCuerpo.Controls.Add(Me.lblNroDocumento)
        Me.pnlCuerpo.Controls.Add(Me.Label3)
        Me.pnlCuerpo.Controls.Add(Me.Label4)
        Me.pnlCuerpo.Controls.Add(Me.cmbMoneda)
        Me.pnlCuerpo.Controls.Add(Me.actxaCliRazonSocial)
        Me.pnlCuerpo.Controls.Add(Me.Label8)
        Me.pnlCuerpo.Controls.Add(Me.cmbMotivo)
        Me.pnlCuerpo.Controls.Add(Me.actxaCliRuc)
        Me.pnlCuerpo.Controls.Add(Me.actxnTipoCambioSunat)
        Me.pnlCuerpo.Controls.Add(Me.lblMoneda)
        Me.pnlCuerpo.Controls.Add(Me.Label7)
        Me.pnlCuerpo.Controls.Add(Me.btnClean)
        Me.pnlCuerpo.Controls.Add(Me.dtpFecFacturacion)
        Me.pnlCuerpo.Controls.Add(Me.Label31)
        Me.pnlCuerpo.Controls.Add(Me.actxnTipoCambio)
        Me.pnlCuerpo.Controls.Add(Me.btnNuevoCliente)
        Me.pnlCuerpo.Controls.Add(Me.txtMotivo)
        Me.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCuerpo.Location = New System.Drawing.Point(0, 0)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(559, 176)
        Me.pnlCuerpo.TabIndex = 3
        '
        'cmbDirecciones
        '
        Me.cmbDirecciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDirecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDirecciones.DropDownWidth = 250
        Me.cmbDirecciones.FormattingEnabled = True
        Me.cmbDirecciones.Location = New System.Drawing.Point(87, 31)
        Me.cmbDirecciones.Name = "cmbDirecciones"
        Me.cmbDirecciones.Size = New System.Drawing.Size(464, 23)
        Me.cmbDirecciones.TabIndex = 6
        Me.cmbDirecciones.Tag = "ECO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Direccion :"
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.Location = New System.Drawing.Point(87, 31)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(464, 23)
        Me.txtDireccion.TabIndex = 7
        '
        'chkIlncluidoIGV
        '
        Me.chkIlncluidoIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIlncluidoIGV.AutoSize = True
        Me.chkIlncluidoIGV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIlncluidoIGV.Location = New System.Drawing.Point(83, 151)
        Me.chkIlncluidoIGV.Name = "chkIlncluidoIGV"
        Me.chkIlncluidoIGV.Size = New System.Drawing.Size(99, 19)
        Me.chkIlncluidoIGV.TabIndex = 16
        Me.chkIlncluidoIGV.Text = "Incluido I.G.V."
        Me.chkIlncluidoIGV.UseVisualStyleBackColor = True
        '
        'lblNroDocumento
        '
        Me.lblNroDocumento.AutoSize = True
        Me.lblNroDocumento.Location = New System.Drawing.Point(32, 9)
        Me.lblNroDocumento.Name = "lblNroDocumento"
        Me.lblNroDocumento.Size = New System.Drawing.Size(50, 15)
        Me.lblNroDocumento.TabIndex = 0
        Me.lblNroDocumento.Text = "Cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Motivo :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Tipo Motivo :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.DropDownWidth = 250
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(87, 56)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(102, 23)
        Me.cmbMoneda.TabIndex = 9
        Me.cmbMoneda.Tag = "EO"
        '
        'actxaCliRazonSocial
        '
        Me.actxaCliRazonSocial.ACActivarAyudaAuto = False
        Me.actxaCliRazonSocial.ACLongitudAceptada = 0
        Me.actxaCliRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaCliRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaCliRazonSocial.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxaCliRazonSocial.Location = New System.Drawing.Point(195, 4)
        Me.actxaCliRazonSocial.MaxLength = 32767
        Me.actxaCliRazonSocial.Name = "actxaCliRazonSocial"
        Me.actxaCliRazonSocial.Size = New System.Drawing.Size(298, 24)
        Me.actxaCliRazonSocial.TabIndex = 2
        Me.actxaCliRazonSocial.Tag = "EVO"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(340, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Fecha Documento :"
        '
        'cmbMotivo
        '
        Me.cmbMotivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivo.DropDownWidth = 250
        Me.cmbMotivo.FormattingEnabled = True
        Me.cmbMotivo.Location = New System.Drawing.Point(87, 81)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(465, 23)
        Me.cmbMotivo.TabIndex = 13
        Me.cmbMotivo.Tag = "ECO"
        '
        'actxaCliRuc
        '
        Me.actxaCliRuc.ACActivarAyudaAuto = False
        Me.actxaCliRuc.ACLongitudAceptada = 0
        Me.actxaCliRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaCliRuc.Location = New System.Drawing.Point(87, 5)
        Me.actxaCliRuc.MaxLength = 32767
        Me.actxaCliRuc.Name = "actxaCliRuc"
        Me.actxaCliRuc.Size = New System.Drawing.Size(102, 23)
        Me.actxaCliRuc.TabIndex = 1
        Me.actxaCliRuc.Tag = "EVO"
        '
        'actxnTipoCambioSunat
        '
        Me.actxnTipoCambioSunat.ACEnteros = 9
        Me.actxnTipoCambioSunat.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTipoCambioSunat.ACNegativo = True
        Me.actxnTipoCambioSunat.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTipoCambioSunat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnTipoCambioSunat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnTipoCambioSunat.Location = New System.Drawing.Point(492, 149)
        Me.actxnTipoCambioSunat.MaxLength = 12
        Me.actxnTipoCambioSunat.Name = "actxnTipoCambioSunat"
        Me.actxnTipoCambioSunat.ReadOnly = True
        Me.actxnTipoCambioSunat.Size = New System.Drawing.Size(59, 23)
        Me.actxnTipoCambioSunat.TabIndex = 20
        Me.actxnTipoCambioSunat.Text = "0.00"
        Me.actxnTipoCambioSunat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(24, 60)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(57, 15)
        Me.lblMoneda.TabIndex = 8
        Me.lblMoneda.Text = "&Moneda :"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Enabled = False
        Me.Label7.Location = New System.Drawing.Point(416, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 15)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "T. C. Sunat :"
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClean.Image = Global.ACPTransportes.My.Resources.Resources.Delete_16x16
        Me.btnClean.Location = New System.Drawing.Point(524, 3)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(29, 27)
        Me.btnClean.TabIndex = 4
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'dtpFecFacturacion
        '
        Me.dtpFecFacturacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecFacturacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFacturacion.Location = New System.Drawing.Point(456, 55)
        Me.dtpFecFacturacion.Name = "dtpFecFacturacion"
        Me.dtpFecFacturacion.Size = New System.Drawing.Size(95, 23)
        Me.dtpFecFacturacion.TabIndex = 11
        Me.dtpFecFacturacion.Tag = "E"
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Enabled = False
        Me.Label31.Location = New System.Drawing.Point(238, 153)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(95, 15)
        Me.Label31.TabIndex = 17
        Me.Label31.Text = "T. C. Venta A.C. :"
        '
        'actxnTipoCambio
        '
        Me.actxnTipoCambio.ACEnteros = 9
        Me.actxnTipoCambio.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTipoCambio.ACNegativo = True
        Me.actxnTipoCambio.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnTipoCambio.Location = New System.Drawing.Point(343, 149)
        Me.actxnTipoCambio.MaxLength = 12
        Me.actxnTipoCambio.Name = "actxnTipoCambio"
        Me.actxnTipoCambio.ReadOnly = True
        Me.actxnTipoCambio.Size = New System.Drawing.Size(59, 23)
        Me.actxnTipoCambio.TabIndex = 18
        Me.actxnTipoCambio.Text = "0.00"
        Me.actxnTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnNuevoCliente
        '
        Me.btnNuevoCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevoCliente.Image = Global.ACPTransportes.My.Resources.Resources.Nuevo_16x16
        Me.btnNuevoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoCliente.Location = New System.Drawing.Point(494, 3)
        Me.btnNuevoCliente.Name = "btnNuevoCliente"
        Me.btnNuevoCliente.Size = New System.Drawing.Size(29, 27)
        Me.btnNuevoCliente.TabIndex = 3
        Me.btnNuevoCliente.UseVisualStyleBackColor = True
        '
        'txtMotivo
        '
        Me.txtMotivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMotivo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivo.Location = New System.Drawing.Point(87, 106)
        Me.txtMotivo.MaxLength = 250
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMotivo.Size = New System.Drawing.Size(465, 39)
        Me.txtMotivo.TabIndex = 15
        Me.txtMotivo.Tag = "EV"
        '
        'tabRelacionados
        '
        Me.tabRelacionados.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabRelacionados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabRelacionados.Location = New System.Drawing.Point(0, 0)
        Me.tabRelacionados.MediaPlayerDockSides = False
        Me.tabRelacionados.Name = "tabRelacionados"
        Me.tabRelacionados.OfficeDockSides = False
        Me.tabRelacionados.SelectedIndex = 1
        Me.tabRelacionados.ShowDropSelect = False
        Me.tabRelacionados.Size = New System.Drawing.Size(319, 176)
        Me.tabRelacionados.TabIndex = 11
        Me.tabRelacionados.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tpgVarias, Me.tpgUnico})
        Me.tabRelacionados.TextTips = True
        '
        'tpgVarias
        '
        Me.tpgVarias.Controls.Add(Me.Panel2)
        Me.tpgVarias.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgVarias.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgVarias.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgVarias.Location = New System.Drawing.Point(1, 1)
        Me.tpgVarias.Name = "tpgVarias"
        Me.tpgVarias.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgVarias.Selected = False
        Me.tpgVarias.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgVarias.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgVarias.Size = New System.Drawing.Size(317, 151)
        Me.tpgVarias.TabIndex = 4
        Me.tpgVarias.Title = "Datos"
        Me.tpgVarias.ToolTip = "Datos"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(317, 151)
        Me.Panel2.TabIndex = 1
        '
        'pnlPanel1
        '
        Me.pnlPanel1.Controls.Add(Me.c1grdFacturas)
        Me.pnlPanel1.Controls.Add(Me.bnavRelacionados)
        Me.pnlPanel1.Controls.Add(Me.AcPanelCaption3)
        Me.pnlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.pnlPanel1.Name = "pnlPanel1"
        Me.pnlPanel1.Size = New System.Drawing.Size(317, 151)
        Me.pnlPanel1.TabIndex = 0
        '
        'c1grdFacturas
        '
        Me.c1grdFacturas.ColumnInfo = "2,1,0,0,0,95,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdFacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdFacturas.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdFacturas.Location = New System.Drawing.Point(0, 20)
        Me.c1grdFacturas.Name = "c1grdFacturas"
        Me.c1grdFacturas.Rows.Count = 2
        Me.c1grdFacturas.Rows.DefaultSize = 19
        Me.c1grdFacturas.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.c1grdFacturas.Size = New System.Drawing.Size(317, 106)
        Me.c1grdFacturas.StyleInfo = resources.GetString("c1grdFacturas.StyleInfo")
        Me.c1grdFacturas.TabIndex = 1
        '
        'bnavRelacionados
        '
        Me.bnavRelacionados.AddNewItem = Nothing
        Me.bnavRelacionados.CountItem = Me.ToolStripLabel3
        Me.bnavRelacionados.DeleteItem = Nothing
        Me.bnavRelacionados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavRelacionados.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton9, Me.ToolStripButton10, Me.ToolStripSeparator5, Me.ToolStripTextBox2, Me.ToolStripLabel3, Me.ToolStripSeparator6, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator7, Me.tsbtnAgregar, Me.ToolStripSeparator8, Me.tsbtnQuitar, Me.ToolStripSeparator9})
        Me.bnavRelacionados.Location = New System.Drawing.Point(0, 126)
        Me.bnavRelacionados.MoveFirstItem = Me.ToolStripButton9
        Me.bnavRelacionados.MoveLastItem = Me.ToolStripButton12
        Me.bnavRelacionados.MoveNextItem = Me.ToolStripButton11
        Me.bnavRelacionados.MovePreviousItem = Me.ToolStripButton10
        Me.bnavRelacionados.Name = "bnavRelacionados"
        Me.bnavRelacionados.PositionItem = Me.ToolStripTextBox2
        Me.bnavRelacionados.Size = New System.Drawing.Size(317, 25)
        Me.bnavRelacionados.TabIndex = 2
        Me.bnavRelacionados.Text = "BindingNavigator1"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel3.Text = "of {0}"
        Me.ToolStripLabel3.ToolTipText = "Total number of items"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton9.Text = "Move first"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton10.Text = "Move previous"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.AccessibleName = "Position"
        Me.ToolStripTextBox2.AutoSize = False
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox2.Text = "0"
        Me.ToolStripTextBox2.ToolTipText = "Current position"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton11.Text = "Move next"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton12.Text = "Move last"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnAgregar
        '
        Me.tsbtnAgregar.Image = CType(resources.GetObject("tsbtnAgregar.Image"), System.Drawing.Image)
        Me.tsbtnAgregar.Name = "tsbtnAgregar"
        Me.tsbtnAgregar.RightToLeftAutoMirrorImage = True
        Me.tsbtnAgregar.Size = New System.Drawing.Size(69, 22)
        Me.tsbtnAgregar.Text = "Agregar"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnQuitar
        '
        Me.tsbtnQuitar.Image = CType(resources.GetObject("tsbtnQuitar.Image"), System.Drawing.Image)
        Me.tsbtnQuitar.Name = "tsbtnQuitar"
        Me.tsbtnQuitar.RightToLeftAutoMirrorImage = True
        Me.tsbtnQuitar.Size = New System.Drawing.Size(60, 20)
        Me.tsbtnQuitar.Text = "Quitar"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption3
        '
        Me.AcPanelCaption3.ACCaption = "Documentos Relacionados"
        Me.AcPanelCaption3.ActiveGradientHighColor = System.Drawing.Color.Red
        Me.AcPanelCaption3.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AcPanelCaption3.ActiveTextColor = System.Drawing.Color.White
        Me.AcPanelCaption3.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption3.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.AcPanelCaption3.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption3.Name = "AcPanelCaption3"
        Me.AcPanelCaption3.Size = New System.Drawing.Size(317, 20)
        Me.AcPanelCaption3.TabIndex = 0
        '
        'tpgUnico
        '
        Me.tpgUnico.Controls.Add(Me.AcPanelCaption1)
        Me.tpgUnico.Controls.Add(Me.lblFecha)
        Me.tpgUnico.Controls.Add(Me.actxaNroDocumento)
        Me.tpgUnico.Controls.Add(Me.Label6)
        Me.tpgUnico.Controls.Add(Me.cmbRefDocumento)
        Me.tpgUnico.Controls.Add(Me.cmbRefSerie)
        Me.tpgUnico.Controls.Add(Me.lblRefNroDocumento)
        Me.tpgUnico.Controls.Add(Me.Label13)
        Me.tpgUnico.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgUnico.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgUnico.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgUnico.Location = New System.Drawing.Point(1, 1)
        Me.tpgUnico.Name = "tpgUnico"
        Me.tpgUnico.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgUnico.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgUnico.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgUnico.Size = New System.Drawing.Size(317, 151)
        Me.tpgUnico.TabIndex = 5
        Me.tpgUnico.Title = "Busqueda"
        Me.tpgUnico.ToolTip = "Busqueda"
        '
        'AcPanelCaption1
        '
        Me.AcPanelCaption1.ACCaption = "Documento Relacionado"
        Me.AcPanelCaption1.ActiveGradientHighColor = System.Drawing.Color.Red
        Me.AcPanelCaption1.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AcPanelCaption1.ActiveTextColor = System.Drawing.Color.White
        Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption1.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption1.Name = "AcPanelCaption1"
        Me.AcPanelCaption1.Size = New System.Drawing.Size(317, 20)
        Me.AcPanelCaption1.TabIndex = 14
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(206, 65)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(47, 15)
        Me.lblFecha.TabIndex = 13
        Me.lblFecha.Text = "Fecha : "
        '
        'actxaNroDocumento
        '
        Me.actxaNroDocumento.ACActivarAyudaAuto = False
        Me.actxaNroDocumento.ACLongitudAceptada = 0
        Me.actxaNroDocumento.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.Numerico
        Me.actxaNroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaNroDocumento.Location = New System.Drawing.Point(125, 91)
        Me.actxaNroDocumento.MaxLength = 8
        Me.actxaNroDocumento.Name = "actxaNroDocumento"
        Me.actxaNroDocumento.Size = New System.Drawing.Size(122, 23)
        Me.actxaNroDocumento.TabIndex = 12
        Me.actxaNroDocumento.Tag = "EVO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Tipo Documento :"
        '
        'cmbRefDocumento
        '
        Me.cmbRefDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRefDocumento.FormattingEnabled = True
        Me.cmbRefDocumento.Items.AddRange(New Object() {"Boleta", "Factura"})
        Me.cmbRefDocumento.Location = New System.Drawing.Point(124, 33)
        Me.cmbRefDocumento.Name = "cmbRefDocumento"
        Me.cmbRefDocumento.Size = New System.Drawing.Size(215, 23)
        Me.cmbRefDocumento.TabIndex = 8
        Me.cmbRefDocumento.Tag = "ECO"
        '
        'cmbRefSerie
        '
        Me.cmbRefSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRefSerie.FormattingEnabled = True
        Me.cmbRefSerie.Location = New System.Drawing.Point(125, 61)
        Me.cmbRefSerie.Name = "cmbRefSerie"
        Me.cmbRefSerie.Size = New System.Drawing.Size(69, 23)
        Me.cmbRefSerie.TabIndex = 10
        Me.cmbRefSerie.Tag = "ECO"
        '
        'lblRefNroDocumento
        '
        Me.lblRefNroDocumento.AutoSize = True
        Me.lblRefNroDocumento.Location = New System.Drawing.Point(65, 96)
        Me.lblRefNroDocumento.Name = "lblRefNroDocumento"
        Me.lblRefNroDocumento.Size = New System.Drawing.Size(57, 15)
        Me.lblRefNroDocumento.TabIndex = 11
        Me.lblRefNroDocumento.Text = "Numero :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(84, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 15)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Serie :"
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Controls.Add(Me.c1grdDetalle)
        Me.pnlDetalle.Controls.Add(Me.pnlItem)
        Me.pnlDetalle.Controls.Add(Me.bnavProductos)
        Me.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetalle.Location = New System.Drawing.Point(0, 0)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(882, 186)
        Me.pnlDetalle.TabIndex = 1
        '
        'c1grdDetalle
        '
        Me.c1grdDetalle.BackColor = System.Drawing.Color.White
        Me.c1grdDetalle.ColumnInfo = resources.GetString("c1grdDetalle.ColumnInfo")
        Me.c1grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdDetalle.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdDetalle.Location = New System.Drawing.Point(0, 47)
        Me.c1grdDetalle.Name = "c1grdDetalle"
        Me.c1grdDetalle.Rows.Count = 2
        Me.c1grdDetalle.Rows.DefaultSize = 21
        Me.c1grdDetalle.Size = New System.Drawing.Size(882, 114)
        Me.c1grdDetalle.StyleInfo = resources.GetString("c1grdDetalle.StyleInfo")
        Me.c1grdDetalle.TabIndex = 1
        '
        'pnlItem
        '
        Me.pnlItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.pnlItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlItem.Controls.Add(Me.actxnPrecio)
        Me.pnlItem.Controls.Add(Me.Label2)
        Me.pnlItem.Controls.Add(Me.txtProdUnidad)
        Me.pnlItem.Controls.Add(Me.actxnSubImporte)
        Me.pnlItem.Controls.Add(Me.actxnProdCantidad)
        Me.pnlItem.Controls.Add(Me.Label10)
        Me.pnlItem.Controls.Add(Me.Label9)
        Me.pnlItem.Controls.Add(Me.Label14)
        Me.pnlItem.Controls.Add(Me.txtProdDescripcion)
        Me.pnlItem.Controls.Add(Me.lblDescripcion)
        Me.pnlItem.Controls.Add(Me.lblCodigo)
        Me.pnlItem.Controls.Add(Me.actxaProdCodigo)
        Me.pnlItem.Controls.Add(Me.txtOpcion)
        Me.pnlItem.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlItem.Location = New System.Drawing.Point(0, 0)
        Me.pnlItem.Name = "pnlItem"
        Me.pnlItem.Size = New System.Drawing.Size(882, 47)
        Me.pnlItem.TabIndex = 0
        '
        'actxnPrecio
        '
        Me.actxnPrecio.ACDecimales = 4
        Me.actxnPrecio.ACEnteros = 9
        Me.actxnPrecio.ACFormato = "#,###,##,##0.0000"
        Me.actxnPrecio.ACNegativo = True
        Me.actxnPrecio.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnPrecio.Location = New System.Drawing.Point(634, 17)
        Me.actxnPrecio.MaxLength = 12
        Me.actxnPrecio.Name = "actxnPrecio"
        Me.actxnPrecio.Size = New System.Drawing.Size(104, 23)
        Me.actxnPrecio.TabIndex = 9
        Me.actxnPrecio.Tag = "EV"
        Me.actxnPrecio.Text = "0.0000"
        Me.actxnPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(465, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Unidad"
        '
        'txtProdUnidad
        '
        Me.txtProdUnidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProdUnidad.BackColor = System.Drawing.Color.Gainsboro
        Me.txtProdUnidad.Location = New System.Drawing.Point(460, 17)
        Me.txtProdUnidad.MaxLength = 1
        Me.txtProdUnidad.Name = "txtProdUnidad"
        Me.txtProdUnidad.Size = New System.Drawing.Size(60, 23)
        Me.txtProdUnidad.TabIndex = 5
        '
        'actxnSubImporte
        '
        Me.actxnSubImporte.ACDecimales = 4
        Me.actxnSubImporte.ACEnteros = 9
        Me.actxnSubImporte.ACFormato = "#,###,##,##0.0000"
        Me.actxnSubImporte.ACNegativo = True
        Me.actxnSubImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnSubImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnSubImporte.Location = New System.Drawing.Point(740, 17)
        Me.actxnSubImporte.MaxLength = 12
        Me.actxnSubImporte.Name = "actxnSubImporte"
        Me.actxnSubImporte.ReadOnly = True
        Me.actxnSubImporte.Size = New System.Drawing.Size(100, 23)
        Me.actxnSubImporte.TabIndex = 11
        Me.actxnSubImporte.Tag = "V"
        Me.actxnSubImporte.Text = "0.0000"
        Me.actxnSubImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnProdCantidad
        '
        Me.actxnProdCantidad.ACEnteros = 9
        Me.actxnProdCantidad.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnProdCantidad.ACNegativo = True
        Me.actxnProdCantidad.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnProdCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnProdCantidad.Location = New System.Drawing.Point(522, 17)
        Me.actxnProdCantidad.MaxLength = 12
        Me.actxnProdCantidad.Name = "actxnProdCantidad"
        Me.actxnProdCantidad.Size = New System.Drawing.Size(110, 23)
        Me.actxnProdCantidad.TabIndex = 7
        Me.actxnProdCantidad.Tag = "EV"
        Me.actxnProdCantidad.Text = "0.00"
        Me.actxnProdCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(749, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Sub Importe"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(641, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Pr&ecio"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(527, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "C&antidad"
        '
        'txtProdDescripcion
        '
        Me.txtProdDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProdDescripcion.Location = New System.Drawing.Point(133, 17)
        Me.txtProdDescripcion.Name = "txtProdDescripcion"
        Me.txtProdDescripcion.ReadOnly = True
        Me.txtProdDescripcion.Size = New System.Drawing.Size(325, 23)
        Me.txtProdDescripcion.TabIndex = 3
        Me.txtProdDescripcion.Tag = "V"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.White
        Me.lblDescripcion.Location = New System.Drawing.Point(139, 2)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(72, 13)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.Text = "Descripcion"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblCodigo.ForeColor = System.Drawing.Color.White
        Me.lblCodigo.Location = New System.Drawing.Point(28, 2)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(45, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "C&odigo"
        '
        'actxaProdCodigo
        '
        Me.actxaProdCodigo.ACActivarAyudaAuto = False
        Me.actxaProdCodigo.ACLongitudAceptada = 0
        Me.actxaProdCodigo.Location = New System.Drawing.Point(21, 17)
        Me.actxaProdCodigo.MaxLength = 32767
        Me.actxaProdCodigo.Name = "actxaProdCodigo"
        Me.actxaProdCodigo.Size = New System.Drawing.Size(110, 23)
        Me.actxaProdCodigo.TabIndex = 1
        Me.actxaProdCodigo.Tag = "EV"
        '
        'txtOpcion
        '
        Me.txtOpcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOpcion.BackColor = System.Drawing.Color.Gainsboro
        Me.txtOpcion.Location = New System.Drawing.Point(842, 17)
        Me.txtOpcion.MaxLength = 1
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.Size = New System.Drawing.Size(25, 23)
        Me.txtOpcion.TabIndex = 21
        '
        'bnavProductos
        '
        Me.bnavProductos.AddNewItem = Me.ToolStripButton1
        Me.bnavProductos.CountItem = Me.ToolStripLabel1
        Me.bnavProductos.DeleteItem = Me.ToolStripButton2
        Me.bnavProductos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavProductos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2, Me.tslblSon, Me.tscmbImpresora, Me.ToolStripLabel2, Me.ToolStripSeparator4})
        Me.bnavProductos.Location = New System.Drawing.Point(0, 161)
        Me.bnavProductos.MoveFirstItem = Me.ToolStripButton3
        Me.bnavProductos.MoveLastItem = Me.ToolStripButton6
        Me.bnavProductos.MoveNextItem = Me.ToolStripButton5
        Me.bnavProductos.MovePreviousItem = Me.ToolStripButton4
        Me.bnavProductos.Name = "bnavProductos"
        Me.bnavProductos.PositionItem = Me.ToolStripTextBox1
        Me.bnavProductos.Size = New System.Drawing.Size(882, 25)
        Me.bnavProductos.TabIndex = 2
        Me.bnavProductos.Text = "BindingNavigator1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Add new"
        Me.ToolStripButton1.Visible = False
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "of {0}"
        Me.ToolStripLabel1.ToolTipText = "Total number of items"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Delete"
        Me.ToolStripButton2.Visible = False
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Move first"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Move previous"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Position"
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Current position"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Move next"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Move last"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tslblSon
        '
        Me.tslblSon.Name = "tslblSon"
        Me.tslblSon.Size = New System.Drawing.Size(47, 22)
        Me.tslblSon.Text = "Son: {0}"
        '
        'tscmbImpresora
        '
        Me.tscmbImpresora.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tscmbImpresora.Name = "tscmbImpresora"
        Me.tscmbImpresora.Size = New System.Drawing.Size(300, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripLabel2.Text = "Impresora :"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.lblImporte)
        Me.pnlPie.Controls.Add(Me.lblTotalPagar)
        Me.pnlPie.Controls.Add(Me.lbligv)
        Me.pnlPie.Controls.Add(Me.actxnImporte)
        Me.pnlPie.Controls.Add(Me.actxnIGV)
        Me.pnlPie.Controls.Add(Me.chkDescuento)
        Me.pnlPie.Controls.Add(Me.actxnTotalPagar)
        Me.pnlPie.Controls.Add(Me.chkAnulada)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.ForeColor = System.Drawing.Color.White
        Me.pnlPie.Location = New System.Drawing.Point(0, 405)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(882, 36)
        Me.pnlPie.TabIndex = 2
        '
        'lblImporte
        '
        Me.lblImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblImporte.ForeColor = System.Drawing.Color.White
        Me.lblImporte.Location = New System.Drawing.Point(303, 9)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(86, 17)
        Me.lblImporte.TabIndex = 1
        Me.lblImporte.Text = "Importe : {0}"
        '
        'lblTotalPagar
        '
        Me.lblTotalPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPagar.AutoSize = True
        Me.lblTotalPagar.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblTotalPagar.ForeColor = System.Drawing.Color.White
        Me.lblTotalPagar.Location = New System.Drawing.Point(670, 9)
        Me.lblTotalPagar.Name = "lblTotalPagar"
        Me.lblTotalPagar.Size = New System.Drawing.Size(108, 17)
        Me.lblTotalPagar.TabIndex = 5
        Me.lblTotalPagar.Text = "Total Pagar : {0}"
        '
        'lbligv
        '
        Me.lbligv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbligv.AutoSize = True
        Me.lbligv.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lbligv.ForeColor = System.Drawing.Color.White
        Me.lbligv.Location = New System.Drawing.Point(494, 9)
        Me.lbligv.Name = "lbligv"
        Me.lbligv.Size = New System.Drawing.Size(71, 17)
        Me.lbligv.TabIndex = 3
        Me.lbligv.Text = "I.G.V. : {0}"
        '
        'actxnImporte
        '
        Me.actxnImporte.ACEnteros = 9
        Me.actxnImporte.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnImporte.ACNegativo = True
        Me.actxnImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnImporte.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxnImporte.Location = New System.Drawing.Point(400, 4)
        Me.actxnImporte.MaxLength = 12
        Me.actxnImporte.Name = "actxnImporte"
        Me.actxnImporte.ReadOnly = True
        Me.actxnImporte.Size = New System.Drawing.Size(85, 26)
        Me.actxnImporte.TabIndex = 2
        Me.actxnImporte.Tag = "EVO"
        Me.actxnImporte.Text = "0.00"
        Me.actxnImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnIGV
        '
        Me.actxnIGV.ACEnteros = 9
        Me.actxnIGV.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnIGV.ACNegativo = True
        Me.actxnIGV.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnIGV.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxnIGV.Location = New System.Drawing.Point(576, 4)
        Me.actxnIGV.MaxLength = 12
        Me.actxnIGV.Name = "actxnIGV"
        Me.actxnIGV.ReadOnly = True
        Me.actxnIGV.Size = New System.Drawing.Size(85, 26)
        Me.actxnIGV.TabIndex = 4
        Me.actxnIGV.Tag = "EVO"
        Me.actxnIGV.Text = "0.00"
        Me.actxnIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkDescuento
        '
        Me.chkDescuento.AutoSize = True
        Me.chkDescuento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDescuento.Location = New System.Drawing.Point(12, 8)
        Me.chkDescuento.Name = "chkDescuento"
        Me.chkDescuento.Size = New System.Drawing.Size(169, 19)
        Me.chkDescuento.TabIndex = 13
        Me.chkDescuento.Text = "Descuento de Documentos"
        Me.chkDescuento.UseVisualStyleBackColor = True
        '
        'actxnTotalPagar
        '
        Me.actxnTotalPagar.ACEnteros = 9
        Me.actxnTotalPagar.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTotalPagar.ACNegativo = True
        Me.actxnTotalPagar.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTotalPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnTotalPagar.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxnTotalPagar.Location = New System.Drawing.Point(788, 4)
        Me.actxnTotalPagar.MaxLength = 12
        Me.actxnTotalPagar.Name = "actxnTotalPagar"
        Me.actxnTotalPagar.ReadOnly = True
        Me.actxnTotalPagar.Size = New System.Drawing.Size(85, 26)
        Me.actxnTotalPagar.TabIndex = 6
        Me.actxnTotalPagar.Tag = "EVO"
        Me.actxnTotalPagar.Text = "0.00"
        Me.actxnTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkAnulada
        '
        Me.chkAnulada.AutoSize = True
        Me.chkAnulada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAnulada.Location = New System.Drawing.Point(187, 8)
        Me.chkAnulada.Name = "chkAnulada"
        Me.chkAnulada.Size = New System.Drawing.Size(70, 19)
        Me.chkAnulada.TabIndex = 14
        Me.chkAnulada.Text = "Anulada"
        Me.chkAnulada.UseVisualStyleBackColor = True
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlCabecera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCabecera.Controls.Add(Me.Label1)
        Me.pnlCabecera.Controls.Add(Me.Label11)
        Me.pnlCabecera.Controls.Add(Me.Label12)
        Me.pnlCabecera.Controls.Add(Me.cmbDocumentoFacturar)
        Me.pnlCabecera.Controls.Add(Me.actxnNumero)
        Me.pnlCabecera.Controls.Add(Me.cmbSerie)
        Me.pnlCabecera.Controls.Add(Me.lblFecTramite)
        Me.pnlCabecera.Controls.Add(Me.dtpFecTramite)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(882, 37)
        Me.pnlCabecera.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label1.Location = New System.Drawing.Point(213, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tipo Documento :"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label11.Location = New System.Drawing.Point(570, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 17)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Serie :"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label12.Location = New System.Drawing.Point(698, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 17)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Numero :"
        '
        'cmbDocumentoFacturar
        '
        Me.cmbDocumentoFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDocumentoFacturar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoFacturar.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.cmbDocumentoFacturar.FormattingEnabled = True
        Me.cmbDocumentoFacturar.Items.AddRange(New Object() {"Boleta", "Factura"})
        Me.cmbDocumentoFacturar.Location = New System.Drawing.Point(346, 4)
        Me.cmbDocumentoFacturar.Name = "cmbDocumentoFacturar"
        Me.cmbDocumentoFacturar.Size = New System.Drawing.Size(211, 27)
        Me.cmbDocumentoFacturar.TabIndex = 0
        Me.cmbDocumentoFacturar.Tag = "EO"
        '
        'actxnNumero
        '
        Me.actxnNumero.ACEnteros = 8
        Me.actxnNumero.ACFormato = "#######0"
        Me.actxnNumero.ACNegativo = True
        Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnNumero.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxnNumero.Location = New System.Drawing.Point(770, 4)
        Me.actxnNumero.MaxLength = 7
        Me.actxnNumero.Name = "actxnNumero"
        Me.actxnNumero.Size = New System.Drawing.Size(100, 26)
        Me.actxnNumero.TabIndex = 2
        Me.actxnNumero.Tag = "EVO"
        Me.actxnNumero.Text = "0"
        Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbSerie
        '
        Me.cmbSerie.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSerie.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.cmbSerie.FormattingEnabled = True
        Me.cmbSerie.Location = New System.Drawing.Point(625, 4)
        Me.cmbSerie.Name = "cmbSerie"
        Me.cmbSerie.Size = New System.Drawing.Size(60, 27)
        Me.cmbSerie.TabIndex = 1
        Me.cmbSerie.Tag = "EO"
        '
        'lblFecTramite
        '
        Me.lblFecTramite.AutoSize = True
        Me.lblFecTramite.Location = New System.Drawing.Point(5, 10)
        Me.lblFecTramite.Name = "lblFecTramite"
        Me.lblFecTramite.Size = New System.Drawing.Size(78, 15)
        Me.lblFecTramite.TabIndex = 0
        Me.lblFecTramite.Text = "Fec. Tramite :"
        '
        'dtpFecTramite
        '
        Me.dtpFecTramite.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecTramite.Location = New System.Drawing.Point(88, 6)
        Me.dtpFecTramite.Name = "dtpFecTramite"
        Me.dtpFecTramite.Size = New System.Drawing.Size(95, 23)
        Me.dtpFecTramite.TabIndex = 1
        Me.dtpFecTramite.Tag = "E"
        '
        'tabBusqueda
        '
        Me.tabBusqueda.Controls.Add(Me.c1grdBusqueda)
        Me.tabBusqueda.Controls.Add(Me.grpBusqueda)
        Me.tabBusqueda.Controls.Add(Me.bnavBusqueda)
        Me.tabBusqueda.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Location = New System.Drawing.Point(1, 1)
        Me.tabBusqueda.Name = "tabBusqueda"
        Me.tabBusqueda.SelectBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Selected = False
        Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Size = New System.Drawing.Size(882, 441)
        Me.tabBusqueda.TabIndex = 0
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'c1grdBusqueda
        '
        Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 95)
        Me.c1grdBusqueda.Name = "c1grdBusqueda"
        Me.c1grdBusqueda.Rows.Count = 2
        Me.c1grdBusqueda.Rows.DefaultSize = 20
        Me.c1grdBusqueda.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.c1grdBusqueda.Size = New System.Drawing.Size(882, 346)
        Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
        Me.c1grdBusqueda.TabIndex = 2
        '
        'grpBusqueda
        '
        Me.grpBusqueda.Controls.Add(Me.btnConsultar)
        Me.grpBusqueda.Controls.Add(Me.rbtnNroCotizacion)
        Me.grpBusqueda.Controls.Add(Me.rbtnCliente)
        Me.grpBusqueda.Controls.Add(Me.grpCliente)
        Me.grpBusqueda.Controls.Add(Me.grpDocumentos)
        Me.grpBusqueda.Controls.Add(Me.chkTodos)
        Me.grpBusqueda.Controls.Add(Me.AcFecha)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(882, 95)
        Me.grpBusqueda.TabIndex = 7
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(777, 47)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 42)
        Me.btnConsultar.TabIndex = 33
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'rbtnNroCotizacion
        '
        Me.rbtnNroCotizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnNroCotizacion.AutoSize = True
        Me.rbtnNroCotizacion.Location = New System.Drawing.Point(340, 43)
        Me.rbtnNroCotizacion.Name = "rbtnNroCotizacion"
        Me.rbtnNroCotizacion.Size = New System.Drawing.Size(88, 19)
        Me.rbtnNroCotizacion.TabIndex = 2
        Me.rbtnNroCotizacion.Text = "Documento"
        Me.rbtnNroCotizacion.UseVisualStyleBackColor = True
        '
        'rbtnCliente
        '
        Me.rbtnCliente.AutoSize = True
        Me.rbtnCliente.Checked = True
        Me.rbtnCliente.Location = New System.Drawing.Point(19, 43)
        Me.rbtnCliente.Name = "rbtnCliente"
        Me.rbtnCliente.Size = New System.Drawing.Size(62, 19)
        Me.rbtnCliente.TabIndex = 1
        Me.rbtnCliente.TabStop = True
        Me.rbtnCliente.Text = "Cliente"
        Me.rbtnCliente.UseVisualStyleBackColor = True
        '
        'grpCliente
        '
        Me.grpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCliente.Controls.Add(Me.txtBusqueda)
        Me.grpCliente.Location = New System.Drawing.Point(6, 46)
        Me.grpCliente.Name = "grpCliente"
        Me.grpCliente.Size = New System.Drawing.Size(324, 42)
        Me.grpCliente.TabIndex = 7
        Me.grpCliente.TabStop = False
        '
        'txtBusqueda
        '
        Me.txtBusqueda.ACActivarAyudaAuto = False
        Me.txtBusqueda.ACLongitudAceptada = 0
        Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda.Location = New System.Drawing.Point(9, 16)
        Me.txtBusqueda.MaxLength = 32767
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(305, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'grpDocumentos
        '
        Me.grpDocumentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDocumentos.Controls.Add(Me.cmbTipoDocumento)
        Me.grpDocumentos.Controls.Add(Me.ComboBox2)
        Me.grpDocumentos.Controls.Add(Me.txtBusNumero)
        Me.grpDocumentos.Location = New System.Drawing.Point(336, 47)
        Me.grpDocumentos.Name = "grpDocumentos"
        Me.grpDocumentos.Size = New System.Drawing.Size(334, 42)
        Me.grpDocumentos.TabIndex = 5
        Me.grpDocumentos.TabStop = False
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(10, 15)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(151, 23)
        Me.cmbTipoDocumento.TabIndex = 8
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(167, 15)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(51, 23)
        Me.ComboBox2.TabIndex = 6
        '
        'txtBusNumero
        '
        Me.txtBusNumero.ACActivarAyudaAuto = False
        Me.txtBusNumero.ACLongitudAceptada = 0
        Me.txtBusNumero.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.Numerico
        Me.txtBusNumero.Location = New System.Drawing.Point(224, 15)
        Me.txtBusNumero.MaxLength = 32767
        Me.txtBusNumero.Name = "txtBusNumero"
        Me.txtBusNumero.Size = New System.Drawing.Size(100, 23)
        Me.txtBusNumero.TabIndex = 7
        '
        'chkTodos
        '
        Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(673, 52)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(103, 19)
        Me.chkTodos.TabIndex = 4
        Me.chkTodos.Text = "Mostrar Todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'AcFecha
        '
        Me.AcFecha.ACFecha_A = New Date(2016, 4, 12, 8, 35, 27, 331)
        Me.AcFecha.ACFecha_De = New Date(2016, 4, 12, 8, 35, 27, 330)
        Me.AcFecha.ACFechaObligatoria = True
        Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
        Me.AcFecha.ACHoyChecked = False
        Me.AcFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AcFecha.Location = New System.Drawing.Point(545, 0)
        Me.AcFecha.MaximumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.MinimumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.Name = "AcFecha"
        Me.AcFecha.Size = New System.Drawing.Size(337, 43)
        Me.AcFecha.TabIndex = 3
        Me.AcFecha.TabStop = False
        '
        'bnavBusqueda
        '
        Me.bnavBusqueda.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.bnavBusqueda.CountItem = Me.BindingNavigatorCountItem
        Me.bnavBusqueda.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 97)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(960, 25)
        Me.bnavBusqueda.TabIndex = 3
        Me.bnavBusqueda.Text = "BindingNavigator1"
        Me.bnavBusqueda.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        Me.BindingNavigatorAddNewItem.Visible = False
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        Me.BindingNavigatorDeleteItem.Visible = False
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TNotasCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(884, 562)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.ACPanel)
        Me.Controls.Add(Me.acTool)
        Me.Name = "TNotasCredito"
        Me.Text = "Facturación de Notas {0} - División de Transportes"
        Me.acTool.ResumeLayout(False)
        Me.acTool.PerformLayout()
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.SContenedor.Panel1.ResumeLayout(False)
        Me.SContenedor.Panel2.ResumeLayout(False)
        CType(Me.SContenedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SContenedor.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        Me.pnlCuerpo.PerformLayout()
        Me.tabRelacionados.ResumeLayout(False)
        Me.tpgVarias.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlPanel1.ResumeLayout(False)
        Me.pnlPanel1.PerformLayout()
        CType(Me.c1grdFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavRelacionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavRelacionados.ResumeLayout(False)
        Me.bnavRelacionados.PerformLayout()
        Me.tpgUnico.ResumeLayout(False)
        Me.tpgUnico.PerformLayout()
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlDetalle.PerformLayout()
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlItem.ResumeLayout(False)
        Me.pnlItem.PerformLayout()
        CType(Me.bnavProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavProductos.ResumeLayout(False)
        Me.bnavProductos.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.tabBusqueda.ResumeLayout(False)
        Me.tabBusqueda.PerformLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBusqueda.ResumeLayout(False)
        Me.grpBusqueda.PerformLayout()
        Me.grpCliente.ResumeLayout(False)
        Me.grpCliente.PerformLayout()
        Me.grpDocumentos.ResumeLayout(False)
        Me.grpDocumentos.PerformLayout()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavBusqueda.ResumeLayout(False)
        Me.bnavBusqueda.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Friend WithEvents ACPanel As ACControles.ACPanelCaption
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents actsbtnPrevisualizar As ACControles.ACToolStripButton
   Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents pnlDatos As System.Windows.Forms.Panel
   Friend WithEvents SContenedor As System.Windows.Forms.SplitContainer
   Friend WithEvents pnlPanel1 As System.Windows.Forms.Panel
   Friend WithEvents c1grdFacturas As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavRelacionados As System.Windows.Forms.BindingNavigator
   Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbtnAgregar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbtnQuitar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents AcPanelCaption3 As ACControles.ACPanelCaption
   Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
   Friend WithEvents cmbMotivo As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
   Friend WithEvents c1grdDetalle As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents pnlItem As System.Windows.Forms.Panel
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtProdUnidad As System.Windows.Forms.TextBox
   Friend WithEvents actxnSubImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnProdCantidad As ACControles.ACTextBoxNumerico
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents txtProdDescripcion As System.Windows.Forms.TextBox
   Friend WithEvents lblDescripcion As System.Windows.Forms.Label
   Friend WithEvents lblCodigo As System.Windows.Forms.Label
   Friend WithEvents actxaProdCodigo As ACControles.ACTextBoxAyuda
   Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
   Friend WithEvents bnavProductos As System.Windows.Forms.BindingNavigator
   Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tslblSon As System.Windows.Forms.ToolStripLabel
   Friend WithEvents tscmbImpresora As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents pnlPie As System.Windows.Forms.Panel
   Friend WithEvents lblImporte As System.Windows.Forms.Label
   Friend WithEvents lblTotalPagar As System.Windows.Forms.Label
   Friend WithEvents lbligv As System.Windows.Forms.Label
   Friend WithEvents actxnImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnIGV As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnTotalPagar As ACControles.ACTextBoxNumerico
   Friend WithEvents cmbDocumentoFacturar As System.Windows.Forms.ComboBox
   Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
   Friend WithEvents cmbSerie As System.Windows.Forms.ComboBox
   Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
   Friend WithEvents chkAnulada As System.Windows.Forms.CheckBox
   Friend WithEvents chkDescuento As System.Windows.Forms.CheckBox
   Friend WithEvents dtpFecFacturacion As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents btnNuevoCliente As System.Windows.Forms.Button
   Friend WithEvents btnClean As System.Windows.Forms.Button
   Friend WithEvents actxaCliRazonSocial As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaCliRuc As ACControles.ACTextBoxAyuda
   Friend WithEvents lblMoneda As System.Windows.Forms.Label
   Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents lblNroDocumento As System.Windows.Forms.Label
   Friend WithEvents actxnTipoCambioSunat As ACControles.ACTextBoxNumerico
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents actxnTipoCambio As ACControles.ACTextBoxNumerico
   Friend WithEvents Label31 As System.Windows.Forms.Label
   Friend WithEvents dtpFecTramite As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblFecTramite As System.Windows.Forms.Label
   Private WithEvents tabBusqueda As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents c1grdBusqueda As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavBusqueda As System.Windows.Forms.BindingNavigator
   Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
   Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents tabRelacionados As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents tpgVarias As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Private WithEvents tpgUnico As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents lblFecha As System.Windows.Forms.Label
   Friend WithEvents actxaNroDocumento As ACControles.ACTextBoxAyuda
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmbRefDocumento As System.Windows.Forms.ComboBox
   Friend WithEvents cmbRefSerie As System.Windows.Forms.ComboBox
   Friend WithEvents lblRefNroDocumento As System.Windows.Forms.Label
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Private WithEvents grpBusqueda As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As System.Windows.Forms.Button
   Friend WithEvents rbtnNroCotizacion As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnCliente As System.Windows.Forms.RadioButton
   Friend WithEvents grpCliente As System.Windows.Forms.GroupBox
   Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
   Friend WithEvents grpDocumentos As System.Windows.Forms.GroupBox
   Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
   Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
   Friend WithEvents txtBusNumero As ACControles.ACTextBoxAyuda
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Friend WithEvents chkIlncluidoIGV As System.Windows.Forms.CheckBox
   Friend WithEvents actxnPrecio As ACControles.ACTextBoxNumerico
   Friend WithEvents pnlCuerpo As System.Windows.Forms.Panel
   Friend WithEvents actsbtnModFecha As ACControles.ACToolStripButton
   Friend WithEvents cmbDirecciones As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
End Class
