Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Public Class ECCuadrePendientes

#Region " Campos "

   Private m_entid_codigo As String
   Private m_entid_razonsocial As String
   Private m_docve_codigo As String
   Private m_tipodocumento As String
   Private m_documento As String
   Private m_docve_fechadocumento As Date
    Private m_tipos_codtipomoneda As String
    Private m_tipos_condicionpago As String
   Private m_tipos_tipomoneda As String
   Private m_pendientesoles As Decimal
   Private m_pendientedolares As Decimal
   Private m_pago As Decimal
   Private m_pagodolares As Decimal
   Private m_impdolares As Decimal
   Private m_impsoles As Decimal
   Private m_tcambioventa As Decimal
   Private m_entid_codigovendedor As String
    Private m_entid_razonsocialvendedor As String
    Private m_entid_codigocotizador As String
    Private m_entid_razonsocialcotizador As String
   Private m_nuevo As Boolean
   Private m_modificado As Boolean
   Private m_eliminado As Boolean

   Private m_hash As Hashtable

   Private m_cheque As String
    Private m_clien_plazocredito As String
   Private m_docve_fechapago As DateTime
   Private m_docve_fechapago_old As DateTime
   Private m_seleccion As Boolean
    Private m_descripion_condicionpago As String
#End Region

#Region " Constructores "

   Public Sub New()
   End Sub

#End Region

#Region " Propiedades "

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
    Public Property TIPOS_CodCondicionPago() As String
        Get
            Return m_tipos_condicionpago
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_condicionpago) Then
                If m_tipos_condicionpago.Equals(value) Then
                    m_tipos_condicionpago = value
                    OnTipos_CodCondicionPagoChanged(m_tipos_condicionpago, EventArgs.Empty)
                End If
            Else
                m_tipos_condicionpago = value
                OnTipos_CodCondicionPagoChanged(m_tipos_condicionpago, EventArgs.Empty)
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

   Public Property TIPOS_CodTipoMoneda() As String
      Get
         Return m_tipos_codtipomoneda
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

   Public Property TIPOS_TipoMoneda() As String
      Get
         Return m_tipos_tipomoneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipomoneda) Then
            If Not m_tipos_tipomoneda.Equals(value) Then
               m_tipos_tipomoneda = value
               OnTIPOS_TipoMonedaChanged(m_tipos_tipomoneda, EventArgs.Empty)
            End If
         Else
            m_tipos_tipomoneda = value
            OnTIPOS_TipoMonedaChanged(m_tipos_tipomoneda, EventArgs.Empty)
         End If
      End Set
   End Property

   Public Property PendienteSoles() As Decimal
      Get
         Return m_pendientesoles
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_pendientesoles) Then
            If Not m_pendientesoles.Equals(value) Then
               m_pendientesoles = value
               OnPendienteSolesChanged(m_pendientesoles, EventArgs.Empty)
            End If
         Else
            m_pendientesoles = value
            OnPendienteSolesChanged(m_pendientesoles, EventArgs.Empty)
         End If
      End Set
   End Property

   Public Property PendienteDolares() As Decimal
      Get
         Return m_pendientedolares
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_pendientedolares) Then
            If Not m_pendientedolares.Equals(value) Then
               m_pendientedolares = value
               OnPendienteDolaresChanged(m_pendientedolares, EventArgs.Empty)
            End If
         Else
            m_pendientedolares = value
            OnPendienteDolaresChanged(m_pendientedolares, EventArgs.Empty)
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

   Public Property PagoDolares() As Decimal
      Get
         Return m_pagodolares
      End Get
      Set(ByVal value As Decimal)
         m_pagodolares = value
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

   Public Property ENTID_CodigoVendedor() As String
      Get
         Return m_entid_codigovendedor
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_codigovendedor) Then
            If Not m_entid_codigovendedor.Equals(value) Then
               m_entid_codigovendedor = value
               OnENTID_CodigoVendedorChanged(m_entid_codigovendedor, EventArgs.Empty)
            End If
         Else
            m_entid_codigovendedor = value
            OnENTID_CodigoVendedorChanged(m_entid_codigovendedor, EventArgs.Empty)
         End If
      End Set
   End Property

   Public Property ENTID_RazonSocialVendedor() As String
      Get
         Return m_entid_razonsocialvendedor
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_razonsocialvendedor) Then
            If Not m_entid_razonsocialvendedor.Equals(value) Then
               m_entid_razonsocialvendedor = value
               OnENTID_RazonSocialVendedorChanged(m_entid_razonsocialvendedor, EventArgs.Empty)
            End If
         Else
            m_entid_razonsocialvendedor = value
            OnENTID_RazonSocialVendedorChanged(m_entid_razonsocialvendedor, EventArgs.Empty)
         End If
      End Set
    End Property
    Public Property ENTID_CodigoCotizador() As String
        Get
            Return m_entid_codigocotizador
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_codigocotizador) Then
                If Not m_entid_codigocotizador.Equals(value) Then
                    m_entid_codigocotizador = value
                    OnENTID_CodigoCotizadorChanged(m_entid_codigocotizador, EventArgs.Empty)
                End If
            Else
                m_entid_codigocotizador = value
                OnENTID_CodigoCotizadorChanged(m_entid_codigocotizador, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TIPOS_Descripcion_CondicionPago() As String
        Get
            Return m_descripion_condicionpago
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_descripion_condicionpago) Then
                If Not m_descripion_condicionpago.Equals(value) Then
                    m_descripion_condicionpago = value
                    OnTIPOS_Descripcion_CondicionPagoChanged(m_descripion_condicionpago, EventArgs.Empty)
                End If
            Else
                m_descripion_condicionpago = value
                OnTIPOS_Descripcion_CondicionPagoChanged(m_descripion_condicionpago, EventArgs.Empty)
            End If
        End Set
    End Property

   Public Property DOCVE_FechaPago() As DateTime
      Get
         Return m_docve_fechapago
      End Get
      Set(ByVal value As DateTime)
         m_docve_fechapago = value
      End Set
   End Property

   Public Property DOCVE_FechaPago_Old() As DateTime
      Get
         Return m_docve_fechapago_old
      End Get
      Set(ByVal value As DateTime)
         m_docve_fechapago_old = value
      End Set
   End Property

   Public Property Seleccion() As Boolean
      Get
         Return m_seleccion
      End Get
      Set(ByVal value As Boolean)
         m_seleccion = value
      End Set
    End Property
    Public Property ENTID_RazonSocialCotizador() As String
        Get
            Return m_entid_razonsocialcotizador
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_razonsocialcotizador) Then
                If Not m_entid_razonsocialcotizador.Equals(value) Then
                    m_entid_razonsocialcotizador = value
                    OnENTID_RazonSocialCotizadorChanged(m_entid_razonsocialcotizador, EventArgs.Empty)
                End If
            Else
                m_entid_razonsocialcotizador = value
                OnENTID_RazonSocialCotizadorChanged(m_entid_razonsocialcotizador, EventArgs.Empty)
            End If
        End Set
    End Property

#Region " Propiedades de Solo Lectura "

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
         Return "VENT_CAJASS_CuadrePendientes"
      End Get
   End Property

   Public Shared ReadOnly Property Esquema() As String
      Get
         Return ""
      End Get
   End Property

   Public Property Cheque() As String
      Get
         Return m_cheque
      End Get
      Set(ByVal value As String)
         m_cheque = value
      End Set
   End Property
    Public Property CLIEN_PlazoCredito() As String
      Get
         Return m_clien_plazocredito
      End Get
      Set(ByVal value As String)
         m_clien_plazocredito = value
      End Set
   End Property
#End Region

#End Region

#Region " Eventos "

   Public Event ENTID_CodigoChanged As EventHandler
   Public Event ENTID_RazonSocialChanged As EventHandler
   Public Event DOCVE_CodigoChanged As EventHandler
   Public Event TipoDocumentoChanged As EventHandler
   Public Event DocumentoChanged As EventHandler
   Public Event DOCVE_FechaDocumentoChanged As EventHandler
   Public Event TIPOS_CodTipoMonedaChanged As EventHandler
   Public Event TIPOS_TipoMonedaChanged As EventHandler
   Public Event PendienteSolesChanged As EventHandler
   Public Event PendienteDolaresChanged As EventHandler
   Public Event PagoChanged As EventHandler
   Public Event ImpDolaresChanged As EventHandler
   Public Event ImpSolesChanged As EventHandler
   Public Event TCambioVentaChanged As EventHandler
   Public Event ENTID_CodigoVendedorChanged As EventHandler
    Public Event ENTID_RazonSocialVendedorChanged As EventHandler
    Public Event ENTID_CodigoCotizadorChanged As EventHandler
    Public Event ENTID_RazonSocialCotizadorChanged As EventHandler

    Public Event TIPOS_CodCondicionPagoChanged As EventHandler
    Public Event TIPOS_Descripcion_CondicionPagoChanged As EventHandler

   Public Sub OnENTID_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ENTID_CodigoChanged(sender, e)
   End Sub

   Public Sub OnENTID_RazonSocialChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ENTID_RazonSocialChanged(sender, e)
   End Sub

   Public Sub OnDOCVE_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent DOCVE_CodigoChanged(sender, e)
   End Sub

   Public Sub OnTipoDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent TipoDocumentoChanged(sender, e)
   End Sub

   Public Sub OnDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent DocumentoChanged(sender, e)
   End Sub

   Public Sub OnDOCVE_FechaDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent DOCVE_FechaDocumentoChanged(sender, e)
   End Sub

   Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
   End Sub

   Public Sub OnTIPOS_TipoMonedaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent TIPOS_TipoMonedaChanged(sender, e)
   End Sub

   Public Sub OnPendienteSolesChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent PendienteSolesChanged(sender, e)
   End Sub

   Public Sub OnPendienteDolaresChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent PendienteDolaresChanged(sender, e)
   End Sub

   Public Sub OnPagoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent PagoChanged(sender, e)
   End Sub

   Public Sub OnImpDolaresChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ImpDolaresChanged(sender, e)
   End Sub

   Public Sub OnImpSolesChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ImpSolesChanged(sender, e)
   End Sub

   Public Sub OnTCambioVentaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent TCambioVentaChanged(sender, e)
   End Sub

   Public Sub OnENTID_CodigoVendedorChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ENTID_CodigoVendedorChanged(sender, e)
   End Sub

   Public Sub OnENTID_RazonSocialVendedorChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ENTID_RazonSocialVendedorChanged(sender, e)
    End Sub

    Public Sub OnENTID_CodigoCotizadorChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_CodigoCotizadorChanged(sender, e)
    End Sub

    Public Sub OnENTID_RazonSocialCotizadorChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_RazonSocialCotizadorChanged(sender, e)
    End Sub
    Public Sub OnTipos_CodCondicionPagoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodCondicionPagoChanged(sender, e)

    End Sub

    Public Sub OnTIPOS_Descripcion_CondicionPagoChanged(ByVal Sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_Descripcion_CondicionPagoChanged(Sender, e)
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
