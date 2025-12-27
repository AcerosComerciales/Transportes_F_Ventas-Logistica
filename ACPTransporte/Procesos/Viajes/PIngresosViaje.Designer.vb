<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PIngresosViajes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PIngresosViajes))
      Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
      Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.pnlDatos = New System.Windows.Forms.Panel()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.chkComprobante = New System.Windows.Forms.CheckBox()
      Me.cmbFlete = New System.Windows.Forms.ComboBox()
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
      Me.btnGenerarRecibo = New System.Windows.Forms.Button()
      Me.chkGRecibos = New System.Windows.Forms.CheckBox()
      Me.grpRecibos = New System.Windows.Forms.GroupBox()
      Me.cmbSerie = New System.Windows.Forms.ComboBox()
      Me.actxnNRecibo = New ACControles.ACTextBoxNumerico()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tabMantenimiento.SuspendLayout()
      Me.tabDatos.SuspendLayout()
      Me.pnlDatos.SuspendLayout()
      Me.grpComprobante.SuspendLayout()
      Me.grpDocumento.SuspendLayout()
      Me.tabBusqueda.SuspendLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavBusqueda.SuspendLayout()
      Me.grpBusqueda.SuspendLayout()
      Me.grpRecibos.SuspendLayout()
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
      Me.tabMantenimiento.Size = New System.Drawing.Size(517, 287)
      Me.tabMantenimiento.TabIndex = 18
      Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos, Me.tabBusqueda})
      Me.tabMantenimiento.TextTips = True
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
      Me.tabDatos.Size = New System.Drawing.Size(515, 262)
      Me.tabDatos.TabIndex = 4
      Me.tabDatos.Title = "Datos"
      Me.tabDatos.ToolTip = "Datos"
      '
      'pnlDatos
      '
      Me.pnlDatos.Controls.Add(Me.chkGRecibos)
      Me.pnlDatos.Controls.Add(Me.grpRecibos)
      Me.pnlDatos.Controls.Add(Me.dtpFecha)
      Me.pnlDatos.Controls.Add(Me.Label7)
      Me.pnlDatos.Controls.Add(Me.chkComprobante)
      Me.pnlDatos.Controls.Add(Me.cmbFlete)
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
      Me.pnlDatos.Size = New System.Drawing.Size(515, 153)
      Me.pnlDatos.TabIndex = 0
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(106, 105)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(95, 23)
      Me.dtpFecha.TabIndex = 9
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(56, 109)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(44, 15)
      Me.Label7.TabIndex = 8
      Me.Label7.Text = "Fecha :"
      '
      'chkComprobante
      '
      Me.chkComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chkComprobante.AutoSize = True
      Me.chkComprobante.Location = New System.Drawing.Point(18, 134)
      Me.chkComprobante.Name = "chkComprobante"
      Me.chkComprobante.Size = New System.Drawing.Size(146, 19)
      Me.chkComprobante.TabIndex = 10
      Me.chkComprobante.Text = "Comprobante de Pago"
      Me.chkComprobante.UseVisualStyleBackColor = True
      '
      'cmbFlete
      '
      Me.cmbFlete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFlete.FormattingEnabled = True
      Me.cmbFlete.Location = New System.Drawing.Point(106, 5)
      Me.cmbFlete.Name = "cmbFlete"
      Me.cmbFlete.Size = New System.Drawing.Size(397, 23)
      Me.cmbFlete.TabIndex = 1
      Me.cmbFlete.Tag = "ECO"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(62, 9)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(38, 15)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Flete :"
      '
      'cmbTipoMoneda
      '
      Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoMoneda.FormattingEnabled = True
      Me.cmbTipoMoneda.Location = New System.Drawing.Point(106, 55)
      Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
      Me.cmbTipoMoneda.Size = New System.Drawing.Size(199, 23)
      Me.cmbTipoMoneda.TabIndex = 7
      Me.cmbTipoMoneda.Tag = "EO"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(16, 59)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(84, 15)
      Me.Label2.TabIndex = 6
      Me.Label2.Text = "Tipo Moneda :"
      '
      'actxnMonto
      '
      Me.actxnMonto.ACEnteros = 8
      Me.actxnMonto.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnMonto.ACFormato = "#######0.00"
      Me.actxnMonto.ACNegativo = True
      Me.actxnMonto.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
      Me.actxnMonto.Location = New System.Drawing.Point(106, 80)
      Me.actxnMonto.MaxLength = 12
      Me.actxnMonto.Name = "actxnMonto"
      Me.actxnMonto.Size = New System.Drawing.Size(95, 23)
      Me.actxnMonto.TabIndex = 5
      Me.actxnMonto.Tag = "EVO"
      Me.actxnMonto.Text = "0"
      Me.actxnMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDescripcion
      '
      Me.txtDescripcion.Location = New System.Drawing.Point(106, 30)
      Me.txtDescripcion.MaxLength = 100
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(397, 23)
      Me.txtDescripcion.TabIndex = 3
      Me.txtDescripcion.Tag = "EVO"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(25, 34)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(75, 15)
      Me.Label5.TabIndex = 2
      Me.Label5.Text = "Descripcion :"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(21, 84)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(79, 15)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Monto Total :"
      '
      'grpComprobante
      '
      Me.grpComprobante.Controls.Add(Me.btnNueProveedor)
      Me.grpComprobante.Controls.Add(Me.actxaDescProveedor)
      Me.grpComprobante.Controls.Add(Me.lblProveedor)
      Me.grpComprobante.Controls.Add(Me.actxaNroDocProveedor)
      Me.grpComprobante.Controls.Add(Me.grpDocumento)
      Me.grpComprobante.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.grpComprobante.Enabled = False
      Me.grpComprobante.Location = New System.Drawing.Point(0, 153)
      Me.grpComprobante.Name = "grpComprobante"
      Me.grpComprobante.Size = New System.Drawing.Size(515, 109)
      Me.grpComprobante.TabIndex = 1
      Me.grpComprobante.TabStop = False
      '
      'btnNueProveedor
      '
      Me.btnNueProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnNueProveedor.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
      Me.btnNueProveedor.Location = New System.Drawing.Point(475, 20)
      Me.btnNueProveedor.Name = "btnNueProveedor"
      Me.btnNueProveedor.Size = New System.Drawing.Size(29, 27)
      Me.btnNueProveedor.TabIndex = 3
      Me.btnNueProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnNueProveedor.UseVisualStyleBackColor = True
      '
      'actxaDescProveedor
      '
      Me.actxaDescProveedor.ACActivarAyudaAuto = False
      Me.actxaDescProveedor.ACLongitudAceptada = 0
      Me.actxaDescProveedor.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaDescProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxaDescProveedor.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxaDescProveedor.Location = New System.Drawing.Point(207, 22)
      Me.actxaDescProveedor.MaxLength = 80
      Me.actxaDescProveedor.Name = "actxaDescProveedor"
      Me.actxaDescProveedor.Size = New System.Drawing.Size(265, 23)
      Me.actxaDescProveedor.TabIndex = 2
      Me.actxaDescProveedor.Tag = "EVO"
      '
      'lblProveedor
      '
      Me.lblProveedor.AutoSize = True
      Me.lblProveedor.Location = New System.Drawing.Point(7, 26)
      Me.lblProveedor.Name = "lblProveedor"
      Me.lblProveedor.Size = New System.Drawing.Size(67, 15)
      Me.lblProveedor.TabIndex = 0
      Me.lblProveedor.Text = "Proveedor :"
      '
      'actxaNroDocProveedor
      '
      Me.actxaNroDocProveedor.ACActivarAyudaAuto = False
      Me.actxaNroDocProveedor.ACLongitudAceptada = 0
      Me.actxaNroDocProveedor.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaNroDocProveedor.Location = New System.Drawing.Point(80, 22)
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
      Me.grpDocumento.Controls.Add(Me.actxnNumero)
      Me.grpDocumento.Controls.Add(Me.Label4)
      Me.grpDocumento.Controls.Add(Me.Label6)
      Me.grpDocumento.Location = New System.Drawing.Point(3, 50)
      Me.grpDocumento.Name = "grpDocumento"
      Me.grpDocumento.Size = New System.Drawing.Size(400, 56)
      Me.grpDocumento.TabIndex = 4
      Me.grpDocumento.TabStop = False
      '
      'txtSerie
      '
      Me.txtSerie.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSerie.Location = New System.Drawing.Point(198, 26)
      Me.txtSerie.MaxLength = 3
      Me.txtSerie.Name = "txtSerie"
      Me.txtSerie.Size = New System.Drawing.Size(60, 23)
      Me.txtSerie.TabIndex = 3
      Me.txtSerie.Tag = "EVO"
      '
      'lblTipoDocumento
      '
      Me.lblTipoDocumento.AutoSize = True
      Me.lblTipoDocumento.Location = New System.Drawing.Point(12, 10)
      Me.lblTipoDocumento.Name = "lblTipoDocumento"
      Me.lblTipoDocumento.Size = New System.Drawing.Size(97, 15)
      Me.lblTipoDocumento.TabIndex = 0
      Me.lblTipoDocumento.Text = "Tipo Documento"
      '
      'cmbGuia
      '
      Me.cmbGuia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbGuia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGuia.FormattingEnabled = True
      Me.cmbGuia.Items.AddRange(New Object() {"Boleta", "Factura"})
      Me.cmbGuia.Location = New System.Drawing.Point(6, 26)
      Me.cmbGuia.Name = "cmbGuia"
      Me.cmbGuia.Size = New System.Drawing.Size(187, 23)
      Me.cmbGuia.TabIndex = 1
      Me.cmbGuia.Tag = "ECO"
      '
      'actxnNumero
      '
      Me.actxnNumero.ACEnteros = 8
      Me.actxnNumero.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnNumero.ACFormato = "#######0"
      Me.actxnNumero.ACNegativo = True
      Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxnNumero.Location = New System.Drawing.Point(265, 26)
      Me.actxnNumero.MaxLength = 7
      Me.actxnNumero.Name = "actxnNumero"
      Me.actxnNumero.Size = New System.Drawing.Size(127, 23)
      Me.actxnNumero.TabIndex = 5
      Me.actxnNumero.Tag = "ENO"
      Me.actxnNumero.Text = "0"
      Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(271, 10)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(51, 15)
      Me.Label4.TabIndex = 4
      Me.Label4.Text = "Numero"
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(203, 10)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(32, 15)
      Me.Label6.TabIndex = 2
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
      Me.tabBusqueda.Selected = False
      Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
      Me.tabBusqueda.Size = New System.Drawing.Size(515, 262)
      Me.tabBusqueda.TabIndex = 5
      Me.tabBusqueda.Title = "Busqueda"
      Me.tabBusqueda.ToolTip = "Busqueda"
      '
      'c1grdBusqueda
      '
      Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 51)
      Me.c1grdBusqueda.Name = "c1grdBusqueda"
      Me.c1grdBusqueda.Rows.Count = 2
      Me.c1grdBusqueda.Rows.DefaultSize = 20
      Me.c1grdBusqueda.Size = New System.Drawing.Size(515, 186)
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
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 237)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(515, 25)
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
      Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
      Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
      Me.grpBusqueda.Name = "grpBusqueda"
      Me.grpBusqueda.Size = New System.Drawing.Size(515, 51)
      Me.grpBusqueda.TabIndex = 1
      Me.grpBusqueda.TabStop = False
      Me.grpBusqueda.Text = "Opciones de Busqueda"
      '
      'txtBusqueda
      '
      Me.txtBusqueda.ACActivarAyudaAuto = False
      Me.txtBusqueda.ACLongitudAceptada = 0
      Me.txtBusqueda.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBusqueda.Location = New System.Drawing.Point(17, 20)
      Me.txtBusqueda.MaxLength = 32767
      Me.txtBusqueda.Name = "txtBusqueda"
      Me.txtBusqueda.Size = New System.Drawing.Size(487, 23)
      Me.txtBusqueda.TabIndex = 0
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Búsqueda Ingresos Viaje"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(517, 30)
      Me.acpnlTitulo.TabIndex = 17
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
      Me.acTool.Location = New System.Drawing.Point(0, 317)
      Me.acTool.Name = "acTool"
      Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.acTool.Size = New System.Drawing.Size(517, 56)
      Me.acTool.TabIndex = 20
      Me.acTool.Text = "AcToolBarMantHorizontalNew1"
      '
      'btnGenerarRecibo
      '
      Me.btnGenerarRecibo.Image = Global.ACPTransportes.My.Resources.Resources.ACGuiaProc_32x32
      Me.btnGenerarRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGenerarRecibo.Location = New System.Drawing.Point(199, 20)
      Me.btnGenerarRecibo.Name = "btnGenerarRecibo"
      Me.btnGenerarRecibo.Size = New System.Drawing.Size(86, 43)
      Me.btnGenerarRecibo.TabIndex = 11
      Me.btnGenerarRecibo.Text = "Generar Recibo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
      Me.btnGenerarRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGenerarRecibo.UseVisualStyleBackColor = True
      '
      'chkGRecibos
      '
      Me.chkGRecibos.AutoSize = True
      Me.chkGRecibos.Location = New System.Drawing.Point(219, 81)
      Me.chkGRecibos.Name = "chkGRecibos"
      Me.chkGRecibos.Size = New System.Drawing.Size(108, 19)
      Me.chkGRecibos.TabIndex = 14
      Me.chkGRecibos.Text = "GenerarRecibos"
      Me.chkGRecibos.UseVisualStyleBackColor = True
      '
      'grpRecibos
      '
      Me.grpRecibos.Controls.Add(Me.btnGenerarRecibo)
      Me.grpRecibos.Controls.Add(Me.Label10)
      Me.grpRecibos.Controls.Add(Me.cmbSerie)
      Me.grpRecibos.Controls.Add(Me.Label9)
      Me.grpRecibos.Controls.Add(Me.actxnNRecibo)
      Me.grpRecibos.Location = New System.Drawing.Point(211, 82)
      Me.grpRecibos.Name = "grpRecibos"
      Me.grpRecibos.Size = New System.Drawing.Size(291, 68)
      Me.grpRecibos.TabIndex = 15
      Me.grpRecibos.TabStop = False
      '
      'cmbSerie
      '
      Me.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSerie.FormattingEnabled = True
      Me.cmbSerie.Location = New System.Drawing.Point(10, 37)
      Me.cmbSerie.Name = "cmbSerie"
      Me.cmbSerie.Size = New System.Drawing.Size(65, 23)
      Me.cmbSerie.TabIndex = 17
      Me.cmbSerie.Tag = "EO"
      '
      'actxnNRecibo
      '
      Me.actxnNRecibo.ACEnteros = 8
      Me.actxnNRecibo.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnNRecibo.ACFormato = "#######0"
      Me.actxnNRecibo.ACNegativo = True
      Me.actxnNRecibo.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnNRecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxnNRecibo.Location = New System.Drawing.Point(81, 37)
      Me.actxnNRecibo.MaxLength = 7
      Me.actxnNRecibo.Name = "actxnNRecibo"
      Me.actxnNRecibo.Size = New System.Drawing.Size(109, 23)
      Me.actxnNRecibo.TabIndex = 19
      Me.actxnNRecibo.Tag = "EVO"
      Me.actxnNRecibo.Text = "0"
      Me.actxnNRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label10
      '
      Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(10, 19)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(38, 15)
      Me.Label10.TabIndex = 16
      Me.Label10.Text = "Serie :"
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(78, 19)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(57, 15)
      Me.Label9.TabIndex = 18
      Me.Label9.Text = "Numero :"
      '
      'PIngresosViajes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(517, 373)
      Me.Controls.Add(Me.tabMantenimiento)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Controls.Add(Me.acTool)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "PIngresosViajes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Búsqueda Ingresos Viaje"
      Me.tabMantenimiento.ResumeLayout(False)
      Me.tabDatos.ResumeLayout(False)
      Me.pnlDatos.ResumeLayout(False)
      Me.pnlDatos.PerformLayout()
      Me.grpComprobante.ResumeLayout(False)
      Me.grpComprobante.PerformLayout()
      Me.grpDocumento.ResumeLayout(False)
      Me.grpDocumento.PerformLayout()
      Me.tabBusqueda.ResumeLayout(False)
      Me.tabBusqueda.PerformLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavBusqueda.ResumeLayout(False)
      Me.bnavBusqueda.PerformLayout()
      Me.grpBusqueda.ResumeLayout(False)
      Me.grpBusqueda.PerformLayout()
      Me.grpRecibos.ResumeLayout(False)
      Me.grpRecibos.PerformLayout()
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
   Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents actxnMonto As ACControles.ACTextBoxNumerico
   Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents cmbFlete As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
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
   Friend WithEvents chkGRecibos As System.Windows.Forms.CheckBox
   Friend WithEvents grpRecibos As System.Windows.Forms.GroupBox
   Friend WithEvents btnGenerarRecibo As System.Windows.Forms.Button
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents cmbSerie As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents actxnNRecibo As ACControles.ACTextBoxNumerico
End Class
