Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BDIST_GuiasRemision

#Region " Variables "
	
	Private m_edist_guiasremision As EDIST_GuiasRemision
	Private m_listDIST_GuiasRemision As List(Of EDIST_GuiasRemision)
	Private m_dtDIST_GuiasRemision As DataTable

	Private m_dsDIST_GuiasRemision As DataSet
	Private d_dist_guiasremision As DDIST_GuiasRemision 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_dist_guiasremision = New DDIST_GuiasRemision()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property DIST_GuiasRemision() As EDIST_GuiasRemision 
		Get
			return m_edist_guiasremision
		End Get
		Set(ByVal value As EDIST_GuiasRemision)
			m_edist_guiasremision = value
		End Set
	End Property

	Public Property ListDIST_GuiasRemision() As List(Of EDIST_GuiasRemision)
		Get
			return m_listDIST_GuiasRemision
		End Get
		Set(ByVal value As List(Of EDIST_GuiasRemision))
			m_listDIST_GuiasRemision = value
		End Set
	End Property

	Public Property DTDIST_GuiasRemision() As DataTable
		Get
			return m_dtDIST_GuiasRemision
		End Get
		Set(ByVal value As DataTable)
			m_dtDIST_GuiasRemision = value
		End Set
	End Property

	Public Property DSDIST_GuiasRemision() As DataSet
		Get
			return m_dsDIST_GuiasRemision
		End Get
		Set(ByVal value As DataSet)
			m_dsDIST_GuiasRemision = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "

   ''' <summary>
   ''' cargar todod los docuementos
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
	Public Function CargarTodos() As Boolean
		Try
			m_listDIST_GuiasRemision = new List(Of EDIST_GuiasRemision)()
			return d_dist_guiasremision.DIST_GUIARSS_Todos(m_listDIST_GuiasRemision)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

   ''' <summary>
   ''' cargar documentos segun condicion
   ''' </summary>
   ''' <param name="x_where">condicion para la carga de datos</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_GuiasRemision = new List(Of EDIST_GuiasRemision)()
			return d_dist_guiasremision.DIST_GUIARSS_Todos(m_listDIST_GuiasRemision, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

   ''' <summary>
   ''' Cargar datos segun carga y listado de join
   ''' </summary>
   ''' <param name="x_join">join</param>
   ''' <param name="x_where">condicionales</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_GuiasRemision = new List(Of EDIST_GuiasRemision)()
			return d_dist_guiasremision.DIST_GUIARSS_Todos(m_listDIST_GuiasRemision, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

   ''' <summary>
   ''' Cargar guias de remision
   ''' </summary>
   ''' <param name="x_join">joins</param>
   ''' <param name="x_where">condiciones</param>
   ''' <param name="x_distinct"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listDIST_GuiasRemision = new List(Of EDIST_GuiasRemision)()
			return d_dist_guiasremision.DIST_GUIARSS_Todos(m_listDIST_GuiasRemision, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_GuiasRemision = new DataSet()
			return d_dist_guiasremision.DIST_GUIARSS_Todos(m_dsDIST_GuiasRemision, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_GuiasRemision = new DataSet()
			return d_dist_guiasremision.DIST_GUIARSS_Todos(m_dsDIST_GuiasRemision, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_GuiasRemision = new DataSet()
			Dim _opcion As Boolean = d_dist_guiasremision.DIST_GUIARSS_Todos(m_dsDIST_GuiasRemision, x_where)
		If _opcion Then
			m_dtDIST_GuiasRemision = m_dsDIST_GuiasRemision.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_GuiasRemision = new DataSet()
			Dim _opcion As Boolean = d_dist_guiasremision.DIST_GUIARSS_Todos(m_dsDIST_GuiasRemision, x_join, x_where)
		If _opcion Then
			m_dtDIST_GuiasRemision = m_dsDIST_GuiasRemision.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_guiar_codigo As String) As Boolean
		Try
			m_edist_guiasremision = New EDIST_GuiasRemision()
			Return d_dist_guiasremision.DIST_GUIARSS_UnReg(m_edist_guiasremision, x_guiar_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_guiasremision = New EDIST_GuiasRemision()
			Return d_dist_guiasremision.DIST_GUIARSS_UnReg(m_edist_guiasremision, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_guiasremision = New EDIST_GuiasRemision()
			Return d_dist_guiasremision.DIST_GUIARSS_UnReg(m_edist_guiasremision, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_edist_guiasremision.Nuevo Then
				d_dist_guiasremision.DIST_GUIARSI_UnReg(m_edist_guiasremision, x_usuario)
			ElseIf m_edist_guiasremision.Modificado Then
				d_dist_guiasremision.DIST_GUIARSU_UnReg(m_edist_guiasremision, x_usuario)
			ElseIf m_edist_guiasremision.Eliminado Then
				d_dist_guiasremision.DIST_GUIARSD_UnReg(DIST_GuiasRemision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_edist_guiasremision.Nuevo Then
				d_dist_guiasremision.DIST_GUIARSI_UnReg(m_edist_guiasremision, x_usuario)
			ElseIf m_edist_guiasremision.Modificado Then
				d_dist_guiasremision.DIST_GUIARSU_UnReg(m_edist_guiasremision, x_where, x_usuario)
			ElseIf m_edist_guiasremision.Eliminado Then
				d_dist_guiasremision.DIST_GUIARSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_guiasremision.Nuevo Then
				d_dist_guiasremision.DIST_GUIARSI_UnReg(m_edist_guiasremision, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_guiasremision.Modificado Then
				d_dist_guiasremision.DIST_GUIARSU_UnReg(m_edist_guiasremision, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_guiasremision.Eliminado Then
				d_dist_guiasremision.DIST_GUIARSD_UnReg(DIST_GuiasRemision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_edist_guiasremision.Nuevo Then
				d_dist_guiasremision.DIST_GUIARSI_UnReg(m_edist_guiasremision, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_guiasremision.Modificado Then
				d_dist_guiasremision.DIST_GUIARSU_UnReg(m_edist_guiasremision, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_edist_guiasremision.Eliminado Then
				d_dist_guiasremision.DIST_GUIARSD_UnReg(DIST_GuiasRemision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_guiasremision.Nuevo Then
				d_dist_guiasremision.DIST_GUIARSI_UnReg(m_edist_guiasremision, x_usuario, x_setfecha)
			ElseIf m_edist_guiasremision.Modificado Then
				d_dist_guiasremision.DIST_GUIARSU_UnReg(m_edist_guiasremision, x_usuario, x_setfecha)
			ElseIf m_edist_guiasremision.Eliminado Then
				d_dist_guiasremision.DIST_GUIARSD_UnReg(DIST_GuiasRemision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_guiasremision.Nuevo Then
				d_dist_guiasremision.DIST_GUIARSI_UnReg(m_edist_guiasremision, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_guiasremision.Eliminado Then
				d_dist_guiasremision.DIST_GUIARSD_UnReg(DIST_GuiasRemision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_GuiasRemision = new List(Of EDIST_GuiasRemision)()
			return d_dist_guiasremision.DIST_GUIARSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_dist_guiasremision.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_dist_guiasremision.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_dist_guiasremision.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_dist_guiasremision.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

