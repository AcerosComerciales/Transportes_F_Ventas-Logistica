Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Imports ACEVentas
Partial Public Class EABAS_DocsCompra
   Implements ICloneable

#Region " Variables "
   Private m_listEABAS_DocsCompraDetalle As List(Of EABAS_DocsCompraDetalle)

   Private m_entid_razonsocial As String
   Private m_almac_descripcion As String
   Private m_tipos_documento As String
   Private m_tipos_moneda As String
   Private m_tipos_tipopago As String
   Private m_entid_nrodocumento As String

   Private m_ordco_serie As String
   Private m_ordco_numero As String

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum
#End Region

#Region " Propiedades "

   Public Property ListEABAS_DocsCompraDetalle() As List(Of EABAS_DocsCompraDetalle)
      Get
         Return m_listEABAS_DocsCompraDetalle
      End Get
      Set(ByVal value As List(Of EABAS_DocsCompraDetalle))
         m_listEABAS_DocsCompraDetalle = value
      End Set
   End Property

   Public Property TIPOS_Documento() As String
      Get
         Return m_tipos_documento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_documento) Then
            If Not m_tipos_documento.Equals(value) Then
               m_tipos_documento = value
            End If
         Else
            m_tipos_documento = value
         End If
      End Set
   End Property

   Public Property ENTID_Proveedor() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_razonsocial) Then
            If Not m_entid_razonsocial.Equals(value) Then
               m_entid_razonsocial = value
            End If
         Else
            m_entid_razonsocial = value
         End If
      End Set
   End Property

   Public Property ALMAC_Descripcion() As String
      Get
         Return m_almac_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_almac_descripcion) Then
            If Not m_almac_descripcion.Equals(value) Then
               m_almac_descripcion = value
            End If
         Else
            m_almac_descripcion = value
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

   Public Property TIPOS_TipoPago() As String
      Get
         Return m_tipos_tipopago
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipopago) Then
            If Not m_tipos_tipopago.Equals(value) Then
               m_tipos_tipopago = value
            End If
         Else
            m_tipos_tipopago = value
         End If
      End Set
   End Property

   Public ReadOnly Property Documento() As String
      Get
         If m_tipos_codtipodocumento = ACEVentas.ETipos.getTipoComprobante(ACEVentas.ETipos.TipoComprobanteVenta.Ticket) Then
            Return String.Format("{0} {1}-{2}", m_tipos_documento, m_docco_serie.PadLeft(4, "0"), m_docco_numero.PadLeft(9, "0"))
         ElseIf m_tipos_codtipodocumento = ACEVentas.ETipos.getTipoComprobante(ACEVentas.ETipos.TipoComprobanteVenta.Factura) Then
            Return String.Format("{0} {1}-{2}", m_tipos_documento, m_docco_serie.PadLeft(3, "0"), m_docco_numero.PadLeft(7, "0"))
         ElseIf m_tipos_codtipodocumento = ACEVentas.ETipos.getTipoComprobante(ACEVentas.ETipos.TipoComprobanteVenta.Boleta) Then
            Return String.Format("{0} {1}-{2}", m_tipos_documento, m_docco_serie.PadLeft(3, "0"), m_docco_numero.PadLeft(7, "0"))
         Else
            Return String.Format("{0} {1}-{2}", m_tipos_documento, m_docco_serie.PadLeft(3, "0"), m_docco_numero.PadLeft(7, "0"))
         End If
      End Get
   End Property

   Public ReadOnly Property DOCCO_Estado_Text() As String
      Get
         Select Case m_docco_estado
            Case getEstado(Estado.Ingresado)
               Return Estado.Ingresado.ToString()
            Case getEstado(Estado.Anulado)
               Return Estado.Anulado.ToString()
            Case getEstado(Estado.Confirmado)
               Return Estado.Confirmado.ToString()
            Case getEstado(Estado.Eliminado)
               Return Estado.Eliminado.ToString()
            Case Else
               Return Estado.Ingresado.ToString()
         End Select
      End Get
   End Property

   Public ReadOnly Property Codigo() As String
      Get
         If IsNothing(m_docco_codigo) Then
            Return ""
         Else
            If m_docco_codigo.Length = 12 Then
               Return Regex.Replace(m_docco_codigo, "^(\d{2})(\d{3})(\d{7})$", "$1 $2-$3")
            ElseIf m_docco_codigo.Length = 13 Then
               Return Regex.Replace(m_docco_codigo, "^(\d{2})(\d{3})(\d{8})$", "$1 $2-$3")
            Else
               Return Regex.Replace(m_docco_codigo, "^(\d{2})(\d{4})(\d{9})$", "$1 $2-$3")
            End If
         End If
      End Get
   End Property

   Public ReadOnly Property CodigoOrden() As String
      Get
         If IsNothing(m_ordco_codigo) Then
            Return ""
         Else
            If m_ordco_codigo.Length = 12 Then
               Return m_ordco_codigo.Substring(0, 2) & " " & Regex.Replace(m_ordco_codigo.Substring(2), "^(\d{3})(\d{7})$", "$1-$2")
            Else
               Return m_ordco_codigo.Substring(0, 2) & " " & Regex.Replace(m_ordco_codigo.Substring(2), "^(\d{43})(\d{9})$", "$1-$2")
            End If
         End If
      End Get
   End Property

   Public ReadOnly Property DocBase() As String
      Get
         If IsNothing(m_ordco_codigo) Then
            Return ""
         Else
            If m_ordco_codigo.Length = 12 Then
               Return m_ordco_codigo.Substring(0, 2) & " " & Regex.Replace(m_ordco_codigo.Substring(2), "^(\d{3})(\d{7})$", "$1-$2")
            Else
               Return m_ordco_codigo.Substring(0, 2) & " " & Regex.Replace(m_ordco_codigo.Substring(2), "^(\d{43})(\d{9})$", "$1-$2")
            End If
         End If
      End Get
   End Property

   Public ReadOnly Property TotalCompraSoles() As Double
      Get
         If m_tipos_codtipomoneda = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
            Return m_docco_totalcompra
         End If
      End Get
   End Property

   Public ReadOnly Property TotalCompraDolares() As Double
      Get
         If m_tipos_codtipomoneda = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
            Return m_docco_totalcompra
         End If
      End Get
   End Property

   Public Property ENTID_NroDocumento() As String
      Get
         Return m_entid_nrodocumento
      End Get
      Set(ByVal value As String)
         m_entid_nrodocumento = value
      End Set
   End Property

   Public Property ORDCO_Numero() As String
      Get
         Return m_ordco_numero
      End Get
      Set(ByVal value As String)
         m_ordco_numero = value
      End Set
   End Property

   Public Property ORDCO_Serie() As String
      Get
         Return m_ordco_serie
      End Get
      Set(ByVal value As String)
         m_ordco_serie = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Shared Function getEstado(ByVal x_opcion As Estado)

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

   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New EABAS_DocsCompra()
         cloneInstance = CType(Me, EABAS_DocsCompra)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
