<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FViajes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FViajes))
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.tcnDetalle = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.tpgVehiRanfla = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pblVehiRanfla = New System.Windows.Forms.Panel()
        Me.tscBase = New System.Windows.Forms.ToolStripContainer()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.pnlPresupuesto = New System.Windows.Forms.Panel()
        Me.c1grdGastoInicial = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.bnavPresupuesto = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnPrModificar = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnPrAgregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator47 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnPrQuitar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
        Me.pnlGuias = New System.Windows.Forms.Panel()
        Me.cmbGEmpresa = New System.Windows.Forms.ComboBox()
        Me.cmbCondicion = New System.Windows.Forms.ComboBox()
        Me.cmbFlete = New System.Windows.Forms.ComboBox()
        Me.cmbTipoGuia = New System.Windows.Forms.ComboBox()
        Me.c1grdGuiaRemision = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnGuiaGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.bnavGuiaRemision = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator44 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox10 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator45 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton27 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton28 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator46 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption9 = New ACControles.ACPanelCaption()
        Me.pnlDatosBase = New System.Windows.Forms.Panel()
        Me.btnModVehiculo = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbRanMarca = New System.Windows.Forms.ComboBox()
        Me.txtRanCertificado = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtRanPlaca = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtRanCodigo = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.grpVehiculo = New System.Windows.Forms.GroupBox()
        Me.cmbTipoVehiculo = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbMarca = New System.Windows.Forms.ComboBox()
        Me.txtVehCertificado = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtVehPlaca = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtVehCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpConFecNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.txtConLicencia = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtConNombre = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tpgConsCombustible = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlConsCombustible = New System.Windows.Forms.Panel()
        Me.c1grdConsCombustible = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavConsCombustible = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton17 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton18 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox4 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton19 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton20 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnCCAgregar = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnCCQuitar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnCModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnCCModFecha = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption4 = New ACControles.ACPanelCaption()
        Me.tpgConsumoAdBlue = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlConsumoAdBlue = New System.Windows.Forms.Panel()
        Me.c1grdConsumoAdBlue = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavConsumoAdBlue = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel14 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton29 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton34 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox12 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator39 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton41 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton42 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator40 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnCABAgregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator48 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnCABModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator51 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton48 = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnCABQuitar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel15 = New System.Windows.Forms.ToolStripLabel()
        Me.AcPanelCaption12 = New ACControles.ACPanelCaption()
        Me.tpgGastos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlGastos = New System.Windows.Forms.Panel()
        Me.c1grdGastViajes = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavGastos = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton23 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton24 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox5 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton25 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton26 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnGVAgregar = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnGVQuitar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator37 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnGVModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator38 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption5 = New ACControles.ACPanelCaption()
        Me.tpgFletes = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlFletes = New System.Windows.Forms.Panel()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.c1grdFletes = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtFleObs = New System.Windows.Forms.TextBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnFleGrabar = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption11 = New ACControles.ACPanelCaption()
        Me.bnavFletes = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAddNewFlete = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnFQuitar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator43 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAgregarFlete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator49 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnModFlete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator50 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption2 = New ACControles.ACPanelCaption()
        Me.tpgPresupuesto = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlIngEgre = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.c1grdIngEgre = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel12 = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbImpresora = New System.Windows.Forms.ToolStripComboBox()
        Me.bnavIngEgre = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel11 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton37 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton38 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox11 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator32 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton39 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton40 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnRecAgregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnRecQuitar = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnRModificar = New System.Windows.Forms.ToolStripButton()
        Me.c1grdRecEmitir = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnImprimirRec = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel13 = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbImpresoraRec = New System.Windows.Forms.ToolStripComboBox()
        Me.bnavRecEmitir = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption10 = New ACControles.ACPanelCaption()
        Me.tpgNeumaticos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlInvNeumaticos = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.c1grdInvNeumaticos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.acvRanfla = New ACControles.ACVehiculo()
        Me.acvTracto = New ACControles.ACVehiculo()
        Me.bnavNeumaticos = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton35 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton36 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox8 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton43 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton44 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAgregarIncNeumaticos = New System.Windows.Forms.ToolStripButton()
        Me.pnlInciNeumatico = New System.Windows.Forms.Panel()
        Me.c1grdInciNeumatico = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavInciNeumaticos = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox9 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton21 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton22 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnQuitarIncNeumaticos = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption8 = New ACControles.ACPanelCaption()
        Me.AcPanelCaption7 = New ACControles.ACPanelCaption()
        Me.tpgIncidencias = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlIncidencias = New System.Windows.Forms.Panel()
        Me.c1grdInciViajes = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtVIGlosa = New System.Windows.Forms.TextBox()
        Me.bnavInicidencias = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnIVAgregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator41 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnIVQuitar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator42 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption3 = New ACControles.ACPanelCaption()
        Me.tpgResumen = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.grpLiq = New System.Windows.Forms.GroupBox()
        Me.actxnConsumoAddBlue = New ACControles.ACTextBoxNumerico()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.btnGenRecibo = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.actxnSaldo = New ACControles.ACTextBoxNumerico()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.actxnPendiente2 = New ACControles.ACTextBoxNumerico()
        Me.actxnPagoConductor = New ACControles.ACTextBoxNumerico()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.actxnRecibosEgreso = New ACControles.ACTextBoxNumerico()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.actxnConsumoCombustible = New ACControles.ACTextBoxNumerico()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.actxnGastosConductor = New ACControles.ACTextBoxNumerico()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.btnCalLiqConductor = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.actxnPendiente = New ACControles.ACTextBoxNumerico()
        Me.actxnRecibosIngreso = New ACControles.ACTextBoxNumerico()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.actxnGastonInicial = New ACControles.ACTextBoxNumerico()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpRutas = New System.Windows.Forms.GroupBox()
        Me.c1grdRutas = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavRutas = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton30 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton31 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox6 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton32 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton33 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator36 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption6 = New ACControles.ACPanelCaption()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.actxnAddBlueRealizado = New ACControles.ACTextBoxNumerico()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.actxnConsAddBlueRealizado = New ACControles.ACTextBoxNumerico()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dtpFecScan = New System.Windows.Forms.DateTimePicker()
        Me.actxnCombScanner = New ACControles.ACTextBoxNumerico()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.actxnKmScanner = New ACControles.ACTextBoxNumerico()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.txtViajexConductor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpCombustible = New System.Windows.Forms.GroupBox()
        Me.actxnCombRealizado = New ACControles.ACTextBoxNumerico()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.actxnConsRealizado = New ACControles.ACTextBoxNumerico()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtViajeXvehiculo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.dtpFecLlegada = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.actxnVehKilometrajeMantenimiento_ = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.actxnVehKilometrajeMantenimiento = New ACControles.ACTextBoxNumerico()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.actxnKmAnterior = New ACControles.ACTextBoxNumerico()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.actxnVehKilometraje = New ACControles.ACTextBoxNumerico()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.actxnKmDiferencia = New ACControles.ACTextBoxNumerico()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.actxnKilometraje = New ACControles.ACTextBoxNumerico()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpFecSalida = New System.Windows.Forms.DateTimePicker()
        Me.dtpHorSalida = New System.Windows.Forms.DateTimePicker()
        Me.dtpHorLlegada = New System.Windows.Forms.DateTimePicker()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnRepIngre = New System.Windows.Forms.ToolStripButton()
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.c1grdBusqueda = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavBusqueda = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnQuitarLiquidacion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton52 = New System.Windows.Forms.ToolStripButton()
        Me.grpBusqueda = New System.Windows.Forms.GroupBox()
        Me.rbtnPlacaTracto = New System.Windows.Forms.RadioButton()
        Me.rbtnDescripcion = New System.Windows.Forms.RadioButton()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.grpBFecha = New System.Windows.Forms.GroupBox()
        Me.rbtnFecSalida = New System.Windows.Forms.RadioButton()
        Me.rbtnFecLlegada = New System.Windows.Forms.RadioButton()
        Me.acFecha = New ACControles.ACFecha(Me.components)
        Me.rbtnCodigo = New System.Windows.Forms.RadioButton()
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.C1FlexGrid7 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox7 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.tsbtnPreview = New ACControles.ACToolStripButton(Me.components)
        Me.actsbtnQuitarAnulado = New ACControles.ACToolStripButton(Me.components)
        Me.tsbtnLiquidacion = New ACControles.ACToolStripButton(Me.components)
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.tabDatos.SuspendLayout
        Me.tcnDetalle.SuspendLayout
        Me.tpgVehiRanfla.SuspendLayout
        Me.pblVehiRanfla.SuspendLayout
        Me.tscBase.ContentPanel.SuspendLayout
        Me.tscBase.SuspendLayout
        Me.pnlDatos.SuspendLayout
        Me.pnlPresupuesto.SuspendLayout
        CType(Me.c1grdGastoInicial,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bnavPresupuesto,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavPresupuesto.SuspendLayout
        Me.pnlGuias.SuspendLayout
        CType(Me.c1grdGuiaRemision,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip2.SuspendLayout
        CType(Me.bnavGuiaRemision,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavGuiaRemision.SuspendLayout
        Me.pnlDatosBase.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.grpVehiculo.SuspendLayout
        Me.GroupBox3.SuspendLayout
        Me.tpgConsCombustible.SuspendLayout
        Me.pnlConsCombustible.SuspendLayout
        CType(Me.c1grdConsCombustible,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bnavConsCombustible,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavConsCombustible.SuspendLayout
        Me.tpgConsumoAdBlue.SuspendLayout
        Me.pnlConsumoAdBlue.SuspendLayout
        CType(Me.c1grdConsumoAdBlue,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bnavConsumoAdBlue,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavConsumoAdBlue.SuspendLayout
        Me.tpgGastos.SuspendLayout
        Me.pnlGastos.SuspendLayout
        CType(Me.c1grdGastViajes,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bnavGastos,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavGastos.SuspendLayout
        Me.tpgFletes.SuspendLayout
        Me.pnlFletes.SuspendLayout
        CType(Me.SplitContainer3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer3.Panel1.SuspendLayout
        Me.SplitContainer3.Panel2.SuspendLayout
        Me.SplitContainer3.SuspendLayout
        CType(Me.c1grdFletes,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip3.SuspendLayout
        CType(Me.bnavFletes,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavFletes.SuspendLayout
        Me.tpgPresupuesto.SuspendLayout
        Me.pnlIngEgre.SuspendLayout
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer2.Panel1.SuspendLayout
        Me.SplitContainer2.Panel2.SuspendLayout
        Me.SplitContainer2.SuspendLayout
        CType(Me.c1grdIngEgre,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip4.SuspendLayout
        CType(Me.bnavIngEgre,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavIngEgre.SuspendLayout
        CType(Me.c1grdRecEmitir,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip5.SuspendLayout
        CType(Me.bnavRecEmitir,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavRecEmitir.SuspendLayout
        Me.tpgNeumaticos.SuspendLayout
        Me.pnlInvNeumaticos.SuspendLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        Me.Panel2.SuspendLayout
        CType(Me.c1grdInvNeumaticos,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        CType(Me.bnavNeumaticos,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavNeumaticos.SuspendLayout
        Me.pnlInciNeumatico.SuspendLayout
        CType(Me.c1grdInciNeumatico,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bnavInciNeumaticos,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavInciNeumaticos.SuspendLayout
        Me.tpgIncidencias.SuspendLayout
        Me.pnlIncidencias.SuspendLayout
        CType(Me.c1grdInciViajes,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bnavInicidencias,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavInicidencias.SuspendLayout
        Me.tpgResumen.SuspendLayout
        Me.grpLiq.SuspendLayout
        Me.GroupBox4.SuspendLayout
        Me.grpRutas.SuspendLayout
        CType(Me.c1grdRutas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bnavRutas,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavRutas.SuspendLayout
        Me.Panel3.SuspendLayout
        Me.GroupBox6.SuspendLayout
        Me.GroupBox5.SuspendLayout
        Me.grpCombustible.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.tabMantenimiento.SuspendLayout
        Me.tabBusqueda.SuspendLayout
        CType(Me.c1grdBusqueda,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bnavBusqueda,System.ComponentModel.ISupportInitialize).BeginInit
        Me.bnavBusqueda.SuspendLayout
        Me.grpBusqueda.SuspendLayout
        Me.grpBFecha.SuspendLayout
        CType(Me.C1FlexGrid7,System.ComponentModel.ISupportInitialize).BeginInit
        Me.acTool.SuspendLayout
        Me.SuspendLayout
        '
        'tabDatos
        '
        Me.tabDatos.Controls.Add(Me.tcnDetalle)
        Me.tabDatos.Controls.Add(Me.Panel3)
        Me.tabDatos.Controls.Add(Me.ToolStrip1)
        Me.tabDatos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Location = New System.Drawing.Point(1, 1)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Size = New System.Drawing.Size(1414, 594)
        Me.tabDatos.TabIndex = 2
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'tcnDetalle
        '
        Me.tcnDetalle.BackColor = System.Drawing.Color.White
        Me.tcnDetalle.BoldSelectedPage = true
        Me.tcnDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcnDetalle.ImageList = Me.ImageList
        Me.tcnDetalle.InsetBorderPagesOnly = true
        Me.tcnDetalle.Location = New System.Drawing.Point(0, 138)
        Me.tcnDetalle.MediaPlayerDockSides = false
        Me.tcnDetalle.Name = "tcnDetalle"
        Me.tcnDetalle.OfficeDockSides = false
        Me.tcnDetalle.OfficeHeaderBorder = true
        Me.tcnDetalle.OfficeStyle = Crownwood.DotNetMagic.Controls.OfficeStyle.Light
        Me.tcnDetalle.PositionTop = true
        Me.tcnDetalle.SelectedIndex = 7
        Me.tcnDetalle.ShowArrows = true
        Me.tcnDetalle.ShowDropSelect = false
        Me.tcnDetalle.Size = New System.Drawing.Size(1414, 456)
        Me.tcnDetalle.Style = Crownwood.DotNetMagic.Common.VisualStyle.Office2003
        Me.tcnDetalle.TabIndex = 1
        Me.tcnDetalle.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tpgVehiRanfla, Me.tpgConsCombustible, Me.tpgConsumoAdBlue, Me.tpgGastos, Me.tpgFletes, Me.tpgPresupuesto, Me.tpgNeumaticos, Me.tpgIncidencias, Me.tpgResumen})
        Me.tcnDetalle.TextTips = true
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Admin_32x32.png")
        Me.ImageList.Images.SetKeyName(1, "AdminPanel_16x16.png")
        '
        'tpgVehiRanfla
        '
        Me.tpgVehiRanfla.Controls.Add(Me.pblVehiRanfla)
        Me.tpgVehiRanfla.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgVehiRanfla.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgVehiRanfla.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgVehiRanfla.Location = New System.Drawing.Point(1, 24)
        Me.tpgVehiRanfla.Name = "tpgVehiRanfla"
        Me.tpgVehiRanfla.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgVehiRanfla.Selected = false
        Me.tpgVehiRanfla.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgVehiRanfla.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgVehiRanfla.Size = New System.Drawing.Size(1412, 431)
        Me.tpgVehiRanfla.TabIndex = 11
        Me.tpgVehiRanfla.Title = "Vehiculo, Ranfla, Conductor y Fletes"
        Me.tpgVehiRanfla.ToolTip = "Vehiculo, Ranfla, Conductor y Fletes"
        '
        'pblVehiRanfla
        '
        Me.pblVehiRanfla.Controls.Add(Me.tscBase)
        Me.pblVehiRanfla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pblVehiRanfla.Location = New System.Drawing.Point(0, 0)
        Me.pblVehiRanfla.Name = "pblVehiRanfla"
        Me.pblVehiRanfla.Size = New System.Drawing.Size(1412, 431)
        Me.pblVehiRanfla.TabIndex = 0
        '
        'tscBase
        '
        '
        'tscBase.ContentPanel
        '
        Me.tscBase.ContentPanel.Controls.Add(Me.pnlDatos)
        Me.tscBase.ContentPanel.Size = New System.Drawing.Size(1412, 406)
        Me.tscBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tscBase.Location = New System.Drawing.Point(0, 0)
        Me.tscBase.Name = "tscBase"
        Me.tscBase.Size = New System.Drawing.Size(1412, 431)
        Me.tscBase.TabIndex = 2
        Me.tscBase.Text = "ToolStripContainer1"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.pnlPresupuesto)
        Me.pnlDatos.Controls.Add(Me.pnlDatosBase)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1412, 406)
        Me.pnlDatos.TabIndex = 0
        '
        'pnlPresupuesto
        '
        Me.pnlPresupuesto.Controls.Add(Me.c1grdGastoInicial)
        Me.pnlPresupuesto.Controls.Add(Me.Splitter1)
        Me.pnlPresupuesto.Controls.Add(Me.bnavPresupuesto)
        Me.pnlPresupuesto.Controls.Add(Me.AcPanelCaption1)
        Me.pnlPresupuesto.Controls.Add(Me.pnlGuias)
        Me.pnlPresupuesto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPresupuesto.Location = New System.Drawing.Point(435, 0)
        Me.pnlPresupuesto.Name = "pnlPresupuesto"
        Me.pnlPresupuesto.Size = New System.Drawing.Size(977, 406)
        Me.pnlPresupuesto.TabIndex = 34
        '
        'c1grdGastoInicial
        '
        Me.c1grdGastoInicial.AllowEditing = false
        Me.c1grdGastoInicial.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdGastoInicial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdGastoInicial.Location = New System.Drawing.Point(0, 20)
        Me.c1grdGastoInicial.Name = "c1grdGastoInicial"
        Me.c1grdGastoInicial.Rows.Count = 2
        Me.c1grdGastoInicial.Rows.DefaultSize = 20
        Me.c1grdGastoInicial.Size = New System.Drawing.Size(977, 237)
        Me.c1grdGastoInicial.StyleInfo = resources.GetString("c1grdGastoInicial.StyleInfo")
        Me.c1grdGastoInicial.TabIndex = 17
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 257)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(977, 5)
        Me.Splitter1.TabIndex = 38
        Me.Splitter1.TabStop = false
        '
        'bnavPresupuesto
        '
        Me.bnavPresupuesto.AddNewItem = Nothing
        Me.bnavPresupuesto.CountItem = Me.ToolStripLabel1
        Me.bnavPresupuesto.DeleteItem = Nothing
        Me.bnavPresupuesto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.tsbtnPrModificar, Me.tsbtnPrAgregar, Me.ToolStripSeparator47, Me.tsbtnPrQuitar, Me.ToolStripSeparator35})
        Me.bnavPresupuesto.Location = New System.Drawing.Point(0, 20)
        Me.bnavPresupuesto.MoveFirstItem = Me.ToolStripButton3
        Me.bnavPresupuesto.MoveLastItem = Me.ToolStripButton6
        Me.bnavPresupuesto.MoveNextItem = Me.ToolStripButton5
        Me.bnavPresupuesto.MovePreviousItem = Me.ToolStripButton4
        Me.bnavPresupuesto.Name = "bnavPresupuesto"
        Me.bnavPresupuesto.PositionItem = Me.ToolStripTextBox1
        Me.bnavPresupuesto.Size = New System.Drawing.Size(838, 25)
        Me.bnavPresupuesto.TabIndex = 16
        Me.bnavPresupuesto.Text = "BindingNavigator1"
        Me.bnavPresupuesto.Visible = false
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "de {0}"
        Me.ToolStripLabel1.ToolTipText = "Total number of items"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"),System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Move first"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"),System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Move previous"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Position"
        Me.ToolStripTextBox1.AutoSize = false
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Current position"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"),System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Move next"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"),System.Drawing.Image)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Move last"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnPrModificar
        '
        Me.tsbtnPrModificar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnPrModificar.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.tsbtnPrModificar.Name = "tsbtnPrModificar"
        Me.tsbtnPrModificar.RightToLeftAutoMirrorImage = true
        Me.tsbtnPrModificar.Size = New System.Drawing.Size(78, 22)
        Me.tsbtnPrModificar.Text = "Modificar"
        '
        'tsbtnPrAgregar
        '
        Me.tsbtnPrAgregar.Image = CType(resources.GetObject("tsbtnPrAgregar.Image"),System.Drawing.Image)
        Me.tsbtnPrAgregar.Name = "tsbtnPrAgregar"
        Me.tsbtnPrAgregar.RightToLeftAutoMirrorImage = true
        Me.tsbtnPrAgregar.Size = New System.Drawing.Size(69, 22)
        Me.tsbtnPrAgregar.Text = "&Agregar"
        '
        'ToolStripSeparator47
        '
        Me.ToolStripSeparator47.Name = "ToolStripSeparator47"
        Me.ToolStripSeparator47.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnPrQuitar
        '
        Me.tsbtnPrQuitar.Image = CType(resources.GetObject("tsbtnPrQuitar.Image"),System.Drawing.Image)
        Me.tsbtnPrQuitar.Name = "tsbtnPrQuitar"
        Me.tsbtnPrQuitar.RightToLeftAutoMirrorImage = true
        Me.tsbtnPrQuitar.Size = New System.Drawing.Size(60, 22)
        Me.tsbtnPrQuitar.Text = "&Quitar"
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption1
        '
        Me.AcPanelCaption1.ACCaption = "Gasto Inicial"
        Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption1.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption1.Name = "AcPanelCaption1"
        Me.AcPanelCaption1.Size = New System.Drawing.Size(977, 20)
        Me.AcPanelCaption1.TabIndex = 13
        '
        'pnlGuias
        '
        Me.pnlGuias.Controls.Add(Me.cmbGEmpresa)
        Me.pnlGuias.Controls.Add(Me.cmbCondicion)
        Me.pnlGuias.Controls.Add(Me.cmbFlete)
        Me.pnlGuias.Controls.Add(Me.cmbTipoGuia)
        Me.pnlGuias.Controls.Add(Me.c1grdGuiaRemision)
        Me.pnlGuias.Controls.Add(Me.ToolStrip2)
        Me.pnlGuias.Controls.Add(Me.bnavGuiaRemision)
        Me.pnlGuias.Controls.Add(Me.AcPanelCaption9)
        Me.pnlGuias.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuias.Location = New System.Drawing.Point(0, 262)
        Me.pnlGuias.Name = "pnlGuias"
        Me.pnlGuias.Size = New System.Drawing.Size(977, 144)
        Me.pnlGuias.TabIndex = 37
        '
        'cmbGEmpresa
        '
        Me.cmbGEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGEmpresa.DropDownWidth = 250
        Me.cmbGEmpresa.Enabled = false
        Me.cmbGEmpresa.FormattingEnabled = true
        Me.cmbGEmpresa.Location = New System.Drawing.Point(42, 99)
        Me.cmbGEmpresa.Name = "cmbGEmpresa"
        Me.cmbGEmpresa.Size = New System.Drawing.Size(133, 23)
        Me.cmbGEmpresa.TabIndex = 43
        '
        'cmbCondicion
        '
        Me.cmbCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicion.DropDownWidth = 100
        Me.cmbCondicion.Enabled = false
        Me.cmbCondicion.FormattingEnabled = true
        Me.cmbCondicion.Location = New System.Drawing.Point(252, 86)
        Me.cmbCondicion.Name = "cmbCondicion"
        Me.cmbCondicion.Size = New System.Drawing.Size(133, 23)
        Me.cmbCondicion.TabIndex = 42
        '
        'cmbFlete
        '
        Me.cmbFlete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFlete.DropDownWidth = 250
        Me.cmbFlete.Enabled = false
        Me.cmbFlete.FormattingEnabled = true
        Me.cmbFlete.Location = New System.Drawing.Point(340, 57)
        Me.cmbFlete.Name = "cmbFlete"
        Me.cmbFlete.Size = New System.Drawing.Size(133, 23)
        Me.cmbFlete.TabIndex = 41
        '
        'cmbTipoGuia
        '
        Me.cmbTipoGuia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoGuia.DropDownWidth = 250
        Me.cmbTipoGuia.Enabled = false
        Me.cmbTipoGuia.FormattingEnabled = true
        Me.cmbTipoGuia.Location = New System.Drawing.Point(187, 57)
        Me.cmbTipoGuia.Name = "cmbTipoGuia"
        Me.cmbTipoGuia.Size = New System.Drawing.Size(133, 23)
        Me.cmbTipoGuia.TabIndex = 40
        '
        'c1grdGuiaRemision
        '
        Me.c1grdGuiaRemision.AllowAddNew = true
        Me.c1grdGuiaRemision.AllowDelete = true
        Me.c1grdGuiaRemision.ColumnInfo = "2,1,0,0,0,95,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdGuiaRemision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdGuiaRemision.Font = New System.Drawing.Font("Segoe UI", 11!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdGuiaRemision.Location = New System.Drawing.Point(0, 44)
        Me.c1grdGuiaRemision.Name = "c1grdGuiaRemision"
        Me.c1grdGuiaRemision.Rows.Count = 2
        Me.c1grdGuiaRemision.Rows.DefaultSize = 19
        Me.c1grdGuiaRemision.Size = New System.Drawing.Size(977, 100)
        Me.c1grdGuiaRemision.StyleInfo = resources.GetString("c1grdGuiaRemision.StyleInfo")
        Me.c1grdGuiaRemision.TabIndex = 15
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnGuiaGrabar, Me.ToolStripSeparator28})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 19)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(977, 25)
        Me.ToolStrip2.TabIndex = 17
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbtnGuiaGrabar
        '
        Me.tsbtnGuiaGrabar.Image = Global.ACPTransportes.My.Resources.Resources.ACGrabar_16x16
        Me.tsbtnGuiaGrabar.Name = "tsbtnGuiaGrabar"
        Me.tsbtnGuiaGrabar.RightToLeftAutoMirrorImage = true
        Me.tsbtnGuiaGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbtnGuiaGrabar.Text = "Graba&r"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(6, 25)
        '
        'bnavGuiaRemision
        '
        Me.bnavGuiaRemision.AddNewItem = Nothing
        Me.bnavGuiaRemision.CountItem = Me.ToolStripLabel10
        Me.bnavGuiaRemision.DeleteItem = Nothing
        Me.bnavGuiaRemision.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavGuiaRemision.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator44, Me.ToolStripTextBox10, Me.ToolStripLabel10, Me.ToolStripSeparator45, Me.ToolStripButton27, Me.ToolStripButton28, Me.ToolStripSeparator46})
        Me.bnavGuiaRemision.Location = New System.Drawing.Point(0, 119)
        Me.bnavGuiaRemision.MoveFirstItem = Me.ToolStripButton1
        Me.bnavGuiaRemision.MoveLastItem = Me.ToolStripButton28
        Me.bnavGuiaRemision.MoveNextItem = Me.ToolStripButton27
        Me.bnavGuiaRemision.MovePreviousItem = Me.ToolStripButton2
        Me.bnavGuiaRemision.Name = "bnavGuiaRemision"
        Me.bnavGuiaRemision.PositionItem = Me.ToolStripTextBox10
        Me.bnavGuiaRemision.Size = New System.Drawing.Size(838, 25)
        Me.bnavGuiaRemision.TabIndex = 16
        Me.bnavGuiaRemision.Text = "bnavFletes"
        Me.bnavGuiaRemision.Visible = false
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel10.Text = "de {0}"
        Me.ToolStripLabel10.ToolTipText = "Total number of items"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"),System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Move first"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"),System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Move previous"
        '
        'ToolStripSeparator44
        '
        Me.ToolStripSeparator44.Name = "ToolStripSeparator44"
        Me.ToolStripSeparator44.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox10
        '
        Me.ToolStripTextBox10.AccessibleName = "Position"
        Me.ToolStripTextBox10.AutoSize = false
        Me.ToolStripTextBox10.Name = "ToolStripTextBox10"
        Me.ToolStripTextBox10.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox10.Text = "0"
        Me.ToolStripTextBox10.ToolTipText = "Current position"
        '
        'ToolStripSeparator45
        '
        Me.ToolStripSeparator45.Name = "ToolStripSeparator45"
        Me.ToolStripSeparator45.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton27
        '
        Me.ToolStripButton27.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton27.Image = CType(resources.GetObject("ToolStripButton27.Image"),System.Drawing.Image)
        Me.ToolStripButton27.Name = "ToolStripButton27"
        Me.ToolStripButton27.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton27.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton27.Text = "Move next"
        '
        'ToolStripButton28
        '
        Me.ToolStripButton28.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton28.Image = CType(resources.GetObject("ToolStripButton28.Image"),System.Drawing.Image)
        Me.ToolStripButton28.Name = "ToolStripButton28"
        Me.ToolStripButton28.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton28.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton28.Text = "Move last"
        '
        'ToolStripSeparator46
        '
        Me.ToolStripSeparator46.Name = "ToolStripSeparator46"
        Me.ToolStripSeparator46.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption9
        '
        Me.AcPanelCaption9.ACCaption = "Guias de Remisión"
        Me.AcPanelCaption9.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption9.Font = New System.Drawing.Font("Tahoma", 10!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption9.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption9.Name = "AcPanelCaption9"
        Me.AcPanelCaption9.Size = New System.Drawing.Size(977, 19)
        Me.AcPanelCaption9.TabIndex = 39
        '
        'pnlDatosBase
        '
        Me.pnlDatosBase.Controls.Add(Me.btnModVehiculo)
        Me.pnlDatosBase.Controls.Add(Me.GroupBox2)
        Me.pnlDatosBase.Controls.Add(Me.grpVehiculo)
        Me.pnlDatosBase.Controls.Add(Me.GroupBox3)
        Me.pnlDatosBase.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDatosBase.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatosBase.Name = "pnlDatosBase"
        Me.pnlDatosBase.Size = New System.Drawing.Size(435, 406)
        Me.pnlDatosBase.TabIndex = 20
        '
        'btnModVehiculo
        '
        Me.btnModVehiculo.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_32x32
        Me.btnModVehiculo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModVehiculo.Location = New System.Drawing.Point(221, 138)
        Me.btnModVehiculo.Name = "btnModVehiculo"
        Me.btnModVehiculo.Size = New System.Drawing.Size(113, 43)
        Me.btnModVehiculo.TabIndex = 3
        Me.btnModVehiculo.Text = "Modificar Vehiculo"
        Me.btnModVehiculo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModVehiculo.UseVisualStyleBackColor = true
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmbRanMarca)
        Me.GroupBox2.Controls.Add(Me.txtRanCertificado)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtRanPlaca)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtRanCodigo)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Location = New System.Drawing.Point(217, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(212, 134)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Ranfla"
        '
        'cmbRanMarca
        '
        Me.cmbRanMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRanMarca.Enabled = false
        Me.cmbRanMarca.FormattingEnabled = true
        Me.cmbRanMarca.Location = New System.Drawing.Point(59, 103)
        Me.cmbRanMarca.Name = "cmbRanMarca"
        Me.cmbRanMarca.Size = New System.Drawing.Size(143, 23)
        Me.cmbRanMarca.TabIndex = 11
        '
        'txtRanCertificado
        '
        Me.txtRanCertificado.Location = New System.Drawing.Point(96, 74)
        Me.txtRanCertificado.Name = "txtRanCertificado"
        Me.txtRanCertificado.ReadOnly = true
        Me.txtRanCertificado.Size = New System.Drawing.Size(106, 23)
        Me.txtRanCertificado.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = true
        Me.Label18.Location = New System.Drawing.Point(14, 78)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 15)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Certificado :"
        '
        'Label19
        '
        Me.Label19.AutoSize = true
        Me.Label19.Location = New System.Drawing.Point(14, 106)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 15)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Marca :"
        '
        'txtRanPlaca
        '
        Me.txtRanPlaca.Location = New System.Drawing.Point(96, 45)
        Me.txtRanPlaca.Name = "txtRanPlaca"
        Me.txtRanPlaca.ReadOnly = true
        Me.txtRanPlaca.Size = New System.Drawing.Size(106, 23)
        Me.txtRanPlaca.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = true
        Me.Label20.Location = New System.Drawing.Point(14, 49)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(41, 15)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Placa :"
        '
        'txtRanCodigo
        '
        Me.txtRanCodigo.Location = New System.Drawing.Point(96, 16)
        Me.txtRanCodigo.Name = "txtRanCodigo"
        Me.txtRanCodigo.ReadOnly = true
        Me.txtRanCodigo.Size = New System.Drawing.Size(106, 23)
        Me.txtRanCodigo.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = true
        Me.Label21.Location = New System.Drawing.Point(14, 20)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 15)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Codigo :"
        '
        'grpVehiculo
        '
        Me.grpVehiculo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpVehiculo.Controls.Add(Me.cmbTipoVehiculo)
        Me.grpVehiculo.Controls.Add(Me.Label22)
        Me.grpVehiculo.Controls.Add(Me.cmbMarca)
        Me.grpVehiculo.Controls.Add(Me.txtVehCertificado)
        Me.grpVehiculo.Controls.Add(Me.Label15)
        Me.grpVehiculo.Controls.Add(Me.Label14)
        Me.grpVehiculo.Controls.Add(Me.txtVehPlaca)
        Me.grpVehiculo.Controls.Add(Me.Label13)
        Me.grpVehiculo.Controls.Add(Me.txtVehCodigo)
        Me.grpVehiculo.Controls.Add(Me.Label2)
        Me.grpVehiculo.Location = New System.Drawing.Point(4, 3)
        Me.grpVehiculo.Name = "grpVehiculo"
        Me.grpVehiculo.Size = New System.Drawing.Size(211, 175)
        Me.grpVehiculo.TabIndex = 0
        Me.grpVehiculo.TabStop = false
        Me.grpVehiculo.Text = "Vehiculo"
        '
        'cmbTipoVehiculo
        '
        Me.cmbTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoVehiculo.Enabled = false
        Me.cmbTipoVehiculo.FormattingEnabled = true
        Me.cmbTipoVehiculo.Location = New System.Drawing.Point(98, 74)
        Me.cmbTipoVehiculo.Name = "cmbTipoVehiculo"
        Me.cmbTipoVehiculo.Size = New System.Drawing.Size(96, 23)
        Me.cmbTipoVehiculo.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.AutoSize = true
        Me.Label22.Location = New System.Drawing.Point(9, 78)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 15)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Tipo Vehiculo :"
        '
        'cmbMarca
        '
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.Enabled = false
        Me.cmbMarca.FormattingEnabled = true
        Me.cmbMarca.Location = New System.Drawing.Point(61, 104)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(133, 23)
        Me.cmbMarca.TabIndex = 10
        '
        'txtVehCertificado
        '
        Me.txtVehCertificado.Location = New System.Drawing.Point(98, 134)
        Me.txtVehCertificado.Name = "txtVehCertificado"
        Me.txtVehCertificado.ReadOnly = true
        Me.txtVehCertificado.Size = New System.Drawing.Size(96, 23)
        Me.txtVehCertificado.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = true
        Me.Label15.Location = New System.Drawing.Point(9, 138)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 15)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Certificado :"
        '
        'Label14
        '
        Me.Label14.AutoSize = true
        Me.Label14.Location = New System.Drawing.Point(9, 108)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 15)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Marca :"
        '
        'txtVehPlaca
        '
        Me.txtVehPlaca.Location = New System.Drawing.Point(98, 44)
        Me.txtVehPlaca.Name = "txtVehPlaca"
        Me.txtVehPlaca.ReadOnly = true
        Me.txtVehPlaca.Size = New System.Drawing.Size(96, 23)
        Me.txtVehPlaca.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = true
        Me.Label13.Location = New System.Drawing.Point(9, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 15)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Placa :"
        '
        'txtVehCodigo
        '
        Me.txtVehCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.txtVehCodigo.Location = New System.Drawing.Point(98, 14)
        Me.txtVehCodigo.Name = "txtVehCodigo"
        Me.txtVehCodigo.ReadOnly = true
        Me.txtVehCodigo.Size = New System.Drawing.Size(96, 23)
        Me.txtVehCodigo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(9, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Codigo :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.dtpConFecNacimiento)
        Me.GroupBox3.Controls.Add(Me.txtConLicencia)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtConNombre)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 177)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(428, 77)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Conductor"
        '
        'dtpConFecNacimiento
        '
        Me.dtpConFecNacimiento.Enabled = false
        Me.dtpConFecNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpConFecNacimiento.Location = New System.Drawing.Point(320, 46)
        Me.dtpConFecNacimiento.Name = "dtpConFecNacimiento"
        Me.dtpConFecNacimiento.Size = New System.Drawing.Size(101, 23)
        Me.dtpConFecNacimiento.TabIndex = 5
        '
        'txtConLicencia
        '
        Me.txtConLicencia.Location = New System.Drawing.Point(68, 46)
        Me.txtConLicencia.Name = "txtConLicencia"
        Me.txtConLicencia.ReadOnly = true
        Me.txtConLicencia.Size = New System.Drawing.Size(143, 23)
        Me.txtConLicencia.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = true
        Me.Label23.Location = New System.Drawing.Point(7, 50)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 15)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Licencia :"
        '
        'Label24
        '
        Me.Label24.AutoSize = true
        Me.Label24.Location = New System.Drawing.Point(218, 50)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(99, 15)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Fec. Nacimiento :"
        '
        'txtConNombre
        '
        Me.txtConNombre.Location = New System.Drawing.Point(70, 17)
        Me.txtConNombre.Name = "txtConNombre"
        Me.txtConNombre.ReadOnly = true
        Me.txtConNombre.Size = New System.Drawing.Size(351, 23)
        Me.txtConNombre.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.AutoSize = true
        Me.Label26.Location = New System.Drawing.Point(7, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(62, 15)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Nombres :"
        '
        'tpgConsCombustible
        '
        Me.tpgConsCombustible.Controls.Add(Me.pnlConsCombustible)
        Me.tpgConsCombustible.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgConsCombustible.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgConsCombustible.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgConsCombustible.Location = New System.Drawing.Point(1, 24)
        Me.tpgConsCombustible.Name = "tpgConsCombustible"
        Me.tpgConsCombustible.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgConsCombustible.Selected = false
        Me.tpgConsCombustible.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgConsCombustible.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgConsCombustible.Size = New System.Drawing.Size(1412, 431)
        Me.tpgConsCombustible.TabIndex = 7
        Me.tpgConsCombustible.Title = "Consumo de Combustible"
        Me.tpgConsCombustible.ToolTip = "Consumo de Combustible"
        '
        'pnlConsCombustible
        '
        Me.pnlConsCombustible.Controls.Add(Me.c1grdConsCombustible)
        Me.pnlConsCombustible.Controls.Add(Me.bnavConsCombustible)
        Me.pnlConsCombustible.Controls.Add(Me.AcPanelCaption4)
        Me.pnlConsCombustible.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlConsCombustible.Location = New System.Drawing.Point(0, 0)
        Me.pnlConsCombustible.Name = "pnlConsCombustible"
        Me.pnlConsCombustible.Size = New System.Drawing.Size(1412, 431)
        Me.pnlConsCombustible.TabIndex = 36
        '
        'c1grdConsCombustible
        '
        Me.c1grdConsCombustible.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdConsCombustible.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdConsCombustible.Location = New System.Drawing.Point(0, 20)
        Me.c1grdConsCombustible.Name = "c1grdConsCombustible"
        Me.c1grdConsCombustible.Rows.Count = 2
        Me.c1grdConsCombustible.Rows.DefaultSize = 20
        Me.c1grdConsCombustible.Size = New System.Drawing.Size(1412, 411)
        Me.c1grdConsCombustible.StyleInfo = resources.GetString("c1grdConsCombustible.StyleInfo")
        Me.c1grdConsCombustible.TabIndex = 15
        '
        'bnavConsCombustible
        '
        Me.bnavConsCombustible.AddNewItem = Nothing
        Me.bnavConsCombustible.CountItem = Me.ToolStripLabel4
        Me.bnavConsCombustible.DeleteItem = Nothing
        Me.bnavConsCombustible.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton17, Me.ToolStripButton18, Me.ToolStripSeparator10, Me.ToolStripTextBox4, Me.ToolStripLabel4, Me.ToolStripSeparator11, Me.ToolStripButton19, Me.ToolStripButton20, Me.ToolStripSeparator12, Me.tsbtnCCAgregar, Me.tsbtnCCQuitar, Me.ToolStripSeparator30, Me.tsbtnCModificar, Me.ToolStripSeparator34, Me.tsbtnCCModFecha})
        Me.bnavConsCombustible.Location = New System.Drawing.Point(0, 20)
        Me.bnavConsCombustible.MoveFirstItem = Me.ToolStripButton17
        Me.bnavConsCombustible.MoveLastItem = Me.ToolStripButton20
        Me.bnavConsCombustible.MoveNextItem = Me.ToolStripButton19
        Me.bnavConsCombustible.MovePreviousItem = Me.ToolStripButton18
        Me.bnavConsCombustible.Name = "bnavConsCombustible"
        Me.bnavConsCombustible.PositionItem = Me.ToolStripTextBox4
        Me.bnavConsCombustible.Size = New System.Drawing.Size(1412, 25)
        Me.bnavConsCombustible.TabIndex = 16
        Me.bnavConsCombustible.Text = "bnavFletes"
        Me.bnavConsCombustible.Visible = false
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel4.Text = "de {0}"
        Me.ToolStripLabel4.ToolTipText = "Total number of items"
        '
        'ToolStripButton17
        '
        Me.ToolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton17.Image = CType(resources.GetObject("ToolStripButton17.Image"),System.Drawing.Image)
        Me.ToolStripButton17.Name = "ToolStripButton17"
        Me.ToolStripButton17.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton17.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton17.Text = "Move first"
        '
        'ToolStripButton18
        '
        Me.ToolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton18.Image = CType(resources.GetObject("ToolStripButton18.Image"),System.Drawing.Image)
        Me.ToolStripButton18.Name = "ToolStripButton18"
        Me.ToolStripButton18.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton18.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton18.Text = "Move previous"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox4
        '
        Me.ToolStripTextBox4.AccessibleName = "Position"
        Me.ToolStripTextBox4.AutoSize = false
        Me.ToolStripTextBox4.Name = "ToolStripTextBox4"
        Me.ToolStripTextBox4.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox4.Text = "0"
        Me.ToolStripTextBox4.ToolTipText = "Current position"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton19
        '
        Me.ToolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton19.Image = CType(resources.GetObject("ToolStripButton19.Image"),System.Drawing.Image)
        Me.ToolStripButton19.Name = "ToolStripButton19"
        Me.ToolStripButton19.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton19.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton19.Text = "Move next"
        '
        'ToolStripButton20
        '
        Me.ToolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton20.Image = CType(resources.GetObject("ToolStripButton20.Image"),System.Drawing.Image)
        Me.ToolStripButton20.Name = "ToolStripButton20"
        Me.ToolStripButton20.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton20.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton20.Text = "Move last"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnCCAgregar
        '
        Me.tsbtnCCAgregar.Image = CType(resources.GetObject("tsbtnCCAgregar.Image"),System.Drawing.Image)
        Me.tsbtnCCAgregar.Name = "tsbtnCCAgregar"
        Me.tsbtnCCAgregar.RightToLeftAutoMirrorImage = true
        Me.tsbtnCCAgregar.Size = New System.Drawing.Size(124, 22)
        Me.tsbtnCCAgregar.Text = "&Agregar Consumo"
        '
        'tsbtnCCQuitar
        '
        Me.tsbtnCCQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnCCQuitar.Image = CType(resources.GetObject("tsbtnCCQuitar.Image"),System.Drawing.Image)
        Me.tsbtnCCQuitar.Name = "tsbtnCCQuitar"
        Me.tsbtnCCQuitar.RightToLeftAutoMirrorImage = true
        Me.tsbtnCCQuitar.Size = New System.Drawing.Size(115, 22)
        Me.tsbtnCCQuitar.Text = "&Quitar Consumo"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator30.Visible = false
        '
        'tsbtnCModificar
        '
        Me.tsbtnCModificar.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.tsbtnCModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnCModificar.Name = "tsbtnCModificar"
        Me.tsbtnCModificar.Size = New System.Drawing.Size(133, 22)
        Me.tsbtnCModificar.Text = "Modificar Consumo"
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator34.Visible = false
        '
        'tsbtnCCModFecha
        '
        Me.tsbtnCCModFecha.Image = Global.ACPTransportes.My.Resources.Resources.Mostrar_16x16
        Me.tsbtnCCModFecha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnCCModFecha.Name = "tsbtnCCModFecha"
        Me.tsbtnCCModFecha.Size = New System.Drawing.Size(112, 22)
        Me.tsbtnCCModFecha.Text = "Modificar Fecha"
        Me.tsbtnCCModFecha.Visible = false
        '
        'AcPanelCaption4
        '
        Me.AcPanelCaption4.ACCaption = "Consumo de Combustible"
        Me.AcPanelCaption4.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption4.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption4.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption4.Name = "AcPanelCaption4"
        Me.AcPanelCaption4.Size = New System.Drawing.Size(1412, 20)
        Me.AcPanelCaption4.TabIndex = 13
        '
        'tpgConsumoAdBlue
        '
        Me.tpgConsumoAdBlue.Controls.Add(Me.pnlConsumoAdBlue)
        Me.tpgConsumoAdBlue.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgConsumoAdBlue.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgConsumoAdBlue.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgConsumoAdBlue.Location = New System.Drawing.Point(1, 24)
        Me.tpgConsumoAdBlue.Name = "tpgConsumoAdBlue"
        Me.tpgConsumoAdBlue.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgConsumoAdBlue.Selected = false
        Me.tpgConsumoAdBlue.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgConsumoAdBlue.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgConsumoAdBlue.Size = New System.Drawing.Size(1412, 431)
        Me.tpgConsumoAdBlue.TabIndex = 12
        Me.tpgConsumoAdBlue.Title = "Consumo de AdBlue"
        Me.tpgConsumoAdBlue.ToolTip = "Consumo de AdBlue"
        '
        'pnlConsumoAdBlue
        '
        Me.pnlConsumoAdBlue.Controls.Add(Me.c1grdConsumoAdBlue)
        Me.pnlConsumoAdBlue.Controls.Add(Me.bnavConsumoAdBlue)
        Me.pnlConsumoAdBlue.Controls.Add(Me.AcPanelCaption12)
        Me.pnlConsumoAdBlue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlConsumoAdBlue.Location = New System.Drawing.Point(0, 0)
        Me.pnlConsumoAdBlue.Name = "pnlConsumoAdBlue"
        Me.pnlConsumoAdBlue.Size = New System.Drawing.Size(1412, 431)
        Me.pnlConsumoAdBlue.TabIndex = 37
        '
        'c1grdConsumoAdBlue
        '
        Me.c1grdConsumoAdBlue.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdConsumoAdBlue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdConsumoAdBlue.Location = New System.Drawing.Point(0, 20)
        Me.c1grdConsumoAdBlue.Name = "c1grdConsumoAdBlue"
        Me.c1grdConsumoAdBlue.Rows.Count = 2
        Me.c1grdConsumoAdBlue.Rows.DefaultSize = 20
        Me.c1grdConsumoAdBlue.Size = New System.Drawing.Size(1412, 411)
        Me.c1grdConsumoAdBlue.StyleInfo = resources.GetString("c1grdConsumoAdBlue.StyleInfo")
        Me.c1grdConsumoAdBlue.TabIndex = 22
        '
        'bnavConsumoAdBlue
        '
        Me.bnavConsumoAdBlue.AddNewItem = Nothing
        Me.bnavConsumoAdBlue.CountItem = Me.ToolStripLabel14
        Me.bnavConsumoAdBlue.DeleteItem = Nothing
        Me.bnavConsumoAdBlue.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton29, Me.ToolStripButton34, Me.ToolStripSeparator16, Me.ToolStripTextBox12, Me.ToolStripLabel14, Me.ToolStripSeparator39, Me.ToolStripButton41, Me.ToolStripButton42, Me.ToolStripSeparator40, Me.tsbtnCABAgregar, Me.ToolStripSeparator48, Me.tsbtnCABModificar, Me.ToolStripSeparator51, Me.ToolStripButton48, Me.tsbtnCABQuitar, Me.ToolStripLabel15})
        Me.bnavConsumoAdBlue.Location = New System.Drawing.Point(0, 20)
        Me.bnavConsumoAdBlue.MoveFirstItem = Me.ToolStripButton29
        Me.bnavConsumoAdBlue.MoveLastItem = Me.ToolStripButton42
        Me.bnavConsumoAdBlue.MoveNextItem = Me.ToolStripButton41
        Me.bnavConsumoAdBlue.MovePreviousItem = Me.ToolStripButton34
        Me.bnavConsumoAdBlue.Name = "bnavConsumoAdBlue"
        Me.bnavConsumoAdBlue.PositionItem = Me.ToolStripTextBox12
        Me.bnavConsumoAdBlue.Size = New System.Drawing.Size(1273, 25)
        Me.bnavConsumoAdBlue.TabIndex = 17
        Me.bnavConsumoAdBlue.Text = "bnavFletes"
        Me.bnavConsumoAdBlue.Visible = false
        '
        'ToolStripLabel14
        '
        Me.ToolStripLabel14.Name = "ToolStripLabel14"
        Me.ToolStripLabel14.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel14.Text = "de {0}"
        Me.ToolStripLabel14.ToolTipText = "Total number of items"
        '
        'ToolStripButton29
        '
        Me.ToolStripButton29.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton29.Image = CType(resources.GetObject("ToolStripButton29.Image"),System.Drawing.Image)
        Me.ToolStripButton29.Name = "ToolStripButton29"
        Me.ToolStripButton29.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton29.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton29.Text = "Move first"
        '
        'ToolStripButton34
        '
        Me.ToolStripButton34.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton34.Image = CType(resources.GetObject("ToolStripButton34.Image"),System.Drawing.Image)
        Me.ToolStripButton34.Name = "ToolStripButton34"
        Me.ToolStripButton34.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton34.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton34.Text = "Move previous"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox12
        '
        Me.ToolStripTextBox12.AccessibleName = "Position"
        Me.ToolStripTextBox12.AutoSize = false
        Me.ToolStripTextBox12.Name = "ToolStripTextBox12"
        Me.ToolStripTextBox12.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox12.Text = "0"
        Me.ToolStripTextBox12.ToolTipText = "Current position"
        '
        'ToolStripSeparator39
        '
        Me.ToolStripSeparator39.Name = "ToolStripSeparator39"
        Me.ToolStripSeparator39.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton41
        '
        Me.ToolStripButton41.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton41.Image = CType(resources.GetObject("ToolStripButton41.Image"),System.Drawing.Image)
        Me.ToolStripButton41.Name = "ToolStripButton41"
        Me.ToolStripButton41.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton41.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton41.Text = "Move next"
        '
        'ToolStripButton42
        '
        Me.ToolStripButton42.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton42.Image = CType(resources.GetObject("ToolStripButton42.Image"),System.Drawing.Image)
        Me.ToolStripButton42.Name = "ToolStripButton42"
        Me.ToolStripButton42.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton42.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton42.Text = "Move last"
        '
        'ToolStripSeparator40
        '
        Me.ToolStripSeparator40.Name = "ToolStripSeparator40"
        Me.ToolStripSeparator40.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnCABAgregar
        '
        Me.tsbtnCABAgregar.Image = CType(resources.GetObject("tsbtnCABAgregar.Image"),System.Drawing.Image)
        Me.tsbtnCABAgregar.Name = "tsbtnCABAgregar"
        Me.tsbtnCABAgregar.RightToLeftAutoMirrorImage = true
        Me.tsbtnCABAgregar.Size = New System.Drawing.Size(165, 22)
        Me.tsbtnCABAgregar.Text = "&Agregar Consumo AdBlue"
        '
        'ToolStripSeparator48
        '
        Me.ToolStripSeparator48.Name = "ToolStripSeparator48"
        Me.ToolStripSeparator48.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator48.Visible = false
        '
        'tsbtnCABModificar
        '
        Me.tsbtnCABModificar.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.tsbtnCABModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnCABModificar.Name = "tsbtnCABModificar"
        Me.tsbtnCABModificar.Size = New System.Drawing.Size(133, 22)
        Me.tsbtnCABModificar.Text = "Modificar Consumo"
        '
        'ToolStripSeparator51
        '
        Me.ToolStripSeparator51.Name = "ToolStripSeparator51"
        Me.ToolStripSeparator51.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator51.Visible = false
        '
        'ToolStripButton48
        '
        Me.ToolStripButton48.Image = Global.ACPTransportes.My.Resources.Resources.Mostrar_16x16
        Me.ToolStripButton48.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton48.Name = "ToolStripButton48"
        Me.ToolStripButton48.Size = New System.Drawing.Size(112, 22)
        Me.ToolStripButton48.Text = "Modificar Fecha"
        Me.ToolStripButton48.Visible = false
        '
        'tsbtnCABQuitar
        '
        Me.tsbtnCABQuitar.Image = CType(resources.GetObject("tsbtnCABQuitar.Image"),System.Drawing.Image)
        Me.tsbtnCABQuitar.Name = "tsbtnCABQuitar"
        Me.tsbtnCABQuitar.RightToLeftAutoMirrorImage = true
        Me.tsbtnCABQuitar.Size = New System.Drawing.Size(115, 22)
        Me.tsbtnCABQuitar.Text = "&Quitar Consumo"
        '
        'ToolStripLabel15
        '
        Me.ToolStripLabel15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel15.Name = "ToolStripLabel15"
        Me.ToolStripLabel15.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripLabel15.Text = "Eliminar Consumo"
        Me.ToolStripLabel15.Visible = false
        '
        'AcPanelCaption12
        '
        Me.AcPanelCaption12.ACCaption = "Consumo de AdBlue"
        Me.AcPanelCaption12.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption12.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption12.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption12.Name = "AcPanelCaption12"
        Me.AcPanelCaption12.Size = New System.Drawing.Size(1412, 20)
        Me.AcPanelCaption12.TabIndex = 14
        '
        'tpgGastos
        '
        Me.tpgGastos.Controls.Add(Me.pnlGastos)
        Me.tpgGastos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgGastos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgGastos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgGastos.Location = New System.Drawing.Point(1, 24)
        Me.tpgGastos.Name = "tpgGastos"
        Me.tpgGastos.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgGastos.Selected = false
        Me.tpgGastos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgGastos.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgGastos.Size = New System.Drawing.Size(1412, 431)
        Me.tpgGastos.TabIndex = 8
        Me.tpgGastos.Title = "Gastos del Viaje"
        Me.tpgGastos.ToolTip = "Gastos del Viaje"
        '
        'pnlGastos
        '
        Me.pnlGastos.Controls.Add(Me.c1grdGastViajes)
        Me.pnlGastos.Controls.Add(Me.bnavGastos)
        Me.pnlGastos.Controls.Add(Me.AcPanelCaption5)
        Me.pnlGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGastos.Location = New System.Drawing.Point(0, 0)
        Me.pnlGastos.Name = "pnlGastos"
        Me.pnlGastos.Size = New System.Drawing.Size(1412, 431)
        Me.pnlGastos.TabIndex = 37
        '
        'c1grdGastViajes
        '
        Me.c1grdGastViajes.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdGastViajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdGastViajes.Location = New System.Drawing.Point(0, 20)
        Me.c1grdGastViajes.Name = "c1grdGastViajes"
        Me.c1grdGastViajes.Rows.Count = 2
        Me.c1grdGastViajes.Rows.DefaultSize = 20
        Me.c1grdGastViajes.Size = New System.Drawing.Size(1412, 411)
        Me.c1grdGastViajes.StyleInfo = resources.GetString("c1grdGastViajes.StyleInfo")
        Me.c1grdGastViajes.TabIndex = 15
        '
        'bnavGastos
        '
        Me.bnavGastos.AddNewItem = Nothing
        Me.bnavGastos.CountItem = Me.ToolStripLabel5
        Me.bnavGastos.DeleteItem = Nothing
        Me.bnavGastos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton23, Me.ToolStripButton24, Me.ToolStripSeparator13, Me.ToolStripTextBox5, Me.ToolStripLabel5, Me.ToolStripSeparator14, Me.ToolStripButton25, Me.ToolStripButton26, Me.ToolStripSeparator15, Me.tsbtnGVAgregar, Me.tsbtnGVQuitar, Me.ToolStripSeparator37, Me.tsbtnGVModificar, Me.ToolStripSeparator38})
        Me.bnavGastos.Location = New System.Drawing.Point(0, 20)
        Me.bnavGastos.MoveFirstItem = Me.ToolStripButton23
        Me.bnavGastos.MoveLastItem = Me.ToolStripButton26
        Me.bnavGastos.MoveNextItem = Me.ToolStripButton25
        Me.bnavGastos.MovePreviousItem = Me.ToolStripButton24
        Me.bnavGastos.Name = "bnavGastos"
        Me.bnavGastos.PositionItem = Me.ToolStripTextBox5
        Me.bnavGastos.Size = New System.Drawing.Size(1273, 25)
        Me.bnavGastos.TabIndex = 16
        Me.bnavGastos.Text = "bnavFletes"
        Me.bnavGastos.Visible = false
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel5.Text = "de {0}"
        Me.ToolStripLabel5.ToolTipText = "Total number of items"
        '
        'ToolStripButton23
        '
        Me.ToolStripButton23.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton23.Image = CType(resources.GetObject("ToolStripButton23.Image"),System.Drawing.Image)
        Me.ToolStripButton23.Name = "ToolStripButton23"
        Me.ToolStripButton23.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton23.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton23.Text = "Move first"
        '
        'ToolStripButton24
        '
        Me.ToolStripButton24.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton24.Image = CType(resources.GetObject("ToolStripButton24.Image"),System.Drawing.Image)
        Me.ToolStripButton24.Name = "ToolStripButton24"
        Me.ToolStripButton24.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton24.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton24.Text = "Move previous"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox5
        '
        Me.ToolStripTextBox5.AccessibleName = "Position"
        Me.ToolStripTextBox5.AutoSize = false
        Me.ToolStripTextBox5.Name = "ToolStripTextBox5"
        Me.ToolStripTextBox5.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox5.Text = "0"
        Me.ToolStripTextBox5.ToolTipText = "Current position"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton25
        '
        Me.ToolStripButton25.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton25.Image = CType(resources.GetObject("ToolStripButton25.Image"),System.Drawing.Image)
        Me.ToolStripButton25.Name = "ToolStripButton25"
        Me.ToolStripButton25.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton25.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton25.Text = "Move next"
        '
        'ToolStripButton26
        '
        Me.ToolStripButton26.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton26.Image = CType(resources.GetObject("ToolStripButton26.Image"),System.Drawing.Image)
        Me.ToolStripButton26.Name = "ToolStripButton26"
        Me.ToolStripButton26.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton26.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton26.Text = "Move last"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnGVAgregar
        '
        Me.tsbtnGVAgregar.Image = CType(resources.GetObject("tsbtnGVAgregar.Image"),System.Drawing.Image)
        Me.tsbtnGVAgregar.Name = "tsbtnGVAgregar"
        Me.tsbtnGVAgregar.RightToLeftAutoMirrorImage = true
        Me.tsbtnGVAgregar.Size = New System.Drawing.Size(107, 22)
        Me.tsbtnGVAgregar.Text = "&Agregar Gastos"
        '
        'tsbtnGVQuitar
        '
        Me.tsbtnGVQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnGVQuitar.Image = CType(resources.GetObject("tsbtnGVQuitar.Image"),System.Drawing.Image)
        Me.tsbtnGVQuitar.Name = "tsbtnGVQuitar"
        Me.tsbtnGVQuitar.RightToLeftAutoMirrorImage = true
        Me.tsbtnGVQuitar.Size = New System.Drawing.Size(93, 22)
        Me.tsbtnGVQuitar.Text = "&Quitar Gasto"
        '
        'ToolStripSeparator37
        '
        Me.ToolStripSeparator37.Name = "ToolStripSeparator37"
        Me.ToolStripSeparator37.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnGVModificar
        '
        Me.tsbtnGVModificar.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.tsbtnGVModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGVModificar.Name = "tsbtnGVModificar"
        Me.tsbtnGVModificar.Size = New System.Drawing.Size(78, 22)
        Me.tsbtnGVModificar.Text = "Modificar"
        '
        'ToolStripSeparator38
        '
        Me.ToolStripSeparator38.Name = "ToolStripSeparator38"
        Me.ToolStripSeparator38.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption5
        '
        Me.AcPanelCaption5.ACCaption = "Gastos de Viaje"
        Me.AcPanelCaption5.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption5.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption5.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption5.Name = "AcPanelCaption5"
        Me.AcPanelCaption5.Size = New System.Drawing.Size(1412, 20)
        Me.AcPanelCaption5.TabIndex = 13
        '
        'tpgFletes
        '
        Me.tpgFletes.Controls.Add(Me.pnlFletes)
        Me.tpgFletes.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgFletes.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgFletes.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgFletes.Location = New System.Drawing.Point(1, 24)
        Me.tpgFletes.Name = "tpgFletes"
        Me.tpgFletes.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgFletes.Selected = false
        Me.tpgFletes.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgFletes.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgFletes.Size = New System.Drawing.Size(1412, 431)
        Me.tpgFletes.TabIndex = 4
        Me.tpgFletes.Title = "Fletes de Transporte"
        Me.tpgFletes.ToolTip = "Fletes de Transporte"
        '
        'pnlFletes
        '
        Me.pnlFletes.Controls.Add(Me.SplitContainer3)
        Me.pnlFletes.Controls.Add(Me.bnavFletes)
        Me.pnlFletes.Controls.Add(Me.AcPanelCaption2)
        Me.pnlFletes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFletes.Location = New System.Drawing.Point(0, 0)
        Me.pnlFletes.Name = "pnlFletes"
        Me.pnlFletes.Size = New System.Drawing.Size(1412, 431)
        Me.pnlFletes.TabIndex = 35
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 20)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.c1grdFletes)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.txtFleObs)
        Me.SplitContainer3.Panel2.Controls.Add(Me.ToolStrip3)
        Me.SplitContainer3.Panel2.Controls.Add(Me.AcPanelCaption11)
        Me.SplitContainer3.Size = New System.Drawing.Size(1412, 411)
        Me.SplitContainer3.SplitterDistance = 1071
        Me.SplitContainer3.TabIndex = 17
        '
        'c1grdFletes
        '
        Me.c1grdFletes.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdFletes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdFletes.Location = New System.Drawing.Point(0, 0)
        Me.c1grdFletes.Name = "c1grdFletes"
        Me.c1grdFletes.Rows.Count = 2
        Me.c1grdFletes.Rows.DefaultSize = 20
        Me.c1grdFletes.Size = New System.Drawing.Size(1071, 411)
        Me.c1grdFletes.StyleInfo = resources.GetString("c1grdFletes.StyleInfo")
        Me.c1grdFletes.TabIndex = 15
        '
        'txtFleObs
        '
        Me.txtFleObs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFleObs.Location = New System.Drawing.Point(0, 20)
        Me.txtFleObs.Multiline = true
        Me.txtFleObs.Name = "txtFleObs"
        Me.txtFleObs.Size = New System.Drawing.Size(337, 366)
        Me.txtFleObs.TabIndex = 0
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnFleGrabar})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 386)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(337, 25)
        Me.ToolStrip3.TabIndex = 15
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'tsbtnFleGrabar
        '
        Me.tsbtnFleGrabar.Image = Global.ACPTransportes.My.Resources.Resources.ACGrabar_16x16
        Me.tsbtnFleGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnFleGrabar.Name = "tsbtnFleGrabar"
        Me.tsbtnFleGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbtnFleGrabar.Text = "Grabar"
        '
        'AcPanelCaption11
        '
        Me.AcPanelCaption11.ACCaption = "Observacion del Flete"
        Me.AcPanelCaption11.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption11.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption11.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption11.Name = "AcPanelCaption11"
        Me.AcPanelCaption11.Size = New System.Drawing.Size(337, 20)
        Me.AcPanelCaption11.TabIndex = 14
        '
        'bnavFletes
        '
        Me.bnavFletes.AddNewItem = Nothing
        Me.bnavFletes.CountItem = Me.ToolStripLabel2
        Me.bnavFletes.DeleteItem = Nothing
        Me.bnavFletes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton9, Me.ToolStripButton10, Me.ToolStripSeparator4, Me.ToolStripTextBox2, Me.ToolStripLabel2, Me.ToolStripSeparator5, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator6, Me.tsbtnAddNewFlete, Me.tsbtnFQuitar, Me.ToolStripSeparator43, Me.tsbtnAgregarFlete, Me.ToolStripSeparator49, Me.tsbtnModFlete, Me.ToolStripSeparator50})
        Me.bnavFletes.Location = New System.Drawing.Point(0, 20)
        Me.bnavFletes.MoveFirstItem = Me.ToolStripButton9
        Me.bnavFletes.MoveLastItem = Me.ToolStripButton12
        Me.bnavFletes.MoveNextItem = Me.ToolStripButton11
        Me.bnavFletes.MovePreviousItem = Me.ToolStripButton10
        Me.bnavFletes.Name = "bnavFletes"
        Me.bnavFletes.PositionItem = Me.ToolStripTextBox2
        Me.bnavFletes.Size = New System.Drawing.Size(1273, 25)
        Me.bnavFletes.TabIndex = 16
        Me.bnavFletes.Text = "bnavFletes"
        Me.bnavFletes.Visible = false
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel2.Text = "de {0}"
        Me.ToolStripLabel2.ToolTipText = "Total number of items"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"),System.Drawing.Image)
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton9.Text = "Move first"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"),System.Drawing.Image)
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton10.Text = "Move previous"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.AccessibleName = "Position"
        Me.ToolStripTextBox2.AutoSize = false
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox2.Text = "0"
        Me.ToolStripTextBox2.ToolTipText = "Current position"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"),System.Drawing.Image)
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton11.Text = "Move next"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"),System.Drawing.Image)
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton12.Text = "Move last"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnAddNewFlete
        '
        Me.tsbtnAddNewFlete.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.tsbtnAddNewFlete.Name = "tsbtnAddNewFlete"
        Me.tsbtnAddNewFlete.RightToLeftAutoMirrorImage = true
        Me.tsbtnAddNewFlete.Size = New System.Drawing.Size(60, 22)
        Me.tsbtnAddNewFlete.Text = "Orden"
        Me.tsbtnAddNewFlete.Visible = false
        '
        'tsbtnFQuitar
        '
        Me.tsbtnFQuitar.Image = CType(resources.GetObject("tsbtnFQuitar.Image"),System.Drawing.Image)
        Me.tsbtnFQuitar.Name = "tsbtnFQuitar"
        Me.tsbtnFQuitar.RightToLeftAutoMirrorImage = true
        Me.tsbtnFQuitar.Size = New System.Drawing.Size(88, 22)
        Me.tsbtnFQuitar.Text = "&Quitar Flete"
        '
        'ToolStripSeparator43
        '
        Me.ToolStripSeparator43.Name = "ToolStripSeparator43"
        Me.ToolStripSeparator43.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator43.Visible = false
        '
        'tsbtnAgregarFlete
        '
        Me.tsbtnAgregarFlete.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.tsbtnAgregarFlete.Name = "tsbtnAgregarFlete"
        Me.tsbtnAgregarFlete.RightToLeftAutoMirrorImage = true
        Me.tsbtnAgregarFlete.Size = New System.Drawing.Size(97, 22)
        Me.tsbtnAgregarFlete.Text = "&Agregar Flete"
        '
        'ToolStripSeparator49
        '
        Me.ToolStripSeparator49.Name = "ToolStripSeparator49"
        Me.ToolStripSeparator49.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnModFlete
        '
        Me.tsbtnModFlete.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.tsbtnModFlete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnModFlete.Name = "tsbtnModFlete"
        Me.tsbtnModFlete.Size = New System.Drawing.Size(106, 22)
        Me.tsbtnModFlete.Text = "Modificar Flete"
        '
        'ToolStripSeparator50
        '
        Me.ToolStripSeparator50.Name = "ToolStripSeparator50"
        Me.ToolStripSeparator50.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption2
        '
        Me.AcPanelCaption2.ACCaption = "Ordenes de Transporte / Fletes"
        Me.AcPanelCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption2.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption2.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption2.Name = "AcPanelCaption2"
        Me.AcPanelCaption2.Size = New System.Drawing.Size(1412, 20)
        Me.AcPanelCaption2.TabIndex = 13
        '
        'tpgPresupuesto
        '
        Me.tpgPresupuesto.Controls.Add(Me.pnlIngEgre)
        Me.tpgPresupuesto.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgPresupuesto.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgPresupuesto.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgPresupuesto.Location = New System.Drawing.Point(1, 24)
        Me.tpgPresupuesto.Name = "tpgPresupuesto"
        Me.tpgPresupuesto.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgPresupuesto.Selected = false
        Me.tpgPresupuesto.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgPresupuesto.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgPresupuesto.Size = New System.Drawing.Size(1412, 431)
        Me.tpgPresupuesto.TabIndex = 5
        Me.tpgPresupuesto.Title = "Recibos de Ingresos / Egresos"
        Me.tpgPresupuesto.ToolTip = "Presupuesto de Viaje"
        '
        'pnlIngEgre
        '
        Me.pnlIngEgre.Controls.Add(Me.SplitContainer2)
        Me.pnlIngEgre.Controls.Add(Me.AcPanelCaption10)
        Me.pnlIngEgre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlIngEgre.Location = New System.Drawing.Point(0, 0)
        Me.pnlIngEgre.Name = "pnlIngEgre"
        Me.pnlIngEgre.Size = New System.Drawing.Size(1412, 431)
        Me.pnlIngEgre.TabIndex = 37
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 20)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.c1grdIngEgre)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ToolStrip4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.bnavIngEgre)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.c1grdRecEmitir)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ToolStrip5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.bnavRecEmitir)
        Me.SplitContainer2.Size = New System.Drawing.Size(1412, 411)
        Me.SplitContainer2.SplitterDistance = 671
        Me.SplitContainer2.TabIndex = 17
        '
        'c1grdIngEgre
        '
        Me.c1grdIngEgre.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdIngEgre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdIngEgre.Location = New System.Drawing.Point(0, 25)
        Me.c1grdIngEgre.Name = "c1grdIngEgre"
        Me.c1grdIngEgre.Rows.Count = 2
        Me.c1grdIngEgre.Rows.DefaultSize = 20
        Me.c1grdIngEgre.Size = New System.Drawing.Size(671, 361)
        Me.c1grdIngEgre.StyleInfo = resources.GetString("c1grdIngEgre.StyleInfo")
        Me.c1grdIngEgre.TabIndex = 15
        '
        'ToolStrip4
        '
        Me.ToolStrip4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnImprimir, Me.ToolStripLabel12, Me.tscmbImpresora})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 386)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(671, 25)
        Me.ToolStrip4.TabIndex = 17
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'tsbtnImprimir
        '
        Me.tsbtnImprimir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnImprimir.Image = Global.ACPTransportes.My.Resources.Resources.ACImprimirRed_16x16
        Me.tsbtnImprimir.Name = "tsbtnImprimir"
        Me.tsbtnImprimir.RightToLeftAutoMirrorImage = true
        Me.tsbtnImprimir.Size = New System.Drawing.Size(112, 22)
        Me.tsbtnImprimir.Text = "Imprimir Recibo"
        '
        'ToolStripLabel12
        '
        Me.ToolStripLabel12.Name = "ToolStripLabel12"
        Me.ToolStripLabel12.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripLabel12.Text = "Impresora :"
        '
        'tscmbImpresora
        '
        Me.tscmbImpresora.DropDownWidth = 300
        Me.tscmbImpresora.Name = "tscmbImpresora"
        Me.tscmbImpresora.Size = New System.Drawing.Size(250, 25)
        '
        'bnavIngEgre
        '
        Me.bnavIngEgre.AddNewItem = Nothing
        Me.bnavIngEgre.CountItem = Me.ToolStripLabel11
        Me.bnavIngEgre.DeleteItem = Nothing
        Me.bnavIngEgre.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.bnavIngEgre.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton37, Me.ToolStripButton38, Me.ToolStripSeparator31, Me.ToolStripTextBox11, Me.ToolStripLabel11, Me.ToolStripSeparator32, Me.ToolStripButton39, Me.ToolStripButton40, Me.ToolStripSeparator33, Me.tsbtnRecAgregar, Me.ToolStripSeparator29, Me.tsbtnRecQuitar, Me.tsbtnRModificar})
        Me.bnavIngEgre.Location = New System.Drawing.Point(0, 0)
        Me.bnavIngEgre.MoveFirstItem = Me.ToolStripButton37
        Me.bnavIngEgre.MoveLastItem = Me.ToolStripButton40
        Me.bnavIngEgre.MoveNextItem = Me.ToolStripButton39
        Me.bnavIngEgre.MovePreviousItem = Me.ToolStripButton38
        Me.bnavIngEgre.Name = "bnavIngEgre"
        Me.bnavIngEgre.PositionItem = Me.ToolStripTextBox11
        Me.bnavIngEgre.Size = New System.Drawing.Size(671, 25)
        Me.bnavIngEgre.TabIndex = 16
        Me.bnavIngEgre.Text = "bnavFletes"
        '
        'ToolStripLabel11
        '
        Me.ToolStripLabel11.Name = "ToolStripLabel11"
        Me.ToolStripLabel11.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel11.Text = "de {0}"
        Me.ToolStripLabel11.ToolTipText = "Total number of items"
        '
        'ToolStripButton37
        '
        Me.ToolStripButton37.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton37.Image = CType(resources.GetObject("ToolStripButton37.Image"),System.Drawing.Image)
        Me.ToolStripButton37.Name = "ToolStripButton37"
        Me.ToolStripButton37.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton37.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton37.Text = "Move first"
        '
        'ToolStripButton38
        '
        Me.ToolStripButton38.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton38.Image = CType(resources.GetObject("ToolStripButton38.Image"),System.Drawing.Image)
        Me.ToolStripButton38.Name = "ToolStripButton38"
        Me.ToolStripButton38.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton38.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton38.Text = "Move previous"
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox11
        '
        Me.ToolStripTextBox11.AccessibleName = "Position"
        Me.ToolStripTextBox11.AutoSize = false
        Me.ToolStripTextBox11.Name = "ToolStripTextBox11"
        Me.ToolStripTextBox11.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox11.Text = "0"
        Me.ToolStripTextBox11.ToolTipText = "Current position"
        '
        'ToolStripSeparator32
        '
        Me.ToolStripSeparator32.Name = "ToolStripSeparator32"
        Me.ToolStripSeparator32.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton39
        '
        Me.ToolStripButton39.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton39.Image = CType(resources.GetObject("ToolStripButton39.Image"),System.Drawing.Image)
        Me.ToolStripButton39.Name = "ToolStripButton39"
        Me.ToolStripButton39.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton39.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton39.Text = "Move next"
        '
        'ToolStripButton40
        '
        Me.ToolStripButton40.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton40.Image = CType(resources.GetObject("ToolStripButton40.Image"),System.Drawing.Image)
        Me.ToolStripButton40.Name = "ToolStripButton40"
        Me.ToolStripButton40.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton40.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton40.Text = "Move last"
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnRecAgregar
        '
        Me.tsbtnRecAgregar.Image = CType(resources.GetObject("tsbtnRecAgregar.Image"),System.Drawing.Image)
        Me.tsbtnRecAgregar.Name = "tsbtnRecAgregar"
        Me.tsbtnRecAgregar.RightToLeftAutoMirrorImage = true
        Me.tsbtnRecAgregar.Size = New System.Drawing.Size(108, 22)
        Me.tsbtnRecAgregar.Text = "&Agregar Recibo"
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnRecQuitar
        '
        Me.tsbtnRecQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnRecQuitar.Image = CType(resources.GetObject("tsbtnRecQuitar.Image"),System.Drawing.Image)
        Me.tsbtnRecQuitar.Name = "tsbtnRecQuitar"
        Me.tsbtnRecQuitar.RightToLeftAutoMirrorImage = true
        Me.tsbtnRecQuitar.Size = New System.Drawing.Size(99, 22)
        Me.tsbtnRecQuitar.Text = "Q&uitar Recibo"
        '
        'tsbtnRModificar
        '
        Me.tsbtnRModificar.Image = Global.ACPTransportes.My.Resources.Resources.ACEdit_16x16
        Me.tsbtnRModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnRModificar.Name = "tsbtnRModificar"
        Me.tsbtnRModificar.Size = New System.Drawing.Size(78, 22)
        Me.tsbtnRModificar.Text = "Modificar"
        '
        'c1grdRecEmitir
        '
        Me.c1grdRecEmitir.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdRecEmitir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdRecEmitir.Location = New System.Drawing.Point(0, 0)
        Me.c1grdRecEmitir.Name = "c1grdRecEmitir"
        Me.c1grdRecEmitir.Rows.Count = 2
        Me.c1grdRecEmitir.Rows.DefaultSize = 20
        Me.c1grdRecEmitir.Size = New System.Drawing.Size(737, 386)
        Me.c1grdRecEmitir.StyleInfo = resources.GetString("c1grdRecEmitir.StyleInfo")
        Me.c1grdRecEmitir.TabIndex = 16
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnImprimirRec, Me.ToolStripLabel13, Me.tscmbImpresoraRec})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 386)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(737, 25)
        Me.ToolStrip5.TabIndex = 18
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'tsbtnImprimirRec
        '
        Me.tsbtnImprimirRec.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnImprimirRec.Image = Global.ACPTransportes.My.Resources.Resources.ACImprimirRed_16x16
        Me.tsbtnImprimirRec.Name = "tsbtnImprimirRec"
        Me.tsbtnImprimirRec.RightToLeftAutoMirrorImage = true
        Me.tsbtnImprimirRec.Size = New System.Drawing.Size(112, 22)
        Me.tsbtnImprimirRec.Text = "Imprimir Recibo"
        '
        'ToolStripLabel13
        '
        Me.ToolStripLabel13.Name = "ToolStripLabel13"
        Me.ToolStripLabel13.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripLabel13.Text = "Impresora :"
        '
        'tscmbImpresoraRec
        '
        Me.tscmbImpresoraRec.DropDownWidth = 300
        Me.tscmbImpresoraRec.Name = "tscmbImpresoraRec"
        Me.tscmbImpresoraRec.Size = New System.Drawing.Size(250, 25)
        '
        'bnavRecEmitir
        '
        Me.bnavRecEmitir.AddNewItem = Nothing
        Me.bnavRecEmitir.CountItem = Me.BindingNavigatorCountItem1
        Me.bnavRecEmitir.DeleteItem = Nothing
        Me.bnavRecEmitir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem1, Me.BindingNavigatorMovePreviousItem1, Me.BindingNavigatorSeparator3, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.BindingNavigatorSeparator4, Me.BindingNavigatorMoveNextItem1, Me.BindingNavigatorMoveLastItem1, Me.BindingNavigatorSeparator5})
        Me.bnavRecEmitir.Location = New System.Drawing.Point(0, 0)
        Me.bnavRecEmitir.MoveFirstItem = Me.BindingNavigatorMoveFirstItem1
        Me.bnavRecEmitir.MoveLastItem = Me.BindingNavigatorMoveLastItem1
        Me.bnavRecEmitir.MoveNextItem = Me.BindingNavigatorMoveNextItem1
        Me.bnavRecEmitir.MovePreviousItem = Me.BindingNavigatorMovePreviousItem1
        Me.bnavRecEmitir.Name = "bnavRecEmitir"
        Me.bnavRecEmitir.PositionItem = Me.BindingNavigatorPositionItem1
        Me.bnavRecEmitir.Size = New System.Drawing.Size(663, 25)
        Me.bnavRecEmitir.TabIndex = 17
        Me.bnavRecEmitir.Text = "BindingNavigator1"
        Me.bnavRecEmitir.Visible = false
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem1"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem1.Text = "de {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem1
        '
        Me.BindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem1.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem1.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem1.Name = "BindingNavigatorMoveFirstItem1"
        Me.BindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveFirstItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem1.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem1
        '
        Me.BindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem1.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem1.Image"),System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem1.Name = "BindingNavigatorMovePreviousItem1"
        Me.BindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMovePreviousItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem1.Text = "Move previous"
        '
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem1
        '
        Me.BindingNavigatorPositionItem1.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem1.AutoSize = false
        Me.BindingNavigatorPositionItem1.Name = "BindingNavigatorPositionItem1"
        Me.BindingNavigatorPositionItem1.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem1.Text = "0"
        Me.BindingNavigatorPositionItem1.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem1
        '
        Me.BindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem1.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem1.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem1.Name = "BindingNavigatorMoveNextItem1"
        Me.BindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveNextItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem1.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem1
        '
        Me.BindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem1.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem1.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem1.Name = "BindingNavigatorMoveLastItem1"
        Me.BindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveLastItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem1.Text = "Move last"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator5"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption10
        '
        Me.AcPanelCaption10.ACCaption = "Recibos de Ingreso/Egreso"
        Me.AcPanelCaption10.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption10.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption10.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption10.Name = "AcPanelCaption10"
        Me.AcPanelCaption10.Size = New System.Drawing.Size(1412, 20)
        Me.AcPanelCaption10.TabIndex = 13
        '
        'tpgNeumaticos
        '
        Me.tpgNeumaticos.Controls.Add(Me.pnlInvNeumaticos)
        Me.tpgNeumaticos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgNeumaticos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgNeumaticos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgNeumaticos.Location = New System.Drawing.Point(1, 24)
        Me.tpgNeumaticos.Name = "tpgNeumaticos"
        Me.tpgNeumaticos.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgNeumaticos.Selected = false
        Me.tpgNeumaticos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgNeumaticos.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgNeumaticos.Size = New System.Drawing.Size(1412, 431)
        Me.tpgNeumaticos.TabIndex = 10
        Me.tpgNeumaticos.Title = "Neumaticos"
        Me.tpgNeumaticos.ToolTip = "Neumaticos"
        '
        'pnlInvNeumaticos
        '
        Me.pnlInvNeumaticos.Controls.Add(Me.SplitContainer1)
        Me.pnlInvNeumaticos.Controls.Add(Me.AcPanelCaption7)
        Me.pnlInvNeumaticos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInvNeumaticos.Location = New System.Drawing.Point(0, 0)
        Me.pnlInvNeumaticos.Name = "pnlInvNeumaticos"
        Me.pnlInvNeumaticos.Size = New System.Drawing.Size(1412, 431)
        Me.pnlInvNeumaticos.TabIndex = 37
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 20)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlInciNeumatico)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(1412, 411)
        Me.SplitContainer1.SplitterDistance = 711
        Me.SplitContainer1.TabIndex = 19
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.c1grdInvNeumaticos)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.bnavNeumaticos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(711, 411)
        Me.Panel2.TabIndex = 20
        '
        'c1grdInvNeumaticos
        '
        Me.c1grdInvNeumaticos.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdInvNeumaticos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdInvNeumaticos.Location = New System.Drawing.Point(0, 0)
        Me.c1grdInvNeumaticos.Name = "c1grdInvNeumaticos"
        Me.c1grdInvNeumaticos.Rows.Count = 2
        Me.c1grdInvNeumaticos.Rows.DefaultSize = 20
        Me.c1grdInvNeumaticos.Size = New System.Drawing.Size(648, 411)
        Me.c1grdInvNeumaticos.StyleInfo = resources.GetString("c1grdInvNeumaticos.StyleInfo")
        Me.c1grdInvNeumaticos.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.acvRanfla)
        Me.Panel1.Controls.Add(Me.acvTracto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(648, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(63, 411)
        Me.Panel1.TabIndex = 26
        '
        'acvRanfla
        '
        Me.acvRanfla.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.acvRanfla.BackColor = System.Drawing.Color.Transparent
        Me.acvRanfla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.acvRanfla.ColorAll = System.Drawing.Color.Black
        Me.acvRanfla.ColorDefaultOne = System.Drawing.Color.Black
        Me.acvRanfla.ColorDefaultTwo = System.Drawing.Color.Red
        Me.acvRanfla.Location = New System.Drawing.Point(5, 196)
        Me.acvRanfla.MaximumSize = New System.Drawing.Size(52, 200)
        Me.acvRanfla.MinimumSize = New System.Drawing.Size(52, 100)
        Me.acvRanfla.Name = "acvRanfla"
        Me.acvRanfla.NeuDelDerExt1 = System.Drawing.Color.Black
        Me.acvRanfla.NeuDelIzqExt1 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosDerExt2 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosDerExt3 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosDerExt4 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosDerInt2 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosDerInt3 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosDerInt4 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosIzqExt2 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosIzqExt3 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosIzqExt4 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosIzqInt2 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosIzqInt3 = System.Drawing.Color.Black
        Me.acvRanfla.NeuPosIzqInt4 = System.Drawing.Color.Black
        Me.acvRanfla.Size = New System.Drawing.Size(52, 110)
        Me.acvRanfla.TabIndex = 23
        Me.acvRanfla.VisiblePanelPos1 = false
        Me.acvRanfla.VisiblePanelPos3 = false
        Me.acvRanfla.VisiblePanelPos4 = false
        '
        'acvTracto
        '
        Me.acvTracto.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.acvTracto.BackColor = System.Drawing.Color.Transparent
        Me.acvTracto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.acvTracto.ColorAll = System.Drawing.Color.Black
        Me.acvTracto.ColorDefaultOne = System.Drawing.Color.Black
        Me.acvTracto.ColorDefaultTwo = System.Drawing.Color.Red
        Me.acvTracto.Location = New System.Drawing.Point(5, 105)
        Me.acvTracto.MaximumSize = New System.Drawing.Size(52, 200)
        Me.acvTracto.MinimumSize = New System.Drawing.Size(52, 100)
        Me.acvTracto.Name = "acvTracto"
        Me.acvTracto.NeuDelDerExt1 = System.Drawing.Color.Black
        Me.acvTracto.NeuDelIzqExt1 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosDerExt2 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosDerExt3 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosDerExt4 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosDerInt2 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosDerInt3 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosDerInt4 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosIzqExt2 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosIzqExt3 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosIzqExt4 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosIzqInt2 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosIzqInt3 = System.Drawing.Color.Black
        Me.acvTracto.NeuPosIzqInt4 = System.Drawing.Color.Black
        Me.acvTracto.Size = New System.Drawing.Size(52, 110)
        Me.acvTracto.TabIndex = 24
        Me.acvTracto.VisiblePanelPos1 = false
        Me.acvTracto.VisiblePanelPos3 = false
        Me.acvTracto.VisiblePanelPos4 = false
        '
        'bnavNeumaticos
        '
        Me.bnavNeumaticos.AddNewItem = Nothing
        Me.bnavNeumaticos.CountItem = Me.ToolStripLabel8
        Me.bnavNeumaticos.DeleteItem = Nothing
        Me.bnavNeumaticos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavNeumaticos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton35, Me.ToolStripButton36, Me.ToolStripSeparator22, Me.ToolStripTextBox8, Me.ToolStripLabel8, Me.ToolStripSeparator23, Me.ToolStripButton43, Me.ToolStripButton44, Me.ToolStripSeparator24, Me.tsbtnAgregarIncNeumaticos})
        Me.bnavNeumaticos.Location = New System.Drawing.Point(0, 386)
        Me.bnavNeumaticos.MoveFirstItem = Me.ToolStripButton35
        Me.bnavNeumaticos.MoveLastItem = Me.ToolStripButton44
        Me.bnavNeumaticos.MoveNextItem = Me.ToolStripButton43
        Me.bnavNeumaticos.MovePreviousItem = Me.ToolStripButton36
        Me.bnavNeumaticos.Name = "bnavNeumaticos"
        Me.bnavNeumaticos.PositionItem = Me.ToolStripTextBox8
        Me.bnavNeumaticos.Size = New System.Drawing.Size(642, 25)
        Me.bnavNeumaticos.TabIndex = 16
        Me.bnavNeumaticos.Text = "bnavFletes"
        Me.bnavNeumaticos.Visible = false
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel8.Text = "de {0}"
        Me.ToolStripLabel8.ToolTipText = "Total number of items"
        '
        'ToolStripButton35
        '
        Me.ToolStripButton35.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton35.Image = CType(resources.GetObject("ToolStripButton35.Image"),System.Drawing.Image)
        Me.ToolStripButton35.Name = "ToolStripButton35"
        Me.ToolStripButton35.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton35.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton35.Text = "Move first"
        '
        'ToolStripButton36
        '
        Me.ToolStripButton36.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton36.Image = CType(resources.GetObject("ToolStripButton36.Image"),System.Drawing.Image)
        Me.ToolStripButton36.Name = "ToolStripButton36"
        Me.ToolStripButton36.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton36.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton36.Text = "Move previous"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox8
        '
        Me.ToolStripTextBox8.AccessibleName = "Position"
        Me.ToolStripTextBox8.AutoSize = false
        Me.ToolStripTextBox8.Name = "ToolStripTextBox8"
        Me.ToolStripTextBox8.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox8.Text = "0"
        Me.ToolStripTextBox8.ToolTipText = "Current position"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton43
        '
        Me.ToolStripButton43.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton43.Image = CType(resources.GetObject("ToolStripButton43.Image"),System.Drawing.Image)
        Me.ToolStripButton43.Name = "ToolStripButton43"
        Me.ToolStripButton43.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton43.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton43.Text = "Move next"
        '
        'ToolStripButton44
        '
        Me.ToolStripButton44.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton44.Image = CType(resources.GetObject("ToolStripButton44.Image"),System.Drawing.Image)
        Me.ToolStripButton44.Name = "ToolStripButton44"
        Me.ToolStripButton44.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton44.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton44.Text = "Move last"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnAgregarIncNeumaticos
        '
        Me.tsbtnAgregarIncNeumaticos.Image = CType(resources.GetObject("tsbtnAgregarIncNeumaticos.Image"),System.Drawing.Image)
        Me.tsbtnAgregarIncNeumaticos.Name = "tsbtnAgregarIncNeumaticos"
        Me.tsbtnAgregarIncNeumaticos.RightToLeftAutoMirrorImage = true
        Me.tsbtnAgregarIncNeumaticos.Size = New System.Drawing.Size(126, 22)
        Me.tsbtnAgregarIncNeumaticos.Text = "Agregar &Incidencia"
        '
        'pnlInciNeumatico
        '
        Me.pnlInciNeumatico.Controls.Add(Me.c1grdInciNeumatico)
        Me.pnlInciNeumatico.Controls.Add(Me.bnavInciNeumaticos)
        Me.pnlInciNeumatico.Controls.Add(Me.AcPanelCaption8)
        Me.pnlInciNeumatico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInciNeumatico.Location = New System.Drawing.Point(0, 0)
        Me.pnlInciNeumatico.Name = "pnlInciNeumatico"
        Me.pnlInciNeumatico.Size = New System.Drawing.Size(697, 411)
        Me.pnlInciNeumatico.TabIndex = 18
        '
        'c1grdInciNeumatico
        '
        Me.c1grdInciNeumatico.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdInciNeumatico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdInciNeumatico.Location = New System.Drawing.Point(0, 20)
        Me.c1grdInciNeumatico.Name = "c1grdInciNeumatico"
        Me.c1grdInciNeumatico.Rows.Count = 2
        Me.c1grdInciNeumatico.Rows.DefaultSize = 20
        Me.c1grdInciNeumatico.Size = New System.Drawing.Size(697, 366)
        Me.c1grdInciNeumatico.StyleInfo = resources.GetString("c1grdInciNeumatico.StyleInfo")
        Me.c1grdInciNeumatico.TabIndex = 19
        '
        'bnavInciNeumaticos
        '
        Me.bnavInciNeumaticos.AddNewItem = Nothing
        Me.bnavInciNeumaticos.CountItem = Me.ToolStripLabel9
        Me.bnavInciNeumaticos.DeleteItem = Nothing
        Me.bnavInciNeumaticos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavInciNeumaticos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton15, Me.ToolStripButton16, Me.ToolStripSeparator25, Me.ToolStripTextBox9, Me.ToolStripLabel9, Me.ToolStripSeparator26, Me.ToolStripButton21, Me.ToolStripButton22, Me.ToolStripSeparator27, Me.tsbtnQuitarIncNeumaticos})
        Me.bnavInciNeumaticos.Location = New System.Drawing.Point(0, 386)
        Me.bnavInciNeumaticos.MoveFirstItem = Me.ToolStripButton15
        Me.bnavInciNeumaticos.MoveLastItem = Me.ToolStripButton22
        Me.bnavInciNeumaticos.MoveNextItem = Me.ToolStripButton21
        Me.bnavInciNeumaticos.MovePreviousItem = Me.ToolStripButton16
        Me.bnavInciNeumaticos.Name = "bnavInciNeumaticos"
        Me.bnavInciNeumaticos.PositionItem = Me.ToolStripTextBox9
        Me.bnavInciNeumaticos.Size = New System.Drawing.Size(697, 25)
        Me.bnavInciNeumaticos.TabIndex = 18
        Me.bnavInciNeumaticos.Text = "bnavFletes"
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel9.Text = "de {0}"
        Me.ToolStripLabel9.ToolTipText = "Total number of items"
        '
        'ToolStripButton15
        '
        Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton15.Image = CType(resources.GetObject("ToolStripButton15.Image"),System.Drawing.Image)
        Me.ToolStripButton15.Name = "ToolStripButton15"
        Me.ToolStripButton15.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton15.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton15.Text = "Move first"
        '
        'ToolStripButton16
        '
        Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton16.Image = CType(resources.GetObject("ToolStripButton16.Image"),System.Drawing.Image)
        Me.ToolStripButton16.Name = "ToolStripButton16"
        Me.ToolStripButton16.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton16.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton16.Text = "Move previous"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox9
        '
        Me.ToolStripTextBox9.AccessibleName = "Position"
        Me.ToolStripTextBox9.AutoSize = false
        Me.ToolStripTextBox9.Name = "ToolStripTextBox9"
        Me.ToolStripTextBox9.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox9.Text = "0"
        Me.ToolStripTextBox9.ToolTipText = "Current position"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton21
        '
        Me.ToolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton21.Image = CType(resources.GetObject("ToolStripButton21.Image"),System.Drawing.Image)
        Me.ToolStripButton21.Name = "ToolStripButton21"
        Me.ToolStripButton21.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton21.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton21.Text = "Move next"
        '
        'ToolStripButton22
        '
        Me.ToolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton22.Image = CType(resources.GetObject("ToolStripButton22.Image"),System.Drawing.Image)
        Me.ToolStripButton22.Name = "ToolStripButton22"
        Me.ToolStripButton22.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton22.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton22.Text = "Move last"
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnQuitarIncNeumaticos
        '
        Me.tsbtnQuitarIncNeumaticos.Image = CType(resources.GetObject("tsbtnQuitarIncNeumaticos.Image"),System.Drawing.Image)
        Me.tsbtnQuitarIncNeumaticos.Name = "tsbtnQuitarIncNeumaticos"
        Me.tsbtnQuitarIncNeumaticos.RightToLeftAutoMirrorImage = true
        Me.tsbtnQuitarIncNeumaticos.Size = New System.Drawing.Size(117, 22)
        Me.tsbtnQuitarIncNeumaticos.Text = "&Quitar Incidencia"
        '
        'AcPanelCaption8
        '
        Me.AcPanelCaption8.ACCaption = "Incidencias del Neumatico"
        Me.AcPanelCaption8.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption8.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption8.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption8.Name = "AcPanelCaption8"
        Me.AcPanelCaption8.Size = New System.Drawing.Size(697, 20)
        Me.AcPanelCaption8.TabIndex = 17
        '
        'AcPanelCaption7
        '
        Me.AcPanelCaption7.ACCaption = "Inventario de Neumaticos"
        Me.AcPanelCaption7.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption7.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption7.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption7.Name = "AcPanelCaption7"
        Me.AcPanelCaption7.Size = New System.Drawing.Size(1412, 20)
        Me.AcPanelCaption7.TabIndex = 13
        '
        'tpgIncidencias
        '
        Me.tpgIncidencias.Controls.Add(Me.pnlIncidencias)
        Me.tpgIncidencias.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgIncidencias.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgIncidencias.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgIncidencias.Location = New System.Drawing.Point(1, 24)
        Me.tpgIncidencias.Name = "tpgIncidencias"
        Me.tpgIncidencias.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgIncidencias.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgIncidencias.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgIncidencias.Size = New System.Drawing.Size(1412, 431)
        Me.tpgIncidencias.TabIndex = 6
        Me.tpgIncidencias.Title = "Incidencias de Viaje"
        Me.tpgIncidencias.ToolTip = "Incidencias de Viaje"
        '
        'pnlIncidencias
        '
        Me.pnlIncidencias.Controls.Add(Me.c1grdInciViajes)
        Me.pnlIncidencias.Controls.Add(Me.txtVIGlosa)
        Me.pnlIncidencias.Controls.Add(Me.bnavInicidencias)
        Me.pnlIncidencias.Controls.Add(Me.AcPanelCaption3)
        Me.pnlIncidencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlIncidencias.Location = New System.Drawing.Point(0, 0)
        Me.pnlIncidencias.Name = "pnlIncidencias"
        Me.pnlIncidencias.Size = New System.Drawing.Size(1412, 431)
        Me.pnlIncidencias.TabIndex = 36
        '
        'c1grdInciViajes
        '
        Me.c1grdInciViajes.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdInciViajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdInciViajes.Location = New System.Drawing.Point(0, 45)
        Me.c1grdInciViajes.Name = "c1grdInciViajes"
        Me.c1grdInciViajes.Rows.Count = 2
        Me.c1grdInciViajes.Rows.DefaultSize = 20
        Me.c1grdInciViajes.Size = New System.Drawing.Size(1072, 386)
        Me.c1grdInciViajes.StyleInfo = resources.GetString("c1grdInciViajes.StyleInfo")
        Me.c1grdInciViajes.TabIndex = 15
        '
        'txtVIGlosa
        '
        Me.txtVIGlosa.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtVIGlosa.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtVIGlosa.Location = New System.Drawing.Point(1072, 45)
        Me.txtVIGlosa.Multiline = true
        Me.txtVIGlosa.Name = "txtVIGlosa"
        Me.txtVIGlosa.ReadOnly = true
        Me.txtVIGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtVIGlosa.Size = New System.Drawing.Size(340, 386)
        Me.txtVIGlosa.TabIndex = 17
        '
        'bnavInicidencias
        '
        Me.bnavInicidencias.AddNewItem = Nothing
        Me.bnavInicidencias.CountItem = Me.ToolStripLabel3
        Me.bnavInicidencias.DeleteItem = Nothing
        Me.bnavInicidencias.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.bnavInicidencias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.ToolStripButton8, Me.ToolStripSeparator7, Me.ToolStripTextBox3, Me.ToolStripLabel3, Me.ToolStripSeparator8, Me.ToolStripButton13, Me.ToolStripButton14, Me.ToolStripSeparator9, Me.tsbtnIVAgregar, Me.ToolStripSeparator41, Me.tsbtnIVQuitar, Me.ToolStripSeparator42})
        Me.bnavInicidencias.Location = New System.Drawing.Point(0, 20)
        Me.bnavInicidencias.MoveFirstItem = Me.ToolStripButton7
        Me.bnavInicidencias.MoveLastItem = Me.ToolStripButton14
        Me.bnavInicidencias.MoveNextItem = Me.ToolStripButton13
        Me.bnavInicidencias.MovePreviousItem = Me.ToolStripButton8
        Me.bnavInicidencias.Name = "bnavInicidencias"
        Me.bnavInicidencias.PositionItem = Me.ToolStripTextBox3
        Me.bnavInicidencias.Size = New System.Drawing.Size(1412, 25)
        Me.bnavInicidencias.TabIndex = 16
        Me.bnavInicidencias.Text = "bnavFletes"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel3.Text = "de {0}"
        Me.ToolStripLabel3.ToolTipText = "Total number of items"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"),System.Drawing.Image)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Move first"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"),System.Drawing.Image)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "Move previous"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.AccessibleName = "Position"
        Me.ToolStripTextBox3.AutoSize = false
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox3.Text = "0"
        Me.ToolStripTextBox3.ToolTipText = "Current position"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"),System.Drawing.Image)
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton13.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton13.Text = "Move next"
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.Image = CType(resources.GetObject("ToolStripButton14.Image"),System.Drawing.Image)
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton14.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton14.Text = "Move last"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnIVAgregar
        '
        Me.tsbtnIVAgregar.Image = CType(resources.GetObject("tsbtnIVAgregar.Image"),System.Drawing.Image)
        Me.tsbtnIVAgregar.Name = "tsbtnIVAgregar"
        Me.tsbtnIVAgregar.RightToLeftAutoMirrorImage = true
        Me.tsbtnIVAgregar.Size = New System.Drawing.Size(126, 22)
        Me.tsbtnIVAgregar.Text = "&Agregar Incidencia"
        '
        'ToolStripSeparator41
        '
        Me.ToolStripSeparator41.Name = "ToolStripSeparator41"
        Me.ToolStripSeparator41.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnIVQuitar
        '
        Me.tsbtnIVQuitar.Image = CType(resources.GetObject("tsbtnIVQuitar.Image"),System.Drawing.Image)
        Me.tsbtnIVQuitar.Name = "tsbtnIVQuitar"
        Me.tsbtnIVQuitar.RightToLeftAutoMirrorImage = true
        Me.tsbtnIVQuitar.Size = New System.Drawing.Size(117, 22)
        Me.tsbtnIVQuitar.Text = "&Quitar Incidencia"
        '
        'ToolStripSeparator42
        '
        Me.ToolStripSeparator42.Name = "ToolStripSeparator42"
        Me.ToolStripSeparator42.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption3
        '
        Me.AcPanelCaption3.ACCaption = "Incidencias del Viaje"
        Me.AcPanelCaption3.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption3.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption3.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption3.Name = "AcPanelCaption3"
        Me.AcPanelCaption3.Size = New System.Drawing.Size(1412, 20)
        Me.AcPanelCaption3.TabIndex = 13
        '
        'tpgResumen
        '
        Me.tpgResumen.Controls.Add(Me.grpLiq)
        Me.tpgResumen.Controls.Add(Me.grpRutas)
        Me.tpgResumen.InactiveBackColor = System.Drawing.Color.Empty
        Me.tpgResumen.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tpgResumen.InactiveTextColor = System.Drawing.Color.Empty
        Me.tpgResumen.Location = New System.Drawing.Point(1, 24)
        Me.tpgResumen.Name = "tpgResumen"
        Me.tpgResumen.SelectBackColor = System.Drawing.Color.Empty
        Me.tpgResumen.Selected = false
        Me.tpgResumen.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tpgResumen.SelectTextColor = System.Drawing.Color.Empty
        Me.tpgResumen.Size = New System.Drawing.Size(1412, 431)
        Me.tpgResumen.TabIndex = 12
        Me.tpgResumen.Title = "Resumen"
        Me.tpgResumen.ToolTip = "Resumen"
        '
        'grpLiq
        '
        Me.grpLiq.Controls.Add(Me.actxnConsumoAddBlue)
        Me.grpLiq.Controls.Add(Me.Label46)
        Me.grpLiq.Controls.Add(Me.btnGenRecibo)
        Me.grpLiq.Controls.Add(Me.GroupBox4)
        Me.grpLiq.Controls.Add(Me.actxnRecibosEgreso)
        Me.grpLiq.Controls.Add(Me.Label41)
        Me.grpLiq.Controls.Add(Me.actxnConsumoCombustible)
        Me.grpLiq.Controls.Add(Me.Label39)
        Me.grpLiq.Controls.Add(Me.actxnGastosConductor)
        Me.grpLiq.Controls.Add(Me.Label38)
        Me.grpLiq.Controls.Add(Me.btnCalLiqConductor)
        Me.grpLiq.Controls.Add(Me.Label37)
        Me.grpLiq.Controls.Add(Me.actxnPendiente)
        Me.grpLiq.Controls.Add(Me.actxnRecibosIngreso)
        Me.grpLiq.Controls.Add(Me.Label36)
        Me.grpLiq.Controls.Add(Me.actxnGastonInicial)
        Me.grpLiq.Controls.Add(Me.Label8)
        Me.grpLiq.Location = New System.Drawing.Point(403, 13)
        Me.grpLiq.Name = "grpLiq"
        Me.grpLiq.Size = New System.Drawing.Size(270, 348)
        Me.grpLiq.TabIndex = 17
        Me.grpLiq.TabStop = false
        Me.grpLiq.Text = "Liquidación Gastos de Conductor"
        '
        'actxnConsumoAddBlue
        '
        Me.actxnConsumoAddBlue.ACEnteros = 9
        Me.actxnConsumoAddBlue.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnConsumoAddBlue.ACNegativo = true
        Me.actxnConsumoAddBlue.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnConsumoAddBlue.Location = New System.Drawing.Point(172, 73)
        Me.actxnConsumoAddBlue.MaxLength = 12
        Me.actxnConsumoAddBlue.Name = "actxnConsumoAddBlue"
        Me.actxnConsumoAddBlue.ReadOnly = true
        Me.actxnConsumoAddBlue.Size = New System.Drawing.Size(86, 23)
        Me.actxnConsumoAddBlue.TabIndex = 19
        Me.actxnConsumoAddBlue.Tag = "EV"
        Me.actxnConsumoAddBlue.Text = "0.00"
        Me.actxnConsumoAddBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label46
        '
        Me.Label46.AutoSize = true
        Me.Label46.Location = New System.Drawing.Point(50, 77)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(106, 15)
        Me.Label46.TabIndex = 18
        Me.Label46.Text = "Consumo AdBlue :"
        '
        'btnGenRecibo
        '
        Me.btnGenRecibo.ForeColor = System.Drawing.Color.Black
        Me.btnGenRecibo.Image = Global.ACPTransportes.My.Resources.Resources.ACMoney_16x16
        Me.btnGenRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenRecibo.Location = New System.Drawing.Point(143, 204)
        Me.btnGenRecibo.Name = "btnGenRecibo"
        Me.btnGenRecibo.Size = New System.Drawing.Size(118, 24)
        Me.btnGenRecibo.TabIndex = 17
        Me.btnGenRecibo.Text = "Generar Recibo"
        Me.btnGenRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenRecibo.UseVisualStyleBackColor = true
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Navy
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.actxnSaldo)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.actxnPendiente2)
        Me.GroupBox4.Controls.Add(Me.actxnPagoConductor)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(3, 234)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(264, 111)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = false
        Me.GroupBox4.Text = "Pago a Conductor"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(33, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Saldo :"
        '
        'actxnSaldo
        '
        Me.actxnSaldo.ACEnteros = 9
        Me.actxnSaldo.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnSaldo.ACNegativo = true
        Me.actxnSaldo.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnSaldo.Location = New System.Drawing.Point(106, 78)
        Me.actxnSaldo.MaxLength = 12
        Me.actxnSaldo.Name = "actxnSaldo"
        Me.actxnSaldo.ReadOnly = true
        Me.actxnSaldo.Size = New System.Drawing.Size(88, 23)
        Me.actxnSaldo.TabIndex = 16
        Me.actxnSaldo.Tag = "EV"
        Me.actxnSaldo.Text = "0.00"
        Me.actxnSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Pendiente :"
        '
        'actxnPendiente2
        '
        Me.actxnPendiente2.ACEnteros = 9
        Me.actxnPendiente2.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnPendiente2.ACNegativo = true
        Me.actxnPendiente2.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnPendiente2.Location = New System.Drawing.Point(106, 53)
        Me.actxnPendiente2.MaxLength = 12
        Me.actxnPendiente2.Name = "actxnPendiente2"
        Me.actxnPendiente2.ReadOnly = true
        Me.actxnPendiente2.Size = New System.Drawing.Size(88, 23)
        Me.actxnPendiente2.TabIndex = 14
        Me.actxnPendiente2.Tag = "EV"
        Me.actxnPendiente2.Text = "0.00"
        Me.actxnPendiente2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnPagoConductor
        '
        Me.actxnPagoConductor.ACEnteros = 9
        Me.actxnPagoConductor.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnPagoConductor.ACNegativo = true
        Me.actxnPagoConductor.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnPagoConductor.Font = New System.Drawing.Font("Courier New", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.actxnPagoConductor.Location = New System.Drawing.Point(106, 12)
        Me.actxnPagoConductor.MaxLength = 12
        Me.actxnPagoConductor.Name = "actxnPagoConductor"
        Me.actxnPagoConductor.Size = New System.Drawing.Size(152, 35)
        Me.actxnPagoConductor.TabIndex = 12
        Me.actxnPagoConductor.Tag = "EV"
        Me.actxnPagoConductor.Text = "0.00"
        Me.actxnPagoConductor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = true
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 16!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.Label30.Location = New System.Drawing.Point(6, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(94, 21)
        Me.Label30.TabIndex = 11
        Me.Label30.Text = "Importe : S/."
        '
        'actxnRecibosEgreso
        '
        Me.actxnRecibosEgreso.ACEnteros = 9
        Me.actxnRecibosEgreso.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnRecibosEgreso.ACNegativo = true
        Me.actxnRecibosEgreso.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnRecibosEgreso.Location = New System.Drawing.Point(173, 152)
        Me.actxnRecibosEgreso.MaxLength = 12
        Me.actxnRecibosEgreso.Name = "actxnRecibosEgreso"
        Me.actxnRecibosEgreso.ReadOnly = true
        Me.actxnRecibosEgreso.Size = New System.Drawing.Size(86, 23)
        Me.actxnRecibosEgreso.TabIndex = 16
        Me.actxnRecibosEgreso.Tag = "EV"
        Me.actxnRecibosEgreso.Text = "0.00"
        Me.actxnRecibosEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.AutoSize = true
        Me.Label41.Location = New System.Drawing.Point(56, 156)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(108, 15)
        Me.Label41.TabIndex = 15
        Me.Label41.Text = "Recibos de Egreso :"
        '
        'actxnConsumoCombustible
        '
        Me.actxnConsumoCombustible.ACEnteros = 9
        Me.actxnConsumoCombustible.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnConsumoCombustible.ACNegativo = true
        Me.actxnConsumoCombustible.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnConsumoCombustible.Location = New System.Drawing.Point(173, 46)
        Me.actxnConsumoCombustible.MaxLength = 12
        Me.actxnConsumoCombustible.Name = "actxnConsumoCombustible"
        Me.actxnConsumoCombustible.ReadOnly = true
        Me.actxnConsumoCombustible.Size = New System.Drawing.Size(86, 23)
        Me.actxnConsumoCombustible.TabIndex = 14
        Me.actxnConsumoCombustible.Tag = "EV"
        Me.actxnConsumoCombustible.Text = "0.00"
        Me.actxnConsumoCombustible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.AutoSize = true
        Me.Label39.Location = New System.Drawing.Point(28, 50)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(136, 15)
        Me.Label39.TabIndex = 13
        Me.Label39.Text = "Consumo Combustible :"
        '
        'actxnGastosConductor
        '
        Me.actxnGastosConductor.ACEnteros = 9
        Me.actxnGastosConductor.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnGastosConductor.ACNegativo = true
        Me.actxnGastosConductor.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnGastosConductor.Location = New System.Drawing.Point(173, 99)
        Me.actxnGastosConductor.MaxLength = 12
        Me.actxnGastosConductor.Name = "actxnGastosConductor"
        Me.actxnGastosConductor.ReadOnly = true
        Me.actxnGastosConductor.Size = New System.Drawing.Size(86, 23)
        Me.actxnGastosConductor.TabIndex = 3
        Me.actxnGastosConductor.Tag = "EV"
        Me.actxnGastosConductor.Text = "0.00"
        Me.actxnGastosConductor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = true
        Me.Label38.Location = New System.Drawing.Point(37, 103)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(127, 15)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "Gastos del Conductor :"
        '
        'btnCalLiqConductor
        '
        Me.btnCalLiqConductor.Image = Global.ACPTransportes.My.Resources.Resources.ACSum
        Me.btnCalLiqConductor.Location = New System.Drawing.Point(11, 196)
        Me.btnCalLiqConductor.Name = "btnCalLiqConductor"
        Me.btnCalLiqConductor.Size = New System.Drawing.Size(30, 32)
        Me.btnCalLiqConductor.TabIndex = 8
        Me.btnCalLiqConductor.UseVisualStyleBackColor = true
        '
        'Label37
        '
        Me.Label37.AutoSize = true
        Me.Label37.Location = New System.Drawing.Point(98, 182)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(66, 15)
        Me.Label37.TabIndex = 9
        Me.Label37.Text = "Pendiente :"
        '
        'actxnPendiente
        '
        Me.actxnPendiente.ACEnteros = 9
        Me.actxnPendiente.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnPendiente.ACNegativo = true
        Me.actxnPendiente.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnPendiente.Location = New System.Drawing.Point(173, 178)
        Me.actxnPendiente.MaxLength = 12
        Me.actxnPendiente.Name = "actxnPendiente"
        Me.actxnPendiente.ReadOnly = true
        Me.actxnPendiente.Size = New System.Drawing.Size(86, 23)
        Me.actxnPendiente.TabIndex = 10
        Me.actxnPendiente.Tag = "EV"
        Me.actxnPendiente.Text = "0.00"
        Me.actxnPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnRecibosIngreso
        '
        Me.actxnRecibosIngreso.ACEnteros = 9
        Me.actxnRecibosIngreso.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnRecibosIngreso.ACNegativo = true
        Me.actxnRecibosIngreso.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnRecibosIngreso.Location = New System.Drawing.Point(173, 126)
        Me.actxnRecibosIngreso.MaxLength = 12
        Me.actxnRecibosIngreso.Name = "actxnRecibosIngreso"
        Me.actxnRecibosIngreso.ReadOnly = true
        Me.actxnRecibosIngreso.Size = New System.Drawing.Size(86, 23)
        Me.actxnRecibosIngreso.TabIndex = 5
        Me.actxnRecibosIngreso.Tag = "EV"
        Me.actxnRecibosIngreso.Text = "0.00"
        Me.actxnRecibosIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = true
        Me.Label36.Location = New System.Drawing.Point(52, 130)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(112, 15)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Recibos de Ingreso :"
        '
        'actxnGastonInicial
        '
        Me.actxnGastonInicial.ACEnteros = 9
        Me.actxnGastonInicial.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnGastonInicial.ACNegativo = true
        Me.actxnGastonInicial.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnGastonInicial.Location = New System.Drawing.Point(173, 20)
        Me.actxnGastonInicial.MaxLength = 12
        Me.actxnGastonInicial.Name = "actxnGastonInicial"
        Me.actxnGastonInicial.ReadOnly = true
        Me.actxnGastonInicial.Size = New System.Drawing.Size(86, 23)
        Me.actxnGastonInicial.TabIndex = 1
        Me.actxnGastonInicial.Tag = "EV"
        Me.actxnGastonInicial.Text = "0.00"
        Me.actxnGastonInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(71, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Gastos Iniciales :"
        '
        'grpRutas
        '
        Me.grpRutas.Controls.Add(Me.c1grdRutas)
        Me.grpRutas.Controls.Add(Me.bnavRutas)
        Me.grpRutas.Controls.Add(Me.AcPanelCaption6)
        Me.grpRutas.Location = New System.Drawing.Point(725, 23)
        Me.grpRutas.Name = "grpRutas"
        Me.grpRutas.Size = New System.Drawing.Size(253, 240)
        Me.grpRutas.TabIndex = 18
        Me.grpRutas.TabStop = false
        Me.grpRutas.Text = "Listado de Viajes"
        '
        'c1grdRutas
        '
        Me.c1grdRutas.AllowEditing = false
        Me.c1grdRutas.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdRutas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdRutas.Location = New System.Drawing.Point(3, 41)
        Me.c1grdRutas.Name = "c1grdRutas"
        Me.c1grdRutas.Rows.Count = 2
        Me.c1grdRutas.Rows.DefaultSize = 20
        Me.c1grdRutas.Size = New System.Drawing.Size(247, 196)
        Me.c1grdRutas.StyleInfo = resources.GetString("c1grdRutas.StyleInfo")
        Me.c1grdRutas.TabIndex = 22
        '
        'bnavRutas
        '
        Me.bnavRutas.AddNewItem = Nothing
        Me.bnavRutas.CountItem = Me.ToolStripLabel6
        Me.bnavRutas.DeleteItem = Nothing
        Me.bnavRutas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavRutas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton30, Me.ToolStripButton31, Me.ToolStripSeparator17, Me.ToolStripTextBox6, Me.ToolStripLabel6, Me.ToolStripSeparator18, Me.ToolStripButton32, Me.ToolStripButton33, Me.ToolStripSeparator36})
        Me.bnavRutas.Location = New System.Drawing.Point(3, 212)
        Me.bnavRutas.MoveFirstItem = Me.ToolStripButton30
        Me.bnavRutas.MoveLastItem = Me.ToolStripButton33
        Me.bnavRutas.MoveNextItem = Me.ToolStripButton32
        Me.bnavRutas.MovePreviousItem = Me.ToolStripButton31
        Me.bnavRutas.Name = "bnavRutas"
        Me.bnavRutas.PositionItem = Me.ToolStripTextBox6
        Me.bnavRutas.Size = New System.Drawing.Size(247, 25)
        Me.bnavRutas.TabIndex = 23
        Me.bnavRutas.Text = "bnavFletes"
        Me.bnavRutas.Visible = false
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel6.Text = "de {0}"
        Me.ToolStripLabel6.ToolTipText = "Total number of items"
        '
        'ToolStripButton30
        '
        Me.ToolStripButton30.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton30.Image = CType(resources.GetObject("ToolStripButton30.Image"),System.Drawing.Image)
        Me.ToolStripButton30.Name = "ToolStripButton30"
        Me.ToolStripButton30.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton30.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton30.Text = "Move first"
        '
        'ToolStripButton31
        '
        Me.ToolStripButton31.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton31.Image = CType(resources.GetObject("ToolStripButton31.Image"),System.Drawing.Image)
        Me.ToolStripButton31.Name = "ToolStripButton31"
        Me.ToolStripButton31.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton31.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton31.Text = "Move previous"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox6
        '
        Me.ToolStripTextBox6.AccessibleName = "Position"
        Me.ToolStripTextBox6.AutoSize = false
        Me.ToolStripTextBox6.Name = "ToolStripTextBox6"
        Me.ToolStripTextBox6.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox6.Text = "0"
        Me.ToolStripTextBox6.ToolTipText = "Current position"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton32
        '
        Me.ToolStripButton32.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton32.Image = CType(resources.GetObject("ToolStripButton32.Image"),System.Drawing.Image)
        Me.ToolStripButton32.Name = "ToolStripButton32"
        Me.ToolStripButton32.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton32.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton32.Text = "Move next"
        '
        'ToolStripButton33
        '
        Me.ToolStripButton33.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton33.Image = CType(resources.GetObject("ToolStripButton33.Image"),System.Drawing.Image)
        Me.ToolStripButton33.Name = "ToolStripButton33"
        Me.ToolStripButton33.RightToLeftAutoMirrorImage = true
        Me.ToolStripButton33.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton33.Text = "Move last"
        '
        'ToolStripSeparator36
        '
        Me.ToolStripSeparator36.Name = "ToolStripSeparator36"
        Me.ToolStripSeparator36.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption6
        '
        Me.AcPanelCaption6.ACCaption = "Origen - Destino"
        Me.AcPanelCaption6.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption6.Font = New System.Drawing.Font("Tahoma", 8!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption6.Location = New System.Drawing.Point(3, 19)
        Me.AcPanelCaption6.Name = "AcPanelCaption6"
        Me.AcPanelCaption6.Size = New System.Drawing.Size(247, 22)
        Me.AcPanelCaption6.TabIndex = 25
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox6)
        Me.Panel3.Controls.Add(Me.GroupBox5)
        Me.Panel3.Controls.Add(Me.btnReporte)
        Me.Panel3.Controls.Add(Me.txtViajexConductor)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.grpCombustible)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label40)
        Me.Panel3.Controls.Add(Me.txtCodigo)
        Me.Panel3.Controls.Add(Me.txtViajeXvehiculo)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label35)
        Me.Panel3.Controls.Add(Me.dtpFecLlegada)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.dtpFecSalida)
        Me.Panel3.Controls.Add(Me.dtpHorSalida)
        Me.Panel3.Controls.Add(Me.dtpHorLlegada)
        Me.Panel3.Controls.Add(Me.txtDescripcion)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1414, 138)
        Me.Panel3.TabIndex = 38
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.actxnAddBlueRealizado)
        Me.GroupBox6.Controls.Add(Me.Label43)
        Me.GroupBox6.Controls.Add(Me.Label44)
        Me.GroupBox6.Controls.Add(Me.actxnConsAddBlueRealizado)
        Me.GroupBox6.Controls.Add(Me.Label45)
        Me.GroupBox6.Location = New System.Drawing.Point(835, 65)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(186, 67)
        Me.GroupBox6.TabIndex = 25
        Me.GroupBox6.TabStop = false
        Me.GroupBox6.Text = "AdBlue"
        '
        'actxnAddBlueRealizado
        '
        Me.actxnAddBlueRealizado.ACEnteros = 9
        Me.actxnAddBlueRealizado.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnAddBlueRealizado.ACFormato = "###,###,##0.0000"
        Me.actxnAddBlueRealizado.ACNegativo = true
        Me.actxnAddBlueRealizado.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnAddBlueRealizado.Location = New System.Drawing.Point(95, 15)
        Me.actxnAddBlueRealizado.MaxLength = 12
        Me.actxnAddBlueRealizado.Name = "actxnAddBlueRealizado"
        Me.actxnAddBlueRealizado.ReadOnly = true
        Me.actxnAddBlueRealizado.Size = New System.Drawing.Size(61, 23)
        Me.actxnAddBlueRealizado.TabIndex = 5
        Me.actxnAddBlueRealizado.Tag = "EV"
        Me.actxnAddBlueRealizado.Text = "0.0000"
        Me.actxnAddBlueRealizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.AutoSize = true
        Me.Label43.Location = New System.Drawing.Point(158, 20)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(26, 15)
        Me.Label43.TabIndex = 24
        Me.Label43.Text = "Gls."
        '
        'Label44
        '
        Me.Label44.AutoSize = true
        Me.Label44.Location = New System.Drawing.Point(10, 44)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(82, 15)
        Me.Label44.TabIndex = 6
        Me.Label44.Text = "Consumo S/. :"
        '
        'actxnConsAddBlueRealizado
        '
        Me.actxnConsAddBlueRealizado.ACEnteros = 9
        Me.actxnConsAddBlueRealizado.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnConsAddBlueRealizado.ACNegativo = true
        Me.actxnConsAddBlueRealizado.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnConsAddBlueRealizado.Location = New System.Drawing.Point(95, 41)
        Me.actxnConsAddBlueRealizado.MaxLength = 12
        Me.actxnConsAddBlueRealizado.Name = "actxnConsAddBlueRealizado"
        Me.actxnConsAddBlueRealizado.ReadOnly = true
        Me.actxnConsAddBlueRealizado.Size = New System.Drawing.Size(73, 23)
        Me.actxnConsAddBlueRealizado.TabIndex = 7
        Me.actxnConsAddBlueRealizado.Tag = "EV"
        Me.actxnConsAddBlueRealizado.Text = "0.00"
        Me.actxnConsAddBlueRealizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.AutoSize = true
        Me.Label45.Location = New System.Drawing.Point(1, 19)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(84, 15)
        Me.Label45.TabIndex = 4
        Me.Label45.Text = "AdBlue Cons. :"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.dtpFecScan)
        Me.GroupBox5.Controls.Add(Me.actxnCombScanner)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.actxnKmScanner)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Location = New System.Drawing.Point(1027, 65)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(276, 67)
        Me.GroupBox5.TabIndex = 18
        Me.GroupBox5.TabStop = false
        Me.GroupBox5.Text = "Datos Scanner"
        '
        'Label25
        '
        Me.Label25.AutoSize = true
        Me.Label25.Location = New System.Drawing.Point(209, 20)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 15)
        Me.Label25.TabIndex = 25
        Me.Label25.Text = "Fecha"
        '
        'dtpFecScan
        '
        Me.dtpFecScan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecScan.Location = New System.Drawing.Point(159, 39)
        Me.dtpFecScan.Name = "dtpFecScan"
        Me.dtpFecScan.ShowCheckBox = true
        Me.dtpFecScan.Size = New System.Drawing.Size(115, 23)
        Me.dtpFecScan.TabIndex = 19
        '
        'actxnCombScanner
        '
        Me.actxnCombScanner.ACEnteros = 9
        Me.actxnCombScanner.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnCombScanner.ACFormato = "###,###,##0.0000"
        Me.actxnCombScanner.ACNegativo = true
        Me.actxnCombScanner.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnCombScanner.Location = New System.Drawing.Point(95, 15)
        Me.actxnCombScanner.MaxLength = 12
        Me.actxnCombScanner.Name = "actxnCombScanner"
        Me.actxnCombScanner.Size = New System.Drawing.Size(61, 23)
        Me.actxnCombScanner.TabIndex = 5
        Me.actxnCombScanner.Tag = "EV"
        Me.actxnCombScanner.Text = "0.0000"
        Me.actxnCombScanner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(159, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 15)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Gls."
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.Location = New System.Drawing.Point(9, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 15)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "kilometraje :"
        '
        'actxnKmScanner
        '
        Me.actxnKmScanner.ACEnteros = 9
        Me.actxnKmScanner.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnKmScanner.ACNegativo = true
        Me.actxnKmScanner.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnKmScanner.Location = New System.Drawing.Point(85, 39)
        Me.actxnKmScanner.MaxLength = 12
        Me.actxnKmScanner.Name = "actxnKmScanner"
        Me.actxnKmScanner.Size = New System.Drawing.Size(71, 23)
        Me.actxnKmScanner.TabIndex = 7
        Me.actxnKmScanner.Tag = "EV"
        Me.actxnKmScanner.Text = "0.00"
        Me.actxnKmScanner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = true
        Me.Label17.Location = New System.Drawing.Point(10, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 15)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Combustible :"
        '
        'btnReporte
        '
        Me.btnReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnReporte.Image = Global.ACPTransportes.My.Resources.Resources.ACImprimirRed_32x32
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(1308, 81)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(100, 48)
        Me.btnReporte.TabIndex = 17
        Me.btnReporte.Text = "Imprimir Informe"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = true
        '
        'txtViajexConductor
        '
        Me.txtViajexConductor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtViajexConductor.Location = New System.Drawing.Point(1317, 38)
        Me.txtViajexConductor.Name = "txtViajexConductor"
        Me.txtViajexConductor.Size = New System.Drawing.Size(86, 23)
        Me.txtViajexConductor.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Enabled = false
        Me.Label6.Location = New System.Drawing.Point(9, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha Salida :"
        '
        'grpCombustible
        '
        Me.grpCombustible.Controls.Add(Me.actxnCombRealizado)
        Me.grpCombustible.Controls.Add(Me.Label29)
        Me.grpCombustible.Controls.Add(Me.Label28)
        Me.grpCombustible.Controls.Add(Me.actxnConsRealizado)
        Me.grpCombustible.Controls.Add(Me.Label11)
        Me.grpCombustible.Location = New System.Drawing.Point(619, 65)
        Me.grpCombustible.Name = "grpCombustible"
        Me.grpCombustible.Size = New System.Drawing.Size(213, 67)
        Me.grpCombustible.TabIndex = 14
        Me.grpCombustible.TabStop = false
        Me.grpCombustible.Text = "Combustible"
        '
        'actxnCombRealizado
        '
        Me.actxnCombRealizado.ACEnteros = 9
        Me.actxnCombRealizado.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnCombRealizado.ACFormato = "###,###,##0.0000"
        Me.actxnCombRealizado.ACNegativo = true
        Me.actxnCombRealizado.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnCombRealizado.Location = New System.Drawing.Point(120, 15)
        Me.actxnCombRealizado.MaxLength = 12
        Me.actxnCombRealizado.Name = "actxnCombRealizado"
        Me.actxnCombRealizado.ReadOnly = true
        Me.actxnCombRealizado.Size = New System.Drawing.Size(61, 23)
        Me.actxnCombRealizado.TabIndex = 5
        Me.actxnCombRealizado.Tag = "EV"
        Me.actxnCombRealizado.Text = "0.0000"
        Me.actxnCombRealizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = true
        Me.Label29.Location = New System.Drawing.Point(183, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(26, 15)
        Me.Label29.TabIndex = 24
        Me.Label29.Text = "Gls."
        '
        'Label28
        '
        Me.Label28.AutoSize = true
        Me.Label28.Location = New System.Drawing.Point(35, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(82, 15)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "Consumo S/. :"
        '
        'actxnConsRealizado
        '
        Me.actxnConsRealizado.ACEnteros = 9
        Me.actxnConsRealizado.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnConsRealizado.ACNegativo = true
        Me.actxnConsRealizado.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnConsRealizado.Location = New System.Drawing.Point(120, 40)
        Me.actxnConsRealizado.MaxLength = 12
        Me.actxnConsRealizado.Name = "actxnConsRealizado"
        Me.actxnConsRealizado.ReadOnly = true
        Me.actxnConsRealizado.Size = New System.Drawing.Size(90, 23)
        Me.actxnConsRealizado.TabIndex = 7
        Me.actxnConsRealizado.Tag = "EV"
        Me.actxnConsRealizado.Text = "0.00"
        Me.actxnConsRealizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(3, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 15)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Comb. Consumido :"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = true
        Me.Label5.Enabled = false
        Me.Label5.Location = New System.Drawing.Point(1264, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Codigo :"
        '
        'Label40
        '
        Me.Label40.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label40.AutoSize = true
        Me.Label40.Enabled = false
        Me.Label40.Location = New System.Drawing.Point(1205, 42)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(107, 15)
        Me.Label40.TabIndex = 12
        Me.Label40.Text = "Viaje x Conductor :"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtCodigo.Enabled = false
        Me.txtCodigo.Location = New System.Drawing.Point(1317, 7)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(86, 23)
        Me.txtCodigo.TabIndex = 11
        '
        'txtViajeXvehiculo
        '
        Me.txtViajeXvehiculo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtViajeXvehiculo.Location = New System.Drawing.Point(1208, 7)
        Me.txtViajeXvehiculo.Name = "txtViajeXvehiculo"
        Me.txtViajeXvehiculo.Size = New System.Drawing.Size(50, 23)
        Me.txtViajeXvehiculo.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Enabled = false
        Me.Label7.Location = New System.Drawing.Point(296, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 15)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Fecha Llegada :"
        '
        'Label35
        '
        Me.Label35.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label35.Enabled = false
        Me.Label35.Location = New System.Drawing.Point(1146, 2)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(58, 33)
        Me.Label35.TabIndex = 8
        Me.Label35.Text = "Viaje x Vehiculo :"
        '
        'dtpFecLlegada
        '
        Me.dtpFecLlegada.Checked = false
        Me.dtpFecLlegada.Enabled = false
        Me.dtpFecLlegada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecLlegada.Location = New System.Drawing.Point(404, 7)
        Me.dtpFecLlegada.Name = "dtpFecLlegada"
        Me.dtpFecLlegada.ShowCheckBox = true
        Me.dtpFecLlegada.Size = New System.Drawing.Size(117, 23)
        Me.dtpFecLlegada.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.actxnVehKilometrajeMantenimiento_)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.actxnVehKilometrajeMantenimiento)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.actxnKmAnterior)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.actxnVehKilometraje)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.actxnKmDiferencia)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.actxnKilometraje)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(600, 67)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Ruta"
        '
        'actxnVehKilometrajeMantenimiento_
        '
        Me.actxnVehKilometrajeMantenimiento_.Location = New System.Drawing.Point(496, 32)
        Me.actxnVehKilometrajeMantenimiento_.Name = "actxnVehKilometrajeMantenimiento_"
        Me.actxnVehKilometrajeMantenimiento_.Size = New System.Drawing.Size(79, 23)
        Me.actxnVehKilometrajeMantenimiento_.TabIndex = 17
        '
        'Label42
        '
        Me.Label42.AutoSize = true
        Me.Label42.Location = New System.Drawing.Point(576, 35)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(28, 15)
        Me.Label42.TabIndex = 15
        Me.Label42.Text = ".Km"
        '
        'actxnVehKilometrajeMantenimiento
        '
        Me.actxnVehKilometrajeMantenimiento.ACEnteros = 9
        Me.actxnVehKilometrajeMantenimiento.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnVehKilometrajeMantenimiento.ACFormato = "########0.00"
        Me.actxnVehKilometrajeMantenimiento.ACNegativo = true
        Me.actxnVehKilometrajeMantenimiento.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnVehKilometrajeMantenimiento.Enabled = false
        Me.actxnVehKilometrajeMantenimiento.Font = New System.Drawing.Font("Segoe UI Black", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.actxnVehKilometrajeMantenimiento.Location = New System.Drawing.Point(403, 33)
        Me.actxnVehKilometrajeMantenimiento.MaxLength = 12
        Me.actxnVehKilometrajeMantenimiento.Name = "actxnVehKilometrajeMantenimiento"
        Me.actxnVehKilometrajeMantenimiento.ReadOnly = true
        Me.actxnVehKilometrajeMantenimiento.Size = New System.Drawing.Size(85, 24)
        Me.actxnVehKilometrajeMantenimiento.TabIndex = 14
        Me.actxnVehKilometrajeMantenimiento.Tag = "EV"
        Me.actxnVehKilometrajeMantenimiento.Text = "0.00"
        Me.actxnVehKilometrajeMantenimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = true
        Me.Label27.Location = New System.Drawing.Point(402, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(170, 15)
        Me.Label27.TabIndex = 13
        Me.Label27.Text = "Km Rest. para Mantenimiento :"
        '
        'actxnKmAnterior
        '
        Me.actxnKmAnterior.ACEnteros = 9
        Me.actxnKmAnterior.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnKmAnterior.ACNegativo = true
        Me.actxnKmAnterior.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnKmAnterior.Location = New System.Drawing.Point(109, 34)
        Me.actxnKmAnterior.MaxLength = 12
        Me.actxnKmAnterior.Name = "actxnKmAnterior"
        Me.actxnKmAnterior.Size = New System.Drawing.Size(83, 23)
        Me.actxnKmAnterior.TabIndex = 4
        Me.actxnKmAnterior.Tag = "EVO"
        Me.actxnKmAnterior.Text = "0.00"
        Me.actxnKmAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = true
        Me.Label31.Location = New System.Drawing.Point(114, 15)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(74, 15)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "Km. Anterior"
        '
        'Label34
        '
        Me.Label34.AutoSize = true
        Me.Label34.Location = New System.Drawing.Point(192, 38)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(15, 15)
        Me.Label34.TabIndex = 5
        Me.Label34.Text = "="
        '
        'actxnVehKilometraje
        '
        Me.actxnVehKilometraje.ACEnteros = 9
        Me.actxnVehKilometraje.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnVehKilometraje.ACFormato = "########0.00"
        Me.actxnVehKilometraje.ACNegativo = true
        Me.actxnVehKilometraje.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnVehKilometraje.Location = New System.Drawing.Point(303, 34)
        Me.actxnVehKilometraje.MaxLength = 12
        Me.actxnVehKilometraje.Name = "actxnVehKilometraje"
        Me.actxnVehKilometraje.ReadOnly = true
        Me.actxnVehKilometraje.Size = New System.Drawing.Size(86, 23)
        Me.actxnVehKilometraje.TabIndex = 9
        Me.actxnVehKilometraje.Tag = "EV"
        Me.actxnVehKilometraje.Text = "0.00"
        Me.actxnVehKilometraje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = true
        Me.Label16.Location = New System.Drawing.Point(302, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 15)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Km del Vehiculo :"
        '
        'Label33
        '
        Me.Label33.AutoSize = true
        Me.Label33.Location = New System.Drawing.Point(96, 38)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(12, 15)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "-"
        '
        'actxnKmDiferencia
        '
        Me.actxnKmDiferencia.ACEnteros = 9
        Me.actxnKmDiferencia.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnKmDiferencia.ACNegativo = true
        Me.actxnKmDiferencia.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnKmDiferencia.Location = New System.Drawing.Point(211, 34)
        Me.actxnKmDiferencia.MaxLength = 12
        Me.actxnKmDiferencia.Name = "actxnKmDiferencia"
        Me.actxnKmDiferencia.ReadOnly = true
        Me.actxnKmDiferencia.Size = New System.Drawing.Size(83, 23)
        Me.actxnKmDiferencia.TabIndex = 7
        Me.actxnKmDiferencia.Tag = "EVO"
        Me.actxnKmDiferencia.Text = "0.00"
        Me.actxnKmDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = true
        Me.Label32.Location = New System.Drawing.Point(215, 15)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(79, 15)
        Me.Label32.TabIndex = 6
        Me.Label32.Text = "Km Recorrido"
        '
        'actxnKilometraje
        '
        Me.actxnKilometraje.ACEnteros = 9
        Me.actxnKilometraje.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnKilometraje.ACNegativo = true
        Me.actxnKilometraje.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnKilometraje.Location = New System.Drawing.Point(9, 34)
        Me.actxnKilometraje.MaxLength = 12
        Me.actxnKilometraje.Name = "actxnKilometraje"
        Me.actxnKilometraje.Size = New System.Drawing.Size(83, 23)
        Me.actxnKilometraje.TabIndex = 1
        Me.actxnKilometraje.Tag = "EVO"
        Me.actxnKilometraje.Text = "0.00"
        Me.actxnKilometraje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(13, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Km Marcado "
        '
        'dtpFecSalida
        '
        Me.dtpFecSalida.Enabled = false
        Me.dtpFecSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecSalida.Location = New System.Drawing.Point(91, 7)
        Me.dtpFecSalida.Name = "dtpFecSalida"
        Me.dtpFecSalida.Size = New System.Drawing.Size(96, 23)
        Me.dtpFecSalida.TabIndex = 1
        '
        'dtpHorSalida
        '
        Me.dtpHorSalida.CustomFormat = "hh:mm tt"
        Me.dtpHorSalida.Enabled = false
        Me.dtpHorSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHorSalida.Location = New System.Drawing.Point(190, 7)
        Me.dtpHorSalida.Name = "dtpHorSalida"
        Me.dtpHorSalida.ShowUpDown = true
        Me.dtpHorSalida.Size = New System.Drawing.Size(87, 23)
        Me.dtpHorSalida.TabIndex = 2
        '
        'dtpHorLlegada
        '
        Me.dtpHorLlegada.CustomFormat = "hh:mm tt"
        Me.dtpHorLlegada.Enabled = false
        Me.dtpHorLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHorLlegada.Location = New System.Drawing.Point(526, 7)
        Me.dtpHorLlegada.Name = "dtpHorLlegada"
        Me.dtpHorLlegada.ShowUpDown = true
        Me.dtpHorLlegada.Size = New System.Drawing.Size(86, 23)
        Me.dtpHorLlegada.TabIndex = 5
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.txtDescripcion.Location = New System.Drawing.Point(91, 37)
        Me.txtDescripcion.MaxLength = 120
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(1108, 25)
        Me.txtDescripcion.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(9, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripción :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnRepIngre})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(37, 594)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
        Me.ToolStrip1.Visible = false
        '
        'tsbtnRepIngre
        '
        Me.tsbtnRepIngre.Font = New System.Drawing.Font("Segoe UI", 10!)
        Me.tsbtnRepIngre.Image = Global.ACPTransportes.My.Resources.Resources.ACImprimirRed_32x32
        Me.tsbtnRepIngre.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbtnRepIngre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnRepIngre.Name = "tsbtnRepIngre"
        Me.tsbtnRepIngre.Size = New System.Drawing.Size(34, 168)
        Me.tsbtnRepIngre.Text = "Reporte de Ingresos"
        Me.tsbtnRepIngre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 29)
        Me.tabMantenimiento.MediaPlayerDockSides = false
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = false
        Me.tabMantenimiento.SelectedIndex = 0
        Me.tabMantenimiento.ShowDropSelect = false
        Me.tabMantenimiento.Size = New System.Drawing.Size(1416, 619)
        Me.tabMantenimiento.TabIndex = 1
        Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos, Me.tabDatos, Me.tabBusqueda})
        Me.tabMantenimiento.TextTips = true
        '
        'tabBusqueda
        '
        Me.tabBusqueda.Controls.Add(Me.c1grdBusqueda)
        Me.tabBusqueda.Controls.Add(Me.bnavBusqueda)
        Me.tabBusqueda.Controls.Add(Me.grpBusqueda)
        Me.tabBusqueda.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Location = New System.Drawing.Point(1, 1)
        Me.tabBusqueda.Name = "tabBusqueda"
        Me.tabBusqueda.SelectBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Selected = false
        Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Size = New System.Drawing.Size(1414, 594)
        Me.tabBusqueda.TabIndex = 5
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'c1grdBusqueda
        '
        Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 98)
        Me.c1grdBusqueda.Name = "c1grdBusqueda"
        Me.c1grdBusqueda.Rows.Count = 2
        Me.c1grdBusqueda.Rows.DefaultSize = 20
        Me.c1grdBusqueda.Size = New System.Drawing.Size(1414, 496)
        Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
        Me.c1grdBusqueda.TabIndex = 2
        '
        'bnavBusqueda
        '
        Me.bnavBusqueda.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.bnavBusqueda.CountItem = Me.BindingNavigatorCountItem
        Me.bnavBusqueda.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.tsbtnQuitarLiquidacion, Me.ToolStripButton52})
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 569)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(1275, 25)
        Me.bnavBusqueda.TabIndex = 3
        Me.bnavBusqueda.Text = "BindingNavigator1"
        Me.bnavBusqueda.Visible = false
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        Me.BindingNavigatorAddNewItem.Visible = false
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        Me.BindingNavigatorDeleteItem.Visible = false
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = false
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnQuitarLiquidacion
        '
        Me.tsbtnQuitarLiquidacion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnQuitarLiquidacion.Image = Global.ACPTransportes.My.Resources.Resources.ACAnular_16x16
        Me.tsbtnQuitarLiquidacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnQuitarLiquidacion.Name = "tsbtnQuitarLiquidacion"
        Me.tsbtnQuitarLiquidacion.Size = New System.Drawing.Size(125, 22)
        Me.tsbtnQuitarLiquidacion.Text = "Quitar Liquidación"
        '
        'ToolStripButton52
        '
        Me.ToolStripButton52.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton52.Image = Global.ACPTransportes.My.Resources.Resources.Excel2_16x16
        Me.ToolStripButton52.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton52.Name = "ToolStripButton52"
        Me.ToolStripButton52.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripButton52.Text = "Enviar a Excel"
        '
        'grpBusqueda
        '
        Me.grpBusqueda.Controls.Add(Me.rbtnPlacaTracto)
        Me.grpBusqueda.Controls.Add(Me.rbtnDescripcion)
        Me.grpBusqueda.Controls.Add(Me.btnConsultar)
        Me.grpBusqueda.Controls.Add(Me.chkTodos)
        Me.grpBusqueda.Controls.Add(Me.grpBFecha)
        Me.grpBusqueda.Controls.Add(Me.rbtnCodigo)
        Me.grpBusqueda.Controls.Add(Me.txtBusqueda)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(1414, 98)
        Me.grpBusqueda.TabIndex = 1
        Me.grpBusqueda.TabStop = false
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'rbtnPlacaTracto
        '
        Me.rbtnPlacaTracto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.rbtnPlacaTracto.AutoSize = true
        Me.rbtnPlacaTracto.Location = New System.Drawing.Point(1251, 69)
        Me.rbtnPlacaTracto.Name = "rbtnPlacaTracto"
        Me.rbtnPlacaTracto.Size = New System.Drawing.Size(88, 19)
        Me.rbtnPlacaTracto.TabIndex = 36
        Me.rbtnPlacaTracto.Text = "Placa Tracto"
        Me.rbtnPlacaTracto.UseVisualStyleBackColor = true
        '
        'rbtnDescripcion
        '
        Me.rbtnDescripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.rbtnDescripcion.AutoSize = true
        Me.rbtnDescripcion.Location = New System.Drawing.Point(1159, 69)
        Me.rbtnDescripcion.Name = "rbtnDescripcion"
        Me.rbtnDescripcion.Size = New System.Drawing.Size(87, 19)
        Me.rbtnDescripcion.TabIndex = 35
        Me.rbtnDescripcion.Text = "Descripcion"
        Me.rbtnDescripcion.UseVisualStyleBackColor = true
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(1304, 17)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 41)
        Me.btnConsultar.TabIndex = 34
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = true
        '
        'chkTodos
        '
        Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.chkTodos.AutoSize = true
        Me.chkTodos.Location = New System.Drawing.Point(1197, 22)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(101, 19)
        Me.chkTodos.TabIndex = 34
        Me.chkTodos.Text = "Mostrar Todos"
        Me.chkTodos.UseVisualStyleBackColor = true
        '
        'grpBFecha
        '
        Me.grpBFecha.Controls.Add(Me.rbtnFecSalida)
        Me.grpBFecha.Controls.Add(Me.rbtnFecLlegada)
        Me.grpBFecha.Controls.Add(Me.acFecha)
        Me.grpBFecha.Location = New System.Drawing.Point(8, 15)
        Me.grpBFecha.Name = "grpBFecha"
        Me.grpBFecha.Size = New System.Drawing.Size(554, 43)
        Me.grpBFecha.TabIndex = 32
        Me.grpBFecha.TabStop = false
        '
        'rbtnFecSalida
        '
        Me.rbtnFecSalida.AutoSize = true
        Me.rbtnFecSalida.Checked = true
        Me.rbtnFecSalida.Location = New System.Drawing.Point(6, 17)
        Me.rbtnFecSalida.Name = "rbtnFecSalida"
        Me.rbtnFecSalida.Size = New System.Drawing.Size(90, 19)
        Me.rbtnFecSalida.TabIndex = 33
        Me.rbtnFecSalida.TabStop = true
        Me.rbtnFecSalida.Text = "Fecha Salida"
        Me.rbtnFecSalida.UseVisualStyleBackColor = true
        '
        'rbtnFecLlegada
        '
        Me.rbtnFecLlegada.AutoSize = true
        Me.rbtnFecLlegada.Location = New System.Drawing.Point(104, 17)
        Me.rbtnFecLlegada.Name = "rbtnFecLlegada"
        Me.rbtnFecLlegada.Size = New System.Drawing.Size(100, 19)
        Me.rbtnFecLlegada.TabIndex = 32
        Me.rbtnFecLlegada.Text = "Fecha Llegada"
        Me.rbtnFecLlegada.UseVisualStyleBackColor = true
        '
        'acFecha
        '
        Me.acFecha.ACFecha_A = New Date(2025, 11, 26, 8, 50, 37, 706)
        Me.acFecha.ACFecha_De = New Date(2025, 11, 26, 8, 50, 37, 705)
        Me.acFecha.ACFechaObligatoria = true
        Me.acFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
        Me.acFecha.ACHoyChecked = false
        Me.acFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.acFecha.Location = New System.Drawing.Point(217, 0)
        Me.acFecha.MaximumSize = New System.Drawing.Size(337, 43)
        Me.acFecha.MinimumSize = New System.Drawing.Size(337, 43)
        Me.acFecha.Name = "acFecha"
        Me.acFecha.Size = New System.Drawing.Size(337, 43)
        Me.acFecha.TabIndex = 25
        Me.acFecha.TabStop = false
        '
        'rbtnCodigo
        '
        Me.rbtnCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.rbtnCodigo.AutoSize = true
        Me.rbtnCodigo.Checked = true
        Me.rbtnCodigo.Location = New System.Drawing.Point(1088, 69)
        Me.rbtnCodigo.Name = "rbtnCodigo"
        Me.rbtnCodigo.Size = New System.Drawing.Size(64, 19)
        Me.rbtnCodigo.TabIndex = 30
        Me.rbtnCodigo.TabStop = true
        Me.rbtnCodigo.Text = "Codigo"
        Me.rbtnCodigo.UseVisualStyleBackColor = true
        '
        'txtBusqueda
        '
        Me.txtBusqueda.ACActivarAyudaAuto = false
        Me.txtBusqueda.ACLongitudAceptada = 0
        Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda.Location = New System.Drawing.Point(8, 67)
        Me.txtBusqueda.MaxLength = 32767
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(1068, 23)
        Me.txtBusqueda.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtBusqueda, "Para abrir el documento presione <F4>")
        '
        'C1FlexGrid7
        '
        Me.C1FlexGrid7.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FlexGrid7.Location = New System.Drawing.Point(0, 0)
        Me.C1FlexGrid7.Name = "C1FlexGrid7"
        Me.C1FlexGrid7.Rows.Count = 2
        Me.C1FlexGrid7.Rows.DefaultSize = 18
        Me.C1FlexGrid7.Size = New System.Drawing.Size(742, 317)
        Me.C1FlexGrid7.StyleInfo = resources.GetString("C1FlexGrid7.StyleInfo")
        Me.C1FlexGrid7.TabIndex = 11
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel7.Text = "of {0}"
        Me.ToolStripLabel7.ToolTipText = "Total number of items"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox7
        '
        Me.ToolStripTextBox7.AccessibleName = "Position"
        Me.ToolStripTextBox7.AutoSize = false
        Me.ToolStripTextBox7.Name = "ToolStripTextBox7"
        Me.ToolStripTextBox7.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox7.ToolTipText = "Current position"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(6, 25)
        '
        'acTool
        '
        Me.acTool.ACBtnAnularEnabled = false
        Me.acTool.ACBtnAnularVisible = false
        Me.acTool.ACBtnBuscarEnabled = false
        Me.acTool.ACBtnBuscarVisible = false
        Me.acTool.ACBtnCancelarEnabled = false
        Me.acTool.ACBtnCancelarVisible = false
        Me.acTool.ACBtnEliminarEnabled = false
        Me.acTool.ACBtnEliminarVisible = false
        Me.acTool.ACBtnGrabarEnabled = false
        Me.acTool.ACBtnGrabarVisible = false
        Me.acTool.ACBtnImprimirEnabled = false
        Me.acTool.ACBtnImprimirVisible = false
        Me.acTool.ACBtnRehusarEnabled = false
        Me.acTool.ACBtnRehusarVisible = false
        Me.acTool.ACBtnReporteEnabled = false
        Me.acTool.ACBtnReporteVisible = false
        Me.acTool.ACBtnSalirEnabled = false
        Me.acTool.ACBtnSalirText = "&Salir"
        Me.acTool.ACBtnSalirVisible = false
        Me.acTool.ACBtnVolverEnabled = false
        Me.acTool.ACBtnVolverVisible = false
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabar
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnPreview, Me.actsbtnQuitarAnulado, Me.tsbtnLiquidacion})
        Me.acTool.Location = New System.Drawing.Point(0, 648)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(1416, 56)
        Me.acTool.TabIndex = 2
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'tsbtnPreview
        '
        Me.tsbtnPreview.AutoSize = false
        Me.tsbtnPreview.Image = Global.ACPTransportes.My.Resources.Resources.PrintPreview_32x32
        Me.tsbtnPreview.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbtnPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtnPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnPreview.Name = "tsbBoton"
        Me.tsbtnPreview.Size = New System.Drawing.Size(84, 53)
        Me.tsbtnPreview.Text = "Previsualizar"
        Me.tsbtnPreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbtnPreview.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.tsbtnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnPreview.Visible = false
        '
        'actsbtnQuitarAnulado
        '
        Me.actsbtnQuitarAnulado.AutoSize = false
        Me.actsbtnQuitarAnulado.Image = Global.ACPTransportes.My.Resources.Resources.aceptar_32x32
        Me.actsbtnQuitarAnulado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.actsbtnQuitarAnulado.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.actsbtnQuitarAnulado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.actsbtnQuitarAnulado.Name = "tsbBoton"
        Me.actsbtnQuitarAnulado.Size = New System.Drawing.Size(82, 53)
        Me.actsbtnQuitarAnulado.Text = "Activar Viaje"
        Me.actsbtnQuitarAnulado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.actsbtnQuitarAnulado.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.actsbtnQuitarAnulado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbtnLiquidacion
        '
        Me.tsbtnLiquidacion.AutoSize = false
        Me.tsbtnLiquidacion.Image = Global.ACPTransportes.My.Resources.Resources.ACGrabarCerrar_32x32
        Me.tsbtnLiquidacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsbtnLiquidacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtnLiquidacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnLiquidacion.Name = "tsbBoton"
        Me.tsbtnLiquidacion.Size = New System.Drawing.Size(82, 53)
        Me.tsbtnLiquidacion.Text = "Liquidación"
        Me.tsbtnLiquidacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbtnLiquidacion.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.tsbtnLiquidacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Administración de Viajes"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 10!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(1416, 29)
        Me.acpnlTitulo.TabIndex = 0
        '
        'PrintDocument1
        '
        '
        'FViajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1416, 704)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.acTool)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "FViajes"
        Me.Text = "Administración de Viajes"
        Me.tabDatos.ResumeLayout(false)
        Me.tabDatos.PerformLayout
        Me.tcnDetalle.ResumeLayout(false)
        Me.tpgVehiRanfla.ResumeLayout(false)
        Me.pblVehiRanfla.ResumeLayout(false)
        Me.tscBase.ContentPanel.ResumeLayout(false)
        Me.tscBase.ResumeLayout(false)
        Me.tscBase.PerformLayout
        Me.pnlDatos.ResumeLayout(false)
        Me.pnlPresupuesto.ResumeLayout(false)
        Me.pnlPresupuesto.PerformLayout
        CType(Me.c1grdGastoInicial,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bnavPresupuesto,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavPresupuesto.ResumeLayout(false)
        Me.bnavPresupuesto.PerformLayout
        Me.pnlGuias.ResumeLayout(false)
        Me.pnlGuias.PerformLayout
        CType(Me.c1grdGuiaRemision,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        CType(Me.bnavGuiaRemision,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavGuiaRemision.ResumeLayout(false)
        Me.bnavGuiaRemision.PerformLayout
        Me.pnlDatosBase.ResumeLayout(false)
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.grpVehiculo.ResumeLayout(false)
        Me.grpVehiculo.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.tpgConsCombustible.ResumeLayout(false)
        Me.pnlConsCombustible.ResumeLayout(false)
        Me.pnlConsCombustible.PerformLayout
        CType(Me.c1grdConsCombustible,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bnavConsCombustible,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavConsCombustible.ResumeLayout(false)
        Me.bnavConsCombustible.PerformLayout
        Me.tpgConsumoAdBlue.ResumeLayout(false)
        Me.pnlConsumoAdBlue.ResumeLayout(false)
        Me.pnlConsumoAdBlue.PerformLayout
        CType(Me.c1grdConsumoAdBlue,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bnavConsumoAdBlue,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavConsumoAdBlue.ResumeLayout(false)
        Me.bnavConsumoAdBlue.PerformLayout
        Me.tpgGastos.ResumeLayout(false)
        Me.pnlGastos.ResumeLayout(false)
        Me.pnlGastos.PerformLayout
        CType(Me.c1grdGastViajes,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bnavGastos,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavGastos.ResumeLayout(false)
        Me.bnavGastos.PerformLayout
        Me.tpgFletes.ResumeLayout(false)
        Me.pnlFletes.ResumeLayout(false)
        Me.pnlFletes.PerformLayout
        Me.SplitContainer3.Panel1.ResumeLayout(false)
        Me.SplitContainer3.Panel2.ResumeLayout(false)
        Me.SplitContainer3.Panel2.PerformLayout
        CType(Me.SplitContainer3,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer3.ResumeLayout(false)
        CType(Me.c1grdFletes,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip3.ResumeLayout(false)
        Me.ToolStrip3.PerformLayout
        CType(Me.bnavFletes,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavFletes.ResumeLayout(false)
        Me.bnavFletes.PerformLayout
        Me.tpgPresupuesto.ResumeLayout(false)
        Me.pnlIngEgre.ResumeLayout(false)
        Me.SplitContainer2.Panel1.ResumeLayout(false)
        Me.SplitContainer2.Panel1.PerformLayout
        Me.SplitContainer2.Panel2.ResumeLayout(false)
        Me.SplitContainer2.Panel2.PerformLayout
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer2.ResumeLayout(false)
        CType(Me.c1grdIngEgre,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip4.ResumeLayout(false)
        Me.ToolStrip4.PerformLayout
        CType(Me.bnavIngEgre,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavIngEgre.ResumeLayout(false)
        Me.bnavIngEgre.PerformLayout
        CType(Me.c1grdRecEmitir,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip5.ResumeLayout(false)
        Me.ToolStrip5.PerformLayout
        CType(Me.bnavRecEmitir,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavRecEmitir.ResumeLayout(false)
        Me.bnavRecEmitir.PerformLayout
        Me.tpgNeumaticos.ResumeLayout(false)
        Me.pnlInvNeumaticos.ResumeLayout(false)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        CType(Me.c1grdInvNeumaticos,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        CType(Me.bnavNeumaticos,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavNeumaticos.ResumeLayout(false)
        Me.bnavNeumaticos.PerformLayout
        Me.pnlInciNeumatico.ResumeLayout(false)
        Me.pnlInciNeumatico.PerformLayout
        CType(Me.c1grdInciNeumatico,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bnavInciNeumaticos,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavInciNeumaticos.ResumeLayout(false)
        Me.bnavInciNeumaticos.PerformLayout
        Me.tpgIncidencias.ResumeLayout(false)
        Me.pnlIncidencias.ResumeLayout(false)
        Me.pnlIncidencias.PerformLayout
        CType(Me.c1grdInciViajes,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bnavInicidencias,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavInicidencias.ResumeLayout(false)
        Me.bnavInicidencias.PerformLayout
        Me.tpgResumen.ResumeLayout(false)
        Me.grpLiq.ResumeLayout(false)
        Me.grpLiq.PerformLayout
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.grpRutas.ResumeLayout(false)
        Me.grpRutas.PerformLayout
        CType(Me.c1grdRutas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bnavRutas,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavRutas.ResumeLayout(false)
        Me.bnavRutas.PerformLayout
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.GroupBox6.ResumeLayout(false)
        Me.GroupBox6.PerformLayout
        Me.GroupBox5.ResumeLayout(false)
        Me.GroupBox5.PerformLayout
        Me.grpCombustible.ResumeLayout(false)
        Me.grpCombustible.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.tabMantenimiento.ResumeLayout(false)
        Me.tabBusqueda.ResumeLayout(false)
        Me.tabBusqueda.PerformLayout
        CType(Me.c1grdBusqueda,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bnavBusqueda,System.ComponentModel.ISupportInitialize).EndInit
        Me.bnavBusqueda.ResumeLayout(false)
        Me.bnavBusqueda.PerformLayout
        Me.grpBusqueda.ResumeLayout(false)
        Me.grpBusqueda.PerformLayout
        Me.grpBFecha.ResumeLayout(false)
        Me.grpBFecha.PerformLayout
        CType(Me.C1FlexGrid7,System.ComponentModel.ISupportInitialize).EndInit
        Me.acTool.ResumeLayout(false)
        Me.acTool.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
    Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
    Private WithEvents tabBusqueda As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents c1grdBusqueda As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavBusqueda As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents grpBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
    Friend WithEvents C1FlexGrid7 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox7 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
    Friend WithEvents acFecha As ACControles.ACFecha
    Friend WithEvents pnlPresupuesto As System.Windows.Forms.Panel
    Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
    Friend WithEvents actxnGastonInicial As ACControles.ACTextBoxNumerico
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents bnavPresupuesto As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents rbtnCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents grpBFecha As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnFecSalida As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFecLlegada As System.Windows.Forms.RadioButton
    Private WithEvents tcnDetalle As Crownwood.DotNetMagic.Controls.TabControl
    Private WithEvents tpgFletes As Crownwood.DotNetMagic.Controls.TabPage
    Private WithEvents tpgPresupuesto As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents pnlFletes As System.Windows.Forms.Panel
    Friend WithEvents c1grdFletes As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavFletes As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AcPanelCaption2 As ACControles.ACPanelCaption
    Friend WithEvents tsbtnAddNewFlete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnFQuitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tpgIncidencias As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents tpgConsCombustible As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents tpgConsumoAdBlue As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents tpgGastos As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents pnlIncidencias As System.Windows.Forms.Panel
    Friend WithEvents c1grdInciViajes As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavInicidencias As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox3 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnIVAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnIVQuitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents AcPanelCaption3 As ACControles.ACPanelCaption
    Friend WithEvents pnlConsCombustible As System.Windows.Forms.Panel
    Friend WithEvents pnlConsumoAdBlue As System.Windows.Forms.Panel
    Friend WithEvents bnavConsCombustible As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton17 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton18 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox4 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton19 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton20 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnCCAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnCCQuitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents AcPanelCaption4 As ACControles.ACPanelCaption
    Friend WithEvents tpgNeumaticos As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents tpgVehiRanfla As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents pblVehiRanfla As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grpVehiculo As System.Windows.Forms.GroupBox
    Friend WithEvents pnlGastos As System.Windows.Forms.Panel
    Friend WithEvents c1grdGastViajes As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavGastos As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton23 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton24 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox5 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton25 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton26 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnGVAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnGVQuitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents AcPanelCaption5 As ACControles.ACPanelCaption
    Friend WithEvents pnlInvNeumaticos As System.Windows.Forms.Panel
    Friend WithEvents c1grdInvNeumaticos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavNeumaticos As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel8 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton35 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton36 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox8 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton43 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton44 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AcPanelCaption7 As ACControles.ACPanelCaption
    Friend WithEvents txtVehCertificado As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtVehPlaca As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtVehCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtConLicencia As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtConNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtRanCertificado As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtRanPlaca As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtRanCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpConFecNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbMarca As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbRanMarca As System.Windows.Forms.ComboBox
    Friend WithEvents txtVIGlosa As System.Windows.Forms.TextBox
    Friend WithEvents pnlInciNeumatico As System.Windows.Forms.Panel
    Friend WithEvents c1grdInciNeumatico As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavInciNeumaticos As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel9 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton16 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox9 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton21 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton22 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AcPanelCaption8 As ACControles.ACPanelCaption
    Friend WithEvents tsbtnAgregarIncNeumaticos As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tsbtnLiquidacion As ACControles.ACToolStripButton
    Friend WithEvents tsbtnPreview As ACControles.ACToolStripButton
    Friend WithEvents tpgResumen As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents actxnPagoConductor As ACControles.ACTextBoxNumerico
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents pnlIngEgre As System.Windows.Forms.Panel
    Friend WithEvents c1grdIngEgre As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavIngEgre As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel11 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton37 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton38 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox11 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator32 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton39 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton40 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator33 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnRecAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnRecQuitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents AcPanelCaption10 As ACControles.ACPanelCaption
    Friend WithEvents ToolStripSeparator29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpLiq As System.Windows.Forms.GroupBox
    Friend WithEvents actxnRecibosIngreso As ACControles.ACTextBoxNumerico
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btnCalLiqConductor As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents actxnPendiente As ACControles.ACTextBoxNumerico
    Friend WithEvents tscBase As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents actxnGastosConductor As ACControles.ACTextBoxNumerico
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents acvTracto As ACControles.ACVehiculo
    Friend WithEvents acvRanfla As ACControles.ACVehiculo
    Friend WithEvents tsbtnQuitarIncNeumaticos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnRepIngre As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlDatosBase As System.Windows.Forms.Panel
    Friend WithEvents tsbtnCModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnGVModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator43 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator35 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator34 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator37 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator38 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator41 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator42 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents rbtnDescripcion As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPlacaTracto As System.Windows.Forms.RadioButton
    Friend WithEvents tsbtnAgregarFlete As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlGuias As System.Windows.Forms.Panel
    Friend WithEvents c1grdGuiaRemision As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavGuiaRemision As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel10 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator44 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox10 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator45 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton27 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton28 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator46 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnGuiaGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents AcPanelCaption9 As ACControles.ACPanelCaption
    Friend WithEvents tsbtnPrAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator47 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnPrQuitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents c1grdGastoInicial As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStripSeparator49 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnModFlete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator50 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbTipoGuia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFlete As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents actxnRecibosEgreso As ACControles.ACTextBoxNumerico
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents actxnConsumoCombustible As ACControles.ACTextBoxNumerico
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents actxnSaldo As ACControles.ACTextBoxNumerico
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents actxnPendiente2 As ACControles.ACTextBoxNumerico
    Friend WithEvents btnModVehiculo As System.Windows.Forms.Button
    Friend WithEvents btnGenRecibo As System.Windows.Forms.Button
    Friend WithEvents grpRutas As System.Windows.Forms.GroupBox
    Friend WithEvents c1grdRutas As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavRutas As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton30 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton31 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox6 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton32 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton33 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator36 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AcPanelCaption6 As ACControles.ACPanelCaption
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents c1grdRecEmitir As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavRecEmitir As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents actsbtnQuitarAnulado As ACControles.ACToolStripButton
    Friend WithEvents tsbtnPrModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnCCModFecha As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnRModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnQuitarLiquidacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbGEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtFleObs As System.Windows.Forms.TextBox
    Friend WithEvents AcPanelCaption11 As ACControles.ACPanelCaption
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnFleGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel12 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscmbImpresora As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnImprimirRec As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel13 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscmbImpresoraRec As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents AcPanelCaption12 As ACControles.ACPanelCaption
    Friend WithEvents bnavConsumoAdBlue As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel14 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton29 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton34 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox12 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator39 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton41 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton42 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator40 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnCABAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnCABQuitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator48 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnCABModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator51 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton48 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton52 As System.Windows.Forms.ToolStripButton
    Friend WithEvents c1grdConsCombustible As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStripLabel15 As ToolStripLabel
    Friend WithEvents c1grdConsumoAdBlue As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents dtpFecScan As DateTimePicker
    Friend WithEvents actxnCombScanner As ACControles.ACTextBoxNumerico
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents actxnKmScanner As ACControles.ACTextBoxNumerico
    Friend WithEvents Label17 As Label
    Friend WithEvents btnReporte As Button
    Friend WithEvents txtViajexConductor As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents grpCombustible As GroupBox
    Friend WithEvents actxnCombRealizado As ACControles.ACTextBoxNumerico
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents actxnConsRealizado As ACControles.ACTextBoxNumerico
    Friend WithEvents Label11 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtViajeXvehiculo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents dtpFecLlegada As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label27 As Label
    Friend WithEvents actxnKmAnterior As ACControles.ACTextBoxNumerico
    Friend WithEvents Label31 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents actxnVehKilometraje As ACControles.ACTextBoxNumerico
    Friend WithEvents Label16 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents actxnKmDiferencia As ACControles.ACTextBoxNumerico
    Friend WithEvents Label32 As Label
    Friend WithEvents actxnKilometraje As ACControles.ACTextBoxNumerico
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpFecSalida As DateTimePicker
    Friend WithEvents dtpHorSalida As DateTimePicker
    Friend WithEvents dtpHorLlegada As DateTimePicker
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents actxnVehKilometrajeMantenimiento As ACControles.ACTextBoxNumerico
    Friend WithEvents Label42 As Label
    Friend WithEvents actxnVehKilometrajeMantenimiento_ As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents actxnAddBlueRealizado As ACControles.ACTextBoxNumerico
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents actxnConsAddBlueRealizado As ACControles.ACTextBoxNumerico
    Friend WithEvents Label45 As Label
    Friend WithEvents actxnConsumoAddBlue As ACControles.ACTextBoxNumerico
    Friend WithEvents Label46 As Label
End Class
