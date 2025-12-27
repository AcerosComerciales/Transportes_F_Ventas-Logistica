Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EVENT_PedidosDetalle

#Region " Campos "
	
	Private m_pedid_codigo As String
	Private m_pddet_item As Short
	Private m_zonas_codigo As String
	Private m_lprec_id As Long
	Private m_almac_id As Short
	Private m_artic_codigo As String
	Private m_pddet_percepcion As Boolean
	Private m_pddet_costounitario As Decimal
	Private m_pddet_pesounitario As Decimal
	Private m_pddet_preciounitario As Decimal
	Private m_pddet_cantidad As Decimal
	Private m_pddet_subimporteventa As Decimal
	Private m_pddet_subimportepercepcion As Decimal
	Private m_pddet_stocklocal As Decimal
	Private m_pddet_stockprincipal As Decimal
	Private m_pddet_prfaltante As Decimal
	Private m_pddet_costounitariodolares As Decimal
	Private m_pddet_costounitariosoles As Decimal
	Private m_pddet_tipocambiocosto As Decimal
	Private m_pddet_usrcrea As String
	Private m_pddet_feccrea As Date
	Private m_pddet_usrmod As String
	Private m_pddet_fecmod As Date
    Private m_referencia As String
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
    Private m_eliminado As Boolean
    Private m_linea As String

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlVENT_PedidosDetalle
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
	
	Public Property PEDID_Codigo() As String
		Get
			return m_pedid_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_codigo) Then
				If Not m_pedid_codigo.Equals(value) Then
					m_pedid_codigo = value
					OnPEDID_CodigoChanged(m_pedid_codigo, EventArgs.Empty)
				End If
			Else
				m_pedid_codigo = value
				OnPEDID_CodigoChanged(m_pedid_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property PDDET_Referencia() As String
		Get
			return m_referencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_referencia) Then
				If Not m_referencia.Equals(value) Then
					m_referencia = value
					OnPDDET_ReferenciaChanged(m_referencia, EventArgs.Empty)
				End If
			Else
				m_referencia = value
				OnPDDET_ReferenciaChanged(m_referencia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_Item() As Short
		Get
			return m_pddet_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_pddet_item) Then
				If Not m_pddet_item.Equals(value) Then
					m_pddet_item = value
					OnPDDET_ItemChanged(m_pddet_item, EventArgs.Empty)
				End If
			Else
				m_pddet_item = value
				OnPDDET_ItemChanged(m_pddet_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ZONAS_Codigo() As String
		Get
			return m_zonas_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_zonas_codigo) Then
				If Not m_zonas_codigo.Equals(value) Then
					m_zonas_codigo = value
					OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
				End If
			Else
				m_zonas_codigo = value
				OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property LPREC_Id() As Long
		Get
			return m_lprec_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_lprec_id) Then
				If Not m_lprec_id.Equals(value) Then
					m_lprec_id = value
					OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
				End If
			Else
				m_lprec_id = value
				OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
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

	Public Property PDDET_Percepcion() As Boolean
		Get
			return m_pddet_percepcion
		End Get
		Set(ByVal value As Boolean)
			If Not m_pddet_percepcion.Equals(value) Then
				m_pddet_percepcion = value
				OnPDDET_PercepcionChanged(m_pddet_percepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_CostoUnitario() As Decimal
		Get
			return m_pddet_costounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_costounitario) Then
				If Not m_pddet_costounitario.Equals(value) Then
					m_pddet_costounitario = value
					OnPDDET_CostoUnitarioChanged(m_pddet_costounitario, EventArgs.Empty)
				End If
			Else
				m_pddet_costounitario = value
				OnPDDET_CostoUnitarioChanged(m_pddet_costounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_PesoUnitario() As Decimal
		Get
			return m_pddet_pesounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_pesounitario) Then
				If Not m_pddet_pesounitario.Equals(value) Then
					m_pddet_pesounitario = value
					OnPDDET_PesoUnitarioChanged(m_pddet_pesounitario, EventArgs.Empty)
				End If
			Else
				m_pddet_pesounitario = value
				OnPDDET_PesoUnitarioChanged(m_pddet_pesounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_PrecioUnitario() As Decimal
		Get
			return m_pddet_preciounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_preciounitario) Then
				If Not m_pddet_preciounitario.Equals(value) Then
					m_pddet_preciounitario = value
					OnPDDET_PrecioUnitarioChanged(m_pddet_preciounitario, EventArgs.Empty)
				End If
			Else
				m_pddet_preciounitario = value
				OnPDDET_PrecioUnitarioChanged(m_pddet_preciounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_Cantidad() As Decimal
		Get
			return m_pddet_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_cantidad) Then
				If Not m_pddet_cantidad.Equals(value) Then
					m_pddet_cantidad = value
					OnPDDET_CantidadChanged(m_pddet_cantidad, EventArgs.Empty)
				End If
			Else
				m_pddet_cantidad = value
				OnPDDET_CantidadChanged(m_pddet_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_SubImporteVenta() As Decimal
		Get
			return m_pddet_subimporteventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_subimporteventa) Then
				If Not m_pddet_subimporteventa.Equals(value) Then
					m_pddet_subimporteventa = value
					OnPDDET_SubImporteVentaChanged(m_pddet_subimporteventa, EventArgs.Empty)
				End If
			Else
				m_pddet_subimporteventa = value
				OnPDDET_SubImporteVentaChanged(m_pddet_subimporteventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_SubImportePercepcion() As Decimal
		Get
			return m_pddet_subimportepercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_subimportepercepcion) Then
				If Not m_pddet_subimportepercepcion.Equals(value) Then
					m_pddet_subimportepercepcion = value
					OnPDDET_SubImportePercepcionChanged(m_pddet_subimportepercepcion, EventArgs.Empty)
				End If
			Else
				m_pddet_subimportepercepcion = value
				OnPDDET_SubImportePercepcionChanged(m_pddet_subimportepercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_StockLocal() As Decimal
		Get
			return m_pddet_stocklocal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_stocklocal) Then
				If Not m_pddet_stocklocal.Equals(value) Then
					m_pddet_stocklocal = value
					OnPDDET_StockLocalChanged(m_pddet_stocklocal, EventArgs.Empty)
				End If
			Else
				m_pddet_stocklocal = value
				OnPDDET_StockLocalChanged(m_pddet_stocklocal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_StockPrincipal() As Decimal
		Get
			return m_pddet_stockprincipal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_stockprincipal) Then
				If Not m_pddet_stockprincipal.Equals(value) Then
					m_pddet_stockprincipal = value
					OnPDDET_StockPrincipalChanged(m_pddet_stockprincipal, EventArgs.Empty)
				End If
			Else
				m_pddet_stockprincipal = value
				OnPDDET_StockPrincipalChanged(m_pddet_stockprincipal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_PRFaltante() As Decimal
		Get
			return m_pddet_prfaltante
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_prfaltante) Then
				If Not m_pddet_prfaltante.Equals(value) Then
					m_pddet_prfaltante = value
					OnPDDET_PRFaltanteChanged(m_pddet_prfaltante, EventArgs.Empty)
				End If
			Else
				m_pddet_prfaltante = value
				OnPDDET_PRFaltanteChanged(m_pddet_prfaltante, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_CostoUnitarioDolares() As Decimal
		Get
			return m_pddet_costounitariodolares
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_costounitariodolares) Then
				If Not m_pddet_costounitariodolares.Equals(value) Then
					m_pddet_costounitariodolares = value
					OnPDDET_CostoUnitarioDolaresChanged(m_pddet_costounitariodolares, EventArgs.Empty)
				End If
			Else
				m_pddet_costounitariodolares = value
				OnPDDET_CostoUnitarioDolaresChanged(m_pddet_costounitariodolares, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_CostoUnitarioSoles() As Decimal
		Get
			return m_pddet_costounitariosoles
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_costounitariosoles) Then
				If Not m_pddet_costounitariosoles.Equals(value) Then
					m_pddet_costounitariosoles = value
					OnPDDET_CostoUnitarioSolesChanged(m_pddet_costounitariosoles, EventArgs.Empty)
				End If
			Else
				m_pddet_costounitariosoles = value
				OnPDDET_CostoUnitarioSolesChanged(m_pddet_costounitariosoles, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_TipoCambioCosto() As Decimal
		Get
			return m_pddet_tipocambiocosto
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pddet_tipocambiocosto) Then
				If Not m_pddet_tipocambiocosto.Equals(value) Then
					m_pddet_tipocambiocosto = value
					OnPDDET_TipoCambioCostoChanged(m_pddet_tipocambiocosto, EventArgs.Empty)
				End If
			Else
				m_pddet_tipocambiocosto = value
				OnPDDET_TipoCambioCostoChanged(m_pddet_tipocambiocosto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PDDET_UsrCrea() As String
		Get
			return m_pddet_usrcrea
		End Get
		Set(ByVal value As String)
			m_pddet_usrcrea = value
		End Set
    End Property

    Public Property PDDET_Linea() As String
        Get
            Return m_linea
        End Get
        Set(ByVal value As String)
            m_linea = value
        End Set
    End Property


	Public Property PDDET_FecCrea() As Date
		Get
			return m_pddet_feccrea
		End Get
		Set(ByVal value As Date)
			m_pddet_feccrea = value
		End Set
	End Property

	Public Property PDDET_UsrMod() As String
		Get
			return m_pddet_usrmod
		End Get
		Set(ByVal value As String)
			m_pddet_usrmod = value
		End Set
	End Property

	Public Property PDDET_FecMod() As Date
		Get
			return m_pddet_fecmod
		End Get
		Set(ByVal value As Date)
			m_pddet_fecmod = value
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
      Public ReadOnly Property  Total() As Decimal
        Get
			return m_pddet_pesounitario*m_pddet_cantidad
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
			Return "VENT_PedidosDetalle"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Ventas"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event PEDID_CodigoChanged As EventHandler
	Public Event PDDET_ItemChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event LPREC_IdChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event PDDET_PercepcionChanged As EventHandler
	Public Event PDDET_CostoUnitarioChanged As EventHandler
	Public Event PDDET_PesoUnitarioChanged As EventHandler
	Public Event PDDET_PrecioUnitarioChanged As EventHandler
	Public Event PDDET_CantidadChanged As EventHandler
	Public Event PDDET_SubImporteVentaChanged As EventHandler
	Public Event PDDET_SubImportePercepcionChanged As EventHandler
	Public Event PDDET_StockLocalChanged As EventHandler
    Public Event PDDET_ReferenciaChanged as EventHandler
	Public Event PDDET_StockPrincipalChanged As EventHandler
	Public Event PDDET_PRFaltanteChanged As EventHandler
	Public Event PDDET_CostoUnitarioDolaresChanged As EventHandler
	Public Event PDDET_CostoUnitarioSolesChanged As EventHandler
	Public Event PDDET_TipoCambioCostoChanged As EventHandler

	Public Sub OnPEDID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CodigoChanged(sender, e)
	End Sub

      Public Sub OnPDDET_ReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_ReferenciaChanged(sender, e)
	End Sub
    

	Public Sub OnPDDET_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_ItemChanged(sender, e)
	End Sub

	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnLPREC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent LPREC_IdChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPDDET_PercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_PercepcionChanged(sender, e)
	End Sub

	Public Sub OnPDDET_CostoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_CostoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnPDDET_PesoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_PesoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnPDDET_PrecioUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_PrecioUnitarioChanged(sender, e)
	End Sub

	Public Sub OnPDDET_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_CantidadChanged(sender, e)
	End Sub

	Public Sub OnPDDET_SubImporteVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_SubImporteVentaChanged(sender, e)
	End Sub

	Public Sub OnPDDET_SubImportePercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_SubImportePercepcionChanged(sender, e)
	End Sub

	Public Sub OnPDDET_StockLocalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_StockLocalChanged(sender, e)
	End Sub

	Public Sub OnPDDET_StockPrincipalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_StockPrincipalChanged(sender, e)
	End Sub

	Public Sub OnPDDET_PRFaltanteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_PRFaltanteChanged(sender, e)
	End Sub

	Public Sub OnPDDET_CostoUnitarioDolaresChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_CostoUnitarioDolaresChanged(sender, e)
	End Sub

	Public Sub OnPDDET_CostoUnitarioSolesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_CostoUnitarioSolesChanged(sender, e)
	End Sub

	Public Sub OnPDDET_TipoCambioCostoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PDDET_TipoCambioCostoChanged(sender, e)
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

