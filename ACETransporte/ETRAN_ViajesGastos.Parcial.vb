Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_ViajesGastos

#Region " Campos "
	
	Private m_vgast_id As Long
	Private m_viaje_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_docus_codigo As String
	Private m_entid_codigoproveedor As String
	Private m_tipos_codtipogasto As String
	Private m_tipos_codtipomoneda As String
	Private m_vgast_descripcion As String
	Private m_vgast_fecha As Date
	Private m_vgast_monto As Decimal
	Private m_vgast_comprobantes As Boolean
	Private m_vgast_estado As String
	Private m_vgast_fechaviaje As Date
	Private m_vgast_usrcrea As String
	Private m_vgast_feccrea As Date
	Private m_vgast_usrmod As String
	Private m_vgast_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_ViajesGastos
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
	
	Public Property VGAST_Id() As Long
		Get
			return m_vgast_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vgast_id) Then
				If Not m_vgast_id.Equals(value) Then
					m_vgast_id = value
					OnVGAST_IdChanged(m_vgast_id, EventArgs.Empty)
				End If
			Else
				m_vgast_id = value
				OnVGAST_IdChanged(m_vgast_id, EventArgs.Empty)
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

	Public Property TIPOS_CodTipoGasto() As String
		Get
			return m_tipos_codtipogasto
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipogasto) Then
				If Not m_tipos_codtipogasto.Equals(value) Then
					m_tipos_codtipogasto = value
					OnTIPOS_CodTipoGastoChanged(m_tipos_codtipogasto, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipogasto = value
				OnTIPOS_CodTipoGastoChanged(m_tipos_codtipogasto, EventArgs.Empty)
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

	Public Property VGAST_Descripcion() As String
		Get
			return m_vgast_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vgast_descripcion) Then
				If Not m_vgast_descripcion.Equals(value) Then
					m_vgast_descripcion = value
					OnVGAST_DescripcionChanged(m_vgast_descripcion, EventArgs.Empty)
				End If
			Else
				m_vgast_descripcion = value
				OnVGAST_DescripcionChanged(m_vgast_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VGAST_Fecha() As Date
		Get
			return m_vgast_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_vgast_fecha) Then
				If Not m_vgast_fecha.Equals(value) Then
					m_vgast_fecha = value
					OnVGAST_FechaChanged(m_vgast_fecha, EventArgs.Empty)
				End If
			Else
				m_vgast_fecha = value
				OnVGAST_FechaChanged(m_vgast_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VGAST_Monto() As Decimal
		Get
			return m_vgast_monto
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_vgast_monto) Then
				If Not m_vgast_monto.Equals(value) Then
					m_vgast_monto = value
					OnVGAST_MontoChanged(m_vgast_monto, EventArgs.Empty)
				End If
			Else
				m_vgast_monto = value
				OnVGAST_MontoChanged(m_vgast_monto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VGAST_Comprobantes() As Boolean
		Get
			return m_vgast_comprobantes
		End Get
		Set(ByVal value As Boolean)
			If Not m_vgast_comprobantes.Equals(value) Then
				m_vgast_comprobantes = value
				OnVGAST_ComprobantesChanged(m_vgast_comprobantes, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VGAST_Estado() As String
		Get
			return m_vgast_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vgast_estado) Then
				If Not m_vgast_estado.Equals(value) Then
					m_vgast_estado = value
					OnVGAST_EstadoChanged(m_vgast_estado, EventArgs.Empty)
				End If
			Else
				m_vgast_estado = value
				OnVGAST_EstadoChanged(m_vgast_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VGAST_FechaViaje() As Date
		Get
			return m_vgast_fechaviaje
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_vgast_fechaviaje) Then
				If Not m_vgast_fechaviaje.Equals(value) Then
					m_vgast_fechaviaje = value
					OnVGAST_FechaViajeChanged(m_vgast_fechaviaje, EventArgs.Empty)
				End If
			Else
				m_vgast_fechaviaje = value
				OnVGAST_FechaViajeChanged(m_vgast_fechaviaje, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VGAST_UsrCrea() As String
		Get
			return m_vgast_usrcrea
		End Get
		Set(ByVal value As String)
			m_vgast_usrcrea = value
		End Set
	End Property

	Public Property VGAST_FecCrea() As Date
		Get
			return m_vgast_feccrea
		End Get
		Set(ByVal value As Date)
			m_vgast_feccrea = value
		End Set
	End Property

	Public Property VGAST_UsrMod() As String
		Get
			return m_vgast_usrmod
		End Get
		Set(ByVal value As String)
			m_vgast_usrmod = value
		End Set
	End Property

	Public Property VGAST_FecMod() As Date
		Get
			return m_vgast_fecmod
		End Get
		Set(ByVal value As Date)
			m_vgast_fecmod = value
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
			Return "TRAN_ViajesGastos"
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
	
	Public Event VGAST_IdChanged As EventHandler
	Public Event VIAJE_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event DOCUS_CodigoChanged As EventHandler
	Public Event ENTID_CodigoProveedorChanged As EventHandler
	Public Event TIPOS_CodTipoGastoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event VGAST_DescripcionChanged As EventHandler
	Public Event VGAST_FechaChanged As EventHandler
	Public Event VGAST_MontoChanged As EventHandler
	Public Event VGAST_ComprobantesChanged As EventHandler
	Public Event VGAST_EstadoChanged As EventHandler
	Public Event VGAST_FechaViajeChanged As EventHandler

	Public Sub OnVGAST_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VGAST_IdChanged(sender, e)
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

	Public Sub OnTIPOS_CodTipoGastoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoGastoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnVGAST_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VGAST_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnVGAST_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VGAST_FechaChanged(sender, e)
	End Sub

	Public Sub OnVGAST_MontoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VGAST_MontoChanged(sender, e)
	End Sub

	Public Sub OnVGAST_ComprobantesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VGAST_ComprobantesChanged(sender, e)
	End Sub

	Public Sub OnVGAST_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VGAST_EstadoChanged(sender, e)
	End Sub

	Public Sub OnVGAST_FechaViajeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VGAST_FechaViajeChanged(sender, e)
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

