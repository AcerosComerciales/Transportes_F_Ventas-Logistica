Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DPrecios


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	

#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
   Public Function PRECISI_UnRegSQL(ByRef x_precios As EPrecios, ByVal x_usuario As String) As String
      Try
         Return getInsert(x_precios, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function PRECISU_UnRegSQL(ByVal x_precios As EPrecios, ByVal x_usuario As String) As String
      Try
         Return getUpdate(x_precios, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region


End Class

