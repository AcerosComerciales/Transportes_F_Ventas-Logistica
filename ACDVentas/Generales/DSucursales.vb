Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DSucursales


#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function SUCUSS_Todos(ByRef listESucursales As List(Of ESucursales), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ESucursales())
               While reader.Read()
                  Dim e_sucursales As New ESucursales()
                  _utilitarios.ACCargarEsquemas(reader, e_sucursales)
                  e_sucursales.Instanciar(ACEInstancia.Consulta)
                  listESucursales.Add(e_sucursales)
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
         sql &= " SUCUR_Id"
         sql &= ",SUCUR_Nombre"
         sql &= ",SUCUR_Direccion"
         sql &= ",SUCUR_Telefono"
         sql &= ",EMPRE_CODIGO"
         sql &= " FROM dbo.Sucursales"
         sql &= " WHERE "
         sql &= String.Format("SUCUR_Nombre Like '%{0}%'", x_cadena)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

