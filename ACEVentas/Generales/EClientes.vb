Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EClientes


#Region " Variables "
   Private m_percepcion As Double
   Private m_lprec_descripcion As String
#End Region

#Region " Propiedades "
   Public Property Percepcion() As Double
      Get
         Return m_percepcion
      End Get
      Set(ByVal value As Double)
         m_percepcion = value
      End Set
   End Property

   Public Property LPREC_Descripcion() As String
      Get
         Return m_lprec_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_lprec_descripcion) Then
            If Not m_lprec_descripcion.Equals(value) Then
               m_lprec_descripcion = value
            End If
         Else
            m_lprec_descripcion = value
         End If
      End Set
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
