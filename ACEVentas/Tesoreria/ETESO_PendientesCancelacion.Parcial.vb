Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_PendientesCancelacion

#Region " Campos "
	
	Private m_pcaja_id As Long
	Private m_pvent_id As Long
	Private m_pccaj_item As Short
	Private m_tipos_codtipocancelacion As String
	Private m_pccaj_fecha As Date
	Private m_pccaj_importe As Decimal
	Private m_pccaj_glosa As String
	Private m_pccaj_estado As String
	Private m_pccaj_efectivo As Boolean
	Private m_pccaj_usrcrea As String
	Private m_pccaj_feccrea As Date
	Private m_pccaj_usrmod As String
	Private m_pccaj_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_PendientesCancelacion
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

	Public Property PCCAJ_Item() As Short
		Get
			return m_pccaj_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_pccaj_item) Then
				If Not m_pccaj_item.Equals(value) Then
					m_pccaj_item = value
					OnPCCAJ_ItemChanged(m_pccaj_item, EventArgs.Empty)
				End If
			Else
				m_pccaj_item = value
				OnPCCAJ_ItemChanged(m_pccaj_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoCancelacion() As String
		Get
			return m_tipos_codtipocancelacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipocancelacion) Then
				If Not m_tipos_codtipocancelacion.Equals(value) Then
					m_tipos_codtipocancelacion = value
					OnTIPOS_CodTipoCancelacionChanged(m_tipos_codtipocancelacion, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipocancelacion = value
				OnTIPOS_CodTipoCancelacionChanged(m_tipos_codtipocancelacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCCAJ_Fecha() As Date
		Get
			return m_pccaj_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_pccaj_fecha) Then
				If Not m_pccaj_fecha.Equals(value) Then
					m_pccaj_fecha = value
					OnPCCAJ_FechaChanged(m_pccaj_fecha, EventArgs.Empty)
				End If
			Else
				m_pccaj_fecha = value
				OnPCCAJ_FechaChanged(m_pccaj_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCCAJ_Importe() As Decimal
		Get
			return m_pccaj_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pccaj_importe) Then
				If Not m_pccaj_importe.Equals(value) Then
					m_pccaj_importe = value
					OnPCCAJ_ImporteChanged(m_pccaj_importe, EventArgs.Empty)
				End If
			Else
				m_pccaj_importe = value
				OnPCCAJ_ImporteChanged(m_pccaj_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCCAJ_Glosa() As String
		Get
			return m_pccaj_glosa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pccaj_glosa) Then
				If Not m_pccaj_glosa.Equals(value) Then
					m_pccaj_glosa = value
					OnPCCAJ_GlosaChanged(m_pccaj_glosa, EventArgs.Empty)
				End If
			Else
				m_pccaj_glosa = value
				OnPCCAJ_GlosaChanged(m_pccaj_glosa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCCAJ_Estado() As String
		Get
			return m_pccaj_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pccaj_estado) Then
				If Not m_pccaj_estado.Equals(value) Then
					m_pccaj_estado = value
					OnPCCAJ_EstadoChanged(m_pccaj_estado, EventArgs.Empty)
				End If
			Else
				m_pccaj_estado = value
				OnPCCAJ_EstadoChanged(m_pccaj_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCCAJ_Efectivo() As Boolean
		Get
			return m_pccaj_efectivo
		End Get
		Set(ByVal value As Boolean)
			If Not m_pccaj_efectivo.Equals(value) Then
				m_pccaj_efectivo = value
				OnPCCAJ_EfectivoChanged(m_pccaj_efectivo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PCCAJ_UsrCrea() As String
		Get
			return m_pccaj_usrcrea
		End Get
		Set(ByVal value As String)
			m_pccaj_usrcrea = value
		End Set
	End Property

	Public Property PCCAJ_FecCrea() As Date
		Get
			return m_pccaj_feccrea
		End Get
		Set(ByVal value As Date)
			m_pccaj_feccrea = value
		End Set
	End Property

	Public Property PCCAJ_UsrMod() As String
		Get
			return m_pccaj_usrmod
		End Get
		Set(ByVal value As String)
			m_pccaj_usrmod = value
		End Set
	End Property

	Public Property PCCAJ_FecMod() As Date
		Get
			return m_pccaj_fecmod
		End Get
		Set(ByVal value As Date)
			m_pccaj_fecmod = value
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
			Return "TESO_PendientesCancelacion"
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
	Public Event PCCAJ_ItemChanged As EventHandler
	Public Event TIPOS_CodTipoCancelacionChanged As EventHandler
	Public Event PCCAJ_FechaChanged As EventHandler
	Public Event PCCAJ_ImporteChanged As EventHandler
	Public Event PCCAJ_GlosaChanged As EventHandler
	Public Event PCCAJ_EstadoChanged As EventHandler
	Public Event PCCAJ_EfectivoChanged As EventHandler

	Public Sub OnPCAJA_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCAJA_IdChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnPCCAJ_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCCAJ_ItemChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoCancelacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoCancelacionChanged(sender, e)
	End Sub

	Public Sub OnPCCAJ_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCCAJ_FechaChanged(sender, e)
	End Sub

	Public Sub OnPCCAJ_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCCAJ_ImporteChanged(sender, e)
	End Sub

	Public Sub OnPCCAJ_GlosaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCCAJ_GlosaChanged(sender, e)
	End Sub

	Public Sub OnPCCAJ_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCCAJ_EstadoChanged(sender, e)
	End Sub

	Public Sub OnPCCAJ_EfectivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PCCAJ_EfectivoChanged(sender, e)
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

