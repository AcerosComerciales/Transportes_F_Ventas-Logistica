Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports System.Xml
Imports ACFramework
Imports System.Text.RegularExpressions

Partial Public Class EArticulos

#Region " Variables "
   Private m_listPrecios As List(Of EPrecios)
   Private m_listPPrecios As List(Of EPPrecios)
   Private m_listVentPrecios As List(Of EVENT_ListaPreciosArticulos)
   Private m_tipos_unidadmedida As String
   Private m_tipos_unidadmedidacorta As String
   Private m_tipos_producto As String
   Private m_tipos_categoria As String
   Private m_color_descripcion As String
   Private m_linea_nombre As String
   Private m_linea As String
   Private m_sublinea As String
   Private m_tipos_tipomoneda As String
   Private m_tipos_tipomonedacorta As String

   Private m_preciosoles As Decimal
   Private m_preciodolares As Decimal
    Private m_preciologistica As Decimal
   Private m_preci_tipocambio As Decimal
   Private m_preci_precio As Decimal
   Private m_tipos_codtipomoneda As String
   ''Articulos Destinos
   Private m_listArtDestinos As List(Of EArticDestinos)
   ''Articulos de Stock
   'Private m_listStocks As List(Of EStocks)
   Private m_listlog_stocks As List(Of ACELogistica.ELOG_Stocks)

   Private m_stocklocal As Decimal
   Private m_preciopublico As Decimal
   Private m_precioxmayor As Decimal
   Private m_pesobobina as String


   Private m_epprecios As EPPrecios

   Public Enum TipoInicializacion
      Todos
      Articulos_Destino
      Stock
   End Enum

   Private m_ordenitem As Integer

#End Region

#Region " Propiedades "

   Public Property ListPPrecios() As List(Of EPPrecios)
      Get
         Return m_listPPrecios
      End Get
      Set(ByVal value As List(Of EPPrecios))
         m_listPPrecios = value
      End Set
   End Property

   Public Property ListPrecios() As List(Of EPrecios)
      Get
         Return m_listPrecios
      End Get
      Set(ByVal value As List(Of EPrecios))
         m_listPrecios = value
      End Set
   End Property

   Public Property ListVentPrecios() As List(Of EVENT_ListaPreciosArticulos)
      Get
         Return m_listVentPrecios
      End Get
      Set(ByVal value As List(Of EVENT_ListaPreciosArticulos))
         m_listVentPrecios = value
      End Set
   End Property

   Public Property TIPOS_UnidadMedida() As String
      Get
         Return m_tipos_unidadmedida
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_unidadmedida) Then
            If Not m_tipos_unidadmedida.Equals(value) Then
               m_tipos_unidadmedida = value
            End If
         Else
            m_tipos_unidadmedida = value
         End If
      End Set
   End Property

   Public Property TIPOS_UndMedCorta() As String
      Get
         Return m_tipos_unidadmedidacorta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_unidadmedidacorta) Then
            If Not m_tipos_unidadmedidacorta.Equals(value) Then
               m_tipos_unidadmedidacorta = value
            End If
         Else
            m_tipos_unidadmedidacorta = value
         End If
      End Set
   End Property

   Public Property TIPOS_Producto() As String
      Get
         Return m_tipos_producto
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_producto) Then
            If Not m_tipos_producto.Equals(value) Then
               m_tipos_producto = value
            End If
         Else
            m_tipos_producto = value
         End If
      End Set
   End Property

   Public Property TIPOS_Categoria() As String
      Get
         Return m_tipos_categoria
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_categoria) Then
            If Not m_tipos_categoria.Equals(value) Then
               m_tipos_categoria = value
            End If
         Else
            m_tipos_categoria = value
         End If
      End Set
   End Property

   Public Property COLOR_Descripcion() As String
      Get
         Return m_color_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_color_descripcion) Then
            If Not m_color_descripcion.Equals(value) Then
               m_color_descripcion = value
            End If
         Else
            m_color_descripcion = value
         End If
      End Set
   End Property

   Public Property LINEA_Nombre() As String
      Get
         Return m_linea_nombre
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_linea_nombre) Then
            If Not m_linea_nombre.Equals(value) Then
               m_linea_nombre = value
            End If
         Else
            m_linea_nombre = value
         End If
      End Set
   End Property

   Public Property Linea() As String
      Get
         Return m_linea
      End Get
      Set(ByVal value As String)
         m_linea = value
      End Set
   End Property

   Public Property SubLinea() As String
      Get
         Return m_sublinea
      End Get
      Set(ByVal value As String)
         m_sublinea = value
      End Set
   End Property

   Public Property ListArtDestinos() As List(Of EArticDestinos)
      Get
         Return m_listArtDestinos
      End Get
      Set(ByVal value As List(Of EArticDestinos))
         m_listArtDestinos = value
      End Set
   End Property

   Public Property ListLOG_Stocks() As List(Of ACELogistica.ELOG_Stocks)
      Get
         Return m_listlog_stocks
      End Get
      Set(ByVal value As List(Of ACELogistica.ELOG_Stocks))
         m_listlog_stocks = value
      End Set
   End Property


   'Public Property ListStock() As List(Of EStocks)
   '   Get
   '      Return m_listStocks
   '   End Get
   '   ''Probar EStock
   '   Set(ByVal value As List(Of EStocks))
   '      m_listStocks = value
   '   End Set
   'End Property

   Public Property TIPOS_TipoMoneda() As String
      Get
         Return m_tipos_tipomoneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipomoneda) Then
            If Not m_tipos_tipomoneda.Equals(value) Then
               m_tipos_tipomoneda = value
            End If
         Else
            m_tipos_tipomoneda = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoMonedaCorta() As String
      Get
         Return m_tipos_tipomonedacorta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipomonedacorta) Then
            If Not m_tipos_tipomonedacorta.Equals(value) Then
               m_tipos_tipomonedacorta = value
            End If
         Else
            m_tipos_tipomonedacorta = value
         End If
      End Set
   End Property

   Public ReadOnly Property Codigo() As String
      Get
         If IsNothing(m_artic_codigo) Then
            Return ""
         Else
            Return Regex.Replace(m_artic_codigo, "^(\d{2})(\d{2})(\d{3})$", "$1.$2.$3")
         End If
      End Get
   End Property

    Public Property precioLogistica() As Decimal
        Get
            Return m_preciologistica
        End Get
        Set(ByVal value As Decimal)
            m_preciologistica = value
        End Set
    End Property

   Public Property PrecioDolares() As Decimal
      Get
         Return m_preciodolares
      End Get
      Set(ByVal value As Decimal)
         m_preciodolares = value
      End Set
   End Property

   Public Property PrecioSoles() As Decimal
      Get
         Return m_preciosoles
      End Get
      Set(ByVal value As Decimal)
         m_preciosoles = value
      End Set
   End Property

   Public Property PRECI_TipoCambio() As Decimal
      Get
         Return m_preci_tipocambio
      End Get
      Set(ByVal value As Decimal)
         m_preci_tipocambio = value
      End Set
   End Property

   Public Property PRECI_Precio() As Decimal
      Get
         Return m_preci_precio
      End Get
      Set(ByVal value As Decimal)
         m_preci_precio = value
      End Set
   End Property

   Public Property TIPOS_CodTipoMoneda() As String
      Get
         Return m_tipos_codtipomoneda
      End Get
      Set(ByVal value As String)
         m_tipos_codtipomoneda = value
      End Set
   End Property

   Public Property StockLocal() As Decimal
      Get
         Return m_stocklocal
      End Get
      Set(ByVal value As Decimal)
         m_stocklocal = value
      End Set
   End Property
   
   Public Property PrecioPublico() As Decimal
      Get
         Return m_preciopublico
      End Get
      Set(ByVal value As Decimal)
         m_preciopublico = value
      End Set
   End Property

   Public Property PrecioXMayor() As Decimal
      Get
         Return m_precioxmayor
      End Get
      Set(ByVal value As Decimal)
         m_precioxmayor = value
      End Set
   End Property

   Public Property PPrecios() As EPPrecios
      Get
         Return m_epprecios
      End Get
      Set(ByVal value As EPPrecios)
         m_epprecios = value
      End Set
   End Property

   Public Property OrdenItem() As Integer
      Get
         Return m_ordenitem
      End Get
      Set(ByVal value As Integer)
         m_ordenitem = value
      End Set
   End Property

    Public ReadOnly Property Bobina() As Decimal
            
    get    
            dim dato as Decimal
            Dim count=0
            Dim pattern As String = "\/"
            Dim elements() As String
        If PEDID_Referencia="" Then
            elements = Regex.Split("", pattern)
        Else 
            elements = Regex.Split(PEDID_Referencia, pattern)
        End If
            
            For Each element In elements
                    count+=1
                    if (count=3)then
                       dato =element
                    End If
                Next
            Return dato
     End Get

    End Property



   Public  Property  PEDID_Referencia() As String
        Get
         Return m_pesobobina
      End Get
      Set(ByVal value As String)
         m_pesobobina = value
      End Set     
End Property


#End Region

#Region " Constructores "
   '
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
