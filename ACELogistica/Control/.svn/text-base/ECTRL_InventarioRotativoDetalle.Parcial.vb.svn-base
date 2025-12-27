Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECTRL_InventarioRotativoDetalle

#Region " Campos "
	
	Private m_inrot_codigo As String
	Private m_inrod_item As Integer
	Private m_artic_codigo As String
	Private m_inrod_stock As Decimal
	Private m_inrod_penordenes As Decimal
	Private m_inrod_penpedidos As Decimal
	Private m_inrod_penfacturas As Decimal
	Private m_inrod_penconfirmacion As Decimal
	Private m_inrod_pendiente As Decimal
	Private m_inrod_stockfinal As Decimal
	Private m_inrod_stockfisico As Decimal
	Private m_inrod_vericorrecto As Boolean
	Private m_inrod_verisobrante As Decimal
	Private m_inrod_verifaltante As Decimal
	Private m_inrod_usrcrea As String
	Private m_inrod_feccrea As Date
	Private m_inrod_usrmod As String
	Private m_inrod_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlCTRL_InventarioRotativoDetalle
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
	
	Public Property INROT_Codigo() As String
		Get
			return m_inrot_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_inrot_codigo) Then
				If Not m_inrot_codigo.Equals(value) Then
					m_inrot_codigo = value
					OnINROT_CodigoChanged(m_inrot_codigo, EventArgs.Empty)
				End If
			Else
				m_inrot_codigo = value
				OnINROT_CodigoChanged(m_inrot_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_Item() As Integer
		Get
			return m_inrod_item
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_inrod_item) Then
				If Not m_inrod_item.Equals(value) Then
					m_inrod_item = value
					OnINROD_ItemChanged(m_inrod_item, EventArgs.Empty)
				End If
			Else
				m_inrod_item = value
				OnINROD_ItemChanged(m_inrod_item, EventArgs.Empty)
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

	Public Property INROD_Stock() As Decimal
		Get
			return m_inrod_stock
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_stock) Then
				If Not m_inrod_stock.Equals(value) Then
					m_inrod_stock = value
					OnINROD_StockChanged(m_inrod_stock, EventArgs.Empty)
				End If
			Else
				m_inrod_stock = value
				OnINROD_StockChanged(m_inrod_stock, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_PenOrdenes() As Decimal
		Get
			return m_inrod_penordenes
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_penordenes) Then
				If Not m_inrod_penordenes.Equals(value) Then
					m_inrod_penordenes = value
					OnINROD_PenOrdenesChanged(m_inrod_penordenes, EventArgs.Empty)
				End If
			Else
				m_inrod_penordenes = value
				OnINROD_PenOrdenesChanged(m_inrod_penordenes, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_PenPedidos() As Decimal
		Get
			return m_inrod_penpedidos
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_penpedidos) Then
				If Not m_inrod_penpedidos.Equals(value) Then
					m_inrod_penpedidos = value
					OnINROD_PenPedidosChanged(m_inrod_penpedidos, EventArgs.Empty)
				End If
			Else
				m_inrod_penpedidos = value
				OnINROD_PenPedidosChanged(m_inrod_penpedidos, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_PenFacturas() As Decimal
		Get
			return m_inrod_penfacturas
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_penfacturas) Then
				If Not m_inrod_penfacturas.Equals(value) Then
					m_inrod_penfacturas = value
					OnINROD_PenFacturasChanged(m_inrod_penfacturas, EventArgs.Empty)
				End If
			Else
				m_inrod_penfacturas = value
				OnINROD_PenFacturasChanged(m_inrod_penfacturas, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_PenConfirmacion() As Decimal
		Get
			return m_inrod_penconfirmacion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_penconfirmacion) Then
				If Not m_inrod_penconfirmacion.Equals(value) Then
					m_inrod_penconfirmacion = value
					OnINROD_PenConfirmacionChanged(m_inrod_penconfirmacion, EventArgs.Empty)
				End If
			Else
				m_inrod_penconfirmacion = value
				OnINROD_PenConfirmacionChanged(m_inrod_penconfirmacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_Pendiente() As Decimal
		Get
			return m_inrod_pendiente
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_pendiente) Then
				If Not m_inrod_pendiente.Equals(value) Then
					m_inrod_pendiente = value
					OnINROD_PendienteChanged(m_inrod_pendiente, EventArgs.Empty)
				End If
			Else
				m_inrod_pendiente = value
				OnINROD_PendienteChanged(m_inrod_pendiente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_StockFinal() As Decimal
		Get
			return m_inrod_stockfinal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_stockfinal) Then
				If Not m_inrod_stockfinal.Equals(value) Then
					m_inrod_stockfinal = value
					OnINROD_StockFinalChanged(m_inrod_stockfinal, EventArgs.Empty)
				End If
			Else
				m_inrod_stockfinal = value
				OnINROD_StockFinalChanged(m_inrod_stockfinal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_StockFisico() As Decimal
		Get
			return m_inrod_stockfisico
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_stockfisico) Then
				If Not m_inrod_stockfisico.Equals(value) Then
					m_inrod_stockfisico = value
					OnINROD_StockFisicoChanged(m_inrod_stockfisico, EventArgs.Empty)
				End If
			Else
				m_inrod_stockfisico = value
				OnINROD_StockFisicoChanged(m_inrod_stockfisico, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_VeriCorrecto() As Boolean
		Get
			return m_inrod_vericorrecto
		End Get
		Set(ByVal value As Boolean)
			If Not m_inrod_vericorrecto.Equals(value) Then
				m_inrod_vericorrecto = value
				OnINROD_VeriCorrectoChanged(m_inrod_vericorrecto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_VeriSobrante() As Decimal
		Get
			return m_inrod_verisobrante
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_verisobrante) Then
				If Not m_inrod_verisobrante.Equals(value) Then
					m_inrod_verisobrante = value
					OnINROD_VeriSobranteChanged(m_inrod_verisobrante, EventArgs.Empty)
				End If
			Else
				m_inrod_verisobrante = value
				OnINROD_VeriSobranteChanged(m_inrod_verisobrante, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_VeriFaltante() As Decimal
		Get
			return m_inrod_verifaltante
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_inrod_verifaltante) Then
				If Not m_inrod_verifaltante.Equals(value) Then
					m_inrod_verifaltante = value
					OnINROD_VeriFaltanteChanged(m_inrod_verifaltante, EventArgs.Empty)
				End If
			Else
				m_inrod_verifaltante = value
				OnINROD_VeriFaltanteChanged(m_inrod_verifaltante, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property INROD_UsrCrea() As String
		Get
			return m_inrod_usrcrea
		End Get
		Set(ByVal value As String)
			m_inrod_usrcrea = value
		End Set
	End Property

	Public Property INROD_FecCrea() As Date
		Get
			return m_inrod_feccrea
		End Get
		Set(ByVal value As Date)
			m_inrod_feccrea = value
		End Set
	End Property

	Public Property INROD_UsrMod() As String
		Get
			return m_inrod_usrmod
		End Get
		Set(ByVal value As String)
			m_inrod_usrmod = value
		End Set
	End Property

	Public Property INROD_FecMod() As Date
		Get
			return m_inrod_fecmod
		End Get
		Set(ByVal value As Date)
			m_inrod_fecmod = value
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
			Return "CTRL_InventarioRotativoDetalle"
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
	
	Public Event INROT_CodigoChanged As EventHandler
	Public Event INROD_ItemChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event INROD_StockChanged As EventHandler
	Public Event INROD_PenOrdenesChanged As EventHandler
	Public Event INROD_PenPedidosChanged As EventHandler
	Public Event INROD_PenFacturasChanged As EventHandler
	Public Event INROD_PenConfirmacionChanged As EventHandler
	Public Event INROD_PendienteChanged As EventHandler
	Public Event INROD_StockFinalChanged As EventHandler
	Public Event INROD_StockFisicoChanged As EventHandler
	Public Event INROD_VeriCorrectoChanged As EventHandler
	Public Event INROD_VeriSobranteChanged As EventHandler
	Public Event INROD_VeriFaltanteChanged As EventHandler

	Public Sub OnINROT_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROT_CodigoChanged(sender, e)
	End Sub

	Public Sub OnINROD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_ItemChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnINROD_StockChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_StockChanged(sender, e)
	End Sub

	Public Sub OnINROD_PenOrdenesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_PenOrdenesChanged(sender, e)
	End Sub

	Public Sub OnINROD_PenPedidosChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_PenPedidosChanged(sender, e)
	End Sub

	Public Sub OnINROD_PenFacturasChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_PenFacturasChanged(sender, e)
	End Sub

	Public Sub OnINROD_PenConfirmacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_PenConfirmacionChanged(sender, e)
	End Sub

	Public Sub OnINROD_PendienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_PendienteChanged(sender, e)
	End Sub

	Public Sub OnINROD_StockFinalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_StockFinalChanged(sender, e)
	End Sub

	Public Sub OnINROD_StockFisicoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_StockFisicoChanged(sender, e)
	End Sub

	Public Sub OnINROD_VeriCorrectoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_VeriCorrectoChanged(sender, e)
	End Sub

	Public Sub OnINROD_VeriSobranteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_VeriSobranteChanged(sender, e)
	End Sub

	Public Sub OnINROD_VeriFaltanteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INROD_VeriFaltanteChanged(sender, e)
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

