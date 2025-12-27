Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETipos

#Region " Campos "
	
	Private m_tipos_codigo As String
	Private m_tipos_descripcion As String
	Private m_tipos_desclarga As String
	Private m_tipos_desccorta As String
	Private m_tipos_desc2 As String
	Private m_tipos_numero As Decimal
	Private m_tipos_estado As String
	Private m_tipos_protegido As Boolean
	Private m_tipos_nventas As Short
	Private m_tipos_nlogistica As Short
	Private m_tipos_lserie As Short
	Private m_tipos_lnumero As Short
	Private m_tipos_items As Short
	Private m_tipos_usrcrea As String
	Private m_tipos_feccrea As Date
	Private m_tipos_usrmod As String
	Private m_tipos_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTipos
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
	
	Public Property TIPOS_Codigo() As String
		Get
			return m_tipos_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codigo) Then
				If Not m_tipos_codigo.Equals(value) Then
					m_tipos_codigo = value
					OnTIPOS_CodigoChanged(m_tipos_codigo, EventArgs.Empty)
				End If
			Else
				m_tipos_codigo = value
				OnTIPOS_CodigoChanged(m_tipos_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Descripcion() As String
		Get
			return m_tipos_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_descripcion) Then
				If Not m_tipos_descripcion.Equals(value) Then
					m_tipos_descripcion = value
					OnTIPOS_DescripcionChanged(m_tipos_descripcion, EventArgs.Empty)
				End If
			Else
				m_tipos_descripcion = value
				OnTIPOS_DescripcionChanged(m_tipos_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_DescLarga() As String
		Get
			return m_tipos_desclarga
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_desclarga) Then
				If Not m_tipos_desclarga.Equals(value) Then
					m_tipos_desclarga = value
					OnTIPOS_DescLargaChanged(m_tipos_desclarga, EventArgs.Empty)
				End If
			Else
				m_tipos_desclarga = value
				OnTIPOS_DescLargaChanged(m_tipos_desclarga, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_DescCorta() As String
		Get
			return m_tipos_desccorta
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_desccorta) Then
				If Not m_tipos_desccorta.Equals(value) Then
					m_tipos_desccorta = value
					OnTIPOS_DescCortaChanged(m_tipos_desccorta, EventArgs.Empty)
				End If
			Else
				m_tipos_desccorta = value
				OnTIPOS_DescCortaChanged(m_tipos_desccorta, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Desc2() As String
		Get
			return m_tipos_desc2
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_desc2) Then
				If Not m_tipos_desc2.Equals(value) Then
					m_tipos_desc2 = value
					OnTIPOS_Desc2Changed(m_tipos_desc2, EventArgs.Empty)
				End If
			Else
				m_tipos_desc2 = value
				OnTIPOS_Desc2Changed(m_tipos_desc2, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Numero() As Decimal
		Get
			return m_tipos_numero
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tipos_numero) Then
				If Not m_tipos_numero.Equals(value) Then
					m_tipos_numero = value
					OnTIPOS_NumeroChanged(m_tipos_numero, EventArgs.Empty)
				End If
			Else
				m_tipos_numero = value
				OnTIPOS_NumeroChanged(m_tipos_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Estado() As String
		Get
			return m_tipos_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_estado) Then
				If Not m_tipos_estado.Equals(value) Then
					m_tipos_estado = value
					OnTIPOS_EstadoChanged(m_tipos_estado, EventArgs.Empty)
				End If
			Else
				m_tipos_estado = value
				OnTIPOS_EstadoChanged(m_tipos_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Protegido() As Boolean
		Get
			return m_tipos_protegido
		End Get
		Set(ByVal value As Boolean)
			If Not m_tipos_protegido.Equals(value) Then
				m_tipos_protegido = value
				OnTIPOS_ProtegidoChanged(m_tipos_protegido, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_NVentas() As Short
		Get
			return m_tipos_nventas
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_nventas) Then
				If Not m_tipos_nventas.Equals(value) Then
					m_tipos_nventas = value
					OnTIPOS_NVentasChanged(m_tipos_nventas, EventArgs.Empty)
				End If
			Else
				m_tipos_nventas = value
				OnTIPOS_NVentasChanged(m_tipos_nventas, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_NLogistica() As Short
		Get
			return m_tipos_nlogistica
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_nlogistica) Then
				If Not m_tipos_nlogistica.Equals(value) Then
					m_tipos_nlogistica = value
					OnTIPOS_NLogisticaChanged(m_tipos_nlogistica, EventArgs.Empty)
				End If
			Else
				m_tipos_nlogistica = value
				OnTIPOS_NLogisticaChanged(m_tipos_nlogistica, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_LSerie() As Short
		Get
            Return m_tipos_lserie
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_lserie) Then
				If Not m_tipos_lserie.Equals(value) Then
					m_tipos_lserie = value
					OnTIPOS_LSerieChanged(m_tipos_lserie, EventArgs.Empty)
				End If
			Else
				m_tipos_lserie = value
				OnTIPOS_LSerieChanged(m_tipos_lserie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_LNumero() As Short
		Get
			return m_tipos_lnumero
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_lnumero) Then
				If Not m_tipos_lnumero.Equals(value) Then
					m_tipos_lnumero = value
					OnTIPOS_LNumeroChanged(m_tipos_lnumero, EventArgs.Empty)
				End If
			Else
				m_tipos_lnumero = value
				OnTIPOS_LNumeroChanged(m_tipos_lnumero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Items() As Short
		Get
			return m_tipos_items
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_items) Then
				If Not m_tipos_items.Equals(value) Then
					m_tipos_items = value
					OnTIPOS_ItemsChanged(m_tipos_items, EventArgs.Empty)
				End If
			Else
				m_tipos_items = value
				OnTIPOS_ItemsChanged(m_tipos_items, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_UsrCrea() As String
		Get
			return m_tipos_usrcrea
		End Get
		Set(ByVal value As String)
			m_tipos_usrcrea = value
		End Set
	End Property

	Public Property TIPOS_FecCrea() As Date
		Get
			return m_tipos_feccrea
		End Get
		Set(ByVal value As Date)
			m_tipos_feccrea = value
		End Set
	End Property

	Public Property TIPOS_UsrMod() As String
		Get
			return m_tipos_usrmod
		End Get
		Set(ByVal value As String)
			m_tipos_usrmod = value
		End Set
	End Property

	Public Property TIPOS_FecMod() As Date
		Get
			return m_tipos_fecmod
		End Get
		Set(ByVal value As Date)
			m_tipos_fecmod = value
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
			Return "Tipos"
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
	
	Public Event TIPOS_CodigoChanged As EventHandler
	Public Event TIPOS_DescripcionChanged As EventHandler
	Public Event TIPOS_DescLargaChanged As EventHandler
	Public Event TIPOS_DescCortaChanged As EventHandler
	Public Event TIPOS_Desc2Changed As EventHandler
	Public Event TIPOS_NumeroChanged As EventHandler
	Public Event TIPOS_EstadoChanged As EventHandler
	Public Event TIPOS_ProtegidoChanged As EventHandler
	Public Event TIPOS_NVentasChanged As EventHandler
	Public Event TIPOS_NLogisticaChanged As EventHandler
	Public Event TIPOS_LSerieChanged As EventHandler
	Public Event TIPOS_LNumeroChanged As EventHandler
	Public Event TIPOS_ItemsChanged As EventHandler

	Public Sub OnTIPOS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_DescLargaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_DescLargaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_DescCortaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_DescCortaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_Desc2Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_Desc2Changed(sender, e)
	End Sub

	Public Sub OnTIPOS_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_NumeroChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_EstadoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_ProtegidoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_ProtegidoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_NVentasChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_NVentasChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_NLogisticaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_NLogisticaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_LSerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_LSerieChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_LNumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_LNumeroChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_ItemsChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_ItemsChanged(sender, e)
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

