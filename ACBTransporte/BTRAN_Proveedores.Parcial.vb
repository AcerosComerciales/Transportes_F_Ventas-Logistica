Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_Proveedores

#Region " Variables "
	
	Private m_tran_proveedores As ETRAN_Proveedores
	Private m_listTRAN_Proveedores As List(Of ETRAN_Proveedores)
	Private m_dtTRAN_Proveedores As DataTable

	Private m_dsTRAN_Proveedores As DataSet
	Private d_tran_proveedores As DTRAN_Proveedores 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_proveedores = New DTRAN_Proveedores()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_Proveedores() As ETRAN_Proveedores 
		Get
			return m_tran_proveedores
		End Get
		Set(ByVal value As ETRAN_Proveedores)
			m_tran_proveedores = value
		End Set
	End Property
	Public Property ListTRAN_Proveedores() As List(Of ETRAN_Proveedores)
		Get
			return m_listTRAN_Proveedores
		End Get
		Set(ByVal value As List(Of ETRAN_Proveedores))
			m_listTRAN_Proveedores = value
		End Set
	End Property
	Public Property DTTRAN_Proveedores() As DataTable
		Get
			return m_dtTRAN_Proveedores
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_Proveedores = value
		End Set
	End Property
	Public Property DSTRAN_Proveedores() As DataSet
		Get
			return m_dsTRAN_Proveedores
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_Proveedores = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_Proveedores() As List(Of ETRAN_Proveedores)
			Return Me.m_listTRAN_Proveedores
		End Function
		Public Sub setListTRAN_Proveedores(ByVal _listtran_proveedores As List (Of ETRAN_Proveedores))
			Me.m_listTRAN_Proveedores = m_listtran_proveedores 
		End Sub
		Public Function getTRAN_Proveedores() As ETRAN_Proveedores
			Return Me.m_tran_proveedores
		End Function
		Public Sub setTRAN_Proveedores(ByVal x_tran_proveedores As ETRAN_Proveedores)
			Me.m_tran_proveedores = x_tran_proveedores 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_Proveedores = new List(Of ETRAN_Proveedores)()
			return d_tran_proveedores.TRAN_PROVESS_Todos(m_listTRAN_Proveedores)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Proveedores = new List(Of ETRAN_Proveedores)()
			return d_tran_proveedores.TRAN_PROVESS_Todos(m_listTRAN_Proveedores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Proveedores = new List(Of ETRAN_Proveedores)()
			return d_tran_proveedores.TRAN_PROVESS_Todos(m_listTRAN_Proveedores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_Proveedores = new List(Of ETRAN_Proveedores)()
			return d_tran_proveedores.TRAN_PROVESS_Todos(m_listTRAN_Proveedores, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Proveedores = new DataSet()
			return d_tran_proveedores.TRAN_PROVESS_Todos(m_dsTRAN_Proveedores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Proveedores = new DataSet()
			return d_tran_proveedores.TRAN_PROVESS_Todos(m_dsTRAN_Proveedores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Proveedores = new DataSet()
			Dim _opcion As Boolean = d_tran_proveedores.TRAN_PROVESS_Todos(m_dsTRAN_Proveedores, x_where)
		If _opcion Then
			m_dtTRAN_Proveedores = m_dsTRAN_Proveedores.Tables(0)
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
			m_dsTRAN_Proveedores = new DataSet()
			Dim _opcion As Boolean = d_tran_proveedores.TRAN_PROVESS_Todos(m_dsTRAN_Proveedores, x_join, x_where)
		If _opcion Then
			m_dtTRAN_Proveedores = m_dsTRAN_Proveedores.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_prove_id As Long) As Boolean
		Try
			m_tran_proveedores = New ETRAN_Proveedores()
			Return d_tran_proveedores.TRAN_PROVESS_UnReg(m_tran_proveedores, x_prove_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_proveedores = New ETRAN_Proveedores()
			Return d_tran_proveedores.TRAN_PROVESS_UnReg(m_tran_proveedores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_proveedores = New ETRAN_Proveedores()
			Return d_tran_proveedores.TRAN_PROVESS_UnReg(m_tran_proveedores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_proveedores.Nuevo Then
				d_tran_proveedores.TRAN_PROVESI_UnReg(m_tran_proveedores, x_usuario)
			ElseIf m_tran_proveedores.Modificado Then
				d_tran_proveedores.TRAN_PROVESU_UnReg(m_tran_proveedores, x_usuario)
			ElseIf m_tran_proveedores.Eliminado Then
				d_tran_proveedores.TRAN_PROVESD_UnReg(m_tran_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_proveedores.Nuevo Then
				d_tran_proveedores.TRAN_PROVESI_UnReg(m_tran_proveedores, x_usuario)
			ElseIf m_tran_proveedores.Modificado Then
				d_tran_proveedores.TRAN_PROVESU_UnReg(m_tran_proveedores, x_where, x_usuario)
			ElseIf m_tran_proveedores.Eliminado Then
				d_tran_proveedores.TRAN_PROVESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_proveedores.Nuevo Then
				d_tran_proveedores.TRAN_PROVESI_UnReg(m_tran_proveedores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_proveedores.Modificado Then
				d_tran_proveedores.TRAN_PROVESU_UnReg(m_tran_proveedores, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_proveedores.Eliminado Then
				d_tran_proveedores.TRAN_PROVESD_UnReg(m_tran_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_proveedores.Nuevo Then
				d_tran_proveedores.TRAN_PROVESI_UnReg(m_tran_proveedores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_proveedores.Modificado Then
				d_tran_proveedores.TRAN_PROVESU_UnReg(m_tran_proveedores, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_proveedores.Eliminado Then
				d_tran_proveedores.TRAN_PROVESD_UnReg(m_tran_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_proveedores.Nuevo Then
				d_tran_proveedores.TRAN_PROVESI_UnReg(m_tran_proveedores, x_usuario, x_setfecha)
			ElseIf m_tran_proveedores.Modificado Then
				d_tran_proveedores.TRAN_PROVESU_UnReg(m_tran_proveedores, x_usuario, x_setfecha)
			ElseIf m_tran_proveedores.Eliminado Then
				d_tran_proveedores.TRAN_PROVESD_UnReg(m_tran_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_proveedores.Nuevo Then
				d_tran_proveedores.TRAN_PROVESI_UnReg(m_tran_proveedores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_proveedores.Eliminado Then
				d_tran_proveedores.TRAN_PROVESD_UnReg(m_tran_proveedores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Proveedores = new List(Of ETRAN_Proveedores)()
			return d_tran_proveedores.TRAN_PROVESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_proveedores.getCorrelativo("PROVE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_proveedores.getCorrelativo("PROVE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_proveedores.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_proveedores.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_proveedores.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_proveedores.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

