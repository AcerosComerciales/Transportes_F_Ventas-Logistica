Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports ACFramework
Imports DAConexion
Imports ACBVentas
Imports ACEVentas

Public Class BDocumentos

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As String) As Boolean
      Dim d_documentos As New DDocumentos()
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin("dbo", "Tipos", "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CODTIPODOCUMENTO")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPO_DOCUMENTO")}))
         Dim _where As New Hashtable()
         _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         m_listDocumentos = New List(Of EDocumentos)()
         Return d_documentos.DOCMTSS_Todos(m_listDocumentos, _join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Guardar(ByVal x_usuario As String, ByVal x_ano As String, ByVal x_detalle As Boolean, Optional ByVal x_tran As Boolean = True) As Boolean
      Try
         If x_detalle Then
            Dim d_documentos As New DDocumentos()
            If m_documentos.Nuevo Then
               If x_tran Then DAEnterprise.BeginTransaction()
               Dim b_correlativo As New BCorrelativos()
               Try
                  b_correlativo.getCorrelativo(m_documentos.SUCUR_Id, ECorrelativos.NTabla.Documentos, x_ano)
                  m_documentos.DOCMT_Nro = b_correlativo.Correlativos.Codigo
                  m_documentos.DOCMT_Id = getCorrelativo()
                  d_documentos.DOCMTSI_UnReg(m_documentos, x_usuario)
                  b_correlativo.SetCorrelativo(x_usuario)
                  If x_tran Then DAEnterprise.CommitTransaction()
               Catch ex As Exception
                  If x_tran Then DAEnterprise.RollBackTransaction()
                  Throw ex
               End Try
            ElseIf m_documentos.Modificado Then
               d_documentos.DOCMTSU_UnReg(m_documentos, x_usuario)
            ElseIf m_documentos.Eliminado Then
               d_documentos.DOCMTSD_UnReg(m_documentos)
            End If
            Return True
         Else
            Return Guardar(x_usuario)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function EliminarDocumento(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_tran As Boolean) As Boolean
      Dim b_tran_documentodetalle As New BTRAN_DocumentosDetalle
      Dim _where As New Hashtable
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
         _where.Add("DOCUS_Codigo", New ACWhere(x_docus_codigo))
         _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
         If b_tran_documentodetalle.Eliminar(_where) Then
            Eliminar(_where)
            If x_tran Then DAEnterprise.CommitTransaction()
            Return True
         End If
         Return False
      Catch ex As Exception
         If x_tran Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function
#End Region

End Class

