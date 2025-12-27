Imports System
Imports System.Data
Imports System.Collections.Generic
Imports DAConexion
Imports ACFramework
Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_CajaChicaPagos

#Region " Variables "
    Private m_pvent_id As Integer
    Private d_teso_cajachicapagos As DTESO_CajaChicaPagos
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "
    Public Function TESO_GastosXCajaChica(ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        ' m_listvent_docsventa = New List(Of EVENT_DocsVenta)
        '  m_listTESO_Recibos = New List(Of ETESO_Recibos)
        m_listTESO_CajaChicaPagos = New List(Of ETESO_CajaChicaPagos)
        Try
            Return d_teso_cajachicapagos.TESO_GastosXCajaChica(m_listTESO_CajaChicaPagos, x_entid_codigo, m_pvent_id, x_todos, x_fecini, x_fecfin)
            'Return d_administracioncaja.VENT_DOCVESS_FacturasXCliente(m_listvent_docsventa, x_entid_codigo, m_pvent_id, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TESO_PagosXCajaChica(ByVal x_cajac_id As Integer) As Boolean
        ' m_listvent_docsventa = New List(Of EVENT_DocsVenta)
        '  m_listTESO_Recibos = New List(Of ETESO_Recibos)
        m_listTESO_CajaChicaPagos = New List(Of ETESO_CajaChicaPagos)
        Try
            Return d_teso_cajachicapagos.TESO_PagosXCajaChica(m_listTESO_CajaChicaPagos, x_cajac_id)
            'Return d_administracioncaja.VENT_DOCVESS_FacturasXCliente(m_listvent_docsventa, x_entid_codigo, m_pvent_id, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Metodos "

    ''' <summary>
    ''' Guardar pagos de caja chica
    ''' </summary>
    ''' <param name="x_usuario">codigo de usuario</param>
    ''' <param name="x_detalle">detalle de los pago</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Guardar(ByVal x_usuario As String, ByVal x_detalle As Boolean) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim _where As New Hashtable
         _where.Add("CAJAC_Id", New ACWhere(m_eteso_cajachicapagos.CAJAC_Id))
         m_eteso_cajachicapagos.CAJAP_Item = getCorrelativo("CAJAP_Item", _where)

         If x_detalle Then
            Dim _documento As New BTESO_Documentos
            _documento.TESO_Documentos = m_eteso_cajachicapagos.TESO_Documentos
            _documento.TESO_Documentos.DOCUS_Serie = _documento.TESO_Documentos.DOCUS_Serie.Trim().PadLeft(3, "0")
            _documento.TESO_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", _documento.TESO_Documentos.TIPOS_CodTipoDocumento.Substring(3, 2), _documento.TESO_Documentos.DOCUS_Serie, _documento.TESO_Documentos.DOCUS_Numero.PadLeft(7, "0"))
            m_eteso_cajachicapagos.DOCUS_Codigo = _documento.TESO_Documentos.DOCUS_Codigo
            If _documento.GenerarDocumento(m_eteso_cajachicapagos.CAJAP_Descripcion, x_usuario, False) Then
               If Guardar(x_usuario) Then
                  DAEnterprise.CommitTransaction()
                  Return True
               Else
                  Throw New Exception("No se puede completar el proceso")
               End If
            End If
         Else
            If Guardar(x_usuario) Then
               DAEnterprise.CommitTransaction()
               Return True
            Else
               Throw New Exception("No se puede completar el proceso")
            End If
         End If
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: TESO_ConsultaPagosCC
   ''' </summary>
   ''' <param name="x_pvent_id">Parametro 1: </param> 
   ''' <param name="x_cajac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ConsultaPagosCC(ByVal x_pvent_id As Long, ByVal x_cajac_id As Long) As Boolean
      m_listTESO_CajaChicaPagos = New List(Of ETESO_CajaChicaPagos)
      Try
         Return d_teso_cajachicapagos.TESO_ConsultaPagosCC(m_listTESO_CajaChicaPagos, x_pvent_id, x_cajac_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

