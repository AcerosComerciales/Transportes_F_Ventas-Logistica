Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTipoCambio

#Region " Variables "
	
	Private m_tipocambio As ETipoCambio
	Private m_listTipoCambio As List(Of ETipoCambio)
	Private m_dtTipoCambio As DataTable

	Private m_dsTipoCambio As DataSet
	Private d_tipocambio As DTipoCambio 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tipocambio = New DTipoCambio()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TipoCambio() As ETipoCambio 
		Get
			return m_tipocambio
		End Get
		Set(ByVal value As ETipoCambio)
			m_tipocambio = value
		End Set
	End Property
	Public Property ListTipoCambio() As List(Of ETipoCambio)
		Get
			return m_listTipoCambio
		End Get
		Set(ByVal value As List(Of ETipoCambio))
			m_listTipoCambio = value
		End Set
	End Property
	Public Property DTTipoCambio() As DataTable
		Get
			return m_dtTipoCambio
		End Get
		Set(ByVal value As DataTable)
			m_dtTipoCambio = value
		End Set
	End Property
	Public Property DSTipoCambio() As DataSet
		Get
			return m_dsTipoCambio
		End Get
		Set(ByVal value As DataSet)
			m_dsTipoCambio = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTipoCambio = new List(Of ETipoCambio)()
			return d_tipocambio.TIPOCSS_Todos(m_listTipoCambio)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTipoCambio = new List(Of ETipoCambio)()
			return d_tipocambio.TIPOCSS_Todos(m_listTipoCambio, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTipoCambio = new List(Of ETipoCambio)()
			return d_tipocambio.TIPOCSS_Todos(m_listTipoCambio, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTipoCambio = new List(Of ETipoCambio)()
			return d_tipocambio.TIPOCSS_Todos(m_listTipoCambio, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTipoCambio = new DataSet()
			return d_tipocambio.TIPOCSS_Todos(m_dsTipoCambio, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTipoCambio = new DataSet()
			return d_tipocambio.TIPOCSS_Todos(m_dsTipoCambio, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTipoCambio = new DataSet()
			Dim _opcion As Boolean = d_tipocambio.TIPOCSS_Todos(m_dsTipoCambio, x_where)
		If _opcion Then
			m_dtTipoCambio = m_dsTipoCambio.Tables(0)
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
			m_dsTipoCambio = new DataSet()
			Dim _opcion As Boolean = d_tipocambio.TIPOCSS_Todos(m_dsTipoCambio, x_join, x_where)
		If _opcion Then
			m_dtTipoCambio = m_dsTipoCambio.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_tipoc_fecha As String) As Boolean
		Try
			m_tipocambio = New ETipoCambio()
			Return d_tipocambio.TIPOCSS_UnReg(m_tipocambio, x_tipoc_fecha)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tipocambio = New ETipoCambio()
			Return d_tipocambio.TIPOCSS_UnReg(m_tipocambio, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tipocambio = New ETipoCambio()
			Return d_tipocambio.TIPOCSS_UnReg(m_tipocambio, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tipocambio.Nuevo Then
				d_tipocambio.TIPOCSI_UnReg(m_tipocambio, x_usuario)
			ElseIf m_tipocambio.Modificado Then
				d_tipocambio.TIPOCSU_UnReg(m_tipocambio, x_usuario)
			ElseIf m_tipocambio.Eliminado Then
				d_tipocambio.TIPOCSD_UnReg(m_tipocambio)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tipocambio.Nuevo Then
				d_tipocambio.TIPOCSI_UnReg(m_tipocambio, x_usuario)
			ElseIf m_tipocambio.Modificado Then
				d_tipocambio.TIPOCSU_UnReg(m_tipocambio, x_where, x_usuario)
			ElseIf m_tipocambio.Eliminado Then
				d_tipocambio.TIPOCSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tipocambio.Nuevo Then
				d_tipocambio.TIPOCSI_UnReg(m_tipocambio, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tipocambio.Modificado Then
				d_tipocambio.TIPOCSU_UnReg(m_tipocambio, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tipocambio.Eliminado Then
				d_tipocambio.TIPOCSD_UnReg(m_tipocambio)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tipocambio.Nuevo Then
				d_tipocambio.TIPOCSI_UnReg(m_tipocambio, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tipocambio.Modificado Then
				d_tipocambio.TIPOCSU_UnReg(m_tipocambio, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tipocambio.Eliminado Then
				d_tipocambio.TIPOCSD_UnReg(m_tipocambio)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tipocambio.Nuevo Then
				d_tipocambio.TIPOCSI_UnReg(m_tipocambio, x_usuario, x_setfecha)
			ElseIf m_tipocambio.Modificado Then
				d_tipocambio.TIPOCSU_UnReg(m_tipocambio, x_usuario, x_setfecha)
			ElseIf m_tipocambio.Eliminado Then
				d_tipocambio.TIPOCSD_UnReg(m_tipocambio)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tipocambio.Nuevo Then
				d_tipocambio.TIPOCSI_UnReg(m_tipocambio, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tipocambio.Eliminado Then
				d_tipocambio.TIPOCSD_UnReg(m_tipocambio)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTipoCambio = new List(Of ETipoCambio)()
			return d_tipocambio.TIPOCSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tipocambio.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tipocambio.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tipocambio.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tipocambio.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

