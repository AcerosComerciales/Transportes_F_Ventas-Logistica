Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports ACFramework
Imports System.Xml


Partial Public Class ETipoCambio

#Region " Variables "
   Private m_fecha As DateTime
#End Region

#Region " Propiedades "

   Public Property Fecha() As DateTime
      Get
         Return m_fecha
      End Get
      Set(ByVal value As DateTime)
         m_fecha = value
      End Set
   End Property
#End Region

#Region " Constructores "
   Public Sub New(ByVal x_fecha As DateTime, ByVal x_instancia As ACEInstancia)
      m_fecha = x_fecha
      m_tipoc_fecha = x_fecha.ToString("yyyyMMdd")
      m_tipoc_fechac = x_fecha
      m_tipoc_compraoficina = 0.0
      m_tipoc_ventaoficina = 0
      Instanciar(x_instancia)
      Try
         Dim _obj As Object = ACEVentas.My.Resources.xmlTipoCambio
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
