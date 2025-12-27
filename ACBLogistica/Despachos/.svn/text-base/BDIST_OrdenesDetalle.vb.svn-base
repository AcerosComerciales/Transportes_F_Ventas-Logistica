Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BDIST_OrdenesDetalle

#Region " Variables "
	
	Private m_edist_ordenesdetalle As EDIST_OrdenesDetalle
	Private m_listDIST_OrdenesDetalle As List(Of EDIST_OrdenesDetalle)
	Private m_dtDIST_OrdenesDetalle As DataTable

	Private m_dsDIST_OrdenesDetalle As DataSet
	Private d_dist_ordenesdetalle As DDIST_OrdenesDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_dist_ordenesdetalle = New DDIST_OrdenesDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property DIST_OrdenesDetalle() As EDIST_OrdenesDetalle 
		Get
			return m_edist_ordenesdetalle
		End Get
		Set(ByVal value As EDIST_OrdenesDetalle)
			m_edist_ordenesdetalle = value
		End Set
	End Property

	Public Property ListDIST_OrdenesDetalle() As List(Of EDIST_OrdenesDetalle)
		Get
			return m_listDIST_OrdenesDetalle
		End Get
		Set(ByVal value As List(Of EDIST_OrdenesDetalle))
			m_listDIST_OrdenesDetalle = value
		End Set
	End Property

	Public Property DTDIST_OrdenesDetalle() As DataTable
		Get
			return m_dtDIST_OrdenesDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtDIST_OrdenesDetalle = value
		End Set
	End Property

	Public Property DSDIST_OrdenesDetalle() As DataSet
		Get
			return m_dsDIST_OrdenesDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsDIST_OrdenesDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listDIST_OrdenesDetalle = new List(Of EDIST_OrdenesDetalle)()
			return d_dist_ordenesdetalle.DIST_ORDETSS_Todos(m_listDIST_OrdenesDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_OrdenesDetalle = new List(Of EDIST_OrdenesDetalle)()
			return d_dist_ordenesdetalle.DIST_ORDETSS_Todos(m_listDIST_OrdenesDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_OrdenesDetalle = new List(Of EDIST_OrdenesDetalle)()
			return d_dist_ordenesdetalle.DIST_ORDETSS_Todos(m_listDIST_OrdenesDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listDIST_OrdenesDetalle = new List(Of EDIST_OrdenesDetalle)()
			return d_dist_ordenesdetalle.DIST_ORDETSS_Todos(m_listDIST_OrdenesDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_orden_codigo As String) As Boolean
		Try
			m_edist_ordenesdetalle = New EDIST_OrdenesDetalle()
			Return d_dist_ordenesdetalle.DIST_ORDETSS_Todos(m_edist_ordenesdetalle, x_orden_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_OrdenesDetalle = new DataSet()
			return d_dist_ordenesdetalle.DIST_ORDETSS_Todos(m_dsDIST_OrdenesDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_OrdenesDetalle = new DataSet()
			return d_dist_ordenesdetalle.DIST_ORDETSS_Todos(m_dsDIST_OrdenesDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_OrdenesDetalle = new DataSet()
			Dim _opcion As Boolean = d_dist_ordenesdetalle.DIST_ORDETSS_Todos(m_dsDIST_OrdenesDetalle, x_where)
		If _opcion Then
			m_dtDIST_OrdenesDetalle = m_dsDIST_OrdenesDetalle.Tables(0)
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
			m_dsDIST_OrdenesDetalle = new DataSet()
			Dim _opcion As Boolean = d_dist_ordenesdetalle.DIST_ORDETSS_Todos(m_dsDIST_OrdenesDetalle, x_join, x_where)
		If _opcion Then
			m_dtDIST_OrdenesDetalle = m_dsDIST_OrdenesDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_orden_codigo As String, x_ordet_item As Short) As Boolean
		Try
			m_edist_ordenesdetalle = New EDIST_OrdenesDetalle()
			Return d_dist_ordenesdetalle.DIST_ORDETSS_UnReg(m_edist_ordenesdetalle, x_orden_codigo, x_ordet_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_ordenesdetalle = New EDIST_OrdenesDetalle()
			Return d_dist_ordenesdetalle.DIST_ORDETSS_UnReg(m_edist_ordenesdetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_ordenesdetalle = New EDIST_OrdenesDetalle()
			Return d_dist_ordenesdetalle.DIST_ORDETSS_UnReg(m_edist_ordenesdetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_edist_ordenesdetalle.Nuevo Then
				d_dist_ordenesdetalle.DIST_ORDETSI_UnReg(m_edist_ordenesdetalle, x_usuario)
			ElseIf m_edist_ordenesdetalle.Modificado Then
				d_dist_ordenesdetalle.DIST_ORDETSU_UnReg(m_edist_ordenesdetalle, x_usuario)
			ElseIf m_edist_ordenesdetalle.Eliminado Then
				d_dist_ordenesdetalle.DIST_ORDETSD_UnReg(DIST_OrdenesDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_edist_ordenesdetalle.Nuevo Then
				d_dist_ordenesdetalle.DIST_ORDETSI_UnReg(m_edist_ordenesdetalle, x_usuario)
			ElseIf m_edist_ordenesdetalle.Modificado Then
				d_dist_ordenesdetalle.DIST_ORDETSU_UnReg(m_edist_ordenesdetalle, x_where, x_usuario)
			ElseIf m_edist_ordenesdetalle.Eliminado Then
				d_dist_ordenesdetalle.DIST_ORDETSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_ordenesdetalle.Nuevo Then
				d_dist_ordenesdetalle.DIST_ORDETSI_UnReg(m_edist_ordenesdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_ordenesdetalle.Modificado Then
				d_dist_ordenesdetalle.DIST_ORDETSU_UnReg(m_edist_ordenesdetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_ordenesdetalle.Eliminado Then
				d_dist_ordenesdetalle.DIST_ORDETSD_UnReg(DIST_OrdenesDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_edist_ordenesdetalle.Nuevo Then
				d_dist_ordenesdetalle.DIST_ORDETSI_UnReg(m_edist_ordenesdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_ordenesdetalle.Modificado Then
				d_dist_ordenesdetalle.DIST_ORDETSU_UnReg(m_edist_ordenesdetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_edist_ordenesdetalle.Eliminado Then
				d_dist_ordenesdetalle.DIST_ORDETSD_UnReg(DIST_OrdenesDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_ordenesdetalle.Nuevo Then
				d_dist_ordenesdetalle.DIST_ORDETSI_UnReg(m_edist_ordenesdetalle, x_usuario, x_setfecha)
			ElseIf m_edist_ordenesdetalle.Modificado Then
				d_dist_ordenesdetalle.DIST_ORDETSU_UnReg(m_edist_ordenesdetalle, x_usuario, x_setfecha)
			ElseIf m_edist_ordenesdetalle.Eliminado Then
				d_dist_ordenesdetalle.DIST_ORDETSD_UnReg(DIST_OrdenesDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_ordenesdetalle.Nuevo Then
				d_dist_ordenesdetalle.DIST_ORDETSI_UnReg(m_edist_ordenesdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_ordenesdetalle.Eliminado Then
				d_dist_ordenesdetalle.DIST_ORDETSD_UnReg(DIST_OrdenesDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_OrdenesDetalle = new List(Of EDIST_OrdenesDetalle)()
			return d_dist_ordenesdetalle.DIST_ORDETSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_dist_ordenesdetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_dist_ordenesdetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_dist_ordenesdetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_dist_ordenesdetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

