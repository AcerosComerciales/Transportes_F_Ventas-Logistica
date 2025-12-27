Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DABAS_OrdenesCompra

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   ''' <summary> 
   ''' Capa de Datos: LOG_ORDCOSS_TodosOrdenes
   ''' </summary>
   ''' <param name="x_zonas_codigo">Parametro 1: </param> 
   ''' <param name="x_sucur_id">Parametro 2: </param> 
   ''' <param name="x_cadena">Parametro 3: </param> 
   ''' <param name="x_opcion">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <param name="x_fecini">Parametro 6: </param> 
   ''' <param name="x_fecfin">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_ORDCOSS_TodosOrdenes(ByVal m_listabas_ordenescompra As List(Of EABAS_OrdenesCompra), ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_ORDCOSS_TodosOrdenes")
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _abas_ordenescompra As New EABAS_OrdenesCompra()
                  ACEsquemas.ACCargarEsquema(reader, _abas_ordenescompra)
                  _abas_ordenescompra.Instanciar(ACEInstancia.Consulta)
                  m_listabas_ordenescompra.Add(_abas_ordenescompra)
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
   ''' Capa de Datos: LOG_ABASSS_ConsultaOrdenes
   ''' </summary>
   ''' <param name="x_cadena">Parametro 1: </param> 
   ''' <param name="x_opciontc">Parametro 2: </param> 
   ''' <param name="x_todos">Parametro 3: </param> 
   ''' <param name="x_fecini">Parametro 4: </param> 
   ''' <param name="x_fecfin">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_ABASSS_ConsultaOrdenes(ByVal m_listabas_ordenescompra As List(Of EABAS_OrdenesCompra), ByVal x_cadena As String, ByVal x_opciontc As Short, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_ABASSS_ConsultaOrdenes")
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@OpcionTC", x_opciontc, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _abas_ordenescompra As New EABAS_OrdenesCompra()
                  ACEsquemas.ACCargarEsquema(reader, _abas_ordenescompra)
                  _abas_ordenescompra.Instanciar(ACEInstancia.Consulta)
                  m_listabas_ordenescompra.Add(_abas_ordenescompra)
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
   ''' Metodo para generar el correlativo
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCorrelativo() As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectCorr(), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("Codigo"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "
   ''' <summary>
   ''' metodo para generar la sentencia SQL que obtendra el correlativo
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function getSelectCorr() As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" SELECT IsNull(Max(ORDCO_Id), 0) As Codigo FROM Logistica.ABAS_OrdenesCompra {0}", vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region


End Class

