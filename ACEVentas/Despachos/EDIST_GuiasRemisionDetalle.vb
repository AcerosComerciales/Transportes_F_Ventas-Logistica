Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDIST_GuiasRemisionDetalle

#Region " Campos "
   Private m_artic_descripcion As String
   Private m_titulo As String
   Private m_tipos_unidadmedida As String
   Private m_tipos_unidadmedidacorta As String
   Private m_almac_descripcion As String

   Private m_earticulo As EArticulos

   Private m_diferencia As Decimal
   Private m_entregado As Decimal

   Private m_docvd_cantidad As Decimal

   Private m_docvd_pesounitario As Decimal
   Private m_tipos_codunidadmedida As String
#End Region

#Region" Constructores "
	
#End Region

#Region" Propiedades "
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

       Public Property Titulo() As String
      Get
         Return m_titulo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_titulo) Then
            If Not m_titulo.Equals(value) Then
               m_titulo = value
            End If
         Else
            m_titulo = value
         End If
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
         Return m_tipos_unidadmedidacorta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_unidadmedidacorta) Then
            If Not m_tipos_unidadmedidacorta.Equals(value) Then
               m_tipos_unidadmedidacorta = value
            End If
         Else
            m_tipos_unidadmedidacorta = value
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

   Public Property Articulo() As EArticulos
      Get
         Return m_earticulo
      End Get
      Set(ByVal value As EArticulos)
         m_earticulo = value
      End Set
   End Property

   Public ReadOnly Property SubPeso() As Decimal
      Get
         Return m_guird_cantidad * m_guird_pesounitario
      End Get
   End Property

   Public Property Diferencia() As Decimal
      Get
         Return m_diferencia
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_diferencia) Then
            If Not m_diferencia.Equals(value) Then
               m_diferencia = value
            End If
         Else
            m_diferencia = value
         End If
      End Set
   End Property

   Public Property Entregado() As Decimal
      Get
         Return m_entregado
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_entregado) Then
            If Not m_entregado.Equals(value) Then
               m_entregado = value
            End If
         Else
            m_entregado = value
         End If
      End Set
   End Property

   Public Property DOCVD_Cantidad() As Decimal
      Get
         Return m_docvd_cantidad
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_docvd_cantidad) Then
            If Not m_docvd_cantidad.Equals(value) Then
               m_docvd_cantidad = value
            End If
         Else
            m_docvd_cantidad = value
         End If
      End Set
   End Property

   Public Property DOCVD_PesoUnitario() As Decimal
      Get
         Return m_docvd_pesounitario
      End Get
      Set(ByVal value As Decimal)
         m_docvd_pesounitario = value
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

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

