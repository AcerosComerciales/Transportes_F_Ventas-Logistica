Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_VehiculosMantenimientoDetalle

#Region " Campos "
   Private m_pieza_codigo As String
   Private m_pieza_descripcion As String
   Private m_tipos_tiporepuesto As String

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

    Public Property PIEZA_Codigo() As String
        Get
            Return m_pieza_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_pieza_codigo) Then
                If Not m_pieza_codigo.Equals(value) Then
                    m_pieza_codigo = value
                    OnPIEZA_CodigoChanged(m_pieza_codigo, EventArgs.Empty)
                End If
            Else
                m_pieza_codigo = value
                OnPIEZA_CodigoChanged(m_pieza_codigo, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PIEZA_Descripcion() As String
      Get
         Return m_pieza_descripcion
      End Get
      Set(ByVal value As String)
         m_pieza_descripcion = value
      End Set
   End Property

   Public Property TIPOS_TipoRepuesto() As String
      Get
         Return m_tipos_tiporepuesto
      End Get
      Set(ByVal value As String)
         m_tipos_tiporepuesto = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "

#End Region

End Class

