Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTESO_DocsPagos


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function getAyuda(ByRef x_datos As DataSet, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_where), CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet()
         Return x_datos.Tables(0).Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getAyuda(ByRef x_datos As DataSet, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TESO_DOCPGSS_Ayuda")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
         x_datos = DAEnterprise.ExecuteDataSet()
         Return x_datos.Tables(0).Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
    End Function
     Public Function getAyudaNC(ByRef x_datos As DataSet, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_entid_codigoDoc As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_DOCPGSS_AyudaNotaCredito")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ENTID_CodigoDoc", x_entid_codigoDoc, DbType.String, 15)
            x_datos = DAEnterprise.ExecuteDataSet()
            Return x_datos.Tables(0).Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary> 
   ''' Capa de Datos: TESO_DPAGSS_ObtenerDocPagos
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_opcion">Parametro 3: </param> 
   ''' <param name="x_cadena">Parametro 4: </param> 
   ''' <param name="x_optfecha">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
    Public Function TESO_DPAGSS_ObtenerDocPagos(ByVal m_listteso_docspagos As List(Of ETESO_DocsPagos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_optfecha As Short) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_DPAGSS_ObtenerDocPagos")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@OptFecha", x_optfecha, DbType.Int16, 2)

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _teso_docspagos As New ETESO_DocsPagos()
                        ACEsquemas.ACCargarEsquema(reader, _teso_docspagos)
                        _teso_docspagos.Instanciar(ACEInstancia.Consulta)
                        m_listteso_docspagos.Add(_teso_docspagos)
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
   ''' Capa de Datos: TESO_DOCPSS_ConsutaNotaCredito
   ''' </summary>
   ''' <param name="x_tipodoc">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <param name="x_opcion">Parametro 3: </param> 
   ''' <param name="x_cadena">Parametro 4: </param> 
   ''' <param name="x_fecini">Parametro 5: </param> 
   ''' <param name="x_fecfin">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TESO_DOCPSS_ConsutaNotaCredito(ByVal m_listteso_docspagos As List(Of ETESO_DocsPagos), ByVal x_tipodoc As String, ByVal x_pvent_id As Long, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TESO_DOCPSS_ConsutaNotaCredito")
         DAEnterprise.AgregarParametro("@TipoDoc", x_tipodoc, DbType.String, 6)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _teso_docspagos As New ETESO_DocsPagos()
                  ACEsquemas.ACCargarEsquema(reader, _teso_docspagos)
                  _teso_docspagos.Instanciar(ACEInstancia.Consulta)
                  m_listteso_docspagos.Add(_teso_docspagos)
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
    ''' Capa de Datos: obtener depositos
    ''' </summary>
    ''' <param name="x_dpago_numero">Parametro 1: </param> 
    ''' <param name="x_banco_id">Parametro 2: </param> 
    ''' <param name="x_cuenta_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ObtenerDepositos(ByVal x_dpago_numero As String, ByVal x_banco_id As Integer, ByVal x_cuenta_id As Integer) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_VerificarDeposito")
            DAEnterprise.AgregarParametro("@DPAGO_Numero", x_dpago_numero, DbType.String, 15)
            DAEnterprise.AgregarParametro("@BANCO_Id", x_banco_id, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@CUENT_Id", x_cuenta_id, DbType.Int16, 2)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

                If reader.HasRows Then
                    While reader.Read()
                        Return True
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Procedimientos Adicionales "
   Private Function getSelectAyuda(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= App.Hash("IDGenerarCancelacion.getAyuda")
         Dim _where As New ACGenerador(Of ETESO_DocsPagos)(m_formatofecha)
         sql = String.Format(sql, _where.getWhere(x_where, True))
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Datos: VENT_DOCVESS_GetDocsPago
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_DOCVESS_GetDocsPago(ByVal m_listteso_docspagos As List(Of ETESO_DocsPagos), ByVal x_docve_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_DOCVESS_GetDocsPago")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 15)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _teso_docspagos As New ETESO_DocsPagos()
                  ACEsquemas.ACCargarEsquema(reader, _teso_docspagos)
                  _teso_docspagos.Instanciar(ACEInstancia.Consulta)
                  m_listteso_docspagos.Add(_teso_docspagos)
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

