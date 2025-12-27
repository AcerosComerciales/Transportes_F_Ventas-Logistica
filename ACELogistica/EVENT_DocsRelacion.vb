Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EVENT_DocsRelacion
    
#Region " Campos "
	
	Private m_docve_codigo As String
	Private m_docve_codreferencia As String
	Private m_docre_ncporcentaje As Decimal
	Private m_docre_ncimporte As Decimal
	Private m_docre_usrcrea As String
	Private m_docre_feccrea As Date
	Private m_docre_usrmod As String
	Private m_docre_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlVENT_DocsRelacion
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

	Public Property DOCVE_CodReferencia() As String
		Get
			return m_docve_codreferencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_codreferencia) Then
				If Not m_docve_codreferencia.Equals(value) Then
					m_docve_codreferencia = value
					OnDOCVE_CodReferenciaChanged(m_docve_codreferencia, EventArgs.Empty)
				End If
			Else
				m_docve_codreferencia = value
				OnDOCVE_CodReferenciaChanged(m_docve_codreferencia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCRE_NCPorcentaje() As Decimal
		Get
			return m_docre_ncporcentaje
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docre_ncporcentaje) Then
				If Not m_docre_ncporcentaje.Equals(value) Then
					m_docre_ncporcentaje = value
					OnDOCRE_NCPorcentajeChanged(m_docre_ncporcentaje, EventArgs.Empty)
				End If
			Else
				m_docre_ncporcentaje = value
				OnDOCRE_NCPorcentajeChanged(m_docre_ncporcentaje, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCRE_NCImporte() As Decimal
		Get
			return m_docre_ncimporte
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docre_ncimporte) Then
				If Not m_docre_ncimporte.Equals(value) Then
					m_docre_ncimporte = value
					OnDOCRE_NCImporteChanged(m_docre_ncimporte, EventArgs.Empty)
				End If
			Else
				m_docre_ncimporte = value
				OnDOCRE_NCImporteChanged(m_docre_ncimporte, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCRE_UsrCrea() As String
		Get
			return m_docre_usrcrea
		End Get
		Set(ByVal value As String)
			m_docre_usrcrea = value
		End Set
	End Property

	Public Property DOCRE_FecCrea() As Date
		Get
			return m_docre_feccrea
		End Get
		Set(ByVal value As Date)
			m_docre_feccrea = value
		End Set
	End Property

	Public Property DOCRE_UsrMod() As String
		Get
			return m_docre_usrmod
		End Get
		Set(ByVal value As String)
			m_docre_usrmod = value
		End Set
	End Property

	Public Property DOCRE_FecMod() As Date
		Get
			return m_docre_fecmod
		End Get
		Set(ByVal value As Date)
			m_docre_fecmod = value
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
			Return "VENT_DocsRelacion"
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
	Public Event DOCVE_CodReferenciaChanged As EventHandler
	Public Event DOCRE_NCPorcentajeChanged As EventHandler
	Public Event DOCRE_NCImporteChanged As EventHandler

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodReferenciaChanged(sender, e)
	End Sub

	Public Sub OnDOCRE_NCPorcentajeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCRE_NCPorcentajeChanged(sender, e)
	End Sub

	Public Sub OnDOCRE_NCImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCRE_NCImporteChanged(sender, e)
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
