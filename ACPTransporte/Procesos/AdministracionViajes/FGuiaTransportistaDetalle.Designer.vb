<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FGuiaTransportistaDetalle
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.AcTextBoxNumerico2 = New ACControles.ACTextBoxNumerico
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.AcTextBoxNumerico1 = New ACControles.ACTextBoxNumerico
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.acTool = New ACControles.ACToolBarMantHorizontal
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.AcTextBoxNumerico2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ComboBox2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.AcTextBoxNumerico1)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(596, 150)
        Me.Panel1.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Código"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(112, 6)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(201, 20)
        Me.TextBox2.TabIndex = 35
        '
        'AcTextBoxNumerico2
        '
        Me.AcTextBoxNumerico2.ACDecimales = 2
        Me.AcTextBoxNumerico2.ACEnteros = 8
        Me.AcTextBoxNumerico2.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
        Me.AcTextBoxNumerico2.ACFormato = "#######0.00"
        Me.AcTextBoxNumerico2.ACNegativo = True
        Me.AcTextBoxNumerico2.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.AcTextBoxNumerico2.Location = New System.Drawing.Point(112, 111)
        Me.AcTextBoxNumerico2.MaxLength = 12
        Me.AcTextBoxNumerico2.Name = "AcTextBoxNumerico2"
        Me.AcTextBoxNumerico2.Size = New System.Drawing.Size(201, 20)
        Me.AcTextBoxNumerico2.TabIndex = 34
        Me.AcTextBoxNumerico2.Text = "0"
        Me.AcTextBoxNumerico2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Cantidad"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(112, 58)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(201, 21)
        Me.ComboBox2.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Unidad"
        '
        'AcTextBoxNumerico1
        '
        Me.AcTextBoxNumerico1.ACDecimales = 2
        Me.AcTextBoxNumerico1.ACEnteros = 8
        Me.AcTextBoxNumerico1.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
        Me.AcTextBoxNumerico1.ACFormato = "#######0.00"
        Me.AcTextBoxNumerico1.ACNegativo = True
        Me.AcTextBoxNumerico1.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.AcTextBoxNumerico1.Location = New System.Drawing.Point(112, 85)
        Me.AcTextBoxNumerico1.MaxLength = 12
        Me.AcTextBoxNumerico1.Name = "AcTextBoxNumerico1"
        Me.AcTextBoxNumerico1.Size = New System.Drawing.Size(201, 20)
        Me.AcTextBoxNumerico1.TabIndex = 28
        Me.AcTextBoxNumerico1.Text = "0"
        Me.AcTextBoxNumerico1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(112, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(467, 20)
        Me.TextBox1.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Peso"
        '
        'acTool
        '
        Me.acTool.ACTipoBoton = ACControles.ACToolBarMantHorizontal.TipoBoton.Eliminar
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontal.tipoToolBar.ToolNuevoGrabarEliminar
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Location = New System.Drawing.Point(0, 150)
        Me.acTool.MinimumSize = New System.Drawing.Size(495, 60)
        Me.acTool.Name = "acTool"
        Me.acTool.Size = New System.Drawing.Size(596, 60)
        Me.acTool.TabIndex = 23
        '
        'FGuiaTransportistaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 210)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.acTool)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FGuiaTransportistaDetalle"
        Me.Text = "FGuiaTransportistaDetalle"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents AcTextBoxNumerico2 As ACControles.ACTextBoxNumerico
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AcTextBoxNumerico1 As ACControles.ACTextBoxNumerico
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents acTool As ACControles.ACToolBarMantHorizontal
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
End Class
