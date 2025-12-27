<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDocsPago
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDocsPago))
      Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
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
      Me.rbtnCliente = New System.Windows.Forms.RadioButton()
      Me.rbtnOperacion = New System.Windows.Forms.RadioButton()
      Me.acFecha = New ACControles.ACFecha(Me.components)
      Me.chkTodos = New System.Windows.Forms.CheckBox()
      Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
      Me.tabCheque = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.dtpChFechaCaja = New System.Windows.Forms.DateTimePicker()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.txtChNumeroOperacion = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtChDepositante = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtChCodGirador = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbChCuenta = New System.Windows.Forms.ComboBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.txtChNumeroCheque = New System.Windows.Forms.TextBox()
      Me.actxnChImporte = New ACControles.ACTextBoxNumerico()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.rbtnChDolares = New System.Windows.Forms.RadioButton()
      Me.rbtnChSoles = New System.Windows.Forms.RadioButton()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.dtpChFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.cmbChBanco = New System.Windows.Forms.ComboBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.tabDeposito = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.cmbDeMoneda = New System.Windows.Forms.ComboBox()
      Me.cmbDeTipoCuenta = New System.Windows.Forms.ComboBox()
      Me.Label40 = New System.Windows.Forms.Label()
      Me.cmbDeNumeroCuenta = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtDeNumeroOperacion = New System.Windows.Forms.TextBox()
      Me.actxnDeImporte = New ACControles.ACTextBoxNumerico()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.dtpDeFechaVoucher = New System.Windows.Forms.DateTimePicker()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.dtpDeFechaCaja = New System.Windows.Forms.DateTimePicker()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.cmbDeBanco = New System.Windows.Forms.ComboBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.tabLetras = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.pnlDatos = New System.Windows.Forms.Panel()
      Me.cmbLeNroCuenta = New System.Windows.Forms.ComboBox()
      Me.lblLeNroCuenta = New System.Windows.Forms.Label()
      Me.cmbLeBanco = New System.Windows.Forms.ComboBox()
      Me.lblLeBanco = New System.Windows.Forms.Label()
      Me.grpMoneda = New System.Windows.Forms.GroupBox()
      Me.rbtnLeDolares = New System.Windows.Forms.RadioButton()
      Me.rbtnLeSoles = New System.Windows.Forms.RadioButton()
      Me.txtLeReGirador = New System.Windows.Forms.TextBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.grpLetra = New System.Windows.Forms.GroupBox()
      Me.txtTelefono = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.txtRUC = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.txtLocalidad = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtDomicilio = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.txtAceptante = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.txtGlosa = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.txtLeNumero = New System.Windows.Forms.TextBox()
      Me.actxnImporte = New ACControles.ACTextBoxNumerico()
      Me.lblImporte = New System.Windows.Forms.Label()
      Me.lblNumero = New System.Windows.Forms.Label()
      Me.dtpLeFechaVencimiento = New System.Windows.Forms.DateTimePicker()
      Me.lblFechaDoc = New System.Windows.Forms.Label()
      Me.dtpLeFechaGiro = New System.Windows.Forms.DateTimePicker()
      Me.lblFecha = New System.Windows.Forms.Label()
      Me.txtLeLugarGiro = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.tpgDetraccion = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.txtDtNumOperacion = New System.Windows.Forms.TextBox()
      Me.actxnDtImporte = New ACControles.ACTextBoxNumerico()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.rbtnDtDolares = New System.Windows.Forms.RadioButton()
      Me.rbtnDtSoles = New System.Windows.Forms.RadioButton()
      Me.Label26 = New System.Windows.Forms.Label()
      Me.dtpDtFecVoucher = New System.Windows.Forms.DateTimePicker()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.dtpDtFecCaja = New System.Windows.Forms.DateTimePicker()
      Me.Label28 = New System.Windows.Forms.Label()
      Me.cmbDtBanco = New System.Windows.Forms.ComboBox()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.tpgNotaCredito = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.txtNCMotivo = New System.Windows.Forms.TextBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.GroupBox5 = New System.Windows.Forms.GroupBox()
      Me.Label35 = New System.Windows.Forms.Label()
      Me.txtSerie = New System.Windows.Forms.TextBox()
      Me.actxnNumero = New ACControles.ACTextBoxNumerico()
      Me.Label36 = New System.Windows.Forms.Label()
      Me.Label37 = New System.Windows.Forms.Label()
      Me.lblTipoDocumento = New System.Windows.Forms.Label()
      Me.cmbNCTipoDocumento = New System.Windows.Forms.ComboBox()
      Me.dtpNCFecDocumento = New System.Windows.Forms.DateTimePicker()
      Me.GroupBox4 = New System.Windows.Forms.GroupBox()
      Me.rbtnNCDolares = New System.Windows.Forms.RadioButton()
      Me.rbtnNCSoles = New System.Windows.Forms.RadioButton()
      Me.actxnNCImporte = New ACControles.ACTextBoxNumerico()
      Me.Label30 = New System.Windows.Forms.Label()
      Me.dtpNCFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label33 = New System.Windows.Forms.Label()
      Me.tpgRecEgreInterno = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.txtREGirador = New System.Windows.Forms.TextBox()
      Me.Label39 = New System.Windows.Forms.Label()
      Me.txtRENumero = New System.Windows.Forms.TextBox()
      Me.Label38 = New System.Windows.Forms.Label()
      Me.txtREConcepto = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.GroupBox6 = New System.Windows.Forms.GroupBox()
      Me.rbtnRIDolares = New System.Windows.Forms.RadioButton()
      Me.rbtnRISoles = New System.Windows.Forms.RadioButton()
      Me.actxnREImporte = New ACControles.ACTextBoxNumerico()
      Me.Label32 = New System.Windows.Forms.Label()
      Me.dtpREFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label34 = New System.Windows.Forms.Label()
      Me.eprError = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.acpnlTitulo = New ACControles.ACPanelCaption()
      Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
      Me.acbtnSeleccionar = New ACControles.ACToolStripButton(Me.components)
      Me.tabMantenimiento.SuspendLayout()
      Me.tabBusqueda.SuspendLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavBusqueda.SuspendLayout()
      Me.grpBusqueda.SuspendLayout()
      Me.tabCheque.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.tabDeposito.SuspendLayout()
      Me.tabLetras.SuspendLayout()
      Me.pnlDatos.SuspendLayout()
      Me.grpMoneda.SuspendLayout()
      Me.grpLetra.SuspendLayout()
      Me.tpgDetraccion.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.tpgNotaCredito.SuspendLayout()
      Me.GroupBox5.SuspendLayout()
      Me.GroupBox4.SuspendLayout()
      Me.tpgRecEgreInterno.SuspendLayout()
      Me.GroupBox6.SuspendLayout()
      CType(Me.eprError, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.tabMantenimiento.SelectedIndex = 0
      Me.tabMantenimiento.ShowDropSelect = False
      Me.tabMantenimiento.Size = New System.Drawing.Size(484, 442)
      Me.tabMantenimiento.TabIndex = 10
      Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabBusqueda, Me.tabCheque, Me.tabDeposito, Me.tabLetras, Me.tpgDetraccion, Me.tpgNotaCredito, Me.tpgRecEgreInterno})
      Me.tabMantenimiento.TextTips = True
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
      Me.tabBusqueda.Size = New System.Drawing.Size(482, 417)
      Me.tabBusqueda.TabIndex = 5
      Me.tabBusqueda.Title = "Busqueda"
      Me.tabBusqueda.ToolTip = "Busqueda"
      '
      'c1grdBusqueda
      '
      Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 80)
      Me.c1grdBusqueda.Name = "c1grdBusqueda"
      Me.c1grdBusqueda.Rows.Count = 2
      Me.c1grdBusqueda.Rows.DefaultSize = 20
      Me.c1grdBusqueda.Size = New System.Drawing.Size(482, 312)
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
      Me.bnavBusqueda.Location = New System.Drawing.Point(0, 392)
      Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavBusqueda.Name = "bnavBusqueda"
      Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavBusqueda.Size = New System.Drawing.Size(482, 25)
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
      Me.grpBusqueda.Controls.Add(Me.rbtnCliente)
      Me.grpBusqueda.Controls.Add(Me.rbtnOperacion)
      Me.grpBusqueda.Controls.Add(Me.acFecha)
      Me.grpBusqueda.Controls.Add(Me.chkTodos)
      Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
      Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
      Me.grpBusqueda.Name = "grpBusqueda"
      Me.grpBusqueda.Size = New System.Drawing.Size(482, 80)
      Me.grpBusqueda.TabIndex = 1
      Me.grpBusqueda.TabStop = False
      Me.grpBusqueda.Text = "Opciones de Busqueda"
      '
      'rbtnCliente
      '
      Me.rbtnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnCliente.AutoSize = True
      Me.rbtnCliente.Location = New System.Drawing.Point(399, 53)
      Me.rbtnCliente.Name = "rbtnCliente"
      Me.rbtnCliente.Size = New System.Drawing.Size(62, 19)
      Me.rbtnCliente.TabIndex = 28
      Me.rbtnCliente.Text = "Cliente"
      Me.rbtnCliente.UseVisualStyleBackColor = True
      '
      'rbtnOperacion
      '
      Me.rbtnOperacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rbtnOperacion.AutoSize = True
      Me.rbtnOperacion.Checked = True
      Me.rbtnOperacion.Location = New System.Drawing.Point(277, 53)
      Me.rbtnOperacion.Name = "rbtnOperacion"
      Me.rbtnOperacion.Size = New System.Drawing.Size(106, 19)
      Me.rbtnOperacion.TabIndex = 27
      Me.rbtnOperacion.TabStop = True
      Me.rbtnOperacion.Text = "Nro. Operacion"
      Me.rbtnOperacion.UseVisualStyleBackColor = True
      '
      'acFecha
      '
      Me.acFecha.ACFecha_A = New Date(2012, 10, 25, 11, 18, 50, 765)
      Me.acFecha.ACFecha_De = New Date(2012, 10, 25, 11, 18, 50, 763)
      Me.acFecha.ACFechaObligatoria = True
      Me.acFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
      Me.acFecha.ACHoyChecked = False
      Me.acFecha.ACIncrementoFecha_A = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.acFecha.ACIncrementoFecha_De = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.acFecha.ACIntervalos = ACControles.ACFecha.ACIntervalo.Ninguno
      Me.acFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.acFecha.Location = New System.Drawing.Point(145, 0)
      Me.acFecha.MaximumSize = New System.Drawing.Size(337, 43)
      Me.acFecha.MinimumSize = New System.Drawing.Size(337, 43)
      Me.acFecha.Name = "acFecha"
      Me.acFecha.Size = New System.Drawing.Size(337, 43)
      Me.acFecha.TabIndex = 26
      Me.acFecha.TabStop = False
      '
      'chkTodos
      '
      Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkTodos.AutoSize = True
      Me.chkTodos.Location = New System.Drawing.Point(33, 20)
      Me.chkTodos.Name = "chkTodos"
      Me.chkTodos.Size = New System.Drawing.Size(103, 19)
      Me.chkTodos.TabIndex = 7
      Me.chkTodos.Text = "Mostrar Todos"
      Me.chkTodos.UseVisualStyleBackColor = True
      '
      'txtBusqueda
      '
      Me.txtBusqueda.ACActivarAyudaAuto = False
      Me.txtBusqueda.ACLongitudAceptada = 0
      Me.txtBusqueda.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBusqueda.Location = New System.Drawing.Point(13, 49)
      Me.txtBusqueda.MaxLength = 32767
      Me.txtBusqueda.Name = "txtBusqueda"
      Me.txtBusqueda.Size = New System.Drawing.Size(258, 23)
      Me.txtBusqueda.TabIndex = 0
      '
      'tabCheque
      '
      Me.tabCheque.Controls.Add(Me.Panel1)
      Me.tabCheque.InactiveBackColor = System.Drawing.Color.Empty
      Me.tabCheque.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tabCheque.InactiveTextColor = System.Drawing.Color.Empty
      Me.tabCheque.Location = New System.Drawing.Point(1, 1)
      Me.tabCheque.Name = "tabCheque"
      Me.tabCheque.SelectBackColor = System.Drawing.Color.Empty
      Me.tabCheque.Selected = False
      Me.tabCheque.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tabCheque.SelectTextColor = System.Drawing.Color.Empty
      Me.tabCheque.Size = New System.Drawing.Size(482, 417)
      Me.tabCheque.TabIndex = 6
      Me.tabCheque.Title = "cheque"
      Me.tabCheque.ToolTip = "Page"
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.dtpChFechaCaja)
      Me.Panel1.Controls.Add(Me.Label23)
      Me.Panel1.Controls.Add(Me.txtChNumeroOperacion)
      Me.Panel1.Controls.Add(Me.Label3)
      Me.Panel1.Controls.Add(Me.txtChDepositante)
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.txtChCodGirador)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.cmbChCuenta)
      Me.Panel1.Controls.Add(Me.Label17)
      Me.Panel1.Controls.Add(Me.txtChNumeroCheque)
      Me.Panel1.Controls.Add(Me.actxnChImporte)
      Me.Panel1.Controls.Add(Me.Label18)
      Me.Panel1.Controls.Add(Me.GroupBox2)
      Me.Panel1.Controls.Add(Me.Label19)
      Me.Panel1.Controls.Add(Me.dtpChFecha)
      Me.Panel1.Controls.Add(Me.Label21)
      Me.Panel1.Controls.Add(Me.cmbChBanco)
      Me.Panel1.Controls.Add(Me.Label22)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(482, 417)
      Me.Panel1.TabIndex = 2
      '
      'dtpChFechaCaja
      '
      Me.dtpChFechaCaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpChFechaCaja.Location = New System.Drawing.Point(126, 230)
      Me.dtpChFechaCaja.Name = "dtpChFechaCaja"
      Me.dtpChFechaCaja.Size = New System.Drawing.Size(121, 23)
      Me.dtpChFechaCaja.TabIndex = 18
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.Location = New System.Drawing.Point(52, 234)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(70, 15)
      Me.Label23.TabIndex = 17
      Me.Label23.Text = "Fecha Caja :"
      '
      'txtChNumeroOperacion
      '
      Me.txtChNumeroOperacion.Location = New System.Drawing.Point(126, 122)
      Me.txtChNumeroOperacion.MaxLength = 25
      Me.txtChNumeroOperacion.Name = "txtChNumeroOperacion"
      Me.txtChNumeroOperacion.Size = New System.Drawing.Size(121, 23)
      Me.txtChNumeroOperacion.TabIndex = 9
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(7, 125)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(115, 15)
      Me.Label3.TabIndex = 8
      Me.Label3.Text = "Numero Operación :"
      '
      'txtChDepositante
      '
      Me.txtChDepositante.Location = New System.Drawing.Point(126, 176)
      Me.txtChDepositante.MaxLength = 25
      Me.txtChDepositante.Name = "txtChDepositante"
      Me.txtChDepositante.Size = New System.Drawing.Size(288, 23)
      Me.txtChDepositante.TabIndex = 14
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(46, 179)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(76, 15)
      Me.Label2.TabIndex = 13
      Me.Label2.Text = "Depositante :"
      '
      'txtChCodGirador
      '
      Me.txtChCodGirador.Location = New System.Drawing.Point(126, 68)
      Me.txtChCodGirador.MaxLength = 25
      Me.txtChCodGirador.Name = "txtChCodGirador"
      Me.txtChCodGirador.Size = New System.Drawing.Size(121, 23)
      Me.txtChCodGirador.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(28, 71)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(94, 15)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Codigo Girador :"
      '
      'cmbChCuenta
      '
      Me.cmbChCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbChCuenta.FormattingEnabled = True
      Me.cmbChCuenta.Location = New System.Drawing.Point(126, 41)
      Me.cmbChCuenta.Name = "cmbChCuenta"
      Me.cmbChCuenta.Size = New System.Drawing.Size(288, 23)
      Me.cmbChCuenta.TabIndex = 3
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.Location = New System.Drawing.Point(45, 44)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(77, 15)
      Me.Label17.TabIndex = 2
      Me.Label17.Text = "Nro. Cuenta :"
      '
      'txtChNumeroCheque
      '
      Me.txtChNumeroCheque.Location = New System.Drawing.Point(126, 95)
      Me.txtChNumeroCheque.MaxLength = 25
      Me.txtChNumeroCheque.Name = "txtChNumeroCheque"
      Me.txtChNumeroCheque.Size = New System.Drawing.Size(121, 23)
      Me.txtChNumeroCheque.TabIndex = 7
      '
      'actxnChImporte
      '
      Me.actxnChImporte.ACEnteros = 8
      Me.actxnChImporte.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnChImporte.ACFormato = "##,###,##0.00"
      Me.actxnChImporte.ACNegativo = True
      Me.actxnChImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnChImporte.Location = New System.Drawing.Point(126, 149)
      Me.actxnChImporte.MaxLength = 12
      Me.actxnChImporte.Name = "actxnChImporte"
      Me.actxnChImporte.Size = New System.Drawing.Size(121, 23)
      Me.actxnChImporte.TabIndex = 11
      Me.actxnChImporte.Text = "0.00"
      Me.actxnChImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(67, 152)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(55, 15)
      Me.Label18.TabIndex = 10
      Me.Label18.Text = "Importe :"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.rbtnChDolares)
      Me.GroupBox2.Controls.Add(Me.rbtnChSoles)
      Me.GroupBox2.Location = New System.Drawing.Point(267, 68)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(147, 75)
      Me.GroupBox2.TabIndex = 12
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Moneda"
      '
      'rbtnChDolares
      '
      Me.rbtnChDolares.AutoSize = True
      Me.rbtnChDolares.Location = New System.Drawing.Point(14, 45)
      Me.rbtnChDolares.Name = "rbtnChDolares"
      Me.rbtnChDolares.Size = New System.Drawing.Size(130, 19)
      Me.rbtnChDolares.TabIndex = 1
      Me.rbtnChDolares.Text = "Dolares Americanos"
      Me.rbtnChDolares.UseVisualStyleBackColor = True
      '
      'rbtnChSoles
      '
      Me.rbtnChSoles.AutoSize = True
      Me.rbtnChSoles.Checked = True
      Me.rbtnChSoles.Location = New System.Drawing.Point(14, 21)
      Me.rbtnChSoles.Name = "rbtnChSoles"
      Me.rbtnChSoles.Size = New System.Drawing.Size(95, 19)
      Me.rbtnChSoles.TabIndex = 0
      Me.rbtnChSoles.TabStop = True
      Me.rbtnChSoles.Text = "Nuevos Soles"
      Me.rbtnChSoles.UseVisualStyleBackColor = True
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.Location = New System.Drawing.Point(21, 98)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(101, 15)
      Me.Label19.TabIndex = 6
      Me.Label19.Text = "Numero Cheque :"
      '
      'dtpChFecha
      '
      Me.dtpChFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpChFecha.Location = New System.Drawing.Point(126, 203)
      Me.dtpChFecha.Name = "dtpChFecha"
      Me.dtpChFecha.Size = New System.Drawing.Size(121, 23)
      Me.dtpChFecha.TabIndex = 16
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.Location = New System.Drawing.Point(78, 206)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(44, 15)
      Me.Label21.TabIndex = 15
      Me.Label21.Text = "Fecha :"
      '
      'cmbChBanco
      '
      Me.cmbChBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbChBanco.FormattingEnabled = True
      Me.cmbChBanco.Location = New System.Drawing.Point(126, 14)
      Me.cmbChBanco.Name = "cmbChBanco"
      Me.cmbChBanco.Size = New System.Drawing.Size(288, 23)
      Me.cmbChBanco.TabIndex = 1
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.Location = New System.Drawing.Point(76, 17)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(46, 15)
      Me.Label22.TabIndex = 0
      Me.Label22.Text = "Banco :"
      '
      'tabDeposito
      '
      Me.tabDeposito.Controls.Add(Me.cmbDeMoneda)
      Me.tabDeposito.Controls.Add(Me.cmbDeTipoCuenta)
      Me.tabDeposito.Controls.Add(Me.Label40)
      Me.tabDeposito.Controls.Add(Me.cmbDeNumeroCuenta)
      Me.tabDeposito.Controls.Add(Me.Label4)
      Me.tabDeposito.Controls.Add(Me.txtDeNumeroOperacion)
      Me.tabDeposito.Controls.Add(Me.actxnDeImporte)
      Me.tabDeposito.Controls.Add(Me.Label5)
      Me.tabDeposito.Controls.Add(Me.Label6)
      Me.tabDeposito.Controls.Add(Me.dtpDeFechaVoucher)
      Me.tabDeposito.Controls.Add(Me.Label7)
      Me.tabDeposito.Controls.Add(Me.dtpDeFechaCaja)
      Me.tabDeposito.Controls.Add(Me.Label16)
      Me.tabDeposito.Controls.Add(Me.cmbDeBanco)
      Me.tabDeposito.Controls.Add(Me.Label20)
      Me.tabDeposito.InactiveBackColor = System.Drawing.Color.Empty
      Me.tabDeposito.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tabDeposito.InactiveTextColor = System.Drawing.Color.Empty
      Me.tabDeposito.Location = New System.Drawing.Point(1, 1)
      Me.tabDeposito.Name = "tabDeposito"
      Me.tabDeposito.SelectBackColor = System.Drawing.Color.Empty
      Me.tabDeposito.Selected = False
      Me.tabDeposito.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tabDeposito.SelectTextColor = System.Drawing.Color.Empty
      Me.tabDeposito.Size = New System.Drawing.Size(482, 417)
      Me.tabDeposito.TabIndex = 8
      Me.tabDeposito.Title = "deposito"
      Me.tabDeposito.ToolTip = "Page"
      '
      'cmbDeMoneda
      '
      Me.cmbDeMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
      Me.cmbDeMoneda.Enabled = False
      Me.cmbDeMoneda.FormattingEnabled = True
      Me.cmbDeMoneda.Location = New System.Drawing.Point(132, 95)
      Me.cmbDeMoneda.Name = "cmbDeMoneda"
      Me.cmbDeMoneda.Size = New System.Drawing.Size(288, 23)
      Me.cmbDeMoneda.TabIndex = 16
      '
      'cmbDeTipoCuenta
      '
      Me.cmbDeTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
      Me.cmbDeTipoCuenta.Enabled = False
      Me.cmbDeTipoCuenta.FormattingEnabled = True
      Me.cmbDeTipoCuenta.Location = New System.Drawing.Point(132, 69)
      Me.cmbDeTipoCuenta.Name = "cmbDeTipoCuenta"
      Me.cmbDeTipoCuenta.Size = New System.Drawing.Size(288, 23)
      Me.cmbDeTipoCuenta.TabIndex = 14
      '
      'Label40
      '
      Me.Label40.AutoSize = True
      Me.Label40.Enabled = False
      Me.Label40.Location = New System.Drawing.Point(33, 73)
      Me.Label40.Name = "Label40"
      Me.Label40.Size = New System.Drawing.Size(94, 15)
      Me.Label40.TabIndex = 13
      Me.Label40.Text = "Tipo de Cuenta :"
      '
      'cmbDeNumeroCuenta
      '
      Me.cmbDeNumeroCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDeNumeroCuenta.FormattingEnabled = True
      Me.cmbDeNumeroCuenta.Location = New System.Drawing.Point(132, 43)
      Me.cmbDeNumeroCuenta.Name = "cmbDeNumeroCuenta"
      Me.cmbDeNumeroCuenta.Size = New System.Drawing.Size(288, 23)
      Me.cmbDeNumeroCuenta.TabIndex = 3
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(50, 46)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(77, 15)
      Me.Label4.TabIndex = 2
      Me.Label4.Text = "Nro. Cuenta :"
      '
      'txtDeNumeroOperacion
      '
      Me.txtDeNumeroOperacion.Location = New System.Drawing.Point(132, 179)
      Me.txtDeNumeroOperacion.MaxLength = 25
      Me.txtDeNumeroOperacion.Name = "txtDeNumeroOperacion"
      Me.txtDeNumeroOperacion.Size = New System.Drawing.Size(121, 23)
      Me.txtDeNumeroOperacion.TabIndex = 9
      '
      'actxnDeImporte
      '
      Me.actxnDeImporte.ACEnteros = 8
      Me.actxnDeImporte.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnDeImporte.ACFormato = "##,###,##0.00"
      Me.actxnDeImporte.ACNegativo = True
      Me.actxnDeImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnDeImporte.Location = New System.Drawing.Point(132, 205)
      Me.actxnDeImporte.MaxLength = 12
      Me.actxnDeImporte.Name = "actxnDeImporte"
      Me.actxnDeImporte.Size = New System.Drawing.Size(121, 23)
      Me.actxnDeImporte.TabIndex = 12
      Me.actxnDeImporte.Text = "0.00"
      Me.actxnDeImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(72, 209)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(55, 15)
      Me.Label5.TabIndex = 11
      Me.Label5.Text = "Importe :"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(12, 182)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(115, 15)
      Me.Label6.TabIndex = 8
      Me.Label6.Text = "Numero Operación :"
      '
      'dtpDeFechaVoucher
      '
      Me.dtpDeFechaVoucher.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDeFechaVoucher.Location = New System.Drawing.Point(132, 151)
      Me.dtpDeFechaVoucher.Name = "dtpDeFechaVoucher"
      Me.dtpDeFechaVoucher.Size = New System.Drawing.Size(121, 23)
      Me.dtpDeFechaVoucher.TabIndex = 7
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(36, 155)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(91, 15)
      Me.Label7.TabIndex = 6
      Me.Label7.Text = "Fecha Voucher :"
      '
      'dtpDeFechaCaja
      '
      Me.dtpDeFechaCaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDeFechaCaja.Location = New System.Drawing.Point(132, 124)
      Me.dtpDeFechaCaja.Name = "dtpDeFechaCaja"
      Me.dtpDeFechaCaja.Size = New System.Drawing.Size(121, 23)
      Me.dtpDeFechaCaja.TabIndex = 5
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.Location = New System.Drawing.Point(57, 128)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(70, 15)
      Me.Label16.TabIndex = 4
      Me.Label16.Text = "Fecha Caja :"
      '
      'cmbDeBanco
      '
      Me.cmbDeBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDeBanco.FormattingEnabled = True
      Me.cmbDeBanco.Location = New System.Drawing.Point(132, 16)
      Me.cmbDeBanco.Name = "cmbDeBanco"
      Me.cmbDeBanco.Size = New System.Drawing.Size(288, 23)
      Me.cmbDeBanco.TabIndex = 1
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.Location = New System.Drawing.Point(81, 20)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(46, 15)
      Me.Label20.TabIndex = 0
      Me.Label20.Text = "Banco :"
      '
      'tabLetras
      '
      Me.tabLetras.Controls.Add(Me.pnlDatos)
      Me.tabLetras.InactiveBackColor = System.Drawing.Color.Empty
      Me.tabLetras.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tabLetras.InactiveTextColor = System.Drawing.Color.Empty
      Me.tabLetras.Location = New System.Drawing.Point(1, 1)
      Me.tabLetras.Name = "tabLetras"
      Me.tabLetras.SelectBackColor = System.Drawing.Color.Empty
      Me.tabLetras.Selected = False
      Me.tabLetras.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tabLetras.SelectTextColor = System.Drawing.Color.Empty
      Me.tabLetras.Size = New System.Drawing.Size(482, 417)
      Me.tabLetras.TabIndex = 4
      Me.tabLetras.Title = "Letras"
      Me.tabLetras.ToolTip = "Datos"
      '
      'pnlDatos
      '
      Me.pnlDatos.Controls.Add(Me.cmbLeNroCuenta)
      Me.pnlDatos.Controls.Add(Me.lblLeNroCuenta)
      Me.pnlDatos.Controls.Add(Me.cmbLeBanco)
      Me.pnlDatos.Controls.Add(Me.lblLeBanco)
      Me.pnlDatos.Controls.Add(Me.grpMoneda)
      Me.pnlDatos.Controls.Add(Me.txtLeReGirador)
      Me.pnlDatos.Controls.Add(Me.Label15)
      Me.pnlDatos.Controls.Add(Me.grpLetra)
      Me.pnlDatos.Controls.Add(Me.txtLeNumero)
      Me.pnlDatos.Controls.Add(Me.actxnImporte)
      Me.pnlDatos.Controls.Add(Me.lblImporte)
      Me.pnlDatos.Controls.Add(Me.lblNumero)
      Me.pnlDatos.Controls.Add(Me.dtpLeFechaVencimiento)
      Me.pnlDatos.Controls.Add(Me.lblFechaDoc)
      Me.pnlDatos.Controls.Add(Me.dtpLeFechaGiro)
      Me.pnlDatos.Controls.Add(Me.lblFecha)
      Me.pnlDatos.Controls.Add(Me.txtLeLugarGiro)
      Me.pnlDatos.Controls.Add(Me.Label8)
      Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
      Me.pnlDatos.Name = "pnlDatos"
      Me.pnlDatos.Size = New System.Drawing.Size(482, 417)
      Me.pnlDatos.TabIndex = 1
      '
      'cmbLeNroCuenta
      '
      Me.cmbLeNroCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLeNroCuenta.FormattingEnabled = True
      Me.cmbLeNroCuenta.Location = New System.Drawing.Point(121, 42)
      Me.cmbLeNroCuenta.Name = "cmbLeNroCuenta"
      Me.cmbLeNroCuenta.Size = New System.Drawing.Size(288, 23)
      Me.cmbLeNroCuenta.TabIndex = 20
      '
      'lblLeNroCuenta
      '
      Me.lblLeNroCuenta.AutoSize = True
      Me.lblLeNroCuenta.Location = New System.Drawing.Point(42, 45)
      Me.lblLeNroCuenta.Name = "lblLeNroCuenta"
      Me.lblLeNroCuenta.Size = New System.Drawing.Size(77, 15)
      Me.lblLeNroCuenta.TabIndex = 19
      Me.lblLeNroCuenta.Text = "Nro. Cuenta :"
      '
      'cmbLeBanco
      '
      Me.cmbLeBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLeBanco.FormattingEnabled = True
      Me.cmbLeBanco.Location = New System.Drawing.Point(121, 15)
      Me.cmbLeBanco.Name = "cmbLeBanco"
      Me.cmbLeBanco.Size = New System.Drawing.Size(288, 23)
      Me.cmbLeBanco.TabIndex = 18
      '
      'lblLeBanco
      '
      Me.lblLeBanco.AutoSize = True
      Me.lblLeBanco.Location = New System.Drawing.Point(72, 19)
      Me.lblLeBanco.Name = "lblLeBanco"
      Me.lblLeBanco.Size = New System.Drawing.Size(46, 15)
      Me.lblLeBanco.TabIndex = 17
      Me.lblLeBanco.Text = "Banco :"
      '
      'grpMoneda
      '
      Me.grpMoneda.Controls.Add(Me.rbtnLeDolares)
      Me.grpMoneda.Controls.Add(Me.rbtnLeSoles)
      Me.grpMoneda.Location = New System.Drawing.Point(262, 180)
      Me.grpMoneda.Name = "grpMoneda"
      Me.grpMoneda.Size = New System.Drawing.Size(147, 60)
      Me.grpMoneda.TabIndex = 8
      Me.grpMoneda.TabStop = False
      Me.grpMoneda.Text = "Moneda"
      '
      'rbtnLeDolares
      '
      Me.rbtnLeDolares.AutoSize = True
      Me.rbtnLeDolares.Location = New System.Drawing.Point(14, 38)
      Me.rbtnLeDolares.Name = "rbtnLeDolares"
      Me.rbtnLeDolares.Size = New System.Drawing.Size(130, 19)
      Me.rbtnLeDolares.TabIndex = 4
      Me.rbtnLeDolares.Text = "Dolares Americanos"
      Me.rbtnLeDolares.UseVisualStyleBackColor = True
      '
      'rbtnLeSoles
      '
      Me.rbtnLeSoles.AutoSize = True
      Me.rbtnLeSoles.Checked = True
      Me.rbtnLeSoles.Location = New System.Drawing.Point(14, 16)
      Me.rbtnLeSoles.Name = "rbtnLeSoles"
      Me.rbtnLeSoles.Size = New System.Drawing.Size(95, 19)
      Me.rbtnLeSoles.TabIndex = 3
      Me.rbtnLeSoles.TabStop = True
      Me.rbtnLeSoles.Text = "Nuevos Soles"
      Me.rbtnLeSoles.UseVisualStyleBackColor = True
      '
      'txtLeReGirador
      '
      Me.txtLeReGirador.Location = New System.Drawing.Point(121, 97)
      Me.txtLeReGirador.MaxLength = 50
      Me.txtLeReGirador.Name = "txtLeReGirador"
      Me.txtLeReGirador.Size = New System.Drawing.Size(288, 23)
      Me.txtLeReGirador.TabIndex = 15
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(42, 100)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(75, 15)
      Me.Label15.TabIndex = 14
      Me.Label15.Text = "Ref. Girador :"
      '
      'grpLetra
      '
      Me.grpLetra.Controls.Add(Me.txtTelefono)
      Me.grpLetra.Controls.Add(Me.Label14)
      Me.grpLetra.Controls.Add(Me.txtRUC)
      Me.grpLetra.Controls.Add(Me.Label13)
      Me.grpLetra.Controls.Add(Me.txtLocalidad)
      Me.grpLetra.Controls.Add(Me.Label12)
      Me.grpLetra.Controls.Add(Me.txtDomicilio)
      Me.grpLetra.Controls.Add(Me.Label11)
      Me.grpLetra.Controls.Add(Me.txtAceptante)
      Me.grpLetra.Controls.Add(Me.Label10)
      Me.grpLetra.Controls.Add(Me.txtGlosa)
      Me.grpLetra.Controls.Add(Me.Label9)
      Me.grpLetra.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.grpLetra.Location = New System.Drawing.Point(0, 237)
      Me.grpLetra.Name = "grpLetra"
      Me.grpLetra.Size = New System.Drawing.Size(482, 180)
      Me.grpLetra.TabIndex = 16
      Me.grpLetra.TabStop = False
      Me.grpLetra.Text = "Datos adicionales"
      Me.grpLetra.Visible = False
      '
      'txtTelefono
      '
      Me.txtTelefono.Location = New System.Drawing.Point(121, 153)
      Me.txtTelefono.MaxLength = 15
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.Size = New System.Drawing.Size(288, 23)
      Me.txtTelefono.TabIndex = 13
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(59, 156)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(60, 15)
      Me.Label14.TabIndex = 12
      Me.Label14.Text = "Telefono :"
      '
      'txtRUC
      '
      Me.txtRUC.Location = New System.Drawing.Point(121, 126)
      Me.txtRUC.MaxLength = 15
      Me.txtRUC.Name = "txtRUC"
      Me.txtRUC.Size = New System.Drawing.Size(288, 23)
      Me.txtRUC.TabIndex = 11
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(68, 129)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(45, 15)
      Me.Label13.TabIndex = 10
      Me.Label13.Text = "R.U.C. :"
      '
      'txtLocalidad
      '
      Me.txtLocalidad.Location = New System.Drawing.Point(121, 99)
      Me.txtLocalidad.MaxLength = 50
      Me.txtLocalidad.Name = "txtLocalidad"
      Me.txtLocalidad.Size = New System.Drawing.Size(288, 23)
      Me.txtLocalidad.TabIndex = 9
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(57, 102)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(64, 15)
      Me.Label12.TabIndex = 8
      Me.Label12.Text = "Localidad :"
      '
      'txtDomicilio
      '
      Me.txtDomicilio.Location = New System.Drawing.Point(121, 72)
      Me.txtDomicilio.MaxLength = 60
      Me.txtDomicilio.Name = "txtDomicilio"
      Me.txtDomicilio.Size = New System.Drawing.Size(288, 23)
      Me.txtDomicilio.TabIndex = 7
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(61, 75)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(64, 15)
      Me.Label11.TabIndex = 6
      Me.Label11.Text = "Domicilio :"
      '
      'txtAceptante
      '
      Me.txtAceptante.Location = New System.Drawing.Point(121, 45)
      Me.txtAceptante.MaxLength = 50
      Me.txtAceptante.Name = "txtAceptante"
      Me.txtAceptante.Size = New System.Drawing.Size(288, 23)
      Me.txtAceptante.TabIndex = 5
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(51, 48)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(67, 15)
      Me.Label10.TabIndex = 4
      Me.Label10.Text = "Aceptante :"
      '
      'txtGlosa
      '
      Me.txtGlosa.Location = New System.Drawing.Point(121, 18)
      Me.txtGlosa.MaxLength = 50
      Me.txtGlosa.Name = "txtGlosa"
      Me.txtGlosa.Size = New System.Drawing.Size(288, 23)
      Me.txtGlosa.TabIndex = 3
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(75, 21)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(42, 15)
      Me.Label9.TabIndex = 2
      Me.Label9.Text = "Glosa :"
      '
      'txtLeNumero
      '
      Me.txtLeNumero.Location = New System.Drawing.Point(121, 70)
      Me.txtLeNumero.MaxLength = 25
      Me.txtLeNumero.Name = "txtLeNumero"
      Me.txtLeNumero.Size = New System.Drawing.Size(121, 23)
      Me.txtLeNumero.TabIndex = 13
      '
      'actxnImporte
      '
      Me.actxnImporte.ACEnteros = 8
      Me.actxnImporte.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnImporte.ACFormato = "##,###,##0.00"
      Me.actxnImporte.ACNegativo = True
      Me.actxnImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnImporte.Location = New System.Drawing.Point(121, 205)
      Me.actxnImporte.MaxLength = 12
      Me.actxnImporte.Name = "actxnImporte"
      Me.actxnImporte.Size = New System.Drawing.Size(121, 23)
      Me.actxnImporte.TabIndex = 10
      Me.actxnImporte.Text = "0.00"
      Me.actxnImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblImporte
      '
      Me.lblImporte.AutoSize = True
      Me.lblImporte.Location = New System.Drawing.Point(63, 209)
      Me.lblImporte.Name = "lblImporte"
      Me.lblImporte.Size = New System.Drawing.Size(55, 15)
      Me.lblImporte.TabIndex = 9
      Me.lblImporte.Text = "Importe :"
      '
      'lblNumero
      '
      Me.lblNumero.AutoSize = True
      Me.lblNumero.Location = New System.Drawing.Point(64, 73)
      Me.lblNumero.Name = "lblNumero"
      Me.lblNumero.Size = New System.Drawing.Size(57, 15)
      Me.lblNumero.TabIndex = 6
      Me.lblNumero.Text = "Numero :"
      '
      'dtpLeFechaVencimiento
      '
      Me.dtpLeFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpLeFechaVencimiento.Location = New System.Drawing.Point(121, 178)
      Me.dtpLeFechaVencimiento.Name = "dtpLeFechaVencimiento"
      Me.dtpLeFechaVencimiento.Size = New System.Drawing.Size(121, 23)
      Me.dtpLeFechaVencimiento.TabIndex = 5
      '
      'lblFechaDoc
      '
      Me.lblFechaDoc.AutoSize = True
      Me.lblFechaDoc.Location = New System.Drawing.Point(12, 182)
      Me.lblFechaDoc.Name = "lblFechaDoc"
      Me.lblFechaDoc.Size = New System.Drawing.Size(114, 15)
      Me.lblFechaDoc.TabIndex = 4
      Me.lblFechaDoc.Text = "Fecha Vencimiento :"
      '
      'dtpLeFechaGiro
      '
      Me.dtpLeFechaGiro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpLeFechaGiro.Location = New System.Drawing.Point(121, 124)
      Me.dtpLeFechaGiro.Name = "dtpLeFechaGiro"
      Me.dtpLeFechaGiro.Size = New System.Drawing.Size(121, 23)
      Me.dtpLeFechaGiro.TabIndex = 3
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.Location = New System.Drawing.Point(50, 128)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(69, 15)
      Me.lblFecha.TabIndex = 2
      Me.lblFecha.Text = "Fecha Giro :"
      '
      'txtLeLugarGiro
      '
      Me.txtLeLugarGiro.Location = New System.Drawing.Point(121, 151)
      Me.txtLeLugarGiro.MaxLength = 50
      Me.txtLeLugarGiro.Name = "txtLeLugarGiro"
      Me.txtLeLugarGiro.Size = New System.Drawing.Size(288, 23)
      Me.txtLeLugarGiro.TabIndex = 1
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(37, 154)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(84, 15)
      Me.Label8.TabIndex = 0
      Me.Label8.Text = "Lugar de Giro :"
      '
      'tpgDetraccion
      '
      Me.tpgDetraccion.Controls.Add(Me.txtDtNumOperacion)
      Me.tpgDetraccion.Controls.Add(Me.actxnDtImporte)
      Me.tpgDetraccion.Controls.Add(Me.Label25)
      Me.tpgDetraccion.Controls.Add(Me.GroupBox3)
      Me.tpgDetraccion.Controls.Add(Me.Label26)
      Me.tpgDetraccion.Controls.Add(Me.dtpDtFecVoucher)
      Me.tpgDetraccion.Controls.Add(Me.Label27)
      Me.tpgDetraccion.Controls.Add(Me.dtpDtFecCaja)
      Me.tpgDetraccion.Controls.Add(Me.Label28)
      Me.tpgDetraccion.Controls.Add(Me.cmbDtBanco)
      Me.tpgDetraccion.Controls.Add(Me.Label29)
      Me.tpgDetraccion.InactiveBackColor = System.Drawing.Color.Empty
      Me.tpgDetraccion.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tpgDetraccion.InactiveTextColor = System.Drawing.Color.Empty
      Me.tpgDetraccion.Location = New System.Drawing.Point(1, 1)
      Me.tpgDetraccion.Name = "tpgDetraccion"
      Me.tpgDetraccion.SelectBackColor = System.Drawing.Color.Empty
      Me.tpgDetraccion.Selected = False
      Me.tpgDetraccion.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tpgDetraccion.SelectTextColor = System.Drawing.Color.Empty
      Me.tpgDetraccion.Size = New System.Drawing.Size(482, 417)
      Me.tpgDetraccion.TabIndex = 9
      Me.tpgDetraccion.Title = "Detracción"
      Me.tpgDetraccion.ToolTip = "Detracción"
      '
      'txtDtNumOperacion
      '
      Me.txtDtNumOperacion.Location = New System.Drawing.Point(140, 89)
      Me.txtDtNumOperacion.MaxLength = 25
      Me.txtDtNumOperacion.Name = "txtDtNumOperacion"
      Me.txtDtNumOperacion.Size = New System.Drawing.Size(121, 23)
      Me.txtDtNumOperacion.TabIndex = 7
      '
      'actxnDtImporte
      '
      Me.actxnDtImporte.ACEnteros = 8
      Me.actxnDtImporte.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnDtImporte.ACFormato = "##,###,##0.00"
      Me.actxnDtImporte.ACNegativo = True
      Me.actxnDtImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnDtImporte.Location = New System.Drawing.Point(140, 115)
      Me.actxnDtImporte.MaxLength = 12
      Me.actxnDtImporte.Name = "actxnDtImporte"
      Me.actxnDtImporte.Size = New System.Drawing.Size(121, 23)
      Me.actxnDtImporte.TabIndex = 10
      Me.actxnDtImporte.Text = "0.00"
      Me.actxnDtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.Location = New System.Drawing.Point(79, 119)
      Me.Label25.Name = "Label25"
      Me.Label25.Size = New System.Drawing.Size(55, 15)
      Me.Label25.TabIndex = 9
      Me.Label25.Text = "Importe :"
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.rbtnDtDolares)
      Me.GroupBox3.Controls.Add(Me.rbtnDtSoles)
      Me.GroupBox3.Location = New System.Drawing.Point(281, 34)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(147, 75)
      Me.GroupBox3.TabIndex = 8
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Moneda"
      '
      'rbtnDtDolares
      '
      Me.rbtnDtDolares.AutoSize = True
      Me.rbtnDtDolares.Location = New System.Drawing.Point(14, 45)
      Me.rbtnDtDolares.Name = "rbtnDtDolares"
      Me.rbtnDtDolares.Size = New System.Drawing.Size(130, 19)
      Me.rbtnDtDolares.TabIndex = 1
      Me.rbtnDtDolares.Text = "Dolares Americanos"
      Me.rbtnDtDolares.UseVisualStyleBackColor = True
      '
      'rbtnDtSoles
      '
      Me.rbtnDtSoles.AutoSize = True
      Me.rbtnDtSoles.Checked = True
      Me.rbtnDtSoles.Location = New System.Drawing.Point(14, 21)
      Me.rbtnDtSoles.Name = "rbtnDtSoles"
      Me.rbtnDtSoles.Size = New System.Drawing.Size(95, 19)
      Me.rbtnDtSoles.TabIndex = 0
      Me.rbtnDtSoles.TabStop = True
      Me.rbtnDtSoles.Text = "Nuevos Soles"
      Me.rbtnDtSoles.UseVisualStyleBackColor = True
      '
      'Label26
      '
      Me.Label26.AutoSize = True
      Me.Label26.Location = New System.Drawing.Point(19, 92)
      Me.Label26.Name = "Label26"
      Me.Label26.Size = New System.Drawing.Size(115, 15)
      Me.Label26.TabIndex = 6
      Me.Label26.Text = "Numero Operación :"
      '
      'dtpDtFecVoucher
      '
      Me.dtpDtFecVoucher.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDtFecVoucher.Location = New System.Drawing.Point(140, 61)
      Me.dtpDtFecVoucher.Name = "dtpDtFecVoucher"
      Me.dtpDtFecVoucher.Size = New System.Drawing.Size(121, 23)
      Me.dtpDtFecVoucher.TabIndex = 5
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.Location = New System.Drawing.Point(43, 65)
      Me.Label27.Name = "Label27"
      Me.Label27.Size = New System.Drawing.Size(91, 15)
      Me.Label27.TabIndex = 4
      Me.Label27.Text = "Fecha Voucher :"
      '
      'dtpDtFecCaja
      '
      Me.dtpDtFecCaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDtFecCaja.Location = New System.Drawing.Point(140, 34)
      Me.dtpDtFecCaja.Name = "dtpDtFecCaja"
      Me.dtpDtFecCaja.Size = New System.Drawing.Size(121, 23)
      Me.dtpDtFecCaja.TabIndex = 3
      '
      'Label28
      '
      Me.Label28.AutoSize = True
      Me.Label28.Location = New System.Drawing.Point(64, 38)
      Me.Label28.Name = "Label28"
      Me.Label28.Size = New System.Drawing.Size(70, 15)
      Me.Label28.TabIndex = 2
      Me.Label28.Text = "Fecha Caja :"
      '
      'cmbDtBanco
      '
      Me.cmbDtBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDtBanco.FormattingEnabled = True
      Me.cmbDtBanco.Location = New System.Drawing.Point(140, 5)
      Me.cmbDtBanco.Name = "cmbDtBanco"
      Me.cmbDtBanco.Size = New System.Drawing.Size(288, 23)
      Me.cmbDtBanco.TabIndex = 1
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.Location = New System.Drawing.Point(88, 9)
      Me.Label29.Name = "Label29"
      Me.Label29.Size = New System.Drawing.Size(46, 15)
      Me.Label29.TabIndex = 0
      Me.Label29.Text = "Banco :"
      '
      'tpgNotaCredito
      '
      Me.tpgNotaCredito.Controls.Add(Me.txtNCMotivo)
      Me.tpgNotaCredito.Controls.Add(Me.Label24)
      Me.tpgNotaCredito.Controls.Add(Me.GroupBox5)
      Me.tpgNotaCredito.Controls.Add(Me.GroupBox4)
      Me.tpgNotaCredito.Controls.Add(Me.actxnNCImporte)
      Me.tpgNotaCredito.Controls.Add(Me.Label30)
      Me.tpgNotaCredito.Controls.Add(Me.dtpNCFecha)
      Me.tpgNotaCredito.Controls.Add(Me.Label33)
      Me.tpgNotaCredito.InactiveBackColor = System.Drawing.Color.Empty
      Me.tpgNotaCredito.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tpgNotaCredito.InactiveTextColor = System.Drawing.Color.Empty
      Me.tpgNotaCredito.Location = New System.Drawing.Point(1, 1)
      Me.tpgNotaCredito.Name = "tpgNotaCredito"
      Me.tpgNotaCredito.SelectBackColor = System.Drawing.Color.Empty
      Me.tpgNotaCredito.Selected = False
      Me.tpgNotaCredito.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tpgNotaCredito.SelectTextColor = System.Drawing.Color.Empty
      Me.tpgNotaCredito.Size = New System.Drawing.Size(482, 417)
      Me.tpgNotaCredito.TabIndex = 10
      Me.tpgNotaCredito.Title = "Nota Credito"
      Me.tpgNotaCredito.ToolTip = "Nota Credito"
      '
      'txtNCMotivo
      '
      Me.txtNCMotivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNCMotivo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNCMotivo.Location = New System.Drawing.Point(92, 79)
      Me.txtNCMotivo.MaxLength = 120
      Me.txtNCMotivo.Multiline = True
      Me.txtNCMotivo.Name = "txtNCMotivo"
      Me.txtNCMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNCMotivo.Size = New System.Drawing.Size(375, 56)
      Me.txtNCMotivo.TabIndex = 6
      Me.txtNCMotivo.Tag = "EVO"
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.Location = New System.Drawing.Point(35, 79)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(51, 15)
      Me.Label24.TabIndex = 5
      Me.Label24.Text = "Motivo :"
      '
      'GroupBox5
      '
      Me.GroupBox5.Controls.Add(Me.Label35)
      Me.GroupBox5.Controls.Add(Me.txtSerie)
      Me.GroupBox5.Controls.Add(Me.actxnNumero)
      Me.GroupBox5.Controls.Add(Me.Label36)
      Me.GroupBox5.Controls.Add(Me.Label37)
      Me.GroupBox5.Controls.Add(Me.lblTipoDocumento)
      Me.GroupBox5.Controls.Add(Me.cmbNCTipoDocumento)
      Me.GroupBox5.Controls.Add(Me.dtpNCFecDocumento)
      Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.GroupBox5.Location = New System.Drawing.Point(0, 343)
      Me.GroupBox5.Name = "GroupBox5"
      Me.GroupBox5.Size = New System.Drawing.Size(482, 74)
      Me.GroupBox5.TabIndex = 29
      Me.GroupBox5.TabStop = False
      Me.GroupBox5.Text = "Documento"
      '
      'Label35
      '
      Me.Label35.AutoSize = True
      Me.Label35.Location = New System.Drawing.Point(313, 22)
      Me.Label35.Name = "Label35"
      Me.Label35.Size = New System.Drawing.Size(44, 15)
      Me.Label35.TabIndex = 2
      Me.Label35.Text = "&Fecha :"
      '
      'txtSerie
      '
      Me.txtSerie.Location = New System.Drawing.Point(86, 44)
      Me.txtSerie.MaxLength = 3
      Me.txtSerie.Name = "txtSerie"
      Me.txtSerie.Size = New System.Drawing.Size(51, 23)
      Me.txtSerie.TabIndex = 5
      Me.txtSerie.Tag = "EVO"
      '
      'actxnNumero
      '
      Me.actxnNumero.ACEnteros = 8
      Me.actxnNumero.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnNumero.ACFormato = "#######0"
      Me.actxnNumero.ACNegativo = True
      Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnNumero.Location = New System.Drawing.Point(202, 44)
      Me.actxnNumero.MaxLength = 12
      Me.actxnNumero.Name = "actxnNumero"
      Me.actxnNumero.Size = New System.Drawing.Size(100, 23)
      Me.actxnNumero.TabIndex = 7
      Me.actxnNumero.Tag = "EVO"
      Me.actxnNumero.Text = "0"
      Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label36
      '
      Me.Label36.AutoSize = True
      Me.Label36.Location = New System.Drawing.Point(142, 48)
      Me.Label36.Name = "Label36"
      Me.Label36.Size = New System.Drawing.Size(57, 15)
      Me.Label36.TabIndex = 6
      Me.Label36.Text = "Numero :"
      '
      'Label37
      '
      Me.Label37.AutoSize = True
      Me.Label37.Location = New System.Drawing.Point(41, 48)
      Me.Label37.Name = "Label37"
      Me.Label37.Size = New System.Drawing.Size(38, 15)
      Me.Label37.TabIndex = 4
      Me.Label37.Text = "Serie :"
      '
      'lblTipoDocumento
      '
      Me.lblTipoDocumento.AutoSize = True
      Me.lblTipoDocumento.Location = New System.Drawing.Point(5, 22)
      Me.lblTipoDocumento.Name = "lblTipoDocumento"
      Me.lblTipoDocumento.Size = New System.Drawing.Size(76, 15)
      Me.lblTipoDocumento.TabIndex = 0
      Me.lblTipoDocumento.Text = "Documento :"
      '
      'cmbNCTipoDocumento
      '
      Me.cmbNCTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNCTipoDocumento.FormattingEnabled = True
      Me.cmbNCTipoDocumento.Items.AddRange(New Object() {"Boleta", "Factura"})
      Me.cmbNCTipoDocumento.Location = New System.Drawing.Point(86, 18)
      Me.cmbNCTipoDocumento.Name = "cmbNCTipoDocumento"
      Me.cmbNCTipoDocumento.Size = New System.Drawing.Size(216, 23)
      Me.cmbNCTipoDocumento.TabIndex = 1
      Me.cmbNCTipoDocumento.Tag = "ECO"
      '
      'dtpNCFecDocumento
      '
      Me.dtpNCFecDocumento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpNCFecDocumento.Location = New System.Drawing.Point(366, 18)
      Me.dtpNCFecDocumento.Name = "dtpNCFecDocumento"
      Me.dtpNCFecDocumento.Size = New System.Drawing.Size(101, 23)
      Me.dtpNCFecDocumento.TabIndex = 3
      Me.dtpNCFecDocumento.Tag = "E"
      '
      'GroupBox4
      '
      Me.GroupBox4.Controls.Add(Me.rbtnNCDolares)
      Me.GroupBox4.Controls.Add(Me.rbtnNCSoles)
      Me.GroupBox4.Location = New System.Drawing.Point(292, 10)
      Me.GroupBox4.Name = "GroupBox4"
      Me.GroupBox4.Size = New System.Drawing.Size(175, 63)
      Me.GroupBox4.TabIndex = 4
      Me.GroupBox4.TabStop = False
      Me.GroupBox4.Text = "Moneda"
      '
      'rbtnNCDolares
      '
      Me.rbtnNCDolares.AutoSize = True
      Me.rbtnNCDolares.Location = New System.Drawing.Point(14, 38)
      Me.rbtnNCDolares.Name = "rbtnNCDolares"
      Me.rbtnNCDolares.Size = New System.Drawing.Size(130, 19)
      Me.rbtnNCDolares.TabIndex = 1
      Me.rbtnNCDolares.Text = "Dolares Americanos"
      Me.rbtnNCDolares.UseVisualStyleBackColor = True
      '
      'rbtnNCSoles
      '
      Me.rbtnNCSoles.AutoSize = True
      Me.rbtnNCSoles.Checked = True
      Me.rbtnNCSoles.Location = New System.Drawing.Point(14, 16)
      Me.rbtnNCSoles.Name = "rbtnNCSoles"
      Me.rbtnNCSoles.Size = New System.Drawing.Size(95, 19)
      Me.rbtnNCSoles.TabIndex = 0
      Me.rbtnNCSoles.TabStop = True
      Me.rbtnNCSoles.Text = "Nuevos Soles"
      Me.rbtnNCSoles.UseVisualStyleBackColor = True
      '
      'actxnNCImporte
      '
      Me.actxnNCImporte.ACEnteros = 8
      Me.actxnNCImporte.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnNCImporte.ACFormato = "##,###,##0.00"
      Me.actxnNCImporte.ACNegativo = True
      Me.actxnNCImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnNCImporte.Location = New System.Drawing.Point(92, 46)
      Me.actxnNCImporte.MaxLength = 12
      Me.actxnNCImporte.Name = "actxnNCImporte"
      Me.actxnNCImporte.Size = New System.Drawing.Size(103, 23)
      Me.actxnNCImporte.TabIndex = 3
      Me.actxnNCImporte.Text = "0.00"
      Me.actxnNCImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label30
      '
      Me.Label30.AutoSize = True
      Me.Label30.Location = New System.Drawing.Point(31, 50)
      Me.Label30.Name = "Label30"
      Me.Label30.Size = New System.Drawing.Size(55, 15)
      Me.Label30.TabIndex = 2
      Me.Label30.Text = "Importe :"
      '
      'dtpNCFecha
      '
      Me.dtpNCFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpNCFecha.Location = New System.Drawing.Point(92, 16)
      Me.dtpNCFecha.Name = "dtpNCFecha"
      Me.dtpNCFecha.Size = New System.Drawing.Size(103, 23)
      Me.dtpNCFecha.TabIndex = 1
      '
      'Label33
      '
      Me.Label33.AutoSize = True
      Me.Label33.Location = New System.Drawing.Point(17, 20)
      Me.Label33.Name = "Label33"
      Me.Label33.Size = New System.Drawing.Size(69, 15)
      Me.Label33.TabIndex = 0
      Me.Label33.Text = "Fecha Giro :"
      '
      'tpgRecEgreInterno
      '
      Me.tpgRecEgreInterno.Controls.Add(Me.txtREGirador)
      Me.tpgRecEgreInterno.Controls.Add(Me.Label39)
      Me.tpgRecEgreInterno.Controls.Add(Me.txtRENumero)
      Me.tpgRecEgreInterno.Controls.Add(Me.Label38)
      Me.tpgRecEgreInterno.Controls.Add(Me.txtREConcepto)
      Me.tpgRecEgreInterno.Controls.Add(Me.Label31)
      Me.tpgRecEgreInterno.Controls.Add(Me.GroupBox6)
      Me.tpgRecEgreInterno.Controls.Add(Me.actxnREImporte)
      Me.tpgRecEgreInterno.Controls.Add(Me.Label32)
      Me.tpgRecEgreInterno.Controls.Add(Me.dtpREFecha)
      Me.tpgRecEgreInterno.Controls.Add(Me.Label34)
      Me.tpgRecEgreInterno.InactiveBackColor = System.Drawing.Color.Empty
      Me.tpgRecEgreInterno.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tpgRecEgreInterno.InactiveTextColor = System.Drawing.Color.Empty
      Me.tpgRecEgreInterno.Location = New System.Drawing.Point(1, 1)
      Me.tpgRecEgreInterno.Name = "tpgRecEgreInterno"
      Me.tpgRecEgreInterno.SelectBackColor = System.Drawing.Color.Empty
      Me.tpgRecEgreInterno.Selected = False
      Me.tpgRecEgreInterno.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tpgRecEgreInterno.SelectTextColor = System.Drawing.Color.Empty
      Me.tpgRecEgreInterno.Size = New System.Drawing.Size(482, 417)
      Me.tpgRecEgreInterno.TabIndex = 11
      Me.tpgRecEgreInterno.Title = "Recibo de Egreso Interno"
      Me.tpgRecEgreInterno.ToolTip = "Recibo de Egreso Interno"
      '
      'txtREGirador
      '
      Me.txtREGirador.Location = New System.Drawing.Point(90, 11)
      Me.txtREGirador.MaxLength = 50
      Me.txtREGirador.Name = "txtREGirador"
      Me.txtREGirador.Size = New System.Drawing.Size(375, 23)
      Me.txtREGirador.TabIndex = 1
      '
      'Label39
      '
      Me.Label39.AutoSize = True
      Me.Label39.Location = New System.Drawing.Point(11, 14)
      Me.Label39.Name = "Label39"
      Me.Label39.Size = New System.Drawing.Size(75, 15)
      Me.Label39.TabIndex = 0
      Me.Label39.Text = "Ref. Girador :"
      '
      'txtRENumero
      '
      Me.txtRENumero.Location = New System.Drawing.Point(90, 40)
      Me.txtRENumero.MaxLength = 25
      Me.txtRENumero.Name = "txtRENumero"
      Me.txtRENumero.Size = New System.Drawing.Size(121, 23)
      Me.txtRENumero.TabIndex = 3
      '
      'Label38
      '
      Me.Label38.AutoSize = True
      Me.Label38.Location = New System.Drawing.Point(29, 43)
      Me.Label38.Name = "Label38"
      Me.Label38.Size = New System.Drawing.Size(57, 15)
      Me.Label38.TabIndex = 2
      Me.Label38.Text = "Numero :"
      '
      'txtREConcepto
      '
      Me.txtREConcepto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtREConcepto.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtREConcepto.Location = New System.Drawing.Point(90, 132)
      Me.txtREConcepto.MaxLength = 120
      Me.txtREConcepto.Multiline = True
      Me.txtREConcepto.Name = "txtREConcepto"
      Me.txtREConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtREConcepto.Size = New System.Drawing.Size(375, 56)
      Me.txtREConcepto.TabIndex = 10
      Me.txtREConcepto.Tag = "EVO"
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.Location = New System.Drawing.Point(21, 132)
      Me.Label31.Name = "Label31"
      Me.Label31.Size = New System.Drawing.Size(65, 15)
      Me.Label31.TabIndex = 9
      Me.Label31.Text = "Concepto :"
      '
      'GroupBox6
      '
      Me.GroupBox6.Controls.Add(Me.rbtnRIDolares)
      Me.GroupBox6.Controls.Add(Me.rbtnRISoles)
      Me.GroupBox6.Location = New System.Drawing.Point(290, 63)
      Me.GroupBox6.Name = "GroupBox6"
      Me.GroupBox6.Size = New System.Drawing.Size(175, 63)
      Me.GroupBox6.TabIndex = 8
      Me.GroupBox6.TabStop = False
      Me.GroupBox6.Text = "Moneda"
      '
      'rbtnRIDolares
      '
      Me.rbtnRIDolares.AutoSize = True
      Me.rbtnRIDolares.Location = New System.Drawing.Point(14, 38)
      Me.rbtnRIDolares.Name = "rbtnRIDolares"
      Me.rbtnRIDolares.Size = New System.Drawing.Size(130, 19)
      Me.rbtnRIDolares.TabIndex = 1
      Me.rbtnRIDolares.Text = "Dolares Americanos"
      Me.rbtnRIDolares.UseVisualStyleBackColor = True
      '
      'rbtnRISoles
      '
      Me.rbtnRISoles.AutoSize = True
      Me.rbtnRISoles.Checked = True
      Me.rbtnRISoles.Location = New System.Drawing.Point(14, 16)
      Me.rbtnRISoles.Name = "rbtnRISoles"
      Me.rbtnRISoles.Size = New System.Drawing.Size(95, 19)
      Me.rbtnRISoles.TabIndex = 0
      Me.rbtnRISoles.TabStop = True
      Me.rbtnRISoles.Text = "Nuevos Soles"
      Me.rbtnRISoles.UseVisualStyleBackColor = True
      '
      'actxnREImporte
      '
      Me.actxnREImporte.ACEnteros = 8
      Me.actxnREImporte.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnREImporte.ACFormato = "#,###,###0.00"
      Me.actxnREImporte.ACNegativo = True
      Me.actxnREImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnREImporte.Location = New System.Drawing.Point(90, 99)
      Me.actxnREImporte.MaxLength = 12
      Me.actxnREImporte.Name = "actxnREImporte"
      Me.actxnREImporte.Size = New System.Drawing.Size(103, 23)
      Me.actxnREImporte.TabIndex = 7
      Me.actxnREImporte.Text = "0.00"
      Me.actxnREImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label32
      '
      Me.Label32.AutoSize = True
      Me.Label32.Location = New System.Drawing.Point(31, 103)
      Me.Label32.Name = "Label32"
      Me.Label32.Size = New System.Drawing.Size(55, 15)
      Me.Label32.TabIndex = 6
      Me.Label32.Text = "Importe :"
      '
      'dtpREFecha
      '
      Me.dtpREFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpREFecha.Location = New System.Drawing.Point(90, 69)
      Me.dtpREFecha.Name = "dtpREFecha"
      Me.dtpREFecha.Size = New System.Drawing.Size(103, 23)
      Me.dtpREFecha.TabIndex = 5
      '
      'Label34
      '
      Me.Label34.AutoSize = True
      Me.Label34.Location = New System.Drawing.Point(17, 73)
      Me.Label34.Name = "Label34"
      Me.Label34.Size = New System.Drawing.Size(69, 15)
      Me.Label34.TabIndex = 4
      Me.Label34.Text = "Fecha Giro :"
      '
      'eprError
      '
      Me.eprError.ContainerControl = Me
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Mantenimiento de {0}"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(484, 30)
      Me.acpnlTitulo.TabIndex = 8
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
      Me.acTool.ACBtnSalirText = "&Salir"
      Me.acTool.ACBtnVolverEnabled = False
      Me.acTool.ACBtnVolverVisible = False
      Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabar
      Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
      Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
      Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.acbtnSeleccionar})
      Me.acTool.Location = New System.Drawing.Point(0, 472)
      Me.acTool.Name = "acTool"
      Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.acTool.Size = New System.Drawing.Size(484, 56)
      Me.acTool.TabIndex = 12
      Me.acTool.Text = "AcToolBarMantHorizontalNew1"
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
      Me.acbtnSeleccionar.Visible = False
      '
      'MDocsPago
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(484, 528)
      Me.Controls.Add(Me.tabMantenimiento)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Controls.Add(Me.acTool)
      Me.Name = "MDocsPago"
      Me.Text = "Mantenimiento de {0}"
      Me.tabMantenimiento.ResumeLayout(False)
      Me.tabBusqueda.ResumeLayout(False)
      Me.tabBusqueda.PerformLayout()
      CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavBusqueda.ResumeLayout(False)
      Me.bnavBusqueda.PerformLayout()
      Me.grpBusqueda.ResumeLayout(False)
      Me.grpBusqueda.PerformLayout()
      Me.tabCheque.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.tabDeposito.ResumeLayout(False)
      Me.tabDeposito.PerformLayout()
      Me.tabLetras.ResumeLayout(False)
      Me.pnlDatos.ResumeLayout(False)
      Me.pnlDatos.PerformLayout()
      Me.grpMoneda.ResumeLayout(False)
      Me.grpMoneda.PerformLayout()
      Me.grpLetra.ResumeLayout(False)
      Me.grpLetra.PerformLayout()
      Me.tpgDetraccion.ResumeLayout(False)
      Me.tpgDetraccion.PerformLayout()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.tpgNotaCredito.ResumeLayout(False)
      Me.tpgNotaCredito.PerformLayout()
      Me.GroupBox5.ResumeLayout(False)
      Me.GroupBox5.PerformLayout()
      Me.GroupBox4.ResumeLayout(False)
      Me.GroupBox4.PerformLayout()
      Me.tpgRecEgreInterno.ResumeLayout(False)
      Me.tpgRecEgreInterno.PerformLayout()
      Me.GroupBox6.ResumeLayout(False)
      Me.GroupBox6.PerformLayout()
      CType(Me.eprError, System.ComponentModel.ISupportInitialize).EndInit()
      Me.acTool.ResumeLayout(False)
      Me.acTool.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents tabLetras As Crownwood.DotNetMagic.Controls.TabPage
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
   Friend WithEvents grpMoneda As System.Windows.Forms.GroupBox
   Friend WithEvents lblNumero As System.Windows.Forms.Label
   Friend WithEvents dtpLeFechaVencimiento As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblFechaDoc As System.Windows.Forms.Label
   Friend WithEvents dtpLeFechaGiro As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblFecha As System.Windows.Forms.Label
   Friend WithEvents rbtnLeDolares As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnLeSoles As System.Windows.Forms.RadioButton
   Friend WithEvents actxnImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents lblImporte As System.Windows.Forms.Label
   Friend WithEvents txtLeNumero As System.Windows.Forms.TextBox
   Friend WithEvents grpLetra As System.Windows.Forms.GroupBox
   Friend WithEvents txtLeReGirador As System.Windows.Forms.TextBox
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents txtRUC As System.Windows.Forms.TextBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents txtLocalidad As System.Windows.Forms.TextBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents txtAceptante As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents txtLeLugarGiro As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tabCheque As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents tabDeposito As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents txtChCodGirador As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmbChCuenta As System.Windows.Forms.ComboBox
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents txtChNumeroCheque As System.Windows.Forms.TextBox
   Friend WithEvents actxnChImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtnChDolares As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnChSoles As System.Windows.Forms.RadioButton
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents dtpChFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents cmbChBanco As System.Windows.Forms.ComboBox
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents txtChDepositante As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtChNumeroOperacion As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents dtpChFechaCaja As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents cmbDeNumeroCuenta As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtDeNumeroOperacion As System.Windows.Forms.TextBox
   Friend WithEvents actxnDeImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents dtpDeFechaVoucher As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents dtpDeFechaCaja As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents cmbDeBanco As System.Windows.Forms.ComboBox
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents eprError As System.Windows.Forms.ErrorProvider
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents cmbLeBanco As System.Windows.Forms.ComboBox
   Friend WithEvents lblLeBanco As System.Windows.Forms.Label
   Friend WithEvents cmbLeNroCuenta As System.Windows.Forms.ComboBox
   Friend WithEvents lblLeNroCuenta As System.Windows.Forms.Label
   Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents acbtnSeleccionar As ACControles.ACToolStripButton
   Friend WithEvents tpgDetraccion As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents txtDtNumOperacion As System.Windows.Forms.TextBox
   Friend WithEvents actxnDtImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents Label25 As System.Windows.Forms.Label
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtnDtDolares As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnDtSoles As System.Windows.Forms.RadioButton
   Friend WithEvents Label26 As System.Windows.Forms.Label
   Friend WithEvents dtpDtFecVoucher As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents dtpDtFecCaja As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label28 As System.Windows.Forms.Label
   Friend WithEvents cmbDtBanco As System.Windows.Forms.ComboBox
   Friend WithEvents Label29 As System.Windows.Forms.Label
   Friend WithEvents tpgNotaCredito As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtnNCDolares As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnNCSoles As System.Windows.Forms.RadioButton
   Friend WithEvents actxnNCImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents Label30 As System.Windows.Forms.Label
   Friend WithEvents dtpNCFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label33 As System.Windows.Forms.Label
   Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
   Friend WithEvents Label35 As System.Windows.Forms.Label
   Friend WithEvents txtSerie As System.Windows.Forms.TextBox
   Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
   Friend WithEvents Label36 As System.Windows.Forms.Label
   Friend WithEvents Label37 As System.Windows.Forms.Label
   Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
   Friend WithEvents cmbNCTipoDocumento As System.Windows.Forms.ComboBox
   Friend WithEvents dtpNCFecDocumento As System.Windows.Forms.DateTimePicker
   Friend WithEvents txtNCMotivo As System.Windows.Forms.TextBox
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Friend WithEvents tpgRecEgreInterno As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents txtREGirador As System.Windows.Forms.TextBox
   Friend WithEvents Label39 As System.Windows.Forms.Label
   Friend WithEvents txtRENumero As System.Windows.Forms.TextBox
   Friend WithEvents Label38 As System.Windows.Forms.Label
   Friend WithEvents txtREConcepto As System.Windows.Forms.TextBox
   Friend WithEvents Label31 As System.Windows.Forms.Label
   Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtnRIDolares As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnRISoles As System.Windows.Forms.RadioButton
   Friend WithEvents actxnREImporte As ACControles.ACTextBoxNumerico
   Friend WithEvents Label32 As System.Windows.Forms.Label
   Friend WithEvents dtpREFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label34 As System.Windows.Forms.Label
   Friend WithEvents cmbDeTipoCuenta As System.Windows.Forms.ComboBox
   Friend WithEvents Label40 As System.Windows.Forms.Label
   Friend WithEvents cmbDeMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents rbtnCliente As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnOperacion As System.Windows.Forms.RadioButton
   Friend WithEvents acFecha As ACControles.ACFecha
End Class
