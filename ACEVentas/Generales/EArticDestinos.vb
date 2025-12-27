Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml

Imports ACFramework

Partial Public Class EArticDestinos

#Region " Variables "
   ' ''Articulos Destinos
   Private m_listArtDestinos As List(Of EArticDestinos)
   Private m_artic_descripcion As String

   Public Enum TipoInicializacion
      Todos
      Articulos_Destino
   End Enum



#End Region

#Region " Propiedades "
   Public Property ListArticDestinos() As List(Of EArticDestinos)
      Get
         Return m_listArtDestinos
      End Get
      Set(ByVal value As List(Of EArticDestinos))
         m_listArtDestinos = value
      End Set
   End Property

   Public Property ARTIC_Descripcion() As String
      Get
         Return m_artic_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_artic_descripcion) Then
            If Not m_artic_descripcion.Equals(value) Then
               m_artic_descripcion = value
            End If
         Else
            m_artic_descripcion = value
         End If
      End Set
   End Property


#End Region

#Region " Constructores "
   Public Sub New(ByVal x_tipo As TipoInicializacion)
      Select Case x_tipo
         Case TipoInicializacion.Articulos_Destino
            m_listArtDestinos = New List(Of EArticDestinos)

         Case 2

         Case Else

      End Select
      Try
         Dim _obj As Object = ACEVentas.My.Resources.xmlArticDestinos
         Dim _xml As New XmlDocument
         _xml.LoadXml(_obj)
         If IsNothing(m_hash) Then
            m_hash = New Hashtable()
            Dim cPlantilla As XmlNodeList = _xml.GetElementsByTagName("Tabla")
            Dim cCampos As XmlNodeList = CType(cPlantilla(0), XmlElement).GetElementsByTagName("Campos")
            Dim Campo As XmlNodeList = CType(cCampos(0), XmlElement).GetElementsByTagName("CCampo")
            For Each Item As XmlElement In Campo
               m_hash.Add(Item.InnerText.ToString(), New CCampo(Item.GetAttribute("xmlns"), IIf(Item.GetAttribute("Identity") = "1", True, False), IIf(Item.GetAttribute("ForeignKey") = "1", True, False), IIf(Item.GetAttribute("PrimaryKey") = "1", True, False)))
            Next
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos "

#End Region

End Class
