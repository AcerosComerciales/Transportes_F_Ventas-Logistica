Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports ACEVentas.EUtilitarios
Imports System.Xml

Imports ACFramework

Partial Public Class EEntidades

#Region " Variables "
   Private m_listContactos As List(Of EEntidades)
   Private m_tipos_documento As String
   Private m_prove_contacto As String

   Private m_listDirecciones As List(Of EDirecciones)
   Private m_listTelefonos As List(Of ETelefonos)
   Private m_listEntidadesTipos As List(Of EEntidadesRoles)

   Private m_ecliente As EClientes
   Private m_eproveedor As EProveedores
   Private m_econductor As EConductores
   Private m_ubigo_descripcion As String
   Private m_tiposdocumentocorto As String

   Private m_direccion As String
   Private m_nrodocumentos As Integer

   Public Enum TipoEntidad
      Todos = 0
      Usuarios = 1
      Clientes = 2
      Proveedores = 3
      Trabajadores = 4
      Conductores = 5
      Contactos = 6
      Vendedores = 7
      EnBlanco = 8
      Transportista = 9
      ProveedoresLogistica = 10
      Basico = 100
   End Enum

   Public Enum TipoInicializacion
      Todos
      Direcciones
      Telefonos
      Dir_Tel
      EntTipos_Dir_Tel
      Cliente
      Proveedor
      Conductor
      Transportista
   End Enum

#End Region

#Region " Propiedades "

   Public Property UBIGO_Descripcion() As String
      Get
         Return m_ubigo_descripcion
      End Get
      Set(ByVal value As String)
         m_ubigo_descripcion = value
      End Set
   End Property

   Public Property ListContactos() As List(Of EEntidades)
      Get
         Return m_listContactos
      End Get
      Set(ByVal value As List(Of EEntidades))
         m_listContactos = value
      End Set
   End Property

   Public Property ListDirecciones() As List(Of EDirecciones)
      Get
         Return m_listDirecciones
      End Get
      Set(ByVal value As List(Of EDirecciones))
         m_listDirecciones = value
      End Set
   End Property

   Public Property ListTelefonos() As List(Of ETelefonos)
      Get
         Return m_listTelefonos
      End Get
      Set(ByVal value As List(Of ETelefonos))
         m_listTelefonos = value
      End Set
   End Property

   Public Property ListEntidadesTipos() As List(Of EEntidadesRoles)
      Get
         Return m_listEntidadesTipos
      End Get
      Set(ByVal value As List(Of EEntidadesRoles))
         m_listEntidadesTipos = value
      End Set
   End Property

   Public Property TIPOS_Documento() As String
      Get
         Return m_tipos_documento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_documento) Then
            If Not m_tipos_documento.Equals(value) Then
               m_tipos_documento = value
            End If
         Else
            m_tipos_documento = value
         End If
      End Set
   End Property

   Public Property PROVE_Contacto() As String
      Get
         Return m_prove_contacto
      End Get
      Set(ByVal value As String)
         m_prove_contacto = value
      End Set
   End Property

   Public Property TIPOS_DocumentoCorto() As String
      Get
         Return m_tiposdocumentocorto
      End Get
      Set(ByVal value As String)
         m_tiposdocumentocorto = value
      End Set
   End Property

   Public ReadOnly Property Documento() As String
      Get
         Return String.Format("{0} - {1}", m_tiposdocumentocorto, m_entid_nrodocumento)
      End Get
   End Property

   Public Property Cliente() As EClientes
      Get
         Return m_ecliente
      End Get
      Set(ByVal value As EClientes)
         m_ecliente = value
      End Set
   End Property

   Public Property Proveedor() As EProveedores
      Get
         Return m_eproveedor
      End Get
      Set(ByVal value As EProveedores)
         m_eproveedor = value
      End Set
   End Property

   Public Property Conductor() As EConductores
      Get
         Return m_econductor
      End Get
      Set(ByVal value As EConductores)
         m_econductor = value
      End Set
   End Property

   Public Property Direccion() As String
      Get
         Return m_direccion
      End Get
      Set(ByVal value As String)
         m_direccion = value
      End Set
   End Property

   Public Property NroDocumentos() As Integer
      Get
         Return m_nrodocumentos
      End Get
      Set(ByVal value As Integer)
         m_nrodocumentos = value
      End Set
   End Property


#End Region

#Region " Constructores "
   Public Sub New(ByVal x_tipo As TipoInicializacion)
      Select Case x_tipo
         Case TipoInicializacion.EntTipos_Dir_Tel
            m_listEntidadesTipos = New List(Of EEntidadesRoles)
            m_listDirecciones = New List(Of EDirecciones)
            m_listTelefonos = New List(Of ETelefonos)
         Case 2

         Case Else

      End Select
      Try
         Dim _obj As Object = ACEVentas.My.Resources.xmlEntidades
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
