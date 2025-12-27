Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Imports ACFramework

Public Class BSucursales


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
   ''' busqueda de sucursales
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String) As Boolean
      Try
         m_listSucursales = New List(Of ESucursales)()
         Dim _where As New Hashtable() : _where.Add("SUCUR_Nombre", New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         Return CargarTodos(_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

