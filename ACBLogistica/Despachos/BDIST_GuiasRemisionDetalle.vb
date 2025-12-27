Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BDIST_GuiasRemisionDetalle

#Region " Variables "
	
	Private m_edist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle
	Private m_listDIST_GuiasRemisionDetalle As List(Of EDIST_GuiasRemisionDetalle)
	Private m_dtDIST_GuiasRemisionDetalle As DataTable

	Private m_dsDIST_GuiasRemisionDetalle As DataSet
	Private d_dist_guiasremisiondetalle As DDIST_GuiasRemisionDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_dist_guiasremisiondetalle = New DDIST_GuiasRemisionDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property DIST_GuiasRemisionDetalle() As EDIST_GuiasRemisionDetalle 
		Get
			return m_edist_guiasremisiondetalle
		End Get
		Set(ByVal value As EDIST_GuiasRemisionDetalle)
			m_edist_guiasremisiondetalle = value
		End Set
	End Property

	Public Property ListDIST_GuiasRemisionDetalle() As List(Of EDIST_GuiasRemisionDetalle)
		Get
			return m_listDIST_GuiasRemisionDetalle
		End Get
		Set(ByVal value As List(Of EDIST_GuiasRemisionDetalle))
			m_listDIST_GuiasRemisionDetalle = value
		End Set
	End Property

	Public Property DTDIST_GuiasRemisionDetalle() As DataTable
		Get
			return m_dtDIST_GuiasRemisionDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtDIST_GuiasRemisionDetalle = value
		End Set
	End Property

	Public Property DSDIST_GuiasRemisionDetalle() As DataSet
		Get
			return m_dsDIST_GuiasRemisionDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsDIST_GuiasRemisionDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listDIST_GuiasRemisionDetalle = new List(Of EDIST_GuiasRemisionDetalle)()
			return d_dist_guiasremisiondetalle.DIST_GUIRDSS_Todos(m_listDIST_GuiasRemisionDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_GuiasRemisionDetalle = new List(Of EDIST_GuiasRemisionDetalle)()
			return d_dist_guiasremisiondetalle.DIST_GUIRDSS_Todos(m_listDIST_GuiasRemisionDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_GuiasRemisionDetalle = new List(Of EDIST_GuiasRemisionDetalle)()
			return d_dist_guiasremisiondetalle.DIST_GUIRDSS_Todos(m_listDIST_GuiasRemisionDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listDIST_GuiasRemisionDetalle = new List(Of EDIST_GuiasRemisionDetalle)()
			return d_dist_guiasremisiondetalle.DIST_GUIRDSS_Todos(m_listDIST_GuiasRemisionDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_guiar_codigo As String) As Boolean
		Try
			m_edist_guiasremisiondetalle = New EDIST_GuiasRemisionDetalle()
			Return d_dist_guiasremisiondetalle.DIST_GUIRDSS_Todos(m_edist_guiasremisiondetalle, x_guiar_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_GuiasRemisionDetalle = new DataSet()
			return d_dist_guiasremisiondetalle.DIST_GUIRDSS_Todos(m_dsDIST_GuiasRemisionDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_GuiasRemisionDetalle = new DataSet()
			return d_dist_guiasremisiondetalle.DIST_GUIRDSS_Todos(m_dsDIST_GuiasRemisionDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDIST_GuiasRemisionDetalle = new DataSet()
			Dim _opcion As Boolean = d_dist_guiasremisiondetalle.DIST_GUIRDSS_Todos(m_dsDIST_GuiasRemisionDetalle, x_where)
		If _opcion Then
			m_dtDIST_GuiasRemisionDetalle = m_dsDIST_GuiasRemisionDetalle.Tables(0)
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
			m_dsDIST_GuiasRemisionDetalle = new DataSet()
			Dim _opcion As Boolean = d_dist_guiasremisiondetalle.DIST_GUIRDSS_Todos(m_dsDIST_GuiasRemisionDetalle, x_join, x_where)
		If _opcion Then
			m_dtDIST_GuiasRemisionDetalle = m_dsDIST_GuiasRemisionDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_guiar_codigo As String, x_guird_item As Short) As Boolean
		Try
			m_edist_guiasremisiondetalle = New EDIST_GuiasRemisionDetalle()
			Return d_dist_guiasremisiondetalle.DIST_GUIRDSS_UnReg(m_edist_guiasremisiondetalle, x_guiar_codigo, x_guird_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_guiasremisiondetalle = New EDIST_GuiasRemisionDetalle()
			Return d_dist_guiasremisiondetalle.DIST_GUIRDSS_UnReg(m_edist_guiasremisiondetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_edist_guiasremisiondetalle = New EDIST_GuiasRemisionDetalle()
			Return d_dist_guiasremisiondetalle.DIST_GUIRDSS_UnReg(m_edist_guiasremisiondetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_edist_guiasremisiondetalle.Nuevo Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSI_UnReg(m_edist_guiasremisiondetalle, x_usuario)
			ElseIf m_edist_guiasremisiondetalle.Modificado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSU_UnReg(m_edist_guiasremisiondetalle, x_usuario)
			ElseIf m_edist_guiasremisiondetalle.Eliminado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSD_UnReg(DIST_GuiasRemisionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_edist_guiasremisiondetalle.Nuevo Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSI_UnReg(m_edist_guiasremisiondetalle, x_usuario)
			ElseIf m_edist_guiasremisiondetalle.Modificado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSU_UnReg(m_edist_guiasremisiondetalle, x_where, x_usuario)
			ElseIf m_edist_guiasremisiondetalle.Eliminado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_guiasremisiondetalle.Nuevo Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSI_UnReg(m_edist_guiasremisiondetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_guiasremisiondetalle.Modificado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSU_UnReg(m_edist_guiasremisiondetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_guiasremisiondetalle.Eliminado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSD_UnReg(DIST_GuiasRemisionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_edist_guiasremisiondetalle.Nuevo Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSI_UnReg(m_edist_guiasremisiondetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_guiasremisiondetalle.Modificado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSU_UnReg(m_edist_guiasremisiondetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_edist_guiasremisiondetalle.Eliminado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSD_UnReg(DIST_GuiasRemisionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_guiasremisiondetalle.Nuevo Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSI_UnReg(m_edist_guiasremisiondetalle, x_usuario, x_setfecha)
			ElseIf m_edist_guiasremisiondetalle.Modificado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSU_UnReg(m_edist_guiasremisiondetalle, x_usuario, x_setfecha)
			ElseIf m_edist_guiasremisiondetalle.Eliminado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSD_UnReg(DIST_GuiasRemisionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_edist_guiasremisiondetalle.Nuevo Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSI_UnReg(m_edist_guiasremisiondetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_edist_guiasremisiondetalle.Eliminado Then
				d_dist_guiasremisiondetalle.DIST_GUIRDSD_UnReg(DIST_GuiasRemisionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDIST_GuiasRemisionDetalle = new List(Of EDIST_GuiasRemisionDetalle)()
			return d_dist_guiasremisiondetalle.DIST_GUIRDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_dist_guiasremisiondetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_dist_guiasremisiondetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_dist_guiasremisiondetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_dist_guiasremisiondetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

