Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Imports ACFramework

Public Class BEntidadRelacion


#Region " Variables "
   Private m_entid_razonsocial As String
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         m_entid_razonsocial = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "

   ''' <summary>
   ''' cargar relacionados
   ''' </summary>
   ''' <param name="x_entid_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarRelacionados(ByVal x_entid_codigo As String) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodRelacion")} _
                              , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoRelacion")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoRelacion")}))
         Dim _where As New Hashtable()
         _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el numero correltivo de la entidad
   ''' </summary>
   ''' <param name="x_entid_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetNumero(ByVal x_entid_codigo As String) As Integer
      Try
         Return (d_entidadrelacion.GetNumero(x_entid_codigo) + 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

