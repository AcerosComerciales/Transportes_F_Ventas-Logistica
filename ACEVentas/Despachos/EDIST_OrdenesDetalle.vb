Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDIST_OrdenesDetalle

#Region " Campos "
   Private m_artic_descripcion As String
   Private m_tipos_unidadmedida As String
   Private m_pesounitario As Decimal
   Private m_entregado As Decimal
   Private m_diferencia As Decimal
   Private m_docvd_cantidad As Decimal
   Private m_tipos_codunidadmedida As String
   Private m_stockdestino As Decimal
    Private m_linea As String
#End Region

#Region" Constructores "
	
#End Region

#Region" Propiedades "

   Public Property ARTIC_Descripcion() As String
      Get
         Return m_artic_descripcion
      End Get
      Set(ByVal value As String)
         m_artic_descripcion = value
      End Set
   End Property

   Public Property TIPOS_UnidadMedida() As String
      Get
         Return m_tipos_unidadmedida
      End Get
      Set(ByVal value As String)
         m_tipos_unidadmedida = value
      End Set
   End Property

      
       Public Property LINEA_Codigo() As String
      Get
         Return m_linea
      End Get
      Set(ByVal value As String)
         m_linea = value
      End Set
   End Property

   Public Property PesoUnitario() As Decimal
      Get
         Return m_pesounitario
      End Get
      Set(ByVal value As Decimal)
         m_pesounitario = value
      End Set
   End Property

   Public Property Diferencia() As Decimal
      Get
         Return m_diferencia
      End Get
      Set(ByVal value As Decimal)
         m_diferencia = value
      End Set
   End Property

   Public Property Entregado() As Decimal
      Get
         Return m_entregado
      End Get
      Set(ByVal value As Decimal)
         m_entregado = value
      End Set
   End Property

   Public Property DOCVD_Cantidad() As Decimal
      Get
         Return m_docvd_cantidad
      End Get
      Set(ByVal value As Decimal)
         m_docvd_cantidad = value
      End Set
   End Property

   Public Property TIPOS_CodUnidadMedida() As String
      Get
         Return m_tipos_codunidadmedida
      End Get
      Set(ByVal value As String)
         m_tipos_codunidadmedida = value
      End Set
   End Property

   Public Property StockDestino() As Decimal
      Get
         Return m_stockdestino
      End Get
      Set(ByVal value As Decimal)
         m_stockdestino = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

