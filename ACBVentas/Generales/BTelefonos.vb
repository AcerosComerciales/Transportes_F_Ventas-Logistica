Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Public Class BTelefonos


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
   ''' cargar los telefonos de una entidad
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarTodos(ByVal x_entid_codigo As String) As Boolean
      Try
         m_listTelefonos = New List(Of ETelefonos)()
         Return d_telefonos.TELESS_Todos(m_listTelefonos, x_entid_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

