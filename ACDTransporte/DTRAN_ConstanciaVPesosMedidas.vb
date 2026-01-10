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
#End Region
End Class

