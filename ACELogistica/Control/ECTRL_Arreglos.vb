Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECTRL_Arreglos

#Region " Campos "
   Private m_tipos_tipoarreglo As String
   Private m_usuariocreador As String

   Private m_listctrl_arreglosdetalle As List(Of ECTRL_ArreglosDetalle)
#End Region

#Region" Constructores "
	
#End Region

#Region " Propiedades "

   Public Property TIPOS_TipoArreglo() As String
      Get
         Return m_tipos_tipoarreglo
      End Get
      Set(ByVal value As String)
         m_tipos_tipoarreglo = value
      End Set
   End Property


   Public Property ListCTRL_ArreglosDetalle() As List(Of ECTRL_ArreglosDetalle)
      Get
         Return m_listctrl_arreglosdetalle
      End Get
      Set(ByVal value As List(Of ECTRL_ArreglosDetalle))
         m_listctrl_arreglosdetalle = value
      End Set
   End Property

   Public Property UsuarioCreador() As String
      Get
         Return m_usuariocreador
      End Get
      Set(ByVal value As String)
         m_usuariocreador = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

