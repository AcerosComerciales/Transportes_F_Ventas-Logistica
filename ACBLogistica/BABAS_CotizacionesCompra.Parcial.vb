Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_CotizacionesCompra

#Region " Variables "
	
	Private m_eabas_cotizacionescompra As EABAS_CotizacionesCompra
	Private m_listABAS_CotizacionesCompra As List(Of EABAS_CotizacionesCompra)
	Private m_dtABAS_CotizacionesCompra As DataTable

	Private m_dsABAS_CotizacionesCompra As DataSet
	Private d_abas_cotizacionescompra As DABAS_CotizacionesCompra 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_cotizacionescompra = New DABAS_CotizacionesCompra()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_CotizacionesCompra() As EABAS_CotizacionesCompra 
		Get
			return m_eabas_cotizacionescompra
		End Get
		Set(ByVal value As EABAS_CotizacionesCompra)
			m_eabas_cotizacionescompra = value
		End Set
	End Property

	Public Property ListABAS_CotizacionesCompra() As List(Of EABAS_CotizacionesCompra)
		Get
			return m_listABAS_CotizacionesCompra
		End Get
		Set(ByVal value As List(Of EABAS_CotizacionesCompra))
			m_listABAS_CotizacionesCompra = value
		End Set
	End Property

	Public Property DTABAS_CotizacionesCompra() As DataTable
		Get
			return m_dtABAS_CotizacionesCompra
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_CotizacionesCompra = value
		End Set
	End Property

	Public Property DSABAS_CotizacionesCompra() As DataSet
		Get
			return m_dsABAS_CotizacionesCompra
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_CotizacionesCompra = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_CotizacionesCompra = new List(Of EABAS_CotizacionesCompra)()
			return d_abas_cotizacionescompra.ABAS_COTCOSS_Todos(m_listABAS_CotizacionesCompra)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_CotizacionesCompra = new List(Of EABAS_CotizacionesCompra)()
			return d_abas_cotizacionescompra.ABAS_COTCOSS_Todos(m_listABAS_CotizacionesCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_CotizacionesCompra = new List(Of EABAS_CotizacionesCompra)()
			return d_abas_cotizacionescompra.ABAS_COTCOSS_Todos(m_listABAS_CotizacionesCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_CotizacionesCompra = new List(Of EABAS_CotizacionesCompra)()
			return d_abas_cotizacionescompra.ABAS_COTCOSS_Todos(m_listABAS_CotizacionesCompra, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_CotizacionesCompra = new DataSet()
			return d_abas_cotizacionescompra.ABAS_COTCOSS_Todos(m_dsABAS_CotizacionesCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_CotizacionesCompra = new DataSet()
			return d_abas_cotizacionescompra.ABAS_COTCOSS_Todos(m_dsABAS_CotizacionesCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_CotizacionesCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_cotizacionescompra.ABAS_COTCOSS_Todos(m_dsABAS_CotizacionesCompra, x_where)
		If _opcion Then
			m_dtABAS_CotizacionesCompra = m_dsABAS_CotizacionesCompra.Tables(0)
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
			m_dsABAS_CotizacionesCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_cotizacionescompra.ABAS_COTCOSS_Todos(m_dsABAS_CotizacionesCompra, x_join, x_where)
		If _opcion Then
			m_dtABAS_CotizacionesCompra = m_dsABAS_CotizacionesCompra.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_cotco_codigo As String) As Boolean
		Try
			m_eabas_cotizacionescompra = New EABAS_CotizacionesCompra()
			Return d_abas_cotizacionescompra.ABAS_COTCOSS_UnReg(m_eabas_cotizacionescompra, x_cotco_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_cotizacionescompra = New EABAS_CotizacionesCompra()
			Return d_abas_cotizacionescompra.ABAS_COTCOSS_UnReg(m_eabas_cotizacionescompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_cotizacionescompra = New EABAS_CotizacionesCompra()
			Return d_abas_cotizacionescompra.ABAS_COTCOSS_UnReg(m_eabas_cotizacionescompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_cotizacionescompra.Nuevo Then
				d_abas_cotizacionescompra.ABAS_COTCOSI_UnReg(m_eabas_cotizacionescompra, x_usuario)
			ElseIf m_eabas_cotizacionescompra.Modificado Then
				d_abas_cotizacionescompra.ABAS_COTCOSU_UnReg(m_eabas_cotizacionescompra, x_usuario)
			ElseIf m_eabas_cotizacionescompra.Eliminado Then
				d_abas_cotizacionescompra.ABAS_COTCOSD_UnReg(ABAS_CotizacionesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_cotizacionescompra.Nuevo Then
				d_abas_cotizacionescompra.ABAS_COTCOSI_UnReg(m_eabas_cotizacionescompra, x_usuario)
			ElseIf m_eabas_cotizacionescompra.Modificado Then
				d_abas_cotizacionescompra.ABAS_COTCOSU_UnReg(m_eabas_cotizacionescompra, x_where, x_usuario)
			ElseIf m_eabas_cotizacionescompra.Eliminado Then
				d_abas_cotizacionescompra.ABAS_COTCOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_cotizacionescompra.Nuevo Then
				d_abas_cotizacionescompra.ABAS_COTCOSI_UnReg(m_eabas_cotizacionescompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_cotizacionescompra.Modificado Then
				d_abas_cotizacionescompra.ABAS_COTCOSU_UnReg(m_eabas_cotizacionescompra, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_cotizacionescompra.Eliminado Then
				d_abas_cotizacionescompra.ABAS_COTCOSD_UnReg(ABAS_CotizacionesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eabas_cotizacionescompra.Nuevo Then
				d_abas_cotizacionescompra.ABAS_COTCOSI_UnReg(m_eabas_cotizacionescompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_cotizacionescompra.Modificado Then
				d_abas_cotizacionescompra.ABAS_COTCOSU_UnReg(m_eabas_cotizacionescompra, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eabas_cotizacionescompra.Eliminado Then
				d_abas_cotizacionescompra.ABAS_COTCOSD_UnReg(ABAS_CotizacionesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_cotizacionescompra.Nuevo Then
				d_abas_cotizacionescompra.ABAS_COTCOSI_UnReg(m_eabas_cotizacionescompra, x_usuario, x_setfecha)
			ElseIf m_eabas_cotizacionescompra.Modificado Then
				d_abas_cotizacionescompra.ABAS_COTCOSU_UnReg(m_eabas_cotizacionescompra, x_usuario, x_setfecha)
			ElseIf m_eabas_cotizacionescompra.Eliminado Then
				d_abas_cotizacionescompra.ABAS_COTCOSD_UnReg(ABAS_CotizacionesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_cotizacionescompra.Nuevo Then
				d_abas_cotizacionescompra.ABAS_COTCOSI_UnReg(m_eabas_cotizacionescompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_cotizacionescompra.Eliminado Then
				d_abas_cotizacionescompra.ABAS_COTCOSD_UnReg(ABAS_CotizacionesCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_CotizacionesCompra = new List(Of EABAS_CotizacionesCompra)()
			return d_abas_cotizacionescompra.ABAS_COTCOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_cotizacionescompra.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_cotizacionescompra.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_cotizacionescompra.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_cotizacionescompra.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

