Imports ACETransporte
Imports DAConexion

Public Class DAdministracionInventarios
#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Function GetInventarios(ByRef dt_datos As DataTable, ByVal x_codigos As String) As Boolean
      Dim _sql As String = ""
      Try
         App.Inicializar()
         If x_codigos.Length > 0 Then
            _sql &= App.Hash("GetInventarios.Todos")
         Else
            _sql &= String.Format(App.Hash("GetInventarios.Seleccionados"), x_codigos)
         End If
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         dt_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dt_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Metodos de Controles"

#End Region
End Class
