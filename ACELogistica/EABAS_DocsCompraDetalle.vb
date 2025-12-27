Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports ACEVentas


Partial Public Class EABAS_DocsCompraDetalle
   Implements ICloneable

#Region " Variables "
   Private m_earticulo As EArticulos
   Private m_artic_descripcion As String
   Private m_tipos_unidadmedida As String
   Private m_tipos_unidmedicorta As String
   Private m_tipos_tipodestino As String
   Private m_costo As Decimal
   Private m_costoigv As Decimal
   Private m_servicio As Decimal
   Private m_cantidadtotal As Decimal
   Private m_artic_desServicio As String
   Private m_artic_codServicio As String

   Private m_abas_costeos As EABAS_Costeos

   Private m_cflete As EABAS_Costeos
   Private m_cgasto As EABAS_Costeos
   Private m_cservicios As EABAS_Costeos
   Private m_ccosteos As List(Of EABAS_Costeos)

   Private m_entid_razonsocial As String
   Private m_documento As String

   Private m_coste_cantidad As Short
   Private m_coste_item As Short
   Private m_docco_fechadocumento As Date
   Private m_descuentos As Decimal
   Private m_seleccionar As Boolean

   Private m_diferencia As Decimal
   Private m_entregado As Decimal

   Private m_tipos_codtipomoneda As String
   Private m_tipos_tipomoneda As String
#End Region

#Region " Propiedades "

   Public Property Articulo() As EArticulos
      Get
         Return m_earticulo
      End Get
      Set(ByVal value As EArticulos)
         m_earticulo = value
      End Set
   End Property

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
         Return m_tipos_unidadmedida
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_unidadmedida) Then
            If Not m_tipos_unidadmedida.Equals(value) Then
               m_tipos_unidadmedida = value
            End If
         Else
            m_tipos_unidadmedida = value
         End If
      End Set
   End Property

   Public Property TIPOS_UnidadMedidaCorta() As String
      Get
         Return m_tipos_unidmedicorta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_unidmedicorta) Then
            If Not m_tipos_unidmedicorta.Equals(value) Then
               m_tipos_unidmedicorta = value
            End If
         Else
            m_tipos_unidmedicorta = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoDestino() As String
      Get
         Return m_tipos_tipodestino
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipodestino) Then
            If Not m_tipos_tipodestino.Equals(value) Then
               m_tipos_tipodestino = value
            End If
         Else
            m_tipos_tipodestino = value
         End If
      End Set
   End Property

   Public Property ABAS_Costeos() As EABAS_Costeos
      Get
         Return m_abas_costeos
      End Get
      Set(ByVal value As EABAS_Costeos)
         m_abas_costeos = value
      End Set
   End Property

   Public Property CantidadTotal() As Decimal
      Get
         Return m_cantidadtotal
      End Get
      Set(ByVal value As Decimal)
         m_cantidadtotal = value
      End Set
   End Property

   Public Property Costo() As Decimal
      Get
         Return m_costo
      End Get
      Set(ByVal value As Decimal)
         m_costo = value
      End Set
   End Property

   Public Property CostoIGV() As Decimal
      Get
         Return m_costoigv
      End Get
      Set(ByVal value As Decimal)
         m_costoigv = value
      End Set
   End Property

   Public Property Servicio() As Decimal
      Get
         Return m_servicio
      End Get
      Set(ByVal value As Decimal)
         m_servicio = value
      End Set
   End Property

   Public Property CFlete() As EABAS_Costeos
      Get
         Return m_cflete
      End Get
      Set(ByVal value As EABAS_Costeos)
         m_cflete = value
      End Set
   End Property

   Public Property ARTIC_CodServicio() As String
      Get
         Return m_artic_codServicio
      End Get
      Set(ByVal value As String)
         m_artic_codServicio = value
      End Set
   End Property

   Public Property ARTIC_DesServicio() As String
      Get
         Return m_artic_desServicio
      End Get
      Set(ByVal value As String)
         m_artic_desServicio = value
      End Set
   End Property

   Public Property CGasto() As EABAS_Costeos
      Get
         Return m_cgasto
      End Get
      Set(ByVal value As EABAS_Costeos)
         m_cgasto = value
      End Set
   End Property

   Public Property CServicios() As EABAS_Costeos
      Get
         Return m_cservicios
      End Get
      Set(ByVal value As EABAS_Costeos)
         m_cservicios = value
      End Set
   End Property

   Public Property CCosteos() As List(Of EABAS_Costeos)
      Get
         Return m_ccosteos
      End Get
      Set(ByVal value As List(Of EABAS_Costeos))
         m_ccosteos = value
      End Set
   End Property

   Public Property COSTE_Cantidad() As Short
      Get
         Return m_coste_cantidad
      End Get
      Set(ByVal value As Short)
         If Not IsNothing(m_coste_cantidad) Then
            If Not m_coste_cantidad.Equals(value) Then
               m_coste_cantidad = value
            End If
         Else
            m_coste_cantidad = value
         End If
      End Set
   End Property

   Public Property COSTE_Item() As Short
      Get
         Return m_coste_item
      End Get
      Set(ByVal value As Short)
         If Not IsNothing(m_coste_item) Then
            If Not m_coste_item.Equals(value) Then
               m_coste_item = value
            End If
         Else
            m_coste_item = value
         End If
      End Set
   End Property

   Public Property DOCCO_FechaDocumento() As Date
      Get
         Return m_docco_fechadocumento
      End Get
      Set(ByVal value As Date)
         If Not IsNothing(m_docco_fechadocumento) Then
            If Not m_docco_fechadocumento.Equals(value) Then
               m_docco_fechadocumento = value
            End If
         Else
            m_docco_fechadocumento = value
         End If
      End Set
   End Property

   Public Property Descuentos() As Decimal
      Get
         Return m_descuentos
      End Get
      Set(ByVal value As Decimal)
         m_descuentos = value
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

   Public Property Diferencia() As Decimal
      Get
         Return m_diferencia
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_diferencia) Then
            If Not m_diferencia.Equals(value) Then
               m_diferencia = value
            End If
         Else
            m_diferencia = value
         End If
      End Set
   End Property

   Public Property Entregado() As Decimal
      Get
         Return m_entregado
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_entregado) Then
            If Not m_entregado.Equals(value) Then
               m_entregado = value
            End If
         Else
            m_entregado = value
         End If
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

   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
      End Set
   End Property

   Public Property TIPOS_CodTipoMoneda() As String
      Get
         Return m_tipos_codtipomoneda
      End Get
      Set(ByVal value As String)
         m_tipos_codtipomoneda = value
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
   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New EABAS_DocsCompraDetalle()
         cloneInstance = CType(Me, EABAS_DocsCompraDetalle)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Descuentos "
   Private m_descuento_1 As Decimal
   Private m_descuento_2 As Decimal
   Private m_descuento_3 As Decimal
   Private m_descuento_4 As Decimal
   Private m_descuento_5 As Decimal
   Private m_descuento_6 As Decimal
   Private m_descuento_7 As Decimal
   Private m_descuento_8 As Decimal
   Private m_descuento_9 As Decimal
   Private m_descuento_10 As Decimal

#Region " Propiedades "

   Public Property Descuento_1() As Decimal
      Get
         Return m_descuento_1
      End Get
      Set(ByVal value As Decimal)
         m_descuento_1 = value
      End Set
   End Property

   Public Property Descuento_2() As Decimal
      Get
         Return m_descuento_2
      End Get
      Set(ByVal value As Decimal)
         m_descuento_2 = value
      End Set
   End Property

   Public Property Descuento_3() As Decimal
      Get
         Return m_descuento_3
      End Get
      Set(ByVal value As Decimal)
         m_descuento_3 = value
      End Set
   End Property

   Public Property Descuento_4() As Decimal
      Get
         Return m_descuento_4
      End Get
      Set(ByVal value As Decimal)
         m_descuento_4 = value
      End Set
   End Property

   Public Property Descuento_5() As Decimal
      Get
         Return m_descuento_5
      End Get
      Set(ByVal value As Decimal)
         m_descuento_5 = value
      End Set
   End Property

   Public Property Descuento_6() As Decimal
      Get
         Return m_descuento_6
      End Get
      Set(ByVal value As Decimal)
         m_descuento_6 = value
      End Set
   End Property

   Public Property Descuento_7() As Decimal
      Get
         Return m_descuento_7
      End Get
      Set(ByVal value As Decimal)
         m_descuento_7 = value
      End Set
   End Property

   Public Property Descuento_8() As Decimal
      Get
         Return m_descuento_8
      End Get
      Set(ByVal value As Decimal)
         m_descuento_8 = value
      End Set
   End Property

   Public Property Descuento_9() As Decimal
      Get
         Return m_descuento_9
      End Get
      Set(ByVal value As Decimal)
         m_descuento_9 = value
      End Set
   End Property

   Public Property Descuento_10() As Decimal
      Get
         Return m_descuento_10
      End Get
      Set(ByVal value As Decimal)
         m_descuento_10 = value
      End Set
   End Property
#End Region


#End Region

End Class
