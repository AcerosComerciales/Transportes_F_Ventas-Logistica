Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_Documentos

#Region " Campos "
   Private m_listteso_documentosdetalle As List(Of ETESO_DocumentosDetalle)
#End Region

#Region" Constructores "
	
#End Region

#Region" Propiedades "

   Public Property ListTESO_DocumentosDetalle() As List(Of ETESO_DocumentosDetalle)
      Get
         Return m_listteso_documentosdetalle
      End Get
      Set(ByVal value As List(Of ETESO_DocumentosDetalle))
         m_listteso_documentosdetalle = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

