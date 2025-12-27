Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Public Class DManejarStock

#Region " Variables "
   Private m_formatofecha As String
#End Region

#Region " Constructores "
   Public Sub New()
      m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
   End Sub
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function Egreso(ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_cantidad As Double, ByVal x_usuario As String) As Boolean
      Try
         x_cantidad = x_cantidad * -1
         DAEnterprise.AsignarProcedure(getUpdateES(x_artic_codigo, x_almac_id, x_cantidad, x_usuario), CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Ingreso(ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_cantidad As Double, ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getUpdateES(x_artic_codigo, x_almac_id, x_cantidad, x_usuario), CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function AnulacionIngreso(ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_cantidad As Double, ByVal x_usuario As String) As Boolean
      Try

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function AnulacionEgreso(ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_cantidad As Double, ByVal x_usuario As String) As Boolean
      Try

      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region " Metodos Adicionales "
   Private Function getUpdateES(ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_cantidad As Double, ByVal x_usuario As String) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         Dim x_fecha As DateTime = getDateTime()
         sql = String.Format(App.Hash("DManejarStock.IngresoEgreso").ToString(), x_cantidad.ToString(), x_usuario, x_fecha.ToString(m_formatofecha), x_artic_codigo, x_almac_id.ToString())
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getDateTime() As DateTime
      Dim x_datos As New DataTable()
      Try
         DAEnterprise.AsignarProcedure("select GetDate()", CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Dim _fecha As DateTime = x_datos.Rows(0)(0)
         Return _fecha
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

#Region " Metodos "

#End Region


End Class

