Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration

Public Class BEntidadesRoles


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
   ''' cargar roles de usuario
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function cargarTodos(ByVal x_entid_codigo As String) As Boolean
      Try
         m_listEntidadesRoles = New List(Of EEntidadesRoles)
         d_entidadesroles.ENTISS_Todos(m_listEntidadesRoles, x_entid_codigo)
         Return m_listEntidadesRoles.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

