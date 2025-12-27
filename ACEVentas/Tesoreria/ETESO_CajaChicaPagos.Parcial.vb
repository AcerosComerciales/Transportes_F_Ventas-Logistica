Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_CajaChicaPagos

#Region " Campos "
	
	Private m_pvent_id As Long
	Private m_cajac_id As Long
	Private m_cajap_item As Short
	Private m_entid_codigo As String
	Private m_docus_codigo As String
	Private m_cajap_descripcion As String
	Private m_cajap_fecha As Date
	Private m_cajap_importe As Decimal
	Private m_cajap_estado As String
	Private m_tipos_codtipopago As String
	Private m_cajap_usrcrea As String
	Private m_cajap_feccrea As Date
	Private m_cajap_usrmod As String
    Private m_cajap_fecmod As Date

    Private m_dpago_id As Long
    Private m_cajap_tipocambio As Decimal

	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_CajaChicaPagos
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
	
	Public Property PVENT_Id() As Long
		Get
			return m_pvent_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pvent_id) Then
				If Not m_pvent_id.Equals(value) Then
					m_pvent_id = value
					OnPVENT_IdChanged(m_pvent_id, EventArgs.Empty)
				End If
			Else
				m_pvent_id = value
				OnPVENT_IdChanged(m_pvent_id, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property DPAGO_Id() As Long
        Get
            Return m_dpago_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_dpago_id) Then
                If Not m_dpago_id.Equals(value) Then
                    m_dpago_id = value
                    OnDPAGO_IdChanged(m_dpago_id, EventArgs.Empty)
                End If
            Else
                m_dpago_id = value
                OnDPAGO_IdChanged(m_dpago_id, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property CAJAC_Id() As Long
		Get
			return m_cajac_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_cajac_id) Then
				If Not m_cajac_id.Equals(value) Then
					m_cajac_id = value
					OnCAJAC_IdChanged(m_cajac_id, EventArgs.Empty)
				End If
			Else
				m_cajac_id = value
				OnCAJAC_IdChanged(m_cajac_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJAP_Item() As Short
		Get
			return m_cajap_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_cajap_item) Then
				If Not m_cajap_item.Equals(value) Then
					m_cajap_item = value
					OnCAJAP_ItemChanged(m_cajap_item, EventArgs.Empty)
				End If
			Else
				m_cajap_item = value
				OnCAJAP_ItemChanged(m_cajap_item, EventArgs.Empty)
			End If
		End Set
    End Property

    Public Property CAJAP_TipoCambio() As Decimal
        Get
            Return m_cajap_tipocambio
        End Get
        Set(ByVal value As Decimal)
            m_cajap_tipocambio = value
        End Set
    End Property

	Public Property ENTID_Codigo() As String
		Get
			return m_entid_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigo) Then
				If Not m_entid_codigo.Equals(value) Then
					m_entid_codigo = value
					OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
				End If
			Else
				m_entid_codigo = value
				OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCUS_Codigo() As String
		Get
			return m_docus_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docus_codigo) Then
				If Not m_docus_codigo.Equals(value) Then
					m_docus_codigo = value
					OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
				End If
			Else
				m_docus_codigo = value
				OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJAP_Descripcion() As String
		Get
			return m_cajap_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cajap_descripcion) Then
				If Not m_cajap_descripcion.Equals(value) Then
					m_cajap_descripcion = value
					OnCAJAP_DescripcionChanged(m_cajap_descripcion, EventArgs.Empty)
				End If
			Else
				m_cajap_descripcion = value
				OnCAJAP_DescripcionChanged(m_cajap_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJAP_Fecha() As Date
		Get
			return m_cajap_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_cajap_fecha) Then
				If Not m_cajap_fecha.Equals(value) Then
					m_cajap_fecha = value
					OnCAJAP_FechaChanged(m_cajap_fecha, EventArgs.Empty)
				End If
			Else
				m_cajap_fecha = value
				OnCAJAP_FechaChanged(m_cajap_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJAP_Importe() As Decimal
		Get
			return m_cajap_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cajap_importe) Then
				If Not m_cajap_importe.Equals(value) Then
					m_cajap_importe = value
					OnCAJAP_ImporteChanged(m_cajap_importe, EventArgs.Empty)
				End If
			Else
				m_cajap_importe = value
				OnCAJAP_ImporteChanged(m_cajap_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJAP_Estado() As String
		Get
			return m_cajap_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cajap_estado) Then
				If Not m_cajap_estado.Equals(value) Then
					m_cajap_estado = value
					OnCAJAP_EstadoChanged(m_cajap_estado, EventArgs.Empty)
				End If
			Else
				m_cajap_estado = value
				OnCAJAP_EstadoChanged(m_cajap_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoPago() As String
		Get
			return m_tipos_codtipopago
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipopago) Then
				If Not m_tipos_codtipopago.Equals(value) Then
					m_tipos_codtipopago = value
					OnTIPOS_CodTipoPagoChanged(m_tipos_codtipopago, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipopago = value
				OnTIPOS_CodTipoPagoChanged(m_tipos_codtipopago, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJAP_UsrCrea() As String
		Get
			return m_cajap_usrcrea
		End Get
		Set(ByVal value As String)
			m_cajap_usrcrea = value
		End Set
	End Property

	Public Property CAJAP_FecCrea() As Date
		Get
			return m_cajap_feccrea
		End Get
		Set(ByVal value As Date)
			m_cajap_feccrea = value
		End Set
	End Property

	Public Property CAJAP_UsrMod() As String
		Get
			return m_cajap_usrmod
		End Get
		Set(ByVal value As String)
			m_cajap_usrmod = value
		End Set
	End Property

	Public Property CAJAP_FecMod() As Date
		Get
			return m_cajap_fecmod
		End Get
		Set(ByVal value As Date)
			m_cajap_fecmod = value
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
			Return "TESO_CajaChicaPagos"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Tesoreria"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event PVENT_IdChanged As EventHandler
	Public Event CAJAC_IdChanged As EventHandler
	Public Event CAJAP_ItemChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
    Public Event DOCUS_CodigoChanged As EventHandler
    Public Event DPAGO_IdChanged As EventHandler
	Public Event CAJAP_DescripcionChanged As EventHandler
	Public Event CAJAP_FechaChanged As EventHandler
	Public Event CAJAP_ImporteChanged As EventHandler
	Public Event CAJAP_EstadoChanged As EventHandler
	Public Event TIPOS_CodTipoPagoChanged As EventHandler

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnCAJAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAC_IdChanged(sender, e)
	End Sub

	Public Sub OnCAJAP_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAP_ItemChanged(sender, e)
    End Sub
    Public Sub OnDPAGO_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DPAGO_IdChanged(sender, e)
    End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDOCUS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCUS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnCAJAP_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAP_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnCAJAP_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAP_FechaChanged(sender, e)
	End Sub

	Public Sub OnCAJAP_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAP_ImporteChanged(sender, e)
	End Sub

	Public Sub OnCAJAP_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAP_EstadoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoPagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoPagoChanged(sender, e)
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

