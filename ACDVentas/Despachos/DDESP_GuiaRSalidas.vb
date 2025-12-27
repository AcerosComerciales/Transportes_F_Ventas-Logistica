Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DDESP_GuiaRSalidas

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function GUIASU_ActualizarGuiaRSalidas(ByRef x_desp_guiarsalidas As EDESP_GuiaRSalidas, ByVal x_usuario As String) As Integer
      Try
         DAEnterprise.AsignarProcedure("GUIASU_ActualizarGuiaRSalidas")
         DAEnterprise.AgregarParametro("@SALID_Id", x_desp_guiarsalidas.SALID_Id, DbType.Int32, 4)
         DAEnterprise.AgregarParametro("@VEHIC_Id", x_desp_guiarsalidas.VEHIC_Id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@GUISA_Numero", x_desp_guiarsalidas.GUISA_Numero, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@GUISA_HoraSalida", x_desp_guiarsalidas.GUISA_HoraSalida, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@GUISA_HoraLlegada", x_desp_guiarsalidas.GUISA_HoraLlegada, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Usuario", x_usuario, DbType.String, 20)
         Return DAEnterprise.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
	
#End Region

End Class

