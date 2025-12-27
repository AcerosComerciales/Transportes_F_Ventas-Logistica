Imports ACEVentas
Imports DAConexion
Imports ACFramework
Imports System.Data.Common

Public Class DGenerarPedidoTransformacion

#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
  
    ''' <summary>
    ''' getNumeroLotexBobina
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNumeroLotexBobina(byval x_articcodigo As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectloteXbobina(x_articcodigo), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("Lote"), Integer)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     Public Function getcabecera(byval x_codigo As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectcabecera(x_codigo), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("Lote"), Integer)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    


   ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_OrdenesXDocumento
   ''' </summary>
   ''' <param name="x_pedid_codtrans">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_PedidosXDocumento(ByVal m_listdist_ordenes As List(Of EABAS_PedidoTransformacion), ByVal x_pedid_codtrans As String, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_PedTransformacionXDocumento")
         DAEnterprise.AgregarParametro("@PEDID_CodigoTras", x_pedid_codtrans, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_ordenes As New EABAS_PedidoTransformacion()
                  ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
                  _dist_ordenes.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_ordenes)
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

    
     ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_OrdenesXDocumento
   ''' </summary>
   ''' <param name="x_pedid_codtrans">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_PedidosXDocumentoL(ByVal m_listdist_ordenes As List(Of EABAS_PedidoTransformacion), ByVal x_pedid_codtrans As String, ByVal x_Almac_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_PedTransformacionXDocumentoL")
         DAEnterprise.AgregarParametro("@PEDID_CodigoTras", x_pedid_codtrans, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_Almac_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_ordenes As New EABAS_PedidoTransformacion()
                  ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
                  _dist_ordenes.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_ordenes)
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



#End Region

#Region " Procedimientos Adicionales"
    Private Function getSelectloteXbobina(ByVal x_articcodigo As String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format("select isnull(max(PEDID_Lote)+1,1) AS Lote from Logistica.ABAS_PedidoTransformacionDetalle where artic_codigo={0}",x_articcodigo, vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
     Private Function getSelectcabecera(ByVal x_codigo As String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format("select isnull(max(PEDID_Lote)+1,1) AS Lote from Logistica.ABAS_PedidoTransformacionDetalle where artic_codigo={0}",x_codigo, vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region


End Class
