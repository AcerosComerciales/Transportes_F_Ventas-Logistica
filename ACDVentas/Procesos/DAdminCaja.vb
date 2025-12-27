Imports ACEVentas
Imports DAConexion
Imports System.Data.Common
Imports ACFramework

Public Class DAdminCaja

#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Datos: TRAN_CAJASS_CuadreCajaPagos
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TRAN_CAJASS_CuadreCajaPagos(ByVal m_listteso_caja As List(Of ETESO_Caja), ByVal x_docve_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_CAJASS_CuadreCajaPagos")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 12)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _teso_caja As New ETESO_Caja()
                  ACEsquemas.ACCargarEsquema(reader, _teso_caja)
                  _teso_caja.Instanciar(ACEInstancia.Consulta)
                  m_listteso_caja.Add(_teso_caja)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ''' <summary> 
   ''' Capa de Datos: VENT_DOCVESS_CajaPagos
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_DOCVESS_CajaPagos(ByVal m_listteso_caja As List(Of ETESO_Caja), ByVal x_docve_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_DOCVESS_CajaPagos")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 15)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _teso_caja As New ETESO_Caja()
                  ACEsquemas.ACCargarEsquema(reader, _teso_caja)
                  _teso_caja.Instanciar(ACEInstancia.Consulta)
                  m_listteso_caja.Add(_teso_caja)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Datos: VENT_DOCVESS_CajaPagosXCajaCodigo _M
    ''' </summary>
    ''' <param name="x_caja_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_DOCVESS_CajaPagosXCajaCodigo(ByVal m_listteso_caja As List(Of ETESO_Caja), ByVal x_caja_codigo As String, ByVal x_caja_codigo1 As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_DOCVESS_CajaPagosXCodigoCaja")
            DAEnterprise.AgregarParametro("@CAJA_Codigo", x_caja_codigo, DbType.String, 12)
            DAEnterprise.AgregarParametro("@CAJA_Codigo1", x_caja_codigo1, DbType.String, 12)

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _teso_caja As New ETESO_Caja()
                        ACEsquemas.ACCargarEsquema(reader, _teso_caja)
                        _teso_caja.Instanciar(ACEInstancia.Consulta)
                        m_listteso_caja.Add(_teso_caja)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'TESO_GastosXCodigoCajaChica
    ''' <summary> 
    ''' Capa de Datos: VENT_DOCVESS_CajaPagosXCajaCodigo  
    ''' </summary>
    ''' <param name="x_caja_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_DOCVESS_CajaPagosXCajaCodigo(ByVal m_list_teso_cajaChicaPago As List(Of ETESO_CajaChicaIngreso), ByVal x_caja_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_GastosXCodigoCajaChica")
            DAEnterprise.AgregarParametro("@Caja_id", x_caja_codigo, DbType.String, 12)
            '  DAEnterprise.AgregarParametro("@CAJA_Codigo1", x_caja_codigo1, DbType.String, 12)

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _teso_cajaChicaPago As New ETESO_CajaChicaIngreso()
                        ACEsquemas.ACCargarEsquema(reader, _teso_cajaChicaPago)
                        _teso_cajaChicaPago.Instanciar(ACEInstancia.Consulta)
                        m_list_teso_cajaChicaPago.Add(_teso_cajaChicaPago)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary> 
    ''' Capa de Datos: VENT_DOCVESS_CajaPagosXCajaCodigo _M
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_DOCVESS_CajaPagosNC(ByVal m_listteso_caja As List(Of ETESO_Caja), ByVal x_docve_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_DOCVESS_CajaPagosNC")
            DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 15)

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _teso_caja As New ETESO_Caja()
                        ACEsquemas.ACCargarEsquema(reader, _teso_caja)
                        _teso_caja.Instanciar(ACEInstancia.Consulta)
                        m_listteso_caja.Add(_teso_caja)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary> 
   ''' Capa de Datos: TRAN_CAJASS_FacturasXCancelar
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TRAN_CAJASS_FacturasXCancelar(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_CAJASS_FacturasXCancelar")
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventa As New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                  _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventa.Add(_vent_docsventa)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: VEN_CAJASS_FacturasXCancelar
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VEN_CAJASS_FacturasXCancelar(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VEN_CAJASS_FacturasXCancelar")
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventa As New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                  _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventa.Add(_vent_docsventa)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: TRAN_CAJASS_FacturasXCliente
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <param name="x_todos">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TRAN_CAJASS_FacturasXCliente(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_entid_codigo As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_CAJASS_FacturasXCliente")
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventa As New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                  _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventa.Add(_vent_docsventa)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: VENT_DOCVESS_FacturasXCliente
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <param name="x_todos">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_DOCVESS_FacturasXCliente(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_DOCVESS_FacturasXCliente")
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventa As New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                  _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventa.Add(_vent_docsventa)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Datos: VENT_DOCVESS_FacturasXCliente
    ''' </summary>
    ''' <param name="x_entid_codigo">Parametro 1: </param> 
    ''' <param name="x_todos">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_DOCRec_SaldosXCliente(ByVal m_listTESO_Recibos As List(Of ETESO_Recibos), ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_DOCREC_SaldosXCliente")
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _rec_Recibos As New ETESO_Recibos
                        'Dim _vent_docsventa As New EVENT_DocsVenta()
                        'ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                        '_vent_docsventa.Instanciar(ACEInstancia.Consulta)
                        ACEsquemas.ACCargarEsquema(reader, _rec_Recibos)
                        _rec_Recibos.Instanciar(ACEInstancia.Consulta)
                        m_listTESO_Recibos.Add(_rec_Recibos)
                        ' m_listvent_docsventa.Add(_vent_docsventa)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary> 
    ''' Capa de Datos: TESO_GastosXCajaChica
    ''' </summary>
    ''' <param name="x_entid_codigo">Parametro 1: </param> 
    ''' <param name="x_todos">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function TESO_GastosXCajaChica(ByVal m_list_cajachicapago As List(Of ETESO_CajaChicaIngreso), ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TESO_GastosXCajaChica")
            DAEnterprise.AgregarParametro("@DESCRIPCION", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _rec_CAJA_CHICA As New ETESO_CajaChicaIngreso
                        'Dim _vent_docsventa As New EVENT_DocsVenta()
                        'ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                        '_vent_docsventa.Instanciar(ACEInstancia.Consulta)
                        ACEsquemas.ACCargarEsquema(reader, _rec_CAJA_CHICA)
                        _rec_CAJA_CHICA.Instanciar(ACEInstancia.Consulta)
                        m_list_cajachicapago.Add(_rec_CAJA_CHICA)
                        ' m_listvent_docsventa.Add(_vent_docsventa)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'TESO_GastosXCajaChica


    ''' <summary>
    ''' Obtener los pagos
    ''' </summary>
    ''' <param name="x_listteso_caja">lista de clases de pagos</param>
    ''' <param name="x_docs_codigo">codigo del documento de venta</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPagos(ByVal x_listteso_caja As List(Of ETESO_Caja), ByVal x_docs_codigo As String) As Boolean
      Dim _sql As String = ""
      Try
         _sql &= String.Format("Select * From Tesoreria.TESO_Caja Where DOCVE_Codigo In ({1}){0}", vbNewLine, x_docs_codigo)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: VENT_CAJASS_ValidarPagos
   ''' </summary>
   ''' <param name="x_fecfin">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <param name="x_entid_razonsocial">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_CAJASS_ValidarPagos(ByVal m_listccuadrependientes As List(Of ECCuadrePendientes), ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_entid_razonsocial As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_CAJASS_ValidarPagos")
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@ENTID_RazonSocial", x_entid_razonsocial, DbType.String, 150)
            DAEnterprise.CommandTimeOut = 0
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

                If reader.HasRows Then
                    While reader.Read()
                        Dim _ccuadrependientes As New ECCuadrePendientes()
                        ACEsquemas.ACCargarEsquema(reader, _ccuadrependientes)
                        _ccuadrependientes.Instanciar(ACEInstancia.Consulta)
                        m_listccuadrependientes.Add(_ccuadrependientes)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Datos: VENT_CAJASS_ValidarPagos
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_pvent_id">Parametro 2: </param> 
    ''' <param name="x_entid_razonsocial">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_ValidarPagosCreditos(ByVal m_listccuadrependientes As List(Of ECCuadrePendientes), ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_entid_razonsocial As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_CAJASS_ValidarPagosCreditos")
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@ENTID_RazonSocial", x_entid_razonsocial, DbType.String, 150)
            ''' DAEnterprise.CommandTimeOut = 0
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

                If reader.HasRows Then
                    While reader.Read()
                        Dim _ccuadrependientes As New ECCuadrePendientes()
                        ACEsquemas.ACCargarEsquema(reader, _ccuadrependientes)
                        _ccuadrependientes.Instanciar(ACEInstancia.Consulta)
                        m_listccuadrependientes.Add(_ccuadrependientes)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Actualizar la fecha de pago
   ''' </summary>
   ''' <param name="x_docve_codigo"></param>
   ''' <param name="x_fecha"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ActualizarFechaPago(ByVal x_docve_codigo As String, ByVal x_fecha As DateTime, ByVal x_usuario As String)
      Try
         Dim _sql As String = String.Format("Update Ventas.VENT_DocsVenta Set DOCVE_FechaPago = '{0}', DOCVE_FPUsrMod = {2}, DOCVE_UsrMod = {2}, DOCVE_FecMod = GetDate() Where DOCVE_Codigo = '{1}'", x_fecha.ToString("MM-dd-yyyy"), x_docve_codigo, x_usuario)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Dim i As Integer = DAEnterprise.ExecuteNonQuery()
         Return i > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos de Controles"

#End Region


End Class
