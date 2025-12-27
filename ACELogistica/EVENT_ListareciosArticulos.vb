Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EVENT_ListaPreciosArticulos

#Region " Variables "
    Private m_zonas_descripcion As String
    Private m_sucur_nombre As String
    Private m_lprec_descripcion As String
    Private m_tipos_tipomoneda As String
    Private m_preci_id As Long
#End Region

#Region " Propiedades "
    Public Property ZONAS_Descripcion() As String
        Get
            Return m_zonas_descripcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_zonas_descripcion) Then
                If Not m_zonas_descripcion.Equals(value) Then
                    m_zonas_descripcion = value
                End If
            Else
                m_zonas_descripcion = value
            End If
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

    Public Property LPREC_Descripcion() As String
        Get
            Return m_lprec_descripcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_lprec_descripcion) Then
                If Not m_lprec_descripcion.Equals(value) Then
                    m_lprec_descripcion = value
                End If
            Else
                m_lprec_descripcion = value
            End If
        End Set
    End Property

    Public Property TIPOS_TipoMoneda() As String
        Get
            Return m_tipos_tipomoneda
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_tipomoneda) Then
                If Not m_tipos_tipomoneda.Equals(value) Then
                    m_tipos_tipomoneda = value
                End If
            Else
                m_tipos_tipomoneda = value
            End If
        End Set
    End Property

    Public Property PRECI_Id() As Long
        Get
            Return m_preci_id
        End Get
        Set(ByVal value As Long)
            m_preci_id = value
        End Set
    End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
