Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BParametros

#Region " Variables "
	
	Private m_parametros As EParametros
	Private m_listParametros As List(Of EParametros)
	Private m_dtParametros As DataTable

	Private m_dsParametros As DataSet
	Private d_parametros As DParametros 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_parametros = New DParametros()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Parametros() As EParametros 
		Get
			return m_parametros
		End Get
		Set(ByVal value As EParametros)
			m_parametros = value
		End Set
	End Property
	Public Property ListParametros() As List(Of EParametros)
		Get
			return m_listParametros
		End Get
		Set(ByVal value As List(Of EParametros))
			m_listParametros = value
		End Set
	End Property
	Public Property DTParametros() As DataTable
		Get
			return m_dtParametros
		End Get
		Set(ByVal value As DataTable)
			m_dtParametros = value
		End Set
	End Property
	Public Property DSParametros() As DataSet
		Get
			return m_dsParametros
		End Get
		Set(ByVal value As DataSet)
			m_dsParametros = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListParametros() As List(Of EParametros)
			Return Me.m_listParametros
		End Function
		Public Sub setListParametros(ByVal _listparametros As List (Of EParametros))
			Me.m_listParametros = m_listparametros 
		End Sub
		Public Function getParametros() As EParametros
			Return Me.m_parametros
		End Function
		Public Sub setParametros(ByVal x_parametros As EParametros)
			Me.m_parametros = x_parametros 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listParametros = new List(Of EParametros)()
			return d_parametros.PARMTSS_Todos(m_listParametros)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listParametros = new List(Of EParametros)()
			return d_parametros.PARMTSS_Todos(m_listParametros, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listParametros = new List(Of EParametros)()
			return d_parametros.PARMTSS_Todos(m_listParametros, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listParametros = new List(Of EParametros)()
			return d_parametros.PARMTSS_Todos(m_listParametros, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_sucur_id As Short) As Boolean
		Try
			m_listParametros = new List(Of EParametros)()
			Return d_parametros.PARMTSS_Todos(m_listParametros, x_sucur_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsParametros = new DataSet()
			return d_parametros.PARMTSS_Todos(m_dsParametros, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsParametros = new DataSet()
			return d_parametros.PARMTSS_Todos(m_dsParametros, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsParametros = new DataSet()
			Dim _opcion As Boolean = d_parametros.PARMTSS_Todos(m_dsParametros, x_where)
		If _opcion Then
			m_dtParametros = m_dsParametros.Tables(0)
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
			m_dsParametros = new DataSet()
			Dim _opcion As Boolean = d_parametros.PARMTSS_Todos(m_dsParametros, x_join, x_where)
		If _opcion Then
			m_dtParametros = m_dsParametros.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_parmt_id As String, x_aplic_codigo As String, x_sucur_id As Short) As Boolean
		Try
			m_parametros = New EParametros()
			Return d_parametros.PARMTSS_UnReg(m_parametros, x_parmt_id, x_aplic_codigo, x_sucur_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_parametros = New EParametros()
			Return d_parametros.PARMTSS_UnReg(m_parametros, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_parametros = New EParametros()
			Return d_parametros.PARMTSS_UnReg(m_parametros, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_parametros.Nuevo Then
				d_parametros.PARMTSI_UnReg(m_parametros, x_usuario)
			ElseIf m_parametros.Modificado Then
				d_parametros.PARMTSU_UnReg(m_parametros, x_usuario)
			ElseIf m_parametros.Eliminado Then
				d_parametros.PARMTSD_UnReg(m_parametros)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_parametros.Nuevo Then
				d_parametros.PARMTSI_UnReg(m_parametros, x_usuario)
			ElseIf m_parametros.Modificado Then
				d_parametros.PARMTSU_UnReg(m_parametros, x_where, x_usuario)
			ElseIf m_parametros.Eliminado Then
				d_parametros.PARMTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_parametros.Nuevo Then
				d_parametros.PARMTSI_UnReg(m_parametros, x_usuario, x_excluir, x_setfecha)
			ElseIf m_parametros.Modificado Then
				d_parametros.PARMTSU_UnReg(m_parametros, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_parametros.Eliminado Then
				d_parametros.PARMTSD_UnReg(m_parametros)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_parametros.Nuevo Then
				d_parametros.PARMTSI_UnReg(m_parametros, x_usuario, x_excluir, x_setfecha)
			ElseIf m_parametros.Modificado Then
				d_parametros.PARMTSU_UnReg(m_parametros, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_parametros.Eliminado Then
				d_parametros.PARMTSD_UnReg(m_parametros)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_parametros.Nuevo Then
				d_parametros.PARMTSI_UnReg(m_parametros, x_usuario, x_setfecha)
			ElseIf m_parametros.Modificado Then
				d_parametros.PARMTSU_UnReg(m_parametros, x_usuario, x_setfecha)
			ElseIf m_parametros.Eliminado Then
				d_parametros.PARMTSD_UnReg(m_parametros)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_parametros.Nuevo Then
				d_parametros.PARMTSI_UnReg(m_parametros, x_usuario, x_excluir, x_setfecha)
			ElseIf m_parametros.Eliminado Then
				d_parametros.PARMTSD_UnReg(m_parametros)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listParametros = new List(Of EParametros)()
			return d_parametros.PARMTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_parametros.getCorrelativo("PARMT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_parametros.getCorrelativo("PARMT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_parametros.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_parametros.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_parametros.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_parametros.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

