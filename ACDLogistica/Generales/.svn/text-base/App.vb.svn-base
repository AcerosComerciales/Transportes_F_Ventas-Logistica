Imports System.Xml

Public Class App

#Region " Variables "
   Private Shared m_mutex As New System.Threading.Mutex
   Private Shared m_instance As App = Nothing

   Private Shared m_hash As Hashtable
   Private Shared m_hashReporte As Hashtable
#End Region

#Region " Propiedades "
   Public Shared ReadOnly Property Hash() As Hashtable
      Get
         Return m_hash
      End Get
   End Property

   Public Shared ReadOnly Property HashReportes() As Hashtable
      Get
         Return m_hashReporte
      End Get
   End Property
#End Region

#Region " Constructores "

   Private Sub New()

   End Sub

   Public Shared Function Inicializar(Optional ByVal Forzar As Boolean = False) As App
      m_mutex.WaitOne()
      Try
         If m_instance Is Nothing Or Forzar Then
            m_instance = New App()
         End If
         '' Implementaciones aqui
         Dim _obj As Object = ACDLogistica.My.Resources.sql
         Dim _xml As New XmlDocument
         _xml.LoadXml(_obj)
         If IsNothing(m_hash) Then
            m_hash = New Hashtable()
            Dim cPlantilla As XmlNodeList = _xml.GetElementsByTagName("xml")
            Dim cCampos As XmlNodeList = CType(cPlantilla(0), XmlElement).GetElementsByTagName("sql")
            For Each Item As XmlElement In cCampos
               Dim titulo As XmlNodeList = Item.GetElementsByTagName("titulo")
               Dim code As XmlNodeList = Item.GetElementsByTagName("code")
               m_hash.Add(titulo(0).InnerText.ToString(), code(0).InnerText.ToString())
            Next
         End If
         ''
         Dim _objRep As Object = ACDLogistica.My.Resources.reportes
         Dim _xmlRep As New XmlDocument
         _xmlRep.LoadXml(_objRep)
         If IsNothing(m_hashReporte) Then
            m_hashReporte = New Hashtable()
            Dim cPlantilla As XmlNodeList = _xmlRep.GetElementsByTagName("xml")
            Dim cCampos As XmlNodeList = CType(cPlantilla(0), XmlElement).GetElementsByTagName("sql")
            For Each Item As XmlElement In cCampos
               Dim titulo As XmlNodeList = Item.GetElementsByTagName("titulo")
               Dim code As XmlNodeList = Item.GetElementsByTagName("code")
               m_hash.Add(titulo(0).InnerText.ToString(), code(0).InnerText.ToString())
            Next
         End If
      Catch ex As Exception
         Return Nothing
      Finally
         m_mutex.ReleaseMutex()
      End Try
      Return m_instance
   End Function
#End Region

#Region " Metodos "

#End Region

#Region " Metodos de Controles"

#End Region

End Class
