Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDIST_GuiasRemision

#Region " Campos "
    Private m_list_edist_guiasremisiondetalle As List(Of EDIST_GuiasRemisionDetalle)

    Private m_almac_descripcion As String
    Private m_pvent_origen As String
    Private m_almac_destino As String
    Private m_pvent_destino As String
    Private m_tipos_documento As String
    Private m_tipos_doccorta As String
    Private m_tipos_motivotraslado As String
    Private m_docventa As String
    Private m_fechaimpresion As DateTime
    Private m_entid_codusuario As String
    Private m_motivotraslado As Integer

    Private m_tiempo As Integer
    Private m_tiempohora As String
    Private m_generar As Boolean
    Private m_csalida As String
    Private m_numero As Integer
    Private m_guisa_numero As Integer
    Private m_doc_relacion As String
    Private m_Tipo_Doc As String


    Enum Estado
        Ingresado
        Anulado
        Eliminado
        Confirmado
    End Enum
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "
    Public Property ListDIST_GuiasRemisionDetalle() As List(Of EDIST_GuiasRemisionDetalle)
        Get
            Return m_list_edist_guiasremisiondetalle
        End Get
        Set(ByVal value As List(Of EDIST_GuiasRemisionDetalle))
            m_list_eDIST_GuiasRemisionDetalle = value
        End Set
    End Property




    Public Property ALMAC_Origen() As String
        Get
            Return m_almac_descripcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_almac_descripcion) Then
                If Not m_almac_descripcion.Equals(value) Then
                    m_almac_descripcion = value
                End If
            Else
                m_almac_descripcion = value
            End If
        End Set
    End Property

    Public Property ALMAC_Destino() As String
        Get
            Return m_almac_destino
        End Get
        Set(ByVal value As String)
            m_almac_destino = value
        End Set
    End Property


    Public Property PVENT_Destino() As String
        Get
            Return m_pvent_destino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_destino) Then
                If Not m_pvent_destino.Equals(value) Then
                    m_pvent_destino = value
                End If
            Else
                m_pvent_destino = value
            End If
        End Set
    End Property

    Public Property PVENT_Origen() As String
        Get
            Return m_pvent_origen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pvent_origen) Then
                If Not m_pvent_origen.Equals(value) Then
                    m_pvent_origen = value
                End If
            Else
                m_pvent_origen = value
            End If
        End Set
    End Property

    Public Property TIPOS_TipoDocumento() As String
        Get
            Return m_tipos_documento
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_documento) Then
                If Not m_tipos_documento.Equals(value) Then
                    m_tipos_documento = value
                End If
            Else
                m_tipos_documento = value
            End If
        End Set
    End Property

    Public Property TIPOS_TipoDocCorta() As String
        Get
            Return m_tipos_doccorta
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_doccorta) Then
                If Not m_tipos_doccorta.Equals(value) Then
                    m_tipos_doccorta = value
                End If
            Else
                m_tipos_doccorta = value
            End If
        End Set
    End Property

    Public Property TIPOS_MotivoTraslado() As String
        Get
            Return m_tipos_motivotraslado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_motivotraslado) Then
                If Not m_tipos_motivotraslado.Equals(value) Then
                    m_tipos_motivotraslado = value
                End If
            Else
                m_tipos_motivotraslado = value
            End If
        End Set
    End Property

    Public ReadOnly Property DOTRA_Estado_Text() As String
        Get
            Select Case m_guiar_estado
                Case getEstado(Estado.Ingresado)
                    Return Estado.Ingresado.ToString()
                Case getEstado(Estado.Anulado)
                    Return Estado.Anulado.ToString()
                Case getEstado(Estado.Confirmado)
                    Return Estado.Confirmado.ToString()
                Case getEstado(Estado.Eliminado)
                    Return Estado.Eliminado.ToString()
                Case Else
                    Return Estado.Ingresado.ToString()
            End Select
        End Get
    End Property

    Public ReadOnly Property Documento()
        Get
            Return String.Format("{0} {1}-{2}", m_tipos_doccorta, m_guiar_serie, m_guiar_numero.ToString().PadLeft(7, "0"))
        End Get
    End Property

    Public Property DocVenta() As String
        Get
            Return m_docventa
        End Get
        Set(ByVal value As String)
            m_docventa = value
        End Set
    End Property

    Public Property FechaImpresion() As DateTime
        Get
            Return m_fechaimpresion
        End Get
        Set(ByVal value As DateTime)
            m_fechaimpresion = value
        End Set
    End Property

    Public Property ENTID_CodUsuario() As String
        Get
            Return m_entid_codusuario
        End Get
        Set(ByVal value As String)
            m_entid_codusuario = value
        End Set
    End Property
    Public Property doc_relacion() As String '
        Get
            Return m_doc_relacion
        End Get
        Set(ByVal value As String)
            m_doc_relacion = value
        End Set
    End Property

    Public Property Tipo_doc() As String
        Get
            Return m_Tipo_Doc
        End Get
        Set(ByVal value As String)
            m_Tipo_Doc = value
        End Set
    End Property

    Public Property MotivoTraslado() As Integer
        Get
            Return m_motivotraslado
        End Get
        Set(ByVal value As Integer)
            m_motivotraslado = value
        End Set
    End Property

    Public ReadOnly Property Cliente() As String
        Get
            Return String.Format("{0} - {1}", m_entid_codigocliente, m_guiar_descripcioncliente)
        End Get
    End Property

    Public Property Tiempo() As Integer
        Get
            Return m_tiempo
        End Get
        Set(ByVal value As Integer)
            m_tiempo = value
        End Set
    End Property

    Public Property TiempoHora() As String
        Get
            Return m_tiempohora
        End Get
        Set(ByVal value As String)
            m_tiempohora = value
        End Set
    End Property

    Public Property Generar() As Boolean
        Get
            Return m_generar
        End Get
        Set(ByVal value As Boolean)
            m_generar = value
        End Set
    End Property

    Public Property CSalida() As String
        Get
            Return m_csalida
        End Get
        Set(ByVal value As String)
            m_csalida = value
        End Set
    End Property

    Public Property Numero() As Integer
        Get
            Return m_numero
        End Get
        Set(ByVal value As Integer)
            m_numero = value
        End Set
    End Property

    Public Property GUISA_Numero() As Integer
        Get
            Return m_guisa_numero
        End Get
        Set(ByVal value As Integer)
            m_guisa_numero = value
        End Set
    End Property
#End Region

#Region " Eventos "

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
            Case Else
                Return "I"
        End Select

    End Function
#End Region
End Class


