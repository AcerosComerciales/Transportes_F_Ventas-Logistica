<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFletesCaja
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFletesCaja))
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.AcFecha = New ACControles.ACFecha(Me.components)
      Me.btnExcel = New System.Windows.Forms.Button()
      Me.btnProcesar = New System.Windows.Forms.Button()
      Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
      Me.tctReporte = New Crownwood.DotNetMagic.Controls.TabControl()
      Me.tpgFletes = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.spcFletes = New System.Windows.Forms.SplitContainer()
      Me.c1grdReporte = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.actxnSaldoFletes = New ACControles.ACTextBoxNumerico()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.bnavReporte = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.c1grdPagosRealizados = New C1.Win.C1FlexGrid.C1FlexGrid()
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
      Me.AcPanelCaption5 = New ACControles.ACPanelCaption()
      Me.c1grdDetalle = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.bnavFletes = New System.Windows.Forms.BindingNavigator(Me.components)
      Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
      Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
      Me.AcPanelCaption4 = New ACControles.ACPanelCaption()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.btnClean = New System.Windows.Forms.Button()
      Me.actxaCliRazonSocial = New ACControles.ACTextBoxAyuda()
      Me.lblNroDocumento = New System.Windows.Forms.Label()
      Me.actxaCliRuc = New ACControles.ACTextBoxAyuda()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.rbtnFleSinFacturar = New System.Windows.Forms.RadioButton()
      Me.rbtnFletes = New System.Windows.Forms.RadioButton()
      Me.rbtnFacturas = New System.Windows.Forms.RadioButton()
      Me.actxnSaldoAnteriorFletes = New ACControles.ACTextBoxNumerico()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.AcPanelCaption2 = New ACControles.ACPanelCaption()
      Me.tpgCEfectivo = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.c1grdEfectivo = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.Panel7 = New System.Windows.Forms.Panel()
      Me.chkAgruparEfectivo = New System.Windows.Forms.CheckBox()
      Me.actxnSaldoAnteriorEfectivo = New ACControles.ACTextBoxNumerico()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.AcPanelCaption6 = New ACControles.ACPanelCaption()
      Me.Panel6 = New System.Windows.Forms.Panel()
      Me.actxnSaldoEfectivo = New ACControles.ACTextBoxNumerico()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.bnavEfectivo = New System.Windows.Forms.BindingNavigator(Me.components)
      Me.ToolStripButton19 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
      Me.ToolStripButton20 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton21 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton22 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripTextBox4 = New System.Windows.Forms.ToolStripTextBox()
      Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
      Me.ToolStripButton23 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton24 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
      Me.tpgPagosPendientes = New Crownwood.DotNetMagic.Controls.TabPage()
      Me.c1grdPendientesPagadas = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.bnavPendientesPagados = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.AcPanelCaption3 = New ACControles.ACPanelCaption()
      Me.Panel1.SuspendLayout()
      Me.tctReporte.SuspendLayout()
      Me.tpgFletes.SuspendLayout()
      CType(Me.spcFletes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spcFletes.Panel1.SuspendLayout()
      Me.spcFletes.Panel2.SuspendLayout()
      Me.spcFletes.SuspendLayout()
      CType(Me.c1grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel3.SuspendLayout()
      CType(Me.bnavReporte, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavReporte.SuspendLayout()
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      CType(Me.c1grdPagosRealizados, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavPagos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavPagos.SuspendLayout()
      CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavFletes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavFletes.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.tpgCEfectivo.SuspendLayout()
      CType(Me.c1grdEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel7.SuspendLayout()
      Me.Panel6.SuspendLayout()
      CType(Me.bnavEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavEfectivo.SuspendLayout()
      Me.tpgPagosPendientes.SuspendLayout()
      CType(Me.c1grdPendientesPagadas, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavPendientesPagados, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavPendientesPagados.SuspendLayout()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.AcFecha)
      Me.Panel1.Controls.Add(Me.btnExcel)
      Me.Panel1.Controls.Add(Me.btnProcesar)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 30)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(784, 63)
      Me.Panel1.TabIndex = 51
      '
      'AcFecha
      '
      Me.AcFecha.ACFecha_A = New Date(2013, 6, 24, 9, 10, 58, 48)
      Me.AcFecha.ACFecha_De = New Date(2013, 6, 24, 9, 10, 58, 46)
      Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
      Me.AcFecha.ACHoyChecked = False
      Me.AcFecha.Location = New System.Drawing.Point(12, 6)
      Me.AcFecha.MaximumSize = New System.Drawing.Size(340, 50)
      Me.AcFecha.MinimumSize = New System.Drawing.Size(337, 43)
      Me.AcFecha.Name = "AcFecha"
      Me.AcFecha.Size = New System.Drawing.Size(337, 50)
      Me.AcFecha.TabIndex = 25
      Me.AcFecha.TabStop = False
      '
      'btnExcel
      '
      Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnExcel.Image = Global.ACPTransportes.My.Resources.Resources.Excel2_32x32
      Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExcel.Location = New System.Drawing.Point(616, 3)
      Me.btnExcel.Name = "btnExcel"
      Me.btnExcel.Size = New System.Drawing.Size(164, 41)
      Me.btnExcel.TabIndex = 8
      Me.btnExcel.Text = "Envia a Excel"
      Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExcel.UseVisualStyleBackColor = True
      '
      'btnProcesar
      '
      Me.btnProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnProcesar.Image = Global.ACPTransportes.My.Resources.Resources.CheckProcess_32x32
      Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnProcesar.Location = New System.Drawing.Point(490, 3)
      Me.btnProcesar.Name = "btnProcesar"
      Me.btnProcesar.Size = New System.Drawing.Size(120, 41)
      Me.btnProcesar.TabIndex = 7
      Me.btnProcesar.Text = "Procesar"
      Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnProcesar.UseVisualStyleBackColor = True
      '
      'AcPanelCaption1
      '
      Me.AcPanelCaption1.ACCaption = "Consulta de Fletes y Efectivo"
      Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption1.Name = "AcPanelCaption1"
      Me.AcPanelCaption1.Size = New System.Drawing.Size(784, 30)
      Me.AcPanelCaption1.TabIndex = 50
      '
      'tctReporte
      '
      Me.tctReporte.BackColor = System.Drawing.Color.LightSteelBlue
      Me.tctReporte.BoldSelectedPage = True
      Me.tctReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.tctReporte.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tctReporte.Location = New System.Drawing.Point(0, 93)
      Me.tctReporte.MediaPlayerDockSides = False
      Me.tctReporte.Name = "tctReporte"
      Me.tctReporte.OfficeDockSides = False
      Me.tctReporte.PositionTop = True
      Me.tctReporte.SelectedIndex = 0
      Me.tctReporte.ShowDropSelect = False
      Me.tctReporte.Size = New System.Drawing.Size(784, 469)
      Me.tctReporte.Style = Crownwood.DotNetMagic.Common.VisualStyle.Office2003
      Me.tctReporte.TabIndex = 54
      Me.tctReporte.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tpgCEfectivo, Me.tpgFletes, Me.tpgPagosPendientes})
      Me.tctReporte.TextTips = True
      '
      'tpgFletes
      '
      Me.tpgFletes.Controls.Add(Me.spcFletes)
      Me.tpgFletes.Controls.Add(Me.Panel2)
      Me.tpgFletes.Controls.Add(Me.AcPanelCaption2)
      Me.tpgFletes.InactiveBackColor = System.Drawing.Color.Empty
      Me.tpgFletes.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tpgFletes.InactiveTextColor = System.Drawing.Color.Empty
      Me.tpgFletes.Location = New System.Drawing.Point(1, 24)
      Me.tpgFletes.Name = "tpgFletes"
      Me.tpgFletes.SelectBackColor = System.Drawing.Color.Empty
      Me.tpgFletes.Selected = False
      Me.tpgFletes.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tpgFletes.SelectTextColor = System.Drawing.Color.Empty
      Me.tpgFletes.Size = New System.Drawing.Size(782, 444)
      Me.tpgFletes.TabIndex = 4
      Me.tpgFletes.Title = "Reporte de Fletes Pendientes"
      Me.tpgFletes.ToolTip = "Reporte de Fletes Pendientes"
      '
      'spcFletes
      '
      Me.spcFletes.Dock = System.Windows.Forms.DockStyle.Fill
      Me.spcFletes.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
      Me.spcFletes.Location = New System.Drawing.Point(0, 80)
      Me.spcFletes.Name = "spcFletes"
      Me.spcFletes.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'spcFletes.Panel1
      '
      Me.spcFletes.Panel1.Controls.Add(Me.c1grdReporte)
      Me.spcFletes.Panel1.Controls.Add(Me.Panel3)
      Me.spcFletes.Panel1.Controls.Add(Me.bnavReporte)
      '
      'spcFletes.Panel2
      '
      Me.spcFletes.Panel2.Controls.Add(Me.SplitContainer1)
      Me.spcFletes.Size = New System.Drawing.Size(782, 364)
      Me.spcFletes.SplitterDistance = 211
      Me.spcFletes.TabIndex = 66
      '
      'c1grdReporte
      '
      Me.c1grdReporte.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdReporte.Location = New System.Drawing.Point(0, 0)
      Me.c1grdReporte.Name = "c1grdReporte"
      Me.c1grdReporte.Rows.Count = 2
      Me.c1grdReporte.Rows.DefaultSize = 20
      Me.c1grdReporte.Size = New System.Drawing.Size(782, 151)
      Me.c1grdReporte.StyleInfo = resources.GetString("c1grdReporte.StyleInfo")
      Me.c1grdReporte.TabIndex = 62
      '
      'Panel3
      '
      Me.Panel3.Controls.Add(Me.actxnSaldoFletes)
      Me.Panel3.Controls.Add(Me.Label2)
      Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel3.Location = New System.Drawing.Point(0, 151)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(782, 35)
      Me.Panel3.TabIndex = 61
      '
      'actxnSaldoFletes
      '
      Me.actxnSaldoFletes.ACEnteros = 9
      Me.actxnSaldoFletes.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnSaldoFletes.ACNegativo = True
      Me.actxnSaldoFletes.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnSaldoFletes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxnSaldoFletes.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxnSaldoFletes.Location = New System.Drawing.Point(652, 4)
      Me.actxnSaldoFletes.MaxLength = 12
      Me.actxnSaldoFletes.Name = "actxnSaldoFletes"
      Me.actxnSaldoFletes.Size = New System.Drawing.Size(118, 26)
      Me.actxnSaldoFletes.TabIndex = 26
      Me.actxnSaldoFletes.Tag = "EV"
      Me.actxnSaldoFletes.Text = "0.00"
      Me.actxnSaldoFletes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.Label2.Location = New System.Drawing.Point(555, 7)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(91, 19)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "Saldo Actual :"
      '
      'bnavReporte
      '
      Me.bnavReporte.AddNewItem = Me.BindingNavigatorAddNewItem
      Me.bnavReporte.CountItem = Me.BindingNavigatorCountItem
      Me.bnavReporte.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.bnavReporte.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavReporte.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
      Me.bnavReporte.Location = New System.Drawing.Point(0, 186)
      Me.bnavReporte.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavReporte.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavReporte.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavReporte.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavReporte.Name = "bnavReporte"
      Me.bnavReporte.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavReporte.Size = New System.Drawing.Size(782, 25)
      Me.bnavReporte.TabIndex = 60
      Me.bnavReporte.Text = "BindingNavigator1"
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
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Name = "SplitContainer1"
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.c1grdPagosRealizados)
      Me.SplitContainer1.Panel1.Controls.Add(Me.bnavPagos)
      Me.SplitContainer1.Panel1.Controls.Add(Me.AcPanelCaption5)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.c1grdDetalle)
      Me.SplitContainer1.Panel2.Controls.Add(Me.bnavFletes)
      Me.SplitContainer1.Panel2.Controls.Add(Me.AcPanelCaption4)
      Me.SplitContainer1.Size = New System.Drawing.Size(782, 149)
      Me.SplitContainer1.SplitterDistance = 379
      Me.SplitContainer1.TabIndex = 66
      '
      'c1grdPagosRealizados
      '
      Me.c1grdPagosRealizados.ColumnInfo = "2,1,0,0,0,95,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdPagosRealizados.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdPagosRealizados.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.c1grdPagosRealizados.Location = New System.Drawing.Point(0, 15)
      Me.c1grdPagosRealizados.Name = "c1grdPagosRealizados"
      Me.c1grdPagosRealizados.Rows.Count = 2
      Me.c1grdPagosRealizados.Rows.DefaultSize = 19
      Me.c1grdPagosRealizados.Size = New System.Drawing.Size(379, 109)
      Me.c1grdPagosRealizados.StyleInfo = resources.GetString("c1grdPagosRealizados.StyleInfo")
      Me.c1grdPagosRealizados.TabIndex = 64
      '
      'bnavPagos
      '
      Me.bnavPagos.AddNewItem = Me.ToolStripButton13
      Me.bnavPagos.CountItem = Me.ToolStripLabel3
      Me.bnavPagos.DeleteItem = Me.ToolStripButton14
      Me.bnavPagos.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavPagos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton15, Me.ToolStripButton16, Me.ToolStripSeparator7, Me.ToolStripTextBox3, Me.ToolStripLabel3, Me.ToolStripSeparator8, Me.ToolStripButton17, Me.ToolStripButton18, Me.ToolStripSeparator9, Me.ToolStripButton13, Me.ToolStripButton14})
      Me.bnavPagos.Location = New System.Drawing.Point(0, 124)
      Me.bnavPagos.MoveFirstItem = Me.ToolStripButton15
      Me.bnavPagos.MoveLastItem = Me.ToolStripButton18
      Me.bnavPagos.MoveNextItem = Me.ToolStripButton17
      Me.bnavPagos.MovePreviousItem = Me.ToolStripButton16
      Me.bnavPagos.Name = "bnavPagos"
      Me.bnavPagos.PositionItem = Me.ToolStripTextBox3
      Me.bnavPagos.Size = New System.Drawing.Size(379, 25)
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
      'AcPanelCaption5
      '
      Me.AcPanelCaption5.ACCaption = "Pagos Realizados"
      Me.AcPanelCaption5.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption5.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption5.Name = "AcPanelCaption5"
      Me.AcPanelCaption5.Size = New System.Drawing.Size(379, 15)
      Me.AcPanelCaption5.TabIndex = 66
      '
      'c1grdDetalle
      '
      Me.c1grdDetalle.ColumnInfo = "2,1,0,0,0,95,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdDetalle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.c1grdDetalle.Location = New System.Drawing.Point(0, 15)
      Me.c1grdDetalle.Name = "c1grdDetalle"
      Me.c1grdDetalle.Rows.Count = 2
      Me.c1grdDetalle.Rows.DefaultSize = 19
      Me.c1grdDetalle.Size = New System.Drawing.Size(399, 109)
      Me.c1grdDetalle.StyleInfo = resources.GetString("c1grdDetalle.StyleInfo")
      Me.c1grdDetalle.TabIndex = 67
      '
      'bnavFletes
      '
      Me.bnavFletes.AddNewItem = Me.ToolStripButton7
      Me.bnavFletes.CountItem = Me.ToolStripLabel2
      Me.bnavFletes.DeleteItem = Me.ToolStripButton8
      Me.bnavFletes.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavFletes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton9, Me.ToolStripButton10, Me.ToolStripSeparator4, Me.ToolStripTextBox2, Me.ToolStripLabel2, Me.ToolStripSeparator5, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator6, Me.ToolStripButton7, Me.ToolStripButton8})
      Me.bnavFletes.Location = New System.Drawing.Point(0, 124)
      Me.bnavFletes.MoveFirstItem = Me.ToolStripButton9
      Me.bnavFletes.MoveLastItem = Me.ToolStripButton12
      Me.bnavFletes.MoveNextItem = Me.ToolStripButton11
      Me.bnavFletes.MovePreviousItem = Me.ToolStripButton10
      Me.bnavFletes.Name = "bnavFletes"
      Me.bnavFletes.PositionItem = Me.ToolStripTextBox2
      Me.bnavFletes.Size = New System.Drawing.Size(399, 25)
      Me.bnavFletes.TabIndex = 69
      Me.bnavFletes.Text = "BindingNavigator1"
      '
      'ToolStripButton7
      '
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
      Me.ToolStripLabel2.Size = New System.Drawing.Size(35, 22)
      Me.ToolStripLabel2.Text = "of {0}"
      Me.ToolStripLabel2.ToolTipText = "Total number of items"
      '
      'ToolStripButton8
      '
      Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
      Me.ToolStripButton8.Name = "ToolStripButton8"
      Me.ToolStripButton8.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton8.Text = "Delete"
      Me.ToolStripButton8.Visible = False
      '
      'ToolStripButton9
      '
      Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
      Me.ToolStripButton9.Name = "ToolStripButton9"
      Me.ToolStripButton9.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton9.Text = "Move first"
      '
      'ToolStripButton10
      '
      Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
      Me.ToolStripButton10.Name = "ToolStripButton10"
      Me.ToolStripButton10.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton10.Text = "Move previous"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripTextBox2
      '
      Me.ToolStripTextBox2.AccessibleName = "Position"
      Me.ToolStripTextBox2.AutoSize = False
      Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
      Me.ToolStripTextBox2.Size = New System.Drawing.Size(50, 23)
      Me.ToolStripTextBox2.Text = "0"
      Me.ToolStripTextBox2.ToolTipText = "Current position"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripButton11
      '
      Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
      Me.ToolStripButton11.Name = "ToolStripButton11"
      Me.ToolStripButton11.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton11.Text = "Move next"
      '
      'ToolStripButton12
      '
      Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
      Me.ToolStripButton12.Name = "ToolStripButton12"
      Me.ToolStripButton12.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton12.Text = "Move last"
      '
      'ToolStripSeparator6
      '
      Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
      Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
      '
      'AcPanelCaption4
      '
      Me.AcPanelCaption4.ACCaption = "Fletes de Facturas"
      Me.AcPanelCaption4.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption4.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption4.Name = "AcPanelCaption4"
      Me.AcPanelCaption4.Size = New System.Drawing.Size(399, 15)
      Me.AcPanelCaption4.TabIndex = 68
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.btnClean)
      Me.Panel2.Controls.Add(Me.actxaCliRazonSocial)
      Me.Panel2.Controls.Add(Me.lblNroDocumento)
      Me.Panel2.Controls.Add(Me.actxaCliRuc)
      Me.Panel2.Controls.Add(Me.GroupBox1)
      Me.Panel2.Controls.Add(Me.actxnSaldoAnteriorFletes)
      Me.Panel2.Controls.Add(Me.Label1)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel2.Location = New System.Drawing.Point(0, 25)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(782, 55)
      Me.Panel2.TabIndex = 56
      '
      'btnClean
      '
      Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClean.Image = Global.ACPTransportes.My.Resources.Resources.Delete_16x16
      Me.btnClean.Location = New System.Drawing.Point(512, 13)
      Me.btnClean.Name = "btnClean"
      Me.btnClean.Size = New System.Drawing.Size(36, 26)
      Me.btnClean.TabIndex = 31
      Me.btnClean.UseVisualStyleBackColor = True
      '
      'actxaCliRazonSocial
      '
      Me.actxaCliRazonSocial.ACActivarAyudaAuto = False
      Me.actxaCliRazonSocial.ACLongitudAceptada = 0
      Me.actxaCliRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxaCliRazonSocial.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
      Me.actxaCliRazonSocial.Location = New System.Drawing.Point(321, 14)
      Me.actxaCliRazonSocial.MaxLength = 80
      Me.actxaCliRazonSocial.Name = "actxaCliRazonSocial"
      Me.actxaCliRazonSocial.Size = New System.Drawing.Size(188, 24)
      Me.actxaCliRazonSocial.TabIndex = 30
      Me.actxaCliRazonSocial.Tag = "EVO"
      '
      'lblNroDocumento
      '
      Me.lblNroDocumento.AutoSize = True
      Me.lblNroDocumento.Location = New System.Drawing.Point(152, 19)
      Me.lblNroDocumento.Name = "lblNroDocumento"
      Me.lblNroDocumento.Size = New System.Drawing.Size(50, 15)
      Me.lblNroDocumento.TabIndex = 28
      Me.lblNroDocumento.Text = "Cliente :"
      '
      'actxaCliRuc
      '
      Me.actxaCliRuc.ACActivarAyudaAuto = False
      Me.actxaCliRuc.ACLongitudAceptada = 0
      Me.actxaCliRuc.Location = New System.Drawing.Point(204, 15)
      Me.actxaCliRuc.MaxLength = 14
      Me.actxaCliRuc.Name = "actxaCliRuc"
      Me.actxaCliRuc.Size = New System.Drawing.Size(111, 23)
      Me.actxaCliRuc.TabIndex = 29
      Me.actxaCliRuc.Tag = "EVO"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.rbtnFleSinFacturar)
      Me.GroupBox1.Controls.Add(Me.rbtnFletes)
      Me.GroupBox1.Controls.Add(Me.rbtnFacturas)
      Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
      Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(145, 55)
      Me.GroupBox1.TabIndex = 27
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Consulta por"
      '
      'rbtnFleSinFacturar
      '
      Me.rbtnFleSinFacturar.AutoSize = True
      Me.rbtnFleSinFacturar.Location = New System.Drawing.Point(5, 33)
      Me.rbtnFleSinFacturar.Name = "rbtnFleSinFacturar"
      Me.rbtnFleSinFacturar.Size = New System.Drawing.Size(119, 19)
      Me.rbtnFleSinFacturar.TabIndex = 2
      Me.rbtnFleSinFacturar.Text = "Fletes sin Facturar"
      Me.rbtnFleSinFacturar.UseVisualStyleBackColor = True
      '
      'rbtnFletes
      '
      Me.rbtnFletes.AutoSize = True
      Me.rbtnFletes.Location = New System.Drawing.Point(78, 14)
      Me.rbtnFletes.Name = "rbtnFletes"
      Me.rbtnFletes.Size = New System.Drawing.Size(55, 19)
      Me.rbtnFletes.TabIndex = 1
      Me.rbtnFletes.Text = "Fletes"
      Me.rbtnFletes.UseVisualStyleBackColor = True
      '
      'rbtnFacturas
      '
      Me.rbtnFacturas.AutoSize = True
      Me.rbtnFacturas.Checked = True
      Me.rbtnFacturas.Location = New System.Drawing.Point(5, 14)
      Me.rbtnFacturas.Name = "rbtnFacturas"
      Me.rbtnFacturas.Size = New System.Drawing.Size(69, 19)
      Me.rbtnFacturas.TabIndex = 0
      Me.rbtnFacturas.TabStop = True
      Me.rbtnFacturas.Text = "Facturas"
      Me.rbtnFacturas.UseVisualStyleBackColor = True
      '
      'actxnSaldoAnteriorFletes
      '
      Me.actxnSaldoAnteriorFletes.ACEnteros = 9
      Me.actxnSaldoAnteriorFletes.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnSaldoAnteriorFletes.ACNegativo = True
      Me.actxnSaldoAnteriorFletes.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnSaldoAnteriorFletes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxnSaldoAnteriorFletes.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxnSaldoAnteriorFletes.Location = New System.Drawing.Point(658, 13)
      Me.actxnSaldoAnteriorFletes.MaxLength = 12
      Me.actxnSaldoAnteriorFletes.Name = "actxnSaldoAnteriorFletes"
      Me.actxnSaldoAnteriorFletes.Size = New System.Drawing.Size(118, 26)
      Me.actxnSaldoAnteriorFletes.TabIndex = 26
      Me.actxnSaldoAnteriorFletes.Tag = "EV"
      Me.actxnSaldoAnteriorFletes.Text = "0.00"
      Me.actxnSaldoAnteriorFletes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.Label1.Location = New System.Drawing.Point(549, 17)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(103, 19)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Saldo Anterior :"
      '
      'AcPanelCaption2
      '
      Me.AcPanelCaption2.ACCaption = "Fletes Pendientes"
      Me.AcPanelCaption2.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption2.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption2.Name = "AcPanelCaption2"
      Me.AcPanelCaption2.Size = New System.Drawing.Size(782, 25)
      Me.AcPanelCaption2.TabIndex = 58
      '
      'tpgCEfectivo
      '
      Me.tpgCEfectivo.Controls.Add(Me.c1grdEfectivo)
      Me.tpgCEfectivo.Controls.Add(Me.Panel7)
      Me.tpgCEfectivo.Controls.Add(Me.AcPanelCaption6)
      Me.tpgCEfectivo.Controls.Add(Me.Panel6)
      Me.tpgCEfectivo.Controls.Add(Me.bnavEfectivo)
      Me.tpgCEfectivo.InactiveBackColor = System.Drawing.Color.Empty
      Me.tpgCEfectivo.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tpgCEfectivo.InactiveTextColor = System.Drawing.Color.Empty
      Me.tpgCEfectivo.Location = New System.Drawing.Point(1, 24)
      Me.tpgCEfectivo.Name = "tpgCEfectivo"
      Me.tpgCEfectivo.SelectBackColor = System.Drawing.Color.Empty
      Me.tpgCEfectivo.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tpgCEfectivo.SelectTextColor = System.Drawing.Color.Empty
      Me.tpgCEfectivo.Size = New System.Drawing.Size(782, 444)
      Me.tpgCEfectivo.TabIndex = 7
      Me.tpgCEfectivo.Title = "Cuadre de Efectivo"
      Me.tpgCEfectivo.ToolTip = "Cuadre de Efectivo"
      '
      'c1grdEfectivo
      '
      Me.c1grdEfectivo.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdEfectivo.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdEfectivo.Location = New System.Drawing.Point(0, 60)
      Me.c1grdEfectivo.Name = "c1grdEfectivo"
      Me.c1grdEfectivo.Rows.Count = 2
      Me.c1grdEfectivo.Rows.DefaultSize = 20
      Me.c1grdEfectivo.Size = New System.Drawing.Size(782, 318)
      Me.c1grdEfectivo.StyleInfo = resources.GetString("c1grdEfectivo.StyleInfo")
      Me.c1grdEfectivo.TabIndex = 65
      '
      'Panel7
      '
      Me.Panel7.Controls.Add(Me.chkAgruparEfectivo)
      Me.Panel7.Controls.Add(Me.actxnSaldoAnteriorEfectivo)
      Me.Panel7.Controls.Add(Me.Label6)
      Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel7.Location = New System.Drawing.Point(0, 25)
      Me.Panel7.Name = "Panel7"
      Me.Panel7.Size = New System.Drawing.Size(782, 35)
      Me.Panel7.TabIndex = 69
      '
      'chkAgruparEfectivo
      '
      Me.chkAgruparEfectivo.AutoSize = True
      Me.chkAgruparEfectivo.Location = New System.Drawing.Point(10, 8)
      Me.chkAgruparEfectivo.Name = "chkAgruparEfectivo"
      Me.chkAgruparEfectivo.Size = New System.Drawing.Size(118, 19)
      Me.chkAgruparEfectivo.TabIndex = 27
      Me.chkAgruparEfectivo.Text = "Agrupar por Viaje"
      Me.chkAgruparEfectivo.UseVisualStyleBackColor = True
      '
      'actxnSaldoAnteriorEfectivo
      '
      Me.actxnSaldoAnteriorEfectivo.ACEnteros = 9
      Me.actxnSaldoAnteriorEfectivo.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnSaldoAnteriorEfectivo.ACNegativo = True
      Me.actxnSaldoAnteriorEfectivo.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnSaldoAnteriorEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxnSaldoAnteriorEfectivo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxnSaldoAnteriorEfectivo.Location = New System.Drawing.Point(652, 3)
      Me.actxnSaldoAnteriorEfectivo.MaxLength = 12
      Me.actxnSaldoAnteriorEfectivo.Name = "actxnSaldoAnteriorEfectivo"
      Me.actxnSaldoAnteriorEfectivo.Size = New System.Drawing.Size(118, 26)
      Me.actxnSaldoAnteriorEfectivo.TabIndex = 26
      Me.actxnSaldoAnteriorEfectivo.Tag = "EV"
      Me.actxnSaldoAnteriorEfectivo.Text = "0.00"
      Me.actxnSaldoAnteriorEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.Label6.Location = New System.Drawing.Point(543, 6)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(103, 19)
      Me.Label6.TabIndex = 0
      Me.Label6.Text = "Saldo Anterior :"
      '
      'AcPanelCaption6
      '
      Me.AcPanelCaption6.ACCaption = "Cuadre de Efectivo"
      Me.AcPanelCaption6.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption6.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption6.Name = "AcPanelCaption6"
      Me.AcPanelCaption6.Size = New System.Drawing.Size(782, 25)
      Me.AcPanelCaption6.TabIndex = 67
      '
      'Panel6
      '
      Me.Panel6.Controls.Add(Me.actxnSaldoEfectivo)
      Me.Panel6.Controls.Add(Me.Label5)
      Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel6.Location = New System.Drawing.Point(0, 378)
      Me.Panel6.Name = "Panel6"
      Me.Panel6.Size = New System.Drawing.Size(782, 41)
      Me.Panel6.TabIndex = 66
      '
      'actxnSaldoEfectivo
      '
      Me.actxnSaldoEfectivo.ACEnteros = 9
      Me.actxnSaldoEfectivo.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnSaldoEfectivo.ACNegativo = True
      Me.actxnSaldoEfectivo.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnSaldoEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxnSaldoEfectivo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxnSaldoEfectivo.Location = New System.Drawing.Point(652, 7)
      Me.actxnSaldoEfectivo.MaxLength = 12
      Me.actxnSaldoEfectivo.Name = "actxnSaldoEfectivo"
      Me.actxnSaldoEfectivo.Size = New System.Drawing.Size(118, 26)
      Me.actxnSaldoEfectivo.TabIndex = 26
      Me.actxnSaldoEfectivo.Tag = "EV"
      Me.actxnSaldoEfectivo.Text = "0.00"
      Me.actxnSaldoEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.Label5.Location = New System.Drawing.Point(555, 10)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(91, 19)
      Me.Label5.TabIndex = 0
      Me.Label5.Text = "Saldo Actual :"
      '
      'bnavEfectivo
      '
      Me.bnavEfectivo.AddNewItem = Me.ToolStripButton19
      Me.bnavEfectivo.CountItem = Me.ToolStripLabel4
      Me.bnavEfectivo.DeleteItem = Me.ToolStripButton20
      Me.bnavEfectivo.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavEfectivo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton21, Me.ToolStripButton22, Me.ToolStripSeparator10, Me.ToolStripTextBox4, Me.ToolStripLabel4, Me.ToolStripSeparator11, Me.ToolStripButton23, Me.ToolStripButton24, Me.ToolStripSeparator12, Me.ToolStripButton19, Me.ToolStripButton20})
      Me.bnavEfectivo.Location = New System.Drawing.Point(0, 419)
      Me.bnavEfectivo.MoveFirstItem = Me.ToolStripButton21
      Me.bnavEfectivo.MoveLastItem = Me.ToolStripButton24
      Me.bnavEfectivo.MoveNextItem = Me.ToolStripButton23
      Me.bnavEfectivo.MovePreviousItem = Me.ToolStripButton22
      Me.bnavEfectivo.Name = "bnavEfectivo"
      Me.bnavEfectivo.PositionItem = Me.ToolStripTextBox4
      Me.bnavEfectivo.Size = New System.Drawing.Size(782, 25)
      Me.bnavEfectivo.TabIndex = 68
      Me.bnavEfectivo.Text = "BindingNavigator1"
      '
      'ToolStripButton19
      '
      Me.ToolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton19.Image = CType(resources.GetObject("ToolStripButton19.Image"), System.Drawing.Image)
      Me.ToolStripButton19.Name = "ToolStripButton19"
      Me.ToolStripButton19.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton19.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton19.Text = "Add new"
      Me.ToolStripButton19.Visible = False
      '
      'ToolStripLabel4
      '
      Me.ToolStripLabel4.Name = "ToolStripLabel4"
      Me.ToolStripLabel4.Size = New System.Drawing.Size(35, 22)
      Me.ToolStripLabel4.Text = "of {0}"
      Me.ToolStripLabel4.ToolTipText = "Total number of items"
      '
      'ToolStripButton20
      '
      Me.ToolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton20.Image = CType(resources.GetObject("ToolStripButton20.Image"), System.Drawing.Image)
      Me.ToolStripButton20.Name = "ToolStripButton20"
      Me.ToolStripButton20.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton20.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton20.Text = "Delete"
      Me.ToolStripButton20.Visible = False
      '
      'ToolStripButton21
      '
      Me.ToolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton21.Image = CType(resources.GetObject("ToolStripButton21.Image"), System.Drawing.Image)
      Me.ToolStripButton21.Name = "ToolStripButton21"
      Me.ToolStripButton21.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton21.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton21.Text = "Move first"
      '
      'ToolStripButton22
      '
      Me.ToolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton22.Image = CType(resources.GetObject("ToolStripButton22.Image"), System.Drawing.Image)
      Me.ToolStripButton22.Name = "ToolStripButton22"
      Me.ToolStripButton22.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton22.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton22.Text = "Move previous"
      '
      'ToolStripSeparator10
      '
      Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
      Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripTextBox4
      '
      Me.ToolStripTextBox4.AccessibleName = "Position"
      Me.ToolStripTextBox4.AutoSize = False
      Me.ToolStripTextBox4.Name = "ToolStripTextBox4"
      Me.ToolStripTextBox4.Size = New System.Drawing.Size(50, 23)
      Me.ToolStripTextBox4.Text = "0"
      Me.ToolStripTextBox4.ToolTipText = "Current position"
      '
      'ToolStripSeparator11
      '
      Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
      Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripButton23
      '
      Me.ToolStripButton23.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton23.Image = CType(resources.GetObject("ToolStripButton23.Image"), System.Drawing.Image)
      Me.ToolStripButton23.Name = "ToolStripButton23"
      Me.ToolStripButton23.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton23.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton23.Text = "Move next"
      '
      'ToolStripButton24
      '
      Me.ToolStripButton24.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton24.Image = CType(resources.GetObject("ToolStripButton24.Image"), System.Drawing.Image)
      Me.ToolStripButton24.Name = "ToolStripButton24"
      Me.ToolStripButton24.RightToLeftAutoMirrorImage = True
      Me.ToolStripButton24.Size = New System.Drawing.Size(23, 22)
      Me.ToolStripButton24.Text = "Move last"
      '
      'ToolStripSeparator12
      '
      Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
      Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
      '
      'tpgPagosPendientes
      '
      Me.tpgPagosPendientes.Controls.Add(Me.c1grdPendientesPagadas)
      Me.tpgPagosPendientes.Controls.Add(Me.bnavPendientesPagados)
      Me.tpgPagosPendientes.Controls.Add(Me.AcPanelCaption3)
      Me.tpgPagosPendientes.InactiveBackColor = System.Drawing.Color.Empty
      Me.tpgPagosPendientes.InactiveTextBackColor = System.Drawing.Color.Empty
      Me.tpgPagosPendientes.InactiveTextColor = System.Drawing.Color.Empty
      Me.tpgPagosPendientes.Location = New System.Drawing.Point(1, 24)
      Me.tpgPagosPendientes.Name = "tpgPagosPendientes"
      Me.tpgPagosPendientes.SelectBackColor = System.Drawing.Color.Empty
      Me.tpgPagosPendientes.Selected = False
      Me.tpgPagosPendientes.SelectTextBackColor = System.Drawing.Color.Empty
      Me.tpgPagosPendientes.SelectTextColor = System.Drawing.Color.Empty
      Me.tpgPagosPendientes.Size = New System.Drawing.Size(782, 444)
      Me.tpgPagosPendientes.TabIndex = 8
      Me.tpgPagosPendientes.Title = "Pagos de Pendientes"
      Me.tpgPagosPendientes.ToolTip = "Pagos de Pendientes"
      '
      'c1grdPendientesPagadas
      '
      Me.c1grdPendientesPagadas.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdPendientesPagadas.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdPendientesPagadas.Location = New System.Drawing.Point(0, 25)
      Me.c1grdPendientesPagadas.Name = "c1grdPendientesPagadas"
      Me.c1grdPendientesPagadas.Rows.Count = 2
      Me.c1grdPendientesPagadas.Rows.DefaultSize = 20
      Me.c1grdPendientesPagadas.Size = New System.Drawing.Size(782, 394)
      Me.c1grdPendientesPagadas.StyleInfo = resources.GetString("c1grdPendientesPagadas.StyleInfo")
      Me.c1grdPendientesPagadas.TabIndex = 65
      '
      'bnavPendientesPagados
      '
      Me.bnavPendientesPagados.AddNewItem = Me.ToolStripButton1
      Me.bnavPendientesPagados.CountItem = Me.ToolStripLabel1
      Me.bnavPendientesPagados.DeleteItem = Me.ToolStripButton2
      Me.bnavPendientesPagados.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavPendientesPagados.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2})
      Me.bnavPendientesPagados.Location = New System.Drawing.Point(0, 419)
      Me.bnavPendientesPagados.MoveFirstItem = Me.ToolStripButton3
      Me.bnavPendientesPagados.MoveLastItem = Me.ToolStripButton6
      Me.bnavPendientesPagados.MoveNextItem = Me.ToolStripButton5
      Me.bnavPendientesPagados.MovePreviousItem = Me.ToolStripButton4
      Me.bnavPendientesPagados.Name = "bnavPendientesPagados"
      Me.bnavPendientesPagados.PositionItem = Me.ToolStripTextBox1
      Me.bnavPendientesPagados.Size = New System.Drawing.Size(782, 25)
      Me.bnavPendientesPagados.TabIndex = 64
      Me.bnavPendientesPagados.Text = "BindingNavigator1"
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
      Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 23)
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
      'AcPanelCaption3
      '
      Me.AcPanelCaption3.ACCaption = "Pagos Realizados en la Fecha"
      Me.AcPanelCaption3.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption3.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption3.Name = "AcPanelCaption3"
      Me.AcPanelCaption3.Size = New System.Drawing.Size(782, 25)
      Me.AcPanelCaption3.TabIndex = 63
      '
      'CFletesCaja
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(784, 562)
      Me.Controls.Add(Me.tctReporte)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.AcPanelCaption1)
      Me.Name = "CFletesCaja"
      Me.Text = "Consulta de Fletes y Efectivo"
      Me.Panel1.ResumeLayout(False)
      Me.tctReporte.ResumeLayout(False)
      Me.tpgFletes.ResumeLayout(False)
      Me.spcFletes.Panel1.ResumeLayout(False)
      Me.spcFletes.Panel1.PerformLayout()
      Me.spcFletes.Panel2.ResumeLayout(False)
      CType(Me.spcFletes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spcFletes.ResumeLayout(False)
      CType(Me.c1grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel3.ResumeLayout(False)
      Me.Panel3.PerformLayout()
      CType(Me.bnavReporte, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavReporte.ResumeLayout(False)
      Me.bnavReporte.PerformLayout()
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.PerformLayout()
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.Panel2.PerformLayout()
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.ResumeLayout(False)
      CType(Me.c1grdPagosRealizados, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavPagos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavPagos.ResumeLayout(False)
      Me.bnavPagos.PerformLayout()
      CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavFletes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavFletes.ResumeLayout(False)
      Me.bnavFletes.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.tpgCEfectivo.ResumeLayout(False)
      Me.tpgCEfectivo.PerformLayout()
      CType(Me.c1grdEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel7.ResumeLayout(False)
      Me.Panel7.PerformLayout()
      Me.Panel6.ResumeLayout(False)
      Me.Panel6.PerformLayout()
      CType(Me.bnavEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavEfectivo.ResumeLayout(False)
      Me.bnavEfectivo.PerformLayout()
      Me.tpgPagosPendientes.ResumeLayout(False)
      Me.tpgPagosPendientes.PerformLayout()
      CType(Me.c1grdPendientesPagadas, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavPendientesPagados, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavPendientesPagados.ResumeLayout(False)
      Me.bnavPendientesPagados.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents btnExcel As System.Windows.Forms.Button
   Friend WithEvents btnProcesar As System.Windows.Forms.Button
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Private WithEvents tctReporte As Crownwood.DotNetMagic.Controls.TabControl
   Private WithEvents tpgFletes As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents actxnSaldoAnteriorFletes As ACControles.ACTextBoxNumerico
   Friend WithEvents AcPanelCaption2 As ACControles.ACPanelCaption
   Friend WithEvents spcFletes As System.Windows.Forms.SplitContainer
   Friend WithEvents c1grdReporte As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents actxnSaldoFletes As ACControles.ACTextBoxNumerico
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents bnavReporte As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents c1grdPagosRealizados As C1.Win.C1FlexGrid.C1FlexGrid
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
   Friend WithEvents tpgCEfectivo As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents c1grdEfectivo As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents AcPanelCaption6 As ACControles.ACPanelCaption
   Friend WithEvents Panel6 As System.Windows.Forms.Panel
   Friend WithEvents actxnSaldoEfectivo As ACControles.ACTextBoxNumerico
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents bnavEfectivo As System.Windows.Forms.BindingNavigator
   Friend WithEvents ToolStripButton19 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripButton20 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton21 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton22 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripTextBox4 As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton23 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton24 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents Panel7 As System.Windows.Forms.Panel
   Friend WithEvents actxnSaldoAnteriorEfectivo As ACControles.ACTextBoxNumerico
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents chkAgruparEfectivo As System.Windows.Forms.CheckBox
   Friend WithEvents tpgPagosPendientes As Crownwood.DotNetMagic.Controls.TabPage
   Friend WithEvents c1grdPendientesPagadas As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavPendientesPagados As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents AcPanelCaption3 As ACControles.ACPanelCaption
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents AcPanelCaption5 As ACControles.ACPanelCaption
   Friend WithEvents c1grdDetalle As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents AcPanelCaption4 As ACControles.ACPanelCaption
   Friend WithEvents bnavFletes As System.Windows.Forms.BindingNavigator
   Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtnFletes As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnFacturas As System.Windows.Forms.RadioButton
   Friend WithEvents actxaCliRazonSocial As ACControles.ACTextBoxAyuda
   Friend WithEvents lblNroDocumento As System.Windows.Forms.Label
   Friend WithEvents actxaCliRuc As ACControles.ACTextBoxAyuda
   Friend WithEvents btnClean As System.Windows.Forms.Button
   Friend WithEvents rbtnFleSinFacturar As System.Windows.Forms.RadioButton
End Class
