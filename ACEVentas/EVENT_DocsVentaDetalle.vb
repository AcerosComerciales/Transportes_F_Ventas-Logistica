Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Partial Public Class EVENT_DocsVentaDetalle

#Region " Variables "
   Private m_artic_descripcion As String
   Private m_tipos_tipounidad As String
   Private m_tipos_unidadmedidacorta As String
   Private m_almac_descripcion As String

   Private m_diferencia As Double
   Private m_entregado As Double
   Private m_tipos_codunidadmedida As String

   Private m_articulos As EArticulos

   Private m_documento As String
   Private m_docve_fechadocumento As DateTime
   Private m_entid_codigocliente As String
   Private m_docve_descripcioncliente As String
   Private m_entid_codigo As String
   Private m_saldo As Decimal
   Private m_artic_detalle As String
   Private m_seleccionar As Boolean
   Private m_faltante As Decimal

   Private m_importesoles As Decimal
   Private m_importedolares As Decimal
   Private m_subpeso As Decimal
   Private m_utilidad As Decimal
   Private m_vendedor As String
   Private m_entid_codigovendedor As String

   Private m_linea As String
   Private m_sublinea As String

   Private m_anho As Short
    Private m_mes As Short
    Private m_estado As String

#End Region

#Region " Propiedades "
   Public Property ARTIC_Descripcion() As String
      Get
         Return m_artic_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_artic_descripcion) Then
            If Not m_artic_descripcion.Equals(value) Then
               m_artic_descripcion = value
            End If
         Else
            m_artic_descripcion = value
         End If
      End Set
   End Property

   Public Property TIPOS_UnidadMedida() As String
      Get
         Return m_tipos_tipounidad
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipounidad) Then
            If Not m_tipos_tipounidad.Equals(value) Then
               m_tipos_tipounidad = value
            End If
         Else
            m_tipos_tipounidad = value
         End If
      End Set
   End Property

   Public Property TIPOS_UnidadMedidaCorta() As String
      Get
         Return m_tipos_unidadmedidacorta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_unidadmedidacorta) Then
            If Not m_tipos_unidadmedidacorta.Equals(value) Then
               m_tipos_unidadmedidacorta = value
            End If
         Else
            m_tipos_unidadmedidacorta = value
         End If
      End Set
   End Property

   Public Property ALMAC_Descripcion() As String
      Get
         Return m_almac_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_almac_descripcion) Then
            If Not m_almac_descripcion.Equals(value) Then
               m_almac_descripcion = value
            End If
         Else
            m_almac_descripcion = value
         End If
      End Set
   End Property

   Public Property Diferencia() As Double
      Get
         Return m_diferencia
      End Get
      Set(ByVal value As Double)
         If Not IsNothing(m_diferencia) Then
            If Not m_diferencia.Equals(value) Then
               m_diferencia = value
            End If
         Else
            m_diferencia = value
         End If
      End Set
   End Property

   Public Property Entregado() As Double
      Get
         Return m_entregado
      End Get
      Set(ByVal value As Double)
         If Not IsNothing(m_entregado) Then
            If Not m_entregado.Equals(value) Then
               m_entregado = value
            End If
         Else
            m_entregado = value
         End If
      End Set
   End Property

   Public Property TIPOS_CodUnidadMedida() As String
      Get
         Return m_tipos_codunidadmedida
      End Get
      Set(ByVal value As String)
         m_tipos_codunidadmedida = value
      End Set
   End Property

   Public Property Articulo() As EArticulos
      Get
         Return m_articulos
      End Get
      Set(ByVal value As EArticulos)
         m_articulos = value
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

   Public Property DOCVE_FechaDocumento() As DateTime
      Get
         Return m_docve_fechadocumento
      End Get
      Set(ByVal value As DateTime)
         m_docve_fechadocumento = value
      End Set
   End Property

   Public Property ENTID_CodigoCliente() As String
      Get
         Return m_entid_codigocliente
      End Get
      Set(ByVal value As String)
         m_entid_codigocliente = value
      End Set
   End Property

   Public Property DOCVE_DescripcionCliente() As String
      Get
         Return m_docve_descripcioncliente
      End Get
      Set(ByVal value As String)
         m_docve_descripcioncliente = value
      End Set
   End Property

   Public Property ENTID_Codigo() As String
      Get
         Return m_entid_codigo
      End Get
      Set(ByVal value As String)
         m_entid_codigo = value
      End Set
   End Property

   Public Property Saldo() As Decimal
      Get
         Return m_saldo
      End Get
      Set(ByVal value As Decimal)
         m_saldo = value
      End Set
   End Property

   Public Property ARTIC_Detalle() As String
      Get
         Return m_artic_detalle
      End Get
      Set(ByVal value As String)
         m_artic_detalle = value
      End Set
   End Property
  

   Public Property Seleccionar() As Boolean
      Get
         Return m_seleccionar
      End Get
      Set(ByVal value As Boolean)
         m_seleccionar = value
      End Set
   End Property

   Public Property Faltante() As Decimal
      Get
         Return m_faltante
      End Get
      Set(ByVal value As Decimal)
         m_faltante = value
      End Set
   End Property

   Public Property ImporteSoles() As Decimal
      Get
         Return m_importesoles
      End Get
      Set(ByVal value As Decimal)
         m_importesoles = value
      End Set
   End Property

   Public Property ImporteDolares() As Decimal
      Get
         Return m_importedolares
      End Get
      Set(ByVal value As Decimal)
         m_importedolares = value
      End Set
   End Property

   Public Property SubPeso() As Decimal
      Get
         Return m_subpeso
      End Get
      Set(ByVal value As Decimal)
         m_subpeso = value
      End Set
   End Property



   Public Property Utilidad() As Decimal
      Get
         Return m_utilidad
      End Get
      Set(ByVal value As Decimal)
         m_utilidad = value
      End Set
   End Property
   
   Public Property Linea() As String
      Get
         Return m_linea
      End Get
      Set(ByVal value As String)
         m_linea = value
      End Set
   End Property

   Public Property SubLinea() As String
      Get
         Return m_sublinea
      End Get
      Set(ByVal value As String)
         m_sublinea = value
      End Set
   End Property

   Public Property Vendedor() As String
      Get
         Return m_vendedor
      End Get
      Set(ByVal value As String)
         m_vendedor = value
      End Set
   End Property

   Public Property ENTID_CodigoVendedor() As String
      Get
         Return m_entid_codigovendedor
      End Get
      Set(ByVal value As String)
         m_entid_codigovendedor = value
      End Set
   End Property


   Public Property Anho() As Short
      Get
         Return m_anho
      End Get
      Set(ByVal value As Short)
         m_anho = value
      End Set
   End Property

   Public Property Mes() As Short
      Get
         Return m_mes
      End Get
      Set(ByVal value As Short)
         m_mes = value
      End Set
   End Property

    Public Property DOCVE_Estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = value
        End Set
    End Property


#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

End Class
