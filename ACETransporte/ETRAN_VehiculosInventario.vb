Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_VehiculosInventario

#Region " Variables "
   Private m_listtran_vehiculosinventariodetalle As List(Of ETRAN_VehiculosInventarioDetalle)

   Enum Estado
      Anulado
      Activo
      Inactivo
   End Enum

#End Region

#Region " Propiedades "

   Public Property ListTRAN_VehiculosInventarioDetalle() As List(Of ETRAN_VehiculosInventarioDetalle)
      Get
         Return m_listtran_vehiculosinventariodetalle
      End Get
      Set(ByVal value As List(Of ETRAN_VehiculosInventarioDetalle))
         m_listtran_vehiculosinventariodetalle = value
      End Set
   End Property


   Public ReadOnly Property VEHIN_Estado_Text() As String
      Get
         Select Case m_vehin_estado
            Case getEstado(Estado.Activo)
               Return Estado.Activo.ToString()
            Case getEstado(Estado.Anulado)
               Return Estado.Anulado.ToString()
            Case getEstado(Estado.Inactivo)
               Return Estado.Inactivo.ToString()
            Case Else
               Return Estado.Activo.ToString()
         End Select
      End Get
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Shared Function getEstado(ByVal x_opcion As Estado)

      Select Case x_opcion
         Case Estado.Anulado
            Return "X"
         Case Estado.Activo
            Return "A"
         Case Estado.Inactivo
            Return "N"
         Case Else
            Return "A"
      End Select

   End Function
#End Region

End Class
