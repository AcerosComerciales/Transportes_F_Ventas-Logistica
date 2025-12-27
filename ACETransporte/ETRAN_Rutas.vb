Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_Rutas

#Region " Variables "
   Private m_ubigo_origen As String
   Private m_ubigo_destino As String
   Private m_sucur_nombre As String
#End Region

#Region " Propiedades "
   Public Property UBIGO_Origen() As String
      Get
         Return m_ubigo_origen
      End Get
      Set(ByVal value As String)
         m_ubigo_origen = value
      End Set
   End Property

   Public Property UBIGO_Destino() As String
      Get
         Return m_ubigo_destino
      End Get
      Set(ByVal value As String)
         m_ubigo_destino = value
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

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
