Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion


Partial Public Class DCONT_DocsPercepcion

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function CONT_DOCPESS_Todos(ByRef m_datos As DataSet, ByVal x_docpe_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("CONT_DOCPESS_UnRegReporte")
         DAEnterprise.AgregarParametro("@DOCPE_Codigo", x_docpe_codigo)
         m_datos = DAEnterprise.ExecuteDataSet()
         Return m_datos.Tables.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function



#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
   
#End Region

End Class

