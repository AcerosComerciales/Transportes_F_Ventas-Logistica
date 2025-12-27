Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ELOG_StockIniciales

#Region " Campos "
	
	Private m_perio_codigo As String
	Private m_artic_codigo As String
	Private m_stini_id As Long
	Private m_stini_cantidad As Decimal
	Private m_stini_fecha As Date
	Private m_stini_usrcrea As String
	Private m_stini_feccrea As Date
	Private m_stini_usrmod As String
	Private m_syini_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlLOG_StockIniciales
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
	
	Public Property PERIO_Codigo() As String
		Get
			return m_perio_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_perio_codigo) Then
				If Not m_perio_codigo.Equals(value) Then
					m_perio_codigo = value
					OnPERIO_CodigoChanged(m_perio_codigo, EventArgs.Empty)
				End If
			Else
				m_perio_codigo = value
				OnPERIO_CodigoChanged(m_perio_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Codigo() As String
		Get
			return m_artic_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_codigo) Then
				If Not m_artic_codigo.Equals(value) Then
					m_artic_codigo = value
					OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
				End If
			Else
				m_artic_codigo = value
				OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property STINI_Id() As Long
		Get
			return m_stini_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_stini_id) Then
				If Not m_stini_id.Equals(value) Then
					m_stini_id = value
					OnSTINI_IdChanged(m_stini_id, EventArgs.Empty)
				End If
			Else
				m_stini_id = value
				OnSTINI_IdChanged(m_stini_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property STINI_Cantidad() As Decimal
		Get
			return m_stini_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_stini_cantidad) Then
				If Not m_stini_cantidad.Equals(value) Then
					m_stini_cantidad = value
					OnSTINI_CantidadChanged(m_stini_cantidad, EventArgs.Empty)
				End If
			Else
				m_stini_cantidad = value
				OnSTINI_CantidadChanged(m_stini_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property STINI_Fecha() As Date
		Get
			return m_stini_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_stini_fecha) Then
				If Not m_stini_fecha.Equals(value) Then
					m_stini_fecha = value
					OnSTINI_FechaChanged(m_stini_fecha, EventArgs.Empty)
				End If
			Else
				m_stini_fecha = value
				OnSTINI_FechaChanged(m_stini_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property STINI_UsrCrea() As String
		Get
			return m_stini_usrcrea
		End Get
		Set(ByVal value As String)
			m_stini_usrcrea = value
		End Set
	End Property

	Public Property STINI_FecCrea() As Date
		Get
			return m_stini_feccrea
		End Get
		Set(ByVal value As Date)
			m_stini_feccrea = value
		End Set
	End Property

	Public Property STINI_UsrMod() As String
		Get
			return m_stini_usrmod
		End Get
		Set(ByVal value As String)
			m_stini_usrmod = value
		End Set
	End Property

	Public Property SYINI_FecMod() As Date
		Get
			return m_syini_fecmod
		End Get
		Set(ByVal value As Date)
			m_syini_fecmod = value
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
			Return "LOG_StockIniciales"
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
	
	Public Event PERIO_CodigoChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event STINI_IdChanged As EventHandler
	Public Event STINI_CantidadChanged As EventHandler
	Public Event STINI_FechaChanged As EventHandler

	Public Sub OnPERIO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PERIO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnSTINI_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent STINI_IdChanged(sender, e)
	End Sub

	Public Sub OnSTINI_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent STINI_CantidadChanged(sender, e)
	End Sub

	Public Sub OnSTINI_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent STINI_FechaChanged(sender, e)
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

