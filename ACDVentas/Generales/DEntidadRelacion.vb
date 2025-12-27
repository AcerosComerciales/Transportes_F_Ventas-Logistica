Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DEntidadRelacion


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function GetNumero(ByVal x_entid_codigo As String) As Integer
      Dim m_datos As New DataTable()
      Try
         DAEnterprise.AsignarProcedure(getSelectNumero(x_entid_codigo), CommandType.Text)
         m_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return m_datos.Rows(0)("Numero")
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
   Private Function getSelectNumero(ByVal x_entid_codigo As String)
      Dim sql As String = ""
      Try
         sql &= String.Format("SELECT IsNull(Max(ENTRE_Numero), 1) As Numero From EntidadRelacion Where ENTID_Codigo = '{0}'", x_entid_codigo)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region


End Class

