Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EUbigeos
   Implements ICloneable

#Region " Variables "
   Private m_upadre_descripcion As String
#End Region

#Region " Propiedades "
   Public Property UPADRE_DESCRIPCION() As String
      Get
         Return m_upadre_descripcion
      End Get
      Set(ByVal value As String)
         m_upadre_descripcion = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New EUbigeos()
         cloneInstance = CType(Me, EUbigeos)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
