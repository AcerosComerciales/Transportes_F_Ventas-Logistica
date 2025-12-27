Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EVENT_PVentDocumento

#Region " Variables "
   Private m_sucur_nombre As String
   Private m_pvent_descripcion As String
   Private m_tipos_descripcion As String
#End Region

#Region " Propiedades "
   Public Property SUCUR_Nombre() As String
      Get
         Return m_sucur_nombre
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_sucur_nombre) Then
            If Not m_sucur_nombre.Equals(value) Then
               m_sucur_nombre = value
            End If
         Else
            m_sucur_nombre = value
         End If
      End Set
   End Property

   Public Property PVENT_Descripcion() As String
      Get
         Return m_pvent_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_pvent_descripcion) Then
            If Not m_pvent_descripcion.Equals(value) Then
               m_pvent_descripcion = value
            End If
         Else
            m_pvent_descripcion = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoDocumento() As String
      Get
         Return m_tipos_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_descripcion) Then
            If Not m_tipos_descripcion.Equals(value) Then
               m_tipos_descripcion = value
            End If
         Else
            m_tipos_descripcion = value
         End If
      End Set
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
