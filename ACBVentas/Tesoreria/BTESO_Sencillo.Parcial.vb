Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_Sencillo

#Region " Variables "
	
	Private m_eteso_sencillo As ETESO_Sencillo
	Private m_listTESO_Sencillo As List(Of ETESO_Sencillo)
	Private m_dtTESO_Sencillo As DataTable

	Private m_dsTESO_Sencillo As DataSet
	Private d_teso_sencillo As DTESO_Sencillo 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_teso_sencillo = New DTESO_Sencillo()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_Sencillo() As ETESO_Sencillo 
		Get
			return m_eteso_sencillo
		End Get
		Set(ByVal value As ETESO_Sencillo)
			m_eteso_sencillo = value
		End Set
	End Property

	Public Property ListTESO_Sencillo() As List(Of ETESO_Sencillo)
		Get
			return m_listTESO_Sencillo
		End Get
		Set(ByVal value As List(Of ETESO_Sencillo))
			m_listTESO_Sencillo = value
		End Set
	End Property

	Public Property DTTESO_Sencillo() As DataTable
		Get
			return m_dtTESO_Sencillo
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_Sencillo = value
		End Set
	End Property

	Public Property DSTESO_Sencillo() As DataSet
		Get
			return m_dsTESO_Sencillo
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_Sencillo = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_Sencillo = new List(Of ETESO_Sencillo)()
			return d_teso_sencillo.TESO_SENCISS_Todos(m_listTESO_Sencillo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Sencillo = new List(Of ETESO_Sencillo)()
			return d_teso_sencillo.TESO_SENCISS_Todos(m_listTESO_Sencillo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Sencillo = new List(Of ETESO_Sencillo)()
			return d_teso_sencillo.TESO_SENCISS_Todos(m_listTESO_Sencillo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_Sencillo = new List(Of ETESO_Sencillo)()
			return d_teso_sencillo.TESO_SENCISS_Todos(m_listTESO_Sencillo, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_pvent_id As Long) As Boolean
		Try
			m_eteso_sencillo = New ETESO_Sencillo()
			Return d_teso_sencillo.TESO_SENCISS_Todos(m_eteso_sencillo, x_pvent_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Sencillo = new DataSet()
			return d_teso_sencillo.TESO_SENCISS_Todos(m_dsTESO_Sencillo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Sencillo = new DataSet()
			return d_teso_sencillo.TESO_SENCISS_Todos(m_dsTESO_Sencillo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Sencillo = new DataSet()
			Dim _opcion As Boolean = d_teso_sencillo.TESO_SENCISS_Todos(m_dsTESO_Sencillo, x_where)
		If _opcion Then
			m_dtTESO_Sencillo = m_dsTESO_Sencillo.Tables(0)
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
			m_dsTESO_Sencillo = new DataSet()
			Dim _opcion As Boolean = d_teso_sencillo.TESO_SENCISS_Todos(m_dsTESO_Sencillo, x_join, x_where)
		If _opcion Then
			m_dtTESO_Sencillo = m_dsTESO_Sencillo.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pvent_id As Long, x_senci_id As Long) As Boolean
		Try
			m_eteso_sencillo = New ETESO_Sencillo()
			Return d_teso_sencillo.TESO_SENCISS_UnReg(m_eteso_sencillo, x_pvent_id, x_senci_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_sencillo = New ETESO_Sencillo()
			Return d_teso_sencillo.TESO_SENCISS_UnReg(m_eteso_sencillo, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_sencillo = New ETESO_Sencillo()
			Return d_teso_sencillo.TESO_SENCISS_UnReg(m_eteso_sencillo, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_sencillo.Nuevo Then
				d_teso_sencillo.TESO_SENCISI_UnReg(m_eteso_sencillo, x_usuario)
			ElseIf m_eteso_sencillo.Modificado Then
				d_teso_sencillo.TESO_SENCISU_UnReg(m_eteso_sencillo, x_usuario)
			ElseIf m_eteso_sencillo.Eliminado Then
				d_teso_sencillo.TESO_SENCISD_UnReg(TESO_Sencillo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_sencillo.Nuevo Then
				d_teso_sencillo.TESO_SENCISI_UnReg(m_eteso_sencillo, x_usuario)
			ElseIf m_eteso_sencillo.Modificado Then
				d_teso_sencillo.TESO_SENCISU_UnReg(m_eteso_sencillo, x_where, x_usuario)
			ElseIf m_eteso_sencillo.Eliminado Then
				d_teso_sencillo.TESO_SENCISD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_sencillo.Nuevo Then
				d_teso_sencillo.TESO_SENCISI_UnReg(m_eteso_sencillo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_sencillo.Modificado Then
				d_teso_sencillo.TESO_SENCISU_UnReg(m_eteso_sencillo, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_sencillo.Eliminado Then
				d_teso_sencillo.TESO_SENCISD_UnReg(TESO_Sencillo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_sencillo.Nuevo Then
				d_teso_sencillo.TESO_SENCISI_UnReg(m_eteso_sencillo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_sencillo.Modificado Then
				d_teso_sencillo.TESO_SENCISU_UnReg(m_eteso_sencillo, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_sencillo.Eliminado Then
				d_teso_sencillo.TESO_SENCISD_UnReg(TESO_Sencillo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_sencillo.Nuevo Then
				d_teso_sencillo.TESO_SENCISI_UnReg(m_eteso_sencillo, x_usuario, x_setfecha)
			ElseIf m_eteso_sencillo.Modificado Then
				d_teso_sencillo.TESO_SENCISU_UnReg(m_eteso_sencillo, x_usuario, x_setfecha)
			ElseIf m_eteso_sencillo.Eliminado Then
				d_teso_sencillo.TESO_SENCISD_UnReg(TESO_Sencillo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_sencillo.Nuevo Then
				d_teso_sencillo.TESO_SENCISI_UnReg(m_eteso_sencillo, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_sencillo.Eliminado Then
				d_teso_sencillo.TESO_SENCISD_UnReg(TESO_Sencillo)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Sencillo = new List(Of ETESO_Sencillo)()
			return d_teso_sencillo.TESO_SENCISD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_teso_sencillo.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_teso_sencillo.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_sencillo.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_sencillo.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_sencillo.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_sencillo.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	' <summary> 
	' Capa de Negocio: TESO_ConsultaSencillo
	' </summary>
	' <param name="x_fecini">Parametro 1: </param> 
	' <param name="x_fecfin">Parametro 2: </param> 
	' <param name="x_cadena">Parametro 3: </param> 
	' <param name="x_pvent_id">Parametro 4: </param> 
	' <param name="x_todos">Parametro 5: </param> 
	' <returns></returns> 
	' <remarks></remarks> 
	Public Function ConsultaSencillo(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_todos As Boolean) As Boolean

        m_listTESO_Sencillo = New List(Of ETESO_Sencillo)
        Try
            Return d_teso_sencillo.TESO_ConsultaSencillo(m_listTESO_Sencillo, x_fecini, x_fecfin, x_pvent_id, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class

