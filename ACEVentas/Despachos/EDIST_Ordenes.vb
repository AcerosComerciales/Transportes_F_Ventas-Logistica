Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework
Imports Microsoft.SqlServer.Server

Partial Public Class EDIST_Ordenes

#Region " Campos "
   Private m_listdist_ordenesdetalle As List(Of EDIST_OrdenesDetalle)

   Private m_seleccion As Boolean
   Private m_documento As String
   Private m_docventa As String
   Private m_almac_origen As String
   Private m_pvent_origen As String
   Private m_pvent_destino As String
   Private m_entid_direccion As String
   Private m_codigo As String
    Private m_usuario As String
    Private m_tipo_des as string    
    Private m_usu_Modificador As String
   Private m_peso As Decimal
   Private m_cliente As String
   Private m_orden_fechaentrega_old As DateTime
   Private m_ordenescondicion as string
   Private m_artic_descripcion As string
   Private m_artic_codigo as string
   Private m_artic_cantidad As decimal
#End Region

#Region" Constructores "
	
#End Region

#Region " Propiedades "

   Public Property ListDIST_OrdenesDetalle() As List(Of EDIST_OrdenesDetalle)
      Get
         Return m_listdist_ordenesdetalle
      End Get
      Set(ByVal value As List(Of EDIST_OrdenesDetalle))
         m_listdist_ordenesdetalle = value
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

   Public Property PVENT_Destino() As String
      Get
         Return m_pvent_destino
      End Get
      Set(ByVal value As String)
         m_pvent_destino = value
      End Set
   End Property

   Public Property PVENT_Origen() As String
      Get
         Return m_pvent_origen
      End Get
      Set(ByVal value As String)
         m_pvent_origen = value
      End Set
   End Property

   Public Property ALMAC_Origen() As String
      Get
         Return m_almac_origen
      End Get
      Set(ByVal value As String)
         m_almac_origen = value
      End Set
   End Property

   Public Property DocVenta() As String
      Get
         Return m_docventa
      End Get
      Set(ByVal value As String)
         m_docventa = value
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

   Public Property ORDET_Cantidad() As Decimal
       Get
         Return m_artic_cantidad
      End Get
      Set(ByVal value As Decimal)
         m_artic_cantidad = value
      End Set
   End Property

   Public Property ENTID_Direccion() As String
      Get
         Return m_entid_direccion
      End Get
      Set(ByVal value As String)
         m_entid_direccion = value
      End Set
    End Property

    Public Property Usuario_Modificador() As String
        Get
            Return m_usu_Modificador
        End Get
        Set(ByVal value As String)
            m_usu_Modificador = value
        End Set
    End Property
     Public Property TIPO_Descripcion() As String
        Get
            Return m_tipo_des
        End Get
        Set(ByVal value As String)
            m_tipo_des = value
        End Set
    End Property


   Public Property Usuario() As String
      Get
         Return m_usuario
      End Get
      Set(ByVal value As String)
         m_usuario = value
      End Set
   End Property

   Public Property Codigo() As String
      Get
         Return m_codigo
      End Get
      Set(ByVal value As String)
         m_codigo = value
      End Set
   End Property


    Public Property Condicion() As String
    Get
         Return m_ordenescondicion
      End Get
      Set(ByVal value As String)
         m_ordenescondicion = value
      End Set
    End Property

   Public ReadOnly Property ORDEN_Estado_Text() As String
      Get
         Select Case m_orden_estado
            Case Constantes.getEstado(Constantes.Estado.Ingresado)
               Return Constantes.Estado.Ingresado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Anulado)
               Return Constantes.Estado.Anulado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Confirmado)
               Return Constantes.Estado.Confirmado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Eliminado)
               Return Constantes.Estado.Eliminado.ToString()
            Case Else
               Return Constantes.Estado.Ingresado.ToString()
         End Select
      End Get
   End Property

   Public Property Peso() As Decimal
      Get
         Return m_peso
      End Get
      Set(ByVal value As Decimal)
         m_peso = value
      End Set
   End Property

   Public Property Cliente() As String
      Get
         Return m_cliente
      End Get
      Set(ByVal value As String)
         m_cliente = value
      End Set
   End Property

   Public Property ORDEN_FechaEntrega_Old() As DateTime
      Get
         Return m_orden_fechaentrega_old
      End Get
      Set(ByVal value As DateTime)
         m_orden_fechaentrega_old = value
      End Set
   End Property

        Public Property ARTIC_Codigo() As String
      Get
         Return m_artic_codigo 
      End Get
      Set(ByVal value As String)
         m_artic_codigo = value
      End Set
   End Property

   Public Property ARTIC_Descripcion() As String
      Get
         Return m_artic_descripcion
      End Get
      Set(ByVal value As String)
         m_artic_descripcion = value
      End Set
   End Property

#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

