Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BColor

#Region " Variables "
	
	Private m_color As EColor
	Private m_listColor As List(Of EColor)
	Private m_dtColor As DataTable

	Private m_dsColor As DataSet
	Private d_color As DColor 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_color = New DColor()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Color() As EColor 
		Get
			return m_color
		End Get
		Set(ByVal value As EColor)
			m_color = value
		End Set
	End Property
	Public Property ListColor() As List(Of EColor)
		Get
			return m_listColor
		End Get
		Set(ByVal value As List(Of EColor))
			m_listColor = value
		End Set
	End Property
	Public Property DTColor() As DataTable
		Get
			return m_dtColor
		End Get
		Set(ByVal value As DataTable)
			m_dtColor = value
		End Set
	End Property
	Public Property DSColor() As DataSet
		Get
			return m_dsColor
		End Get
		Set(ByVal value As DataSet)
			m_dsColor = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListColor() As List(Of EColor)
			Return Me.m_listColor
		End Function
		Public Sub setListColor(ByVal _listcolor As List (Of EColor))
			Me.m_listColor = m_listcolor 
		End Sub
		Public Function getColor() As EColor
			Return Me.m_color
		End Function
		Public Sub setColor(ByVal x_color As EColor)
			Me.m_color = x_color 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listColor = new List(Of EColor)()
			return d_color.COLORSS_Todos(m_listColor)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listColor = new List(Of EColor)()
			return d_color.COLORSS_Todos(m_listColor, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listColor = new List(Of EColor)()
			return d_color.COLORSS_Todos(m_listColor, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listColor = new List(Of EColor)()
			return d_color.COLORSS_Todos(m_listColor, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsColor = new DataSet()
			return d_color.COLORSS_Todos(m_dsColor, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsColor = new DataSet()
			return d_color.COLORSS_Todos(m_dsColor, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsColor = new DataSet()
			Dim _opcion As Boolean = d_color.COLORSS_Todos(m_dsColor, x_where)
		If _opcion Then
			m_dtColor = m_dsColor.Tables(0)
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
			m_dsColor = new DataSet()
			Dim _opcion As Boolean = d_color.COLORSS_Todos(m_dsColor, x_join, x_where)
		If _opcion Then
			m_dtColor = m_dsColor.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_color_id As Integer) As Boolean
		Try
			m_color = New EColor()
			Return d_color.COLORSS_UnReg(m_color, x_color_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_color = New EColor()
			Return d_color.COLORSS_UnReg(m_color, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_color = New EColor()
			Return d_color.COLORSS_UnReg(m_color, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_color.Nuevo Then
				d_color.COLORSI_UnReg(m_color, x_usuario)
			ElseIf m_color.Modificado Then
				d_color.COLORSU_UnReg(m_color, x_usuario)
			ElseIf m_color.Eliminado Then
				d_color.COLORSD_UnReg(m_color)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_color.Nuevo Then
				d_color.COLORSI_UnReg(m_color, x_usuario)
			ElseIf m_color.Modificado Then
				d_color.COLORSU_UnReg(m_color, x_where, x_usuario)
			ElseIf m_color.Eliminado Then
				d_color.COLORSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_color.Nuevo Then
				d_color.COLORSI_UnReg(m_color, x_usuario, x_excluir, x_setfecha)
			ElseIf m_color.Modificado Then
				d_color.COLORSU_UnReg(m_color, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_color.Eliminado Then
				d_color.COLORSD_UnReg(m_color)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_color.Nuevo Then
				d_color.COLORSI_UnReg(m_color, x_usuario, x_excluir, x_setfecha)
			ElseIf m_color.Modificado Then
				d_color.COLORSU_UnReg(m_color, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_color.Eliminado Then
				d_color.COLORSD_UnReg(m_color)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_color.Nuevo Then
				d_color.COLORSI_UnReg(m_color, x_usuario, x_setfecha)
			ElseIf m_color.Modificado Then
				d_color.COLORSU_UnReg(m_color, x_usuario, x_setfecha)
			ElseIf m_color.Eliminado Then
				d_color.COLORSD_UnReg(m_color)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_color.Nuevo Then
				d_color.COLORSI_UnReg(m_color, x_usuario, x_excluir, x_setfecha)
			ElseIf m_color.Eliminado Then
				d_color.COLORSD_UnReg(m_color)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listColor = new List(Of EColor)()
			return d_color.COLORSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_color.getCorrelativo("COLOR_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_color.getCorrelativo("COLOR_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_color.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_color.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_color.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_color.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

