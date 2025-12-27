Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_NeumaticosIncidencias

#Region " Campos "
	
	Private m_incnu_id As Long
	Private m_neuma_id As Long
	Private m_viaje_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_docus_codigo As String
	Private m_entid_codigoproveedor As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtipoincidencia As String
	Private m_incnu_descripcion As String
	Private m_incnu_fecha As Date
	Private m_incnu_accionrealizada As String
	Private m_incnu_pago As Double
	Private m_incnu_tiempovidautilperdida As Date
	Private m_incnu_kminicidencia As Double
	Private m_incnu_kmvidautil As Double
	Private m_incnu_estado As String
	Private m_incnu_usrcrea As String
	Private m_incnu_feccrea As Date
	Private m_incnu_usrmod As String
	Private m_incnu_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_NeumaticosIncidencias
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
	
	Public Property INCNU_Id() As Long
		Get
			return m_incnu_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_incnu_id) Then
				If Not m_incnu_id.Equals(value) Then
					m_incnu_id = value
					OnINCNU_IdChanged(m_incnu_id, EventArgs.Empty)
				End If
			Else
				m_incnu_id = value
				OnINCNU_IdChanged(m_incnu_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Id() As Long
		Get
			return m_neuma_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_neuma_id) Then
				If Not m_neuma_id.Equals(value) Then
					m_neuma_id = value
					OnNEUMA_IdChanged(m_neuma_id, EventArgs.Empty)
				End If
			Else
				m_neuma_id = value
				OnNEUMA_IdChanged(m_neuma_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property VIAJE_Id() As Long
		Get
			return m_viaje_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_viaje_id) Then
				If Not m_viaje_id.Equals(value) Then
					m_viaje_id = value
					OnVIAJE_IdChanged(m_viaje_id, EventArgs.Empty)
				End If
			Else
				m_viaje_id = value
				OnVIAJE_IdChanged(m_viaje_id, EventArgs.Empty)
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
	Public Property ENTID_CodigoProveedor() As String
		Get
			return m_entid_codigoproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoproveedor) Then
				If Not m_entid_codigoproveedor.Equals(value) Then
					m_entid_codigoproveedor = value
					OnENTID_CodigoProveedorChanged(m_entid_codigoproveedor, EventArgs.Empty)
				End If
			Else
				m_entid_codigoproveedor = value
				OnENTID_CodigoProveedorChanged(m_entid_codigoproveedor, EventArgs.Empty)
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
	Public Property TIPOS_CodTipoIncidencia() As String
		Get
			return m_tipos_codtipoincidencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipoincidencia) Then
				If Not m_tipos_codtipoincidencia.Equals(value) Then
					m_tipos_codtipoincidencia = value
					OnTIPOS_CodTipoIncidenciaChanged(m_tipos_codtipoincidencia, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipoincidencia = value
				OnTIPOS_CodTipoIncidenciaChanged(m_tipos_codtipoincidencia, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCNU_Descripcion() As String
		Get
			return m_incnu_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_incnu_descripcion) Then
				If Not m_incnu_descripcion.Equals(value) Then
					m_incnu_descripcion = value
					OnINCNU_DescripcionChanged(m_incnu_descripcion, EventArgs.Empty)
				End If
			Else
				m_incnu_descripcion = value
				OnINCNU_DescripcionChanged(m_incnu_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCNU_Fecha() As Date
		Get
			return m_incnu_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_incnu_fecha) Then
				If Not m_incnu_fecha.Equals(value) Then
					m_incnu_fecha = value
					OnINCNU_FechaChanged(m_incnu_fecha, EventArgs.Empty)
				End If
			Else
				m_incnu_fecha = value
				OnINCNU_FechaChanged(m_incnu_fecha, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCNU_AccionRealizada() As String
		Get
			return m_incnu_accionrealizada
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_incnu_accionrealizada) Then
				If Not m_incnu_accionrealizada.Equals(value) Then
					m_incnu_accionrealizada = value
					OnINCNU_AccionRealizadaChanged(m_incnu_accionrealizada, EventArgs.Empty)
				End If
			Else
				m_incnu_accionrealizada = value
				OnINCNU_AccionRealizadaChanged(m_incnu_accionrealizada, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCNU_Pago() As Double
		Get
			return m_incnu_pago
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_incnu_pago) Then
				If Not m_incnu_pago.Equals(value) Then
					m_incnu_pago = value
					OnINCNU_PagoChanged(m_incnu_pago, EventArgs.Empty)
				End If
			Else
				m_incnu_pago = value
				OnINCNU_PagoChanged(m_incnu_pago, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCNU_TiempoVidaUtilPerdida() As Date
		Get
			return m_incnu_tiempovidautilperdida
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_incnu_tiempovidautilperdida) Then
				If Not m_incnu_tiempovidautilperdida.Equals(value) Then
					m_incnu_tiempovidautilperdida = value
					OnINCNU_TiempoVidaUtilPerdidaChanged(m_incnu_tiempovidautilperdida, EventArgs.Empty)
				End If
			Else
				m_incnu_tiempovidautilperdida = value
				OnINCNU_TiempoVidaUtilPerdidaChanged(m_incnu_tiempovidautilperdida, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCNU_KmInicidencia() As Double
		Get
			return m_incnu_kminicidencia
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_incnu_kminicidencia) Then
				If Not m_incnu_kminicidencia.Equals(value) Then
					m_incnu_kminicidencia = value
					OnINCNU_KmInicidenciaChanged(m_incnu_kminicidencia, EventArgs.Empty)
				End If
			Else
				m_incnu_kminicidencia = value
				OnINCNU_KmInicidenciaChanged(m_incnu_kminicidencia, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCNU_KmVidaUtil() As Double
		Get
			return m_incnu_kmvidautil
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_incnu_kmvidautil) Then
				If Not m_incnu_kmvidautil.Equals(value) Then
					m_incnu_kmvidautil = value
					OnINCNU_KmVidaUtilChanged(m_incnu_kmvidautil, EventArgs.Empty)
				End If
			Else
				m_incnu_kmvidautil = value
				OnINCNU_KmVidaUtilChanged(m_incnu_kmvidautil, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCNU_Estado() As String
		Get
			return m_incnu_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_incnu_estado) Then
				If Not m_incnu_estado.Equals(value) Then
					m_incnu_estado = value
					OnINCNU_EstadoChanged(m_incnu_estado, EventArgs.Empty)
				End If
			Else
				m_incnu_estado = value
				OnINCNU_EstadoChanged(m_incnu_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCNU_UsrCrea() As String
		Get
			return m_incnu_usrcrea
		End Get
		Set(ByVal value As String)
			m_incnu_usrcrea = value
		End Set
	End Property
	Public Property INCNU_FecCrea() As Date
		Get
			return m_incnu_feccrea
		End Get
		Set(ByVal value As Date)
			m_incnu_feccrea = value
		End Set
	End Property
	Public Property INCNU_UsrMod() As String
		Get
			return m_incnu_usrmod
		End Get
		Set(ByVal value As String)
			m_incnu_usrmod = value
		End Set
	End Property
	Public Property INCNU_FecMod() As Date
		Get
			return m_incnu_fecmod
		End Get
		Set(ByVal value As Date)
			m_incnu_fecmod = value
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
			Return "TRAN_NeumaticosIncidencias"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event INCNU_IdChanged As EventHandler
	Public Event NEUMA_IdChanged As EventHandler
	Public Event VIAJE_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event DOCUS_CodigoChanged As EventHandler
	Public Event ENTID_CodigoProveedorChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoIncidenciaChanged As EventHandler
	Public Event INCNU_DescripcionChanged As EventHandler
	Public Event INCNU_FechaChanged As EventHandler
	Public Event INCNU_AccionRealizadaChanged As EventHandler
	Public Event INCNU_PagoChanged As EventHandler
	Public Event INCNU_TiempoVidaUtilPerdidaChanged As EventHandler
	Public Event INCNU_KmInicidenciaChanged As EventHandler
	Public Event INCNU_KmVidaUtilChanged As EventHandler
	Public Event INCNU_EstadoChanged As EventHandler
	Public Sub OnINCNU_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCNU_IdChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_IdChanged(sender, e)
	End Sub
	Public Sub OnVIAJE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VIAJE_IdChanged(sender, e)
	End Sub
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnDOCUS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCUS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnENTID_CodigoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoProveedorChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodTipoIncidenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoIncidenciaChanged(sender, e)
	End Sub
	Public Sub OnINCNU_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCNU_DescripcionChanged(sender, e)
	End Sub
	Public Sub OnINCNU_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCNU_FechaChanged(sender, e)
	End Sub
	Public Sub OnINCNU_AccionRealizadaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCNU_AccionRealizadaChanged(sender, e)
	End Sub
	Public Sub OnINCNU_PagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCNU_PagoChanged(sender, e)
	End Sub
	Public Sub OnINCNU_TiempoVidaUtilPerdidaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCNU_TiempoVidaUtilPerdidaChanged(sender, e)
	End Sub
	Public Sub OnINCNU_KmInicidenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCNU_KmInicidenciaChanged(sender, e)
	End Sub
	Public Sub OnINCNU_KmVidaUtilChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCNU_KmVidaUtilChanged(sender, e)
	End Sub
	Public Sub OnINCNU_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCNU_EstadoChanged(sender, e)
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

