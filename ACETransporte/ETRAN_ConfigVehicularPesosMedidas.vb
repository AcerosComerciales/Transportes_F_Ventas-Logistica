Imports System.Xml
Imports ACFramework

Public Class ETRAN_ConfigVehicularPesosMedidas
    #Region "Campos"
    Private m_cvehic_codigo As integer
    Private m_tipos_codtipocvehic As String
    Private m_cvehic_longitudmaxima As Decimal
    Private m_cvehic_ejedelanteromax As Decimal
    Private m_cvehic_ejeposterior1max As decimal
    Private m_cvehic_ejeposterior2max as Decimal
    Private m_cvehic_ejeposterior3max As Decimal
    Private m_cvehic_ejeposterior4max As Decimal
    Private m_cvehic_pesobrutomax As Decimal
    Private m_cvehic_usrcrea As String
    Private m_cvehic_feccrea as Date
    Private m_cvehic_usrmod As String
    Private m_cvehic_fecmod As Date

    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean

    Private m_hash As Hashtable
#End Region
    
#Region" Constructores "
	
    Public Sub New()

        Try
            Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_ConfigVehicularPesosMedidas
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
    	
    Public Property CVEHIC_Codigo() As Integer
        Get
            return m_cvehic_codigo
        End Get
        Set(ByVal value As Integer)
            If Not IsNothing(m_cvehic_codigo) Then
                If Not m_cvehic_codigo.Equals(value) Then
                    m_cvehic_codigo = value
                    OnCVEHIC_CodigoChanged(m_cvehic_codigo, EventArgs.Empty)
                End If
            Else
                m_cvehic_codigo = value
                OnCVEHIC_CodigoChanged(m_cvehic_codigo, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property TIPOS_CodTipoCVehic() As String
        Get
            return m_tipos_codtipocvehic
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codtipocvehic) Then
                If Not m_tipos_codtipocvehic.Equals(value) Then
                    m_tipos_codtipocvehic = value
                    OnTIPOS_CodTipoCVehicChanged(m_tipos_codtipocvehic, EventArgs.Empty)
                End If
            Else
                m_tipos_codtipocvehic = value
                OnTIPOS_CodTipoCVehicChanged(m_tipos_codtipocvehic, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CVEHIC_LongitudMaxima() As Decimal
        Get
            return m_cvehic_longitudmaxima
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_cvehic_longitudmaxima) Then
                If Not m_cvehic_longitudmaxima.Equals(value) Then
                    m_cvehic_longitudmaxima = value
                    OnCVEHIC_LongitudMaximaChanged(m_cvehic_longitudmaxima, EventArgs.Empty)
                End If
            Else
                m_cvehic_longitudmaxima = value
                OnCVEHIC_LongitudMaximaChanged(m_cvehic_longitudmaxima, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CVEHIC_EjeDelanteroMax() As Decimal
        Get
            return m_cvehic_ejedelanteromax
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_cvehic_ejedelanteromax) Then
                If Not m_cvehic_ejedelanteromax.Equals(value) Then
                    m_cvehic_ejedelanteromax = value
                    OnCVEHIC_EjeDelanteroMaxChanged(m_cvehic_ejedelanteromax, EventArgs.Empty)
                End If
            Else
                m_cvehic_ejedelanteromax = value
                OnCVEHIC_EjeDelanteroMaxChanged(m_cvehic_ejedelanteromax, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CVEHIC_EjePosterior1Max() As Decimal
        Get
            return m_cvehic_ejeposterior1max
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_cvehic_ejeposterior1max) Then
                If Not m_cvehic_ejeposterior1max.Equals(value) Then
                    m_cvehic_ejeposterior1max = value
                    OnCVEHIC_EjePosterior1MaxChanged(m_cvehic_ejeposterior1max, EventArgs.Empty)
                End If
            Else
                m_cvehic_ejeposterior1max = value
                OnCVEHIC_EjePosterior1MaxChanged(m_cvehic_ejeposterior1max, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CVEHIC_EjePosterior2Max() As Decimal
        Get
            return m_cvehic_ejeposterior2max
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_cvehic_ejeposterior2max) Then
                If Not m_cvehic_ejeposterior2max.Equals(value) Then
                    m_cvehic_ejeposterior2max = value
                    OnCVEHIC_EjePosterior2MaxChanged(m_cvehic_ejeposterior2max, EventArgs.Empty)
                End If
            Else
                m_cvehic_ejeposterior2max = value
                OnCVEHIC_EjePosterior2MaxChanged(m_cvehic_ejeposterior2max, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CVEHIC_EjePosterior3Max() As Decimal
        Get
            return m_cvehic_ejeposterior3max
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_cvehic_ejeposterior3max) Then
                If Not m_cvehic_ejeposterior3max.Equals(value) Then
                    m_cvehic_ejeposterior3max = value
                    OnCVEHIC_EjePosterior3MaxChanged(m_cvehic_ejeposterior3max, EventArgs.Empty)
                End If
            Else
                m_cvehic_ejeposterior3max = value
                OnCVEHIC_EjePosterior3MaxChanged(m_cvehic_ejeposterior3max, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CVEHIC_EjePosterior4Max() As Decimal
        Get
            return m_cvehic_ejeposterior4max
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_cvehic_ejeposterior4max) Then
                If Not m_cvehic_ejeposterior4max.Equals(value) Then
                    m_cvehic_ejeposterior4max = value
                    OnCVEHIC_EjePosterior4MaxChanged(m_cvehic_ejeposterior4max, EventArgs.Empty)
                End If
            Else
                m_cvehic_ejeposterior4max = value
                OnCVEHIC_EjePosterior4MaxChanged(m_cvehic_ejeposterior4max, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CVEHIC_PesoBrutoMax() As Decimal
        Get
            return m_cvehic_pesobrutomax
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_cvehic_pesobrutomax) Then
                If Not m_cvehic_pesobrutomax.Equals(value) Then
                    m_cvehic_pesobrutomax = value
                    OnCVEHIC_PesoBrutoMaxChanged(m_cvehic_pesobrutomax, EventArgs.Empty)
                End If
            Else
                m_cvehic_pesobrutomax = value
                OnCVEHIC_PesoBrutoMaxChanged(m_cvehic_pesobrutomax, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CVEHIC_UsrCrea() As String
        Get
            return m_cvehic_usrcrea
        End Get
        Set(ByVal value As String)
            m_cvehic_usrcrea = value
        End Set
    End Property

    Public Property CVEHIC_FecCrea() As Date
        Get
            return m_cvehic_feccrea
        End Get
        Set(ByVal value As Date)
            m_cvehic_feccrea = value
        End Set
    End Property

    Public Property CVEHIC_UsrMod() As String
        Get
            return m_cvehic_usrmod
        End Get
        Set(ByVal value As String)
            m_cvehic_usrmod = value
        End Set
    End Property

    Public Property CVEHIC_FecMod() As Date
        Get
            return m_cvehic_fecmod
        End Get
        Set(ByVal value As Date)
            m_cvehic_fecmod = value
        End Set
    End Property
#End Region
#Region " Propiedades de Solo Lectura "

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
            Return "TRAN_ConfigVehicularPesosMedidas"
        End Get
    End Property

    Public Shared ReadOnly Property Esquema() As String
        Get
            Return "Transportes"
        End Get
    End Property

#End Region



#Region " Eventos "
    Public Event CVEHIC_CodigoChanged As EventHandler
    Public Event TIPOS_CodTipoCVehicChanged As EventHandler
    public Event CVEHIC_LongitudMaximaChanged as EventHandler
    Public Event CVEHIC_EjeDelanteroMaxChanged as EventHandler
    Public Event CVEHIC_EjePosterior1MaxChanged as EventHandler
    Public  Event CVEHIC_EjePosterior2MaxChanged As EventHandler
    Public Event CVEHIC_EjePosterior3MaxChanged as EventHandler
    Public Event CVEHIC_EjePosterior4MaxChanged as EventHandler
    Public Event CVEHIC_PesoBrutoMaxChanged as EventHandler
    

    
    Public Sub OnCVEHIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CVEHIC_CodigoChanged(sender, e)
    End Sub
    Public Sub OnTIPOS_CodTipoCVehicChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoCVehicChanged(sender, e)
    End Sub
    Public Sub OnCVEHIC_LongitudMaximaChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CVEHIC_LongitudMaximaChanged(sender, e)
    End Sub
    Public Sub OnCVEHIC_EjeDelanteroMaxChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CVEHIC_EjeDelanteroMaxChanged(sender, e)
    End Sub
    Public Sub OnCVEHIC_EjePosterior1MaxChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CVEHIC_EjePosterior1MaxChanged(sender, e)
    End Sub
    Public Sub OnCVEHIC_EjePosterior2MaxChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CVEHIC_EjePosterior2MaxChanged(sender, e)
    End Sub
    Public Sub OnCVEHIC_EjePosterior3MaxChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CVEHIC_EjePosterior3MaxChanged(sender, e)
    End Sub
    Public Sub OnCVEHIC_EjePosterior4MaxChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CVEHIC_EjePosterior4MaxChanged(sender, e)
    End Sub
    Public Sub OnCVEHIC_PesoBrutoMaxChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CVEHIC_PesoBrutoMaxChanged(sender, e)
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
