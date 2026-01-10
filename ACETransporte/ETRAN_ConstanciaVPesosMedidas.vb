Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Public Class ETRAN_ConstanciaVPesosMedidas
#Region " Variables "
    Private m_listETRAN_ConstanciaVGuiasDetalle As List(Of ETRAN_ConstanciaVGuiasDetalle)

    Enum Estado
        Ingresado
        Anulado
        Eliminado
        Confirmado
    End Enum

#End Region
#Region " Campos "
    Private m_const_codigo As String
    Private m_pvent_id As Long
    Private m_almac_id As Short
    Private m_const_serie As String
    Private m_const_numero As Integer
    Private m_const_fechaemision As Date
    Private m_const_rucgenerador As String
    Private m_tipos_codtipocontrol As String
    Private m_tipos_codtipoconfigvehicular As String
    Private m_vehic_placatracto As String
    Private m_vehic_placacarreta As String
    Private m_const_pesobrutovehicmaxpermitido as String
    Private m_const_pesobrutotransportado As Decimal
    Private m_const_pbmaxsoncontrolejes As Decimal
    Private m_const_pbmaxconbonificacion As Decimal
    Private m_const_anchomt As Decimal
    Private m_const_largomt As Decimal
    Private m_const_altomt As Decimal
    Private m_const_observaciones As String
    Private m_const_estado As String
    Private m_const_usrcrea As String
    Private m_const_feccrea As Date
    Private m_const_usrmod As String
    Private m_const_fecmod As Date

    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean
    Private m_hash As Hashtable

#End Region

#Region" Constructores "
	
    Public Sub New()

        Try
            Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_ConstanciaVPesosMedidas
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
#Region " Propiedades Principal"
    Public Property ListETRAN_ConstanciaVGuiasDetalle() As List(Of ETRAN_ConstanciaVGuiasDetalle)
        Get
            Return m_listETRAN_ConstanciaVGuiasDetalle
        End Get
        Set(ByVal value As List(Of ETRAN_ConstanciaVGuiasDetalle))
            m_listETRAN_ConstanciaVGuiasDetalle = value
        End Set
    End Property
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
    Public Property PVENT_Id() As Long
        Get
            return m_pvent_id
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
    Public Property ALMAC_Id() As Long
        Get
            return m_almac_id
        End Get
        Set(ByVal value As Long)
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
    Public Property CONST_Serie() As String
        Get
            return m_const_serie
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_const_serie) Then
                If Not m_const_serie.Equals(value) Then
                    m_const_serie = value
                    OnCONST_SerieChanged(m_const_serie, EventArgs.Empty)
                End If
            Else
                m_const_serie = value
                OnCONST_SerieChanged(m_const_serie, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_Numero() As Integer
        Get
            return m_const_numero
        End Get
        Set(ByVal value As Integer)
            If Not IsNothing(m_const_numero) Then
                If Not m_const_numero.Equals(value) Then
                    m_const_numero = value
                    OnCONST_NumeroChanged(m_const_numero, EventArgs.Empty)
                End If
            Else
                m_const_numero = value
                OnCONST_NumeroChanged(m_const_numero, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_FechaEmision() As Date
        Get
            return m_const_fechaemision
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_const_fechaemision) Then
                If Not m_const_fechaemision.Equals(value) Then
                    m_const_fechaemision = value
                    OnCONST_FechaEmisionChanged(m_const_fechaemision, EventArgs.Empty)
                End If
            Else
                m_const_fechaemision = value
                OnCONST_FechaEmisionChanged(m_const_fechaemision, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_RucGenerador() As String
        Get
            return m_const_rucgenerador
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_const_rucgenerador) Then
                If Not m_const_rucgenerador.Equals(value) Then
                    m_const_rucgenerador = value
                    OnCONST_RucGeneradorChanged(m_const_rucgenerador, EventArgs.Empty)
                End If
            Else
                m_const_rucgenerador = value
                OnCONST_RucGeneradorChanged(m_const_rucgenerador, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property TIPOS_CodTipoControl() As String
        Get
            return m_tipos_codtipocontrol
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codtipocontrol) Then
                If Not m_tipos_codtipocontrol.Equals(value) Then
                    m_tipos_codtipocontrol = value
                    OnTIPOS_CodTipoControlChanged(m_tipos_codtipocontrol, EventArgs.Empty)
                End If
            Else
                m_tipos_codtipocontrol = value
                OnTIPOS_CodTipoControlChanged(m_tipos_codtipocontrol, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property TIPOS_CodTipoConfigVehicular() As String
        Get
            return m_tipos_codtipoconfigvehicular
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codtipoconfigvehicular) Then
                If Not m_tipos_codtipoconfigvehicular.Equals(value) Then
                    m_tipos_codtipoconfigvehicular = value
                    OnTIPOS_CodTipoConfigVehicularChanged(m_tipos_codtipoconfigvehicular, EventArgs.Empty)
                End If
            Else
                m_tipos_codtipoconfigvehicular = value
                OnTIPOS_CodTipoConfigVehicularChanged(m_tipos_codtipoconfigvehicular, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property VEHIC_PlacaTracto() As String
        Get
            return m_vehic_placatracto
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_vehic_placatracto) Then
                If Not m_vehic_placatracto.Equals(value) Then
                    m_vehic_placatracto = value
                    OnVEHIC_PlacaTractoChanged(m_vehic_placatracto, EventArgs.Empty)
                End If
            Else
                m_vehic_placatracto = value
                OnVEHIC_PlacaTractoChanged(m_vehic_placatracto, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property VEHIC_PlacaCarreta() As String
        Get
            return m_vehic_placacarreta
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_vehic_placacarreta) Then
                If Not m_vehic_placacarreta.Equals(value) Then
                    m_vehic_placacarreta = value
                    OnVEHIC_PlacaCarretaChanged(m_vehic_placacarreta, EventArgs.Empty)
                End If
            Else
                m_vehic_placacarreta = value
                OnVEHIC_PlacaCarretaChanged(m_vehic_placacarreta, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_PesoBrutoVehicMaxPermitido() As Decimal
        Get
            return m_const_pesobrutovehicmaxpermitido
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_const_pesobrutovehicmaxpermitido) Then
                If Not m_const_pesobrutovehicmaxpermitido.Equals(value) Then
                    m_const_pesobrutovehicmaxpermitido = value
                    OnCONST_PesoBrutoVehicMaxPermitidoChanged(m_const_pesobrutovehicmaxpermitido, EventArgs.Empty)
                End If
            Else
                m_const_pesobrutovehicmaxpermitido = value
                OnCONST_PesoBrutoVehicMaxPermitidoChanged(m_const_pesobrutovehicmaxpermitido, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_PesoBrutoTransportado() As Decimal
        Get
            return m_const_pesobrutotransportado
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_const_pesobrutotransportado) Then
                If Not m_const_pesobrutotransportado.Equals(value) Then
                    m_const_pesobrutotransportado = value
                    OnCONST_PesoBrutoTransportadoChanged(m_const_pesobrutotransportado, EventArgs.Empty)
                End If
            Else
                m_const_pesobrutotransportado = value
                OnCONST_PesoBrutoTransportadoChanged(m_const_pesobrutotransportado, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_PBMaxSinControEjes() As Decimal
        Get
            return m_const_pbmaxsoncontrolejes
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_const_pbmaxsoncontrolejes) Then
                If Not m_const_pbmaxsoncontrolejes.Equals(value) Then
                    m_const_pbmaxsoncontrolejes = value
                    OnCONST_PBMaxSinControEjesChanged(m_const_pbmaxsoncontrolejes, EventArgs.Empty)
                End If
            Else
                m_const_pbmaxsoncontrolejes = value
                OnCONST_PBMaxSinControEjesChanged(m_const_pbmaxsoncontrolejes, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_PBMaxConBonificacion() As Decimal
        Get
            return m_const_pbmaxconbonificacion
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_const_pbmaxconbonificacion) Then
                If Not m_const_pbmaxconbonificacion.Equals(value) Then
                    m_const_pbmaxconbonificacion = value
                    OnCONST_PBMaxConBonificacionChanged(m_const_pbmaxconbonificacion, EventArgs.Empty)
                End If
            Else
                m_const_pbmaxconbonificacion = value
                OnCONST_PBMaxConBonificacionChanged(m_const_pbmaxconbonificacion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_AnchoMt() As Decimal
        Get
            return m_const_anchomt
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_const_anchomt) Then
                If Not m_const_anchomt.Equals(value) Then
                    m_const_anchomt = value
                    OnCONST_AnchoMtChanged(m_const_anchomt, EventArgs.Empty)
                End If
            Else
                m_const_anchomt = value
                OnCONST_AnchoMtChanged(m_const_anchomt, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_LargoMt() As Decimal
        Get
            return m_const_largomt
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_const_largomt) Then
                If Not m_const_largomt.Equals(value) Then
                    m_const_largomt = value
                    OnCONST_LargoMtChanged(m_const_largomt, EventArgs.Empty)
                End If
            Else
                m_const_largomt = value
                OnCONST_LargoMtChanged(m_const_largomt, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_AltoMt() As Decimal
        Get
            return m_const_altomt
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_const_altomt) Then
                If Not m_const_altomt.Equals(value) Then
                    m_const_altomt = value
                    OnCONST_AltoMtChanged(m_const_altomt, EventArgs.Empty)
                End If
            Else
                m_const_altomt = value
                OnCONST_AltoMtChanged(m_const_altomt, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property CONST_Observaciones() As String
        Get
            return m_const_observaciones
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_const_observaciones) Then
                If Not m_const_observaciones.Equals(value) Then
                    m_const_observaciones = value
                    OnCONST_ObservacionesChanged(m_const_observaciones, EventArgs.Empty)
                End If
            Else
                m_const_observaciones = value
                OnCONST_ObservacionesChanged(m_const_observaciones, EventArgs.Empty)
            End If
        End Set
    End Property
    
    Public Property CONST_Estado() As String
        Get
            Return m_const_estado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_const_estado) Then
                If Not m_const_estado.Equals(value) Then
                    m_const_estado = value
                    OnCONST_EstadoChanged(m_const_estado, EventArgs.Empty)
                End If
            Else
                m_const_estado = value
                OnCONST_EstadoChanged(m_const_estado, EventArgs.Empty)
            End If
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
            Return "TRAN_ConstanciaVPesosMedidas"
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
    Public Event PVENT_IdChanged As EventHandler
    Public Event ALMAC_IdChanged As EventHandler
    Public Event CONST_SerieChanged as EventHandler
    Public Event CONST_NumeroChanged as EventHandler
    Public Event CONST_FechaEmisionChanged as EventHandler
    Public Event CONST_RucGeneradorChanged as EventHandler
    Public Event TIPOS_CodTipoControlChanged as EventHandler
    Public Event VEHIC_PlacaTractoChanged as EventHandler
    Public Event VEHIC_PlacaCarretaChanged as EventHandler
    Public Event CONST_PesoBrutoVehicMaxPermitidoChanged as EventHandler
    Public Event CONST_PesoBrutoTransportadoChanged as EventHandler
    Public Event CONST_PBMaxSinControEjesChanged as EventHandler
    Public Event CONST_PBMaxConBonificacionChanged as EventHandler
    Public Event CONST_AnchoMtChanged as EventHandler
    Public Event CONST_LargoMtChanged as EventHandler
    Public Event CONST_AltoMtChanged as EventHandler
    Public Event CONST_ObservacionesChanged as EventHandler
    Public Event CONST_EstadoChanged As EventHandler
    Public Event TIPOS_CodTipoConfigVehicularChanged as EventHandler
    Public Sub OnCONST_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_CodigoChanged(sender, e)
    End Sub
    Public Sub OnPVENT_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_IdChanged(sender,e)
    End Sub
    Public Sub OnALMAC_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ALMAC_IdChanged(sender,e)
    End Sub
    Public Sub OnCONST_SerieChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_SerieChanged(sender,e)
    End Sub
    Public Sub OnCONST_NumeroChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_NumeroChanged(sender,e)
    End Sub
    Public Sub OnCONST_FechaEmisionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_FechaEmisionChanged(sender,e)
    End Sub
    Public Sub OnCONST_RucGeneradorChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_RucGeneradorChanged(sender,e)
    End Sub
    Public Sub OnTIPOS_CodTipoControlChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoControlChanged(sender,e)
    End Sub
    Public Sub OnTIPOS_CodTipoConfigVehicularChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoConfigVehicularChanged(sender,e)
    End Sub
    Public Sub OnVEHIC_PlacaTractoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent VEHIC_PlacaTractoChanged(sender,e)
    End Sub
    Public Sub OnVEHIC_PlacaCarretaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent VEHIC_PlacaCarretaChanged(sender,e)
    End Sub
    Public Sub OnCONST_PesoBrutoVehicMaxPermitidoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_PesoBrutoVehicMaxPermitidoChanged(sender,e)
    End Sub
    Public Sub OnCONST_PesoBrutoTransportadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_PesoBrutoTransportadoChanged(sender,e)
    End Sub
    Public Sub OnCONST_PBMaxSinControEjesChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_PBMaxSinControEjesChanged(sender,e)
    End Sub
    Public Sub OnCONST_PBMaxConBonificacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_PBMaxConBonificacionChanged(sender,e)
    End Sub
    Public Sub OnCONST_AnchoMtChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_AnchoMtChanged(sender,e)
    End Sub
    Public Sub OnCONST_LargoMtChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_LargoMtChanged(sender,e)
    End Sub
    Public Sub OnCONST_AltoMtChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_AltoMtChanged(sender,e)
    End Sub
    Public Sub OnCONST_ObservacionesChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_ObservacionesChanged(sender,e)
    End Sub
    Public Sub OnCONST_EstadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent CONST_EstadoChanged(sender,e)
    End Sub

    

    Public Property CONST_UsrCrea() As String
        Get
            return m_const_usrcrea
        End Get
        Set(ByVal value As String)
            m_const_usrcrea = value
        End Set
    End Property

    Public Property CONST_FecCrea() As Date
        Get
            return m_const_feccrea
        End Get
        Set(ByVal value As Date)
            m_const_feccrea = value
        End Set
    End Property

    Public Property CONST_UsrMod() As String
        Get
            return m_const_usrmod
        End Get
        Set(ByVal value As String)
            m_const_usrmod = value
        End Set
    End Property

    Public Property CONST_FecMod() As Date
        Get
            return m_const_fecmod
        End Get
        Set(ByVal value As Date)
            m_const_fecmod = value
        End Set
    End Property
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

    Public Shared Function getEstado(ByVal x_opcion As Estado)

        Select Case x_opcion
            Case Estado.Anulado
                Return "X"
            Case Estado.Confirmado
                Return "C"
            Case Estado.Eliminado
                Return "E"
            Case Estado.Ingresado
                Return "I"
            Case Else
                Return "I"
        End Select

    End Function

#End Region

End Class
