Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports ACEVentas

Public Class MPartesMant
#Region " Variables "
   Private m_tran_vehmandetalle As ETRAN_VehiculosMantenimientoDetalle
   Private bs_documentos As BindingSource

   Enum TPiezas
      Codigo = 0
      Nombre = 1
   End Enum
#End Region

#Region " Propiedades "

   Public Property TRAN_VehiculosMantenimientoDetalle() As ETRAN_VehiculosMantenimientoDetalle
      Get
         Return m_tran_vehmandetalle
      End Get
      Set(ByVal value As ETRAN_VehiculosMantenimientoDetalle)
         m_tran_vehmandetalle = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_listFacturas As List(Of ETRAN_Documentos))

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         m_tran_vehmandetalle = New ETRAN_VehiculosMantenimientoDetalle

         ACUtilitarios.ACCargaCombo(cmbTipoRepuesto, Colecciones.Tipos(ETipos.MyTipos.TipoRepuesto), "TIPOS_Descripcion", "TIPOS_Codigo")

         Inicializacion(x_listFacturas)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub

   Public Sub New(ByRef x_tran_vehiculosmantenimientodetalle As ETRAN_VehiculosMantenimientoDetalle, ByVal x_listFacturas As List(Of ETRAN_Documentos))
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Try
         m_tran_vehmandetalle = New ETRAN_VehiculosMantenimientoDetalle
         m_tran_vehmandetalle = x_tran_vehiculosmantenimientodetalle

         ACUtilitarios.ACCargaCombo(cmbTipoRepuesto, Colecciones.Tipos(ETipos.MyTipos.TipoRepuesto), "TIPOS_Descripcion", "TIPOS_Codigo")

         Inicializacion(x_listFacturas)
         cmbRepuesto.SelectedValue = m_tran_vehmandetalle.PIEZA_Id
         actxaCodigo.Text = m_tran_vehmandetalle.PIEZA_Codigo
         actxaDescripcion.Text = m_tran_vehmandetalle.PIEZA_Descripcion
         txtCantidad.Text = m_tran_vehmandetalle.VMDET_Cantidad
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub

   Private Sub Inicializacion(ByVal x_listFacturas As List(Of ETRAN_Documentos))
      Try
         If x_listFacturas.Count > 0 Then
            Dim _documentos As New BTRAN_Documentos
            Dim x_condicion As String = ""
            Dim _uno As Boolean = True
            For Each item As ETRAN_Documentos In x_listFacturas
               If _uno Then
                  x_condicion &= String.Format("'{0}{1}'", item.DOCUS_Codigo, item.ENTID_Codigo) : _uno = False
               Else
                  x_condicion &= String.Format(",'{0}{1}'", item.DOCUS_Codigo, item.ENTID_Codigo)
               End If
            Next
            If _documentos.CargarDetalle(x_condicion) Then
               bs_documentos = New BindingSource
               bs_documentos.DataSource = _documentos.TRAN_Documentos.ListETRAN_DocumentosDetalle

               ACUtilitarios.ACCargaCombo(cmbRepuesto, bs_documentos, "Repuesto", "PIEZA_Id")
               AddHandler bs_documentos.CurrentChanged, AddressOf bs_documentos_CurrentChanged
               bs_documentos_CurrentChanged(Nothing, Nothing)
            End If
         End If
         txtProvCodigo.ReadOnly = True
         txtProvDescripcion.ReadOnly = True
         actxnTotal.ReadOnly = True

         Me.KeyPreview = True
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

#Region " Metodos "
   Private Sub bs_documentos_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         txtProvCodigo.Text = CType(bs_documentos.Current, ETRAN_DocumentosDetalle).ENTID_Codigo
         txtProvDescripcion.Text = CType(bs_documentos.Current, ETRAN_DocumentosDetalle).ENTID_RazonSocial
         actxnTotal.Text = CType(bs_documentos.Current, ETRAN_DocumentosDetalle).DCDET_SubImporte
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Me.Text, "Ocurrio un error en el proceso <Procesos>", ex)
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         If sender.Name = "acTool" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub
#End Region


   Private Sub CargarParte(ByVal x_opcion As TPiezas, ByVal x_cadena As String)
      Try
         Dim m_piezas As New BTRAN_Piezas

         If m_piezas.Ayuda(x_opcion, x_cadena) Then
            Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Proveedor", m_piezas.Datos.Tables(0), False)
            If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
               '' Cargar datos del cliente
               actxaCodigo.Text = Ayuda.Respuesta.Rows(0)("Codigo")
               actxaDescripcion.Text = Ayuda.Respuesta.Rows(0)("Descripcion")
               m_tran_vehmandetalle.PIEZA_Id = Ayuda.Respuesta.Rows(0)("Id")
               cmbRepuesto.SelectedValue = m_tran_vehmandetalle.PIEZA_Id
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede Cargar la ayuda por que no se encontro registros")
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub actxaCodigo_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaCodigo.ACAyudaClick
      Try
         CargarParte(TPiezas.Codigo, actxaCodigo.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar la Ayuda de las piezas"), ex)
      End Try
   End Sub

   Private Sub tsbtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAceptar.Click
      Try
         m_tran_vehmandetalle.TIPOS_CodTipoRepuesto = cmbTipoRepuesto.SelectedValue
         m_tran_vehmandetalle.TIPOS_TipoRepuesto = cmbTipoRepuesto.Text
         m_tran_vehmandetalle.VMDET_Cantidad = txtCantidad.Text
         m_tran_vehmandetalle.VMDET_Responsable = txtResponsable.Text
         m_tran_vehmandetalle.VMDET_Procedimiento = txtProcedimiento.Text
         m_tran_vehmandetalle.PIEZA_Codigo = actxaCodigo.Text
         m_tran_vehmandetalle.PIEZA_Descripcion = actxaDescripcion.Text
         m_tran_vehmandetalle.DOCUS_Codigo = CType(bs_documentos.Current, ETRAN_DocumentosDetalle).DOCUS_Codigo
         m_tran_vehmandetalle.ENTID_Codigo = CType(bs_documentos.Current, ETRAN_DocumentosDetalle).ENTID_Codigo
         m_tran_vehmandetalle.DCDET_Item = CType(bs_documentos.Current, ETRAN_DocumentosDetalle).DCDET_Item

         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar la Ayuda de las piezas"), ex)
      End Try
   End Sub

   Private Sub actxaDescripcion_ACAyudaClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actxaDescripcion.ACAyudaClick
      Try
         CargarParte(TPiezas.Nombre, actxaDescripcion.Text)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar la Ayuda de las piezas"), ex)
      End Try
   End Sub

   Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
      Try
         Dim m_piezas As New MPiezas(MPiezas.TPieza.Nueva)
         If m_piezas.ShowDialog() Then
            actxaCodigo.Text = m_piezas.TRAN_Piezas.PIEZA_Codigo
            actxaDescripcion.Text = m_piezas.TRAN_Piezas.PIEZA_Descripcion
            m_tran_vehmandetalle.PIEZA_Id = m_piezas.TRAN_Piezas.PIEZA_Id
            Label2.Focus()
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar la Ayuda de las piezas"), ex)
      End Try
   End Sub

   Private Sub tsbtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub tsbtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSalir.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub txtProcedimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProcedimiento.KeyDown
      If e.KeyCode = Keys.Enter Then
         KeyPreview = False
         ToolStrip1.Focus()
         tsbtnAceptar.Select()
      End If
   End Sub
End Class