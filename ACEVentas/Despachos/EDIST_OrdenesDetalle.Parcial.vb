Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDIST_OrdenesDetalle

#Region " Campos "
	
	Private m_orden_codigo As String
	Private m_ordet_item As Short
	Private m_ordet_itemdocumento As Short
	Private m_artic_codigo As String
	Private m_ordet_cantidad As Decimal
	Private m_ordet_faltante As Decimal
	Private m_ordet_stockdestino As Decimal
	Private m_ordet_usrcrea As String
	Private m_ordet_feccrea As Date
	Private m_ordet_usrmod As String
	Private m_ordet_fecmod As Date
	Private m_nuevo As Boolean
    Private m_subpeso As Decimal
	Private m_modificado As Boolean
	Private m_eliminado As Boolean
    Private m_kardex As Boolean
    Private m_ordet_cantidadentregada As Decimal
    Private m_ordet_fecalmacen As DateTime
    Private m_ordet_usuarioalmacen As String
    Private m_ordet_motivo As String
    ' Private m_ordet_estalmacen As String

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlDIST_OrdenesDetalle
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
	
	Public Property ORDEN_Codigo() As String
		Get
			return m_orden_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_orden_codigo) Then
				If Not m_orden_codigo.Equals(value) Then
					m_orden_codigo = value
					OnORDEN_CodigoChanged(m_orden_codigo, EventArgs.Empty)
				End If
			Else
				m_orden_codigo = value
				OnORDEN_CodigoChanged(m_orden_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

      Public Property kardex() As Boolean
		Get
			return m_kardex
		End Get
		Set(ByVal value As Boolean)
			If Not IsNothing(m_kardex) Then
				If Not m_kardex.Equals(value) Then
					m_kardex = value
					OnkardexChanged(m_kardex, EventArgs.Empty)
				End If
			Else
				m_kardex = value
				OnkardexChanged(m_kardex, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDET_Item() As Short
		Get
			return m_ordet_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_ordet_item) Then
				If Not m_ordet_item.Equals(value) Then
					m_ordet_item = value
					OnORDET_ItemChanged(m_ordet_item, EventArgs.Empty)
				End If
			Else
				m_ordet_item = value
				OnORDET_ItemChanged(m_ordet_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDET_ItemDocumento() As Short
		Get
			return m_ordet_itemdocumento
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_ordet_itemdocumento) Then
				If Not m_ordet_itemdocumento.Equals(value) Then
					m_ordet_itemdocumento = value
					OnORDET_ItemDocumentoChanged(m_ordet_itemdocumento, EventArgs.Empty)
				End If
			Else
				m_ordet_itemdocumento = value
				OnORDET_ItemDocumentoChanged(m_ordet_itemdocumento, EventArgs.Empty)
			End If
		End Set
	End Property

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

	Public Property ORDET_Cantidad() As Decimal
		Get
			return m_ordet_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordet_cantidad) Then
				If Not m_ordet_cantidad.Equals(value) Then
					m_ordet_cantidad = value
					OnORDET_CantidadChanged(m_ordet_cantidad, EventArgs.Empty)
				End If
			Else
				m_ordet_cantidad = value
				OnORDET_CantidadChanged(m_ordet_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDET_Faltante() As Decimal
		Get
			return m_ordet_faltante
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordet_faltante) Then
				If Not m_ordet_faltante.Equals(value) Then
					m_ordet_faltante = value
					OnORDET_FaltanteChanged(m_ordet_faltante, EventArgs.Empty)
				End If
			Else
				m_ordet_faltante = value
				OnORDET_FaltanteChanged(m_ordet_faltante, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDET_StockDestino() As Decimal
		Get
			return m_ordet_stockdestino
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordet_stockdestino) Then
				If Not m_ordet_stockdestino.Equals(value) Then
					m_ordet_stockdestino = value
					OnORDET_StockDestinoChanged(m_ordet_stockdestino, EventArgs.Empty)
				End If
			Else
				m_ordet_stockdestino = value
				OnORDET_StockDestinoChanged(m_ordet_stockdestino, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property ORDET_CantidadEntregada() As Decimal
        Get
            Return m_ordet_cantidadentregada
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_ordet_cantidadentregada) Then
                If Not m_ordet_cantidadentregada.Equals(value) Then
                    m_ordet_cantidadentregada = value
                    OnORDET_CantidadEntregadaChanged(m_ordet_cantidadentregada, EventArgs.Empty)
                End If
            Else
                m_ordet_cantidadentregada = value
                OnORDET_CantidadEntregadaChanged(m_ordet_cantidadentregada, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property ORDET_Motivo() As String
        Get
            Return m_ordet_motivo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_ordet_motivo) Then
                If Not m_ordet_motivo.Equals(value) Then
                    m_ordet_motivo = value
                    OnORDET_MotivoChanged(m_ordet_motivo, EventArgs.Empty)
                End If
            Else
                m_ordet_motivo = value
                OnORDET_MotivoChanged(m_ordet_motivo, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property ORDET_UsrCrea() As String
		Get
			return m_ordet_usrcrea
		End Get
		Set(ByVal value As String)
			m_ordet_usrcrea = value
		End Set
	End Property

	Public Property ORDET_FecCrea() As Date
		Get
			return m_ordet_feccrea
		End Get
		Set(ByVal value As Date)
			m_ordet_feccrea = value
		End Set
	End Property

	Public Property ORDET_UsrMod() As String
		Get
			return m_ordet_usrmod
		End Get
		Set(ByVal value As String)
			m_ordet_usrmod = value
		End Set
    End Property
    Public Property ORDET_UsuarioAlmacen() As String
        Get
            Return m_ordet_usuarioalmacen
        End Get
        Set(ByVal value As String)
            m_ordet_usuarioalmacen = value
        End Set
    End Property

	Public Property ORDET_FecMod() As Date
		Get
			return m_ordet_fecmod
		End Get
		Set(ByVal value As Date)
			m_ordet_fecmod = value
		End Set
    End Property
    Public Property ORDET_FecAlmacen() As Date
        Get
            Return m_ordet_fecalmacen
        End Get
        Set(ByVal value As Date)
            m_ordet_fecalmacen = value
        End Set
    End Property
    Public Property ORDET_subpeso() As Decimal
		Get
			return m_subpeso
		End Get
		Set(ByVal value As Decimal)
			m_subpeso = value
		End Set
    End Property

    'Public Property ORDET_EstAlmacen() As String
    '    Get
    '        Return m_ordet_estalmacen
    '    End Get
    '    Set(ByVal value As String)
    '        If Not IsNothing(m_ordet_estalmacen) Then
    '            If Not m_ordet_estalmacen.Equals(value) Then
    '                m_ordet_estalmacen = value
    '                OnORDET_EstAlmacenChanged(m_ordet_estalmacen, EventArgs.Empty)
    '            End If
    '        Else
    '            m_ordet_estalmacen = value
    '            OnORDET_EstAlmacenChanged(m_ordet_estalmacen, EventArgs.Empty)
    '        End If
    '    End Set
    'End Property

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
			Return "DIST_OrdenesDetalle"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Logistica"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event ORDEN_CodigoChanged As EventHandler
	Public Event ORDET_ItemChanged As EventHandler
	Public Event ORDET_ItemDocumentoChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event ORDET_CantidadChanged As EventHandler
    Public Event kardexChanged as EventHandler
	Public Event ORDET_FaltanteChanged As EventHandler
    Public Event ORDET_StockDestinoChanged As EventHandler
    ' Public Event ORDET_EstAlmacenChanged As EventHandler
    Public Event ORDET_CantidadEntregadaChanged As EventHandler
    Public Event ORDET_MotivoChanged As EventHandler


	Public Sub OnORDEN_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDEN_CodigoChanged(sender, e)
    End Sub
    Public Sub OnORDET_CantidadEntregadaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ORDET_CantidadEntregadaChanged(sender, e)
    End Sub

    'Public Sub OnORDET_EstAlmacenChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    ActualizarInstancia()
    '    RaiseEvent ORDET_EstAlmacenChanged(sender, e)
    'End Sub
    Public Sub OnORDET_MotivoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ORDET_MotivoChanged(sender, e)
    End Sub
	Public Sub OnORDET_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDET_ItemChanged(sender, e)
	End Sub

	Public Sub OnORDET_ItemDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDET_ItemDocumentoChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnORDET_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDET_CantidadChanged(sender, e)
	End Sub

	Public Sub OnORDET_FaltanteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDET_FaltanteChanged(sender, e)
    End Sub


	Public Sub OnORDET_StockDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDET_StockDestinoChanged(sender, e)
	End Sub
  Public Sub OnkardexChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent kardexChanged(sender, e)
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

