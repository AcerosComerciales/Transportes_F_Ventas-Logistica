Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTESO_CajaChicaPagos

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "
    Public Function TESO_GastosXCajaChica(ByVal m_list_cajachicapago As List(Of ETESO_CajaChicaPagos), ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_GastosXCajaChica")
            DAEnterprise.AgregarParametro("@DESCRIPCION", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _rec_CAJA_CHICA As New ETESO_CajaChicaPagos
                        'Dim _vent_docsventa As New EVENT_DocsVenta()
                        'ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                        '_vent_docsventa.Instanciar(ACEInstancia.Consulta)
                        ACEsquemas.ACCargarEsquema(reader, _rec_CAJA_CHICA)
                        _rec_CAJA_CHICA.Instanciar(ACEInstancia.Consulta)
                        m_list_cajachicapago.Add(_rec_CAJA_CHICA)
                        ' m_listvent_docsventa.Add(_vent_docsventa)
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
    Public Function TESO_PagosXCajaChica(ByVal m_list_cajachicapago As List(Of ETESO_CajaChicaPagos), ByVal x_cajac_id As Integer) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_PagosCajaChica")
            DAEnterprise.AgregarParametro("@CAJAC_Id", x_cajac_id, DbType.String, 14)

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _pag_CAJA_CHICA As New ETESO_CajaChicaPagos
                        'Dim _vent_docsventa As New EVENT_DocsVenta()
                        'ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                        '_vent_docsventa.Instanciar(ACEInstancia.Consulta)
                        ACEsquemas.ACCargarEsquema(reader, _pag_CAJA_CHICA)
                        _pag_CAJA_CHICA.Instanciar(ACEInstancia.Consulta)
                        m_list_cajachicapago.Add(_pag_CAJA_CHICA)
                        ' m_listvent_docsventa.Add(_vent_docsventa)
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
    ''' Capa de Datos: TESO_ConsultaPagosCC
    ''' </summary>
    ''' <param name="x_pvent_id">Parametro 1: </param> 
    ''' <param name="x_cajac_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function TESO_ConsultaPagosCC(ByVal m_listteso_cajachicapagos As List(Of ETESO_CajaChicaPagos), ByVal x_pvent_id As Long, ByVal x_cajac_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TESO_ConsultaPagosCC")
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@CAJAC_Id", x_cajac_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _teso_cajachicapagos As New ETESO_CajaChicaPagos()
                  ACEsquemas.ACCargarEsquema(reader, _teso_cajachicapagos)
                  _teso_cajachicapagos.Instanciar(ACEInstancia.Consulta)
                  m_listteso_cajachicapagos.Add(_teso_cajachicapagos)
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

End Class

