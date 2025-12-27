<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PCreaFactAnulado
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
      Me.acpnlTitulo = New ACControles.ACPanelCaption()
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.tsbtGuardar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbtnCancelar = New System.Windows.Forms.ToolStripButton()
      Me.tsbtnSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.grpCabCuerpo = New System.Windows.Forms.GroupBox()
      Me.actxaCliRazonSocial = New ACControles.ACTextBoxAyuda()
      Me.lblNroDocumento = New System.Windows.Forms.Label()
      Me.actxaCliRuc = New ACControles.ACTextBoxAyuda()
      Me.dtpFecFacturacion = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.grpDocumento = New System.Windows.Forms.GroupBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmbDocumento = New System.Windows.Forms.ComboBox()
      Me.actxnNumero = New ACControles.ACTextBoxNumerico()
      Me.cmbSerie = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.rbtnBlanco = New System.Windows.Forms.RadioButton()
      Me.rbtnAnulado = New System.Windows.Forms.RadioButton()
      Me.ToolStrip1.SuspendLayout()
      Me.grpCabCuerpo.SuspendLayout()
      Me.grpDocumento.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Crear Factura Anulada / En Blanco"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(627, 30)
      Me.acpnlTitulo.TabIndex = 22
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtGuardar, Me.ToolStripSeparator1, Me.tsbtnCancelar, Me.tsbtnSalir, Me.ToolStripSeparator2})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 166)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(627, 25)
      Me.ToolStrip1.TabIndex = 21
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'tsbtGuardar
      '
      Me.tsbtGuardar.Image = Global.ACPTransportes.My.Resources.Resources.guardar
      Me.tsbtGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbtGuardar.Name = "tsbtGuardar"
      Me.tsbtGuardar.Size = New System.Drawing.Size(69, 22)
      Me.tsbtGuardar.Text = "Guardar"
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
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'grpCabCuerpo
      '
      Me.grpCabCuerpo.Controls.Add(Me.actxaCliRazonSocial)
      Me.grpCabCuerpo.Controls.Add(Me.lblNroDocumento)
      Me.grpCabCuerpo.Controls.Add(Me.actxaCliRuc)
      Me.grpCabCuerpo.Location = New System.Drawing.Point(3, 72)
      Me.grpCabCuerpo.Name = "grpCabCuerpo"
      Me.grpCabCuerpo.Size = New System.Drawing.Size(594, 43)
      Me.grpCabCuerpo.TabIndex = 18
      Me.grpCabCuerpo.TabStop = False
      Me.grpCabCuerpo.Tag = "EVO"
      '
      'actxaCliRazonSocial
      '
      Me.actxaCliRazonSocial.ACActivarAyudaAuto = False
      Me.actxaCliRazonSocial.ACLongitudAceptada = 0
      Me.actxaCliRazonSocial.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaCliRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.actxaCliRazonSocial.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
      Me.actxaCliRazonSocial.Location = New System.Drawing.Point(214, 12)
      Me.actxaCliRazonSocial.MaxLength = 80
      Me.actxaCliRazonSocial.Name = "actxaCliRazonSocial"
      Me.actxaCliRazonSocial.ReadOnly = True
      Me.actxaCliRazonSocial.Size = New System.Drawing.Size(372, 24)
      Me.actxaCliRazonSocial.TabIndex = 2
      Me.actxaCliRazonSocial.Tag = "EVO"
      '
      'lblNroDocumento
      '
      Me.lblNroDocumento.AutoSize = True
      Me.lblNroDocumento.Location = New System.Drawing.Point(36, 18)
      Me.lblNroDocumento.Name = "lblNroDocumento"
      Me.lblNroDocumento.Size = New System.Drawing.Size(45, 13)
      Me.lblNroDocumento.TabIndex = 0
      Me.lblNroDocumento.Text = "Cliente :"
      '
      'actxaCliRuc
      '
      Me.actxaCliRuc.ACActivarAyudaAuto = False
      Me.actxaCliRuc.ACLongitudAceptada = 0
      Me.actxaCliRuc.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.AlfaNumerico
      Me.actxaCliRuc.Location = New System.Drawing.Point(94, 14)
      Me.actxaCliRuc.MaxLength = 14
      Me.actxaCliRuc.Name = "actxaCliRuc"
      Me.actxaCliRuc.ReadOnly = True
      Me.actxaCliRuc.Size = New System.Drawing.Size(111, 20)
      Me.actxaCliRuc.TabIndex = 1
      Me.actxaCliRuc.Tag = "EVO"
      '
      'dtpFecFacturacion
      '
      Me.dtpFecFacturacion.Enabled = False
      Me.dtpFecFacturacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecFacturacion.Location = New System.Drawing.Point(482, 128)
      Me.dtpFecFacturacion.Name = "dtpFecFacturacion"
      Me.dtpFecFacturacion.Size = New System.Drawing.Size(105, 20)
      Me.dtpFecFacturacion.TabIndex = 20
      Me.dtpFecFacturacion.Tag = "E"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(390, 132)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(82, 13)
      Me.Label1.TabIndex = 19
      Me.Label1.Text = "Fecha Emi&sion :"
      '
      'grpDocumento
      '
      Me.grpDocumento.BackColor = System.Drawing.Color.MidnightBlue
      Me.grpDocumento.Controls.Add(Me.Label3)
      Me.grpDocumento.Controls.Add(Me.cmbDocumento)
      Me.grpDocumento.Controls.Add(Me.actxnNumero)
      Me.grpDocumento.Controls.Add(Me.cmbSerie)
      Me.grpDocumento.Controls.Add(Me.Label4)
      Me.grpDocumento.Controls.Add(Me.Label5)
      Me.grpDocumento.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpDocumento.Location = New System.Drawing.Point(0, 30)
      Me.grpDocumento.Name = "grpDocumento"
      Me.grpDocumento.Size = New System.Drawing.Size(627, 40)
      Me.grpDocumento.TabIndex = 23
      Me.grpDocumento.TabStop = False
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(17, 17)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(92, 13)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Tipo Documento :"
      '
      'cmbDocumento
      '
      Me.cmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDocumento.Enabled = False
      Me.cmbDocumento.FormattingEnabled = True
      Me.cmbDocumento.Items.AddRange(New Object() {"Boleta", "Factura"})
      Me.cmbDocumento.Location = New System.Drawing.Point(122, 13)
      Me.cmbDocumento.Name = "cmbDocumento"
      Me.cmbDocumento.Size = New System.Drawing.Size(204, 21)
      Me.cmbDocumento.TabIndex = 1
      Me.cmbDocumento.Tag = "ECO"
      '
      'actxnNumero
      '
      Me.actxnNumero.ACEnteros = 8
      Me.actxnNumero.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnNumero.ACFormato = "#######0"
      Me.actxnNumero.ACNegativo = True
      Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnNumero.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
      Me.actxnNumero.Location = New System.Drawing.Point(498, 11)
      Me.actxnNumero.MaxLength = 7
      Me.actxnNumero.Name = "actxnNumero"
      Me.actxnNumero.Size = New System.Drawing.Size(100, 24)
      Me.actxnNumero.TabIndex = 5
      Me.actxnNumero.Tag = "ENO"
      Me.actxnNumero.Text = "0"
      Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbSerie
      '
      Me.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSerie.FormattingEnabled = True
      Me.cmbSerie.Location = New System.Drawing.Point(367, 13)
      Me.cmbSerie.Name = "cmbSerie"
      Me.cmbSerie.Size = New System.Drawing.Size(69, 21)
      Me.cmbSerie.TabIndex = 3
      Me.cmbSerie.Tag = "ECO"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.ForeColor = System.Drawing.Color.White
      Me.Label4.Location = New System.Drawing.Point(438, 17)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(50, 13)
      Me.Label4.TabIndex = 4
      Me.Label4.Text = "Numero :"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.ForeColor = System.Drawing.Color.White
      Me.Label5.Location = New System.Drawing.Point(326, 17)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(37, 13)
      Me.Label5.TabIndex = 2
      Me.Label5.Text = "Serie :"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.rbtnBlanco)
      Me.GroupBox1.Controls.Add(Me.rbtnAnulado)
      Me.GroupBox1.Location = New System.Drawing.Point(5, 118)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(203, 41)
      Me.GroupBox1.TabIndex = 24
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Tipo Factura"
      '
      'rbtnBlanco
      '
      Me.rbtnBlanco.AutoSize = True
      Me.rbtnBlanco.Location = New System.Drawing.Point(119, 16)
      Me.rbtnBlanco.Name = "rbtnBlanco"
      Me.rbtnBlanco.Size = New System.Drawing.Size(74, 17)
      Me.rbtnBlanco.TabIndex = 1
      Me.rbtnBlanco.Text = "En Blanco"
      Me.rbtnBlanco.UseVisualStyleBackColor = True
      '
      'rbtnAnulado
      '
      Me.rbtnAnulado.AutoSize = True
      Me.rbtnAnulado.Checked = True
      Me.rbtnAnulado.Location = New System.Drawing.Point(7, 16)
      Me.rbtnAnulado.Name = "rbtnAnulado"
      Me.rbtnAnulado.Size = New System.Drawing.Size(64, 17)
      Me.rbtnAnulado.TabIndex = 0
      Me.rbtnAnulado.TabStop = True
      Me.rbtnAnulado.Text = "Anulada"
      Me.rbtnAnulado.UseVisualStyleBackColor = True
      '
      'PCreaFactAnulado
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.ClientSize = New System.Drawing.Size(627, 191)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.grpDocumento)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Controls.Add(Me.grpCabCuerpo)
      Me.Controls.Add(Me.dtpFecFacturacion)
      Me.Controls.Add(Me.Label1)
      Me.Name = "PCreaFactAnulado"
      Me.Text = "Crear Factura Anulada / En Blanco"
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.grpCabCuerpo.ResumeLayout(False)
      Me.grpCabCuerpo.PerformLayout()
      Me.grpDocumento.ResumeLayout(False)
      Me.grpDocumento.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbtGuardar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbtnCancelar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbtnSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grpCabCuerpo As System.Windows.Forms.GroupBox
   Friend WithEvents actxaCliRazonSocial As ACControles.ACTextBoxAyuda
   Friend WithEvents lblNroDocumento As System.Windows.Forms.Label
   Friend WithEvents actxaCliRuc As ACControles.ACTextBoxAyuda
   Friend WithEvents dtpFecFacturacion As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents grpDocumento As System.Windows.Forms.GroupBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmbDocumento As System.Windows.Forms.ComboBox
   Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
   Friend WithEvents cmbSerie As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents rbtnBlanco As System.Windows.Forms.RadioButton
   Friend WithEvents rbtnAnulado As System.Windows.Forms.RadioButton
End Class
