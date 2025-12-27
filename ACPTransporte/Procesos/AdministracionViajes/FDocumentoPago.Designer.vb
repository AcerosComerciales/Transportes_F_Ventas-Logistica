<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FDocumentoPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FDocumentoPago))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.c1grdDocumentoPagoDet = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.bnavDetDocPago = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton25 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripButton26 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton27 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton28 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox5 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton29 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton30 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.acTool = New ACControles.ACToolBarMantHorizontal
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Panel1.SuspendLayout()
        CType(Me.c1grdDocumentoPagoDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavDetDocPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavDetDocPago.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.c1grdDocumentoPagoDet)
        Me.Panel1.Controls.Add(Me.bnavDetDocPago)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(620, 481)
        Me.Panel1.TabIndex = 18
        '
        'c1grdDocumentoPagoDet
        '
        Me.c1grdDocumentoPagoDet.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdDocumentoPagoDet.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.c1grdDocumentoPagoDet.Location = New System.Drawing.Point(0, 188)
        Me.c1grdDocumentoPagoDet.Name = "c1grdDocumentoPagoDet"
        Me.c1grdDocumentoPagoDet.Rows.Count = 2
        Me.c1grdDocumentoPagoDet.Rows.DefaultSize = 18
        Me.c1grdDocumentoPagoDet.Size = New System.Drawing.Size(620, 268)
        Me.c1grdDocumentoPagoDet.StyleInfo = resources.GetString("c1grdDocumentoPagoDet.StyleInfo")
        Me.c1grdDocumentoPagoDet.TabIndex = 38
        '
        'bnavDetDocPago
        '
        Me.bnavDetDocPago.AddNewItem = Me.ToolStripButton25
        Me.bnavDetDocPago.CountItem = Me.ToolStripLabel5
        Me.bnavDetDocPago.DeleteItem = Me.ToolStripButton26
        Me.bnavDetDocPago.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavDetDocPago.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton27, Me.ToolStripButton28, Me.ToolStripSeparator13, Me.ToolStripTextBox5, Me.ToolStripLabel5, Me.ToolStripSeparator14, Me.ToolStripButton29, Me.ToolStripButton30, Me.ToolStripSeparator15, Me.ToolStripButton25, Me.ToolStripButton26, Me.ToolStripButton2, Me.ToolStripButton1})
        Me.bnavDetDocPago.Location = New System.Drawing.Point(0, 456)
        Me.bnavDetDocPago.MoveFirstItem = Me.ToolStripButton27
        Me.bnavDetDocPago.MoveLastItem = Me.ToolStripButton30
        Me.bnavDetDocPago.MoveNextItem = Me.ToolStripButton29
        Me.bnavDetDocPago.MovePreviousItem = Me.ToolStripButton28
        Me.bnavDetDocPago.Name = "bnavDetDocPago"
        Me.bnavDetDocPago.PositionItem = Me.ToolStripTextBox5
        Me.bnavDetDocPago.Size = New System.Drawing.Size(620, 25)
        Me.bnavDetDocPago.TabIndex = 39
        Me.bnavDetDocPago.Text = "BindingNavigator1"
        '
        'ToolStripButton25
        '
        Me.ToolStripButton25.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton25.Image = CType(resources.GetObject("ToolStripButton25.Image"), System.Drawing.Image)
        Me.ToolStripButton25.Name = "ToolStripButton25"
        Me.ToolStripButton25.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton25.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton25.Text = "Add new"
        Me.ToolStripButton25.Visible = False
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel5.Text = "of {0}"
        Me.ToolStripLabel5.ToolTipText = "Total number of items"
        '
        'ToolStripButton26
        '
        Me.ToolStripButton26.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton26.Image = CType(resources.GetObject("ToolStripButton26.Image"), System.Drawing.Image)
        Me.ToolStripButton26.Name = "ToolStripButton26"
        Me.ToolStripButton26.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton26.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton26.Text = "Delete"
        Me.ToolStripButton26.Visible = False
        '
        'ToolStripButton27
        '
        Me.ToolStripButton27.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton27.Image = CType(resources.GetObject("ToolStripButton27.Image"), System.Drawing.Image)
        Me.ToolStripButton27.Name = "ToolStripButton27"
        Me.ToolStripButton27.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton27.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton27.Text = "Move first"
        '
        'ToolStripButton28
        '
        Me.ToolStripButton28.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton28.Image = CType(resources.GetObject("ToolStripButton28.Image"), System.Drawing.Image)
        Me.ToolStripButton28.Name = "ToolStripButton28"
        Me.ToolStripButton28.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton28.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton28.Text = "Move previous"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox5
        '
        Me.ToolStripTextBox5.AccessibleName = "Position"
        Me.ToolStripTextBox5.AutoSize = False
        Me.ToolStripTextBox5.Name = "ToolStripTextBox5"
        Me.ToolStripTextBox5.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox5.Text = "0"
        Me.ToolStripTextBox5.ToolTipText = "Current position"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton29
        '
        Me.ToolStripButton29.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton29.Image = CType(resources.GetObject("ToolStripButton29.Image"), System.Drawing.Image)
        Me.ToolStripButton29.Name = "ToolStripButton29"
        Me.ToolStripButton29.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton29.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton29.Text = "Move next"
        '
        'ToolStripButton30
        '
        Me.ToolStripButton30.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton30.Image = CType(resources.GetObject("ToolStripButton30.Image"), System.Drawing.Image)
        Me.ToolStripButton30.Name = "ToolStripButton30"
        Me.ToolStripButton30.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton30.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton30.Text = "Move last"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.ACPTransportes.My.Resources.Resources.ACReporte_16x16
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Descripcion"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(138, 46)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(453, 20)
        Me.TextBox3.TabIndex = 34
        '
        'acTool
        '
        Me.acTool.ACTipoBoton = ACControles.ACToolBarMantHorizontal.TipoBoton.Eliminar
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontal.tipoToolBar.ToolNuevoGrabarEliminar
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Location = New System.Drawing.Point(0, 481)
        Me.acTool.MinimumSize = New System.Drawing.Size(495, 60)
        Me.acTool.Name = "acTool"
        Me.acTool.RehusarAnchor = System.Windows.Forms.AnchorStyles.Top
        Me.acTool.RehusarImage = CType(resources.GetObject("acTool.RehusarImage"), System.Drawing.Image)
        Me.acTool.RehusarLocation = New System.Drawing.Point(443, 2)
        Me.acTool.RehusarSize = New System.Drawing.Size(79, 53)
        Me.acTool.RehusaText = "Re&husar"
        Me.acTool.Size = New System.Drawing.Size(620, 60)
        Me.acTool.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(620, 186)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento Pago"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(138, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(201, 21)
        Me.ComboBox1.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Tipo Documento"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(438, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(153, 20)
        Me.TextBox1.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(350, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Nro Documento"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(438, 72)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(153, 20)
        Me.TextBox4.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(350, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Valor Total"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Fecha"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(138, 72)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(199, 20)
        Me.DateTimePicker2.TabIndex = 38
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(138, 125)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(464, 48)
        Me.TextBox2.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Glosa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Fecha Pago Acordado"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(138, 99)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(199, 20)
        Me.DateTimePicker1.TabIndex = 44
        '
        'FDocumentoPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 541)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.acTool)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FDocumentoPago"
        Me.Text = "Documentos Pago"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.c1grdDocumentoPagoDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavDetDocPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavDetDocPago.ResumeLayout(False)
        Me.bnavDetDocPago.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents acTool As ACControles.ACToolBarMantHorizontal
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents c1grdDocumentoPagoDet As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavDetDocPago As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton25 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton26 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton27 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton28 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox5 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton29 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton30 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
End Class
