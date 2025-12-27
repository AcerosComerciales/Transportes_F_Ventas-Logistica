Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework


Partial Public Class EABAS_Costeos

#Region " Variables "
   Private m_artic_descripcion As String
   Private m_entid_razonsocial As String
#End Region

#Region " Propiedades "
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

   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_razonsocial) Then
            If Not m_entid_razonsocial.Equals(value) Then
               m_entid_razonsocial = value
            End If
         Else
            m_entid_razonsocial = value
         End If
      End Set
   End Property
#End Region

#Region " Constructores "
   Public Sub New(ByVal x_artic_codigo As String, ByVal x_entid_codigo As String, ByVal x_doccd_item As Short, ByVal x_tipos_tipocosteo As String)
      m_artic_codigo = x_artic_codigo
      m_entid_codigoproveedor = x_entid_codigo
      m_doccd_item = x_doccd_item
      m_tipos_codtipocosteo = x_tipos_tipocosteo

      Try
         Dim _obj As Object = ACELogistica.My.Resources.xmlABAS_Costeos
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

   Public Sub New(ByVal x_artic_codigo As String, ByVal x_entid_codigo As String, ByVal x_doccd_item As Short, ByVal x_tipos_tipocosteo As String, ByVal x_importe As Double)
      m_artic_codigo = x_artic_codigo
      m_entid_codigoproveedor = x_entid_codigo
      m_doccd_item = x_doccd_item
      m_tipos_codtipocosteo = x_tipos_tipocosteo
      m_coste_importe = x_importe

      Try
         Dim _obj As Object = ACELogistica.My.Resources.xmlABAS_Costeos
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

   Public Sub New(ByVal x_artic_codigo As String, ByVal x_entid_codigo As String, ByVal x_doccd_item As Short _
                  , ByVal x_tipos_tipocosteo As String, ByVal x_importe As Double, ByVal x_documento As String, ByVal x_proveedor As String)
      m_artic_codigo = x_artic_codigo
      m_entid_codigoproveedor = x_entid_codigo
      m_doccd_item = x_doccd_item
      m_tipos_codtipocosteo = x_tipos_tipocosteo
      m_coste_importe = x_importe
      m_coste_codigodocumento = x_documento
      m_coste_codigoproveedor = x_proveedor

      Try
         Dim _obj As Object = ACELogistica.My.Resources.xmlABAS_Costeos
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
