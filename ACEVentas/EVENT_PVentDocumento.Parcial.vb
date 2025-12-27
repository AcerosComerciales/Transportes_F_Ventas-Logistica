Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EVENT_PVentDocumento

#Region " Campos "
	
	Private m_pvdocu_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_pvent_id As Long
	Private m_almac_id As Short
	Private m_tipos_codtipodocumento As String
	Private m_pvdocu_serie As String
	Private m_pvdocu_autorizacion As String
	Private m_pvdocu_nrolineas As Integer
	Private m_pvdocu_predeterminado As Boolean
	Private m_pvdocu_predetboleta As Boolean
	Private m_pvdocu_predetguiaremistransportista As Boolean
	Private m_pvdocu_predetguiaremisremitventas As Boolean
	Private m_pvdocu_predetguiaremisremittransportista As Boolean
	Private m_pvdocu_dispositivoimpresion As String
	Private m_pvdocu_app As String
	Private m_pvdocu_top As Short
	Private m_pvdocu_left As Short
	Private m_pvdocu_tipoimpresion As String
	Private m_pvdocu_usrcrea As String
	Private m_pvdocu_feccrea As Date
	Private m_pvdocu_usrmod As String
	Private m_pvdocu_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlVENT_PVentDocumento
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
	
	Public Property PVDOCU_Id() As Long
		Get
			return m_pvdocu_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pvdocu_id) Then
				If Not m_pvdocu_id.Equals(value) Then
					m_pvdocu_id = value
					OnPVDOCU_IdChanged(m_pvdocu_id, EventArgs.Empty)
				End If
			Else
				m_pvdocu_id = value
				OnPVDOCU_IdChanged(m_pvdocu_id, EventArgs.Empty)
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

	Public Property SUCUR_Id() As Short
		Get
			return m_sucur_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_sucur_id) Then
				If Not m_sucur_id.Equals(value) Then
					m_sucur_id = value
					OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
				End If
			Else
				m_sucur_id = value
				OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
			End If
		End Set
	End Property

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

	Public Property TIPOS_CodTipoDocumento() As String
		Get
			return m_tipos_codtipodocumento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipodocumento) Then
				If Not m_tipos_codtipodocumento.Equals(value) Then
					m_tipos_codtipodocumento = value
					OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipodocumento = value
				OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_Serie() As String
		Get
			return m_pvdocu_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pvdocu_serie) Then
				If Not m_pvdocu_serie.Equals(value) Then
					m_pvdocu_serie = value
					OnPVDOCU_SerieChanged(m_pvdocu_serie, EventArgs.Empty)
				End If
			Else
				m_pvdocu_serie = value
				OnPVDOCU_SerieChanged(m_pvdocu_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_Autorizacion() As String
		Get
			return m_pvdocu_autorizacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pvdocu_autorizacion) Then
				If Not m_pvdocu_autorizacion.Equals(value) Then
					m_pvdocu_autorizacion = value
					OnPVDOCU_AutorizacionChanged(m_pvdocu_autorizacion, EventArgs.Empty)
				End If
			Else
				m_pvdocu_autorizacion = value
				OnPVDOCU_AutorizacionChanged(m_pvdocu_autorizacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_NroLineas() As Integer
		Get
			return m_pvdocu_nrolineas
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_pvdocu_nrolineas) Then
				If Not m_pvdocu_nrolineas.Equals(value) Then
					m_pvdocu_nrolineas = value
					OnPVDOCU_NroLineasChanged(m_pvdocu_nrolineas, EventArgs.Empty)
				End If
			Else
				m_pvdocu_nrolineas = value
				OnPVDOCU_NroLineasChanged(m_pvdocu_nrolineas, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_Predeterminado() As Boolean
		Get
			return m_pvdocu_predeterminado
		End Get
		Set(ByVal value As Boolean)
			If Not m_pvdocu_predeterminado.Equals(value) Then
				m_pvdocu_predeterminado = value
				OnPVDOCU_PredeterminadoChanged(m_pvdocu_predeterminado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_PredetBoleta() As Boolean
		Get
			return m_pvdocu_predetboleta
		End Get
		Set(ByVal value As Boolean)
			If Not m_pvdocu_predetboleta.Equals(value) Then
				m_pvdocu_predetboleta = value
				OnPVDOCU_PredetBoletaChanged(m_pvdocu_predetboleta, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_PredetGuiaRemisTransportista() As Boolean
		Get
			return m_pvdocu_predetguiaremistransportista
		End Get
		Set(ByVal value As Boolean)
			If Not m_pvdocu_predetguiaremistransportista.Equals(value) Then
				m_pvdocu_predetguiaremistransportista = value
				OnPVDOCU_PredetGuiaRemisTransportistaChanged(m_pvdocu_predetguiaremistransportista, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_PredetGuiaRemisRemitVentas() As Boolean
		Get
			return m_pvdocu_predetguiaremisremitventas
		End Get
		Set(ByVal value As Boolean)
			If Not m_pvdocu_predetguiaremisremitventas.Equals(value) Then
				m_pvdocu_predetguiaremisremitventas = value
				OnPVDOCU_PredetGuiaRemisRemitVentasChanged(m_pvdocu_predetguiaremisremitventas, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_PredetGuiaRemisRemitTransportista() As Boolean
		Get
			return m_pvdocu_predetguiaremisremittransportista
		End Get
		Set(ByVal value As Boolean)
			If Not m_pvdocu_predetguiaremisremittransportista.Equals(value) Then
				m_pvdocu_predetguiaremisremittransportista = value
				OnPVDOCU_PredetGuiaRemisRemitTransportistaChanged(m_pvdocu_predetguiaremisremittransportista, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_DispositivoImpresion() As String
		Get
			return m_pvdocu_dispositivoimpresion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pvdocu_dispositivoimpresion) Then
				If Not m_pvdocu_dispositivoimpresion.Equals(value) Then
					m_pvdocu_dispositivoimpresion = value
					OnPVDOCU_DispositivoImpresionChanged(m_pvdocu_dispositivoimpresion, EventArgs.Empty)
				End If
			Else
				m_pvdocu_dispositivoimpresion = value
				OnPVDOCU_DispositivoImpresionChanged(m_pvdocu_dispositivoimpresion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_App() As String
		Get
			return m_pvdocu_app
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pvdocu_app) Then
				If Not m_pvdocu_app.Equals(value) Then
					m_pvdocu_app = value
					OnPVDOCU_AppChanged(m_pvdocu_app, EventArgs.Empty)
				End If
			Else
				m_pvdocu_app = value
				OnPVDOCU_AppChanged(m_pvdocu_app, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_Top() As Short
		Get
			return m_pvdocu_top
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_pvdocu_top) Then
				If Not m_pvdocu_top.Equals(value) Then
					m_pvdocu_top = value
					OnPVDOCU_TopChanged(m_pvdocu_top, EventArgs.Empty)
				End If
			Else
				m_pvdocu_top = value
				OnPVDOCU_TopChanged(m_pvdocu_top, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_Left() As Short
		Get
			return m_pvdocu_left
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_pvdocu_left) Then
				If Not m_pvdocu_left.Equals(value) Then
					m_pvdocu_left = value
					OnPVDOCU_LeftChanged(m_pvdocu_left, EventArgs.Empty)
				End If
			Else
				m_pvdocu_left = value
				OnPVDOCU_LeftChanged(m_pvdocu_left, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_TipoImpresion() As String
		Get
			return m_pvdocu_tipoimpresion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pvdocu_tipoimpresion) Then
				If Not m_pvdocu_tipoimpresion.Equals(value) Then
					m_pvdocu_tipoimpresion = value
					OnPVDOCU_TipoImpresionChanged(m_pvdocu_tipoimpresion, EventArgs.Empty)
				End If
			Else
				m_pvdocu_tipoimpresion = value
				OnPVDOCU_TipoImpresionChanged(m_pvdocu_tipoimpresion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVDOCU_UsrCrea() As String
		Get
			return m_pvdocu_usrcrea
		End Get
		Set(ByVal value As String)
			m_pvdocu_usrcrea = value
		End Set
	End Property

	Public Property PVDOCU_FecCrea() As Date
		Get
			return m_pvdocu_feccrea
		End Get
		Set(ByVal value As Date)
			m_pvdocu_feccrea = value
		End Set
	End Property

	Public Property PVDOCU_UsrMod() As String
		Get
			return m_pvdocu_usrmod
		End Get
		Set(ByVal value As String)
			m_pvdocu_usrmod = value
		End Set
	End Property

	Public Property PVDOCU_FecMod() As Date
		Get
			return m_pvdocu_fecmod
		End Get
		Set(ByVal value As Date)
			m_pvdocu_fecmod = value
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
			Return "VENT_PVentDocumento"
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
	
	Public Event PVDOCU_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event PVDOCU_SerieChanged As EventHandler
	Public Event PVDOCU_AutorizacionChanged As EventHandler
	Public Event PVDOCU_NroLineasChanged As EventHandler
	Public Event PVDOCU_PredeterminadoChanged As EventHandler
	Public Event PVDOCU_PredetBoletaChanged As EventHandler
	Public Event PVDOCU_PredetGuiaRemisTransportistaChanged As EventHandler
	Public Event PVDOCU_PredetGuiaRemisRemitVentasChanged As EventHandler
	Public Event PVDOCU_PredetGuiaRemisRemitTransportistaChanged As EventHandler
	Public Event PVDOCU_DispositivoImpresionChanged As EventHandler
	Public Event PVDOCU_AppChanged As EventHandler
	Public Event PVDOCU_TopChanged As EventHandler
	Public Event PVDOCU_LeftChanged As EventHandler
	Public Event PVDOCU_TipoImpresionChanged As EventHandler

	Public Sub OnPVDOCU_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_IdChanged(sender, e)
	End Sub

	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_SerieChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_AutorizacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_AutorizacionChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_NroLineasChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_NroLineasChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_PredeterminadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_PredeterminadoChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_PredetBoletaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_PredetBoletaChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_PredetGuiaRemisTransportistaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_PredetGuiaRemisTransportistaChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_PredetGuiaRemisRemitVentasChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_PredetGuiaRemisRemitVentasChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_PredetGuiaRemisRemitTransportistaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_PredetGuiaRemisRemitTransportistaChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_DispositivoImpresionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_DispositivoImpresionChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_AppChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_AppChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_TopChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_TopChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_LeftChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_LeftChanged(sender, e)
	End Sub

	Public Sub OnPVDOCU_TipoImpresionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVDOCU_TipoImpresionChanged(sender, e)
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

