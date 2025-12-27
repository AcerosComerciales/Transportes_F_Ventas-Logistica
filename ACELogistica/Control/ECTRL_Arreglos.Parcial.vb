Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ECTRL_Arreglos

#Region " Campos "
	
	Private m_arreg_codigo As String
	Private m_tipos_codtipoarreglo As String
	Private m_docve_codigo As String
	Private m_almac_id As Short
    Private m_arreg_serie As String
    Private m_usuario As String
	Private m_arreg_numero As Integer
	Private m_arreg_fecha As Date
	Private m_arreg_fechaingreso As Date
	Private m_arreg_estado As String
	Private m_arreg_observaciones As String
	Private m_arreg_fechaanulacion As Date
	Private m_arreg_motivoanulacion As String
	Private m_arreg_anuladocaja As Boolean
	Private m_arreg_usrcrea As String
	Private m_arreg_feccrea As Date
	Private m_arreg_usrmod As String
	Private m_arreg_fecmod As Date
    Private m_nuevo As Boolean

	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
         Dim _obj As Object = ACELogistica.My.Resources.xmlCTRL_Arreglos
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
	
	Public Property ARREG_Codigo() As String
		Get
			return m_arreg_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_arreg_codigo) Then
				If Not m_arreg_codigo.Equals(value) Then
					m_arreg_codigo = value
					OnARREG_CodigoChanged(m_arreg_codigo, EventArgs.Empty)
				End If
			Else
				m_arreg_codigo = value
				OnARREG_CodigoChanged(m_arreg_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoArreglo() As String
		Get
			return m_tipos_codtipoarreglo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipoarreglo) Then
				If Not m_tipos_codtipoarreglo.Equals(value) Then
					m_tipos_codtipoarreglo = value
					OnTIPOS_CodTipoArregloChanged(m_tipos_codtipoarreglo, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipoarreglo = value
				OnTIPOS_CodTipoArregloChanged(m_tipos_codtipoarreglo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Codigo() As String
		Get
			return m_docve_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_codigo) Then
				If Not m_docve_codigo.Equals(value) Then
					m_docve_codigo = value
					OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
				End If
			Else
				m_docve_codigo = value
				OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
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

	Public Property ARREG_Serie() As String
		Get
			return m_arreg_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_arreg_serie) Then
				If Not m_arreg_serie.Equals(value) Then
					m_arreg_serie = value
					OnARREG_SerieChanged(m_arreg_serie, EventArgs.Empty)
				End If
			Else
				m_arreg_serie = value
				OnARREG_SerieChanged(m_arreg_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARREG_Numero() As Integer
		Get
			return m_arreg_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_arreg_numero) Then
				If Not m_arreg_numero.Equals(value) Then
					m_arreg_numero = value
					OnARREG_NumeroChanged(m_arreg_numero, EventArgs.Empty)
				End If
			Else
				m_arreg_numero = value
				OnARREG_NumeroChanged(m_arreg_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARREG_Fecha() As Date
		Get
			return m_arreg_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_arreg_fecha) Then
				If Not m_arreg_fecha.Equals(value) Then
					m_arreg_fecha = value
					OnARREG_FechaChanged(m_arreg_fecha, EventArgs.Empty)
				End If
			Else
				m_arreg_fecha = value
				OnARREG_FechaChanged(m_arreg_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARREG_FechaIngreso() As Date
		Get
			return m_arreg_fechaingreso
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_arreg_fechaingreso) Then
				If Not m_arreg_fechaingreso.Equals(value) Then
					m_arreg_fechaingreso = value
					OnARREG_FechaIngresoChanged(m_arreg_fechaingreso, EventArgs.Empty)
				End If
			Else
				m_arreg_fechaingreso = value
				OnARREG_FechaIngresoChanged(m_arreg_fechaingreso, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARREG_Estado() As String
		Get
			return m_arreg_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_arreg_estado) Then
				If Not m_arreg_estado.Equals(value) Then
					m_arreg_estado = value
					OnARREG_EstadoChanged(m_arreg_estado, EventArgs.Empty)
				End If
			Else
				m_arreg_estado = value
				OnARREG_EstadoChanged(m_arreg_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARREG_Observaciones() As String
		Get
			return m_arreg_observaciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_arreg_observaciones) Then
				If Not m_arreg_observaciones.Equals(value) Then
					m_arreg_observaciones = value
					OnARREG_ObservacionesChanged(m_arreg_observaciones, EventArgs.Empty)
				End If
			Else
				m_arreg_observaciones = value
				OnARREG_ObservacionesChanged(m_arreg_observaciones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARREG_FechaAnulacion() As Date
		Get
			return m_arreg_fechaanulacion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_arreg_fechaanulacion) Then
				If Not m_arreg_fechaanulacion.Equals(value) Then
					m_arreg_fechaanulacion = value
					OnARREG_FechaAnulacionChanged(m_arreg_fechaanulacion, EventArgs.Empty)
				End If
			Else
				m_arreg_fechaanulacion = value
				OnARREG_FechaAnulacionChanged(m_arreg_fechaanulacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARREG_MotivoAnulacion() As String
		Get
			return m_arreg_motivoanulacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_arreg_motivoanulacion) Then
				If Not m_arreg_motivoanulacion.Equals(value) Then
					m_arreg_motivoanulacion = value
					OnARREG_MotivoAnulacionChanged(m_arreg_motivoanulacion, EventArgs.Empty)
				End If
			Else
				m_arreg_motivoanulacion = value
				OnARREG_MotivoAnulacionChanged(m_arreg_motivoanulacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARREG_AnuladoCaja() As Boolean
		Get
			return m_arreg_anuladocaja
		End Get
		Set(ByVal value As Boolean)
			If Not m_arreg_anuladocaja.Equals(value) Then
				m_arreg_anuladocaja = value
				OnARREG_AnuladoCajaChanged(m_arreg_anuladocaja, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARREG_UsrCrea() As String
		Get
			return m_arreg_usrcrea
		End Get
		Set(ByVal value As String)
			m_arreg_usrcrea = value
		End Set
	End Property

	Public Property ARREG_FecCrea() As Date
		Get
			return m_arreg_feccrea
		End Get
		Set(ByVal value As Date)
			m_arreg_feccrea = value
		End Set
	End Property

	Public Property ARREG_UsrMod() As String
		Get
			return m_arreg_usrmod
		End Get
		Set(ByVal value As String)
			m_arreg_usrmod = value
		End Set
    End Property
    Public Property Usuario() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property

	Public Property ARREG_FecMod() As Date
		Get
			return m_arreg_fecmod
		End Get
		Set(ByVal value As Date)
			m_arreg_fecmod = value
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
			Return "CTRL_Arreglos"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Logistica"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event ARREG_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoArregloChanged As EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event ARREG_SerieChanged As EventHandler
	Public Event ARREG_NumeroChanged As EventHandler
	Public Event ARREG_FechaChanged As EventHandler
	Public Event ARREG_FechaIngresoChanged As EventHandler
	Public Event ARREG_EstadoChanged As EventHandler
	Public Event ARREG_ObservacionesChanged As EventHandler
	Public Event ARREG_FechaAnulacionChanged As EventHandler
	Public Event ARREG_MotivoAnulacionChanged As EventHandler
	Public Event ARREG_AnuladoCajaChanged As EventHandler

	Public Sub OnARREG_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoArregloChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoArregloChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnARREG_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_SerieChanged(sender, e)
	End Sub

	Public Sub OnARREG_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_NumeroChanged(sender, e)
	End Sub

	Public Sub OnARREG_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_FechaChanged(sender, e)
	End Sub

	Public Sub OnARREG_FechaIngresoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_FechaIngresoChanged(sender, e)
	End Sub

	Public Sub OnARREG_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_EstadoChanged(sender, e)
	End Sub

	Public Sub OnARREG_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_ObservacionesChanged(sender, e)
	End Sub

	Public Sub OnARREG_FechaAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_FechaAnulacionChanged(sender, e)
	End Sub

	Public Sub OnARREG_MotivoAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_MotivoAnulacionChanged(sender, e)
	End Sub

	Public Sub OnARREG_AnuladoCajaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARREG_AnuladoCajaChanged(sender, e)
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

