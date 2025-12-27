Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BDirecciones

#Region " Variables "
	
	Private m_direcciones As EDirecciones
	Private m_listDirecciones As List(Of EDirecciones)
	Private m_dtDirecciones As DataTable

	Private m_dsDirecciones As DataSet
	Private d_direcciones As DDirecciones 


#End Region

#Region " Constructores "
	
	Public Sub New()
		d_direcciones = New DDirecciones()
	End Sub

#End Region

#Region " Propiedades "
	
	Public Property Direcciones() As EDirecciones 
		Get
			return m_direcciones
		End Get
		Set(ByVal value As EDirecciones)
			m_direcciones = value
		End Set
	End Property
    Public Property ListEDirecciones() As List(Of EDirecciones)
        Get
            Return m_listDirecciones
        End Get
        Set(ByVal value As List(Of EDirecciones))
            m_listDirecciones = value
        End Set
    End Property
    Public Property DTDirecciones() As DataTable
		Get
			return m_dtDirecciones
		End Get
		Set(ByVal value As DataTable)
			m_dtDirecciones = value
		End Set
	End Property
	Public Property DSDirecciones() As DataSet
		Get
			return m_dsDirecciones
		End Get
		Set(ByVal value As DataSet)
			m_dsDirecciones = value
		End Set
	End Property

#End Region

#Region " Funciones para obtencion de datos "
	

		Public Function getListDirecciones() As List(Of EDirecciones)
			Return Me.m_listDirecciones
		End Function
		Public Sub setListDirecciones(ByVal _listdirecciones As List (Of EDirecciones))
			Me.m_listDirecciones = m_listdirecciones 
		End Sub
		Public Function getDirecciones() As EDirecciones
			Return Me.m_direcciones
		End Function
    Public Sub setDirecciones(ByVal x_direcciones As EDirecciones)
        Me.m_direcciones = x_direcciones
    End Sub
    Public Property ListDirecciones() As List(Of EDirecciones)
        Get
            Return m_listDirecciones
        End Get
        Set(value As List(Of EDirecciones))
            m_listDirecciones = value
        End Set
    End Property
#End Region

#Region " Metodos "

    Public Function CargarTodos() As Boolean
        Try
            m_listDirecciones = New List(Of EDirecciones)()
            Return d_direcciones.DIRECSS_Todos(m_listDirecciones)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'pROVEIMIDIENTO CREADO FRANK 



    Public Function AYUDASS_Busq_X_UBIGEOS(ByVal x_entid_codigo As String) As Boolean
        Try
            m_listDirecciones = New List(Of EDirecciones)()
            Return d_direcciones.AYUDASS_Busq_X_UBIGEOS(m_listDirecciones, x_entid_codigo)
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    '@DIRECCION


    Public Function AYUDASS_Busq_X_UBIGEOS_Descripcion(ByVal x_direccion As String) As Boolean
        Try
            m_listDirecciones = New List(Of EDirecciones)()
            Return d_direcciones.AYUDASS_Busq_X_UBIGEOS_Descripcion(m_listDirecciones, x_direccion)
        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDirecciones = new List(Of EDirecciones)()
			return d_direcciones.DIRECSS_Todos(m_listDirecciones, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_listDirecciones = new List(Of EDirecciones)()
			return d_direcciones.DIRECSS_Todos(m_listDirecciones, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			m_listDirecciones = new List(Of EDirecciones)()
			return d_direcciones.DIRECSS_Todos(m_listDirecciones, x_join, x_where, x_distinct)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodos(ByVal x_entid_codigo As String) As Boolean
		Try
			m_listDirecciones = new List(Of EDirecciones)()
			Return d_direcciones.DIRECSS_Todos(m_listDirecciones, x_entid_codigo)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDirecciones = new DataSet()
			return d_direcciones.DIRECSS_Todos(m_dsDirecciones, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDirecciones = new DataSet()
			return d_direcciones.DIRECSS_Todos(m_dsDirecciones, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
		Try
			m_dsDirecciones = new DataSet()
			Dim _opcion As Boolean = d_direcciones.DIRECSS_Todos(m_dsDirecciones, x_where)
		If _opcion Then
			m_dtDirecciones = m_dsDirecciones.Tables(0)
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
			m_dsDirecciones = new DataSet()
			Dim _opcion As Boolean = d_direcciones.DIRECSS_Todos(m_dsDirecciones, x_join, x_where)
		If _opcion Then
			m_dtDirecciones = m_dsDirecciones.Tables(0)
			Return True
		Else
			Return False
		End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function Cargar(ByVal x_entid_codigo As String, x_direc_id As Short) As Boolean
		Try
			m_direcciones = New EDirecciones()
			Return d_direcciones.DIRECSS_UnReg(m_direcciones, x_entid_codigo, x_direc_id)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_where As Hashtable) As Boolean
		Try
			m_direcciones = New EDirecciones()
			Return d_direcciones.DIRECSS_UnReg(m_direcciones, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			m_direcciones = New EDirecciones()
			Return d_direcciones.DIRECSS_UnReg(m_direcciones, x_join, x_where)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String) As Boolean
		Try
			If m_direcciones.Nuevo Then
				d_direcciones.DIRECSI_UnReg(m_direcciones, x_usuario)
			ElseIf m_direcciones.Modificado Then
				d_direcciones.DIRECSU_UnReg(m_direcciones, x_usuario)
			ElseIf m_direcciones.Eliminado Then
				d_direcciones.DIRECSD_UnReg(m_direcciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
		Try
			If m_direcciones.Nuevo Then
				d_direcciones.DIRECSI_UnReg(m_direcciones, x_usuario)
			ElseIf m_direcciones.Modificado Then
				d_direcciones.DIRECSU_UnReg(m_direcciones, x_where, x_usuario)
			ElseIf m_direcciones.Eliminado Then
				d_direcciones.DIRECSD_UnReg(x_where)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_direcciones.Nuevo Then
				d_direcciones.DIRECSI_UnReg(m_direcciones, x_usuario, x_excluir, x_setfecha)
			ElseIf m_direcciones.Modificado Then
				d_direcciones.DIRECSU_UnReg(m_direcciones, x_where, x_usuario, x_excluir, x_setfecha)
			ElseIf m_direcciones.Eliminado Then
				d_direcciones.DIRECSD_UnReg(m_direcciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
		Try
			If m_direcciones.Nuevo Then
				d_direcciones.DIRECSI_UnReg(m_direcciones, x_usuario, x_excluir, x_setfecha)
			ElseIf m_direcciones.Modificado Then
				d_direcciones.DIRECSU_UnReg(m_direcciones, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
			ElseIf m_direcciones.Eliminado Then
				d_direcciones.DIRECSD_UnReg(m_direcciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_direcciones.Nuevo Then
				d_direcciones.DIRECSI_UnReg(m_direcciones, x_usuario, x_setfecha)
			ElseIf m_direcciones.Modificado Then
				d_direcciones.DIRECSU_UnReg(m_direcciones, x_usuario, x_setfecha)
			ElseIf m_direcciones.Eliminado Then
				d_direcciones.DIRECSD_UnReg(m_direcciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
		Try
			If m_direcciones.Nuevo Then
				d_direcciones.DIRECSI_UnReg(m_direcciones, x_usuario, x_excluir, x_setfecha)
			ElseIf m_direcciones.Eliminado Then
				d_direcciones.DIRECSD_UnReg(m_direcciones)
			End If
			Return True
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
		Try
			m_listDirecciones = new List(Of EDirecciones)()
			return d_direcciones.DIRECSD_UnReg(x_where) > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo() As Integer
		Try
			Return d_direcciones.getCorrelativo("DIREC_Id") + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer) As Integer
		Try
			x_id = d_direcciones.getCorrelativo("DIREC_Id")
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			Return d_direcciones.getCorrelativo(x_campo) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
		Try
			x_id = d_direcciones.getCorrelativo(x_campo)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			Return d_direcciones.getCorrelativo(x_campo, x_where) + 1 
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			x_id = d_direcciones.getCorrelativo(x_campo, x_where)
			Return (x_id + 1)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

