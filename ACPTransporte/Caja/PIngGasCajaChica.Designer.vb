<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PIngGasCajaChica
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PIngGasCajaChica))
      Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
      Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.pnlDatos = New System.Windows.Forms.Panel()
      Me.lblMoneda = New System.Windows.Forms.Label()
      Me.cmbMoneda = New System.Windows.Forms.ComboBox()
      Me.lblTotalPagar = New System.Windows.Forms.Label()
      Me.actxnImporte = New ACControles.ACTextBoxNumerico()
      Me.txtDetalles = New System.Windows.Forms.TextBox()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.btnNuevoCliente = New System.Windows.Forms.Button()
      Me.btnClean = New System.Windows.Forms.Button()
      Me.actxaRazonSocial = New ACControles.ACTextBoxAyuda()
      Me.actxaDocumento = New ACControles.ACTextBoxAyuda()
      Me.lblNroDocumento = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
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
      Me.chkTodos = New System.Windows.Forms.CheckBox()
      Me.btnCConsultar = New System.Windows.Forms.Button()
      Me.AcFecha = New ACControles.ACFecha(Me.components)
      Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
      Me.tabPagos = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.c1grdPagos = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.tsbtnAgregar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbtnQuitar = New System.Windows.Forms.ToolStripButton()
      Me.bnavPagos = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.tstxtTotal = New System.Windows.Forms.ToolStripTextBox()
      Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.txtRazSocialUsuario = New System.Windows.Forms.TextBox()
      Me.txtDocUsuario = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmbCMoneda = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.actxaCImporte = New ACControles.ACTextBoxNumerico()
      Me.txtCDetalle = New System.Windows.Forms.TextBox()
      Me.dtpCFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.acpnlTitulo = New ACControles.ACPanelCaption()
      Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
      Me.actsbtnPagar = New ACControles.ACToolStripButton(Me.components)
      Me.tabMantenimiento.SuspendLayout()
      Me.tabDatos.SuspendLayout()
      Me.pnlDatos.SuspendLayout()
      Me.tabBusqueda.SuspendLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavBusqueda.SuspendLayout()
      Me.grpBusqueda.SuspendLayout()
      Me.tabPagos.SuspendLayout()
      Me.Panel1.SuspendLayout()
      CType(Me.c1grdPagos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ToolStrip1.SuspendLayout()
      CType(Me.bnavPagos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavPagos.SuspendLayout()
      Me.Panel2.SuspendLayout()
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
      Me.tabMantenimiento.SelectedIndex = 1
      Me.tabMantenimiento.ShowDropSelect = False
      Me.tabMantenimiento.Size = New System.Drawing.Size(728, 384)
      Me.tabMantenimiento.TabIndex = 12
      Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos, Me.tabBusqueda, Me.tabPagos})
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
      Me.tabDatos.Selected = False
      Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
      Me.tabDatos.Size = New System.Drawing.Size(726, 359)
      Me.tabDatos.TabIndex = 4
      Me.tabDatos.Title = "Datos"
      Me.tabDatos.ToolTip = "Datos"
      '
      'pnlDatos
      '
      Me.pnlDatos.Controls.Add(Me.lblMoneda)
      Me.pnlDatos.Controls.Add(Me.cmbMoneda)
      Me.pnlDatos.Controls.Add(Me.lblTotalPagar)
      Me.pnlDatos.Controls.Add(Me.actxnImporte)
      Me.pnlDatos.Controls.Add(Me.txtDetalles)
      Me.pnlDatos.Controls.Add(Me.dtpFecha)
      Me.pnlDatos.Controls.Add(Me.Label3)
      Me.pnlDatos.Controls.Add(Me.btnNuevoCliente)
      Me.pnlDatos.Controls.Add(Me.btnClean)
      Me.pnlDatos.Controls.Add(Me.actxaRazonSocial)
      Me.pnlDatos.Controls.Add(Me.actxaDocumento)
      Me.pnlDatos.Controls.Add(Me.lblNroDocumento)
      Me.pnlDatos.Controls.Add(Me.Label1)
      Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
      Me.pnlDatos.Name = "pnlDatos"
      Me.pnlDatos.Size = New System.Drawing.Size(726, 359)
      Me.pnlDatos.TabIndex = 1
      '
      'lblMoneda
      '
      Me.lblMoneda.AutoSize = True
      Me.lblMoneda.Location = New System.Drawing.Point(59, 156)
      Me.lblMoneda.Name = "lblMoneda"
      Me.lblMoneda.Size = New System.Drawing.Size(57, 15)
      Me.lblMoneda.TabIndex = 9
      Me.lblMoneda.Text = "&Moneda :"
      '
      'cmbMoneda
      '
      Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMoneda.DropDownWidth = 250
      Me.cmbMoneda.FormattingEnabled = True
      Me.cmbMoneda.Location = New System.Drawing.Point(123, 152)
      Me.cmbMoneda.Name = "cmbMoneda"
      Me.cmbMoneda.Size = New System.Drawing.Size(66, 23)
      Me.cmbMoneda.TabIndex = 10
      Me.cmbMoneda.Tag = "EO"
      '
      'lblTotalPagar
      '
      Me.lblTotalPagar.AutoSize = True
      Me.lblTotalPagar.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
      Me.lblTotalPagar.Location = New System.Drawing.Point(52, 186)
      Me.lblTotalPagar.Name = "lblTotalPagar"
      Me.lblTotalPagar.Size = New System.Drawing.Size(65, 17)
      Me.lblTotalPagar.TabIndex = 11
      Me.lblTotalPagar.Text = "Importe :"
      '
      'actxnImporte
      '
      Me.actxnImporte.ACEnteros = 9
      Me.actxnImporte.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnImporte.ACNegativo = True
      Me.actxnImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
      Me.actxnImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.actxnImporte.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
      Me.actxnImporte.Location = New System.Drawing.Point(123, 181)
      Me.actxnImporte.MaxLength = 12
      Me.actxnImporte.Name = "actxnImporte"
      Me.actxnImporte.ReadOnly = True
      Me.actxnImporte.Size = New System.Drawing.Size(122, 26)
      Me.actxnImporte.TabIndex = 12
      Me.actxnImporte.Tag = "EVO"
      Me.actxnImporte.Text = "0.00"
      Me.actxnImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDetalles
      '
      Me.txtDetalles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtDetalles.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtDetalles.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDetalles.Location = New System.Drawing.Point(123, 107)
      Me.txtDetalles.Multiline = True
      Me.txtDetalles.Name = "txtDetalles"
      Me.txtDetalles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtDetalles.Size = New System.Drawing.Size(555, 39)
      Me.txtDetalles.TabIndex = 8
      Me.txtDetalles.Tag = "EV"
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(123, 78)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(122, 23)
      Me.dtpFecha.TabIndex = 6
      Me.dtpFecha.Tag = "E"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(73, 82)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(44, 15)
      Me.Label3.TabIndex = 5
      Me.Label3.Text = "Fecha :"
      '
      'btnNuevoCliente
      '
      Me.btnNuevoCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnNuevoCliente.Image = Global.ACPTransportes.My.Resources.Resources.Nuevo_16x16
      Me.btnNuevoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnNuevoCliente.Location = New System.Drawing.Point(632, 48)
      Me.btnNuevoCliente.Name = "btnNuevoCliente"
      Me.btnNuevoCliente.Size = New System.Drawing.Size(25, 25)
      Me.btnNuevoCliente.TabIndex = 3
      Me.btnNuevoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnNuevoCliente.UseVisualStyleBackColor = True
      '
      'btnClean
      '
      Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClean.Image = Global.ACPTransportes.My.Resources.Resources.Delete_16x16
      Me.btnClean.Location = New System.Drawing.Point(656, 48)
      Me.btnClean.Name = "btnClean"
      Me.btnClean.Size = New System.Drawing.Size(25, 25)
      Me.btnClean.TabIndex = 4
      Me.btnClean.UseVisualStyleBackColor = True
      '
      'actxaRazonSocial
      '
      Me.actxaRazonSocial.ACActivarAyudaAuto = False
      Me.actxaRazonSocial.ACLongitudAceptada = 0
      Me.actxaRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxaRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.actxaRazonSocial.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxaRazonSocial.Location = New System.Drawing.Point(265, 48)
      Me.actxaRazonSocial.MaxLength = 32767
      Me.actxaRazonSocial.Name = "actxaRazonSocial"
      Me.actxaRazonSocial.Size = New System.Drawing.Size(358, 24)
      Me.actxaRazonSocial.TabIndex = 2
      Me.actxaRazonSocial.Tag = "EV"
      '
      'actxaDocumento
      '
      Me.actxaDocumento.ACActivarAyudaAuto = False
      Me.actxaDocumento.ACLongitudAceptada = 0
      Me.actxaDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.actxaDocumento.Location = New System.Drawing.Point(123, 49)
      Me.actxaDocumento.MaxLength = 32767
      Me.actxaDocumento.Name = "actxaDocumento"
      Me.actxaDocumento.Size = New System.Drawing.Size(122, 23)
      Me.actxaDocumento.TabIndex = 1
      Me.actxaDocumento.Tag = "EVO"
      '
      'lblNroDocumento
      '
      Me.lblNroDocumento.AutoSize = True
      Me.lblNroDocumento.Location = New System.Drawing.Point(68, 107)
      Me.lblNroDocumento.Name = "lblNroDocumento"
      Me.lblNroDocumento.Size = New System.Drawing.Size(49, 15)
      Me.lblNroDocumento.TabIndex = 7
      Me.lblNroDocumento.Text = "Detalle :"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(38, 53)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(79, 15)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Responsable :"
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
      Me.tabBusqueda.Size = New System.Drawing.Size(726, 359)
      Me.tabBusqueda.TabIndex = 5
      Me.tabBusqueda.Title = "Busqueda"
      Me.tabBusqueda.ToolTip = "Busqueda"
      '
      'c1grdBusqueda
      '
      Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 68)
      Me.c1grdBusqueda.Name = "c1grdBusqueda"
      Me.c1grdBusqueda.Rows.Count = 2
      Me.c1grdBusqueda.Rows.DefaultSize = 20
      Me.c1grdBusqueda.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
      Me.c1grdBusqueda.Size = New System.Drawing.Size(726, 266)
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
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 334)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(726, 25)
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
      Me.grpBusqueda.Controls.Add(Me.chkTodos)
      Me.grpBusqueda.Controls.Add(Me.btnCConsultar)
      Me.grpBusqueda.Controls.Add(Me.AcFecha)
      Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
      Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
      Me.grpBusqueda.Name = "grpBusqueda"
      Me.grpBusqueda.Size = New System.Drawing.Size(726, 68)
      Me.grpBusqueda.TabIndex = 1
      Me.grpBusqueda.TabStop = False
      Me.grpBusqueda.Text = "Opciones de Busqueda"
      '
      'chkTodos
      '
      Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkTodos.AutoSize = True
      Me.chkTodos.Location = New System.Drawing.Point(617, 47)
      Me.chkTodos.Name = "chkTodos"
      Me.chkTodos.Size = New System.Drawing.Size(103, 19)
      Me.chkTodos.TabIndex = 33
      Me.chkTodos.Text = "Mostrar Todos"
      Me.chkTodos.UseVisualStyleBackColor = True
      '
      'btnCConsultar
      '
      Me.btnCConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.btnCConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
      Me.btnCConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCConsultar.Location = New System.Drawing.Point(283, 14)
      Me.btnCConsultar.Name = "btnCConsultar"
      Me.btnCConsultar.Size = New System.Drawing.Size(99, 42)
      Me.btnCConsultar.TabIndex = 32
      Me.btnCConsultar.Text = "Consultar"
      Me.btnCConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCConsultar.UseVisualStyleBackColor = True
      '
      'AcFecha
      '
      Me.AcFecha.ACFecha_A = Nothing
      Me.AcFecha.ACFecha_De = Nothing
      Me.AcFecha.ACFechaChecked = False
      Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
      Me.AcFecha.ACHoyChecked = False
      Me.AcFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.AcFecha.Location = New System.Drawing.Point(389, 0)
      Me.AcFecha.MaximumSize = New System.Drawing.Size(337, 43)
      Me.AcFecha.MinimumSize = New System.Drawing.Size(337, 43)
      Me.AcFecha.Name = "AcFecha"
      Me.AcFecha.Size = New System.Drawing.Size(337, 43)
      Me.AcFecha.TabIndex = 26
      Me.AcFecha.TabStop = False
      '
      'txtBusqueda
      '
      Me.txtBusqueda.ACActivarAyudaAuto = False
      Me.txtBusqueda.ACLongitudAceptada = 0
      Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBusqueda.Location = New System.Drawing.Point(6, 25)
      Me.txtBusqueda.MaxLength = 32767
      Me.txtBusqueda.Name = "txtBusqueda"
      Me.txtBusqueda.Size = New System.Drawing.Size(271, 23)
      Me.txtBusqueda.TabIndex = 0
      '
      'tabPagos
      '
      Me.tabPagos.Controls.Add(Me.Panel1)
      Me.tabPagos.Controls.Add(Me.Panel2)
      Me.tabPagos.InactiveBackColor = System.Drawing.Color.Empty
      Me.tabPagos.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tabPagos.InactiveTextColor = System.Drawing.Color.Empty
      Me.tabPagos.Location = New System.Drawing.Point(1, 1)
      Me.tabPagos.Name = "tabPagos"
      Me.tabPagos.SelectBackColor = System.Drawing.Color.Empty
      Me.tabPagos.Selected = False
      Me.tabPagos.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tabPagos.SelectTextColor = System.Drawing.Color.Empty
      Me.tabPagos.Size = New System.Drawing.Size(726, 359)
      Me.tabPagos.TabIndex = 6
      Me.tabPagos.Title = "Pagos"
      Me.tabPagos.ToolTip = "Pagos"
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.c1grdPagos)
      Me.Panel1.Controls.Add(Me.ToolStrip1)
      Me.Panel1.Controls.Add(Me.bnavPagos)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel1.Location = New System.Drawing.Point(0, 111)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(726, 248)
      Me.Panel1.TabIndex = 13
      '
      'c1grdPagos
      '
      Me.c1grdPagos.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdPagos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdPagos.Location = New System.Drawing.Point(0, 25)
      Me.c1grdPagos.Name = "c1grdPagos"
      Me.c1grdPagos.Rows.Count = 2
      Me.c1grdPagos.Rows.DefaultSize = 20
      Me.c1grdPagos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
      Me.c1grdPagos.Size = New System.Drawing.Size(726, 198)
      Me.c1grdPagos.StyleInfo = resources.GetString("c1grdPagos.StyleInfo")
      Me.c1grdPagos.TabIndex = 4
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAgregar, Me.ToolStripSeparator4, Me.tsbtnQuitar})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(726, 25)
      Me.ToolStrip1.TabIndex = 6
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'tsbtnAgregar
      '
      Me.tsbtnAgregar.Image = CType(resources.GetObject("tsbtnAgregar.Image"), System.Drawing.Image)
      Me.tsbtnAgregar.Name = "tsbtnAgregar"
      Me.tsbtnAgregar.RightToLeftAutoMirrorImage = True
      Me.tsbtnAgregar.Size = New System.Drawing.Size(69, 22)
      Me.tsbtnAgregar.Text = "Agregar"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
      '
      'tsbtnQuitar
      '
      Me.tsbtnQuitar.Image = CType(resources.GetObject("tsbtnQuitar.Image"), System.Drawing.Image)
      Me.tsbtnQuitar.Name = "tsbtnQuitar"
      Me.tsbtnQuitar.RightToLeftAutoMirrorImage = True
      Me.tsbtnQuitar.Size = New System.Drawing.Size(60, 22)
      Me.tsbtnQuitar.Text = "Quitar"
      '
      'bnavPagos
      '
      Me.bnavPagos.AddNewItem = Me.ToolStripButton1
      Me.bnavPagos.CountItem = Me.ToolStripLabel1
      Me.bnavPagos.DeleteItem = Me.ToolStripButton2
      Me.bnavPagos.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavPagos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2, Me.tstxtTotal, Me.ToolStripLabel2})
      Me.bnavPagos.Location = New System.Drawing.Point(0, 223)
      Me.bnavPagos.MoveFirstItem = Me.ToolStripButton3
      Me.bnavPagos.MoveLastItem = Me.ToolStripButton6
      Me.bnavPagos.MoveNextItem = Me.ToolStripButton5
      Me.bnavPagos.MovePreviousItem = Me.ToolStripButton4
      Me.bnavPagos.Name = "bnavPagos"
      Me.bnavPagos.PositionItem = Me.ToolStripTextBox1
      Me.bnavPagos.Size = New System.Drawing.Size(726, 25)
      Me.bnavPagos.TabIndex = 5
      Me.bnavPagos.Text = "BindingNavigator1"
      '
      'ToolStripButton1
      '
      Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
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
      Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
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
      'tstxtTotal
      '
      Me.tstxtTotal.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.tstxtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.tstxtTotal.Name = "tstxtTotal"
      Me.tstxtTotal.ReadOnly = True
      Me.tstxtTotal.Size = New System.Drawing.Size(120, 25)
      '
      'ToolStripLabel2
      '
      Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripLabel2.Name = "ToolStripLabel2"
      Me.ToolStripLabel2.Size = New System.Drawing.Size(40, 22)
      Me.ToolStripLabel2.Text = "Total :"
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.txtRazSocialUsuario)
      Me.Panel2.Controls.Add(Me.txtDocUsuario)
      Me.Panel2.Controls.Add(Me.Label2)
      Me.Panel2.Controls.Add(Me.cmbCMoneda)
      Me.Panel2.Controls.Add(Me.Label4)
      Me.Panel2.Controls.Add(Me.actxaCImporte)
      Me.Panel2.Controls.Add(Me.txtCDetalle)
      Me.Panel2.Controls.Add(Me.dtpCFecha)
      Me.Panel2.Controls.Add(Me.Label6)
      Me.Panel2.Controls.Add(Me.Label7)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel2.Location = New System.Drawing.Point(0, 0)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(726, 111)
      Me.Panel2.TabIndex = 14
      '
      'txtRazSocialUsuario
      '
      Me.txtRazSocialUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtRazSocialUsuario.Location = New System.Drawing.Point(252, 5)
      Me.txtRazSocialUsuario.Name = "txtRazSocialUsuario"
      Me.txtRazSocialUsuario.ReadOnly = True
      Me.txtRazSocialUsuario.Size = New System.Drawing.Size(325, 23)
      Me.txtRazSocialUsuario.TabIndex = 14
      '
      'txtDocUsuario
      '
      Me.txtDocUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtDocUsuario.Location = New System.Drawing.Point(124, 5)
      Me.txtDocUsuario.Name = "txtDocUsuario"
      Me.txtDocUsuario.ReadOnly = True
      Me.txtDocUsuario.Size = New System.Drawing.Size(122, 23)
      Me.txtDocUsuario.TabIndex = 13
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(60, 83)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(57, 15)
      Me.Label2.TabIndex = 9
      Me.Label2.Text = "&Moneda :"
      '
      'cmbCMoneda
      '
      Me.cmbCMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCMoneda.DropDownWidth = 250
      Me.cmbCMoneda.Enabled = False
      Me.cmbCMoneda.FormattingEnabled = True
      Me.cmbCMoneda.Location = New System.Drawing.Point(124, 79)
      Me.cmbCMoneda.Name = "cmbCMoneda"
      Me.cmbCMoneda.Size = New System.Drawing.Size(122, 23)
      Me.cmbCMoneda.TabIndex = 10
      Me.cmbCMoneda.Tag = "EO"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
      Me.Label4.Location = New System.Drawing.Point(486, 83)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(65, 17)
      Me.Label4.TabIndex = 11
      Me.Label4.Text = "Importe :"
      '
      'actxaCImporte
      '
      Me.actxaCImporte.ACEnteros = 9
      Me.actxaCImporte.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxaCImporte.ACNegativo = True
      Me.actxaCImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
      Me.actxaCImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.actxaCImporte.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
      Me.actxaCImporte.Location = New System.Drawing.Point(557, 78)
      Me.actxaCImporte.MaxLength = 12
      Me.actxaCImporte.Name = "actxaCImporte"
      Me.actxaCImporte.ReadOnly = True
      Me.actxaCImporte.Size = New System.Drawing.Size(122, 26)
      Me.actxaCImporte.TabIndex = 12
      Me.actxaCImporte.Tag = "EVO"
      Me.actxaCImporte.Text = "0.00"
      Me.actxaCImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCDetalle
      '
      Me.txtCDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtCDetalle.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCDetalle.Location = New System.Drawing.Point(124, 34)
      Me.txtCDetalle.Multiline = True
      Me.txtCDetalle.Name = "txtCDetalle"
      Me.txtCDetalle.ReadOnly = True
      Me.txtCDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtCDetalle.Size = New System.Drawing.Size(555, 39)
      Me.txtCDetalle.TabIndex = 8
      Me.txtCDetalle.Tag = "EV"
      '
      'dtpCFecha
      '
      Me.dtpCFecha.Enabled = False
      Me.dtpCFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpCFecha.Location = New System.Drawing.Point(583, 5)
      Me.dtpCFecha.Name = "dtpCFecha"
      Me.dtpCFecha.Size = New System.Drawing.Size(96, 23)
      Me.dtpCFecha.TabIndex = 6
      Me.dtpCFecha.Tag = "E"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(69, 34)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(49, 15)
      Me.Label6.TabIndex = 7
      Me.Label6.Text = "Detalle :"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(38, 8)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(79, 15)
      Me.Label7.TabIndex = 0
      Me.Label7.Text = "Responsable :"
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Ingreso de Gastos de Caja Chica"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(728, 30)
      Me.acpnlTitulo.TabIndex = 11
      '
      'acTool
      '
      Me.acTool.ACBtnAnularEnabled = False
      Me.acTool.ACBtnAnularVisible = False
      Me.acTool.ACBtnBuscarEnabled = False
      Me.acTool.ACBtnBuscarVisible = False
      Me.acTool.ACBtnCancelarEnabled = False
      Me.acTool.ACBtnCancelarVisible = False
      Me.acTool.ACBtnGrabarEnabled = False
      Me.acTool.ACBtnGrabarVisible = False
      Me.acTool.ACBtnImprimirEnabled = False
      Me.acTool.ACBtnImprimirVisible = False
      Me.acTool.ACBtnRehusarEnabled = False
      Me.acTool.ACBtnRehusarVisible = False
      Me.acTool.ACBtnReporteEnabled = False
      Me.acTool.ACBtnReporteVisible = False
      Me.acTool.ACBtnSalirEnabled = False
      Me.acTool.ACBtnSalirText = "&Salir"
      Me.acTool.ACBtnSalirVisible = False
      Me.acTool.ACBtnVolverEnabled = False
      Me.acTool.ACBtnVolverVisible = False
      Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
      Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
      Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.actsbtnPagar})
      Me.acTool.Location = New System.Drawing.Point(0, 414)
      Me.acTool.Name = "acTool"
      Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.acTool.Size = New System.Drawing.Size(728, 56)
      Me.acTool.TabIndex = 13
      Me.acTool.Text = "AcToolBarMantHorizontalNew1"
      '
      'actsbtnPagar
      '
      Me.actsbtnPagar.AutoSize = False
      Me.actsbtnPagar.Image = Global.ACPTransportes.My.Resources.Resources.EMoney_32x32
      Me.actsbtnPagar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.actsbtnPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.actsbtnPagar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.actsbtnPagar.Name = "tsbBoton"
      Me.actsbtnPagar.Size = New System.Drawing.Size(75, 53)
      Me.actsbtnPagar.Text = "Pagar"
      Me.actsbtnPagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.actsbtnPagar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.actsbtnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      '
      'PIngGasCajaChica
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(728, 470)
      Me.Controls.Add(Me.tabMantenimiento)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Controls.Add(Me.acTool)
      Me.Name = "PIngGasCajaChica"
      Me.Text = "Ingreso de Gastos de Caja Chica"
      Me.tabMantenimiento.ResumeLayout(False)
      Me.tabDatos.ResumeLayout(False)
      Me.pnlDatos.ResumeLayout(False)
      Me.pnlDatos.PerformLayout()
      Me.tabBusqueda.ResumeLayout(False)
      Me.tabBusqueda.PerformLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavBusqueda.ResumeLayout(False)
      Me.bnavBusqueda.PerformLayout()
      Me.grpBusqueda.ResumeLayout(False)
      Me.grpBusqueda.PerformLayout()
      Me.tabPagos.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.c1grdPagos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      CType(Me.bnavPagos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavPagos.ResumeLayout(False)
      Me.bnavPagos.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.acTool.ResumeLayout(False)
      Me.acTool.PerformLayout()
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
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents btnCConsultar As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents btnNuevoCliente As System.Windows.Forms.Button
   Friend WithEvents btnClean As System.Windows.Forms.Button
   Friend WithEvents actxaRazonSocial As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaDocumento As ACControles.ACTextBoxAyuda
   Friend WithEvents lblNroDocumento As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtDetalles As System.Windows.Forms.TextBox
   Friend WithEvents actxnImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents lblTotalPagar As System.Windows.Forms.Label
   Friend WithEvents lblMoneda As System.Windows.Forms.Label
   Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents tabPagos As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents c1grdPagos As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbtnAgregar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbtnQuitar As System.Windows.Forms.ToolStripButton
   Friend WithEvents bnavPagos As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents tstxtTotal As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents txtRazSocialUsuario As System.Windows.Forms.TextBox
   Friend WithEvents txtDocUsuario As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmbCMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents actxaCImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents txtCDetalle As System.Windows.Forms.TextBox
   Friend WithEvents dtpCFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents actsbtnPagar As ACControles.ACToolStripButton
End Class
