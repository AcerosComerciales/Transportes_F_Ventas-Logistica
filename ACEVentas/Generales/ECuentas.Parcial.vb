Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECuentas

#Region " Campos "
	
	Private m_cuent_id As Short
	Private m_banco_id As Short
	Private m_tipos_codtipocuenta As String
	Private m_tipos_codtipomoneda As String
	Private m_cuent_numero As String
	Private m_cuent_estado As String
	Private m_cuent_usrcrea As String
	Private m_cuent_feccrea As Date
	Private m_cuent_usrmod As String
	Private m_cuent_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlCuentas
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
	
	Public Property CUENT_Id() As Short
		Get
			return m_cuent_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_cuent_id) Then
				If Not m_cuent_id.Equals(value) Then
					m_cuent_id = value
					OnCUENT_IdChanged(m_cuent_id, EventArgs.Empty)
				End If
			Else
				m_cuent_id = value
				OnCUENT_IdChanged(m_cuent_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property BANCO_Id() As Short
		Get
			return m_banco_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_banco_id) Then
				If Not m_banco_id.Equals(value) Then
					m_banco_id = value
					OnBANCO_IdChanged(m_banco_id, EventArgs.Empty)
				End If
			Else
				m_banco_id = value
				OnBANCO_IdChanged(m_banco_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoCuenta() As String
		Get
			return m_tipos_codtipocuenta
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipocuenta) Then
				If Not m_tipos_codtipocuenta.Equals(value) Then
					m_tipos_codtipocuenta = value
					OnTIPOS_CodTipoCuentaChanged(m_tipos_codtipocuenta, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipocuenta = value
				OnTIPOS_CodTipoCuentaChanged(m_tipos_codtipocuenta, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoMoneda() As String
		Get
			return m_tipos_codtipomoneda
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipomoneda) Then
				If Not m_tipos_codtipomoneda.Equals(value) Then
					m_tipos_codtipomoneda = value
					OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipomoneda = value
				OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CUENT_Numero() As String
		Get
			return m_cuent_numero
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cuent_numero) Then
				If Not m_cuent_numero.Equals(value) Then
					m_cuent_numero = value
					OnCUENT_NumeroChanged(m_cuent_numero, EventArgs.Empty)
				End If
			Else
				m_cuent_numero = value
				OnCUENT_NumeroChanged(m_cuent_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CUENT_Estado() As String
		Get
			return m_cuent_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cuent_estado) Then
				If Not m_cuent_estado.Equals(value) Then
					m_cuent_estado = value
					OnCUENT_EstadoChanged(m_cuent_estado, EventArgs.Empty)
				End If
			Else
				m_cuent_estado = value
				OnCUENT_EstadoChanged(m_cuent_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CUENT_UsrCrea() As String
		Get
			return m_cuent_usrcrea
		End Get
		Set(ByVal value As String)
			m_cuent_usrcrea = value
		End Set
	End Property

	Public Property CUENT_FecCrea() As Date
		Get
			return m_cuent_feccrea
		End Get
		Set(ByVal value As Date)
			m_cuent_feccrea = value
		End Set
	End Property

	Public Property CUENT_UsrMod() As String
		Get
			return m_cuent_usrmod
		End Get
		Set(ByVal value As String)
			m_cuent_usrmod = value
		End Set
	End Property

	Public Property CUENT_FecMod() As Date
		Get
			return m_cuent_fecmod
		End Get
		Set(ByVal value As Date)
			m_cuent_fecmod = value
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
			Return "Cuentas"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event CUENT_IdChanged As EventHandler
	Public Event BANCO_IdChanged As EventHandler
	Public Event TIPOS_CodTipoCuentaChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event CUENT_NumeroChanged As EventHandler
	Public Event CUENT_EstadoChanged As EventHandler

	Public Sub OnCUENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CUENT_IdChanged(sender, e)
	End Sub

	Public Sub OnBANCO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent BANCO_IdChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoCuentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoCuentaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnCUENT_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CUENT_NumeroChanged(sender, e)
	End Sub

	Public Sub OnCUENT_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CUENT_EstadoChanged(sender, e)
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

