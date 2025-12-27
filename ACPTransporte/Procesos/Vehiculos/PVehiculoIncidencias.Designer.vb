<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVehiculosIncidencias
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PVehiculosIncidencias))
      Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
      Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.tbcIncidencias = New Crownwood.DotNetMagic.Controls.TabControl()
      Me.tbpRegistro = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.pnlDatos = New System.Windows.Forms.Panel()
      Me.cmbTipoIncidencia = New System.Windows.Forms.ComboBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.actxnMonto = New ACControles.ACTextBoxNumerico()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.chkComprobante = New System.Windows.Forms.CheckBox()
      Me.txtAccion = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtDescripcion = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.grpComprobante = New System.Windows.Forms.GroupBox()
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
      Me.tbpConsulta = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.c1grdIncidencias = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.bnavIncidencias = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.txtPlaca = New System.Windows.Forms.TextBox()
      Me.txtModelo = New System.Windows.Forms.TextBox()
      Me.cmbCombustible = New System.Windows.Forms.ComboBox()
      Me.cmbMarca = New System.Windows.Forms.ComboBox()
      Me.cmbTipVehiculo = New System.Windows.Forms.ComboBox()
      Me.txtVehiculoID = New System.Windows.Forms.TextBox()
      Me.lblPlaca = New System.Windows.Forms.Label()
      Me.lblModelo = New System.Windows.Forms.Label()
      Me.lblTipCombustible = New System.Windows.Forms.Label()
      Me.lblMarca = New System.Windows.Forms.Label()
      Me.lblCodTipVehiculo = New System.Windows.Forms.Label()
      Me.lblVehiculoID = New System.Windows.Forms.Label()
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
      Me.rbtnCodigo = New System.Windows.Forms.RadioButton()
      Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
      Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
      Me.acpnlTitulo = New ACControles.ACPanelCaption()
      Me.btnNueProveedor = New System.Windows.Forms.Button()
      Me.btnConsultar = New System.Windows.Forms.Button()
      Me.rbtnPlaca = New System.Windows.Forms.RadioButton()
      Me.tabMantenimiento.SuspendLayout()
      Me.tabDatos.SuspendLayout()
      Me.tbcIncidencias.SuspendLayout()
      Me.tbpRegistro.SuspendLayout()
      Me.pnlDatos.SuspendLayout()
      Me.grpComprobante.SuspendLayout()
      Me.grpDocumento.SuspendLayout()
      Me.tbpConsulta.SuspendLayout()
      CType(Me.c1grdIncidencias, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavIncidencias, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavIncidencias.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.tabBusqueda.SuspendLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavBusqueda.SuspendLayout()
      Me.grpBusqueda.SuspendLayout()
      Me.SuspendLayout()
      '
      'tabMantenimiento
      '
      Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
      Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideUsingLogic
      Me.tabMantenimiento.Location = New System.Drawing.Point(0, 30)
      Me.tabMantenimiento.MediaPlayerDockSides = False
      Me.tabMantenimiento.Name = "tabMantenimiento"
      Me.tabMantenimiento.OfficeDockSides = False
      Me.tabMantenimiento.SelectedIndex = 1
      Me.tabMantenimiento.ShowDropSelect = False
      Me.tabMantenimiento.Size = New System.Drawing.Size(790, 437)
      Me.tabMantenimiento.TabIndex = 1
      Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos, Me.tabBusqueda})
      Me.tabMantenimiento.TextTips = True
      '
      'tabDatos
      '
      Me.tabDatos.Controls.Add(Me.tbcIncidencias)
      Me.tabDatos.Controls.Add(Me.Panel1)
      Me.tabDatos.InactiveBackColor = System.Drawing.Color.Empty
      Me.tabDatos.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tabDatos.InactiveTextColor = System.Drawing.Color.Empty
      Me.tabDatos.Location = New System.Drawing.Point(1, 1)
      Me.tabDatos.Name = "tabDatos"
      Me.tabDatos.SelectBackColor = System.Drawing.Color.Empty
      Me.tabDatos.Selected = False
      Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
      Me.tabDatos.Size = New System.Drawing.Size(788, 412)
      Me.tabDatos.TabIndex = 1
      Me.tabDatos.Title = "Datos"
      Me.tabDatos.ToolTip = "Datos"
      '
      'tbcIncidencias
      '
      Me.tbcIncidencias.BackColor = System.Drawing.Color.LightSteelBlue
      Me.tbcIncidencias.BoldSelectedPage = True
      Me.tbcIncidencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.tbcIncidencias.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tbcIncidencias.Location = New System.Drawing.Point(0, 90)
      Me.tbcIncidencias.MediaPlayerDockSides = False
      Me.tbcIncidencias.Name = "tbcIncidencias"
      Me.tbcIncidencias.OfficeDockSides = False
      Me.tbcIncidencias.PositionTop = True
      Me.tbcIncidencias.SelectedIndex = 0
      Me.tbcIncidencias.ShowDropSelect = False
      Me.tbcIncidencias.Size = New System.Drawing.Size(788, 322)
      Me.tbcIncidencias.TabIndex = 12
      Me.tbcIncidencias.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tbpRegistro, Me.tbpConsulta})
      Me.tbcIncidencias.TextTips = True
      '
      'tbpRegistro
      '
      Me.tbpRegistro.Controls.Add(Me.pnlDatos)
      Me.tbpRegistro.Controls.Add(Me.grpComprobante)
      Me.tbpRegistro.InactiveBackColor = System.Drawing.Color.Empty
      Me.tbpRegistro.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tbpRegistro.InactiveTextColor = System.Drawing.Color.Empty
      Me.tbpRegistro.Location = New System.Drawing.Point(1, 24)
      Me.tbpRegistro.Name = "tbpRegistro"
      Me.tbpRegistro.SelectBackColor = System.Drawing.Color.Empty
      Me.tbpRegistro.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tbpRegistro.SelectTextColor = System.Drawing.Color.Empty
      Me.tbpRegistro.Size = New System.Drawing.Size(786, 297)
      Me.tbpRegistro.TabIndex = 4
      Me.tbpRegistro.Title = "Registro de Incidencias"
      Me.tbpRegistro.ToolTip = "Registro de Incidencias"
      '
      'pnlDatos
      '
      Me.pnlDatos.Controls.Add(Me.cmbTipoIncidencia)
      Me.pnlDatos.Controls.Add(Me.Label14)
      Me.pnlDatos.Controls.Add(Me.actxnMonto)
      Me.pnlDatos.Controls.Add(Me.Label7)
      Me.pnlDatos.Controls.Add(Me.cmbTipoMoneda)
      Me.pnlDatos.Controls.Add(Me.Label5)
      Me.pnlDatos.Controls.Add(Me.chkComprobante)
      Me.pnlDatos.Controls.Add(Me.txtAccion)
      Me.pnlDatos.Controls.Add(Me.Label3)
      Me.pnlDatos.Controls.Add(Me.dtpFecha)
      Me.pnlDatos.Controls.Add(Me.Label2)
      Me.pnlDatos.Controls.Add(Me.txtDescripcion)
      Me.pnlDatos.Controls.Add(Me.Label1)
      Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
      Me.pnlDatos.Name = "pnlDatos"
      Me.pnlDatos.Size = New System.Drawing.Size(786, 188)
      Me.pnlDatos.TabIndex = 0
      '
      'cmbTipoIncidencia
      '
      Me.cmbTipoIncidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoIncidencia.FormattingEnabled = True
      Me.cmbTipoIncidencia.Location = New System.Drawing.Point(118, 11)
      Me.cmbTipoIncidencia.Name = "cmbTipoIncidencia"
      Me.cmbTipoIncidencia.Size = New System.Drawing.Size(280, 23)
      Me.cmbTipoIncidencia.TabIndex = 1
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(32, 15)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(89, 15)
      Me.Label14.TabIndex = 0
      Me.Label14.Text = "Tipo Incidente :"
      '
      'actxnMonto
      '
      Me.actxnMonto.ACEnteros = 9
      Me.actxnMonto.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnMonto.ACFormato = "########0.00"
      Me.actxnMonto.ACNegativo = True
      Me.actxnMonto.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
      Me.actxnMonto.Location = New System.Drawing.Point(118, 126)
      Me.actxnMonto.MaxLength = 12
      Me.actxnMonto.Name = "actxnMonto"
      Me.actxnMonto.Size = New System.Drawing.Size(90, 23)
      Me.actxnMonto.TabIndex = 7
      Me.actxnMonto.Text = "0.00"
      Me.actxnMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(70, 130)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(49, 15)
      Me.Label7.TabIndex = 6
      Me.Label7.Text = "Monto :"
      '
      'cmbTipoMoneda
      '
      Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoMoneda.FormattingEnabled = True
      Me.cmbTipoMoneda.Location = New System.Drawing.Point(316, 126)
      Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
      Me.cmbTipoMoneda.Size = New System.Drawing.Size(280, 23)
      Me.cmbTipoMoneda.TabIndex = 9
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(235, 130)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(84, 15)
      Me.Label5.TabIndex = 8
      Me.Label5.Text = "Tipo Moneda :"
      '
      'chkComprobante
      '
      Me.chkComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chkComprobante.AutoSize = True
      Me.chkComprobante.Location = New System.Drawing.Point(12, 172)
      Me.chkComprobante.Name = "chkComprobante"
      Me.chkComprobante.Size = New System.Drawing.Size(146, 19)
      Me.chkComprobante.TabIndex = 12
      Me.chkComprobante.Text = "Comprobante de Pago"
      Me.chkComprobante.UseVisualStyleBackColor = True
      '
      'txtAccion
      '
      Me.txtAccion.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtAccion.Location = New System.Drawing.Point(118, 80)
      Me.txtAccion.MaxLength = 500
      Me.txtAccion.Multiline = True
      Me.txtAccion.Name = "txtAccion"
      Me.txtAccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtAccion.Size = New System.Drawing.Size(659, 40)
      Me.txtAccion.TabIndex = 5
      Me.txtAccion.Tag = "EVO"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(20, 83)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(102, 15)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Acción Realizada :"
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(118, 153)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(90, 23)
      Me.dtpFecha.TabIndex = 11
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(71, 157)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(44, 15)
      Me.Label2.TabIndex = 10
      Me.Label2.Text = "Fecha :"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.Location = New System.Drawing.Point(118, 38)
      Me.txtDescripcion.MaxLength = 120
      Me.txtDescripcion.Multiline = True
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtDescripcion.Size = New System.Drawing.Size(659, 36)
      Me.txtDescripcion.TabIndex = 3
      Me.txtDescripcion.Tag = "EVO"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(46, 41)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(75, 15)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Descripción :"
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
      Me.grpComprobante.Location = New System.Drawing.Point(0, 188)
      Me.grpComprobante.Name = "grpComprobante"
      Me.grpComprobante.Size = New System.Drawing.Size(786, 109)
      Me.grpComprobante.TabIndex = 1
      Me.grpComprobante.TabStop = False
      '
      'actxaDescProveedor
      '
      Me.actxaDescProveedor.ACActivarAyudaAuto = False
      Me.actxaDescProveedor.ACLongitudAceptada = 0
      Me.actxaDescProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxaDescProveedor.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxaDescProveedor.Location = New System.Drawing.Point(207, 22)
      Me.actxaDescProveedor.MaxLength = 80
      Me.actxaDescProveedor.Name = "actxaDescProveedor"
      Me.actxaDescProveedor.Size = New System.Drawing.Size(536, 23)
      Me.actxaDescProveedor.TabIndex = 2
      Me.actxaDescProveedor.Tag = "EVO"
      '
      'lblProveedor
      '
      Me.lblProveedor.AutoSize = True
      Me.lblProveedor.Location = New System.Drawing.Point(9, 27)
      Me.lblProveedor.Name = "lblProveedor"
      Me.lblProveedor.Size = New System.Drawing.Size(67, 15)
      Me.lblProveedor.TabIndex = 0
      Me.lblProveedor.Text = "Proveedor :"
      '
      'actxaNroDocProveedor
      '
      Me.actxaNroDocProveedor.ACActivarAyudaAuto = False
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
      Me.grpDocumento.Controls.Add(Me.actxnNumero)
      Me.grpDocumento.Controls.Add(Me.Label4)
      Me.grpDocumento.Controls.Add(Me.Label6)
      Me.grpDocumento.Location = New System.Drawing.Point(3, 50)
      Me.grpDocumento.Name = "grpDocumento"
      Me.grpDocumento.Size = New System.Drawing.Size(400, 56)
      Me.grpDocumento.TabIndex = 1
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
      'tbpConsulta
      '
      Me.tbpConsulta.Controls.Add(Me.c1grdIncidencias)
      Me.tbpConsulta.Controls.Add(Me.bnavIncidencias)
      Me.tbpConsulta.InactiveBackColor = System.Drawing.Color.Empty
      Me.tbpConsulta.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tbpConsulta.InactiveTextColor = System.Drawing.Color.Empty
      Me.tbpConsulta.Location = New System.Drawing.Point(1, 24)
      Me.tbpConsulta.Name = "tbpConsulta"
      Me.tbpConsulta.SelectBackColor = System.Drawing.Color.Empty
      Me.tbpConsulta.Selected = False
      Me.tbpConsulta.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tbpConsulta.SelectTextColor = System.Drawing.Color.Empty
      Me.tbpConsulta.Size = New System.Drawing.Size(786, 297)
      Me.tbpConsulta.TabIndex = 5
      Me.tbpConsulta.Title = "Incidencias Registradas"
      Me.tbpConsulta.ToolTip = "Incidencias Registradas"
      '
      'c1grdIncidencias
      '
      Me.c1grdIncidencias.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdIncidencias.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdIncidencias.Location = New System.Drawing.Point(0, 0)
      Me.c1grdIncidencias.Name = "c1grdIncidencias"
      Me.c1grdIncidencias.Rows.Count = 2
      Me.c1grdIncidencias.Rows.DefaultSize = 20
      Me.c1grdIncidencias.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
      Me.c1grdIncidencias.Size = New System.Drawing.Size(786, 272)
      Me.c1grdIncidencias.StyleInfo = resources.GetString("c1grdIncidencias.StyleInfo")
      Me.c1grdIncidencias.TabIndex = 4
      '
      'bnavIncidencias
      '
      Me.bnavIncidencias.AddNewItem = Me.ToolStripButton1
      Me.bnavIncidencias.CountItem = Me.ToolStripLabel1
      Me.bnavIncidencias.DeleteItem = Me.ToolStripButton2
      Me.bnavIncidencias.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavIncidencias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2})
      Me.bnavIncidencias.Location = New System.Drawing.Point(0, 272)
      Me.bnavIncidencias.MoveFirstItem = Me.ToolStripButton3
      Me.bnavIncidencias.MoveLastItem = Me.ToolStripButton6
      Me.bnavIncidencias.MoveNextItem = Me.ToolStripButton5
      Me.bnavIncidencias.MovePreviousItem = Me.ToolStripButton4
      Me.bnavIncidencias.Name = "bnavIncidencias"
      Me.bnavIncidencias.PositionItem = Me.ToolStripTextBox1
      Me.bnavIncidencias.Size = New System.Drawing.Size(786, 25)
      Me.bnavIncidencias.TabIndex = 5
      Me.bnavIncidencias.Text = "BindingNavigator1"
      '
      'ToolStripButton1
      '
      Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
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
      Me.ToolStripButton2.Name = "ToolStripButton2"
      Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton2.Text = "Delete"
      Me.ToolStripButton2.Visible = False
      '
      'ToolStripButton3
      '
      Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton3.Name = "ToolStripButton3"
      Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton3.Text = "Move first"
      '
      'ToolStripButton4
      '
      Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
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
      Me.ToolStripButton5.Name = "ToolStripButton5"
      Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton5.Text = "Move next"
      '
      'ToolStripButton6
      '
      Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
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
      'Panel1
      '
      Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Panel1.Controls.Add(Me.txtPlaca)
      Me.Panel1.Controls.Add(Me.txtModelo)
      Me.Panel1.Controls.Add(Me.cmbCombustible)
      Me.Panel1.Controls.Add(Me.cmbMarca)
      Me.Panel1.Controls.Add(Me.cmbTipVehiculo)
      Me.Panel1.Controls.Add(Me.txtVehiculoID)
      Me.Panel1.Controls.Add(Me.lblPlaca)
      Me.Panel1.Controls.Add(Me.lblModelo)
      Me.Panel1.Controls.Add(Me.lblTipCombustible)
      Me.Panel1.Controls.Add(Me.lblMarca)
      Me.Panel1.Controls.Add(Me.lblCodTipVehiculo)
      Me.Panel1.Controls.Add(Me.lblVehiculoID)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Enabled = False
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(788, 90)
      Me.Panel1.TabIndex = 2
      '
      'txtPlaca
      '
      Me.txtPlaca.Location = New System.Drawing.Point(439, 3)
      Me.txtPlaca.Name = "txtPlaca"
      Me.txtPlaca.Size = New System.Drawing.Size(219, 23)
      Me.txtPlaca.TabIndex = 9
      Me.txtPlaca.Tag = "EVO"
      '
      'txtModelo
      '
      Me.txtModelo.Location = New System.Drawing.Point(118, 57)
      Me.txtModelo.Name = "txtModelo"
      Me.txtModelo.Size = New System.Drawing.Size(219, 23)
      Me.txtModelo.TabIndex = 15
      Me.txtModelo.Tag = "EV"
      '
      'cmbCombustible
      '
      Me.cmbCombustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCombustible.FormattingEnabled = True
      Me.cmbCombustible.Location = New System.Drawing.Point(439, 57)
      Me.cmbCombustible.Name = "cmbCombustible"
      Me.cmbCombustible.Size = New System.Drawing.Size(219, 23)
      Me.cmbCombustible.TabIndex = 17
      Me.cmbCombustible.Tag = "ECO"
      '
      'cmbMarca
      '
      Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarca.FormattingEnabled = True
      Me.cmbMarca.Location = New System.Drawing.Point(118, 30)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(219, 23)
      Me.cmbMarca.TabIndex = 12
      Me.cmbMarca.Tag = "ECO"
      '
      'cmbTipVehiculo
      '
      Me.cmbTipVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipVehiculo.FormattingEnabled = True
      Me.cmbTipVehiculo.Location = New System.Drawing.Point(439, 30)
      Me.cmbTipVehiculo.Name = "cmbTipVehiculo"
      Me.cmbTipVehiculo.Size = New System.Drawing.Size(219, 23)
      Me.cmbTipVehiculo.TabIndex = 14
      Me.cmbTipVehiculo.Tag = "ECO"
      '
      'txtVehiculoID
      '
      Me.txtVehiculoID.Location = New System.Drawing.Point(118, 3)
      Me.txtVehiculoID.Name = "txtVehiculoID"
      Me.txtVehiculoID.Size = New System.Drawing.Size(124, 23)
      Me.txtVehiculoID.TabIndex = 8
      Me.txtVehiculoID.Tag = "EV"
      '
      'lblPlaca
      '
      Me.lblPlaca.AutoSize = True
      Me.lblPlaca.Location = New System.Drawing.Point(394, 7)
      Me.lblPlaca.Name = "lblPlaca"
      Me.lblPlaca.Size = New System.Drawing.Size(41, 15)
      Me.lblPlaca.TabIndex = 18
      Me.lblPlaca.Text = "Placa :"
      '
      'lblModelo
      '
      Me.lblModelo.AutoSize = True
      Me.lblModelo.Location = New System.Drawing.Point(64, 61)
      Me.lblModelo.Name = "lblModelo"
      Me.lblModelo.Size = New System.Drawing.Size(54, 15)
      Me.lblModelo.TabIndex = 16
      Me.lblModelo.Text = "Modelo :"
      '
      'lblTipCombustible
      '
      Me.lblTipCombustible.AutoSize = True
      Me.lblTipCombustible.Location = New System.Drawing.Point(361, 61)
      Me.lblTipCombustible.Name = "lblTipCombustible"
      Me.lblTipCombustible.Size = New System.Drawing.Size(81, 15)
      Me.lblTipCombustible.TabIndex = 13
      Me.lblTipCombustible.Text = "Combustible :"
      '
      'lblMarca
      '
      Me.lblMarca.AutoSize = True
      Me.lblMarca.Location = New System.Drawing.Point(69, 34)
      Me.lblMarca.Name = "lblMarca"
      Me.lblMarca.Size = New System.Drawing.Size(46, 15)
      Me.lblMarca.TabIndex = 11
      Me.lblMarca.Text = "Marca :"
      '
      'lblCodTipVehiculo
      '
      Me.lblCodTipVehiculo.AutoSize = True
      Me.lblCodTipVehiculo.Location = New System.Drawing.Point(357, 34)
      Me.lblCodTipVehiculo.Name = "lblCodTipVehiculo"
      Me.lblCodTipVehiculo.Size = New System.Drawing.Size(86, 15)
      Me.lblCodTipVehiculo.TabIndex = 10
      Me.lblCodTipVehiculo.Text = "Tipo Vehiculo :"
      '
      'lblVehiculoID
      '
      Me.lblVehiculoID.AutoSize = True
      Me.lblVehiculoID.Location = New System.Drawing.Point(45, 7)
      Me.lblVehiculoID.Name = "lblVehiculoID"
      Me.lblVehiculoID.Size = New System.Drawing.Size(73, 15)
      Me.lblVehiculoID.TabIndex = 7
      Me.lblVehiculoID.Text = "Vehiculo ID :"
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
      Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
      Me.tabBusqueda.Size = New System.Drawing.Size(788, 412)
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
      Me.c1grdBusqueda.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
      Me.c1grdBusqueda.Size = New System.Drawing.Size(788, 336)
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
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 387)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(788, 25)
      Me.bnavBusqueda.TabIndex = 3
      Me.bnavBusqueda.Text = "BindingNavigator1"
      '
      'BindingNavigatorAddNewItem
      '
      Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
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
      Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
      Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorDeleteItem.Text = "Delete"
      Me.BindingNavigatorDeleteItem.Visible = False
      '
      'BindingNavigatorMoveFirstItem
      '
      Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
      Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorMoveFirstItem.Text = "Move first"
      '
      'BindingNavigatorMovePreviousItem
      '
      Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
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
      Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
      Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorMoveNextItem.Text = "Move next"
      '
      'BindingNavigatorMoveLastItem
      '
      Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
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
      Me.grpBusqueda.Controls.Add(Me.rbtnPlaca)
      Me.grpBusqueda.Controls.Add(Me.rbtnCodigo)
      Me.grpBusqueda.Controls.Add(Me.btnConsultar)
      Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
      Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
      Me.grpBusqueda.Name = "grpBusqueda"
      Me.grpBusqueda.Size = New System.Drawing.Size(788, 51)
      Me.grpBusqueda.TabIndex = 1
      Me.grpBusqueda.TabStop = False
      Me.grpBusqueda.Text = "Opciones de Busqueda"
      '
      'rbtnCodigo
      '
      Me.rbtnCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnCodigo.AutoSize = True
      Me.rbtnCodigo.Location = New System.Drawing.Point(500, 20)
      Me.rbtnCodigo.Name = "rbtnCodigo"
      Me.rbtnCodigo.Size = New System.Drawing.Size(64, 19)
      Me.rbtnCodigo.TabIndex = 36
      Me.rbtnCodigo.Text = "Codigo"
      Me.rbtnCodigo.UseVisualStyleBackColor = True
      '
      'txtBusqueda
      '
      Me.txtBusqueda.ACActivarAyudaAuto = False
      Me.txtBusqueda.ACLongitudAceptada = 0
      Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBusqueda.Location = New System.Drawing.Point(17, 18)
      Me.txtBusqueda.MaxLength = 32767
      Me.txtBusqueda.Name = "txtBusqueda"
      Me.txtBusqueda.Size = New System.Drawing.Size(466, 23)
      Me.txtBusqueda.TabIndex = 0
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
      Me.acTool.Location = New System.Drawing.Point(0, 467)
      Me.acTool.Name = "acTool"
      Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.acTool.Size = New System.Drawing.Size(790, 56)
      Me.acTool.TabIndex = 2
      Me.acTool.Text = "AcToolBarMantHorizontalNew1"
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Incidencias de Vehiculos"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(790, 30)
      Me.acpnlTitulo.TabIndex = 0
      '
      'btnNueProveedor
      '
      Me.btnNueProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnNueProveedor.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
      Me.btnNueProveedor.Location = New System.Drawing.Point(746, 20)
      Me.btnNueProveedor.Name = "btnNueProveedor"
      Me.btnNueProveedor.Size = New System.Drawing.Size(29, 27)
      Me.btnNueProveedor.TabIndex = 3
      Me.btnNueProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnNueProveedor.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(683, 9)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(99, 41)
      Me.btnConsultar.TabIndex = 35
      Me.btnConsultar.Text = "Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'rbtnPlaca
      '
      Me.rbtnPlaca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnPlaca.AutoSize = True
      Me.rbtnPlaca.Checked = True
      Me.rbtnPlaca.Location = New System.Drawing.Point(583, 20)
      Me.rbtnPlaca.Name = "rbtnPlaca"
      Me.rbtnPlaca.Size = New System.Drawing.Size(74, 19)
      Me.rbtnPlaca.TabIndex = 37
      Me.rbtnPlaca.Text = "Por Placa"
      Me.rbtnPlaca.UseVisualStyleBackColor = True
      '
      'PVehiculosIncidencias
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(790, 523)
      Me.Controls.Add(Me.tabMantenimiento)
      Me.Controls.Add(Me.acTool)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Name = "PVehiculosIncidencias"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Incidencias de Vehiculos"
      Me.tabMantenimiento.ResumeLayout(False)
      Me.tabDatos.ResumeLayout(False)
      Me.tbcIncidencias.ResumeLayout(False)
      Me.tbpRegistro.ResumeLayout(False)
      Me.pnlDatos.ResumeLayout(False)
      Me.pnlDatos.PerformLayout()
      Me.grpComprobante.ResumeLayout(False)
      Me.grpComprobante.PerformLayout()
      Me.grpDocumento.ResumeLayout(False)
      Me.grpDocumento.PerformLayout()
      Me.tbpConsulta.ResumeLayout(False)
      Me.tbpConsulta.PerformLayout()
      CType(Me.c1grdIncidencias, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavIncidencias, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavIncidencias.ResumeLayout(False)
      Me.bnavIncidencias.PerformLayout()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.tabBusqueda.ResumeLayout(False)
      Me.tabBusqueda.PerformLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavBusqueda.ResumeLayout(False)
      Me.bnavBusqueda.PerformLayout()
      Me.grpBusqueda.ResumeLayout(False)
      Me.grpBusqueda.PerformLayout()
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
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents txtAccion As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents grpComprobante As System.Windows.Forms.GroupBox
   Friend WithEvents grpDocumento As System.Windows.Forms.GroupBox
   Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
   Friend WithEvents cmbGuia As System.Windows.Forms.ComboBox
   Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents actxaDescProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents lblProveedor As System.Windows.Forms.Label
   Friend WithEvents actxaNroDocProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents chkComprobante As System.Windows.Forms.CheckBox
   Friend WithEvents btnNueProveedor As System.Windows.Forms.Button
   Friend WithEvents txtSerie As System.Windows.Forms.TextBox
   Friend WithEvents btnConsultar As System.Windows.Forms.Button
   Friend WithEvents rbtnCodigo As System.Windows.Forms.RadioButton
   Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents actxnMonto As ACControles.ACTextBoxNumerico
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Private WithEvents tbcIncidencias As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents tbpRegistro As Crownwood.DotNetMagic.Controls.TabPage
   Private WithEvents tbpConsulta As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents c1grdIncidencias As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavIncidencias As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents cmbTipoIncidencia As System.Windows.Forms.ComboBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
   Friend WithEvents txtModelo As System.Windows.Forms.TextBox
   Friend WithEvents cmbCombustible As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMarca As System.Windows.Forms.ComboBox
   Friend WithEvents cmbTipVehiculo As System.Windows.Forms.ComboBox
   Friend WithEvents txtVehiculoID As System.Windows.Forms.TextBox
   Friend WithEvents lblPlaca As System.Windows.Forms.Label
   Friend WithEvents lblModelo As System.Windows.Forms.Label
   Friend WithEvents lblTipCombustible As System.Windows.Forms.Label
   Friend WithEvents lblMarca As System.Windows.Forms.Label
   Friend WithEvents lblCodTipVehiculo As System.Windows.Forms.Label
   Friend WithEvents lblVehiculoID As System.Windows.Forms.Label
   Friend WithEvents rbtnPlaca As System.Windows.Forms.RadioButton
End Class
