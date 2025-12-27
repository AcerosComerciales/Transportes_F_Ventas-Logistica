Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_CajaDocsPago

#Region " Campos "
	
	Private m_caja_codigo As String
	Private m_pvent_id As Long
	Private m_dpago_id As Long
	Private m_cdepo_numero As Integer
	Private m_cdepo_importe As Decimal
	Private m_cdepo_usrcrea As String
	Private m_cdepo_feccrea As Date
	Private m_cdepo_usrmod As String
	Private m_cdepo_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_CajaDocsPago
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
	
	Public Property CAJA_Codigo() As String
		Get
			return m_caja_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_codigo) Then
				If Not m_caja_codigo.Equals(value) Then
					m_caja_codigo = value
					OnCAJA_CodigoChanged(m_caja_codigo, EventArgs.Empty)
				End If
			Else
				m_caja_codigo = value
				OnCAJA_CodigoChanged(m_caja_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

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

	Public Property CDEPO_Numero() As Integer
		Get
			return m_cdepo_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_cdepo_numero) Then
				If Not m_cdepo_numero.Equals(value) Then
					m_cdepo_numero = value
					OnCDEPO_NumeroChanged(m_cdepo_numero, EventArgs.Empty)
				End If
			Else
				m_cdepo_numero = value
				OnCDEPO_NumeroChanged(m_cdepo_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CDEPO_Importe() As Decimal
		Get
			return m_cdepo_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cdepo_importe) Then
				If Not m_cdepo_importe.Equals(value) Then
					m_cdepo_importe = value
					OnCDEPO_ImporteChanged(m_cdepo_importe, EventArgs.Empty)
				End If
			Else
				m_cdepo_importe = value
				OnCDEPO_ImporteChanged(m_cdepo_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CDEPO_UsrCrea() As String
		Get
			return m_cdepo_usrcrea
		End Get
		Set(ByVal value As String)
			m_cdepo_usrcrea = value
		End Set
	End Property

	Public Property CDEPO_FecCrea() As Date
		Get
			return m_cdepo_feccrea
		End Get
		Set(ByVal value As Date)
			m_cdepo_feccrea = value
		End Set
	End Property

	Public Property CDEPO_UsrMod() As String
		Get
			return m_cdepo_usrmod
		End Get
		Set(ByVal value As String)
			m_cdepo_usrmod = value
		End Set
	End Property

	Public Property CDEPO_FecMod() As Date
		Get
			return m_cdepo_fecmod
		End Get
		Set(ByVal value As Date)
			m_cdepo_fecmod = value
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
			Return "TESO_CajaDocsPago"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Tesoreria"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event CAJA_CodigoChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event DPAGO_IdChanged As EventHandler
	Public Event CDEPO_NumeroChanged As EventHandler
	Public Event CDEPO_ImporteChanged As EventHandler

	Public Sub OnCAJA_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_IdChanged(sender, e)
	End Sub

	Public Sub OnCDEPO_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CDEPO_NumeroChanged(sender, e)
	End Sub

	Public Sub OnCDEPO_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CDEPO_ImporteChanged(sender, e)
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

