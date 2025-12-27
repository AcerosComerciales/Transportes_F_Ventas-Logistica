Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BEntidades

#Region " Variables "
    'R 14/06/2017
    Private m_vent_docsventa As EVENT_DocsVenta

    Private m_entidades As EEntidades
    Private m_listEntidades As List(Of EEntidades)
    Private m_dtEntidades As DataTable

    Private m_dsEntidades As DataSet
    Private d_entidades As DEntidades
    'R 14/06/2017
    Private d_vent_docsventa As DVENT_DocsVenta


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_entidades = New DEntidades()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Entidades() As EEntidades 
		Get
			return m_entidades
		End Get
		Set(ByVal value As EEntidades)
			m_entidades = value
		End Set
	End Property
	Public Property ListEntidades() As List(Of EEntidades)
		Get
			return m_listEntidades
		End Get
		Set(ByVal value As List(Of EEntidades))
			m_listEntidades = value
		End Set
	End Property
	Public Property DTEntidades() As DataTable
		Get
			return m_dtEntidades
		End Get
		Set(ByVal value As DataTable)
			m_dtEntidades = value
		End Set
	End Property
	Public Property DSEntidades() As DataSet
		Get
			return m_dsEntidades
		End Get
		Set(ByVal value As DataSet)
			m_dsEntidades = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListEntidades() As List(Of EEntidades)
			Return Me.m_listEntidades
		End Function
		Public Sub setListEntidades(ByVal _listentidades As List (Of EEntidades))
			Me.m_listEntidades = m_listentidades 
		End Sub
		Public Function getEntidades() As EEntidades
			Return Me.m_entidades
		End Function
		Public Sub setEntidades(ByVal x_entidades As EEntidades)
			Me.m_entidades = x_entidades 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listEntidades = new List(Of EEntidades)()
			return d_entidades.ENTIDSS_Todos(m_listEntidades)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidades = new List(Of EEntidades)()
			return d_entidades.ENTIDSS_Todos(m_listEntidades, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidades = new List(Of EEntidades)()
			return d_entidades.ENTIDSS_Todos(m_listEntidades, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listEntidades = new List(Of EEntidades)()
			return d_entidades.ENTIDSS_Todos(m_listEntidades, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidades = new DataSet()
			return d_entidades.ENTIDSS_Todos(m_dsEntidades, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidades = new DataSet()
			return d_entidades.ENTIDSS_Todos(m_dsEntidades, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidades = new DataSet()
			Dim _opcion As Boolean = d_entidades.ENTIDSS_Todos(m_dsEntidades, x_where)
		If _opcion Then
			m_dtEntidades = m_dsEntidades.Tables(0)
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
			m_dsEntidades = new DataSet()
			Dim _opcion As Boolean = d_entidades.ENTIDSS_Todos(m_dsEntidades, x_join, x_where)
		If _opcion Then
			m_dtEntidades = m_dsEntidades.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_entid_codigo As String) As Boolean
		Try
			m_entidades = New EEntidades()
			Return d_entidades.ENTIDSS_UnReg(m_entidades, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_entidades = New EEntidades()
			Return d_entidades.ENTIDSS_UnReg(m_entidades, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_entidades = New EEntidades()
            Return d_entidades.ENTIDSS_UnReg(m_entidades, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_entidades.Nuevo Then
				d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario)
			ElseIf m_entidades.Modificado Then
				d_entidades.ENTIDSU_UnReg(m_entidades, x_usuario)
			ElseIf m_entidades.Eliminado Then
				d_entidades.ENTIDSD_UnReg(m_entidades)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_entidades.Nuevo Then
				d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario)
			ElseIf m_entidades.Modificado Then
				d_entidades.ENTIDSU_UnReg(m_entidades, x_where, x_usuario)
			ElseIf m_entidades.Eliminado Then
				d_entidades.ENTIDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_entidades.Nuevo Then
				d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidades.Modificado Then
				d_entidades.ENTIDSU_UnReg(m_entidades, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidades.Eliminado Then
				d_entidades.ENTIDSD_UnReg(m_entidades)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_entidades.Nuevo Then
				d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidades.Modificado Then
				d_entidades.ENTIDSU_UnReg(m_entidades, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_entidades.Eliminado Then
				d_entidades.ENTIDSD_UnReg(m_entidades)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_entidades.Nuevo Then
				d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario, x_setfecha)
			ElseIf m_entidades.Modificado Then
				d_entidades.ENTIDSU_UnReg(m_entidades, x_usuario, x_setfecha)
			ElseIf m_entidades.Eliminado Then
				d_entidades.ENTIDSD_UnReg(m_entidades)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_entidades.Nuevo Then
				d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidades.Eliminado Then
				d_entidades.ENTIDSD_UnReg(m_entidades)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidades = new List(Of EEntidades)()
			return d_entidades.ENTIDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_entidades.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_entidades.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_entidades.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_entidades.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

