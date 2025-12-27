Imports System.Data.Common
Imports ACDAppMovil
Imports ACEAppMovil
Imports ACFramework
Imports DAConexion

Public Class BTRANGUIAS_Usuarios


    Sub New(x_entidad As TipoBusqueda)


    End Sub


    Enum TipoBusqueda
        NumDocumento = 1
        RazonSocial = 2

    End Enum
#Region " Variables "

    Private m_ETRANGUIAS_Usuarios As ETRANGUIAS_Usuarios
    Private m_listUsuariosPorAlmacen As List(Of ETRANGUIAS_Usuarios)
    Private m_dtUsuariosPorAlmacen As DataTable

    Private m_dsUsuariosPorAlmacen As DataSet
    Private d_usuariosporalmacen As DTRANGUIAS_Usuarios


#End Region

#Region " Constructores "

    Public Sub New()
        d_usuariosporalmacen = New DTRANGUIAS_Usuarios()
        'm_ETRANGUIAS_Usuarios = New ETRANGUIAS_Usuarios()
    End Sub

#End Region

#Region " Propiedades "

    Public Property ETRAN_GUIAS_Usuarios() As ETRANGUIAS_Usuarios
        Get
            Return m_ETRANGUIAS_Usuarios
        End Get
        Set(ByVal value As ETRANGUIAS_Usuarios)
            m_ETRANGUIAS_Usuarios = value
        End Set
    End Property

    Public Property ListUsuariosApp() As List(Of ETRANGUIAS_Usuarios)
        Get
            Return m_listUsuariosPorAlmacen
        End Get
        Set(ByVal value As List(Of ETRANGUIAS_Usuarios))
            m_listUsuariosPorAlmacen = value
        End Set
    End Property

    Public Property DTUsuariosPorAlmacen() As DataTable
        Get
            Return m_dtUsuariosPorAlmacen
        End Get
        Set(ByVal value As DataTable)
            m_dtUsuariosPorAlmacen = value
        End Set
    End Property

    Public Property DSUsuariosPorAlmacen() As DataSet
        Get
            Return m_dsUsuariosPorAlmacen
        End Get
        Set(ByVal value As DataSet)
            m_dsUsuariosPorAlmacen = value
        End Set
    End Property


#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "


    Public Function Cargar(ByVal where As Hashtable) As Boolean 'Cargar Registro Individua 
        Try
            m_ETRANGUIAS_Usuarios = New ETRANGUIAS_Usuarios()

            If d_usuariosporalmacen.TRAN_GUIAS_UnReg(m_ETRANGUIAS_Usuarios, where) Then

                Return True
            Else

                Return False
            End If

            'Return d_usuariosporalmacen.getSelectBy(where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function CargarTodos() As Boolean
        Try
            m_listUsuariosPorAlmacen = New List(Of ETRANGUIAS_Usuarios)()
            Return d_usuariosporalmacen.USUARSS_Todos(m_listUsuariosPorAlmacen)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
        Try
            m_listUsuariosPorAlmacen = New List(Of ETRANGUIAS_Usuarios)()
            Return d_usuariosporalmacen.USUARSS_Todos(m_listUsuariosPorAlmacen, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Cargar Un registro pero con un Join Papu 
    Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            'm_listUsuariosPorAlmacen = New List(Of ETRANGUIAS_Usuarios)()

            m_ETRANGUIAS_Usuarios = New ETRANGUIAS_Usuarios()
            Return d_usuariosporalmacen.USUARSS_JoinUnReg(m_ETRANGUIAS_Usuarios, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_listUsuariosPorAlmacen = New List(Of ETRANGUIAS_Usuarios)()
            Return d_usuariosporalmacen.USUARSS_Todos(m_listUsuariosPorAlmacen, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
        Try
            m_listUsuariosPorAlmacen = New List(Of ETRANGUIAS_Usuarios)()
            Return d_usuariosporalmacen.USUARSS_Todos(m_listUsuariosPorAlmacen, x_join, x_where, x_distinct)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
        Try
            m_dsUsuariosPorAlmacen = New DataSet()
            Return d_usuariosporalmacen.USUARSS_Todos(m_dsUsuariosPorAlmacen, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_dsUsuariosPorAlmacen = New DataSet()
            Return d_usuariosporalmacen.USUARSS_Todos(m_dsUsuariosPorAlmacen, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
        Try
            m_dsUsuariosPorAlmacen = New DataSet()
            Dim _opcion As Boolean = d_usuariosporalmacen.USUARSS_Todos(m_dsUsuariosPorAlmacen, x_where)
            If _opcion Then
                m_dtUsuariosPorAlmacen = m_dsUsuariosPorAlmacen.Tables(0)
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
            m_dsUsuariosPorAlmacen = New DataSet()
            Dim _opcion As Boolean = d_usuariosporalmacen.USUARSS_Todos(m_dsUsuariosPorAlmacen, x_join, x_where)
            If _opcion Then
                m_dtUsuariosPorAlmacen = m_dsUsuariosPorAlmacen.Tables(0)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Guardar(ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            If m_ETRANGUIAS_Usuarios.Nuevo Then
                d_usuariosporalmacen.USUARSI_UnReg(m_ETRANGUIAS_Usuarios, x_usuario)
                DAEnterprise.CommitTransaction()

            ElseIf m_ETRANGUIAS_Usuarios.Modificado Then

                d_usuariosporalmacen.USUARUP_UnReg(m_ETRANGUIAS_Usuarios, x_usuario)
                DAEnterprise.CommitTransaction()


            ElseIf m_ETRANGUIAS_Usuarios.Eliminado Then
                d_usuariosporalmacen.USUARSD_UnReg(ETRAN_GUIAS_Usuarios)
                DAEnterprise.CommitTransaction()

            End If
            Return True

        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
        Try
            If m_ETRANGUIAS_Usuarios.Nuevo Then
                d_usuariosporalmacen.USUARSI_UnReg(m_ETRANGUIAS_Usuarios, x_usuario)
            ElseIf m_ETRANGUIAS_Usuarios.Eliminado Then
                d_usuariosporalmacen.USUARSD_UnReg(x_where)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
        Try
            If m_ETRANGUIAS_Usuarios.Nuevo Then
                d_usuariosporalmacen.USUARSI_UnReg(m_ETRANGUIAS_Usuarios, x_usuario, x_excluir, x_setfecha)
            ElseIf m_ETRANGUIAS_Usuarios.Eliminado Then
                d_usuariosporalmacen.USUARSD_UnReg(ETRAN_GUIAS_Usuarios)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
        Try
            If m_ETRANGUIAS_Usuarios.Nuevo Then
                d_usuariosporalmacen.USUARSI_UnReg(m_ETRANGUIAS_Usuarios, x_usuario, x_excluir, x_setfecha)
            ElseIf m_ETRANGUIAS_Usuarios.Eliminado Then
                d_usuariosporalmacen.USUARSD_UnReg(ETRAN_GUIAS_Usuarios)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
        Try
            If m_ETRANGUIAS_Usuarios.Nuevo Then
                d_usuariosporalmacen.USUARSI_UnReg(m_ETRANGUIAS_Usuarios, x_usuario, x_setfecha)
            ElseIf m_ETRANGUIAS_Usuarios.Eliminado Then
                d_usuariosporalmacen.USUARSD_UnReg(ETRAN_GUIAS_Usuarios)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
        Try
            If m_ETRANGUIAS_Usuarios.Nuevo Then
                d_usuariosporalmacen.USUARSI_UnReg(m_ETRANGUIAS_Usuarios, x_usuario, x_excluir, x_setfecha)
            ElseIf m_ETRANGUIAS_Usuarios.Eliminado Then
                d_usuariosporalmacen.USUARSD_UnReg(ETRAN_GUIAS_Usuarios)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
        Try
            m_listUsuariosPorAlmacen = New List(Of ETRANGUIAS_Usuarios)()
            Return d_usuariosporalmacen.USUARSD_UnReg(x_where) > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function getCorrelativo() As Integer
        Try
            Return d_usuariosporalmacen.getCorrelativo("GtusId") + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCorrelativo(ByRef x_id As Integer) As Integer
        Try
            x_id = d_usuariosporalmacen.getCorrelativo("GtusId")
            Return (x_id + 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCorrelativo(ByVal x_campo As String) As Integer
        Try
            Return d_usuariosporalmacen.getCorrelativo(x_campo) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
        Try
            x_id = d_usuariosporalmacen.getCorrelativo(x_campo)
            Return (x_id + 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
        Try
            Return d_usuariosporalmacen.getCorrelativo(x_campo, x_where) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
        Try
            x_id = d_usuariosporalmacen.getCorrelativo(x_campo, x_where)
            Return (x_id + 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


#Region "Procedimientos almacenados by frnk"


    Public Function TRAN_GUIAS_TRANSPORTISTA_BusqUsuarioXNumDocumento(x_ENTID_codigoFk As String, x_razonSocial As String, ByVal x_tipoUsuario As TipoBusqueda)
        Try
            m_listUsuariosPorAlmacen = New List(Of ETRANGUIAS_Usuarios)()
            Return d_usuariosporalmacen.TRAN_GUIAS_TRANSPORTISTA_BusqUsuarioXNumDocumento(x_ENTID_codigoFk, x_razonSocial, m_listUsuariosPorAlmacen, x_tipoUsuario)
        Catch ex As Exception
            Throw ex
        End Try



    End Function
    'TRAN_GUIAS_TRANSPORTISTA_BusqUsuariosActivosInactivos


    Public Function TRAN_GUIAS_TRANSPORTISTA_BusqUsuariosActivosInactivos(ByVal viewall As Boolean)
        Try
            m_listUsuariosPorAlmacen = New List(Of ETRANGUIAS_Usuarios)()
            Return d_usuariosporalmacen.TRAN_GUIAS_TRANSPORTISTA_BusqUsuariosActivosInactivos(m_listUsuariosPorAlmacen, viewall)
        Catch ex As Exception
            Throw ex
        End Try



    End Function

#End Region
#Region "Funciones de Busqueda de Forma Individual "

    Public Function TRAN_GUIAS_Usuarios_UnReg(ByRef x_entidades As ETRANGUIAS_Usuarios, ByVal X_NumDoc As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectByUsuario(X_NumDoc), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function



#End Region

#Region "Consultas SQL Por Cadena de Conexion"
    Public Function getSelectByUsuario(ByVal X_NumDoc As String) As String
        Dim sql As String
        Try
            sql = " SELECT "
            sql &= " * "
            sql &= " FROM TransportesGuias.TRANGUIAS_Usuarios"
            sql &= " WHERE "
            sql &= String.Format("ENTID_CodigoFk = '{0}'", X_NumDoc)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function





#End Region




End Class
