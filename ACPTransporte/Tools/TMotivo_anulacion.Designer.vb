<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TMotivo_anulacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TMotivo_anulacion))
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.acbtnGrabar = New ACControles.ACToolStripButton(Me.components)
        Me.acTool.SuspendLayout()
        Me.SuspendLayout()
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Motivo de Anulación de Documento : {0}"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(562, 30)
        Me.acpnlTitulo.TabIndex = 3
        '
        'txtMotivo
        '
        Me.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivo.Location = New System.Drawing.Point(0, 30)
        Me.txtMotivo.MaxLength = 150
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMotivo.Size = New System.Drawing.Size(562, 159)
        Me.txtMotivo.TabIndex = 4
        '
        'acTool
        '
        Me.acTool.ACBtnAnularEnabled = False
        Me.acTool.ACBtnAnularVisible = False
        Me.acTool.ACBtnBuscarEnabled = False
        Me.acTool.ACBtnBuscarVisible = False
        Me.acTool.ACBtnCancelarEnabled = False
        Me.acTool.ACBtnCancelarVisible = False
        Me.acTool.ACBtnEliminarEnabled = False
        Me.acTool.ACBtnEliminarVisible = False
        Me.acTool.ACBtnGrabarEnabled = False
        Me.acTool.ACBtnGrabarVisible = False
        Me.acTool.ACBtnImprimirEnabled = False
        Me.acTool.ACBtnImprimirVisible = False
        Me.acTool.ACBtnModificarEnabled = False
        Me.acTool.ACBtnModificarVisible = False
        Me.acTool.ACBtnNuevoEnabled = False
        Me.acTool.ACBtnNuevoVisible = False
        Me.acTool.ACBtnRehusarEnabled = False
        Me.acTool.ACBtnRehusarVisible = False
        Me.acTool.ACBtnReporteEnabled = False
        Me.acTool.ACBtnReporteVisible = False
        Me.acTool.ACBtnSalirText = "&Salir"
        Me.acTool.ACBtnVolverEnabled = False
        Me.acTool.ACBtnVolverVisible = False
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolSalir
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.acbtnGrabar})
        Me.acTool.Location = New System.Drawing.Point(0, 189)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(562, 56)
        Me.acTool.TabIndex = 5
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'acbtnGrabar
        '
        Me.acbtnGrabar.AutoSize = False
        Me.acbtnGrabar.Image = CType(resources.GetObject("acbtnGrabar.Image"), System.Drawing.Image)
        Me.acbtnGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.acbtnGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.acbtnGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.acbtnGrabar.Name = "tsbBoton"
        Me.acbtnGrabar.Size = New System.Drawing.Size(84, 53)
        Me.acbtnGrabar.Text = "&Grabar"
        Me.acbtnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.acbtnGrabar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.acbtnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TMotivo_anulacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 245)
        Me.Controls.Add(Me.txtMotivo)
        Me.Controls.Add(Me.acTool)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Name = "TMotivo_anulacion"
        Me.Text = "TMotivo_anulacion"
        Me.acTool.ResumeLayout(False)
        Me.acTool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
    Friend WithEvents acbtnGrabar As ACControles.ACToolStripButton
End Class
