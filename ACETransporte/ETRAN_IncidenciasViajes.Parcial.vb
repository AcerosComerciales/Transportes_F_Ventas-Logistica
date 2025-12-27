Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_IncidenciasViajes

#Region " Campos "
	
	Private m_inciv_id As Long
	Private m_viaje_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_inciv_descripcion As String
	Private m_inciv_fecha As Date
	Private m_inciv_accionrealizada As String
	Private m_inciv_usrcrea As String
	Private m_inciv_feccrea As Date
	Private m_inciv_usrmod As String
	Private m_inciv_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_IncidenciasViajes
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
	
	Public Property INCIV_Id() As Long
		Get
			return m_inciv_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_inciv_id) Then
				If Not m_inciv_id.Equals(value) Then
					m_inciv_id = value
					OnINCIV_IdChanged(m_inciv_id, EventArgs.Empty)
				End If
			Else
				m_inciv_id = value
				OnINCIV_IdChanged(m_inciv_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property VIAJE_Id() As Long
		Get
			return m_viaje_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_viaje_id) Then
				If Not m_viaje_id.Equals(value) Then
					m_viaje_id = value
					OnVIAJE_IdChanged(m_viaje_id, EventArgs.Empty)
				End If
			Else
				m_viaje_id = value
				OnVIAJE_IdChanged(m_viaje_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ZONAS_Codigo() As String
		Get
			return m_zonas_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_zonas_codigo) Then
				If Not m_zonas_codigo.Equals(value) Then
					m_zonas_codigo = value
					OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
				End If
			Else
				m_zonas_codigo = value
				OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property SUCUR_Id() As Short
		Get
			return m_sucur_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_sucur_id) Then
				If Not m_sucur_id.Equals(value) Then
					m_sucur_id = value
					OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
				End If
			Else
				m_sucur_id = value
				OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCIV_Descripcion() As String
		Get
			return m_inciv_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_inciv_descripcion) Then
				If Not m_inciv_descripcion.Equals(value) Then
					m_inciv_descripcion = value
					OnINCIV_DescripcionChanged(m_inciv_descripcion, EventArgs.Empty)
				End If
			Else
				m_inciv_descripcion = value
				OnINCIV_DescripcionChanged(m_inciv_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCIV_Fecha() As Date
		Get
			return m_inciv_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_inciv_fecha) Then
				If Not m_inciv_fecha.Equals(value) Then
					m_inciv_fecha = value
					OnINCIV_FechaChanged(m_inciv_fecha, EventArgs.Empty)
				End If
			Else
				m_inciv_fecha = value
				OnINCIV_FechaChanged(m_inciv_fecha, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCIV_AccionRealizada() As String
		Get
			return m_inciv_accionrealizada
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_inciv_accionrealizada) Then
				If Not m_inciv_accionrealizada.Equals(value) Then
					m_inciv_accionrealizada = value
					OnINCIV_AccionRealizadaChanged(m_inciv_accionrealizada, EventArgs.Empty)
				End If
			Else
				m_inciv_accionrealizada = value
				OnINCIV_AccionRealizadaChanged(m_inciv_accionrealizada, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCIV_UsrCrea() As String
		Get
			return m_inciv_usrcrea
		End Get
		Set(ByVal value As String)
			m_inciv_usrcrea = value
		End Set
	End Property
	Public Property INCIV_FecCrea() As Date
		Get
			return m_inciv_feccrea
		End Get
		Set(ByVal value As Date)
			m_inciv_feccrea = value
		End Set
	End Property
	Public Property INCIV_UsrMod() As String
		Get
			return m_inciv_usrmod
		End Get
		Set(ByVal value As String)
			m_inciv_usrmod = value
		End Set
	End Property
	Public Property INCIV_FecMod() As Date
		Get
			return m_inciv_fecmod
		End Get
		Set(ByVal value As Date)
			m_inciv_fecmod = value
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
			Return "TRAN_IncidenciasViajes"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event INCIV_IdChanged As EventHandler
	Public Event VIAJE_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event INCIV_DescripcionChanged As EventHandler
	Public Event INCIV_FechaChanged As EventHandler
	Public Event INCIV_AccionRealizadaChanged As EventHandler
	Public Sub OnINCIV_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCIV_IdChanged(sender, e)
	End Sub
	Public Sub OnVIAJE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VIAJE_IdChanged(sender, e)
	End Sub
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnINCIV_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCIV_DescripcionChanged(sender, e)
	End Sub
	Public Sub OnINCIV_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCIV_FechaChanged(sender, e)
	End Sub
	Public Sub OnINCIV_AccionRealizadaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCIV_AccionRealizadaChanged(sender, e)
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

