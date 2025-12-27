<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TPendientesCaja
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
      Me.SuspendLayout()
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Recibos"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(664, 30)
      Me.acpnlTitulo.TabIndex = 13
      '
      'TPendientesCaja
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(664, 479)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Name = "TPendientesCaja"
      Me.Text = "TPendientesCaja"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
End Class
