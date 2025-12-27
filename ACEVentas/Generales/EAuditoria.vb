Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EAuditoria

#Region " Variables "
   Private m_entid_otorgado As String
   Private m_entid_confirmado As String
   Private m_tipos_proceso As String
   Private m_sucursal As String
   Private m_documento As String

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum
#End Region

#Region " Propiedades "
   Public Property ENTID_Otorgado() As String
      Get
         Return m_entid_otorgado
      End Get
      Set(ByVal value As String)
         m_entid_otorgado = value
      End Set
   End Property

   Public Property ENTID_Confirmado() As String
      Get
         Return m_entid_confirmado
      End Get
      Set(ByVal value As String)
         m_entid_confirmado = value
      End Set
   End Property

   Public Property TIPOS_Proceso() As String
      Get
         Return m_tipos_proceso
      End Get
      Set(ByVal value As String)
         m_tipos_proceso = value
      End Set
   End Property

   Public Property Sucursal() As String
      Get
         Return m_sucursal
      End Get
      Set(ByVal value As String)
         m_sucursal = value
      End Set
   End Property

   Public ReadOnly Property AUDIT_Estado_Text() As String
      Get
         Select Case m_audit_estado
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

   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
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
