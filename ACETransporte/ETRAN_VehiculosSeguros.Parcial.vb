Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_VehiculosSeguros

#Region " Campos "
	
	Private m_segvh_id As Long
    Private m_vehic_id As Long
    Private m_segvh_conductor As String
    Private m_segvh_descripcion As String
    Private m_segvh_fecinicio As Date
	Private m_segvh_fecfin As Date
	Private m_segvh_empresaaseguradora As String
    Private m_segvh_fecadquisicion As Date
    Private m_segvh_estado As String
    Private m_segvh_color As String
    Private m_segvh_dias_restantes As Long
    Private m_segvh_tiempo_contrato As String
    Private m_segvh_precio As Double
	Private m_segvh_usrcrea As String
	Private m_segvh_feccrea As Date
	Private m_segvh_usrmod As String
	Private m_segvh_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_VehiculosSeguros
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

#Region " Propiedades "

    Public Property SEGVH_Id() As Long
        Get
            Return m_segvh_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_segvh_id) Then
                If Not m_segvh_id.Equals(value) Then
                    m_segvh_id = value
                    OnSEGVH_IdChanged(m_segvh_id, EventArgs.Empty)
                End If
            Else
                m_segvh_id = value
                OnSEGVH_IdChanged(m_segvh_id, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property SEGVH_Conductor As String
        Get
            Return m_segvh_conductor
        End Get
        Set(value As String)
            If Not IsNothing(m_segvh_conductor) Then
                If Not m_segvh_conductor.Equals(value) Then
                    m_segvh_conductor = value
                    OnSEGVH_IdChanged(m_segvh_conductor, EventArgs.Empty)
                End If
            Else
                m_segvh_conductor = value
                OnSEGVH_IdChanged(m_segvh_id, EventArgs.Empty)
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
	Public Property SEGVH_Descripcion() As String
		Get
			return m_segvh_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_segvh_descripcion) Then
				If Not m_segvh_descripcion.Equals(value) Then
					m_segvh_descripcion = value
					OnSEGVH_DescripcionChanged(m_segvh_descripcion, EventArgs.Empty)
				End If
			Else
				m_segvh_descripcion = value
				OnSEGVH_DescripcionChanged(m_segvh_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property SEGVH_FecInicio() As Date
		Get
			return m_segvh_fecinicio
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_segvh_fecinicio) Then
				If Not m_segvh_fecinicio.Equals(value) Then
					m_segvh_fecinicio = value
					OnSEGVH_FecInicioChanged(m_segvh_fecinicio, EventArgs.Empty)
				End If
			Else
				m_segvh_fecinicio = value
				OnSEGVH_FecInicioChanged(m_segvh_fecinicio, EventArgs.Empty)
			End If
		End Set
	End Property
    Public Property SEGVH_FecFin() As Date
        Get
            Return m_segvh_fecfin
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_segvh_fecfin) Then
                If Not m_segvh_fecfin.Equals(value) Then
                    m_segvh_fecfin = value
                    OnSEGVH_FecFinChanged(m_segvh_fecfin, EventArgs.Empty)
                End If
            Else
                m_segvh_fecfin = value
                OnSEGVH_FecFinChanged(m_segvh_fecfin, EventArgs.Empty)
            End If
        End Set
    End Property
    'Variable Creador Frank 
    Public Property SEGVH_EmpresaAseguradora() As String
        Get
            Return m_segvh_empresaaseguradora
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_segvh_empresaaseguradora) Then
                If Not m_segvh_empresaaseguradora.Equals(value) Then
                    m_segvh_empresaaseguradora = value
                    OnSEGVH_EmpresaAseguradoraChanged(m_segvh_empresaaseguradora, EventArgs.Empty)
                End If
            Else
                m_segvh_empresaaseguradora = value
                OnSEGVH_EmpresaAseguradoraChanged(m_segvh_empresaaseguradora, EventArgs.Empty)
            End If
        End Set
    End Property
    'Variable creado frank 
    Public Property SEGVH_Estado() As String
        Get
            Return m_segvh_estado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_segvh_estado) Then
                If Not m_segvh_estado.Equals(value) Then
                    m_segvh_estado = value
                    OnSEGVH_EmpresaAseguradoraChanged(m_segvh_estado, EventArgs.Empty)
                End If
            Else
                m_segvh_estado = value
                OnSEGVH_EmpresaAseguradoraChanged(m_segvh_estado, EventArgs.Empty)
            End If
        End Set
    End Property
    'Frank 
    Public Property SEGVH_Color() As String
        Get
            Return m_segvh_color
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_segvh_color) Then
                If Not m_segvh_color.Equals(value) Then
                    m_segvh_color = value
                    OnSEGVH_EmpresaAseguradoraChanged(m_segvh_color, EventArgs.Empty)
                End If
            Else
                m_segvh_color = value
                OnSEGVH_EmpresaAseguradoraChanged(m_segvh_color, EventArgs.Empty)
            End If
        End Set
    End Property
    'Frank 
    Public Property SEGVH_DiasRestantes() As Long
        Get
            Return m_segvh_dias_restantes
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_segvh_empresaaseguradora) Then
                If Not m_segvh_dias_restantes.Equals(value) Then
                    m_segvh_dias_restantes = value
                    OnSEGVH_EmpresaAseguradoraChanged(m_segvh_empresaaseguradora, EventArgs.Empty)
                End If
            Else
                m_segvh_dias_restantes = value
                OnSEGVH_EmpresaAseguradoraChanged(m_segvh_dias_restantes, EventArgs.Empty)
            End If
        End Set
    End Property
    'Frank   :)
    Public Property SEGVH_TiempoContrato() As Long
        Get
            Return m_segvh_tiempo_contrato
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_segvh_tiempo_contrato) Then
                If Not m_segvh_tiempo_contrato.Equals(value) Then
                    m_segvh_tiempo_contrato = value
                    OnSEGVH_EmpresaAseguradoraChanged(m_segvh_tiempo_contrato, EventArgs.Empty)
                End If
            Else
                m_segvh_tiempo_contrato = value
                OnSEGVH_EmpresaAseguradoraChanged(m_segvh_tiempo_contrato, EventArgs.Empty)
            End If
        End Set
    End Property


    Public Property SEGVH_FecAdquisicion() As Date
		Get
			return m_segvh_fecadquisicion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_segvh_fecadquisicion) Then
				If Not m_segvh_fecadquisicion.Equals(value) Then
					m_segvh_fecadquisicion = value
					OnSEGVH_FecAdquisicionChanged(m_segvh_fecadquisicion, EventArgs.Empty)
				End If
			Else
				m_segvh_fecadquisicion = value
				OnSEGVH_FecAdquisicionChanged(m_segvh_fecadquisicion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property SEGVH_Precio() As Double
		Get
			return m_segvh_precio
		End Get
		Set(ByVal value As Double)
			If Not IsNothing(m_segvh_precio) Then
				If Not m_segvh_precio.Equals(value) Then
					m_segvh_precio = value
					OnSEGVH_PrecioChanged(m_segvh_precio, EventArgs.Empty)
				End If
			Else
				m_segvh_precio = value
				OnSEGVH_PrecioChanged(m_segvh_precio, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property SEGVH_UsrCrea() As String
		Get
			return m_segvh_usrcrea
		End Get
		Set(ByVal value As String)
			m_segvh_usrcrea = value
		End Set
	End Property
	Public Property SEGVH_FecCrea() As Date
		Get
			return m_segvh_feccrea
		End Get
		Set(ByVal value As Date)
			m_segvh_feccrea = value
		End Set
	End Property
	Public Property SEGVH_UsrMod() As String
		Get
			return m_segvh_usrmod
		End Get
		Set(ByVal value As String)
			m_segvh_usrmod = value
		End Set
	End Property
	Public Property SEGVH_FecMod() As Date
		Get
			return m_segvh_fecmod
		End Get
		Set(ByVal value As Date)
			m_segvh_fecmod = value
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
			Return "TRAN_VehiculosSeguros"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
    'Creas tu Variable aqui 
    Public Event SEGVH_IdChanged As EventHandler
    Public Event SEGVH_ConductorChanged As EventHandler
    Public Event VEHIC_IdChanged As EventHandler
	Public Event SEGVH_DescripcionChanged As EventHandler
	Public Event SEGVH_FecInicioChanged As EventHandler
	Public Event SEGVH_FecFinChanged As EventHandler
	Public Event SEGVH_EmpresaAseguradoraChanged As EventHandler
    Public Event SEGVH_FecAdquisicionChanged As EventHandler
    Public Event SEGVH_EstadoChanged As EventHandler
    Public Event SEGVH_ColorChanged As EventHandler
    Public Event SEGVH_DiasRestantesChanged As EventHandler
    Public Event SEGVH_TiempoContratoChanged As EventHandler
    Public Event SEGVH_PrecioChanged As EventHandler

    'Tambien aqui  y no te olvides del XML en la Capa E  Ayudita por Frank s.a.c 
    Public Sub OnSEGVH_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SEGVH_IdChanged(sender, e)
    End Sub
    ' m_segvh_conductor
    Public Sub OnSEGVH_ConductorChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SEGVH_ConductorChanged(sender, e)
    End Sub

    Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
	End Sub
	Public Sub OnSEGVH_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SEGVH_DescripcionChanged(sender, e)
	End Sub
	Public Sub OnSEGVH_FecInicioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SEGVH_FecInicioChanged(sender, e)
	End Sub
	Public Sub OnSEGVH_FecFinChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SEGVH_FecFinChanged(sender, e)
	End Sub
	Public Sub OnSEGVH_EmpresaAseguradoraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SEGVH_EmpresaAseguradoraChanged(sender, e)
	End Sub
    Public Sub OnSEGVH_FecAdquisicionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SEGVH_FecAdquisicionChanged(sender, e)
    End Sub
    'SEGVH_Estado
    Public Sub OnSEGVH_EstadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SEGVH_EstadoChanged(sender, e)
    End Sub
    'SEGVH_Color
    Public Sub OnSEGVH_ColorChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SEGVH_ColorChanged(sender, e)
    End Sub
    'SEGVH_DiasRestantes
    Public Sub OnSEGVH_DiasRestantesChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SEGVH_DiasRestantesChanged(sender, e)
    End Sub
    'SEGVH_TiempoContrato
    Public Sub OnSEGVH_TiempoContratoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent SEGVH_TiempoContratoChanged(sender, e)
    End Sub

    Public Sub OnSEGVH_PrecioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SEGVH_PrecioChanged(sender, e)
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

