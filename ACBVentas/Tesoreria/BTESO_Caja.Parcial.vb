Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_Caja

#Region " Variables "
	
	Private m_eteso_caja As ETESO_Caja
    Private m_eteso_caja_dp As ETESO_DocsPagos
	Private m_listTESO_Caja As List(Of ETESO_Caja)
	Private m_dtTESO_Caja As DataTable

	Private m_dsTESO_Caja As DataSet
	Private d_teso_caja As DTESO_Caja
    Private d_teso_caja_dp As DTESO_DocsPagos


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_teso_caja = New DTESO_Caja()
        d_teso_caja_dp = new DTESO_DocsPagos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TESO_Caja() As ETESO_Caja 
		Get
			return m_eteso_caja
		End Get
		Set(ByVal value As ETESO_Caja)
			m_eteso_caja = value
		End Set
	End Property
    Public Property TESO_DocsPagos() As ETESO_DocsPagos 
		Get
			return m_eteso_caja_dp
		End Get
		Set(ByVal value As ETESO_DocsPagos)
			m_eteso_caja_dp = value
		End Set
	End Property

	Public Property ListTESO_Caja() As List(Of ETESO_Caja)
		Get
			return m_listTESO_Caja
		End Get
		Set(ByVal value As List(Of ETESO_Caja))
			m_listTESO_Caja = value
		End Set
	End Property

	Public Property DTTESO_Caja() As DataTable
		Get
			return m_dtTESO_Caja
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_Caja = value
		End Set
	End Property

	Public Property DSTESO_Caja() As DataSet
		Get
			return m_dsTESO_Caja
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_Caja = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_Caja = new List(Of ETESO_Caja)()
			return d_teso_caja.TESO_CAJASS_Todos(m_listTESO_Caja)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Caja = new List(Of ETESO_Caja)()
			return d_teso_caja.TESO_CAJASS_Todos(m_listTESO_Caja, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Caja = new List(Of ETESO_Caja)()
			return d_teso_caja.TESO_CAJASS_Todos(m_listTESO_Caja, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_Caja = new List(Of ETESO_Caja)()
			return d_teso_caja.TESO_CAJASS_Todos(m_listTESO_Caja, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_pvent_id As Long) As Boolean
		Try
			m_eteso_caja = New ETESO_Caja()
			Return d_teso_caja.TESO_CAJASS_Todos(m_eteso_caja, x_pvent_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Caja = new DataSet()
			return d_teso_caja.TESO_CAJASS_Todos(m_dsTESO_Caja, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Caja = new DataSet()
			return d_teso_caja.TESO_CAJASS_Todos(m_dsTESO_Caja, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Caja = new DataSet()
			Dim _opcion As Boolean = d_teso_caja.TESO_CAJASS_Todos(m_dsTESO_Caja, x_where)
		If _opcion Then
			m_dtTESO_Caja = m_dsTESO_Caja.Tables(0)
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
			m_dsTESO_Caja = new DataSet()
			Dim _opcion As Boolean = d_teso_caja.TESO_CAJASS_Todos(m_dsTESO_Caja, x_join, x_where)
		If _opcion Then
			m_dtTESO_Caja = m_dsTESO_Caja.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_pvent_id As Long, x_caja_id As Long) As Boolean
		Try
			m_eteso_caja = New ETESO_Caja()
			Return d_teso_caja.TESO_CAJASS_UnReg(m_eteso_caja, x_pvent_id, x_caja_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_caja = New ETESO_Caja()
			Return d_teso_caja.TESO_CAJASS_UnReg(m_eteso_caja, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_caja = New ETESO_Caja()
			Return d_teso_caja.TESO_CAJASS_UnReg(m_eteso_caja, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    ''validar pagos _A

    Public Function Cargar_DP(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Array) As Boolean
        Try
            m_eteso_caja = New ETESO_Caja()
            Return d_teso_caja.TESO_CAJASS_UnReg_p(m_eteso_caja, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' </summary>
    ' <param name="x_where"></param>
    ' <returns></returns>
    ' <remarks></remarks>



    Public Function Guardar(ByVal x_usuario As String) As Boolean
        Try
            If m_eteso_caja.Nuevo Then
                d_teso_caja.TESO_CAJASI_UnReg(m_eteso_caja, x_usuario)
            ElseIf m_eteso_caja.Modificado Then
                d_teso_caja.TESO_CAJASU_UnReg(m_eteso_caja, x_usuario)
            ElseIf m_eteso_caja.Eliminado Then
                d_teso_caja.TESO_CAJASD_UnReg(TESO_Caja)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_caja.Nuevo Then
				d_teso_caja.TESO_CAJASI_UnReg(m_eteso_caja, x_usuario)
			ElseIf m_eteso_caja.Modificado Then
				d_teso_caja.TESO_CAJASU_UnReg(m_eteso_caja, x_where, x_usuario)
			ElseIf m_eteso_caja.Eliminado Then
				d_teso_caja.TESO_CAJASD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_caja.Nuevo Then
				d_teso_caja.TESO_CAJASI_UnReg(m_eteso_caja, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_caja.Modificado Then
				d_teso_caja.TESO_CAJASU_UnReg(m_eteso_caja, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_caja.Eliminado Then
				d_teso_caja.TESO_CAJASD_UnReg(TESO_Caja)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_caja.Nuevo Then
				d_teso_caja.TESO_CAJASI_UnReg(m_eteso_caja, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_caja.Modificado Then
				d_teso_caja.TESO_CAJASU_UnReg(m_eteso_caja, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_caja.Eliminado Then
				d_teso_caja.TESO_CAJASD_UnReg(TESO_Caja)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_caja.Nuevo Then
				d_teso_caja.TESO_CAJASI_UnReg(m_eteso_caja, x_usuario, x_setfecha)
			ElseIf m_eteso_caja.Modificado Then
				d_teso_caja.TESO_CAJASU_UnReg(m_eteso_caja, x_usuario, x_setfecha)
			ElseIf m_eteso_caja.Eliminado Then
				d_teso_caja.TESO_CAJASD_UnReg(TESO_Caja)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_caja.Nuevo Then
				d_teso_caja.TESO_CAJASI_UnReg(m_eteso_caja, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_caja.Eliminado Then
				d_teso_caja.TESO_CAJASD_UnReg(TESO_Caja)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Caja = new List(Of ETESO_Caja)()
			return d_teso_caja.TESO_CAJASD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_teso_caja.getCorrelativo("PVENT_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_teso_caja.getCorrelativo("PVENT_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_caja.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_caja.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_caja.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_caja.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

