Imports System
Imports System.Data
Imports System.Collections.Generic
Imports ACFramework
Imports ACEVentas
Imports ACDVentas
Imports DAConexion

Partial Public Class BTESO_CajaChicaIngreso

#Region " Variables "
   Private m_listteso_cajachicapagos As List(Of ETESO_CajaChicaPagos)
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "

   Public Property ListTESO_CajaChicaPagos() As List(Of ETESO_CajaChicaPagos)
      Get
         Return m_listteso_cajachicapagos
      End Get
      Set(ByVal value As List(Of ETESO_CajaChicaPagos))
         m_listteso_cajachicapagos = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
    ''' <summary> 
    ''' Capa de Negocio: TESO_ConsultaCajaChica
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_cadena">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_todos">Parametro 5: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ConsultaCajaChica(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_cadena As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean, ByVal x_fecha As Boolean, ByVal x_tipocc As String) As Boolean
        m_listTESO_CajaChicaIngreso = New List(Of ETESO_CajaChicaIngreso)
        Try
            Return d_teso_cajachicaingreso.TESO_ConsultaCajaChica(m_listTESO_CajaChicaIngreso, x_fecini, x_fecfin, x_cadena, x_pvent_id, x_todos, x_fecha, x_tipocc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' Capa de Negocio: TESO_ConsultaCajaChica
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_cadena">Parametro 3: </param> 
    ' <param name="x_pvent_id">Parametro 4: </param> 
    ' <param name="x_todos">Parametro 5: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function TESO_GastosXNumeroCajaChica(ByVal x_pvent_id As Integer) As Boolean
        m_listTESO_CajaChicaIngreso = New List(Of ETESO_CajaChicaIngreso)
        Try
            Return d_teso_cajachicaingreso.TESO_GastosXNumeroCajaChica(m_listTESO_CajaChicaIngreso, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary> 
    ''' 
    ''' Capa de Negocio: TESO_ConsultaCajaChica
    ''' </summary>
    ''' <param name="x_cajac_id">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function TESO_ObtenerReciboCC(ByRef m_tran_recibosCC As ETESO_CajaChicaIngreso, ByVal x_cajac_id As String,
                                         ByVal x_pvent_id As Long) As Boolean
        m_tran_recibosCC = New ETESO_CajaChicaIngreso
        Try
            Return d_teso_cajachicaingreso.TESO_ObtenerReciboCC(m_tran_recibosCC, x_cajac_id, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' cargar registros de caja
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Cargar()
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                              , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))
         Dim _where As New Hashtable
         _where.Add("PVENT_Id", New ACWhere(m_eteso_cajachicaingreso.PVENT_Id))
         _where.Add("CAJAC_Id", New ACWhere(m_eteso_cajachicaingreso.CAJAC_Id))

         If Cargar(_join, _where) Then
            Dim _pagos As New BTESO_CajaChicaPagos
            m_listteso_cajachicapagos = New List(Of ETESO_CajaChicaPagos)
            If _pagos.ConsultaPagosCC(m_eteso_cajachicaingreso.PVENT_Id, m_eteso_cajachicaingreso.CAJAC_Id) Then
               m_listteso_cajachicapagos = _pagos.ListTESO_CajaChicaPagos
            End If
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' guardar registro de caja
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_detalle">detalle del regstro</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Guardar(ByVal x_usuario As String, ByVal x_detalle As Boolean) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         If Guardar(x_usuario) Then
            '' Anular el Detalle
            If x_detalle Then
               Dim _detalle As New BTESO_CajaChicaPagos
               Dim _where As New Hashtable
               _where.Add("CAJAC_Id", New ACWhere(m_eteso_cajachicaingreso.CAJAC_Id))
            _where.Add("PVENT_Id", new ACWhere(m_eteso_cajachicaingreso.PVENT_Id))
               If _detalle.CargarTodos(_where) Then
                  For Each item As ETESO_CajaChicaPagos In _detalle.ListTESO_CajaChicaPagos
                     _detalle.TESO_CajaChicaPagos = item
                     _detalle.TESO_CajaChicaPagos.Instanciar(ACEInstancia.Modificado)
                     _detalle.TESO_CajaChicaPagos.CAJAP_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
                     _detalle.Guardar(x_usuario)
                  Next
               End If
            End If
            DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No se completo el proceso de Grabado")
         End If
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

#End Region

End Class

