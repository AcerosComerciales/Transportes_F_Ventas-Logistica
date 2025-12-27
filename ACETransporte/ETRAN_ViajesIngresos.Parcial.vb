Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_ViajesIngresos

#Region " Campos "
	
	Private m_vingr_id As Long
	Private m_viaje_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_docus_codigo As String
	Private m_entid_codigo As String
	Private m_tipos_codtipomoneda As String
	Private m_flete_id As Long
	Private m_recib_codigo As String
	Private m_vingr_descripcion As String
	Private m_vingr_fecha As Date
	Private m_vingr_monto As Decimal
	Private m_vingr_estado As String
	Private m_vingr_usrcrea As String
	Private m_vingr_feccrea As Date
	Private m_vingr_usrmod As String
	Private m_vingr_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_ViajesIngresos
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
	
	Public Property VINGR_Id() As Long
		Get
			return m_vingr_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vingr_id) Then
				If Not m_vingr_id.Equals(value) Then
					m_vingr_id = value
					OnVINGR_IdChanged(m_vingr_id, EventArgs.Empty)
				End If
			Else
				m_vingr_id = value
				OnVINGR_IdChanged(m_vingr_id, EventArgs.Empty)
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

	Public Property FLETE_Id() As Long
		Get
			return m_flete_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_flete_id) Then
				If Not m_flete_id.Equals(value) Then
					m_flete_id = value
					OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
				End If
			Else
				m_flete_id = value
				OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_Codigo() As String
		Get
			return m_recib_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_recib_codigo) Then
				If Not m_recib_codigo.Equals(value) Then
					m_recib_codigo = value
					OnRECIB_CodigoChanged(m_recib_codigo, EventArgs.Empty)
				End If
			Else
				m_recib_codigo = value
				OnRECIB_CodigoChanged(m_recib_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VINGR_Descripcion() As String
		Get
			return m_vingr_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vingr_descripcion) Then
				If Not m_vingr_descripcion.Equals(value) Then
					m_vingr_descripcion = value
					OnVINGR_DescripcionChanged(m_vingr_descripcion, EventArgs.Empty)
				End If
			Else
				m_vingr_descripcion = value
				OnVINGR_DescripcionChanged(m_vingr_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VINGR_Fecha() As Date
		Get
			return m_vingr_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_vingr_fecha) Then
				If Not m_vingr_fecha.Equals(value) Then
					m_vingr_fecha = value
					OnVINGR_FechaChanged(m_vingr_fecha, EventArgs.Empty)
				End If
			Else
				m_vingr_fecha = value
				OnVINGR_FechaChanged(m_vingr_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VINGR_Monto() As Decimal
		Get
			return m_vingr_monto
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_vingr_monto) Then
				If Not m_vingr_monto.Equals(value) Then
					m_vingr_monto = value
					OnVINGR_MontoChanged(m_vingr_monto, EventArgs.Empty)
				End If
			Else
				m_vingr_monto = value
				OnVINGR_MontoChanged(m_vingr_monto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VINGR_Estado() As String
		Get
			return m_vingr_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vingr_estado) Then
				If Not m_vingr_estado.Equals(value) Then
					m_vingr_estado = value
					OnVINGR_EstadoChanged(m_vingr_estado, EventArgs.Empty)
				End If
			Else
				m_vingr_estado = value
				OnVINGR_EstadoChanged(m_vingr_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VINGR_UsrCrea() As String
		Get
			return m_vingr_usrcrea
		End Get
		Set(ByVal value As String)
			m_vingr_usrcrea = value
		End Set
	End Property

	Public Property VINGR_FecCrea() As Date
		Get
			return m_vingr_feccrea
		End Get
		Set(ByVal value As Date)
			m_vingr_feccrea = value
		End Set
	End Property

	Public Property VINGR_UsrMod() As String
		Get
			return m_vingr_usrmod
		End Get
		Set(ByVal value As String)
			m_vingr_usrmod = value
		End Set
	End Property

	Public Property VINGR_FecMod() As Date
		Get
			return m_vingr_fecmod
		End Get
		Set(ByVal value As Date)
			m_vingr_fecmod = value
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
			Return "TRAN_ViajesIngresos"
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
	
	Public Event VINGR_IdChanged As EventHandler
	Public Event VIAJE_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event DOCUS_CodigoChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event FLETE_IdChanged As EventHandler
	Public Event RECIB_CodigoChanged As EventHandler
	Public Event VINGR_DescripcionChanged As EventHandler
	Public Event VINGR_FechaChanged As EventHandler
	Public Event VINGR_MontoChanged As EventHandler
	Public Event VINGR_EstadoChanged As EventHandler

	Public Sub OnVINGR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VINGR_IdChanged(sender, e)
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

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnFLETE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent FLETE_IdChanged(sender, e)
	End Sub

	Public Sub OnRECIB_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_CodigoChanged(sender, e)
	End Sub

	Public Sub OnVINGR_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VINGR_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnVINGR_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VINGR_FechaChanged(sender, e)
	End Sub

	Public Sub OnVINGR_MontoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VINGR_MontoChanged(sender, e)
	End Sub

	Public Sub OnVINGR_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VINGR_EstadoChanged(sender, e)
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

