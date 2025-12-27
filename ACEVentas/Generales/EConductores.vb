Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EConductores

#Region " Variables "
   Private m_transportista As EEntidadRelacion
#End Region

#Region " Propiedades "
   Public Property Transportista() As EEntidadRelacion
      Get
         Return m_transportista
      End Get
      Set(ByVal value As EEntidadRelacion)
         m_transportista = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
