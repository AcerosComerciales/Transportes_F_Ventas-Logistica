Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_Costeos

#Region " Variables "
	
	Private m_abas_costeos As EABAS_Costeos
	Private m_listABAS_Costeos As List(Of EABAS_Costeos)
	Private m_dtABAS_Costeos As DataTable

	Private m_dsABAS_Costeos As DataSet
	Private d_abas_costeos As DABAS_Costeos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_costeos = New DABAS_Costeos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_Costeos() As EABAS_Costeos 
		Get
			return m_abas_costeos
		End Get
		Set(ByVal value As EABAS_Costeos)
			m_abas_costeos = value
		End Set
	End Property
	Public Property ListABAS_Costeos() As List(Of EABAS_Costeos)
		Get
			return m_listABAS_Costeos
		End Get
		Set(ByVal value As List(Of EABAS_Costeos))
			m_listABAS_Costeos = value
		End Set
	End Property
	Public Property DTABAS_Costeos() As DataTable
		Get
			return m_dtABAS_Costeos
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_Costeos = value
		End Set
	End Property
	Public Property DSABAS_Costeos() As DataSet
		Get
			return m_dsABAS_Costeos
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_Costeos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListABAS_Costeos() As List(Of EABAS_Costeos)
			Return Me.m_listABAS_Costeos
		End Function
		Public Sub setListABAS_Costeos(ByVal _listabas_costeos As List (Of EABAS_Costeos))
			Me.m_listABAS_Costeos = m_listabas_costeos 
		End Sub
		Public Function getABAS_Costeos() As EABAS_Costeos
			Return Me.m_abas_costeos
		End Function
		Public Sub setABAS_Costeos(ByVal x_abas_costeos As EABAS_Costeos)
			Me.m_abas_costeos = x_abas_costeos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_Costeos = new List(Of EABAS_Costeos)()
			return d_abas_costeos.ABAS_COSTESS_Todos(m_listABAS_Costeos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_Costeos = new List(Of EABAS_Costeos)()
			return d_abas_costeos.ABAS_COSTESS_Todos(m_listABAS_Costeos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_Costeos = new List(Of EABAS_Costeos)()
			return d_abas_costeos.ABAS_COSTESS_Todos(m_listABAS_Costeos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_Costeos = new List(Of EABAS_Costeos)()
			return d_abas_costeos.ABAS_COSTESS_Todos(m_listABAS_Costeos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_docco_codigo As String, ByVal x_entid_codigoproveedor As String, ByVal x_doccd_item As Short) As Boolean
		Try
			m_listABAS_Costeos = new List(Of EABAS_Costeos)()
			Return d_abas_costeos.ABAS_COSTESS_Todos(m_listABAS_Costeos, x_docco_codigo, x_entid_codigoproveedor, x_doccd_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_Costeos = new DataSet()
			return d_abas_costeos.ABAS_COSTESS_Todos(m_dsABAS_Costeos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_Costeos = new DataSet()
			return d_abas_costeos.ABAS_COSTESS_Todos(m_dsABAS_Costeos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_Costeos = new DataSet()
			Dim _opcion As Boolean = d_abas_costeos.ABAS_COSTESS_Todos(m_dsABAS_Costeos, x_where)
		If _opcion Then
			m_dtABAS_Costeos = m_dsABAS_Costeos.Tables(0)
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
			m_dsABAS_Costeos = new DataSet()
			Dim _opcion As Boolean = d_abas_costeos.ABAS_COSTESS_Todos(m_dsABAS_Costeos, x_join, x_where)
		If _opcion Then
			m_dtABAS_Costeos = m_dsABAS_Costeos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docco_codigo As String, x_entid_codigoproveedor As String, x_doccd_item As Short, x_coste_item As Short) As Boolean
		Try
			m_abas_costeos = New EABAS_Costeos()
			Return d_abas_costeos.ABAS_COSTESS_UnReg(m_abas_costeos, x_docco_codigo, x_entid_codigoproveedor, x_doccd_item, x_coste_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_abas_costeos = New EABAS_Costeos()
			Return d_abas_costeos.ABAS_COSTESS_UnReg(m_abas_costeos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_abas_costeos = New EABAS_Costeos()
			Return d_abas_costeos.ABAS_COSTESS_UnReg(m_abas_costeos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_abas_costeos.Nuevo Then
				d_abas_costeos.ABAS_COSTESI_UnReg(m_abas_costeos, x_usuario)
			ElseIf m_abas_costeos.Modificado Then
				d_abas_costeos.ABAS_COSTESU_UnReg(m_abas_costeos, x_usuario)
			ElseIf m_abas_costeos.Eliminado Then
				d_abas_costeos.ABAS_COSTESD_UnReg(m_abas_costeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_abas_costeos.Nuevo Then
				d_abas_costeos.ABAS_COSTESI_UnReg(m_abas_costeos, x_usuario)
			ElseIf m_abas_costeos.Modificado Then
				d_abas_costeos.ABAS_COSTESU_UnReg(m_abas_costeos, x_where, x_usuario)
			ElseIf m_abas_costeos.Eliminado Then
				d_abas_costeos.ABAS_COSTESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_costeos.Nuevo Then
				d_abas_costeos.ABAS_COSTESI_UnReg(m_abas_costeos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_costeos.Modificado Then
				d_abas_costeos.ABAS_COSTESU_UnReg(m_abas_costeos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_costeos.Eliminado Then
				d_abas_costeos.ABAS_COSTESD_UnReg(m_abas_costeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_abas_costeos.Nuevo Then
				d_abas_costeos.ABAS_COSTESI_UnReg(m_abas_costeos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_costeos.Modificado Then
				d_abas_costeos.ABAS_COSTESU_UnReg(m_abas_costeos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_abas_costeos.Eliminado Then
				d_abas_costeos.ABAS_COSTESD_UnReg(m_abas_costeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_costeos.Nuevo Then
				d_abas_costeos.ABAS_COSTESI_UnReg(m_abas_costeos, x_usuario, x_setfecha)
			ElseIf m_abas_costeos.Modificado Then
				d_abas_costeos.ABAS_COSTESU_UnReg(m_abas_costeos, x_usuario, x_setfecha)
			ElseIf m_abas_costeos.Eliminado Then
				d_abas_costeos.ABAS_COSTESD_UnReg(m_abas_costeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_costeos.Nuevo Then
				d_abas_costeos.ABAS_COSTESI_UnReg(m_abas_costeos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_costeos.Eliminado Then
				d_abas_costeos.ABAS_COSTESD_UnReg(m_abas_costeos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_Costeos = new List(Of EABAS_Costeos)()
			return d_abas_costeos.ABAS_COSTESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_costeos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_costeos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_costeos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_costeos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

