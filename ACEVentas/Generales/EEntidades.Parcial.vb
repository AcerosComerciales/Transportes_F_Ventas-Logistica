Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EEntidades

#Region " Campos "
	
	Private m_entid_codigo As String
	Private m_tipos_codtipodocumento As String
	Private m_ubigo_codigo As String
	Private m_entid_id As Long
	Private m_entid_tipoentidadpdt As String
	Private m_entid_nombres As String
	Private m_entid_nrodocumento As String
	Private m_entid_razonsocial As String
	Private m_entid_nombrecomercial As String
	Private m_entid_fecnacimiento As Date
	Private m_entid_ptrapematerno As Short
	Private m_entid_ptrnombre1 As Short
	Private m_entid_ptrnombre2 As Short
	Private m_entid_email As String
	Private m_entid_estado As String
	Private m_entid_direccion As String
	Private m_entid_telefono1 As String
	Private m_entid_telefono2 As String
	Private m_entid_fax As String
	Private m_usuar_codigo As String
	Private m_entid_codusuario As String
	Private m_entid_codbusqueda As Integer
	Private m_entid_usrcrea As String
	Private m_entid_feccrea As Date
	Private m_entid_usrmod As String
	Private m_entid_fecmod As Date
    Private m_entid_proveserie As String 
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlEntidades
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

	Public Property UBIGO_Codigo() As String
		Get
			return m_ubigo_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ubigo_codigo) Then
				If Not m_ubigo_codigo.Equals(value) Then
					m_ubigo_codigo = value
					OnUBIGO_CodigoChanged(m_ubigo_codigo, EventArgs.Empty)
				End If
			Else
				m_ubigo_codigo = value
				OnUBIGO_CodigoChanged(m_ubigo_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Id() As Long
		Get
			return m_entid_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_entid_id) Then
				If Not m_entid_id.Equals(value) Then
					m_entid_id = value
					OnENTID_IdChanged(m_entid_id, EventArgs.Empty)
				End If
			Else
				m_entid_id = value
				OnENTID_IdChanged(m_entid_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_TipoEntidadPDT() As String
		Get
			return m_entid_tipoentidadpdt
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_tipoentidadpdt) Then
				If Not m_entid_tipoentidadpdt.Equals(value) Then
					m_entid_tipoentidadpdt = value
					OnENTID_TipoEntidadPDTChanged(m_entid_tipoentidadpdt, EventArgs.Empty)
				End If
			Else
				m_entid_tipoentidadpdt = value
				OnENTID_TipoEntidadPDTChanged(m_entid_tipoentidadpdt, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Nombres() As String
		Get
			return m_entid_nombres
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_nombres) Then
				If Not m_entid_nombres.Equals(value) Then
					m_entid_nombres = value
					OnENTID_NombresChanged(m_entid_nombres, EventArgs.Empty)
				End If
			Else
				m_entid_nombres = value
				OnENTID_NombresChanged(m_entid_nombres, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_NroDocumento() As String
		Get
			return m_entid_nrodocumento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_nrodocumento) Then
				If Not m_entid_nrodocumento.Equals(value) Then
					m_entid_nrodocumento = value
					OnENTID_NroDocumentoChanged(m_entid_nrodocumento, EventArgs.Empty)
				End If
			Else
				m_entid_nrodocumento = value
				OnENTID_NroDocumentoChanged(m_entid_nrodocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_RazonSocial() As String
		Get
			return m_entid_razonsocial
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_razonsocial) Then
				If Not m_entid_razonsocial.Equals(value) Then
					m_entid_razonsocial = value
					OnENTID_RazonSocialChanged(m_entid_razonsocial, EventArgs.Empty)
				End If
			Else
				m_entid_razonsocial = value
				OnENTID_RazonSocialChanged(m_entid_razonsocial, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_NombreComercial() As String
		Get
			return m_entid_nombrecomercial
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_nombrecomercial) Then
				If Not m_entid_nombrecomercial.Equals(value) Then
					m_entid_nombrecomercial = value
					OnENTID_NombreComercialChanged(m_entid_nombrecomercial, EventArgs.Empty)
				End If
			Else
				m_entid_nombrecomercial = value
				OnENTID_NombreComercialChanged(m_entid_nombrecomercial, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_FecNacimiento() As Date
		Get
			return m_entid_fecnacimiento
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_entid_fecnacimiento) Then
				If Not m_entid_fecnacimiento.Equals(value) Then
					m_entid_fecnacimiento = value
					OnENTID_FecNacimientoChanged(m_entid_fecnacimiento, EventArgs.Empty)
				End If
			Else
				m_entid_fecnacimiento = value
				OnENTID_FecNacimientoChanged(m_entid_fecnacimiento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_PtrApeMaterno() As Short
		Get
			return m_entid_ptrapematerno
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_entid_ptrapematerno) Then
				If Not m_entid_ptrapematerno.Equals(value) Then
					m_entid_ptrapematerno = value
					OnENTID_PtrApeMaternoChanged(m_entid_ptrapematerno, EventArgs.Empty)
				End If
			Else
				m_entid_ptrapematerno = value
				OnENTID_PtrApeMaternoChanged(m_entid_ptrapematerno, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_PtrNombre1() As Short
		Get
			return m_entid_ptrnombre1
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_entid_ptrnombre1) Then
				If Not m_entid_ptrnombre1.Equals(value) Then
					m_entid_ptrnombre1 = value
					OnENTID_PtrNombre1Changed(m_entid_ptrnombre1, EventArgs.Empty)
				End If
			Else
				m_entid_ptrnombre1 = value
				OnENTID_PtrNombre1Changed(m_entid_ptrnombre1, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_PtrNombre2() As Short
		Get
			return m_entid_ptrnombre2
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_entid_ptrnombre2) Then
				If Not m_entid_ptrnombre2.Equals(value) Then
					m_entid_ptrnombre2 = value
					OnENTID_PtrNombre2Changed(m_entid_ptrnombre2, EventArgs.Empty)
				End If
			Else
				m_entid_ptrnombre2 = value
				OnENTID_PtrNombre2Changed(m_entid_ptrnombre2, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_EMail() As String
		Get
			return m_entid_email
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_email) Then
				If Not m_entid_email.Equals(value) Then
					m_entid_email = value
					OnENTID_EMailChanged(m_entid_email, EventArgs.Empty)
				End If
			Else
				m_entid_email = value
				OnENTID_EMailChanged(m_entid_email, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Estado() As String
		Get
			return m_entid_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_estado) Then
				If Not m_entid_estado.Equals(value) Then
					m_entid_estado = value
					OnENTID_EstadoChanged(m_entid_estado, EventArgs.Empty)
				End If
			Else
				m_entid_estado = value
				OnENTID_EstadoChanged(m_entid_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Direccion() As String
		Get
			return m_entid_direccion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_direccion) Then
				If Not m_entid_direccion.Equals(value) Then
					m_entid_direccion = value
					OnENTID_DireccionChanged(m_entid_direccion, EventArgs.Empty)
				End If
			Else
				m_entid_direccion = value
				OnENTID_DireccionChanged(m_entid_direccion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Telefono1() As String
		Get
			return m_entid_telefono1
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_telefono1) Then
				If Not m_entid_telefono1.Equals(value) Then
					m_entid_telefono1 = value
					OnENTID_Telefono1Changed(m_entid_telefono1, EventArgs.Empty)
				End If
			Else
				m_entid_telefono1 = value
				OnENTID_Telefono1Changed(m_entid_telefono1, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Telefono2() As String
		Get
			return m_entid_telefono2
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_telefono2) Then
				If Not m_entid_telefono2.Equals(value) Then
					m_entid_telefono2 = value
					OnENTID_Telefono2Changed(m_entid_telefono2, EventArgs.Empty)
				End If
			Else
				m_entid_telefono2 = value
				OnENTID_Telefono2Changed(m_entid_telefono2, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Fax() As String
		Get
			return m_entid_fax
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_fax) Then
				If Not m_entid_fax.Equals(value) Then
					m_entid_fax = value
					OnENTID_FaxChanged(m_entid_fax, EventArgs.Empty)
				End If
			Else
				m_entid_fax = value
				OnENTID_FaxChanged(m_entid_fax, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property USUAR_Codigo() As String
		Get
			return m_usuar_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_usuar_codigo) Then
				If Not m_usuar_codigo.Equals(value) Then
					m_usuar_codigo = value
					OnUSUAR_CodigoChanged(m_usuar_codigo, EventArgs.Empty)
				End If
			Else
				m_usuar_codigo = value
				OnUSUAR_CodigoChanged(m_usuar_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodUsuario() As String
		Get
			return m_entid_codusuario
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codusuario) Then
				If Not m_entid_codusuario.Equals(value) Then
					m_entid_codusuario = value
					OnENTID_CodUsuarioChanged(m_entid_codusuario, EventArgs.Empty)
				End If
			Else
				m_entid_codusuario = value
				OnENTID_CodUsuarioChanged(m_entid_codusuario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodBusqueda() As Integer
		Get
			return m_entid_codbusqueda
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_entid_codbusqueda) Then
				If Not m_entid_codbusqueda.Equals(value) Then
					m_entid_codbusqueda = value
					OnENTID_CodBusquedaChanged(m_entid_codbusqueda, EventArgs.Empty)
				End If
			Else
				m_entid_codbusqueda = value
				OnENTID_CodBusquedaChanged(m_entid_codbusqueda, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_UsrCrea() As String
		Get
			return m_entid_usrcrea
		End Get
		Set(ByVal value As String)
			m_entid_usrcrea = value
		End Set
	End Property

    Public Property ENTID_PROVESerie() As String
		Get
			return m_entid_proveserie
		End Get
		Set(ByVal value As String)
			m_entid_proveserie = value
		End Set
	End Property

	Public Property ENTID_FecCrea() As Date
		Get
			return m_entid_feccrea
		End Get
		Set(ByVal value As Date)
			m_entid_feccrea = value
		End Set
	End Property

	Public Property ENTID_UsrMod() As String
		Get
			return m_entid_usrmod
		End Get
		Set(ByVal value As String)
			m_entid_usrmod = value
		End Set
	End Property

	Public Property ENTID_FecMod() As Date
		Get
			return m_entid_fecmod
		End Get
		Set(ByVal value As Date)
			m_entid_fecmod = value
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
			Return "Entidades"
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
	
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event UBIGO_CodigoChanged As EventHandler
	Public Event ENTID_IdChanged As EventHandler
	Public Event ENTID_TipoEntidadPDTChanged As EventHandler
	Public Event ENTID_NombresChanged As EventHandler
	Public Event ENTID_NroDocumentoChanged As EventHandler
	Public Event ENTID_RazonSocialChanged As EventHandler
	Public Event ENTID_NombreComercialChanged As EventHandler
	Public Event ENTID_FecNacimientoChanged As EventHandler
	Public Event ENTID_PtrApeMaternoChanged As EventHandler
	Public Event ENTID_PtrNombre1Changed As EventHandler
	Public Event ENTID_PtrNombre2Changed As EventHandler
	Public Event ENTID_EMailChanged As EventHandler
	Public Event ENTID_EstadoChanged As EventHandler
	Public Event ENTID_DireccionChanged As EventHandler
	Public Event ENTID_Telefono1Changed As EventHandler
	Public Event ENTID_Telefono2Changed As EventHandler
	Public Event ENTID_FaxChanged As EventHandler
	Public Event USUAR_CodigoChanged As EventHandler
	Public Event ENTID_CodUsuarioChanged As EventHandler
	Public Event ENTID_CodBusquedaChanged As EventHandler

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnUBIGO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent UBIGO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_TipoEntidadPDTChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_TipoEntidadPDTChanged(sender, e)
	End Sub

	Public Sub OnENTID_NombresChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_NombresChanged(sender, e)
	End Sub

	Public Sub OnENTID_NroDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_NroDocumentoChanged(sender, e)
	End Sub

	Public Sub OnENTID_RazonSocialChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_RazonSocialChanged(sender, e)
	End Sub

	Public Sub OnENTID_NombreComercialChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_NombreComercialChanged(sender, e)
	End Sub

	Public Sub OnENTID_FecNacimientoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_FecNacimientoChanged(sender, e)
	End Sub

	Public Sub OnENTID_PtrApeMaternoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_PtrApeMaternoChanged(sender, e)
	End Sub

	Public Sub OnENTID_PtrNombre1Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_PtrNombre1Changed(sender, e)
	End Sub

	Public Sub OnENTID_PtrNombre2Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_PtrNombre2Changed(sender, e)
	End Sub

	Public Sub OnENTID_EMailChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_EMailChanged(sender, e)
	End Sub

	Public Sub OnENTID_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_EstadoChanged(sender, e)
	End Sub

	Public Sub OnENTID_DireccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_DireccionChanged(sender, e)
	End Sub

	Public Sub OnENTID_Telefono1Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_Telefono1Changed(sender, e)
	End Sub

	Public Sub OnENTID_Telefono2Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_Telefono2Changed(sender, e)
	End Sub

	Public Sub OnENTID_FaxChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_FaxChanged(sender, e)
	End Sub

	Public Sub OnUSUAR_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent USUAR_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodUsuarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodUsuarioChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodBusquedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodBusquedaChanged(sender, e)
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

