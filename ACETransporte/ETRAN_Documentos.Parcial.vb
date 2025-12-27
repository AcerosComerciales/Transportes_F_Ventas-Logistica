Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Documentos

#Region " Campos "

    Private m_docus_codigo As String
    Private m_entid_codigo As String
    Private m_tipos_codtipomoneda As String
    Private m_tipos_codtipodocumento As String
    Private m_docus_id As Long
    Private m_docus_serie As String
    Private m_docus_numero As Integer
    Private m_docus_fecha As Date
    Private m_docus_fechacancelacion As Date
    Private m_docus_importe As Decimal
    Private m_docus_importeigv As Decimal
    Private m_docus_totalpago As Decimal
    Private m_docus_tipocambio As Decimal
    Private m_docus_estado As String
    Private m_docus_motivoanulacion As String
    Private m_docus_incigv As Boolean
    Private m_tipos_codtipoorigen As String
    Private m_pvent_id As Long
    Private m_docus_fechaingreso As Date
    Private m_docus_usrcrea As String
    Private m_docus_feccrea As Date
    Private m_docus_usrmod As String
    Private m_docus_fecmod As Date
    Private m_nuevo As Boolean
    Private m_modificado As Boolean
    Private m_eliminado As Boolean

    Private m_hash As Hashtable
#End Region

#Region " Constructores "

    Public Sub New()

        Try
            Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_Documentos
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

    Public Property DOCUS_Codigo() As String
        Get
            Return m_docus_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docus_codigo) Then
                If Not m_docus_codigo.Equals(value) Then
                    m_docus_codigo = value
                    OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
                End If
            Else
                m_docus_codigo = value
                OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ENTID_Codigo() As String
        Get
            Return m_entid_codigo
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

    Public Property TIPOS_CodTipoMoneda() As String
        Get
            Return m_tipos_codtipomoneda
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

    Public Property TIPOS_CodTipoDocumento() As String
        Get
            Return m_tipos_codtipodocumento
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codtipodocumento) Then
                If Not m_tipos_codtipodocumento.Equals(value) Then
                    m_tipos_codtipodocumento = value
                    OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
                End If
            Else
                m_tipos_codtipodocumento = value
                OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_Id() As Long
        Get
            Return m_docus_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_docus_id) Then
                If Not m_docus_id.Equals(value) Then
                    m_docus_id = value
                    OnDOCUS_IdChanged(m_docus_id, EventArgs.Empty)
                End If
            Else
                m_docus_id = value
                OnDOCUS_IdChanged(m_docus_id, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_Serie() As String
        Get
            Return m_docus_serie
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docus_serie) Then
                If Not m_docus_serie.Equals(value) Then
                    m_docus_serie = value
                    OnDOCUS_SerieChanged(m_docus_serie, EventArgs.Empty)
                End If
            Else
                m_docus_serie = value
                OnDOCUS_SerieChanged(m_docus_serie, EventArgs.Empty)
            End If
        End Set
    End Property


    Public Property DOCUS_Numero() As Integer
        Get
            Return m_docus_numero
        End Get
        Set(ByVal value As Integer)
            If Not IsNothing(m_docus_numero) Then
                If Not m_docus_numero.Equals(value) Then
                    m_docus_numero = value
                    OnDOCUS_NumeroChanged(m_docus_numero, EventArgs.Empty)
                End If
            Else
                m_docus_numero = value
                OnDOCUS_NumeroChanged(m_docus_numero, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_Fecha() As Date
        Get
            Return m_docus_fecha
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_docus_fecha) Then
                If Not m_docus_fecha.Equals(value) Then
                    m_docus_fecha = value
                    OnDOCUS_FechaChanged(m_docus_fecha, EventArgs.Empty)
                End If
            Else
                m_docus_fecha = value
                OnDOCUS_FechaChanged(m_docus_fecha, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_FechaCancelacion() As Date
        Get
            Return m_docus_fechacancelacion
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_docus_fechacancelacion) Then
                If Not m_docus_fechacancelacion.Equals(value) Then
                    m_docus_fechacancelacion = value
                    OnDOCUS_FechaCancelacionChanged(m_docus_fechacancelacion, EventArgs.Empty)
                End If
            Else
                m_docus_fechacancelacion = value
                OnDOCUS_FechaCancelacionChanged(m_docus_fechacancelacion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_Importe() As Decimal
        Get
            Return m_docus_importe
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docus_importe) Then
                If Not m_docus_importe.Equals(value) Then
                    m_docus_importe = value
                    OnDOCUS_ImporteChanged(m_docus_importe, EventArgs.Empty)
                End If
            Else
                m_docus_importe = value
                OnDOCUS_ImporteChanged(m_docus_importe, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_ImporteIGV() As Decimal
        Get
            Return m_docus_importeigv
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docus_importeigv) Then
                If Not m_docus_importeigv.Equals(value) Then
                    m_docus_importeigv = value
                    OnDOCUS_ImporteIGVChanged(m_docus_importeigv, EventArgs.Empty)
                End If
            Else
                m_docus_importeigv = value
                OnDOCUS_ImporteIGVChanged(m_docus_importeigv, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_TotalPago() As Decimal
        Get
            Return m_docus_totalpago
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docus_totalpago) Then
                If Not m_docus_totalpago.Equals(value) Then
                    m_docus_totalpago = value
                    OnDOCUS_TotalPagoChanged(m_docus_totalpago, EventArgs.Empty)
                End If
            Else
                m_docus_totalpago = value
                OnDOCUS_TotalPagoChanged(m_docus_totalpago, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_TipoCambio() As Decimal
        Get
            Return m_docus_tipocambio
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docus_tipocambio) Then
                If Not m_docus_tipocambio.Equals(value) Then
                    m_docus_tipocambio = value
                    OnDOCUS_TipoCambioChanged(m_docus_tipocambio, EventArgs.Empty)
                End If
            Else
                m_docus_tipocambio = value
                OnDOCUS_TipoCambioChanged(m_docus_tipocambio, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_Estado() As String
        Get
            Return m_docus_estado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docus_estado) Then
                If Not m_docus_estado.Equals(value) Then
                    m_docus_estado = value
                    OnDOCUS_EstadoChanged(m_docus_estado, EventArgs.Empty)
                End If
            Else
                m_docus_estado = value
                OnDOCUS_EstadoChanged(m_docus_estado, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCUS_MotivoAnulacion() As String
        Get
            Return m_docus_motivoanulacion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docus_motivoanulacion) Then
                If Not m_docus_motivoanulacion.Equals(value) Then
                    m_docus_motivoanulacion = value
                    OnDOCUS_MotivoAnulacionChanged(m_docus_motivoanulacion, EventArgs.Empty)
                End If
            Else
                m_docus_motivoanulacion = value
                OnDOCUS_MotivoAnulacionChanged(m_docus_motivoanulacion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCUS_IncIGV() As Boolean
        Get
            Return m_docus_incigv
        End Get
        Set(ByVal value As Boolean)
            If Not m_docus_incigv.Equals(value) Then
                m_docus_incigv = value
                OnDOCUS_IncIGVChanged(m_docus_incigv, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TIPOS_CodTipoOrigen() As String
        Get
            Return m_tipos_codtipoorigen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_codtipoorigen) Then
                If Not m_tipos_codtipoorigen.Equals(value) Then
                    m_tipos_codtipoorigen = value
                    OnTIPOS_CodTipoOrigenChanged(m_tipos_codtipoorigen, EventArgs.Empty)
                End If
            Else
                m_tipos_codtipoorigen = value
                OnTIPOS_CodTipoOrigenChanged(m_tipos_codtipoorigen, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PVENT_Id() As Long
        Get
            Return m_pvent_id
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

    Public Property DOCUS_FechaIngreso() As Date
        Get
            Return m_docus_fechaingreso
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_docus_fechaingreso) Then
                If Not m_docus_fechaingreso.Equals(value) Then
                    m_docus_fechaingreso = value
                    OnDOCUS_FechaIngresoChanged(m_docus_fechaingreso, EventArgs.Empty)
                End If
            Else
                m_docus_fechaingreso = value
                OnDOCUS_FechaIngresoChanged(m_docus_fechaingreso, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCUS_UsrCrea() As String
        Get
            Return m_docus_usrcrea
        End Get
        Set(ByVal value As String)
            m_docus_usrcrea = value
        End Set
    End Property

    Public Property DOCUS_FecCrea() As Date
        Get
            Return m_docus_feccrea
        End Get
        Set(ByVal value As Date)
            m_docus_feccrea = value
        End Set
    End Property

    Public Property DOCUS_UsrMod() As String
        Get
            Return m_docus_usrmod
        End Get
        Set(ByVal value As String)
            m_docus_usrmod = value
        End Set
    End Property

    Public Property DOCUS_FecMod() As Date
        Get
            Return m_docus_fecmod
        End Get
        Set(ByVal value As Date)
            m_docus_fecmod = value
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
            Return "TRAN_Documentos"
        End Get
    End Property

    Public Shared ReadOnly Property Esquema() As String
        Get
            Return "Transportes"
        End Get
    End Property

#End Region

#End Region

#Region " Eventos "

    Public Event DOCUS_CodigoChanged As EventHandler
    Public Event ENTID_CodigoChanged As EventHandler
    Public Event TIPOS_CodTipoMonedaChanged As EventHandler
    Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
    Public Event DOCUS_IdChanged As EventHandler
    Public Event DOCUS_SerieChanged As EventHandler
    Public Event DOCUS_NumeroChanged As EventHandler
    Public Event DOCUS_FechaChanged As EventHandler
    Public Event DOCUS_FechaCancelacionChanged As EventHandler
    Public Event DOCUS_ImporteChanged As EventHandler
    Public Event DOCUS_ImporteIGVChanged As EventHandler
    Public Event DOCUS_TotalPagoChanged As EventHandler
    Public Event DOCUS_TipoCambioChanged As EventHandler
    Public Event DOCUS_EstadoChanged As EventHandler
    Public Event DOCUS_MotivoAnulacionChanged As EventHandler
    Public Event DOCUS_IncIGVChanged As EventHandler
    Public Event TIPOS_CodTipoOrigenChanged As EventHandler
    Public Event PVENT_IdChanged As EventHandler
    Public Event DOCUS_FechaIngresoChanged As EventHandler

    Public Sub OnDOCUS_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_CodigoChanged(sender, e)
    End Sub

    Public Sub OnENTID_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_CodigoChanged(sender, e)
    End Sub

    Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
    End Sub

    Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_IdChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_SerieChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_SerieChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_NumeroChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_NumeroChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_FechaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_FechaChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_FechaCancelacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_FechaCancelacionChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_ImporteChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_ImporteChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_ImporteIGVChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_ImporteIGVChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_TotalPagoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_TotalPagoChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_TipoCambioChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_TipoCambioChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_EstadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_EstadoChanged(sender, e)
    End Sub
    Public Sub OnDOCUS_MotivoAnulacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_MotivoAnulacionChanged(sender, e)
    End Sub
    Public Sub OnDOCUS_IncIGVChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_IncIGVChanged(sender, e)
    End Sub

    Public Sub OnTIPOS_CodTipoOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoOrigenChanged(sender, e)
    End Sub

    Public Sub OnPVENT_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PVENT_IdChanged(sender, e)
    End Sub

    Public Sub OnDOCUS_FechaIngresoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCUS_FechaIngresoChanged(sender, e)
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


