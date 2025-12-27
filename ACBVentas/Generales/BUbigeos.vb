Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Public Class BUbigeos


#Region " Variables "
   Shared m_dtUbigeo As DataTable
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "

   Public Property UbigeosDT() As DataTable
      Get
         Return m_dtUbigeo
      End Get
      Set(ByVal value As DataTable)
         m_dtUbigeo = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
   Public Function CargarTodosDT() As DataTable
      Dim d_ubigeos As New DUbigeos()
      Try
         m_listUbigeos = New List(Of EUbigeos)()
         Return d_ubigeos.UBIGSS_TodosDT()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodosLTD() As Boolean
      Dim d_ubigeos As New DUbigeos()
      Try
         m_listUbigeos = New List(Of EUbigeos)()
         m_dtUbigeo = New DataTable()
         Return d_ubigeos.UBIGSS_Todos(m_listUbigeos, m_dtUbigeo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Busqueda(ByVal x_cadenas As String) As Boolean
      Dim d_ubigeos As New DUbigeos()
      Try
         m_listUbigeos = New List(Of EUbigeos)()
         Return d_ubigeos.UBIGSS_Todos(m_listUbigeos, x_cadenas)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Metodos "
	
#End Region

End Class

