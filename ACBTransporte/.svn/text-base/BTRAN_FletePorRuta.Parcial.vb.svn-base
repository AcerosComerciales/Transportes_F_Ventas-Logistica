Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_FletePorRuta

#Region " Variables "
	
	Private m_tran_fleteporruta As ETRAN_FletePorRuta
	Private m_listTRAN_FletePorRuta As List(Of ETRAN_FletePorRuta)
	Private m_dtTRAN_FletePorRuta As DataTable

	Private m_dsTRAN_FletePorRuta As DataSet
	Private d_tran_fleteporruta As DTRAN_FletePorRuta 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_fleteporruta = New DTRAN_FletePorRuta()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_FletePorRuta() As ETRAN_FletePorRuta 
		Get
			return m_tran_fleteporruta
		End Get
		Set(ByVal value As ETRAN_FletePorRuta)
			m_tran_fleteporruta = value
		End Set
	End Property

	Public Property ListTRAN_FletePorRuta() As List(Of ETRAN_FletePorRuta)
		Get
			return m_listTRAN_FletePorRuta
		End Get
		Set(ByVal value As List(Of ETRAN_FletePorRuta))
			m_listTRAN_FletePorRuta = value
		End Set
	End Property

	Public Property DTTRAN_FletePorRuta() As DataTable
		Get
			return m_dtTRAN_FletePorRuta
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_FletePorRuta = value
		End Set
	End Property

	Public Property DSTRAN_FletePorRuta() As DataSet
		Get
			return m_dsTRAN_FletePorRuta
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_FletePorRuta = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_FletePorRuta = new List(Of ETRAN_FletePorRuta)()
			return d_tran_fleteporruta.TRAN_FLERTSS_Todos(m_listTRAN_FletePorRuta)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_FletePorRuta = new List(Of ETRAN_FletePorRuta)()
			return d_tran_fleteporruta.TRAN_FLERTSS_Todos(m_listTRAN_FletePorRuta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_FletePorRuta = new List(Of ETRAN_FletePorRuta)()
			return d_tran_fleteporruta.TRAN_FLERTSS_Todos(m_listTRAN_FletePorRuta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_FletePorRuta = new List(Of ETRAN_FletePorRuta)()
			return d_tran_fleteporruta.TRAN_FLERTSS_Todos(m_listTRAN_FletePorRuta, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_FletePorRuta = new DataSet()
			return d_tran_fleteporruta.TRAN_FLERTSS_Todos(m_dsTRAN_FletePorRuta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_FletePorRuta = new DataSet()
			return d_tran_fleteporruta.TRAN_FLERTSS_Todos(m_dsTRAN_FletePorRuta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_FletePorRuta = new DataSet()
			Dim _opcion As Boolean = d_tran_fleteporruta.TRAN_FLERTSS_Todos(m_dsTRAN_FletePorRuta, x_where)
		If _opcion Then
			m_dtTRAN_FletePorRuta = m_dsTRAN_FletePorRuta.Tables(0)
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
			m_dsTRAN_FletePorRuta = new DataSet()
			Dim _opcion As Boolean = d_tran_fleteporruta.TRAN_FLERTSS_Todos(m_dsTRAN_FletePorRuta, x_join, x_where)
		If _opcion Then
			m_dtTRAN_FletePorRuta = m_dsTRAN_FletePorRuta.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_rutas_id As Long, x_entid_codigo As String) As Boolean
		Try
			m_tran_fleteporruta = New ETRAN_FletePorRuta()
			Return d_tran_fleteporruta.TRAN_FLERTSS_UnReg(m_tran_fleteporruta, x_rutas_id, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_fleteporruta = New ETRAN_FletePorRuta()
			Return d_tran_fleteporruta.TRAN_FLERTSS_UnReg(m_tran_fleteporruta, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_fleteporruta = New ETRAN_FletePorRuta()
			Return d_tran_fleteporruta.TRAN_FLERTSS_UnReg(m_tran_fleteporruta, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_fleteporruta.Nuevo Then
				d_tran_fleteporruta.TRAN_FLERTSI_UnReg(m_tran_fleteporruta, x_usuario)
			ElseIf m_tran_fleteporruta.Modificado Then
				d_tran_fleteporruta.TRAN_FLERTSU_UnReg(m_tran_fleteporruta, x_usuario)
			ElseIf m_tran_fleteporruta.Eliminado Then
				d_tran_fleteporruta.TRAN_FLERTSD_UnReg(TRAN_FletePorRuta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_fleteporruta.Nuevo Then
				d_tran_fleteporruta.TRAN_FLERTSI_UnReg(m_tran_fleteporruta, x_usuario)
			ElseIf m_tran_fleteporruta.Modificado Then
				d_tran_fleteporruta.TRAN_FLERTSU_UnReg(m_tran_fleteporruta, x_where, x_usuario)
			ElseIf m_tran_fleteporruta.Eliminado Then
				d_tran_fleteporruta.TRAN_FLERTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_fleteporruta.Nuevo Then
				d_tran_fleteporruta.TRAN_FLERTSI_UnReg(m_tran_fleteporruta, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_fleteporruta.Modificado Then
				d_tran_fleteporruta.TRAN_FLERTSU_UnReg(m_tran_fleteporruta, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_fleteporruta.Eliminado Then
				d_tran_fleteporruta.TRAN_FLERTSD_UnReg(TRAN_FletePorRuta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_fleteporruta.Nuevo Then
				d_tran_fleteporruta.TRAN_FLERTSI_UnReg(m_tran_fleteporruta, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_fleteporruta.Modificado Then
				d_tran_fleteporruta.TRAN_FLERTSU_UnReg(m_tran_fleteporruta, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_fleteporruta.Eliminado Then
				d_tran_fleteporruta.TRAN_FLERTSD_UnReg(TRAN_FletePorRuta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_fleteporruta.Nuevo Then
				d_tran_fleteporruta.TRAN_FLERTSI_UnReg(m_tran_fleteporruta, x_usuario, x_setfecha)
			ElseIf m_tran_fleteporruta.Modificado Then
				d_tran_fleteporruta.TRAN_FLERTSU_UnReg(m_tran_fleteporruta, x_usuario, x_setfecha)
			ElseIf m_tran_fleteporruta.Eliminado Then
				d_tran_fleteporruta.TRAN_FLERTSD_UnReg(TRAN_FletePorRuta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_fleteporruta.Nuevo Then
				d_tran_fleteporruta.TRAN_FLERTSI_UnReg(m_tran_fleteporruta, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_fleteporruta.Eliminado Then
				d_tran_fleteporruta.TRAN_FLERTSD_UnReg(TRAN_FletePorRuta)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_FletePorRuta = new List(Of ETRAN_FletePorRuta)()
			return d_tran_fleteporruta.TRAN_FLERTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_fleteporruta.getCorrelativo("RUTAS_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_fleteporruta.getCorrelativo("RUTAS_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_fleteporruta.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_fleteporruta.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_fleteporruta.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_fleteporruta.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

