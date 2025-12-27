Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTelefonos


#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function TELESS_Todos(ByRef listETelefonos As List(Of ETelefonos), ByVal x_entid_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_entid_codigo), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETelefonos())
               While reader.Read()
                  Dim e_telefonos As New ETelefonos()
                  _utilitarios.ACCargarEsquemas(reader, e_telefonos)
                  e_telefonos.Instanciar(ACEInstancia.Consulta)
                  listETelefonos.Add(e_telefonos)
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
   Public Function getSelectAll(ByVal x_entid_codigo As String) As String
      Dim sql As String = ""
      Try
         sql = " SELECT "
         sql &= " ENTID_Codigo"
         sql &= ",TELEF_ID"
         sql &= ",TELEF_TELEFONO"
         sql &= " FROM dbo.Telefonos"
         sql &= " WHERE "
         sql &= "ENTID_Codigo = '" + x_entid_codigo & "'"
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

