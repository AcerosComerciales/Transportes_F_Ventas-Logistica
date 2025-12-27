Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BCorrelativos

#Region " Variables "
	
	Private m_correlativos As ECorrelativos
	Private m_listCorrelativos As List(Of ECorrelativos)
	Private m_dtCorrelativos As DataTable

	Private m_dsCorrelativos As DataSet
	Private d_correlativos As DCorrelativos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_correlativos = New DCorrelativos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Correlativos() As ECorrelativos 
		Get
			return m_correlativos
		End Get
		Set(ByVal value As ECorrelativos)
			m_correlativos = value
		End Set
	End Property
	Public Property ListCorrelativos() As List(Of ECorrelativos)
		Get
			return m_listCorrelativos
		End Get
		Set(ByVal value As List(Of ECorrelativos))
			m_listCorrelativos = value
		End Set
	End Property
	Public Property DTCorrelativos() As DataTable
		Get
			return m_dtCorrelativos
		End Get
		Set(ByVal value As DataTable)
			m_dtCorrelativos = value
		End Set
	End Property
	Public Property DSCorrelativos() As DataSet
		Get
			return m_dsCorrelativos
		End Get
		Set(ByVal value As DataSet)
			m_dsCorrelativos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListCorrelativos() As List(Of ECorrelativos)
			Return Me.m_listCorrelativos
		End Function
		Public Sub setListCorrelativos(ByVal _listcorrelativos As List (Of ECorrelativos))
			Me.m_listCorrelativos = m_listcorrelativos 
		End Sub
		Public Function getCorrelativos() As ECorrelativos
			Return Me.m_correlativos
		End Function
		Public Sub setCorrelativos(ByVal x_correlativos As ECorrelativos)
			Me.m_correlativos = x_correlativos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listCorrelativos = new List(Of ECorrelativos)()
			return d_correlativos.CORRESS_Todos(m_listCorrelativos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCorrelativos = new List(Of ECorrelativos)()
			return d_correlativos.CORRESS_Todos(m_listCorrelativos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listCorrelativos = new List(Of ECorrelativos)()
			return d_correlativos.CORRESS_Todos(m_listCorrelativos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listCorrelativos = new List(Of ECorrelativos)()
			return d_correlativos.CORRESS_Todos(m_listCorrelativos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCorrelativos = new DataSet()
			return d_correlativos.CORRESS_Todos(m_dsCorrelativos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCorrelativos = new DataSet()
			return d_correlativos.CORRESS_Todos(m_dsCorrelativos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCorrelativos = new DataSet()
			Dim _opcion As Boolean = d_correlativos.CORRESS_Todos(m_dsCorrelativos, x_where)
		If _opcion Then
			m_dtCorrelativos = m_dsCorrelativos.Tables(0)
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
			m_dsCorrelativos = new DataSet()
			Dim _opcion As Boolean = d_correlativos.CORRESS_Todos(m_dsCorrelativos, x_join, x_where)
		If _opcion Then
			m_dtCorrelativos = m_dsCorrelativos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_corre_id As Long) As Boolean
		Try
			m_correlativos = New ECorrelativos()
			Return d_correlativos.CORRESS_UnReg(m_correlativos, x_corre_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_correlativos = New ECorrelativos()
			Return d_correlativos.CORRESS_UnReg(m_correlativos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_correlativos = New ECorrelativos()
			Return d_correlativos.CORRESS_UnReg(m_correlativos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_correlativos.Nuevo Then
				d_correlativos.CORRESI_UnReg(m_correlativos, x_usuario)
			ElseIf m_correlativos.Modificado Then
				d_correlativos.CORRESU_UnReg(m_correlativos, x_usuario)
			ElseIf m_correlativos.Eliminado Then
				d_correlativos.CORRESD_UnReg(m_correlativos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_correlativos.Nuevo Then
				d_correlativos.CORRESI_UnReg(m_correlativos, x_usuario)
			ElseIf m_correlativos.Modificado Then
				d_correlativos.CORRESU_UnReg(m_correlativos, x_where, x_usuario)
			ElseIf m_correlativos.Eliminado Then
				d_correlativos.CORRESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_correlativos.Nuevo Then
				d_correlativos.CORRESI_UnReg(m_correlativos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_correlativos.Modificado Then
				d_correlativos.CORRESU_UnReg(m_correlativos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_correlativos.Eliminado Then
				d_correlativos.CORRESD_UnReg(m_correlativos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_correlativos.Nuevo Then
				d_correlativos.CORRESI_UnReg(m_correlativos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_correlativos.Modificado Then
				d_correlativos.CORRESU_UnReg(m_correlativos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_correlativos.Eliminado Then
				d_correlativos.CORRESD_UnReg(m_correlativos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_correlativos.Nuevo Then
				d_correlativos.CORRESI_UnReg(m_correlativos, x_usuario, x_setfecha)
			ElseIf m_correlativos.Modificado Then
				d_correlativos.CORRESU_UnReg(m_correlativos, x_usuario, x_setfecha)
			ElseIf m_correlativos.Eliminado Then
				d_correlativos.CORRESD_UnReg(m_correlativos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_correlativos.Nuevo Then
				d_correlativos.CORRESI_UnReg(m_correlativos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_correlativos.Eliminado Then
				d_correlativos.CORRESD_UnReg(m_correlativos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCorrelativos = new List(Of ECorrelativos)()
			return d_correlativos.CORRESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_correlativos.getCorrelativo("CORRE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_correlativos.getCorrelativo("CORRE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_correlativos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_correlativos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_correlativos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_correlativos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

