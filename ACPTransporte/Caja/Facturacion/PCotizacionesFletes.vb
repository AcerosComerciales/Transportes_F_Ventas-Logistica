Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports ACBVentas
Imports ACEVentas
Imports C1.Win.C1FlexGrid

Public Class PCotizacionesFletes

    'COTIZACIONES DE TRANSPORTES FLETES
    '  %&&  %  ,.   *. %(*                                                                                                                                                                                *(*
    ' , (((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
    ' * ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,Fechas,,,,,,,,,,,,,,,,,,
    '   ,Opciones de Busqueda                                                                                                                  Cliente                 **Consultar,@,,#De: < / / >,A: < / / >*.         ,.,,,,*.         ..,
    '   ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,Codigo ,,,,,,,,,..........,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
    '   .       (                                                   ,              .                           .                               **************************************************************
    '   .Fecha     Codigo    Documento   NumeroDoc.Cli.      Cliente     Moneda         Condicion     Total a Pagar    Cod Flete       Estado                                                                                                                                    **************************************************************
    '   .                                                     (                                                                                **************************************************************
    '   .   %* ,/, , /..#@ .  **,# @(@ ( .%   /./#.   .*  /(*  .      /, .# / / /.     .* .(* , ..*/ ***  ( *& * /* * /#*                 %    **************************************************************
    '   .   * .  . / /.  % @  #/&,, *. / / **,/,. *   ,# @. #  .,    # . **   (      . ,  #/# # ,*/# (*/ @,// .  /* / //.                   */ **************************************************************
    '   .                                                                    # /                                                               **************************************************************
    '   .                                                                                                                                      **************************************************************
    '   .                                                                                                                                      **************************************************************
    '   .   %* ,/,   /(. %    (  ,  *(   *%.,*/        ,,##  / .     .%, .# / / /.     .* .(* , ..*/ ***  ( *& * /* * /#*                 %    **************************************************************
    '   .   * .  .@/ /. # , ,  *(  ., *.,              *. . (/.      ,/  **   (      .   .* . . /.*@     .,#/    **    */   # .,            */ **************************************************************
    '   .                                                                    # /                                                               **************************************************************
    '   .                                                                                                                                      **************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************
    '   *****************************************************************************************************************************************************************************************************


    '   ,   , (     #/      , ,          &(                                                                                                                                                              #(  
    '   ,                                                                                                                                                                                                    
    ' % # @(.NUEVO, @ ANULAR  (%/ANULAR    /#,&  PREVISUALIZAR /&.,%(  .%(,./.,.  ,,&  %#%%/*.  ,. @#,./ ., /  %  .( **(                                                     SALIR                                                  
    '&&  &&&*&&&&..&&& **&&..*&& /*&&%(%&&&%&&&&( &&&(&&&&.*&&%**%%&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& &&#(&,,&&&&&&&&&  &&
#Region " Variables "
   Private managerTRAN_Cotizaciones As BTRAN_Cotizaciones
   Private managerEntidades As BEntidades
   Private managerFletes As BTRAN_Fletes

   Private bs_pedidos As BindingSource
   Private bs_detPedido As BindingSource

   Private bs_moneda As BindingSource
   Private bs_tipocomprobante As BindingSource
   Private bs_viajesventas As BindingSource

   Private bs_viajesguias As BindingSource
   Private bs_viajesguiasdetalle As BindingSource

   Private m_listBindHelper As List(Of ACBindHelper)

   Private m_modArticulo As Boolean = False
   Private m_opcion As Inicio

   Private _frmViajes As CViajes

   Private m_order As Integer = 1

   Private m_cotiz_codigo As String

   Enum Inicio
      Normal
      Busqueda
   End Enum
#End Region

#Region " Propiedades "

   Public Property TRAN_Cotizaciones() As ETRAN_Cotizaciones
      Get
         Return managerTRAN_Cotizaciones.TRAN_Cotizaciones
      End Get
      Set(ByVal value As ETRAN_Cotizaciones)
         managerTRAN_Cotizaciones.TRAN_Cotizaciones = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      Try
         m_opcion = Inicio.Normal
         Inicializar()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Public Sub New(ByVal x_opcion As Inicio)
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Try
         m_opcion = x_opcion
         Inicializar()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub Inicializar()
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         managerTRAN_Cotizaciones = New BTRAN_Cotizaciones
         managerEntidades = New BEntidades
         managerFletes = New BTRAN_Fletes

         formatearGrilla()
         cargarCombos()
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
         spcCabecera.Panel2Collapsed = True

         Select Case m_opcion
            Case Inicio.Busqueda
               acTool.ACTipoToolBar = ACControles.ACToolBarMantHorizontalNew.tipoToolBar.ToolSalir
               acbtnSeleccionar.Visible = True
               actsbtnPrevisualizar.Visible = True
               Me.WindowState = FormWindowState.Normal
               Me.MaximizeBox = True
               Me.MinimizeBox = False
               Me.StartPosition = FormStartPosition.CenterScreen
               txtBusqueda_ACAyudaClick(Nothing, Nothing)
            Case Inicio.Normal

            Case Else

         End Select
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)

         AcFecha.ACDtpFecha_De.Value = DateTime.Now.AddDays(-1 * DateTime.Now.Day + 1)
         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACGuiaProc_16x16.GetHicon)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Function getCampo() As String
      Try
         If (rbtnCliente.Checked) Then
            Return "ENTID_RazonSocial"
         ElseIf rbtnNroCotizacion.Checked Then
            Return "COTIZ_Codigo"
         Else
            Return "ENTID_RazonSocial"
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function busqueda(ByVal x_cadena As String) As Boolean
      Try
         'If txtBusqueda.ACEstadoAutoAyuda Then
         If managerTRAN_Cotizaciones.Busqueda(x_cadena, getCampo(), chkTodos.Checked, AcFecha.ACDtpFecha_De.Value.Date, AcFecha.ACDtpFecha_A.Value.Date.AddDays(1), GApp.Zona, GApp.Sucursal, GApp.PuntoVenta) Then
            acTool.ACBtnEliminarEnabled = True
            acTool.ACBtnModificarEnabled = True
         Else
            managerTRAN_Cotizaciones.ListTRAN_Cotizaciones = New List(Of ETRAN_Cotizaciones)
            acTool.ACBtnEliminarEnabled = False
            acTool.ACBtnModificarEnabled = False
         End If
         cargarDatos()
         'End If
         Return acTool.ACBtnEliminarEnabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Sub cargarDatos()
      Try
         bs_pedidos = New BindingSource()
         bs_pedidos.DataSource = managerTRAN_Cotizaciones.ListTRAN_Cotizaciones
         c1grdBusqueda.DataSource = bs_pedidos
         bnavBusqueda.BindingSource = bs_pedidos
         AddHandler bs_pedidos.CurrentChanged, AddressOf bs_pedidos_CurrentChanged
         bs_pedidos_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub calcular(Optional ByVal x_moneda As Boolean = False)
      Try
         If Not IsNothing(managerTRAN_Cotizaciones.TRAN_Cotizaciones) Then
            If Not IsNothing(managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle) Then
               If managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle.Count > 0 Then
                  Dim _importeTotal As Decimal = 0
                  Dim _pesoTotal As Decimal = 0
                  Dim _igv As Decimal = Parametros.GetParametro(EParametros.TipoParametros.PIGV)
                  Dim _totalPagar As Decimal = 0
                  Dim _cantidad As Decimal = 0
                  Dim _tipocambio As Decimal = actxnTipoCambio.Text

                  If chkIlncluidoIGV.Checked Then
                     '' Calcular los precios con percepcion
                     '' Calcular totales
                     For Each Item As ETRAN_CotizacionesDetalle In managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle
                        _importeTotal += Math.Round(Item.COTDT_PrecioUnitarioPrecIncIGV * Item.COTDT_Cantidad, 2)
                        _pesoTotal += Item.COTDT_PesoUnitario * Item.COTDT_Cantidad
                        _cantidad += Item.COTDT_Cantidad
                     Next

                     'Dim _importeIgv As Decimal = Math.Round(_importeTotal * (_igv / 100), 2, MidpointRounding.AwayFromZero)
                     'Dim _total As Decimal = Math.Round(_importeTotal + _importeIgv, 2, MidpointRounding.AwayFromZero)
                     Dim _total As Decimal = Math.Round(_importeTotal, 2, MidpointRounding.AwayFromZero)
                     Dim _importeIgv As Decimal = Math.Round(_total / (1 + ((_igv / 100))), 2, MidpointRounding.AwayFromZero)

                     actxnImporte.Text = Math.Round(_importeIgv, 2, MidpointRounding.AwayFromZero) : actxnImporte.Formatear()
                     actxnIGV.Text = _total - _importeIgv : actxnIGV.Formatear()
                     _totalPagar = _total
                     actxnTotalPagar.Text = _totalPagar : actxnTotalPagar.Formatear()
                  Else
                     '' Calcular los precios con percepcion
                     '' Calcular totales
                     For Each Item As ETRAN_CotizacionesDetalle In managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle
                        _importeTotal += Math.Round(Item.COTDT_PrecioUnitario * Item.COTDT_Cantidad, 2, MidpointRounding.AwayFromZero)
                        _pesoTotal += Item.COTDT_PesoUnitario * Item.COTDT_Cantidad
                        _cantidad += Item.COTDT_Cantidad
                     Next

                     'Dim _importeIgv As Decimal = Math.Round(_importeTotal * (_igv / 100), 2, MidpointRounding.AwayFromZero)
                     'Dim _total As Decimal = Math.Round(_importeTotal + _importeIgv, 2, MidpointRounding.AwayFromZero)
                     Dim _total As Decimal = Math.Round(_importeTotal * ((_igv / 100) + 1), 2, MidpointRounding.AwayFromZero)
                     Dim _importeIgv As Decimal = Math.Round(_total - _importeTotal, 2, MidpointRounding.AwayFromZero)

                     actxnImporte.Text = Math.Round(_importeTotal, 2, MidpointRounding.AwayFromZero) : actxnImporte.Formatear()
                     actxnIGV.Text = _importeIgv : actxnIGV.Formatear()
                     _totalPagar = _total
                     actxnTotalPagar.Text = _totalPagar : actxnTotalPagar.Formatear()
                  End If
                  Dim _existe As Boolean
                  If _totalPagar >= Convert.ToDecimal(Parametros.GetParametro("pg_PreLimBoleta", _existe)) Then
                     txtNotaPie.Text = Parametros.GetParametro("pg_FacDetCtaCte", _existe)
                  Else
                     txtNotaPie.Text = ""
                  End If
               End If
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_monedas_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         CambiarMoneda()
         calcular()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

   Private Function Validar(ByRef m_msg As String) As Boolean
      Try
         managerTRAN_Cotizaciones.TRAN_Cotizaciones.TIPOS_CodCondicionPago = ETipos.getCondicionPago(ETipos.TipoPago.Contado)
         Dim _msg As String = ""
         If Not ACUtilitarios.ACDatosOk(pnlCabecera, _msg) Then
            m_msg &= _msg
            Return False
         End If
         '' Validar Detalle
         bs_detPedido.ResetBindings(False)
         ''
         If Not managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle.Count > 0 Then
            m_msg = String.Format("- NO se ha ingresado items para este documento{0}", vbNewLine)
         End If
         '' Valida que la cantidad y el precio es superior a 0
         For Each Item As ETRAN_CotizacionesDetalle In managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle
            If Not Item.COTDT_Cantidad * Item.COTDT_PrecioUnitario > 0 Then
               m_msg &= String.Format("- El Producto tiene como cantidad {0} y el precio {1}, no es aceptable{2}", Item.COTDT_Cantidad, Item.COTDT_PrecioUnitario, vbNewLine)
            End If
         Next
         '' Validar La moneda y el Cliente a Facturar
         Dim _moneda As String = cmbMoneda.SelectedValue
         For Each item As ETRAN_CotizacionesFletes In managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes
            If _moneda <> item.TIPOS_CodTipoMoneda Then
               m_msg &= String.Format("- No hay correlación de tipo de moneda de uno de los Fletes, Moneda de Cotización: {1}, Moneda del Flete: {2}{0}", vbNewLine, _
                                      CType(bs_moneda.Current, ETipos).TIPOS_DescCorta, item.TIPOS_TipoMoneda)
            End If
            If actxaCliRuc.Text <> item.ENTID_NroDocumento Then
               m_msg &= String.Format("- No hay correlación del cliente que se desea Facturar, Cliente Cotización: {1}, Cliente del Flete: {2}{0}", vbNewLine, _
                                      actxaCliRuc.Text, _
                                      item.ENTID_NroDocumento)
            End If
         Next



         '' Verificar si hay pedidos
         Return Not (m_msg.Length > 0)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function addDetalle() As Boolean
      Dim _detDocsVenta As New ETRAN_CotizacionesDetalle
      Try
         Dim _cantidad As Decimal = actxnProdCantidad.Text
         Dim _precio As Decimal = actxnPrecio.Text
         If (_cantidad * _precio) > 0 Then

            _detDocsVenta.COTDT_Cantidad = actxnProdCantidad.Text
            _detDocsVenta.COTDT_Unidad = txtProdUnidad.Text
            _detDocsVenta.COTDT_Item = managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle.Count() + 1

            _detDocsVenta.COTDT_Detalle = txtProdDescripcion.Text

            Dim _igv As Decimal = 1 + (Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100)
            If chkIlncluidoIGV.Checked Then
               _detDocsVenta.COTDT_PrecioUnitarioPrecIncIGV = actxnPrecio.Text
               _detDocsVenta.COTDT_PrecioUnitario = Math.Round(_detDocsVenta.COTDT_PrecioUnitarioPrecIncIGV / _igv, 4, MidpointRounding.AwayFromZero)
               _detDocsVenta.COTDT_SubImporteVenta = _detDocsVenta.COTDT_PrecioUnitarioPrecIncIGV * _detDocsVenta.COTDT_Cantidad
               c1grdDetalle.Cols("COTDT_PrecioUnitario").Visible = False
               c1grdDetalle.Cols("COTDT_PrecioUnitarioPrecIncIGV").Visible = True
            Else
               _detDocsVenta.COTDT_PrecioUnitarioPrecIncIGV = 0
               _detDocsVenta.COTDT_PrecioUnitario = actxnPrecio.Text
               _detDocsVenta.COTDT_SubImporteVenta = _detDocsVenta.COTDT_PrecioUnitario * _detDocsVenta.COTDT_Cantidad
               c1grdDetalle.Cols("COTDT_PrecioUnitario").Visible = True
               c1grdDetalle.Cols("COTDT_PrecioUnitarioPrecIncIGV").Visible = False
            End If
            '' Actualizar contenido
            managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle.Add(_detDocsVenta)
            bs_detPedido.ResetBindings(False)
            calcular()
            c1grdDetalle.AutoSizeRows()
            c1grdDetalle.AutoSizeCols()
            Return True
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede agregar el producto, por la Cantida/Precio es incorrecto, corrija y vuelva a intentarlo ")
            If _detDocsVenta.COTDT_Cantidad = 0 Then
               actxnProdCantidad.Focus()
            ElseIf _detDocsVenta.COTDT_PrecioUnitario = 0 Then
               actxnPrecio.Focus()
            End If
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

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
                     managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo = Ayuda.Respuesta.Rows(0)("Codigo")
                     If Not Ayuda.Respuesta.Rows(0)("Ubigeo") Is DBNull.Value Then
                        managerTRAN_Cotizaciones.TRAN_Cotizaciones.UBIGO_Codigo = Ayuda.Respuesta.Rows(0)("Ubigeo")
                     End If
                     actxaCliRazonSocial.Text = Ayuda.Respuesta.Rows(0)("Razon Social").ToString()
                     actxaCliRuc.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.").ToString()
                     txtDireccion.Text = Ayuda.Respuesta.Rows(0)("Dirección").ToString()

                     '' Cargar datos adicionales cliente
                     ' Cargar Cliente
                     If managerEntidades.Cargar(managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo, EEntidades.TipoInicializacion.Cliente) Then
                        ' Cargar Vendedor
                     End If
                     Dim l_Tipos As New List(Of ETipos)(Colecciones.GetTipos(managerEntidades.Entidades.Cliente.TIPOS_CodTipoPercepcion))
                     Dim pPercepcion As Double
                     If l_Tipos.Count > 0 Then
                        pPercepcion = l_Tipos(0).TIPOS_Numero
                     End If
                     managerEntidades.Entidades.Cliente.Percepcion = pPercepcion
                     pnlItem.Enabled = True
                     calcular()
                     lblMoneda.Focus()
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

   Private Sub NuevoCliente(ByVal x_entid_nrodocumento As String)
      Try
         Dim frmEntidad As New MEntidad(MEntidad.Inicio.NuevaEntidad, ACEVentas.EEntidades.TipoEntidad.Clientes)
         frmEntidad.StartPosition = FormStartPosition.CenterScreen
         If x_entid_nrodocumento.Length > 0 Then
            frmEntidad.EEntidad.ENTID_NroDocumento = x_entid_nrodocumento
            frmEntidad.lblNombres.Focus()
         End If
         If frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            managerEntidades.Entidades = frmEntidad.EEntidad
            managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo = managerEntidades.Entidades.ENTID_Codigo

            Dim l_Tipos As New List(Of ETipos)(Colecciones.GetTipos(managerEntidades.Entidades.Cliente.TIPOS_CodTipoPercepcion))
            Dim pPercepcion As Double
            If l_Tipos.Count > 0 Then
               pPercepcion = l_Tipos(0).TIPOS_Numero
            End If
            managerEntidades.Entidades.Cliente.Percepcion = pPercepcion
            managerEntidades.Entidades = managerEntidades.Entidades
            managerEntidades.Cliente = managerEntidades.Entidades.Cliente
            actxaCliRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
            actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
            txtDireccion.Text = managerEntidades.Entidades.ENTID_Direccion

            pnlItem.Enabled = True
            calcular()
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of ETRAN_Cotizaciones)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_pedidos.DataSource, List(Of ETRAN_Cotizaciones)).Sort(_ordenador)
         c1grdBusqueda.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub SubirItem()
      Try
         If Not IsNothing(bs_detPedido.Current) Then
            '' Cargar Producto
            txtProdDescripcion.Text = CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_Detalle
            actxnProdCantidad.Text = CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_Cantidad
            If chkIlncluidoIGV.Checked Then
               actxnPrecio.Text = CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitarioPrecIncIGV
            Else
               actxnPrecio.Text = CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitario
            End If
            actxnSubImporte.Text = CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_SubImporteVenta
            txtProdUnidad.Text = CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_Unidad
            setProducto(True)
         Else
            setProducto(False)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#Region " Procesos "

   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbDocumento, "SelectedValue", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "TIPOS_CodTipoDocumento"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbMoneda, "SelectedValue", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "TIPOS_CodTipoMoneda"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxnImporte, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_ImporteVenta"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnIGV, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_ImporteIgv"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnTotalPagar, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_TotalPagar"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxnTipoCambio, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_TipoCambio"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnTCVentaSunat, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_TipoCambioSunat"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtNotaPie, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_NotaPie"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtGuia, "Text", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_Guia"))
         m_listBindHelper.Add(ACBindHelper.ACBind(chkIlncluidoIGV, "Checked", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_PrecIncIGV"))

         If managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_FechaDocumento.Year < 1700 Then managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_FechaDocumento = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecFacturacion, "Value", managerTRAN_Cotizaciones.TRAN_Cotizaciones, "COTIZ_FechaDocumento"))

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function nueva() As Boolean
      managerTRAN_Cotizaciones.TRAN_Cotizaciones = New ETRAN_Cotizaciones
      Try
         m_cotiz_codigo = Nothing
         '' Inicializar clase Pedido
         managerTRAN_Cotizaciones.TRAN_Cotizaciones.Instanciar(ACEInstancia.Nuevo)
         managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Ingresado)
         '' Instanciar clase
         AsignarBinding()
         setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)
         '' Obtener el tipo de cambio
         managerTRAN_Cotizaciones.getTipoCambio()
         actxnTipoCambio.Text = managerTRAN_Cotizaciones.TipoCambio.TIPOC_VentaOficina
         actxnTCVentaSunat.Text = managerTRAN_Cotizaciones.TipoCambio.TIPOC_VentaSunat
         '' Para Cargar detalle del producto
         bs_detPedido = New BindingSource

         managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle = New List(Of ETRAN_CotizacionesDetalle)
         bs_detPedido.DataSource = managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle
         c1grdDetalle.DataSource = bs_detPedido
         bnavProductos.BindingSource = bs_detPedido

         bs_viajesventas = New BindingSource
         managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletesLiberados = New List(Of ETRAN_CotizacionesFletes)
         managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes = New List(Of ETRAN_CotizacionesFletes)
         bs_viajesventas.DataSource = managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes
         bnavFletes.BindingSource = bs_viajesventas
         c1grdFletes.DataSource = bs_viajesventas

         tabMantenimiento.SelectedTab = tabDatos : cmbDocumento.Focus()
         cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles)
         spcCabecera.Panel2Collapsed = True
         _frmViajes = Nothing

         cmbDocumento.SelectedIndex = 0

         c1grdGuias.Refresh()
         c1grdEmpresas.Refresh()
         m_modArticulo = False
         Return True
      Catch ex As Exception
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Function

#End Region

#Region " Utilitarios "
   Private Sub setProducto(ByVal x_opcion As Boolean)
      Try
         If x_opcion Then
            txtProdDescripcion.Focus()
         Else
            txtProdDescripcion.Clear()
            actxnProdCantidad.Text = "0.00"
            actxnSubImporte.Text = "0.00"
            actxnPrecio.Text = "0.00"
            txtProdUnidad.Clear()
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub CambiarMoneda()
      Try
         Dim _tipocambio As Double = actxnTipoCambio.Text
         '' Calcular totales
         If IsNothing(managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle.Count > 0) Then
            For Each Item As ETRAN_CotizacionesDetalle In managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle
               If cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
                  Item.COTDT_PrecioUnitario = Item.COTDT_PrecioUnitario * _tipocambio
                  setEtiqueta(ETipos.TipoMoneda.Soles)
               ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
                  Item.COTDT_PrecioUnitario = Item.COTDT_PrecioUnitario / _tipocambio
                  setEtiqueta(ETipos.TipoMoneda.Dolares)
               Else
                  Item.COTDT_PrecioUnitario = Item.COTDT_PrecioUnitario * _tipocambio
                  setEtiqueta(ETipos.TipoMoneda.Soles)
               End If
            Next
         Else
            If cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Soles) Then
               setEtiqueta(ETipos.TipoMoneda.Soles)
            ElseIf cmbMoneda.SelectedValue = ETipos.getTipo(ETipos.TipoMoneda.Dolares) Then
               setEtiqueta(ETipos.TipoMoneda.Dolares)
            Else
               setEtiqueta(ETipos.TipoMoneda.Soles)
            End If
         End If

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setEtiqueta(ByVal x_moneda As ETipos.TipoMoneda)
      Try
         Select Case x_moneda
            Case ETipos.TipoMoneda.Soles
               lbligv.Text = String.Format("I.G.V. : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
               lblImporte.Text = String.Format("Importe : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
               lblTotalPagar.Text = String.Format("Total Pagar : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Soles))
            Case ETipos.TipoMoneda.Dolares
               lbligv.Text = String.Format("I.G.V. : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Dolares))
               lblImporte.Text = String.Format("Importe : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Dolares))
               lblTotalPagar.Text = String.Format("Total Pagar : {0}", ACETransporte.Constantes.Moneda(ETipos.TipoMoneda.Dolares))
            Case Else
               setEtiqueta(ETipos.TipoMoneda.Soles)
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargarCombos()
      Try
         '' Moneda
         bs_moneda = New BindingSource() : bs_moneda.DataSource = Colecciones.Tipos(ETipos.MyTipos.TipoMoneda)
         AddHandler bs_moneda.CurrentChanged, AddressOf bs_monedas_CurrentChanged
         ACUtilitarios.ACCargaCombo(cmbMoneda, bs_moneda, "TIPOS_Descripcion", "TIPOS_Codigo")
         '' Tipo de Documento Comprobante
         ACUtilitarios.ACCargaCombo(cmbDocumento, Colecciones.TiposDocComprobante(), "TIPOS_Descripcion", "TIPOS_Codigo")
         bs_tipocomprobante = New BindingSource
         bs_tipocomprobante.DataSource = Colecciones.Tipos(ETipos.MyTipos.CondicionPago)
         '' Tipos Varios
         ACUtilitarios.ACCargaCombo(cmbEntrega, Colecciones.ListEstadoEntrega, ACLista.Descripcion, ACLista.Codigo)



         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACGuiaProc_16x16.GetHicon)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 13, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "COTIZ_FechaDocumento", "COTIZ_FechaDocumento", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "COTIZ_Codigo", "COTIZ_Codigo", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Documento", "TIPOS_TipoDocumento", "TIPOS_TipoDocumento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro. Doc. Cli.", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cliente", "ENTID_Cliente", "ENTID_Cliente", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Moneda", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Condición", "TIPOS_CondicionPago", "TIPOS_CondicionPago", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Total Pagar", "PEDID_TotalPagar", "PEDID_TotalPagar", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Numero", "COTIZ_Numero", "COTIZ_Numero", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Cod. Flete", "FLETE_Id", "FLETE_Id", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "COTIZ_Estado_Text", "COTIZ_Estado_Text", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "COTIZ_Estado", "COTIZ_Estado", 150, False, False, "System.String") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         'c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue
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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 8, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Id", "COTDT_Item", "COTDT_Item", 110, True, False, "System.Int") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Detalle", "COTDT_Detalle", "COTDT_Detalle", 160, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Unidad", "COTDT_Unidad", "COTDT_Unidad", 160, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Cantidad", "COTDT_Cantidad", "COTDT_Cantidad", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Precio", "COTDT_PrecioUnitario", "COTDT_PrecioUnitario", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Precio", "COTDT_PrecioUnitarioPrecIncIGV", "COTDT_PrecioUnitarioPrecIncIGV", 110, False, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Sub-Importe", "COTDT_SubImporteVenta", "COTDT_SubImporteVenta", 100, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         c1grdDetalle.AllowEditing = False
         c1grdDetalle.AutoResize = True
         c1grdDetalle.Cols(0).Width = 18
         c1grdDetalle.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDetalle.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDetalle.Styles.Highlight.BackColor = Color.Gray
         c1grdDetalle.SelectionMode = SelectionModeEnum.Row
         c1grdDetalle.AllowResizing = AllowResizingEnum.Rows
         'c1grdDetalle.VisualStyle = VisualStyle.Office2007Blue

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdFletes, 1, 1, 10, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Flete", "FLETE_Id", "FLETE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Peso (T.M.)", "FLETE_PesoEnTM", "FLETE_PesoEnTM", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Mon.", "TIPOS_TipoMoneda", "TIPOS_TipoMoneda", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Importe", "FLETE_TotIngreso", "FLETE_TotIngreso", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Viaje", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Descripción", "FLETE_Glosa", "FLETE_Glosa", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Glosa de Viaje", "VIAJE_Descripcion", "VIAJE_Descripcion", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "R.U.C. / Doc.", "ENTID_NroDocumento", "ENTID_NroDocumento", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdFletes, index, "Razon Social", "ENTID_RazonSocial", "ENTID_RazonSocial", 150, True, False, "System.String") : index += 1

         c1grdFletes.AllowEditing = False
         c1grdFletes.AutoResize = True
         c1grdFletes.Cols(0).Width = 18
         c1grdFletes.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdFletes.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdFletes.Styles.Highlight.BackColor = Color.Gray
         c1grdFletes.SelectionMode = SelectionModeEnum.Row
         c1grdFletes.AllowResizing = AllowResizingEnum.Rows
         c1grdFletes.AllowAddNew = False

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdEmpresas, 1, 1, 2, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdEmpresas, index, "Empresa", "Empresa", "Empresa", 250, True, False, "System.String") : index += 1
         c1grdEmpresas.AllowEditing = False
         c1grdEmpresas.AutoResize = True
         c1grdEmpresas.Cols(0).Width = 18
         c1grdEmpresas.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdEmpresas.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdEmpresas.Styles.Highlight.BackColor = Color.Gray
         c1grdEmpresas.SelectionMode = SelectionModeEnum.Row
         c1grdEmpresas.AllowResizing = AllowResizingEnum.Rows
         c1grdEmpresas.AllowAddNew = False

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdGuias, 1, 1, 7, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "X", "Seleccion", "Seleccion", 250, True, True, "System.Boolean") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Tipo", "TIPOS_TipoDocumento", "TIPOS_TipoDocumento", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Serie-Numero", "Documento", "Documento", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Observacion", "VEGRE_Observacion", "VEGRE_Observacion", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Viaje", "VIAJE_Id", "VIAJE_Id", 250, True, False, "System.String", "0000000") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdGuias, index, "Flete", "FLETE_Id", "FLETE_Id", 250, True, False, "System.String", "0000000") : index += 1
         c1grdGuias.AllowEditing = True
         c1grdGuias.AutoResize = True
         c1grdGuias.Cols(0).Width = 18
         c1grdGuias.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdGuias.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdGuias.Styles.Highlight.BackColor = Color.Gray
         c1grdGuias.SelectionMode = SelectionModeEnum.Row
         c1grdGuias.AllowResizing = AllowResizingEnum.Rows
         c1grdGuias.AllowAddNew = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub SetControles(ByVal x_opcion As Boolean)
      cmbDocumento.Enabled = x_opcion

      actxaCliRazonSocial.ACActivarAyuda = x_opcion : actxaCliRazonSocial.ACAyuda.Enabled = x_opcion
      actxaCliRuc.ACActivarAyuda = x_opcion : actxaCliRuc.ACAyuda.Enabled = x_opcion
      cmbDocumento.Enabled = x_opcion

      dtpFecFacturacion.Enabled = x_opcion
      txtNotaPie.Enabled = x_opcion
      pnlItem.Enabled = x_opcion
      pnlPie.Enabled = x_opcion
      pnlCabHeader.Enabled = x_opcion
      chkIlncluidoIGV.Enabled = x_opcion

      btnNuevoCliente.Enabled = x_opcion : btnClean.Enabled = x_opcion
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
      Try
         acTool.ACBtnRehusarVisible = False
         acTool.ACBtnImprimirVisible = False

         Select Case _opcion
            Case ACUtilitarios.ACSetInstancia.Nuevo
               ACUtilitarios.ACLimpiaVar(pnlCabecera)
               ACUtilitarios.ACLimpiaVar(pnlItem)
               ACUtilitarios.ACSetControl(pnlCabecera, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
               ACUtilitarios.ACLimpiaVar(pnlPie)
               SetControles(True)
               acTool.ACBtnImprimirVisible = False
               actsbtnPrevisualizar.Visible = False
               acTool.ACBtnAnularVisible = False
               acTool.ACBtnImprimirEnabled = False
               pnlItem.Enabled = False
               pnlCabHeader.Enabled = True
               acTool.ACBtnImprimirVisible = False
               setEtiqueta(ETipos.TipoMoneda.Soles)
               pnlFlete.Enabled = True
               ToolStrip2.Enabled = True
               grpFlete.Enabled = True
               actxaCotiz.Visible = False
               Label8.Visible = False
               chkIlncluidoIGV.Enabled = True
               spcDetalle.Panel2Collapsed = True
               spcCabecera.Panel2Collapsed = True
               AddHandler c1grdDetalle.KeyDown, AddressOf c1grdDetalle_KeyDown
            Case ACUtilitarios.ACSetInstancia.Modificado

            Case ACUtilitarios.ACSetInstancia.Guardar
               txtBusqueda.Focus()
            Case ACUtilitarios.ACSetInstancia.Deshacer
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               acTool.ACBtnBuscarVisible = False
               actsbtnPrevisualizar.Visible = True
               acTool.ACBtnImprimirVisible = False
               acTool.ACBtnAnularEnabled = False
               tabMantenimiento.SelectedTab = tabBusqueda
               acTool.ACBtnImprimirEnabled = True
               acTool.ACBtnImprimirVisible = False
               pnlItem.Enabled = False
               pnlFlete.Enabled = True
               grpFlete.Enabled = True
            Case ACUtilitarios.ACSetInstancia.Previsualizar
               ACUtilitarios.ACLimpiaVar(pnlItem)
               ACFramework.ACUtilitarios.ACSetControl(grpCabCuerpo, True, ACFramework.ACUtilitarios.TipoPropiedad.ACReadOnly)
               actxaCliRazonSocial.ACAyuda.Enabled = False
               actxaCliRazonSocial.ACActivarAyuda = False
               'acTool.ACBtnImprimirVisible = True
               If CType(bs_pedidos.Current, ETRAN_Cotizaciones).COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Confirmado) Then
                  acTool.ACBtnRehusarVisible = False
               Else
                  acTool.ACBtnRehusarVisible = True
               End If

               acTool.ACBtnAnularEnabled = False
               actxaCliRuc.ACAyuda.Enabled = False
               actxaCliRuc.ACActivarAyuda = False
               pnlCabHeader.Enabled = False
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
               acTool.ACBtnImprimirVisible = True
               acTool.ACBtnGrabarVisible = False
               actsbtnPrevisualizar.Visible = False
               chkIlncluidoIGV.Enabled = False
               SetControles(False)
               pnlItem.Enabled = False
               pnlFlete.Enabled = True
               ToolStrip2.Enabled = False
               grpFlete.Enabled = False
               actxaCotiz.Visible = True
               Label8.Visible = True
               RemoveHandler c1grdDetalle.KeyDown, AddressOf c1grdDetalle_KeyDown
         End Select
         acTool.ACBtnModificarVisible = False
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#End Region

#Region " Metodos de Controles"

   Private Sub btnNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         NuevoCliente("")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nuevo Cliente", ex)
      End Try
   End Sub

   Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo = ""
         managerEntidades.Entidades = New EEntidades
         actxaCliRazonSocial.Clear()
         actxaCliRuc.Clear()
         txtDireccion.Clear()
         pnlItem.Enabled = False
         actxaCliRuc.Focus()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Limpiar Entidad", ex)
      End Try
   End Sub

   Private Sub actxnProdCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles actxnProdCantidad.LostFocus
      Try
         Dim _cantidad As Decimal = actxnProdCantidad.Text
         Dim _importe As Decimal = actxnPrecio.Text
         actxnSubImporte.Text = _cantidad * _importe : actxnSubImporte.Formatear()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso calcular Sub-Importe", ex)
      End Try
   End Sub

   Private Sub actxnPrecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles actxnPrecio.LostFocus
      Try
         Dim _cantidad As Decimal = actxnProdCantidad.Text
         Dim _importe As Decimal = actxnPrecio.Text
         actxnSubImporte.Text = _cantidad * _importe : actxnSubImporte.Formatear()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso calcular Sub-Importe", ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         txtBusqueda_ACAyudaClick(Nothing, Nothing)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede realizar la consulta", ex)
      End Try
   End Sub

   Private Function cargar(ByVal x_codigo As String) As Boolean
      Try
         If managerTRAN_Cotizaciones.Cargar(x_codigo, True) Then
            '' Setear Valores
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Previsualizar)
            '' Cargar
            AsignarBinding()
            bs_detPedido = New BindingSource()
            bs_detPedido.DataSource = managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle
            c1grdDetalle.DataSource = bs_detPedido
            bnavProductos.BindingSource = bs_detPedido

            If managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_PrecIncIGV Then
               c1grdDetalle.Cols("COTDT_PrecioUnitario").Visible = False
               c1grdDetalle.Cols("COTDT_PrecioUnitarioPrecIncIGV").Visible = True
            Else
               c1grdDetalle.Cols("COTDT_PrecioUnitario").Visible = True
               c1grdDetalle.Cols("COTDT_PrecioUnitarioPrecIncIGV").Visible = False
            End If

            tabMantenimiento.SelectedTab = tabDatos
            '' Cargar Cliente
            actxaCliRuc.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_NroDocumento
            setCliente()
            '' Cargar Docmento
            cmbDocumento.SelectedValue = managerTRAN_Cotizaciones.TRAN_Cotizaciones.TIPOS_CodTipoDocumento
            txtDireccion.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionCliente
            '' Cargar Fletes
            bs_viajesventas = New BindingSource
            bs_viajesventas.DataSource = managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes
            c1grdFletes.DataSource = bs_viajesventas
            bnavFletes.BindingSource = bs_viajesventas
            spcCabecera.Panel2Collapsed = False
            If managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes.Count > 0 Then
               actxaFlete.Text = managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes(0).FLETE_Id
               actxaFleteDesc.Text = managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes(0).FLETE_Glosa
            End If

            actxaCotiz.Text = managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo
            spcDetalle.Panel2Collapsed = False
            CargarGuias()
            c1grdDetalle.AutoSizeRows()
            c1grdDetalle.AutoSizeCols()
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 2, "Total")
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 4, "Total")
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub acbtnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acbtnSeleccionar.Click
      Try
         If Not IsNothing(bs_pedidos) Then
            If Not IsNothing(bs_pedidos.Current) Then
               If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Seleccionar Registro: {0}", Me.Text) _
                   , String.Format("Desea seleccionar el registro con codigo: {0}? ", CType(bs_pedidos.Current, ETRAN_Cotizaciones).COTIZ_Codigo) _
                   , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                  managerTRAN_Cotizaciones.TRAN_Cotizaciones = CType(bs_pedidos.Current, ETRAN_Cotizaciones)
                  Me.DialogResult = Windows.Forms.DialogResult.OK
               End If
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede seleccionar una orden, debe seleccionar un registro")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede seleccionar una orden, debe cargar algunr egistro ")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en seleccionarr orden de compra", ex)
      End Try
   End Sub

   Private Sub txtGuia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyData = Keys.Enter Then
         Me.KeyPreview = False
         acTool.Focus()
         acTool.ACBtnGrabar.Select()
      End If
   End Sub

   Private Sub actxaFlete_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaFlete.ACAyudaClick, actxaFleteDesc.ACAyudaClick
      Try
         Dim _frm As New CFletes("", CFletes.TAyuda.RazonSocial) With {.StartPosition = FormStartPosition.CenterScreen}
         If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            actxaFlete.Text = _frm.TRAN_Fletes.FLETE_Id

            spcCabecera.Panel2Collapsed = False
            spcDetalle.Panel2Collapsed = False

            '' Cargar los detalles del flete
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner, _
                                 New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")}, _
                                 New ACCampos() {New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
            Dim _where As New Hashtable()
            _where.Add("FLETE_Id", New ACWhere(_frm.TRAN_Fletes.FLETE_Id))
            If managerFletes.Cargar(_join, _where) Then
               actxaFleteDesc.Text = managerFletes.TRAN_Fletes.FLETE_Glosa
               actxaCliRuc.Text = managerFletes.TRAN_Fletes.ENTID_NroDocumento

               actxnProdCantidad.Text = managerFletes.TRAN_Fletes.FLETE_PesoEnTM

               txtProdUnidad.Text = "T.M."
               txtProdDescripcion.Text = managerFletes.TRAN_Fletes.FLETE_Glosa
               If managerFletes.TRAN_Fletes.FLETE_ImporteIgv = 0 Then
                  actxnPrecio.Text = Math.Round(managerFletes.TRAN_Fletes.FLETE_MontoPorTM / (Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100 + 1), 4)
               Else
                  actxnPrecio.Text = managerFletes.TRAN_Fletes.FLETE_MontoPorTM
               End If

               actxnPrecio_LostFocus(Nothing, Nothing)
               cmbMoneda.SelectedValue = managerFletes.TRAN_Fletes.TIPOS_CodTipoMoneda
               cmbEntrega.SelectedIndex = 0
               setCliente()

               managerTRAN_Cotizaciones.TRAN_Cotizaciones.FLETE_Id = managerFletes.TRAN_Fletes.FLETE_Id
               managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id = managerFletes.TRAN_Fletes.RUTAS_Id

               Dim _filter As New ACFiltrador(Of ETRAN_CotizacionesFletes)(String.Format("FLETE_Id={0}", managerFletes.TRAN_Fletes.FLETE_Id))
               If Not _filter.ACFiltrar(managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes).Count > 0 Then
                  Dim _cfletes As New ETRAN_CotizacionesFletes
                  _cfletes.FLETE_Id = managerFletes.TRAN_Fletes.FLETE_Id
                  _cfletes.FLETE_Glosa = managerFletes.TRAN_Fletes.FLETE_Glosa
                  _cfletes.VIAJE_Id = managerFletes.TRAN_Fletes.VIAJE_Id
                  _cfletes.VIAJE_Descripcion = _frm.TRAN_Fletes.VIAJE_Descripcion
                  _cfletes.ENTID_RazonSocial = _frm.TRAN_Fletes.ENTID_RazonSocial
                  _cfletes.FLETE_TotIngreso = managerFletes.TRAN_Fletes.FLETE_TotIngreso
                  _cfletes.FLETE_PesoEnTM = managerFletes.TRAN_Fletes.FLETE_PesoEnTM
                  _cfletes.TIPOS_TipoMoneda = _frm.TRAN_Fletes.TIPOS_TipoMoneda
                  _cfletes.TIPOS_CodTipoMoneda = managerFletes.TRAN_Fletes.TIPOS_CodTipoMoneda
                  _cfletes.ENTID_NroDocumento = managerFletes.TRAN_Fletes.ENTID_NroDocumento
                  managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes.Add(_cfletes)
               End If
               bs_viajesventas.ResetBindings(False)
               pnlItem.Enabled = True
               '' Cargar los Guias por Fletes
               CargarGuias()
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar Flete"), ex)
      End Try
   End Sub

   Private Sub AcFecha_ACFecIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecIni_KeyDown
      If e.KeyData = Keys.Enter Then
         AcFecha.ACDtpFecha_A.Focus()
      End If
   End Sub

   Private Sub AcFecha_ACFecFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecFin_KeyDown
      If e.KeyData = Keys.Enter Then
         btnConsultar_Click(Nothing, Nothing)
      End If
   End Sub

#Region " Ayudas "
   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs)
      Try
         busqueda(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la Busqueda", ex)
      End Try
   End Sub

#End Region

#Region " Ayuda para Cliente "

   Private Sub setCliente()
      Try
         If managerEntidades.CargarDocIden(actxaCliRuc.Text, EEntidades.TipoInicializacion.Cliente) Then
            '' Cargar datos del cliente
            managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Codigo = managerEntidades.Entidades.ENTID_Codigo
            Dim l_Tipos As New List(Of ETipos)(Colecciones.GetTipos(managerEntidades.Entidades.Cliente.TIPOS_CodTipoPercepcion))
            Dim pPercepcion As Double
            If l_Tipos.Count > 0 Then
               pPercepcion = l_Tipos(0).TIPOS_Numero
            End If
            managerEntidades.Entidades.Cliente.Percepcion = pPercepcion

            actxaCliRazonSocial.Text = managerEntidades.Entidades.ENTID_RazonSocial
            actxaCliRuc.Text = managerEntidades.Entidades.ENTID_NroDocumento
            txtDireccion.Text = managerEntidades.Entidades.Direccion
            calcular()
            lblMoneda.Focus()
         Else
            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                            , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaCliRuc.Text) _
                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
               NuevoCliente(actxaCliRuc.Text)
               lblMoneda.Focus()
            Else
               btnClean_Click(Nothing, Nothing)
               lblNroDocumento.Focus()
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub actxaCliRuc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaCliRuc.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaCliRuc.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaCliRuc.ACAyuda.Enabled = True Then
                  setCliente()
                  pnlItem.Enabled = True
               End If
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

   Private Sub actxaCliRazonSocial_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliRazonSocial.ACAyudaClick
      Try
         AyudaEntidad(actxaCliRazonSocial.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Clientes)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso busqueda de cliente por Nombre/Razon Social", ex)
      End Try
   End Sub

   Private Sub actxaCliRuc_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCliRuc.ACAyudaClick
      Try
         AyudaEntidad(actxaCliRuc.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Clientes)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Documento de Identidad", ex)
      End Try
   End Sub

#End Region

#Region " BindingSource "
   Private Sub bs_pedidos_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_pedidos.Current) Then
            If CType(bs_pedidos.Current, ETRAN_Cotizaciones).COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Confirmado) Then
               acTool.ACBtnModificarEnabled = False
               acTool.ACBtnAnularEnabled = False
               acbtnSeleccionar.Enabled = False
            ElseIf CType(bs_pedidos.Current, ETRAN_Cotizaciones).COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Anulado) Then
               acbtnSeleccionar.Enabled = False
               acTool.ACBtnAnularEnabled = False
               acTool.ACBtnModificarEnabled = False
            Else
               acTool.ACBtnModificarEnabled = True
               acTool.ACBtnAnularEnabled = True
               acbtnSeleccionar.Enabled = True
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Propiedades del Cotización/Pedido", ex)
      End Try
   End Sub
#End Region

#Region " ToolBox "
   Private Sub acTool_ACBtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnAnular_Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Documento de Venta: {0}", Me.Text) _
             , String.Format("Desea anular el documento: ", CType(bs_pedidos.Current, ETRAN_Cotizaciones).COTIZ_Codigo) _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            If managerTRAN_Cotizaciones.AnularDocumento(CType(bs_pedidos.Current, ETRAN_Cotizaciones).COTIZ_Codigo, GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Anulado satisfactoriamente")
               btnConsultar_Click(Nothing, Nothing)
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede anular el documento")
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso anular factura", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnCancelar_Click
      setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim m_msg As String = ""
      Try
         If Not IsNothing(managerTRAN_Cotizaciones.TRAN_Cotizaciones) Then
            If Validar(m_msg) Then
               managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Cliente = actxaCliRazonSocial.Text
               If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Generar Cotización: {0}", Me.Text) _
                            , String.Format("¿Generar cotización del cliente: {1}? ", cmbDocumento.Text, managerTRAN_Cotizaciones.TRAN_Cotizaciones.ENTID_Cliente) _
                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                  managerTRAN_Cotizaciones.TRAN_Cotizaciones.ZONAS_Codigo = GApp.Zona
                  managerTRAN_Cotizaciones.TRAN_Cotizaciones.SUCUR_Id = GApp.Sucursal
                  managerTRAN_Cotizaciones.TRAN_Cotizaciones.PVENT_Id = GApp.PuntoVenta
                  managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_TotalPagar = actxnTotalPagar.Text
                  managerTRAN_Cotizaciones.TRAN_Cotizaciones.TIPOS_CodTipoDocumento = cmbDocumento.SelectedValue
                  managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionCliente = txtDireccion.Text
                  '' Generar documento de Venta
                  If managerTRAN_Cotizaciones.GenerarCotizacion(GApp.Usuario, m_msg, True) Then
                     '' Imprimir
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Cotización para generar el documento: {0}, fue genereado satisfactiramente", cmbDocumento.Text), m_msg)
                     If Not IsNothing(m_cotiz_codigo) Then managerTRAN_Cotizaciones.AnularDocumento(m_cotiz_codigo, GApp.Usuario)
                     setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
                     btnConsultar_Click(Nothing, Nothing)
                  Else
                     acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
                     ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede grabar la Cotización, revise los detalles", m_msg)
                  End If
               End If
                  Else
                     acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
                     ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Grabar la Cotización, revise los detalles", m_msg)
                  End If
               Else
                  acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede grabar la Cotización, revise los detalles", m_msg)
               End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Generar la Cotización", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnImprimir_Click
      Try
         Dim ptimp As New PImpresion(managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Codigo) With {.StartPosition = FormStartPosition.CenterScreen, .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog}
         ptimp.ShowDialog()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Imprimir Guia", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         nueva()
         '' Activar las opciones generales del teclado
         KeyPreview = True

         '' Campos Obligatorios
         'txtCodigo.Focus()
         eprError.SetError(Me.cmbDocumento, "Campo Obligatorio")
         eprError.SetError(Me.actxaCliRuc, "Campo Obligatorio")
         eprError.SetError(Me.actxaCliRazonSocial, "Campo Obligatorio")
         Me.KeyPreview = True

      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nueva Factura", ex)
      End Try
   End Sub

   Private Sub txtOpcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpcion.KeyPress
      Try
         Select Case e.KeyChar
            Case "+"c
               If m_modArticulo Then
                  e.Handled = True
                  CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_Cantidad = actxnProdCantidad.Text
                  CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_Unidad = txtProdUnidad.Text

                  Dim _igv As Decimal = 1 + (Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100)
                  If chkIlncluidoIGV.Checked Then
                     CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitarioPrecIncIGV = actxnPrecio.Text
                     CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitario = Math.Round(CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitarioPrecIncIGV / _igv, 4, MidpointRounding.AwayFromZero)
                     c1grdDetalle.Cols("COTDT_PrecioUnitario").Visible = False
                     c1grdDetalle.Cols("COTDT_PrecioUnitarioPrecIncIGV").Visible = True
                  Else
                     CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitarioPrecIncIGV = 0
                     CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitario = actxnPrecio.Text
                     c1grdDetalle.Cols("COTDT_PrecioUnitario").Visible = True
                     c1grdDetalle.Cols("COTDT_PrecioUnitarioPrecIncIGV").Visible = False
                  End If

                  CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_SubImporteVenta = actxnSubImporte.Text
                  CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_Detalle = txtProdDescripcion.Text
                  setProducto(False)
                  calcular()
                  c1grdDetalle.Enabled = True
                  Me.KeyPreview = False
                  m_modArticulo = False
                  c1grdDetalle.AutoSizeCols()
                  c1grdDetalle.AutoSizeRows()
               Else
                  e.Handled = True
                  If addDetalle() Then
                     lblCantidad.Focus()
                     txtOpcion.Text = ""
                     txtOpcion.SelectAll()
                     setProducto(False)
                  End If
               End If
            Case "-"c
               e.Handled = True
            Case Else
               e.Handled = True
         End Select
         c1grdDetalle.AutoSizeRows()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso opciones", ex)
      End Try
   End Sub

   Private Sub txtOpcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOpcion.KeyDown
      Try
         Select Case e.KeyData
            Case Keys.Enter
               If m_modArticulo Then
                  e.Handled = True
                  CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_Cantidad = actxnProdCantidad.Text
                  CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_Unidad = txtProdUnidad.Text

                  Dim _igv As Decimal = 1 + (Parametros.GetParametro(EParametros.TipoParametros.PIGV) / 100)
                  If chkIlncluidoIGV.Checked Then
                     CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitarioPrecIncIGV = actxnPrecio.Text
                     CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitario = Math.Round(CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitarioPrecIncIGV / _igv, 4, MidpointRounding.AwayFromZero)
                     c1grdDetalle.Cols("COTDT_PrecioUnitario").Visible = False
                     c1grdDetalle.Cols("COTDT_PrecioUnitarioPrecIncIGV").Visible = True
                  Else
                     CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitarioPrecIncIGV = 0
                     CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_PrecioUnitario = actxnPrecio.Text
                     c1grdDetalle.Cols("COTDT_PrecioUnitario").Visible = True
                     c1grdDetalle.Cols("COTDT_PrecioUnitarioPrecIncIGV").Visible = False
                  End If

                  CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_SubImporteVenta = actxnSubImporte.Text
                  CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle).COTDT_Detalle = txtProdDescripcion.Text
                  setProducto(False)
                  calcular()
                  c1grdDetalle.Enabled = True
                  Me.KeyPreview = False
                  m_modArticulo = False
                  Label11.Focus()
                  Me.KeyPreview = True
               Else
                  addDetalle()
                  setProducto(False)
                  Label11.Focus()
                  Me.KeyPreview = True
               End If
            Case Keys.Escape
               setProducto(False)
               c1grdDetalle.Enabled = True
               Me.KeyPreview = False
            Case Else

         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede procesar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnRehusar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnRehusar_Click
      Try
         SetControles(True)
         m_cotiz_codigo = CType(bs_pedidos.Current, ETRAN_Cotizaciones).COTIZ_Codigo
         ACUtilitarios.ACSetControl(pnlCabecera, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         acTool.ACBtnRehusarVisible = False
         managerTRAN_Cotizaciones.TRAN_Cotizaciones.Instanciar(ACEInstancia.Nuevo)
         managerTRAN_Cotizaciones.TRAN_Cotizaciones.COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Ingresado)
         acTool.ACBtnImprimirEnabled = False
         pnlItem.Enabled = True
         pnlFlete.Enabled = True
         ToolStrip2.Enabled = True
         grpFlete.Enabled = True
         managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletesLiberados = New List(Of ETRAN_CotizacionesFletes)
         AddHandler c1grdDetalle.KeyDown, AddressOf c1grdDetalle_KeyDown
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error habilitando los controles para rehusar el documento", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub actsbtnPrevisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actsbtnPrevisualizar.Click
      Try
         If Not IsNothing(bs_pedidos) Then
            If Not IsNothing(bs_pedidos.Current) Then
               '' Codigo
               Dim x_codigo As String = CType(bs_pedidos.Current, ETRAN_Cotizaciones).COTIZ_Codigo
               If Not cargar(x_codigo) Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro")
               End If
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede por que no se ha seleccionado ningun registro")
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede continuar por que no se ha cargado ningun registro ")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso previsualizar", ex)
      End Try
   End Sub
#End Region

#Region " Grillas "
   Private Sub c1grdBusqueda_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdBusqueda.BeforeSort
      Try
         Ordenar(c1grdBusqueda.Cols(e.Col).UserData)
         c1grdBusqueda.Subtotal(AggregateEnum.Clear)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub

   Private Sub c1grdBusqueda_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles c1grdBusqueda.OwnerDrawCell
      Try
         If e.Row < c1grdBusqueda.Rows.Fixed OrElse e.Col < c1grdBusqueda.Cols.Fixed Then Return
         If c1grdBusqueda.Rows(e.Row)("COTIZ_Estado") = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado) Then
            e.Style = c1grdBusqueda.Styles("Anulado")
         End If
         If c1grdBusqueda.Rows(e.Row)("COTIZ_Estado") = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Confirmado) Then
            e.Style = c1grdBusqueda.Styles("Facturado")
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

   Private Sub c1grdDetalle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1grdDetalle.GotFocus
      Me.KeyPreview = False
   End Sub

   Private Sub c1grdDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1grdDetalle.KeyDown
      Try
         Select Case e.KeyCode
            Case Keys.Delete
               If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
                   , String.Format("¿Desea quitar el Registro Seleccionado?") _
                   , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                  Dim m_det As ETRAN_CotizacionesDetalle = CType(bs_detPedido.Current, ETRAN_CotizacionesDetalle)
                  managerTRAN_Cotizaciones.TRAN_Cotizaciones.ListTRAN_CotizacionesDetalle.Remove(m_det)
                  bs_detPedido.ResetBindings(False)
                  calcular()
               End If
            Case Keys.Enter
               e.SuppressKeyPress = True
               SubirItem()
               'SendKeys.Send("{F4}")
               c1grdDetalle.Enabled = False
               lblCantidad.Focus()
               m_modArticulo = True
            Case Else
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede calcular carga el Item", ex)
      End Try
   End Sub

   Private Sub c1grdDetalle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1grdDetalle.LostFocus
      'Me.KeyPreview = True
   End Sub

   Private Sub c1grdBusqueda_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdBusqueda.DoubleClick
      actsbtnPrevisualizar_Click(Nothing, Nothing)
   End Sub

#End Region

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         If TypeOf ActiveControl Is ACControles.ACTextBoxAyuda And ActiveControl.Name = "actxaProdCodigo" Then
            Exit Sub
         End If
         If ActiveControl.Name = "txtProdDescripcion" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub

   Private Sub txtProdDescripcion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProdDescripcion.GotFocus
      Me.KeyPreview = False
   End Sub

   Private Sub txtProdDescripcion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProdDescripcion.LostFocus
      Me.KeyPreview = True
   End Sub
#End Region
   Private Sub CargarGuias()
      Try
         Dim _cadenas As String = ""

         For Each item As ETRAN_CotizacionesFletes In managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes
            _cadenas &= String.Format("{0},", item.FLETE_Id)
         Next
         _cadenas = _cadenas.Substring(0, _cadenas.Length - 1)
         bs_viajesguias = New BindingSource
         If Not managerTRAN_Cotizaciones.ObtenerGuias(_cadenas) Then
            managerTRAN_Cotizaciones.ListTRAN_ViajesGuiasRemision = New List(Of ETRAN_ViajesGuiasRemision)
         End If
         If managerTRAN_Cotizaciones.ListTRAN_ViajesGuiasRemision.Count > 0 Then
            bs_viajesguias.DataSource = managerTRAN_Cotizaciones.ListTRAN_ViajesGuiasRemision
            c1grdEmpresas.DataSource = bs_viajesguias
            AddHandler bs_viajesguias.CurrentChanged, AddressOf bs_viajesguias_CurrentChanged
            bs_viajesguias_CurrentChanged(Nothing, Nothing)
         Else
            spcDetalle.Panel2Collapsed = True
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub tsbtnAddFletes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAddFletes.Click
      Try
         If IsNothing(_frmViajes) Then _frmViajes = New CViajes With {.WindowState = FormWindowState.Normal, .StartPosition = FormStartPosition.CenterScreen}
         If _frmViajes.ShowDialog() = Windows.Forms.DialogResult.OK Then


            For Each item As ETRAN_Fletes In _frmViajes.TRAN_Viajes.ListTRAN_Fletes
               Dim _filter As New ACFiltrador(Of ETRAN_CotizacionesFletes)(String.Format("FLETE_Id={0}", item.FLETE_Id))
               If Not _filter.ACFiltrar(managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes).Count > 0 Then
                  Dim _cfletes As New ETRAN_CotizacionesFletes
                  _cfletes.VIAJE_Id = item.VIAJE_Id
                  _cfletes.FLETE_Id = item.FLETE_Id
                  _cfletes.ENTID_RazonSocial = item.ENTID_RazonSocial
                  _cfletes.FLETE_Glosa = item.FLETE_Glosa
                  _cfletes.FLETE_TotIngreso = item.FLETE_TotIngreso
                  _cfletes.FLETE_PesoEnTM = item.FLETE_PesoEnTM
                  _cfletes.TIPOS_CodTipoMoneda = item.TIPOS_CodTipoMoneda
                  _cfletes.TIPOS_TipoMoneda = item.TIPOS_TipoMoneda
                  _cfletes.VIAJE_Descripcion = _frmViajes.TRAN_Viajes.VIAJE_Descripcion
                  _cfletes.ENTID_NroDocumento = item.ENTID_NroDocumento

                  managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes.Add(_cfletes)
               End If
            Next
           
            '' Cargar los Guias por Fletes
            CargarGuias()

            bs_viajesventas.ResetBindings(False)
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 2, "Total")
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 4, "Total")
            If managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes.Count = 1 Then
               managerTRAN_Cotizaciones.TRAN_Cotizaciones.FLETE_Id = _frmViajes.TRAN_Viajes.ListTRAN_Fletes(0).FLETE_Id
               managerTRAN_Cotizaciones.TRAN_Cotizaciones.RUTAS_Id = _frmViajes.TRAN_Viajes.ListTRAN_Fletes(0).RUTAS_Id
               actxaFlete.Text = _frmViajes.TRAN_Viajes.ListTRAN_Fletes(0).FLETE_Id
               actxaFleteDesc.Text = _frmViajes.TRAN_Viajes.ListTRAN_Fletes(0).FLETE_Glosa
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Seleccionar Viaje/Flete"), ex)
      End Try
   End Sub

   Private Sub bs_viajesguias_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         bs_viajesguiasdetalle = New BindingSource
         If Not IsNothing(bs_viajesguias) Then
            bs_viajesguiasdetalle.DataSource = CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).ListETRAN_ViajesGuiasRemision
            c1grdGuias.DataSource = bs_viajesguiasdetalle
            bnavGuias.BindingSource = bs_viajesguiasdetalle
            tsbtnGenerar_Click(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cambiar Empresa", ex)
      End Try
   End Sub

   Private Sub tsbtnQuitarFletes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnQuitarFletes.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Eliminar Registro: {0}", Me.Text) _
                      , String.Format("Desea eliminar el registro del Flete: {0}", CType(bs_viajesventas.Current, ETRAN_CotizacionesFletes).FLETE_Id) _
                      , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletesLiberados.Add(CType(bs_viajesventas.Current, ETRAN_CotizacionesFletes).Clone)
            managerTRAN_Cotizaciones.ListTRAN_CotizacionesFletes.Remove(CType(bs_viajesventas.Current, ETRAN_CotizacionesFletes))
            bs_viajesventas.ResetBindings(False)
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 2, "Total")
            c1grdFletes.Subtotal(AggregateEnum.Sum, 0, -1, 4, "Total")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Quitar Fletes"), ex)
      End Try
   End Sub

   Private Sub btnMas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMas.Click
      txtProdDescripcion.Font = New Font(txtProdDescripcion.Font.FontFamily, txtProdDescripcion.Font.Size + 1)
   End Sub

   Private Sub btnMenos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenos.Click
      txtProdDescripcion.Font = New Font(txtProdDescripcion.Font.FontFamily, txtProdDescripcion.Font.Size - 1)
   End Sub

   Private Sub mmm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaFlete.TextChanged

   End Sub

   Private Sub tsbtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGenerar.Click
      Try
         Dim _cadena As String = ""
         Dim _serie As String = ""
         If CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).ListETRAN_ViajesGuiasRemision.Count > 0 Then
            _serie = CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).ListETRAN_ViajesGuiasRemision(0).Serie
            _cadena = String.Format("Guias de {0}: {1}-", CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).Empresa, _serie)
            Dim i As Integer = 0
            For Each item As ETRAN_ViajesGuiasRemision In CType(bs_viajesguias.Current, ETRAN_ViajesGuiasRemision).ListETRAN_ViajesGuiasRemision
               If item.Seleccion Then
                  If _serie = item.Serie Then
                     If i = 0 Then
                        _cadena &= String.Format("{0},", item.Numero_text)
                     Else
                        _cadena &= String.Format(" {0},", item.Numero_text)
                     End If
                     i += 1
                  Else
                     _serie = item.Serie
                     _cadena &= String.Format(" {0}-{1}", _serie, item.Numero_text)
                  End If
               End If
            Next
            txtTexto.Text = _cadena.Substring(0, _cadena.Length - 1) & "."
         Else
            txtTexto.Text = ""
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Generar Texto Glosa"), ex)
      End Try
   End Sub

    Private Sub PCotizacionesFletes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
