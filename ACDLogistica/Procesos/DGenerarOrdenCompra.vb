Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Public Class DGenerarOrdenCompra

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function ABAS_ORDCDSS_UnRegImpresion(ByRef x_datos As DataSet, ByVal x_ordco_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ABAS_ORDCDSS_UnRegImpresion")
         DAEnterprise.AgregarParametro("@ORDCO_Codigo", x_ordco_codigo, DbType.String, 12)
         x_datos = DAEnterprise.ExecuteDataSet()
         Return x_datos.Tables(0).Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos "
	
#End Region


End Class

