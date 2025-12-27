Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTESO_Recibos

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   ''' <summary> 
   ''' Capa de Datos: TESO_ConsultaRecibos
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_cadena">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TESO_ConsultaRecibos(ByVal m_listteso_recibos As List(Of ETESO_Recibos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_cadena As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TESO_ConsultaRecibos")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _teso_recibos As New ETESO_Recibos()
                  ACEsquemas.ACCargarEsquema(reader, _teso_recibos)
                  _teso_recibos.Instanciar(ACEInstancia.Consulta)
                  m_listteso_recibos.Add(_teso_recibos)
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
    ''' Capa de Datos: TESO_ObtenerRecibo
    ''' </summary>
    ''' <param name="x_recib_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function TESO_ObtenerRecibo(ByRef m_tran_recibos As ETESO_Recibos, ByVal x_recib_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_ObtenerRecibo")
            DAEnterprise.AgregarParametro("@RECIB_Codigo", x_recib_codigo, DbType.String, 14)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    m_tran_recibos = New ETESO_Recibos()
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

#End Region
#End Region

#Region " Metodos "
	
#End Region

End Class

