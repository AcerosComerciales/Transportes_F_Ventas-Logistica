Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ECorrelativos

#Region " Variables "
   Public Enum NTabla
      TRAN_Cotizaciones
      TRAN_Rutas
      TRAN_OrdenesTransportes
      TRAN_Viajes
      TRAN_Fletes
      TRAN_Vehiculos
      TRAN_Ranflas
      Documentos
   End Enum

   Private m_codigo As String
#End Region

#Region " Propiedades "
   Public Property Codigo() As String
      Get
         Return m_codigo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_codigo) Then
            If Not m_codigo.Equals(value) Then
               m_codigo = value
            End If
         Else
            m_codigo = value
         End If
      End Set
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Shared Function getTabla(ByVal x_tabla As NTabla) As String
      Try
         Select Case x_tabla
            Case NTabla.TRAN_Cotizaciones
               Return "TRAN_Cotizaciones"
            Case Else
               Return x_tabla.ToString()
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class
