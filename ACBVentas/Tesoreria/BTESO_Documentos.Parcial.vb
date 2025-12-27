Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_Documentos

#Region " Variables "
	
	Private m_eteso_documentos As ETESO_Documentos
	Private m_listTESO_Documentos As List(Of ETESO_Documentos)
	Private m_dtTESO_Documentos As DataTable

	Private m_dsTESO_Documentos As DataSet
	Private d_teso_documentos As DTESO_Documentos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_teso_documentos = New DTESO_Documentos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_Documentos() As ETESO_Documentos 
		Get
			return m_eteso_documentos
		End Get
		Set(ByVal value As ETESO_Documentos)
			m_eteso_documentos = value
		End Set
	End Property

	Public Property ListTESO_Documentos() As List(Of ETESO_Documentos)
		Get
			return m_listTESO_Documentos
		End Get
		Set(ByVal value As List(Of ETESO_Documentos))
			m_listTESO_Documentos = value
		End Set
	End Property

	Public Property DTTESO_Documentos() As DataTable
		Get
			return m_dtTESO_Documentos
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_Documentos = value
		End Set
	End Property

	Public Property DSTESO_Documentos() As DataSet
		Get
			return m_dsTESO_Documentos
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_Documentos = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_Documentos = new List(Of ETESO_Documentos)()
			return d_teso_documentos.TESO_DOCUSSS_Todos(m_listTESO_Documentos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Documentos = new List(Of ETESO_Documentos)()
			return d_teso_documentos.TESO_DOCUSSS_Todos(m_listTESO_Documentos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Documentos = new List(Of ETESO_Documentos)()
			return d_teso_documentos.TESO_DOCUSSS_Todos(m_listTESO_Documentos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_Documentos = new List(Of ETESO_Documentos)()
			return d_teso_documentos.TESO_DOCUSSS_Todos(m_listTESO_Documentos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_entid_codigo As String) As Boolean
		Try
			m_eteso_documentos = New ETESO_Documentos()
			Return d_teso_documentos.TESO_DOCUSSS_Todos(m_eteso_documentos, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Documentos = new DataSet()
			return d_teso_documentos.TESO_DOCUSSS_Todos(m_dsTESO_Documentos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Documentos = new DataSet()
			return d_teso_documentos.TESO_DOCUSSS_Todos(m_dsTESO_Documentos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Documentos = new DataSet()
			Dim _opcion As Boolean = d_teso_documentos.TESO_DOCUSSS_Todos(m_dsTESO_Documentos, x_where)
		If _opcion Then
			m_dtTESO_Documentos = m_dsTESO_Documentos.Tables(0)
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
			m_dsTESO_Documentos = new DataSet()
			Dim _opcion As Boolean = d_teso_documentos.TESO_DOCUSSS_Todos(m_dsTESO_Documentos, x_join, x_where)
		If _opcion Then
			m_dtTESO_Documentos = m_dsTESO_Documentos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_entid_codigo As String, x_docus_codigo As String) As Boolean
		Try
			m_eteso_documentos = New ETESO_Documentos()
			Return d_teso_documentos.TESO_DOCUSSS_UnReg(m_eteso_documentos, x_entid_codigo, x_docus_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_documentos = New ETESO_Documentos()
			Return d_teso_documentos.TESO_DOCUSSS_UnReg(m_eteso_documentos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_documentos = New ETESO_Documentos()
			Return d_teso_documentos.TESO_DOCUSSS_UnReg(m_eteso_documentos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_documentos.Nuevo Then
				d_teso_documentos.TESO_DOCUSSI_UnReg(m_eteso_documentos, x_usuario)
			ElseIf m_eteso_documentos.Modificado Then
				d_teso_documentos.TESO_DOCUSSU_UnReg(m_eteso_documentos, x_usuario)
			ElseIf m_eteso_documentos.Eliminado Then
				d_teso_documentos.TESO_DOCUSSD_UnReg(TESO_Documentos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_documentos.Nuevo Then
				d_teso_documentos.TESO_DOCUSSI_UnReg(m_eteso_documentos, x_usuario)
			ElseIf m_eteso_documentos.Modificado Then
				d_teso_documentos.TESO_DOCUSSU_UnReg(m_eteso_documentos, x_where, x_usuario)
			ElseIf m_eteso_documentos.Eliminado Then
				d_teso_documentos.TESO_DOCUSSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_documentos.Nuevo Then
				d_teso_documentos.TESO_DOCUSSI_UnReg(m_eteso_documentos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_documentos.Modificado Then
				d_teso_documentos.TESO_DOCUSSU_UnReg(m_eteso_documentos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_documentos.Eliminado Then
				d_teso_documentos.TESO_DOCUSSD_UnReg(TESO_Documentos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_documentos.Nuevo Then
				d_teso_documentos.TESO_DOCUSSI_UnReg(m_eteso_documentos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_documentos.Modificado Then
				d_teso_documentos.TESO_DOCUSSU_UnReg(m_eteso_documentos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_documentos.Eliminado Then
				d_teso_documentos.TESO_DOCUSSD_UnReg(TESO_Documentos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_documentos.Nuevo Then
				d_teso_documentos.TESO_DOCUSSI_UnReg(m_eteso_documentos, x_usuario, x_setfecha)
			ElseIf m_eteso_documentos.Modificado Then
				d_teso_documentos.TESO_DOCUSSU_UnReg(m_eteso_documentos, x_usuario, x_setfecha)
			ElseIf m_eteso_documentos.Eliminado Then
				d_teso_documentos.TESO_DOCUSSD_UnReg(TESO_Documentos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_documentos.Nuevo Then
				d_teso_documentos.TESO_DOCUSSI_UnReg(m_eteso_documentos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_documentos.Eliminado Then
				d_teso_documentos.TESO_DOCUSSD_UnReg(TESO_Documentos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Documentos = new List(Of ETESO_Documentos)()
			return d_teso_documentos.TESO_DOCUSSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_documentos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_documentos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_documentos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_documentos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

