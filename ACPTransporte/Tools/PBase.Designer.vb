<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PBase
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PBase))
      Me.acpnlTitulo = New ACControles.ACPanelCaption
      Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl
      Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage
      Me.pnlDatos = New System.Windows.Forms.Panel
      Me.TabControl1 = New Crownwood.DotNetMagic.Controls.TabControl
      Me.TabPage1 = New Crownwood.DotNetMagic.Controls.TabPage
      Me.TabPage2 = New Crownwood.DotNetMagic.Controls.TabPage
      Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage
      Me.c1grdBusqueda = New C1.Win.C1FlexGrid.C1FlexGrid
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
      Me.acTool = New ACControles.ACToolBarMantHorizontal
      Me.tool = New System.Windows.Forms.ToolStrip
      Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
      Me.AcToolBarMantHorizontalNew1 = New ACControles.ACToolBarMantHorizontalNew(Me.components)
      Me.tabMantenimiento.SuspendLayout()
      Me.tabDatos.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.tabBusqueda.SuspendLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavBusqueda.SuspendLayout()
      Me.grpBusqueda.SuspendLayout()
      Me.tool.SuspendLayout()
      Me.SuspendLayout()
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "<Nombre>"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(523, 30)
      Me.acpnlTitulo.TabIndex = 8
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
      Me.tabMantenimiento.Size = New System.Drawing.Size(523, 249)
      Me.tabMantenimiento.TabIndex = 10
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
      Me.tabDatos.Size = New System.Drawing.Size(521, 224)
      Me.tabDatos.TabIndex = 4
      Me.tabDatos.Title = "Datos"
      Me.tabDatos.ToolTip = "Datos"
      '
      'pnlDatos
      '
      Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
      Me.pnlDatos.Name = "pnlDatos"
      Me.pnlDatos.Size = New System.Drawing.Size(521, 224)
      Me.pnlDatos.TabIndex = 1
      '
      'TabControl1
      '
      Me.TabControl1.BackColor = System.Drawing.Color.LightSteelBlue
      Me.TabControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.TabControl1.Location = New System.Drawing.Point(273, 297)
      Me.TabControl1.MediaPlayerDockSides = False
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.OfficeDockSides = False
      Me.TabControl1.PositionTop = True
      Me.TabControl1.SelectedIndex = 1
      Me.TabControl1.ShowDropSelect = False
      Me.TabControl1.Size = New System.Drawing.Size(373, 177)
      Me.TabControl1.TabIndex = 11
      Me.TabControl1.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.TabPage1, Me.TabPage2})
      Me.TabControl1.TextTips = True
      '
      'TabPage1
      '
      Me.TabPage1.InactiveBackColor = System.Drawing.Color.Empty
      Me.TabPage1.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.TabPage1.InactiveTextColor = System.Drawing.Color.Empty
      Me.TabPage1.Location = New System.Drawing.Point(1, 24)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.SelectBackColor = System.Drawing.Color.Empty
      Me.TabPage1.Selected = False
      Me.TabPage1.SelectTextBackColor = System.Drawing.Color.Empty
      Me.TabPage1.SelectTextColor = System.Drawing.Color.Empty
      Me.TabPage1.Size = New System.Drawing.Size(371, 152)
      Me.TabPage1.TabIndex = 4
      Me.TabPage1.Title = "Datos"
      Me.TabPage1.ToolTip = "Datos"
      '
      'TabPage2
      '
      Me.TabPage2.InactiveBackColor = System.Drawing.Color.Empty
      Me.TabPage2.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.TabPage2.InactiveTextColor = System.Drawing.Color.Empty
      Me.TabPage2.Location = New System.Drawing.Point(1, 24)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.SelectBackColor = System.Drawing.Color.Empty
      Me.TabPage2.SelectTextBackColor = System.Drawing.Color.Empty
      Me.TabPage2.SelectTextColor = System.Drawing.Color.Empty
      Me.TabPage2.Size = New System.Drawing.Size(371, 152)
      Me.TabPage2.TabIndex = 5
      Me.TabPage2.Title = "Busqueda"
      Me.TabPage2.ToolTip = "Busqueda"
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
      Me.tabBusqueda.Size = New System.Drawing.Size(521, 224)
      Me.tabBusqueda.TabIndex = 5
      Me.tabBusqueda.Title = "Busqueda"
      Me.tabBusqueda.ToolTip = "Busqueda"
      '
      'c1grdBusqueda
      '
      Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 51)
      Me.c1grdBusqueda.Name = "c1grdBusqueda"
      Me.c1grdBusqueda.Rows.Count = 2
      Me.c1grdBusqueda.Rows.DefaultSize = 18
      Me.c1grdBusqueda.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
      Me.c1grdBusqueda.Size = New System.Drawing.Size(521, 148)
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
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 199)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(521, 25)
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
      Me.grpBusqueda.Size = New System.Drawing.Size(521, 51)
      Me.grpBusqueda.TabIndex = 1
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
      Me.txtBusqueda.Size = New System.Drawing.Size(493, 21)
      Me.txtBusqueda.TabIndex = 0
      '
      'acTool
      '
      Me.acTool.ACTipoBoton = ACControles.ACToolBarMantHorizontal.TipoBoton.Eliminar
      Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontal.tipoToolBar.ToolNuevoGrabarEliminar
      Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.acTool.Location = New System.Drawing.Point(0, 279)
      Me.acTool.MinimumSize = New System.Drawing.Size(495, 60)
      Me.acTool.Name = "acTool"
      Me.acTool.RehusarAnchor = System.Windows.Forms.AnchorStyles.Top
      Me.acTool.RehusarImage = CType(resources.GetObject("acTool.RehusarImage"), System.Drawing.Image)
      Me.acTool.RehusarLocation = New System.Drawing.Point(273, 2)
      Me.acTool.RehusarSize = New System.Drawing.Size(79, 53)
      Me.acTool.RehusaText = "Re&husar"
      Me.acTool.Size = New System.Drawing.Size(523, 60)
      Me.acTool.TabIndex = 9
      '
      'tool
      '
      Me.tool.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.tool.Font = New System.Drawing.Font("Tahoma", 9.5!)
      Me.tool.ImageScalingSize = New System.Drawing.Size(32, 32)
      Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripButton2, Me.ToolStripSeparator2, Me.ToolStripButton7, Me.ToolStripSeparator7, Me.ToolStripButton6, Me.ToolStripSeparator6, Me.ToolStripButton5, Me.ToolStripSeparator5, Me.ToolStripButton4, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripSeparator3, Me.ToolStripButton8, Me.ToolStripSeparator8, Me.ToolStripButton9, Me.ToolStripSeparator9, Me.ToolStripButton10, Me.ToolStripSeparator10, Me.ToolStripButton11, Me.ToolStripSeparator11, Me.ToolStripButton12, Me.ToolStripSeparator12})
      Me.tool.Location = New System.Drawing.Point(0, 339)
      Me.tool.Name = "tool"
      Me.tool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.tool.Size = New System.Drawing.Size(523, 56)
      Me.tool.TabIndex = 11
      Me.tool.Text = "ToolStrip1"
      '
      'ToolStripButton1
      '
      Me.ToolStripButton1.AutoSize = False
      Me.ToolStripButton1.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_32x32
      Me.ToolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton1.Name = "ToolStripButton1"
      Me.ToolStripButton1.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton1.Text = "&Nuevo"
      Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 56)
      '
      'ToolStripButton2
      '
      Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripButton2.AutoSize = False
      Me.ToolStripButton2.Image = Global.ACPTransportes.My.Resources.Resources.ACExit_32x32
      Me.ToolStripButton2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton2.Name = "ToolStripButton2"
      Me.ToolStripButton2.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton2.Text = "Salir"
      Me.ToolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 56)
      '
      'ToolStripButton7
      '
      Me.ToolStripButton7.AutoSize = False
      Me.ToolStripButton7.Image = Global.ACPTransportes.My.Resources.Resources.ACReporte_32x32
      Me.ToolStripButton7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton7.Name = "ToolStripButton7"
      Me.ToolStripButton7.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton7.Text = "&Reporte"
      Me.ToolStripButton7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton7.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      Me.ToolStripButton7.Visible = False
      '
      'ToolStripSeparator7
      '
      Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
      Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 56)
      Me.ToolStripSeparator7.Visible = False
      '
      'ToolStripButton6
      '
      Me.ToolStripButton6.AutoSize = False
      Me.ToolStripButton6.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_32x32
      Me.ToolStripButton6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton6.Name = "ToolStripButton6"
      Me.ToolStripButton6.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton6.Text = "&Modificar"
      Me.ToolStripButton6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton6.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      '
      'ToolStripSeparator6
      '
      Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
      Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 56)
      '
      'ToolStripButton5
      '
      Me.ToolStripButton5.AutoSize = False
      Me.ToolStripButton5.Image = Global.ACPTransportes.My.Resources.Resources.ACGrabar_32x32
      Me.ToolStripButton5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton5.Name = "ToolStripButton5"
      Me.ToolStripButton5.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton5.Text = "&Grabar"
      Me.ToolStripButton5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton5.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      Me.ToolStripButton5.Visible = False
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 56)
      Me.ToolStripSeparator5.Visible = False
      '
      'ToolStripButton4
      '
      Me.ToolStripButton4.AutoSize = False
      Me.ToolStripButton4.Image = Global.ACPTransportes.My.Resources.Resources.ACDelete_32x32
      Me.ToolStripButton4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton4.Name = "ToolStripButton4"
      Me.ToolStripButton4.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton4.Text = "&Eliminar"
      Me.ToolStripButton4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton4.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 56)
      '
      'ToolStripButton3
      '
      Me.ToolStripButton3.AutoSize = False
      Me.ToolStripButton3.Image = Global.ACPTransportes.My.Resources.Resources.ACAnular_32x32
      Me.ToolStripButton3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton3.Name = "ToolStripButton3"
      Me.ToolStripButton3.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton3.Text = "&Anular"
      Me.ToolStripButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton3.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      Me.ToolStripButton3.Visible = False
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 56)
      Me.ToolStripSeparator3.Visible = False
      '
      'ToolStripButton8
      '
      Me.ToolStripButton8.AutoSize = False
      Me.ToolStripButton8.Image = Global.ACPTransportes.My.Resources.Resources.ACVolver_32x32
      Me.ToolStripButton8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton8.Name = "ToolStripButton8"
      Me.ToolStripButton8.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton8.Text = "&Volver"
      Me.ToolStripButton8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton8.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      Me.ToolStripButton8.Visible = False
      '
      'ToolStripSeparator8
      '
      Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
      Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 56)
      Me.ToolStripSeparator8.Visible = False
      '
      'ToolStripButton9
      '
      Me.ToolStripButton9.AutoSize = False
      Me.ToolStripButton9.Image = Global.ACPTransportes.My.Resources.Resources.ACCancelar_32x32
      Me.ToolStripButton9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton9.Name = "ToolStripButton9"
      Me.ToolStripButton9.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton9.Text = "&Cancelar"
      Me.ToolStripButton9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton9.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      Me.ToolStripButton9.Visible = False
      '
      'ToolStripSeparator9
      '
      Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
      Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 56)
      Me.ToolStripSeparator9.Visible = False
      '
      'ToolStripButton10
      '
      Me.ToolStripButton10.AutoSize = False
      Me.ToolStripButton10.Image = Global.ACPTransportes.My.Resources.Resources.ACImprimirRed_32x32
      Me.ToolStripButton10.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton10.Name = "ToolStripButton10"
      Me.ToolStripButton10.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton10.Text = "&Imprimir"
      Me.ToolStripButton10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton10.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      Me.ToolStripButton10.Visible = False
      '
      'ToolStripSeparator10
      '
      Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
      Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 56)
      Me.ToolStripSeparator10.Visible = False
      '
      'ToolStripButton11
      '
      Me.ToolStripButton11.AutoSize = False
      Me.ToolStripButton11.Image = Global.ACPTransportes.My.Resources.Resources.ACRehusar_32x32
      Me.ToolStripButton11.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton11.Name = "ToolStripButton11"
      Me.ToolStripButton11.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton11.Text = "&Rehusar"
      Me.ToolStripButton11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton11.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      Me.ToolStripButton11.Visible = False
      '
      'ToolStripSeparator11
      '
      Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
      Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 56)
      Me.ToolStripSeparator11.Visible = False
      '
      'ToolStripButton12
      '
      Me.ToolStripButton12.AutoSize = False
      Me.ToolStripButton12.Image = Global.ACPTransportes.My.Resources.Resources.ACBuscar_32x32
      Me.ToolStripButton12.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.ToolStripButton12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton12.Name = "ToolStripButton12"
      Me.ToolStripButton12.Size = New System.Drawing.Size(75, 53)
      Me.ToolStripButton12.Text = "&Buscar"
      Me.ToolStripButton12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.ToolStripButton12.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.ToolStripButton12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      '
      'ToolStripSeparator12
      '
      Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
      Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 56)
      '
      'AcToolBarMantHorizontalNew1
      '
      Me.AcToolBarMantHorizontalNew1.ACBtnAnularEnabled = False
      Me.AcToolBarMantHorizontalNew1.ACBtnAnularVisible = False
      Me.AcToolBarMantHorizontalNew1.ACBtnBuscarEnabled = False
      Me.AcToolBarMantHorizontalNew1.ACBtnBuscarVisible = False
      Me.AcToolBarMantHorizontalNew1.ACBtnCancelarEnabled = False
      Me.AcToolBarMantHorizontalNew1.ACBtnCancelarVisible = False
      Me.AcToolBarMantHorizontalNew1.ACBtnGrabarEnabled = False
      Me.AcToolBarMantHorizontalNew1.ACBtnGrabarVisible = False
      Me.AcToolBarMantHorizontalNew1.ACBtnRehusarEnabled = False
      Me.AcToolBarMantHorizontalNew1.ACBtnRehusarVisible = False
      Me.AcToolBarMantHorizontalNew1.ACBtnReporteEnabled = False
      Me.AcToolBarMantHorizontalNew1.ACBtnReporteVisible = False
      Me.AcToolBarMantHorizontalNew1.ACBtnVolverEnabled = False
      Me.AcToolBarMantHorizontalNew1.ACBtnVolverVisible = False
      Me.AcToolBarMantHorizontalNew1.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabarEliminar
      Me.AcToolBarMantHorizontalNew1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.AcToolBarMantHorizontalNew1.Font = New System.Drawing.Font("Tahoma", 9.5!)
      Me.AcToolBarMantHorizontalNew1.ImageScalingSize = New System.Drawing.Size(32, 32)
      Me.AcToolBarMantHorizontalNew1.Location = New System.Drawing.Point(0, 395)
      Me.AcToolBarMantHorizontalNew1.Name = "AcToolBarMantHorizontalNew1"
      Me.AcToolBarMantHorizontalNew1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.AcToolBarMantHorizontalNew1.Size = New System.Drawing.Size(523, 56)
      Me.AcToolBarMantHorizontalNew1.TabIndex = 11
      Me.AcToolBarMantHorizontalNew1.Text = "AcToolBarMantHorizontalNew1"
      '
      'PBase
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(523, 451)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.tabMantenimiento)
      Me.Controls.Add(Me.acTool)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Controls.Add(Me.tool)
      Me.Controls.Add(Me.AcToolBarMantHorizontalNew1)
      Me.Name = "PBase"
      Me.Text = "PBase"
      Me.tabMantenimiento.ResumeLayout(False)
      Me.tabDatos.ResumeLayout(False)
      Me.TabControl1.ResumeLayout(False)
      Me.tabBusqueda.ResumeLayout(False)
      Me.tabBusqueda.PerformLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavBusqueda.ResumeLayout(False)
      Me.bnavBusqueda.PerformLayout()
      Me.grpBusqueda.ResumeLayout(False)
      Me.grpBusqueda.PerformLayout()
      Me.tool.ResumeLayout(False)
      Me.tool.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontal
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
   Friend WithEvents tool As System.Windows.Forms.ToolStrip
   Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents AcToolBarMantHorizontalNew1 As ACControles.ACToolBarMantHorizontalNew
   Private WithEvents TabControl1 As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents TabPage1 As Crownwood.DotNetMagic.Controls.TabPage
   Private WithEvents TabPage2 As Crownwood.DotNetMagic.Controls.TabPage
End Class
