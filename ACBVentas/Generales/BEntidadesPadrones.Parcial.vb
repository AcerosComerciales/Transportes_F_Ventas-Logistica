Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BEntidadesPadrones

#Region " Variables "
	
	Private m_eentidadespadrones As EEntidadesPadrones
	Private m_listEntidadesPadrones As List(Of EEntidadesPadrones)
	Private m_dtEntidadesPadrones As DataTable

	Private m_dsEntidadesPadrones As DataSet
	Private d_entidadespadrones As DEntidadesPadrones 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_entidadespadrones = New DEntidadesPadrones()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property EntidadesPadrones() As EEntidadesPadrones 
		Get
			return m_eentidadespadrones
		End Get
		Set(ByVal value As EEntidadesPadrones)
			m_eentidadespadrones = value
		End Set
	End Property

	Public Property ListEntidadesPadrones() As List(Of EEntidadesPadrones)
		Get
			return m_listEntidadesPadrones
		End Get
		Set(ByVal value As List(Of EEntidadesPadrones))
			m_listEntidadesPadrones = value
		End Set
	End Property

	Public Property DTEntidadesPadrones() As DataTable
		Get
			return m_dtEntidadesPadrones
		End Get
		Set(ByVal value As DataTable)
			m_dtEntidadesPadrones = value
		End Set
	End Property

	Public Property DSEntidadesPadrones() As DataSet
		Get
			return m_dsEntidadesPadrones
		End Get
		Set(ByVal value As DataSet)
			m_dsEntidadesPadrones = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listEntidadesPadrones = new List(Of EEntidadesPadrones)()
			return d_entidadespadrones.ENPADSS_Todos(m_listEntidadesPadrones)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidadesPadrones = new List(Of EEntidadesPadrones)()
			return d_entidadespadrones.ENPADSS_Todos(m_listEntidadesPadrones, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidadesPadrones = new List(Of EEntidadesPadrones)()
			return d_entidadespadrones.ENPADSS_Todos(m_listEntidadesPadrones, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listEntidadesPadrones = new List(Of EEntidadesPadrones)()
			return d_entidadespadrones.ENPADSS_Todos(m_listEntidadesPadrones, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidadesPadrones = new DataSet()
			return d_entidadespadrones.ENPADSS_Todos(m_dsEntidadesPadrones, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidadesPadrones = new DataSet()
			return d_entidadespadrones.ENPADSS_Todos(m_dsEntidadesPadrones, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidadesPadrones = new DataSet()
			Dim _opcion As Boolean = d_entidadespadrones.ENPADSS_Todos(m_dsEntidadesPadrones, x_where)
		If _opcion Then
			m_dtEntidadesPadrones = m_dsEntidadesPadrones.Tables(0)
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
			m_dsEntidadesPadrones = new DataSet()
			Dim _opcion As Boolean = d_entidadespadrones.ENPADSS_Todos(m_dsEntidadesPadrones, x_join, x_where)
		If _opcion Then
			m_dtEntidadesPadrones = m_dsEntidadesPadrones.Tables(0)
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
			If m_eentidadespadrones.Nuevo Then
				d_entidadespadrones.ENPADSI_UnReg(m_eentidadespadrones, x_usuario)
			ElseIf m_eentidadespadrones.Eliminado Then
				d_entidadespadrones.ENPADSD_UnReg(EntidadesPadrones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eentidadespadrones.Nuevo Then
				d_entidadespadrones.ENPADSI_UnReg(m_eentidadespadrones, x_usuario)
			ElseIf m_eentidadespadrones.Eliminado Then
				d_entidadespadrones.ENPADSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eentidadespadrones.Nuevo Then
				d_entidadespadrones.ENPADSI_UnReg(m_eentidadespadrones, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eentidadespadrones.Eliminado Then
				d_entidadespadrones.ENPADSD_UnReg(EntidadesPadrones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eentidadespadrones.Nuevo Then
				d_entidadespadrones.ENPADSI_UnReg(m_eentidadespadrones, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eentidadespadrones.Eliminado Then
				d_entidadespadrones.ENPADSD_UnReg(EntidadesPadrones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eentidadespadrones.Nuevo Then
				d_entidadespadrones.ENPADSI_UnReg(m_eentidadespadrones, x_usuario, x_setfecha)
			ElseIf m_eentidadespadrones.Eliminado Then
				d_entidadespadrones.ENPADSD_UnReg(EntidadesPadrones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eentidadespadrones.Nuevo Then
				d_entidadespadrones.ENPADSI_UnReg(m_eentidadespadrones, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eentidadespadrones.Eliminado Then
				d_entidadespadrones.ENPADSD_UnReg(EntidadesPadrones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidadesPadrones = new List(Of EEntidadesPadrones)()
			return d_entidadespadrones.ENPADSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_entidadespadrones.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_entidadespadrones.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_entidadespadrones.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_entidadespadrones.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

