Imports ACBVentas
Imports ACEVentas
Imports ACFramework
Imports ACFrameworkC1

Imports C1.Win.C1FlexGrid

Public Class CProductos
#Region " Variables "
   Private managerConsultaArticulos As BConsultaArticulos
   Private managerArticulos As BArticulos
   Private m_listLineas As List(Of ELineas)
   Private m_listSubLineas As List(Of ELineas)

   Private bs_productos As BindingSource
   Private bs_lineas As BindingSource
   Private bs_sublineas As BindingSource
   Private bs_precios As BindingSource

   Private m_opcion As Origen

   Private m_articulo As EArticulos


   Enum Origen
      Cotizaciones
      Pedidos
   End Enum

#End Region

#Region " Propiedades "

   Public Property Articulo() As EArticulos
      Get
         Return m_articulo
      End Get
      Set(ByVal value As EArticulos)
         m_articulo = value
      End Set
   End Property
#End Region

#Region " Constructores "
   Public Sub New(ByVal x_opcion As Origen)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Try
         managerArticulos = New BArticulos
         managerConsultaArticulos = New BConsultaArticulos(GApp.Periodo)
         formatearGrilla()
         cargarDatos()
         Me.KeyPreview = True

         m_opcion = x_opcion
         Select Case m_opcion
            Case Origen.Cotizaciones

            Case Origen.Pedidos

            Case Else

         End Select

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los controles iniciales", ex)
      End Try
   End Sub

   Public Function cargarDatos() As Boolean
      Try
         managerConsultaArticulos.cargarProductos()
         m_listLineas = New List(Of ELineas)(managerConsultaArticulos.ListLineas)
         bs_lineas = New BindingSource()
         bs_lineas.DataSource = m_listLineas
         m_listSubLineas = New List(Of ELineas)(managerConsultaArticulos.ListSubLineas)

         ACFramework.ACUtilitarios.ACCargaCombo(cmbLinea, bs_lineas, "LINEA_Nombre", "LINEA_Codigo")
         AddHandler bs_lineas.CurrentChanged, AddressOf bs_lineas_CurrentChanged
         bs_lineas_CurrentChanged(Nothing, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos "
#Region " Metodos Utilitarios "
   ' <summary>
   ' Dar Formato a la grilla de busqueda
   ' </summary>
   ' <remarks></remarks>
   Private Sub formatearGrilla()
      Dim _index As Integer = 1
      Try
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdBusqueda, 1, 1, 4, 1, 0)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, _index, "Codigo", "ARTIC_Codigo", "ARTIC_Codigo", 150, True, False, "System.String", "") : _index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, _index, "Nombre", "ARTIC_Descripcion", "ARTIC_Descripcion", 150, True, False, "System.String", "") : _index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdBusqueda, _index, "Precio", "LPREC_PrecioVenta", "LPREC_PrecioVenta", 150, False, False, "System.Decimal", Parametros.GetParametro(Parametros.TipoParametros.pg_FMondo2d)) : _index += 1

         c1grdBusqueda.AllowEditing = False
         c1grdBusqueda.Styles.Alternate.BackColor = Color.WhiteSmoke
         c1grdBusqueda.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdBusqueda.Styles.Highlight.BackColor = Color.Gray
         c1grdBusqueda.SelectionMode = SelectionModeEnum.Row

         _index = 1


         'Precios
         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdPrecios, 1, 1, 3, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPrecios, _index, "Lista", "LPREC_Descripcion", "LPREC_Descripcion", 80, True, False) : _index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdPrecios, _index, "Precio", "PrecioCalculado", "PrecioCalculado", 100, True, False, "System.Decimal", Parametros.GetParametro(Parametros.TipoParametros.pg_FMondo2d)) : _index = 1

         c1grdPrecios.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdPrecios.Styles.Fixed.Font = New Font(Font.FontFamily.Name, 12, FontStyle.Bold)
         c1grdPrecios.Rows(0).Height = 30


         ACFrameworkC1.ACUtilitarios.ACFormatearGrilla(c1grdStock, 1, 1, 5, 1)
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdStock, _index, "Almacen", "ALMA_Desc2", "ALMA_Desc2", 100, True, False) : _index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdStock, _index, "ALMA_Codigo", "ALMA_Codigo", "ALMA_Codigo", 0, False, False) : _index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdStock, _index, "Stock", "Saldo", "Saldo", 100, True, False, "System.Decimal", Parametros.GetParametro(Parametros.TipoParametros.pg_FMondo2d)) : _index += 1
         ACFrameworkC1.ACUtilitarios.ACAgregarColumna(c1grdStock, _index, "Orden", "Orden", "Orden", 0, False, False, "System.Integer") : _index += 1

         c1grdStock.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
         c1grdStock.Styles.Fixed.Font = New Font(Font.FontFamily.Name, 12, FontStyle.Bold)
         c1grdStock.Rows(0).Height = 30


      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Text), "No se puede dar formato a la grilla", ex)
      End Try
   End Sub
#End Region

   Private Sub bs_lineas_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Me.KeyPreview = True
         Dim _filter As New ACFiltrador(Of ELineas)() With {.ACFiltro = String.Format("LINEA_CodPadre={0}", cmbLinea.SelectedValue)}
         bs_sublineas = New BindingSource()
         bs_sublineas.DataSource = _filter.ACFiltrar(_filter.ACFiltrar(m_listSubLineas))
         ACFramework.ACUtilitarios.ACCargaCombo(cmbSubLinea, bs_sublineas, "LINEA_Nombre", "LINEA_Codigo")
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Sub Lineas", ex)
      End Try
   End Sub

   Private Sub bs_productos_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If Not IsNothing(bs_productos) Then
            If CType(bs_productos.DataSource, List(Of EArticulos)).Count > 0 Then
               Dim x_artic_codigo As String = CType(bs_productos.Current, EArticulos).ARTIC_Codigo
               bs_precios = New BindingSource()
                    'If managerConsultaArticulos.cargarPrecios(GApp.EZona.ZONAS_Codigo, x_artic_codigo) Then
                    '   bs_precios.DataSource = managerConsultaArticulos.ListPrecios
                    'Else
                    managerConsultaArticulos.ListPrecios = New List(Of EPPrecios)()
                    bs_precios.DataSource = managerConsultaArticulos.ListPrecios
                    'End If
                    c1grdPrecios.DataSource = bs_precios
                    CType(bs_productos.Current, EArticulos).ListPPrecios = New List(Of EPPrecios)(managerConsultaArticulos.ListPrecios)
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso <Procesos>", ex)
        End Try
   End Sub
#End Region

#Region " Metodos de Controles"

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        Try
            If Not IsNothing(bs_productos) Then
                If managerArticulos.ListArticulos.Count > 0 Then
                    Dim _filter As New ACFiltrador(Of EArticulos)() With {.ACFiltro = String.Format("ARTIC_Descripcion=%{0}%", txtBusqueda.Text)}
                    bs_productos = New BindingSource()
                    bs_productos.DataSource = _filter.ACFiltrar(managerArticulos.ListArticulos)
                    c1grdBusqueda.DataSource = bs_productos
                    bnavBusqueda.BindingSource = bs_productos
                    AddHandler bs_productos.CurrentChanged, AddressOf bs_productos_CurrentChanged
                    bs_productos_CurrentChanged(Nothing, Nothing)
                    Me.KeyPreview = False
                End If
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso buscar articulo", ex)
        End Try
    End Sub

   Private Sub cmbSubLinea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSubLinea.KeyDown
      Try
         Me.KeyPreview = True
         If e.KeyCode = Keys.Enter Then
            Dim _where As New Hashtable() 
            _where.Add("LINEA_Codigo", New ACWhere(cmbSubLinea.SelectedValue, ACWhere.TipoWhere.Igual))
                ' _where.Add("ARTIC_PrecioVenta", New ACWhere(0, ACWhere.TipoWhere.Mayor, False))
            bs_productos = New BindingSource()
            If managerArticulos.CargarTodos(_where) Then
               bs_productos.DataSource = managerArticulos.ListArticulos
               c1grdBusqueda.DataSource = bs_productos
               '' Crear  el metodo para cargar los precios
               AddHandler bs_productos.CurrentChanged, AddressOf bs_productos_CurrentChanged
               bs_productos_CurrentChanged(Nothing, Nothing)
               txtBusqueda.Enabled = True
            Else
               managerArticulos.ListArticulos = New List(Of EArticulos)
               bs_productos.DataSource = managerArticulos.ListArticulos
               c1grdBusqueda.DataSource = bs_productos
               cmbLinea.Focus()
               txtBusqueda.Enabled = False
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "NO existen articulos en esta sub-linea, elija otra sub-line")
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Cargar Sub Lineas", ex)
      End Try
   End Sub

#End Region

   Private Sub txtBusqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
      Try
         Select Case e.KeyCode
            Case Keys.Down
               RemoveHandler Me.txtBusqueda.TextChanged, AddressOf txtBusqueda_TextChanged
               bs_productos.Position += 1
               AddHandler Me.txtBusqueda.TextChanged, AddressOf txtBusqueda_TextChanged
               e.Handled = True
               Exit Select
            Case Keys.Up
               RemoveHandler Me.txtBusqueda.TextChanged, AddressOf txtBusqueda_TextChanged
               bs_productos.Position -= 1
               AddHandler Me.txtBusqueda.TextChanged, AddressOf txtBusqueda_TextChanged
               e.Handled = True
               Exit Select
            Case Keys.PageDown
               RemoveHandler Me.txtBusqueda.TextChanged, AddressOf txtBusqueda_TextChanged
               bs_productos.Position += 10
               AddHandler Me.txtBusqueda.TextChanged, AddressOf txtBusqueda_TextChanged
               e.Handled = True
               e.Handled = True
               Exit Select
            Case Keys.PageUp
               RemoveHandler Me.txtBusqueda.TextChanged, AddressOf txtBusqueda_TextChanged
               bs_productos.Position -= 10
               AddHandler Me.txtBusqueda.TextChanged, AddressOf txtBusqueda_TextChanged
               e.Handled = True
               e.Handled = True
               Exit Select
            Case Keys.Enter
               If setDatos() Then
                  Me.DialogResult = Windows.Forms.DialogResult.OK
                  Me.Close()
               Else
                  Me.DialogResult = Windows.Forms.DialogResult.Cancel
               End If
            Case Keys.Escape
               Me.DialogResult = Windows.Forms.DialogResult.Cancel
               Me.Close()
               '   Exit Select
         End Select

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No puede completar el proceso ejecutado por el teclado", ex)
      End Try
   End Sub

   Private Function setDatos() As Boolean
      Try
         If Not IsNothing(bs_productos) Then
            If CType(bs_productos.DataSource, List(Of EArticulos)).Count > 0 Then
               m_articulo = New EArticulos
               m_articulo = CType(bs_productos.Current, EArticulos)
               Return True
            Else
               ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No ha seleccionado ningun Item")
               Return False
            End If
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No ha seleccionado ningun Item")
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub
   
   Private Sub c1grdBusqueda_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1grdBusqueda.DoubleClick
      Try
         If setDatos() Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
         Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso No se puede seleccionar el articulo", ex)
      End Try
   End Sub
   
End Class
