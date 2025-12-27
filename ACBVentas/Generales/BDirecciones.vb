Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration

Imports ACFramework

Public Class BDirecciones

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "

   ''' <summary>
   ''' cargar todas las direcciones de una entidad
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de la entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarTodosDirecciones(ByVal x_entid_codigo As String) As Boolean
      Try
         m_listDirecciones = New List(Of EDirecciones)()
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EUbigeos.Esquema, EUbigeos.Tabla, ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("UBIGO_Codigo", "UBIGO_Codigo")} _
                              , New ACCampos() {New ACCampos("UBIGO_Descripcion", "UBIGO_Descripcion")}))
         Dim _where As New Hashtable()
         _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' carhar ayuda de las direcciones
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de la entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarAyuda(ByVal x_entid_codigo As String) As Boolean
      Try
         m_dtDirecciones = New DataTable()
         Dim _where As New Hashtable()
         _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
         Return d_direcciones.DIRECS_TodosAyuda(m_dtDirecciones, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el ide de la direccion de una entidad
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de la entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getIdDireccion(ByVal x_entid_codigo As String) As Short
      Try
         Return d_direcciones.getIdDireccion(x_entid_codigo) + 1
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

