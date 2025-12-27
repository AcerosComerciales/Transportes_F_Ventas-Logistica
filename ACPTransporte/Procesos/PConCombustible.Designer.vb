<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PConCombustible
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PConCombustible))
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.c1grdConsumos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavConsumos = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.tsbtnAnularRegistro = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnExcel = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption2 = New ACControles.ACPanelCaption()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.c1grdDocsPago = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnNuevoTPago = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAgregarTPago = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption4 = New ACControles.ACPanelCaption()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtnumeroentero = New ACControles.ACTextBoxNumerico()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.actxtotal = New ACControles.ACTextBoxNumerico()
        Me.actxtsub = New ACControles.ACTextBoxNumerico()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.AcTextBoxNumerico1 = New ACControles.ACTextBoxNumerico()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.cmbGuia = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.actxaDescVehiculo = New ACControles.ACTextBoxAyuda()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.actxaCodVehiculo = New ACControles.ACTextBoxAyuda()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.actxnKilometraje = New ACControles.ACTextBoxNumerico()
        Me.lblTipoCombustible = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.actxnComPrecGalon = New ACControles.ACTextBoxNumerico()
        Me.btnNuevConductor = New System.Windows.Forms.Button()
        Me.cmbComTipoCombustible = New System.Windows.Forms.ComboBox()
        Me.actxaDescConductor = New ACControles.ACTextBoxAyuda()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.actxnNumero = New ACControles.ACTextBoxNumerico()
        Me.actxnTotal = New ACControles.ACTextBoxNumerico()
        Me.actxnComLitConsumidos = New ACControles.ACTextBoxNumerico()
        Me.actxaCodConductor = New ACControles.ACTextBoxAyuda()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.dtpFecConsumo = New System.Windows.Forms.DateTimePicker()
        Me.actxaNroDocProveedor = New ACControles.ACTextBoxAyuda()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.actxaDescProveedor = New ACControles.ACTextBoxAyuda()
        Me.dtpFecViaje = New System.Windows.Forms.DateTimePicker()
        Me.btnNueProveedor = New System.Windows.Forms.Button()
        Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
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
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.rbtnPlaca = New System.Windows.Forms.RadioButton()
        Me.rbtnCodigo = New System.Windows.Forms.RadioButton()
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.tabBusConsumos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.c1grdBusConsumos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtnProveedor = New System.Windows.Forms.RadioButton()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.actxaBusqueda = New ACControles.ACTextBoxAyuda()
        Me.chkMostrarTodos = New System.Windows.Forms.CheckBox()
        Me.rbtnConductor = New System.Windows.Forms.RadioButton()
        Me.rbtnPlacaVehiculo = New System.Windows.Forms.RadioButton()
        Me.AcFecha = New ACControles.ACFecha(Me.components)
        Me.bnavBusConsumos = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption3 = New ACControles.ACPanelCaption()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.c1grdConsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavConsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavConsumos.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.c1grdDocsPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabBusqueda.SuspendLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavBusqueda.SuspendLayout()
        Me.grpBusqueda.SuspendLayout()
        Me.tabBusConsumos.SuspendLayout()
        CType(Me.c1grdBusConsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.bnavBusConsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavBusConsumos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 0)
        Me.tabMantenimiento.MediaPlayerDockSides = False
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = False
        Me.tabMantenimiento.SelectedIndex = 0
        Me.tabMantenimiento.ShowDropSelect = False
        Me.tabMantenimiento.Size = New System.Drawing.Size(1054, 602)
        Me.tabMantenimiento.TabIndex = 13
        Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos, Me.tabBusqueda, Me.tabBusConsumos})
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
        Me.tabDatos.Size = New System.Drawing.Size(1052, 577)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.Panel3)
        Me.pnlDatos.Controls.Add(Me.Panel1)
        Me.pnlDatos.Controls.Add(Me.AcPanelCaption1)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1052, 577)
        Me.pnlDatos.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 348)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1052, 229)
        Me.Panel3.TabIndex = 36
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.c1grdConsumos)
        Me.Panel2.Controls.Add(Me.bnavConsumos)
        Me.Panel2.Controls.Add(Me.AcPanelCaption2)
        Me.Panel2.Location = New System.Drawing.Point(3, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(564, 232)
        Me.Panel2.TabIndex = 37
        '
        'c1grdConsumos
        '
        Me.c1grdConsumos.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdConsumos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdConsumos.Location = New System.Drawing.Point(0, 30)
        Me.c1grdConsumos.Name = "c1grdConsumos"
        Me.c1grdConsumos.Rows.Count = 2
        Me.c1grdConsumos.Rows.DefaultSize = 20
        Me.c1grdConsumos.Size = New System.Drawing.Size(564, 177)
        Me.c1grdConsumos.StyleInfo = resources.GetString("c1grdConsumos.StyleInfo")
        Me.c1grdConsumos.TabIndex = 38
        '
        'bnavConsumos
        '
        Me.bnavConsumos.AddNewItem = Me.ToolStripButton1
        Me.bnavConsumos.CountItem = Me.ToolStripLabel1
        Me.bnavConsumos.DeleteItem = Me.ToolStripButton2
        Me.bnavConsumos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavConsumos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2, Me.tsbtnAnularRegistro, Me.tsbtnExcel})
        Me.bnavConsumos.Location = New System.Drawing.Point(0, 207)
        Me.bnavConsumos.MoveFirstItem = Me.ToolStripButton3
        Me.bnavConsumos.MoveLastItem = Me.ToolStripButton6
        Me.bnavConsumos.MoveNextItem = Me.ToolStripButton5
        Me.bnavConsumos.MovePreviousItem = Me.ToolStripButton4
        Me.bnavConsumos.Name = "bnavConsumos"
        Me.bnavConsumos.PositionItem = Me.ToolStripTextBox1
        Me.bnavConsumos.Size = New System.Drawing.Size(564, 25)
        Me.bnavConsumos.TabIndex = 36
        Me.bnavConsumos.Text = "BindingNavigator1"
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
        'tsbtnAnularRegistro
        '
        Me.tsbtnAnularRegistro.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnAnularRegistro.Image = Global.ACPTransportes.My.Resources.Resources.ACAnular_16x16
        Me.tsbtnAnularRegistro.Name = "tsbtnAnularRegistro"
        Me.tsbtnAnularRegistro.RightToLeftAutoMirrorImage = True
        Me.tsbtnAnularRegistro.Size = New System.Drawing.Size(108, 22)
        Me.tsbtnAnularRegistro.Text = "Anular Registro"
        '
        'tsbtnExcel
        '
        Me.tsbtnExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnExcel.Image = Global.ACPTransportes.My.Resources.Resources.Excel2_16x16
        Me.tsbtnExcel.Name = "tsbtnExcel"
        Me.tsbtnExcel.RightToLeftAutoMirrorImage = True
        Me.tsbtnExcel.Size = New System.Drawing.Size(54, 22)
        Me.tsbtnExcel.Text = "Excel"
        '
        'AcPanelCaption2
        '
        Me.AcPanelCaption2.ACCaption = "Ultimos Consumos"
        Me.AcPanelCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption2.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption2.Name = "AcPanelCaption2"
        Me.AcPanelCaption2.Size = New System.Drawing.Size(564, 30)
        Me.AcPanelCaption2.TabIndex = 34
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.c1grdDocsPago)
        Me.Panel4.Controls.Add(Me.ToolStrip1)
        Me.Panel4.Controls.Add(Me.AcPanelCaption4)
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(566, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(483, 233)
        Me.Panel4.TabIndex = 36
        '
        'c1grdDocsPago
        '
        Me.c1grdDocsPago.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:21;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdDocsPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdDocsPago.Location = New System.Drawing.Point(0, 55)
        Me.c1grdDocsPago.Name = "c1grdDocsPago"
        Me.c1grdDocsPago.Rows.Count = 2
        Me.c1grdDocsPago.Rows.DefaultSize = 20
        Me.c1grdDocsPago.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.c1grdDocsPago.Size = New System.Drawing.Size(481, 176)
        Me.c1grdDocsPago.StyleInfo = resources.GetString("c1grdDocsPago.StyleInfo")
        Me.c1grdDocsPago.TabIndex = 37
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnNuevoTPago, Me.ToolStripSeparator7, Me.tsbtnAgregarTPago, Me.ToolStripSeparator10})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 30)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(481, 25)
        Me.ToolStrip1.TabIndex = 36
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtnNuevoTPago
        '
        Me.tsbtnNuevoTPago.Image = CType(resources.GetObject("tsbtnNuevoTPago.Image"), System.Drawing.Image)
        Me.tsbtnNuevoTPago.Name = "tsbtnNuevoTPago"
        Me.tsbtnNuevoTPago.RightToLeftAutoMirrorImage = True
        Me.tsbtnNuevoTPago.Size = New System.Drawing.Size(62, 22)
        Me.tsbtnNuevoTPago.Text = "&Nuevo"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnAgregarTPago
        '
        Me.tsbtnAgregarTPago.Image = Global.ACPTransportes.My.Resources.Resources.ACAdd_32x32
        Me.tsbtnAgregarTPago.Name = "tsbtnAgregarTPago"
        Me.tsbtnAgregarTPago.RightToLeftAutoMirrorImage = True
        Me.tsbtnAgregarTPago.Size = New System.Drawing.Size(74, 22)
        Me.tsbtnAgregarTPago.Text = "&Existente"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption4
        '
        Me.AcPanelCaption4.ACCaption = "Relacion de Documentos"
        Me.AcPanelCaption4.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption4.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption4.Name = "AcPanelCaption4"
        Me.AcPanelCaption4.Size = New System.Drawing.Size(481, 30)
        Me.AcPanelCaption4.TabIndex = 35
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.actxaDescVehiculo)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.actxaCodVehiculo)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblProveedor)
        Me.Panel1.Controls.Add(Me.actxnKilometraje)
        Me.Panel1.Controls.Add(Me.lblTipoCombustible)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.actxnComPrecGalon)
        Me.Panel1.Controls.Add(Me.btnNuevConductor)
        Me.Panel1.Controls.Add(Me.cmbComTipoCombustible)
        Me.Panel1.Controls.Add(Me.actxaDescConductor)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.actxnNumero)
        Me.Panel1.Controls.Add(Me.actxnTotal)
        Me.Panel1.Controls.Add(Me.actxnComLitConsumidos)
        Me.Panel1.Controls.Add(Me.actxaCodConductor)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cmbTipoMoneda)
        Me.Panel1.Controls.Add(Me.dtpFecConsumo)
        Me.Panel1.Controls.Add(Me.actxaNroDocProveedor)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.actxaDescProveedor)
        Me.Panel1.Controls.Add(Me.dtpFecViaje)
        Me.Panel1.Controls.Add(Me.btnNueProveedor)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1052, 291)
        Me.Panel1.TabIndex = 30
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtnumeroentero)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.actxtotal)
        Me.GroupBox3.Controls.Add(Me.actxtsub)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(616, 199)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(295, 73)
        Me.GroupBox3.TabIndex = 36
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Saldos Documento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(134, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 15)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Total :"
        '
        'txtnumeroentero
        '
        Me.txtnumeroentero.ACEnteros = 8
        Me.txtnumeroentero.ACFormato = "#######0"
        Me.txtnumeroentero.ACNegativo = True
        Me.txtnumeroentero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtnumeroentero.Enabled = False
        Me.txtnumeroentero.Location = New System.Drawing.Point(67, 55)
        Me.txtnumeroentero.MaxLength = 12
        Me.txtnumeroentero.Name = "txtnumeroentero"
        Me.txtnumeroentero.Size = New System.Drawing.Size(202, 23)
        Me.txtnumeroentero.TabIndex = 31
        Me.txtnumeroentero.Tag = "EVO"
        Me.txtnumeroentero.Text = "0"
        Me.txtnumeroentero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtnumeroentero.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label11.Location = New System.Drawing.Point(16, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 15)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Saldo :"
        '
        'actxtotal
        '
        Me.actxtotal.ACEnteros = 9
        Me.actxtotal.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxtotal.ACNegativo = True
        Me.actxtotal.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxtotal.Enabled = False
        Me.actxtotal.Location = New System.Drawing.Point(184, 26)
        Me.actxtotal.MaxLength = 12
        Me.actxtotal.Name = "actxtotal"
        Me.actxtotal.Size = New System.Drawing.Size(100, 23)
        Me.actxtotal.TabIndex = 35
        Me.actxtotal.Tag = "VO"
        Me.actxtotal.Text = "0.00"
        Me.actxtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxtsub
        '
        Me.actxtsub.ACEnteros = 9
        Me.actxtsub.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxtsub.ACNegativo = True
        Me.actxtsub.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxtsub.Enabled = False
        Me.actxtsub.Location = New System.Drawing.Point(67, 26)
        Me.actxtsub.MaxLength = 12
        Me.actxtsub.Name = "actxtsub"
        Me.actxtsub.Size = New System.Drawing.Size(52, 23)
        Me.actxtsub.TabIndex = 34
        Me.actxtsub.Tag = "VO"
        Me.actxtsub.Text = "0.00"
        Me.actxtsub.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(279, 198)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(114, 19)
        Me.CheckBox1.TabIndex = 29
        Me.CheckBox1.Text = "Con Documento"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSerie)
        Me.GroupBox2.Controls.Add(Me.AcTextBoxNumerico1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblTipoDocumento)
        Me.GroupBox2.Controls.Add(Me.cmbGuia)
        Me.GroupBox2.Location = New System.Drawing.Point(262, 199)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 74)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(86, 46)
        Me.txtSerie.MaxLength = 5
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(51, 23)
        Me.txtSerie.TabIndex = 5
        Me.txtSerie.Tag = "EV"
        '
        'AcTextBoxNumerico1
        '
        Me.AcTextBoxNumerico1.ACEnteros = 8
        Me.AcTextBoxNumerico1.ACFormato = "#######0"
        Me.AcTextBoxNumerico1.ACNegativo = True
        Me.AcTextBoxNumerico1.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.AcTextBoxNumerico1.Location = New System.Drawing.Point(225, 46)
        Me.AcTextBoxNumerico1.MaxLength = 12
        Me.AcTextBoxNumerico1.Name = "AcTextBoxNumerico1"
        Me.AcTextBoxNumerico1.Size = New System.Drawing.Size(100, 23)
        Me.AcTextBoxNumerico1.TabIndex = 7
        Me.AcTextBoxNumerico1.Tag = "EN"
        Me.AcTextBoxNumerico1.Text = "0"
        Me.AcTextBoxNumerico1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(158, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 15)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Numero :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(41, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 15)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Serie :"
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.AutoSize = True
        Me.lblTipoDocumento.Location = New System.Drawing.Point(5, 24)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(76, 15)
        Me.lblTipoDocumento.TabIndex = 0
        Me.lblTipoDocumento.Text = "Documento :"
        '
        'cmbGuia
        '
        Me.cmbGuia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGuia.FormattingEnabled = True
        Me.cmbGuia.Items.AddRange(New Object() {"Boleta", "Factura"})
        Me.cmbGuia.Location = New System.Drawing.Point(87, 21)
        Me.cmbGuia.Name = "cmbGuia"
        Me.cmbGuia.Size = New System.Drawing.Size(239, 23)
        Me.cmbGuia.TabIndex = 1
        Me.cmbGuia.Tag = "EC"
        Me.cmbGuia.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Numero Vale :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(52, 170)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 15)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Precio Galon :"
        '
        'actxaDescVehiculo
        '
        Me.actxaDescVehiculo.ACActivarAyudaAuto = False
        Me.actxaDescVehiculo.ACLongitudAceptada = 0
        Me.actxaDescVehiculo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaDescVehiculo.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxaDescVehiculo.Location = New System.Drawing.Point(272, 87)
        Me.actxaDescVehiculo.MaxLength = 80
        Me.actxaDescVehiculo.Name = "actxaDescVehiculo"
        Me.actxaDescVehiculo.Size = New System.Drawing.Size(742, 23)
        Me.actxaDescVehiculo.TabIndex = 12
        Me.actxaDescVehiculo.Tag = "EVO"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(259, 170)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 15)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Galones Consumido :"
        '
        'actxaCodVehiculo
        '
        Me.actxaCodVehiculo.ACActivarAyudaAuto = False
        Me.actxaCodVehiculo.ACLongitudAceptada = 0
        Me.actxaCodVehiculo.Location = New System.Drawing.Point(141, 87)
        Me.actxaCodVehiculo.MaxLength = 14
        Me.actxaCodVehiculo.Name = "actxaCodVehiculo"
        Me.actxaCodVehiculo.Size = New System.Drawing.Size(121, 23)
        Me.actxaCodVehiculo.TabIndex = 11
        Me.actxaCodVehiculo.Tag = "EVO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(75, 225)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 15)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "&Fecha :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(73, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Vehiculo :"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(65, 37)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(67, 15)
        Me.lblProveedor.TabIndex = 2
        Me.lblProveedor.Text = "Proveedor :"
        '
        'actxnKilometraje
        '
        Me.actxnKilometraje.ACEnteros = 9
        Me.actxnKilometraje.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnKilometraje.ACNegativo = True
        Me.actxnKilometraje.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnKilometraje.Location = New System.Drawing.Point(140, 250)
        Me.actxnKilometraje.MaxLength = 12
        Me.actxnKilometraje.Name = "actxnKilometraje"
        Me.actxnKilometraje.Size = New System.Drawing.Size(102, 23)
        Me.actxnKilometraje.TabIndex = 28
        Me.actxnKilometraje.Tag = "EV"
        Me.actxnKilometraje.Text = "0.00"
        Me.actxnKilometraje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTipoCombustible
        '
        Me.lblTipoCombustible.AutoSize = True
        Me.lblTipoCombustible.Location = New System.Drawing.Point(8, 118)
        Me.lblTipoCombustible.Name = "lblTipoCombustible"
        Me.lblTipoCombustible.Size = New System.Drawing.Size(123, 15)
        Me.lblTipoCombustible.TabIndex = 13
        Me.lblTipoCombustible.Text = "Tipo de Combustible :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Kilometraje :"
        '
        'actxnComPrecGalon
        '
        Me.actxnComPrecGalon.ACEnteros = 9
        Me.actxnComPrecGalon.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnComPrecGalon.ACNegativo = True
        Me.actxnComPrecGalon.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnComPrecGalon.Location = New System.Drawing.Point(141, 166)
        Me.actxnComPrecGalon.MaxLength = 12
        Me.actxnComPrecGalon.Name = "actxnComPrecGalon"
        Me.actxnComPrecGalon.Size = New System.Drawing.Size(101, 23)
        Me.actxnComPrecGalon.TabIndex = 18
        Me.actxnComPrecGalon.Tag = "EV"
        Me.actxnComPrecGalon.Text = "0.00"
        Me.actxnComPrecGalon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnNuevConductor
        '
        Me.btnNuevConductor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevConductor.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnNuevConductor.Location = New System.Drawing.Point(1018, 58)
        Me.btnNuevConductor.Name = "btnNuevConductor"
        Me.btnNuevConductor.Size = New System.Drawing.Size(29, 27)
        Me.btnNuevConductor.TabIndex = 9
        Me.btnNuevConductor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevConductor.UseVisualStyleBackColor = True
        '
        'cmbComTipoCombustible
        '
        Me.cmbComTipoCombustible.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbComTipoCombustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComTipoCombustible.FormattingEnabled = True
        Me.cmbComTipoCombustible.Location = New System.Drawing.Point(141, 114)
        Me.cmbComTipoCombustible.Name = "cmbComTipoCombustible"
        Me.cmbComTipoCombustible.Size = New System.Drawing.Size(873, 23)
        Me.cmbComTipoCombustible.TabIndex = 14
        Me.cmbComTipoCombustible.Tag = "ECO"
        '
        'actxaDescConductor
        '
        Me.actxaDescConductor.ACActivarAyudaAuto = False
        Me.actxaDescConductor.ACLongitudAceptada = 0
        Me.actxaDescConductor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaDescConductor.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxaDescConductor.Location = New System.Drawing.Point(272, 60)
        Me.actxaDescConductor.MaxLength = 80
        Me.actxaDescConductor.Name = "actxaDescConductor"
        Me.actxaDescConductor.Size = New System.Drawing.Size(742, 23)
        Me.actxaDescConductor.TabIndex = 8
        Me.actxaDescConductor.Tag = "EVO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(558, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Precio Total :"
        '
        'actxnNumero
        '
        Me.actxnNumero.ACEnteros = 8
        Me.actxnNumero.ACFormato = "#######0"
        Me.actxnNumero.ACNegativo = True
        Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnNumero.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxnNumero.Location = New System.Drawing.Point(141, 4)
        Me.actxnNumero.MaxLength = 12
        Me.actxnNumero.Name = "actxnNumero"
        Me.actxnNumero.Size = New System.Drawing.Size(121, 26)
        Me.actxnNumero.TabIndex = 1
        Me.actxnNumero.Tag = "EVO"
        Me.actxnNumero.Text = "0"
        Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnTotal
        '
        Me.actxnTotal.ACEnteros = 9
        Me.actxnTotal.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnTotal.ACNegativo = True
        Me.actxnTotal.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTotal.Location = New System.Drawing.Point(643, 166)
        Me.actxnTotal.MaxLength = 12
        Me.actxnTotal.Name = "actxnTotal"
        Me.actxnTotal.Size = New System.Drawing.Size(101, 23)
        Me.actxnTotal.TabIndex = 22
        Me.actxnTotal.Tag = "EVO"
        Me.actxnTotal.Text = "0.00"
        Me.actxnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnComLitConsumidos
        '
        Me.actxnComLitConsumidos.ACDecimales = 4
        Me.actxnComLitConsumidos.ACEnteros = 8
        Me.actxnComLitConsumidos.ACFormato = "#####0.0000"
        Me.actxnComLitConsumidos.ACNegativo = True
        Me.actxnComLitConsumidos.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnComLitConsumidos.Location = New System.Drawing.Point(391, 166)
        Me.actxnComLitConsumidos.MaxLength = 12
        Me.actxnComLitConsumidos.Name = "actxnComLitConsumidos"
        Me.actxnComLitConsumidos.Size = New System.Drawing.Size(100, 23)
        Me.actxnComLitConsumidos.TabIndex = 20
        Me.actxnComLitConsumidos.Text = "0.0000"
        Me.actxnComLitConsumidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxaCodConductor
        '
        Me.actxaCodConductor.ACActivarAyudaAuto = False
        Me.actxaCodConductor.ACLongitudAceptada = 0
        Me.actxaCodConductor.Location = New System.Drawing.Point(141, 60)
        Me.actxaCodConductor.MaxLength = 14
        Me.actxaCodConductor.Name = "actxaCodConductor"
        Me.actxaCodConductor.Size = New System.Drawing.Size(121, 23)
        Me.actxaCodConductor.TabIndex = 7
        Me.actxaCodConductor.Tag = "EVO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Tipo Moneda :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(62, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Conductor :"
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(141, 140)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(255, 23)
        Me.cmbTipoMoneda.TabIndex = 16
        '
        'dtpFecConsumo
        '
        Me.dtpFecConsumo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecConsumo.Location = New System.Drawing.Point(141, 193)
        Me.dtpFecConsumo.Name = "dtpFecConsumo"
        Me.dtpFecConsumo.Size = New System.Drawing.Size(101, 23)
        Me.dtpFecConsumo.TabIndex = 24
        Me.dtpFecConsumo.Tag = "E"
        '
        'actxaNroDocProveedor
        '
        Me.actxaNroDocProveedor.ACActivarAyudaAuto = False
        Me.actxaNroDocProveedor.ACLongitudAceptada = 0
        Me.actxaNroDocProveedor.Location = New System.Drawing.Point(141, 33)
        Me.actxaNroDocProveedor.MaxLength = 14
        Me.actxaNroDocProveedor.Name = "actxaNroDocProveedor"
        Me.actxaNroDocProveedor.Size = New System.Drawing.Size(121, 23)
        Me.actxaNroDocProveedor.TabIndex = 3
        Me.actxaNroDocProveedor.Tag = "EVO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 15)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Fec&ha Consumo :"
        '
        'actxaDescProveedor
        '
        Me.actxaDescProveedor.ACActivarAyudaAuto = False
        Me.actxaDescProveedor.ACLongitudAceptada = 0
        Me.actxaDescProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaDescProveedor.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxaDescProveedor.Location = New System.Drawing.Point(272, 33)
        Me.actxaDescProveedor.MaxLength = 80
        Me.actxaDescProveedor.Name = "actxaDescProveedor"
        Me.actxaDescProveedor.Size = New System.Drawing.Size(743, 23)
        Me.actxaDescProveedor.TabIndex = 4
        Me.actxaDescProveedor.Tag = "EVO"
        '
        'dtpFecViaje
        '
        Me.dtpFecViaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecViaje.Location = New System.Drawing.Point(142, 221)
        Me.dtpFecViaje.Name = "dtpFecViaje"
        Me.dtpFecViaje.Size = New System.Drawing.Size(101, 23)
        Me.dtpFecViaje.TabIndex = 26
        Me.dtpFecViaje.Tag = "E"
        '
        'btnNueProveedor
        '
        Me.btnNueProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNueProveedor.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnNueProveedor.Location = New System.Drawing.Point(1018, 31)
        Me.btnNueProveedor.Name = "btnNueProveedor"
        Me.btnNueProveedor.Size = New System.Drawing.Size(29, 27)
        Me.btnNueProveedor.TabIndex = 5
        Me.btnNueProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNueProveedor.UseVisualStyleBackColor = True
        '
        'AcPanelCaption1
        '
        Me.AcPanelCaption1.ACCaption = "Registro de Consumo de Combustible"
        Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption1.Name = "AcPanelCaption1"
        Me.AcPanelCaption1.Size = New System.Drawing.Size(1052, 30)
        Me.AcPanelCaption1.TabIndex = 29
        '
        'tabBusqueda
        '
        Me.tabBusqueda.Controls.Add(Me.c1grdBusqueda)
        Me.tabBusqueda.Controls.Add(Me.bnavBusqueda)
        Me.tabBusqueda.Controls.Add(Me.grpBusqueda)
        Me.tabBusqueda.Controls.Add(Me.acpnlTitulo)
        Me.tabBusqueda.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Location = New System.Drawing.Point(1, 1)
        Me.tabBusqueda.Name = "tabBusqueda"
        Me.tabBusqueda.SelectBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Selected = False
        Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Size = New System.Drawing.Size(1052, 577)
        Me.tabBusqueda.TabIndex = 5
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'c1grdBusqueda
        '
        Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 91)
        Me.c1grdBusqueda.Name = "c1grdBusqueda"
        Me.c1grdBusqueda.Rows.Count = 2
        Me.c1grdBusqueda.Rows.DefaultSize = 20
        Me.c1grdBusqueda.Size = New System.Drawing.Size(1052, 461)
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
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 552)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(1052, 25)
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
        'grpBusqueda
        '
        Me.grpBusqueda.Controls.Add(Me.btnProcesar)
        Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
        Me.grpBusqueda.Controls.Add(Me.rbtnPlaca)
        Me.grpBusqueda.Controls.Add(Me.rbtnCodigo)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 30)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(1052, 61)
        Me.grpBusqueda.TabIndex = 1
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'btnProcesar
        '
        Me.btnProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Image = Global.ACPTransportes.My.Resources.Resources.CheckProcess_32x32
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(921, 14)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(120, 41)
        Me.btnProcesar.TabIndex = 8
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = True
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
        Me.txtBusqueda.Size = New System.Drawing.Size(779, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'rbtnPlaca
        '
        Me.rbtnPlaca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnPlaca.AutoSize = True
        Me.rbtnPlaca.Checked = True
        Me.rbtnPlaca.Location = New System.Drawing.Point(820, 36)
        Me.rbtnPlaca.Name = "rbtnPlaca"
        Me.rbtnPlaca.Size = New System.Drawing.Size(74, 19)
        Me.rbtnPlaca.TabIndex = 6
        Me.rbtnPlaca.TabStop = True
        Me.rbtnPlaca.Text = "Por Placa"
        Me.rbtnPlaca.UseVisualStyleBackColor = True
        '
        'rbtnCodigo
        '
        Me.rbtnCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnCodigo.AutoSize = True
        Me.rbtnCodigo.Location = New System.Drawing.Point(820, 13)
        Me.rbtnCodigo.Name = "rbtnCodigo"
        Me.rbtnCodigo.Size = New System.Drawing.Size(85, 19)
        Me.rbtnCodigo.TabIndex = 5
        Me.rbtnCodigo.Text = "Por Codigo"
        Me.rbtnCodigo.UseVisualStyleBackColor = True
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Busqueda de Vehiculos"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(1052, 30)
        Me.acpnlTitulo.TabIndex = 13
        '
        'tabBusConsumos
        '
        Me.tabBusConsumos.Controls.Add(Me.c1grdBusConsumos)
        Me.tabBusConsumos.Controls.Add(Me.GroupBox1)
        Me.tabBusConsumos.Controls.Add(Me.bnavBusConsumos)
        Me.tabBusConsumos.Controls.Add(Me.AcPanelCaption3)
        Me.tabBusConsumos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabBusConsumos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabBusConsumos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabBusConsumos.Location = New System.Drawing.Point(1, 1)
        Me.tabBusConsumos.Name = "tabBusConsumos"
        Me.tabBusConsumos.SelectBackColor = System.Drawing.Color.Empty
        Me.tabBusConsumos.Selected = False
        Me.tabBusConsumos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabBusConsumos.SelectTextColor = System.Drawing.Color.Empty
        Me.tabBusConsumos.Size = New System.Drawing.Size(1052, 577)
        Me.tabBusConsumos.TabIndex = 6
        Me.tabBusConsumos.ToolTip = "Page"
        '
        'c1grdBusConsumos
        '
        Me.c1grdBusConsumos.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdBusConsumos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdBusConsumos.Location = New System.Drawing.Point(0, 104)
        Me.c1grdBusConsumos.Name = "c1grdBusConsumos"
        Me.c1grdBusConsumos.Rows.Count = 2
        Me.c1grdBusConsumos.Rows.DefaultSize = 20
        Me.c1grdBusConsumos.Size = New System.Drawing.Size(1052, 448)
        Me.c1grdBusConsumos.StyleInfo = resources.GetString("c1grdBusConsumos.StyleInfo")
        Me.c1grdBusConsumos.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtnProveedor)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.actxaBusqueda)
        Me.GroupBox1.Controls.Add(Me.chkMostrarTodos)
        Me.GroupBox1.Controls.Add(Me.rbtnConductor)
        Me.GroupBox1.Controls.Add(Me.rbtnPlacaVehiculo)
        Me.GroupBox1.Controls.Add(Me.AcFecha)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1052, 74)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones de Busqueda"
        '
        'rbtnProveedor
        '
        Me.rbtnProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnProveedor.AutoSize = True
        Me.rbtnProveedor.Location = New System.Drawing.Point(493, 19)
        Me.rbtnProveedor.Name = "rbtnProveedor"
        Me.rbtnProveedor.Size = New System.Drawing.Size(79, 19)
        Me.rbtnProveedor.TabIndex = 34
        Me.rbtnProveedor.Text = "Proveedor"
        Me.rbtnProveedor.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(610, 9)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 44)
        Me.btnConsultar.TabIndex = 33
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'actxaBusqueda
        '
        Me.actxaBusqueda.ACActivarAyudaAuto = False
        Me.actxaBusqueda.ACLongitudAceptada = 0
        Me.actxaBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaBusqueda.Location = New System.Drawing.Point(6, 44)
        Me.actxaBusqueda.MaxLength = 32767
        Me.actxaBusqueda.Name = "actxaBusqueda"
        Me.actxaBusqueda.Size = New System.Drawing.Size(594, 23)
        Me.actxaBusqueda.TabIndex = 0
        '
        'chkMostrarTodos
        '
        Me.chkMostrarTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMostrarTodos.AutoSize = True
        Me.chkMostrarTodos.Location = New System.Drawing.Point(940, 49)
        Me.chkMostrarTodos.Name = "chkMostrarTodos"
        Me.chkMostrarTodos.Size = New System.Drawing.Size(101, 19)
        Me.chkMostrarTodos.TabIndex = 28
        Me.chkMostrarTodos.Text = "Mostrar Todos"
        Me.chkMostrarTodos.UseVisualStyleBackColor = True
        '
        'rbtnConductor
        '
        Me.rbtnConductor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnConductor.AutoSize = True
        Me.rbtnConductor.Checked = True
        Me.rbtnConductor.Location = New System.Drawing.Point(281, 19)
        Me.rbtnConductor.Name = "rbtnConductor"
        Me.rbtnConductor.Size = New System.Drawing.Size(82, 19)
        Me.rbtnConductor.TabIndex = 27
        Me.rbtnConductor.TabStop = True
        Me.rbtnConductor.Text = "Conductor"
        Me.rbtnConductor.UseVisualStyleBackColor = True
        '
        'rbtnPlacaVehiculo
        '
        Me.rbtnPlacaVehiculo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnPlacaVehiculo.AutoSize = True
        Me.rbtnPlacaVehiculo.Location = New System.Drawing.Point(378, 19)
        Me.rbtnPlacaVehiculo.Name = "rbtnPlacaVehiculo"
        Me.rbtnPlacaVehiculo.Size = New System.Drawing.Size(101, 19)
        Me.rbtnPlacaVehiculo.TabIndex = 26
        Me.rbtnPlacaVehiculo.Text = "Placa Vehiculo"
        Me.rbtnPlacaVehiculo.UseVisualStyleBackColor = True
        '
        'AcFecha
        '
        Me.AcFecha.ACFecha_A = New Date(2021, 9, 15, 15, 2, 13, 205)
        Me.AcFecha.ACFecha_De = New Date(2021, 9, 15, 15, 2, 13, 202)
        Me.AcFecha.ACFechaObligatoria = True
        Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
        Me.AcFecha.ACHoyChecked = False
        Me.AcFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AcFecha.Location = New System.Drawing.Point(715, 0)
        Me.AcFecha.MaximumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.MinimumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.Name = "AcFecha"
        Me.AcFecha.Size = New System.Drawing.Size(337, 43)
        Me.AcFecha.TabIndex = 25
        Me.AcFecha.TabStop = False
        '
        'bnavBusConsumos
        '
        Me.bnavBusConsumos.AddNewItem = Me.ToolStripButton7
        Me.bnavBusConsumos.CountItem = Me.ToolStripLabel2
        Me.bnavBusConsumos.DeleteItem = Me.ToolStripButton8
        Me.bnavBusConsumos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavBusConsumos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton9, Me.ToolStripButton10, Me.ToolStripSeparator4, Me.ToolStripTextBox2, Me.ToolStripLabel2, Me.ToolStripSeparator5, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator6, Me.ToolStripButton7, Me.ToolStripButton8})
        Me.bnavBusConsumos.Location = New System.Drawing.Point(0, 552)
        Me.bnavBusConsumos.MoveFirstItem = Me.ToolStripButton9
        Me.bnavBusConsumos.MoveLastItem = Me.ToolStripButton12
        Me.bnavBusConsumos.MoveNextItem = Me.ToolStripButton11
        Me.bnavBusConsumos.MovePreviousItem = Me.ToolStripButton10
        Me.bnavBusConsumos.Name = "bnavBusConsumos"
        Me.bnavBusConsumos.PositionItem = Me.ToolStripTextBox2
        Me.bnavBusConsumos.Size = New System.Drawing.Size(1052, 25)
        Me.bnavBusConsumos.TabIndex = 16
        Me.bnavBusConsumos.Text = "BindingNavigator1"
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
        Me.ToolStripLabel2.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel2.Text = "of {0}"
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption3
        '
        Me.AcPanelCaption3.ACCaption = "Busqueda de Consumo de Combustible"
        Me.AcPanelCaption3.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption3.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption3.Name = "AcPanelCaption3"
        Me.AcPanelCaption3.Size = New System.Drawing.Size(1052, 30)
        Me.AcPanelCaption3.TabIndex = 17
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
        Me.acTool.Location = New System.Drawing.Point(0, 602)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(1054, 56)
        Me.acTool.TabIndex = 14
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'PConCombustible
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 658)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acTool)
        Me.Name = "PConCombustible"
        Me.Text = "Registro de Consumo de Combustible"
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.c1grdConsumos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavConsumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavConsumos.ResumeLayout(False)
        Me.bnavConsumos.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.c1grdDocsPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabBusqueda.ResumeLayout(False)
        Me.tabBusqueda.PerformLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavBusqueda.ResumeLayout(False)
        Me.bnavBusqueda.PerformLayout()
        Me.grpBusqueda.ResumeLayout(False)
        Me.grpBusqueda.PerformLayout()
        Me.tabBusConsumos.ResumeLayout(False)
        Me.tabBusConsumos.PerformLayout()
        CType(Me.c1grdBusConsumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.bnavBusConsumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavBusConsumos.ResumeLayout(False)
        Me.bnavBusConsumos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
   Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents pnlDatos As System.Windows.Forms.Panel
   Friend WithEvents dtpFecViaje As System.Windows.Forms.DateTimePicker
   Friend WithEvents btnNueProveedor As System.Windows.Forms.Button
   Friend WithEvents actxaDescProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaNroDocProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents actxnComLitConsumidos As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnTotal As ACControles.ACTextBoxNumerico
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmbComTipoCombustible As System.Windows.Forms.ComboBox
   Friend WithEvents actxnComPrecGalon As ACControles.ACTextBoxNumerico
   Friend WithEvents lblTipoCombustible As System.Windows.Forms.Label
   Friend WithEvents lblProveedor As System.Windows.Forms.Label
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents Label19 As System.Windows.Forms.Label
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
   Friend WithEvents rbtnPlaca As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnCodigo As System.Windows.Forms.RadioButton
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents actxnKilometraje As ACControles.ACTextBoxNumerico
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents btnNuevConductor As System.Windows.Forms.Button
   Friend WithEvents actxaDescConductor As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaCodConductor As ACControles.ACTextBoxAyuda
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents dtpFecConsumo As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents actxaDescVehiculo As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaCodVehiculo As ACControles.ACTextBoxAyuda
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents btnProcesar As System.Windows.Forms.Button
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents tabBusConsumos As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents c1grdBusConsumos As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavBusConsumos As System.Windows.Forms.BindingNavigator
   Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents AcPanelCaption3 As ACControles.ACPanelCaption
   Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As System.Windows.Forms.Button
   Friend WithEvents actxaBusqueda As ACControles.ACTextBoxAyuda
   Friend WithEvents chkMostrarTodos As System.Windows.Forms.CheckBox
   Friend WithEvents rbtnConductor As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnPlacaVehiculo As System.Windows.Forms.RadioButton
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents rbtnProveedor As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents txtSerie As System.Windows.Forms.TextBox
   Friend WithEvents AcTextBoxNumerico1 As ACControles.ACTextBoxNumerico
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
   Friend WithEvents cmbGuia As System.Windows.Forms.ComboBox
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents c1grdConsumos As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavConsumos As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents tsbtnAnularRegistro As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbtnExcel As System.Windows.Forms.ToolStripButton
   Friend WithEvents AcPanelCaption2 As ACControles.ACPanelCaption
   Friend WithEvents Panel4 As System.Windows.Forms.Panel
   Private WithEvents c1grdDocsPago As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Private WithEvents tsbtnNuevoTPago As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents tsbtnAgregarTPago As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents AcPanelCaption4 As ACControles.ACPanelCaption
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents txtnumeroentero As ACControles.ACTextBoxNumerico
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents actxtotal As ACControles.ACTextBoxNumerico
   Friend WithEvents actxtsub As ACControles.ACTextBoxNumerico
End Class
