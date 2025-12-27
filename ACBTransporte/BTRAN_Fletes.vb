Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports ACBVentas
Imports ACEVentas
Imports ACFramework
Imports DAConexion

Public Class BTRAN_Fletes

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   Public Function CargarAyuda() As Boolean
      Dim d_tran_fletes As New DTRAN_Fletes()
      Try
         m_listTRAN_Fletes = New List(Of ETRAN_Fletes)()
         Return d_tran_fletes.TRAN_FLETESS_Todos(m_listTRAN_Fletes)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarDisponibles() As Boolean
      Dim d_tran_fletes As New DTRAN_Fletes()
      Try
         m_listTRAN_Fletes = New List(Of ETRAN_Fletes)()
         Return d_tran_fletes.FLETSS_TodosDisponibles(m_dtTRAN_Fletes)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ActualizarViaje(ByVal x_usuario As String) As Boolean
      Dim d_tran_fletes As New DTRAN_Fletes()
      Try
         Return d_tran_fletes.TRAN_FLETESU_UnReg(m_tran_fletes, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Procedimiento "TRAN_FLETESS_UnReg" por el Generador 27/02/2012
   ' </summary> 
   ' <param name="x_entid_codigo">Parametro 1: </param> 
   ' <returns>Si no hay registros devuelve Falso</returns> 
   ' <remarks></remarks> 
   Public Function TRAN_FLETESS_UnReg(ByVal x_entid_codigo As String) As Boolean
      m_listTRAN_Fletes = New List(Of ETRAN_Fletes)
      Try
         Return d_tran_fletes.TRAN_FLETESS_UnReg(m_listTRAN_Fletes, x_entid_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Negocio: TRAN_CAJASS_PendienteFletes
   ' </summary>
   ' <param name="x_fecfin">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function Reporte_PendienteFletes(ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      m_listTRAN_Fletes = New List(Of ETRAN_Fletes)
      Try
         Return d_tran_fletes.TRAN_CAJASS_PendienteFletes(m_listTRAN_Fletes, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Procedimiento "TRAN_FLETESS_Ayuda" por el Generador 20/03/2012
   ' </summary> 
   ' <param name="x_cadena">Parametro 1: </param> 
   ' <param name="x_opcion">Parametro 2: </param> 
   ' <param name="x_fecini">Parametro 3: </param> 
   ' <param name="x_fecfin">Parametro 4: </param> 
   ' <returns>Si no hay registros devuelve Falso</returns> 
   ' <remarks></remarks> 
   Public Function TRAN_FLETESS_Ayuda(ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      m_listTRAN_Fletes = New List(Of ETRAN_Fletes)
      Try
         Return d_tran_fletes.TRAN_FLETESS_Ayuda(m_listTRAN_Fletes, x_cadena, x_opcion, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Negocio: TRAN_FLETESS_ConsultaFletes
   ' </summary>
   ' <param name="x_cadena">Parametro 1: </param> 
   ' <param name="x_opcion">Parametro 2: </param> 
   ' <param name="x_opfecha">Parametro 3: </param> 
   ' <param name="x_fecini">Parametro 4: </param> 
   ' <param name="x_fecfin">Parametro 5: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function ConsultaFletes(ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_opfecha As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      m_listTRAN_Fletes = New List(Of ETRAN_Fletes)
      Try
         Return d_tran_fletes.TRAN_FLETESS_ConsultaFletes(m_listTRAN_Fletes, x_cadena, x_opcion, x_opfecha, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ' <summary> 
   ' Capa de Negocio: TRAN_FLETESS_ConsultaFletesDoc
   ' </summary>
   ' <param name="x_tipos_codtipodocumento">Parametro 1: </param> 
   ' <param name="x_docve_serie">Parametro 2: </param> 
   ' <param name="x_docve_numero">Parametro 3: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function ConsultaFletesDoc(ByVal x_tipos_codtipodocumento As String, ByVal x_docve_serie As String, ByVal x_docve_numero As String) As Boolean
      m_listTRAN_Fletes = New List(Of ETRAN_Fletes)
      Try
         Return d_tran_fletes.TRAN_FLETESS_ConsultaFletesDoc(m_listTRAN_Fletes, x_tipos_codtipodocumento, x_docve_serie, x_docve_numero)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    Public Function Cargar(ByVal x_cotiz_codigo As String, ByVal x_opcion As Boolean) As Boolean
        Try
            '' Cargar Cotización
            m_tran_fletes = New ETRAN_Fletes()
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                               , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Cliente") _
                                                 , New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
            '_join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Left _
            '                   , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
            '                   , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))
            _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TMon", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                               , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))
            _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TCond", ACJoin.TipoJoin.Left _
                               , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodModoPago")} _
                               , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_CodModoPago")}))
            '_join.Add(New ACJoin(ETRAN_Fletes.Esquema, ETRAN_Fletes.Tabla, "Flete", ACJoin.TipoJoin.Left _
            '                   , New ACCampos() {New ACCampos("FLETE_Id", "FLETE_Id")} _
            '                   , New ACCampos() {New ACCampos("VIAJE_Id", "VIAJE_Id")}))
            Dim _where As New Hashtable()
            _where.Add("ZONAS_Codigo", New ACWhere(BConstantes.ZONAS_Codigo))
            _where.Add("SUCUR_Id", New ACWhere(BConstantes.SUCUR_Id))
            _where.Add("PVENT_Id", New ACWhere(BConstantes.PVENT_Id))
            _where.Add("FLETE_Id", New ACWhere(x_cotiz_codigo))
            If Cargar(_join, _where) Then
               
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class

