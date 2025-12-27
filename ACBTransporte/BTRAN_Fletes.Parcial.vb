Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_Fletes

#Region " Variables "
	
	Private m_tran_fletes As ETRAN_Fletes
	Private m_listTRAN_Fletes As List(Of ETRAN_Fletes)
	Private m_dtTRAN_Fletes As DataTable

	Private m_dsTRAN_Fletes As DataSet
	Private d_tran_fletes As DTRAN_Fletes 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_fletes = New DTRAN_Fletes()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_Fletes() As ETRAN_Fletes 
		Get
			return m_tran_fletes
		End Get
		Set(ByVal value As ETRAN_Fletes)
			m_tran_fletes = value
		End Set
	End Property
	Public Property ListTRAN_Fletes() As List(Of ETRAN_Fletes)
		Get
			return m_listTRAN_Fletes
		End Get
		Set(ByVal value As List(Of ETRAN_Fletes))
			m_listTRAN_Fletes = value
		End Set
	End Property
	Public Property DTTRAN_Fletes() As DataTable
		Get
			return m_dtTRAN_Fletes
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_Fletes = value
		End Set
	End Property
	Public Property DSTRAN_Fletes() As DataSet
		Get
			return m_dsTRAN_Fletes
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_Fletes = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_Fletes() As List(Of ETRAN_Fletes)
			Return Me.m_listTRAN_Fletes
		End Function
		Public Sub setListTRAN_Fletes(ByVal _listtran_fletes As List (Of ETRAN_Fletes))
			Me.m_listTRAN_Fletes = m_listtran_fletes 
		End Sub
		Public Function getTRAN_Fletes() As ETRAN_Fletes
			Return Me.m_tran_fletes
		End Function
		Public Sub setTRAN_Fletes(ByVal x_tran_fletes As ETRAN_Fletes)
			Me.m_tran_fletes = x_tran_fletes 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_Fletes = new List(Of ETRAN_Fletes)()
			return d_tran_fletes.TRAN_FLETESS_Todos(m_listTRAN_Fletes)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Fletes = new List(Of ETRAN_Fletes)()
			return d_tran_fletes.TRAN_FLETESS_Todos(m_listTRAN_Fletes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Fletes = new List(Of ETRAN_Fletes)()
			return d_tran_fletes.TRAN_FLETESS_Todos(m_listTRAN_Fletes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_Fletes = new List(Of ETRAN_Fletes)()
			return d_tran_fletes.TRAN_FLETESS_Todos(m_listTRAN_Fletes, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Fletes = new DataSet()
			return d_tran_fletes.TRAN_FLETESS_Todos(m_dsTRAN_Fletes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Fletes = new DataSet()
			return d_tran_fletes.TRAN_FLETESS_Todos(m_dsTRAN_Fletes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_Fletes = new DataSet()
			Dim _opcion As Boolean = d_tran_fletes.TRAN_FLETESS_Todos(m_dsTRAN_Fletes, x_where)
		If _opcion Then
			m_dtTRAN_Fletes = m_dsTRAN_Fletes.Tables(0)
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
			m_dsTRAN_Fletes = new DataSet()
			Dim _opcion As Boolean = d_tran_fletes.TRAN_FLETESS_Todos(m_dsTRAN_Fletes, x_join, x_where)
		If _opcion Then
			m_dtTRAN_Fletes = m_dsTRAN_Fletes.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    Public Function Cargar(ByVal x_flete_id As Long) As Boolean
        Try
            m_tran_fletes = New ETRAN_Fletes()
            Return d_tran_fletes.TRAN_FLETESS_UnReg(m_tran_fletes, x_flete_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CargarXCotiz(ByVal x_cotiz_codigo As String) As Boolean
        Try
            m_tran_fletes = New ETRAN_Fletes()
            Return d_tran_fletes.TRAN_FLETESS_UnRegXCotiz(m_tran_fletes, x_cotiz_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_fletes = New ETRAN_Fletes()
			Return d_tran_fletes.TRAN_FLETESS_UnReg(m_tran_fletes, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_fletes = New ETRAN_Fletes()
			Return d_tran_fletes.TRAN_FLETESS_UnReg(m_tran_fletes, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
    End Function

    Public Function Guardar(ByVal x_usuario As String) As Boolean
        Try
            If m_tran_fletes.Nuevo Then
                d_tran_fletes.TRAN_FLETESI_UnReg(m_tran_fletes, x_usuario)
            ElseIf m_tran_fletes.Modificado Then
                d_tran_fletes.TRAN_FLETESU_UnReg(m_tran_fletes, x_usuario)
            ElseIf m_tran_fletes.Eliminado Then
                d_tran_fletes.TRAN_FLETESD_UnReg(m_tran_fletes)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GuardarFleteXCotizacion(ByVal x_usuario As String) As Boolean
        Try

            d_tran_fletes.TRAN_FLETESU_UnReg(m_tran_fletes, x_usuario)

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_fletes.Nuevo Then
				d_tran_fletes.TRAN_FLETESI_UnReg(m_tran_fletes, x_usuario)
			ElseIf m_tran_fletes.Modificado Then
				d_tran_fletes.TRAN_FLETESU_UnReg(m_tran_fletes, x_where, x_usuario)
			ElseIf m_tran_fletes.Eliminado Then
				d_tran_fletes.TRAN_FLETESD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_fletes.Nuevo Then
				d_tran_fletes.TRAN_FLETESI_UnReg(m_tran_fletes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_fletes.Modificado Then
				d_tran_fletes.TRAN_FLETESU_UnReg(m_tran_fletes, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_fletes.Eliminado Then
				d_tran_fletes.TRAN_FLETESD_UnReg(m_tran_fletes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_fletes.Nuevo Then
				d_tran_fletes.TRAN_FLETESI_UnReg(m_tran_fletes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_fletes.Modificado Then
				d_tran_fletes.TRAN_FLETESU_UnReg(m_tran_fletes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_fletes.Eliminado Then
				d_tran_fletes.TRAN_FLETESD_UnReg(m_tran_fletes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_fletes.Nuevo Then
				d_tran_fletes.TRAN_FLETESI_UnReg(m_tran_fletes, x_usuario, x_setfecha)
			ElseIf m_tran_fletes.Modificado Then
				d_tran_fletes.TRAN_FLETESU_UnReg(m_tran_fletes, x_usuario, x_setfecha)
			ElseIf m_tran_fletes.Eliminado Then
				d_tran_fletes.TRAN_FLETESD_UnReg(m_tran_fletes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_fletes.Nuevo Then
				d_tran_fletes.TRAN_FLETESI_UnReg(m_tran_fletes, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_fletes.Eliminado Then
				d_tran_fletes.TRAN_FLETESD_UnReg(m_tran_fletes)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_Fletes = new List(Of ETRAN_Fletes)()
			return d_tran_fletes.TRAN_FLETESD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_fletes.getCorrelativo("FLETE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_fletes.getCorrelativo("FLETE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_fletes.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_fletes.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_fletes.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_fletes.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

