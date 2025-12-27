Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Public Class BTipos


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
   ''' cargar los tipos con todos los campos sin espacios
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarTodosTrim() As Boolean
      Try
         m_listTipos = New List(Of ETipos)()
         Return d_tipos.TIPOSSS_TodosTrim(m_listTipos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' busqueda de tipos
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_tipo_codigo">categoria del tipo que se esta buscando</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String, ByVal x_tipo_codigo As String) As Boolean
      Try
         m_listTipos = New List(Of ETipos)()
         Return d_tipos.TIPOSS_Todos(m_listTipos, x_cadena, x_tipo_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' guardar tipo usando un procedimiento almacenado
   ''' </summary>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GuardarSP(ByVal x_usuario As String) As Boolean
      Try
         If m_tipos.Nuevo Then
            d_tipos.TIPOSI_UnRegSP(m_tipos, x_usuario)
         ElseIf m_tipos.Modificado Then
            d_tipos.TIPOSSU_UnReg(m_tipos, x_usuario)
         ElseIf m_tipos.Eliminado Then
            d_tipos.TIPOSSD_UnReg(m_tipos)
         End If
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

