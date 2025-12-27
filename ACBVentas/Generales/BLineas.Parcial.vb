Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BLineas

#Region " Variables "
	
	Private m_lineas As ELineas
	Private m_listLineas As List(Of ELineas)
	Private m_dtLineas As DataTable

	Private m_dsLineas As DataSet
	Private d_lineas As DLineas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_lineas = New DLineas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Lineas() As ELineas 
		Get
			return m_lineas
		End Get
		Set(ByVal value As ELineas)
			m_lineas = value
		End Set
	End Property
	Public Property ListLineas() As List(Of ELineas)
		Get
			return m_listLineas
		End Get
		Set(ByVal value As List(Of ELineas))
			m_listLineas = value
		End Set
	End Property
	Public Property DTLineas() As DataTable
		Get
			return m_dtLineas
		End Get
		Set(ByVal value As DataTable)
			m_dtLineas = value
		End Set
	End Property
	Public Property DSLineas() As DataSet
		Get
			return m_dsLineas
		End Get
		Set(ByVal value As DataSet)
			m_dsLineas = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListLineas() As List(Of ELineas)
			Return Me.m_listLineas
		End Function
		Public Sub setListLineas(ByVal _listlineas As List (Of ELineas))
			Me.m_listLineas = m_listlineas 
		End Sub
		Public Function getLineas() As ELineas
			Return Me.m_lineas
		End Function
		Public Sub setLineas(ByVal x_lineas As ELineas)
			Me.m_lineas = x_lineas 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listLineas = new List(Of ELineas)()
			return d_lineas.LINEASS_Todos(m_listLineas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listLineas = new List(Of ELineas)()
			return d_lineas.LINEASS_Todos(m_listLineas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listLineas = new List(Of ELineas)()
			return d_lineas.LINEASS_Todos(m_listLineas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listLineas = new List(Of ELineas)()
			return d_lineas.LINEASS_Todos(m_listLineas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsLineas = new DataSet()
			return d_lineas.LINEASS_Todos(m_dsLineas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsLineas = new DataSet()
			return d_lineas.LINEASS_Todos(m_dsLineas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsLineas = new DataSet()
			Dim _opcion As Boolean = d_lineas.LINEASS_Todos(m_dsLineas, x_where)
		If _opcion Then
			m_dtLineas = m_dsLineas.Tables(0)
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
			m_dsLineas = new DataSet()
			Dim _opcion As Boolean = d_lineas.LINEASS_Todos(m_dsLineas, x_join, x_where)
		If _opcion Then
			m_dtLineas = m_dsLineas.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_linea_codigo As String) As Boolean
		Try
			m_lineas = New ELineas()
			Return d_lineas.LINEASS_UnReg(m_lineas, x_linea_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_lineas = New ELineas()
			Return d_lineas.LINEASS_UnReg(m_lineas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_lineas = New ELineas()
			Return d_lineas.LINEASS_UnReg(m_lineas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_lineas.Nuevo Then
				d_lineas.LINEASI_UnReg(m_lineas, x_usuario)
			ElseIf m_lineas.Modificado Then
				d_lineas.LINEASU_UnReg(m_lineas, x_usuario)
			ElseIf m_lineas.Eliminado Then
				d_lineas.LINEASD_UnReg(m_lineas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_lineas.Nuevo Then
				d_lineas.LINEASI_UnReg(m_lineas, x_usuario)
			ElseIf m_lineas.Modificado Then
				d_lineas.LINEASU_UnReg(m_lineas, x_where, x_usuario)
			ElseIf m_lineas.Eliminado Then
				d_lineas.LINEASD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_lineas.Nuevo Then
				d_lineas.LINEASI_UnReg(m_lineas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_lineas.Modificado Then
				d_lineas.LINEASU_UnReg(m_lineas, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_lineas.Eliminado Then
				d_lineas.LINEASD_UnReg(m_lineas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_lineas.Nuevo Then
				d_lineas.LINEASI_UnReg(m_lineas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_lineas.Modificado Then
				d_lineas.LINEASU_UnReg(m_lineas, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_lineas.Eliminado Then
				d_lineas.LINEASD_UnReg(m_lineas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_lineas.Nuevo Then
				d_lineas.LINEASI_UnReg(m_lineas, x_usuario, x_setfecha)
			ElseIf m_lineas.Modificado Then
				d_lineas.LINEASU_UnReg(m_lineas, x_usuario, x_setfecha)
			ElseIf m_lineas.Eliminado Then
				d_lineas.LINEASD_UnReg(m_lineas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_lineas.Nuevo Then
				d_lineas.LINEASI_UnReg(m_lineas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_lineas.Eliminado Then
				d_lineas.LINEASD_UnReg(m_lineas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listLineas = new List(Of ELineas)()
			return d_lineas.LINEASD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_lineas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_lineas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_lineas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_lineas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

