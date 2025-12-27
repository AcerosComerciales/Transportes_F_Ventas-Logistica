Imports System
Imports System.Data
Imports System.Collections.Generic

Imports DAConexion
Imports ACFramework

Imports ACEVentas
Imports ACDVentas

Public Class BCONT_DocsPercepcion

#Region " Variables "
   Private m_zonas_codigo As String
   Private m_sucur_id As Short
   Private m_pvent_id As Long
#End Region

#Region " Constructores "
   Public Sub New(x_zonas_codigo As String, x_sucur_id As Short, x_pvent_id As Long)
      m_zonas_codigo = x_zonas_codigo
      m_sucur_id = x_sucur_id
      m_pvent_id = x_pvent_id
      d_cont_docspercepcion = New DCONT_DocsPercepcion()
   End Sub
#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "
   Public Function getDocumentos(ByVal x_serie As String, ByVal x_numero As String, ByVal x_todos As Boolean, ByVal x_tipo As String) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         setJoinWhere(_join, _where, x_todos)
         _where.Add("DOCPE_Serie", New ACWhere(x_serie, ACWhere.TipoWhere.Igual))
         _where.Add("DOCPE_Numero", New ACWhere(x_numero, ACWhere.TipoWhere._Like))
         _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo, ACWhere.TipoWhere.Igual))
         m_listCONT_DocsPercepcion = New List(Of ECONT_DocsPercepcion)
         Return d_cont_docspercepcion.CONT_DOCPESS_Todos(m_listCONT_DocsPercepcion, _join, _where)
      Catch ex As Exception
         Throw ex
      End Try
    End Function


   Public Function getCliente(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean _
                            , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         setJoinWhere(_join, _where, x_todos)
         _where.Add(x_campo, New ACWhere(x_cadena, "Cli", "System.String", ACWhere.TipoWhere._Like))
         _where.Add("DOCPE_FecEmision", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
         _where.Add(ACWhere.OrderBy, New ACWhere(New ACOrderBy() {New ACOrderBy("DOCPE_FecEmision", ACOrderBy.Ordenamiento.Ascendente)}))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    '--Lista de documentos de percepciones
    Public Function getDocumeDetalle(ByVal x_serie As String, ByVal x_numero As Decimal, ByVal x_iTodos As Int16, ByVal x_tipo As String, ByVal xFecIni As Date, ByVal xFecFin As Date) As DataTable
        Try
            Dim m_datos As New DataTable

            d_cont_docspercepcion.CONT_DOCPEDT_Todos(x_serie, x_numero, x_iTodos, x_tipo, m_datos, xFecIni, xFecFin)
            Return m_datos
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Metodos "

   ''' <summary>
   ''' generar los join
   ''' </summary>
   ''' <param name="_join"></param>
   ''' <param name="_where"></param>
   ''' <param name="x_todos"></param>
   ''' <remarks></remarks>
   Private Sub setJoinWhere(ByRef _join As List(Of ACJoin), ByRef _where As Hashtable, ByVal x_todos As Boolean)
      Try
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Cli", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoDocumento")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TMon", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))
         If Not x_todos Then _where.Add("DOCPE_Estado", New ACWhere(ECONT_DocsPercepcion.getEstado(ECONT_DocsPercepcion.Estado.Anulado), ACWhere.TipoWhere.Diferente))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ''' <summary>
   ''' Grabar el documento de percepcion
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_detalle"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Grabar(ByVal x_usuario As String, ByVal x_detalle As Boolean)
      Try
         DAEnterprise.BeginTransaction()
         If m_econt_docspercepcion.Nuevo Then
            m_econt_docspercepcion.DOCPE_Codigo = String.Format("{0}{1}{2}", m_econt_docspercepcion.TIPOS_CodTipoDocumento.Substring(3, 2) _
                                                            , m_econt_docspercepcion.DOCPE_Serie.PadLeft(3, "0") _
                                                            , m_econt_docspercepcion.DOCPE_Numero.ToString().PadLeft(7, "0"))
         End If
         If Guardar(x_usuario, New String() {"DOCPE_FecTransaccion"}) Then
            Dim _detalle As New BCONT_DocsPercepcionDetalle
            If m_econt_docspercepcion.Modificado Then
               Dim _where As New Hashtable()
               _where.Add("DOCPE_Codigo", New ACWhere(m_econt_docspercepcion.DOCPE_Codigo))
               _detalle.Eliminar(_where)

               Dim _i As Integer = 1
               For Each item As ECONT_DocsPercepcionDetalle In m_econt_docspercepcion.ListCONT_DocsPercepcionDetalle
                  _detalle.CONT_DocsPercepcionDetalle = item
                  _detalle.CONT_DocsPercepcionDetalle.Instanciar(ACFramework.ACEInstancia.Nuevo)
                  _detalle.CONT_DocsPercepcionDetalle.DOCPE_Codigo = m_econt_docspercepcion.DOCPE_Codigo
                  _detalle.CONT_DocsPercepcionDetalle.DOCPD_Item = _i
                  If Not _detalle.Guardar(x_usuario) Then Throw New Exception("No se puede grabar el detalle")
                  _i += 1
               Next


            ElseIf m_econt_docspercepcion.Nuevo Then
               Dim _i As Integer = 1
               For Each item As ECONT_DocsPercepcionDetalle In m_econt_docspercepcion.ListCONT_DocsPercepcionDetalle
                  _detalle.CONT_DocsPercepcionDetalle = item
                  _detalle.CONT_DocsPercepcionDetalle.Instanciar(ACFramework.ACEInstancia.Nuevo)
                  _detalle.CONT_DocsPercepcionDetalle.DOCPE_Codigo = m_econt_docspercepcion.DOCPE_Codigo
                  _detalle.CONT_DocsPercepcionDetalle.DOCPD_Item = _i
                  If Not _detalle.Guardar(x_usuario) Then Throw New Exception("No se puede grabar el detalle")
                  _i += 1
               Next

            End If
            DAEnterprise.CommitTransaction()
            Return True
         Else
            DAEnterprise.RollBackTransaction()
            Return False
         End If
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar reporte del documento de percepcion
   ''' </summary>
   ''' <param name="x_docpe_codigo">codigo del documento de percepcion</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarReporte(ByVal x_docpe_codigo As String) As Boolean
      Try
         m_dtCONT_DocsPercepcion = New DataTable
         If d_cont_docspercepcion.CONT_DOCPESS_Todos(m_dsCONT_DocsPercepcion, x_docpe_codigo) Then
            m_dtCONT_DocsPercepcion = m_dsCONT_DocsPercepcion.Tables(0)
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar documento de percepcion
   ''' </summary>
   ''' <param name="x_docpe_codigo"></param>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Cargar(ByVal x_docpe_codigo As String, ByVal x_opcion As Boolean) As Boolean
      m_econt_docspercepcion = New ECONT_DocsPercepcion()
      m_econt_docspercepcion.ListCONT_DocsPercepcionDetalle = New List(Of ECONT_DocsPercepcionDetalle)
      Dim _join As New List(Of ACJoin)
      Dim _where As New Hashtable
      Try
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Cli", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                              , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TMon", ACJoin.TipoJoin.Inner _
                           , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                           , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoMoneda")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", "Cli", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoDocumento")}))
         _where.Add("DOCPE_Codigo", New ACWhere(x_docpe_codigo))
         _where.Add("DOCPE_Estado", New ACWhere(ECONT_DocsPercepcion.getEstado(ECONT_DocsPercepcion.Estado.Anulado), ACWhere.TipoWhere.Diferente))
         If Cargar(_join, _where) Then
            _join = New List(Of ACJoin)
            _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))
            _where = New Hashtable()
            _where.Add("DOCPE_Codigo", New ACWhere(x_docpe_codigo))
            Dim _bcont_docspercepciondetalle As New BCONT_DocsPercepcionDetalle()
            If x_opcion And _bcont_docspercepciondetalle.CargarTodos(_join, _where) Then
               m_econt_docspercepcion.ListCONT_DocsPercepcionDetalle = New List(Of ECONT_DocsPercepcionDetalle)(_bcont_docspercepciondetalle.ListCONT_DocsPercepcionDetalle)
               Return True
            End If
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' anular documento de percepcion
   ''' </summary>
   ''' <param name="x_docpe_codigo">codigo del documento de percepcion</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AnularDocumento(ByVal x_docpe_codigo As String, ByVal x_usuario As String) As Boolean
      Dim _where As New Hashtable
      Try
         m_econt_docspercepcion = New ECONT_DocsPercepcion()
         m_econt_docspercepcion.DOCPE_Codigo = x_docpe_codigo
         m_econt_docspercepcion.DOCPE_Estado = ECONT_DocsPercepcion.getEstado(ECONT_DocsPercepcion.Estado.Anulado)
         m_econt_docspercepcion.Instanciar(ACEInstancia.Modificado)
         _where.Add("DOCPE_Codigo", New ACWhere(x_docpe_codigo))
         If Guardar(_where, x_usuario) Then
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' agregar percepcion a la caja
   ''' </summary>
   ''' <param name="x_docpe_codigo">codigo del documento de percepcion</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AgregarPercepcion(ByVal x_docpe_codigo As String, ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         If Cargar(x_docpe_codigo) Then
            Dim _ventas As New BVENT_DocsVenta
            _ventas.VENT_DocsVenta = New EVENT_DocsVenta
            _ventas.VENT_DocsVenta.Instanciar(ACEInstancia.Nuevo)
            _ventas.VENT_DocsVenta.ZONAS_Codigo = m_zonas_codigo
            _ventas.VENT_DocsVenta.SUCUR_Id = m_sucur_id
            _ventas.VENT_DocsVenta.PVENT_Id = m_pvent_id
            '' Cargar Vendedor
            Dim _cliente As New BClientes
            If _cliente.Cargar(m_econt_docspercepcion.ENTID_Codigo) Then
               _ventas.VENT_DocsVenta.ENTID_CodigoVendedor = _cliente.Clientes.ENTID_CodigoVendedor
            End If

            _ventas.VENT_DocsVenta.DOCVE_Codigo = m_econt_docspercepcion.DOCPE_Codigo
            _ventas.VENT_DocsVenta.ENTID_CodigoCliente = m_econt_docspercepcion.ENTID_Codigo
            _ventas.VENT_DocsVenta.TIPOS_CodTipoMoneda = m_econt_docspercepcion.TIPOS_CodTipoMoneda
            _ventas.VENT_DocsVenta.TIPOS_CodTipoDocumento = m_econt_docspercepcion.TIPOS_CodTipoDocumento
            _ventas.VENT_DocsVenta.DOCVE_Serie = m_econt_docspercepcion.DOCPE_Serie
            _ventas.VENT_DocsVenta.DOCVE_Numero = m_econt_docspercepcion.DOCPE_Numero
            If m_econt_docspercepcion.DOCPE_TipoCambio = 0 Then
               Dim _btipocambio As New BTipoCambio
               If _btipocambio.getTipoCambioSunat(m_econt_docspercepcion.DOCPE_FecEmision) Then
                  _ventas.VENT_DocsVenta.DOCVE_TipoCambio = _btipocambio.TipoCambio.TIPOC_VentaSunat
               End If
            Else
               _ventas.VENT_DocsVenta.DOCVE_TipoCambio = m_econt_docspercepcion.DOCPE_TipoCambio
            End If
            _ventas.VENT_DocsVenta.DOCVE_FechaDocumento = m_econt_docspercepcion.DOCPE_FecEmision
            Dim _constantes As New BConstantes
            _ventas.VENT_DocsVenta.DOCVE_FechaTransaccion = _constantes.getFecha()
            _ventas.VENT_DocsVenta.DOCVE_TotalPagar = m_econt_docspercepcion.DOCPE_TotalPercepcion
            _ventas.VENT_DocsVenta.TotalPagado = m_econt_docspercepcion.DOCPE_TotalPercepcion
            _ventas.VENT_DocsVenta.DOCVE_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
            _ventas.VENT_DocsVenta.DOCVE_Codigo = m_econt_docspercepcion.DOCPE_Codigo
            _ventas.VENT_DocsVenta.DOCVE_Codigo = m_econt_docspercepcion.DOCPE_Codigo
            _ventas.VENT_DocsVenta.DOCVE_Codigo = m_econt_docspercepcion.DOCPE_Codigo
            _ventas.VENT_DocsVenta.DOCVE_Id = _ventas.getCorrelativo("DOCVE_Id")
            If _ventas.Guardar(x_usuario) Then
               m_econt_docspercepcion.DOCVE_Codigo = m_econt_docspercepcion.DOCPE_Codigo
               m_econt_docspercepcion.Instanciar(ACEInstancia.Modificado)
               If Guardar(x_usuario) Then
                  DAEnterprise.CommitTransaction()
                  Return True
               End If
            End If
         Else
            Throw New Exception("No se puede cargar el comprobante de percepción")
         End If
         Throw New Exception("No se puede cargar el comprobante de percepción")
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function
#End Region

End Class

