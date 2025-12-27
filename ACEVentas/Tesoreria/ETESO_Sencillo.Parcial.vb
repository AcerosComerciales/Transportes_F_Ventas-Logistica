Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework
Imports ACDVentas

Partial Public Class ETESO_Sencillo

#Region " Campos "
	
	Private m_pvent_id As Long
	Private m_senci_id As Long
	Private m_senci_fecha As Date
	Private m_senci_observacion As String
	Private m_senci_importe As Decimal
	Private m_senci_tipocambio As Decimal
	Private m_tipos_codtipomoneda As String
	Private m_entid_codigo As String
	Private m_senci_usrcrea As String
	Private m_senci_feccrea As Date
	Private m_senci_usrmod As String
	Private m_senci_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

    Private m_senci_estado As String
    Private m_senci_fechaanulacion As Date
	Private m_senci_motivoanulacion As String



	Private m_hash As Hashtable
#End Region

#Region " Constructores "

	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_Sencillo
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

	Public Sub New(ByVal pvent_id As Integer)
		m_pvent_id = pvent_id

	End Sub




#End Region

#Region " Propiedades "

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

	Public Property SENCI_Id() As Long
		Get
			return m_senci_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_senci_id) Then
				If Not m_senci_id.Equals(value) Then
					m_senci_id = value
					OnSENCI_IdChanged(m_senci_id, EventArgs.Empty)
				End If
			Else
				m_senci_id = value
				OnSENCI_IdChanged(m_senci_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SENCI_Fecha() As Date
		Get
			return m_senci_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_senci_fecha) Then
				If Not m_senci_fecha.Equals(value) Then
					m_senci_fecha = value
					OnSENCI_FechaChanged(m_senci_fecha, EventArgs.Empty)
				End If
			Else
				m_senci_fecha = value
				OnSENCI_FechaChanged(m_senci_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SENCI_Observacion() As String
		Get
			return m_senci_observacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_senci_observacion) Then
				If Not m_senci_observacion.Equals(value) Then
					m_senci_observacion = value
					OnSENCI_ObservacionChanged(m_senci_observacion, EventArgs.Empty)
				End If
			Else
				m_senci_observacion = value
				OnSENCI_ObservacionChanged(m_senci_observacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SENCI_Importe() As Decimal
		Get
			return m_senci_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_senci_importe) Then
				If Not m_senci_importe.Equals(value) Then
					m_senci_importe = value
					OnSENCI_ImporteChanged(m_senci_importe, EventArgs.Empty)
				End If
			Else
				m_senci_importe = value
				OnSENCI_ImporteChanged(m_senci_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property SENCI_TipoCambio() As Decimal
		Get
			return m_senci_tipocambio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_senci_tipocambio) Then
				If Not m_senci_tipocambio.Equals(value) Then
					m_senci_tipocambio = value
					OnSENCI_TipoCambioChanged(m_senci_tipocambio, EventArgs.Empty)
				End If
			Else
				m_senci_tipocambio = value
				OnSENCI_TipoCambioChanged(m_senci_tipocambio, EventArgs.Empty)
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

    Public Property SENCI_Estado() As String
        Get
            Return m_senci_estado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_senci_estado) Then
                If Not m_senci_estado.Equals(value) Then
                    m_senci_estado = value
                    OnSENCI_EstadoChanged(m_senci_estado, EventArgs.Empty)
                End If
            Else
                m_senci_estado = value
                OnSENCI_EstadoChanged(m_senci_estado, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property SENCI_FechaAnulacion() As Date
        Get
            Return m_senci_fechaanulacion
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_senci_fechaanulacion) Then
                If Not m_senci_fechaanulacion.Equals(value) Then
                    m_senci_fechaanulacion = value
                    OnSENCI_FechaAnulacionChanged(m_senci_fechaanulacion, EventArgs.Empty)
                End If
            Else
                m_senci_fechaanulacion = value
                OnSENCI_FechaAnulacionChanged(m_senci_fechaanulacion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property SENCI_MotivoAnulacion() As String
        Get
            Return m_senci_motivoanulacion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_senci_motivoanulacion) Then
                If Not m_senci_motivoanulacion.Equals(value) Then
                    m_senci_motivoanulacion = value
                    OnSENCI_MotivoAnulacionChanged(m_senci_motivoanulacion, EventArgs.Empty)
                End If
            Else
                m_senci_motivoanulacion = value
                OnSENCI_MotivoAnulacionChanged(m_senci_motivoanulacion, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property SENCI_UsrCrea() As String
		Get
			return m_senci_usrcrea
		End Get
		Set(ByVal value As String)
			m_senci_usrcrea = value
		End Set
	End Property

	Public Property SENCI_FecCrea() As Date
		Get
			return m_senci_feccrea
		End Get
		Set(ByVal value As Date)
			m_senci_feccrea = value
		End Set
	End Property

	Public Property SENCI_UsrMod() As String
		Get
			return m_senci_usrmod
		End Get
		Set(ByVal value As String)
			m_senci_usrmod = value
		End Set
	End Property

	Public Property SENCI_FecMod() As Date
		Get
			return m_senci_fecmod
		End Get
		Set(ByVal value As Date)
			m_senci_fecmod = value
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
			Return "TESO_Sencillo"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Tesoreria"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event PVENT_IdChanged As EventHandler
	Public Event SENCI_IdChanged As EventHandler
	Public Event SENCI_FechaChanged As EventHandler
	Public Event SENCI_ObservacionChanged As EventHandler
	Public Event SENCI_ImporteChanged As EventHandler
	Public Event SENCI_TipoCambioChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
    Public Event ENTID_CodigoChanged As EventHandler

    Public Event SENCI_EstadoChanged As EventHandler
    Public Event SENCI_FechaAnulacionChanged As EventHandler
    Public Event SENCI_MotivoAnulacionChanged As EventHandler

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnSENCI_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SENCI_IdChanged(sender, e)
	End Sub

	Public Sub OnSENCI_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SENCI_FechaChanged(sender, e)
	End Sub

	Public Sub OnSENCI_ObservacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SENCI_ObservacionChanged(sender, e)
	End Sub

	Public Sub OnSENCI_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SENCI_ImporteChanged(sender, e)
	End Sub

	Public Sub OnSENCI_TipoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SENCI_TipoCambioChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub


    Public Sub OnSENCI_EstadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SENCI_EstadoChanged(sender, e)
    End Sub
    Public Sub OnSENCI_FechaAnulacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SENCI_FechaAnulacionChanged(sender, e)
    End Sub

    Public Sub OnSENCI_MotivoAnulacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SENCI_MotivoAnulacionChanged(sender, e)
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

