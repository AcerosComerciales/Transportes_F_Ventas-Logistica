Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_VehiculosInventarioDetalle

#Region " Variables "
   Private m_existe As Boolean
   Private m_tipos_objeto As String
   Private m_tipos_categoria As String

   Enum Estado
      Anulado
      Activo
      Inactivo
   End Enum
#End Region

#Region " Propiedades "
   Public ReadOnly Property VEHID_Estado_Text() As String
      Get
         Select Case m_vehid_estado
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

   Public Property Existe() As Boolean
      Get
         Return m_existe
      End Get
      Set(ByVal value As Boolean)
         m_existe = value
      End Set
   End Property

   Public Property TIPOS_Categoria() As String
      Get
         Return m_tipos_categoria
      End Get
      Set(ByVal value As String)
         m_tipos_categoria = value
      End Set
   End Property


   Public Property TIPOS_Objeto() As String
      Get
         Return m_TIPOS_Objeto
      End Get
      Set(ByVal value As String)
         m_TIPOS_Objeto = value
      End Set
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
