Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_VehiculosNeumaticos

#Region " Variables "
	
	Private m_tran_vehiculosneumaticos As ETRAN_VehiculosNeumaticos
	Private m_listTRAN_VehiculosNeumaticos As List(Of ETRAN_VehiculosNeumaticos)
	Private m_dtTRAN_VehiculosNeumaticos As DataTable

	Private m_dsTRAN_VehiculosNeumaticos As DataSet
	Private d_tran_vehiculosneumaticos As DTRAN_VehiculosNeumaticos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_vehiculosneumaticos = New DTRAN_VehiculosNeumaticos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_VehiculosNeumaticos() As ETRAN_VehiculosNeumaticos 
		Get
			return m_tran_vehiculosneumaticos
		End Get
		Set(ByVal value As ETRAN_VehiculosNeumaticos)
			m_tran_vehiculosneumaticos = value
		End Set
	End Property
	Public Property ListTRAN_VehiculosNeumaticos() As List(Of ETRAN_VehiculosNeumaticos)
		Get
			return m_listTRAN_VehiculosNeumaticos
		End Get
		Set(ByVal value As List(Of ETRAN_VehiculosNeumaticos))
			m_listTRAN_VehiculosNeumaticos = value
		End Set
	End Property
	Public Property DTTRAN_VehiculosNeumaticos() As DataTable
		Get
			return m_dtTRAN_VehiculosNeumaticos
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_VehiculosNeumaticos = value
		End Set
	End Property
	Public Property DSTRAN_VehiculosNeumaticos() As DataSet
		Get
			return m_dsTRAN_VehiculosNeumaticos
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_VehiculosNeumaticos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_VehiculosNeumaticos() As List(Of ETRAN_VehiculosNeumaticos)
			Return Me.m_listTRAN_VehiculosNeumaticos
		End Function
		Public Sub setListTRAN_VehiculosNeumaticos(ByVal _listtran_vehiculosneumaticos As List (Of ETRAN_VehiculosNeumaticos))
			Me.m_listTRAN_VehiculosNeumaticos = m_listtran_vehiculosneumaticos 
		End Sub
		Public Function getTRAN_VehiculosNeumaticos() As ETRAN_VehiculosNeumaticos
			Return Me.m_tran_vehiculosneumaticos
		End Function
		Public Sub setTRAN_VehiculosNeumaticos(ByVal x_tran_vehiculosneumaticos As ETRAN_VehiculosNeumaticos)
			Me.m_tran_vehiculosneumaticos = x_tran_vehiculosneumaticos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_VehiculosNeumaticos = new List(Of ETRAN_VehiculosNeumaticos)()
			return d_tran_vehiculosneumaticos.TRAN_VNEUMSS_Todos(m_listTRAN_VehiculosNeumaticos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosNeumaticos = new List(Of ETRAN_VehiculosNeumaticos)()
			return d_tran_vehiculosneumaticos.TRAN_VNEUMSS_Todos(m_listTRAN_VehiculosNeumaticos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosNeumaticos = new List(Of ETRAN_VehiculosNeumaticos)()
			return d_tran_vehiculosneumaticos.TRAN_VNEUMSS_Todos(m_listTRAN_VehiculosNeumaticos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_VehiculosNeumaticos = new List(Of ETRAN_VehiculosNeumaticos)()
			return d_tran_vehiculosneumaticos.TRAN_VNEUMSS_Todos(m_listTRAN_VehiculosNeumaticos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosNeumaticos = new DataSet()
			return d_tran_vehiculosneumaticos.TRAN_VNEUMSS_Todos(m_dsTRAN_VehiculosNeumaticos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosNeumaticos = new DataSet()
			return d_tran_vehiculosneumaticos.TRAN_VNEUMSS_Todos(m_dsTRAN_VehiculosNeumaticos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosNeumaticos = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosneumaticos.TRAN_VNEUMSS_Todos(m_dsTRAN_VehiculosNeumaticos, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosNeumaticos = m_dsTRAN_VehiculosNeumaticos.Tables(0)
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
			m_dsTRAN_VehiculosNeumaticos = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosneumaticos.TRAN_VNEUMSS_Todos(m_dsTRAN_VehiculosNeumaticos, x_join, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosNeumaticos = m_dsTRAN_VehiculosNeumaticos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_vneum_id As Long) As Boolean
		Try
			m_tran_vehiculosneumaticos = New ETRAN_VehiculosNeumaticos()
			Return d_tran_vehiculosneumaticos.TRAN_VNEUMSS_UnReg(m_tran_vehiculosneumaticos, x_vneum_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosneumaticos = New ETRAN_VehiculosNeumaticos()
			Return d_tran_vehiculosneumaticos.TRAN_VNEUMSS_UnReg(m_tran_vehiculosneumaticos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosneumaticos = New ETRAN_VehiculosNeumaticos()
			Return d_tran_vehiculosneumaticos.TRAN_VNEUMSS_UnReg(m_tran_vehiculosneumaticos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosneumaticos.Nuevo Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSI_UnReg(m_tran_vehiculosneumaticos, x_usuario)
			ElseIf m_tran_vehiculosneumaticos.Modificado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSU_UnReg(m_tran_vehiculosneumaticos, x_usuario)
			ElseIf m_tran_vehiculosneumaticos.Eliminado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSD_UnReg(m_tran_vehiculosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosneumaticos.Nuevo Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSI_UnReg(m_tran_vehiculosneumaticos, x_usuario)
			ElseIf m_tran_vehiculosneumaticos.Modificado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSU_UnReg(m_tran_vehiculosneumaticos, x_where, x_usuario)
			ElseIf m_tran_vehiculosneumaticos.Eliminado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosneumaticos.Nuevo Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSI_UnReg(m_tran_vehiculosneumaticos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosneumaticos.Modificado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSU_UnReg(m_tran_vehiculosneumaticos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosneumaticos.Eliminado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSD_UnReg(m_tran_vehiculosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_vehiculosneumaticos.Nuevo Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSI_UnReg(m_tran_vehiculosneumaticos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosneumaticos.Modificado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSU_UnReg(m_tran_vehiculosneumaticos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_vehiculosneumaticos.Eliminado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSD_UnReg(m_tran_vehiculosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosneumaticos.Nuevo Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSI_UnReg(m_tran_vehiculosneumaticos, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosneumaticos.Modificado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSU_UnReg(m_tran_vehiculosneumaticos, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosneumaticos.Eliminado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSD_UnReg(m_tran_vehiculosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosneumaticos.Nuevo Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSI_UnReg(m_tran_vehiculosneumaticos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosneumaticos.Eliminado Then
				d_tran_vehiculosneumaticos.TRAN_VNEUMSD_UnReg(m_tran_vehiculosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosNeumaticos = new List(Of ETRAN_VehiculosNeumaticos)()
			return d_tran_vehiculosneumaticos.TRAN_VNEUMSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_vehiculosneumaticos.getCorrelativo("VNEUM_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_vehiculosneumaticos.getCorrelativo("VNEUM_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_vehiculosneumaticos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_vehiculosneumaticos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_vehiculosneumaticos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_vehiculosneumaticos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

