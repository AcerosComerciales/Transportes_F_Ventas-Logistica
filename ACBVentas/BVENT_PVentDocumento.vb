Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports ACFramework

Imports System.Configuration

Imports DAConexion

Public Class BVENT_PVentDocumento


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "

   ''' <summary>
   ''' Obtener la series de los documentos
   ''' </summary>
   ''' <param name="x_zonas_codigo">codigo de las zonas</param>
   ''' <param name="x_sucur_id">codigo de sucursal</param>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <param name="x_tipo_documento">codigo del tipo de documento</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetSeries(ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer, ByVal x_pvent_id As Integer, ByVal x_tipo_documento As String) As Boolean
      Try
         m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)()

         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin(ESucursales.Esquema, ESucursales.Tabla, "Sucur", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                              , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, "PVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")} _
                              , New ACCampos() {New ACCampos("PVENT_Descripcion", "PVENT_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))

         Dim x_where As New Hashtable
         x_where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
         x_where.Add("SUCUR_Id", New ACWhere(x_sucur_id))
         If x_pvent_id > 0 Then x_where.Add("PVENT_Id", New ACWhere(x_pvent_id))
         If x_tipo_documento.Length > 3 Then x_where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo_documento))

         Return d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_listVENT_PVentDocumento, _join, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtyener las seried de los documentos
   ''' </summary>
   ''' <param name="x_zonas_codigo">codigo de la zonas</param>
   ''' <param name="x_sucur_id">codigo de sucursal</param>
   ''' <param name="x_tipo_documento">codigo del tipo de documento</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetSeries(ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer, ByVal x_tipo_documento As String) As Boolean
      Try
         m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)()

         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin(ESucursales.Esquema, ESucursales.Tabla, "Sucur", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                              , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, "PVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")} _
                              , New ACCampos() {New ACCampos("PVENT_Descripcion", "PVENT_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))

         Dim x_where As New Hashtable
         x_where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
         x_where.Add("SUCUR_Id", New ACWhere(x_sucur_id))
         If x_tipo_documento.Length > 3 Then x_where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo_documento))

         Return d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_listVENT_PVentDocumento, _join, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener la series
   ''' </summary>
   ''' <param name="x_zonas_codigo">codigo de zona</param>
   ''' <param name="x_tipo_documento">codigo del tipo de documento</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetSeries(ByVal x_zonas_codigo As String, ByVal x_tipo_documento As String) As Boolean
      Try
         m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)()

         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin(ESucursales.Esquema, ESucursales.Tabla, "Sucur", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                              , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, "PVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")} _
                              , New ACCampos() {New ACCampos("PVENT_Descripcion", "PVENT_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))

         Dim x_where As New Hashtable
         x_where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
         If x_tipo_documento.Length > 3 Then x_where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo_documento))

         Return d_vent_pventdocumento.VENT_PVDOCUSS_Todos(m_listVENT_PVentDocumento, _join, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Funcion para predeterminar documentos en el momento de su creación
   ''' </summary>
   ''' <param name="x_zonas_codigo">codigo de zona</param>
   ''' <param name="x_sucur_id">codigo de sucursal</param>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <param name="x_tipo_documento">codigo del tipo de documento</param>
   ''' <param name="x_pvdocu_serie">serie del documento</param>
   ''' <param name="x_columnas">columna a la cual a a predeterminar</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function SetPredeterminado(ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer, ByVal x_pvent_id As Integer _
                                     , ByVal x_tipo_documento As String, ByVal x_pvdocu_serie As String, ByVal x_columnas As String _
                                     , ByVal x_usuario As String) As Boolean
      Dim x_where As New Hashtable
      Dim x_excluir As String() = {}
      Try
         DAEnterprise.BeginTransaction()

         x_where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo)) : x_where.Add("SUCUR_Id", New ACWhere(x_sucur_id)) : x_where.Add("PVENT_Id", New ACWhere(x_pvent_id))
         x_where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo_documento))

         m_vent_pventdocumento = New EVENT_PVentDocumento
         setBoolean(m_vent_pventdocumento, x_tipo_documento, x_columnas, x_excluir, False)
         m_vent_pventdocumento.Instanciar(ACEInstancia.Modificado)
         Guardar(x_where, x_usuario, x_excluir, New String() {})

         x_where.Add("PVDOCU_Serie", New ACWhere(x_pvdocu_serie))
         m_vent_pventdocumento = New EVENT_PVentDocumento
         setBoolean(m_vent_pventdocumento, x_tipo_documento, x_columnas, x_excluir, True)
         m_vent_pventdocumento.Instanciar(ACEInstancia.Modificado)
         Guardar(x_where, x_usuario, x_excluir, New String() {})

         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Prederminar valor booleano
   ''' </summary>
   ''' <param name="m_pventdoc">clase donde se encuentra grabado el tipo de documento</param>
   ''' <param name="x_tipo_documento">tipo de documento</param>
   ''' <param name="x_columna">columna sobre la cual se afectara el booleno</param>
   ''' <param name="x_exluir">campos a excluir</param>
   ''' <param name="x_opcion">valor del booleano</param>
   ''' <remarks></remarks>
   Private Sub setBoolean(ByRef m_pventdoc As EVENT_PVentDocumento, ByVal x_tipo_documento As String, ByVal x_columna As String, ByRef x_exluir As String(), ByVal x_opcion As Boolean)
      Try
         Select Case x_tipo_documento
            Case ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Factura)
               x_exluir = New String() {"PVDOCU_PredetBoleta", "PVDOCU_PredetGuiaRemisRemitTransportista", "PVDOCU_PredetGuiaRemisRemitVentas", "PVDOCU_PredetGuiaRemisTransportista"}
               m_vent_pventdocumento.PVDOCU_Predeterminado = x_opcion
            Case ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Boleta)
               x_exluir = New String() {"PVDOCU_Predeterminado", "PVDOCU_PredetGuiaRemisRemitTransportista", "PVDOCU_PredetGuiaRemisRemitVentas", "PVDOCU_PredetGuiaRemisTransportista"}
               m_vent_pventdocumento.PVDOCU_PredetBoleta = x_opcion
            Case ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
               If x_columna.Equals("PVDOCU_PredetGuiaRemisRemitTransportista") Then
                  x_exluir = New String() {"PVDOCU_Predeterminado", "PVDOCU_PredetBoleta", "PVDOCU_PredetGuiaRemisRemitVentas", "PVDOCU_PredetGuiaRemisTransportista"}
                  m_vent_pventdocumento.PVDOCU_PredetGuiaRemisRemitTransportista = x_opcion
               ElseIf x_columna.Equals("PVDOCU_PredetGuiaRemisRemitVentas") Then
                  x_exluir = New String() {"PVDOCU_Predeterminado", "PVDOCU_PredetBoleta", "PVDOCU_PredetGuiaRemisRemitTransportista", "PVDOCU_PredetGuiaRemisTransportista"}
                  m_vent_pventdocumento.PVDOCU_PredetGuiaRemisRemitVentas = x_opcion
               Else
                  m_vent_pventdocumento.PVDOCU_PredetGuiaRemisRemitTransportista = x_opcion
               End If
            Case ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionTransportista)
               x_exluir = New String() {"PVDOCU_Predeterminado", "PVDOCU_PredetBoleta", "PVDOCU_PredetGuiaRemisRemitTransportista", "PVDOCU_PredetGuiaRemisRemitVentas"}
               m_vent_pventdocumento.PVDOCU_PredetGuiaRemisTransportista = x_opcion
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Sub


#End Region

End Class

