<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCotizaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FCotizaciones))
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.actextBusqDescripcion = New ACControles.ACTextBoxAyuda()
        Me.cmbDireccionOrigen = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.actxtUbigoDestino = New ACControles.ACTextBoxAyuda()
        Me.actxtUbigoOrigen = New ACControles.ACTextBoxAyuda()
        Me.cmbDireccionDestino = New System.Windows.Forms.ComboBox()
        Me.actxnTotalValorReferencial = New ACControles.ACTextBoxNumerico()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.actxnValorReferencialXTm = New ACControles.ACTextBoxNumerico()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbDocumento = New System.Windows.Forms.ComboBox()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.actxnIGV = New ACControles.ACTextBoxNumerico()
        Me.chkIGV = New System.Windows.Forms.CheckBox()
        Me.chkOrdenTransporte = New System.Windows.Forms.CheckBox()
        Me.actxnMontoXTm = New ACControles.ACTextBoxNumerico()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.actxnPeso = New ACControles.ACTextBoxNumerico()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRClean = New System.Windows.Forms.Button()
        Me.btnREditar = New System.Windows.Forms.Button()
        Me.btnRNuevo = New System.Windows.Forms.Button()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.actxnDispVehiculos = New ACControles.ACTextBoxNumerico()
        Me.actxaRuta = New ACControles.ACTextBoxAyuda()
        Me.actxaCliente = New ACControles.ACTextBoxAyuda()
        Me.actxaCodRuta = New ACControles.ACTextBoxAyuda()
        Me.actxaCliRuc = New ACControles.ACTextBoxAyuda()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtCarga = New System.Windows.Forms.TextBox()
        Me.actxnMonto = New ACControles.ACTextBoxNumerico()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblNroDocumento = New System.Windows.Forms.Label()
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
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.chkMostrarTodos = New System.Windows.Forms.CheckBox()
        Me.rbtnCliente = New System.Windows.Forms.RadioButton()
        Me.rbtnCodigo = New System.Windows.Forms.RadioButton()
        Me.AcFecha = New ACControles.ACFecha(Me.components)
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.btnModificarDesdeFactura = New System.Windows.Forms.ToolStripButton()
        Me.acbtnRecOrden = New ACControles.ACToolStripButton(Me.components)
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.tabMantenimiento.Size = New System.Drawing.Size(1148, 639)
        Me.tabMantenimiento.TabIndex = 12
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
        Me.tabDatos.Size = New System.Drawing.Size(1146, 614)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.actextBusqDescripcion)
        Me.pnlDatos.Controls.Add(Me.cmbDireccionOrigen)
        Me.pnlDatos.Controls.Add(Me.Label15)
        Me.pnlDatos.Controls.Add(Me.Label14)
        Me.pnlDatos.Controls.Add(Me.Panel1)
        Me.pnlDatos.Controls.Add(Me.cmbDireccionDestino)
        Me.pnlDatos.Controls.Add(Me.actxnTotalValorReferencial)
        Me.pnlDatos.Controls.Add(Me.Label11)
        Me.pnlDatos.Controls.Add(Me.actxnValorReferencialXTm)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.cmbDocumento)
        Me.pnlDatos.Controls.Add(Me.lblDocumento)
        Me.pnlDatos.Controls.Add(Me.actxnIGV)
        Me.pnlDatos.Controls.Add(Me.chkIGV)
        Me.pnlDatos.Controls.Add(Me.chkOrdenTransporte)
        Me.pnlDatos.Controls.Add(Me.actxnMontoXTm)
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.actxnPeso)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.btnRClean)
        Me.pnlDatos.Controls.Add(Me.btnREditar)
        Me.pnlDatos.Controls.Add(Me.btnRNuevo)
        Me.pnlDatos.Controls.Add(Me.btnClean)
        Me.pnlDatos.Controls.Add(Me.btnEditar)
        Me.pnlDatos.Controls.Add(Me.btnNuevo)
        Me.pnlDatos.Controls.Add(Me.lblMoneda)
        Me.pnlDatos.Controls.Add(Me.cmbMoneda)
        Me.pnlDatos.Controls.Add(Me.actxnDispVehiculos)
        Me.pnlDatos.Controls.Add(Me.actxaRuta)
        Me.pnlDatos.Controls.Add(Me.actxaCliente)
        Me.pnlDatos.Controls.Add(Me.actxaCodRuta)
        Me.pnlDatos.Controls.Add(Me.actxaCliRuc)
        Me.pnlDatos.Controls.Add(Me.txtCodigo)
        Me.pnlDatos.Controls.Add(Me.txtCarga)
        Me.pnlDatos.Controls.Add(Me.actxnMonto)
        Me.pnlDatos.Controls.Add(Me.dtpFecha)
        Me.pnlDatos.Controls.Add(Me.Label7)
        Me.pnlDatos.Controls.Add(Me.Label6)
        Me.pnlDatos.Controls.Add(Me.lblRuta)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.lblFecha)
        Me.pnlDatos.Controls.Add(Me.lblNroDocumento)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1146, 614)
        Me.pnlDatos.TabIndex = 0
        '
        'actextBusqDescripcion
        '
        Me.actextBusqDescripcion.ACActivarAyudaAuto = False
        Me.actextBusqDescripcion.ACLongitudAceptada = 0
        Me.actextBusqDescripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actextBusqDescripcion.Location = New System.Drawing.Point(622, 135)
        Me.actextBusqDescripcion.MaxLength = 8
        Me.actextBusqDescripcion.Name = "actextBusqDescripcion"
        Me.actextBusqDescripcion.Size = New System.Drawing.Size(117, 23)
        Me.actextBusqDescripcion.TabIndex = 53
        Me.actextBusqDescripcion.Tag = "EV"
        '
        'cmbDireccionOrigen
        '
        Me.cmbDireccionOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDireccionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDireccionOrigen.DropDownWidth = 250
        Me.cmbDireccionOrigen.FormattingEnabled = True
        Me.cmbDireccionOrigen.Location = New System.Drawing.Point(105, 110)
        Me.cmbDireccionOrigen.Name = "cmbDireccionOrigen"
        Me.cmbDireccionOrigen.Size = New System.Drawing.Size(502, 23)
        Me.cmbDireccionOrigen.TabIndex = 51
        Me.cmbDireccionOrigen.Tag = "EO"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 143)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "Punto Destino"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 114)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 15)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "Punto Origen"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.actxtUbigoDestino)
        Me.Panel1.Controls.Add(Me.actxtUbigoOrigen)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 538)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1146, 76)
        Me.Panel1.TabIndex = 39
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(242, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 34)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Ubigeo Destino"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(3, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 34)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Ubigeo Origen"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'actxtUbigoDestino
        '
        Me.actxtUbigoDestino.ACActivarAyudaAuto = False
        Me.actxtUbigoDestino.ACLongitudAceptada = 0
        Me.actxtUbigoDestino.Location = New System.Drawing.Point(310, 40)
        Me.actxtUbigoDestino.MaxLength = 8
        Me.actxtUbigoDestino.Name = "actxtUbigoDestino"
        Me.actxtUbigoDestino.Size = New System.Drawing.Size(191, 23)
        Me.actxtUbigoDestino.TabIndex = 11
        Me.actxtUbigoDestino.Tag = "EV"
        '
        'actxtUbigoOrigen
        '
        Me.actxtUbigoOrigen.ACActivarAyudaAuto = False
        Me.actxtUbigoOrigen.ACLongitudAceptada = 0
        Me.actxtUbigoOrigen.Location = New System.Drawing.Point(63, 40)
        Me.actxtUbigoOrigen.MaxLength = 8
        Me.actxtUbigoOrigen.Name = "actxtUbigoOrigen"
        Me.actxtUbigoOrigen.Size = New System.Drawing.Size(180, 23)
        Me.actxtUbigoOrigen.TabIndex = 10
        Me.actxtUbigoOrigen.Tag = "EV"
        '
        'cmbDireccionDestino
        '
        Me.cmbDireccionDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDireccionDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDireccionDestino.DropDownWidth = 250
        Me.cmbDireccionDestino.FormattingEnabled = True
        Me.cmbDireccionDestino.Location = New System.Drawing.Point(105, 135)
        Me.cmbDireccionDestino.Name = "cmbDireccionDestino"
        Me.cmbDireccionDestino.Size = New System.Drawing.Size(502, 23)
        Me.cmbDireccionDestino.TabIndex = 50
        Me.cmbDireccionDestino.Tag = "EO"
        '
        'actxnTotalValorReferencial
        '
        Me.actxnTotalValorReferencial.ACEnteros = 9
        Me.actxnTotalValorReferencial.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTotalValorReferencial.ACNegativo = True
        Me.actxnTotalValorReferencial.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTotalValorReferencial.Enabled = False
        Me.actxnTotalValorReferencial.Location = New System.Drawing.Point(535, 262)
        Me.actxnTotalValorReferencial.MaxLength = 12
        Me.actxnTotalValorReferencial.Name = "actxnTotalValorReferencial"
        Me.actxnTotalValorReferencial.Size = New System.Drawing.Size(117, 23)
        Me.actxnTotalValorReferencial.TabIndex = 38
        Me.actxnTotalValorReferencial.Tag = "EV"
        Me.actxnTotalValorReferencial.Text = "0.00"
        Me.actxnTotalValorReferencial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(468, 266)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 15)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Total V.R. :"
        '
        'actxnValorReferencialXTm
        '
        Me.actxnValorReferencialXTm.ACDecimales = 4
        Me.actxnValorReferencialXTm.ACEnteros = 9
        Me.actxnValorReferencialXTm.ACFormato = "###,###,##0.0000"
        Me.actxnValorReferencialXTm.ACNegativo = True
        Me.actxnValorReferencialXTm.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnValorReferencialXTm.Enabled = False
        Me.actxnValorReferencialXTm.Location = New System.Drawing.Point(535, 233)
        Me.actxnValorReferencialXTm.MaxLength = 12
        Me.actxnValorReferencialXTm.Name = "actxnValorReferencialXTm"
        Me.actxnValorReferencialXTm.Size = New System.Drawing.Size(117, 23)
        Me.actxnValorReferencialXTm.TabIndex = 35
        Me.actxnValorReferencialXTm.Tag = "EV"
        Me.actxnValorReferencialXTm.Text = "0.0000"
        Me.actxnValorReferencialXTm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(664, 237)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Por T.M."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(429, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 15)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Valor Referencial :"
        '
        'cmbDocumento
        '
        Me.cmbDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumento.FormattingEnabled = True
        Me.cmbDocumento.Items.AddRange(New Object() {"Pedido", "Cotización"})
        Me.cmbDocumento.Location = New System.Drawing.Point(936, 206)
        Me.cmbDocumento.Name = "cmbDocumento"
        Me.cmbDocumento.Size = New System.Drawing.Size(178, 23)
        Me.cmbDocumento.TabIndex = 29
        '
        'lblDocumento
        '
        Me.lblDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDocumento.AutoSize = True
        Me.lblDocumento.Location = New System.Drawing.Point(858, 210)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(76, 15)
        Me.lblDocumento.TabIndex = 28
        Me.lblDocumento.Text = "&Documento :"
        '
        'actxnIGV
        '
        Me.actxnIGV.ACDecimales = 4
        Me.actxnIGV.ACEnteros = 9
        Me.actxnIGV.ACFormato = "###,###,##0.0000"
        Me.actxnIGV.ACNegativo = True
        Me.actxnIGV.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnIGV.Location = New System.Drawing.Point(125, 262)
        Me.actxnIGV.MaxLength = 12
        Me.actxnIGV.Name = "actxnIGV"
        Me.actxnIGV.Size = New System.Drawing.Size(96, 23)
        Me.actxnIGV.TabIndex = 22
        Me.actxnIGV.Tag = "EV"
        Me.actxnIGV.Text = "0.0000"
        Me.actxnIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkIGV
        '
        Me.chkIGV.AutoSize = True
        Me.chkIGV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIGV.Location = New System.Drawing.Point(20, 262)
        Me.chkIGV.Name = "chkIGV"
        Me.chkIGV.Size = New System.Drawing.Size(99, 19)
        Me.chkIGV.TabIndex = 21
        Me.chkIGV.Text = "Con I.G.V. :     "
        Me.chkIGV.UseVisualStyleBackColor = True
        '
        'chkOrdenTransporte
        '
        Me.chkOrdenTransporte.AutoSize = True
        Me.chkOrdenTransporte.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOrdenTransporte.Location = New System.Drawing.Point(536, 5)
        Me.chkOrdenTransporte.Name = "chkOrdenTransporte"
        Me.chkOrdenTransporte.Size = New System.Drawing.Size(177, 19)
        Me.chkOrdenTransporte.TabIndex = 30
        Me.chkOrdenTransporte.Text = "Generar Orden de Transporte"
        Me.chkOrdenTransporte.UseVisualStyleBackColor = True
        Me.chkOrdenTransporte.Visible = False
        '
        'actxnMontoXTm
        '
        Me.actxnMontoXTm.ACDecimales = 8
        Me.actxnMontoXTm.ACEnteros = 9
        Me.actxnMontoXTm.ACFormato = "###,###,##0.00000000"
        Me.actxnMontoXTm.ACNegativo = True
        Me.actxnMontoXTm.ACValue = New Decimal(New Integer() {0, 0, 0, 393216})
        Me.actxnMontoXTm.Location = New System.Drawing.Point(104, 233)
        Me.actxnMontoXTm.MaxLength = 12
        Me.actxnMontoXTm.Name = "actxnMontoXTm"
        Me.actxnMontoXTm.Size = New System.Drawing.Size(117, 23)
        Me.actxnMontoXTm.TabIndex = 19
        Me.actxnMontoXTm.Tag = "EV"
        Me.actxnMontoXTm.Text = "0.00000000"
        Me.actxnMontoXTm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(233, 237)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Por T.M."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(227, 294)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 15)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "T.M."
        '
        'actxnPeso
        '
        Me.actxnPeso.ACDecimales = 4
        Me.actxnPeso.ACEnteros = 9
        Me.actxnPeso.ACFormato = "###,###,##0.0000"
        Me.actxnPeso.ACNegativo = True
        Me.actxnPeso.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnPeso.Location = New System.Drawing.Point(104, 291)
        Me.actxnPeso.MaxLength = 12
        Me.actxnPeso.Name = "actxnPeso"
        Me.actxnPeso.Size = New System.Drawing.Size(117, 23)
        Me.actxnPeso.TabIndex = 24
        Me.actxnPeso.Tag = "EV"
        Me.actxnPeso.Text = "0.0000"
        Me.actxnPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 294)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 15)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Peso Total :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 237)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Monto :"
        '
        'btnRClean
        '
        Me.btnRClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRClean.Image = Global.ACPTransportes.My.Resources.Resources.Delete_16x16
        Me.btnRClean.Location = New System.Drawing.Point(1084, 76)
        Me.btnRClean.Name = "btnRClean"
        Me.btnRClean.Size = New System.Drawing.Size(30, 27)
        Me.btnRClean.TabIndex = 13
        Me.btnRClean.UseVisualStyleBackColor = True
        '
        'btnREditar
        '
        Me.btnREditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnREditar.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.btnREditar.Location = New System.Drawing.Point(1054, 76)
        Me.btnREditar.Name = "btnREditar"
        Me.btnREditar.Size = New System.Drawing.Size(30, 27)
        Me.btnREditar.TabIndex = 12
        Me.btnREditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnREditar.UseVisualStyleBackColor = True
        '
        'btnRNuevo
        '
        Me.btnRNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRNuevo.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnRNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRNuevo.Location = New System.Drawing.Point(1024, 76)
        Me.btnRNuevo.Name = "btnRNuevo"
        Me.btnRNuevo.Size = New System.Drawing.Size(30, 27)
        Me.btnRNuevo.TabIndex = 11
        Me.btnRNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRNuevo.UseVisualStyleBackColor = True
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClean.Image = Global.ACPTransportes.My.Resources.Resources.Delete_16x16
        Me.btnClean.Location = New System.Drawing.Point(1085, 47)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(30, 27)
        Me.btnClean.TabIndex = 7
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.btnEditar.Location = New System.Drawing.Point(1055, 47)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(30, 27)
        Me.btnEditar.TabIndex = 6
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(1025, 47)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(30, 27)
        Me.btnNuevo.TabIndex = 5
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(31, 208)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(57, 15)
        Me.lblMoneda.TabIndex = 32
        Me.lblMoneda.Text = "&Moneda :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.DropDownWidth = 250
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(104, 204)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(118, 23)
        Me.cmbMoneda.TabIndex = 33
        Me.cmbMoneda.Tag = "EO"
        '
        'actxnDispVehiculos
        '
        Me.actxnDispVehiculos.ACEnteros = 8
        Me.actxnDispVehiculos.ACFormato = "#######0.00"
        Me.actxnDispVehiculos.ACNegativo = True
        Me.actxnDispVehiculos.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnDispVehiculos.Location = New System.Drawing.Point(591, 176)
        Me.actxnDispVehiculos.MaxLength = 12
        Me.actxnDispVehiculos.Name = "actxnDispVehiculos"
        Me.actxnDispVehiculos.ReadOnly = True
        Me.actxnDispVehiculos.Size = New System.Drawing.Size(120, 23)
        Me.actxnDispVehiculos.TabIndex = 17
        Me.actxnDispVehiculos.Text = "0"
        Me.actxnDispVehiculos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.actxnDispVehiculos.Visible = False
        '
        'actxaRuta
        '
        Me.actxaRuta.ACActivarAyudaAuto = False
        Me.actxaRuta.ACLongitudAceptada = 0
        Me.actxaRuta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaRuta.Location = New System.Drawing.Point(230, 78)
        Me.actxaRuta.MaxLength = 32767
        Me.actxaRuta.Name = "actxaRuta"
        Me.actxaRuta.Size = New System.Drawing.Size(788, 23)
        Me.actxaRuta.TabIndex = 10
        Me.actxaRuta.Tag = "EV"
        '
        'actxaCliente
        '
        Me.actxaCliente.ACActivarAyudaAuto = False
        Me.actxaCliente.ACLongitudAceptada = 0
        Me.actxaCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaCliente.Location = New System.Drawing.Point(230, 49)
        Me.actxaCliente.MaxLength = 50
        Me.actxaCliente.Name = "actxaCliente"
        Me.actxaCliente.Size = New System.Drawing.Size(788, 23)
        Me.actxaCliente.TabIndex = 4
        Me.actxaCliente.Tag = "EVO"
        '
        'actxaCodRuta
        '
        Me.actxaCodRuta.ACActivarAyudaAuto = False
        Me.actxaCodRuta.ACLongitudAceptada = 0
        Me.actxaCodRuta.Location = New System.Drawing.Point(105, 78)
        Me.actxaCodRuta.MaxLength = 8
        Me.actxaCodRuta.Name = "actxaCodRuta"
        Me.actxaCodRuta.Size = New System.Drawing.Size(117, 23)
        Me.actxaCodRuta.TabIndex = 9
        Me.actxaCodRuta.Tag = "EV"
        '
        'actxaCliRuc
        '
        Me.actxaCliRuc.ACActivarAyudaAuto = False
        Me.actxaCliRuc.ACLongitudAceptada = 0
        Me.actxaCliRuc.Location = New System.Drawing.Point(105, 49)
        Me.actxaCliRuc.MaxLength = 32767
        Me.actxaCliRuc.Name = "actxaCliRuc"
        Me.actxaCliRuc.Size = New System.Drawing.Size(117, 23)
        Me.actxaCliRuc.TabIndex = 3
        Me.actxaCliRuc.Tag = "EVO"
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(105, 20)
        Me.txtCodigo.MaxLength = 8
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(118, 23)
        Me.txtCodigo.TabIndex = 1
        '
        'txtCarga
        '
        Me.txtCarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCarga.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarga.Location = New System.Drawing.Point(104, 403)
        Me.txtCarga.MaxLength = 600
        Me.txtCarga.Multiline = True
        Me.txtCarga.Name = "txtCarga"
        Me.txtCarga.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCarga.Size = New System.Drawing.Size(1011, 87)
        Me.txtCarga.TabIndex = 31
        Me.txtCarga.Tag = "EV"
        '
        'actxnMonto
        '
        Me.actxnMonto.ACEnteros = 9
        Me.actxnMonto.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnMonto.ACNegativo = True
        Me.actxnMonto.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnMonto.Location = New System.Drawing.Point(104, 320)
        Me.actxnMonto.MaxLength = 12
        Me.actxnMonto.Name = "actxnMonto"
        Me.actxnMonto.Size = New System.Drawing.Size(117, 23)
        Me.actxnMonto.TabIndex = 27
        Me.actxnMonto.Tag = "EV"
        Me.actxnMonto.Text = "0.00"
        Me.actxnMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(104, 178)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(117, 23)
        Me.dtpFecha.TabIndex = 15
        Me.dtpFecha.Value = New Date(2010, 7, 12, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Codigo :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(429, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Disponiblidad de Vehiculos :"
        Me.Label6.Visible = False
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(52, 82)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(37, 15)
        Me.lblRuta.TabIndex = 8
        Me.lblRuta.Text = "Ruta :"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 424)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 34)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Descripcion de la Carga :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 328)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Total :"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(44, 181)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(44, 15)
        Me.lblFecha.TabIndex = 14
        Me.lblFecha.Text = "Fecha :"
        '
        'lblNroDocumento
        '
        Me.lblNroDocumento.AutoSize = True
        Me.lblNroDocumento.Location = New System.Drawing.Point(39, 53)
        Me.lblNroDocumento.Name = "lblNroDocumento"
        Me.lblNroDocumento.Size = New System.Drawing.Size(50, 15)
        Me.lblNroDocumento.TabIndex = 2
        Me.lblNroDocumento.Text = "Cliente :"
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
        Me.tabBusqueda.Size = New System.Drawing.Size(1146, 614)
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
        Me.c1grdBusqueda.Size = New System.Drawing.Size(1146, 532)
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
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 589)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(1146, 25)
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
        Me.grpBusqueda.Controls.Add(Me.btnConsultar)
        Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
        Me.grpBusqueda.Controls.Add(Me.chkMostrarTodos)
        Me.grpBusqueda.Controls.Add(Me.rbtnCliente)
        Me.grpBusqueda.Controls.Add(Me.rbtnCodigo)
        Me.grpBusqueda.Controls.Add(Me.AcFecha)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(1146, 57)
        Me.grpBusqueda.TabIndex = 1
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(704, 9)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 44)
        Me.btnConsultar.TabIndex = 33
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.ACActivarAyudaAuto = False
        Me.txtBusqueda.ACLongitudAceptada = 0
        Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda.Location = New System.Drawing.Point(6, 22)
        Me.txtBusqueda.MaxLength = 32767
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(533, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'chkMostrarTodos
        '
        Me.chkMostrarTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMostrarTodos.AutoSize = True
        Me.chkMostrarTodos.Location = New System.Drawing.Point(603, 20)
        Me.chkMostrarTodos.Name = "chkMostrarTodos"
        Me.chkMostrarTodos.Size = New System.Drawing.Size(101, 19)
        Me.chkMostrarTodos.TabIndex = 28
        Me.chkMostrarTodos.Text = "Mostrar Todos"
        Me.chkMostrarTodos.UseVisualStyleBackColor = True
        '
        'rbtnCliente
        '
        Me.rbtnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnCliente.AutoSize = True
        Me.rbtnCliente.Location = New System.Drawing.Point(541, 9)
        Me.rbtnCliente.Name = "rbtnCliente"
        Me.rbtnCliente.Size = New System.Drawing.Size(62, 19)
        Me.rbtnCliente.TabIndex = 27
        Me.rbtnCliente.Text = "Cliente"
        Me.rbtnCliente.UseVisualStyleBackColor = True
        '
        'rbtnCodigo
        '
        Me.rbtnCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnCodigo.AutoSize = True
        Me.rbtnCodigo.Checked = True
        Me.rbtnCodigo.Location = New System.Drawing.Point(539, 30)
        Me.rbtnCodigo.Name = "rbtnCodigo"
        Me.rbtnCodigo.Size = New System.Drawing.Size(64, 19)
        Me.rbtnCodigo.TabIndex = 26
        Me.rbtnCodigo.TabStop = True
        Me.rbtnCodigo.Text = "Codigo"
        Me.rbtnCodigo.UseVisualStyleBackColor = True
        '
        'AcFecha
        '
        Me.AcFecha.ACFecha_A = New Date(2025, 4, 8, 9, 52, 23, 822)
        Me.AcFecha.ACFecha_De = New Date(2025, 4, 8, 9, 52, 23, 820)
        Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
        Me.AcFecha.ACHoyChecked = False
        Me.AcFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AcFecha.Location = New System.Drawing.Point(809, 0)
        Me.AcFecha.MaximumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.MinimumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.Name = "AcFecha"
        Me.AcFecha.Size = New System.Drawing.Size(337, 43)
        Me.AcFecha.TabIndex = 25
        Me.AcFecha.TabStop = False
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Cotizaciones de Transporte"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(1148, 30)
        Me.acpnlTitulo.TabIndex = 11
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
        Me.acTool.ACBtnImprimirEnabled = False
        Me.acTool.ACBtnImprimirVisible = False
        Me.acTool.ACBtnRehusarEnabled = False
        Me.acTool.ACBtnRehusarVisible = False
        Me.acTool.ACBtnReporteEnabled = False
        Me.acTool.ACBtnReporteVisible = False
        Me.acTool.ACBtnSalirText = "&Salir"
        Me.acTool.ACBtnVolverEnabled = False
        Me.acTool.ACBtnVolverVisible = False
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabarAnular
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnModificarDesdeFactura, Me.acbtnRecOrden})
        Me.acTool.Location = New System.Drawing.Point(0, 669)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(1148, 56)
        Me.acTool.TabIndex = 11
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'btnModificarDesdeFactura
        '
        Me.btnModificarDesdeFactura.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificarDesdeFactura.Image = CType(resources.GetObject("btnModificarDesdeFactura.Image"), System.Drawing.Image)
        Me.btnModificarDesdeFactura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificarDesdeFactura.Name = "btnModificarDesdeFactura"
        Me.btnModificarDesdeFactura.Size = New System.Drawing.Size(36, 53)
        Me.btnModificarDesdeFactura.Text = "ModificarDesdeFactura"
        '
        'acbtnRecOrden
        '
        Me.acbtnRecOrden.AutoSize = False
        Me.acbtnRecOrden.Image = Global.ACPTransportes.My.Resources.Resources.ACForkliftBoxes_32x32
        Me.acbtnRecOrden.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.acbtnRecOrden.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.acbtnRecOrden.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.acbtnRecOrden.Name = "tsbBoton"
        Me.acbtnRecOrden.Size = New System.Drawing.Size(133, 53)
        Me.acbtnRecOrden.Text = "Generar Flete y Viaje"
        Me.acbtnRecOrden.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.acbtnRecOrden.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.acbtnRecOrden.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FCotizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1148, 725)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Controls.Add(Me.acTool)
        Me.Name = "FCotizaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cotizaciones de Transporte"
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
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
        Me.acTool.ResumeLayout(False)
        Me.acTool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
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
   Friend WithEvents actxaCliente As ACControles.ACTextBoxAyuda
   Friend WithEvents lblNroDocumento As System.Windows.Forms.Label
   Friend WithEvents lblFecha As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents actxnMonto As ACControles.ACTextBoxNumerico
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtCarga As System.Windows.Forms.TextBox
   Friend WithEvents actxaRuta As ACControles.ACTextBoxAyuda
   Friend WithEvents lblRuta As System.Windows.Forms.Label
   Friend WithEvents actxnDispVehiculos As ACControles.ACTextBoxNumerico
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents rbtnCliente As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnCodigo As System.Windows.Forms.RadioButton
   Friend WithEvents actxaCliRuc As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaCodRuta As ACControles.ACTextBoxAyuda
   Friend WithEvents chkMostrarTodos As System.Windows.Forms.CheckBox
   Friend WithEvents btnConsultar As System.Windows.Forms.Button
   Friend WithEvents lblMoneda As System.Windows.Forms.Label
   Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents btnNuevo As System.Windows.Forms.Button
   Friend WithEvents btnEditar As System.Windows.Forms.Button
   Friend WithEvents btnClean As System.Windows.Forms.Button
   Friend WithEvents btnRClean As System.Windows.Forms.Button
   Friend WithEvents btnREditar As System.Windows.Forms.Button
   Friend WithEvents btnRNuevo As System.Windows.Forms.Button
   Friend WithEvents actxnMontoXTm As ACControles.ACTextBoxNumerico
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents actxnPeso As ACControles.ACTextBoxNumerico
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents chkOrdenTransporte As System.Windows.Forms.CheckBox
   Friend WithEvents acbtnRecOrden As ACControles.ACToolStripButton
   Friend WithEvents actxnIGV As ACControles.ACTextBoxNumerico
   Friend WithEvents chkIGV As System.Windows.Forms.CheckBox
   Friend WithEvents cmbDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents actxnTotalValorReferencial As ACControles.ACTextBoxNumerico
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents actxnValorReferencialXTm As ACControles.ACTextBoxNumerico
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents actxtUbigoDestino As ACControles.ACTextBoxAyuda
    Friend WithEvents actxtUbigoOrigen As ACControles.ACTextBoxAyuda
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbDireccionOrigen As ComboBox
    Friend WithEvents cmbDireccionDestino As ComboBox
    Friend WithEvents actextBusqDescripcion As ACControles.ACTextBoxAyuda
    Friend WithEvents Label15 As Label
    Friend WithEvents btnModificarDesdeFactura As ToolStripButton
End Class
