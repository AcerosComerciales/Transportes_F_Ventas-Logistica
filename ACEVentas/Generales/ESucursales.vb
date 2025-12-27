Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ESucursales
   Implements ICloneable

#Region " Variables "
   Private m_pvent_basedatos As String
   Private m_pvent_direccionip As String
   Private m_almac_id As Short
#End Region

#Region " Propiedades "
   Public Property PVENT_BaseDatos() As String
      Get
         Return m_pvent_basedatos
      End Get
      Set(ByVal value As String)
         m_pvent_basedatos = value
      End Set
   End Property

   Public Property PVENT_DireccionIP() As String
      Get
         Return m_pvent_direccionip
      End Get
      Set(ByVal value As String)
         m_pvent_direccionip = value
      End Set
   End Property

   Public Property ALMAC_Id() As Short
      Get
         Return m_almac_id
      End Get
      Set(ByVal value As Short)
         m_almac_id = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_sucur_id As Integer, ByVal x_sucur_descripcion As String)
      Me.m_sucur_id = x_sucur_id
      Me.m_sucur_nombre = x_sucur_descripcion
   End Sub
#End Region

#Region " Metodos "
   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New ESucursales()
         cloneInstance = CType(Me, ESucursales)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
