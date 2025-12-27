Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration

Imports DAConexion
Imports ACFramework

Public Class BTRAN_Documentos

#Region " Variables "
   Dim COMBUSTIBLE As ETRAN_CombustibleConsumo
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function crearDocumento(ByVal x_descripcion As String) As Boolean
      Dim _tran_documentodetalle As New ETRAN_DocumentosDetalle()
      Try
         m_tran_documentos.ListETRAN_DocumentosDetalle = New List(Of ETRAN_DocumentosDetalle)()
         _tran_documentodetalle.DOCUS_Codigo = m_tran_documentos.DOCUS_Codigo
         _tran_documentodetalle.ENTID_Codigo = m_tran_documentos.ENTID_Codigo
         _tran_documentodetalle.DCDET_Item = 1
         _tran_documentodetalle.DCDET_Cantidad = 1
         _tran_documentodetalle.DCDET_Descripcion = x_descripcion
         _tran_documentodetalle.DCDET_Importe = m_tran_documentos.DOCUS_TotalPago
         _tran_documentodetalle.DCDET_SubImporte = m_tran_documentos.DOCUS_TotalPago
         _tran_documentodetalle.DCDET_Estado = ETRAN_DocumentosDetalle.getEstado(ETRAN_DocumentosDetalle.Estado.Ingresado)
         _tran_documentodetalle.Instanciar(ACFramework.ACEInstancia.Nuevo)
         m_tran_documentos.ListETRAN_DocumentosDetalle.Add(_tran_documentodetalle)

         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Guardar(ByVal x_usuario As String, ByVal x_detalle As Boolean, Optional ByVal x_transaccion As Boolean = True) As Boolean
      Dim i As Integer = 1
      Try
         If x_transaccion Then DAEnterprise.BeginTransaction()
         m_tran_documentos.DOCUS_Id = getCorrelativo("DOCUS_Id")
         m_tran_documentos.DOCUS_Estado = ETRAN_Documentos.getEstado(ETRAN_Documentos.Estado.Ingresado)
         If Guardar(x_usuario) Then
            If x_detalle Then
               Dim _btran_documentosdetalle As New BTRAN_DocumentosDetalle
               For Each item As ETRAN_DocumentosDetalle In m_tran_documentos.ListETRAN_DocumentosDetalle
            
                  item.DCDET_Item = i
                  _btran_documentosdetalle.TRAN_DocumentosDetalle = item
                  _btran_documentosdetalle.TRAN_DocumentosDetalle.DOCUS_Codigo = m_tran_documentos.DOCUS_Codigo
                  _btran_documentosdetalle.TRAN_DocumentosDetalle.ENTID_Codigo = m_tran_documentos.ENTID_Codigo
                  _btran_documentosdetalle.TRAN_DocumentosDetalle.DCDET_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Ingresado)
                  _btran_documentosdetalle.Guardar(x_usuario)
                  i += 1
               Next
            End If
            If x_transaccion Then DAEnterprise.CommitTransaction()
            Return True
         End If
      Catch ex As Exception
         If x_transaccion Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function


    ' <summary>
    ' proceso guardar detalle _a
    ' </summary>
    ' <param name="x_docus_codigo"></param>
    '<param name="x_entid_codigo"></param>
    ' <param name="x_tran"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    ' 
    Public Function Guardar_det(ByVal LIST As  List(Of ETRAN_DocumentosDetalle),ByVal x_usuario As String, ByVal x_detalle As Boolean, Optional ByVal x_transaccion As Boolean = True) As Boolean
      Dim i As Integer = 1
      Try
         If x_transaccion Then DAEnterprise.BeginTransaction()
         m_tran_documentos.DOCUS_Id = getCorrelativo("DOCUS_Id")
         m_tran_documentos.DOCUS_Estado = ETRAN_Documentos.getEstado(ETRAN_Documentos.Estado.Ingresado)
         If Guardar(x_usuario) Then
            If x_detalle Then
               Dim _btran_documentosdetalle As New BTRAN_DocumentosDetalle
                    '  Dim m_tran_documentoss As BTRAN_Documentos

                    _btran_documentosdetalle.ListTRAN_DocumentosDetalle=LIST
               
              For Each item As ETRAN_DocumentosDetalle In _btran_documentosdetalle.ListTRAN_DocumentosDetalle
                  item.DCDET_Item = i
                  _btran_documentosdetalle.TRAN_DocumentosDetalle = item
                  _btran_documentosdetalle.TRAN_DocumentosDetalle.DOCUS_Codigo = m_tran_documentos.DOCUS_Codigo
                  _btran_documentosdetalle.TRAN_DocumentosDetalle.ENTID_Codigo = m_tran_documentos.ENTID_Codigo
                  _btran_documentosdetalle.TRAN_DocumentosDetalle.DCDET_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Ingresado)
                  _btran_documentosdetalle.TRAN_DocumentosDetalle.Instanciar(ACEInstancia.Nuevo)
                  _btran_documentosdetalle.Guardar(x_usuario)
                  i += 1
               Next

            End If
            If x_transaccion Then DAEnterprise.CommitTransaction()
            Return True
         End If
      Catch ex As Exception
         If x_transaccion Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function



   Public Function EliminarDocumento(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_tran As Boolean) As Boolean
      Dim b_tran_documentodetalle As New BTRAN_DocumentosDetalle
      Dim _where As New Hashtable
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
         _where.Add("DOCUS_Codigo", New ACWhere(x_docus_codigo))
         _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
         If b_tran_documentodetalle.Eliminar(_where) Then
            Eliminar(_where)
            If x_tran Then DAEnterprise.CommitTransaction()
            Return True
         End If
         Return False
      Catch ex As Exception
         If x_tran Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   Public Function getCliente(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean _
                         , ByVal x_fechas As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         Dim _where As New Hashtable()
         setJoinWhere(_join, _where, x_todos, x_fechas, x_fecini, x_fecfin)
         _where.Add(x_campo, New ACWhere(x_cadena, "Cli", "System.String", ACWhere.TipoWhere._Like))
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub setJoinWhere(ByRef _join As List(Of ACJoin), ByRef _where As Hashtable, ByVal x_todos As Boolean, ByVal x_fechas As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime)
      Try
         _join.Add(New ACJoin("dbo", "Entidades", "Cli", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento") _
                                              , New ACCampos("TIPOS_DescCorta", "TIPOS_TipoDocCorta")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TMon", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))

         If x_fechas Then _where.Add("DOCUS_Fecha", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
         If Not x_todos Then _where.Add("DOCUS_Estado", New ACWhere(ETRAN_Documentos.getEstado(ETRAN_Documentos.Estado.Ingresado), ACWhere.TipoWhere.Igual))
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Function CargarDocumento(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Dim _join As New List(Of ACJoin)
      Dim _where As New Hashtable()
      Try
         m_tran_documentos = New ETRAN_Documentos()
         _join.Add(New ACJoin("dbo", "Entidades", "Cli", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento") _
                                             , New ACCampos("ENTID_Direccion", "ENTID_Direccion")}))
         _where.Add("DOCUS_Codigo", New ACWhere(x_docus_codigo))
         _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
         If x_detalle Then
            If Cargar(_join, _where) Then
               Dim m_docdetalle As New BTRAN_DocumentosDetalle
               If m_docdetalle.CargarTodos(x_docus_codigo, x_entid_codigo) Then
                  m_tran_documentos.ListETRAN_DocumentosDetalle = m_docdetalle.ListTRAN_DocumentosDetalle
                  Return True
               Else
                  m_tran_documentos.ListETRAN_DocumentosDetalle = New List(Of ETRAN_DocumentosDetalle)
               End If
            End If
         Else
            Return Cargar(_join, _where)
         End If

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GenCancelacion(ByVal x_usuario As String, ByVal x_fecha As DateTime)
      Try
         Dim _bdocumento As New BTRAN_Documentos
         _bdocumento.TRAN_Documentos = New ETRAN_Documentos
         _bdocumento.TRAN_Documentos.Instanciar(ACEInstancia.Modificado)
         _bdocumento.TRAN_Documentos.DOCUS_Codigo = m_tran_documentos.DOCUS_Codigo
         _bdocumento.TRAN_Documentos.ENTID_Codigo = m_tran_documentos.ENTID_Codigo
         _bdocumento.TRAN_Documentos.DOCUS_FechaCancelacion = x_fecha
         _bdocumento.TRAN_Documentos.DOCUS_Estado = ETRAN_Documentos.getEstado(ETRAN_Documentos.Estado.Confirmado)

         Return _bdocumento.Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    'Creado Frank 
    Public Function AnularDocumento(ByVal x_usuario As String, ByVal x_docus_Codigo As String, ByVal x_entid_codigo As String, ByVal x_fecha As DateTime, ByVal x_motivo_anulacion As String)
        Try
            Dim _bdocumento As New BTRAN_Documentos
            _bdocumento.TRAN_Documentos = New ETRAN_Documentos
            _bdocumento.TRAN_Documentos.Instanciar(ACEInstancia.Modificado)
            _bdocumento.TRAN_Documentos.DOCUS_Codigo = x_docus_Codigo
            _bdocumento.TRAN_Documentos.ENTID_Codigo = x_entid_codigo
            _bdocumento.TRAN_Documentos.DOCUS_FechaCancelacion = x_fecha
            _bdocumento.TRAN_Documentos.Docus_MotivoAnulacion = x_motivo_anulacion
            _bdocumento.TRAN_Documentos.DOCUS_Estado = ETRAN_Documentos.getEstado(ETRAN_Documentos.Estado.Anulado)

            Return _bdocumento.Guardar(x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' Capa de Negocio: TRAN_ObtenerDocumentosCompra
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_pvent_id">Parametro 3: </param> 
    ' <param name="x_opcion">Parametro 4: </param> 
    ' <param name="x_cadena">Parametro 5: </param> 
    ' <param name="x_todos">Parametro 6: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function TRAN_ObtenerDocumentosCompra(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        m_listtran_documentos = New List(Of ETRAN_Documentos)
        Try
            Return d_tran_documentos.TRAN_ObtenerDocumentosCompra(m_listtran_documentos, x_fecini, x_fecfin, x_pvent_id, x_opcion, x_cadena, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_ObtenerDocumentosCompraNow(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_cadena As String) As Boolean
        m_listTRAN_Documentos = New List(Of ETRAN_Documentos)
        Try
            Return d_tran_documentos.TRAN_ObtenerDocumentosCompraNow(m_listTRAN_Documentos, x_fecini, x_fecfin, x_pvent_id, x_cadena)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarDetalle(ByVal x_condicion As String) As Boolean
      m_tran_documentos = New ETRAN_Documentos
        Try
            Return d_tran_documentos.CargarDetalle(m_tran_documentos, x_condicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function CargarDetalleMantenimiento(ByVal x_condicion As String) As Boolean
        m_tran_documentos = New ETRAN_Documentos
        Try
            Return d_tran_documentos.CargarDetalle(m_tran_documentos, x_condicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

End Class


