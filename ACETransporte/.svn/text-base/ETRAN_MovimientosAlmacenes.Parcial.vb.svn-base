Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_MovimientosAlmacenes

#Region " Campos "
	
	Private m_moval_id As Long
	Private m_tipos_codtipopieza As String
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_moval_idalmacenorigen As Long
	Private m_moval_idalmacendestino As Long
	Private m_moval_tipooperacion As Short
	Private m_moval_fecha As Date
	Private m_moval_glosa As String
	Private m_moval_idpieza As Long
	Private m_moval_usrcrea As String
	Private m_moval_feccrea As Date
	Private m_moval_usrmod As String
	Private m_moval_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_MovimientosAlmacenes
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
	
	Public Property MOVAL_Id() As Long
		Get
			return m_moval_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_moval_id) Then
				If Not m_moval_id.Equals(value) Then
					m_moval_id = value
					OnMOVAL_IdChanged(m_moval_id, EventArgs.Empty)
				End If
			Else
				m_moval_id = value
				OnMOVAL_IdChanged(m_moval_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property TIPOS_CodTipoPieza() As String
		Get
			return m_tipos_codtipopieza
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipopieza) Then
				If Not m_tipos_codtipopieza.Equals(value) Then
					m_tipos_codtipopieza = value
					OnTIPOS_CodTipoPiezaChanged(m_tipos_codtipopieza, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipopieza = value
				OnTIPOS_CodTipoPiezaChanged(m_tipos_codtipopieza, EventArgs.Empty)
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
	Public Property MOVAL_IdAlmacenOrigen() As Long
		Get
			return m_moval_idalmacenorigen
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_moval_idalmacenorigen) Then
				If Not m_moval_idalmacenorigen.Equals(value) Then
					m_moval_idalmacenorigen = value
					OnMOVAL_IdAlmacenOrigenChanged(m_moval_idalmacenorigen, EventArgs.Empty)
				End If
			Else
				m_moval_idalmacenorigen = value
				OnMOVAL_IdAlmacenOrigenChanged(m_moval_idalmacenorigen, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVAL_IdAlmacenDestino() As Long
		Get
			return m_moval_idalmacendestino
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_moval_idalmacendestino) Then
				If Not m_moval_idalmacendestino.Equals(value) Then
					m_moval_idalmacendestino = value
					OnMOVAL_IdAlmacenDestinoChanged(m_moval_idalmacendestino, EventArgs.Empty)
				End If
			Else
				m_moval_idalmacendestino = value
				OnMOVAL_IdAlmacenDestinoChanged(m_moval_idalmacendestino, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVAL_TipoOperacion() As Short
		Get
			return m_moval_tipooperacion
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_moval_tipooperacion) Then
				If Not m_moval_tipooperacion.Equals(value) Then
					m_moval_tipooperacion = value
					OnMOVAL_TipoOperacionChanged(m_moval_tipooperacion, EventArgs.Empty)
				End If
			Else
				m_moval_tipooperacion = value
				OnMOVAL_TipoOperacionChanged(m_moval_tipooperacion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVAL_Fecha() As Date
		Get
			return m_moval_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_moval_fecha) Then
				If Not m_moval_fecha.Equals(value) Then
					m_moval_fecha = value
					OnMOVAL_FechaChanged(m_moval_fecha, EventArgs.Empty)
				End If
			Else
				m_moval_fecha = value
				OnMOVAL_FechaChanged(m_moval_fecha, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVAL_Glosa() As String
		Get
			return m_moval_glosa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_moval_glosa) Then
				If Not m_moval_glosa.Equals(value) Then
					m_moval_glosa = value
					OnMOVAL_GlosaChanged(m_moval_glosa, EventArgs.Empty)
				End If
			Else
				m_moval_glosa = value
				OnMOVAL_GlosaChanged(m_moval_glosa, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVAL_IdPieza() As Long
		Get
			return m_moval_idpieza
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_moval_idpieza) Then
				If Not m_moval_idpieza.Equals(value) Then
					m_moval_idpieza = value
					OnMOVAL_IdPiezaChanged(m_moval_idpieza, EventArgs.Empty)
				End If
			Else
				m_moval_idpieza = value
				OnMOVAL_IdPiezaChanged(m_moval_idpieza, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property MOVAL_UsrCrea() As String
		Get
			return m_moval_usrcrea
		End Get
		Set(ByVal value As String)
			m_moval_usrcrea = value
		End Set
	End Property
	Public Property MOVAL_FecCrea() As Date
		Get
			return m_moval_feccrea
		End Get
		Set(ByVal value As Date)
			m_moval_feccrea = value
		End Set
	End Property
	Public Property MOVAL_UsrMod() As String
		Get
			return m_moval_usrmod
		End Get
		Set(ByVal value As String)
			m_moval_usrmod = value
		End Set
	End Property
	Public Property MOVAL_FecMod() As Date
		Get
			return m_moval_fecmod
		End Get
		Set(ByVal value As Date)
			m_moval_fecmod = value
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
			Return "TRAN_MovimientosAlmacenes"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event MOVAL_IdChanged As EventHandler
	Public Event TIPOS_CodTipoPiezaChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event MOVAL_IdAlmacenOrigenChanged As EventHandler
	Public Event MOVAL_IdAlmacenDestinoChanged As EventHandler
	Public Event MOVAL_TipoOperacionChanged As EventHandler
	Public Event MOVAL_FechaChanged As EventHandler
	Public Event MOVAL_GlosaChanged As EventHandler
	Public Event MOVAL_IdPiezaChanged As EventHandler
	Public Sub OnMOVAL_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVAL_IdChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodTipoPiezaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoPiezaChanged(sender, e)
	End Sub
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnMOVAL_IdAlmacenOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVAL_IdAlmacenOrigenChanged(sender, e)
	End Sub
	Public Sub OnMOVAL_IdAlmacenDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVAL_IdAlmacenDestinoChanged(sender, e)
	End Sub
	Public Sub OnMOVAL_TipoOperacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVAL_TipoOperacionChanged(sender, e)
	End Sub
	Public Sub OnMOVAL_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVAL_FechaChanged(sender, e)
	End Sub
	Public Sub OnMOVAL_GlosaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVAL_GlosaChanged(sender, e)
	End Sub
	Public Sub OnMOVAL_IdPiezaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent MOVAL_IdPiezaChanged(sender, e)
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

