Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_Recibos

#Region " Variables "
	
	Private m_eteso_recibos As ETESO_Recibos
	Private m_listTESO_Recibos As List(Of ETESO_Recibos)
	Private m_list_RecibosPendientesAFavor As List(Of ETESO_Recibos)
	Private m_dtTESO_Recibos As DataTable

	Private m_dsTESO_Recibos As DataSet
    Private d_teso_recibos As DTESO_Recibos

    Private m_pvent_id As Integer



#End Region

#Region " Constructores "

    Public Sub New()
        d_teso_recibos = New DTESO_Recibos()
    End Sub

    Public Sub New(ByVal x_pvent_id As Integer)
        m_pvent_id = m_pvent_id
        d_teso_recibos = New DTESO_Recibos()

    End Sub

    Public Property DTTESO_TesoRecibos() As DataTable
        Get
            Return m_dtTESO_Recibos
        End Get
        Set(ByVal value As DataTable)
            m_dtTESO_Recibos = value
        End Set
    End Property
#End Region

#Region " Propiedades "

    Public Property TESO_Recibos() As ETESO_Recibos 
		Get
			return m_eteso_recibos
		End Get
		Set(ByVal value As ETESO_Recibos)
			m_eteso_recibos = value
		End Set
	End Property

	Public Property ListTESO_Recibos() As List(Of ETESO_Recibos)
		Get
			return m_listTESO_Recibos
		End Get
		Set(ByVal value As List(Of ETESO_Recibos))
			m_listTESO_Recibos = value
		End Set
	End Property

	Public Property DTTESO_Recibos() As DataTable
		Get
			return m_dtTESO_Recibos
		End Get
		Set(ByVal value As DataTable)
			m_dtTESO_Recibos = value
		End Set
	End Property

	Public Property DSTESO_Recibos() As DataSet
		Get
			return m_dsTESO_Recibos
		End Get
		Set(ByVal value As DataSet)
			m_dsTESO_Recibos = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "

	''' <summary>
	''' Procedimiento almacenado para Obtener el Saldo Pendiente que se Debe a un cliente By Frank
	''' </summary>
	''' <param name="x_fecini">fecha inicial de buqeuda</param>
	''' <param name="x_fecfin">fecha final de busqueda</param>
	''' <param name="x_entid_codigo"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function TRAN_CAJASS_ObtenerSaldosAFavorClientePendientes(ByVal x_entid_codigo As String) As Boolean
		Try
			m_list_RecibosPendientesAFavor = New List(Of ETESO_Recibos)
			Return d_teso_recibos.TRAN_CAJASS_ObtenerSaldosAFavorClientePendientes(m_list_RecibosPendientesAFavor, x_entid_codigo)
			'm_listTRAN_VehiculosMantenimientoDetalle = New List(Of ETRAN_VehiculosMantenimientoDetalle)
			'Try
			'	Return d_tran_vehiculosmantenimiento.TRAN_REPOSS_VehiculoMantenimientos(x_campo, x_placa, m_listTRAN_VehiculosMantenimientoDetalle, x_fecini, x_fecfin)
			'Catch ex As Exception
			'	Throw ex
			'End Try
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

#Region " Metodos "

	Public Function CargarTodos() As Boolean
		Try
			m_listTESO_Recibos = new List(Of ETESO_Recibos)()
			return d_teso_recibos.TESO_RECIBSS_Todos(m_listTESO_Recibos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Recibos = new List(Of ETESO_Recibos)()
			return d_teso_recibos.TESO_RECIBSS_Todos(m_listTESO_Recibos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Recibos = new List(Of ETESO_Recibos)()
			return d_teso_recibos.TESO_RECIBSS_Todos(m_listTESO_Recibos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTESO_Recibos = new List(Of ETESO_Recibos)()
			return d_teso_recibos.TESO_RECIBSS_Todos(m_listTESO_Recibos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Recibos = new DataSet()
			return d_teso_recibos.TESO_RECIBSS_Todos(m_dsTESO_Recibos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Recibos = new DataSet()
			return d_teso_recibos.TESO_RECIBSS_Todos(m_dsTESO_Recibos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTESO_Recibos = new DataSet()
			Dim _opcion As Boolean = d_teso_recibos.TESO_RECIBSS_Todos(m_dsTESO_Recibos, x_where)
		If _opcion Then
			m_dtTESO_Recibos = m_dsTESO_Recibos.Tables(0)
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
			m_dsTESO_Recibos = new DataSet()
			Dim _opcion As Boolean = d_teso_recibos.TESO_RECIBSS_Todos(m_dsTESO_Recibos, x_join, x_where)
		If _opcion Then
			m_dtTESO_Recibos = m_dsTESO_Recibos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    Public Function Cargar(ByVal x_recib_codigo As String) As Boolean
        Try
            m_eteso_recibos = New ETESO_Recibos()
            Return d_teso_recibos.TESO_RECIBSS_UnReg(m_eteso_recibos, x_recib_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Funciont de Ayuda 
    Public Function Ayuda(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String) As Boolean
        Try
            Dim _dteso_recibo As New BTESO_Recibos(m_pvent_id)
            If _dteso_recibo.AyudaSaldo(x_entid_codigo) Then
                m_dtTESO_Recibos = New DataTable() : m_dtTESO_Recibos = _dteso_recibo.DTTESO_TesoRecibos
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Function AyudaSaldo(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String) As Boolean

    Public Function AyudaSaldo(ByVal x_entid_codigo As String) As Boolean
        Try
            If d_teso_recibos.getAyudaSaldo(m_dsTESO_Recibos, x_entid_codigo) Then
                m_dtTESO_Recibos = New DataTable()
                m_dtTESO_Recibos = m_dsTESO_Recibos.Tables(0)
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_recibos = New ETESO_Recibos()
			Return d_teso_recibos.TESO_RECIBSS_UnReg(m_eteso_recibos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_eteso_recibos = New ETESO_Recibos()
			Return d_teso_recibos.TESO_RECIBSS_UnReg(m_eteso_recibos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_recibos.Nuevo Then
				d_teso_recibos.TESO_RECIBSI_UnReg(m_eteso_recibos, x_usuario)
			ElseIf m_eteso_recibos.Modificado Then
				d_teso_recibos.TESO_RECIBSU_UnReg(m_eteso_recibos, x_usuario)
			ElseIf m_eteso_recibos.Eliminado Then
				d_teso_recibos.TESO_RECIBSD_UnReg(TESO_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_eteso_recibos.Nuevo Then
				d_teso_recibos.TESO_RECIBSI_UnReg(m_eteso_recibos, x_usuario)
			ElseIf m_eteso_recibos.Modificado Then
				d_teso_recibos.TESO_RECIBSU_UnReg(m_eteso_recibos, x_where, x_usuario)
			ElseIf m_eteso_recibos.Eliminado Then
				d_teso_recibos.TESO_RECIBSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_recibos.Nuevo Then
				d_teso_recibos.TESO_RECIBSI_UnReg(m_eteso_recibos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_recibos.Modificado Then
				d_teso_recibos.TESO_RECIBSU_UnReg(m_eteso_recibos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_recibos.Eliminado Then
				d_teso_recibos.TESO_RECIBSD_UnReg(TESO_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_eteso_recibos.Nuevo Then
				d_teso_recibos.TESO_RECIBSI_UnReg(m_eteso_recibos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_recibos.Modificado Then
				d_teso_recibos.TESO_RECIBSU_UnReg(m_eteso_recibos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_eteso_recibos.Eliminado Then
				d_teso_recibos.TESO_RECIBSD_UnReg(TESO_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_recibos.Nuevo Then
				d_teso_recibos.TESO_RECIBSI_UnReg(m_eteso_recibos, x_usuario, x_setfecha)
			ElseIf m_eteso_recibos.Modificado Then
				d_teso_recibos.TESO_RECIBSU_UnReg(m_eteso_recibos, x_usuario, x_setfecha)
			ElseIf m_eteso_recibos.Eliminado Then
				d_teso_recibos.TESO_RECIBSD_UnReg(TESO_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_eteso_recibos.Nuevo Then
				d_teso_recibos.TESO_RECIBSI_UnReg(m_eteso_recibos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_eteso_recibos.Eliminado Then
				d_teso_recibos.TESO_RECIBSD_UnReg(TESO_Recibos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTESO_Recibos = new List(Of ETESO_Recibos)()
			return d_teso_recibos.TESO_RECIBSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_teso_recibos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_teso_recibos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_teso_recibos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    Public Function getENTIDAD(ByVal x_campo As String, ByVal x_where As Hashtable) As string
		Try
			Return d_teso_recibos.getEntidad(x_campo, x_where)  
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_teso_recibos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

