Imports DAConexion

Public Class DConstantes

#Region " Variables "
   Private m_formatofecha As String
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()
      m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
   End Sub
#End Region

#Region " Metodos "
   Public Function getDate() As String
      Dim x_datos As New DataTable()
      Try
         DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Dim _fecha As DateTime = x_datos.Rows(0)(0)
         Return "'" & _fecha.ToString(m_formatofecha) & "'"
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getDateTime() As DateTime
      Dim x_datos As New DataTable()
      Try
         DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Dim _fecha As DateTime = x_datos.Rows(0)(0)
         Return _fecha
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Metodos de Controles"

#End Region


End Class
