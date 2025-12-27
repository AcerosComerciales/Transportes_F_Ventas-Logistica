<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PConsumoAdBlue
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
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.chkComprobante = New System.Windows.Forms.CheckBox()
        Me.grpComprobante = New System.Windows.Forms.GroupBox()
        Me.actxnTotal = New ACControles.ACTextBoxNumerico()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.actxnPrecioUnit = New ACControles.ACTextBoxNumerico()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnNueProveedor = New System.Windows.Forms.Button()
        Me.actxaDescProveedor = New ACControles.ACTextBoxAyuda()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.actxaNroDocProveedor = New ACControles.ACTextBoxAyuda()
        Me.grpDocumento = New System.Windows.Forms.GroupBox()
        Me.txtSeriecomp = New System.Windows.Forms.TextBox()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpComprobanteFecha = New System.Windows.Forms.DateTimePicker()
        Me.actxnNumComprobante = New ACControles.ACTextBoxNumerico()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.actxnNumero = New ACControles.ACTextBoxNumerico()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.tscmbImpresora = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.actxnLitrosConsumidos = New ACControles.ACTextBoxNumerico()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbPendiente = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpComFecha = New System.Windows.Forms.DateTimePicker()
        Me.chkCCaja = New System.Windows.Forms.CheckBox()
        Me.actxnGalonesConsumidos = New ACControles.ACTextBoxNumerico()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.cmbConsumibles = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.grpComprobante.SuspendLayout()
        Me.grpDocumento.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Registro de Consumo de AdBlue"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(562, 30)
        Me.acpnlTitulo.TabIndex = 1
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
        Me.tabMantenimiento.Size = New System.Drawing.Size(562, 400)
        Me.tabMantenimiento.TabIndex = 10
        Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos})
        Me.tabMantenimiento.TextTips = True
        '
        'tabDatos
        '
        Me.tabDatos.Controls.Add(Me.chkComprobante)
        Me.tabDatos.Controls.Add(Me.grpComprobante)
        Me.tabDatos.Controls.Add(Me.pnlDatos)
        Me.tabDatos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Location = New System.Drawing.Point(1, 1)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Size = New System.Drawing.Size(560, 375)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'chkComprobante
        '
        Me.chkComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkComprobante.AutoSize = True
        Me.chkComprobante.Location = New System.Drawing.Point(12, 159)
        Me.chkComprobante.Name = "chkComprobante"
        Me.chkComprobante.Size = New System.Drawing.Size(146, 19)
        Me.chkComprobante.TabIndex = 36
        Me.chkComprobante.Text = "Comprobante de Pago"
        Me.chkComprobante.UseVisualStyleBackColor = True
        '
        'grpComprobante
        '
        Me.grpComprobante.Controls.Add(Me.actxnTotal)
        Me.grpComprobante.Controls.Add(Me.Label6)
        Me.grpComprobante.Controls.Add(Me.actxnPrecioUnit)
        Me.grpComprobante.Controls.Add(Me.Label5)
        Me.grpComprobante.Controls.Add(Me.btnNueProveedor)
        Me.grpComprobante.Controls.Add(Me.actxaDescProveedor)
        Me.grpComprobante.Controls.Add(Me.lblProveedor)
        Me.grpComprobante.Controls.Add(Me.actxaNroDocProveedor)
        Me.grpComprobante.Controls.Add(Me.grpDocumento)
        Me.grpComprobante.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpComprobante.Enabled = False
        Me.grpComprobante.Location = New System.Drawing.Point(0, 160)
        Me.grpComprobante.Name = "grpComprobante"
        Me.grpComprobante.Size = New System.Drawing.Size(560, 215)
        Me.grpComprobante.TabIndex = 35
        Me.grpComprobante.TabStop = False
        '
        'actxnTotal
        '
        Me.actxnTotal.ACEnteros = 9
        Me.actxnTotal.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnTotal.ACNegativo = True
        Me.actxnTotal.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTotal.Location = New System.Drawing.Point(430, 111)
        Me.actxnTotal.MaxLength = 12
        Me.actxnTotal.Name = "actxnTotal"
        Me.actxnTotal.Size = New System.Drawing.Size(97, 23)
        Me.actxnTotal.TabIndex = 44
        Me.actxnTotal.Tag = "V"
        Me.actxnTotal.Text = "0.00"
        Me.actxnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(378, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 15)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Total S/:"
        '
        'actxnPrecioUnit
        '
        Me.actxnPrecioUnit.ACEnteros = 9
        Me.actxnPrecioUnit.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnPrecioUnit.ACNegativo = True
        Me.actxnPrecioUnit.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnPrecioUnit.Location = New System.Drawing.Point(248, 111)
        Me.actxnPrecioUnit.MaxLength = 12
        Me.actxnPrecioUnit.Name = "actxnPrecioUnit"
        Me.actxnPrecioUnit.Size = New System.Drawing.Size(97, 23)
        Me.actxnPrecioUnit.TabIndex = 42
        Me.actxnPrecioUnit.Tag = "V"
        Me.actxnPrecioUnit.Text = "0.00"
        Me.actxnPrecioUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(166, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Precio Unit S/:"
        '
        'btnNueProveedor
        '
        Me.btnNueProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNueProveedor.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnNueProveedor.Location = New System.Drawing.Point(520, 22)
        Me.btnNueProveedor.Name = "btnNueProveedor"
        Me.btnNueProveedor.Size = New System.Drawing.Size(29, 27)
        Me.btnNueProveedor.TabIndex = 3
        Me.btnNueProveedor.TabStop = False
        Me.btnNueProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNueProveedor.UseVisualStyleBackColor = True
        '
        'actxaDescProveedor
        '
        Me.actxaDescProveedor.ACActivarAyudaAuto = False
        Me.actxaDescProveedor.ACLongitudAceptada = 0
        Me.actxaDescProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaDescProveedor.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxaDescProveedor.Location = New System.Drawing.Point(207, 24)
        Me.actxaDescProveedor.MaxLength = 80
        Me.actxaDescProveedor.Name = "actxaDescProveedor"
        Me.actxaDescProveedor.Size = New System.Drawing.Size(310, 23)
        Me.actxaDescProveedor.TabIndex = 2
        Me.actxaDescProveedor.Tag = "EV"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(9, 28)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(67, 15)
        Me.lblProveedor.TabIndex = 0
        Me.lblProveedor.Text = "Proveedor :"
        '
        'actxaNroDocProveedor
        '
        Me.actxaNroDocProveedor.ACActivarAyudaAuto = False
        Me.actxaNroDocProveedor.ACLongitudAceptada = 0
        Me.actxaNroDocProveedor.Location = New System.Drawing.Point(80, 25)
        Me.actxaNroDocProveedor.MaxLength = 14
        Me.actxaNroDocProveedor.Name = "actxaNroDocProveedor"
        Me.actxaNroDocProveedor.Size = New System.Drawing.Size(121, 23)
        Me.actxaNroDocProveedor.TabIndex = 1
        Me.actxaNroDocProveedor.Tag = "EV"
        '
        'grpDocumento
        '
        Me.grpDocumento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpDocumento.Controls.Add(Me.txtSeriecomp)
        Me.grpDocumento.Controls.Add(Me.lblTipoDocumento)
        Me.grpDocumento.Controls.Add(Me.cmbTipoDocumento)
        Me.grpDocumento.Controls.Add(Me.Label7)
        Me.grpDocumento.Controls.Add(Me.dtpComprobanteFecha)
        Me.grpDocumento.Controls.Add(Me.actxnNumComprobante)
        Me.grpDocumento.Controls.Add(Me.Label4)
        Me.grpDocumento.Controls.Add(Me.Label8)
        Me.grpDocumento.Location = New System.Drawing.Point(3, 49)
        Me.grpDocumento.Name = "grpDocumento"
        Me.grpDocumento.Size = New System.Drawing.Size(550, 56)
        Me.grpDocumento.TabIndex = 4
        Me.grpDocumento.TabStop = False
        '
        'txtSeriecomp
        '
        Me.txtSeriecomp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSeriecomp.Location = New System.Drawing.Point(348, 26)
        Me.txtSeriecomp.MaxLength = 5
        Me.txtSeriecomp.Name = "txtSeriecomp"
        Me.txtSeriecomp.Size = New System.Drawing.Size(60, 23)
        Me.txtSeriecomp.TabIndex = 5
        Me.txtSeriecomp.Tag = "EV"
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.AutoSize = True
        Me.lblTipoDocumento.Location = New System.Drawing.Point(119, 10)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(96, 15)
        Me.lblTipoDocumento.TabIndex = 2
        Me.lblTipoDocumento.Text = "Tipo Documento"
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.Items.AddRange(New Object() {"Boleta", "Factura"})
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(114, 26)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(229, 23)
        Me.cmbTipoDocumento.TabIndex = 3
        Me.cmbTipoDocumento.Tag = "EC"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Fecha :"
        '
        'dtpComprobanteFecha
        '
        Me.dtpComprobanteFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpComprobanteFecha.Location = New System.Drawing.Point(9, 26)
        Me.dtpComprobanteFecha.Name = "dtpComprobanteFecha"
        Me.dtpComprobanteFecha.Size = New System.Drawing.Size(99, 23)
        Me.dtpComprobanteFecha.TabIndex = 1
        '
        'actxnNumComprobante
        '
        Me.actxnNumComprobante.ACEnteros = 8
        Me.actxnNumComprobante.ACFormato = "#######0"
        Me.actxnNumComprobante.ACNegativo = True
        Me.actxnNumComprobante.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnNumComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnNumComprobante.Location = New System.Drawing.Point(415, 26)
        Me.actxnNumComprobante.MaxLength = 26
        Me.actxnNumComprobante.Name = "actxnNumComprobante"
        Me.actxnNumComprobante.Size = New System.Drawing.Size(109, 23)
        Me.actxnNumComprobante.TabIndex = 7
        Me.actxnNumComprobante.Tag = "EN"
        Me.actxnNumComprobante.Text = "0"
        Me.actxnNumComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(421, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Numero"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(353, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 15)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Serie"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.cmbConsumibles)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.actxnNumero)
        Me.pnlDatos.Controls.Add(Me.txtSerie)
        Me.pnlDatos.Controls.Add(Me.tscmbImpresora)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.actxnLitrosConsumidos)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.cmbPendiente)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.dtpComFecha)
        Me.pnlDatos.Controls.Add(Me.chkCCaja)
        Me.pnlDatos.Controls.Add(Me.actxnGalonesConsumidos)
        Me.pnlDatos.Controls.Add(Me.Label18)
        Me.pnlDatos.Controls.Add(Me.Label20)
        Me.pnlDatos.Location = New System.Drawing.Point(0, 1)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(556, 166)
        Me.pnlDatos.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Codigo :"
        '
        'actxnNumero
        '
        Me.actxnNumero.ACEnteros = 8
        Me.actxnNumero.ACFormato = "#######0"
        Me.actxnNumero.ACNegativo = True
        Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnNumero.Enabled = False
        Me.actxnNumero.Location = New System.Drawing.Point(179, 36)
        Me.actxnNumero.MaxLength = 7
        Me.actxnNumero.Name = "actxnNumero"
        Me.actxnNumero.Size = New System.Drawing.Size(117, 23)
        Me.actxnNumero.TabIndex = 39
        Me.actxnNumero.Tag = "ENO"
        Me.actxnNumero.Text = "0"
        Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSerie
        '
        Me.txtSerie.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.Enabled = False
        Me.txtSerie.Location = New System.Drawing.Point(118, 36)
        Me.txtSerie.MaxLength = 3
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSerie.Size = New System.Drawing.Size(56, 23)
        Me.txtSerie.TabIndex = 38
        Me.txtSerie.Tag = "EVO"
        Me.txtSerie.Text = "009"
        '
        'tscmbImpresora
        '
        Me.tscmbImpresora.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tscmbImpresora.FormattingEnabled = True
        Me.tscmbImpresora.Location = New System.Drawing.Point(327, 130)
        Me.tscmbImpresora.Name = "tscmbImpresora"
        Me.tscmbImpresora.Size = New System.Drawing.Size(213, 23)
        Me.tscmbImpresora.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(245, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Impresora :"
        '
        'actxnLitrosConsumidos
        '
        Me.actxnLitrosConsumidos.ACDecimales = 4
        Me.actxnLitrosConsumidos.ACEnteros = 8
        Me.actxnLitrosConsumidos.ACFormato = "#####0.0000"
        Me.actxnLitrosConsumidos.ACNegativo = True
        Me.actxnLitrosConsumidos.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnLitrosConsumidos.Location = New System.Drawing.Point(117, 70)
        Me.actxnLitrosConsumidos.MaxLength = 12
        Me.actxnLitrosConsumidos.Name = "actxnLitrosConsumidos"
        Me.actxnLitrosConsumidos.Size = New System.Drawing.Size(97, 23)
        Me.actxnLitrosConsumidos.TabIndex = 25
        Me.actxnLitrosConsumidos.Text = "0.0000"
        Me.actxnLitrosConsumidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Litros Consumido :"
        '
        'cmbPendiente
        '
        Me.cmbPendiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPendiente.FormattingEnabled = True
        Me.cmbPendiente.Location = New System.Drawing.Point(116, 7)
        Me.cmbPendiente.Name = "cmbPendiente"
        Me.cmbPendiente.Size = New System.Drawing.Size(424, 23)
        Me.cmbPendiente.TabIndex = 1
        Me.cmbPendiente.Tag = "EO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(45, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Pendiente :"
        '
        'dtpComFecha
        '
        Me.dtpComFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpComFecha.Location = New System.Drawing.Point(407, 36)
        Me.dtpComFecha.Name = "dtpComFecha"
        Me.dtpComFecha.Size = New System.Drawing.Size(133, 23)
        Me.dtpComFecha.TabIndex = 19
        Me.dtpComFecha.Tag = ""
        '
        'chkCCaja
        '
        Me.chkCCaja.AutoSize = True
        Me.chkCCaja.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCCaja.Location = New System.Drawing.Point(435, 106)
        Me.chkCCaja.Name = "chkCCaja"
        Me.chkCCaja.Size = New System.Drawing.Size(106, 19)
        Me.chkCCaja.TabIndex = 20
        Me.chkCCaja.Tag = ""
        Me.chkCCaja.Text = "Ingresa En Caja"
        Me.chkCCaja.UseVisualStyleBackColor = True
        '
        'actxnGalonesConsumidos
        '
        Me.actxnGalonesConsumidos.ACDecimales = 4
        Me.actxnGalonesConsumidos.ACEnteros = 8
        Me.actxnGalonesConsumidos.ACFormato = "#####0.0000"
        Me.actxnGalonesConsumidos.ACNegativo = True
        Me.actxnGalonesConsumidos.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnGalonesConsumidos.Location = New System.Drawing.Point(374, 70)
        Me.actxnGalonesConsumidos.MaxLength = 12
        Me.actxnGalonesConsumidos.Name = "actxnGalonesConsumidos"
        Me.actxnGalonesConsumidos.Size = New System.Drawing.Size(97, 23)
        Me.actxnGalonesConsumidos.TabIndex = 15
        Me.actxnGalonesConsumidos.Text = "0.0000"
        Me.actxnGalonesConsumidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(357, 42)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 15)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "&Fecha :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(249, 73)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 15)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "Galones Consumido :"
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
        Me.acTool.Location = New System.Drawing.Point(0, 374)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(562, 56)
        Me.acTool.TabIndex = 12
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'PrintDocument1
        '
        '
        'cmbConsumibles
        '
        Me.cmbConsumibles.FormattingEnabled = True
        Me.cmbConsumibles.Location = New System.Drawing.Point(91, 125)
        Me.cmbConsumibles.Name = "cmbConsumibles"
        Me.cmbConsumibles.Size = New System.Drawing.Size(146, 23)
        Me.cmbConsumibles.TabIndex = 41
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 15)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Consumibles"
        '
        'PConsumoAdBlue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 430)
        Me.Controls.Add(Me.acTool)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Name = "PConsumoAdBlue"
        Me.Text = "PConsumoAdBlue"
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.tabDatos.PerformLayout()
        Me.grpComprobante.ResumeLayout(False)
        Me.grpComprobante.PerformLayout()
        Me.grpDocumento.ResumeLayout(False)
        Me.grpDocumento.PerformLayout()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
    Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
    Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
    Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents chkComprobante As System.Windows.Forms.CheckBox
    Friend WithEvents tscmbImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents btnNueProveedor As System.Windows.Forms.Button
    Friend WithEvents actxaDescProveedor As ACControles.ACTextBoxAyuda
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents actxaNroDocProveedor As ACControles.ACTextBoxAyuda
    Friend WithEvents grpDocumento As System.Windows.Forms.GroupBox
    Friend WithEvents txtSeriecomp As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpComprobanteFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents actxnNumComprobante As ACControles.ACTextBoxNumerico
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents actxnLitrosConsumidos As ACControles.ACTextBoxNumerico
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPendiente As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpComFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkCCaja As System.Windows.Forms.CheckBox
    Friend WithEvents actxnGalonesConsumidos As ACControles.ACTextBoxNumerico
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents actxnTotal As ACControles.ACTextBoxNumerico
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents actxnPrecioUnit As ACControles.ACTextBoxNumerico
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbConsumibles As ComboBox
End Class
