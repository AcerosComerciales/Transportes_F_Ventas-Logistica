Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_Documentos

#Region " Variables "
   Private m_listETRAN_DocumentosDetalle As List(Of ETRAN_DocumentosDetalle)

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum

   Private m_entid_cliente As String
   Private m_entid_nrodocumento As String
   Private m_tipos_documento As String
   Private m_tipos_doccorta As String
   Private m_tipos_moneda As String
   Private m_entid_direccion As String
   Private m_entid_razonsocial As String
   Private m_codigo As String

#End Region

#Region " Propiedades "
   Public Property ListETRAN_DocumentosDetalle() As List(Of ETRAN_DocumentosDetalle)
      Get
         Return m_listETRAN_DocumentosDetalle
      End Get
      Set(ByVal value As List(Of ETRAN_DocumentosDetalle))
         m_listETRAN_DocumentosDetalle = value
      End Set
   End Property

   Public ReadOnly Property Documento() As String
      Get
         Return String.Format("{0} {1}-{2}", m_tipos_doccorta, m_docus_serie.PadLeft(3, "0"), m_docus_numero.ToString().PadLeft(7, "0"))
      End Get
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

   Public Property ENTID_Cliente() As String
      Get
         Return m_entid_cliente
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_cliente) Then
            If Not m_entid_cliente.Equals(value) Then
               m_entid_cliente = value
            End If
         Else
            m_entid_cliente = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoDocumento() As String
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

   Public Property TIPOS_TipoDocCorta() As String
      Get
         Return m_tipos_doccorta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_doccorta) Then
            If Not m_tipos_doccorta.Equals(value) Then
               m_tipos_doccorta = value
            End If
         Else
            m_tipos_doccorta = value
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

   Public ReadOnly Property DOCUS_Estado_Text() As String
      Get
         Select Case m_docus_estado
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

   Public Property ENTID_Direccion() As String
      Get
         Return m_entid_direccion
      End Get
      Set(ByVal value As String)
         m_entid_direccion = value
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

   Public Property Codigo() As String
      Get
         Return m_codigo
      End Get
      Set(ByVal value As String)
         m_codigo = value
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
#End Region

End Class
