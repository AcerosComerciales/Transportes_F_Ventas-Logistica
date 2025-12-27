Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_GuiasTransportista

#Region " Variables "
	
	Private m_tran_guiastransportista As ETRAN_GuiasTransportista
	Private m_listTRAN_GuiasTransportista As List(Of ETRAN_GuiasTransportista)
	Private m_dtTRAN_GuiasTransportista As DataTable

	Private m_dsTRAN_GuiasTransportista As DataSet
	Private d_tran_guiastransportista As DTRAN_GuiasTransportista 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_guiastransportista = New DTRAN_GuiasTransportista()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_GuiasTransportista() As ETRAN_GuiasTransportista 
		Get
			return m_tran_guiastransportista
		End Get
		Set(ByVal value As ETRAN_GuiasTransportista)
			m_tran_guiastransportista = value
		End Set
	End Property
	Public Property ListTRAN_GuiasTransportista() As List(Of ETRAN_GuiasTransportista)
		Get
			return m_listTRAN_GuiasTransportista
		End Get
		Set(ByVal value As List(Of ETRAN_GuiasTransportista))
			m_listTRAN_GuiasTransportista = value
		End Set
	End Property
	Public Property DTTRAN_GuiasTransportista() As DataTable
		Get
			return m_dtTRAN_GuiasTransportista
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_GuiasTransportista = value
		End Set
	End Property
	Public Property DSTRAN_GuiasTransportista() As DataSet
		Get
			return m_dsTRAN_GuiasTransportista
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_GuiasTransportista = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_GuiasTransportista() As List(Of ETRAN_GuiasTransportista)
			Return Me.m_listTRAN_GuiasTransportista
		End Function
		Public Sub setListTRAN_GuiasTransportista(ByVal _listtran_guiastransportista As List (Of ETRAN_GuiasTransportista))
			Me.m_listTRAN_GuiasTransportista = m_listtran_guiastransportista 
		End Sub
		Public Function getTRAN_GuiasTransportista() As ETRAN_GuiasTransportista
			Return Me.m_tran_guiastransportista
		End Function
		Public Sub setTRAN_GuiasTransportista(ByVal x_tran_guiastransportista As ETRAN_GuiasTransportista)
			Me.m_tran_guiastransportista = x_tran_guiastransportista 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_GuiasTransportista = new List(Of ETRAN_GuiasTransportista)()
			return d_tran_guiastransportista.TRAN_GTRANSS_Todos(m_listTRAN_GuiasTransportista)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_GuiasTransportista = new List(Of ETRAN_GuiasTransportista)()
			return d_tran_guiastransportista.TRAN_GTRANSS_Todos(m_listTRAN_GuiasTransportista, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_GuiasTransportista = new List(Of ETRAN_GuiasTransportista)()
			return d_tran_guiastransportista.TRAN_GTRANSS_Todos(m_listTRAN_GuiasTransportista, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_GuiasTransportista = new List(Of ETRAN_GuiasTransportista)()
			return d_tran_guiastransportista.TRAN_GTRANSS_Todos(m_listTRAN_GuiasTransportista, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_GuiasTransportista = new DataSet()
			return d_tran_guiastransportista.TRAN_GTRANSS_Todos(m_dsTRAN_GuiasTransportista, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_GuiasTransportista = new DataSet()
			return d_tran_guiastransportista.TRAN_GTRANSS_Todos(m_dsTRAN_GuiasTransportista, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_GuiasTransportista = new DataSet()
			Dim _opcion As Boolean = d_tran_guiastransportista.TRAN_GTRANSS_Todos(m_dsTRAN_GuiasTransportista, x_where)
		If _opcion Then
			m_dtTRAN_GuiasTransportista = m_dsTRAN_GuiasTransportista.Tables(0)
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
			m_dsTRAN_GuiasTransportista = new DataSet()
			Dim _opcion As Boolean = d_tran_guiastransportista.TRAN_GTRANSS_Todos(m_dsTRAN_GuiasTransportista, x_join, x_where)
		If _opcion Then
			m_dtTRAN_GuiasTransportista = m_dsTRAN_GuiasTransportista.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_gtran_codigo As String) As Boolean
		Try
			m_tran_guiastransportista = New ETRAN_GuiasTransportista()
			Return d_tran_guiastransportista.TRAN_GTRANSS_UnReg(m_tran_guiastransportista, x_gtran_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_guiastransportista = New ETRAN_GuiasTransportista()
			Return d_tran_guiastransportista.TRAN_GTRANSS_UnReg(m_tran_guiastransportista, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_guiastransportista = New ETRAN_GuiasTransportista()
			Return d_tran_guiastransportista.TRAN_GTRANSS_UnReg(m_tran_guiastransportista, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_guiastransportista.Nuevo Then
				d_tran_guiastransportista.TRAN_GTRANSI_UnReg(m_tran_guiastransportista, x_usuario)
			ElseIf m_tran_guiastransportista.Modificado Then
				d_tran_guiastransportista.TRAN_GTRANSU_UnReg(m_tran_guiastransportista, x_usuario)
			ElseIf m_tran_guiastransportista.Eliminado Then
				d_tran_guiastransportista.TRAN_GTRANSD_UnReg(m_tran_guiastransportista)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_guiastransportista.Nuevo Then
				d_tran_guiastransportista.TRAN_GTRANSI_UnReg(m_tran_guiastransportista, x_usuario)
			ElseIf m_tran_guiastransportista.Modificado Then
				d_tran_guiastransportista.TRAN_GTRANSU_UnReg(m_tran_guiastransportista, x_where, x_usuario)
			ElseIf m_tran_guiastransportista.Eliminado Then
				d_tran_guiastransportista.TRAN_GTRANSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_guiastransportista.Nuevo Then
				d_tran_guiastransportista.TRAN_GTRANSI_UnReg(m_tran_guiastransportista, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_guiastransportista.Modificado Then
				d_tran_guiastransportista.TRAN_GTRANSU_UnReg(m_tran_guiastransportista, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_guiastransportista.Eliminado Then
				d_tran_guiastransportista.TRAN_GTRANSD_UnReg(m_tran_guiastransportista)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_guiastransportista.Nuevo Then
				d_tran_guiastransportista.TRAN_GTRANSI_UnReg(m_tran_guiastransportista, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_guiastransportista.Modificado Then
				d_tran_guiastransportista.TRAN_GTRANSU_UnReg(m_tran_guiastransportista, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_guiastransportista.Eliminado Then
				d_tran_guiastransportista.TRAN_GTRANSD_UnReg(m_tran_guiastransportista)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_guiastransportista.Nuevo Then
				d_tran_guiastransportista.TRAN_GTRANSI_UnReg(m_tran_guiastransportista, x_usuario, x_setfecha)
			ElseIf m_tran_guiastransportista.Modificado Then
				d_tran_guiastransportista.TRAN_GTRANSU_UnReg(m_tran_guiastransportista, x_usuario, x_setfecha)
			ElseIf m_tran_guiastransportista.Eliminado Then
				d_tran_guiastransportista.TRAN_GTRANSD_UnReg(m_tran_guiastransportista)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_guiastransportista.Nuevo Then
				d_tran_guiastransportista.TRAN_GTRANSI_UnReg(m_tran_guiastransportista, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_guiastransportista.Eliminado Then
				d_tran_guiastransportista.TRAN_GTRANSD_UnReg(m_tran_guiastransportista)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_GuiasTransportista = new List(Of ETRAN_GuiasTransportista)()
			return d_tran_guiastransportista.TRAN_GTRANSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_guiastransportista.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_guiastransportista.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_guiastransportista.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_guiastransportista.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

