Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_GuiasTransportistaDetalles

#Region " Variables "
	
	Private m_tran_guiastransportistadetalles As ETRAN_GuiasTransportistaDetalles
	Private m_listTRAN_GuiasTransportistaDetalles As List(Of ETRAN_GuiasTransportistaDetalles)
	Private m_dtTRAN_GuiasTransportistaDetalles As DataTable

	Private m_dsTRAN_GuiasTransportistaDetalles As DataSet
	Private d_tran_guiastransportistadetalles As DTRAN_GuiasTransportistaDetalles 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_guiastransportistadetalles = New DTRAN_GuiasTransportistaDetalles()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_GuiasTransportistaDetalles() As ETRAN_GuiasTransportistaDetalles 
		Get
			return m_tran_guiastransportistadetalles
		End Get
		Set(ByVal value As ETRAN_GuiasTransportistaDetalles)
			m_tran_guiastransportistadetalles = value
		End Set
	End Property
	Public Property ListTRAN_GuiasTransportistaDetalles() As List(Of ETRAN_GuiasTransportistaDetalles)
		Get
			return m_listTRAN_GuiasTransportistaDetalles
		End Get
		Set(ByVal value As List(Of ETRAN_GuiasTransportistaDetalles))
			m_listTRAN_GuiasTransportistaDetalles = value
		End Set
	End Property
	Public Property DTTRAN_GuiasTransportistaDetalles() As DataTable
		Get
			return m_dtTRAN_GuiasTransportistaDetalles
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_GuiasTransportistaDetalles = value
		End Set
	End Property
	Public Property DSTRAN_GuiasTransportistaDetalles() As DataSet
		Get
			return m_dsTRAN_GuiasTransportistaDetalles
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_GuiasTransportistaDetalles = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_GuiasTransportistaDetalles() As List(Of ETRAN_GuiasTransportistaDetalles)
			Return Me.m_listTRAN_GuiasTransportistaDetalles
		End Function
		Public Sub setListTRAN_GuiasTransportistaDetalles(ByVal _listtran_guiastransportistadetalles As List (Of ETRAN_GuiasTransportistaDetalles))
			Me.m_listTRAN_GuiasTransportistaDetalles = m_listtran_guiastransportistadetalles 
		End Sub
		Public Function getTRAN_GuiasTransportistaDetalles() As ETRAN_GuiasTransportistaDetalles
			Return Me.m_tran_guiastransportistadetalles
		End Function
		Public Sub setTRAN_GuiasTransportistaDetalles(ByVal x_tran_guiastransportistadetalles As ETRAN_GuiasTransportistaDetalles)
			Me.m_tran_guiastransportistadetalles = x_tran_guiastransportistadetalles 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_GuiasTransportistaDetalles = new List(Of ETRAN_GuiasTransportistaDetalles)()
			return d_tran_guiastransportistadetalles.TRAN_GTDETSS_Todos(m_listTRAN_GuiasTransportistaDetalles)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_GuiasTransportistaDetalles = new List(Of ETRAN_GuiasTransportistaDetalles)()
			return d_tran_guiastransportistadetalles.TRAN_GTDETSS_Todos(m_listTRAN_GuiasTransportistaDetalles, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_GuiasTransportistaDetalles = new List(Of ETRAN_GuiasTransportistaDetalles)()
			return d_tran_guiastransportistadetalles.TRAN_GTDETSS_Todos(m_listTRAN_GuiasTransportistaDetalles, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_GuiasTransportistaDetalles = new List(Of ETRAN_GuiasTransportistaDetalles)()
			return d_tran_guiastransportistadetalles.TRAN_GTDETSS_Todos(m_listTRAN_GuiasTransportistaDetalles, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_gtran_codigo As String) As Boolean
		Try
			m_listTRAN_GuiasTransportistaDetalles = new List(Of ETRAN_GuiasTransportistaDetalles)()
			Return d_tran_guiastransportistadetalles.TRAN_GTDETSS_Todos(m_listTRAN_GuiasTransportistaDetalles, x_gtran_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_GuiasTransportistaDetalles = new DataSet()
			return d_tran_guiastransportistadetalles.TRAN_GTDETSS_Todos(m_dsTRAN_GuiasTransportistaDetalles, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_GuiasTransportistaDetalles = new DataSet()
			return d_tran_guiastransportistadetalles.TRAN_GTDETSS_Todos(m_dsTRAN_GuiasTransportistaDetalles, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_GuiasTransportistaDetalles = new DataSet()
			Dim _opcion As Boolean = d_tran_guiastransportistadetalles.TRAN_GTDETSS_Todos(m_dsTRAN_GuiasTransportistaDetalles, x_where)
		If _opcion Then
			m_dtTRAN_GuiasTransportistaDetalles = m_dsTRAN_GuiasTransportistaDetalles.Tables(0)
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
			m_dsTRAN_GuiasTransportistaDetalles = new DataSet()
			Dim _opcion As Boolean = d_tran_guiastransportistadetalles.TRAN_GTDETSS_Todos(m_dsTRAN_GuiasTransportistaDetalles, x_join, x_where)
		If _opcion Then
			m_dtTRAN_GuiasTransportistaDetalles = m_dsTRAN_GuiasTransportistaDetalles.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_gtran_codigo As String, x_gtdet_item As Short) As Boolean
		Try
			m_tran_guiastransportistadetalles = New ETRAN_GuiasTransportistaDetalles()
			Return d_tran_guiastransportistadetalles.TRAN_GTDETSS_UnReg(m_tran_guiastransportistadetalles, x_gtran_codigo, x_gtdet_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_guiastransportistadetalles = New ETRAN_GuiasTransportistaDetalles()
			Return d_tran_guiastransportistadetalles.TRAN_GTDETSS_UnReg(m_tran_guiastransportistadetalles, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_guiastransportistadetalles = New ETRAN_GuiasTransportistaDetalles()
			Return d_tran_guiastransportistadetalles.TRAN_GTDETSS_UnReg(m_tran_guiastransportistadetalles, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_guiastransportistadetalles.Nuevo Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSI_UnReg(m_tran_guiastransportistadetalles, x_usuario)
			ElseIf m_tran_guiastransportistadetalles.Modificado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSU_UnReg(m_tran_guiastransportistadetalles, x_usuario)
			ElseIf m_tran_guiastransportistadetalles.Eliminado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSD_UnReg(m_tran_guiastransportistadetalles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_guiastransportistadetalles.Nuevo Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSI_UnReg(m_tran_guiastransportistadetalles, x_usuario)
			ElseIf m_tran_guiastransportistadetalles.Modificado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSU_UnReg(m_tran_guiastransportistadetalles, x_where, x_usuario)
			ElseIf m_tran_guiastransportistadetalles.Eliminado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_guiastransportistadetalles.Nuevo Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSI_UnReg(m_tran_guiastransportistadetalles, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_guiastransportistadetalles.Modificado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSU_UnReg(m_tran_guiastransportistadetalles, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_guiastransportistadetalles.Eliminado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSD_UnReg(m_tran_guiastransportistadetalles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_guiastransportistadetalles.Nuevo Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSI_UnReg(m_tran_guiastransportistadetalles, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_guiastransportistadetalles.Modificado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSU_UnReg(m_tran_guiastransportistadetalles, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_guiastransportistadetalles.Eliminado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSD_UnReg(m_tran_guiastransportistadetalles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_guiastransportistadetalles.Nuevo Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSI_UnReg(m_tran_guiastransportistadetalles, x_usuario, x_setfecha)
			ElseIf m_tran_guiastransportistadetalles.Modificado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSU_UnReg(m_tran_guiastransportistadetalles, x_usuario, x_setfecha)
			ElseIf m_tran_guiastransportistadetalles.Eliminado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSD_UnReg(m_tran_guiastransportistadetalles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_guiastransportistadetalles.Nuevo Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSI_UnReg(m_tran_guiastransportistadetalles, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_guiastransportistadetalles.Eliminado Then
				d_tran_guiastransportistadetalles.TRAN_GTDETSD_UnReg(m_tran_guiastransportistadetalles)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_GuiasTransportistaDetalles = new List(Of ETRAN_GuiasTransportistaDetalles)()
			return d_tran_guiastransportistadetalles.TRAN_GTDETSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_guiastransportistadetalles.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_guiastransportistadetalles.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_guiastransportistadetalles.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_guiastransportistadetalles.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

