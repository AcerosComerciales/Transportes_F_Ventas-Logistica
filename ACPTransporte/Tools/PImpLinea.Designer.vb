<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PImpLinea
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
      Me.txtLinea = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.btnImprimir = New System.Windows.Forms.Button()
      Me.btnSalir = New System.Windows.Forms.Button()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtFilas = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtColumnas = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtInternlineado = New System.Windows.Forms.TextBox()
      Me.acpnlTitulo = New ACControles.ACPanelCaption()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cmbImpresora = New System.Windows.Forms.ComboBox()
      Me.ComboBox1 = New System.Windows.Forms.ComboBox()
      Me.SuspendLayout()
      '
      'txtLinea
      '
      Me.txtLinea.Location = New System.Drawing.Point(154, 34)
      Me.txtLinea.Name = "txtLinea"
      Me.txtLinea.Size = New System.Drawing.Size(404, 20)
      Me.txtLinea.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(109, 38)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(39, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Linea :"
      '
      'btnImprimir
      '
      Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnImprimir.Image = Global.ACPTransportes.My.Resources.Resources.ACImprimirRed_32x32
      Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnImprimir.Location = New System.Drawing.Point(308, 69)
      Me.btnImprimir.Name = "btnImprimir"
      Me.btnImprimir.Size = New System.Drawing.Size(125, 49)
      Me.btnImprimir.TabIndex = 8
      Me.btnImprimir.Text = "Imprimir"
      Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnImprimir.UseVisualStyleBackColor = True
      '
      'btnSalir
      '
      Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnSalir.Image = Global.ACPTransportes.My.Resources.Resources.ACExit_32x32
      Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnSalir.Location = New System.Drawing.Point(464, 69)
      Me.btnSalir.Name = "btnSalir"
      Me.btnSalir.Size = New System.Drawing.Size(94, 49)
      Me.btnSalir.TabIndex = 9
      Me.btnSalir.Text = "Salir"
      Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnSalir.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(114, 64)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(34, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Filas :"
      '
      'txtFilas
      '
      Me.txtFilas.Location = New System.Drawing.Point(154, 60)
      Me.txtFilas.Name = "txtFilas"
      Me.txtFilas.Size = New System.Drawing.Size(100, 20)
      Me.txtFilas.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(89, 90)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(59, 13)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Columnas :"
      '
      'txtColumnas
      '
      Me.txtColumnas.Location = New System.Drawing.Point(154, 86)
      Me.txtColumnas.Name = "txtColumnas"
      Me.txtColumnas.Size = New System.Drawing.Size(100, 20)
      Me.txtColumnas.TabIndex = 5
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(54, 116)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(94, 13)
      Me.Label4.TabIndex = 6
      Me.Label4.Text = "Interlineado (6/8) :"
      '
      'txtInternlineado
      '
      Me.txtInternlineado.Location = New System.Drawing.Point(154, 112)
      Me.txtInternlineado.Name = "txtInternlineado"
      Me.txtInternlineado.Size = New System.Drawing.Size(100, 20)
      Me.txtInternlineado.TabIndex = 7
      Me.txtInternlineado.Text = "6"
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Imprimir Linea"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(570, 29)
      Me.acpnlTitulo.TabIndex = 10
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(54, 142)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(94, 13)
      Me.Label5.TabIndex = 11
      Me.Label5.Text = "Interlineado (6/8) :"
      '
      'cmbImpresora
      '
      Me.cmbImpresora.FormattingEnabled = True
      Me.cmbImpresora.Location = New System.Drawing.Point(154, 138)
      Me.cmbImpresora.Name = "cmbImpresora"
      Me.cmbImpresora.Size = New System.Drawing.Size(404, 21)
      Me.cmbImpresora.TabIndex = 12
      '
      'ComboBox1
      '
      Me.ComboBox1.FormattingEnabled = True
      Me.ComboBox1.Location = New System.Drawing.Point(154, 138)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(404, 21)
      Me.ComboBox1.TabIndex = 12
      '
      'PImpLinea
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(570, 167)
      Me.Controls.Add(Me.cmbImpresora)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtInternlineado)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtColumnas)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtFilas)
      Me.Controls.Add(Me.btnSalir)
      Me.Controls.Add(Me.btnImprimir)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtLinea)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "PImpLinea"
      Me.Text = "Imprimir Linea"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtLinea As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents btnImprimir As System.Windows.Forms.Button
   Friend WithEvents btnSalir As System.Windows.Forms.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtFilas As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtColumnas As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtInternlineado As System.Windows.Forms.TextBox
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cmbImpresora As System.Windows.Forms.ComboBox
   Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
