Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDESP_GuiaRSalidas

#Region " Campos "
	
	Private m_pvent_id As Long
	Private m_salid_id As Long
	Private m_vehic_id As Long
	Private m_guiar_codigo As String
	Private m_guisa_horasalida As Date
	Private m_guisa_horallegada As Date
	Private m_guisa_destino As String
	Private m_guisa_numero As Short
	Private m_guisa_usrcrea As String
	Private m_guisa_feccrea As Date
	Private m_guisa_usrmod As String
	Private m_guisa_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlDESP_GuiaRSalidas
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

	Public Property SALID_Id() As Long
		Get
			return m_salid_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_salid_id) Then
				If Not m_salid_id.Equals(value) Then
					m_salid_id = value
					OnSALID_IdChanged(m_salid_id, EventArgs.Empty)
				End If
			Else
				m_salid_id = value
				OnSALID_IdChanged(m_salid_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_Id() As Long
		Get
			return m_vehic_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vehic_id) Then
				If Not m_vehic_id.Equals(value) Then
					m_vehic_id = value
					OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
				End If
			Else
				m_vehic_id = value
				OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUIAR_Codigo() As String
		Get
			return m_guiar_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_guiar_codigo) Then
				If Not m_guiar_codigo.Equals(value) Then
					m_guiar_codigo = value
					OnGUIAR_CodigoChanged(m_guiar_codigo, EventArgs.Empty)
				End If
			Else
				m_guiar_codigo = value
				OnGUIAR_CodigoChanged(m_guiar_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUISA_HoraSalida() As Date
		Get
			return m_guisa_horasalida
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_guisa_horasalida) Then
				If Not m_guisa_horasalida.Equals(value) Then
					m_guisa_horasalida = value
					OnGUISA_HoraSalidaChanged(m_guisa_horasalida, EventArgs.Empty)
				End If
			Else
				m_guisa_horasalida = value
				OnGUISA_HoraSalidaChanged(m_guisa_horasalida, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUISA_HoraLlegada() As Date
		Get
			return m_guisa_horallegada
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_guisa_horallegada) Then
				If Not m_guisa_horallegada.Equals(value) Then
					m_guisa_horallegada = value
					OnGUISA_HoraLlegadaChanged(m_guisa_horallegada, EventArgs.Empty)
				End If
			Else
				m_guisa_horallegada = value
				OnGUISA_HoraLlegadaChanged(m_guisa_horallegada, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUISA_Destino() As String
		Get
			return m_guisa_destino
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_guisa_destino) Then
				If Not m_guisa_destino.Equals(value) Then
					m_guisa_destino = value
					OnGUISA_DestinoChanged(m_guisa_destino, EventArgs.Empty)
				End If
			Else
				m_guisa_destino = value
				OnGUISA_DestinoChanged(m_guisa_destino, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUISA_Numero() As Short
		Get
			return m_guisa_numero
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_guisa_numero) Then
				If Not m_guisa_numero.Equals(value) Then
					m_guisa_numero = value
					OnGUISA_NumeroChanged(m_guisa_numero, EventArgs.Empty)
				End If
			Else
				m_guisa_numero = value
				OnGUISA_NumeroChanged(m_guisa_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUISA_UsrCrea() As String
		Get
			return m_guisa_usrcrea
		End Get
		Set(ByVal value As String)
			m_guisa_usrcrea = value
		End Set
	End Property

	Public Property GUISA_FecCrea() As Date
		Get
			return m_guisa_feccrea
		End Get
		Set(ByVal value As Date)
			m_guisa_feccrea = value
		End Set
	End Property

	Public Property GUISA_UsrMod() As String
		Get
			return m_guisa_usrmod
		End Get
		Set(ByVal value As String)
			m_guisa_usrmod = value
		End Set
	End Property

	Public Property GUISA_FecMod() As Date
		Get
			return m_guisa_fecmod
		End Get
		Set(ByVal value As Date)
			m_guisa_fecmod = value
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
			Return "DESP_GuiaRSalidas"
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
	
	Public Event PVENT_IdChanged As EventHandler
	Public Event SALID_IdChanged As EventHandler
	Public Event VEHIC_IdChanged As EventHandler
	Public Event GUIAR_CodigoChanged As EventHandler
	Public Event GUISA_HoraSalidaChanged As EventHandler
	Public Event GUISA_HoraLlegadaChanged As EventHandler
	Public Event GUISA_DestinoChanged As EventHandler
	Public Event GUISA_NumeroChanged As EventHandler

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnSALID_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SALID_IdChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
	End Sub

	Public Sub OnGUIAR_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUIAR_CodigoChanged(sender, e)
	End Sub

	Public Sub OnGUISA_HoraSalidaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUISA_HoraSalidaChanged(sender, e)
	End Sub

	Public Sub OnGUISA_HoraLlegadaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUISA_HoraLlegadaChanged(sender, e)
	End Sub

	Public Sub OnGUISA_DestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUISA_DestinoChanged(sender, e)
	End Sub

	Public Sub OnGUISA_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUISA_NumeroChanged(sender, e)
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

