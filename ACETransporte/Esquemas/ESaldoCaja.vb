Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ESaldoCaja

#Region " Variables "
   Private m_saldo As Decimal
#End Region

#Region " Propiedades "
   Public Property Saldo() As Decimal
      Get
         Return m_saldo
      End Get
      Set(ByVal value As Decimal)
         m_saldo = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
