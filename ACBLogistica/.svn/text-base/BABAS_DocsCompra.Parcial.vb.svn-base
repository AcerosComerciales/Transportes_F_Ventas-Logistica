Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_DocsCompra

#Region " Variables "
	
	Private m_eabas_docscompra As EABAS_DocsCompra
	Private m_listABAS_DocsCompra As List(Of EABAS_DocsCompra)
	Private m_dtABAS_DocsCompra As DataTable

	Private m_dsABAS_DocsCompra As DataSet
	Private d_abas_docscompra As DABAS_DocsCompra 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_docscompra = New DABAS_DocsCompra()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_DocsCompra() As EABAS_DocsCompra 
		Get
			return m_eabas_docscompra
		End Get
		Set(ByVal value As EABAS_DocsCompra)
			m_eabas_docscompra = value
		End Set
	End Property

	Public Property ListABAS_DocsCompra() As List(Of EABAS_DocsCompra)
		Get
			return m_listABAS_DocsCompra
		End Get
		Set(ByVal value As List(Of EABAS_DocsCompra))
			m_listABAS_DocsCompra = value
		End Set
	End Property

	Public Property DTABAS_DocsCompra() As DataTable
		Get
			return m_dtABAS_DocsCompra
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_DocsCompra = value
		End Set
	End Property

	Public Property DSABAS_DocsCompra() As DataSet
		Get
			return m_dsABAS_DocsCompra
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_DocsCompra = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_DocsCompra = new List(Of EABAS_DocsCompra)()
			return d_abas_docscompra.ABAS_DOCCOSS_Todos(m_listABAS_DocsCompra)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_DocsCompra = new List(Of EABAS_DocsCompra)()
			return d_abas_docscompra.ABAS_DOCCOSS_Todos(m_listABAS_DocsCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_DocsCompra = new List(Of EABAS_DocsCompra)()
			return d_abas_docscompra.ABAS_DOCCOSS_Todos(m_listABAS_DocsCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_DocsCompra = new List(Of EABAS_DocsCompra)()
			return d_abas_docscompra.ABAS_DOCCOSS_Todos(m_listABAS_DocsCompra, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_entid_codigoproveedor As String) As Boolean
		Try
			m_eabas_docscompra = New EABAS_DocsCompra()
			Return d_abas_docscompra.ABAS_DOCCOSS_Todos(m_eabas_docscompra, x_entid_codigoproveedor)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_DocsCompra = new DataSet()
			return d_abas_docscompra.ABAS_DOCCOSS_Todos(m_dsABAS_DocsCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_DocsCompra = new DataSet()
			return d_abas_docscompra.ABAS_DOCCOSS_Todos(m_dsABAS_DocsCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_DocsCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_docscompra.ABAS_DOCCOSS_Todos(m_dsABAS_DocsCompra, x_where)
		If _opcion Then
			m_dtABAS_DocsCompra = m_dsABAS_DocsCompra.Tables(0)
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
			m_dsABAS_DocsCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_docscompra.ABAS_DOCCOSS_Todos(m_dsABAS_DocsCompra, x_join, x_where)
		If _opcion Then
			m_dtABAS_DocsCompra = m_dsABAS_DocsCompra.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docco_codigo As String, x_entid_codigoproveedor As String) As Boolean
		Try
			m_eabas_docscompra = New EABAS_DocsCompra()
			Return d_abas_docscompra.ABAS_DOCCOSS_UnReg(m_eabas_docscompra, x_docco_codigo, x_entid_codigoproveedor)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_docscompra = New EABAS_DocsCompra()
			Return d_abas_docscompra.ABAS_DOCCOSS_UnReg(m_eabas_docscompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_docscompra = New EABAS_DocsCompra()
			Return d_abas_docscompra.ABAS_DOCCOSS_UnReg(m_eabas_docscompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_docscompra.Nuevo Then
				d_abas_docscompra.ABAS_DOCCOSI_UnReg(m_eabas_docscompra, x_usuario)
			ElseIf m_eabas_docscompra.Modificado Then
				d_abas_docscompra.ABAS_DOCCOSU_UnReg(m_eabas_docscompra, x_usuario)
			ElseIf m_eabas_docscompra.Eliminado Then
				d_abas_docscompra.ABAS_DOCCOSD_UnReg(ABAS_DocsCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_docscompra.Nuevo Then
				d_abas_docscompra.ABAS_DOCCOSI_UnReg(m_eabas_docscompra, x_usuario)
			ElseIf m_eabas_docscompra.Modificado Then
				d_abas_docscompra.ABAS_DOCCOSU_UnReg(m_eabas_docscompra, x_where, x_usuario)
			ElseIf m_eabas_docscompra.Eliminado Then
				d_abas_docscompra.ABAS_DOCCOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_docscompra.Nuevo Then
				d_abas_docscompra.ABAS_DOCCOSI_UnReg(m_eabas_docscompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_docscompra.Modificado Then
				d_abas_docscompra.ABAS_DOCCOSU_UnReg(m_eabas_docscompra, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_docscompra.Eliminado Then
				d_abas_docscompra.ABAS_DOCCOSD_UnReg(ABAS_DocsCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eabas_docscompra.Nuevo Then
				d_abas_docscompra.ABAS_DOCCOSI_UnReg(m_eabas_docscompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_docscompra.Modificado Then
				d_abas_docscompra.ABAS_DOCCOSU_UnReg(m_eabas_docscompra, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eabas_docscompra.Eliminado Then
				d_abas_docscompra.ABAS_DOCCOSD_UnReg(ABAS_DocsCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_docscompra.Nuevo Then
				d_abas_docscompra.ABAS_DOCCOSI_UnReg(m_eabas_docscompra, x_usuario, x_setfecha)
			ElseIf m_eabas_docscompra.Modificado Then
				d_abas_docscompra.ABAS_DOCCOSU_UnReg(m_eabas_docscompra, x_usuario, x_setfecha)
			ElseIf m_eabas_docscompra.Eliminado Then
				d_abas_docscompra.ABAS_DOCCOSD_UnReg(ABAS_DocsCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_docscompra.Nuevo Then
				d_abas_docscompra.ABAS_DOCCOSI_UnReg(m_eabas_docscompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_docscompra.Eliminado Then
				d_abas_docscompra.ABAS_DOCCOSD_UnReg(ABAS_DocsCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_DocsCompra = new List(Of EABAS_DocsCompra)()
			return d_abas_docscompra.ABAS_DOCCOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_docscompra.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_docscompra.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_docscompra.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_docscompra.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

