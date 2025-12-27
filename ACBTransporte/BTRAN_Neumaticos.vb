Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports ACBVentas
Imports ACFramework

Public Class BTRAN_Neumaticos

#Region " Variables "

#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "
   'Public Function getCorrelativo(ByRef x_tran_neumat_id As Integer) As Integer
   '   Try
   '      x_tran_neumat_id = d_tran_neumaticos.getCorrelativo() + 1
   '      Dim x_codigo As String = x_tran_neumat_id.ToString()
   '      Return x_codigo

   '   Catch ex As Exception
   '      Throw ex
   '   End Try

   'End Function


#End Region

#Region " Metodos "
   Public Function Busqueda(ByVal x_cadena As String) As Boolean
      Dim d_tran_neumaticos As New DTRAN_Neumaticos()
      Try
         m_listTRAN_Neumaticos = New List(Of ETRAN_Neumaticos)()
         Return d_tran_neumaticos.NEUMSS_Todos(m_listTRAN_Neumaticos, x_cadena)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean) As Boolean
        Dim d_tran_neumaticos As New DTRAN_Neumaticos()
        Try
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin("dbo", "Tipos", "TMnd", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodMoneda")} _
                               , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPO_Moneda")}))
            _join.Add(New ACJoin("dbo", "Tipos", "TMar", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodMarca")} _
                               , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPO_Marca")}))
            _join.Add(New ACJoin("dbo", "Tipos", "TNeu", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoLlanta")} _
                               , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPO_Llanta")}))

            _join.Add(New ACJoin("dbo", "Sucursales", "Suc", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                               , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
            Dim _where As New Hashtable()
            _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
            If x_todos = True Then
            Else
                _where.Add("NEUMA_Estado", New ACWhere(BConstantes.getEstado(BConstantes.Estados.Activo), ACWhere.TipoWhere.Igual))
            End If


            m_listTRAN_Neumaticos = New List(Of ETRAN_Neumaticos)()
            Return d_tran_neumaticos.TRAN_NEUMASS_Todos(m_listTRAN_Neumaticos, _join, _where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   Public Function CargarAyuda(ByVal x_where As Hashtable) As Boolean
      Dim d_tran_neumaticos As New DTRAN_Neumaticos()
      Try
         m_dtTRAN_Neumaticos = New DataTable()
         Return d_tran_neumaticos.NEUMSS_TodosAyuda(m_dtTRAN_Neumaticos, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Cargar(ByVal x_neuma_id As Long, ByVal _inner As Boolean) As Boolean
      Dim d_tran_neumaticos As New DTRAN_Neumaticos()
      Try
         If _inner Then
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin("Transportes", "TRAN_VehiculosNeumaticos", "VNeu", ACJoin.TipoJoin.Left _
                               , New ACCampos() {New ACCampos("NEUMA_Id", "NEUMA_Id")} _
                               , New ACCampos() {New ACCampos("VNEUM_Lado", "VNEUM_Lado") _
                                               , New ACCampos("VNEUM_Seccion", "VNEUM_Seccion") _
                                               , New ACCampos("VNEUM_InternoExterno", "VNEUM_InternoExterno") _
                                               , New ACCampos("VNEUM_Repuesto", "VNEUM_Repuesto") _
                                               , New ACCampos("VNEUM_FecAsignacion", "VNEUM_FecAsignacion") _
                                               , New ACCampos("VNEUM_OrdenPosicion", "VNEUM_OrdenPosicion")} _
                               , New ACCampos() {New ACCampos("VNEUM_Estado", "A", "A".GetType().ToString())}))
            _join.Add(New ACJoin("dbo", "Tipos", "TMar", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodMarca")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPO_Marca")}))
            _join.Add(New ACJoin("dbo", "Tipos", "TNeu", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoLlanta")} _
                               , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPO_Llanta")}))

            Dim _where As New Hashtable()
            _where.Add("NEUMA_Id", New ACWhere(x_neuma_id.ToString(), ACWhere.TipoWhere.Igual))

            m_tran_neumaticos = New ETRAN_Neumaticos(ETRAN_Neumaticos.TipoInicializacion.Movimientos)
            If d_tran_neumaticos.TRAN_NEUMASS_UnReg(m_tran_neumaticos, _join, _where) Then
               m_tran_neumaticos.TRAN_MovimientosNeumaticos = New ETRAN_MovimientosNeumaticos
               m_tran_neumaticos.TRAN_VehiculosNeumaticos = New ETRAN_VehiculosNeumaticos
               Return True
            End If
            Return False
         Else
            Dim _where As New Hashtable()
            Dim _listNeumatico As New List(Of ETRAN_Neumaticos)()
                _where.Add("Neu.NEUMA_Id", New ACWhere(x_neuma_id.ToString(), ACWhere.TipoWhere.Igual))
                If d_tran_neumaticos.TRAN_NEUMASS_Todos(_listNeumatico, _where) Then
               m_tran_neumaticos = _listNeumatico(0)
               Return True
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    Public Function TRAM_NEUMASS_Activos() As DataTable
        Dim _listNeumatico As New List(Of ETRAN_Neumaticos)()
        Return d_tran_neumaticos.TRAM_NEUMASS_Activos(_listNeumatico)
    End Function

#End Region

End Class

