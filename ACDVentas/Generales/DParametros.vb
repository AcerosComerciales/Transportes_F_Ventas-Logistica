Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DParametros


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function PARMTSS_TodosGlobal(ByRef listEParametros As List(Of EParametros)) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectGlobal(), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EParametros())
               While reader.Read()
                  Dim e_parametros As New EParametros()
                  _utilitarios.ACCargarEsquemas(reader, e_parametros)
                  e_parametros.Instanciar(ACEInstancia.Consulta)
                  listEParametros.Add(e_parametros)
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
   Private Function getSelectGlobal() As String
      Dim sql As String = ""
      Try
         sql = " SELECT  * " & vbNewLine
         sql &= " FROM dbo.Parametros" & vbNewLine
         sql &= " WHERE ZONAS_Codigo Is Null AND SUCUR_Id = 0 AND APLIC_Codigo = ''" & vbNewLine
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

#Region " Metodos "
	
#End Region


End Class

