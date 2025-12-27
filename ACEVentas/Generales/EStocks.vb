Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EStocks

#Region " Variables "
   Private m_almac_descripcion As String

   Private m_orden As Integer
#End Region

#Region " Propiedades "
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

   Public Property Orden() As Integer
      Get
         Return m_orden
      End Get
      Set(ByVal value As Integer)
         m_orden = value
      End Set
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
