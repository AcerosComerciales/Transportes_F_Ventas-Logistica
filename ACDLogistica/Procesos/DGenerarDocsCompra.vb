Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Public Class DGenerarDocsCompra

#Region " Variables "
   Private m_formatofecha As String
#End Region

#Region " Constructores "
   Public Sub New()
      m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
   End Sub
#End Region

#Region " Procedimientos Almacenados "
   Public Function BusquedaDocsGenNota(ByRef listEABAS_OrdenesCompra As List(Of EABAS_OrdenesCompra), ByVal Esquema As String, ByVal Tabla As String, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectOrden(Esquema, Tabla, x_join, x_where), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EABAS_OrdenesCompra())
               While reader.Read()
                  Dim e_abas_docscompra As New EABAS_OrdenesCompra()
                  _utilitarios.ACCargarEsquemas(reader, e_abas_docscompra)
                  e_abas_docscompra.Instanciar(ACEInstancia.Consulta)
                  listEABAS_OrdenesCompra.Add(e_abas_docscompra)
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

   Public Function cargarDetDifOrden(ByRef x_list As List(Of EABAS_DocsCompraDetalle), ByVal x_ordco_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectOrden(x_ordco_codigo), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EABAS_DocsCompraDetalle())
               While reader.Read()
                  Dim e_abas_doccompradetalle As New EABAS_DocsCompraDetalle()
                  _utilitarios.ACCargarEsquemas(reader, e_abas_doccompradetalle)
                  e_abas_doccompradetalle.Instanciar(ACEInstancia.Consulta)
                  x_list.Add(e_abas_doccompradetalle)
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
   Private Function getSelectOrden(ByVal Esquema As String, ByVal Tabla As String, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         Dim _join As New ACGenerador(Of EABAS_OrdenesCompra)(m_formatofecha)
         sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

         App.Inicializar()
         sql &= String.Format(App.Hash("DGenerarDocsCompra.BusquedaDocsRegCompraOrden").ToString())
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectOrden(ByVal x_ordco_codigo As String) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql = String.Format(App.Hash("DGenerarDocsCompra.cargarDetDifOrden").ToString(), x_ordco_codigo)
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

