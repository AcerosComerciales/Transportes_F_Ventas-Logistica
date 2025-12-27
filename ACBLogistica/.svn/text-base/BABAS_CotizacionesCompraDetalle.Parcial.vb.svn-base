Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_CotizacionesCompraDetalle

#Region " Variables "
	
	Private m_abas_cotizacionescompradetalle As EABAS_CotizacionesCompraDetalle
	Private m_listABAS_CotizacionesCompraDetalle As List(Of EABAS_CotizacionesCompraDetalle)
	Private m_dtABAS_CotizacionesCompraDetalle As DataTable

	Private m_dsABAS_CotizacionesCompraDetalle As DataSet
	Private d_abas_cotizacionescompradetalle As DABAS_CotizacionesCompraDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_cotizacionescompradetalle = New DABAS_CotizacionesCompraDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_CotizacionesCompraDetalle() As EABAS_CotizacionesCompraDetalle 
		Get
			return m_abas_cotizacionescompradetalle
		End Get
		Set(ByVal value As EABAS_CotizacionesCompraDetalle)
			m_abas_cotizacionescompradetalle = value
		End Set
	End Property
	Public Property ListABAS_CotizacionesCompraDetalle() As List(Of EABAS_CotizacionesCompraDetalle)
		Get
			return m_listABAS_CotizacionesCompraDetalle
		End Get
		Set(ByVal value As List(Of EABAS_CotizacionesCompraDetalle))
			m_listABAS_CotizacionesCompraDetalle = value
		End Set
	End Property
	Public Property DTABAS_CotizacionesCompraDetalle() As DataTable
		Get
			return m_dtABAS_CotizacionesCompraDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_CotizacionesCompraDetalle = value
		End Set
	End Property
	Public Property DSABAS_CotizacionesCompraDetalle() As DataSet
		Get
			return m_dsABAS_CotizacionesCompraDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_CotizacionesCompraDetalle = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListABAS_CotizacionesCompraDetalle() As List(Of EABAS_CotizacionesCompraDetalle)
			Return Me.m_listABAS_CotizacionesCompraDetalle
		End Function
		Public Sub setListABAS_CotizacionesCompraDetalle(ByVal _listabas_cotizacionescompradetalle As List (Of EABAS_CotizacionesCompraDetalle))
			Me.m_listABAS_CotizacionesCompraDetalle = m_listabas_cotizacionescompradetalle 
		End Sub
		Public Function getABAS_CotizacionesCompraDetalle() As EABAS_CotizacionesCompraDetalle
			Return Me.m_abas_cotizacionescompradetalle
		End Function
		Public Sub setABAS_CotizacionesCompraDetalle(ByVal x_abas_cotizacionescompradetalle As EABAS_CotizacionesCompraDetalle)
			Me.m_abas_cotizacionescompradetalle = x_abas_cotizacionescompradetalle 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_CotizacionesCompraDetalle = new List(Of EABAS_CotizacionesCompraDetalle)()
			return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_Todos(m_listABAS_CotizacionesCompraDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_CotizacionesCompraDetalle = new List(Of EABAS_CotizacionesCompraDetalle)()
			return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_Todos(m_listABAS_CotizacionesCompraDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_CotizacionesCompraDetalle = new List(Of EABAS_CotizacionesCompraDetalle)()
			return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_Todos(m_listABAS_CotizacionesCompraDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_CotizacionesCompraDetalle = new List(Of EABAS_CotizacionesCompraDetalle)()
			return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_Todos(m_listABAS_CotizacionesCompraDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_cotco_codigo As String) As Boolean
		Try
			m_listABAS_CotizacionesCompraDetalle = new List(Of EABAS_CotizacionesCompraDetalle)()
			Return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_Todos(m_listABAS_CotizacionesCompraDetalle, x_cotco_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_CotizacionesCompraDetalle = new DataSet()
			return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_Todos(m_dsABAS_CotizacionesCompraDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_CotizacionesCompraDetalle = new DataSet()
			return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_Todos(m_dsABAS_CotizacionesCompraDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_CotizacionesCompraDetalle = new DataSet()
			Dim _opcion As Boolean = d_abas_cotizacionescompradetalle.ABAS_COTCDSS_Todos(m_dsABAS_CotizacionesCompraDetalle, x_where)
		If _opcion Then
			m_dtABAS_CotizacionesCompraDetalle = m_dsABAS_CotizacionesCompraDetalle.Tables(0)
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
			m_dsABAS_CotizacionesCompraDetalle = new DataSet()
			Dim _opcion As Boolean = d_abas_cotizacionescompradetalle.ABAS_COTCDSS_Todos(m_dsABAS_CotizacionesCompraDetalle, x_join, x_where)
		If _opcion Then
			m_dtABAS_CotizacionesCompraDetalle = m_dsABAS_CotizacionesCompraDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_cotco_codigo As String, x_cotcd_item As Short) As Boolean
		Try
			m_abas_cotizacionescompradetalle = New EABAS_CotizacionesCompraDetalle()
			Return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_UnReg(m_abas_cotizacionescompradetalle, x_cotco_codigo, x_cotcd_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_abas_cotizacionescompradetalle = New EABAS_CotizacionesCompraDetalle()
			Return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_UnReg(m_abas_cotizacionescompradetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_abas_cotizacionescompradetalle = New EABAS_CotizacionesCompraDetalle()
			Return d_abas_cotizacionescompradetalle.ABAS_COTCDSS_UnReg(m_abas_cotizacionescompradetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_abas_cotizacionescompradetalle.Nuevo Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSI_UnReg(m_abas_cotizacionescompradetalle, x_usuario)
			ElseIf m_abas_cotizacionescompradetalle.Modificado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSU_UnReg(m_abas_cotizacionescompradetalle, x_usuario)
			ElseIf m_abas_cotizacionescompradetalle.Eliminado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSD_UnReg(m_abas_cotizacionescompradetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_abas_cotizacionescompradetalle.Nuevo Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSI_UnReg(m_abas_cotizacionescompradetalle, x_usuario)
			ElseIf m_abas_cotizacionescompradetalle.Modificado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSU_UnReg(m_abas_cotizacionescompradetalle, x_where, x_usuario)
			ElseIf m_abas_cotizacionescompradetalle.Eliminado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_cotizacionescompradetalle.Nuevo Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSI_UnReg(m_abas_cotizacionescompradetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_cotizacionescompradetalle.Modificado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSU_UnReg(m_abas_cotizacionescompradetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_cotizacionescompradetalle.Eliminado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSD_UnReg(m_abas_cotizacionescompradetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_abas_cotizacionescompradetalle.Nuevo Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSI_UnReg(m_abas_cotizacionescompradetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_cotizacionescompradetalle.Modificado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSU_UnReg(m_abas_cotizacionescompradetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_abas_cotizacionescompradetalle.Eliminado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSD_UnReg(m_abas_cotizacionescompradetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_cotizacionescompradetalle.Nuevo Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSI_UnReg(m_abas_cotizacionescompradetalle, x_usuario, x_setfecha)
			ElseIf m_abas_cotizacionescompradetalle.Modificado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSU_UnReg(m_abas_cotizacionescompradetalle, x_usuario, x_setfecha)
			ElseIf m_abas_cotizacionescompradetalle.Eliminado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSD_UnReg(m_abas_cotizacionescompradetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_cotizacionescompradetalle.Nuevo Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSI_UnReg(m_abas_cotizacionescompradetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_cotizacionescompradetalle.Eliminado Then
				d_abas_cotizacionescompradetalle.ABAS_COTCDSD_UnReg(m_abas_cotizacionescompradetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_CotizacionesCompraDetalle = new List(Of EABAS_CotizacionesCompraDetalle)()
			return d_abas_cotizacionescompradetalle.ABAS_COTCDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_cotizacionescompradetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_cotizacionescompradetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_cotizacionescompradetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_cotizacionescompradetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

