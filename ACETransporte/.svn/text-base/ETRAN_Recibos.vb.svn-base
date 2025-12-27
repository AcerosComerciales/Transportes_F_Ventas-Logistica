Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_Recibos

#Region " Variables "
   Private m_codigo As String
   Private m_tipos_tiporecibo As String
   Private m_tipos_tipomonedalargo As String
   Private m_tipos_tipomoneda As String
   Private m_caja_id As Long
   Private m_caja_pase As String
   Private m_entid_codusuario As String
#End Region

#Region " Propiedades "
   Public Property Codigo() As String
      Get
         Return m_codigo
      End Get
      Set(ByVal value As String)
         m_codigo = value
      End Set
   End Property

   Public Property TIPOS_TipoRecibo() As String
      Get
         Return m_tipos_tiporecibo
      End Get
      Set(ByVal value As String)
         m_tipos_tiporecibo = value
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

   Public Property TIPOS_TipoMonedaLargo() As String
      Get
         Return m_tipos_tipomonedalargo
      End Get
      Set(ByVal value As String)
         m_tipos_tipomonedalargo = value
      End Set
   End Property

   Public ReadOnly Property Documento() As String
      Get
         Return String.Format("{0}-{1}", m_recib_serie, m_recib_numero.ToString().PadLeft(7, "0"))
      End Get
   End Property

   Public Property CAJA_Id() As Long
      Get
         Return m_caja_id
      End Get
      Set(ByVal value As Long)
         m_caja_id = value
      End Set
   End Property

   Public Property CAJA_Pase() As String
      Get
         Return m_caja_pase
      End Get
      Set(ByVal value As String)
         m_caja_pase = value
      End Set
   End Property

   Public Property ENTID_CodUsuario() As String
      Get
         Return m_entid_codusuario
      End Get
      Set(ByVal value As String)
         m_entid_codusuario = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
