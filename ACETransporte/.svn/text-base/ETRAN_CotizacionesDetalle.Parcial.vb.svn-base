Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_CotizacionesDetalle

#Region " Campos "
	
	Private m_cotiz_codigo As String
	Private m_cotdt_item As Short
	Private m_cotdt_unidad As String
	Private m_cotdt_detalle As String
	Private m_cotdt_percepcion As Boolean
	Private m_cotdt_costounitario As Decimal
	Private m_cotdt_pesounitario As Decimal
	Private m_cotdt_preciounitario As Decimal
	Private m_cotdt_preciounitarioprecincigv As Decimal
	Private m_cotdt_cantidad As Decimal
	Private m_cotdt_subimporteventa As Decimal
	Private m_cotdt_subimportepercepcion As Decimal
	Private m_cotdt_usrcrea As String
	Private m_cotdt_feccrea As Date
	Private m_cotdt_usrmod As String
	Private m_cotdt_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_CotizacionesDetalle
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
	
	Public Property COTIZ_Codigo() As String
		Get
			return m_cotiz_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_codigo) Then
				If Not m_cotiz_codigo.Equals(value) Then
					m_cotiz_codigo = value
					OnCOTIZ_CodigoChanged(m_cotiz_codigo, EventArgs.Empty)
				End If
			Else
				m_cotiz_codigo = value
				OnCOTIZ_CodigoChanged(m_cotiz_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_Item() As Short
		Get
			return m_cotdt_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_cotdt_item) Then
				If Not m_cotdt_item.Equals(value) Then
					m_cotdt_item = value
					OnCOTDT_ItemChanged(m_cotdt_item, EventArgs.Empty)
				End If
			Else
				m_cotdt_item = value
				OnCOTDT_ItemChanged(m_cotdt_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_Unidad() As String
		Get
			return m_cotdt_unidad
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotdt_unidad) Then
				If Not m_cotdt_unidad.Equals(value) Then
					m_cotdt_unidad = value
					OnCOTDT_UnidadChanged(m_cotdt_unidad, EventArgs.Empty)
				End If
			Else
				m_cotdt_unidad = value
				OnCOTDT_UnidadChanged(m_cotdt_unidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_Detalle() As String
		Get
			return m_cotdt_detalle
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotdt_detalle) Then
				If Not m_cotdt_detalle.Equals(value) Then
					m_cotdt_detalle = value
					OnCOTDT_DetalleChanged(m_cotdt_detalle, EventArgs.Empty)
				End If
			Else
				m_cotdt_detalle = value
				OnCOTDT_DetalleChanged(m_cotdt_detalle, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_Percepcion() As Boolean
		Get
			return m_cotdt_percepcion
		End Get
		Set(ByVal value As Boolean)
			If Not m_cotdt_percepcion.Equals(value) Then
				m_cotdt_percepcion = value
				OnCOTDT_PercepcionChanged(m_cotdt_percepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_CostoUnitario() As Decimal
		Get
			return m_cotdt_costounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotdt_costounitario) Then
				If Not m_cotdt_costounitario.Equals(value) Then
					m_cotdt_costounitario = value
					OnCOTDT_CostoUnitarioChanged(m_cotdt_costounitario, EventArgs.Empty)
				End If
			Else
				m_cotdt_costounitario = value
				OnCOTDT_CostoUnitarioChanged(m_cotdt_costounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_PesoUnitario() As Decimal
		Get
			return m_cotdt_pesounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotdt_pesounitario) Then
				If Not m_cotdt_pesounitario.Equals(value) Then
					m_cotdt_pesounitario = value
					OnCOTDT_PesoUnitarioChanged(m_cotdt_pesounitario, EventArgs.Empty)
				End If
			Else
				m_cotdt_pesounitario = value
				OnCOTDT_PesoUnitarioChanged(m_cotdt_pesounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_PrecioUnitario() As Decimal
		Get
			return m_cotdt_preciounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotdt_preciounitario) Then
				If Not m_cotdt_preciounitario.Equals(value) Then
					m_cotdt_preciounitario = value
					OnCOTDT_PrecioUnitarioChanged(m_cotdt_preciounitario, EventArgs.Empty)
				End If
			Else
				m_cotdt_preciounitario = value
				OnCOTDT_PrecioUnitarioChanged(m_cotdt_preciounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_PrecioUnitarioPrecIncIGV() As Decimal
		Get
			return m_cotdt_preciounitarioprecincigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotdt_preciounitarioprecincigv) Then
				If Not m_cotdt_preciounitarioprecincigv.Equals(value) Then
					m_cotdt_preciounitarioprecincigv = value
					OnCOTDT_PrecioUnitarioPrecIncIGVChanged(m_cotdt_preciounitarioprecincigv, EventArgs.Empty)
				End If
			Else
				m_cotdt_preciounitarioprecincigv = value
				OnCOTDT_PrecioUnitarioPrecIncIGVChanged(m_cotdt_preciounitarioprecincigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_Cantidad() As Decimal
		Get
			return m_cotdt_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotdt_cantidad) Then
				If Not m_cotdt_cantidad.Equals(value) Then
					m_cotdt_cantidad = value
					OnCOTDT_CantidadChanged(m_cotdt_cantidad, EventArgs.Empty)
				End If
			Else
				m_cotdt_cantidad = value
				OnCOTDT_CantidadChanged(m_cotdt_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_SubImporteVenta() As Decimal
		Get
			return m_cotdt_subimporteventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotdt_subimporteventa) Then
				If Not m_cotdt_subimporteventa.Equals(value) Then
					m_cotdt_subimporteventa = value
					OnCOTDT_SubImporteVentaChanged(m_cotdt_subimporteventa, EventArgs.Empty)
				End If
			Else
				m_cotdt_subimporteventa = value
				OnCOTDT_SubImporteVentaChanged(m_cotdt_subimporteventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_SubImportePercepcion() As Decimal
		Get
			return m_cotdt_subimportepercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotdt_subimportepercepcion) Then
				If Not m_cotdt_subimportepercepcion.Equals(value) Then
					m_cotdt_subimportepercepcion = value
					OnCOTDT_SubImportePercepcionChanged(m_cotdt_subimportepercepcion, EventArgs.Empty)
				End If
			Else
				m_cotdt_subimportepercepcion = value
				OnCOTDT_SubImportePercepcionChanged(m_cotdt_subimportepercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTDT_UsrCrea() As String
		Get
			return m_cotdt_usrcrea
		End Get
		Set(ByVal value As String)
			m_cotdt_usrcrea = value
		End Set
	End Property

	Public Property COTDT_FecCrea() As Date
		Get
			return m_cotdt_feccrea
		End Get
		Set(ByVal value As Date)
			m_cotdt_feccrea = value
		End Set
	End Property

	Public Property COTDT_UsrMod() As String
		Get
			return m_cotdt_usrmod
		End Get
		Set(ByVal value As String)
			m_cotdt_usrmod = value
		End Set
	End Property

	Public Property COTDT_FecMod() As Date
		Get
			return m_cotdt_fecmod
		End Get
		Set(ByVal value As Date)
			m_cotdt_fecmod = value
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
			Return "TRAN_CotizacionesDetalle"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event COTIZ_CodigoChanged As EventHandler
	Public Event COTDT_ItemChanged As EventHandler
	Public Event COTDT_UnidadChanged As EventHandler
	Public Event COTDT_DetalleChanged As EventHandler
	Public Event COTDT_PercepcionChanged As EventHandler
	Public Event COTDT_CostoUnitarioChanged As EventHandler
	Public Event COTDT_PesoUnitarioChanged As EventHandler
	Public Event COTDT_PrecioUnitarioChanged As EventHandler
	Public Event COTDT_PrecioUnitarioPrecIncIGVChanged As EventHandler
	Public Event COTDT_CantidadChanged As EventHandler
	Public Event COTDT_SubImporteVentaChanged As EventHandler
	Public Event COTDT_SubImportePercepcionChanged As EventHandler

	Public Sub OnCOTIZ_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_CodigoChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_ItemChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_UnidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_UnidadChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_DetalleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_DetalleChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_PercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_PercepcionChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_CostoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_CostoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_PesoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_PesoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_PrecioUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_PrecioUnitarioChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_PrecioUnitarioPrecIncIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_PrecioUnitarioPrecIncIGVChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_CantidadChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_SubImporteVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_SubImporteVentaChanged(sender, e)
	End Sub

	Public Sub OnCOTDT_SubImportePercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTDT_SubImportePercepcionChanged(sender, e)
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

