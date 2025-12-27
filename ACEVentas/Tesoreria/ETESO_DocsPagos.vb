Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETESO_DocsPagos

#Region " Variables "
   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum

   Private m_banco_nombre As String
   Private m_tipos_moneda As String
   Private m_cuentaId As String

   Private m_importeusado As Decimal
   Private m_docventa As String
   Private m_tipos_tipodocumento As String
   Private m_tipos_tipocuenta As String

   Private m_vent_docsventas As EVENT_DocsVenta
   Private m_listvent_docsventa As List(Of EVENT_DocsVenta)
   Private m_teso_caja As ETESO_Caja
   Private m_listteso_caja As List(Of ETESO_Caja)

   Private m_entid_razonsocial As String

   Private m_impdolares As Decimal
   Private m_impsoles As Decimal
   Private m_eimpdolares As Decimal
   Private m_eimpsoles As Decimal

   Private m_doccaja As String
   Private m_entid_codigocliente As String
   Private m_entid_codigovendedor As String

   Private m_pvent_descripcion As String
   Private m_tipoc_ventasunat As String
   Private m_tipoc_ventarenta As Decimal

   Private m_pvent_zonacontable As String
    Private m_cuenc_codigo As String


   Private m_listAsientos As List(Of CAsientos)
#End Region

#Region " Propiedades "

   Public Property BANCO_Descripcion() As String
      Get
         Return m_banco_nombre
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_banco_nombre) Then
            If Not m_banco_nombre.Equals(value) Then
               m_banco_nombre = value
            End If
         Else
            m_banco_nombre = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoMoneda() As String
      Get
         Return m_tipos_moneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_moneda) Then
            If Not m_tipos_moneda.Equals(value) Then
               m_tipos_moneda = value
            End If
         Else
            m_tipos_moneda = value
         End If
      End Set
   End Property

   Public Property CUENTAS_Id() As String
      Get
         Return m_cuentaId
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_cuentaId) Then
            If Not m_cuentaId.Equals(value) Then
               m_cuentaId = value
            End If
         Else
            m_cuentaId = value
         End If
      End Set
   End Property

   Public ReadOnly Property TIPOS_CodTipoMoneda_Text() As String
      Get
         Select Case m_tipos_codtipomoneda
            Case ETipos.getTipo(ETipos.TipoMoneda.Dolares)
               Return ETipos.TipoMoneda.Dolares.ToString()
            Case ETipos.getTipo(ETipos.TipoMoneda.Soles)
               Return ETipos.TipoMoneda.Soles.ToString()
            Case Else
               Return ETipos.TipoMoneda.Otros.ToString()
         End Select
      End Get
   End Property

   Public Property ImporteUsado() As Decimal
      Get
         Return m_importeusado
      End Get
      Set(ByVal value As Decimal)
         m_importeusado = value
      End Set
   End Property

   Public Property TIPOS_TipoDocumento() As String
      Get
         Return m_tipos_tipodocumento
      End Get
      Set(ByVal value As String)
         m_tipos_tipodocumento = value
      End Set
   End Property

   Public Property TIPOS_TipoCuenta() As String
      Get
         Return m_tipos_tipocuenta
      End Get
      Set(ByVal value As String)
         m_tipos_tipocuenta = value
      End Set
   End Property

   Public Property VENT_DocsVenta() As EVENT_DocsVenta
      Get
         Return m_vent_docsventas
      End Get
      Set(ByVal value As EVENT_DocsVenta)
         m_vent_docsventas = value
      End Set
   End Property

   Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
      Get
         Return m_listvent_docsventa
      End Get
      Set(ByVal value As List(Of EVENT_DocsVenta))
         m_listvent_docsventa = value
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

   Public Property ListTESO_Caja() As List(Of ETESO_Caja)
      Get
         Return m_listteso_caja
      End Get
      Set(ByVal value As List(Of ETESO_Caja))
         m_listteso_caja = value
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

   Public ReadOnly Property DPAGO_Estado_Text() As String
      Get
         Select Case m_dpago_estado
            Case "X"
                    Return "Anulado"
                Case "C"
                    Return "Confirmado"
                Case Else
                    Return "Ingresado"
            End Select
      End Get
   End Property

   Public Property DocVenta() As String
      Get
         Return m_docventa
      End Get
      Set(ByVal value As String)
         m_docventa = value
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

   Public Property ImpSoles() As Decimal
      Get
         Return m_impsoles
      End Get
      Set(ByVal value As Decimal)
         m_impsoles = value
      End Set
   End Property

   Public Property EImpDolares() As Decimal
      Get
         Return m_eimpdolares
      End Get
      Set(ByVal value As Decimal)
         m_eimpdolares = value
      End Set
   End Property

   Public Property EImpSoles() As Decimal
      Get
         Return m_eimpsoles
      End Get
      Set(ByVal value As Decimal)
         m_eimpsoles = value
      End Set
   End Property

   Public Property DocCaja() As String
      Get
         Return m_doccaja
      End Get
      Set(ByVal value As String)
         m_doccaja = value
      End Set
   End Property

   Public Property ENTID_CodigoCliente() As String
      Get
         Return m_entid_codigocliente
      End Get
      Set(ByVal value As String)
         m_entid_codigocliente = value
      End Set
   End Property

   Public Property ENTID_CodigoVendedor() As String
      Get
         Return m_entid_codigovendedor
      End Get
      Set(ByVal value As String)
         m_entid_codigovendedor = value
      End Set
   End Property

   Public Property PVENT_Descripcion() As String
      Get
         Return m_pvent_descripcion
      End Get
      Set(ByVal value As String)
         m_pvent_descripcion = value
      End Set
   End Property

   Public Property TIPOC_VentaSunat() As Decimal
      Get
         Return m_tipoc_ventasunat
      End Get
      Set(ByVal value As Decimal)
         m_tipoc_ventasunat = value
      End Set
   End Property

   Public Property TIPOC_VentaRenta() As Decimal
      Get
         Return m_tipoc_ventarenta
      End Get
      Set(ByVal value As Decimal)
         m_tipoc_ventarenta = value
      End Set
   End Property

   Public Property PVENT_ZonaContable() As String
      Get
         Return m_pvent_zonacontable
      End Get
      Set(ByVal value As String)
         m_pvent_zonacontable = value
      End Set
   End Property

   Public Property CUENC_Codigo() As String
      Get
         Return m_cuenc_codigo
      End Get
      Set(ByVal value As String)
         m_cuenc_codigo = value
      End Set
    End Property


   Public Property ListAsientos() As List(Of CAsientos)
      Get
         Return m_listAsientos
      End Get
      Set(ByVal value As List(Of CAsientos))
         m_listAsientos = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Shared Function getTipoDocumento(ByVal x_tipo As ETipos.TipoDocPago) As String
      Try
         Return String.Format("{0}{1}", ETipos.getCodTipo(ETipos.MyTipos.TipoDocumentoPago), CType(x_tipo, Integer))
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function getEstado(ByVal x_opcion As Estado) As String
      Select Case x_opcion
         Case Estado.Anulado
            Return "X"
         Case Estado.Confirmado
            Return "C"
         Case Estado.Eliminado
            Return "E"
         Case Estado.Ingresado
            Return "I"
         Case Else
            Return "I"
      End Select

   End Function
#End Region

End Class
