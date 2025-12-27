Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_Cotizaciones

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "

   Public Function COTISS_TodosAyuda(ByRef dtETRAN_Cotizaciones As DataTable, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
         dtETRAN_Cotizaciones = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtETRAN_Cotizaciones.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getCorrelativo(ByVal x_zonas_codigo As String, ByVal x_sucur_codigo As Short) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectAllC(x_zonas_codigo, x_sucur_codigo), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("Codigo"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function QuitarFacturaCotizacion(ByVal x_docve_codigo As String) As Boolean
      Dim _sql As String = ""
      Try
         _sql = String.Format("Update Transportes.TRAN_Cotizaciones Set DOCVE_Codigo = Null Where DOCVE_Codigo = '{0}'", x_docve_codigo)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "
   Private Function getSelectAllC(ByVal x_zonas_codigo As String, ByVal x_sucur_codigo As Short) As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" SELECT Convert(Int, IsNull(Max(COTIZ_Numero), '0')) As Codigo FROM [Transportes].[TRAN_Cotizaciones] {0}", vbNewLine)
         sql &= String.Format(" Where ZONAS_Codigo = '{0}' And SUCUR_Id = {1} {2}", x_zonas_codigo, x_sucur_codigo, vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

#Region " Metodos "
   Public Function CambiarEstado(ByVal x_estado As ETRAN_Cotizaciones.Estado, ByVal x_cotiz_codigo As String)
      Dim sql As String = ""
      Try
         sql = String.Format("Update Transportes.TRAN_Cotizaciones Set COTIZ_Estado = '{0}' Where COTIZ_Codigo = '{1}'", ETRAN_Cotizaciones.getEstado(x_estado), x_cotiz_codigo)
         DAEnterprise.AsignarProcedure(sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region


End Class

