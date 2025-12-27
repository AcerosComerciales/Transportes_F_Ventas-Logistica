Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDIST_GuiasTodas

#Region " Campos "
    Private m_list_edist_guiasremisiondetalle As List(Of EDIST_GuiasRemisionDetalle)

    Private m_almac_descripcion As String
    Private m_pvent_origen As String
    Private m_almac_destino As String
    Private m_pvent_destino As String
    Private m_tipos_documento As String
    Private m_tipos_doccorta As String
    Private m_tipos_motivotraslado As String
    Private m_docventa As String
    Private m_fechaimpresion As DateTime
    Private m_entid_codusuario As String
    Private m_motivotraslado As Integer

    Private m_tiempo As Integer
    Private m_tiempohora As String
    Private m_generar As Boolean
    Private m_csalida As String
    Private m_numero As Integer
    Private m_guisa_numero As Integer
    Private m_doc_relacion As String
    Private m_Tipo_Doc As String


    Enum Estado
        Ingresado
        Anulado
        Eliminado
        Confirmado
    End Enum
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "
    Public Property ListDIST_GuiasRemisionDetalle() As List(Of EDIST_GuiasRemisionDetalle)
        Get
            Return m_list_edist_guiasremisiondetalle
        End Get
        Set(ByVal value As List(Of EDIST_GuiasRemisionDetalle))
            m_list_eDIST_GuiasRemisionDetalle = value
        End Set
    End Property

  


    Public Property ALMAC_Origen() As String
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

    Public Property ALMAC_Destino() As String
        Get
            Return m_almac_destino
        End Get
        Set(ByVal value As String)
            m_almac_destino = value
        End Set
    End Property


    Public Property PVENT_Destino() As String
        Get
            Return m_pvent_destino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_destino) Then
                If Not m_pvent_destino.Equals(value) Then
                    m_pvent_destino = value
                End If
            Else
                m_pvent_destino = value
            End If
        End Set
    End Property

    Public Property PVENT_Origen() As String
        Get
            Return m_pvent_origen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_origen) Then
                If Not m_pvent_origen.Equals(value) Then
                    m_pvent_origen = value
                End If
            Else
                m_pvent_origen = value
            End If
        End Set
    End Property

    Public Property TIPOS_TipoDocumento() As String
        Get
            Return m_tipos_documento
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_documento) Then
                If Not m_tipos_documento.Equals(value) Then
                    m_tipos_documento = value
                End If
            Else
                m_tipos_documento = value
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

    Public Property TIPOS_MotivoTraslado() As String
        Get
            Return m_tipos_motivotraslado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_motivotraslado) Then
                If Not m_tipos_motivotraslado.Equals(value) Then
                    m_tipos_motivotraslado = value
                End If
            Else
                m_tipos_motivotraslado = value
            End If
        End Set
    End Property

    Public ReadOnly Property DOTRA_Estado_Text() As String
        Get
            Select Case m_guiar_estado
                Case getEstado(Estado.Ingresado)
                    Return Estado.Ingresado.ToString()
                Case getEstado(Estado.Anulado)
                    Return Estado.Anulado.ToString()
                Case getEstado(Estado.Confirmado)
                    Return Estado.Confirmado.ToString()
                Case getEstado(Estado.Eliminado)
                    Return Estado.Eliminado.ToString()
                Case Else
                    Return Estado.Ingresado.ToString()
            End Select
        End Get
    End Property

    Public ReadOnly Property Documento()
        Get
            Return String.Format("{0} {1}-{2}", m_tipos_doccorta, m_guiar_serie, m_guiar_numero.ToString().PadLeft(7, "0"))
        End Get
    End Property

    Public Property DocVenta() As String
        Get
            Return m_docventa
        End Get
        Set(ByVal value As String)
            m_docventa = value
        End Set
    End Property

    Public Property FechaImpresion() As DateTime
        Get
            Return m_fechaimpresion
        End Get
        Set(ByVal value As DateTime)
            m_fechaimpresion = value
        End Set
    End Property

    Public Property ENTID_CodUsuario() As String
        Get
            Return m_entid_codusuario
        End Get
        Set(ByVal value As String)
            m_entid_codusuario = value
        End Set
    End Property
    Public Property doc_relacion() As String '
        Get
            Return m_doc_relacion
        End Get
        Set(ByVal value As String)
            m_doc_relacion = value
        End Set
    End Property

    Public Property Tipo_doc() As String
        Get
            Return m_Tipo_Doc
        End Get
        Set(ByVal value As String)
            m_Tipo_Doc = value
        End Set
    End Property

    Public Property MotivoTraslado() As Integer
        Get
            Return m_motivotraslado
        End Get
        Set(ByVal value As Integer)
            m_motivotraslado = value
        End Set
    End Property

    Public ReadOnly Property Cliente() As String
        Get
            Return String.Format("{0} - {1}", m_entid_codigocliente, m_guiar_descripcioncliente)
        End Get
    End Property

    Public Property Tiempo() As Integer
        Get
            Return m_tiempo
        End Get
        Set(ByVal value As Integer)
            m_tiempo = value
        End Set
    End Property

    Public Property TiempoHora() As String
        Get
            Return m_tiempohora
        End Get
        Set(ByVal value As String)
            m_tiempohora = value
        End Set
    End Property

    Public Property Generar() As Boolean
        Get
            Return m_generar
        End Get
        Set(ByVal value As Boolean)
            m_generar = value
        End Set
    End Property

    Public Property CSalida() As String
        Get
            Return m_csalida
        End Get
        Set(ByVal value As String)
            m_csalida = value
        End Set
    End Property

    Public Property Numero() As Integer
        Get
            Return m_numero
        End Get
        Set(ByVal value As Integer)
            m_numero = value
        End Set
    End Property

    Public Property GUISA_Numero() As Integer
        Get
            Return m_guisa_numero
        End Get
        Set(ByVal value As Integer)
            m_guisa_numero = value
        End Set
    End Property
#End Region

#Region " Eventos "

#End Region

#Region " Metodos "
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


'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

''partial clasa 2

Partial Public Class EDIST_GuiasTodas

#Region " Campos "

    Private m_guiar_codigo As String
    Private m_pvent_id As Long
    Private m_docve_codigo As String
    Private m_orden_codigo As String
    Private m_almac_idorigen As Short
    Private m_pvent_idorigen As Long
    Private m_direc_iddestino As Short
    Private m_almac_iddestino As Short
    Private m_pvent_iddestino As Long
    Private m_tipos_codmotivotraslado As String
    Private m_tipos_codtipodocumento As String
    Private m_entid_codigocliente As String
    Private m_entid_codigotransportista As String
    Private m_entid_codigoconductor As String
    Private m_pedid_codigo As String
    Private m_vehic_id As Long
    Private m_guiar_serie As String
    Private m_guiar_numero As Integer
    Private m_guiar_direccorigen As String
    Private m_guiar_direccdestino As String
    Private m_guiar_descripcioncliente As String
    Private m_guiar_fechaemision As Date
    Private m_guiar_fechatraslado As Date
    Private m_guiar_descripciontransportista As String
    Private m_guiar_descripcionconductor As String
    Private m_guiar_licenciaconductor As String
    Private m_guiar_descripcionvehiculo As String
    Private m_guiar_certificadovehiculo As String
    Private m_guiar_totalpeso As Decimal
    Private m_guiar_observaciones As String
    Private m_guiar_impresa As Boolean
    Private m_guiar_estado As String
    Private m_guiar_salida As Boolean
    Private m_guiar_horasalida As Date
    Private m_guiar_horallegada As Date
    Private m_guiar_motivoanulacion As String
    Private m_tipos_codtipoorigen As String
    Private m_guiar_fechaanulacion As Date
    Private m_guiar_anuladocaja As Boolean
    Private m_guiar_stockdevuelto As Boolean
    Private m_guiar_fechaingreso As Date
    Private m_guiar_usrcrea As String
    Private m_guiar_feccrea As Date
    Private m_guiar_usrmod As String
    Private m_guiar_fecmod As Date
    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean
     Private m_usr_modificador As String


    Private m_hash As Hashtable
#End Region

#Region " Constructores "

    Public Sub New()

        Try
            Dim _obj As Object = ACELogistica.My.Resources.xmlDIST_GuiasRemision
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

    Public Property GUIAR_Codigo() As String
        Get
            Return m_guiar_codigo
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

    Public Property DOCVE_Codigo() As String
        Get
            Return m_docve_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docve_codigo) Then
                If Not m_docve_codigo.Equals(value) Then
                    m_docve_codigo = value
                    OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
                End If
            Else
                m_docve_codigo = value
                OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ORDEN_Codigo() As String
        Get
            Return m_orden_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_orden_codigo) Then
                If Not m_orden_codigo.Equals(value) Then
                    m_orden_codigo = value
                    OnORDEN_CodigoChanged(m_orden_codigo, EventArgs.Empty)
                End If
            Else
                m_orden_codigo = value
                OnORDEN_CodigoChanged(m_orden_codigo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ALMAC_IdOrigen() As Short
        Get
            Return m_almac_idorigen
        End Get
        Set(ByVal value As Short)
            If Not IsNothing(m_almac_idorigen) Then
                If Not m_almac_idorigen.Equals(value) Then
                    m_almac_idorigen = value
                    OnALMAC_IdOrigenChanged(m_almac_idorigen, EventArgs.Empty)
                End If
            Else
                m_almac_idorigen = value
                OnALMAC_IdOrigenChanged(m_almac_idorigen, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_IdOrigen() As Long
        Get
            Return m_pvent_idorigen
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_pvent_idorigen) Then
                If Not m_pvent_idorigen.Equals(value) Then
                    m_pvent_idorigen = value
                    OnPVENT_IdOrigenChanged(m_pvent_idorigen, EventArgs.Empty)
                End If
            Else
                m_pvent_idorigen = value
                OnPVENT_IdOrigenChanged(m_pvent_idorigen, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DIREC_IdDestino() As Short
        Get
            Return m_direc_iddestino
        End Get
        Set(ByVal value As Short)
            If Not IsNothing(m_direc_iddestino) Then
                If Not m_direc_iddestino.Equals(value) Then
                    m_direc_iddestino = value
                    OnDIREC_IdDestinoChanged(m_direc_iddestino, EventArgs.Empty)
                End If
            Else
                m_direc_iddestino = value
                OnDIREC_IdDestinoChanged(m_direc_iddestino, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ALMAC_IdDestino() As Short
        Get
            Return m_almac_iddestino
        End Get
        Set(ByVal value As Short)
            If Not IsNothing(m_almac_iddestino) Then
                If Not m_almac_iddestino.Equals(value) Then
                    m_almac_iddestino = value
                    OnALMAC_IdDestinoChanged(m_almac_iddestino, EventArgs.Empty)
                End If
            Else
                m_almac_iddestino = value
                OnALMAC_IdDestinoChanged(m_almac_iddestino, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_IdDestino() As Long
        Get
            Return m_pvent_iddestino
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_pvent_iddestino) Then
                If Not m_pvent_iddestino.Equals(value) Then
                    m_pvent_iddestino = value
                    OnPVENT_IdDestinoChanged(m_pvent_iddestino, EventArgs.Empty)
                End If
            Else
                m_pvent_iddestino = value
                OnPVENT_IdDestinoChanged(m_pvent_iddestino, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TIPOS_CodMotivoTraslado() As String
        Get
            Return m_tipos_codmotivotraslado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codmotivotraslado) Then
                If Not m_tipos_codmotivotraslado.Equals(value) Then
                    m_tipos_codmotivotraslado = value
                    OnTIPOS_CodMotivoTrasladoChanged(m_tipos_codmotivotraslado, EventArgs.Empty)
                End If
            Else
                m_tipos_codmotivotraslado = value
                OnTIPOS_CodMotivoTrasladoChanged(m_tipos_codmotivotraslado, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TIPOS_CodTipoDocumento() As String
        Get
            Return m_tipos_codtipodocumento
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codtipodocumento) Then
                If Not m_tipos_codtipodocumento.Equals(value) Then
                    m_tipos_codtipodocumento = value
                    OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
                End If
            Else
                m_tipos_codtipodocumento = value
                OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ENTID_CodigoCliente() As String
        Get
            Return m_entid_codigocliente
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_codigocliente) Then
                If Not m_entid_codigocliente.Equals(value) Then
                    m_entid_codigocliente = value
                    OnENTID_CodigoClienteChanged(m_entid_codigocliente, EventArgs.Empty)
                End If
            Else
                m_entid_codigocliente = value
                OnENTID_CodigoClienteChanged(m_entid_codigocliente, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ENTID_CodigoTransportista() As String
        Get
            Return m_entid_codigotransportista
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_codigotransportista) Then
                If Not m_entid_codigotransportista.Equals(value) Then
                    m_entid_codigotransportista = value
                    OnENTID_CodigoTransportistaChanged(m_entid_codigotransportista, EventArgs.Empty)
                End If
            Else
                m_entid_codigotransportista = value
                OnENTID_CodigoTransportistaChanged(m_entid_codigotransportista, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ENTID_CodigoConductor() As String
        Get
            Return m_entid_codigoconductor
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_codigoconductor) Then
                If Not m_entid_codigoconductor.Equals(value) Then
                    m_entid_codigoconductor = value
                    OnENTID_CodigoConductorChanged(m_entid_codigoconductor, EventArgs.Empty)
                End If
            Else
                m_entid_codigoconductor = value
                OnENTID_CodigoConductorChanged(m_entid_codigoconductor, EventArgs.Empty)
            End If
        End Set
    End Property

      Public Property Usuario_Modificador() As String
        Get
            Return m_usr_modificador
        End Get
        Set(ByVal value As String)
            m_usr_modificador = value
        End Set
    End Property

    Public Property PEDID_Codigo() As String
        Get
            Return m_pedid_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pedid_codigo) Then
                If Not m_pedid_codigo.Equals(value) Then
                    m_pedid_codigo = value
                    OnPEDID_CodigoChanged(m_pedid_codigo, EventArgs.Empty)
                End If
            Else
                m_pedid_codigo = value
                OnPEDID_CodigoChanged(m_pedid_codigo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property VEHIC_Id() As Long
        Get
            Return m_vehic_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_vehic_id) Then
                If Not m_vehic_id.Equals(value) Then
                    m_vehic_id = value
                    OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
                End If
            Else
                m_vehic_id = value
                OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_Serie() As String
        Get
            Return m_guiar_serie
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_serie) Then
                If Not m_guiar_serie.Equals(value) Then
                    m_guiar_serie = value
                    OnGUIAR_SerieChanged(m_guiar_serie, EventArgs.Empty)
                End If
            Else
                m_guiar_serie = value
                OnGUIAR_SerieChanged(m_guiar_serie, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_Numero() As Integer
        Get
            Return m_guiar_numero
        End Get
        Set(ByVal value As Integer)
            If Not IsNothing(m_guiar_numero) Then
                If Not m_guiar_numero.Equals(value) Then
                    m_guiar_numero = value
                    OnGUIAR_NumeroChanged(m_guiar_numero, EventArgs.Empty)
                End If
            Else
                m_guiar_numero = value
                OnGUIAR_NumeroChanged(m_guiar_numero, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_DireccOrigen() As String
        Get
            Return m_guiar_direccorigen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_direccorigen) Then
                If Not m_guiar_direccorigen.Equals(value) Then
                    m_guiar_direccorigen = value
                    OnGUIAR_DireccOrigenChanged(m_guiar_direccorigen, EventArgs.Empty)
                End If
            Else
                m_guiar_direccorigen = value
                OnGUIAR_DireccOrigenChanged(m_guiar_direccorigen, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_DireccDestino() As String
        Get
            Return m_guiar_direccdestino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_direccdestino) Then
                If Not m_guiar_direccdestino.Equals(value) Then
                    m_guiar_direccdestino = value
                    OnGUIAR_DireccDestinoChanged(m_guiar_direccdestino, EventArgs.Empty)
                End If
            Else
                m_guiar_direccdestino = value
                OnGUIAR_DireccDestinoChanged(m_guiar_direccdestino, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_Descripcioncliente() As String
        Get
            Return m_guiar_descripcioncliente
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_descripcioncliente) Then
                If Not m_guiar_descripcioncliente.Equals(value) Then
                    m_guiar_descripcioncliente = value
                    OnGUIAR_DescripcionclienteChanged(m_guiar_descripcioncliente, EventArgs.Empty)
                End If
            Else
                m_guiar_descripcioncliente = value
                OnGUIAR_DescripcionclienteChanged(m_guiar_descripcioncliente, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_FechaEmision() As Date
        Get
            Return m_guiar_fechaemision
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_guiar_fechaemision) Then
                If Not m_guiar_fechaemision.Equals(value) Then
                    m_guiar_fechaemision = value
                    OnGUIAR_FechaEmisionChanged(m_guiar_fechaemision, EventArgs.Empty)
                End If
            Else
                m_guiar_fechaemision = value
                OnGUIAR_FechaEmisionChanged(m_guiar_fechaemision, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_FechaTraslado() As Date
        Get
            Return m_guiar_fechatraslado
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_guiar_fechatraslado) Then
                If Not m_guiar_fechatraslado.Equals(value) Then
                    m_guiar_fechatraslado = value
                    OnGUIAR_FechaTrasladoChanged(m_guiar_fechatraslado, EventArgs.Empty)
                End If
            Else
                m_guiar_fechatraslado = value
                OnGUIAR_FechaTrasladoChanged(m_guiar_fechatraslado, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_DescripcionTransportista() As String
        Get
            Return m_guiar_descripciontransportista
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_descripciontransportista) Then
                If Not m_guiar_descripciontransportista.Equals(value) Then
                    m_guiar_descripciontransportista = value
                    OnGUIAR_DescripcionTransportistaChanged(m_guiar_descripciontransportista, EventArgs.Empty)
                End If
            Else
                m_guiar_descripciontransportista = value
                OnGUIAR_DescripcionTransportistaChanged(m_guiar_descripciontransportista, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_DescripcionConductor() As String
        Get
            Return m_guiar_descripcionconductor
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_descripcionconductor) Then
                If Not m_guiar_descripcionconductor.Equals(value) Then
                    m_guiar_descripcionconductor = value
                    OnGUIAR_DescripcionConductorChanged(m_guiar_descripcionconductor, EventArgs.Empty)
                End If
            Else
                m_guiar_descripcionconductor = value
                OnGUIAR_DescripcionConductorChanged(m_guiar_descripcionconductor, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_LicenciaConductor() As String
        Get
            Return m_guiar_licenciaconductor
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_licenciaconductor) Then
                If Not m_guiar_licenciaconductor.Equals(value) Then
                    m_guiar_licenciaconductor = value
                    OnGUIAR_LicenciaConductorChanged(m_guiar_licenciaconductor, EventArgs.Empty)
                End If
            Else
                m_guiar_licenciaconductor = value
                OnGUIAR_LicenciaConductorChanged(m_guiar_licenciaconductor, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_DescripcionVehiculo() As String
        Get
            Return m_guiar_descripcionvehiculo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_descripcionvehiculo) Then
                If Not m_guiar_descripcionvehiculo.Equals(value) Then
                    m_guiar_descripcionvehiculo = value
                    OnGUIAR_DescripcionVehiculoChanged(m_guiar_descripcionvehiculo, EventArgs.Empty)
                End If
            Else
                m_guiar_descripcionvehiculo = value
                OnGUIAR_DescripcionVehiculoChanged(m_guiar_descripcionvehiculo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_CertificadoVehiculo() As String
        Get
            Return m_guiar_certificadovehiculo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_certificadovehiculo) Then
                If Not m_guiar_certificadovehiculo.Equals(value) Then
                    m_guiar_certificadovehiculo = value
                    OnGUIAR_CertificadoVehiculoChanged(m_guiar_certificadovehiculo, EventArgs.Empty)
                End If
            Else
                m_guiar_certificadovehiculo = value
                OnGUIAR_CertificadoVehiculoChanged(m_guiar_certificadovehiculo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_TotalPeso() As Decimal
        Get
            Return m_guiar_totalpeso
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_guiar_totalpeso) Then
                If Not m_guiar_totalpeso.Equals(value) Then
                    m_guiar_totalpeso = value
                    OnGUIAR_TotalPesoChanged(m_guiar_totalpeso, EventArgs.Empty)
                End If
            Else
                m_guiar_totalpeso = value
                OnGUIAR_TotalPesoChanged(m_guiar_totalpeso, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_Observaciones() As String
        Get
            Return m_guiar_observaciones
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_observaciones) Then
                If Not m_guiar_observaciones.Equals(value) Then
                    m_guiar_observaciones = value
                    OnGUIAR_ObservacionesChanged(m_guiar_observaciones, EventArgs.Empty)
                End If
            Else
                m_guiar_observaciones = value
                OnGUIAR_ObservacionesChanged(m_guiar_observaciones, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_Impresa() As Boolean
        Get
            Return m_guiar_impresa
        End Get
        Set(ByVal value As Boolean)
            If Not m_guiar_impresa.Equals(value) Then
                m_guiar_impresa = value
                OnGUIAR_ImpresaChanged(m_guiar_impresa, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_Estado() As String
        Get
            Return m_guiar_estado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_estado) Then
                If Not m_guiar_estado.Equals(value) Then
                    m_guiar_estado = value
                    OnGUIAR_EstadoChanged(m_guiar_estado, EventArgs.Empty)
                End If
            Else
                m_guiar_estado = value
                OnGUIAR_EstadoChanged(m_guiar_estado, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_Salida() As Boolean
        Get
            Return m_guiar_salida
        End Get
        Set(ByVal value As Boolean)
            If Not m_guiar_salida.Equals(value) Then
                m_guiar_salida = value
                OnGUIAR_SalidaChanged(m_guiar_salida, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_HoraSalida() As Date
        Get
            Return m_guiar_horasalida
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_guiar_horasalida) Then
                If Not m_guiar_horasalida.Equals(value) Then
                    m_guiar_horasalida = value
                    OnGUIAR_HoraSalidaChanged(m_guiar_horasalida, EventArgs.Empty)
                End If
            Else
                m_guiar_horasalida = value
                OnGUIAR_HoraSalidaChanged(m_guiar_horasalida, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_HoraLlegada() As Date
        Get
            Return m_guiar_horallegada
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_guiar_horallegada) Then
                If Not m_guiar_horallegada.Equals(value) Then
                    m_guiar_horallegada = value
                    OnGUIAR_HoraLlegadaChanged(m_guiar_horallegada, EventArgs.Empty)
                End If
            Else
                m_guiar_horallegada = value
                OnGUIAR_HoraLlegadaChanged(m_guiar_horallegada, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_MotivoAnulacion() As String
        Get
            Return m_guiar_motivoanulacion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_guiar_motivoanulacion) Then
                If Not m_guiar_motivoanulacion.Equals(value) Then
                    m_guiar_motivoanulacion = value
                    OnGUIAR_MotivoAnulacionChanged(m_guiar_motivoanulacion, EventArgs.Empty)
                End If
            Else
                m_guiar_motivoanulacion = value
                OnGUIAR_MotivoAnulacionChanged(m_guiar_motivoanulacion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TIPOS_CodTipoOrigen() As String
        Get
            Return m_tipos_codtipoorigen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codtipoorigen) Then
                If Not m_tipos_codtipoorigen.Equals(value) Then
                    m_tipos_codtipoorigen = value
                    OnTIPOS_CodTipoOrigenChanged(m_tipos_codtipoorigen, EventArgs.Empty)
                End If
            Else
                m_tipos_codtipoorigen = value
                OnTIPOS_CodTipoOrigenChanged(m_tipos_codtipoorigen, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_FechaAnulacion() As Date
        Get
            Return m_guiar_fechaanulacion
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_guiar_fechaanulacion) Then
                If Not m_guiar_fechaanulacion.Equals(value) Then
                    m_guiar_fechaanulacion = value
                    OnGUIAR_FechaAnulacionChanged(m_guiar_fechaanulacion, EventArgs.Empty)
                End If
            Else
                m_guiar_fechaanulacion = value
                OnGUIAR_FechaAnulacionChanged(m_guiar_fechaanulacion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_AnuladoCaja() As Boolean
        Get
            Return m_guiar_anuladocaja
        End Get
        Set(ByVal value As Boolean)
            If Not m_guiar_anuladocaja.Equals(value) Then
                m_guiar_anuladocaja = value
                OnGUIAR_AnuladoCajaChanged(m_guiar_anuladocaja, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_StockDevuelto() As Boolean
        Get
            Return m_guiar_stockdevuelto
        End Get
        Set(ByVal value As Boolean)
            If Not m_guiar_stockdevuelto.Equals(value) Then
                m_guiar_stockdevuelto = value
                OnGUIAR_StockDevueltoChanged(m_guiar_stockdevuelto, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_FechaIngreso() As Date
        Get
            Return m_guiar_fechaingreso
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_guiar_fechaingreso) Then
                If Not m_guiar_fechaingreso.Equals(value) Then
                    m_guiar_fechaingreso = value
                    OnGUIAR_FechaIngresoChanged(m_guiar_fechaingreso, EventArgs.Empty)
                End If
            Else
                m_guiar_fechaingreso = value
                OnGUIAR_FechaIngresoChanged(m_guiar_fechaingreso, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property GUIAR_UsrCrea() As String
        Get
            Return m_guiar_usrcrea
        End Get
        Set(ByVal value As String)
            m_guiar_usrcrea = value
        End Set
    End Property

    Public Property GUIAR_FecCrea() As Date
        Get
            Return m_guiar_feccrea
        End Get
        Set(ByVal value As Date)
            m_guiar_feccrea = value
        End Set
    End Property

    Public Property GUIAR_UsrMod() As String
        Get
            Return m_guiar_usrmod
        End Get
        Set(ByVal value As String)
            m_guiar_usrmod = value
        End Set
    End Property

    Public Property GUIAR_FecMod() As Date
        Get
            Return m_guiar_fecmod
        End Get
        Set(ByVal value As Date)
            m_guiar_fecmod = value
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
            Return "DIST_GuiasRemision"
        End Get
    End Property

    Public Shared ReadOnly Property Esquema() As String
        Get
            Return "Logistica"
        End Get
    End Property

#End Region

#End Region

#Region " Eventos "

    Public Event GUIAR_CodigoChanged As EventHandler
    Public Event PVENT_IdChanged As EventHandler
    Public Event DOCVE_CodigoChanged As EventHandler
    Public Event ORDEN_CodigoChanged As EventHandler
    Public Event ALMAC_IdOrigenChanged As EventHandler
    Public Event PVENT_IdOrigenChanged As EventHandler
    Public Event DIREC_IdDestinoChanged As EventHandler
    Public Event ALMAC_IdDestinoChanged As EventHandler
    Public Event PVENT_IdDestinoChanged As EventHandler
    Public Event TIPOS_CodMotivoTrasladoChanged As EventHandler
    Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
    Public Event ENTID_CodigoClienteChanged As EventHandler
    Public Event ENTID_CodigoTransportistaChanged As EventHandler
    Public Event ENTID_CodigoConductorChanged As EventHandler
    Public Event PEDID_CodigoChanged As EventHandler
    Public Event VEHIC_IdChanged As EventHandler
    Public Event GUIAR_SerieChanged As EventHandler
    Public Event GUIAR_NumeroChanged As EventHandler
    Public Event GUIAR_DireccOrigenChanged As EventHandler
    Public Event GUIAR_DireccDestinoChanged As EventHandler
    Public Event GUIAR_DescripcionclienteChanged As EventHandler
    Public Event GUIAR_FechaEmisionChanged As EventHandler
    Public Event GUIAR_FechaTrasladoChanged As EventHandler
    Public Event GUIAR_DescripcionTransportistaChanged As EventHandler
    Public Event GUIAR_DescripcionConductorChanged As EventHandler
    Public Event GUIAR_LicenciaConductorChanged As EventHandler
    Public Event GUIAR_DescripcionVehiculoChanged As EventHandler
    Public Event GUIAR_CertificadoVehiculoChanged As EventHandler
    Public Event GUIAR_TotalPesoChanged As EventHandler
    Public Event GUIAR_ObservacionesChanged As EventHandler
    Public Event GUIAR_ImpresaChanged As EventHandler
    Public Event GUIAR_EstadoChanged As EventHandler
    Public Event GUIAR_SalidaChanged As EventHandler
    Public Event GUIAR_HoraSalidaChanged As EventHandler
    Public Event GUIAR_HoraLlegadaChanged As EventHandler
    Public Event GUIAR_MotivoAnulacionChanged As EventHandler
    Public Event TIPOS_CodTipoOrigenChanged As EventHandler
    Public Event GUIAR_FechaAnulacionChanged As EventHandler
    Public Event GUIAR_AnuladoCajaChanged As EventHandler
    Public Event GUIAR_StockDevueltoChanged As EventHandler
    Public Event GUIAR_FechaIngresoChanged As EventHandler

    Public Sub OnGUIAR_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_CodigoChanged(sender, e)
    End Sub

    Public Sub OnPVENT_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_IdChanged(sender, e)
    End Sub

    Public Sub OnDOCVE_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_CodigoChanged(sender, e)
    End Sub

    Public Sub OnORDEN_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ORDEN_CodigoChanged(sender, e)
    End Sub

    Public Sub OnALMAC_IdOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ALMAC_IdOrigenChanged(sender, e)
    End Sub

    Public Sub OnPVENT_IdOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_IdOrigenChanged(sender, e)
    End Sub

    Public Sub OnDIREC_IdDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DIREC_IdDestinoChanged(sender, e)
    End Sub

    Public Sub OnALMAC_IdDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ALMAC_IdDestinoChanged(sender, e)
    End Sub

    Public Sub OnPVENT_IdDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_IdDestinoChanged(sender, e)
    End Sub

    Public Sub OnTIPOS_CodMotivoTrasladoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodMotivoTrasladoChanged(sender, e)
    End Sub

    Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
    End Sub

    Public Sub OnENTID_CodigoClienteChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_CodigoClienteChanged(sender, e)
    End Sub

    Public Sub OnENTID_CodigoTransportistaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_CodigoTransportistaChanged(sender, e)
    End Sub

    Public Sub OnENTID_CodigoConductorChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_CodigoConductorChanged(sender, e)
    End Sub

    Public Sub OnPEDID_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PEDID_CodigoChanged(sender, e)
    End Sub

    Public Sub OnVEHIC_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent VEHIC_IdChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_SerieChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_SerieChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_NumeroChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_NumeroChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_DireccOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_DireccOrigenChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_DireccDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_DireccDestinoChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_DescripcionclienteChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_DescripcionclienteChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_FechaEmisionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_FechaEmisionChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_FechaTrasladoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_FechaTrasladoChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_DescripcionTransportistaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_DescripcionTransportistaChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_DescripcionConductorChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_DescripcionConductorChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_LicenciaConductorChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_LicenciaConductorChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_DescripcionVehiculoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_DescripcionVehiculoChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_CertificadoVehiculoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_CertificadoVehiculoChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_TotalPesoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_TotalPesoChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_ObservacionesChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_ObservacionesChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_ImpresaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_ImpresaChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_EstadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_EstadoChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_SalidaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_SalidaChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_HoraSalidaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_HoraSalidaChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_HoraLlegadaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_HoraLlegadaChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_MotivoAnulacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_MotivoAnulacionChanged(sender, e)
    End Sub

    Public Sub OnTIPOS_CodTipoOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoOrigenChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_FechaAnulacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_FechaAnulacionChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_AnuladoCajaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_AnuladoCajaChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_StockDevueltoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_StockDevueltoChanged(sender, e)
    End Sub

    Public Sub OnGUIAR_FechaIngresoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent GUIAR_FechaIngresoChanged(sender, e)
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




