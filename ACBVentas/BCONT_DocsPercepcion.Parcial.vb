Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BCONT_DocsPercepcion

#Region " Variables "
	
	Private m_econt_docspercepcion As ECONT_DocsPercepcion
	Private m_listCONT_DocsPercepcion As List(Of ECONT_DocsPercepcion)
	Private m_dtCONT_DocsPercepcion As DataTable

	Private m_dsCONT_DocsPercepcion As DataSet
	Private d_cont_docspercepcion As DCONT_DocsPercepcion 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_cont_docspercepcion = New DCONT_DocsPercepcion()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property CONT_DocsPercepcion() As ECONT_DocsPercepcion 
		Get
			return m_econt_docspercepcion
		End Get
		Set(ByVal value As ECONT_DocsPercepcion)
			m_econt_docspercepcion = value
		End Set
	End Property

	Public Property ListCONT_DocsPercepcion() As List(Of ECONT_DocsPercepcion)
		Get
			return m_listCONT_DocsPercepcion
		End Get
		Set(ByVal value As List(Of ECONT_DocsPercepcion))
			m_listCONT_DocsPercepcion = value
		End Set
	End Property

	Public Property DTCONT_DocsPercepcion() As DataTable
		Get
			return m_dtCONT_DocsPercepcion
		End Get
		Set(ByVal value As DataTable)
			m_dtCONT_DocsPercepcion = value
		End Set
	End Property

	Public Property DSCONT_DocsPercepcion() As DataSet
		Get
			return m_dsCONT_DocsPercepcion
		End Get
		Set(ByVal value As DataSet)
			m_dsCONT_DocsPercepcion = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listCONT_DocsPercepcion = new List(Of ECONT_DocsPercepcion)()
			return d_cont_docspercepcion.CONT_DOCPESS_Todos(m_listCONT_DocsPercepcion)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCONT_DocsPercepcion = new List(Of ECONT_DocsPercepcion)()
			return d_cont_docspercepcion.CONT_DOCPESS_Todos(m_listCONT_DocsPercepcion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listCONT_DocsPercepcion = new List(Of ECONT_DocsPercepcion)()
			return d_cont_docspercepcion.CONT_DOCPESS_Todos(m_listCONT_DocsPercepcion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listCONT_DocsPercepcion = new List(Of ECONT_DocsPercepcion)()
			return d_cont_docspercepcion.CONT_DOCPESS_Todos(m_listCONT_DocsPercepcion, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCONT_DocsPercepcion = new DataSet()
			return d_cont_docspercepcion.CONT_DOCPESS_Todos(m_dsCONT_DocsPercepcion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCONT_DocsPercepcion = new DataSet()
			return d_cont_docspercepcion.CONT_DOCPESS_Todos(m_dsCONT_DocsPercepcion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCONT_DocsPercepcion = new DataSet()
			Dim _opcion As Boolean = d_cont_docspercepcion.CONT_DOCPESS_Todos(m_dsCONT_DocsPercepcion, x_where)
		If _opcion Then
			m_dtCONT_DocsPercepcion = m_dsCONT_DocsPercepcion.Tables(0)
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
			m_dsCONT_DocsPercepcion = new DataSet()
			Dim _opcion As Boolean = d_cont_docspercepcion.CONT_DOCPESS_Todos(m_dsCONT_DocsPercepcion, x_join, x_where)
		If _opcion Then
			m_dtCONT_DocsPercepcion = m_dsCONT_DocsPercepcion.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docpe_codigo As String) As Boolean
		Try
			m_econt_docspercepcion = New ECONT_DocsPercepcion()
			Return d_cont_docspercepcion.CONT_DOCPESS_UnReg(m_econt_docspercepcion, x_docpe_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_econt_docspercepcion = New ECONT_DocsPercepcion()
			Return d_cont_docspercepcion.CONT_DOCPESS_UnReg(m_econt_docspercepcion, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_econt_docspercepcion = New ECONT_DocsPercepcion()
			Return d_cont_docspercepcion.CONT_DOCPESS_UnReg(m_econt_docspercepcion, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_econt_docspercepcion.Nuevo Then
				d_cont_docspercepcion.CONT_DOCPESI_UnReg(m_econt_docspercepcion, x_usuario)
			ElseIf m_econt_docspercepcion.Modificado Then
				d_cont_docspercepcion.CONT_DOCPESU_UnReg(m_econt_docspercepcion, x_usuario)
			ElseIf m_econt_docspercepcion.Eliminado Then
				d_cont_docspercepcion.CONT_DOCPESD_UnReg(CONT_DocsPercepcion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_econt_docspercepcion.Nuevo Then
				d_cont_docspercepcion.CONT_DOCPESI_UnReg(m_econt_docspercepcion, x_usuario)
			ElseIf m_econt_docspercepcion.Modificado Then
				d_cont_docspercepcion.CONT_DOCPESU_UnReg(m_econt_docspercepcion, x_where, x_usuario)
			ElseIf m_econt_docspercepcion.Eliminado Then
				d_cont_docspercepcion.CONT_DOCPESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_econt_docspercepcion.Nuevo Then
				d_cont_docspercepcion.CONT_DOCPESI_UnReg(m_econt_docspercepcion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_econt_docspercepcion.Modificado Then
				d_cont_docspercepcion.CONT_DOCPESU_UnReg(m_econt_docspercepcion, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_econt_docspercepcion.Eliminado Then
				d_cont_docspercepcion.CONT_DOCPESD_UnReg(CONT_DocsPercepcion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_econt_docspercepcion.Nuevo Then
				d_cont_docspercepcion.CONT_DOCPESI_UnReg(m_econt_docspercepcion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_econt_docspercepcion.Modificado Then
				d_cont_docspercepcion.CONT_DOCPESU_UnReg(m_econt_docspercepcion, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_econt_docspercepcion.Eliminado Then
				d_cont_docspercepcion.CONT_DOCPESD_UnReg(CONT_DocsPercepcion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_econt_docspercepcion.Nuevo Then
				d_cont_docspercepcion.CONT_DOCPESI_UnReg(m_econt_docspercepcion, x_usuario, x_setfecha)
			ElseIf m_econt_docspercepcion.Modificado Then
				d_cont_docspercepcion.CONT_DOCPESU_UnReg(m_econt_docspercepcion, x_usuario, x_setfecha)
			ElseIf m_econt_docspercepcion.Eliminado Then
				d_cont_docspercepcion.CONT_DOCPESD_UnReg(CONT_DocsPercepcion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_econt_docspercepcion.Nuevo Then
				d_cont_docspercepcion.CONT_DOCPESI_UnReg(m_econt_docspercepcion, x_usuario, x_excluir, x_setfecha)
			ElseIf m_econt_docspercepcion.Eliminado Then
				d_cont_docspercepcion.CONT_DOCPESD_UnReg(CONT_DocsPercepcion)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCONT_DocsPercepcion = new List(Of ECONT_DocsPercepcion)()
			return d_cont_docspercepcion.CONT_DOCPESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_cont_docspercepcion.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_cont_docspercepcion.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_cont_docspercepcion.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_cont_docspercepcion.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

