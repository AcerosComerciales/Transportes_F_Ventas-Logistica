Imports System.Text.RegularExpressions
Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports ACEVentas
Imports ACBVentas

Imports C1.Win.C1FlexGrid
'formulario GUIA TRANSPORTISTA 


Public Class PGuiaRemiTransportista

#Region " Variables "
   Private managerVENT_PVentDocumento As BVENT_PVentDocumento
   Private managerEntidades As BEntidades
   Private managerTRAN_Vehiculos As BTRAN_Vehiculos
    Private managerConsultaArticulos As BConsultaArticulos 'Este es el Objeto encargado de Llamar a los datos de la BDAcerosComer
    Private managerGenerarGuias As ACBTransporte.BGenerarGuias

   Private m_listSalDep As List(Of EUbigeos) : Private m_listDesDep As List(Of EUbigeos)
   Private bs_SalDep As BindingSource : Private bs_DesDep As BindingSource
   Private m_listSalPro As List(Of EUbigeos) : Private m_listDesPro As List(Of EUbigeos)
   Private bs_SalPro As BindingSource : Private bs_DesPro As BindingSource
   Private m_listSalDis As List(Of EUbigeos) : Private m_listDesDis As List(Of EUbigeos)
   Private bs_SalDis As BindingSource : Private bs_DesDis As BindingSource

   Private bs_almacenesOrigen As BindingSource
   Private bs_almacenesDestino As BindingSource
   Private bs_etran_guiastransportistadetalle As BindingSource
   Private bs_puntoventa As BindingSource
   Private bs_etran_guiastransportista As BindingSource
   Private bs_series As BindingSource
   Private bs_dirorigen As BindingSource
   Private bs_dirdestino As BindingSource
   Private bs_tipodocumento As BindingSource

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_earticulos As EArticulos
   Private m_etran_guiastransportista As ETRAN_GuiasTransportista

   Private frmCons As CProductos

    Private m_order As Integer = 1

    Private m_modArticulo As Boolean = False

   Enum TEnvio
      Remitente
      Destinatario
   End Enum

   Enum TGuia
      Remitente
      Transportista
   End Enum

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         Inicializacion()
         acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Guia de Traslado Interno - Salida por Transferencia")

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Private Sub Inicializacion()
      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda

         managerEntidades = New BEntidades
         managerTRAN_Vehiculos = New BTRAN_Vehiculos
         managerGenerarGuias = New ACBTransporte.BGenerarGuias
         managerVENT_PVentDocumento = New BVENT_PVentDocumento
         managerConsultaArticulos = New BConsultaArticulos(GApp.Periodo)

         formatearGrilla()
         cargarCombos()

         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)

         btnModConductor.Enabled = False
         btnModificar.Enabled = False
         Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACGuiaProc_16x16.GetHicon)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Procesos "
    'codigo nueva GUIA--FRANK

    Private Function nuevaGuia() As Boolean
      Try
         '' Cargar los detalles del producto
         m_etran_guiastransportista = New ETRAN_GuiasTransportista
         m_etran_guiastransportista.Instanciar(ACEInstancia.Nuevo)
         m_etran_guiastransportista.GTRAN_Estado = ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Ingresado)
         setInstancia(ACUtilitarios.ACSetInstancia.Nuevo)

         AsignarBinding()
         '' Cargar direcciones destino
         m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles = New List(Of ETRAN_GuiasTransportistaDetalles)
         bs_etran_guiastransportistadetalle = New BindingSource
         bs_etran_guiastransportistadetalle.DataSource = m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles
         bnavProductos.BindingSource = bs_etran_guiastransportistadetalle
         c1grdDetalle.DataSource = bs_etran_guiastransportistadetalle
         '' Obtener el numero de serie y de guia correspondiente
         bs_series_CurrentChanged(Nothing, Nothing)
         cmbGuia.SelectedValue = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionTransportista)
         '' Dar la instancia de los controles de la interfaz segun el proceso
         tabMantenimiento.SelectedTab = tabDatos
         bs_almacenOrigen_CurrentChanged(Nothing, Nothing)
         'txtAlmaDirDestino.Clear()

            'cmbDirDestino.SelectedValue = GApp.ESucursal.SUCUR_Direccion
         'bs_almacenesDestino_CurrentChanged(Nothing, Nothing)
         'cmbDestinoDepartamento.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo.Substring(0, 2)
         'cmbDestinoProvincia.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo.Substring(0, 5)
         'cmbDestinoDistrito.SelectedValue = CType(cmbDirDestino.SelectedItem, ESucursales).UBIGO_Codigo

         Label23.Focus()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos "
   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of ETRAN_GuiasTransportista)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_etran_guiastransportista.DataSource, List(Of ETRAN_GuiasTransportista)).Sort(_ordenador)
         c1grdBusqueda.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
    End Sub
    Private Sub subirItem()
        Try
            If IsNothing(CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).Articulo) Then
                actxaProdCodigo.Text = CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).ARTIC_Codigo
                txtProdDescripcion.Text = CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Descripcion
                actxnProdPeso.Text = CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Peso
                actxnProdCantidad.Text = CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Cantidad
            Else
                m_earticulos = CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).Articulo
                setProducto(True)
                actxnProdCantidad.Text = CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Cantidad
            End If

        Catch ex As Exception

        End Try
    End Sub

   Private Sub NuevaEntidad(ByVal x_envio As TEnvio, ByVal x_entid_nrodocumento As String, ByVal x_tipoentidad As EEntidades.TipoEntidad)
      Try
         Dim frmEntidad As New MEntidad(MEntidad.Inicio.NuevaEntidad, x_tipoentidad)
         frmEntidad.StartPosition = FormStartPosition.CenterScreen
         If x_entid_nrodocumento.Length > 0 Then
            frmEntidad.EEntidad.ENTID_NroDocumento = x_entid_nrodocumento
            frmEntidad.lblNombres.Focus()
         End If
         If frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Select x_tipoentidad
               Case EEntidades.TipoEntidad.Clientes
                  CargarCliente(x_envio, managerEntidades.Entidades.ENTID_NroDocumento, managerEntidades.Entidades.ENTID_Codigo, managerEntidades.Entidades.ENTID_RazonSocial)
               Case EEntidades.TipoEntidad.Transportista
                  actxaNroDocTransportista.Text = frmEntidad.EEntidad.ENTID_NroDocumento
                  actxaDescTransportista.Text = frmEntidad.EEntidad.ENTID_RazonSocial
                  m_etran_guiastransportista.ENTID_CodigoTransportista = frmEntidad.EEntidad.ENTID_Codigo
                  lblNomConductor.Focus()
               Case EEntidades.TipoEntidad.Conductores
                  actxaNroDocConductor.Text = frmEntidad.EEntidad.ENTID_NroDocumento
                        actxaDescConductor.Text = frmEntidad.EEntidad.ENTID_RazonSocial
                        txtLicencia.Text = frmEntidad.EEntidad.Conductor.CONDU_Licencia
                  m_etran_guiastransportista.ENTID_CodigoConductor = frmEntidad.EEntidad.ENTID_Codigo
                  lblDescVehiculo.Focus()
            End Select
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format("Ocurrio un error en el proceso Nuevo ", x_tipoentidad.ToString()), ex)
      End Try
   End Sub

   Private Sub setRolRemitente(ByVal x_opcion As ACETransporte.Constantes.Seteo)
      Try
         actxaDescRemitente.ReadOnly = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, False, True)
         actxaDescRemitente.ACActivarAyuda = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, True, False)
         actxaDescRemitente.ACAyuda.Enabled = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, True, False)
         actxaNroDocRemitente.ReadOnly = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, False, True)
         actxaNroDocRemitente.ACAyuda.Enabled = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, True, False)
         actxaNroDocRemitente.ACActivarAyuda = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, True, False)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setRolDestinatario(ByVal x_opcion As ACETransporte.Constantes.Seteo)
      Try
         actxaDescDestinatario.ReadOnly = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, False, True)
         actxaDescDestinatario.ACActivarAyuda = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, True, False)
         actxaDescDestinatario.ACAyuda.Enabled = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, True, False)
         actxaNroDocDestinatario.ReadOnly = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, False, True)
         actxaNroDocDestinatario.ACAyuda.Enabled = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, True, False)
         actxaNroDocDestinatario.ACActivarAyuda = IIf(x_opcion = ACETransporte.Constantes.Seteo.Activar, True, False)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub actxaNroDocRemitente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocRemitente.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocRemitente.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocRemitente.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocRemitente.Text, EEntidades.TipoInicializacion.Direcciones) Then
                     CargarCliente(TEnvio.Remitente, managerEntidades.Entidades.ENTID_NroDocumento, managerEntidades.Entidades.ENTID_Codigo, managerEntidades.Entidades.ENTID_RazonSocial)
                  Else
                     If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                     , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaNroDocRemitente.Text) _
                                     , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        NuevaEntidad(TEnvio.Remitente, actxaNroDocRemitente.Text, EEntidades.TipoEntidad.Proveedores)
                     Else
                        btnClean_Click(Nothing, Nothing)
                        lblRazonSocial.Focus()
                     End If
                  End If
               End If
            Else
               If actxaNroDocRemitente.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocRemitente.Text))
                  btnClean_Click(Nothing, Nothing)
                  lblRazonSocial.Focus()
               End If

            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

    Private Sub actxaRucDestinatario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocDestinatario.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                If actxaNroDocDestinatario.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
                    '' Cargar datos adicionales cliente
                    If actxaNroDocDestinatario.ACAyuda.Enabled = True Then
                        If managerEntidades.CargarDocIden(actxaNroDocDestinatario.Text, EEntidades.TipoInicializacion.Direcciones) Then
                            CargarCliente(TEnvio.Destinatario, managerEntidades.Entidades.ENTID_NroDocumento, managerEntidades.Entidades.ENTID_Codigo, managerEntidades.Entidades.ENTID_RazonSocial)
                        Else
                            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                            , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaNroDocRemitente.Text) _
                                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                                NuevaEntidad(TEnvio.Destinatario, actxaNroDocDestinatario.Text, EEntidades.TipoEntidad.Clientes)
                            Else
                                btnClean_Click(Nothing, Nothing)
                                lblRazonSocial.Focus()
                            End If
                        End If
                    End If
                Else
                    If actxaNroDocDestinatario.Text.Trim().Length > 0 Then
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocRemitente.Text))
                        btnClean_Click(Nothing, Nothing)
                        lblRazonSocial.Focus()
                    End If

                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
        End Try
    End Sub

#Region " Utilitarios "

   Private Sub calcular(Optional ByVal x_moneda As Boolean = False)
      Try
         If Not IsNothing(m_etran_guiastransportista) Then
            If Not IsNothing(m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles) Then
               If m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles.Count > 0 Then
                  Dim _pesoTotal As Decimal = 0
                  Dim _cantidad As Decimal = 0
                  '' Calcular los precios con percepcion
                  '' Calcular totales
                  For Each Item As ETRAN_GuiasTransportistaDetalles In m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles
                     _pesoTotal += Item.GTDET_Peso * Item.GTDET_Cantidad
                     _cantidad += Item.GTDET_Cantidad
                  Next
                  actxnPesoTotal.Text = _pesoTotal : actxnPesoTotal.Formatear()
               End If
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function busqueda(ByVal x_cadena As String, Optional ByVal x_documento As Boolean = False) As Boolean
      Try
         If x_documento Then
            If managerGenerarGuias.Busqueda(cmbTipoDocumento.SelectedValue, txtCSerie.Text, txtBusNumero.Text, GApp.Sucursal, chkTodos.Checked, acFecha.ACDtpFecha_De.Value.Date, acFecha.ACDtpFecha_A.Value.Date.AddDays(1)) Then
               actool.ACBtnEliminarEnabled = True
               actool.ACBtnModificarEnabled = True
            Else
               actool.ACBtnEliminarEnabled = False
               actool.ACBtnModificarEnabled = False
            End If
            cargarDatos()
         Else
            'If txtBusqueda.ACEstadoAutoAyuda Then
                If managerGenerarGuias.BusquedaGuiaTransportista(x_cadena, getCampo(), GApp.Sucursal, chkTodos.Checked, ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionTransportista), acFecha.ACDtpFecha_De.Value.Date, acFecha.ACDtpFecha_A.Value.Date.AddDays(1)) Then
                    actool.ACBtnEliminarEnabled = True
                    actool.ACBtnModificarEnabled = True
                Else
                    actool.ACBtnEliminarEnabled = False
                    actool.ACBtnModificarEnabled = False
                End If
            cargarDatos()
            'End If
            Return actool.ACBtnEliminarEnabled
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Function getCampo() As String
      Try
         If (rbtnProveedor.Checked) Then
                Return "GTRAN_DescEntidadRemitente" ''"GTRAN_DescEntidadProveedor"
         ElseIf rbtnNroOrdenCompra.Checked Then
            Return "GTRAN_Codigo"
         Else
                Return "GTRAN_DescEntidadRemitente"
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function Validar(ByRef msg As String) As Boolean
      Dim i As Integer = 0
      Dim j As Decimal = 0
      Try
         For Each Item As ETRAN_GuiasTransportistaDetalles In m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles
            i += Item.GTDET_Cantidad
            j += Item.GTDET_Peso * Item.GTDET_Cantidad
         Next

         If j >= CType(Parametros.GetParametro("pg_CargaMax", True), Decimal) Then
            msg &= String.Format("- El peso excede el limite establecido, {2}Peso Actual: {0} kg.,{2}Peso Establecido: {1} kg.{2}" _
                                 , j.ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) _
                                 , CType(Parametros.GetParametro("pg_CargaMax", True), Decimal).ToString(Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) _
                                 , vbNewLine)
         End If

         If Not i > 0 Then msg &= "- La Cantidad debe ser superior a 0" & vbNewLine
         If Not m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles.Count > 0 Then msg &= "- Debe ingresar al menos un Item" & vbNewLine


            ' validar caracteres especiales


            cmbDirDestino.Text = EliminarEspeciales(cmbDirDestino.Text)


            'Validar el tamaño de las direcciones

            'If Len(cmbDirDestino.Text & " - " & cmbDestinoDepartamento.Text & " / " & cmbDestinoProvincia.Text & " / " & cmbDestinoDistrito.Text) > 100 Then
            '    msg &= String.Format("- La cantidad maximo de caracteres es de 100, revise o use abreviaturas para esta direccion.{0}", vbNewLine)
            'End If

            'Validar licencia de conducir
            If Regex.IsMatch(txtLicencia.Text, "^[0-9]*$") Then
                msg &= String.Format("- La licencia de conducir debe contener almenos una letra.{0}", vbNewLine)
            End If

            'que la licencia no este vacia
            If Len(Trim(txtLicencia.Text)) <= 5 Then
                msg &= String.Format("- La licencia de conducir no coincide con el numero de caracteres.{0}", vbNewLine)
            End If
            'que la licencia no este vacia
            'If Len(Trim(actxaCodVehiculo.Text)) <= 5 Then
            '    msg &= String.Format("- La placa no coincide con el numero de caracteres.{0}", vbNewLine)
            'End If

            If Len(Trim(actxnDVNumero.Text)) < 1 Then
                msg &= String.Format("- No hay un numero de documento relacionado.{0}", vbNewLine)
            End If

            Return Not msg.Length > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Function EliminarEspeciales(ByVal s As String, _
Optional ByVal Filtro As String = "{}[]!""#$%&()=?¡'¿|*+¨´:.;,<>^ªº") As String
        Dim I As Integer
        For I = 1 To Len(Filtro)
            s = Replace(s, Mid(Filtro, I, 1), "")
        Next
        EliminarEspeciales = s
    End Function

    Private Sub setProducto(ByVal x_opcion As Boolean) 'ESTO LLAMA A LOS PRODUCTOS QUE TENEMOS QUE BUSCAR 

        Try
            If x_opcion Then
                If managerConsultaArticulos.cargarProducto(m_earticulos.ARTIC_Codigo) Then
                    m_earticulos = managerConsultaArticulos.Articulos
                    actxaProdCodigo.Text = m_earticulos.ARTIC_Codigo
                    txtProdDescripcion.Text = m_earticulos.ARTIC_Descripcion
                    txtProdUnidad.Text = m_earticulos.TIPOS_UnidadMedida
                    actxnProdPeso.Text = m_earticulos.ARTIC_Peso
                    txtProdDescripcion.Focus()
                End If
            Else
                actxaProdCodigo.Clear()
                txtProdDescripcion.Clear()
                actxnProdCantidad.Text = "0.00"
                txtProdUnidad.Text = ""
                actxnProdPeso.Text = "0.00"

                'actxnSubImporte.Text = "0.00"
                'cmbPrecioUnitario.DataSource = Nothing
                m_earticulos = Nothing
                'actxaProdCodigo.Clear()
                'txtProdUnidad.Clear()
                'txtProdDescripcion.Clear()
                'actxnProdCantidad.Text = "0.00"
                'actxnProdPeso.Text = "0.0000"
                'actxnProdCantidad.Text = "0.00"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cargarCombos()
      Try
         '' Cargar tipo de documentos de mercaderia en transito
         ACUtilitarios.ACCargaCombo(cmbDocVenta, Colecciones.TiposDocMerTransito(), "TIPOS_Descripcion", "TIPOS_Codigo")
         Dim list As New List(Of ETipos)()
         For Each Item As ETipos In Colecciones.TiposDocMerTransito()
            list.Add(Item.Clone())
         Next
         list.Insert(0, New ETipos("", "<< Todos >>"))
         '' Cargar Direcciones de los almacenes como direccion de origen
         'bs_sucursales = New BindingSource() : bs_sucursales.DataSource = Colecciones.Sucursales
         'ACFramework.ACUtilitarios.ACCargaCombo(cmbDirDestino, bs_sucursales, "SUCUR_Direccion", "SUCUR_Direccion")
         'AddHandler bs_sucursales.CurrentChanged, AddressOf bs_sucursales_CurrentChanged : bs_sucursales_CurrentChanged(Nothing, Nothing)
         '' Tipo de Traslado
         ACFramework.ACUtilitarios.ACCargaCombo(cmbMotivoTraslado, Colecciones.Tipos(ETipos.MyTipos.MotivoTraslado), "TIPOS_Descripcion", "TIPOS_Codigo", ETipos.getMotivoTraslado(ETipos.MotivoTraslado.Compra))
         '' Documentos de Traslados
         Dim listDT As New List(Of ETipos) : Dim listBus As New List(Of ETipos)
         For Each Item As ETipos In Colecciones.TiposGuiaRemisionTransportista
            listDT.Add(Item.Clone()) : listBus.Add(Item.Clone())
         Next
         bs_tipodocumento = New BindingSource() : bs_tipodocumento.DataSource = listDT
         ACFramework.ACUtilitarios.ACCargaCombo(cmbGuia, bs_tipodocumento, "TIPOS_Descripcion", "TIPOS_Codigo", ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionTransportista))
         AddHandler bs_tipodocumento.CurrentChanged, AddressOf bs_tipodocumento_CurrentChanged : bs_tipodocumento_CurrentChanged(Nothing, Nothing)
         listBus.Insert(0, New ETipos("", "<< Todos >>"))
         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoDocumento, listBus, "TIPOS_Descripcion", "TIPOS_Codigo")

         '' Cargar Ubigeos
         m_listSalDep = New List(Of EUbigeos) : m_listDesDep = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Departamentos
            If Not Item.UBIGO_Codigo.Equals("00") Then
               m_listSalDep.Add(Item.Clone) : m_listDesDep.Add(Item.Clone)
            End If
         Next
         bs_SalDep = New BindingSource() : bs_SalDep.DataSource = m_listSalDep : AddHandler bs_SalDep.CurrentChanged, AddressOf bs_saldep_CurrentChanged : bs_saldep_CurrentChanged(Nothing, Nothing)
         bs_DesDep = New BindingSource() : bs_DesDep.DataSource = m_listDesDep : AddHandler bs_DesDep.CurrentChanged, AddressOf bs_desdep_CurrentChanged : bs_desdep_CurrentChanged(Nothing, Nothing)
         '' Ubigeos
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDestinoDepartamento, bs_SalDep, "UBIGO_Descripcion", "UBIGO_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbOrigenDepartamento, bs_DesDep, "UBIGO_Descripcion", "UBIGO_Codigo")

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACUtilitarios.ACSetInstancia)
      Try
         actool.ACBtnRehusarVisible = False
         actool.ACBtnModificarVisible = False
         Select Case _opcion
                Case ACUtilitarios.ACSetInstancia.Nuevo 'Esto sirve para que cuando se presione todos los campos se vacien
                    ACUtilitarios.ACLimpiaVar(pnlCabecera) 'Aca esta encerrado por las partes de un formulario Cabecera cuerpo pie etc .
                    ACUtilitarios.ACLimpiaVar(pnlItem)
               ACUtilitarios.ACSetControl(pnlCabecera, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
               actxnDVNumero.Clear()
                    cmbDirOrigen.Text = ""
                    cmbDirDestino.Text = ""
                    SetControles(True) 'Esta funcion se la estamos pasando true o false y abajo esta declarado
                    actool.ACBtnImprimirVisible = False
                    actsbtnPrevisualizar.Visible = False 'Estos son los  botones Imprimir , Visualizar , Anular 
                    actool.ACBtnAnularVisible = False
               actool.ACBtnImprimirEnabled = False
            Case ACUtilitarios.ACSetInstancia.Modificado
                    'FALTA CODIGO AQUI 
                Case ACUtilitarios.ACSetInstancia.Guardar
               txtBusqueda.Focus()
            Case ACUtilitarios.ACSetInstancia.Deshacer
               actool.ACBtnModificarVisible = False
               actool.ACBtnBuscarVisible = False
               actsbtnPrevisualizar.Visible = True
               actool.ACBtnImprimirVisible = False
               tabMantenimiento.SelectedTab = tabBusqueda
                    actool.ACBtnImprimirEnabled = True
                    m_modArticulo = False
                    c1grdDetalle.Enabled = True
            Case ACUtilitarios.ACSetInstancia.Previsualizar
               actool.ACBtnImprimirVisible = True
               ACUtilitarios.ACLimpiaVar(pnlCabecera)
               ACUtilitarios.ACLimpiaVar(pnlItem)
               ACUtilitarios.ACSetControl(pnlCabecera, True, ACUtilitarios.TipoPropiedad.ACReadOnly)
               actool.ACBtnGrabarVisible = False
               actsbtnPrevisualizar.Visible = False
               actool.ACBtnRehusarVisible = True
               actool.ACBtnImprimirEnabled = True
                    SetControles(False) 'Esta funcion se la estamos pasando true o false y abajo esta declarado
            End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

    Private Sub SetControles(ByVal x_opcion As Boolean) 'True o false 
        cmbDirDestino.Enabled = x_opcion
        cmbDirOrigen.Enabled = x_opcion
        cmbGuia.Enabled = x_opcion

        actxaDescTransportista.ACActivarAyuda = x_opcion : actxaDescTransportista.ACAyuda.Enabled = x_opcion
        actxaNroDocTransportista.ACActivarAyuda = x_opcion : actxaNroDocTransportista.ACAyuda.Enabled = x_opcion
        actxaDescConductor.ACActivarAyuda = x_opcion : actxaDescConductor.ACAyuda.Enabled = x_opcion
        'EN ESTA SECCION SE OPERA CON PURAS CONDICIONES TERNARIAS
        'todos se guarda ya sea en tru o false en las variable <<actxa>>
        actxaNroDocConductor.ACActivarAyuda = x_opcion : actxaNroDocConductor.ACAyuda.Enabled = x_opcion 'VARIABLE DEL TEXTBOX CONDUCTOR --> FRANK 
        actxaDescVehiculo.ACActivarAyuda = x_opcion : actxaDescVehiculo.ACAyuda.Enabled = x_opcion
        actxaCodVehiculo.ACActivarAyuda = x_opcion : actxaCodVehiculo.ACAyuda.Enabled = x_opcion
        actxaDescRemitente.ACActivarAyuda = x_opcion : actxaDescRemitente.ACAyuda.Enabled = x_opcion
        actxaNroDocRemitente.ACActivarAyuda = x_opcion : actxaNroDocRemitente.ACAyuda.Enabled = x_opcion

        actxaDescDestinatario.ACActivarAyuda = x_opcion : actxaDescDestinatario.ACAyuda.Enabled = x_opcion
        actxaNroDocDestinatario.ACActivarAyuda = x_opcion : actxaNroDocDestinatario.ACAyuda.Enabled = x_opcion

        cmbMotivoTraslado.Enabled = x_opcion
        GroupBox7.Enabled = x_opcion
        grpDocumento.Enabled = x_opcion

        dtpFechaEmision.Enabled = x_opcion
        dtpFechaTraslado.Enabled = x_opcion

        pnlItem.Enabled = x_opcion

        btnNueRemitente.Enabled = x_opcion : btnCleanRemitente.Enabled = x_opcion
        btnNueTransportista.Enabled = x_opcion : btnNuevConductor.Enabled = x_opcion

        btnModConductor.Enabled = x_opcion
        btnModificar.Enabled = x_opcion

    End Sub

    Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 17, 1, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha Emisión", "GTRAN_Fecha", "GTRAN_Fecha", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "GTRAN_Codigo", "GTRAN_Codigo", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Nro. Guia", "NroGuia", "NroGuia", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Comprobante", "DocComprobante", "TipoComprobante", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha Traslado", "GTRAN_FechaTraslado", "GTRAN_FechaTraslado", 150, True, False, "System.DateTime") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Direccion Partida", "GTRAN_DireccionProveedor", "GTRAN_DireccionProveedor", 150, False, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Direccion Llegada", "GTRAN_DireccionDestinatario", "GTRAN_DireccionDestinatario", 150, False, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Remitente", "ENTID_CodigoRemitente", "ENTID_CodigoRemitente", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Remitente", "GTRAN_DescEntidadRemitente", "GTRAN_DescEntidadRemitente", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Transportista", "ENTID_Transportista", "ENTID_Transportista", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Conductor", "ENTID_Conductor", "ENTID_Conductor", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Vehiculo", "GTRAN_DescripcionVehiculo", "GTRAN_DescripcionVehiculo", 150, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Doc. Relacionado", "GTRAN_NroComprobantePago", "GTRAN_NroComprobantePago", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Total Peso", "GTRAN_PesoTotal", "GTRAN_PesoTotal", 150, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "GTRAN_Estado_Text", "GTRAN_Estado_Text", 150, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Estado", "GTRAN_Estado", "GTRAN_Estado", 150, False, False, "System.String") : index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row
         'c1grdBusqueda.VisualStyle = VisualStyle.Office2007Blue
         c1grdBusqueda.SubtotalPosition = SubtotalPositionEnum.AboveData
         c1grdBusqueda.Tree.Column = 2

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
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdDetalle, 1, 1, 6, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Codigo", "ARTIC_Codigo", "ARTIC_Codigo", 110, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Descripción", "GTDET_Descripcion", "GTDET_Descripcion", 454, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Unidad", "GTDET_Unidad", "GTDET_Unidad", 80, True, False, "System.String") : index += 1
            ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Peso", "GTDET_Peso", "GTDET_Peso", 80, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo4d)) : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdDetalle, index, "Cantidad", "GTDET_Cantidad", "GTDET_Cantidad", 110, True, False, "System.Decimal", Parametros.GetParametro(EParametros.TipoParametros.pg_FMondo2d)) : index += 1
         c1grdDetalle.AllowEditing = True
         c1grdDetalle.AutoResize = False
         c1grdDetalle.Cols(0).Width = 15
         c1grdDetalle.ExtendLastCol = False
         c1grdDetalle.VisualStyle = VisualStyle.Office2007Blue
         c1grdDetalle.AllowSorting = AllowSortingEnum.SingleColumn

         c1grdDetalle.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdDetalle.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdDetalle.Styles.Highlight.BackColor = Color.Gray
         c1grdDetalle.SelectionMode = SelectionModeEnum.Row
         c1grdDetalle.AllowResizing = AllowResizingEnum.None
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try

   End Sub

#End Region

#Region " Cargar Datos "

   Private Function addDetallePedido() As Boolean
      Try
         'If Not IsNothing(m_earticulos) Then
         Dim _detGuiaRemision As New ETRAN_GuiasTransportistaDetalles
         _detGuiaRemision.Articulo = m_earticulos
         If IsNothing(m_earticulos) Then
                _detGuiaRemision.ARTIC_Codigo = "1301001" 'actxaProdCodigo.Text
            _detGuiaRemision.GTDET_Unidad = txtProdUnidad.Text
            _detGuiaRemision.GTDET_Peso = actxnProdPeso.Text
            _detGuiaRemision.GTDET_Descripcion = txtProdDescripcion.Text
         Else
            _detGuiaRemision.GTDET_Unidad = txtProdUnidad.Text
            _detGuiaRemision.ARTIC_Codigo = m_earticulos.ARTIC_Codigo
            _detGuiaRemision.GTDET_Peso = m_earticulos.ARTIC_Peso
                _detGuiaRemision.GTDET_Descripcion = txtProdDescripcion.Text 'm_earticulos.ARTIC_Descripcion
         End If
         _detGuiaRemision.GTDET_Cantidad = actxnProdCantidad.Text

         If _detGuiaRemision.GTDET_Cantidad > 0 Then
            '' Actualizar contenido
            m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles.Add(_detGuiaRemision)
            bs_etran_guiastransportistadetalle.ResetBindings(False)
            calcular()
            Return True
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede agregar el producto, por la Cantida/Precio es incorrecto, corrija y vuelva a intentarlo ")
            If _detGuiaRemision.GTDET_Cantidad = 0 Then
               actxnProdCantidad.Focus()
               Return False
            End If
         End If
            c1grdDetalle.AutoSizeCols()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub bs_series_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_series.Current) Then
                Dim x_numero As Integer = managerGenerarGuias.getNumero(CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_Serie, ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionTransportista))
            actxnNumero.Text = (x_numero + 1).ToString()
            tscmbImpresora.Text = CType(bs_series.Current, EVENT_PVentDocumento).PVDOCU_DispositivoImpresion
         Else
            actxnNumero.Clear()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub

#Region " Ubigeos "
   Private Sub bs_saldep_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_ubigeo As String = CType(bs_SalDep.Current, EUbigeos).UBIGO_Codigo
         m_listSalPro = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Provincias
            If x_ubigeo.Equals(Item.UBIGO_CodPadre) Then
               m_listSalPro.Add(Item.Clone)
            End If
         Next
         bs_SalPro = New BindingSource() : bs_SalPro.DataSource = m_listSalPro : AddHandler bs_SalPro.CurrentChanged, AddressOf bs_salpro_CurrentChanged
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDestinoProvincia, bs_SalPro, "UBIGO_Descripcion", "UBIGO_Codigo")
         bs_salpro_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso actualizar departamento", ex)
      End Try
   End Sub

   Private Sub bs_salpro_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_ubigeo As String = CType(bs_SalPro.Current, EUbigeos).UBIGO_Codigo
         m_listSalDis = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Distritos
            If x_ubigeo.Equals(Item.UBIGO_CodPadre) Then
               m_listSalDis.Add(Item.Clone)
            End If
         Next
         bs_SalDis = New BindingSource() : bs_SalDis.DataSource = m_listSalDis
         ACFramework.ACUtilitarios.ACCargaCombo(cmbDestinoDistrito, bs_SalDis, "UBIGO_Descripcion", "UBIGO_Codigo")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso actualizar provincia", ex)
      End Try
   End Sub

   Private Sub bs_desdep_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_ubigeo As String = CType(bs_DesDep.Current, EUbigeos).UBIGO_Codigo
         m_listDesPro = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Provincias
            If x_ubigeo.Equals(Item.UBIGO_CodPadre) Then
               m_listDesPro.Add(Item.Clone)
            End If
         Next
         bs_DesPro = New BindingSource() : bs_DesPro.DataSource = m_listDesPro : AddHandler bs_DesPro.CurrentChanged, AddressOf bs_despro_CurrentChanged
         ACFramework.ACUtilitarios.ACCargaCombo(cmbOrigenProvincia, bs_DesPro, "UBIGO_Descripcion", "UBIGO_Codigo")
         bs_despro_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso actualizar departamento", ex)
      End Try
   End Sub

   Private Sub bs_despro_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_ubigeo As String = CType(bs_DesPro.Current, EUbigeos).UBIGO_Codigo
         m_listDesDis = New List(Of EUbigeos)
         For Each Item As EUbigeos In Colecciones.Distritos
            If x_ubigeo.Equals(Item.UBIGO_CodPadre) Then
               m_listDesDis.Add(Item.Clone)
            End If
         Next
         bs_DesDis = New BindingSource() : bs_DesDis.DataSource = m_listDesDis
         ACFramework.ACUtilitarios.ACCargaCombo(cmbOrigenDistrito, bs_DesDis, "UBIGO_Descripcion", "UBIGO_Codigo")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso actualizar provincia", ex)
      End Try
   End Sub

#End Region

   Private Sub bs_tran_guiastransito_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_etran_guiastransportista) Then
            If Not IsNothing(bs_etran_guiastransportista.Current) Then
               If CType(bs_etran_guiastransportista.Current, ETRAN_GuiasTransportista).GTRAN_Estado = ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Ingresado) Then
                  actool.ACBtnAnularEnabled = True
                  actool.ACBtnImprimirEnabled = True
               Else
                  actool.ACBtnAnularEnabled = False
                  actool.ACBtnImprimirEnabled = False
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Propiedades del Cotización/Pedido", ex)
      End Try
   End Sub

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad, Optional ByVal x_envio As TEnvio = TEnvio.Destinatario)
      Try
         Select Case x_opcion
            Case EEntidades.TipoEntidad.Transportista
               Dim _where As New Hashtable
               _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
               If managerEntidades.Ayuda(_where, x_opcion) Then
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Transportista", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     '' Cargar datos del cliente
                     actxaNroDocTransportista.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     actxaDescTransportista.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                     m_etran_guiastransportista.ENTID_CodigoTransportista = Ayuda.Respuesta.Rows(0)("Codigo")
                     lblNomConductor.Focus()
                     btnModificar.Enabled = True
                  End If
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
               End If
            Case EEntidades.TipoEntidad.Conductores
               If managerEntidades.AyudaConductores(m_etran_guiastransportista.ENTID_CodigoTransportista, x_cadenas, x_campo, x_opcion) Then
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Conductores", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     actxaNroDocConductor.Text = Ayuda.Respuesta.Rows(0)("Doc./R.U.C.")
                     actxaDescConductor.Text = Ayuda.Respuesta.Rows(0)("Razon Social")
                     m_etran_guiastransportista.ENTID_CodigoConductor = Ayuda.Respuesta.Rows(0)("Codigo")
                     managerEntidades.Entidades = New EEntidades()
                     If managerEntidades.CargarConductor(m_etran_guiastransportista.ENTID_CodigoConductor) Then
                        txtLicencia.Text = managerEntidades.Entidades.Conductor.CONDU_Licencia
                     End If
                     lblDescVehiculo.Focus()
                  End If
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
               End If
            Case EEntidades.TipoEntidad.Clientes
               Dim _where As New Hashtable
               _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
               If managerEntidades.Ayuda(_where, x_opcion) Then
                  Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Cliente", managerEntidades.DTEntidades, False)
                  If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     '' Cargar datos del cliente
                     CargarCliente(x_envio, Ayuda.Respuesta.Rows(0)("Doc./R.U.C."), Ayuda.Respuesta.Rows(0)("Codigo"), Ayuda.Respuesta.Rows(0)("Razon Social"))
                  End If
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
               End If
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub CargarCliente(ByVal x_envio As TEnvio, ByVal x_entid_nrodocumento As String, ByVal x_entid_codigo As String, ByVal x_entid_razonsocial As String)
      Try
         Select Case x_envio
            Case TEnvio.Remitente
               actxaNroDocRemitente.Text = x_entid_nrodocumento
               m_etran_guiastransportista.ENTID_CodigoRemitente = x_entid_codigo
               actxaDescRemitente.Text = x_entid_razonsocial
               If managerEntidades.Cargar(m_etran_guiastransportista.ENTID_CodigoRemitente, EEntidades.TipoInicializacion.Direcciones) Then
                  Dim x_direcciones As New EDirecciones
                  x_direcciones.DIREC_Id = 0
                  x_direcciones.DIREC_Direccion = managerEntidades.Entidades.ENTID_Direccion
                  x_direcciones.UBIGO_Codigo = managerEntidades.Entidades.UBIGO_Codigo
                  If IsNothing(managerEntidades.Entidades.ListDirecciones) Then managerEntidades.Entidades.ListDirecciones = New List(Of EDirecciones)()
                  managerEntidades.Entidades.ListDirecciones.Insert(0, x_direcciones)
                  bs_dirorigen = New BindingSource()
                  bs_dirorigen.DataSource = managerEntidades.Entidades.ListDirecciones
                  AddHandler bs_dirorigen.CurrentChanged, AddressOf bs_cmborigen_CurrentChanged
                  ACFramework.ACUtilitarios.ACCargaCombo(cmbDirOrigen, bs_dirorigen, "DIREC_Direccion", "DIREC_Id")
                  If managerEntidades.Entidades.ListDirecciones.Count > 0 Then
                     cmbDirOrigen.SelectedValue = managerEntidades.Entidades.ListDirecciones(0).DIREC_Id
                     If Not IsNothing(CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo) Then
                        cmbOrigenDepartamento.SelectedValue = CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 2)
                        cmbOrigenProvincia.SelectedValue = CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 5)
                                cmbOrigenDistrito.SelectedValue = CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo

                                Dim cmb As Integer = (Len(cmbOrigenDepartamento.Text) + Len(cmbOrigenProvincia.Text) + Len(cmbOrigenDistrito.Text) + 6) '(Len(cmbDepartamento.Text) + Len(cmbProvincia.Text) + Len(cmbDistrito.Text) + 8)
                                Dim total As Integer = Len(cmbDirOrigen.Text)
                                Dim dir As Integer = total - cmb

                                cmbDirOrigen.Text = cmbDirOrigen.Text.Substring(0, dir)
                            Else
                                cmbOrigenDepartamento.SelectedIndex = -1
                                cmbOrigenProvincia.SelectedIndex = -1
                                cmbOrigenDistrito.SelectedIndex = -1

                                cmbDirOrigen.Text = "-"
                     End If
                        End If
                      

                        txtUbigeoPartida.Text = managerEntidades.Entidades.UBIGO_Codigo
                  setRolRemitente(ACETransporte.Constantes.Seteo.Desactivar)
                  pnlItem.Enabled = True
                  lblDireccion.Focus()
               End If
            Case TEnvio.Destinatario
               actxaNroDocDestinatario.Text = x_entid_nrodocumento
               m_etran_guiastransportista.ENTID_CodigoDestinatario = x_entid_codigo
               actxaDescDestinatario.Text = x_entid_razonsocial
               If managerEntidades.Cargar(m_etran_guiastransportista.ENTID_CodigoDestinatario, EEntidades.TipoInicializacion.Direcciones) Then
                  Dim x_direcciones As New EDirecciones
                  x_direcciones.DIREC_Id = 0
                  x_direcciones.DIREC_Direccion = managerEntidades.Entidades.ENTID_Direccion
                  x_direcciones.UBIGO_Codigo = managerEntidades.Entidades.UBIGO_Codigo
                  If IsNothing(managerEntidades.Entidades.ListDirecciones) Then managerEntidades.Entidades.ListDirecciones = New List(Of EDirecciones)()
                  managerEntidades.Entidades.ListDirecciones.Insert(0, x_direcciones)
                  bs_dirdestino = New BindingSource
                  bs_dirdestino.DataSource = managerEntidades.Entidades.ListDirecciones
                  AddHandler bs_dirdestino.CurrentChanged, AddressOf bs_cmbdestino_CurrentChanged
                  ACFramework.ACUtilitarios.ACCargaCombo(cmbDirDestino, bs_dirdestino, "DIREC_Direccion", "DIREC_Id")
                  If managerEntidades.Entidades.ListDirecciones.Count > 0 Then
                     cmbDirDestino.SelectedValue = managerEntidades.Entidades.ListDirecciones(0).DIREC_Id
                     If Not IsNothing(CType(cmbDirDestino.SelectedItem, EDirecciones).UBIGO_Codigo) Then
                        cmbDestinoDepartamento.SelectedValue = CType(cmbDirDestino.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 2)
                        cmbDestinoProvincia.SelectedValue = CType(cmbDirDestino.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 5)
                                cmbDestinoDistrito.SelectedValue = CType(cmbDirDestino.SelectedItem, EDirecciones).UBIGO_Codigo


                                Dim cmb As Integer = (Len(cmbDestinoDepartamento.Text) + Len(cmbDestinoProvincia.Text) + Len(cmbDestinoDistrito.Text) + 6) '(Len(cmbDepartamento.Text) + Len(cmbProvincia.Text) + Len(cmbDistrito.Text) + 8)
                                Dim total As Integer = Len(cmbDirDestino.Text)
                                Dim dir As Integer = total - cmb

                                cmbDirDestino.Text = cmbDirDestino.Text.Substring(0, dir)

                            Else
                                cmbDestinoDepartamento.SelectedIndex = -1
                                cmbDestinoProvincia.SelectedIndex = -1
                                cmbDestinoDistrito.SelectedIndex = -1

                                cmbDirDestino.Text = "-"
                     End If
                        End If


                        txtUbigeoLlegada.Text = managerEntidades.Entidades.UBIGO_Codigo
                  setRolDestinatario(ACETransporte.Constantes.Seteo.Desactivar)
                  pnlItem.Enabled = True
                  lblDireccionDestino.Focus()
               End If
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AyudaVehiculo(ByVal x_cadenas As String, ByVal x_campos As String)
      Try
            ' If managerTRAN_Vehiculos.Ayuda(m_etran_guiastransportista.ENTID_CodigoTransportista, x_cadenas, x_campos) Then
            If managerTRAN_Vehiculos.Ayuda(actxaNroDocTransportista.Text, x_cadenas, x_campos) Then
                Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerTRAN_Vehiculos.DTTRAN_Vehiculos, False)
                If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    actxaCodVehiculo.Text = Ayuda.Respuesta.Rows(0)("Placa")
                    m_etran_guiastransportista.VEHIC_Id = Ayuda.Respuesta.Rows(0)("Interno")
                    If Ayuda.Respuesta.Rows(0)("Marca Ranfla") Is DBNull.Value Then
                        actxaDescVehiculo.Text = String.Format("{0}/{1}", Ayuda.Respuesta.Rows(0)("Marca"), Ayuda.Respuesta.Rows(0)("Placa"))
                        m_etran_guiastransportista.VEHIC_Placa = Ayuda.Respuesta.Rows(0)("Placa")
                        txtCertificado.Text = String.Format("{0}/{1}", Ayuda.Respuesta.Rows(0)("Certificado"), Ayuda.Respuesta.Rows(0)("Certificado Ranfla"))
                    Else
                        actxaDescVehiculo.Text = String.Format("{0}-{1}/{2},{3}", Ayuda.Respuesta.Rows(0)("Marca"), Ayuda.Respuesta.Rows(0)("Marca Ranfla"), Ayuda.Respuesta.Rows(0)("Placa"), Ayuda.Respuesta.Rows(0)("Placa Ranfla"))
                        m_etran_guiastransportista.VEHIC_Placa = Ayuda.Respuesta.Rows(0)("Placa")
                        txtCertificado.Text = String.Format("{0}/{1}", Ayuda.Respuesta.Rows(0)("Certificado"), Ayuda.Respuesta.Rows(0)("Certificado Ranfla"))
                    End If
                    'If Ayuda.Respuesta.Rows(0)("Certificado Ranfla") Is DBNull.Value Then
                    '    txtCertificado.Text = String.Format("{0}", Ayuda.Respuesta.Rows(0)("Certificado"))

                    'Else
                    '    txtCertificado.Text = String.Format("{0}/{1}", Ayuda.Respuesta.Rows(0)("Certificado"), Ayuda.Respuesta.Rows(0)("Certificado Ranfla"))
                    'End If

                    'managerGenerarGuias.TRAN_GuiasTransportista.VEHIC_Id = Ayuda.Respuesta.Rows(0)("Interno")
                    'If managerTRAN_Vehiculos.Cargar(managerGenerarGuias.TRAN_GuiasTransportista.VEHIC_Id, True) Then
                    '    SetVehiculo()
                    'End If
                End If
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar la ayuda, posiblemente no hay datos que mostrar")
            End If
        Catch ex As Exception
            Throw ex
        End Try
   End Sub
    Private Sub SetVehiculo()
        Try
            actxaCodVehiculo.Text = managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Placa
            Dim _padic As String = ""
            Dim _cadic As String = ""
            If Not IsNothing(managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_PlacaAdic) Then
                _padic = String.Format("/{0}", managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_PlacaAdic)
                _cadic = String.Format("/{0}", managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_CertificadoAdic)
            End If
            actxaDescVehiculo.Text = String.Format("{0}/{1}/{2}{3}", managerTRAN_Vehiculos.TRAN_Vehiculos.TIPOS_Marca, _
                                                   managerTRAN_Vehiculos.TRAN_Vehiculos.TIPOS_Vehiculo, _
                                                   managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Placa, _
                                                   _padic)
            txtCertificado.Text = String.Format("{0}{1}", managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Certificado, _cadic)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
   Private Sub bs_almacenesDestino_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim x_almacen As Short = cmbDirDestino.SelectedValue
         'txtAlmaDirDestino.Text = CType(bs_almacenesDestino.Current, EAlmacenes).ALMAC_Descripcion
         Dim _filter As New ACFiltrador(Of EPuntoVenta)() With {.ACFiltro = String.Format("ALMAC_Id={0}", x_almacen.ToString())}
         bs_puntoventa = New BindingSource()
         bs_puntoventa.DataSource = _filter.ACFiltrar(Colecciones.PuntosVenta)
         'ACUtilitarios.ACCargaCombo(cmbPuntoVentaDestino, bs_puntoventa, "PVENT_Descripcion", "PVENT_Id")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_tipodocumento_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not (bs_tipodocumento.Current Is Nothing) Then
            '' Series por documento
            managerVENT_PVentDocumento.GetSeries(GApp.Zona, GApp.Sucursal, cmbGuia.SelectedValue)
            Dim _serie As String = ""
            For Each item As EVENT_PVentDocumento In managerVENT_PVentDocumento.ListVENT_PVentDocumento
               If item.PVDOCU_PredetGuiaRemisRemitTransportista Then
                  _serie = item.PVDOCU_Serie
               End If
            Next
            bs_series = New BindingSource() : bs_series.DataSource = managerVENT_PVentDocumento.ListVENT_PVentDocumento
            If _serie.Equals("") Then
               ACFramework.ACUtilitarios.ACCargaCombo(cmbSerie, bs_series, "PVDOCU_Serie", "PVDOCU_Serie")
            Else : ACFramework.ACUtilitarios.ACCargaCombo(cmbSerie, bs_series, "PVDOCU_Serie", "PVDOCU_Serie", _serie)
            End If
            AddHandler bs_series.CurrentChanged, AddressOf bs_series_CurrentChanged : bs_series_CurrentChanged(Nothing, Nothing)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_almacenOrigen_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         'txtAlmaDirOrigen.Text = CType(bs_almacenesOrigen.Current, EAlmacenes).ALMAC_Descripcion
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbGuia, "SelectedValue", m_etran_guiastransportista, "TIPOS_CodTipoDocumento"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbSerie, "SelectedValue", m_etran_guiastransportista, "GTRAN_Serie"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnNumero, "Text", m_etran_guiastransportista, "GTRAN_Numero"))
         If m_etran_guiastransportista.GTRAN_Fecha.Year < 1700 Then m_etran_guiastransportista.GTRAN_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFechaEmision, "Value", m_etran_guiastransportista, "GTRAN_Fecha"))
         If m_etran_guiastransportista.GTRAN_FechaTraslado.Year < 1700 Then m_etran_guiastransportista.GTRAN_FechaTraslado = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFechaTraslado, "Value", m_etran_guiastransportista, "GTRAN_FechaTraslado"))

            m_listBindHelper.Add(ACBindHelper.ACBind(actxaNroDocRemitente, "Text", m_etran_guiastransportista, "GTRAN_RUCRemitente"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxaDescRemitente, "Text", m_etran_guiastransportista, "GTRAN_DescEntidadRemitente"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtZonaOrigen, "Text", m_etran_guiastransportista, "GTRAN_ZonaRemitente"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbDirOrigen, "Text", m_etran_guiastransportista, "GTRAN_DireccionRemitente"))
            m_listBindHelper.Add(ACBindHelper.ACBind(cmbOrigenDistrito, "SelectedValue", m_etran_guiastransportista, "UBIGO_CodigoRemitente"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxaNroDocDestinatario, "Text", m_etran_guiastransportista, "GTRAN_RUCDestinatario"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxaDescDestinatario, "Text", m_etran_guiastransportista, "GTRAN_DesEntidadDestinatario"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtZonaDestino, "Text", m_etran_guiastransportista, "GTRAN_ZonaDestinatario"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbDirDestino, "Text", m_etran_guiastransportista, "GTRAN_DireccionDestinatario"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbDestinoDistrito, "SelectedValue", m_etran_guiastransportista, "UBIGO_CodigoDestinatario"))

            ' m_listBindHelper.Add(ACBindHelper.ACBind(cmbMotivoTraslado, "SelectedValue", m_etran_guiastransportista, "TIPOS_CodMotivoTraslado"))

         m_listBindHelper.Add(ACBindHelper.ACBind(actxaCodVehiculo, "Text", m_etran_guiastransportista, "VEHIC_Id"))
            m_listBindHelper.Add(ACBindHelper.ACBind(actxaDescVehiculo, "Text", m_etran_guiastransportista, "GTRAN_DescripcionVehiculo"))
            m_listBindHelper.Add(ACBindHelper.ACBind(txtCertificado, "Text", m_etran_guiastransportista, "GTRAN_CertificadosVehiculo"))
         'm_listBindHelper.Add(ACBindHelper.ACBind(cmbMotivoTraslado, "SelectedValue", m_etran_guiastransportista, "TIPOS_CodMotivoTraslado"))
         m_listBindHelper.Add(ACBindHelper.ACBind(actxnPesoTotal, "Text", m_etran_guiastransportista, "GTRAN_PesoTotal"))

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargarDatos()
      Try
         bs_etran_guiastransportista = New BindingSource()
         bs_etran_guiastransportista.DataSource = managerGenerarGuias.ListTRAN_GuiasTransportista
         c1grdBusqueda.DataSource = bs_etran_guiastransportista
         bnavBusqueda.BindingSource = bs_etran_guiastransportista
         AddHandler bs_etran_guiastransportista.CurrentChanged, AddressOf bs_tran_guiastransito_CurrentChanged
         bs_tran_guiastransito_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region
#End Region

#Region " Metodos de Controles"

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If rbtnDatos.Checked Then
            txtBusqueda_ACAyudaClick(Nothing, Nothing)
         ElseIf rbtnDocVenta.Checked Then
            txtBusNumero_ACAyudaClick(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede realizar la consulta", ex)
      End Try
   End Sub

   Private Sub rbtnDatos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnDatos.CheckedChanged
      grpCliente.Enabled = rbtnDatos.Checked
      grpDocumentos.Enabled = rbtnDocVenta.Checked
   End Sub

   Private Sub actool_ACBtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnAnular_Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Anular Registro: {0}", Me.Text) _
             , String.Format("Desea anular la Guia Nro: {0}-{1} ", CType(bs_etran_guiastransportista.Current, ETRAN_GuiasTransportista).GTRAN_Serie _
                             , CType(bs_etran_guiastransportista.Current, ETRAN_GuiasTransportista).GTRAN_Numero.ToString().PadLeft(7, "0")) _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            If managerGenerarGuias.AnularGuia(CType(bs_etran_guiastransportista.Current, ETRAN_GuiasTransportista).GTRAN_Codigo, GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Documento Anulado satisfactoriamente")
               acTool_ACBtnCancelar_Click(Nothing, Nothing) : btnConsultar_Click(Nothing, Nothing)
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "El documento no puede ser anulado")
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Anular Documento", ex)
      End Try
   End Sub

   Private Sub actool_ACBtnRehusar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnRehusar_Click
      Try
         SetControles(True)
         ACUtilitarios.ACSetControl(pnlCabecera, False, ACUtilitarios.TipoPropiedad.ACReadOnly)
         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         actool.ACBtnRehusarVisible = False
         bs_series_CurrentChanged(Nothing, Nothing)
         m_etran_guiastransportista.Instanciar(ACEInstancia.Nuevo)
         m_etran_guiastransportista.GTRAN_Estado = ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Ingresado)
         txtDVSerie.Clear()
         actxnDVNumero.Clear()
         actool.ACBtnImprimirEnabled = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Rehusar Documento", ex)
      End Try
   End Sub

   Private Sub c1grdBusqueda_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles c1grdBusqueda.MouseDoubleClick
      actsbtnPrevisualizar_Click(Nothing, Nothing)
   End Sub

#Region "Ayudas"

    Private Sub actxaProdCodigo_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaProdCodigo.ACAyudaClick 'BOTON DE BUSQUEDA 
        'PARA LOS PRODUCTOS ESTA TE ABRE UNA MINIVENTANA EN DONDE SE BUSCARA LOS PRODUCTOS --->FRANK  
        Try
            If IsNothing(frmCons) Then frmCons = New CProductos(CProductos.Origen.Cotizaciones) With {.StartPosition = FormStartPosition.CenterScreen}
            Me.KeyPreview = False
            If frmCons.ShowDialog() = Windows.Forms.DialogResult.OK Then
                m_earticulos = frmCons.Articulo
                setProducto(True)
                Me.KeyPreview = True
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar productos", ex)
        End Try
    End Sub

    Private Sub txtBusqueda_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda para los registros de compra", ex)
      End Try
   End Sub

   Private Sub txtBusNumero_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusNumero.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text, True)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Convert.ToString(Text)), "No se puede cargar la ayuda para los registros de compra", ex)
      End Try
   End Sub

   Private Sub actxaNroDocProveedor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocRemitente.ACAyudaClick
      Try
         AyudaEntidad(actxaNroDocRemitente.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Clientes, TEnvio.Remitente)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaDescCliente_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescRemitente.ACAyudaClick
      Try
         AyudaEntidad(actxaDescRemitente.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Clientes, TEnvio.Remitente)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaDescConductor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescConductor.ACAyudaClick
      Try
         AyudaEntidad(actxaDescConductor.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Conductores)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar conductoR", ex)
      End Try
   End Sub

   Private Sub actxaCodVehiculo_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCodVehiculo.ACAyudaClick
      'Try
      '   AyudaVehiculo(actxaCodVehiculo.Text, "VEHIC_Id")
      'Catch ex As Exception
      '   ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Vehiculo", ex)
        'End Try
        Try
            AyudaVehiculo(actxaCodVehiculo.Text, "VEHIC_Placa")
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar vehiculo", ex)
        End Try
   End Sub

   Private Sub actxaDescVehiculo_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescVehiculo.ACAyudaClick
      Try
         AyudaVehiculo(actxaDescVehiculo.Text, "VEHIC_Placa")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar veHiculo", ex)
      End Try
   End Sub

   Private Sub actxaNroDocConductor_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocConductor.ACAyudaClick
      Try
            AyudaEntidad(actxaNroDocConductor.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Conductores) 'AQUI SUPUESTAMENTE ABRE UN MINIFORMULARIO PARA BUSCAR 
        Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Conductor", ex)
      End Try
   End Sub

    Private Sub actxaDescTransportista_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescTransportista.ACAyudaClick
        Try
            AyudaEntidad(actxaDescTransportista.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Transportista)
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Transportista", ex)
        End Try
    End Sub

    Private Sub actxaNroDocTransportista_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocTransportista.ACAyudaClick
      Try
         AyudaEntidad(actxaNroDocTransportista.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Transportista)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar transportista", ex)
      End Try
   End Sub

#End Region

#Region "toolbar"

   Private Sub actool_ACBtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnImprimir_Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Imprimir Guia: {0}", Me.Text) _
             , String.Format("Desea imprimir la Guia: {0}-{1}", m_etran_guiastransportista.GTRAN_Serie, m_etran_guiastransportista.GTRAN_Numero.ToString("0000000")) _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            Dim _print As New Impresion(tscmbImpresora.Text)
            _print.Print_GuiaTransportista(CType(bs_etran_guiastransportista.Current, ETRAN_GuiasTransportista).GTRAN_Codigo)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Imprimir Guia", ex)
      End Try
   End Sub

   Private Sub actsbtnPrevisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actsbtnPrevisualizar.Click
      Try
         Dim x_gtran_codigo As String = CType(bs_etran_guiastransportista.Current, ETRAN_GuiasTransportista).GTRAN_Codigo
         Dim m_bGenerarGuias As New ACBTransporte.BGenerarGuias()
            ' If m_bGenerarGuias.GuiaTransportista(x_gtran_codigo, ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Anulado)) Then
            If m_bGenerarGuias.CargarGuiaTransportista(x_gtran_codigo) Then
                'Dim m_bdetaguia As New BTRAN_GuiasTransportistaDetalles()
                'Dim _detwhere As New Hashtable()
                ' _detwhere.Add("GTRAN_Codigo", New ACWhere(x_gtran_codigo, ACWhere.TipoWhere.Igual))
                ' If m_bdetaguia.CargarTodos(_detwhere) Then
                ' m_bGenerarGuias.TRAN_GuiasTransportista.ListETRAN_GuiasTransportistaDetalles = m_bdetaguia.ListTRAN_GuiasTransportistaDetalles
                m_etran_guiastransportista = m_bGenerarGuias.TRAN_GuiasTransportista

                actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
                setInstancia(ACUtilitarios.ACSetInstancia.Previsualizar)

                tabMantenimiento.SelectedTab = tabDatos

                cmbDestinoDepartamento.SelectedValue = m_etran_guiastransportista.UBIGO_CodigoDestinatario.Substring(0, 2)
                cmbDestinoProvincia.SelectedValue = m_etran_guiastransportista.UBIGO_CodigoDestinatario.Substring(0, 5)

                cmbOrigenDepartamento.SelectedValue = m_etran_guiastransportista.UBIGO_CodigoRemitente.Substring(0, 2)
                cmbOrigenProvincia.SelectedValue = m_etran_guiastransportista.UBIGO_CodigoRemitente.Substring(0, 5)

                If Not IsNothing(m_etran_guiastransportista.GTRAN_NroComprobantePago) Then
                    cmbDocVenta.SelectedValue = String.Format("{0}{1}", ETipos.getCodTipo(ETipos.MyTipos.TipoDocComprobante), m_etran_guiastransportista.GTRAN_NroComprobantePago.Substring(0, 2))
                    txtDVSerie.Text = m_etran_guiastransportista.GTRAN_NroComprobantePago.Substring(2, 3)
                    actxnDVNumero.Text = m_etran_guiastransportista.GTRAN_NroComprobantePago.Substring(5)
                End If

                
                actxaNroDocConductor.Text = m_etran_guiastransportista.ENTID_CodigoConductor
                actxaDescConductor.Text = m_etran_guiastransportista.ENTID_Conductor

                actxaNroDocTransportista.Text = m_etran_guiastransportista.ENTID_CodigoTransportista
                actxaDescTransportista.Text = m_etran_guiastransportista.ENTID_Transportista

                txtLicencia.Text = m_etran_guiastransportista.GTRAN_LicenciaConductor
                'If IsNothing(m_etran_guiastransportista.RANFL_Certificado) Then
                '    txtCertificado.Text = String.Format("{0}", m_etran_guiastransportista.VEHIC_Certificado)
                'Else
                '    txtCertificado.Text = String.Format("{0}/{1}", m_etran_guiastransportista.VEHIC_Certificado, m_etran_guiastransportista.RANFL_Certificado)
                'End If
                txtCertificado.Text = m_etran_guiastransportista.GTRAN_CertificadosVehiculo

                actxaDescVehiculo.Text = m_etran_guiastransportista.GTRAN_DescripcionVehiculo

                ' actxaNroDocDestinatario.Text = Parametros.GetParametro(EParametros.TipoParametros.Empresa)

                ' actxaDescDestinatario.Text = Parametros.GetParametro(EParametros.TipoParametros.EmpresaRS)


                actxaNroDocTransportista.Text = m_etran_guiastransportista.ENTID_CodigoTransportista
                actxaNroDocConductor.Text = m_etran_guiastransportista.ENTID_CodigoConductor
                'actxaDescRemitente.Text = m_etran_guiastransportista.GTRAN_RemiDescripcionEntidad
                'cmbDirDestino.Text = m_etran_guiastransportista.GTRAN_DireccionDestinatario

                AsignarBinding()



                bs_etran_guiastransportistadetalle = New BindingSource
                bs_etran_guiastransportistadetalle.DataSource = m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles
                bnavProductos.BindingSource = bs_etran_guiastransportistadetalle
                c1grdDetalle.DataSource = bs_etran_guiastransportistadetalle

                'Else
                '    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro, posiblemente haya errores en su creacion")
                'End If
            Else
                ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede cargar el registro, posiblemente haya errores en su creacion")
            End If
        Catch ex As Exception
            actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
            setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso previsualizar hay un Error en el Codigo ", ex)
        End Try
   End Sub

   Private Sub actool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If ACUtilitarios.ACDatosOk(pnlDatos, msg) And Validar(msg) Then
            m_etran_guiastransportista.TIPOS_CodTipoDocumento = cmbGuia.SelectedValue
            m_etran_guiastransportista.GTRAN_Codigo = String.Format("{0}{1}{2}", m_etran_guiastransportista.TIPOS_CodTipoDocumento.Substring(3), m_etran_guiastransportista.GTRAN_Serie, m_etran_guiastransportista.GTRAN_Numero.ToString("0000000"))
            m_etran_guiastransportista.SUCUR_Id = GApp.Sucursal
            m_etran_guiastransportista.ZONAS_Codigo = GApp.Zona
                m_etran_guiastransportista.GTRAN_Serie = cmbSerie.SelectedValue
                m_etran_guiastransportista.GTRAN_DireccionRemitente = cmbDirOrigen.Text & " - " & cmbOrigenDepartamento.Text & " / " & cmbOrigenProvincia.Text & " / " & cmbOrigenDistrito.Text
                m_etran_guiastransportista.GTRAN_DireccionDestinatario = cmbDirDestino.Text & " - " & cmbDestinoDepartamento.Text & " / " & cmbDestinoProvincia.Text & " / " & cmbDestinoDistrito.Text
                m_etran_guiastransportista.GTRAN_Numero = actxnNumero.Text
                m_etran_guiastransportista.GTRAN_CertificadosVehiculo = txtCertificado.Text
                m_etran_guiastransportista.GTRAN_LicenciaConductor = Trim(txtLicencia.Text)

                m_etran_guiastransportista.GTRAN_PesoTotal = actxnPesoTotal.Text

            If Not IsNothing(cmbDocVenta.SelectedValue) Then
                    m_etran_guiastransportista.GTRAN_NroComprobantePago = String.Format("{0}{1}{2}", cmbDocVenta.SelectedValue.ToString().Substring(3, 2) _
                                                                                     , txtDVSerie.Text.PadLeft(4, "0"), actxnDVNumero.Text.ToString().PadLeft(7, "0"))
            End If
                m_etran_guiastransportista.VEHIC_Placa = Trim((((actxaCodVehiculo.Text).Replace("/", "")).Replace(" ", "")).Replace(".", ""))

                m_etran_guiastransportista.UBIGO_CodigoRemitente = txtUbigeoPartida.Text.Replace(".", "")
                m_etran_guiastransportista.UBIGO_CodigoDestinatario = txtUbigeoLlegada.Text.Replace(".", "") 'CType(bs_direcciones.Current, EDirecciones).UBIGO_Codigo
               


            managerGenerarGuias.TRAN_GuiasTransportista = m_etran_guiastransportista
            If managerGenerarGuias.Guardar(GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("Se va ha imprimir la Guia Nro: {0}, coloque la guia en la impresora: {1}", m_etran_guiastransportista.NroGuia, tscmbImpresora.Text))
               Dim _print As New Impresion(tscmbImpresora.Text)
               Try
                  If _print.Print_GuiaTransportista(m_etran_guiastransportista.GTRAN_Codigo) Then
                     ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado/Impreso satisfactoriamente")
                  Else
                     ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente", "No se Imprimio el documento, puede intentarlo nuevamente")
                  End If
               Catch ex As Exception
                  ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente", "No se Imprimio el documento, puede intentarlo nuevamente" & vbNewLine & ex.Message)
               End Try
               actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
               setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
               tabMantenimiento.SelectedTab = tabBusqueda

               btnConsultar_Click(Nothing, Nothing)
            End If
         Else
            actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede grabar", msg)
         End If
      Catch ex As Exception
         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso grabar Guia de Remision", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles actool.ACBtnSalir_Click
      Me.Close()
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         setInstancia(ACUtilitarios.ACSetInstancia.Deshacer)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cancelar la Cotización/Pedido", ex)
      End Try
   End Sub
    'BOTON DE NUEVO
    Private Sub acTool_ACBtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actool.ACBtnNuevo_Click
      Try
            nuevaGuia() 'funcion CREAR NUEVA GUIA 
            '' Activar las opciones generales del teclado
            KeyPreview = True
      Catch ex As Exception
         actool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Nueva Cotización/Pedido", ex)
      End Try
   End Sub


#End Region

#Region " Textos "
   Private Sub txtOpcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpcion.KeyPress
        'Try
        '   Select Case e.KeyChar
        '      Case "+"c
        '         e.Handled = True
        '         If addDetallePedido() Then
        '            actxaProdCodigo.Focus()
        '            txtOpcion.Text = ""
        '            txtOpcion.SelectAll()
        '            setProducto(False)
        '         End If
        '      Case "-"c
        '         e.Handled = True
        '      Case Else
        '         e.Handled = True
        '   End Select
        'Catch ex As Exception
        '   ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso opciones", ex)
        'End Try
       Try
            Select Case e.KeyChar
                Case "+"c
                    If m_modArticulo Then
                        e.Handled = True
                        CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Descripcion = txtProdDescripcion.Text
                        CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Cantidad = actxnProdCantidad.Text
                        CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Peso = actxnProdPeso.Text
                        setProducto(False)
                        calcular()
                        c1grdDetalle.Enabled = True
                        Me.KeyPreview = False
                        m_modArticulo = False
                        c1grdDetalle.AutoSizeCols()
                    Else
                        e.Handled = True
                        If addDetallePedido() Then
                            actxaProdCodigo.Focus()
                            txtOpcion.Text = ""
                            txtOpcion.SelectAll()
                            setProducto(False)

                        End If
                    End If
                    c1grdDetalle.AutoSizeCols()
                Case "-"c
                    e.Handled = True
                    c1grdDetalle.AutoSizeCols()
                Case Else
                    e.Handled = True
            End Select
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso opciones", ex)
        End Try
   End Sub

   Private Sub txtOpcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOpcion.KeyDown
      Try
         Select Case e.KeyData
            Case Keys.Enter
               addDetallePedido()
               setProducto(False)
               'acTool_ACBtnGrabar_Click(Nothing, Nothing)
               Me.KeyPreview = True
               cmbGuia.Focus()
                    m_modArticulo = False
            Case Keys.Escape
               setProducto(False)
               c1grdDetalle.Enabled = True
                    Me.KeyPreview = False
                    m_modArticulo = False
            Case Else

         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede procesar", ex)
      End Try
   End Sub

   Private Sub txtProdDescripcion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProdDescripcion.GotFocus
      Me.KeyPreview = False
   End Sub

   Private Sub txtProdDescripcion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProdDescripcion.LostFocus
      Me.KeyPreview = True
   End Sub

   Private Sub txtProdDescripcion_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProdDescripcion.SizeChanged
      Try
         c1grdDetalle.Cols(2).Width = txtProdDescripcion.Size.Width
      Catch ex As Exception

      End Try
   End Sub

   Private Sub actxaNroDocTransportista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocTransportista.KeyDown
      Try
         If e.KeyData = Keys.Enter Then
            If actxaNroDocTransportista.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
               '' Cargar datos adicionales cliente
               If actxaNroDocTransportista.ACAyuda.Enabled = True Then
                  If managerEntidades.CargarDocIden(actxaNroDocTransportista.Text, EEntidades.TipoInicializacion.Transportista) Then
                     actxaNroDocTransportista.Text = managerEntidades.Entidades.ENTID_NroDocumento
                     m_etran_guiastransportista.ENTID_CodigoTransportista = managerEntidades.Entidades.ENTID_Codigo
                     actxaDescTransportista.Text = managerEntidades.Entidades.ENTID_RazonSocial
                     lblNomConductor.Focus()
                  Else
                     If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                     , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaNroDocTransportista.Text) _
                                     , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        NuevaEntidad(TEnvio.Destinatario, actxaNroDocTransportista.Text, EEntidades.TipoEntidad.Transportista)
                     Else
                        actxaNroDocTransportista.Clear() : actxaDescTransportista.Clear() : lblNomConductor.Focus()
                     End If
                  End If
               End If
            Else
               If actxaNroDocTransportista.Text.Trim().Length > 0 Then
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocTransportista.Text))
                  lblNomConductor.Focus()
               End If
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
      End Try
   End Sub

    Private Sub actxaNroDocConductor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actxaNroDocConductor.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                If actxaNroDocConductor.Text.ToString().Length >= ACETransporte.Constantes.LongitudCodigo Then
                    '' Cargar datos adicionales cliente
                    If actxaNroDocConductor.ACAyuda.Enabled = True Then
                        If managerEntidades.CargarDocIden(actxaNroDocConductor.Text, EEntidades.TipoInicializacion.Transportista) Then
                            actxaNroDocConductor.Text = managerEntidades.Entidades.ENTID_NroDocumento
                            m_etran_guiastransportista.ENTID_CodigoConductor = managerEntidades.Entidades.ENTID_Codigo
                            actxaDescConductor.Text = managerEntidades.Entidades.ENTID_RazonSocial
                            If managerEntidades.CargarConductor(m_etran_guiastransportista.ENTID_CodigoConductor) Then
                                txtLicencia.Text = managerEntidades.Entidades.Conductor.CONDU_Licencia
                            End If
                            lblDescVehiculo.Focus()
                        Else
                            If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Documento de Identidad: {0}", Me.Text) _
                                            , String.Format("El Documento de Identidad {0} no existe, ¿Desea Ingresar la Entidad?", actxaNroDocTransportista.Text) _
                                            , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                                NuevaEntidad(TEnvio.Destinatario, actxaNroDocTransportista.Text, EEntidades.TipoEntidad.Conductores)
                            Else
                                actxaNroDocConductor.Clear() : actxaDescConductor.Clear() : lblDescVehiculo.Focus()
                            End If
                        End If
                    End If
                Else
                    If actxaNroDocTransportista.Text.Trim().Length > 0 Then
                        ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), String.Format("El Documento de Identidad {0} no existe, el documento ingresado tienen menos de 8 numeros", actxaNroDocConductor.Text))
                        lblNomConductor.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Cliente", ex)
        End Try
    End Sub

   Private Sub txtNumeroPedido_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         actool_ACBtnGrabar_Click(Nothing, Nothing)
      End If
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
         If c1grdBusqueda.Rows(e.Row)("GTRAN_Estado") = ETRAN_GuiasTransportista.getEstado(ETRAN_GuiasTransportista.Estado.Anulado) Then
            e.Style = c1grdBusqueda.Styles("Anulado")
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambia de color", ex)
      End Try
   End Sub

    Private Sub c1grdDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1grdDetalle.KeyDown
        Try
            e.SuppressKeyPress = True
            Select Case e.KeyCode
                Case Keys.Enter
                    '  If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Subir Registro: {0}", Me.Text) _
                    ', String.Format("¿Desea Modificar el precio manualmente del producto: {0} ?", "") _
                    ', ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                    'cmbPrecioUnitario.Enabled = True
                    subirItem()
                    c1grdDetalle.Enabled = False
                    actxnProdCantidad.Focus()
                    m_modArticulo = True
                    Me.KeyPreview = True
                    'End If
                Case Keys.Delete
                    If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
                           , String.Format("Desea quitar el Articulo : {0} ", CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles).GTDET_Descripcion) _
                           , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
                        Dim m_det As ETRAN_GuiasTransportistaDetalles = CType(bs_etran_guiastransportistadetalle.Current, ETRAN_GuiasTransportistaDetalles)
                        m_etran_guiastransportista.ListETRAN_GuiasTransportistaDetalles.Remove(m_det)
                        bs_etran_guiastransportistadetalle.ResetBindings(False)
                        calcular()
                    End If

            End Select
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede calcular carga el Item", ex)
        End Try
    End Sub
#End Region

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         'If sender.Name = "txtBusqueda" Then
         '   Exit Sub
         'End If
         'If TypeOf ActiveControl Is ACControles.ACTextBoxAyuda Then
         '   Exit Sub
         'End If
         SendKeys.Send("{TAB}")
      End If
   End Sub

   Private Sub btnNueTransportista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNueTransportista.Click
      NuevaEntidad(TEnvio.Destinatario, "", EEntidades.TipoEntidad.Transportista)
   End Sub

   Private Sub btnNuevConductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevConductor.Click
      NuevaEntidad(TEnvio.Destinatario, "", EEntidades.TipoEntidad.Conductores)
   End Sub

   Private Sub btnNueRemitente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNueRemitente.Click
      NuevaEntidad(TEnvio.Remitente, "", EEntidades.TipoEntidad.Proveedores)
   End Sub

   Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleanRemitente.Click
      Try
         m_etran_guiastransportista.ENTID_Codigo = ""
         actxaDescRemitente.Clear() : actxaNroDocRemitente.Clear()
         'If Not IsNothing(bs_almacenesOrigen) Then RemoveHandler bs_almacenesOrigen.CurrentChanged, AddressOf bs_almacenOrigen_CurrentChanged
         cmbDirOrigen.DataSource = Nothing
         pnlItem.Enabled = False
         setRolRemitente(ACETransporte.Constantes.Seteo.Activar)
         actxaNroDocRemitente.Focus()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Limpiar Entidad", ex)
      End Try
   End Sub

#End Region

   Private Sub actxaRucDestinatario_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaNroDocDestinatario.ACAyudaClick
      Try
         AyudaEntidad(actxaNroDocDestinatario.Text, "ENTID_NroDocumento", EEntidades.TipoEntidad.Clientes, TEnvio.Destinatario)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub actxaRazSocDestinatario_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescDestinatario.ACAyudaClick
      Try
         AyudaEntidad(actxaDescDestinatario.Text, "ENTID_RazonSocial", EEntidades.TipoEntidad.Clientes, TEnvio.Destinatario)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cargar Cliente", ex)
      End Try
   End Sub

   Private Sub bs_cmborigen_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_dirorigen.Current) Then
            If IsNothing(CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo) Then
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "La dirección actual no tiene un ubigeo definido, por favor selecione uno para su impresión")
            Else
               cmbOrigenDepartamento.SelectedValue = CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 2)
               cmbOrigenProvincia.SelectedValue = CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 5)
               cmbOrigenDistrito.SelectedValue = CType(cmbDirOrigen.SelectedItem, EDirecciones).UBIGO_Codigo
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cambiando de direccion", ex)
      End Try
   End Sub

   Private Sub bs_cmbdestino_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_dirdestino.Current) Then
            If IsNothing(CType(cmbDirDestino.SelectedItem, EDirecciones).UBIGO_Codigo) Then
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "La dirección actual no tiene un ubigeo definido, por favor selecione uno para su impresión")
            Else
               cmbDestinoDepartamento.SelectedValue = CType(cmbDirDestino.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 2)
               cmbDestinoProvincia.SelectedValue = CType(cmbDirDestino.SelectedItem, EDirecciones).UBIGO_Codigo.Substring(0, 5)
               cmbDestinoDistrito.SelectedValue = CType(cmbDirDestino.SelectedItem, EDirecciones).UBIGO_Codigo
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso cambiando de direccion", ex)
      End Try
   End Sub

   Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
      Try
         Dim _frmEntidad As New MEntidad(m_etran_guiastransportista.ENTID_CodigoTransportista, MEntidad.Inicio.Normal, EEntidades.TipoEntidad.Transportista) With {.StartPosition = FormStartPosition.CenterScreen}
         If _frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then

         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar al Transportista", ex)
      End Try
   End Sub

   Private Sub btnModConductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModConductor.Click
      Try
         Dim _frmEntidad As New MEntidad(m_etran_guiastransportista.ENTID_CodigoConductor, MEntidad.Inicio.Normal, EEntidades.TipoEntidad.Conductores) With {.StartPosition = FormStartPosition.CenterScreen}
         If _frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then

         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar el conductor", ex)
      End Try
   End Sub

   Private Sub btnModRemitente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModRemitente.Click
      Try
         Dim _frmEntidad As New MEntidad(m_etran_guiastransportista.ENTID_CodigoRemitente, MEntidad.Inicio.Normal, EEntidades.TipoEntidad.Clientes) With {.StartPosition = FormStartPosition.CenterScreen}
         If _frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then

         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar el conductor", ex)
      End Try
   End Sub

   Private Sub btnNuevoDestinatario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoDestinatario.Click
      NuevaEntidad(TEnvio.Destinatario, "", EEntidades.TipoEntidad.Proveedores)
   End Sub

   Private Sub btnModDestinatario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModDestinatario.Click
      Try
         Dim _frmEntidad As New MEntidad(m_etran_guiastransportista.ENTID_CodigoDestinatario, MEntidad.Inicio.Normal, EEntidades.TipoEntidad.Clientes) With {.StartPosition = FormStartPosition.CenterScreen}
         If _frmEntidad.ShowDialog() = Windows.Forms.DialogResult.OK Then

         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Modificar el conductor", ex)
      End Try
   End Sub

   Private Sub btnCleanDestinatario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleanDestinatario.Click
      Try
         m_etran_guiastransportista.ENTID_CodigoDestinatario = ""
         actxaDescDestinatario.Clear() : actxaNroDocDestinatario.Clear()
         'If Not IsNothing(bs_almacenesOrigen) Then RemoveHandler bs_almacenesOrigen.CurrentChanged, AddressOf bs_almacenOrigen_CurrentChanged
         cmbDirDestino.DataSource = Nothing
         pnlItem.Enabled = False
         setRolDestinatario(ACETransporte.Constantes.Seteo.Activar)
         actxaNroDocDestinatario.Focus()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Limpiar Entidad", ex)
      End Try
   End Sub

   Private Sub tscmbImpresora_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmbImpresora.DropDown
      Try
         If IsNothing(Colecciones.ListPrinter) Then
            Colecciones.CargarImpresoras()
         End If
         ACFramework.ACUtilitarios.ACCargaCombo(tscmbImpresora.ComboBox, Colecciones.ListPrinter, "DeviceName", "DeviceName")
      Catch ex As Exception

      End Try
   End Sub


    Private Sub PGuiaRemiTransportista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmbOrigenDistrito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrigenDistrito.SelectedIndexChanged

        txtUbigeoPartida.Text = cmbOrigenDistrito.SelectedValue

    End Sub

    Private Sub cmbDestinoDistrito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDestinoDistrito.SelectedIndexChanged
        txtUbigeoLlegada.Text = cmbDestinoDistrito.SelectedValue
    End Sub

    Private Sub txtOpcion_TextChanged(sender As Object, e As EventArgs) Handles txtOpcion.TextChanged

    End Sub
   
End Class