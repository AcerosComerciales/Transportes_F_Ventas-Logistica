Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DVENT_ListaPreciosArticulos


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	


#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
   Public Function VENT_ALPRESI_UnRegSQL(ByRef x_vent_listapreciosarticulos As EVENT_ListaPreciosArticulos, ByVal x_usuario As String) As String
      Try
         Return getInsert(x_vent_listapreciosarticulos, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function VENT_ALPRESU_UnRegSQL(ByVal x_vent_listapreciosarticulos As EVENT_ListaPreciosArticulos, ByVal x_usuario As String) As String
      Try
            Return getUpdateSQL(x_vent_listapreciosarticulos, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
    End Function

    Private Function getUpdateSQL(ByVal x_vent_listapreciosarticulos As EVENT_ListaPreciosArticulos, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            sql &= String.Format("UPDATE Ventas.VENT_ListaPreciosArticulos Set{0}", vbNewLine)
            sql &= String.Format("ALPRE_PorcentaVenta = {1}{0}", vbNewLine, x_vent_listapreciosarticulos.ALPRE_PorcentaVenta)
            sql &= String.Format(",ALPRE_UsrMod = '{1}'{0}", vbNewLine, x_usuario)
            sql &= String.Format(",ALPRE_FecMod = GetDate(){0}", vbNewLine)
            sql &= String.Format("Where   ISNULL(LPREC_Id, '') = {1} AND  ISNULL(ZONAS_Codigo, '') = '{2}' AND  ISNULL(ARTIC_Codigo, '') = '{3}'{0}", vbNewLine, _
                                  x_vent_listapreciosarticulos.LPREC_Id, x_vent_listapreciosarticulos.ZONAS_Codigo, x_vent_listapreciosarticulos.ARTIC_Codigo)
            sql &= String.Format("{0}", vbNewLine)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
   End Function

   Public Function VENT_ALPRESU_UnRegPASQL(ByVal x_vent_listapreciosarticulos As EVENT_ListaPreciosArticulos, ByVal x_usuario As String) As Integer
      Try
         DAEnterprise.AsignarProcedure("VENT_ALPRESU_UnReg")
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_vent_listapreciosarticulos.ZONAS_Codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@LPREC_Id", x_vent_listapreciosarticulos.LPREC_Id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_vent_listapreciosarticulos.ARTIC_Codigo, DbType.String, 7)
         DAEnterprise.AgregarParametro("@ALPRE_Constante", x_vent_listapreciosarticulos.ALPRE_Constante, DbType.Decimal, 9)
         DAEnterprise.AgregarParametro("@ALPRE_PorcentaVenta", x_vent_listapreciosarticulos.ALPRE_PorcentaVenta, DbType.Decimal, 9)
         DAEnterprise.AgregarParametro("@Usuario", x_usuario, 20)
         Return DAEnterprise.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region


End Class

