Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_VehiculosRanflas

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function RAMFSS_Todos(ByRef listETRAN_VehiculosRanflas As List(Of ETRAN_VehiculosRanflas), ByVal x_vehic_id As Long, ByVal x_opcion As Boolean, ByVal x_estado As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_vehic_id, x_opcion, x_estado), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosRanflas())
               While reader.Read()
                  Dim e_tran_vehiculosranflas As New ETRAN_VehiculosRanflas()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_vehiculosranflas)
                  e_tran_vehiculosranflas.Instanciar(ACEInstancia.Consulta)
                  listETRAN_VehiculosRanflas.Add(e_tran_vehiculosranflas)
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

   Public Function RAMFSS_Todos(ByRef listETRAN_VehiculosRanflas As List(Of ETRAN_VehiculosRanflas), ByVal x_opcion As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_opcion), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosRanflas())
               While reader.Read()
                  Dim e_tran_ranflas As New ETRAN_VehiculosRanflas()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_ranflas)
                  e_tran_ranflas.Instanciar(ACEInstancia.Consulta)
                  listETRAN_VehiculosRanflas.Add(e_tran_ranflas)
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
   Public Function getSelectAll(ByVal x_ranfl_id As Long, ByVal x_opcion As Boolean, ByVal x_estado As Boolean) As String
      Dim sql As String
      Try
         sql = "Select Ran.RANFL_Codigo, Ran.RANFL_Placa, Ran.RANFL_FecAdquisicion, VRan.* From transportes.Tran_Ranflas As Ran Inner Join transportes.Tran_vehiculosRanflas As VRan On {0} Ran.RANFL_Id = VRan.RANFL_Id And VRan.VEHRN_Estado {1} In ('A') Inner Join Tipos As TMar On TMar.TIPOS_Codigo = Ran.TIPOS_CodMarca Where VRan.VEHIC_Id = {2}"
         'sql = " Select Ran.RANFL_Codigo, Ran.RANFL_Placa, Ran.RANFL_FecAdquisicion, VRan.* "
         'sql &= " From transportes.Tran_Ranflas As Ran "
         'sql &= " Inner Join transportes.Tran_vehiculosRanflas As VRan "
         'sql &= " On " & IIf(x_opcion, "", " Not ") & " Ran.RAMFL_ID = VRan.RAMFL_ID "
         'sql &= " And VRan.VEHRN_Estado " & IIf(x_estado, "", " Not ") & " In ('A') "
         'sql &= " Inner Join Tipos As TMar On TMar.TIPOS_Codigo = Ran.TIPOS_CodMarca"
         'sql &= " Where VRan.VEHIC_Id = " & x_ranfl_id.ToString()
         Return String.Format(sql, New Object() {IIf(x_opcion, "", " Not "), IIf(x_estado, "", " Not "), x_ranfl_id.ToString()})
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAll(ByVal x_opcion As Boolean) As String
      Dim sql As String
      Try
         sql = " Select * from transportes.Tran_Ranflas As Ran " & vbNewLine
         sql &= " Where {0}" & vbNewLine
         sql &= " Ran.RANFL_Id In (Select VRan.RANFL_Id " & vbNewLine
         sql &= " from transportes.Tran_vehiculosRanflas As VRan Where VEHRN_Estado In ('A')) {1}" & vbNewLine
         Return String.Format(sql, New Object() {IIf(x_opcion, "", " Not "), ";"})
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

