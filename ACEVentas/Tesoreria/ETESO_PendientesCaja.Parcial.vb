Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_PendientesCaja

#Region " Campos "
	
	Private m_pcaja_id As Long
	Private m_pvent_id As Long
	Private m_tipos_codtipomoneda As String
	Private m_pcaja_fecha As Date
	Private m_pcaja_glosa As String
	Private m_pcaja_usuariorec As String
	Private m_pcaja_usuariooto As String
	Private m_pcaja_importe As Decimal
	Private m_pcaja_efectivo As Boolean
	Private m_pcaja_tipo As Boolean
	Private m_pcaja_estado As String
	Private m_pcaja_usrcrea As String
	Private m_pcaja_feccrea As Date
	Private m_pcaja_usrmod As String
	Private m_pcaja_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_PendientesCaja
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
	
	Public Property PCAJA_Id() As Long
		Get
			return m_pcaja_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pcaja_id) Then
				If Not m_pcaja_id.Equals(value) Then
					m_pcaja_id = value
					OnPCAJA_IdChanged(m_pcaja_id, EventArgs.Empty)
				End If
			Else
				m_pcaja_id = value
				OnPCAJA_IdChanged(m_pcaja_id, EventArgs.Empty)
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

	Public Property PCAJA_Fecha() As Date
		Get
			return m_pcaja_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_pcaja_fecha) Then
				If Not m_pcaja_fecha.Equals(value) Then
					m_pcaja_fecha = value
					OnPCAJA_FechaChanged(m_pcaja_fecha, EventArgs.Empty)
				End If
			Else
				m_pcaja_fecha = value
				OnPCAJA_FechaChanged(m_pcaja_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCAJA_Glosa() As String
		Get
			return m_pcaja_glosa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pcaja_glosa) Then
				If Not m_pcaja_glosa.Equals(value) Then
					m_pcaja_glosa = value
					OnPCAJA_GlosaChanged(m_pcaja_glosa, EventArgs.Empty)
				End If
			Else
				m_pcaja_glosa = value
				OnPCAJA_GlosaChanged(m_pcaja_glosa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCAJA_UsuarioRec() As String
		Get
			return m_pcaja_usuariorec
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pcaja_usuariorec) Then
				If Not m_pcaja_usuariorec.Equals(value) Then
					m_pcaja_usuariorec = value
					OnPCAJA_UsuarioRecChanged(m_pcaja_usuariorec, EventArgs.Empty)
				End If
			Else
				m_pcaja_usuariorec = value
				OnPCAJA_UsuarioRecChanged(m_pcaja_usuariorec, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCAJA_UsuarioOto() As String
		Get
			return m_pcaja_usuariooto
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pcaja_usuariooto) Then
				If Not m_pcaja_usuariooto.Equals(value) Then
					m_pcaja_usuariooto = value
					OnPCAJA_UsuarioOtoChanged(m_pcaja_usuariooto, EventArgs.Empty)
				End If
			Else
				m_pcaja_usuariooto = value
				OnPCAJA_UsuarioOtoChanged(m_pcaja_usuariooto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCAJA_Importe() As Decimal
		Get
			return m_pcaja_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pcaja_importe) Then
				If Not m_pcaja_importe.Equals(value) Then
					m_pcaja_importe = value
					OnPCAJA_ImporteChanged(m_pcaja_importe, EventArgs.Empty)
				End If
			Else
				m_pcaja_importe = value
				OnPCAJA_ImporteChanged(m_pcaja_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCAJA_Efectivo() As Boolean
		Get
			return m_pcaja_efectivo
		End Get
		Set(ByVal value As Boolean)
			If Not m_pcaja_efectivo.Equals(value) Then
				m_pcaja_efectivo = value
				OnPCAJA_EfectivoChanged(m_pcaja_efectivo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCAJA_Tipo() As Boolean
		Get
			return m_pcaja_tipo
		End Get
		Set(ByVal value As Boolean)
			If Not m_pcaja_tipo.Equals(value) Then
				m_pcaja_tipo = value
				OnPCAJA_TipoChanged(m_pcaja_tipo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCAJA_Estado() As String
		Get
			return m_pcaja_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pcaja_estado) Then
				If Not m_pcaja_estado.Equals(value) Then
					m_pcaja_estado = value
					OnPCAJA_EstadoChanged(m_pcaja_estado, EventArgs.Empty)
				End If
			Else
				m_pcaja_estado = value
				OnPCAJA_EstadoChanged(m_pcaja_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCAJA_UsrCrea() As String
		Get
			return m_pcaja_usrcrea
		End Get
		Set(ByVal value As String)
			m_pcaja_usrcrea = value
		End Set
	End Property

	Public Property PCAJA_FecCrea() As Date
		Get
			return m_pcaja_feccrea
		End Get
		Set(ByVal value As Date)
			m_pcaja_feccrea = value
		End Set
	End Property

	Public Property PCAJA_UsrMod() As String
		Get
			return m_pcaja_usrmod
		End Get
		Set(ByVal value As String)
			m_pcaja_usrmod = value
		End Set
	End Property

	Public Property PCAJA_FecMod() As Date
		Get
			return m_pcaja_fecmod
		End Get
		Set(ByVal value As Date)
			m_pcaja_fecmod = value
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
			Return "TESO_PendientesCaja"
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
	
	Public Event PCAJA_IdChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event PCAJA_FechaChanged As EventHandler
	Public Event PCAJA_GlosaChanged As EventHandler
	Public Event PCAJA_UsuarioRecChanged As EventHandler
	Public Event PCAJA_UsuarioOtoChanged As EventHandler
	Public Event PCAJA_ImporteChanged As EventHandler
	Public Event PCAJA_EfectivoChanged As EventHandler
	Public Event PCAJA_TipoChanged As EventHandler
	Public Event PCAJA_EstadoChanged As EventHandler

	Public Sub OnPCAJA_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_IdChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnPCAJA_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_FechaChanged(sender, e)
	End Sub

	Public Sub OnPCAJA_GlosaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_GlosaChanged(sender, e)
	End Sub

	Public Sub OnPCAJA_UsuarioRecChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_UsuarioRecChanged(sender, e)
	End Sub

	Public Sub OnPCAJA_UsuarioOtoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_UsuarioOtoChanged(sender, e)
	End Sub

	Public Sub OnPCAJA_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_ImporteChanged(sender, e)
	End Sub

	Public Sub OnPCAJA_EfectivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_EfectivoChanged(sender, e)
	End Sub

	Public Sub OnPCAJA_TipoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_TipoChanged(sender, e)
	End Sub

	Public Sub OnPCAJA_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_EstadoChanged(sender, e)
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

