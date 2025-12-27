Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ECONT_DocsPercepcion

#Region " Variables "
   Private m_listcont_docspercepciondetalle As List(Of ECONT_DocsPercepcionDetalle)

   Private m_entid_cliente As String
   Private m_tipos_tipodocumento As String
   Private m_tipos_tipomoneda As String

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum
#End Region

#Region " Propiedades "
   Public Property ListCONT_DocsPercepcionDetalle() As List(Of ECONT_DocsPercepcionDetalle)
      Get
         Return m_listcont_docspercepciondetalle
      End Get
      Set(ByVal value As List(Of ECONT_DocsPercepcionDetalle))
         m_listcont_docspercepciondetalle = value
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

   Public Property TIPOS_TipoDocumento() As String
      Get
         Return m_tipos_tipodocumento
      End Get
      Set(ByVal value As String)
         m_tipos_tipodocumento = value
      End Set
   End Property

   Public Property ENTID_Cliente() As String
      Get
         Return m_entid_cliente
      End Get
      Set(ByVal value As String)
         m_entid_cliente = value
      End Set
   End Property

   Public ReadOnly Property Documento() As String
      Get
         Return String.Format("{0}/{1}-{2}", m_tipos_tipodocumento, m_docpe_serie, m_docpe_numero.ToString().PadLeft(7, "0"))
      End Get
   End Property

   Public ReadOnly Property DOCVE_Estado_Text() As String
      Get
         Select Case m_docpe_estado
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

   Public ReadOnly Property DOCPE_Estado_Text() As String
      Get
         Select Case m_docpe_estado
            Case getEstado(Estado.Anulado)
               Return "Anulado"
            Case getEstado(Estado.Confirmado)
               Return "Confirmado"
            Case getEstado(Estado.Eliminado)
               Return "Eliminado"
            Case getEstado(Estado.Ingresado)
               Return "Ingresado"
            Case Else
               Return "Ingresado"
         End Select
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
