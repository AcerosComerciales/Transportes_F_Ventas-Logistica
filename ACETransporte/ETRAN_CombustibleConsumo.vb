Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_CombustibleConsumo

#Region " Variables "
   Private m_tran_documentos As ETRAN_Documentos

   Private m_tipos_modopago As String
   Private m_tipos_tipocombustible As String
   Private m_entid_razonsocial As String
   Private m_tipos_tipodocumento As String
   Private m_tipos_tipodoccorta As String

   Private m_docus_serie As String
   Private m_docus_numero As Integer
   Private m_docus_codtipodocumento As String
   Private m_comptipodocumento As String

   Private m_entid_nrodocumento As String

   Private m_caja_id As Integer
   Private m_recib_codigo As String

   Private m_documento As String
   Private m_referencia As String
   Private m_tipos_tipomoneda As String
   Private m_conductor As String
   Private m_vehic_placa As String
   Private m_entid_nrodocproveedor As String
   Private m_entid_nrodocconductor As String

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

   Public Property TIPOS_ModoPago() As String
      Get
         Return m_tipos_modopago
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_modopago) Then
            If Not m_tipos_modopago.Equals(value) Then
               m_tipos_modopago = value
            End If
         Else
            m_tipos_modopago = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoCombustible() As String
      Get
         Return m_tipos_tipocombustible
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipocombustible) Then
            If Not m_tipos_tipocombustible.Equals(value) Then
               m_tipos_tipocombustible = value
            End If
         Else
            m_tipos_tipocombustible = value
         End If
      End Set
   End Property

   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_razonsocial) Then
            If Not m_entid_razonsocial.Equals(value) Then
               m_entid_razonsocial = value
            End If
         Else
            m_entid_razonsocial = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoDocumento() As String
      Get
         Return m_tipos_tipodocumento
      End Get
      Set(ByVal value As String)
         m_tipos_tipodocumento = value
      End Set
   End Property

   Public Property TIPOS_TipoDocCorta() As String
      Get
         Return m_tipos_tipodoccorta
      End Get
      Set(ByVal value As String)
         m_tipos_tipodoccorta = value
      End Set
   End Property

   Public Property DOCUS_CodTipoDocumento() As String
      Get
         Return m_docus_codtipodocumento
      End Get
      Set(ByVal value As String)
         m_docus_codtipodocumento = value
      End Set
   End Property

   Public Property DOCUS_Numero() As Integer
      Get
         Return m_docus_numero
      End Get
      Set(ByVal value As Integer)
         m_docus_numero = value
      End Set
   End Property

   Public Property DOCUS_Serie() As String
      Get
         Return m_docus_serie
      End Get
      Set(ByVal value As String)
         m_docus_serie = value
      End Set
   End Property

   Public Property CompTipoDocumento() As String
      Get
         Return m_comptipodocumento
      End Get
      Set(ByVal value As String)
         m_comptipodocumento = value
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

   Public ReadOnly Property CompDocumento() As String
      Get
         If m_docus_numero > 0 Then
            Return String.Format("{0} {1}-{2}", m_comptipodocumento, m_docus_serie, m_docus_numero.ToString().PadLeft(7, "0"))
         Else
            Return ""
         End If
      End Get
   End Property

   Public Property CAJA_Id() As Integer
      Get
         Return m_caja_id
      End Get
      Set(ByVal value As Integer)
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

   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
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

   Public Property Conductor() As String
      Get
         Return m_conductor
      End Get
      Set(ByVal value As String)
         m_conductor = value
      End Set
   End Property

   Public Property VEHIC_Placa() As String
      Get
         Return m_vehic_placa
      End Get
      Set(ByVal value As String)
         m_vehic_placa = value
      End Set
   End Property

   Public Property ENTID_NroDocProveedor() As String
      Get
         Return m_entid_nrodocproveedor
      End Get
      Set(ByVal value As String)
         m_entid_nrodocproveedor = value
      End Set
   End Property

   Public Property ENTID_NroDocConductor() As String
      Get
         Return m_entid_nrodocconductor
      End Get
      Set(ByVal value As String)
         m_entid_nrodocconductor = value
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
#End Region

End Class
