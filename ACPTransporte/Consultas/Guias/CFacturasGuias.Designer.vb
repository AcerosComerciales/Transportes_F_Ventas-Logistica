<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFacturasGuias
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFacturasGuias))
      Me.btnExcel = New System.Windows.Forms.Button()
      Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
      Me.spcFletes = New System.Windows.Forms.SplitContainer()
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
      Me.c1grdGuias = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.AcPanelCaption5 = New ACControles.ACPanelCaption()
      Me.bnavPagos = New System.Windows.Forms.BindingNavigator(Me.components)
      Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
      Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox()
      Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripButton17 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton18 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbtnAbrirGuia = New System.Windows.Forms.ToolStripButton()
      Me.grpBusqueda = New System.Windows.Forms.GroupBox()
      Me.btnConsultar = New System.Windows.Forms.Button()
      Me.chkTodos = New System.Windows.Forms.CheckBox()
      Me.rbtnDatos = New System.Windows.Forms.RadioButton()
      Me.acFecha = New ACControles.ACFecha(Me.components)
      Me.grpCliente = New System.Windows.Forms.GroupBox()
      Me.rbtnNroOrdenCompra = New System.Windows.Forms.RadioButton()
      Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
      Me.rbtnProveedor = New System.Windows.Forms.RadioButton()
      Me.rbtnDocVenta = New System.Windows.Forms.RadioButton()
      Me.grpDocumentos = New System.Windows.Forms.GroupBox()
      Me.ComboBox2 = New System.Windows.Forms.ComboBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox()
      Me.txtBusNumero = New ACControles.ACTextBoxAyuda()
      CType(Me.spcFletes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spcFletes.Panel1.SuspendLayout()
      Me.spcFletes.Panel2.SuspendLayout()
      Me.spcFletes.SuspendLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavBusqueda.SuspendLayout()
      CType(Me.c1grdGuias, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavPagos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavPagos.SuspendLayout()
      Me.grpBusqueda.SuspendLayout()
      Me.grpCliente.SuspendLayout()
      Me.grpDocumentos.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnExcel
      '
      Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnExcel.Image = Global.ACPTransportes.My.Resources.Resources.Excel2_32x32
      Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExcel.Location = New System.Drawing.Point(828, 66)
      Me.btnExcel.Name = "btnExcel"
      Me.btnExcel.Size = New System.Drawing.Size(43, 41)
      Me.btnExcel.TabIndex = 8
      Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExcel.UseVisualStyleBackColor = True
      '
      'AcPanelCaption1
      '
      Me.AcPanelCaption1.ACCaption = "Facturas"
      Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption1.Name = "AcPanelCaption1"
      Me.AcPanelCaption1.Size = New System.Drawing.Size(879, 30)
      Me.AcPanelCaption1.TabIndex = 52
      '
      'spcFletes
      '
      Me.spcFletes.Dock = System.Windows.Forms.DockStyle.Fill
      Me.spcFletes.Location = New System.Drawing.Point(0, 148)
      Me.spcFletes.Name = "spcFletes"
      Me.spcFletes.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'spcFletes.Panel1
      '
      Me.spcFletes.Panel1.Controls.Add(Me.c1grdBusqueda)
      Me.spcFletes.Panel1.Controls.Add(Me.bnavBusqueda)
      '
      'spcFletes.Panel2
      '
      Me.spcFletes.Panel2.Controls.Add(Me.c1grdGuias)
      Me.spcFletes.Panel2.Controls.Add(Me.AcPanelCaption5)
      Me.spcFletes.Panel2.Controls.Add(Me.bnavPagos)
      Me.spcFletes.Size = New System.Drawing.Size(879, 327)
      Me.spcFletes.SplitterDistance = 217
      Me.spcFletes.TabIndex = 67
      '
      'c1grdBusqueda
      '
      Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 0)
      Me.c1grdBusqueda.Name = "c1grdBusqueda"
      Me.c1grdBusqueda.Rows.Count = 2
      Me.c1grdBusqueda.Rows.DefaultSize = 20
      Me.c1grdBusqueda.Size = New System.Drawing.Size(879, 192)
      Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
      Me.c1grdBusqueda.TabIndex = 62
      '
      'bnavBusqueda
      '
      Me.bnavBusqueda.AddNewItem = Me.BindingNavigatorAddNewItem
      Me.bnavBusqueda.CountItem = Me.BindingNavigatorCountItem
      Me.bnavBusqueda.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 192)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(879, 25)
      Me.bnavBusqueda.TabIndex = 60
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
      Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
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
      'c1grdGuias
      '
      Me.c1grdGuias.ColumnInfo = "2,1,0,0,0,95,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdGuias.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdGuias.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.c1grdGuias.Location = New System.Drawing.Point(0, 22)
      Me.c1grdGuias.Name = "c1grdGuias"
      Me.c1grdGuias.Rows.Count = 2
      Me.c1grdGuias.Rows.DefaultSize = 19
      Me.c1grdGuias.Size = New System.Drawing.Size(879, 59)
      Me.c1grdGuias.StyleInfo = resources.GetString("c1grdGuias.StyleInfo")
      Me.c1grdGuias.TabIndex = 64
      '
      'AcPanelCaption5
      '
      Me.AcPanelCaption5.ACCaption = "Guias de Remision"
      Me.AcPanelCaption5.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption5.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption5.Name = "AcPanelCaption5"
      Me.AcPanelCaption5.Size = New System.Drawing.Size(879, 22)
      Me.AcPanelCaption5.TabIndex = 65
      '
      'bnavPagos
      '
      Me.bnavPagos.AddNewItem = Me.ToolStripButton13
      Me.bnavPagos.CountItem = Me.ToolStripLabel3
      Me.bnavPagos.DeleteItem = Me.ToolStripButton14
      Me.bnavPagos.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavPagos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton15, Me.ToolStripButton16, Me.ToolStripSeparator7, Me.ToolStripTextBox3, Me.ToolStripLabel3, Me.ToolStripSeparator8, Me.ToolStripButton17, Me.ToolStripButton18, Me.ToolStripSeparator9, Me.ToolStripButton13, Me.ToolStripButton14, Me.tsbtnAbrirGuia})
      Me.bnavPagos.Location = New System.Drawing.Point(0, 81)
      Me.bnavPagos.MoveFirstItem = Me.ToolStripButton15
      Me.bnavPagos.MoveLastItem = Me.ToolStripButton18
      Me.bnavPagos.MoveNextItem = Me.ToolStripButton17
      Me.bnavPagos.MovePreviousItem = Me.ToolStripButton16
      Me.bnavPagos.Name = "bnavPagos"
      Me.bnavPagos.PositionItem = Me.ToolStripTextBox3
      Me.bnavPagos.Size = New System.Drawing.Size(879, 25)
      Me.bnavPagos.TabIndex = 63
      Me.bnavPagos.Text = "BindingNavigator1"
      '
      'ToolStripButton13
      '
      Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
      Me.ToolStripButton13.Name = "ToolStripButton13"
      Me.ToolStripButton13.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton13.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton13.Text = "Add new"
      Me.ToolStripButton13.Visible = False
      '
      'ToolStripLabel3
      '
      Me.ToolStripLabel3.Name = "ToolStripLabel3"
      Me.ToolStripLabel3.Size = New System.Drawing.Size(35, 22)
      Me.ToolStripLabel3.Text = "of {0}"
      Me.ToolStripLabel3.ToolTipText = "Total number of items"
      '
      'ToolStripButton14
      '
      Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton14.Image = CType(resources.GetObject("ToolStripButton14.Image"), System.Drawing.Image)
      Me.ToolStripButton14.Name = "ToolStripButton14"
      Me.ToolStripButton14.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton14.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton14.Text = "Delete"
      Me.ToolStripButton14.Visible = False
      '
      'ToolStripButton15
      '
      Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton15.Image = CType(resources.GetObject("ToolStripButton15.Image"), System.Drawing.Image)
      Me.ToolStripButton15.Name = "ToolStripButton15"
      Me.ToolStripButton15.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton15.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton15.Text = "Move first"
      '
      'ToolStripButton16
      '
      Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton16.Image = CType(resources.GetObject("ToolStripButton16.Image"), System.Drawing.Image)
      Me.ToolStripButton16.Name = "ToolStripButton16"
      Me.ToolStripButton16.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton16.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton16.Text = "Move previous"
      '
      'ToolStripSeparator7
      '
      Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
      Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripTextBox3
      '
      Me.ToolStripTextBox3.AccessibleName = "Position"
      Me.ToolStripTextBox3.AutoSize = False
      Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
      Me.ToolStripTextBox3.Size = New System.Drawing.Size(50, 23)
      Me.ToolStripTextBox3.Text = "0"
      Me.ToolStripTextBox3.ToolTipText = "Current position"
      '
      'ToolStripSeparator8
      '
      Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
      Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripButton17
      '
      Me.ToolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton17.Image = CType(resources.GetObject("ToolStripButton17.Image"), System.Drawing.Image)
      Me.ToolStripButton17.Name = "ToolStripButton17"
      Me.ToolStripButton17.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton17.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton17.Text = "Move next"
      '
      'ToolStripButton18
      '
      Me.ToolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton18.Image = CType(resources.GetObject("ToolStripButton18.Image"), System.Drawing.Image)
      Me.ToolStripButton18.Name = "ToolStripButton18"
      Me.ToolStripButton18.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton18.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton18.Text = "Move last"
      '
      'ToolStripSeparator9
      '
      Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
      Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
      '
      'tsbtnAbrirGuia
      '
      Me.tsbtnAbrirGuia.Image = Global.ACPTransportes.My.Resources.Resources.ACReporte_32x32
      Me.tsbtnAbrirGuia.Name = "tsbtnAbrirGuia"
      Me.tsbtnAbrirGuia.RightToLeftAutoMirrorImage = True
      Me.tsbtnAbrirGuia.Size = New System.Drawing.Size(80, 22)
      Me.tsbtnAbrirGuia.Text = "Abrir Guia"
      '
      'grpBusqueda
      '
      Me.grpBusqueda.Controls.Add(Me.btnExcel)
      Me.grpBusqueda.Controls.Add(Me.btnConsultar)
      Me.grpBusqueda.Controls.Add(Me.chkTodos)
      Me.grpBusqueda.Controls.Add(Me.rbtnDatos)
      Me.grpBusqueda.Controls.Add(Me.acFecha)
      Me.grpBusqueda.Controls.Add(Me.grpCliente)
      Me.grpBusqueda.Controls.Add(Me.rbtnDocVenta)
      Me.grpBusqueda.Controls.Add(Me.grpDocumentos)
      Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpBusqueda.Location = New System.Drawing.Point(0, 30)
      Me.grpBusqueda.Name = "grpBusqueda"
      Me.grpBusqueda.Size = New System.Drawing.Size(879, 118)
      Me.grpBusqueda.TabIndex = 68
      Me.grpBusqueda.TabStop = False
      Me.grpBusqueda.Text = "Opciones de Busqueda, Documentos de Venta"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(723, 66)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(99, 41)
      Me.btnConsultar.TabIndex = 31
      Me.btnConsultar.Text = "Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chkTodos
      '
      Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkTodos.AutoSize = True
      Me.chkTodos.Location = New System.Drawing.Point(443, 20)
      Me.chkTodos.Name = "chkTodos"
      Me.chkTodos.Size = New System.Drawing.Size(94, 17)
      Me.chkTodos.TabIndex = 26
      Me.chkTodos.Text = "Mostrar Todos"
      Me.chkTodos.UseVisualStyleBackColor = True
      '
      'rbtnDatos
      '
      Me.rbtnDatos.AutoSize = True
      Me.rbtnDatos.Checked = True
      Me.rbtnDatos.Location = New System.Drawing.Point(19, 46)
      Me.rbtnDatos.Name = "rbtnDatos"
      Me.rbtnDatos.Size = New System.Drawing.Size(174, 17)
      Me.rbtnDatos.TabIndex = 12
      Me.rbtnDatos.TabStop = True
      Me.rbtnDatos.Text = "Datos del Documento de Venta"
      Me.rbtnDatos.UseVisualStyleBackColor = True
      '
      'acFecha
      '
      Me.acFecha.ACFecha_A = New Date(2012, 6, 28, 11, 32, 35, 505)
      Me.acFecha.ACFecha_De = New Date(2012, 6, 28, 11, 32, 35, 503)
      Me.acFecha.ACFechaObligatoria = True
      Me.acFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
      Me.acFecha.ACHoyChecked = False
      Me.acFecha.ACIncrementoFecha_A = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.acFecha.ACIncrementoFecha_De = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.acFecha.ACIntervalos = ACControles.ACFecha.ACIntervalo.Ninguno
      Me.acFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.acFecha.Location = New System.Drawing.Point(543, 0)
      Me.acFecha.MaximumSize = New System.Drawing.Size(337, 43)
      Me.acFecha.MinimumSize = New System.Drawing.Size(337, 43)
      Me.acFecha.Name = "acFecha"
      Me.acFecha.Size = New System.Drawing.Size(337, 43)
      Me.acFecha.TabIndex = 25
      Me.acFecha.TabStop = False
      '
      'grpCliente
      '
      Me.grpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpCliente.Controls.Add(Me.rbtnNroOrdenCompra)
      Me.grpCliente.Controls.Add(Me.txtBusqueda)
      Me.grpCliente.Controls.Add(Me.rbtnProveedor)
      Me.grpCliente.Location = New System.Drawing.Point(6, 48)
      Me.grpCliente.Name = "grpCliente"
      Me.grpCliente.Size = New System.Drawing.Size(349, 63)
      Me.grpCliente.TabIndex = 13
      Me.grpCliente.TabStop = False
      '
      'rbtnNroOrdenCompra
      '
      Me.rbtnNroOrdenCompra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnNroOrdenCompra.AutoSize = True
      Me.rbtnNroOrdenCompra.Location = New System.Drawing.Point(141, 13)
      Me.rbtnNroOrdenCompra.Name = "rbtnNroOrdenCompra"
      Me.rbtnNroOrdenCompra.Size = New System.Drawing.Size(115, 17)
      Me.rbtnNroOrdenCompra.TabIndex = 3
      Me.rbtnNroOrdenCompra.Text = "Nro de Documento"
      Me.rbtnNroOrdenCompra.UseVisualStyleBackColor = True
      '
      'txtBusqueda
      '
      Me.txtBusqueda.ACActivarAyudaAuto = False
      Me.txtBusqueda.ACLongitudAceptada = 0
      Me.txtBusqueda.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBusqueda.Location = New System.Drawing.Point(6, 36)
      Me.txtBusqueda.MaxLength = 32767
      Me.txtBusqueda.Name = "txtBusqueda"
      Me.txtBusqueda.Size = New System.Drawing.Size(330, 20)
      Me.txtBusqueda.TabIndex = 1
      '
      'rbtnProveedor
      '
      Me.rbtnProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnProveedor.AutoSize = True
      Me.rbtnProveedor.Checked = True
      Me.rbtnProveedor.Location = New System.Drawing.Point(262, 13)
      Me.rbtnProveedor.Name = "rbtnProveedor"
      Me.rbtnProveedor.Size = New System.Drawing.Size(74, 17)
      Me.rbtnProveedor.TabIndex = 0
      Me.rbtnProveedor.TabStop = True
      Me.rbtnProveedor.Text = "Proveedor"
      Me.rbtnProveedor.UseVisualStyleBackColor = True
      '
      'rbtnDocVenta
      '
      Me.rbtnDocVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnDocVenta.AutoSize = True
      Me.rbtnDocVenta.Location = New System.Drawing.Point(374, 45)
      Me.rbtnDocVenta.Name = "rbtnDocVenta"
      Me.rbtnDocVenta.Size = New System.Drawing.Size(126, 17)
      Me.rbtnDocVenta.TabIndex = 11
      Me.rbtnDocVenta.Text = "Documento de Venta"
      Me.rbtnDocVenta.UseVisualStyleBackColor = True
      '
      'grpDocumentos
      '
      Me.grpDocumentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpDocumentos.Controls.Add(Me.ComboBox2)
      Me.grpDocumentos.Controls.Add(Me.Label18)
      Me.grpDocumentos.Controls.Add(Me.Label13)
      Me.grpDocumentos.Controls.Add(Me.Label15)
      Me.grpDocumentos.Controls.Add(Me.cmbTipoDocumento)
      Me.grpDocumentos.Controls.Add(Me.txtBusNumero)
      Me.grpDocumentos.Location = New System.Drawing.Point(361, 48)
      Me.grpDocumentos.Name = "grpDocumentos"
      Me.grpDocumentos.Size = New System.Drawing.Size(352, 63)
      Me.grpDocumentos.TabIndex = 14
      Me.grpDocumentos.TabStop = False
      '
      'ComboBox2
      '
      Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ComboBox2.FormattingEnabled = True
      Me.ComboBox2.Location = New System.Drawing.Point(182, 36)
      Me.ComboBox2.Name = "ComboBox2"
      Me.ComboBox2.Size = New System.Drawing.Size(51, 21)
      Me.ComboBox2.TabIndex = 3
      '
      'Label18
      '
      Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(245, 17)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(44, 13)
      Me.Label18.TabIndex = 4
      Me.Label18.Text = "Numero"
      '
      'Label13
      '
      Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(187, 17)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(31, 13)
      Me.Label13.TabIndex = 2
      Me.Label13.Text = "Serie"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(11, 17)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(54, 13)
      Me.Label15.TabIndex = 0
      Me.Label15.Text = "Tipo Doc."
      '
      'cmbTipoDocumento
      '
      Me.cmbTipoDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoDocumento.DropDownWidth = 250
      Me.cmbTipoDocumento.FormattingEnabled = True
      Me.cmbTipoDocumento.Location = New System.Drawing.Point(6, 36)
      Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
      Me.cmbTipoDocumento.Size = New System.Drawing.Size(174, 21)
      Me.cmbTipoDocumento.TabIndex = 1
      '
      'txtBusNumero
      '
      Me.txtBusNumero.ACActivarAyudaAuto = False
      Me.txtBusNumero.ACLongitudAceptada = 0
      Me.txtBusNumero.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.Numerico
      Me.txtBusNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBusNumero.Location = New System.Drawing.Point(237, 36)
      Me.txtBusNumero.MaxLength = 9
      Me.txtBusNumero.Name = "txtBusNumero"
      Me.txtBusNumero.Size = New System.Drawing.Size(101, 20)
      Me.txtBusNumero.TabIndex = 5
      '
      'CFacturasGuias
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(879, 475)
      Me.Controls.Add(Me.spcFletes)
      Me.Controls.Add(Me.grpBusqueda)
      Me.Controls.Add(Me.AcPanelCaption1)
      Me.Name = "CFacturasGuias"
      Me.Text = "Facturas"
      Me.spcFletes.Panel1.ResumeLayout(False)
      Me.spcFletes.Panel1.PerformLayout()
      Me.spcFletes.Panel2.ResumeLayout(False)
      Me.spcFletes.Panel2.PerformLayout()
      CType(Me.spcFletes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spcFletes.ResumeLayout(False)
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavBusqueda.ResumeLayout(False)
      Me.bnavBusqueda.PerformLayout()
      CType(Me.c1grdGuias, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavPagos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavPagos.ResumeLayout(False)
      Me.bnavPagos.PerformLayout()
      Me.grpBusqueda.ResumeLayout(False)
      Me.grpBusqueda.PerformLayout()
      Me.grpCliente.ResumeLayout(False)
      Me.grpCliente.PerformLayout()
      Me.grpDocumentos.ResumeLayout(False)
      Me.grpDocumentos.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents btnExcel As System.Windows.Forms.Button
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Friend WithEvents spcFletes As System.Windows.Forms.SplitContainer
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
   Friend WithEvents c1grdGuias As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents AcPanelCaption5 As ACControles.ACPanelCaption
   Friend WithEvents bnavPagos As System.Windows.Forms.BindingNavigator
   Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton15 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton16 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripTextBox3 As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton17 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton18 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents grpBusqueda As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As System.Windows.Forms.Button
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents rbtnDatos As System.Windows.Forms.RadioButton
   Friend WithEvents acFecha As ACControles.ACFecha
   Friend WithEvents grpCliente As System.Windows.Forms.GroupBox
   Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
   Friend WithEvents rbtnProveedor As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnDocVenta As System.Windows.Forms.RadioButton
   Friend WithEvents grpDocumentos As System.Windows.Forms.GroupBox
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
   Friend WithEvents txtBusNumero As ACControles.ACTextBoxAyuda
   Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
   Friend WithEvents rbtnNroOrdenCompra As System.Windows.Forms.RadioButton
   Friend WithEvents tsbtnAbrirGuia As System.Windows.Forms.ToolStripButton
End Class
