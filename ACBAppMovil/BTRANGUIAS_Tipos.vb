Imports System
Imports System.Data
Imports System.Collections.Generic


Imports System.Configuration
Imports ACDAppMovil
Imports ACEAppMovil
Imports System.Windows.Forms

Public Class BTRANGUIAS_Tipos


#Region "Variables"
    Private m_tipos As ETRANGUIAS_Tipos
    Private m_listTipos As List(Of ETRANGUIAS_Tipos)
    Private m_dtTipos As DataTable

    Private m_dsTipos As DataSet
    Private d_tipos As DTRANGUIAS_Tipos


#End Region

#Region " Constructores "

    Public Sub New()
        d_tipos = New DTRANGUIAS_Tipos()
    End Sub

#End Region

#Region " Propiedades "

    Public Property Tipos() As ETRANGUIAS_Tipos
        Get
            Return m_tipos
        End Get
        Set(ByVal value As ETRANGUIAS_Tipos)
            m_tipos = value
        End Set
    End Property
    Public Property ListTipos() As List(Of ETRANGUIAS_Tipos)
        Get
            Return m_listTipos
        End Get
        Set(ByVal value As List(Of ETRANGUIAS_Tipos))
            m_listTipos = value
        End Set
    End Property
    Public Property DTTipos() As DataTable
        Get
            Return m_dtTipos
        End Get
        Set(ByVal value As DataTable)
            m_dtTipos = value
        End Set
    End Property
    Public Property DSTipos() As DataSet
        Get
            Return m_dsTipos
        End Get
        Set(ByVal value As DataSet)
            m_dsTipos = value
        End Set
    End Property

#End Region

#Region " Funciones para obtencion de datos "


    Public Function getListTipos() As List(Of ETRANGUIAS_Tipos)
        Return Me.m_listTipos
    End Function
    Public Sub setListTipos(ByVal _listtipos As List(Of ETRANGUIAS_Tipos))
        Me.m_listTipos = m_listTipos
    End Sub
    Public Function getTipos() As ETRANGUIAS_Tipos
        Return Me.m_tipos
    End Function
    Public Sub setTipos(ByVal x_tipos As ETRANGUIAS_Tipos)
        Me.m_tipos = x_tipos
    End Sub
#End Region

    Public Function CargarTodos() As Boolean
        Try
            m_listTipos = New List(Of ETRANGUIAS_Tipos)()
            Return d_tipos.TIPOSSS_Todos(m_listTipos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
        Try
            m_listTipos = New List(Of ETRANGUIAS_Tipos)()
            Return d_tipos.TIPOSSS_Todos(m_listTipos, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_listTipos = New List(Of ETRANGUIAS_Tipos)()
            Return d_tipos.TIPOSSS_Todos(m_listTipos, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
        Try
            m_listTipos = New List(Of ETRANGUIAS_Tipos)()
            Return d_tipos.TIPOSSS_Todos(m_listTipos, x_join, x_where, x_distinct)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
        Try
            m_dsTipos = New DataSet()
            Return d_tipos.TIPOSSS_Todos(m_dsTipos, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_dsTipos = New DataSet()
            Return d_tipos.TIPOSSS_Todos(m_dsTipos, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
        Try
            m_dsTipos = New DataSet()
            Dim _opcion As Boolean = d_tipos.TIPOSSS_Todos(m_dsTipos, x_where)
            If _opcion Then
                m_dtTipos = m_dsTipos.Tables(0)
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
            m_dsTipos = New DataSet()
            Dim _opcion As Boolean = d_tipos.TIPOSSS_Todos(m_dsTipos, x_join, x_where)
            If _opcion Then
                m_dtTipos = m_dsTipos.Tables(0)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cargar(ByVal x_tipos_codigo As String) As Boolean
        Try
            m_tipos = New ETRANGUIAS_Tipos()
            Return d_tipos.TIPOSSS_UnReg(m_tipos, x_tipos_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cargar(ByVal x_where As Hashtable) As Boolean
        Try
            m_tipos = New ETRANGUIAS_Tipos()
            Return d_tipos.TIPOSSS_UnReg(m_tipos, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_tipos = New ETRANGUIAS_Tipos()
            Return d_tipos.TIPOSSS_UnReg(m_tipos, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'Procedimientos almacenado ============================================================================================================================================


    Public Function BusquedaTiposPorUsuarios(ByRef listTipos As List(Of ETRANGUIAS_Tipos), x_usuarios As String) As Boolean

        Try
            m_listTipos = New List(Of ETRANGUIAS_Tipos)
            Return d_tipos.Busq_GUIAS_TIPOS_X_Usuario(m_listTipos, x_usuarios)


        Catch ex As Exception

        End Try


    End Function

    'Busq_GUIAS_TIPOS_Entidad_X_Usuario

    Public Function Busq_GUIAS_TIPOS_Entidad_X_Usuario(ByRef listTipos As List(Of ETRANGUIAS_Tipos), x_usuarios As String) As Boolean



        Try
            m_listTipos = New List(Of ETRANGUIAS_Tipos)
            Return d_tipos.Busq_GUIAS_TIPOS_Entidad_X_Usuario(m_listTipos, x_usuarios)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Function


    Public Function Guardar(ByVal x_usuario As String) As Boolean
        Try
            If m_tipos.Nuevo Then
                d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario)
            ElseIf m_tipos.Modificado Then
                d_tipos.TIPOSSU_UnReg(m_tipos, x_usuario)
            ElseIf m_tipos.Eliminado Then
                d_tipos.TIPOSSD_UnReg(m_tipos)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
        Try
            If m_tipos.Nuevo Then
                d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario)
            ElseIf m_tipos.Modificado Then
                d_tipos.TIPOSSU_UnReg(m_tipos, x_where, x_usuario)
            ElseIf m_tipos.Eliminado Then
                d_tipos.TIPOSSD_UnReg(x_where)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
        Try
            If m_tipos.Nuevo Then
                d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario, x_excluir, x_setfecha)
            ElseIf m_tipos.Modificado Then
                d_tipos.TIPOSSU_UnReg(m_tipos, x_where, x_usuario, x_excluir, x_setfecha)
            ElseIf m_tipos.Eliminado Then
                d_tipos.TIPOSSD_UnReg(m_tipos)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
        Try
            If m_tipos.Nuevo Then
                d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario, x_excluir, x_setfecha)
            ElseIf m_tipos.Modificado Then
                d_tipos.TIPOSSU_UnReg(m_tipos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
            ElseIf m_tipos.Eliminado Then
                d_tipos.TIPOSSD_UnReg(m_tipos)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
        Try
            If m_tipos.Nuevo Then
                d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario, x_setfecha)
            ElseIf m_tipos.Modificado Then
                d_tipos.TIPOSSU_UnReg(m_tipos, x_usuario, x_setfecha)
            ElseIf m_tipos.Eliminado Then
                d_tipos.TIPOSSD_UnReg(m_tipos)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
        Try
            If m_tipos.Nuevo Then
                d_tipos.TIPOSSI_UnReg(m_tipos, x_usuario, x_excluir, x_setfecha)
            ElseIf m_tipos.Eliminado Then
                d_tipos.TIPOSSD_UnReg(m_tipos)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
        Try
            m_listTipos = New List(Of ETRANGUIAS_Tipos)()
            Return d_tipos.TIPOSSD_UnReg(x_where) > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCorrelativo(ByVal x_campo As String) As Integer
        Try
            Return d_tipos.getCorrelativo(x_campo) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
        Try
            x_id = d_tipos.getCorrelativo(x_campo)
            Return (x_id + 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
        Try
            Return d_tipos.getCorrelativo(x_campo, x_where) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
        Try
            x_id = d_tipos.getCorrelativo(x_campo, x_where)
            Return (x_id + 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region " Metodos "

    ''' <summary>
    ''' cargar los tipos con todos los campos sin espacios
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargarTodosTrim() As Boolean
        Try
            m_listTipos = New List(Of ETRANGUIAS_Tipos)()
            Return d_tipos.TIPOSSS_TodosTrim(m_listTipos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' busqueda de tipos
    ''' </summary>
    ''' <param name="x_cadena">cadena de busqueda</param>
    ''' <param name="x_tipo_codigo">categoria del tipo que se esta buscando</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Busqueda(ByVal x_cadena As String, ByVal x_tipo_codigo As String) As Boolean
        Try
            m_listTipos = New List(Of ETRANGUIAS_Tipos)()
            Return d_tipos.TIPOSS_Todos(m_listTipos, x_cadena, x_tipo_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' guardar tipo usando un procedimiento almacenado
    ''' </summary>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GuardarSP(ByVal x_usuario As String) As Boolean
        Try
            If m_tipos.Nuevo Then
                d_tipos.TIPOSI_UnRegSP(m_tipos, x_usuario)
            ElseIf m_tipos.Modificado Then
                d_tipos.TIPOSSU_UnReg(m_tipos, x_usuario)
            ElseIf m_tipos.Eliminado Then
                d_tipos.TIPOSSD_UnReg(m_tipos)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


End Class
