Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECuadreCaja

#Region " Campos "
	
	Private m_orden As Integer
	Private m_titulo As String
	Private m_fecha As Date
	Private m_entid_nrodocumento As String
	Private m_entid_razonsocial As String
	Private m_documento As String
	Private m_moneda As String
	Private m_tcambioventa As Decimal
	Private m_impdolares As Decimal
	Private m_impsoles As Decimal
	Private m_flete_id As Integer
	Private m_viaje_id As Integer
	Private m_entid_codigo As String
	Private m_docve_codigo As String
	Private m_flete_glosa As String
	Private m_pendiente As Decimal
	Private m_docve_fechadocumento As Date
	Private m_pago As Decimal
	Private m_docve_serie As String
	Private m_docve_numero As Integer
   Private m_tipodocumento As String
   Private m_recibo As String
   Private m_nuevo As Boolean
   Private m_modificado As Boolean
   Private m_eliminado As Boolean

   Private m_hash As Hashtable
#End Region

#Region " Constructores "

   Public Sub New()

      Try
        
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

#Region " Propiedades "

   Public Property Orden() As Integer
      Get
         Return m_orden
      End Get
      Set(ByVal value As Integer)
         If Not IsNothing(m_orden) Then
            If Not m_orden.Equals(value) Then
               m_orden = value
               OnOrdenChanged(m_orden, EventArgs.Empty)
            End If
         Else
            m_orden = value
            OnOrdenChanged(m_orden, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property Titulo() As String
      Get
         Return m_titulo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_titulo) Then
            If Not m_titulo.Equals(value) Then
               m_titulo = value
               OnTituloChanged(m_titulo, EventArgs.Empty)
            End If
         Else
            m_titulo = value
            OnTituloChanged(m_titulo, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property Fecha() As Date
      Get
         Return m_fecha
      End Get
      Set(ByVal value As Date)
         If Not IsNothing(m_fecha) Then
            If Not m_fecha.Equals(value) Then
               m_fecha = value
               OnFechaChanged(m_fecha, EventArgs.Empty)
            End If
         Else
            m_fecha = value
            OnFechaChanged(m_fecha, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property ENTID_NroDocumento() As String
      Get
         Return m_entid_nrodocumento
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
         Return m_entid_razonsocial
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
   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_documento) Then
            If Not m_documento.Equals(value) Then
               m_documento = value
               OnDocumentoChanged(m_documento, EventArgs.Empty)
            End If
         Else
            m_documento = value
            OnDocumentoChanged(m_documento, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property Moneda() As String
      Get
         Return m_moneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_moneda) Then
            If Not m_moneda.Equals(value) Then
               m_moneda = value
               OnMonedaChanged(m_moneda, EventArgs.Empty)
            End If
         Else
            m_moneda = value
            OnMonedaChanged(m_moneda, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property TCambioVenta() As Decimal
      Get
         Return m_tcambioventa
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_tcambioventa) Then
            If Not m_tcambioventa.Equals(value) Then
               m_tcambioventa = value
               OnTCambioVentaChanged(m_tcambioventa, EventArgs.Empty)
            End If
         Else
            m_tcambioventa = value
            OnTCambioVentaChanged(m_tcambioventa, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property ImpDolares() As Decimal
      Get
         Return m_impdolares
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_impdolares) Then
            If Not m_impdolares.Equals(value) Then
               m_impdolares = value
               OnImpDolaresChanged(m_impdolares, EventArgs.Empty)
            End If
         Else
            m_impdolares = value
            OnImpDolaresChanged(m_impdolares, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property ImpSoles() As Decimal
      Get
         Return m_impsoles
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_impsoles) Then
            If Not m_impsoles.Equals(value) Then
               m_impsoles = value
               OnImpSolesChanged(m_impsoles, EventArgs.Empty)
            End If
         Else
            m_impsoles = value
            OnImpSolesChanged(m_impsoles, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property FLETE_Id() As Integer
      Get
         Return m_flete_id
      End Get
      Set(ByVal value As Integer)
         If Not IsNothing(m_flete_id) Then
            If Not m_flete_id.Equals(value) Then
               m_flete_id = value
               OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
            End If
         Else
            m_flete_id = value
            OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property VIAJE_Id() As Integer
      Get
         Return m_viaje_id
      End Get
      Set(ByVal value As Integer)
         If Not IsNothing(m_viaje_id) Then
            If Not m_viaje_id.Equals(value) Then
               m_viaje_id = value
               OnVIAJE_IdChanged(m_viaje_id, EventArgs.Empty)
            End If
         Else
            m_viaje_id = value
            OnVIAJE_IdChanged(m_viaje_id, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property ENTID_Codigo() As String
      Get
         Return m_entid_codigo
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
         Return m_docve_codigo
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
   Public Property FLETE_Glosa() As String
      Get
         Return m_flete_glosa
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_flete_glosa) Then
            If Not m_flete_glosa.Equals(value) Then
               m_flete_glosa = value
               OnFLETE_GlosaChanged(m_flete_glosa, EventArgs.Empty)
            End If
         Else
            m_flete_glosa = value
            OnFLETE_GlosaChanged(m_flete_glosa, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property Pendiente() As Decimal
      Get
         Return m_pendiente
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_pendiente) Then
            If Not m_pendiente.Equals(value) Then
               m_pendiente = value
               OnPendienteChanged(m_pendiente, EventArgs.Empty)
            End If
         Else
            m_pendiente = value
            OnPendienteChanged(m_pendiente, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property DOCVE_FechaDocumento() As Date
      Get
         Return m_docve_fechadocumento
      End Get
      Set(ByVal value As Date)
         If Not IsNothing(m_docve_fechadocumento) Then
            If Not m_docve_fechadocumento.Equals(value) Then
               m_docve_fechadocumento = value
               OnDOCVE_FechaDocumentoChanged(m_docve_fechadocumento, EventArgs.Empty)
            End If
         Else
            m_docve_fechadocumento = value
            OnDOCVE_FechaDocumentoChanged(m_docve_fechadocumento, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property Pago() As Decimal
      Get
         Return m_pago
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_pago) Then
            If Not m_pago.Equals(value) Then
               m_pago = value
               OnPagoChanged(m_pago, EventArgs.Empty)
            End If
         Else
            m_pago = value
            OnPagoChanged(m_pago, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property DOCVE_Serie() As String
      Get
         Return m_docve_serie
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_docve_serie) Then
            If Not m_docve_serie.Equals(value) Then
               m_docve_serie = value
               OnDOCVE_SerieChanged(m_docve_serie, EventArgs.Empty)
            End If
         Else
            m_docve_serie = value
            OnDOCVE_SerieChanged(m_docve_serie, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property DOCVE_Numero() As Integer
      Get
         Return m_docve_numero
      End Get
      Set(ByVal value As Integer)
         If Not IsNothing(m_docve_numero) Then
            If Not m_docve_numero.Equals(value) Then
               m_docve_numero = value
               OnDOCVE_NumeroChanged(m_docve_numero, EventArgs.Empty)
            End If
         Else
            m_docve_numero = value
            OnDOCVE_NumeroChanged(m_docve_numero, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property TipoDocumento() As String
      Get
         Return m_tipodocumento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipodocumento) Then
            If Not m_tipodocumento.Equals(value) Then
               m_tipodocumento = value
               OnTipoDocumentoChanged(m_tipodocumento, EventArgs.Empty)
            End If
         Else
            m_tipodocumento = value
            OnTipoDocumentoChanged(m_tipodocumento, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property Recibo() As String
      Get
         Return m_recibo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_recibo) Then
            If Not m_recibo.Equals(value) Then
               m_recibo = value
               OnReciboChanged(m_recibo, EventArgs.Empty)
            End If
         Else
            m_recibo = value
            OnReciboChanged(m_recibo, EventArgs.Empty)
         End If
      End Set
   End Property
   Public ReadOnly Property Nuevo() As Boolean
      Get
         Return m_nuevo
      End Get
   End Property
   Public ReadOnly Property Modificado() As Boolean
      Get
         Return m_modificado
      End Get
   End Property
   Public ReadOnly Property Eliminado() As Boolean
      Get
         Return m_eliminado
      End Get
   End Property
   Public ReadOnly Property Hash() As Hashtable
      Get
         Return m_hash
      End Get
   End Property
   Public Shared ReadOnly Property Tabla() As String
      Get
         Return "CuadreCaja"
      End Get
   End Property
   Public Shared ReadOnly Property Esquema() As String
      Get
         Return ""
      End Get
   End Property


#End Region

#Region " Eventos "

   Public Event OrdenChanged As EventHandler
   Public Event TituloChanged As EventHandler
   Public Event FechaChanged As EventHandler
   Public Event ENTID_NroDocumentoChanged As EventHandler
   Public Event ENTID_RazonSocialChanged As EventHandler
   Public Event DocumentoChanged As EventHandler
   Public Event MonedaChanged As EventHandler
   Public Event TCambioVentaChanged As EventHandler
   Public Event ImpDolaresChanged As EventHandler
   Public Event ImpSolesChanged As EventHandler
   Public Event FLETE_IdChanged As EventHandler
   Public Event VIAJE_IdChanged As EventHandler
   Public Event ENTID_CodigoChanged As EventHandler
   Public Event DOCVE_CodigoChanged As EventHandler
   Public Event FLETE_GlosaChanged As EventHandler
   Public Event PendienteChanged As EventHandler
   Public Event DOCVE_FechaDocumentoChanged As EventHandler
   Public Event PagoChanged As EventHandler
   Public Event DOCVE_SerieChanged As EventHandler
   Public Event DOCVE_NumeroChanged As EventHandler
   Public Event TipoDocumentoChanged As EventHandler
   Public Event ReciboChanged As EventHandler
   Public Sub OnOrdenChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent OrdenChanged(sender, e)
   End Sub
   Public Sub OnTituloChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent TituloChanged(sender, e)
   End Sub
   Public Sub OnFechaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent FechaChanged(sender, e)
   End Sub
   Public Sub OnENTID_NroDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ENTID_NroDocumentoChanged(sender, e)
   End Sub
   Public Sub OnENTID_RazonSocialChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ENTID_RazonSocialChanged(sender, e)
   End Sub
   Public Sub OnDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent DocumentoChanged(sender, e)
   End Sub
   Public Sub OnMonedaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent MonedaChanged(sender, e)
   End Sub
   Public Sub OnTCambioVentaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent TCambioVentaChanged(sender, e)
   End Sub
   Public Sub OnImpDolaresChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ImpDolaresChanged(sender, e)
   End Sub
   Public Sub OnImpSolesChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ImpSolesChanged(sender, e)
   End Sub
   Public Sub OnFLETE_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent FLETE_IdChanged(sender, e)
   End Sub
   Public Sub OnVIAJE_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent VIAJE_IdChanged(sender, e)
   End Sub
   Public Sub OnENTID_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ENTID_CodigoChanged(sender, e)
   End Sub
   Public Sub OnDOCVE_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent DOCVE_CodigoChanged(sender, e)
   End Sub
   Public Sub OnFLETE_GlosaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent FLETE_GlosaChanged(sender, e)
   End Sub
   Public Sub OnPendienteChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent PendienteChanged(sender, e)
   End Sub
   Public Sub OnDOCVE_FechaDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent DOCVE_FechaDocumentoChanged(sender, e)
   End Sub
   Public Sub OnPagoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent PagoChanged(sender, e)
   End Sub
   Public Sub OnDOCVE_SerieChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent DOCVE_SerieChanged(sender, e)
   End Sub
   Public Sub OnDOCVE_NumeroChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent DOCVE_NumeroChanged(sender, e)
   End Sub
   Public Sub OnTipoDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent TipoDocumentoChanged(sender, e)
   End Sub
   Public Sub OnReciboChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ReciboChanged(sender, e)
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

