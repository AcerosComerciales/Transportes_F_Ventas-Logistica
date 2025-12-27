Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica
Imports ACEVentas
Imports ACFramework

Imports DAConexion

Partial Public Class BCTRL_Arreglos

#Region " Variables "
   Enum TBus
      Fecha
      Codigo
   End Enum

#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "

   ''' <summary>
   ''' Guardar arreglo
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_detalle">opcion para guardar el detalle del arreglo</param>
   ''' <param name="x_periodo">codigo de periodo</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Guardar(ByVal x_usuario As String, ByVal x_detalle As Boolean, ByVal x_periodo As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         m_ectrl_arreglos.ARREG_Codigo = String.Format("{0}{1}{2:0000000}", m_ectrl_arreglos.TIPOS_CodTipoArreglo.Substring(3, 2), m_ectrl_arreglos.ARREG_Serie, m_ectrl_arreglos.ARREG_Numero)
         m_ectrl_arreglos.ARREG_FechaIngreso = m_ectrl_arreglos.ARREG_FechaIngreso.Date
         If Guardar(x_usuario) Then
            Dim i As Integer = 1
            For Each item As ECTRL_ArreglosDetalle In m_ectrl_arreglos.ListCTRL_ArreglosDetalle
               Dim _detarreglos As New BCTRL_ArreglosDetalle
               _detarreglos.CTRL_ArreglosDetalle = item
               _detarreglos.CTRL_ArreglosDetalle.ARREG_Codigo = m_ectrl_arreglos.ARREG_Codigo
               _detarreglos.CTRL_ArreglosDetalle.ARRDT_Item = i
               _detarreglos.CTRL_ArreglosDetalle.Instanciar(ACFramework.ACEInstancia.Nuevo)
               If _detarreglos.Guardar(x_usuario, New String() {"ARREG_Fecha"}) Then
                  Dim _manejarstocks As New BManejarStock()
                  _manejarstocks.LOG_Stocks = New ELOG_Stocks
                  _manejarstocks.LOG_Stocks.Instanciar(ACFramework.ACEInstancia.Nuevo)
                  _manejarstocks.LOG_Stocks.ARREG_Codigo = m_ectrl_arreglos.ARREG_Codigo
                  _manejarstocks.LOG_Stocks.ARRDT_Item = i
                  If m_ectrl_arreglos.TIPOS_CodTipoArreglo.Equals(ACEVentas.ETipos.getTipoArreglo(ACEVentas.ETipos.TArreglo.Ingreso)) Then
                     _manejarstocks.Ingreso(x_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida, m_ectrl_arreglos.ALMAC_Id, _
                                            item.ARRDT_Cantidad, m_ectrl_arreglos.ARREG_FechaIngreso, _
                                            ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TMovimientoStock.IngresoArreglo), x_usuario)
                  ElseIf m_ectrl_arreglos.TIPOS_CodTipoArreglo.Equals(ACEVentas.ETipos.getTipoArreglo(ACEVentas.ETipos.TArreglo.Egreso)) Then
                     _manejarstocks.Egreso(x_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida, m_ectrl_arreglos.ALMAC_Id, _
                                            item.ARRDT_Cantidad, m_ectrl_arreglos.ARREG_FechaIngreso, _
                                            ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TMovimientoStock.SalidaArreglo), x_usuario)
                  Else
                     Throw New Exception("No se completo el proceso")
                  End If

               End If

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
   ''' Anular arreglo
   ''' </summary>
   ''' <param name="x_periodo">codigo de periodo</param>
   ''' <param name="x_motivo">motivo de anulacion</param>
   ''' <param name="m_proceso">permiso de anulacion para fechas posteriores a la fecha de creacion</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
    Public Function Anular(ByVal x_periodo As String, ByVal x_motivo As String, ByVal m_proceso As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Dim _constantes As New ACBVentas.BConstantes
            Dim _eliFec As Boolean = False
            Dim _fecha As DateTime = _constantes.getFecha()
            'If Not _fecha.Date = m_ectrl_arreglos.ARREG_FechaIngreso.Date Then
            '' Verificar si el usuario tiene autorizacion
            '  If Not m_proceso Then
            'Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
            'End If
            _eliFec = True
            'End If

            DAEnterprise.BeginTransaction()
            Dim _arreglo As New BCTRL_Arreglos
            _arreglo.CTRL_Arreglos = New ECTRL_Arreglos
            _arreglo.CTRL_Arreglos.ARREG_Codigo = m_ectrl_arreglos.ARREG_Codigo
            _arreglo.CTRL_Arreglos.ARREG_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Anulado)
            _arreglo.CTRL_Arreglos.ARREG_AnuladoCaja = _eliFec
            _arreglo.CTRL_Arreglos.ARREG_FechaAnulacion = _fecha
            _arreglo.CTRL_Arreglos.ARREG_MotivoAnulacion = x_motivo
            _arreglo.CTRL_Arreglos.ALMAC_Id = m_ectrl_arreglos.ALMAC_Id
            _arreglo.CTRL_Arreglos.Instanciar(ACEInstancia.Modificado)
            If _arreglo.Guardar(x_usuario) Then
                For Each item As ECTRL_ArreglosDetalle In m_ectrl_arreglos.ListCTRL_ArreglosDetalle
                    Dim _manejarstock As New BManejarStock
                    _manejarstock.AnulacionIngresoArreglo(x_periodo, item.ARTIC_Codigo, _arreglo.CTRL_Arreglos.ALMAC_Id, _arreglo.CTRL_Arreglos.ARREG_Codigo, item.ARRDT_Item, item.ARRDT_Cantidad, x_usuario)
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
   Public Function BuscarArreglos(ByVal x_tbusqueda As TBus, ByVal x_fecini As DateTime, ByVal x_fecfin As Date, ByVal x_codigo As String) As Boolean
      Try
         Dim _where As New Hashtable
         Select Case x_tbusqueda
            Case TBus.Codigo
               _where.Add("ARREG_Numero", New ACWhere(x_codigo, ACWhere.TipoWhere._Like))
            Case TBus.Fecha
               _where.Add("ARREG_FechaIngreso", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
            Case Else

         End Select
         Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, ACJoin.TipoJoin.Inner, _
                                 New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoArreglo")}, _
                                 New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoArreglo")}))
            '-- Dim _joine As New List(Of ACJoin)
            _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("ENTID_Codigo", "ARREG_UsrCrea")} _
                               , New ACCampos() {New ACCampos("ENTID_RazonSocial", "Usuario") _
                                               , New ACCampos("ENTID_PtrNombre1", "PrtNombre")}))

            Return CargarTodos(_join, _where)

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
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoArreglo")}, _
                              New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoArreglo")}))
         Dim _where As New Hashtable
         _where.Add("ARREG_Codigo", New ACWhere(x_codigo))
         If Cargar(_join, _where) Then
            Dim _detalle As New BCTRL_ArreglosDetalle
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
               Dim _order As New ACOrdenador(Of ECTRL_ArreglosDetalle)(String.Format("ARRDT_Item ASC"))
               _detalle.ListCTRL_ArreglosDetalle.Sort(_order)
               m_ectrl_arreglos.ListCTRL_ArreglosDetalle = _detalle.ListCTRL_ArreglosDetalle
               Return True
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

