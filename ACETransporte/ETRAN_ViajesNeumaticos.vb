Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_ViajesNeumaticos

#Region " Variables "
   Private m_neuma_codigo As String
   Private m_neuma_modelo As String
   Private m_neuma_tamano As String
   Private m_tipos_marca As String
   Private m_tipos_tipollanta As String

   Private m_vneum_lado As String
   Private m_vneum_seccion As String
   Private m_vneum_ordenposicion As Short
   Private m_vneum_internoexterno As String
   Private m_listIncidencias As List(Of ETRAN_NeumaticosIncidencias)
    Private m_listViajeNeumaticos As List(Of ETRAN_ViajesNeumaticos)
    Private m_listViajeNeumaticos_N As List(Of ETRAN_Neumaticos)


    Private m_viaje_codigo As String
   Private m_viaje_fecsalida As Date
   Private m_viaje_fecllegada As Date
   Private m_viaje_descripcion As String

   Private m_vehic_id As Long
   Private m_ranfl_id As Long
#End Region

#Region " Propiedades "
   Public Property NEUMA_Codigo() As String
      Get
         Return m_neuma_codigo.Substring(4)
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_neuma_codigo) Then
            If Not m_neuma_codigo.Equals(value) Then
               m_neuma_codigo = value
            End If
         Else
            m_neuma_codigo = value
         End If
      End Set
   End Property

   Public Property NEUMA_Modelo() As String
      Get
         Return m_neuma_modelo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_neuma_modelo) Then
            If Not m_neuma_modelo.Equals(value) Then
               m_neuma_modelo = value
            End If
         Else
            m_neuma_modelo = value
         End If
      End Set
   End Property

   Public Property NEUMA_Tamano() As String
      Get
         Return m_neuma_tamano
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_neuma_tamano) Then
            If Not m_neuma_tamano.Equals(value) Then
               m_neuma_tamano = value
            End If
         Else
            m_neuma_tamano = value
         End If
      End Set
   End Property

   Public Property TIPOS_Marca() As String
      Get
         Return m_tipos_marca
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_marca) Then
            If Not m_tipos_marca.Equals(value) Then
               m_tipos_marca = value
            End If
         Else
            m_tipos_marca = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoLlanta() As String
      Get
         Return m_tipos_tipollanta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipollanta) Then
            If Not m_tipos_tipollanta.Equals(value) Then
               m_tipos_tipollanta = value
            End If
         Else
            m_tipos_tipollanta = value
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

    Public Property ListTRAN_IncidenciasNeumaticos() As List(Of ETRAN_NeumaticosIncidencias)
        Get
            Return m_listIncidencias
        End Get
        Set(ByVal value As List(Of ETRAN_NeumaticosIncidencias))
            m_listIncidencias = value
        End Set
    End Property


    Public Property ListTRAN_Viajes_Neumaticos() As List(Of ETRAN_ViajesNeumaticos)
        Get
            Return m_listViajeNeumaticos
        End Get
        Set(ByVal value As List(Of ETRAN_ViajesNeumaticos))
            m_listViajeNeumaticos = value
        End Set
    End Property



    Public Property ListTRAN_Viajes_Neumaticos_N() As List(Of ETRAN_Neumaticos)
        Get
            Return m_listViajeNeumaticos_N
        End Get
        Set(ByVal value As List(Of ETRAN_Neumaticos))
            m_listViajeNeumaticos_N = value
        End Set
    End Property

    Public Property VIAJE_Codigo() As String
      Get
         Return m_viaje_codigo.Substring(4)
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_viaje_codigo) Then
            If Not m_viaje_codigo.Equals(value) Then
               m_viaje_codigo = value
            End If
         Else
            m_viaje_codigo = value
         End If
      End Set
   End Property

   Public Property VIAJE_FecSalida() As Date
      Get
         Return m_viaje_fecsalida
      End Get
      Set(ByVal value As Date)
         If Not IsNothing(m_viaje_fecsalida) Then
            If Not m_viaje_fecsalida.Equals(value) Then
               m_viaje_fecsalida = value
            End If
         Else
            m_viaje_fecsalida = value
         End If
      End Set
   End Property
   Public Property VIAJE_FecLlegada() As Date
      Get
         Return m_viaje_fecllegada
      End Get
      Set(ByVal value As Date)
         If Not IsNothing(m_viaje_fecllegada) Then
            If Not m_viaje_fecllegada.Equals(value) Then
               m_viaje_fecllegada = value
            End If
         Else
            m_viaje_fecllegada = value
         End If
      End Set
   End Property
   Public Property VIAJE_Descripcion() As String
      Get
         Return m_viaje_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_viaje_descripcion) Then
            If Not m_viaje_descripcion.Equals(value) Then
               m_viaje_descripcion = value
            End If
         Else
            m_viaje_descripcion = value
         End If
      End Set
   End Property

   Public Property VEHIC_Id() As Long
      Get
         Return m_vehic_id
      End Get
      Set(ByVal value As Long)
         If Not IsNothing(m_vehic_id) Then
            If Not m_vehic_id.Equals(value) Then
               m_vehic_id = value
            End If
         Else
            m_vehic_id = value
         End If
      End Set
   End Property
   Public Property RANFL_Id() As Long
      Get
         Return m_ranfl_id
      End Get
      Set(ByVal value As Long)
         If Not IsNothing(m_ranfl_id) Then
            If Not m_ranfl_id.Equals(value) Then
               m_ranfl_id = value
            End If
         Else
            m_ranfl_id = value
         End If
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
