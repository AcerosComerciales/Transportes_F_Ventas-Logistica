Imports ACBTransporte
Imports ACETransporte
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid
Imports ACBVentas
Imports ACEVentas

Public Class FMovimientoNeumatico
#Region " Variables "
   Private managerDocumentos As BDocumentos
   Private managerTRAN_Neumaticos As BTRAN_Neumaticos
   Private managerMovimientosNeumaticos As BMovimientosNeumaticos
   Private managerTRAN_MovimientosNeumaticos As BTRAN_MovimientosNeumaticos
   Private managerEntidades As BEntidades
   Private managerAlmacenes As BAlmacenes
   Private managerTRAN_Vehiculos As BTRAN_Vehiculos
   Private managerTRAN_Ranflas As BTRAN_Ranflas

   Private m_listBindHelper As List(Of ACBindHelper)
   Private m_listBHNeumaticos As List(Of ACBindHelper)

   Private m_edocumentos As EDocumentos
   Private m_listTRAN_Neumaticos As List(Of ETRAN_Neumaticos)
   Private m_listNoAsignadosTRAN_Neumaticos As List(Of ETRAN_Neumaticos)
   Private m_etran_neumaticos As ETRAN_Neumaticos
   'Private m_etran_movimientosneumaticos As ETRAN_MovimientosNeumaticos

   Private m_destino As BConstantes.TipoDestino

   Private bs_bdocumentos As BindingSource
   Private bs_tran_neumaticos As BindingSource
   Private bs_noAsignados As BindingSource
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         tabMantenimiento.HideTabsMode = Crownwood.DotNetMagic.Controls.HideTabsModes.HideAlways
         tabMantenimiento.SelectedTab = tabBusqueda
         formatearGrilla()
         cargarCombos()
         managerDocumentos = New BDocumentos
         managerMovimientosNeumaticos = New BMovimientosNeumaticos
         managerTRAN_MovimientosNeumaticos = New BTRAN_MovimientosNeumaticos
         managerTRAN_Neumaticos = New BTRAN_Neumaticos
         managerEntidades = New BEntidades
         managerAlmacenes = New BAlmacenes
         managerTRAN_Vehiculos = New BTRAN_Vehiculos
         managerTRAN_Ranflas = New BTRAN_Ranflas

         eprError.SetError(cmbTipoDocumento, "Campo Obligatorio")
         eprError.SetError(txtDescripcion, "Campo Obligatorio")
         eprError.SetError(txtContenido, "Campo Obligatorio")

         grpNuevPosicion.Enabled = False
         acTool.ACBtnModificarVisible = False
         acTool.ACBtnEliminarEnabled = False
         acTool.ACBtnModificarEnabled = False

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
#Region " Utilitarios "
   ' <summary>
   ' Dar Formato a la grilla de busqueda
   ' </summary>
   ' <remarks></remarks>
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 5, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Codigo", "DOCMT_NRO_Text", "DOCMT_NRO_Text", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "T. Documento", "TIPO_DOCUMENTO", "TIPO_DOCUMENTO", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Descripción", "DOCMT_Descripcion", "DOCMT_Descripcion", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, index, "Fecha", "DOCMT_Fecha", "DOCMT_Fecha", 150, True, False, "System.String", "") : index += 1
         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdNeumaticos, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Codigo", "NEUMA_Codigo", "NEUMA_Codigo", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Sección", "VNEUM_SECCION_Text", "VNEUM_SECCION_Text", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Posición", "VNEUM_OrdenPosicion", "VNEUM_OrdenPosicion", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Lado", "VNEUM_LADO_Text", "VNEUM_LADO_Text", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Interno/Externo", "VNEUM_INTERNOEXTERNO_Text", "VNEUM_INTERNOEXTERNO_Text", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Marca", "TIPO_Marca", "TIPO_Marca", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Modelo", "NEUMA_Modelo", "NEUMA_Modelo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Tipo Llanda", "TIPO_Llanta", "TIPO_Llanta", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Kilometraje", "NEUMA_KmVidaUtil", "NEUMA_KmVidaUtil", 100, True, True, "System.Decimal", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNeumaticos, index, "Compra", "NEUMA_FecCompra", "NEUMA_FecCompra", 100, True, True, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         c1grdNeumaticos.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdNeumaticos.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdNeumaticos.AllowEditing = False
         c1grdNeumaticos.AutoResize = True
         c1grdNeumaticos.AutoSizeCols()

         index = 1
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdNoAsignados, 1, 1, 11, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Codigo", "NEUMA_Codigo", "NEUMA_Codigo", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Sección", "VNEUM_SECCION_Text", "VNEUM_SECCION_Text", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Posición", "VNEUM_OrdenPosicion", "VNEUM_OrdenPosicion", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Lado", "VNEUM_LADO_Text", "VNEUM_LADO_Text", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Interno/Externo", "VNEUM_INTERNOEXTERNO_Text", "VNEUM_INTERNOEXTERNO_Text", 100, True, True, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Marca", "TIPO_Marca", "TIPO_Marca", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Modelo", "NEUMA_Modelo", "NEUMA_Modelo", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Tipo Llanda", "TIPO_Llanta", "TIPO_Llanta", 150, True, False, "System.String", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Kilometraje", "NEUMA_KmVidaUtil", "NEUMA_KmVidaUtil", 100, True, True, "System.Decimal", "") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdNoAsignados, index, "Compra", "NEUMA_FecCompra", "NEUMA_FecCompra", 100, True, True, "System.DateTime", Parametros.GetParametro(EParametros.TipoParametros.pg_FormatoFecha)) : index += 1
         c1grdNoAsignados.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdNoAsignados.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdNoAsignados.AllowEditing = False
         c1grdNoAsignados.AutoResize = True
         c1grdNoAsignados.AutoSizeCols()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub cargarCombos()
      Try
         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoDocumento, Colecciones.Tipos(ETipos.MyTipos.TipoDocumentoInterno), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoUbicacion, Colecciones.Tipos(ETipos.MyTipos.TipoOrigenDestino), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(cmbLado, Colecciones.ListLadosNeumatico, ACLista.Descripcion, ACLista.Codigo)
         ACFramework.ACUtilitarios.ACCargaCombo(cmbIntExt, Colecciones.ListIntExtNeumatico, ACLista.Descripcion, ACLista.Codigo)
         ACFramework.ACUtilitarios.ACCargaCombo(cmbSeccion, Colecciones.ListSeccionNeumatico, ACLista.Descripcion, ACLista.Codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setInstancia(ByVal _opcion As ACFramework.ACUtilitarios.ACSetInstancia)
      Select Case _opcion
         Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
            grpPosicionActual.Visible = True
            ACFramework.ACUtilitarios.ACSetControl(grpDocumento, True)
            ACFramework.ACUtilitarios.ACLimpiaVar(grpDocumento)
            acTool.ACBtnEliminarVisible = False
            ToolStrip2.Enabled = True
            tsbOpciones.Enabled = True
            tsbtnRevisar.Visible = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
            grpPosicionActual.Visible = False
            ACFramework.ACUtilitarios.ACSetControl(pnlDatos, False)
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Nuevo)
            acTool.ACBtnGrabarVisible = False
            acTool.ACBtnEliminarVisible = False
            acTool.ACBtnBuscarVisible = False
            acTool.ACBtnVolverVisible = False
            tsbtnRevisar.Visible = False
            ToolStrip2.Enabled = False
            tsbOpciones.Enabled = False
            tsbtnRevisar.Visible = False
         Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar, ACFramework.ACUtilitarios.ACSetInstancia.Deshacer
            acTool.ACBtnModificarVisible = False
            acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
            tsbtnRevisar.Visible = True
      End Select
   End Sub

   Private Sub setInstanciaUbicacion(ByVal x_opcion As ACFramework.ACUtilitarios.ACSetInstancia)
      Try
         actxaPara.Enabled = True
         actxParaDesc.Enabled = True
         Select Case x_opcion
            Case ACFramework.ACUtilitarios.ACSetInstancia.Nuevo
               grpNuevPosicion.Enabled = True
               pnlSeleccionados.Enabled = False

               tsbtnGrabarUbicacion.Enabled = True
               tsbtnModificarUbicacion.Visible = False
               tsbtnCancelarUbicacion.Visible = True

               eprError.Clear()
               eprError.SetError(cmbTipoDocumento, "Campo Obligatorio")
               eprError.SetError(txtDescripcion, "Campo Obligatorio")
               eprError.SetError(txtNroDocumento, "Campo Obligatorio")
               eprError.SetError(txtContenido, "Campo Obligatorio")

               eprError.SetError(cmbLado, "Campo Obligatorio")
               eprError.SetError(cmbSeccion, "Campo Obligatorio")
               eprError.SetError(cmbIntExt, "Campo Obligatorio")
               eprError.SetError(cmbTipoUbicacion, "Campo Obligatorio")
               eprError.SetError(nupPosicion, "Campo Obligatorio")

               RemoveHandler cmbTipoUbicacion.SelectedIndexChanged, AddressOf cmbTipoUbicacion_SelectedIndexChanged
               cmbIntExt.SelectedIndex = -1
               cmbLado.SelectedIndex = -1
               cmbSeccion.SelectedIndex = -1
               cmbTipoUbicacion.SelectedIndex = -1
               actxaPara.Text = ""
               actxParaDesc.Text = ""
               txtDestino.Clear()
               txtGlosa.Clear()
               txtMotivo.Clear()
               AddHandler cmbTipoUbicacion.SelectedIndexChanged, AddressOf cmbTipoUbicacion_SelectedIndexChanged
               cmbTipoUbicacion.Enabled = True
            Case ACFramework.ACUtilitarios.ACSetInstancia.Deshacer
               grpNuevPosicion.Enabled = False
               pnlSeleccionados.Enabled = True

               tsbtnGrabarUbicacion.Enabled = False
               tsbtnModificarUbicacion.Visible = True
               tsbtnCancelarUbicacion.Visible = False

               eprError.Clear()
               eprError.SetError(cmbTipoDocumento, "Campo Obligatorio")
               eprError.SetError(txtDescripcion, "Campo Obligatorio")
               eprError.SetError(txtNroDocumento, "Campo Obligatorio")
               eprError.SetError(txtContenido, "Campo Obligatorio")
            Case ACFramework.ACUtilitarios.ACSetInstancia.Guardar
               grpNuevPosicion.Enabled = False
               pnlSeleccionados.Enabled = True

               tsbtnGrabarUbicacion.Enabled = False
               tsbtnModificarUbicacion.Visible = True
               tsbtnCancelarUbicacion.Visible = False

               eprError.Clear()
               eprError.SetError(cmbTipoDocumento, "Campo Obligatorio")
               eprError.SetError(txtDescripcion, "Campo Obligatorio")
               eprError.SetError(txtNroDocumento, "Campo Obligatorio")
               eprError.SetError(txtContenido, "Campo Obligatorio")
            Case ACFramework.ACUtilitarios.ACSetInstancia.Modificado
               grpNuevPosicion.Enabled = True
               pnlSeleccionados.Enabled = False

               tsbtnGrabarUbicacion.Enabled = True
               tsbtnModificarUbicacion.Visible = False
               tsbtnCancelarUbicacion.Visible = True

               eprError.Clear()
               eprError.SetError(cmbTipoDocumento, "Campo Obligatorio")
               eprError.SetError(txtDescripcion, "Campo Obligatorio")
               eprError.SetError(txtNroDocumento, "Campo Obligatorio")
               eprError.SetError(txtContenido, "Campo Obligatorio")

               eprError.SetError(cmbLado, "Campo Obligatorio")
               eprError.SetError(cmbSeccion, "Campo Obligatorio")
               eprError.SetError(cmbIntExt, "Campo Obligatorio")
               eprError.SetError(cmbTipoUbicacion, "Campo Obligatorio")
               eprError.SetError(nupPosicion, "Campo Obligatorio")
            Case Else

         End Select

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

#Region " Cargar Datos "
   ' <summary>
   ' Cargar los datos en el control Visual C1FlexGrid
   ' </summary>
   Private Sub cargarDatos()
      Try
         bs_bdocumentos = New BindingSource()
         bs_bdocumentos.DataSource = managerDocumentos.getListDocumentos
         c1grdBusqueda.DataSource = bs_bdocumentos
         bnavBusqueda.BindingSource = bs_bdocumentos
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ' <summary>
   ' Realiza el enlace de los controles visuales con la clase esquema
   ' </summary>
   Private Sub AsignarBinding()
      Try
         m_listBindHelper = New List(Of ACBindHelper)()
         m_listBindHelper.Add(ACBindHelper.ACBind(txtNroDocumento, "Text", m_edocumentos, "DOCMT_Nro"))
         m_listBindHelper.Add(ACBindHelper.ACBind(cmbTipoDocumento, "SelectedValue", m_edocumentos, "TIPOS_CodTipoDocumento"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtDescripcion, "Text", m_edocumentos, "DOCMT_Descripcion"))
         If m_edocumentos.DOCMT_Fecha.Year < 1700 Then m_edocumentos.DOCMT_Fecha = DateTime.Now
         m_listBindHelper.Add(ACBindHelper.ACBind(dtpFecha, "Value", m_edocumentos, "DOCMT_Fecha"))
         m_listBindHelper.Add(ACBindHelper.ACBind(txtContenido, "Text", m_edocumentos, "DOCMT_Contenido"))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub SetUbicacionNeumaticos()
      Try
         If Not IsNothing(m_etran_neumaticos.TRAN_MovimientosNeumaticos.TIPOS_CodDestino) Then : cmbTipoUbicacion.SelectedValue = m_etran_neumaticos.TRAN_MovimientosNeumaticos.TIPOS_CodDestino
         Else : cmbTipoUbicacion.SelectedIndex = -1
         End If
         actxaPara.Text = m_etran_neumaticos.TRAN_MovimientosNeumaticos.MOVNM_IdDestino
         actxParaDesc.Text = m_etran_neumaticos.TRAN_MovimientosNeumaticos.Destino
         If Not IsNothing(m_etran_neumaticos.TRAN_VehiculosNeumaticos.VNEUM_Lado) Then : cmbLado.SelectedValue = m_etran_neumaticos.TRAN_VehiculosNeumaticos.VNEUM_Lado
         Else : cmbLado.SelectedIndex = -1
         End If
         If Not IsNothing(m_etran_neumaticos.TRAN_VehiculosNeumaticos.VNEUM_Seccion) Then : cmbSeccion.SelectedValue = m_etran_neumaticos.TRAN_VehiculosNeumaticos.VNEUM_Seccion
         Else : cmbSeccion.SelectedIndex = -1
         End If
         nupPosicion.Value = m_etran_neumaticos.TRAN_VehiculosNeumaticos.VNEUM_OrdenPosicion
         If Not IsNothing(m_etran_neumaticos.TRAN_VehiculosNeumaticos.VNEUM_InternoExterno) Then : cmbIntExt.SelectedValue = m_etran_neumaticos.TRAN_VehiculosNeumaticos.VNEUM_InternoExterno
         Else : cmbIntExt.SelectedIndex = -1
         End If
         txtDestino.Text = m_etran_neumaticos.TRAN_MovimientosNeumaticos.MOVNM_UbicacionDestino
         txtGlosa.Text = m_etran_neumaticos.TRAN_MovimientosNeumaticos.MOVNM_Glosa
         txtMotivo.Text = m_etran_neumaticos.TRAN_MovimientosNeumaticos.MOVNM_Motivo
         chkRepuesto.Checked = m_etran_neumaticos.TRAN_VehiculosNeumaticos.VNEUM_Repuesto
      Catch ex As Exception
         'Throw ex
      End Try
   End Sub

   Private Sub GetUbicacionNeumaticos()
      Try
         If IsNothing(m_etran_neumaticos) Then m_etran_neumaticos = New ETRAN_Neumaticos()
         If IsNothing(m_etran_neumaticos.TRAN_MovimientosNeumaticos) Then m_etran_neumaticos.TRAN_MovimientosNeumaticos = New ETRAN_MovimientosNeumaticos()
         If IsNothing(m_etran_neumaticos.TRAN_VehiculosNeumaticos) Then m_etran_neumaticos.TRAN_VehiculosNeumaticos = New ETRAN_VehiculosNeumaticos()
         Select Case cmbTipoUbicacion.SelectedValue.ToString()
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Almacen) _
            , BConstantes.getOrigenDestino(BConstantes.TipoDestino.Proveedor)
               CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.TDestino = BConstantes.TipoDestino.Almacen
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Ranfla)
               CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.TDestino = BConstantes.TipoDestino.Ranfla
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Vehiculo)
               CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.TDestino = BConstantes.TipoDestino.Vehiculo
         End Select
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.TIPOS_CodDestino = cmbTipoUbicacion.SelectedValue
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.MOVNM_IdDestino = actxaPara.Text
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.Destino = actxParaDesc.Text
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_VehiculosNeumaticos.VNEUM_Lado = cmbLado.SelectedValue
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_VehiculosNeumaticos.VNEUM_Seccion = cmbSeccion.SelectedValue
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_VehiculosNeumaticos.VNEUM_OrdenPosicion = nupPosicion.Value
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_VehiculosNeumaticos.VNEUM_InternoExterno = cmbIntExt.SelectedValue
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.MOVNM_UbicacionDestino = txtDestino.Text
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.MOVNM_Glosa = txtGlosa.Text
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.MOVNM_Motivo = txtMotivo.Text
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovimientosNeumaticos.TIPOS_CodOrigen = m_etran_neumaticos.TRAN_MovNeumaAnterior.TIPOS_CodOrigen
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_VehiculosNeumaticos.VNEUM_Repuesto = chkRepuesto.Checked
         CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).TRAN_MovNeumaAnterior = m_etran_neumaticos.TRAN_MovNeumaAnterior
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub UBNeumaticos()
      Try
         If Not IsNothing(m_listBHNeumaticos) Then
            For Each Item As ACBindHelper In m_listBHNeumaticos
               Item.ACUnBind()
            Next
         End If
         m_listBHNeumaticos = New List(Of ACBindHelper)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub ABNeumaticos()
      Try
         m_listBHNeumaticos = New List(Of ACBindHelper)()
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(cmbTipoUbicacion, "SelectedValue", m_etran_neumaticos.TRAN_MovimientosNeumaticos, "TIPOS_CodDestino"))
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(actxaPara, "Text", m_etran_neumaticos.TRAN_MovimientosNeumaticos, "MOVNM_IdDestino"))
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(cmbLado, "SelectedValue", m_etran_neumaticos.TRAN_VehiculosNeumaticos, "VNEUM_Lado"))
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(cmbSeccion, "SelectedValue", m_etran_neumaticos.TRAN_VehiculosNeumaticos, "VNEUM_Seccion"))
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(nupPosicion, "Value", m_etran_neumaticos.TRAN_VehiculosNeumaticos, "VNEUM_OrdenPosicion"))
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(cmbIntExt, "SelectedValue", m_etran_neumaticos.TRAN_VehiculosNeumaticos, "VNEUM_InternoExterno"))
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(txtDestino, "Text", m_etran_neumaticos.TRAN_MovimientosNeumaticos, "MOVNM_UbicacionOrigen"))
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(txtGlosa, "Text", m_etran_neumaticos.TRAN_MovimientosNeumaticos, "MOVNM_Glosa"))
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(txtMotivo, "Text", m_etran_neumaticos.TRAN_MovimientosNeumaticos, "MOVNM_Motivo"))
         m_listBHNeumaticos.Add(ACBindHelper.ACBind(chkRepuesto, "Checked", m_etran_neumaticos.TRAN_VehiculosNeumaticos, "VNEUM_Repuesto"))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cargar()
      Try
         If bs_bdocumentos.Current IsNot Nothing Then
            Dim x_codigo As Integer = CType(bs_bdocumentos.Current, EDocumentos).DOCMT_Id
            managerMovimientosNeumaticos.cargarMovDocumento(x_codigo)
            m_listTRAN_Neumaticos = managerMovimientosNeumaticos.ListTRAN_Neumaticos
            m_edocumentos = managerMovimientosNeumaticos.Documentos
            m_edocumentos.Instanciar(ACEInstancia.Consulta)
            AsignarBinding()
            tabMantenimiento.SelectedTab = tabDatos
            setDatos()
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantVertical.TipoInstancia.Cancelar)
         Throw ex
      End Try
   End Sub

   Private Sub setDatos()
      Try
         bs_tran_neumaticos = New BindingSource()
         bs_tran_neumaticos.DataSource = m_listTRAN_Neumaticos
         c1grdNeumaticos.DataSource = bs_tran_neumaticos
         bnavNeumaticos.BindingSource = bs_tran_neumaticos
         AddHandler bs_tran_neumaticos.CurrentChanged, AddressOf bs_tran_neumaticos_CurrentChanged
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ' <summary>
   ' Ejecutar la busqueda de una cadena en la tabla Neumaticos
   ' </summary>
   ' <param name="x_cadena">Cadena objetivo</param>
   ' <returns></returns>
   Private Function busqueda(ByVal x_cadena As String) As Boolean
      Try
         If managerDocumentos.Busqueda(x_cadena, getCampo()) Then
            acTool.ACBtnEliminarEnabled = True
            acTool.ACBtnModificarEnabled = True
         Else
            acTool.ACBtnEliminarEnabled = False
            acTool.ACBtnModificarEnabled = False
         End If
         cargarDatos()
         Return acTool.ACBtnModificarEnabled
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
      End Try
      Return False
   End Function

   Private Sub cargarUbicacion(ByVal x_neuma_id As Long)
      Try
         Dim _tipoUbicacion As String = ""
         Dim _ubicacion As String = ""
         Dim _movneu As New ETRAN_MovimientosNeumaticos
         If managerTRAN_MovimientosNeumaticos.CargarUbicacion(x_neuma_id, _movneu, _tipoUbicacion, _ubicacion) Then
            txtTipoUbicacion.Text = _tipoUbicacion
            txtUbicacion.Text = _ubicacion
            m_etran_neumaticos.TRAN_MovNeumaAnterior = _movneu
         Else
            txtTipoUbicacion.Text = ""
            txtUbicacion.Text = ""
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub bs_tran_neumaticos_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_tran_neumaticos.Current) Then
            'UBNeumaticos()
            m_etran_neumaticos = New ETRAN_Neumaticos(ETRAN_Neumaticos.TipoInicializacion.Movimientos)
            m_etran_neumaticos = CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).Clone()
            txtLado.Text = m_etran_neumaticos.VNEUM_LADO_Text
            txtSeccion.Text = m_etran_neumaticos.VNEUM_SECCION_Text
            txtIntExt.Text = m_etran_neumaticos.VNEUM_INTERNOEXTERNO_Text
            txtPosicion.Text = m_etran_neumaticos.VNEUM_OrdenPosicion
            Dim _lado As String = m_etran_neumaticos.VNEUM_Lado
            Dim _intext As String = m_etran_neumaticos.VNEUM_InternoExterno
            Dim _seccion As String = m_etran_neumaticos.VNEUM_Seccion
            Dim _posicion As String = m_etran_neumaticos.VNEUM_OrdenPosicion.ToString()
            acVehActual.setColor(_seccion & _lado & _intext & _posicion)
            setColor()
            Dim _neuma_id As Long = m_etran_neumaticos.NEUMA_Id
            cargarUbicacion(_neuma_id)
            SetUbicacionNeumaticos()
            setInstanciaUbicacion(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
         Else
            setInstanciaUbicacion(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

   Private Function getCampo() As String
      Try
         If (rbtnCodigo.Checked) Then
            Return "DOCMT_Nro"
         ElseIf rbtnDescripcion.Checked Then
            Return "DOCMT_Descripcion"
         Else
            Return "DOCMT_Nro"
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub AyudaDestino(ByVal x_valor As String, ByVal x_columna As String)
      Try
         Dim m_datos As New DataTable()
         Dim _where As New Hashtable
         Dim _campo As String = ""
         Dim _campoCodigo As String = "Interno"
         _where.Add(x_columna, New ACFramework.ACWhere(x_valor, ACFramework.ACWhere.TipoWhere._Like))
         Select Case cmbTipoUbicacion.SelectedValue.ToString()
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Almacen)
               managerAlmacenes.Ayuda(_where)
               m_datos = managerAlmacenes.DTAlmacenes
               _campo = "Descripción"
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Proveedor)
               managerEntidades.Ayuda(_where, EEntidades.TipoEntidad.Proveedores)
               m_datos = managerEntidades.DTEntidades
               _campo = "Razon Social"
               _campoCodigo = "Codigo"
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Ranfla)
               managerTRAN_Ranflas.Ayuda(_where)
               m_datos = managerTRAN_Ranflas.DTTRAN_Ranflas
               _campo = "Placa"
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Vehiculo)
               managerTRAN_Vehiculos.Ayuda(_where)
               m_datos = managerTRAN_Vehiculos.DTTRAN_Vehiculos
               _campo = "Placa"
            Case Else
               managerAlmacenes.Ayuda(_where)
               m_datos = managerAlmacenes.DTAlmacenes
               _campo = "Descripción"
         End Select
         Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", m_datos, False)
         If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
            actxaPara.Text = Ayuda.Respuesta.Rows(0)(_campoCodigo).ToString()
            actxParaDesc.Text = Ayuda.Respuesta.Rows(0)(_campo).ToString()
         End If

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function ValidarNeumaticos(ByRef msg As String)
      Try
         Dim _msg As String = ""
         For Each Item As ETRAN_Neumaticos In m_listTRAN_Neumaticos
            If IsNothing(Item.TRAN_MovimientosNeumaticos.TIPOS_CodDestino) Then
               _msg &= String.Format("- Neumatico, Codigo: {0}, No tiene un destino asignado", Item.NEUMA_Codigo) & vbNewLine
            End If
         Next
         If _msg.Length > 0 Then
            msg &= "Los Neumaticos siguientes presentan problemas: " & vbNewLine & _msg
            Return False
         End If
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub NoGuardar()
      Try
         If m_listNoAsignadosTRAN_Neumaticos.Count > 0 Then
            bs_noAsignados = New BindingSource()
            bs_noAsignados.DataSource = m_listNoAsignadosTRAN_Neumaticos
            c1grdNoAsignados.DataSource = bs_noAsignados
            bnavNoAsignados.BindingSource = bs_noAsignados
            pnlNoAsignados.Visible = True
         Else
            pnlNoAsignados.Visible = False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub AsignarNoSeleccionado()
      Try
         Dim _registro As New ETRAN_Neumaticos()
         _registro = CType(bs_noAsignados.Current, ETRAN_Neumaticos)
         m_listTRAN_Neumaticos.Add(_registro)
         m_listNoAsignadosTRAN_Neumaticos.Remove(_registro)

         bs_tran_neumaticos.ResetBindings(False)
         bs_noAsignados.ResetBindings(False)
         pnlNoAsignados.Visible = m_listNoAsignadosTRAN_Neumaticos.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub setColor()
      Dim _posicion As String = 0
      If cmbTipoUbicacion.SelectedValue = BConstantes.getOrigenDestino(BConstantes.TipoDestino.Vehiculo) Then
         _posicion = nupPosicion.Value.ToString()
      ElseIf cmbTipoUbicacion.SelectedValue = BConstantes.getOrigenDestino(BConstantes.TipoDestino.Ranfla) Then
         _posicion = (nupPosicion.Value + 1).ToString()
      End If
      Dim _lado As String = IIf(IsNothing(cmbLado.SelectedValue), "", cmbLado.SelectedValue)
      Dim _intext As String = IIf(IsNothing(cmbIntExt.SelectedValue), "", cmbIntExt.SelectedValue)
      Dim _seccion As String = IIf(IsNothing(cmbSeccion.SelectedValue), "", cmbSeccion.SelectedValue)

      acVehNueva.setColor(_seccion & _lado & _intext & _posicion)
   End Sub
#End Region

#Region " Metodos de Controles"

#Region " Tool Bar "

   Private Sub acTool_ACBtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnNuevo_Click
      Try
         tabMantenimiento.SelectedTab = tabDatos

         m_edocumentos = New EDocumentos()
         m_listTRAN_Neumaticos = New List(Of ETRAN_Neumaticos)
         m_listNoAsignadosTRAN_Neumaticos = New List(Of ETRAN_Neumaticos)
         m_edocumentos.Instanciar(ACEInstancia.Nuevo)
         setDatos()
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
         setInstanciaUbicacion(ACFramework.ACUtilitarios.ACSetInstancia.Guardar)
         AsignarBinding()
         cmbTipoDocumento.Focus()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Nuevo Documento", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnCancelar_Click
      Try
         tabMantenimiento.SelectedTab = tabBusqueda
         txtBusqueda.Focus()
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Cancelar)
         tsbtnRevisar.Visible = True
         acTool.ACBtnModificarVisible = False
         Me.KeyPreview = False
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cancelar Documento", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnModificar_Click
      Try
         setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         cargar()
         tabMantenimiento.SelectedTab = tabDatos
         cmbTipoDocumento.Focus()
         Me.KeyPreview = True
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Modificar Documento", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles acTool.ACBtnGrabar_Click
      Dim msg As String = ""
      Try
         If ACFramework.ACUtilitarios.ACDatosOk(grpDocumento, msg) And ValidarNeumaticos(msg) Then
            m_edocumentos.SUCUR_Id = GApp.Sucursal
            m_edocumentos.DOCMT_De = GApp.EUsuarioEntidad.ENTID_Id
            managerMovimientosNeumaticos.Documentos = m_edocumentos
            managerMovimientosNeumaticos.ListTRAN_Neumaticos = m_listTRAN_Neumaticos
            If managerMovimientosNeumaticos.Guardar(GApp.Usuario, GApp.FechaProceso.Year.ToString(), True, msg) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Grabado satisfactoriamente")
               tabMantenimiento.SelectedTab = tabBusqueda
               busqueda(txtBusqueda.Text)
               Me.KeyPreview = False
               txtBusqueda.Focus()
            Else
               m_listNoAsignadosTRAN_Neumaticos = managerMovimientosNeumaticos.NoAsignadosTRAN_Neumaticos
               NoGuardar()
               ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No puede guardar verifique el detalle", msg)
               acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
            End If
         Else
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Modificar)
            ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No puede guardar, por que hay campos obligatorios vacios: ", msg)
         End If
      Catch ex As Exception
         acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " + Me.Text, "No se puede grabar", ex)
      End Try
   End Sub

   Private Sub acTool_ACBtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acTool.ACBtnSalir_Click
      Me.Close()
   End Sub

#End Region

#Region " Botones "
   Private Sub txtBusqueda_ACAyudaClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.ACAyudaClick
      Try
         busqueda(txtBusqueda.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar la ayuda de los conductores", ex)
      End Try
   End Sub

   Private Sub txtBusqueda_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBusqueda.KeyUp
      Try
         If e.KeyCode = Keys.Enter Then
            busqueda(txtBusqueda.Text)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub tsbtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAgregar.Click
      Try
         managerTRAN_Neumaticos.CargarAyuda(Nothing)
         Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerTRAN_Neumaticos.DTTRAN_Neumaticos, False)
         If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim _codigo As String = Ayuda.Respuesta.Rows(0)("Interno").ToString()
            Dim _filter As New ACFiltrador(Of ETRAN_Neumaticos)
            _filter.ACFiltro = String.Format("NEUMA_Id={0}", _codigo)
            If _filter.ACFiltrar(m_listTRAN_Neumaticos).Count > 0 Then
               ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "El neumatico seleccionado ya fue agregado")
            Else
               'UBNeumaticos()
               managerTRAN_Neumaticos.Cargar(_codigo, True)
               RemoveHandler bs_tran_neumaticos.CurrentChanged, AddressOf bs_tran_neumaticos_CurrentChanged
               RemoveHandler cmbLado.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanged
               RemoveHandler cmbSeccion.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanged
               RemoveHandler cmbIntExt.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanged

               m_listTRAN_Neumaticos.Add(managerTRAN_Neumaticos.TRAN_Neumaticos)

               bs_tran_neumaticos.ResetBindings(True)
               bs_tran_neumaticos.Position = m_listTRAN_Neumaticos.Count - 1
               setInstanciaUbicacion(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)

               AddHandler cmbLado.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanged
               AddHandler cmbSeccion.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanged
               AddHandler cmbIntExt.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanged
               AddHandler bs_tran_neumaticos.CurrentChanged, AddressOf bs_tran_neumaticos_CurrentChanged
               bs_tran_neumaticos_CurrentChanged(Nothing, Nothing)
               setInstanciaUbicacion(ACFramework.ACUtilitarios.ACSetInstancia.Nuevo)
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Agregar Neumatico", ex)
      End Try
   End Sub

   Private Sub tsbQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbQuitar.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta("Eliminar Registro del Neumatico, Codigo: " & CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos).NEUMA_Codigo _
             , "Desea eliminar el registro: " _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            Dim _reg As New ETRAN_Neumaticos()
            _reg = CType(bs_tran_neumaticos.Current, ETRAN_Neumaticos)
            m_listTRAN_Neumaticos.Remove(_reg)
            RemoveHandler bs_tran_neumaticos.CurrentChanged, AddressOf bs_tran_neumaticos_CurrentChanged
            bs_tran_neumaticos.ResetBindings(False)
            AddHandler bs_tran_neumaticos.CurrentChanged, AddressOf bs_tran_neumaticos_CurrentChanged
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Quitar Neumatico", ex)
      End Try
   End Sub

   Private Sub tsbtnGrabarUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGrabarUbicacion.Click
      Try
         Dim msg As String = ""
         If Not IsNothing(bs_tran_neumaticos.Current) Then
            If ACFramework.ACUtilitarios.ACDatosOk(grpNuevPosicion, msg) Then
               GetUbicacionNeumaticos()
               setInstanciaUbicacion(ACFramework.ACUtilitarios.ACSetInstancia.Guardar)
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio("Información: " + Me.Text, "Grabado satisfactoriamente")
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion("Información: " & Me.Text, "No se puede grabar por que no se ha seleccionado los campos obligatorios ", msg)
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Grabar Ubicacion", ex)
      End Try
   End Sub

   Private Sub tsbtnAsignarNoSeleccionado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAsignarNoSeleccionado.Click
      Try
         AsignarNoSeleccionado()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso No se puede asignar el neumatico", ex)
      End Try
   End Sub

   Private Sub tsbtnAsigTodosNoSeleccionado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAsigTodosNoSeleccionado.Click
      Try
         For Each Item As ETRAN_Neumaticos In m_listNoAsignadosTRAN_Neumaticos
            m_listTRAN_Neumaticos.Add(Item)
         Next
         m_listNoAsignadosTRAN_Neumaticos = New List(Of ETRAN_Neumaticos)

         bs_tran_neumaticos.ResetBindings(False)
         bs_noAsignados.ResetBindings(False)
         pnlNoAsignados.Visible = m_listNoAsignadosTRAN_Neumaticos.Count > 0
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso No se puede asignar el neumatico", ex)
      End Try
   End Sub

   Private Sub tsbtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnModificarUbicacion.Click
      Try
         setInstanciaUbicacion(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Modificar", ex)
      End Try
   End Sub

   Private Sub tsbtnCancelarUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnCancelarUbicacion.Click
      Try
         setInstanciaUbicacion(ACFramework.ACUtilitarios.ACSetInstancia.Deshacer)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Cancelar", ex)
      End Try
   End Sub

#End Region

#Region " Textos "
   Private Sub actxaPara_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaPara.ACAyudaClick
      Try
         Select Case cmbTipoUbicacion.SelectedValue.ToString()
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Almacen)
               AyudaDestino(actxaPara.Text, "ALMAC_Id")
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Proveedor)
               AyudaDestino(actxaPara.Text, "ENTID_Id")
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Ranfla)
               AyudaDestino(actxaPara.Text, "RANFL_Id")
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Vehiculo)
               AyudaDestino(actxaPara.Text, "VEHIC_Id")
            Case Else
               AyudaDestino(actxaPara.Text, "VEHIC_Id")
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Ayuda de Destinos", ex)
      End Try
   End Sub

   Private Sub actxParaDesc_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxParaDesc.ACAyudaClick
      Try
         Select Case cmbTipoUbicacion.SelectedValue.ToString()
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Almacen)
               AyudaDestino(actxParaDesc.Text, "ALMAC_Descripcion")
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Proveedor)
               AyudaDestino(actxParaDesc.Text, "ENTID_RazonSocial")
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Ranfla)
               AyudaDestino(actxParaDesc.Text, "RANFL_Placa")
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Vehiculo)
               AyudaDestino(actxParaDesc.Text, "VEHIC_Placa")
            Case Else
               AyudaDestino(actxParaDesc.Text, "VEHIC_Placa")
         End Select
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Ayuda de Destinos", ex)
      End Try
   End Sub
#End Region

#Region " ComboBox "
   Private Sub cmbTipoUbicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoUbicacion.SelectedIndexChanged
      Try
         cmbLado.SelectedIndex = -1
         cmbSeccion.SelectedIndex = -1
         cmbIntExt.SelectedIndex = -1
         actxaPara.Text = ""
         actxParaDesc.Text = ""
         Select Case cmbTipoUbicacion.SelectedValue.ToString()
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Almacen) _
            , BConstantes.getOrigenDestino(BConstantes.TipoDestino.Proveedor)
               lblLado.Enabled = False
               cmbLado.Enabled = False
               cmbLado.Tag = "EC"
               lblSeccion.Enabled = False
               cmbSeccion.Enabled = False
               cmbSeccion.Tag = "EC"
               lblPosicion.Enabled = False
               nupPosicion.Enabled = False
               lblIntExt.Enabled = False
               cmbIntExt.Enabled = False
               cmbIntExt.Tag = "EC"
               m_destino = BConstantes.TipoDestino.Almacen
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Ranfla)
               lblSeccion.Enabled = False
               cmbSeccion.Enabled = False
               cmbSeccion.SelectedValue = ACETransporte.Constantes.getSeccionNeumatico(ACETransporte.Constantes.SeccionNeumatico.Posteriores)
               cmbSeccion.Tag = "EC"
               lblLado.Enabled = True
               cmbLado.Enabled = True
               cmbLado.Tag = "ECO"
               lblPosicion.Enabled = True
               nupPosicion.Enabled = True
               lblIntExt.Enabled = True
               cmbIntExt.Enabled = True
               cmbIntExt.Tag = "ECO"
               m_destino = BConstantes.TipoDestino.Ranfla
            Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Vehiculo)
               lblLado.Enabled = True
               cmbLado.Enabled = True
               cmbLado.Tag = "ECO"
               lblSeccion.Enabled = True
               cmbSeccion.Enabled = True
               cmbSeccion.Tag = "ECO"
               lblPosicion.Enabled = True
               nupPosicion.Enabled = True
               lblIntExt.Enabled = True
               cmbIntExt.Enabled = True
               cmbIntExt.Tag = "ECO"

               m_destino = BConstantes.TipoDestino.Vehiculo
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If cmbSeccion.SelectedValue = ACETransporte.Constantes.getSeccionNeumatico(ACETransporte.Constantes.SeccionNeumatico.Delanteros) Then
            cmbIntExt.SelectedValue = ACETransporte.Constantes.getIntExt(ACETransporte.Constantes.IntExtNeumatico.Externo)
            cmbIntExt.Enabled = False
            nupPosicion.Minimum = 1
            nupPosicion.Maximum = 1
            nupPosicion.Value = 1
         Else
            cmbIntExt.Enabled = True
            nupPosicion.Minimum = 2
            nupPosicion.Maximum = 4
            nupPosicion.Value = 2
         End If
         setColor()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso asignar ubicación", ex)
      End Try
   End Sub
#End Region

   Private Sub c1grdNoAsignados_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles c1grdNoAsignados.MouseDoubleClick
      Try
         If e.X > c1grdNoAsignados.Rows.Fixed Then
            AsignarNoSeleccionado()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso No se puede asignar el neumatico", ex)
      End Try
   End Sub

   Private Sub c1grdDetalle_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles c1grdBusqueda.MouseDoubleClick
      Try
         If e.X > c1grdBusqueda.Rows.Fixed Then
            txbtnRevisar_Click(Nothing, Nothing)
            'cargar()
            'setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar el registro seleccionado", ex)
      End Try

   End Sub

   Private Sub nupPosicion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupPosicion.ValueChanged
      setColor()
   End Sub

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub

   Private Sub txbtnRevisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnRevisar.Click
      Try
         If Not IsNothing(bs_bdocumentos.Current) Then
            cargar()
            acTool.setInstancia(ACControles.ACToolBarMantHorizontalNew.TipoInstancia.Nuevo)
            setInstancia(ACFramework.ACUtilitarios.ACSetInstancia.Modificado)
            bs_tran_neumaticos_CurrentChanged(Nothing, Nothing)
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso Ver Documento", ex)
      End Try
   End Sub
#End Region

End Class
