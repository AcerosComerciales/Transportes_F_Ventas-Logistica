Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVerStockPtoVenta

#Region " Variables "
	
	Private m_everstockptoventa As EVerStockPtoVenta
	Private m_listVerStockPtoVenta As List(Of EVerStockPtoVenta)
	Private m_dtVerStockPtoVenta As DataTable

	Private m_dsVerStockPtoVenta As DataSet
	Private d_verstockptoventa As DVerStockPtoVenta 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_verstockptoventa = New DVerStockPtoVenta()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VerStockPtoVenta() As EVerStockPtoVenta 
		Get
			return m_everstockptoventa
		End Get
		Set(ByVal value As EVerStockPtoVenta)
			m_everstockptoventa = value
		End Set
	End Property

	Public Property ListVerStockPtoVenta() As List(Of EVerStockPtoVenta)
		Get
			return m_listVerStockPtoVenta
		End Get
		Set(ByVal value As List(Of EVerStockPtoVenta))
			m_listVerStockPtoVenta = value
		End Set
	End Property

	Public Property DTVerStockPtoVenta() As DataTable
		Get
			return m_dtVerStockPtoVenta
		End Get
		Set(ByVal value As DataTable)
			m_dtVerStockPtoVenta = value
		End Set
	End Property

	Public Property DSVerStockPtoVenta() As DataSet
		Get
			return m_dsVerStockPtoVenta
		End Get
		Set(ByVal value As DataSet)
			m_dsVerStockPtoVenta = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVerStockPtoVenta = new List(Of EVerStockPtoVenta)()
			return d_verstockptoventa.VERSTSS_Todos(m_listVerStockPtoVenta)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVerStockPtoVenta = new List(Of EVerStockPtoVenta)()
			return d_verstockptoventa.VERSTSS_Todos(m_listVerStockPtoVenta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVerStockPtoVenta = new List(Of EVerStockPtoVenta)()
			return d_verstockptoventa.VERSTSS_Todos(m_listVerStockPtoVenta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVerStockPtoVenta = new List(Of EVerStockPtoVenta)()
			return d_verstockptoventa.VERSTSS_Todos(m_listVerStockPtoVenta, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVerStockPtoVenta = new DataSet()
			return d_verstockptoventa.VERSTSS_Todos(m_dsVerStockPtoVenta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVerStockPtoVenta = new DataSet()
			return d_verstockptoventa.VERSTSS_Todos(m_dsVerStockPtoVenta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVerStockPtoVenta = new DataSet()
			Dim _opcion As Boolean = d_verstockptoventa.VERSTSS_Todos(m_dsVerStockPtoVenta, x_where)
		If _opcion Then
			m_dtVerStockPtoVenta = m_dsVerStockPtoVenta.Tables(0)
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
			m_dsVerStockPtoVenta = new DataSet()
			Dim _opcion As Boolean = d_verstockptoventa.VERSTSS_Todos(m_dsVerStockPtoVenta, x_join, x_where)
		If _opcion Then
			m_dtVerStockPtoVenta = m_dsVerStockPtoVenta.Tables(0)
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
			If m_everstockptoventa.Nuevo Then
				d_verstockptoventa.VERSTSI_UnReg(m_everstockptoventa, x_usuario)
			ElseIf m_everstockptoventa.Eliminado Then
				d_verstockptoventa.VERSTSD_UnReg(VerStockPtoVenta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_everstockptoventa.Nuevo Then
				d_verstockptoventa.VERSTSI_UnReg(m_everstockptoventa, x_usuario)
			ElseIf m_everstockptoventa.Eliminado Then
				d_verstockptoventa.VERSTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_everstockptoventa.Nuevo Then
				d_verstockptoventa.VERSTSI_UnReg(m_everstockptoventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_everstockptoventa.Eliminado Then
				d_verstockptoventa.VERSTSD_UnReg(VerStockPtoVenta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_everstockptoventa.Nuevo Then
				d_verstockptoventa.VERSTSI_UnReg(m_everstockptoventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_everstockptoventa.Eliminado Then
				d_verstockptoventa.VERSTSD_UnReg(VerStockPtoVenta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_everstockptoventa.Nuevo Then
				d_verstockptoventa.VERSTSI_UnReg(m_everstockptoventa, x_usuario, x_setfecha)
			ElseIf m_everstockptoventa.Eliminado Then
				d_verstockptoventa.VERSTSD_UnReg(VerStockPtoVenta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_everstockptoventa.Nuevo Then
				d_verstockptoventa.VERSTSI_UnReg(m_everstockptoventa, x_usuario, x_excluir, x_setfecha)
			ElseIf m_everstockptoventa.Eliminado Then
				d_verstockptoventa.VERSTSD_UnReg(VerStockPtoVenta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVerStockPtoVenta = new List(Of EVerStockPtoVenta)()
			return d_verstockptoventa.VERSTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_verstockptoventa.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_verstockptoventa.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_verstockptoventa.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_verstockptoventa.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_verstockptoventa.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_verstockptoventa.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

