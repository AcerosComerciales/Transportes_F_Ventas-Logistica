Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration
Imports System.Configuration
Imports ACEVentas

Imports DAConexion
Imports ACFramework

Imports ACBLogistica

Public Class BGenerarCotizCompra

#Region " Variables "
   Private m_eabast_cotizacionescompra As EABAS_CotizacionesCompra
   Private m_evendedor As EEntidades
   Private m_eproveedor As EEntidades
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

   Public Property EABAST_CotizacionesCompra() As EABAS_CotizacionesCompra
      Get
         Return m_eabast_cotizacionescompra
      End Get
      Set(ByVal value As EABAS_CotizacionesCompra)
         m_eabast_cotizacionescompra = value
      End Set
   End Property

   Public Property Proveedor() As EEntidades
      Get
         Return m_eproveedor
      End Get
      Set(ByVal value As ACEVentas.EEntidades)
         m_evendedor = value
      End Set

   End Property


#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "

   ''' <summary>
   ''' Grabar la cotización de compra
   ''' </summary>
   ''' <param name="x_usuario"></param>
   ''' <param name="x_msg"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabaCotizCompra(ByVal x_usuario As String, ByRef x_msg As String) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_bABAS_CotizacionesCompra As New BABAS_CotizacionesCompra() With {.ABAS_CotizacionesCompra = m_eabast_cotizacionescompra}
         m_bABAS_CotizacionesCompra.ABAS_CotizacionesCompra.COTCO_Id = m_bABAS_CotizacionesCompra.getCorrelativo("COTCO_Id")
         '' Iniciar transaccion
         DAEnterprise.BeginTransaction()
         If m_bABAS_CotizacionesCompra.Guardar(x_usuario) Then
            Dim i As Integer = 1
            '' Eliminar todo el detalle en caso de que existan
            Dim m_detalle As New BABAS_CotizacionesCompraDetalle()
            Dim x_where As New Hashtable() : x_where.Add("COTCO_Codigo", New ACWhere(m_eabast_cotizacionescompra.COTCO_Codigo))
            m_detalle.Eliminar(x_where)

            '' Grabar los detalles
            For Each Item As EABAS_CotizacionesCompraDetalle In m_bABAS_CotizacionesCompra.ABAS_CotizacionesCompra.ListABAS_CotizacionesCompraDetalle
               Item.COTCO_Codigo = m_bABAS_CotizacionesCompra.ABAS_CotizacionesCompra.COTCO_Codigo
               Item.COTCD_Item = i
               Item.Instanciar(ACEInstancia.Nuevo)
               i += 1
               Dim m_babas_cotizacionescompradetalle As New BABAS_CotizacionesCompraDetalle() With {.ABAS_CotizacionesCompraDetalle = Item}
               m_babas_cotizacionescompradetalle.Guardar(x_usuario)
            Next
         Else
            DAEnterprise.RollBackTransaction()
            x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
            Return False
         End If
         '' Completar Operaciones adicionales con el Pedido/Cotizacion

         '' Culminar la transaccion
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         '' Deshacer la transaccion en caso de que surja un error ed
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar cotizacion de compra
   ''' </summary>
   ''' <param name="x_cotco_codigo">codigo de la cotizacion</param>
   ''' <param name="x_detalle">opcion para cargar detalle de la cotizacion</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarCotizacion(ByVal x_cotco_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim m_babas_cotizacionescompra As New BABAS_CotizacionesCompra
         If m_babas_cotizacionescompra.Cargar(x_cotco_codigo, True) Then
            m_eabast_cotizacionescompra = New EABAS_CotizacionesCompra
            m_eabast_cotizacionescompra = m_babas_cotizacionescompra.ABAS_CotizacionesCompra
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener proveedor
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getProveedor(ByVal x_entid_codigo As String) As Boolean
      Try
         Dim m_bentidad As New ACBVentas.BEntidades
         If m_bentidad.Cargar(x_entid_codigo) Then
            m_eproveedor = m_bentidad.Entidades
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#End Region

End Class

