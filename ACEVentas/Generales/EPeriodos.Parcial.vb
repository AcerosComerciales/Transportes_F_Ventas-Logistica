Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EPeriodos

#Region " Campos "
	
	Private m_perio_codigo As String
	Private m_perio_descripcion As String
	Private m_perio_stockactivo As Boolean
	Private m_perio_lock As Boolean
	Private m_perio_activo As Boolean
	Private m_perio_usrcrea As String
	Private m_perio_feccrea As Date
	Private m_perio_usrmod As String
	Private m_perio_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlPeriodos
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
	
	Public Property PERIO_Codigo() As String
		Get
			return m_perio_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_perio_codigo) Then
				If Not m_perio_codigo.Equals(value) Then
					m_perio_codigo = value
					OnPERIO_CodigoChanged(m_perio_codigo, EventArgs.Empty)
				End If
			Else
				m_perio_codigo = value
				OnPERIO_CodigoChanged(m_perio_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PERIO_Descripcion() As String
		Get
			return m_perio_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_perio_descripcion) Then
				If Not m_perio_descripcion.Equals(value) Then
					m_perio_descripcion = value
					OnPERIO_DescripcionChanged(m_perio_descripcion, EventArgs.Empty)
				End If
			Else
				m_perio_descripcion = value
				OnPERIO_DescripcionChanged(m_perio_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PERIO_StockActivo() As Boolean
		Get
			return m_perio_stockactivo
		End Get
		Set(ByVal value As Boolean)
			If Not m_perio_stockactivo.Equals(value) Then
				m_perio_stockactivo = value
				OnPERIO_StockActivoChanged(m_perio_stockactivo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PERIO_Lock() As Boolean
		Get
			return m_perio_lock
		End Get
		Set(ByVal value As Boolean)
			If Not m_perio_lock.Equals(value) Then
				m_perio_lock = value
				OnPERIO_LockChanged(m_perio_lock, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PERIO_Activo() As Boolean
		Get
			return m_perio_activo
		End Get
		Set(ByVal value As Boolean)
			If Not m_perio_activo.Equals(value) Then
				m_perio_activo = value
				OnPERIO_ActivoChanged(m_perio_activo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PERIO_UsrCrea() As String
		Get
			return m_perio_usrcrea
		End Get
		Set(ByVal value As String)
			m_perio_usrcrea = value
		End Set
	End Property

	Public Property PERIO_FecCrea() As Date
		Get
			return m_perio_feccrea
		End Get
		Set(ByVal value As Date)
			m_perio_feccrea = value
		End Set
	End Property

	Public Property PERIO_UsrMod() As String
		Get
			return m_perio_usrmod
		End Get
		Set(ByVal value As String)
			m_perio_usrmod = value
		End Set
	End Property

	Public Property PERIO_FecMod() As Date
		Get
			return m_perio_fecmod
		End Get
		Set(ByVal value As Date)
			m_perio_fecmod = value
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
			Return "Periodos"
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
	
	Public Event PERIO_CodigoChanged As EventHandler
	Public Event PERIO_DescripcionChanged As EventHandler
	Public Event PERIO_StockActivoChanged As EventHandler
	Public Event PERIO_LockChanged As EventHandler
	Public Event PERIO_ActivoChanged As EventHandler

	Public Sub OnPERIO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PERIO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPERIO_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PERIO_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnPERIO_StockActivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PERIO_StockActivoChanged(sender, e)
	End Sub

	Public Sub OnPERIO_LockChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PERIO_LockChanged(sender, e)
	End Sub

	Public Sub OnPERIO_ActivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PERIO_ActivoChanged(sender, e)
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

