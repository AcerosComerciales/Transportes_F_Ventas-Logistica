Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EPrecios

#Region " Variables "
   Private m_zonas_descripcion As String
   Private m_lprec_id As Long
    Private m_alpre_porcentaventa As Decimal
    Private m_alpre_constante As Decimal
   Private m_tipos_tipomoneda As String
    Private m_preci_id As Long


   Private m_vent_listapreciosarticulos As List(Of EVENT_ListaPreciosArticulos)
#End Region

#Region " Propiedades "
   Public Property ZONAS_Descripcion() As String
      Get
         Return m_zonas_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_zonas_descripcion) Then
            If Not m_zonas_descripcion.Equals(value) Then
               m_zonas_descripcion = value
            End If
         Else
            m_zonas_descripcion = value
         End If
      End Set
   End Property

   Public Property LPREC_Id() As Long
      Get
         Return m_lprec_id
      End Get
      Set(ByVal value As Long)
         m_lprec_id = value
      End Set
   End Property

    Public Property alpre_constante() As Decimal
        Get
            Return m_alpre_constante
        End Get
        Set(ByVal value As Decimal)
            m_alpre_constante = value
        End Set
    End Property

    Public Property ALPRE_PorcentaVenta() As Decimal
        Get
            Return m_alpre_porcentaventa
        End Get
        Set(ByVal value As Decimal)
            m_alpre_porcentaventa = value
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

   Public Property PRECI_Id() As Long
      Get
         Return m_preci_id
      End Get
      Set(ByVal value As Long)
         m_preci_id = value
      End Set
    End Property

   Public Property ListVENT_ListaPreciosArticulos() As List(Of EVENT_ListaPreciosArticulos)
      Get
         Return m_vent_listapreciosarticulos
      End Get
      Set(ByVal value As List(Of EVENT_ListaPreciosArticulos))
         m_vent_listapreciosarticulos = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
