Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DABAS_CotizacionesCompra

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	


#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "

   ''' <summary>
   ''' Metodo para generar el correlativo desde la capa de datos
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCodCorrelativo(ByVal x_tipo As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectCorr(x_tipo), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("Codigo"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: LOG_COTCOSS_TodosCotizaciones
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
   Public Function LOG_COTCOSS_TodosCotizaciones(ByVal m_listabas_cotizacionescompra As List(Of EABAS_CotizacionesCompra), ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_COTCOSS_TodosCotizaciones")
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
                  Dim _abas_cotizacionescompra As New EABAS_CotizacionesCompra()
                  ACEsquemas.ACCargarEsquema(reader, _abas_cotizacionescompra)
                  _abas_cotizacionescompra.Instanciar(ACEInstancia.Consulta)
                  m_listabas_cotizacionescompra.Add(_abas_cotizacionescompra)
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
   ''' <summary>
   ''' procedimiento que construye la sentencia SQL
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function getSelectCorr(ByVal x_tipo As String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" SELECT IsNull(Max(COTCO_Numero), 0) As Codigo FROM Logistica.ABAS_CotizacionesCompra Where Left(COTCO_Codigo, 2) = '{0}' {1}", x_tipo, vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region


End Class

