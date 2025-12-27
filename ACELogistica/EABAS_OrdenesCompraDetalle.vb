Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports ACEVentas


Partial Public Class EABAS_OrdenesCompraDetalle

#Region " Variables "
    Private m_earticulo As ACEVentas.EArticulos
   Private m_listeabas_listaprecioscompra As List(Of EABAS_ListaPreciosCompra)
   Private m_artic_descripcion As String
   Private m_tipos_unidadmedida As String
   Private m_tipos_unidadmedidadescc As String
#End Region

#Region " Propiedades "
    Public Property Articulo() As ACEVentas.EArticulos
        Get
            Return m_earticulo
        End Get
        Set(ByVal value As ACEVentas.EArticulos)
            m_earticulo = value
        End Set
    End Property

   Public Property ARTIC_Descripcion() As String
      Get
         Return m_artic_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_artic_descripcion) Then
            If Not m_artic_descripcion.Equals(value) Then
               m_artic_descripcion = value
            End If
         Else
            m_artic_descripcion = value
         End If
      End Set
   End Property

   Public Property ListEABAS_ListaPreciosCompra() As List(Of EABAS_ListaPreciosCompra)
      Get
         Return m_listeabas_listaprecioscompra
      End Get
      Set(ByVal value As List(Of EABAS_ListaPreciosCompra))
         m_listeabas_listaprecioscompra = value
      End Set
   End Property

   Public Property TIPOS_UnidadMedida() As String
      Get
         Return m_tipos_unidadmedida
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_unidadmedida) Then
            If Not m_tipos_unidadmedida.Equals(value) Then
               m_tipos_unidadmedida = value
            End If
         Else
            m_tipos_unidadmedida = value
         End If
      End Set
   End Property

   Public Property TIPOS_UnidadMedidaCorta() As String
      Get
         Return m_tipos_unidadmedidadescc
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_unidadmedidadescc) Then
            If Not m_tipos_unidadmedidadescc.Equals(value) Then
               m_tipos_unidadmedidadescc = value
            End If
         Else
            m_tipos_unidadmedidadescc = value
         End If
      End Set
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
