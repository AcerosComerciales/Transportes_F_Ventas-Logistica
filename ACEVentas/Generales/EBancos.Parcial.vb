Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EBancos

#Region " Campos "
	
	Private m_banco_id As Short
    Private m_banco_descripcion As String
    Private m_banco_DescCorta As String
	Private m_banco_protegido As Boolean
	Private m_banco_usrcrea As String
	Private m_banco_feccrea As Date
	Private m_banco_usrmod As String
	Private m_banco_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlBancos
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
	Public Property BANCO_Descripcion() As String
		Get
			return m_banco_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_banco_descripcion) Then
				If Not m_banco_descripcion.Equals(value) Then
					m_banco_descripcion = value
					OnBANCO_DescripcionChanged(m_banco_descripcion, EventArgs.Empty)
				End If
			Else
				m_banco_descripcion = value
				OnBANCO_DescripcionChanged(m_banco_descripcion, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property BANCO_DescCorta() As String
        Get
            Return m_banco_DescCorta
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_banco_DescCorta) Then
                If Not m_banco_DescCorta.Equals(value) Then
                    m_banco_DescCorta = value
                    OnBANCO_DescCortaChanged(m_banco_DescCorta, EventArgs.Empty)
                End If
            Else
                m_banco_DescCorta = value
                OnBANCO_DescCortaChanged(m_banco_DescCorta, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property BANCO_Protegido() As Boolean
		Get
			return m_banco_protegido
		End Get
		Set(ByVal value As Boolean)
			If Not m_banco_protegido.Equals(value) Then
				m_banco_protegido = value
				OnBANCO_ProtegidoChanged(m_banco_protegido, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property BANCO_UsrCrea() As String
		Get
			return m_banco_usrcrea
		End Get
		Set(ByVal value As String)
			m_banco_usrcrea = value
		End Set
	End Property
	Public Property BANCO_FecCrea() As Date
		Get
			return m_banco_feccrea
		End Get
		Set(ByVal value As Date)
			m_banco_feccrea = value
		End Set
	End Property
	Public Property BANCO_UsrMod() As String
		Get
			return m_banco_usrmod
		End Get
		Set(ByVal value As String)
			m_banco_usrmod = value
		End Set
	End Property
	Public Property BANCO_FecMod() As Date
		Get
			return m_banco_fecmod
		End Get
		Set(ByVal value As Date)
			m_banco_fecmod = value
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
			Return "Bancos"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event BANCO_IdChanged As EventHandler
    Public Event BANCO_DescripcionChanged As EventHandler
    Public Event BANCO_DescCortaChanged As EventHandler
	Public Event BANCO_ProtegidoChanged As EventHandler
	Public Sub OnBANCO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent BANCO_IdChanged(sender, e)
	End Sub
	Public Sub OnBANCO_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent BANCO_DescripcionChanged(sender, e)
    End Sub
    Public Sub OnBANCO_DescCortaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent BANCO_DescCortaChanged(sender, e)
    End Sub
	Public Sub OnBANCO_ProtegidoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent BANCO_ProtegidoChanged(sender, e)
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

