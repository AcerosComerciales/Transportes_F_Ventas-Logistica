Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_CombustibleConsumo

#Region " Variables "
	
	Private m_tran_combustibleconsumo As ETRAN_CombustibleConsumo
	Private m_listTRAN_CombustibleConsumo As List(Of ETRAN_CombustibleConsumo)
	Private m_dtTRAN_CombustibleConsumo As DataTable

	Private m_dsTRAN_CombustibleConsumo As DataSet
	Private d_tran_combustibleconsumo As DTRAN_CombustibleConsumo 


#End Region

#Region " Constructores "
	
   Public Sub New()
      d_tran_combustibleconsumo = New DTRAN_CombustibleConsumo()
   End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_CombustibleConsumo() As ETRAN_CombustibleConsumo 
		Get
			return m_tran_combustibleconsumo
		End Get
		Set(ByVal value As ETRAN_CombustibleConsumo)
			m_tran_combustibleconsumo = value
		End Set
	End Property
	Public Property ListTRAN_CombustibleConsumo() As List(Of ETRAN_CombustibleConsumo)
		Get
			return m_listTRAN_CombustibleConsumo
		End Get
		Set(ByVal value As List(Of ETRAN_CombustibleConsumo))
			m_listTRAN_CombustibleConsumo = value
		End Set
	End Property
	Public Property DTTRAN_CombustibleConsumo() As DataTable
		Get
			return m_dtTRAN_CombustibleConsumo
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_CombustibleConsumo = value
		End Set
	End Property
	Public Property DSTRAN_CombustibleConsumo() As DataSet
		Get
			return m_dsTRAN_CombustibleConsumo
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_CombustibleConsumo = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_CombustibleConsumo() As List(Of ETRAN_CombustibleConsumo)
			Return Me.m_listTRAN_CombustibleConsumo
		End Function
		Public Sub setListTRAN_CombustibleConsumo(ByVal _listtran_combustibleconsumo As List (Of ETRAN_CombustibleConsumo))
			Me.m_listTRAN_CombustibleConsumo = m_listtran_combustibleconsumo 
		End Sub
		Public Function getTRAN_CombustibleConsumo() As ETRAN_CombustibleConsumo
			Return Me.m_tran_combustibleconsumo
		End Function
		Public Sub setTRAN_CombustibleConsumo(ByVal x_tran_combustibleconsumo As ETRAN_CombustibleConsumo)
			Me.m_tran_combustibleconsumo = x_tran_combustibleconsumo 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_CombustibleConsumo = new List(Of ETRAN_CombustibleConsumo)()
			return d_tran_combustibleconsumo.TRAN_COMCOSS_Todos(m_listTRAN_CombustibleConsumo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_CombustibleConsumo = new List(Of ETRAN_CombustibleConsumo)()
			return d_tran_combustibleconsumo.TRAN_COMCOSS_Todos(m_listTRAN_CombustibleConsumo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_CombustibleConsumo = new List(Of ETRAN_CombustibleConsumo)()
			return d_tran_combustibleconsumo.TRAN_COMCOSS_Todos(m_listTRAN_CombustibleConsumo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_CombustibleConsumo = new List(Of ETRAN_CombustibleConsumo)()
			return d_tran_combustibleconsumo.TRAN_COMCOSS_Todos(m_listTRAN_CombustibleConsumo, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_CombustibleConsumo = new DataSet()
			return d_tran_combustibleconsumo.TRAN_COMCOSS_Todos(m_dsTRAN_CombustibleConsumo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_CombustibleConsumo = new DataSet()
			return d_tran_combustibleconsumo.TRAN_COMCOSS_Todos(m_dsTRAN_CombustibleConsumo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_CombustibleConsumo = new DataSet()
			Dim _opcion As Boolean = d_tran_combustibleconsumo.TRAN_COMCOSS_Todos(m_dsTRAN_CombustibleConsumo, x_where)
		If _opcion Then
			m_dtTRAN_CombustibleConsumo = m_dsTRAN_CombustibleConsumo.Tables(0)
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
			m_dsTRAN_CombustibleConsumo = new DataSet()
			Dim _opcion As Boolean = d_tran_combustibleconsumo.TRAN_COMCOSS_Todos(m_dsTRAN_CombustibleConsumo, x_join, x_where)
		If _opcion Then
			m_dtTRAN_CombustibleConsumo = m_dsTRAN_CombustibleConsumo.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_comco_id As Long) As Boolean
		Try
			m_tran_combustibleconsumo = New ETRAN_CombustibleConsumo()
			Return d_tran_combustibleconsumo.TRAN_COMCOSS_UnReg(m_tran_combustibleconsumo, x_comco_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_combustibleconsumo = New ETRAN_CombustibleConsumo()
			Return d_tran_combustibleconsumo.TRAN_COMCOSS_UnReg(m_tran_combustibleconsumo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_combustibleconsumo = New ETRAN_CombustibleConsumo()
			Return d_tran_combustibleconsumo.TRAN_COMCOSS_UnReg(m_tran_combustibleconsumo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_combustibleconsumo.Nuevo Then
				d_tran_combustibleconsumo.TRAN_COMCOSI_UnReg(m_tran_combustibleconsumo, x_usuario)
			ElseIf m_tran_combustibleconsumo.Modificado Then
				d_tran_combustibleconsumo.TRAN_COMCOSU_UnReg(m_tran_combustibleconsumo, x_usuario)
			ElseIf m_tran_combustibleconsumo.Eliminado Then
				d_tran_combustibleconsumo.TRAN_COMCOSD_UnReg(m_tran_combustibleconsumo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_combustibleconsumo.Nuevo Then
				d_tran_combustibleconsumo.TRAN_COMCOSI_UnReg(m_tran_combustibleconsumo, x_usuario)
			ElseIf m_tran_combustibleconsumo.Modificado Then
				d_tran_combustibleconsumo.TRAN_COMCOSU_UnReg(m_tran_combustibleconsumo, x_where, x_usuario)
			ElseIf m_tran_combustibleconsumo.Eliminado Then
				d_tran_combustibleconsumo.TRAN_COMCOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_combustibleconsumo.Nuevo Then
				d_tran_combustibleconsumo.TRAN_COMCOSI_UnReg(m_tran_combustibleconsumo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_combustibleconsumo.Modificado Then
				d_tran_combustibleconsumo.TRAN_COMCOSU_UnReg(m_tran_combustibleconsumo, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_combustibleconsumo.Eliminado Then
				d_tran_combustibleconsumo.TRAN_COMCOSD_UnReg(m_tran_combustibleconsumo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_combustibleconsumo.Nuevo Then
				d_tran_combustibleconsumo.TRAN_COMCOSI_UnReg(m_tran_combustibleconsumo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_combustibleconsumo.Modificado Then
				d_tran_combustibleconsumo.TRAN_COMCOSU_UnReg(m_tran_combustibleconsumo, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_combustibleconsumo.Eliminado Then
				d_tran_combustibleconsumo.TRAN_COMCOSD_UnReg(m_tran_combustibleconsumo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_combustibleconsumo.Nuevo Then
				d_tran_combustibleconsumo.TRAN_COMCOSI_UnReg(m_tran_combustibleconsumo, x_usuario, x_setfecha)
			ElseIf m_tran_combustibleconsumo.Modificado Then
				d_tran_combustibleconsumo.TRAN_COMCOSU_UnReg(m_tran_combustibleconsumo, x_usuario, x_setfecha)
			ElseIf m_tran_combustibleconsumo.Eliminado Then
				d_tran_combustibleconsumo.TRAN_COMCOSD_UnReg(m_tran_combustibleconsumo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_combustibleconsumo.Nuevo Then
				d_tran_combustibleconsumo.TRAN_COMCOSI_UnReg(m_tran_combustibleconsumo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_combustibleconsumo.Eliminado Then
				d_tran_combustibleconsumo.TRAN_COMCOSD_UnReg(m_tran_combustibleconsumo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_CombustibleConsumo = new List(Of ETRAN_CombustibleConsumo)()
			return d_tran_combustibleconsumo.TRAN_COMCOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_combustibleconsumo.getCorrelativo("COMCO_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_combustibleconsumo.getCorrelativo("COMCO_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_combustibleconsumo.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_combustibleconsumo.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_combustibleconsumo.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_combustibleconsumo.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

