Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework


Public Class ETRANGUIAS_Tipos
    Implements ICloneable

#Region " Variables "
    Private m_tipoid As Long
    Private m_tipos_generalfk As Long
    Private m_tipo_descripcion As String
    Private m_tipo_abreviatura As String
    Private m_tipo_codsunat As String
    Private m_tipo_estado As Long
    Private m_tipo_feccrea As DateTime
    Private m_tipo_user_creacion As Long
    Private m_tipo_fec_modificacion As DateTime
    Private m_tipos_user_modificacion As Long


    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean

    Private m_hash As Hashtable
#End Region
    Public Sub New()

        Try
            Dim _obj As Object = ACEAppMovil.My.Resources.xmlETRANGUIAS_Tipos
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
#Region " Propiedades "
    'Public ReadOnly Property TIPOS_CODTIPO() As String
    '    Get
    '        Return m_tipos_codigo.Substring(3)
    '    End Get
    'End Property

#End Region

    '==============****************************************************************************************

#Region " Constructores "
    'Public Sub New(ByVal x_tipos_codigo As String, ByVal x_tipos_descripcion As String)
    '    Me.m_tipos_codigo = x_tipos_codigo
    '    Me.m_tipos_descripcion = x_tipos_descripcion
    'End Sub
#End Region

    Public Function Clone() As Object Implements ICloneable.Clone
        Try
            Dim cloneInstance As New ETRANGUIAS_Tipos()
            cloneInstance = CType(Me, ETRANGUIAS_Tipos)
            Return cloneInstance.MemberwiseClone
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Property TipoId() As Long
        Get
            Return m_tipoid
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_tipoid) Then
                If Not m_tipoid.Equals(value) Then
                    m_tipoid = value
                    OnTipoIdChanged(m_tipoid, EventArgs.Empty)
                End If
            Else
                m_tipoid = value
                OnTipoIdChanged(m_tipoid, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TiposGeneralFk() As Long
        Get
            Return m_tipos_generalfk
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_tipos_generalfk) Then
                If Not m_tipos_generalfk.Equals(value) Then
                    m_tipos_generalfk = value
                    OnTiposGeneralFkChanged(m_tipos_generalfk, EventArgs.Empty)
                End If
            Else
                m_tipos_generalfk = value
                OnTiposGeneralFkChanged(m_tipos_generalfk, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TipoDescripcion() As String
        Get
            Return m_tipo_descripcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipo_descripcion) Then
                If Not m_tipo_descripcion.Equals(value) Then
                    m_tipo_descripcion = value
                    OnTipoDescripcionChanged(m_tipo_descripcion, EventArgs.Empty)
                End If
            Else
                m_tipo_descripcion = value
                OnTipoDescripcionChanged(m_tipo_descripcion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TipoAbreviatura() As String
        Get
            Return m_tipo_abreviatura
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipo_abreviatura) Then
                If Not m_tipo_abreviatura.Equals(value) Then
                    m_tipo_abreviatura = value
                    OnTipoAbreviaturaChanged(m_tipo_abreviatura, EventArgs.Empty)
                End If
            Else
                m_tipo_abreviatura = value
                OnTipoAbreviaturaChanged(m_tipo_abreviatura, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TipoCodSUNAT() As String
        Get
            Return m_tipo_codsunat
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipo_codsunat) Then
                If Not m_tipo_codsunat.Equals(value) Then
                    m_tipo_codsunat = value
                    OnTìpoCodSunatChanged(m_tipo_codsunat, EventArgs.Empty)
                End If
            Else
                m_tipo_codsunat = value
                OnTìpoCodSunatChanged(m_tipo_codsunat, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TipoEstado() As Long
        Get
            Return m_tipo_estado
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_tipo_estado) Then
                If Not m_tipo_estado.Equals(value) Then
                    m_tipo_estado = value
                    OnTipoEstadoChanged(m_tipo_estado, EventArgs.Empty)
                End If
            Else
                m_tipo_estado = value
                OnTipoEstadoChanged(m_tipo_estado, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TipoFecCreacion() As DateTime
        Get
            Return m_tipo_feccrea
        End Get
        Set(ByVal value As DateTime)
            If Not IsNothing(m_tipo_feccrea) Then
                If Not m_tipo_feccrea.Equals(value) Then
                    m_tipo_feccrea = value
                    OnTipoFecCreacionChanged(m_tipo_feccrea, EventArgs.Empty)
                End If
            Else
                m_tipo_feccrea = value
                OnTipoFecCreacionChanged(m_tipo_feccrea, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TipoUsrCreacion() As Boolean
        Get
            Return m_tipo_user_creacion
        End Get
        Set(ByVal value As Boolean)
            If Not m_tipo_user_creacion.Equals(value) Then
                m_tipo_user_creacion = value
                OnTipoUsrCreacionChanged(m_tipo_user_creacion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TipoFecModificacion() As DateTime
        Get
            Return m_tipo_fec_modificacion
        End Get
        Set(ByVal value As DateTime)
            If Not IsNothing(m_tipo_fec_modificacion) Then
                If Not m_tipo_fec_modificacion.Equals(value) Then
                    m_tipo_fec_modificacion = value
                    OnTipoFecModificacionChanged(m_tipo_fec_modificacion, EventArgs.Empty)
                End If
            Else
                m_tipo_fec_modificacion = value
                OnTipoFecModificacionChanged(m_tipo_fec_modificacion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TipoUsrModificacion() As Long
        Get
            Return m_tipos_user_modificacion
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_tipos_user_modificacion) Then
                If Not m_tipos_user_modificacion.Equals(value) Then
                    m_tipos_user_modificacion = value
                    OnTipoUsrModificacionChanged(m_tipos_user_modificacion, EventArgs.Empty)
                End If
            Else
                m_tipos_user_modificacion = value
                OnTipoUsrModificacionChanged(m_tipos_user_modificacion, EventArgs.Empty)
            End If
        End Set
    End Property



#Region " Propiedades de Solo Lectura "

    Public ReadOnly Property Nuevo() As Boolean
        Get
            Return m_nuevo
        End Get
    End Property

    Public ReadOnly Property Modificado() As Boolean
        Get
            Return m_modificado
        End Get
    End Property

    Public ReadOnly Property Eliminado() As Boolean
        Get
            Return m_eliminado
        End Get
    End Property

    Public ReadOnly Property Hash() As Hashtable
        Get
            Return m_hash
        End Get
    End Property

    Public Shared ReadOnly Property Tabla() As String
        Get
            Return "TRANGUIAS_Tipos"
        End Get
    End Property

    Public Shared ReadOnly Property Esquema() As String
        Get
            Return "TransportesGuias"
        End Get
    End Property

#End Region


    'Eventos 

    Public Event TipoIdChanged As EventHandler
    Public Event TiposGeneralFkChanged As EventHandler
    Public Event TipoDescripcionChanged As EventHandler
    Public Event TipoAbreviaturaChanged As EventHandler

    Public Event TìpoCodSunatChanged As EventHandler
    Public Event TipoEstadoChanged As EventHandler
    Public Event TipoFecCreacionChanged As EventHandler
    Public Event TipoUsrCreacionChanged As EventHandler

    Public Event TipoFecModificacionChanged As EventHandler

    Public Event TipoUsrModificacionChanged As EventHandler



    'Changed 

    Public Sub OnTipoIdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TipoIdChanged(sender, e)
    End Sub
    Public Sub OnTiposGeneralFkChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TiposGeneralFkChanged(sender, e)
    End Sub

    Public Sub OnTipoDescripcionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TipoDescripcionChanged(sender, e)
    End Sub

    Public Sub OnTipoAbreviaturaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TipoAbreviaturaChanged(sender, e)
    End Sub

    Public Sub OnTìpoCodSunatChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TìpoCodSunatChanged(sender, e)
    End Sub
    Public Sub OnTipoEstadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TipoEstadoChanged(sender, e)
    End Sub

    Public Sub OnTipoFecCreacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TipoFecCreacionChanged(sender, e)
    End Sub
    Public Sub OnTipoUsrCreacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TipoUsrCreacionChanged(sender, e)
    End Sub

    Public Sub OnTipoFecModificacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TipoFecModificacionChanged(sender, e)
    End Sub


    Public Sub OnTipoUsrModificacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TipoUsrModificacionChanged(sender, e)
    End Sub


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


    'Public Shared Function getTipoDocumento(ByVal x_opcion As TipoDocumento) As String
    '    Dim x_tipo As String
    '    Try
    '        x_tipo = getCodTipo(MyTipos.TipoDocComprobante)
    '        Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return x_tipo
    'End Function


    'Public Shared Function getTipoDevCajaChica(ByVal x_opcion As TipoDevCajaChica) As String
    '    Dim x_tipo As String
    '    Try
    '        x_tipo = getCodTipo(MyTipos.TipoDevCajaChica)
    '        Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return x_tipo
    'End Function

    '    Public Shared Function getTipoDocPago(ByVal x_opcion As TipoDocPago) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoDocumentoPago)
    '            Return String.Format("{0}{1:00}", x_tipo, CType(x_opcion, Integer))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipoDePago(ByVal x_opcion As TipoDePago) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoPago)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipoDocTraslado(ByVal x_opcion As TipoDocsTraslado) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoDocComprobante)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTiposOrdenProducion(ByVal x_opcion As TiposOrdenProducion) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TiposOrdenProducion)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function
    '    Public Shared Function getTiposPedidoTransformacion(ByVal x_opcion As TiposPedidoTransformacion) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TiposPedidoTransformacion)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function
    '    Public Shared Function getTiposPendCajaChica(ByVal x_opcion As TiposPendienteCajaChica) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TiposPendienteCajaChica)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function
    '    Public Shared Function getTiposTransformacion(ByVal x_opcion As TiposTransformacion) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TiposTransformacion)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipoOrigen(ByVal x_opcion As OrigenCancelacion) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.OrigenCancelacion)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    ''' <summary>
    '    ''' Tipo de Pago
    '    ''' </summary>
    '    ''' <param name="x_opcion"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function getCondicionPago(ByVal x_opcion As TipoPago) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.CondicionPago)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function
    '    ''' <summary>
    '    ''' Tipo de Consumo - Transportes
    '    ''' </summary>
    '    ''' <param name="x_opcion"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function getTipoConsumo(ByVal x_opcion As TipoPago) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoConsumo)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    ''' <summary>
    '    ''' Motivo de Traslado
    '    ''' </summary>
    '    ''' <param name="x_opcion"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function getMotivoTraslado(ByVal x_opcion As MotivoTraslado) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.MotivoTraslado)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

    '    Public Shared Function getTipoOrdenRecojo(ByVal x_opcion As TipoOrdenRecojo) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoOrdenRecojo)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getMotivoNotaCredito(ByVal x_opcion As MotivoNotaCredito) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.MotivoNotaCredito)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("000"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getMotivoNotaDebito(ByVal x_opcion As MotivoNotaDebito) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.MotivoNotaDebito)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("000"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipoArreglo(ByVal x_opcion As TArreglo) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoDeArreglo)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo_TRAN_OrigenDocCompra(ByVal x_opcion As TTRAN_TipoOrigenCompra) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TRAN_TipoOrigenCompra)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '#End Region

    '#Region " Tipos como Funciones GetTipo"

    '    ''' <summary>
    '    ''' Documentos de Identidad
    '    ''' </summary>
    '    ''' <param name="x_opcion"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function getTipo(ByVal x_opcion As TipoDocumentoIdentidad) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.DocumentoIndentidad)
    '            Select Case x_opcion
    '                Case TipoDocumentoIdentidad.Otros
    '                    Return String.Format("{0}0", x_tipo)
    '                Case TipoDocumentoIdentidad.DNI
    '                    Return String.Format("{0}1", x_tipo)
    '                Case TipoDocumentoIdentidad.CarnetExtranjeria
    '                    Return String.Format("{0}4", x_tipo)
    '                Case TipoDocumentoIdentidad.RUC
    '                    Return String.Format("{0}6", x_tipo)
    '                Case TipoDocumentoIdentidad.Pasaporte
    '                    Return String.Format("{0}7", x_tipo)
    '            End Select
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    ''' <summary>
    '    ''' Tipo de Moneda
    '    ''' </summary>
    '    ''' <param name="x_opcion"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function getTipo(ByVal x_opcion As TipoMoneda) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoMoneda)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function
    '    ''' <summary>
    '    ''' Tipo Porcentaje Descuento
    '    ''' </summary>
    '    ''' <param name="x_opcion"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function getTipo(ByVal x_opcion As TipoPorcentajeDescuento) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoPorcentajeDescuento)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    ''' <summary>
    '    ''' Tipo de Moneda
    '    ''' </summary>
    '    ''' <param name="x_opcion"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function getTipo(ByVal x_opcion As TipoEntidadRelacion) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoEntidadRelacion)
    '            Return String.Format("{0}{1:00}", x_tipo, CType(x_opcion, Integer))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    ''' <summary>
    '    ''' Tipo de Costeo
    '    ''' </summary>
    '    ''' <param name="x_opcion"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function getTipo(ByVal x_opcion As TipoCosteo) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoCosteo)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    ''' <summary>
    '    ''' Tipo destino
    '    ''' </summary>
    '    ''' <param name="x_opcion"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function getTipo(ByVal x_opcion As TipoDestino) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoDestinoArticulo)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TipoAuditoria) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.Auditoria)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("000"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TipoGasto) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoGasto)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TipoRecibo) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoRecibo)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TBanco) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.EntidadFinanciera)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TCuentaBancaria) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoCuentaBancaria)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TipoDePago) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoPago)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As OrigenCotizacion) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.OrigenCotizacion)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function


    '    Public Shared Function getTipo(ByVal x_opcion As TPercepcion) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoPercepcion)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TransaccionTRecibos) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TransaccionTRecibos)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TOrigenDeGuias) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.OrigenDeGuias)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function


    '    Public Shared Function getTipo(ByVal x_opcion As TMovimientoStock) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TipoMovimientoStock)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TiposPedidoTransformacion) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TiposPedidoTransformacion)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function

    '    Public Shared Function getTipo(ByVal x_opcion As TiposTransformacion) As String
    '        Dim x_tipo As String
    '        Try
    '            x_tipo = getCodTipo(MyTipos.TiposTransformacion)
    '            Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '        Return x_tipo
    '    End Function




End Class
