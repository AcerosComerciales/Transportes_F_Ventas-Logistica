<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MVehiculos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MVehiculos))
      Me.acpnlVehiculos = New ACControles.ACPanelCaption()
      Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
      Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.pnlDatos = New System.Windows.Forms.Panel()
      Me.cmbPuntoVenta = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.chkAnulado = New System.Windows.Forms.CheckBox()
      Me.chkVehiculos = New System.Windows.Forms.CheckBox()
      Me.grpTransportista = New System.Windows.Forms.GroupBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.actxaDescTransportista = New ACControles.ACTextBoxAyuda()
      Me.actxaCodTransportista = New ACControles.ACTextBoxAyuda()
      Me.actxnKilomInicial = New ACControles.ACTextBoxNumerico()
      Me.actxnKilomActual = New ACControles.ACTextBoxNumerico()
      Me.lblKMI = New System.Windows.Forms.Label()
      Me.lblKMA = New System.Windows.Forms.Label()
      Me.txtVehiCombustible = New System.Windows.Forms.TextBox()
      Me.txtCertificado = New System.Windows.Forms.TextBox()
      Me.txtNroEjes = New System.Windows.Forms.TextBox()
      Me.txtNroNeumaticos = New System.Windows.Forms.TextBox()
      Me.txtPlaca = New System.Windows.Forms.TextBox()
      Me.dtpFecAdquisicion = New System.Windows.Forms.DateTimePicker()
      Me.txtModelo = New System.Windows.Forms.TextBox()
      Me.cmbCombustible = New System.Windows.Forms.ComboBox()
      Me.cmbMarca = New System.Windows.Forms.ComboBox()
      Me.cmbTipVehiculo = New System.Windows.Forms.ComboBox()
      Me.txtVehiculoID = New System.Windows.Forms.TextBox()
      Me.lblVehCombustible = New System.Windows.Forms.Label()
      Me.lblCertificado = New System.Windows.Forms.Label()
      Me.lblKmInicial = New System.Windows.Forms.Label()
      Me.lblKmActual = New System.Windows.Forms.Label()
      Me.lblNroEjes = New System.Windows.Forms.Label()
      Me.lblNroNeumaticos = New System.Windows.Forms.Label()
      Me.lblPlaca = New System.Windows.Forms.Label()
      Me.lblFecAdquisicion = New System.Windows.Forms.Label()
      Me.lblModelo = New System.Windows.Forms.Label()
      Me.lblTipCombustible = New System.Windows.Forms.Label()
      Me.lblMarca = New System.Windows.Forms.Label()
      Me.lblCodTipVehiculo = New System.Windows.Forms.Label()
      Me.lblVehiculoID = New System.Windows.Forms.Label()
      Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.c1grdBusqueda = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.bnavBusqueda = New System.Windows.Forms.BindingNavigator(Me.components)
      Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
      Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
      Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.grpBusqueda = New System.Windows.Forms.GroupBox()
      Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
      Me.rbtnPlaca = New System.Windows.Forms.RadioButton()
      Me.rbtnCodigo = New System.Windows.Forms.RadioButton()
      Me.eprError = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.AcTool = New ACControles.ACToolBarMantVertical()
      Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
      Me.tsbtnEnviarExcel = New System.Windows.Forms.ToolStripButton()
      Me.btnConsultar = New System.Windows.Forms.Button()
      Me.actxnCargaMax = New ACControles.ACTextBoxNumerico()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tabMantenimiento.SuspendLayout()
      Me.tabDatos.SuspendLayout()
      Me.pnlDatos.SuspendLayout()
      Me.grpTransportista.SuspendLayout()
      Me.tabBusqueda.SuspendLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavBusqueda.SuspendLayout()
      Me.grpBusqueda.SuspendLayout()
      CType(Me.eprError, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'acpnlVehiculos
      '
      Me.acpnlVehiculos.ACCaption = "Mantenimiento de Vehiculos"
      Me.acpnlVehiculos.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlVehiculos.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlVehiculos.Location = New System.Drawing.Point(0, 0)
      Me.acpnlVehiculos.Name = "acpnlVehiculos"
      Me.acpnlVehiculos.Size = New System.Drawing.Size(800, 30)
      Me.acpnlVehiculos.TabIndex = 9
      '
      'tabMantenimiento
      '
      Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
      Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tabMantenimiento.Location = New System.Drawing.Point(100, 30)
      Me.tabMantenimiento.MediaPlayerDockSides = False
      Me.tabMantenimiento.Name = "tabMantenimiento"
      Me.tabMantenimiento.OfficeDockSides = False
      Me.tabMantenimiento.SelectedIndex = 0
      Me.tabMantenimiento.ShowDropSelect = False
      Me.tabMantenimiento.Size = New System.Drawing.Size(700, 350)
      Me.tabMantenimiento.TabIndex = 11
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
      Me.tabDatos.Size = New System.Drawing.Size(698, 325)
      Me.tabDatos.TabIndex = 4
      Me.tabDatos.Title = "Datos"
      Me.tabDatos.ToolTip = "Datos"
      '
      'pnlDatos
      '
      Me.pnlDatos.Controls.Add(Me.actxnCargaMax)
      Me.pnlDatos.Controls.Add(Me.Label2)
      Me.pnlDatos.Controls.Add(Me.cmbPuntoVenta)
      Me.pnlDatos.Controls.Add(Me.Label1)
      Me.pnlDatos.Controls.Add(Me.chkAnulado)
      Me.pnlDatos.Controls.Add(Me.chkVehiculos)
      Me.pnlDatos.Controls.Add(Me.grpTransportista)
      Me.pnlDatos.Controls.Add(Me.actxnKilomInicial)
      Me.pnlDatos.Controls.Add(Me.actxnKilomActual)
      Me.pnlDatos.Controls.Add(Me.lblKMI)
      Me.pnlDatos.Controls.Add(Me.lblKMA)
      Me.pnlDatos.Controls.Add(Me.txtVehiCombustible)
      Me.pnlDatos.Controls.Add(Me.txtCertificado)
      Me.pnlDatos.Controls.Add(Me.txtNroEjes)
      Me.pnlDatos.Controls.Add(Me.txtNroNeumaticos)
      Me.pnlDatos.Controls.Add(Me.txtPlaca)
      Me.pnlDatos.Controls.Add(Me.dtpFecAdquisicion)
      Me.pnlDatos.Controls.Add(Me.txtModelo)
      Me.pnlDatos.Controls.Add(Me.cmbCombustible)
      Me.pnlDatos.Controls.Add(Me.cmbMarca)
      Me.pnlDatos.Controls.Add(Me.cmbTipVehiculo)
      Me.pnlDatos.Controls.Add(Me.txtVehiculoID)
      Me.pnlDatos.Controls.Add(Me.lblVehCombustible)
      Me.pnlDatos.Controls.Add(Me.lblCertificado)
      Me.pnlDatos.Controls.Add(Me.lblKmInicial)
      Me.pnlDatos.Controls.Add(Me.lblKmActual)
      Me.pnlDatos.Controls.Add(Me.lblNroEjes)
      Me.pnlDatos.Controls.Add(Me.lblNroNeumaticos)
      Me.pnlDatos.Controls.Add(Me.lblPlaca)
      Me.pnlDatos.Controls.Add(Me.lblFecAdquisicion)
      Me.pnlDatos.Controls.Add(Me.lblModelo)
      Me.pnlDatos.Controls.Add(Me.lblTipCombustible)
      Me.pnlDatos.Controls.Add(Me.lblMarca)
      Me.pnlDatos.Controls.Add(Me.lblCodTipVehiculo)
      Me.pnlDatos.Controls.Add(Me.lblVehiculoID)
      Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
      Me.pnlDatos.Name = "pnlDatos"
      Me.pnlDatos.Size = New System.Drawing.Size(698, 325)
      Me.pnlDatos.TabIndex = 0
      '
      'cmbPuntoVenta
      '
      Me.cmbPuntoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPuntoVenta.FormattingEnabled = True
      Me.cmbPuntoVenta.Location = New System.Drawing.Point(377, 15)
      Me.cmbPuntoVenta.Name = "cmbPuntoVenta"
      Me.cmbPuntoVenta.Size = New System.Drawing.Size(219, 23)
      Me.cmbPuntoVenta.TabIndex = 3
      Me.cmbPuntoVenta.Tag = "ECO"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(278, 19)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(94, 15)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Punto de Venta :"
      '
      'chkAnulado
      '
      Me.chkAnulado.AutoSize = True
      Me.chkAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkAnulado.Location = New System.Drawing.Point(611, 17)
      Me.chkAnulado.Name = "chkAnulado"
      Me.chkAnulado.Size = New System.Drawing.Size(71, 19)
      Me.chkAnulado.TabIndex = 4
      Me.chkAnulado.Text = "Anulado"
      Me.chkAnulado.UseVisualStyleBackColor = True
      '
      'chkVehiculos
      '
      Me.chkVehiculos.AutoSize = True
      Me.chkVehiculos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkVehiculos.Location = New System.Drawing.Point(372, 207)
      Me.chkVehiculos.Name = "chkVehiculos"
      Me.chkVehiculos.Size = New System.Drawing.Size(108, 19)
      Me.chkVehiculos.TabIndex = 31
      Me.chkVehiculos.Text = "Genera Viajes :  "
      Me.chkVehiculos.UseVisualStyleBackColor = True
      '
      'grpTransportista
      '
      Me.grpTransportista.Controls.Add(Me.Label9)
      Me.grpTransportista.Controls.Add(Me.Label5)
      Me.grpTransportista.Controls.Add(Me.actxaDescTransportista)
      Me.grpTransportista.Controls.Add(Me.actxaCodTransportista)
      Me.grpTransportista.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.grpTransportista.Location = New System.Drawing.Point(0, 265)
      Me.grpTransportista.Name = "grpTransportista"
      Me.grpTransportista.Size = New System.Drawing.Size(698, 60)
      Me.grpTransportista.TabIndex = 32
      Me.grpTransportista.TabStop = False
      Me.grpTransportista.Text = "Transportista"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(197, 27)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(79, 15)
      Me.Label9.TabIndex = 2
      Me.Label9.Text = "Razon Social :"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(13, 27)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(52, 15)
      Me.Label5.TabIndex = 0
      Me.Label5.Text = "Codigo :"
      '
      'actxaDescTransportista
      '
      Me.actxaDescTransportista.ACActivarAyudaAuto = False
      Me.actxaDescTransportista.ACLongitudAceptada = 0
      Me.actxaDescTransportista.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaDescTransportista.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxaDescTransportista.Location = New System.Drawing.Point(282, 23)
      Me.actxaDescTransportista.MaxLength = 100
      Me.actxaDescTransportista.Name = "actxaDescTransportista"
      Me.actxaDescTransportista.Size = New System.Drawing.Size(405, 23)
      Me.actxaDescTransportista.TabIndex = 3
      Me.actxaDescTransportista.Tag = "EV"
      '
      'actxaCodTransportista
      '
      Me.actxaCodTransportista.ACActivarAyudaAuto = False
      Me.actxaCodTransportista.ACLongitudAceptada = 0
      Me.actxaCodTransportista.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaCodTransportista.Location = New System.Drawing.Point(71, 23)
      Me.actxaCodTransportista.MaxLength = 14
      Me.actxaCodTransportista.Name = "actxaCodTransportista"
      Me.actxaCodTransportista.Size = New System.Drawing.Size(118, 23)
      Me.actxaCodTransportista.TabIndex = 1
      Me.actxaCodTransportista.Tag = "EV"
      '
      'actxnKilomInicial
      '
      Me.actxnKilomInicial.ACEnteros = 9
      Me.actxnKilomInicial.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnKilomInicial.ACFormato = "########0.00"
      Me.actxnKilomInicial.ACNegativo = True
      Me.actxnKilomInicial.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
      Me.actxnKilomInicial.Location = New System.Drawing.Point(148, 177)
      Me.actxnKilomInicial.MaxLength = 12
      Me.actxnKilomInicial.Name = "actxnKilomInicial"
      Me.actxnKilomInicial.Size = New System.Drawing.Size(124, 23)
      Me.actxnKilomInicial.TabIndex = 24
      Me.actxnKilomInicial.Tag = "EV"
      Me.actxnKilomInicial.Text = "0.00"
      Me.actxnKilomInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'actxnKilomActual
      '
      Me.actxnKilomActual.ACEnteros = 9
      Me.actxnKilomActual.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnKilomActual.ACFormato = "########0.00"
      Me.actxnKilomActual.ACNegativo = True
      Me.actxnKilomActual.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
      Me.actxnKilomActual.Location = New System.Drawing.Point(463, 177)
      Me.actxnKilomActual.MaxLength = 12
      Me.actxnKilomActual.Name = "actxnKilomActual"
      Me.actxnKilomActual.Size = New System.Drawing.Size(124, 23)
      Me.actxnKilomActual.TabIndex = 27
      Me.actxnKilomActual.Tag = "EV"
      Me.actxnKilomActual.Text = "0.00"
      Me.actxnKilomActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblKMI
      '
      Me.lblKMI.AutoSize = True
      Me.lblKMI.Location = New System.Drawing.Point(593, 181)
      Me.lblKMI.Name = "lblKMI"
      Me.lblKMI.Size = New System.Drawing.Size(25, 15)
      Me.lblKMI.TabIndex = 28
      Me.lblKMI.Text = "KM"
      '
      'lblKMA
      '
      Me.lblKMA.AutoSize = True
      Me.lblKMA.Location = New System.Drawing.Point(277, 181)
      Me.lblKMA.Name = "lblKMA"
      Me.lblKMA.Size = New System.Drawing.Size(25, 15)
      Me.lblKMA.TabIndex = 25
      Me.lblKMA.Text = "KM"
      '
      'txtVehiCombustible
      '
      Me.txtVehiCombustible.Location = New System.Drawing.Point(148, 123)
      Me.txtVehiCombustible.Name = "txtVehiCombustible"
      Me.txtVehiCombustible.Size = New System.Drawing.Size(124, 23)
      Me.txtVehiCombustible.TabIndex = 16
      Me.txtVehiCombustible.Tag = "EV"
      '
      'txtCertificado
      '
      Me.txtCertificado.Location = New System.Drawing.Point(148, 205)
      Me.txtCertificado.Name = "txtCertificado"
      Me.txtCertificado.Size = New System.Drawing.Size(124, 23)
      Me.txtCertificado.TabIndex = 30
      Me.txtCertificado.Tag = "EVO"
      '
      'txtNroEjes
      '
      Me.txtNroEjes.Location = New System.Drawing.Point(148, 150)
      Me.txtNroEjes.Name = "txtNroEjes"
      Me.txtNroEjes.Size = New System.Drawing.Size(124, 23)
      Me.txtNroEjes.TabIndex = 20
      Me.txtNroEjes.Tag = "EV"
      '
      'txtNroNeumaticos
      '
      Me.txtNroNeumaticos.Location = New System.Drawing.Point(463, 150)
      Me.txtNroNeumaticos.Name = "txtNroNeumaticos"
      Me.txtNroNeumaticos.Size = New System.Drawing.Size(124, 23)
      Me.txtNroNeumaticos.TabIndex = 22
      Me.txtNroNeumaticos.Tag = "EV"
      '
      'txtPlaca
      '
      Me.txtPlaca.Location = New System.Drawing.Point(148, 42)
      Me.txtPlaca.Name = "txtPlaca"
      Me.txtPlaca.Size = New System.Drawing.Size(219, 23)
      Me.txtPlaca.TabIndex = 6
      Me.txtPlaca.Tag = "EVO"
      '
      'dtpFecAdquisicion
      '
      Me.dtpFecAdquisicion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecAdquisicion.Location = New System.Drawing.Point(463, 123)
      Me.dtpFecAdquisicion.Name = "dtpFecAdquisicion"
      Me.dtpFecAdquisicion.Size = New System.Drawing.Size(87, 23)
      Me.dtpFecAdquisicion.TabIndex = 18
      Me.dtpFecAdquisicion.Tag = "E"
      '
      'txtModelo
      '
      Me.txtModelo.Location = New System.Drawing.Point(148, 96)
      Me.txtModelo.Name = "txtModelo"
      Me.txtModelo.Size = New System.Drawing.Size(219, 23)
      Me.txtModelo.TabIndex = 12
      Me.txtModelo.Tag = "EV"
      '
      'cmbCombustible
      '
      Me.cmbCombustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCombustible.FormattingEnabled = True
      Me.cmbCombustible.Location = New System.Drawing.Point(463, 96)
      Me.cmbCombustible.Name = "cmbCombustible"
      Me.cmbCombustible.Size = New System.Drawing.Size(219, 23)
      Me.cmbCombustible.TabIndex = 14
      Me.cmbCombustible.Tag = "ECO"
      '
      'cmbMarca
      '
      Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarca.FormattingEnabled = True
      Me.cmbMarca.Location = New System.Drawing.Point(148, 69)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(219, 23)
      Me.cmbMarca.TabIndex = 8
      Me.cmbMarca.Tag = "ECO"
      '
      'cmbTipVehiculo
      '
      Me.cmbTipVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipVehiculo.FormattingEnabled = True
      Me.cmbTipVehiculo.Location = New System.Drawing.Point(463, 69)
      Me.cmbTipVehiculo.Name = "cmbTipVehiculo"
      Me.cmbTipVehiculo.Size = New System.Drawing.Size(219, 23)
      Me.cmbTipVehiculo.TabIndex = 10
      Me.cmbTipVehiculo.Tag = "ECO"
      '
      'txtVehiculoID
      '
      Me.txtVehiculoID.Location = New System.Drawing.Point(148, 15)
      Me.txtVehiculoID.Name = "txtVehiculoID"
      Me.txtVehiculoID.Size = New System.Drawing.Size(124, 23)
      Me.txtVehiculoID.TabIndex = 1
      Me.txtVehiculoID.Tag = "EV"
      '
      'lblVehCombustible
      '
      Me.lblVehCombustible.AutoSize = True
      Me.lblVehCombustible.Location = New System.Drawing.Point(3, 127)
      Me.lblVehCombustible.Name = "lblVehCombustible"
      Me.lblVehCombustible.Size = New System.Drawing.Size(140, 15)
      Me.lblVehCombustible.TabIndex = 15
      Me.lblVehCombustible.Text = "Capacidad Combustible :"
      '
      'lblCertificado
      '
      Me.lblCertificado.AutoSize = True
      Me.lblCertificado.Location = New System.Drawing.Point(72, 209)
      Me.lblCertificado.Name = "lblCertificado"
      Me.lblCertificado.Size = New System.Drawing.Size(71, 15)
      Me.lblCertificado.TabIndex = 29
      Me.lblCertificado.Text = "Certificado :"
      '
      'lblKmInicial
      '
      Me.lblKmInicial.AutoSize = True
      Me.lblKmInicial.Location = New System.Drawing.Point(36, 181)
      Me.lblKmInicial.Name = "lblKmInicial"
      Me.lblKmInicial.Size = New System.Drawing.Size(107, 15)
      Me.lblKmInicial.TabIndex = 23
      Me.lblKmInicial.Text = "Kilometraje Inicial :"
      '
      'lblKmActual
      '
      Me.lblKmActual.AutoSize = True
      Me.lblKmActual.Location = New System.Drawing.Point(346, 181)
      Me.lblKmActual.Name = "lblKmActual"
      Me.lblKmActual.Size = New System.Drawing.Size(110, 15)
      Me.lblKmActual.TabIndex = 26
      Me.lblKmActual.Text = "Kilometraje Actual :"
      '
      'lblNroEjes
      '
      Me.lblNroEjes.AutoSize = True
      Me.lblNroEjes.Location = New System.Drawing.Point(87, 154)
      Me.lblNroEjes.Name = "lblNroEjes"
      Me.lblNroEjes.Size = New System.Drawing.Size(56, 15)
      Me.lblNroEjes.TabIndex = 19
      Me.lblNroEjes.Text = "Nro Ejes :"
      '
      'lblNroNeumaticos
      '
      Me.lblNroNeumaticos.AutoSize = True
      Me.lblNroNeumaticos.Location = New System.Drawing.Point(356, 154)
      Me.lblNroNeumaticos.Name = "lblNroNeumaticos"
      Me.lblNroNeumaticos.Size = New System.Drawing.Size(100, 15)
      Me.lblNroNeumaticos.TabIndex = 21
      Me.lblNroNeumaticos.Text = "Nro Neumáticos :"
      '
      'lblPlaca
      '
      Me.lblPlaca.AutoSize = True
      Me.lblPlaca.Location = New System.Drawing.Point(102, 45)
      Me.lblPlaca.Name = "lblPlaca"
      Me.lblPlaca.Size = New System.Drawing.Size(41, 15)
      Me.lblPlaca.TabIndex = 5
      Me.lblPlaca.Text = "Placa :"
      '
      'lblFecAdquisicion
      '
      Me.lblFecAdquisicion.AutoSize = True
      Me.lblFecAdquisicion.Location = New System.Drawing.Point(346, 127)
      Me.lblFecAdquisicion.Name = "lblFecAdquisicion"
      Me.lblFecAdquisicion.Size = New System.Drawing.Size(110, 15)
      Me.lblFecAdquisicion.TabIndex = 17
      Me.lblFecAdquisicion.Text = "Fecha Adquisición :"
      '
      'lblModelo
      '
      Me.lblModelo.AutoSize = True
      Me.lblModelo.Location = New System.Drawing.Point(89, 100)
      Me.lblModelo.Name = "lblModelo"
      Me.lblModelo.Size = New System.Drawing.Size(54, 15)
      Me.lblModelo.TabIndex = 11
      Me.lblModelo.Text = "Modelo :"
      '
      'lblTipCombustible
      '
      Me.lblTipCombustible.AutoSize = True
      Me.lblTipCombustible.Location = New System.Drawing.Point(375, 100)
      Me.lblTipCombustible.Name = "lblTipCombustible"
      Me.lblTipCombustible.Size = New System.Drawing.Size(81, 15)
      Me.lblTipCombustible.TabIndex = 13
      Me.lblTipCombustible.Text = "Combustible :"
      '
      'lblMarca
      '
      Me.lblMarca.AutoSize = True
      Me.lblMarca.Location = New System.Drawing.Point(97, 73)
      Me.lblMarca.Name = "lblMarca"
      Me.lblMarca.Size = New System.Drawing.Size(46, 15)
      Me.lblMarca.TabIndex = 7
      Me.lblMarca.Text = "Marca :"
      '
      'lblCodTipVehiculo
      '
      Me.lblCodTipVehiculo.AutoSize = True
      Me.lblCodTipVehiculo.Location = New System.Drawing.Point(370, 73)
      Me.lblCodTipVehiculo.Name = "lblCodTipVehiculo"
      Me.lblCodTipVehiculo.Size = New System.Drawing.Size(86, 15)
      Me.lblCodTipVehiculo.TabIndex = 9
      Me.lblCodTipVehiculo.Text = "Tipo Vehiculo :"
      '
      'lblVehiculoID
      '
      Me.lblVehiculoID.AutoSize = True
      Me.lblVehiculoID.Location = New System.Drawing.Point(70, 19)
      Me.lblVehiculoID.Name = "lblVehiculoID"
      Me.lblVehiculoID.Size = New System.Drawing.Size(73, 15)
      Me.lblVehiculoID.TabIndex = 0
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
      Me.tabBusqueda.Selected = False
      Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
      Me.tabBusqueda.Size = New System.Drawing.Size(698, 325)
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
      Me.c1grdBusqueda.Size = New System.Drawing.Size(698, 274)
      Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
      Me.c1grdBusqueda.TabIndex = 2
      '
      'bnavBusqueda
      '
      Me.bnavBusqueda.AddNewItem = Me.BindingNavigatorAddNewItem
      Me.bnavBusqueda.CountItem = Me.BindingNavigatorCountItem
      Me.bnavBusqueda.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.tsbtnEnviarExcel})
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 273)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(698, 25)
      Me.bnavBusqueda.TabIndex = 3
      Me.bnavBusqueda.Text = "BindingNavigator1"
      Me.bnavBusqueda.Visible = False
      '
      'BindingNavigatorCountItem
      '
      Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
      Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
      Me.BindingNavigatorCountItem.Text = "of {0}"
      Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
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
      'BindingNavigatorSeparator2
      '
      Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
      Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'grpBusqueda
      '
      Me.grpBusqueda.Controls.Add(Me.btnConsultar)
      Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
      Me.grpBusqueda.Controls.Add(Me.rbtnPlaca)
      Me.grpBusqueda.Controls.Add(Me.rbtnCodigo)
      Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
      Me.grpBusqueda.Name = "grpBusqueda"
      Me.grpBusqueda.Size = New System.Drawing.Size(698, 51)
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
      Me.txtBusqueda.Location = New System.Drawing.Point(6, 20)
      Me.txtBusqueda.MaxLength = 32767
      Me.txtBusqueda.Name = "txtBusqueda"
      Me.txtBusqueda.Size = New System.Drawing.Size(402, 23)
      Me.txtBusqueda.TabIndex = 3
      '
      'rbtnPlaca
      '
      Me.rbtnPlaca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnPlaca.AutoSize = True
      Me.rbtnPlaca.Checked = True
      Me.rbtnPlaca.Location = New System.Drawing.Point(508, 21)
      Me.rbtnPlaca.Name = "rbtnPlaca"
      Me.rbtnPlaca.Size = New System.Drawing.Size(74, 19)
      Me.rbtnPlaca.TabIndex = 5
      Me.rbtnPlaca.TabStop = True
      Me.rbtnPlaca.Text = "Por Placa"
      Me.rbtnPlaca.UseVisualStyleBackColor = True
      '
      'rbtnCodigo
      '
      Me.rbtnCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnCodigo.AutoSize = True
      Me.rbtnCodigo.Location = New System.Drawing.Point(422, 21)
      Me.rbtnCodigo.Name = "rbtnCodigo"
      Me.rbtnCodigo.Size = New System.Drawing.Size(85, 19)
      Me.rbtnCodigo.TabIndex = 4
      Me.rbtnCodigo.Text = "Por Codigo"
      Me.rbtnCodigo.UseVisualStyleBackColor = True
      '
      'eprError
      '
      Me.eprError.ContainerControl = Me
      '
      'AcTool
      '
      Me.AcTool.ACBackColor = System.Drawing.Color.LightSteelBlue
      Me.AcTool.ACBackColorTFin = System.Drawing.Color.LightSteelBlue
      Me.AcTool.ACBackColorTIni = System.Drawing.Color.LightSteelBlue
      Me.AcTool.ACMostrarTabs = Crownwood.DotNetMagic.Controls.HideTabsModes.ShowAlways
      Me.AcTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabIni
      Me.AcTool.BackColor = System.Drawing.Color.LightSteelBlue
      Me.AcTool.Dock = System.Windows.Forms.DockStyle.Left
      Me.AcTool.Location = New System.Drawing.Point(0, 30)
      Me.AcTool.MinimumSize = New System.Drawing.Size(75, 254)
      Me.AcTool.Name = "AcTool"
      Me.AcTool.Size = New System.Drawing.Size(100, 350)
      Me.AcTool.TabIndex = 10
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
      'tsbtnEnviarExcel
      '
      Me.tsbtnEnviarExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.tsbtnEnviarExcel.Image = Global.ACPTransportes.My.Resources.Resources.Excel2_16x16
      Me.tsbtnEnviarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnEnviarExcel.Name = "tsbtnEnviarExcel"
      Me.tsbtnEnviarExcel.Size = New System.Drawing.Size(88, 22)
      Me.tsbtnEnviarExcel.Text = "Enviar Excel"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(588, 7)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(99, 41)
      Me.btnConsultar.TabIndex = 37
      Me.btnConsultar.Text = "Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'actxnCargaMax
      '
      Me.actxnCargaMax.ACEnteros = 9
      Me.actxnCargaMax.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnCargaMax.ACFormato = "########0.00"
      Me.actxnCargaMax.ACNegativo = True
      Me.actxnCargaMax.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
      Me.actxnCargaMax.Location = New System.Drawing.Point(148, 234)
      Me.actxnCargaMax.MaxLength = 12
      Me.actxnCargaMax.Name = "actxnCargaMax"
      Me.actxnCargaMax.Size = New System.Drawing.Size(124, 23)
      Me.actxnCargaMax.TabIndex = 34
      Me.actxnCargaMax.Tag = "EV"
      Me.actxnCargaMax.Text = "0.00"
      Me.actxnCargaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(51, 238)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(91, 15)
      Me.Label2.TabIndex = 33
      Me.Label2.Text = "Carga Max (Kg):"
      '
      'MVehiculos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(800, 380)
      Me.Controls.Add(Me.tabMantenimiento)
      Me.Controls.Add(Me.AcTool)
      Me.Controls.Add(Me.acpnlVehiculos)
      Me.Name = "MVehiculos"
      Me.Text = "Mantenimiento de Vehiculos"
      Me.tabMantenimiento.ResumeLayout(False)
      Me.tabDatos.ResumeLayout(False)
      Me.pnlDatos.ResumeLayout(False)
      Me.pnlDatos.PerformLayout()
      Me.grpTransportista.ResumeLayout(False)
      Me.grpTransportista.PerformLayout()
      Me.tabBusqueda.ResumeLayout(False)
      Me.tabBusqueda.PerformLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavBusqueda.ResumeLayout(False)
      Me.bnavBusqueda.PerformLayout()
      Me.grpBusqueda.ResumeLayout(False)
      Me.grpBusqueda.PerformLayout()
      CType(Me.eprError, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents acpnlVehiculos As ACControles.ACPanelCaption
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
   Friend WithEvents lblVehCombustible As System.Windows.Forms.Label
   Friend WithEvents lblCertificado As System.Windows.Forms.Label
   Friend WithEvents lblKmInicial As System.Windows.Forms.Label
   Friend WithEvents lblKmActual As System.Windows.Forms.Label
   Friend WithEvents lblNroEjes As System.Windows.Forms.Label
   Friend WithEvents lblNroNeumaticos As System.Windows.Forms.Label
   Friend WithEvents lblPlaca As System.Windows.Forms.Label
   Friend WithEvents lblFecAdquisicion As System.Windows.Forms.Label
   Friend WithEvents lblModelo As System.Windows.Forms.Label
   Friend WithEvents lblTipCombustible As System.Windows.Forms.Label
   Friend WithEvents lblMarca As System.Windows.Forms.Label
   Friend WithEvents lblCodTipVehiculo As System.Windows.Forms.Label
   Friend WithEvents lblVehiculoID As System.Windows.Forms.Label
   Friend WithEvents cmbCombustible As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMarca As System.Windows.Forms.ComboBox
   Friend WithEvents cmbTipVehiculo As System.Windows.Forms.ComboBox
   Friend WithEvents txtVehiculoID As System.Windows.Forms.TextBox
   Friend WithEvents lblKMI As System.Windows.Forms.Label
   Friend WithEvents lblKMA As System.Windows.Forms.Label
   Friend WithEvents txtVehiCombustible As System.Windows.Forms.TextBox
   Friend WithEvents txtCertificado As System.Windows.Forms.TextBox
   Friend WithEvents txtNroEjes As System.Windows.Forms.TextBox
   Friend WithEvents txtNroNeumaticos As System.Windows.Forms.TextBox
   Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
   Friend WithEvents dtpFecAdquisicion As System.Windows.Forms.DateTimePicker
   Friend WithEvents txtModelo As System.Windows.Forms.TextBox
   Friend WithEvents eprError As System.Windows.Forms.ErrorProvider
   Friend WithEvents actxnKilomInicial As ACControles.ACTextBoxNumerico
   Friend WithEvents actxnKilomActual As ACControles.ACTextBoxNumerico
   Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
   Friend WithEvents rbtnPlaca As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnCodigo As System.Windows.Forms.RadioButton
   Friend WithEvents grpTransportista As System.Windows.Forms.GroupBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents actxaDescTransportista As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaCodTransportista As ACControles.ACTextBoxAyuda
   Friend WithEvents AcTool As ACControles.ACToolBarMantVertical
   Friend WithEvents btnConsultar As System.Windows.Forms.Button
   Friend WithEvents chkVehiculos As System.Windows.Forms.CheckBox
   Friend WithEvents chkAnulado As System.Windows.Forms.CheckBox
   Friend WithEvents cmbPuntoVenta As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tsbtnEnviarExcel As System.Windows.Forms.ToolStripButton
   Friend WithEvents actxnCargaMax As ACControles.ACTextBoxNumerico
   Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
