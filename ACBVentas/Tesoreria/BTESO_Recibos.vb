Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports ACFramework
Imports DAConexion

Partial Public Class BTESO_Recibos

#Region " Variables "
   Private m_listVENT_PVentDocumento As List(Of EVENT_PVentDocumento)
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "

   Public Property ListVENT_PVentDocumento() As List(Of EVENT_PVentDocumento)
      Get
         Return m_listVENT_PVentDocumento
      End Get
      Set(ByVal value As List(Of EVENT_PVentDocumento))
         m_listVENT_PVentDocumento = value
      End Set
   End Property
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Negocio: TESO_ConsultaRecibos
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_cadena">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ConsultaRecibos(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_cadena As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean) As Boolean
      m_listTESO_Recibos = New List(Of ETESO_Recibos)
      Try
         Return d_teso_recibos.TESO_ConsultaRecibos(m_listTESO_Recibos, x_fecini, x_fecfin, x_cadena, x_pvent_id, x_todos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener las series de los documentos
   ''' </summary>
   ''' <param name="x_app">codigo de aplicacion</param>
   ''' <param name="x_zonas_codigo">codigo de la zona</param>
   ''' <param name="x_sucur_id">codigo de la sucursal</param>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <param name="x_tipo_documento">tipo de documento</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetSeries(ByVal x_app As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer, ByVal x_pvent_id As Integer, ByVal x_tipo_documento As String) As Boolean
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
         x_where.Add("PVDOCU_App", New ACWhere(x_app))

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
    ''' Capa de Negocio: TESO_ObtenerRecibo
    ''' </summary>
    ''' <param name="x_recib_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function TESO_ObtenerRecibo(ByRef m_tran_recibos As ETESO_Recibos, ByVal x_recib_codigo As String) As Boolean
        m_tran_recibos = New ETESO_Recibos
        Try
            Return d_teso_recibos.TESO_ObtenerRecibo(m_tran_recibos, x_recib_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   
   ''' <summary>
   ''' Guardar el recibo
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_detalle"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Guardar(ByVal x_usuario As String, ByVal x_detalle As Boolean) As Boolean
      Try
         If x_detalle Then
            DAEnterprise.BeginTransaction()

            Dim _documento As New BTESO_Documentos
            _documento.TESO_Documentos = New ETESO_Documentos
            _documento.TESO_Documentos = m_eteso_recibos.TESO_Documentos
            _documento.TESO_Documentos.DOCUS_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
            _documento.TESO_Documentos.DOCUS_Importe = m_eteso_recibos.RECIB_Importe
            _documento.TESO_Documentos.DOCUS_TotalPago = m_eteso_recibos.RECIB_Importe
            _documento.TESO_Documentos.TIPOS_CodTipoMoneda = m_eteso_recibos.TIPOS_CodTipoMoneda
            _documento.TESO_Documentos.Instanciar(ACEInstancia.Nuevo)
            _documento.TESO_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", _documento.TESO_Documentos.TIPOS_CodTipoDocumento.Substring(3, 2), _documento.TESO_Documentos.DOCUS_Serie.PadLeft(3, "0"), _documento.TESO_Documentos.DOCUS_Numero.PadLeft(7, "0"))
            If _documento.Guardar(x_usuario) Then
               m_eteso_recibos.ENTID_CodigoProveedor = _documento.TESO_Documentos.ENTID_Codigo
               m_eteso_recibos.DOCUS_Codigo = _documento.TESO_Documentos.DOCUS_Codigo
               m_eteso_recibos.TIPOS_CodTransaccion = ETipos.getTipo(ETipos.TransaccionTRecibos.Normal)
               If Guardar(x_usuario) Then
                  DAEnterprise.CommitTransaction()
                  Return True
               Else
                  Throw New Exception("No puede completar la operación grabar registro Documento")
               End If
            Else
               Throw New Exception("No puede completar la operación grabar registro Recibo")
            End If
         Else
         Return Guardar(x_usuario)
         End If
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

#End Region

End Class

