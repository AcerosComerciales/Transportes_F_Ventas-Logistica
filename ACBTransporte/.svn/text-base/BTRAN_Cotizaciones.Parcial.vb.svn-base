Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_Cotizaciones

#Region " Variables "
	
	Private m_tran_cotizaciones As ETRAN_Cotizaciones
	Private m_listTRAN_Cotizaciones As List(Of ETRAN_Cotizaciones)
	Private m_dtTRAN_Cotizaciones As DataTable

	Private m_dsTRAN_Cotizaciones As DataSet
	Private d_tran_cotizaciones As DTRAN_Cotizaciones 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_cotizaciones = New DTRAN_Cotizaciones()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_Cotizaciones() As ETRAN_Cotizaciones 
		Get
			return m_tran_cotizaciones
		End Get
		Set(ByVal value As ETRAN_Cotizaciones)
			m_tran_cotizaciones = value
		End Set
	End Property
	Public Property ListTRAN_Cotizaciones() As List(Of ETRAN_Cotizaciones)
		Get
			return m_listTRAN_Cotizaciones
		End Get
		Set(ByVal value As List(Of ETRAN_Cotizaciones))
			m_listTRAN_Cotizaciones = value
		End Set
	End Property
	Public Property DTTRAN_Cotizaciones() As DataTable
		Get
			return m_dtTRAN_Cotizaciones
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_Cotizaciones = value
		End Set
	End Property
	Public Property DSTRAN_Cotizaciones() As DataSet
		Get
			return m_dsTRAN_Cotizaciones
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_Cotizaciones = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_Cotizaciones() As List(Of ETRAN_Cotizaciones)
			Return Me.m_listTRAN_Cotizaciones
		End Function
		Public Sub setListTRAN_Cotizaciones(ByVal _listtran_cotizaciones As List (Of ETRAN_Cotizaciones))
			Me.m_listTRAN_Cotizaciones = m_listtran_cotizaciones 
		End Sub
		Public Function getTRAN_Cotizaciones() As ETRAN_Cotizaciones
			Return Me.m_tran_cotizaciones
		End Function
		Public Sub setTRAN_Cotizaciones(ByVal x_tran_cotizaciones As ETRAN_Cotizaciones)
			Me.m_tran_cotizaciones = x_tran_cotizaciones 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_Cotizaciones = new List(Of ETRAN_Cotizaciones)()
			return d_tran_cotizaciones.TRAN_COTIZSS_Todos(m_listTRAN_Cotizaciones)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Cotizaciones = new List(Of ETRAN_Cotizaciones)()
			return d_tran_cotizaciones.TRAN_COTIZSS_Todos(m_listTRAN_Cotizaciones, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Cotizaciones = new List(Of ETRAN_Cotizaciones)()
			return d_tran_cotizaciones.TRAN_COTIZSS_Todos(m_listTRAN_Cotizaciones, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_Cotizaciones = new List(Of ETRAN_Cotizaciones)()
			return d_tran_cotizaciones.TRAN_COTIZSS_Todos(m_listTRAN_Cotizaciones, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Cotizaciones = new DataSet()
			return d_tran_cotizaciones.TRAN_COTIZSS_Todos(m_dsTRAN_Cotizaciones, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Cotizaciones = new DataSet()
			return d_tran_cotizaciones.TRAN_COTIZSS_Todos(m_dsTRAN_Cotizaciones, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Cotizaciones = new DataSet()
			Dim _opcion As Boolean = d_tran_cotizaciones.TRAN_COTIZSS_Todos(m_dsTRAN_Cotizaciones, x_where)
		If _opcion Then
			m_dtTRAN_Cotizaciones = m_dsTRAN_Cotizaciones.Tables(0)
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
			m_dsTRAN_Cotizaciones = new DataSet()
			Dim _opcion As Boolean = d_tran_cotizaciones.TRAN_COTIZSS_Todos(m_dsTRAN_Cotizaciones, x_join, x_where)
		If _opcion Then
			m_dtTRAN_Cotizaciones = m_dsTRAN_Cotizaciones.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_cotiz_codigo As String) As Boolean
		Try
			m_tran_cotizaciones = New ETRAN_Cotizaciones()
			Return d_tran_cotizaciones.TRAN_COTIZSS_UnReg(m_tran_cotizaciones, x_cotiz_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_cotizaciones = New ETRAN_Cotizaciones()
			Return d_tran_cotizaciones.TRAN_COTIZSS_UnReg(m_tran_cotizaciones, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_cotizaciones = New ETRAN_Cotizaciones()
			Return d_tran_cotizaciones.TRAN_COTIZSS_UnReg(m_tran_cotizaciones, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_cotizaciones.Nuevo Then
				d_tran_cotizaciones.TRAN_COTIZSI_UnReg(m_tran_cotizaciones, x_usuario)
			ElseIf m_tran_cotizaciones.Modificado Then
				d_tran_cotizaciones.TRAN_COTIZSU_UnReg(m_tran_cotizaciones, x_usuario)
			ElseIf m_tran_cotizaciones.Eliminado Then
				d_tran_cotizaciones.TRAN_COTIZSD_UnReg(m_tran_cotizaciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_cotizaciones.Nuevo Then
				d_tran_cotizaciones.TRAN_COTIZSI_UnReg(m_tran_cotizaciones, x_usuario)
			ElseIf m_tran_cotizaciones.Modificado Then
				d_tran_cotizaciones.TRAN_COTIZSU_UnReg(m_tran_cotizaciones, x_where, x_usuario)
			ElseIf m_tran_cotizaciones.Eliminado Then
				d_tran_cotizaciones.TRAN_COTIZSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_cotizaciones.Nuevo Then
				d_tran_cotizaciones.TRAN_COTIZSI_UnReg(m_tran_cotizaciones, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizaciones.Modificado Then
				d_tran_cotizaciones.TRAN_COTIZSU_UnReg(m_tran_cotizaciones, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizaciones.Eliminado Then
				d_tran_cotizaciones.TRAN_COTIZSD_UnReg(m_tran_cotizaciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_cotizaciones.Nuevo Then
				d_tran_cotizaciones.TRAN_COTIZSI_UnReg(m_tran_cotizaciones, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizaciones.Modificado Then
				d_tran_cotizaciones.TRAN_COTIZSU_UnReg(m_tran_cotizaciones, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_cotizaciones.Eliminado Then
				d_tran_cotizaciones.TRAN_COTIZSD_UnReg(m_tran_cotizaciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_cotizaciones.Nuevo Then
				d_tran_cotizaciones.TRAN_COTIZSI_UnReg(m_tran_cotizaciones, x_usuario, x_setfecha)
			ElseIf m_tran_cotizaciones.Modificado Then
				d_tran_cotizaciones.TRAN_COTIZSU_UnReg(m_tran_cotizaciones, x_usuario, x_setfecha)
			ElseIf m_tran_cotizaciones.Eliminado Then
				d_tran_cotizaciones.TRAN_COTIZSD_UnReg(m_tran_cotizaciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_cotizaciones.Nuevo Then
				d_tran_cotizaciones.TRAN_COTIZSI_UnReg(m_tran_cotizaciones, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizaciones.Eliminado Then
				d_tran_cotizaciones.TRAN_COTIZSD_UnReg(m_tran_cotizaciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Cotizaciones = new List(Of ETRAN_Cotizaciones)()
			return d_tran_cotizaciones.TRAN_COTIZSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_cotizaciones.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_cotizaciones.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_cotizaciones.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_cotizaciones.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

