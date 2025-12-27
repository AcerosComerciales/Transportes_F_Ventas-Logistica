Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports ACFramework
Imports System.Configuration

Public Class BReportes

#Region " Variables "



#End Region

#Region " Constructores "



#End Region

#Region " Propiedades "


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   'Public Function reporteVentas(ByVal x_fecini As DateTime, ByVal x_fin As DateTime) As Boolean
   '   Try
   '      Dim _join As New List(Of ACJoin)
   '      _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, ACJoin.TipoJoin.Inner _
   '                           , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoCliente")} _
   '                           , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente") _
   '                                            , New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
   '      _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TMon", ACJoin.TipoJoin.Inner _
   '                           , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
   '                           , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))
   '      _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
   '                           , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
   '                           , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))
   '      Dim _where As New Hashtable
   '      _where.Add("DOCVE_FechaDocumento", New ACWhere(x_fecini, x_fin, ACWhere.TipoWhere.Between))
   '      _where.Add("DOCVE_Estado", New ACWhere("X", ACWhere.TipoWhere.Diferente))

   '      Dim _bvent_docsventa As New BVENT_DocsVenta
   '      If _bvent_docsventa.CargarTodos(_join, _where) Then
   '         m_listDocsVentas = New List(Of EVENT_DocsVenta)(_bvent_docsventa.ListVENT_DocsVenta)
   '         Return True
   '      End If
   '      Return False
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function




#End Region

End Class

