Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml

Imports ACFramework

Partial Public Class EArticDestinos

#Region " Variables "
    ' ''Articulos Destinos
    Private m_listArtDestinos As List(Of EArticDestinos)
    Private m_artic_descripcion As String

    Public Enum TipoInicializacion
        Todos
        Articulos_Destino
    End Enum



#End Region

#Region " Propiedades "
    Public Property ListArticDestinos() As List(Of EArticDestinos)
        Get
            Return m_listArtDestinos
        End Get
        Set(ByVal value As List(Of EArticDestinos))
            m_listArtDestinos = value
        End Set
    End Property

    Public Property ARTIC_Descripcion() As String
        Get
            Return m_artic_descripcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_artic_descripcion) Then
                If Not m_artic_descripcion.Equals(value) Then
                    m_artic_descripcion = value
                End If
            Else
                m_artic_descripcion = value
            End If
        End Set
    End Property


#End Region

#Region " Constructores "
    Public Sub New(ByVal x_tipo As TipoInicializacion)
        Select Case x_tipo
            Case TipoInicializacion.Articulos_Destino
                m_listArtDestinos = New List(Of EArticDestinos)

            Case 2

            Case Else

        End Select
        Try
            Dim _obj As Object = ACELogistica.My.Resources.xmlArticDestinos
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

#Region " Metodos "

#End Region

End Class



'''''''''''''''''''''''''''''''''''''''' articulos parciales

Partial Public Class EArticDestinos

#Region " Campos "

    Private m_artic_codigo As String
    Private m_artic_codigodestino As String
    Private m_artde_usrcrea As String
    Private m_artde_feccrea As Date
    Private m_artde_usrmod As String
    Private m_artde_fecmod As Date
    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean

    Private m_hash As Hashtable
#End Region

#Region " Constructores "

    Public Sub New()

        Try
            Dim _obj As Object = ACELogistica.My.Resources.xmlArticDestinos
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

    Public Property ARTIC_Codigo() As String
        Get
            Return m_artic_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_artic_codigo) Then
                If Not m_artic_codigo.Equals(value) Then
                    m_artic_codigo = value
                    OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
                End If
            Else
                m_artic_codigo = value
                OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property ARTIC_CodigoDestino() As String
        Get
            Return m_artic_codigodestino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_artic_codigodestino) Then
                If Not m_artic_codigodestino.Equals(value) Then
                    m_artic_codigodestino = value
                    OnARTIC_CodigoDestinoChanged(m_artic_codigodestino, EventArgs.Empty)
                End If
            Else
                m_artic_codigodestino = value
                OnARTIC_CodigoDestinoChanged(m_artic_codigodestino, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property ARTDE_UsrCrea() As String
        Get
            Return m_artde_usrcrea
        End Get
        Set(ByVal value As String)
            m_artde_usrcrea = value
        End Set
    End Property
    Public Property ARTDE_FecCrea() As Date
        Get
            Return m_artde_feccrea
        End Get
        Set(ByVal value As Date)
            m_artde_feccrea = value
        End Set
    End Property
    Public Property ARTDE_UsrMod() As String
        Get
            Return m_artde_usrmod
        End Get
        Set(ByVal value As String)
            m_artde_usrmod = value
        End Set
    End Property
    Public Property ARTDE_FecMod() As Date
        Get
            Return m_artde_fecmod
        End Get
        Set(ByVal value As Date)
            m_artde_fecmod = value
        End Set
    End Property
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
            Return "ArticDestinos"
        End Get
    End Property
    Public Shared ReadOnly Property Esquema() As String
        Get
            Return "dbo"
        End Get
    End Property


#End Region

#Region " Eventos "

    Public Event ARTIC_CodigoChanged As EventHandler
    Public Event ARTIC_CodigoDestinoChanged As EventHandler
    Public Sub OnARTIC_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ARTIC_CodigoChanged(sender, e)
    End Sub
    Public Sub OnARTIC_CodigoDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ARTIC_CodigoDestinoChanged(sender, e)
    End Sub

#End Region

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