Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Neumaticos

#Region " Campos "
	
	Private m_neuma_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_tipos_codmoneda As String
	Private m_tipos_codmarca As String
	Private m_tipos_codtipollanta As String
	Private m_tipos_codtipovehiculo As String
	Private m_neuma_codigo As String
	Private m_neuma_feccompra As Date
	Private m_neuma_modelo As String
	Private m_neuma_fechagarantia As Date
	Private m_neuma_precio As Decimal
	Private m_neuma_tiempovidautil As Date
	Private m_neuma_kmvidautil As Decimal
	Private m_neuma_tamano As String
	Private m_neuma_km As Decimal
	Private m_neuma_reencauches As Short
	Private m_neuma_parches As Short
	Private m_neuma_nroposicion As Short
	Private m_neuma_estado As String
	Private m_neuma_usrcrea As String
	Private m_neuma_feccrea As Date
	Private m_neuma_usrmod As String
	Private m_neuma_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_Neumaticos
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
	Public Property TIPOS_CodMoneda() As String
		Get
			return m_tipos_codmoneda
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codmoneda) Then
				If Not m_tipos_codmoneda.Equals(value) Then
					m_tipos_codmoneda = value
					OnTIPOS_CodMonedaChanged(m_tipos_codmoneda, EventArgs.Empty)
				End If
			Else
				m_tipos_codmoneda = value
				OnTIPOS_CodMonedaChanged(m_tipos_codmoneda, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property TIPOS_CodMarca() As String
		Get
			return m_tipos_codmarca
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codmarca) Then
				If Not m_tipos_codmarca.Equals(value) Then
					m_tipos_codmarca = value
					OnTIPOS_CodMarcaChanged(m_tipos_codmarca, EventArgs.Empty)
				End If
			Else
				m_tipos_codmarca = value
				OnTIPOS_CodMarcaChanged(m_tipos_codmarca, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property TIPOS_CodTipoLlanta() As String
		Get
			return m_tipos_codtipollanta
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipollanta) Then
				If Not m_tipos_codtipollanta.Equals(value) Then
					m_tipos_codtipollanta = value
					OnTIPOS_CodTipoLlantaChanged(m_tipos_codtipollanta, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipollanta = value
				OnTIPOS_CodTipoLlantaChanged(m_tipos_codtipollanta, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property TIPOS_CodTipoVehiculo() As String
		Get
			return m_tipos_codtipovehiculo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipovehiculo) Then
				If Not m_tipos_codtipovehiculo.Equals(value) Then
					m_tipos_codtipovehiculo = value
					OnTIPOS_CodTipoVehiculoChanged(m_tipos_codtipovehiculo, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipovehiculo = value
				OnTIPOS_CodTipoVehiculoChanged(m_tipos_codtipovehiculo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Codigo() As String
		Get
			return m_neuma_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_neuma_codigo) Then
				If Not m_neuma_codigo.Equals(value) Then
					m_neuma_codigo = value
					OnNEUMA_CodigoChanged(m_neuma_codigo, EventArgs.Empty)
				End If
			Else
				m_neuma_codigo = value
				OnNEUMA_CodigoChanged(m_neuma_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_FecCompra() As Date
		Get
			return m_neuma_feccompra
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_neuma_feccompra) Then
				If Not m_neuma_feccompra.Equals(value) Then
					m_neuma_feccompra = value
					OnNEUMA_FecCompraChanged(m_neuma_feccompra, EventArgs.Empty)
				End If
			Else
				m_neuma_feccompra = value
				OnNEUMA_FecCompraChanged(m_neuma_feccompra, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Modelo() As String
		Get
			return m_neuma_modelo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_neuma_modelo) Then
				If Not m_neuma_modelo.Equals(value) Then
					m_neuma_modelo = value
					OnNEUMA_ModeloChanged(m_neuma_modelo, EventArgs.Empty)
				End If
			Else
				m_neuma_modelo = value
				OnNEUMA_ModeloChanged(m_neuma_modelo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_FechaGarantia() As Date
		Get
			return m_neuma_fechagarantia
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_neuma_fechagarantia) Then
				If Not m_neuma_fechagarantia.Equals(value) Then
					m_neuma_fechagarantia = value
					OnNEUMA_FechaGarantiaChanged(m_neuma_fechagarantia, EventArgs.Empty)
				End If
			Else
				m_neuma_fechagarantia = value
				OnNEUMA_FechaGarantiaChanged(m_neuma_fechagarantia, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Precio() As Decimal
		Get
			return m_neuma_precio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_neuma_precio) Then
				If Not m_neuma_precio.Equals(value) Then
					m_neuma_precio = value
					OnNEUMA_PrecioChanged(m_neuma_precio, EventArgs.Empty)
				End If
			Else
				m_neuma_precio = value
				OnNEUMA_PrecioChanged(m_neuma_precio, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_TiempoVidaUtil() As Date
		Get
			return m_neuma_tiempovidautil
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_neuma_tiempovidautil) Then
				If Not m_neuma_tiempovidautil.Equals(value) Then
					m_neuma_tiempovidautil = value
					OnNEUMA_TiempoVidaUtilChanged(m_neuma_tiempovidautil, EventArgs.Empty)
				End If
			Else
				m_neuma_tiempovidautil = value
				OnNEUMA_TiempoVidaUtilChanged(m_neuma_tiempovidautil, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_KmVidaUtil() As Decimal
		Get
			return m_neuma_kmvidautil
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_neuma_kmvidautil) Then
				If Not m_neuma_kmvidautil.Equals(value) Then
					m_neuma_kmvidautil = value
					OnNEUMA_KmVidaUtilChanged(m_neuma_kmvidautil, EventArgs.Empty)
				End If
			Else
				m_neuma_kmvidautil = value
				OnNEUMA_KmVidaUtilChanged(m_neuma_kmvidautil, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Tamano() As String
		Get
			return m_neuma_tamano
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_neuma_tamano) Then
				If Not m_neuma_tamano.Equals(value) Then
					m_neuma_tamano = value
					OnNEUMA_TamanoChanged(m_neuma_tamano, EventArgs.Empty)
				End If
			Else
				m_neuma_tamano = value
				OnNEUMA_TamanoChanged(m_neuma_tamano, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Km() As Decimal
		Get
			return m_neuma_km
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_neuma_km) Then
				If Not m_neuma_km.Equals(value) Then
					m_neuma_km = value
					OnNEUMA_KmChanged(m_neuma_km, EventArgs.Empty)
				End If
			Else
				m_neuma_km = value
				OnNEUMA_KmChanged(m_neuma_km, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Reencauches() As Short
		Get
			return m_neuma_reencauches
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_neuma_reencauches) Then
				If Not m_neuma_reencauches.Equals(value) Then
					m_neuma_reencauches = value
					OnNEUMA_ReencauchesChanged(m_neuma_reencauches, EventArgs.Empty)
				End If
			Else
				m_neuma_reencauches = value
				OnNEUMA_ReencauchesChanged(m_neuma_reencauches, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Parches() As Short
		Get
			return m_neuma_parches
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_neuma_parches) Then
				If Not m_neuma_parches.Equals(value) Then
					m_neuma_parches = value
					OnNEUMA_ParchesChanged(m_neuma_parches, EventArgs.Empty)
				End If
			Else
				m_neuma_parches = value
				OnNEUMA_ParchesChanged(m_neuma_parches, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_NroPosicion() As Short
		Get
			return m_neuma_nroposicion
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_neuma_nroposicion) Then
				If Not m_neuma_nroposicion.Equals(value) Then
					m_neuma_nroposicion = value
					OnNEUMA_NroPosicionChanged(m_neuma_nroposicion, EventArgs.Empty)
				End If
			Else
				m_neuma_nroposicion = value
				OnNEUMA_NroPosicionChanged(m_neuma_nroposicion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_Estado() As String
		Get
			return m_neuma_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_neuma_estado) Then
				If Not m_neuma_estado.Equals(value) Then
					m_neuma_estado = value
					OnNEUMA_EstadoChanged(m_neuma_estado, EventArgs.Empty)
				End If
			Else
				m_neuma_estado = value
				OnNEUMA_EstadoChanged(m_neuma_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property NEUMA_UsrCrea() As String
		Get
			return m_neuma_usrcrea
		End Get
		Set(ByVal value As String)
			m_neuma_usrcrea = value
		End Set
	End Property
	Public Property NEUMA_FecCrea() As Date
		Get
			return m_neuma_feccrea
		End Get
		Set(ByVal value As Date)
			m_neuma_feccrea = value
		End Set
	End Property
	Public Property NEUMA_UsrMod() As String
		Get
			return m_neuma_usrmod
		End Get
		Set(ByVal value As String)
			m_neuma_usrmod = value
		End Set
	End Property
	Public Property NEUMA_FecMod() As Date
		Get
			return m_neuma_fecmod
		End Get
		Set(ByVal value As Date)
			m_neuma_fecmod = value
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
			Return "TRAN_Neumaticos"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event NEUMA_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event TIPOS_CodMonedaChanged As EventHandler
	Public Event TIPOS_CodMarcaChanged As EventHandler
	Public Event TIPOS_CodTipoLlantaChanged As EventHandler
	Public Event TIPOS_CodTipoVehiculoChanged As EventHandler
	Public Event NEUMA_CodigoChanged As EventHandler
	Public Event NEUMA_FecCompraChanged As EventHandler
	Public Event NEUMA_ModeloChanged As EventHandler
	Public Event NEUMA_FechaGarantiaChanged As EventHandler
	Public Event NEUMA_PrecioChanged As EventHandler
	Public Event NEUMA_TiempoVidaUtilChanged As EventHandler
	Public Event NEUMA_KmVidaUtilChanged As EventHandler
	Public Event NEUMA_TamanoChanged As EventHandler
	Public Event NEUMA_KmChanged As EventHandler
	Public Event NEUMA_ReencauchesChanged As EventHandler
	Public Event NEUMA_ParchesChanged As EventHandler
	Public Event NEUMA_NroPosicionChanged As EventHandler
	Public Event NEUMA_EstadoChanged As EventHandler
	Public Sub OnNEUMA_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_IdChanged(sender, e)
	End Sub
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodMonedaChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodMarcaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodMarcaChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodTipoLlantaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoLlantaChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodTipoVehiculoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoVehiculoChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_CodigoChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_FecCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_FecCompraChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_ModeloChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_ModeloChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_FechaGarantiaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_FechaGarantiaChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_PrecioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_PrecioChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_TiempoVidaUtilChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_TiempoVidaUtilChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_KmVidaUtilChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_KmVidaUtilChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_TamanoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_TamanoChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_KmChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_KmChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_ReencauchesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_ReencauchesChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_ParchesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_ParchesChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_NroPosicionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_NroPosicionChanged(sender, e)
	End Sub
	Public Sub OnNEUMA_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent NEUMA_EstadoChanged(sender, e)
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

