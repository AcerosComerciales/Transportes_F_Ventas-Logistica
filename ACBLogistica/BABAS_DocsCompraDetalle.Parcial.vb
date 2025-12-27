Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_DocsCompraDetalle

#Region " Variables "
	
	Private m_eabas_docscompradetalle As EABAS_DocsCompraDetalle
	Private m_listABAS_DocsCompraDetalle As List(Of EABAS_DocsCompraDetalle)
	Private m_dtABAS_DocsCompraDetalle As DataTable

	Private m_dsABAS_DocsCompraDetalle As DataSet
	Private d_abas_docscompradetalle As DABAS_DocsCompraDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_docscompradetalle = New DABAS_DocsCompraDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_DocsCompraDetalle() As EABAS_DocsCompraDetalle 
		Get
			return m_eabas_docscompradetalle
		End Get
		Set(ByVal value As EABAS_DocsCompraDetalle)
			m_eabas_docscompradetalle = value
		End Set
	End Property

	Public Property ListABAS_DocsCompraDetalle() As List(Of EABAS_DocsCompraDetalle)
		Get
			return m_listABAS_DocsCompraDetalle
		End Get
		Set(ByVal value As List(Of EABAS_DocsCompraDetalle))
			m_listABAS_DocsCompraDetalle = value
		End Set
	End Property

	Public Property DTABAS_DocsCompraDetalle() As DataTable
		Get
			return m_dtABAS_DocsCompraDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_DocsCompraDetalle = value
		End Set
	End Property

	Public Property DSABAS_DocsCompraDetalle() As DataSet
		Get
			return m_dsABAS_DocsCompraDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_DocsCompraDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_DocsCompraDetalle = new List(Of EABAS_DocsCompraDetalle)()
			return d_abas_docscompradetalle.ABAS_DOCCDSS_Todos(m_listABAS_DocsCompraDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_DocsCompraDetalle = new List(Of EABAS_DocsCompraDetalle)()
			return d_abas_docscompradetalle.ABAS_DOCCDSS_Todos(m_listABAS_DocsCompraDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_DocsCompraDetalle = new List(Of EABAS_DocsCompraDetalle)()
			return d_abas_docscompradetalle.ABAS_DOCCDSS_Todos(m_listABAS_DocsCompraDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_DocsCompraDetalle = new List(Of EABAS_DocsCompraDetalle)()
			return d_abas_docscompradetalle.ABAS_DOCCDSS_Todos(m_listABAS_DocsCompraDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_docco_codigo As String, ByVal x_entid_codigoproveedor As String) As Boolean
		Try
			m_eabas_docscompradetalle = New EABAS_DocsCompraDetalle()
			Return d_abas_docscompradetalle.ABAS_DOCCDSS_Todos(m_eabas_docscompradetalle, x_docco_codigo, x_entid_codigoproveedor)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_DocsCompraDetalle = new DataSet()
			return d_abas_docscompradetalle.ABAS_DOCCDSS_Todos(m_dsABAS_DocsCompraDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_DocsCompraDetalle = new DataSet()
			return d_abas_docscompradetalle.ABAS_DOCCDSS_Todos(m_dsABAS_DocsCompraDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_DocsCompraDetalle = new DataSet()
			Dim _opcion As Boolean = d_abas_docscompradetalle.ABAS_DOCCDSS_Todos(m_dsABAS_DocsCompraDetalle, x_where)
		If _opcion Then
			m_dtABAS_DocsCompraDetalle = m_dsABAS_DocsCompraDetalle.Tables(0)
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
			m_dsABAS_DocsCompraDetalle = new DataSet()
			Dim _opcion As Boolean = d_abas_docscompradetalle.ABAS_DOCCDSS_Todos(m_dsABAS_DocsCompraDetalle, x_join, x_where)
		If _opcion Then
			m_dtABAS_DocsCompraDetalle = m_dsABAS_DocsCompraDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docco_codigo As String, x_entid_codigoproveedor As String, x_doccd_item As Short) As Boolean
		Try
			m_eabas_docscompradetalle = New EABAS_DocsCompraDetalle()
			Return d_abas_docscompradetalle.ABAS_DOCCDSS_UnReg(m_eabas_docscompradetalle, x_docco_codigo, x_entid_codigoproveedor, x_doccd_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_docscompradetalle = New EABAS_DocsCompraDetalle()
			Return d_abas_docscompradetalle.ABAS_DOCCDSS_UnReg(m_eabas_docscompradetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_docscompradetalle = New EABAS_DocsCompraDetalle()
			Return d_abas_docscompradetalle.ABAS_DOCCDSS_UnReg(m_eabas_docscompradetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_docscompradetalle.Nuevo Then
				d_abas_docscompradetalle.ABAS_DOCCDSI_UnReg(m_eabas_docscompradetalle, x_usuario)
			ElseIf m_eabas_docscompradetalle.Modificado Then
				d_abas_docscompradetalle.ABAS_DOCCDSU_UnReg(m_eabas_docscompradetalle, x_usuario)
			ElseIf m_eabas_docscompradetalle.Eliminado Then
				d_abas_docscompradetalle.ABAS_DOCCDSD_UnReg(ABAS_DocsCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_docscompradetalle.Nuevo Then
				d_abas_docscompradetalle.ABAS_DOCCDSI_UnReg(m_eabas_docscompradetalle, x_usuario)
			ElseIf m_eabas_docscompradetalle.Modificado Then
				d_abas_docscompradetalle.ABAS_DOCCDSU_UnReg(m_eabas_docscompradetalle, x_where, x_usuario)
			ElseIf m_eabas_docscompradetalle.Eliminado Then
				d_abas_docscompradetalle.ABAS_DOCCDSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_docscompradetalle.Nuevo Then
				d_abas_docscompradetalle.ABAS_DOCCDSI_UnReg(m_eabas_docscompradetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_docscompradetalle.Modificado Then
				d_abas_docscompradetalle.ABAS_DOCCDSU_UnReg(m_eabas_docscompradetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_docscompradetalle.Eliminado Then
				d_abas_docscompradetalle.ABAS_DOCCDSD_UnReg(ABAS_DocsCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eabas_docscompradetalle.Nuevo Then
				d_abas_docscompradetalle.ABAS_DOCCDSI_UnReg(m_eabas_docscompradetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_docscompradetalle.Modificado Then
				d_abas_docscompradetalle.ABAS_DOCCDSU_UnReg(m_eabas_docscompradetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eabas_docscompradetalle.Eliminado Then
				d_abas_docscompradetalle.ABAS_DOCCDSD_UnReg(ABAS_DocsCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_docscompradetalle.Nuevo Then
				d_abas_docscompradetalle.ABAS_DOCCDSI_UnReg(m_eabas_docscompradetalle, x_usuario, x_setfecha)
			ElseIf m_eabas_docscompradetalle.Modificado Then
				d_abas_docscompradetalle.ABAS_DOCCDSU_UnReg(m_eabas_docscompradetalle, x_usuario, x_setfecha)
			ElseIf m_eabas_docscompradetalle.Eliminado Then
				d_abas_docscompradetalle.ABAS_DOCCDSD_UnReg(ABAS_DocsCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_docscompradetalle.Nuevo Then
				d_abas_docscompradetalle.ABAS_DOCCDSI_UnReg(m_eabas_docscompradetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_docscompradetalle.Eliminado Then
				d_abas_docscompradetalle.ABAS_DOCCDSD_UnReg(ABAS_DocsCompraDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_DocsCompraDetalle = new List(Of EABAS_DocsCompraDetalle)()
			return d_abas_docscompradetalle.ABAS_DOCCDSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_docscompradetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_docscompradetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_docscompradetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_docscompradetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

