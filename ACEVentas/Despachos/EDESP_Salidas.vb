Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDESP_Salidas

#Region " Campos "
   Private m_csalida As String
   Private m_listEGuia_Remision As List(Of EDIST_GuiasRemision)

   Private m_placa As String
   Private m_conductor As String
   Private m_vehiculo As String
   Private m_certificado As String

   Private m_guiar_codigo As String
   Private m_guisa_numero As Integer
#End Region

#Region" Constructores "
   Public Sub New(ByVal x_vehic_id As Long, ByVal x_entid_codigoconductor As String)
      Me.New()
      m_vehic_id = x_vehic_id
      m_entid_codigoconductor = x_entid_codigoconductor
   End Sub
#End Region

#Region " Propiedades "
   Public Property CSalida() As String
      Get
         Return m_csalida
      End Get
      Set(ByVal value As String)
         m_csalida = value
      End Set
   End Property

   Public Property ListGuia_Remision() As List(Of EDIST_GuiasRemision)
      Get
         Return m_listEGuia_Remision
      End Get
      Set(ByVal value As List(Of EDIST_GuiasRemision))
         m_listEGuia_Remision = value
      End Set
   End Property

   Public Property Certificado() As String
      Get
         Return m_certificado
      End Get
      Set(ByVal value As String)
         m_certificado = value
      End Set
   End Property


   Public Property Vehiculo() As String
      Get
         Return m_vehiculo
      End Get
      Set(ByVal value As String)
         m_vehiculo = value
      End Set
   End Property


   Public Property Conductor() As String
      Get
         Return m_conductor
      End Get
      Set(ByVal value As String)
         m_conductor = value
      End Set
   End Property

   Public Property Placa() As String
      Get
         Return m_placa
      End Get
      Set(ByVal value As String)
         m_placa = value
      End Set
   End Property

   Public Property GUIAR_Codigo() As String
      Get
         Return m_guiar_codigo
      End Get
      Set(ByVal value As String)
         m_guiar_codigo = value
      End Set
   End Property

   Public Property GUISA_Numero() As Integer
      Get
         Return m_guisa_numero
      End Get
      Set(ByVal value As Integer)
         m_guisa_numero = value
      End Set
   End Property
#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

