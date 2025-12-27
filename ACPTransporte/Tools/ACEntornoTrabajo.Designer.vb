<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ACEntornoTrabajo
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ACEntornoTrabajo))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbSucursales = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtUsuario = New System.Windows.Forms.TextBox()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.cmbZona = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cmbPuntoVenta = New System.Windows.Forms.ComboBox()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(14, 88)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(54, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Sucursal :"
      '
      'cmbSucursales
      '
      Me.cmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursales.FormattingEnabled = True
      Me.cmbSucursales.Location = New System.Drawing.Point(14, 104)
      Me.cmbSucursales.Name = "cmbSucursales"
      Me.cmbSucursales.Size = New System.Drawing.Size(210, 21)
      Me.cmbSucursales.TabIndex = 5
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(14, 9)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(43, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Fecha :"
      '
      'dtpFecha
      '
      Me.dtpFecha.Location = New System.Drawing.Point(14, 25)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(210, 20)
      Me.dtpFecha.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(14, 168)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(49, 13)
      Me.Label3.TabIndex = 6
      Me.Label3.Text = "Usuario :"
      '
      'txtUsuario
      '
      Me.txtUsuario.Location = New System.Drawing.Point(14, 184)
      Me.txtUsuario.Name = "txtUsuario"
      Me.txtUsuario.ReadOnly = True
      Me.txtUsuario.Size = New System.Drawing.Size(210, 20)
      Me.txtUsuario.TabIndex = 7
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Image = Global.ACPTransportes.My.Resources.Resources.shutdown
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(144, 216)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 26)
      Me.btnCancelar.TabIndex = 1
      Me.btnCancelar.Text = "Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = False
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.btnAceptar.Image = Global.ACPTransportes.My.Resources.Resources.ok
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(58, 216)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 26)
      Me.btnAceptar.TabIndex = 0
      Me.btnAceptar.Text = "Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = False
      '
      'cmbZona
      '
      Me.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbZona.FormattingEnabled = True
      Me.cmbZona.Location = New System.Drawing.Point(14, 64)
      Me.cmbZona.Name = "cmbZona"
      Me.cmbZona.Size = New System.Drawing.Size(210, 21)
      Me.cmbZona.TabIndex = 11
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(14, 48)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(38, 13)
      Me.Label4.TabIndex = 10
      Me.Label4.Text = "Zona :"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(14, 128)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(87, 13)
      Me.Label5.TabIndex = 14
      Me.Label5.Text = "Punto de Venta :"
      '
      'cmbPuntoVenta
      '
      Me.cmbPuntoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPuntoVenta.FormattingEnabled = True
      Me.cmbPuntoVenta.Location = New System.Drawing.Point(14, 144)
      Me.cmbPuntoVenta.Name = "cmbPuntoVenta"
      Me.cmbPuntoVenta.Size = New System.Drawing.Size(210, 21)
      Me.cmbPuntoVenta.TabIndex = 15
      '
      'ACEntornoTrabajo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(248, 253)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.cmbPuntoVenta)
      Me.Controls.Add(Me.cmbZona)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.txtUsuario)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cmbSucursales)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ACEntornoTrabajo"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Entorno de Trabajo"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmbSucursales As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents cmbZona As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cmbPuntoVenta As System.Windows.Forms.ComboBox
End Class
