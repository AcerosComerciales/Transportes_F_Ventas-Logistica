Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECONT_DocsPercepcion

#Region " Campos "
	
	Private m_docpe_codigo As String
	Private m_entid_codigo As String
	Private m_docve_codigo As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtipodocumento As String
	Private m_docpe_serie As String
	Private m_docpe_numero As Decimal
	Private m_docpe_tipocambio As Decimal
	Private m_docpe_fecemision As Date
	Private m_docpe_fectransaccion As Date
	Private m_docpe_nroautorizacion As String
	Private m_docpe_totalpercepcion As Decimal
	Private m_docpe_estado As String
	Private m_docpe_usrcrea As String
	Private m_docpe_feccrea As Date
	Private m_docpe_usrmod As String
	Private m_docpe_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlCONT_DocsPercepcion
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
	
	Public Property DOCPE_Codigo() As String
		Get
			return m_docpe_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docpe_codigo) Then
				If Not m_docpe_codigo.Equals(value) Then
					m_docpe_codigo = value
					OnDOCPE_CodigoChanged(m_docpe_codigo, EventArgs.Empty)
				End If
			Else
				m_docpe_codigo = value
				OnDOCPE_CodigoChanged(m_docpe_codigo, EventArgs.Empty)
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

	Public Property DOCVE_Codigo() As String
		Get
			return m_docve_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_codigo) Then
				If Not m_docve_codigo.Equals(value) Then
					m_docve_codigo = value
					OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
				End If
			Else
				m_docve_codigo = value
				OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoMoneda() As String
		Get
			return m_tipos_codtipomoneda
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipomoneda) Then
				If Not m_tipos_codtipomoneda.Equals(value) Then
					m_tipos_codtipomoneda = value
					OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipomoneda = value
				OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
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

	Public Property DOCPE_Serie() As String
		Get
			return m_docpe_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docpe_serie) Then
				If Not m_docpe_serie.Equals(value) Then
					m_docpe_serie = value
					OnDOCPE_SerieChanged(m_docpe_serie, EventArgs.Empty)
				End If
			Else
				m_docpe_serie = value
				OnDOCPE_SerieChanged(m_docpe_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPE_Numero() As Decimal
		Get
			return m_docpe_numero
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docpe_numero) Then
				If Not m_docpe_numero.Equals(value) Then
					m_docpe_numero = value
					OnDOCPE_NumeroChanged(m_docpe_numero, EventArgs.Empty)
				End If
			Else
				m_docpe_numero = value
				OnDOCPE_NumeroChanged(m_docpe_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPE_TipoCambio() As Decimal
		Get
			return m_docpe_tipocambio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docpe_tipocambio) Then
				If Not m_docpe_tipocambio.Equals(value) Then
					m_docpe_tipocambio = value
					OnDOCPE_TipoCambioChanged(m_docpe_tipocambio, EventArgs.Empty)
				End If
			Else
				m_docpe_tipocambio = value
				OnDOCPE_TipoCambioChanged(m_docpe_tipocambio, EventArgs.Empty)
			End If
		End Set
	End Property

   Public Property DOCPE_FecEmision() As DateTime
      Get
         Return m_docpe_fecemision
      End Get
      Set(ByVal value As DateTime)
         If Not IsNothing(m_docpe_fecemision) Then
            If Not m_docpe_fecemision.Equals(value) Then
               m_docpe_fecemision = value
               OnDOCPE_FecEmisionChanged(m_docpe_fecemision, EventArgs.Empty)
            End If
         Else
            m_docpe_fecemision = value
            OnDOCPE_FecEmisionChanged(m_docpe_fecemision, EventArgs.Empty)
         End If
      End Set
   End Property

	Public Property DOCPE_FecTransaccion() As Date
		Get
			return m_docpe_fectransaccion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docpe_fectransaccion) Then
				If Not m_docpe_fectransaccion.Equals(value) Then
					m_docpe_fectransaccion = value
					OnDOCPE_FecTransaccionChanged(m_docpe_fectransaccion, EventArgs.Empty)
				End If
			Else
				m_docpe_fectransaccion = value
				OnDOCPE_FecTransaccionChanged(m_docpe_fectransaccion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPE_NroAutorizacion() As String
		Get
			return m_docpe_nroautorizacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docpe_nroautorizacion) Then
				If Not m_docpe_nroautorizacion.Equals(value) Then
					m_docpe_nroautorizacion = value
					OnDOCPE_NroAutorizacionChanged(m_docpe_nroautorizacion, EventArgs.Empty)
				End If
			Else
				m_docpe_nroautorizacion = value
				OnDOCPE_NroAutorizacionChanged(m_docpe_nroautorizacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPE_TotalPercepcion() As Decimal
		Get
			return m_docpe_totalpercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docpe_totalpercepcion) Then
				If Not m_docpe_totalpercepcion.Equals(value) Then
					m_docpe_totalpercepcion = value
					OnDOCPE_TotalPercepcionChanged(m_docpe_totalpercepcion, EventArgs.Empty)
				End If
			Else
				m_docpe_totalpercepcion = value
				OnDOCPE_TotalPercepcionChanged(m_docpe_totalpercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPE_Estado() As String
		Get
			return m_docpe_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docpe_estado) Then
				If Not m_docpe_estado.Equals(value) Then
					m_docpe_estado = value
					OnDOCPE_EstadoChanged(m_docpe_estado, EventArgs.Empty)
				End If
			Else
				m_docpe_estado = value
				OnDOCPE_EstadoChanged(m_docpe_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCPE_UsrCrea() As String
		Get
			return m_docpe_usrcrea
		End Get
		Set(ByVal value As String)
			m_docpe_usrcrea = value
		End Set
	End Property

	Public Property DOCPE_FecCrea() As Date
		Get
			return m_docpe_feccrea
		End Get
		Set(ByVal value As Date)
			m_docpe_feccrea = value
		End Set
	End Property

	Public Property DOCPE_UsrMod() As String
		Get
			return m_docpe_usrmod
		End Get
		Set(ByVal value As String)
			m_docpe_usrmod = value
		End Set
	End Property

	Public Property DOCPE_FecMod() As Date
		Get
			return m_docpe_fecmod
		End Get
		Set(ByVal value As Date)
			m_docpe_fecmod = value
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
			Return "CONT_DocsPercepcion"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Contabilidad"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event DOCPE_CodigoChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event DOCPE_SerieChanged As EventHandler
	Public Event DOCPE_NumeroChanged As EventHandler
	Public Event DOCPE_TipoCambioChanged As EventHandler
	Public Event DOCPE_FecEmisionChanged As EventHandler
	Public Event DOCPE_FecTransaccionChanged As EventHandler
	Public Event DOCPE_NroAutorizacionChanged As EventHandler
	Public Event DOCPE_TotalPercepcionChanged As EventHandler
	Public Event DOCPE_EstadoChanged As EventHandler

	Public Sub OnDOCPE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnDOCPE_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_SerieChanged(sender, e)
	End Sub

	Public Sub OnDOCPE_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_NumeroChanged(sender, e)
	End Sub

	Public Sub OnDOCPE_TipoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_TipoCambioChanged(sender, e)
	End Sub

	Public Sub OnDOCPE_FecEmisionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_FecEmisionChanged(sender, e)
	End Sub

	Public Sub OnDOCPE_FecTransaccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_FecTransaccionChanged(sender, e)
	End Sub

	Public Sub OnDOCPE_NroAutorizacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_NroAutorizacionChanged(sender, e)
	End Sub

	Public Sub OnDOCPE_TotalPercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_TotalPercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCPE_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCPE_EstadoChanged(sender, e)
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

