<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMovimientoNeumatico
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMovimientoNeumatico))
      Me.pnlDetalle = New System.Windows.Forms.Panel()
      Me.pnlSeleccionados = New System.Windows.Forms.Panel()
      Me.c1grdNeumaticos = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.tsbOpciones = New System.Windows.Forms.ToolStrip()
      Me.tsbtnAgregar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
      Me.bnavNeumaticos = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.pnlNoAsignados = New System.Windows.Forms.Panel()
      Me.c1grdNoAsignados = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.bnavNoAsignados = New System.Windows.Forms.BindingNavigator(Me.components)
      Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
      Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
      Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbtnAsignarNoSeleccionado = New System.Windows.Forms.ToolStripButton()
      Me.tsbtnAsigTodosNoSeleccionado = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton17 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
      Me.AcPanelCaption2 = New ACControles.ACPanelCaption()
      Me.pnlUbicacion = New System.Windows.Forms.Panel()
      Me.grpNuevPosicion = New System.Windows.Forms.GroupBox()
      Me.lblSeccion = New System.Windows.Forms.Label()
      Me.acVehNueva = New ACControles.ACVehiculo()
      Me.cmbSeccion = New System.Windows.Forms.ComboBox()
      Me.txtMotivo = New System.Windows.Forms.TextBox()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.txtGlosa = New System.Windows.Forms.TextBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.txtDestino = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.actxParaDesc = New ACControles.ACTextBoxAyuda()
      Me.actxaPara = New ACControles.ACTextBoxAyuda()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.nupPosicion = New System.Windows.Forms.NumericUpDown()
      Me.chkRepuesto = New System.Windows.Forms.CheckBox()
      Me.lblPosicion = New System.Windows.Forms.Label()
      Me.cmbIntExt = New System.Windows.Forms.ComboBox()
      Me.lblIntExt = New System.Windows.Forms.Label()
      Me.cmbLado = New System.Windows.Forms.ComboBox()
      Me.lblLado = New System.Windows.Forms.Label()
      Me.cmbTipoUbicacion = New System.Windows.Forms.ComboBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
      Me.tsbtnGrabarUbicacion = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbtnModificarUbicacion = New System.Windows.Forms.ToolStripButton()
      Me.tsbtnCancelarUbicacion = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
      Me.grpPosicionActual = New System.Windows.Forms.GroupBox()
      Me.acVehActual = New ACControles.ACVehiculo()
      Me.txtUbicacion = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.txtPosicion = New System.Windows.Forms.TextBox()
      Me.txtTipoUbicacion = New System.Windows.Forms.TextBox()
      Me.txtLado = New System.Windows.Forms.TextBox()
      Me.txtIntExt = New System.Windows.Forms.TextBox()
      Me.txtSeccion = New System.Windows.Forms.TextBox()
      Me.CheckBox1 = New System.Windows.Forms.CheckBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
      Me.grpDocumento = New System.Windows.Forms.GroupBox()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.txtContenido = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtNroDocumento = New System.Windows.Forms.TextBox()
      Me.txtDescripcion = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.acpnlTitulo = New ACControles.ACPanelCaption()
      Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
      Me.tsbtnRevisar = New ACControles.ACToolStripButton(Me.components)
      Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
      Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.pnlDatos = New System.Windows.Forms.Panel()
      Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.c1grdBusqueda = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.bnavBusqueda = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.grpBusqueda = New System.Windows.Forms.GroupBox()
      Me.rbtnDescripcion = New System.Windows.Forms.RadioButton()
      Me.rbtnCodigo = New System.Windows.Forms.RadioButton()
      Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
      Me.eprError = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.pnlDetalle.SuspendLayout()
      Me.pnlSeleccionados.SuspendLayout()
      CType(Me.c1grdNeumaticos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tsbOpciones.SuspendLayout()
      CType(Me.bnavNeumaticos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavNeumaticos.SuspendLayout()
      Me.pnlNoAsignados.SuspendLayout()
      CType(Me.c1grdNoAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavNoAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavNoAsignados.SuspendLayout()
      Me.pnlUbicacion.SuspendLayout()
      Me.grpNuevPosicion.SuspendLayout()
      CType(Me.nupPosicion, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ToolStrip2.SuspendLayout()
      Me.grpPosicionActual.SuspendLayout()
      Me.grpDocumento.SuspendLayout()
      Me.acTool.SuspendLayout()
      Me.tabMantenimiento.SuspendLayout()
      Me.tabDatos.SuspendLayout()
      Me.pnlDatos.SuspendLayout()
      Me.tabBusqueda.SuspendLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavBusqueda.SuspendLayout()
      Me.grpBusqueda.SuspendLayout()
      CType(Me.eprError, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'pnlDetalle
      '
      Me.pnlDetalle.Controls.Add(Me.pnlSeleccionados)
      Me.pnlDetalle.Controls.Add(Me.pnlUbicacion)
      Me.pnlDetalle.Controls.Add(Me.AcPanelCaption1)
      Me.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlDetalle.Location = New System.Drawing.Point(0, 94)
      Me.pnlDetalle.Name = "pnlDetalle"
      Me.pnlDetalle.Size = New System.Drawing.Size(910, 386)
      Me.pnlDetalle.TabIndex = 41
      '
      'pnlSeleccionados
      '
      Me.pnlSeleccionados.Controls.Add(Me.c1grdNeumaticos)
      Me.pnlSeleccionados.Controls.Add(Me.tsbOpciones)
      Me.pnlSeleccionados.Controls.Add(Me.bnavNeumaticos)
      Me.pnlSeleccionados.Controls.Add(Me.pnlNoAsignados)
      Me.pnlSeleccionados.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlSeleccionados.Location = New System.Drawing.Point(0, 18)
      Me.pnlSeleccionados.Name = "pnlSeleccionados"
      Me.pnlSeleccionados.Size = New System.Drawing.Size(476, 368)
      Me.pnlSeleccionados.TabIndex = 12
      '
      'c1grdNeumaticos
      '
      Me.c1grdNeumaticos.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdNeumaticos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdNeumaticos.Location = New System.Drawing.Point(0, 39)
      Me.c1grdNeumaticos.Name = "c1grdNeumaticos"
      Me.c1grdNeumaticos.Rows.Count = 2
      Me.c1grdNeumaticos.Rows.DefaultSize = 18
      Me.c1grdNeumaticos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
      Me.c1grdNeumaticos.Size = New System.Drawing.Size(476, 164)
      Me.c1grdNeumaticos.StyleInfo = resources.GetString("c1grdNeumaticos.StyleInfo")
      Me.c1grdNeumaticos.TabIndex = 4
      '
      'tsbOpciones
      '
      Me.tsbOpciones.ImageScalingSize = New System.Drawing.Size(32, 32)
      Me.tsbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAgregar, Me.ToolStripSeparator5, Me.tsbQuitar, Me.ToolStripSeparator6})
      Me.tsbOpciones.Location = New System.Drawing.Point(0, 0)
      Me.tsbOpciones.Name = "tsbOpciones"
      Me.tsbOpciones.Size = New System.Drawing.Size(476, 39)
      Me.tsbOpciones.TabIndex = 11
      Me.tsbOpciones.Text = "ToolStrip1"
      '
      'tsbtnAgregar
      '
      Me.tsbtnAgregar.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_32x32
      Me.tsbtnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnAgregar.Name = "tsbtnAgregar"
      Me.tsbtnAgregar.Size = New System.Drawing.Size(135, 36)
      Me.tsbtnAgregar.Text = "Agregar Neumatico"
      Me.tsbtnAgregar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 39)
      '
      'tsbQuitar
      '
      Me.tsbQuitar.Image = Global.ACPTransportes.My.Resources.Resources.ACDelete_32x32
      Me.tsbQuitar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbQuitar.Name = "tsbQuitar"
      Me.tsbQuitar.Size = New System.Drawing.Size(126, 36)
      Me.tsbQuitar.Text = "Quitar Neumatico"
      '
      'ToolStripSeparator6
      '
      Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
      Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
      '
      'bnavNeumaticos
      '
      Me.bnavNeumaticos.AddNewItem = Me.BindingNavigatorAddNewItem
      Me.bnavNeumaticos.CountItem = Me.BindingNavigatorCountItem
      Me.bnavNeumaticos.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.bnavNeumaticos.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavNeumaticos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
      Me.bnavNeumaticos.Location = New System.Drawing.Point(0, 203)
      Me.bnavNeumaticos.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavNeumaticos.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavNeumaticos.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavNeumaticos.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavNeumaticos.Name = "bnavNeumaticos"
      Me.bnavNeumaticos.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavNeumaticos.Size = New System.Drawing.Size(476, 25)
      Me.bnavNeumaticos.TabIndex = 5
      Me.bnavNeumaticos.Text = "BindingNavigator1"
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
      'pnlNoAsignados
      '
      Me.pnlNoAsignados.Controls.Add(Me.c1grdNoAsignados)
      Me.pnlNoAsignados.Controls.Add(Me.bnavNoAsignados)
      Me.pnlNoAsignados.Controls.Add(Me.AcPanelCaption2)
      Me.pnlNoAsignados.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.pnlNoAsignados.Location = New System.Drawing.Point(0, 228)
      Me.pnlNoAsignados.Name = "pnlNoAsignados"
      Me.pnlNoAsignados.Size = New System.Drawing.Size(476, 140)
      Me.pnlNoAsignados.TabIndex = 12
      Me.pnlNoAsignados.Visible = False
      '
      'c1grdNoAsignados
      '
      Me.c1grdNoAsignados.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdNoAsignados.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdNoAsignados.Location = New System.Drawing.Point(0, 43)
      Me.c1grdNoAsignados.Name = "c1grdNoAsignados"
      Me.c1grdNoAsignados.Rows.Count = 2
      Me.c1grdNoAsignados.Rows.DefaultSize = 18
      Me.c1grdNoAsignados.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
      Me.c1grdNoAsignados.Size = New System.Drawing.Size(476, 97)
      Me.c1grdNoAsignados.StyleInfo = resources.GetString("c1grdNoAsignados.StyleInfo")
      Me.c1grdNoAsignados.TabIndex = 12
      '
      'bnavNoAsignados
      '
      Me.bnavNoAsignados.AddNewItem = Me.ToolStripButton7
      Me.bnavNoAsignados.CountItem = Me.ToolStripLabel2
      Me.bnavNoAsignados.DeleteItem = Me.ToolStripButton9
      Me.bnavNoAsignados.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton10, Me.ToolStripButton11, Me.ToolStripSeparator8, Me.ToolStripTextBox2, Me.ToolStripLabel2, Me.ToolStripSeparator9, Me.ToolStripButton12, Me.ToolStripButton13, Me.ToolStripSeparator10, Me.ToolStripButton7, Me.ToolStripButton9, Me.tsbtnAsignarNoSeleccionado, Me.tsbtnAsigTodosNoSeleccionado, Me.ToolStripSeparator11, Me.ToolStripButton16, Me.ToolStripButton17, Me.ToolStripSeparator12})
      Me.bnavNoAsignados.Location = New System.Drawing.Point(0, 18)
      Me.bnavNoAsignados.MoveFirstItem = Me.ToolStripButton10
      Me.bnavNoAsignados.MoveLastItem = Me.ToolStripButton13
      Me.bnavNoAsignados.MoveNextItem = Me.ToolStripButton12
      Me.bnavNoAsignados.MovePreviousItem = Me.ToolStripButton11
      Me.bnavNoAsignados.Name = "bnavNoAsignados"
      Me.bnavNoAsignados.PositionItem = Me.ToolStripTextBox2
      Me.bnavNoAsignados.Size = New System.Drawing.Size(476, 25)
      Me.bnavNoAsignados.TabIndex = 13
      Me.bnavNoAsignados.Text = "BindingNavigator1"
      '
      'ToolStripButton7
      '
      Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
      Me.ToolStripButton7.Name = "ToolStripButton7"
      Me.ToolStripButton7.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton7.Text = "Add new"
      Me.ToolStripButton7.Visible = False
      '
      'ToolStripLabel2
      '
      Me.ToolStripLabel2.Name = "ToolStripLabel2"
      Me.ToolStripLabel2.Size = New System.Drawing.Size(36, 22)
      Me.ToolStripLabel2.Text = "of {0}"
      Me.ToolStripLabel2.ToolTipText = "Total number of items"
      '
      'ToolStripButton9
      '
      Me.ToolStripButton9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
      Me.ToolStripButton9.Name = "ToolStripButton9"
      Me.ToolStripButton9.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton9.Text = "Delete"
      Me.ToolStripButton9.Visible = False
      '
      'ToolStripButton10
      '
      Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
      Me.ToolStripButton10.Name = "ToolStripButton10"
      Me.ToolStripButton10.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton10.Text = "Move first"
      '
      'ToolStripButton11
      '
      Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
      Me.ToolStripButton11.Name = "ToolStripButton11"
      Me.ToolStripButton11.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton11.Text = "Move previous"
      '
      'ToolStripSeparator8
      '
      Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
      Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripTextBox2
      '
      Me.ToolStripTextBox2.AccessibleName = "Position"
      Me.ToolStripTextBox2.AutoSize = False
      Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
      Me.ToolStripTextBox2.Size = New System.Drawing.Size(50, 21)
      Me.ToolStripTextBox2.Text = "0"
      Me.ToolStripTextBox2.ToolTipText = "Current position"
      '
      'ToolStripSeparator9
      '
      Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
      Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripButton12
      '
      Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
      Me.ToolStripButton12.Name = "ToolStripButton12"
      Me.ToolStripButton12.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton12.Text = "Move next"
      '
      'ToolStripButton13
      '
      Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
      Me.ToolStripButton13.Name = "ToolStripButton13"
      Me.ToolStripButton13.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton13.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton13.Text = "Move last"
      '
      'ToolStripSeparator10
      '
      Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
      Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
      '
      'tsbtnAsignarNoSeleccionado
      '
      Me.tsbtnAsignarNoSeleccionado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.tsbtnAsignarNoSeleccionado.Image = Global.ACPTransportes.My.Resources.Resources.ACUpArrow_16x16
      Me.tsbtnAsignarNoSeleccionado.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnAsignarNoSeleccionado.Name = "tsbtnAsignarNoSeleccionado"
      Me.tsbtnAsignarNoSeleccionado.Size = New System.Drawing.Size(23, 22)
      Me.tsbtnAsignarNoSeleccionado.Text = "Agregar"
      '
      'tsbtnAsigTodosNoSeleccionado
      '
      Me.tsbtnAsigTodosNoSeleccionado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.tsbtnAsigTodosNoSeleccionado.Image = Global.ACPTransportes.My.Resources.Resources.ACUpArrowAll_16x16
      Me.tsbtnAsigTodosNoSeleccionado.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnAsigTodosNoSeleccionado.Name = "tsbtnAsigTodosNoSeleccionado"
      Me.tsbtnAsigTodosNoSeleccionado.Size = New System.Drawing.Size(23, 22)
      Me.tsbtnAsigTodosNoSeleccionado.Text = "Agregar"
      '
      'ToolStripSeparator11
      '
      Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
      Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripButton16
      '
      Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton16.Image = Global.ACPTransportes.My.Resources.Resources.ACDownArrow_16x16
      Me.ToolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton16.Name = "ToolStripButton16"
      Me.ToolStripButton16.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton16.Text = "Agregar"
      Me.ToolStripButton16.Visible = False
      '
      'ToolStripButton17
      '
      Me.ToolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton17.Image = Global.ACPTransportes.My.Resources.Resources.ACDownArrowAll_16x16
      Me.ToolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton17.Name = "ToolStripButton17"
      Me.ToolStripButton17.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton17.Text = "Agregar"
      Me.ToolStripButton17.Visible = False
      '
      'ToolStripSeparator12
      '
      Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
      Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
      Me.ToolStripSeparator12.Visible = False
      '
      'AcPanelCaption2
      '
      Me.AcPanelCaption2.ACCaption = "Neumaticos No Asignados"
      Me.AcPanelCaption2.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption2.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption2.Name = "AcPanelCaption2"
      Me.AcPanelCaption2.Size = New System.Drawing.Size(476, 18)
      Me.AcPanelCaption2.TabIndex = 11
      '
      'pnlUbicacion
      '
      Me.pnlUbicacion.Controls.Add(Me.grpNuevPosicion)
      Me.pnlUbicacion.Controls.Add(Me.grpPosicionActual)
      Me.pnlUbicacion.Controls.Add(Me.ToolStrip2)
      Me.pnlUbicacion.Dock = System.Windows.Forms.DockStyle.Right
      Me.pnlUbicacion.Location = New System.Drawing.Point(476, 18)
      Me.pnlUbicacion.Name = "pnlUbicacion"
      Me.pnlUbicacion.Size = New System.Drawing.Size(434, 368)
      Me.pnlUbicacion.TabIndex = 0
      '
      'grpNuevPosicion
      '
      Me.grpNuevPosicion.Controls.Add(Me.NumericUpDown1)
      Me.grpNuevPosicion.Controls.Add(Me.Label11)
      Me.grpNuevPosicion.Controls.Add(Me.lblSeccion)
      Me.grpNuevPosicion.Controls.Add(Me.acVehNueva)
      Me.grpNuevPosicion.Controls.Add(Me.cmbSeccion)
      Me.grpNuevPosicion.Controls.Add(Me.txtMotivo)
      Me.grpNuevPosicion.Controls.Add(Me.Label19)
      Me.grpNuevPosicion.Controls.Add(Me.txtGlosa)
      Me.grpNuevPosicion.Controls.Add(Me.Label18)
      Me.grpNuevPosicion.Controls.Add(Me.txtDestino)
      Me.grpNuevPosicion.Controls.Add(Me.Label3)
      Me.grpNuevPosicion.Controls.Add(Me.actxParaDesc)
      Me.grpNuevPosicion.Controls.Add(Me.actxaPara)
      Me.grpNuevPosicion.Controls.Add(Me.Label14)
      Me.grpNuevPosicion.Controls.Add(Me.nupPosicion)
      Me.grpNuevPosicion.Controls.Add(Me.chkRepuesto)
      Me.grpNuevPosicion.Controls.Add(Me.lblPosicion)
      Me.grpNuevPosicion.Controls.Add(Me.cmbIntExt)
      Me.grpNuevPosicion.Controls.Add(Me.lblIntExt)
      Me.grpNuevPosicion.Controls.Add(Me.cmbLado)
      Me.grpNuevPosicion.Controls.Add(Me.lblLado)
      Me.grpNuevPosicion.Controls.Add(Me.cmbTipoUbicacion)
      Me.grpNuevPosicion.Controls.Add(Me.Label15)
      Me.grpNuevPosicion.Dock = System.Windows.Forms.DockStyle.Fill
      Me.grpNuevPosicion.Location = New System.Drawing.Point(0, 114)
      Me.grpNuevPosicion.Name = "grpNuevPosicion"
      Me.grpNuevPosicion.Size = New System.Drawing.Size(384, 254)
      Me.grpNuevPosicion.TabIndex = 43
      Me.grpNuevPosicion.TabStop = False
      Me.grpNuevPosicion.Text = "Ubicacion Nueva"
      '
      'lblSeccion
      '
      Me.lblSeccion.AutoSize = True
      Me.lblSeccion.Location = New System.Drawing.Point(53, 84)
      Me.lblSeccion.Name = "lblSeccion"
      Me.lblSeccion.Size = New System.Drawing.Size(50, 13)
      Me.lblSeccion.TabIndex = 8
      Me.lblSeccion.Text = "Sección :"
      '
      'acVehNueva
      '
      Me.acVehNueva.BackColor = System.Drawing.Color.Transparent
      Me.acVehNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.acVehNueva.ColorAll = System.Drawing.Color.Black
      Me.acVehNueva.ColorDefaultOne = System.Drawing.Color.Black
      Me.acVehNueva.ColorDefaultTwo = System.Drawing.Color.Red
      Me.acVehNueva.Location = New System.Drawing.Point(328, 58)
      Me.acVehNueva.MaximumSize = New System.Drawing.Size(52, 122)
      Me.acVehNueva.MinimumSize = New System.Drawing.Size(52, 100)
      Me.acVehNueva.Name = "acVehNueva"
      Me.acVehNueva.NeuDelDerExt1 = System.Drawing.Color.Black
      Me.acVehNueva.NeuDelIzqExt1 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosDerExt2 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosDerExt3 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosDerExt4 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosDerInt2 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosDerInt3 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosDerInt4 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosIzqExt2 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosIzqExt3 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosIzqExt4 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosIzqInt2 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosIzqInt3 = System.Drawing.Color.Black
      Me.acVehNueva.NeuPosIzqInt4 = System.Drawing.Color.Black
      Me.acVehNueva.Size = New System.Drawing.Size(52, 105)
      Me.acVehNueva.TabIndex = 23
      Me.acVehNueva.VisiblePanelPos3 = True
      Me.acVehNueva.VisiblePanelPos4 = True
      '
      'cmbSeccion
      '
      Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSeccion.FormattingEnabled = True
      Me.cmbSeccion.Location = New System.Drawing.Point(108, 80)
      Me.cmbSeccion.Name = "cmbSeccion"
      Me.cmbSeccion.Size = New System.Drawing.Size(142, 21)
      Me.cmbSeccion.TabIndex = 9
      Me.cmbSeccion.Tag = "ECO"
      '
      'txtMotivo
      '
      Me.txtMotivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtMotivo.Location = New System.Drawing.Point(108, 225)
      Me.txtMotivo.MaxLength = 200
      Me.txtMotivo.Multiline = True
      Me.txtMotivo.Name = "txtMotivo"
      Me.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtMotivo.Size = New System.Drawing.Size(272, 25)
      Me.txtMotivo.TabIndex = 21
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.Location = New System.Drawing.Point(57, 228)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(46, 13)
      Me.Label19.TabIndex = 20
      Me.Label19.Text = "Motivo :"
      '
      'txtGlosa
      '
      Me.txtGlosa.Location = New System.Drawing.Point(108, 190)
      Me.txtGlosa.MaxLength = 200
      Me.txtGlosa.Multiline = True
      Me.txtGlosa.Name = "txtGlosa"
      Me.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtGlosa.Size = New System.Drawing.Size(272, 34)
      Me.txtGlosa.TabIndex = 19
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(63, 193)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(40, 13)
      Me.Label18.TabIndex = 18
      Me.Label18.Text = "Glosa :"
      '
      'txtDestino
      '
      Me.txtDestino.Location = New System.Drawing.Point(108, 168)
      Me.txtDestino.MaxLength = 50
      Me.txtDestino.Name = "txtDestino"
      Me.txtDestino.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtDestino.Size = New System.Drawing.Size(272, 21)
      Me.txtDestino.TabIndex = 17
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(53, 173)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(50, 13)
      Me.Label3.TabIndex = 16
      Me.Label3.Text = "Destino :"
      '
      'actxParaDesc
      '
      Me.actxParaDesc.ACActivarAyudaAuto = False
      Me.actxParaDesc.ACLongitudAceptada = 0
      Me.actxParaDesc.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxParaDesc.Location = New System.Drawing.Point(202, 36)
      Me.actxParaDesc.MaxLength = 32767
      Me.actxParaDesc.Name = "actxParaDesc"
      Me.actxParaDesc.Size = New System.Drawing.Size(178, 21)
      Me.actxParaDesc.TabIndex = 5
      Me.actxParaDesc.Tag = "EV"
      '
      'actxaPara
      '
      Me.actxaPara.ACActivarAyudaAuto = False
      Me.actxaPara.ACLongitudAceptada = 0
      Me.actxaPara.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaPara.Location = New System.Drawing.Point(108, 36)
      Me.actxaPara.MaxLength = 32767
      Me.actxaPara.Name = "actxaPara"
      Me.actxaPara.Size = New System.Drawing.Size(88, 21)
      Me.actxaPara.TabIndex = 4
      Me.actxaPara.Tag = "EVO"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(67, 40)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(36, 13)
      Me.Label14.TabIndex = 3
      Me.Label14.Text = "Para :"
      '
      'nupPosicion
      '
      Me.nupPosicion.Location = New System.Drawing.Point(108, 146)
      Me.nupPosicion.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
      Me.nupPosicion.Name = "nupPosicion"
      Me.nupPosicion.Size = New System.Drawing.Size(142, 21)
      Me.nupPosicion.TabIndex = 15
      Me.nupPosicion.ThousandsSeparator = True
      '
      'chkRepuesto
      '
      Me.chkRepuesto.AutoSize = True
      Me.chkRepuesto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkRepuesto.Location = New System.Drawing.Point(296, 18)
      Me.chkRepuesto.Name = "chkRepuesto"
      Me.chkRepuesto.Size = New System.Drawing.Size(84, 17)
      Me.chkRepuesto.TabIndex = 2
      Me.chkRepuesto.Text = "Respuesto :"
      Me.chkRepuesto.UseVisualStyleBackColor = True
      '
      'lblPosicion
      '
      Me.lblPosicion.AutoSize = True
      Me.lblPosicion.Location = New System.Drawing.Point(51, 150)
      Me.lblPosicion.Name = "lblPosicion"
      Me.lblPosicion.Size = New System.Drawing.Size(52, 13)
      Me.lblPosicion.TabIndex = 14
      Me.lblPosicion.Text = "Posición :"
      '
      'cmbIntExt
      '
      Me.cmbIntExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIntExt.FormattingEnabled = True
      Me.cmbIntExt.Location = New System.Drawing.Point(108, 124)
      Me.cmbIntExt.Name = "cmbIntExt"
      Me.cmbIntExt.Size = New System.Drawing.Size(142, 21)
      Me.cmbIntExt.TabIndex = 13
      Me.cmbIntExt.Tag = "ECO"
      '
      'lblIntExt
      '
      Me.lblIntExt.AutoSize = True
      Me.lblIntExt.Location = New System.Drawing.Point(11, 127)
      Me.lblIntExt.Name = "lblIntExt"
      Me.lblIntExt.Size = New System.Drawing.Size(92, 13)
      Me.lblIntExt.TabIndex = 12
      Me.lblIntExt.Text = "Interno/Externo :"
      '
      'cmbLado
      '
      Me.cmbLado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLado.FormattingEnabled = True
      Me.cmbLado.Location = New System.Drawing.Point(108, 102)
      Me.cmbLado.Name = "cmbLado"
      Me.cmbLado.Size = New System.Drawing.Size(142, 21)
      Me.cmbLado.TabIndex = 11
      Me.cmbLado.Tag = "ECO"
      '
      'lblLado
      '
      Me.lblLado.AutoSize = True
      Me.lblLado.Location = New System.Drawing.Point(66, 105)
      Me.lblLado.Name = "lblLado"
      Me.lblLado.Size = New System.Drawing.Size(37, 13)
      Me.lblLado.TabIndex = 10
      Me.lblLado.Text = "Lado :"
      '
      'cmbTipoUbicacion
      '
      Me.cmbTipoUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoUbicacion.FormattingEnabled = True
      Me.cmbTipoUbicacion.Location = New System.Drawing.Point(108, 14)
      Me.cmbTipoUbicacion.Name = "cmbTipoUbicacion"
      Me.cmbTipoUbicacion.Size = New System.Drawing.Size(175, 21)
      Me.cmbTipoUbicacion.TabIndex = 1
      Me.cmbTipoUbicacion.Tag = "ECO"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(15, 17)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(88, 13)
      Me.Label15.TabIndex = 0
      Me.Label15.Text = "Tipo de Destino :"
      '
      'ToolStrip2
      '
      Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Right
      Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(32, 32)
      Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnGrabarUbicacion, Me.ToolStripSeparator4, Me.tsbtnModificarUbicacion, Me.tsbtnCancelarUbicacion, Me.ToolStripSeparator7})
      Me.ToolStrip2.Location = New System.Drawing.Point(384, 0)
      Me.ToolStrip2.Name = "ToolStrip2"
      Me.ToolStrip2.Size = New System.Drawing.Size(50, 368)
      Me.ToolStrip2.TabIndex = 20
      Me.ToolStrip2.Text = "ToolStrip2"
      Me.ToolStrip2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
      '
      'tsbtnGrabarUbicacion
      '
      Me.tsbtnGrabarUbicacion.Image = Global.ACPTransportes.My.Resources.Resources.ACGrabar_32x32
      Me.tsbtnGrabarUbicacion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnGrabarUbicacion.Name = "tsbtnGrabarUbicacion"
      Me.tsbtnGrabarUbicacion.Size = New System.Drawing.Size(47, 92)
      Me.tsbtnGrabarUbicacion.Text = "Grabar Ubicación"
      Me.tsbtnGrabarUbicacion.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(47, 6)
      Me.ToolStripSeparator4.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
      '
      'tsbtnModificarUbicacion
      '
      Me.tsbtnModificarUbicacion.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_32x32
      Me.tsbtnModificarUbicacion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnModificarUbicacion.Name = "tsbtnModificarUbicacion"
      Me.tsbtnModificarUbicacion.Size = New System.Drawing.Size(47, 54)
      Me.tsbtnModificarUbicacion.Text = "Modificar"
      '
      'tsbtnCancelarUbicacion
      '
      Me.tsbtnCancelarUbicacion.Image = Global.ACPTransportes.My.Resources.Resources.ACCancelar_32x32
      Me.tsbtnCancelarUbicacion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnCancelarUbicacion.Name = "tsbtnCancelarUbicacion"
      Me.tsbtnCancelarUbicacion.Size = New System.Drawing.Size(47, 96)
      Me.tsbtnCancelarUbicacion.Text = "Cancelar Cambios"
      Me.tsbtnCancelarUbicacion.Visible = False
      '
      'ToolStripSeparator7
      '
      Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
      Me.ToolStripSeparator7.Size = New System.Drawing.Size(47, 6)
      Me.ToolStripSeparator7.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
      '
      'grpPosicionActual
      '
      Me.grpPosicionActual.Controls.Add(Me.acVehActual)
      Me.grpPosicionActual.Controls.Add(Me.txtUbicacion)
      Me.grpPosicionActual.Controls.Add(Me.Label20)
      Me.grpPosicionActual.Controls.Add(Me.txtPosicion)
      Me.grpPosicionActual.Controls.Add(Me.txtTipoUbicacion)
      Me.grpPosicionActual.Controls.Add(Me.txtLado)
      Me.grpPosicionActual.Controls.Add(Me.txtIntExt)
      Me.grpPosicionActual.Controls.Add(Me.txtSeccion)
      Me.grpPosicionActual.Controls.Add(Me.CheckBox1)
      Me.grpPosicionActual.Controls.Add(Me.Label4)
      Me.grpPosicionActual.Controls.Add(Me.Label6)
      Me.grpPosicionActual.Controls.Add(Me.Label7)
      Me.grpPosicionActual.Controls.Add(Me.Label8)
      Me.grpPosicionActual.Controls.Add(Me.Label9)
      Me.grpPosicionActual.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpPosicionActual.Location = New System.Drawing.Point(0, 0)
      Me.grpPosicionActual.Name = "grpPosicionActual"
      Me.grpPosicionActual.Size = New System.Drawing.Size(384, 114)
      Me.grpPosicionActual.TabIndex = 44
      Me.grpPosicionActual.TabStop = False
      Me.grpPosicionActual.Text = "Ubicacion Actual"
      '
      'acVehActual
      '
      Me.acVehActual.BackColor = System.Drawing.Color.Transparent
      Me.acVehActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.acVehActual.ColorAll = System.Drawing.Color.Black
      Me.acVehActual.ColorDefaultOne = System.Drawing.Color.Black
      Me.acVehActual.ColorDefaultTwo = System.Drawing.Color.Red
      Me.acVehActual.Location = New System.Drawing.Point(328, 8)
      Me.acVehActual.MaximumSize = New System.Drawing.Size(52, 122)
      Me.acVehActual.MinimumSize = New System.Drawing.Size(52, 100)
      Me.acVehActual.Name = "acVehActual"
      Me.acVehActual.NeuDelDerExt1 = System.Drawing.Color.Black
      Me.acVehActual.NeuDelIzqExt1 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosDerExt2 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosDerExt3 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosDerExt4 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosDerInt2 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosDerInt3 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosDerInt4 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosIzqExt2 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosIzqExt3 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosIzqExt4 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosIzqInt2 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosIzqInt3 = System.Drawing.Color.Black
      Me.acVehActual.NeuPosIzqInt4 = System.Drawing.Color.Black
      Me.acVehActual.Size = New System.Drawing.Size(52, 105)
      Me.acVehActual.TabIndex = 22
      Me.acVehActual.VisiblePanelPos3 = True
      Me.acVehActual.VisiblePanelPos4 = True
      '
      'txtUbicacion
      '
      Me.txtUbicacion.Location = New System.Drawing.Point(108, 38)
      Me.txtUbicacion.Name = "txtUbicacion"
      Me.txtUbicacion.ReadOnly = True
      Me.txtUbicacion.Size = New System.Drawing.Size(214, 21)
      Me.txtUbicacion.TabIndex = 12
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.Location = New System.Drawing.Point(44, 41)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(59, 13)
      Me.Label20.TabIndex = 11
      Me.Label20.Text = "Ubicacion :"
      '
      'txtPosicion
      '
      Me.txtPosicion.Location = New System.Drawing.Point(250, 87)
      Me.txtPosicion.Name = "txtPosicion"
      Me.txtPosicion.ReadOnly = True
      Me.txtPosicion.Size = New System.Drawing.Size(72, 21)
      Me.txtPosicion.TabIndex = 9
      '
      'txtTipoUbicacion
      '
      Me.txtTipoUbicacion.Location = New System.Drawing.Point(108, 14)
      Me.txtTipoUbicacion.Name = "txtTipoUbicacion"
      Me.txtTipoUbicacion.ReadOnly = True
      Me.txtTipoUbicacion.Size = New System.Drawing.Size(120, 21)
      Me.txtTipoUbicacion.TabIndex = 1
      '
      'txtLado
      '
      Me.txtLado.Location = New System.Drawing.Point(108, 87)
      Me.txtLado.Name = "txtLado"
      Me.txtLado.ReadOnly = True
      Me.txtLado.Size = New System.Drawing.Size(68, 21)
      Me.txtLado.TabIndex = 3
      '
      'txtIntExt
      '
      Me.txtIntExt.Location = New System.Drawing.Point(250, 63)
      Me.txtIntExt.Name = "txtIntExt"
      Me.txtIntExt.ReadOnly = True
      Me.txtIntExt.Size = New System.Drawing.Size(72, 21)
      Me.txtIntExt.TabIndex = 5
      '
      'txtSeccion
      '
      Me.txtSeccion.Location = New System.Drawing.Point(108, 63)
      Me.txtSeccion.Name = "txtSeccion"
      Me.txtSeccion.ReadOnly = True
      Me.txtSeccion.Size = New System.Drawing.Size(68, 21)
      Me.txtSeccion.TabIndex = 7
      '
      'CheckBox1
      '
      Me.CheckBox1.AutoSize = True
      Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.CheckBox1.Enabled = False
      Me.CheckBox1.Location = New System.Drawing.Point(238, 16)
      Me.CheckBox1.Name = "CheckBox1"
      Me.CheckBox1.Size = New System.Drawing.Size(84, 17)
      Me.CheckBox1.TabIndex = 10
      Me.CheckBox1.Text = "Respuesto :"
      Me.CheckBox1.UseVisualStyleBackColor = True
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(188, 91)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(52, 13)
      Me.Label4.TabIndex = 8
      Me.Label4.Text = "Posición :"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(184, 67)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(56, 13)
      Me.Label6.TabIndex = 4
      Me.Label6.Text = "Int./Ext. :"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(66, 91)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(37, 13)
      Me.Label7.TabIndex = 2
      Me.Label7.Text = "Lado :"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(53, 67)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(50, 13)
      Me.Label8.TabIndex = 6
      Me.Label8.Text = "Sección :"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(21, 18)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(82, 13)
      Me.Label9.TabIndex = 0
      Me.Label9.Text = "Tipo Ubicacion :"
      '
      'AcPanelCaption1
      '
      Me.AcPanelCaption1.ACCaption = "Datos Generales"
      Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption1.Name = "AcPanelCaption1"
      Me.AcPanelCaption1.Size = New System.Drawing.Size(910, 18)
      Me.AcPanelCaption1.TabIndex = 10
      '
      'grpDocumento
      '
      Me.grpDocumento.Controls.Add(Me.dtpFecha)
      Me.grpDocumento.Controls.Add(Me.Label16)
      Me.grpDocumento.Controls.Add(Me.txtContenido)
      Me.grpDocumento.Controls.Add(Me.Label1)
      Me.grpDocumento.Controls.Add(Me.txtNroDocumento)
      Me.grpDocumento.Controls.Add(Me.txtDescripcion)
      Me.grpDocumento.Controls.Add(Me.Label10)
      Me.grpDocumento.Controls.Add(Me.cmbTipoDocumento)
      Me.grpDocumento.Controls.Add(Me.Label2)
      Me.grpDocumento.Controls.Add(Me.Label5)
      Me.grpDocumento.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpDocumento.Location = New System.Drawing.Point(0, 0)
      Me.grpDocumento.Name = "grpDocumento"
      Me.grpDocumento.Size = New System.Drawing.Size(910, 94)
      Me.grpDocumento.TabIndex = 40
      Me.grpDocumento.TabStop = False
      Me.grpDocumento.Text = "Documento de Movimiento"
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(448, 14)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(119, 21)
      Me.dtpFecha.TabIndex = 3
      Me.dtpFecha.Tag = "E"
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.Location = New System.Drawing.Point(399, 18)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(43, 13)
      Me.Label16.TabIndex = 2
      Me.Label16.Text = "&Fecha :"
      '
      'txtContenido
      '
      Me.txtContenido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtContenido.Location = New System.Drawing.Point(118, 58)
      Me.txtContenido.MaxLength = 200
      Me.txtContenido.Multiline = True
      Me.txtContenido.Name = "txtContenido"
      Me.txtContenido.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtContenido.Size = New System.Drawing.Size(771, 32)
      Me.txtContenido.TabIndex = 12
      Me.txtContenido.Tag = "EV"
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(687, 18)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(56, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Nro Doc. :"
      '
      'txtNroDocumento
      '
      Me.txtNroDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNroDocumento.Enabled = False
      Me.txtNroDocumento.Location = New System.Drawing.Point(748, 14)
      Me.txtNroDocumento.MaxLength = 8
      Me.txtNroDocumento.Name = "txtNroDocumento"
      Me.txtNroDocumento.Size = New System.Drawing.Size(141, 21)
      Me.txtNroDocumento.TabIndex = 5
      Me.txtNroDocumento.Tag = ""
      '
      'txtDescripcion
      '
      Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDescripcion.Location = New System.Drawing.Point(118, 36)
      Me.txtDescripcion.MaxLength = 50
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(771, 21)
      Me.txtDescripcion.TabIndex = 7
      Me.txtDescripcion.Tag = "EVO"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(49, 58)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(63, 13)
      Me.Label10.TabIndex = 11
      Me.Label10.Text = "Contenido :"
      '
      'cmbTipoDocumento
      '
      Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoDocumento.FormattingEnabled = True
      Me.cmbTipoDocumento.Location = New System.Drawing.Point(118, 14)
      Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
      Me.cmbTipoDocumento.Size = New System.Drawing.Size(268, 21)
      Me.cmbTipoDocumento.TabIndex = 1
      Me.cmbTipoDocumento.Tag = "ECO"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(45, 40)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(68, 13)
      Me.Label2.TabIndex = 6
      Me.Label2.Text = "Descripción :"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(7, 18)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(106, 13)
      Me.Label5.TabIndex = 0
      Me.Label5.Text = "Tipo de Documento :"
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Movimiento de Neumaticos"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(912, 25)
      Me.acpnlTitulo.TabIndex = 19
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
      Me.acTool.ACBtnVolverEnabled = False
      Me.acTool.ACBtnVolverVisible = False
      Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabar
      Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
      Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
      Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnRevisar})
      Me.acTool.Location = New System.Drawing.Point(0, 530)
      Me.acTool.Name = "acTool"
      Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.acTool.Size = New System.Drawing.Size(912, 56)
      Me.acTool.TabIndex = 11
      Me.acTool.Text = "AcToolBarMantHorizontalNew1"
      '
      'tsbtnRevisar
      '
      Me.tsbtnRevisar.AutoSize = False
      Me.tsbtnRevisar.Image = Global.ACPTransportes.My.Resources.Resources.ACAppProduccion_32x32
      Me.tsbtnRevisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.tsbtnRevisar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.tsbtnRevisar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnRevisar.Name = "tsbBoton"
      Me.tsbtnRevisar.Size = New System.Drawing.Size(75, 53)
      Me.tsbtnRevisar.Text = "Revisar"
      Me.tsbtnRevisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.tsbtnRevisar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.tsbtnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      '
      'tabMantenimiento
      '
      Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
      Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tabMantenimiento.Location = New System.Drawing.Point(0, 25)
      Me.tabMantenimiento.MediaPlayerDockSides = False
      Me.tabMantenimiento.Name = "tabMantenimiento"
      Me.tabMantenimiento.OfficeDockSides = False
      Me.tabMantenimiento.SelectedIndex = 0
      Me.tabMantenimiento.ShowDropSelect = False
      Me.tabMantenimiento.Size = New System.Drawing.Size(912, 505)
      Me.tabMantenimiento.TabIndex = 42
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
      Me.tabDatos.Size = New System.Drawing.Size(910, 480)
      Me.tabDatos.TabIndex = 4
      Me.tabDatos.Title = "Datos"
      Me.tabDatos.ToolTip = "Datos"
      '
      'pnlDatos
      '
      Me.pnlDatos.Controls.Add(Me.pnlDetalle)
      Me.pnlDatos.Controls.Add(Me.grpDocumento)
      Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
      Me.pnlDatos.Name = "pnlDatos"
      Me.pnlDatos.Size = New System.Drawing.Size(910, 480)
      Me.pnlDatos.TabIndex = 1
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
      Me.tabBusqueda.Size = New System.Drawing.Size(910, 480)
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
      Me.c1grdBusqueda.Size = New System.Drawing.Size(910, 404)
      Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
      Me.c1grdBusqueda.TabIndex = 2
      '
      'bnavBusqueda
      '
      Me.bnavBusqueda.AddNewItem = Me.ToolStripButton1
      Me.bnavBusqueda.CountItem = Me.ToolStripLabel1
      Me.bnavBusqueda.DeleteItem = Me.ToolStripButton2
      Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2})
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 455)
      Me.bnavBusqueda.MoveFirstItem = Me.ToolStripButton3
      Me.bnavBusqueda.MoveLastItem = Me.ToolStripButton6
      Me.bnavBusqueda.MoveNextItem = Me.ToolStripButton5
      Me.bnavBusqueda.MovePreviousItem = Me.ToolStripButton4
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.ToolStripTextBox1
      Me.bnavBusqueda.Size = New System.Drawing.Size(910, 25)
      Me.bnavBusqueda.TabIndex = 3
      Me.bnavBusqueda.Text = "BindingNavigator1"
      '
      'ToolStripButton1
      '
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
      Me.ToolStripLabel1.Size = New System.Drawing.Size(36, 22)
      Me.ToolStripLabel1.Text = "of {0}"
      Me.ToolStripLabel1.ToolTipText = "Total number of items"
      '
      'ToolStripButton2
      '
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
      'grpBusqueda
      '
      Me.grpBusqueda.Controls.Add(Me.rbtnDescripcion)
      Me.grpBusqueda.Controls.Add(Me.rbtnCodigo)
      Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
      Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
      Me.grpBusqueda.Name = "grpBusqueda"
      Me.grpBusqueda.Size = New System.Drawing.Size(910, 51)
      Me.grpBusqueda.TabIndex = 1
      Me.grpBusqueda.TabStop = False
      Me.grpBusqueda.Text = "Opciones de Busqueda"
      '
      'rbtnDescripcion
      '
      Me.rbtnDescripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnDescripcion.AutoSize = True
      Me.rbtnDescripcion.Checked = True
      Me.rbtnDescripcion.Location = New System.Drawing.Point(801, 22)
      Me.rbtnDescripcion.Name = "rbtnDescripcion"
      Me.rbtnDescripcion.Size = New System.Drawing.Size(98, 17)
      Me.rbtnDescripcion.TabIndex = 4
      Me.rbtnDescripcion.TabStop = True
      Me.rbtnDescripcion.Text = "Por Descripción"
      Me.rbtnDescripcion.UseVisualStyleBackColor = True
      '
      'rbtnCodigo
      '
      Me.rbtnCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnCodigo.AutoSize = True
      Me.rbtnCodigo.Location = New System.Drawing.Point(708, 22)
      Me.rbtnCodigo.Name = "rbtnCodigo"
      Me.rbtnCodigo.Size = New System.Drawing.Size(77, 17)
      Me.rbtnCodigo.TabIndex = 3
      Me.rbtnCodigo.Text = "Por Codigo"
      Me.rbtnCodigo.UseVisualStyleBackColor = True
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
      Me.txtBusqueda.Size = New System.Drawing.Size(672, 21)
      Me.txtBusqueda.TabIndex = 0
      '
      'eprError
      '
      Me.eprError.ContainerControl = Me
      '
      'NumericUpDown1
      '
      Me.NumericUpDown1.Location = New System.Drawing.Point(108, 58)
      Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
      Me.NumericUpDown1.Name = "NumericUpDown1"
      Me.NumericUpDown1.Size = New System.Drawing.Size(142, 21)
      Me.NumericUpDown1.TabIndex = 7
      Me.NumericUpDown1.ThousandsSeparator = True
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(6, 62)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(97, 13)
      Me.Label11.TabIndex = 6
      Me.Label11.Text = "Posición Absoluta :"
      '
      'FMovimientoNeumatico
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(912, 586)
      Me.Controls.Add(Me.tabMantenimiento)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Controls.Add(Me.acTool)
      Me.Name = "FMovimientoNeumatico"
      Me.Text = "Movimiento de Neumaticos"
      Me.pnlDetalle.ResumeLayout(False)
      Me.pnlSeleccionados.ResumeLayout(False)
      Me.pnlSeleccionados.PerformLayout()
      CType(Me.c1grdNeumaticos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tsbOpciones.ResumeLayout(False)
      Me.tsbOpciones.PerformLayout()
      CType(Me.bnavNeumaticos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavNeumaticos.ResumeLayout(False)
      Me.bnavNeumaticos.PerformLayout()
      Me.pnlNoAsignados.ResumeLayout(False)
      Me.pnlNoAsignados.PerformLayout()
      CType(Me.c1grdNoAsignados, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavNoAsignados, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavNoAsignados.ResumeLayout(False)
      Me.bnavNoAsignados.PerformLayout()
      Me.pnlUbicacion.ResumeLayout(False)
      Me.pnlUbicacion.PerformLayout()
      Me.grpNuevPosicion.ResumeLayout(False)
      Me.grpNuevPosicion.PerformLayout()
      CType(Me.nupPosicion, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ToolStrip2.ResumeLayout(False)
      Me.ToolStrip2.PerformLayout()
      Me.grpPosicionActual.ResumeLayout(False)
      Me.grpPosicionActual.PerformLayout()
      Me.grpDocumento.ResumeLayout(False)
      Me.grpDocumento.PerformLayout()
      Me.acTool.ResumeLayout(False)
      Me.acTool.PerformLayout()
      Me.tabMantenimiento.ResumeLayout(False)
      Me.tabDatos.ResumeLayout(False)
      Me.pnlDatos.ResumeLayout(False)
      Me.tabBusqueda.ResumeLayout(False)
      Me.tabBusqueda.PerformLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavBusqueda.ResumeLayout(False)
      Me.bnavBusqueda.PerformLayout()
      Me.grpBusqueda.ResumeLayout(False)
      Me.grpBusqueda.PerformLayout()
      CType(Me.eprError, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents grpDocumento As System.Windows.Forms.GroupBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
   Private WithEvents grpNuevPosicion As System.Windows.Forms.GroupBox
   Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
   Friend WithEvents txtContenido As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtNroDocumento As System.Windows.Forms.TextBox
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
   Friend WithEvents pnlUbicacion As System.Windows.Forms.Panel
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Private WithEvents grpPosicionActual As System.Windows.Forms.GroupBox
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents c1grdNeumaticos As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavNeumaticos As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Friend WithEvents nupPosicion As System.Windows.Forms.NumericUpDown
   Friend WithEvents chkRepuesto As System.Windows.Forms.CheckBox
   Friend WithEvents lblPosicion As System.Windows.Forms.Label
   Friend WithEvents cmbIntExt As System.Windows.Forms.ComboBox
   Friend WithEvents lblIntExt As System.Windows.Forms.Label
   Friend WithEvents cmbLado As System.Windows.Forms.ComboBox
   Friend WithEvents lblLado As System.Windows.Forms.Label
   Friend WithEvents cmbTipoUbicacion As System.Windows.Forms.ComboBox
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents txtTipoUbicacion As System.Windows.Forms.TextBox
   Friend WithEvents txtLado As System.Windows.Forms.TextBox
   Friend WithEvents txtIntExt As System.Windows.Forms.TextBox
   Friend WithEvents txtSeccion As System.Windows.Forms.TextBox
   Friend WithEvents txtPosicion As System.Windows.Forms.TextBox
   Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents pnlDatos As System.Windows.Forms.Panel
   Private WithEvents tabBusqueda As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents c1grdBusqueda As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavBusqueda As System.Windows.Forms.BindingNavigator
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
   Private WithEvents grpBusqueda As System.Windows.Forms.GroupBox
   Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
   Friend WithEvents eprError As System.Windows.Forms.ErrorProvider
   Friend WithEvents rbtnDescripcion As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnCodigo As System.Windows.Forms.RadioButton
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents cmbSeccion As System.Windows.Forms.ComboBox
   Friend WithEvents lblSeccion As System.Windows.Forms.Label
   Friend WithEvents tsbOpciones As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbtnAgregar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbQuitar As System.Windows.Forms.ToolStripButton
   Friend WithEvents actxaPara As ACControles.ACTextBoxAyuda
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents txtDestino As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents actxParaDesc As ACControles.ACTextBoxAyuda
   Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents txtUbicacion As System.Windows.Forms.TextBox
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbtnGrabarUbicacion As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbtnModificarUbicacion As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents pnlSeleccionados As System.Windows.Forms.Panel
   Friend WithEvents pnlNoAsignados As System.Windows.Forms.Panel
   Friend WithEvents c1grdNoAsignados As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavNoAsignados As System.Windows.Forms.BindingNavigator
   Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents AcPanelCaption2 As ACControles.ACPanelCaption
   Friend WithEvents tsbtnAsignarNoSeleccionado As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbtnAsigTodosNoSeleccionado As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton16 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton17 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents acVehActual As ACControles.ACVehiculo
   Friend WithEvents acVehNueva As ACControles.ACVehiculo
   Friend WithEvents tsbtnCancelarUbicacion As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbtnRevisar As ACControles.ACToolStripButton
   Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
