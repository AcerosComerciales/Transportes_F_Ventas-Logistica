Imports System.Xml
Imports ACFramework

Public Class ETRANGUIAS_Entidades
#Region " Variables "

    Private enti_id As Long
    Private tipo_documentofk As Long
    Private m_entid_documento As String
    Private enti_razonsocial As String
    Private entid_direccion As String
    Private entid_estado As Boolean
    Private entid_feccreacion As DateTime
    Private entid_usr_creacion As Long
    Private entid_fec_modificacion As DateTime
    Private entid_usr_modificacion As Long


    Private m_pedid_fechaentrega_old As DateTime

    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean


    Private m_hash As Hashtable

    Enum Estado
        Activo = 0
        Inactivo = 1
    End Enum
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
#End Region
    Public Sub New()

        Try
            Dim _obj As Object = ACEAppMovil.My.Resources.xmlETRANGUIAS_Entidades
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

#Region " Propiedades "

    Public Property EntiId() As Long
        Get
            Return enti_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(enti_id) Then
                If Not enti_id.Equals(value) Then
                    enti_id = value

                    OnEntiIdChanged(enti_id, EventArgs.Empty)
                End If
            Else
                enti_id = value
                OnEntiIdChanged(enti_id, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TipoDocumentoFk() As Long
        Get
            Return tipo_documentofk
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(tipo_documentofk) Then
                If Not tipo_documentofk.Equals(value) Then
                    tipo_documentofk = value
                    OnTiposDocumentoFkChanged(tipo_documentofk, EventArgs.Empty)
                End If
            Else
                tipo_documentofk = value
                OnTiposDocumentoFkChanged(tipo_documentofk, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property EntiDocumento() As String
        Get
            Return m_entid_documento
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_documento) Then
                If Not m_entid_documento.Equals(value) Then
                    m_entid_documento = value
                    OnEntiDocumentoChanged(m_entid_documento, EventArgs.Empty)
                End If
            Else
                m_entid_documento = value
                OnEntiDocumentoChanged(m_entid_documento, EventArgs.Empty)
            End If
        End Set
    End Property


    Public Property EntiRazonSocial() As String
        Get
            Return enti_razonsocial
        End Get
        Set(ByVal value As String)
            If Not IsNothing(enti_razonsocial) Then
                If Not enti_razonsocial.Equals(value) Then
                    enti_razonsocial = value
                    OnEntiRazonSocialChanged(enti_razonsocial, EventArgs.Empty)
                End If
            Else
                enti_razonsocial = value
                OnEntiRazonSocialChanged(enti_razonsocial, EventArgs.Empty)
            End If
        End Set
    End Property

    '=================================
    Public Property EntiDireccion() As String
        Get
            Return entid_direccion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(entid_direccion) Then
                If Not entid_direccion.Equals(value) Then
                    entid_direccion = value
                    OnEntiDireccionChanged(entid_direccion, EventArgs.Empty)
                End If
            Else
                entid_direccion = value
                OnEntiDireccionChanged(entid_direccion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property EntiEstado() As Long
        Get
            Return entid_estado
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(entid_estado) Then
                If Not entid_estado.Equals(value) Then
                    entid_estado = value
                    OnEntiEstadoChanged(entid_estado, EventArgs.Empty)
                End If
            Else
                entid_estado = value
                OnEntiEstadoChanged(entid_estado, EventArgs.Empty)
            End If
        End Set
    End Property



    Public Property EntiFecCreacion() As DateTime
        Get
            Return entid_feccreacion
        End Get
        Set(ByVal value As DateTime)
            If Not IsNothing(entid_feccreacion) Then
                If Not entid_feccreacion.Equals(value) Then
                    entid_feccreacion = value
                    OnEntiFecCreacionChanged(entid_feccreacion, EventArgs.Empty)
                End If
            Else
                entid_feccreacion = value
                OnEntiFecCreacionChanged(entid_feccreacion, EventArgs.Empty)

            End If
        End Set
    End Property


    Public Property EntiUsrCreacion() As Long
        Get
            Return entid_usr_creacion
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(entid_usr_creacion) Then
                If Not entid_usr_creacion.Equals(value) Then
                    entid_usr_creacion = value
                    OnEntiUsrCreacionChanged(entid_usr_creacion, EventArgs.Empty)
                End If
            Else
                entid_usr_creacion = value
                OnEntiUsrCreacionChanged(entid_usr_creacion, EventArgs.Empty)

            End If
        End Set
    End Property


    Public Property EntiFecModificacion() As DateTime
        Get
            Return entid_fec_modificacion
        End Get
        Set(ByVal value As DateTime)
            If Not IsNothing(entid_fec_modificacion) Then
                If Not entid_fec_modificacion.Equals(value) Then
                    entid_fec_modificacion = value
                    OnEntiFecModificacionChanged(entid_fec_modificacion, EventArgs.Empty)
                End If
            Else
                entid_fec_modificacion = value
                OnEntiFecModificacionChanged(entid_fec_modificacion, EventArgs.Empty)
            End If
        End Set
    End Property


    Public Property EntiUsrModificacion() As Long
        Get
            Return entid_usr_modificacion
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(entid_usr_modificacion) Then
                If Not entid_usr_modificacion.Equals(value) Then
                    entid_usr_modificacion = value
                    OnEntiUsrModificacionChanged(entid_usr_modificacion, EventArgs.Empty)
                End If
            Else
                entid_usr_modificacion = value
                OnEntiUsrModificacionChanged(entid_usr_modificacion, EventArgs.Empty)
            End If
        End Set
    End Property

    'Public ReadOnly Property EntiDireccion() As String
    '    Get
    '        Select Case m_pedid_estado
    '            Case getEstado(Estado.Ingresado)
    '                Return Estado.Ingresado.ToString()
    '            Case getEstado(Estado.Anulado)
    '                Return Estado.Anulado.ToString()
    '            Case getEstado(Estado.Confirmado)
    '                Return Estado.Confirmado.ToString()
    '            Case getEstado(Estado.Eliminado)
    '                Return Estado.Eliminado.ToString()
    '            Case getEstado(Estado.Rehusado)
    '                Return Estado.Rehusado.ToString()
    '            Case getEstado(Estado.Nuevo)
    '                Return Estado.Nuevo.ToString()
    '            Case Else
    '                Return Estado.Ingresado.ToString()
    '        End Select
    '    End Get
    'End Property
    'Public ReadOnly Property Documento()
    '    Get
    '        Return m_pedid_codigo.Substring(0, 2) & "-" & m_pedid_codigo.Substring(2, 3).ToString().PadLeft(3, "0") & "-" & m_pedid_numero.ToString().PadLeft(8, "0")
    '    End Get

    'End Property

#End Region




#Region " Metodos "
    Public Shared Function getEstado(ByVal x_opcion As Estado)

        Select Case x_opcion
            Case Estado.Activo
                Return 1
            Case Estado.Inactivo
                Return 0

        End Select

    End Function


#End Region



#Region "Eventos "

    Public Event EntiIdChanged As EventHandler
    Public Event TiposDocumentoFkChanged As EventHandler
    Public Event EntiDocumentoChanged As EventHandler


    Public Event EntiRazonSocialChanged As EventHandler

    Public Event EntiDireccionChanged As EventHandler
    Public Event EntiEstadoChanged As EventHandler
    Public Event EntiFecCreacionChanged As EventHandler
    Public Event EntiUsrCreacionChanged As EventHandler

    Public Event EntiFecModificacionChanged As EventHandler
    Public Event EntiUsrModificacionChanged As EventHandler

#End Region


    Public Sub OnEntiIdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent EntiIdChanged(sender, e)
    End Sub

    Public Sub OnTiposDocumentoFkChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TiposDocumentoFkChanged(sender, e)
    End Sub

    Public Sub OnEntiDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent EntiDocumentoChanged(sender, e)
    End Sub


    Public Sub OnEntiRazonSocialChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent EntiRazonSocialChanged(sender, e)
    End Sub
    '=================
    Public Sub OnEntiDireccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent EntiDireccionChanged(sender, e)
    End Sub

    '
    Public Sub OnEntiEstadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent EntiEstadoChanged(sender, e)
    End Sub

    Public Sub OnEntiFecCreacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent EntiFecCreacionChanged(sender, e)
    End Sub

    Public Sub OnEntiUsrCreacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent EntiUsrCreacionChanged(sender, e)
    End Sub

    Public Sub OnEntiFecModificacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent EntiFecModificacionChanged(sender, e)
    End Sub

    Public Sub OnEntiUsrModificacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent EntiUsrModificacionChanged(sender, e)
    End Sub



#Region " Propiedades de Solo Lectura "

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
            Return "TRANGUIAS_Entidades"
        End Get
    End Property

    Public Shared ReadOnly Property Esquema() As String
        Get
            Return "TransportesGuias"
        End Get
    End Property

#End Region


#Region "Metodos "


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
#End Region



    Public Sub ActualizarInstancia()
        If Not Nuevo Then
            If Not Eliminado Then
                Instanciar(ACEInstancia.Modificado)
            End If
        End If
    End Sub


End Class
