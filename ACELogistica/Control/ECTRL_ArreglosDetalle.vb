Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECTRL_ArreglosDetalle

#Region " Campos "
   Private m_articulos As ACEVentas.EArticulos

   Private m_artic_descripcion As String
   Private m_tipos_unidadmedida As String
   Private m_artic_peso As Decimal
   Private m_tipos_codunidadmedida As String
#End Region

#Region" Constructores "
	
#End Region

#Region" Propiedades "

   Public Property Articulo() As ACEVentas.EArticulos
      Get
         Return m_articulos
      End Get
      Set(ByVal value As ACEVentas.EArticulos)
         m_articulos = value
      End Set
   End Property

   Public Property ARTIC_Descripcion() As String
      Get
         Return m_artic_descripcion
      End Get
      Set(ByVal value As String)
         m_artic_descripcion = value
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

   Public Property TIPOS_UnidadMedida() As String
      Get
         Return m_tipos_unidadmedida
      End Get
      Set(ByVal value As String)
         m_tipos_unidadmedida = value
      End Set
   End Property

   Public Property ARTIC_Peso() As Decimal
      Get
         Return m_ARTIC_Peso
      End Get
      Set(ByVal value As Decimal)
         m_ARTIC_Peso = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

