Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EVENT_ProductoAdicionales

#Region " Campos "
	
	Private m_artic_codigo As String
	Private m_artic_cuenta As String
	Private m_artic_cuentacos As String
	Private m_artic_cuentacar As String
	Private m_artic_cuentaabo As String
	Private m_artic_cuentavta As String
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlVENT_ProductoAdicionales
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
	Public Property ARTIC_Cuenta() As String
		Get
			return m_artic_cuenta
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_cuenta) Then
				If Not m_artic_cuenta.Equals(value) Then
					m_artic_cuenta = value
					OnARTIC_CuentaChanged(m_artic_cuenta, EventArgs.Empty)
				End If
			Else
				m_artic_cuenta = value
				OnARTIC_CuentaChanged(m_artic_cuenta, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ARTIC_CuentaCos() As String
		Get
			return m_artic_cuentacos
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_cuentacos) Then
				If Not m_artic_cuentacos.Equals(value) Then
					m_artic_cuentacos = value
					OnARTIC_CuentaCosChanged(m_artic_cuentacos, EventArgs.Empty)
				End If
			Else
				m_artic_cuentacos = value
				OnARTIC_CuentaCosChanged(m_artic_cuentacos, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ARTIC_CuentaCar() As String
		Get
			return m_artic_cuentacar
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_cuentacar) Then
				If Not m_artic_cuentacar.Equals(value) Then
					m_artic_cuentacar = value
					OnARTIC_CuentaCarChanged(m_artic_cuentacar, EventArgs.Empty)
				End If
			Else
				m_artic_cuentacar = value
				OnARTIC_CuentaCarChanged(m_artic_cuentacar, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ARTIC_CuentaAbo() As String
		Get
			return m_artic_cuentaabo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_cuentaabo) Then
				If Not m_artic_cuentaabo.Equals(value) Then
					m_artic_cuentaabo = value
					OnARTIC_CuentaAboChanged(m_artic_cuentaabo, EventArgs.Empty)
				End If
			Else
				m_artic_cuentaabo = value
				OnARTIC_CuentaAboChanged(m_artic_cuentaabo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ARTIC_CuentaVta() As String
		Get
			return m_artic_cuentavta
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_cuentavta) Then
				If Not m_artic_cuentavta.Equals(value) Then
					m_artic_cuentavta = value
					OnARTIC_CuentaVtaChanged(m_artic_cuentavta, EventArgs.Empty)
				End If
			Else
				m_artic_cuentavta = value
				OnARTIC_CuentaVtaChanged(m_artic_cuentavta, EventArgs.Empty)
			End If
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
			Return "VENT_ProductoAdicionales"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Ventas"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event ARTIC_CuentaChanged As EventHandler
	Public Event ARTIC_CuentaCosChanged As EventHandler
	Public Event ARTIC_CuentaCarChanged As EventHandler
	Public Event ARTIC_CuentaAboChanged As EventHandler
	Public Event ARTIC_CuentaVtaChanged As EventHandler
	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub
	Public Sub OnARTIC_CuentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CuentaChanged(sender, e)
	End Sub
	Public Sub OnARTIC_CuentaCosChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CuentaCosChanged(sender, e)
	End Sub
	Public Sub OnARTIC_CuentaCarChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CuentaCarChanged(sender, e)
	End Sub
	Public Sub OnARTIC_CuentaAboChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CuentaAboChanged(sender, e)
	End Sub
	Public Sub OnARTIC_CuentaVtaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CuentaVtaChanged(sender, e)
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

