Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EABAS_CotizacionesCompra

#Region " Variables "
   Private m_listABAS_CotizacionesCompraDetalle As List(Of EABAS_CotizacionesCompraDetalle)
   Private m_entid_razonsocial As String
   Private m_almac_descripcion As String
   Private m_entid_nrodocumento As String

   Private m_entid_telefono As String
   Private m_entid_correo As String
   Private m_entid_direccion As String


   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum

   Enum TipoPedido
      CT
      RQ
   End Enum
#End Region

#Region " Propiedades "

   Public Property ListABAS_CotizacionesCompraDetalle() As List(Of EABAS_CotizacionesCompraDetalle)
      Get
         Return m_listABAS_CotizacionesCompraDetalle
      End Get
      Set(ByVal value As List(Of EABAS_CotizacionesCompraDetalle))
         m_listABAS_CotizacionesCompraDetalle = value
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

   Public ReadOnly Property COTCO_Estado_Text() As String
      Get
         Select Case m_cotco_estado
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

   Public Property ENTID_Telefono() As String
      Get
         Return m_entid_telefono
      End Get
      Set(ByVal value As String)
         m_entid_telefono = value
      End Set
   End Property

   Public Property ENTID_Correo() As String
      Get
         Return m_entid_correo
      End Get
      Set(ByVal value As String)
         m_entid_correo = value
      End Set
   End Property

   Public Property ENTID_Direccion() As String
      Get
         Return m_entid_direccion
      End Get
      Set(ByVal value As String)
         m_entid_direccion = value
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
