Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EEntidadesPadrones

#Region " Campos "
   Private m_tipos_tipopadron As Decimal
#End Region

#Region" Constructores "
	
#End Region

#Region " Propiedades "

   Public Property TIPOS_TipoPadron() As Decimal
      Get
         Return m_tipos_tipopadron
      End Get
      Set(ByVal value As Decimal)
         m_tipos_tipopadron = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

