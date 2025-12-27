'Imports ACBLogistica
Imports ACBTransporte
Imports ACETransporte
Imports ACEVentas
Imports ACFramework


Imports CrystalDecisions

Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports CrystalDecisions.CrystalReports.Engine

Public Class Reporte
#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

   End Sub

#End Region

#Region " Metodos "

#Region "Cuadre de Caja "

   Public Function CuadreCaja(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_imprimir As Boolean)
      Try
         Dim _btran As New BReporte(GApp.PuntoVenta)
         Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")
         Dim strReportName As String = "CRCuadreCaja.rpt"
         Dim strReportPath As String = System.IO.Path.Combine(m_Path_Plantillas, strReportName)
         If _btran.CuadreCajaC(x_fecini, x_fecfin, GApp.PuntoVenta) Then
            If x_imprimir Then

            Else ' Ver
               VisualizarCC(_btran, strReportPath, x_fecini, x_fecfin)
            End If
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function VisualizarCC(ByRef m_reporte As BReporte, ByVal strReportPath As String, _
                              ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         Dim _dsdatos As New DSCuadreCaja()
         getDatosCC(m_reporte, _dsdatos, x_fecini, x_fecfin)

         Dim Informe As New ReportDocument
         Informe.Load(strReportPath)
         Informe.SetDataSource(_dsdatos)


         Dim reporte As New RReportView(Informe) With {.StartPosition = FormStartPosition.CenterScreen}
         reporte.Text = String.Format("Reporte de Cuadre de Caja: del {0:dd/MM/yyyy} Al {1:dd/MM/yyyy}", x_fecini, x_fecfin)
         reporte.Show()

         'Informe.Close()
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getDatosCC(ByVal m_reporte As BReporte, ByRef _dsdatos As DSCuadreCaja, _
                             ByVal x_fecini As Date, ByVal x_fecfin As Date)
      Try
         Dim _dr As DataRow = _dsdatos.DTBase.NewRow()
         _dr("Codigo") = "0"
         _dr("SaldoInicial") = m_reporte.SaldoCaja.SaldoInicial
         _dr("FecIni") = x_fecini.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         _dr("FecFin") = x_fecfin.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         _dr("Ingresos") = m_reporte.SaldoCaja.Ingreso.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
         _dr("Egresos") = m_reporte.SaldoCaja.Egreso.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
         _dr("Saldo") = (m_reporte.SaldoCaja.Saldo).ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
         _dr("Empresa") = GApp.EEmpresa.EMPR_Desc
         _dr("RUC") = GApp.EmpresaRUC
         _dsdatos.DTBase.Rows.Add(_dr)

         For Each item As ECuadreCaja In m_reporte.ListCuadreCaja
            Dim x_dr As DataRow = _dsdatos.DTReporteCuadreCaja.NewRow()
            x_dr("Codigo") = "0"
            x_dr("Orden") = item.Orden
            x_dr("ViajeFlete") = String.Format("CV:{0} / CF:{1}", item.VIAJE_Id, item.FLETE_Id)
            x_dr("Titulo") = item.Titulo
            x_dr("Title") = item.Title
            x_dr("Glosa") = item.Glosa
            x_dr("Documento") = item.Documento
            x_dr("Fecha") = item.Fecha.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            x_dr("FechaFlete") = item.FechaFlete.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            x_dr("ENTID_RazonSocial") = item.ENTID_RazonSocial
            x_dr("ENTID_NroDocumento") = item.ENTID_NroDocumento
            x_dr("Moneda") = item.Moneda
            x_dr("TipoDocumento") = item.TipoDocumento
            x_dr("ImpDolares") = item.ImpDolares.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("ImpSoles") = item.ImpSoles.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("TCambioVenta") = item.TCambioVenta.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo3d))

            _dsdatos.DTReporteCuadreCaja.Rows.Add(x_dr)
         Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region


#Region " Cuadre de Pendientes "
   Public Function CuadrePendientes(ByVal x_fecfin As Date, ByVal x_imprimir As Boolean, ByVal x_listado As Boolean, ByVal x_pvent_id As Long)
      Try
         Dim _btran As New BReporte(GApp.PuntoVenta)
         Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")
         Dim strReportName As String = "CRPendientes.rpt"
         If x_listado Then
            strReportName = "CRPendientesListado.rpt"
         End If

         Dim strReportPath As String = System.IO.Path.Combine(m_Path_Plantillas, strReportName)
         If _btran.CuadrePendientes(x_fecfin, x_pvent_id) Then
            If x_imprimir Then

            Else ' Ver
               VisualizarCP(_btran, strReportPath, x_fecfin)
            End If
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function VisualizarCP(ByRef m_reporte As BReporte, ByVal strReportPath As String, _
                            ByVal x_fecfin As Date) As Boolean
      Try
         Dim _dsdatos As New DSCPendiente()
         getDatosCP(m_reporte, _dsdatos, x_fecfin)

         Dim Informe As New ReportDocument
         Informe.Load(strReportPath)
         Informe.SetDataSource(_dsdatos)

         Dim reporte As New RReportView(Informe) With {.StartPosition = FormStartPosition.CenterScreen}
         reporte.Text = String.Format("Reporte de Cuadre de Pendientes: Al {0:dd/MM/yyyy}", x_fecfin)
         reporte.Show()

         'Informe.Close()
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getDatosCP(ByVal m_reporte As BReporte, ByRef _dsdatos As DSCPendiente, _
                             ByVal x_fecfin As Date)
      Try
         Dim _fletes As Decimal = 0
         For Each item As ETRAN_Fletes In m_reporte.ListTRAN_Fletes
            If Not item.ENTID_NroDocumento.Equals("00000000001") Then
               _fletes += item.ImpSoles
            End If
         Next

         Dim _dr As DataRow = _dsdatos.DTCabPendiente.NewRow()
         _dr("Codigo") = "0"
         _dr("Fecha") = x_fecfin.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         _dr("TotalGeneral") = _fletes
         _dr("Empresa") = GApp.EEmpresa.EMPR_Desc
         _dr("RUC") = GApp.EmpresaRUC
         _dsdatos.DTCabPendiente.Rows.Add(_dr)

         For Each item As ETRAN_Fletes In m_reporte.ListTRAN_Fletes
            Dim x_dr As DataRow = _dsdatos.DTCPendientes.NewRow()
            x_dr("Codigo") = "0"
            x_dr("Fecha") = item.DOCVE_FechaDocumento.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            x_dr("FechaFlete") = item.FLETE_Fecha.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            x_dr("TipoDocumento") = item.TipoDocumento
            x_dr("NumeroDoc") = item.ENTID_NroDocumento
            x_dr("Cliente") = item.ENTID_RazonSocial
            x_dr("Moneda") = item.TIPOS_TipoMoneda
            x_dr("NroComprobante") = item.Documento
            x_dr("ViajeFlete") = String.Format("CV:{0} / CF:{1}", item.VIAJE_Id, item.FLETE_Id)
            x_dr("Glosa") = item.FLETE_Glosa
            x_dr("PagoFlete") = item.TotalPagado
            x_dr("TotalCobrado") = item.Pago
            x_dr("GlosaAgrupada") = item.GlosaAgrupada

            x_dr("SaldoDol") = item.ImpDolares.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("SaldoSol") = item.ImpSoles.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("Cobrado") = item.Pago.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("TipoCambio") = item.TCambioVenta.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo4d))

            _dsdatos.DTCPendientes.Rows.Add(x_dr)
         Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Guias de Cemento "
   Public Function GuiasCemento(ByVal m_reporte As List(Of ETRAN_GuiasTransportista), ByVal x_fecini As Date, ByVal x_fecfin As Date)
      Try
         Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")
         Dim strReportName As String = "CRGuiasCemento.rpt"
         Dim strReportPath As String = System.IO.Path.Combine(m_Path_Plantillas, strReportName)

         Dim _dsdatos As New DSGuiasCemento()
         getDatosGC(m_reporte, _dsdatos)

         Dim Informe As New ReportDocument
         Informe.Load(strReportPath)
         Informe.SetDataSource(_dsdatos)


         Dim reporte As New RReportView(Informe) With {.StartPosition = FormStartPosition.CenterScreen}
         reporte.Text = String.Format("Reporte de Guias de Cemento: del {0:dd/MM/yyyy} Al {1:dd/MM/yyyy}", x_fecini, x_fecfin)
         reporte.Show()

         'Informe.Close()
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getDatosGC(ByVal m_reporte As List(Of ETRAN_GuiasTransportista), ByVal _dsdatos As DSGuiasCemento)
      Try
         Dim _dr As DataRow = _dsdatos.DTCabecera.NewRow()
         _dr("Codigo") = "0"
         _dr("Empresa") = GApp.EEmpresa.EMPR_Desc
         _dr("RUC") = GApp.EmpresaRUC
         '_dsdatos.DTBase.Rows.Add(_dr)

         'For Each item As ETRAN_GuiasTransportista In m_reporte
         '   Dim x_dr As DataRow = _dsdatos.DTDetalle.NewRow()
         '   x_dr("Codigo") = "0"

         '   x_dr("Documento") = item.Documento
         '   x_dr("Documento") = item.Documento
         '   x_dr("Fecha") = item.Fecha.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         '   x_dr("FechaFlete") = item.FechaFlete.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         '   x_dr("ImpDolares") = item.ImpDolares.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
         '   x_dr("ImpSoles") = item.ImpSoles.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
         '   x_dr("TCambioVenta") = item.TCambioVenta.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo3d))

         '   _dsdatos.DTReporteCuadreCaja.Rows.Add(x_dr)
         'Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Reporte de Cuentas Corrientes "

   Public Function RCuentaCorriente(ByVal x_fecIni As Date, ByVal x_fecfin As Date, ByVal x_fecha As Boolean, ByVal x_entid_codigocliente As String)
      Dim strReportPath As String
      Dim strReportName As String = "CRCuentasCorrientes.rpt"
      Try
         Dim _btran As New BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
         Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")

         If _btran.REPOSS_CuentasCorrientes(x_fecIni, x_fecfin, x_entid_codigocliente, GApp.PuntoVenta, x_fecha) Then
            strReportPath = System.IO.Path.Combine(m_Path_Plantillas, strReportName)
            If _btran.VENT_CAJASS_CobranzaPendiente(x_fecIni, x_fecfin, GApp.PuntoVenta, False, Nothing, x_entid_codigocliente) Then
               strReportPath = System.IO.Path.Combine(m_Path_Plantillas, strReportName)
            End If
            VisualizarCuentasCorrientes(_btran, strReportPath, x_fecIni, x_fecfin)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function VisualizarCuentasCorrientes(ByRef m_reporte As BReporte, ByVal strReportPath As String, ByVal x_fecIni As Date, ByVal x_fecfin As Date) As Boolean
      Try
         Dim _dsdatos As New DSCuentaCorriente()
         Dim _dsdatosCP As New DSCuadrePendientes()
         getDatosCuentasCorrientes(m_reporte, _dsdatos, x_fecIni, x_fecfin)
         getDatosCobranzaPendiente(m_reporte, _dsdatosCP, x_fecIni, x_fecfin)

         Dim Informe As New ReportDocument
         Informe.Load(strReportPath)
         Informe.SetDataSource(_dsdatos)
         Informe.Subreports(0).SetDataSource(_dsdatosCP)

         Dim reporte As New RReportView(Informe) With {.StartPosition = FormStartPosition.CenterScreen}
         reporte.Text = String.Format("Reporte de Cuentas Corrientes: Del {0:dd/MM/yyyy} Al {1:dd/MM/yyyy}", x_fecIni, x_fecfin)
         reporte.Show()

         'Informe.Close()
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getDatosCuentasCorrientes(ByVal m_reporte As BReporte, ByRef _dsdatos As DSCuentaCorriente, ByVal x_fecini As Date, ByVal x_fecfin As Date)
      Try
         Dim _fletes As Decimal = 0
         'For Each item As EVCuadrePendientes In m_reporte.ListVCuadrePendientes
         '   If Not item.ENTID_NroDocumento.Equals("00000000001") Then
         '      _fletes += item.ImpSoles
         '   End If
         'Next

         Dim _dr As DataRow = _dsdatos.DTCabecera.NewRow()
         _dr("Codigo") = "0"
         _dr("FecIni") = x_fecini.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         _dr("FecFin") = x_fecfin.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         '_dr("TotalGeneral") = _fletes
         _dr("Empresa") = GApp.EEmpresa.EMPR_Desc
         _dr("PuntoVenta") = GApp.EPuntoVenta.PVENT_Descripcion
         '_dr("RUC") = GApp.RUC_Empresa
         _dr("ENTID_CodigoCliente") = m_reporte.ListVENT_DocsVenta(0).ENTID_Codigo
         _dr("ENTID_RazonSocial") = m_reporte.ListVENT_DocsVenta(0).ENTID_RazonSocial
         _dsdatos.DTCabecera.Rows.Add(_dr)

         For Each item As ACEVentas.EVENT_DocsVenta In m_reporte.ListVENT_DocsVenta
            Dim x_dr As DataRow = _dsdatos.DTDetalle.NewRow()
            x_dr("Codigo") = "0"
            x_dr("DPAGO_Fecha") = item.DPAGO_Fecha.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            x_dr("Documento") = item.Documento
            x_dr("DOCVE_FechaDocumento") = item.DOCVE_FechaDocumento.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            x_dr("DPAGO_Numero") = item.DPAGO_Numero
            x_dr("CAJA_Fecha") = item.CAJA_Fecha.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            x_dr("TIPOS_TipoPago") = item.TIPOS_TipoPago
            x_dr("DOCVE_Codigo") = item.DOCVE_Codigo
            x_dr("TIPOS_TipoMonedaPago") = item.TIPOS_TipoMonedaPago
            x_dr("DPAGO_Importe") = item.DPAGO_Importe.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("CAJA_Importe") = item.CAJA_Importe.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("TotalPagado") = item.TotalPagado.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("TotalPagadoDolares") = item.TotalPagadoDolares.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("Glosa") = item.Glosa '& item.DOCVE_TipoCambio.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d))
            x_dr("CAJA_Glosa") = item.CAJA_Glosa
            x_dr("DOCVE_TipoCambio") = item.DOCVE_TipoCambio.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo4d))
            _dsdatos.DTDetalle.Rows.Add(x_dr)
         Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getDatosCobranzaPendiente(ByVal m_reporte As BReporte, ByRef _dsdatos As DSCuadrePendientes, ByVal x_fecini As Date, ByVal x_fecfin As Date)
      Try
         Dim _fletes As Decimal = 0
         'For Each item As EVCuadrePendientes In m_reporte.ListVCuadrePendientes
         '   If Not item.ENTID_NroDocumento.Equals("00000000001") Then
         '      _fletes += item.ImpSoles
         '   End If
         'Next

         Dim _dr As DataRow = _dsdatos.DTCabecera.NewRow()
         _dr("Codigo") = "0"
         _dr("FecIni") = x_fecini.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         _dr("FecFin") = x_fecfin.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         '_dr("TotalGeneral") = _fletes
         _dr("Empresa") = GApp.EEmpresa.EMPR_Desc
         _dr("PuntoVenta") = GApp.EPuntoVenta.PVENT_Descripcion
         '_dr("RUC") = GApp.RUC_Empresa
         _dsdatos.DTCabecera.Rows.Add(_dr)

         For Each item As ACEVentas.ECCuadrePendientes In m_reporte.ListCCuadrePendientes
            Dim x_dr As DataRow = _dsdatos.DTCuadreCaja.NewRow()
            x_dr("Codigo") = "0"
            x_dr("DOCVE_FechaDocumento") = item.DOCVE_FechaDocumento.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            x_dr("Documento") = item.Documento
            x_dr("ENTID_Codigo") = item.ENTID_Codigo
            x_dr("TipoDocumento") = item.TipoDocumento
            x_dr("ENTID_RazonSocial") = " " & item.ENTID_RazonSocial
            x_dr("TIPOS_TipoMoneda") = item.TIPOS_TipoMoneda
            x_dr("Pago") = item.Pago '.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("PagoDolares") = item.PagoDolares
            x_dr("ImpSoles") = item.ImpSoles
            x_dr("ImpDolares") = item.ImpDolares
            x_dr("PendienteSoles") = item.PendienteSoles
            x_dr("PendienteDolares") = item.PendienteDolares
            x_dr("TCambioVenta") = item.TCambioVenta.ToString("##0.000")
            x_dr("ENTID_RazonSocialVendedor") = item.ENTID_RazonSocialVendedor
            x_dr("ENTID_CodigoVendedor") = item.ENTID_CodigoVendedor
            x_dr("Cheque") = item.Cheque

            _dsdatos.DTCuadreCaja.Rows.Add(x_dr)
         Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region "Facturacion Electronica "
     Public Function RVentas(ByVal x_docve_codigo As String, ByVal x_printername As String, ByVal x_imprimir As Boolean, ByVal x_spot As Boolean)
      Try
         Dim _btran As New BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
         Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")
         Dim strReportName As String = "CRFacturasElec.rpt"
            ''Dim strReportName As String = "CRFacturasElecSencillas"
            'Dim strReportName As String = "CRNotaCredito_Elec.rpt"

         Dim strReportPath As String = System.IO.Path.Combine(m_Path_Plantillas, strReportName)

         If _btran.REPOS_DocsVenta(x_docve_codigo) Then
            If x_imprimir Then

            Else ' Ver
              
                     VisualizarCotizacion(_btran, strReportPath,x_spot)
                     Return True
                 
            End If
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function
     Public Function RVentasSimple(ByVal x_docve_codigo As String, ByVal x_printername As String, ByVal x_imprimir As Boolean, ByVal x_spot As Boolean)
      Try
         Dim _btran As New BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
         Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")
         Dim strReportName As String = "CRFacturasElecSencillas.rpt"
            'Dim strReportName As String = "CRNotaCredito_Elec.rpt"

         Dim strReportPath As String = System.IO.Path.Combine(m_Path_Plantillas, strReportName)

         If _btran.REPOS_DocsVenta(x_docve_codigo) Then
            If x_imprimir Then

            Else ' Ver
              
                     VisualizarCotizacion(_btran, strReportPath,x_spot)
                     Return True
                 
            End If
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     Public Function VisualizarCotizacion(ByRef m_reporte As BReporte, ByVal strReportPath As String, ByVal x_spot As Boolean) As Boolean
      Try
         Dim _dsdatos As New DSDocsVentaElec()
         getDatosCotizacion(m_reporte, _dsdatos,x_spot)

         Dim Informe As New ReportDocument
         Informe.Load(strReportPath)
         Informe.SetDataSource(_dsdatos)

         Dim reporte As New RReportView(Informe) With {.StartPosition = FormStartPosition.CenterScreen}
         reporte.Text = String.Format("Comprobante de Venta : {0}", m_reporte.VENT_DocsVenta.DOCVE_Codigo)
         reporte.Show()

         'Informe.Close()
         Return True
      Catch ex As Exception
         Throw ex
      End Try
    End Function


    Private Function getDatosCotizacion(ByVal m_reporte As BReporte, ByRef _dsdatos As DSDocsVentaElec, ByVal x_spot As Boolean)
      Try
         Dim _dr As DataRow = _dsdatos.VENT_DocsVenta.NewRow()
            dim _doc As String
         _dr("DOCVE_Codigo") = m_reporte.VENT_DocsVenta.DOCVE_CODIGO
         _dr("ALMAC_Descripcion") = GApp.EPuntoVenta.PVENT_Descripcion
         _dr("DOCVE_FechaDocumento") = m_reporte.VENT_DocsVenta.DOCVE_FechaDocumento.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
         _dr("Tipos_CodTipoDocumento") = m_reporte.VENT_DocsVenta.Tipos_CodTipoDocumento
         _dr("Tipos_CodTipoMoneda") = m_reporte.VENT_DocsVenta.TIPOS_CodTipoMoneda
         _dr("TIPOS_CondicionPago") = m_reporte.VENT_DocsVenta.TIPOS_CondicionPago
         _dr("TIPOS_TipoMoneda") = m_reporte.VENT_DocsVenta.TIPOS_TipoMoneda
         _dr("DOCVE_UsrCrea") = m_reporte.VENT_DocsVenta.DOCVE_UsrCrea
         _dr("ENTID_RazonSocial") = m_reporte.VENT_DocsVenta.ENTID_RazonSocial
         _dr("DOCVE_DireccionCliente") = m_reporte.VENT_DocsVenta.DOCVE_DireccionCliente
         _dr("DOCVE_ImporteVenta") =Math.Round(m_reporte.VENT_DocsVenta.Docve_ImporteVenta,2) 
         _dr("DOCVE_TotalVenta") = Math.Round(m_reporte.VENT_DocsVenta.DOCVE_TotalVenta,2)
         _dr("DOCVE_TotalPagar") = m_reporte.VENT_DocsVenta.DOCVE_TotalPagar

          if m_reporte.VENT_DocsVenta.DOCVE_TotalVenta >0 Then
         _dr("Nro_EnLetras")=ACUtilitarios.NumPalabra(m_reporte.VENT_DocsVenta.DOCVE_TotalVenta, m_reporte.VENT_DocsVenta.TIPOS_TipoMoneda)
                Else 
                Dim total as Double 
                total = m_reporte.VENT_DocsVenta.DOCVE_TotalVenta * -1
                _dr("Nro_EnLetras")=ACUtilitarios.NumPalabra(total, m_reporte.VENT_DocsVenta.TIPOS_TipoMoneda)

          End If
        
         _dr("DOCVE_Motivo")=m_reporte.VENT_DocsVenta.docve_Motivo
        
           IF (GApp.EPuntoVenta.PVENT_Id = 9 And x_spot=true)
                _dr("DOCVE_Observaciones") = "Operacion Sujeta al Sistema de Pago de ObligacionesTributarias Con el Gobierno Central.     Cta. Cte. Bco. de la Nacion 101-091929"
               Else                            
                _dr("DOCVE_Observaciones") = ""
            End If

            _doc=m_reporte.VENT_DocsVenta.DOCVE_Codigo.ToString().Substring(2,4) & " - " & m_reporte.VENT_DocsVenta.DOCVE_Codigo.ToString().Substring(6,7)
         _dr("Nro_Documento") = _doc
           _dr("ENTID_CodigoCliente") = m_reporte.VENT_DocsVenta.ENTID_CodigoCliente
            _dr("DOCVE_ImporteIGV") = m_reporte.VENT_DocsVenta.DOCVE_ImporteIGV
         _dsdatos.VENT_DocsVenta.Rows.Add(_dr)

         For Each item As EVENT_DocsVentaDetalle In m_reporte.VENT_DocsVenta.ListVENT_DocsVentaDetalle
            Dim x_dr As DataRow = _dsdatos.VENT_DocsVentaDetalle.NewRow()
            x_dr("DOCVD_Detalle") =item.DOCVD_Detalle
            x_dr("DOCVD_PesoUnitario") =item.DOCVD_PesoUnitario
               x_dr("DOCVD_Unidad") = item.DOCVD_Unidad
            x_dr("DOCVD_Item") = item.DOCVD_Item
            x_dr("DOCVD_Cantidad") = Math.Round(item.DOCVD_Cantidad ,3)
                'item.DOCVD_Cantidad.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("DOCVD_PrecioUnitario") = Math.Round(item.DOCVD_PrecioUnitario ,2)
            'x_dr("DOCVD_SubImporteVenta") = Math.Round(item.DOCVD_SubImporteVenta ,2)
                x_dr("DOCVD_SubImporteVenta") = item.DOCVD_SubImporteVenta
               ' item.DOCVD_SubImporteVenta.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
            x_dr("DOCVE_Codigo") = item.DOCVE_Codigo
            'x_dr("DOCVD_PrecioTotal") = Math.Round( item.DOCVD_PrecioUnitario * item.DOCVD_Cantidad,2)
                x_dr("DOCVD_PrecioTotal") = Math.Round(item.DOCVD_SubImporteVenta ,2)
            _dsdatos.VENT_DocsVentaDetalle.Rows.Add(x_dr)
         Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function



#End Region
#Region "Guias Electronicas"
    Public Function REPOS_GuiaElectronica(ByVal x_guiar_codigo As String, ByVal x_printername As String, ByVal x_imprimir As Boolean)
        Try
            Dim _btran As New BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
            '_btran.REPOS_Fac(x_docve_codigo) 
            Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")
            Dim strReportName As String

            If (GApp.Empresa.Equals("ACERO") Or GApp.Empresa.Equals("VIRTU")) Then
                'R 20-12-2017
                strReportName = "CRGuiaRemision.rpt"
                ' strReportName = "CRNotaCredito_Elec_Prueba.rpt"
            Else
                ' strReportName = "CRNotaCredito_ElecPro.rpt"
                strReportName = "CRGuiaRemision.rpt"
            End If
            Dim strReportPath As String = System.IO.Path.Combine(m_Path_Plantillas, strReportName)

            If _btran.REPOS_Guias(x_guiar_codigo) Then
                If x_imprimir Then

                Else ' Ver

                    'R 20-12-2017
                    VisualizarGuia(_btran, x_printername, strReportPath)
                    ' VisualizarFactura(_btran, x_printername, strReportPath)
                    Return True

                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function VisualizarGuia(ByRef m_reporte As BReporte, ByVal x_impresora As String, ByVal strReportPath As String) As Boolean
        Try
            Dim _dsdatos As New DSGuiaTransportista()
            getDatosGuia(m_reporte, _dsdatos)

            Dim Informe As New ReportDocument
            Informe.Load(strReportPath)
            Informe.SetDataSource(_dsdatos)

            'If x_imprimir Then
            Informe.PrintOptions.PrinterName = x_impresora

            Informe.PrintOptions.PaperSize = [Shared].PaperSize.DefaultPaperSize '+
            Informe.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto '+

            If m_reporte.GTRAN_GuiasTransportista.TIPOS_CodMotivoTraslado = "MTG01" Or m_reporte.GTRAN_GuiasTransportista.TIPOS_CodMotivoTraslado = "MTG06" Or m_reporte.GTRAN_GuiasTransportista.TIPOS_CodMotivoTraslado = "MTG02" Then
                Informe.SetParameterValue("destino_copia ", "CLIENTE")
                Informe.PrintToPrinter(1, True, 1, 1)
                Informe.SetParameterValue("destino_copia ", "CONTROL")
                Informe.PrintToPrinter(1, True, 1, 1)

            Else
                Informe.SetParameterValue("destino_copia ", "CONTROL")
                Informe.PrintToPrinter(1, True, 1, 1)
            End If

            Dim reporte As New RReportView(Informe) With {.StartPosition = FormStartPosition.CenterScreen}
            reporte.Text = String.Format("Guia de Remision : {0}", m_reporte.GTRAN_GuiasTransportista.GTRAN_Codigo)
            reporte.crvReporte.ShowPrintButton = False
            reporte.crvReporte.ShowExportButton = False
            reporte.Show()

            'Informe.Close()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getDatosGuia(ByVal m_reporte As BReporte, ByRef _dsdatos As DSGuiaTransportista)
        Try
            Dim _dr As DataRow = _dsdatos.TRAN_GuiasTransportista.NewRow()
            Dim _doc As String
            Dim _guia As String
            Dim hora As String
            _dr("GTRAN_Codigo") = m_reporte.GTRAN_GuiasTransportista.GTRAN_Codigo
            _dr("ZONAS_Codigo") = m_reporte.GTRAN_GuiasTransportista.ZONAS_Codigo
            _dr("GTRAN_Fecha") = Format(m_reporte.GTRAN_GuiasTransportista.GTRAN_Fecha, "Long Date")
            _dr("GTRAN_FechaTraslado") = m_reporte.GTRAN_GuiasTransportista.GTRAN_FechaTraslado.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            _dr("GTRAN_FecCrea") = m_reporte.GTRAN_GuiasTransportista.GTRAN_FecCrea.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            '_dr("DOCVE_UsrCrea") = m_reporte.VENT_DocsVenta.DOCVE_UsrCrea
            _dr("GTRAN_DesEntidadDestinatario") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DesEntidadDestinatario
            _dr("ENTID_CodigoDestinatario") = m_reporte.GTRAN_GuiasTransportista.ENTID_CodigoDestinatario
            _dr("GTRAN_DescEntidadProveedor") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DescEntidadProveedor
            _dr("ENTID_CodigoTransportista") = m_reporte.GTRAN_GuiasTransportista.ENTID_CodigoTransportista
             _dr("GTRAN_DescEntidadRemitente") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DescEntidadRemitente

            _dr("GTRAN_NroPedido") = m_reporte.GTRAN_GuiasTransportista.GTRAN_NroPedido
            _dr("GTRAN_RucProveedor") = m_reporte.GTRAN_GuiasTransportista.GTRAN_RucProveedor
            _dr("GTRAN_DireccionProveedor") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DireccionProveedor
            _dr("GTRAN_DireccionDestinatario") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DireccionDestinatario
            _dr("GTRAN_DescripcionVehiculo") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DescripcionVehiculo
            _dr("GTRAN_CertificadosVehiculo") = m_reporte.GTRAN_GuiasTransportista.GTRAN_CertificadosVehiculo
            _dr("ENTID_Conductor") = m_reporte.GTRAN_GuiasTransportista.ENTID_Conductor
            '_dr("GUIAR_DescripcionConductor") = m_reporte.GTRAN_GuiasTransportista.GUIAR_DescripcionConductor
            _dr("GTRAN_LicenciaConductor") = m_reporte.GTRAN_GuiasTransportista.GTRAN_LicenciaConductor
            _dr("GTRAN_PesoTotal") = m_reporte.GTRAN_GuiasTransportista.GTRAN_PesoTotal
            _dr("GTRAN_UsrCrea") = m_reporte.GTRAN_GuiasTransportista.GTRAN_UsrCrea
            _dr("GTRAN_ZonaRemitente") = m_reporte.GTRAN_GuiasTransportista.GTRAN_ZonaRemitente
            _dr("Certificados") = m_reporte.GTRAN_GuiasTransportista.GTRAN_CertificadosVehiculo
            ' _dr("GUIAR_Impresa") = m_reporte.GTRAN_GuiasTransportista.GUIAR_Impresa
            ' _dr("GUIAR_Impresiones") = m_reporte.GTRAN_GuiasTransportista.GUIAR_Impresiones + 1
            hora = Format(m_reporte.GTRAN_GuiasTransportista.GTRAN_Fecha, "HH:mm tt")
            'If m_reporte.GTRAN_GuiasTransportista.TIPOS_CodMotivoTraslado = "MTG06" Then
            '    _dr("GUIAR_FechaIngreso") = "-"
            'Else
            '    _dr("GUIAR_FechaIngreso") = m_reporte.GTRAN_GuiasTransportista.GUIAR_FechaIngreso.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            'End If
            '_dr("GUIAR_FechaIngreso") = m_reporte.DIST_GuiasRemision.GUIAR_FechaIngreso.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            _dr("Hora") = hora
            ' _dr("GUIAR_DescripcionProveedor") = m_reporte.GTRAN_GuiasTransportista.GUIAR_DescripcionProveedor


            If Not IsNothing(m_reporte.GTRAN_GuiasTransportista.NumeroComprobante) Then
                If Len(m_reporte.GTRAN_GuiasTransportista.NumeroComprobante) = 12 Then
                    _doc = m_reporte.GTRAN_GuiasTransportista.NumeroComprobante.ToString().Substring(2, 3) & " - 0" & m_reporte.GTRAN_GuiasTransportista.NumeroComprobante.ToString().Substring(5, 7)
                Else
                    _doc = m_reporte.GTRAN_GuiasTransportista.NumeroComprobante.ToString().Substring(2, 4) & " - 0" & m_reporte.GTRAN_GuiasTransportista.NumeroComprobante.ToString().Substring(6, 7)
                End If

            Else

                _doc = "-"
            End If
            '_doc = m_reporte.VENT_DocsVenta.DOCVE_Codigo.ToString().Substring(2, 3) & " - 0" & m_reporte.VENT_DocsVenta.DOCVE_Codigo.ToString().Substring(5, 7)
            _guia = m_reporte.GTRAN_GuiasTransportista.GTRAN_Codigo.ToString().Substring(2, 4) & " - 0" & m_reporte.GTRAN_GuiasTransportista.GTRAN_Codigo.ToString().Substring(6, 7)
            '_guia = m_reporte.DIST_GuiasRemision.GUIAR_Codigo.ToString().Substring(2, 3) & " - 0" & m_reporte.DIST_GuiasRemision.GUIAR_Codigo.ToString().Substring(5, 7)
            _dr("NumeroComprobante") = _doc
            _dr("NroGuia") = _guia
            ' _dr("ENTID_CodigoCliente") = m_reporte.GTRAN_GuiasTransportista.ENTID_CodigoCliente
            ' _dr("ENTID_CodigoTransportista") = m_reporte.GTRAN_GuiasTransportista.ENTID_CodigoTransportista
            '_dr("DOCVE_ImporteIGV") = m_reporte.VENT_DocsVenta.DOCVE_ImporteIgv
            _dsdatos.TRAN_GuiasTransportista.Rows.Add(_dr)

            For Each item As ETRAN_GuiasTransportistaDetalles In m_reporte.GTRAN_GuiasTransportista.ListETRAN_GuiasTransportistaDetalles
                Dim x_dr As DataRow = _dsdatos.TRAN_GuiasTransportistaDetalles.NewRow()

                x_dr("GTDET_Peso") = item.GTDET_Peso
                x_dr("GTDET_Unidad") = item.GTDET_Unidad
                x_dr("GTDET_Item") = item.GTDET_Item
                x_dr("ARTIC_Codigo") = item.ARTIC_Codigo
                x_dr("GTDET_Descripcion") = item.GTDET_Descripcion
                x_dr("GTDET_Cantidad") = Math.Round(item.GTDET_Cantidad, 2)
                x_dr("GTRAN_Codigo") = item.GTRAN_Codigo

                _dsdatos.TRAN_GuiasTransportistaDetalles.Rows.Add(x_dr)

            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Guias Electronicas - Transportista"
    Public Function REPOS_GuiaElectronicaTransportista(ByVal x_guiar_codigo As String, ByVal x_printername As String, ByVal x_imprimir As Boolean)
        Try
            Dim _btran As New BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
            '_btran.REPOS_Fac(x_docve_codigo) 
            Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")
            Dim strReportName As String

            If (GApp.Empresa.Equals("ACERO") Or GApp.Empresa.Equals("VIRTU")) Then
                'R 20-12-2017
                strReportName = "CRGuiaRemisionTransportista.rpt"
                ' strReportName = "CRNotaCredito_Elec_Prueba.rpt"
            Else
                ' strReportName = "CRNotaCredito_ElecPro.rpt"
                strReportName = "CRGuiaRemisionTransportista.rpt"
            End If
            Dim strReportPath As String = System.IO.Path.Combine(m_Path_Plantillas, strReportName)

            If _btran.REPOS_GuiasTransportista(x_guiar_codigo) Then
                If x_imprimir Then

                Else ' Ver

                    'R 20-12-2017
                    VisualizarGuiaTransportista(_btran, x_printername, strReportPath)
                    ' VisualizarFactura(_btran, x_printername, strReportPath)
                    Return True

                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function VisualizarGuiaTransportista(ByRef m_reporte As BReporte, ByVal x_impresora As String, ByVal strReportPath As String) As Boolean
        Try
            Dim _dsdatos As New DSGuiaTransportista()
            getDatosGuiaTransportista(m_reporte, _dsdatos)

            Dim Informe As New ReportDocument
            Informe.Load(strReportPath)
            Informe.SetDataSource(_dsdatos)

            'If x_imprimir Then
            Informe.PrintOptions.PrinterName = x_impresora

            Informe.PrintOptions.PaperSize = [Shared].PaperSize.DefaultPaperSize '+
            Informe.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto '+

            If m_reporte.GTRAN_GuiasTransportista.TIPOS_CodMotivoTraslado = "MTG01" Or m_reporte.GTRAN_GuiasTransportista.TIPOS_CodMotivoTraslado = "MTG06" Or m_reporte.GTRAN_GuiasTransportista.TIPOS_CodMotivoTraslado = "MTG02" Then
                Informe.SetParameterValue("destino_copia ", "CLIENTE")
                Informe.PrintToPrinter(1, True, 1, 1)
                Informe.SetParameterValue("destino_copia ", "CONTROL")
                Informe.PrintToPrinter(1, True, 1, 1)

            Else
                Informe.SetParameterValue("destino_copia ", "CONTROL")
                Informe.PrintToPrinter(1, True, 1, 1)
            End If

            Dim reporte As New RReportView(Informe) With {.StartPosition = FormStartPosition.CenterScreen}
            reporte.Text = String.Format("Guia de Remision : {0}", m_reporte.GTRAN_GuiasTransportista.GTRAN_Codigo)
            reporte.crvReporte.ShowPrintButton = False
            reporte.crvReporte.ShowExportButton = False
            reporte.Show()

            'Informe.Close()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
  
    Private Function getDatosGuiaTransportista(ByVal m_reporte As BReporte, ByRef _dsdatos As DSGuiaTransportista)
        Try
            Dim _dr As DataRow = _dsdatos.TRAN_GuiasTransportista.NewRow()
            Dim _doc As String
            Dim _guia As String
            Dim hora As String
            _dr("GTRAN_Codigo") = m_reporte.GTRAN_GuiasTransportista.GTRAN_Codigo
            '_dr("ZONAS_Codigo") = m_reporte.GTRAN_GuiasTransportista.ZONAS_Codigo
            _dr("GTRAN_Fecha") = Format(m_reporte.GTRAN_GuiasTransportista.GTRAN_Fecha, "Long Date")
            _dr("GTRAN_FechaTraslado") = m_reporte.GTRAN_GuiasTransportista.GTRAN_FechaTraslado.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            '_dr("DOCVE_UsrCrea") = m_reporte.VENT_DocsVenta.DOCVE_UsrCrea
            _dr("GTRAN_RUCRemitente") = m_reporte.GTRAN_GuiasTransportista.GTRAN_RUCRemitente
            _dr("GTRAN_DescEntidadRemitente") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DescEntidadRemitente
            _dr("ENTID_CodigoDestinatario") = m_reporte.GTRAN_GuiasTransportista.ENTID_CodigoDestinatario
            _dr("GTRAN_DesEntidadDestinatario") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DesEntidadDestinatario

            '_dr("GTRAN_NroPedido") = m_reporte.GTRAN_GuiasTransportista.GTRAN_NroPedido
            _dr("GTRAN_DireccionRemitente") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DireccionRemitente
            _dr("GTRAN_DireccionDestinatario") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DireccionDestinatario
            _dr("GTRAN_DescripcionVehiculo") = m_reporte.GTRAN_GuiasTransportista.GTRAN_DescripcionVehiculo
            _dr("Certificados") = m_reporte.GTRAN_GuiasTransportista.Certificados
            _dr("ENTID_Conductor") = m_reporte.GTRAN_GuiasTransportista.ENTID_Conductor
            '_dr("GUIAR_DescripcionConductor") = m_reporte.GTRAN_GuiasTransportista.GUIAR_DescripcionConductor
            _dr("GTRAN_LicenciaConductor") = m_reporte.GTRAN_GuiasTransportista.GTRAN_LicenciaConductor
            _dr("GTRAN_PesoTotal") = m_reporte.GTRAN_GuiasTransportista.GTRAN_PesoTotal
            _dr("GTRAN_UsrCrea") = m_reporte.GTRAN_GuiasTransportista.GTRAN_UsrCrea
            ' _dr("GTRAN_ZonaRemitente") = m_reporte.GTRAN_GuiasTransportista.GTRAN_ZonaRemitente
            '_dr("TIPOS_MotivoTraslado") = m_reporte.GTRAN_GuiasTransportista.TIPOS_MotivoTraslado
            ' _dr("GUIAR_Impresa") = m_reporte.GTRAN_GuiasTransportista.GUIAR_Impresa
            ' _dr("GUIAR_Impresiones") = m_reporte.GTRAN_GuiasTransportista.GUIAR_Impresiones + 1
            hora = Format(m_reporte.GTRAN_GuiasTransportista.GTRAN_Fecha, "HH:mm tt")
            'If m_reporte.GTRAN_GuiasTransportista.TIPOS_CodMotivoTraslado = "MTG06" Then
            '    _dr("GUIAR_FechaIngreso") = "-"
            'Else
            '    _dr("GUIAR_FechaIngreso") = m_reporte.GTRAN_GuiasTransportista.GUIAR_FechaIngreso.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            'End If
            '_dr("GUIAR_FechaIngreso") = m_reporte.DIST_GuiasRemision.GUIAR_FechaIngreso.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            _dr("Hora") = hora
            ' _dr("GUIAR_DescripcionProveedor") = m_reporte.GTRAN_GuiasTransportista.GUIAR_DescripcionProveedor


            If Not IsNothing(m_reporte.GTRAN_GuiasTransportista.NumeroComprobante) Then
                If Len(m_reporte.GTRAN_GuiasTransportista.NumeroComprobante) = 12 Then
                    _doc = m_reporte.GTRAN_GuiasTransportista.NumeroComprobante.ToString().Substring(2, 3) & " - 0" & m_reporte.GTRAN_GuiasTransportista.NumeroComprobante.ToString().Substring(5, 7)
                Else
                    _doc = m_reporte.GTRAN_GuiasTransportista.NumeroComprobante.ToString().Substring(2, 4) & " - 0" & m_reporte.GTRAN_GuiasTransportista.NumeroComprobante.ToString().Substring(6, 7)
                End If

            Else

                _doc = "-"
            End If
            '_doc = m_reporte.VENT_DocsVenta.DOCVE_Codigo.ToString().Substring(2, 3) & " - 0" & m_reporte.VENT_DocsVenta.DOCVE_Codigo.ToString().Substring(5, 7)
            _guia = m_reporte.GTRAN_GuiasTransportista.GTRAN_Codigo.ToString().Substring(2, 4) & " - 0" & m_reporte.GTRAN_GuiasTransportista.GTRAN_Codigo.ToString().Substring(6, 7)
            '_guia = m_reporte.DIST_GuiasRemision.GUIAR_Codigo.ToString().Substring(2, 3) & " - 0" & m_reporte.DIST_GuiasRemision.GUIAR_Codigo.ToString().Substring(5, 7)
            _dr("NumeroComprobante") = _doc
            _dr("NroGuia") = _guia
            ' _dr("ENTID_CodigoCliente") = m_reporte.GTRAN_GuiasTransportista.ENTID_CodigoCliente
            ' _dr("ENTID_CodigoTransportista") = m_reporte.GTRAN_GuiasTransportista.ENTID_CodigoTransportista
            '_dr("DOCVE_ImporteIGV") = m_reporte.VENT_DocsVenta.DOCVE_ImporteIgv
            _dsdatos.TRAN_GuiasTransportista.Rows.Add(_dr)

            For Each item As ETRAN_GuiasTransportistaDetalles In m_reporte.GTRAN_GuiasTransportista.ListETRAN_GuiasTransportistaDetalles
                Dim x_dr As DataRow = _dsdatos.TRAN_GuiasTransportistaDetalles.NewRow()

                x_dr("GTDET_Peso") = item.GTDET_Peso
                x_dr("GTDET_Unidad") = item.GTDET_Unidad
                x_dr("GTDET_Item") = item.GTDET_Item
                x_dr("ARTIC_Codigo") = item.ARTIC_Codigo
                x_dr("GTDET_Descripcion") = item.GTDET_Descripcion
                x_dr("GTDET_Cantidad") = Math.Round(item.GTDET_Cantidad, 2)
                x_dr("GTRAN_Codigo") = item.GTRAN_Codigo

                _dsdatos.TRAN_GuiasTransportistaDetalles.Rows.Add(x_dr)

            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#End Region

#Region "Facturacion Electronica- Notas de Credito "
    Public Function RNotasCredito(ByVal x_docve_codigo As String, ByVal x_printername As String, ByVal x_imprimir As Boolean)
        Try
            Dim _btran As New BReporte(GApp.PuntoVenta, GApp.Periodo, GApp.Sucursal)
            Dim m_Path_Plantillas As String = System.IO.Path.Combine(Application.StartupPath, "Plantillas")
            Dim strReportName As String

            If (GApp.Empresa.Equals("ACERO") Or GApp.Empresa.Equals("VIRTU")) Then
                strReportName = "CRNotaCredito_Elec.rpt"
            Else
                strReportName = "CRNotaCredito_ElecPro.rpt"
            End If
            Dim strReportPath As String = System.IO.Path.Combine(m_Path_Plantillas, strReportName)

            If _btran.REPOS_NotasCre(x_docve_codigo) Then
                If x_imprimir Then

                Else ' Ver

                    VisualizarNC(_btran, strReportPath)
                    Return True

                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function VisualizarNC(ByRef m_reporte As BReporte, ByVal strReportPath As String) As Boolean
        Try
            Dim _dsdatos As New DSNotaCredito_Elec()
            getDatosNC(m_reporte, _dsdatos)

            Dim Informe As New ReportDocument
            Informe.Load(strReportPath)
            Informe.SetDataSource(_dsdatos)

            Dim reporte As New RReportView(Informe) With {.StartPosition = FormStartPosition.CenterScreen}
            reporte.Text = String.Format("Comprobante de Venta : {0}", m_reporte.VENT_DocsVenta.DOCVE_Codigo)
            reporte.Show()

            'Informe.Close()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getDatosNC(ByVal m_reporte As BReporte, ByRef _dsdatos As DSNotaCredito_Elec)
        Try
            Dim _dr As DataRow = _dsdatos.VENT_DocsVenta.NewRow()
            Dim _doc As String
            _dr("DOCVE_Codigo") = m_reporte.VENT_DocsVenta.DOCVE_CODIGO
            _dr("ALMAC_Descripcion") = GApp.EPuntoVenta.PVENT_Descripcion
            _dr("DOCVE_FechaDocumento") = m_reporte.VENT_DocsVenta.DOCVE_FechaDocumento.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha))
            _dr("Tipos_CodTipoDocumento") = m_reporte.VENT_DocsVenta.Tipos_CodTipoDocumento
            _dr("Tipos_CodTipoMoneda") = m_reporte.VENT_DocsVenta.TIPOS_CodTipoMoneda
            _dr("TIPOS_CondicionPago") = m_reporte.VENT_DocsVenta.TIPOS_CondicionPago
            _dr("TIPOS_TipoMoneda") = m_reporte.VENT_DocsVenta.TIPOS_TipoMoneda
            _dr("DOCVE_UsrCrea") = m_reporte.VENT_DocsVenta.DOCVE_UsrCrea
            _dr("ENTID_RazonSocial") = m_reporte.VENT_DocsVenta.ENTID_RazonSocial
            _dr("DOCVE_DireccionCliente") = m_reporte.VENT_DocsVenta.DOCVE_DireccionCliente
            _dr("DOCVE_ImporteVenta") = m_reporte.VENT_DocsVenta.Docve_ImporteVenta
            _dr("DOCVE_TotalVenta") = m_reporte.VENT_DocsVenta.DOCVE_TotalVenta
            _dr("DOCVE_TotalPagar") = m_reporte.VENT_DocsVenta.DOCVE_TotalPagar
            _dr("DOCVE_Motivo") = m_reporte.VENT_DocsVenta.DOCVE_Motivo
            _dr("Nro_EnLetras") = ACUtilitarios.NumPalabra(m_reporte.VENT_DocsVenta.DOCVE_TotalVenta, m_reporte.VENT_DocsVenta.TIPOS_TipoMoneda)
            _dr("DOCVE_Impresiones") = m_reporte.VENT_DocsVenta.DOCVE_Impresiones + 1

            If (GApp.EPuntoVenta.PVENT_Id = 9) Then
                _dr("DOCVE_Observaciones") = "Operacion Sujeta al Sistema de Pago de ObligacionesTributarias Con el Gobierno Central.     Cta. Cte. Bco. de la Nacion 101-091929"
            Else
                _dr("DOCVE_Observaciones") = ""
            End If

            _doc = m_reporte.VENT_DocsVenta.DOCVE_Codigo.ToString().Substring(2, 4) & " - 0" & m_reporte.VENT_DocsVenta.DOCVE_Codigo.ToString().Substring(6, 7)
            _dr("Nro_Documento") = _doc
            _dr("ENTID_CodigoCliente") = m_reporte.VENT_DocsVenta.ENTID_CodigoCliente
            _dr("DOCVE_ImporteIGV") = m_reporte.VENT_DocsVenta.DOCVE_ImporteIGV
            _dsdatos.VENT_DocsVenta.Rows.Add(_dr)

            For Each item As EVENT_DocsVentaDetalle In m_reporte.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                Dim x_dr As DataRow = _dsdatos.VENT_DocsVentaDetalle.NewRow()

                x_dr("DOCVD_PesoUnitario") = item.DOCVD_PesoUnitario
                x_dr("DOCVD_Unidad") = item.DOCVD_Unidad
                x_dr("DOCVD_Item") = item.DOCVD_Item
                x_dr("ARTIC_Codigo") = item.ARTIC_Codigo
                x_dr("ARTIC_Descripcion") = item.ARTIC_Descripcion
                x_dr("DOCVD_Cantidad") = Math.Round(item.DOCVD_Cantidad, 2)
                'item.DOCVD_Cantidad.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
                x_dr("DOCVD_PrecioUnitario") = Math.Round(item.DOCVD_PrecioUnitario, 2)
                x_dr("DOCVD_SubImporteVenta") = Math.Round(item.DOCVD_SubImporteVenta, 2)
                ' item.DOCVD_SubImporteVenta.ToString(Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d))
                x_dr("DOCVE_Codigo") = item.DOCVE_Codigo
                x_dr("DOCVD_PrecioTotal") = Math.Round(item.DOCVD_PrecioUnitario * item.DOCVD_Cantidad, 2)
                _dsdatos.VENT_DocsVentaDetalle.Rows.Add(x_dr)
            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Metodos de Controles"

#End Region
End Class
