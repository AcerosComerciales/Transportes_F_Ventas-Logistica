Imports ACFramework

Imports ACBTransporte
Imports ACETransporte
Imports ACBVentas
Imports ACEVentas

Public Class ACEntornoTrabajo
#Region " Variables "
   Private bs_zonas As BindingSource
   Private bs_sucursales As BindingSource
   Private bs_puntoventa As BindingSource
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         bs_zonas = New BindingSource()
         bs_zonas.DataSource = Colecciones.Zonas
         ACUtilitarios.ACCargaCombo(cmbZona, bs_zonas, "ZONAS_Descripcion", "ZONAS_Codigo")
         AddHandler bs_zonas.CurrentChanged, AddressOf bs_zonas_CurrentChanged
         bs_zonas_CurrentChanged(Nothing, Nothing)
         txtUsuario.Text = GApp.EUsuarioEntidad.ENTID_Nombres

         Utilitarios.getFileConfigBase()
         If CType(Utilitarios.cConfig("zona"), PXML).Valor <> "" Then
            cmbZona.SelectedValue = CType(Utilitarios.cConfig("zona"), PXML).Valor.ToString()
            If CType(Utilitarios.cConfig("sucursal"), PXML).Valor <> "" Then
               cmbSucursales.SelectedValue = CType(CType(Utilitarios.cConfig("sucursal"), PXML).Valor, Int16)
               If CType(Utilitarios.cConfig("puntoventa"), PXML).Valor <> "" Then cmbPuntoVenta.SelectedValue = CType(CType(Utilitarios.cConfig("puntoventa"), PXML).Valor, Long)
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso: Inicializar Contoles", ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
   Private Function validarUsuario(ByRef m_msg As String) As Boolean
      Try
         Dim managerVENT_UsuariosPorPuntoVenta As New BUsuariosPorPuntoVenta
         Dim _where As New Hashtable()
         _where.Add("PVENT_Id", New ACWhere(cmbPuntoVenta.SelectedValue))
         _where.Add("ENTID_Codigo", New ACWhere(GApp.EUsuarioEntidad.ENTID_Codigo))
         _where.Add("ZONAS_Codigo", New ACWhere(cmbZona.SelectedValue))
         _where.Add("SUCUR_Id", New ACWhere(cmbSucursales.SelectedValue))
         If managerVENT_UsuariosPorPuntoVenta.CargarTodos(_where) Then
            Return True
         Else
            m_msg &= String.Format("El usuario {0} no tiene acceso a: {4} - Zona: {1}{4} - Sucursal:{2}{4} - Punto de Venta: {3}{4}Consulte con el administrador del sistema." _
                                   , New Object() {GApp.EUsuarioEntidad.ENTID_Nombres, cmbZona.Text, cmbSucursales.Text, cmbPuntoVenta.Text, vbNewLine})
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub bs_zonas_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_zonas) Then
            If CType(bs_zonas.DataSource, List(Of EZonas)).Count > 0 Then
               Dim x_zona As String = cmbZona.SelectedValue
               Dim _filter As New ACFiltrador(Of ESucursales)() With {.ACFiltro = String.Format("ZONAS_Codigo={0}", x_zona)}
               bs_sucursales = New BindingSource()
               bs_sucursales.DataSource = _filter.ACFiltrar(Colecciones.Sucursales)
               ACUtilitarios.ACCargaCombo(cmbSucursales, bs_sucursales, "SUCUR_Nombre", "SUCUR_Id")

               AddHandler bs_sucursales.CurrentChanged, AddressOf bs_sucursales_CurrentChanged
               bs_sucursales_CurrentChanged(Nothing, Nothing)
            End If
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Sucursales", ex)
      End Try
   End Sub

   Private Sub bs_sucursales_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_sucursales) Then
            If CType(bs_sucursales.DataSource, List(Of ESucursales)).Count > 0 Then
               Dim x_zona As String = cmbZona.SelectedValue
               Dim x_sucursal As Long = cmbSucursales.SelectedValue
               Dim _filter As New ACFiltrador(Of EPuntoVenta)() With {.ACFiltro = String.Format("ZONAS_Codigo={0} AND SUCUR_Id={1}", x_zona, x_sucursal.ToString())}
               bs_puntoventa = New BindingSource()
               bs_puntoventa.DataSource = _filter.ACFiltrar(Colecciones.PuntosVenta)
               ACUtilitarios.ACCargaCombo(cmbPuntoVenta, bs_puntoventa, "PVENT_Descripcion", "PVENT_Id")
            End If
         End If

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Sucursales", ex)
      End Try
   End Sub
#End Region

#Region " Metodos de Controles"
   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Dim m_msg As String = ""
      Try
         If cmbZona.SelectedIndex > -1 And cmbSucursales.SelectedIndex > -1 And cmbPuntoVenta.SelectedIndex > -1 Then
            If validarUsuario(m_msg) Then
               GApp.SetBase(CType(bs_zonas.Current, EZonas), CType(bs_sucursales.Current, ESucursales), CType(bs_puntoventa.Current, EPuntoVenta), dtpFecha.Value)
               Parametros.Inicializar(GApp.EZona.ZONAS_Codigo, GApp.ESucursal.SUCUR_Id, GApp.Aplicacion)
               '' Inicializar datos generales
               Utilitarios.cConfig("zona") = New PXML(cmbZona.SelectedValue, "zona")
               Utilitarios.cConfig("sucursal") = New PXML(cmbSucursales.SelectedValue, "sucursal")
               Utilitarios.cConfig("puntoventa") = New PXML(cmbPuntoVenta.SelectedValue, "puntoventa")
               Utilitarios.cConfig("empresa") = New PXML(GApp.Empresa, "empresa")
               Utilitarios.saveXML()
               '' Inicializar en la Capa de Negocio
               Dim managerBConstantes As BConstantes
               managerBConstantes = New BConstantes
               managerBConstantes.setIniciales(GApp.Aplicacion, GApp.Zona, GApp.Sucursal, GApp.PuntoVenta, GApp.Periodo, GApp.EUsuarioEntidad)
               '' Cerrar
               Me.DialogResult = Windows.Forms.DialogResult.OK
               Me.Close()
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede dar acceso, revise los detalles.", m_msg)
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede continuar hasta que se selecciones la Zona/Sucursal Adecuada ")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los dialogos iniciales", ex)
      End Try
   End Sub
#End Region

End Class