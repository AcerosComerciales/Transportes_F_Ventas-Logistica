Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DColor


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function COLORSS_Todos(ByRef listETRAN_Colores As List(Of EColor), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EColor())
               While reader.Read()
                  Dim e_tran_colores As New EColor()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_colores)
                  e_tran_colores.Instanciar(ACEInstancia.Consulta)
                  listETRAN_Colores.Add(e_tran_colores)
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
         sql = " SELECT *"
         sql &= " FROM Color C"
         sql &= " WHERE "
         sql &= "C.COLOR_Descripcion like '%" & x_cadena & "%'"

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

