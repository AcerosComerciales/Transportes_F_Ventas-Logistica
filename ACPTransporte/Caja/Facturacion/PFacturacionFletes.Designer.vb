<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PFacturacionFletes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PFacturacionFletes))
        Me.tabMantenimiento = New Crownwood.DotNetMagic.Controls.TabControl()
        Me.tabDatos = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.spcCabecera = New System.Windows.Forms.SplitContainer()
        Me.pnlItem = New System.Windows.Forms.Panel()
        Me.cmbProdUnidad = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.actxnValorReferencial = New ACControles.ACTextBoxNumerico()
        Me.btnMenos = New System.Windows.Forms.Button()
        Me.btnMas = New System.Windows.Forms.Button()
        Me.txtProdUnidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.actxnPrecio = New ACControles.ACTextBoxNumerico()
        Me.txtOpcion = New System.Windows.Forms.TextBox()
        Me.actxnSubImporte = New ACControles.ACTextBoxNumerico()
        Me.actxnProdCantidad = New ACControles.ACTextBoxNumerico()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtProdDescripcion = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.grpCabCuerpo = New System.Windows.Forms.GroupBox()
        Me.chkEditarFactura = New System.Windows.Forms.CheckBox()
        Me.chkValorReferencialEnFactura = New System.Windows.Forms.CheckBox()
        Me.dtpFecPlazo = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.actxnPlazo = New ACControles.ACTextBoxNumerico()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbCondicionPago = New System.Windows.Forms.ComboBox()
        Me.chkDetraccion = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbDetraccion = New System.Windows.Forms.ComboBox()
        Me.chkspot = New System.Windows.Forms.CheckBox()
        Me.chkIlncluidoIGV = New System.Windows.Forms.CheckBox()
        Me.grpFlete = New System.Windows.Forms.GroupBox()
        Me.actxaFlete = New ACControles.ACTextBoxAyuda()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpFecFacturacion = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkPermiteFecha = New System.Windows.Forms.CheckBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.cmbDirecciones = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnNuevoCliente = New System.Windows.Forms.Button()
        Me.cmbEntrega = New System.Windows.Forms.ComboBox()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.actxaCliRazonSocial = New ACControles.ACTextBoxAyuda()
        Me.lblNroDocumento = New System.Windows.Forms.Label()
        Me.actxaCliRuc = New ACControles.ACTextBoxAyuda()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpgFletes = New System.Windows.Forms.TabPage()
        Me.c1grdFletes = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavFletes = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator44 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox10 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator45 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton27 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton28 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator46 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tstFletes = New System.Windows.Forms.ToolStrip()
        Me.tsbtnAddFletes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnQuitarFletes = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption1 = New ACControles.ACPanelCaption()
        Me.tpgNotasCredito = New System.Windows.Forms.TabPage()
        Me.c1grdNCreditos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton19 = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption5 = New ACControles.ACPanelCaption()
        Me.tpgPagos = New System.Windows.Forms.TabPage()
        Me.c1grdPagos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BindingNavigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton20 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton21 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox4 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton22 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton23 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton24 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton25 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton26 = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption6 = New ACControles.ACPanelCaption()
        Me.spcDetalle = New System.Windows.Forms.SplitContainer()
        Me.c1grdDetalle = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.c1grdEmpresas = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.AcPanelCaption2 = New ACControles.ACPanelCaption()
        Me.c1grdGuias = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.bnavGuias = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton17 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton18 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcPanelCaption4 = New ACControles.ACPanelCaption()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtTexto = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnGenerar = New System.Windows.Forms.ToolStripButton()
        Me.AcPanelCaption3 = New ACControles.ACPanelCaption()
        Me.bnavProductos = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslblSon = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbImpresora = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.txtobservacionanulacion = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNotaPie = New System.Windows.Forms.TextBox()
        Me.grpDetPago = New System.Windows.Forms.GroupBox()
        Me.actxnTotalDetraccion = New ACControles.ACTextBoxNumerico()
        Me.txtphantom_RUTAS_ID = New System.Windows.Forms.TextBox()
        Me.lblTotalDetraccion = New System.Windows.Forms.Label()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lbligv = New System.Windows.Forms.Label()
        Me.actxnImporte = New ACControles.ACTextBoxNumerico()
        Me.actxnIGV = New ACControles.ACTextBoxNumerico()
        Me.actxnTotalPagar = New ACControles.ACTextBoxNumerico()
        Me.lblTotalPagar = New System.Windows.Forms.Label()
        Me.actxnTCVentaSunat = New ACControles.ACTextBoxNumerico()
        Me.lblVenDolarSunat = New System.Windows.Forms.Label()
        Me.actxnTipoCambio = New ACControles.ACTextBoxNumerico()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDocumentoFacturar = New System.Windows.Forms.ComboBox()
        Me.actxaCotiz = New ACControles.ACTextBoxAyuda()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.actxnNumeroFacturar = New ACControles.ACTextBoxNumerico()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSerieFacturar = New System.Windows.Forms.ComboBox()
        Me.tabBusqueda = New Crownwood.DotNetMagic.Controls.TabPage()
        Me.c1grdBusqueda = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grpBusqueda = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.rbtnNroCotizacion = New System.Windows.Forms.RadioButton()
        Me.rbtnCliente = New System.Windows.Forms.RadioButton()
        Me.grpCliente = New System.Windows.Forms.GroupBox()
        Me.txtBusqueda = New ACControles.ACTextBoxAyuda()
        Me.grpDocumentos = New System.Windows.Forms.GroupBox()
        Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.txtBusNumero = New ACControles.ACTextBoxAyuda()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.AcFecha = New ACControles.ACFecha(Me.components)
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
        Me.tsbtnExcel = New System.Windows.Forms.ToolStripButton()
        Me.actxtDireccionDestino = New System.Windows.Forms.TextBox()
        Me.actxtDireccionOrigen = New System.Windows.Forms.TextBox()
        Me.acpnlTitulo = New ACControles.ACPanelCaption()
        Me.acTool = New ACControles.ACToolBarMantHorizontalNew(Me.components)
        Me.actsbtnModFecha = New ACControles.ACToolStripButton(Me.components)
        Me.acbtnCreaAnulado = New ACControles.ACToolStripButton(Me.components)
        Me.acbtnSeleccionar = New ACControles.ACToolStripButton(Me.components)
        Me.actsbtnPrevisualizar = New ACControles.ACToolStripButton(Me.components)
        Me.actsbtn_CapturaPantalla = New System.Windows.Forms.ToolStripButton()
        Me.eprError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.bnavConsumoAdBlue = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton29 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton34 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox12 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel14 = New System.Windows.Forms.ToolStripLabel()
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
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.c1grdIngresoCompra = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.AcPanelCaption12 = New ACControles.ACPanelCaption()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.AcPanelCaption10 = New ACControles.ACPanelCaption()
        Me.c1grGuiasCompraDet = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtphantom_ubigo_origen = New System.Windows.Forms.TextBox()
        Me.txtphantom_ubigo_destino = New System.Windows.Forms.TextBox()
        Me.txtphantom_rutas_nombre = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.txtVEHIC_Certificado = New System.Windows.Forms.TextBox()
        Me.tabMantenimiento.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.pnlDetalle.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.spcCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcCabecera.Panel1.SuspendLayout()
        Me.spcCabecera.Panel2.SuspendLayout()
        Me.spcCabecera.SuspendLayout()
        Me.pnlItem.SuspendLayout()
        Me.grpCabCuerpo.SuspendLayout()
        Me.grpFlete.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpgFletes.SuspendLayout()
        CType(Me.c1grdFletes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavFletes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavFletes.SuspendLayout()
        Me.tstFletes.SuspendLayout()
        Me.tpgNotasCredito.SuspendLayout()
        CType(Me.c1grdNCreditos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.tpgPagos.SuspendLayout()
        CType(Me.c1grdPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator2.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.spcDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcDetalle.Panel1.SuspendLayout()
        Me.spcDetalle.Panel2.SuspendLayout()
        Me.spcDetalle.SuspendLayout()
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.c1grdEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1grdGuias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavGuias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavGuias.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.bnavProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavProductos.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.grpDetPago.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.tabBusqueda.SuspendLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBusqueda.SuspendLayout()
        Me.grpCliente.SuspendLayout()
        Me.grpDocumentos.SuspendLayout()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavBusqueda.SuspendLayout()
        Me.acTool.SuspendLayout()
        CType(Me.eprError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnavConsumoAdBlue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.c1grdIngresoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1grGuiasCompraDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMantenimiento.Location = New System.Drawing.Point(0, 25)
        Me.tabMantenimiento.MediaPlayerDockSides = False
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.OfficeDockSides = False
        Me.tabMantenimiento.SelectedIndex = 0
        Me.tabMantenimiento.ShowDropSelect = False
        Me.tabMantenimiento.Size = New System.Drawing.Size(1377, 797)
        Me.tabMantenimiento.TabIndex = 1
        Me.tabMantenimiento.TabPages.AddRange(New Crownwood.DotNetMagic.Controls.TabPage() {Me.tabDatos, Me.tabBusqueda})
        Me.tabMantenimiento.TextTips = True
        '
        'tabDatos
        '
        Me.tabDatos.Controls.Add(Me.pnlDatos)
        Me.tabDatos.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Location = New System.Drawing.Point(1, 1)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabDatos.SelectTextColor = System.Drawing.Color.Empty
        Me.tabDatos.Size = New System.Drawing.Size(1375, 772)
        Me.tabDatos.TabIndex = 4
        Me.tabDatos.Title = "Datos"
        Me.tabDatos.ToolTip = "Datos"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.pnlDetalle)
        Me.pnlDatos.Controls.Add(Me.pnlPie)
        Me.pnlDatos.Controls.Add(Me.pnlCabecera)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1375, 772)
        Me.pnlDatos.TabIndex = 1
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Controls.Add(Me.SplitContainer2)
        Me.pnlDetalle.Controls.Add(Me.bnavProductos)
        Me.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetalle.Location = New System.Drawing.Point(0, 34)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(1375, 639)
        Me.pnlDetalle.TabIndex = 5
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.spcCabecera)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.spcDetalle)
        Me.SplitContainer2.Size = New System.Drawing.Size(1375, 614)
        Me.SplitContainer2.SplitterDistance = 319
        Me.SplitContainer2.TabIndex = 0
        '
        'spcCabecera
        '
        Me.spcCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcCabecera.Location = New System.Drawing.Point(0, 0)
        Me.spcCabecera.Name = "spcCabecera"
        '
        'spcCabecera.Panel1
        '
        Me.spcCabecera.Panel1.Controls.Add(Me.pnlItem)
        Me.spcCabecera.Panel1.Controls.Add(Me.grpCabCuerpo)
        '
        'spcCabecera.Panel2
        '
        Me.spcCabecera.Panel2.Controls.Add(Me.TabControl1)
        Me.spcCabecera.Size = New System.Drawing.Size(1375, 319)
        Me.spcCabecera.SplitterDistance = 972
        Me.spcCabecera.TabIndex = 2
        '
        'pnlItem
        '
        Me.pnlItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.pnlItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlItem.Controls.Add(Me.cmbProdUnidad)
        Me.pnlItem.Controls.Add(Me.Label19)
        Me.pnlItem.Controls.Add(Me.actxnValorReferencial)
        Me.pnlItem.Controls.Add(Me.btnMenos)
        Me.pnlItem.Controls.Add(Me.btnMas)
        Me.pnlItem.Controls.Add(Me.txtProdUnidad)
        Me.pnlItem.Controls.Add(Me.Label2)
        Me.pnlItem.Controls.Add(Me.actxnPrecio)
        Me.pnlItem.Controls.Add(Me.txtOpcion)
        Me.pnlItem.Controls.Add(Me.actxnSubImporte)
        Me.pnlItem.Controls.Add(Me.actxnProdCantidad)
        Me.pnlItem.Controls.Add(Me.Label10)
        Me.pnlItem.Controls.Add(Me.Label9)
        Me.pnlItem.Controls.Add(Me.lblCantidad)
        Me.pnlItem.Controls.Add(Me.txtProdDescripcion)
        Me.pnlItem.Controls.Add(Me.Label17)
        Me.pnlItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlItem.Location = New System.Drawing.Point(0, 155)
        Me.pnlItem.Name = "pnlItem"
        Me.pnlItem.Size = New System.Drawing.Size(972, 164)
        Me.pnlItem.TabIndex = 0
        '
        'cmbProdUnidad
        '
        Me.cmbProdUnidad.FormattingEnabled = True
        Me.cmbProdUnidad.Location = New System.Drawing.Point(132, 12)
        Me.cmbProdUnidad.Name = "cmbProdUnidad"
        Me.cmbProdUnidad.Size = New System.Drawing.Size(151, 23)
        Me.cmbProdUnidad.TabIndex = 19
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(613, -1)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 13)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Valor Referencial"
        '
        'actxnValorReferencial
        '
        Me.actxnValorReferencial.ACDecimales = 8
        Me.actxnValorReferencial.ACEnteros = 9
        Me.actxnValorReferencial.ACEstandar = ACControles.ACEstandaresFormato.ACGeneral
        Me.actxnValorReferencial.ACFormato = "########0.00"
        Me.actxnValorReferencial.ACNegativo = True
        Me.actxnValorReferencial.ACValue = New Decimal(New Integer() {0, 0, 0, 524288})
        Me.actxnValorReferencial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnValorReferencial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnValorReferencial.Location = New System.Drawing.Point(615, 12)
        Me.actxnValorReferencial.MaxLength = 12
        Me.actxnValorReferencial.Name = "actxnValorReferencial"
        Me.actxnValorReferencial.Size = New System.Drawing.Size(100, 23)
        Me.actxnValorReferencial.TabIndex = 17
        Me.actxnValorReferencial.Tag = "V"
        Me.actxnValorReferencial.Text = "0.00"
        Me.actxnValorReferencial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnMenos
        '
        Me.btnMenos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenos.Location = New System.Drawing.Point(938, 60)
        Me.btnMenos.Name = "btnMenos"
        Me.btnMenos.Size = New System.Drawing.Size(26, 23)
        Me.btnMenos.TabIndex = 16
        Me.btnMenos.Text = "-"
        Me.btnMenos.UseVisualStyleBackColor = True
        '
        'btnMas
        '
        Me.btnMas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMas.Location = New System.Drawing.Point(938, 37)
        Me.btnMas.Name = "btnMas"
        Me.btnMas.Size = New System.Drawing.Size(26, 23)
        Me.btnMas.TabIndex = 15
        Me.btnMas.Text = "+"
        Me.btnMas.UseVisualStyleBackColor = True
        '
        'txtProdUnidad
        '
        Me.txtProdUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProdUnidad.Location = New System.Drawing.Point(300, 12)
        Me.txtProdUnidad.MaxLength = 10
        Me.txtProdUnidad.Name = "txtProdUnidad"
        Me.txtProdUnidad.Size = New System.Drawing.Size(138, 23)
        Me.txtProdUnidad.TabIndex = 3
        Me.txtProdUnidad.Tag = "EV"
        Me.txtProdUnidad.Text = "NO SE USA "
        Me.txtProdUnidad.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(129, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Unidad"
        '
        'actxnPrecio
        '
        Me.actxnPrecio.ACDecimales = 8
        Me.actxnPrecio.ACEnteros = 9
        Me.actxnPrecio.ACEstandar = ACControles.ACEstandaresFormato.ACGeneral
        Me.actxnPrecio.ACFormato = "########0.00000000"
        Me.actxnPrecio.ACNegativo = True
        Me.actxnPrecio.ACValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.actxnPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnPrecio.Location = New System.Drawing.Point(721, 12)
        Me.actxnPrecio.MaxLength = 12
        Me.actxnPrecio.Name = "actxnPrecio"
        Me.actxnPrecio.Size = New System.Drawing.Size(100, 23)
        Me.actxnPrecio.TabIndex = 7
        Me.actxnPrecio.Tag = "V"
        Me.actxnPrecio.Text = "0.00000000"
        Me.actxnPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOpcion
        '
        Me.txtOpcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOpcion.BackColor = System.Drawing.Color.Gainsboro
        Me.txtOpcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpcion.Location = New System.Drawing.Point(939, 12)
        Me.txtOpcion.MaxLength = 1
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.Size = New System.Drawing.Size(25, 23)
        Me.txtOpcion.TabIndex = 10
        '
        'actxnSubImporte
        '
        Me.actxnSubImporte.ACEnteros = 9
        Me.actxnSubImporte.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnSubImporte.ACNegativo = True
        Me.actxnSubImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnSubImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnSubImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnSubImporte.Location = New System.Drawing.Point(833, 12)
        Me.actxnSubImporte.MaxLength = 12
        Me.actxnSubImporte.Name = "actxnSubImporte"
        Me.actxnSubImporte.ReadOnly = True
        Me.actxnSubImporte.Size = New System.Drawing.Size(100, 23)
        Me.actxnSubImporte.TabIndex = 9
        Me.actxnSubImporte.Tag = "V"
        Me.actxnSubImporte.Text = "0.00"
        Me.actxnSubImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnProdCantidad
        '
        Me.actxnProdCantidad.ACDecimales = 4
        Me.actxnProdCantidad.ACEnteros = 9
        Me.actxnProdCantidad.ACFormato = "###,###,##0.0000"
        Me.actxnProdCantidad.ACNegativo = True
        Me.actxnProdCantidad.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnProdCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnProdCantidad.Location = New System.Drawing.Point(5, 12)
        Me.actxnProdCantidad.MaxLength = 18
        Me.actxnProdCantidad.Name = "actxnProdCantidad"
        Me.actxnProdCantidad.Size = New System.Drawing.Size(110, 23)
        Me.actxnProdCantidad.TabIndex = 1
        Me.actxnProdCantidad.Tag = "EV"
        Me.actxnProdCantidad.Text = "0.0000"
        Me.actxnProdCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(837, -1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Sub Importe"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(725, -1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Pr&ecio"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblCantidad.ForeColor = System.Drawing.Color.White
        Me.lblCantidad.Location = New System.Drawing.Point(14, -1)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(57, 13)
        Me.lblCantidad.TabIndex = 0
        Me.lblCantidad.Text = "C&antidad"
        '
        'txtProdDescripcion
        '
        Me.txtProdDescripcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProdDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProdDescripcion.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProdDescripcion.Location = New System.Drawing.Point(125, 41)
        Me.txtProdDescripcion.MaxLength = 2000
        Me.txtProdDescripcion.Multiline = True
        Me.txtProdDescripcion.Name = "txtProdDescripcion"
        Me.txtProdDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProdDescripcion.Size = New System.Drawing.Size(808, 115)
        Me.txtProdDescripcion.TabIndex = 5
        Me.txtProdDescripcion.Tag = "V"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(41, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Descripción :"
        '
        'grpCabCuerpo
        '
        Me.grpCabCuerpo.Controls.Add(Me.chkEditarFactura)
        Me.grpCabCuerpo.Controls.Add(Me.chkValorReferencialEnFactura)
        Me.grpCabCuerpo.Controls.Add(Me.dtpFecPlazo)
        Me.grpCabCuerpo.Controls.Add(Me.Label15)
        Me.grpCabCuerpo.Controls.Add(Me.Label18)
        Me.grpCabCuerpo.Controls.Add(Me.actxnPlazo)
        Me.grpCabCuerpo.Controls.Add(Me.Label13)
        Me.grpCabCuerpo.Controls.Add(Me.cmbCondicionPago)
        Me.grpCabCuerpo.Controls.Add(Me.chkDetraccion)
        Me.grpCabCuerpo.Controls.Add(Me.Label16)
        Me.grpCabCuerpo.Controls.Add(Me.cmbDetraccion)
        Me.grpCabCuerpo.Controls.Add(Me.chkspot)
        Me.grpCabCuerpo.Controls.Add(Me.chkIlncluidoIGV)
        Me.grpCabCuerpo.Controls.Add(Me.grpFlete)
        Me.grpCabCuerpo.Controls.Add(Me.txtDireccion)
        Me.grpCabCuerpo.Controls.Add(Me.cmbDirecciones)
        Me.grpCabCuerpo.Controls.Add(Me.Label7)
        Me.grpCabCuerpo.Controls.Add(Me.Label6)
        Me.grpCabCuerpo.Controls.Add(Me.btnNuevoCliente)
        Me.grpCabCuerpo.Controls.Add(Me.cmbEntrega)
        Me.grpCabCuerpo.Controls.Add(Me.btnClean)
        Me.grpCabCuerpo.Controls.Add(Me.actxaCliRazonSocial)
        Me.grpCabCuerpo.Controls.Add(Me.lblNroDocumento)
        Me.grpCabCuerpo.Controls.Add(Me.actxaCliRuc)
        Me.grpCabCuerpo.Controls.Add(Me.lblMoneda)
        Me.grpCabCuerpo.Controls.Add(Me.cmbMoneda)
        Me.grpCabCuerpo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCabCuerpo.Location = New System.Drawing.Point(0, 0)
        Me.grpCabCuerpo.Name = "grpCabCuerpo"
        Me.grpCabCuerpo.Size = New System.Drawing.Size(972, 155)
        Me.grpCabCuerpo.TabIndex = 1
        Me.grpCabCuerpo.TabStop = False
        Me.grpCabCuerpo.Tag = "EVO"
        '
        'chkEditarFactura
        '
        Me.chkEditarFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEditarFactura.AutoSize = True
        Me.chkEditarFactura.Location = New System.Drawing.Point(658, 128)
        Me.chkEditarFactura.Name = "chkEditarFactura"
        Me.chkEditarFactura.Size = New System.Drawing.Size(107, 19)
        Me.chkEditarFactura.TabIndex = 66
        Me.chkEditarFactura.Text = "Direccion Mod."
        Me.chkEditarFactura.UseVisualStyleBackColor = True
        '
        'chkValorReferencialEnFactura
        '
        Me.chkValorReferencialEnFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkValorReferencialEnFactura.AutoSize = True
        Me.chkValorReferencialEnFactura.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkValorReferencialEnFactura.Enabled = False
        Me.chkValorReferencialEnFactura.Location = New System.Drawing.Point(849, 125)
        Me.chkValorReferencialEnFactura.Name = "chkValorReferencialEnFactura"
        Me.chkValorReferencialEnFactura.Size = New System.Drawing.Size(117, 19)
        Me.chkValorReferencialEnFactura.TabIndex = 37
        Me.chkValorReferencialEnFactura.Text = "V. Ref. en Factura"
        Me.chkValorReferencialEnFactura.UseVisualStyleBackColor = True
        '
        'dtpFecPlazo
        '
        Me.dtpFecPlazo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecPlazo.Enabled = False
        Me.dtpFecPlazo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecPlazo.Location = New System.Drawing.Point(519, 124)
        Me.dtpFecPlazo.Name = "dtpFecPlazo"
        Me.dtpFecPlazo.Size = New System.Drawing.Size(101, 23)
        Me.dtpFecPlazo.TabIndex = 36
        Me.dtpFecPlazo.Tag = "E"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(469, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 15)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Fecha :"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Enabled = False
        Me.Label18.Location = New System.Drawing.Point(394, 128)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 15)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Plazo :"
        '
        'actxnPlazo
        '
        Me.actxnPlazo.ACDecimales = 0
        Me.actxnPlazo.ACEnteros = 9
        Me.actxnPlazo.ACFormato = "########0"
        Me.actxnPlazo.ACNegativo = True
        Me.actxnPlazo.ACValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.actxnPlazo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnPlazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnPlazo.Enabled = False
        Me.actxnPlazo.Location = New System.Drawing.Point(439, 124)
        Me.actxnPlazo.MaxLength = 12
        Me.actxnPlazo.Name = "actxnPlazo"
        Me.actxnPlazo.ReadOnly = True
        Me.actxnPlazo.Size = New System.Drawing.Size(26, 23)
        Me.actxnPlazo.TabIndex = 34
        Me.actxnPlazo.Text = "0"
        Me.actxnPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 130)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 15)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Cond. Pago:"
        '
        'cmbCondicionPago
        '
        Me.cmbCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondicionPago.Enabled = False
        Me.cmbCondicionPago.FormattingEnabled = True
        Me.cmbCondicionPago.Location = New System.Drawing.Point(86, 125)
        Me.cmbCondicionPago.Name = "cmbCondicionPago"
        Me.cmbCondicionPago.Size = New System.Drawing.Size(198, 23)
        Me.cmbCondicionPago.TabIndex = 32
        Me.cmbCondicionPago.Tag = "ECO"
        '
        'chkDetraccion
        '
        Me.chkDetraccion.AutoSize = True
        Me.chkDetraccion.Location = New System.Drawing.Point(512, 100)
        Me.chkDetraccion.Name = "chkDetraccion"
        Me.chkDetraccion.Size = New System.Drawing.Size(89, 19)
        Me.chkDetraccion.TabIndex = 30
        Me.chkDetraccion.Text = "Detracción: "
        Me.chkDetraccion.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(661, 162)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(17, 15)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "%"
        '
        'cmbDetraccion
        '
        Me.cmbDetraccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDetraccion.Enabled = False
        Me.cmbDetraccion.FormattingEnabled = True
        Me.cmbDetraccion.Items.AddRange(New Object() {"0", "4", "10", "12"})
        Me.cmbDetraccion.Location = New System.Drawing.Point(603, 97)
        Me.cmbDetraccion.Name = "cmbDetraccion"
        Me.cmbDetraccion.Size = New System.Drawing.Size(52, 23)
        Me.cmbDetraccion.TabIndex = 28
        Me.cmbDetraccion.Tag = "ECO"
        '
        'chkspot
        '
        Me.chkspot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkspot.AutoSize = True
        Me.chkspot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkspot.Checked = True
        Me.chkspot.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkspot.Location = New System.Drawing.Point(775, 100)
        Me.chkspot.Name = "chkspot"
        Me.chkspot.Size = New System.Drawing.Size(95, 19)
        Me.chkspot.TabIndex = 26
        Me.chkspot.Text = "Agregar Spot"
        Me.chkspot.UseVisualStyleBackColor = True
        '
        'chkIlncluidoIGV
        '
        Me.chkIlncluidoIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIlncluidoIGV.AutoSize = True
        Me.chkIlncluidoIGV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIlncluidoIGV.Enabled = False
        Me.chkIlncluidoIGV.Location = New System.Drawing.Point(869, 101)
        Me.chkIlncluidoIGV.Name = "chkIlncluidoIGV"
        Me.chkIlncluidoIGV.Size = New System.Drawing.Size(99, 19)
        Me.chkIlncluidoIGV.TabIndex = 17
        Me.chkIlncluidoIGV.Text = "Incluido I.G.V."
        Me.chkIlncluidoIGV.UseVisualStyleBackColor = True
        '
        'grpFlete
        '
        Me.grpFlete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFlete.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.grpFlete.Controls.Add(Me.actxaFlete)
        Me.grpFlete.Controls.Add(Me.Label14)
        Me.grpFlete.Controls.Add(Me.dtpFecFacturacion)
        Me.grpFlete.Controls.Add(Me.Label1)
        Me.grpFlete.Controls.Add(Me.chkPermiteFecha)
        Me.grpFlete.Location = New System.Drawing.Point(0, -4)
        Me.grpFlete.Name = "grpFlete"
        Me.grpFlete.Size = New System.Drawing.Size(973, 48)
        Me.grpFlete.TabIndex = 24
        Me.grpFlete.TabStop = False
        '
        'actxaFlete
        '
        Me.actxaFlete.ACActivarAyudaAuto = False
        Me.actxaFlete.ACLongitudAceptada = 0
        Me.actxaFlete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaFlete.Location = New System.Drawing.Point(89, 20)
        Me.actxaFlete.MaxLength = 14
        Me.actxaFlete.Name = "actxaFlete"
        Me.actxaFlete.Size = New System.Drawing.Size(111, 23)
        Me.actxaFlete.TabIndex = 1
        Me.actxaFlete.Tag = "EVO"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(33, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 17)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Flete :"
        '
        'dtpFecFacturacion
        '
        Me.dtpFecFacturacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecFacturacion.Enabled = False
        Me.dtpFecFacturacion.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dtpFecFacturacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFacturacion.Location = New System.Drawing.Point(723, 15)
        Me.dtpFecFacturacion.Name = "dtpFecFacturacion"
        Me.dtpFecFacturacion.Size = New System.Drawing.Size(113, 26)
        Me.dtpFecFacturacion.TabIndex = 14
        Me.dtpFecFacturacion.Tag = "E"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(607, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 19)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Fecha Emi&sion :"
        '
        'chkPermiteFecha
        '
        Me.chkPermiteFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPermiteFecha.ForeColor = System.Drawing.Color.White
        Me.chkPermiteFecha.Location = New System.Drawing.Point(844, 11)
        Me.chkPermiteFecha.Name = "chkPermiteFecha"
        Me.chkPermiteFecha.Size = New System.Drawing.Size(122, 34)
        Me.chkPermiteFecha.TabIndex = 25
        Me.chkPermiteFecha.Text = "Permitir un fecha Inferior a la ultima Factura"
        Me.chkPermiteFecha.UseVisualStyleBackColor = True
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.Location = New System.Drawing.Point(89, 72)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(874, 23)
        Me.txtDireccion.TabIndex = 21
        '
        'cmbDirecciones
        '
        Me.cmbDirecciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDirecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDirecciones.DropDownWidth = 250
        Me.cmbDirecciones.FormattingEnabled = True
        Me.cmbDirecciones.Location = New System.Drawing.Point(89, 71)
        Me.cmbDirecciones.Name = "cmbDirecciones"
        Me.cmbDirecciones.Size = New System.Drawing.Size(874, 23)
        Me.cmbDirecciones.TabIndex = 20
        Me.cmbDirecciones.Tag = "EO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 15)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Direccion :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(216, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Cond&ición :"
        '
        'btnNuevoCliente
        '
        Me.btnNuevoCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevoCliente.Image = Global.ACPTransportes.My.Resources.Resources.ACNuevo_16x16
        Me.btnNuevoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoCliente.Location = New System.Drawing.Point(852, 43)
        Me.btnNuevoCliente.Name = "btnNuevoCliente"
        Me.btnNuevoCliente.Size = New System.Drawing.Size(68, 28)
        Me.btnNuevoCliente.TabIndex = 3
        Me.btnNuevoCliente.Text = "Nuevo "
        Me.btnNuevoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevoCliente.UseVisualStyleBackColor = True
        '
        'cmbEntrega
        '
        Me.cmbEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntrega.FormattingEnabled = True
        Me.cmbEntrega.Location = New System.Drawing.Point(290, 99)
        Me.cmbEntrega.Name = "cmbEntrega"
        Me.cmbEntrega.Size = New System.Drawing.Size(145, 23)
        Me.cmbEntrega.TabIndex = 10
        Me.cmbEntrega.Tag = "ECO"
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClean.Image = Global.ACPTransportes.My.Resources.Resources.Delete_16x16
        Me.btnClean.Location = New System.Drawing.Point(927, 43)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(36, 28)
        Me.btnClean.TabIndex = 4
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'actxaCliRazonSocial
        '
        Me.actxaCliRazonSocial.ACActivarAyudaAuto = False
        Me.actxaCliRazonSocial.ACLongitudAceptada = 0
        Me.actxaCliRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxaCliRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaCliRazonSocial.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxaCliRazonSocial.Location = New System.Drawing.Point(226, 46)
        Me.actxaCliRazonSocial.MaxLength = 80
        Me.actxaCliRazonSocial.Name = "actxaCliRazonSocial"
        Me.actxaCliRazonSocial.Size = New System.Drawing.Size(615, 24)
        Me.actxaCliRazonSocial.TabIndex = 2
        Me.actxaCliRazonSocial.Tag = "EVO"
        '
        'lblNroDocumento
        '
        Me.lblNroDocumento.AutoSize = True
        Me.lblNroDocumento.Location = New System.Drawing.Point(29, 53)
        Me.lblNroDocumento.Name = "lblNroDocumento"
        Me.lblNroDocumento.Size = New System.Drawing.Size(50, 15)
        Me.lblNroDocumento.TabIndex = 0
        Me.lblNroDocumento.Text = "Cliente :"
        '
        'actxaCliRuc
        '
        Me.actxaCliRuc.ACActivarAyudaAuto = False
        Me.actxaCliRuc.ACLongitudAceptada = 0
        Me.actxaCliRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxaCliRuc.Location = New System.Drawing.Point(89, 45)
        Me.actxaCliRuc.MaxLength = 14
        Me.actxaCliRuc.Name = "actxaCliRuc"
        Me.actxaCliRuc.Size = New System.Drawing.Size(111, 23)
        Me.actxaCliRuc.TabIndex = 1
        Me.actxaCliRuc.Tag = "EVO"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(21, 104)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(57, 15)
        Me.lblMoneda.TabIndex = 7
        Me.lblMoneda.Text = "&Moneda :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.DropDownWidth = 250
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(86, 99)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(114, 23)
        Me.cmbMoneda.TabIndex = 8
        Me.cmbMoneda.Tag = "EO"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpgFletes)
        Me.TabControl1.Controls.Add(Me.tpgNotasCredito)
        Me.TabControl1.Controls.Add(Me.tpgPagos)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(399, 319)
        Me.TabControl1.TabIndex = 22
        '
        'tpgFletes
        '
        Me.tpgFletes.Controls.Add(Me.c1grdFletes)
        Me.tpgFletes.Controls.Add(Me.bnavFletes)
        Me.tpgFletes.Controls.Add(Me.tstFletes)
        Me.tpgFletes.Controls.Add(Me.AcPanelCaption1)
        Me.tpgFletes.Location = New System.Drawing.Point(4, 24)
        Me.tpgFletes.Name = "tpgFletes"
        Me.tpgFletes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgFletes.Size = New System.Drawing.Size(391, 291)
        Me.tpgFletes.TabIndex = 0
        Me.tpgFletes.Text = "Fletes"
        Me.tpgFletes.UseVisualStyleBackColor = True
        '
        'c1grdFletes
        '
        Me.c1grdFletes.AllowAddNew = True
        Me.c1grdFletes.AllowDelete = True
        Me.c1grdFletes.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdFletes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdFletes.Location = New System.Drawing.Point(3, 53)
        Me.c1grdFletes.Name = "c1grdFletes"
        Me.c1grdFletes.Rows.Count = 2
        Me.c1grdFletes.Rows.DefaultSize = 20
        Me.c1grdFletes.Size = New System.Drawing.Size(385, 210)
        Me.c1grdFletes.StyleInfo = resources.GetString("c1grdFletes.StyleInfo")
        Me.c1grdFletes.TabIndex = 22
        '
        'bnavFletes
        '
        Me.bnavFletes.AddNewItem = Nothing
        Me.bnavFletes.CountItem = Me.ToolStripLabel10
        Me.bnavFletes.DeleteItem = Nothing
        Me.bnavFletes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavFletes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bnavFletes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.ToolStripButton8, Me.ToolStripSeparator44, Me.ToolStripTextBox10, Me.ToolStripLabel10, Me.ToolStripSeparator45, Me.ToolStripButton27, Me.ToolStripButton28, Me.ToolStripSeparator46, Me.tsbtnImprimir})
        Me.bnavFletes.Location = New System.Drawing.Point(3, 263)
        Me.bnavFletes.MoveFirstItem = Me.ToolStripButton7
        Me.bnavFletes.MoveLastItem = Me.ToolStripButton28
        Me.bnavFletes.MoveNextItem = Me.ToolStripButton27
        Me.bnavFletes.MovePreviousItem = Me.ToolStripButton8
        Me.bnavFletes.Name = "bnavFletes"
        Me.bnavFletes.PositionItem = Me.ToolStripTextBox10
        Me.bnavFletes.Size = New System.Drawing.Size(385, 25)
        Me.bnavFletes.TabIndex = 23
        Me.bnavFletes.Text = "bnavFletes"
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel10.Text = "de {0}"
        Me.ToolStripLabel10.ToolTipText = "Total number of items"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Move first"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "Move previous"
        '
        'ToolStripSeparator44
        '
        Me.ToolStripSeparator44.Name = "ToolStripSeparator44"
        Me.ToolStripSeparator44.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox10
        '
        Me.ToolStripTextBox10.AccessibleName = "Position"
        Me.ToolStripTextBox10.AutoSize = False
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
        Me.ToolStripButton27.Image = CType(resources.GetObject("ToolStripButton27.Image"), System.Drawing.Image)
        Me.ToolStripButton27.Name = "ToolStripButton27"
        Me.ToolStripButton27.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton27.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton27.Text = "Move next"
        '
        'ToolStripButton28
        '
        Me.ToolStripButton28.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton28.Image = CType(resources.GetObject("ToolStripButton28.Image"), System.Drawing.Image)
        Me.ToolStripButton28.Name = "ToolStripButton28"
        Me.ToolStripButton28.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton28.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton28.Text = "Move last"
        '
        'ToolStripSeparator46
        '
        Me.ToolStripSeparator46.Name = "ToolStripSeparator46"
        Me.ToolStripSeparator46.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnImprimir
        '
        Me.tsbtnImprimir.Image = Global.ACPTransportes.My.Resources.Resources.ACImprimirRed_16x16
        Me.tsbtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnImprimir.Name = "tsbtnImprimir"
        Me.tsbtnImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbtnImprimir.Text = "Imprimir"
        '
        'tstFletes
        '
        Me.tstFletes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tstFletes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAddFletes, Me.ToolStripSeparator5, Me.tsbtnQuitarFletes})
        Me.tstFletes.Location = New System.Drawing.Point(3, 28)
        Me.tstFletes.Name = "tstFletes"
        Me.tstFletes.Size = New System.Drawing.Size(385, 25)
        Me.tstFletes.TabIndex = 24
        Me.tstFletes.Text = "ToolStrip2"
        '
        'tsbtnAddFletes
        '
        Me.tsbtnAddFletes.Image = Global.ACPTransportes.My.Resources.Resources.ACAdd_16x16
        Me.tsbtnAddFletes.Name = "tsbtnAddFletes"
        Me.tsbtnAddFletes.RightToLeftAutoMirrorImage = True
        Me.tsbtnAddFletes.Size = New System.Drawing.Size(69, 22)
        Me.tsbtnAddFletes.Text = "Agregar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnQuitarFletes
        '
        Me.tsbtnQuitarFletes.Image = Global.ACPTransportes.My.Resources.Resources.ACAnular_16x16
        Me.tsbtnQuitarFletes.Name = "tsbtnQuitarFletes"
        Me.tsbtnQuitarFletes.RightToLeftAutoMirrorImage = True
        Me.tsbtnQuitarFletes.Size = New System.Drawing.Size(60, 22)
        Me.tsbtnQuitarFletes.Text = "Quitar"
        '
        'AcPanelCaption1
        '
        Me.AcPanelCaption1.ACCaption = "Fletes"
        Me.AcPanelCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption1.Location = New System.Drawing.Point(3, 3)
        Me.AcPanelCaption1.Name = "AcPanelCaption1"
        Me.AcPanelCaption1.Size = New System.Drawing.Size(385, 25)
        Me.AcPanelCaption1.TabIndex = 25
        '
        'tpgNotasCredito
        '
        Me.tpgNotasCredito.Controls.Add(Me.c1grdNCreditos)
        Me.tpgNotasCredito.Controls.Add(Me.BindingNavigator1)
        Me.tpgNotasCredito.Controls.Add(Me.ToolStrip2)
        Me.tpgNotasCredito.Controls.Add(Me.AcPanelCaption5)
        Me.tpgNotasCredito.Location = New System.Drawing.Point(4, 24)
        Me.tpgNotasCredito.Name = "tpgNotasCredito"
        Me.tpgNotasCredito.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgNotasCredito.Size = New System.Drawing.Size(391, 291)
        Me.tpgNotasCredito.TabIndex = 1
        Me.tpgNotasCredito.Text = "Notas de Credito"
        Me.tpgNotasCredito.UseVisualStyleBackColor = True
        '
        'c1grdNCreditos
        '
        Me.c1grdNCreditos.AllowAddNew = True
        Me.c1grdNCreditos.AllowDelete = True
        Me.c1grdNCreditos.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdNCreditos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdNCreditos.Location = New System.Drawing.Point(3, 53)
        Me.c1grdNCreditos.Name = "c1grdNCreditos"
        Me.c1grdNCreditos.Rows.Count = 2
        Me.c1grdNCreditos.Rows.DefaultSize = 20
        Me.c1grdNCreditos.Size = New System.Drawing.Size(385, 210)
        Me.c1grdNCreditos.StyleInfo = resources.GetString("c1grdNCreditos.StyleInfo")
        Me.c1grdNCreditos.TabIndex = 22
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.CountItem = Me.ToolStripLabel3
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton9, Me.ToolStripButton10, Me.ToolStripSeparator6, Me.ToolStripTextBox2, Me.ToolStripLabel3, Me.ToolStripSeparator7, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator8, Me.ToolStripButton13})
        Me.BindingNavigator1.Location = New System.Drawing.Point(3, 263)
        Me.BindingNavigator1.MoveFirstItem = Me.ToolStripButton9
        Me.BindingNavigator1.MoveLastItem = Me.ToolStripButton12
        Me.BindingNavigator1.MoveNextItem = Me.ToolStripButton11
        Me.BindingNavigator1.MovePreviousItem = Me.ToolStripButton10
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.ToolStripTextBox2
        Me.BindingNavigator1.Size = New System.Drawing.Size(385, 25)
        Me.BindingNavigator1.TabIndex = 23
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel3.Text = "de {0}"
        Me.ToolStripLabel3.ToolTipText = "Total number of items"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton9.Text = "Move first"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton10.Text = "Move previous"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.AccessibleName = "Position"
        Me.ToolStripTextBox2.AutoSize = False
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox2.Text = "0"
        Me.ToolStripTextBox2.ToolTipText = "Current position"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton11.Text = "Move next"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton12.Text = "Move last"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.Image = Global.ACPTransportes.My.Resources.Resources.ACImprimirRed_16x16
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(73, 22)
        Me.ToolStripButton13.Text = "Imprimir"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton14, Me.ToolStripSeparator12, Me.ToolStripButton19})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 28)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(385, 25)
        Me.ToolStrip2.TabIndex = 24
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.Image = Global.ACPTransportes.My.Resources.Resources.ACAdd_16x16
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton14.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButton14.Text = "Agregar"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton19
        '
        Me.ToolStripButton19.Image = Global.ACPTransportes.My.Resources.Resources.ACAnular_16x16
        Me.ToolStripButton19.Name = "ToolStripButton19"
        Me.ToolStripButton19.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton19.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton19.Text = "Quitar"
        '
        'AcPanelCaption5
        '
        Me.AcPanelCaption5.ACCaption = "Notas de Credito"
        Me.AcPanelCaption5.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption5.Location = New System.Drawing.Point(3, 3)
        Me.AcPanelCaption5.Name = "AcPanelCaption5"
        Me.AcPanelCaption5.Size = New System.Drawing.Size(385, 25)
        Me.AcPanelCaption5.TabIndex = 25
        '
        'tpgPagos
        '
        Me.tpgPagos.Controls.Add(Me.c1grdPagos)
        Me.tpgPagos.Controls.Add(Me.BindingNavigator2)
        Me.tpgPagos.Controls.Add(Me.ToolStrip3)
        Me.tpgPagos.Controls.Add(Me.AcPanelCaption6)
        Me.tpgPagos.Location = New System.Drawing.Point(4, 24)
        Me.tpgPagos.Name = "tpgPagos"
        Me.tpgPagos.Size = New System.Drawing.Size(391, 291)
        Me.tpgPagos.TabIndex = 2
        Me.tpgPagos.Text = "Pagos"
        Me.tpgPagos.UseVisualStyleBackColor = True
        '
        'c1grdPagos
        '
        Me.c1grdPagos.AllowAddNew = True
        Me.c1grdPagos.AllowDelete = True
        Me.c1grdPagos.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdPagos.Location = New System.Drawing.Point(0, 50)
        Me.c1grdPagos.Name = "c1grdPagos"
        Me.c1grdPagos.Rows.Count = 2
        Me.c1grdPagos.Rows.DefaultSize = 20
        Me.c1grdPagos.Size = New System.Drawing.Size(391, 216)
        Me.c1grdPagos.StyleInfo = resources.GetString("c1grdPagos.StyleInfo")
        Me.c1grdPagos.TabIndex = 26
        '
        'BindingNavigator2
        '
        Me.BindingNavigator2.AddNewItem = Nothing
        Me.BindingNavigator2.CountItem = Me.ToolStripLabel5
        Me.BindingNavigator2.DeleteItem = Nothing
        Me.BindingNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigator2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton20, Me.ToolStripButton21, Me.ToolStripSeparator13, Me.ToolStripTextBox4, Me.ToolStripLabel5, Me.ToolStripSeparator14, Me.ToolStripButton22, Me.ToolStripButton23, Me.ToolStripSeparator15, Me.ToolStripButton24})
        Me.BindingNavigator2.Location = New System.Drawing.Point(0, 266)
        Me.BindingNavigator2.MoveFirstItem = Me.ToolStripButton20
        Me.BindingNavigator2.MoveLastItem = Me.ToolStripButton23
        Me.BindingNavigator2.MoveNextItem = Me.ToolStripButton22
        Me.BindingNavigator2.MovePreviousItem = Me.ToolStripButton21
        Me.BindingNavigator2.Name = "BindingNavigator2"
        Me.BindingNavigator2.PositionItem = Me.ToolStripTextBox4
        Me.BindingNavigator2.Size = New System.Drawing.Size(391, 25)
        Me.BindingNavigator2.TabIndex = 27
        Me.BindingNavigator2.Text = "BindingNavigator2"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel5.Text = "de {0}"
        Me.ToolStripLabel5.ToolTipText = "Total number of items"
        '
        'ToolStripButton20
        '
        Me.ToolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton20.Image = CType(resources.GetObject("ToolStripButton20.Image"), System.Drawing.Image)
        Me.ToolStripButton20.Name = "ToolStripButton20"
        Me.ToolStripButton20.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton20.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton20.Text = "Move first"
        '
        'ToolStripButton21
        '
        Me.ToolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton21.Image = CType(resources.GetObject("ToolStripButton21.Image"), System.Drawing.Image)
        Me.ToolStripButton21.Name = "ToolStripButton21"
        Me.ToolStripButton21.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton21.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton21.Text = "Move previous"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox4
        '
        Me.ToolStripTextBox4.AccessibleName = "Position"
        Me.ToolStripTextBox4.AutoSize = False
        Me.ToolStripTextBox4.Name = "ToolStripTextBox4"
        Me.ToolStripTextBox4.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox4.Text = "0"
        Me.ToolStripTextBox4.ToolTipText = "Current position"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton22
        '
        Me.ToolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton22.Image = CType(resources.GetObject("ToolStripButton22.Image"), System.Drawing.Image)
        Me.ToolStripButton22.Name = "ToolStripButton22"
        Me.ToolStripButton22.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton22.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton22.Text = "Move next"
        '
        'ToolStripButton23
        '
        Me.ToolStripButton23.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton23.Image = CType(resources.GetObject("ToolStripButton23.Image"), System.Drawing.Image)
        Me.ToolStripButton23.Name = "ToolStripButton23"
        Me.ToolStripButton23.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton23.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton23.Text = "Move last"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton24
        '
        Me.ToolStripButton24.Image = Global.ACPTransportes.My.Resources.Resources.ACImprimirRed_16x16
        Me.ToolStripButton24.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton24.Name = "ToolStripButton24"
        Me.ToolStripButton24.Size = New System.Drawing.Size(73, 22)
        Me.ToolStripButton24.Text = "Imprimir"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton25, Me.ToolStripSeparator17, Me.ToolStripButton26})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(391, 25)
        Me.ToolStrip3.TabIndex = 28
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripButton25
        '
        Me.ToolStripButton25.Image = Global.ACPTransportes.My.Resources.Resources.ACAdd_16x16
        Me.ToolStripButton25.Name = "ToolStripButton25"
        Me.ToolStripButton25.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton25.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButton25.Text = "Agregar"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton26
        '
        Me.ToolStripButton26.Image = Global.ACPTransportes.My.Resources.Resources.ACAnular_16x16
        Me.ToolStripButton26.Name = "ToolStripButton26"
        Me.ToolStripButton26.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton26.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton26.Text = "Quitar"
        '
        'AcPanelCaption6
        '
        Me.AcPanelCaption6.ACCaption = "Pagos"
        Me.AcPanelCaption6.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption6.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption6.Name = "AcPanelCaption6"
        Me.AcPanelCaption6.Size = New System.Drawing.Size(391, 25)
        Me.AcPanelCaption6.TabIndex = 29
        '
        'spcDetalle
        '
        Me.spcDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcDetalle.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.spcDetalle.Location = New System.Drawing.Point(0, 0)
        Me.spcDetalle.Name = "spcDetalle"
        '
        'spcDetalle.Panel1
        '
        Me.spcDetalle.Panel1.Controls.Add(Me.c1grdDetalle)
        '
        'spcDetalle.Panel2
        '
        Me.spcDetalle.Panel2.Controls.Add(Me.SplitContainer3)
        Me.spcDetalle.Panel2.Controls.Add(Me.Panel2)
        Me.spcDetalle.Size = New System.Drawing.Size(1375, 291)
        Me.spcDetalle.SplitterDistance = 897
        Me.spcDetalle.TabIndex = 4
        '
        'c1grdDetalle
        '
        Me.c1grdDetalle.AutoClipboard = True
        Me.c1grdDetalle.BackColor = System.Drawing.Color.White
        Me.c1grdDetalle.ColumnInfo = "2,1,0,0,0,105,Columns:0{Width:18;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:107;Caption:""Codigo"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdDetalle.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdDetalle.Location = New System.Drawing.Point(0, 0)
        Me.c1grdDetalle.Name = "c1grdDetalle"
        Me.c1grdDetalle.Rows.Count = 2
        Me.c1grdDetalle.Rows.DefaultSize = 21
        Me.c1grdDetalle.Size = New System.Drawing.Size(897, 291)
        Me.c1grdDetalle.StyleInfo = resources.GetString("c1grdDetalle.StyleInfo")
        Me.c1grdDetalle.TabIndex = 1
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(200, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.c1grdEmpresas)
        Me.SplitContainer3.Panel1.Controls.Add(Me.AcPanelCaption2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.c1grdGuias)
        Me.SplitContainer3.Panel2.Controls.Add(Me.bnavGuias)
        Me.SplitContainer3.Panel2.Controls.Add(Me.AcPanelCaption4)
        Me.SplitContainer3.Size = New System.Drawing.Size(274, 291)
        Me.SplitContainer3.SplitterDistance = 131
        Me.SplitContainer3.TabIndex = 2
        '
        'c1grdEmpresas
        '
        Me.c1grdEmpresas.AllowAddNew = True
        Me.c1grdEmpresas.AllowDelete = True
        Me.c1grdEmpresas.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdEmpresas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdEmpresas.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdEmpresas.Location = New System.Drawing.Point(0, 18)
        Me.c1grdEmpresas.Name = "c1grdEmpresas"
        Me.c1grdEmpresas.Rows.Count = 2
        Me.c1grdEmpresas.Rows.DefaultSize = 18
        Me.c1grdEmpresas.Size = New System.Drawing.Size(274, 113)
        Me.c1grdEmpresas.StyleInfo = resources.GetString("c1grdEmpresas.StyleInfo")
        Me.c1grdEmpresas.TabIndex = 19
        '
        'AcPanelCaption2
        '
        Me.AcPanelCaption2.ACCaption = "Empresas"
        Me.AcPanelCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption2.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption2.Name = "AcPanelCaption2"
        Me.AcPanelCaption2.Size = New System.Drawing.Size(274, 18)
        Me.AcPanelCaption2.TabIndex = 22
        '
        'c1grdGuias
        '
        Me.c1grdGuias.AllowAddNew = True
        Me.c1grdGuias.AllowDelete = True
        Me.c1grdGuias.ColumnInfo = "2,1,0,0,0,90,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdGuias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdGuias.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.c1grdGuias.Location = New System.Drawing.Point(0, 18)
        Me.c1grdGuias.Name = "c1grdGuias"
        Me.c1grdGuias.Rows.Count = 2
        Me.c1grdGuias.Rows.DefaultSize = 18
        Me.c1grdGuias.Size = New System.Drawing.Size(274, 113)
        Me.c1grdGuias.StyleInfo = resources.GetString("c1grdGuias.StyleInfo")
        Me.c1grdGuias.TabIndex = 23
        '
        'bnavGuias
        '
        Me.bnavGuias.AddNewItem = Nothing
        Me.bnavGuias.CountItem = Me.ToolStripLabel4
        Me.bnavGuias.DeleteItem = Nothing
        Me.bnavGuias.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavGuias.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bnavGuias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton15, Me.ToolStripButton16, Me.ToolStripSeparator9, Me.ToolStripTextBox3, Me.ToolStripLabel4, Me.ToolStripSeparator10, Me.ToolStripButton17, Me.ToolStripButton18, Me.ToolStripSeparator11})
        Me.bnavGuias.Location = New System.Drawing.Point(0, 131)
        Me.bnavGuias.MoveFirstItem = Me.ToolStripButton15
        Me.bnavGuias.MoveLastItem = Me.ToolStripButton18
        Me.bnavGuias.MoveNextItem = Me.ToolStripButton17
        Me.bnavGuias.MovePreviousItem = Me.ToolStripButton16
        Me.bnavGuias.Name = "bnavGuias"
        Me.bnavGuias.PositionItem = Me.ToolStripTextBox3
        Me.bnavGuias.Size = New System.Drawing.Size(274, 25)
        Me.bnavGuias.TabIndex = 25
        Me.bnavGuias.Text = "BindingNavigator1"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel4.Text = "de {0}"
        Me.ToolStripLabel4.ToolTipText = "Total number of items"
        '
        'ToolStripButton15
        '
        Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton15.Image = CType(resources.GetObject("ToolStripButton15.Image"), System.Drawing.Image)
        Me.ToolStripButton15.Name = "ToolStripButton15"
        Me.ToolStripButton15.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton15.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton15.Text = "Move first"
        '
        'ToolStripButton16
        '
        Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton16.Image = CType(resources.GetObject("ToolStripButton16.Image"), System.Drawing.Image)
        Me.ToolStripButton16.Name = "ToolStripButton16"
        Me.ToolStripButton16.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton16.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton16.Text = "Move previous"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.AccessibleName = "Position"
        Me.ToolStripTextBox3.AutoSize = False
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox3.Text = "0"
        Me.ToolStripTextBox3.ToolTipText = "Current position"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton17
        '
        Me.ToolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton17.Image = CType(resources.GetObject("ToolStripButton17.Image"), System.Drawing.Image)
        Me.ToolStripButton17.Name = "ToolStripButton17"
        Me.ToolStripButton17.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton17.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton17.Text = "Move next"
        '
        'ToolStripButton18
        '
        Me.ToolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton18.Image = CType(resources.GetObject("ToolStripButton18.Image"), System.Drawing.Image)
        Me.ToolStripButton18.Name = "ToolStripButton18"
        Me.ToolStripButton18.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton18.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton18.Text = "Move last"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'AcPanelCaption4
        '
        Me.AcPanelCaption4.ACCaption = "Guias de Fletes"
        Me.AcPanelCaption4.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption4.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption4.Name = "AcPanelCaption4"
        Me.AcPanelCaption4.Size = New System.Drawing.Size(274, 18)
        Me.AcPanelCaption4.TabIndex = 24
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtTexto)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.AcPanelCaption3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 291)
        Me.Panel2.TabIndex = 1
        '
        'txtTexto
        '
        Me.txtTexto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTexto.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto.Location = New System.Drawing.Point(0, 18)
        Me.txtTexto.MaxLength = 250
        Me.txtTexto.Multiline = True
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTexto.Size = New System.Drawing.Size(200, 248)
        Me.txtTexto.TabIndex = 6
        Me.txtTexto.Tag = "V"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnGenerar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 266)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(200, 25)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtnGenerar
        '
        Me.tsbtnGenerar.Image = Global.ACPTransportes.My.Resources.Resources.ACAppProduccion_16x16
        Me.tsbtnGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGenerar.Name = "tsbtnGenerar"
        Me.tsbtnGenerar.Size = New System.Drawing.Size(68, 22)
        Me.tsbtnGenerar.Text = "Generar"
        '
        'AcPanelCaption3
        '
        Me.AcPanelCaption3.ACCaption = "Texto"
        Me.AcPanelCaption3.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption3.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption3.Name = "AcPanelCaption3"
        Me.AcPanelCaption3.Size = New System.Drawing.Size(200, 18)
        Me.AcPanelCaption3.TabIndex = 23
        '
        'bnavProductos
        '
        Me.bnavProductos.AddNewItem = Me.ToolStripButton1
        Me.bnavProductos.CountItem = Me.ToolStripLabel1
        Me.bnavProductos.DeleteItem = Me.ToolStripButton2
        Me.bnavProductos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavProductos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bnavProductos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2, Me.tslblSon, Me.tscmbImpresora, Me.ToolStripLabel2, Me.ToolStripSeparator4})
        Me.bnavProductos.Location = New System.Drawing.Point(0, 614)
        Me.bnavProductos.MoveFirstItem = Me.ToolStripButton3
        Me.bnavProductos.MoveLastItem = Me.ToolStripButton6
        Me.bnavProductos.MoveNextItem = Me.ToolStripButton5
        Me.bnavProductos.MovePreviousItem = Me.ToolStripButton4
        Me.bnavProductos.Name = "bnavProductos"
        Me.bnavProductos.PositionItem = Me.ToolStripTextBox1
        Me.bnavProductos.Size = New System.Drawing.Size(1375, 25)
        Me.bnavProductos.TabIndex = 2
        Me.bnavProductos.Text = "BindingNavigator1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Add new"
        Me.ToolStripButton1.Visible = False
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "de {0}"
        Me.ToolStripLabel1.ToolTipText = "Total number of items"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Delete"
        Me.ToolStripButton2.Visible = False
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Move first"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
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
        Me.ToolStripTextBox1.AutoSize = False
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
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Move next"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Move last"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tslblSon
        '
        Me.tslblSon.Name = "tslblSon"
        Me.tslblSon.Size = New System.Drawing.Size(47, 22)
        Me.tslblSon.Text = "Son: {0}"
        '
        'tscmbImpresora
        '
        Me.tscmbImpresora.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tscmbImpresora.Name = "tscmbImpresora"
        Me.tscmbImpresora.Size = New System.Drawing.Size(300, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripLabel2.Text = "Impresora :"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.txtobservacionanulacion)
        Me.pnlPie.Controls.Add(Me.Label20)
        Me.pnlPie.Controls.Add(Me.Label12)
        Me.pnlPie.Controls.Add(Me.txtObservaciones)
        Me.pnlPie.Controls.Add(Me.Label11)
        Me.pnlPie.Controls.Add(Me.txtNotaPie)
        Me.pnlPie.Controls.Add(Me.grpDetPago)
        Me.pnlPie.Controls.Add(Me.actxnTCVentaSunat)
        Me.pnlPie.Controls.Add(Me.lblVenDolarSunat)
        Me.pnlPie.Controls.Add(Me.actxnTipoCambio)
        Me.pnlPie.Controls.Add(Me.Label31)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 673)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1375, 99)
        Me.pnlPie.TabIndex = 0
        '
        'txtobservacionanulacion
        '
        Me.txtobservacionanulacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtobservacionanulacion.Location = New System.Drawing.Point(125, 63)
        Me.txtobservacionanulacion.MaxLength = 50
        Me.txtobservacionanulacion.Name = "txtobservacionanulacion"
        Me.txtobservacionanulacion.Size = New System.Drawing.Size(577, 23)
        Me.txtobservacionanulacion.TabIndex = 18
        Me.txtobservacionanulacion.Tag = "EV"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(111, 15)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "Motivo Anulacion : "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 15)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Observac. :"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Location = New System.Drawing.Point(78, 34)
        Me.txtObservaciones.MaxLength = 50
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(457, 23)
        Me.txtObservaciones.TabIndex = 8
        Me.txtObservaciones.Tag = "EV"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 15)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Nota al Pie :"
        '
        'txtNotaPie
        '
        Me.txtNotaPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotaPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotaPie.Location = New System.Drawing.Point(78, 2)
        Me.txtNotaPie.MaxLength = 50
        Me.txtNotaPie.Name = "txtNotaPie"
        Me.txtNotaPie.Size = New System.Drawing.Size(457, 23)
        Me.txtNotaPie.TabIndex = 4
        Me.txtNotaPie.Tag = "EV"
        '
        'grpDetPago
        '
        Me.grpDetPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.grpDetPago.Controls.Add(Me.actxnTotalDetraccion)
        Me.grpDetPago.Controls.Add(Me.txtphantom_RUTAS_ID)
        Me.grpDetPago.Controls.Add(Me.lblTotalDetraccion)
        Me.grpDetPago.Controls.Add(Me.lblImporte)
        Me.grpDetPago.Controls.Add(Me.lbligv)
        Me.grpDetPago.Controls.Add(Me.actxnImporte)
        Me.grpDetPago.Controls.Add(Me.actxnIGV)
        Me.grpDetPago.Controls.Add(Me.actxnTotalPagar)
        Me.grpDetPago.Controls.Add(Me.lblTotalPagar)
        Me.grpDetPago.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpDetPago.Location = New System.Drawing.Point(708, 0)
        Me.grpDetPago.Name = "grpDetPago"
        Me.grpDetPago.Size = New System.Drawing.Size(665, 97)
        Me.grpDetPago.TabIndex = 2
        Me.grpDetPago.TabStop = False
        '
        'actxnTotalDetraccion
        '
        Me.actxnTotalDetraccion.ACEnteros = 9
        Me.actxnTotalDetraccion.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTotalDetraccion.ACNegativo = True
        Me.actxnTotalDetraccion.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTotalDetraccion.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxnTotalDetraccion.Location = New System.Drawing.Point(81, 18)
        Me.actxnTotalDetraccion.MaxLength = 12
        Me.actxnTotalDetraccion.Name = "actxnTotalDetraccion"
        Me.actxnTotalDetraccion.ReadOnly = True
        Me.actxnTotalDetraccion.Size = New System.Drawing.Size(92, 26)
        Me.actxnTotalDetraccion.TabIndex = 7
        Me.actxnTotalDetraccion.Tag = "EVO"
        Me.actxnTotalDetraccion.Text = "0.00"
        Me.actxnTotalDetraccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtphantom_RUTAS_ID
        '
        Me.txtphantom_RUTAS_ID.Enabled = False
        Me.txtphantom_RUTAS_ID.Location = New System.Drawing.Point(429, 2)
        Me.txtphantom_RUTAS_ID.Name = "txtphantom_RUTAS_ID"
        Me.txtphantom_RUTAS_ID.Size = New System.Drawing.Size(100, 23)
        Me.txtphantom_RUTAS_ID.TabIndex = 18
        Me.txtphantom_RUTAS_ID.Visible = False
        '
        'lblTotalDetraccion
        '
        Me.lblTotalDetraccion.AutoSize = True
        Me.lblTotalDetraccion.ForeColor = System.Drawing.Color.White
        Me.lblTotalDetraccion.Location = New System.Drawing.Point(1, 24)
        Me.lblTotalDetraccion.Name = "lblTotalDetraccion"
        Me.lblTotalDetraccion.Size = New System.Drawing.Size(84, 15)
        Me.lblTotalDetraccion.TabIndex = 6
        Me.lblTotalDetraccion.Text = "Detracción: {0}"
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.ForeColor = System.Drawing.Color.White
        Me.lblImporte.Location = New System.Drawing.Point(176, 24)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(72, 15)
        Me.lblImporte.TabIndex = 0
        Me.lblImporte.Text = "Importe : {0}"
        '
        'lbligv
        '
        Me.lbligv.AutoSize = True
        Me.lbligv.ForeColor = System.Drawing.Color.White
        Me.lbligv.Location = New System.Drawing.Point(339, 24)
        Me.lbligv.Name = "lbligv"
        Me.lbligv.Size = New System.Drawing.Size(57, 15)
        Me.lbligv.TabIndex = 2
        Me.lbligv.Text = "I.G.V. : {0}"
        '
        'actxnImporte
        '
        Me.actxnImporte.ACEnteros = 9
        Me.actxnImporte.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnImporte.ACNegativo = True
        Me.actxnImporte.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnImporte.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxnImporte.Location = New System.Drawing.Point(247, 18)
        Me.actxnImporte.MaxLength = 12
        Me.actxnImporte.Name = "actxnImporte"
        Me.actxnImporte.ReadOnly = True
        Me.actxnImporte.Size = New System.Drawing.Size(92, 26)
        Me.actxnImporte.TabIndex = 1
        Me.actxnImporte.Tag = "EVO"
        Me.actxnImporte.Text = "0.00"
        Me.actxnImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnIGV
        '
        Me.actxnIGV.ACEnteros = 9
        Me.actxnIGV.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnIGV.ACNegativo = True
        Me.actxnIGV.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnIGV.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxnIGV.Location = New System.Drawing.Point(395, 18)
        Me.actxnIGV.MaxLength = 12
        Me.actxnIGV.Name = "actxnIGV"
        Me.actxnIGV.ReadOnly = True
        Me.actxnIGV.Size = New System.Drawing.Size(92, 26)
        Me.actxnIGV.TabIndex = 3
        Me.actxnIGV.Tag = "EVO"
        Me.actxnIGV.Text = "0.00"
        Me.actxnIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'actxnTotalPagar
        '
        Me.actxnTotalPagar.ACEnteros = 9
        Me.actxnTotalPagar.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTotalPagar.ACNegativo = True
        Me.actxnTotalPagar.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTotalPagar.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.actxnTotalPagar.Location = New System.Drawing.Point(571, 18)
        Me.actxnTotalPagar.MaxLength = 12
        Me.actxnTotalPagar.Name = "actxnTotalPagar"
        Me.actxnTotalPagar.ReadOnly = True
        Me.actxnTotalPagar.Size = New System.Drawing.Size(92, 26)
        Me.actxnTotalPagar.TabIndex = 5
        Me.actxnTotalPagar.Tag = "EVO"
        Me.actxnTotalPagar.Text = "0.00"
        Me.actxnTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalPagar
        '
        Me.lblTotalPagar.AutoSize = True
        Me.lblTotalPagar.ForeColor = System.Drawing.Color.White
        Me.lblTotalPagar.Location = New System.Drawing.Point(486, 24)
        Me.lblTotalPagar.Name = "lblTotalPagar"
        Me.lblTotalPagar.Size = New System.Drawing.Size(88, 15)
        Me.lblTotalPagar.TabIndex = 4
        Me.lblTotalPagar.Text = "Total Pagar : {0}"
        '
        'actxnTCVentaSunat
        '
        Me.actxnTCVentaSunat.ACEnteros = 9
        Me.actxnTCVentaSunat.ACEstandar = ACControles.ACEstandaresFormato.ACDecimal
        Me.actxnTCVentaSunat.ACNegativo = True
        Me.actxnTCVentaSunat.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTCVentaSunat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnTCVentaSunat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnTCVentaSunat.Location = New System.Drawing.Point(662, 30)
        Me.actxnTCVentaSunat.MaxLength = 12
        Me.actxnTCVentaSunat.Name = "actxnTCVentaSunat"
        Me.actxnTCVentaSunat.ReadOnly = True
        Me.actxnTCVentaSunat.Size = New System.Drawing.Size(45, 23)
        Me.actxnTCVentaSunat.TabIndex = 16
        Me.actxnTCVentaSunat.Text = "0.00"
        Me.actxnTCVentaSunat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVenDolarSunat
        '
        Me.lblVenDolarSunat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVenDolarSunat.AutoSize = True
        Me.lblVenDolarSunat.Enabled = False
        Me.lblVenDolarSunat.Location = New System.Drawing.Point(533, 34)
        Me.lblVenDolarSunat.Name = "lblVenDolarSunat"
        Me.lblVenDolarSunat.Size = New System.Drawing.Size(123, 15)
        Me.lblVenDolarSunat.TabIndex = 15
        Me.lblVenDolarSunat.Text = "Venta Dolar Sunat : {0}"
        '
        'actxnTipoCambio
        '
        Me.actxnTipoCambio.ACEnteros = 9
        Me.actxnTipoCambio.ACEstandar = ACControles.ACEstandaresFormato.ACMoneda
        Me.actxnTipoCambio.ACNegativo = True
        Me.actxnTipoCambio.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.actxnTipoCambio.Location = New System.Drawing.Point(662, 3)
        Me.actxnTipoCambio.MaxLength = 12
        Me.actxnTipoCambio.Name = "actxnTipoCambio"
        Me.actxnTipoCambio.ReadOnly = True
        Me.actxnTipoCambio.Size = New System.Drawing.Size(45, 23)
        Me.actxnTipoCambio.TabIndex = 12
        Me.actxnTipoCambio.Text = "0.00"
        Me.actxnTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Enabled = False
        Me.Label31.Location = New System.Drawing.Point(574, 7)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(81, 15)
        Me.Label31.TabIndex = 11
        Me.Label31.Text = "Tipo Cam&bio :"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.MidnightBlue
        Me.pnlCabecera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCabecera.Controls.Add(Me.Label3)
        Me.pnlCabecera.Controls.Add(Me.cmbDocumentoFacturar)
        Me.pnlCabecera.Controls.Add(Me.actxaCotiz)
        Me.pnlCabecera.Controls.Add(Me.Label8)
        Me.pnlCabecera.Controls.Add(Me.Label5)
        Me.pnlCabecera.Controls.Add(Me.actxnNumeroFacturar)
        Me.pnlCabecera.Controls.Add(Me.Label4)
        Me.pnlCabecera.Controls.Add(Me.cmbSerieFacturar)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1375, 34)
        Me.pnlCabecera.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(711, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo Documento :"
        '
        'cmbDocumentoFacturar
        '
        Me.cmbDocumentoFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDocumentoFacturar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentoFacturar.Enabled = False
        Me.cmbDocumentoFacturar.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.cmbDocumentoFacturar.FormattingEnabled = True
        Me.cmbDocumentoFacturar.Items.AddRange(New Object() {"Boleta", "Factura"})
        Me.cmbDocumentoFacturar.Location = New System.Drawing.Point(844, 3)
        Me.cmbDocumentoFacturar.Name = "cmbDocumentoFacturar"
        Me.cmbDocumentoFacturar.Size = New System.Drawing.Size(204, 27)
        Me.cmbDocumentoFacturar.TabIndex = 3
        Me.cmbDocumentoFacturar.Tag = "ECO"
        '
        'actxaCotiz
        '
        Me.actxaCotiz.ACActivarAyudaAuto = False
        Me.actxaCotiz.ACLongitudAceptada = 0
        Me.actxaCotiz.Location = New System.Drawing.Point(88, 3)
        Me.actxaCotiz.MaxLength = 32767
        Me.actxaCotiz.Name = "actxaCotiz"
        Me.actxaCotiz.Size = New System.Drawing.Size(111, 23)
        Me.actxaCotiz.TabIndex = 1
        Me.actxaCotiz.Tag = "EV"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(2, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Cotización :"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1064, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Serie :"
        '
        'actxnNumeroFacturar
        '
        Me.actxnNumeroFacturar.ACEnteros = 8
        Me.actxnNumeroFacturar.ACFormato = "#######0"
        Me.actxnNumeroFacturar.ACNegativo = True
        Me.actxnNumeroFacturar.ACValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.actxnNumeroFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.actxnNumeroFacturar.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.actxnNumeroFacturar.Location = New System.Drawing.Point(1266, 4)
        Me.actxnNumeroFacturar.MaxLength = 7
        Me.actxnNumeroFacturar.Name = "actxnNumeroFacturar"
        Me.actxnNumeroFacturar.Size = New System.Drawing.Size(100, 24)
        Me.actxnNumeroFacturar.TabIndex = 7
        Me.actxnNumeroFacturar.Tag = "ENO"
        Me.actxnNumeroFacturar.Text = "0"
        Me.actxnNumeroFacturar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1190, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Numero :"
        '
        'cmbSerieFacturar
        '
        Me.cmbSerieFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSerieFacturar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSerieFacturar.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.cmbSerieFacturar.FormattingEnabled = True
        Me.cmbSerieFacturar.Location = New System.Drawing.Point(1120, 3)
        Me.cmbSerieFacturar.Name = "cmbSerieFacturar"
        Me.cmbSerieFacturar.Size = New System.Drawing.Size(69, 27)
        Me.cmbSerieFacturar.TabIndex = 5
        Me.cmbSerieFacturar.Tag = "ECO"
        '
        'tabBusqueda
        '
        Me.tabBusqueda.Controls.Add(Me.c1grdBusqueda)
        Me.tabBusqueda.Controls.Add(Me.grpBusqueda)
        Me.tabBusqueda.Controls.Add(Me.bnavBusqueda)
        Me.tabBusqueda.InactiveBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.InactiveTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Location = New System.Drawing.Point(1, 1)
        Me.tabBusqueda.Name = "tabBusqueda"
        Me.tabBusqueda.SelectBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Selected = False
        Me.tabBusqueda.SelectTextBackColor = System.Drawing.Color.Empty
        Me.tabBusqueda.SelectTextColor = System.Drawing.Color.Empty
        Me.tabBusqueda.Size = New System.Drawing.Size(1375, 772)
        Me.tabBusqueda.TabIndex = 5
        Me.tabBusqueda.Title = "Busqueda"
        Me.tabBusqueda.ToolTip = "Busqueda"
        '
        'c1grdBusqueda
        '
        Me.c1grdBusqueda.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdBusqueda.Location = New System.Drawing.Point(0, 95)
        Me.c1grdBusqueda.Name = "c1grdBusqueda"
        Me.c1grdBusqueda.Rows.Count = 2
        Me.c1grdBusqueda.Rows.DefaultSize = 20
        Me.c1grdBusqueda.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.c1grdBusqueda.Size = New System.Drawing.Size(1375, 677)
        Me.c1grdBusqueda.StyleInfo = resources.GetString("c1grdBusqueda.StyleInfo")
        Me.c1grdBusqueda.TabIndex = 2
        '
        'grpBusqueda
        '
        Me.grpBusqueda.Controls.Add(Me.btnConsultar)
        Me.grpBusqueda.Controls.Add(Me.rbtnNroCotizacion)
        Me.grpBusqueda.Controls.Add(Me.rbtnCliente)
        Me.grpBusqueda.Controls.Add(Me.grpCliente)
        Me.grpBusqueda.Controls.Add(Me.grpDocumentos)
        Me.grpBusqueda.Controls.Add(Me.chkTodos)
        Me.grpBusqueda.Controls.Add(Me.AcFecha)
        Me.grpBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(1375, 95)
        Me.grpBusqueda.TabIndex = 6
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Opciones de Busqueda"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.btnConsultar.Image = Global.ACPTransportes.My.Resources.Resources.Search_files_32x32
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(1270, 47)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 42)
        Me.btnConsultar.TabIndex = 33
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'rbtnNroCotizacion
        '
        Me.rbtnNroCotizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtnNroCotizacion.AutoSize = True
        Me.rbtnNroCotizacion.Location = New System.Drawing.Point(833, 43)
        Me.rbtnNroCotizacion.Name = "rbtnNroCotizacion"
        Me.rbtnNroCotizacion.Size = New System.Drawing.Size(88, 19)
        Me.rbtnNroCotizacion.TabIndex = 2
        Me.rbtnNroCotizacion.Text = "Documento"
        Me.rbtnNroCotizacion.UseVisualStyleBackColor = True
        '
        'rbtnCliente
        '
        Me.rbtnCliente.AutoSize = True
        Me.rbtnCliente.Checked = True
        Me.rbtnCliente.Location = New System.Drawing.Point(19, 43)
        Me.rbtnCliente.Name = "rbtnCliente"
        Me.rbtnCliente.Size = New System.Drawing.Size(62, 19)
        Me.rbtnCliente.TabIndex = 1
        Me.rbtnCliente.TabStop = True
        Me.rbtnCliente.Text = "Cliente"
        Me.rbtnCliente.UseVisualStyleBackColor = True
        '
        'grpCliente
        '
        Me.grpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCliente.Controls.Add(Me.txtBusqueda)
        Me.grpCliente.Location = New System.Drawing.Point(6, 46)
        Me.grpCliente.Name = "grpCliente"
        Me.grpCliente.Size = New System.Drawing.Size(817, 42)
        Me.grpCliente.TabIndex = 7
        Me.grpCliente.TabStop = False
        '
        'txtBusqueda
        '
        Me.txtBusqueda.ACActivarAyudaAuto = False
        Me.txtBusqueda.ACLongitudAceptada = 0
        Me.txtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda.Location = New System.Drawing.Point(9, 16)
        Me.txtBusqueda.MaxLength = 32767
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(798, 23)
        Me.txtBusqueda.TabIndex = 0
        '
        'grpDocumentos
        '
        Me.grpDocumentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDocumentos.Controls.Add(Me.cmbTipoDocumento)
        Me.grpDocumentos.Controls.Add(Me.ComboBox2)
        Me.grpDocumentos.Controls.Add(Me.txtBusNumero)
        Me.grpDocumentos.Location = New System.Drawing.Point(829, 47)
        Me.grpDocumentos.Name = "grpDocumentos"
        Me.grpDocumentos.Size = New System.Drawing.Size(334, 42)
        Me.grpDocumentos.TabIndex = 5
        Me.grpDocumentos.TabStop = False
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(10, 15)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(151, 23)
        Me.cmbTipoDocumento.TabIndex = 8
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(167, 15)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(51, 23)
        Me.ComboBox2.TabIndex = 6
        '
        'txtBusNumero
        '
        Me.txtBusNumero.ACActivarAyudaAuto = False
        Me.txtBusNumero.ACLongitudAceptada = 0
        Me.txtBusNumero.ACTipo = ACControles.ACTextBoxAyuda.TipoTextBoxAyuda.Numerico
        Me.txtBusNumero.Location = New System.Drawing.Point(224, 15)
        Me.txtBusNumero.MaxLength = 32767
        Me.txtBusNumero.Name = "txtBusNumero"
        Me.txtBusNumero.Size = New System.Drawing.Size(100, 23)
        Me.txtBusNumero.TabIndex = 7
        '
        'chkTodos
        '
        Me.chkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(1168, 52)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(101, 19)
        Me.chkTodos.TabIndex = 4
        Me.chkTodos.Text = "Mostrar Todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'AcFecha
        '
        Me.AcFecha.ACFecha_A = New Date(2025, 9, 30, 15, 25, 58, 206)
        Me.AcFecha.ACFecha_De = New Date(2025, 9, 30, 15, 25, 58, 199)
        Me.AcFecha.ACFechaObligatoria = True
        Me.AcFecha.ACFormatoControl = ACControles.ACFecha.ACTipoFormatoControl.Horizontal
        Me.AcFecha.ACHoyChecked = False
        Me.AcFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AcFecha.Location = New System.Drawing.Point(1038, 0)
        Me.AcFecha.MaximumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.MinimumSize = New System.Drawing.Size(337, 43)
        Me.AcFecha.Name = "AcFecha"
        Me.AcFecha.Size = New System.Drawing.Size(337, 43)
        Me.AcFecha.TabIndex = 3
        Me.AcFecha.TabStop = False
        '
        'bnavBusqueda
        '
        Me.bnavBusqueda.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.bnavBusqueda.CountItem = Me.BindingNavigatorCountItem
        Me.bnavBusqueda.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.bnavBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavBusqueda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.tsbtnExcel})
        Me.bnavBusqueda.Location = New System.Drawing.Point(0, 494)
        Me.bnavBusqueda.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnavBusqueda.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnavBusqueda.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnavBusqueda.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnavBusqueda.Name = "bnavBusqueda"
        Me.bnavBusqueda.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavBusqueda.Size = New System.Drawing.Size(982, 25)
        Me.bnavBusqueda.TabIndex = 3
        Me.bnavBusqueda.Text = "BindingNavigator1"
        Me.bnavBusqueda.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        Me.BindingNavigatorAddNewItem.Visible = False
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
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        Me.BindingNavigatorDeleteItem.Visible = False
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
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
        Me.BindingNavigatorPositionItem.AutoSize = False
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
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnExcel
        '
        Me.tsbtnExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnExcel.Image = Global.ACPTransportes.My.Resources.Resources.Excel2_32x32
        Me.tsbtnExcel.Name = "tsbtnExcel"
        Me.tsbtnExcel.RightToLeftAutoMirrorImage = True
        Me.tsbtnExcel.Size = New System.Drawing.Size(98, 22)
        Me.tsbtnExcel.Text = "Enviar a Excel"
        '
        'actxtDireccionDestino
        '
        Me.actxtDireccionDestino.Location = New System.Drawing.Point(1354, 0)
        Me.actxtDireccionDestino.Name = "actxtDireccionDestino"
        Me.actxtDireccionDestino.Size = New System.Drawing.Size(10, 20)
        Me.actxtDireccionDestino.TabIndex = 65
        Me.actxtDireccionDestino.Text = "se hizo invisible ojo"
        Me.actxtDireccionDestino.Visible = False
        '
        'actxtDireccionOrigen
        '
        Me.actxtDireccionOrigen.Location = New System.Drawing.Point(1365, 0)
        Me.actxtDireccionOrigen.Name = "actxtDireccionOrigen"
        Me.actxtDireccionOrigen.Size = New System.Drawing.Size(10, 20)
        Me.actxtDireccionOrigen.TabIndex = 64
        Me.actxtDireccionOrigen.Text = "se hizo invisible ojo"
        Me.actxtDireccionOrigen.Visible = False
        '
        'acpnlTitulo
        '
        Me.acpnlTitulo.ACCaption = "Facturación - División de Transportes"
        Me.acpnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.acpnlTitulo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.acpnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.acpnlTitulo.Name = "acpnlTitulo"
        Me.acpnlTitulo.Size = New System.Drawing.Size(1377, 25)
        Me.acpnlTitulo.TabIndex = 12
        '
        'acTool
        '
        Me.acTool.ACBtnAnularEnabled = False
        Me.acTool.ACBtnAnularVisible = False
        Me.acTool.ACBtnBuscarText = "Cot&izaciones"
        Me.acTool.ACBtnCancelarEnabled = False
        Me.acTool.ACBtnCancelarVisible = False
        Me.acTool.ACBtnGrabarEnabled = False
        Me.acTool.ACBtnGrabarVisible = False
        Me.acTool.ACBtnImprimirEnabled = False
        Me.acTool.ACBtnImprimirVisible = False
        Me.acTool.ACBtnReporteEnabled = False
        Me.acTool.ACBtnReporteVisible = False
        Me.acTool.ACBtnSalirEnabled = False
        Me.acTool.ACBtnSalirText = "&Salir"
        Me.acTool.ACBtnSalirVisible = False
        Me.acTool.ACBtnVolverEnabled = False
        Me.acTool.ACBtnVolverVisible = False
        Me.acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolNuevoGrabarEliminarBuscarRehusar
        Me.acTool.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.acTool.Font = New System.Drawing.Font("Tahoma", 9.5!)
        Me.acTool.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.acTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.actsbtnModFecha, Me.acbtnCreaAnulado, Me.acbtnSeleccionar, Me.actsbtnPrevisualizar, Me.actsbtn_CapturaPantalla})
        Me.acTool.Location = New System.Drawing.Point(0, 822)
        Me.acTool.Name = "acTool"
        Me.acTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.acTool.Size = New System.Drawing.Size(1377, 56)
        Me.acTool.TabIndex = 14
        Me.acTool.Text = "AcToolBarMantHorizontalNew1"
        '
        'actsbtnModFecha
        '
        Me.actsbtnModFecha.AutoSize = False
        Me.actsbtnModFecha.Image = Global.ACPTransportes.My.Resources.Resources.EditPaper_32x32
        Me.actsbtnModFecha.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.actsbtnModFecha.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.actsbtnModFecha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.actsbtnModFecha.Name = "tsbBoton"
        Me.actsbtnModFecha.Size = New System.Drawing.Size(102, 53)
        Me.actsbtnModFecha.Text = "Modificar Fecha"
        Me.actsbtnModFecha.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.actsbtnModFecha.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.actsbtnModFecha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.actsbtnModFecha.Visible = False
        '
        'acbtnCreaAnulado
        '
        Me.acbtnCreaAnulado.AutoSize = False
        Me.acbtnCreaAnulado.Enabled = False
        Me.acbtnCreaAnulado.Image = Global.ACPTransportes.My.Resources.Resources.ACAnular_32x32
        Me.acbtnCreaAnulado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.acbtnCreaAnulado.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.acbtnCreaAnulado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.acbtnCreaAnulado.Name = "tsbBoton"
        Me.acbtnCreaAnulado.Size = New System.Drawing.Size(102, 53)
        Me.acbtnCreaAnulado.Text = "Crear Anulado"
        Me.acbtnCreaAnulado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.acbtnCreaAnulado.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.acbtnCreaAnulado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.acbtnCreaAnulado.Visible = False
        '
        'acbtnSeleccionar
        '
        Me.acbtnSeleccionar.AutoSize = False
        Me.acbtnSeleccionar.Image = Global.ACPTransportes.My.Resources.Resources.aceptar_32x32
        Me.acbtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.acbtnSeleccionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.acbtnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.acbtnSeleccionar.Name = "tsbBoton"
        Me.acbtnSeleccionar.Size = New System.Drawing.Size(84, 53)
        Me.acbtnSeleccionar.Text = "&Seleccionar"
        Me.acbtnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.acbtnSeleccionar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.acbtnSeleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.acbtnSeleccionar.Visible = False
        '
        'actsbtnPrevisualizar
        '
        Me.actsbtnPrevisualizar.AutoSize = False
        Me.actsbtnPrevisualizar.Image = Global.ACPTransportes.My.Resources.Resources.Buscar2_32x32
        Me.actsbtnPrevisualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.actsbtnPrevisualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.actsbtnPrevisualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.actsbtnPrevisualizar.Name = "tsbBoton"
        Me.actsbtnPrevisualizar.Size = New System.Drawing.Size(84, 53)
        Me.actsbtnPrevisualizar.Text = "Previsualizar"
        Me.actsbtnPrevisualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.actsbtnPrevisualizar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.actsbtnPrevisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.actsbtnPrevisualizar.Visible = False
        '
        'actsbtn_CapturaPantalla
        '
        Me.actsbtn_CapturaPantalla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.actsbtn_CapturaPantalla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.actsbtn_CapturaPantalla.Name = "actsbtn_CapturaPantalla"
        Me.actsbtn_CapturaPantalla.Size = New System.Drawing.Size(23, 53)
        Me.actsbtn_CapturaPantalla.Text = "ToolStripButton10"
        '
        'eprError
        '
        Me.eprError.ContainerControl = Me
        '
        'PrintDocument1
        '
        '
        'bnavConsumoAdBlue
        '
        Me.bnavConsumoAdBlue.AddNewItem = Nothing
        Me.bnavConsumoAdBlue.CountItem = Nothing
        Me.bnavConsumoAdBlue.DeleteItem = Nothing
        Me.bnavConsumoAdBlue.Location = New System.Drawing.Point(0, 20)
        Me.bnavConsumoAdBlue.MoveFirstItem = Nothing
        Me.bnavConsumoAdBlue.MoveLastItem = Nothing
        Me.bnavConsumoAdBlue.MoveNextItem = Nothing
        Me.bnavConsumoAdBlue.MovePreviousItem = Nothing
        Me.bnavConsumoAdBlue.Name = "bnavConsumoAdBlue"
        Me.bnavConsumoAdBlue.PositionItem = Nothing
        Me.bnavConsumoAdBlue.Size = New System.Drawing.Size(1273, 25)
        Me.bnavConsumoAdBlue.TabIndex = 17
        Me.bnavConsumoAdBlue.Text = "bnavFletes"
        Me.bnavConsumoAdBlue.Visible = False
        '
        'ToolStripButton29
        '
        Me.ToolStripButton29.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton29.Image = CType(resources.GetObject("ToolStripButton29.Image"), System.Drawing.Image)
        Me.ToolStripButton29.Name = "ToolStripButton29"
        Me.ToolStripButton29.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton29.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton29.Text = "Move first"
        '
        'ToolStripButton34
        '
        Me.ToolStripButton34.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton34.Image = CType(resources.GetObject("ToolStripButton34.Image"), System.Drawing.Image)
        Me.ToolStripButton34.Name = "ToolStripButton34"
        Me.ToolStripButton34.RightToLeftAutoMirrorImage = True
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
        Me.ToolStripTextBox12.AutoSize = False
        Me.ToolStripTextBox12.Name = "ToolStripTextBox12"
        Me.ToolStripTextBox12.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox12.Text = "0"
        Me.ToolStripTextBox12.ToolTipText = "Current position"
        '
        'ToolStripLabel14
        '
        Me.ToolStripLabel14.Name = "ToolStripLabel14"
        Me.ToolStripLabel14.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel14.Text = "de {0}"
        Me.ToolStripLabel14.ToolTipText = "Total number of items"
        '
        'ToolStripSeparator39
        '
        Me.ToolStripSeparator39.Name = "ToolStripSeparator39"
        Me.ToolStripSeparator39.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton41
        '
        Me.ToolStripButton41.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton41.Image = CType(resources.GetObject("ToolStripButton41.Image"), System.Drawing.Image)
        Me.ToolStripButton41.Name = "ToolStripButton41"
        Me.ToolStripButton41.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton41.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton41.Text = "Move next"
        '
        'ToolStripButton42
        '
        Me.ToolStripButton42.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton42.Image = CType(resources.GetObject("ToolStripButton42.Image"), System.Drawing.Image)
        Me.ToolStripButton42.Name = "ToolStripButton42"
        Me.ToolStripButton42.RightToLeftAutoMirrorImage = True
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
        Me.tsbtnCABAgregar.Image = CType(resources.GetObject("tsbtnCABAgregar.Image"), System.Drawing.Image)
        Me.tsbtnCABAgregar.Name = "tsbtnCABAgregar"
        Me.tsbtnCABAgregar.RightToLeftAutoMirrorImage = True
        Me.tsbtnCABAgregar.Size = New System.Drawing.Size(165, 22)
        Me.tsbtnCABAgregar.Text = "&Agregar Consumo AdBlue"
        '
        'ToolStripSeparator48
        '
        Me.ToolStripSeparator48.Name = "ToolStripSeparator48"
        Me.ToolStripSeparator48.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator48.Visible = False
        '
        'tsbtnCABModificar
        '
        Me.tsbtnCABModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnCABModificar.Name = "tsbtnCABModificar"
        Me.tsbtnCABModificar.Size = New System.Drawing.Size(117, 22)
        Me.tsbtnCABModificar.Text = "Modificar Consumo"
        '
        'ToolStripSeparator51
        '
        Me.ToolStripSeparator51.Name = "ToolStripSeparator51"
        Me.ToolStripSeparator51.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator51.Visible = False
        '
        'ToolStripButton48
        '
        Me.ToolStripButton48.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton48.Name = "ToolStripButton48"
        Me.ToolStripButton48.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripButton48.Text = "Modificar Fecha"
        Me.ToolStripButton48.Visible = False
        '
        'tsbtnCABQuitar
        '
        Me.tsbtnCABQuitar.Image = CType(resources.GetObject("tsbtnCABQuitar.Image"), System.Drawing.Image)
        Me.tsbtnCABQuitar.Name = "tsbtnCABQuitar"
        Me.tsbtnCABQuitar.RightToLeftAutoMirrorImage = True
        Me.tsbtnCABQuitar.Size = New System.Drawing.Size(115, 22)
        Me.tsbtnCABQuitar.Text = "&Quitar Consumo"
        '
        'ToolStripLabel15
        '
        Me.ToolStripLabel15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel15.Name = "ToolStripLabel15"
        Me.ToolStripLabel15.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripLabel15.Text = "Eliminar Consumo"
        Me.ToolStripLabel15.Visible = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.c1grdIngresoCompra)
        Me.Panel6.Controls.Add(Me.AcPanelCaption12)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(607, 188)
        Me.Panel6.TabIndex = 23
        '
        'c1grdIngresoCompra
        '
        Me.c1grdIngresoCompra.ColumnInfo = "2,1,0,0,0,100,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grdIngresoCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grdIngresoCompra.Location = New System.Drawing.Point(0, 20)
        Me.c1grdIngresoCompra.Name = "c1grdIngresoCompra"
        Me.c1grdIngresoCompra.Rows.Count = 2
        Me.c1grdIngresoCompra.Rows.DefaultSize = 20
        Me.c1grdIngresoCompra.Size = New System.Drawing.Size(607, 168)
        Me.c1grdIngresoCompra.StyleInfo = resources.GetString("c1grdIngresoCompra.StyleInfo")
        Me.c1grdIngresoCompra.TabIndex = 22
        '
        'AcPanelCaption12
        '
        Me.AcPanelCaption12.ACCaption = "Ingreso Compra "
        Me.AcPanelCaption12.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption12.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption12.Name = "AcPanelCaption12"
        Me.AcPanelCaption12.Size = New System.Drawing.Size(607, 20)
        Me.AcPanelCaption12.TabIndex = 14
        '
        'Panel12
        '
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(0, 188)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(607, 0)
        Me.Panel12.TabIndex = 24
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(607, 0)
        Me.Panel7.TabIndex = 24
        '
        'AcPanelCaption10
        '
        Me.AcPanelCaption10.ACCaption = "Guias Registradas"
        Me.AcPanelCaption10.Dock = System.Windows.Forms.DockStyle.Top
        Me.AcPanelCaption10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.AcPanelCaption10.Location = New System.Drawing.Point(0, 0)
        Me.AcPanelCaption10.Name = "AcPanelCaption10"
        Me.AcPanelCaption10.Size = New System.Drawing.Size(607, 20)
        Me.AcPanelCaption10.TabIndex = 14
        '
        'c1grGuiasCompraDet
        '
        Me.c1grGuiasCompraDet.ColumnInfo = "2,1,0,0,0,85,Columns:0{Width:25;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.c1grGuiasCompraDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1grGuiasCompraDet.Location = New System.Drawing.Point(0, 20)
        Me.c1grGuiasCompraDet.Name = "c1grGuiasCompraDet"
        Me.c1grGuiasCompraDet.Rows.Count = 2
        Me.c1grGuiasCompraDet.Rows.DefaultSize = 17
        Me.c1grGuiasCompraDet.Size = New System.Drawing.Size(607, 0)
        Me.c1grGuiasCompraDet.TabIndex = 22
        '
        'txtphantom_ubigo_origen
        '
        Me.txtphantom_ubigo_origen.Enabled = False
        Me.txtphantom_ubigo_origen.Location = New System.Drawing.Point(1144, 704)
        Me.txtphantom_ubigo_origen.Name = "txtphantom_ubigo_origen"
        Me.txtphantom_ubigo_origen.Size = New System.Drawing.Size(100, 20)
        Me.txtphantom_ubigo_origen.TabIndex = 15
        Me.txtphantom_ubigo_origen.Visible = False
        '
        'txtphantom_ubigo_destino
        '
        Me.txtphantom_ubigo_destino.Enabled = False
        Me.txtphantom_ubigo_destino.Location = New System.Drawing.Point(1140, 706)
        Me.txtphantom_ubigo_destino.Name = "txtphantom_ubigo_destino"
        Me.txtphantom_ubigo_destino.Size = New System.Drawing.Size(100, 20)
        Me.txtphantom_ubigo_destino.TabIndex = 16
        Me.txtphantom_ubigo_destino.Visible = False
        '
        'txtphantom_rutas_nombre
        '
        Me.txtphantom_rutas_nombre.Enabled = False
        Me.txtphantom_rutas_nombre.Location = New System.Drawing.Point(1139, 704)
        Me.txtphantom_rutas_nombre.Name = "txtphantom_rutas_nombre"
        Me.txtphantom_rutas_nombre.Size = New System.Drawing.Size(100, 20)
        Me.txtphantom_rutas_nombre.TabIndex = 17
        Me.txtphantom_rutas_nombre.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'txtVEHIC_Certificado
        '
        Me.txtVEHIC_Certificado.Enabled = False
        Me.txtVEHIC_Certificado.Location = New System.Drawing.Point(1164, 846)
        Me.txtVEHIC_Certificado.Name = "txtVEHIC_Certificado"
        Me.txtVEHIC_Certificado.Size = New System.Drawing.Size(100, 20)
        Me.txtVEHIC_Certificado.TabIndex = 18
        Me.txtVEHIC_Certificado.Visible = False
        '
        'PFacturacionFletes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1377, 878)
        Me.Controls.Add(Me.actxtDireccionDestino)
        Me.Controls.Add(Me.actxtDireccionOrigen)
        Me.Controls.Add(Me.txtVEHIC_Certificado)
        Me.Controls.Add(Me.txtphantom_rutas_nombre)
        Me.Controls.Add(Me.tabMantenimiento)
        Me.Controls.Add(Me.txtphantom_ubigo_destino)
        Me.Controls.Add(Me.acpnlTitulo)
        Me.Controls.Add(Me.txtphantom_ubigo_origen)
        Me.Controls.Add(Me.acTool)
        Me.Name = "PFacturacionFletes"
        Me.Text = "ToolNuevoGrabarAnularImprimir"
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlDetalle.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.spcCabecera.Panel1.ResumeLayout(False)
        Me.spcCabecera.Panel2.ResumeLayout(False)
        CType(Me.spcCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcCabecera.ResumeLayout(False)
        Me.pnlItem.ResumeLayout(False)
        Me.pnlItem.PerformLayout()
        Me.grpCabCuerpo.ResumeLayout(False)
        Me.grpCabCuerpo.PerformLayout()
        Me.grpFlete.ResumeLayout(False)
        Me.grpFlete.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpgFletes.ResumeLayout(False)
        Me.tpgFletes.PerformLayout()
        CType(Me.c1grdFletes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavFletes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavFletes.ResumeLayout(False)
        Me.bnavFletes.PerformLayout()
        Me.tstFletes.ResumeLayout(False)
        Me.tstFletes.PerformLayout()
        Me.tpgNotasCredito.ResumeLayout(False)
        Me.tpgNotasCredito.PerformLayout()
        CType(Me.c1grdNCreditos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tpgPagos.ResumeLayout(False)
        Me.tpgPagos.PerformLayout()
        CType(Me.c1grdPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator2.ResumeLayout(False)
        Me.BindingNavigator2.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.spcDetalle.Panel1.ResumeLayout(False)
        Me.spcDetalle.Panel2.ResumeLayout(False)
        CType(Me.spcDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcDetalle.ResumeLayout(False)
        CType(Me.c1grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.c1grdEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1grdGuias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavGuias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavGuias.ResumeLayout(False)
        Me.bnavGuias.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.bnavProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavProductos.ResumeLayout(False)
        Me.bnavProductos.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.grpDetPago.ResumeLayout(False)
        Me.grpDetPago.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.tabBusqueda.ResumeLayout(False)
        Me.tabBusqueda.PerformLayout()
        CType(Me.c1grdBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBusqueda.ResumeLayout(False)
        Me.grpBusqueda.PerformLayout()
        Me.grpCliente.ResumeLayout(False)
        Me.grpCliente.PerformLayout()
        Me.grpDocumentos.ResumeLayout(False)
        Me.grpDocumentos.PerformLayout()
        CType(Me.bnavBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavBusqueda.ResumeLayout(False)
        Me.bnavBusqueda.PerformLayout()
        Me.acTool.ResumeLayout(False)
        Me.acTool.PerformLayout()
        CType(Me.eprError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnavConsumoAdBlue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        CType(Me.c1grdIngresoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1grGuiasCompraDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tabMantenimiento As Crownwood.DotNetMagic.Controls.TabControl
    Private WithEvents tabDatos As Crownwood.DotNetMagic.Controls.TabPage
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
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
    Friend WithEvents acpnlTitulo As ACControles.ACPanelCaption
    Friend WithEvents acTool As ACControles.ACToolBarMantHorizontalNew
    Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents c1grdDetalle As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pnlItem As System.Windows.Forms.Panel
    Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
    Friend WithEvents actxnSubImporte As ACControles.ACTextBoxNumerico
    Friend WithEvents actxnProdCantidad As ACControles.ACTextBoxNumerico
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents txtProdDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents bnavProductos As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents grpDetPago As System.Windows.Forms.GroupBox
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents lbligv As System.Windows.Forms.Label
    Friend WithEvents actxnImporte As ACControles.ACTextBoxNumerico
    Friend WithEvents actxnIGV As ACControles.ACTextBoxNumerico
    Friend WithEvents actxnTotalPagar As ACControles.ACTextBoxNumerico
    Friend WithEvents lblTotalPagar As System.Windows.Forms.Label
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents grpCabCuerpo As System.Windows.Forms.GroupBox
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents lblVenDolarSunat As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents dtpFecFacturacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNuevoCliente As System.Windows.Forms.Button
    Friend WithEvents btnClean As System.Windows.Forms.Button
    Friend WithEvents actxaCliRazonSocial As ACControles.ACTextBoxAyuda
    Friend WithEvents lblNroDocumento As System.Windows.Forms.Label
    Friend WithEvents actxaCliRuc As ACControles.ACTextBoxAyuda
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDocumentoFacturar As System.Windows.Forms.ComboBox
    Friend WithEvents actxnNumeroFacturar As ACControles.ACTextBoxNumerico
    Friend WithEvents cmbSerieFacturar As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents actxnPrecio As ACControles.ACTextBoxNumerico
    Friend WithEvents txtProdUnidad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents actsbtnPrevisualizar As ACControles.ACToolStripButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents eprError As System.Windows.Forms.ErrorProvider
    Private WithEvents grpBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents rbtnNroCotizacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCliente As System.Windows.Forms.RadioButton
    Friend WithEvents grpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents txtBusqueda As ACControles.ACTextBoxAyuda
    Friend WithEvents grpDocumentos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtBusNumero As ACControles.ACTextBoxAyuda
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents AcFecha As ACControles.ACFecha
    Friend WithEvents tslblSon As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscmbImpresora As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents actxnTCVentaSunat As ACControles.ACTextBoxNumerico
    Private WithEvents actxnTipoCambio As ACControles.ACTextBoxNumerico
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNotaPie As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents actxaCotiz As ACControles.ACTextBoxAyuda
    Friend WithEvents cmbDirecciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents actsbtnModFecha As ACControles.ACToolStripButton
    Friend WithEvents grpFlete As System.Windows.Forms.GroupBox
    Friend WithEvents actxaFlete As ACControles.ACTextBoxAyuda
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents spcCabecera As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnMenos As System.Windows.Forms.Button
    Friend WithEvents btnMas As System.Windows.Forms.Button
    Friend WithEvents tsbtnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents acbtnCreaAnulado As ACControles.ACToolStripButton
    Friend WithEvents chkPermiteFecha As System.Windows.Forms.CheckBox
    Friend WithEvents chkIlncluidoIGV As System.Windows.Forms.CheckBox
    Friend WithEvents acbtnSeleccionar As ACControles.ACToolStripButton
    Friend WithEvents spcDetalle As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents c1grdEmpresas As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents AcPanelCaption2 As ACControles.ACPanelCaption
    Friend WithEvents c1grdGuias As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavGuias As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton16 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox3 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton17 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton18 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AcPanelCaption4 As ACControles.ACPanelCaption
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtTexto As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnGenerar As System.Windows.Forms.ToolStripButton
    Friend WithEvents AcPanelCaption3 As ACControles.ACPanelCaption
    Friend WithEvents chkspot As System.Windows.Forms.CheckBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbDetraccion As System.Windows.Forms.ComboBox
    Friend WithEvents actxnTotalDetraccion As ACControles.ACTextBoxNumerico
    Friend WithEvents lblTotalDetraccion As System.Windows.Forms.Label
    Friend WithEvents chkDetraccion As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFecPlazo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents actxnPlazo As ACControles.ACTextBoxNumerico
    Friend WithEvents chkValorReferencialEnFactura As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents actxnValorReferencial As ACControles.ACTextBoxNumerico
    Friend WithEvents actsbtn_CapturaPantalla As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbProdUnidad As ComboBox
    Friend WithEvents txtobservacionanulacion As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tpgFletes As TabPage
    Friend WithEvents tpgNotasCredito As TabPage
    Friend WithEvents bnavConsumoAdBlue As BindingNavigator
    Friend WithEvents ToolStripButton29 As ToolStripButton
    Friend WithEvents ToolStripButton34 As ToolStripButton
    Friend WithEvents ToolStripSeparator16 As ToolStripSeparator
    Friend WithEvents ToolStripTextBox12 As ToolStripTextBox
    Friend WithEvents ToolStripLabel14 As ToolStripLabel
    Friend WithEvents ToolStripSeparator39 As ToolStripSeparator
    Friend WithEvents ToolStripButton41 As ToolStripButton
    Friend WithEvents ToolStripButton42 As ToolStripButton
    Friend WithEvents ToolStripSeparator40 As ToolStripSeparator
    Friend WithEvents tsbtnCABAgregar As ToolStripButton
    Friend WithEvents ToolStripSeparator48 As ToolStripSeparator
    Friend WithEvents tsbtnCABModificar As ToolStripButton
    Friend WithEvents ToolStripSeparator51 As ToolStripSeparator
    Friend WithEvents ToolStripButton48 As ToolStripButton
    Friend WithEvents tsbtnCABQuitar As ToolStripButton
    Friend WithEvents ToolStripLabel15 As ToolStripLabel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents c1grdIngresoCompra As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents AcPanelCaption12 As ACControles.ACPanelCaption
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents AcPanelCaption10 As ACControles.ACPanelCaption
    Friend WithEvents c1grGuiasCompraDet As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents c1grdFletes As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bnavFletes As BindingNavigator
    Friend WithEvents ToolStripLabel10 As ToolStripLabel
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents ToolStripButton8 As ToolStripButton
    Friend WithEvents ToolStripSeparator44 As ToolStripSeparator
    Friend WithEvents ToolStripTextBox10 As ToolStripTextBox
    Friend WithEvents ToolStripSeparator45 As ToolStripSeparator
    Friend WithEvents ToolStripButton27 As ToolStripButton
    Friend WithEvents ToolStripButton28 As ToolStripButton
    Friend WithEvents ToolStripSeparator46 As ToolStripSeparator
    Friend WithEvents tsbtnImprimir As ToolStripButton
    Friend WithEvents tstFletes As ToolStrip
    Friend WithEvents tsbtnAddFletes As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsbtnQuitarFletes As ToolStripButton
    Friend WithEvents AcPanelCaption1 As ACControles.ACPanelCaption
    Friend WithEvents c1grdNCreditos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BindingNavigator1 As BindingNavigator
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripButton9 As ToolStripButton
    Friend WithEvents ToolStripButton10 As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripTextBox2 As ToolStripTextBox
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripButton11 As ToolStripButton
    Friend WithEvents ToolStripButton12 As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripButton13 As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ToolStripButton14 As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents ToolStripButton19 As ToolStripButton
    Friend WithEvents AcPanelCaption5 As ACControles.ACPanelCaption
    Friend WithEvents tpgPagos As TabPage
    Friend WithEvents c1grdPagos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BindingNavigator2 As BindingNavigator
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents ToolStripButton20 As ToolStripButton
    Friend WithEvents ToolStripButton21 As ToolStripButton
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents ToolStripTextBox4 As ToolStripTextBox
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents ToolStripButton22 As ToolStripButton
    Friend WithEvents ToolStripButton23 As ToolStripButton
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
    Friend WithEvents ToolStripButton24 As ToolStripButton
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents ToolStripButton25 As ToolStripButton
    Friend WithEvents ToolStripSeparator17 As ToolStripSeparator
    Friend WithEvents ToolStripButton26 As ToolStripButton
    Friend WithEvents AcPanelCaption6 As ACControles.ACPanelCaption
    Friend WithEvents txtphantom_ubigo_origen As TextBox
    Friend WithEvents txtphantom_ubigo_destino As TextBox
    Friend WithEvents txtphantom_rutas_nombre As TextBox
    Friend WithEvents txtphantom_RUTAS_ID As TextBox
    Friend WithEvents actxtDireccionDestino As TextBox
    Friend WithEvents actxtDireccionOrigen As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents txtVEHIC_Certificado As TextBox
    Friend WithEvents chkEditarFactura As CheckBox
End Class
