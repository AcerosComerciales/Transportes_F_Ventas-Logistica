Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_VehiculosRanflas

#Region " Variables "
   Private m_ranfl_codigo As String
   Private m_ranfl_placa As String
   Private m_ranfl_fecadquisicion As Date
   Private m_vehic_placa As String
#End Region

#Region " Propiedades "
   Public Property RANFL_Codigo() As String
      Get
         Return m_ranfl_codigo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_ranfl_codigo) Then
            If Not m_ranfl_codigo.Equals(value) Then
               m_ranfl_codigo = value
            End If
         Else
            m_ranfl_codigo = value
         End If
      End Set
   End Property

   Public Property VEHIC_Placa() As String
      Get
         Return m_vehic_placa
      End Get
      Set(ByVal value As String)
         m_vehic_placa = value
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

   Public Property RANFL_FecAdquisicion() As Date
      Get
         Return m_ranfl_fecadquisicion
      End Get
      Set(ByVal value As Date)
         If Not IsNothing(m_ranfl_fecadquisicion) Then
            If Not m_ranfl_fecadquisicion.Equals(value) Then
               m_ranfl_fecadquisicion = value
            End If
         Else
            m_ranfl_fecadquisicion = value
         End If
      End Set
   End Property

   Public ReadOnly Property VEHRN_FECASIGNACION_Fecha() As String
      Get
         Return IIf(m_vehrn_fecasignacion.Year > 1700, m_vehrn_fecasignacion.ToString("dd/MM/yyyy"), "")
      End Get
      
   End Property
   Public ReadOnly Property VEHRN_FECDESASIGNACION_Fecha() As String
      Get
         Return IIf(m_vehrn_fecdesasignacion.Year > 1700, m_vehrn_fecdesasignacion.ToString("dd/MM/yyyy"), "")
      End Get
   End Property
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
