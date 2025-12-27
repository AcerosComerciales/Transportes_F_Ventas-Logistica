Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_Recibos

#Region " Campos "
    Private m_codigo As String
    Private m_documento As String
    Private m_tipos_tiporecibo As String
    Private m_tipos_tipomoneda As String
    Private m_teso_documentos As ETESO_Documentos

    Private m_documentodoc As String
    Private m_entid_razonsocialproveedor As String
    Private m_saldopendiente As Decimal '_M
#End Region

#Region" Constructores "
	
#End Region

#Region" Propiedades "
    Public Property Codigo() As String
        Get
            Return m_codigo
        End Get
        Set(ByVal value As String)
            m_codigo = value
        End Set
    End Property
    Public Property TIPOS_TipoRecibo() As String
        Get
            Return m_tipos_tiporecibo
        End Get
        Set(ByVal value As String)
            m_tipos_tiporecibo = value
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


   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
      End Set
   End Property

   Public Property TESO_Documentos() As ETESO_Documentos
      Get
         Return m_teso_documentos
      End Get
      Set(ByVal value As ETESO_Documentos)
         m_teso_documentos = value
      End Set
   End Property

   Public Property DocumentoDoc() As String
      Get
         Return m_documentodoc
      End Get
      Set(ByVal value As String)
         m_documentodoc = value
      End Set
   End Property

   Public Property ENTID_RazonSocialProveedor() As String
      Get
         Return m_entid_razonsocialproveedor
      End Get
      Set(ByVal value As String)
         m_entid_razonsocialproveedor = value
      End Set
    End Property
    '_M
    Public Property SaldoPendiente() As Decimal
        Get
            Return m_saldopendiente
        End Get
        Set(ByVal value As Decimal)
            m_saldopendiente = value
        End Set
    End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

