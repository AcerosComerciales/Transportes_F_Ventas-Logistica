Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EABAS_ListaPreciosCompra

#Region " Variables "
   Private m_precio As Double

#End Region

#Region " Propiedades "

   Public ReadOnly Property Precio() As Double
      Get
         Return (m_lprco_precio * (1 - m_lprco_porcentaje / 100))
      End Get
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
