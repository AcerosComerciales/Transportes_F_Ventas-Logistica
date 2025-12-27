<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PPendientesViaje
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
      Me.acpnlTitulo = New ACControles.ACPanelCaption()
      Me.actool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
      Me.cmbTipoGasto = New System.Windows.Forms.ComboBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.actxnNumero = New ACControles.ACTextBoxNumerico()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtGlosa = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.actxnMonto = New ACControles.ACTextBoxNumerico()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmbTipoTransaccion = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtSerie = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      '
      'acpnlTitulo
      '
      Me.acpnlTitulo.ACCaption = "Gastos de Viaje : {0}"
      Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
      Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
      Me.acpnlTitulo.Name = "acpnlTitulo"
      Me.acpnlTitulo.Size = New System.Drawing.Size(595, 30)
      Me.acpnlTitulo.TabIndex = 17
      '
      'actool
      '
      Me.actool.ACBtnAnularEnabled = False
      Me.actool.ACBtnAnularVisible = False
      Me.actool.ACBtnBuscarEnabled = False
      Me.actool.ACBtnBuscarVisible = False
      Me.actool.ACBtnCancelarEnabled = False
      Me.actool.ACBtnCancelarVisible = False
      Me.actool.ACBtnEliminarEnabled = False
      Me.actool.ACBtnEliminarVisible = False
      Me.actool.ACBtnGrabarEnabled = False
      Me.actool.ACBtnGrabarVisible = False
      Me.actool.ACBtnImprimirEnabled = False
      Me.actool.ACBtnImprimirVisible = False
      Me.actool.ACBtnNuevoEnabled = False
      Me.actool.ACBtnNuevoVisible = False
      Me.actool.ACBtnRehusarEnabled = False
      Me.actool.ACBtnRehusarVisible = False
      Me.actool.ACBtnReporteEnabled = False
      Me.actool.ACBtnReporteVisible = False
      Me.actool.ACBtnSalirText = "&Salir"
      Me.actool.ACBtnVolverEnabled = False
      Me.actool.ACBtnVolverVisible = False
      Me.actool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolGrabar
      Me.actool.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.actool.Font = New System.Drawing.Font("Tahoma", 9.5!)
      Me.actool.ImageScalingSize = New System.Drawing.Size(32, 32)
      Me.actool.Location = New System.Drawing.Point(0, 222)
      Me.actool.Name = "actool"
      Me.actool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.actool.Size = New System.Drawing.Size(595, 56)
      Me.actool.TabIndex = 16
      Me.actool.Text = "AcToolBarMantHorizontalNew1"
      '
      'cmbTipoGasto
      '
      Me.cmbTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoGasto.FormattingEnabled = True
      Me.cmbTipoGasto.Location = New System.Drawing.Point(110, 40)
      Me.cmbTipoGasto.Name = "cmbTipoGasto"
      Me.cmbTipoGasto.Size = New System.Drawing.Size(280, 21)
      Me.cmbTipoGasto.TabIndex = 1
      Me.cmbTipoGasto.Tag = "ECO"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(39, 45)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(65, 13)
      Me.Label14.TabIndex = 0
      Me.Label14.Text = "Tipo Gasto :"
      '
      'actxnNumero
      '
      Me.actxnNumero.ACEnteros = 8
      Me.actxnNumero.ACEstandar = ACControles.ACEstandaresFormato.ACNinguno
      Me.actxnNumero.ACFormato = "#######0"
      Me.actxnNumero.ACNegativo = True
      Me.actxnNumero.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
      Me.actxnNumero.Location = New System.Drawing.Point(212, 94)
      Me.actxnNumero.MaxLength = 7
      Me.actxnNumero.Name = "actxnNumero"
      Me.actxnNumero.ReadOnly = True
      Me.actxnNumero.Size = New System.Drawing.Size(127, 20)
      Me.actxnNumero.TabIndex = 7
      Me.actxnNumero.Tag = "EVO"
      Me.actxnNumero.Text = "0"
      Me.actxnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(155, 98)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(50, 13)
      Me.Label4.TabIndex = 6
      Me.Label4.Text = "Numero :"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(67, 98)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(37, 13)
      Me.Label6.TabIndex = 4
      Me.Label6.Text = "Serie :"
      '
      'txtGlosa
      '
      Me.txtGlosa.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtGlosa.Location = New System.Drawing.Point(110, 120)
      Me.txtGlosa.MaxLength = 200
      Me.txtGlosa.Multiline = True
      Me.txtGlosa.Name = "txtGlosa"
      Me.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtGlosa.Size = New System.Drawing.Size(475, 40)
      Me.txtGlosa.TabIndex = 9
      Me.txtGlosa.Tag = "EVO"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(64, 123)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(40, 13)
      Me.Label3.TabIndex = 8
      Me.Label3.Text = "Glosa :"
      '
      'actxnMonto
      '
      Me.actxnMonto.ACEnteros = 9
      Me.actxnMonto.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
      Me.actxnMonto.ACFormato = "########0.00"
      Me.actxnMonto.ACNegativo = True
      Me.actxnMonto.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
      Me.actxnMonto.Location = New System.Drawing.Point(110, 166)
      Me.actxnMonto.MaxLength = 12
      Me.actxnMonto.Name = "actxnMonto"
      Me.actxnMonto.Size = New System.Drawing.Size(95, 20)
      Me.actxnMonto.TabIndex = 11
      Me.actxnMonto.Tag = "N"
      Me.actxnMonto.Text = "0.00"
      Me.actxnMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(61, 170)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(43, 13)
      Me.Label7.TabIndex = 10
      Me.Label7.Text = "Monto :"
      '
      'cmbTipoMoneda
      '
      Me.cmbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoMoneda.FormattingEnabled = True
      Me.cmbTipoMoneda.Location = New System.Drawing.Point(307, 166)
      Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
      Me.cmbTipoMoneda.Size = New System.Drawing.Size(277, 21)
      Me.cmbTipoMoneda.TabIndex = 13
      Me.cmbTipoMoneda.Tag = "EO"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(226, 170)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(76, 13)
      Me.Label5.TabIndex = 12
      Me.Label5.Text = "Tipo Moneda :"
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(110, 192)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
      Me.dtpFecha.TabIndex = 15
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(61, 196)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(43, 13)
      Me.Label2.TabIndex = 14
      Me.Label2.Text = "Fecha :"
      '
      'cmbTipoTransaccion
      '
      Me.cmbTipoTransaccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoTransaccion.FormattingEnabled = True
      Me.cmbTipoTransaccion.Location = New System.Drawing.Point(110, 66)
      Me.cmbTipoTransaccion.Name = "cmbTipoTransaccion"
      Me.cmbTipoTransaccion.Size = New System.Drawing.Size(280, 21)
      Me.cmbTipoTransaccion.TabIndex = 3
      Me.cmbTipoTransaccion.Tag = "ECO"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(8, 71)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(96, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Tipo Transacción :"
      '
      'txtSerie
      '
      Me.txtSerie.Location = New System.Drawing.Point(110, 94)
      Me.txtSerie.Name = "txtSerie"
      Me.txtSerie.ReadOnly = True
      Me.txtSerie.Size = New System.Drawing.Size(37, 20)
      Me.txtSerie.TabIndex = 5
      Me.txtSerie.Text = "000"
      Me.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'PPendientesViaje
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightSteelBlue
      Me.ClientSize = New System.Drawing.Size(595, 278)
      Me.Controls.Add(Me.txtSerie)
      Me.Controls.Add(Me.cmbTipoTransaccion)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtGlosa)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.actxnMonto)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.cmbTipoMoneda)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.actxnNumero)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.cmbTipoGasto)
      Me.Controls.Add(Me.Label14)
      Me.Controls.Add(Me.actool)
      Me.Controls.Add(Me.acpnlTitulo)
      Me.Name = "PPendientesViaje"
      Me.Text = "Gastos de Viaje"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
   Friend WithEvents actool As ACControles.ACToolBarMantHorizontalNew
   Friend WithEvents cmbTipoGasto As System.Windows.Forms.ComboBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents actxnNumero As ACControles.ACTextBoxNumerico
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents actxnMonto As ACControles.ACTextBoxNumerico
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoTransaccion As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtSerie As System.Windows.Forms.TextBox
End Class
