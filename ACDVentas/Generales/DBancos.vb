Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DBancos


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function BANCOSS_Todos(ByRef listETRAN_Bancos As List(Of EBancos), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EBancos())
               While reader.Read()
                  Dim e_tran_bancos As New EBancos()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_bancos)
                  e_tran_bancos.Instanciar(ACEInstancia.Consulta)
                  listETRAN_Bancos.Add(e_tran_bancos)
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

   Public Function getCorrelativo() As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectId(), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("BancoID"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function BANCOSS_TodosDT() As DataTable
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
         Return DAEnterprise.ExecuteDataSet().Tables(0)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function BANCOSS_Todos(ByRef listEBancos As List(Of EBancos), ByRef m_dtBanco As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
         m_dtBanco = DAEnterprise.ExecuteDataSet().Tables(0)

         For Each Item As DataRow In m_dtBanco.Rows
            Dim _utilitarios As New ACEsquemas(New EBancos())
            Dim e_bancos As New EBancos()
            _utilitarios.ACCargarEsquemas(Item, e_bancos)
            e_bancos.Instanciar(ACEInstancia.Consulta)
            listEBancos.Add(e_bancos)
         Next
         m_dtBanco.Columns("BANCO_Id").ColumnName = "CODIGO"
         m_dtBanco.Columns("BANCO_Descripcion").ColumnName = "DESCRIPCION"

      Catch ex As Exception
         Throw ex
      End Try
   End Function


#Region "Procedimientos Adicionales "
   Public Function getSelectAll(ByVal x_cadena As String) As String
      Dim sql As String
      Try
         sql = " SELECT *"
         sql &= " FROM Bancos As B"
         sql &= " WHERE "
         sql &= "B.BANCO_Descripcion like '%" & x_cadena & "%'"

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectID() As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" SELECT max(B.BANCO_Id) as BancoID  from Bancos B {0}", vbNewLine)
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

