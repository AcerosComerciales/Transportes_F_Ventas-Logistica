Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_VehiculosConductores

#Region " Campos "
	
	Private m_vhcon_id As Long
	Private m_vehic_id As Long
	Private m_entid_codigo As String
	Private m_vhcon_fecdesde As Date
	Private m_vhcon_fechasta As Date
	Private m_vhcon_estado As String
	Private m_vhcon_usrcrea As String
	Private m_vhcon_feccrea As Date
	Private m_vhcon_usrmod As String
	Private m_vhcon_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_VehiculosConductores
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
	
	Public Property VHCON_Id() As Long
		Get
			return m_vhcon_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vhcon_id) Then
				If Not m_vhcon_id.Equals(value) Then
					m_vhcon_id = value
					OnVHCON_IdChanged(m_vhcon_id, EventArgs.Empty)
				End If
			Else
				m_vhcon_id = value
				OnVHCON_IdChanged(m_vhcon_id, EventArgs.Empty)
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
	Public Property VHCON_FecDesde() As Date
		Get
			return m_vhcon_fecdesde
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_vhcon_fecdesde) Then
				If Not m_vhcon_fecdesde.Equals(value) Then
					m_vhcon_fecdesde = value
					OnVHCON_FecDesdeChanged(m_vhcon_fecdesde, EventArgs.Empty)
				End If
			Else
				m_vhcon_fecdesde = value
				OnVHCON_FecDesdeChanged(m_vhcon_fecdesde, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property VHCON_FecHasta() As Date
		Get
			return m_vhcon_fechasta
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_vhcon_fechasta) Then
				If Not m_vhcon_fechasta.Equals(value) Then
					m_vhcon_fechasta = value
					OnVHCON_FecHastaChanged(m_vhcon_fechasta, EventArgs.Empty)
				End If
			Else
				m_vhcon_fechasta = value
				OnVHCON_FecHastaChanged(m_vhcon_fechasta, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property VHCON_Estado() As String
		Get
			return m_vhcon_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vhcon_estado) Then
				If Not m_vhcon_estado.Equals(value) Then
					m_vhcon_estado = value
					OnVHCON_EstadoChanged(m_vhcon_estado, EventArgs.Empty)
				End If
			Else
				m_vhcon_estado = value
				OnVHCON_EstadoChanged(m_vhcon_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property VHCON_UsrCrea() As String
		Get
			return m_vhcon_usrcrea
		End Get
		Set(ByVal value As String)
			m_vhcon_usrcrea = value
		End Set
	End Property
	Public Property VHCON_FecCrea() As Date
		Get
			return m_vhcon_feccrea
		End Get
		Set(ByVal value As Date)
			m_vhcon_feccrea = value
		End Set
	End Property
	Public Property VHCON_UsrMod() As String
		Get
			return m_vhcon_usrmod
		End Get
		Set(ByVal value As String)
			m_vhcon_usrmod = value
		End Set
	End Property
	Public Property VHCON_FecMod() As Date
		Get
			return m_vhcon_fecmod
		End Get
		Set(ByVal value As Date)
			m_vhcon_fecmod = value
		End Set
	End Property
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
			Return "TRAN_VehiculosConductores"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event VHCON_IdChanged As EventHandler
	Public Event VEHIC_IdChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event VHCON_FecDesdeChanged As EventHandler
	Public Event VHCON_FecHastaChanged As EventHandler
	Public Event VHCON_EstadoChanged As EventHandler
	Public Sub OnVHCON_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VHCON_IdChanged(sender, e)
	End Sub
	Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
	End Sub
	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub
	Public Sub OnVHCON_FecDesdeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VHCON_FecDesdeChanged(sender, e)
	End Sub
	Public Sub OnVHCON_FecHastaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VHCON_FecHastaChanged(sender, e)
	End Sub
	Public Sub OnVHCON_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VHCON_EstadoChanged(sender, e)
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

