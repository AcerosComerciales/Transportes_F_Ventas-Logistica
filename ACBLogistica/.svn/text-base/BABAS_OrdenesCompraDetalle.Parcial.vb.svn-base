Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_OrdenesCompraDetalle

#Region " Variables "
	
	Private m_eabas_ordenescompradetalle As EABAS_OrdenesCompraDetalle
	Private m_listABAS_OrdenesCompraDetalle As List(Of EABAS_OrdenesCompraDetalle)
	Private m_dtABAS_OrdenesCompraDetalle As DataTable

	Private m_dsABAS_OrdenesCompraDetalle As DataSet
	Private d_abas_ordenescompradetalle As DABAS_OrdenesCompraDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_ordenescompradetalle = New DABAS_OrdenesCompraDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_OrdenesCompraDetalle() As EABAS_OrdenesCompraDetalle 
		Get
			return m_eabas_ordenescompradetalle
		End Get
		Set(ByVal value As EABAS_OrdenesCompraDetalle)
			m_eabas_ordenescompradetalle = value
		End Set
	End Property

	Public Property ListABAS_OrdenesCompraDetalle() As List(Of EABAS_OrdenesCompraDetalle)
		Get
			return m_listABAS_OrdenesCompraDetalle
		End Get
		Set(ByVal value As List(Of EABAS_OrdenesCompraDetalle))
			m_listABAS_OrdenesCompraDetalle = value
		End Set
	End Property

	Public Property DTABAS_OrdenesCompraDetalle() As DataTable
		Get
			return m_dtABAS_OrdenesCompraDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_OrdenesCompraDetalle = value
		End Set
	End Property

	Public Property DSABAS_OrdenesCompraDetalle() As DataSet
		Get
			return m_dsABAS_OrdenesCompraDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_OrdenesCompraDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_OrdenesCompraDetalle = new List(Of EABAS_OrdenesCompraDetalle)()
			return d_abas_ordenescompradetalle.ABAS_ORDCDSS_Todos(m_listABAS_OrdenesCompraDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_OrdenesCompraDetalle = new List(Of EABAS_OrdenesCompraDetalle)()
			return d_abas_ordenescompradetalle.ABAS_ORDCDSS_Todos(m_listABAS_OrdenesCompraDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_OrdenesCompraDetalle = new List(Of EABAS_OrdenesCompraDetalle)()
			return d_abas_ordenescompradetalle.ABAS_ORDCDSS_Todos(m_listABAS_OrdenesCompraDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_OrdenesCompraDetalle = new List(Of EABAS_OrdenesCompraDetalle)()
			return d_abas_ordenescompradetalle.ABAS_ORDCDSS_Todos(m_listABAS_OrdenesCompraDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_ordco_codigo As String) As Boolean
		Try
			m_eabas_ordenescompradetalle = New EABAS_OrdenesCompraDetalle()
			Return d_abas_ordenescompradetalle.ABAS_ORDCDSS_Todos(m_eabas_ordenescompradetalle, x_ordco_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_OrdenesCompraDetalle = new DataSet()
			return d_abas_ordenescompradetalle.ABAS_ORDCDSS_Todos(m_dsABAS_OrdenesCompraDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_OrdenesCompraDetalle = new DataSet()
			return d_abas_ordenescompradetalle.ABAS_ORDCDSS_Todos(m_dsABAS_OrdenesCompraDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_OrdenesCompraDetalle = new DataSet()
			Dim _opcion As Boolean = d_abas_ordenescompradetalle.ABAS_ORDCDSS_Todos(m_dsABAS_OrdenesCompraDetalle, x_where)
		If _opcion Then
			m_dtABAS_OrdenesCompraDetalle = m_dsABAS_OrdenesCompraDetalle.Tables(0)
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
			m_dsABAS_OrdenesCompraDetalle = new DataSet()
			Dim _opcion As Boolean = d_abas_ordenescompradetalle.ABAS_ORDCDSS_Todos(m_dsABAS_OrdenesCompraDetalle, x_join, x_where)
		If _opcion Then
			m_dtABAS_OrdenesCompraDetalle = m_dsABAS_OrdenesCompraDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_ordco_codigo As String, x_ordcd_item As Short) As Boolean
		Try
			m_eabas_ordenescompradetalle = New EABAS_OrdenesCompraDetalle()
			Return d_abas_ordenescompradetalle.ABAS_ORDCDSS_UnReg(m_eabas_ordenescompradetalle, x_ordco_codigo, x_ordcd_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_ordenescompradetalle = New EABAS_OrdenesCompraDetalle()
			Return d_abas_ordenescompradetalle.ABAS_ORDCDSS_UnReg(m_eabas_ordenescompradetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_ordenescompradetalle = New EABAS_OrdenesCompraDetalle()
			Return d_abas_ordenescompradetalle.ABAS_ORDCDSS_UnReg(m_eabas_ordenescompradetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_ordenescompradetalle.Nuevo Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSI_UnReg(m_eabas_ordenescompradetalle, x_usuario)
			ElseIf m_eabas_ordenescompradetalle.Modificado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSU_UnReg(m_eabas_ordenescompradetalle, x_usuario)
			ElseIf m_eabas_ordenescompradetalle.Eliminado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSD_UnReg(ABAS_OrdenesCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_ordenescompradetalle.Nuevo Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSI_UnReg(m_eabas_ordenescompradetalle, x_usuario)
			ElseIf m_eabas_ordenescompradetalle.Modificado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSU_UnReg(m_eabas_ordenescompradetalle, x_where, x_usuario)
			ElseIf m_eabas_ordenescompradetalle.Eliminado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_ordenescompradetalle.Nuevo Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSI_UnReg(m_eabas_ordenescompradetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ordenescompradetalle.Modificado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSU_UnReg(m_eabas_ordenescompradetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ordenescompradetalle.Eliminado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSD_UnReg(ABAS_OrdenesCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eabas_ordenescompradetalle.Nuevo Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSI_UnReg(m_eabas_ordenescompradetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ordenescompradetalle.Modificado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSU_UnReg(m_eabas_ordenescompradetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eabas_ordenescompradetalle.Eliminado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSD_UnReg(ABAS_OrdenesCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_ordenescompradetalle.Nuevo Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSI_UnReg(m_eabas_ordenescompradetalle, x_usuario, x_setfecha)
			ElseIf m_eabas_ordenescompradetalle.Modificado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSU_UnReg(m_eabas_ordenescompradetalle, x_usuario, x_setfecha)
			ElseIf m_eabas_ordenescompradetalle.Eliminado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSD_UnReg(ABAS_OrdenesCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_ordenescompradetalle.Nuevo Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSI_UnReg(m_eabas_ordenescompradetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ordenescompradetalle.Eliminado Then
				d_abas_ordenescompradetalle.ABAS_ORDCDSD_UnReg(ABAS_OrdenesCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_OrdenesCompraDetalle = new List(Of EABAS_OrdenesCompraDetalle)()
			return d_abas_ordenescompradetalle.ABAS_ORDCDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_ordenescompradetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_ordenescompradetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_ordenescompradetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_ordenescompradetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

