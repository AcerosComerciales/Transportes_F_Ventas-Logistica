Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DABAS_DocsCompra

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "

   ''' <summary> 
   ''' Capa de Datos: LOG_DOCCOSS_TodosDocCompra
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
   Public Function LOG_DOCCOSS_TodosDocCompra(ByVal m_listabas_docscompra As List(Of EABAS_DocsCompra), ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DOCCOSS_TodosDocCompra")
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
                  Dim _abas_docscompra As New EABAS_DocsCompra()
                  ACEsquemas.ACCargarEsquema(reader, _abas_docscompra)
                  _abas_docscompra.Instanciar(ACEInstancia.Consulta)
                  m_listabas_docscompra.Add(_abas_docscompra)
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
   ''' Capa de Datos: LOG_ABASSS_ConsultaCompras
   ''' </summary>
   ''' <param name="x_cadena">Parametro 1: </param> 
   ''' <param name="x_opciontc">Parametro 2: </param> 
   ''' <param name="x_todos">Parametro 3: </param> 
   ''' <param name="x_fecini">Parametro 4: </param> 
   ''' <param name="x_fecfin">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_ABASSS_ConsultaCompras(ByVal m_listabas_docscompra As List(Of EABAS_DocsCompra), ByVal x_cadena As String, ByVal x_opciontc As Short, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_ABASSS_ConsultaCompras")
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@OpcionTC", x_opciontc, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _abas_docscompra As New EABAS_DocsCompra()
                  ACEsquemas.ACCargarEsquema(reader, _abas_docscompra)
                  _abas_docscompra.Instanciar(ACEInstancia.Consulta)
                  m_listabas_docscompra.Add(_abas_docscompra)
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
   ''' Capa de Datos: COSTESS_ObtenerDocCosteados
   ''' </summary>
   ''' <param name="x_entid_codigoproveedor">Parametro 1: </param> 
   ''' <param name="x_docco_codigo">Parametro 2: </param> 
   ''' <param name="x_detalle">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function COSTESS_ObtenerDocCosteados(ByRef m_abas_docscompra As EABAS_DocsCompra, _
                                               ByVal x_entid_codigoproveedor As String, ByVal x_docco_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("COSTESS_ObtenerDocCosteados")
         DAEnterprise.AgregarParametro("@ENTID_CodigoProveedor", x_entid_codigoproveedor, DbType.String, 14)
         DAEnterprise.AgregarParametro("@DOCCO_Codigo", x_docco_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@Detalle", x_detalle, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, m_abas_docscompra)
               m_abas_docscompra.Instanciar(ACEInstancia.Consulta)
               m_abas_docscompra.ListEABAS_DocsCompraDetalle = New List(Of EABAS_DocsCompraDetalle)
               If x_detalle Then
                  If reader.NextResult() Then
                     While reader.Read()
                        Dim e_doccodet As New EABAS_DocsCompraDetalle()
                        ACEsquemas.ACCargarEsquema(reader, e_doccodet)
                        e_doccodet.Instanciar(ACEInstancia.Consulta)
                        m_abas_docscompra.ListEABAS_DocsCompraDetalle.Add(e_doccodet)
                     End While
                  End If
               End If
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

