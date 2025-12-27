Imports System.Xml
Imports System.Text
Imports System.Globalization
Imports ACFramework
Imports System.IO
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports C1.Win.C1FlexGrid

Public Class Utilitarios
#Region " Guardar Configuracion "
   Private Shared m_cconfig As Hashtable
   Private Shared m_cconfiguracion As ACFramework.CConfig
   Private Shared m_listCConfig As New List(Of ACFramework.CConfig)

   Public Shared Property cConfig() As Hashtable
      Get
         Return m_cconfig
      End Get
      Set(ByVal value As Hashtable)
         m_cconfig = value
      End Set
   End Property

   Public Shared Property cConfiguracion() As ACFramework.CConfig
      Get
         Return m_cconfiguracion
      End Get
      Set(ByVal value As ACFramework.CConfig)
         m_cconfiguracion = value
      End Set
   End Property


   Public Shared Sub saveXML()
      Try
         Dim pathName As String = Path.Combine(Application.StartupPath, "cConfig.xml")
         m_cconfiguracion.Empresa = IIf(CType(m_cconfig("empresa"), PXML).Valor = "", GApp.Empresa, CType(m_cconfig("empresa"), PXML).Valor)
         m_cconfiguracion.Zona = CType(m_cconfig("zona"), PXML).Valor
         m_cconfiguracion.Sucursal = CType(m_cconfig("sucursal"), PXML).Valor
         m_cconfiguracion.Puntoventa = CType(m_cconfig("puntoventa"), PXML).Valor
         m_cconfiguracion.PathFondo = CType(m_cconfig("pathfondo"), PXML).Valor
         m_cconfiguracion.FondoLayout = ACFramework.CConfig.getLayout(CType(m_cconfig("layout"), PXML).Valor)
         m_cconfiguracion.HConfig = m_cconfig
         Dim _noexiste As Boolean = True
         For Each item As ACFramework.CConfig In m_listCConfig
            If item.Empresa.Equals(m_cconfiguracion.Empresa) Then
               _noexiste = False
            End If
         Next
         If _noexiste Then
            m_listCConfig.Add(m_cconfiguracion)
         End If
         ACFramework.CConfig.saveXML(pathName, m_listCConfig)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Shared Sub getFileConfigBase()
      Try
         m_cconfiguracion = New ACFramework.CConfig()
         cConfig = ACFramework.CConfig.getFileConfigBase(Application.StartupPath, "cConfig.xml", m_cconfiguracion, m_listCConfig, GApp.Empresa)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region


#Region "Metodos para Grillas "
   Public Shared Sub ExportarXLS(ByRef _c1grd As C1FlexGrid, ByVal x_titulo As String)
      Try
         Dim archivo As String, proceso As Process = New Process
         Dim sfdArchivo As New SaveFileDialog()
         sfdArchivo.DefaultExt = ".xls"
         sfdArchivo.Filter = "*.xls|"
         If sfdArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
            archivo = sfdArchivo.FileName
            _c1grd.SaveExcel(archivo, x_titulo, FileFlags.IncludeFixedCells + FileFlags.IncludeMergedRanges)
            Process.Start(archivo)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region
End Class

Public Class Presupuesto
#Region " Variables "
   Private m_orden As Integer
   Private m_descripcion As String
   Private m_monto As Decimal
#End Region

#Region " Propiedades "

   Public Property Orden() As Integer
      Get
         Return m_orden
      End Get
      Set(ByVal value As Integer)
         m_orden = value
      End Set
   End Property

   Public Property Descripcion() As String
      Get
         Return m_descripcion
      End Get
      Set(ByVal value As String)
         m_descripcion = value
      End Set
   End Property

   Public Property Monto() As Decimal
      Get
         Return m_monto
      End Get
      Set(ByVal value As Decimal)
         m_monto = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New()

   End Sub

   Public Sub New(ByVal x_orden As Integer, ByVal x_descripcion As String, ByVal x_monto As Decimal)
      Me.m_orden = x_orden
      Me.m_descripcion = x_descripcion
      Me.m_monto = x_monto
   End Sub

   Public Sub New(ByVal x_descripcion As String, ByVal x_monto As Decimal)
      Me.m_orden = 0
      Me.m_descripcion = x_descripcion
      Me.m_monto = x_monto
   End Sub
#End Region

#Region " Metodos "

#End Region

#Region " Metodos de Controles"

#End Region
End Class

