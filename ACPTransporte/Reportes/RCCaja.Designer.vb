<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RCCaja
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
      Me.AcFecha = New ACControles.ACFecha(Me.components)
      Me.btnProcesar = New System.Windows.Forms.Button()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
      Me.SuspendLayout()
      '
      'AcFecha
      '
      Me.AcFecha.ACFecha_A = New Date(2012, 7, 9, 12, 43, 16, 227)
      Me.AcFecha.ACFecha_De = New Date(2012, 7, 9, 12, 43, 24, 452)
      Me.AcFecha.ACFechaObligatoria = True
      Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Vertical
      Me.AcFecha.ACHoyChecked = False
      Me.AcFecha.ACIncrementoFecha_A = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.AcFecha.ACIncrementoFecha_De = ACControles.ACFecha.ACTipoIncremento.Dia
      Me.AcFecha.ACIntervalos = ACControles.ACFecha.ACIntervalo.Ninguno
      Me.AcFecha.Location = New System.Drawing.Point(12, 46)
      Me.AcFecha.MaximumSize = New System.Drawing.Size(300, 94)
      Me.AcFecha.MinimumSize = New System.Drawing.Size(176, 94)
      Me.AcFecha.Name = "AcFecha"
      Me.AcFecha.Size = New System.Drawing.Size(176, 94)
      Me.AcFecha.TabIndex = 1
      Me.AcFecha.TabStop = False
      '
      'btnProcesar
      '
      Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnProcesar.Image = Global.ACPTransportes.My.Resources.Resources.CheckProcess_32x32
      Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnProcesar.Location = New System.Drawing.Point(208, 46)
      Me.btnProcesar.Name = "btnProcesar"
      Me.btnProcesar.Size = New System.Drawing.Size(120, 41)
      Me.btnProcesar.TabIndex = 2
      Me.btnProcesar.Text = "Procesar"
      Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnProcesar.UseVisualStyleBackColor = True
      '
      'Button1
      '
      Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Button1.Image = Global.ACPTransportes.My.Resources.Resources.Exit_32x32
      Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.Button1.Location = New System.Drawing.Point(208, 98)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(120, 41)
      Me.Button1.TabIndex = 3
      Me.Button1.Text = "Salir"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'AcPanelCaption1
      '
      Me.AcPanelCaption1.ACCaption = "Reporte de Cuadre de Caja: "
      Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
      Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
      Me.AcPanelCaption1.Name = "AcPanelCaption1"
      Me.AcPanelCaption1.Size = New System.Drawing.Size(343, 30)
      Me.AcPanelCaption1.TabIndex = 0
      '
      'RCCaja
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(343, 153)
      Me.Controls.Add(Me.AcPanelCaption1)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.AcFecha)
      Me.Controls.Add(Me.btnProcesar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.Name = "RCCaja"
      Me.Text = "Reporte de Cuadre"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents AcFecha As ACControles.ACFecha
   Friend WithEvents btnProcesar As System.Windows.Forms.Button
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
End Class
