Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports DAConexion
Imports ACFramework

Public Class BGenerarControl

#Region " Variables "
	
	Private m_dtGenerarControl As DataTable

	Private m_dsGenerarControl As DataSet

   Private m_bguia_remision As BDIST_GuiasRemision
   Private m_bdesp_salidas As BDESP_Salidas
   Private d_generarcontrol As DGenerarControl

   Private m_listguia_remision As List(Of EDIST_GuiasRemision)
   Private m_listgrdesalidas As List(Of EDIST_GuiasRemision)

#End Region

#Region " Constructores "
	
	Public Sub New()
      d_generarcontrol = New DGenerarControl
	End Sub

#End Region

#Region " Propiedades "
	
   Public Property ListGuia_Remision() As List(Of EDIST_GuiasRemision)
      Get
         Return m_bguia_remision.ListDIST_GuiasRemision
      End Get
      Set(ByVal value As List(Of EDIST_GuiasRemision))
         m_bguia_remision.ListDIST_GuiasRemision = value
      End Set
   End Property

   Public Property ListGRPendiente() As List(Of EDIST_GuiasRemision)
      Get
         Return m_listguia_remision
      End Get
      Set(ByVal value As List(Of EDIST_GuiasRemision))
         m_listguia_remision = value
      End Set
   End Property

   Public Property ListGRDeSalidas() As List(Of EDIST_GuiasRemision)
      Get
         Return m_listgrdesalidas
      End Get
      Set(ByVal value As List(Of EDIST_GuiasRemision))
         m_listgrdesalidas = value
      End Set
   End Property

   Public Property ListDESP_Salidas() As List(Of EDESP_Salidas)
      Get
         Return m_bdesp_salidas.ListDESP_Salidas
      End Get
      Set(ByVal value As List(Of EDESP_Salidas))
         m_bdesp_salidas.ListDESP_Salidas = value
      End Set
   End Property

   Public Property DTGenerarControl() As DataTable
      Get
         Return m_dtGenerarControl
      End Get
      Set(ByVal value As DataTable)
         m_dtGenerarControl = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "

#Region " Guias de Remision "

   ''' <summary>
   ''' Obtener las guias pendientes de salida/embarque
   ''' </summary>
   ''' <param name="x_fecini">Fecha Inicial</param>
   ''' <param name="x_fecfin">Fecha Final</param>
   ''' <param name="x_trans_id">Id del transportista</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function SalidasPendientes(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_trans_id As String) As Boolean
      m_bguia_remision = New BDIST_GuiasRemision
      Try
         Return m_bguia_remision.GUIA_SalidasPendientes(x_fecini, x_fecfin, x_trans_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Guias por conductor pendientes de salida/embarque
   ''' </summary>
   ''' <param name="x_condu_id">Id del conductor</param>
   ''' <param name="x_vehic_id">Id del vehiculo</param>
   ''' <param name="x_fecini">fecha inicial de consulta</param>
   ''' <param name="x_fecfin">fecha final de consulta</param>
   ''' <param name="x_trans_id">Id de transportista</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function GuiasPorConductor(ByVal x_condu_id As String, ByVal x_vehic_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_trans_id As String) As Boolean
      Dim _bguia_remision = New BDIST_GuiasRemision
      Try
         If _bguia_remision.GUIA_GuiasPorConductor(x_condu_id, x_vehic_id, x_fecini, x_fecfin, x_trans_id) Then
            m_listguia_remision = New List(Of EDIST_GuiasRemision)(_bguia_remision.ListDIST_GuiasRemision)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener las guias por conductor
   ''' </summary>
   ''' <param name="x_condu_id">Codifo de conductor</param>
   ''' <param name="x_vehic_id">Codigo del vehiculo</param>
   ''' <param name="x_fecini">fecha inicial de consulta</param>
   ''' <param name="x_trans_id">Codigo del transportista</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function GuiasPorConductor(ByVal x_condu_id As String, ByVal x_vehic_id As Long, ByVal x_fecini As Date, ByVal x_trans_id As String) As Boolean
      Dim _bguia_remision = New BDIST_GuiasRemision
      Try
         If _bguia_remision.GUIA_GuiasPorConductor(x_condu_id, x_vehic_id, x_fecini, x_trans_id) Then
            m_listguia_remision = New List(Of EDIST_GuiasRemision)(_bguia_remision.ListDIST_GuiasRemision)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar las guias de salida
   ''' </summary>
   ''' <param name="x_vehic_id">Codigo de vehiculos</param>
   ''' <param name="x_fecha">Fecha de consulta</param>
   ''' <param name="x_trans_id">condigo del transportista</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function CargarGuiasDeSalidas(ByVal x_vehic_id As Long, ByVal x_fecha As Date, ByVal x_trans_id As String) As Boolean
      Dim _bguia_remision As New BDIST_GuiasRemision
      Try
         If _bguia_remision.GUIA_GuiasDeSalidas(x_vehic_id, x_fecha, x_trans_id) Then
            m_listgrdesalidas = New List(Of EDIST_GuiasRemision)(m_bguia_remision.ListDIST_GuiasRemision)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Salidas "

   ''' <summary>
   ''' Cargar guias de salida
   ''' </summary>
   ''' <param name="x_fecha"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarSalidas(ByVal x_fecha As Date)
      m_bdesp_salidas = New BDESP_Salidas()
      Try
         Return m_bdesp_salidas.GUIA_Salidas(x_fecha)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar detalle de las guias pendientes de salida
   ''' </summary>
   ''' <param name="m_listGuia_Remision"></param>
   ''' <param name="x_fecha"></param>
   ''' <param name="x_csalida"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarSalidasDetalle(ByRef m_listGuia_Remision As List(Of EDIST_GuiasRemision), ByVal x_fecha As Date, ByVal x_csalida As String)
      m_listGuia_Remision = New List(Of EDIST_GuiasRemision)
      Try
         Return m_bdesp_salidas.GUIA_SalidasDetalle(m_listGuia_Remision, x_fecha, x_csalida)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Grabar "

   ''' <summary>
   ''' Grabar la salida del documento Guia
   ''' </summary>
   ''' <param name="x_usuario">Codigo de Usuario</param>
   ''' <param name="x_pvent_id">Codigo de punto de venta</param>
   ''' <param name="x_eguia_remision">Clase Guia de remision</param>
   ''' <param name="x_listGuia_Remision">Listado de guias de remision</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function GenerarSalida(ByVal x_usuario As String, ByVal x_pvent_id As Long, ByVal x_eguia_remision As EDIST_GuiasRemision, ByVal x_listGuia_Remision As List(Of EDIST_GuiasRemision)) As Boolean
      m_bdesp_salidas = New BDESP_Salidas
      Try
         DAEnterprise.BeginTransaction()
         m_bdesp_salidas.DESP_Salidas = New EDESP_Salidas(x_eguia_remision.VEHIC_Id, x_eguia_remision.ENTID_CodigoConductor)
         m_bdesp_salidas.DESP_Salidas.PVENT_Id = x_pvent_id
         Dim _peso As Decimal = 0
         For Each item As EDIST_GuiasRemision In x_listGuia_Remision
            If item.Generar Then
               _peso += item.GUIAR_TotalPeso
            End If
         Next
         m_bdesp_salidas.DESP_Salidas.SALID_Peso = _peso
         m_bdesp_salidas.DESP_Salidas.Instanciar(ACFramework.ACEInstancia.Nuevo)
         Dim _where As New Hashtable
         _where.Add("VEHIC_Id", New ACFramework.ACWhere(x_eguia_remision.VEHIC_Id))
         m_bdesp_salidas.DESP_Salidas.SALID_Id = m_bdesp_salidas.getCorrelativo("SALID_Id", _where)
         '' Grabar la salida de la guia
         If m_bdesp_salidas.Guardar(x_usuario, New String() {"SALID_HoraSalida"}) Then
            Dim _bdesp_guiarsalidas As New BDESP_GuiaRSalidas
            Dim i As Integer = 1
            For Each item As EDIST_GuiasRemision In x_listGuia_Remision
               If item.Generar Then
                  _bdesp_guiarsalidas.DESP_GuiaRSalidas = New EDESP_GuiaRSalidas(item.GUIAR_Codigo, m_bdesp_salidas.DESP_Salidas.SALID_Id, item.VEHIC_Id)
                  _bdesp_guiarsalidas.DESP_GuiaRSalidas.GUISA_Numero = i
                  _bdesp_guiarsalidas.DESP_GuiaRSalidas.PVENT_Id = x_pvent_id
                  _bdesp_guiarsalidas.Guardar(x_usuario)
                  i += 1
               End If
            Next
            DAEnterprise.CommitTransaction()
            Return True
         End If
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar la salida de guias de remision
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="item">Clase DESP_salidas</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function GrabarSalida(ByVal x_usuario As String, ByVal item As EDESP_Salidas) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         If item.Modificado Then
            Dim _bdesp_salidas As New BDESP_Salidas
            _bdesp_salidas.DESP_SALIDSU_UnRegActualizarLlegada(item, x_usuario)
         End If
         For Each iguia As EDIST_GuiasRemision In item.ListGuia_Remision
            If iguia.GUIAR_Codigo.Length = 0 Then
               Dim _bdesp_guiarsalidas As New BDESP_GuiaRSalidas
               _bdesp_guiarsalidas.DESP_GuiaRSalidas = New EDESP_GuiaRSalidas
               _bdesp_guiarsalidas.DESP_GuiaRSalidas.GUISA_HoraSalida = iguia.GUIAR_HoraSalida
               _bdesp_guiarsalidas.DESP_GuiaRSalidas.GUISA_HoraLlegada = iguia.GUIAR_HoraLlegada
               _bdesp_guiarsalidas.DESP_GuiaRSalidas.GUISA_Numero = iguia.Numero
               _bdesp_guiarsalidas.DESP_GuiaRSalidas.SALID_Id = item.SALID_Id
               _bdesp_guiarsalidas.DESP_GuiaRSalidas.VEHIC_Id = item.VEHIC_Id
               If iguia.Modificado Then _bdesp_guiarsalidas.GUIASU_ActualizarGuiaRSalidas(x_usuario)
            Else
               Dim _bguia_remision As New BDIST_GuiasRemision
               If iguia.Modificado Then _bguia_remision.GUIAR_UnRegActGuiaRemision(iguia, True, x_usuario)
               If iguia.Modificado Then _bguia_remision.GUIAR_UnRegActGuiaRemision(iguia, False, x_usuario)
            End If
         Next
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Generar un destino que no figura en las salidas o direcciones de las guias disponibles
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_edesp_guiarsalidas">Clase donde se almacen</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GenerarDestino(ByVal x_usuario As String, ByVal x_edesp_guiarsalidas As EDESP_GuiaRSalidas) As Boolean
      Dim _where As New Hashtable
      Try
         Dim _bdesp_guiarsalidas As New BDESP_GuiaRSalidas
         _bdesp_guiarsalidas.DESP_GuiaRSalidas = x_edesp_guiarsalidas
         _bdesp_guiarsalidas.DESP_GuiaRSalidas.Instanciar(ACFramework.ACEInstancia.Nuevo)
         _where.Add("SALID_Id", New ACWhere(_bdesp_guiarsalidas.DESP_GuiaRSalidas.SALID_Id, ACWhere.TipoWhere.Igual))
         _where.Add("VEHIC_Id", New ACWhere(_bdesp_guiarsalidas.DESP_GuiaRSalidas.VEHIC_Id, ACWhere.TipoWhere.Igual))
         _bdesp_guiarsalidas.DESP_GuiaRSalidas.GUISA_Numero = _bdesp_guiarsalidas.getCorrelativo("GUISA_Numero", _where)
         Return _bdesp_guiarsalidas.Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Quitar el destino de una guia de remison 
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_edesp_guiarsalidas">Objeto contenedor de la salida</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function QuitarDestinoGuia(ByVal x_usuario As String, ByVal x_edesp_guiarsalidas As EDESP_GuiaRSalidas) As Boolean
      Dim _where As New Hashtable
      Try
         Dim _bdesp_guiarsalidas As New BDESP_GuiaRSalidas
         _bdesp_guiarsalidas.DESP_GuiaRSalidas = x_edesp_guiarsalidas
         _bdesp_guiarsalidas.DESP_GuiaRSalidas.Instanciar(ACFramework.ACEInstancia.Nuevo)
         _where.Add("SALID_Id", New ACWhere(_bdesp_guiarsalidas.DESP_GuiaRSalidas.SALID_Id, ACWhere.TipoWhere.Igual))
         _where.Add("VEHIC_Id", New ACWhere(_bdesp_guiarsalidas.DESP_GuiaRSalidas.VEHIC_Id, ACWhere.TipoWhere.Igual))
         _where.Add("GUISA_Numero", New ACWhere(_bdesp_guiarsalidas.DESP_GuiaRSalidas.GUISA_Numero, ACWhere.TipoWhere.Igual))
         If Not IsNothing(_bdesp_guiarsalidas.DESP_GuiaRSalidas.GUIAR_Codigo) Then
            _where.Add("GUIAR_Id", New ACWhere(IIf(IsNothing(_bdesp_guiarsalidas.DESP_GuiaRSalidas.GUIAR_Codigo), "", _bdesp_guiarsalidas.DESP_GuiaRSalidas.GUIAR_Codigo), ACWhere.TipoWhere.Igual))
         End If
         Return _bdesp_guiarsalidas.Eliminar(_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Quitar una salida
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_edesp_salidas">objeto que contiene la salida</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function QuitarSalida(ByVal x_usuario As String, ByVal x_edesp_salidas As EDESP_Salidas) As Boolean
      Dim _where As New Hashtable
      Try
         DAEnterprise.BeginTransaction()
         Dim _bdesp_salidas As New BDESP_Salidas
         _bdesp_salidas.DESP_Salidas = x_edesp_salidas
         _bdesp_salidas.DESP_Salidas.Instanciar(ACFramework.ACEInstancia.Nuevo)
         For Each item As EDIST_GuiasRemision In _bdesp_salidas.DESP_Salidas.ListGuia_Remision
            Dim _desp_guiarsalidas As New EDESP_GuiaRSalidas
            _desp_guiarsalidas.VEHIC_Id = x_edesp_salidas.VEHIC_Id
            _desp_guiarsalidas.SALID_Id = x_edesp_salidas.SALID_Id
            _desp_guiarsalidas.GUIAR_Codigo = item.GUIAR_Codigo
            _desp_guiarsalidas.GUISA_Numero = item.GUISA_Numero
            QuitarDestinoGuia(x_usuario, _desp_guiarsalidas)
         Next
         _where.Add("SALID_Id", New ACWhere(_bdesp_salidas.DESP_Salidas.SALID_Id, ACWhere.TipoWhere.Igual))
         _where.Add("VEHIC_Id", New ACWhere(_bdesp_salidas.DESP_Salidas.VEHIC_Id, ACWhere.TipoWhere.Igual))
         If _bdesp_salidas.Eliminar(_where) Then
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

#End Region

   ''' <summary> 
   ''' Capa de Negocio: REPOSS_GuiasXConductor
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_id_conductor">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function REPOSS_GuiasXConductor(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_id_conductor As String) As Boolean
      m_listguia_remision = New List(Of EDIST_GuiasRemision)
      Try
         m_bguia_remision = New BDIST_GuiasRemision
         m_bguia_remision.ListDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
         If d_generarcontrol.REPOSS_GuiasXConductor(m_bguia_remision.ListDIST_GuiasRemision, x_fecini, x_fecfin, x_id_conductor) Then
            For Each item As EDIST_GuiasRemision In m_bguia_remision.ListDIST_GuiasRemision
               item.Tiempo = DateDiff(DateInterval.Minute, item.GUIAR_HoraLlegada, item.GUIAR_HoraSalida)
               If Math.Abs(item.Tiempo - Math.Round(item.Tiempo / 60, 0)) <> 0 Then
                  item.TiempoHora = String.Format("{0:00}:{1:00}", Math.Truncate(item.Tiempo / 60), item.Tiempo - Math.Truncate(item.Tiempo / 60) * 60)
               End If
            Next
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: REPOSS_GuiasXCliente
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_id_cliente">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function REPOSS_GuiasXCliente(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_id_cliente As String) As Boolean
      m_listguia_remision = New List(Of EDIST_GuiasRemision)
      Try
         m_bguia_remision = New BDIST_GuiasRemision
         m_bguia_remision.ListDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
         If d_generarcontrol.REPOSS_GuiasXCliente(m_bguia_remision.ListDIST_GuiasRemision, x_fecini, x_fecfin, x_id_cliente) Then
            For Each item As EDIST_GuiasRemision In m_bguia_remision.ListDIST_GuiasRemision
               item.Tiempo = DateDiff(DateInterval.Minute, item.GUIAR_HoraLlegada, item.GUIAR_HoraSalida)
               If (item.Tiempo - Math.Round(item.Tiempo / 60, 0)) > 0 Then
                  item.TiempoHora = String.Format("{0:00}:{1:00}", Math.Truncate(item.Tiempo / 60), item.Tiempo - Math.Truncate(item.Tiempo / 60) * 60)
               End If
            Next
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Carga la ayuda de conductores
   ''' </summary>
   ''' <param name="x_cadena"></param>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Ayuda(ByVal x_cadena As String, ByVal x_opcion As Short)
      Try
         m_dtGenerarControl = New DataTable
         Return d_generarcontrol.CONDSS_Ayuda(m_dtGenerarControl, x_cadena, x_opcion)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

