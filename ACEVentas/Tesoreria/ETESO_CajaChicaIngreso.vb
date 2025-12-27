Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_CajaChicaIngreso

#Region " Campos "
   Private m_entid_razonsocial As String
    Private m_tipos_tipomoneda As String
    Private m_tipos_tipopendiente As String
   Private m_saldo As Decimal
#End Region

#Region" Constructores "
	
#End Region

#Region" Propiedades "

   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         m_entid_razonsocial = value
      End Set
   End Property

   Public Property TIPOS_TipoMoneda() As String
      Get
         Return m_tipos_tipomoneda
      End Get
      Set(ByVal value As String)
         m_tipos_tipomoneda = value
      End Set
    End Property
    Public Property TIPOS_TipoPendiente() As String
        Get
            Return m_tipos_tipopendiente
        End Get
        Set(ByVal value As String)
            m_tipos_tipopendiente = value
        End Set
    End Property

   Public Property Saldo() As Decimal
      Get
         Return m_saldo
      End Get
      Set(ByVal value As Decimal)
         m_saldo = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

