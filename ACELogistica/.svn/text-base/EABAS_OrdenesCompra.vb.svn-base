Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Partial Public Class EABAS_OrdenesCompra

#Region " Variables "
   Private m_ListABAS_OrdenesCompraDetalle As List(Of EABAS_OrdenesCompraDetalle)
   Private m_entid_razonsocial As String
   Private m_almac_descripcion As String
   Private m_entid_nrodocumento As String
   Private m_tipos_moneda As String
   Private m_doccompra As String

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum

   Enum TipoPedido
      OC
   End Enum
#End Region

#Region " Propiedades "

   Public Property ListABAS_OrdenesCompraDetalle() As List(Of EABAS_OrdenesCompraDetalle)
      Get
         Return m_ListABAS_OrdenesCompraDetalle
      End Get
      Set(ByVal value As List(Of EABAS_OrdenesCompraDetalle))
         m_ListABAS_OrdenesCompraDetalle = value
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

   Public Property ENTID_NroDocumento() As String
      Get
         Return m_entid_nrodocumento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_nrodocumento) Then
            If Not m_entid_nrodocumento.Equals(value) Then
               m_entid_nrodocumento = value
            End If
         Else
            m_entid_nrodocumento = value
         End If
      End Set
   End Property

   Public ReadOnly Property ORDCO_Estado_Text() As String
      Get
         Select Case m_ordco_estado
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

   Public ReadOnly Property DocReferencia() As String
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

   Public ReadOnly Property DocBase() As String
      Get
         If IsNothing(m_cotco_codigo) Then
            Return ""
         Else
            If m_cotco_codigo.Length = 12 Then
               Return m_cotco_codigo.Substring(0, 2) & " " & Regex.Replace(m_cotco_codigo.Substring(2), "^(\d{3})(\d{7})$", "$1-$2")
            Else
               Return m_cotco_codigo.Substring(0, 2) & " " & Regex.Replace(m_cotco_codigo.Substring(2), "^(\d{43})(\d{9})$", "$1-$2")
            End If
         End If
      End Get
   End Property

   Public ReadOnly Property Codigo() As String
      Get
         If IsNothing(m_ordco_codigo) Then
            Return ""
         Else
            If m_ordco_codigo.Length = 12 Then
               Return m_ordco_codigo.Substring(0, 2) & " " & Regex.Replace(m_ordco_codigo.Substring(2), "^(\d{3})(\d{7})$", "$1-$2")
            Else
               Return m_ordco_codigo.Substring(0, 2) & " " & Regex.Replace(m_ordco_codigo.Substring(2), "^(\d{4})(\d{9})$", "$1-$2")
            End If
         End If
      End Get
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

   Public Property DocCompra() As String
      Get
         Return m_doccompra
      End Get
      Set(ByVal value As String)
         m_doccompra = value
      End Set
   End Property

   Public ReadOnly Property Documento() As String
      Get
         Return String.Format("{2} {0}-{1:0000000}", m_ordco_serie, m_ordco_numero, m_ordco_codigo.Substring(0, 2))
      End Get
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
#End Region

End Class
