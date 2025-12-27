<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FFlete
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FFlete))
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.actxtdireccion_destino = New System.Windows.Forms.TextBox()
        Me.actxtdireccion_origen = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.actxnTotalValorReferencial = New ACControles.ACTextBoxNumerico()
        Me.chkFleteLocal = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.actxnMonto = New ACControles.ACTextBoxNumerico()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUbiDestino = New System.Windows.Forms.TextBox()
        Me.txtUbiOrigen = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCodRuta = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtCodCliente = New System.Windows.Forms.TextBox()
        Me.dtpHorProgramada = New System.Windows.Forms.DateTimePicker()
        Me.dtpHorSalida = New System.Windows.Forms.DateTimePicker()
        Me.dtpHorLlegada = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecProgramada = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecSalida = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecLlegada = New System.Windows.Forms.DateTimePicker()
        Me.grpVehiculo = New System.Windows.Forms.GroupBox()
        Me.txtvehic_mtc = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSigla = New System.Windows.Forms.TextBox()
        Me.txtConductor = New System.Windows.Forms.TextBox()
        Me.txtCodConductor = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.actxaPlaca = New ACControles.ACTextBoxAyuda()
        Me.actxaCodVehiculo = New ACControles.ACTextBoxAyuda()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtIdConductor = New ACControles.ACTextBoxNumerico()
        Me.txtViaje = New ACControles.ACTextBoxNumerico()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.eprError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
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
        Me.pnlDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpVehiculo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.eprError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.tabBusqueda.SuspendLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavBusqueda.SuspendLayout()
        Me.grpBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDatos
        '
        Me.pnlDatos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlDatos.Controls.Add(Me.actxtdireccion_destino)
        Me.pnlDatos.Controls.Add(Me.actxtdireccion_origen)
        Me.pnlDatos.Controls.Add(Me.Label18)
        Me.pnlDatos.Controls.Add(Me.Label19)
        Me.pnlDatos.Controls.Add(Me.Label16)
        Me.pnlDatos.Controls.Add(Me.actxnTotalValorReferencial)
        Me.pnlDatos.Controls.Add(Me.chkFleteLocal)
        Me.pnlDatos.Controls.Add(Me.Label15)
        Me.pnlDatos.Controls.Add(Me.actxnMonto)
        Me.pnlDatos.Controls.Add(Me.cmbTipoMoneda)
        Me.pnlDatos.Controls.Add(Me.Label14)
        Me.pnlDatos.Controls.Add(Me.GroupBox1)
        Me.pnlDatos.Controls.Add(Me.txtCliente)
        Me.pnlDatos.Controls.Add(Me.txtCodCliente)
        Me.pnlDatos.Controls.Add(Me.dtpHorProgramada)
        Me.pnlDatos.Controls.Add(Me.dtpHorSalida)
        Me.pnlDatos.Controls.Add(Me.dtpHorLlegada)
        Me.pnlDatos.Controls.Add(Me.dtpFecProgramada)
        Me.pnlDatos.Controls.Add(Me.dtpFecSalida)
        Me.pnlDatos.Controls.Add(Me.dtpFecLlegada)
        Me.pnlDatos.Controls.Add(Me.grpVehiculo)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.GroupBox2)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(788, 503)
        Me.pnlDatos.TabIndex = 1
        '
        'actxtdireccion_destino
        '
        Me.actxtdireccion_destino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxtdireccion_destino.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxtdireccion_destino.Location = New System.Drawing.Point(131, 133)
        Me.actxtdireccion_destino.Name = "actxtdireccion_destino"
        Me.actxtdireccion_destino.ReadOnly = True
        Me.actxtdireccion_destino.Size = New System.Drawing.Size(326, 26)
        Me.actxtdireccion_destino.TabIndex = 69
        '
        'actxtdireccion_origen
        '
        Me.actxtdireccion_origen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxtdireccion_origen.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxtdireccion_origen.Location = New System.Drawing.Point(132, 102)
        Me.actxtdireccion_origen.Name = "actxtdireccion_origen"
        Me.actxtdireccion_origen.ReadOnly = True
        Me.actxtdireccion_origen.Size = New System.Drawing.Size(325, 26)
        Me.actxtdireccion_origen.TabIndex = 68
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(43, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 15)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Punto Destino"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(47, 107)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 15)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Punto Origen"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(418, 311)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 15)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Valor Referencial :"
        '
        'actxnTotalValorReferencial
        '
        Me.actxnTotalValorReferencial.ACEnteros = 9
        Me.actxnTotalValorReferencial.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTotalValorReferencial.ACNegativo = True
        Me.actxnTotalValorReferencial.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTotalValorReferencial.Location = New System.Drawing.Point(524, 309)
        Me.actxnTotalValorReferencial.MaxLength = 12
        Me.actxnTotalValorReferencial.Name = "actxnTotalValorReferencial"
        Me.actxnTotalValorReferencial.ReadOnly = True
        Me.actxnTotalValorReferencial.Size = New System.Drawing.Size(96, 23)
        Me.actxnTotalValorReferencial.TabIndex = 22
        Me.actxnTotalValorReferencial.Tag = "EV"
        Me.actxnTotalValorReferencial.Text = "0.00"
        Me.actxnTotalValorReferencial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkFleteLocal
        '
        Me.chkFleteLocal.AutoSize = True
        Me.chkFleteLocal.Location = New System.Drawing.Point(241, 309)
        Me.chkFleteLocal.Name = "chkFleteLocal"
        Me.chkFleteLocal.Size = New System.Drawing.Size(82, 19)
        Me.chkFleteLocal.TabIndex = 19
        Me.chkFleteLocal.Text = "Flete Local"
        Me.chkFleteLocal.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(88, 311)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 15)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Flete :"
        '
        'actxnMonto
        '
        Me.actxnMonto.ACEnteros = 9
        Me.actxnMonto.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnMonto.ACNegativo = True
        Me.actxnMonto.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnMonto.Location = New System.Drawing.Point(132, 307)
        Me.actxnMonto.MaxLength = 12
        Me.actxnMonto.Name = "actxnMonto"
        Me.actxnMonto.ReadOnly = True
        Me.actxnMonto.Size = New System.Drawing.Size(96, 23)
        Me.actxnMonto.TabIndex = 18
        Me.actxnMonto.Tag = "EV"
        Me.actxnMonto.Text = "0.00"
        Me.actxnMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(132, 279)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(319, 23)
        Me.cmbTipoMoneda.TabIndex = 16
        Me.cmbTipoMoneda.Tag = "ECO"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(69, 282)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 15)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Moneda :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtUbiDestino)
        Me.GroupBox1.Controls.Add(Me.txtUbiOrigen)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtDestino)
        Me.GroupBox1.Controls.Add(Me.txtOrigen)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtRuta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCodRuta)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(788, 99)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ruta del Flete"
        '
        'txtUbiDestino
        '
        Me.txtUbiDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUbiDestino.Location = New System.Drawing.Point(132, 73)
        Me.txtUbiDestino.Name = "txtUbiDestino"
        Me.txtUbiDestino.ReadOnly = True
        Me.txtUbiDestino.Size = New System.Drawing.Size(63, 23)
        Me.txtUbiDestino.TabIndex = 7
        '
        'txtUbiOrigen
        '
        Me.txtUbiOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUbiOrigen.Location = New System.Drawing.Point(132, 44)
        Me.txtUbiOrigen.Name = "txtUbiOrigen"
        Me.txtUbiOrigen.ReadOnly = True
        Me.txtUbiOrigen.Size = New System.Drawing.Size(63, 23)
        Me.txtUbiOrigen.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(81, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 15)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Origen :"
        '
        'txtDestino
        '
        Me.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDestino.Location = New System.Drawing.Point(202, 73)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.ReadOnly = True
        Me.txtDestino.Size = New System.Drawing.Size(250, 23)
        Me.txtDestino.TabIndex = 8
        '
        'txtOrigen
        '
        Me.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrigen.Location = New System.Drawing.Point(202, 44)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(250, 23)
        Me.txtOrigen.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(77, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 15)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Destino :"
        '
        'txtRuta
        '
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Location = New System.Drawing.Point(202, 15)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(420, 23)
        Me.txtRuta.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(93, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ruta :"
        '
        'txtCodRuta
        '
        Me.txtCodRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodRuta.Location = New System.Drawing.Point(133, 15)
        Me.txtCodRuta.Name = "txtCodRuta"
        Me.txtCodRuta.ReadOnly = True
        Me.txtCodRuta.Size = New System.Drawing.Size(63, 23)
        Me.txtCodRuta.TabIndex = 1
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.txtCliente.Location = New System.Drawing.Point(241, 190)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(380, 26)
        Me.txtCliente.TabIndex = 3
        '
        'txtCodCliente
        '
        Me.txtCodCliente.Location = New System.Drawing.Point(132, 192)
        Me.txtCodCliente.Name = "txtCodCliente"
        Me.txtCodCliente.ReadOnly = True
        Me.txtCodCliente.Size = New System.Drawing.Size(97, 23)
        Me.txtCodCliente.TabIndex = 2
        '
        'dtpHorProgramada
        '
        Me.dtpHorProgramada.CustomFormat = "hh:mm tt"
        Me.dtpHorProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHorProgramada.Location = New System.Drawing.Point(245, 221)
        Me.dtpHorProgramada.Name = "dtpHorProgramada"
        Me.dtpHorProgramada.ShowUpDown = True
        Me.dtpHorProgramada.Size = New System.Drawing.Size(81, 23)
        Me.dtpHorProgramada.TabIndex = 8
        '
        'dtpHorSalida
        '
        Me.dtpHorSalida.CustomFormat = "hh:mm tt"
        Me.dtpHorSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHorSalida.Location = New System.Drawing.Point(245, 250)
        Me.dtpHorSalida.Name = "dtpHorSalida"
        Me.dtpHorSalida.ShowUpDown = True
        Me.dtpHorSalida.Size = New System.Drawing.Size(81, 23)
        Me.dtpHorSalida.TabIndex = 11
        '
        'dtpHorLlegada
        '
        Me.dtpHorLlegada.CustomFormat = "hh:mm tt"
        Me.dtpHorLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHorLlegada.Location = New System.Drawing.Point(539, 277)
        Me.dtpHorLlegada.Name = "dtpHorLlegada"
        Me.dtpHorLlegada.ShowUpDown = True
        Me.dtpHorLlegada.Size = New System.Drawing.Size(81, 23)
        Me.dtpHorLlegada.TabIndex = 14
        '
        'dtpFecProgramada
        '
        Me.dtpFecProgramada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecProgramada.Location = New System.Drawing.Point(132, 221)
        Me.dtpFecProgramada.Name = "dtpFecProgramada"
        Me.dtpFecProgramada.Size = New System.Drawing.Size(96, 23)
        Me.dtpFecProgramada.TabIndex = 7
        '
        'dtpFecSalida
        '
        Me.dtpFecSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecSalida.Location = New System.Drawing.Point(132, 250)
        Me.dtpFecSalida.Name = "dtpFecSalida"
        Me.dtpFecSalida.Size = New System.Drawing.Size(96, 23)
        Me.dtpFecSalida.TabIndex = 10
        '
        'dtpFecLlegada
        '
        Me.dtpFecLlegada.Checked = False
        Me.dtpFecLlegada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecLlegada.Location = New System.Drawing.Point(427, 250)
        Me.dtpFecLlegada.Name = "dtpFecLlegada"
        Me.dtpFecLlegada.ShowCheckBox = True
        Me.dtpFecLlegada.Size = New System.Drawing.Size(107, 23)
        Me.dtpFecLlegada.TabIndex = 13
        '
        'grpVehiculo
        '
        Me.grpVehiculo.BackColor = System.Drawing.Color.White
        Me.grpVehiculo.Controls.Add(Me.txtvehic_mtc)
        Me.grpVehiculo.Controls.Add(Me.Label17)
        Me.grpVehiculo.Controls.Add(Me.txtSigla)
        Me.grpVehiculo.Controls.Add(Me.txtConductor)
        Me.grpVehiculo.Controls.Add(Me.txtCodConductor)
        Me.grpVehiculo.Controls.Add(Me.Label13)
        Me.grpVehiculo.Controls.Add(Me.actxaPlaca)
        Me.grpVehiculo.Controls.Add(Me.actxaCodVehiculo)
        Me.grpVehiculo.Controls.Add(Me.Label10)
        Me.grpVehiculo.Controls.Add(Me.Label9)
        Me.grpVehiculo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpVehiculo.Location = New System.Drawing.Point(0, 363)
        Me.grpVehiculo.Name = "grpVehiculo"
        Me.grpVehiculo.Size = New System.Drawing.Size(788, 92)
        Me.grpVehiculo.TabIndex = 20
        Me.grpVehiculo.TabStop = False
        Me.grpVehiculo.Text = "Vehiculo"
        '
        'txtvehic_mtc
        '
        Me.txtvehic_mtc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvehic_mtc.Location = New System.Drawing.Point(133, 68)
        Me.txtvehic_mtc.Name = "txtvehic_mtc"
        Me.txtvehic_mtc.ReadOnly = True
        Me.txtvehic_mtc.Size = New System.Drawing.Size(210, 23)
        Me.txtvehic_mtc.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(89, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 15)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "MTC :"
        '
        'txtSigla
        '
        Me.txtSigla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSigla.Location = New System.Drawing.Point(556, 41)
        Me.txtSigla.Name = "txtSigla"
        Me.txtSigla.ReadOnly = True
        Me.txtSigla.Size = New System.Drawing.Size(66, 23)
        Me.txtSigla.TabIndex = 7
        '
        'txtConductor
        '
        Me.txtConductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConductor.Location = New System.Drawing.Point(235, 41)
        Me.txtConductor.Name = "txtConductor"
        Me.txtConductor.ReadOnly = True
        Me.txtConductor.Size = New System.Drawing.Size(315, 23)
        Me.txtConductor.TabIndex = 6
        '
        'txtCodConductor
        '
        Me.txtCodConductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodConductor.Location = New System.Drawing.Point(132, 41)
        Me.txtCodConductor.Name = "txtCodConductor"
        Me.txtCodConductor.ReadOnly = True
        Me.txtCodConductor.Size = New System.Drawing.Size(97, 23)
        Me.txtCodConductor.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(58, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 15)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Conductor :"
        '
        'actxaPlaca
        '
        Me.actxaPlaca.ACActivarAyudaAuto = False
        Me.actxaPlaca.ACLongitudAceptada = 0
        Me.actxaPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaPlaca.Location = New System.Drawing.Point(285, 12)
        Me.actxaPlaca.MaxLength = 32767
        Me.actxaPlaca.Name = "actxaPlaca"
        Me.actxaPlaca.Size = New System.Drawing.Size(97, 23)
        Me.actxaPlaca.TabIndex = 3
        Me.actxaPlaca.Tag = "EVO"
        '
        'actxaCodVehiculo
        '
        Me.actxaCodVehiculo.ACActivarAyudaAuto = False
        Me.actxaCodVehiculo.ACLongitudAceptada = 0
        Me.actxaCodVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaCodVehiculo.Location = New System.Drawing.Point(132, 12)
        Me.actxaCodVehiculo.MaxLength = 32767
        Me.actxaCodVehiculo.Name = "actxaCodVehiculo"
        Me.actxaCodVehiculo.Size = New System.Drawing.Size(97, 23)
        Me.actxaCodVehiculo.TabIndex = 1
        Me.actxaCodVehiculo.Tag = "EVO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(239, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 15)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Placa :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(75, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Código :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 15)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Fecha Programada :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Fecha Salida :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(333, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Fecha LLegada :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cliente :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Controls.Add(Me.txtIdConductor)
        Me.GroupBox2.Controls.Add(Me.txtViaje)
        Me.GroupBox2.Controls.Add(Me.txtGlosa)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(0, 455)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(788, 48)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Viaje Generado"
        '
        'txtIdConductor
        '
        Me.txtIdConductor.ACEnteros = 9
        Me.txtIdConductor.ACFormato = "########0"
        Me.txtIdConductor.ACNegativo = True
        Me.txtIdConductor.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIdConductor.Location = New System.Drawing.Point(226, 18)
        Me.txtIdConductor.MaxLength = 12
        Me.txtIdConductor.Name = "txtIdConductor"
        Me.txtIdConductor.Size = New System.Drawing.Size(50, 23)
        Me.txtIdConductor.TabIndex = 18
        Me.txtIdConductor.Tag = "EV"
        Me.txtIdConductor.Text = "0"
        Me.txtIdConductor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtViaje
        '
        Me.txtViaje.ACEnteros = 9
        Me.txtViaje.ACFormato = "########0"
        Me.txtViaje.ACNegativo = True
        Me.txtViaje.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtViaje.Location = New System.Drawing.Point(58, 18)
        Me.txtViaje.MaxLength = 12
        Me.txtViaje.Name = "txtViaje"
        Me.txtViaje.Size = New System.Drawing.Size(50, 23)
        Me.txtViaje.TabIndex = 17
        Me.txtViaje.Tag = "EV"
        Me.txtViaje.Text = "0"
        Me.txtViaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGlosa
        '
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.Location = New System.Drawing.Point(330, 18)
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ReadOnly = True
        Me.txtGlosa.Size = New System.Drawing.Size(292, 23)
        Me.txtGlosa.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(279, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Glosa :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Viaje :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(114, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Viaje x Conductor :"
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Asignación Flete"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(790, 30)
        Me.acpnlTitulo.TabIndex = 0
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
        Me.acTool.ACBtnNuevoEnabled = False
        Me.acTool.ACBtnNuevoVisible = False
        Me.acTool.ACBtnRehusarEnabled = False
        Me.acTool.ACBtnRehusarVisible = False
        Me.acTool.ACBtnReporteEnabled = False
        Me.acTool.ACBtnReporteVisible = False
        Me.acTool.ACBtnSalirText = "&Salir"
        Me.acTool.ACBtnVolverEnabled = False
        Me.acTool.ACBtnVolverVisible = False
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolGrabar
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.acTool.Location = New System.Drawing.Point(0, 558)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(790, 56)
        Me.acTool.TabIndex = 2
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'eprError
        '
        Me.eprError.ContainerControl = Me
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
        Me.tabMantenimiento.Size = New System.Drawing.Size(790, 528)
        Me.tabMantenimiento.TabIndex = 28
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
        Me.tabDatos.Size = New System.Drawing.Size(788, 503)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
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
        Me.tabBusqueda.Size = New System.Drawing.Size(788, 503)
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
        Me.c1grdBusqueda.Size = New System.Drawing.Size(788, 427)
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
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 478)
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
        Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(788, 51)
        Me.grpBusqueda.TabIndex = 1
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
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
        Me.txtBusqueda.Size = New System.Drawing.Size(760, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'FFlete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 614)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acTool)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FFlete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación Flete"
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpVehiculo.ResumeLayout(False)
        Me.grpVehiculo.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.eprError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
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
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFecProgramada As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFecLlegada As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
    Friend WithEvents dtpHorProgramada As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHorSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHorLlegada As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCodRuta As System.Windows.Forms.TextBox
    Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
    Friend WithEvents grpVehiculo As System.Windows.Forms.GroupBox
    Friend WithEvents actxaPlaca As ACControles.ACTextBoxAyuda
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents actxaCodVehiculo As ACControles.ACTextBoxAyuda
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents eprError As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
    Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
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
    Friend WithEvents txtConductor As System.Windows.Forms.TextBox
    Friend WithEvents txtCodConductor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSigla As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtUbiDestino As System.Windows.Forms.TextBox
    Friend WithEvents txtUbiOrigen As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents actxnMonto As ACControles.ACTextBoxNumerico
    Friend WithEvents txtIdConductor As ACControles.ACTextBoxNumerico
    Friend WithEvents txtViaje As ACControles.ACTextBoxNumerico
    Friend WithEvents chkFleteLocal As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents actxnTotalValorReferencial As ACControles.ACTextBoxNumerico
    Friend WithEvents txtvehic_mtc As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents actxtdireccion_destino As TextBox
    Friend WithEvents actxtdireccion_origen As TextBox
End Class
