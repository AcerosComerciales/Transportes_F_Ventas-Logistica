Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECTRL_ArreglosDetalle

#Region " Campos "
	
	Private m_arreg_codigo As String
	Private m_arrdt_item As Short
	Private m_artic_codigo As String
	Private m_arrdt_cantidad As Decimal
	Private m_arrdt_usrcrea As String
	Private m_arrdt_feccrea As Date
	Private m_arrdt_usrmod As String
	Private m_arrdt_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlCTRL_ArreglosDetalle
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
	
	Public Property ARREG_Codigo() As String
		Get
			return m_arreg_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_arreg_codigo) Then
				If Not m_arreg_codigo.Equals(value) Then
					m_arreg_codigo = value
					OnARREG_CodigoChanged(m_arreg_codigo, EventArgs.Empty)
				End If
			Else
				m_arreg_codigo = value
				OnARREG_CodigoChanged(m_arreg_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARRDT_Item() As Short
		Get
			return m_arrdt_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_arrdt_item) Then
				If Not m_arrdt_item.Equals(value) Then
					m_arrdt_item = value
					OnARRDT_ItemChanged(m_arrdt_item, EventArgs.Empty)
				End If
			Else
				m_arrdt_item = value
				OnARRDT_ItemChanged(m_arrdt_item, EventArgs.Empty)
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

	Public Property ARRDT_Cantidad() As Decimal
		Get
			return m_arrdt_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_arrdt_cantidad) Then
				If Not m_arrdt_cantidad.Equals(value) Then
					m_arrdt_cantidad = value
					OnARRDT_CantidadChanged(m_arrdt_cantidad, EventArgs.Empty)
				End If
			Else
				m_arrdt_cantidad = value
				OnARRDT_CantidadChanged(m_arrdt_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARRDT_UsrCrea() As String
		Get
			return m_arrdt_usrcrea
		End Get
		Set(ByVal value As String)
			m_arrdt_usrcrea = value
		End Set
	End Property

	Public Property ARRDT_FecCrea() As Date
		Get
			return m_arrdt_feccrea
		End Get
		Set(ByVal value As Date)
			m_arrdt_feccrea = value
		End Set
	End Property

	Public Property ARRDT_UsrMod() As String
		Get
			return m_arrdt_usrmod
		End Get
		Set(ByVal value As String)
			m_arrdt_usrmod = value
		End Set
	End Property

	Public Property ARRDT_FecMod() As Date
		Get
			return m_arrdt_fecmod
		End Get
		Set(ByVal value As Date)
			m_arrdt_fecmod = value
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
			Return "CTRL_ArreglosDetalle"
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
	
	Public Event ARREG_CodigoChanged As EventHandler
	Public Event ARRDT_ItemChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event ARRDT_CantidadChanged As EventHandler

	Public Sub OnARREG_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_CodigoChanged(sender, e)
	End Sub

	Public Sub OnARRDT_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARRDT_ItemChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnARRDT_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARRDT_CantidadChanged(sender, e)
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

