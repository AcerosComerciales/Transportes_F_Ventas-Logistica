Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_OrdenesCompra

#Region " Variables "
	
	Private m_eabas_ordenescompra As EABAS_OrdenesCompra
	Private m_listABAS_OrdenesCompra As List(Of EABAS_OrdenesCompra)
	Private m_dtABAS_OrdenesCompra As DataTable

	Private m_dsABAS_OrdenesCompra As DataSet
	Private d_abas_ordenescompra As DABAS_OrdenesCompra 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_ordenescompra = New DABAS_OrdenesCompra()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_OrdenesCompra() As EABAS_OrdenesCompra 
		Get
			return m_eabas_ordenescompra
		End Get
		Set(ByVal value As EABAS_OrdenesCompra)
			m_eabas_ordenescompra = value
		End Set
	End Property

	Public Property ListABAS_OrdenesCompra() As List(Of EABAS_OrdenesCompra)
		Get
			return m_listABAS_OrdenesCompra
		End Get
		Set(ByVal value As List(Of EABAS_OrdenesCompra))
			m_listABAS_OrdenesCompra = value
		End Set
	End Property

	Public Property DTABAS_OrdenesCompra() As DataTable
		Get
			return m_dtABAS_OrdenesCompra
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_OrdenesCompra = value
		End Set
	End Property

	Public Property DSABAS_OrdenesCompra() As DataSet
		Get
			return m_dsABAS_OrdenesCompra
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_OrdenesCompra = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_OrdenesCompra = new List(Of EABAS_OrdenesCompra)()
			return d_abas_ordenescompra.ABAS_ORDCOSS_Todos(m_listABAS_OrdenesCompra)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_OrdenesCompra = new List(Of EABAS_OrdenesCompra)()
			return d_abas_ordenescompra.ABAS_ORDCOSS_Todos(m_listABAS_OrdenesCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_OrdenesCompra = new List(Of EABAS_OrdenesCompra)()
			return d_abas_ordenescompra.ABAS_ORDCOSS_Todos(m_listABAS_OrdenesCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_OrdenesCompra = new List(Of EABAS_OrdenesCompra)()
			return d_abas_ordenescompra.ABAS_ORDCOSS_Todos(m_listABAS_OrdenesCompra, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_OrdenesCompra = new DataSet()
			return d_abas_ordenescompra.ABAS_ORDCOSS_Todos(m_dsABAS_OrdenesCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_OrdenesCompra = new DataSet()
			return d_abas_ordenescompra.ABAS_ORDCOSS_Todos(m_dsABAS_OrdenesCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_OrdenesCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_ordenescompra.ABAS_ORDCOSS_Todos(m_dsABAS_OrdenesCompra, x_where)
		If _opcion Then
			m_dtABAS_OrdenesCompra = m_dsABAS_OrdenesCompra.Tables(0)
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
			m_dsABAS_OrdenesCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_ordenescompra.ABAS_ORDCOSS_Todos(m_dsABAS_OrdenesCompra, x_join, x_where)
		If _opcion Then
			m_dtABAS_OrdenesCompra = m_dsABAS_OrdenesCompra.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_ordco_codigo As String) As Boolean
		Try
			m_eabas_ordenescompra = New EABAS_OrdenesCompra()
			Return d_abas_ordenescompra.ABAS_ORDCOSS_UnReg(m_eabas_ordenescompra, x_ordco_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_ordenescompra = New EABAS_OrdenesCompra()
			Return d_abas_ordenescompra.ABAS_ORDCOSS_UnReg(m_eabas_ordenescompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_ordenescompra = New EABAS_OrdenesCompra()
			Return d_abas_ordenescompra.ABAS_ORDCOSS_UnReg(m_eabas_ordenescompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_ordenescompra.Nuevo Then
				d_abas_ordenescompra.ABAS_ORDCOSI_UnReg(m_eabas_ordenescompra, x_usuario)
			ElseIf m_eabas_ordenescompra.Modificado Then
				d_abas_ordenescompra.ABAS_ORDCOSU_UnReg(m_eabas_ordenescompra, x_usuario)
			ElseIf m_eabas_ordenescompra.Eliminado Then
				d_abas_ordenescompra.ABAS_ORDCOSD_UnReg(ABAS_OrdenesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_ordenescompra.Nuevo Then
				d_abas_ordenescompra.ABAS_ORDCOSI_UnReg(m_eabas_ordenescompra, x_usuario)
			ElseIf m_eabas_ordenescompra.Modificado Then
				d_abas_ordenescompra.ABAS_ORDCOSU_UnReg(m_eabas_ordenescompra, x_where, x_usuario)
			ElseIf m_eabas_ordenescompra.Eliminado Then
				d_abas_ordenescompra.ABAS_ORDCOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_ordenescompra.Nuevo Then
				d_abas_ordenescompra.ABAS_ORDCOSI_UnReg(m_eabas_ordenescompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ordenescompra.Modificado Then
				d_abas_ordenescompra.ABAS_ORDCOSU_UnReg(m_eabas_ordenescompra, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ordenescompra.Eliminado Then
				d_abas_ordenescompra.ABAS_ORDCOSD_UnReg(ABAS_OrdenesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eabas_ordenescompra.Nuevo Then
				d_abas_ordenescompra.ABAS_ORDCOSI_UnReg(m_eabas_ordenescompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ordenescompra.Modificado Then
				d_abas_ordenescompra.ABAS_ORDCOSU_UnReg(m_eabas_ordenescompra, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eabas_ordenescompra.Eliminado Then
				d_abas_ordenescompra.ABAS_ORDCOSD_UnReg(ABAS_OrdenesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_ordenescompra.Nuevo Then
				d_abas_ordenescompra.ABAS_ORDCOSI_UnReg(m_eabas_ordenescompra, x_usuario, x_setfecha)
			ElseIf m_eabas_ordenescompra.Modificado Then
				d_abas_ordenescompra.ABAS_ORDCOSU_UnReg(m_eabas_ordenescompra, x_usuario, x_setfecha)
			ElseIf m_eabas_ordenescompra.Eliminado Then
				d_abas_ordenescompra.ABAS_ORDCOSD_UnReg(ABAS_OrdenesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_ordenescompra.Nuevo Then
				d_abas_ordenescompra.ABAS_ORDCOSI_UnReg(m_eabas_ordenescompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ordenescompra.Eliminado Then
				d_abas_ordenescompra.ABAS_ORDCOSD_UnReg(ABAS_OrdenesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_OrdenesCompra = new List(Of EABAS_OrdenesCompra)()
			return d_abas_ordenescompra.ABAS_ORDCOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_ordenescompra.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_ordenescompra.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_ordenescompra.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_ordenescompra.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

