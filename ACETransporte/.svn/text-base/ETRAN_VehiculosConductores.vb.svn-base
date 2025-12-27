Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_VehiculosConductores

#Region " Variables "
   Private m_entid_nombre As String
   Private m_entid_nrodocumento As String
   Private m_entid_fecnacimiento As Date
   Private m_vehic_placa As String
#End Region

#Region " Propiedades "
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

   Public Property ENTID_FecNacimiento() As Date
      Get
         Return m_entid_fecnacimiento
      End Get
      Set(ByVal value As Date)
         If Not IsNothing(m_entid_fecnacimiento) Then
            If Not m_entid_fecnacimiento.Equals(value) Then
               m_entid_fecnacimiento = value
            End If
         Else
            m_entid_fecnacimiento = value
         End If
      End Set
   End Property

   Public ReadOnly Property VHCON_FECDESDE_Fecha() As String
      Get
         If m_vhcon_fecdesde.Year < 1700 Then
            Return ""
         Else
            Return m_vhcon_fecdesde
         End If
      End Get
   End Property

   Public ReadOnly Property VHCON_FECHASTA_Fecha() As String
      Get
         If m_vhcon_fechasta.Year < 1700 Then
            Return ""
         Else
            Return m_vhcon_fechasta
         End If
      End Get

   End Property

   Public Property VEHIC_Placa() As String
      Get
         Return m_vehic_placa
      End Get
      Set(ByVal value As String)
         m_vehic_placa = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
