Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_VehiculosNeumaticos

#Region " Campos "
	
	Private m_vneum_id As Long
	Private m_movnm_id As Long
	Private m_neuma_id As Long
	Private m_vehic_id As Long
	Private m_ranfl_id As Long
	Private m_vneum_fecasignacion As Date
	Private m_vneum_fecretiro As Date
	Private m_vneum_lado As String
	Private m_vneum_seccion As String
	Private m_vneum_orden As Short
	Private m_vneum_ordenposicion As Short
	Private m_vneum_internoexterno As String
	Private m_vneum_repuesto As Short
	Private m_vneum_estado As String
	Private m_vneum_kminicio As Integer
	Private m_vneum_kmfin As Integer
	Private m_vneum_usrcrea As String
	Private m_vneum_feccrea As Date
	Private m_vneum_usrmod As String
	Private m_vneum_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_VehiculosNeumaticos
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
	
	Public Property VNEUM_Id() As Long
		Get
			return m_vneum_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vneum_id) Then
				If Not m_vneum_id.Equals(value) Then
					m_vneum_id = value
					OnVNEUM_IdChanged(m_vneum_id, EventArgs.Empty)
				End If
			Else
				m_vneum_id = value
				OnVNEUM_IdChanged(m_vneum_id, EventArgs.Empty)
			End If
		End Set
	End Property

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

	Public Property RANFL_Id() As Long
		Get
			return m_ranfl_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_ranfl_id) Then
				If Not m_ranfl_id.Equals(value) Then
					m_ranfl_id = value
					OnRANFL_IdChanged(m_ranfl_id, EventArgs.Empty)
				End If
			Else
				m_ranfl_id = value
				OnRANFL_IdChanged(m_ranfl_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_FecAsignacion() As Date
		Get
			return m_vneum_fecasignacion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_vneum_fecasignacion) Then
				If Not m_vneum_fecasignacion.Equals(value) Then
					m_vneum_fecasignacion = value
					OnVNEUM_FecAsignacionChanged(m_vneum_fecasignacion, EventArgs.Empty)
				End If
			Else
				m_vneum_fecasignacion = value
				OnVNEUM_FecAsignacionChanged(m_vneum_fecasignacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_FecRetiro() As Date
		Get
			return m_vneum_fecretiro
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_vneum_fecretiro) Then
				If Not m_vneum_fecretiro.Equals(value) Then
					m_vneum_fecretiro = value
					OnVNEUM_FecRetiroChanged(m_vneum_fecretiro, EventArgs.Empty)
				End If
			Else
				m_vneum_fecretiro = value
				OnVNEUM_FecRetiroChanged(m_vneum_fecretiro, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_Lado() As String
		Get
			return m_vneum_lado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vneum_lado) Then
				If Not m_vneum_lado.Equals(value) Then
					m_vneum_lado = value
					OnVNEUM_LadoChanged(m_vneum_lado, EventArgs.Empty)
				End If
			Else
				m_vneum_lado = value
				OnVNEUM_LadoChanged(m_vneum_lado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_Seccion() As String
		Get
			return m_vneum_seccion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vneum_seccion) Then
				If Not m_vneum_seccion.Equals(value) Then
					m_vneum_seccion = value
					OnVNEUM_SeccionChanged(m_vneum_seccion, EventArgs.Empty)
				End If
			Else
				m_vneum_seccion = value
				OnVNEUM_SeccionChanged(m_vneum_seccion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_Orden() As Short
		Get
			return m_vneum_orden
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_vneum_orden) Then
				If Not m_vneum_orden.Equals(value) Then
					m_vneum_orden = value
					OnVNEUM_OrdenChanged(m_vneum_orden, EventArgs.Empty)
				End If
			Else
				m_vneum_orden = value
				OnVNEUM_OrdenChanged(m_vneum_orden, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_OrdenPosicion() As Short
		Get
			return m_vneum_ordenposicion
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_vneum_ordenposicion) Then
				If Not m_vneum_ordenposicion.Equals(value) Then
					m_vneum_ordenposicion = value
					OnVNEUM_OrdenPosicionChanged(m_vneum_ordenposicion, EventArgs.Empty)
				End If
			Else
				m_vneum_ordenposicion = value
				OnVNEUM_OrdenPosicionChanged(m_vneum_ordenposicion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_InternoExterno() As String
		Get
			return m_vneum_internoexterno
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vneum_internoexterno) Then
				If Not m_vneum_internoexterno.Equals(value) Then
					m_vneum_internoexterno = value
					OnVNEUM_InternoExternoChanged(m_vneum_internoexterno, EventArgs.Empty)
				End If
			Else
				m_vneum_internoexterno = value
				OnVNEUM_InternoExternoChanged(m_vneum_internoexterno, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_Repuesto() As Short
		Get
			return m_vneum_repuesto
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_vneum_repuesto) Then
				If Not m_vneum_repuesto.Equals(value) Then
					m_vneum_repuesto = value
					OnVNEUM_RepuestoChanged(m_vneum_repuesto, EventArgs.Empty)
				End If
			Else
				m_vneum_repuesto = value
				OnVNEUM_RepuestoChanged(m_vneum_repuesto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_Estado() As String
		Get
			return m_vneum_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vneum_estado) Then
				If Not m_vneum_estado.Equals(value) Then
					m_vneum_estado = value
					OnVNEUM_EstadoChanged(m_vneum_estado, EventArgs.Empty)
				End If
			Else
				m_vneum_estado = value
				OnVNEUM_EstadoChanged(m_vneum_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_KmInicio() As Integer
		Get
			return m_vneum_kminicio
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_vneum_kminicio) Then
				If Not m_vneum_kminicio.Equals(value) Then
					m_vneum_kminicio = value
					OnVNEUM_KmInicioChanged(m_vneum_kminicio, EventArgs.Empty)
				End If
			Else
				m_vneum_kminicio = value
				OnVNEUM_KmInicioChanged(m_vneum_kminicio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_KmFin() As Integer
		Get
			return m_vneum_kmfin
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_vneum_kmfin) Then
				If Not m_vneum_kmfin.Equals(value) Then
					m_vneum_kmfin = value
					OnVNEUM_KmFinChanged(m_vneum_kmfin, EventArgs.Empty)
				End If
			Else
				m_vneum_kmfin = value
				OnVNEUM_KmFinChanged(m_vneum_kmfin, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VNEUM_UsrCrea() As String
		Get
			return m_vneum_usrcrea
		End Get
		Set(ByVal value As String)
			m_vneum_usrcrea = value
		End Set
	End Property

	Public Property VNEUM_FecCrea() As Date
		Get
			return m_vneum_feccrea
		End Get
		Set(ByVal value As Date)
			m_vneum_feccrea = value
		End Set
	End Property

	Public Property VNEUM_UsrMod() As String
		Get
			return m_vneum_usrmod
		End Get
		Set(ByVal value As String)
			m_vneum_usrmod = value
		End Set
	End Property

	Public Property VNEUM_FecMod() As Date
		Get
			return m_vneum_fecmod
		End Get
		Set(ByVal value As Date)
			m_vneum_fecmod = value
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
			Return "TRAN_VehiculosNeumaticos"
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
	
	Public Event VNEUM_IdChanged As EventHandler
	Public Event MOVNM_IdChanged As EventHandler
	Public Event NEUMA_IdChanged As EventHandler
	Public Event VEHIC_IdChanged As EventHandler
	Public Event RANFL_IdChanged As EventHandler
	Public Event VNEUM_FecAsignacionChanged As EventHandler
	Public Event VNEUM_FecRetiroChanged As EventHandler
	Public Event VNEUM_LadoChanged As EventHandler
	Public Event VNEUM_SeccionChanged As EventHandler
	Public Event VNEUM_OrdenChanged As EventHandler
	Public Event VNEUM_OrdenPosicionChanged As EventHandler
	Public Event VNEUM_InternoExternoChanged As EventHandler
	Public Event VNEUM_RepuestoChanged As EventHandler
	Public Event VNEUM_EstadoChanged As EventHandler
	Public Event VNEUM_KmInicioChanged As EventHandler
	Public Event VNEUM_KmFinChanged As EventHandler

	Public Sub OnVNEUM_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_IdChanged(sender, e)
	End Sub

	Public Sub OnMOVNM_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVNM_IdChanged(sender, e)
	End Sub

	Public Sub OnNEUMA_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_IdChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
	End Sub

	Public Sub OnRANFL_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RANFL_IdChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_FecAsignacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_FecAsignacionChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_FecRetiroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_FecRetiroChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_LadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_LadoChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_SeccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_SeccionChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_OrdenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_OrdenChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_OrdenPosicionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_OrdenPosicionChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_InternoExternoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_InternoExternoChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_RepuestoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_RepuestoChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_EstadoChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_KmInicioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_KmInicioChanged(sender, e)
	End Sub

	Public Sub OnVNEUM_KmFinChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VNEUM_KmFinChanged(sender, e)
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

