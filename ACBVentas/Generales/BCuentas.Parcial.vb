Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BCuentas

#Region " Variables "
	
	Private m_ecuentas As ECuentas
	Private m_listCuentas As List(Of ECuentas)
	Private m_dtCuentas As DataTable

	Private m_dsCuentas As DataSet
	Private d_cuentas As DCuentas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_cuentas = New DCuentas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Cuentas() As ECuentas 
		Get
			return m_ecuentas
		End Get
		Set(ByVal value As ECuentas)
			m_ecuentas = value
		End Set
	End Property

	Public Property ListCuentas() As List(Of ECuentas)
		Get
			return m_listCuentas
		End Get
		Set(ByVal value As List(Of ECuentas))
			m_listCuentas = value
		End Set
	End Property

	Public Property DTCuentas() As DataTable
		Get
			return m_dtCuentas
		End Get
		Set(ByVal value As DataTable)
			m_dtCuentas = value
		End Set
	End Property

	Public Property DSCuentas() As DataSet
		Get
			return m_dsCuentas
		End Get
		Set(ByVal value As DataSet)
			m_dsCuentas = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listCuentas = new List(Of ECuentas)()
			return d_cuentas.CUENTSS_Todos(m_listCuentas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCuentas = new List(Of ECuentas)()
			return d_cuentas.CUENTSS_Todos(m_listCuentas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listCuentas = new List(Of ECuentas)()
			return d_cuentas.CUENTSS_Todos(m_listCuentas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listCuentas = new List(Of ECuentas)()
			return d_cuentas.CUENTSS_Todos(m_listCuentas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_banco_id As Short) As Boolean
		Try
			m_ecuentas = New ECuentas()
			Return d_cuentas.CUENTSS_Todos(m_ecuentas, x_banco_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCuentas = new DataSet()
			return d_cuentas.CUENTSS_Todos(m_dsCuentas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCuentas = new DataSet()
			return d_cuentas.CUENTSS_Todos(m_dsCuentas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCuentas = new DataSet()
			Dim _opcion As Boolean = d_cuentas.CUENTSS_Todos(m_dsCuentas, x_where)
		If _opcion Then
			m_dtCuentas = m_dsCuentas.Tables(0)
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
			m_dsCuentas = new DataSet()
			Dim _opcion As Boolean = d_cuentas.CUENTSS_Todos(m_dsCuentas, x_join, x_where)
		If _opcion Then
			m_dtCuentas = m_dsCuentas.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_cuent_id As Short, x_banco_id As Short) As Boolean
		Try
			m_ecuentas = New ECuentas()
			Return d_cuentas.CUENTSS_UnReg(m_ecuentas, x_cuent_id, x_banco_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_ecuentas = New ECuentas()
			Return d_cuentas.CUENTSS_UnReg(m_ecuentas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_ecuentas = New ECuentas()
			Return d_cuentas.CUENTSS_UnReg(m_ecuentas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_ecuentas.Nuevo Then
				d_cuentas.CUENTSI_UnReg(m_ecuentas, x_usuario)
			ElseIf m_ecuentas.Modificado Then
				d_cuentas.CUENTSU_UnReg(m_ecuentas, x_usuario)
			ElseIf m_ecuentas.Eliminado Then
				d_cuentas.CUENTSD_UnReg(Cuentas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_ecuentas.Nuevo Then
				d_cuentas.CUENTSI_UnReg(m_ecuentas, x_usuario)
			ElseIf m_ecuentas.Modificado Then
				d_cuentas.CUENTSU_UnReg(m_ecuentas, x_where, x_usuario)
			ElseIf m_ecuentas.Eliminado Then
				d_cuentas.CUENTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ecuentas.Nuevo Then
				d_cuentas.CUENTSI_UnReg(m_ecuentas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ecuentas.Modificado Then
				d_cuentas.CUENTSU_UnReg(m_ecuentas, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ecuentas.Eliminado Then
				d_cuentas.CUENTSD_UnReg(Cuentas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_ecuentas.Nuevo Then
				d_cuentas.CUENTSI_UnReg(m_ecuentas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ecuentas.Modificado Then
				d_cuentas.CUENTSU_UnReg(m_ecuentas, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_ecuentas.Eliminado Then
				d_cuentas.CUENTSD_UnReg(Cuentas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ecuentas.Nuevo Then
				d_cuentas.CUENTSI_UnReg(m_ecuentas, x_usuario, x_setfecha)
			ElseIf m_ecuentas.Modificado Then
				d_cuentas.CUENTSU_UnReg(m_ecuentas, x_usuario, x_setfecha)
			ElseIf m_ecuentas.Eliminado Then
				d_cuentas.CUENTSD_UnReg(Cuentas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ecuentas.Nuevo Then
				d_cuentas.CUENTSI_UnReg(m_ecuentas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ecuentas.Eliminado Then
				d_cuentas.CUENTSD_UnReg(Cuentas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCuentas = new List(Of ECuentas)()
			return d_cuentas.CUENTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_cuentas.getCorrelativo("CUENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_cuentas.getCorrelativo("CUENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_cuentas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_cuentas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_cuentas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_cuentas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

