Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_ListaPreciosCompra

#Region " Variables "
	
	Private m_abas_listaprecioscompra As EABAS_ListaPreciosCompra
	Private m_listABAS_ListaPreciosCompra As List(Of EABAS_ListaPreciosCompra)
	Private m_dtABAS_ListaPreciosCompra As DataTable

	Private m_dsABAS_ListaPreciosCompra As DataSet
	Private d_abas_listaprecioscompra As DABAS_ListaPreciosCompra 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_listaprecioscompra = New DABAS_ListaPreciosCompra()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_ListaPreciosCompra() As EABAS_ListaPreciosCompra 
		Get
			return m_abas_listaprecioscompra
		End Get
		Set(ByVal value As EABAS_ListaPreciosCompra)
			m_abas_listaprecioscompra = value
		End Set
	End Property
	Public Property ListABAS_ListaPreciosCompra() As List(Of EABAS_ListaPreciosCompra)
		Get
			return m_listABAS_ListaPreciosCompra
		End Get
		Set(ByVal value As List(Of EABAS_ListaPreciosCompra))
			m_listABAS_ListaPreciosCompra = value
		End Set
	End Property
	Public Property DTABAS_ListaPreciosCompra() As DataTable
		Get
			return m_dtABAS_ListaPreciosCompra
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_ListaPreciosCompra = value
		End Set
	End Property
	Public Property DSABAS_ListaPreciosCompra() As DataSet
		Get
			return m_dsABAS_ListaPreciosCompra
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_ListaPreciosCompra = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListABAS_ListaPreciosCompra() As List(Of EABAS_ListaPreciosCompra)
			Return Me.m_listABAS_ListaPreciosCompra
		End Function
		Public Sub setListABAS_ListaPreciosCompra(ByVal _listabas_listaprecioscompra As List (Of EABAS_ListaPreciosCompra))
			Me.m_listABAS_ListaPreciosCompra = m_listabas_listaprecioscompra 
		End Sub
		Public Function getABAS_ListaPreciosCompra() As EABAS_ListaPreciosCompra
			Return Me.m_abas_listaprecioscompra
		End Function
		Public Sub setABAS_ListaPreciosCompra(ByVal x_abas_listaprecioscompra As EABAS_ListaPreciosCompra)
			Me.m_abas_listaprecioscompra = x_abas_listaprecioscompra 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_ListaPreciosCompra = new List(Of EABAS_ListaPreciosCompra)()
			return d_abas_listaprecioscompra.ABAS_LPRCOSS_Todos(m_listABAS_ListaPreciosCompra)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_ListaPreciosCompra = new List(Of EABAS_ListaPreciosCompra)()
			return d_abas_listaprecioscompra.ABAS_LPRCOSS_Todos(m_listABAS_ListaPreciosCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_ListaPreciosCompra = new List(Of EABAS_ListaPreciosCompra)()
			return d_abas_listaprecioscompra.ABAS_LPRCOSS_Todos(m_listABAS_ListaPreciosCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_ListaPreciosCompra = new List(Of EABAS_ListaPreciosCompra)()
			return d_abas_listaprecioscompra.ABAS_LPRCOSS_Todos(m_listABAS_ListaPreciosCompra, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_ListaPreciosCompra = new DataSet()
			return d_abas_listaprecioscompra.ABAS_LPRCOSS_Todos(m_dsABAS_ListaPreciosCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_ListaPreciosCompra = new DataSet()
			return d_abas_listaprecioscompra.ABAS_LPRCOSS_Todos(m_dsABAS_ListaPreciosCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_ListaPreciosCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_listaprecioscompra.ABAS_LPRCOSS_Todos(m_dsABAS_ListaPreciosCompra, x_where)
		If _opcion Then
			m_dtABAS_ListaPreciosCompra = m_dsABAS_ListaPreciosCompra.Tables(0)
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
			m_dsABAS_ListaPreciosCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_listaprecioscompra.ABAS_LPRCOSS_Todos(m_dsABAS_ListaPreciosCompra, x_join, x_where)
		If _opcion Then
			m_dtABAS_ListaPreciosCompra = m_dsABAS_ListaPreciosCompra.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_entid_codigo As String, x_artic_codigo As String, x_tipos_codtipomoneda As String) As Boolean
		Try
			m_abas_listaprecioscompra = New EABAS_ListaPreciosCompra()
			Return d_abas_listaprecioscompra.ABAS_LPRCOSS_UnReg(m_abas_listaprecioscompra, x_entid_codigo, x_artic_codigo, x_tipos_codtipomoneda)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_abas_listaprecioscompra = New EABAS_ListaPreciosCompra()
			Return d_abas_listaprecioscompra.ABAS_LPRCOSS_UnReg(m_abas_listaprecioscompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_abas_listaprecioscompra = New EABAS_ListaPreciosCompra()
			Return d_abas_listaprecioscompra.ABAS_LPRCOSS_UnReg(m_abas_listaprecioscompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_abas_listaprecioscompra.Nuevo Then
				d_abas_listaprecioscompra.ABAS_LPRCOSI_UnReg(m_abas_listaprecioscompra, x_usuario)
			ElseIf m_abas_listaprecioscompra.Modificado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSU_UnReg(m_abas_listaprecioscompra, x_usuario)
			ElseIf m_abas_listaprecioscompra.Eliminado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSD_UnReg(m_abas_listaprecioscompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_abas_listaprecioscompra.Nuevo Then
				d_abas_listaprecioscompra.ABAS_LPRCOSI_UnReg(m_abas_listaprecioscompra, x_usuario)
			ElseIf m_abas_listaprecioscompra.Modificado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSU_UnReg(m_abas_listaprecioscompra, x_where, x_usuario)
			ElseIf m_abas_listaprecioscompra.Eliminado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_listaprecioscompra.Nuevo Then
				d_abas_listaprecioscompra.ABAS_LPRCOSI_UnReg(m_abas_listaprecioscompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_listaprecioscompra.Modificado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSU_UnReg(m_abas_listaprecioscompra, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_listaprecioscompra.Eliminado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSD_UnReg(m_abas_listaprecioscompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_abas_listaprecioscompra.Nuevo Then
				d_abas_listaprecioscompra.ABAS_LPRCOSI_UnReg(m_abas_listaprecioscompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_listaprecioscompra.Modificado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSU_UnReg(m_abas_listaprecioscompra, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_abas_listaprecioscompra.Eliminado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSD_UnReg(m_abas_listaprecioscompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_listaprecioscompra.Nuevo Then
				d_abas_listaprecioscompra.ABAS_LPRCOSI_UnReg(m_abas_listaprecioscompra, x_usuario, x_setfecha)
			ElseIf m_abas_listaprecioscompra.Modificado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSU_UnReg(m_abas_listaprecioscompra, x_usuario, x_setfecha)
			ElseIf m_abas_listaprecioscompra.Eliminado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSD_UnReg(m_abas_listaprecioscompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_listaprecioscompra.Nuevo Then
				d_abas_listaprecioscompra.ABAS_LPRCOSI_UnReg(m_abas_listaprecioscompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_listaprecioscompra.Eliminado Then
				d_abas_listaprecioscompra.ABAS_LPRCOSD_UnReg(m_abas_listaprecioscompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_ListaPreciosCompra = new List(Of EABAS_ListaPreciosCompra)()
			return d_abas_listaprecioscompra.ABAS_LPRCOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_listaprecioscompra.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_listaprecioscompra.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_listaprecioscompra.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_listaprecioscompra.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

