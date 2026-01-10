Imports System.Xml
Imports ACFramework

Public Class ETRAN_ConstanciaVGuiasDetalle
#Region " Campos "
    Private m_const_codigo As String
    Private m_consgd_item As Short
    Private m_guiar_codigo As String
    Private m_consgd_descripcionmercaderia as String
    Private m_consgd_pesoguia As Decimal
    Private m_tipos_doccorta As String
    Private m_guiar_serie As String
    Private m_guiar_numero As Integer
    Private m_consgd_usrcrea As String
    Private m_consgd_feccrea As Date
    Private m_consgd_usrmod As String
    Private m_consgd_fecmod As Date
    Private  m_documento As String
    Private m_docventa As String
    Private  m_cliente As String

    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean

    Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
    Public Sub New()

        Try
            Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_ConstanciaVGuiasDetalle
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
#Region" Propiedades "
    Public Property CONST_Codigo() As String
        Get
            return m_const_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_const_codigo) Then
                If Not m_const_codigo.Equals(value) Then
                    m_const_codigo = value
                    OnCONST_CodigoChanged(m_const_codigo, EventArgs.Empty)
                End If
            Else
                m_const_codigo = value
                OnCONST_CodigoChanged(m_const_codigo, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONSGD_Item() As Short
        Get
            return m_consgd_item
        End Get
        Set(ByVal value As Short)
            If Not IsNothing(m_consgd_item) Then
                If Not m_consgd_item.Equals(value) Then
                    m_consgd_item = value
                    OnCONSGD_ItemChanged(m_consgd_item, EventArgs.Empty)
                End If
            Else
                m_consgd_item = value
                OnCONSGD_ItemChanged(m_consgd_item, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property GUIAR_Codigo() As String
        Get
            return m_guiar_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_codigo) Then
                If Not m_guiar_codigo.Equals(value) Then
                    m_guiar_codigo = value
                    OnGUIAR_CodigoChanged(m_guiar_codigo, EventArgs.Empty)
                End If
            Else
                m_guiar_codigo = value
                OnGUIAR_CodigoChanged(m_guiar_codigo, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONSVG_DescripcionMercaderia() As String
        Get
            return m_consgd_descripcionmercaderia
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_consgd_descripcionmercaderia) Then
                If Not m_consgd_descripcionmercaderia.Equals(value) Then
                    m_consgd_descripcionmercaderia = value
                    OnCONSGD_DescripcionMercaderiaChanged(m_consgd_descripcionmercaderia, EventArgs.Empty)
                End If
            Else
                m_consgd_descripcionmercaderia = value
                OnCONSGD_DescripcionMercaderiaChanged(m_consgd_descripcionmercaderia, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONSVG_PesoGuia() As Decimal
        Get
            return m_consgd_pesoguia
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_consgd_pesoguia) Then
                If Not m_consgd_pesoguia.Equals(value) Then
                    m_consgd_pesoguia = value
                    OnCONSGD_PesoGuiaChanged(m_consgd_pesoguia, EventArgs.Empty)
                End If
            Else
                m_consgd_pesoguia = value
                OnCONSGD_PesoGuiaChanged(m_consgd_pesoguia, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property GUIAR_Serie() As String
        Get
            return m_guiar_serie
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_serie) Then
                If Not m_guiar_serie.Equals(value) Then
                    m_guiar_serie = value
                  
                End If
            Else
                m_guiar_serie = value
                
            End If
        End Set
    End Property
    Public Property GUIAR_Numero() As Integer
        Get
            return m_guiar_numero
        End Get
        Set(ByVal value As Integer)
            If Not IsNothing(m_guiar_numero) Then
                If Not m_guiar_numero.Equals(value) Then
                    m_guiar_numero = value
                   
                End If
            Else
                m_guiar_numero = value
               
            End If
        End Set
    End Property
    Public Property TIPOS_TipoDocCorta() As String
        Get
            Return m_tipos_doccorta
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_doccorta) Then
                If Not m_tipos_doccorta.Equals(value) Then
                    m_tipos_doccorta = value
                End If
            Else
                m_tipos_doccorta = value
            End If
        End Set
    End Property
    Public Property Documento() As String
        Get

            Return String.Format("{0} {1}-{2}", m_tipos_doccorta, m_guiar_serie, m_guiar_numero.ToString().PadLeft(7, "0"))

        End Get
        Set(ByVal value As String)
            m_documento = value
        End Set

    End Property
    Public Property DocVenta() As String
        Get
            Return m_docventa
        End Get
        Set(ByVal value As String)
            m_docventa = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return m_cliente
        End Get
        Set(ByVal value As String)
            m_cliente = value
        End Set
    End Property
    Public Property CONSVG_UsrCrea() As String
        Get
            return m_consgd_usrcrea
        End Get
        Set(ByVal value As String)
            m_consgd_usrcrea = value
        End Set
    End Property
    Public Property CONSVG_FecCrea() As Date
        Get
            return m_consgd_feccrea
        End Get
        Set(ByVal value As Date)
            m_consgd_feccrea = value
        End Set
    End Property
    Public Property CONSVG_UsrMod() As String
        Get
            return m_consgd_usrmod
        End Get
        Set(ByVal value As String)
            m_consgd_usrmod = value
        End Set
    End Property
    Public Property CONSVG_FecMod() As Date
        Get
            return m_consgd_fecmod
        End Get
        Set(ByVal value As Date)
            m_consgd_fecmod = value
        End Set
    End Property
    Public ReadOnly Property Nuevo() As Boolean
        Get
            return m_nuevo
        End Get
    End Property
    Public ReadOnly Property Modificado() As Boolean
        Get
            return m_modificado
        End Get
    End Property
    Public ReadOnly Property Eliminado() As Boolean
        Get
            return m_eliminado
        End Get
    End Property
    Public ReadOnly Property Hash() As Hashtable
        Get
            return m_hash
        End Get
    End Property
    Public Shared ReadOnly Property Tabla() As String
        Get
            Return "TRAN_ConstanciaVGuiasDetalle"
        End Get
    End Property
    Public Shared ReadOnly Property Esquema() As String
        Get
            Return "Transportes"
        End Get
    End Property
#End Region

#Region " Eventos "
    Public Event CONST_CodigoChanged As EventHandler
    public Event CONSGD_ItemChanged as EventHandler
    Public Event GUIAR_CodigoChanged As EventHandler
    Public Event CONSGD_DescripcionMercaderiaChanged as EventHandler
    Public Event CONSGD_PesoGuiaChanged as EventHandler
    
    Public Sub OnCONST_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_CodigoChanged(sender, e)
    End Sub
    Public Sub OnCONSGD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONSGD_ItemChanged(sender, e)
    End Sub
    Public Sub OnGUIAR_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_CodigoChanged(sender, e)
    End Sub
    Public Sub OnCONSGD_DescripcionMercaderiaChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONSGD_DescripcionMercaderiaChanged(sender, e)
    End Sub
    Public Sub OnCONSGD_PesoGuiaChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONSGD_PesoGuiaChanged(sender, e)
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
