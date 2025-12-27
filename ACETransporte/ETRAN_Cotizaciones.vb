Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_Cotizaciones

#Region " Variables "
    Private m_entid_cliente As String
    Private m_entid_direccion As String
   Private m_tipos_documento As String
   Private m_tipos_moneda As String
   Private m_entid_nrodocumento As String
   Private m_tipos_condicionpago As String
   Private m_listetran_cotizacionesdetalle As List(Of ETRAN_CotizacionesDetalle)

   Private m_rutas_codigo As String
   Private m_rutas_nombre As String

   Private m_viaje_id As Int64

   Enum TipoCotizacion
      CT
      PD
   End Enum

   Enum Estado
      Activo
      Inactivo
      Anulado
      Recibido
      Confirmado
      Ingresado
   End Enum

   Public Shared Function getEstado(ByVal x_opcion As Estado) As String
      Select Case x_opcion
         Case Estado.Activo
            Return "A"
         Case Estado.Anulado
            Return "X"
         Case Estado.Inactivo
            Return "N"
         Case Estado.Ingresado
            Return "I"
         Case Estado.Recibido
            Return "R"
         Case Estado.Confirmado
            Return "C"
         Case Else
            Return "I"
      End Select
   End Function

#End Region

#Region " Propiedades "
   Public Property TIPOS_CondicionPago() As String
      Get
         Return m_tipos_condicionpago
      End Get
      Set(ByVal value As String)
         m_tipos_condicionpago = value
      End Set
   End Property

   Public Property ENTID_Cliente() As String
      Get
         Return m_entid_cliente
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_cliente) Then
            If Not m_entid_cliente.Equals(value) Then
               m_entid_cliente = value
            End If
         Else
            m_entid_cliente = value
         End If
      End Set
    End Property
    Public Property ENTID_Direccion() As String
        Get
            Return m_entid_direccion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_direccion) Then
                If Not m_entid_direccion.Equals(value) Then
                    m_entid_direccion = value
                End If
            Else
                m_entid_direccion = value
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

   Public Property TIPOS_TipoMoneda() As String
      Get
         Return m_tipos_moneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_moneda) Then
            If Not m_tipos_moneda.Equals(value) Then
               m_tipos_moneda = value
            End If
         Else
            m_tipos_moneda = value
         End If
      End Set
   End Property

   Public Property ENTID_NroDocumento() As String
      Get
         Return m_entid_nrodocumento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_nrodocumento) Then
            If Not m_entid_nrodocumento.Equals(value) Then
               m_entid_nrodocumento = value
            End If
         Else
            m_entid_nrodocumento = value
         End If
      End Set
   End Property

   Public Property ListTRAN_CotizacionesDetalle() As List(Of ETRAN_CotizacionesDetalle)
      Get
         Return m_listetran_cotizacionesdetalle
      End Get
      Set(ByVal value As List(Of ETRAN_CotizacionesDetalle))
         m_listetran_cotizacionesdetalle = value
      End Set
   End Property

   Public ReadOnly Property COTIZ_CODIGO_Cod() As String
      Get
         Return m_cotiz_codigo.Substring(4)
      End Get
   End Property

   Public Property RUTAS_Codigo() As String
      Get
         Return m_rutas_codigo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_rutas_codigo) Then
            If Not m_rutas_codigo.Equals(value) Then
               m_rutas_codigo = value
            End If
         Else
            m_rutas_codigo = value
         End If
      End Set
   End Property

   Public Property RUTAS_Nombre() As String
      Get
         Return m_rutas_nombre
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_rutas_nombre) Then
            If Not m_rutas_nombre.Equals(value) Then
               m_rutas_nombre = value
            End If
         Else
            m_rutas_nombre = value
         End If
      End Set
   End Property

   Public ReadOnly Property COTIZ_ESTADO_Text() As String
      Get
         Select Case m_cotiz_estado
            Case getEstado(Estado.Activo)
               Return "Activo"
            Case getEstado(Estado.Inactivo)
               Return "Inactivo"
            Case getEstado(Estado.Recibido)
               Return "Recibido"
            Case getEstado(Estado.Anulado)
               Return "Anulado"
            Case Else
               Return "Activo"
         End Select
      End Get
   End Property

   Public Property VIAJE_Id() As Int64
      Get
         Return m_viaje_id
      End Get
      Set(ByVal value As Int64)
         m_viaje_id = value
      End Set
   End Property


#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
