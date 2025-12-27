Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_ViajesGuiasRemision

#Region " Campos "
	
	Private m_viaje_id As Long
	Private m_gtran_codigo As String
	Private m_flete_id As Long
	Private m_tipos_codtipodocumento As String
	Private m_vegre_observacion As String
	Private m_vegre_condicion As String
	Private m_entid_codigo As String
	Private m_vegre_usrcrea As String
	Private m_vegre_feccrea As Date
	Private m_vegre_usrmod As String
	Private m_vegre_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_ViajesGuiasRemision
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

	Public Property GTRAN_Codigo() As String
		Get
			return m_gtran_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gtran_codigo) Then
				If Not m_gtran_codigo.Equals(value) Then
					m_gtran_codigo = value
					OnGTRAN_CodigoChanged(m_gtran_codigo, EventArgs.Empty)
				End If
			Else
				m_gtran_codigo = value
				OnGTRAN_CodigoChanged(m_gtran_codigo, EventArgs.Empty)
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

	Public Property VEGRE_Observacion() As String
		Get
			return m_vegre_observacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vegre_observacion) Then
				If Not m_vegre_observacion.Equals(value) Then
					m_vegre_observacion = value
					OnVEGRE_ObservacionChanged(m_vegre_observacion, EventArgs.Empty)
				End If
			Else
				m_vegre_observacion = value
				OnVEGRE_ObservacionChanged(m_vegre_observacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEGRE_Condicion() As String
		Get
			return m_vegre_condicion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vegre_condicion) Then
				If Not m_vegre_condicion.Equals(value) Then
					m_vegre_condicion = value
					OnVEGRE_CondicionChanged(m_vegre_condicion, EventArgs.Empty)
				End If
			Else
				m_vegre_condicion = value
				OnVEGRE_CondicionChanged(m_vegre_condicion, EventArgs.Empty)
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

	Public Property VEGRE_UsrCrea() As String
		Get
			return m_vegre_usrcrea
		End Get
		Set(ByVal value As String)
			m_vegre_usrcrea = value
		End Set
	End Property

	Public Property VEGRE_FecCrea() As Date
		Get
			return m_vegre_feccrea
		End Get
		Set(ByVal value As Date)
			m_vegre_feccrea = value
		End Set
	End Property

	Public Property VEGRE_UsrMod() As String
		Get
			return m_vegre_usrmod
		End Get
		Set(ByVal value As String)
			m_vegre_usrmod = value
		End Set
	End Property

	Public Property VEGRE_FecMod() As Date
		Get
			return m_vegre_fecmod
		End Get
		Set(ByVal value As Date)
			m_vegre_fecmod = value
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
			Return "TRAN_ViajesGuiasRemision"
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
	Public Event GTRAN_CodigoChanged As EventHandler
	Public Event FLETE_IdChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event VEGRE_ObservacionChanged As EventHandler
	Public Event VEGRE_CondicionChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler

	Public Sub OnVIAJE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VIAJE_IdChanged(sender, e)
	End Sub

	Public Sub OnGTRAN_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GTRAN_CodigoChanged(sender, e)
	End Sub

	Public Sub OnFLETE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent FLETE_IdChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnVEGRE_ObservacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEGRE_ObservacionChanged(sender, e)
	End Sub

	Public Sub OnVEGRE_CondicionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEGRE_CondicionChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
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

