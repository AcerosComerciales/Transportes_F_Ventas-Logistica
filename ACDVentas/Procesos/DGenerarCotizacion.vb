Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DGenerarCotizacion


#Region " Variables "
   Private m_formatofecha As String
#End Region

#Region " Constructores "
   Public Sub New()
      m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
   End Sub
#End Region

#Region " Procedimientos Almacenados "

   Public Function getCorrelativo(ByVal x_pvent_id As Long, ByVal x_tipo As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectAllC(x_pvent_id, x_tipo), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("Codigo"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
       Public Function getImpresiones(ByVal x_pedid_codigo As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectimpresiones(x_pedid_codigo), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("Codigo"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
     Public sub getActualizar(ByVal x_pedid_codigo As String, ByVal x_imprsiones As Integer) 
      Try
         DAEnterprise.AsignarProcedure(getactualizar_t(x_pedid_codigo,x_imprsiones), CommandType.Text)
         DAEnterprise.ExecuteNonQuery()
        
      Catch ex As Exception
         Throw ex
      End Try
   End Sub


  Public Function getCorrelativoCorte(ByVal x_pvent_id As Long, ByVal x_tipo As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectAllCorte(x_pvent_id, x_tipo), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("Codigo"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    Public Function getcantidadlimite(ByVal X_codigorelacionado As String, ByVal x_artic_codigo As String, ByVal tipo_documento As String) As Decimal
      Try
         DAEnterprise.AsignarProcedure(getSelectcantidadlimite(X_codigorelacionado, x_artic_codigo,tipo_documento), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("cantidad"), Decimal)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#Region " Adicionales "

   Private Function getSelectAll(ByVal x_zonas_codigo As String, ByVal x_artic_codigo As String)
      Dim sql As String = ""
      Try
         App.Inicializar()
         Dim _where As New ACGenerador(Of EEntidades)(m_formatofecha)
         sql &= String.Format(App.Hash("DConsultaArticulos.cargarPrecios").ToString(), x_artic_codigo, x_zonas_codigo)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectAllC(ByVal x_pvent_id As Long, ByVal x_tipo As String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" SELECT Convert(Int, IsNull(Max(PEDID_Numero), '0')) As Codigo FROM Ventas.VENT_Pedidos {0}", vbNewLine)
         sql &= String.Format(" Where PVENT_Id = {0} And PEDID_Tipo = '{1}' {2}", x_pvent_id.ToString, x_tipo, vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    Private Function getSelectimpresiones(ByVal x_pedid_codigo as String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" SELECT IsNull(PEDID_Impresiones,0) As Codigo FROM Ventas.VENT_Pedidos {0}", vbNewLine)
         sql &= String.Format(" Where PEDID_Codigo = '{0}' ", x_pedid_codigo.ToString,  vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
     Private Function getactualizar_t(ByVal x_pedid_codigo as String,ByVal x_impresiones as Integer) As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" update Ventas.VENT_Pedidos ", vbNewLine)
         sql &= String.Format(" set PEDID_Impresiones={0}",x_impresiones, vbNewLine)
         sql &= String.Format(" Where PEDID_Codigo = '{0}' ", x_pedid_codigo.ToString,  vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

  Private Function getSelectAllCorte(ByVal x_pvent_id As Long, ByVal x_tipo As String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" SELECT Convert(Int, IsNull(Max(PEDID_Numero), '0')) As Codigo FROM Ventas.VENT_Pedidos {0}", vbNewLine)
         sql &= String.Format(" Where PVENT_Id = {0} And TIPOS_CodTipoDocumento = '{1}' {2}", x_pvent_id.ToString, x_tipo, vbNewLine)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
      Private Function getSelectcantidadlimite(ByVal X_codigorelacionado As String, ByVal x_artic_codigo As String, ByVal tipo_documento As String) As String
      Dim sql As String = ""
      Try
            Select tipo_documento
                Case  ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Boleta),ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura)
                        sql &= String.Format(" Select isnull(DOCVD_Cantidad - (select sum(vdd.PDDET_PesoUnitario*vdd.PDDET_Cantidad) from Ventas.VENT_PedidosDetalle vdd, Ventas.VENT_Pedidos v", vbNewLine)
                        sql &= String.Format(" where vdd.PEDID_Codigo=v.PEDID_Codigo and", vbNewLine)
                        sql &= String.Format(" v.PEDID_CodRelacionado=ven.DOCVE_Codigo  and",  vbNewLine)
                        sql &= String.Format(" vdd.ARTIC_Codigo=vd.ARTIC_Codigo and", vbNewLine)
                        sql &= String.Format(" v.TIPOS_CodTipoDocumento='CPDOCT' ", vbNewLine)
                        sql &= String.Format(" group by ARTIC_Codigo),DOCVD_Cantidad) as cantidad", vbNewLine)
                        sql &= String.Format(" from Ventas.VENT_DocsVentaDetalle vd, Ventas.VENT_DocsVenta ven", vbNewLine)
                        sql &= String.Format(" where vd.DOCVE_Codigo=ven.DOCVE_Codigo and", vbNewLine)
                        sql &= String.Format(" vD.DOCVE_Codigo='{0}' AND ARTIC_Codigo='{1}'", X_codigorelacionado.ToString, x_artic_codigo, vbNewLine)
                Case  ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.PedidoReposicion)

                        sql &= String.Format(" Select isnull(pd.PDDET_Cantidad - (select sum(vdd.PDDET_PesoUnitario*vdd.PDDET_Cantidad) from Ventas.VENT_PedidosDetalle vdd, Ventas.VENT_Pedidos v ", vbNewLine)
                        sql &= String.Format(" where vdd.PEDID_Codigo=v.PEDID_Codigo and v.PEDID_CodRelacionado=p.PEDID_Codigo  and vdd.ARTIC_Codigo=pd.ARTIC_Codigo AND ", vbNewLine)
                        sql &= String.Format(" v.TIPOS_CodTipoDocumento='CPDOCT' group by ARTIC_Codigo),PDDET_Cantidad) as cantidad from Ventas.VENT_PedidosDetalle pd, Ventas.VENT_Pedidos p",  vbNewLine)
                        sql &= String.Format(" where  pd.PEDID_Codigo=p.PEDID_Codigo and pd.PEDID_Codigo='{0}' AND   ARTIC_Codigo='{1}'", X_codigorelacionado.ToString, x_artic_codigo, vbNewLine)
                        
                Case ETipos.getTipoOrdenRecojo(ETipos.TipoOrdenRecojo.RecojoSalida) 
                        sql &= String.Format(" Select  isnull(ORDET_Cantidad -  (select sum(vdd.PDDET_PesoUnitario*vdd.PDDET_Cantidad) from Ventas.VENT_PedidosDetalle vdd, Ventas.VENT_Pedidos v ", vbNewLine)
                    sql &= String.Format(" where vdd.PEDID_Codigo=v.PEDID_Codigo and   v.PEDID_CodRelacionado=o.ORDEN_Codigo  and   vdd.ARTIC_Codigo=od.ARTIC_Codigo and v.TIPOS_CodTipoDocumento='CPDOCT' and v.PEDID_Estado <>'X' ", vbNewLine)
                        sql &= String.Format(" group by ARTIC_Codigo),ORDET_Cantidad) as cantidad from Logistica.DIST_OrdenesDetalle od, Logistica.DIST_Ordenes o ",  vbNewLine)
                        sql &= String.Format(" where  od.ORDEN_Codigo=o.ORDEN_Codigo and", vbNewLine)
                        sql &= String.Format(" oD.ORDEN_Codigo='{0}' AND   ARTIC_Codigo='{1}'", X_codigorelacionado.ToString, x_artic_codigo, vbNewLine)
                Case ETipos.getTiposPedidoTransformacion(ETipos.TiposPedidoTransformacion.SalidaPedidoTransformacion) 
                        sql &= String.Format(" Select  isnull(PEDID_Cantidad - (select sum(vdd.PDDET_PesoUnitario*vdd.PDDET_Cantidad) from Ventas.VENT_PedidosDetalle vdd, Ventas.VENT_Pedidos v ", vbNewLine)
                        sql &= String.Format(" where vdd.PEDID_Codigo=v.PEDID_Codigo and v.PEDID_CodRelacionado=p.PEDID_CodigoTrans  and vdd.ARTIC_Codigo=pd.ARTIC_Codigo and v.TIPOS_CodTipoDocumento='CPDOCT'", vbNewLine)
                        sql &= String.Format(" group by ARTIC_Codigo),PEDID_Cantidad) as cantidad from Logistica.ABAS_PedidoTransformacionDetalle pd, Logistica.ABAS_PedidoTransformacion p",  vbNewLine)
                        sql &= String.Format(" where  pd.PEDID_CodigoTrans=p.PEDID_CodigoTrans and", vbNewLine)
                        sql &= String.Format(" pD.PEDID_CodigoTrans='{0}' AND   ARTIC_Codigo='{1}'", X_codigorelacionado.ToString, x_artic_codigo, vbNewLine)

            End Select
             


         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ' <summary> 
    ' Capa de Datos: obtener orden compra
    ' </summary>
    ' <param name="x_artic_codigo">Parametro 1: </param> 
    ' <param name="x_zonas_codigo">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function obtener_orden_compra(ByVal x_orden_compra As String, ByVal x_documento As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("orde_compra")
            DAEnterprise.AgregarParametro("@orden_compra", x_orden_compra, DbType.String, 15)
            DAEnterprise.AgregarParametro("@documento", x_documento, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

                If reader.HasRows Then
                    While reader.Read()
                        Return True
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getDateTime() As DateTime
      Dim x_datos As New DataTable()
      Try
         DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Dim _fecha As DateTime = x_datos.Rows(0)(0)
         Return _fecha
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#End Region
#End Region

#Region " Metodos "


#End Region


End Class

