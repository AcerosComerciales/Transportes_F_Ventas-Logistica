Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_CajaChicaPagos

#Region " Campos "
   Private m_teso_documentos As ETESO_Documentos
   Private m_entid_razonsocial As String
   Private m_documento As String
#End Region

#Region" Constructores "
	
#End Region

#Region" Propiedades "

   Public Property TESO_Documentos() As ETESO_Documentos
      Get
         Return m_teso_documentos
      End Get
      Set(ByVal value As ETESO_Documentos)
         m_teso_documentos = value
      End Set
   End Property

   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         m_entid_razonsocial = value
      End Set
   End Property

   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

