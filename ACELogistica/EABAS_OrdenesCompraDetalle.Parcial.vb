Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EABAS_OrdenesCompraDetalle

#Region " Campos "
	
	Private m_ordco_codigo As String
	Private m_ordcd_item As Short
	Private m_artic_codigo As String
	Private m_ordcd_cantidad As Decimal
	Private m_ordcd_preciounitario As Decimal
	Private m_ordcd_pesounitario As Decimal
	Private m_ordcd_subimportecompra As Decimal
	Private m_ordcd_subimporteigv As Decimal
	Private m_ordcd_subtotal As Decimal
	Private m_ordcd_usrcrea As String
	Private m_ordcd_feccrea As Date
	Private m_ordcd_usrmod As String
	Private m_ordcd_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlABAS_OrdenesCompraDetalle
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
	
	Public Property ORDCO_Codigo() As String
		Get
			return m_ordco_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_codigo) Then
				If Not m_ordco_codigo.Equals(value) Then
					m_ordco_codigo = value
					OnORDCO_CodigoChanged(m_ordco_codigo, EventArgs.Empty)
				End If
			Else
				m_ordco_codigo = value
				OnORDCO_CodigoChanged(m_ordco_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCD_Item() As Short
		Get
			return m_ordcd_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_ordcd_item) Then
				If Not m_ordcd_item.Equals(value) Then
					m_ordcd_item = value
					OnORDCD_ItemChanged(m_ordcd_item, EventArgs.Empty)
				End If
			Else
				m_ordcd_item = value
				OnORDCD_ItemChanged(m_ordcd_item, EventArgs.Empty)
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

	Public Property ORDCD_Cantidad() As Decimal
		Get
			return m_ordcd_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordcd_cantidad) Then
				If Not m_ordcd_cantidad.Equals(value) Then
					m_ordcd_cantidad = value
					OnORDCD_CantidadChanged(m_ordcd_cantidad, EventArgs.Empty)
				End If
			Else
				m_ordcd_cantidad = value
				OnORDCD_CantidadChanged(m_ordcd_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCD_PrecioUnitario() As Decimal
		Get
			return m_ordcd_preciounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordcd_preciounitario) Then
				If Not m_ordcd_preciounitario.Equals(value) Then
					m_ordcd_preciounitario = value
					OnORDCD_PrecioUnitarioChanged(m_ordcd_preciounitario, EventArgs.Empty)
				End If
			Else
				m_ordcd_preciounitario = value
				OnORDCD_PrecioUnitarioChanged(m_ordcd_preciounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCD_PesoUnitario() As Decimal
		Get
			return m_ordcd_pesounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordcd_pesounitario) Then
				If Not m_ordcd_pesounitario.Equals(value) Then
					m_ordcd_pesounitario = value
					OnORDCD_PesoUnitarioChanged(m_ordcd_pesounitario, EventArgs.Empty)
				End If
			Else
				m_ordcd_pesounitario = value
				OnORDCD_PesoUnitarioChanged(m_ordcd_pesounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCD_SubImporteCompra() As Decimal
		Get
			return m_ordcd_subimportecompra
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordcd_subimportecompra) Then
				If Not m_ordcd_subimportecompra.Equals(value) Then
					m_ordcd_subimportecompra = value
					OnORDCD_SubImporteCompraChanged(m_ordcd_subimportecompra, EventArgs.Empty)
				End If
			Else
				m_ordcd_subimportecompra = value
				OnORDCD_SubImporteCompraChanged(m_ordcd_subimportecompra, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCD_SubImporteIgv() As Decimal
		Get
			return m_ordcd_subimporteigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordcd_subimporteigv) Then
				If Not m_ordcd_subimporteigv.Equals(value) Then
					m_ordcd_subimporteigv = value
					OnORDCD_SubImporteIgvChanged(m_ordcd_subimporteigv, EventArgs.Empty)
				End If
			Else
				m_ordcd_subimporteigv = value
				OnORDCD_SubImporteIgvChanged(m_ordcd_subimporteigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCD_SubTotal() As Decimal
		Get
			return m_ordcd_subtotal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordcd_subtotal) Then
				If Not m_ordcd_subtotal.Equals(value) Then
					m_ordcd_subtotal = value
					OnORDCD_SubTotalChanged(m_ordcd_subtotal, EventArgs.Empty)
				End If
			Else
				m_ordcd_subtotal = value
				OnORDCD_SubTotalChanged(m_ordcd_subtotal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCD_UsrCrea() As String
		Get
			return m_ordcd_usrcrea
		End Get
		Set(ByVal value As String)
			m_ordcd_usrcrea = value
		End Set
	End Property

	Public Property ORDCD_FecCrea() As Date
		Get
			return m_ordcd_feccrea
		End Get
		Set(ByVal value As Date)
			m_ordcd_feccrea = value
		End Set
	End Property

	Public Property ORDCD_UsrMod() As String
		Get
			return m_ordcd_usrmod
		End Get
		Set(ByVal value As String)
			m_ordcd_usrmod = value
		End Set
	End Property

	Public Property ORDCD_FecMod() As Date
		Get
			return m_ordcd_fecmod
		End Get
		Set(ByVal value As Date)
			m_ordcd_fecmod = value
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
			Return "ABAS_OrdenesCompraDetalle"
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
	
	Public Event ORDCO_CodigoChanged As EventHandler
	Public Event ORDCD_ItemChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event ORDCD_CantidadChanged As EventHandler
	Public Event ORDCD_PrecioUnitarioChanged As EventHandler
	Public Event ORDCD_PesoUnitarioChanged As EventHandler
	Public Event ORDCD_SubImporteCompraChanged As EventHandler
	Public Event ORDCD_SubImporteIgvChanged As EventHandler
	Public Event ORDCD_SubTotalChanged As EventHandler

	Public Sub OnORDCO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnORDCD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCD_ItemChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnORDCD_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCD_CantidadChanged(sender, e)
	End Sub

	Public Sub OnORDCD_PrecioUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCD_PrecioUnitarioChanged(sender, e)
	End Sub

	Public Sub OnORDCD_PesoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCD_PesoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnORDCD_SubImporteCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCD_SubImporteCompraChanged(sender, e)
	End Sub

	Public Sub OnORDCD_SubImporteIgvChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCD_SubImporteIgvChanged(sender, e)
	End Sub

	Public Sub OnORDCD_SubTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCD_SubTotalChanged(sender, e)
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

