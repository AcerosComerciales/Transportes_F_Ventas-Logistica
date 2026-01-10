Imports ACETransporte
Imports ACFramework
Imports DAConexion

Public Class DTRAN_ConstanciaVGuiasDetalle
    
#Region " Variables "
    Private m_formatofecha As String
    Public ReadOnly Property Tabla() As String
        Get
            Return "TRAN_ConstanciaVGuiasDetalle"
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
    Public Function TRAN_CONSTVGuiasDetalleSI_UnReg(ByRef x_tran_constanciavguiasdetalle As ETRAN_ConstanciaVGuiasDetalle, ByVal x_usuario As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_tran_constanciavguiasdetalle, x_usuario), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_CONSTVGuiasDetalleSU_UnReg(ByVal x_tran_constanciavguiasdetalle As ETRAN_ConstanciaVGuiasDetalle, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tran_constanciavguiasdetalle, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_CONSTVGuiasDetalleSD_UnReg(ByVal x_tran_constanciavguiasdetalle As ETRAN_ConstanciaVGuiasDetalle) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_tran_constanciavguiasdetalle), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    
    Private Function getInsert(ByVal x_tran_constanciavguiasdetalle As ETRAN_ConstanciaVGuiasDetalle, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_constanciavguiasdetalle.CONSVG_UsrCrea = x_usuario
            x_tran_constanciavguiasdetalle.CONSVG_FecCrea = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRAN_ConstanciaVGuiasDetalle)(_fecha, m_formatofecha)
            sql = _insert.getInsert(Esquema, Tabla, x_tran_constanciavguiasdetalle, x_tran_constanciavguiasdetalle.Hash, New String() {})
            Debug.WriteLine(sql)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tran_constanciavguiasdetalle As ETRAN_ConstanciaVGuiasDetalle, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_constanciavguiasdetalle.CONSVG_UsrMod = x_usuario
            x_tran_constanciavguiasdetalle.CONSVG_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRAN_ConstanciaVGuiasDetalle)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("CONST_Codigo", New ACWhere(x_tran_constanciavguiasdetalle.CONST_Codigo, ACWhere.TipoWhere.Igual))
            _where.Add("GUIAR_Codigo", New ACWhere(x_tran_constanciavguiasdetalle.GUIAR_Codigo, ACWhere.TipoWhere.Igual))
            _where.Add("CONSGD_Item", New ACWhere(x_tran_constanciavguiasdetalle.CONSGD_Item, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdate(Esquema, Tabla, x_tran_constanciavguiasdetalle, _where, x_tran_constanciavguiasdetalle.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Function getDelete(ByVal x_tran_constanciavguiasdetalle As ETRAN_ConstanciaVGuiasDetalle) As String 
        Dim sql As String = ""
        Try

            sql  = " DELETE FROM Transportes.TRAN_ConstanciaVGuiasDetalle" & vbNewLine
            sql &= " WHERE "
            sql &= "    DOCUS_Codigo = " & IIf(IsNothing(x_tran_constanciavguiasdetalle.CONST_Codigo), "Null", "'" & x_tran_constanciavguiasdetalle.CONST_Codigo & "'") & vbNewLine
            sql &= "And ENTID_Codigo = " & IIf(IsNothing(x_tran_constanciavguiasdetalle.GUIAR_Codigo), "Null", "'" & x_tran_constanciavguiasdetalle.GUIAR_Codigo & "'") & vbNewLine
            sql &= "And DCDET_Item = " & IIf(x_tran_constanciavguiasdetalle.CONSGD_Item = 0, "Null", x_tran_constanciavguiasdetalle.CONSGD_Item.ToString()) & vbNewLine

            Return sql
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

End Class
