Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_RelDocsCosteo

#Region " Variables "
	
	Private m_abas_reldocscosteo As EABAS_RelDocsCosteo
	Private m_listABAS_RelDocsCosteo As List(Of EABAS_RelDocsCosteo)
	Private m_dtABAS_RelDocsCosteo As DataTable

	Private m_dsABAS_RelDocsCosteo As DataSet
	Private d_abas_reldocscosteo As DABAS_RelDocsCosteo 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_reldocscosteo = New DABAS_RelDocsCosteo()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_RelDocsCosteo() As EABAS_RelDocsCosteo 
		Get
			return m_abas_reldocscosteo
		End Get
		Set(ByVal value As EABAS_RelDocsCosteo)
			m_abas_reldocscosteo = value
		End Set
	End Property
	Public Property ListABAS_RelDocsCosteo() As List(Of EABAS_RelDocsCosteo)
		Get
			return m_listABAS_RelDocsCosteo
		End Get
		Set(ByVal value As List(Of EABAS_RelDocsCosteo))
			m_listABAS_RelDocsCosteo = value
		End Set
	End Property
	Public Property DTABAS_RelDocsCosteo() As DataTable
		Get
			return m_dtABAS_RelDocsCosteo
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_RelDocsCosteo = value
		End Set
	End Property
	Public Property DSABAS_RelDocsCosteo() As DataSet
		Get
			return m_dsABAS_RelDocsCosteo
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_RelDocsCosteo = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListABAS_RelDocsCosteo() As List(Of EABAS_RelDocsCosteo)
			Return Me.m_listABAS_RelDocsCosteo
		End Function
		Public Sub setListABAS_RelDocsCosteo(ByVal _listabas_reldocscosteo As List (Of EABAS_RelDocsCosteo))
			Me.m_listABAS_RelDocsCosteo = m_listabas_reldocscosteo 
		End Sub
		Public Function getABAS_RelDocsCosteo() As EABAS_RelDocsCosteo
			Return Me.m_abas_reldocscosteo
		End Function
		Public Sub setABAS_RelDocsCosteo(ByVal x_abas_reldocscosteo As EABAS_RelDocsCosteo)
			Me.m_abas_reldocscosteo = x_abas_reldocscosteo 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_RelDocsCosteo = new List(Of EABAS_RelDocsCosteo)()
			return d_abas_reldocscosteo.ABAS_DOCCOSS_Todos(m_listABAS_RelDocsCosteo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_RelDocsCosteo = new List(Of EABAS_RelDocsCosteo)()
			return d_abas_reldocscosteo.ABAS_DOCCOSS_Todos(m_listABAS_RelDocsCosteo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_RelDocsCosteo = new List(Of EABAS_RelDocsCosteo)()
			return d_abas_reldocscosteo.ABAS_DOCCOSS_Todos(m_listABAS_RelDocsCosteo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_RelDocsCosteo = new List(Of EABAS_RelDocsCosteo)()
			return d_abas_reldocscosteo.ABAS_DOCCOSS_Todos(m_listABAS_RelDocsCosteo, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_RelDocsCosteo = new DataSet()
			return d_abas_reldocscosteo.ABAS_DOCCOSS_Todos(m_dsABAS_RelDocsCosteo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_RelDocsCosteo = new DataSet()
			return d_abas_reldocscosteo.ABAS_DOCCOSS_Todos(m_dsABAS_RelDocsCosteo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_RelDocsCosteo = new DataSet()
			Dim _opcion As Boolean = d_abas_reldocscosteo.ABAS_DOCCOSS_Todos(m_dsABAS_RelDocsCosteo, x_where)
		If _opcion Then
			m_dtABAS_RelDocsCosteo = m_dsABAS_RelDocsCosteo.Tables(0)
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
			m_dsABAS_RelDocsCosteo = new DataSet()
			Dim _opcion As Boolean = d_abas_reldocscosteo.ABAS_DOCCOSS_Todos(m_dsABAS_RelDocsCosteo, x_join, x_where)
		If _opcion Then
			m_dtABAS_RelDocsCosteo = m_dsABAS_RelDocsCosteo.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docco_codigo As String, x_doccd_item As Short, x_entid_codigoproveedor As String, x_coste_item As Short) As Boolean
		Try
			m_abas_reldocscosteo = New EABAS_RelDocsCosteo()
			Return d_abas_reldocscosteo.ABAS_DOCCOSS_UnReg(m_abas_reldocscosteo, x_docco_codigo, x_doccd_item, x_entid_codigoproveedor, x_coste_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_abas_reldocscosteo = New EABAS_RelDocsCosteo()
			Return d_abas_reldocscosteo.ABAS_DOCCOSS_UnReg(m_abas_reldocscosteo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_abas_reldocscosteo = New EABAS_RelDocsCosteo()
			Return d_abas_reldocscosteo.ABAS_DOCCOSS_UnReg(m_abas_reldocscosteo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_abas_reldocscosteo.Nuevo Then
				d_abas_reldocscosteo.ABAS_DOCCOSI_UnReg(m_abas_reldocscosteo, x_usuario)
			ElseIf m_abas_reldocscosteo.Modificado Then
				d_abas_reldocscosteo.ABAS_DOCCOSU_UnReg(m_abas_reldocscosteo, x_usuario)
			ElseIf m_abas_reldocscosteo.Eliminado Then
				d_abas_reldocscosteo.ABAS_DOCCOSD_UnReg(m_abas_reldocscosteo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_abas_reldocscosteo.Nuevo Then
				d_abas_reldocscosteo.ABAS_DOCCOSI_UnReg(m_abas_reldocscosteo, x_usuario)
			ElseIf m_abas_reldocscosteo.Modificado Then
				d_abas_reldocscosteo.ABAS_DOCCOSU_UnReg(m_abas_reldocscosteo, x_where, x_usuario)
			ElseIf m_abas_reldocscosteo.Eliminado Then
				d_abas_reldocscosteo.ABAS_DOCCOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_reldocscosteo.Nuevo Then
				d_abas_reldocscosteo.ABAS_DOCCOSI_UnReg(m_abas_reldocscosteo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_reldocscosteo.Modificado Then
				d_abas_reldocscosteo.ABAS_DOCCOSU_UnReg(m_abas_reldocscosteo, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_reldocscosteo.Eliminado Then
				d_abas_reldocscosteo.ABAS_DOCCOSD_UnReg(m_abas_reldocscosteo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_abas_reldocscosteo.Nuevo Then
				d_abas_reldocscosteo.ABAS_DOCCOSI_UnReg(m_abas_reldocscosteo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_reldocscosteo.Modificado Then
				d_abas_reldocscosteo.ABAS_DOCCOSU_UnReg(m_abas_reldocscosteo, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_abas_reldocscosteo.Eliminado Then
				d_abas_reldocscosteo.ABAS_DOCCOSD_UnReg(m_abas_reldocscosteo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_reldocscosteo.Nuevo Then
				d_abas_reldocscosteo.ABAS_DOCCOSI_UnReg(m_abas_reldocscosteo, x_usuario, x_setfecha)
			ElseIf m_abas_reldocscosteo.Modificado Then
				d_abas_reldocscosteo.ABAS_DOCCOSU_UnReg(m_abas_reldocscosteo, x_usuario, x_setfecha)
			ElseIf m_abas_reldocscosteo.Eliminado Then
				d_abas_reldocscosteo.ABAS_DOCCOSD_UnReg(m_abas_reldocscosteo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_abas_reldocscosteo.Nuevo Then
				d_abas_reldocscosteo.ABAS_DOCCOSI_UnReg(m_abas_reldocscosteo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_abas_reldocscosteo.Eliminado Then
				d_abas_reldocscosteo.ABAS_DOCCOSD_UnReg(m_abas_reldocscosteo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_RelDocsCosteo = new List(Of EABAS_RelDocsCosteo)()
			return d_abas_reldocscosteo.ABAS_DOCCOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_reldocscosteo.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_reldocscosteo.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_reldocscosteo.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_reldocscosteo.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

