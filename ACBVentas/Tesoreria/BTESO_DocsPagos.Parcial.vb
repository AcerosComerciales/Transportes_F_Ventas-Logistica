Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_DocsPagos

#Region " Variables "
	
	Private m_eteso_docspagos As ETESO_DocsPagos
	Private m_listTESO_DocsPagos As List(Of ETESO_DocsPagos)
	Private m_dtTESO_DocsPagos As DataTable

	Private m_dsTESO_DocsPagos As DataSet
	Private d_teso_docspagos As DTESO_DocsPagos 


#End Region

#Region " Constructores "
	
   'Public Sub New()
   '	d_teso_docspagos = New DTESO_DocsPagos()
   'End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_DocsPagos() As ETESO_DocsPagos 
		Get
			return m_eteso_docspagos
		End Get
		Set(ByVal value As ETESO_DocsPagos)
			m_eteso_docspagos = value
		End Set
	End Property

	Public Property ListTESO_DocsPagos() As List(Of ETESO_DocsPagos)
		Get
			return m_listTESO_DocsPagos
		End Get
		Set(ByVal value As List(Of ETESO_DocsPagos))
			m_listTESO_DocsPagos = value
		End Set
	End Property

	Public Property DTTESO_DocsPagos() As DataTable
		Get
			return m_dtTESO_DocsPagos
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_DocsPagos = value
		End Set
	End Property

	Public Property DSTESO_DocsPagos() As DataSet
		Get
			return m_dsTESO_DocsPagos
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_DocsPagos = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_DocsPagos = new List(Of ETESO_DocsPagos)()
			return d_teso_docspagos.TESO_DPAGOSS_Todos(m_listTESO_DocsPagos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_DocsPagos = new List(Of ETESO_DocsPagos)()
			return d_teso_docspagos.TESO_DPAGOSS_Todos(m_listTESO_DocsPagos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_DocsPagos = new List(Of ETESO_DocsPagos)()
			return d_teso_docspagos.TESO_DPAGOSS_Todos(m_listTESO_DocsPagos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_DocsPagos = new List(Of ETESO_DocsPagos)()
			return d_teso_docspagos.TESO_DPAGOSS_Todos(m_listTESO_DocsPagos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_pvent_id As Long) As Boolean
		Try
			m_eteso_docspagos = New ETESO_DocsPagos()
			Return d_teso_docspagos.TESO_DPAGOSS_Todos(m_eteso_docspagos, x_pvent_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_DocsPagos = new DataSet()
			return d_teso_docspagos.TESO_DPAGOSS_Todos(m_dsTESO_DocsPagos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_DocsPagos = new DataSet()
			return d_teso_docspagos.TESO_DPAGOSS_Todos(m_dsTESO_DocsPagos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_DocsPagos = new DataSet()
			Dim _opcion As Boolean = d_teso_docspagos.TESO_DPAGOSS_Todos(m_dsTESO_DocsPagos, x_where)
		If _opcion Then
			m_dtTESO_DocsPagos = m_dsTESO_DocsPagos.Tables(0)
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
			m_dsTESO_DocsPagos = new DataSet()
			Dim _opcion As Boolean = d_teso_docspagos.TESO_DPAGOSS_Todos(m_dsTESO_DocsPagos, x_join, x_where)
		If _opcion Then
			m_dtTESO_DocsPagos = m_dsTESO_DocsPagos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pvent_id As Long, x_dpago_id As Long) As Boolean
		Try
			m_eteso_docspagos = New ETESO_DocsPagos()
			Return d_teso_docspagos.TESO_DPAGOSS_UnReg(m_eteso_docspagos, x_pvent_id, x_dpago_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_docspagos = New ETESO_DocsPagos()
			Return d_teso_docspagos.TESO_DPAGOSS_UnReg(m_eteso_docspagos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_docspagos = New ETESO_DocsPagos()
			Return d_teso_docspagos.TESO_DPAGOSS_UnReg(m_eteso_docspagos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_docspagos.Nuevo Then
				d_teso_docspagos.TESO_DPAGOSI_UnReg(m_eteso_docspagos, x_usuario)
			ElseIf m_eteso_docspagos.Modificado Then
				d_teso_docspagos.TESO_DPAGOSU_UnReg(m_eteso_docspagos, x_usuario)
			ElseIf m_eteso_docspagos.Eliminado Then
				d_teso_docspagos.TESO_DPAGOSD_UnReg(TESO_DocsPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_docspagos.Nuevo Then
				d_teso_docspagos.TESO_DPAGOSI_UnReg(m_eteso_docspagos, x_usuario)
			ElseIf m_eteso_docspagos.Modificado Then
				d_teso_docspagos.TESO_DPAGOSU_UnReg(m_eteso_docspagos, x_where, x_usuario)
			ElseIf m_eteso_docspagos.Eliminado Then
				d_teso_docspagos.TESO_DPAGOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_docspagos.Nuevo Then
				d_teso_docspagos.TESO_DPAGOSI_UnReg(m_eteso_docspagos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_docspagos.Modificado Then
				d_teso_docspagos.TESO_DPAGOSU_UnReg(m_eteso_docspagos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_docspagos.Eliminado Then
				d_teso_docspagos.TESO_DPAGOSD_UnReg(TESO_DocsPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_docspagos.Nuevo Then
				d_teso_docspagos.TESO_DPAGOSI_UnReg(m_eteso_docspagos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_docspagos.Modificado Then
				d_teso_docspagos.TESO_DPAGOSU_UnReg(m_eteso_docspagos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_docspagos.Eliminado Then
				d_teso_docspagos.TESO_DPAGOSD_UnReg(TESO_DocsPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_docspagos.Nuevo Then
				d_teso_docspagos.TESO_DPAGOSI_UnReg(m_eteso_docspagos, x_usuario, x_setfecha)
			ElseIf m_eteso_docspagos.Modificado Then
				d_teso_docspagos.TESO_DPAGOSU_UnReg(m_eteso_docspagos, x_usuario, x_setfecha)
			ElseIf m_eteso_docspagos.Eliminado Then
				d_teso_docspagos.TESO_DPAGOSD_UnReg(TESO_DocsPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_docspagos.Nuevo Then
				d_teso_docspagos.TESO_DPAGOSI_UnReg(m_eteso_docspagos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_docspagos.Eliminado Then
				d_teso_docspagos.TESO_DPAGOSD_UnReg(TESO_DocsPagos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_DocsPagos = new List(Of ETESO_DocsPagos)()
			return d_teso_docspagos.TESO_DPAGOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_teso_docspagos.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_teso_docspagos.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_docspagos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_docspagos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_docspagos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_docspagos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

