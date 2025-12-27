Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDocumentos

#Region " Campos "
	
	Private m_docmt_id As Long
	Private m_sucur_id As Short
	Private m_tipos_codtipodocumento As String
	Private m_docmt_nro As String
	Private m_docmt_descripcion As String
	Private m_docmt_de As Long
	Private m_docmt_para As Long
	Private m_docmt_fecha As Date
	Private m_docmt_contenido As String
	Private m_docmt_fecdoc As Date
	Private m_docmt_usrcrea As String
	Private m_docmt_feccrea As Date
	Private m_docmt_usrmod As String
	Private m_docmt_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlDocumentos
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
	
	Public Property DOCMT_Id() As Long
		Get
			return m_docmt_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_docmt_id) Then
				If Not m_docmt_id.Equals(value) Then
					m_docmt_id = value
					OnDOCMT_IdChanged(m_docmt_id, EventArgs.Empty)
				End If
			Else
				m_docmt_id = value
				OnDOCMT_IdChanged(m_docmt_id, EventArgs.Empty)
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
	Public Property TIPOS_CodTipoDocumento() As String
		Get
			return m_tipos_codtipodocumento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipodocumento) Then
				If Not m_tipos_codtipodocumento.Equals(value) Then
					m_tipos_codtipodocumento = value
					OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipodocumento = value
				OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCMT_Nro() As String
		Get
			return m_docmt_nro
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docmt_nro) Then
				If Not m_docmt_nro.Equals(value) Then
					m_docmt_nro = value
					OnDOCMT_NroChanged(m_docmt_nro, EventArgs.Empty)
				End If
			Else
				m_docmt_nro = value
				OnDOCMT_NroChanged(m_docmt_nro, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCMT_Descripcion() As String
		Get
			return m_docmt_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docmt_descripcion) Then
				If Not m_docmt_descripcion.Equals(value) Then
					m_docmt_descripcion = value
					OnDOCMT_DescripcionChanged(m_docmt_descripcion, EventArgs.Empty)
				End If
			Else
				m_docmt_descripcion = value
				OnDOCMT_DescripcionChanged(m_docmt_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCMT_De() As Long
		Get
			return m_docmt_de
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_docmt_de) Then
				If Not m_docmt_de.Equals(value) Then
					m_docmt_de = value
					OnDOCMT_DeChanged(m_docmt_de, EventArgs.Empty)
				End If
			Else
				m_docmt_de = value
				OnDOCMT_DeChanged(m_docmt_de, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCMT_Para() As Long
		Get
			return m_docmt_para
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_docmt_para) Then
				If Not m_docmt_para.Equals(value) Then
					m_docmt_para = value
					OnDOCMT_ParaChanged(m_docmt_para, EventArgs.Empty)
				End If
			Else
				m_docmt_para = value
				OnDOCMT_ParaChanged(m_docmt_para, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCMT_Fecha() As Date
		Get
			return m_docmt_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docmt_fecha) Then
				If Not m_docmt_fecha.Equals(value) Then
					m_docmt_fecha = value
					OnDOCMT_FechaChanged(m_docmt_fecha, EventArgs.Empty)
				End If
			Else
				m_docmt_fecha = value
				OnDOCMT_FechaChanged(m_docmt_fecha, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCMT_Contenido() As String
		Get
			return m_docmt_contenido
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docmt_contenido) Then
				If Not m_docmt_contenido.Equals(value) Then
					m_docmt_contenido = value
					OnDOCMT_ContenidoChanged(m_docmt_contenido, EventArgs.Empty)
				End If
			Else
				m_docmt_contenido = value
				OnDOCMT_ContenidoChanged(m_docmt_contenido, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCMT_FecDoc() As Date
		Get
			return m_docmt_fecdoc
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docmt_fecdoc) Then
				If Not m_docmt_fecdoc.Equals(value) Then
					m_docmt_fecdoc = value
					OnDOCMT_FecDocChanged(m_docmt_fecdoc, EventArgs.Empty)
				End If
			Else
				m_docmt_fecdoc = value
				OnDOCMT_FecDocChanged(m_docmt_fecdoc, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCMT_UsrCrea() As String
		Get
			return m_docmt_usrcrea
		End Get
		Set(ByVal value As String)
			m_docmt_usrcrea = value
		End Set
	End Property
	Public Property DOCMT_FecCrea() As Date
		Get
			return m_docmt_feccrea
		End Get
		Set(ByVal value As Date)
			m_docmt_feccrea = value
		End Set
	End Property
	Public Property DOCMT_UsrMod() As String
		Get
			return m_docmt_usrmod
		End Get
		Set(ByVal value As String)
			m_docmt_usrmod = value
		End Set
	End Property
	Public Property DOCMT_FecMod() As Date
		Get
			return m_docmt_fecmod
		End Get
		Set(ByVal value As Date)
			m_docmt_fecmod = value
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
			Return "Documentos"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event DOCMT_IdChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event DOCMT_NroChanged As EventHandler
	Public Event DOCMT_DescripcionChanged As EventHandler
	Public Event DOCMT_DeChanged As EventHandler
	Public Event DOCMT_ParaChanged As EventHandler
	Public Event DOCMT_FechaChanged As EventHandler
	Public Event DOCMT_ContenidoChanged As EventHandler
	Public Event DOCMT_FecDocChanged As EventHandler
	Public Sub OnDOCMT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCMT_IdChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub
	Public Sub OnDOCMT_NroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCMT_NroChanged(sender, e)
	End Sub
	Public Sub OnDOCMT_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCMT_DescripcionChanged(sender, e)
	End Sub
	Public Sub OnDOCMT_DeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCMT_DeChanged(sender, e)
	End Sub
	Public Sub OnDOCMT_ParaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCMT_ParaChanged(sender, e)
	End Sub
	Public Sub OnDOCMT_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCMT_FechaChanged(sender, e)
	End Sub
	Public Sub OnDOCMT_ContenidoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCMT_ContenidoChanged(sender, e)
	End Sub
	Public Sub OnDOCMT_FecDocChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCMT_FecDocChanged(sender, e)
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

