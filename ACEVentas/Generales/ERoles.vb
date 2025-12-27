Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ERoles
   Implements ICloneable

#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_roles_id As Long, ByVal x_roles_descripcion As String)
      Try
         m_roles_descripcion = x_roles_descripcion
         m_roles_id = x_roles_id

         Dim _obj As Object = ACEVentas.My.Resources.xmlRoles
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
   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New ERoles()
         cloneInstance = CType(Me, ERoles)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
