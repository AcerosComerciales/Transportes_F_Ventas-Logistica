Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECONT_DocsPercepcionDetalle

#Region " Campos "
	
	Private m_docpe_codigo As String
	Private m_docpd_item As Short
	Private m_tipos_codtipodocumento As String
	Private m_docpd_seriedoc As String
	Private m_docpd_numerodoc As Decimal
	Private m_docpd_fecemision As Date
	Private m_docpd_precventaoriginal As Decimal
	Private m_docpd_precventa As Decimal
	Private m_docpd_porcpercepcion As Decimal
	Private m_docpd_importepercepcion As Decimal
	Private m_docpd_montototal As Decimal
	Private m_docpd_usrcrea As String
	Private m_docpd_feccrea As Date
	Private m_docpd_usrmod As String
	Private m_docpd_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlCONT_DocsPercepcionDetalle
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
	
	Public Property DOCPE_Codigo() As String
		Get
			return m_docpe_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docpe_codigo) Then
				If Not m_docpe_codigo.Equals(value) Then
					m_docpe_codigo = value
					OnDOCPE_CodigoChanged(m_docpe_codigo, EventArgs.Empty)
				End If
			Else
				m_docpe_codigo = value
				OnDOCPE_CodigoChanged(m_docpe_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPD_Item() As Short
		Get
			return m_docpd_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_docpd_item) Then
				If Not m_docpd_item.Equals(value) Then
					m_docpd_item = value
					OnDOCPD_ItemChanged(m_docpd_item, EventArgs.Empty)
				End If
			Else
				m_docpd_item = value
				OnDOCPD_ItemChanged(m_docpd_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoDocumento() As String
		Get
			return m_tipos_codtipodocumento
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

	Public Property DOCPD_SerieDoc() As String
		Get
			return m_docpd_seriedoc
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docpd_seriedoc) Then
				If Not m_docpd_seriedoc.Equals(value) Then
					m_docpd_seriedoc = value
					OnDOCPD_SerieDocChanged(m_docpd_seriedoc, EventArgs.Empty)
				End If
			Else
				m_docpd_seriedoc = value
				OnDOCPD_SerieDocChanged(m_docpd_seriedoc, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPD_NumeroDoc() As Decimal
		Get
			return m_docpd_numerodoc
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docpd_numerodoc) Then
				If Not m_docpd_numerodoc.Equals(value) Then
					m_docpd_numerodoc = value
					OnDOCPD_NumeroDocChanged(m_docpd_numerodoc, EventArgs.Empty)
				End If
			Else
				m_docpd_numerodoc = value
				OnDOCPD_NumeroDocChanged(m_docpd_numerodoc, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPD_FecEmision() As Date
		Get
			return m_docpd_fecemision
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docpd_fecemision) Then
				If Not m_docpd_fecemision.Equals(value) Then
					m_docpd_fecemision = value
					OnDOCPD_FecEmisionChanged(m_docpd_fecemision, EventArgs.Empty)
				End If
			Else
				m_docpd_fecemision = value
				OnDOCPD_FecEmisionChanged(m_docpd_fecemision, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPD_PrecVentaOriginal() As Decimal
		Get
			return m_docpd_precventaoriginal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docpd_precventaoriginal) Then
				If Not m_docpd_precventaoriginal.Equals(value) Then
					m_docpd_precventaoriginal = value
					OnDOCPD_PrecVentaOriginalChanged(m_docpd_precventaoriginal, EventArgs.Empty)
				End If
			Else
				m_docpd_precventaoriginal = value
				OnDOCPD_PrecVentaOriginalChanged(m_docpd_precventaoriginal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPD_PrecVenta() As Decimal
		Get
			return m_docpd_precventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docpd_precventa) Then
				If Not m_docpd_precventa.Equals(value) Then
					m_docpd_precventa = value
					OnDOCPD_PrecVentaChanged(m_docpd_precventa, EventArgs.Empty)
				End If
			Else
				m_docpd_precventa = value
				OnDOCPD_PrecVentaChanged(m_docpd_precventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPD_PorcPercepcion() As Decimal
		Get
			return m_docpd_porcpercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docpd_porcpercepcion) Then
				If Not m_docpd_porcpercepcion.Equals(value) Then
					m_docpd_porcpercepcion = value
					OnDOCPD_PorcPercepcionChanged(m_docpd_porcpercepcion, EventArgs.Empty)
				End If
			Else
				m_docpd_porcpercepcion = value
				OnDOCPD_PorcPercepcionChanged(m_docpd_porcpercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPD_ImportePercepcion() As Decimal
		Get
			return m_docpd_importepercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docpd_importepercepcion) Then
				If Not m_docpd_importepercepcion.Equals(value) Then
					m_docpd_importepercepcion = value
					OnDOCPD_ImportePercepcionChanged(m_docpd_importepercepcion, EventArgs.Empty)
				End If
			Else
				m_docpd_importepercepcion = value
				OnDOCPD_ImportePercepcionChanged(m_docpd_importepercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPD_MontoTotal() As Decimal
		Get
			return m_docpd_montototal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docpd_montototal) Then
				If Not m_docpd_montototal.Equals(value) Then
					m_docpd_montototal = value
					OnDOCPD_MontoTotalChanged(m_docpd_montototal, EventArgs.Empty)
				End If
			Else
				m_docpd_montototal = value
				OnDOCPD_MontoTotalChanged(m_docpd_montototal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPD_UsrCrea() As String
		Get
			return m_docpd_usrcrea
		End Get
		Set(ByVal value As String)
			m_docpd_usrcrea = value
		End Set
	End Property

	Public Property DOCPD_FecCrea() As Date
		Get
			return m_docpd_feccrea
		End Get
		Set(ByVal value As Date)
			m_docpd_feccrea = value
		End Set
	End Property

	Public Property DOCPD_UsrMod() As String
		Get
			return m_docpd_usrmod
		End Get
		Set(ByVal value As String)
			m_docpd_usrmod = value
		End Set
	End Property

	Public Property DOCPD_FecMod() As Date
		Get
			return m_docpd_fecmod
		End Get
		Set(ByVal value As Date)
			m_docpd_fecmod = value
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
			Return "CONT_DocsPercepcionDetalle"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Contabilidad"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event DOCPE_CodigoChanged As EventHandler
	Public Event DOCPD_ItemChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event DOCPD_SerieDocChanged As EventHandler
	Public Event DOCPD_NumeroDocChanged As EventHandler
	Public Event DOCPD_FecEmisionChanged As EventHandler
	Public Event DOCPD_PrecVentaOriginalChanged As EventHandler
	Public Event DOCPD_PrecVentaChanged As EventHandler
	Public Event DOCPD_PorcPercepcionChanged As EventHandler
	Public Event DOCPD_ImportePercepcionChanged As EventHandler
	Public Event DOCPD_MontoTotalChanged As EventHandler

	Public Sub OnDOCPE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDOCPD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPD_ItemChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnDOCPD_SerieDocChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPD_SerieDocChanged(sender, e)
	End Sub

	Public Sub OnDOCPD_NumeroDocChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPD_NumeroDocChanged(sender, e)
	End Sub

	Public Sub OnDOCPD_FecEmisionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPD_FecEmisionChanged(sender, e)
	End Sub

	Public Sub OnDOCPD_PrecVentaOriginalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPD_PrecVentaOriginalChanged(sender, e)
	End Sub

	Public Sub OnDOCPD_PrecVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPD_PrecVentaChanged(sender, e)
	End Sub

	Public Sub OnDOCPD_PorcPercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPD_PorcPercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCPD_ImportePercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPD_ImportePercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCPD_MontoTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPD_MontoTotalChanged(sender, e)
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

