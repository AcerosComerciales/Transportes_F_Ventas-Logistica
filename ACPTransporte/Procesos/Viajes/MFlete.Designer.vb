<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MFlete
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
        Me.actxaDescRuta = New ACControles.ACTextBoxAyuda()
        Me.actxaCodRuta = New ACControles.ACTextBoxAyuda()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.actxaCliente = New ACControles.ACTextBoxAyuda()
        Me.actxaCliRuc = New ACControles.ACTextBoxAyuda()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.actxnIGV = New ACControles.ACTextBoxNumerico()
        Me.chkIGV = New System.Windows.Forms.CheckBox()
        Me.actxnMontoXTm = New ACControles.ACTextBoxNumerico()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.actxnPeso = New ACControles.ACTextBoxNumerico()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCarga = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.actxnMonto = New ACControles.ACTextBoxNumerico()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtUbiDestino = New System.Windows.Forms.TextBox()
        Me.txtUbiOrigen = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpHoraProgramada = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraSalida = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraLlegada = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecProgramada = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecSalida = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecLlegada = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtSigla = New System.Windows.Forms.TextBox()
        Me.txtConductor = New System.Windows.Forms.TextBox()
        Me.txtCodConductor = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.actxaPlaca = New ACControles.ACTextBoxAyuda()
        Me.actxaCodVehiculo = New ACControles.ACTextBoxAyuda()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtViaje = New System.Windows.Forms.TextBox()
        Me.txtIdConductor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.actxnTotalValorReferencial = New ACControles.ACTextBoxNumerico()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.actxnValorReferencialXTm = New ACControles.ACTextBoxNumerico()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlDatos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'actxaDescRuta
        '
        Me.actxaDescRuta.ACActivarAyudaAuto = False
        Me.actxaDescRuta.ACLongitudAceptada = 0
        Me.actxaDescRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actxaDescRuta.Location = New System.Drawing.Point(201, 16)
        Me.actxaDescRuta.MaxLength = 32767
        Me.actxaDescRuta.Name = "actxaDescRuta"
        Me.actxaDescRuta.Size = New System.Drawing.Size(421, 23)
        Me.actxaDescRuta.TabIndex = 2
        Me.actxaDescRuta.Tag = "EVO"
        '
        'actxaCodRuta
        '
        Me.actxaCodRuta.ACActivarAyudaAuto = False
        Me.actxaCodRuta.ACLongitudAceptada = 0
        Me.actxaCodRuta.Location = New System.Drawing.Point(132, 17)
        Me.actxaCodRuta.MaxLength = 32767
        Me.actxaCodRuta.Name = "actxaCodRuta"
        Me.actxaCodRuta.Size = New System.Drawing.Size(63, 20)
        Me.actxaCodRuta.TabIndex = 1
        Me.actxaCodRuta.Tag = "EVO"
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
        Me.acTool.Location = New System.Drawing.Point(0, 477)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(646, 56)
        Me.acTool.TabIndex = 50
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Mantenimiento de Fletes"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(646, 30)
        Me.acpnlTitulo.TabIndex = 51
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClean.Image = Global.ACPTransportes.My.Resources.Resources.Delete_16x16
        Me.btnClean.Location = New System.Drawing.Point(592, 98)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(30, 24)
        Me.btnClean.TabIndex = 5
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.btnEditar.Location = New System.Drawing.Point(562, 98)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(30, 24)
        Me.btnEditar.TabIndex = 4
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(536, 98)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(26, 24)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'actxaCliente
        '
        Me.actxaCliente.ACActivarAyudaAuto = False
        Me.actxaCliente.ACLongitudAceptada = 0
        Me.actxaCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actxaCliente.Location = New System.Drawing.Point(258, 99)
        Me.actxaCliente.MaxLength = 50
        Me.actxaCliente.Name = "actxaCliente"
        Me.actxaCliente.Size = New System.Drawing.Size(272, 23)
        Me.actxaCliente.TabIndex = 2
        Me.actxaCliente.Tag = "EV"
        '
        'actxaCliRuc
        '
        Me.actxaCliRuc.ACActivarAyudaAuto = False
        Me.actxaCliRuc.ACLongitudAceptada = 0
        Me.actxaCliRuc.Location = New System.Drawing.Point(133, 100)
        Me.actxaCliRuc.MaxLength = 32767
        Me.actxaCliRuc.Name = "actxaCliRuc"
        Me.actxaCliRuc.Size = New System.Drawing.Size(117, 20)
        Me.actxaCliRuc.TabIndex = 1
        Me.actxaCliRuc.Tag = "EV"
        '
        'pnlDatos
        '
        Me.pnlDatos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlDatos.Controls.Add(Me.actxnTotalValorReferencial)
        Me.pnlDatos.Controls.Add(Me.Label11)
        Me.pnlDatos.Controls.Add(Me.actxnValorReferencialXTm)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.actxnIGV)
        Me.pnlDatos.Controls.Add(Me.chkIGV)
        Me.pnlDatos.Controls.Add(Me.actxnMontoXTm)
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.actxnPeso)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.txtCarga)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.Label15)
        Me.pnlDatos.Controls.Add(Me.btnClean)
        Me.pnlDatos.Controls.Add(Me.actxnMonto)
        Me.pnlDatos.Controls.Add(Me.btnEditar)
        Me.pnlDatos.Controls.Add(Me.cmbMoneda)
        Me.pnlDatos.Controls.Add(Me.btnNuevo)
        Me.pnlDatos.Controls.Add(Me.Label16)
        Me.pnlDatos.Controls.Add(Me.actxaCliente)
        Me.pnlDatos.Controls.Add(Me.GroupBox2)
        Me.pnlDatos.Controls.Add(Me.actxaCliRuc)
        Me.pnlDatos.Controls.Add(Me.dtpHoraProgramada)
        Me.pnlDatos.Controls.Add(Me.dtpHoraSalida)
        Me.pnlDatos.Controls.Add(Me.dtpHoraLlegada)
        Me.pnlDatos.Controls.Add(Me.dtpFecProgramada)
        Me.pnlDatos.Controls.Add(Me.dtpFecSalida)
        Me.pnlDatos.Controls.Add(Me.dtpFecLlegada)
        Me.pnlDatos.Controls.Add(Me.GroupBox3)
        Me.pnlDatos.Controls.Add(Me.Label23)
        Me.pnlDatos.Controls.Add(Me.Label24)
        Me.pnlDatos.Controls.Add(Me.Label25)
        Me.pnlDatos.Controls.Add(Me.Label26)
        Me.pnlDatos.Controls.Add(Me.GroupBox4)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 30)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(646, 447)
        Me.pnlDatos.TabIndex = 57
        '
        'actxnIGV
        '
        Me.actxnIGV.ACDecimales = 4
        Me.actxnIGV.ACEnteros = 9
        Me.actxnIGV.ACFormato = "###,###,##0.0000"
        Me.actxnIGV.ACNegativo = True
        Me.actxnIGV.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnIGV.Location = New System.Drawing.Point(133, 219)
        Me.actxnIGV.MaxLength = 12
        Me.actxnIGV.Name = "actxnIGV"
        Me.actxnIGV.Size = New System.Drawing.Size(82, 20)
        Me.actxnIGV.TabIndex = 23
        Me.actxnIGV.Tag = "EV"
        Me.actxnIGV.Text = "0.0000"
        Me.actxnIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkIGV
        '
        Me.chkIGV.AutoSize = True
        Me.chkIGV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIGV.Location = New System.Drawing.Point(40, 221)
        Me.chkIGV.Name = "chkIGV"
        Me.chkIGV.Size = New System.Drawing.Size(81, 17)
        Me.chkIGV.TabIndex = 22
        Me.chkIGV.Text = "Con I.G.V. :"
        Me.chkIGV.UseVisualStyleBackColor = True
        '
        'actxnMontoXTm
        '
        Me.actxnMontoXTm.ACDecimales = 4
        Me.actxnMontoXTm.ACEnteros = 9
        Me.actxnMontoXTm.ACFormato = "###,###,##0.0000"
        Me.actxnMontoXTm.ACNegativo = True
        Me.actxnMontoXTm.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnMontoXTm.Location = New System.Drawing.Point(133, 195)
        Me.actxnMontoXTm.MaxLength = 12
        Me.actxnMontoXTm.Name = "actxnMontoXTm"
        Me.actxnMontoXTm.Size = New System.Drawing.Size(82, 20)
        Me.actxnMontoXTm.TabIndex = 20
        Me.actxnMontoXTm.Tag = "EV"
        Me.actxnMontoXTm.Text = "0.0000"
        Me.actxnMontoXTm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(218, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Por T.M."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(221, 247)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "T.M."
        '
        'actxnPeso
        '
        Me.actxnPeso.ACDecimales = 4
        Me.actxnPeso.ACEnteros = 9
        Me.actxnPeso.ACFormato = "###,###,##0.0000"
        Me.actxnPeso.ACNegativo = True
        Me.actxnPeso.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnPeso.Location = New System.Drawing.Point(133, 243)
        Me.actxnPeso.MaxLength = 12
        Me.actxnPeso.Name = "actxnPeso"
        Me.actxnPeso.Size = New System.Drawing.Size(84, 20)
        Me.actxnPeso.TabIndex = 25
        Me.actxnPeso.Tag = "EV"
        Me.actxnPeso.Text = "0.0000"
        Me.actxnPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(59, 247)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Peso Total :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(80, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Monto :"
        '
        'txtCarga
        '
        Me.txtCarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCarga.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarga.Location = New System.Drawing.Point(133, 289)
        Me.txtCarga.MaxLength = 200
        Me.txtCarga.Multiline = True
        Me.txtCarga.Name = "txtCarga"
        Me.txtCarga.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCarga.Size = New System.Drawing.Size(489, 43)
        Me.txtCarga.TabIndex = 30
        Me.txtCarga.Tag = "EV"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(44, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 34)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Descripcion de la Carga :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(87, 270)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Flete :"
        '
        'actxnMonto
        '
        Me.actxnMonto.ACEnteros = 9
        Me.actxnMonto.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnMonto.ACNegativo = True
        Me.actxnMonto.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnMonto.Location = New System.Drawing.Point(133, 266)
        Me.actxnMonto.MaxLength = 12
        Me.actxnMonto.Name = "actxnMonto"
        Me.actxnMonto.Size = New System.Drawing.Size(96, 20)
        Me.actxnMonto.TabIndex = 28
        Me.actxnMonto.Tag = "EV"
        Me.actxnMonto.Text = "0.00"
        Me.actxnMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(133, 171)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(319, 21)
        Me.cmbMoneda.TabIndex = 18
        Me.cmbMoneda.Tag = "ECO"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(71, 174)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Moneda :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.actxaDescRuta)
        Me.GroupBox2.Controls.Add(Me.txtUbiDestino)
        Me.GroupBox2.Controls.Add(Me.actxaCodRuta)
        Me.GroupBox2.Controls.Add(Me.txtUbiOrigen)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtDestino)
        Me.GroupBox2.Controls.Add(Me.txtOrigen)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(646, 94)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ruta del Flete"
        '
        'txtUbiDestino
        '
        Me.txtUbiDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUbiDestino.Location = New System.Drawing.Point(132, 68)
        Me.txtUbiDestino.Name = "txtUbiDestino"
        Me.txtUbiDestino.ReadOnly = True
        Me.txtUbiDestino.Size = New System.Drawing.Size(63, 20)
        Me.txtUbiDestino.TabIndex = 7
        '
        'txtUbiOrigen
        '
        Me.txtUbiOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUbiOrigen.Location = New System.Drawing.Point(132, 42)
        Me.txtUbiOrigen.Name = "txtUbiOrigen"
        Me.txtUbiOrigen.ReadOnly = True
        Me.txtUbiOrigen.Size = New System.Drawing.Size(63, 20)
        Me.txtUbiOrigen.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(81, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 13)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Origen :"
        '
        'txtDestino
        '
        Me.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDestino.Location = New System.Drawing.Point(202, 68)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.ReadOnly = True
        Me.txtDestino.Size = New System.Drawing.Size(250, 20)
        Me.txtDestino.TabIndex = 8
        '
        'txtOrigen
        '
        Me.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrigen.Location = New System.Drawing.Point(202, 42)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(250, 20)
        Me.txtOrigen.TabIndex = 5
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(77, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Destino :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(93, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(36, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Ruta :"
        '
        'dtpHoraProgramada
        '
        Me.dtpHoraProgramada.CustomFormat = "hh:mm tt"
        Me.dtpHoraProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraProgramada.Location = New System.Drawing.Point(245, 124)
        Me.dtpHoraProgramada.Name = "dtpHoraProgramada"
        Me.dtpHoraProgramada.ShowUpDown = True
        Me.dtpHoraProgramada.Size = New System.Drawing.Size(81, 20)
        Me.dtpHoraProgramada.TabIndex = 10
        '
        'dtpHoraSalida
        '
        Me.dtpHoraSalida.CustomFormat = "hh:mm tt"
        Me.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraSalida.Location = New System.Drawing.Point(246, 147)
        Me.dtpHoraSalida.Name = "dtpHoraSalida"
        Me.dtpHoraSalida.ShowUpDown = True
        Me.dtpHoraSalida.Size = New System.Drawing.Size(81, 20)
        Me.dtpHoraSalida.TabIndex = 13
        '
        'dtpHoraLlegada
        '
        Me.dtpHoraLlegada.CustomFormat = "hh:mm tt"
        Me.dtpHoraLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraLlegada.Location = New System.Drawing.Point(541, 147)
        Me.dtpHoraLlegada.Name = "dtpHoraLlegada"
        Me.dtpHoraLlegada.ShowUpDown = True
        Me.dtpHoraLlegada.Size = New System.Drawing.Size(81, 20)
        Me.dtpHoraLlegada.TabIndex = 16
        '
        'dtpFecProgramada
        '
        Me.dtpFecProgramada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecProgramada.Location = New System.Drawing.Point(132, 124)
        Me.dtpFecProgramada.Name = "dtpFecProgramada"
        Me.dtpFecProgramada.Size = New System.Drawing.Size(96, 20)
        Me.dtpFecProgramada.TabIndex = 9
        '
        'dtpFecSalida
        '
        Me.dtpFecSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecSalida.Location = New System.Drawing.Point(133, 147)
        Me.dtpFecSalida.Name = "dtpFecSalida"
        Me.dtpFecSalida.Size = New System.Drawing.Size(96, 20)
        Me.dtpFecSalida.TabIndex = 12
        '
        'dtpFecLlegada
        '
        Me.dtpFecLlegada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecLlegada.Location = New System.Drawing.Point(428, 147)
        Me.dtpFecLlegada.Name = "dtpFecLlegada"
        Me.dtpFecLlegada.Size = New System.Drawing.Size(96, 20)
        Me.dtpFecLlegada.TabIndex = 15
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.txtSigla)
        Me.GroupBox3.Controls.Add(Me.txtConductor)
        Me.GroupBox3.Controls.Add(Me.txtCodConductor)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.actxaPlaca)
        Me.GroupBox3.Controls.Add(Me.actxaCodVehiculo)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 339)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(646, 60)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Vehiculo"
        '
        'txtSigla
        '
        Me.txtSigla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSigla.Location = New System.Drawing.Point(556, 35)
        Me.txtSigla.Name = "txtSigla"
        Me.txtSigla.ReadOnly = True
        Me.txtSigla.Size = New System.Drawing.Size(66, 20)
        Me.txtSigla.TabIndex = 10
        '
        'txtConductor
        '
        Me.txtConductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConductor.Location = New System.Drawing.Point(235, 35)
        Me.txtConductor.Name = "txtConductor"
        Me.txtConductor.ReadOnly = True
        Me.txtConductor.Size = New System.Drawing.Size(315, 20)
        Me.txtConductor.TabIndex = 9
        '
        'txtCodConductor
        '
        Me.txtCodConductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodConductor.Location = New System.Drawing.Point(132, 35)
        Me.txtCodConductor.Name = "txtCodConductor"
        Me.txtCodConductor.ReadOnly = True
        Me.txtCodConductor.Size = New System.Drawing.Size(97, 20)
        Me.txtCodConductor.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(58, 37)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Conductor :"
        '
        'actxaPlaca
        '
        Me.actxaPlaca.ACActivarAyudaAuto = False
        Me.actxaPlaca.ACLongitudAceptada = 0
        Me.actxaPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaPlaca.Location = New System.Drawing.Point(285, 11)
        Me.actxaPlaca.MaxLength = 32767
        Me.actxaPlaca.Name = "actxaPlaca"
        Me.actxaPlaca.Size = New System.Drawing.Size(97, 20)
        Me.actxaPlaca.TabIndex = 3
        Me.actxaPlaca.Tag = "EVO"
        '
        'actxaCodVehiculo
        '
        Me.actxaCodVehiculo.ACActivarAyudaAuto = False
        Me.actxaCodVehiculo.ACLongitudAceptada = 0
        Me.actxaCodVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaCodVehiculo.Location = New System.Drawing.Point(132, 11)
        Me.actxaCodVehiculo.MaxLength = 32767
        Me.actxaCodVehiculo.Name = "actxaCodVehiculo"
        Me.actxaCodVehiculo.Size = New System.Drawing.Size(97, 20)
        Me.actxaCodVehiculo.TabIndex = 1
        Me.actxaCodVehiculo.Tag = "EVO"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(239, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Placa :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(75, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Código :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(21, 128)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(103, 13)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "Fecha Programada :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(48, 151)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(75, 13)
        Me.Label24.TabIndex = 11
        Me.Label24.Text = "Fecha Salida :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(334, 151)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 13)
        Me.Label25.TabIndex = 14
        Me.Label25.Text = "Fecha LLegada :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(78, 104)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(45, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Cliente :"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox4.Controls.Add(Me.txtGlosa)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtViaje)
        Me.GroupBox4.Controls.Add(Me.txtIdConductor)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(0, 399)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(646, 48)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Viaje Generado"
        '
        'txtGlosa
        '
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.Location = New System.Drawing.Point(335, 17)
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ReadOnly = True
        Me.txtGlosa.Size = New System.Drawing.Size(292, 20)
        Me.txtGlosa.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(284, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Glosa :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Viaje :"
        '
        'txtViaje
        '
        Me.txtViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtViaje.Location = New System.Drawing.Point(66, 17)
        Me.txtViaje.Name = "txtViaje"
        Me.txtViaje.ReadOnly = True
        Me.txtViaje.Size = New System.Drawing.Size(44, 20)
        Me.txtViaje.TabIndex = 7
        '
        'txtIdConductor
        '
        Me.txtIdConductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdConductor.Location = New System.Drawing.Point(234, 17)
        Me.txtIdConductor.Name = "txtIdConductor"
        Me.txtIdConductor.ReadOnly = True
        Me.txtIdConductor.Size = New System.Drawing.Size(41, 20)
        Me.txtIdConductor.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Viaje x Conductor :"
        '
        'actxnTotalValorReferencial
        '
        Me.actxnTotalValorReferencial.ACEnteros = 9
        Me.actxnTotalValorReferencial.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTotalValorReferencial.ACNegativo = True
        Me.actxnTotalValorReferencial.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTotalValorReferencial.Enabled = False
        Me.actxnTotalValorReferencial.Location = New System.Drawing.Point(457, 225)
        Me.actxnTotalValorReferencial.MaxLength = 12
        Me.actxnTotalValorReferencial.Name = "actxnTotalValorReferencial"
        Me.actxnTotalValorReferencial.Size = New System.Drawing.Size(117, 20)
        Me.actxnTotalValorReferencial.TabIndex = 43
        Me.actxnTotalValorReferencial.Tag = "EV"
        Me.actxnTotalValorReferencial.Text = "0.00"
        Me.actxnTotalValorReferencial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(390, 229)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 42
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
        Me.actxnValorReferencialXTm.Location = New System.Drawing.Point(457, 196)
        Me.actxnValorReferencialXTm.MaxLength = 12
        Me.actxnValorReferencialXTm.Name = "actxnValorReferencialXTm"
        Me.actxnValorReferencialXTm.Size = New System.Drawing.Size(117, 20)
        Me.actxnValorReferencialXTm.TabIndex = 40
        Me.actxnValorReferencialXTm.Tag = "EV"
        Me.actxnValorReferencialXTm.Text = "0.0000"
        Me.actxnValorReferencialXTm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(586, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Por T.M."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(351, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Valor Referencial :"
        '
        'MFlete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(646, 533)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Controls.Add(Me.acTool)
        Me.Name = "MFlete"
        Me.Text = "Mantenimiento de Fletes"
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents actxaDescRuta As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaCodRuta As ACControles.ACTextBoxAyuda
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents btnClean As System.Windows.Forms.Button
   Friend WithEvents btnEditar As System.Windows.Forms.Button
   Friend WithEvents btnNuevo As System.Windows.Forms.Button
   Friend WithEvents actxaCliente As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaCliRuc As ACControles.ACTextBoxAyuda
   Friend WithEvents pnlDatos As System.Windows.Forms.Panel
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents actxnMonto As ACControles.ACTextBoxNumerico
   Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents txtUbiDestino As System.Windows.Forms.TextBox
   Friend WithEvents txtUbiOrigen As System.Windows.Forms.TextBox
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents txtDestino As System.Windows.Forms.TextBox
   Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents dtpHoraProgramada As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpHoraSalida As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpHoraLlegada As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpFecProgramada As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpFecSalida As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpFecLlegada As System.Windows.Forms.DateTimePicker
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents actxaPlaca As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaCodVehiculo As ACControles.ACTextBoxAyuda
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Friend WithEvents Label25 As System.Windows.Forms.Label
   Friend WithEvents Label26 As System.Windows.Forms.Label
   Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
   Friend WithEvents txtSigla As System.Windows.Forms.TextBox
   Friend WithEvents txtConductor As System.Windows.Forms.TextBox
   Friend WithEvents txtCodConductor As System.Windows.Forms.TextBox
   Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents txtViaje As System.Windows.Forms.TextBox
   Friend WithEvents txtIdConductor As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtCarga As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents actxnMontoXTm As ACControles.ACTextBoxNumerico
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents actxnPeso As ACControles.ACTextBoxNumerico
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents actxnIGV As ACControles.ACTextBoxNumerico
    Friend WithEvents chkIGV As System.Windows.Forms.CheckBox
    Friend WithEvents actxnTotalValorReferencial As ACControles.ACTextBoxNumerico
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents actxnValorReferencialXTm As ACControles.ACTextBoxNumerico
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
