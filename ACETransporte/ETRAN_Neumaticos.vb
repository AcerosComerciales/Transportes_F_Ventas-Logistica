Imports System

Partial Public Class ETRAN_Neumaticos
    Implements ICloneable

#Region " Variables "
    Private m_sucur_nombre As String
    Private m_tipo_marca As String
    Private m_tipo_llanta As String

    Private m_vneum_lado As String
    Private m_vneum_seccion As String
    Private m_vneum_ordenposicion As Short
    Private m_vneum_orden As Short
    Private m_vneum_internoexterno As String

    Private m_etran_movimientosneumaticos As ETRAN_MovimientosNeumaticos
    Private m_etran_vehiculosneumaticos As ETRAN_VehiculosNeumaticos
    Private m_etran_vnanterior As ETRAN_MovimientosNeumaticos


    Private m_listATRAN_Neumaticos As List(Of ETRAN_ViajesNeumaticos) 'Creado Frank
#End Region

#Region " Propiedades "

    Public Property ListATRAN_Neumaticos() As List(Of ETRAN_ViajesNeumaticos) 'Creado Frank
        Get
            Return m_listATRAN_Neumaticos
        End Get
        Set(ByVal value As List(Of ETRAN_ViajesNeumaticos))
            m_listATRAN_Neumaticos = value
        End Set
    End Property
    Public Property SUCUR_Nombre() As String
        Get
            Return m_sucur_nombre
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_sucur_nombre) Then
                If Not m_sucur_nombre.Equals(value) Then
                    m_sucur_nombre = value
                End If
            Else
                m_sucur_nombre = value
            End If
        End Set
    End Property

    Public Property TIPO_Marca() As String
        Get
            Return m_tipo_marca
        End Get
        Set(ByVal value As String)
            m_tipo_marca = value
        End Set
    End Property

    Public Property TIPO_Llanta() As String
        Get
            Return m_tipo_llanta
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipo_llanta) Then
                If Not m_tipo_llanta.Equals(value) Then
                    m_tipo_llanta = value
                End If
            Else
                m_tipo_llanta = value
            End If
        End Set
    End Property

    Public Property VNEUM_Lado() As String
        Get
            Return m_vneum_lado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_vneum_lado) Then
                If Not m_vneum_lado.Equals(value) Then
                    m_vneum_lado = value
                End If
            Else
                m_vneum_lado = value
            End If
        End Set
    End Property

    Public ReadOnly Property VNEUM_LADO_Text() As String
        Get
            If m_vneum_lado = "D" Then
                Return "Derecho"
            ElseIf m_vneum_lado = "I" Then
                Return "Izquierdo"
            Else
                Return "-"
            End If
        End Get
    End Property

    Public Property VNEUM_Seccion() As String
        Get
            Return m_vneum_seccion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_vneum_seccion) Then
                If Not m_vneum_seccion.Equals(value) Then
                    m_vneum_seccion = value
                End If
            Else
                m_vneum_seccion = value
            End If
        End Set
    End Property

    Public ReadOnly Property VNEUM_SECCION_Text() As String
        Get
            If m_vneum_seccion = "D" Then
                Return "Delanteros"
            ElseIf m_vneum_seccion = "P" Then
                Return "Posteriores"
            ElseIf m_vneum_seccion = "R" Then
                Return "Repuesto"
            Else
                Return "Delanteros"
            End If
        End Get
    End Property

    Public Property VNEUM_OrdenPosicion() As Short
        Get
            Return m_vneum_ordenposicion
        End Get
        Set(ByVal value As Short)
            If Not IsNothing(m_vneum_ordenposicion) Then
                If Not m_vneum_ordenposicion.Equals(value) Then
                    m_vneum_ordenposicion = value
                End If
            Else
                m_vneum_ordenposicion = value
            End If
        End Set
    End Property

    Public Property VNEUM_Orden() As Short
        Get
            Return m_vneum_orden
        End Get
        Set(ByVal value As Short)
            m_vneum_orden = value
        End Set
    End Property


    Public Property VNEUM_InternoExterno() As String
        Get
            Return m_vneum_internoexterno
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_vneum_internoexterno) Then
                If Not m_vneum_internoexterno.Equals(value) Then
                    m_vneum_internoexterno = value
                End If
            Else
                m_vneum_internoexterno = value
            End If
        End Set
    End Property

    Public ReadOnly Property VNEUM_INTERNOEXTERNO_Text() As String
        Get
            If m_vneum_internoexterno = "E" Then
                Return "Externo"
            ElseIf m_vneum_internoexterno = "I" Then
                Return "Interno"
            Else
                Return "-"
            End If
        End Get
    End Property

    Public Property TRAN_MovimientosNeumaticos() As ETRAN_MovimientosNeumaticos
        Get
            Return m_etran_movimientosneumaticos
        End Get
        Set(ByVal value As ETRAN_MovimientosNeumaticos)
            m_etran_movimientosneumaticos = value
        End Set
    End Property

    Public Property TRAN_VehiculosNeumaticos() As ETRAN_VehiculosNeumaticos
        Get
            Return m_etran_vehiculosneumaticos
        End Get
        Set(ByVal value As ETRAN_VehiculosNeumaticos)
            m_etran_vehiculosneumaticos = value
        End Set
    End Property

    Public Property TRAN_MovNeumaAnterior() As ETRAN_MovimientosNeumaticos
        Get
            Return m_etran_vnanterior
        End Get
        Set(ByVal value As ETRAN_MovimientosNeumaticos)
            m_etran_vnanterior = value
        End Set
    End Property

#End Region

#Region " Constructores "
    Public Sub New(ByVal x_neuma_id As Long, ByVal x_neuma_codigo As String _
                   , ByVal x_neuma_modelo As String, ByVal x_tipo_llanta As String _
                   , ByVal x_tipo_marca As String, ByVal x_neuma_feccompra As Date _
                   , ByVal x_neuma_kmvidautil As Decimal, ByVal x_seccion As String _
                   , ByVal x_lado As String, ByVal x_ordenposicion As Short, ByVal x_orden As Short, ByVal x_intext As String _
                   , Optional ByVal x_nuevo As Boolean = True)
        m_neuma_id = x_neuma_id
        m_neuma_codigo = x_neuma_codigo
        m_neuma_feccompra = x_neuma_feccompra
        m_neuma_modelo = x_neuma_modelo
        m_tipo_llanta = x_tipo_llanta
        m_tipo_marca = x_tipo_marca
        m_neuma_kmvidautil = x_neuma_kmvidautil
        m_vneum_lado = x_lado
        m_vneum_seccion = x_seccion
        m_vneum_ordenposicion = x_ordenposicion
        m_vneum_orden = x_orden
        m_vneum_internoexterno = x_intext
        m_nuevo = x_nuevo
    End Sub


    Enum TipoInicializacion
        Todos
        Movimientos
    End Enum


    Public Sub New(ByVal x_opcion As TipoInicializacion)
        Select Case x_opcion
            Case TipoInicializacion.Todos
                m_etran_movimientosneumaticos = New ETRAN_MovimientosNeumaticos()
                m_etran_vehiculosneumaticos = New ETRAN_VehiculosNeumaticos()
            Case TipoInicializacion.Movimientos
                m_etran_movimientosneumaticos = New ETRAN_MovimientosNeumaticos()
                m_etran_vehiculosneumaticos = New ETRAN_VehiculosNeumaticos()
            Case Else

        End Select
    End Sub
#End Region

#Region " Metodos "
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Try
            Dim cloneInstance As New ETRAN_Neumaticos()
            cloneInstance = Me
            Return cloneInstance.MemberwiseClone
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
