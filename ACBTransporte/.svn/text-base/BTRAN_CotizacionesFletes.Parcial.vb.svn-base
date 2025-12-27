Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_CotizacionesFletes

#Region " Variables "
	
	Private m_tran_cotizacionesfletes As ETRAN_CotizacionesFletes
	Private m_listTRAN_CotizacionesFletes As List(Of ETRAN_CotizacionesFletes)
	Private m_dtTRAN_CotizacionesFletes As DataTable

	Private m_dsTRAN_CotizacionesFletes As DataSet
	Private d_tran_cotizacionesfletes As DTRAN_CotizacionesFletes 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_cotizacionesfletes = New DTRAN_CotizacionesFletes()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_CotizacionesFletes() As ETRAN_CotizacionesFletes 
		Get
			return m_tran_cotizacionesfletes
		End Get
		Set(ByVal value As ETRAN_CotizacionesFletes)
			m_tran_cotizacionesfletes = value
		End Set
	End Property

	Public Property ListTRAN_CotizacionesFletes() As List(Of ETRAN_CotizacionesFletes)
		Get
			return m_listTRAN_CotizacionesFletes
		End Get
		Set(ByVal value As List(Of ETRAN_CotizacionesFletes))
			m_listTRAN_CotizacionesFletes = value
		End Set
	End Property

	Public Property DTTRAN_CotizacionesFletes() As DataTable
		Get
			return m_dtTRAN_CotizacionesFletes
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_CotizacionesFletes = value
		End Set
	End Property

	Public Property DSTRAN_CotizacionesFletes() As DataSet
		Get
			return m_dsTRAN_CotizacionesFletes
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_CotizacionesFletes = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_CotizacionesFletes = new List(Of ETRAN_CotizacionesFletes)()
			return d_tran_cotizacionesfletes.TRAN_TRANSS_Todos(m_listTRAN_CotizacionesFletes)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_CotizacionesFletes = new List(Of ETRAN_CotizacionesFletes)()
			return d_tran_cotizacionesfletes.TRAN_TRANSS_Todos(m_listTRAN_CotizacionesFletes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_CotizacionesFletes = new List(Of ETRAN_CotizacionesFletes)()
			return d_tran_cotizacionesfletes.TRAN_TRANSS_Todos(m_listTRAN_CotizacionesFletes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_CotizacionesFletes = new List(Of ETRAN_CotizacionesFletes)()
			return d_tran_cotizacionesfletes.TRAN_TRANSS_Todos(m_listTRAN_CotizacionesFletes, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_CotizacionesFletes = new DataSet()
			return d_tran_cotizacionesfletes.TRAN_TRANSS_Todos(m_dsTRAN_CotizacionesFletes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_CotizacionesFletes = new DataSet()
			return d_tran_cotizacionesfletes.TRAN_TRANSS_Todos(m_dsTRAN_CotizacionesFletes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_CotizacionesFletes = new DataSet()
			Dim _opcion As Boolean = d_tran_cotizacionesfletes.TRAN_TRANSS_Todos(m_dsTRAN_CotizacionesFletes, x_where)
		If _opcion Then
			m_dtTRAN_CotizacionesFletes = m_dsTRAN_CotizacionesFletes.Tables(0)
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
			m_dsTRAN_CotizacionesFletes = new DataSet()
			Dim _opcion As Boolean = d_tran_cotizacionesfletes.TRAN_TRANSS_Todos(m_dsTRAN_CotizacionesFletes, x_join, x_where)
		If _opcion Then
			m_dtTRAN_CotizacionesFletes = m_dsTRAN_CotizacionesFletes.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_cotizacionesfletes.Nuevo Then
				d_tran_cotizacionesfletes.TRAN_TRANSI_UnReg(m_tran_cotizacionesfletes, x_usuario)
			ElseIf m_tran_cotizacionesfletes.Eliminado Then
				d_tran_cotizacionesfletes.TRAN_TRANSD_UnReg(TRAN_CotizacionesFletes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_cotizacionesfletes.Nuevo Then
				d_tran_cotizacionesfletes.TRAN_TRANSI_UnReg(m_tran_cotizacionesfletes, x_usuario)
			ElseIf m_tran_cotizacionesfletes.Eliminado Then
				d_tran_cotizacionesfletes.TRAN_TRANSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_cotizacionesfletes.Nuevo Then
				d_tran_cotizacionesfletes.TRAN_TRANSI_UnReg(m_tran_cotizacionesfletes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizacionesfletes.Eliminado Then
				d_tran_cotizacionesfletes.TRAN_TRANSD_UnReg(TRAN_CotizacionesFletes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_cotizacionesfletes.Nuevo Then
				d_tran_cotizacionesfletes.TRAN_TRANSI_UnReg(m_tran_cotizacionesfletes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizacionesfletes.Eliminado Then
				d_tran_cotizacionesfletes.TRAN_TRANSD_UnReg(TRAN_CotizacionesFletes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_cotizacionesfletes.Nuevo Then
				d_tran_cotizacionesfletes.TRAN_TRANSI_UnReg(m_tran_cotizacionesfletes, x_usuario, x_setfecha)
			ElseIf m_tran_cotizacionesfletes.Eliminado Then
				d_tran_cotizacionesfletes.TRAN_TRANSD_UnReg(TRAN_CotizacionesFletes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_cotizacionesfletes.Nuevo Then
				d_tran_cotizacionesfletes.TRAN_TRANSI_UnReg(m_tran_cotizacionesfletes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizacionesfletes.Eliminado Then
				d_tran_cotizacionesfletes.TRAN_TRANSD_UnReg(TRAN_CotizacionesFletes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_CotizacionesFletes = new List(Of ETRAN_CotizacionesFletes)()
			return d_tran_cotizacionesfletes.TRAN_TRANSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_cotizacionesfletes.getCorrelativo("FLETE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_cotizacionesfletes.getCorrelativo("FLETE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_cotizacionesfletes.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_cotizacionesfletes.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_cotizacionesfletes.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_cotizacionesfletes.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

