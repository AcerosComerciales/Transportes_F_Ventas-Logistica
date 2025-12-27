Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Piezas

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

