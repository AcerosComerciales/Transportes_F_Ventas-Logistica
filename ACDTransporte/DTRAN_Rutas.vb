Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_Rutas

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function RUTASS_Todos(ByRef listETRAN_Rutas As List(Of ETRAN_Rutas), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_Rutas())
               While reader.Read()
                  Dim e_tran_rutas As New ETRAN_Rutas()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_rutas)
                  e_tran_rutas.Instanciar(ACEInstancia.Consulta)
                  listETRAN_Rutas.Add(e_tran_rutas)
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

   Public Function RUTASS_TodosAyuda(ByRef dtETRAN_Rutas As DataTable, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_where), CommandType.Text)
         dtETRAN_Rutas = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtETRAN_Rutas.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "
   Public Function getSelectAll(ByVal x_cadena As String) As String
      Dim sql As String
      Try
         sql = " SELECT "
         sql &= " Rut.* "
         sql &= ", UOrigen.UBIGO_Descripcion As UBIGO_ORIGEN"
         sql &= ", UDestin.UBIGO_Descripcion As UBIGO_DESTINO"
         sql &= " FROM Transportes.TRAN_Rutas As Rut"
         sql &= " Inner Join Ubigeos As UOrigen On UOrigen.UBIGO_Codigo = Rut.UBIGO_CODORIGEN"
         sql &= " Inner Join Ubigeos As UDestin On UDestin.UBIGO_Codigo = Rut.UBIGO_CODDESTINO"
         sql &= " WHERE "
         sql &= String.Format(" Rut.RUTAS_Nombre Like '%{0}%'", x_cadena)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAyuda(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         Dim _where As New ACGenerador(Of ETRAN_Rutas)(m_formatofecha)
            sql = String.Format(App.Hash("DTRAN_Rutas.RUTASS_TodossAyuda").ToString(), _where.getWhere(x_where, True))
            Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

