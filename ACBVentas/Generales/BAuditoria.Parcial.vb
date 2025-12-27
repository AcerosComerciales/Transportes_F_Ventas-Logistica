Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BAuditoria

#Region " Variables "
	
	Private m_auditoria As EAuditoria
	Private m_listAuditoria As List(Of EAuditoria)
	Private m_dtAuditoria As DataTable

	Private m_dsAuditoria As DataSet
	Private d_auditoria As DAuditoria 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_auditoria = New DAuditoria()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Auditoria() As EAuditoria 
		Get
			return m_auditoria
		End Get
		Set(ByVal value As EAuditoria)
			m_auditoria = value
		End Set
	End Property
	Public Property ListAuditoria() As List(Of EAuditoria)
		Get
			return m_listAuditoria
		End Get
		Set(ByVal value As List(Of EAuditoria))
			m_listAuditoria = value
		End Set
	End Property
	Public Property DTAuditoria() As DataTable
		Get
			return m_dtAuditoria
		End Get
		Set(ByVal value As DataTable)
			m_dtAuditoria = value
		End Set
	End Property
	Public Property DSAuditoria() As DataSet
		Get
			return m_dsAuditoria
		End Get
		Set(ByVal value As DataSet)
			m_dsAuditoria = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListAuditoria() As List(Of EAuditoria)
			Return Me.m_listAuditoria
		End Function
		Public Sub setListAuditoria(ByVal _listauditoria As List (Of EAuditoria))
			Me.m_listAuditoria = m_listauditoria 
		End Sub
		Public Function getAuditoria() As EAuditoria
			Return Me.m_auditoria
		End Function
		Public Sub setAuditoria(ByVal x_auditoria As EAuditoria)
			Me.m_auditoria = x_auditoria 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listAuditoria = new List(Of EAuditoria)()
			return d_auditoria.AUDITSS_Todos(m_listAuditoria)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listAuditoria = new List(Of EAuditoria)()
			return d_auditoria.AUDITSS_Todos(m_listAuditoria, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listAuditoria = new List(Of EAuditoria)()
			return d_auditoria.AUDITSS_Todos(m_listAuditoria, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listAuditoria = new List(Of EAuditoria)()
			return d_auditoria.AUDITSS_Todos(m_listAuditoria, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_sucur_id As Short) As Boolean
		Try
			m_listAuditoria = new List(Of EAuditoria)()
			Return d_auditoria.AUDITSS_Todos(m_listAuditoria, x_sucur_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsAuditoria = new DataSet()
			return d_auditoria.AUDITSS_Todos(m_dsAuditoria, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsAuditoria = new DataSet()
			return d_auditoria.AUDITSS_Todos(m_dsAuditoria, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsAuditoria = new DataSet()
			Dim _opcion As Boolean = d_auditoria.AUDITSS_Todos(m_dsAuditoria, x_where)
		If _opcion Then
			m_dtAuditoria = m_dsAuditoria.Tables(0)
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
			m_dsAuditoria = new DataSet()
			Dim _opcion As Boolean = d_auditoria.AUDITSS_Todos(m_dsAuditoria, x_join, x_where)
		If _opcion Then
			m_dtAuditoria = m_dsAuditoria.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_audit_id As Long, x_aplic_codigo As String, x_sucur_id As Short) As Boolean
		Try
			m_auditoria = New EAuditoria()
			Return d_auditoria.AUDITSS_UnReg(m_auditoria, x_audit_id, x_aplic_codigo, x_sucur_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_auditoria = New EAuditoria()
			Return d_auditoria.AUDITSS_UnReg(m_auditoria, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_auditoria = New EAuditoria()
			Return d_auditoria.AUDITSS_UnReg(m_auditoria, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_auditoria.Nuevo Then
				d_auditoria.AUDITSI_UnReg(m_auditoria, x_usuario)
			ElseIf m_auditoria.Modificado Then
				d_auditoria.AUDITSU_UnReg(m_auditoria, x_usuario)
			ElseIf m_auditoria.Eliminado Then
				d_auditoria.AUDITSD_UnReg(m_auditoria)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_auditoria.Nuevo Then
				d_auditoria.AUDITSI_UnReg(m_auditoria, x_usuario)
			ElseIf m_auditoria.Modificado Then
				d_auditoria.AUDITSU_UnReg(m_auditoria, x_where, x_usuario)
			ElseIf m_auditoria.Eliminado Then
				d_auditoria.AUDITSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_auditoria.Nuevo Then
				d_auditoria.AUDITSI_UnReg(m_auditoria, x_usuario, x_excluir, x_setfecha)
			ElseIf m_auditoria.Modificado Then
				d_auditoria.AUDITSU_UnReg(m_auditoria, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_auditoria.Eliminado Then
				d_auditoria.AUDITSD_UnReg(m_auditoria)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_auditoria.Nuevo Then
				d_auditoria.AUDITSI_UnReg(m_auditoria, x_usuario, x_excluir, x_setfecha)
			ElseIf m_auditoria.Modificado Then
				d_auditoria.AUDITSU_UnReg(m_auditoria, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_auditoria.Eliminado Then
				d_auditoria.AUDITSD_UnReg(m_auditoria)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_auditoria.Nuevo Then
				d_auditoria.AUDITSI_UnReg(m_auditoria, x_usuario, x_setfecha)
			ElseIf m_auditoria.Modificado Then
				d_auditoria.AUDITSU_UnReg(m_auditoria, x_usuario, x_setfecha)
			ElseIf m_auditoria.Eliminado Then
				d_auditoria.AUDITSD_UnReg(m_auditoria)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_auditoria.Nuevo Then
				d_auditoria.AUDITSI_UnReg(m_auditoria, x_usuario, x_excluir, x_setfecha)
			ElseIf m_auditoria.Eliminado Then
				d_auditoria.AUDITSD_UnReg(m_auditoria)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listAuditoria = new List(Of EAuditoria)()
			return d_auditoria.AUDITSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_auditoria.getCorrelativo("AUDIT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_auditoria.getCorrelativo("AUDIT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_auditoria.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_auditoria.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_auditoria.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_auditoria.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

