Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTESO_Sencillo

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   ''' <summary> 
   ''' Capa de Datos: TESO_SENCISS_UnReg
   ''' </summary>
   ''' <param name="x_senci_fecha">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TESO_SENCISS_UnReg(ByVal x_teso_sencillo As ETESO_Sencillo, ByVal x_senci_fecha As Date, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TESO_SENCISS_UnReg")
         DAEnterprise.AgregarParametro("@SENCI_Fecha", x_senci_fecha, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_teso_sencillo)
               x_teso_sencillo.Instanciar(ACEInstancia.Consulta)
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

   Public Function getFecha() As DateTime
      Dim x_datos As New DataTable()
      Try
         DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Dim _fecha As DateTime = x_datos.Rows(0)(0)
         Return _fecha
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: TESO_SENCISS_VerificarIngreso
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TESO_SENCISS_VerificarIngreso(ByVal x_teso_sencillo As ETESO_Sencillo, ByVal x_fecini As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TESO_SENCISS_VerificarIngreso")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_teso_sencillo)
               x_teso_sencillo.Instanciar(ACEInstancia.Consulta)
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
    ''' Capa de Datos: TESO_ConsultaSencillo
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_cadena">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_todos">Parametro 5: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function TESO_ConsultaSencillo(ByVal m_listteso_sencillo As List(Of ETESO_Sencillo), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_todos As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_ConsultaSencillo")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)

            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _teso_sencillo As New ETESO_Sencillo()
                        ACEsquemas.ACCargarEsquema(reader, _teso_sencillo)
                        _teso_sencillo.Instanciar(ACEInstancia.Consulta)
                        m_listteso_sencillo.Add(_teso_sencillo)
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
	
#End Region

End Class

