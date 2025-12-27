Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EVENT_PedidosDetalle

#Region " Variables "
   Private m_artic_descripcion As String
   Private m_almac_descripcion As String
   Private m_tipos_unidadmedida As String
   Private m_articulo As EArticulos
   Private m_tipos_codunidadmedida As String
   Private m_artic_peso As Decimal
     Private m_titulo As String
   Private m_artic_percepcion As Boolean

   Private m_diferencia As Decimal
   Private m_entregado As Decimal
#End Region

#Region " Propiedades "
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


   Public Property Articulo() As EArticulos
      Get
         Return m_articulo
      End Get
      Set(ByVal value As EArticulos)
         m_articulo = value
      End Set
   End Property

   Public Property ALMAC_Descripcion() As String
      Get
         Return m_almac_descripcion
      End Get
      Set(ByVal value As String)
         m_almac_descripcion = value
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

   Public Property TIPOS_CodUnidadMedida() As String
      Get
         Return m_tipos_codunidadmedida
      End Get
      Set(ByVal value As String)
         m_tipos_codunidadmedida = value
      End Set
   End Property

   Public Property ARTIC_Peso() As Decimal
      Get
         Return m_artic_peso
      End Get
      Set(ByVal value As Decimal)
         m_artic_peso = value
      End Set
   End Property

   Public Property ARTIC_Percepcion() As Boolean
      Get
         Return m_artic_percepcion
      End Get
      Set(ByVal value As Boolean)
         m_artic_percepcion = value
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


#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
