Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTRAN_Vehiculos

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "
   Public Function VEHISS_Todos(ByRef listETRAN_Vehiculos As List(Of ETRAN_Vehiculos), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_Vehiculos())
               While reader.Read()
                  Dim e_tran_vehiculos As New ETRAN_Vehiculos()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_vehiculos)
                  e_tran_vehiculos.Instanciar(ACEInstancia.Consulta)
                  listETRAN_Vehiculos.Add(e_tran_vehiculos)
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

   Public Function TRAN_VEHICSS_Ayuda(ByRef dtETRAN_Vehiculos As DataTable, ByVal x_cadena As String, ByVal x_opcion As Short) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_VEHICSS_Ayuda")
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         dtETRAN_Vehiculos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return (dtETRAN_Vehiculos.Rows.Count > 0)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function VEHISS_TodosAyuda(ByRef dtETRAN_Vehiculos As DataTable, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_where), CommandType.Text)
         dtETRAN_Vehiculos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtETRAN_Vehiculos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "
   Public Function getSelectAll(ByVal x_cadena As String) As String
      Dim sql As String
      Try
         sql = " SELECT "
         sql &= " Vehi.*"
         sql &= " , TMar.TIPOS_Descripcion As TIPOS_Marca"
         sql &= " , TVehi.TIPOS_Descripcion As TIPOS_Vehiculo"
         sql &= " , Suc.SUCUR_Nombre "
         sql &= " FROM Transportes.TRAN_Vehiculos As Vehi"
         sql &= " Inner Join Tipos As TMar On TMar.TIPOS_Codigo = Vehi.TIPOS_CodMarca"
         sql &= " Inner Join Tipos As TVehi On TVehi.TIPOS_Codigo = Vehi.TIPOS_CodTipoVehiculo"
         sql &= " Inner Join Sucursales As Suc On Suc.SUCUR_Id = Vehi.SUCUR_Id"
         sql &= " WHERE "
         sql &= " VEHIC_Placa Like '%" + x_cadena & "%'"
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAyuda(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= App.Hash("DTRAN_Vehiculos.VEHISS_TodosAyuda") & vbNewLine
         Dim _where As New ACGenerador(Of ETRAN_Vehiculos)(m_formatofecha)
         sql &= _where.getWhere(x_where, "Vehi", True)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

