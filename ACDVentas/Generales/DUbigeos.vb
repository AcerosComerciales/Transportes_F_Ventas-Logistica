Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DUbigeos


#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function UBIGSS_TodosDT() As DataTable
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
         Return DAEnterprise.ExecuteDataSet().Tables(0)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function UBIGSS_Todos(ByRef listEUbigeos As List(Of EUbigeos), ByRef m_dtUbigeo As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
         m_dtUbigeo = DAEnterprise.ExecuteDataSet().Tables(0)

         For Each Item As DataRow In m_dtUbigeo.Rows
            Dim _utilitarios As New ACEsquemas(New EUbigeos())
            Dim e_ubigeos As New EUbigeos()
            _utilitarios.ACCargarEsquemas(Item, e_ubigeos)
            e_ubigeos.Instanciar(ACEInstancia.Consulta)
            listEUbigeos.Add(e_ubigeos)
         Next
         m_dtUbigeo.Columns("UBIGO_Codigo").ColumnName = "CODIGO"
         m_dtUbigeo.Columns("UBIGO_Descripcion").ColumnName = "DESCRIPCION"
         m_dtUbigeo.Columns("UBIGO_CODPADRE").ColumnName = "CODPADRE"
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function UBIGSS_Todos(ByRef listEUbigeos As List(Of EUbigeos), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EUbigeos())
               While reader.Read()
                  Dim e_ubigeos As New EUbigeos()
                  _utilitarios.ACCargarEsquemas(reader, e_ubigeos)
                  e_ubigeos.Instanciar(ACEInstancia.Consulta)
                  listEUbigeos.Add(e_ubigeos)
               End While
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#Region "Procedimientos Adicionales "
   Public Function getSelectAll(ByVal x_cadena As String) As String
      Dim sql As String
      Try
         sql = " SELECT "
         sql &= " UPadre.UBIGO_Descripcion As UPADRE_DESCRIPCION, Ubi.*"
         sql &= " FROM dbo.Ubigeos As Ubi"
         sql &= " Left Join Ubigeos As UPadre On UPadre.UBIGO_Codigo = Ubi.UBIGO_CodPadre "
         sql &= " WHERE "
         sql &= "Ubi.UBIGO_Descripcion Like '%" & x_cadena & "%'"

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

