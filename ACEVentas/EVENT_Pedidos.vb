Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EVENT_Pedidos
   Implements ICloneable

#Region " Variables "
   Private m_listDetPedidos As List(Of EVENT_PedidosDetalle)

   Private m_seleccion As Boolean
   Private m_entid_cliente As String
   Private m_entid_vendedor As String
   Private m_usuario As String
   Private m_tipos_documento As String
   Private m_tipos_moneda As String
   Private m_entid_codigo As String
   Private m_entid_nrodocumento As String
   Private m_tipos_condicionpago As String
   Private m_tipocotizacion As String
   Private m_cotizador As String
   Private m_documento as String
   Private m_prtnombre As Short
   Private m_observaciones as String
   Private m_condiciones As String
   Private m_entrega As String
   Private m_nota As String
   Private m_docventa As String
   Private m_pvtaorigen As String
   Private m_pvtarelacionado As String
   Private m_pvtadestino As String
   Private m_artic_codigo as String
   Private m_artic_descripcion As String
   Private m_cantidadarticulo as Decimal

   Private m_pedid_fechaentrega_old As DateTime

   Enum TipoPedido
      CT
      PD
      PR
      GR
      PI
      PS
      C
      OC
   End Enum

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
      Rehusado
      Nuevo
   End Enum

#End Region

#Region " Propiedades "

   Public Property Seleccion() As Boolean
      Get
         Return m_seleccion
      End Get
      Set(ByVal value As Boolean)
         m_seleccion = value
      End Set
   End Property


   Public Property TIPOS_CondicionPago() As String
      Get
         Return m_tipos_condicionpago
      End Get
      Set(ByVal value As String)
         m_tipos_condicionpago = value
      End Set
   End Property

   Public Property ListDetPedidos() As List(Of EVENT_PedidosDetalle)
      Get
         Return m_listDetPedidos
      End Get
      Set(ByVal value As List(Of EVENT_PedidosDetalle))
         m_listDetPedidos = value
      End Set
   End Property

   Public Property ENTID_Cliente() As String
      Get
         Return m_entid_cliente
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_cliente) Then
            If Not m_entid_cliente.Equals(value) Then
               m_entid_cliente = value
            End If
         Else
            m_entid_cliente = value
         End If
      End Set
   End Property

   Public Property ENTID_Vendedor() As String
      Get
         Return m_entid_vendedor
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_vendedor) Then
            If Not m_entid_vendedor.Equals(value) Then
               m_entid_vendedor = value
            End If
         Else
            m_entid_vendedor = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoDocumento() As String
      Get
         Return m_tipos_documento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_documento) Then
            If Not m_tipos_documento.Equals(value) Then
               m_tipos_documento = value
            End If
         Else
            m_tipos_documento = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoMoneda() As String
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

   Public ReadOnly Property PEDID_Estado_Text() As String
      Get
         Select Case m_pedid_estado
            Case getEstado(Estado.Ingresado)
               Return Estado.Ingresado.ToString()
            Case getEstado(Estado.Anulado)
               Return Estado.Anulado.ToString()
            Case getEstado(Estado.Confirmado)
               Return Estado.Confirmado.ToString()
            Case getEstado(Estado.Eliminado)
               Return Estado.Eliminado.ToString()
            Case getEstado(Estado.Rehusado)
               Return Estado.Rehusado.ToString()
            Case getEstado(Estado.Nuevo)
               Return Estado.Nuevo.ToString()
            Case Else
               Return Estado.Ingresado.ToString()
         End Select
      End Get
   End Property
     Public ReadOnly Property Documento()
      Get
         Return m_pedid_codigo.Substring(0,2) & "-" & m_pedid_codigo.Substring(2,3).ToString().PadLeft(3,"0") & "-" & m_pedid_numero.ToString().PadLeft(8,"0")
      End Get
     
   End Property
    Public Property Observaciones() As String
        Get
            Return m_observaciones

        End Get
        Set(ByVal value As String)
            m_observaciones = value

        End Set
    End Property

    Public Property PDDET_Cantidad as Decimal
    
        Get
            Return m_cantidadarticulo

        End Get
        Set(ByVal value As Decimal)
            m_cantidadarticulo = value

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

   Public Property ENTID_Codigo() As String
      Get
         Return m_entid_codigo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_codigo) Then
            If Not m_entid_codigo.Equals(value) Then
               m_entid_codigo = value
            End If
         Else
            m_entid_codigo = value
         End If
      End Set
   End Property

   Public Property ENTID_NroDocumento() As String
      Get
         Return m_entid_nrodocumento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_nrodocumento) Then
            If Not m_entid_nrodocumento.Equals(value) Then
               m_entid_nrodocumento = value
            End If
         Else
            m_entid_nrodocumento = value
         End If
      End Set
   End Property

   Public ReadOnly Property Condicion() As String
      Get
         Select Case m_pedid_estentrega
            Case "E"
               Return "Entrega Directa"
            Case "P"
               Return "Pendiente / Adj. Guia"
            Case Else
               Return "Entrega Directa"
         End Select
      End Get
   End Property

   Public Property TipoDeCotizacion() As String
      Get
         Return m_tipocotizacion
      End Get
      Set(ByVal value As String)
         m_tipocotizacion = value
      End Set
   End Property

   Public Property Cotizador() As String
      Get
         Return m_cotizador
      End Get
      Set(ByVal value As String)
         m_cotizador = value
      End Set
   End Property

   Public Property PrtNombre() As Short
      Get
         Return m_prtnombre
      End Get
      Set(ByVal value As Short)
         m_prtnombre = value
      End Set
   End Property

   Public Shared ReadOnly Property TipoCotizacion(ByVal x_tipo As TipoPedido) As String
      Get
         Select Case x_tipo
            Case TipoPedido.CT
               Return "C"
            Case TipoPedido.PD
               Return "P"
            Case TipoPedido.PR
               Return "R"
            Case TipoPedido.PS
               Return "S"
            Case Else
               Return "C"
         End Select
      End Get
   End Property

   Public Shared ReadOnly Property TipoCotizacion(ByVal x_tipo As String) As TipoPedido
      Get
         Select Case x_tipo
            Case "C"
               Return TipoPedido.CT
            Case "P"
               Return TipoPedido.PD
            Case "R"
               Return TipoPedido.PR
            Case "S"
               Return TipoPedido.PS
            Case Else
               Return "C"
         End Select
      End Get
   End Property

   Public Shared ReadOnly Property TipoCotizacionCodigo(ByVal x_tipo As String) As TipoPedido
      Get
         Select Case x_tipo.Substring(0, 2)
            Case "CT"
               Return TipoPedido.CT
            Case "PD"
               Return TipoPedido.PD
            Case "PR"
               Return TipoPedido.PR
            Case "PS"
               Return TipoPedido.PS
            Case "PI"
               Return TipoPedido.PI
                Case Else
                    'Return "C"
                    Return TipoPedido.C
            End Select
      End Get
   End Property


   Public Property Condiciones() As String
      Get
         Return m_condiciones
      End Get
      Set(ByVal value As String)
         m_condiciones = value
      End Set
   End Property

   Public Property Entrega() As String
      Get
         Return m_entrega
      End Get
      Set(ByVal value As String)
         m_entrega = value
      End Set
   End Property

   Public Property Nota() As String
      Get
         Return m_nota
      End Get
      Set(ByVal value As String)
         m_nota = value
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

   Public Property PVtaOrigen() As String
      Get
         Return m_pvtaorigen
      End Get
      Set(ByVal value As String)
         m_pvtaorigen = value
      End Set
   End Property

   Public Property PVtaRelacionado() As String
      Get
         Return m_pvtarelacionado
      End Get
      Set(ByVal value As String)
         m_pvtarelacionado = value
      End Set
   End Property

   Public Property PVtaDestino() As String
      Get
         Return m_pvtadestino
      End Get
      Set(ByVal value As String)
         m_pvtadestino = value
      End Set
   End Property

   Public Property PEDID_FechaEntrega_Old() As DateTime
      Get
         Return m_pedid_fechaentrega_old
      End Get
      Set(ByVal value As DateTime)
         m_pedid_fechaentrega_old = value
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
         Case Estado.Rehusado
            Return "R"
         Case Estado.Nuevo
            Return "N"
         Case Else
            Return "I"
      End Select

   End Function

   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New EVENT_Pedidos()
         cloneInstance = CType(Me, EVENT_Pedidos)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class
