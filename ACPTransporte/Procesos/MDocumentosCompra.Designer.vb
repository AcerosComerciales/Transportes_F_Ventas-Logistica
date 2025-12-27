<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDocumentosCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDocumentosCompra))
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.c1grdDetalle = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pnlPedSeparacion = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.actxnTotalPagarOld = New ACControles.ACTextBoxNumerico()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.actxnIGVOld = New ACControles.ACTextBoxNumerico()
        Me.actxnImporteOld = New ACControles.ACTextBoxNumerico()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlItem = New System.Windows.Forms.Panel()
        Me.chkPrecIGV = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.actxnPrecIGV = New ACControles.ACTextBoxNumerico()
        Me.actxaDescripcion = New ACControles.ACTextBoxAyuda()
        Me.actxnDescuento = New ACControles.ACTextBoxNumerico()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.actxnPrecio = New ACControles.ACTextBoxNumerico()
        Me.txtOpcion = New System.Windows.Forms.TextBox()
        Me.actxnSubImporte = New ACControles.ACTextBoxNumerico()
        Me.actxnProdCantidad = New ACControles.ACTextBoxNumerico()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.actxaProdCodigo = New ACControles.ACTextBoxAyuda()
        Me.bnavProductos = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.actxnImporte = New ACControles.ACTextBoxNumerico()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lblTotalPagar = New System.Windows.Forms.Label()
        Me.lbligv = New System.Windows.Forms.Label()
        Me.actxnTotalPagar = New ACControles.ACTextBoxNumerico()
        Me.actxnIGV = New ACControles.ACTextBoxNumerico()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.dtpFecIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkIncluidoIGV = New System.Windows.Forms.CheckBox()
        Me.btnNueTransportista = New System.Windows.Forms.Button()
        Me.actxaDescProveedor = New ACControles.ACTextBoxAyuda()
        Me.actxaNroDocProveedor = New ACControles.ACTextBoxAyuda()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.actxnNumero = New ACControles.ACTextBoxNumerico()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.cmbDocumento = New System.Windows.Forms.ComboBox()
        Me.dtpFecEmision = New System.Windows.Forms.DateTimePicker()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.c1grdBusqueda = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavBusqueda = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.grpBusqueda = New System.Windows.Forms.GroupBox()
        Me.rbtnNroDocumento = New System.Windows.Forms.RadioButton()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.rbtnProveedor = New System.Windows.Forms.RadioButton()
        Me.AcFecha = New ACControles.ACFecha(Me.components)
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.actsbtnSeleccionar = New ACControles.ACToolStripButton(Me.components)
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.pnlDetalle.SuspendLayout()
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPedSeparacion.SuspendLayout()
        Me.pnlItem.SuspendLayout()
        CType(Me.bnavProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavProductos.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.tabBusqueda.SuspendLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavBusqueda.SuspendLayout()
        Me.grpBusqueda.SuspendLayout()
        Me.acTool.SuspendLayout()
        Me.SuspendLayout()
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Documento de Compra"
        Me.acpnlTitulo.BackColor = System.Drawing.Color.Red
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.acpnlTitulo.InactiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.acpnlTitulo.InactiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(784, 28)
        Me.acpnlTitulo.TabIndex = 2
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabMantenimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 28)
        Me.tabMantenimiento.MediaPlayerDockSides = False
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = False
        Me.tabMantenimiento.SelectedIndex = 0
        Me.tabMantenimiento.ShowDropSelect = False
        Me.tabMantenimiento.Size = New System.Drawing.Size(784, 378)
        Me.tabMantenimiento.TabIndex = 3
        Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos, Me.tabBusqueda})
        Me.tabMantenimiento.TextTips = True
        '
        'tabDatos
        '
        Me.tabDatos.Controls.Add(Me.pnlDetalle)
        Me.tabDatos.Controls.Add(Me.pnlPie)
        Me.tabDatos.Controls.Add(Me.pnlCabecera)
        Me.tabDatos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Location = New System.Drawing.Point(1, 1)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Size = New System.Drawing.Size(782, 353)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Controls.Add(Me.c1grdDetalle)
        Me.pnlDetalle.Controls.Add(Me.pnlPedSeparacion)
        Me.pnlDetalle.Controls.Add(Me.pnlItem)
        Me.pnlDetalle.Controls.Add(Me.bnavProductos)
        Me.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetalle.Location = New System.Drawing.Point(0, 120)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(782, 194)
        Me.pnlDetalle.TabIndex = 2
        '
        'c1grdDetalle
        '
        Me.c1grdDetalle.BackColor = System.Drawing.Color.White
        Me.c1grdDetalle.ColumnInfo = "2,1,0,0,0,105,Columns:0{Width:18;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:107;Caption:""Codigo"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdDetalle.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdDetalle.Location = New System.Drawing.Point(0, 51)
        Me.c1grdDetalle.Name = "c1grdDetalle"
        Me.c1grdDetalle.Rows.Count = 2
        Me.c1grdDetalle.Rows.DefaultSize = 21
        Me.c1grdDetalle.Size = New System.Drawing.Size(519, 118)
        Me.c1grdDetalle.StyleInfo = resources.GetString("c1grdDetalle.StyleInfo")
        Me.c1grdDetalle.TabIndex = 1
        '
        'pnlPedSeparacion
        '
        Me.pnlPedSeparacion.Controls.Add(Me.Label11)
        Me.pnlPedSeparacion.Controls.Add(Me.actxnTotalPagarOld)
        Me.pnlPedSeparacion.Controls.Add(Me.Label8)
        Me.pnlPedSeparacion.Controls.Add(Me.actxnIGVOld)
        Me.pnlPedSeparacion.Controls.Add(Me.actxnImporteOld)
        Me.pnlPedSeparacion.Controls.Add(Me.Label7)
        Me.pnlPedSeparacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlPedSeparacion.Location = New System.Drawing.Point(519, 51)
        Me.pnlPedSeparacion.Name = "pnlPedSeparacion"
        Me.pnlPedSeparacion.Size = New System.Drawing.Size(263, 118)
        Me.pnlPedSeparacion.TabIndex = 25
        Me.pnlPedSeparacion.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label11.Location = New System.Drawing.Point(43, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 17)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Total Pagar : {0}"
        '
        'actxnTotalPagarOld
        '
        Me.actxnTotalPagarOld.ACEnteros = 9
        Me.actxnTotalPagarOld.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTotalPagarOld.ACNegativo = True
        Me.actxnTotalPagarOld.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnTotalPagarOld.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnTotalPagarOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnTotalPagarOld.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxnTotalPagarOld.Location = New System.Drawing.Point(157, 64)
        Me.actxnTotalPagarOld.MaxLength = 12
        Me.actxnTotalPagarOld.Name = "actxnTotalPagarOld"
        Me.actxnTotalPagarOld.ReadOnly = True
        Me.actxnTotalPagarOld.Size = New System.Drawing.Size(100, 26)
        Me.actxnTotalPagarOld.TabIndex = 11
        Me.actxnTotalPagarOld.Tag = "ENO"
        Me.actxnTotalPagarOld.Text = "0.00"
        Me.actxnTotalPagarOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(94, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "I.G.V. : {0}"
        '
        'actxnIGVOld
        '
        Me.actxnIGVOld.ACEnteros = 9
        Me.actxnIGVOld.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnIGVOld.ACNegativo = True
        Me.actxnIGVOld.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnIGVOld.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnIGVOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnIGVOld.Location = New System.Drawing.Point(157, 35)
        Me.actxnIGVOld.MaxLength = 12
        Me.actxnIGVOld.Name = "actxnIGVOld"
        Me.actxnIGVOld.ReadOnly = True
        Me.actxnIGVOld.Size = New System.Drawing.Size(100, 23)
        Me.actxnIGVOld.TabIndex = 5
        Me.actxnIGVOld.Tag = "ENO"
        Me.actxnIGVOld.Text = "0.00"
        Me.actxnIGVOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnImporteOld
        '
        Me.actxnImporteOld.ACEnteros = 9
        Me.actxnImporteOld.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnImporteOld.ACNegativo = True
        Me.actxnImporteOld.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnImporteOld.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnImporteOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnImporteOld.Location = New System.Drawing.Point(157, 6)
        Me.actxnImporteOld.MaxLength = 12
        Me.actxnImporteOld.Name = "actxnImporteOld"
        Me.actxnImporteOld.ReadOnly = True
        Me.actxnImporteOld.Size = New System.Drawing.Size(100, 23)
        Me.actxnImporteOld.TabIndex = 3
        Me.actxnImporteOld.Tag = "ENO"
        Me.actxnImporteOld.Text = "0.00"
        Me.actxnImporteOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(79, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Importe : {0}"
        '
        'pnlItem
        '
        Me.pnlItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.pnlItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlItem.Controls.Add(Me.chkPrecIGV)
        Me.pnlItem.Controls.Add(Me.Label5)
        Me.pnlItem.Controls.Add(Me.actxnPrecIGV)
        Me.pnlItem.Controls.Add(Me.actxaDescripcion)
        Me.pnlItem.Controls.Add(Me.actxnDescuento)
        Me.pnlItem.Controls.Add(Me.Label4)
        Me.pnlItem.Controls.Add(Me.actxnPrecio)
        Me.pnlItem.Controls.Add(Me.txtOpcion)
        Me.pnlItem.Controls.Add(Me.actxnSubImporte)
        Me.pnlItem.Controls.Add(Me.actxnProdCantidad)
        Me.pnlItem.Controls.Add(Me.Label10)
        Me.pnlItem.Controls.Add(Me.Label9)
        Me.pnlItem.Controls.Add(Me.Label14)
        Me.pnlItem.Controls.Add(Me.Label17)
        Me.pnlItem.Controls.Add(Me.lblCodigo)
        Me.pnlItem.Controls.Add(Me.actxaProdCodigo)
        Me.pnlItem.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlItem.Location = New System.Drawing.Point(0, 0)
        Me.pnlItem.Name = "pnlItem"
        Me.pnlItem.Size = New System.Drawing.Size(782, 51)
        Me.pnlItem.TabIndex = 0
        '
        'chkPrecIGV
        '
        Me.chkPrecIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPrecIGV.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPrecIGV.AutoSize = True
        Me.chkPrecIGV.Location = New System.Drawing.Point(458, 20)
        Me.chkPrecIGV.Name = "chkPrecIGV"
        Me.chkPrecIGV.Size = New System.Drawing.Size(35, 25)
        Me.chkPrecIGV.TabIndex = 8
        Me.chkPrecIGV.Text = "IGV"
        Me.chkPrecIGV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPrecIGV.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(500, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "P. + IGV"
        '
        'actxnPrecIGV
        '
        Me.actxnPrecIGV.ACEnteros = 9
        Me.actxnPrecIGV.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnPrecIGV.ACNegativo = True
        Me.actxnPrecIGV.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnPrecIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnPrecIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnPrecIGV.Location = New System.Drawing.Point(494, 21)
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
        Me.actxaDescripcion.Location = New System.Drawing.Point(116, 21)
        Me.actxaDescripcion.MaxLength = 50
        Me.actxaDescripcion.Name = "actxaDescripcion"
        Me.actxaDescripcion.Size = New System.Drawing.Size(184, 23)
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
        Me.actxnDescuento.Location = New System.Drawing.Point(573, 21)
        Me.actxnDescuento.MaxLength = 12
        Me.actxnDescuento.Name = "actxnDescuento"
        Me.actxnDescuento.Size = New System.Drawing.Size(74, 23)
        Me.actxnDescuento.TabIndex = 12
        Me.actxnDescuento.Tag = "EV"
        Me.actxnDescuento.Text = "0.00"
        Me.actxnDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(580, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Descuento"
        '
        'actxnPrecio
        '
        Me.actxnPrecio.ACEnteros = 9
        Me.actxnPrecio.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnPrecio.ACNegativo = True
        Me.actxnPrecio.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnPrecio.Location = New System.Drawing.Point(378, 21)
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
        Me.txtOpcion.Location = New System.Drawing.Point(749, 21)
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
        Me.actxnSubImporte.Location = New System.Drawing.Point(649, 21)
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
        Me.actxnProdCantidad.Location = New System.Drawing.Point(302, 21)
        Me.actxnProdCantidad.MaxLength = 12
        Me.actxnProdCantidad.Name = "actxnProdCantidad"
        Me.actxnProdCantidad.Size = New System.Drawing.Size(74, 23)
        Me.actxnProdCantidad.TabIndex = 5
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
        Me.Label10.Location = New System.Drawing.Point(658, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Sub Importe"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(386, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Pr&ecio"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(307, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "C&antidad"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(125, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Descripcion"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblCodigo.ForeColor = System.Drawing.Color.White
        Me.lblCodigo.Location = New System.Drawing.Point(11, 5)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(45, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "C&odigo"
        '
        'actxaProdCodigo
        '
        Me.actxaProdCodigo.ACActivarAyudaAuto = False
        Me.actxaProdCodigo.ACLongitudAceptada = 0
        Me.actxaProdCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaProdCodigo.Location = New System.Drawing.Point(4, 21)
        Me.actxaProdCodigo.MaxLength = 20
        Me.actxaProdCodigo.Name = "actxaProdCodigo"
        Me.actxaProdCodigo.Size = New System.Drawing.Size(110, 23)
        Me.actxaProdCodigo.TabIndex = 1
        Me.actxaProdCodigo.Tag = "EV"
        '
        'bnavProductos
        '
        Me.bnavProductos.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.bnavProductos.CountItem = Me.BindingNavigatorCountItem
        Me.bnavProductos.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.bnavProductos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavProductos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.bnavProductos.Location = New System.Drawing.Point(0, 169)
        Me.bnavProductos.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavProductos.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavProductos.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavProductos.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavProductos.Name = "bnavProductos"
        Me.bnavProductos.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavProductos.Size = New System.Drawing.Size(782, 25)
        Me.bnavProductos.TabIndex = 2
        Me.bnavProductos.Text = "BindingNavigator1"
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
        Me.pnlPie.Location = New System.Drawing.Point(0, 314)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(782, 39)
        Me.pnlPie.TabIndex = 3
        '
        'actxnImporte
        '
        Me.actxnImporte.ACEnteros = 9
        Me.actxnImporte.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnImporte.ACNegativo = True
        Me.actxnImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnImporte.Location = New System.Drawing.Point(240, 7)
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
        Me.lblImporte.Location = New System.Drawing.Point(162, 11)
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
        Me.lblTotalPagar.Location = New System.Drawing.Point(538, 10)
        Me.lblTotalPagar.Name = "lblTotalPagar"
        Me.lblTotalPagar.Size = New System.Drawing.Size(107, 17)
        Me.lblTotalPagar.TabIndex = 8
        Me.lblTotalPagar.Text = "Total Pagar : {0}"
        '
        'lbligv
        '
        Me.lbligv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbligv.AutoSize = True
        Me.lbligv.Location = New System.Drawing.Point(354, 11)
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
        Me.actxnTotalPagar.Location = New System.Drawing.Point(652, 5)
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
        Me.actxnIGV.Location = New System.Drawing.Point(417, 7)
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
        Me.pnlCabecera.Controls.Add(Me.Label6)
        Me.pnlCabecera.Controls.Add(Me.chkIncluidoIGV)
        Me.pnlCabecera.Controls.Add(Me.btnNueTransportista)
        Me.pnlCabecera.Controls.Add(Me.actxaDescProveedor)
        Me.pnlCabecera.Controls.Add(Me.actxaNroDocProveedor)
        Me.pnlCabecera.Controls.Add(Me.lblProveedor)
        Me.pnlCabecera.Controls.Add(Me.txtSerie)
        Me.pnlCabecera.Controls.Add(Me.actxnNumero)
        Me.pnlCabecera.Controls.Add(Me.Label2)
        Me.pnlCabecera.Controls.Add(Me.Label3)
        Me.pnlCabecera.Controls.Add(Me.lblTipoDocumento)
        Me.pnlCabecera.Controls.Add(Me.cmbDocumento)
        Me.pnlCabecera.Controls.Add(Me.dtpFecEmision)
        Me.pnlCabecera.Controls.Add(Me.lblMoneda)
        Me.pnlCabecera.Controls.Add(Me.cmbMoneda)
        Me.pnlCabecera.Controls.Add(Me.Label1)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(782, 120)
        Me.pnlCabecera.TabIndex = 1
        '
        'dtpFecIngreso
        '
        Me.dtpFecIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIngreso.Location = New System.Drawing.Point(298, 63)
        Me.dtpFecIngreso.Name = "dtpFecIngreso"
        Me.dtpFecIngreso.Size = New System.Drawing.Size(109, 23)
        Me.dtpFecIngreso.TabIndex = 8
        Me.dtpFecIngreso.Tag = "E"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(206, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Fecha Ingreso :"
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
        Me.btnNueTransportista.Location = New System.Drawing.Point(743, 5)
        Me.btnNueTransportista.Name = "btnNueTransportista"
        Me.btnNueTransportista.Size = New System.Drawing.Size(29, 27)
        Me.btnNueTransportista.TabIndex = 3
        Me.btnNueTransportista.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNueTransportista.UseVisualStyleBackColor = True
        '
        'actxaDescProveedor
        '
        Me.actxaDescProveedor.ACActivarAyudaAuto = False
        Me.actxaDescProveedor.ACLongitudAceptada = 0
        Me.actxaDescProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaDescProveedor.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxaDescProveedor.Location = New System.Drawing.Point(216, 7)
        Me.actxaDescProveedor.MaxLength = 80
        Me.actxaDescProveedor.Name = "actxaDescProveedor"
        Me.actxaDescProveedor.Size = New System.Drawing.Size(520, 23)
        Me.actxaDescProveedor.TabIndex = 2
        Me.actxaDescProveedor.Tag = "EVO"
        '
        'actxaNroDocProveedor
        '
        Me.actxaNroDocProveedor.ACActivarAyudaAuto = False
        Me.actxaNroDocProveedor.ACLongitudAceptada = 0
        Me.actxaNroDocProveedor.Location = New System.Drawing.Point(88, 7)
        Me.actxaNroDocProveedor.MaxLength = 14
        Me.actxaNroDocProveedor.Name = "actxaNroDocProveedor"
        Me.actxaNroDocProveedor.Size = New System.Drawing.Size(121, 23)
        Me.actxaNroDocProveedor.TabIndex = 1
        Me.actxaNroDocProveedor.Tag = "EVO"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(13, 11)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(67, 15)
        Me.lblProveedor.TabIndex = 0
        Me.lblProveedor.Text = "Proveedor :"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(488, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Numero :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(385, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Serie :"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fecha :"
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
        Me.tabBusqueda.Size = New System.Drawing.Size(782, 353)
        Me.tabBusqueda.TabIndex = 5
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'c1grdBusqueda
        '
        Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 71)
        Me.c1grdBusqueda.Name = "c1grdBusqueda"
        Me.c1grdBusqueda.Rows.Count = 2
        Me.c1grdBusqueda.Rows.DefaultSize = 20
        Me.c1grdBusqueda.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.c1grdBusqueda.Size = New System.Drawing.Size(782, 257)
        Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
        Me.c1grdBusqueda.TabIndex = 1
        '
        'bnavBusqueda
        '
        Me.bnavBusqueda.AddNewItem = Me.ToolStripButton1
        Me.bnavBusqueda.CountItem = Me.ToolStripLabel1
        Me.bnavBusqueda.DeleteItem = Me.ToolStripButton2
        Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 328)
        Me.bnavBusqueda.MoveFirstItem = Me.ToolStripButton3
        Me.bnavBusqueda.MoveLastItem = Me.ToolStripButton6
        Me.bnavBusqueda.MoveNextItem = Me.ToolStripButton5
        Me.bnavBusqueda.MovePreviousItem = Me.ToolStripButton4
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.ToolStripTextBox1
        Me.bnavBusqueda.Size = New System.Drawing.Size(782, 25)
        Me.bnavBusqueda.TabIndex = 2
        Me.bnavBusqueda.Text = "BindingNavigator1"
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
        'grpBusqueda
        '
        Me.grpBusqueda.Controls.Add(Me.rbtnNroDocumento)
        Me.grpBusqueda.Controls.Add(Me.btnConsultar)
        Me.grpBusqueda.Controls.Add(Me.chkTodos)
        Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
        Me.grpBusqueda.Controls.Add(Me.rbtnProveedor)
        Me.grpBusqueda.Controls.Add(Me.AcFecha)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(782, 71)
        Me.grpBusqueda.TabIndex = 0
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'rbtnNroDocumento
        '
        Me.rbtnNroDocumento.AutoSize = True
        Me.rbtnNroDocumento.Location = New System.Drawing.Point(101, 17)
        Me.rbtnNroDocumento.Name = "rbtnNroDocumento"
        Me.rbtnNroDocumento.Size = New System.Drawing.Size(72, 19)
        Me.rbtnNroDocumento.TabIndex = 33
        Me.rbtnNroDocumento.Text = "Nro Doc."
        Me.rbtnNroDocumento.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.CheckProcess_32x32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(339, 14)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 44)
        Me.btnConsultar.TabIndex = 32
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chkTodos
        '
        Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(669, 49)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(101, 19)
        Me.chkTodos.TabIndex = 3
        Me.chkTodos.Text = "Mostrar Todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.ACActivarAyudaAuto = False
        Me.txtBusqueda.ACLongitudAceptada = 0
        Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda.Location = New System.Drawing.Point(6, 42)
        Me.txtBusqueda.MaxLength = 32767
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(327, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'rbtnProveedor
        '
        Me.rbtnProveedor.AutoSize = True
        Me.rbtnProveedor.Checked = True
        Me.rbtnProveedor.Location = New System.Drawing.Point(10, 17)
        Me.rbtnProveedor.Name = "rbtnProveedor"
        Me.rbtnProveedor.Size = New System.Drawing.Size(79, 19)
        Me.rbtnProveedor.TabIndex = 1
        Me.rbtnProveedor.TabStop = True
        Me.rbtnProveedor.Text = "Proveedor"
        Me.rbtnProveedor.UseVisualStyleBackColor = True
        '
        'AcFecha
        '
        Me.AcFecha.ACFecha_A = New Date(2024, 7, 8, 16, 29, 35, 630)
        Me.AcFecha.ACFecha_De = New Date(2024, 7, 8, 16, 29, 35, 628)
        Me.AcFecha.ACFechaObligatoria = True
        Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
        Me.AcFecha.ACHoyChecked = False
        Me.AcFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AcFecha.Location = New System.Drawing.Point(441, 0)
        Me.AcFecha.MaximumSize = New System.Drawing.Size(340, 50)
        Me.AcFecha.MinimumSize = New System.Drawing.Size(340, 43)
        Me.AcFecha.Name = "AcFecha"
        Me.AcFecha.Size = New System.Drawing.Size(340, 45)
        Me.AcFecha.TabIndex = 3
        Me.AcFecha.TabStop = False
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
        Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.actsbtnSeleccionar})
        Me.acTool.Location = New System.Drawing.Point(0, 406)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(784, 56)
        Me.acTool.TabIndex = 4
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'actsbtnSeleccionar
        '
        Me.actsbtnSeleccionar.AutoSize = False
        Me.actsbtnSeleccionar.Image = Global.ACPTransportes.My.Resources.Resources.aceptar_32x32
        Me.actsbtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.actsbtnSeleccionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.actsbtnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.actsbtnSeleccionar.Name = "tsbBoton"
        Me.actsbtnSeleccionar.Size = New System.Drawing.Size(84, 53)
        Me.actsbtnSeleccionar.Text = "Selección"
        Me.actsbtnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.actsbtnSeleccionar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.actsbtnSeleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MDocumentosCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 462)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Controls.Add(Me.acTool)
        Me.Name = "MDocumentosCompra"
        Me.Text = "Documento de Compra"
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlDetalle.PerformLayout()
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPedSeparacion.ResumeLayout(False)
        Me.pnlPedSeparacion.PerformLayout()
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
    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
   Friend WithEvents c1grdDetalle As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents pnlPedSeparacion As System.Windows.Forms.Panel
   Friend WithEvents pnlItem As System.Windows.Forms.Panel
   Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
   Friend WithEvents actxnSubImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnProdCantidad As ACControles.ACTextBoxNumerico
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents lblCodigo As System.Windows.Forms.Label
   Friend WithEvents actxaProdCodigo As ACControles.ACTextBoxAyuda
   Friend WithEvents bnavProductos As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents pnlPie As System.Windows.Forms.Panel
   Friend WithEvents lblImporte As System.Windows.Forms.Label
   Friend WithEvents lbligv As System.Windows.Forms.Label
   Friend WithEvents actxnImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnIGV As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnTotalPagar As ACControles.ACTextBoxNumerico
   Friend WithEvents lblTotalPagar As System.Windows.Forms.Label
   Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
   Friend WithEvents dtpFecEmision As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblMoneda As System.Windows.Forms.Label
   Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Private WithEvents tabBusqueda As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents c1grdBusqueda As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavBusqueda As System.Windows.Forms.BindingNavigator
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
   Private WithEvents grpBusqueda As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As System.Windows.Forms.Button
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
   Friend WithEvents rbtnProveedor As System.Windows.Forms.RadioButton
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents actsbtnSeleccionar As ACControles.ACToolStripButton
   Friend WithEvents actxnPrecio As ACControles.ACTextBoxNumerico
   Friend WithEvents txtSerie As System.Windows.Forms.TextBox
   Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
   Friend WithEvents cmbDocumento As System.Windows.Forms.ComboBox
   Friend WithEvents btnNueTransportista As System.Windows.Forms.Button
   Friend WithEvents actxaDescProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaNroDocProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents lblProveedor As System.Windows.Forms.Label
   Friend WithEvents rbtnNroDocumento As System.Windows.Forms.RadioButton
   Friend WithEvents actxnDescuento As ACControles.ACTextBoxNumerico
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents chkIncluidoIGV As System.Windows.Forms.CheckBox
   Friend WithEvents actxaDescripcion As ACControles.ACTextBoxAyuda
   Friend WithEvents chkPrecIGV As System.Windows.Forms.CheckBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents actxnPrecIGV As ACControles.ACTextBoxNumerico
   Friend WithEvents dtpFecIngreso As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents actxnTotalPagarOld As ACControles.ACTextBoxNumerico
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents actxnIGVOld As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnImporteOld As ACControles.ACTextBoxNumerico
   Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
