Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_Viajes
   Implements ICloneable

#Region " Variables "
   Enum EstadosViajes
      Activo
      Anulado
      Liquidado
      Viaje
   End Enum

   Private m_vehic_placa As String
   Private m_entid_nombre As String
   Private m_ranfl_placa As String

   Private m_tran_viajesvehiculos As ETRAN_ViajesVehiculos

   Private m_listTRAN_Fletes As List(Of ETRAN_Fletes)

   Private m_pendiente As Decimal
   Private m_conductor As String
   Private m_documento As String

   Private m_usuario As String

   Private m_entid_razonsocial As String
   Private m_condu_sigla As String
   Private m_entid_nrodocumento As String

   Private m_comco_galonesconsumidos As Decimal
#End Region

#Region " Propiedades "
   Public ReadOnly Property VIAJE_CODIGO_Text() As String
      Get
         Return m_viaje_id.ToString("0000000")
      End Get
   End Property

   Public ReadOnly Property VIAJE_Estado_Text() As String
      Get
         Select Case m_viaje_estado
            Case getEstado(EstadosViajes.Liquidado)
               Return "Liquidado"
            Case getEstado(EstadosViajes.Activo)
               Return "Activo"
            Case getEstado(EstadosViajes.Anulado)
               Return "Anulado"
            Case getEstado(EstadosViajes.Viaje)
               Return "En Viaje"
            Case Else
               Return "Activo"
         End Select
      End Get
   End Property

   Public Property VEHIC_Placa() As String
      Get
         Return m_vehic_placa
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_vehic_placa) Then
            If Not m_vehic_placa.Equals(value) Then
               m_vehic_placa = value
            End If
         Else
            m_vehic_placa = value
         End If
      End Set
   End Property

   Public Property ENTID_Nombres() As String
      Get
         Return m_entid_nombre
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_nombre) Then
            If Not m_entid_nombre.Equals(value) Then
               m_entid_nombre = value
            End If
         Else
            m_entid_nombre = value
         End If
      End Set
   End Property

   Public Property RANFL_Placa() As String
      Get
         Return m_ranfl_placa
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_ranfl_placa) Then
            If Not m_ranfl_placa.Equals(value) Then
               m_ranfl_placa = value
            End If
         Else
            m_ranfl_placa = value
         End If
      End Set
   End Property

   Public Property TRAN_ViajesVehiculos() As ETRAN_ViajesVehiculos
      Get
         Return m_tran_viajesvehiculos
      End Get
      Set(ByVal value As ETRAN_ViajesVehiculos)
         m_tran_viajesvehiculos = value
      End Set
   End Property

   Public Property ListTRAN_Fletes() As List(Of ETRAN_Fletes)
      Get
         Return m_listTRAN_Fletes
      End Get
      Set(ByVal value As List(Of ETRAN_Fletes))
         m_listTRAN_Fletes = value
      End Set
   End Property

   Public Property Pendiente() As Decimal
      Get
         Return m_pendiente
      End Get
      Set(ByVal value As Decimal)
         m_pendiente = value
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

   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
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

   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         m_entid_razonsocial = value
      End Set
   End Property

   Public Property CONDU_Sigla() As String
      Get
         Return m_condu_sigla
      End Get
      Set(ByVal value As String)
         m_condu_sigla = value
      End Set
   End Property

   Public Property ENTID_NroDocumento() As String
      Get
         Return m_entid_nrodocumento
      End Get
      Set(ByVal value As String)
         m_entid_nrodocumento = value
      End Set
   End Property

   Public ReadOnly Property VIAJE_FecLlegada_Text() As String
      Get
         If m_viaje_fecllegada.Year > 1900 Then
            Return m_viaje_fecllegada.ToString("dd/MM/yyyy")
         Else
            Return ""
         End If
      End Get
   End Property

   Public ReadOnly Property VIAJE_ScanFecha_Text() As String
      Get
         If m_viaje_scanfecha.Year > 1900 Then
            Return m_viaje_scanfecha.ToString("dd/MM/yyyy")
         Else
            Return ""
         End If
      End Get
   End Property

   Public Property COMCO_GalonesConsumidos() As Decimal
      Get
         Return m_comco_galonesconsumidos
      End Get
      Set(ByVal value As Decimal)
         m_comco_galonesconsumidos = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Shared Function getEstado(ByVal Estado As EstadosViajes) As String
      Select Case Estado
         Case EstadosViajes.Activo : Return "A"
         Case EstadosViajes.Anulado : Return "X"
         Case EstadosViajes.Liquidado : Return "L"
         Case EstadosViajes.Viaje : Return "V"
         Case Else : Return "A"
      End Select
   End Function

   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New ETRAN_Viajes()
         cloneInstance = CType(Me, ETRAN_Viajes)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
