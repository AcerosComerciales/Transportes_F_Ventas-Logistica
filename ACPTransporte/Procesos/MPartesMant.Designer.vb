<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPartesMant
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
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.actxaDescripcion = New ACControles.ACTextBoxAyuda()
      Me.btnNuevo = New System.Windows.Forms.Button()
      Me.actxaCodigo = New ACControles.ACTextBoxAyuda()
      Me.Label38 = New System.Windows.Forms.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.PictureBox1 = New System.Windows.Forms.PictureBox()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.btnDirecctorio = New System.Windows.Forms.Button()
      Me.txtPathGenerador = New System.Windows.Forms.TextBox()
      Me.txtProcedimiento = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cmbTipoRepuesto = New System.Windows.Forms.ComboBox()
      Me.txtResponsable = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtCantidad = New ACControles.ACTextBoxNumerico()
      Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.tsbtnAceptar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbtnCancelar = New System.Windows.Forms.ToolStripButton()
      Me.tsbtnSalir = New System.Windows.Forms.ToolStripButton()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cmbRepuesto = New System.Windows.Forms.ComboBox()
      Me.txtProvDescripcion = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.actxnTotal = New ACControles.ACTextBoxNumerico()
      Me.grpDocumento = New System.Windows.Forms.GroupBox()
      Me.txtProvCodigo = New System.Windows.Forms.TextBox()
      Me.Panel2.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.ToolStrip1.SuspendLayout()
      Me.grpDocumento.SuspendLayout()
      Me.SuspendLayout()
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.grpDocumento)
      Me.Panel2.Controls.Add(Me.Label1)
      Me.Panel2.Controls.Add(Me.actxaDescripcion)
      Me.Panel2.Controls.Add(Me.btnNuevo)
      Me.Panel2.Controls.Add(Me.actxaCodigo)
      Me.Panel2.Controls.Add(Me.Label38)
      Me.Panel2.Controls.Add(Me.GroupBox1)
      Me.Panel2.Controls.Add(Me.txtProcedimiento)
      Me.Panel2.Controls.Add(Me.Label2)
      Me.Panel2.Controls.Add(Me.Label5)
      Me.Panel2.Controls.Add(Me.cmbTipoRepuesto)
      Me.Panel2.Controls.Add(Me.txtResponsable)
      Me.Panel2.Controls.Add(Me.Label4)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel2.Location = New System.Drawing.Point(0, 30)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(708, 332)
      Me.Panel2.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(5, 43)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(112, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Descripción de Parte :"
      '
      'actxaDescripcion
      '
      Me.actxaDescripcion.ACActivarAyudaAuto = False
      Me.actxaDescripcion.ACLongitudAceptada = 0
      Me.actxaDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.actxaDescripcion.Location = New System.Drawing.Point(123, 39)
      Me.actxaDescripcion.MaxLength = 32767
      Me.actxaDescripcion.Name = "actxaDescripcion"
      Me.actxaDescripcion.Size = New System.Drawing.Size(288, 20)
      Me.actxaDescripcion.TabIndex = 4
      Me.actxaDescripcion.Tag = "EVO"
      '
      'btnNuevo
      '
      Me.btnNuevo.Enabled = False
      Me.btnNuevo.Image = Global.ACPTransportes.My.Resources.Resources.Nuevo_16x16
      Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnNuevo.Location = New System.Drawing.Point(386, 10)
      Me.btnNuevo.Name = "btnNuevo"
      Me.btnNuevo.Size = New System.Drawing.Size(25, 22)
      Me.btnNuevo.TabIndex = 2
      Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnNuevo.UseVisualStyleBackColor = True
      '
      'actxaCodigo
      '
      Me.actxaCodigo.ACActivarAyudaAuto = False
      Me.actxaCodigo.ACLongitudAceptada = 0
      Me.actxaCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.actxaCodigo.Location = New System.Drawing.Point(123, 13)
      Me.actxaCodigo.MaxLength = 32767
      Me.actxaCodigo.Name = "actxaCodigo"
      Me.actxaCodigo.Size = New System.Drawing.Size(158, 20)
      Me.actxaCodigo.TabIndex = 1
      Me.actxaCodigo.Tag = "EVO"
      '
      'Label38
      '
      Me.Label38.AutoSize = True
      Me.Label38.Location = New System.Drawing.Point(24, 17)
      Me.Label38.Name = "Label38"
      Me.Label38.Size = New System.Drawing.Size(93, 13)
      Me.Label38.TabIndex = 0
      Me.Label38.Text = "Numero de Parte :"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.PictureBox1)
      Me.GroupBox1.Controls.Add(Me.Panel1)
      Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
      Me.GroupBox1.Location = New System.Drawing.Point(426, 0)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(282, 332)
      Me.GroupBox1.TabIndex = 11
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Imagen"
      '
      'PictureBox1
      '
      Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.PictureBox1.Location = New System.Drawing.Point(3, 47)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(276, 282)
      Me.PictureBox1.TabIndex = 16
      Me.PictureBox1.TabStop = False
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.btnDirecctorio)
      Me.Panel1.Controls.Add(Me.txtPathGenerador)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(3, 16)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(276, 31)
      Me.Panel1.TabIndex = 0
      '
      'btnDirecctorio
      '
      Me.btnDirecctorio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnDirecctorio.Enabled = False
      Me.btnDirecctorio.Image = Global.ACPTransportes.My.Resources.Resources.folderadd_16x16
      Me.btnDirecctorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnDirecctorio.Location = New System.Drawing.Point(235, 5)
      Me.btnDirecctorio.Name = "btnDirecctorio"
      Me.btnDirecctorio.Size = New System.Drawing.Size(25, 22)
      Me.btnDirecctorio.TabIndex = 1
      Me.btnDirecctorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnDirecctorio.UseVisualStyleBackColor = True
      '
      'txtPathGenerador
      '
      Me.txtPathGenerador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPathGenerador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtPathGenerador.Enabled = False
      Me.txtPathGenerador.Location = New System.Drawing.Point(15, 5)
      Me.txtPathGenerador.Name = "txtPathGenerador"
      Me.txtPathGenerador.Size = New System.Drawing.Size(245, 20)
      Me.txtPathGenerador.TabIndex = 0
      Me.txtPathGenerador.Tag = "C"
      '
      'txtProcedimiento
      '
      Me.txtProcedimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtProcedimiento.Location = New System.Drawing.Point(12, 134)
      Me.txtProcedimiento.MaxLength = 200
      Me.txtProcedimiento.Multiline = True
      Me.txtProcedimiento.Name = "txtProcedimiento"
      Me.txtProcedimiento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtProcedimiento.Size = New System.Drawing.Size(399, 38)
      Me.txtProcedimiento.TabIndex = 12
      Me.txtProcedimiento.Tag = "EVO"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(19, 69)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(98, 13)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "Tipo de Repuesto :"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(16, 118)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(134, 13)
      Me.Label5.TabIndex = 11
      Me.Label5.Text = "Procedimiento de Trabajo :"
      Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbTipoRepuesto
      '
      Me.cmbTipoRepuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoRepuesto.FormattingEnabled = True
      Me.cmbTipoRepuesto.Location = New System.Drawing.Point(123, 65)
      Me.cmbTipoRepuesto.Name = "cmbTipoRepuesto"
      Me.cmbTipoRepuesto.Size = New System.Drawing.Size(288, 21)
      Me.cmbTipoRepuesto.TabIndex = 6
      Me.cmbTipoRepuesto.Tag = "ECO"
      '
      'txtResponsable
      '
      Me.txtResponsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtResponsable.Location = New System.Drawing.Point(123, 92)
      Me.txtResponsable.MaxLength = 50
      Me.txtResponsable.Name = "txtResponsable"
      Me.txtResponsable.Size = New System.Drawing.Size(288, 20)
      Me.txtResponsable.TabIndex = 10
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(16, 27)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(55, 13)
      Me.Label3.TabIndex = 7
      Me.Label3.Text = "Cantidad :"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(42, 96)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(75, 13)
      Me.Label4.TabIndex = 9
      Me.Label4.Text = "Responsable :"
      '
      'txtCantidad
      '
      Me.txtCantidad.ACEnteros = 9
      Me.txtCantidad.ACNegativo = True
      Me.txtCantidad.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtCantidad.Location = New System.Drawing.Point(77, 23)
      Me.txtCantidad.MaxLength = 12
      Me.txtCantidad.Name = "txtCantidad"
      Me.txtCantidad.Size = New System.Drawing.Size(76, 20)
      Me.txtCantidad.TabIndex = 8
      Me.txtCantidad.Tag = "EV"
      Me.txtCantidad.Text = "0.00"
      Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'AcPanelCaption1
      '
      Me.AcPanelCaption1.ACCaption = "Registro de Repuestos"
      Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption1.Name = "AcPanelCaption1"
      Me.AcPanelCaption1.Size = New System.Drawing.Size(708, 30)
      Me.AcPanelCaption1.TabIndex = 1
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAceptar, Me.ToolStripSeparator1, Me.tsbtnCancelar, Me.tsbtnSalir})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 362)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(708, 25)
      Me.ToolStrip1.TabIndex = 2
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'tsbtnAceptar
      '
      Me.tsbtnAceptar.Image = Global.ACPTransportes.My.Resources.Resources.ok
      Me.tsbtnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnAceptar.Name = "tsbtnAceptar"
      Me.tsbtnAceptar.Size = New System.Drawing.Size(68, 22)
      Me.tsbtnAceptar.Text = "Aceptar"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'tsbtnCancelar
      '
      Me.tsbtnCancelar.Image = Global.ACPTransportes.My.Resources.Resources.ACCancelar_16x16
      Me.tsbtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnCancelar.Name = "tsbtnCancelar"
      Me.tsbtnCancelar.Size = New System.Drawing.Size(73, 22)
      Me.tsbtnCancelar.Text = "Cancelar"
      '
      'tsbtnSalir
      '
      Me.tsbtnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.tsbtnSalir.Image = Global.ACPTransportes.My.Resources.Resources.ACExit_16x16
      Me.tsbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtnSalir.Name = "tsbtnSalir"
      Me.tsbtnSalir.Size = New System.Drawing.Size(49, 22)
      Me.tsbtnSalir.Text = "Salir"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(16, 53)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(59, 13)
      Me.Label6.TabIndex = 13
      Me.Label6.Text = "Repuesto :"
      '
      'cmbRepuesto
      '
      Me.cmbRepuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRepuesto.FormattingEnabled = True
      Me.cmbRepuesto.Location = New System.Drawing.Point(81, 49)
      Me.cmbRepuesto.Name = "cmbRepuesto"
      Me.cmbRepuesto.Size = New System.Drawing.Size(298, 21)
      Me.cmbRepuesto.TabIndex = 14
      Me.cmbRepuesto.Tag = "ECO"
      '
      'txtProvDescripcion
      '
      Me.txtProvDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtProvDescripcion.Location = New System.Drawing.Point(170, 76)
      Me.txtProvDescripcion.MaxLength = 50
      Me.txtProvDescripcion.Name = "txtProvDescripcion"
      Me.txtProvDescripcion.Size = New System.Drawing.Size(209, 20)
      Me.txtProvDescripcion.TabIndex = 16
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(16, 80)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(62, 13)
      Me.Label7.TabIndex = 15
      Me.Label7.Text = "Proveedor :"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(16, 106)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(84, 13)
      Me.Label8.TabIndex = 17
      Me.Label8.Text = "Importe : (+ IGV)"
      '
      'actxnTotal
      '
      Me.actxnTotal.ACEnteros = 9
      Me.actxnTotal.ACNegativo = True
      Me.actxnTotal.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.actxnTotal.Location = New System.Drawing.Point(119, 102)
      Me.actxnTotal.MaxLength = 12
      Me.actxnTotal.Name = "actxnTotal"
      Me.actxnTotal.Size = New System.Drawing.Size(76, 20)
      Me.actxnTotal.TabIndex = 18
      Me.actxnTotal.Tag = "EV"
      Me.actxnTotal.Text = "0.00"
      Me.actxnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'grpDocumento
      '
      Me.grpDocumento.Controls.Add(Me.txtProvCodigo)
      Me.grpDocumento.Controls.Add(Me.Label8)
      Me.grpDocumento.Controls.Add(Me.Label3)
      Me.grpDocumento.Controls.Add(Me.actxnTotal)
      Me.grpDocumento.Controls.Add(Me.txtCantidad)
      Me.grpDocumento.Controls.Add(Me.txtProvDescripcion)
      Me.grpDocumento.Controls.Add(Me.Label6)
      Me.grpDocumento.Controls.Add(Me.Label7)
      Me.grpDocumento.Controls.Add(Me.cmbRepuesto)
      Me.grpDocumento.Location = New System.Drawing.Point(12, 178)
      Me.grpDocumento.Name = "grpDocumento"
      Me.grpDocumento.Size = New System.Drawing.Size(399, 135)
      Me.grpDocumento.TabIndex = 17
      Me.grpDocumento.TabStop = False
      Me.grpDocumento.Text = "Documento"
      '
      'txtProvCodigo
      '
      Me.txtProvCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtProvCodigo.Location = New System.Drawing.Point(84, 76)
      Me.txtProvCodigo.MaxLength = 50
      Me.txtProvCodigo.Name = "txtProvCodigo"
      Me.txtProvCodigo.Size = New System.Drawing.Size(80, 20)
      Me.txtProvCodigo.TabIndex = 19
      '
      'MPartesMant
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(708, 387)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Controls.Add(Me.AcPanelCaption1)
      Me.Name = "MPartesMant"
      Me.Text = "Registro de Repuestos"
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.grpDocumento.ResumeLayout(False)
      Me.grpDocumento.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents Label38 As System.Windows.Forms.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Private WithEvents btnDirecctorio As System.Windows.Forms.Button
   Private WithEvents txtPathGenerador As System.Windows.Forms.TextBox
   Friend WithEvents txtProcedimiento As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoRepuesto As System.Windows.Forms.ComboBox
   Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtCantidad As ACControles.ACTextBoxNumerico
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents actxaCodigo As ACControles.ACTextBoxAyuda
   Private WithEvents btnNuevo As System.Windows.Forms.Button
   Friend WithEvents tsbtnAceptar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbtnCancelar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbtnSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents actxaDescripcion As ACControles.ACTextBoxAyuda
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents grpDocumento As System.Windows.Forms.GroupBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents actxnTotal As ACControles.ACTextBoxNumerico
   Friend WithEvents txtProvDescripcion As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cmbRepuesto As System.Windows.Forms.ComboBox
   Friend WithEvents txtProvCodigo As System.Windows.Forms.TextBox
End Class
