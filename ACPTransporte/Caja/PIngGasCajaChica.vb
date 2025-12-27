Imports ACEVentas
Imports ACBVentas
Imports ACFramework
Imports C1.Win.C1FlexGrid
Imports ACSeguridad

Public Class PIngGasCajaChica
#Region " Variables "
   Private managerEntidades As BEntidades
   Private m_teso_cajachicaingreso As BTESO_CajaChicaIngreso
   Private m_listBindHelper As List(Of ACBindHelper)
   Private bs_cajachica As BindingSource
   Private bs_pagos As BindingSource

   Private m_xingresosmismodia As Boolean = False
   Private m_xingresosposterior As Boolean = False
   Private m_xingresospagos As Boolean = False
   Private m_qingresos As Boolean = False

   Enum Seteo
      Activar
      Desactivar
   End Enum
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_icono As System.Drawing.Bitmap)

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         managerEntidades = New BEntidades
         m_teso_cajachicaingreso = New BTESO_CajaChicaIngreso

         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
         CargarCombos()
         formatearGrilla()
         actxnImporte.ReadOnly = False
         AcFecha.ACFechaChecked = False
         Me.KeyPreview = False

         acTool.ACBtnSalirVisible = True
         If Not IsNothing(x_icono) Then Me.Icon = Icon.FromHandle(x_icono.GetHicon)
         Dim _validate As ACValidarUsuario
         _validate = New ACValidarUsuario(GApp.DataConexion, GApp.DataUsuario, ACValidarUsuario.Operacion.ValidarVariosProcesos)
         For Each item As ACSeguridad.EProcesos In _validate.ListProcesos
            Select Case item.PROC_Codigo
               Case Procesos.getProceso(Procesos.TipoProcesos.CChica_AnulaIngresosMismoDia)
                  m_xingresosmismodia = True
               Case Procesos.getProceso(Procesos.TipoProcesos.CChica_AnulaIngresosPosterior)
                  m_xingresosposterior = True
               Case Procesos.getProceso(Procesos.TipoProcesos.CChica_AnulaIngresosPagos)
                  m_xingresospagos = True
               Case Procesos.getProceso(Procesos.TipoProcesos.CChica_QuitarPago)
                  m_qingresos = True
            End Select
         Next
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
      acTool.ACBtnAnularVisible = False
      Select Case _opcion
         Case ACUtilitarios.ACSetInstancia.Nuevo
            ACUtilitarios.ACLimpiaVar(pnlDatos)
            tabMantenimiento.SelectedTab = tabDatos
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            Me.KeyPreview = True
            acTool.ACBtnAnularVisible = False
            actsbtnPagar.Visible = False
         Case ACUtilitarios.ACSetInstancia.Deshacer
            tabMantenimiento.SelectedTab = tabBusqueda
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
            Me.KeyPreview = False
            acTool.ACBtnAnularVisible = True
            actsbtnPagar.Visible = True
            acTool.ACBtnAnularVisible = m_xingresosmismodia
         Case ACUtilitarios.ACSetInstancia.Previsualizar

         Case ACUtilitarios.ACSetInstancia.Modificado
            ACUtilitarios.ACLimpiaVar(pnlDatos)
            tabMantenimiento.SelectedTab = tabPagos
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            acTool.ACBtnGrabarVisible = False
            acTool.ACBtnCancelarVisible = True
            acTool.ACBtnAnularVisible = False
            actsbtnPagar.Visible = False
         Case Else
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
      End Select
      acTool.ACBtnEliminarVisible = False
      acTool.ACBtnModificarVisible = False

   End Sub

   Private Sub setRolCliente(ByVal x_opcion As Seteo)
      Try
         actxaRazonSocial.ReadOnly = IIf(x_opcion = Seteo.Activar, False, True)
         actxaRazonSocial.ACActivarAyuda = IIf(x_opcion = Seteo.Activar, True, False)
         actxaRazonSocial.ACAyuda.Enabled = IIf(x_opcion = Seteo.Activar, True, False)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub NuevaEntidad(ByVal x_entid_nrodocumento As String)
      Try
         Dim frmEntidad As New MEntidad(MEntidad.Inicio.NuevaEntidad, ACEVentas.EEntidades.TipoEntidad.Usuarios)
         frmEntidad.StartPosition = FormStartPosition.CenterScreen
         If x_entid_nrodocumento.Length > 0 Then
            frmEntidad.EEntidad.ENTID_NroDocumento = x_entid_nrodocumento
            frmEntidad.lblNombres.Focus()
         End If
         If frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            managerEntidades.Entidades = frmEntidad.EEntidad
            m_teso_cajachicaingreso.TESO_CajaChicaIngreso.ENTID_Codigo = frmEntidad.EEntidad.ENTID_Codigo

            actxaRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
            actxaDocumento.Text = managerEntidades.Entidades.ENTID_NroDocumento
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         Dim _where As New Hashtable
         _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
         If managerEntidades.Ayuda(_where, x_opcion) Then
            Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerEntidades.DTEntidades, False)
            If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Select Case x_opcion
                  Case EEntidades.TipoEntidad.Usuarios
                     '' Cargar datos del cliente
                     m_teso_cajachicaingreso.TESO_CajaChicaIngreso.ENTID_Codigo = Ayuda.Respuesta.Rows(0)("Codigo")
                     actxaRazonSocial.Text = Ayuda.Respuesta.Rows(0)("Razon Social").ToString()
                     actxaDocumento.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.").ToString()
                     Label3.Focus()
                  Case EEntidades.TipoEntidad.Vendedores
                     Dim x_entid_codigo As String = Ayuda.Respuesta.Rows(0)("Codigo")
               End Select
            Else

            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede mostrar la ayuda, posiblemente no haya datos que mostrar")
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(actxaDocumento, "Text", m_teso_cajachicaingreso.TESO_CajaChicaIngreso, "ENTID_Codigo"))
         If m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Fecha.Year < 1700 Then m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecha, "Value", m_teso_cajachicaingreso.TESO_CajaChicaIngreso, "CAJAC_Fecha"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDetalles, "Text", m_teso_cajachicaingreso.TESO_CajaChicaIngreso, "CAJAC_Detalle"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnImporte, "Text", m_teso_cajachicaingreso.TESO_CajaChicaIngreso, "CAJAC_Importe"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", m_teso_cajachicaingreso.TESO_CajaChicaIngreso, "TIPOS_CodTipoMoneda"))

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub CargarCombos()
      Try
         '' Moneda
         ACUtilitarios.ACCargaCombo(cmbMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_DescCorta", "TIPOS_Codigo")
         ACUtilitarios.ACCargaCombo(cmbCMoneda, Colecciones.Tipos(ETipos.MyTipos.TipoMoneda), "TIPOS_DescCorta", "TIPOS_Codigo")

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 10, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "CAJAC_Id", "CAJAC_Id", 150, True, False, "System.String", "0000#") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "CAJAC_Fecha", "CAJAC_Fecha", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Usuario", "ENTID_Codigo", "ENTID_Codigo", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Usuario", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Importe", "CAJAC_Importe", "CAJAC_Importe", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Saldo", "Saldo", "Saldo", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Detalle", "CAJAC_Detalle", "CAJAC_Detalle", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "CAJAC_Estado", "CAJAC_Estado", 150, True, False, "System.String") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.LightGray
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn

         Dim t As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Facturado")
         t.BackColor = Color.LightGreen
         t.ForeColor = Color.DarkBlue
         t.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

         Dim u As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Facturar")
         u.BackColor = Color.Green
         u.ForeColor = Color.White
         u.Font = New Font(c1grdBusqueda.Font, FontStyle.Regular)

         Dim d As C1.Win.C1FlexGrid.CellStyle = c1grdBusqueda.Styles.Add("Anulado")
         d.BackColor = Color.Red
         d.ForeColor = Color.White
         d.Font = New Font(c1grdBusqueda.Font, FontStyle.Bold)
         c1grdBusqueda.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdPagos, 1, 1, 8, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Item", "CAJAP_Item", "CAJAP_Item", 150, True, False, "System.String", "0000#") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Fecha", "CAJAP_Fecha", "CAJAP_Fecha", 150, True, False, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Detalle", "CAJAP_Descripcion", "CAJAP_Descripcion", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Importe", "CAJAP_Importe", "CAJAP_Importe", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Documento", "Documento", "Documento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "R.U.C.", "ENTID_Codigo", "ENTID_Codigo", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPagos, index, "Razon Social", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1

         c1grdPagos.AllowEditing = False
         c1grdPagos.Styles.Alternate.BackColor = Color.LightGray
         c1grdPagos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdPagos.Styles.Highlight.BackColor = Color.Gray
         c1grdPagos.SelectionMode = SelectionModeEnum.Row
         c1grdPagos.AllowSorting = AllowSortingEnum.SingleColumn
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub actxaCliRuc_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaDocumento.KeyUp
      Try
         If actxaDocumento.Text.Length > 1 Then
            setRolCliente(Seteo.Desactivar)
         Else
            setRolCliente(Seteo.Activar)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Procesar la cadena"), ex)
      End Try
   End Sub

   Private Sub btnNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCliente.Click
      Try
         NuevaEntidad("")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Cliente", ex)
      End Try
   End Sub

   Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClean.Click
      Try
         actxaRazonSocial.Clear()
         actxaDocumento.Clear()
         setRolCliente(Seteo.Activar)
         actxaDocumento.Focus()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Limpiar Entidad", ex)
      End Try
   End Sub

   Private Sub actxaCliRuc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaDocumento.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaDocumento.Text.ToString().Length >= Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaDocumento.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaDocumento.Text, EEntidades.TipoInicializacion.Cliente) Then
                     '' Cargar datos del cliente
                     m_teso_cajachicaingreso.TESO_CajaChicaIngreso.ENTID_Codigo = managerEntidades.Entidades.ENTID_Codigo

                     actxaRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
                     actxaDocumento.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     Label3.Focus()
                  Else
                     If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                     , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaDocumento.Text) _
                                     , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        NuevaEntidad(actxaDocumento.Text)
                     Else
                        btnClean_Click(Nothing, Nothing)
                        Label3.Focus()
                     End If
                  End If
               End If
            Else
               If actxaDocumento.Text.Trim().Length > 0 Then
                  actxaRazonSocial.Clear()
                  If managerEntidades.CargarDocIden(Constantes.Cliente(Constantes.TCliente.Blanco), EEntidades.TipoInicializacion.Cliente) Then
                     m_teso_cajachicaingreso.TESO_CajaChicaIngreso.ENTID_Codigo = managerEntidades.Entidades.ENTID_Codigo
                     btnClean.Enabled = False
                     btnNuevoCliente.Enabled = False
                  End If
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         If TypeOf ActiveControl Is ACControles.ACTextBoxAyuda And ActiveControl.Name = "actxaProdCodigo" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub

   Private Sub AcFecha_ACFecIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecIni_KeyDown
      If e.KeyData = Keys.Enter Then
         AcFecha.ACDtpFecha_A.Focus()
      End If
   End Sub

   Private Sub AcFecha_ACFecFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecFin_KeyDown
      If e.KeyData = Keys.Enter Then
         btnCConsultar_Click(Nothing, Nothing)
      End If
   End Sub

#End Region

   Private Sub acTool_ACBtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnAnular_Click
      Try
         If m_xingresosmismodia Then
            If CType(bs_cajachica.Current, ETESO_CajaChicaIngreso).CAJAC_Estado = Constantes.getEstado(Constantes.Estado.Anulado) Then
               Throw New Exception("No puede anular un Ingreso que ya se encuentra anulado")
            End If
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Anular Registro: {0}", Me.Text) _
                         , String.Format("Desea Anular el registro Nro.: {0:00000}", CType(bs_cajachica.Current, ETESO_CajaChicaIngreso).CAJAC_Id) _
                         , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then

               Dim _pagos As New BTESO_CajaChicaPagos
               Dim _where As New Hashtable
               _where.Add("PVENT_Id", New ACWhere(CType(bs_cajachica.Current, ETESO_CajaChicaIngreso).PVENT_Id))
               _where.Add("CAJAC_Id", New ACWhere(CType(bs_cajachica.Current, ETESO_CajaChicaIngreso).CAJAC_Id))
               If _pagos.CargarTodos(_where) Then
                  If Not m_xingresospagos Then
                     Throw New Exception("Ud. No tiene autorizacion para eliminar los ingresos y sus pagos respectivos")
                  End If
               End If

               m_teso_cajachicaingreso.TESO_CajaChicaIngreso = New ETESO_CajaChicaIngreso
               m_teso_cajachicaingreso.TESO_CajaChicaIngreso.Instanciar(ACEInstancia.Modificado)
               m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Id = CType(bs_cajachica.Current, ETESO_CajaChicaIngreso).CAJAC_Id
               m_teso_cajachicaingreso.TESO_CajaChicaIngreso.PVENT_Id = CType(bs_cajachica.Current, ETESO_CajaChicaIngreso).PVENT_Id
               m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Estado = Constantes.getEstado(Constantes.Estado.Anulado)

               Dim _constantes As New BConstantes
               If Not _constantes.getFecha().Date = CType(bs_cajachica.Current, ETESO_CajaChicaIngreso).CAJAC_Fecha.Date Then
                  '' Verificar si el usuario tiene autorizacion
                  If Not m_xingresosposterior Then
                     Throw New Exception("Ud. No tiene autorizacion para anular un ingreso que no fue echo el dia de hoy")
                  End If
               End If

               If m_teso_cajachicaingreso.Guardar(GApp.Usuario, m_xingresospagos) Then
                  ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Anulado satisfactoriamente")
                  btnCConsultar_Click(Nothing, Nothing)
               Else
                  Throw New Exception("No se puede Anular el documento, ocurrio un error en el proceso")
               End If
            End If
         Else
            Throw New Exception("Ud. no tiene autorizacion para realizar esta operacion")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Anular Registro"), ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click
      setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
      btnCConsultar_Click(Nothing, Nothing)
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Grabar Registro: {0}", Me.Text) _
                      , "Desea Grabar el registro: " _
                      , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            m_teso_cajachicaingreso.TESO_CajaChicaIngreso.PVENT_Id = GApp.PuntoVenta
            Dim _where As New Hashtable
            _where.Add("PVENT_Id", New ACWhere(GApp.PuntoVenta))
            m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Id = m_teso_cajachicaingreso.getCorrelativo("CAJAC_Id", _where)
            m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
            If m_teso_cajachicaingreso.Guardar(GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
               setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
               btnCConsultar_Click(Nothing, Nothing)
            Else
               Throw New Exception("No se puede grabar el registro")
            End If
         Else
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Grabar Registro"), ex)
      End Try
      setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
   End Sub

   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)
         m_teso_cajachicaingreso.TESO_CajaChicaIngreso = New ETESO_CajaChicaIngreso
         m_teso_cajachicaingreso.TESO_CajaChicaIngreso.Instanciar(ACEInstancia.Nuevo)
         AsignarBinding()
         Label1.Focus()

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Completar el proceso Nuevo"), ex)
      End Try
   End Sub

   Private Sub actxaRazonSocial_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaRazonSocial.ACAyudaClick
      Try
         AyudaEntidad(actxaRazonSocial.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Usuarios)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso busqueda de cliente por Nombre/Razon Social", ex)
      End Try
   End Sub

   Private Sub actxaDocumento_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDocumento.ACAyudaClick
      Try
         AyudaEntidad(actxaDocumento.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Usuarios)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Documento de Identidad", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub btnCConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCConsultar.Click
      bs_cajachica = New BindingSource
      Try
         If AcFecha.ACFechaChecked Then
                If Not m_teso_cajachicaingreso.ConsultaCajaChica(AcFecha.ACFecha_De.Value.Date, AcFecha.ACFecha_A.Value.Date, txtBusqueda.Text, GApp.PuntoVenta, chkTodos.Checked, AcFecha.ACFechaChecked, "PCC01") Then
                    m_teso_cajachicaingreso.ListTESO_CajaChicaIngreso = New List(Of ETESO_CajaChicaIngreso)
                End If
         Else
                If Not m_teso_cajachicaingreso.ConsultaCajaChica(DateTime.Now, DateTime.Now, txtBusqueda.Text, GApp.PuntoVenta, chkTodos.Checked, AcFecha.ACFechaChecked, "PCC01") Then
                    m_teso_cajachicaingreso.ListTESO_CajaChicaIngreso = New List(Of ETESO_CajaChicaIngreso)
                End If
         End If
         
         bs_cajachica.DataSource = m_teso_cajachicaingreso.ListTESO_CajaChicaIngreso
         c1grdBusqueda.DataSource = bs_cajachica
         bnavBusqueda.BindingSource = bs_cajachica

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar la Busqueda"), ex)
      End Try
   End Sub

   Private Sub c1grdPagos_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdBusqueda.OwnerDrawCell
      Try
         If e.Row < c1grdBusqueda.Rows.Fixed OrElse e.Col < c1grdBusqueda.Cols.Fixed Then Return
         If c1grdBusqueda.Rows(e.Row)("CAJAC_Estado") = Constantes.getEstado(Constantes.Estado.Anulado) Then
            e.Style = c1grdBusqueda.Styles("Anulado")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Dar formato a la grilla"), ex)
      End Try
   End Sub

   Private Sub actxnImporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxnImporte.KeyDown
      If e.KeyData = Keys.Enter Then
         KeyPreview = False
         acTool.Focus()
         acTool.ACBtnGrabar.Select()
      End If
   End Sub

   Private Sub tsbtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAgregar.Click
      Try
         Dim _frm As New PDocumento(m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Id, _
                                    m_teso_cajachicaingreso.TESO_CajaChicaIngreso.TIPOS_CodTipoMoneda, _
                                    m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Importe, _
                                    tstxtTotal.Text)
         _frm.WindowState = FormWindowState.Normal
         _frm.StartPosition = FormStartPosition.CenterScreen
         If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CargarPagos()

         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Agregar Pago"), ex)
      End Try
   End Sub

   Private Sub CargarPagos()
      Try
         Dim _pagos As New BTESO_CajaChicaPagos
         If _pagos.ConsultaPagosCC(m_teso_cajachicaingreso.TESO_CajaChicaIngreso.PVENT_Id, m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Id) Then
            m_teso_cajachicaingreso.ListTESO_CajaChicaPagos = _pagos.ListTESO_CajaChicaPagos
         Else
            m_teso_cajachicaingreso.ListTESO_CajaChicaPagos = New List(Of ETESO_CajaChicaPagos)
         End If
         bs_pagos = New BindingSource
         bs_pagos.DataSource = m_teso_cajachicaingreso.ListTESO_CajaChicaPagos
         c1grdPagos.DataSource = bs_pagos
         bnavPagos.BindingSource = bs_pagos
         Calcular()
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub Calcular()
      Try
         Dim _total As Decimal = 0
         For Each item As ETESO_CajaChicaPagos In m_teso_cajachicaingreso.ListTESO_CajaChicaPagos
            _total += item.CAJAP_Importe
         Next
         tstxtTotal.Text = _total.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub actsbtnPagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actsbtnPagar.Click
      Try
         m_teso_cajachicaingreso.TESO_CajaChicaIngreso = CType(bs_cajachica.Current, ETESO_CajaChicaIngreso)
         If m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Estado = Constantes.getEstado(Constantes.Estado.Anulado) Then
            Throw New Exception("No puede Pagar un Ingreso Anulado")
         End If
         If m_teso_cajachicaingreso.Cargar() Then
            setInstancia(ACUtilitarios.ACSetInstancia.Modificado)
            txtDocUsuario.Text = m_teso_cajachicaingreso.TESO_CajaChicaIngreso.ENTID_Codigo
            txtRazSocialUsuario.Text = m_teso_cajachicaingreso.TESO_CajaChicaIngreso.ENTID_RazonSocial
            dtpCFecha.Value = m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Fecha
            txtCDetalle.Text = m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Detalle
            cmbCMoneda.SelectedValue = m_teso_cajachicaingreso.TESO_CajaChicaIngreso.TIPOS_CodTipoMoneda
            actxaCImporte.Text = m_teso_cajachicaingreso.TESO_CajaChicaIngreso.CAJAC_Importe

            bs_pagos = New BindingSource
            bs_pagos.DataSource = m_teso_cajachicaingreso.ListTESO_CajaChicaPagos
            c1grdPagos.DataSource = bs_pagos
            bnavPagos.BindingSource = bs_pagos
            Calcular()
            tsbtnQuitar.Enabled = m_qingresos
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Pagar"), ex)
      End Try
   End Sub

   Private Sub tsbtnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnQuitar.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
                      , String.Format("Desea Quitar el registro por un importe de : {0}", CType(bs_pagos.Current, ETESO_CajaChicaPagos).CAJAP_Importe) _
                      , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            If Not m_qingresos Then
               Throw New Exception("Ud no tiene autorizacion para realizar esta operacion")
            End If
            Dim _pagos As New BTESO_CajaChicaPagos
            _pagos.TESO_CajaChicaPagos = New ETESO_CajaChicaPagos
            _pagos.TESO_CajaChicaPagos.Instanciar(ACEInstancia.Modificado)
            _pagos.TESO_CajaChicaPagos.PVENT_Id = CType(bs_pagos.Current, ETESO_CajaChicaPagos).PVENT_Id
            _pagos.TESO_CajaChicaPagos.CAJAC_Id = CType(bs_pagos.Current, ETESO_CajaChicaPagos).CAJAC_Id
            _pagos.TESO_CajaChicaPagos.CAJAP_Item = CType(bs_pagos.Current, ETESO_CajaChicaPagos).CAJAP_Item
            _pagos.TESO_CajaChicaPagos.CAJAP_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
            If _pagos.Guardar(GApp.Usuario) Then
               CargarPagos()
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Pago Anulado satisfactoriamente")
            Else
               Throw New Exception("No se puede completar el proceso de ""quitar pago""")
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Quitar Pago"), ex)
      End Try
   End Sub
End Class