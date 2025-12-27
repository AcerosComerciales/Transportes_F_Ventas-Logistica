Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework
Imports ACEVentas

Partial Public Class EVENT_DocsVentaDetalle


#Region " Variables "
   Private m_artic_descripcion As String
   Private m_tipos_tipounidad As String
   Private m_tipos_unidadmedidacorta As String
   Private m_almac_descripcion As String

   Private m_diferencia As Double
   Private m_entregado As Double
   Private m_tipos_codunidadmedida As String

   Private m_articulos As EArticulos

   Private m_documento As String
   Private m_docve_fechadocumento As DateTime
   Private m_entid_codigocliente As String
   Private m_docve_descripcioncliente As String
   Private m_entid_codigo As String
   Private m_saldo As Decimal
   Private m_artic_detalle As String
   Private m_seleccionar As Boolean
   Private m_faltante As Decimal

   Private m_importesoles As Decimal
   Private m_importedolares As Decimal
   Private m_subpeso As Decimal
   Private m_utilidad As Decimal
   Private m_vendedor As String
   Private m_entid_codigovendedor As String

   Private m_linea As String
   Private m_sublinea As String

   Private m_anho As Short
    Private m_mes As Short
    Private m_estado As String

#End Region

#Region " Propiedades "
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

   Public Property TIPOS_UnidadMedida() As String
      Get
         Return m_tipos_tipounidad
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipounidad) Then
            If Not m_tipos_tipounidad.Equals(value) Then
               m_tipos_tipounidad = value
            End If
         Else
            m_tipos_tipounidad = value
         End If
      End Set
   End Property

   Public Property TIPOS_UnidadMedidaCorta() As String
      Get
         Return m_tipos_unidadmedidacorta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_unidadmedidacorta) Then
            If Not m_tipos_unidadmedidacorta.Equals(value) Then
               m_tipos_unidadmedidacorta = value
            End If
         Else
            m_tipos_unidadmedidacorta = value
         End If
      End Set
   End Property

   Public Property ALMAC_Descripcion() As String
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

   Public Property Diferencia() As Double
      Get
         Return m_diferencia
      End Get
      Set(ByVal value As Double)
         If Not IsNothing(m_diferencia) Then
            If Not m_diferencia.Equals(value) Then
               m_diferencia = value
            End If
         Else
            m_diferencia = value
         End If
      End Set
   End Property

   Public Property Entregado() As Double
      Get
         Return m_entregado
      End Get
      Set(ByVal value As Double)
         If Not IsNothing(m_entregado) Then
            If Not m_entregado.Equals(value) Then
               m_entregado = value
            End If
         Else
            m_entregado = value
         End If
      End Set
   End Property

   Public Property TIPOS_CodUnidadMedida() As String
      Get
         Return m_tipos_codunidadmedida
      End Get
      Set(ByVal value As String)
         m_tipos_codunidadmedida = value
      End Set
   End Property

   Public Property Articulo() As EArticulos
      Get
         Return m_articulos
      End Get
      Set(ByVal value As EArticulos)
         m_articulos = value
      End Set
   End Property

   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
      End Set
   End Property

   Public Property DOCVE_FechaDocumento() As DateTime
      Get
         Return m_docve_fechadocumento
      End Get
      Set(ByVal value As DateTime)
         m_docve_fechadocumento = value
      End Set
   End Property

   Public Property ENTID_CodigoCliente() As String
      Get
         Return m_entid_codigocliente
      End Get
      Set(ByVal value As String)
         m_entid_codigocliente = value
      End Set
   End Property

   Public Property DOCVE_DescripcionCliente() As String
      Get
         Return m_docve_descripcioncliente
      End Get
      Set(ByVal value As String)
         m_docve_descripcioncliente = value
      End Set
   End Property

   Public Property ENTID_Codigo() As String
      Get
         Return m_entid_codigo
      End Get
      Set(ByVal value As String)
         m_entid_codigo = value
      End Set
   End Property

   Public Property Saldo() As Decimal
      Get
         Return m_saldo
      End Get
      Set(ByVal value As Decimal)
         m_saldo = value
      End Set
   End Property

   Public Property ARTIC_Detalle() As String
      Get
         Return m_artic_detalle
      End Get
      Set(ByVal value As String)
         m_artic_detalle = value
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

   Public Property Faltante() As Decimal
      Get
         Return m_faltante
      End Get
      Set(ByVal value As Decimal)
         m_faltante = value
      End Set
   End Property

   Public Property ImporteSoles() As Decimal
      Get
         Return m_importesoles
      End Get
      Set(ByVal value As Decimal)
         m_importesoles = value
      End Set
   End Property

   Public Property ImporteDolares() As Decimal
      Get
         Return m_importedolares
      End Get
      Set(ByVal value As Decimal)
         m_importedolares = value
      End Set
   End Property

   Public Property SubPeso() As Decimal
      Get
         Return m_subpeso
      End Get
      Set(ByVal value As Decimal)
         m_subpeso = value
      End Set
   End Property



   Public Property Utilidad() As Decimal
      Get
         Return m_utilidad
      End Get
      Set(ByVal value As Decimal)
         m_utilidad = value
      End Set
   End Property
   
   Public Property Linea() As String
      Get
         Return m_linea
      End Get
      Set(ByVal value As String)
         m_linea = value
      End Set
   End Property

   Public Property SubLinea() As String
      Get
         Return m_sublinea
      End Get
      Set(ByVal value As String)
         m_sublinea = value
      End Set
   End Property

   Public Property Vendedor() As String
      Get
         Return m_vendedor
      End Get
      Set(ByVal value As String)
         m_vendedor = value
      End Set
   End Property

   Public Property ENTID_CodigoVendedor() As String
      Get
         Return m_entid_codigovendedor
      End Get
      Set(ByVal value As String)
         m_entid_codigovendedor = value
      End Set
   End Property


   Public Property Anho() As Short
      Get
         Return m_anho
      End Get
      Set(ByVal value As Short)
         m_anho = value
      End Set
   End Property

   Public Property Mes() As Short
      Get
         Return m_mes
      End Get
      Set(ByVal value As Short)
         m_mes = value
      End Set
   End Property

    Public Property DOCVE_Estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = value
        End Set
    End Property


#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region



End Class

Partial Public Class EVENT_DocsVentaDetalle

#Region " Campos "
	
	Private m_docve_codigo As String
	Private m_docvd_item As Short
	Private m_zonas_codigo As String
	Private m_lprec_id As Long
	Private m_almac_id As Short
	Private m_artic_codigo As String
	Private m_docvd_percepcion As Boolean
	Private m_docvd_costounitario As Decimal
	Private m_docvd_pesounitario As Decimal
	Private m_docvd_preciounitario As Decimal
	Private m_docvd_cantidad As Decimal
	Private m_docvd_unidad As String
	Private m_docvd_detalle As String
	Private m_docvd_saldo As Decimal
	Private m_docvd_subimporteventa As Decimal
	Private m_docvd_subimportepercepcion As Decimal
	Private m_docvd_subtotal As Decimal
	Private m_docve_codigoreferencia As String
	Private m_docvd_precventaoriginal As Decimal
	Private m_docvd_precioventa As Decimal
	Private m_docvd_porcentaje As Decimal
	Private m_docvd_fecemision As Date
	Private m_docvd_importe As Decimal
	Private m_docvd_montototal As Decimal
	Private m_docvd_estado As String
	Private m_docvd_precincigv As Decimal
	Private m_docvd_preciounitarioprecincigv As Decimal
	Private m_tmp As Decimal
	Private m_docvd_cantidaddevolver As Decimal
	Private m_artic_codigocambio As String
	Private m_docvd_cantidadcambio As Decimal
	Private m_docvd_codigocambio As Integer
	Private m_docvd_costounitariodolares As Decimal
	Private m_docvd_costounitariosoles As Decimal
	Private m_docvd_tipocambiocosto As Decimal
	Private m_docvd_usrcrea As String
	Private m_docvd_feccrea As Date
	Private m_docvd_usrmod As String
	Private m_docvd_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlVENT_DocsVentaDetalle
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

	Public Property DOCVD_Item() As Short
		Get
			return m_docvd_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_docvd_item) Then
				If Not m_docvd_item.Equals(value) Then
					m_docvd_item = value
					OnDOCVD_ItemChanged(m_docvd_item, EventArgs.Empty)
				End If
			Else
				m_docvd_item = value
				OnDOCVD_ItemChanged(m_docvd_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ZONAS_Codigo() As String
		Get
			return m_zonas_codigo
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

	Public Property LPREC_Id() As Long
		Get
			return m_lprec_id
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

	Public Property ARTIC_Codigo() As String
		Get
			return m_artic_codigo
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

	Public Property DOCVD_Percepcion() As Boolean
		Get
			return m_docvd_percepcion
		End Get
		Set(ByVal value As Boolean)
			If Not m_docvd_percepcion.Equals(value) Then
				m_docvd_percepcion = value
				OnDOCVD_PercepcionChanged(m_docvd_percepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CostoUnitario() As Decimal
		Get
			return m_docvd_costounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_costounitario) Then
				If Not m_docvd_costounitario.Equals(value) Then
					m_docvd_costounitario = value
					OnDOCVD_CostoUnitarioChanged(m_docvd_costounitario, EventArgs.Empty)
				End If
			Else
				m_docvd_costounitario = value
				OnDOCVD_CostoUnitarioChanged(m_docvd_costounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PesoUnitario() As Decimal
		Get
			return m_docvd_pesounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_pesounitario) Then
				If Not m_docvd_pesounitario.Equals(value) Then
					m_docvd_pesounitario = value
					OnDOCVD_PesoUnitarioChanged(m_docvd_pesounitario, EventArgs.Empty)
				End If
			Else
				m_docvd_pesounitario = value
				OnDOCVD_PesoUnitarioChanged(m_docvd_pesounitario, EventArgs.Empty)
			End If
		End Set
	End Property

     Public ReadOnly Property SubPeso_() As Decimal
        Get
            Return m_docvd_cantidad * m_docvd_pesounitario
        End Get
    End Property


	Public Property DOCVD_PrecioUnitario() As Decimal
		Get
			return m_docvd_preciounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_preciounitario) Then
				If Not m_docvd_preciounitario.Equals(value) Then
					m_docvd_preciounitario = value
					OnDOCVD_PrecioUnitarioChanged(m_docvd_preciounitario, EventArgs.Empty)
				End If
			Else
				m_docvd_preciounitario = value
				OnDOCVD_PrecioUnitarioChanged(m_docvd_preciounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Cantidad() As Decimal
		Get
			return m_docvd_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_cantidad) Then
				If Not m_docvd_cantidad.Equals(value) Then
					m_docvd_cantidad = value
					OnDOCVD_CantidadChanged(m_docvd_cantidad, EventArgs.Empty)
				End If
			Else
				m_docvd_cantidad = value
				OnDOCVD_CantidadChanged(m_docvd_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Unidad() As String
		Get
			return m_docvd_unidad
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docvd_unidad) Then
				If Not m_docvd_unidad.Equals(value) Then
					m_docvd_unidad = value
					OnDOCVD_UnidadChanged(m_docvd_unidad, EventArgs.Empty)
				End If
			Else
				m_docvd_unidad = value
				OnDOCVD_UnidadChanged(m_docvd_unidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Detalle() As String
		Get
			return m_docvd_detalle
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docvd_detalle) Then
				If Not m_docvd_detalle.Equals(value) Then
					m_docvd_detalle = value
					OnDOCVD_DetalleChanged(m_docvd_detalle, EventArgs.Empty)
				End If
			Else
				m_docvd_detalle = value
				OnDOCVD_DetalleChanged(m_docvd_detalle, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Saldo() As Decimal
		Get
			return m_docvd_saldo
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_saldo) Then
				If Not m_docvd_saldo.Equals(value) Then
					m_docvd_saldo = value
					OnDOCVD_SaldoChanged(m_docvd_saldo, EventArgs.Empty)
				End If
			Else
				m_docvd_saldo = value
				OnDOCVD_SaldoChanged(m_docvd_saldo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_SubImporteVenta() As Decimal
		Get
			return m_docvd_subimporteventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_subimporteventa) Then
				If Not m_docvd_subimporteventa.Equals(value) Then
					m_docvd_subimporteventa = value
					OnDOCVD_SubImporteVentaChanged(m_docvd_subimporteventa, EventArgs.Empty)
				End If
			Else
				m_docvd_subimporteventa = value
				OnDOCVD_SubImporteVentaChanged(m_docvd_subimporteventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_SubImportePercepcion() As Decimal
		Get
			return m_docvd_subimportepercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_subimportepercepcion) Then
				If Not m_docvd_subimportepercepcion.Equals(value) Then
					m_docvd_subimportepercepcion = value
					OnDOCVD_SubImportePercepcionChanged(m_docvd_subimportepercepcion, EventArgs.Empty)
				End If
			Else
				m_docvd_subimportepercepcion = value
				OnDOCVD_SubImportePercepcionChanged(m_docvd_subimportepercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_SubTotal() As Decimal
		Get
			return m_docvd_subtotal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_subtotal) Then
				If Not m_docvd_subtotal.Equals(value) Then
					m_docvd_subtotal = value
					OnDOCVD_SubTotalChanged(m_docvd_subtotal, EventArgs.Empty)
				End If
			Else
				m_docvd_subtotal = value
				OnDOCVD_SubTotalChanged(m_docvd_subtotal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_CodigoReferencia() As String
		Get
			return m_docve_codigoreferencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_codigoreferencia) Then
				If Not m_docve_codigoreferencia.Equals(value) Then
					m_docve_codigoreferencia = value
					OnDOCVE_CodigoReferenciaChanged(m_docve_codigoreferencia, EventArgs.Empty)
				End If
			Else
				m_docve_codigoreferencia = value
				OnDOCVE_CodigoReferenciaChanged(m_docve_codigoreferencia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PrecVentaOriginal() As Decimal
		Get
			return m_docvd_precventaoriginal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_precventaoriginal) Then
				If Not m_docvd_precventaoriginal.Equals(value) Then
					m_docvd_precventaoriginal = value
					OnDOCVD_PrecVentaOriginalChanged(m_docvd_precventaoriginal, EventArgs.Empty)
				End If
			Else
				m_docvd_precventaoriginal = value
				OnDOCVD_PrecVentaOriginalChanged(m_docvd_precventaoriginal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PrecioVenta() As Decimal
		Get
			return m_docvd_precioventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_precioventa) Then
				If Not m_docvd_precioventa.Equals(value) Then
					m_docvd_precioventa = value
					OnDOCVD_PrecioVentaChanged(m_docvd_precioventa, EventArgs.Empty)
				End If
			Else
				m_docvd_precioventa = value
				OnDOCVD_PrecioVentaChanged(m_docvd_precioventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Porcentaje() As Decimal
		Get
			return m_docvd_porcentaje
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_porcentaje) Then
				If Not m_docvd_porcentaje.Equals(value) Then
					m_docvd_porcentaje = value
					OnDOCVD_PorcentajeChanged(m_docvd_porcentaje, EventArgs.Empty)
				End If
			Else
				m_docvd_porcentaje = value
				OnDOCVD_PorcentajeChanged(m_docvd_porcentaje, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_FecEmision() As Date
		Get
			return m_docvd_fecemision
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docvd_fecemision) Then
				If Not m_docvd_fecemision.Equals(value) Then
					m_docvd_fecemision = value
					OnDOCVD_FecEmisionChanged(m_docvd_fecemision, EventArgs.Empty)
				End If
			Else
				m_docvd_fecemision = value
				OnDOCVD_FecEmisionChanged(m_docvd_fecemision, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Importe() As Decimal
		Get
			return m_docvd_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_importe) Then
				If Not m_docvd_importe.Equals(value) Then
					m_docvd_importe = value
					OnDOCVD_ImporteChanged(m_docvd_importe, EventArgs.Empty)
				End If
			Else
				m_docvd_importe = value
				OnDOCVD_ImporteChanged(m_docvd_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_MontoTotal() As Decimal
		Get
			return m_docvd_montototal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_montototal) Then
				If Not m_docvd_montototal.Equals(value) Then
					m_docvd_montototal = value
					OnDOCVD_MontoTotalChanged(m_docvd_montototal, EventArgs.Empty)
				End If
			Else
				m_docvd_montototal = value
				OnDOCVD_MontoTotalChanged(m_docvd_montototal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Estado() As String
		Get
			return m_docvd_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docvd_estado) Then
				If Not m_docvd_estado.Equals(value) Then
					m_docvd_estado = value
					OnDOCVD_EstadoChanged(m_docvd_estado, EventArgs.Empty)
				End If
			Else
				m_docvd_estado = value
				OnDOCVD_EstadoChanged(m_docvd_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PrecIncIGV() As Decimal
		Get
			return m_docvd_precincigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_precincigv) Then
				If Not m_docvd_precincigv.Equals(value) Then
					m_docvd_precincigv = value
					OnDOCVD_PrecIncIGVChanged(m_docvd_precincigv, EventArgs.Empty)
				End If
			Else
				m_docvd_precincigv = value
				OnDOCVD_PrecIncIGVChanged(m_docvd_precincigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PrecioUnitarioPrecIncIGV() As Decimal
		Get
			return m_docvd_preciounitarioprecincigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_preciounitarioprecincigv) Then
				If Not m_docvd_preciounitarioprecincigv.Equals(value) Then
					m_docvd_preciounitarioprecincigv = value
					OnDOCVD_PrecioUnitarioPrecIncIGVChanged(m_docvd_preciounitarioprecincigv, EventArgs.Empty)
				End If
			Else
				m_docvd_preciounitarioprecincigv = value
				OnDOCVD_PrecioUnitarioPrecIncIGVChanged(m_docvd_preciounitarioprecincigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TMP() As Decimal
		Get
			return m_tmp
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tmp) Then
				If Not m_tmp.Equals(value) Then
					m_tmp = value
					OnTMPChanged(m_tmp, EventArgs.Empty)
				End If
			Else
				m_tmp = value
				OnTMPChanged(m_tmp, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CantidadDevolver() As Decimal
		Get
			return m_docvd_cantidaddevolver
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_cantidaddevolver) Then
				If Not m_docvd_cantidaddevolver.Equals(value) Then
					m_docvd_cantidaddevolver = value
					OnDOCVD_CantidadDevolverChanged(m_docvd_cantidaddevolver, EventArgs.Empty)
				End If
			Else
				m_docvd_cantidaddevolver = value
				OnDOCVD_CantidadDevolverChanged(m_docvd_cantidaddevolver, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_CodigoCambio() As String
		Get
			return m_artic_codigocambio
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_codigocambio) Then
				If Not m_artic_codigocambio.Equals(value) Then
					m_artic_codigocambio = value
					OnARTIC_CodigoCambioChanged(m_artic_codigocambio, EventArgs.Empty)
				End If
			Else
				m_artic_codigocambio = value
				OnARTIC_CodigoCambioChanged(m_artic_codigocambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CantidadCambio() As Decimal
		Get
			return m_docvd_cantidadcambio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_cantidadcambio) Then
				If Not m_docvd_cantidadcambio.Equals(value) Then
					m_docvd_cantidadcambio = value
					OnDOCVD_CantidadCambioChanged(m_docvd_cantidadcambio, EventArgs.Empty)
				End If
			Else
				m_docvd_cantidadcambio = value
				OnDOCVD_CantidadCambioChanged(m_docvd_cantidadcambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CodigoCambio() As Integer
		Get
			return m_docvd_codigocambio
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_docvd_codigocambio) Then
				If Not m_docvd_codigocambio.Equals(value) Then
					m_docvd_codigocambio = value
					OnDOCVD_CodigoCambioChanged(m_docvd_codigocambio, EventArgs.Empty)
				End If
			Else
				m_docvd_codigocambio = value
				OnDOCVD_CodigoCambioChanged(m_docvd_codigocambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CostoUnitarioDolares() As Decimal
		Get
			return m_docvd_costounitariodolares
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_costounitariodolares) Then
				If Not m_docvd_costounitariodolares.Equals(value) Then
					m_docvd_costounitariodolares = value
					OnDOCVD_CostoUnitarioDolaresChanged(m_docvd_costounitariodolares, EventArgs.Empty)
				End If
			Else
				m_docvd_costounitariodolares = value
				OnDOCVD_CostoUnitarioDolaresChanged(m_docvd_costounitariodolares, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CostoUnitarioSoles() As Decimal
		Get
			return m_docvd_costounitariosoles
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_costounitariosoles) Then
				If Not m_docvd_costounitariosoles.Equals(value) Then
					m_docvd_costounitariosoles = value
					OnDOCVD_CostoUnitarioSolesChanged(m_docvd_costounitariosoles, EventArgs.Empty)
				End If
			Else
				m_docvd_costounitariosoles = value
				OnDOCVD_CostoUnitarioSolesChanged(m_docvd_costounitariosoles, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_TipoCambioCosto() As Decimal
		Get
			return m_docvd_tipocambiocosto
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_tipocambiocosto) Then
				If Not m_docvd_tipocambiocosto.Equals(value) Then
					m_docvd_tipocambiocosto = value
					OnDOCVD_TipoCambioCostoChanged(m_docvd_tipocambiocosto, EventArgs.Empty)
				End If
			Else
				m_docvd_tipocambiocosto = value
				OnDOCVD_TipoCambioCostoChanged(m_docvd_tipocambiocosto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_UsrCrea() As String
		Get
			return m_docvd_usrcrea
		End Get
		Set(ByVal value As String)
			m_docvd_usrcrea = value
		End Set
	End Property

	Public Property DOCVD_FecCrea() As Date
		Get
			return m_docvd_feccrea
		End Get
		Set(ByVal value As Date)
			m_docvd_feccrea = value
		End Set
	End Property

	Public Property DOCVD_UsrMod() As String
		Get
			return m_docvd_usrmod
		End Get
		Set(ByVal value As String)
			m_docvd_usrmod = value
		End Set
	End Property

	Public Property DOCVD_FecMod() As Date
		Get
			return m_docvd_fecmod
		End Get
		Set(ByVal value As Date)
			m_docvd_fecmod = value
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
			Return "VENT_DocsVentaDetalle"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Ventas"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event DOCVD_ItemChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event LPREC_IdChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event DOCVD_PercepcionChanged As EventHandler
	Public Event DOCVD_CostoUnitarioChanged As EventHandler
	Public Event DOCVD_PesoUnitarioChanged As EventHandler
	Public Event DOCVD_PrecioUnitarioChanged As EventHandler
	Public Event DOCVD_CantidadChanged As EventHandler
	Public Event DOCVD_UnidadChanged As EventHandler
	Public Event DOCVD_DetalleChanged As EventHandler
	Public Event DOCVD_SaldoChanged As EventHandler
	Public Event DOCVD_SubImporteVentaChanged As EventHandler
	Public Event DOCVD_SubImportePercepcionChanged As EventHandler
	Public Event DOCVD_SubTotalChanged As EventHandler
	Public Event DOCVE_CodigoReferenciaChanged As EventHandler
	Public Event DOCVD_PrecVentaOriginalChanged As EventHandler
	Public Event DOCVD_PrecioVentaChanged As EventHandler
	Public Event DOCVD_PorcentajeChanged As EventHandler
	Public Event DOCVD_FecEmisionChanged As EventHandler
	Public Event DOCVD_ImporteChanged As EventHandler
	Public Event DOCVD_MontoTotalChanged As EventHandler
	Public Event DOCVD_EstadoChanged As EventHandler
	Public Event DOCVD_PrecIncIGVChanged As EventHandler
	Public Event DOCVD_PrecioUnitarioPrecIncIGVChanged As EventHandler
	Public Event TMPChanged As EventHandler
	Public Event DOCVD_CantidadDevolverChanged As EventHandler
	Public Event ARTIC_CodigoCambioChanged As EventHandler
	Public Event DOCVD_CantidadCambioChanged As EventHandler
	Public Event DOCVD_CodigoCambioChanged As EventHandler
	Public Event DOCVD_CostoUnitarioDolaresChanged As EventHandler
	Public Event DOCVD_CostoUnitarioSolesChanged As EventHandler
	Public Event DOCVD_TipoCambioCostoChanged As EventHandler

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_ItemChanged(sender, e)
	End Sub

	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnLPREC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent LPREC_IdChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CostoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CostoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PesoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PesoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecioUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecioUnitarioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CantidadChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_UnidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_UnidadChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_DetalleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_DetalleChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_SaldoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_SaldoChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_SubImporteVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_SubImporteVentaChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_SubImportePercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_SubImportePercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_SubTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_SubTotalChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoReferenciaChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecVentaOriginalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecVentaOriginalChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecioVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecioVentaChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PorcentajeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PorcentajeChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_FecEmisionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_FecEmisionChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_ImporteChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_MontoTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_MontoTotalChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_EstadoChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecIncIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecIncIGVChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecioUnitarioPrecIncIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecioUnitarioPrecIncIGVChanged(sender, e)
	End Sub

	Public Sub OnTMPChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TMPChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CantidadDevolverChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CantidadDevolverChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoCambioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CantidadCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CantidadCambioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CodigoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CodigoCambioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CostoUnitarioDolaresChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CostoUnitarioDolaresChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CostoUnitarioSolesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CostoUnitarioSolesChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_TipoCambioCostoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_TipoCambioCostoChanged(sender, e)
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
