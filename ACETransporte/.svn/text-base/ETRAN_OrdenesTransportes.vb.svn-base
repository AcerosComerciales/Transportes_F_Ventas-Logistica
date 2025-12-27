Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml


Partial Public Class ETRAN_OrdenesTransportes

#Region " Variables "
   Private m_rutas_nombre As String
   Private m_entid_nombre As String
   Private m_rutas_codigo As String

   Enum Estado
      Activo
      Inactivo
      Anulado
      Recibido
   End Enum

   Public Shared Function getEstado(ByVal x_opcion As Estado) As String
      Select Case x_opcion
         Case Estado.Activo
            Return "A"
         Case Estado.Anulado
            Return "X"
         Case Estado.Inactivo
            Return "I"
         Case Estado.Recibido
            Return "R"
         Case Else
            Return "A"
      End Select
   End Function

#End Region

#Region " Propiedades "
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

   Public Property ENTID_RazonSocial() As String
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

   Public ReadOnly Property ORDTR_ESTADO_Text() As String
      Get
         Select Case m_ordtr_estado
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

   Public ReadOnly Property ORDTR_CODIGO_Text() As String
      Get
         Return m_ordtr_codigo.Substring(4)

      End Get
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
