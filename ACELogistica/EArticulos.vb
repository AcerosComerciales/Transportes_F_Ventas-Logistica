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
         Dim _obj As Object = ACELogistica.My.Resources.xmlArticDestinos
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




Partial Public Class EArticulos

#Region " Campos "
	
	Private m_artic_codigo As String
	Private m_linea_codigo As String
	Private m_tipos_codtipoproducto As String
	Private m_tipos_codcategoria As String
	Private m_tipos_codunidadmedida As String
	Private m_color_id As Integer
	Private m_artic_id As Long
	Private m_artic_peso As Decimal
	Private m_artic_detalle As String
	Private m_artic_descripcion As String
	Private m_artic_percepcion As Boolean
	Private m_artic_descontinuado As Boolean
	Private m_artic_localizacion As String
	Private m_artic_orden As Short
	Private m_artic_existenciamin As Short
	Private m_artic_existenciamax As Long
	Private m_artic_puntoreorden As Short
	Private m_artic_estado As String
	Private m_artic_codigoanterior As String
	Private m_artic_numero As Short
	Private m_artic_usrcrea As String
	Private m_artic_feccrea As Date
	Private m_artic_usrmod As String
	Private m_artic_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean
    Private m_lprecid As Integer

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlArticulos
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

#Region" Propiedades "
	
	Public Property ARTIC_Codigo() As String
		Get
			return m_artic_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_codigo) Then
				If Not m_artic_codigo.Equals(value) Then
					m_artic_codigo = value
					OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
				End If
			Else
				m_artic_codigo = value
				OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property LINEA_Codigo() As String
		Get
			return m_linea_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_linea_codigo) Then
				If Not m_linea_codigo.Equals(value) Then
					m_linea_codigo = value
					OnLINEA_CodigoChanged(m_linea_codigo, EventArgs.Empty)
				End If
			Else
				m_linea_codigo = value
				OnLINEA_CodigoChanged(m_linea_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoProducto() As String
		Get
			return m_tipos_codtipoproducto
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipoproducto) Then
				If Not m_tipos_codtipoproducto.Equals(value) Then
					m_tipos_codtipoproducto = value
					OnTIPOS_CodTipoProductoChanged(m_tipos_codtipoproducto, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipoproducto = value
				OnTIPOS_CodTipoProductoChanged(m_tipos_codtipoproducto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodCategoria() As String
		Get
			return m_tipos_codcategoria
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codcategoria) Then
				If Not m_tipos_codcategoria.Equals(value) Then
					m_tipos_codcategoria = value
					OnTIPOS_CodCategoriaChanged(m_tipos_codcategoria, EventArgs.Empty)
				End If
			Else
				m_tipos_codcategoria = value
				OnTIPOS_CodCategoriaChanged(m_tipos_codcategoria, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodUnidadMedida() As String
		Get
			return m_tipos_codunidadmedida
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codunidadmedida) Then
				If Not m_tipos_codunidadmedida.Equals(value) Then
					m_tipos_codunidadmedida = value
					OnTIPOS_CodUnidadMedidaChanged(m_tipos_codunidadmedida, EventArgs.Empty)
				End If
			Else
				m_tipos_codunidadmedida = value
				OnTIPOS_CodUnidadMedidaChanged(m_tipos_codunidadmedida, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COLOR_Id() As Integer
		Get
			return m_color_id
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_color_id) Then
				If Not m_color_id.Equals(value) Then
					m_color_id = value
					OnCOLOR_IdChanged(m_color_id, EventArgs.Empty)
				End If
			Else
				m_color_id = value
				OnCOLOR_IdChanged(m_color_id, EventArgs.Empty)
			End If
		End Set
	End Property


    Public Property PRECI_Id() As Integer
        Get
            Return m_lprecid
        End Get
        Set(ByVal value As Integer)
            If Not IsNothing(m_lprecid) Then
                If Not m_lprecid.Equals(value) Then
                    m_lprecid = value
                    OnCOLOR_IdChanged(m_lprecid, EventArgs.Empty)
                End If
            Else
                m_lprecid = value
                OnCOLOR_IdChanged(m_lprecid, EventArgs.Empty)
            End If
        End Set
    End Property


	Public Property ARTIC_Id() As Long
		Get
			return m_artic_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_artic_id) Then
				If Not m_artic_id.Equals(value) Then
					m_artic_id = value
					OnARTIC_IdChanged(m_artic_id, EventArgs.Empty)
				End If
			Else
				m_artic_id = value
				OnARTIC_IdChanged(m_artic_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Peso() As Decimal
		Get
			return m_artic_peso
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_artic_peso) Then
				If Not m_artic_peso.Equals(value) Then
					m_artic_peso = value
					OnARTIC_PesoChanged(m_artic_peso, EventArgs.Empty)
				End If
			Else
				m_artic_peso = value
				OnARTIC_PesoChanged(m_artic_peso, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Detalle() As String
		Get
			return m_artic_detalle
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_detalle) Then
				If Not m_artic_detalle.Equals(value) Then
					m_artic_detalle = value
					OnARTIC_DetalleChanged(m_artic_detalle, EventArgs.Empty)
				End If
			Else
				m_artic_detalle = value
				OnARTIC_DetalleChanged(m_artic_detalle, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Descripcion() As String
		Get
			return m_artic_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_descripcion) Then
				If Not m_artic_descripcion.Equals(value) Then
					m_artic_descripcion = value
					OnARTIC_DescripcionChanged(m_artic_descripcion, EventArgs.Empty)
				End If
			Else
				m_artic_descripcion = value
				OnARTIC_DescripcionChanged(m_artic_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Percepcion() As Boolean
		Get
			return m_artic_percepcion
		End Get
		Set(ByVal value As Boolean)
			If Not m_artic_percepcion.Equals(value) Then
				m_artic_percepcion = value
				OnARTIC_PercepcionChanged(m_artic_percepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Descontinuado() As Boolean
		Get
			return m_artic_descontinuado
		End Get
		Set(ByVal value As Boolean)
			If Not m_artic_descontinuado.Equals(value) Then
				m_artic_descontinuado = value
				OnARTIC_DescontinuadoChanged(m_artic_descontinuado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Localizacion() As String
		Get
			return m_artic_localizacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_localizacion) Then
				If Not m_artic_localizacion.Equals(value) Then
					m_artic_localizacion = value
					OnARTIC_LocalizacionChanged(m_artic_localizacion, EventArgs.Empty)
				End If
			Else
				m_artic_localizacion = value
				OnARTIC_LocalizacionChanged(m_artic_localizacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Orden() As Short
		Get
			return m_artic_orden
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_artic_orden) Then
				If Not m_artic_orden.Equals(value) Then
					m_artic_orden = value
					OnARTIC_OrdenChanged(m_artic_orden, EventArgs.Empty)
				End If
			Else
				m_artic_orden = value
				OnARTIC_OrdenChanged(m_artic_orden, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_ExistenciaMin() As Short
		Get
			return m_artic_existenciamin
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_artic_existenciamin) Then
				If Not m_artic_existenciamin.Equals(value) Then
					m_artic_existenciamin = value
					OnARTIC_ExistenciaMinChanged(m_artic_existenciamin, EventArgs.Empty)
				End If
			Else
				m_artic_existenciamin = value
				OnARTIC_ExistenciaMinChanged(m_artic_existenciamin, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_ExistenciaMax() As Long
		Get
			return m_artic_existenciamax
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_artic_existenciamax) Then
				If Not m_artic_existenciamax.Equals(value) Then
					m_artic_existenciamax = value
					OnARTIC_ExistenciaMaxChanged(m_artic_existenciamax, EventArgs.Empty)
				End If
			Else
				m_artic_existenciamax = value
				OnARTIC_ExistenciaMaxChanged(m_artic_existenciamax, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_PuntoReorden() As Short
		Get
			return m_artic_puntoreorden
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_artic_puntoreorden) Then
				If Not m_artic_puntoreorden.Equals(value) Then
					m_artic_puntoreorden = value
					OnARTIC_PuntoReordenChanged(m_artic_puntoreorden, EventArgs.Empty)
				End If
			Else
				m_artic_puntoreorden = value
				OnARTIC_PuntoReordenChanged(m_artic_puntoreorden, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Estado() As String
		Get
			return m_artic_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_estado) Then
				If Not m_artic_estado.Equals(value) Then
					m_artic_estado = value
					OnARTIC_EstadoChanged(m_artic_estado, EventArgs.Empty)
				End If
			Else
				m_artic_estado = value
				OnARTIC_EstadoChanged(m_artic_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_CodigoAnterior() As String
		Get
			return m_artic_codigoanterior
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_codigoanterior) Then
				If Not m_artic_codigoanterior.Equals(value) Then
					m_artic_codigoanterior = value
					OnARTIC_CodigoAnteriorChanged(m_artic_codigoanterior, EventArgs.Empty)
				End If
			Else
				m_artic_codigoanterior = value
				OnARTIC_CodigoAnteriorChanged(m_artic_codigoanterior, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Numero() As Short
		Get
			return m_artic_numero
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_artic_numero) Then
				If Not m_artic_numero.Equals(value) Then
					m_artic_numero = value
					OnARTIC_NumeroChanged(m_artic_numero, EventArgs.Empty)
				End If
			Else
				m_artic_numero = value
				OnARTIC_NumeroChanged(m_artic_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_UsrCrea() As String
		Get
			return m_artic_usrcrea
		End Get
		Set(ByVal value As String)
			m_artic_usrcrea = value
		End Set
	End Property

	Public Property ARTIC_FecCrea() As Date
		Get
			return m_artic_feccrea
		End Get
		Set(ByVal value As Date)
			m_artic_feccrea = value
		End Set
	End Property

	Public Property ARTIC_UsrMod() As String
		Get
			return m_artic_usrmod
		End Get
		Set(ByVal value As String)
			m_artic_usrmod = value
		End Set
	End Property

	Public Property ARTIC_FecMod() As Date
		Get
			return m_artic_fecmod
		End Get
		Set(ByVal value As Date)
			m_artic_fecmod = value
		End Set
	End Property

	#Region " Propiedades de Solo Lectura "

	Public ReadOnly Property Nuevo() As Boolean
		Get
			return m_nuevo
		End Get
	End Property

	Public ReadOnly Property Modificado() As Boolean
		Get
			return m_modificado
		End Get
	End Property

	Public ReadOnly Property Eliminado() As Boolean
		Get
			return m_eliminado
		End Get
	End Property

	Public ReadOnly Property Hash() As Hashtable
		Get
			return m_hash
		End Get
	End Property

	Public Shared ReadOnly Property Tabla() As String
		Get
			Return "Articulos"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event LINEA_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoProductoChanged As EventHandler
	Public Event TIPOS_CodCategoriaChanged As EventHandler
	Public Event TIPOS_CodUnidadMedidaChanged As EventHandler
	Public Event COLOR_IdChanged As EventHandler
	Public Event ARTIC_IdChanged As EventHandler
	Public Event ARTIC_PesoChanged As EventHandler
	Public Event ARTIC_DetalleChanged As EventHandler
	Public Event ARTIC_DescripcionChanged As EventHandler
	Public Event ARTIC_PercepcionChanged As EventHandler
	Public Event ARTIC_DescontinuadoChanged As EventHandler
	Public Event ARTIC_LocalizacionChanged As EventHandler
	Public Event ARTIC_OrdenChanged As EventHandler
	Public Event ARTIC_ExistenciaMinChanged As EventHandler
	Public Event ARTIC_ExistenciaMaxChanged As EventHandler
	Public Event ARTIC_PuntoReordenChanged As EventHandler
	Public Event ARTIC_EstadoChanged As EventHandler
	Public Event ARTIC_CodigoAnteriorChanged As EventHandler
	Public Event ARTIC_NumeroChanged As EventHandler

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnLINEA_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent LINEA_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoProductoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoProductoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodCategoriaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodCategoriaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodUnidadMedidaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodUnidadMedidaChanged(sender, e)
	End Sub

	Public Sub OnCOLOR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COLOR_IdChanged(sender, e)
	End Sub

	Public Sub OnARTIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_IdChanged(sender, e)
	End Sub

	Public Sub OnARTIC_PesoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_PesoChanged(sender, e)
	End Sub

	Public Sub OnARTIC_DetalleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_DetalleChanged(sender, e)
	End Sub

	Public Sub OnARTIC_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnARTIC_PercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_PercepcionChanged(sender, e)
	End Sub

	Public Sub OnARTIC_DescontinuadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_DescontinuadoChanged(sender, e)
	End Sub

	Public Sub OnARTIC_LocalizacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_LocalizacionChanged(sender, e)
	End Sub

	Public Sub OnARTIC_OrdenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_OrdenChanged(sender, e)
	End Sub

	Public Sub OnARTIC_ExistenciaMinChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_ExistenciaMinChanged(sender, e)
	End Sub

	Public Sub OnARTIC_ExistenciaMaxChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_ExistenciaMaxChanged(sender, e)
	End Sub

	Public Sub OnARTIC_PuntoReordenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_PuntoReordenChanged(sender, e)
	End Sub

	Public Sub OnARTIC_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_EstadoChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoAnteriorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoAnteriorChanged(sender, e)
	End Sub

	Public Sub OnARTIC_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_NumeroChanged(sender, e)
	End Sub


#End Region

#Region " Metodos "
	
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

	Public Sub ActualizarInstancia()
		If Not Nuevo Then
			If Not Eliminado Then
				Instanciar(ACEInstancia.Modificado)
			End If
		End If
	End Sub

#End Region

End Class
