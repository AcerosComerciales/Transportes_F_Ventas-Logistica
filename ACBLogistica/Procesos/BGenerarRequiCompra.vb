Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration
Imports System.Configuration

Imports DAConexion
Imports ACFramework


Public Class BGenerarRequiCompra

#Region " Variables "
	
	Private m_dtGenerarRequiCompra As DataTable

	Private ds_generarrequicompra As DataSet
   Private d_generarrequicompra As DGenerarRequiCompra

   Private m_eabast_requisicionescompra As EABAS_CotizacionesCompra

#End Region

#Region " Constructores "
	
	Public Sub New()
      d_generarrequicompra = New DGenerarRequiCompra
   End Sub

#End Region

#Region " Propiedades "

   Public Property EABAST_CotizacionesCompra() As EABAS_CotizacionesCompra
      Get
         Return m_eabast_requisicionescompra
      End Get
      Set(ByVal value As EABAS_CotizacionesCompra)
         m_eabast_requisicionescompra = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   ''' <summary>
   ''' Grabar la requisición de compra
   ''' </summary>
   ''' <param name="x_usuario"></param>
   ''' <param name="x_msg"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabaRequiCompra(ByVal x_usuario As String, ByRef x_msg As String) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_bABAS_RequisicionesCompra As New BABAS_CotizacionesCompra() With {.ABAS_CotizacionesCompra = m_eabast_requisicionescompra}
         '' Iniciar transaccion
         DAEnterprise.BeginTransaction()
         If m_bABAS_RequisicionesCompra.Guardar(x_usuario) Then
            Dim i As Integer = 1
            '' Grabar los detalles
            For Each Item As EABAS_CotizacionesCompraDetalle In m_bABAS_RequisicionesCompra.ABAS_CotizacionesCompra.ListABAS_CotizacionesCompraDetalle
               Item.COTCO_Codigo = m_bABAS_RequisicionesCompra.ABAS_CotizacionesCompra.COTCO_Codigo
               Item.COTCD_Item = i
               Item.Instanciar(ACEInstancia.Nuevo)
               i += 1
               Dim m_babas_requisicionescompradetalle As New BABAS_CotizacionesCompraDetalle() With {.ABAS_CotizacionesCompraDetalle = Item}
               m_babas_requisicionescompradetalle.Guardar(x_usuario)
            Next
         Else
            DAEnterprise.RollBackTransaction()
            x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
            Return False
         End If
         '' Completar Operaciones adicionales con el Pedido/Requisicion

         '' Culminar la transaccion
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         '' Deshacer la transaccion en caso de que surja un error ed
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

#End Region

End Class

