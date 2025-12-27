Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_MovimientosNeumaticos

#Region " Campos "
	
	Private m_movnm_id As Long
	Private m_neuma_id As Long
	Private m_tipos_codorigen As String
	Private m_tipos_coddestino As String
	Private m_docmt_idorden As Long
	Private m_movnm_fecha As Date
	Private m_movnm_ubicaciondestino As String
	Private m_movnm_iddestino As Long
	Private m_movnm_ubicacionorigen As String
	Private m_movnm_idorigen As Long
	Private m_movnm_fecasignacion As Date
	Private m_movnm_fecretiro As Date
	Private m_movnm_glosa As String
	Private m_movnm_motivo As String
	Private m_movnm_estado As String
	Private m_movnm_usrcrea As String
	Private m_movnm_feccrea As Date
	Private m_movnm_usrmod As String
	Private m_movnm_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_MovimientosNeumaticos
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
	
	Public Property MOVNM_Id() As Long
		Get
			return m_movnm_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_movnm_id) Then
				If Not m_movnm_id.Equals(value) Then
					m_movnm_id = value
					OnMOVNM_IdChanged(m_movnm_id, EventArgs.Empty)
				End If
			Else
				m_movnm_id = value
				OnMOVNM_IdChanged(m_movnm_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Id() As Long
		Get
			return m_neuma_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_neuma_id) Then
				If Not m_neuma_id.Equals(value) Then
					m_neuma_id = value
					OnNEUMA_IdChanged(m_neuma_id, EventArgs.Empty)
				End If
			Else
				m_neuma_id = value
				OnNEUMA_IdChanged(m_neuma_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property TIPOS_CodOrigen() As String
		Get
			return m_tipos_codorigen
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codorigen) Then
				If Not m_tipos_codorigen.Equals(value) Then
					m_tipos_codorigen = value
					OnTIPOS_CodOrigenChanged(m_tipos_codorigen, EventArgs.Empty)
				End If
			Else
				m_tipos_codorigen = value
				OnTIPOS_CodOrigenChanged(m_tipos_codorigen, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property TIPOS_CodDestino() As String
		Get
			return m_tipos_coddestino
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_coddestino) Then
				If Not m_tipos_coddestino.Equals(value) Then
					m_tipos_coddestino = value
					OnTIPOS_CodDestinoChanged(m_tipos_coddestino, EventArgs.Empty)
				End If
			Else
				m_tipos_coddestino = value
				OnTIPOS_CodDestinoChanged(m_tipos_coddestino, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCMT_IdOrden() As Long
		Get
			return m_docmt_idorden
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_docmt_idorden) Then
				If Not m_docmt_idorden.Equals(value) Then
					m_docmt_idorden = value
					OnDOCMT_IdOrdenChanged(m_docmt_idorden, EventArgs.Empty)
				End If
			Else
				m_docmt_idorden = value
				OnDOCMT_IdOrdenChanged(m_docmt_idorden, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_Fecha() As Date
		Get
			return m_movnm_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_movnm_fecha) Then
				If Not m_movnm_fecha.Equals(value) Then
					m_movnm_fecha = value
					OnMOVNM_FechaChanged(m_movnm_fecha, EventArgs.Empty)
				End If
			Else
				m_movnm_fecha = value
				OnMOVNM_FechaChanged(m_movnm_fecha, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_UbicacionDestino() As String
		Get
			return m_movnm_ubicaciondestino
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_movnm_ubicaciondestino) Then
				If Not m_movnm_ubicaciondestino.Equals(value) Then
					m_movnm_ubicaciondestino = value
					OnMOVNM_UbicacionDestinoChanged(m_movnm_ubicaciondestino, EventArgs.Empty)
				End If
			Else
				m_movnm_ubicaciondestino = value
				OnMOVNM_UbicacionDestinoChanged(m_movnm_ubicaciondestino, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_IdDestino() As Long
		Get
			return m_movnm_iddestino
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_movnm_iddestino) Then
				If Not m_movnm_iddestino.Equals(value) Then
					m_movnm_iddestino = value
					OnMOVNM_IdDestinoChanged(m_movnm_iddestino, EventArgs.Empty)
				End If
			Else
				m_movnm_iddestino = value
				OnMOVNM_IdDestinoChanged(m_movnm_iddestino, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_UbicacionOrigen() As String
		Get
			return m_movnm_ubicacionorigen
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_movnm_ubicacionorigen) Then
				If Not m_movnm_ubicacionorigen.Equals(value) Then
					m_movnm_ubicacionorigen = value
					OnMOVNM_UbicacionOrigenChanged(m_movnm_ubicacionorigen, EventArgs.Empty)
				End If
			Else
				m_movnm_ubicacionorigen = value
				OnMOVNM_UbicacionOrigenChanged(m_movnm_ubicacionorigen, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_IdOrigen() As Long
		Get
			return m_movnm_idorigen
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_movnm_idorigen) Then
				If Not m_movnm_idorigen.Equals(value) Then
					m_movnm_idorigen = value
					OnMOVNM_IdOrigenChanged(m_movnm_idorigen, EventArgs.Empty)
				End If
			Else
				m_movnm_idorigen = value
				OnMOVNM_IdOrigenChanged(m_movnm_idorigen, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_FecAsignacion() As Date
		Get
			return m_movnm_fecasignacion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_movnm_fecasignacion) Then
				If Not m_movnm_fecasignacion.Equals(value) Then
					m_movnm_fecasignacion = value
					OnMOVNM_FecAsignacionChanged(m_movnm_fecasignacion, EventArgs.Empty)
				End If
			Else
				m_movnm_fecasignacion = value
				OnMOVNM_FecAsignacionChanged(m_movnm_fecasignacion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_FecRetiro() As Date
		Get
			return m_movnm_fecretiro
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_movnm_fecretiro) Then
				If Not m_movnm_fecretiro.Equals(value) Then
					m_movnm_fecretiro = value
					OnMOVNM_FecRetiroChanged(m_movnm_fecretiro, EventArgs.Empty)
				End If
			Else
				m_movnm_fecretiro = value
				OnMOVNM_FecRetiroChanged(m_movnm_fecretiro, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_Glosa() As String
		Get
			return m_movnm_glosa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_movnm_glosa) Then
				If Not m_movnm_glosa.Equals(value) Then
					m_movnm_glosa = value
					OnMOVNM_GlosaChanged(m_movnm_glosa, EventArgs.Empty)
				End If
			Else
				m_movnm_glosa = value
				OnMOVNM_GlosaChanged(m_movnm_glosa, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_Motivo() As String
		Get
			return m_movnm_motivo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_movnm_motivo) Then
				If Not m_movnm_motivo.Equals(value) Then
					m_movnm_motivo = value
					OnMOVNM_MotivoChanged(m_movnm_motivo, EventArgs.Empty)
				End If
			Else
				m_movnm_motivo = value
				OnMOVNM_MotivoChanged(m_movnm_motivo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_Estado() As String
		Get
			return m_movnm_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_movnm_estado) Then
				If Not m_movnm_estado.Equals(value) Then
					m_movnm_estado = value
					OnMOVNM_EstadoChanged(m_movnm_estado, EventArgs.Empty)
				End If
			Else
				m_movnm_estado = value
				OnMOVNM_EstadoChanged(m_movnm_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVNM_UsrCrea() As String
		Get
			return m_movnm_usrcrea
		End Get
		Set(ByVal value As String)
			m_movnm_usrcrea = value
		End Set
	End Property
	Public Property MOVNM_FecCrea() As Date
		Get
			return m_movnm_feccrea
		End Get
		Set(ByVal value As Date)
			m_movnm_feccrea = value
		End Set
	End Property
	Public Property MOVNM_UsrMod() As String
		Get
			return m_movnm_usrmod
		End Get
		Set(ByVal value As String)
			m_movnm_usrmod = value
		End Set
	End Property
	Public Property MOVNM_FecMod() As Date
		Get
			return m_movnm_fecmod
		End Get
		Set(ByVal value As Date)
			m_movnm_fecmod = value
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
			Return "TRAN_MovimientosNeumaticos"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event MOVNM_IdChanged As EventHandler
	Public Event NEUMA_IdChanged As EventHandler
	Public Event TIPOS_CodOrigenChanged As EventHandler
	Public Event TIPOS_CodDestinoChanged As EventHandler
	Public Event DOCMT_IdOrdenChanged As EventHandler
	Public Event MOVNM_FechaChanged As EventHandler
	Public Event MOVNM_UbicacionDestinoChanged As EventHandler
	Public Event MOVNM_IdDestinoChanged As EventHandler
	Public Event MOVNM_UbicacionOrigenChanged As EventHandler
	Public Event MOVNM_IdOrigenChanged As EventHandler
	Public Event MOVNM_FecAsignacionChanged As EventHandler
	Public Event MOVNM_FecRetiroChanged As EventHandler
	Public Event MOVNM_GlosaChanged As EventHandler
	Public Event MOVNM_MotivoChanged As EventHandler
	Public Event MOVNM_EstadoChanged As EventHandler
	Public Sub OnMOVNM_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_IdChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_IdChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodOrigenChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodDestinoChanged(sender, e)
	End Sub
	Public Sub OnDOCMT_IdOrdenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCMT_IdOrdenChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_FechaChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_UbicacionDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_UbicacionDestinoChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_IdDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_IdDestinoChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_UbicacionOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_UbicacionOrigenChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_IdOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_IdOrigenChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_FecAsignacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_FecAsignacionChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_FecRetiroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_FecRetiroChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_GlosaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_GlosaChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_MotivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_MotivoChanged(sender, e)
	End Sub
	Public Sub OnMOVNM_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_EstadoChanged(sender, e)
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

