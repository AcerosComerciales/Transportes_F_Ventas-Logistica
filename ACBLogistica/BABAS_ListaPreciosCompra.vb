Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration
Imports System.Configuration

Imports ACFramework

Public Class BABAS_ListaPreciosCompra

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   Public Function GetPreciosArticulo(ByVal x_entid_codigo As String, ByVal x_artic_codigo As String) As Boolean
      Try
         Dim _where As New Hashtable()
         _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
         _where.Add("ARTIC_Codigo", New ACWhere(x_artic_codigo))
         Return CargarTodos(_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

