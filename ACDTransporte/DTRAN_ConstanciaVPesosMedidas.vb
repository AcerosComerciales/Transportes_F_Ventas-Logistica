Imports System.Data.Common
Imports ACETransporte
Imports ACFramework
Imports DAConexion

Public Class DTRAN_ConstanciaVPesosMedidas
#Region " Variables "
    Private m_formatofecha As String


    Public ReadOnly Property Tabla() As String
        Get
            Return "TRAN_ConstanciaVPesosMedidas"
        End Get
    End Property
    Public ReadOnly Property Esquema() As String
        Get
            Return "Transportes"
        End Get
    End Property
#End Region

#Region " Constructores "
    Public Sub New()
        m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
    End Sub
#End Region
#Region " Procedimientos Almacenados "
    Public Function REPOSS_ConstanciaVPesosMedidas(ByRef m_tran_constanciavpesosmedidas As ETRAN_ConstanciaVPesosMedidas, ByVal x_const_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_ObtenerConstanciaVPesosMedidas")
            DAEnterprise.AgregarParametro("@const_codigo", x_const_codigo, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        m_tran_constanciavpesosmedidas = New ETRAN_ConstanciaVPesosMedidas()
                        ACEsquemas.ACCargarEsquema(reader, m_tran_constanciavpesosmedidas)
                        m_tran_constanciavpesosmedidas.Instanciar(ACEInstancia.Consulta)
                    End If
                    If reader.NextResult() Then
                        m_tran_constanciavpesosmedidas.ListETRAN_ConstanciaVGuiasDetalle = New List(Of ETRAN_ConstanciaVGuiasDetalle)
                        While reader.Read()
                            Dim _tran_vguiasdetalle As New ETRAN_ConstanciaVGuiasDetalle()
                            ACEsquemas.ACCargarEsquema(reader, _tran_vguiasdetalle)
                            _tran_vguiasdetalle.Instanciar(ACEInstancia.Consulta)
                            m_tran_constanciavpesosmedidas.ListETRAN_ConstanciaVGuiasDetalle.Add(_tran_vguiasdetalle)
                        End While
                    End If
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
    Public Function TRAN_BuscarConstanciasVPesosMedidas(ByVal m_listdist_constanciavpesosmedidas As List(Of ETRAN_ConstanciaVPesosMedidas), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_BuscarConstanciasVPesosMedidas")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _tran_constanciasvpesosmedidas As New ETRAN_ConstanciaVPesosMedidas()
                        ACEsquemas.ACCargarEsquema(reader, _tran_constanciasvpesosmedidas)
                        _tran_constanciasvpesosmedidas.Instanciar(ACEInstancia.Consulta)
                        m_listdist_constanciavpesosmedidas.Add(_tran_constanciasvpesosmedidas)
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
    ''' Capa de Datos: LOG_DISTSS_ObtenerGuiaVenta
    ''' </summary>
    ''' <param name="x_guiar_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function TRAN_ConstanciaVPesosMedidas(ByVal x_tran_constanciasvpesosmedidas As ETRAN_ConstanciaVPesosMedidas, ByVal x_const_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_ObtenerConstanciaVPesosMedidas")
            DAEnterprise.AgregarParametro("@CONST_Codigo", x_const_codigo, DbType.String, 14)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_tran_constanciasvpesosmedidas)
                    x_tran_constanciasvpesosmedidas.Instanciar(ACEInstancia.Consulta)
                    x_tran_constanciasvpesosmedidas.ListETRAN_ConstanciaVGuiasDetalle = New List(Of ETRAN_ConstanciaVGuiasDetalle)

                    If reader.NextResult() Then
                        While reader.Read()
                            Dim e_guiadetalle As New ETRAN_ConstanciaVGuiasDetalle()
                            ACEsquemas.ACCargarEsquema(reader, e_guiadetalle)
                            e_guiadetalle.Instanciar(ACEInstancia.Consulta)
                            x_tran_constanciasvpesosmedidas.ListETRAN_ConstanciaVGuiasDetalle.Add(e_guiadetalle)
                        End While
                    End If

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
    Public Function getNumero(ByVal x_serie As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_serie), CommandType.Text)
            Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
            If m_datos.Rows.Count > 0 Then
                Return CType(m_datos.Rows(0)("Numero"), Integer)
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getCorrelativo(ByVal x_campo As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getSelectId(x_campo), CommandType.Text)
            Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
            Return CType(m_data.Tables(0).Rows(0)("Id"), Integer)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    
    Public Function TRAN_CONSTANCIASVPM_UnReg(ByRef x_tran_constanciasvpm As ETRAN_ConstanciaVPesosMedidas, ByVal x_const_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(x_const_codigo), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_tran_constanciasvpm)
                    x_tran_constanciasvpm.Instanciar(ACEInstancia.Consulta)
                    return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region " Metodos "
	
    Private Function getDate() As String
        Dim x_datos As New DataTable()
        Try
            DAEnterprise.AsignarProcedure("select GetDate()", CommandType.Text)
            x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
            Dim _fecha As DateTime = x_datos.Rows(0)(0)
            Return "'" & _fecha.ToString(m_formatofecha) & "'"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDateTime() As DateTime
        Dim x_datos As New DataTable()
        Try
            DAEnterprise.AsignarProcedure("select GetDate()", CommandType.Text)
            x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
            Dim _fecha As DateTime = x_datos.Rows(0)(0)
            Return _fecha
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Procedimientos Adicionales "
    Public Function TRAN_CONSTVPesosMedidasSI_UnReg(ByRef x_tran_constanciaPesosMedidas As ETRAN_ConstanciaVPesosMedidas, ByVal x_usuario As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_tran_constanciaPesosMedidas, x_usuario), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_CONSTVPesosMedidasSU_UnReg(ByVal x_tran_documentos As ETRAN_ConstanciaVPesosMedidas, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tran_documentos, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_CONSTVPesosMedidasSD_UnReg(ByVal x_tran_documentos As ETRAN_ConstanciaVPesosMedidas) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_tran_documentos), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_serie As String) As String
        Dim sql As String = ""
        Try
            sql &= String.Format(" Select IsNull(Max(CONST_Numero), 0) As Numero from [Transportes].[TRAN_ConstanciaVPesosMedidas] ", vbNewLine)
            sql &= String.Format(" Where CONST_Serie = '{0}' {1}", x_serie,  vbNewLine)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getInsert(ByVal x_tran_constanciavpesosmedidas As ETRAN_ConstanciaVPesosMedidas, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_constanciavpesosmedidas.CONST_UsrCrea = x_usuario
            x_tran_constanciavpesosmedidas.CONST_FecCrea = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRAN_ConstanciaVPesosMedidas)(_fecha, m_formatofecha)
            sql = _insert.getInsert(Esquema, Tabla, x_tran_constanciavpesosmedidas, x_tran_constanciavpesosmedidas.Hash, New String() {})

            Debug.WriteLine(sql)
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    
    Private Function getUpdate(ByVal x_tran_constanciavpesosmedidas As ETRAN_ConstanciaVPesosMedidas, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_constanciavpesosmedidas.CONST_UsrMod = x_usuario
            x_tran_constanciavpesosmedidas.CONST_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRAN_ConstanciaVPesosMedidas)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("CONST_Codigo", New ACWhere(x_tran_constanciavpesosmedidas.CONST_Codigo, ACWhere.TipoWhere.Igual))
            _where.Add("CONST_RucGenerador", New ACWhere(x_tran_constanciavpesosmedidas.CONST_RucGenerador, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdate(Esquema, Tabla, x_tran_constanciavpesosmedidas, _where, x_tran_constanciavpesosmedidas.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getDelete(ByVal x_tran_constanciavpesosmedidas As ETRAN_ConstanciaVPesosMedidas) As String 
        Dim sql As String = ""
        Try

            sql  = " DELETE FROM Transportes.TRAN_ConstanciaVPesosMedidas" & vbNewLine
            sql &= " WHERE "
            sql &= "    CONST_Codigo = " & IIf(IsNothing(x_tran_constanciavpesosmedidas.CONST_Codigo), "Null", "'" & x_tran_constanciavpesosmedidas.CONST_Codigo & "'") & vbNewLine
            sql &= "And CONST_RucGenerador = " & IIf(IsNothing(x_tran_constanciavpesosmedidas.CONST_RucGenerador), "Null", "'" & x_tran_constanciavpesosmedidas.CONST_RucGenerador & "'") & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getSelectId(ByVal x_campo As String) As String 
        Dim sql As String = ""
        Try

            sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_ConstanciaVPesosMedidas", x_campo)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getSelectBy(ByVal x_const_codigo As String) As String
        Dim sql As String = ""
        Try
            sql = " SELECT constancia.*,Entm.ENTID_RazonSocial AS Usuario_Modificador " & vbNewLine
            sql &= " FROM Transportes.TRAN_ConstanciaVPesosMedidas constancia" & vbNewLine
            sql &= " left Join Entidades As Entm On EntM.ENTID_Codigo = constancia.CONST_UsrMod " & vbNewLine
            sql &= " WHERE " & vbNewLine
            sql &= "CONST_Codigo = " + IIf(IsNothing(x_const_codigo), "Null", "'" & x_const_codigo & "'") & vbNewLine


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class

