Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Public Class BLineas


#Region " Variables "
   Shared m_dtLinea As DataTable
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "

   Public Property LineasDT() As DataTable
      Get
         Return m_dtLinea
      End Get
      Set(ByVal value As DataTable)
         m_dtLinea = value
      End Set
   End Property
#End Region

#Region " Funciones para obtencion de datos "
   Public Function CargarTodosDT() As DataTable
      Dim d_lineas As New DLineas()
      Try
         m_listLineas = New List(Of ELineas)()
         Return d_lineas.LINEASS_TodosDT
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodosLTD() As Boolean
      Dim d_lineas As New DLineas()
      Try
         m_listLineas = New List(Of ELineas)()
         m_dtLineas = New DataTable()
         Return d_lineas.LINEASS_Todos(m_listLineas, m_dtLineas)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Busqueda(ByVal x_cadenas As String) As Boolean
      Dim d_lineas As New DLineas()
      Try
         m_listLineas = New List(Of ELineas)()
         Return d_lineas.LINEASS_Todos(m_listLineas, x_cadenas)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos "
	
#End Region

End Class

