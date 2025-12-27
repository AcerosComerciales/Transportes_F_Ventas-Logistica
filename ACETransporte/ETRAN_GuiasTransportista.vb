Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACEVentas
Imports System.Text.RegularExpressions

Partial Public Class ETRAN_GuiasTransportista

#Region " Variables "
   Private m_list_edist_guiastrasportdetalle As List(Of ETRAN_GuiasTransportistaDetalles)
   Private m_dotra_estado As String

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum

   Private m_entid_transportista As String : Private m_entid_proveedor As String : Private m_entid_conductor As String
   Private m_salidadistrito As String : Private m_salidaprovincia As String : Private m_salidadepartamento As String
   Private m_llegadadistrito As String : Private m_llegadaprovincia As String : Private m_llegadadepartamento As String
   Private m_entid_condruc As String
   Private m_tipocomprobante As String
   Private m_numerocomprobante As String
   Private m_entid_tranRUC As String
   Private m_vehic_certificado As String
   Private m_ranfl_certificado As String
   Private m_condu_licencia As String
   Private m_tipos_tipodocumentocorta As String
   Private m_documento As String
   Private m_impresa As Boolean

   Private m_entid_razonsocialproveedor As String
   Private m_entid_razonsocialdestinatario As String
   Private m_entid_razonsocialtransportista As String
   Private m_entid_razonsocialconductor As String
   Private m_doccompra As String
   Private m_docco_fechadocumento As DateTime
   Private m_cantidad As Decimal
   Private m_cancomprada As Decimal
   Private m_entid_direccionproveedor As String

#End Region

#Region " Propiedades "
   Public Property TIPOS_TipoDocumentoCorta() As String
      Get
         Return m_tipos_tipodocumentocorta
      End Get
      Set(ByVal value As String)
         m_tipos_tipodocumentocorta = value
      End Set
   End Property
   Public Property ListETRAN_GuiasTransportistaDetalles() As List(Of ETRAN_GuiasTransportistaDetalles)
      Get
         Return m_list_edist_guiastrasportdetalle
      End Get
      Set(ByVal value As List(Of ETRAN_GuiasTransportistaDetalles))
         m_list_edist_guiastrasportdetalle = value
      End Set
   End Property

   Public Property ENTID_Transportista() As String
      Get
         Return m_entid_transportista
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_transportista) Then
            If Not m_entid_transportista.Equals(value) Then
               m_entid_transportista = value
            End If
         Else
            m_entid_transportista = value
         End If
      End Set
   End Property

   Public Property ENTID_Conductor() As String
      Get
         Return m_entid_conductor
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_conductor) Then
            If Not m_entid_conductor.Equals(value) Then
               m_entid_conductor = value
            End If
         Else
            m_entid_conductor = value
         End If
      End Set
   End Property

   Public Property SalidaDistrito() As String
      Get
         Return m_salidadistrito
      End Get
      Set(ByVal value As String)
         m_salidadistrito = value
      End Set
   End Property
   Public Property SalidaProvincia() As String
      Get
         Return m_salidaprovincia
      End Get
      Set(ByVal value As String)
         m_salidaprovincia = value
      End Set
   End Property
   Public Property SalidaDepartamento() As String
      Get
         Return m_salidadepartamento
      End Get
      Set(ByVal value As String)
         m_salidadepartamento = value
      End Set
   End Property

   Public Property LlegadaDistrito() As String
      Get
         Return m_llegadadistrito
      End Get
      Set(ByVal value As String)
         m_llegadadistrito = value
      End Set
   End Property
   Public Property LlegadaProvincia() As String
      Get
         Return m_llegadaprovincia
      End Get
      Set(ByVal value As String)
         m_llegadaprovincia = value
      End Set
   End Property
   Public Property LlegadaDepartamento() As String
      Get
         Return m_llegadadepartamento
      End Get
      Set(ByVal value As String)
         m_llegadadepartamento = value
      End Set
   End Property

   Public Property ENTID_CondRUC() As String
      Get
         Return m_entid_condruc
      End Get
      Set(ByVal value As String)
         m_entid_condruc = value
      End Set
   End Property

   Public Property ENTID_TranRUC() As String
      Get
         Return m_entid_tranRUC
      End Get
      Set(ByVal value As String)
         m_entid_tranRUC = value
      End Set
   End Property

   Public Property TipoComprobante() As String
      Get
         Return m_tipocomprobante
      End Get
      Set(ByVal value As String)
         m_tipocomprobante = value
      End Set
   End Property

   Public Property NumeroComprobante() As String
      Get
         If Not IsNothing(m_numerocomprobante) Then
            Return Regex.Replace(m_numerocomprobante, "^(\d{3})(\d{7})$", "$1-$2")
         Else
            Return ""
         End If
      End Get
      Set(ByVal value As String)
         m_numerocomprobante = value
      End Set
   End Property

   Public ReadOnly Property DocComprobante() As String
      Get
         Return String.Format("{0} {1}", m_tipocomprobante, NumeroComprobante)
      End Get
   End Property

   Public Property VEHIC_Certificado() As String
      Get
         Return m_vehic_certificado
      End Get
      Set(ByVal value As String)
         m_vehic_certificado = value
      End Set
   End Property

   Public Property RANFL_Certificado() As String
      Get
         Return m_ranfl_certificado
      End Get
      Set(ByVal value As String)
         m_ranfl_certificado = value
      End Set
   End Property

   Public ReadOnly Property Certificados() As String
      Get
         If IsNothing(m_ranfl_certificado) Then
            Return String.Format("{0}", m_vehic_certificado)
         Else
            Return String.Format("{0}/{1}", m_vehic_certificado, m_ranfl_certificado)
         End If
      End Get
   End Property

   Public Property CONDU_Licencia() As String
      Get
         Return m_condu_licencia
      End Get
      Set(ByVal value As String)
         m_condu_licencia = value
      End Set
   End Property

   Public ReadOnly Property NroGuia() As String
      Get
         Return String.Format("{0} {1}-{2}", m_tipos_tipodocumentocorta, m_gtran_serie, m_gtran_numero.ToString("0000000"))
      End Get
   End Property

   Public ReadOnly Property Documento() As String
      Get
         Return String.Format("{0}-{1}", m_gtran_serie, m_gtran_numero.ToString("0000000"))
      End Get
   End Property

   Public Property ENTID_Proveedor() As String
      Get
         Return m_entid_proveedor
      End Get
      Set(ByVal value As String)
         m_entid_proveedor = value
      End Set
   End Property

   Public ReadOnly Property GTRAN_Estado_Text() As String
      Get
         Select Case m_gtran_estado
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

   Public Property DocVenta() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
      End Set
   End Property

   Public Property DocCompra() As String
      Get
         Return m_doccompra
      End Get
      Set(ByVal value As String)
         m_doccompra = value
      End Set
   End Property


   Public Property Impresa() As Boolean
      Get
         Return m_impresa
      End Get
      Set(ByVal value As Boolean)
         m_impresa = value
      End Set
   End Property

   Public Property ENTID_RazonSocialProveedor() As String
      Get
         Return m_entid_razonsocialproveedor
      End Get
      Set(ByVal value As String)
         m_entid_razonsocialproveedor = value
      End Set
   End Property

   Public Property ENTID_RazonSocialDestinatario() As String
      Get
         Return m_entid_razonsocialdestinatario
      End Get
      Set(ByVal value As String)
         m_entid_razonsocialdestinatario = value
      End Set
   End Property

   Public Property ENTID_RazonSocialTransportista() As String
      Get
         Return m_entid_razonsocialtransportista
      End Get
      Set(ByVal value As String)
         m_entid_razonsocialtransportista = value
      End Set
   End Property

   Public Property ENTID_RazonSocialConductor() As String
      Get
         Return m_entid_razonsocialconductor
      End Get
      Set(ByVal value As String)
         m_entid_razonsocialconductor = value
      End Set
   End Property

   Public Property DOCCO_FechaDocumento() As DateTime
      Get
         Return m_docco_fechadocumento
      End Get
      Set(ByVal value As DateTime)
         m_docco_fechadocumento = value
      End Set
   End Property

   Public Property Cantidad() As Decimal
      Get
         Return m_cantidad
      End Get
      Set(ByVal value As Decimal)
         m_cantidad = value
      End Set
   End Property

   Public Property CanComprada() As Decimal
      Get
         Return m_cancomprada
      End Get
      Set(ByVal value As Decimal)
         m_cancomprada = value
      End Set
   End Property

   Public Property ENTID_DireccionProveedor() As String
      Get
         Return m_entid_direccionproveedor
      End Get
      Set(ByVal value As String)
         m_entid_direccionproveedor = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Shared Function getEstado(ByVal x_opcion As Estado)
      Select Case x_opcion
         Case Estado.Anulado : Return "X"
         Case Estado.Confirmado : Return "C"
         Case Estado.Eliminado : Return "E"
         Case Estado.Ingresado : Return "I"
         Case Else : Return "I"
      End Select
   End Function
#End Region

End Class
