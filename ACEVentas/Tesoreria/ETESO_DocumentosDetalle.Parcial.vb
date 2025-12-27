Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_DocumentosDetalle

#Region " Campos "
	
	Private m_docus_codigo As String
	Private m_entid_codigo As String
	Private m_dcdet_item As Short
	Private m_dcdet_cantidad As Decimal
	Private m_dcdet_descripcion As String
	Private m_dcdet_importe As Decimal
	Private m_dcdet_subimporte As Decimal
	Private m_dcdet_estado As String
	Private m_dcdet_usrcrea As String
	Private m_dcdet_feccrea As Date
	Private m_dcdet_usrmod As String
	Private m_dcdet_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_DocumentosDetalle
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
	
	Public Property DOCUS_Codigo() As String
		Get
			return m_docus_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docus_codigo) Then
				If Not m_docus_codigo.Equals(value) Then
					m_docus_codigo = value
					OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
				End If
			Else
				m_docus_codigo = value
				OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Codigo() As String
		Get
			return m_entid_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigo) Then
				If Not m_entid_codigo.Equals(value) Then
					m_entid_codigo = value
					OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
				End If
			Else
				m_entid_codigo = value
				OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DCDET_Item() As Short
		Get
			return m_dcdet_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_dcdet_item) Then
				If Not m_dcdet_item.Equals(value) Then
					m_dcdet_item = value
					OnDCDET_ItemChanged(m_dcdet_item, EventArgs.Empty)
				End If
			Else
				m_dcdet_item = value
				OnDCDET_ItemChanged(m_dcdet_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DCDET_Cantidad() As Decimal
		Get
			return m_dcdet_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_dcdet_cantidad) Then
				If Not m_dcdet_cantidad.Equals(value) Then
					m_dcdet_cantidad = value
					OnDCDET_CantidadChanged(m_dcdet_cantidad, EventArgs.Empty)
				End If
			Else
				m_dcdet_cantidad = value
				OnDCDET_CantidadChanged(m_dcdet_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DCDET_Descripcion() As String
		Get
			return m_dcdet_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dcdet_descripcion) Then
				If Not m_dcdet_descripcion.Equals(value) Then
					m_dcdet_descripcion = value
					OnDCDET_DescripcionChanged(m_dcdet_descripcion, EventArgs.Empty)
				End If
			Else
				m_dcdet_descripcion = value
				OnDCDET_DescripcionChanged(m_dcdet_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DCDET_Importe() As Decimal
		Get
			return m_dcdet_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_dcdet_importe) Then
				If Not m_dcdet_importe.Equals(value) Then
					m_dcdet_importe = value
					OnDCDET_ImporteChanged(m_dcdet_importe, EventArgs.Empty)
				End If
			Else
				m_dcdet_importe = value
				OnDCDET_ImporteChanged(m_dcdet_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DCDET_SubImporte() As Decimal
		Get
			return m_dcdet_subimporte
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_dcdet_subimporte) Then
				If Not m_dcdet_subimporte.Equals(value) Then
					m_dcdet_subimporte = value
					OnDCDET_SubImporteChanged(m_dcdet_subimporte, EventArgs.Empty)
				End If
			Else
				m_dcdet_subimporte = value
				OnDCDET_SubImporteChanged(m_dcdet_subimporte, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DCDET_Estado() As String
		Get
			return m_dcdet_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dcdet_estado) Then
				If Not m_dcdet_estado.Equals(value) Then
					m_dcdet_estado = value
					OnDCDET_EstadoChanged(m_dcdet_estado, EventArgs.Empty)
				End If
			Else
				m_dcdet_estado = value
				OnDCDET_EstadoChanged(m_dcdet_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DCDET_UsrCrea() As String
		Get
			return m_dcdet_usrcrea
		End Get
		Set(ByVal value As String)
			m_dcdet_usrcrea = value
		End Set
	End Property

	Public Property DCDET_FecCrea() As Date
		Get
			return m_dcdet_feccrea
		End Get
		Set(ByVal value As Date)
			m_dcdet_feccrea = value
		End Set
	End Property

	Public Property DCDET_UsrMod() As String
		Get
			return m_dcdet_usrmod
		End Get
		Set(ByVal value As String)
			m_dcdet_usrmod = value
		End Set
	End Property

	Public Property DCDET_FecMod() As Date
		Get
			return m_dcdet_fecmod
		End Get
		Set(ByVal value As Date)
			m_dcdet_fecmod = value
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
			Return "TESO_DocumentosDetalle"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Tesoreria"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event DOCUS_CodigoChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event DCDET_ItemChanged As EventHandler
	Public Event DCDET_CantidadChanged As EventHandler
	Public Event DCDET_DescripcionChanged As EventHandler
	Public Event DCDET_ImporteChanged As EventHandler
	Public Event DCDET_SubImporteChanged As EventHandler
	Public Event DCDET_EstadoChanged As EventHandler

	Public Sub OnDOCUS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCUS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDCDET_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DCDET_ItemChanged(sender, e)
	End Sub

	Public Sub OnDCDET_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DCDET_CantidadChanged(sender, e)
	End Sub

	Public Sub OnDCDET_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DCDET_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnDCDET_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DCDET_ImporteChanged(sender, e)
	End Sub

	Public Sub OnDCDET_SubImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DCDET_SubImporteChanged(sender, e)
	End Sub

	Public Sub OnDCDET_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DCDET_EstadoChanged(sender, e)
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

