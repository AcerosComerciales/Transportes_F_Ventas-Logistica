Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework
Public Class ETRANGUIAS_Usuarios


#Region " Campos "

    Private gtus_id As Long
    Private tipos_usuarios_fk As Long
    Private entid_codigo_fk As String
    Private gtus_usuario As String
    Private gtus_contrasena As String
    Private gtus_Estado As Boolean

    Private gtus_hash As String

    Private gtus_salt As String

    Private gtus_feccreacion As DateTime
    Private gtus_usrcreacion As Long

    Private gtus_fecmodificacion As DateTime
    Private gtus_usrmodificacion As Long


    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean

    Private m_hash As Hashtable
#End Region
    Public Enum TipoEntidad
        Todos = 0
        Usuarios = 1
        Clientes = 2
        Proveedores = 3
        Trabajadores = 4
        Conductores = 5
        Contactos = 6
        Vendedores = 7
        EnBlanco = 8
        Transportista = 9
        ProveedoresLogistica = 10
        Basico = 100
    End Enum

    Public Enum TipoInicializacion
        Todos
        Direcciones
        Telefonos
        Dir_Tel
        EntTipos_Dir_Tel
        Cliente
        Proveedor
        Conductor
        Transportista
    End Enum
#Region " Constructores "

    Public Sub New()

        Try
            Dim _obj As Object = ACEAppMovil.My.Resources.xmlETRANGUIAS_Usuarios
            Dim _xml As New XmlDocument
            _xml.LoadXml(_obj)
            If IsNothing(m_hash) Then
                m_hash = New Hashtable()
                Dim cPlantilla As XmlNodeList = _xml.GetElementsByTagName("Tabla")
                Dim cCampos As XmlNodeList = CType(cPlantilla(0), XmlElement).GetElementsByTagName("Campos")
                Dim Campo As XmlNodeList = CType(cCampos(0), XmlElement).GetElementsByTagName("CCampo")
                For Each Item As XmlElement In Campo
                    m_hash.Add(Item.InnerText.ToString(), New CCampo(Item.GetAttribute("xmlns"), IIf(Item.GetAttribute("Identity") = "1", True, False), IIf(Item.GetAttribute("ForeignKey") = "1", True, False), IIf(Item.GetAttribute("PrimaryKey") = "1", True, False)))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub





#End Region

#Region " Propiedades "

    'Private gtus_id As String
    'Private tipos_usuarios_fk As Long
    'Private entid_codigo_fk As String
    'Private gtus_usuario As String
    'Private gtus_contrasena As String
    'Private gtus_Estado As Boolean
    'Private gtus_feccreacion As DateTime
    'Private gtus_usrcreacion As Long

    'Private gtus_fecmodificacion As DateTime
    'Private gtus_usrmodificacion As Long



    Public Property GtusId() As Long
        Get
            Return gtus_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(gtus_id) Then
                If Not gtus_id.Equals(value) Then
                    gtus_id = value
                    OnGtusIdChanged(gtus_id, EventArgs.Empty)
                End If
            Else
                gtus_id = value
                OnGtusIdChanged(gtus_id, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TiposUsuariosFk() As Long
        Get
            Return tipos_usuarios_fk
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(tipos_usuarios_fk) Then
                If Not tipos_usuarios_fk.Equals(value) Then
                    tipos_usuarios_fk = value
                    OnTiposUsuariosFkChanged(tipos_usuarios_fk, EventArgs.Empty)
                End If
            Else
                tipos_usuarios_fk = value
                OnTiposUsuariosFkChanged(tipos_usuarios_fk, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ENTID_CodigoFk() As String
        Get
            Return entid_codigo_fk
        End Get
        Set(ByVal value As String)
            If Not IsNothing(entid_codigo_fk) Then
                If Not entid_codigo_fk.Equals(value) Then
                    entid_codigo_fk = value
                    OnENTID_CodigoFkChanged(entid_codigo_fk, EventArgs.Empty)
                End If
            Else
                entid_codigo_fk = value
                OnENTID_CodigoFkChanged(entid_codigo_fk, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GtusUsuario() As String
        Get
            Return gtus_usuario
        End Get
        Set(ByVal value As String)
            If Not IsNothing(gtus_usuario) Then
                If Not gtus_usuario.Equals(value) Then
                    gtus_usuario = value
                    OnGtusUsuarioChanged(gtus_usuario, EventArgs.Empty)
                End If
            Else
                gtus_usuario = value
                OnGtusUsuarioChanged(gtus_usuario, EventArgs.Empty)
            End If
        End Set
    End Property

    'GtusId
    ' ,TiposUsuariosFk
    ' ,ENTID_CodigoFk
    ' ,GtusUsuario
    ' ,GtusContraseña
    ' ,GtusEstado
    ' ,GtusFecCreacion
    ' ,GtusUsrCreacion
    ' ,GtusFecModificacion
    ' ,GtusUsrModificacion



    Public Property GtusContraseña() As String
        Get
            Return gtus_contrasena
        End Get
        Set(ByVal value As String)
            If Not IsNothing(gtus_contrasena) Then
                If Not gtus_contrasena.Equals(value) Then
                    gtus_contrasena = value
                    OnGtusContrasenaChanged(gtus_contrasena, EventArgs.Empty)
                End If
            Else
                gtus_contrasena = value
                OnGtusContrasenaChanged(gtus_contrasena, EventArgs.Empty)
            End If
        End Set
    End Property

    'Columnas de enctryptation 


    Public Property GtusHash() As String
        Get
            Return gtus_hash
        End Get
        Set(ByVal value As String)
            If Not IsNothing(gtus_hash) Then
                If Not gtus_hash.Equals(value) Then
                    gtus_hash = value
                    OnGtusHashChanged(gtus_hash, EventArgs.Empty)
                End If
            Else
                gtus_hash = value
                OnGtusHashChanged(gtus_hash, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property GtusSalt() As String
        Get
            Return gtus_salt
        End Get
        Set(ByVal value As String)
            If Not IsNothing(gtus_salt) Then
                If Not gtus_salt.Equals(value) Then
                    gtus_salt = value
                    OnGtusSaltChanged(gtus_salt, EventArgs.Empty)
                End If
            Else
                gtus_salt = value
                OnGtusSaltChanged(gtus_salt, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property GtusEstado() As Boolean
        Get
            Return gtus_Estado
        End Get
        Set(ByVal value As Boolean)
            If Not IsNothing(gtus_Estado) Then
                If Not gtus_Estado.Equals(value) Then
                    gtus_Estado = value
                    OnGtusEstadoChanged(gtus_Estado, EventArgs.Empty)
                End If
            Else
                gtus_Estado = value
                OnGtusEstadoChanged(gtus_Estado, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GtusFecCreacion() As DateTime
        Get
            Return gtus_feccreacion
        End Get
        Set(ByVal value As DateTime)
            If Not IsNothing(gtus_feccreacion) Then
                If Not gtus_feccreacion.Equals(value) Then
                    gtus_feccreacion = value
                    OnGtusFecCreacionChanged(gtus_feccreacion, EventArgs.Empty)
                End If
            Else
                gtus_feccreacion = value
                OnGtusFecCreacionChanged(gtus_feccreacion, EventArgs.Empty)
            End If
        End Set
    End Property


    Public Property GtusUsrCreacion() As Long
        Get
            Return gtus_usrcreacion
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(gtus_usrcreacion) Then
                If Not gtus_usrcreacion.Equals(value) Then
                    gtus_usrcreacion = value
                    OnGtusUsrCreacionChanged(gtus_usrcreacion, EventArgs.Empty)
                End If
            Else
                gtus_usrcreacion = value
                OnGtusUsrCreacionChanged(gtus_usrcreacion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GtusFecModificacion() As DateTime
        Get
            Return gtus_fecmodificacion
        End Get
        Set(ByVal value As DateTime)
            If Not IsNothing(gtus_fecmodificacion) Then
                If Not gtus_fecmodificacion.Equals(value) Then
                    gtus_fecmodificacion = value
                    OnGtusFecModificacionChanged(gtus_fecmodificacion, EventArgs.Empty)
                End If
            Else
                gtus_usuario = value
                OnGtusFecModificacionChanged(gtus_fecmodificacion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property GtusUsrModificacion() As Long
        Get
            Return gtus_usrmodificacion
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(gtus_usrmodificacion) Then
                If Not gtus_usrmodificacion.Equals(value) Then
                    gtus_usrmodificacion = value
                    OnGtusUsrModificacionChanged(gtus_usrmodificacion, EventArgs.Empty)
                End If
            Else
                gtus_usrmodificacion = value
                OnGtusUsrModificacionChanged(gtus_usrmodificacion, EventArgs.Empty)
            End If
        End Set
    End Property




#End Region

#Region " Eventos "

    Public Event GtusIdChanged As EventHandler
    Public Event TiposUsuariosFkChanged As EventHandler
    Public Event ENTID_CodigoFkChanged As EventHandler
    Public Event GtusUsuarioChanged As EventHandler

    Public Event GtusContrasenaChanged As EventHandler
    Public Event GtusEstadoChanged As EventHandler
    Public Event GtusFecCreacionChanged As EventHandler
    Public Event GtusUsrCreacionChanged As EventHandler


    'gtus_id 
    Public Event GtusHashChanged As EventHandler
    Public Event GtusSaltChanged As EventHandler


    Public Event GtusFecModificacionChanged As EventHandler
    Public Event GtusUsrModificacionChanged As EventHandler


    Public Sub OnGtusIdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusIdChanged(sender, e)
    End Sub

    Public Sub OnTiposUsuariosFkChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TiposUsuariosFkChanged(sender, e)
    End Sub



    Public Sub OnENTID_CodigoFkChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_CodigoFkChanged(sender, e)
    End Sub

    Public Sub OnGtusUsuarioChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusUsuarioChanged(sender, e)
    End Sub
    '=================
    Public Sub OnGtusContrasenaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusContrasenaChanged(sender, e)
    End Sub

    '
    Public Sub OnGtusHashChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusHashChanged(sender, e)
    End Sub

    Public Sub OnGtusSaltChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusSaltChanged(sender, e)
    End Sub

    Public Sub OnGtusEstadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusEstadoChanged(sender, e)
    End Sub

    Public Sub OnGtusFecCreacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusFecCreacionChanged(sender, e)
    End Sub

    Public Sub OnGtusUsrCreacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusUsrCreacionChanged(sender, e)
    End Sub

    Public Sub OnGtusFecModificacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusFecModificacionChanged(sender, e)
    End Sub
    Public Sub OnGtusUsrModificacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GtusUsrModificacionChanged(sender, e)
    End Sub

#End Region



    Public ReadOnly Property Nuevo() As Boolean
        Get
            Return m_nuevo
        End Get
    End Property

    Public ReadOnly Property Modificado() As Boolean
        Get
            Return m_modificado
        End Get
    End Property

    Public ReadOnly Property Eliminado() As Boolean
        Get
            Return m_eliminado
        End Get
    End Property

    Public ReadOnly Property Hash() As Hashtable
        Get
            Return m_hash
        End Get
    End Property

    Public Shared ReadOnly Property Tabla() As String
        Get
            Return "TRANGUIAS_Usuarios"
        End Get
    End Property

    Public Shared ReadOnly Property Esquema() As String
        Get
            Return "TransportesGuias"
        End Get
    End Property


#Region " Metodos "

    Public Sub Instanciar(ByVal x_instancia As ACEInstancia)
        Select Case x_instancia
            Case ACEInstancia.Consulta
                m_nuevo = False
                m_modificado = False
                m_eliminado = False
            Case ACEInstancia.Nuevo
                m_nuevo = True
                m_modificado = False
                m_eliminado = False
            Case ACEInstancia.Modificado
                m_nuevo = False
                m_modificado = True
                m_eliminado = False
            Case ACEInstancia.Eliminado
                m_nuevo = False
                m_modificado = False
                m_eliminado = True
        End Select
    End Sub

    Public Sub ActualizarInstancia()
        If Not Nuevo Then
            If Not Eliminado Then
                Instanciar(ACEInstancia.Modificado)
            End If
        End If
    End Sub

#End Region

End Class
