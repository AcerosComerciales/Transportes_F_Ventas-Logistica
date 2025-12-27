Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Net.Configuration
Imports System.Xml
Imports ACFramework

Partial Public Class EClientes

#Region " Campos "

    Private m_entid_codigo As String
    Private m_entid_codigovendedor As String
    Private m_zonas_codigo As String
    Private m_sucur_id As Short
    Private m_lprec_id As Long
    Private m_tipos_codtipopercepcion As String
    Private m_clien_percepcion As Boolean
    Private m_clien_precioespecial As Boolean
    Private m_clien_porcprecespecial As Decimal
    Private m_clien_credito As Boolean
    Private m_clien_plazocredito As Short
    Private m_clien_limcredito As Decimal
    Private m_clien_usrcrea As String
    Private m_clien_feccrea As Date
    Private m_clien_usrmod As String
    Private m_clien_fecmod As Date

    Private m_clien_codcondicionpago As String

    Private m_clien_retencion As Boolean

    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean

    Private m_hash As Hashtable
#End Region

#Region " Constructores "

    Public Sub New()

        Try
            Dim _obj As Object = ACEVentas.My.Resources.xmlClientes
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

    Public Property ENTID_Codigo() As String
        Get
            Return m_entid_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_codigo) Then
                If Not m_entid_codigo.Equals(value) Then
                    m_entid_codigo = value
                    OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
                End If
            Else
                m_entid_codigo = value
                OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ENTID_CodigoVendedor() As String
        Get
            Return m_entid_codigovendedor
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_codigovendedor) Then
                If Not m_entid_codigovendedor.Equals(value) Then
                    m_entid_codigovendedor = value
                    OnENTID_CodigoVendedorChanged(m_entid_codigovendedor, EventArgs.Empty)
                End If
            Else
                m_entid_codigovendedor = value
                OnENTID_CodigoVendedorChanged(m_entid_codigovendedor, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ZONAS_Codigo() As String
        Get
            Return m_zonas_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_zonas_codigo) Then
                If Not m_zonas_codigo.Equals(value) Then
                    m_zonas_codigo = value
                    OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
                End If
            Else
                m_zonas_codigo = value
                OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property SUCUR_Id() As Short
        Get
            Return m_sucur_id
        End Get
        Set(ByVal value As Short)
            If Not IsNothing(m_sucur_id) Then
                If Not m_sucur_id.Equals(value) Then
                    m_sucur_id = value
                    OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
                End If
            Else
                m_sucur_id = value
                OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property LPREC_Id() As Long
        Get
            Return m_lprec_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_lprec_id) Then
                If Not m_lprec_id.Equals(value) Then
                    m_lprec_id = value
                    OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
                End If
            Else
                m_lprec_id = value
                OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TIPOS_CodTipoPercepcion() As String
        Get
            Return m_tipos_codtipopercepcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codtipopercepcion) Then
                If Not m_tipos_codtipopercepcion.Equals(value) Then
                    m_tipos_codtipopercepcion = value
                    OnTIPOS_CodTipoPercepcionChanged(m_tipos_codtipopercepcion, EventArgs.Empty)
                End If
            Else
                m_tipos_codtipopercepcion = value
                OnTIPOS_CodTipoPercepcionChanged(m_tipos_codtipopercepcion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property CLIEN_Percepcion() As Boolean
        Get
            Return m_clien_percepcion
        End Get
        Set(ByVal value As Boolean)
            If Not m_clien_percepcion.Equals(value) Then
                m_clien_percepcion = value
                OnCLIEN_PercepcionChanged(m_clien_percepcion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property CLIEN_PrecioEspecial() As Boolean
        Get
            Return m_clien_precioespecial
        End Get
        Set(ByVal value As Boolean)
            If Not m_clien_precioespecial.Equals(value) Then
                m_clien_precioespecial = value
                OnCLIEN_PrecioEspecialChanged(m_clien_precioespecial, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property CLIEN_PorcPrecEspecial() As Decimal
        Get
            Return m_clien_porcprecespecial
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_clien_porcprecespecial) Then
                If Not m_clien_porcprecespecial.Equals(value) Then
                    m_clien_porcprecespecial = value
                    OnCLIEN_PorcPrecEspecialChanged(m_clien_porcprecespecial, EventArgs.Empty)
                End If
            Else
                m_clien_porcprecespecial = value
                OnCLIEN_PorcPrecEspecialChanged(m_clien_porcprecespecial, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property CLIEN_Credito() As Boolean
        Get
            Return m_clien_credito
        End Get
        Set(ByVal value As Boolean)
            If Not m_clien_credito.Equals(value) Then
                m_clien_credito = value
                OnCLIEN_CreditoChanged(m_clien_credito, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property CLIEN_PlazoCredito() As Short
        Get
            Return m_clien_plazocredito
        End Get
        Set(ByVal value As Short)
            If Not IsNothing(m_clien_plazocredito) Then
                If Not m_clien_plazocredito.Equals(value) Then
                    m_clien_plazocredito = value
                    OnCLIEN_PlazoCreditoChanged(m_clien_plazocredito, EventArgs.Empty)
                End If
            Else
                m_clien_plazocredito = value
                OnCLIEN_PlazoCreditoChanged(m_clien_plazocredito, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property CLIEN_LimCredito() As Decimal
        Get
            Return m_clien_limcredito
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_clien_limcredito) Then
                If Not m_clien_limcredito.Equals(value) Then
                    m_clien_limcredito = value
                    OnCLIEN_LimCreditoChanged(m_clien_limcredito, EventArgs.Empty)
                End If
            Else
                m_clien_limcredito = value
                OnCLIEN_LimCreditoChanged(m_clien_limcredito, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property CLIEN_UsrCrea() As String
        Get
            Return m_clien_usrcrea
        End Get
        Set(ByVal value As String)
            m_clien_usrcrea = value
        End Set
    End Property

    Public Property CLIEN_FecCrea() As Date
        Get
            Return m_clien_feccrea
        End Get
        Set(ByVal value As Date)
            m_clien_feccrea = value
        End Set
    End Property

    Public Property CLIEN_UsrMod() As String
        Get
            Return m_clien_usrmod
        End Get
        Set(ByVal value As String)
            m_clien_usrmod = value
        End Set
    End Property

    Public Property CLIEN_FecMod() As Date
        Get
            Return m_clien_fecmod
        End Get
        Set(ByVal value As Date)
            m_clien_fecmod = value
        End Set
    End Property


    Public Property CLIEN_CodCondicionPago() As String
        Get
            Return m_clien_codcondicionpago
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_clien_codcondicionpago) Then
                If Not m_clien_codcondicionpago.Equals(value) Then
                    m_clien_codcondicionpago = value
                    OnCLIEN_CodCondicionPagoChanged(m_clien_codcondicionpago, EventArgs.Empty)
                End If
            Else
                m_clien_codcondicionpago = value
                OnCLIEN_CodCondicionPagoChanged(m_clien_codcondicionpago, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property CLIEN_Retencion() As Boolean
        Get
            Return m_clien_retencion
        End Get
        Set(ByVal value As Boolean)
            If Not m_clien_retencion.Equals(value) Then
                m_clien_retencion = value
                OnCLIEN_RetencionChanged(m_clien_retencion, EventArgs.Empty)
            End If
        End Set
    End Property

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
            Return "Clientes"
        End Get
    End Property

    Public Shared ReadOnly Property Esquema() As String
        Get
            Return "dbo"
        End Get
    End Property

#End Region

#End Region

#Region " Eventos "

    Public Event ENTID_CodigoChanged As EventHandler
    Public Event ENTID_CodigoVendedorChanged As EventHandler
    Public Event ZONAS_CodigoChanged As EventHandler
    Public Event SUCUR_IdChanged As EventHandler
    Public Event LPREC_IdChanged As EventHandler
    Public Event TIPOS_CodTipoPercepcionChanged As EventHandler
    Public Event CLIEN_PercepcionChanged As EventHandler
    Public Event CLIEN_PrecioEspecialChanged As EventHandler
    Public Event CLIEN_PorcPrecEspecialChanged As EventHandler
    Public Event CLIEN_CreditoChanged As EventHandler
    Public Event CLIEN_PlazoCreditoChanged As EventHandler
    Public Event CLIEN_LimCreditoChanged As EventHandler
    Public Event CLIEN_CodCondicionPagoChanged As EventHandler
    Public Event CLIEN_RetencionChanged As EventHandler


    Public Sub OnENTID_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_CodigoChanged(sender, e)
    End Sub

    Public Sub OnENTID_CodigoVendedorChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_CodigoVendedorChanged(sender, e)
    End Sub

    Public Sub OnZONAS_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ZONAS_CodigoChanged(sender, e)
    End Sub

    Public Sub OnSUCUR_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SUCUR_IdChanged(sender, e)
    End Sub

    Public Sub OnLPREC_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent LPREC_IdChanged(sender, e)
    End Sub

    Public Sub OnTIPOS_CodTipoPercepcionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoPercepcionChanged(sender, e)
    End Sub

    Public Sub OnCLIEN_PercepcionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CLIEN_PercepcionChanged(sender, e)
    End Sub

    Public Sub OnCLIEN_PrecioEspecialChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CLIEN_PrecioEspecialChanged(sender, e)
    End Sub

    Public Sub OnCLIEN_PorcPrecEspecialChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CLIEN_PorcPrecEspecialChanged(sender, e)
    End Sub

    Public Sub OnCLIEN_CreditoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CLIEN_CreditoChanged(sender, e)
    End Sub

    Public Sub OnCLIEN_PlazoCreditoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CLIEN_PlazoCreditoChanged(sender, e)
    End Sub

    Public Sub OnCLIEN_LimCreditoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CLIEN_LimCreditoChanged(sender, e)
    End Sub

    Public Sub OnCLIEN_CodCondicionPagoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CLIEN_CodCondicionPagoChanged(sender, e)
    End Sub
    Public Sub OnCLIEN_RetencionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CLIEN_RetencionChanged(sender, e)
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

