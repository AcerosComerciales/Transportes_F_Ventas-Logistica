Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTipos

#Region " Variables "
	
	Private m_tipos As ETipos
	Private m_listTipos As List(Of ETipos)
	Private m_dtTipos As DataTable

	Private m_dsTipos As DataSet
	Private d_tipos As DTipos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tipos = New DTipos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Tipos() As ETipos 
		Get
			return m_tipos
		End Get
		Set(ByVal value As ETipos)
			m_tipos = value
		End Set
	End Property
	Public Property ListTipos() As List(Of ETipos)
		Get
			return m_listTipos
		End Get
		Set(ByVal value As List(Of ETipos))
			m_listTipos = value
		End Set
	End Property
	Public Property DTTipos() As DataTable
		Get
			return m_dtTipos
		End Get
		Set(ByVal value As DataTable)
			m_dtTipos = value
		End Set
	End Property
	Public Property DSTipos() As DataSet
		Get
			return m_dsTipos
		End Get
		Set(ByVal value As DataSet)
			m_dsTipos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTipos() As List(Of ETipos)
			Return Me.m_listTipos
		End Function
		Public Sub setListTipos(ByVal _listtipos As List (Of ETipos))
			Me.m_listTipos = m_listtipos 
		End Sub
		Public Function getTipos() As ETipos
			Return Me.m_tipos
		End Function
		Public Sub setTipos(ByVal x_tipos As ETipos)
			Me.m_tipos = x_tipos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTipos = new List(Of ETipos)()
			return d_tipos.TIPOSSS_Todos(m_listTipos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTipos = new List(Of ETipos)()
			return d_tipos.TIPOSSS_Todos(m_listTipos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTipos = new List(Of ETipos)()
			return d_tipos.TIPOSSS_Todos(m_listTipos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTipos = new List(Of ETipos)()
			return d_tipos.TIPOSSS_Todos(m_listTipos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTipos = new DataSet()
			return d_tipos.TIPOSSS_Todos(m_dsTipos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTipos = new DataSet()
			return d_tipos.TIPOSSS_Todos(m_dsTipos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTipos = new DataSet()
			Dim _opcion As Boolean = d_tipos.TIPOSSS_Todos(m_dsTipos, x_where)
		If _opcion Then
			m_dtTipos = m_dsTipos.Tables(0)
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
			m_dsTipos = new DataSet()
			Dim _opcion As Boolean = d_tipos.TIPOSSS_Todos(m_dsTipos, x_join, x_where)
		If _opcion Then
			m_dtTipos = m_dsTipos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_tipos_codigo As String) As Boolean
		Try
			m_tipos = New ETipos()
			Return d_tipos.TIPOSSS_UnReg(m_tipos, x_tipos_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tipos = New ETipos()
			Return d_tipos.TIPOSSS_UnReg(m_tipos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tipos = New ETipos()
			Return d_tipos.TIPOSSS_UnReg(m_tipos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tipos.Nuevo Then
				d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario)
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
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tipos.Nuevo Then
				d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario)
			ElseIf m_tipos.Modificado Then
				d_tipos.TIPOSSU_UnReg(m_tipos, x_where, x_usuario)
			ElseIf m_tipos.Eliminado Then
				d_tipos.TIPOSSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tipos.Nuevo Then
				d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tipos.Modificado Then
				d_tipos.TIPOSSU_UnReg(m_tipos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tipos.Eliminado Then
				d_tipos.TIPOSSD_UnReg(m_tipos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tipos.Nuevo Then
				d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tipos.Modificado Then
				d_tipos.TIPOSSU_UnReg(m_tipos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tipos.Eliminado Then
				d_tipos.TIPOSSD_UnReg(m_tipos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tipos.Nuevo Then
				d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario, x_setfecha)
			ElseIf m_tipos.Modificado Then
				d_tipos.TIPOSSU_UnReg(m_tipos, x_usuario, x_setfecha)
			ElseIf m_tipos.Eliminado Then
				d_tipos.TIPOSSD_UnReg(m_tipos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tipos.Nuevo Then
				d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tipos.Eliminado Then
				d_tipos.TIPOSSD_UnReg(m_tipos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTipos = new List(Of ETipos)()
			return d_tipos.TIPOSSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tipos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tipos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tipos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tipos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

