Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_GuiasTransportistaDetalles

#Region " Campos "
	
	Private m_gtran_codigo As String
	Private m_gtdet_item As Short
	Private m_artic_codigo As String
	Private m_gtdet_unidad As String
	Private m_gtdet_descripcion As String
	Private m_gtdet_peso As Double
	Private m_gtdet_cantidad As Double
	Private m_gtdet_estado As String
	Private m_gtdet_usrcrea As String
	Private m_gtdet_feccrea As Date
	Private m_gtdet_usrmod As String
	Private m_gtdet_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_GuiasTransportistaDetalles
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
	
	Public Property GTRAN_Codigo() As String
		Get
			return m_gtran_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gtran_codigo) Then
				If Not m_gtran_codigo.Equals(value) Then
					m_gtran_codigo = value
					OnGTRAN_CodigoChanged(m_gtran_codigo, EventArgs.Empty)
				End If
			Else
				m_gtran_codigo = value
				OnGTRAN_CodigoChanged(m_gtran_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property GTDET_Item() As Short
		Get
			return m_gtdet_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_gtdet_item) Then
				If Not m_gtdet_item.Equals(value) Then
					m_gtdet_item = value
					OnGTDET_ItemChanged(m_gtdet_item, EventArgs.Empty)
				End If
			Else
				m_gtdet_item = value
				OnGTDET_ItemChanged(m_gtdet_item, EventArgs.Empty)
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
	Public Property GTDET_Unidad() As String
		Get
			return m_gtdet_unidad
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gtdet_unidad) Then
				If Not m_gtdet_unidad.Equals(value) Then
					m_gtdet_unidad = value
					OnGTDET_UnidadChanged(m_gtdet_unidad, EventArgs.Empty)
				End If
			Else
				m_gtdet_unidad = value
				OnGTDET_UnidadChanged(m_gtdet_unidad, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property GTDET_Descripcion() As String
		Get
			return m_gtdet_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gtdet_descripcion) Then
				If Not m_gtdet_descripcion.Equals(value) Then
					m_gtdet_descripcion = value
					OnGTDET_DescripcionChanged(m_gtdet_descripcion, EventArgs.Empty)
				End If
			Else
				m_gtdet_descripcion = value
				OnGTDET_DescripcionChanged(m_gtdet_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property GTDET_Peso() As Double
		Get
			return m_gtdet_peso
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_gtdet_peso) Then
				If Not m_gtdet_peso.Equals(value) Then
					m_gtdet_peso = value
					OnGTDET_PesoChanged(m_gtdet_peso, EventArgs.Empty)
				End If
			Else
				m_gtdet_peso = value
				OnGTDET_PesoChanged(m_gtdet_peso, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property GTDET_Cantidad() As Double
		Get
			return m_gtdet_cantidad
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_gtdet_cantidad) Then
				If Not m_gtdet_cantidad.Equals(value) Then
					m_gtdet_cantidad = value
					OnGTDET_CantidadChanged(m_gtdet_cantidad, EventArgs.Empty)
				End If
			Else
				m_gtdet_cantidad = value
				OnGTDET_CantidadChanged(m_gtdet_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property GTDET_Estado() As String
		Get
			return m_gtdet_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gtdet_estado) Then
				If Not m_gtdet_estado.Equals(value) Then
					m_gtdet_estado = value
					OnGTDET_EstadoChanged(m_gtdet_estado, EventArgs.Empty)
				End If
			Else
				m_gtdet_estado = value
				OnGTDET_EstadoChanged(m_gtdet_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property GTDET_UsrCrea() As String
		Get
			return m_gtdet_usrcrea
		End Get
		Set(ByVal value As String)
			m_gtdet_usrcrea = value
		End Set
	End Property
	Public Property GTDET_FecCrea() As Date
		Get
			return m_gtdet_feccrea
		End Get
		Set(ByVal value As Date)
			m_gtdet_feccrea = value
		End Set
	End Property
	Public Property GTDET_UsrMod() As String
		Get
			return m_gtdet_usrmod
		End Get
		Set(ByVal value As String)
			m_gtdet_usrmod = value
		End Set
	End Property
	Public Property GTDET_FecMod() As Date
		Get
			return m_gtdet_fecmod
		End Get
		Set(ByVal value As Date)
			m_gtdet_fecmod = value
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
			Return "TRAN_GuiasTransportistaDetalles"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event GTRAN_CodigoChanged As EventHandler
	Public Event GTDET_ItemChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event GTDET_UnidadChanged As EventHandler
	Public Event GTDET_DescripcionChanged As EventHandler
	Public Event GTDET_PesoChanged As EventHandler
	Public Event GTDET_CantidadChanged As EventHandler
	Public Event GTDET_EstadoChanged As EventHandler
	Public Sub OnGTRAN_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GTRAN_CodigoChanged(sender, e)
	End Sub
	Public Sub OnGTDET_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GTDET_ItemChanged(sender, e)
	End Sub
	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub
	Public Sub OnGTDET_UnidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GTDET_UnidadChanged(sender, e)
	End Sub
	Public Sub OnGTDET_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GTDET_DescripcionChanged(sender, e)
	End Sub
	Public Sub OnGTDET_PesoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GTDET_PesoChanged(sender, e)
	End Sub
	Public Sub OnGTDET_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GTDET_CantidadChanged(sender, e)
	End Sub
	Public Sub OnGTDET_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GTDET_EstadoChanged(sender, e)
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

