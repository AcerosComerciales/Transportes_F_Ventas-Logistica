Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EAuditoria

#Region " Campos "
	
	Private m_audit_id As Long
	Private m_aplic_codigo As String
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_audit_codigoreferencia As String
	Private m_tipos_codtipoproceso As String
	Private m_tipos_codtipodocumento As String
	Private m_entid_codigootorgado As String
	Private m_entid_codigoconfirmado As String
	Private m_audit_estado As String
	Private m_audit_docautorizado As String
	Private m_audit_usrcrea As String
	Private m_audit_feccrea As Date
	Private m_audit_usrmod As String
	Private m_audit_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlAuditoria
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
	
	Public Property AUDIT_Id() As Long
		Get
			return m_audit_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_audit_id) Then
				If Not m_audit_id.Equals(value) Then
					m_audit_id = value
					OnAUDIT_IdChanged(m_audit_id, EventArgs.Empty)
				End If
			Else
				m_audit_id = value
				OnAUDIT_IdChanged(m_audit_id, EventArgs.Empty)
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

	Public Property AUDIT_CodigoReferencia() As String
		Get
			return m_audit_codigoreferencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_audit_codigoreferencia) Then
				If Not m_audit_codigoreferencia.Equals(value) Then
					m_audit_codigoreferencia = value
					OnAUDIT_CodigoReferenciaChanged(m_audit_codigoreferencia, EventArgs.Empty)
				End If
			Else
				m_audit_codigoreferencia = value
				OnAUDIT_CodigoReferenciaChanged(m_audit_codigoreferencia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoProceso() As String
		Get
			return m_tipos_codtipoproceso
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipoproceso) Then
				If Not m_tipos_codtipoproceso.Equals(value) Then
					m_tipos_codtipoproceso = value
					OnTIPOS_CodTipoProcesoChanged(m_tipos_codtipoproceso, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipoproceso = value
				OnTIPOS_CodTipoProcesoChanged(m_tipos_codtipoproceso, EventArgs.Empty)
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

	Public Property ENTID_CodigoOtorgado() As String
		Get
			return m_entid_codigootorgado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigootorgado) Then
				If Not m_entid_codigootorgado.Equals(value) Then
					m_entid_codigootorgado = value
					OnENTID_CodigoOtorgadoChanged(m_entid_codigootorgado, EventArgs.Empty)
				End If
			Else
				m_entid_codigootorgado = value
				OnENTID_CodigoOtorgadoChanged(m_entid_codigootorgado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodigoConfirmado() As String
		Get
			return m_entid_codigoconfirmado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoconfirmado) Then
				If Not m_entid_codigoconfirmado.Equals(value) Then
					m_entid_codigoconfirmado = value
					OnENTID_CodigoConfirmadoChanged(m_entid_codigoconfirmado, EventArgs.Empty)
				End If
			Else
				m_entid_codigoconfirmado = value
				OnENTID_CodigoConfirmadoChanged(m_entid_codigoconfirmado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property AUDIT_Estado() As String
		Get
			return m_audit_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_audit_estado) Then
				If Not m_audit_estado.Equals(value) Then
					m_audit_estado = value
					OnAUDIT_EstadoChanged(m_audit_estado, EventArgs.Empty)
				End If
			Else
				m_audit_estado = value
				OnAUDIT_EstadoChanged(m_audit_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property AUDIT_DocAutorizado() As String
		Get
			return m_audit_docautorizado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_audit_docautorizado) Then
				If Not m_audit_docautorizado.Equals(value) Then
					m_audit_docautorizado = value
					OnAUDIT_DocAutorizadoChanged(m_audit_docautorizado, EventArgs.Empty)
				End If
			Else
				m_audit_docautorizado = value
				OnAUDIT_DocAutorizadoChanged(m_audit_docautorizado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property AUDIT_UsrCrea() As String
		Get
			return m_audit_usrcrea
		End Get
		Set(ByVal value As String)
			m_audit_usrcrea = value
		End Set
	End Property

	Public Property AUDIT_FecCrea() As Date
		Get
			return m_audit_feccrea
		End Get
		Set(ByVal value As Date)
			m_audit_feccrea = value
		End Set
	End Property

	Public Property AUDIT_UsrMod() As String
		Get
			return m_audit_usrmod
		End Get
		Set(ByVal value As String)
			m_audit_usrmod = value
		End Set
	End Property

	Public Property AUDIT_FecMod() As Date
		Get
			return m_audit_fecmod
		End Get
		Set(ByVal value As Date)
			m_audit_fecmod = value
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
			Return "Auditoria"
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
	
	Public Event AUDIT_IdChanged As EventHandler
	Public Event APLIC_CodigoChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event AUDIT_CodigoReferenciaChanged As EventHandler
	Public Event TIPOS_CodTipoProcesoChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event ENTID_CodigoOtorgadoChanged As EventHandler
	Public Event ENTID_CodigoConfirmadoChanged As EventHandler
	Public Event AUDIT_EstadoChanged As EventHandler
	Public Event AUDIT_DocAutorizadoChanged As EventHandler

	Public Sub OnAUDIT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent AUDIT_IdChanged(sender, e)
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

	Public Sub OnAUDIT_CodigoReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent AUDIT_CodigoReferenciaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoProcesoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoProcesoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoOtorgadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoOtorgadoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoConfirmadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoConfirmadoChanged(sender, e)
	End Sub

	Public Sub OnAUDIT_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent AUDIT_EstadoChanged(sender, e)
	End Sub

	Public Sub OnAUDIT_DocAutorizadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent AUDIT_DocAutorizadoChanged(sender, e)
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

