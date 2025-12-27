Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class PuntoVenta
    Implements ICloneable

#Region " Variables "
    Private m_almac_descripcion As String
    Private m_sucur_nombre As String
    Private m_vspva_parapedidos As Boolean

    Private m_almacenactivo As Boolean
    Private m_seleccionar As Boolean
#End Region

#Region " Propiedades "
    Public Property ALMAC_Nombre() As String
        Get
            Return m_almac_descripcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_almac_descripcion) Then
                If Not m_almac_descripcion.Equals(value) Then
                    m_almac_descripcion = value
                End If
            Else
                m_almac_descripcion = value
            End If
        End Set
    End Property

    Public Property SUCUR_Nombre() As String
        Get
            Return m_sucur_nombre
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_sucur_nombre) Then
                If Not m_sucur_nombre.Equals(value) Then
                    m_sucur_nombre = value
                End If
            Else
                m_sucur_nombre = value
            End If
        End Set
    End Property

    Public Property VSPVA_ParaPedidos() As Boolean
        Get
            Return m_vspva_parapedidos
        End Get
        Set(ByVal value As Boolean)
            m_vspva_parapedidos = value
        End Set
    End Property

    Public Property AlmacenActivo() As Boolean
        Get
            Return m_almacenactivo
        End Get
        Set(ByVal value As Boolean)
            m_almacenactivo = value
        End Set
    End Property

    Public Property Seleccionar() As Boolean
        Get
            Return m_seleccionar
        End Get
        Set(ByVal value As Boolean)
            m_seleccionar = value
        End Set
    End Property


#End Region

#Region " Constructores "
    Public Sub New(ByVal x_pvent_id As Long, ByVal x_pvent_descripcion As String)
        Me.m_pvent_id = x_pvent_id
        Me.m_pvent_descripcion = x_pvent_descripcion
    End Sub
#End Region

#Region " Metodos "
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Try
            Dim cloneInstance As New PuntoVenta()
            cloneInstance = CType(Me, PuntoVenta)
            Return cloneInstance.MemberwiseClone
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class



'''''''''''''''''''''parcial


Partial Public Class PuntoVenta

#Region " Campos "

    Private m_pvent_id As Long
    Private m_zonas_codigo As String
    Private m_sucur_id As Short
    Private m_almac_id As Short
    Private m_pvent_descripcion As String
    Private m_pvent_principal As Boolean
    Private m_pvent_direccionip As String
    Private m_pvent_basedatos As String
    Private m_pvent_direccionipac As String
    Private m_pvent_basedatosac As String
    Private m_pvent_activo As Boolean
    Private m_pvent_bdadmin As String
    Private m_pvent_user As String
    Private m_pvent_password As String
    Private m_pvent_direccionipdesc As String
    Private m_pvent_glosa As String
    Private m_pvent_impresion As Boolean
    Private m_pvent_direccion As String
    Private m_pvent_zonacontable As String
    Private m_pvent_activodespachos As Boolean
    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean

    Private m_hash As Hashtable
#End Region

#Region " Constructores "

    Public Sub New()

        Try
            Dim _obj As Object = ACELogistica.My.Resources.xmlPuntoVenta
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

    Public Property PVENT_Id() As Long
        Get
            Return m_pvent_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_pvent_id) Then
                If Not m_pvent_id.Equals(value) Then
                    m_pvent_id = value
                    OnPVENT_IdChanged(m_pvent_id, EventArgs.Empty)
                End If
            Else
                m_pvent_id = value
                OnPVENT_IdChanged(m_pvent_id, EventArgs.Empty)
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

    Public Property ALMAC_Id() As Short
        Get
            Return m_almac_id
        End Get
        Set(ByVal value As Short)
            If Not IsNothing(m_almac_id) Then
                If Not m_almac_id.Equals(value) Then
                    m_almac_id = value
                    OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
                End If
            Else
                m_almac_id = value
                OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_Descripcion() As String
        Get
            Return m_pvent_descripcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_descripcion) Then
                If Not m_pvent_descripcion.Equals(value) Then
                    m_pvent_descripcion = value
                    OnPVENT_DescripcionChanged(m_pvent_descripcion, EventArgs.Empty)
                End If
            Else
                m_pvent_descripcion = value
                OnPVENT_DescripcionChanged(m_pvent_descripcion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_Principal() As Boolean
        Get
            Return m_pvent_principal
        End Get
        Set(ByVal value As Boolean)
            If Not m_pvent_principal.Equals(value) Then
                m_pvent_principal = value
                OnPVENT_PrincipalChanged(m_pvent_principal, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_DireccionIP() As String
        Get
            Return m_pvent_direccionip
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_direccionip) Then
                If Not m_pvent_direccionip.Equals(value) Then
                    m_pvent_direccionip = value
                    OnPVENT_DireccionIPChanged(m_pvent_direccionip, EventArgs.Empty)
                End If
            Else
                m_pvent_direccionip = value
                OnPVENT_DireccionIPChanged(m_pvent_direccionip, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_BaseDatos() As String
        Get
            Return m_pvent_basedatos
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_basedatos) Then
                If Not m_pvent_basedatos.Equals(value) Then
                    m_pvent_basedatos = value
                    OnPVENT_BaseDatosChanged(m_pvent_basedatos, EventArgs.Empty)
                End If
            Else
                m_pvent_basedatos = value
                OnPVENT_BaseDatosChanged(m_pvent_basedatos, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_DireccionIPAC() As String
        Get
            Return m_pvent_direccionipac
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_direccionipac) Then
                If Not m_pvent_direccionipac.Equals(value) Then
                    m_pvent_direccionipac = value
                    OnPVENT_DireccionIPACChanged(m_pvent_direccionipac, EventArgs.Empty)
                End If
            Else
                m_pvent_direccionipac = value
                OnPVENT_DireccionIPACChanged(m_pvent_direccionipac, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_BaseDatosAC() As String
        Get
            Return m_pvent_basedatosac
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_basedatosac) Then
                If Not m_pvent_basedatosac.Equals(value) Then
                    m_pvent_basedatosac = value
                    OnPVENT_BaseDatosACChanged(m_pvent_basedatosac, EventArgs.Empty)
                End If
            Else
                m_pvent_basedatosac = value
                OnPVENT_BaseDatosACChanged(m_pvent_basedatosac, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_Activo() As Boolean
        Get
            Return m_pvent_activo
        End Get
        Set(ByVal value As Boolean)
            If Not m_pvent_activo.Equals(value) Then
                m_pvent_activo = value
                OnPVENT_ActivoChanged(m_pvent_activo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_BDAdmin() As String
        Get
            Return m_pvent_bdadmin
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_bdadmin) Then
                If Not m_pvent_bdadmin.Equals(value) Then
                    m_pvent_bdadmin = value
                    OnPVENT_BDAdminChanged(m_pvent_bdadmin, EventArgs.Empty)
                End If
            Else
                m_pvent_bdadmin = value
                OnPVENT_BDAdminChanged(m_pvent_bdadmin, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_User() As String
        Get
            Return m_pvent_user
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_user) Then
                If Not m_pvent_user.Equals(value) Then
                    m_pvent_user = value
                    OnPVENT_UserChanged(m_pvent_user, EventArgs.Empty)
                End If
            Else
                m_pvent_user = value
                OnPVENT_UserChanged(m_pvent_user, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_Password() As String
        Get
            Return m_pvent_password
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_password) Then
                If Not m_pvent_password.Equals(value) Then
                    m_pvent_password = value
                    OnPVENT_PasswordChanged(m_pvent_password, EventArgs.Empty)
                End If
            Else
                m_pvent_password = value
                OnPVENT_PasswordChanged(m_pvent_password, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_DireccionIPDesc() As String
        Get
            Return m_pvent_direccionipdesc
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_direccionipdesc) Then
                If Not m_pvent_direccionipdesc.Equals(value) Then
                    m_pvent_direccionipdesc = value
                    OnPVENT_DireccionIPDescChanged(m_pvent_direccionipdesc, EventArgs.Empty)
                End If
            Else
                m_pvent_direccionipdesc = value
                OnPVENT_DireccionIPDescChanged(m_pvent_direccionipdesc, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_Glosa() As String
        Get
            Return m_pvent_glosa
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_glosa) Then
                If Not m_pvent_glosa.Equals(value) Then
                    m_pvent_glosa = value
                    OnPVENT_GlosaChanged(m_pvent_glosa, EventArgs.Empty)
                End If
            Else
                m_pvent_glosa = value
                OnPVENT_GlosaChanged(m_pvent_glosa, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_Impresion() As Boolean
        Get
            Return m_pvent_impresion
        End Get
        Set(ByVal value As Boolean)
            If Not m_pvent_impresion.Equals(value) Then
                m_pvent_impresion = value
                OnPVENT_ImpresionChanged(m_pvent_impresion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_Direccion() As String
        Get
            Return m_pvent_direccion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_direccion) Then
                If Not m_pvent_direccion.Equals(value) Then
                    m_pvent_direccion = value
                    OnPVENT_DireccionChanged(m_pvent_direccion, EventArgs.Empty)
                End If
            Else
                m_pvent_direccion = value
                OnPVENT_DireccionChanged(m_pvent_direccion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_ZonaContable() As String
        Get
            Return m_pvent_zonacontable
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_zonacontable) Then
                If Not m_pvent_zonacontable.Equals(value) Then
                    m_pvent_zonacontable = value
                    OnPVENT_ZonaContableChanged(m_pvent_zonacontable, EventArgs.Empty)
                End If
            Else
                m_pvent_zonacontable = value
                OnPVENT_ZonaContableChanged(m_pvent_zonacontable, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_ActivoDespachos() As Boolean
        Get
            Return m_pvent_activodespachos
        End Get
        Set(ByVal value As Boolean)
            If Not m_pvent_activodespachos.Equals(value) Then
                m_pvent_activodespachos = value
                OnPVENT_ActivoDespachosChanged(m_pvent_activodespachos, EventArgs.Empty)
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
            Return "PuntoVenta"
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

    Public Event PVENT_IdChanged As EventHandler
    Public Event ZONAS_CodigoChanged As EventHandler
    Public Event SUCUR_IdChanged As EventHandler
    Public Event ALMAC_IdChanged As EventHandler
    Public Event PVENT_DescripcionChanged As EventHandler
    Public Event PVENT_PrincipalChanged As EventHandler
    Public Event PVENT_DireccionIPChanged As EventHandler
    Public Event PVENT_BaseDatosChanged As EventHandler
    Public Event PVENT_DireccionIPACChanged As EventHandler
    Public Event PVENT_BaseDatosACChanged As EventHandler
    Public Event PVENT_ActivoChanged As EventHandler
    Public Event PVENT_BDAdminChanged As EventHandler
    Public Event PVENT_UserChanged As EventHandler
    Public Event PVENT_PasswordChanged As EventHandler
    Public Event PVENT_DireccionIPDescChanged As EventHandler
    Public Event PVENT_GlosaChanged As EventHandler
    Public Event PVENT_ImpresionChanged As EventHandler
    Public Event PVENT_DireccionChanged As EventHandler
    Public Event PVENT_ZonaContableChanged As EventHandler
    Public Event PVENT_ActivoDespachosChanged As EventHandler

    Public Sub OnPVENT_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_IdChanged(sender, e)
    End Sub

    Public Sub OnZONAS_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ZONAS_CodigoChanged(sender, e)
    End Sub

    Public Sub OnSUCUR_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SUCUR_IdChanged(sender, e)
    End Sub

    Public Sub OnALMAC_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ALMAC_IdChanged(sender, e)
    End Sub

    Public Sub OnPVENT_DescripcionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_DescripcionChanged(sender, e)
    End Sub

    Public Sub OnPVENT_PrincipalChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_PrincipalChanged(sender, e)
    End Sub

    Public Sub OnPVENT_DireccionIPChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_DireccionIPChanged(sender, e)
    End Sub

    Public Sub OnPVENT_BaseDatosChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_BaseDatosChanged(sender, e)
    End Sub

    Public Sub OnPVENT_DireccionIPACChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_DireccionIPACChanged(sender, e)
    End Sub

    Public Sub OnPVENT_BaseDatosACChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_BaseDatosACChanged(sender, e)
    End Sub

    Public Sub OnPVENT_ActivoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_ActivoChanged(sender, e)
    End Sub

    Public Sub OnPVENT_BDAdminChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_BDAdminChanged(sender, e)
    End Sub

    Public Sub OnPVENT_UserChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_UserChanged(sender, e)
    End Sub

    Public Sub OnPVENT_PasswordChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_PasswordChanged(sender, e)
    End Sub

    Public Sub OnPVENT_DireccionIPDescChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_DireccionIPDescChanged(sender, e)
    End Sub

    Public Sub OnPVENT_GlosaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_GlosaChanged(sender, e)
    End Sub

    Public Sub OnPVENT_ImpresionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_ImpresionChanged(sender, e)
    End Sub

    Public Sub OnPVENT_DireccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_DireccionChanged(sender, e)
    End Sub

    Public Sub OnPVENT_ZonaContableChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_ZonaContableChanged(sender, e)
    End Sub

    Public Sub OnPVENT_ActivoDespachosChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_ActivoDespachosChanged(sender, e)
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

