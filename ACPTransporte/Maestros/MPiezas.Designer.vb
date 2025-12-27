<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPiezas
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPiezas))
      Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
      Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.pnlDatos = New System.Windows.Forms.Panel()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.PictureBox1 = New System.Windows.Forms.PictureBox()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.btnDirecctorio = New System.Windows.Forms.Button()
      Me.txtPathGenerador = New System.Windows.Forms.TextBox()
      Me.txtMarca = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtDescripcion = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtCodigo = New System.Windows.Forms.TextBox()
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
      Me.acTool = New ACControles.ACToolBarMantVertical()
      Me.acpnlTitulo = New ACControles.ACPanelCaption()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cmbClasificacion = New System.Windows.Forms.ComboBox()
      Me.tabMantenimiento.SuspendLayout()
      Me.tabDatos.SuspendLayout()
      Me.pnlDatos.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
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
      Me.tabMantenimiento.Location = New System.Drawing.Point(90, 30)
      Me.tabMantenimiento.MediaPlayerDockSides = False
      Me.tabMantenimiento.Name = "tabMantenimiento"
      Me.tabMantenimiento.OfficeDockSides = False
      Me.tabMantenimiento.SelectedIndex = 0
      Me.tabMantenimiento.ShowDropSelect = False
      Me.tabMantenimiento.Size = New System.Drawing.Size(700, 307)
      Me.tabMantenimiento.TabIndex = 9
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
      Me.tabDatos.Size = New System.Drawing.Size(698, 282)
      Me.tabDatos.TabIndex = 4
      Me.tabDatos.Title = "Datos"
      Me.tabDatos.ToolTip = "Datos"
      '
      'pnlDatos
      '
      Me.pnlDatos.Controls.Add(Me.cmbClasificacion)
      Me.pnlDatos.Controls.Add(Me.Label4)
      Me.pnlDatos.Controls.Add(Me.GroupBox1)
      Me.pnlDatos.Controls.Add(Me.txtMarca)
      Me.pnlDatos.Controls.Add(Me.Label3)
      Me.pnlDatos.Controls.Add(Me.txtDescripcion)
      Me.pnlDatos.Controls.Add(Me.Label2)
      Me.pnlDatos.Controls.Add(Me.txtCodigo)
      Me.pnlDatos.Controls.Add(Me.Label1)
      Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
      Me.pnlDatos.Name = "pnlDatos"
      Me.pnlDatos.Size = New System.Drawing.Size(698, 282)
      Me.pnlDatos.TabIndex = 1
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.PictureBox1)
      Me.GroupBox1.Controls.Add(Me.Panel1)
      Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
      Me.GroupBox1.Location = New System.Drawing.Point(416, 0)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(282, 282)
      Me.GroupBox1.TabIndex = 12
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Imagen"
      '
      'PictureBox1
      '
      Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.PictureBox1.Location = New System.Drawing.Point(3, 52)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(276, 227)
      Me.PictureBox1.TabIndex = 16
      Me.PictureBox1.TabStop = False
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.btnDirecctorio)
      Me.Panel1.Controls.Add(Me.txtPathGenerador)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(3, 19)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(276, 33)
      Me.Panel1.TabIndex = 0
      '
      'btnDirecctorio
      '
      Me.btnDirecctorio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnDirecctorio.Enabled = False
      Me.btnDirecctorio.Image = Global.ACPTransportes.My.Resources.Resources.folderadd_16x16
      Me.btnDirecctorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnDirecctorio.Location = New System.Drawing.Point(235, 5)
      Me.btnDirecctorio.Name = "btnDirecctorio"
      Me.btnDirecctorio.Size = New System.Drawing.Size(25, 22)
      Me.btnDirecctorio.TabIndex = 1
      Me.btnDirecctorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnDirecctorio.UseVisualStyleBackColor = True
      '
      'txtPathGenerador
      '
      Me.txtPathGenerador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPathGenerador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtPathGenerador.Enabled = False
      Me.txtPathGenerador.Location = New System.Drawing.Point(15, 5)
      Me.txtPathGenerador.Name = "txtPathGenerador"
      Me.txtPathGenerador.Size = New System.Drawing.Size(245, 23)
      Me.txtPathGenerador.TabIndex = 0
      Me.txtPathGenerador.Tag = "C"
      '
      'txtMarca
      '
      Me.txtMarca.Location = New System.Drawing.Point(88, 143)
      Me.txtMarca.MaxLength = 30
      Me.txtMarca.Name = "txtMarca"
      Me.txtMarca.Size = New System.Drawing.Size(322, 23)
      Me.txtMarca.TabIndex = 5
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(37, 147)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(46, 15)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Marca :"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.Location = New System.Drawing.Point(88, 48)
      Me.txtDescripcion.MaxLength = 120
      Me.txtDescripcion.Multiline = True
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtDescripcion.Size = New System.Drawing.Size(322, 89)
      Me.txtDescripcion.TabIndex = 3
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(8, 52)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(75, 15)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Descripción :"
      '
      'txtCodigo
      '
      Me.txtCodigo.Location = New System.Drawing.Point(88, 19)
      Me.txtCodigo.MaxLength = 20
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(100, 23)
      Me.txtCodigo.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(31, 23)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(52, 15)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Codigo :"
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
      Me.tabBusqueda.Size = New System.Drawing.Size(698, 282)
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
      Me.c1grdBusqueda.Size = New System.Drawing.Size(698, 206)
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
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 257)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(698, 25)
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
      Me.grpBusqueda.Size = New System.Drawing.Size(698, 51)
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
      Me.txtBusqueda.Size = New System.Drawing.Size(670, 23)
      Me.txtBusqueda.TabIndex = 0
      '
      'acTool
      '
      Me.acTool.ACBackColor = System.Drawing.Color.LightSteelBlue
      Me.acTool.ACBackColorTFin = System.Drawing.Color.LightSteelBlue
      Me.acTool.ACBackColorTIni = System.Drawing.Color.LightSteelBlue
      Me.acTool.ACMostrarTabs = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
      Me.acTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabIni
      Me.acTool.BackColor = System.Drawing.Color.LightSteelBlue
      Me.acTool.Dock = System.Windows.Forms.DockStyle.Left
      Me.acTool.Location = New System.Drawing.Point(0, 30)
      Me.acTool.MinimumSize = New System.Drawing.Size(90, 254)
      Me.acTool.Name = "acTool"
      Me.acTool.Size = New System.Drawing.Size(90, 307)
      Me.acTool.TabIndex = 8
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Mantenimiento de Piezas"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(790, 30)
      Me.acpnlTitulo.TabIndex = 10
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(3, 176)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(80, 15)
      Me.Label4.TabIndex = 13
      Me.Label4.Text = "Clasificación :"
      '
      'cmbClasificacion
      '
      Me.cmbClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbClasificacion.FormattingEnabled = True
      Me.cmbClasificacion.Location = New System.Drawing.Point(90, 173)
      Me.cmbClasificacion.Name = "cmbClasificacion"
      Me.cmbClasificacion.Size = New System.Drawing.Size(320, 23)
      Me.cmbClasificacion.TabIndex = 14
      '
      'MPiezas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(790, 337)
      Me.Controls.Add(Me.tabMantenimiento)
      Me.Controls.Add(Me.acTool)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Name = "MPiezas"
      Me.Text = "MPiezas"
      Me.tabMantenimiento.ResumeLayout(False)
      Me.tabDatos.ResumeLayout(False)
      Me.pnlDatos.ResumeLayout(False)
      Me.pnlDatos.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents pnlDatos As System.Windows.Forms.Panel
   Friend WithEvents txtMarca As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
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
   Private WithEvents acTool As ACControles.ACToolBarMantVertical
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Private WithEvents btnDirecctorio As System.Windows.Forms.Button
   Private WithEvents txtPathGenerador As System.Windows.Forms.TextBox
   Friend WithEvents cmbClasificacion As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
