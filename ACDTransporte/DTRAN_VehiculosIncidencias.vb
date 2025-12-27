Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_VehiculosIncidencias

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function GetIncidencias(ByRef listETRAN_VehiculosIncidencias As List(Of ETRAN_VehiculosIncidencias), ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectIncidencias(x_where), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosIncidencias())
               While reader.Read()
                  Dim e_tran_vehiculosincidencias As New ETRAN_VehiculosIncidencias()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_vehiculosincidencias)
                  e_tran_vehiculosincidencias.Instanciar(ACEInstancia.Consulta)
                  listETRAN_VehiculosIncidencias.Add(e_tran_vehiculosincidencias)
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
   Private Function getSelectIncidencias(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql = App.Hash("DTRAN_VehiculosIncidencias.GetIncidencias").ToString()
         Dim _where As New ACGenerador(Of ETRAN_VehiculosIncidencias)(m_formatofecha)
         sql = String.Format(sql, _where.getWhere(x_where, True))

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

