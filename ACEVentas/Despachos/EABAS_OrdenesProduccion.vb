Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Public Class EABAS_OrdenesProduccion


    #Region " Campos "
   Private m_listdist_ordenesdetalle As List(Of EABAS_OrdenesProduccionDetalle)

   Private m_seleccion As Boolean
   Private m_documento As String
   Private m_docventa As String
   Private m_almac_origen As String
    Private m_almac_destino As String
   Private m_pvent_origen As String
   Private m_pvent_destino As String
   Private m_entid_direccion As String
   Private m_codigo As String
    Private m_usuario As String
    Private m_usu_Modificador As String
    Private m_tipodoc as String
   Private m_peso As Decimal
   Private m_cliente As String
   Private m_orden_fechaentrega_old As DateTime
#End Region

#Region" Constructores "
	
#End Region

#Region " Propiedades "

   Public Property ListDIST_OrdenesDetalle() As List(Of EABAS_OrdenesProduccionDetalle)
      Get
         Return m_listdist_ordenesdetalle
      End Get
      Set(ByVal value As List(Of EABAS_OrdenesProduccionDetalle))
         m_listdist_ordenesdetalle = value
      End Set
   End Property

   Public Property TIPOS_TipoDocumento() As String
     Get
         Return m_tipodoc
      End Get
      Set(ByVal value As String)
         m_tipodoc = value
      End Set
   End Property

   Public Property Seleccion() As Boolean
      Get
         Return m_seleccion
      End Get
      Set(ByVal value As Boolean)
         m_seleccion = value
      End Set
   End Property

   Public Property PVENT_Destino() As String
      Get
         Return m_pvent_destino
      End Get
      Set(ByVal value As String)
         m_pvent_destino = value
      End Set
   End Property

   Public Property PVENT_Origen() As String
      Get
         Return m_pvent_origen
      End Get
      Set(ByVal value As String)
         m_pvent_origen = value
      End Set
   End Property

   Public Property ALMAC_Origen() As String
      Get
         Return m_almac_origen
      End Get
      Set(ByVal value As String)
         m_almac_origen = value
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

   Public Property DocVenta() As String
      Get
			return m_docventa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docventa) Then
				If Not m_docventa.Equals(value) Then
					m_docventa = value
					OnDocVentaChanged(m_docventa, EventArgs.Empty)
				End If
			Else
				m_docventa = value
				OnDocVentaChanged(m_docventa, EventArgs.Empty)
			End If
		End Set
   End Property

   Public Property Documento() As String
      Get
			return m_documento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_documento) Then
				If Not m_documento.Equals(value) Then
					m_documento = value
					OnDocumentoChanged(m_documento, EventArgs.Empty)
				End If
			Else
				m_documento = value
				OnDocumentoChanged(m_documento, EventArgs.Empty)
			End If
		End Set
   End Property

   Public Property ENTID_Direccion() As String
      Get
         Return m_entid_direccion
      End Get
      Set(ByVal value As String)
         m_entid_direccion = value
      End Set
    End Property

    Public Property Usuario_Modificador() As String
        Get
            Return m_usu_Modificador
        End Get
        Set(ByVal value As String)
            m_usu_Modificador = value
        End Set
    End Property



   Public Property Usuario() As String
      Get
         Return m_usuario
      End Get
      Set(ByVal value As String)
         m_usuario = value
      End Set
   End Property

   Public Property Codigo() As String
      Get
         Return m_codigo
      End Get
      Set(ByVal value As String)
         m_codigo = value
      End Set
   End Property

   Public ReadOnly Property ORDEN_Estado_Text() As String
      Get
         Select Case m_orden_estado
            Case Constantes.getEstado(Constantes.Estado.Ingresado)
               Return Constantes.Estado.Ingresado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Anulado)
               Return Constantes.Estado.Anulado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Confirmado)
               Return Constantes.Estado.Confirmado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Eliminado)
               Return Constantes.Estado.Eliminado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Terminado)
                Return Constantes.Estado.Terminado.ToString()
            Case Else
               Return Constantes.Estado.Ingresado.ToString()
         End Select
      End Get
   End Property

   Public Property Peso() As Decimal
      Get
         Return m_peso
      End Get
      Set(ByVal value As Decimal)
         m_peso = value
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

   Public Property ORDEN_FechaEntrega_Old() As DateTime
      Get
         Return m_orden_fechaentrega_old
      End Get
      Set(ByVal value As DateTime)
         m_orden_fechaentrega_old = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region


	#Region " Metodos "

#End Region


End Class

Partial Public Class EABAS_OrdenesProduccion

#Region " Campos "
	
	Private m_orden_codigo As String
	Private m_entid_codigocliente As String
    Private m_entid_codigoencargado As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtipoorden As String
    Private m_tipos_codtipoordenPro As String
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
    Private m_orden_descripcionencargado As String
	Private m_orden_observaciones As String
	Private m_orden_atendido As Boolean
	Private m_orden_impresa As Boolean
	Private m_orden_impresiones As Short
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
    Private m_pesoTotal as Decimal
    Private m_orden_cod_referencia as String

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlABAS_OrdenesProduccion
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

    Public Property ORDEN_CodReferencia() As String
		Get
			return m_orden_cod_referencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_cod_referencia) Then
				If Not m_orden_cod_referencia.Equals(value) Then
					m_orden_cod_referencia = value
					OnORDEN_CodReferenciaChanged(m_orden_cod_referencia, EventArgs.Empty)
				End If
			Else
				m_orden_cod_referencia = value
				OnORDEN_CodReferenciaChanged(m_orden_cod_referencia, EventArgs.Empty)
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
    Public Property ENTID_CodigoEncargado() As String
		Get
			return m_entid_codigoencargado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoencargado) Then
				If Not m_entid_codigoencargado.Equals(value) Then
					m_entid_codigoencargado = value
					OnENTID_CodigoEncargadoChanged(m_entid_codigoencargado, EventArgs.Empty)
				End If
			Else
				m_entid_codigoencargado = value
				OnENTID_CodigoEncargadoChanged(m_entid_codigoencargado, EventArgs.Empty)
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
    
    Public Property TIPOS_CodTipoOrdenPro() As String
		Get
			return m_tipos_codtipoordenPro
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipoordenPro) Then
				If Not m_tipos_codtipoordenPro.Equals(value) Then
					m_tipos_codtipoordenPro = value
					OnTIPOS_CodTipoOrdenProChanged(m_tipos_codtipoordenPro, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipoordenPro = value
				OnTIPOS_CodTipoOrdenProChanged(m_tipos_codtipoordenPro, EventArgs.Empty)
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

    Public Property ORDEN_PesoTotal() As Decimal   
		Get
			return m_pesoTotal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pesoTotal) Then
				If Not m_pesoTotal.Equals(value) Then
					m_pesoTotal = value
					OnORDEN_PesoTotalChanged(m_pesoTotal, EventArgs.Empty)
				End If
			Else
				m_pesoTotal = value
				OnORDEN_PesoTotalChanged(m_pesoTotal, EventArgs.Empty)
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
    
    Public Property ORDEN_DescripcionEncargado() As String
		Get
			return m_orden_descripcionencargado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_descripcionencargado) Then
				If Not m_orden_descripcionencargado.Equals(value) Then
					m_orden_descripcionencargado = value
					OnORDEN_DescripcionEncargadoChanged(m_orden_descripcionencargado, EventArgs.Empty)
				End If
			Else
				m_orden_descripcionencargado = value
				OnORDEN_DescripcionEncargadoChanged(m_orden_descripcionencargado, EventArgs.Empty)
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

	'Public Property ORDEN_PerGenGuia() As Boolean
	'	Get
	'		return m_orden_pergenguia
	'	End Get
	'	Set(ByVal value As Boolean)
	'		If Not m_orden_pergenguia.Equals(value) Then
	'			m_orden_pergenguia = value
	'			OnORDEN_PerGenGuiaChanged(m_orden_pergenguia, EventArgs.Empty)
	'		End If
	'	End Set
	'End Property

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
    Public Event ORDEN_CodReferenciaChanged as EventHandler
    Public Event DocVentaChanged as EventHandler
    Public Event DocumentoChanged AS EventHandler
	Public Event ENTID_CodigoClienteChanged As EventHandler
    Public Event ENTID_CodigoEncargadoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoOrdenChanged As EventHandler
    Public Event TIPOS_CodTipoOrdenProChanged As EventHandler
    Public Event DOCVE_CodigoChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
    Public Event ORDEN_PesoTotalChanged As EventHandler
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
    Public Event ORDEN_DescripcionEncargadoChanged As EventHandler
	Public Event ORDEN_ObservacionesChanged As EventHandler
	Public Event ORDEN_AtendidoChanged As EventHandler
	Public Event ORDEN_ImpresaChanged As EventHandler
	Public Event ORDEN_ImpresionesChanged As EventHandler
	Public Event ORDEN_EstadoChanged As EventHandler
	Public Event ORDEN_SerieChanged As EventHandler
	Public Event ORDEN_NumeroChanged As EventHandler
	Public Event ORDEN_PerGenGuiaChanged As EventHandler
	Public Event ORDEN_FechaEntregaChanged As EventHandler

	Public Sub OnORDEN_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_CodigoChanged(sender, e)
	End Sub
    
    Public Sub OnORDEN_CodReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_CodReferenciaChanged(sender, e)
	End Sub
    Public Sub OnDocVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DocVentaChanged(sender, e)
	End Sub
      Public Sub OnDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DocumentoChanged(sender, e)
	End Sub
    
	Public Sub OnENTID_CodigoClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoClienteChanged(sender, e)
	End Sub
    
    Public Sub OnENTID_CodigoEncargadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoEncargadoChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoOrdenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoOrdenChanged(sender, e)
	End Sub

    Public Sub OnTIPOS_CodTipoOrdenProChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoOrdenProChanged(sender, e)
	End Sub
    

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub
    
    Public Sub OnORDEN_PesoTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_PesoTotalChanged(sender, e)
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
    Public Sub OnORDEN_DescripcionEncargadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_DescripcionEncargadoChanged(sender, e)
	End Sub
    

	Public Sub OnORDEN_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_ObservacionesChanged(sender, e)
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
