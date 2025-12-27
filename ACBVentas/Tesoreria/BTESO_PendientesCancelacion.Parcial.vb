Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_PendientesCancelacion

#Region " Variables "
	
	Private m_eteso_pendientescancelacion As ETESO_PendientesCancelacion
	Private m_listTESO_PendientesCancelacion As List(Of ETESO_PendientesCancelacion)
	Private m_dtTESO_PendientesCancelacion As DataTable

	Private m_dsTESO_PendientesCancelacion As DataSet
	Private d_teso_pendientescancelacion As DTESO_PendientesCancelacion 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_teso_pendientescancelacion = New DTESO_PendientesCancelacion()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_PendientesCancelacion() As ETESO_PendientesCancelacion 
		Get
			return m_eteso_pendientescancelacion
		End Get
		Set(ByVal value As ETESO_PendientesCancelacion)
			m_eteso_pendientescancelacion = value
		End Set
	End Property

	Public Property ListTESO_PendientesCancelacion() As List(Of ETESO_PendientesCancelacion)
		Get
			return m_listTESO_PendientesCancelacion
		End Get
		Set(ByVal value As List(Of ETESO_PendientesCancelacion))
			m_listTESO_PendientesCancelacion = value
		End Set
	End Property

	Public Property DTTESO_PendientesCancelacion() As DataTable
		Get
			return m_dtTESO_PendientesCancelacion
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_PendientesCancelacion = value
		End Set
	End Property

	Public Property DSTESO_PendientesCancelacion() As DataSet
		Get
			return m_dsTESO_PendientesCancelacion
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_PendientesCancelacion = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_PendientesCancelacion = new List(Of ETESO_PendientesCancelacion)()
			return d_teso_pendientescancelacion.TESO_PCCAJSS_Todos(m_listTESO_PendientesCancelacion)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_PendientesCancelacion = new List(Of ETESO_PendientesCancelacion)()
			return d_teso_pendientescancelacion.TESO_PCCAJSS_Todos(m_listTESO_PendientesCancelacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_PendientesCancelacion = new List(Of ETESO_PendientesCancelacion)()
			return d_teso_pendientescancelacion.TESO_PCCAJSS_Todos(m_listTESO_PendientesCancelacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_PendientesCancelacion = new List(Of ETESO_PendientesCancelacion)()
			return d_teso_pendientescancelacion.TESO_PCCAJSS_Todos(m_listTESO_PendientesCancelacion, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_pcaja_id As Long, ByVal x_pvent_id As Long) As Boolean
		Try
			m_eteso_pendientescancelacion = New ETESO_PendientesCancelacion()
			Return d_teso_pendientescancelacion.TESO_PCCAJSS_Todos(m_eteso_pendientescancelacion, x_pcaja_id, x_pvent_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_PendientesCancelacion = new DataSet()
			return d_teso_pendientescancelacion.TESO_PCCAJSS_Todos(m_dsTESO_PendientesCancelacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_PendientesCancelacion = new DataSet()
			return d_teso_pendientescancelacion.TESO_PCCAJSS_Todos(m_dsTESO_PendientesCancelacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_PendientesCancelacion = new DataSet()
			Dim _opcion As Boolean = d_teso_pendientescancelacion.TESO_PCCAJSS_Todos(m_dsTESO_PendientesCancelacion, x_where)
		If _opcion Then
			m_dtTESO_PendientesCancelacion = m_dsTESO_PendientesCancelacion.Tables(0)
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
			m_dsTESO_PendientesCancelacion = new DataSet()
			Dim _opcion As Boolean = d_teso_pendientescancelacion.TESO_PCCAJSS_Todos(m_dsTESO_PendientesCancelacion, x_join, x_where)
		If _opcion Then
			m_dtTESO_PendientesCancelacion = m_dsTESO_PendientesCancelacion.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pcaja_id As Long, x_pvent_id As Long, x_pccaj_item As Short) As Boolean
		Try
			m_eteso_pendientescancelacion = New ETESO_PendientesCancelacion()
			Return d_teso_pendientescancelacion.TESO_PCCAJSS_UnReg(m_eteso_pendientescancelacion, x_pcaja_id, x_pvent_id, x_pccaj_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_pendientescancelacion = New ETESO_PendientesCancelacion()
			Return d_teso_pendientescancelacion.TESO_PCCAJSS_UnReg(m_eteso_pendientescancelacion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_pendientescancelacion = New ETESO_PendientesCancelacion()
			Return d_teso_pendientescancelacion.TESO_PCCAJSS_UnReg(m_eteso_pendientescancelacion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_pendientescancelacion.Nuevo Then
				d_teso_pendientescancelacion.TESO_PCCAJSI_UnReg(m_eteso_pendientescancelacion, x_usuario)
			ElseIf m_eteso_pendientescancelacion.Modificado Then
				d_teso_pendientescancelacion.TESO_PCCAJSU_UnReg(m_eteso_pendientescancelacion, x_usuario)
			ElseIf m_eteso_pendientescancelacion.Eliminado Then
				d_teso_pendientescancelacion.TESO_PCCAJSD_UnReg(TESO_PendientesCancelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_pendientescancelacion.Nuevo Then
				d_teso_pendientescancelacion.TESO_PCCAJSI_UnReg(m_eteso_pendientescancelacion, x_usuario)
			ElseIf m_eteso_pendientescancelacion.Modificado Then
				d_teso_pendientescancelacion.TESO_PCCAJSU_UnReg(m_eteso_pendientescancelacion, x_where, x_usuario)
			ElseIf m_eteso_pendientescancelacion.Eliminado Then
				d_teso_pendientescancelacion.TESO_PCCAJSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_pendientescancelacion.Nuevo Then
				d_teso_pendientescancelacion.TESO_PCCAJSI_UnReg(m_eteso_pendientescancelacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_pendientescancelacion.Modificado Then
				d_teso_pendientescancelacion.TESO_PCCAJSU_UnReg(m_eteso_pendientescancelacion, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_pendientescancelacion.Eliminado Then
				d_teso_pendientescancelacion.TESO_PCCAJSD_UnReg(TESO_PendientesCancelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_pendientescancelacion.Nuevo Then
				d_teso_pendientescancelacion.TESO_PCCAJSI_UnReg(m_eteso_pendientescancelacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_pendientescancelacion.Modificado Then
				d_teso_pendientescancelacion.TESO_PCCAJSU_UnReg(m_eteso_pendientescancelacion, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_pendientescancelacion.Eliminado Then
				d_teso_pendientescancelacion.TESO_PCCAJSD_UnReg(TESO_PendientesCancelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_pendientescancelacion.Nuevo Then
				d_teso_pendientescancelacion.TESO_PCCAJSI_UnReg(m_eteso_pendientescancelacion, x_usuario, x_setfecha)
			ElseIf m_eteso_pendientescancelacion.Modificado Then
				d_teso_pendientescancelacion.TESO_PCCAJSU_UnReg(m_eteso_pendientescancelacion, x_usuario, x_setfecha)
			ElseIf m_eteso_pendientescancelacion.Eliminado Then
				d_teso_pendientescancelacion.TESO_PCCAJSD_UnReg(TESO_PendientesCancelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_pendientescancelacion.Nuevo Then
				d_teso_pendientescancelacion.TESO_PCCAJSI_UnReg(m_eteso_pendientescancelacion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_pendientescancelacion.Eliminado Then
				d_teso_pendientescancelacion.TESO_PCCAJSD_UnReg(TESO_PendientesCancelacion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_PendientesCancelacion = new List(Of ETESO_PendientesCancelacion)()
			return d_teso_pendientescancelacion.TESO_PCCAJSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_teso_pendientescancelacion.getCorrelativo("PCAJA_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_teso_pendientescancelacion.getCorrelativo("PCAJA_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_pendientescancelacion.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_pendientescancelacion.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_pendientescancelacion.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_pendientescancelacion.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

