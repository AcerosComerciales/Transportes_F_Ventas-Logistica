<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RCPendientes
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
      Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.btnProcesar = New System.Windows.Forms.Button()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
      Me.CheckBox1 = New System.Windows.Forms.CheckBox()
      Me.SuspendLayout()
      '
      'AcPanelCaption1
      '
      Me.AcPanelCaption1.ACCaption = "Reporte de Cuadre de Pendientes"
      Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption1.Name = "AcPanelCaption1"
      Me.AcPanelCaption1.Size = New System.Drawing.Size(314, 30)
      Me.AcPanelCaption1.TabIndex = 4
      '
      'Button1
      '
      Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Button1.Image = Global.ACPTransportes.My.Resources.Resources.Exit_32x32
      Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.Button1.Location = New System.Drawing.Point(166, 75)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(120, 41)
      Me.Button1.TabIndex = 6
      Me.Button1.Text = "Salir"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'btnProcesar
      '
      Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnProcesar.Image = Global.ACPTransportes.My.Resources.Resources.CheckProcess_32x32
      Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnProcesar.Location = New System.Drawing.Point(28, 75)
      Me.btnProcesar.Name = "btnProcesar"
      Me.btnProcesar.Size = New System.Drawing.Size(120, 41)
      Me.btnProcesar.TabIndex = 5
      Me.btnProcesar.Text = "Procesar"
      Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnProcesar.UseVisualStyleBackColor = True
      '
      'dtpFecha
      '
      Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(122, 37)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(139, 30)
      Me.dtpFecha.TabIndex = 7
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(54, 42)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(62, 20)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "Fecha :"
      '
      'DateTimePicker1
      '
      Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.DateTimePicker1.Location = New System.Drawing.Point(122, 37)
      Me.DateTimePicker1.Name = "DateTimePicker1"
      Me.DateTimePicker1.Size = New System.Drawing.Size(139, 30)
      Me.DateTimePicker1.TabIndex = 7
      '
      'CheckBox1
      '
      Me.CheckBox1.AutoSize = True
      Me.CheckBox1.Location = New System.Drawing.Point(35, 122)
      Me.CheckBox1.Name = "CheckBox1"
      Me.CheckBox1.Size = New System.Drawing.Size(127, 17)
      Me.CheckBox1.TabIndex = 9
      Me.CheckBox1.Text = "Mostrar como Listado"
      Me.CheckBox1.UseVisualStyleBackColor = True
      '
      'RCPendientes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(314, 150)
      Me.Controls.Add(Me.CheckBox1)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.AcPanelCaption1)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.btnProcesar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.Name = "RCPendientes"
      Me.Text = "Reporte de Cuadre de Pendientes"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents btnProcesar As System.Windows.Forms.Button
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
