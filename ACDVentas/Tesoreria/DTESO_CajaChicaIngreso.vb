Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTESO_CajaChicaIngreso

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "

    ''' <summary> 
    ''' Capa de Datos: TESO_ConsultaCajaChica
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_cadena">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_todos">Parametro 5: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function TESO_ConsultaCajaChica(ByVal m_listteso_cajachicaingreso As List(Of ETESO_CajaChicaIngreso), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_cadena As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean, ByVal x_fecha As Boolean, ByVal x_tipocc As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_GastosXCodigoCajaChica")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@TipoCC", x_tipocc, DbType.String, 5)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _teso_cajachicaingreso As New ETESO_CajaChicaIngreso()
                        ACEsquemas.ACCargarEsquema(reader, _teso_cajachicaingreso)
                        _teso_cajachicaingreso.Instanciar(ACEInstancia.Consulta)
                        m_listteso_cajachicaingreso.Add(_teso_cajachicaingreso)
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

    'TESO_GastosXNumeroCajaChica
    Public Function TESO_GastosXNumeroCajaChica(ByVal m_listteso_cajachicaingreso As List(Of ETESO_CajaChicaIngreso), ByVal x_caja_id As Integer) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_GastosXNumeroCajaChica")
            DAEnterprise.AgregarParametro("@Caja_Id", x_caja_id, DbType.Int32, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _teso_cajachicaingreso As New ETESO_CajaChicaIngreso()
                        ACEsquemas.ACCargarEsquema(reader, _teso_cajachicaingreso)
                        _teso_cajachicaingreso.Instanciar(ACEInstancia.Consulta)
                        m_listteso_cajachicaingreso.Add(_teso_cajachicaingreso)
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
    ''' Capa de Datos: TESO_ObtenerReciboCC
    ''' </summary>
    ''' <param name="x_cajac_id">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function TESO_ObtenerReciboCC(ByRef m_tran_recibosCC As ETESO_CajaChicaIngreso, ByVal x_cajac_id As String, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_ObtenerReciboCC")
            DAEnterprise.AgregarParametro("@CAJAC_Id", x_cajac_id, DbType.String, 14)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    m_tran_recibosCC = New ETESO_CajaChicaIngreso()
                    If reader.Read() Then
                        ACEsquemas.ACCargarEsquema(reader, m_tran_recibosCC)
                        m_tran_recibosCC.Instanciar(ACEInstancia.Consulta)
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

#End Region
#End Region

#Region " Metodos "
	
#End Region

End Class

