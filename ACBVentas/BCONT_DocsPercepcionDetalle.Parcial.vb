Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BCONT_DocsPercepcionDetalle

#Region " Variables "
	
	Private m_econt_docspercepciondetalle As ECONT_DocsPercepcionDetalle
	Private m_listCONT_DocsPercepcionDetalle As List(Of ECONT_DocsPercepcionDetalle)
	Private m_dtCONT_DocsPercepcionDetalle As DataTable

	Private m_dsCONT_DocsPercepcionDetalle As DataSet
	Private d_cont_docspercepciondetalle As DCONT_DocsPercepcionDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_cont_docspercepciondetalle = New DCONT_DocsPercepcionDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property CONT_DocsPercepcionDetalle() As ECONT_DocsPercepcionDetalle 
		Get
			return m_econt_docspercepciondetalle
		End Get
		Set(ByVal value As ECONT_DocsPercepcionDetalle)
			m_econt_docspercepciondetalle = value
		End Set
	End Property

	Public Property ListCONT_DocsPercepcionDetalle() As List(Of ECONT_DocsPercepcionDetalle)
		Get
			return m_listCONT_DocsPercepcionDetalle
		End Get
		Set(ByVal value As List(Of ECONT_DocsPercepcionDetalle))
			m_listCONT_DocsPercepcionDetalle = value
		End Set
	End Property

	Public Property DTCONT_DocsPercepcionDetalle() As DataTable
		Get
			return m_dtCONT_DocsPercepcionDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtCONT_DocsPercepcionDetalle = value
		End Set
	End Property

	Public Property DSCONT_DocsPercepcionDetalle() As DataSet
		Get
			return m_dsCONT_DocsPercepcionDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsCONT_DocsPercepcionDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listCONT_DocsPercepcionDetalle = new List(Of ECONT_DocsPercepcionDetalle)()
			return d_cont_docspercepciondetalle.CONT_DOCPDSS_Todos(m_listCONT_DocsPercepcionDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCONT_DocsPercepcionDetalle = new List(Of ECONT_DocsPercepcionDetalle)()
			return d_cont_docspercepciondetalle.CONT_DOCPDSS_Todos(m_listCONT_DocsPercepcionDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listCONT_DocsPercepcionDetalle = new List(Of ECONT_DocsPercepcionDetalle)()
			return d_cont_docspercepciondetalle.CONT_DOCPDSS_Todos(m_listCONT_DocsPercepcionDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listCONT_DocsPercepcionDetalle = new List(Of ECONT_DocsPercepcionDetalle)()
			return d_cont_docspercepciondetalle.CONT_DOCPDSS_Todos(m_listCONT_DocsPercepcionDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_docpe_codigo As String) As Boolean
		Try
			m_econt_docspercepciondetalle = New ECONT_DocsPercepcionDetalle()
			Return d_cont_docspercepciondetalle.CONT_DOCPDSS_Todos(m_econt_docspercepciondetalle, x_docpe_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCONT_DocsPercepcionDetalle = new DataSet()
			return d_cont_docspercepciondetalle.CONT_DOCPDSS_Todos(m_dsCONT_DocsPercepcionDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCONT_DocsPercepcionDetalle = new DataSet()
			return d_cont_docspercepciondetalle.CONT_DOCPDSS_Todos(m_dsCONT_DocsPercepcionDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCONT_DocsPercepcionDetalle = new DataSet()
			Dim _opcion As Boolean = d_cont_docspercepciondetalle.CONT_DOCPDSS_Todos(m_dsCONT_DocsPercepcionDetalle, x_where)
		If _opcion Then
			m_dtCONT_DocsPercepcionDetalle = m_dsCONT_DocsPercepcionDetalle.Tables(0)
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
			m_dsCONT_DocsPercepcionDetalle = new DataSet()
			Dim _opcion As Boolean = d_cont_docspercepciondetalle.CONT_DOCPDSS_Todos(m_dsCONT_DocsPercepcionDetalle, x_join, x_where)
		If _opcion Then
			m_dtCONT_DocsPercepcionDetalle = m_dsCONT_DocsPercepcionDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docpe_codigo As String, x_docpd_item As Short) As Boolean
		Try
			m_econt_docspercepciondetalle = New ECONT_DocsPercepcionDetalle()
			Return d_cont_docspercepciondetalle.CONT_DOCPDSS_UnReg(m_econt_docspercepciondetalle, x_docpe_codigo, x_docpd_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_econt_docspercepciondetalle = New ECONT_DocsPercepcionDetalle()
			Return d_cont_docspercepciondetalle.CONT_DOCPDSS_UnReg(m_econt_docspercepciondetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_econt_docspercepciondetalle = New ECONT_DocsPercepcionDetalle()
			Return d_cont_docspercepciondetalle.CONT_DOCPDSS_UnReg(m_econt_docspercepciondetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_econt_docspercepciondetalle.Nuevo Then
				d_cont_docspercepciondetalle.CONT_DOCPDSI_UnReg(m_econt_docspercepciondetalle, x_usuario)
			ElseIf m_econt_docspercepciondetalle.Modificado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSU_UnReg(m_econt_docspercepciondetalle, x_usuario)
			ElseIf m_econt_docspercepciondetalle.Eliminado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSD_UnReg(CONT_DocsPercepcionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_econt_docspercepciondetalle.Nuevo Then
				d_cont_docspercepciondetalle.CONT_DOCPDSI_UnReg(m_econt_docspercepciondetalle, x_usuario)
			ElseIf m_econt_docspercepciondetalle.Modificado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSU_UnReg(m_econt_docspercepciondetalle, x_where, x_usuario)
			ElseIf m_econt_docspercepciondetalle.Eliminado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_econt_docspercepciondetalle.Nuevo Then
				d_cont_docspercepciondetalle.CONT_DOCPDSI_UnReg(m_econt_docspercepciondetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_econt_docspercepciondetalle.Modificado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSU_UnReg(m_econt_docspercepciondetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_econt_docspercepciondetalle.Eliminado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSD_UnReg(CONT_DocsPercepcionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_econt_docspercepciondetalle.Nuevo Then
				d_cont_docspercepciondetalle.CONT_DOCPDSI_UnReg(m_econt_docspercepciondetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_econt_docspercepciondetalle.Modificado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSU_UnReg(m_econt_docspercepciondetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_econt_docspercepciondetalle.Eliminado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSD_UnReg(CONT_DocsPercepcionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_econt_docspercepciondetalle.Nuevo Then
				d_cont_docspercepciondetalle.CONT_DOCPDSI_UnReg(m_econt_docspercepciondetalle, x_usuario, x_setfecha)
			ElseIf m_econt_docspercepciondetalle.Modificado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSU_UnReg(m_econt_docspercepciondetalle, x_usuario, x_setfecha)
			ElseIf m_econt_docspercepciondetalle.Eliminado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSD_UnReg(CONT_DocsPercepcionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_econt_docspercepciondetalle.Nuevo Then
				d_cont_docspercepciondetalle.CONT_DOCPDSI_UnReg(m_econt_docspercepciondetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_econt_docspercepciondetalle.Eliminado Then
				d_cont_docspercepciondetalle.CONT_DOCPDSD_UnReg(CONT_DocsPercepcionDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCONT_DocsPercepcionDetalle = new List(Of ECONT_DocsPercepcionDetalle)()
			return d_cont_docspercepciondetalle.CONT_DOCPDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_cont_docspercepciondetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_cont_docspercepciondetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_cont_docspercepciondetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_cont_docspercepciondetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

