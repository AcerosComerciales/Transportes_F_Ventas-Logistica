Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica
Imports ACEVentas

Public Class DControlDescuentos

#Region " Variables "
   Private m_formatofecha As String
#End Region

#Region " Constructores "
   Public Sub New()
      m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
   End Sub
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function BusquedaProveedor(ByRef x_list As List(Of EEntidades), ByVal x_tipocosteo As String, ByVal x_cadena As String, ByVal x_campo As String _
                                   , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelect(x_tipocosteo, x_fecini, x_fecfin, x_campo, x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EEntidades())
               While reader.Read()
                  Dim e_entidades As New EEntidades()
                  _utilitarios.ACCargarEsquemas(reader, e_entidades)
                  e_entidades.Instanciar(ACEInstancia.Consulta)
                  x_list.Add(e_entidades)
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

   Public Function ObtenerDetalle(ByRef x_list As List(Of EABAS_DocsCompraDetalle), ByVal x_tipocosteo As String, ByVal x_entid_codigo As String _
                                , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelect(x_tipocosteo, x_fecini, x_fecfin, x_entid_codigo), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EABAS_DocsCompraDetalle())
               While reader.Read()
                  Dim e_detdocs As New EABAS_DocsCompraDetalle()
                  _utilitarios.ACCargarEsquemas(reader, e_detdocs)
                  e_detdocs.Instanciar(ACEInstancia.Consulta)
                  x_list.Add(e_detdocs)
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
   Private Function getSelect(ByVal x_tipocosteo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                            , ByVal x_campo As String, ByVal x_cadena As String)
      Dim sql As String = ""
      Try
         App.Inicializar()
         Dim _fecini As String = x_fecini.ToString(m_formatofecha)
         Dim _fecfin As String = x_fecfin.ToString(m_formatofecha)
         sql = String.Format(App.Hash("DControlDescuentos.BusquedaProveedor").ToString(), New String() {x_tipocosteo, x_campo, x_cadena, _fecini, _fecfin})
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelect(ByVal x_tipocosteo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByVal x_entid_codigo As String)
      Dim sql As String = ""
      Try
         App.Inicializar()
         Dim _fecini As String = x_fecini.ToString(m_formatofecha)
         Dim _fecfin As String = x_fecfin.ToString(m_formatofecha)
         sql = String.Format(App.Hash("DControlDescuentos.ObtenerDetalle").ToString(), New String() {x_tipocosteo, x_entid_codigo, _fecini, _fecfin})
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

