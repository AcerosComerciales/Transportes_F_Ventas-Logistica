Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EStocks

#Region " Campos "
	
	Private m_artic_codigo As String
	Private m_almac_id As Short
	Private m_perio_codigo As String
	Private m_stock_cantidad As Double
	Private m_stock_inicial As Double
	Private m_stock_minimo As Double
	Private m_stock_maximo As Double
	Private m_stock_activo As Boolean
	Private m_stock_reorden As Double
	Private m_stock_usrcrea As String
	Private m_stock_feccrea As Date
	Private m_stock_usrmod As String
	Private m_stock_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlStocks
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
	Public Property ALMAC_Id() As Short
		Get
			return m_almac_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_almac_id) Then
				If Not m_almac_id.Equals(value) Then
					m_almac_id = value
					OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
				End If
			Else
				m_almac_id = value
				OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PERIO_Codigo() As String
		Get
			return m_perio_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_perio_codigo) Then
				If Not m_perio_codigo.Equals(value) Then
					m_perio_codigo = value
					OnPERIO_CodigoChanged(m_perio_codigo, EventArgs.Empty)
				End If
			Else
				m_perio_codigo = value
				OnPERIO_CodigoChanged(m_perio_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property STOCK_Cantidad() As Double
		Get
			return m_stock_cantidad
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_stock_cantidad) Then
				If Not m_stock_cantidad.Equals(value) Then
					m_stock_cantidad = value
					OnSTOCK_CantidadChanged(m_stock_cantidad, EventArgs.Empty)
				End If
			Else
				m_stock_cantidad = value
				OnSTOCK_CantidadChanged(m_stock_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property STOCK_Inicial() As Double
		Get
			return m_stock_inicial
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_stock_inicial) Then
				If Not m_stock_inicial.Equals(value) Then
					m_stock_inicial = value
					OnSTOCK_InicialChanged(m_stock_inicial, EventArgs.Empty)
				End If
			Else
				m_stock_inicial = value
				OnSTOCK_InicialChanged(m_stock_inicial, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property STOCK_Minimo() As Double
		Get
			return m_stock_minimo
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_stock_minimo) Then
				If Not m_stock_minimo.Equals(value) Then
					m_stock_minimo = value
					OnSTOCK_MinimoChanged(m_stock_minimo, EventArgs.Empty)
				End If
			Else
				m_stock_minimo = value
				OnSTOCK_MinimoChanged(m_stock_minimo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property STOCK_Maximo() As Double
		Get
			return m_stock_maximo
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_stock_maximo) Then
				If Not m_stock_maximo.Equals(value) Then
					m_stock_maximo = value
					OnSTOCK_MaximoChanged(m_stock_maximo, EventArgs.Empty)
				End If
			Else
				m_stock_maximo = value
				OnSTOCK_MaximoChanged(m_stock_maximo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property STOCK_Activo() As Boolean
		Get
			return m_stock_activo
		End Get
		Set(ByVal value As Boolean)
			If Not m_stock_activo.Equals(value) Then
				m_stock_activo = value
				OnSTOCK_ActivoChanged(m_stock_activo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property STOCK_ReOrden() As Double
		Get
			return m_stock_reorden
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_stock_reorden) Then
				If Not m_stock_reorden.Equals(value) Then
					m_stock_reorden = value
					OnSTOCK_ReOrdenChanged(m_stock_reorden, EventArgs.Empty)
				End If
			Else
				m_stock_reorden = value
				OnSTOCK_ReOrdenChanged(m_stock_reorden, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property STOCK_UsrCrea() As String
		Get
			return m_stock_usrcrea
		End Get
		Set(ByVal value As String)
			m_stock_usrcrea = value
		End Set
	End Property
	Public Property STOCK_FecCrea() As Date
		Get
			return m_stock_feccrea
		End Get
		Set(ByVal value As Date)
			m_stock_feccrea = value
		End Set
	End Property
	Public Property STOCK_UsrMod() As String
		Get
			return m_stock_usrmod
		End Get
		Set(ByVal value As String)
			m_stock_usrmod = value
		End Set
	End Property
	Public Property STOCK_FecMod() As Date
		Get
			return m_stock_fecmod
		End Get
		Set(ByVal value As Date)
			m_stock_fecmod = value
		End Set
	End Property
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
			Return "Stocks"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event PERIO_CodigoChanged As EventHandler
	Public Event STOCK_CantidadChanged As EventHandler
	Public Event STOCK_InicialChanged As EventHandler
	Public Event STOCK_MinimoChanged As EventHandler
	Public Event STOCK_MaximoChanged As EventHandler
	Public Event STOCK_ActivoChanged As EventHandler
	Public Event STOCK_ReOrdenChanged As EventHandler
	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub
	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub
	Public Sub OnPERIO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PERIO_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSTOCK_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent STOCK_CantidadChanged(sender, e)
	End Sub
	Public Sub OnSTOCK_InicialChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent STOCK_InicialChanged(sender, e)
	End Sub
	Public Sub OnSTOCK_MinimoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent STOCK_MinimoChanged(sender, e)
	End Sub
	Public Sub OnSTOCK_MaximoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent STOCK_MaximoChanged(sender, e)
	End Sub
	Public Sub OnSTOCK_ActivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent STOCK_ActivoChanged(sender, e)
	End Sub
	Public Sub OnSTOCK_ReOrdenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent STOCK_ReOrdenChanged(sender, e)
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

