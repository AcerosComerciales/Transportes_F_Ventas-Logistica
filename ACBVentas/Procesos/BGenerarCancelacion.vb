Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration
Imports ACFramework

Imports DAConexion

Public Class BGenerarCancelacion

#Region " Variables "

   Private m_dtGenerarCancelacion As DataTable

   Private m_dsGenerarCancelacion As DataSet

   Private d_generarcancelacion As DGenerarCancelacion

   Private m_tipocambio As ETipoCambio
   Private m_listVENT_PVentDocumento As List(Of EVENT_PVentDocumento)

   Private m_listEntidades As List(Of EEntidades)
   Private m_listVENT_DocsVenta As List(Of EVENT_DocsVenta)
   Private m_listVENT_Pagos As List(Of EVENT_DocsVenta)

   Private m_pvent_id As Long
   Private m_periodo As String
   Private m_zonas_codigo As String
   Private m_sucur_id As Integer
#End Region

#Region " Constructores "

   ''' <summary>
   ''' constructor principal
   ''' </summary>
   ''' <param name="x_pvent_id">Codigo del punto de venta</param>
   ''' <param name="x_periodo">Codigo del periodo</param>
   ''' <param name="x_zonas_codigo">Codigo de la zona</param>
   ''' <param name="x_sucur_id">Codigo de la sucursal</param>
   ''' <remarks></remarks>
   Public Sub New(ByVal x_pvent_id As Integer, ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer)
      m_pvent_id = x_pvent_id
      m_periodo = x_periodo
      m_zonas_codigo = x_zonas_codigo
      m_sucur_id = x_sucur_id
      d_generarcancelacion = New DGenerarCancelacion()
   End Sub

#End Region

#Region " Propiedades "

   Public Property DTGenerarCancelacion() As DataTable
      Get
         Return m_dtGenerarCancelacion
      End Get
      Set(ByVal value As DataTable)
         m_dtGenerarCancelacion = value
      End Set
   End Property

   Public Property DSGenerarCancelacion() As DataSet
      Get
         Return m_dsGenerarCancelacion
      End Get
      Set(ByVal value As DataSet)
         m_dsGenerarCancelacion = value
      End Set
   End Property

   Public Property ListVENT_PVentDocumento() As List(Of EVENT_PVentDocumento)
      Get
         Return m_listVENT_PVentDocumento
      End Get
      Set(ByVal value As List(Of EVENT_PVentDocumento))
         m_listVENT_PVentDocumento = value
      End Set
   End Property

   Public Property ListEntidades() As List(Of EEntidades)
      Get
         Return m_listEntidades
      End Get
      Set(ByVal value As List(Of EEntidades))
         m_listEntidades = value
      End Set
   End Property

   Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
      Get
         Return m_listVENT_DocsVenta
      End Get
      Set(ByVal value As List(Of EVENT_DocsVenta))
         m_listVENT_DocsVenta = value
      End Set
   End Property

   Public Property ListVENT_Pagos() As List(Of EVENT_DocsVenta)
      Get
         Return m_listVENT_Pagos
      End Get
      Set(ByVal value As List(Of EVENT_DocsVenta))
         m_listVENT_Pagos = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "

   ''' <summary>
   ''' obtener el tipo de cambio
   ''' </summary>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function getTipoCambio() As Boolean
      Try
         Dim b_tipocambio As New BTipoCambio()
         If b_tipocambio.getUltTipoCambio() Then
            m_tipocambio = b_tipocambio.TipoCambio
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el ultimo tipo de cambio ingresado
   ''' </summary>
   ''' <returns>devuelve el valor del tipo de cambio</returns>
   ''' <remarks></remarks>
   Public Function TipoCambio() As Double
      Try
         Dim b_tipocambio As New BTipoCambio()
         If b_tipocambio.getUltTipoCambio() Then
            m_tipocambio = b_tipocambio.TipoCambio
            Return m_tipocambio.TIPOC_CompraOficina
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Geera el numero de transacción para la tabla Tesoreria.TESO_Caja
   ''' </summary>
   ''' <param name="x_serie"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getNroTransaccion(ByVal x_serie As String) As Integer
      Dim x_where As New Hashtable
      Try
         x_where.Add("CAJA_Serie", New ACWhere(x_serie))
         Dim _caja As New BTESO_Caja
         Return _caja.getCorrelativo("CAJA_Numero", x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtiene las series que tiene asignado el punto de venta, las series de documentos de venta
   ''' </summary>
   ''' <param name="x_zonas_codigo">Codigo de la zona</param>
   ''' <param name="x_sucur_id">Codigo de la sucursal</param>
   ''' <param name="x_pvent_id">Codigo del punto de venta</param>
   ''' <param name="x_tipo_documento">Tipo de documento que se requiere los numero de serie</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetSeries(ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer, ByVal x_pvent_id As Long, ByVal x_tipo_documento As String) As Boolean
      Try
         m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)()

         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin(ESucursales.Esquema, ESucursales.Tabla, "Sucur", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                              , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, "PVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")} _
                              , New ACCampos() {New ACCampos("PVENT_Descripcion", "PVENT_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))

         Dim x_where As New Hashtable
         x_where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
         x_where.Add("SUCUR_Id", New ACWhere(x_sucur_id))

         If x_pvent_id > 0 Then x_where.Add("PVENT_Id", New ACWhere(x_pvent_id))
         If x_tipo_documento.Length > 3 Then x_where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo_documento))

         ''Jalar los datos de la capa de Negocio de BVENT_PVentDocumento
         Dim m_bvent_pventdoc As New BVENT_PVentDocumento
         '' CargarTodos: Metodo para Cargar todas las listas de los registros
         If m_bvent_pventdoc.CargarTodos(_join, x_where) Then
            m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)(m_bvent_pventdoc.ListVENT_PVentDocumento)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener los clientes que tienen documentos pendientes de pago
   ''' </summary>
   ''' <param name="x_cadena">Cadena de Busqueda</param>
   ''' <param name="x_campo">Campo sobre el cual se realiza la busqueda de la cadena</param>
   ''' <param name="x_todos"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getPendiente(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         setJoinWhereEntidad(_join, _where, x_todos)
         _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         Dim m_bentidades As New BEntidades
         If m_bentidades.CargarTodos(_join, _where, True) Then
            m_listEntidades = New List(Of EEntidades)(m_bentidades.ListEntidades)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Join para obtener los datos de los clientes con pendientes
   ''' </summary>
   ''' <param name="_join">Objeto que almacena los join</param>
   ''' <param name="_where">Condicion para la busqueda</param>
   ''' <param name="x_todos"></param>
   ''' <remarks></remarks>
   Private Sub setJoinWhereEntidad(ByRef _join As List(Of ACJoin), ByRef _where As Hashtable, ByVal x_todos As Boolean)
      Try
         _join.Add(New ACJoin(EVENT_DocsVenta.Esquema, EVENT_DocsVenta.Tabla, "Vent", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_CodigoCliente", "ENTID_Codigo")} _
                            , New ACCampos() {}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_DocumentoCorto") _
                                              , New ACCampos("TIPOS_Descripcion", "TIPOS_Documento")}))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ''' <summary>
   ''' Cargar todos los documentos de venta de un cliente
   ''' </summary>
   ''' <param name="x_entid_codigo">Codigo del cliente</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarTodos(ByVal x_entid_codigo As String) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin("dbo", "Entidades", "Vend", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoVendedor")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Vendedor")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento") _
                                              , New ACCampos("TIPOS_DescCorta", "TIPOS_TipoDocCorta")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TMon", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TPag", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoPago")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoPago")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TCon", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodCondicionPago")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_CondicionPago")}))
         _join.Add(New ACJoin("dbo", "Entidades", "Us", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("USUAR_Codigo", "DOCVE_UsrCrea")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "Usuario")}))
         Dim _where As New Hashtable()
         _where.Add("ENTID_CodigoCliente", New ACWhere(x_entid_codigo))
         _where.Add("DOCVE_Estado", New ACWhere(EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Anulado), ACWhere.TipoWhere.Diferente))

         Dim _docsVenta As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
         If _docsVenta.CargarTodos(_join, _where) Then
            m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)(_docsVenta.ListVENT_DocsVenta)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Ayuda para los documentos de pago
   ''' </summary>
   ''' <param name="x_where">Condicion para la busqueda de los documentos de pago</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Ayuda(ByVal x_where As Hashtable) As Boolean
      Try
         Dim _docspago As New BTESO_DocsPagos(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
         If _docspago.Ayuda(x_where) Then
            m_dtGenerarCancelacion = New DataTable() : m_dtGenerarCancelacion = _docspago.DTTESO_DocsPagos
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Procedimiento "VENT_DOCSS_TodosConSaldo" por el Generador 31/01/2012
   ''' </summary> 
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function VENT_DOCSS_TodosConSaldo(ByVal x_entid_codigo As String) As Boolean
      m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
      Try
         Return d_generarcancelacion.VENT_DOCSS_TodosConSaldo(m_listVENT_DocsVenta, x_entid_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar un pago en la yabla Tesoreria.TESO_Caja
   ''' </summary>
   ''' <param name="x_usuario">Codigo del usuario</param>
   ''' <param name="x_opcion">Opcion de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarPagos(ByVal x_usuario As String, ByVal x_opcion As Boolean)
      Try
         DAEnterprise.BeginTransaction()
         Dim _i As Integer = 1
         For Each item As EVENT_DocsVenta In m_listVENT_Pagos
            Dim _caja As New BTESO_Caja
            _caja.TESO_Caja = item.TESO_Caja
            _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)
            _caja.TESO_Caja.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
            _caja.TESO_Caja.TIPOS_CodTransaccion = IIf(x_opcion, ETipos.getTipo(ETipos.TipoDePago.Efectivo), ETipos.getTipo(item.TipoDePago))
            _caja.TESO_Caja.CAJA_OrdenDocumento = _i
            _caja.TESO_Caja.CAJA_Pase = Constantes.GetPase(Constantes.Pase.Entrada)
            _caja.TESO_Caja.CAJA_NroDocumento = item.DOCVE_Codigo
            _caja.TESO_Caja.TIPOS_CodTipoDocumento = item.TIPOS_CodTipoDocumento
            _caja.TESO_Caja.CAJA_TCDocumento = item.DOCVE_TipoCambio
            _caja.TESO_Caja.CAJA_Glosa = IIf(x_opcion, Constantes.getGlosaTipoDePago(ETipos.TipoDePago.Efectivo), Constantes.getGlosaTipoDePago(item.TipoDePago))
            _caja.TESO_Caja.CAJA_Importe = item.ImportePagar
            _caja.TESO_Caja.CAJA_ImporteVenta = item.DOCVE_TotalPagar
            _caja.TESO_Caja.ENTID_Codigo = item.ENTID_CodigoCliente
            _caja.TESO_Caja.CAJA_Estado = ETESO_Caja.getEstado(ETESO_Caja.Estado.Ingresado)
            _i += 1
            _caja.Guardar(x_usuario)
         Next
         If x_opcion Then

         Else

         End If

         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function
#End Region

End Class

