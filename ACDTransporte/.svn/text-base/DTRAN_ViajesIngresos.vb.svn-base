Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_ViajesIngresos

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function GetIngresosViaje(ByRef listETRAN_ViajesIngresos As List(Of ETRAN_ViajesIngresos), ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectIngresosViajes(x_where), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_ViajesIngresos())
               While reader.Read()
                  Dim e_tran_viajesingresos As New ETRAN_ViajesIngresos()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_viajesingresos)
                  e_tran_viajesingresos.Instanciar(ACEInstancia.Consulta)
                  listETRAN_ViajesIngresos.Add(e_tran_viajesingresos)
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
   Private Function getSelectIngresosViajes(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql = App.Hash("DTRAN_ViajesIngresos.GetIngresosViaje").ToString()
         Dim _where As New ACGenerador(Of ETRAN_ViajesIngresos)(m_formatofecha)
         sql = String.Format(sql, _where.getWhere(x_where, True))

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

