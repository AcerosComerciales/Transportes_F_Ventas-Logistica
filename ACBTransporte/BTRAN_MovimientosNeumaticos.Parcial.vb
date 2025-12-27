Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_MovimientosNeumaticos

#Region " Variables "
	
	Private m_tran_movimientosneumaticos As ETRAN_MovimientosNeumaticos
	Private m_listTRAN_MovimientosNeumaticos As List(Of ETRAN_MovimientosNeumaticos)
	Private m_dtTRAN_MovimientosNeumaticos As DataTable

	Private m_dsTRAN_MovimientosNeumaticos As DataSet
	Private d_tran_movimientosneumaticos As DTRAN_MovimientosNeumaticos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_movimientosneumaticos = New DTRAN_MovimientosNeumaticos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_MovimientosNeumaticos() As ETRAN_MovimientosNeumaticos 
		Get
			return m_tran_movimientosneumaticos
		End Get
		Set(ByVal value As ETRAN_MovimientosNeumaticos)
			m_tran_movimientosneumaticos = value
		End Set
	End Property
	Public Property ListTRAN_MovimientosNeumaticos() As List(Of ETRAN_MovimientosNeumaticos)
		Get
			return m_listTRAN_MovimientosNeumaticos
		End Get
		Set(ByVal value As List(Of ETRAN_MovimientosNeumaticos))
			m_listTRAN_MovimientosNeumaticos = value
		End Set
	End Property
	Public Property DTTRAN_MovimientosNeumaticos() As DataTable
		Get
			return m_dtTRAN_MovimientosNeumaticos
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_MovimientosNeumaticos = value
		End Set
	End Property
	Public Property DSTRAN_MovimientosNeumaticos() As DataSet
		Get
			return m_dsTRAN_MovimientosNeumaticos
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_MovimientosNeumaticos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_MovimientosNeumaticos() As List(Of ETRAN_MovimientosNeumaticos)
			Return Me.m_listTRAN_MovimientosNeumaticos
		End Function
		Public Sub setListTRAN_MovimientosNeumaticos(ByVal _listtran_movimientosneumaticos As List (Of ETRAN_MovimientosNeumaticos))
			Me.m_listTRAN_MovimientosNeumaticos = m_listtran_movimientosneumaticos 
		End Sub
		Public Function getTRAN_MovimientosNeumaticos() As ETRAN_MovimientosNeumaticos
			Return Me.m_tran_movimientosneumaticos
		End Function
		Public Sub setTRAN_MovimientosNeumaticos(ByVal x_tran_movimientosneumaticos As ETRAN_MovimientosNeumaticos)
			Me.m_tran_movimientosneumaticos = x_tran_movimientosneumaticos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_MovimientosNeumaticos = new List(Of ETRAN_MovimientosNeumaticos)()
			return d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(m_listTRAN_MovimientosNeumaticos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_MovimientosNeumaticos = new List(Of ETRAN_MovimientosNeumaticos)()
			return d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(m_listTRAN_MovimientosNeumaticos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_MovimientosNeumaticos = new List(Of ETRAN_MovimientosNeumaticos)()
			return d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(m_listTRAN_MovimientosNeumaticos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_MovimientosNeumaticos = new List(Of ETRAN_MovimientosNeumaticos)()
			return d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(m_listTRAN_MovimientosNeumaticos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_MovimientosNeumaticos = new DataSet()
			return d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(m_dsTRAN_MovimientosNeumaticos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_MovimientosNeumaticos = new DataSet()
			return d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(m_dsTRAN_MovimientosNeumaticos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_MovimientosNeumaticos = new DataSet()
			Dim _opcion As Boolean = d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(m_dsTRAN_MovimientosNeumaticos, x_where)
		If _opcion Then
			m_dtTRAN_MovimientosNeumaticos = m_dsTRAN_MovimientosNeumaticos.Tables(0)
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
			m_dsTRAN_MovimientosNeumaticos = new DataSet()
			Dim _opcion As Boolean = d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(m_dsTRAN_MovimientosNeumaticos, x_join, x_where)
		If _opcion Then
			m_dtTRAN_MovimientosNeumaticos = m_dsTRAN_MovimientosNeumaticos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_movnm_id As Long) As Boolean
		Try
			m_tran_movimientosneumaticos = New ETRAN_MovimientosNeumaticos()
			Return d_tran_movimientosneumaticos.TRAN_MOVNMSS_UnReg(m_tran_movimientosneumaticos, x_movnm_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_movimientosneumaticos = New ETRAN_MovimientosNeumaticos()
			Return d_tran_movimientosneumaticos.TRAN_MOVNMSS_UnReg(m_tran_movimientosneumaticos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_movimientosneumaticos = New ETRAN_MovimientosNeumaticos()
			Return d_tran_movimientosneumaticos.TRAN_MOVNMSS_UnReg(m_tran_movimientosneumaticos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_movimientosneumaticos.Nuevo Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSI_UnReg(m_tran_movimientosneumaticos, x_usuario)
			ElseIf m_tran_movimientosneumaticos.Modificado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSU_UnReg(m_tran_movimientosneumaticos, x_usuario)
			ElseIf m_tran_movimientosneumaticos.Eliminado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSD_UnReg(m_tran_movimientosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_movimientosneumaticos.Nuevo Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSI_UnReg(m_tran_movimientosneumaticos, x_usuario)
			ElseIf m_tran_movimientosneumaticos.Modificado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSU_UnReg(m_tran_movimientosneumaticos, x_where, x_usuario)
			ElseIf m_tran_movimientosneumaticos.Eliminado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_movimientosneumaticos.Nuevo Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSI_UnReg(m_tran_movimientosneumaticos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_movimientosneumaticos.Modificado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSU_UnReg(m_tran_movimientosneumaticos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_movimientosneumaticos.Eliminado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSD_UnReg(m_tran_movimientosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_movimientosneumaticos.Nuevo Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSI_UnReg(m_tran_movimientosneumaticos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_movimientosneumaticos.Modificado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSU_UnReg(m_tran_movimientosneumaticos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_movimientosneumaticos.Eliminado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSD_UnReg(m_tran_movimientosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_movimientosneumaticos.Nuevo Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSI_UnReg(m_tran_movimientosneumaticos, x_usuario, x_setfecha)
			ElseIf m_tran_movimientosneumaticos.Modificado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSU_UnReg(m_tran_movimientosneumaticos, x_usuario, x_setfecha)
			ElseIf m_tran_movimientosneumaticos.Eliminado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSD_UnReg(m_tran_movimientosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_movimientosneumaticos.Nuevo Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSI_UnReg(m_tran_movimientosneumaticos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_movimientosneumaticos.Eliminado Then
				d_tran_movimientosneumaticos.TRAN_MOVNMSD_UnReg(m_tran_movimientosneumaticos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_MovimientosNeumaticos = new List(Of ETRAN_MovimientosNeumaticos)()
			return d_tran_movimientosneumaticos.TRAN_MOVNMSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_movimientosneumaticos.getCorrelativo("MOVNM_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_movimientosneumaticos.getCorrelativo("MOVNM_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_movimientosneumaticos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_movimientosneumaticos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_movimientosneumaticos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_movimientosneumaticos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

