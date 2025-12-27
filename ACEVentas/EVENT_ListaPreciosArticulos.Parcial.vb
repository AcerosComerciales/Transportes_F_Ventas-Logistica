Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EVENT_ListaPreciosArticulos

#Region " Campos "
	
	Private m_zonas_codigo As String
	Private m_lprec_id As Long
	Private m_artic_codigo As String
	Private m_alpre_constante As Decimal
	Private m_alpre_porcentaventa As Decimal
	Private m_alpre_usrcrea As String
	Private m_alpre_feccrea As Date
	Private m_alpre_usrmod As String
	Private m_alpre_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlVENT_ListaPreciosArticulos
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

	Public Property LPREC_Id() As Long
		Get
			return m_lprec_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_lprec_id) Then
				If Not m_lprec_id.Equals(value) Then
					m_lprec_id = value
					OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
				End If
			Else
				m_lprec_id = value
				OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
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

	Public Property ALPRE_Constante() As Decimal
		Get
			return m_alpre_constante
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_alpre_constante) Then
				If Not m_alpre_constante.Equals(value) Then
					m_alpre_constante = value
					OnALPRE_ConstanteChanged(m_alpre_constante, EventArgs.Empty)
				End If
			Else
				m_alpre_constante = value
				OnALPRE_ConstanteChanged(m_alpre_constante, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ALPRE_PorcentaVenta() As Decimal
		Get
			return m_alpre_porcentaventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_alpre_porcentaventa) Then
				If Not m_alpre_porcentaventa.Equals(value) Then
					m_alpre_porcentaventa = value
					OnALPRE_PorcentaVentaChanged(m_alpre_porcentaventa, EventArgs.Empty)
				End If
			Else
				m_alpre_porcentaventa = value
				OnALPRE_PorcentaVentaChanged(m_alpre_porcentaventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ALPRE_UsrCrea() As String
		Get
			return m_alpre_usrcrea
		End Get
		Set(ByVal value As String)
			m_alpre_usrcrea = value
		End Set
	End Property

	Public Property ALPRE_FecCrea() As Date
		Get
			return m_alpre_feccrea
		End Get
		Set(ByVal value As Date)
			m_alpre_feccrea = value
		End Set
	End Property

	Public Property ALPRE_UsrMod() As String
		Get
			return m_alpre_usrmod
		End Get
		Set(ByVal value As String)
			m_alpre_usrmod = value
		End Set
	End Property

	Public Property ALPRE_FecMod() As Date
		Get
			return m_alpre_fecmod
		End Get
		Set(ByVal value As Date)
			m_alpre_fecmod = value
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
			Return "VENT_ListaPreciosArticulos"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Ventas"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event LPREC_IdChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event ALPRE_ConstanteChanged As EventHandler
	Public Event ALPRE_PorcentaVentaChanged As EventHandler

	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnLPREC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent LPREC_IdChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnALPRE_ConstanteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALPRE_ConstanteChanged(sender, e)
	End Sub

	Public Sub OnALPRE_PorcentaVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALPRE_PorcentaVentaChanged(sender, e)
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

