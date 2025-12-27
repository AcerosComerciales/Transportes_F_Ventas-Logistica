Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_ViajesGastos

#Region " Variables "
   Private m_tran_documentos As ETRAN_Documentos

   Private m_tipos_gasto As String
   Private m_tipos_moneda As String

   Private m_documento As String
   Private m_entid_razonsocial As String
   Private m_tipos_tipomoneda As String
   Private m_tipos_tipogasto As String

   Private m_caja_id As Long
   Private m_recib_codigo As String

   Private m_recibo As String
   Private m_referencia As String

   Private m_entid_nrodocumento As String

   Private m_viaje_descripcion As String
   Private m_importe As Decimal

   Private m_egreso As Decimal
   Private m_ingreso As Decimal
   Private m_flete_glosa As String

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum
#End Region

#Region " Propiedades "
   Public Property TRAN_Documentos() As ETRAN_Documentos
      Get
         Return m_tran_documentos
      End Get
      Set(ByVal value As ETRAN_Documentos)
         m_tran_documentos = value
      End Set
   End Property

   Public Property TIPOS_Gasto() As String
      Get
         Return m_tipos_gasto
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_gasto) Then
            If Not m_tipos_gasto.Equals(value) Then
               m_tipos_gasto = value
            End If
         Else
            m_tipos_gasto = value
         End If
      End Set
   End Property

   Public Property TIPOS_Moneda() As String
      Get
         Return m_tipos_moneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_moneda) Then
            If Not m_tipos_moneda.Equals(value) Then
               m_tipos_moneda = value
            End If
         Else
            m_tipos_moneda = value
         End If
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

   Public Property TIPOS_TipoGasto() As String
      Get
         Return m_tipos_tipogasto
      End Get
      Set(ByVal value As String)
         m_tipos_tipogasto = value
      End Set
   End Property

   Public Property CAJA_Id() As Long
      Get
         Return m_caja_id
      End Get
      Set(ByVal value As Long)
         m_caja_id = value
      End Set
   End Property

   Public Property RECIB_Codigo() As String
      Get
         Return m_recib_codigo
      End Get
      Set(ByVal value As String)
         m_recib_codigo = value
      End Set
   End Property

   Public Property Referencia() As String
      Get
         Return m_referencia
      End Get
      Set(ByVal value As String)
         m_referencia = value
      End Set
   End Property

   Public Property Recibo() As String
      Get
         Return m_recibo
      End Get
      Set(ByVal value As String)
         m_recibo = value
      End Set
   End Property

   Public Property ENTID_NroDocumento() As String
      Get
         Return m_entid_nrodocumento
      End Get
      Set(ByVal value As String)
         m_entid_nrodocumento = value
      End Set
   End Property

   Public Property VIAJE_Descripcion() As String
      Get
         Return m_viaje_descripcion
      End Get
      Set(ByVal value As String)
         m_viaje_descripcion = value
      End Set
   End Property

   Public Property Importe() As Decimal
      Get
         Return m_importe
      End Get
      Set(ByVal value As Decimal)
         m_importe = value
      End Set
   End Property

   Public Property Ingreso() As Decimal
      Get
         Return m_ingreso
      End Get
      Set(ByVal value As Decimal)
         m_ingreso = value
      End Set
   End Property

   Public Property Egreso() As Decimal
      Get
         Return m_egreso
      End Get
      Set(ByVal value As Decimal)
         m_egreso = value
      End Set
   End Property

   Public Property FLETE_Glosa() As String
      Get
         Return m_flete_glosa
      End Get
      Set(ByVal value As String)
         m_flete_glosa = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   Public Shared Function getEstado(ByVal x_opcion As Estado)
      Select Case x_opcion
         Case Estado.Anulado : Return "X"
         Case Estado.Confirmado : Return "C"
         Case Estado.Eliminado : Return "E"
         Case Estado.Ingresado : Return "I"
         Case Else : Return "I"
      End Select
   End Function
#End Region

End Class
