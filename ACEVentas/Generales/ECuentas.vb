Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ECuentas

#Region " Variables "
Private m_banco_nombre As String
    Private m_tipos_cuenta As String
   Private m_tipos_moneda As String

   Enum Estado
      Anulado
      Activo
      Inactivo
   End Enum
#End Region

#Region " Propiedades "
Public Property BANCO_Descripcion() As String
        Get
            Return m_banco_nombre
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_banco_nombre) Then
                If Not m_banco_nombre.Equals(value) Then
                    m_banco_nombre = value
                End If
            Else
                m_banco_nombre = value
            End If
        End Set
    End Property

    Public Property TIPOS_TipoCuenta() As String
        Get
            Return m_tipos_cuenta
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_cuenta) Then
                If Not m_tipos_cuenta.Equals(value) Then
                    m_tipos_cuenta = value
                End If
            Else
                m_tipos_cuenta = value
            End If
        End Set
    End Property

    Public Property TIPOS_TipoMoneda() As String
        Get
            Return m_tipos_moneda
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_moneda) Then
                If Not m_tipos_moneda.Equals(value) Then
                    m_tipos_moneda = value
                End If
            Else
                m_tipos_moneda = value
            End If
        End Set
   End Property

   Public ReadOnly Property CUENT_Estado_Text() As String
      Get
         Select Case m_cuent_estado
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
