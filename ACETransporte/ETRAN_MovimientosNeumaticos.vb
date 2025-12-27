Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_MovimientosNeumaticos

#Region " Variables "
   Private m_destino As String
   Private m_tipodestino As TipoDestino

   Public Enum TipoDestino
      Vehiculo
      Ranfla
      Almacen
      Proveedor
   End Enum
#End Region

#Region " Propiedades "
   Public Property Destino() As String
      Get
         Return m_destino
      End Get
      Set(ByVal value As String)
         m_destino = value
      End Set
   End Property

   Public Property TDestino() As TipoDestino
      Get
         Return m_tipodestino
      End Get
      Set(ByVal value As TipoDestino)
         m_tipodestino = value
      End Set
   End Property


   Public ReadOnly Property MOVNM_ESTADO_Text() As String
      Get
         Select Case m_movnm_estado
            Case "A"
               Return "Activo"
            Case "I"
               Return "Inactivo"
            Case "X"
               Return "Anulado"
            Case "P"
               Return "Pendiente"
            Case "G"
               Return "Asignado"
            Case Else
               Return "Sin Estado"
         End Select
      End Get
   End Property

   Public ReadOnly Property MOVNM_FECASIGNACION_Text() As Date
      Get
         If m_movnm_fecasignacion.Year > 1700 Then
            Return m_movnm_fecasignacion.ToString("dd/MM/yyyy hh:mm tt")
         Else
            Return ""
         End If
      End Get
   End Property
   Public ReadOnly Property MOVNM_FECRETIRO_Text() As Date
      Get
         If m_movnm_fecretiro.Year > 1700 Then
            Return m_movnm_fecretiro.ToString("dd/MM/yyyy hh:mm tt")
         Else
            Return ""
         End If
      End Get
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
