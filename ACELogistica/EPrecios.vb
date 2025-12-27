Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EPrecios
    
#Region " Variables "
   Private m_zonas_descripcion As String
   Private m_lprec_id As Long
    Private m_alpre_porcentaventa As Decimal
    Private m_alpre_constante As Decimal
   Private m_tipos_tipomoneda As String
    Private m_preci_id As Long


   Private m_vent_listapreciosarticulos As List(Of EVENT_ListaPreciosArticulos)
#End Region

#Region " Propiedades "
   Public Property ZONAS_Descripcion() As String
      Get
         Return m_zonas_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_zonas_descripcion) Then
            If Not m_zonas_descripcion.Equals(value) Then
               m_zonas_descripcion = value
            End If
         Else
            m_zonas_descripcion = value
         End If
      End Set
   End Property

   Public Property LPREC_Id() As Long
      Get
         Return m_lprec_id
      End Get
      Set(ByVal value As Long)
         m_lprec_id = value
      End Set
   End Property

    Public Property alpre_constante() As Decimal
        Get
            Return m_alpre_constante
        End Get
        Set(ByVal value As Decimal)
            m_alpre_constante = value
        End Set
    End Property

    Public Property ALPRE_PorcentaVenta() As Decimal
        Get
            Return m_alpre_porcentaventa
        End Get
        Set(ByVal value As Decimal)
            m_alpre_porcentaventa = value
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

   Public Property PRECI_Id() As Long
      Get
         Return m_preci_id
      End Get
      Set(ByVal value As Long)
         m_preci_id = value
      End Set
    End Property

   Public Property ListVENT_ListaPreciosArticulos() As List(Of EVENT_ListaPreciosArticulos)
      Get
         Return m_vent_listapreciosarticulos
      End Get
      Set(ByVal value As List(Of EVENT_ListaPreciosArticulos))
         m_vent_listapreciosarticulos = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region
End Class



Partial Public Class EPrecios

#Region " Campos "
	
	Private m_zonas_codigo As String
	Private m_artic_codigo As String
   Private m_tipos_codtipomoneda As String
    Private m_preci_precio As Decimal
    Private m_precioLogistica As Decimal
   Private m_preci_tipocambio As Decimal
   Private m_preci_usrcrea As String
   Private m_preci_feccrea As Date
   Private m_preci_usrmod As String
   Private m_preci_fecmod As Date
   Private m_nuevo As Boolean
   Private m_modificado As Boolean
   Private m_eliminado As Boolean

   Private m_hash As Hashtable
#End Region

#Region " Constructores "

   Public Sub New()

      Try
         Dim _obj As Object = ACELogistica.My.Resources.xmlPrecios
         Dim _xml As New XmlDocument
         _xml.LoadXml(_obj)
         If IsNothing(m_hash) Then
            m_hash = New Hashtable()
            Dim cPlantilla As XmlNodeList = _xml.GetElementsByTagName("Tabla")
            Dim cCampos As XmlNodeList = CType(cPlantilla(0), XmlElement).GetElementsByTagName("Campos")
            Dim Campo As XmlNodeList = CType(cCampos(0), XmlElement).GetElementsByTagName("CCampo")
            For Each Item As XmlElement In Campo
               m_hash.Add(Item.InnerText.ToString(), New CCampo(Item.GetAttribute("xmlns"), IIf(Item.GetAttribute("Identity") = "1", True, False), IIf(Item.GetAttribute("ForeignKey") = "1", True, False), IIf(Item.GetAttribute("PrimaryKey") = "1", True, False)))
            Next
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

#Region " Propiedades "

   Public Property ZONAS_Codigo() As String
      Get
         Return m_zonas_codigo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_zonas_codigo) Then
            If Not m_zonas_codigo.Equals(value) Then
               m_zonas_codigo = value
               OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
            End If
         Else
            m_zonas_codigo = value
            OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
         End If
      End Set
   End Property

   Public Property ARTIC_Codigo() As String
      Get
         Return m_artic_codigo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_artic_codigo) Then
            If Not m_artic_codigo.Equals(value) Then
               m_artic_codigo = value
               OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
            End If
         Else
            m_artic_codigo = value
            OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
         End If
      End Set
   End Property

   Public Property TIPOS_CodTipoMoneda() As String
      Get
         Return m_tipos_codtipomoneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_codtipomoneda) Then
            If Not m_tipos_codtipomoneda.Equals(value) Then
               m_tipos_codtipomoneda = value
               OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
            End If
         Else
            m_tipos_codtipomoneda = value
            OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
         End If
      End Set
   End Property

   Public Property PRECI_Precio() As Decimal
      Get
         Return m_preci_precio
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_preci_precio) Then
            If Not m_preci_precio.Equals(value) Then
               m_preci_precio = value
               OnPRECI_PrecioChanged(m_preci_precio, EventArgs.Empty)
            End If
         Else
            m_preci_precio = value
            OnPRECI_PrecioChanged(m_preci_precio, EventArgs.Empty)
         End If
      End Set
    End Property
    '_M
    Public Property PrecioLogistica() As Decimal
        Get
            Return m_precioLogistica
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_precioLogistica) Then
                If Not m_precioLogistica.Equals(value) Then
                    m_precioLogistica = value
                    OnPrecioLogisticaChanged(m_precioLogistica, EventArgs.Empty)
                End If
            Else
                m_precioLogistica = value
                OnPrecioLogisticaChanged(m_precioLogistica, EventArgs.Empty)
            End If
        End Set
    End Property

   Public Property PRECI_TipoCambio() As Decimal
      Get
         Return m_preci_tipocambio
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_preci_tipocambio) Then
            If Not m_preci_tipocambio.Equals(value) Then
               m_preci_tipocambio = value
               OnPRECI_TipoCambioChanged(m_preci_tipocambio, EventArgs.Empty)
            End If
         Else
            m_preci_tipocambio = value
            OnPRECI_TipoCambioChanged(m_preci_tipocambio, EventArgs.Empty)
         End If
      End Set
   End Property

   Public Property PRECI_UsrCrea() As String
      Get
         Return m_preci_usrcrea
      End Get
      Set(ByVal value As String)
         m_preci_usrcrea = value
      End Set
   End Property

   Public Property PRECI_FecCrea() As Date
      Get
         Return m_preci_feccrea
      End Get
      Set(ByVal value As Date)
         m_preci_feccrea = value
      End Set
   End Property

   Public Property PRECI_UsrMod() As String
      Get
         Return m_preci_usrmod
      End Get
      Set(ByVal value As String)
         m_preci_usrmod = value
      End Set
   End Property

   Public Property PRECI_FecMod() As Date
      Get
         Return m_preci_fecmod
      End Get
      Set(ByVal value As Date)
         m_preci_fecmod = value
      End Set
   End Property

#Region " Propiedades de Solo Lectura "

   Public ReadOnly Property Nuevo() As Boolean
      Get
         Return m_nuevo
      End Get
   End Property

   Public ReadOnly Property Modificado() As Boolean
      Get
         Return m_modificado
      End Get
   End Property

   Public ReadOnly Property Eliminado() As Boolean
      Get
         Return m_eliminado
      End Get
   End Property

   Public ReadOnly Property Hash() As Hashtable
      Get
         Return m_hash
      End Get
   End Property

   Public Shared ReadOnly Property Tabla() As String
      Get
         Return "Precios"
      End Get
   End Property

   Public Shared ReadOnly Property Esquema() As String
      Get
         Return "dbo"
      End Get
   End Property

#End Region

#End Region

#Region " Eventos "

   Public Event ZONAS_CodigoChanged As EventHandler
   Public Event ARTIC_CodigoChanged As EventHandler
   Public Event TIPOS_CodTipoMonedaChanged As EventHandler
    Public Event PRECI_PrecioChanged As EventHandler
    Public Event PrecioLogisticaChanged As EventHandler
   Public Event PRECI_TipoCambioChanged As EventHandler

   Public Sub OnZONAS_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ZONAS_CodigoChanged(sender, e)
   End Sub

   Public Sub OnARTIC_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ARTIC_CodigoChanged(sender, e)
   End Sub

   Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
   End Sub

   Public Sub OnPRECI_PrecioChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent PRECI_PrecioChanged(sender, e)
    End Sub
    '_M
    Public Sub OnPrecioLogisticaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PrecioLogisticaChanged(sender, e)
    End Sub

   Public Sub OnPRECI_TipoCambioChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent PRECI_TipoCambioChanged(sender, e)
   End Sub


#End Region

#Region " Metodos "

   Public Sub Instanciar(ByVal x_instancia As ACEInstancia)
      Select Case x_instancia
         Case ACEInstancia.Consulta
            m_nuevo = False
            m_modificado = False
            m_eliminado = False
         Case ACEInstancia.Nuevo
            m_nuevo = True
            m_modificado = False
            m_eliminado = False
         Case ACEInstancia.Modificado
            m_nuevo = False
            m_modificado = True
            m_eliminado = False
         Case ACEInstancia.Eliminado
            m_nuevo = False
            m_modificado = False
            m_eliminado = True
      End Select
   End Sub

   Public Sub ActualizarInstancia()
      If Not Nuevo Then
         If Not Eliminado Then
            Instanciar(ACEInstancia.Modificado)
         End If
      End If
   End Sub

#End Region

End Class
