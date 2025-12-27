Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_Caja

#Region " Campos "
    Enum Estado
        Ingresado
        Anulado
        Eliminado
        Confirmado
    End Enum

    Private m_tipos_tipomoneda As String
    Private m_recib_codigo As String
    Private m_caja_glosaimporte As String
    Private m_documento As String
    Private m_tipos_transaccion As String
    Private m_usuario As String
    Private m_glosa As String
    Private m_dpago_fecha As DateTime
    Private m_tipos_tipodocumento As String
    Private m_docve_fechadocumento As DateTime

    Private m_caja_importedolares As Decimal
    Private m_caja_importesoles As Decimal
    Private m_dpago_id As Long

    Private m_tipoc_facturaventasunat As Decimal
    Private m_tipoc_facturaventarenta As Decimal
    Private m_tipoc_cajaventasunat As Decimal
    Private m_tipoc_cajaventarenta As Decimal

    Private m_recib_impresa As Boolean
    Private m_recib_impresiones As Short
    Private m_recib_documento As String
    Private m_recib_nombre As String
    Private m_recib_direccion As String
    Private m_recib_de As String

    Private m_vent_docsventa As EVENT_DocsVenta
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "
    Public Property TIPOS_TipoMoneda() As String
        Get
            Return m_tipos_tipomoneda
        End Get
        Set(ByVal value As String)
            m_tipos_tipomoneda = value
        End Set
    End Property

    Public Property RECIB_Codigo() As String
        Get
            Return m_recib_codigo
        End Get
        Set(ByVal value As String)
            m_recib_codigo = value
        End Set
    End Property

    Public Property CAJA_GlosaImporte() As String
        Get
            Return m_caja_glosaimporte
        End Get
        Set(ByVal value As String)
            m_caja_glosaimporte = value
        End Set
    End Property

    Public Property Documento() As String
        Get
            Return m_documento
        End Get
        Set(ByVal value As String)
            m_documento = value
        End Set
    End Property

    Public Property TIPOS_Transaccion() As String
        Get
            Return m_tipos_transaccion
        End Get
        Set(ByVal value As String)
            m_tipos_transaccion = value
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

    Public Property Glosa() As String
        Get
            Return m_glosa
        End Get
        Set(ByVal value As String)
            m_glosa = value
        End Set
    End Property

    Public Property DPAGO_Fecha() As DateTime
        Get
            Return m_dpago_fecha
        End Get
        Set(ByVal value As DateTime)
            m_dpago_fecha = value
        End Set
    End Property

    Public Property TIPOS_TipoDocumento() As String
        Get
            Return m_tipos_tipodocumento
        End Get
        Set(ByVal value As String)
            m_tipos_tipodocumento = value
        End Set
    End Property

    Public Property DOCVE_FechaDocumento() As DateTime
        Get
            Return m_docve_fechadocumento
        End Get
        Set(ByVal value As DateTime)
            m_docve_fechadocumento = value
        End Set
    End Property

    Public ReadOnly Property CAJA_Estado_Text() As String
        Get
            If Not IsNothing(m_caja_estado) Then
                Select Case m_caja_estado
                    Case getEstado(Estado.Anulado)
                        Return Estado.Anulado.ToString()
                    Case getEstado(Estado.Ingresado)
                        Return Estado.Ingresado.ToString()
                    Case Else
                        Return Estado.Ingresado.ToString()
                End Select
            Else
                Return ""
            End If
        End Get
    End Property

    Public Property CAJA_ImporteSoles() As Decimal
        Get
            Return m_caja_importesoles
        End Get
        Set(ByVal value As Decimal)
            m_caja_importesoles = value
        End Set
    End Property

    Public Property CAJA_ImporteDolares() As Decimal
        Get
            Return m_caja_importedolares
        End Get
        Set(ByVal value As Decimal)
            m_caja_importedolares = value
        End Set
    End Property

    Public Property DPAGO_Id() As Long
        Get
            Return m_dpago_id
        End Get
        Set(ByVal value As Long)
            m_dpago_id = value
        End Set
    End Property

    Public Property TIPOC_FacturaVentaSunat() As Decimal
        Get
            Return m_tipoc_facturaventasunat
        End Get
        Set(ByVal value As Decimal)
            m_tipoc_facturaventasunat = value
        End Set
    End Property

    Public Property TIPOC_FacturaVentaRenta() As Decimal
        Get
            Return m_tipoc_facturaventarenta
        End Get
        Set(ByVal value As Decimal)
            m_tipoc_facturaventarenta = value
        End Set
    End Property

    Public Property TIPOC_CajaVentaSunat() As Decimal
        Get
            Return m_tipoc_cajaventasunat
        End Get
        Set(ByVal value As Decimal)
            m_tipoc_cajaventasunat = value
        End Set
    End Property

    Public Property TIPOC_CajaVentaRenta() As Decimal
        Get
            Return m_tipoc_cajaventarenta
        End Get
        Set(ByVal value As Decimal)
            m_tipoc_cajaventarenta = value
        End Set
    End Property

    Public Property VENT_DocsVenta() As EVENT_DocsVenta
        Get
            Return m_vent_docsventa
        End Get
        Set(ByVal value As EVENT_DocsVenta)
            m_vent_docsventa = value
        End Set
    End Property

    Public Property RECIB_Impresa() As Boolean
        Get
            Return m_recib_impresa
        End Get
        Set(ByVal value As Boolean)
            m_recib_impresa = value
        End Set
    End Property

    Public Property RECIB_Impresiones() As Short
        Get
            Return m_recib_impresiones
        End Get
        Set(ByVal value As Short)
            m_recib_impresiones = value
        End Set
    End Property

    Public Property RECIB_Documento() As String
        Get
            Return m_recib_documento
        End Get
        Set(ByVal value As String)
            m_recib_documento = value
        End Set
    End Property

    Public Property RECIB_Direccion() As String
        Get
            Return m_recib_direccion
        End Get
        Set(ByVal value As String)
            m_recib_direccion = value
        End Set
    End Property

    Public Property RECIB_Nombre() As String
        Get
            Return m_recib_nombre
        End Get
        Set(ByVal value As String)
            m_recib_nombre = value
        End Set
    End Property

    Public Property RECIB_De() As String
        Get
            Return m_recib_de
        End Get
        Set(ByVal value As String)
            m_recib_de = value
        End Set
    End Property

    
    'Public Property RECIB_De() As String
    '    Get
    '        Return m_recib_de
    '    End Get
    '    Set(ByVal value As String)
    '        m_recib_de = value
    '    End Set
    'End Property


#End Region

#Region " Eventos "

#End Region

#Region " Metodos "
    Public Shared Function getEstado(ByVal x_opcion As Estado) As String
        Select Case x_opcion
            Case Estado.Anulado
                Return "X"
            Case Estado.Confirmado
                Return "C"
            Case Estado.Eliminado
                Return "E"
            Case Estado.Ingresado
                Return "I"
            Case Else
                Return "I"
        End Select

    End Function
#End Region

End Class

