Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTESO_Caja

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   ''' <summary> 
   ''' Capa de Datos: TESO_CAJASS_ObtenerDocPagosDetalle
   ''' </summary>
   ''' <param name="x_dpago_id">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TESO_CAJASS_ObtenerDocPagosDetalle(ByVal m_listteso_caja As List(Of ETESO_Caja), ByVal x_dpago_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TESO_CAJASS_ObtenerDocPagosDetalle")
         DAEnterprise.AgregarParametro("@DPAGO_Id", x_dpago_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _teso_caja As New ETESO_Caja()
                  ACEsquemas.ACCargarEsquema(reader, _teso_caja)
                  _teso_caja.Instanciar(ACEInstancia.Consulta)
                  m_listteso_caja.Add(_teso_caja)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "

   ''' <summary>
   ''' modificar la fecha de impresión
   ''' </summary>
   ''' <param name="x_eteso_caja"></param>
   ''' <param name="x_caja_fecha"></param>
   ''' <param name="x_importe"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ModificarImpFec(ByVal x_eteso_caja As ETESO_Caja, ByVal x_caja_fecha As DateTime, ByVal x_importe As Decimal, ByVal x_usuario As String) As Boolean
      Dim _sql As String = ""
      Try
         Dim _fecha As DateTime = getDateTime()

         _sql &= String.Format("Update Tesoreria.TESO_Caja Set CAJA_Fecha = '{1}', CAJA_Importe = {2}{0}", vbNewLine, x_caja_fecha.ToString(m_formatofecha), x_importe)
         _sql &= String.Format(", CAJA_UsrMod = '{1}', CAJA_FecMod = '{2}'{0}", vbNewLine, x_usuario, _fecha.ToString(m_formatofecha))
         _sql &= String.Format("Where CAJA_Id = {1}{0}", vbNewLine, x_eteso_caja.CAJA_Id)
         _sql &= String.Format("{0}", vbNewLine)

         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Modificar fecha
   ''' </summary>
   ''' <param name="x_eteso_caja"></param>
   ''' <param name="x_caja_fecha"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ModificarFecha(ByVal x_eteso_caja As ETESO_Caja, ByVal x_caja_fecha As DateTime, ByVal x_usuario As String) As Boolean
      Dim _sql As String = ""
      Try
         Dim _fecha As DateTime = getDateTime()

         _sql &= String.Format("Update Tesoreria.TESO_Caja Set CAJA_Fecha = '{1}'{0}", vbNewLine, x_caja_fecha.ToString(m_formatofecha))
         _sql &= String.Format(", CAJA_UsrMod = '{1}', CAJA_FecMod = '{2}'{0}", vbNewLine, x_usuario, _fecha.ToString(m_formatofecha))
         _sql &= String.Format("Where CAJA_Id = {1} AND PVENT_Id={1}{0}", vbNewLine, x_eteso_caja.CAJA_Id, x_eteso_caja.PVENT_Id)
         _sql &= String.Format("{0}", vbNewLine)

         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cambiar estado
   ''' </summary>
   ''' <param name="x_caja_id"></param>
   ''' <param name="x_pvent_id"></param>
   ''' <param name="x_caja_fecha"></param>
   ''' <param name="x_estado"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CambiarEstado(ByVal x_caja_id As Long, ByVal x_pvent_id As Integer, ByVal x_caja_fecha As DateTime, ByVal x_estado As ETESO_Caja.Estado, ByVal x_usuario As String) As Boolean
      Dim _sql As String = ""
      Try
         Dim _fecha As DateTime = getDateTime()
         If _fecha.Date <> x_caja_fecha.Date Then
            _sql &= String.Format("Update Tesoreria.TESO_Caja Set CAJA_Estado = '{1}', CAJA_FechaAnulado = GetDate(), CAJA_AnuladoCaja = 1 ,CAJA_UsrMod = '{2}' ,CAJA_FecMod = '{3}'{0}", vbNewLine, ETESO_Caja.getEstado(x_estado), x_usuario, _fecha.ToString(m_formatofecha))
         Else
            _sql &= String.Format("Update Tesoreria.TESO_Caja Set CAJA_Estado = '{1}', CAJA_UsrMod = '{2}' ,CAJA_FecMod = '{3}'{0}", vbNewLine, ETESO_Caja.getEstado(x_estado), x_usuario, _fecha.ToString(m_formatofecha))
         End If
         _sql &= String.Format("Where CAJA_Id = {1} AND PVENT_Id = {2}{0}", vbNewLine, x_caja_id, x_pvent_id)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

