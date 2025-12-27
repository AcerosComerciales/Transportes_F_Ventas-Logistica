Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports DAConexion
Imports System.Configuration

Imports ACFramework


Public Class BTESO_DocsPagos

#Region " Variables "
   Private m_pvent_id As Long
   Private m_periodo As String
   Private m_zonas_codigo As String
   Private m_surcu_id As Integer
#End Region

#Region " Constructores "
   Public Sub New(ByVal x_pvent_id As Integer, ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer)
      m_pvent_id = x_pvent_id
      m_periodo = x_periodo
      m_zonas_codigo = x_zonas_codigo
      m_surcu_id = x_sucur_id
      d_teso_docspagos = New DTESO_DocsPagos()
   End Sub
#End Region

#Region " Propiedades "
   
#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "

   ''' <summary> 
   ''' Capa de Negocio: TESO_DOCPSS_ConsutaNotaCredito
   ''' </summary>
   ''' <param name="x_tipodoc">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <param name="x_opcion">Parametro 3: </param> 
   ''' <param name="x_cadena">Parametro 4: </param> 
   ''' <param name="x_fecini">Parametro 5: </param> 
   ''' <param name="x_fecfin">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ConsutaNotaCredito(ByVal x_tipodoc As String, ByVal x_pvent_id As Long, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      m_listTESO_DocsPagos = New List(Of ETESO_DocsPagos)
      Try
         Return d_teso_docspagos.TESO_DOCPSS_ConsutaNotaCredito(m_listTESO_DocsPagos, x_tipodoc, x_pvent_id, x_opcion, x_cadena, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar documento de pago
   ''' </summary>
   ''' <param name="x_dpago_id">codigo del documento de pago</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
    Public Function CargarDocumento(ByVal x_dpago_id As Long, ByVal x_entid_codigo As String) As Boolean
        Try
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin(EBancos.Esquema, EBancos.Tabla, ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("BANCO_Id", "BANCO_Id")} _
                              , New ACCampos() {New ACCampos("BANCO_Descripcion", "BANCO_Descripcion")}))
            _join.Add(New ACJoin(ECuentas.Esquema, ECuentas.Tabla, ACJoin.TipoJoin.Left _
                                 , New ACCampos() {New ACCampos("CUENT_Id", "CUENT_Id")} _
                                 , New ACCampos() {New ACCampos("CUENT_Numero", "CUENT_Numero")}))
            _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                                 , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))
            _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TMon", ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                                 , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoMoneda") _
                                                   , New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMonedaCorta")}))
            Dim _where As New Hashtable()
            _where.Add("DPAGO_Id", New ACWhere(x_dpago_id))
            _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
            Return Cargar(_join, _where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Busqueda de documentos de pago
   ''' </summary>
   ''' <param name="x_cadena"></param>
   ''' <param name="x_tipdoc"></param>
   ''' <param name="x_opcion"></param>
   ''' <param name="x_fecini"></param>
   ''' <param name="x_fecfin"></param>
   ''' <param name="x_todos"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String, ByVal x_tipdoc As String, ByVal x_opcion As Short, ByVal x_fecini As DateTime, ByVal x_fecfin As Date, ByVal x_todos As Boolean) As Boolean
      Try
         m_listTESO_DocsPagos = New List(Of ETESO_DocsPagos)()

         If x_tipdoc = ETipos.getTipoDocPago(ETipos.TipoDocPago.NotaCredito) Then
            Return ConsutaNotaCredito(x_tipdoc, m_pvent_id, x_opcion, x_cadena, x_fecini, x_fecfin)
         Else
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin(EBancos.Esquema, EBancos.Tabla, ACJoin.TipoJoin.Left _
                                 , New ACCampos() {New ACCampos("BANCO_Id", "BANCO_Id")} _
                                 , New ACCampos() {New ACCampos("BANCO_Descripcion", "BANCO_Descripcion")}))

            _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, ACJoin.TipoJoin.Inner _
                                , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                                , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoMoneda")}))

            _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Left _
                                , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                                , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))

            Dim _where As New Hashtable()

            _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipdoc, ACWhere.TipoWhere._Like))
            _where.Add("DPAGO_Fecha", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
            If x_opcion = 0 Then
               _where.Add("ENTID_RazonSocial", New ACWhere(x_cadena, "Ent", ACWhere.TipoWhere._Like))
            ElseIf x_opcion = 1 Then
               _where.Add("DPAGO_Numero", New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
            End If

            If Not x_todos Then
               _where.Add("DPAGO_Estado", New ACWhere("X", ACWhere.TipoWhere.Diferente))
            End If

            Return CargarTodos(_join, _where)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: TESO_DPAGSS_ObtenerDocPagos
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_opcion">Parametro 3: </param> 
   ''' <param name="x_cadena">Parametro 4: </param> 
   ''' <param name="x_optfecha">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
    Public Function ObtenerDocPagos(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_optfecha As Short) As Boolean
        m_listTESO_DocsPagos = New List(Of ETESO_DocsPagos)
        Try
            Return d_teso_docspagos.TESO_DPAGSS_ObtenerDocPagos(m_listTESO_DocsPagos, x_fecini, x_fecfin, x_opcion, x_cadena, x_optfecha)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' Capa de Negocio: TESO_DPAGSS_ObtenerDocPagos
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_opcion">Parametro 3: </param> 
    ' <param name="x_cadena">Parametro 4: </param> 
    ' <param name="x_optfecha">Parametro 5: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function Validar_Depositos(ByVal x_dpago_numero As String, ByVal x_banco_id As Integer, ByVal x_cuenta_id As Integer) As Boolean
        m_listTESO_DocsPagos = New List(Of ETESO_DocsPagos)
        Try
            Return d_teso_docspagos.ObtenerDepositos(x_dpago_numero, x_banco_id, x_cuenta_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Ayuda de los documentos de pago
   ''' </summary>
   ''' <param name="x_where">condicion para la consulta</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Ayuda(ByVal x_where As Hashtable) As Boolean
      Try
         If d_teso_docspagos.getAyuda(m_dsTESO_DocsPagos, x_where) Then
            m_dtTESO_DocsPagos = New DataTable()
            m_dtTESO_DocsPagos = m_dsTESO_DocsPagos.Tables(0)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Ayuda de documentos de pago
   ''' </summary>
   ''' <param name="x_fecini">fecha inicial de buqeuda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <param name="x_entid_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Ayuda(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String) As Boolean
      Try
         If d_teso_docspagos.getAyuda(m_dsTESO_DocsPagos, x_fecini, x_fecfin, x_entid_codigo) Then
            m_dtTESO_DocsPagos = New DataTable()
            m_dtTESO_DocsPagos = m_dsTESO_DocsPagos.Tables(0)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
    End Function

    ''' <summary>
    ''' Ayuda de documentos de pago
    ''' </summary>
    ''' <param name="x_fecini">fecha inicial de buqeuda</param>
    ''' <param name="x_fecfin">fecha final de busqueda</param>
    ''' <param name="x_entid_codigo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AyudaNC(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_entid_codigoDoc As String) As Boolean
        Try
            If d_teso_docspagos.getAyudaNC(m_dsTESO_DocsPagos, x_fecini, x_fecfin, x_entid_codigo, x_entid_codigoDoc) Then
                m_dtTESO_DocsPagos = New DataTable()
                m_dtTESO_DocsPagos = m_dsTESO_DocsPagos.Tables(0)
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Guardar documento de pago
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_detalle">para grabar el detalle del documento de pago</param>
   ''' <param name="x_opcion">tipo de documento de pago</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Guardar(ByVal x_usuario As String, ByVal x_detalle As Boolean, ByVal x_opcion As ETipos.TipoDocPago) As Boolean
      Try
         If x_detalle Then
            DAEnterprise.BeginTransaction()
            m_eteso_docspagos.ENTID_Codigo = m_eteso_docspagos.VENT_DocsVenta.ENTID_CodigoCliente
            If Guardar(x_usuario) Then
               Select Case x_opcion
                  Case ETipos.TipoDocPago.NotaCredito
                     Dim m_bgenerardocsventa As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_surcu_id)
                     Dim x_msg As String = ""
                     m_bgenerardocsventa.VENT_DocsVenta = m_eteso_docspagos.VENT_DocsVenta
                     m_bgenerardocsventa.VENT_DocsVenta.Instanciar(ACEInstancia.Nuevo)
                     m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Ingresado)
                     m_bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                     Dim _detalle As New EVENT_DocsVentaDetalle
                     _detalle.DOCVD_PrecioUnitario = m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
                     _detalle.DOCVD_SubImporteVenta = m_bgenerardocsventa.VENT_DocsVenta.DOCVE_ImporteVenta
                     _detalle.DOCVD_Cantidad = 1
                     m_bgenerardocsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle.Add(_detalle)
                            If Not m_bgenerardocsventa.generarDocumento(x_usuario, m_bgenerardocsventa.VENT_DocsVenta.DOCVE_FechaDocumento, _
                                                                    m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Serie, _
                                                                    m_bgenerardocsventa.VENT_DocsVenta.DOCVE_Numero, "E", x_msg, False, "") Then
                                DAEnterprise.RollBackTransaction()
                                Throw New Exception("No Se puede Generar el Documento Nota de Credito")
                            End If
                     DAEnterprise.CommitTransaction()
                     Return True
                  Case Else
                     Return Guardar(x_usuario)
               End Select
            End If
         Else
            Return Guardar(x_usuario)
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: VENT_DOCVESS_GetDocsPago
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function GetDocsPago(ByVal x_docve_codigo As String) As Boolean
      m_listTESO_DocsPagos = New List(Of ETESO_DocsPagos)
      Try
         Return d_teso_docspagos.VENT_DOCVESS_GetDocsPago(m_listTESO_DocsPagos, x_docve_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

