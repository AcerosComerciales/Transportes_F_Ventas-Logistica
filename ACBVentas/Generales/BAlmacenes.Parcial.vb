Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BAlmacenes

#Region " Variables "
	
	Private m_almacenes As EAlmacenes
	Private m_listAlmacenes As List(Of EAlmacenes)
	Private m_dtAlmacenes As DataTable

	Private m_dsAlmacenes As DataSet
	Private d_almacenes As DAlmacenes 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_almacenes = New DAlmacenes()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Almacenes() As EAlmacenes 
		Get
			return m_almacenes
		End Get
		Set(ByVal value As EAlmacenes)
			m_almacenes = value
		End Set
	End Property
	Public Property ListAlmacenes() As List(Of EAlmacenes)
		Get
			return m_listAlmacenes
		End Get
		Set(ByVal value As List(Of EAlmacenes))
			m_listAlmacenes = value
		End Set
	End Property
	Public Property DTAlmacenes() As DataTable
		Get
			return m_dtAlmacenes
		End Get
		Set(ByVal value As DataTable)
			m_dtAlmacenes = value
		End Set
	End Property
	Public Property DSAlmacenes() As DataSet
		Get
			return m_dsAlmacenes
		End Get
		Set(ByVal value As DataSet)
			m_dsAlmacenes = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListAlmacenes() As List(Of EAlmacenes)
			Return Me.m_listAlmacenes
		End Function
		Public Sub setListAlmacenes(ByVal _listalmacenes As List (Of EAlmacenes))
			Me.m_listAlmacenes = m_listalmacenes 
		End Sub
		Public Function getAlmacenes() As EAlmacenes
			Return Me.m_almacenes
		End Function
		Public Sub setAlmacenes(ByVal x_almacenes As EAlmacenes)
			Me.m_almacenes = x_almacenes 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listAlmacenes = new List(Of EAlmacenes)()
			return d_almacenes.ALMACSS_Todos(m_listAlmacenes)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listAlmacenes = new List(Of EAlmacenes)()
			return d_almacenes.ALMACSS_Todos(m_listAlmacenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listAlmacenes = new List(Of EAlmacenes)()
			return d_almacenes.ALMACSS_Todos(m_listAlmacenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listAlmacenes = new List(Of EAlmacenes)()
			return d_almacenes.ALMACSS_Todos(m_listAlmacenes, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsAlmacenes = new DataSet()
			return d_almacenes.ALMACSS_Todos(m_dsAlmacenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsAlmacenes = new DataSet()
			return d_almacenes.ALMACSS_Todos(m_dsAlmacenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsAlmacenes = new DataSet()
			Dim _opcion As Boolean = d_almacenes.ALMACSS_Todos(m_dsAlmacenes, x_where)
		If _opcion Then
			m_dtAlmacenes = m_dsAlmacenes.Tables(0)
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
			m_dsAlmacenes = new DataSet()
			Dim _opcion As Boolean = d_almacenes.ALMACSS_Todos(m_dsAlmacenes, x_join, x_where)
		If _opcion Then
			m_dtAlmacenes = m_dsAlmacenes.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_almac_id As Short) As Boolean
		Try
			m_almacenes = New EAlmacenes()
			Return d_almacenes.ALMACSS_UnReg(m_almacenes, x_almac_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_almacenes = New EAlmacenes()
			Return d_almacenes.ALMACSS_UnReg(m_almacenes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_almacenes = New EAlmacenes()
			Return d_almacenes.ALMACSS_UnReg(m_almacenes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_almacenes.Nuevo Then
				d_almacenes.ALMACSI_UnReg(m_almacenes, x_usuario)
			ElseIf m_almacenes.Modificado Then
				d_almacenes.ALMACSU_UnReg(m_almacenes, x_usuario)
			ElseIf m_almacenes.Eliminado Then
				d_almacenes.ALMACSD_UnReg(m_almacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_almacenes.Nuevo Then
				d_almacenes.ALMACSI_UnReg(m_almacenes, x_usuario)
			ElseIf m_almacenes.Modificado Then
				d_almacenes.ALMACSU_UnReg(m_almacenes, x_where, x_usuario)
			ElseIf m_almacenes.Eliminado Then
				d_almacenes.ALMACSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_almacenes.Nuevo Then
				d_almacenes.ALMACSI_UnReg(m_almacenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_almacenes.Modificado Then
				d_almacenes.ALMACSU_UnReg(m_almacenes, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_almacenes.Eliminado Then
				d_almacenes.ALMACSD_UnReg(m_almacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_almacenes.Nuevo Then
				d_almacenes.ALMACSI_UnReg(m_almacenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_almacenes.Modificado Then
				d_almacenes.ALMACSU_UnReg(m_almacenes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_almacenes.Eliminado Then
				d_almacenes.ALMACSD_UnReg(m_almacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_almacenes.Nuevo Then
				d_almacenes.ALMACSI_UnReg(m_almacenes, x_usuario, x_setfecha)
			ElseIf m_almacenes.Modificado Then
				d_almacenes.ALMACSU_UnReg(m_almacenes, x_usuario, x_setfecha)
			ElseIf m_almacenes.Eliminado Then
				d_almacenes.ALMACSD_UnReg(m_almacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_almacenes.Nuevo Then
				d_almacenes.ALMACSI_UnReg(m_almacenes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_almacenes.Eliminado Then
				d_almacenes.ALMACSD_UnReg(m_almacenes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listAlmacenes = new List(Of EAlmacenes)()
			return d_almacenes.ALMACSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_almacenes.getCorrelativo("ALMAC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_almacenes.getCorrelativo("ALMAC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_almacenes.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_almacenes.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_almacenes.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_almacenes.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

