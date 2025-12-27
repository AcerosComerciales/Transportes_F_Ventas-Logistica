Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BArticulos

#Region " Variables "
	
	Private m_articulos As EArticulos
	Private m_listArticulos As List(Of EArticulos)
	Private m_dtArticulos As DataTable

	Private m_dsArticulos As DataSet
	Private d_articulos As DArticulos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_articulos = New DArticulos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Articulos() As EArticulos 
		Get
			return m_articulos
		End Get
		Set(ByVal value As EArticulos)
			m_articulos = value
		End Set
	End Property
	Public Property ListArticulos() As List(Of EArticulos)
		Get
			return m_listArticulos
		End Get
		Set(ByVal value As List(Of EArticulos))
			m_listArticulos = value
		End Set
	End Property
	Public Property DTArticulos() As DataTable
		Get
			return m_dtArticulos
		End Get
		Set(ByVal value As DataTable)
			m_dtArticulos = value
		End Set
	End Property
	Public Property DSArticulos() As DataSet
		Get
			return m_dsArticulos
		End Get
		Set(ByVal value As DataSet)
			m_dsArticulos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListArticulos() As List(Of EArticulos)
			Return Me.m_listArticulos
		End Function
		Public Sub setListArticulos(ByVal _listarticulos As List (Of EArticulos))
			Me.m_listArticulos = m_listarticulos 
		End Sub
		Public Function getArticulos() As EArticulos
			Return Me.m_articulos
		End Function
		Public Sub setArticulos(ByVal x_articulos As EArticulos)
			Me.m_articulos = x_articulos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listArticulos = new List(Of EArticulos)()
			return d_articulos.ARTICSS_Todos(m_listArticulos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listArticulos = new List(Of EArticulos)()
			return d_articulos.ARTICSS_Todos(m_listArticulos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listArticulos = new List(Of EArticulos)()
			return d_articulos.ARTICSS_Todos(m_listArticulos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listArticulos = new List(Of EArticulos)()
			return d_articulos.ARTICSS_Todos(m_listArticulos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsArticulos = new DataSet()
			return d_articulos.ARTICSS_Todos(m_dsArticulos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsArticulos = new DataSet()
			return d_articulos.ARTICSS_Todos(m_dsArticulos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsArticulos = new DataSet()
			Dim _opcion As Boolean = d_articulos.ARTICSS_Todos(m_dsArticulos, x_where)
		If _opcion Then
			m_dtArticulos = m_dsArticulos.Tables(0)
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
			m_dsArticulos = new DataSet()
			Dim _opcion As Boolean = d_articulos.ARTICSS_Todos(m_dsArticulos, x_join, x_where)
		If _opcion Then
			m_dtArticulos = m_dsArticulos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_artic_codigo As String) As Boolean
		Try
			m_articulos = New EArticulos()
			Return d_articulos.ARTICSS_UnReg(m_articulos, x_artic_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_articulos = New EArticulos()
			Return d_articulos.ARTICSS_UnReg(m_articulos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_articulos = New EArticulos()
			Return d_articulos.ARTICSS_UnReg(m_articulos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_articulos.Nuevo Then
				d_articulos.ARTICSI_UnReg(m_articulos, x_usuario)
			ElseIf m_articulos.Modificado Then
				d_articulos.ARTICSU_UnReg(m_articulos, x_usuario)
			ElseIf m_articulos.Eliminado Then
				d_articulos.ARTICSD_UnReg(m_articulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_articulos.Nuevo Then
				d_articulos.ARTICSI_UnReg(m_articulos, x_usuario)
			ElseIf m_articulos.Modificado Then
				d_articulos.ARTICSU_UnReg(m_articulos, x_where, x_usuario)
			ElseIf m_articulos.Eliminado Then
				d_articulos.ARTICSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_articulos.Nuevo Then
				d_articulos.ARTICSI_UnReg(m_articulos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_articulos.Modificado Then
				d_articulos.ARTICSU_UnReg(m_articulos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_articulos.Eliminado Then
				d_articulos.ARTICSD_UnReg(m_articulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_articulos.Nuevo Then
				d_articulos.ARTICSI_UnReg(m_articulos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_articulos.Modificado Then
				d_articulos.ARTICSU_UnReg(m_articulos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_articulos.Eliminado Then
				d_articulos.ARTICSD_UnReg(m_articulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_articulos.Nuevo Then
				d_articulos.ARTICSI_UnReg(m_articulos, x_usuario, x_setfecha)
			ElseIf m_articulos.Modificado Then
				d_articulos.ARTICSU_UnReg(m_articulos, x_usuario, x_setfecha)
			ElseIf m_articulos.Eliminado Then
				d_articulos.ARTICSD_UnReg(m_articulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_articulos.Nuevo Then
				d_articulos.ARTICSI_UnReg(m_articulos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_articulos.Eliminado Then
				d_articulos.ARTICSD_UnReg(m_articulos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listArticulos = new List(Of EArticulos)()
			return d_articulos.ARTICSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_articulos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_articulos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_articulos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_articulos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

