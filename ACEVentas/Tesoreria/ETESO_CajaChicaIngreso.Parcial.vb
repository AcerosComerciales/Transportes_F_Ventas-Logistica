Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_CajaChicaIngreso

#Region " Campos "
	
	Private m_pvent_id As Long
	Private m_cajac_id As Long
	Private m_entid_codigo As String
    Private m_tipos_codtipomoneda As String
    Private m_cajac_tipocambio As Decimal
    Private m_tipos_codtipocajachica As String
	Private m_cajac_fecha As Date
	Private m_cajac_detalle As String
	Private m_cajac_importe As Decimal
	Private m_cajac_estado As String
	Private m_cajac_usrcrea As String
	Private m_cajac_feccrea As Date
	Private m_cajac_usrmod As String
	Private m_cajac_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_CajaChicaIngreso
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

	Public Property TIPOS_CodTipoMoneda() As String
		Get
			return m_tipos_codtipomoneda
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipomoneda) Then
				If Not m_tipos_codtipomoneda.Equals(value) Then
					m_tipos_codtipomoneda = value
					OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipomoneda = value
				OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property TIPOS_CodTipoCajaChica() As String
        Get
            Return m_tipos_codtipocajachica
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codtipocajachica) Then
                If Not m_tipos_codtipocajachica.Equals(value) Then
                    m_tipos_codtipocajachica = value
                    OnTIPOS_CodTipoCajaChicaChanged(m_tipos_codtipocajachica, EventArgs.Empty)
                End If
            Else
                m_tipos_codtipocajachica = value
                OnTIPOS_CodTipoCajaChicaChanged(m_tipos_codtipocajachica, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property CAJAC_Fecha() As Date
		Get
			return m_cajac_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_cajac_fecha) Then
				If Not m_cajac_fecha.Equals(value) Then
					m_cajac_fecha = value
					OnCAJAC_FechaChanged(m_cajac_fecha, EventArgs.Empty)
				End If
			Else
				m_cajac_fecha = value
				OnCAJAC_FechaChanged(m_cajac_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJAC_Detalle() As String
		Get
			return m_cajac_detalle
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cajac_detalle) Then
				If Not m_cajac_detalle.Equals(value) Then
					m_cajac_detalle = value
					OnCAJAC_DetalleChanged(m_cajac_detalle, EventArgs.Empty)
				End If
			Else
				m_cajac_detalle = value
				OnCAJAC_DetalleChanged(m_cajac_detalle, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJAC_Importe() As Decimal
		Get
			return m_cajac_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cajac_importe) Then
				If Not m_cajac_importe.Equals(value) Then
					m_cajac_importe = value
					OnCAJAC_ImporteChanged(m_cajac_importe, EventArgs.Empty)
				End If
			Else
				m_cajac_importe = value
				OnCAJAC_ImporteChanged(m_cajac_importe, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property CAJAC_TipoCambio() As Decimal
        Get
            Return m_cajac_tipocambio
        End Get
        Set(ByVal value As Decimal)
            m_cajac_tipocambio = value
        End Set
    End Property

	Public Property CAJAC_Estado() As String
		Get
			return m_cajac_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cajac_estado) Then
				If Not m_cajac_estado.Equals(value) Then
					m_cajac_estado = value
					OnCAJAC_EstadoChanged(m_cajac_estado, EventArgs.Empty)
				End If
			Else
				m_cajac_estado = value
				OnCAJAC_EstadoChanged(m_cajac_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJAC_UsrCrea() As String
		Get
			return m_cajac_usrcrea
		End Get
		Set(ByVal value As String)
			m_cajac_usrcrea = value
		End Set
	End Property

	Public Property CAJAC_FecCrea() As Date
		Get
			return m_cajac_feccrea
		End Get
		Set(ByVal value As Date)
			m_cajac_feccrea = value
		End Set
	End Property

	Public Property CAJAC_UsrMod() As String
		Get
			return m_cajac_usrmod
		End Get
		Set(ByVal value As String)
			m_cajac_usrmod = value
		End Set
	End Property

	Public Property CAJAC_FecMod() As Date
		Get
			return m_cajac_fecmod
		End Get
		Set(ByVal value As Date)
			m_cajac_fecmod = value
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
			Return "TESO_CajaChicaIngreso"
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
	Public Event ENTID_CodigoChanged As EventHandler
    Public Event TIPOS_CodTipoMonedaChanged As EventHandler
    Public Event TIPOS_CodTipoCajaChicaChanged As EventHandler
	Public Event CAJAC_FechaChanged As EventHandler
	Public Event CAJAC_DetalleChanged As EventHandler
	Public Event CAJAC_ImporteChanged As EventHandler
	Public Event CAJAC_EstadoChanged As EventHandler

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnCAJAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAC_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
    End Sub
    Public Sub OnTIPOS_CodTipoCajaChicaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoCajaChicaChanged(sender, e)
    End Sub

	Public Sub OnCAJAC_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAC_FechaChanged(sender, e)
	End Sub

	Public Sub OnCAJAC_DetalleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAC_DetalleChanged(sender, e)
	End Sub

	Public Sub OnCAJAC_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAC_ImporteChanged(sender, e)
	End Sub

	Public Sub OnCAJAC_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJAC_EstadoChanged(sender, e)
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

