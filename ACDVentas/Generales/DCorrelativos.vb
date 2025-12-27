Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DCorrelativos


#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "
   Public Function CORRSS_UnRegGetCorrelativo(ByRef x_correlativos As ECorrelativos) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectByGetCorrelativo(x_correlativos), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_correlativos)
               x_correlativos.Instanciar(ACEInstancia.Consulta)
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CORRSU_UnRegSetCorrelativo(ByVal x_correlativos As ECorrelativos, ByVal x_usuario As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getUpdateSetCorrelativo(x_correlativos, x_usuario), CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#Region "Procedimientos Adicionales "
   Public Function getSelectByGetCorrelativo(ByRef x_correlativos As ECorrelativos) As String
      Dim sql As String = ""
      Try
         sql = " SELECT " & vbNewLine
         sql &= " CORRE_Id" & vbNewLine
         sql &= ",SUCUR_Id" & vbNewLine
         sql &= ",CORRE_Tabla" & vbNewLine
         sql &= ",CORRE_Ano" & vbNewLine
         sql &= ",CORRE_Numero" & vbNewLine
         sql &= ",CORRE_Descripcion" & vbNewLine
         sql &= " FROM dbo.Correlativos" & vbNewLine
         sql &= " WHERE " & vbNewLine
         sql &= "CORRE_Tabla = '" + x_correlativos.CORRE_Tabla & "'" & vbNewLine
         sql &= "AND CORRE_Ano = '" + x_correlativos.CORRE_Ano & "'" & vbNewLine
         sql &= "AND SUCUR_Id = " & x_correlativos.SUCUR_Id.ToString()

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getUpdateSetCorrelativo(ByVal x_correlativos As ECorrelativos, ByVal x_usuario As String) As String
      Dim sql As String = ""
      Try
         sql &= "UPDATE dbo.Correlativos" & vbNewLine
         sql &= " SET "
         sql &= "  CORRE_Numero = " & IIf(x_correlativos.CORRE_Numero = 0, "Null", x_correlativos.CORRE_Numero.ToString()) & vbNewLine
         sql &= ", CORRE_UsrMod  = '" + x_usuario & "'" & vbNewLine
         sql &= ", CORRE_FecMod = " & getDate() & vbNewLine
         sql &= " WHERE "
         sql &= "    CORRE_Ano = '" & x_correlativos.CORRE_Ano & "'" & vbNewLine
         sql &= "AND CORRE_Tabla = '" & x_correlativos.CORRE_Tabla & "'"
         sql &= "AND SUCUR_Id = " & x_correlativos.SUCUR_Id.ToString()
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

