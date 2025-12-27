<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MAdministracionUsuarios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MAdministracionUsuarios))
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.grpBusqueda = New System.Windows.Forms.GroupBox()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bnavPuntoVenta = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem2 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem2 = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem2 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem2 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem2 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem2 = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem2 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem2 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
        Me.bnavUsuarios = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAgregar = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnQuitar = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption2 = New ACControles.ACPanelCaption()
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.c1grdPuntoVenta = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.c1grdUsuarios = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grpBusqueda.SuspendLayout()
        CType(Me.bnavPuntoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavPuntoVenta.SuspendLayout()
        CType(Me.bnavUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavUsuarios.SuspendLayout()
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.tabBusqueda.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.c1grdPuntoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1grdUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Mantenimiento de Usuarios Transportes"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(727, 30)
        Me.acpnlTitulo.TabIndex = 12
        '
        'grpBusqueda
        '
        Me.grpBusqueda.Controls.Add(Me.cmbZona)
        Me.grpBusqueda.Controls.Add(Me.Label2)
        Me.grpBusqueda.Controls.Add(Me.cmbSucursal)
        Me.grpBusqueda.Controls.Add(Me.Label1)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(725, 72)
        Me.grpBusqueda.TabIndex = 1
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'cmbZona
        '
        Me.cmbZona.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(97, 16)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(617, 23)
        Me.cmbZona.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Zona :"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(97, 43)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(617, 23)
        Me.cmbSucursal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal :"
        '
        'bnavPuntoVenta
        '
        Me.bnavPuntoVenta.AddNewItem = Me.BindingNavigatorAddNewItem2
        Me.bnavPuntoVenta.CountItem = Me.BindingNavigatorCountItem2
        Me.bnavPuntoVenta.DeleteItem = Me.BindingNavigatorDeleteItem2
        Me.bnavPuntoVenta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem2, Me.BindingNavigatorMovePreviousItem2, Me.BindingNavigatorSeparator6, Me.BindingNavigatorPositionItem2, Me.BindingNavigatorCountItem2, Me.BindingNavigatorSeparator7, Me.BindingNavigatorMoveNextItem2, Me.BindingNavigatorMoveLastItem2, Me.BindingNavigatorSeparator8, Me.BindingNavigatorAddNewItem2, Me.BindingNavigatorDeleteItem2})
        Me.bnavPuntoVenta.Location = New System.Drawing.Point(0, 30)
        Me.bnavPuntoVenta.MoveFirstItem = Me.BindingNavigatorMoveFirstItem2
        Me.bnavPuntoVenta.MoveLastItem = Me.BindingNavigatorMoveLastItem2
        Me.bnavPuntoVenta.MoveNextItem = Me.BindingNavigatorMoveNextItem2
        Me.bnavPuntoVenta.MovePreviousItem = Me.BindingNavigatorMovePreviousItem2
        Me.bnavPuntoVenta.Name = "bnavPuntoVenta"
        Me.bnavPuntoVenta.PositionItem = Me.BindingNavigatorPositionItem2
        Me.bnavPuntoVenta.Size = New System.Drawing.Size(725, 25)
        Me.bnavPuntoVenta.TabIndex = 3
        Me.bnavPuntoVenta.Text = "BindingNavigator2"
        '
        'BindingNavigatorAddNewItem2
        '
        Me.BindingNavigatorAddNewItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem2.Image = CType(resources.GetObject("BindingNavigatorAddNewItem2.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem2.Name = "BindingNavigatorAddNewItem2"
        Me.BindingNavigatorAddNewItem2.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem2.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem2.Text = "Add new"
        Me.BindingNavigatorAddNewItem2.Visible = False
        '
        'BindingNavigatorCountItem2
        '
        Me.BindingNavigatorCountItem2.Name = "BindingNavigatorCountItem2"
        Me.BindingNavigatorCountItem2.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem2.Text = "de {0}"
        Me.BindingNavigatorCountItem2.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem2
        '
        Me.BindingNavigatorDeleteItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem2.Image = CType(resources.GetObject("BindingNavigatorDeleteItem2.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem2.Name = "BindingNavigatorDeleteItem2"
        Me.BindingNavigatorDeleteItem2.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem2.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem2.Text = "Delete"
        Me.BindingNavigatorDeleteItem2.Visible = False
        '
        'BindingNavigatorMoveFirstItem2
        '
        Me.BindingNavigatorMoveFirstItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem2.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem2.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem2.Name = "BindingNavigatorMoveFirstItem2"
        Me.BindingNavigatorMoveFirstItem2.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem2.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem2.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem2
        '
        Me.BindingNavigatorMovePreviousItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem2.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem2.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem2.Name = "BindingNavigatorMovePreviousItem2"
        Me.BindingNavigatorMovePreviousItem2.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem2.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem2.Text = "Move previous"
        '
        'BindingNavigatorSeparator6
        '
        Me.BindingNavigatorSeparator6.Name = "BindingNavigatorSeparator6"
        Me.BindingNavigatorSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem2
        '
        Me.BindingNavigatorPositionItem2.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem2.AutoSize = False
        Me.BindingNavigatorPositionItem2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem2.Name = "BindingNavigatorPositionItem2"
        Me.BindingNavigatorPositionItem2.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem2.Text = "0"
        Me.BindingNavigatorPositionItem2.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator7
        '
        Me.BindingNavigatorSeparator7.Name = "BindingNavigatorSeparator7"
        Me.BindingNavigatorSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem2
        '
        Me.BindingNavigatorMoveNextItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem2.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem2.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem2.Name = "BindingNavigatorMoveNextItem2"
        Me.BindingNavigatorMoveNextItem2.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem2.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem2.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem2
        '
        Me.BindingNavigatorMoveLastItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem2.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem2.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem2.Name = "BindingNavigatorMoveLastItem2"
        Me.BindingNavigatorMoveLastItem2.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem2.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem2.Text = "Move last"
        '
        'BindingNavigatorSeparator8
        '
        Me.BindingNavigatorSeparator8.Name = "BindingNavigatorSeparator8"
        Me.BindingNavigatorSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption1
        '
        Me.AcPanelCaption1.ACCaption = "Punto de Venta"
        Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption1.Name = "AcPanelCaption1"
        Me.AcPanelCaption1.Size = New System.Drawing.Size(725, 30)
        Me.AcPanelCaption1.TabIndex = 11
        '
        'bnavUsuarios
        '
        Me.bnavUsuarios.AddNewItem = Nothing
        Me.bnavUsuarios.CountItem = Me.BindingNavigatorCountItem1
        Me.bnavUsuarios.DeleteItem = Nothing
        Me.bnavUsuarios.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem1, Me.BindingNavigatorMovePreviousItem1, Me.BindingNavigatorSeparator3, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.BindingNavigatorSeparator4, Me.BindingNavigatorMoveNextItem1, Me.BindingNavigatorMoveLastItem1, Me.BindingNavigatorSeparator5, Me.tsbtnAgregar, Me.tsbtnQuitar})
        Me.bnavUsuarios.Location = New System.Drawing.Point(0, 30)
        Me.bnavUsuarios.MoveFirstItem = Me.BindingNavigatorMoveFirstItem1
        Me.bnavUsuarios.MoveLastItem = Me.BindingNavigatorMoveLastItem1
        Me.bnavUsuarios.MoveNextItem = Me.BindingNavigatorMoveNextItem1
        Me.bnavUsuarios.MovePreviousItem = Me.BindingNavigatorMovePreviousItem1
        Me.bnavUsuarios.Name = "bnavUsuarios"
        Me.bnavUsuarios.PositionItem = Me.BindingNavigatorPositionItem1
        Me.bnavUsuarios.Size = New System.Drawing.Size(725, 25)
        Me.bnavUsuarios.TabIndex = 4
        Me.bnavUsuarios.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem1"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem1.Text = "de {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem1
        '
        Me.BindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem1.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem1.Name = "BindingNavigatorMoveFirstItem1"
        Me.BindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem1.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem1
        '
        Me.BindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem1.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem1.Name = "BindingNavigatorMovePreviousItem1"
        Me.BindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem1.Text = "Move previous"
        '
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem1
        '
        Me.BindingNavigatorPositionItem1.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem1.AutoSize = False
        Me.BindingNavigatorPositionItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem1.Name = "BindingNavigatorPositionItem1"
        Me.BindingNavigatorPositionItem1.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem1.Text = "0"
        Me.BindingNavigatorPositionItem1.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem1
        '
        Me.BindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem1.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem1.Name = "BindingNavigatorMoveNextItem1"
        Me.BindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem1.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem1
        '
        Me.BindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem1.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem1.Name = "BindingNavigatorMoveLastItem1"
        Me.BindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem1.Text = "Move last"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator5"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnAgregar
        '
        Me.tsbtnAgregar.Image = CType(resources.GetObject("tsbtnAgregar.Image"), System.Drawing.Image)
        Me.tsbtnAgregar.Name = "tsbtnAgregar"
        Me.tsbtnAgregar.RightToLeftAutoMirrorImage = True
        Me.tsbtnAgregar.Size = New System.Drawing.Size(112, 22)
        Me.tsbtnAgregar.Text = "Agregar Usuario"
        '
        'tsbtnQuitar
        '
        Me.tsbtnQuitar.Image = CType(resources.GetObject("tsbtnQuitar.Image"), System.Drawing.Image)
        Me.tsbtnQuitar.Name = "tsbtnQuitar"
        Me.tsbtnQuitar.RightToLeftAutoMirrorImage = True
        Me.tsbtnQuitar.Size = New System.Drawing.Size(103, 22)
        Me.tsbtnQuitar.Text = "Quitar Usuario"
        '
        'AcPanelCaption2
        '
        Me.AcPanelCaption2.ACCaption = "Usuarios"
        Me.AcPanelCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption2.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption2.Name = "AcPanelCaption2"
        Me.AcPanelCaption2.Size = New System.Drawing.Size(725, 30)
        Me.AcPanelCaption2.TabIndex = 11
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
        Me.tabMantenimiento.Size = New System.Drawing.Size(727, 528)
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
        Me.tabDatos.Selected = False
        Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Size = New System.Drawing.Size(725, 503)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDatos
        '
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(725, 503)
        Me.pnlDatos.TabIndex = 1
        '
        'tabBusqueda
        '
        Me.tabBusqueda.Controls.Add(Me.SplitContainer1)
        Me.tabBusqueda.Controls.Add(Me.grpBusqueda)
        Me.tabBusqueda.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Location = New System.Drawing.Point(1, 1)
        Me.tabBusqueda.Name = "tabBusqueda"
        Me.tabBusqueda.SelectBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Size = New System.Drawing.Size(725, 503)
        Me.tabBusqueda.TabIndex = 5
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 72)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.c1grdPuntoVenta)
        Me.SplitContainer1.Panel1.Controls.Add(Me.bnavPuntoVenta)
        Me.SplitContainer1.Panel1.Controls.Add(Me.AcPanelCaption1)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.c1grdUsuarios)
        Me.SplitContainer1.Panel2.Controls.Add(Me.bnavUsuarios)
        Me.SplitContainer1.Panel2.Controls.Add(Me.AcPanelCaption2)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 431)
        Me.SplitContainer1.SplitterDistance = 208
        Me.SplitContainer1.TabIndex = 4
        '
        'c1grdPuntoVenta
        '
        Me.c1grdPuntoVenta.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdPuntoVenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdPuntoVenta.Location = New System.Drawing.Point(0, 55)
        Me.c1grdPuntoVenta.Name = "c1grdPuntoVenta"
        Me.c1grdPuntoVenta.Rows.Count = 2
        Me.c1grdPuntoVenta.Rows.DefaultSize = 20
        Me.c1grdPuntoVenta.Size = New System.Drawing.Size(725, 153)
        Me.c1grdPuntoVenta.StyleInfo = resources.GetString("c1grdPuntoVenta.StyleInfo")
        Me.c1grdPuntoVenta.TabIndex = 2
        '
        'c1grdUsuarios
        '
        Me.c1grdUsuarios.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdUsuarios.Location = New System.Drawing.Point(0, 55)
        Me.c1grdUsuarios.Name = "c1grdUsuarios"
        Me.c1grdUsuarios.Rows.Count = 2
        Me.c1grdUsuarios.Rows.DefaultSize = 20
        Me.c1grdUsuarios.Size = New System.Drawing.Size(725, 164)
        Me.c1grdUsuarios.StyleInfo = resources.GetString("c1grdUsuarios.StyleInfo")
        Me.c1grdUsuarios.TabIndex = 3
        '
        'MAdministracionUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 558)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Name = "MAdministracionUsuarios"
        Me.Text = "MAdministracionUsuarios"
        Me.grpBusqueda.ResumeLayout(False)
        Me.grpBusqueda.PerformLayout()
        CType(Me.bnavPuntoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavPuntoVenta.ResumeLayout(False)
        Me.bnavPuntoVenta.PerformLayout()
        CType(Me.bnavUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavUsuarios.ResumeLayout(False)
        Me.bnavUsuarios.PerformLayout()
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.tabBusqueda.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.c1grdPuntoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1grdUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
    Private WithEvents grpBusqueda As GroupBox
    Friend WithEvents cmbZona As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbSucursal As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bnavPuntoVenta As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem2 As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem2 As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem2 As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem2 As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem2 As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator6 As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem2 As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator7 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem2 As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem2 As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator8 As ToolStripSeparator
    Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
    Friend WithEvents bnavUsuarios As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem1 As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem1 As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem1 As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem1 As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator4 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem1 As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem1 As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator5 As ToolStripSeparator
    Friend WithEvents tsbtnAgregar As ToolStripButton
    Friend WithEvents tsbtnQuitar As ToolStripButton
    Friend WithEvents AcPanelCaption2 As ACControles.ACPanelCaption
    Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
    Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents pnlDatos As Panel
    Private WithEvents tabBusqueda As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents c1grdPuntoVenta As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents c1grdUsuarios As C1.Win.C1FlexGrid.C1FlexGrid
End Class
