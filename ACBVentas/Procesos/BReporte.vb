Imports ACBVentas
Imports ACDVentas
Imports ACEVentas


Public Class BReporte
#Region " Variables "
    Private m_dtReportes As DataTable
    Private m_dsReportes As DataSet
    Private m_pvent_id As Long
    Private m_periodo As String
    Private d_reporte As DReporte
    Private m_listccuadrependientes As List(Of ECCuadrePendientes)
    Private m_listcuadrecaja As List(Of ECCuadreCaja)
    Private m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle)

    Private m_listvent_docsventa As List(Of EVENT_DocsVenta)
    Private m_listvent_docsventacorr As List(Of EVENT_DocsVenta)
    Private m_listvent_docsventafaltante As List(Of EVENT_DocsVenta)

    Private m_saldocaja As ESaldoCaja
    Private m_saldocajaefectivo As ESaldoCaja
    Private m_listteso_docspagos As List(Of ETESO_DocsPagos)
    Private m_vent_pedidos As EVENT_Pedidos
    Private m_abas_gestionOC As EABAS_GestionOrdenes
    Private m_dist_ordenes As EDIST_Ordenes
    Private m_dist_ordenesP As EABAS_OrdenesProduccion
    Private m_vent_Nc As EVENT_DocsVenta
    Private m_dist_guias As EDIST_GuiasRemision

    Enum TipoDocumento
        DocumentosVenta = 1
        OtrosIngresos = 2
        RecibosEgreso = 3
        GastosViaje = 4
    End Enum

    Public Enum TRCuadreCaja
        Nuevo = 1
        Actual = 2
    End Enum

    Enum TRVentas
        Todos = 1
        Anuladas = 2
        AnuladasMDia = 3
        Correlatividad = 4
        VentasXCliente = 5
    End Enum

    Private m_sucur_id As Integer

#End Region

#Region " Propiedades "
    Public Property ListCCuadrePendientes() As List(Of ECCuadrePendientes)
        Get
            Return m_listccuadrependientes
        End Get
        Set(ByVal value As List(Of ECCuadrePendientes))
            m_listccuadrependientes = value
        End Set
    End Property

    Public Property DTReportes() As DataTable
        Get
            Return m_dtReportes
        End Get
        Set(ByVal value As DataTable)
            m_dtReportes = value
        End Set
    End Property

    Public Property DSReportes() As DataSet
        Get
            Return m_dsReportes
        End Get
        Set(ByVal value As DataSet)
            m_dsReportes = value
        End Set
    End Property

    Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
        Get
            Return m_listvent_docsventa
        End Get
        Set(ByVal value As List(Of EVENT_DocsVenta))
            m_listvent_docsventa = value
        End Set
    End Property

    Public Property ListCCuadreCaja() As List(Of ECCuadreCaja)
        Get
            Return m_listcuadrecaja
        End Get
        Set(ByVal value As List(Of ECCuadreCaja))
            m_listcuadrecaja = value
        End Set
    End Property

    Public Property SaldoCaja() As ESaldoCaja
        Get
            Return m_saldocaja
        End Get
        Set(ByVal value As ESaldoCaja)
            m_saldocaja = value
        End Set
    End Property

    Public Property ListVENT_DocsVentaDetalle() As List(Of EVENT_DocsVentaDetalle)
        Get
            Return m_listvent_docsventadetalle
        End Get
        Set(ByVal value As List(Of EVENT_DocsVentaDetalle))
            m_listvent_docsventadetalle = value
        End Set
    End Property

    Public Property ListTESO_DocsPagos() As List(Of ETESO_DocsPagos)
        Get
            Return m_listteso_docspagos
        End Get
        Set(ByVal value As List(Of ETESO_DocsPagos))
            m_listteso_docspagos = value
        End Set
    End Property

    Public Property VENT_Pedidos() As EVENT_Pedidos
        Get
            Return m_vent_pedidos
        End Get
        Set(ByVal value As EVENT_Pedidos)
            m_vent_pedidos = value
        End Set
    End Property

    Public Property ABAS_GestionOrdenes() As EABAS_GestionOrdenes
        Get
            Return m_abas_gestionOC
        End Get
        Set(ByVal value As EABAS_GestionOrdenes)
            m_abas_gestionOC = value
        End Set
    End Property


    Public Property ListVENT_DocsVentaFaltante() As List(Of EVENT_DocsVenta)
        Get
            Return m_listvent_docsventafaltante
        End Get
        Set(ByVal value As List(Of EVENT_DocsVenta))
            m_listvent_docsventafaltante = value
        End Set
    End Property

    Public Property DIST_Ordenes() As EDIST_Ordenes
        Get
            Return m_dist_ordenes
        End Get
        Set(ByVal value As EDIST_Ordenes)
            m_dist_ordenes = value
        End Set
    End Property


    Public Property DIST_OrdenesPorduccion() As EABAS_OrdenesProduccion
        Get
            Return m_dist_ordenesP
        End Get
        Set(ByVal value As EABAS_OrdenesProduccion)
            m_dist_ordenesP = value
        End Set
    End Property

    Public Property VENT_DocsVenta() As EVENT_DocsVenta
        Get
            Return m_vent_Nc
        End Get
        Set(value As EVENT_DocsVenta)
            m_vent_Nc = value
        End Set
    End Property
        Public Property DIST_GuiasRemision() As EDIST_GuiasRemision
        Get
            Return m_dist_guias
        End Get
        Set(value As EDIST_GuiasRemision)
            m_dist_guias = value
        End Set
    End Property


#End Region

#Region " Constructores "

    Public Sub New(ByVal x_pvent_id As Long, ByVal x_periodo As String, ByVal x_sucur_id As Integer)
        m_periodo = x_periodo
        m_pvent_id = x_pvent_id
        m_sucur_id = x_sucur_id
        d_reporte = New DReporte
    End Sub
#End Region

#Region " Metodos "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x_fecini"></param>
    ''' <param name="x_fecfin"></param>
    ''' <param name="x_pvent_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RCuadreCaja(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        Dim m_listCuadreCaja_Facturas As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Egreso As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Egreso_trans As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Ingreso As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Ingreso_Trans As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Efectivo As New List(Of ECCuadreCaja)
        m_saldocaja = New ESaldoCaja
        m_saldocajaefectivo = New ESaldoCaja
        m_listcuadrecaja = New List(Of ECCuadreCaja)
        Try

            If d_reporte.VENT_CAJASS_CuadreCaja_Facturas(m_listCuadreCaja_Facturas, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja) Then
                m_listcuadrecaja = New List(Of ECCuadreCaja)(m_listCuadreCaja_Facturas)
            End If
            If d_reporte.VENT_CAJASS_CuadreCaja_Ingresos(m_listCuadreCaja_Ingreso, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja) Then
                For Each item As ECCuadreCaja In m_listCuadreCaja_Ingreso
                    m_listcuadrecaja.Add(item)
                Next
            End If
            If d_reporte.VENT_CAJASS_CuadreCaja_Ingresos_Trans(m_listCuadreCaja_Ingreso_Trans, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja) Then
                For Each item As ECCuadreCaja In m_listCuadreCaja_Ingreso_Trans
                    m_listcuadrecaja.Add(item)
                Next
            End If
            If d_reporte.VENT_CAJASS_CuadreCaja_Egresos(m_listCuadreCaja_Egreso, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja) Then
                For Each item As ECCuadreCaja In m_listCuadreCaja_Egreso
                    m_listcuadrecaja.Add(item)
                Next
            End If
            If d_reporte.VENT_CAJASS_CuadreCaja_Egresos_Trans(m_listCuadreCaja_Egreso_trans, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja) Then
                For Each item As ECCuadreCaja In m_listCuadreCaja_Egreso_trans
                    m_listcuadrecaja.Add(item)
                Next
            End If

            d_reporte.VENT_CAJASS_SaldoInicial(m_saldocaja, x_fecini, x_pvent_id, x_trcuadrecaja)

            Select Case x_trcuadrecaja
                Case TRCuadreCaja.Actual

                Case TRCuadreCaja.Nuevo
                    d_reporte.VENT_CCAJASS_SaldoInicialEfectivo(m_saldocajaefectivo, x_fecini, x_fecfin, m_pvent_id)
                    Dim _caja As New ECCuadreCaja
                    _caja.Orden = 4
                    _caja.Titulo = "Movimiento de Efectivo"
                    _caja.Title = "04.- Movimiento de Efectivo"
                    _caja.Fecha = x_fecini
                    _caja.ENTID_Codigo = "0000000000"
                    _caja.Detalle = String.Format("Saldo Inicial al dia{0:dd/MM/yyyy}", x_fecini.AddDays(-1))
                    _caja.ENTID_RazonSocial = String.Format("Saldo Inicial al dia{0:dd/MM/yyyy}", x_fecini.AddDays(-1))
                    _caja.ImpSoles = m_saldocajaefectivo.Ingreso
                    _caja.ImpDolares = m_saldocajaefectivo.IngresoDol
                    _caja.Moneda = ""
                    _caja.Documento = String.Format(" SI-{1:yyyymmdd}", m_pvent_id, x_fecini.AddDays(-1))
                    m_listCuadreCaja_Efectivo.Add(_caja)
                    If d_reporte.VENT_CCAJASS_Efectivo(m_listCuadreCaja_Efectivo, x_fecini, x_fecfin, x_pvent_id) Then
                        For Each item As ECCuadreCaja In m_listCuadreCaja_Efectivo
                            m_listcuadrecaja.Add(item)
                        Next
                    End If

            End Select


            '' Calcular Saldos
            Dim _importe_fcfac As Decimal = 0 : Dim _importe_fcfac_dol As Decimal = 0
            Dim _importe_oi As Decimal = 0 : Dim _importe_oi_dol As Decimal = 0
            Dim _importe_re As Decimal = 0 : Dim _importe_re_dol As Decimal = 0
            Dim _importe_gviaje As Decimal = 0 : Dim _importe_gviaje_dol As Decimal = 0
            For Each item As ECCuadreCaja In m_listcuadrecaja
                If item.Orden = 2 Then
                    Dim i As Integer = 0
                End If
                If Not IsNothing(item.ENTID_RazonSocial) Then item.ENTID_RazonSocial = item.ENTID_RazonSocial.Replace(vbCrLf, " ")
                Select Case item.Orden
                    Case TipoDocumento.DocumentosVenta
                        _importe_fcfac += item.ImpSoles
                        _importe_fcfac_dol += item.ImpDolares
                    Case TipoDocumento.OtrosIngresos
                        _importe_oi += item.ImpSoles
                        _importe_oi_dol += item.ImpDolares
                    Case TipoDocumento.RecibosEgreso
                        _importe_re += item.ImpSoles
                        _importe_re_dol += item.ImpDolares
                    Case TipoDocumento.GastosViaje
                        _importe_gviaje += item.ImpSoles
                        _importe_gviaje_dol += item.ImpDolares
                    Case Else

                End Select
            Next




            m_saldocaja.Ingreso = _importe_fcfac + _importe_oi ' m_saldocaja.SaldoInicial  
            m_saldocaja.IngresoDol = _importe_fcfac_dol + _importe_oi_dol ' m_saldocaja.SaldoInicialDol 
            m_saldocaja.Egreso = _importe_re
            m_saldocaja.EgresoDol = _importe_re_dol +
            m_saldocaja.Saldo = (m_saldocaja.SaldoInicial + m_saldocaja.Ingreso) - m_saldocaja.Egreso
            '  MsgBox(m_saldocaja.Saldo)
            m_saldocaja.SaldoDol = (m_saldocaja.SaldoInicialDol + m_saldocaja.IngresoDol) - m_saldocaja.EgresoDol
            Return m_listcuadrecaja.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x_fecini"></param>
    ''' <param name="x_fecfin"></param>
    ''' <param name="x_pvent_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RCuadreCajaCreditos(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean ', ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        Dim m_listCuadreCaja_Facturas As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Egreso As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Egreso_trans As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Ingreso As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Ingreso_Trans As New List(Of ECCuadreCaja)
        Dim m_listCuadreCaja_Efectivo As New List(Of ECCuadreCaja)
        m_saldocaja = New ESaldoCaja
        m_saldocajaefectivo = New ESaldoCaja
        m_listcuadrecaja = New List(Of ECCuadreCaja)
        Try

            If d_reporte.VENT_CAJASS_CuadreCaja_Facturas_Creditos(m_listCuadreCaja_Facturas, x_fecini, x_fecfin, x_pvent_id) Then ', x_trcuadrecaja) Then
                m_listcuadrecaja = New List(Of ECCuadreCaja)(m_listCuadreCaja_Facturas)
            End If
            If d_reporte.VENT_CAJASS_CuadreCaja_Ingresos_Creditos(m_listCuadreCaja_Ingreso, x_fecini, x_fecfin, x_pvent_id) Then ', x_trcuadrecaja) Then
                For Each item As ECCuadreCaja In m_listCuadreCaja_Ingreso
                    m_listcuadrecaja.Add(item)
                Next
            End If
            '    If d_reporte.VENT_CAJASS_CuadreCaja_Ingresos_Trans(m_listCuadreCaja_Ingreso_Trans, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja) Then
            '        For Each item As ECCuadreCaja In m_listCuadreCaja_Ingreso_Trans
            '            m_listcuadrecaja.Add(item)
            '        Next
            '    End If
            If d_reporte.VENT_CAJASS_CuadreCaja_Egresos_Creditos(m_listCuadreCaja_Egreso, x_fecini, x_fecfin, x_pvent_id) Then ', x_trcuadrecaja) Then
                For Each item As ECCuadreCaja In m_listCuadreCaja_Egreso
                    m_listcuadrecaja.Add(item)
                Next
            End If
            '    If d_reporte.VENT_CAJASS_CuadreCaja_Egresos_Trans(m_listCuadreCaja_Egreso_trans, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja) Then
            '        For Each item As ECCuadreCaja In m_listCuadreCaja_Egreso_trans
            '            m_listcuadrecaja.Add(item)
            '        Next
            '    End If

            'd_reporte.VENT_CAJASS_SaldoInicial(m_saldocaja, x_fecini, x_pvent_id, x_trcuadrecaja)

            '    Select Case x_trcuadrecaja
            '        Case TRCuadreCaja.Actual

            '        Case TRCuadreCaja.Nuevo
            '            d_reporte.VENT_CCAJASS_SaldoInicialEfectivo(m_saldocajaefectivo, x_fecini, x_fecfin, m_pvent_id)
            '            Dim _caja As New ECCuadreCaja
            '            _caja.Orden = 4
            '            _caja.Titulo = "Movimiento de Efectivo"
            '            _caja.Title = "04.- Movimiento de Efectivo"
            '            _caja.Fecha = x_fecini
            '            _caja.ENTID_Codigo = "0000000000"
            '            _caja.Detalle = String.Format("Saldo Inicial al dia{0:dd/MM/yyyy}", x_fecini.AddDays(-1))
            '            _caja.ENTID_RazonSocial = String.Format("Saldo Inicial al dia{0:dd/MM/yyyy}", x_fecini.AddDays(-1))
            '            _caja.ImpSoles = m_saldocajaefectivo.Ingreso
            '            _caja.ImpDolares = m_saldocajaefectivo.IngresoDol
            '            _caja.Moneda = ""
            '            _caja.Documento = String.Format(" SI-{1:yyyymmdd}", m_pvent_id, x_fecini.AddDays(-1))
            '            m_listCuadreCaja_Efectivo.Add(_caja)
            '            If d_reporte.VENT_CCAJASS_Efectivo(m_listCuadreCaja_Efectivo, x_fecini, x_fecfin, x_pvent_id) Then
            '                For Each item As ECCuadreCaja In m_listCuadreCaja_Efectivo
            '                    m_listcuadrecaja.Add(item)
            '                Next
            '            End If

            '    End Select


            '' Calcular Saldos
            Dim _importe_fcfac As Decimal = 0 : Dim _importe_fcfac_dol As Decimal = 0
            Dim _importe_oi As Decimal = 0 : Dim _importe_oi_dol As Decimal = 0
            Dim _importe_re As Decimal = 0 : Dim _importe_re_dol As Decimal = 0
            Dim _importe_gviaje As Decimal = 0 : Dim _importe_gviaje_dol As Decimal = 0
            For Each item As ECCuadreCaja In m_listcuadrecaja
                If item.Orden = 2 Then
                    Dim i As Integer = 0
                End If
                If Not IsNothing(item.ENTID_RazonSocial) Then item.ENTID_RazonSocial = item.ENTID_RazonSocial.Replace(vbCrLf, " ")
                Select Case item.Orden
                    Case TipoDocumento.DocumentosVenta
                        _importe_fcfac += item.ImpSoles
                        _importe_fcfac_dol += item.ImpDolares
                    Case TipoDocumento.OtrosIngresos
                        _importe_oi += item.ImpSoles
                        _importe_oi_dol += item.ImpDolares
                    Case TipoDocumento.RecibosEgreso
                        _importe_re += item.ImpSoles
                        _importe_re_dol += item.ImpDolares
                    Case TipoDocumento.GastosViaje
                        _importe_gviaje += item.ImpSoles
                        _importe_gviaje_dol += item.ImpDolares
                    Case Else

                End Select
            Next




            m_saldocaja.Ingreso = _importe_fcfac + _importe_oi ' m_saldocaja.SaldoInicial  
            m_saldocaja.IngresoDol = _importe_fcfac_dol + _importe_oi_dol ' m_saldocaja.SaldoInicialDol 
            m_saldocaja.Egreso = _importe_re
            m_saldocaja.EgresoDol = _importe_re_dol
            m_saldocaja.Saldo = (m_saldocaja.SaldoInicial + m_saldocaja.Ingreso) - m_saldocaja.Egreso
            m_saldocaja.SaldoDol = (m_saldocaja.SaldoInicialDol + m_saldocaja.IngresoDol) - m_saldocaja.EgresoDol
            Return m_listcuadrecaja.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function RMovimientoEfectivo(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
    '   Try
    '      VENT_REPOSS_MovimientoEfectivo(x_fecini, x_fecfin)
    '   Catch ex As Exception
    '      Throw ex
    '   End Try
    'End Function


#End Region

#Region " Procedimientos "

    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJASS_CuadreCaja_Facturas
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadreCaja_Facturas(ByRef x_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        x_listccuadrecaja = New List(Of ECCuadreCaja)
        Try
            Return d_reporte.VENT_CAJASS_CuadreCaja_Facturas(x_listccuadrecaja, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJASS_CuadreCaja_Facturas_Creditos
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadreCaja_Facturas_Creditos(ByRef x_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean ', ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        x_listccuadrecaja = New List(Of ECCuadreCaja)
        Try
            Return d_reporte.VENT_CAJASS_CuadreCaja_Facturas_Creditos(x_listccuadrecaja, x_fecini, x_fecfin, x_pvent_id) ', x_trcuadrecaja)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' para buscar ventas facturacion Electronica Notas_Cre _A
    ''' </summary>
    ''' <param name="x_pedid_codigo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function REPOS_NotasCre(ByVal x_pedid_codigo As String) As Boolean
        m_vent_Nc = New EVENT_DocsVenta
        Try
            Return d_reporte.REPOSS_NotasCre(m_vent_Nc, x_pedid_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function REPOS_Fac(ByVal x_pedid_codigo As String) As Boolean
        m_vent_Nc = New EVENT_DocsVenta
        Try
            Return d_reporte.REPOSS_Fac(m_vent_Nc, x_pedid_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function REPOS_Guias(ByVal x_guiar_codigo As String) As Boolean
        m_dist_guias = New EDIST_GuiasRemision
        Try
            Return d_reporte.REPOSS_Guias(m_dist_guias, x_guiar_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJASS_CuadreCaja_Egresos
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadreCaja_Egresos(ByRef x_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        x_listccuadrecaja = New List(Of ECCuadreCaja)
        Try
            Return d_reporte.VENT_CAJASS_CuadreCaja_Egresos(x_listccuadrecaja, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJASS_CuadreCaja_Ingresos
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadreCaja_Ingresos(ByRef x_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        x_listccuadrecaja = New List(Of ECCuadreCaja)
        Try
            Return d_reporte.VENT_CAJASS_CuadreCaja_Ingresos(x_listccuadrecaja, x_fecini, x_fecfin, x_pvent_id, x_trcuadrecaja)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJASS_CuadrePendientes
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_pvent_id">Parametro 2: </param> 
    ''' <param name="x_orden">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadrePendientes(ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_orden As Short, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        m_listccuadrependientes = New List(Of ECCuadrePendientes)
        Try
            Return d_reporte.VENT_CAJASS_CuadrePendientes(m_listccuadrependientes, x_fecfin, x_pvent_id, x_orden, x_trcuadrecaja)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJASS_CuadrePendientesCreditos
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_pvent_id">Parametro 2: </param> 
    ''' <param name="x_orden">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadrePendientesCreditos(ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_orden As Short) As Boolean ', ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        m_listccuadrependientes = New List(Of ECCuadrePendientes)
        Try
            Return d_reporte.VENT_CAJASS_CuadrePendientesCreditos(m_listccuadrependientes, x_fecfin, x_pvent_id, x_orden) ', x_trcuadrecaja)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJASS_CuadrePendientes
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_pvent_id">Parametro 2: </param> 
    ''' <param name="x_orden">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadrePendientes(ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_orden As Short) As Boolean
        m_listvent_docsventa = New List(Of EVENT_DocsVenta)
        Try
            Return d_reporte.VENT_CAJASS_CuadrePendientes(m_listvent_docsventa, x_fecfin, x_pvent_id, x_orden)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJASS_CobranzaPendiente
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <param name="x_fecha">Parametro 5: </param> 
    ''' <param name="x_entid_codigovendedor">Parametro 6: </param> 
    ''' <param name="x_entid_codigocliente">Parametro 7: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CobranzaPendiente(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_fecha As Boolean, ByVal x_entid_codigovendedor As String, ByVal x_entid_codigocliente As String) As Boolean
        m_listccuadrependientes = New List(Of ECCuadrePendientes)
        Try
            Return d_reporte.VENT_CAJASS_CobranzaPendiente(m_listccuadrependientes, x_fecini, x_fecfin, x_pvent_id, x_fecha, x_entid_codigovendedor, x_entid_codigocliente)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Reporte de ventas
    ''' </summary>
    ''' <param name="x_fecini">fecha hasta donde se muestra las ventas</param>
    ''' <param name="x_fin">fecha de fin</param>
    ''' <param name="x_zonas_codigo">codigo de la zona</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function reporteVentas(ByVal x_fecini As DateTime, ByVal x_fin As DateTime, ByVal x_zonas_codigo As String) As Boolean
        Try
            Dim _bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, x_zonas_codigo, m_sucur_id)
            If _bvent_docsventa.REPOSS_Ventas(x_fecini, x_fin, m_pvent_id) Then
                m_listvent_docsventa = New List(Of EVENT_DocsVenta)(_bvent_docsventa.ListVENT_DocsVenta)
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: LOG_DIST_CuadrePendientes
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_almac_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_CuadrePendientesVentas(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Short, Optional ByVal x_pvent_id As Long = Nothing, Optional ByVal x_artic_codigo As String = Nothing, Optional ByVal x_entid_codigo As String = Nothing, Optional ByVal x_fecha As Boolean = True, Optional ByVal x_desbloqueo As Boolean = False) As Boolean
        m_listvent_docsventadetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            'x_desbloqueo = True
            Return d_reporte.LOG_DIST_CuadrePendientesVentas(m_listvent_docsventadetalle, x_fecini, x_fecfin, x_almac_id, x_pvent_id, x_artic_codigo, x_entid_codigo, x_fecha, x_desbloqueo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: LOG_DIST_CuadrePendientesOrdenes
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_almac_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_CuadrePendientesOrdenes(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Short, Optional ByVal x_pvent_id As Long = Nothing, Optional ByVal x_artic_codigo As String = Nothing, Optional ByVal x_entid_codigo As String = Nothing, Optional ByVal x_fecha As Boolean = True, Optional ByVal x_desbloqueo As Boolean = False) As Boolean
        m_listvent_docsventadetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            'x_desbloqueo = True
            Return d_reporte.LOG_DIST_CuadrePendientesOrdenes(m_listvent_docsventadetalle, x_fecini, x_fecfin, x_almac_id, x_pvent_id, x_artic_codigo, x_entid_codigo, x_fecha, x_desbloqueo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function LOG_DIST_CuadrePendientesReposicion(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Short, Optional ByVal x_pvent_id As Long = Nothing, Optional ByVal x_artic_codigo As String = Nothing, Optional ByVal x_entid_codigo As String = Nothing, Optional ByVal x_fecha As Boolean = True, Optional ByVal x_desbloqueo As Boolean = False) As Boolean
        m_listvent_docsventadetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            'x_desbloqueo = True
            Return d_reporte.LOG_DIST_CuadrePendientesReposicion(m_listvent_docsventadetalle, x_fecini, x_fecfin, x_almac_id, x_pvent_id, x_artic_codigo, x_entid_codigo, x_fecha, x_desbloqueo)
        Catch ex As Exception

        End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: LOG_DIST_CuadrePendientesIntegrado
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_almac_id">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_artic_codigo">Parametro 5: </param> 
    ''' <param name="x_entid_codigo">Parametro 6: </param> 
    ''' <param name="x_fecha">Parametro 7: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_CuadrePendientesIntegrado(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Short, Optional ByVal x_pvent_id As Long = Nothing, Optional ByVal x_artic_codigo As String = Nothing, Optional ByVal x_entid_codigo As String = Nothing, Optional ByVal x_fecha As Boolean = True, Optional ByVal x_desbloqueo As Boolean = False) As Boolean
        m_listvent_docsventadetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_reporte.LOG_DIST_CuadrePendientesIntegrado(m_listvent_docsventadetalle, x_fecini, x_fecfin, x_almac_id, x_pvent_id, x_artic_codigo, x_entid_codigo, x_fecha, x_desbloqueo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: LOG_DISTSS_ReporVentXCliente
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_usuario">Parametro 3: </param> 
    ''' <param name="x_cliente">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DISTSS_ReporVentXCliente(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_usuario As String, ByVal x_cliente As String) As Boolean
        m_listvent_docsventa = New List(Of EVENT_DocsVenta)
        Try
            Return d_reporte.LOG_DISTSS_ReporVentXCliente(m_listvent_docsventa, x_fecini, x_fecfin, x_usuario, x_cliente)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_CCAJASS_Efectivo
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CCAJASS_Efectivo(ByRef x_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        x_listccuadrecaja = New List(Of ECCuadreCaja)
        Try
            Return d_reporte.VENT_CCAJASS_Efectivo(x_listccuadrecaja, x_fecini, x_fecfin, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_CCAJASS_SaldoInicialEfectivo
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CCAJASS_SaldoInicialEfectivo(ByRef x_saldocaja As ESaldoCaja, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        x_saldocaja = New ESaldoCaja
        Try
            Return d_reporte.VENT_CCAJASS_SaldoInicialEfectivo(x_saldocaja, x_fecini, x_fecfin, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENT_CAJAS_CuadreCaja_Resumen
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJAS_CuadreCaja_Resumen(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        m_listcuadrecaja = New List(Of ECCuadreCaja)
        m_dsReportes = New DataSet()
        Try
            Return d_reporte.VENT_CAJAS_CuadreCaja_Resumen(m_dsReportes, m_listcuadrecaja, x_fecini, x_fecfin, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: VENTSS_VentasXCliente
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigo">Parametro 3: </param> 
    ''' <param name="x_linea">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENTSS_VentasXCliente(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_linea As String) As Boolean
        m_listvent_docsventadetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_reporte.VENTSS_VentasXCliente(m_listvent_docsventadetalle, x_fecini, x_fecfin, x_entid_codigo, x_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: REPOSS_CuentasCorrientes
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigo">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_fecha">Parametro 5: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_CuentasCorrientes(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_fecha As Boolean) As Boolean
        m_listvent_docsventa = New List(Of EVENT_DocsVenta)
        Try
            Return d_reporte.REPOSS_CuentasCorrientes(m_listvent_docsventa, x_fecini, x_fecfin, x_entid_codigo, x_pvent_id, x_fecha)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " Reportes de Caja "

    ''' <summary> 
    ''' Capa de Negocio: VENT_REPOSS_MovimientoEfectivo
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_REPOSS_MovimientoEfectivo(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        m_listteso_docspagos = New List(Of ETESO_DocsPagos)
        m_saldocaja = New ESaldoCaja
        Try
            Return d_reporte.VENT_REPOSS_MovimientoEfectivo(m_listteso_docspagos, m_saldocaja, x_fecini, x_fecfin, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: REPOSS_MovimientoCaja
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_MovimientoCaja(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            Return d_reporte.REPOSS_MovimientoCaja(m_data, x_fecini, x_fecfin, m_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: REPOSS_ReporteCobranza
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_ReporteCobranza(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            Return d_reporte.REPOSS_ReporteCobranza(m_data, x_fecini, x_fecfin, m_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: REPOSS_ReporteBancarizacion
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_ReporteBancarizacion(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            Return d_reporte.REPOSS_ReporteBancarizacion(m_data, x_fecini, x_fecfin, m_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: REPOSS_ReporteVentasAnuladas
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_ReporteVentasAnuladas(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            Return d_reporte.REPOSS_ReporteVentasAnuladas(m_data, x_fecini, x_fecfin, m_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " Reportes de Despachos "

    ''' <summary> 
    ''' Capa de Negocio: REPOSS_GuiasTraslado
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_GuiasTraslado(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            Return d_reporte.REPOSS_GuiasTraslado(m_data, x_fecini, x_fecfin, m_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " Cotizaciones / Pedidos"
    ''' <summary> 
    ''' Capa de Negocio: REPOSS_CotizacionVenta
    ''' </summary>
    ''' <param name="x_pedid_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_CotizacionVenta(ByVal x_pedid_codigo As String) As Boolean
        m_vent_pedidos = New EVENT_Pedidos
        Try
            Return d_reporte.REPOSS_CotizacionVenta(m_vent_pedidos, x_pedid_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Gestion Ordenes"
    ''' <summary> 
    ''' Capa de Negocio: REPOSS_CotizacionVenta
    ''' </summary>
    ''' <param name="x_pedid_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_GestionOrdenes(ByVal x_gestion_codigo As String) As Boolean
        m_abas_gestionOC = New EABAS_GestionOrdenes
        Try
            Return d_reporte.LOG_DISTSS_ObtenerGestionOrdenReport(m_abas_gestionOC, x_gestion_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Reporte de Ventas "

    ''' <summary> 
    ''' Capa de Negocio: Linea _a
    ''' </summary> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <param name="x_zonas_codigo">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function Linea_Produto(ByVal x_articulo As String) As Boolean
        Try
            m_dtReportes = New DataTable
            Return d_reporte.lineas_Articulos(m_dtReportes, x_articulo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function







    ''' <summary>
    ''' Generar el reporte de ventas
    ''' </summary>
    ''' <param name="x_fecini">fecha de inicio de busqueda</param>
    ''' <param name="x_fecfin">fecha de fin de busqueda</param>
    ''' <param name="x_treporte">tipo de reporte requerido</param>
    ''' <param name="x_entid_codigo">codigo de la entidad cliente que se desea el reporte</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReporteVentas(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_treporte As TRVentas, ByVal x_entid_codigo As String) As Boolean
        Try

            If REPOSS_VentasTodos(x_fecini, x_fecfin, m_pvent_id, x_treporte, x_entid_codigo) Then
                Select Case x_treporte
                    Case TRVentas.Todos
                        For Each item As EVENT_DocsVenta In m_listvent_docsventa
                            If item.DOCVE_Estado = Constantes.getEstado(Constantes.Estado.Anulado) Then
                                item.ImporteSoles = 0
                                item.ImporteDolares = 0
                            End If
                        Next
                        Return True
                    Case TRVentas.Anuladas
                        Return True
                    Case TRVentas.AnuladasMDia
                        Return True
                    Case TRVentas.Correlatividad
                        m_listvent_docsventafaltante = New List(Of EVENT_DocsVenta)
                        For Each item As EVENT_DocsVenta In m_listvent_docsventacorr
                            Dim _filter As New ACFramework.ACFiltrador(Of EVENT_DocsVenta)(String.Format("TIPOS_CodTipoDocumento={0} AND DOCVE_Serie={1}", item.TIPOS_CodTipoDocumento, item.DOCVE_Serie))
                            _filter.ACFiltrar(m_listvent_docsventa)
                            Dim _ini As Integer = _filter.ACListaFiltrada(0).DOCVE_Numero
                            Dim _fin As Integer = _filter.ACListaFiltrada(_filter.ACListaFiltrada.Count - 1).DOCVE_Numero
                            Dim _index As Integer = 0
                            While _ini < _fin
                                If Not _ini = _filter.ACListaFiltrada(_index).DOCVE_Numero Then
                                    Dim _docventa As New EVENT_DocsVenta
                                    _docventa.DOCVE_Numero = _ini
                                    _docventa.DOCVE_Serie = item.DOCVE_Serie
                                    _docventa.TIPOS_CodTipoDocumento = item.TIPOS_CodTipoDocumento
                                    _docventa.TIPOS_TipoDocCorta = item.TIPOS_TipoDocCorta
                                    _docventa.Titulo = _filter.ACListaFiltrada(_index).Titulo
                                    m_listvent_docsventafaltante.Add(_docventa)
                                    _ini += 1
                                Else
                                    _ini += 1
                                    _index += 1
                                End If

                            End While

                            'For index = 1 To 10
                            '   'For Each DocVenta As EVENT_DocsVenta In _filter.ACListaFiltrada
                            'Next

                        Next
                        Return True
                    Case TRVentas.VentasXCliente
                        Return True
                    Case Else

                End Select
            Else
                Return False
            End If

            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: REPOSS_VentasTodos
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_VentasTodos(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_opcion As Short, ByVal x_entid_codigo As String) As Boolean
        m_listvent_docsventa = New List(Of EVENT_DocsVenta)
        m_listvent_docsventacorr = New List(Of EVENT_DocsVenta)
        Try
            Return d_reporte.REPOSS_VentasTodos(m_listvent_docsventa, m_listvent_docsventacorr, x_fecini, x_fecfin, x_pvent_id, x_opcion, x_entid_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Reporte de estado de cuenta corriente de los clientes
    ''' </summary>
    ''' <param name="x_fecini">fecha de inicio de reporte</param>
    ''' <param name="x_fecfin">fecha de fin de reporte</param>
    ''' <param name="x_entid_codigo">codigo de entidad</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReporteEstadoCtaCte(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String)
        Try
            If REPOSS_EstadoCuentaCorriente(x_fecini, x_fecfin, x_entid_codigo, m_pvent_id) Then
                Dim _saldo As Decimal = 0
                For Each item As EVENT_DocsVenta In m_listvent_docsventa
                    _saldo += item.Cargo - item.Abono
                    item.SaldoCta = _saldo
                Next

                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: REPOSS_EstadoCuentaCorriente
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigo">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_EstadoCuentaCorriente(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Boolean
        m_listvent_docsventa = New List(Of EVENT_DocsVenta)
        Try
            Return d_reporte.REPOSS_EstadoCuentaCorriente(m_listvent_docsventa, x_fecini, x_fecfin, x_entid_codigo, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Stock  "

    ''' <summary> 
    ''' Capa de Negocio: VENTSS_ListaPrecios
    ''' </summary> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <param name="x_zonas_codigo">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ListaPrecios(ByVal x_almac_id As Short, ByVal x_zonas_codigo As String, ByVal x_articulo As String, ByVal x_linea As String) As Boolean
        Try
            m_dtReportes = New DataTable
            Return d_reporte.VENTSS_ListaPrecios(m_dtReportes, m_periodo, x_almac_id, x_zonas_codigo, x_articulo, x_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#End Region

#Region " Metodos de Controles"

#End Region


End Class
