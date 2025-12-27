Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_ViajesVentas

#Region " Campos "
	
	Private m_viaje_id As Long
	Private m_docve_codigo As String
	Private m_flete_id As Long
	Private m_vingr_id As Long
	Private m_viave_estado As String
	Private m_viave_usrcrea As String
	Private m_viave_feccrea As Date
	Private m_viave_usrmod As String
	Private m_viave_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_ViajesVentas
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
	
	Public Property VIAJE_Id() As Long
		Get
			return m_viaje_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_viaje_id) Then
				If Not m_viaje_id.Equals(value) Then
					m_viaje_id = value
					OnVIAJE_IdChanged(m_viaje_id, EventArgs.Empty)
				End If
			Else
				m_viaje_id = value
				OnVIAJE_IdChanged(m_viaje_id, EventArgs.Empty)
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

	Public Property FLETE_Id() As Long
		Get
			return m_flete_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_flete_id) Then
				If Not m_flete_id.Equals(value) Then
					m_flete_id = value
					OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
				End If
			Else
				m_flete_id = value
				OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VINGR_Id() As Long
		Get
			return m_vingr_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vingr_id) Then
				If Not m_vingr_id.Equals(value) Then
					m_vingr_id = value
					OnVINGR_IdChanged(m_vingr_id, EventArgs.Empty)
				End If
			Else
				m_vingr_id = value
				OnVINGR_IdChanged(m_vingr_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VIAVE_Estado() As String
		Get
			return m_viave_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_viave_estado) Then
				If Not m_viave_estado.Equals(value) Then
					m_viave_estado = value
					OnVIAVE_EstadoChanged(m_viave_estado, EventArgs.Empty)
				End If
			Else
				m_viave_estado = value
				OnVIAVE_EstadoChanged(m_viave_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VIAVE_UsrCrea() As String
		Get
			return m_viave_usrcrea
		End Get
		Set(ByVal value As String)
			m_viave_usrcrea = value
		End Set
	End Property

	Public Property VIAVE_FecCrea() As Date
		Get
			return m_viave_feccrea
		End Get
		Set(ByVal value As Date)
			m_viave_feccrea = value
		End Set
	End Property

	Public Property VIAVE_UsrMod() As String
		Get
			return m_viave_usrmod
		End Get
		Set(ByVal value As String)
			m_viave_usrmod = value
		End Set
	End Property

	Public Property VIAVE_FecMod() As Date
		Get
			return m_viave_fecmod
		End Get
		Set(ByVal value As Date)
			m_viave_fecmod = value
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
			Return "TRAN_ViajesVentas"
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
	
	Public Event VIAJE_IdChanged As EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event FLETE_IdChanged As EventHandler
	Public Event VINGR_IdChanged As EventHandler
	Public Event VIAVE_EstadoChanged As EventHandler

	Public Sub OnVIAJE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VIAJE_IdChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnFLETE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent FLETE_IdChanged(sender, e)
	End Sub

	Public Sub OnVINGR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VINGR_IdChanged(sender, e)
	End Sub

	Public Sub OnVIAVE_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VIAVE_EstadoChanged(sender, e)
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

