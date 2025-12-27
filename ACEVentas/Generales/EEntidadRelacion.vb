Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EEntidadRelacion

#Region " Variables "
   Private m_entid_razonsocial As String
   Private m_tipos_tiporelacion As String
#End Region

#Region " Propiedades "
   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_razonsocial) Then
            If Not m_entid_razonsocial.Equals(value) Then
               m_entid_razonsocial = value
            End If
         Else
            m_entid_razonsocial = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoRelacion() As String
      Get
         Return m_tipos_tiporelacion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tiporelacion) Then
            If Not m_tipos_tiporelacion.Equals(value) Then
               m_tipos_tiporelacion = value
            End If
         Else
            m_tipos_tiporelacion = value
         End If
      End Set
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
