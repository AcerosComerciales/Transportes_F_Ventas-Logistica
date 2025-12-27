Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_VehiculosConductores

#Region " Variables "
	
	Private m_tran_vehiculosconductores As ETRAN_VehiculosConductores
	Private m_listTRAN_VehiculosConductores As List(Of ETRAN_VehiculosConductores)
	Private m_dtTRAN_VehiculosConductores As DataTable

	Private m_dsTRAN_VehiculosConductores As DataSet
	Private d_tran_vehiculosconductores As DTRAN_VehiculosConductores 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_vehiculosconductores = New DTRAN_VehiculosConductores()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_VehiculosConductores() As ETRAN_VehiculosConductores 
		Get
			return m_tran_vehiculosconductores
		End Get
		Set(ByVal value As ETRAN_VehiculosConductores)
			m_tran_vehiculosconductores = value
		End Set
	End Property
	Public Property ListTRAN_VehiculosConductores() As List(Of ETRAN_VehiculosConductores)
		Get
			return m_listTRAN_VehiculosConductores
		End Get
		Set(ByVal value As List(Of ETRAN_VehiculosConductores))
			m_listTRAN_VehiculosConductores = value
		End Set
	End Property
	Public Property DTTRAN_VehiculosConductores() As DataTable
		Get
			return m_dtTRAN_VehiculosConductores
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_VehiculosConductores = value
		End Set
	End Property
	Public Property DSTRAN_VehiculosConductores() As DataSet
		Get
			return m_dsTRAN_VehiculosConductores
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_VehiculosConductores = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_VehiculosConductores() As List(Of ETRAN_VehiculosConductores)
			Return Me.m_listTRAN_VehiculosConductores
		End Function
		Public Sub setListTRAN_VehiculosConductores(ByVal _listtran_vehiculosconductores As List (Of ETRAN_VehiculosConductores))
			Me.m_listTRAN_VehiculosConductores = m_listtran_vehiculosconductores 
		End Sub
		Public Function getTRAN_VehiculosConductores() As ETRAN_VehiculosConductores
			Return Me.m_tran_vehiculosconductores
		End Function
		Public Sub setTRAN_VehiculosConductores(ByVal x_tran_vehiculosconductores As ETRAN_VehiculosConductores)
			Me.m_tran_vehiculosconductores = x_tran_vehiculosconductores 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_VehiculosConductores = new List(Of ETRAN_VehiculosConductores)()
			return d_tran_vehiculosconductores.TRAN_VHCONSS_Todos(m_listTRAN_VehiculosConductores)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosConductores = new List(Of ETRAN_VehiculosConductores)()
			return d_tran_vehiculosconductores.TRAN_VHCONSS_Todos(m_listTRAN_VehiculosConductores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosConductores = new List(Of ETRAN_VehiculosConductores)()
			return d_tran_vehiculosconductores.TRAN_VHCONSS_Todos(m_listTRAN_VehiculosConductores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_VehiculosConductores = new List(Of ETRAN_VehiculosConductores)()
			return d_tran_vehiculosconductores.TRAN_VHCONSS_Todos(m_listTRAN_VehiculosConductores, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosConductores = new DataSet()
			return d_tran_vehiculosconductores.TRAN_VHCONSS_Todos(m_dsTRAN_VehiculosConductores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosConductores = new DataSet()
			return d_tran_vehiculosconductores.TRAN_VHCONSS_Todos(m_dsTRAN_VehiculosConductores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosConductores = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosconductores.TRAN_VHCONSS_Todos(m_dsTRAN_VehiculosConductores, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosConductores = m_dsTRAN_VehiculosConductores.Tables(0)
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
			m_dsTRAN_VehiculosConductores = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosconductores.TRAN_VHCONSS_Todos(m_dsTRAN_VehiculosConductores, x_join, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosConductores = m_dsTRAN_VehiculosConductores.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_vhcon_id As Long) As Boolean
		Try
			m_tran_vehiculosconductores = New ETRAN_VehiculosConductores()
			Return d_tran_vehiculosconductores.TRAN_VHCONSS_UnReg(m_tran_vehiculosconductores, x_vhcon_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

  '  Public Function CargarConductoresXNombre() As Boolean 

  '      	Try
		'	m_tran_vehiculosconductores = New ETRAN_VehiculosConductores()
		'	Return d_tran_vehiculosconductores.getSelectForName( x_vhcon_id,x_nombre)
		'Catch ex As Exception
		'	Throw ex
		'End Try


  '  End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosconductores = New ETRAN_VehiculosConductores()
			Return d_tran_vehiculosconductores.TRAN_VHCONSS_UnReg(m_tran_vehiculosconductores, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosconductores = New ETRAN_VehiculosConductores()
			Return d_tran_vehiculosconductores.TRAN_VHCONSS_UnReg(m_tran_vehiculosconductores, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosconductores.Nuevo Then
				d_tran_vehiculosconductores.TRAN_VHCONSI_UnReg(m_tran_vehiculosconductores, x_usuario)
			ElseIf m_tran_vehiculosconductores.Modificado Then
				d_tran_vehiculosconductores.TRAN_VHCONSU_UnReg(m_tran_vehiculosconductores, x_usuario)
			ElseIf m_tran_vehiculosconductores.Eliminado Then
				d_tran_vehiculosconductores.TRAN_VHCONSD_UnReg(m_tran_vehiculosconductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosconductores.Nuevo Then
				d_tran_vehiculosconductores.TRAN_VHCONSI_UnReg(m_tran_vehiculosconductores, x_usuario)
			ElseIf m_tran_vehiculosconductores.Modificado Then
				d_tran_vehiculosconductores.TRAN_VHCONSU_UnReg(m_tran_vehiculosconductores, x_where, x_usuario)
			ElseIf m_tran_vehiculosconductores.Eliminado Then
				d_tran_vehiculosconductores.TRAN_VHCONSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosconductores.Nuevo Then
				d_tran_vehiculosconductores.TRAN_VHCONSI_UnReg(m_tran_vehiculosconductores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosconductores.Modificado Then
				d_tran_vehiculosconductores.TRAN_VHCONSU_UnReg(m_tran_vehiculosconductores, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosconductores.Eliminado Then
				d_tran_vehiculosconductores.TRAN_VHCONSD_UnReg(m_tran_vehiculosconductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_vehiculosconductores.Nuevo Then
				d_tran_vehiculosconductores.TRAN_VHCONSI_UnReg(m_tran_vehiculosconductores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosconductores.Modificado Then
				d_tran_vehiculosconductores.TRAN_VHCONSU_UnReg(m_tran_vehiculosconductores, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_vehiculosconductores.Eliminado Then
				d_tran_vehiculosconductores.TRAN_VHCONSD_UnReg(m_tran_vehiculosconductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosconductores.Nuevo Then
				d_tran_vehiculosconductores.TRAN_VHCONSI_UnReg(m_tran_vehiculosconductores, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosconductores.Modificado Then
				d_tran_vehiculosconductores.TRAN_VHCONSU_UnReg(m_tran_vehiculosconductores, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosconductores.Eliminado Then
				d_tran_vehiculosconductores.TRAN_VHCONSD_UnReg(m_tran_vehiculosconductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosconductores.Nuevo Then
				d_tran_vehiculosconductores.TRAN_VHCONSI_UnReg(m_tran_vehiculosconductores, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosconductores.Eliminado Then
				d_tran_vehiculosconductores.TRAN_VHCONSD_UnReg(m_tran_vehiculosconductores)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosConductores = new List(Of ETRAN_VehiculosConductores)()
			return d_tran_vehiculosconductores.TRAN_VHCONSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_vehiculosconductores.getCorrelativo("VHCON_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_vehiculosconductores.getCorrelativo("VHCON_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_vehiculosconductores.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_vehiculosconductores.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_vehiculosconductores.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_vehiculosconductores.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

