<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPendientes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RPendientes))
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.AcFecha = New ACControles.ACFecha(Me.components)
      Me.btnExcel = New System.Windows.Forms.Button()
      Me.btnProcesar = New System.Windows.Forms.Button()
      Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
      Me.c1grdReporte = New C1.Win.C1FlexGrid.C1FlexGrid()
      Me.bnavReporte = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.actxnPagado = New ACControles.ACTextBoxNumerico()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.actxnPendiente = New ACControles.ACTextBoxNumerico()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Panel1.SuspendLayout()
      CType(Me.c1grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bnavReporte, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavReporte.SuspendLayout()
      Me.Panel3.SuspendLayout()
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
      Me.Panel1.Size = New System.Drawing.Size(717, 63)
      Me.Panel1.TabIndex = 53
      '
      'AcFecha
      '
      Me.AcFecha.ACFecha_A = New Date(2012, 5, 30, 15, 37, 43, 381)
      Me.AcFecha.ACFecha_De = New Date(2012, 5, 30, 15, 37, 43, 380)
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
      Me.btnExcel.Location = New System.Drawing.Point(549, 3)
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
      Me.btnProcesar.Location = New System.Drawing.Point(423, 3)
      Me.btnProcesar.Name = "btnProcesar"
      Me.btnProcesar.Size = New System.Drawing.Size(120, 41)
      Me.btnProcesar.TabIndex = 7
      Me.btnProcesar.Text = "Procesar"
      Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnProcesar.UseVisualStyleBackColor = True
      '
      'AcPanelCaption1
      '
      Me.AcPanelCaption1.ACCaption = "Reporte de Cuadre de Caja: "
      Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption1.Name = "AcPanelCaption1"
      Me.AcPanelCaption1.Size = New System.Drawing.Size(717, 30)
      Me.AcPanelCaption1.TabIndex = 52
      '
      'c1grdReporte
      '
      Me.c1grdReporte.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
      Me.c1grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
      Me.c1grdReporte.Location = New System.Drawing.Point(0, 93)
      Me.c1grdReporte.Name = "c1grdReporte"
      Me.c1grdReporte.Rows.Count = 2
      Me.c1grdReporte.Rows.DefaultSize = 20
      Me.c1grdReporte.Size = New System.Drawing.Size(717, 209)
      Me.c1grdReporte.StyleInfo = resources.GetString("c1grdReporte.StyleInfo")
      Me.c1grdReporte.TabIndex = 69
      '
      'bnavReporte
      '
      Me.bnavReporte.AddNewItem = Me.ToolStripButton19
      Me.bnavReporte.CountItem = Me.ToolStripLabel4
      Me.bnavReporte.DeleteItem = Me.ToolStripButton20
      Me.bnavReporte.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.bnavReporte.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton21, Me.ToolStripButton22, Me.ToolStripSeparator10, Me.ToolStripTextBox4, Me.ToolStripLabel4, Me.ToolStripSeparator11, Me.ToolStripButton23, Me.ToolStripButton24, Me.ToolStripSeparator12, Me.ToolStripButton19, Me.ToolStripButton20})
      Me.bnavReporte.Location = New System.Drawing.Point(0, 337)
      Me.bnavReporte.MoveFirstItem = Me.ToolStripButton21
      Me.bnavReporte.MoveLastItem = Me.ToolStripButton24
      Me.bnavReporte.MoveNextItem = Me.ToolStripButton23
      Me.bnavReporte.MovePreviousItem = Me.ToolStripButton22
      Me.bnavReporte.Name = "bnavReporte"
      Me.bnavReporte.PositionItem = Me.ToolStripTextBox4
      Me.bnavReporte.Size = New System.Drawing.Size(717, 25)
      Me.bnavReporte.TabIndex = 70
      Me.bnavReporte.Text = "bnavReporte"
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
      'Panel3
      '
      Me.Panel3.Controls.Add(Me.actxnPagado)
      Me.Panel3.Controls.Add(Me.Label1)
      Me.Panel3.Controls.Add(Me.actxnPendiente)
      Me.Panel3.Controls.Add(Me.Label2)
      Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel3.Location = New System.Drawing.Point(0, 302)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(717, 35)
      Me.Panel3.TabIndex = 71
      '
      'actxnPagado
      '
      Me.actxnPagado.ACEnteros = 9
      Me.actxnPagado.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnPagado.ACNegativo = True
      Me.actxnPagado.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnPagado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxnPagado.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxnPagado.Location = New System.Drawing.Point(368, 5)
      Me.actxnPagado.MaxLength = 12
      Me.actxnPagado.Name = "actxnPagado"
      Me.actxnPagado.Size = New System.Drawing.Size(118, 26)
      Me.actxnPagado.TabIndex = 28
      Me.actxnPagado.Tag = "EV"
      Me.actxnPagado.Text = "0.00"
      Me.actxnPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.Label1.Location = New System.Drawing.Point(294, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(62, 19)
      Me.Label1.TabIndex = 27
      Me.Label1.Text = "Pagado :"
      '
      'actxnPendiente
      '
      Me.actxnPendiente.ACEnteros = 9
      Me.actxnPendiente.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnPendiente.ACNegativo = True
      Me.actxnPendiente.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxnPendiente.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxnPendiente.Location = New System.Drawing.Point(587, 5)
      Me.actxnPendiente.MaxLength = 12
      Me.actxnPendiente.Name = "actxnPendiente"
      Me.actxnPendiente.Size = New System.Drawing.Size(118, 26)
      Me.actxnPendiente.TabIndex = 26
      Me.actxnPendiente.Tag = "EV"
      Me.actxnPendiente.Text = "0.00"
      Me.actxnPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.Label2.Location = New System.Drawing.Point(498, 8)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(77, 19)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "Pendiente :"
      '
      'RPendientes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(717, 362)
      Me.Controls.Add(Me.c1grdReporte)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.bnavReporte)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.AcPanelCaption1)
      Me.Name = "RPendientes"
      Me.Text = "RPendientes"
      Me.Panel1.ResumeLayout(False)
      CType(Me.c1grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bnavReporte, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavReporte.ResumeLayout(False)
      Me.bnavReporte.PerformLayout()
      Me.Panel3.ResumeLayout(False)
      Me.Panel3.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents btnExcel As System.Windows.Forms.Button
   Friend WithEvents btnProcesar As System.Windows.Forms.Button
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Friend WithEvents c1grdReporte As C1.Win.C1FlexGrid.C1FlexGrid
   Friend WithEvents bnavReporte As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents actxnPendiente As ACControles.ACTextBoxNumerico
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents actxnPagado As ACControles.ACTextBoxNumerico
   Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
