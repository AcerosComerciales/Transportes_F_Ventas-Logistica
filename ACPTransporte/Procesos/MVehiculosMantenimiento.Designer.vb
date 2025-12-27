<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MVehiculosMantenimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MVehiculosMantenimiento))
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.IngresoFac = New System.Windows.Forms.TabPage()
        Me.bnavProductos = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton17 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton18 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.c1grdDetalle = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pnlItem = New System.Windows.Forms.Panel()
        Me.chkPrecIGV = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.actxnPrecIGV = New ACControles.ACTextBoxNumerico()
        Me.actxaDescripcion = New ACControles.ACTextBoxAyuda()
        Me.actxnDescuento = New ACControles.ACTextBoxNumerico()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.actxnPrecio = New ACControles.ACTextBoxNumerico()
        Me.txtOpcion = New System.Windows.Forms.TextBox()
        Me.actxnSubImporte = New ACControles.ACTextBoxNumerico()
        Me.actxnProdCantidad = New ACControles.ACTextBoxNumerico()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.actxnImporte = New ACControles.ACTextBoxNumerico()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lblTotalPagar = New System.Windows.Forms.Label()
        Me.lbligv = New System.Windows.Forms.Label()
        Me.actxnTotalPagar = New ACControles.ACTextBoxNumerico()
        Me.actxnIGV = New ACControles.ACTextBoxNumerico()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.dtpFecIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkIncluidoIGV = New System.Windows.Forms.CheckBox()
        Me.btnNueTransportista = New System.Windows.Forms.Button()
        Me.AcTextBoxAyuda1 = New ACControles.ACTextBoxAyuda()
        Me.actxaNroDocProveedor_2 = New ACControles.ACTextBoxAyuda()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.actxnNumero = New ACControles.ACTextBoxNumerico()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.cmbDocumento = New System.Windows.Forms.ComboBox()
        Me.dtpFecEmision = New System.Windows.Forms.DateTimePicker()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tpgFacturas = New System.Windows.Forms.TabPage()
        Me.c1grdFacturas = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavFacturas = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tspFacturas = New System.Windows.Forms.ToolStrip()
        Me.tsbtnAgregarFacturas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnQuitarFacturas = New System.Windows.Forms.ToolStripButton()
        Me.tpgRepuestos = New System.Windows.Forms.TabPage()
        Me.spcBase = New System.Windows.Forms.SplitContainer()
        Me.c1grdDetalle_piezas = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavDetalle = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.tool = New System.Windows.Forms.ToolStrip()
        Me.tsbtnAgregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnQuitar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnModificarPieza = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlVehiculo = New System.Windows.Forms.Panel()
        Me.txtVehiDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVehicPlaca = New System.Windows.Forms.TextBox()
        Me.dtpFecMantenimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbManTipoMantenimiento = New System.Windows.Forms.ComboBox()
        Me.actxaNroDocProveedor = New ACControles.ACTextBoxAyuda()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.actxnManKilometraje = New ACControles.ACTextBoxNumerico()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtManObservacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.actxaDescProveedor = New ACControles.ACTextBoxAyuda()
        Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.c1grdBusqueda = New C1.Win.C1FlexGrid.C1FlexGrid()
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
        Me.grpBusqueda = New System.Windows.Forms.GroupBox()
        Me.AcFecha = New ACControles.ACFecha(Me.components)
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.rbtnPlaca = New System.Windows.Forms.RadioButton()
        Me.rbtnCodigo = New System.Windows.Forms.RadioButton()
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.acbtnSeleccionar = New ACControles.ACToolStripButton(Me.components)
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.IngresoFac.SuspendLayout()
        CType(Me.bnavProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavProductos.SuspendLayout()
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlItem.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.tpgFacturas.SuspendLayout()
        CType(Me.c1grdFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavFacturas.SuspendLayout()
        Me.tspFacturas.SuspendLayout()
        Me.tpgRepuestos.SuspendLayout()
        CType(Me.spcBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcBase.Panel1.SuspendLayout()
        Me.spcBase.Panel2.SuspendLayout()
        Me.spcBase.SuspendLayout()
        CType(Me.c1grdDetalle_piezas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavDetalle.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tool.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlVehiculo.SuspendLayout()
        Me.tabBusqueda.SuspendLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavBusqueda.SuspendLayout()
        Me.grpBusqueda.SuspendLayout()
        Me.acTool.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 30)
        Me.tabMantenimiento.MediaPlayerDockSides = False
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = False
        Me.tabMantenimiento.SelectedIndex = 0
        Me.tabMantenimiento.ShowDropSelect = False
        Me.tabMantenimiento.Size = New System.Drawing.Size(834, 567)
        Me.tabMantenimiento.TabIndex = 9
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
        Me.tabDatos.Size = New System.Drawing.Size(832, 542)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.TabControl1)
        Me.pnlDatos.Controls.Add(Me.AcPanelCaption1)
        Me.pnlDatos.Controls.Add(Me.Panel3)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(832, 542)
        Me.pnlDatos.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.IngresoFac)
        Me.TabControl1.Controls.Add(Me.tpgFacturas)
        Me.TabControl1.Controls.Add(Me.tpgRepuestos)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 203)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(832, 339)
        Me.TabControl1.TabIndex = 6
        '
        'IngresoFac
        '
        Me.IngresoFac.Controls.Add(Me.bnavProductos)
        Me.IngresoFac.Controls.Add(Me.c1grdDetalle)
        Me.IngresoFac.Controls.Add(Me.pnlItem)
        Me.IngresoFac.Controls.Add(Me.pnlPie)
        Me.IngresoFac.Controls.Add(Me.pnlCabecera)
        Me.IngresoFac.Location = New System.Drawing.Point(4, 24)
        Me.IngresoFac.Name = "IngresoFac"
        Me.IngresoFac.Size = New System.Drawing.Size(824, 311)
        Me.IngresoFac.TabIndex = 2
        Me.IngresoFac.Text = "IngresoFac"
        Me.IngresoFac.UseVisualStyleBackColor = True
        '
        'bnavProductos
        '
        Me.bnavProductos.AddNewItem = Me.ToolStripButton13
        Me.bnavProductos.CountItem = Me.ToolStripLabel3
        Me.bnavProductos.DeleteItem = Me.ToolStripButton14
        Me.bnavProductos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavProductos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton15, Me.ToolStripButton16, Me.ToolStripSeparator10, Me.ToolStripTextBox3, Me.ToolStripLabel3, Me.ToolStripSeparator11, Me.ToolStripButton17, Me.ToolStripButton18, Me.ToolStripSeparator12, Me.ToolStripButton13, Me.ToolStripButton14})
        Me.bnavProductos.Location = New System.Drawing.Point(0, 247)
        Me.bnavProductos.MoveFirstItem = Me.ToolStripButton15
        Me.bnavProductos.MoveLastItem = Me.ToolStripButton18
        Me.bnavProductos.MoveNextItem = Me.ToolStripButton17
        Me.bnavProductos.MovePreviousItem = Me.ToolStripButton16
        Me.bnavProductos.Name = "bnavProductos"
        Me.bnavProductos.PositionItem = Me.ToolStripTextBox3
        Me.bnavProductos.Size = New System.Drawing.Size(824, 25)
        Me.bnavProductos.TabIndex = 28
        Me.bnavProductos.Text = "BindingNavigator1"
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton13.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton13.Text = "Add new"
        Me.ToolStripButton13.Visible = False
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel3.Text = "de {0}"
        Me.ToolStripLabel3.ToolTipText = "Total number of items"
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.Image = CType(resources.GetObject("ToolStripButton14.Image"), System.Drawing.Image)
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton14.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton14.Text = "Delete"
        Me.ToolStripButton14.Visible = False
        '
        'ToolStripButton15
        '
        Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton15.Image = CType(resources.GetObject("ToolStripButton15.Image"), System.Drawing.Image)
        Me.ToolStripButton15.Name = "ToolStripButton15"
        Me.ToolStripButton15.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton15.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton15.Text = "Move first"
        '
        'ToolStripButton16
        '
        Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton16.Image = CType(resources.GetObject("ToolStripButton16.Image"), System.Drawing.Image)
        Me.ToolStripButton16.Name = "ToolStripButton16"
        Me.ToolStripButton16.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton16.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton16.Text = "Move previous"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.AccessibleName = "Position"
        Me.ToolStripTextBox3.AutoSize = False
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox3.Text = "0"
        Me.ToolStripTextBox3.ToolTipText = "Current position"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton17
        '
        Me.ToolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton17.Image = CType(resources.GetObject("ToolStripButton17.Image"), System.Drawing.Image)
        Me.ToolStripButton17.Name = "ToolStripButton17"
        Me.ToolStripButton17.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton17.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton17.Text = "Move next"
        '
        'ToolStripButton18
        '
        Me.ToolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton18.Image = CType(resources.GetObject("ToolStripButton18.Image"), System.Drawing.Image)
        Me.ToolStripButton18.Name = "ToolStripButton18"
        Me.ToolStripButton18.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton18.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton18.Text = "Move last"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'c1grdDetalle
        '
        Me.c1grdDetalle.BackColor = System.Drawing.Color.White
        Me.c1grdDetalle.ColumnInfo = "2,1,0,0,0,105,Columns:0{Width:18;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:107;Caption:""Codigo"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdDetalle.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdDetalle.Location = New System.Drawing.Point(0, 171)
        Me.c1grdDetalle.Name = "c1grdDetalle"
        Me.c1grdDetalle.Rows.Count = 2
        Me.c1grdDetalle.Rows.DefaultSize = 21
        Me.c1grdDetalle.Size = New System.Drawing.Size(824, 101)
        Me.c1grdDetalle.StyleInfo = resources.GetString("c1grdDetalle.StyleInfo")
        Me.c1grdDetalle.TabIndex = 27
        '
        'pnlItem
        '
        Me.pnlItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.pnlItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlItem.Controls.Add(Me.chkPrecIGV)
        Me.pnlItem.Controls.Add(Me.Label13)
        Me.pnlItem.Controls.Add(Me.actxnPrecIGV)
        Me.pnlItem.Controls.Add(Me.actxaDescripcion)
        Me.pnlItem.Controls.Add(Me.actxnDescuento)
        Me.pnlItem.Controls.Add(Me.Label14)
        Me.pnlItem.Controls.Add(Me.actxnPrecio)
        Me.pnlItem.Controls.Add(Me.txtOpcion)
        Me.pnlItem.Controls.Add(Me.actxnSubImporte)
        Me.pnlItem.Controls.Add(Me.actxnProdCantidad)
        Me.pnlItem.Controls.Add(Me.Label15)
        Me.pnlItem.Controls.Add(Me.Label16)
        Me.pnlItem.Controls.Add(Me.Label17)
        Me.pnlItem.Controls.Add(Me.Label18)
        Me.pnlItem.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlItem.Location = New System.Drawing.Point(0, 120)
        Me.pnlItem.Name = "pnlItem"
        Me.pnlItem.Size = New System.Drawing.Size(824, 51)
        Me.pnlItem.TabIndex = 5
        '
        'chkPrecIGV
        '
        Me.chkPrecIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPrecIGV.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPrecIGV.AutoSize = True
        Me.chkPrecIGV.Location = New System.Drawing.Point(500, 20)
        Me.chkPrecIGV.Name = "chkPrecIGV"
        Me.chkPrecIGV.Size = New System.Drawing.Size(35, 25)
        Me.chkPrecIGV.TabIndex = 8
        Me.chkPrecIGV.Text = "IGV"
        Me.chkPrecIGV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPrecIGV.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(542, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "P. + IGV"
        '
        'actxnPrecIGV
        '
        Me.actxnPrecIGV.ACEnteros = 9
        Me.actxnPrecIGV.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnPrecIGV.ACNegativo = True
        Me.actxnPrecIGV.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnPrecIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnPrecIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnPrecIGV.Location = New System.Drawing.Point(536, 21)
        Me.actxnPrecIGV.MaxLength = 12
        Me.actxnPrecIGV.Name = "actxnPrecIGV"
        Me.actxnPrecIGV.ReadOnly = True
        Me.actxnPrecIGV.Size = New System.Drawing.Size(75, 23)
        Me.actxnPrecIGV.TabIndex = 10
        Me.actxnPrecIGV.Tag = "V"
        Me.actxnPrecIGV.Text = "0.00"
        Me.actxnPrecIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxaDescripcion
        '
        Me.actxaDescripcion.ACActivarAyudaAuto = False
        Me.actxaDescripcion.ACLongitudAceptada = 0
        Me.actxaDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaDescripcion.Location = New System.Drawing.Point(3, 21)
        Me.actxaDescripcion.MaxLength = 250
        Me.actxaDescripcion.Name = "actxaDescripcion"
        Me.actxaDescripcion.Size = New System.Drawing.Size(339, 23)
        Me.actxaDescripcion.TabIndex = 3
        Me.actxaDescripcion.Tag = "EV"
        '
        'actxnDescuento
        '
        Me.actxnDescuento.ACEnteros = 9
        Me.actxnDescuento.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnDescuento.ACNegativo = True
        Me.actxnDescuento.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnDescuento.Location = New System.Drawing.Point(615, 21)
        Me.actxnDescuento.MaxLength = 12
        Me.actxnDescuento.Name = "actxnDescuento"
        Me.actxnDescuento.Size = New System.Drawing.Size(74, 23)
        Me.actxnDescuento.TabIndex = 12
        Me.actxnDescuento.Tag = "EV"
        Me.actxnDescuento.Text = "0.00"
        Me.actxnDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(622, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Descuento"
        '
        'actxnPrecio
        '
        Me.actxnPrecio.ACEnteros = 9
        Me.actxnPrecio.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnPrecio.ACNegativo = True
        Me.actxnPrecio.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnPrecio.Location = New System.Drawing.Point(420, 21)
        Me.actxnPrecio.MaxLength = 12
        Me.actxnPrecio.Name = "actxnPrecio"
        Me.actxnPrecio.Size = New System.Drawing.Size(78, 23)
        Me.actxnPrecio.TabIndex = 7
        Me.actxnPrecio.Tag = "EV"
        Me.actxnPrecio.Text = "0.00"
        Me.actxnPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOpcion
        '
        Me.txtOpcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOpcion.BackColor = System.Drawing.Color.Gainsboro
        Me.txtOpcion.Location = New System.Drawing.Point(791, 21)
        Me.txtOpcion.MaxLength = 1
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.Size = New System.Drawing.Size(25, 23)
        Me.txtOpcion.TabIndex = 15
        '
        'actxnSubImporte
        '
        Me.actxnSubImporte.ACEnteros = 9
        Me.actxnSubImporte.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnSubImporte.ACNegativo = True
        Me.actxnSubImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnSubImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnSubImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnSubImporte.Location = New System.Drawing.Point(691, 21)
        Me.actxnSubImporte.MaxLength = 12
        Me.actxnSubImporte.Name = "actxnSubImporte"
        Me.actxnSubImporte.ReadOnly = True
        Me.actxnSubImporte.Size = New System.Drawing.Size(97, 23)
        Me.actxnSubImporte.TabIndex = 14
        Me.actxnSubImporte.Tag = "V"
        Me.actxnSubImporte.Text = "0.00"
        Me.actxnSubImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnProdCantidad
        '
        Me.actxnProdCantidad.ACEnteros = 9
        Me.actxnProdCantidad.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnProdCantidad.ACNegativo = True
        Me.actxnProdCantidad.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnProdCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnProdCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnProdCantidad.Location = New System.Drawing.Point(344, 21)
        Me.actxnProdCantidad.MaxLength = 12
        Me.actxnProdCantidad.Name = "actxnProdCantidad"
        Me.actxnProdCantidad.Size = New System.Drawing.Size(74, 23)
        Me.actxnProdCantidad.TabIndex = 5
        Me.actxnProdCantidad.Tag = "EV"
        Me.actxnProdCantidad.Text = "0.00"
        Me.actxnProdCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(700, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Sub Importe"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(428, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Pr&ecio"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(349, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "C&antidad"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(125, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Descripcion"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.actxnImporte)
        Me.pnlPie.Controls.Add(Me.lblImporte)
        Me.pnlPie.Controls.Add(Me.lblTotalPagar)
        Me.pnlPie.Controls.Add(Me.lbligv)
        Me.pnlPie.Controls.Add(Me.actxnTotalPagar)
        Me.pnlPie.Controls.Add(Me.actxnIGV)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 272)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(824, 39)
        Me.pnlPie.TabIndex = 4
        '
        'actxnImporte
        '
        Me.actxnImporte.ACEnteros = 9
        Me.actxnImporte.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnImporte.ACNegativo = True
        Me.actxnImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnImporte.Location = New System.Drawing.Point(282, 7)
        Me.actxnImporte.MaxLength = 12
        Me.actxnImporte.Name = "actxnImporte"
        Me.actxnImporte.ReadOnly = True
        Me.actxnImporte.Size = New System.Drawing.Size(100, 23)
        Me.actxnImporte.TabIndex = 1
        Me.actxnImporte.Tag = "ENO"
        Me.actxnImporte.Text = "0.00"
        Me.actxnImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblImporte
        '
        Me.lblImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Location = New System.Drawing.Point(204, 11)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(72, 15)
        Me.lblImporte.TabIndex = 0
        Me.lblImporte.Text = "Importe : {0}"
        '
        'lblTotalPagar
        '
        Me.lblTotalPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPagar.AutoSize = True
        Me.lblTotalPagar.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblTotalPagar.Location = New System.Drawing.Point(580, 10)
        Me.lblTotalPagar.Name = "lblTotalPagar"
        Me.lblTotalPagar.Size = New System.Drawing.Size(107, 17)
        Me.lblTotalPagar.TabIndex = 8
        Me.lblTotalPagar.Text = "Total Pagar : {0}"
        '
        'lbligv
        '
        Me.lbligv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbligv.AutoSize = True
        Me.lbligv.Location = New System.Drawing.Point(396, 11)
        Me.lbligv.Name = "lbligv"
        Me.lbligv.Size = New System.Drawing.Size(57, 15)
        Me.lbligv.TabIndex = 2
        Me.lbligv.Text = "I.G.V. : {0}"
        '
        'actxnTotalPagar
        '
        Me.actxnTotalPagar.ACEnteros = 9
        Me.actxnTotalPagar.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTotalPagar.ACNegativo = True
        Me.actxnTotalPagar.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnTotalPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnTotalPagar.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxnTotalPagar.Location = New System.Drawing.Point(694, 5)
        Me.actxnTotalPagar.MaxLength = 12
        Me.actxnTotalPagar.Name = "actxnTotalPagar"
        Me.actxnTotalPagar.ReadOnly = True
        Me.actxnTotalPagar.Size = New System.Drawing.Size(125, 26)
        Me.actxnTotalPagar.TabIndex = 9
        Me.actxnTotalPagar.Tag = "ENO"
        Me.actxnTotalPagar.Text = "0.00"
        Me.actxnTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnIGV
        '
        Me.actxnIGV.ACEnteros = 9
        Me.actxnIGV.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnIGV.ACNegativo = True
        Me.actxnIGV.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnIGV.Location = New System.Drawing.Point(459, 7)
        Me.actxnIGV.MaxLength = 12
        Me.actxnIGV.Name = "actxnIGV"
        Me.actxnIGV.ReadOnly = True
        Me.actxnIGV.Size = New System.Drawing.Size(100, 23)
        Me.actxnIGV.TabIndex = 3
        Me.actxnIGV.Tag = "ENO"
        Me.actxnIGV.Text = "0.00"
        Me.actxnIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlCabecera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCabecera.Controls.Add(Me.dtpFecIngreso)
        Me.pnlCabecera.Controls.Add(Me.Label4)
        Me.pnlCabecera.Controls.Add(Me.chkIncluidoIGV)
        Me.pnlCabecera.Controls.Add(Me.btnNueTransportista)
        Me.pnlCabecera.Controls.Add(Me.AcTextBoxAyuda1)
        Me.pnlCabecera.Controls.Add(Me.actxaNroDocProveedor_2)
        Me.pnlCabecera.Controls.Add(Me.Label5)
        Me.pnlCabecera.Controls.Add(Me.txtSerie)
        Me.pnlCabecera.Controls.Add(Me.actxnNumero)
        Me.pnlCabecera.Controls.Add(Me.Label9)
        Me.pnlCabecera.Controls.Add(Me.Label10)
        Me.pnlCabecera.Controls.Add(Me.lblTipoDocumento)
        Me.pnlCabecera.Controls.Add(Me.cmbDocumento)
        Me.pnlCabecera.Controls.Add(Me.dtpFecEmision)
        Me.pnlCabecera.Controls.Add(Me.lblMoneda)
        Me.pnlCabecera.Controls.Add(Me.cmbMoneda)
        Me.pnlCabecera.Controls.Add(Me.Label12)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(824, 120)
        Me.pnlCabecera.TabIndex = 2
        '
        'dtpFecIngreso
        '
        Me.dtpFecIngreso.Enabled = False
        Me.dtpFecIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIngreso.Location = New System.Drawing.Point(298, 63)
        Me.dtpFecIngreso.Name = "dtpFecIngreso"
        Me.dtpFecIngreso.Size = New System.Drawing.Size(109, 23)
        Me.dtpFecIngreso.TabIndex = 8
        Me.dtpFecIngreso.Tag = "E"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha Ingreso :"
        '
        'chkIncluidoIGV
        '
        Me.chkIncluidoIGV.AutoSize = True
        Me.chkIncluidoIGV.Location = New System.Drawing.Point(661, 92)
        Me.chkIncluidoIGV.Name = "chkIncluidoIGV"
        Me.chkIncluidoIGV.Size = New System.Drawing.Size(99, 19)
        Me.chkIncluidoIGV.TabIndex = 15
        Me.chkIncluidoIGV.Text = "Incluido I.G.V."
        Me.chkIncluidoIGV.UseVisualStyleBackColor = True
        '
        'btnNueTransportista
        '
        Me.btnNueTransportista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNueTransportista.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnNueTransportista.Location = New System.Drawing.Point(785, 5)
        Me.btnNueTransportista.Name = "btnNueTransportista"
        Me.btnNueTransportista.Size = New System.Drawing.Size(29, 27)
        Me.btnNueTransportista.TabIndex = 3
        Me.btnNueTransportista.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNueTransportista.UseVisualStyleBackColor = True
        '
        'AcTextBoxAyuda1
        '
        Me.AcTextBoxAyuda1.ACActivarAyudaAuto = False
        Me.AcTextBoxAyuda1.ACLongitudAceptada = 0
        Me.AcTextBoxAyuda1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AcTextBoxAyuda1.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.AcTextBoxAyuda1.Location = New System.Drawing.Point(216, 7)
        Me.AcTextBoxAyuda1.MaxLength = 80
        Me.AcTextBoxAyuda1.Name = "AcTextBoxAyuda1"
        Me.AcTextBoxAyuda1.Size = New System.Drawing.Size(562, 23)
        Me.AcTextBoxAyuda1.TabIndex = 2
        Me.AcTextBoxAyuda1.Tag = "EVO"
        '
        'actxaNroDocProveedor_2
        '
        Me.actxaNroDocProveedor_2.ACActivarAyudaAuto = False
        Me.actxaNroDocProveedor_2.ACLongitudAceptada = 0
        Me.actxaNroDocProveedor_2.Location = New System.Drawing.Point(88, 7)
        Me.actxaNroDocProveedor_2.MaxLength = 14
        Me.actxaNroDocProveedor_2.Name = "actxaNroDocProveedor_2"
        Me.actxaNroDocProveedor_2.Size = New System.Drawing.Size(121, 23)
        Me.actxaNroDocProveedor_2.TabIndex = 1
        Me.actxaNroDocProveedor_2.Tag = "EVO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Proveedor :"
        '
        'txtSerie
        '
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.Location = New System.Drawing.Point(430, 90)
        Me.txtSerie.MaxLength = 4
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(51, 23)
        Me.txtSerie.TabIndex = 12
        Me.txtSerie.Tag = "EVO"
        '
        'actxnNumero
        '
        Me.actxnNumero.ACEnteros = 8
        Me.actxnNumero.ACFormato = "#######0"
        Me.actxnNumero.ACNegativo = True
        Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnNumero.Location = New System.Drawing.Point(546, 90)
        Me.actxnNumero.MaxLength = 12
        Me.actxnNumero.Name = "actxnNumero"
        Me.actxnNumero.Size = New System.Drawing.Size(100, 23)
        Me.actxnNumero.TabIndex = 14
        Me.actxnNumero.Tag = "ENO"
        Me.actxnNumero.Text = "0"
        Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(488, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 15)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Numero :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(385, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 15)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Serie :"
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.AutoSize = True
        Me.lblTipoDocumento.Location = New System.Drawing.Point(4, 94)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(76, 15)
        Me.lblTipoDocumento.TabIndex = 9
        Me.lblTipoDocumento.Text = "Documento :"
        '
        'cmbDocumento
        '
        Me.cmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumento.FormattingEnabled = True
        Me.cmbDocumento.Items.AddRange(New Object() {"Boleta", "Factura"})
        Me.cmbDocumento.Location = New System.Drawing.Point(88, 90)
        Me.cmbDocumento.Name = "cmbDocumento"
        Me.cmbDocumento.Size = New System.Drawing.Size(279, 23)
        Me.cmbDocumento.TabIndex = 10
        Me.cmbDocumento.Tag = "ECO"
        '
        'dtpFecEmision
        '
        Me.dtpFecEmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecEmision.Location = New System.Drawing.Point(88, 63)
        Me.dtpFecEmision.Name = "dtpFecEmision"
        Me.dtpFecEmision.Size = New System.Drawing.Size(109, 23)
        Me.dtpFecEmision.TabIndex = 6
        Me.dtpFecEmision.Tag = "E"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(23, 40)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(57, 15)
        Me.lblMoneda.TabIndex = 3
        Me.lblMoneda.Text = "&Moneda :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.DropDownWidth = 250
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(88, 36)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(109, 23)
        Me.cmbMoneda.TabIndex = 4
        Me.cmbMoneda.Tag = "EO"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(36, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Fecha :"
        '
        'tpgFacturas
        '
        Me.tpgFacturas.Controls.Add(Me.c1grdFacturas)
        Me.tpgFacturas.Controls.Add(Me.bnavFacturas)
        Me.tpgFacturas.Controls.Add(Me.tspFacturas)
        Me.tpgFacturas.Location = New System.Drawing.Point(4, 24)
        Me.tpgFacturas.Name = "tpgFacturas"
        Me.tpgFacturas.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgFacturas.Size = New System.Drawing.Size(824, 311)
        Me.tpgFacturas.TabIndex = 1
        Me.tpgFacturas.Text = "Lista Doc. Compra Piezas"
        Me.tpgFacturas.UseVisualStyleBackColor = True
        '
        'c1grdFacturas
        '
        Me.c1grdFacturas.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdFacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdFacturas.Location = New System.Drawing.Point(3, 28)
        Me.c1grdFacturas.Name = "c1grdFacturas"
        Me.c1grdFacturas.Rows.Count = 2
        Me.c1grdFacturas.Rows.DefaultSize = 20
        Me.c1grdFacturas.Size = New System.Drawing.Size(818, 255)
        Me.c1grdFacturas.StyleInfo = resources.GetString("c1grdFacturas.StyleInfo")
        Me.c1grdFacturas.TabIndex = 35
        '
        'bnavFacturas
        '
        Me.bnavFacturas.AddNewItem = Me.ToolStripButton7
        Me.bnavFacturas.CountItem = Me.ToolStripLabel2
        Me.bnavFacturas.DeleteItem = Me.ToolStripButton8
        Me.bnavFacturas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavFacturas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton9, Me.ToolStripButton10, Me.ToolStripSeparator5, Me.ToolStripTextBox2, Me.ToolStripLabel2, Me.ToolStripSeparator6, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator7, Me.ToolStripButton8, Me.ToolStripButton7})
        Me.bnavFacturas.Location = New System.Drawing.Point(3, 283)
        Me.bnavFacturas.MoveFirstItem = Me.ToolStripButton9
        Me.bnavFacturas.MoveLastItem = Me.ToolStripButton12
        Me.bnavFacturas.MoveNextItem = Me.ToolStripButton11
        Me.bnavFacturas.MovePreviousItem = Me.ToolStripButton10
        Me.bnavFacturas.Name = "bnavFacturas"
        Me.bnavFacturas.PositionItem = Me.ToolStripTextBox2
        Me.bnavFacturas.Size = New System.Drawing.Size(818, 25)
        Me.bnavFacturas.TabIndex = 36
        Me.bnavFacturas.Text = "BindingNavigator1"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Add new"
        Me.ToolStripButton7.Visible = False
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel2.Text = "de {0}"
        Me.ToolStripLabel2.ToolTipText = "Total number of items"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "Delete"
        Me.ToolStripButton8.Visible = False
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
        'tspFacturas
        '
        Me.tspFacturas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAgregarFacturas, Me.ToolStripSeparator8, Me.tsbtnQuitarFacturas})
        Me.tspFacturas.Location = New System.Drawing.Point(3, 3)
        Me.tspFacturas.Name = "tspFacturas"
        Me.tspFacturas.Size = New System.Drawing.Size(818, 25)
        Me.tspFacturas.TabIndex = 37
        Me.tspFacturas.Text = "ToolStrip1"
        '
        'tsbtnAgregarFacturas
        '
        Me.tsbtnAgregarFacturas.Image = CType(resources.GetObject("tsbtnAgregarFacturas.Image"), System.Drawing.Image)
        Me.tsbtnAgregarFacturas.Name = "tsbtnAgregarFacturas"
        Me.tsbtnAgregarFacturas.RightToLeftAutoMirrorImage = True
        Me.tsbtnAgregarFacturas.Size = New System.Drawing.Size(142, 22)
        Me.tsbtnAgregarFacturas.Text = "Agregar Doc. Compra"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnQuitarFacturas
        '
        Me.tsbtnQuitarFacturas.Image = CType(resources.GetObject("tsbtnQuitarFacturas.Image"), System.Drawing.Image)
        Me.tsbtnQuitarFacturas.Name = "tsbtnQuitarFacturas"
        Me.tsbtnQuitarFacturas.RightToLeftAutoMirrorImage = True
        Me.tsbtnQuitarFacturas.Size = New System.Drawing.Size(133, 22)
        Me.tsbtnQuitarFacturas.Text = "Quitar Doc. Compra"
        '
        'tpgRepuestos
        '
        Me.tpgRepuestos.Controls.Add(Me.spcBase)
        Me.tpgRepuestos.Controls.Add(Me.tool)
        Me.tpgRepuestos.Location = New System.Drawing.Point(4, 24)
        Me.tpgRepuestos.Name = "tpgRepuestos"
        Me.tpgRepuestos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgRepuestos.Size = New System.Drawing.Size(824, 311)
        Me.tpgRepuestos.TabIndex = 0
        Me.tpgRepuestos.Text = "Lista Piezas"
        Me.tpgRepuestos.UseVisualStyleBackColor = True
        '
        'spcBase
        '
        Me.spcBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcBase.Location = New System.Drawing.Point(3, 28)
        Me.spcBase.Name = "spcBase"
        '
        'spcBase.Panel1
        '
        Me.spcBase.Panel1.Controls.Add(Me.c1grdDetalle_piezas)
        Me.spcBase.Panel1.Controls.Add(Me.bnavDetalle)
        '
        'spcBase.Panel2
        '
        Me.spcBase.Panel2.Controls.Add(Me.PictureBox2)
        Me.spcBase.Size = New System.Drawing.Size(818, 280)
        Me.spcBase.SplitterDistance = 548
        Me.spcBase.TabIndex = 30
        '
        'c1grdDetalle_piezas
        '
        Me.c1grdDetalle_piezas.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdDetalle_piezas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdDetalle_piezas.Location = New System.Drawing.Point(0, 0)
        Me.c1grdDetalle_piezas.Name = "c1grdDetalle_piezas"
        Me.c1grdDetalle_piezas.Rows.Count = 2
        Me.c1grdDetalle_piezas.Rows.DefaultSize = 20
        Me.c1grdDetalle_piezas.Size = New System.Drawing.Size(548, 255)
        Me.c1grdDetalle_piezas.StyleInfo = resources.GetString("c1grdDetalle_piezas.StyleInfo")
        Me.c1grdDetalle_piezas.TabIndex = 4
        '
        'bnavDetalle
        '
        Me.bnavDetalle.AddNewItem = Me.ToolStripButton1
        Me.bnavDetalle.CountItem = Me.ToolStripLabel1
        Me.bnavDetalle.DeleteItem = Me.ToolStripButton2
        Me.bnavDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton2, Me.ToolStripButton1})
        Me.bnavDetalle.Location = New System.Drawing.Point(0, 255)
        Me.bnavDetalle.MoveFirstItem = Me.ToolStripButton3
        Me.bnavDetalle.MoveLastItem = Me.ToolStripButton6
        Me.bnavDetalle.MoveNextItem = Me.ToolStripButton5
        Me.bnavDetalle.MovePreviousItem = Me.ToolStripButton4
        Me.bnavDetalle.Name = "bnavDetalle"
        Me.bnavDetalle.PositionItem = Me.ToolStripTextBox1
        Me.bnavDetalle.Size = New System.Drawing.Size(548, 25)
        Me.bnavDetalle.TabIndex = 5
        Me.bnavDetalle.Text = "BindingNavigator1"
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
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "de {0}"
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
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(266, 280)
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        '
        'tool
        '
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAgregar, Me.ToolStripSeparator4, Me.tsbtnQuitar, Me.ToolStripSeparator9, Me.tsbtnModificarPieza})
        Me.tool.Location = New System.Drawing.Point(3, 3)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(818, 25)
        Me.tool.TabIndex = 34
        Me.tool.Text = "ToolStrip1"
        '
        'tsbtnAgregar
        '
        Me.tsbtnAgregar.Image = CType(resources.GetObject("tsbtnAgregar.Image"), System.Drawing.Image)
        Me.tsbtnAgregar.Name = "tsbtnAgregar"
        Me.tsbtnAgregar.RightToLeftAutoMirrorImage = True
        Me.tsbtnAgregar.Size = New System.Drawing.Size(121, 22)
        Me.tsbtnAgregar.Text = "Agregar Repuesto"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnQuitar
        '
        Me.tsbtnQuitar.Image = CType(resources.GetObject("tsbtnQuitar.Image"), System.Drawing.Image)
        Me.tsbtnQuitar.Name = "tsbtnQuitar"
        Me.tsbtnQuitar.RightToLeftAutoMirrorImage = True
        Me.tsbtnQuitar.Size = New System.Drawing.Size(112, 22)
        Me.tsbtnQuitar.Text = "Quitar Repuesto"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnModificarPieza
        '
        Me.tsbtnModificarPieza.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.tsbtnModificarPieza.Name = "tsbtnModificarPieza"
        Me.tsbtnModificarPieza.RightToLeftAutoMirrorImage = True
        Me.tsbtnModificarPieza.Size = New System.Drawing.Size(130, 22)
        Me.tsbtnModificarPieza.Text = "Modificar Repuesto"
        '
        'AcPanelCaption1
        '
        Me.AcPanelCaption1.ACCaption = "Detalle del Mantenimiento"
        Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 179)
        Me.AcPanelCaption1.Name = "AcPanelCaption1"
        Me.AcPanelCaption1.Size = New System.Drawing.Size(832, 24)
        Me.AcPanelCaption1.TabIndex = 31
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.pnlVehiculo)
        Me.Panel3.Controls.Add(Me.cmbManTipoMantenimiento)
        Me.Panel3.Controls.Add(Me.actxaNroDocProveedor)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.actxnManKilometraje)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtManObservacion)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.lblProveedor)
        Me.Panel3.Controls.Add(Me.actxaDescProveedor)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(832, 179)
        Me.Panel3.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(70, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 15)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "&Kilometraje :"
        '
        'pnlVehiculo
        '
        Me.pnlVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlVehiculo.Controls.Add(Me.txtVehiDescripcion)
        Me.pnlVehiculo.Controls.Add(Me.Label3)
        Me.pnlVehiculo.Controls.Add(Me.txtVehicPlaca)
        Me.pnlVehiculo.Controls.Add(Me.dtpFecMantenimiento)
        Me.pnlVehiculo.Controls.Add(Me.Label6)
        Me.pnlVehiculo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVehiculo.Location = New System.Drawing.Point(0, 0)
        Me.pnlVehiculo.Name = "pnlVehiculo"
        Me.pnlVehiculo.Size = New System.Drawing.Size(832, 36)
        Me.pnlVehiculo.TabIndex = 15
        '
        'txtVehiDescripcion
        '
        Me.txtVehiDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehiDescripcion.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.txtVehiDescripcion.Location = New System.Drawing.Point(266, 4)
        Me.txtVehiDescripcion.Name = "txtVehiDescripcion"
        Me.txtVehiDescripcion.Size = New System.Drawing.Size(165, 26)
        Me.txtVehiDescripcion.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label3.Location = New System.Drawing.Point(68, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Vehiculo :"
        '
        'txtVehicPlaca
        '
        Me.txtVehicPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicPlaca.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.txtVehicPlaca.Location = New System.Drawing.Point(148, 4)
        Me.txtVehicPlaca.Name = "txtVehicPlaca"
        Me.txtVehicPlaca.Size = New System.Drawing.Size(112, 26)
        Me.txtVehicPlaca.TabIndex = 1
        '
        'dtpFecMantenimiento
        '
        Me.dtpFecMantenimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecMantenimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecMantenimiento.Location = New System.Drawing.Point(708, 6)
        Me.dtpFecMantenimiento.Name = "dtpFecMantenimiento"
        Me.dtpFecMantenimiento.Size = New System.Drawing.Size(112, 23)
        Me.dtpFecMantenimiento.TabIndex = 4
        Me.dtpFecMantenimiento.Tag = "E"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(652, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "&Fecha :"
        '
        'cmbManTipoMantenimiento
        '
        Me.cmbManTipoMantenimiento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbManTipoMantenimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbManTipoMantenimiento.FormattingEnabled = True
        Me.cmbManTipoMantenimiento.Location = New System.Drawing.Point(147, 40)
        Me.cmbManTipoMantenimiento.Name = "cmbManTipoMantenimiento"
        Me.cmbManTipoMantenimiento.Size = New System.Drawing.Size(674, 23)
        Me.cmbManTipoMantenimiento.TabIndex = 1
        Me.cmbManTipoMantenimiento.Tag = "ECO"
        '
        'actxaNroDocProveedor
        '
        Me.actxaNroDocProveedor.ACActivarAyudaAuto = False
        Me.actxaNroDocProveedor.ACLongitudAceptada = 0
        Me.actxaNroDocProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaNroDocProveedor.Location = New System.Drawing.Point(147, 66)
        Me.actxaNroDocProveedor.MaxLength = 32767
        Me.actxaNroDocProveedor.Name = "actxaNroDocProveedor"
        Me.actxaNroDocProveedor.Size = New System.Drawing.Size(112, 23)
        Me.actxaNroDocProveedor.TabIndex = 3
        Me.actxaNroDocProveedor.Tag = "EVO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(63, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 15)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Observación :"
        '
        'actxnManKilometraje
        '
        Me.actxnManKilometraje.ACEnteros = 9
        Me.actxnManKilometraje.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnManKilometraje.ACFormato = "########0.00"
        Me.actxnManKilometraje.ACNegativo = True
        Me.actxnManKilometraje.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnManKilometraje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnManKilometraje.Location = New System.Drawing.Point(147, 95)
        Me.actxnManKilometraje.MaxLength = 12
        Me.actxnManKilometraje.Name = "actxnManKilometraje"
        Me.actxnManKilometraje.Size = New System.Drawing.Size(98, 23)
        Me.actxnManKilometraje.TabIndex = 9
        Me.actxnManKilometraje.Tag = "EV"
        Me.actxnManKilometraje.Text = "0.00"
        Me.actxnManKilometraje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo de Mantenimiento :"
        '
        'txtManObservacion
        '
        Me.txtManObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtManObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManObservacion.Location = New System.Drawing.Point(148, 125)
        Me.txtManObservacion.MaxLength = 200
        Me.txtManObservacion.Multiline = True
        Me.txtManObservacion.Name = "txtManObservacion"
        Me.txtManObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtManObservacion.Size = New System.Drawing.Size(674, 36)
        Me.txtManObservacion.TabIndex = 12
        Me.txtManObservacion.Tag = "EVO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(251, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "KM"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(76, 70)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(67, 15)
        Me.lblProveedor.TabIndex = 2
        Me.lblProveedor.Text = "Proveedor :"
        '
        'actxaDescProveedor
        '
        Me.actxaDescProveedor.ACActivarAyudaAuto = False
        Me.actxaDescProveedor.ACLongitudAceptada = 0
        Me.actxaDescProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaDescProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaDescProveedor.Location = New System.Drawing.Point(265, 66)
        Me.actxaDescProveedor.MaxLength = 50
        Me.actxaDescProveedor.Name = "actxaDescProveedor"
        Me.actxaDescProveedor.Size = New System.Drawing.Size(556, 23)
        Me.actxaDescProveedor.TabIndex = 4
        Me.actxaDescProveedor.Tag = "EV"
        '
        'tabBusqueda
        '
        Me.tabBusqueda.Controls.Add(Me.c1grdBusqueda)
        Me.tabBusqueda.Controls.Add(Me.bnavBusqueda)
        Me.tabBusqueda.Controls.Add(Me.grpBusqueda)
        Me.tabBusqueda.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Location = New System.Drawing.Point(1, 1)
        Me.tabBusqueda.Name = "tabBusqueda"
        Me.tabBusqueda.SelectBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Selected = False
        Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Size = New System.Drawing.Size(832, 542)
        Me.tabBusqueda.TabIndex = 5
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'c1grdBusqueda
        '
        Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 55)
        Me.c1grdBusqueda.Name = "c1grdBusqueda"
        Me.c1grdBusqueda.Rows.Count = 2
        Me.c1grdBusqueda.Rows.DefaultSize = 20
        Me.c1grdBusqueda.Size = New System.Drawing.Size(832, 462)
        Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
        Me.c1grdBusqueda.TabIndex = 2
        '
        'bnavBusqueda
        '
        Me.bnavBusqueda.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.bnavBusqueda.CountItem = Me.BindingNavigatorCountItem
        Me.bnavBusqueda.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 517)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(832, 25)
        Me.bnavBusqueda.TabIndex = 3
        Me.bnavBusqueda.Text = "BindingNavigator1"
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
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
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
        'grpBusqueda
        '
        Me.grpBusqueda.Controls.Add(Me.AcFecha)
        Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
        Me.grpBusqueda.Controls.Add(Me.rbtnPlaca)
        Me.grpBusqueda.Controls.Add(Me.rbtnCodigo)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(832, 55)
        Me.grpBusqueda.TabIndex = 1
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'AcFecha
        '
        Me.AcFecha.ACFecha_A = New Date(2024, 9, 27, 16, 30, 44, 384)
        Me.AcFecha.ACFecha_De = New Date(2024, 9, 27, 16, 30, 44, 382)
        Me.AcFecha.ACFechaObligatoria = True
        Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
        Me.AcFecha.ACHoyChecked = False
        Me.AcFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AcFecha.Location = New System.Drawing.Point(491, 1)
        Me.AcFecha.MaximumSize = New System.Drawing.Size(340, 50)
        Me.AcFecha.MinimumSize = New System.Drawing.Size(340, 43)
        Me.AcFecha.Name = "AcFecha"
        Me.AcFecha.Size = New System.Drawing.Size(340, 45)
        Me.AcFecha.TabIndex = 9
        Me.AcFecha.TabStop = False
        '
        'txtBusqueda
        '
        Me.txtBusqueda.ACActivarAyudaAuto = False
        Me.txtBusqueda.ACLongitudAceptada = 0
        Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda.Location = New System.Drawing.Point(17, 20)
        Me.txtBusqueda.MaxLength = 32767
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(275, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'rbtnPlaca
        '
        Me.rbtnPlaca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnPlaca.AutoSize = True
        Me.rbtnPlaca.Checked = True
        Me.rbtnPlaca.Location = New System.Drawing.Point(411, 22)
        Me.rbtnPlaca.Name = "rbtnPlaca"
        Me.rbtnPlaca.Size = New System.Drawing.Size(74, 19)
        Me.rbtnPlaca.TabIndex = 8
        Me.rbtnPlaca.TabStop = True
        Me.rbtnPlaca.Text = "Por Placa"
        Me.rbtnPlaca.UseVisualStyleBackColor = True
        '
        'rbtnCodigo
        '
        Me.rbtnCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnCodigo.AutoSize = True
        Me.rbtnCodigo.Location = New System.Drawing.Point(316, 22)
        Me.rbtnCodigo.Name = "rbtnCodigo"
        Me.rbtnCodigo.Size = New System.Drawing.Size(85, 19)
        Me.rbtnCodigo.TabIndex = 7
        Me.rbtnCodigo.Text = "Por Codigo"
        Me.rbtnCodigo.UseVisualStyleBackColor = True
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Registro de Mantenimiento de Vehiculos"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(834, 30)
        Me.acpnlTitulo.TabIndex = 10
        '
        'acTool
        '
        Me.acTool.ACBtnAnularEnabled = False
        Me.acTool.ACBtnAnularVisible = False
        Me.acTool.ACBtnBuscarEnabled = False
        Me.acTool.ACBtnBuscarVisible = False
        Me.acTool.ACBtnCancelarEnabled = False
        Me.acTool.ACBtnCancelarVisible = False
        Me.acTool.ACBtnEliminarEnabled = False
        Me.acTool.ACBtnEliminarVisible = False
        Me.acTool.ACBtnGrabarEnabled = False
        Me.acTool.ACBtnGrabarVisible = False
        Me.acTool.ACBtnImprimirEnabled = False
        Me.acTool.ACBtnImprimirVisible = False
        Me.acTool.ACBtnRehusarEnabled = False
        Me.acTool.ACBtnRehusarVisible = False
        Me.acTool.ACBtnReporteEnabled = False
        Me.acTool.ACBtnReporteVisible = False
        Me.acTool.ACBtnSalirText = "&Salir"
        Me.acTool.ACBtnVolverEnabled = False
        Me.acTool.ACBtnVolverVisible = False
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabar
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.acbtnSeleccionar})
        Me.acTool.Location = New System.Drawing.Point(0, 597)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(834, 56)
        Me.acTool.TabIndex = 13
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'acbtnSeleccionar
        '
        Me.acbtnSeleccionar.AutoSize = False
        Me.acbtnSeleccionar.Image = Global.ACPTransportes.My.Resources.Resources.aceptar_32x32
        Me.acbtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.acbtnSeleccionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.acbtnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.acbtnSeleccionar.Name = "tsbBoton"
        Me.acbtnSeleccionar.Size = New System.Drawing.Size(84, 53)
        Me.acbtnSeleccionar.Text = "&Seleccionar"
        Me.acbtnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.acbtnSeleccionar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.acbtnSeleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.acbtnSeleccionar.Visible = False
        '
        'MVehiculosMantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 653)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Controls.Add(Me.acTool)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MVehiculosMantenimiento"
        Me.Text = "Registro de Mantenimiento de Vehiculos"
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.IngresoFac.ResumeLayout(False)
        Me.IngresoFac.PerformLayout()
        CType(Me.bnavProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavProductos.ResumeLayout(False)
        Me.bnavProductos.PerformLayout()
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlItem.ResumeLayout(False)
        Me.pnlItem.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.tpgFacturas.ResumeLayout(False)
        Me.tpgFacturas.PerformLayout()
        CType(Me.c1grdFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavFacturas.ResumeLayout(False)
        Me.bnavFacturas.PerformLayout()
        Me.tspFacturas.ResumeLayout(False)
        Me.tspFacturas.PerformLayout()
        Me.tpgRepuestos.ResumeLayout(False)
        Me.tpgRepuestos.PerformLayout()
        Me.spcBase.Panel1.ResumeLayout(False)
        Me.spcBase.Panel1.PerformLayout()
        Me.spcBase.Panel2.ResumeLayout(False)
        CType(Me.spcBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcBase.ResumeLayout(False)
        CType(Me.c1grdDetalle_piezas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavDetalle.ResumeLayout(False)
        Me.bnavDetalle.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlVehiculo.ResumeLayout(False)
        Me.pnlVehiculo.PerformLayout()
        Me.tabBusqueda.ResumeLayout(False)
        Me.tabBusqueda.PerformLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavBusqueda.ResumeLayout(False)
        Me.bnavBusqueda.PerformLayout()
        Me.grpBusqueda.ResumeLayout(False)
        Me.grpBusqueda.PerformLayout()
        Me.acTool.ResumeLayout(False)
        Me.acTool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
    Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
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
    Private WithEvents grpBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents actxnManKilometraje As ACControles.ACTextBoxNumerico
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtManObservacion As System.Windows.Forms.TextBox
    Friend WithEvents dtpFecMantenimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbManTipoMantenimiento As System.Windows.Forms.ComboBox
    Friend WithEvents rbtnPlaca As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents actxaDescProveedor As ACControles.ACTextBoxAyuda
    Friend WithEvents actxaNroDocProveedor As ACControles.ACTextBoxAyuda
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents spcBase As System.Windows.Forms.SplitContainer
    Friend WithEvents c1grdDetalle_piezas As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavDetalle As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tool As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnQuitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlVehiculo As System.Windows.Forms.Panel
    Friend WithEvents txtVehiDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVehicPlaca As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpgRepuestos As System.Windows.Forms.TabPage
    Friend WithEvents tpgFacturas As System.Windows.Forms.TabPage
    Friend WithEvents c1grdFacturas As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavFacturas As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tspFacturas As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnAgregarFacturas As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnQuitarFacturas As System.Windows.Forms.ToolStripButton
    Friend WithEvents AcFecha As ACControles.ACFecha
    Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
    Friend WithEvents acbtnSeleccionar As ACControles.ACToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnModificarPieza As System.Windows.Forms.ToolStripButton
    Friend WithEvents IngresoFac As TabPage
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents dtpFecIngreso As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents chkIncluidoIGV As CheckBox
    Friend WithEvents btnNueTransportista As Button
    Friend WithEvents AcTextBoxAyuda1 As ACControles.ACTextBoxAyuda
    Friend WithEvents actxaNroDocProveedor_2 As ACControles.ACTextBoxAyuda
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSerie As TextBox
    Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblTipoDocumento As Label
    Friend WithEvents cmbDocumento As ComboBox
    Friend WithEvents dtpFecEmision As DateTimePicker
    Friend WithEvents lblMoneda As Label
    Friend WithEvents cmbMoneda As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents actxnImporte As ACControles.ACTextBoxNumerico
    Friend WithEvents lblImporte As Label
    Friend WithEvents lblTotalPagar As Label
    Friend WithEvents lbligv As Label
    Friend WithEvents actxnTotalPagar As ACControles.ACTextBoxNumerico
    Friend WithEvents actxnIGV As ACControles.ACTextBoxNumerico
    Friend WithEvents pnlItem As Panel
    Friend WithEvents chkPrecIGV As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents actxnPrecIGV As ACControles.ACTextBoxNumerico
    Friend WithEvents actxaDescripcion As ACControles.ACTextBoxAyuda
    Friend WithEvents actxnDescuento As ACControles.ACTextBoxNumerico
    Friend WithEvents Label14 As Label
    Friend WithEvents actxnPrecio As ACControles.ACTextBoxNumerico
    Friend WithEvents txtOpcion As TextBox
    Friend WithEvents actxnSubImporte As ACControles.ACTextBoxNumerico
    Friend WithEvents actxnProdCantidad As ACControles.ACTextBoxNumerico
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents c1grdDetalle As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavProductos As BindingNavigator
    Friend WithEvents ToolStripButton13 As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripButton14 As ToolStripButton
    Friend WithEvents ToolStripButton15 As ToolStripButton
    Friend WithEvents ToolStripButton16 As ToolStripButton
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents ToolStripTextBox3 As ToolStripTextBox
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents ToolStripButton17 As ToolStripButton
    Friend WithEvents ToolStripButton18 As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
End Class
