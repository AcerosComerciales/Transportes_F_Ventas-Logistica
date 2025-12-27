Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration

Public Class BColor


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   Public Function Busqueda(ByVal x_cadena As String) As Boolean
      Try
         m_listColor = New List(Of EColor)()
         Return d_color.COLORSS_Todos(m_listColor, x_cadena)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

