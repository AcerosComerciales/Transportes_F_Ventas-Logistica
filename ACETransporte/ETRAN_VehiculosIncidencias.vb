Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Partial Public Class ETRAN_VehiculosIncidencias
   Implements ICloneable

#Region " Variables "
   Private m_tipos_tipoincidencia As String
   Private m_tran_documentos As ETRAN_Documentos

   Private m_documento As String
   Private m_entid_razonsocial As String
   Private m_tipos_tipomoneda As String

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum
#End Region

#Region " Propiedades "

   Public ReadOnly Property VIAJE_Id_Text() As String
      Get
         Return IIf(m_viaje_id > 0, m_viaje_id.ToString(), "")
      End Get
   End Property

   Public Property TIPOS_TipoIncidencia() As String
      Get
         Return m_tipos_tipoincidencia
      End Get
      Set(ByVal value As String)
         m_tipos_tipoincidencia = value
      End Set
   End Property

   Public Property TRAN_Documentos() As ETRAN_Documentos
      Get
         Return m_tran_documentos
      End Get
      Set(ByVal value As ETRAN_Documentos)
         m_tran_documentos = value
      End Set
   End Property

   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
      End Set
   End Property

   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         m_entid_razonsocial = value
      End Set
   End Property

   Public Property TIPOS_TipoMoneda() As String
      Get
         Return m_tipos_tipomoneda
      End Get
      Set(ByVal value As String)
         m_tipos_tipomoneda = value
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
         Case Estado.Confirmado
            Return "C"
         Case Estado.Eliminado
            Return "E"
         Case Estado.Ingresado
            Return "I"
         Case Else
            Return "I"
      End Select

   End Function

   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New ETRAN_VehiculosIncidencias()
         cloneInstance = CType(Me, ETRAN_VehiculosIncidencias)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
