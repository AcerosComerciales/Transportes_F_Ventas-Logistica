Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EDirecciones
    Implements ICloneable

#Region " Variables "
    Private m_ubigo_descripcion As String

    Private m_direccion As String
#End Region

#Region " Propiedades "
   Public Property UBIGO_Descripcion() As String
      Get
         Return m_ubigo_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_ubigo_descripcion) Then
            If Not m_ubigo_descripcion.Equals(value) Then
               m_ubigo_descripcion = value
            End If
         Else
            m_ubigo_descripcion = value
         End If
      End Set
   End Property



    Public Property Direccion() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property

    Public Function Clone() As Object Implements ICloneable.Clone
        Try
            Dim cloneInstance As New EDirecciones()
            cloneInstance = CType(Me, EDirecciones)
            Return cloneInstance.MemberwiseClone
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
