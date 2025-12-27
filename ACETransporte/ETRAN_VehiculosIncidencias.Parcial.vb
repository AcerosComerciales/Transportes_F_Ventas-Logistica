Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_VehiculosIncidencias

#Region " Campos "
	
	Private m_incve_id As Long
	Private m_viaje_id As Long
	Private m_vehic_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_docus_codigo As String
	Private m_entid_codigoproveedor As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtipoincidencia As String
	Private m_incve_descripcion As String
	Private m_incve_fecha As Date
	Private m_incve_accionrealizada As String
	Private m_incve_pago As Double
	Private m_incve_estado As String
	Private m_incve_usrcrea As String
	Private m_incve_feccrea As Date
	Private m_incve_usrmod As String
	Private m_incve_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_VehiculosIncidencias
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
	
	Public Property INCVE_Id() As Long
		Get
			return m_incve_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_incve_id) Then
				If Not m_incve_id.Equals(value) Then
					m_incve_id = value
					OnINCVE_IdChanged(m_incve_id, EventArgs.Empty)
				End If
			Else
				m_incve_id = value
				OnINCVE_IdChanged(m_incve_id, EventArgs.Empty)
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
	Public Property INCVE_Descripcion() As String
		Get
			return m_incve_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_incve_descripcion) Then
				If Not m_incve_descripcion.Equals(value) Then
					m_incve_descripcion = value
					OnINCVE_DescripcionChanged(m_incve_descripcion, EventArgs.Empty)
				End If
			Else
				m_incve_descripcion = value
				OnINCVE_DescripcionChanged(m_incve_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCVE_Fecha() As Date
		Get
			return m_incve_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_incve_fecha) Then
				If Not m_incve_fecha.Equals(value) Then
					m_incve_fecha = value
					OnINCVE_FechaChanged(m_incve_fecha, EventArgs.Empty)
				End If
			Else
				m_incve_fecha = value
				OnINCVE_FechaChanged(m_incve_fecha, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCVE_AccionRealizada() As String
		Get
			return m_incve_accionrealizada
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_incve_accionrealizada) Then
				If Not m_incve_accionrealizada.Equals(value) Then
					m_incve_accionrealizada = value
					OnINCVE_AccionRealizadaChanged(m_incve_accionrealizada, EventArgs.Empty)
				End If
			Else
				m_incve_accionrealizada = value
				OnINCVE_AccionRealizadaChanged(m_incve_accionrealizada, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCVE_Pago() As Double
		Get
			return m_incve_pago
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_incve_pago) Then
				If Not m_incve_pago.Equals(value) Then
					m_incve_pago = value
					OnINCVE_PagoChanged(m_incve_pago, EventArgs.Empty)
				End If
			Else
				m_incve_pago = value
				OnINCVE_PagoChanged(m_incve_pago, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCVE_Estado() As String
		Get
			return m_incve_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_incve_estado) Then
				If Not m_incve_estado.Equals(value) Then
					m_incve_estado = value
					OnINCVE_EstadoChanged(m_incve_estado, EventArgs.Empty)
				End If
			Else
				m_incve_estado = value
				OnINCVE_EstadoChanged(m_incve_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property INCVE_UsrCrea() As String
		Get
			return m_incve_usrcrea
		End Get
		Set(ByVal value As String)
			m_incve_usrcrea = value
		End Set
	End Property
	Public Property INCVE_FecCrea() As Date
		Get
			return m_incve_feccrea
		End Get
		Set(ByVal value As Date)
			m_incve_feccrea = value
		End Set
	End Property
	Public Property INCVE_UsrMod() As String
		Get
			return m_incve_usrmod
		End Get
		Set(ByVal value As String)
			m_incve_usrmod = value
		End Set
	End Property
	Public Property INCVE_FecMod() As Date
		Get
			return m_incve_fecmod
		End Get
		Set(ByVal value As Date)
			m_incve_fecmod = value
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
			Return "TRAN_VehiculosIncidencias"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event INCVE_IdChanged As EventHandler
	Public Event VIAJE_IdChanged As EventHandler
	Public Event VEHIC_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event DOCUS_CodigoChanged As EventHandler
	Public Event ENTID_CodigoProveedorChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoIncidenciaChanged As EventHandler
	Public Event INCVE_DescripcionChanged As EventHandler
	Public Event INCVE_FechaChanged As EventHandler
	Public Event INCVE_AccionRealizadaChanged As EventHandler
	Public Event INCVE_PagoChanged As EventHandler
	Public Event INCVE_EstadoChanged As EventHandler
	Public Sub OnINCVE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCVE_IdChanged(sender, e)
	End Sub
	Public Sub OnVIAJE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VIAJE_IdChanged(sender, e)
	End Sub
	Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
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
	Public Sub OnINCVE_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCVE_DescripcionChanged(sender, e)
	End Sub
	Public Sub OnINCVE_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCVE_FechaChanged(sender, e)
	End Sub
	Public Sub OnINCVE_AccionRealizadaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCVE_AccionRealizadaChanged(sender, e)
	End Sub
	Public Sub OnINCVE_PagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCVE_PagoChanged(sender, e)
	End Sub
	Public Sub OnINCVE_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent INCVE_EstadoChanged(sender, e)
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

