Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_ViajesVentas

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function AnularVentas(ByVal x_docve_codigo As String, ByVal x_estado As String) As Boolean
      Dim _sql As String = ""
      Try
         _sql &= String.Format("Update Transportes.TRAN_ViajesVentas Set VIAVE_Estado = '{1}'{0}", vbNewLine, x_estado)
         _sql &= String.Format("Where DOCVE_Codigo = '{1}'{0}", vbNewLine, x_docve_codigo)

         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
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

