Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DEntidadesRoles


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	


#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
   Public Function ENTISS_Todos(ByVal x_listentidadestipos As List(Of EEntidadesRoles), ByVal x_entid_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectBy(x_entid_codigo), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EEntidadesRoles())
               While reader.Read()
                  Dim e_entidadestipos As New EEntidadesRoles()
                  _utilitarios.ACCargarEsquemas(reader, e_entidadestipos)
                  e_entidadestipos.Instanciar(ACEInstancia.Consulta)
                  x_listentidadestipos.Add(e_entidadestipos)
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
   Public Function getSelectBy(ByVal x_entid_codigo As String) As String
      Dim sql As String
      Try
         sql = " SELECT * FROM EntidadesRoles"
         sql &= " Where ENTID_Codigo = '" & x_entid_codigo.ToString() & "'"
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region


End Class

