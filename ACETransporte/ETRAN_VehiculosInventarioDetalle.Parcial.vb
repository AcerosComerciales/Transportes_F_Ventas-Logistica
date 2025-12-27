Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_VehiculosInventarioDetalle

#Region " Campos "
	
	Private m_vehic_id As Long
	Private m_vehin_id As Long
	Private m_tipos_codobjeto As String
	Private m_vehid_id As Integer
	Private m_tipos_codcategoria As String
	Private m_vehid_observacion As String
	Private m_vehid_existe As Boolean
	Private m_vehid_estado As String
	Private m_vehid_usrcrea As String
	Private m_vehid_feccrea As Date
	Private m_vehid_usrmod As String
	Private m_vehid_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_VehiculosInventarioDetalle
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

	Public Property TIPOS_CodObjeto() As String
		Get
			return m_tipos_codobjeto
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codobjeto) Then
				If Not m_tipos_codobjeto.Equals(value) Then
					m_tipos_codobjeto = value
					OnTIPOS_CodObjetoChanged(m_tipos_codobjeto, EventArgs.Empty)
				End If
			Else
				m_tipos_codobjeto = value
				OnTIPOS_CodObjetoChanged(m_tipos_codobjeto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHID_Id() As Integer
		Get
			return m_vehid_id
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_vehid_id) Then
				If Not m_vehid_id.Equals(value) Then
					m_vehid_id = value
					OnVEHID_IdChanged(m_vehid_id, EventArgs.Empty)
				End If
			Else
				m_vehid_id = value
				OnVEHID_IdChanged(m_vehid_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodCategoria() As String
		Get
			return m_tipos_codcategoria
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codcategoria) Then
				If Not m_tipos_codcategoria.Equals(value) Then
					m_tipos_codcategoria = value
					OnTIPOS_CodCategoriaChanged(m_tipos_codcategoria, EventArgs.Empty)
				End If
			Else
				m_tipos_codcategoria = value
				OnTIPOS_CodCategoriaChanged(m_tipos_codcategoria, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHID_Observacion() As String
		Get
			return m_vehid_observacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehid_observacion) Then
				If Not m_vehid_observacion.Equals(value) Then
					m_vehid_observacion = value
					OnVEHID_ObservacionChanged(m_vehid_observacion, EventArgs.Empty)
				End If
			Else
				m_vehid_observacion = value
				OnVEHID_ObservacionChanged(m_vehid_observacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHID_Existe() As Boolean
		Get
			return m_vehid_existe
		End Get
		Set(ByVal value As Boolean)
			If Not m_vehid_existe.Equals(value) Then
				m_vehid_existe = value
				OnVEHID_ExisteChanged(m_vehid_existe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHID_Estado() As String
		Get
			return m_vehid_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehid_estado) Then
				If Not m_vehid_estado.Equals(value) Then
					m_vehid_estado = value
					OnVEHID_EstadoChanged(m_vehid_estado, EventArgs.Empty)
				End If
			Else
				m_vehid_estado = value
				OnVEHID_EstadoChanged(m_vehid_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHID_UsrCrea() As String
		Get
			return m_vehid_usrcrea
		End Get
		Set(ByVal value As String)
			m_vehid_usrcrea = value
		End Set
	End Property

	Public Property VEHID_FecCrea() As Date
		Get
			return m_vehid_feccrea
		End Get
		Set(ByVal value As Date)
			m_vehid_feccrea = value
		End Set
	End Property

	Public Property VEHID_UsrMod() As String
		Get
			return m_vehid_usrmod
		End Get
		Set(ByVal value As String)
			m_vehid_usrmod = value
		End Set
	End Property

	Public Property VEHID_FecMod() As Date
		Get
			return m_vehid_fecmod
		End Get
		Set(ByVal value As Date)
			m_vehid_fecmod = value
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
			Return "TRAN_VehiculosInventarioDetalle"
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
	Public Event TIPOS_CodObjetoChanged As EventHandler
	Public Event VEHID_IdChanged As EventHandler
	Public Event TIPOS_CodCategoriaChanged As EventHandler
	Public Event VEHID_ObservacionChanged As EventHandler
	Public Event VEHID_ExisteChanged As EventHandler
	Public Event VEHID_EstadoChanged As EventHandler

	Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
	End Sub

	Public Sub OnVEHIN_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIN_IdChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodObjetoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodObjetoChanged(sender, e)
	End Sub

	Public Sub OnVEHID_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHID_IdChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodCategoriaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodCategoriaChanged(sender, e)
	End Sub

	Public Sub OnVEHID_ObservacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHID_ObservacionChanged(sender, e)
	End Sub

	Public Sub OnVEHID_ExisteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHID_ExisteChanged(sender, e)
	End Sub

	Public Sub OnVEHID_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHID_EstadoChanged(sender, e)
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

