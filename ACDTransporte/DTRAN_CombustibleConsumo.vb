Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_CombustibleConsumo

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "

    'Public Function getCorrelativo(ByVal x_campo As String) As Integer
    '   Try
    '      DAEnterprise.AsignarProcedure(getSelectID(x_campo), CommandType.Text)
    '      Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
    '      Return CType(m_data.Tables(0).Rows(0)("Id"), Integer)
    '   Catch ex As Exception
    '      Throw ex
    '   End Try
    'End Function

    ' <summary> 
    ' Capa de Datos: TRAN_COMCOSS_ObtConCombustible
    ' </summary>
    ' <param name="x_comco_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function TRAN_COMCOSS_ObtConCombustible(ByVal x_tran_combustibleconsumo As ETRAN_CombustibleConsumo, ByVal x_comco_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_COMCOSS_ObtConCombustible")
            DAEnterprise.AgregarParametro("@COMCO_Id", x_comco_id, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_tran_combustibleconsumo)
                    x_tran_combustibleconsumo.Instanciar(ACEInstancia.Consulta)
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

    ' <summary> 
    ' Capa de Datos: TRAN_ObtenerConsumoAdBlue
    ' </summary>
    ' <param name="x_recib_codigo">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function TRAN_ObtenerConsumoAdBlue(ByRef m_tran_consumoadblue As ETRAN_CombustibleConsumo, ByVal x_comco_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_ObtenerConsumoAdBlue")
            DAEnterprise.AgregarParametro("@COMCO_Id", x_comco_id, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    m_tran_consumoadblue = New ETRAN_CombustibleConsumo()
                    If reader.Read() Then
                        ACEsquemas.ACCargarEsquema(reader, m_tran_consumoadblue)
                        m_tran_consumoadblue.Instanciar(ACEInstancia.Consulta)
                        Return True
                    End If

                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AnularRegistro(ByVal x_comco_id As Long, ByVal x_estado As String, ByVal x_usuario As String) As Boolean
        Dim _sql As String = ""
        Try
            Dim _fecha As DateTime = GetFecha()
            _sql &= String.Format("Update Transportes.TRAN_CombustibleConsumo Set COMCO_Estado = '{1}'{0}", vbNewLine, x_estado)
            _sql &= String.Format(",COMCO_UsrMod = '{1}', COMCO_FecMod = '{2}'{0}", vbNewLine, x_usuario, _fecha.ToString(m_formatofecha))
            _sql &= String.Format("Where COMCO_Id = {1}{0}", vbNewLine, x_comco_id)
            _sql &= String.Format("{0}", vbNewLine)
            DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery() > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Procedimiento "TRAN_CAJASS_ConsumoCombustible" por el Generador 02/04/2012
    ' </summary> 
    ' <param name="m_listTRAN_CombustibleConsumo">Lista donde se cargaran los valores</param> 
    ' <param name="x_viaje_id">Parametro 1: </param> 
    ' <returns>Si no hay registros devuelve Falso</returns> 
    ' <remarks></remarks> 
    Public Function TRAN_CAJASS_ConsumoCombustible(ByRef m_listTRAN_CombustibleConsumo As List(Of ETRAN_CombustibleConsumo), ByVal x_viaje_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_CAJASS_ConsumoCombustible")
            DAEnterprise.AgregarParametro("@VIAJE_Id", x_viaje_id, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim e_tran_combustibleconsumo As New ETRAN_CombustibleConsumo()
                        ACEsquemas.ACCargarEsquema(reader, e_tran_combustibleconsumo)
                        e_tran_combustibleconsumo.Instanciar(ACEInstancia.Consulta)
                        m_listTRAN_CombustibleConsumo.Add(e_tran_combustibleconsumo)
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

    ' <summary> 
    ' Procedimiento "TRAN_CAJASS_ConsumoCombustible" por el Generador 02/04/2012
    ' </summary> 
    ' <param name="m_listTRAN_CombustibleConsumo">Lista donde se cargaran los valores</param> 
    ' <param name="x_viaje_id">Parametro 1: </param> 
    ' <returns>Si no hay registros devuelve Falso</returns> 
    ' <remarks></remarks> 
    Public Function TRAN_CAJASS_ConsumoAdBlue(ByRef m_listTRAN_CombustibleConsumo As List(Of ETRAN_CombustibleConsumo), ByVal x_viaje_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_CAJASS_ConsumoAdBlue")
            DAEnterprise.AgregarParametro("@VIAJE_Id", x_viaje_id, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim e_tran_combustibleconsumo As New ETRAN_CombustibleConsumo()
                        ACEsquemas.ACCargarEsquema(reader, e_tran_combustibleconsumo)
                        e_tran_combustibleconsumo.Instanciar(ACEInstancia.Consulta)
                        m_listTRAN_CombustibleConsumo.Add(e_tran_combustibleconsumo)
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

    ' <summary> 
    ' Capa de Datos: TRAN_COMCOSS_ConsumosXVehiculo
    ' </summary>
    ' <param name="x_vehic_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function TRAN_COMCOSS_ConsumosXVehiculo(ByVal m_listtran_combustibleconsumo As List(Of ETRAN_CombustibleConsumo), ByVal x_vehic_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_COMCOSS_ConsumosXVehiculo")
            DAEnterprise.AgregarParametro("@VEHIC_Id", x_vehic_id, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _tran_combustibleconsumo As New ETRAN_CombustibleConsumo()
                        ACEsquemas.ACCargarEsquema(reader, _tran_combustibleconsumo)
                        _tran_combustibleconsumo.Instanciar(ACEInstancia.Consulta)
                        m_listtran_combustibleconsumo.Add(_tran_combustibleconsumo)
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

    ' <summary> 
    ' Capa de Datos: consumos_combustible
    ' </summary>
    ' <param name="x_vehic_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function consumo_combustibles(ByRef m_data As DataTable, ByVal x_documento As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRANS_ConsumosComb")
            DAEnterprise.AgregarParametro("@DOCUS_CODIGO", x_documento, DbType.String, 15)

            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' buscar_compra
    ' </summary>
    '<param name="x_vehic_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function doc_compra(ByRef m_data As DataTable, ByVal x_fecini As String, ByVal x_fecfin As String, ByVal x_provee As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("documentos_compra")
            DAEnterprise.AgregarParametro("@fecini", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@fecfin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@proveedor", x_provee, DbType.String, 11)

            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '<summary> 
    'buscar_compra_pro
    '</summary>
    '<param name="x_vehic_id">Parametro 1: </param> 
    ' <returns></returns> 
    '<remarks></remarks> 
    Public Function doc_compra_pro(ByRef m_data As DataTable, ByVal x_provee As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("documentos_compra_pro")
            DAEnterprise.AgregarParametro("@proveedor", x_provee, DbType.String, 11)

            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' buscar_compra
    ' </summary>
    ' <param name="x_vehic_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function doc_compra_val(ByRef m_data As DataTable, ByVal x_doc As String, ByVal x_pro As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("Saldos_comp_consu")
            DAEnterprise.AgregarParametro("@documento", x_doc, DbType.String, 15)
            DAEnterprise.AgregarParametro("@proveedor", x_pro, DbType.String, 15)

            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' Capa de Datos: TRAN_COMCOSS_Consumos
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_cadena">Parametro 3: </param> 
    ' <param name="x_opcion">Parametro 4: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function TRAN_COMCOSS_Consumos(ByVal m_listtran_combustibleconsumo As List(Of ETRAN_CombustibleConsumo), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_cadena As String, ByVal x_opcion As Short) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_COMCOSS_Consumos")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _tran_combustibleconsumo As New ETRAN_CombustibleConsumo()
                  ACEsquemas.ACCargarEsquema(reader, _tran_combustibleconsumo)
                  _tran_combustibleconsumo.Instanciar(ACEInstancia.Consulta)
                  m_listtran_combustibleconsumo.Add(_tran_combustibleconsumo)
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

   Public Function GetFecha() As DateTime
      Try
         Return getDateTime()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "
   'Public Function getSelectID(ByVal x_campo As String) As String
   '   Dim sql As String = ""
   '   Try
   '      sql &= String.Format("SELECT IsNull(Max({0}), 0) As Id  from Transportes.TRAN_CombustibleConsumo {0}", x_campo, vbNewLine)
   '      Return sql
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function
#End Region
#End Region

End Class

