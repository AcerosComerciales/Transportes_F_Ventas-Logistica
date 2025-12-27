Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_ProductoAdicionales

#Region " Variables "
	
	Private m_vent_productoadicionales As EVENT_ProductoAdicionales
	Private m_listVENT_ProductoAdicionales As List(Of EVENT_ProductoAdicionales)
	Private m_dtVENT_ProductoAdicionales As DataTable

	Private m_dsVENT_ProductoAdicionales As DataSet
	Private d_vent_productoadicionales As DVENT_ProductoAdicionales 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_vent_productoadicionales = New DVENT_ProductoAdicionales()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_ProductoAdicionales() As EVENT_ProductoAdicionales 
		Get
			return m_vent_productoadicionales
		End Get
		Set(ByVal value As EVENT_ProductoAdicionales)
			m_vent_productoadicionales = value
		End Set
	End Property
	Public Property ListVENT_ProductoAdicionales() As List(Of EVENT_ProductoAdicionales)
		Get
			return m_listVENT_ProductoAdicionales
		End Get
		Set(ByVal value As List(Of EVENT_ProductoAdicionales))
			m_listVENT_ProductoAdicionales = value
		End Set
	End Property
	Public Property DTVENT_ProductoAdicionales() As DataTable
		Get
			return m_dtVENT_ProductoAdicionales
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_ProductoAdicionales = value
		End Set
	End Property
	Public Property DSVENT_ProductoAdicionales() As DataSet
		Get
			return m_dsVENT_ProductoAdicionales
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_ProductoAdicionales = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	
		Public Function getVENT_ProductoAdicionales() As EVENT_ProductoAdicionales
			Return Me.m_vent_productoadicionales
		End Function
		Public Sub setVENT_ProductoAdicionales(ByVal x_vent_productoadicionales As EVENT_ProductoAdicionales)
			Me.m_vent_productoadicionales = x_vent_productoadicionales 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_ProductoAdicionales = new List(Of EVENT_ProductoAdicionales)()
			return d_vent_productoadicionales.VENT_ARTICSS_Todos(m_listVENT_ProductoAdicionales)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_ProductoAdicionales = new List(Of EVENT_ProductoAdicionales)()
			return d_vent_productoadicionales.VENT_ARTICSS_Todos(m_listVENT_ProductoAdicionales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_ProductoAdicionales = new List(Of EVENT_ProductoAdicionales)()
			return d_vent_productoadicionales.VENT_ARTICSS_Todos(m_listVENT_ProductoAdicionales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_ProductoAdicionales = new List(Of EVENT_ProductoAdicionales)()
			return d_vent_productoadicionales.VENT_ARTICSS_Todos(m_listVENT_ProductoAdicionales, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_ProductoAdicionales = new DataSet()
			return d_vent_productoadicionales.VENT_ARTICSS_Todos(m_dsVENT_ProductoAdicionales, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_ProductoAdicionales = new DataSet()
			return d_vent_productoadicionales.VENT_ARTICSS_Todos(m_dsVENT_ProductoAdicionales, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_ProductoAdicionales = new DataSet()
			Dim _opcion As Boolean = d_vent_productoadicionales.VENT_ARTICSS_Todos(m_dsVENT_ProductoAdicionales, x_where)
		If _opcion Then
			m_dtVENT_ProductoAdicionales = m_dsVENT_ProductoAdicionales.Tables(0)
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
			m_dsVENT_ProductoAdicionales = new DataSet()
			Dim _opcion As Boolean = d_vent_productoadicionales.VENT_ARTICSS_Todos(m_dsVENT_ProductoAdicionales, x_join, x_where)
		If _opcion Then
			m_dtVENT_ProductoAdicionales = m_dsVENT_ProductoAdicionales.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_vent_productoadicionales.Nuevo Then
				d_vent_productoadicionales.VENT_ARTICSI_UnReg(m_vent_productoadicionales, x_usuario)
			ElseIf m_vent_productoadicionales.Eliminado Then
				d_vent_productoadicionales.VENT_ARTICSD_UnReg(m_vent_productoadicionales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_vent_productoadicionales.Nuevo Then
				d_vent_productoadicionales.VENT_ARTICSI_UnReg(m_vent_productoadicionales, x_usuario)
			ElseIf m_vent_productoadicionales.Eliminado Then
				d_vent_productoadicionales.VENT_ARTICSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_productoadicionales.Nuevo Then
				d_vent_productoadicionales.VENT_ARTICSI_UnReg(m_vent_productoadicionales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_productoadicionales.Eliminado Then
				d_vent_productoadicionales.VENT_ARTICSD_UnReg(m_vent_productoadicionales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_vent_productoadicionales.Nuevo Then
				d_vent_productoadicionales.VENT_ARTICSI_UnReg(m_vent_productoadicionales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_productoadicionales.Eliminado Then
				d_vent_productoadicionales.VENT_ARTICSD_UnReg(m_vent_productoadicionales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_productoadicionales.Nuevo Then
				d_vent_productoadicionales.VENT_ARTICSI_UnReg(m_vent_productoadicionales, x_usuario, x_setfecha)
			ElseIf m_vent_productoadicionales.Eliminado Then
				d_vent_productoadicionales.VENT_ARTICSD_UnReg(m_vent_productoadicionales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_productoadicionales.Nuevo Then
				d_vent_productoadicionales.VENT_ARTICSI_UnReg(m_vent_productoadicionales, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_productoadicionales.Eliminado Then
				d_vent_productoadicionales.VENT_ARTICSD_UnReg(m_vent_productoadicionales)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_ProductoAdicionales = new List(Of EVENT_ProductoAdicionales)()
			return d_vent_productoadicionales.VENT_ARTICSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_productoadicionales.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_productoadicionales.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_productoadicionales.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_productoadicionales.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

