Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Public Class BParametros


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
   Public Function CargarTodosGlobal() As Boolean
      Dim d_parametros As New DParametros()
      Try
         m_listParametros = New List(Of EParametros)()
         Return d_parametros.PARMTSS_TodosGlobal(m_listParametros)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Metodos "
	
#End Region

End Class

