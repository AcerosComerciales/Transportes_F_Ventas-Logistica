Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_VehiculosMantenimientoDocCompra

#Region " Variables "
	
	Private m_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra
	Private m_listTRAN_VehiculosMantenimientoDocCompra As List(Of ETRAN_VehiculosMantenimientoDocCompra)
	Private m_dtTRAN_VehiculosMantenimientoDocCompra As DataTable

	Private m_dsTRAN_VehiculosMantenimientoDocCompra As DataSet
	Private d_tran_vehiculosmantenimientodoccompra As DTRAN_VehiculosMantenimientoDocCompra 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_tran_vehiculosmantenimientodoccompra = New DTRAN_VehiculosMantenimientoDocCompra()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_VehiculosMantenimientoDocCompra() As ETRAN_VehiculosMantenimientoDocCompra 
		Get
			return m_tran_vehiculosmantenimientodoccompra
		End Get
		Set(ByVal value As ETRAN_VehiculosMantenimientoDocCompra)
			m_tran_vehiculosmantenimientodoccompra = value
		End Set
	End Property

	Public Property ListTRAN_VehiculosMantenimientoDocCompra() As List(Of ETRAN_VehiculosMantenimientoDocCompra)
		Get
			return m_listTRAN_VehiculosMantenimientoDocCompra
		End Get
		Set(ByVal value As List(Of ETRAN_VehiculosMantenimientoDocCompra))
			m_listTRAN_VehiculosMantenimientoDocCompra = value
		End Set
	End Property

	Public Property DTTRAN_VehiculosMantenimientoDocCompra() As DataTable
		Get
			return m_dtTRAN_VehiculosMantenimientoDocCompra
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_VehiculosMantenimientoDocCompra = value
		End Set
	End Property

	Public Property DSTRAN_VehiculosMantenimientoDocCompra() As DataSet
		Get
			return m_dsTRAN_VehiculosMantenimientoDocCompra
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_VehiculosMantenimientoDocCompra = value
		End Set
	End Property


#End Region

#Region " Funciones para obtencion de datos "
    Public Function TRAN_VMAN_ObtenerMantenimientosDeleteDocCompra(ByVal x_vehic_id As Long, ByVal x_docus_codigo As String, ByVal x_vman_item As Long) As Boolean
        Try
            ' m_listTRAN_VehiculosMantenimientoDocCompra = New List(Of ETRAN_VehiculosMantenimientoDocCompra)()
            Return d_tran_vehiculosmantenimientodoccompra.TRAN_VMAN_ObtenerMantenimientosDeleteDocCompra(x_vehic_id, x_docus_codigo, x_vman_item)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Metodos "

    Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDocCompra = new List(Of ETRAN_VehiculosMantenimientoDocCompra)()
			return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_Todos(m_listTRAN_VehiculosMantenimientoDocCompra)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDocCompra = new List(Of ETRAN_VehiculosMantenimientoDocCompra)()
			return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_Todos(m_listTRAN_VehiculosMantenimientoDocCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDocCompra = new List(Of ETRAN_VehiculosMantenimientoDocCompra)()
			return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_Todos(m_listTRAN_VehiculosMantenimientoDocCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDocCompra = new List(Of ETRAN_VehiculosMantenimientoDocCompra)()
			return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_Todos(m_listTRAN_VehiculosMantenimientoDocCompra, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_vehic_id As Long, ByVal x_vman_item As Long) As Boolean
		Try
			m_tran_vehiculosmantenimientodoccompra = New ETRAN_VehiculosMantenimientoDocCompra()
			Return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_Todos(m_tran_vehiculosmantenimientodoccompra, x_docus_codigo, x_entid_codigo, x_vehic_id, x_vman_item)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosMantenimientoDocCompra = new DataSet()
			return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_Todos(m_dsTRAN_VehiculosMantenimientoDocCompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosMantenimientoDocCompra = new DataSet()
			return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_Todos(m_dsTRAN_VehiculosMantenimientoDocCompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_VehiculosMantenimientoDocCompra = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_Todos(m_dsTRAN_VehiculosMantenimientoDocCompra, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosMantenimientoDocCompra = m_dsTRAN_VehiculosMantenimientoDocCompra.Tables(0)
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
			m_dsTRAN_VehiculosMantenimientoDocCompra = new DataSet()
			Dim _opcion As Boolean = d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_Todos(m_dsTRAN_VehiculosMantenimientoDocCompra, x_join, x_where)
		If _opcion Then
			m_dtTRAN_VehiculosMantenimientoDocCompra = m_dsTRAN_VehiculosMantenimientoDocCompra.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_docus_codigo As String, x_entid_codigo As String, x_vehic_id As Long, x_vman_item As Long, x_vmdco_numero As Short) As Boolean
		Try
			m_tran_vehiculosmantenimientodoccompra = New ETRAN_VehiculosMantenimientoDocCompra()
			Return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_UnReg(m_tran_vehiculosmantenimientodoccompra, x_docus_codigo, x_entid_codigo, x_vehic_id, x_vman_item, x_vmdco_numero)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosmantenimientodoccompra = New ETRAN_VehiculosMantenimientoDocCompra()
			Return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_UnReg(m_tran_vehiculosmantenimientodoccompra, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_vehiculosmantenimientodoccompra = New ETRAN_VehiculosMantenimientoDocCompra()
			Return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSS_UnReg(m_tran_vehiculosmantenimientodoccompra, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodoccompra.Nuevo Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSI_UnReg(m_tran_vehiculosmantenimientodoccompra, x_usuario)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Modificado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSU_UnReg(m_tran_vehiculosmantenimientodoccompra, x_usuario)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Eliminado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSD_UnReg(TRAN_VehiculosMantenimientoDocCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodoccompra.Nuevo Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSI_UnReg(m_tran_vehiculosmantenimientodoccompra, x_usuario)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Modificado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSU_UnReg(m_tran_vehiculosmantenimientodoccompra, x_where, x_usuario)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Eliminado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodoccompra.Nuevo Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSI_UnReg(m_tran_vehiculosmantenimientodoccompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Modificado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSU_UnReg(m_tran_vehiculosmantenimientodoccompra, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Eliminado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSD_UnReg(TRAN_VehiculosMantenimientoDocCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodoccompra.Nuevo Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSI_UnReg(m_tran_vehiculosmantenimientodoccompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Modificado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSU_UnReg(m_tran_vehiculosmantenimientodoccompra, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Eliminado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSD_UnReg(TRAN_VehiculosMantenimientoDocCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodoccompra.Nuevo Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSI_UnReg(m_tran_vehiculosmantenimientodoccompra, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Modificado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSU_UnReg(m_tran_vehiculosmantenimientodoccompra, x_usuario, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Eliminado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSD_UnReg(TRAN_VehiculosMantenimientoDocCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_vehiculosmantenimientodoccompra.Nuevo Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSI_UnReg(m_tran_vehiculosmantenimientodoccompra, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_vehiculosmantenimientodoccompra.Eliminado Then
				d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSD_UnReg(TRAN_VehiculosMantenimientoDocCompra)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_VehiculosMantenimientoDocCompra = new List(Of ETRAN_VehiculosMantenimientoDocCompra)()
			return d_tran_vehiculosmantenimientodoccompra.TRAN_VMDCOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_vehiculosmantenimientodoccompra.getCorrelativo("VEHIC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_vehiculosmantenimientodoccompra.getCorrelativo("VEHIC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_vehiculosmantenimientodoccompra.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_vehiculosmantenimientodoccompra.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_vehiculosmantenimientodoccompra.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_vehiculosmantenimientodoccompra.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


#End Region

End Class

