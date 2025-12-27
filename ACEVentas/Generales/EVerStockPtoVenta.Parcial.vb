Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EVerStockPtoVenta

#Region " Campos "
	
	Private m_pvent_id As Long
	Private m_almac_id As Short
	Private m_vspva_activo As Boolean
	Private m_vspva_parapedidos As Boolean
	Private m_vspva_usrcrea As String
	Private m_vspva_feccrea As Date
	Private m_vspva_usrmod As String
	Private m_vspva_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlVerStockPtoVenta
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

	Public Property ALMAC_Id() As Short
		Get
			return m_almac_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_almac_id) Then
				If Not m_almac_id.Equals(value) Then
					m_almac_id = value
					OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
				End If
			Else
				m_almac_id = value
				OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VSPVA_Activo() As Boolean
		Get
			return m_vspva_activo
		End Get
		Set(ByVal value As Boolean)
			If Not m_vspva_activo.Equals(value) Then
				m_vspva_activo = value
				OnVSPVA_ActivoChanged(m_vspva_activo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VSPVA_ParaPedidos() As Boolean
		Get
			return m_vspva_parapedidos
		End Get
		Set(ByVal value As Boolean)
			If Not m_vspva_parapedidos.Equals(value) Then
				m_vspva_parapedidos = value
				OnVSPVA_ParaPedidosChanged(m_vspva_parapedidos, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VSPVA_UsrCrea() As String
		Get
			return m_vspva_usrcrea
		End Get
		Set(ByVal value As String)
			m_vspva_usrcrea = value
		End Set
	End Property

	Public Property VSPVA_FecCrea() As Date
		Get
			return m_vspva_feccrea
		End Get
		Set(ByVal value As Date)
			m_vspva_feccrea = value
		End Set
	End Property

	Public Property VSPVA_UsrMod() As String
		Get
			return m_vspva_usrmod
		End Get
		Set(ByVal value As String)
			m_vspva_usrmod = value
		End Set
	End Property

	Public Property VSPVA_FecMod() As Date
		Get
			return m_vspva_fecmod
		End Get
		Set(ByVal value As Date)
			m_vspva_fecmod = value
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
			Return "VerStockPtoVenta"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event PVENT_IdChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event VSPVA_ActivoChanged As EventHandler
	Public Event VSPVA_ParaPedidosChanged As EventHandler

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnVSPVA_ActivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VSPVA_ActivoChanged(sender, e)
	End Sub

	Public Sub OnVSPVA_ParaPedidosChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VSPVA_ParaPedidosChanged(sender, e)
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

