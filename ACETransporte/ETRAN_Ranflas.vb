Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_Ranflas

#Region " Variables "
   Private m_tipos_marca As String
   Private m_sucur_nombre As String
   Private m_vehrn_fecasignacion As Date
   Private m_vehrn_fecdesasignacion As Date
#End Region

#Region " Propiedades "
   Public Property TIPOS_Marca() As String
      Get
         Return m_tipos_marca
      End Get
      Set(ByVal value As String)
         m_tipos_marca = value
      End Set
   End Property

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

   Public Property VEHRN_FecAsignacion() As Date
      Get
         Return m_vehrn_fecasignacion
      End Get
      Set(ByVal value As Date)
         If Not IsNothing(m_vehrn_fecasignacion) Then
            If Not m_vehrn_fecasignacion.Equals(value) Then
               m_vehrn_fecasignacion = value
            End If
         Else
            m_vehrn_fecasignacion = value
         End If
      End Set
   End Property
   Public Property VEHRN_FecDesasignacion() As Date
      Get
         Return m_vehrn_fecdesasignacion
      End Get
      Set(ByVal value As Date)
         If Not IsNothing(m_vehrn_fecdesasignacion) Then
            If Not m_vehrn_fecdesasignacion.Equals(value) Then
               m_vehrn_fecdesasignacion = value
            End If
         Else
            m_vehrn_fecdesasignacion = value
         End If
      End Set
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
