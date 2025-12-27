Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_VehiculosNeumaticos

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "
    Public Function VNEUSU_UnRegEstado(ByVal x_tran_vehiculosneumaticos As ETRAN_VehiculosNeumaticos, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdateEstado(x_tran_vehiculosneumaticos, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'creado FRANK 
    Public Function Neumatico_Listado(ByVal m_list_Neumaticos As List(Of ETRAN_Neumaticos))

        Try
            DAEnterprise.AsignarProcedure("TRAN_NEUMA_Listado")
            '  DAEnterprise.AgregarParametro("@VEHIC_Id", x_vehic_id, DbType.Int64, 8)
            ' DAEnterprise.AgregarParametro("@VIAJE_IdxVehiculo", x_viaje_idxvehiculo, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim Neumaticos As New ETRAN_Neumaticos()
                        ACEsquemas.ACCargarEsquema(reader, Neumaticos)
                        Neumaticos.Instanciar(ACEInstancia.Consulta)
                        m_list_Neumaticos.Add(Neumaticos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function




#Region "Procedimientos Adicionales "
    Public Function getUpdateEstado(ByVal x_tran_vehiculosneumaticos As ETRAN_VehiculosNeumaticos, ByVal x_usuario As String) As String
      Dim sql As String = ""
      Try
         sql &= "UPDATE Transportes.TRAN_VehiculosNeumaticos"
         sql &= " SET "
         sql &= "  VNEUM_FECRETIRO = " & getDate()
         sql &= ", VNEUM_Estado = " & IIf(IsNothing(x_tran_vehiculosneumaticos.VNEUM_Estado), "Null", "'" & x_tran_vehiculosneumaticos.VNEUM_Estado & "'")
         sql &= ", VNEUM_UsrMod = '" + x_usuario & "'"
         sql &= ", VNEUM_FecMod = " & getDate()
         sql &= " WHERE "
         sql &= " VEHIC_Id = " & IIf(x_tran_vehiculosneumaticos.VEHIC_Id = 0, "Null", x_tran_vehiculosneumaticos.VEHIC_Id.ToString())
         sql &= " And VNEUM_Lado = " & IIf(IsNothing(x_tran_vehiculosneumaticos.VNEUM_Lado), "Null", "'" & x_tran_vehiculosneumaticos.VNEUM_Lado & "'")
         sql &= " And VNEUM_Seccion = " & IIf(IsNothing(x_tran_vehiculosneumaticos.VNEUM_Seccion), "Null", "'" & x_tran_vehiculosneumaticos.VNEUM_Seccion & "'")
         sql &= " And VNEUM_OrdenPosicion = " & IIf(x_tran_vehiculosneumaticos.VNEUM_OrdenPosicion = 0, "Null", x_tran_vehiculosneumaticos.VNEUM_OrdenPosicion.ToString())
         sql &= " And VNEUM_InternoExterno = " & IIf(IsNothing(x_tran_vehiculosneumaticos.VNEUM_InternoExterno), "Null", "'" & x_tran_vehiculosneumaticos.VNEUM_InternoExterno & "'")

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region
#End Region

End Class

