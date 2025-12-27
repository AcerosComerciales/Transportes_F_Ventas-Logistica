Imports ACBTransporte
Imports ACETransporte
Imports ACBVentas
Imports ACEVentas

Imports ACSeguridad

Imports ACFramework
Imports C1.Win.C1FlexGrid

Public Class CEstPagosPorCliente
#Region " Variables "
   Private m_badministracioncaja As BAdministracionCaja
   Private managerEntidades As BEntidades
   Private m_entid_codigo As String

   Private bs_reporte As BindingSource
   Private bs_pagos As BindingSource
   Private bs_fletes As BindingSource
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         formatearGrilla()
         m_badministracioncaja = New BAdministracionCaja(GApp.Zona, GApp.Sucursal, GApp.PuntoVenta)
         managerEntidades = New BEntidades
         btnExcel.Enabled = False

         tsbtnAnularPago.Visible = False
         tsbtnAnularPago.Enabled = False
         GApp.DataUsuario.PROC_Codigo = Procesos.getProceso(Procesos.TipoProcesos.CajaAnularPagos)
         Dim _validate As New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarProceso)
         tsbtnAnularPago.Visible = _validate.ACProceso

         GApp.DataUsuario.PROC_Codigo = Procesos.getProceso(Procesos.TipoProcesos.CajaModFecha)
         _validate = New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarProceso)
         tsbtnModificarFecha.Visible = _validate.ACProceso

         btnProcesar.Enabled = False
         grpModFecha.Visible = False

         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACReporte_16x16.GetHicon)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdReporte, 1, 1, 9, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Codigo", "DOCVE_Codigo", "DOCVE_Codigo", 80, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Documento", "Documento", "Documento", 110, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Fecha", "DOCVE_FechaDocumento", "DOCVE_FechaDocumento", 80, True, False, "System.DateTime", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 60, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Importe US$", "TotalDolares", "TotalDolares", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Importe S/.", "DOCVE_TotalPagar", "DOCVE_TotalPagar", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Pago", "DOCVE_TotalPagado", "DOCVE_TotalPagado", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdReporte, index, "Pendiente", "SaldoPendiente", "SaldoPendiente", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         c1grdReporte.AllowEditing = False
         c1grdReporte.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdReporte.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdReporte.Styles.Highlight.BackColor = Color.Gray
         c1grdReporte.SelectionMode = SelectionModeEnum.Row
         c1grdReporte.AutoResize = False
         c1grdReporte.AllowResizing = AllowResizingEnum.Both
         c1grdReporte.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdReporte.Tree.Column = 1

         Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Facturado")
         t.BackColor = Color.LightGreen
         t.ForeColor = Color.DarkBlue
         t.Font = New Font(c1grdReporte.Font, FontStyle.Regular)

         Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Facturar")
         u.BackColor = Color.Green
         u.ForeColor = Color.White
         u.Font = New Font(c1grdReporte.Font, FontStyle.Regular)

         Dim j As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Pagar")
         j.BackColor = Color.DarkBlue
         j.ForeColor = Color.White
         j.Font = New Font(c1grdReporte.Font, FontStyle.Bold)

         Dim d As C1.Win.C1FlexGrid.CellStyle = c1grdReporte.Styles.Add("Anulado")
         d.BackColor = Color.Red
         d.ForeColor = Color.White
         d.Font = New Font(c1grdReporte.Font, FontStyle.Bold)
         c1grdReporte.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdPagos, 1, 1, 13, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Cod. Caja", "CAJA_Id", "CAJA_Id", 80, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Documento", "Documento", "Documento", 80, True, False, "System.Integer", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Orden Doc.", "CAJA_OrdenDocumento", "CAJA_OrdenDocumento", 90, True, False, "System.Integer") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Fecha", "CAJA_Fecha", "CAJA_Fecha", 350, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Fecha Proceso", "CAJA_FechaPago", "CAJA_FechaPago", 350, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Importe", "CAJA_Importe", "CAJA_Importe", 100, True, False, "System.Decimal", Parametros.GetParametro(ACEVentas.EParametros.TipoParametros.pg_FMondo2d)) : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Transacción", "TIPOS_Transaccion", "TIPOS_Transaccion", 80, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 80, True, False, "System.String") : index += 1

         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Glosa", "Glosa", "Glosa", 80, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Fecha", "DPAGO_Fecha", "DPAGO_Fecha", 80, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Estado", "CAJA_Estado", "CAJA_Estado", 80, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Estado", "CAJA_Estado_Text", "CAJA_Estado_Text", 80, True, False, "System.String") : index += 1

         c1grdPagos.AllowEditing = False
         c1grdPagos.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdPagos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdPagos.Styles.Highlight.BackColor = Color.Gray
         c1grdPagos.SelectionMode = SelectionModeEnum.Row
         c1grdPagos.AutoResize = True
         c1grdPagos.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         Dim t2 As C1.Win.C1FlexGrid.CellStyle = c1grdPagos.Styles.Add("Facturado")
         t2.BackColor = Color.LightGreen
         t2.ForeColor = Color.DarkBlue
         t2.Font = New Font(c1grdPagos.Font, FontStyle.Regular)

         Dim u2 As C1.Win.C1FlexGrid.CellStyle = c1grdPagos.Styles.Add("Facturar")
         u2.BackColor = Color.Green
         u2.ForeColor = Color.White
         u2.Font = New Font(c1grdPagos.Font, FontStyle.Regular)

         Dim j2 As C1.Win.C1FlexGrid.CellStyle = c1grdPagos.Styles.Add("Pagar")
         j2.BackColor = Color.DarkBlue
         j2.ForeColor = Color.White
         j2.Font = New Font(c1grdPagos.Font, FontStyle.Bold)

         Dim d3 As C1.Win.C1FlexGrid.CellStyle = c1grdPagos.Styles.Add("Anulado")
         d3.BackColor = Color.Red
         d3.ForeColor = Color.White
         d3.Font = New Font(c1grdPagos.Font, FontStyle.Bold)
         c1grdPagos.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdFletes, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Viaje", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Código", "FLETE_Id", "FLETE_Id", 250, True, False, "Syste m.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Viaje", "VIAJE_Descripcion", "VIAJE_Descripcion", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Peso T.M.", "FLETE_PesoEnTM", "FLETE_PesoEnTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Monto x TM", "FLETE_MontoPorTM", "FLETE_MontoPorTM", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "I.G.V.", "FLETE_ImporteIgv", "FLETE_ImporteIgv", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Total Flete", "FLETE_TotIngreso", "FLETE_TotIngreso", 250, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Salida", "FLETE_FecSalida", "FLETE_FecSalida", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Llegada", "FLETE_FecLlegada", "FLETE_FecLlegada", 250, True, False, "System.DateTime", "dd/MM/yyyy") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Descripción", "FLETE_Glosa", "FLETE_Glosa", 250, True, False, "System.String") : index += 1

         c1grdFletes.AllowEditing = False
         c1grdFletes.AutoResize = True
         c1grdFletes.Cols(0).Width = 18
         c1grdFletes.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdFletes.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdFletes.Styles.Highlight.BackColor = Color.Gray
         c1grdFletes.SelectionMode = SelectionModeEnum.Row
         c1grdFletes.AllowResizing = AllowResizingEnum.Rows
         c1grdFletes.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         Dim tt As C1.Win.C1FlexGrid.CellStyle = c1grdPagos.Styles.Add("Anulado")
         tt.BackColor = Color.Red
         tt.ForeColor = Color.White
         tt.Font = New Font(c1grdPagos.Font, FontStyle.Bold)

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
      End Try
   End Sub


   Private m_order As Integer = 1
   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of EVENT_DocsVenta)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_reporte.DataSource, List(Of EVENT_DocsVenta)).Sort(_ordenador)
         c1grdReporte.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub c1grdReporte_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdReporte.OwnerDrawCell
      Try
         If e.Row < c1grdReporte.Rows.Fixed OrElse e.Col < c1grdReporte.Cols.Fixed Then Return
         'If c1grdReporte.Rows(e.Row)("Pendiente") <> 0 Then
         '   e.Style = c1grdReporte.Styles("Facturado")
         'End If
         If c1grdReporte.Cols(e.Col).Name = "SaldoPendiente" Then
            If c1grdReporte.Rows(e.Row)("SaldoPendiente") <> 0 Then
               e.Style = c1grdReporte.Styles("Anulado")
            End If
         End If

         If c1grdReporte.Cols(e.Col).Name = "DOCVE_TotalPagar" Then
            If c1grdReporte.Rows(e.Row)("DOCVE_TotalPagar") > 0 Then
               e.Style = c1grdReporte.Styles("Pagar")
            End If
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub c1grdPagos_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdPagos.OwnerDrawCell
      Try
         If e.Row < c1grdPagos.Rows.Fixed OrElse e.Col < c1grdReporte.Cols.Fixed Then Return
         If c1grdPagos.Rows(e.Row)("CAJA_Estado") = ETESO_Caja.getEstado(ETESO_Caja.Estado.Anulado) Then
            e.Style = c1grdPagos.Styles("Anulado")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub bs_reporte_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      bs_pagos = New BindingSource
      bs_fletes = New BindingSource
      Try
         If Not IsNothing(bs_reporte.Current) Then
            Dim _codigo As String = CType(bs_reporte.Current, EVENT_DocsVenta).DOCVE_Codigo
            tsbtnAnularPago.Enabled = True
            If Not m_badministracioncaja.CuadreCajaPagos(tsmiMostrarTodos.Checked, _codigo) Then
               m_badministracioncaja.ListTESO_CajaPagos = New List(Of ETESO_Caja)
               tsbtnAnularPago.Enabled = False
            End If
            bs_pagos.DataSource = m_badministracioncaja.ListTESO_CajaPagos
            c1grdPagos.DataSource = bs_pagos
            bnavPagos.BindingSource = bs_pagos
            c1grdPagos.Subtotal(AggregateEnum.Sum, 0, -1, c1grdPagos.Cols("CAJA_Importe").Index, "Total")

            If Not m_badministracioncaja.FletesXFacturas(_codigo) Then
               m_badministracioncaja.ListTRAN_Fletes = New List(Of ETRAN_Fletes)
            End If
            bs_fletes.DataSource = m_badministracioncaja.ListTRAN_Fletes
            c1grdFletes.DataSource = bs_fletes
            bnavFletes.BindingSource = bs_fletes
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, c1grdFletes.Cols("FLETE_PesoEnTM").Index, "Total")
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, c1grdFletes.Cols("FLETE_TotIngreso").Index, "Total")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Sub c1grdReporte_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdReporte.BeforeSort
      Try
         Ordenar(c1grdReporte.Cols(e.Col).UserData)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub

#Region " Clientes "
   Private Sub setCliente()
      '' Cargar datos adicionales cliente
      If actxaCliRuc.ACAyuda.Enabled = True Then
         If managerEntidades.CargarDocIden(actxaCliRuc.Text, EEntidades.TipoInicializacion.Direcciones) Then
            '' Cargar datos del cliente
            m_entid_codigo = managerEntidades.Entidades.ENTID_Codigo

            Dim x_direcciones As New EDirecciones
            x_direcciones.DIREC_Id = 0
            x_direcciones.Direccion = managerEntidades.Entidades.Direccion
            x_direcciones.UBIGO_Codigo = managerEntidades.Entidades.UBIGO_Codigo
            If IsNothing(managerEntidades.Entidades.ListDirecciones) Then managerEntidades.Entidades.ListDirecciones = New List(Of EDirecciones)()
            managerEntidades.Entidades.ListDirecciones.Insert(0, x_direcciones)

            actxaCliRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
            actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
            btnProcesar.Enabled = True
            btnProcesar.Focus()
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Documento de Identidad: {0}", Me.Text) _
                            , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaCliRuc.Text) _
                            )

            btnClean_Click(Nothing, Nothing)
            lblNroDocumento.Focus()
         End If
      End If
   End Sub

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         Dim _where As New Hashtable
         _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
         If managerEntidades.Ayuda(_where, x_opcion) Then
            Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerEntidades.DTEntidades, False)
            If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Select Case x_opcion
                  Case EEntidades.TipoEntidad.Clientes
                     '' Cargar datos del cliente
                     m_entid_codigo = Ayuda.Respuesta.Rows(0)("Codigo")
                     actxaCliRazonSocial.Text = Ayuda.Respuesta.Rows(0)("Razon Social").ToString()
                     actxaCliRuc.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.").ToString()
                     setCliente()
                     btnProcesar.Enabled = True
                     btnProcesar.Focus()
                  Case EEntidades.TipoEntidad.Vendedores
                     Dim x_entid_codigo As String = Ayuda.Respuesta.Rows(0)("Codigo")
               End Select
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede mostrar la ayuda, posiblemente no haya datos que mostrar")
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub actxaCliRuc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaCliRuc.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaCliRuc.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               setCliente()
            Else
               If actxaCliRuc.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaCliRuc.Text))
                  btnClean_Click(Nothing, Nothing)
                  lblNroDocumento.Focus()
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaCliRuc_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliRuc.ACAyudaClick
      Try
         AyudaEntidad(actxaCliRuc.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Clientes)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Documento de Identidad", ex)
      End Try
   End Sub

   Private Sub actxaCliRazonSocial_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliRazonSocial.ACAyudaClick
      Try
         AyudaEntidad(actxaCliRazonSocial.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Clientes)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso busqueda de cliente por Nombre/Razon Social", ex)
      End Try
   End Sub

   Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClean.Click
      Try
         actxaCliRazonSocial.Clear()
         actxaCliRuc.Clear()
         actxaCliRuc.Focus()
         m_entid_codigo = Nothing
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Limpiar Entidad", ex)
      End Try
   End Sub
#End Region
#End Region


   Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      bs_reporte = New BindingSource
      Try
         btnExcel.Enabled = True
         Dim _reporte As New ETRAN_Fletes

         If Not m_badministracioncaja.FacturasXCliente(m_entid_codigo, rbtnTodos.Checked) Then
            m_badministracioncaja.ListVENT_DocsVenta = New List(Of EVENT_DocsVenta)
            btnExcel.Enabled = False
         End If
         bs_reporte.DataSource = m_badministracioncaja.ListVENT_DocsVenta

         c1grdReporte.DataSource = bs_reporte
         bnavReporte.BindingSource = bs_reporte
         AddHandler bs_reporte.CurrentChanged, AddressOf bs_reporte_CurrentChanged
         tsmiMostrarTodos.Checked = False
         bs_reporte_CurrentChanged(Nothing, Nothing)
         c1grdReporte.AutoSizeRows()

         c1grdReporte.Subtotal(AggregateEnum.Sum, 0, -1, 6, "Total")
         c1grdReporte.Subtotal(AggregateEnum.Sum, 0, -1, 7, "Total")
         c1grdReporte.Subtotal(AggregateEnum.Sum, 0, -1, 8, "Total")
         c1grdReporte.AutoSizeCol(1)

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar el Reporte"), ex)
      End Try
   End Sub

   Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
      Utilitarios.ExportarXLS(c1grdReporte, String.Format("Estado de Cuenta"))
   End Sub

   Private Sub tsbtnAnularPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAnularPago.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Anular Registro: {0}", Me.Text) _
             , String.Format("Desea anular el registro de pago Nro: {0} de {1}", CType(bs_pagos.Current, ETESO_Caja).CAJA_Id _
                             , CType(bs_reporte.Current, EVENT_DocsVenta).Documento) _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            Dim m_caja As New BTESO_Caja
            If m_caja.CambiarEstado(CType(bs_pagos.Current, ETESO_Caja).CAJA_Id, GApp.PuntoVenta, CType(bs_pagos.Current, ETESO_Caja).CAJA_Fecha, ETESO_Caja.Estado.Anulado, GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Anulado satisfactoriamente")
               bs_reporte_CurrentChanged(Nothing, Nothing)
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), "Anular el registro"))
            End If
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Anular Pagos"), ex)
      End Try
   End Sub

   Private Sub tsbtnModificarFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnModificarFecha.Click
      Try

         SplitContainer2.Panel1.Enabled = False
         SplitContainer3.Panel2.Enabled = False
         grpModFecha.Visible = True

         c1grdPagos.Enabled = False
         bnavPagos.Enabled = False

         dtpFecha.Value = CType(bs_pagos.Current, ETESO_Caja).CAJA_Fecha
         dtpFecha.Focus()

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Anular Pagos"), ex)
      End Try
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Try
         Dim m_caja As New BTESO_Caja
         m_caja.TESO_Caja = CType(bs_pagos.Current, ETESO_Caja)
         m_caja.TESO_Caja.PVENT_Id = GApp.PuntoVenta
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Modificar Registro: {0}", Me.Text) _
           , String.Format("Desea Modificar el registro de pago Nro: {0} de {1}", CType(bs_pagos.Current, ETESO_Caja).CAJA_Id _
                           , CType(bs_reporte.Current, EVENT_DocsVenta).Documento) _
           , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

            If m_caja.ModificarFecha(dtpFecha.Value, GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Cambiado satisfactoriamente")
               SplitContainer2.Panel1.Enabled = True
               SplitContainer3.Panel2.Enabled = True
               grpModFecha.Visible = False
               c1grdPagos.Enabled = True
               bnavPagos.Enabled = True
               bs_reporte_CurrentChanged(Nothing, Nothing)
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format(Colecciones.getError("00102"), "Cambiar Fecha del registro"))
            End If
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Modificar Fecha"), ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Try

         SplitContainer2.Panel1.Enabled = True
         SplitContainer3.Panel2.Enabled = True
         grpModFecha.Visible = False
         c1grdPagos.Enabled = True
         bnavPagos.Enabled = True

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Modificar Fecha"), ex)
      End Try
   End Sub

   Private Sub dtpFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnAceptar.Focus()
      ElseIf e.KeyCode = Keys.Escape Then
         btnCancelar_Click(Nothing, Nothing)
      End If
   End Sub

   Private Sub tsmiMostrarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiMostrarTodos.Click

   End Sub

   Private Sub tsmiMostrarTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiMostrarTodos.CheckedChanged
      bs_reporte_CurrentChanged(Nothing, Nothing)
   End Sub

    Private Sub c1grdReporte_Click(sender As Object, e As EventArgs) Handles c1grdReporte.Click

    End Sub
End Class