Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Vehiculos

#Region " Campos "
	
	Private m_vehic_id As Long
	Private m_pvent_id As Long
	Private m_tipos_codtipocombustible As String
	Private m_tipos_codtipovehiculo As String
	Private m_tipos_codmarca As String
	Private m_entid_codigotransportista As String
	Private m_vehic_codigo As String
	Private m_vehic_modelo As String
	Private m_vehic_fecadquisicion As Date
	Private m_vehic_placa As String
	Private m_vehic_nroneumaticos As Short
	Private m_vehic_numeroejes As Short
	Private m_vehic_kmactual As Decimal
	Private m_vehic_kminicial As Decimal
	Private m_vehic_certificado As String
	Private m_vehic_combustible As Decimal
	Private m_vehic_estado As String
	Private m_vehic_estadoviaje As String
	Private m_vehic_generaviajes As Boolean
	Private m_vehic_cargamax As Decimal
	Private m_vehic_placaadic As String
	Private m_vehic_certificadoadic As String
	Private m_vehic_codbusqueda As Integer
	Private m_vehic_usrcrea As String
	Private m_vehic_feccrea As Date
	Private m_vehic_usrmod As String
	Private m_vehic_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_Vehiculos
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
	
	Public Property VEHIC_Id() As Long
		Get
			return m_vehic_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vehic_id) Then
				If Not m_vehic_id.Equals(value) Then
					m_vehic_id = value
					OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
				End If
			Else
				m_vehic_id = value
				OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
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

	Public Property TIPOS_CodTipoCombustible() As String
		Get
			return m_tipos_codtipocombustible
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipocombustible) Then
				If Not m_tipos_codtipocombustible.Equals(value) Then
					m_tipos_codtipocombustible = value
					OnTIPOS_CodTipoCombustibleChanged(m_tipos_codtipocombustible, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipocombustible = value
				OnTIPOS_CodTipoCombustibleChanged(m_tipos_codtipocombustible, EventArgs.Empty)
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

	Public Property ENTID_CodigoTransportista() As String
		Get
			return m_entid_codigotransportista
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigotransportista) Then
				If Not m_entid_codigotransportista.Equals(value) Then
					m_entid_codigotransportista = value
					OnENTID_CodigoTransportistaChanged(m_entid_codigotransportista, EventArgs.Empty)
				End If
			Else
				m_entid_codigotransportista = value
				OnENTID_CodigoTransportistaChanged(m_entid_codigotransportista, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_Codigo() As String
		Get
			return m_vehic_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehic_codigo) Then
				If Not m_vehic_codigo.Equals(value) Then
					m_vehic_codigo = value
					OnVEHIC_CodigoChanged(m_vehic_codigo, EventArgs.Empty)
				End If
			Else
				m_vehic_codigo = value
				OnVEHIC_CodigoChanged(m_vehic_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_Modelo() As String
		Get
			return m_vehic_modelo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehic_modelo) Then
				If Not m_vehic_modelo.Equals(value) Then
					m_vehic_modelo = value
					OnVEHIC_ModeloChanged(m_vehic_modelo, EventArgs.Empty)
				End If
			Else
				m_vehic_modelo = value
				OnVEHIC_ModeloChanged(m_vehic_modelo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_FecAdquisicion() As Date
		Get
			return m_vehic_fecadquisicion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_vehic_fecadquisicion) Then
				If Not m_vehic_fecadquisicion.Equals(value) Then
					m_vehic_fecadquisicion = value
					OnVEHIC_FecAdquisicionChanged(m_vehic_fecadquisicion, EventArgs.Empty)
				End If
			Else
				m_vehic_fecadquisicion = value
				OnVEHIC_FecAdquisicionChanged(m_vehic_fecadquisicion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_Placa() As String
		Get
			return m_vehic_placa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehic_placa) Then
				If Not m_vehic_placa.Equals(value) Then
					m_vehic_placa = value
					OnVEHIC_PlacaChanged(m_vehic_placa, EventArgs.Empty)
				End If
			Else
				m_vehic_placa = value
				OnVEHIC_PlacaChanged(m_vehic_placa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_NroNeumaticos() As Short
		Get
			return m_vehic_nroneumaticos
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_vehic_nroneumaticos) Then
				If Not m_vehic_nroneumaticos.Equals(value) Then
					m_vehic_nroneumaticos = value
					OnVEHIC_NroNeumaticosChanged(m_vehic_nroneumaticos, EventArgs.Empty)
				End If
			Else
				m_vehic_nroneumaticos = value
				OnVEHIC_NroNeumaticosChanged(m_vehic_nroneumaticos, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_NumeroEjes() As Short
		Get
			return m_vehic_numeroejes
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_vehic_numeroejes) Then
				If Not m_vehic_numeroejes.Equals(value) Then
					m_vehic_numeroejes = value
					OnVEHIC_NumeroEjesChanged(m_vehic_numeroejes, EventArgs.Empty)
				End If
			Else
				m_vehic_numeroejes = value
				OnVEHIC_NumeroEjesChanged(m_vehic_numeroejes, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_KmActual() As Decimal
		Get
			return m_vehic_kmactual
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_vehic_kmactual) Then
				If Not m_vehic_kmactual.Equals(value) Then
					m_vehic_kmactual = value
					OnVEHIC_KmActualChanged(m_vehic_kmactual, EventArgs.Empty)
				End If
			Else
				m_vehic_kmactual = value
				OnVEHIC_KmActualChanged(m_vehic_kmactual, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_KmInicial() As Decimal
		Get
			return m_vehic_kminicial
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_vehic_kminicial) Then
				If Not m_vehic_kminicial.Equals(value) Then
					m_vehic_kminicial = value
					OnVEHIC_KmInicialChanged(m_vehic_kminicial, EventArgs.Empty)
				End If
			Else
				m_vehic_kminicial = value
				OnVEHIC_KmInicialChanged(m_vehic_kminicial, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_Certificado() As String
		Get
			return m_vehic_certificado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehic_certificado) Then
				If Not m_vehic_certificado.Equals(value) Then
					m_vehic_certificado = value
					OnVEHIC_CertificadoChanged(m_vehic_certificado, EventArgs.Empty)
				End If
			Else
				m_vehic_certificado = value
				OnVEHIC_CertificadoChanged(m_vehic_certificado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_Combustible() As Decimal
		Get
			return m_vehic_combustible
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_vehic_combustible) Then
				If Not m_vehic_combustible.Equals(value) Then
					m_vehic_combustible = value
					OnVEHIC_CombustibleChanged(m_vehic_combustible, EventArgs.Empty)
				End If
			Else
				m_vehic_combustible = value
				OnVEHIC_CombustibleChanged(m_vehic_combustible, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_Estado() As String
		Get
			return m_vehic_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehic_estado) Then
				If Not m_vehic_estado.Equals(value) Then
					m_vehic_estado = value
					OnVEHIC_EstadoChanged(m_vehic_estado, EventArgs.Empty)
				End If
			Else
				m_vehic_estado = value
				OnVEHIC_EstadoChanged(m_vehic_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_EstadoViaje() As String
		Get
			return m_vehic_estadoviaje
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehic_estadoviaje) Then
				If Not m_vehic_estadoviaje.Equals(value) Then
					m_vehic_estadoviaje = value
					OnVEHIC_EstadoViajeChanged(m_vehic_estadoviaje, EventArgs.Empty)
				End If
			Else
				m_vehic_estadoviaje = value
				OnVEHIC_EstadoViajeChanged(m_vehic_estadoviaje, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_GeneraViajes() As Boolean
		Get
			return m_vehic_generaviajes
		End Get
		Set(ByVal value As Boolean)
			If Not m_vehic_generaviajes.Equals(value) Then
				m_vehic_generaviajes = value
				OnVEHIC_GeneraViajesChanged(m_vehic_generaviajes, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_CargaMax() As Decimal
		Get
			return m_vehic_cargamax
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_vehic_cargamax) Then
				If Not m_vehic_cargamax.Equals(value) Then
					m_vehic_cargamax = value
					OnVEHIC_CargaMaxChanged(m_vehic_cargamax, EventArgs.Empty)
				End If
			Else
				m_vehic_cargamax = value
				OnVEHIC_CargaMaxChanged(m_vehic_cargamax, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_PlacaAdic() As String
		Get
			return m_vehic_placaadic
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehic_placaadic) Then
				If Not m_vehic_placaadic.Equals(value) Then
					m_vehic_placaadic = value
					OnVEHIC_PlacaAdicChanged(m_vehic_placaadic, EventArgs.Empty)
				End If
			Else
				m_vehic_placaadic = value
				OnVEHIC_PlacaAdicChanged(m_vehic_placaadic, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_CertificadoAdic() As String
		Get
			return m_vehic_certificadoadic
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vehic_certificadoadic) Then
				If Not m_vehic_certificadoadic.Equals(value) Then
					m_vehic_certificadoadic = value
					OnVEHIC_CertificadoAdicChanged(m_vehic_certificadoadic, EventArgs.Empty)
				End If
			Else
				m_vehic_certificadoadic = value
				OnVEHIC_CertificadoAdicChanged(m_vehic_certificadoadic, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_CodBusqueda() As Integer
		Get
			return m_vehic_codbusqueda
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_vehic_codbusqueda) Then
				If Not m_vehic_codbusqueda.Equals(value) Then
					m_vehic_codbusqueda = value
					OnVEHIC_CodBusquedaChanged(m_vehic_codbusqueda, EventArgs.Empty)
				End If
			Else
				m_vehic_codbusqueda = value
				OnVEHIC_CodBusquedaChanged(m_vehic_codbusqueda, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VEHIC_UsrCrea() As String
		Get
			return m_vehic_usrcrea
		End Get
		Set(ByVal value As String)
			m_vehic_usrcrea = value
		End Set
	End Property

	Public Property VEHIC_FecCrea() As Date
		Get
			return m_vehic_feccrea
		End Get
		Set(ByVal value As Date)
			m_vehic_feccrea = value
		End Set
	End Property

	Public Property VEHIC_UsrMod() As String
		Get
			return m_vehic_usrmod
		End Get
		Set(ByVal value As String)
			m_vehic_usrmod = value
		End Set
	End Property

	Public Property VEHIC_FecMod() As Date
		Get
			return m_vehic_fecmod
		End Get
		Set(ByVal value As Date)
			m_vehic_fecmod = value
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
			Return "TRAN_Vehiculos"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event VEHIC_IdChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event TIPOS_CodTipoCombustibleChanged As EventHandler
	Public Event TIPOS_CodTipoVehiculoChanged As EventHandler
	Public Event TIPOS_CodMarcaChanged As EventHandler
	Public Event ENTID_CodigoTransportistaChanged As EventHandler
	Public Event VEHIC_CodigoChanged As EventHandler
	Public Event VEHIC_ModeloChanged As EventHandler
	Public Event VEHIC_FecAdquisicionChanged As EventHandler
	Public Event VEHIC_PlacaChanged As EventHandler
	Public Event VEHIC_NroNeumaticosChanged As EventHandler
	Public Event VEHIC_NumeroEjesChanged As EventHandler
	Public Event VEHIC_KmActualChanged As EventHandler
	Public Event VEHIC_KmInicialChanged As EventHandler
	Public Event VEHIC_CertificadoChanged As EventHandler
	Public Event VEHIC_CombustibleChanged As EventHandler
	Public Event VEHIC_EstadoChanged As EventHandler
	Public Event VEHIC_EstadoViajeChanged As EventHandler
	Public Event VEHIC_GeneraViajesChanged As EventHandler
	Public Event VEHIC_CargaMaxChanged As EventHandler
	Public Event VEHIC_PlacaAdicChanged As EventHandler
	Public Event VEHIC_CertificadoAdicChanged As EventHandler
	Public Event VEHIC_CodBusquedaChanged As EventHandler

	Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoCombustibleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoCombustibleChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoVehiculoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoVehiculoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodMarcaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodMarcaChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoTransportistaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoTransportistaChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_ModeloChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_ModeloChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_FecAdquisicionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_FecAdquisicionChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_PlacaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_PlacaChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_NroNeumaticosChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_NroNeumaticosChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_NumeroEjesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_NumeroEjesChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_KmActualChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_KmActualChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_KmInicialChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_KmInicialChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_CertificadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_CertificadoChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_CombustibleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_CombustibleChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_EstadoChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_EstadoViajeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_EstadoViajeChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_GeneraViajesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_GeneraViajesChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_CargaMaxChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_CargaMaxChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_PlacaAdicChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_PlacaAdicChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_CertificadoAdicChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_CertificadoAdicChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_CodBusquedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_CodBusquedaChanged(sender, e)
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

