Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BCTRL_InventarioRotativo

#Region " Variables "
	
	Private m_ectrl_inventariorotativo As ECTRL_InventarioRotativo
	Private m_listCTRL_InventarioRotativo As List(Of ECTRL_InventarioRotativo)
	Private m_dtCTRL_InventarioRotativo As DataTable

	Private m_dsCTRL_InventarioRotativo As DataSet
	Private d_ctrl_inventariorotativo As DCTRL_InventarioRotativo 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_ctrl_inventariorotativo = New DCTRL_InventarioRotativo()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property CTRL_InventarioRotativo() As ECTRL_InventarioRotativo 
		Get
			return m_ectrl_inventariorotativo
		End Get
		Set(ByVal value As ECTRL_InventarioRotativo)
			m_ectrl_inventariorotativo = value
		End Set
	End Property

	Public Property ListCTRL_InventarioRotativo() As List(Of ECTRL_InventarioRotativo)
		Get
			return m_listCTRL_InventarioRotativo
		End Get
		Set(ByVal value As List(Of ECTRL_InventarioRotativo))
			m_listCTRL_InventarioRotativo = value
		End Set
	End Property

	Public Property DTCTRL_InventarioRotativo() As DataTable
		Get
			return m_dtCTRL_InventarioRotativo
		End Get
		Set(ByVal value As DataTable)
			m_dtCTRL_InventarioRotativo = value
		End Set
	End Property

	Public Property DSCTRL_InventarioRotativo() As DataSet
		Get
			return m_dsCTRL_InventarioRotativo
		End Get
		Set(ByVal value As DataSet)
			m_dsCTRL_InventarioRotativo = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listCTRL_InventarioRotativo = new List(Of ECTRL_InventarioRotativo)()
			return d_ctrl_inventariorotativo.CTRL_INROTSS_Todos(m_listCTRL_InventarioRotativo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCTRL_InventarioRotativo = new List(Of ECTRL_InventarioRotativo)()
			return d_ctrl_inventariorotativo.CTRL_INROTSS_Todos(m_listCTRL_InventarioRotativo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listCTRL_InventarioRotativo = new List(Of ECTRL_InventarioRotativo)()
			return d_ctrl_inventariorotativo.CTRL_INROTSS_Todos(m_listCTRL_InventarioRotativo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listCTRL_InventarioRotativo = new List(Of ECTRL_InventarioRotativo)()
			return d_ctrl_inventariorotativo.CTRL_INROTSS_Todos(m_listCTRL_InventarioRotativo, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCTRL_InventarioRotativo = new DataSet()
			return d_ctrl_inventariorotativo.CTRL_INROTSS_Todos(m_dsCTRL_InventarioRotativo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCTRL_InventarioRotativo = new DataSet()
			return d_ctrl_inventariorotativo.CTRL_INROTSS_Todos(m_dsCTRL_InventarioRotativo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCTRL_InventarioRotativo = new DataSet()
			Dim _opcion As Boolean = d_ctrl_inventariorotativo.CTRL_INROTSS_Todos(m_dsCTRL_InventarioRotativo, x_where)
		If _opcion Then
			m_dtCTRL_InventarioRotativo = m_dsCTRL_InventarioRotativo.Tables(0)
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
			m_dsCTRL_InventarioRotativo = new DataSet()
			Dim _opcion As Boolean = d_ctrl_inventariorotativo.CTRL_INROTSS_Todos(m_dsCTRL_InventarioRotativo, x_join, x_where)
		If _opcion Then
			m_dtCTRL_InventarioRotativo = m_dsCTRL_InventarioRotativo.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_inrot_codigo As String) As Boolean
		Try
			m_ectrl_inventariorotativo = New ECTRL_InventarioRotativo()
			Return d_ctrl_inventariorotativo.CTRL_INROTSS_UnReg(m_ectrl_inventariorotativo, x_inrot_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_ectrl_inventariorotativo = New ECTRL_InventarioRotativo()
			Return d_ctrl_inventariorotativo.CTRL_INROTSS_UnReg(m_ectrl_inventariorotativo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_ectrl_inventariorotativo = New ECTRL_InventarioRotativo()
			Return d_ctrl_inventariorotativo.CTRL_INROTSS_UnReg(m_ectrl_inventariorotativo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_ectrl_inventariorotativo.Nuevo Then
				d_ctrl_inventariorotativo.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativo, x_usuario)
			ElseIf m_ectrl_inventariorotativo.Modificado Then
				d_ctrl_inventariorotativo.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativo, x_usuario)
			ElseIf m_ectrl_inventariorotativo.Eliminado Then
				d_ctrl_inventariorotativo.CTRL_INROTSD_UnReg(CTRL_InventarioRotativo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_ectrl_inventariorotativo.Nuevo Then
				d_ctrl_inventariorotativo.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativo, x_usuario)
			ElseIf m_ectrl_inventariorotativo.Modificado Then
				d_ctrl_inventariorotativo.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativo, x_where, x_usuario)
			ElseIf m_ectrl_inventariorotativo.Eliminado Then
				d_ctrl_inventariorotativo.CTRL_INROTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ectrl_inventariorotativo.Nuevo Then
				d_ctrl_inventariorotativo.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ectrl_inventariorotativo.Modificado Then
				d_ctrl_inventariorotativo.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativo, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ectrl_inventariorotativo.Eliminado Then
				d_ctrl_inventariorotativo.CTRL_INROTSD_UnReg(CTRL_InventarioRotativo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_ectrl_inventariorotativo.Nuevo Then
				d_ctrl_inventariorotativo.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ectrl_inventariorotativo.Modificado Then
				d_ctrl_inventariorotativo.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativo, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_ectrl_inventariorotativo.Eliminado Then
				d_ctrl_inventariorotativo.CTRL_INROTSD_UnReg(CTRL_InventarioRotativo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ectrl_inventariorotativo.Nuevo Then
				d_ctrl_inventariorotativo.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativo, x_usuario, x_setfecha)
			ElseIf m_ectrl_inventariorotativo.Modificado Then
				d_ctrl_inventariorotativo.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativo, x_usuario, x_setfecha)
			ElseIf m_ectrl_inventariorotativo.Eliminado Then
				d_ctrl_inventariorotativo.CTRL_INROTSD_UnReg(CTRL_InventarioRotativo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ectrl_inventariorotativo.Nuevo Then
				d_ctrl_inventariorotativo.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ectrl_inventariorotativo.Eliminado Then
				d_ctrl_inventariorotativo.CTRL_INROTSD_UnReg(CTRL_InventarioRotativo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCTRL_InventarioRotativo = new List(Of ECTRL_InventarioRotativo)()
			return d_ctrl_inventariorotativo.CTRL_INROTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_ctrl_inventariorotativo.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_ctrl_inventariorotativo.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_ctrl_inventariorotativo.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_ctrl_inventariorotativo.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

