Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_DocumentosDetalle

#Region " Variables "
	
	Private m_eteso_documentosdetalle As ETESO_DocumentosDetalle
	Private m_listTESO_DocumentosDetalle As List(Of ETESO_DocumentosDetalle)
	Private m_dtTESO_DocumentosDetalle As DataTable

	Private m_dsTESO_DocumentosDetalle As DataSet
	Private d_teso_documentosdetalle As DTESO_DocumentosDetalle 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_teso_documentosdetalle = New DTESO_DocumentosDetalle()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_DocumentosDetalle() As ETESO_DocumentosDetalle 
		Get
			return m_eteso_documentosdetalle
		End Get
		Set(ByVal value As ETESO_DocumentosDetalle)
			m_eteso_documentosdetalle = value
		End Set
	End Property

	Public Property ListTESO_DocumentosDetalle() As List(Of ETESO_DocumentosDetalle)
		Get
			return m_listTESO_DocumentosDetalle
		End Get
		Set(ByVal value As List(Of ETESO_DocumentosDetalle))
			m_listTESO_DocumentosDetalle = value
		End Set
	End Property

	Public Property DTTESO_DocumentosDetalle() As DataTable
		Get
			return m_dtTESO_DocumentosDetalle
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_DocumentosDetalle = value
		End Set
	End Property

	Public Property DSTESO_DocumentosDetalle() As DataSet
		Get
			return m_dsTESO_DocumentosDetalle
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_DocumentosDetalle = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_DocumentosDetalle = new List(Of ETESO_DocumentosDetalle)()
			return d_teso_documentosdetalle.TESO_DCDETSS_Todos(m_listTESO_DocumentosDetalle)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_DocumentosDetalle = new List(Of ETESO_DocumentosDetalle)()
			return d_teso_documentosdetalle.TESO_DCDETSS_Todos(m_listTESO_DocumentosDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_DocumentosDetalle = new List(Of ETESO_DocumentosDetalle)()
			return d_teso_documentosdetalle.TESO_DCDETSS_Todos(m_listTESO_DocumentosDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_DocumentosDetalle = new List(Of ETESO_DocumentosDetalle)()
			return d_teso_documentosdetalle.TESO_DCDETSS_Todos(m_listTESO_DocumentosDetalle, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String) As Boolean
		Try
			m_eteso_documentosdetalle = New ETESO_DocumentosDetalle()
			Return d_teso_documentosdetalle.TESO_DCDETSS_Todos(m_eteso_documentosdetalle, x_docus_codigo, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_DocumentosDetalle = new DataSet()
			return d_teso_documentosdetalle.TESO_DCDETSS_Todos(m_dsTESO_DocumentosDetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_DocumentosDetalle = new DataSet()
			return d_teso_documentosdetalle.TESO_DCDETSS_Todos(m_dsTESO_DocumentosDetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_DocumentosDetalle = new DataSet()
			Dim _opcion As Boolean = d_teso_documentosdetalle.TESO_DCDETSS_Todos(m_dsTESO_DocumentosDetalle, x_where)
		If _opcion Then
			m_dtTESO_DocumentosDetalle = m_dsTESO_DocumentosDetalle.Tables(0)
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
			m_dsTESO_DocumentosDetalle = new DataSet()
			Dim _opcion As Boolean = d_teso_documentosdetalle.TESO_DCDETSS_Todos(m_dsTESO_DocumentosDetalle, x_join, x_where)
		If _opcion Then
			m_dtTESO_DocumentosDetalle = m_dsTESO_DocumentosDetalle.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docus_codigo As String, x_entid_codigo As String, x_dcdet_item As Short) As Boolean
		Try
			m_eteso_documentosdetalle = New ETESO_DocumentosDetalle()
			Return d_teso_documentosdetalle.TESO_DCDETSS_UnReg(m_eteso_documentosdetalle, x_docus_codigo, x_entid_codigo, x_dcdet_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_documentosdetalle = New ETESO_DocumentosDetalle()
			Return d_teso_documentosdetalle.TESO_DCDETSS_UnReg(m_eteso_documentosdetalle, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_documentosdetalle = New ETESO_DocumentosDetalle()
			Return d_teso_documentosdetalle.TESO_DCDETSS_UnReg(m_eteso_documentosdetalle, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_documentosdetalle.Nuevo Then
				d_teso_documentosdetalle.TESO_DCDETSI_UnReg(m_eteso_documentosdetalle, x_usuario)
			ElseIf m_eteso_documentosdetalle.Modificado Then
				d_teso_documentosdetalle.TESO_DCDETSU_UnReg(m_eteso_documentosdetalle, x_usuario)
			ElseIf m_eteso_documentosdetalle.Eliminado Then
				d_teso_documentosdetalle.TESO_DCDETSD_UnReg(TESO_DocumentosDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_documentosdetalle.Nuevo Then
				d_teso_documentosdetalle.TESO_DCDETSI_UnReg(m_eteso_documentosdetalle, x_usuario)
			ElseIf m_eteso_documentosdetalle.Modificado Then
				d_teso_documentosdetalle.TESO_DCDETSU_UnReg(m_eteso_documentosdetalle, x_where, x_usuario)
			ElseIf m_eteso_documentosdetalle.Eliminado Then
				d_teso_documentosdetalle.TESO_DCDETSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_documentosdetalle.Nuevo Then
				d_teso_documentosdetalle.TESO_DCDETSI_UnReg(m_eteso_documentosdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_documentosdetalle.Modificado Then
				d_teso_documentosdetalle.TESO_DCDETSU_UnReg(m_eteso_documentosdetalle, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_documentosdetalle.Eliminado Then
				d_teso_documentosdetalle.TESO_DCDETSD_UnReg(TESO_DocumentosDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_documentosdetalle.Nuevo Then
				d_teso_documentosdetalle.TESO_DCDETSI_UnReg(m_eteso_documentosdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_documentosdetalle.Modificado Then
				d_teso_documentosdetalle.TESO_DCDETSU_UnReg(m_eteso_documentosdetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_documentosdetalle.Eliminado Then
				d_teso_documentosdetalle.TESO_DCDETSD_UnReg(TESO_DocumentosDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_documentosdetalle.Nuevo Then
				d_teso_documentosdetalle.TESO_DCDETSI_UnReg(m_eteso_documentosdetalle, x_usuario, x_setfecha)
			ElseIf m_eteso_documentosdetalle.Modificado Then
				d_teso_documentosdetalle.TESO_DCDETSU_UnReg(m_eteso_documentosdetalle, x_usuario, x_setfecha)
			ElseIf m_eteso_documentosdetalle.Eliminado Then
				d_teso_documentosdetalle.TESO_DCDETSD_UnReg(TESO_DocumentosDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_documentosdetalle.Nuevo Then
				d_teso_documentosdetalle.TESO_DCDETSI_UnReg(m_eteso_documentosdetalle, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_documentosdetalle.Eliminado Then
				d_teso_documentosdetalle.TESO_DCDETSD_UnReg(TESO_DocumentosDetalle)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_DocumentosDetalle = new List(Of ETESO_DocumentosDetalle)()
			return d_teso_documentosdetalle.TESO_DCDETSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_documentosdetalle.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_documentosdetalle.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_documentosdetalle.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_documentosdetalle.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

