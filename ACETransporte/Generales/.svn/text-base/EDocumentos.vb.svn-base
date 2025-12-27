Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EDocumentos

#Region " Variables "
   Private m_tipos_descripcion As String
  
#End Region

#Region " Propiedades "
   Public ReadOnly Property DOCMT_NRO_Text() As String
      Get
         Return m_docmt_nro.Substring(4)
      End Get
   End Property

   Public Property TIPO_DOCUMENTO() As String
      Get
         Return m_tipos_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_descripcion) Then
            If Not m_tipos_descripcion.Equals(value) Then
               m_tipos_descripcion = value
            End If
         Else
            m_tipos_descripcion = value
         End If
      End Set
   End Property

#End Region

#Region " Constructores "
  
#End Region

#Region " Metodos "

#End Region

End Class
