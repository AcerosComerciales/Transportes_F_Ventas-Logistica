Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

'r
Imports System.Data.SqlClient

Partial Public Class DCTRL_InventarioRotativo

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   ''' <summary> 
   ''' Capa de Datos: CTRLSS_InventarioRotativo
   ''' </summary>
   ''' <param name="x_perio_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_articulo">Parametro 4: </param> 
   ''' <param name="x_linea">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function CTRLSS_InventarioRotativo(ByRef m_listarticulos As List(Of ACEVentas.EArticulos), ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String, ByVal x_articulo As String, ByVal x_linea As String) As Boolean
      Try
            DAEnterprise.AsignarProcedure("CTRLSS_InventarioRotativo")
         DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@Articulo", x_articulo, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Linea", x_linea, DbType.String, 10)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _articulos As New ACEVentas.EArticulos()
                  ACEsquemas.ACCargarEsquema(reader, _articulos)
                  _articulos.Instanciar(ACEInstancia.Consulta)
                  m_listarticulos.Add(_articulos)
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
   ''' Capa de Datos: CTRLSS_PendientesOrdenes
   ''' </summary>
   ''' <param name="x_fecfin">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_linea">Parametro 3: </param> 
   ''' <returns></returns> 
    ''' <remarks></remarks> 

    Public Function CTRLSS_PendientesOrdenes(ByRef m_listvent_docsventadetalle As List(Of ACEVentas.EVENT_DocsVentaDetalle), ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
        Try

            DAEnterprise.AsignarProcedure("CTRLSS_PendientesOrdenes")
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Linea", x_linea, DbType.String, 10)

            DAEnterprise.CommandTimeOut = 0

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New ACEVentas.EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
   ''' Capa de Datos: CTRLSS_PendientesVentas
   ''' </summary>
   ''' <param name="x_fecfin">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_linea">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function CTRLSS_PendientesVentas(ByRef m_listvent_docsventadetalle As List(Of ACEVentas.EVENT_DocsVentaDetalle), ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("CTRLSS_PendientesVentas")
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Linea", x_linea, DbType.String, 10)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventadetalle As New ACEVentas.EVENT_DocsVentaDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                  _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
   ''' Capa de Datos: CTRLSS_PedidoReposicion
   ''' </summary>
   ''' <param name="x_fecfin">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_linea">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function CTRLSS_PedidoReposicion(ByRef m_listvent_docsventadetalle As List(Of ACEVentas.EVENT_DocsVentaDetalle), ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("CTRLSS_PedidoReposicion")
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Linea", x_linea, DbType.String, 10)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New ACEVentas.EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
   ''' Capa de Datos: CTRLSS_CompraSinConfirmar
   ''' </summary>
   ''' <param name="x_fecfin">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_linea">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function CTRLSS_CompraSinConfirmar(ByRef m_listvent_docsventadetalle As List(Of ACEVentas.EVENT_DocsVentaDetalle), ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("CTRLSS_CompraSinConfirmar")
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Linea", x_linea, DbType.String, 10)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventadetalle As New ACEVentas.EVENT_DocsVentaDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                  _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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

