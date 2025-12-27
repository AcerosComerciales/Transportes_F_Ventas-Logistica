Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_Vehiculos

#Region " Variables "
	
	Private m_tran_vehiculos As ETRAN_Vehiculos
	Private m_listTRAN_Vehiculos As List(Of ETRAN_Vehiculos)
	Private m_dtTRAN_Vehiculos As DataTable

	Private m_dsTRAN_Vehiculos As DataSet
	Private d_tran_vehiculos As DTRAN_Vehiculos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_vehiculos = New DTRAN_Vehiculos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_Vehiculos() As ETRAN_Vehiculos 
		Get
			return m_tran_vehiculos
		End Get
		Set(ByVal value As ETRAN_Vehiculos)
			m_tran_vehiculos = value
		End Set
	End Property
	Public Property ListTRAN_Vehiculos() As List(Of ETRAN_Vehiculos)
		Get
			return m_listTRAN_Vehiculos
		End Get
		Set(ByVal value As List(Of ETRAN_Vehiculos))
			m_listTRAN_Vehiculos = value
		End Set
	End Property
	Public Property DTTRAN_Vehiculos() As DataTable
		Get
			return m_dtTRAN_Vehiculos
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_Vehiculos = value
		End Set
	End Property
	Public Property DSTRAN_Vehiculos() As DataSet
		Get
			return m_dsTRAN_Vehiculos
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_Vehiculos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_Vehiculos() As List(Of ETRAN_Vehiculos)
			Return Me.m_listTRAN_Vehiculos
		End Function
		Public Sub setListTRAN_Vehiculos(ByVal _listtran_vehiculos As List (Of ETRAN_Vehiculos))
			Me.m_listTRAN_Vehiculos = m_listtran_vehiculos 
		End Sub
		Public Function getTRAN_Vehiculos() As ETRAN_Vehiculos
			Return Me.m_tran_vehiculos
		End Function
		Public Sub setTRAN_Vehiculos(ByVal x_tran_vehiculos As ETRAN_Vehiculos)
			Me.m_tran_vehiculos = x_tran_vehiculos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_Vehiculos = new List(Of ETRAN_Vehiculos)()
			return d_tran_vehiculos.TRAN_VEHICSS_Todos(m_listTRAN_Vehiculos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Vehiculos = new List(Of ETRAN_Vehiculos)()
			return d_tran_vehiculos.TRAN_VEHICSS_Todos(m_listTRAN_Vehiculos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Vehiculos = new List(Of ETRAN_Vehiculos)()
			return d_tran_vehiculos.TRAN_VEHICSS_Todos(m_listTRAN_Vehiculos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_Vehiculos = new List(Of ETRAN_Vehiculos)()
			return d_tran_vehiculos.TRAN_VEHICSS_Todos(m_listTRAN_Vehiculos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Vehiculos = new DataSet()
			return d_tran_vehiculos.TRAN_VEHICSS_Todos(m_dsTRAN_Vehiculos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Vehiculos = new DataSet()
			return d_tran_vehiculos.TRAN_VEHICSS_Todos(m_dsTRAN_Vehiculos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Vehiculos = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculos.TRAN_VEHICSS_Todos(m_dsTRAN_Vehiculos, x_where)
		If _opcion Then
			m_dtTRAN_Vehiculos = m_dsTRAN_Vehiculos.Tables(0)
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
			m_dsTRAN_Vehiculos = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculos.TRAN_VEHICSS_Todos(m_dsTRAN_Vehiculos, x_join, x_where)
		If _opcion Then
			m_dtTRAN_Vehiculos = m_dsTRAN_Vehiculos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_vehic_id As Long) As Boolean
		Try
			m_tran_vehiculos = New ETRAN_Vehiculos()
			Return d_tran_vehiculos.TRAN_VEHICSS_UnReg(m_tran_vehiculos, x_vehic_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculos = New ETRAN_Vehiculos()
			Return d_tran_vehiculos.TRAN_VEHICSS_UnReg(m_tran_vehiculos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculos = New ETRAN_Vehiculos()
			Return d_tran_vehiculos.TRAN_VEHICSS_UnReg(m_tran_vehiculos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculos.Nuevo Then
				d_tran_vehiculos.TRAN_VEHICSI_UnReg(m_tran_vehiculos, x_usuario)
			ElseIf m_tran_vehiculos.Modificado Then
				d_tran_vehiculos.TRAN_VEHICSU_UnReg(m_tran_vehiculos, x_usuario)
			ElseIf m_tran_vehiculos.Eliminado Then
				d_tran_vehiculos.TRAN_VEHICSD_UnReg(m_tran_vehiculos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculos.Nuevo Then
				d_tran_vehiculos.TRAN_VEHICSI_UnReg(m_tran_vehiculos, x_usuario)
			ElseIf m_tran_vehiculos.Modificado Then
				d_tran_vehiculos.TRAN_VEHICSU_UnReg(m_tran_vehiculos, x_where, x_usuario)
			ElseIf m_tran_vehiculos.Eliminado Then
				d_tran_vehiculos.TRAN_VEHICSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculos.Nuevo Then
				d_tran_vehiculos.TRAN_VEHICSI_UnReg(m_tran_vehiculos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculos.Modificado Then
				d_tran_vehiculos.TRAN_VEHICSU_UnReg(m_tran_vehiculos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculos.Eliminado Then
				d_tran_vehiculos.TRAN_VEHICSD_UnReg(m_tran_vehiculos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_vehiculos.Nuevo Then
				d_tran_vehiculos.TRAN_VEHICSI_UnReg(m_tran_vehiculos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculos.Modificado Then
				d_tran_vehiculos.TRAN_VEHICSU_UnReg(m_tran_vehiculos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_vehiculos.Eliminado Then
				d_tran_vehiculos.TRAN_VEHICSD_UnReg(m_tran_vehiculos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculos.Nuevo Then
				d_tran_vehiculos.TRAN_VEHICSI_UnReg(m_tran_vehiculos, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculos.Modificado Then
				d_tran_vehiculos.TRAN_VEHICSU_UnReg(m_tran_vehiculos, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculos.Eliminado Then
				d_tran_vehiculos.TRAN_VEHICSD_UnReg(m_tran_vehiculos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculos.Nuevo Then
				d_tran_vehiculos.TRAN_VEHICSI_UnReg(m_tran_vehiculos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculos.Eliminado Then
				d_tran_vehiculos.TRAN_VEHICSD_UnReg(m_tran_vehiculos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Vehiculos = new List(Of ETRAN_Vehiculos)()
			return d_tran_vehiculos.TRAN_VEHICSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_vehiculos.getCorrelativo("VEHIC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_vehiculos.getCorrelativo("VEHIC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_vehiculos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_vehiculos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_vehiculos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_vehiculos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

