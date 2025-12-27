Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECTRL_InventarioRotativo

#Region " Campos "
	
	Private m_inrot_codigo As String
	Private m_entid_codigoresponsable As String
	Private m_inrot_serie As String
	Private m_inrot_numero As Integer
	Private m_inrot_fecha As Date
	Private m_inrot_estado As String
	Private m_inrot_observaciones As String
	Private m_inrot_usrcrea As String
	Private m_inrot_feccrea As Date
	Private m_inrot_usrmod As String
	Private m_inrot_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlCTRL_InventarioRotativo
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
	
	Public Property INROT_Codigo() As String
		Get
			return m_inrot_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_inrot_codigo) Then
				If Not m_inrot_codigo.Equals(value) Then
					m_inrot_codigo = value
					OnINROT_CodigoChanged(m_inrot_codigo, EventArgs.Empty)
				End If
			Else
				m_inrot_codigo = value
				OnINROT_CodigoChanged(m_inrot_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodigoResponsable() As String
		Get
			return m_entid_codigoresponsable
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoresponsable) Then
				If Not m_entid_codigoresponsable.Equals(value) Then
					m_entid_codigoresponsable = value
					OnENTID_CodigoResponsableChanged(m_entid_codigoresponsable, EventArgs.Empty)
				End If
			Else
				m_entid_codigoresponsable = value
				OnENTID_CodigoResponsableChanged(m_entid_codigoresponsable, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROT_Serie() As String
		Get
			return m_inrot_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_inrot_serie) Then
				If Not m_inrot_serie.Equals(value) Then
					m_inrot_serie = value
					OnINROT_SerieChanged(m_inrot_serie, EventArgs.Empty)
				End If
			Else
				m_inrot_serie = value
				OnINROT_SerieChanged(m_inrot_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROT_Numero() As Integer
		Get
			return m_inrot_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_inrot_numero) Then
				If Not m_inrot_numero.Equals(value) Then
					m_inrot_numero = value
					OnINROT_NumeroChanged(m_inrot_numero, EventArgs.Empty)
				End If
			Else
				m_inrot_numero = value
				OnINROT_NumeroChanged(m_inrot_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROT_Fecha() As Date
		Get
			return m_inrot_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_inrot_fecha) Then
				If Not m_inrot_fecha.Equals(value) Then
					m_inrot_fecha = value
					OnINROT_FechaChanged(m_inrot_fecha, EventArgs.Empty)
				End If
			Else
				m_inrot_fecha = value
				OnINROT_FechaChanged(m_inrot_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROT_Estado() As String
		Get
			return m_inrot_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_inrot_estado) Then
				If Not m_inrot_estado.Equals(value) Then
					m_inrot_estado = value
					OnINROT_EstadoChanged(m_inrot_estado, EventArgs.Empty)
				End If
			Else
				m_inrot_estado = value
				OnINROT_EstadoChanged(m_inrot_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROT_Observaciones() As String
		Get
			return m_inrot_observaciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_inrot_observaciones) Then
				If Not m_inrot_observaciones.Equals(value) Then
					m_inrot_observaciones = value
					OnINROT_ObservacionesChanged(m_inrot_observaciones, EventArgs.Empty)
				End If
			Else
				m_inrot_observaciones = value
				OnINROT_ObservacionesChanged(m_inrot_observaciones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROT_UsrCrea() As String
		Get
			return m_inrot_usrcrea
		End Get
		Set(ByVal value As String)
			m_inrot_usrcrea = value
		End Set
	End Property

	Public Property INROT_FecCrea() As Date
		Get
			return m_inrot_feccrea
		End Get
		Set(ByVal value As Date)
			m_inrot_feccrea = value
		End Set
	End Property

	Public Property INROT_UsrMod() As String
		Get
			return m_inrot_usrmod
		End Get
		Set(ByVal value As String)
			m_inrot_usrmod = value
		End Set
	End Property

	Public Property INROT_FecMod() As Date
		Get
			return m_inrot_fecmod
		End Get
		Set(ByVal value As Date)
			m_inrot_fecmod = value
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
			Return "CTRL_InventarioRotativo"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Logistica"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event INROT_CodigoChanged As EventHandler
	Public Event ENTID_CodigoResponsableChanged As EventHandler
	Public Event INROT_SerieChanged As EventHandler
	Public Event INROT_NumeroChanged As EventHandler
	Public Event INROT_FechaChanged As EventHandler
	Public Event INROT_EstadoChanged As EventHandler
	Public Event INROT_ObservacionesChanged As EventHandler

	Public Sub OnINROT_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROT_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoResponsableChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoResponsableChanged(sender, e)
	End Sub

	Public Sub OnINROT_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROT_SerieChanged(sender, e)
	End Sub

	Public Sub OnINROT_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROT_NumeroChanged(sender, e)
	End Sub

	Public Sub OnINROT_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROT_FechaChanged(sender, e)
	End Sub

	Public Sub OnINROT_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROT_EstadoChanged(sender, e)
	End Sub

	Public Sub OnINROT_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROT_ObservacionesChanged(sender, e)
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

