Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Public Class BTRAN_ViajesVentas

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   Public Function AnularVentas(ByVal x_docve_codigo As String, ByVal x_estado As String) As Boolean
      Try
         Return d_tran_viajesventas.AnularVentas(x_docve_codigo, x_estado)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

