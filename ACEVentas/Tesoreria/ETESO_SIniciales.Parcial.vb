Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_SIniciales

#Region " Campos "
	
	Private m_entid_codigo As String
	Private m_pvent_id As Long
	Private m_sinic_id As Long
	Private m_sinic_glosa As String
	Private m_sinic_importe As Decimal
	Private m_sinic_fecha As Date
	Private m_sinic_usrcrea As String
	Private m_sinic_feccrea As Date
	Private m_sinic_usrmod As String
	Private m_sinic_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_SIniciales
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

	Public Property SINIC_Id() As Long
		Get
			return m_sinic_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_sinic_id) Then
				If Not m_sinic_id.Equals(value) Then
					m_sinic_id = value
					OnSINIC_IdChanged(m_sinic_id, EventArgs.Empty)
				End If
			Else
				m_sinic_id = value
				OnSINIC_IdChanged(m_sinic_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SINIC_Glosa() As String
		Get
			return m_sinic_glosa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_sinic_glosa) Then
				If Not m_sinic_glosa.Equals(value) Then
					m_sinic_glosa = value
					OnSINIC_GlosaChanged(m_sinic_glosa, EventArgs.Empty)
				End If
			Else
				m_sinic_glosa = value
				OnSINIC_GlosaChanged(m_sinic_glosa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SINIC_Importe() As Decimal
		Get
			return m_sinic_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_sinic_importe) Then
				If Not m_sinic_importe.Equals(value) Then
					m_sinic_importe = value
					OnSINIC_ImporteChanged(m_sinic_importe, EventArgs.Empty)
				End If
			Else
				m_sinic_importe = value
				OnSINIC_ImporteChanged(m_sinic_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SINIC_Fecha() As Date
		Get
			return m_sinic_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_sinic_fecha) Then
				If Not m_sinic_fecha.Equals(value) Then
					m_sinic_fecha = value
					OnSINIC_FechaChanged(m_sinic_fecha, EventArgs.Empty)
				End If
			Else
				m_sinic_fecha = value
				OnSINIC_FechaChanged(m_sinic_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SINIC_UsrCrea() As String
		Get
			return m_sinic_usrcrea
		End Get
		Set(ByVal value As String)
			m_sinic_usrcrea = value
		End Set
	End Property

	Public Property SINIC_FecCrea() As Date
		Get
			return m_sinic_feccrea
		End Get
		Set(ByVal value As Date)
			m_sinic_feccrea = value
		End Set
	End Property

	Public Property SINIC_UsrMod() As String
		Get
			return m_sinic_usrmod
		End Get
		Set(ByVal value As String)
			m_sinic_usrmod = value
		End Set
	End Property

	Public Property SINIC_FecMod() As Date
		Get
			return m_sinic_fecmod
		End Get
		Set(ByVal value As Date)
			m_sinic_fecmod = value
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
			Return "TESO_SIniciales"
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
	
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event SINIC_IdChanged As EventHandler
	Public Event SINIC_GlosaChanged As EventHandler
	Public Event SINIC_ImporteChanged As EventHandler
	Public Event SINIC_FechaChanged As EventHandler

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnSINIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SINIC_IdChanged(sender, e)
	End Sub

	Public Sub OnSINIC_GlosaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SINIC_GlosaChanged(sender, e)
	End Sub

	Public Sub OnSINIC_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SINIC_ImporteChanged(sender, e)
	End Sub

	Public Sub OnSINIC_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SINIC_FechaChanged(sender, e)
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

