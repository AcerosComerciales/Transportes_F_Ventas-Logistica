<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PCotizacionesFletes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PCotizacionesFletes))
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.spcBase = New System.Windows.Forms.SplitContainer()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.spcCabecera = New System.Windows.Forms.SplitContainer()
        Me.pnlItem = New System.Windows.Forms.Panel()
        Me.btnMenos = New System.Windows.Forms.Button()
        Me.btnMas = New System.Windows.Forms.Button()
        Me.txtProdUnidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.actxnPrecio = New ACControles.ACTextBoxNumerico()
        Me.txtOpcion = New System.Windows.Forms.TextBox()
        Me.actxnSubImporte = New ACControles.ACTextBoxNumerico()
        Me.actxnProdCantidad = New ACControles.ACTextBoxNumerico()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtProdDescripcion = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.grpCabCuerpo = New System.Windows.Forms.GroupBox()
        Me.chkIlncluidoIGV = New System.Windows.Forms.CheckBox()
        Me.grpFlete = New System.Windows.Forms.GroupBox()
        Me.actxaFleteDesc = New ACControles.ACTextBoxAyuda()
        Me.actxaFlete = New ACControles.ACTextBoxAyuda()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.actxnTCVentaSunat = New ACControles.ACTextBoxNumerico()
        Me.lblVenDolarSunat = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnNuevoCliente = New System.Windows.Forms.Button()
        Me.cmbEntrega = New System.Windows.Forms.ComboBox()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.actxaCliRazonSocial = New ACControles.ACTextBoxAyuda()
        Me.lblNroDocumento = New System.Windows.Forms.Label()
        Me.actxaCliRuc = New ACControles.ACTextBoxAyuda()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.pnlFlete = New System.Windows.Forms.Panel()
        Me.c1grdFletes = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnAddFletes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnQuitarFletes = New System.Windows.Forms.ToolStripButton()
        Me.bnavFletes = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator44 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox10 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator45 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton27 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton28 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator46 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.spcDetalle = New System.Windows.Forms.SplitContainer()
        Me.c1grdDetalle = New C1.Win.C1FlexGrid.C1FlexGrid()
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
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.c1grdEmpresas = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.AcPanelCaption2 = New ACControles.ACPanelCaption()
        Me.c1grdGuias = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavGuias = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption4 = New ACControles.ACPanelCaption()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtTexto = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnGenerar = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption3 = New ACControles.ACPanelCaption()
        Me.pnlCabHeader = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFecFacturacion = New System.Windows.Forms.DateTimePicker()
        Me.actxaCotiz = New ACControles.ACTextBoxAyuda()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDocumento = New System.Windows.Forms.ComboBox()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.actxnTipoCambio = New ACControles.ACTextBoxNumerico()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNotaPie = New System.Windows.Forms.TextBox()
        Me.grpDetPago = New System.Windows.Forms.GroupBox()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lbligv = New System.Windows.Forms.Label()
        Me.actxnImporte = New ACControles.ACTextBoxNumerico()
        Me.actxnIGV = New ACControles.ACTextBoxNumerico()
        Me.actxnTotalPagar = New ACControles.ACTextBoxNumerico()
        Me.lblTotalPagar = New System.Windows.Forms.Label()
        Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.c1grdBusqueda = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grpBusqueda = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.rbtnNroCotizacion = New System.Windows.Forms.RadioButton()
        Me.rbtnCliente = New System.Windows.Forms.RadioButton()
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
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.acbtnSeleccionar = New ACControles.ACToolStripButton(Me.components)
        Me.actsbtnPrevisualizar = New ACControles.ACToolStripButton(Me.components)
        Me.eprError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        CType(Me.spcBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcBase.Panel1.SuspendLayout()
        Me.spcBase.Panel2.SuspendLayout()
        Me.spcBase.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        CType(Me.spcCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcCabecera.Panel1.SuspendLayout()
        Me.spcCabecera.Panel2.SuspendLayout()
        Me.spcCabecera.SuspendLayout()
        Me.pnlItem.SuspendLayout()
        Me.grpCabCuerpo.SuspendLayout()
        Me.grpFlete.SuspendLayout()
        Me.pnlFlete.SuspendLayout()
        CType(Me.c1grdFletes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.bnavFletes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavFletes.SuspendLayout()
        Me.pnlDetalle.SuspendLayout()
        CType(Me.spcDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcDetalle.Panel1.SuspendLayout()
        Me.spcDetalle.Panel2.SuspendLayout()
        Me.spcDetalle.SuspendLayout()
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavProductos.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.c1grdEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1grdGuias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavGuias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavGuias.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlCabHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.grpDetPago.SuspendLayout()
        Me.tabBusqueda.SuspendLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBusqueda.SuspendLayout()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavBusqueda.SuspendLayout()
        Me.acTool.SuspendLayout()
        CType(Me.eprError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 25)
        Me.tabMantenimiento.MediaPlayerDockSides = False
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = False
        Me.tabMantenimiento.SelectedIndex = 0
        Me.tabMantenimiento.ShowDropSelect = False
        Me.tabMantenimiento.Size = New System.Drawing.Size(984, 549)
        Me.tabMantenimiento.TabIndex = 13
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
        Me.tabDatos.Size = New System.Drawing.Size(982, 524)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.spcBase)
        Me.pnlDatos.Controls.Add(Me.pnlCabHeader)
        Me.pnlDatos.Controls.Add(Me.pnlPie)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(982, 524)
        Me.pnlDatos.TabIndex = 1
        '
        'spcBase
        '
        Me.spcBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcBase.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.spcBase.Location = New System.Drawing.Point(0, 32)
        Me.spcBase.Name = "spcBase"
        Me.spcBase.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcBase.Panel1
        '
        Me.spcBase.Panel1.Controls.Add(Me.pnlCabecera)
        '
        'spcBase.Panel2
        '
        Me.spcBase.Panel2.Controls.Add(Me.pnlDetalle)
        Me.spcBase.Size = New System.Drawing.Size(982, 437)
        Me.spcBase.SplitterDistance = 221
        Me.spcBase.TabIndex = 3
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlCabecera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCabecera.Controls.Add(Me.spcCabecera)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(982, 221)
        Me.pnlCabecera.TabIndex = 2
        '
        'spcCabecera
        '
        Me.spcCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcCabecera.Location = New System.Drawing.Point(0, 0)
        Me.spcCabecera.Name = "spcCabecera"
        '
        'spcCabecera.Panel1
        '
        Me.spcCabecera.Panel1.Controls.Add(Me.pnlItem)
        Me.spcCabecera.Panel1.Controls.Add(Me.grpCabCuerpo)
        '
        'spcCabecera.Panel2
        '
        Me.spcCabecera.Panel2.Controls.Add(Me.pnlFlete)
        Me.spcCabecera.Size = New System.Drawing.Size(980, 219)
        Me.spcCabecera.SplitterDistance = 717
        Me.spcCabecera.TabIndex = 11
        '
        'pnlItem
        '
        Me.pnlItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.pnlItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlItem.Controls.Add(Me.btnMenos)
        Me.pnlItem.Controls.Add(Me.btnMas)
        Me.pnlItem.Controls.Add(Me.txtProdUnidad)
        Me.pnlItem.Controls.Add(Me.Label2)
        Me.pnlItem.Controls.Add(Me.actxnPrecio)
        Me.pnlItem.Controls.Add(Me.txtOpcion)
        Me.pnlItem.Controls.Add(Me.actxnSubImporte)
        Me.pnlItem.Controls.Add(Me.actxnProdCantidad)
        Me.pnlItem.Controls.Add(Me.Label10)
        Me.pnlItem.Controls.Add(Me.Label9)
        Me.pnlItem.Controls.Add(Me.lblCantidad)
        Me.pnlItem.Controls.Add(Me.txtProdDescripcion)
        Me.pnlItem.Controls.Add(Me.Label17)
        Me.pnlItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlItem.Location = New System.Drawing.Point(0, 125)
        Me.pnlItem.Name = "pnlItem"
        Me.pnlItem.Size = New System.Drawing.Size(717, 94)
        Me.pnlItem.TabIndex = 0
        '
        'btnMenos
        '
        Me.btnMenos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenos.Location = New System.Drawing.Point(684, 67)
        Me.btnMenos.Name = "btnMenos"
        Me.btnMenos.Size = New System.Drawing.Size(26, 23)
        Me.btnMenos.TabIndex = 14
        Me.btnMenos.Text = "-"
        Me.btnMenos.UseVisualStyleBackColor = True
        '
        'btnMas
        '
        Me.btnMas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMas.Location = New System.Drawing.Point(684, 45)
        Me.btnMas.Name = "btnMas"
        Me.btnMas.Size = New System.Drawing.Size(26, 23)
        Me.btnMas.TabIndex = 13
        Me.btnMas.Text = "+"
        Me.btnMas.UseVisualStyleBackColor = True
        '
        'txtProdUnidad
        '
        Me.txtProdUnidad.Location = New System.Drawing.Point(126, 19)
        Me.txtProdUnidad.MaxLength = 10
        Me.txtProdUnidad.Name = "txtProdUnidad"
        Me.txtProdUnidad.Size = New System.Drawing.Size(138, 23)
        Me.txtProdUnidad.TabIndex = 3
        Me.txtProdUnidad.Tag = "EV"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(129, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Unidad"
        '
        'actxnPrecio
        '
        Me.actxnPrecio.ACDecimales = 4
        Me.actxnPrecio.ACEnteros = 9
        Me.actxnPrecio.ACFormato = "###,###,##0.0000"
        Me.actxnPrecio.ACNegativo = True
        Me.actxnPrecio.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnPrecio.Location = New System.Drawing.Point(466, 19)
        Me.actxnPrecio.MaxLength = 12
        Me.actxnPrecio.Name = "actxnPrecio"
        Me.actxnPrecio.Size = New System.Drawing.Size(100, 23)
        Me.actxnPrecio.TabIndex = 7
        Me.actxnPrecio.Tag = "N"
        Me.actxnPrecio.Text = "0.0000"
        Me.actxnPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOpcion
        '
        Me.txtOpcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOpcion.BackColor = System.Drawing.Color.Gainsboro
        Me.txtOpcion.Location = New System.Drawing.Point(684, 19)
        Me.txtOpcion.MaxLength = 1
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.Size = New System.Drawing.Size(25, 23)
        Me.txtOpcion.TabIndex = 10
        '
        'actxnSubImporte
        '
        Me.actxnSubImporte.ACDecimales = 4
        Me.actxnSubImporte.ACEnteros = 9
        Me.actxnSubImporte.ACFormato = "###,###,##0.0000"
        Me.actxnSubImporte.ACNegativo = True
        Me.actxnSubImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnSubImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnSubImporte.Location = New System.Drawing.Point(578, 19)
        Me.actxnSubImporte.MaxLength = 12
        Me.actxnSubImporte.Name = "actxnSubImporte"
        Me.actxnSubImporte.ReadOnly = True
        Me.actxnSubImporte.Size = New System.Drawing.Size(100, 23)
        Me.actxnSubImporte.TabIndex = 9
        Me.actxnSubImporte.Tag = "N"
        Me.actxnSubImporte.Text = "0.0000"
        Me.actxnSubImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnProdCantidad
        '
        Me.actxnProdCantidad.ACDecimales = 4
        Me.actxnProdCantidad.ACEnteros = 9
        Me.actxnProdCantidad.ACFormato = "###,###,##0.0000"
        Me.actxnProdCantidad.ACNegativo = True
        Me.actxnProdCantidad.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnProdCantidad.Location = New System.Drawing.Point(10, 19)
        Me.actxnProdCantidad.MaxLength = 18
        Me.actxnProdCantidad.Name = "actxnProdCantidad"
        Me.actxnProdCantidad.Size = New System.Drawing.Size(110, 23)
        Me.actxnProdCantidad.TabIndex = 1
        Me.actxnProdCantidad.Tag = "EN"
        Me.actxnProdCantidad.Text = "0.0000"
        Me.actxnProdCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(582, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Sub Importe"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(470, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Pr&ecio"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblCantidad.ForeColor = System.Drawing.Color.White
        Me.lblCantidad.Location = New System.Drawing.Point(14, 1)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(57, 13)
        Me.lblCantidad.TabIndex = 0
        Me.lblCantidad.Text = "C&antidad"
        '
        'txtProdDescripcion
        '
        Me.txtProdDescripcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProdDescripcion.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProdDescripcion.Location = New System.Drawing.Point(125, 46)
        Me.txtProdDescripcion.MaxLength = 1024
        Me.txtProdDescripcion.Multiline = True
        Me.txtProdDescripcion.Name = "txtProdDescripcion"
        Me.txtProdDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProdDescripcion.Size = New System.Drawing.Size(553, 42)
        Me.txtProdDescripcion.TabIndex = 5
        Me.txtProdDescripcion.Tag = "V"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(41, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Descripción :"
        '
        'grpCabCuerpo
        '
        Me.grpCabCuerpo.Controls.Add(Me.chkIlncluidoIGV)
        Me.grpCabCuerpo.Controls.Add(Me.grpFlete)
        Me.grpCabCuerpo.Controls.Add(Me.txtDireccion)
        Me.grpCabCuerpo.Controls.Add(Me.Label7)
        Me.grpCabCuerpo.Controls.Add(Me.actxnTCVentaSunat)
        Me.grpCabCuerpo.Controls.Add(Me.lblVenDolarSunat)
        Me.grpCabCuerpo.Controls.Add(Me.Label6)
        Me.grpCabCuerpo.Controls.Add(Me.btnNuevoCliente)
        Me.grpCabCuerpo.Controls.Add(Me.cmbEntrega)
        Me.grpCabCuerpo.Controls.Add(Me.btnClean)
        Me.grpCabCuerpo.Controls.Add(Me.actxaCliRazonSocial)
        Me.grpCabCuerpo.Controls.Add(Me.lblNroDocumento)
        Me.grpCabCuerpo.Controls.Add(Me.actxaCliRuc)
        Me.grpCabCuerpo.Controls.Add(Me.lblMoneda)
        Me.grpCabCuerpo.Controls.Add(Me.cmbMoneda)
        Me.grpCabCuerpo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCabCuerpo.Location = New System.Drawing.Point(0, 0)
        Me.grpCabCuerpo.Name = "grpCabCuerpo"
        Me.grpCabCuerpo.Size = New System.Drawing.Size(717, 125)
        Me.grpCabCuerpo.TabIndex = 1
        Me.grpCabCuerpo.TabStop = False
        Me.grpCabCuerpo.Tag = "EVO"
        '
        'chkIlncluidoIGV
        '
        Me.chkIlncluidoIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIlncluidoIGV.AutoSize = True
        Me.chkIlncluidoIGV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIlncluidoIGV.Location = New System.Drawing.Point(455, 100)
        Me.chkIlncluidoIGV.Name = "chkIlncluidoIGV"
        Me.chkIlncluidoIGV.Size = New System.Drawing.Size(99, 19)
        Me.chkIlncluidoIGV.TabIndex = 16
        Me.chkIlncluidoIGV.Text = "Incluido I.G.V."
        Me.chkIlncluidoIGV.UseVisualStyleBackColor = True
        '
        'grpFlete
        '
        Me.grpFlete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFlete.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.grpFlete.Controls.Add(Me.actxaFleteDesc)
        Me.grpFlete.Controls.Add(Me.actxaFlete)
        Me.grpFlete.Controls.Add(Me.Label4)
        Me.grpFlete.Location = New System.Drawing.Point(0, 1)
        Me.grpFlete.Name = "grpFlete"
        Me.grpFlete.Size = New System.Drawing.Size(717, 40)
        Me.grpFlete.TabIndex = 2
        Me.grpFlete.TabStop = False
        '
        'actxaFleteDesc
        '
        Me.actxaFleteDesc.ACActivarAyudaAuto = False
        Me.actxaFleteDesc.ACLongitudAceptada = 0
        Me.actxaFleteDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaFleteDesc.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxaFleteDesc.Location = New System.Drawing.Point(197, 12)
        Me.actxaFleteDesc.MaxLength = 80
        Me.actxaFleteDesc.Name = "actxaFleteDesc"
        Me.actxaFleteDesc.Size = New System.Drawing.Size(369, 24)
        Me.actxaFleteDesc.TabIndex = 2
        Me.actxaFleteDesc.Tag = "EV"
        '
        'actxaFlete
        '
        Me.actxaFlete.ACActivarAyudaAuto = False
        Me.actxaFlete.ACLongitudAceptada = 0
        Me.actxaFlete.Location = New System.Drawing.Point(75, 13)
        Me.actxaFlete.MaxLength = 14
        Me.actxaFlete.Name = "actxaFlete"
        Me.actxaFlete.Size = New System.Drawing.Size(106, 23)
        Me.actxaFlete.TabIndex = 1
        Me.actxaFlete.Tag = "EVO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(28, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Flete :"
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.Location = New System.Drawing.Point(75, 70)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(624, 23)
        Me.txtDireccion.TabIndex = 7
        Me.txtDireccion.Tag = "V"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Direccion :"
        '
        'actxnTCVentaSunat
        '
        Me.actxnTCVentaSunat.ACEnteros = 9
        Me.actxnTCVentaSunat.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTCVentaSunat.ACNegativo = True
        Me.actxnTCVentaSunat.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTCVentaSunat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnTCVentaSunat.Location = New System.Drawing.Point(650, 98)
        Me.actxnTCVentaSunat.MaxLength = 12
        Me.actxnTCVentaSunat.Name = "actxnTCVentaSunat"
        Me.actxnTCVentaSunat.ReadOnly = True
        Me.actxnTCVentaSunat.Size = New System.Drawing.Size(47, 23)
        Me.actxnTCVentaSunat.TabIndex = 15
        Me.actxnTCVentaSunat.Text = "0.00"
        Me.actxnTCVentaSunat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVenDolarSunat
        '
        Me.lblVenDolarSunat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVenDolarSunat.AutoSize = True
        Me.lblVenDolarSunat.Enabled = False
        Me.lblVenDolarSunat.Location = New System.Drawing.Point(560, 102)
        Me.lblVenDolarSunat.Name = "lblVenDolarSunat"
        Me.lblVenDolarSunat.Size = New System.Drawing.Size(83, 15)
        Me.lblVenDolarSunat.TabIndex = 14
        Me.lblVenDolarSunat.Text = "T.C. Sunat : {0}"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(231, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Cond&ición :"
        '
        'btnNuevoCliente
        '
        Me.btnNuevoCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevoCliente.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnNuevoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoCliente.Location = New System.Drawing.Point(588, 42)
        Me.btnNuevoCliente.Name = "btnNuevoCliente"
        Me.btnNuevoCliente.Size = New System.Drawing.Size(68, 27)
        Me.btnNuevoCliente.TabIndex = 4
        Me.btnNuevoCliente.Text = "Nuevo "
        Me.btnNuevoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevoCliente.UseVisualStyleBackColor = True
        '
        'cmbEntrega
        '
        Me.cmbEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntrega.FormattingEnabled = True
        Me.cmbEntrega.Location = New System.Drawing.Point(299, 98)
        Me.cmbEntrega.Name = "cmbEntrega"
        Me.cmbEntrega.Size = New System.Drawing.Size(152, 23)
        Me.cmbEntrega.TabIndex = 11
        Me.cmbEntrega.Tag = "ECO"
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClean.Image = Global.ACPTransportes.My.Resources.Resources.Delete_16x16
        Me.btnClean.Location = New System.Drawing.Point(663, 42)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(36, 27)
        Me.btnClean.TabIndex = 5
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'actxaCliRazonSocial
        '
        Me.actxaCliRazonSocial.ACActivarAyudaAuto = False
        Me.actxaCliRazonSocial.ACLongitudAceptada = 0
        Me.actxaCliRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaCliRazonSocial.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxaCliRazonSocial.Location = New System.Drawing.Point(198, 43)
        Me.actxaCliRazonSocial.MaxLength = 80
        Me.actxaCliRazonSocial.Name = "actxaCliRazonSocial"
        Me.actxaCliRazonSocial.Size = New System.Drawing.Size(369, 24)
        Me.actxaCliRazonSocial.TabIndex = 3
        Me.actxaCliRazonSocial.Tag = "EVO"
        '
        'lblNroDocumento
        '
        Me.lblNroDocumento.AutoSize = True
        Me.lblNroDocumento.Location = New System.Drawing.Point(20, 48)
        Me.lblNroDocumento.Name = "lblNroDocumento"
        Me.lblNroDocumento.Size = New System.Drawing.Size(50, 15)
        Me.lblNroDocumento.TabIndex = 1
        Me.lblNroDocumento.Text = "Cliente :"
        '
        'actxaCliRuc
        '
        Me.actxaCliRuc.ACActivarAyudaAuto = False
        Me.actxaCliRuc.ACLongitudAceptada = 0
        Me.actxaCliRuc.Location = New System.Drawing.Point(75, 44)
        Me.actxaCliRuc.MaxLength = 14
        Me.actxaCliRuc.Name = "actxaCliRuc"
        Me.actxaCliRuc.Size = New System.Drawing.Size(106, 23)
        Me.actxaCliRuc.TabIndex = 2
        Me.actxaCliRuc.Tag = "EVO"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(13, 102)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(57, 15)
        Me.lblMoneda.TabIndex = 8
        Me.lblMoneda.Text = "&Moneda :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.DropDownWidth = 250
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(75, 98)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(150, 23)
        Me.cmbMoneda.TabIndex = 9
        Me.cmbMoneda.Tag = "EO"
        '
        'pnlFlete
        '
        Me.pnlFlete.Controls.Add(Me.c1grdFletes)
        Me.pnlFlete.Controls.Add(Me.ToolStrip2)
        Me.pnlFlete.Controls.Add(Me.bnavFletes)
        Me.pnlFlete.Controls.Add(Me.AcPanelCaption1)
        Me.pnlFlete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFlete.Location = New System.Drawing.Point(0, 0)
        Me.pnlFlete.Name = "pnlFlete"
        Me.pnlFlete.Size = New System.Drawing.Size(259, 219)
        Me.pnlFlete.TabIndex = 2
        '
        'c1grdFletes
        '
        Me.c1grdFletes.AllowAddNew = True
        Me.c1grdFletes.AllowDelete = True
        Me.c1grdFletes.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdFletes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdFletes.Location = New System.Drawing.Point(0, 43)
        Me.c1grdFletes.Name = "c1grdFletes"
        Me.c1grdFletes.Rows.Count = 2
        Me.c1grdFletes.Rows.DefaultSize = 20
        Me.c1grdFletes.Size = New System.Drawing.Size(259, 151)
        Me.c1grdFletes.StyleInfo = resources.GetString("c1grdFletes.StyleInfo")
        Me.c1grdFletes.TabIndex = 18
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAddFletes, Me.ToolStripSeparator4, Me.tsbtnQuitarFletes})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 18)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(259, 25)
        Me.ToolStrip2.TabIndex = 20
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbtnAddFletes
        '
        Me.tsbtnAddFletes.Image = Global.ACPTransportes.My.Resources.Resources.ACAdd_16x16
        Me.tsbtnAddFletes.Name = "tsbtnAddFletes"
        Me.tsbtnAddFletes.RightToLeftAutoMirrorImage = True
        Me.tsbtnAddFletes.Size = New System.Drawing.Size(69, 22)
        Me.tsbtnAddFletes.Text = "Agregar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnQuitarFletes
        '
        Me.tsbtnQuitarFletes.Image = Global.ACPTransportes.My.Resources.Resources.ACAnular_16x16
        Me.tsbtnQuitarFletes.Name = "tsbtnQuitarFletes"
        Me.tsbtnQuitarFletes.RightToLeftAutoMirrorImage = True
        Me.tsbtnQuitarFletes.Size = New System.Drawing.Size(60, 22)
        Me.tsbtnQuitarFletes.Text = "Quitar"
        '
        'bnavFletes
        '
        Me.bnavFletes.AddNewItem = Nothing
        Me.bnavFletes.CountItem = Me.ToolStripLabel10
        Me.bnavFletes.DeleteItem = Nothing
        Me.bnavFletes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavFletes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.ToolStripButton8, Me.ToolStripSeparator44, Me.ToolStripTextBox10, Me.ToolStripLabel10, Me.ToolStripSeparator45, Me.ToolStripButton27, Me.ToolStripButton28, Me.ToolStripSeparator46})
        Me.bnavFletes.Location = New System.Drawing.Point(0, 194)
        Me.bnavFletes.MoveFirstItem = Me.ToolStripButton7
        Me.bnavFletes.MoveLastItem = Me.ToolStripButton28
        Me.bnavFletes.MoveNextItem = Me.ToolStripButton27
        Me.bnavFletes.MovePreviousItem = Me.ToolStripButton8
        Me.bnavFletes.Name = "bnavFletes"
        Me.bnavFletes.PositionItem = Me.ToolStripTextBox10
        Me.bnavFletes.Size = New System.Drawing.Size(259, 25)
        Me.bnavFletes.TabIndex = 19
        Me.bnavFletes.Text = "bnavFletes"
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel10.Text = "of {0}"
        Me.ToolStripLabel10.ToolTipText = "Total number of items"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Move first"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "Move previous"
        '
        'ToolStripSeparator44
        '
        Me.ToolStripSeparator44.Name = "ToolStripSeparator44"
        Me.ToolStripSeparator44.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox10
        '
        Me.ToolStripTextBox10.AccessibleName = "Position"
        Me.ToolStripTextBox10.AutoSize = False
        Me.ToolStripTextBox10.Name = "ToolStripTextBox10"
        Me.ToolStripTextBox10.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox10.Text = "0"
        Me.ToolStripTextBox10.ToolTipText = "Current position"
        '
        'ToolStripSeparator45
        '
        Me.ToolStripSeparator45.Name = "ToolStripSeparator45"
        Me.ToolStripSeparator45.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton27
        '
        Me.ToolStripButton27.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton27.Image = CType(resources.GetObject("ToolStripButton27.Image"), System.Drawing.Image)
        Me.ToolStripButton27.Name = "ToolStripButton27"
        Me.ToolStripButton27.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton27.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton27.Text = "Move next"
        '
        'ToolStripButton28
        '
        Me.ToolStripButton28.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton28.Image = CType(resources.GetObject("ToolStripButton28.Image"), System.Drawing.Image)
        Me.ToolStripButton28.Name = "ToolStripButton28"
        Me.ToolStripButton28.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton28.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton28.Text = "Move last"
        '
        'ToolStripSeparator46
        '
        Me.ToolStripSeparator46.Name = "ToolStripSeparator46"
        Me.ToolStripSeparator46.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption1
        '
        Me.AcPanelCaption1.ACCaption = "Fletes"
        Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption1.Name = "AcPanelCaption1"
        Me.AcPanelCaption1.Size = New System.Drawing.Size(259, 18)
        Me.AcPanelCaption1.TabIndex = 21
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Controls.Add(Me.spcDetalle)
        Me.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetalle.Location = New System.Drawing.Point(0, 0)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(982, 212)
        Me.pnlDetalle.TabIndex = 5
        '
        'spcDetalle
        '
        Me.spcDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcDetalle.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.spcDetalle.Location = New System.Drawing.Point(0, 0)
        Me.spcDetalle.Name = "spcDetalle"
        '
        'spcDetalle.Panel1
        '
        Me.spcDetalle.Panel1.Controls.Add(Me.c1grdDetalle)
        Me.spcDetalle.Panel1.Controls.Add(Me.bnavProductos)
        '
        'spcDetalle.Panel2
        '
        Me.spcDetalle.Panel2.Controls.Add(Me.SplitContainer3)
        Me.spcDetalle.Panel2.Controls.Add(Me.Panel2)
        Me.spcDetalle.Size = New System.Drawing.Size(982, 212)
        Me.spcDetalle.SplitterDistance = 504
        Me.spcDetalle.TabIndex = 3
        '
        'c1grdDetalle
        '
        Me.c1grdDetalle.BackColor = System.Drawing.Color.White
        Me.c1grdDetalle.ColumnInfo = "2,1,0,0,0,105,Columns:0{Width:18;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:107;Caption:""Codigo"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdDetalle.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdDetalle.Location = New System.Drawing.Point(0, 0)
        Me.c1grdDetalle.Name = "c1grdDetalle"
        Me.c1grdDetalle.Rows.Count = 2
        Me.c1grdDetalle.Rows.DefaultSize = 21
        Me.c1grdDetalle.Size = New System.Drawing.Size(504, 187)
        Me.c1grdDetalle.StyleInfo = resources.GetString("c1grdDetalle.StyleInfo")
        Me.c1grdDetalle.TabIndex = 1
        '
        'bnavProductos
        '
        Me.bnavProductos.AddNewItem = Me.ToolStripButton1
        Me.bnavProductos.CountItem = Me.ToolStripLabel1
        Me.bnavProductos.DeleteItem = Me.ToolStripButton2
        Me.bnavProductos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavProductos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.bnavProductos.Location = New System.Drawing.Point(0, 187)
        Me.bnavProductos.MoveFirstItem = Me.ToolStripButton3
        Me.bnavProductos.MoveLastItem = Me.ToolStripButton6
        Me.bnavProductos.MoveNextItem = Me.ToolStripButton5
        Me.bnavProductos.MovePreviousItem = Me.ToolStripButton4
        Me.bnavProductos.Name = "bnavProductos"
        Me.bnavProductos.PositionItem = Me.ToolStripTextBox1
        Me.bnavProductos.Size = New System.Drawing.Size(504, 25)
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
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(200, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.c1grdEmpresas)
        Me.SplitContainer3.Panel1.Controls.Add(Me.AcPanelCaption2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.c1grdGuias)
        Me.SplitContainer3.Panel2.Controls.Add(Me.bnavGuias)
        Me.SplitContainer3.Panel2.Controls.Add(Me.AcPanelCaption4)
        Me.SplitContainer3.Size = New System.Drawing.Size(274, 212)
        Me.SplitContainer3.SplitterDistance = 100
        Me.SplitContainer3.TabIndex = 2
        '
        'c1grdEmpresas
        '
        Me.c1grdEmpresas.AllowAddNew = True
        Me.c1grdEmpresas.AllowDelete = True
        Me.c1grdEmpresas.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdEmpresas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdEmpresas.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdEmpresas.Location = New System.Drawing.Point(0, 18)
        Me.c1grdEmpresas.Name = "c1grdEmpresas"
        Me.c1grdEmpresas.Rows.Count = 2
        Me.c1grdEmpresas.Rows.DefaultSize = 18
        Me.c1grdEmpresas.Size = New System.Drawing.Size(274, 82)
        Me.c1grdEmpresas.StyleInfo = resources.GetString("c1grdEmpresas.StyleInfo")
        Me.c1grdEmpresas.TabIndex = 19
        '
        'AcPanelCaption2
        '
        Me.AcPanelCaption2.ACCaption = "Empresas"
        Me.AcPanelCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption2.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption2.Name = "AcPanelCaption2"
        Me.AcPanelCaption2.Size = New System.Drawing.Size(274, 18)
        Me.AcPanelCaption2.TabIndex = 22
        '
        'c1grdGuias
        '
        Me.c1grdGuias.AllowAddNew = True
        Me.c1grdGuias.AllowDelete = True
        Me.c1grdGuias.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdGuias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdGuias.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdGuias.Location = New System.Drawing.Point(0, 18)
        Me.c1grdGuias.Name = "c1grdGuias"
        Me.c1grdGuias.Rows.Count = 2
        Me.c1grdGuias.Rows.DefaultSize = 18
        Me.c1grdGuias.Size = New System.Drawing.Size(274, 65)
        Me.c1grdGuias.StyleInfo = resources.GetString("c1grdGuias.StyleInfo")
        Me.c1grdGuias.TabIndex = 23
        '
        'bnavGuias
        '
        Me.bnavGuias.AddNewItem = Nothing
        Me.bnavGuias.CountItem = Me.ToolStripLabel2
        Me.bnavGuias.DeleteItem = Nothing
        Me.bnavGuias.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavGuias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton9, Me.ToolStripButton10, Me.ToolStripSeparator5, Me.ToolStripTextBox2, Me.ToolStripLabel2, Me.ToolStripSeparator6, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator7})
        Me.bnavGuias.Location = New System.Drawing.Point(0, 83)
        Me.bnavGuias.MoveFirstItem = Me.ToolStripButton9
        Me.bnavGuias.MoveLastItem = Me.ToolStripButton12
        Me.bnavGuias.MoveNextItem = Me.ToolStripButton11
        Me.bnavGuias.MovePreviousItem = Me.ToolStripButton10
        Me.bnavGuias.Name = "bnavGuias"
        Me.bnavGuias.PositionItem = Me.ToolStripTextBox2
        Me.bnavGuias.Size = New System.Drawing.Size(274, 25)
        Me.bnavGuias.TabIndex = 25
        Me.bnavGuias.Text = "BindingNavigator1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel2.Text = "of {0}"
        Me.ToolStripLabel2.ToolTipText = "Total number of items"
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
        'AcPanelCaption4
        '
        Me.AcPanelCaption4.ACCaption = "Guias de Fletes"
        Me.AcPanelCaption4.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption4.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption4.Name = "AcPanelCaption4"
        Me.AcPanelCaption4.Size = New System.Drawing.Size(274, 18)
        Me.AcPanelCaption4.TabIndex = 24
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtTexto)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.AcPanelCaption3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 212)
        Me.Panel2.TabIndex = 1
        '
        'txtTexto
        '
        Me.txtTexto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTexto.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto.Location = New System.Drawing.Point(0, 18)
        Me.txtTexto.MaxLength = 1024
        Me.txtTexto.Multiline = True
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTexto.Size = New System.Drawing.Size(200, 169)
        Me.txtTexto.TabIndex = 6
        Me.txtTexto.Tag = "V"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnGenerar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 187)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(200, 25)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtnGenerar
        '
        Me.tsbtnGenerar.Image = Global.ACPTransportes.My.Resources.Resources.ACAppProduccion_16x16
        Me.tsbtnGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGenerar.Name = "tsbtnGenerar"
        Me.tsbtnGenerar.Size = New System.Drawing.Size(68, 22)
        Me.tsbtnGenerar.Text = "Generar"
        '
        'AcPanelCaption3
        '
        Me.AcPanelCaption3.ACCaption = "Texto"
        Me.AcPanelCaption3.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption3.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption3.Name = "AcPanelCaption3"
        Me.AcPanelCaption3.Size = New System.Drawing.Size(200, 18)
        Me.AcPanelCaption3.TabIndex = 23
        '
        'pnlCabHeader
        '
        Me.pnlCabHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.pnlCabHeader.Controls.Add(Me.Label8)
        Me.pnlCabHeader.Controls.Add(Me.dtpFecFacturacion)
        Me.pnlCabHeader.Controls.Add(Me.actxaCotiz)
        Me.pnlCabHeader.Controls.Add(Me.Label1)
        Me.pnlCabHeader.Controls.Add(Me.cmbDocumento)
        Me.pnlCabHeader.Controls.Add(Me.lblDocumento)
        Me.pnlCabHeader.Controls.Add(Me.actxnTipoCambio)
        Me.pnlCabHeader.Controls.Add(Me.Label31)
        Me.pnlCabHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabHeader.Name = "pnlCabHeader"
        Me.pnlCabHeader.Size = New System.Drawing.Size(982, 32)
        Me.pnlCabHeader.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(775, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Cotización :"
        '
        'dtpFecFacturacion
        '
        Me.dtpFecFacturacion.Enabled = False
        Me.dtpFecFacturacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFacturacion.Location = New System.Drawing.Point(104, 5)
        Me.dtpFecFacturacion.Name = "dtpFecFacturacion"
        Me.dtpFecFacturacion.Size = New System.Drawing.Size(95, 23)
        Me.dtpFecFacturacion.TabIndex = 1
        Me.dtpFecFacturacion.Tag = "E"
        '
        'actxaCotiz
        '
        Me.actxaCotiz.ACActivarAyudaAuto = False
        Me.actxaCotiz.ACLongitudAceptada = 0
        Me.actxaCotiz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaCotiz.Enabled = False
        Me.actxaCotiz.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxaCotiz.Location = New System.Drawing.Point(852, 3)
        Me.actxaCotiz.MaxLength = 32767
        Me.actxaCotiz.Name = "actxaCotiz"
        Me.actxaCotiz.Size = New System.Drawing.Size(127, 26)
        Me.actxaCotiz.TabIndex = 14
        Me.actxaCotiz.Tag = "EV"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Emi&sion :"
        '
        'cmbDocumento
        '
        Me.cmbDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDocumento.FormattingEnabled = True
        Me.cmbDocumento.Items.AddRange(New Object() {"Pedido", "Cotización"})
        Me.cmbDocumento.Location = New System.Drawing.Point(518, 2)
        Me.cmbDocumento.Name = "cmbDocumento"
        Me.cmbDocumento.Size = New System.Drawing.Size(251, 28)
        Me.cmbDocumento.TabIndex = 7
        '
        'lblDocumento
        '
        Me.lblDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDocumento.AutoSize = True
        Me.lblDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumento.ForeColor = System.Drawing.Color.White
        Me.lblDocumento.Location = New System.Drawing.Point(383, 4)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(129, 24)
        Me.lblDocumento.TabIndex = 6
        Me.lblDocumento.Text = "&Documento :"
        '
        'actxnTipoCambio
        '
        Me.actxnTipoCambio.ACEnteros = 9
        Me.actxnTipoCambio.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnTipoCambio.ACNegativo = True
        Me.actxnTipoCambio.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnTipoCambio.Location = New System.Drawing.Point(311, 5)
        Me.actxnTipoCambio.MaxLength = 12
        Me.actxnTipoCambio.Name = "actxnTipoCambio"
        Me.actxnTipoCambio.ReadOnly = True
        Me.actxnTipoCambio.Size = New System.Drawing.Size(59, 23)
        Me.actxnTipoCambio.TabIndex = 12
        Me.actxnTipoCambio.Text = "0.00"
        Me.actxnTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Enabled = False
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(224, 9)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(81, 15)
        Me.Label31.TabIndex = 11
        Me.Label31.Text = "Tipo Cam&bio :"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.txtGuia)
        Me.pnlPie.Controls.Add(Me.Label11)
        Me.pnlPie.Controls.Add(Me.txtNotaPie)
        Me.pnlPie.Controls.Add(Me.grpDetPago)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 469)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(982, 55)
        Me.pnlPie.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nro. Guias :"
        '
        'txtGuia
        '
        Me.txtGuia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGuia.Location = New System.Drawing.Point(75, 28)
        Me.txtGuia.MaxLength = 50
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Size = New System.Drawing.Size(313, 23)
        Me.txtGuia.TabIndex = 3
        Me.txtGuia.Tag = "EV"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(2, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 15)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Nota al Pie :"
        '
        'txtNotaPie
        '
        Me.txtNotaPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotaPie.Location = New System.Drawing.Point(75, 2)
        Me.txtNotaPie.MaxLength = 50
        Me.txtNotaPie.Name = "txtNotaPie"
        Me.txtNotaPie.Size = New System.Drawing.Size(313, 23)
        Me.txtNotaPie.TabIndex = 1
        Me.txtNotaPie.Tag = "EV"
        '
        'grpDetPago
        '
        Me.grpDetPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.grpDetPago.Controls.Add(Me.lblImporte)
        Me.grpDetPago.Controls.Add(Me.lbligv)
        Me.grpDetPago.Controls.Add(Me.actxnImporte)
        Me.grpDetPago.Controls.Add(Me.actxnIGV)
        Me.grpDetPago.Controls.Add(Me.actxnTotalPagar)
        Me.grpDetPago.Controls.Add(Me.lblTotalPagar)
        Me.grpDetPago.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpDetPago.Location = New System.Drawing.Point(394, 0)
        Me.grpDetPago.Name = "grpDetPago"
        Me.grpDetPago.Size = New System.Drawing.Size(586, 53)
        Me.grpDetPago.TabIndex = 4
        Me.grpDetPago.TabStop = False
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.ForeColor = System.Drawing.Color.White
        Me.lblImporte.Location = New System.Drawing.Point(5, 22)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(72, 15)
        Me.lblImporte.TabIndex = 0
        Me.lblImporte.Text = "Importe : {0}"
        '
        'lbligv
        '
        Me.lbligv.AutoSize = True
        Me.lbligv.ForeColor = System.Drawing.Color.White
        Me.lbligv.Location = New System.Drawing.Point(199, 22)
        Me.lbligv.Name = "lbligv"
        Me.lbligv.Size = New System.Drawing.Size(57, 15)
        Me.lbligv.TabIndex = 2
        Me.lbligv.Text = "I.G.V. : {0}"
        '
        'actxnImporte
        '
        Me.actxnImporte.ACEnteros = 9
        Me.actxnImporte.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnImporte.ACNegativo = True
        Me.actxnImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actxnImporte.Location = New System.Drawing.Point(89, 15)
        Me.actxnImporte.MaxLength = 12
        Me.actxnImporte.Name = "actxnImporte"
        Me.actxnImporte.ReadOnly = True
        Me.actxnImporte.Size = New System.Drawing.Size(104, 29)
        Me.actxnImporte.TabIndex = 1
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
        Me.actxnIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actxnIGV.Location = New System.Drawing.Point(265, 15)
        Me.actxnIGV.MaxLength = 12
        Me.actxnIGV.Name = "actxnIGV"
        Me.actxnIGV.ReadOnly = True
        Me.actxnIGV.Size = New System.Drawing.Size(104, 29)
        Me.actxnIGV.TabIndex = 3
        Me.actxnIGV.Tag = "EVO"
        Me.actxnIGV.Text = "0.00"
        Me.actxnIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnTotalPagar
        '
        Me.actxnTotalPagar.ACEnteros = 9
        Me.actxnTotalPagar.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTotalPagar.ACNegativo = True
        Me.actxnTotalPagar.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actxnTotalPagar.Location = New System.Drawing.Point(474, 15)
        Me.actxnTotalPagar.MaxLength = 12
        Me.actxnTotalPagar.Name = "actxnTotalPagar"
        Me.actxnTotalPagar.ReadOnly = True
        Me.actxnTotalPagar.Size = New System.Drawing.Size(104, 29)
        Me.actxnTotalPagar.TabIndex = 5
        Me.actxnTotalPagar.Tag = "EVO"
        Me.actxnTotalPagar.Text = "0.00"
        Me.actxnTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalPagar
        '
        Me.lblTotalPagar.AutoSize = True
        Me.lblTotalPagar.ForeColor = System.Drawing.Color.White
        Me.lblTotalPagar.Location = New System.Drawing.Point(375, 22)
        Me.lblTotalPagar.Name = "lblTotalPagar"
        Me.lblTotalPagar.Size = New System.Drawing.Size(88, 15)
        Me.lblTotalPagar.TabIndex = 4
        Me.lblTotalPagar.Text = "Total Pagar : {0}"
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
        Me.tabBusqueda.Size = New System.Drawing.Size(982, 524)
        Me.tabBusqueda.TabIndex = 5
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'c1grdBusqueda
        '
        Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 57)
        Me.c1grdBusqueda.Name = "c1grdBusqueda"
        Me.c1grdBusqueda.Rows.Count = 2
        Me.c1grdBusqueda.Rows.DefaultSize = 20
        Me.c1grdBusqueda.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.c1grdBusqueda.Size = New System.Drawing.Size(982, 467)
        Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
        Me.c1grdBusqueda.TabIndex = 2
        '
        'grpBusqueda
        '
        Me.grpBusqueda.Controls.Add(Me.btnConsultar)
        Me.grpBusqueda.Controls.Add(Me.chkTodos)
        Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
        Me.grpBusqueda.Controls.Add(Me.rbtnNroCotizacion)
        Me.grpBusqueda.Controls.Add(Me.rbtnCliente)
        Me.grpBusqueda.Controls.Add(Me.AcFecha)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(982, 57)
        Me.grpBusqueda.TabIndex = 4
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(539, 9)
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
        Me.chkTodos.Location = New System.Drawing.Point(428, 12)
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
        Me.txtBusqueda.Location = New System.Drawing.Point(10, 21)
        Me.txtBusqueda.MaxLength = 32767
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(294, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'rbtnNroCotizacion
        '
        Me.rbtnNroCotizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnNroCotizacion.AutoSize = True
        Me.rbtnNroCotizacion.Location = New System.Drawing.Point(317, 34)
        Me.rbtnNroCotizacion.Name = "rbtnNroCotizacion"
        Me.rbtnNroCotizacion.Size = New System.Drawing.Size(104, 19)
        Me.rbtnNroCotizacion.TabIndex = 2
        Me.rbtnNroCotizacion.Text = "Nro Cotización"
        Me.rbtnNroCotizacion.UseVisualStyleBackColor = True
        '
        'rbtnCliente
        '
        Me.rbtnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnCliente.AutoSize = True
        Me.rbtnCliente.Checked = True
        Me.rbtnCliente.Location = New System.Drawing.Point(317, 11)
        Me.rbtnCliente.Name = "rbtnCliente"
        Me.rbtnCliente.Size = New System.Drawing.Size(62, 19)
        Me.rbtnCliente.TabIndex = 1
        Me.rbtnCliente.TabStop = True
        Me.rbtnCliente.Text = "Cliente"
        Me.rbtnCliente.UseVisualStyleBackColor = True
        '
        'AcFecha
        '
        Me.AcFecha.ACFecha_A = New Date(2020, 11, 19, 8, 31, 10, 0)
        Me.AcFecha.ACFecha_De = New Date(2020, 11, 19, 8, 31, 9, 998)
        Me.AcFecha.ACFechaObligatoria = True
        Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
        Me.AcFecha.ACHoyChecked = False
        Me.AcFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AcFecha.Location = New System.Drawing.Point(644, 0)
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
        Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 501)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(982, 25)
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
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Cotización - División de Transportes"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(984, 25)
        Me.acpnlTitulo.TabIndex = 12
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
        Me.acTool.ACBtnSalirText = "&Salir"
        Me.acTool.ACBtnVolverEnabled = False
        Me.acTool.ACBtnVolverVisible = False
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabarAnularImprimir
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.acbtnSeleccionar, Me.actsbtnPrevisualizar})
        Me.acTool.Location = New System.Drawing.Point(0, 574)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(984, 56)
        Me.acTool.TabIndex = 14
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
        'actsbtnPrevisualizar
        '
        Me.actsbtnPrevisualizar.AutoSize = False
        Me.actsbtnPrevisualizar.Image = Global.ACPTransportes.My.Resources.Resources.Buscar2_32x32
        Me.actsbtnPrevisualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.actsbtnPrevisualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.actsbtnPrevisualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.actsbtnPrevisualizar.Name = "tsbBoton"
        Me.actsbtnPrevisualizar.Size = New System.Drawing.Size(84, 53)
        Me.actsbtnPrevisualizar.Text = "Previsualizar"
        Me.actsbtnPrevisualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.actsbtnPrevisualizar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.actsbtnPrevisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'eprError
        '
        Me.eprError.ContainerControl = Me
        '
        'PCotizacionesFletes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(984, 630)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acTool)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Name = "PCotizacionesFletes"
        Me.Text = "Cotización - División de Transportes"
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.spcBase.Panel1.ResumeLayout(False)
        Me.spcBase.Panel2.ResumeLayout(False)
        CType(Me.spcBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcBase.ResumeLayout(False)
        Me.pnlCabecera.ResumeLayout(False)
        Me.spcCabecera.Panel1.ResumeLayout(False)
        Me.spcCabecera.Panel2.ResumeLayout(False)
        CType(Me.spcCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcCabecera.ResumeLayout(False)
        Me.pnlItem.ResumeLayout(False)
        Me.pnlItem.PerformLayout()
        Me.grpCabCuerpo.ResumeLayout(False)
        Me.grpCabCuerpo.PerformLayout()
        Me.grpFlete.ResumeLayout(False)
        Me.grpFlete.PerformLayout()
        Me.pnlFlete.ResumeLayout(False)
        Me.pnlFlete.PerformLayout()
        CType(Me.c1grdFletes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.bnavFletes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavFletes.ResumeLayout(False)
        Me.bnavFletes.PerformLayout()
        Me.pnlDetalle.ResumeLayout(False)
        Me.spcDetalle.Panel1.ResumeLayout(False)
        Me.spcDetalle.Panel1.PerformLayout()
        Me.spcDetalle.Panel2.ResumeLayout(False)
        CType(Me.spcDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcDetalle.ResumeLayout(False)
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavProductos.ResumeLayout(False)
        Me.bnavProductos.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.c1grdEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1grdGuias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavGuias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavGuias.ResumeLayout(False)
        Me.bnavGuias.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlCabHeader.ResumeLayout(False)
        Me.pnlCabHeader.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.grpDetPago.ResumeLayout(False)
        Me.grpDetPago.PerformLayout()
        Me.tabBusqueda.ResumeLayout(False)
        Me.tabBusqueda.PerformLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBusqueda.ResumeLayout(False)
        Me.grpBusqueda.PerformLayout()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavBusqueda.ResumeLayout(False)
        Me.bnavBusqueda.PerformLayout()
        Me.acTool.ResumeLayout(False)
        Me.acTool.PerformLayout()
        CType(Me.eprError, System.ComponentModel.ISupportInitialize).EndInit()
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
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
   Friend WithEvents c1grdDetalle As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents pnlItem As System.Windows.Forms.Panel
   Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
   Friend WithEvents actxnSubImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnProdCantidad As ACControles.ACTextBoxNumerico
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents lblCantidad As System.Windows.Forms.Label
   Friend WithEvents txtProdDescripcion As System.Windows.Forms.TextBox
   Friend WithEvents Label17 As System.Windows.Forms.Label
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
   Friend WithEvents pnlPie As System.Windows.Forms.Panel
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmbEntrega As System.Windows.Forms.ComboBox
   Friend WithEvents grpDetPago As System.Windows.Forms.GroupBox
   Friend WithEvents lblImporte As System.Windows.Forms.Label
   Friend WithEvents lbligv As System.Windows.Forms.Label
   Friend WithEvents actxnImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnIGV As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnTotalPagar As ACControles.ACTextBoxNumerico
   Friend WithEvents lblTotalPagar As System.Windows.Forms.Label
   Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
   Friend WithEvents grpCabCuerpo As System.Windows.Forms.GroupBox
   Friend WithEvents lblMoneda As System.Windows.Forms.Label
   Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents pnlCabHeader As System.Windows.Forms.Panel
   Friend WithEvents lblVenDolarSunat As System.Windows.Forms.Label
   Friend WithEvents Label31 As System.Windows.Forms.Label
   Friend WithEvents dtpFecFacturacion As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents btnNuevoCliente As System.Windows.Forms.Button
   Friend WithEvents btnClean As System.Windows.Forms.Button
   Friend WithEvents actxaCliRazonSocial As ACControles.ACTextBoxAyuda
   Friend WithEvents lblNroDocumento As System.Windows.Forms.Label
   Friend WithEvents actxaCliRuc As ACControles.ACTextBoxAyuda
   Friend WithEvents actxnPrecio As ACControles.ACTextBoxNumerico
   Friend WithEvents txtProdUnidad As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents actsbtnPrevisualizar As ACControles.ACToolStripButton
   Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents eprError As System.Windows.Forms.ErrorProvider
   Private WithEvents actxnTCVentaSunat As ACControles.ACTextBoxNumerico
   Private WithEvents actxnTipoCambio As ACControles.ACTextBoxNumerico
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents txtNotaPie As System.Windows.Forms.TextBox
   Friend WithEvents lblDocumento As System.Windows.Forms.Label
   Friend WithEvents cmbDocumento As System.Windows.Forms.ComboBox
   Private WithEvents grpBusqueda As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As System.Windows.Forms.Button
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
   Friend WithEvents rbtnNroCotizacion As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnCliente As System.Windows.Forms.RadioButton
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents acbtnSeleccionar As ACControles.ACToolStripButton
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtGuia As System.Windows.Forms.TextBox
   Friend WithEvents pnlFlete As System.Windows.Forms.Panel
   Friend WithEvents c1grdFletes As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbtnAddFletes As System.Windows.Forms.ToolStripButton
   Friend WithEvents bnavFletes As System.Windows.Forms.BindingNavigator
   Friend WithEvents ToolStripLabel10 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator44 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripTextBox10 As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripSeparator45 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton27 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton28 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator46 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbtnQuitarFletes As System.Windows.Forms.ToolStripButton
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Friend WithEvents spcCabecera As System.Windows.Forms.SplitContainer
   Friend WithEvents btnMenos As System.Windows.Forms.Button
   Friend WithEvents btnMas As System.Windows.Forms.Button
   Friend WithEvents grpFlete As System.Windows.Forms.GroupBox
   Friend WithEvents actxaFleteDesc As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaFlete As ACControles.ACTextBoxAyuda
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents spcBase As System.Windows.Forms.SplitContainer
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents actxaCotiz As ACControles.ACTextBoxAyuda
   Friend WithEvents spcDetalle As System.Windows.Forms.SplitContainer
   Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
   Friend WithEvents c1grdEmpresas As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents AcPanelCaption2 As ACControles.ACPanelCaption
   Friend WithEvents c1grdGuias As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents AcPanelCaption4 As ACControles.ACPanelCaption
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents txtTexto As System.Windows.Forms.TextBox
   Friend WithEvents AcPanelCaption3 As ACControles.ACPanelCaption
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbtnGenerar As System.Windows.Forms.ToolStripButton
   Friend WithEvents bnavGuias As System.Windows.Forms.BindingNavigator
   Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chkIlncluidoIGV As System.Windows.Forms.CheckBox
End Class
