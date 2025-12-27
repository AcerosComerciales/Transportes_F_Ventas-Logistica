Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Partial Public Class BTRAN_ViajesGastos

#Region " Variables "
	
	Private m_tran_viajesgastos As ETRAN_ViajesGastos
	Private m_listTRAN_ViajesGastos As List(Of ETRAN_ViajesGastos)
	Private m_dtTRAN_ViajesGastos As DataTable

	Private m_dsTRAN_ViajesGastos As DataSet
	Private d_tran_viajesgastos As DTRAN_ViajesGastos 


#End Region

#Region " Constructores "
	
   Public Sub New()
      d_tran_viajesgastos = New DTRAN_ViajesGastos()
   End Sub

#End Region

#Region " Propiedades "
	
	Public Property TRAN_ViajesGastos() As ETRAN_ViajesGastos 
		Get
			return m_tran_viajesgastos
		End Get
		Set(ByVal value As ETRAN_ViajesGastos)
			m_tran_viajesgastos = value
		End Set
	End Property
	Public Property ListTRAN_ViajesGastos() As List(Of ETRAN_ViajesGastos)
		Get
			return m_listTRAN_ViajesGastos
		End Get
		Set(ByVal value As List(Of ETRAN_ViajesGastos))
			m_listTRAN_ViajesGastos = value
		End Set
	End Property
	Public Property DTTRAN_ViajesGastos() As DataTable
		Get
			return m_dtTRAN_ViajesGastos
		End Get
		Set(ByVal value As DataTable)
			m_dtTRAN_ViajesGastos = value
		End Set
	End Property
	Public Property DSTRAN_ViajesGastos() As DataSet
		Get
			return m_dsTRAN_ViajesGastos
		End Get
		Set(ByVal value As DataSet)
			m_dsTRAN_ViajesGastos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListTRAN_ViajesGastos() As List(Of ETRAN_ViajesGastos)
			Return Me.m_listTRAN_ViajesGastos
		End Function
		Public Sub setListTRAN_ViajesGastos(ByVal _listtran_viajesgastos As List (Of ETRAN_ViajesGastos))
			Me.m_listTRAN_ViajesGastos = m_listtran_viajesgastos 
		End Sub
		Public Function getTRAN_ViajesGastos() As ETRAN_ViajesGastos
			Return Me.m_tran_viajesgastos
		End Function
		Public Sub setTRAN_ViajesGastos(ByVal x_tran_viajesgastos As ETRAN_ViajesGastos)
			Me.m_tran_viajesgastos = x_tran_viajesgastos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listTRAN_ViajesGastos = new List(Of ETRAN_ViajesGastos)()
			return d_tran_viajesgastos.TRAN_VGASTSS_Todos(m_listTRAN_ViajesGastos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesGastos = new List(Of ETRAN_ViajesGastos)()
			return d_tran_viajesgastos.TRAN_VGASTSS_Todos(m_listTRAN_ViajesGastos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesGastos = new List(Of ETRAN_ViajesGastos)()
			return d_tran_viajesgastos.TRAN_VGASTSS_Todos(m_listTRAN_ViajesGastos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listTRAN_ViajesGastos = new List(Of ETRAN_ViajesGastos)()
			return d_tran_viajesgastos.TRAN_VGASTSS_Todos(m_listTRAN_ViajesGastos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_viaje_id As Long) As Boolean
		Try
			m_listTRAN_ViajesGastos = new List(Of ETRAN_ViajesGastos)()
			Return d_tran_viajesgastos.TRAN_VGASTSS_Todos(m_listTRAN_ViajesGastos, x_viaje_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesGastos = new DataSet()
			return d_tran_viajesgastos.TRAN_VGASTSS_Todos(m_dsTRAN_ViajesGastos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesGastos = new DataSet()
			return d_tran_viajesgastos.TRAN_VGASTSS_Todos(m_dsTRAN_ViajesGastos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsTRAN_ViajesGastos = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesgastos.TRAN_VGASTSS_Todos(m_dsTRAN_ViajesGastos, x_where)
		If _opcion Then
			m_dtTRAN_ViajesGastos = m_dsTRAN_ViajesGastos.Tables(0)
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
			m_dsTRAN_ViajesGastos = new DataSet()
			Dim _opcion As Boolean = d_tran_viajesgastos.TRAN_VGASTSS_Todos(m_dsTRAN_ViajesGastos, x_join, x_where)
		If _opcion Then
			m_dtTRAN_ViajesGastos = m_dsTRAN_ViajesGastos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_viaje_id As Long, x_vgast_id As Long) As Boolean
		Try
			m_tran_viajesgastos = New ETRAN_ViajesGastos()
			Return d_tran_viajesgastos.TRAN_VGASTSS_UnReg(m_tran_viajesgastos, x_viaje_id, x_vgast_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_viajesgastos = New ETRAN_ViajesGastos()
			Return d_tran_viajesgastos.TRAN_VGASTSS_UnReg(m_tran_viajesgastos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_tran_viajesgastos = New ETRAN_ViajesGastos()
			Return d_tran_viajesgastos.TRAN_VGASTSS_UnReg(m_tran_viajesgastos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesgastos.Nuevo Then
				d_tran_viajesgastos.TRAN_VGASTSI_UnReg(m_tran_viajesgastos, x_usuario)
			ElseIf m_tran_viajesgastos.Modificado Then
				d_tran_viajesgastos.TRAN_VGASTSU_UnReg(m_tran_viajesgastos, x_usuario)
			ElseIf m_tran_viajesgastos.Eliminado Then
				d_tran_viajesgastos.TRAN_VGASTSD_UnReg(m_tran_viajesgastos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_tran_viajesgastos.Nuevo Then
				d_tran_viajesgastos.TRAN_VGASTSI_UnReg(m_tran_viajesgastos, x_usuario)
			ElseIf m_tran_viajesgastos.Modificado Then
				d_tran_viajesgastos.TRAN_VGASTSU_UnReg(m_tran_viajesgastos, x_where, x_usuario)
			ElseIf m_tran_viajesgastos.Eliminado Then
				d_tran_viajesgastos.TRAN_VGASTSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesgastos.Nuevo Then
				d_tran_viajesgastos.TRAN_VGASTSI_UnReg(m_tran_viajesgastos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesgastos.Modificado Then
				d_tran_viajesgastos.TRAN_VGASTSU_UnReg(m_tran_viajesgastos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesgastos.Eliminado Then
				d_tran_viajesgastos.TRAN_VGASTSD_UnReg(m_tran_viajesgastos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_tran_viajesgastos.Nuevo Then
				d_tran_viajesgastos.TRAN_VGASTSI_UnReg(m_tran_viajesgastos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesgastos.Modificado Then
				d_tran_viajesgastos.TRAN_VGASTSU_UnReg(m_tran_viajesgastos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_tran_viajesgastos.Eliminado Then
				d_tran_viajesgastos.TRAN_VGASTSD_UnReg(m_tran_viajesgastos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesgastos.Nuevo Then
				d_tran_viajesgastos.TRAN_VGASTSI_UnReg(m_tran_viajesgastos, x_usuario, x_setfecha)
			ElseIf m_tran_viajesgastos.Modificado Then
				d_tran_viajesgastos.TRAN_VGASTSU_UnReg(m_tran_viajesgastos, x_usuario, x_setfecha)
			ElseIf m_tran_viajesgastos.Eliminado Then
				d_tran_viajesgastos.TRAN_VGASTSD_UnReg(m_tran_viajesgastos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_tran_viajesgastos.Nuevo Then
				d_tran_viajesgastos.TRAN_VGASTSI_UnReg(m_tran_viajesgastos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_tran_viajesgastos.Eliminado Then
				d_tran_viajesgastos.TRAN_VGASTSD_UnReg(m_tran_viajesgastos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listTRAN_ViajesGastos = new List(Of ETRAN_ViajesGastos)()
			return d_tran_viajesgastos.TRAN_VGASTSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_tran_viajesgastos.getCorrelativo("VIAJE_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_tran_viajesgastos.getCorrelativo("VIAJE_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_tran_viajesgastos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_tran_viajesgastos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_tran_viajesgastos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_tran_viajesgastos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

