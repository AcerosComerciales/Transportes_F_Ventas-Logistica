Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_VehiculosInventario

#Region " Campos "
	
	Private m_vehic_id As Long
	Private m_vehin_id As Long
	Private m_vehin_fecha As Date
	Private m_vehin_observacion As String
	Private m_vehin_estado As String
	Private m_vehin_detalle As XmlDocument
	Private m_vehin_usrcrea As String
	Private m_vehin_feccrea As Date
	Private m_vehin_usrmod As String
	Private m_vehin_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_VehiculosInventario
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

	Public Property VEHIN_Id() As Long
		Get
			return m_vehin_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vehin_id) Then
				If Not m_vehin_id.Equals(value) Then
					m_vehin_id = value
					OnVEHIN_IdChanged(m_vehin_id, EventArgs.Empty)
				End If
			Else
				m_vehin_id = value
				OnVEHIN_IdChanged(m_vehin_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIN_Fecha() As Date
		Get
			return m_vehin_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_vehin_fecha) Then
				If Not m_vehin_fecha.Equals(value) Then
					m_vehin_fecha = value
					OnVEHIN_FechaChanged(m_vehin_fecha, EventArgs.Empty)
				End If
			Else
				m_vehin_fecha = value
				OnVEHIN_FechaChanged(m_vehin_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIN_Observacion() As String
		Get
			return m_vehin_observacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehin_observacion) Then
				If Not m_vehin_observacion.Equals(value) Then
					m_vehin_observacion = value
					OnVEHIN_ObservacionChanged(m_vehin_observacion, EventArgs.Empty)
				End If
			Else
				m_vehin_observacion = value
				OnVEHIN_ObservacionChanged(m_vehin_observacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIN_Estado() As String
		Get
			return m_vehin_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehin_estado) Then
				If Not m_vehin_estado.Equals(value) Then
					m_vehin_estado = value
					OnVEHIN_EstadoChanged(m_vehin_estado, EventArgs.Empty)
				End If
			Else
				m_vehin_estado = value
				OnVEHIN_EstadoChanged(m_vehin_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIN_Detalle() As XmlDocument
		Get
			return m_vehin_detalle
		End Get
		Set(ByVal value As XmlDocument)
			If Not IsNothing(m_vehin_detalle) Then
				If Not m_vehin_detalle.Equals(value) Then
					m_vehin_detalle = value
					OnVEHIN_DetalleChanged(m_vehin_detalle, EventArgs.Empty)
				End If
			Else
				m_vehin_detalle = value
				OnVEHIN_DetalleChanged(m_vehin_detalle, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIN_UsrCrea() As String
		Get
			return m_vehin_usrcrea
		End Get
		Set(ByVal value As String)
			m_vehin_usrcrea = value
		End Set
	End Property

	Public Property VEHIN_FecCrea() As Date
		Get
			return m_vehin_feccrea
		End Get
		Set(ByVal value As Date)
			m_vehin_feccrea = value
		End Set
	End Property

	Public Property VEHIN_UsrMod() As String
		Get
			return m_vehin_usrmod
		End Get
		Set(ByVal value As String)
			m_vehin_usrmod = value
		End Set
	End Property

	Public Property VEHIN_FecMod() As Date
		Get
			return m_vehin_fecmod
		End Get
		Set(ByVal value As Date)
			m_vehin_fecmod = value
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
			Return "TRAN_VehiculosInventario"
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
	
	Public Event VEHIC_IdChanged As EventHandler
	Public Event VEHIN_IdChanged As EventHandler
	Public Event VEHIN_FechaChanged As EventHandler
	Public Event VEHIN_ObservacionChanged As EventHandler
	Public Event VEHIN_EstadoChanged As EventHandler
	Public Event VEHIN_DetalleChanged As EventHandler

	Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
	End Sub

	Public Sub OnVEHIN_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIN_IdChanged(sender, e)
	End Sub

	Public Sub OnVEHIN_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIN_FechaChanged(sender, e)
	End Sub

	Public Sub OnVEHIN_ObservacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIN_ObservacionChanged(sender, e)
	End Sub

	Public Sub OnVEHIN_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIN_EstadoChanged(sender, e)
	End Sub

	Public Sub OnVEHIN_DetalleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIN_DetalleChanged(sender, e)
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

