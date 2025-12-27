Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BPuntoVenta

#Region " Variables "
	
	Private m_puntoventa As EPuntoVenta
	Private m_listPuntoVenta As List(Of EPuntoVenta)
	Private m_dtPuntoVenta As DataTable

	Private m_dsPuntoVenta As DataSet
	Private d_puntoventa As DPuntoVenta 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_puntoventa = New DPuntoVenta()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property PuntoVenta() As EPuntoVenta 
		Get
			return m_puntoventa
		End Get
		Set(ByVal value As EPuntoVenta)
			m_puntoventa = value
		End Set
	End Property
	Public Property ListPuntoVenta() As List(Of EPuntoVenta)
		Get
			return m_listPuntoVenta
		End Get
		Set(ByVal value As List(Of EPuntoVenta))
			m_listPuntoVenta = value
		End Set
	End Property
	Public Property DTPuntoVenta() As DataTable
		Get
			return m_dtPuntoVenta
		End Get
		Set(ByVal value As DataTable)
			m_dtPuntoVenta = value
		End Set
	End Property
	Public Property DSPuntoVenta() As DataSet
		Get
			return m_dsPuntoVenta
		End Get
		Set(ByVal value As DataSet)
			m_dsPuntoVenta = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListPuntoVenta() As List(Of EPuntoVenta)
			Return Me.m_listPuntoVenta
		End Function
		Public Sub setListPuntoVenta(ByVal _listpuntoventa As List (Of EPuntoVenta))
			Me.m_listPuntoVenta = m_listpuntoventa 
		End Sub
		Public Function getPuntoVenta() As EPuntoVenta
			Return Me.m_puntoventa
		End Function
		Public Sub setPuntoVenta(ByVal x_puntoventa As EPuntoVenta)
			Me.m_puntoventa = x_puntoventa 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listPuntoVenta = new List(Of EPuntoVenta)()
			return d_puntoventa.PVENTSS_Todos(m_listPuntoVenta)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listPuntoVenta = new List(Of EPuntoVenta)()
			return d_puntoventa.PVENTSS_Todos(m_listPuntoVenta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listPuntoVenta = new List(Of EPuntoVenta)()
			return d_puntoventa.PVENTSS_Todos(m_listPuntoVenta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listPuntoVenta = new List(Of EPuntoVenta)()
			return d_puntoventa.PVENTSS_Todos(m_listPuntoVenta, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsPuntoVenta = new DataSet()
			return d_puntoventa.PVENTSS_Todos(m_dsPuntoVenta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsPuntoVenta = new DataSet()
			return d_puntoventa.PVENTSS_Todos(m_dsPuntoVenta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsPuntoVenta = new DataSet()
			Dim _opcion As Boolean = d_puntoventa.PVENTSS_Todos(m_dsPuntoVenta, x_where)
		If _opcion Then
			m_dtPuntoVenta = m_dsPuntoVenta.Tables(0)
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
			m_dsPuntoVenta = new DataSet()
			Dim _opcion As Boolean = d_puntoventa.PVENTSS_Todos(m_dsPuntoVenta, x_join, x_where)
		If _opcion Then
			m_dtPuntoVenta = m_dsPuntoVenta.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pvent_id As Long) As Boolean
		Try
			m_puntoventa = New EPuntoVenta()
			Return d_puntoventa.PVENTSS_UnReg(m_puntoventa, x_pvent_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_puntoventa = New EPuntoVenta()
			Return d_puntoventa.PVENTSS_UnReg(m_puntoventa, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_puntoventa = New EPuntoVenta()
			Return d_puntoventa.PVENTSS_UnReg(m_puntoventa, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_puntoventa.Nuevo Then
				d_puntoventa.PVENTSI_UnReg(m_puntoventa, x_usuario)
			ElseIf m_puntoventa.Modificado Then
				d_puntoventa.PVENTSU_UnReg(m_puntoventa, x_usuario)
			ElseIf m_puntoventa.Eliminado Then
				d_puntoventa.PVENTSD_UnReg(m_puntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_puntoventa.Nuevo Then
				d_puntoventa.PVENTSI_UnReg(m_puntoventa, x_usuario)
			ElseIf m_puntoventa.Modificado Then
				d_puntoventa.PVENTSU_UnReg(m_puntoventa, x_where, x_usuario)
			ElseIf m_puntoventa.Eliminado Then
				d_puntoventa.PVENTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_puntoventa.Nuevo Then
				d_puntoventa.PVENTSI_UnReg(m_puntoventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_puntoventa.Modificado Then
				d_puntoventa.PVENTSU_UnReg(m_puntoventa, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_puntoventa.Eliminado Then
				d_puntoventa.PVENTSD_UnReg(m_puntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_puntoventa.Nuevo Then
				d_puntoventa.PVENTSI_UnReg(m_puntoventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_puntoventa.Modificado Then
				d_puntoventa.PVENTSU_UnReg(m_puntoventa, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_puntoventa.Eliminado Then
				d_puntoventa.PVENTSD_UnReg(m_puntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_puntoventa.Nuevo Then
				d_puntoventa.PVENTSI_UnReg(m_puntoventa, x_usuario, x_setfecha)
			ElseIf m_puntoventa.Modificado Then
				d_puntoventa.PVENTSU_UnReg(m_puntoventa, x_usuario, x_setfecha)
			ElseIf m_puntoventa.Eliminado Then
				d_puntoventa.PVENTSD_UnReg(m_puntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_puntoventa.Nuevo Then
				d_puntoventa.PVENTSI_UnReg(m_puntoventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_puntoventa.Eliminado Then
				d_puntoventa.PVENTSD_UnReg(m_puntoventa)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listPuntoVenta = new List(Of EPuntoVenta)()
			return d_puntoventa.PVENTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_puntoventa.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_puntoventa.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_puntoventa.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_puntoventa.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_puntoventa.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_puntoventa.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

