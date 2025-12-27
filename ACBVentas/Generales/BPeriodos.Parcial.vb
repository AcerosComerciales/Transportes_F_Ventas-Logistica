Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BPeriodos

#Region " Variables "
	
	Private m_periodos As EPeriodos
	Private m_listPeriodos As List(Of EPeriodos)
	Private m_dtPeriodos As DataTable

	Private m_dsPeriodos As DataSet
	Private d_periodos As DPeriodos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_periodos = New DPeriodos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Periodos() As EPeriodos 
		Get
			return m_periodos
		End Get
		Set(ByVal value As EPeriodos)
			m_periodos = value
		End Set
	End Property
	Public Property ListPeriodos() As List(Of EPeriodos)
		Get
			return m_listPeriodos
		End Get
		Set(ByVal value As List(Of EPeriodos))
			m_listPeriodos = value
		End Set
	End Property
	Public Property DTPeriodos() As DataTable
		Get
			return m_dtPeriodos
		End Get
		Set(ByVal value As DataTable)
			m_dtPeriodos = value
		End Set
	End Property
	Public Property DSPeriodos() As DataSet
		Get
			return m_dsPeriodos
		End Get
		Set(ByVal value As DataSet)
			m_dsPeriodos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListPeriodos() As List(Of EPeriodos)
			Return Me.m_listPeriodos
		End Function
		Public Sub setListPeriodos(ByVal _listperiodos As List (Of EPeriodos))
			Me.m_listPeriodos = m_listperiodos 
		End Sub
		Public Function getPeriodos() As EPeriodos
			Return Me.m_periodos
		End Function
		Public Sub setPeriodos(ByVal x_periodos As EPeriodos)
			Me.m_periodos = x_periodos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listPeriodos = new List(Of EPeriodos)()
			return d_periodos.PERIOSS_Todos(m_listPeriodos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listPeriodos = new List(Of EPeriodos)()
			return d_periodos.PERIOSS_Todos(m_listPeriodos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listPeriodos = new List(Of EPeriodos)()
			return d_periodos.PERIOSS_Todos(m_listPeriodos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listPeriodos = new List(Of EPeriodos)()
			return d_periodos.PERIOSS_Todos(m_listPeriodos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsPeriodos = new DataSet()
			return d_periodos.PERIOSS_Todos(m_dsPeriodos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsPeriodos = new DataSet()
			return d_periodos.PERIOSS_Todos(m_dsPeriodos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsPeriodos = new DataSet()
			Dim _opcion As Boolean = d_periodos.PERIOSS_Todos(m_dsPeriodos, x_where)
		If _opcion Then
			m_dtPeriodos = m_dsPeriodos.Tables(0)
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
			m_dsPeriodos = new DataSet()
			Dim _opcion As Boolean = d_periodos.PERIOSS_Todos(m_dsPeriodos, x_join, x_where)
		If _opcion Then
			m_dtPeriodos = m_dsPeriodos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_perio_codigo As String) As Boolean
		Try
			m_periodos = New EPeriodos()
			Return d_periodos.PERIOSS_UnReg(m_periodos, x_perio_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_periodos = New EPeriodos()
			Return d_periodos.PERIOSS_UnReg(m_periodos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_periodos = New EPeriodos()
			Return d_periodos.PERIOSS_UnReg(m_periodos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_periodos.Nuevo Then
				d_periodos.PERIOSI_UnReg(m_periodos, x_usuario)
			ElseIf m_periodos.Modificado Then
				d_periodos.PERIOSU_UnReg(m_periodos, x_usuario)
			ElseIf m_periodos.Eliminado Then
				d_periodos.PERIOSD_UnReg(m_periodos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_periodos.Nuevo Then
				d_periodos.PERIOSI_UnReg(m_periodos, x_usuario)
			ElseIf m_periodos.Modificado Then
				d_periodos.PERIOSU_UnReg(m_periodos, x_where, x_usuario)
			ElseIf m_periodos.Eliminado Then
				d_periodos.PERIOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_periodos.Nuevo Then
				d_periodos.PERIOSI_UnReg(m_periodos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_periodos.Modificado Then
				d_periodos.PERIOSU_UnReg(m_periodos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_periodos.Eliminado Then
				d_periodos.PERIOSD_UnReg(m_periodos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_periodos.Nuevo Then
				d_periodos.PERIOSI_UnReg(m_periodos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_periodos.Modificado Then
				d_periodos.PERIOSU_UnReg(m_periodos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_periodos.Eliminado Then
				d_periodos.PERIOSD_UnReg(m_periodos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_periodos.Nuevo Then
				d_periodos.PERIOSI_UnReg(m_periodos, x_usuario, x_setfecha)
			ElseIf m_periodos.Modificado Then
				d_periodos.PERIOSU_UnReg(m_periodos, x_usuario, x_setfecha)
			ElseIf m_periodos.Eliminado Then
				d_periodos.PERIOSD_UnReg(m_periodos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_periodos.Nuevo Then
				d_periodos.PERIOSI_UnReg(m_periodos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_periodos.Eliminado Then
				d_periodos.PERIOSD_UnReg(m_periodos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listPeriodos = new List(Of EPeriodos)()
			return d_periodos.PERIOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_periodos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_periodos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_periodos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_periodos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

