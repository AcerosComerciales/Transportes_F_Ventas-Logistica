Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports ACEVentas


Partial Public Class ETRAN_GuiasTransportistaDetalles

#Region " Variables "
   Private m_earticulo As EArticulos

   Private m_diferencia As Double
   Private m_entregado As Double
   Private m_totaldoc As Double

#End Region

#Region " Propiedades "
   Public Property Articulo() As EArticulos
      Get
         Return m_earticulo
      End Get
      Set(ByVal value As EArticulos)
         m_earticulo = value
      End Set
   End Property

   Public Property Diferencia() As Double
      Get
         Return m_diferencia
      End Get
      Set(ByVal value As Double)
         If Not IsNothing(m_diferencia) Then
            If Not m_diferencia.Equals(value) Then
               m_diferencia = value
            End If
         Else
            m_diferencia = value
         End If
      End Set
   End Property

   Public Property TotalDoc() As Double
      Get
         Return m_totaldoc
      End Get
      Set(ByVal value As Double)
         m_totaldoc = value
      End Set
   End Property

   Public ReadOnly Property SubPeso() As Decimal
      Get
         Return m_gtdet_cantidad * m_gtdet_peso
      End Get
   End Property



   Public Property Entregado() As Double
      Get
         Return m_entregado
      End Get
      Set(ByVal value As Double)
         If Not IsNothing(m_entregado) Then
            If Not m_entregado.Equals(value) Then
               m_entregado = value
            End If
         Else
            m_entregado = value
         End If
      End Set
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
