Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EEntidadesPadrones

#Region " Campos "
	
	Private m_enpad_id As Integer
	Private m_entid_codigo As String
	Private m_tipos_codtipopadron As String
	Private m_enpad_maqreg As String
	Private m_enpad_usrcrea As String
	Private m_enpad_feccrea As Date
	Private m_enpad_usrmod As String
	Private m_enpad_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlEntidadesPadrones
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
	
	Public Property ENPAD_Id() As Integer
		Get
			return m_enpad_id
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_enpad_id) Then
				If Not m_enpad_id.Equals(value) Then
					m_enpad_id = value
					OnENPAD_IdChanged(m_enpad_id, EventArgs.Empty)
				End If
			Else
				m_enpad_id = value
				OnENPAD_IdChanged(m_enpad_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Codigo() As String
		Get
			return m_entid_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigo) Then
				If Not m_entid_codigo.Equals(value) Then
					m_entid_codigo = value
					OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
				End If
			Else
				m_entid_codigo = value
				OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoPadron() As String
		Get
			return m_tipos_codtipopadron
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipopadron) Then
				If Not m_tipos_codtipopadron.Equals(value) Then
					m_tipos_codtipopadron = value
					OnTIPOS_CodTipoPadronChanged(m_tipos_codtipopadron, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipopadron = value
				OnTIPOS_CodTipoPadronChanged(m_tipos_codtipopadron, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENPAD_MaqReg() As String
		Get
			return m_enpad_maqreg
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_enpad_maqreg) Then
				If Not m_enpad_maqreg.Equals(value) Then
					m_enpad_maqreg = value
					OnENPAD_MaqRegChanged(m_enpad_maqreg, EventArgs.Empty)
				End If
			Else
				m_enpad_maqreg = value
				OnENPAD_MaqRegChanged(m_enpad_maqreg, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENPAD_UsrCrea() As String
		Get
			return m_enpad_usrcrea
		End Get
		Set(ByVal value As String)
			m_enpad_usrcrea = value
		End Set
	End Property

	Public Property ENPAD_FecCrea() As Date
		Get
			return m_enpad_feccrea
		End Get
		Set(ByVal value As Date)
			m_enpad_feccrea = value
		End Set
	End Property

	Public Property ENPAD_UsrMod() As String
		Get
			return m_enpad_usrmod
		End Get
		Set(ByVal value As String)
			m_enpad_usrmod = value
		End Set
	End Property

	Public Property ENPAD_FecMod() As Date
		Get
			return m_enpad_fecmod
		End Get
		Set(ByVal value As Date)
			m_enpad_fecmod = value
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
			Return "EntidadesPadrones"
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
	
	Public Event ENPAD_IdChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoPadronChanged As EventHandler
	Public Event ENPAD_MaqRegChanged As EventHandler

	Public Sub OnENPAD_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENPAD_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoPadronChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoPadronChanged(sender, e)
	End Sub

	Public Sub OnENPAD_MaqRegChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENPAD_MaqRegChanged(sender, e)
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

