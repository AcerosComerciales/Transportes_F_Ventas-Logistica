Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EPuntoVenta
   Implements ICloneable

#Region " Variables "
   Private m_almac_descripcion As String
   Private m_sucur_nombre As String
   Private m_vspva_parapedidos As Boolean

   Private m_almacenactivo As Boolean
   Private m_seleccionar As Boolean
#End Region

#Region " Propiedades "
   Public Property ALMAC_Nombre() As String
      Get
         Return m_almac_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_almac_descripcion) Then
            If Not m_almac_descripcion.Equals(value) Then
               m_almac_descripcion = value
            End If
         Else
            m_almac_descripcion = value
         End If
      End Set
   End Property

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

   Public Property VSPVA_ParaPedidos() As Boolean
      Get
         Return m_vspva_parapedidos
      End Get
      Set(ByVal value As Boolean)
         m_vspva_parapedidos = value
      End Set
   End Property

   Public Property AlmacenActivo() As Boolean
      Get
         Return m_almacenactivo
      End Get
      Set(ByVal value As Boolean)
         m_almacenactivo = value
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


#End Region

#Region " Constructores "
   Public Sub New(ByVal x_pvent_id As Long, ByVal x_pvent_descripcion As String)
      Me.m_pvent_id = x_pvent_id
      Me.m_pvent_descripcion = x_pvent_descripcion
   End Sub
#End Region

#Region " Metodos "
   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New EPuntoVenta()
         cloneInstance = CType(Me, EPuntoVenta)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
