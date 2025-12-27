Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class ETRAN_ViajesGuiasRemision

#Region " Variables "
   Private m_tdoc As String
   Private m_serie As String
   Private m_numero As Integer

   Private m_vegre_condicion_text As String
   Private m_flete_id_text As String
   Private m_tipos_codtipodocumento_text As String
   Private m_entid_razonsocial As String

   Private x_listetran_viajesguiasremision As List(Of ETRAN_ViajesGuiasRemision)

   Private m_tipos_tipodocumento As String
   Private m_empresa As String
   Private m_seleccion As Boolean
#End Region

#Region " Propiedades "

   Public Property TDoc() As String
      Get
         Return m_tdoc
      End Get
      Set(ByVal value As String)
         m_tdoc = value
      End Set
   End Property

   Public Property Numero() As Integer
      Get
         Return m_numero
      End Get
      Set(ByVal value As Integer)
         m_numero = value
      End Set
   End Property

   Public ReadOnly Property Numero_text() As String
      Get
         Return m_numero.ToString("0000000")
      End Get
   End Property


   Public Property Serie() As String
      Get
         Return m_serie
      End Get
      Set(ByVal value As String)
         m_serie = value
      End Set
   End Property

   Public ReadOnly Property Documento() As String
      Get
            If Not IsNothing(m_gtran_codigo) Then
                If Len(m_gtran_codigo) = 12 Then
                    Return String.Format("{0}-{1}", m_gtran_codigo.Substring(2, 3), m_gtran_codigo.Substring(5, 7))
                Else
                    Return String.Format("{0}-{1}", m_gtran_codigo.Substring(2, 4), m_gtran_codigo.Substring(5, 7))
                End If
            Else
                Return ""
            End If
        End Get
   End Property

   Public Property TIPOS_CodTipoDocumento_Text() As String
      Get
         Return m_tipos_codtipodocumento_text
      End Get
      Set(ByVal value As String)
         m_tipos_codtipodocumento_text = value
      End Set
   End Property

   Public Property FLETE_Id_Text() As String
      Get
         Return m_flete_id_text
      End Get
      Set(ByVal value As String)
         m_flete_id_text = value
      End Set
   End Property

   Public Property VEGRE_Condicion_Text() As String
      Get
         Return m_vegre_condicion_text
      End Get
      Set(ByVal value As String)
         m_vegre_condicion_text = value
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

   Public Property ListETRAN_ViajesGuiasRemision() As List(Of ETRAN_ViajesGuiasRemision)
      Get
         Return x_listetran_viajesguiasremision
      End Get
      Set(ByVal value As List(Of ETRAN_ViajesGuiasRemision))
         x_listetran_viajesguiasremision = value
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

   Public Property Empresa() As String
      Get
         Return m_empresa
      End Get
      Set(ByVal value As String)
         m_empresa = value
      End Set
   End Property

   Public Property Seleccion() As Boolean
      Get
         Return m_seleccion
      End Get
      Set(ByVal value As Boolean)
         m_seleccion = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
