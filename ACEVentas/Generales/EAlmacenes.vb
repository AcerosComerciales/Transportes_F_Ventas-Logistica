Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EAlmacenes
   Implements ICloneable

#Region " Variables "
   Private m_sucur_nombre As String
   Private m_tipos_almacen As String

   Private m_pvent_direccionip As String
   Private m_pvent_basedatos As String
   Private m_pvent_bdadmin As String
   Private m_pvent_direccionipdesc As String

   Private m_seleccionar As Boolean
   Private m_pvent_principal As Boolean
#End Region

#Region " Propiedades "
   Public Property SUCUR_Nombre() As String
      Get
         Return m_sucur_nombre
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_sucur_nombre) Then
            If Not m_sucur_nombre.Equals(value) Then
               m_sucur_nombre = value
            End If
         Else
            m_sucur_nombre = value
         End If
      End Set
   End Property

   Public Property TIPOS_Almacen() As String
      Get
         Return m_tipos_almacen
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_almacen) Then
            If Not m_tipos_almacen.Equals(value) Then
               m_tipos_almacen = value
            End If
         Else
            m_tipos_almacen = value
         End If
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

   Public Property PVENT_BaseDatos() As String
      Get
         Return m_pvent_basedatos
      End Get
      Set(ByVal value As String)
         m_pvent_basedatos = value
      End Set
   End Property

   Public Property PVENT_BDAdmin() As String
      Get
         Return m_pvent_bdadmin
      End Get
      Set(ByVal value As String)
         m_pvent_bdadmin = value
      End Set
   End Property

   Public Property PVENT_DireccionIPDesc() As String
      Get
         Return m_pvent_direccionipdesc
      End Get
      Set(ByVal value As String)
         m_pvent_direccionipdesc = value
      End Set
   End Property

   Public Property Seleccionar() As Boolean
      Get
         Return m_seleccionar
      End Get
      Set(ByVal value As Boolean)
         m_seleccionar = value
      End Set
   End Property

   Public Property PVENT_Principal() As Boolean
      Get
         Return m_pvent_principal
      End Get
      Set(ByVal value As Boolean)
         m_pvent_principal = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New EAlmacenes()
         cloneInstance = CType(Me, EAlmacenes)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
