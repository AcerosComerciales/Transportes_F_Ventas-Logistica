Imports ACBVentas
Imports ACEVentas
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid


Public Class MRelacionados
#Region " Variables "
   Private managerEntidadRelacion As BEntidadRelacion
   Private managerEntidades As BEntidades

   Private bs_relacionados As BindingSource

   Private m_entid_codigo As String

   Private m_order As Integer = 1
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_entid_codigo As String, ByVal x_entid_razonsocial As String)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      Try
         managerEntidadRelacion = New BEntidadRelacion
         managerEntidades = New BEntidades

         acpnlTitulo.Text = String.Format(acpnlTitulo.Text, x_entid_razonsocial)
         Me.Text = acpnlTitulo.Text
         m_entid_codigo = x_entid_codigo

         formatearGrilla()
         CargarCombos()

         Cargar(x_entid_codigo)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError("Error: " & Convert.ToString(Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub
#End Region

#Region " Metodos "
#Region " Utilitarios "
   Private Sub formatearGrilla()
      Dim index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdRelacionados, 1, 1, 5, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRelacionados, index, "Codigo", "ENTID_CodRelacion", "ENTID_CodRelacion", 20, True, False, "System.String", "########0") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRelacionados, index, "Nombres / Razón Social", "ENTID_RazonSocial", "ENTID_RazonSocial", 250, True, False, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRelacionados, index, "Tipo de Relación", "TIPOS_TipoRelacion", "TIPOS_TipoRelacion", 50, True, True, "System.String") : index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdRelacionados, index, "Tipos", "TIPOS_CodTipoRelacion", "TIPOS_CodTipoRelacion", 50, False, False, "System.String") : index += 1

         c1grdRelacionados.AllowEditing = True
         c1grdRelacionados.AllowSorting = AllowSortingEnum.SingleColumn
         c1grdRelacionados.AutoResize = True
         c1grdRelacionados.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdRelacionados.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdRelacionados.Styles.Highlight.BackColor = Color.Gray
         c1grdRelacionados.SelectionMode = SelectionModeEnum.Row
         c1grdRelacionados.VisualStyle = VisualStyle.Office2007Blue
         c1grdRelacionados.AutoSizeCols()
         'c1grdRelacionados.Cols("TIPOS_TipoRelacion").Editor = cmbTipoRelacion
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub

   Private Sub CargarCombos()
      Try
         'ACFramework.ACUtilitarios.ACCargaCombo(cmbTipoRelacion, Colecciones.Tipos(ETipos.MyTipos.RelacionEntidades), "TIPOS_Descripcion", "TIPOS_Codigo")
         ACFramework.ACUtilitarios.ACCargaCombo(tscmbTipoRelacion.ComboBox, Colecciones.Tipos(ETipos.MyTipos.RelacionEntidades), "TIPOS_Descripcion", "TIPOS_Codigo")
         Dim _lisRoles As New List(Of ERoles)
         _lisRoles.Add(New ERoles(0, "<< Todos >>"))
         For Each Item As ERoles In Colecciones.Roles
            _lisRoles.Add(Item.Clone)
         Next
         ACFramework.ACUtilitarios.ACCargaCombo(tscmbTipoEntidad.ComboBox, _lisRoles, "ROLES_Descripcion", "ROLES_Id")
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

#Region " Cargar Datos "
   Private Function Cargar(ByVal x_entid_codigo As String) As Boolean
      Try
         bs_relacionados = New BindingSource()
         If Not managerEntidadRelacion.CargarRelacionados(x_entid_codigo) Then
            managerEntidadRelacion.ListEntidadRelacion = New List(Of EEntidadRelacion)()
         End If
         bs_relacionados.DataSource = managerEntidadRelacion.ListEntidadRelacion
         c1grdRelacionados.DataSource = bs_relacionados
         bnavRelacion.BindingSource = bs_relacionados
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

#Region " Metodos de Controles"

#End Region

   Private Sub tsbtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAgregar.Click
      Try
         AyudaEntidad(tstxtNombres.Text, "ENTID_RazonSocial", tscmbTipoEntidad.ComboBox.SelectedValue)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso buscar entidad", ex)
      End Try
   End Sub

   Private Sub AyudaEntidad(ByVal x_cadenas As String, ByVal x_campo As String, ByVal x_opcion As EEntidades.TipoEntidad)
      Try
         Dim _where As New Hashtable
         _where.Add(x_campo, New ACWhere(x_cadenas, ACWhere.TipoWhere._Like))
         managerEntidades.Ayuda(_where, x_opcion)
         Dim Ayuda As New ACControlesC1.ACAyudaFlex("Buscar Entidad", managerEntidades.DTEntidades, False)
         If Ayuda.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim b_entidadesrelacion As New BEntidadRelacion()
            b_entidadesrelacion.EntidadRelacion = New EEntidadRelacion()
            b_entidadesrelacion.EntidadRelacion.Instanciar(ACEInstancia.Nuevo)
            b_entidadesrelacion.EntidadRelacion.ENTID_Codigo = m_entid_codigo
            b_entidadesrelacion.EntidadRelacion.ENTID_CodRelacion = Ayuda.Respuesta.Rows(0)("Codigo")
            b_entidadesrelacion.EntidadRelacion.ENTID_RazonSocial = Ayuda.Respuesta.Rows(0)("Razon Social")
            b_entidadesrelacion.EntidadRelacion.TIPOS_CodTipoRelacion = tscmbTipoRelacion.ComboBox.SelectedValue
            b_entidadesrelacion.EntidadRelacion.ENTRE_Numero = b_entidadesrelacion.GetNumero(m_entid_codigo)
            If b_entidadesrelacion.Guardar(GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Grabado satisfactoriamente")
               Cargar(m_entid_codigo)
            End If          
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Sub tsbtnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnQuitar.Click
      Try
         If ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Quitar Registro: {0}", Me.Text) _
             , String.Format("Desea quitar el relacionado: {0}", CType(bs_relacionados.Current, EEntidadRelacion).ENTID_RazonSocial) _
             , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            Dim b_entidadesrelacion As New BEntidadRelacion()
            b_entidadesrelacion.EntidadRelacion = New EEntidadRelacion()
            b_entidadesrelacion.EntidadRelacion.ENTID_Codigo = m_entid_codigo
            b_entidadesrelacion.EntidadRelacion.ENTID_CodRelacion = CType(bs_relacionados.Current, EEntidadRelacion).ENTID_CodRelacion
            b_entidadesrelacion.EntidadRelacion.ENTRE_Numero = CType(bs_relacionados.Current, EEntidadRelacion).ENTRE_Numero
            b_entidadesrelacion.EntidadRelacion.TIPOS_CodTipoRelacion = CType(bs_relacionados.Current, EEntidadRelacion).TIPOS_CodTipoRelacion
            b_entidadesrelacion.EntidadRelacion.Instanciar(ACEInstancia.Eliminado)
            If b_entidadesrelacion.Guardar(GApp.Usuario) Then
               ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Quitado satisfactoriamente")
               Cargar(m_entid_codigo)
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Quitar relacionado", ex)
      End Try
   End Sub

   Private Sub tsbtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSalir.Click
      Me.Close()
   End Sub

   Private Sub c1grdBusqueda_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles c1grdRelacionados.BeforeSort
      Try
         Ordenar(c1grdRelacionados.Cols(e.Col).UserData)
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso ordenar", ex)
      End Try
   End Sub

   Private Sub Ordenar(ByVal x_columna As String)
      Dim _ordenador As New ACOrdenador(Of EEntidadRelacion)
      Try
         If m_order = 2 Then x_columna += " DESC"
         _ordenador.ACOrdenamiento = x_columna
         CType(bs_relacionados.DataSource, List(Of EEntidadRelacion)).Sort(_ordenador)
         c1grdRelacionados.Refresh()
         m_order = IIf(m_order = 1, 2, 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub
End Class