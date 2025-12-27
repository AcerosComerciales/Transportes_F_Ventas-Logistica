<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MUbigeos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MUbigeos))
      Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl
      Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage
      Me.pnlDatos = New System.Windows.Forms.Panel
      Me.txtCodigo = New System.Windows.Forms.MaskedTextBox
      Me.txtDescCorta = New System.Windows.Forms.TextBox
      Me.txtDescripcion = New System.Windows.Forms.TextBox
      Me.actxaCodPadre = New ACControles.ACTextBoxAyuda
      Me.txtUbigeoPadre = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label5 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
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
      Me.RadioButton1 = New System.Windows.Forms.RadioButton
      Me.txtBusqueda = New ACControles.ACTextBoxAyuda
      Me.acTool = New ACControles.ACToolBarMantVertical
      Me.acpnlTitulo = New ACControles.ACPanelCaption
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
      Me.tabMantenimiento.Location = New System.Drawing.Point(90, 30)
      Me.tabMantenimiento.MediaPlayerDockSides = False
      Me.tabMantenimiento.Name = "tabMantenimiento"
      Me.tabMantenimiento.OfficeDockSides = False
      Me.tabMantenimiento.SelectedIndex = 0
      Me.tabMantenimiento.ShowDropSelect = False
      Me.tabMantenimiento.Size = New System.Drawing.Size(392, 259)
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
      Me.tabDatos.Size = New System.Drawing.Size(390, 234)
      Me.tabDatos.TabIndex = 4
      Me.tabDatos.Title = "Datos"
      Me.tabDatos.ToolTip = "Datos"
      '
      'pnlDatos
      '
      Me.pnlDatos.Controls.Add(Me.txtCodigo)
      Me.pnlDatos.Controls.Add(Me.txtDescCorta)
      Me.pnlDatos.Controls.Add(Me.txtDescripcion)
      Me.pnlDatos.Controls.Add(Me.actxaCodPadre)
      Me.pnlDatos.Controls.Add(Me.txtUbigeoPadre)
      Me.pnlDatos.Controls.Add(Me.Label1)
      Me.pnlDatos.Controls.Add(Me.Label2)
      Me.pnlDatos.Controls.Add(Me.Label5)
      Me.pnlDatos.Controls.Add(Me.Label4)
      Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
      Me.pnlDatos.Name = "pnlDatos"
      Me.pnlDatos.Size = New System.Drawing.Size(390, 234)
      Me.pnlDatos.TabIndex = 1
      '
      'txtCodigo
      '
      Me.txtCodigo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodigo.Location = New System.Drawing.Point(101, 45)
      Me.txtCodigo.Mask = "00.00.00"
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(105, 20)
      Me.txtCodigo.TabIndex = 2
      Me.txtCodigo.Tag = "EVO"
      '
      'txtDescCorta
      '
      Me.txtDescCorta.Location = New System.Drawing.Point(101, 98)
      Me.txtDescCorta.MaxLength = 10
      Me.txtDescCorta.Name = "txtDescCorta"
      Me.txtDescCorta.Size = New System.Drawing.Size(261, 21)
      Me.txtDescCorta.TabIndex = 4
      Me.txtDescCorta.Tag = "EV"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.Location = New System.Drawing.Point(101, 71)
      Me.txtDescripcion.MaxLength = 50
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(261, 21)
      Me.txtDescripcion.TabIndex = 3
      Me.txtDescripcion.Tag = "EVO"
      '
      'actxaCodPadre
      '
      Me.actxaCodPadre.ACActivarAyudaAuto = False
      Me.actxaCodPadre.ACLongitudAceptada = 0
      Me.actxaCodPadre.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaCodPadre.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.actxaCodPadre.Location = New System.Drawing.Point(101, 19)
      Me.actxaCodPadre.MaxLength = 4
      Me.actxaCodPadre.Name = "actxaCodPadre"
      Me.actxaCodPadre.Size = New System.Drawing.Size(105, 20)
      Me.actxaCodPadre.TabIndex = 0
      Me.actxaCodPadre.Tag = "EV"
      '
      'txtUbigeoPadre
      '
      Me.txtUbigeoPadre.Location = New System.Drawing.Point(212, 18)
      Me.txtUbigeoPadre.Name = "txtUbigeoPadre"
      Me.txtUbigeoPadre.ReadOnly = True
      Me.txtUbigeoPadre.Size = New System.Drawing.Size(150, 21)
      Me.txtUbigeoPadre.TabIndex = 1
      Me.txtUbigeoPadre.Tag = "EV"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(23, 103)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(71, 13)
      Me.Label1.TabIndex = 7
      Me.Label1.Text = "Desc. Corta :"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(26, 76)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(68, 13)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "Descripción :"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(17, 24)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(78, 13)
      Me.Label5.TabIndex = 0
      Me.Label5.Text = "Codigo Padre :"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(48, 48)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(47, 13)
      Me.Label4.TabIndex = 3
      Me.Label4.Text = "Codigo :"
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
      Me.tabBusqueda.Size = New System.Drawing.Size(390, 234)
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
      Me.c1grdBusqueda.Size = New System.Drawing.Size(390, 158)
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
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 209)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(390, 25)
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
      Me.grpBusqueda.Controls.Add(Me.RadioButton1)
      Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
      Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
      Me.grpBusqueda.Name = "grpBusqueda"
      Me.grpBusqueda.Size = New System.Drawing.Size(390, 51)
      Me.grpBusqueda.TabIndex = 1
      Me.grpBusqueda.TabStop = False
      Me.grpBusqueda.Text = "Opciones de Busqueda"
      '
      'RadioButton1
      '
      Me.RadioButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.RadioButton1.AutoSize = True
      Me.RadioButton1.Checked = True
      Me.RadioButton1.Location = New System.Drawing.Point(300, 22)
      Me.RadioButton1.Name = "RadioButton1"
      Me.RadioButton1.Size = New System.Drawing.Size(79, 17)
      Me.RadioButton1.TabIndex = 2
      Me.RadioButton1.TabStop = True
      Me.RadioButton1.Text = "Descripción"
      Me.RadioButton1.UseVisualStyleBackColor = True
      '
      'txtBusqueda
      '
      Me.txtBusqueda.ACActivarAyudaAuto = False
      Me.txtBusqueda.ACLongitudAceptada = 0
      Me.txtBusqueda.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBusqueda.Location = New System.Drawing.Point(17, 20)
      Me.txtBusqueda.MaxLength = 32767
      Me.txtBusqueda.Name = "txtBusqueda"
      Me.txtBusqueda.Size = New System.Drawing.Size(277, 21)
      Me.txtBusqueda.TabIndex = 0
      '
      'acTool
      '
      Me.acTool.ACBackColor = System.Drawing.Color.LightSteelBlue
      Me.acTool.ACBackColorTFin = System.Drawing.Color.LightSteelBlue
      Me.acTool.ACBackColorTIni = System.Drawing.Color.LightSteelBlue
      Me.acTool.ACMostrarTabs = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
      Me.acTool.ACSelectTabInicio = ACControles.ACToolBarMantVertical.Tabs.TabIni
      Me.acTool.ACVisibleBtnAnular = False
      Me.acTool.BackColor = System.Drawing.Color.LightSteelBlue
      Me.acTool.Dock = System.Windows.Forms.DockStyle.Left
      Me.acTool.Location = New System.Drawing.Point(0, 30)
      Me.acTool.MinimumSize = New System.Drawing.Size(90, 254)
      Me.acTool.Name = "acTool"
      Me.acTool.Size = New System.Drawing.Size(90, 259)
      Me.acTool.TabIndex = 9
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Mantenimiento de Ubigeos"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(482, 30)
      Me.acpnlTitulo.TabIndex = 8
      '
      'MUbigeos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(482, 289)
      Me.Controls.Add(Me.tabMantenimiento)
      Me.Controls.Add(Me.acTool)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "MUbigeos"
      Me.Text = "Mantenimiento de Ubigeos"
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

   End Sub
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Private WithEvents acTool As ACControles.ACToolBarMantVertical
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
   Friend WithEvents actxaCodPadre As ACControles.ACTextBoxAyuda
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtDescCorta As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtUbigeoPadre As System.Windows.Forms.TextBox
   Friend WithEvents txtCodigo As System.Windows.Forms.MaskedTextBox
   Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
