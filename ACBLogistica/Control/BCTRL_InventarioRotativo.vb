Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Imports ACFramework

Imports DAConexion
Imports ACEVentas

Partial Public Class BCTRL_InventarioRotativo

#Region " Variables "
    Private m_listarticulos As List(Of ACEVentas.EArticulos)
    Private m_listvent_docsventadetalle As List(Of ACEVentas.EVENT_DocsVentaDetalle)
    Private m_ctrl_inventariorotativo As BCTRL_InventarioRotativo
    Enum TBus
        Fecha
        Codigo
    End Enum
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

    Public Property ListArticulos() As List(Of ACEVentas.EArticulos)
        Get
            Return m_listarticulos
        End Get
        Set(ByVal value As List(Of ACEVentas.EArticulos))
            m_listarticulos = value
        End Set
    End Property

    Public Property ListVENT_DocsVentaDetalle() As List(Of ACEVentas.EVENT_DocsVentaDetalle)
        Get
            Return m_listvent_docsventadetalle
        End Get
        Set(ByVal value As List(Of ACEVentas.EVENT_DocsVentaDetalle))
            m_listvent_docsventadetalle = value
        End Set
    End Property

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
    ''' <summary> 
    ''' Capa de Negocio: CTRLSS_InventarioRotativo
    ''' </summary>
    ''' <param name="x_perio_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <param name="x_zonas_codigo">Parametro 3: </param> 
    ''' <param name="x_articulo">Parametro 4: </param> 
    ''' <param name="x_linea">Parametro 5: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    '''
    Public Function GrabarInventarioRotativo(ByVal x_usuario As String, ByVal x_detalle As Boolean, ByVal x_periodo As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            m_ectrl_inventariorotativo.INROT_Codigo = String.Format("{0}{1}{2:0000000}", "IR", m_ectrl_inventariorotativo.INROT_Serie, m_ectrl_inventariorotativo.INROT_Numero)
            'm_ectrl_inventariorotativo.INROT_Fecha = m_ectrl_inventariorotativo.INROT_Fecha.Date
            'm_ectrl_inventariorotativo.INROT_FecCrea = m_ectrl_inventariorotativo.INROT_Fecha.Date

            If Guardar(x_usuario) Then
                Dim i As Integer = 1
                For Each item As ECTRL_InventarioRotativoDetalle In m_ectrl_inventariorotativo.ListCTRL_InventarioRotativoDetalle
                    Dim _detinventariorotativo As New BCTRL_InventarioRotativoDetalle
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle = item
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROT_Codigo = m_ectrl_inventariorotativo.INROT_Codigo
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_Item = i
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_Stock = item.INROD_Stock
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_PenOrdenes = item.INROD_PenOrdenes
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_PenPedidos = item.INROD_PenPedidos
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_PenFacturas = item.INROD_PenFacturas
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_PenConfirmacion = item.INROD_PenConfirmacion
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_Pendiente = item.INROD_Pendiente
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_StockFinal = item.INROD_StockFinal
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_StockFisico = item.INROD_StockFisico
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_VeriCorrecto = item.INROD_VeriCorrecto
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_VeriSobrante = item.INROD_VeriSobrante
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.INROD_VeriFaltante = item.INROD_VeriFaltante
                    _detinventariorotativo.CTRL_InventarioRotativoDetalle.Instanciar(ACFramework.ACEInstancia.Nuevo)
                    _detinventariorotativo.Guardar(x_usuario, New String() {"INROT_Fecha"})

                    i += 1
                Next
                DAEnterprise.CommitTransaction()
                Return True
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Busqueda de arreglos por fecha de ingreso
    ''' </summary>
    ''' <param name="x_tbusqueda">tipo de busqueda</param>
    ''' <param name="x_fecini">fecha de inicio de busqueda</param>
    ''' <param name="x_fecfin">fecha de fin de busqueda</param>
    ''' <param name="x_codigo">codigo de arreglo</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BuscarInventarioRotativo(ByVal x_tbusqueda As TBus, ByVal x_fecini As DateTime, ByVal x_fecfin As Date, ByVal x_codigo As String) As Boolean
        Try
            Dim _where As New Hashtable
            Select Case x_tbusqueda
                Case TBus.Codigo
                    _where.Add("ENTID_CodigoResponsable", New ACWhere(x_codigo, ACWhere.TipoWhere._Like))
                Case Else
                    _where.Add("INROT_Fecha", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))


            End Select
            ' Dim _join As New List(Of ACJoin)
            '  _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, ACJoin.TipoJoin.Inner, _
            ' New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoArreglo")}, _
            ' New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoArreglo")}))

            Return CargarTodos(_where)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Consulta(ByVal x_cadena As String, ByVal x_todos As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
        Try
            m_ctrl_inventariorotativo = New BCTRL_InventarioRotativo
            Return m_ctrl_inventariorotativo.Consulta(x_cadena, x_todos, x_fecini, x_fecfin)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CTRLSS_InventarioRotativo(ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String, ByVal x_articulo As String, ByVal x_linea As String) As Boolean
        m_listarticulos = New List(Of ACEVentas.EArticulos)
        Try
            Return d_ctrl_inventariorotativo.CTRLSS_InventarioRotativo(m_listarticulos, x_perio_codigo, x_almac_id, x_zonas_codigo, x_articulo, x_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: CTRLSS_PendientesOrdenes
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <param name="x_linea">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function CTRLSS_PendientesOrdenes(ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
        m_listvent_docsventadetalle = New List(Of ACEVentas.EVENT_DocsVentaDetalle)
        Try
            Return d_ctrl_inventariorotativo.CTRLSS_PendientesOrdenes(m_listvent_docsventadetalle, x_fecfin, x_almac_id, x_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: CTRLSS_PendientesVentas
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <param name="x_linea">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function CTRLSS_PendientesVentas(ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
        m_listvent_docsventadetalle = New List(Of ACEVentas.EVENT_DocsVentaDetalle)
        Try
            Return d_ctrl_inventariorotativo.CTRLSS_PendientesVentas(m_listvent_docsventadetalle, x_fecfin, x_almac_id, x_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: CTRLSS_PedidoReposicion
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <param name="x_linea">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function CTRLSS_PedidoReposicion(ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
        m_listvent_docsventadetalle = New List(Of ACEVentas.EVENT_DocsVentaDetalle)
        Try
            Return d_ctrl_inventariorotativo.CTRLSS_PedidoReposicion(m_listvent_docsventadetalle, x_fecfin, x_almac_id, x_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: CTRLSS_CompraSinConfirmar
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <param name="x_linea">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function CTRLSS_CompraSinConfirmar(ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
        m_listvent_docsventadetalle = New List(Of ACEVentas.EVENT_DocsVentaDetalle)
        Try
            Return d_ctrl_inventariorotativo.CTRLSS_CompraSinConfirmar(m_listvent_docsventadetalle, x_fecfin, x_almac_id, x_linea)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Cargar arreglo
    ''' </summary>
    ''' <param name="x_codigo">codigo de arreglo</param>
    ''' <param name="x_detalle">opcion para cargar detalle del arreglo</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Cargar(ByVal x_codigo As String, ByVal x_detalle As Boolean) As Boolean
        Try
            ' Dim _join As New List(Of ACJoin)
            ' _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, ACJoin.TipoJoin.Inner, _
            ' New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoArreglo")}, _
            ' New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoArreglo")}))
            Dim _where As New Hashtable
            _where.Add("INROT_Codigo", New ACWhere(x_codigo))
            If Cargar(_where) Then
                Dim _detalle As New BCTRL_InventarioRotativoDetalle
                Dim _joindet As New List(Of ACJoin)
                _joindet.Add(New ACJoin(ACEVentas.EArticulos.Esquema, ACEVentas.EArticulos.Tabla, "Art", ACJoin.TipoJoin.Inner, _
                                     New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")}, _
                                     New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion"), _
                                                     New ACCampos("ARTIC_Peso", "ARTIC_Peso"), _
                                                     New ACCampos("TIPOS_CodUnidadMedida", "TIPOS_CodUnidadMedida")}))
                _joindet.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TUni", "Art", ACJoin.TipoJoin.Inner, _
                                  New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")}, _
                                  New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_UnidadMedida")}))
                If _detalle.CargarTodos(_joindet, _where) Then
                    Dim _order As New ACOrdenador(Of ECTRL_ArreglosDetalle)(String.Format("INROD_Item ASC"))
                    '  _detalle.ListCTRL_InventarioRotativoDetalle.Sort(_order)
                    m_ectrl_inventariorotativo.ListCTRL_InventarioRotativoDetalle = _detalle.ListCTRL_InventarioRotativoDetalle
                    Return True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class

