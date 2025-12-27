Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_OrdenesTransportes

#Region " Campos "
	
	Private m_ordtr_codigo As String
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_cotiz_codigo As String
	Private m_entid_codigo As String
	Private m_rutas_id As Long
	Private m_ordtr_id As Long
	Private m_ordtr_numero As Integer
	Private m_ordtr_fecha As Date
	Private m_ordtr_monto As Double
	Private m_ordtr_carga As String
	Private m_ordtr_estado As String
	Private m_ordtr_usrcrea As String
	Private m_ordtr_feccrea As Date
	Private m_ordtr_usrmod As String
	Private m_ordtr_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_OrdenesTransportes
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
	
	Public Property ORDTR_Codigo() As String
		Get
			return m_ordtr_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordtr_codigo) Then
				If Not m_ordtr_codigo.Equals(value) Then
					m_ordtr_codigo = value
					OnORDTR_CodigoChanged(m_ordtr_codigo, EventArgs.Empty)
				End If
			Else
				m_ordtr_codigo = value
				OnORDTR_CodigoChanged(m_ordtr_codigo, EventArgs.Empty)
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
	Public Property COTIZ_Codigo() As String
		Get
			return m_cotiz_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_codigo) Then
				If Not m_cotiz_codigo.Equals(value) Then
					m_cotiz_codigo = value
					OnCOTIZ_CodigoChanged(m_cotiz_codigo, EventArgs.Empty)
				End If
			Else
				m_cotiz_codigo = value
				OnCOTIZ_CodigoChanged(m_cotiz_codigo, EventArgs.Empty)
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
	Public Property RUTAS_Id() As Long
		Get
			return m_rutas_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_rutas_id) Then
				If Not m_rutas_id.Equals(value) Then
					m_rutas_id = value
					OnRUTAS_IdChanged(m_rutas_id, EventArgs.Empty)
				End If
			Else
				m_rutas_id = value
				OnRUTAS_IdChanged(m_rutas_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ORDTR_Id() As Long
		Get
			return m_ordtr_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_ordtr_id) Then
				If Not m_ordtr_id.Equals(value) Then
					m_ordtr_id = value
					OnORDTR_IdChanged(m_ordtr_id, EventArgs.Empty)
				End If
			Else
				m_ordtr_id = value
				OnORDTR_IdChanged(m_ordtr_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ORDTR_Numero() As Integer
		Get
			return m_ordtr_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_ordtr_numero) Then
				If Not m_ordtr_numero.Equals(value) Then
					m_ordtr_numero = value
					OnORDTR_NumeroChanged(m_ordtr_numero, EventArgs.Empty)
				End If
			Else
				m_ordtr_numero = value
				OnORDTR_NumeroChanged(m_ordtr_numero, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ORDTR_Fecha() As Date
		Get
			return m_ordtr_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_ordtr_fecha) Then
				If Not m_ordtr_fecha.Equals(value) Then
					m_ordtr_fecha = value
					OnORDTR_FechaChanged(m_ordtr_fecha, EventArgs.Empty)
				End If
			Else
				m_ordtr_fecha = value
				OnORDTR_FechaChanged(m_ordtr_fecha, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ORDTR_Monto() As Double
		Get
			return m_ordtr_monto
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_ordtr_monto) Then
				If Not m_ordtr_monto.Equals(value) Then
					m_ordtr_monto = value
					OnORDTR_MontoChanged(m_ordtr_monto, EventArgs.Empty)
				End If
			Else
				m_ordtr_monto = value
				OnORDTR_MontoChanged(m_ordtr_monto, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ORDTR_Carga() As String
		Get
			return m_ordtr_carga
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordtr_carga) Then
				If Not m_ordtr_carga.Equals(value) Then
					m_ordtr_carga = value
					OnORDTR_CargaChanged(m_ordtr_carga, EventArgs.Empty)
				End If
			Else
				m_ordtr_carga = value
				OnORDTR_CargaChanged(m_ordtr_carga, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ORDTR_Estado() As String
		Get
			return m_ordtr_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordtr_estado) Then
				If Not m_ordtr_estado.Equals(value) Then
					m_ordtr_estado = value
					OnORDTR_EstadoChanged(m_ordtr_estado, EventArgs.Empty)
				End If
			Else
				m_ordtr_estado = value
				OnORDTR_EstadoChanged(m_ordtr_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ORDTR_UsrCrea() As String
		Get
			return m_ordtr_usrcrea
		End Get
		Set(ByVal value As String)
			m_ordtr_usrcrea = value
		End Set
	End Property
	Public Property ORDTR_FecCrea() As Date
		Get
			return m_ordtr_feccrea
		End Get
		Set(ByVal value As Date)
			m_ordtr_feccrea = value
		End Set
	End Property
	Public Property ORDTR_UsrMod() As String
		Get
			return m_ordtr_usrmod
		End Get
		Set(ByVal value As String)
			m_ordtr_usrmod = value
		End Set
	End Property
	Public Property ORDTR_FecMod() As Date
		Get
			return m_ordtr_fecmod
		End Get
		Set(ByVal value As Date)
			m_ordtr_fecmod = value
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
			Return "TRAN_OrdenesTransportes"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event ORDTR_CodigoChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event COTIZ_CodigoChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event RUTAS_IdChanged As EventHandler
	Public Event ORDTR_IdChanged As EventHandler
	Public Event ORDTR_NumeroChanged As EventHandler
	Public Event ORDTR_FechaChanged As EventHandler
	Public Event ORDTR_MontoChanged As EventHandler
	Public Event ORDTR_CargaChanged As EventHandler
	Public Event ORDTR_EstadoChanged As EventHandler
	Public Sub OnORDTR_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDTR_CodigoChanged(sender, e)
	End Sub
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnCOTIZ_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_CodigoChanged(sender, e)
	End Sub
	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub
	Public Sub OnRUTAS_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RUTAS_IdChanged(sender, e)
	End Sub
	Public Sub OnORDTR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDTR_IdChanged(sender, e)
	End Sub
	Public Sub OnORDTR_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDTR_NumeroChanged(sender, e)
	End Sub
	Public Sub OnORDTR_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDTR_FechaChanged(sender, e)
	End Sub
	Public Sub OnORDTR_MontoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDTR_MontoChanged(sender, e)
	End Sub
	Public Sub OnORDTR_CargaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDTR_CargaChanged(sender, e)
	End Sub
	Public Sub OnORDTR_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDTR_EstadoChanged(sender, e)
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

