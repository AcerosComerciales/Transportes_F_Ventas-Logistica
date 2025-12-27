Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EBancos

#Region " Variables "

   Public Enum TBanco
      BancoNacion = 1
      BCP = 2
      Interbank = 3
      Scotiabank = 4
      MiBanco = 5
      BancoContinental = 6
      BancoAgrario = 7
      CajaMunicipalArequipa = 8
   End Enum

#End Region

#Region " Propiedades "

   Public ReadOnly Property Bancos(ByVal x_opcion As TBanco) As Short
      Get
         Return Convert.ToInt16(x_opcion)
      End Get
   End Property

   Public ReadOnly Property BancoNombre(ByVal x_opcion As TBanco) As Short
      Get
         Return Convert.ToInt16(x_opcion)
      End Get
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
