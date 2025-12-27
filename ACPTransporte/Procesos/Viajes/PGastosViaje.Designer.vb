<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PGastosViaje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PGastosViaje))
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.cmbPendiente = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.dtpFecViaje = New System.Windows.Forms.DateTimePicker()
        Me.chkComprobante = New System.Windows.Forms.CheckBox()
        Me.cmbTipoGasto = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.actxnMonto = New ACControles.ACTextBoxNumerico()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpComprobante = New System.Windows.Forms.GroupBox()
        Me.btnNueProveedor = New System.Windows.Forms.Button()
        Me.actxaDescProveedor = New ACControles.ACTextBoxAyuda()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.actxaNroDocProveedor = New ACControles.ACTextBoxAyuda()
        Me.grpDocumento = New System.Windows.Forms.GroupBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.cmbGuia = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.actxnNumero = New ACControles.ACTextBoxNumerico()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
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
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.tabMantenimiento.SuspendLayout
        Me.tabDatos.SuspendLayout
        Me.pnlDatos.SuspendLayout
        Me.grpComprobante.SuspendLayout
        Me.grpDocumento.SuspendLayout
        Me.tabBusqueda.SuspendLayout
        CType(Me.c1grdBusqueda,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bnavBusqueda,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavBusqueda.SuspendLayout
        Me.grpBusqueda.SuspendLayout
        Me.SuspendLayout
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 30)
        Me.tabMantenimiento.MediaPlayerDockSides = false
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = false
        Me.tabMantenimiento.SelectedIndex = 0
        Me.tabMantenimiento.ShowDropSelect = false
        Me.tabMantenimiento.Size = New System.Drawing.Size(594, 327)
        Me.tabMantenimiento.TabIndex = 18
        Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos, Me.tabBusqueda})
        Me.tabMantenimiento.TextTips = true
        '
        'tabDatos
        '
        Me.tabDatos.Controls.Add(Me.pnlDatos)
        Me.tabDatos.Controls.Add(Me.grpComprobante)
        Me.tabDatos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Location = New System.Drawing.Point(1, 1)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Size = New System.Drawing.Size(592, 302)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.cmbPendiente)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.CheckBox1)
        Me.pnlDatos.Controls.Add(Me.dtpFecViaje)
        Me.pnlDatos.Controls.Add(Me.chkComprobante)
        Me.pnlDatos.Controls.Add(Me.cmbTipoGasto)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.cmbTipoMoneda)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.actxnMonto)
        Me.pnlDatos.Controls.Add(Me.txtDescripcion)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(592, 193)
        Me.pnlDatos.TabIndex = 1
        '
        'cmbPendiente
        '
        Me.cmbPendiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPendiente.FormattingEnabled = true
        Me.cmbPendiente.Location = New System.Drawing.Point(115, 5)
        Me.cmbPendiente.Name = "cmbPendiente"
        Me.cmbPendiente.Size = New System.Drawing.Size(464, 23)
        Me.cmbPendiente.TabIndex = 1
        Me.cmbPendiente.Tag = "EO"
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(41, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Pendiente :"
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(63, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Fecha :"
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = true
        Me.CheckBox1.Location = New System.Drawing.Point(474, 178)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(105, 19)
        Me.CheckBox1.TabIndex = 13
        Me.CheckBox1.Text = "Comprobantes"
        Me.CheckBox1.UseVisualStyleBackColor = true
        '
        'dtpFecViaje
        '
        Me.dtpFecViaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecViaje.Location = New System.Drawing.Point(115, 148)
        Me.dtpFecViaje.Name = "dtpFecViaje"
        Me.dtpFecViaje.Size = New System.Drawing.Size(96, 23)
        Me.dtpFecViaje.TabIndex = 11
        '
        'chkComprobante
        '
        Me.chkComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.chkComprobante.AutoSize = true
        Me.chkComprobante.Location = New System.Drawing.Point(27, 176)
        Me.chkComprobante.Name = "chkComprobante"
        Me.chkComprobante.Size = New System.Drawing.Size(146, 19)
        Me.chkComprobante.TabIndex = 12
        Me.chkComprobante.Text = "Comprobante de Pago"
        Me.chkComprobante.UseVisualStyleBackColor = true
        '
        'cmbTipoGasto
        '
        Me.cmbTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoGasto.FormattingEnabled = true
        Me.cmbTipoGasto.Location = New System.Drawing.Point(115, 33)
        Me.cmbTipoGasto.Name = "cmbTipoGasto"
        Me.cmbTipoGasto.Size = New System.Drawing.Size(238, 23)
        Me.cmbTipoGasto.TabIndex = 3
        Me.cmbTipoGasto.Tag = "EO"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(37, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo Gasto :"
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMoneda.FormattingEnabled = true
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(359, 122)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(220, 23)
        Me.cmbTipoMoneda.TabIndex = 9
        Me.cmbTipoMoneda.Tag = "EO"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(278, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tipo Moneda :"
        '
        'actxnMonto
        '
        Me.actxnMonto.ACEnteros = 9
        Me.actxnMonto.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnMonto.ACFormato = "########0.00"
        Me.actxnMonto.ACNegativo = true
        Me.actxnMonto.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnMonto.Location = New System.Drawing.Point(115, 122)
        Me.actxnMonto.MaxLength = 12
        Me.actxnMonto.Name = "actxnMonto"
        Me.actxnMonto.Size = New System.Drawing.Size(99, 23)
        Me.actxnMonto.TabIndex = 7
        Me.actxnMonto.Tag = "ENO"
        Me.actxnMonto.Text = "0.00"
        Me.actxnMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(115, 60)
        Me.txtDescripcion.MaxLength = 120
        Me.txtDescripcion.Multiline = true
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(464, 56)
        Me.txtDescripcion.TabIndex = 5
        Me.txtDescripcion.Tag = "EVO"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(32, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Descripción :"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(58, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Monto :"
        '
        'grpComprobante
        '
        Me.grpComprobante.Controls.Add(Me.btnNueProveedor)
        Me.grpComprobante.Controls.Add(Me.actxaDescProveedor)
        Me.grpComprobante.Controls.Add(Me.lblProveedor)
        Me.grpComprobante.Controls.Add(Me.actxaNroDocProveedor)
        Me.grpComprobante.Controls.Add(Me.grpDocumento)
        Me.grpComprobante.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpComprobante.Enabled = false
        Me.grpComprobante.Location = New System.Drawing.Point(0, 193)
        Me.grpComprobante.Name = "grpComprobante"
        Me.grpComprobante.Size = New System.Drawing.Size(592, 109)
        Me.grpComprobante.TabIndex = 2
        Me.grpComprobante.TabStop = false
        '
        'btnNueProveedor
        '
        Me.btnNueProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnNueProveedor.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnNueProveedor.Location = New System.Drawing.Point(552, 20)
        Me.btnNueProveedor.Name = "btnNueProveedor"
        Me.btnNueProveedor.Size = New System.Drawing.Size(29, 27)
        Me.btnNueProveedor.TabIndex = 3
        Me.btnNueProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNueProveedor.UseVisualStyleBackColor = true
        '
        'actxaDescProveedor
        '
        Me.actxaDescProveedor.ACActivarAyudaAuto = false
        Me.actxaDescProveedor.ACLongitudAceptada = 0
        Me.actxaDescProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.actxaDescProveedor.Font = New System.Drawing.Font("Tahoma", 13!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxaDescProveedor.Location = New System.Drawing.Point(207, 22)
        Me.actxaDescProveedor.MaxLength = 80
        Me.actxaDescProveedor.Name = "actxaDescProveedor"
        Me.actxaDescProveedor.Size = New System.Drawing.Size(342, 23)
        Me.actxaDescProveedor.TabIndex = 2
        Me.actxaDescProveedor.Tag = "EVO"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = true
        Me.lblProveedor.Location = New System.Drawing.Point(9, 27)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(67, 15)
        Me.lblProveedor.TabIndex = 0
        Me.lblProveedor.Text = "Proveedor :"
        '
        'actxaNroDocProveedor
        '
        Me.actxaNroDocProveedor.ACActivarAyudaAuto = false
        Me.actxaNroDocProveedor.ACLongitudAceptada = 0
        Me.actxaNroDocProveedor.Location = New System.Drawing.Point(80, 23)
        Me.actxaNroDocProveedor.MaxLength = 14
        Me.actxaNroDocProveedor.Name = "actxaNroDocProveedor"
        Me.actxaNroDocProveedor.Size = New System.Drawing.Size(121, 23)
        Me.actxaNroDocProveedor.TabIndex = 1
        Me.actxaNroDocProveedor.Tag = "EVO"
        '
        'grpDocumento
        '
        Me.grpDocumento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpDocumento.Controls.Add(Me.txtSerie)
        Me.grpDocumento.Controls.Add(Me.lblTipoDocumento)
        Me.grpDocumento.Controls.Add(Me.cmbGuia)
        Me.grpDocumento.Controls.Add(Me.Label7)
        Me.grpDocumento.Controls.Add(Me.dtpFecha)
        Me.grpDocumento.Controls.Add(Me.actxnNumero)
        Me.grpDocumento.Controls.Add(Me.Label4)
        Me.grpDocumento.Controls.Add(Me.Label6)
        Me.grpDocumento.Location = New System.Drawing.Point(3, 50)
        Me.grpDocumento.Name = "grpDocumento"
        Me.grpDocumento.Size = New System.Drawing.Size(576, 56)
        Me.grpDocumento.TabIndex = 4
        Me.grpDocumento.TabStop = false
        '
        'txtSerie
        '
        Me.txtSerie.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtSerie.Location = New System.Drawing.Point(374, 26)
        Me.txtSerie.MaxLength = 5
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(60, 23)
        Me.txtSerie.TabIndex = 5
        Me.txtSerie.Tag = "EVO"
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.AutoSize = true
        Me.lblTipoDocumento.Location = New System.Drawing.Point(119, 10)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(96, 15)
        Me.lblTipoDocumento.TabIndex = 2
        Me.lblTipoDocumento.Text = "Tipo Documento"
        '
        'cmbGuia
        '
        Me.cmbGuia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cmbGuia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGuia.FormattingEnabled = true
        Me.cmbGuia.Items.AddRange(New Object() {"Boleta", "Factura"})
        Me.cmbGuia.Location = New System.Drawing.Point(114, 26)
        Me.cmbGuia.Name = "cmbGuia"
        Me.cmbGuia.Size = New System.Drawing.Size(255, 23)
        Me.cmbGuia.TabIndex = 3
        Me.cmbGuia.Tag = "ECO"
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(12, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Fecha :"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(9, 26)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(99, 23)
        Me.dtpFecha.TabIndex = 1
        '
        'actxnNumero
        '
        Me.actxnNumero.ACEnteros = 8
        Me.actxnNumero.ACFormato = "#######0"
        Me.actxnNumero.ACNegativo = true
        Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.actxnNumero.Location = New System.Drawing.Point(441, 26)
        Me.actxnNumero.MaxLength = 7
        Me.actxnNumero.Name = "actxnNumero"
        Me.actxnNumero.Size = New System.Drawing.Size(127, 23)
        Me.actxnNumero.TabIndex = 7
        Me.actxnNumero.Tag = "ENO"
        Me.actxnNumero.Text = "0"
        Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(447, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Numero"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(379, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 15)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Serie"
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
        Me.tabBusqueda.Selected = false
        Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Size = New System.Drawing.Size(592, 302)
        Me.tabBusqueda.TabIndex = 5
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'c1grdBusqueda
        '
        Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 51)
        Me.c1grdBusqueda.Name = "c1grdBusqueda"
        Me.c1grdBusqueda.Rows.Count = 2
        Me.c1grdBusqueda.Rows.DefaultSize = 20
        Me.c1grdBusqueda.Size = New System.Drawing.Size(592, 226)
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
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 277)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(592, 25)
        Me.bnavBusqueda.TabIndex = 3
        Me.bnavBusqueda.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        Me.BindingNavigatorAddNewItem.Visible = false
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
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        Me.BindingNavigatorDeleteItem.Visible = false
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true
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
        Me.BindingNavigatorPositionItem.AutoSize = false
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
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true
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
        Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(592, 51)
        Me.grpBusqueda.TabIndex = 1
        Me.grpBusqueda.TabStop = false
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'txtBusqueda
        '
        Me.txtBusqueda.ACActivarAyudaAuto = false
        Me.txtBusqueda.ACLongitudAceptada = 0
        Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda.Location = New System.Drawing.Point(17, 20)
        Me.txtBusqueda.MaxLength = 32767
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(564, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Gastos de Viaje"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(594, 30)
        Me.acpnlTitulo.TabIndex = 17
        '
        'acTool
        '
        Me.acTool.ACBtnAnularEnabled = false
        Me.acTool.ACBtnAnularVisible = false
        Me.acTool.ACBtnBuscarEnabled = false
        Me.acTool.ACBtnBuscarVisible = false
        Me.acTool.ACBtnCancelarEnabled = false
        Me.acTool.ACBtnCancelarVisible = false
        Me.acTool.ACBtnEliminarEnabled = false
        Me.acTool.ACBtnEliminarVisible = false
        Me.acTool.ACBtnGrabarEnabled = false
        Me.acTool.ACBtnGrabarVisible = false
        Me.acTool.ACBtnImprimirEnabled = false
        Me.acTool.ACBtnImprimirVisible = false
        Me.acTool.ACBtnRehusarEnabled = false
        Me.acTool.ACBtnRehusarVisible = false
        Me.acTool.ACBtnReporteEnabled = false
        Me.acTool.ACBtnReporteVisible = false
        Me.acTool.ACBtnSalirText = "&Salir"
        Me.acTool.ACBtnVolverEnabled = false
        Me.acTool.ACBtnVolverVisible = false
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabar
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.acTool.Location = New System.Drawing.Point(0, 357)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(594, 56)
        Me.acTool.TabIndex = 19
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'PGastosViaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 413)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Controls.Add(Me.acTool)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PGastosViaje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gastos de Viaje"
        Me.tabMantenimiento.ResumeLayout(false)
        Me.tabDatos.ResumeLayout(false)
        Me.pnlDatos.ResumeLayout(false)
        Me.pnlDatos.PerformLayout
        Me.grpComprobante.ResumeLayout(false)
        Me.grpComprobante.PerformLayout
        Me.grpDocumento.ResumeLayout(false)
        Me.grpDocumento.PerformLayout
        Me.tabBusqueda.ResumeLayout(false)
        Me.tabBusqueda.PerformLayout
        CType(Me.c1grdBusqueda,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bnavBusqueda,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavBusqueda.ResumeLayout(false)
        Me.bnavBusqueda.PerformLayout
        Me.grpBusqueda.ResumeLayout(false)
        Me.grpBusqueda.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

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
   Friend WithEvents cmbTipoGasto As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents actxnMonto As ACControles.ACTextBoxNumerico
   Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents grpComprobante As System.Windows.Forms.GroupBox
   Friend WithEvents btnNueProveedor As System.Windows.Forms.Button
   Friend WithEvents actxaDescProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents lblProveedor As System.Windows.Forms.Label
   Friend WithEvents actxaNroDocProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents grpDocumento As System.Windows.Forms.GroupBox
   Friend WithEvents txtSerie As System.Windows.Forms.TextBox
   Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
   Friend WithEvents cmbGuia As System.Windows.Forms.ComboBox
   Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents chkComprobante As System.Windows.Forms.CheckBox
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents dtpFecViaje As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmbPendiente As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
