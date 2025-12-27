Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_Piezas

#Region " Variables "
	
	Private m_tran_piezas As ETRAN_Piezas
	Private m_listTRAN_Piezas As List(Of ETRAN_Piezas)
	Private m_dtTRAN_Piezas As DataTable

	Private m_dsTRAN_Piezas As DataSet
	Private d_tran_piezas As DTRAN_Piezas 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_piezas = New DTRAN_Piezas()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_Piezas() As ETRAN_Piezas 
		Get
			return m_tran_piezas
		End Get
		Set(ByVal value As ETRAN_Piezas)
			m_tran_piezas = value
		End Set
	End Property

	Public Property ListTRAN_Piezas() As List(Of ETRAN_Piezas)
		Get
			return m_listTRAN_Piezas
		End Get
		Set(ByVal value As List(Of ETRAN_Piezas))
			m_listTRAN_Piezas = value
		End Set
	End Property

	Public Property DTTRAN_Piezas() As DataTable
		Get
			return m_dtTRAN_Piezas
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_Piezas = value
		End Set
	End Property

	Public Property DSTRAN_Piezas() As DataSet
		Get
			return m_dsTRAN_Piezas
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_Piezas = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_Piezas = new List(Of ETRAN_Piezas)()
			return d_tran_piezas.TRAN_PIEZASS_Todos(m_listTRAN_Piezas)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Piezas = new List(Of ETRAN_Piezas)()
			return d_tran_piezas.TRAN_PIEZASS_Todos(m_listTRAN_Piezas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Piezas = new List(Of ETRAN_Piezas)()
			return d_tran_piezas.TRAN_PIEZASS_Todos(m_listTRAN_Piezas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_Piezas = new List(Of ETRAN_Piezas)()
			return d_tran_piezas.TRAN_PIEZASS_Todos(m_listTRAN_Piezas, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Piezas = new DataSet()
			return d_tran_piezas.TRAN_PIEZASS_Todos(m_dsTRAN_Piezas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Piezas = new DataSet()
			return d_tran_piezas.TRAN_PIEZASS_Todos(m_dsTRAN_Piezas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Piezas = new DataSet()
			Dim _opcion As Boolean = d_tran_piezas.TRAN_PIEZASS_Todos(m_dsTRAN_Piezas, x_where)
		If _opcion Then
			m_dtTRAN_Piezas = m_dsTRAN_Piezas.Tables(0)
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
			m_dsTRAN_Piezas = new DataSet()
			Dim _opcion As Boolean = d_tran_piezas.TRAN_PIEZASS_Todos(m_dsTRAN_Piezas, x_join, x_where)
		If _opcion Then
			m_dtTRAN_Piezas = m_dsTRAN_Piezas.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    Public Function Cargar(ByVal x_pieza_id As Long) As Boolean
        Try
            m_tran_piezas = New ETRAN_Piezas()
            Return d_tran_piezas.TRAN_PIEZASS_UnReg(m_tran_piezas, x_pieza_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cargar_x_Descripcion(ByVal x_descripcion As String, where As Hashtable) As Boolean

        Try
            m_tran_piezas = New ETRAN_Piezas()
            Return d_tran_piezas.TRAN_PIEZASS_UnReg(m_tran_piezas, where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_piezas = New ETRAN_Piezas()
			Return d_tran_piezas.TRAN_PIEZASS_UnReg(m_tran_piezas, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_piezas = New ETRAN_Piezas()
			Return d_tran_piezas.TRAN_PIEZASS_UnReg(m_tran_piezas, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_piezas.Nuevo Then
				d_tran_piezas.TRAN_PIEZASI_UnReg(m_tran_piezas, x_usuario)
			ElseIf m_tran_piezas.Modificado Then
				d_tran_piezas.TRAN_PIEZASU_UnReg(m_tran_piezas, x_usuario)
			ElseIf m_tran_piezas.Eliminado Then
				d_tran_piezas.TRAN_PIEZASD_UnReg(TRAN_Piezas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_piezas.Nuevo Then
				d_tran_piezas.TRAN_PIEZASI_UnReg(m_tran_piezas, x_usuario)
			ElseIf m_tran_piezas.Modificado Then
				d_tran_piezas.TRAN_PIEZASU_UnReg(m_tran_piezas, x_where, x_usuario)
			ElseIf m_tran_piezas.Eliminado Then
				d_tran_piezas.TRAN_PIEZASD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_piezas.Nuevo Then
				d_tran_piezas.TRAN_PIEZASI_UnReg(m_tran_piezas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_piezas.Modificado Then
				d_tran_piezas.TRAN_PIEZASU_UnReg(m_tran_piezas, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_piezas.Eliminado Then
				d_tran_piezas.TRAN_PIEZASD_UnReg(TRAN_Piezas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_piezas.Nuevo Then
				d_tran_piezas.TRAN_PIEZASI_UnReg(m_tran_piezas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_piezas.Modificado Then
				d_tran_piezas.TRAN_PIEZASU_UnReg(m_tran_piezas, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_piezas.Eliminado Then
				d_tran_piezas.TRAN_PIEZASD_UnReg(TRAN_Piezas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_piezas.Nuevo Then
				d_tran_piezas.TRAN_PIEZASI_UnReg(m_tran_piezas, x_usuario, x_setfecha)
			ElseIf m_tran_piezas.Modificado Then
				d_tran_piezas.TRAN_PIEZASU_UnReg(m_tran_piezas, x_usuario, x_setfecha)
			ElseIf m_tran_piezas.Eliminado Then
				d_tran_piezas.TRAN_PIEZASD_UnReg(TRAN_Piezas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_piezas.Nuevo Then
				d_tran_piezas.TRAN_PIEZASI_UnReg(m_tran_piezas, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_piezas.Eliminado Then
				d_tran_piezas.TRAN_PIEZASD_UnReg(TRAN_Piezas)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Piezas = new List(Of ETRAN_Piezas)()
			return d_tran_piezas.TRAN_PIEZASD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_piezas.getCorrelativo("PIEZA_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_piezas.getCorrelativo("PIEZA_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_piezas.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_piezas.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_piezas.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_piezas.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

