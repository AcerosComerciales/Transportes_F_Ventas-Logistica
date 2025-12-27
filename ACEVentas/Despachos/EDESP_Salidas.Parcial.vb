Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDESP_Salidas

#Region " Campos "
	
	Private m_pvent_id As Long
	Private m_salid_id As Long
	Private m_vehic_id As Long
	Private m_entid_codigoconductor As String
	Private m_salid_horasalida As Date
	Private m_salid_horallegada As Date
	Private m_salid_peso As Decimal
	Private m_salid_usrcrea As String
	Private m_salid_feccrea As Date
	Private m_salid_usrmod As String
	Private m_salid_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlDESP_Salidas
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

	Public Property ENTID_CodigoConductor() As String
		Get
			return m_entid_codigoconductor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoconductor) Then
				If Not m_entid_codigoconductor.Equals(value) Then
					m_entid_codigoconductor = value
					OnENTID_CodigoConductorChanged(m_entid_codigoconductor, EventArgs.Empty)
				End If
			Else
				m_entid_codigoconductor = value
				OnENTID_CodigoConductorChanged(m_entid_codigoconductor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SALID_HoraSalida() As Date
		Get
			return m_salid_horasalida
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_salid_horasalida) Then
				If Not m_salid_horasalida.Equals(value) Then
					m_salid_horasalida = value
					OnSALID_HoraSalidaChanged(m_salid_horasalida, EventArgs.Empty)
				End If
			Else
				m_salid_horasalida = value
				OnSALID_HoraSalidaChanged(m_salid_horasalida, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SALID_HoraLlegada() As Date
		Get
			return m_salid_horallegada
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_salid_horallegada) Then
				If Not m_salid_horallegada.Equals(value) Then
					m_salid_horallegada = value
					OnSALID_HoraLlegadaChanged(m_salid_horallegada, EventArgs.Empty)
				End If
			Else
				m_salid_horallegada = value
				OnSALID_HoraLlegadaChanged(m_salid_horallegada, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SALID_Peso() As Decimal
		Get
			return m_salid_peso
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_salid_peso) Then
				If Not m_salid_peso.Equals(value) Then
					m_salid_peso = value
					OnSALID_PesoChanged(m_salid_peso, EventArgs.Empty)
				End If
			Else
				m_salid_peso = value
				OnSALID_PesoChanged(m_salid_peso, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SALID_UsrCrea() As String
		Get
			return m_salid_usrcrea
		End Get
		Set(ByVal value As String)
			m_salid_usrcrea = value
		End Set
	End Property

	Public Property SALID_FecCrea() As Date
		Get
			return m_salid_feccrea
		End Get
		Set(ByVal value As Date)
			m_salid_feccrea = value
		End Set
	End Property

	Public Property SALID_UsrMod() As String
		Get
			return m_salid_usrmod
		End Get
		Set(ByVal value As String)
			m_salid_usrmod = value
		End Set
	End Property

	Public Property SALID_FecMod() As Date
		Get
			return m_salid_fecmod
		End Get
		Set(ByVal value As Date)
			m_salid_fecmod = value
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
			Return "DESP_Salidas"
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
	Public Event ENTID_CodigoConductorChanged As EventHandler
	Public Event SALID_HoraSalidaChanged As EventHandler
	Public Event SALID_HoraLlegadaChanged As EventHandler
	Public Event SALID_PesoChanged As EventHandler

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

	Public Sub OnENTID_CodigoConductorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoConductorChanged(sender, e)
	End Sub

	Public Sub OnSALID_HoraSalidaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SALID_HoraSalidaChanged(sender, e)
	End Sub

	Public Sub OnSALID_HoraLlegadaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SALID_HoraLlegadaChanged(sender, e)
	End Sub

	Public Sub OnSALID_PesoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SALID_PesoChanged(sender, e)
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

