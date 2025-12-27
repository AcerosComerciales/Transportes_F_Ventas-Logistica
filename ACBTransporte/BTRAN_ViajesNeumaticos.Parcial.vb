Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_ViajesNeumaticos

#Region " Variables "
	
	Private m_tran_viajesneumaticos As ETRAN_ViajesNeumaticos
	Private m_listTRAN_ViajesNeumaticos As List(Of ETRAN_ViajesNeumaticos)
	Private m_dtTRAN_ViajesNeumaticos As DataTable

	Private m_dsTRAN_ViajesNeumaticos As DataSet
	Private d_tran_viajesneumaticos As DTRAN_ViajesNeumaticos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_viajesneumaticos = New DTRAN_ViajesNeumaticos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_ViajesNeumaticos() As ETRAN_ViajesNeumaticos 
		Get
			return m_tran_viajesneumaticos
		End Get
		Set(ByVal value As ETRAN_ViajesNeumaticos)
			m_tran_viajesneumaticos = value
		End Set
	End Property
	Public Property ListTRAN_ViajesNeumaticos() As List(Of ETRAN_ViajesNeumaticos)
		Get
			return m_listTRAN_ViajesNeumaticos
		End Get
		Set(ByVal value As List(Of ETRAN_ViajesNeumaticos))
			m_listTRAN_ViajesNeumaticos = value
		End Set
	End Property
	Public Property DTTRAN_ViajesNeumaticos() As DataTable
		Get
			return m_dtTRAN_ViajesNeumaticos
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_ViajesNeumaticos = value
		End Set
	End Property
	Public Property DSTRAN_ViajesNeumaticos() As DataSet
		Get
			return m_dsTRAN_ViajesNeumaticos
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_ViajesNeumaticos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_ViajesNeumaticos() As List(Of ETRAN_ViajesNeumaticos)
			Return Me.m_listTRAN_ViajesNeumaticos
		End Function
		Public Sub setListTRAN_ViajesNeumaticos(ByVal _listtran_viajesneumaticos As List (Of ETRAN_ViajesNeumaticos))
			Me.m_listTRAN_ViajesNeumaticos = m_listtran_viajesneumaticos 
		End Sub
		Public Function getTRAN_ViajesNeumaticos() As ETRAN_ViajesNeumaticos
			Return Me.m_tran_viajesneumaticos
		End Function
		Public Sub setTRAN_ViajesNeumaticos(ByVal x_tran_viajesneumaticos As ETRAN_ViajesNeumaticos)
			Me.m_tran_viajesneumaticos = x_tran_viajesneumaticos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_ViajesNeumaticos = new List(Of ETRAN_ViajesNeumaticos)()
			return d_tran_viajesneumaticos.TRAN_NEUMFSS_Todos(m_listTRAN_ViajesNeumaticos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesNeumaticos = new List(Of ETRAN_ViajesNeumaticos)()
			return d_tran_viajesneumaticos.TRAN_NEUMFSS_Todos(m_listTRAN_ViajesNeumaticos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesNeumaticos = new List(Of ETRAN_ViajesNeumaticos)()
			return d_tran_viajesneumaticos.TRAN_NEUMFSS_Todos(m_listTRAN_ViajesNeumaticos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_ViajesNeumaticos = new List(Of ETRAN_ViajesNeumaticos)()
			return d_tran_viajesneumaticos.TRAN_NEUMFSS_Todos(m_listTRAN_ViajesNeumaticos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_viaje_id As Long) As Boolean
		Try
			m_listTRAN_ViajesNeumaticos = new List(Of ETRAN_ViajesNeumaticos)()
			Return d_tran_viajesneumaticos.TRAN_NEUMFSS_Todos(m_listTRAN_ViajesNeumaticos, x_viaje_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesNeumaticos = new DataSet()
			return d_tran_viajesneumaticos.TRAN_NEUMFSS_Todos(m_dsTRAN_ViajesNeumaticos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesNeumaticos = new DataSet()
			return d_tran_viajesneumaticos.TRAN_NEUMFSS_Todos(m_dsTRAN_ViajesNeumaticos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesNeumaticos = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesneumaticos.TRAN_NEUMFSS_Todos(m_dsTRAN_ViajesNeumaticos, x_where)
		If _opcion Then
			m_dtTRAN_ViajesNeumaticos = m_dsTRAN_ViajesNeumaticos.Tables(0)
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
			m_dsTRAN_ViajesNeumaticos = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesneumaticos.TRAN_NEUMFSS_Todos(m_dsTRAN_ViajesNeumaticos, x_join, x_where)
		If _opcion Then
			m_dtTRAN_ViajesNeumaticos = m_dsTRAN_ViajesNeumaticos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_viaje_id As Long, x_neumf_id As Long) As Boolean
		Try
			m_tran_viajesneumaticos = New ETRAN_ViajesNeumaticos()
			Return d_tran_viajesneumaticos.TRAN_NEUMFSS_UnReg(m_tran_viajesneumaticos, x_viaje_id, x_neumf_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_viajesneumaticos = New ETRAN_ViajesNeumaticos()
			Return d_tran_viajesneumaticos.TRAN_NEUMFSS_UnReg(m_tran_viajesneumaticos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_viajesneumaticos = New ETRAN_ViajesNeumaticos()
			Return d_tran_viajesneumaticos.TRAN_NEUMFSS_UnReg(m_tran_viajesneumaticos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesneumaticos.Nuevo Then
				d_tran_viajesneumaticos.TRAN_NEUMFSI_UnReg(m_tran_viajesneumaticos, x_usuario)
			ElseIf m_tran_viajesneumaticos.Modificado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSU_UnReg(m_tran_viajesneumaticos, x_usuario)
			ElseIf m_tran_viajesneumaticos.Eliminado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSD_UnReg(m_tran_viajesneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesneumaticos.Nuevo Then
				d_tran_viajesneumaticos.TRAN_NEUMFSI_UnReg(m_tran_viajesneumaticos, x_usuario)
			ElseIf m_tran_viajesneumaticos.Modificado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSU_UnReg(m_tran_viajesneumaticos, x_where, x_usuario)
			ElseIf m_tran_viajesneumaticos.Eliminado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesneumaticos.Nuevo Then
				d_tran_viajesneumaticos.TRAN_NEUMFSI_UnReg(m_tran_viajesneumaticos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesneumaticos.Modificado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSU_UnReg(m_tran_viajesneumaticos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesneumaticos.Eliminado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSD_UnReg(m_tran_viajesneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_viajesneumaticos.Nuevo Then
				d_tran_viajesneumaticos.TRAN_NEUMFSI_UnReg(m_tran_viajesneumaticos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesneumaticos.Modificado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSU_UnReg(m_tran_viajesneumaticos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_viajesneumaticos.Eliminado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSD_UnReg(m_tran_viajesneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesneumaticos.Nuevo Then
				d_tran_viajesneumaticos.TRAN_NEUMFSI_UnReg(m_tran_viajesneumaticos, x_usuario, x_setfecha)
			ElseIf m_tran_viajesneumaticos.Modificado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSU_UnReg(m_tran_viajesneumaticos, x_usuario, x_setfecha)
			ElseIf m_tran_viajesneumaticos.Eliminado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSD_UnReg(m_tran_viajesneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesneumaticos.Nuevo Then
				d_tran_viajesneumaticos.TRAN_NEUMFSI_UnReg(m_tran_viajesneumaticos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesneumaticos.Eliminado Then
				d_tran_viajesneumaticos.TRAN_NEUMFSD_UnReg(m_tran_viajesneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesNeumaticos = new List(Of ETRAN_ViajesNeumaticos)()
			return d_tran_viajesneumaticos.TRAN_NEUMFSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_viajesneumaticos.getCorrelativo("VIAJE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_viajesneumaticos.getCorrelativo("VIAJE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_viajesneumaticos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_viajesneumaticos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_viajesneumaticos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_viajesneumaticos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

