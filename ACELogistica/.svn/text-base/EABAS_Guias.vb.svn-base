Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports ACFramework

Partial Public Class EABAS_Guias
#Region "Variables"
   Private m_documento As String
   Private m_docve_fechadocumento As DateTime
   Private m_entid_codigocliente As String
   Private m_docve_descripcioncliente As String
   Private m_entid_codigo As String

#End Region

#Region "Campos"
   Private m_nuevo As Boolean
   Private m_modificado As Boolean
   Private m_eliminado As Boolean
#End Region

#Region "Propiedades"
   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
      End Set
   End Property

   Public Property DOCVE_FechaDocumento() As DateTime
      Get
         Return m_docve_fechadocumento
      End Get
      Set(ByVal value As DateTime)
         m_docve_fechadocumento = value
      End Set
   End Property

   Public Property ENTID_CodigoCliente() As String
      Get
         Return m_entid_codigocliente
      End Get
      Set(ByVal value As String)
         m_entid_codigocliente = value
      End Set
   End Property

   Public Property DOCVE_DescripcionCliente() As String
      Get
         Return m_docve_descripcioncliente
      End Get
      Set(ByVal value As String)
         m_docve_descripcioncliente = value
      End Set
   End Property

   Public Property ENTID_Codigo() As String
      Get
         Return m_entid_codigo
      End Get
      Set(ByVal value As String)
         m_entid_codigo = value
      End Set
   End Property


#End Region

#Region "Constructores"

#End Region

#Region "Metodos"
   Public Sub Instanciar(ByVal x_instancia As ACEInstancia)
      Select Case x_instancia
         Case ACEInstancia.Consulta
            m_nuevo = False
            m_modificado = False
            m_eliminado = False
         Case ACEInstancia.Nuevo
            m_nuevo = True
            m_modificado = False
            m_eliminado = False
         Case ACEInstancia.Modificado
            m_nuevo = False
            m_modificado = True
            m_eliminado = False
         Case ACEInstancia.Eliminado
            m_nuevo = False
            m_modificado = False
            m_eliminado = True
      End Select
   End Sub
#End Region

End Class
