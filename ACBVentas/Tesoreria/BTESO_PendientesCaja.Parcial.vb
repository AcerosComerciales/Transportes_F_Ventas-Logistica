Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_PendientesCaja

#Region " Variables "
	
	Private m_eteso_pendientescaja As ETESO_PendientesCaja
	Private m_listTESO_PendientesCaja As List(Of ETESO_PendientesCaja)
	Private m_dtTESO_PendientesCaja As DataTable

	Private m_dsTESO_PendientesCaja As DataSet
	Private d_teso_pendientescaja As DTESO_PendientesCaja 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_teso_pendientescaja = New DTESO_PendientesCaja()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_PendientesCaja() As ETESO_PendientesCaja 
		Get
			return m_eteso_pendientescaja
		End Get
		Set(ByVal value As ETESO_PendientesCaja)
			m_eteso_pendientescaja = value
		End Set
	End Property

	Public Property ListTESO_PendientesCaja() As List(Of ETESO_PendientesCaja)
		Get
			return m_listTESO_PendientesCaja
		End Get
		Set(ByVal value As List(Of ETESO_PendientesCaja))
			m_listTESO_PendientesCaja = value
		End Set
	End Property

	Public Property DTTESO_PendientesCaja() As DataTable
		Get
			return m_dtTESO_PendientesCaja
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_PendientesCaja = value
		End Set
	End Property

	Public Property DSTESO_PendientesCaja() As DataSet
		Get
			return m_dsTESO_PendientesCaja
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_PendientesCaja = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_PendientesCaja = new List(Of ETESO_PendientesCaja)()
			return d_teso_pendientescaja.TESO_PCAJASS_Todos(m_listTESO_PendientesCaja)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_PendientesCaja = new List(Of ETESO_PendientesCaja)()
			return d_teso_pendientescaja.TESO_PCAJASS_Todos(m_listTESO_PendientesCaja, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_PendientesCaja = new List(Of ETESO_PendientesCaja)()
			return d_teso_pendientescaja.TESO_PCAJASS_Todos(m_listTESO_PendientesCaja, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_PendientesCaja = new List(Of ETESO_PendientesCaja)()
			return d_teso_pendientescaja.TESO_PCAJASS_Todos(m_listTESO_PendientesCaja, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_pvent_id As Long) As Boolean
		Try
			m_eteso_pendientescaja = New ETESO_PendientesCaja()
			Return d_teso_pendientescaja.TESO_PCAJASS_Todos(m_eteso_pendientescaja, x_pvent_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_PendientesCaja = new DataSet()
			return d_teso_pendientescaja.TESO_PCAJASS_Todos(m_dsTESO_PendientesCaja, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_PendientesCaja = new DataSet()
			return d_teso_pendientescaja.TESO_PCAJASS_Todos(m_dsTESO_PendientesCaja, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_PendientesCaja = new DataSet()
			Dim _opcion As Boolean = d_teso_pendientescaja.TESO_PCAJASS_Todos(m_dsTESO_PendientesCaja, x_where)
		If _opcion Then
			m_dtTESO_PendientesCaja = m_dsTESO_PendientesCaja.Tables(0)
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
			m_dsTESO_PendientesCaja = new DataSet()
			Dim _opcion As Boolean = d_teso_pendientescaja.TESO_PCAJASS_Todos(m_dsTESO_PendientesCaja, x_join, x_where)
		If _opcion Then
			m_dtTESO_PendientesCaja = m_dsTESO_PendientesCaja.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pcaja_id As Long, x_pvent_id As Long) As Boolean
		Try
			m_eteso_pendientescaja = New ETESO_PendientesCaja()
			Return d_teso_pendientescaja.TESO_PCAJASS_UnReg(m_eteso_pendientescaja, x_pcaja_id, x_pvent_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_pendientescaja = New ETESO_PendientesCaja()
			Return d_teso_pendientescaja.TESO_PCAJASS_UnReg(m_eteso_pendientescaja, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_pendientescaja = New ETESO_PendientesCaja()
			Return d_teso_pendientescaja.TESO_PCAJASS_UnReg(m_eteso_pendientescaja, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_pendientescaja.Nuevo Then
				d_teso_pendientescaja.TESO_PCAJASI_UnReg(m_eteso_pendientescaja, x_usuario)
			ElseIf m_eteso_pendientescaja.Modificado Then
				d_teso_pendientescaja.TESO_PCAJASU_UnReg(m_eteso_pendientescaja, x_usuario)
			ElseIf m_eteso_pendientescaja.Eliminado Then
				d_teso_pendientescaja.TESO_PCAJASD_UnReg(TESO_PendientesCaja)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_pendientescaja.Nuevo Then
				d_teso_pendientescaja.TESO_PCAJASI_UnReg(m_eteso_pendientescaja, x_usuario)
			ElseIf m_eteso_pendientescaja.Modificado Then
				d_teso_pendientescaja.TESO_PCAJASU_UnReg(m_eteso_pendientescaja, x_where, x_usuario)
			ElseIf m_eteso_pendientescaja.Eliminado Then
				d_teso_pendientescaja.TESO_PCAJASD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_pendientescaja.Nuevo Then
				d_teso_pendientescaja.TESO_PCAJASI_UnReg(m_eteso_pendientescaja, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_pendientescaja.Modificado Then
				d_teso_pendientescaja.TESO_PCAJASU_UnReg(m_eteso_pendientescaja, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_pendientescaja.Eliminado Then
				d_teso_pendientescaja.TESO_PCAJASD_UnReg(TESO_PendientesCaja)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_pendientescaja.Nuevo Then
				d_teso_pendientescaja.TESO_PCAJASI_UnReg(m_eteso_pendientescaja, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_pendientescaja.Modificado Then
				d_teso_pendientescaja.TESO_PCAJASU_UnReg(m_eteso_pendientescaja, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_pendientescaja.Eliminado Then
				d_teso_pendientescaja.TESO_PCAJASD_UnReg(TESO_PendientesCaja)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_pendientescaja.Nuevo Then
				d_teso_pendientescaja.TESO_PCAJASI_UnReg(m_eteso_pendientescaja, x_usuario, x_setfecha)
			ElseIf m_eteso_pendientescaja.Modificado Then
				d_teso_pendientescaja.TESO_PCAJASU_UnReg(m_eteso_pendientescaja, x_usuario, x_setfecha)
			ElseIf m_eteso_pendientescaja.Eliminado Then
				d_teso_pendientescaja.TESO_PCAJASD_UnReg(TESO_PendientesCaja)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_pendientescaja.Nuevo Then
				d_teso_pendientescaja.TESO_PCAJASI_UnReg(m_eteso_pendientescaja, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_pendientescaja.Eliminado Then
				d_teso_pendientescaja.TESO_PCAJASD_UnReg(TESO_PendientesCaja)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_PendientesCaja = new List(Of ETESO_PendientesCaja)()
			return d_teso_pendientescaja.TESO_PCAJASD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_teso_pendientescaja.getCorrelativo("PCAJA_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_teso_pendientescaja.getCorrelativo("PCAJA_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_pendientescaja.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_pendientescaja.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_pendientescaja.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_pendientescaja.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

