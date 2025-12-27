Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_OrdenesTransportes

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function ORDTSU_UnRegCambiarEstado(ByVal x_tran_ordenestransportes As ETRAN_OrdenesTransportes, ByVal x_usuario As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getUpdateCambiarEstado(x_tran_ordenestransportes, x_usuario), CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#Region "Procedimientos Adicionales "
   Public Function getUpdateCambiarEstado(ByVal x_tran_ordenestransportes As ETRAN_OrdenesTransportes, ByVal x_usuario As String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format("UPDATE Transportes.TRAN_OrdenesTransportes{0}", vbNewLine)
         sql &= " SET "
         sql &= String.Format("  ORDTR_Estado = {0}{1}", IIf(IsNothing(x_tran_ordenestransportes.ORDTR_Estado), "Null", String.Format("'{0}'", x_tran_ordenestransportes.ORDTR_Estado)), vbNewLine)
         sql &= String.Format(", ORDTR_UsrMod = '{0}'{1}", x_usuario, vbNewLine)
         sql &= String.Format(", ORDTR_FecMod = {0}{1}", getDate(), vbNewLine)
         sql &= " WHERE "
         sql &= String.Format("    ORDTR_Codigo = '{0}'{1}", IIf(IsNothing(x_tran_ordenestransportes.ORDTR_Codigo), "Null", x_tran_ordenestransportes.ORDTR_Id.ToString()), vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region
#End Region

#Region " Metodos "
   Public Function ORDTSS_TodosAyuda(ByRef dtETRAN_OrdenesTransportes As DataTable, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_where), CommandType.Text)
         dtETRAN_OrdenesTransportes = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtETRAN_OrdenesTransportes.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   Public Function getSelectAyuda(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         sql = " SELECT "
         sql &= String.Format(" Ent.ENTID_RazonSocial As [Razon Social]{0}", vbNewLine)
         sql &= String.Format(",Rut.RUTAS_Nombre As [Nombre - Ruta]{0}", vbNewLine)
         sql &= String.Format(",OTran.ORDTR_Codigo As Codigo{0}", vbNewLine)
         sql &= String.Format(",OTran.ORDTR_Fecha As Fecha{0}", vbNewLine)
         sql &= String.Format(",OTran.ORDTR_Id As Interno{0}", vbNewLine)
         sql &= String.Format(" FROM Transportes.TRAN_OrdenesTransportes As OTran{0}", vbNewLine)
         sql &= String.Format("     Inner Join dbo.Entidades As Ent On Ent.ENTID_Codigo = OTran.ENTID_Codigo{0}", vbNewLine)
         sql &= String.Format("     Inner Join Transportes.TRAN_Rutas As Rut On Rut.RUTAS_Id = OTran.RUTAS_Id{0}", vbNewLine)
         If Not IsNothing(x_where) Then
            sql &= String.Format(" WHERE {0}", vbNewLine)
            Dim _where As New ACGenerador(Of ETRAN_OrdenesTransportes)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)
         End If
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region


End Class

