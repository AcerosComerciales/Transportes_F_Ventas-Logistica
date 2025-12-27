Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml

Partial Public Class ETRAN_Vehiculos

#Region " Variables "
    Private m_listVRanflas As List(Of ETRAN_VehiculosRanflas)
    Private m_listATRAN_VehiculosRanflas As List(Of ETRAN_VehiculosRanflas)
    Private m_listHTRAN_VehiculosRanflas As List(Of ETRAN_VehiculosRanflas)

    Private m_listATRAN_VehiculosConductores As List(Of ETRAN_VehiculosConductores)
    Private m_listHTRAN_VehiculosConductores As List(Of ETRAN_VehiculosConductores)

    Private m_listVMantenimientos As List(Of ETRAN_VehiculosMantenimiento)
    Private m_listVIncidencias As List(Of ETRAN_VehiculosIncidencias)
    Private m_listVConCombustible As List(Of ETRAN_CombustibleConsumo)
    Private m_listVSeguros As List(Of ETRAN_VehiculosSeguros)
    Private m_listVConductores As List(Of ETRAN_VehiculosConductores)

    Private m_tipos_marca As String
    Private m_tipos_vehiculo As String
    Private m_sucur_nombre As String
    Private m_entid_razonsocial As String
    Private m_tipos_tipocombustible As String

    Private m_ranfl_placa As String
    Private m_conductor As String

    Enum Inicializacion
        All
        Ranflas
        Combustible
        Incidencias
        Mantenimiento
        Conductores
        Seguros
        Marca
        MantenimientoPreventivo
    End Enum

    Enum Estado
        Ingresado
        Anulado
        Eliminado
        Confirmado
        Activo
    End Enum


#End Region

#Region " Propiedades "
    Public Property ListVRanflas() As List(Of ETRAN_VehiculosRanflas)
        Get
            Return m_listVRanflas
        End Get
        Set(ByVal value As List(Of ETRAN_VehiculosRanflas))
            m_listVRanflas = value
        End Set
    End Property

    Public Property ListATRAN_Ranflas() As List(Of ETRAN_VehiculosRanflas)
        Get
            Return m_listATRAN_VehiculosRanflas
        End Get
        Set(ByVal value As List(Of ETRAN_VehiculosRanflas))
            m_listATRAN_VehiculosRanflas = value
        End Set
    End Property

    Public Property ListTRAN_HRanflas() As List(Of ETRAN_VehiculosRanflas)
        Get
            Return m_listHTRAN_VehiculosRanflas
        End Get
        Set(ByVal value As List(Of ETRAN_VehiculosRanflas))
            m_listHTRAN_VehiculosRanflas = value
        End Set
    End Property

    Public Property ListATRAN_Conductores() As List(Of ETRAN_VehiculosConductores)
        Get
            Return m_listATRAN_VehiculosConductores
        End Get
        Set(ByVal value As List(Of ETRAN_VehiculosConductores))
            m_listATRAN_VehiculosConductores = value
        End Set
    End Property

    Public Property ListTRAN_HConductores() As List(Of ETRAN_VehiculosConductores)
        Get
            Return m_listHTRAN_VehiculosConductores
        End Get
        Set(ByVal value As List(Of ETRAN_VehiculosConductores))
            m_listHTRAN_VehiculosConductores = value
        End Set
    End Property

    Public Property ListVMantenimiento() As List(Of ETRAN_VehiculosMantenimiento)
        Get
            Return m_listVMantenimientos
        End Get
        Set(ByVal value As List(Of ETRAN_VehiculosMantenimiento))
            m_listVMantenimientos = value
        End Set
    End Property

    Public Property ListVIncidencias() As List(Of ETRAN_VehiculosIncidencias)
        Get
            Return m_listVIncidencias
        End Get
        Set(ByVal value As List(Of ETRAN_VehiculosIncidencias))
            m_listVIncidencias = value
        End Set
    End Property

    Public Property ListVConCombustible() As List(Of ETRAN_CombustibleConsumo)
        Get
            Return m_listVConCombustible
        End Get
        Set(ByVal value As List(Of ETRAN_CombustibleConsumo))
            m_listVConCombustible = value
        End Set
    End Property

    Public Property ListVSeguros() As List(Of ETRAN_VehiculosSeguros)
        Get
            Return m_listVSeguros
        End Get
        Set(ByVal value As List(Of ETRAN_VehiculosSeguros))
            m_listVSeguros = value
        End Set
    End Property

    Public Property ListVConductores() As List(Of ETRAN_VehiculosConductores)
        Get
            Return m_listVConductores
        End Get
        Set(ByVal value As List(Of ETRAN_VehiculosConductores))
            m_listVConductores = value
        End Set
    End Property


    Public Property TIPOS_Marca() As String
        Get
            Return m_tipos_marca
        End Get
        Set(ByVal value As String)
            m_tipos_marca = value
        End Set
    End Property

    Public Property TIPOS_Vehiculo() As String
        Get
            Return m_tipos_vehiculo
        End Get
        Set(ByVal value As String)
            m_tipos_vehiculo = value
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

    Public Property ENTID_RazonSocial() As String
        Get
            Return m_entid_razonsocial
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_razonsocial) Then
                If Not m_entid_razonsocial.Equals(value) Then
                    m_entid_razonsocial = value
                End If
            Else
                m_entid_razonsocial = value
            End If
        End Set
    End Property

    Public Property TIPOS_TipoCombustible() As String
        Get
            Return m_tipos_tipocombustible
        End Get
        Set(ByVal value As String)
            m_tipos_tipocombustible = value
        End Set
    End Property

    Public Property RANFL_Placa() As String
        Get
            Return m_ranfl_placa
        End Get
        Set(ByVal value As String)
            m_ranfl_placa = value
        End Set
    End Property

    Public Property Conductor() As String
        Get
            Return m_conductor
        End Get
        Set(ByVal value As String)
            m_conductor = value
        End Set
    End Property

#End Region

#Region " Constructores "
    Public Sub New(ByVal x_tipo As Inicializacion)
        Select Case x_tipo
            Case Inicializacion.All
                m_listVRanflas = New List(Of ETRAN_VehiculosRanflas)
                m_listVMantenimientos = New List(Of ETRAN_VehiculosMantenimiento)
                m_listVIncidencias = New List(Of ETRAN_VehiculosIncidencias)
                m_listVConCombustible = New List(Of ETRAN_CombustibleConsumo)
                m_listVSeguros = New List(Of ETRAN_VehiculosSeguros)
                m_listVConductores = New List(Of ETRAN_VehiculosConductores)
            Case Inicializacion.Ranflas
                m_listVRanflas = New List(Of ETRAN_VehiculosRanflas)
                m_listHTRAN_VehiculosRanflas = New List(Of ETRAN_VehiculosRanflas)
                m_listATRAN_VehiculosRanflas = New List(Of ETRAN_VehiculosRanflas)
            Case Else
                m_listVRanflas = New List(Of ETRAN_VehiculosRanflas)
        End Select
    End Sub
#End Region

#Region " Metodos "
    Public Shared Function getEstado(ByVal x_opcion As Estado)

        Select Case x_opcion
            Case Estado.Anulado
                Return "X"
            Case Estado.Confirmado
                Return "C"
            Case Estado.Eliminado
                Return "E"
            Case Estado.Ingresado
                Return "I"
            Case Estado.Activo
                Return "A"
            Case Else
                Return "I"
        End Select

    End Function

#End Region

End Class
