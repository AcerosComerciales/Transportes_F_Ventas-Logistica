Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_FletePorRuta

#Region " Campos "
	
	Private m_rutas_id As Long
	Private m_entid_codigo As String
	Private m_tipos_codtipomoneda As String
	Private m_flert_importe As Decimal
	Private m_flert_conigv As Boolean
	Private m_flert_glosa As String
	Private m_flert_usrcrea As String
	Private m_flert_feccrea As Date
	Private m_flert_usrmod As String
	Private m_flert_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_FletePorRuta
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
	
	Public Property RUTAS_Id() As Long
		Get
			return m_rutas_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_rutas_id) Then
				If Not m_rutas_id.Equals(value) Then
					m_rutas_id = value
					OnRUTAS_IdChanged(m_rutas_id, EventArgs.Empty)
				End If
			Else
				m_rutas_id = value
				OnRUTAS_IdChanged(m_rutas_id, EventArgs.Empty)
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

	Public Property TIPOS_CodTipoMoneda() As String
		Get
			return m_tipos_codtipomoneda
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipomoneda) Then
				If Not m_tipos_codtipomoneda.Equals(value) Then
					m_tipos_codtipomoneda = value
					OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipomoneda = value
				OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property FLERT_Importe() As Decimal
		Get
			return m_flert_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_flert_importe) Then
				If Not m_flert_importe.Equals(value) Then
					m_flert_importe = value
					OnFLERT_ImporteChanged(m_flert_importe, EventArgs.Empty)
				End If
			Else
				m_flert_importe = value
				OnFLERT_ImporteChanged(m_flert_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property FLERT_ConIGV() As Boolean
		Get
			return m_flert_conigv
		End Get
		Set(ByVal value As Boolean)
			If Not m_flert_conigv.Equals(value) Then
				m_flert_conigv = value
				OnFLERT_ConIGVChanged(m_flert_conigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property FLERT_Glosa() As String
		Get
			return m_flert_glosa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_flert_glosa) Then
				If Not m_flert_glosa.Equals(value) Then
					m_flert_glosa = value
					OnFLERT_GlosaChanged(m_flert_glosa, EventArgs.Empty)
				End If
			Else
				m_flert_glosa = value
				OnFLERT_GlosaChanged(m_flert_glosa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property FLERT_UsrCrea() As String
		Get
			return m_flert_usrcrea
		End Get
		Set(ByVal value As String)
			m_flert_usrcrea = value
		End Set
	End Property

	Public Property FLERT_FecCrea() As Date
		Get
			return m_flert_feccrea
		End Get
		Set(ByVal value As Date)
			m_flert_feccrea = value
		End Set
	End Property

	Public Property FLERT_UsrMod() As String
		Get
			return m_flert_usrmod
		End Get
		Set(ByVal value As String)
			m_flert_usrmod = value
		End Set
	End Property

	Public Property FLERT_FecMod() As Date
		Get
			return m_flert_fecmod
		End Get
		Set(ByVal value As Date)
			m_flert_fecmod = value
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
			Return "TRAN_FletePorRuta"
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
	
	Public Event RUTAS_IdChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event FLERT_ImporteChanged As EventHandler
	Public Event FLERT_ConIGVChanged As EventHandler
	Public Event FLERT_GlosaChanged As EventHandler

	Public Sub OnRUTAS_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RUTAS_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnFLERT_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent FLERT_ImporteChanged(sender, e)
	End Sub

	Public Sub OnFLERT_ConIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent FLERT_ConIGVChanged(sender, e)
	End Sub

	Public Sub OnFLERT_GlosaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent FLERT_GlosaChanged(sender, e)
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

