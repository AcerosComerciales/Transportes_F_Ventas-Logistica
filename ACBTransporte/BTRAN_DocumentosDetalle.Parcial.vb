Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_DocumentosDetalle

#Region " Variables "
	
	Private m_tran_documentosdetalle As ETRAN_DocumentosDetalle
	Private m_listTRAN_DocumentosDetalle As List(Of ETRAN_DocumentosDetalle)
	Private m_dtTRAN_DocumentosDetalle As DataTable

	Private m_dsTRAN_DocumentosDetalle As DataSet
	Private d_tran_documentosdetalle As DTRAN_DocumentosDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_documentosdetalle = New DTRAN_DocumentosDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_DocumentosDetalle() As ETRAN_DocumentosDetalle 
		Get
			return m_tran_documentosdetalle
		End Get
		Set(ByVal value As ETRAN_DocumentosDetalle)
			m_tran_documentosdetalle = value
		End Set
	End Property
	Public Property ListTRAN_DocumentosDetalle() As List(Of ETRAN_DocumentosDetalle)
		Get
			return m_listTRAN_DocumentosDetalle
		End Get
		Set(ByVal value As List(Of ETRAN_DocumentosDetalle))
			m_listTRAN_DocumentosDetalle = value
		End Set
	End Property
	Public Property DTTRAN_DocumentosDetalle() As DataTable
		Get
			return m_dtTRAN_DocumentosDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_DocumentosDetalle = value
		End Set
	End Property
	Public Property DSTRAN_DocumentosDetalle() As DataSet
		Get
			return m_dsTRAN_DocumentosDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_DocumentosDetalle = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_DocumentosDetalle() As List(Of ETRAN_DocumentosDetalle)
			Return Me.m_listTRAN_DocumentosDetalle
		End Function
		Public Sub setListTRAN_DocumentosDetalle(ByVal _listtran_documentosdetalle As List (Of ETRAN_DocumentosDetalle))
			Me.m_listTRAN_DocumentosDetalle = m_listtran_documentosdetalle 
		End Sub
		Public Function getTRAN_DocumentosDetalle() As ETRAN_DocumentosDetalle
			Return Me.m_tran_documentosdetalle
		End Function
		Public Sub setTRAN_DocumentosDetalle(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle)
			Me.m_tran_documentosdetalle = x_tran_documentosdetalle 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_DocumentosDetalle = new List(Of ETRAN_DocumentosDetalle)()
			return d_tran_documentosdetalle.TRAN_DCDETSS_Todos(m_listTRAN_DocumentosDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_DocumentosDetalle = new List(Of ETRAN_DocumentosDetalle)()
			return d_tran_documentosdetalle.TRAN_DCDETSS_Todos(m_listTRAN_DocumentosDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_DocumentosDetalle = new List(Of ETRAN_DocumentosDetalle)()
			return d_tran_documentosdetalle.TRAN_DCDETSS_Todos(m_listTRAN_DocumentosDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_DocumentosDetalle = new List(Of ETRAN_DocumentosDetalle)()
			return d_tran_documentosdetalle.TRAN_DCDETSS_Todos(m_listTRAN_DocumentosDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String) As Boolean
		Try
			m_listTRAN_DocumentosDetalle = new List(Of ETRAN_DocumentosDetalle)()
			Return d_tran_documentosdetalle.TRAN_DCDETSS_Todos(m_listTRAN_DocumentosDetalle, x_docus_codigo, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_DocumentosDetalle = new DataSet()
			return d_tran_documentosdetalle.TRAN_DCDETSS_Todos(m_dsTRAN_DocumentosDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_DocumentosDetalle = new DataSet()
			return d_tran_documentosdetalle.TRAN_DCDETSS_Todos(m_dsTRAN_DocumentosDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_DocumentosDetalle = new DataSet()
			Dim _opcion As Boolean = d_tran_documentosdetalle.TRAN_DCDETSS_Todos(m_dsTRAN_DocumentosDetalle, x_where)
		If _opcion Then
			m_dtTRAN_DocumentosDetalle = m_dsTRAN_DocumentosDetalle.Tables(0)
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
			m_dsTRAN_DocumentosDetalle = new DataSet()
			Dim _opcion As Boolean = d_tran_documentosdetalle.TRAN_DCDETSS_Todos(m_dsTRAN_DocumentosDetalle, x_join, x_where)
		If _opcion Then
			m_dtTRAN_DocumentosDetalle = m_dsTRAN_DocumentosDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docus_codigo As String, x_entid_codigo As String, x_dcdet_item As Short) As Boolean
		Try
			m_tran_documentosdetalle = New ETRAN_DocumentosDetalle()
			Return d_tran_documentosdetalle.TRAN_DCDETSS_UnReg(m_tran_documentosdetalle, x_docus_codigo, x_entid_codigo, x_dcdet_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_documentosdetalle = New ETRAN_DocumentosDetalle()
			Return d_tran_documentosdetalle.TRAN_DCDETSS_UnReg(m_tran_documentosdetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_documentosdetalle = New ETRAN_DocumentosDetalle()
			Return d_tran_documentosdetalle.TRAN_DCDETSS_UnReg(m_tran_documentosdetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_documentosdetalle.Nuevo Then
				d_tran_documentosdetalle.TRAN_DCDETSI_UnReg(m_tran_documentosdetalle, x_usuario)
			ElseIf m_tran_documentosdetalle.Modificado Then
				d_tran_documentosdetalle.TRAN_DCDETSU_UnReg(m_tran_documentosdetalle, x_usuario)
			ElseIf m_tran_documentosdetalle.Eliminado Then
				d_tran_documentosdetalle.TRAN_DCDETSD_UnReg(m_tran_documentosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_documentosdetalle.Nuevo Then
				d_tran_documentosdetalle.TRAN_DCDETSI_UnReg(m_tran_documentosdetalle, x_usuario)
			ElseIf m_tran_documentosdetalle.Modificado Then
				d_tran_documentosdetalle.TRAN_DCDETSU_UnReg(m_tran_documentosdetalle, x_where, x_usuario)
			ElseIf m_tran_documentosdetalle.Eliminado Then
				d_tran_documentosdetalle.TRAN_DCDETSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_documentosdetalle.Nuevo Then
				d_tran_documentosdetalle.TRAN_DCDETSI_UnReg(m_tran_documentosdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_documentosdetalle.Modificado Then
				d_tran_documentosdetalle.TRAN_DCDETSU_UnReg(m_tran_documentosdetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_documentosdetalle.Eliminado Then
				d_tran_documentosdetalle.TRAN_DCDETSD_UnReg(m_tran_documentosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_documentosdetalle.Nuevo Then
				d_tran_documentosdetalle.TRAN_DCDETSI_UnReg(m_tran_documentosdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_documentosdetalle.Modificado Then
				d_tran_documentosdetalle.TRAN_DCDETSU_UnReg(m_tran_documentosdetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_documentosdetalle.Eliminado Then
				d_tran_documentosdetalle.TRAN_DCDETSD_UnReg(m_tran_documentosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_documentosdetalle.Nuevo Then
				d_tran_documentosdetalle.TRAN_DCDETSI_UnReg(m_tran_documentosdetalle, x_usuario, x_setfecha)
			ElseIf m_tran_documentosdetalle.Modificado Then
				d_tran_documentosdetalle.TRAN_DCDETSU_UnReg(m_tran_documentosdetalle, x_usuario, x_setfecha)
			ElseIf m_tran_documentosdetalle.Eliminado Then
				d_tran_documentosdetalle.TRAN_DCDETSD_UnReg(m_tran_documentosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_documentosdetalle.Nuevo Then
				d_tran_documentosdetalle.TRAN_DCDETSI_UnReg(m_tran_documentosdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_documentosdetalle.Eliminado Then
				d_tran_documentosdetalle.TRAN_DCDETSD_UnReg(m_tran_documentosdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_DocumentosDetalle = new List(Of ETRAN_DocumentosDetalle)()
			return d_tran_documentosdetalle.TRAN_DCDETSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_documentosdetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_documentosdetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_documentosdetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_documentosdetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

