Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_ViajesGuiasRemision

#Region " Variables "
	
	Private m_tran_viajesguiasremision As ETRAN_ViajesGuiasRemision
	Private m_listTRAN_ViajesGuiasRemision As List(Of ETRAN_ViajesGuiasRemision)
	Private m_dtTRAN_ViajesGuiasRemision As DataTable

	Private m_dsTRAN_ViajesGuiasRemision As DataSet
	Private d_tran_viajesguiasremision As DTRAN_ViajesGuiasRemision 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_viajesguiasremision = New DTRAN_ViajesGuiasRemision()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_ViajesGuiasRemision() As ETRAN_ViajesGuiasRemision 
		Get
			return m_tran_viajesguiasremision
		End Get
		Set(ByVal value As ETRAN_ViajesGuiasRemision)
			m_tran_viajesguiasremision = value
		End Set
	End Property
	Public Property ListTRAN_ViajesGuiasRemision() As List(Of ETRAN_ViajesGuiasRemision)
		Get
			return m_listTRAN_ViajesGuiasRemision
		End Get
		Set(ByVal value As List(Of ETRAN_ViajesGuiasRemision))
			m_listTRAN_ViajesGuiasRemision = value
		End Set
	End Property
	Public Property DTTRAN_ViajesGuiasRemision() As DataTable
		Get
			return m_dtTRAN_ViajesGuiasRemision
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_ViajesGuiasRemision = value
		End Set
	End Property
	Public Property DSTRAN_ViajesGuiasRemision() As DataSet
		Get
			return m_dsTRAN_ViajesGuiasRemision
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_ViajesGuiasRemision = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_ViajesGuiasRemision() As List(Of ETRAN_ViajesGuiasRemision)
			Return Me.m_listTRAN_ViajesGuiasRemision
		End Function
		Public Sub setListTRAN_ViajesGuiasRemision(ByVal _listtran_viajesguiasremision As List (Of ETRAN_ViajesGuiasRemision))
			Me.m_listTRAN_ViajesGuiasRemision = m_listtran_viajesguiasremision 
		End Sub
		Public Function getTRAN_ViajesGuiasRemision() As ETRAN_ViajesGuiasRemision
			Return Me.m_tran_viajesguiasremision
		End Function
		Public Sub setTRAN_ViajesGuiasRemision(ByVal x_tran_viajesguiasremision As ETRAN_ViajesGuiasRemision)
			Me.m_tran_viajesguiasremision = x_tran_viajesguiasremision 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_ViajesGuiasRemision = new List(Of ETRAN_ViajesGuiasRemision)()
			return d_tran_viajesguiasremision.TRAN_VEGRESS_Todos(m_listTRAN_ViajesGuiasRemision)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesGuiasRemision = new List(Of ETRAN_ViajesGuiasRemision)()
			return d_tran_viajesguiasremision.TRAN_VEGRESS_Todos(m_listTRAN_ViajesGuiasRemision, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesGuiasRemision = new List(Of ETRAN_ViajesGuiasRemision)()
			return d_tran_viajesguiasremision.TRAN_VEGRESS_Todos(m_listTRAN_ViajesGuiasRemision, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_ViajesGuiasRemision = new List(Of ETRAN_ViajesGuiasRemision)()
			return d_tran_viajesguiasremision.TRAN_VEGRESS_Todos(m_listTRAN_ViajesGuiasRemision, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesGuiasRemision = new DataSet()
			return d_tran_viajesguiasremision.TRAN_VEGRESS_Todos(m_dsTRAN_ViajesGuiasRemision, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesGuiasRemision = new DataSet()
			return d_tran_viajesguiasremision.TRAN_VEGRESS_Todos(m_dsTRAN_ViajesGuiasRemision, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesGuiasRemision = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesguiasremision.TRAN_VEGRESS_Todos(m_dsTRAN_ViajesGuiasRemision, x_where)
		If _opcion Then
			m_dtTRAN_ViajesGuiasRemision = m_dsTRAN_ViajesGuiasRemision.Tables(0)
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
			m_dsTRAN_ViajesGuiasRemision = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesguiasremision.TRAN_VEGRESS_Todos(m_dsTRAN_ViajesGuiasRemision, x_join, x_where)
		If _opcion Then
			m_dtTRAN_ViajesGuiasRemision = m_dsTRAN_ViajesGuiasRemision.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_viaje_id As Long, x_gtran_codigo As String) As Boolean
		Try
			m_tran_viajesguiasremision = New ETRAN_ViajesGuiasRemision()
			Return d_tran_viajesguiasremision.TRAN_VEGRESS_UnReg(m_tran_viajesguiasremision, x_viaje_id, x_gtran_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_viajesguiasremision = New ETRAN_ViajesGuiasRemision()
			Return d_tran_viajesguiasremision.TRAN_VEGRESS_UnReg(m_tran_viajesguiasremision, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_viajesguiasremision = New ETRAN_ViajesGuiasRemision()
			Return d_tran_viajesguiasremision.TRAN_VEGRESS_UnReg(m_tran_viajesguiasremision, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesguiasremision.Nuevo Then
				d_tran_viajesguiasremision.TRAN_VEGRESI_UnReg(m_tran_viajesguiasremision, x_usuario)
			ElseIf m_tran_viajesguiasremision.Modificado Then
				d_tran_viajesguiasremision.TRAN_VEGRESU_UnReg(m_tran_viajesguiasremision, x_usuario)
			ElseIf m_tran_viajesguiasremision.Eliminado Then
				d_tran_viajesguiasremision.TRAN_VEGRESD_UnReg(m_tran_viajesguiasremision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesguiasremision.Nuevo Then
				d_tran_viajesguiasremision.TRAN_VEGRESI_UnReg(m_tran_viajesguiasremision, x_usuario)
			ElseIf m_tran_viajesguiasremision.Modificado Then
				d_tran_viajesguiasremision.TRAN_VEGRESU_UnReg(m_tran_viajesguiasremision, x_where, x_usuario)
			ElseIf m_tran_viajesguiasremision.Eliminado Then
				d_tran_viajesguiasremision.TRAN_VEGRESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesguiasremision.Nuevo Then
				d_tran_viajesguiasremision.TRAN_VEGRESI_UnReg(m_tran_viajesguiasremision, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesguiasremision.Modificado Then
				d_tran_viajesguiasremision.TRAN_VEGRESU_UnReg(m_tran_viajesguiasremision, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesguiasremision.Eliminado Then
				d_tran_viajesguiasremision.TRAN_VEGRESD_UnReg(m_tran_viajesguiasremision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_viajesguiasremision.Nuevo Then
				d_tran_viajesguiasremision.TRAN_VEGRESI_UnReg(m_tran_viajesguiasremision, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesguiasremision.Modificado Then
				d_tran_viajesguiasremision.TRAN_VEGRESU_UnReg(m_tran_viajesguiasremision, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_viajesguiasremision.Eliminado Then
				d_tran_viajesguiasremision.TRAN_VEGRESD_UnReg(m_tran_viajesguiasremision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesguiasremision.Nuevo Then
				d_tran_viajesguiasremision.TRAN_VEGRESI_UnReg(m_tran_viajesguiasremision, x_usuario, x_setfecha)
			ElseIf m_tran_viajesguiasremision.Modificado Then
				d_tran_viajesguiasremision.TRAN_VEGRESU_UnReg(m_tran_viajesguiasremision, x_usuario, x_setfecha)
			ElseIf m_tran_viajesguiasremision.Eliminado Then
				d_tran_viajesguiasremision.TRAN_VEGRESD_UnReg(m_tran_viajesguiasremision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesguiasremision.Nuevo Then
				d_tran_viajesguiasremision.TRAN_VEGRESI_UnReg(m_tran_viajesguiasremision, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesguiasremision.Eliminado Then
				d_tran_viajesguiasremision.TRAN_VEGRESD_UnReg(m_tran_viajesguiasremision)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesGuiasRemision = new List(Of ETRAN_ViajesGuiasRemision)()
			return d_tran_viajesguiasremision.TRAN_VEGRESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_viajesguiasremision.getCorrelativo("VIAJE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_viajesguiasremision.getCorrelativo("VIAJE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_viajesguiasremision.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_viajesguiasremision.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_viajesguiasremision.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_viajesguiasremision.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

