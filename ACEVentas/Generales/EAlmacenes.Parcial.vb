Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EAlmacenes

#Region " Campos "
	
	Private m_almac_id As Short
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_tipos_codtipoalmacen As String
	Private m_almac_descripcion As String
	Private m_almac_direccion As String
	Private m_almac_activo As Boolean
	Private m_almac_desccorta As String
	Private m_almac_usrcrea As String
	Private m_almac_feccrea As Date
	Private m_almac_usrmod As String
	Private m_almac_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlAlmacenes
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
	
	Public Property ALMAC_Id() As Short
		Get
			return m_almac_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_almac_id) Then
				If Not m_almac_id.Equals(value) Then
					m_almac_id = value
					OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
				End If
			Else
				m_almac_id = value
				OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
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

	Public Property TIPOS_CodTipoAlmacen() As String
		Get
			return m_tipos_codtipoalmacen
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipoalmacen) Then
				If Not m_tipos_codtipoalmacen.Equals(value) Then
					m_tipos_codtipoalmacen = value
					OnTIPOS_CodTipoAlmacenChanged(m_tipos_codtipoalmacen, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipoalmacen = value
				OnTIPOS_CodTipoAlmacenChanged(m_tipos_codtipoalmacen, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ALMAC_Descripcion() As String
		Get
			return m_almac_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_almac_descripcion) Then
				If Not m_almac_descripcion.Equals(value) Then
					m_almac_descripcion = value
					OnALMAC_DescripcionChanged(m_almac_descripcion, EventArgs.Empty)
				End If
			Else
				m_almac_descripcion = value
				OnALMAC_DescripcionChanged(m_almac_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ALMAC_Direccion() As String
		Get
			return m_almac_direccion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_almac_direccion) Then
				If Not m_almac_direccion.Equals(value) Then
					m_almac_direccion = value
					OnALMAC_DireccionChanged(m_almac_direccion, EventArgs.Empty)
				End If
			Else
				m_almac_direccion = value
				OnALMAC_DireccionChanged(m_almac_direccion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ALMAC_Activo() As Boolean
		Get
			return m_almac_activo
		End Get
		Set(ByVal value As Boolean)
			If Not m_almac_activo.Equals(value) Then
				m_almac_activo = value
				OnALMAC_ActivoChanged(m_almac_activo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ALMAC_DescCorta() As String
		Get
			return m_almac_desccorta
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_almac_desccorta) Then
				If Not m_almac_desccorta.Equals(value) Then
					m_almac_desccorta = value
					OnALMAC_DescCortaChanged(m_almac_desccorta, EventArgs.Empty)
				End If
			Else
				m_almac_desccorta = value
				OnALMAC_DescCortaChanged(m_almac_desccorta, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ALMAC_UsrCrea() As String
		Get
			return m_almac_usrcrea
		End Get
		Set(ByVal value As String)
			m_almac_usrcrea = value
		End Set
	End Property

	Public Property ALMAC_FecCrea() As Date
		Get
			return m_almac_feccrea
		End Get
		Set(ByVal value As Date)
			m_almac_feccrea = value
		End Set
	End Property

	Public Property ALMAC_UsrMod() As String
		Get
			return m_almac_usrmod
		End Get
		Set(ByVal value As String)
			m_almac_usrmod = value
		End Set
	End Property

	Public Property ALMAC_FecMod() As Date
		Get
			return m_almac_fecmod
		End Get
		Set(ByVal value As Date)
			m_almac_fecmod = value
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
			Return "Almacenes"
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
	
	Public Event ALMAC_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event TIPOS_CodTipoAlmacenChanged As EventHandler
	Public Event ALMAC_DescripcionChanged As EventHandler
	Public Event ALMAC_DireccionChanged As EventHandler
	Public Event ALMAC_ActivoChanged As EventHandler
	Public Event ALMAC_DescCortaChanged As EventHandler

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoAlmacenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoAlmacenChanged(sender, e)
	End Sub

	Public Sub OnALMAC_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnALMAC_DireccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_DireccionChanged(sender, e)
	End Sub

	Public Sub OnALMAC_ActivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_ActivoChanged(sender, e)
	End Sub

	Public Sub OnALMAC_DescCortaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_DescCortaChanged(sender, e)
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

