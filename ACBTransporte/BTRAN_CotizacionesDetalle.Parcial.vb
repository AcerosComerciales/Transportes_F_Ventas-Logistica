Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_CotizacionesDetalle

#Region " Variables "
	
	Private m_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle
	Private m_listTRAN_CotizacionesDetalle As List(Of ETRAN_CotizacionesDetalle)
	Private m_dtTRAN_CotizacionesDetalle As DataTable

	Private m_dsTRAN_CotizacionesDetalle As DataSet
	Private d_tran_cotizacionesdetalle As DTRAN_CotizacionesDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_cotizacionesdetalle = New DTRAN_CotizacionesDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_CotizacionesDetalle() As ETRAN_CotizacionesDetalle 
		Get
			return m_tran_cotizacionesdetalle
		End Get
		Set(ByVal value As ETRAN_CotizacionesDetalle)
			m_tran_cotizacionesdetalle = value
		End Set
	End Property
	Public Property ListTRAN_CotizacionesDetalle() As List(Of ETRAN_CotizacionesDetalle)
		Get
			return m_listTRAN_CotizacionesDetalle
		End Get
		Set(ByVal value As List(Of ETRAN_CotizacionesDetalle))
			m_listTRAN_CotizacionesDetalle = value
		End Set
	End Property
	Public Property DTTRAN_CotizacionesDetalle() As DataTable
		Get
			return m_dtTRAN_CotizacionesDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_CotizacionesDetalle = value
		End Set
	End Property
	Public Property DSTRAN_CotizacionesDetalle() As DataSet
		Get
			return m_dsTRAN_CotizacionesDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_CotizacionesDetalle = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_CotizacionesDetalle() As List(Of ETRAN_CotizacionesDetalle)
			Return Me.m_listTRAN_CotizacionesDetalle
		End Function
		Public Sub setListTRAN_CotizacionesDetalle(ByVal _listtran_cotizacionesdetalle As List (Of ETRAN_CotizacionesDetalle))
			Me.m_listTRAN_CotizacionesDetalle = m_listtran_cotizacionesdetalle 
		End Sub
		Public Function getTRAN_CotizacionesDetalle() As ETRAN_CotizacionesDetalle
			Return Me.m_tran_cotizacionesdetalle
		End Function
		Public Sub setTRAN_CotizacionesDetalle(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle)
			Me.m_tran_cotizacionesdetalle = x_tran_cotizacionesdetalle 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_CotizacionesDetalle = new List(Of ETRAN_CotizacionesDetalle)()
			return d_tran_cotizacionesdetalle.TRAN_COTDTSS_Todos(m_listTRAN_CotizacionesDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_CotizacionesDetalle = new List(Of ETRAN_CotizacionesDetalle)()
			return d_tran_cotizacionesdetalle.TRAN_COTDTSS_Todos(m_listTRAN_CotizacionesDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_CotizacionesDetalle = new List(Of ETRAN_CotizacionesDetalle)()
			return d_tran_cotizacionesdetalle.TRAN_COTDTSS_Todos(m_listTRAN_CotizacionesDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_CotizacionesDetalle = new List(Of ETRAN_CotizacionesDetalle)()
			return d_tran_cotizacionesdetalle.TRAN_COTDTSS_Todos(m_listTRAN_CotizacionesDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_cotiz_codigo As String) As Boolean
		Try
			m_listTRAN_CotizacionesDetalle = new List(Of ETRAN_CotizacionesDetalle)()
			Return d_tran_cotizacionesdetalle.TRAN_COTDTSS_Todos(m_listTRAN_CotizacionesDetalle, x_cotiz_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_CotizacionesDetalle = new DataSet()
			return d_tran_cotizacionesdetalle.TRAN_COTDTSS_Todos(m_dsTRAN_CotizacionesDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_CotizacionesDetalle = new DataSet()
			return d_tran_cotizacionesdetalle.TRAN_COTDTSS_Todos(m_dsTRAN_CotizacionesDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_CotizacionesDetalle = new DataSet()
			Dim _opcion As Boolean = d_tran_cotizacionesdetalle.TRAN_COTDTSS_Todos(m_dsTRAN_CotizacionesDetalle, x_where)
		If _opcion Then
			m_dtTRAN_CotizacionesDetalle = m_dsTRAN_CotizacionesDetalle.Tables(0)
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
			m_dsTRAN_CotizacionesDetalle = new DataSet()
			Dim _opcion As Boolean = d_tran_cotizacionesdetalle.TRAN_COTDTSS_Todos(m_dsTRAN_CotizacionesDetalle, x_join, x_where)
		If _opcion Then
			m_dtTRAN_CotizacionesDetalle = m_dsTRAN_CotizacionesDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_cotiz_codigo As String, x_cotdt_item As Short) As Boolean
		Try
			m_tran_cotizacionesdetalle = New ETRAN_CotizacionesDetalle()
			Return d_tran_cotizacionesdetalle.TRAN_COTDTSS_UnReg(m_tran_cotizacionesdetalle, x_cotiz_codigo, x_cotdt_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_cotizacionesdetalle = New ETRAN_CotizacionesDetalle()
			Return d_tran_cotizacionesdetalle.TRAN_COTDTSS_UnReg(m_tran_cotizacionesdetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_cotizacionesdetalle = New ETRAN_CotizacionesDetalle()
			Return d_tran_cotizacionesdetalle.TRAN_COTDTSS_UnReg(m_tran_cotizacionesdetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_cotizacionesdetalle.Nuevo Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSI_UnReg(m_tran_cotizacionesdetalle, x_usuario)
			ElseIf m_tran_cotizacionesdetalle.Modificado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSU_UnReg(m_tran_cotizacionesdetalle, x_usuario)
			ElseIf m_tran_cotizacionesdetalle.Eliminado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSD_UnReg(m_tran_cotizacionesdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_cotizacionesdetalle.Nuevo Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSI_UnReg(m_tran_cotizacionesdetalle, x_usuario)
			ElseIf m_tran_cotizacionesdetalle.Modificado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSU_UnReg(m_tran_cotizacionesdetalle, x_where, x_usuario)
			ElseIf m_tran_cotizacionesdetalle.Eliminado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_cotizacionesdetalle.Nuevo Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSI_UnReg(m_tran_cotizacionesdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizacionesdetalle.Modificado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSU_UnReg(m_tran_cotizacionesdetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizacionesdetalle.Eliminado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSD_UnReg(m_tran_cotizacionesdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_cotizacionesdetalle.Nuevo Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSI_UnReg(m_tran_cotizacionesdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizacionesdetalle.Modificado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSU_UnReg(m_tran_cotizacionesdetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_cotizacionesdetalle.Eliminado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSD_UnReg(m_tran_cotizacionesdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_cotizacionesdetalle.Nuevo Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSI_UnReg(m_tran_cotizacionesdetalle, x_usuario, x_setfecha)
			ElseIf m_tran_cotizacionesdetalle.Modificado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSU_UnReg(m_tran_cotizacionesdetalle, x_usuario, x_setfecha)
			ElseIf m_tran_cotizacionesdetalle.Eliminado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSD_UnReg(m_tran_cotizacionesdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_cotizacionesdetalle.Nuevo Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSI_UnReg(m_tran_cotizacionesdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_cotizacionesdetalle.Eliminado Then
				d_tran_cotizacionesdetalle.TRAN_COTDTSD_UnReg(m_tran_cotizacionesdetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_CotizacionesDetalle = new List(Of ETRAN_CotizacionesDetalle)()
			return d_tran_cotizacionesdetalle.TRAN_COTDTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_cotizacionesdetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_cotizacionesdetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_cotizacionesdetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_cotizacionesdetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

