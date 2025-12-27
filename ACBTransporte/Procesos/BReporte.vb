Imports ACDTransporte
Imports ACETransporte
Imports ACBVentas
Imports ACEVentas
Imports ACFramework

Public Class BReporte
#Region " Variables "
   Private m_periodo As String
   Private m_sucur_id As Integer
   Private d_reporte As DReporte

   Private m_saldocaja As ESaldoCaja
   Private m_listcuadrecaja As List(Of ECuadreCaja)
   Private m_listtran_fletes As List(Of ETRAN_Fletes)
   Private m_pvent_id As Long
 Private m_listvent_docsventa As List(Of EVENT_DocsVenta)
   Private m_listccuadrependientes As List(Of ECCuadrePendientes)
    Private m_vent_docs As EVENT_DocsVenta
    Private m_vent_Nc As EVENT_DocsVenta
    Private m_gtran_guias As ETRAN_GuiasTransportista
#End Region

#Region " Propiedades "

   Public Property SaldoCaja() As ESaldoCaja
      Get
         Return m_saldocaja
      End Get
      Set(ByVal value As ESaldoCaja)
         m_saldocaja = value
      End Set
   End Property

   Public Property ListCuadreCaja() As List(Of ECuadreCaja)
      Get
         Return m_listcuadrecaja
      End Get
      Set(ByVal value As List(Of ECuadreCaja))
         m_listcuadrecaja = value
      End Set
   End Property

   Public Property ListTRAN_Fletes() As List(Of ETRAN_Fletes)
      Get
         Return m_listtran_fletes
      End Get
      Set(ByVal value As List(Of ETRAN_Fletes))
         m_listtran_fletes = value
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

   Public Property ListCCuadrePendientes() As List(Of ECCuadrePendientes)
      Get
         Return m_listccuadrependientes
      End Get
      Set(ByVal value As List(Of ECCuadrePendientes))
         m_listccuadrependientes = value
      End Set
   End Property

    Public Property  VENT_DocsVenta() As EVENT_DocsVenta
    GET
            return m_vent_docs
    End Get
    Set(value As EVENT_DocsVenta)
            m_vent_docs = value
    End Set
    End Property
    Public Property GTRAN_GuiasTransportista() As ETRAN_GuiasTransportista
        Get
            Return m_gtran_guias
        End Get
        Set(value As ETRAN_GuiasTransportista)
            m_gtran_guias = value
        End Set
    End Property

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_pvent_id As Long)
      d_reporte = New DReporte
      m_pvent_id = x_pvent_id
   End Sub

   Public Sub New(ByVal x_pvent_id As Long, ByVal x_periodo As String, ByVal x_sucur_id As Integer)
      m_periodo = x_periodo
      m_pvent_id = x_pvent_id
      m_sucur_id = x_sucur_id
      d_reporte = New DReporte
   End Sub
#End Region

#Region " Metodos "

   Enum TipoDocumento
      FletesCFactura = 1
      OtrosIngresos = 2
      RecibosEgreso = 3
      GastosViaje = 4
   End Enum

   Public Function CuadreCajaC(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
      Dim m_listCuadreCaja_Facturas As New List(Of ECuadreCaja)
      Dim m_listCuadreCaja_IngEgre As New List(Of ECuadreCaja)
      m_saldocaja = New ESaldoCaja
      m_listcuadrecaja = New List(Of ECuadreCaja)
      Try
         If d_reporte.TRAN_REPORSS_CuadreCaja_Facturas(m_listCuadreCaja_Facturas, x_fecini, x_fecfin, x_pvent_id) Then
            m_listcuadrecaja = New List(Of ECuadreCaja)(m_listCuadreCaja_Facturas)
         End If

         If d_reporte.TRAN_REPORSS_CuadreCaja_IngEgre(m_listCuadreCaja_IngEgre, x_fecini, x_fecfin, x_pvent_id) Then
            For Each item As ECuadreCaja In m_listCuadreCaja_IngEgre
               m_listcuadrecaja.Add(item)
            Next
         End If

         If d_reporte.TRAN_REPORSS_CuadreCaja_Pendientes(m_saldocaja, x_fecini, x_fecfin, x_pvent_id) Then
            
         End If

         '' Calcular Saldos
         Dim _importe_fcfac As Decimal = 0 : Dim _importe_fcfac_dol As Decimal = 0
         Dim _importe_oi As Decimal = 0 : Dim _importe_oi_dol As Decimal = 0
         Dim _importe_re As Decimal = 0 : Dim _importe_re_dol As Decimal = 0
         Dim _importe_gviaje As Decimal = 0 : Dim _importe_gviaje_dol As Decimal = 0
         For Each item As ECuadreCaja In m_listcuadrecaja
            If item.Orden = 2 Then
               Dim i As Integer = 0
            End If
            If Not IsNothing(item.ENTID_RazonSocial) Then item.ENTID_RazonSocial = item.ENTID_RazonSocial.Replace(vbCrLf, " ")
            Select Case item.Orden
               Case TipoDocumento.FletesCFactura
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
         m_saldocaja.Ingreso = m_saldocaja.SaldoInicial + _importe_fcfac + _importe_oi
         m_saldocaja.Egreso = _importe_re
         m_saldocaja.Saldo = m_saldocaja.Ingreso - m_saldocaja.Egreso
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    ' <summary>
    ' para buscar ventas facturacion Electronica Notas_Cre _A
    ' </summary>
    ' <param name="x_pedid_codigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function REPOS_NotasCre(ByVal x_pedid_codigo As String) As Boolean
        m_vent_Nc = New EVENT_DocsVenta
        Try
            Return d_reporte.REPOSS_NotasCre(m_vent_Nc, x_pedid_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' para buscar ventas facturacion Electronica_A
    ' </summary>
    ' <param name="x_pedid_codigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    public Function REPOS_DocsVenta(ByVal x_pedid_codigo As String) As Boolean
        m_vent_docs = New EVENT_DocsVenta
      Try
         Return d_reporte.REPOSS_DocsVenta(m_vent_docs, x_pedid_codigo)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    Public Function REPOS_Guias(ByVal x_guiar_codigo As String) As Boolean
        m_gtran_guias = New ETRAN_GuiasTransportista()
        Try
            Return d_reporte.REPOSS_Guias(m_gtran_guias, x_guiar_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function REPOS_GuiasTransportista(ByVal x_guiar_codigo As String) As Boolean
        m_gtran_guias = New ETRAN_GuiasTransportista()
        Try
            Return d_reporte.REPOSS_GuiasTransportista(m_gtran_guias, x_guiar_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function







   ' <summary> 
   ' Capa de Negocio: TRAN_REPORSS_CuadreCaja
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function CuadreCaja(ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      m_listcuadrecaja = New List(Of ECuadreCaja)
      m_saldocaja = New ESaldoCaja
      Try
         If d_reporte.TRAN_REPORSS_CuadreCaja(m_listcuadrecaja, m_saldocaja, x_fecini, x_fecfin) Then

            Dim _importe_fcfac As Decimal = 0 : Dim _importe_fcfac_dol As Decimal = 0
            Dim _importe_fsfac As Decimal = 0 : Dim _importe_fsfac_dol As Decimal = 0
            Dim _importe_oi As Decimal = 0 : Dim _importe_oi_dol As Decimal = 0
            Dim _importe_re As Decimal = 0 : Dim _importe_re_dol As Decimal = 0
            Dim _importe_dep As Decimal = 0 : Dim _importe_dep_dol As Decimal = 0
            Dim _importe_tra As Decimal = 0 : Dim _importe_tra_dol As Decimal = 0
            Dim _importe_ccomb As Decimal = 0 : Dim _importe_ccomb_dol As Decimal = 0
            'For Each item As ECuadreCaja In m_listcuadrecaja
            '   If item.Orden = 2 Then
            '      Dim i As Integer = 0
            '   End If
            '   item.ENTID_RazonSocial = item.ENTID_RazonSocial.Replace(vbCrLf, " ")
            '   Select Case item.Orden
            '      Case TipoDocumento.FletesCFactura
            '         _importe_fcfac += item.ImpSoles
            '         _importe_fcfac_dol += item.ImpDolares
            '      Case TipoDocumento.FletesSFactura
            '         _importe_fsfac += item.ImpSoles
            '         _importe_fsfac_dol += item.ImpDolares
            '      Case TipoDocumento.OtrosIngresos
            '         _importe_oi += item.ImpSoles
            '         _importe_oi_dol += item.ImpDolares
            '      Case TipoDocumento.RecibosEgreso
            '         _importe_re += item.ImpSoles
            '         _importe_re_dol += item.ImpDolares
            '      Case TipoDocumento.Depositos
            '         _importe_dep += item.ImpSoles
            '         _importe_dep_dol += item.ImpDolares
            '      Case TipoDocumento.Transferencia
            '         _importe_tra += item.ImpSoles
            '         _importe_tra_dol += item.ImpDolares
            '      Case TipoDocumento.GastosViaje
            '         '_importe_gas += item.ImpSoles
            '         '_importe_gas_dol += item.ImpDolares
            '      Case TipoDocumento.ConsumoCombustible
            '         _importe_ccomb += item.ImpSoles
            '         _importe_ccomb_dol += item.ImpDolares
            '      Case Else

            '   End Select

            'Next
            m_saldocaja.Ingreso = _importe_fcfac + _importe_fsfac + _importe_oi + _importe_tra
            m_saldocaja.Egreso = _importe_re + _importe_ccomb
            m_saldocaja.Saldo = m_saldocaja.Ingreso - m_saldocaja.Egreso
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Negocio: TRAN_CAJASS_CuadrePendientes
   ' </summary>
   ' <param name="x_fecfin">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function CuadrePendientes(ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
      m_listtran_fletes = New List(Of ETRAN_Fletes)
      Try
         Return d_reporte.TRAN_CAJASS_CuadrePendientes(m_listtran_fletes, x_fecfin, x_pvent_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Negocio: TRAN_REPOSS_ViajesFletes
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function REPORTE_ViajesFletes(ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      m_listtran_fletes = New List(Of ETRAN_Fletes)
      Try
         Return d_reporte.TRAN_REPOSS_ViajesFletes(m_listtran_fletes, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Negocio: REPOSS_CuentasCorrientes
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <param name="x_entid_codigo">Parametro 3: </param> 
   ' <param name="x_pvent_id">Parametro 4: </param> 
   ' <param name="x_fecha">Parametro 5: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function REPOSS_CuentasCorrientes(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_fecha As Boolean) As Boolean
      m_listvent_docsventa = New List(Of EVENT_DocsVenta)
      Try
         Return d_reporte.REPOSS_CuentasCorrientes(m_listvent_docsventa, x_fecini, x_fecfin, x_entid_codigo, x_pvent_id, x_fecha)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Negocio: VENT_CAJASS_CobranzaPendiente
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <param name="x_pvent_id">Parametro 3: </param> 
   ' <param name="x_fecha">Parametro 5: </param> 
   ' <param name="x_entid_codigovendedor">Parametro 6: </param> 
   ' <param name="x_entid_codigocliente">Parametro 7: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function VENT_CAJASS_CobranzaPendiente(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_fecha As Boolean, ByVal x_entid_codigovendedor As String, ByVal x_entid_codigocliente As String) As Boolean
      m_listccuadrependientes = New List(Of ECCuadrePendientes)
      Try
         Return d_reporte.VENT_CAJASS_CobranzaPendiente(m_listccuadrependientes, x_fecini, x_fecfin, x_pvent_id, x_fecha, x_entid_codigovendedor, x_entid_codigocliente)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos de Controles"

#End Region
End Class
