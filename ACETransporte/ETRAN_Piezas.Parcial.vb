Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Piezas

#Region " Campos "
	
	Private m_pieza_id As Long
	Private m_pieza_codigo As String
	Private m_pieza_descripcion As String
	Private m_pieza_marca As String
	Private m_pieza_imagen As Byte()
	Private m_pieza_estado As String
	Private m_pieza_clasificacion As String
	Private m_pieza_usrcrea As String
	Private m_pieza_feccrea As Date
	Private m_pieza_usrmod As String
	Private m_pieza_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_Piezas
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
	
	Public Property PIEZA_Id() As Long
		Get
			return m_pieza_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pieza_id) Then
				If Not m_pieza_id.Equals(value) Then
					m_pieza_id = value
					OnPIEZA_IdChanged(m_pieza_id, EventArgs.Empty)
				End If
			Else
				m_pieza_id = value
				OnPIEZA_IdChanged(m_pieza_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PIEZA_Codigo() As String
		Get
			return m_pieza_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pieza_codigo) Then
				If Not m_pieza_codigo.Equals(value) Then
					m_pieza_codigo = value
					OnPIEZA_CodigoChanged(m_pieza_codigo, EventArgs.Empty)
				End If
			Else
				m_pieza_codigo = value
				OnPIEZA_CodigoChanged(m_pieza_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PIEZA_Descripcion() As String
		Get
			return m_pieza_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pieza_descripcion) Then
				If Not m_pieza_descripcion.Equals(value) Then
					m_pieza_descripcion = value
					OnPIEZA_DescripcionChanged(m_pieza_descripcion, EventArgs.Empty)
				End If
			Else
				m_pieza_descripcion = value
				OnPIEZA_DescripcionChanged(m_pieza_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PIEZA_Marca() As String
		Get
			return m_pieza_marca
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pieza_marca) Then
				If Not m_pieza_marca.Equals(value) Then
					m_pieza_marca = value
					OnPIEZA_MarcaChanged(m_pieza_marca, EventArgs.Empty)
				End If
			Else
				m_pieza_marca = value
				OnPIEZA_MarcaChanged(m_pieza_marca, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PIEZA_Imagen() As Byte()
		Get
			return m_pieza_imagen
		End Get
		Set(ByVal value As Byte())
			If Not IsNothing(m_pieza_imagen) Then
				If Not m_pieza_imagen.Equals(value) Then
					m_pieza_imagen = value
					OnPIEZA_ImagenChanged(m_pieza_imagen, EventArgs.Empty)
				End If
			Else
				m_pieza_imagen = value
				OnPIEZA_ImagenChanged(m_pieza_imagen, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PIEZA_Estado() As String
		Get
			return m_pieza_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pieza_estado) Then
				If Not m_pieza_estado.Equals(value) Then
					m_pieza_estado = value
					OnPIEZA_EstadoChanged(m_pieza_estado, EventArgs.Empty)
				End If
			Else
				m_pieza_estado = value
				OnPIEZA_EstadoChanged(m_pieza_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PIEZA_Clasificacion() As String
		Get
			return m_pieza_clasificacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pieza_clasificacion) Then
				If Not m_pieza_clasificacion.Equals(value) Then
					m_pieza_clasificacion = value
					OnPIEZA_ClasificacionChanged(m_pieza_clasificacion, EventArgs.Empty)
				End If
			Else
				m_pieza_clasificacion = value
				OnPIEZA_ClasificacionChanged(m_pieza_clasificacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PIEZA_UsrCrea() As String
		Get
			return m_pieza_usrcrea
		End Get
		Set(ByVal value As String)
			m_pieza_usrcrea = value
		End Set
	End Property

	Public Property PIEZA_FecCrea() As Date
		Get
			return m_pieza_feccrea
		End Get
		Set(ByVal value As Date)
			m_pieza_feccrea = value
		End Set
	End Property

	Public Property PIEZA_UsrMod() As String
		Get
			return m_pieza_usrmod
		End Get
		Set(ByVal value As String)
			m_pieza_usrmod = value
		End Set
	End Property

	Public Property PIEZA_FecMod() As Date
		Get
			return m_pieza_fecmod
		End Get
		Set(ByVal value As Date)
			m_pieza_fecmod = value
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
			Return "TRAN_Piezas"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event PIEZA_IdChanged As EventHandler
	Public Event PIEZA_CodigoChanged As EventHandler
	Public Event PIEZA_DescripcionChanged As EventHandler
	Public Event PIEZA_MarcaChanged As EventHandler
	Public Event PIEZA_ImagenChanged As EventHandler
	Public Event PIEZA_EstadoChanged As EventHandler
	Public Event PIEZA_ClasificacionChanged As EventHandler

	Public Sub OnPIEZA_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PIEZA_IdChanged(sender, e)
	End Sub

	Public Sub OnPIEZA_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PIEZA_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPIEZA_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PIEZA_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnPIEZA_MarcaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PIEZA_MarcaChanged(sender, e)
	End Sub

	Public Sub OnPIEZA_ImagenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PIEZA_ImagenChanged(sender, e)
	End Sub

	Public Sub OnPIEZA_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PIEZA_EstadoChanged(sender, e)
	End Sub

	Public Sub OnPIEZA_ClasificacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PIEZA_ClasificacionChanged(sender, e)
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

