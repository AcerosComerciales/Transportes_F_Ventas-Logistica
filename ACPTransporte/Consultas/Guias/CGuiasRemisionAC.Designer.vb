<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CGuiasRemisionAC
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CGuiasRemisionAC))
      Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.actxaDescProveedor = New ACControles.ACTextBoxAyuda()
      Me.actxaNroDocProveedor = New ACControles.ACTextBoxAyuda()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblNroDocumento = New System.Windows.Forms.Label()
      Me.cmbPuntoVenta = New System.Windows.Forms.ComboBox()
      Me.AcFecha = New ACControles.ACFecha(Me.components)
      Me.btnExcel = New System.Windows.Forms.Button()
      Me.btnProcesar = New System.Windows.Forms.Button()
      Me.c1grdReporte = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.bnavReporte = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.Panel1.SuspendLayout()
      CType(Me.c1grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavReporte, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavReporte.SuspendLayout()
      Me.SuspendLayout()
      '
      'AcPanelCaption1
      '
      Me.AcPanelCaption1.ACCaption = "Guias de Remisión por Punto de Venta"
      Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption1.Name = "AcPanelCaption1"
      Me.AcPanelCaption1.Size = New System.Drawing.Size(660, 30)
      Me.AcPanelCaption1.TabIndex = 51
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.actxaDescProveedor)
      Me.Panel1.Controls.Add(Me.actxaNroDocProveedor)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.lblNroDocumento)
      Me.Panel1.Controls.Add(Me.cmbPuntoVenta)
      Me.Panel1.Controls.Add(Me.AcFecha)
      Me.Panel1.Controls.Add(Me.btnExcel)
      Me.Panel1.Controls.Add(Me.btnProcesar)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 30)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(660, 108)
      Me.Panel1.TabIndex = 52
      '
      'actxaDescProveedor
      '
      Me.actxaDescProveedor.ACActivarAyudaAuto = False
      Me.actxaDescProveedor.ACLongitudAceptada = 0
      Me.actxaDescProveedor.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaDescProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxaDescProveedor.Location = New System.Drawing.Point(379, 79)
      Me.actxaDescProveedor.MaxLength = 50
      Me.actxaDescProveedor.Name = "actxaDescProveedor"
      Me.actxaDescProveedor.Size = New System.Drawing.Size(277, 20)
      Me.actxaDescProveedor.TabIndex = 12
      Me.actxaDescProveedor.Tag = "EVO"
      '
      'actxaNroDocProveedor
      '
      Me.actxaNroDocProveedor.ACActivarAyudaAuto = False
      Me.actxaNroDocProveedor.ACLongitudAceptada = 0
      Me.actxaNroDocProveedor.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaNroDocProveedor.Location = New System.Drawing.Point(254, 79)
      Me.actxaNroDocProveedor.MaxLength = 32767
      Me.actxaNroDocProveedor.Name = "actxaNroDocProveedor"
      Me.actxaNroDocProveedor.Size = New System.Drawing.Size(117, 20)
      Me.actxaNroDocProveedor.TabIndex = 11
      Me.actxaNroDocProveedor.Tag = "EVO"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 60)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(81, 13)
      Me.Label1.TabIndex = 27
      Me.Label1.Text = "Punto de Venta"
      '
      'lblNroDocumento
      '
      Me.lblNroDocumento.AutoSize = True
      Me.lblNroDocumento.Location = New System.Drawing.Point(259, 60)
      Me.lblNroDocumento.Name = "lblNroDocumento"
      Me.lblNroDocumento.Size = New System.Drawing.Size(39, 13)
      Me.lblNroDocumento.TabIndex = 10
      Me.lblNroDocumento.Text = "Cliente"
      '
      'cmbPuntoVenta
      '
      Me.cmbPuntoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPuntoVenta.FormattingEnabled = True
      Me.cmbPuntoVenta.Location = New System.Drawing.Point(15, 78)
      Me.cmbPuntoVenta.Name = "cmbPuntoVenta"
      Me.cmbPuntoVenta.Size = New System.Drawing.Size(223, 21)
      Me.cmbPuntoVenta.TabIndex = 26
      '
      'AcFecha
      '
      Me.AcFecha.ACFecha_A = New Date(2012, 6, 4, 14, 35, 1, 527)
      Me.AcFecha.ACFecha_De = New Date(2012, 6, 4, 14, 35, 1, 524)
      Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
      Me.AcFecha.ACHoyChecked = False
      Me.AcFecha.ACIncrementoFecha_A = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.AcFecha.ACIncrementoFecha_De = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.AcFecha.ACIntervalos = ACControles.ACFecha.ACIntervalo.Ninguno
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
      Me.btnExcel.Location = New System.Drawing.Point(492, 5)
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
      Me.btnProcesar.Location = New System.Drawing.Point(366, 5)
      Me.btnProcesar.Name = "btnProcesar"
      Me.btnProcesar.Size = New System.Drawing.Size(120, 41)
      Me.btnProcesar.TabIndex = 7
      Me.btnProcesar.Text = "Procesar"
      Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnProcesar.UseVisualStyleBackColor = True
      '
      'c1grdReporte
      '
      Me.c1grdReporte.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdReporte.Location = New System.Drawing.Point(0, 138)
      Me.c1grdReporte.Name = "c1grdReporte"
      Me.c1grdReporte.Rows.Count = 2
      Me.c1grdReporte.Rows.DefaultSize = 20
      Me.c1grdReporte.Size = New System.Drawing.Size(660, 350)
      Me.c1grdReporte.StyleInfo = resources.GetString("c1grdReporte.StyleInfo")
      Me.c1grdReporte.TabIndex = 67
      '
      'bnavReporte
      '
      Me.bnavReporte.AddNewItem = Me.ToolStripButton1
      Me.bnavReporte.CountItem = Me.ToolStripLabel1
      Me.bnavReporte.DeleteItem = Me.ToolStripButton2
      Me.bnavReporte.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavReporte.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2})
      Me.bnavReporte.Location = New System.Drawing.Point(0, 488)
      Me.bnavReporte.MoveFirstItem = Me.ToolStripButton3
      Me.bnavReporte.MoveLastItem = Me.ToolStripButton6
      Me.bnavReporte.MoveNextItem = Me.ToolStripButton5
      Me.bnavReporte.MovePreviousItem = Me.ToolStripButton4
      Me.bnavReporte.Name = "bnavReporte"
      Me.bnavReporte.PositionItem = Me.ToolStripTextBox1
      Me.bnavReporte.Size = New System.Drawing.Size(660, 25)
      Me.bnavReporte.TabIndex = 66
      Me.bnavReporte.Text = "BindingNavigator1"
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
      'CGuiasRemisionAC
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(660, 513)
      Me.Controls.Add(Me.c1grdReporte)
      Me.Controls.Add(Me.bnavReporte)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.AcPanelCaption1)
      Me.Name = "CGuiasRemisionAC"
      Me.Text = "Guias de Remisión por Punto de Venta"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.c1grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavReporte, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavReporte.ResumeLayout(False)
      Me.bnavReporte.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents btnExcel As System.Windows.Forms.Button
   Friend WithEvents btnProcesar As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmbPuntoVenta As System.Windows.Forms.ComboBox
   Friend WithEvents c1grdReporte As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavReporte As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents actxaDescProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents actxaNroDocProveedor As ACControles.ACTextBoxAyuda
   Friend WithEvents lblNroDocumento As System.Windows.Forms.Label
End Class
