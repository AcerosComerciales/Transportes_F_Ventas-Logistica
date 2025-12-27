Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration

Imports ACFramework

Public Class BArticDestinos


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
   ''' cargar articulos destinos
   ''' </summary>
   ''' <param name="x_artic_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarArtDestin(ByVal x_artic_codigo As String) As Boolean
      Try
         m_listArticDestinos = New List(Of EArticDestinos)()
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EArticulos.Esquema, EArticulos.Tabla, ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                              , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion")}))
         Dim _where As New Hashtable
         _where.Add("ARTIC_Codigo", New ACWhere(x_artic_codigo))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

