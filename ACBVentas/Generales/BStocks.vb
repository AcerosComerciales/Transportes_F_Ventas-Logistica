Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Imports ACFramework


Public Class BStocks


#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function CargarSStock(ByVal x_artic_codigo As String) As Boolean
      Try
         m_listStocks = New List(Of EStocks)()
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                              , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Descripcion")}))
         Dim _where As New Hashtable()
         _where.Add("ARTIC_Codigo", New ACWhere(x_artic_codigo))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

