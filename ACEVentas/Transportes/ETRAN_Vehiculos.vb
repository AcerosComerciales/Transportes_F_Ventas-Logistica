Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Vehiculos

   Private m_tipos_marca As String
   Private m_tipos_vehiculo As String
   Private m_sucur_nombre As String
   Private m_entid_razonsocial As String
   Private m_tipos_tipocombustible As String

   Private m_ranfl_placa As String

   Enum Inicializacion
      All
      Ranflas
      Combustible
      Incidencias
      Mantenimiento
      Conductores
      Seguros
   End Enum
#Region " Campos "
   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
      Activo
   End Enum
#End Region

#Region" Constructores "
	
#End Region

#Region" Propiedades "
	
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
         Case Estado.Activo
            Return "A"
         Case Else
            Return "I"
      End Select

   End Function
#End Region

End Class

