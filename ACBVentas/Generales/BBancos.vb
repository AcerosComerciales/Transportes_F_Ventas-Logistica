Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Public Class BBancos


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
   Public Property BancosDT() As DataTable
      Get
         Return m_dtBancos
      End Get
      Set(ByVal value As DataTable)
         m_dtBancos = value
      End Set
   End Property
#End Region

#Region " Funciones para obtencion de datos "
   Public Function CargarTodosDT() As DataTable
      Dim d_bancos As New DBancos()
      Try
         m_listBancos = New List(Of EBancos)()
         Return d_bancos.BANCOSS_TodosDT
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodosLTD() As Boolean
      Dim d_bancos As New DBancos()
      Try
         m_listBancos = New List(Of EBancos)()
         m_dtBancos = New DataTable()
         Return d_bancos.BANCOSS_Todos(m_listBancos, m_dtBancos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Metodos "
   ''' <summary>
   ''' busqueda de bancos
   ''' </summary>
   ''' <param name="x_cadena"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String) As Boolean
      Try
         m_listBancos = New List(Of EBancos)()
         Return d_bancos.BANCOSS_Todos(m_listBancos, x_cadena)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

