Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_Recibos

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function getNumero(ByVal x_docve_serie As String, ByVal x_tipos_codtiporecibo As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_docve_serie, x_tipos_codtiporecibo), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("Numero"), Integer)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Procedimiento "TRAN_CAJASS_RecibosTransporte" por el Generador 03/04/2012
   ' </summary> 
   ' <param name="m_listTRAN_Recibos">Lista donde se cargaran los valores</param> 
   ' <param name="x_viaje_id">Parametro 1: </param> 
   ' <returns>Si no hay registros devuelve Falso</returns> 
   ' <remarks></remarks> 
   Public Function TRAN_CAJASS_RecibosTransporte(ByRef m_listTRAN_Recibos As List(Of ETRAN_Recibos), ByVal x_viaje_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_CAJASS_RecibosTransporte")
         DAEnterprise.AgregarParametro("@VIAJE_Id", x_viaje_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_tran_recibos As New ETRAN_Recibos()
                  ACEsquemas.ACCargarEsquema(reader, e_TRAN_Recibos)
                  e_TRAN_Recibos.Instanciar(ACEInstancia.Consulta)
                  m_listTRAN_Recibos.Add(e_TRAN_Recibos)
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

   Public Function ModificarImpFec(ByVal x_tran_recibo As ETRAN_Recibos, ByVal x_fecha As DateTime, ByVal x_importe As Decimal, ByVal x_usuario As String)
      Dim _sql As String = ""
      Try
         Dim _fecha As DateTime = getDateTime()

         _sql &= String.Format("Update Transportes.TRAN_Recibos Set RECIB_Fecha = '{1}', RECIB_Monto = {2}{0}", vbNewLine, x_fecha.ToString(m_formatofecha), x_importe)
         _sql &= String.Format(", RECIB_UsrMod = '{1}', RECIB_FecMod = '{2}'{0}", vbNewLine, x_usuario, _fecha.ToString(m_formatofecha))
         _sql &= String.Format("Where RECIB_Codigo = '{1}'{0}", vbNewLine, x_tran_recibo.RECIB_Codigo)
         _sql &= String.Format("{0}", vbNewLine)

         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ModificarFecha(ByVal x_tran_recibo As ETRAN_Recibos, ByVal x_fecha As DateTime, ByVal x_usuario As String)
      Dim _sql As String = ""
      Try
         Dim _fecha As DateTime = getDateTime()

         _sql &= String.Format("Update Transportes.TRAN_Recibos Set RECIB_Fecha = ''{0}", vbNewLine, x_fecha.ToString(m_formatofecha))
         _sql &= String.Format(", RECIB_UsrMod = '', RECIB_FecMod = ''{0}", vbNewLine, x_usuario, _fecha.ToString(m_formatofecha))
         _sql &= String.Format("Where RECIB_Codigo = ''{0}", vbNewLine, x_tran_recibo.RECIB_Codigo)
         _sql &= String.Format("{0}", vbNewLine)

         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Datos: TRAN_ObtenerRecibo
   ' </summary>
   ' <param name="x_recib_codigo">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_ObtenerRecibo(ByRef m_tran_recibos As ETRAN_Recibos, ByVal x_recib_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_ObtenerRecibo")
         DAEnterprise.AgregarParametro("@RECIB_Codigo", x_recib_codigo, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               m_tran_recibos = New ETRAN_Recibos()
               If reader.Read() Then
                  ACEsquemas.ACCargarEsquema(reader, m_tran_recibos)
                  m_tran_recibos.Instanciar(ACEInstancia.Consulta)
                  Return True
               End If

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
   Private Function getSelectAll(ByVal x_docve_serie As String, ByVal x_tipos_codtiporecibo As String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" Select IsNull(Max(RECIB_Numero), 0) As Numero from Transportes.TRAN_Recibos ", vbNewLine)
         sql &= String.Format(" Where RECIB_Serie = '{0}' And TIPOS_CodTipoRecibo = '{1}'{2}", x_docve_serie, x_tipos_codtiporecibo, vbNewLine)

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

