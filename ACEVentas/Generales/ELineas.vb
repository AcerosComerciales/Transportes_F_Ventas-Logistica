Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ELineas
   Implements ICloneable

#Region " Variables "
   Private m_tipos_comision As String

#End Region

#Region " Propiedades "
   Public Property TIPOS_Comision() As String
      Get
         Return m_tipos_comision
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_comision) Then
            If Not m_tipos_comision.Equals(value) Then
               m_tipos_comision = value
            End If
         Else
            m_tipos_comision = value
         End If
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New ELineas()
         cloneInstance = CType(Me, ELineas)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
