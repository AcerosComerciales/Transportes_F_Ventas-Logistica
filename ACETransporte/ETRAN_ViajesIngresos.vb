Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_ViajesIngresos

#Region " Variables "
   Private m_tran_documentos As ETRAN_Documentos

   Private m_documento As String
   Private m_entid_razonsocial As String
   Private m_tipos_moneda As String

   Public ReadOnly Property SerieRecibo() As String
      Get
         If IsNothing(m_recib_codigo) Then
            Return ""
         Else
            Return String.Format("{0}", m_recib_codigo.Substring(2, 3))
         End If
      End Get
   End Property

   Public ReadOnly Property NumeroRecibo() As String
      Get
         If IsNothing(m_recib_codigo) Then
            Return ""
         Else
            Return String.Format("{0}", Right(m_recib_codigo, 7))
         End If
      End Get
   End Property

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum
#End Region

#Region " Propiedades "
   Public Property TIPOS_Moneda() As String
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

   Public Property TRAN_Documentos() As ETRAN_Documentos
      Get
         Return m_tran_documentos
      End Get
      Set(ByVal value As ETRAN_Documentos)
         m_tran_documentos = value
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

   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         m_entid_razonsocial = value
      End Set
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Shared Function getEstado(ByVal x_opcion As Estado)
      Select Case x_opcion
         Case Estado.Anulado : Return "X"
         Case Estado.Confirmado : Return "C"
         Case Estado.Eliminado : Return "E"
         Case Estado.Ingresado : Return "I"
         Case Else : Return "I"
      End Select
   End Function
#End Region

End Class
