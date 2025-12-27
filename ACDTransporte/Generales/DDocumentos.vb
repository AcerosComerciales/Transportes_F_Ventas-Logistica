Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DDocumentos

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	


#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
   Public Function DOCMSI_UnRegId(ByRef x_documentos As EDocumentos, ByVal x_usuario As String) As Integer
      Dim m_filas As Integer
      Try
         Dim _id As String = " SELECT @@IDENTITY AS 'Identity';"
         DAEnterprise.AsignarProcedure(getInsert(x_documentos, x_usuario) & _id, CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         x_documentos.DOCMT_Id = CType(m_datos.Rows(0)(0), Long)

         m_filas = DAEnterprise.ExecuteNonQuery()
         Return m_filas
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region


End Class

