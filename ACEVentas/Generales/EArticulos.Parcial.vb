Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

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
     Private m_artic_fecCompra As date
	Private m_artic_feccrea As Date
	Private m_artic_usrmod As String
	Private m_artic_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean
    Private m_lprecid As Integer
    Private m_lote As Integer
    Private m_lotegeneral As Integer
    Private m_artic_codigodestino As String

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlArticulos
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
    Public Property ARTIC_CodigoDestino() As String
        Get
            Return m_artic_codigodestino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_artic_codigodestino) Then
                If Not m_artic_codigodestino.Equals(value) Then
                    m_artic_codigodestino = value
                    OnARTIC_CodigoDestinoChanged(m_artic_codigodestino, EventArgs.Empty)
                End If
            Else
                m_artic_codigodestino = value
                OnARTIC_CodigoDestinoChanged(m_artic_codigodestino, EventArgs.Empty)
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


        Public Property stock_lote() As Integer
        Get
            Return m_lote
        End Get
        Set(ByVal value As Integer)
            If Not IsNothing(m_lote) Then
                If Not m_lote.Equals(value) Then
                    m_lote = value
                    Onstock_loteChanged(m_lote, EventArgs.Empty)
                End If
            Else
                m_lote = value
                Onstock_loteChanged(m_lote, EventArgs.Empty)
            End If
        End Set
    End Property

      Public Property stock_loteGeneral() As Integer
        Get
            Return m_lotegeneral
        End Get
        Set(ByVal value As Integer)
            If Not IsNothing(m_lotegeneral) Then
                If Not m_lotegeneral.Equals(value) Then
                    m_lotegeneral = value
                    Onstock_loteGeneralChanged(m_lotegeneral, EventArgs.Empty)
                End If
            Else
                m_lotegeneral = value
                Onstock_loteGeneralChanged(m_lotegeneral, EventArgs.Empty)
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

     Public Property ARTIC_FecCompra() As Date
		Get
			return m_artic_fecCompra
		End Get
		Set(ByVal value As date)
			m_artic_fecCompra = value
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
    Public Event stock_loteChanged As EventHandler
    Public Event stock_lotegeneralChanged as EventHandler
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
    Public Event ARTIC_CodigoDestinoChanged As EventHandler

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

       Public Sub Onstock_loteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent stock_loteChanged(sender, e)
	End Sub
    
    Public Sub Onstock_loteGeneralChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent stock_lotegeneralChanged(sender, e)
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

    Public Sub OnARTIC_CodigoDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ARTIC_CodigoDestinoChanged(sender, e)
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

