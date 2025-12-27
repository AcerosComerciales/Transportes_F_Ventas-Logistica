<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPagosPendientes
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FPagosPendientes))
        Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage
        Me.c1grdPagosPendientes = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.acpnlTitulo = New ACControles.ACPanelCaption
        Me.bnavBusqueda = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.grpBusqueda = New System.Windows.Forms.GroupBox
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl
        Me.acTool = New ACControles.ACToolBarMantHorizontal
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.AcTextBoxNumerico2 = New ACControles.ACTextBoxNumerico
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.AcTextBoxNumerico1 = New ACControles.ACTextBoxNumerico
        Me.Label10 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.AcTextBoxNumerico3 = New ACControles.ACTextBoxNumerico
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.tabBusqueda.SuspendLayout()
        CType(Me.c1grdPagosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavBusqueda.SuspendLayout()
        Me.grpBusqueda.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabMantenimiento.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabBusqueda
        '
        Me.tabBusqueda.Controls.Add(Me.c1grdPagosPendientes)
        Me.tabBusqueda.Controls.Add(Me.acpnlTitulo)
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
        Me.tabBusqueda.Size = New System.Drawing.Size(686, 322)
        Me.tabBusqueda.TabIndex = 5
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'c1grdPagosPendientes
        '
        Me.c1grdPagosPendientes.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdPagosPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdPagosPendientes.Location = New System.Drawing.Point(0, 81)
        Me.c1grdPagosPendientes.Name = "c1grdPagosPendientes"
        Me.c1grdPagosPendientes.Rows.Count = 2
        Me.c1grdPagosPendientes.Rows.DefaultSize = 18
        Me.c1grdPagosPendientes.Size = New System.Drawing.Size(686, 216)
        Me.c1grdPagosPendientes.StyleInfo = resources.GetString("c1grdPagosPendientes.StyleInfo")
        Me.c1grdPagosPendientes.TabIndex = 13
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Búsqueda Pagos Pendientes"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 51)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(686, 30)
        Me.acpnlTitulo.TabIndex = 15
        '
        'bnavBusqueda
        '
        Me.bnavBusqueda.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.bnavBusqueda.CountItem = Me.BindingNavigatorCountItem
        Me.bnavBusqueda.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 297)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(686, 25)
        Me.bnavBusqueda.TabIndex = 14
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
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
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
        Me.grpBusqueda.Size = New System.Drawing.Size(686, 51)
        Me.grpBusqueda.TabIndex = 12
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'txtBusqueda
        '
        Me.txtBusqueda.ACActivarAyudaAuto = False
        Me.txtBusqueda.ACLongitudAceptada = 0
        Me.txtBusqueda.ACRellenaCeros = False
        Me.txtBusqueda.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
        Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda.Location = New System.Drawing.Point(17, 20)
        Me.txtBusqueda.MaxLength = 32767
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(658, 21)
        Me.txtBusqueda.TabIndex = 0
        '
        'tabDatos
        '
        Me.tabDatos.Controls.Add(Me.GroupBox2)
        Me.tabDatos.Controls.Add(Me.GroupBox1)
        Me.tabDatos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Location = New System.Drawing.Point(1, 1)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Size = New System.Drawing.Size(686, 322)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AcTextBoxNumerico3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.AcTextBoxNumerico1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(686, 108)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento Pago"
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 0)
        Me.tabMantenimiento.MediaPlayerDockSides = False
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = False
        Me.tabMantenimiento.SelectedIndex = 1
        Me.tabMantenimiento.ShowDropSelect = False
        Me.tabMantenimiento.Size = New System.Drawing.Size(688, 347)
        Me.tabMantenimiento.TabIndex = 11
        Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabBusqueda, Me.tabDatos})
        Me.tabMantenimiento.TextTips = True
        '
        'acTool
        '
        Me.acTool.ACTipoBoton = ACControles.ACToolBarMantHorizontal.TipoBoton.Eliminar
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontal.tipoToolBar.ToolNuevoGrabarAnularBuscarRehusar
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Location = New System.Drawing.Point(0, 347)
        Me.acTool.MinimumSize = New System.Drawing.Size(495, 60)
        Me.acTool.Name = "acTool"
        Me.acTool.RehusarAnchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.acTool.RehusarImage = Global.ACPTransportes.My.Resources.Resources.ACReporte_32x32
        Me.acTool.RehusarLocation = New System.Drawing.Point(320, 2)
        Me.acTool.RehusarSize = New System.Drawing.Size(79, 53)
        Me.acTool.RehusaText = "Ver Detalle"
        Me.acTool.Size = New System.Drawing.Size(688, 60)
        Me.acTool.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker4)
        Me.GroupBox2.Controls.Add(Me.ComboBox3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.AcTextBoxNumerico2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(686, 214)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Registro de Pago"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Documento Referencia"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(131, 128)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(201, 21)
        Me.TextBox1.TabIndex = 42
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Fecha Pago Parcial"
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Location = New System.Drawing.Point(131, 101)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(201, 21)
        Me.DateTimePicker4.TabIndex = 40
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(131, 47)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(201, 21)
        Me.ComboBox3.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Tipo Pago"
        '
        'AcTextBoxNumerico2
        '
        Me.AcTextBoxNumerico2.ACDecimales = 2
        Me.AcTextBoxNumerico2.ACEnteros = 8
        Me.AcTextBoxNumerico2.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
        Me.AcTextBoxNumerico2.ACFormato = "#######0.00"
        Me.AcTextBoxNumerico2.ACNegativo = True
        Me.AcTextBoxNumerico2.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.AcTextBoxNumerico2.Location = New System.Drawing.Point(131, 74)
        Me.AcTextBoxNumerico2.MaxLength = 12
        Me.AcTextBoxNumerico2.Name = "AcTextBoxNumerico2"
        Me.AcTextBoxNumerico2.Size = New System.Drawing.Size(99, 21)
        Me.AcTextBoxNumerico2.TabIndex = 37
        Me.AcTextBoxNumerico2.Text = "0"
        Me.AcTextBoxNumerico2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Monto"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(131, 20)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(201, 21)
        Me.ComboBox2.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Tipo Moneda"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Tipo Documento"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(131, 14)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(201, 21)
        Me.ComboBox1.TabIndex = 36
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(343, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Nro Documento"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(430, 14)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(201, 21)
        Me.TextBox2.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Fecha Documento"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(131, 41)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(201, 21)
        Me.DateTimePicker1.TabIndex = 44
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(343, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Valor Total"
        '
        'AcTextBoxNumerico1
        '
        Me.AcTextBoxNumerico1.ACDecimales = 2
        Me.AcTextBoxNumerico1.ACEnteros = 8
        Me.AcTextBoxNumerico1.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
        Me.AcTextBoxNumerico1.ACFormato = "#######0.00"
        Me.AcTextBoxNumerico1.ACNegativo = True
        Me.AcTextBoxNumerico1.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.AcTextBoxNumerico1.Location = New System.Drawing.Point(430, 41)
        Me.AcTextBoxNumerico1.MaxLength = 12
        Me.AcTextBoxNumerico1.Name = "AcTextBoxNumerico1"
        Me.AcTextBoxNumerico1.ReadOnly = True
        Me.AcTextBoxNumerico1.Size = New System.Drawing.Size(99, 21)
        Me.AcTextBoxNumerico1.TabIndex = 47
        Me.AcTextBoxNumerico1.Text = "0"
        Me.AcTextBoxNumerico1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 13)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Fecha Pago Acordado"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(131, 68)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(201, 21)
        Me.DateTimePicker2.TabIndex = 48
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(343, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Saldo del Pago"
        '
        'AcTextBoxNumerico3
        '
        Me.AcTextBoxNumerico3.ACDecimales = 2
        Me.AcTextBoxNumerico3.ACEnteros = 8
        Me.AcTextBoxNumerico3.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
        Me.AcTextBoxNumerico3.ACFormato = "#######0.00"
        Me.AcTextBoxNumerico3.ACNegativo = True
        Me.AcTextBoxNumerico3.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.AcTextBoxNumerico3.Location = New System.Drawing.Point(430, 68)
        Me.AcTextBoxNumerico3.MaxLength = 12
        Me.AcTextBoxNumerico3.Name = "AcTextBoxNumerico3"
        Me.AcTextBoxNumerico3.ReadOnly = True
        Me.AcTextBoxNumerico3.Size = New System.Drawing.Size(99, 21)
        Me.AcTextBoxNumerico3.TabIndex = 51
        Me.AcTextBoxNumerico3.Text = "0"
        Me.AcTextBoxNumerico3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 158)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Descripcion"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(131, 155)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(500, 21)
        Me.TextBox3.TabIndex = 45
        '
        'FPagosPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 407)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acTool)
        Me.Name = "FPagosPendientes"
        Me.Text = "FPagosPendientes"
        Me.tabBusqueda.ResumeLayout(False)
        Me.tabBusqueda.PerformLayout()
        CType(Me.c1grdPagosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavBusqueda.ResumeLayout(False)
        Me.bnavBusqueda.PerformLayout()
        Me.grpBusqueda.ResumeLayout(False)
        Me.grpBusqueda.PerformLayout()
        Me.tabDatos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabMantenimiento.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents acTool As ACControles.ACToolBarMantHorizontal
    Private WithEvents tabBusqueda As Crownwood.DotNetMagic.Controls.TabPage
    Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
    Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
    Friend WithEvents c1grdPagosPendientes As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents AcTextBoxNumerico2 As ACControles.ACTextBoxNumerico
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AcTextBoxNumerico3 As ACControles.ACTextBoxNumerico
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents AcTextBoxNumerico1 As ACControles.ACTextBoxNumerico
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
