Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration
Imports System.Configuration

Imports ACEVentas
Imports ACFramework

Public Class BABAS_CotizacionesCompra

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "

   ''' <summary>
   ''' Obtener el correlativo para generar el codigo
   ''' </summary>
   ''' <param name="x_abas_numero">Numero que se devuelve</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCorrelativo(ByVal x_tipo As String, ByRef x_abas_numero As Integer, ByVal x_almac_id As Long) As String
      Try
         x_abas_numero = d_abas_cotizacionescompra.getCodCorrelativo(x_tipo) + 1
         Dim x_codigo As String
         If (x_tipo = "CT") Then
            x_codigo = EABAS_CotizacionesCompra.TipoPedido.CT.ToString() & x_almac_id.ToString().PadLeft(3, "0") & x_abas_numero.ToString().PadLeft(7, "0")
         Else
            x_codigo = EABAS_CotizacionesCompra.TipoPedido.RQ.ToString() & x_almac_id.ToString().PadLeft(3, "0") & x_abas_numero.ToString().PadLeft(7, "0")
         End If

         Return x_codigo
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_COTCOSS_TodosCotizaciones
   ''' </summary>
   ''' <param name="x_zonas_codigo">Parametro 1: </param> 
   ''' <param name="x_sucur_id">Parametro 2: </param> 
   ''' <param name="x_cadena">Parametro 3: </param> 
   ''' <param name="x_opcion">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <param name="x_fecini">Parametro 6: </param> 
   ''' <param name="x_fecfin">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function Busqueda(ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      m_listABAS_CotizacionesCompra = New List(Of EABAS_CotizacionesCompra)
      Try
         Return d_abas_cotizacionescompra.LOG_COTCOSS_TodosCotizaciones(m_listABAS_CotizacionesCompra, x_zonas_codigo, x_sucur_id, x_cadena, x_opcion, x_todos, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' ''' <summary>
   ' ''' Realiza la busqueda de cotizaciones de compra con las condiciones descritas en las siguientes lineas
   ' ''' </summary>
   ' ''' <param name="x_cadena">Cadena que se va ha buscar</param>
   ' ''' <param name="x_campo">Campo por el cual se realizara la busqueda</param>
   ' ''' <param name="x_todos">Opcion para cargar todos los registros ignorando el estado del documento</param>
   ' ''' <param name="x_fecini">Fecha inicial de busqueda</param>
   ' ''' <param name="x_fecfin">Fecha final de busqueda</param>
   ' ''' <returns></returns>
   ' ''' <remarks></remarks>
   'Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
   '                         , ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short) As Boolean
   '   Try
   '      Dim _join As New List(Of ACJoin)
   '      _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
   '                         , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")} _
   '                         , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Proveedor")}))
   '      _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, "Alma", ACJoin.TipoJoin.Inner _
   '                         , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
   '                         , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Descripcion")}))
   '      Dim _where As New Hashtable()
   '      If x_campo.Contains("ENTID") Then
   '         _where.Add(x_campo, New ACWhere(x_cadena, "Ent", "System.String", ACWhere.TipoWhere._Like))
   '      Else
   '         _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
   '      End If
   '      _where.Add("COTCO_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
   '      _where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
   '      _where.Add("SUCUR_Id", New ACWhere(x_sucur_id))
   '      If Not x_todos Then
   '         _where.Add("COTCO_Estado", New ACWhere(EABAS_CotizacionesCompra.getEstado(EABAS_CotizacionesCompra.Estado.Ingresado), ACWhere.TipoWhere.Igual))
   '      End If
   '      m_listABAS_CotizacionesCompra = New List(Of EABAS_CotizacionesCompra)
   '      Return d_abas_cotizacionescompra.ABAS_COTCOSS_Todos(m_listABAS_CotizacionesCompra, _join, _where)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   ''' <summary>
   ''' Realiza la carga del documento con su respectivo detalle
   ''' </summary>
   ''' <param name="x_cotco_codigo">Codigo de cotización</param>
   ''' <param name="x_detalle">Opción para cargar el detalle</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Cargar(ByVal x_cotco_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Proveedor") _
                                            , New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor") _
                                            , New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento") _
                                            , New ACCampos("ENTID_Direccion", "ENTID_Direccion") _
                                            , New ACCampos("ENTID_Telefono1", "ENTID_Telefono") _
                                            , New ACCampos("ENTID_EMail", "ENTID_Correo")}))
         Dim _where As New Hashtable()
         _where.Add("COTCO_Codigo", New ACWhere(x_cotco_codigo, ACWhere.TipoWhere.Igual))
         If Cargar(_join, _where) Then
            If x_detalle Then
               Dim m_babas_cotizacionescompradetalle As New BABAS_CotizacionesCompraDetalle
               Dim _joinDet As New List(Of ACJoin)
               _joinDet.Add(New ACJoin(EArticulos.Esquema, EArticulos.Tabla, "Art", ACJoin.TipoJoin.Inner _
                                  , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                                  , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion") _
                                                    , New ACCampos("ARTIC_Id", "ARTIC_Id")}))
               Dim _whereDet As New Hashtable()
               _whereDet.Add("COTCO_Codigo", New ACWhere(x_cotco_codigo, ACWhere.TipoWhere.Igual))
               m_babas_cotizacionescompradetalle.CargarTodos(_joinDet, _whereDet)
               m_eabas_cotizacionescompra.ListABAS_CotizacionesCompraDetalle = New List(Of EABAS_CotizacionesCompraDetalle)(m_babas_cotizacionescompradetalle.ListABAS_CotizacionesCompraDetalle)
            End If
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

