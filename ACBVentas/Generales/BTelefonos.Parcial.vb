Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTelefonos

#Region " Variables "
	
	Private m_telefonos As ETelefonos
	Private m_listTelefonos As List(Of ETelefonos)
	Private m_dtTelefonos As DataTable

	Private m_dsTelefonos As DataSet
	Private d_telefonos As DTelefonos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_telefonos = New DTelefonos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Telefonos() As ETelefonos 
		Get
			return m_telefonos
		End Get
		Set(ByVal value As ETelefonos)
			m_telefonos = value
		End Set
	End Property
	Public Property ListTelefonos() As List(Of ETelefonos)
		Get
			return m_listTelefonos
		End Get
		Set(ByVal value As List(Of ETelefonos))
			m_listTelefonos = value
		End Set
	End Property
	Public Property DTTelefonos() As DataTable
		Get
			return m_dtTelefonos
		End Get
		Set(ByVal value As DataTable)
			m_dtTelefonos = value
		End Set
	End Property
	Public Property DSTelefonos() As DataSet
		Get
			return m_dsTelefonos
		End Get
		Set(ByVal value As DataSet)
			m_dsTelefonos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTelefonos() As List(Of ETelefonos)
			Return Me.m_listTelefonos
		End Function
		Public Sub setListTelefonos(ByVal _listtelefonos As List (Of ETelefonos))
			Me.m_listTelefonos = m_listtelefonos 
		End Sub
		Public Function getTelefonos() As ETelefonos
			Return Me.m_telefonos
		End Function
		Public Sub setTelefonos(ByVal x_telefonos As ETelefonos)
			Me.m_telefonos = x_telefonos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTelefonos = new List(Of ETelefonos)()
			return d_telefonos.TELEFSS_Todos(m_listTelefonos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTelefonos = new List(Of ETelefonos)()
			return d_telefonos.TELEFSS_Todos(m_listTelefonos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTelefonos = new List(Of ETelefonos)()
			return d_telefonos.TELEFSS_Todos(m_listTelefonos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTelefonos = new List(Of ETelefonos)()
			return d_telefonos.TELEFSS_Todos(m_listTelefonos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTelefonos = new DataSet()
			return d_telefonos.TELEFSS_Todos(m_dsTelefonos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTelefonos = new DataSet()
			return d_telefonos.TELEFSS_Todos(m_dsTelefonos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTelefonos = new DataSet()
			Dim _opcion As Boolean = d_telefonos.TELEFSS_Todos(m_dsTelefonos, x_where)
		If _opcion Then
			m_dtTelefonos = m_dsTelefonos.Tables(0)
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
			m_dsTelefonos = new DataSet()
			Dim _opcion As Boolean = d_telefonos.TELEFSS_Todos(m_dsTelefonos, x_join, x_where)
		If _opcion Then
			m_dtTelefonos = m_dsTelefonos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_telef_id As Long) As Boolean
		Try
			m_telefonos = New ETelefonos()
			Return d_telefonos.TELEFSS_UnReg(m_telefonos, x_telef_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_telefonos = New ETelefonos()
			Return d_telefonos.TELEFSS_UnReg(m_telefonos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_telefonos = New ETelefonos()
			Return d_telefonos.TELEFSS_UnReg(m_telefonos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_telefonos.Nuevo Then
				d_telefonos.TELEFSI_UnReg(m_telefonos, x_usuario)
			ElseIf m_telefonos.Modificado Then
				d_telefonos.TELEFSU_UnReg(m_telefonos, x_usuario)
			ElseIf m_telefonos.Eliminado Then
				d_telefonos.TELEFSD_UnReg(m_telefonos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_telefonos.Nuevo Then
				d_telefonos.TELEFSI_UnReg(m_telefonos, x_usuario)
			ElseIf m_telefonos.Modificado Then
				d_telefonos.TELEFSU_UnReg(m_telefonos, x_where, x_usuario)
			ElseIf m_telefonos.Eliminado Then
				d_telefonos.TELEFSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_telefonos.Nuevo Then
				d_telefonos.TELEFSI_UnReg(m_telefonos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_telefonos.Modificado Then
				d_telefonos.TELEFSU_UnReg(m_telefonos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_telefonos.Eliminado Then
				d_telefonos.TELEFSD_UnReg(m_telefonos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_telefonos.Nuevo Then
				d_telefonos.TELEFSI_UnReg(m_telefonos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_telefonos.Modificado Then
				d_telefonos.TELEFSU_UnReg(m_telefonos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_telefonos.Eliminado Then
				d_telefonos.TELEFSD_UnReg(m_telefonos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_telefonos.Nuevo Then
				d_telefonos.TELEFSI_UnReg(m_telefonos, x_usuario, x_setfecha)
			ElseIf m_telefonos.Modificado Then
				d_telefonos.TELEFSU_UnReg(m_telefonos, x_usuario, x_setfecha)
			ElseIf m_telefonos.Eliminado Then
				d_telefonos.TELEFSD_UnReg(m_telefonos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_telefonos.Nuevo Then
				d_telefonos.TELEFSI_UnReg(m_telefonos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_telefonos.Eliminado Then
				d_telefonos.TELEFSD_UnReg(m_telefonos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTelefonos = new List(Of ETelefonos)()
			return d_telefonos.TELEFSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_telefonos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_telefonos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_telefonos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_telefonos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

