Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_Ranflas

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function RAMFSS_Todos(ByRef listETRAN_Ranflas As List(Of ETRAN_Ranflas), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_Ranflas())
               While reader.Read()
                  Dim e_tran_ranflas As New ETRAN_Ranflas()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_ranflas)
                  e_tran_ranflas.Instanciar(ACEInstancia.Consulta)
                  listETRAN_Ranflas.Add(e_tran_ranflas)
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

   Public Function RAMFSS_TodosAyuda(ByRef x_dtETRAN_Ranflas As DataTable, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_where), CommandType.Text)
         x_dtETRAN_Ranflas = DAEnterprise.ExecuteDataSet().Tables(0)
         Return x_dtETRAN_Ranflas.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getCorrelativo() As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectId(), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("RANFL_Id"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function



#Region "Procedimientos Adicionales "
   Public Function getSelectAll(ByVal x_cadena As String) As String
      Dim sql As String
      Try
         sql = " SELECT "
         sql &= " Ran.*, TIPOS_Descripcion As TIPOS_Marca, Suc.SUCUR_Nombre"
         sql &= " FROM Transportes.TRAN_Ranflas As Ran"
         sql &= " Inner Join Sucursales As Suc On Suc.SUCUR_Id = Ran.SUCUR_Id"
         sql &= " Inner Join Tipos As TMar On TMar.TIPOS_Codigo = Ran.TIPOS_CodMarca"
         sql &= " WHERE "
         sql &= " Ran.RANFL_Codigo Like '%" & x_cadena & "%'"
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAyuda(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         sql = " SELECT " & vbNewLine
         sql &= " RANFL_ID As Interno" & vbNewLine
         sql &= ",TIPOS_Descripcion As Marca" & vbNewLine
         sql &= ",RANFL_Codigo As Codigo" & vbNewLine
         sql &= ",RANFL_MODELO As Modelo" & vbNewLine
         sql &= ",RANFL_Placa As Placa" & vbNewLine
         sql &= ",RANFL_Certificado As Certificado" & vbNewLine
         sql &= ",RANFL_FecAdquisicion As Adquisición" & vbNewLine
         sql &= " FROM Transportes.TRAN_Ranflas As m_Ran" & vbNewLine
         sql &= " Inner Join Tipos As TMar On TMar.TIPOS_Codigo = m_Ran.TIPOS_CodMarca  " & vbNewLine
         sql &= " WHERE " & vbNewLine
         Dim _where As New ACGenerador(Of ETRAN_Ranflas)(m_formatofecha)
         sql &= _where.getWhere(x_where, "Ran", True)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectID() As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" SELECT isnull(max(tr.RANFL_Id),0) as RANFL_Id  from Transportes.TRAN_Ranflas tr {0}", vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#End Region
#End Region

End Class

