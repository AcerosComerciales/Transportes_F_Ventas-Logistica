Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BCTRL_InventarioRotativoDetalle

#Region " Variables "
	
	Private m_ectrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle
	Private m_listCTRL_InventarioRotativoDetalle As List(Of ECTRL_InventarioRotativoDetalle)
	Private m_dtCTRL_InventarioRotativoDetalle As DataTable

	Private m_dsCTRL_InventarioRotativoDetalle As DataSet
	Private d_ctrl_inventariorotativodetalle As DCTRL_InventarioRotativoDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_ctrl_inventariorotativodetalle = New DCTRL_InventarioRotativoDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property CTRL_InventarioRotativoDetalle() As ECTRL_InventarioRotativoDetalle 
		Get
			return m_ectrl_inventariorotativodetalle
		End Get
		Set(ByVal value As ECTRL_InventarioRotativoDetalle)
			m_ectrl_inventariorotativodetalle = value
		End Set
	End Property

	Public Property ListCTRL_InventarioRotativoDetalle() As List(Of ECTRL_InventarioRotativoDetalle)
		Get
			return m_listCTRL_InventarioRotativoDetalle
		End Get
		Set(ByVal value As List(Of ECTRL_InventarioRotativoDetalle))
			m_listCTRL_InventarioRotativoDetalle = value
		End Set
	End Property

	Public Property DTCTRL_InventarioRotativoDetalle() As DataTable
		Get
			return m_dtCTRL_InventarioRotativoDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtCTRL_InventarioRotativoDetalle = value
		End Set
	End Property

	Public Property DSCTRL_InventarioRotativoDetalle() As DataSet
		Get
			return m_dsCTRL_InventarioRotativoDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsCTRL_InventarioRotativoDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listCTRL_InventarioRotativoDetalle = new List(Of ECTRL_InventarioRotativoDetalle)()
			return d_ctrl_inventariorotativodetalle.CTRL_INROTSS_Todos(m_listCTRL_InventarioRotativoDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCTRL_InventarioRotativoDetalle = new List(Of ECTRL_InventarioRotativoDetalle)()
			return d_ctrl_inventariorotativodetalle.CTRL_INROTSS_Todos(m_listCTRL_InventarioRotativoDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listCTRL_InventarioRotativoDetalle = new List(Of ECTRL_InventarioRotativoDetalle)()
			return d_ctrl_inventariorotativodetalle.CTRL_INROTSS_Todos(m_listCTRL_InventarioRotativoDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listCTRL_InventarioRotativoDetalle = new List(Of ECTRL_InventarioRotativoDetalle)()
			return d_ctrl_inventariorotativodetalle.CTRL_INROTSS_Todos(m_listCTRL_InventarioRotativoDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCTRL_InventarioRotativoDetalle = new DataSet()
			return d_ctrl_inventariorotativodetalle.CTRL_INROTSS_Todos(m_dsCTRL_InventarioRotativoDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCTRL_InventarioRotativoDetalle = new DataSet()
			return d_ctrl_inventariorotativodetalle.CTRL_INROTSS_Todos(m_dsCTRL_InventarioRotativoDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsCTRL_InventarioRotativoDetalle = new DataSet()
			Dim _opcion As Boolean = d_ctrl_inventariorotativodetalle.CTRL_INROTSS_Todos(m_dsCTRL_InventarioRotativoDetalle, x_where)
		If _opcion Then
			m_dtCTRL_InventarioRotativoDetalle = m_dsCTRL_InventarioRotativoDetalle.Tables(0)
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
			m_dsCTRL_InventarioRotativoDetalle = new DataSet()
			Dim _opcion As Boolean = d_ctrl_inventariorotativodetalle.CTRL_INROTSS_Todos(m_dsCTRL_InventarioRotativoDetalle, x_join, x_where)
		If _opcion Then
			m_dtCTRL_InventarioRotativoDetalle = m_dsCTRL_InventarioRotativoDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_inrot_codigo As String, x_inrod_item As Integer) As Boolean
		Try
			m_ectrl_inventariorotativodetalle = New ECTRL_InventarioRotativoDetalle()
			Return d_ctrl_inventariorotativodetalle.CTRL_INROTSS_UnReg(m_ectrl_inventariorotativodetalle, x_inrot_codigo, x_inrod_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_ectrl_inventariorotativodetalle = New ECTRL_InventarioRotativoDetalle()
			Return d_ctrl_inventariorotativodetalle.CTRL_INROTSS_UnReg(m_ectrl_inventariorotativodetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_ectrl_inventariorotativodetalle = New ECTRL_InventarioRotativoDetalle()
			Return d_ctrl_inventariorotativodetalle.CTRL_INROTSS_UnReg(m_ectrl_inventariorotativodetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_ectrl_inventariorotativodetalle.Nuevo Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativodetalle, x_usuario)
			ElseIf m_ectrl_inventariorotativodetalle.Modificado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativodetalle, x_usuario)
			ElseIf m_ectrl_inventariorotativodetalle.Eliminado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSD_UnReg(CTRL_InventarioRotativoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_ectrl_inventariorotativodetalle.Nuevo Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativodetalle, x_usuario)
			ElseIf m_ectrl_inventariorotativodetalle.Modificado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativodetalle, x_where, x_usuario)
			ElseIf m_ectrl_inventariorotativodetalle.Eliminado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ectrl_inventariorotativodetalle.Nuevo Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativodetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ectrl_inventariorotativodetalle.Modificado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativodetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ectrl_inventariorotativodetalle.Eliminado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSD_UnReg(CTRL_InventarioRotativoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_ectrl_inventariorotativodetalle.Nuevo Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativodetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ectrl_inventariorotativodetalle.Modificado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativodetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_ectrl_inventariorotativodetalle.Eliminado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSD_UnReg(CTRL_InventarioRotativoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ectrl_inventariorotativodetalle.Nuevo Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativodetalle, x_usuario, x_setfecha)
			ElseIf m_ectrl_inventariorotativodetalle.Modificado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSU_UnReg(m_ectrl_inventariorotativodetalle, x_usuario, x_setfecha)
			ElseIf m_ectrl_inventariorotativodetalle.Eliminado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSD_UnReg(CTRL_InventarioRotativoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_ectrl_inventariorotativodetalle.Nuevo Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSI_UnReg(m_ectrl_inventariorotativodetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_ectrl_inventariorotativodetalle.Eliminado Then
				d_ctrl_inventariorotativodetalle.CTRL_INROTSD_UnReg(CTRL_InventarioRotativoDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listCTRL_InventarioRotativoDetalle = new List(Of ECTRL_InventarioRotativoDetalle)()
			return d_ctrl_inventariorotativodetalle.CTRL_INROTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_ctrl_inventariorotativodetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_ctrl_inventariorotativodetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_ctrl_inventariorotativodetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_ctrl_inventariorotativodetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

