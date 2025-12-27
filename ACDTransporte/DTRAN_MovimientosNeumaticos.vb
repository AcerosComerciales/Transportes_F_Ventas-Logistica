Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_MovimientosNeumaticos

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "

   Public Function MOVNSI_UnRegMovimiento(ByRef x_tran_movimientosneumaticos As ETRAN_MovimientosNeumaticos, ByVal x_usuario As String) As Integer
      Dim m_filas As Integer
      Try
         DAEnterprise.AsignarProcedure(getInsertMovimiento(x_tran_movimientosneumaticos, x_usuario), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         x_tran_movimientosneumaticos.MOVNM_Id = CType(m_datos.Rows(0)(0), Long)
         Return m_filas
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function MOVNSU_UnRegEstado(ByVal x_tran_movimientosneumaticos As ETRAN_MovimientosNeumaticos, ByVal x_usuario As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getUpdateEstado(x_tran_movimientosneumaticos, x_usuario), CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "

   Public Function getInsertMovimiento(ByVal x_tran_movimientosneumaticos As ETRAN_MovimientosNeumaticos, ByVal x_usuario As String) As String
      Dim sql As String = ""
      Try
         sql = "INSERT INTO Transportes.TRAN_MovimientosNeumaticos"
         sql &= " (NEUMA_Id"
         sql &= ", DOCMT_IDORDEN"
         'sql &= ", DOCMT_IDREALIZACION"
         sql &= ", MOVNM_FECHA"
         sql &= ", MOVNM_UbicacionDestino"
         sql &= ", MOVNM_IDDESTINO"
         sql &= ", TIPOS_CodDestino"
         sql &= ", MOVNM_UbicacionOrigen"
         sql &= ", MOVNM_IDORIGEN"
         sql &= ", TIPOS_CODORIGEN"
         sql &= ", MOVNM_FECASIGNACION"
         sql &= ", MOVNM_FECRETIRO"
         sql &= ", MOVNM_GLOSA"
         sql &= ", MOVNM_Motivo"
         sql &= ", MOVNM_ESTADO"
         sql &= ",MOVNM_UsrCrea"
         sql &= ",MOVNM_FecCrea"
         sql &= ")"
         sql &= " VALUES "
         sql &= "(" & IIf(x_tran_movimientosneumaticos.NEUMA_Id = 0, "Null", x_tran_movimientosneumaticos.NEUMA_Id.ToString())
         sql &= "," & IIf(x_tran_movimientosneumaticos.DOCMT_IdOrden = 0, "Null", x_tran_movimientosneumaticos.DOCMT_IdOrden.ToString())
         'sql &= "," & IIf(x_tran_movimientosneumaticos.DOCMT_IDREALIZACION = 0, "Null", x_tran_movimientosneumaticos.DOCMT_IDREALIZACION.ToString())
         sql &= "," & IIf(x_tran_movimientosneumaticos.MOVNM_Fecha.Year < 1700, "Null", "'" & x_tran_movimientosneumaticos.MOVNM_Fecha.ToString(m_formatofecha) & "'")
         sql &= "," & IIf(IsNothing(x_tran_movimientosneumaticos.MOVNM_UbicacionDestino), "Null", "'" & x_tran_movimientosneumaticos.MOVNM_UbicacionDestino & "'")
         sql &= "," & IIf(x_tran_movimientosneumaticos.MOVNM_IdDestino = 0, "Null", x_tran_movimientosneumaticos.MOVNM_IdDestino.ToString())
         sql &= "," & IIf(IsNothing(x_tran_movimientosneumaticos.TIPOS_CodDestino), "Null", "'" & x_tran_movimientosneumaticos.TIPOS_CodDestino & "'")
         sql &= "," & IIf(IsNothing(x_tran_movimientosneumaticos.MOVNM_UbicacionOrigen), "Null", "'" & x_tran_movimientosneumaticos.MOVNM_UbicacionOrigen & "'")
         sql &= "," & IIf(x_tran_movimientosneumaticos.MOVNM_IdOrigen = 0, "Null", x_tran_movimientosneumaticos.MOVNM_IdOrigen.ToString())
         sql &= "," & IIf(IsNothing(x_tran_movimientosneumaticos.TIPOS_CodOrigen), "Null", "'" & x_tran_movimientosneumaticos.TIPOS_CodOrigen & "'")
         sql &= "," & getDate()
         sql &= ", Null"
         sql &= "," & IIf(IsNothing(x_tran_movimientosneumaticos.MOVNM_Glosa), "Null", "'" & x_tran_movimientosneumaticos.MOVNM_Glosa & "'")
         sql &= "," & IIf(IsNothing(x_tran_movimientosneumaticos.MOVNM_Motivo), "Null", "'" & x_tran_movimientosneumaticos.MOVNM_Motivo & "'")
         sql &= "," & IIf(IsNothing(x_tran_movimientosneumaticos.MOVNM_Estado), "Null", "'" & x_tran_movimientosneumaticos.MOVNM_Estado & "'")
         sql &= ", '" & x_usuario & "'"
         sql &= "," & getDate()
         sql &= ")"
         sql &= vbNewLine
         sql &= " SELECT @@IDENTITY AS 'Identity'; "
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getUpdateEstado(ByVal x_tran_movimientosneumaticos As ETRAN_MovimientosNeumaticos, ByVal x_usuario As String) As String
      Dim sql As String = ""
      Try
         sql &= "UPDATE Transportes.TRAN_MovimientosNeumaticos" & vbNewLine
         sql &= " SET "
         sql &= "  MOVNM_FECRETIRO = " & getDate()
         sql &= ", MOVNM_ESTADO = " & IIf(IsNothing(x_tran_movimientosneumaticos.MOVNM_Estado), "Null", "'" & x_tran_movimientosneumaticos.MOVNM_Estado & "'") & vbNewLine
         sql &= ", MOVNM_UsrMod  = '" + x_usuario & "'" & vbNewLine
         sql &= ", MOVNM_FecMod = " & getDate() & vbNewLine
         sql &= " WHERE "
         sql &= "    MOVNM_Id = " & IIf(x_tran_movimientosneumaticos.MOVNM_Id = 0, "Null", x_tran_movimientosneumaticos.MOVNM_Id.ToString()) & vbNewLine

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

