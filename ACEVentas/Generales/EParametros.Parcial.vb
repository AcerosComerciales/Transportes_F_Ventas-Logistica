Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EParametros

#Region " Campos "
	
	Private m_parmt_id As String
	Private m_aplic_codigo As String
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_parmt_valor As String
	Private m_parmt_descripcion As String
	Private m_parmt_tipodato As String
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlParametros
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
	
	Public Property PARMT_Id() As String
		Get
			return m_parmt_id
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_parmt_id) Then
				If Not m_parmt_id.Equals(value) Then
					m_parmt_id = value
					OnPARMT_IdChanged(m_parmt_id, EventArgs.Empty)
				End If
			Else
				m_parmt_id = value
				OnPARMT_IdChanged(m_parmt_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property APLIC_Codigo() As String
		Get
			return m_aplic_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_aplic_codigo) Then
				If Not m_aplic_codigo.Equals(value) Then
					m_aplic_codigo = value
					OnAPLIC_CodigoChanged(m_aplic_codigo, EventArgs.Empty)
				End If
			Else
				m_aplic_codigo = value
				OnAPLIC_CodigoChanged(m_aplic_codigo, EventArgs.Empty)
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
	Public Property PARMT_Valor() As String
		Get
			return m_parmt_valor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_parmt_valor) Then
				If Not m_parmt_valor.Equals(value) Then
					m_parmt_valor = value
					OnPARMT_ValorChanged(m_parmt_valor, EventArgs.Empty)
				End If
			Else
				m_parmt_valor = value
				OnPARMT_ValorChanged(m_parmt_valor, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PARMT_Descripcion() As String
		Get
			return m_parmt_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_parmt_descripcion) Then
				If Not m_parmt_descripcion.Equals(value) Then
					m_parmt_descripcion = value
					OnPARMT_DescripcionChanged(m_parmt_descripcion, EventArgs.Empty)
				End If
			Else
				m_parmt_descripcion = value
				OnPARMT_DescripcionChanged(m_parmt_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PARMT_TipoDato() As String
		Get
			return m_parmt_tipodato
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_parmt_tipodato) Then
				If Not m_parmt_tipodato.Equals(value) Then
					m_parmt_tipodato = value
					OnPARMT_TipoDatoChanged(m_parmt_tipodato, EventArgs.Empty)
				End If
			Else
				m_parmt_tipodato = value
				OnPARMT_TipoDatoChanged(m_parmt_tipodato, EventArgs.Empty)
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
			Return "Parametros"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event PARMT_IdChanged As EventHandler
	Public Event APLIC_CodigoChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event PARMT_ValorChanged As EventHandler
	Public Event PARMT_DescripcionChanged As EventHandler
	Public Event PARMT_TipoDatoChanged As EventHandler
	Public Sub OnPARMT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PARMT_IdChanged(sender, e)
	End Sub
	Public Sub OnAPLIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent APLIC_CodigoChanged(sender, e)
	End Sub
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnPARMT_ValorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PARMT_ValorChanged(sender, e)
	End Sub
	Public Sub OnPARMT_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PARMT_DescripcionChanged(sender, e)
	End Sub
	Public Sub OnPARMT_TipoDatoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PARMT_TipoDatoChanged(sender, e)
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

