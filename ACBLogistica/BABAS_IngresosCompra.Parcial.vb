Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BABAS_IngresosCompra

#Region " Variables "
	
	Private m_eabas_ingresoscompra As EABAS_IngresosCompra
	Private m_listABAS_IngresosCompra As List(Of EABAS_IngresosCompra)
	Private m_dtABAS_IngresosCompra As DataTable

	Private m_dsABAS_IngresosCompra As DataSet
	Private d_abas_ingresoscompra As DABAS_IngresosCompra 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_abas_ingresoscompra = New DABAS_IngresosCompra()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property ABAS_IngresosCompra() As EABAS_IngresosCompra 
		Get
			return m_eabas_ingresoscompra
		End Get
		Set(ByVal value As EABAS_IngresosCompra)
			m_eabas_ingresoscompra = value
		End Set
	End Property

	Public Property ListABAS_IngresosCompra() As List(Of EABAS_IngresosCompra)
		Get
			return m_listABAS_IngresosCompra
		End Get
		Set(ByVal value As List(Of EABAS_IngresosCompra))
			m_listABAS_IngresosCompra = value
		End Set
	End Property

	Public Property DTABAS_IngresosCompra() As DataTable
		Get
			return m_dtABAS_IngresosCompra
		End Get
		Set(ByVal value As DataTable)
			m_dtABAS_IngresosCompra = value
		End Set
	End Property

	Public Property DSABAS_IngresosCompra() As DataSet
		Get
			return m_dsABAS_IngresosCompra
		End Get
		Set(ByVal value As DataSet)
			m_dsABAS_IngresosCompra = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listABAS_IngresosCompra = new List(Of EABAS_IngresosCompra)()
			return d_abas_ingresoscompra.ABAS_INGCOSS_Todos(m_listABAS_IngresosCompra)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_IngresosCompra = new List(Of EABAS_IngresosCompra)()
			return d_abas_ingresoscompra.ABAS_INGCOSS_Todos(m_listABAS_IngresosCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_IngresosCompra = new List(Of EABAS_IngresosCompra)()
			return d_abas_ingresoscompra.ABAS_INGCOSS_Todos(m_listABAS_IngresosCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listABAS_IngresosCompra = new List(Of EABAS_IngresosCompra)()
			return d_abas_ingresoscompra.ABAS_INGCOSS_Todos(m_listABAS_IngresosCompra, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_almac_id As Short) As Boolean
		Try
			m_eabas_ingresoscompra = New EABAS_IngresosCompra()
			Return d_abas_ingresoscompra.ABAS_INGCOSS_Todos(m_eabas_ingresoscompra, x_almac_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_IngresosCompra = new DataSet()
			return d_abas_ingresoscompra.ABAS_INGCOSS_Todos(m_dsABAS_IngresosCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_IngresosCompra = new DataSet()
			return d_abas_ingresoscompra.ABAS_INGCOSS_Todos(m_dsABAS_IngresosCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsABAS_IngresosCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_ingresoscompra.ABAS_INGCOSS_Todos(m_dsABAS_IngresosCompra, x_where)
		If _opcion Then
			m_dtABAS_IngresosCompra = m_dsABAS_IngresosCompra.Tables(0)
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
			m_dsABAS_IngresosCompra = new DataSet()
			Dim _opcion As Boolean = d_abas_ingresoscompra.ABAS_INGCOSS_Todos(m_dsABAS_IngresosCompra, x_join, x_where)
		If _opcion Then
			m_dtABAS_IngresosCompra = m_dsABAS_IngresosCompra.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_almac_id As Short, x_ingco_id As Long) As Boolean
		Try
			m_eabas_ingresoscompra = New EABAS_IngresosCompra()
			Return d_abas_ingresoscompra.ABAS_INGCOSS_UnReg(m_eabas_ingresoscompra, x_almac_id, x_ingco_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_ingresoscompra = New EABAS_IngresosCompra()
			Return d_abas_ingresoscompra.ABAS_INGCOSS_UnReg(m_eabas_ingresoscompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eabas_ingresoscompra = New EABAS_IngresosCompra()
			Return d_abas_ingresoscompra.ABAS_INGCOSS_UnReg(m_eabas_ingresoscompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_ingresoscompra.Nuevo Then
				d_abas_ingresoscompra.ABAS_INGCOSI_UnReg(m_eabas_ingresoscompra, x_usuario)
			ElseIf m_eabas_ingresoscompra.Modificado Then
				d_abas_ingresoscompra.ABAS_INGCOSU_UnReg(m_eabas_ingresoscompra, x_usuario)
			ElseIf m_eabas_ingresoscompra.Eliminado Then
				d_abas_ingresoscompra.ABAS_INGCOSD_UnReg(ABAS_IngresosCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eabas_ingresoscompra.Nuevo Then
				d_abas_ingresoscompra.ABAS_INGCOSI_UnReg(m_eabas_ingresoscompra, x_usuario)
			ElseIf m_eabas_ingresoscompra.Modificado Then
				d_abas_ingresoscompra.ABAS_INGCOSU_UnReg(m_eabas_ingresoscompra, x_where, x_usuario)
			ElseIf m_eabas_ingresoscompra.Eliminado Then
				d_abas_ingresoscompra.ABAS_INGCOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_ingresoscompra.Nuevo Then
				d_abas_ingresoscompra.ABAS_INGCOSI_UnReg(m_eabas_ingresoscompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ingresoscompra.Modificado Then
				d_abas_ingresoscompra.ABAS_INGCOSU_UnReg(m_eabas_ingresoscompra, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ingresoscompra.Eliminado Then
				d_abas_ingresoscompra.ABAS_INGCOSD_UnReg(ABAS_IngresosCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eabas_ingresoscompra.Nuevo Then
				d_abas_ingresoscompra.ABAS_INGCOSI_UnReg(m_eabas_ingresoscompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ingresoscompra.Modificado Then
				d_abas_ingresoscompra.ABAS_INGCOSU_UnReg(m_eabas_ingresoscompra, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eabas_ingresoscompra.Eliminado Then
				d_abas_ingresoscompra.ABAS_INGCOSD_UnReg(ABAS_IngresosCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_ingresoscompra.Nuevo Then
				d_abas_ingresoscompra.ABAS_INGCOSI_UnReg(m_eabas_ingresoscompra, x_usuario, x_setfecha)
			ElseIf m_eabas_ingresoscompra.Modificado Then
				d_abas_ingresoscompra.ABAS_INGCOSU_UnReg(m_eabas_ingresoscompra, x_usuario, x_setfecha)
			ElseIf m_eabas_ingresoscompra.Eliminado Then
				d_abas_ingresoscompra.ABAS_INGCOSD_UnReg(ABAS_IngresosCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eabas_ingresoscompra.Nuevo Then
				d_abas_ingresoscompra.ABAS_INGCOSI_UnReg(m_eabas_ingresoscompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eabas_ingresoscompra.Eliminado Then
				d_abas_ingresoscompra.ABAS_INGCOSD_UnReg(ABAS_IngresosCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listABAS_IngresosCompra = new List(Of EABAS_IngresosCompra)()
			return d_abas_ingresoscompra.ABAS_INGCOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_abas_ingresoscompra.getCorrelativo("ALMAC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_abas_ingresoscompra.getCorrelativo("ALMAC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_abas_ingresoscompra.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_abas_ingresoscompra.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_abas_ingresoscompra.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_abas_ingresoscompra.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

