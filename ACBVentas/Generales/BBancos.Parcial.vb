Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BBancos

#Region " Variables "
	
	Private m_bancos As EBancos
	Private m_listBancos As List(Of EBancos)
	Private m_dtBancos As DataTable

	Private m_dsBancos As DataSet
	Private d_bancos As DBancos 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_bancos = New DBancos()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Bancos() As EBancos 
		Get
			return m_bancos
		End Get
		Set(ByVal value As EBancos)
			m_bancos = value
		End Set
	End Property
	Public Property ListBancos() As List(Of EBancos)
		Get
			return m_listBancos
		End Get
		Set(ByVal value As List(Of EBancos))
			m_listBancos = value
		End Set
	End Property
	Public Property DTBancos() As DataTable
		Get
			return m_dtBancos
		End Get
		Set(ByVal value As DataTable)
			m_dtBancos = value
		End Set
	End Property
	Public Property DSBancos() As DataSet
		Get
			return m_dsBancos
		End Get
		Set(ByVal value As DataSet)
			m_dsBancos = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListBancos() As List(Of EBancos)
			Return Me.m_listBancos
		End Function
		Public Sub setListBancos(ByVal _listbancos As List (Of EBancos))
			Me.m_listBancos = m_listbancos 
		End Sub
		Public Function getBancos() As EBancos
			Return Me.m_bancos
		End Function
		Public Sub setBancos(ByVal x_bancos As EBancos)
			Me.m_bancos = x_bancos 
		End Sub
#End Region

#Region " Metodos "
	
	Public Function CargarTodos() As Boolean
		Try
			m_listBancos = new List(Of EBancos)()
			return d_bancos.BANCOSS_Todos(m_listBancos)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listBancos = new List(Of EBancos)()
			return d_bancos.BANCOSS_Todos(m_listBancos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listBancos = new List(Of EBancos)()
			return d_bancos.BANCOSS_Todos(m_listBancos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listBancos = new List(Of EBancos)()
			return d_bancos.BANCOSS_Todos(m_listBancos, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsBancos = new DataSet()
			return d_bancos.BANCOSS_Todos(m_dsBancos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsBancos = new DataSet()
			return d_bancos.BANCOSS_Todos(m_dsBancos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsBancos = new DataSet()
			Dim _opcion As Boolean = d_bancos.BANCOSS_Todos(m_dsBancos, x_where)
		If _opcion Then
			m_dtBancos = m_dsBancos.Tables(0)
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
			m_dsBancos = new DataSet()
			Dim _opcion As Boolean = d_bancos.BANCOSS_Todos(m_dsBancos, x_join, x_where)
		If _opcion Then
			m_dtBancos = m_dsBancos.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_banco_id As Short) As Boolean
		Try
			m_bancos = New EBancos()
			Return d_bancos.BANCOSS_UnReg(m_bancos, x_banco_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_bancos = New EBancos()
			Return d_bancos.BANCOSS_UnReg(m_bancos, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_bancos = New EBancos()
			Return d_bancos.BANCOSS_UnReg(m_bancos, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
        Try
            Dim x_corre As Integer = 0


            If m_bancos.Nuevo Then
                m_bancos.BANCO_Id = getCorrelativo(x_corre)
                d_bancos.BANCOSI_UnReg(m_bancos, x_usuario)
            ElseIf m_bancos.Modificado Then
                d_bancos.BANCOSU_UnReg(m_bancos, x_usuario)
            ElseIf m_bancos.Eliminado Then
                d_bancos.BANCOSD_UnReg(m_bancos)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_bancos.Nuevo Then
				d_bancos.BANCOSI_UnReg(m_bancos, x_usuario)
			ElseIf m_bancos.Modificado Then
				d_bancos.BANCOSU_UnReg(m_bancos, x_where, x_usuario)
			ElseIf m_bancos.Eliminado Then
				d_bancos.BANCOSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_bancos.Nuevo Then
				d_bancos.BANCOSI_UnReg(m_bancos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_bancos.Modificado Then
				d_bancos.BANCOSU_UnReg(m_bancos, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_bancos.Eliminado Then
				d_bancos.BANCOSD_UnReg(m_bancos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_bancos.Nuevo Then
				d_bancos.BANCOSI_UnReg(m_bancos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_bancos.Modificado Then
				d_bancos.BANCOSU_UnReg(m_bancos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_bancos.Eliminado Then
				d_bancos.BANCOSD_UnReg(m_bancos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_bancos.Nuevo Then
				d_bancos.BANCOSI_UnReg(m_bancos, x_usuario, x_setfecha)
			ElseIf m_bancos.Modificado Then
				d_bancos.BANCOSU_UnReg(m_bancos, x_usuario, x_setfecha)
			ElseIf m_bancos.Eliminado Then
				d_bancos.BANCOSD_UnReg(m_bancos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_bancos.Nuevo Then
				d_bancos.BANCOSI_UnReg(m_bancos, x_usuario, x_excluir, x_setfecha)
			ElseIf m_bancos.Eliminado Then
				d_bancos.BANCOSD_UnReg(m_bancos)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listBancos = new List(Of EBancos)()
			return d_bancos.BANCOSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_bancos.getCorrelativo("BANCO_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_bancos.getCorrelativo("BANCO_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_bancos.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_bancos.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_bancos.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_bancos.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

