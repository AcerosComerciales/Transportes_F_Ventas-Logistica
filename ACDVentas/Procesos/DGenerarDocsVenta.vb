Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DGenerarDocsVenta


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function getNumero(ByVal x_docve_serie As String, ByVal x_tipos_codtipodocumento As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_docve_serie, x_tipos_codtipodocumento), CommandType.Text)
        'DAEnterprise.AsignarProcedure(getSelectAll_N(x_tipos_codtipodocumento), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("Numero"), Integer)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
   Public Function getNumeroNC(ByVal x_docve_serie As String, ByVal x_tipos_codtipodocumento As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectAll_N(x_docve_serie, x_tipos_codtipodocumento), CommandType.Text)
        Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("Numero"), Integer)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: CAJASS_ObtenerDeuda
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function CAJASS_ObtenerDeuda(ByVal x_vent_docsventa As EVENT_DocsVenta, ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("CAJASS_ObtenerDeuda")
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_vent_docsventa)
               x_vent_docsventa.Instanciar(ACEInstancia.Consulta)
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
   
   Public Function CAJASS_ObtenerDeudaReg(ByRef m_datos As DataTable, ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_fecfin As Date) As Boolean
      Try
            DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadrePendientesCliente")
         DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Orden", 0, DbType.Int16, 1)

         m_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return True

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CAJASS_ExcedenPlazo(ByVal m_listvcuadrependientes As List(Of ECCuadrePendientes), ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_fecfin As Date) As Boolean
      Try
            DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreExcedePlazoCliente")
         DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Orden", 0, DbType.Int16, 1)


         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vcuadrependientes As New ECCuadrePendientes()
                  ACEsquemas.ACCargarEsquema(reader, _vcuadrependientes)
                  _vcuadrependientes.Instanciar(ACEInstancia.Consulta)
                  m_listvcuadrependientes.Add(_vcuadrependientes)
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
    ''' Capa de Datos: VENT_Alm_ObtDetDocVenta
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_Alm_ObtDetDocVenta(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_Alm_ObtDetDocVenta")
            DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
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
    ''' Capa de Datos: VENT_Alm_ObtDetDocVenta
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <param name="x_artic_codigo">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_ObtenerEntregasAlmacenDetalle(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_docve_codigo As String,  ByVal x_artic_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_ObtenerEntregasAlmacenDetalle")
            DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo,  DbType.String, 7)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
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
   Private Function getSelectAll(ByVal x_docve_serie As String, ByVal x_tipos_codtipodocumento As String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" Select IsNull(Max(DOCVE_Numero), 0) As Numero from Ventas.VENT_DocsVenta ", vbNewLine)
         sql &= String.Format(" Where DOCVE_Serie = '{0}' And TIPOS_CodTipoDocumento = '{1}'{2}", x_docve_serie, x_tipos_codtipodocumento, vbNewLine)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     Private Function getSelectAll_N(ByVal x_docve_serie As String,ByVal x_tipos_codtipodocumento As String) As String
      Dim sql As String = ""
      Try
          sql &= String.Format(" Select IsNull(Max(DOCVE_Numero), 0) As Numero from Ventas.VENT_DocsVenta ", vbNewLine)
         sql &= String.Format(" Where (DOCVE_Serie = '{0}' OR DOCVE_Serie='{1}') AND TIPOS_CodTipoDocumento = '{2}'{3}","F"+Right(x_docve_serie,3),"B"+Right(x_docve_serie,3),  x_tipos_codtipodocumento, vbNewLine)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

#Region " Metodos "
	
#End Region


End Class

