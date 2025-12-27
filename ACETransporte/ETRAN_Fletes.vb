Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACEVentas

Partial Public Class ETRAN_Fletes
    Private m_listTRAN_Fletes As List(Of ETRAN_Fletes)
#Region " Variables "

    Private m_ubigo_codorigen As String
    Private m_ubigo_coddestino As String
    Private m_entid_nombre As String
    Private m_rutas_nombre As String
    Private m_flete As String
    Private m_cotiz_carga As String
    Private m_ordtr_codigo As String
    Private m_condu_sigla As String

    Private m_entid_nrodocumento As String
    Private m_entid_razonsocial As String

    Private m_seleccionar As Boolean

    Private m_vingr_id As Integer

    Private m_viaje_descripcion As String
    Private m_salida As String
    Private m_llegada As String
    Private m_importepagar As Decimal
    Private m_importeigv As Decimal
    Private m_tpago As ETipos.TipoDePago
    Private m_tipos_tipomoneda As String
    Private m_usuario As String
    Private m_totalpagado As Decimal
    Private m_factura As String
    Private m_tipos_codtipodocumento As String
    Private m_tipos_docpago As String
    Private m_docve_codigo As String
    Private m_documento As String

    Private m_teso_caja As ETESO_Caja

    Private m_pago As Decimal
    Private m_pendiente As Decimal

    Private m_fecsalida As DateTime
    Private m_fecllegada As DateTime
    Private m_docve_fechadocumento As DateTime

    Private m_tipotransaccion As String
    Private m_tipodocumento As String

    Private m_impdolares As Decimal
    Private m_impsoles As Decimal
    Private m_tcambioventa As Decimal

    Private m_glosaagrupada As String

    Enum Estados
        Ingresado
        Activo
        Facturado
        Cotizado
        Anulado
    End Enum
#End Region

#Region " Propiedades "
    Public Property listTRAN_Fletes() As List(Of ETRAN_Fletes)
        Get
            Return m_listTRAN_Fletes
        End Get
        Set(ByVal value As List(Of ETRAN_Fletes))
            m_listTRAN_Fletes = value
        End Set
    End Property
    Public ReadOnly Property Flete() As String
        Get
            Return String.Format("{0} - {1}", FLETE_CODIGO_Text, m_entid_nombre)
        End Get
    End Property

    Public Property UBIGO_ORIGEN() As String
        Get
            Return m_ubigo_codorigen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_ubigo_codorigen) Then
                If Not m_ubigo_codorigen.Equals(value) Then
                    m_ubigo_codorigen = value
                End If
            Else
                m_ubigo_codorigen = value
            End If
        End Set
    End Property

    Public Property UBIGO_DESTINO() As String
        Get
            Return m_ubigo_coddestino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_ubigo_coddestino) Then
                If Not m_ubigo_coddestino.Equals(value) Then
                    m_ubigo_coddestino = value
                End If
            Else
                m_ubigo_coddestino = value
            End If
        End Set
    End Property

    Public Property ENTID_Nombres() As String
        Get
            Return m_entid_nombre
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_nombre) Then
                If Not m_entid_nombre.Equals(value) Then
                    m_entid_nombre = value
                End If
            Else
                m_entid_nombre = value
            End If
        End Set
    End Property

    Public Property RUTAS_Nombre() As String
        Get
            Return m_rutas_nombre
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_rutas_nombre) Then
                If Not m_rutas_nombre.Equals(value) Then
                    m_rutas_nombre = value
                End If
            Else
                m_rutas_nombre = value
            End If
        End Set
    End Property

    Public ReadOnly Property FLETE_CODIGO_Text() As String
        Get
            If IsNothing(m_flete_codigo) Then
                Return ""
            Else
                Return m_flete_codigo.Substring(4)
            End If
        End Get
    End Property

    Public Property COTIZ_Carga() As String
        Get
            Return m_cotiz_carga
        End Get
        Set(ByVal value As String)
            m_cotiz_carga = value
        End Set
    End Property

    Public Property ENTID_RazonSocial() As String
        Get
            Return m_entid_razonsocial
        End Get
        Set(ByVal value As String)
            m_entid_razonsocial = value
        End Set
    End Property

    Public Property Seleccionar() As Boolean
        Get
            Return m_seleccionar
        End Get
        Set(ByVal value As Boolean)
            m_seleccionar = value
        End Set
    End Property

    Public Property VINGR_Id() As Integer
        Get
            Return m_vingr_id
        End Get
        Set(ByVal value As Integer)
            m_vingr_id = value
        End Set
    End Property

    Public Property ENTID_NroDocumento() As String
        Get
            Return m_entid_nrodocumento
        End Get
        Set(ByVal value As String)
            m_entid_nrodocumento = value
        End Set
    End Property

    Public Property VIAJE_Descripcion() As String
        Get
            Return m_viaje_descripcion
        End Get
        Set(ByVal value As String)
            m_viaje_descripcion = value
        End Set
    End Property

    Public Property Salida() As String
        Get
            Return m_salida
        End Get
        Set(ByVal value As String)
            m_salida = value
        End Set
    End Property

    Public Property Llegada() As String
        Get
            Return m_llegada
        End Get
        Set(ByVal value As String)
            m_llegada = value
        End Set
    End Property

    Public Property ImportePagar() As Decimal
        Get
            Return m_importepagar
        End Get
        Set(ByVal value As Decimal)
            m_importepagar = value
        End Set
    End Property
    Public Property ImporteIgv() As Decimal
        Get
            Return m_importeigv
        End Get
        Set(ByVal value As Decimal)
            m_importeigv = value
        End Set
    End Property

    Public Property TipoDePago() As ETipos.TipoDePago
        Get
            Return m_tpago
        End Get
        Set(ByVal value As ETipos.TipoDePago)
            m_tpago = value
        End Set
    End Property

    Public Property TIPOS_TipoMoneda() As String
        Get
            Return m_tipos_tipomoneda
        End Get
        Set(ByVal value As String)
            m_tipos_tipomoneda = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property

    Public Property TotalPagado() As Decimal
        Get
            Return m_totalpagado
        End Get
        Set(ByVal value As Decimal)
            m_totalpagado = value
        End Set
    End Property

    Public Property Factura() As String
        Get
            Return m_factura
        End Get
        Set(ByVal value As String)
            m_factura = value
        End Set
    End Property

    Public Property TIPOS_CodTipoDocumento() As String
        Get
            Return m_tipos_codtipodocumento
        End Get
        Set(ByVal value As String)
            m_tipos_codtipodocumento = value
        End Set
    End Property

    Public Property TIPOS_DocPago() As String
        Get
            Return m_tipos_docpago
        End Get
        Set(ByVal value As String)
            m_tipos_docpago = value
        End Set
    End Property

    Public Property DOCVE_Codigo() As String
        Get
            Return m_docve_codigo
        End Get
        Set(ByVal value As String)
            m_docve_codigo = value
        End Set
    End Property

    Public Property Documento() As String
        Get
            Return m_documento
        End Get
        Set(ByVal value As String)
            m_documento = value
        End Set
    End Property

    Public Property TESO_Caja() As ETESO_Caja
        Get
            Return m_teso_caja
        End Get
        Set(ByVal value As ETESO_Caja)
            m_teso_caja = value
        End Set
    End Property

    Public ReadOnly Property Saldo() As Decimal
        Get
            Return m_flete_totingreso - m_totalpagado
        End Get
    End Property

    Public Property Pendiente() As Decimal
        Get
            Return m_pendiente
        End Get
        Set(ByVal value As Decimal)
            m_pendiente = value
        End Set
    End Property

    Public Property Pago() As Decimal
        Get
            Return m_pago
        End Get
        Set(ByVal value As Decimal)
            m_pago = value
        End Set
    End Property

    Public Property FecLlegada() As DateTime
        Get
            Return m_fecllegada
        End Get
        Set(ByVal value As DateTime)
            m_fecllegada = value
        End Set
    End Property

    Public Property FecSalida() As DateTime
        Get
            Return m_fecsalida
        End Get
        Set(ByVal value As DateTime)
            m_fecsalida = value
        End Set
    End Property

    Public Property TipoTransaccion() As String
        Get
            Return m_tipotransaccion
        End Get
        Set(ByVal value As String)
            m_tipotransaccion = value
        End Set
    End Property

    Public Property DOCVE_FechaDocumento() As DateTime
        Get
            Return m_docve_fechadocumento
        End Get
        Set(ByVal value As DateTime)
            m_docve_fechadocumento = value
        End Set
    End Property

    Public Property TipoDocumento() As String
        Get
            Return m_tipodocumento
        End Get
        Set(ByVal value As String)
            m_tipodocumento = value
        End Set
    End Property

    Public Property TCambioVenta() As Decimal
        Get
            Return m_tcambioventa
        End Get
        Set(ByVal value As Decimal)
            m_tcambioventa = value
        End Set
    End Property

    Public Property ImpSoles() As Decimal
        Get
            Return m_impsoles
        End Get
        Set(ByVal value As Decimal)
            m_impsoles = value
        End Set
    End Property

    Public Property ImpDolares() As Decimal
        Get
            Return m_impdolares
        End Get
        Set(ByVal value As Decimal)
            m_impdolares = value
        End Set
    End Property

    Public Property GlosaAgrupada() As String
        Get
            Return m_glosaagrupada
        End Get
        Set(ByVal value As String)
            m_glosaagrupada = value
        End Set
    End Property

    Public ReadOnly Property CodigoNombre() As String
        Get
            Return String.Format("{0} - {1}", m_flete_id, ENTID_Nombres)
        End Get
    End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

   Public Property ORDTR_Codigo() As String
      Get
         Return m_ordtr_codigo
      End Get
      Set(ByVal value As String)
         m_ordtr_codigo = value
      End Set
   End Property

   Public Property CONDU_Sigla() As String
      Get
         Return m_condu_sigla
      End Get
      Set(ByVal value As String)
         m_condu_sigla = value
      End Set
   End Property

   Public Shared Function getEstado(ByVal Estado As Estados) As String
      Select Case Estado
         Case Estados.Ingresado : Return "I"
         Case Estados.Activo : Return "A"
         Case Estados.Cotizado : Return "C"
         Case Estados.Facturado : Return "F"
         Case Estados.Anulado : Return "X"
         Case Else : Return "A"
      End Select
   End Function

#End Region

End Class
