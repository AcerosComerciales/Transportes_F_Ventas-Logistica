Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EABAS_DocsCompraDetalle

#Region " Campos "
	
	Private m_docco_codigo As String
	Private m_entid_codigoproveedor As String
	Private m_doccd_item As Short
	Private m_artic_codigo As String
	Private m_tipos_codtipodestino As String
	Private m_doccd_cantidad As Decimal
	Private m_doccd_pesounitario As Decimal
	Private m_doccd_subpeso As Decimal
    Private m_doccd_preciounitario As Decimal
    Private m_doccd_preciounitarioigv As Decimal
	Private m_doccd_subimportecompra As Decimal
	Private m_doccd_subimporteigv As Decimal
	Private m_doccd_subtotal As Decimal
	Private m_doccd_costo As Decimal
	Private m_doccd_costoigv As Decimal
	Private m_doccd_usrcrea As String
	Private m_doccd_feccrea As Date
	Private m_doccd_usrmod As String
	Private m_doccd_fecmod As Date

    Private m_docco_licitacion As Boolean

	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlABAS_DocsCompraDetalle
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
	
	Public Property DOCCO_Codigo() As String
		Get
			return m_docco_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docco_codigo) Then
				If Not m_docco_codigo.Equals(value) Then
					m_docco_codigo = value
					OnDOCCO_CodigoChanged(m_docco_codigo, EventArgs.Empty)
				End If
			Else
				m_docco_codigo = value
				OnDOCCO_CodigoChanged(m_docco_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodigoProveedor() As String
		Get
			return m_entid_codigoproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoproveedor) Then
				If Not m_entid_codigoproveedor.Equals(value) Then
					m_entid_codigoproveedor = value
					OnENTID_CodigoProveedorChanged(m_entid_codigoproveedor, EventArgs.Empty)
				End If
			Else
				m_entid_codigoproveedor = value
				OnENTID_CodigoProveedorChanged(m_entid_codigoproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCD_Item() As Short
		Get
			return m_doccd_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_doccd_item) Then
				If Not m_doccd_item.Equals(value) Then
					m_doccd_item = value
					OnDOCCD_ItemChanged(m_doccd_item, EventArgs.Empty)
				End If
			Else
				m_doccd_item = value
				OnDOCCD_ItemChanged(m_doccd_item, EventArgs.Empty)
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

	Public Property TIPOS_CodTipoDestino() As String
		Get
			return m_tipos_codtipodestino
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipodestino) Then
				If Not m_tipos_codtipodestino.Equals(value) Then
					m_tipos_codtipodestino = value
					OnTIPOS_CodTipoDestinoChanged(m_tipos_codtipodestino, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipodestino = value
				OnTIPOS_CodTipoDestinoChanged(m_tipos_codtipodestino, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCD_Cantidad() As Decimal
		Get
			return m_doccd_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_doccd_cantidad) Then
				If Not m_doccd_cantidad.Equals(value) Then
					m_doccd_cantidad = value
					OnDOCCD_CantidadChanged(m_doccd_cantidad, EventArgs.Empty)
				End If
			Else
				m_doccd_cantidad = value
				OnDOCCD_CantidadChanged(m_doccd_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCD_PesoUnitario() As Decimal
		Get
			return m_doccd_pesounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_doccd_pesounitario) Then
				If Not m_doccd_pesounitario.Equals(value) Then
					m_doccd_pesounitario = value
					OnDOCCD_PesoUnitarioChanged(m_doccd_pesounitario, EventArgs.Empty)
				End If
			Else
				m_doccd_pesounitario = value
				OnDOCCD_PesoUnitarioChanged(m_doccd_pesounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCD_SubPeso() As Decimal
		Get
			return m_doccd_subpeso
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_doccd_subpeso) Then
				If Not m_doccd_subpeso.Equals(value) Then
					m_doccd_subpeso = value
					OnDOCCD_SubPesoChanged(m_doccd_subpeso, EventArgs.Empty)
				End If
			Else
				m_doccd_subpeso = value
				OnDOCCD_SubPesoChanged(m_doccd_subpeso, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCD_PrecioUnitario() As Decimal
		Get
			return m_doccd_preciounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_doccd_preciounitario) Then
				If Not m_doccd_preciounitario.Equals(value) Then
					m_doccd_preciounitario = value
					OnDOCCD_PrecioUnitarioChanged(m_doccd_preciounitario, EventArgs.Empty)
				End If
			Else
				m_doccd_preciounitario = value
				OnDOCCD_PrecioUnitarioChanged(m_doccd_preciounitario, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property DOCCD_PrecioUnitarioIGV() As Decimal
        Get
            Return m_doccd_preciounitarioigv
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_doccd_preciounitarioigv) Then
                If Not m_doccd_preciounitarioigv.Equals(value) Then
                    m_doccd_preciounitarioigv = value
                    OnDOCCD_PrecioUnitarioChanged(m_doccd_preciounitarioigv, EventArgs.Empty)
                End If
            Else
                m_doccd_preciounitarioigv = value
                OnDOCCD_PrecioUnitarioChanged(m_doccd_preciounitarioigv, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property DOCCD_SubImporteCompra() As Decimal
		Get
			return m_doccd_subimportecompra
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_doccd_subimportecompra) Then
				If Not m_doccd_subimportecompra.Equals(value) Then
					m_doccd_subimportecompra = value
					OnDOCCD_SubImporteCompraChanged(m_doccd_subimportecompra, EventArgs.Empty)
				End If
			Else
				m_doccd_subimportecompra = value
				OnDOCCD_SubImporteCompraChanged(m_doccd_subimportecompra, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCD_SubImporteIgv() As Decimal
		Get
			return m_doccd_subimporteigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_doccd_subimporteigv) Then
				If Not m_doccd_subimporteigv.Equals(value) Then
					m_doccd_subimporteigv = value
					OnDOCCD_SubImporteIgvChanged(m_doccd_subimporteigv, EventArgs.Empty)
				End If
			Else
				m_doccd_subimporteigv = value
				OnDOCCD_SubImporteIgvChanged(m_doccd_subimporteigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCD_SubTotal() As Decimal
		Get
			return m_doccd_subtotal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_doccd_subtotal) Then
				If Not m_doccd_subtotal.Equals(value) Then
					m_doccd_subtotal = value
					OnDOCCD_SubTotalChanged(m_doccd_subtotal, EventArgs.Empty)
				End If
			Else
				m_doccd_subtotal = value
				OnDOCCD_SubTotalChanged(m_doccd_subtotal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCD_Costo() As Decimal
		Get
			return m_doccd_costo
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_doccd_costo) Then
				If Not m_doccd_costo.Equals(value) Then
					m_doccd_costo = value
					OnDOCCD_CostoChanged(m_doccd_costo, EventArgs.Empty)
				End If
			Else
				m_doccd_costo = value
				OnDOCCD_CostoChanged(m_doccd_costo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCD_CostoIGV() As Decimal
		Get
			return m_doccd_costoigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_doccd_costoigv) Then
				If Not m_doccd_costoigv.Equals(value) Then
					m_doccd_costoigv = value
					OnDOCCD_CostoIGVChanged(m_doccd_costoigv, EventArgs.Empty)
				End If
			Else
				m_doccd_costoigv = value
				OnDOCCD_CostoIGVChanged(m_doccd_costoigv, EventArgs.Empty)
			End If
		End Set
	End Property
     Public Property DOCCO_Licitacion() As Boolean
		Get
			return m_docco_licitacion
		End Get
		Set(ByVal value As Boolean)
			If Not m_docco_licitacion.Equals(value) Then
				m_docco_licitacion = value
				OnDOCCO_LicitacionChanged(m_docco_licitacion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCCD_UsrCrea() As String
		Get
			return m_doccd_usrcrea
		End Get
		Set(ByVal value As String)
			m_doccd_usrcrea = value
		End Set
	End Property

	Public Property DOCCD_FecCrea() As Date
		Get
			return m_doccd_feccrea
		End Get
		Set(ByVal value As Date)
			m_doccd_feccrea = value
		End Set
	End Property

	Public Property DOCCD_UsrMod() As String
		Get
			return m_doccd_usrmod
		End Get
		Set(ByVal value As String)
			m_doccd_usrmod = value
		End Set
	End Property

	Public Property DOCCD_FecMod() As Date
		Get
			return m_doccd_fecmod
		End Get
		Set(ByVal value As Date)
			m_doccd_fecmod = value
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
			Return "ABAS_DocsCompraDetalle"
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
	
	Public Event DOCCO_CodigoChanged As EventHandler
	Public Event ENTID_CodigoProveedorChanged As EventHandler
	Public Event DOCCD_ItemChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoDestinoChanged As EventHandler
	Public Event DOCCD_CantidadChanged As EventHandler
	Public Event DOCCD_PesoUnitarioChanged As EventHandler
	Public Event DOCCD_SubPesoChanged As EventHandler
    Public Event DOCCD_PrecioUnitarioChanged As EventHandler
    Public Event DOCCD_PrecioUnitarioIGVChanged As EventHandler
	Public Event DOCCD_SubImporteCompraChanged As EventHandler
	Public Event DOCCD_SubImporteIgvChanged As EventHandler
	Public Event DOCCD_SubTotalChanged As EventHandler
	Public Event DOCCD_CostoChanged As EventHandler
	Public Event DOCCD_CostoIGVChanged As EventHandler
    Public Event DOCCO_LicitacionChanged As EventHandler

	Public Sub OnDOCCO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoProveedorChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_ItemChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDestinoChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_CantidadChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_PesoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_PesoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_SubPesoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_SubPesoChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_PrecioUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_PrecioUnitarioChanged(sender, e)
    End Sub
    Public Sub OnDOCCD_PrecioUnitarioIGVChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCCD_PrecioUnitarioIGVChanged(sender, e)
    End Sub

	Public Sub OnDOCCD_SubImporteCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_SubImporteCompraChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_SubImporteIgvChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_SubImporteIgvChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_SubTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_SubTotalChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_CostoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_CostoChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_CostoIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_CostoIGVChanged(sender, e)
	End Sub
    Public Sub OnDOCCO_LicitacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCO_LicitacionChanged(sender, e)
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

