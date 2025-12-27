Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_DocumentosDetalle

#Region " Variables "
   Private m_entid_razonsocial As String
   Private m_codigo As String
   Private m_pieza_descripcion As String

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum
#End Region

#Region " Propiedades "

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

   Public Property PIEZA_Descripcion() As String
      Get
         Return m_pieza_descripcion
      End Get
      Set(ByVal value As String)
         m_pieza_descripcion = value
      End Set
   End Property


   Public ReadOnly Property Repuesto() As String
      Get
         Return String.Format("{0} - {1}", m_codigo, m_dcdet_descripcion)
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
