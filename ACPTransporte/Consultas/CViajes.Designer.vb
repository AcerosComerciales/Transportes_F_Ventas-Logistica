<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CViajes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CViajes))
      Me.ACTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
      Me.actsbtnPrevisualizar = New ACControles.ACToolStripButton(Me.components)
      Me.acpnlTitulo = New ACControles.ACPanelCaption()
      Me.grpBusqueda = New System.Windows.Forms.GroupBox()
      Me.rbtnPlacaTracto = New System.Windows.Forms.RadioButton()
      Me.rbtnDescripcion = New System.Windows.Forms.RadioButton()
      Me.btnConsultar = New System.Windows.Forms.Button()
      Me.chkTodos = New System.Windows.Forms.CheckBox()
      Me.grpBFecha = New System.Windows.Forms.GroupBox()
      Me.rbtnFecSalida = New System.Windows.Forms.RadioButton()
      Me.rbtnFecLlegada = New System.Windows.Forms.RadioButton()
      Me.acFecha = New ACControles.ACFecha(Me.components)
      Me.rbtnCodigo = New System.Windows.Forms.RadioButton()
      Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
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
      Me.c1grdFletes = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.bnavFletes = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.acbtnSeleccionar = New ACControles.ACToolStripButton(Me.components)
      Me.ACTool.SuspendLayout()
      Me.grpBusqueda.SuspendLayout()
      Me.grpBFecha.SuspendLayout()
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavBusqueda.SuspendLayout()
      CType(Me.c1grdFletes, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavFletes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavFletes.SuspendLayout()
      Me.SuspendLayout()
      '
      'ACTool
      '
      Me.ACTool.ACBtnAnularEnabled = False
      Me.ACTool.ACBtnAnularVisible = False
      Me.ACTool.ACBtnBuscarEnabled = False
      Me.ACTool.ACBtnBuscarVisible = False
      Me.ACTool.ACBtnCancelarEnabled = False
      Me.ACTool.ACBtnCancelarVisible = False
      Me.ACTool.ACBtnEliminarEnabled = False
      Me.ACTool.ACBtnEliminarVisible = False
      Me.ACTool.ACBtnGrabarEnabled = False
      Me.ACTool.ACBtnGrabarVisible = False
      Me.ACTool.ACBtnImprimirEnabled = False
      Me.ACTool.ACBtnImprimirVisible = False
      Me.ACTool.ACBtnModificarEnabled = False
      Me.ACTool.ACBtnModificarVisible = False
      Me.ACTool.ACBtnNuevoEnabled = False
      Me.ACTool.ACBtnNuevoVisible = False
      Me.ACTool.ACBtnRehusarEnabled = False
      Me.ACTool.ACBtnRehusarVisible = False
      Me.ACTool.ACBtnReporteEnabled = False
      Me.ACTool.ACBtnReporteVisible = False
      Me.ACTool.ACBtnSalirText = "&Salir"
      Me.ACTool.ACBtnVolverEnabled = False
      Me.ACTool.ACBtnVolverVisible = False
      Me.ACTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolSalir
      Me.ACTool.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.ACTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
      Me.ACTool.ImageScalingSize = New System.Drawing.Size(32, 32)
      Me.ACTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.acbtnSeleccionar, Me.actsbtnPrevisualizar})
      Me.ACTool.Location = New System.Drawing.Point(0, 506)
      Me.ACTool.Name = "ACTool"
      Me.ACTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.ACTool.Size = New System.Drawing.Size(784, 56)
      Me.ACTool.TabIndex = 1
      Me.ACTool.Text = "AcToolBarMantHorizontalNew1"
      '
      'actsbtnPrevisualizar
      '
      Me.actsbtnPrevisualizar.AutoSize = False
      Me.actsbtnPrevisualizar.Image = Global.ACPTransportes.My.Resources.Resources.Buscar2_32x32
      Me.actsbtnPrevisualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.actsbtnPrevisualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.actsbtnPrevisualizar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.actsbtnPrevisualizar.Name = "tsbBoton"
      Me.actsbtnPrevisualizar.Size = New System.Drawing.Size(84, 53)
      Me.actsbtnPrevisualizar.Text = "Previsualizar"
      Me.actsbtnPrevisualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.actsbtnPrevisualizar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.actsbtnPrevisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      Me.actsbtnPrevisualizar.Visible = False
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Relacionar Ventas y Viajes"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(784, 30)
      Me.acpnlTitulo.TabIndex = 2
      '
      'grpBusqueda
      '
      Me.grpBusqueda.Controls.Add(Me.rbtnPlacaTracto)
      Me.grpBusqueda.Controls.Add(Me.rbtnDescripcion)
      Me.grpBusqueda.Controls.Add(Me.btnConsultar)
      Me.grpBusqueda.Controls.Add(Me.chkTodos)
      Me.grpBusqueda.Controls.Add(Me.grpBFecha)
      Me.grpBusqueda.Controls.Add(Me.rbtnCodigo)
      Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
      Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpBusqueda.Location = New System.Drawing.Point(0, 30)
      Me.grpBusqueda.Name = "grpBusqueda"
      Me.grpBusqueda.Size = New System.Drawing.Size(784, 98)
      Me.grpBusqueda.TabIndex = 3
      Me.grpBusqueda.TabStop = False
      Me.grpBusqueda.Text = "Opciones de Busqueda"
      '
      'rbtnPlacaTracto
      '
      Me.rbtnPlacaTracto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnPlacaTracto.AutoSize = True
      Me.rbtnPlacaTracto.Location = New System.Drawing.Point(623, 69)
      Me.rbtnPlacaTracto.Name = "rbtnPlacaTracto"
      Me.rbtnPlacaTracto.Size = New System.Drawing.Size(86, 17)
      Me.rbtnPlacaTracto.TabIndex = 36
      Me.rbtnPlacaTracto.Text = "Placa Tracto"
      Me.rbtnPlacaTracto.UseVisualStyleBackColor = True
      '
      'rbtnDescripcion
      '
      Me.rbtnDescripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnDescripcion.AutoSize = True
      Me.rbtnDescripcion.Checked = True
      Me.rbtnDescripcion.Location = New System.Drawing.Point(535, 69)
      Me.rbtnDescripcion.Name = "rbtnDescripcion"
      Me.rbtnDescripcion.Size = New System.Drawing.Size(81, 17)
      Me.rbtnDescripcion.TabIndex = 35
      Me.rbtnDescripcion.TabStop = True
      Me.rbtnDescripcion.Text = "Descripcion"
      Me.rbtnDescripcion.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(674, 17)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(99, 41)
      Me.btnConsultar.TabIndex = 34
      Me.btnConsultar.Text = "Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chkTodos
      '
      Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkTodos.AutoSize = True
      Me.chkTodos.Location = New System.Drawing.Point(574, 22)
      Me.chkTodos.Name = "chkTodos"
      Me.chkTodos.Size = New System.Drawing.Size(94, 17)
      Me.chkTodos.TabIndex = 34
      Me.chkTodos.Text = "Mostrar Todos"
      Me.chkTodos.UseVisualStyleBackColor = True
      '
      'grpBFecha
      '
      Me.grpBFecha.Controls.Add(Me.rbtnFecSalida)
      Me.grpBFecha.Controls.Add(Me.rbtnFecLlegada)
      Me.grpBFecha.Controls.Add(Me.acFecha)
      Me.grpBFecha.Location = New System.Drawing.Point(8, 15)
      Me.grpBFecha.Name = "grpBFecha"
      Me.grpBFecha.Size = New System.Drawing.Size(554, 43)
      Me.grpBFecha.TabIndex = 32
      Me.grpBFecha.TabStop = False
      '
      'rbtnFecSalida
      '
      Me.rbtnFecSalida.AutoSize = True
      Me.rbtnFecSalida.Location = New System.Drawing.Point(6, 17)
      Me.rbtnFecSalida.Name = "rbtnFecSalida"
      Me.rbtnFecSalida.Size = New System.Drawing.Size(87, 17)
      Me.rbtnFecSalida.TabIndex = 33
      Me.rbtnFecSalida.Text = "Fecha Salida"
      Me.rbtnFecSalida.UseVisualStyleBackColor = True
      '
      'rbtnFecLlegada
      '
      Me.rbtnFecLlegada.AutoSize = True
      Me.rbtnFecLlegada.Checked = True
      Me.rbtnFecLlegada.Location = New System.Drawing.Point(104, 17)
      Me.rbtnFecLlegada.Name = "rbtnFecLlegada"
      Me.rbtnFecLlegada.Size = New System.Drawing.Size(96, 17)
      Me.rbtnFecLlegada.TabIndex = 32
      Me.rbtnFecLlegada.TabStop = True
      Me.rbtnFecLlegada.Text = "Fecha Llegada"
      Me.rbtnFecLlegada.UseVisualStyleBackColor = True
      '
      'acFecha
      '
      Me.acFecha.ACFecha_A = New Date(2012, 1, 6, 12, 50, 2, 520)
      Me.acFecha.ACFecha_De = New Date(2012, 1, 6, 12, 50, 2, 518)
      Me.acFecha.ACFechaObligatoria = True
      Me.acFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
      Me.acFecha.ACHoyChecked = False
      Me.acFecha.ACIncrementoFecha_A = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.acFecha.ACIncrementoFecha_De = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.acFecha.ACIntervalos = ACControles.ACFecha.ACIntervalo.Ninguno
      Me.acFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.acFecha.Location = New System.Drawing.Point(217, 0)
      Me.acFecha.MaximumSize = New System.Drawing.Size(337, 43)
      Me.acFecha.MinimumSize = New System.Drawing.Size(337, 43)
      Me.acFecha.Name = "acFecha"
      Me.acFecha.Size = New System.Drawing.Size(337, 43)
      Me.acFecha.TabIndex = 25
      Me.acFecha.TabStop = False
      '
      'rbtnCodigo
      '
      Me.rbtnCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnCodigo.AutoSize = True
      Me.rbtnCodigo.Location = New System.Drawing.Point(464, 69)
      Me.rbtnCodigo.Name = "rbtnCodigo"
      Me.rbtnCodigo.Size = New System.Drawing.Size(58, 17)
      Me.rbtnCodigo.TabIndex = 30
      Me.rbtnCodigo.Text = "Codigo"
      Me.rbtnCodigo.UseVisualStyleBackColor = True
      '
      'txtBusqueda
      '
      Me.txtBusqueda.ACActivarAyudaAuto = False
      Me.txtBusqueda.ACLongitudAceptada = 0
      Me.txtBusqueda.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBusqueda.Location = New System.Drawing.Point(8, 67)
      Me.txtBusqueda.MaxLength = 32767
      Me.txtBusqueda.Name = "txtBusqueda"
      Me.txtBusqueda.Size = New System.Drawing.Size(438, 20)
      Me.txtBusqueda.TabIndex = 0
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 128)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.c1grdBusqueda)
      Me.SplitContainer1.Panel1.Controls.Add(Me.bnavBusqueda)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.c1grdFletes)
      Me.SplitContainer1.Panel2.Controls.Add(Me.bnavFletes)
      Me.SplitContainer1.Size = New System.Drawing.Size(784, 378)
      Me.SplitContainer1.SplitterDistance = 248
      Me.SplitContainer1.TabIndex = 4
      '
      'c1grdBusqueda
      '
      Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 0)
      Me.c1grdBusqueda.Name = "c1grdBusqueda"
      Me.c1grdBusqueda.Rows.Count = 2
      Me.c1grdBusqueda.Rows.DefaultSize = 20
      Me.c1grdBusqueda.Size = New System.Drawing.Size(784, 223)
      Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
      Me.c1grdBusqueda.TabIndex = 4
      '
      'bnavBusqueda
      '
      Me.bnavBusqueda.AddNewItem = Me.BindingNavigatorAddNewItem
      Me.bnavBusqueda.CountItem = Me.BindingNavigatorCountItem
      Me.bnavBusqueda.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 223)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(784, 25)
      Me.bnavBusqueda.TabIndex = 5
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
      'c1grdFletes
      '
      Me.c1grdFletes.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdFletes.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdFletes.Location = New System.Drawing.Point(0, 0)
      Me.c1grdFletes.Name = "c1grdFletes"
      Me.c1grdFletes.Rows.Count = 2
      Me.c1grdFletes.Rows.DefaultSize = 20
      Me.c1grdFletes.Size = New System.Drawing.Size(784, 101)
      Me.c1grdFletes.StyleInfo = resources.GetString("c1grdFletes.StyleInfo")
      Me.c1grdFletes.TabIndex = 4
      '
      'bnavFletes
      '
      Me.bnavFletes.AddNewItem = Me.ToolStripButton1
      Me.bnavFletes.CountItem = Me.ToolStripLabel1
      Me.bnavFletes.DeleteItem = Me.ToolStripButton2
      Me.bnavFletes.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavFletes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2})
      Me.bnavFletes.Location = New System.Drawing.Point(0, 101)
      Me.bnavFletes.MoveFirstItem = Me.ToolStripButton3
      Me.bnavFletes.MoveLastItem = Me.ToolStripButton6
      Me.bnavFletes.MoveNextItem = Me.ToolStripButton5
      Me.bnavFletes.MovePreviousItem = Me.ToolStripButton4
      Me.bnavFletes.Name = "bnavFletes"
      Me.bnavFletes.PositionItem = Me.ToolStripTextBox1
      Me.bnavFletes.Size = New System.Drawing.Size(784, 25)
      Me.bnavFletes.TabIndex = 5
      Me.bnavFletes.Text = "BindingNavigator1"
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
      Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
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
      'acbtnSeleccionar
      '
      Me.acbtnSeleccionar.AutoSize = False
      Me.acbtnSeleccionar.Image = Global.ACPTransportes.My.Resources.Resources.aceptar_32x32
      Me.acbtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.acbtnSeleccionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me.acbtnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.acbtnSeleccionar.Name = "tsbBoton"
      Me.acbtnSeleccionar.Size = New System.Drawing.Size(84, 53)
      Me.acbtnSeleccionar.Text = "&Seleccionar"
      Me.acbtnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.acbtnSeleccionar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
      Me.acbtnSeleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
      '
      'CViajes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(784, 562)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.grpBusqueda)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Controls.Add(Me.ACTool)
      Me.Name = "CViajes"
      Me.Text = "CViajes"
      Me.ACTool.ResumeLayout(False)
      Me.ACTool.PerformLayout()
      Me.grpBusqueda.ResumeLayout(False)
      Me.grpBusqueda.PerformLayout()
      Me.grpBFecha.ResumeLayout(False)
      Me.grpBFecha.PerformLayout()
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.PerformLayout()
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.Panel2.PerformLayout()
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.ResumeLayout(False)
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavBusqueda.ResumeLayout(False)
      Me.bnavBusqueda.PerformLayout()
      CType(Me.c1grdFletes, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavFletes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavFletes.ResumeLayout(False)
      Me.bnavFletes.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ACTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents actsbtnPrevisualizar As ACControles.ACToolStripButton
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Private WithEvents grpBusqueda As System.Windows.Forms.GroupBox
   Friend WithEvents rbtnPlacaTracto As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnDescripcion As System.Windows.Forms.RadioButton
   Friend WithEvents btnConsultar As System.Windows.Forms.Button
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents grpBFecha As System.Windows.Forms.GroupBox
   Friend WithEvents rbtnFecSalida As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnFecLlegada As System.Windows.Forms.RadioButton
   Friend WithEvents acFecha As ACControles.ACFecha
   Friend WithEvents rbtnCodigo As System.Windows.Forms.RadioButton
   Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
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
   Friend WithEvents c1grdFletes As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavFletes As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents acbtnSeleccionar As ACControles.ACToolStripButton
End Class
