<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSaldosAFavor
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
        Me.grpCabCuerpo = New System.Windows.Forms.GroupBox()
        Me.AcFecha = New ACControles.ACFecha(Me.components)
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.rbtnElegir = New System.Windows.Forms.RadioButton()
        Me.rbtnTodos = New System.Windows.Forms.RadioButton()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.actxaCliRazonSocial = New ACControles.ACTextBoxAyuda()
        Me.lblNroDocumento = New System.Windows.Forms.Label()
        Me.actxaCliRuc = New ACControles.ACTextBoxAyuda()
        Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
        Me.grpCabCuerpo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpCabCuerpo
        '
        Me.grpCabCuerpo.Controls.Add(Me.AcFecha)
        Me.grpCabCuerpo.Controls.Add(Me.chkTodos)
        Me.grpCabCuerpo.Controls.Add(Me.rbtnElegir)
        Me.grpCabCuerpo.Controls.Add(Me.rbtnTodos)
        Me.grpCabCuerpo.Controls.Add(Me.btnExcel)
        Me.grpCabCuerpo.Controls.Add(Me.btnProcesar)
        Me.grpCabCuerpo.Controls.Add(Me.btnClean)
        Me.grpCabCuerpo.Controls.Add(Me.actxaCliRazonSocial)
        Me.grpCabCuerpo.Controls.Add(Me.lblNroDocumento)
        Me.grpCabCuerpo.Controls.Add(Me.actxaCliRuc)
        Me.grpCabCuerpo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCabCuerpo.Location = New System.Drawing.Point(0, 30)
        Me.grpCabCuerpo.Name = "grpCabCuerpo"
        Me.grpCabCuerpo.Size = New System.Drawing.Size(800, 114)
        Me.grpCabCuerpo.TabIndex = 52
        Me.grpCabCuerpo.TabStop = False
        Me.grpCabCuerpo.Tag = "EVO"
        '
        'AcFecha
        '
        Me.AcFecha.ACFecha_A = New Date(2025, 7, 9, 12, 34, 22, 149)
        Me.AcFecha.ACFecha_De = New Date(2025, 7, 9, 12, 34, 22, 146)
        Me.AcFecha.ACFechaObligatoria = True
        Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
        Me.AcFecha.ACHoyChecked = False
        Me.AcFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AcFecha.Location = New System.Drawing.Point(457, 1)
        Me.AcFecha.MaximumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.MinimumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.Name = "AcFecha"
        Me.AcFecha.Size = New System.Drawing.Size(337, 43)
        Me.AcFecha.TabIndex = 27
        Me.AcFecha.TabStop = False
        '
        'chkTodos
        '
        Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(610, 96)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(105, 17)
        Me.chkTodos.TabIndex = 9
        Me.chkTodos.Text = "Todos los Pagos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'rbtnElegir
        '
        Me.rbtnElegir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnElegir.AutoSize = True
        Me.rbtnElegir.Checked = True
        Me.rbtnElegir.Location = New System.Drawing.Point(400, 19)
        Me.rbtnElegir.Name = "rbtnElegir"
        Me.rbtnElegir.Size = New System.Drawing.Size(51, 17)
        Me.rbtnElegir.TabIndex = 7
        Me.rbtnElegir.TabStop = True
        Me.rbtnElegir.Text = "Elegir"
        Me.rbtnElegir.UseVisualStyleBackColor = True
        '
        'rbtnTodos
        '
        Me.rbtnTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnTodos.AutoSize = True
        Me.rbtnTodos.Location = New System.Drawing.Point(242, 19)
        Me.rbtnTodos.Name = "rbtnTodos"
        Me.rbtnTodos.Size = New System.Drawing.Size(111, 17)
        Me.rbtnTodos.TabIndex = 6
        Me.rbtnTodos.Text = "Todos los Clientes"
        Me.rbtnTodos.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(748, 50)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(42, 41)
        Me.btnExcel.TabIndex = 5
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(622, 50)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(120, 41)
        Me.btnProcesar.TabIndex = 4
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClean.Location = New System.Drawing.Point(565, 57)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(36, 28)
        Me.btnClean.TabIndex = 3
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'actxaCliRazonSocial
        '
        Me.actxaCliRazonSocial.ACActivarAyudaAuto = False
        Me.actxaCliRazonSocial.ACLongitudAceptada = 0
        Me.actxaCliRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaCliRazonSocial.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxaCliRazonSocial.Location = New System.Drawing.Point(187, 59)
        Me.actxaCliRazonSocial.MaxLength = 80
        Me.actxaCliRazonSocial.Name = "actxaCliRazonSocial"
        Me.actxaCliRazonSocial.Size = New System.Drawing.Size(372, 24)
        Me.actxaCliRazonSocial.TabIndex = 2
        Me.actxaCliRazonSocial.Tag = "EVO"
        '
        'lblNroDocumento
        '
        Me.lblNroDocumento.AutoSize = True
        Me.lblNroDocumento.Location = New System.Drawing.Point(15, 65)
        Me.lblNroDocumento.Name = "lblNroDocumento"
        Me.lblNroDocumento.Size = New System.Drawing.Size(45, 13)
        Me.lblNroDocumento.TabIndex = 0
        Me.lblNroDocumento.Text = "Cliente :"
        '
        'actxaCliRuc
        '
        Me.actxaCliRuc.ACActivarAyudaAuto = False
        Me.actxaCliRuc.ACLongitudAceptada = 0
        Me.actxaCliRuc.Location = New System.Drawing.Point(70, 61)
        Me.actxaCliRuc.MaxLength = 14
        Me.actxaCliRuc.Name = "actxaCliRuc"
        Me.actxaCliRuc.Size = New System.Drawing.Size(111, 20)
        Me.actxaCliRuc.TabIndex = 1
        Me.actxaCliRuc.Tag = "EVO"
        '
        'AcPanelCaption1
        '
        Me.AcPanelCaption1.ACCaption = "Estado de Pagos por Cliente"
        Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption1.Name = "AcPanelCaption1"
        Me.AcPanelCaption1.Size = New System.Drawing.Size(800, 30)
        Me.AcPanelCaption1.TabIndex = 53
        '
        'RSaldosAFavor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.grpCabCuerpo)
        Me.Controls.Add(Me.AcPanelCaption1)
        Me.Name = "RSaldosAFavor"
        Me.Text = "RSaldosAFavor"
        Me.grpCabCuerpo.ResumeLayout(False)
        Me.grpCabCuerpo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpCabCuerpo As GroupBox
    Friend WithEvents AcFecha As ACControles.ACFecha
    Friend WithEvents chkTodos As CheckBox
    Friend WithEvents rbtnElegir As RadioButton
    Friend WithEvents rbtnTodos As RadioButton
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnProcesar As Button
    Friend WithEvents btnClean As Button
    Friend WithEvents actxaCliRazonSocial As ACControles.ACTextBoxAyuda
    Friend WithEvents lblNroDocumento As Label
    Friend WithEvents actxaCliRuc As ACControles.ACTextBoxAyuda
    Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
End Class
