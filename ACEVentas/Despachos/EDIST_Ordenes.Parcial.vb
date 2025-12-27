Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDIST_Ordenes

#Region " Campos "
	
	Private m_orden_codigo As String
	Private m_entid_codigocliente As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtipoorden As String
	Private m_docve_codigo As String
	Private m_pvent_id As Long
	Private m_almac_id As Short
	Private m_pvent_idorigen As Long
	Private m_almac_idorigen As Short
	Private m_pvent_iddestino As Long
	Private m_almac_iddestino As Short
	Private m_orden_id As Long
	Private m_orden_direccionorigen As String
	Private m_orden_direcciondestino As String
	Private m_orden_fechaingreso As Date
	Private m_orden_fechadocumento As Date
	Private m_orden_descripcioncliente As String
	Private m_orden_observaciones As String
	Private m_orden_atendido As Boolean
	Private m_orden_impresa As Boolean
	Private m_orden_impresiones As Short
    Private m_orden_usrimpresion As String
    Private m_orden_fecimpresion as date
	Private m_orden_estado As String
	Private m_orden_serie As String
	Private m_orden_numero As Integer
	Private m_orden_pergenguia As Boolean
	Private m_orden_fechaentrega As Date
	Private m_orden_usrcrearemoto As String
	Private m_orden_feccrearemoto As Date
	Private m_orden_usrcrea As String
	Private m_orden_feccrea As Date
	Private m_orden_usrmod As String
	Private m_orden_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean
    Private m_ordencodorigen as String
    Private m_ord_revisioncontrol As Boolean
    Private m_ord_revisadousr As String
    Private m_ord_totalpeso As Decimal
    Private m_ord_motivoanulacion as string
    Private m_ord_estentrega as string
    Private m_codorigen As String

    Private m_orden_fecrevisado2 As Date
    Private m_ord_revisioncontrol2 As Boolean
    Private m_ord_revisadousr2 As String

    Private m_orden_paseanulacion As Boolean
    Private m_orden_usrpaseanulacion As String
    Private m_orden_fechapaseanulacion As Date

    Private m_orden_ubigeodestino As String

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlDIST_Ordenes
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
	
	Public Property ORDEN_Codigo() As String
		Get
			return m_orden_codigo
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
   Public Property ORDEN_Codorigen() As String
		Get
			return m_ordencodorigen
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordencodorigen) Then
				If Not m_ordencodorigen.Equals(value) Then
					m_ordencodorigen = value
					OnORDEN_CodorigenChanged(m_ordencodorigen, EventArgs.Empty)
				End If
			Else
				m_ordencodorigen = value
				OnORDEN_CodorigenChanged(m_ordencodorigen, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodigoCliente() As String
		Get
			return m_entid_codigocliente
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

	Public Property TIPOS_CodTipoMoneda() As String
		Get
			return m_tipos_codtipomoneda
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipomoneda) Then
				If Not m_tipos_codtipomoneda.Equals(value) Then
					m_tipos_codtipomoneda = value
					OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipomoneda = value
				OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoOrden() As String
		Get
			return m_tipos_codtipoorden
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipoorden) Then
				If Not m_tipos_codtipoorden.Equals(value) Then
					m_tipos_codtipoorden = value
					OnTIPOS_CodTipoOrdenChanged(m_tipos_codtipoorden, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipoorden = value
				OnTIPOS_CodTipoOrdenChanged(m_tipos_codtipoorden, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Codigo() As String
		Get
			return m_docve_codigo
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

	Public Property ALMAC_Id() As Short
		Get
			return m_almac_id
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

	Public Property PVENT_IdOrigen() As Long
		Get
			return m_pvent_idorigen
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

	Public Property ALMAC_IdOrigen() As Short
		Get
			return m_almac_idorigen
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

	Public Property PVENT_IdDestino() As Long
		Get
			return m_pvent_iddestino
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

	Public Property ALMAC_IdDestino() As Short
		Get
			return m_almac_iddestino
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

	Public Property ORDEN_Id() As Long
		Get
			return m_orden_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_orden_id) Then
				If Not m_orden_id.Equals(value) Then
					m_orden_id = value
					OnORDEN_IdChanged(m_orden_id, EventArgs.Empty)
				End If
			Else
				m_orden_id = value
				OnORDEN_IdChanged(m_orden_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_DireccionOrigen() As String
		Get
			return m_orden_direccionorigen
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_direccionorigen) Then
				If Not m_orden_direccionorigen.Equals(value) Then
					m_orden_direccionorigen = value
					OnORDEN_DireccionOrigenChanged(m_orden_direccionorigen, EventArgs.Empty)
				End If
			Else
				m_orden_direccionorigen = value
				OnORDEN_DireccionOrigenChanged(m_orden_direccionorigen, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_DireccionDestino() As String
		Get
			return m_orden_direcciondestino
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_direcciondestino) Then
				If Not m_orden_direcciondestino.Equals(value) Then
					m_orden_direcciondestino = value
					OnORDEN_DireccionDestinoChanged(m_orden_direcciondestino, EventArgs.Empty)
				End If
			Else
				m_orden_direcciondestino = value
				OnORDEN_DireccionDestinoChanged(m_orden_direcciondestino, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_FechaIngreso() As Date
		Get
			return m_orden_fechaingreso
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_orden_fechaingreso) Then
				If Not m_orden_fechaingreso.Equals(value) Then
					m_orden_fechaingreso = value
					OnORDEN_FechaIngresoChanged(m_orden_fechaingreso, EventArgs.Empty)
				End If
			Else
				m_orden_fechaingreso = value
				OnORDEN_FechaIngresoChanged(m_orden_fechaingreso, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_FechaDocumento() As Date
		Get
			return m_orden_fechadocumento
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_orden_fechadocumento) Then
				If Not m_orden_fechadocumento.Equals(value) Then
					m_orden_fechadocumento = value
					OnORDEN_FechaDocumentoChanged(m_orden_fechadocumento, EventArgs.Empty)
				End If
			Else
				m_orden_fechadocumento = value
				OnORDEN_FechaDocumentoChanged(m_orden_fechadocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_DescripcionCliente() As String
		Get
			return m_orden_descripcioncliente
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_descripcioncliente) Then
				If Not m_orden_descripcioncliente.Equals(value) Then
					m_orden_descripcioncliente = value
					OnORDEN_DescripcionClienteChanged(m_orden_descripcioncliente, EventArgs.Empty)
				End If
			Else
				m_orden_descripcioncliente = value
				OnORDEN_DescripcionClienteChanged(m_orden_descripcioncliente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_Observaciones() As String
		Get
			return m_orden_observaciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_observaciones) Then
				If Not m_orden_observaciones.Equals(value) Then
					m_orden_observaciones = value
					OnORDEN_ObservacionesChanged(m_orden_observaciones, EventArgs.Empty)
				End If
			Else
				m_orden_observaciones = value
				OnORDEN_ObservacionesChanged(m_orden_observaciones, EventArgs.Empty)
			End If
		End Set
	End Property
    
    
    Public Property ORDEN_RevisadoControl() As Boolean
		Get
			return m_ord_revisioncontrol
		End Get
		Set(ByVal value As Boolean)
			If Not IsNothing(m_ord_revisioncontrol) Then
				If Not m_ord_revisioncontrol.Equals(value) Then
					m_ord_revisioncontrol = value
					OnORDEN_RevisadoControlChanged(m_ord_revisioncontrol, EventArgs.Empty)
				End If
			Else
				m_ord_revisioncontrol = value
				OnORDEN_RevisadoControlChanged(m_ord_revisioncontrol, EventArgs.Empty)
			End If
		End Set
    End Property

    Public Property ORDEN_RevisadoControl2() As Boolean
        Get
            Return m_ord_revisioncontrol2
        End Get
        Set(ByVal value As Boolean)
            If Not IsNothing(m_ord_revisioncontrol2) Then
                If Not m_ord_revisioncontrol2.Equals(value) Then
                    m_ord_revisioncontrol2 = value
                    OnORDEN_RevisadoControl2Changed(m_ord_revisioncontrol2, EventArgs.Empty)
                End If
            Else
                m_ord_revisioncontrol2 = value
                OnORDEN_RevisadoControl2Changed(m_ord_revisioncontrol2, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ORDEN_RevisadoUsr() As String
		Get
			return m_ord_revisadousr
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ord_revisadousr) Then
				If Not m_ord_revisadousr.Equals(value) Then
					m_ord_revisadousr = value
					OnORDEN_RevisadoUsrChanged(m_ord_revisadousr, EventArgs.Empty)
				End If
			Else
				m_ord_revisadousr = value
				OnORDEN_RevisadoUsrChanged(m_ord_revisadousr, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property ORDEN_RevisadoUsr2() As String
        Get
            Return m_ord_revisadousr2
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_ord_revisadousr2) Then
                If Not m_ord_revisadousr2.Equals(value) Then
                    m_ord_revisadousr2 = value
                    OnORDEN_RevisadoUsr2Changed(m_ord_revisadousr2, EventArgs.Empty)
                End If
            Else
                m_ord_revisadousr2 = value
                OnORDEN_RevisadoUsr2Changed(m_ord_revisadousr2, EventArgs.Empty)
            End If
        End Set
    End Property
    
    Public Property ORDEN_TotalPeso() As Decimal
		Get
			return m_ord_totalpeso
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ord_totalpeso) Then
				If Not m_ord_totalpeso.Equals(value) Then
					m_ord_totalpeso = value
					OnORDEN_TotalPesoChanged(m_ord_totalpeso, EventArgs.Empty)
				End If
			Else
				m_ord_totalpeso = value
				OnORDEN_TotalPesoChanged(m_ord_totalpeso, EventArgs.Empty)
			End If
		End Set
	End Property



	Public Property ORDEN_Atendido() As Boolean
		Get
			return m_orden_atendido
		End Get
		Set(ByVal value As Boolean)
			If Not m_orden_atendido.Equals(value) Then
				m_orden_atendido = value
				OnORDEN_AtendidoChanged(m_orden_atendido, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_Impresa() As Boolean
		Get
			return m_orden_impresa
		End Get
		Set(ByVal value As Boolean)
			If Not m_orden_impresa.Equals(value) Then
				m_orden_impresa = value
				OnORDEN_ImpresaChanged(m_orden_impresa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_Impresiones() As Short
		Get
			return m_orden_impresiones
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_orden_impresiones) Then
				If Not m_orden_impresiones.Equals(value) Then
					m_orden_impresiones = value
					OnORDEN_ImpresionesChanged(m_orden_impresiones, EventArgs.Empty)
				End If
			Else
				m_orden_impresiones = value
				OnORDEN_ImpresionesChanged(m_orden_impresiones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_Estado() As String
		Get
			return m_orden_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_estado) Then
				If Not m_orden_estado.Equals(value) Then
					m_orden_estado = value
					OnORDEN_EstadoChanged(m_orden_estado, EventArgs.Empty)
				End If
			Else
				m_orden_estado = value
				OnORDEN_EstadoChanged(m_orden_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_Serie() As String
		Get
			return m_orden_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_serie) Then
				If Not m_orden_serie.Equals(value) Then
					m_orden_serie = value
					OnORDEN_SerieChanged(m_orden_serie, EventArgs.Empty)
				End If
			Else
				m_orden_serie = value
				OnORDEN_SerieChanged(m_orden_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_Numero() As Integer
		Get
			return m_orden_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_orden_numero) Then
				If Not m_orden_numero.Equals(value) Then
					m_orden_numero = value
					OnORDEN_NumeroChanged(m_orden_numero, EventArgs.Empty)
				End If
			Else
				m_orden_numero = value
				OnORDEN_NumeroChanged(m_orden_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_PerGenGuia() As Boolean
		Get
			return m_orden_pergenguia
		End Get
		Set(ByVal value As Boolean)
			If Not m_orden_pergenguia.Equals(value) Then
				m_orden_pergenguia = value
				OnORDEN_PerGenGuiaChanged(m_orden_pergenguia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDEN_FechaEntrega() As Date
		Get
			return m_orden_fechaentrega
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_orden_fechaentrega) Then
				If Not m_orden_fechaentrega.Equals(value) Then
					m_orden_fechaentrega = value
					OnORDEN_FechaEntregaChanged(m_orden_fechaentrega, EventArgs.Empty)
				End If
			Else
				m_orden_fechaentrega = value
				OnORDEN_FechaEntregaChanged(m_orden_fechaentrega, EventArgs.Empty)
			End If
		End Set
	End Property
    
    Public Property ORDEN_UsrImpresion() As String
		Get
			return m_orden_usrimpresion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_usrimpresion) Then
				If Not m_orden_usrimpresion.Equals(value) Then
					m_orden_usrimpresion = value
					OnORDEN_UsrImpresionChanged(m_orden_usrimpresion, EventArgs.Empty)
				End If
			Else
				m_orden_usrimpresion = value
				OnORDEN_UsrImpresionChanged(m_orden_usrimpresion, EventArgs.Empty)
			End If
		End Set
	End Property
    
    Public Property ORDEN_FecImpresion() As date    
		Get
			return m_orden_fecimpresion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_orden_fecimpresion) Then
				If Not m_orden_fecimpresion.Equals(value) Then
					m_orden_fecimpresion = value
					OnORDEN_FecImpresionChanged(m_orden_fecimpresion, EventArgs.Empty)
				End If
			Else
				m_orden_fecimpresion = value
				OnORDEN_FecImpresionChanged(m_orden_fecimpresion, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property ORDEN_MotivoAnulacion() As String
		Get
			return m_ord_motivoanulacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ord_motivoanulacion) Then
				If Not m_ord_motivoanulacion.Equals(value) Then
					m_ord_motivoanulacion = value
					OnORDEN_MotivoAnulacionChanged(m_ord_motivoanulacion, EventArgs.Empty)
				End If
			Else
				m_ord_motivoanulacion = value
				OnORDEN_MotivoAnulacionChanged(m_ord_motivoanulacion, EventArgs.Empty)
			End If
		End Set
	End Property
    
    Public Property ORDEN_EstEntrega() As String
		Get
			return m_ord_estentrega
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ord_estentrega) Then
				If Not m_ord_estentrega.Equals(value) Then
					m_ord_estentrega = value
					OnORDEN_EstEntregaChanged(m_ord_estentrega, EventArgs.Empty)
				End If
			Else
				m_ord_estentrega = value
				OnORDEN_EstEntregaChanged(m_ord_estentrega, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property ORDEN_PaseAnulacion() As Boolean
        Get
            Return m_orden_paseanulacion
        End Get
        Set(ByVal value As Boolean)
            If Not m_orden_paseanulacion.Equals(value) Then
                m_orden_paseanulacion = value
                OnORDEN_PaseAnulacionChanged(m_orden_paseanulacion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ORDEN_UbigeoDestino() As String
        Get
            Return m_orden_ubigeodestino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_orden_ubigeodestino) Then
                If Not m_orden_ubigeodestino.Equals(value) Then
                    m_orden_ubigeodestino = value
                    OnORDEN_UbigeoDestinoChanged(m_orden_ubigeodestino, EventArgs.Empty)
                End If
            Else
                m_orden_ubigeodestino = value
                OnORDEN_UbigeoDestinoChanged(m_orden_ubigeodestino, EventArgs.Empty)
            End If
        End Set
    End Property


	Public Property ORDEN_UsrCreaRemoto() As String
		Get
			return m_orden_usrcrearemoto
		End Get
		Set(ByVal value As String)
			m_orden_usrcrearemoto = value
		End Set
	End Property

	Public Property ORDEN_FecCreaRemoto() As Date
		Get
			return m_orden_feccrearemoto
		End Get
		Set(ByVal value As Date)
			m_orden_feccrearemoto = value
		End Set
	End Property

	Public Property ORDEN_UsrCrea() As String
		Get
			return m_orden_usrcrea
		End Get
		Set(ByVal value As String)
			m_orden_usrcrea = value
		End Set
	End Property

	Public Property ORDEN_FecCrea() As Date
		Get
			return m_orden_feccrea
		End Get
		Set(ByVal value As Date)
			m_orden_feccrea = value
		End Set
	End Property

	Public Property ORDEN_UsrMod() As String
		Get
			return m_orden_usrmod
		End Get
		Set(ByVal value As String)
			m_orden_usrmod = value
		End Set
	End Property

	Public Property ORDEN_FecMod() As Date
		Get
			return m_orden_fecmod
		End Get
		Set(ByVal value As Date)
			m_orden_fecmod = value
		End Set
    End Property
    Public Property ORDEN_FecRevisado2() As Date
        Get
            Return m_orden_fecrevisado2
        End Get
        Set(ByVal value As Date)
            m_orden_fecrevisado2 = value
        End Set
    End Property
    Public Property cod_relacion() As String
		Get
			return m_codorigen
		End Get
		Set(ByVal value As String)
			m_codorigen = value
		End Set
    End Property
    Public Property ORDEN_UsrPaseAnulacion() As String
        Get
            Return m_orden_usrpaseanulacion
        End Get
        Set(ByVal value As String)
            m_orden_usrpaseanulacion = value
        End Set
    End Property

    Public Property ORDEN_FechaPaseAnulacion() As Date
        Get
            Return m_orden_fechapaseanulacion
        End Get
        Set(ByVal value As Date)
            m_orden_fechapaseanulacion = value
        End Set
    End Property
    

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
			Return "DIST_Ordenes"
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
	
	Public Event ORDEN_CodigoChanged As EventHandler
    Public Event ORDEN_CodorigenChanged as EventHandler
	Public Event ENTID_CodigoClienteChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoOrdenChanged As EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event PVENT_IdOrigenChanged As EventHandler
	Public Event ALMAC_IdOrigenChanged As EventHandler
	Public Event PVENT_IdDestinoChanged As EventHandler
	Public Event ALMAC_IdDestinoChanged As EventHandler
	Public Event ORDEN_IdChanged As EventHandler
	Public Event ORDEN_DireccionOrigenChanged As EventHandler
	Public Event ORDEN_DireccionDestinoChanged As EventHandler
	Public Event ORDEN_FechaIngresoChanged As EventHandler
	Public Event ORDEN_FechaDocumentoChanged As EventHandler
	Public Event ORDEN_DescripcionClienteChanged As EventHandler
	Public Event ORDEN_ObservacionesChanged As EventHandler
    Public Event ORDEN_RevisadoControlChanged As EventHandler
    Public Event ORDEN_RevisadoControl2Changed As EventHandler
    Public Event ORDEN_RevisadoUsrChanged As EventHandler
    Public Event ORDEN_RevisadoUsr2Changed As EventHandler
    Public Event ORDEN_TotalPesoChanged as EventHandler
	Public Event ORDEN_AtendidoChanged As EventHandler
	Public Event ORDEN_ImpresaChanged As EventHandler
	Public Event ORDEN_ImpresionesChanged As EventHandler
	Public Event ORDEN_EstadoChanged As EventHandler
	Public Event ORDEN_SerieChanged As EventHandler
	Public Event ORDEN_NumeroChanged As EventHandler
	Public Event ORDEN_PerGenGuiaChanged As EventHandler
	Public Event ORDEN_FechaEntregaChanged As EventHandler
    Public Event ORDEN_MotivoAnulacionChanged As EventHandler
    Public Event ORDEN_EstEntregaChanged as EventHandler
    pUBLIC Event ORDEN_UsrImpresionChanged as EventHandler
    Public Event ORDEN_FecImpresionChanged As EventHandler
    Public Event ORDEN_PaseAnulacionChanged As EventHandler
    Public Event ORDEN_UbigeoDestinoChanged As EventHandler

	Public Sub OnORDEN_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_CodigoChanged(sender, e)
	End Sub
    
  Public sub OnORDEN_CodorigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
		RaiseEvent ORDEN_CodorigenChanged(sender, e)
    End Sub

	Public Sub OnENTID_CodigoClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoClienteChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoOrdenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoOrdenChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdOrigenChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdOrigenChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdDestinoChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdDestinoChanged(sender, e)
	End Sub

	Public Sub OnORDEN_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_IdChanged(sender, e)
	End Sub

	Public Sub OnORDEN_DireccionOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_DireccionOrigenChanged(sender, e)
	End Sub

	Public Sub OnORDEN_DireccionDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_DireccionDestinoChanged(sender, e)
	End Sub

	Public Sub OnORDEN_FechaIngresoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_FechaIngresoChanged(sender, e)
	End Sub

	Public Sub OnORDEN_FechaDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_FechaDocumentoChanged(sender, e)
	End Sub

	Public Sub OnORDEN_DescripcionClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_DescripcionClienteChanged(sender, e)
	End Sub

	Public Sub OnORDEN_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_ObservacionesChanged(sender, e)
	End Sub

    
    Public Sub OnORDEN_RevisadoControl2Changed(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ORDEN_RevisadoControl2Changed(sender, e)
    End Sub
    Public Sub OnORDEN_RevisadoControlChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ORDEN_RevisadoControlChanged(sender, e)
    End Sub

    Public sub OnORDEN_RevisadoUsrChanged(ByVal sender As object,ByVal e As EventArgs)
        ActualizarInstancia()
		RaiseEvent ORDEN_RevisadoUsrChanged(sender, e)
    End Sub
    Public Sub OnORDEN_RevisadoUsr2Changed(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ORDEN_RevisadoUsr2Changed(sender, e)
    End Sub

    Public sub OnORDEN_TotalPesoChanged(ByVal sender As object,ByVal e As EventArgs)
        ActualizarInstancia()
		RaiseEvent ORDEN_TotalPesoChanged(sender, e)
    End Sub
    
	Public Sub OnORDEN_AtendidoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_AtendidoChanged(sender, e)
	End Sub

	Public Sub OnORDEN_ImpresaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_ImpresaChanged(sender, e)
	End Sub

	Public Sub OnORDEN_ImpresionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_ImpresionesChanged(sender, e)
	End Sub

	Public Sub OnORDEN_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_EstadoChanged(sender, e)
	End Sub

	Public Sub OnORDEN_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_SerieChanged(sender, e)
	End Sub

	Public Sub OnORDEN_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_NumeroChanged(sender, e)
	End Sub

	Public Sub OnORDEN_PerGenGuiaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_PerGenGuiaChanged(sender, e)
	End Sub

	Public Sub OnORDEN_FechaEntregaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_FechaEntregaChanged(sender, e)
	End Sub
    Public Sub OnORDEN_MotivoAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_MotivoAnulacionChanged(sender, e)
	End Sub
    Public Sub OnORDEN_EstEntregaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ORDEN_EstEntregaChanged(sender,e)
    End Sub

    Public Sub OnORDEN_UsrImpresionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_UsrImpresionChanged(sender, e)
	End Sub
    
     Public Sub OnORDEN_FecImpresionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_FecImpresionChanged(sender, e)
	End Sub
    
    Public Sub OnORDEN_PaseAnulacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ORDEN_PaseAnulacionChanged(sender, e)
    End Sub
    Public Sub OnORDEN_UbigeoDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ORDEN_UbigeoDestinoChanged(sender, e)
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

