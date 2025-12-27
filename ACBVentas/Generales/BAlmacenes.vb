Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports ACFramework

Imports System.Configuration

Public Class BAlmacenes


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
   ''' busqueda de almacenes
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String) As Boolean
      Try
         m_listAlmacenes = New List(Of EAlmacenes)()
         Return d_almacenes.ALMASS_Todos(m_listAlmacenes, x_cadena)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' ayuda para buscar almacenes
   ''' </summary>
   ''' <param name="x_where">clase condicion</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Ayuda(ByVal x_where As Hashtable) As Boolean
      Try
         m_dtAlmacenes = New DataTable
         Return d_almacenes.ALMASS_TodosAyuda(m_dtAlmacenes, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Ayuda para buscar almacenes
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Ayuda() As Boolean
      Try
         Dim x_where As New Hashtable
         x_where.Add("ALMAC_Descripcion", New ACWhere("", ACWhere.TipoWhere._Like))
         m_dtAlmacenes = New DataTable
         Return d_almacenes.ALMASS_TodosAyuda(m_dtAlmacenes, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener la lista de almacenes por punto de venta
   ''' </summary>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getListAlmacenXPtoVta(ByVal x_pvent_id As Long) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EVerStockPtoVenta.Esquema, EVerStockPtoVenta.Tabla, "UVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                              , New ACCampos() {New ACCampos("ALMAC_Id", "Interno")}))
         Dim _where As New Hashtable()
         _where.Add("PVENT_Id", New ACWhere(x_pvent_id, "UVta", "System.Int32", ACWhere.TipoWhere.Igual))
         m_listAlmacenes = New List(Of EAlmacenes)
         Return d_almacenes.ALMACSS_Todos(m_listAlmacenes, _join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

