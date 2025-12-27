Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECorrelativos

#Region " Campos "
	
	Private m_corre_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_corre_tabla As String
	Private m_corre_ano As String
	Private m_corre_numero As Long
	Private m_corre_descripcion As String
	Private m_corre_usrcrea As String
	Private m_corre_feccrea As Date
	Private m_corre_usrmod As String
	Private m_corre_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlCorrelativos
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
	
	Public Property CORRE_Id() As Long
		Get
			return m_corre_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_corre_id) Then
				If Not m_corre_id.Equals(value) Then
					m_corre_id = value
					OnCORRE_IdChanged(m_corre_id, EventArgs.Empty)
				End If
			Else
				m_corre_id = value
				OnCORRE_IdChanged(m_corre_id, EventArgs.Empty)
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
	Public Property CORRE_Tabla() As String
		Get
			return m_corre_tabla
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_corre_tabla) Then
				If Not m_corre_tabla.Equals(value) Then
					m_corre_tabla = value
					OnCORRE_TablaChanged(m_corre_tabla, EventArgs.Empty)
				End If
			Else
				m_corre_tabla = value
				OnCORRE_TablaChanged(m_corre_tabla, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property CORRE_Ano() As String
		Get
			return m_corre_ano
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_corre_ano) Then
				If Not m_corre_ano.Equals(value) Then
					m_corre_ano = value
					OnCORRE_AnoChanged(m_corre_ano, EventArgs.Empty)
				End If
			Else
				m_corre_ano = value
				OnCORRE_AnoChanged(m_corre_ano, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property CORRE_Numero() As Long
		Get
			return m_corre_numero
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_corre_numero) Then
				If Not m_corre_numero.Equals(value) Then
					m_corre_numero = value
					OnCORRE_NumeroChanged(m_corre_numero, EventArgs.Empty)
				End If
			Else
				m_corre_numero = value
				OnCORRE_NumeroChanged(m_corre_numero, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property CORRE_Descripcion() As String
		Get
			return m_corre_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_corre_descripcion) Then
				If Not m_corre_descripcion.Equals(value) Then
					m_corre_descripcion = value
					OnCORRE_DescripcionChanged(m_corre_descripcion, EventArgs.Empty)
				End If
			Else
				m_corre_descripcion = value
				OnCORRE_DescripcionChanged(m_corre_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property CORRE_UsrCrea() As String
		Get
			return m_corre_usrcrea
		End Get
		Set(ByVal value As String)
			m_corre_usrcrea = value
		End Set
	End Property
	Public Property CORRE_FecCrea() As Date
		Get
			return m_corre_feccrea
		End Get
		Set(ByVal value As Date)
			m_corre_feccrea = value
		End Set
	End Property
	Public Property CORRE_UsrMod() As String
		Get
			return m_corre_usrmod
		End Get
		Set(ByVal value As String)
			m_corre_usrmod = value
		End Set
	End Property
	Public Property CORRE_FecMod() As Date
		Get
			return m_corre_fecmod
		End Get
		Set(ByVal value As Date)
			m_corre_fecmod = value
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
			Return "Correlativos"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event CORRE_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event CORRE_TablaChanged As EventHandler
	Public Event CORRE_AnoChanged As EventHandler
	Public Event CORRE_NumeroChanged As EventHandler
	Public Event CORRE_DescripcionChanged As EventHandler
	Public Sub OnCORRE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CORRE_IdChanged(sender, e)
	End Sub
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnCORRE_TablaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CORRE_TablaChanged(sender, e)
	End Sub
	Public Sub OnCORRE_AnoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CORRE_AnoChanged(sender, e)
	End Sub
	Public Sub OnCORRE_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CORRE_NumeroChanged(sender, e)
	End Sub
	Public Sub OnCORRE_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CORRE_DescripcionChanged(sender, e)
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

