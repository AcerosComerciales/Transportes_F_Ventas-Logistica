<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TRecibos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TRecibos))
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.cmbPendiente = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.cmbSerie = New System.Windows.Forms.ComboBox()
        Me.actxnNumero = New ACControles.ACTextBoxNumerico()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.actxnMonto = New ACControles.ACTextBoxNumerico()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoRecibo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtRecibi = New System.Windows.Forms.TextBox()
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
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.actool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
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
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 30)
        Me.tabMantenimiento.MediaPlayerDockSides = False
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = False
        Me.tabMantenimiento.SelectedIndex = 0
        Me.tabMantenimiento.ShowDropSelect = False
        Me.tabMantenimiento.Size = New System.Drawing.Size(593, 337)
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
        Me.tabDatos.Size = New System.Drawing.Size(591, 312)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.Label11)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.txtDireccion)
        Me.pnlDatos.Controls.Add(Me.cmbPendiente)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.txtDNI)
        Me.pnlDatos.Controls.Add(Me.cmbSerie)
        Me.pnlDatos.Controls.Add(Me.actxnNumero)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.Label6)
        Me.pnlDatos.Controls.Add(Me.txtConcepto)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.actxnMonto)
        Me.pnlDatos.Controls.Add(Me.Label7)
        Me.pnlDatos.Controls.Add(Me.cmbTipoMoneda)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.dtpFecha)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.cmbTipoRecibo)
        Me.pnlDatos.Controls.Add(Me.Label14)
        Me.pnlDatos.Controls.Add(Me.txtRecibi)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(591, 312)
        Me.pnlDatos.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(43, 237)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 15)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Nombre :"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(106, 233)
        Me.txtNombre.MaxLength = 80
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(474, 23)
        Me.txtNombre.TabIndex = 19
        Me.txtNombre.Tag = "VO"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 266)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 15)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Dirección :"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(106, 262)
        Me.txtDireccion.MaxLength = 100
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(474, 23)
        Me.txtDireccion.TabIndex = 21
        Me.txtDireccion.Tag = "VO"
        '
        'cmbPendiente
        '
        Me.cmbPendiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPendiente.FormattingEnabled = True
        Me.cmbPendiente.Location = New System.Drawing.Point(106, 7)
        Me.cmbPendiente.Name = "cmbPendiente"
        Me.cmbPendiente.Size = New System.Drawing.Size(474, 23)
        Me.cmbPendiente.TabIndex = 1
        Me.cmbPendiente.Tag = "EO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(34, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Pendiente :"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 295)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 15)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Numero D.N.I. :"
        '
        'txtDNI
        '
        Me.txtDNI.Location = New System.Drawing.Point(106, 291)
        Me.txtDNI.MaxLength = 14
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(100, 23)
        Me.txtDNI.TabIndex = 23
        Me.txtDNI.Tag = "VO"
        '
        'cmbSerie
        '
        Me.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSerie.FormattingEnabled = True
        Me.cmbSerie.Location = New System.Drawing.Point(106, 62)
        Me.cmbSerie.Name = "cmbSerie"
        Me.cmbSerie.Size = New System.Drawing.Size(65, 23)
        Me.cmbSerie.TabIndex = 5
        Me.cmbSerie.Tag = "EO"
        '
        'actxnNumero
        '
        Me.actxnNumero.ACEnteros = 8
        Me.actxnNumero.ACFormato = "#######0"
        Me.actxnNumero.ACNegativo = True
        Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnNumero.Location = New System.Drawing.Point(258, 62)
        Me.actxnNumero.MaxLength = 7
        Me.actxnNumero.Name = "actxnNumero"
        Me.actxnNumero.Size = New System.Drawing.Size(127, 23)
        Me.actxnNumero.TabIndex = 7
        Me.actxnNumero.Tag = "EVO"
        Me.actxnNumero.Text = "0"
        Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(197, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Numero :"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(62, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Serie :"
        '
        'txtConcepto
        '
        Me.txtConcepto.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConcepto.Location = New System.Drawing.Point(106, 131)
        Me.txtConcepto.MaxLength = 200
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConcepto.Size = New System.Drawing.Size(475, 40)
        Me.txtConcepto.TabIndex = 11
        Me.txtConcepto.Tag = "VO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Concepto :"
        '
        'actxnMonto
        '
        Me.actxnMonto.ACEnteros = 9
        Me.actxnMonto.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnMonto.ACFormato = "########0.00"
        Me.actxnMonto.ACNegativo = True
        Me.actxnMonto.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnMonto.Location = New System.Drawing.Point(106, 177)
        Me.actxnMonto.MaxLength = 12
        Me.actxnMonto.Name = "actxnMonto"
        Me.actxnMonto.Size = New System.Drawing.Size(99, 23)
        Me.actxnMonto.TabIndex = 13
        Me.actxnMonto.Tag = "VO"
        Me.actxnMonto.Text = "0.00"
        Me.actxnMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(51, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Monto :"
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(303, 177)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(277, 23)
        Me.cmbTipoMoneda.TabIndex = 15
        Me.cmbTipoMoneda.Tag = "O"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(211, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Tipo Moneda :"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(106, 204)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(100, 23)
        Me.dtpFecha.TabIndex = 17
        Me.dtpFecha.Tag = "VO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Fecha :"
        '
        'cmbTipoRecibo
        '
        Me.cmbTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoRecibo.FormattingEnabled = True
        Me.cmbTipoRecibo.Location = New System.Drawing.Point(106, 35)
        Me.cmbTipoRecibo.Name = "cmbTipoRecibo"
        Me.cmbTipoRecibo.Size = New System.Drawing.Size(280, 23)
        Me.cmbTipoRecibo.TabIndex = 3
        Me.cmbTipoRecibo.Tag = "ECO"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(24, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 15)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Tipo Recibo :"
        '
        'txtRecibi
        '
        Me.txtRecibi.Location = New System.Drawing.Point(106, 89)
        Me.txtRecibi.MaxLength = 100
        Me.txtRecibi.Multiline = True
        Me.txtRecibi.Name = "txtRecibi"
        Me.txtRecibi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRecibi.Size = New System.Drawing.Size(475, 36)
        Me.txtRecibi.TabIndex = 9
        Me.txtRecibi.Tag = "VO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Recibi de :"
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
        Me.tabBusqueda.Size = New System.Drawing.Size(591, 312)
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
        Me.c1grdBusqueda.Size = New System.Drawing.Size(591, 236)
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
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 287)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(591, 25)
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
        Me.grpBusqueda.Size = New System.Drawing.Size(591, 51)
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
        Me.txtBusqueda.Size = New System.Drawing.Size(563, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Recibos"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(593, 30)
        Me.acpnlTitulo.TabIndex = 12
        '
        'actool
        '
        Me.actool.ACBtnAnularEnabled = False
        Me.actool.ACBtnAnularVisible = False
        Me.actool.ACBtnBuscarEnabled = False
        Me.actool.ACBtnBuscarVisible = False
        Me.actool.ACBtnCancelarEnabled = False
        Me.actool.ACBtnCancelarVisible = False
        Me.actool.ACBtnGrabarEnabled = False
        Me.actool.ACBtnGrabarVisible = False
        Me.actool.ACBtnImprimirEnabled = False
        Me.actool.ACBtnImprimirVisible = False
        Me.actool.ACBtnRehusarEnabled = False
        Me.actool.ACBtnRehusarVisible = False
        Me.actool.ACBtnReporteEnabled = False
        Me.actool.ACBtnReporteVisible = False
        Me.actool.ACBtnSalirText = "&Salir"
        Me.actool.ACBtnVolverEnabled = False
        Me.actool.ACBtnVolverVisible = False
        Me.actool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.actool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.actool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.actool.Location = New System.Drawing.Point(0, 367)
        Me.actool.Name = "actool"
        Me.actool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.actool.Size = New System.Drawing.Size(593, 56)
        Me.actool.TabIndex = 14
        Me.actool.Text = "AcToolBarMantHorizontalNew1"
        '
        'TRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(593, 423)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Controls.Add(Me.actool)
        Me.KeyPreview = True
        Me.Name = "TRecibos"
        Me.Text = "Recibos"
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
   Friend WithEvents actool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents cmbTipoRecibo As System.Windows.Forms.ComboBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents txtRecibi As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents actxnMonto As ACControles.ACTextBoxNumerico
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmbSerie As System.Windows.Forms.ComboBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents txtDNI As System.Windows.Forms.TextBox
   Friend WithEvents cmbPendiente As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents txtNombre As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
End Class
