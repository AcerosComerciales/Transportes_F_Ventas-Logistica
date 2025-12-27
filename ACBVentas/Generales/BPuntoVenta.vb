Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration
Imports ACFramework

Public Class BPuntoVenta


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
   ''' busqueda de puntos de venta
   ''' </summary>
   ''' <param name="x_cadena">cadeba de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String) As Boolean
      Try
         Dim _Join As New List(Of ACJoin)()
         _Join.Add(New ACJoin(ESucursales.Esquema, ESucursales.Tabla, ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                              , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         _Join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                              , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Nombre")}))
         Dim _where As New Hashtable()
         _where.Add("PVENT_Descripcion", New ACWhere(x_cadena, ACWhere.TipoWhere._Like))

         m_listPuntoVenta = New List(Of EPuntoVenta)()
         Return d_puntoventa.PVENTSS_Todos(m_listPuntoVenta, _Join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

