<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CViajesFletes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CViajesFletes))
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.chkAgruparEfectivo = New System.Windows.Forms.CheckBox()
      Me.AcFecha = New ACControles.ACFecha(Me.components)
      Me.btnExcel = New System.Windows.Forms.Button()
      Me.btnProcesar = New System.Windows.Forms.Button()
      Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
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
      Me.c1grdReporte = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.Panel1.SuspendLayout()
      CType(Me.bnavReporte, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavReporte.SuspendLayout()
      CType(Me.c1grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.chkAgruparEfectivo)
      Me.Panel1.Controls.Add(Me.AcFecha)
      Me.Panel1.Controls.Add(Me.btnExcel)
      Me.Panel1.Controls.Add(Me.btnProcesar)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 30)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(735, 63)
      Me.Panel1.TabIndex = 63
      '
      'chkAgruparEfectivo
      '
      Me.chkAgruparEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkAgruparEfectivo.AutoSize = True
      Me.chkAgruparEfectivo.Location = New System.Drawing.Point(454, 46)
      Me.chkAgruparEfectivo.Name = "chkAgruparEfectivo"
      Me.chkAgruparEfectivo.Size = New System.Drawing.Size(107, 17)
      Me.chkAgruparEfectivo.TabIndex = 29
      Me.chkAgruparEfectivo.Text = "Agrupar por Viaje"
      Me.chkAgruparEfectivo.UseVisualStyleBackColor = True
      '
      'AcFecha
      '
      Me.AcFecha.ACFecha_A = New Date(2012, 6, 4, 15, 52, 48, 250)
      Me.AcFecha.ACFecha_De = New Date(2012, 6, 4, 15, 52, 48, 248)
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
      Me.btnExcel.Location = New System.Drawing.Point(567, 1)
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
      Me.btnProcesar.Location = New System.Drawing.Point(441, 1)
      Me.btnProcesar.Name = "btnProcesar"
      Me.btnProcesar.Size = New System.Drawing.Size(120, 41)
      Me.btnProcesar.TabIndex = 7
      Me.btnProcesar.Text = "Procesar"
      Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnProcesar.UseVisualStyleBackColor = True
      '
      'AcPanelCaption1
      '
      Me.AcPanelCaption1.ACCaption = "Reporte de Cuadre de Caja"
      Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption1.Name = "AcPanelCaption1"
      Me.AcPanelCaption1.Size = New System.Drawing.Size(735, 30)
      Me.AcPanelCaption1.TabIndex = 62
      '
      'bnavReporte
      '
      Me.bnavReporte.AddNewItem = Me.ToolStripButton1
      Me.bnavReporte.CountItem = Me.ToolStripLabel1
      Me.bnavReporte.DeleteItem = Me.ToolStripButton2
      Me.bnavReporte.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavReporte.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2})
      Me.bnavReporte.Location = New System.Drawing.Point(0, 447)
      Me.bnavReporte.MoveFirstItem = Me.ToolStripButton3
      Me.bnavReporte.MoveLastItem = Me.ToolStripButton6
      Me.bnavReporte.MoveNextItem = Me.ToolStripButton5
      Me.bnavReporte.MovePreviousItem = Me.ToolStripButton4
      Me.bnavReporte.Name = "bnavReporte"
      Me.bnavReporte.PositionItem = Me.ToolStripTextBox1
      Me.bnavReporte.Size = New System.Drawing.Size(735, 25)
      Me.bnavReporte.TabIndex = 64
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
      'c1grdReporte
      '
      Me.c1grdReporte.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdReporte.Location = New System.Drawing.Point(0, 93)
      Me.c1grdReporte.Name = "c1grdReporte"
      Me.c1grdReporte.Rows.Count = 2
      Me.c1grdReporte.Rows.DefaultSize = 20
      Me.c1grdReporte.Size = New System.Drawing.Size(735, 354)
      Me.c1grdReporte.StyleInfo = resources.GetString("c1grdReporte.StyleInfo")
      Me.c1grdReporte.TabIndex = 65
      '
      'CViajesFletes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(735, 472)
      Me.Controls.Add(Me.c1grdReporte)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.AcPanelCaption1)
      Me.Controls.Add(Me.bnavReporte)
      Me.Name = "CViajesFletes"
      Me.Text = "CViajesFletes"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.bnavReporte, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavReporte.ResumeLayout(False)
      Me.bnavReporte.PerformLayout()
      CType(Me.c1grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents btnExcel As System.Windows.Forms.Button
   Friend WithEvents btnProcesar As System.Windows.Forms.Button
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
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
   Friend WithEvents chkAgruparEfectivo As System.Windows.Forms.CheckBox
   Friend WithEvents c1grdReporte As C1.Win.C1FlexGrid.C1FlexGrid
End Class
