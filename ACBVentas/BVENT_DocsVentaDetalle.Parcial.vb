Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BVENT_DocsVentaDetalle

#Region " Variables "
	
    Private m_vent_docsventadetalle As EVENT_DocsVentaDetalle
	Private m_listVENT_DocsVentaDetalle As List(Of EVENT_DocsVentaDetalle)
	Private m_dtVENT_DocsVentaDetalle As DataTable

	Private m_dsVENT_DocsVentaDetalle As DataSet
	Private d_vent_docsventadetalle As DVENT_DocsVentaDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_vent_docsventadetalle = New DVENT_DocsVentaDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property VENT_DocsVentaDetalle() As EVENT_DocsVentaDetalle 
		Get
			return m_vent_docsventadetalle
		End Get
		Set(ByVal value As EVENT_DocsVentaDetalle)
			m_vent_docsventadetalle = value
		End Set
	End Property
	Public Property ListVENT_DocsVentaDetalle() As List(Of EVENT_DocsVentaDetalle)
		Get
			return m_listVENT_DocsVentaDetalle
		End Get
		Set(ByVal value As List(Of EVENT_DocsVentaDetalle))
			m_listVENT_DocsVentaDetalle = value
		End Set
	End Property
	Public Property DTVENT_DocsVentaDetalle() As DataTable
		Get
			return m_dtVENT_DocsVentaDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtVENT_DocsVentaDetalle = value
		End Set
	End Property
	Public Property DSVENT_DocsVentaDetalle() As DataSet
		Get
			return m_dsVENT_DocsVentaDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsVENT_DocsVentaDetalle = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListVENT_DocsVentaDetalle() As List(Of EVENT_DocsVentaDetalle)
			Return Me.m_listVENT_DocsVentaDetalle
		End Function
		Public Sub setListVENT_DocsVentaDetalle(ByVal _listvent_docsventadetalle As List (Of EVENT_DocsVentaDetalle))
			Me.m_listVENT_DocsVentaDetalle = m_listvent_docsventadetalle 
		End Sub
		Public Function getVENT_DocsVentaDetalle() As EVENT_DocsVentaDetalle
			Return Me.m_vent_docsventadetalle
		End Function
		Public Sub setVENT_DocsVentaDetalle(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle)
			Me.m_vent_docsventadetalle = x_vent_docsventadetalle 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listVENT_DocsVentaDetalle = new List(Of EVENT_DocsVentaDetalle)()
			return d_vent_docsventadetalle.VENT_DOCVDSS_Todos(m_listVENT_DocsVentaDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVentaDetalle = new List(Of EVENT_DocsVentaDetalle)()
			return d_vent_docsventadetalle.VENT_DOCVDSS_Todos(m_listVENT_DocsVentaDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVentaDetalle = new List(Of EVENT_DocsVentaDetalle)()
			return d_vent_docsventadetalle.VENT_DOCVDSS_Todos(m_listVENT_DocsVentaDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listVENT_DocsVentaDetalle = new List(Of EVENT_DocsVentaDetalle)()
			return d_vent_docsventadetalle.VENT_DOCVDSS_Todos(m_listVENT_DocsVentaDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_docve_codigo As String) As Boolean
		Try
			m_listVENT_DocsVentaDetalle = new List(Of EVENT_DocsVentaDetalle)()
			Return d_vent_docsventadetalle.VENT_DOCVDSS_Todos(m_listVENT_DocsVentaDetalle, x_docve_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsVentaDetalle = new DataSet()
			return d_vent_docsventadetalle.VENT_DOCVDSS_Todos(m_dsVENT_DocsVentaDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    
      Public Function CargarTodosP(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVentaDetalle = new List(Of EVENT_DocsVentaDetalle)()
			return d_vent_docsventadetalle.VENT_DOCVDSS_TodosP(m_listVENT_DocsVentaDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsVentaDetalle = new DataSet()
			return d_vent_docsventadetalle.VENT_DOCVDSS_Todos(m_dsVENT_DocsVentaDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsVENT_DocsVentaDetalle = new DataSet()
			Dim _opcion As Boolean = d_vent_docsventadetalle.VENT_DOCVDSS_Todos(m_dsVENT_DocsVentaDetalle, x_where)
		If _opcion Then
			m_dtVENT_DocsVentaDetalle = m_dsVENT_DocsVentaDetalle.Tables(0)
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
			m_dsVENT_DocsVentaDetalle = new DataSet()
			Dim _opcion As Boolean = d_vent_docsventadetalle.VENT_DOCVDSS_Todos(m_dsVENT_DocsVentaDetalle, x_join, x_where)
		If _opcion Then
			m_dtVENT_DocsVentaDetalle = m_dsVENT_DocsVentaDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docve_codigo As String, x_docvd_item As Short) As Boolean
		Try
			m_vent_docsventadetalle = New EVENT_DocsVentaDetalle()
			Return d_vent_docsventadetalle.VENT_DOCVDSS_UnReg(m_vent_docsventadetalle, x_docve_codigo, x_docvd_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_docsventadetalle = New EVENT_DocsVentaDetalle()
			Return d_vent_docsventadetalle.VENT_DOCVDSS_UnReg(m_vent_docsventadetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_vent_docsventadetalle = New EVENT_DocsVentaDetalle()
			Return d_vent_docsventadetalle.VENT_DOCVDSS_UnReg(m_vent_docsventadetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_vent_docsventadetalle.Nuevo Then
				d_vent_docsventadetalle.VENT_DOCVDSI_UnReg(m_vent_docsventadetalle, x_usuario)
			ElseIf m_vent_docsventadetalle.Modificado Then
				d_vent_docsventadetalle.VENT_DOCVDSU_UnReg(m_vent_docsventadetalle, x_usuario)
			ElseIf m_vent_docsventadetalle.Eliminado Then
				d_vent_docsventadetalle.VENT_DOCVDSD_UnReg(m_vent_docsventadetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_vent_docsventadetalle.Nuevo Then
				d_vent_docsventadetalle.VENT_DOCVDSI_UnReg(m_vent_docsventadetalle, x_usuario)
			ElseIf m_vent_docsventadetalle.Modificado Then
				d_vent_docsventadetalle.VENT_DOCVDSU_UnReg(m_vent_docsventadetalle, x_where, x_usuario)
			ElseIf m_vent_docsventadetalle.Eliminado Then
				d_vent_docsventadetalle.VENT_DOCVDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_docsventadetalle.Nuevo Then
				d_vent_docsventadetalle.VENT_DOCVDSI_UnReg(m_vent_docsventadetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_docsventadetalle.Modificado Then
				d_vent_docsventadetalle.VENT_DOCVDSU_UnReg(m_vent_docsventadetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_docsventadetalle.Eliminado Then
				d_vent_docsventadetalle.VENT_DOCVDSD_UnReg(m_vent_docsventadetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_vent_docsventadetalle.Nuevo Then
				d_vent_docsventadetalle.VENT_DOCVDSI_UnReg(m_vent_docsventadetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_docsventadetalle.Modificado Then
				d_vent_docsventadetalle.VENT_DOCVDSU_UnReg(m_vent_docsventadetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_vent_docsventadetalle.Eliminado Then
				d_vent_docsventadetalle.VENT_DOCVDSD_UnReg(m_vent_docsventadetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_docsventadetalle.Nuevo Then
				d_vent_docsventadetalle.VENT_DOCVDSI_UnReg(m_vent_docsventadetalle, x_usuario, x_setfecha)
			ElseIf m_vent_docsventadetalle.Modificado Then
				d_vent_docsventadetalle.VENT_DOCVDSU_UnReg(m_vent_docsventadetalle, x_usuario, x_setfecha)
			ElseIf m_vent_docsventadetalle.Eliminado Then
				d_vent_docsventadetalle.VENT_DOCVDSD_UnReg(m_vent_docsventadetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
    End Function
    Public Function Guardar(ByVal x_usuario As String, ByVal x_cant As Decimal, ByVal x_almacen As Boolean) As Boolean
        Try
            If m_vent_docsventadetalle.Nuevo Then
                d_vent_docsventadetalle.VENT_DOCVDSI_UnReg(m_vent_docsventadetalle, x_usuario)
            ElseIf m_vent_docsventadetalle.Modificado Then
                d_vent_docsventadetalle.VENT_DOCVDSU_UnReg(m_vent_docsventadetalle, x_usuario, x_cant, x_almacen)
            ElseIf m_vent_docsventadetalle.Eliminado Then
                d_vent_docsventadetalle.VENT_DOCVDSD_UnReg(m_vent_docsventadetalle)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_vent_docsventadetalle.Nuevo Then
				d_vent_docsventadetalle.VENT_DOCVDSI_UnReg(m_vent_docsventadetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_vent_docsventadetalle.Eliminado Then
				d_vent_docsventadetalle.VENT_DOCVDSD_UnReg(m_vent_docsventadetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listVENT_DocsVentaDetalle = new List(Of EVENT_DocsVentaDetalle)()
			return d_vent_docsventadetalle.VENT_DOCVDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_vent_docsventadetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_vent_docsventadetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_vent_docsventadetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_vent_docsventadetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

