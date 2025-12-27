Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ELOG_Stocks

#Region " Campos "
   Private m_stock_cantidad As Decimal
   Private m_almac_descripcion As String
   Private m_orden As Short
   Private m_vspva_parapedidos As Boolean
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

   Public Property ALMAC_Descripcion() As String
      Get
         Return m_almac_descripcion
      End Get
      Set(ByVal value As String)
         m_almac_descripcion = value
      End Set
   End Property

   Public Property STOCK_Cantidad() As Decimal
      Get
         Return m_stock_cantidad
      End Get
      Set(ByVal value As Decimal)
         m_stock_cantidad = value
      End Set
   End Property

   Public Property Orden() As Short
      Get
         Return m_orden
      End Get
      Set(ByVal value As Short)
         m_orden = value
      End Set
   End Property

   Public Property VSPVA_ParaPedidos() As Boolean
      Get
         Return m_vspva_parapedidos
      End Get
      Set(ByVal value As Boolean)
         m_vspva_parapedidos = value
      End Set
   End Property

#End Region

#Region " Eventos "

#End Region

#Region " Metodos "

#End Region

End Class

