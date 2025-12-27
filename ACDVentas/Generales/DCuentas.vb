Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DCuentas


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function getCorrelativo() As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectId(), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("CuentaID"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CUENTSS_Todos(ByRef listETRAN_Cuentas As List(Of ECuentas), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ECuentas())
               While reader.Read()
                  Dim e_tran_cuentas As New ECuentas()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_cuentas)
                  e_tran_cuentas.Instanciar(ACEInstancia.Consulta)
                  listETRAN_Cuentas.Add(e_tran_cuentas)
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

   Public Function CUENTSS_TodosDT() As DataTable
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
         Return DAEnterprise.ExecuteDataSet().Tables(0)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CUENTSS_Todos(ByRef listECuenta As List(Of ECuentas), ByRef m_dtCuenta As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
         m_dtCuenta = DAEnterprise.ExecuteDataSet().Tables(0)

         For Each Item As DataRow In m_dtCuenta.Rows
            Dim _utilitarios As New ACEsquemas(New ECuentas())
            Dim e_cuentas As New ECuentas()
            _utilitarios.ACCargarEsquemas(Item, e_cuentas)
            e_cuentas.Instanciar(ACEInstancia.Consulta)
            listECuenta.Add(e_cuentas)
         Next
         m_dtCuenta.Columns("CUENT_Id").ColumnName = "CODIGO"
         m_dtCuenta.Columns("CUENT_Numero").ColumnName = "NUMERO"

      Catch ex As Exception
         Throw ex
      End Try
   End Function


#Region "Procedimientos Adicionales "
   Public Function getSelectID() As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" SELECT max(C.CUENT_Id) as CuentaID from Cuentas C {0}", vbNewLine)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAll(ByVal x_cadena As String) As String
      Dim sql As String
      Try

         sql = " SELECT C.*, Ba.BANCO_Descripcion "
         sql &= " FROM Cuentas As C"
         sql &= " INNER JOIN Bancos Ba ON "
         sql &= "C.BANCO_Id = Ba.BANCO_Id "
         sql &= "Where "
         sql &= "Ba.BANCO_Descripcion like '%" & x_cadena & "%'"

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

