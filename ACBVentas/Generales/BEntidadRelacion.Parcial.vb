Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BEntidadRelacion

#Region " Variables "
	
	Private m_entidadrelacion As EEntidadRelacion
	Private m_listEntidadRelacion As List(Of EEntidadRelacion)
	Private m_dtEntidadRelacion As DataTable

	Private m_dsEntidadRelacion As DataSet
	Private d_entidadrelacion As DEntidadRelacion 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_entidadrelacion = New DEntidadRelacion()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property EntidadRelacion() As EEntidadRelacion 
		Get
			return m_entidadrelacion
		End Get
		Set(ByVal value As EEntidadRelacion)
			m_entidadrelacion = value
		End Set
	End Property
	Public Property ListEntidadRelacion() As List(Of EEntidadRelacion)
		Get
			return m_listEntidadRelacion
		End Get
		Set(ByVal value As List(Of EEntidadRelacion))
			m_listEntidadRelacion = value
		End Set
	End Property
	Public Property DTEntidadRelacion() As DataTable
		Get
			return m_dtEntidadRelacion
		End Get
		Set(ByVal value As DataTable)
			m_dtEntidadRelacion = value
		End Set
	End Property
	Public Property DSEntidadRelacion() As DataSet
		Get
			return m_dsEntidadRelacion
		End Get
		Set(ByVal value As DataSet)
			m_dsEntidadRelacion = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListEntidadRelacion() As List(Of EEntidadRelacion)
			Return Me.m_listEntidadRelacion
		End Function
		Public Sub setListEntidadRelacion(ByVal _listentidadrelacion As List (Of EEntidadRelacion))
			Me.m_listEntidadRelacion = m_listentidadrelacion 
		End Sub
		Public Function getEntidadRelacion() As EEntidadRelacion
			Return Me.m_entidadrelacion
		End Function
		Public Sub setEntidadRelacion(ByVal x_entidadrelacion As EEntidadRelacion)
			Me.m_entidadrelacion = x_entidadrelacion 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listEntidadRelacion = new List(Of EEntidadRelacion)()
			return d_entidadrelacion.ENTRESS_Todos(m_listEntidadRelacion)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidadRelacion = new List(Of EEntidadRelacion)()
			return d_entidadrelacion.ENTRESS_Todos(m_listEntidadRelacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidadRelacion = new List(Of EEntidadRelacion)()
			return d_entidadrelacion.ENTRESS_Todos(m_listEntidadRelacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listEntidadRelacion = new List(Of EEntidadRelacion)()
			return d_entidadrelacion.ENTRESS_Todos(m_listEntidadRelacion, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_entid_codigo As String, ByVal x_entid_codrelacion As String, ByVal x_tipos_codtiporelacion As String) As Boolean
		Try
			m_listEntidadRelacion = new List(Of EEntidadRelacion)()
			Return d_entidadrelacion.ENTRESS_Todos(m_listEntidadRelacion, x_entid_codigo, x_entid_codrelacion, x_tipos_codtiporelacion)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidadRelacion = new DataSet()
			return d_entidadrelacion.ENTRESS_Todos(m_dsEntidadRelacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidadRelacion = new DataSet()
			return d_entidadrelacion.ENTRESS_Todos(m_dsEntidadRelacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsEntidadRelacion = new DataSet()
			Dim _opcion As Boolean = d_entidadrelacion.ENTRESS_Todos(m_dsEntidadRelacion, x_where)
		If _opcion Then
			m_dtEntidadRelacion = m_dsEntidadRelacion.Tables(0)
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
			m_dsEntidadRelacion = new DataSet()
			Dim _opcion As Boolean = d_entidadrelacion.ENTRESS_Todos(m_dsEntidadRelacion, x_join, x_where)
		If _opcion Then
			m_dtEntidadRelacion = m_dsEntidadRelacion.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_entre_numero As Short, x_entid_codigo As String, x_entid_codrelacion As String, x_tipos_codtiporelacion As String) As Boolean
		Try
			m_entidadrelacion = New EEntidadRelacion()
			Return d_entidadrelacion.ENTRESS_UnReg(m_entidadrelacion, x_entre_numero, x_entid_codigo, x_entid_codrelacion, x_tipos_codtiporelacion)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_entidadrelacion = New EEntidadRelacion()
			Return d_entidadrelacion.ENTRESS_UnReg(m_entidadrelacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_entidadrelacion = New EEntidadRelacion()
			Return d_entidadrelacion.ENTRESS_UnReg(m_entidadrelacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_entidadrelacion.Nuevo Then
				d_entidadrelacion.ENTRESI_UnReg(m_entidadrelacion, x_usuario)
			ElseIf m_entidadrelacion.Modificado Then
				d_entidadrelacion.ENTRESU_UnReg(m_entidadrelacion, x_usuario)
			ElseIf m_entidadrelacion.Eliminado Then
				d_entidadrelacion.ENTRESD_UnReg(m_entidadrelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_entidadrelacion.Nuevo Then
				d_entidadrelacion.ENTRESI_UnReg(m_entidadrelacion, x_usuario)
			ElseIf m_entidadrelacion.Modificado Then
				d_entidadrelacion.ENTRESU_UnReg(m_entidadrelacion, x_where, x_usuario)
			ElseIf m_entidadrelacion.Eliminado Then
				d_entidadrelacion.ENTRESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_entidadrelacion.Nuevo Then
				d_entidadrelacion.ENTRESI_UnReg(m_entidadrelacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidadrelacion.Modificado Then
				d_entidadrelacion.ENTRESU_UnReg(m_entidadrelacion, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidadrelacion.Eliminado Then
				d_entidadrelacion.ENTRESD_UnReg(m_entidadrelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_entidadrelacion.Nuevo Then
				d_entidadrelacion.ENTRESI_UnReg(m_entidadrelacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidadrelacion.Modificado Then
				d_entidadrelacion.ENTRESU_UnReg(m_entidadrelacion, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_entidadrelacion.Eliminado Then
				d_entidadrelacion.ENTRESD_UnReg(m_entidadrelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_entidadrelacion.Nuevo Then
				d_entidadrelacion.ENTRESI_UnReg(m_entidadrelacion, x_usuario, x_setfecha)
			ElseIf m_entidadrelacion.Modificado Then
				d_entidadrelacion.ENTRESU_UnReg(m_entidadrelacion, x_usuario, x_setfecha)
			ElseIf m_entidadrelacion.Eliminado Then
				d_entidadrelacion.ENTRESD_UnReg(m_entidadrelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_entidadrelacion.Nuevo Then
				d_entidadrelacion.ENTRESI_UnReg(m_entidadrelacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_entidadrelacion.Eliminado Then
				d_entidadrelacion.ENTRESD_UnReg(m_entidadrelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listEntidadRelacion = new List(Of EEntidadRelacion)()
			return d_entidadrelacion.ENTRESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_entidadrelacion.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_entidadrelacion.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_entidadrelacion.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_entidadrelacion.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

