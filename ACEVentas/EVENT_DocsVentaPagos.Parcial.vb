Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EVENT_DocsVentaPagos

#Region " Campos "
	
	Private m_pvent_id As Long
	Private m_dpago_id As Long
	Private m_docve_codigo As String
	Private m_dvepg_estado As String
	Private m_dvepg_usrcrea As String
	Private m_dvepg_feccrea As Date
	Private m_dvepg_usrmod As String
	Private m_dvepg_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlVENT_DocsVentaPagos
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

	Public Property DPAGO_Id() As Long
		Get
			return m_dpago_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_dpago_id) Then
				If Not m_dpago_id.Equals(value) Then
					m_dpago_id = value
					OnDPAGO_IdChanged(m_dpago_id, EventArgs.Empty)
				End If
			Else
				m_dpago_id = value
				OnDPAGO_IdChanged(m_dpago_id, EventArgs.Empty)
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

	Public Property DVEPG_Estado() As String
		Get
			return m_dvepg_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dvepg_estado) Then
				If Not m_dvepg_estado.Equals(value) Then
					m_dvepg_estado = value
					OnDVEPG_EstadoChanged(m_dvepg_estado, EventArgs.Empty)
				End If
			Else
				m_dvepg_estado = value
				OnDVEPG_EstadoChanged(m_dvepg_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DVEPG_UsrCrea() As String
		Get
			return m_dvepg_usrcrea
		End Get
		Set(ByVal value As String)
			m_dvepg_usrcrea = value
		End Set
	End Property

	Public Property DVEPG_FecCrea() As Date
		Get
			return m_dvepg_feccrea
		End Get
		Set(ByVal value As Date)
			m_dvepg_feccrea = value
		End Set
	End Property

	Public Property DVEPG_UsrMod() As String
		Get
			return m_dvepg_usrmod
		End Get
		Set(ByVal value As String)
			m_dvepg_usrmod = value
		End Set
	End Property

	Public Property DVEPG_FecMod() As Date
		Get
			return m_dvepg_fecmod
		End Get
		Set(ByVal value As Date)
			m_dvepg_fecmod = value
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
			Return "VENT_DocsVentaPagos"
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
	
	Public Event PVENT_IdChanged As EventHandler
	Public Event DPAGO_IdChanged As EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event DVEPG_EstadoChanged As EventHandler

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_IdChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDVEPG_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DVEPG_EstadoChanged(sender, e)
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

