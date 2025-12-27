Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DDIST_GuiasTodas


#Region " Variables "
    Private m_formatofecha As String
    Public ReadOnly Property Tabla() As String
        Get
            Return "DIST_GuiasRemision"
        End Get
    End Property
    Public ReadOnly Property Esquema() As String
        Get
            Return "Logistica"
        End Get
    End Property

#End Region

#Region " Constructores "

    Public Sub New()
        m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
    End Sub

#End Region

#Region " Procedimientos Almacenados "

    Public Function DIST_GUIARSS_Todos(ByRef x_listDIST_GuiasRemision As List(Of EDIST_GuiasTodas)) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New EDIST_GuiasTodas())
                    While reader.Read()
                        Dim x_edist_guiasremision As New EDIST_GuiasTodas()
                        _utilitarios.ACCargarEsquemas(reader, x_edist_guiasremision)
                        x_edist_guiasremision.Instanciar(ACEInstancia.Consulta)
                        x_listDIST_GuiasRemision.Add(x_edist_guiasremision)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSS_Todos(ByRef x_listDIST_GuiasRemision As List(Of EDIST_GuiasTodas), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New EDIST_GuiasTodas())
                    While reader.Read()
                        Dim x_edist_guiasremision As New EDIST_GuiasTodas()
                        _utilitarios.ACCargarEsquemas(reader, x_edist_guiasremision)
                        x_edist_guiasremision.Instanciar(ACEInstancia.Consulta)
                        x_listDIST_GuiasRemision.Add(x_edist_guiasremision)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSS_Todos(ByRef x_listDIST_GuiasRemision As List(Of EDIST_GuiasTodas), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New EDIST_GuiasTodas())
                    While reader.Read()
                        Dim x_edist_guiasremision As New EDIST_GuiasTodas()
                        _utilitarios.ACCargarEsquemas(reader, x_edist_guiasremision)
                        x_edist_guiasremision.Instanciar(ACEInstancia.Consulta)
                        x_listDIST_GuiasRemision.Add(x_edist_guiasremision)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSS_Todos(ByRef x_listDIST_GuiasRemision As List(Of EDIST_GuiasTodas), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New EDIST_GuiasTodas())
                    While reader.Read()
                        Dim x_edist_guiasremision As New EDIST_GuiasTodas()
                        _utilitarios.ACCargarEsquemas(reader, x_edist_guiasremision)
                        x_edist_guiasremision.Instanciar(ACEInstancia.Consulta)
                        x_listDIST_GuiasRemision.Add(x_edist_guiasremision)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSS_UnReg(ByRef x_edist_guiasremision As EDIST_GuiasTodas, ByVal x_guiar_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(x_guiar_codigo), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_edist_guiasremision)
                    x_edist_guiasremision.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSS_UnReg(ByRef x_edist_guiasremision As EDIST_GuiasTodas, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_edist_guiasremision)
                    x_edist_guiasremision.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSS_UnReg(ByRef x_edist_guiasremision As EDIST_GuiasTodas, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_edist_guiasremision)
                    x_edist_guiasremision.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSI_UnReg(ByRef x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_dist_guiasremision, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSI_UnReg(ByRef x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_dist_guiasremision, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSI_UnReg(ByRef x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_dist_guiasremision, x_usuario, x_excluir, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSU_UnReg(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremision, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSU_UnReg(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremision, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSU_UnReg(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_where As Hashtable, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremision, x_where, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSU_UnReg(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremision, x_where, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSU_UnReg(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremision, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSU_UnReg(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremision, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSD_UnReg(ByVal x_dist_guiasremision As EDIST_GuiasTodas) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_dist_guiasremision), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DIST_GUIARSD_UnReg(ByVal x_where As Hashtable) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_where), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
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

    Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
        Try
            DAEnterprise.AsignarProcedure(getSelectId(x_campo, x_where), CommandType.Text)
            Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
            Return CType(m_data.Tables(0).Rows(0)("Id"), Integer)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "Procedimientos Adicionales "
    Private Function getSelectAll() As String
        Dim sql As String = ""
        Try
            sql = " SELECT * "
            sql &= " FROM Logistica.DIST_GuiasRemision" & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  * " & vbNewLine
            sql &= " FROM Logistica.DIST_GuiasRemision" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of EDIST_GuiasTodas)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  " & vbNewLine
            Dim i As Boolean = True
            For Each Item As ACCampos In m_campos
                If i Then
                    sql &= String.Format(" {0} As {1}{2}", Item.CampoOrigen, Item.CampoDestino, vbNewLine)
                    i = False
                Else
                    sql &= String.Format(",{0} As {1}{2}", Item.CampoOrigen, Item.CampoDestino, vbNewLine)
                End If
            Next
            sql &= " FROM Logistica.DIST_GuiasRemision" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of EDIST_GuiasTodas)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of EDIST_GuiasTodas)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of EDIST_GuiasTodas)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectBy(ByVal x_guiar_codigo As String) As String
        Dim sql As String = ""
        Try
        
            sql = " SELECT GUI.*,Entm.ENTID_RazonSocial AS Usuario_Modificador " & vbNewLine
            sql &= " FROM Logistica.DIST_GuiasRemision gui" & vbNewLine
            sql &= " left Join Entidades As Entm On EntM.ENTID_Codigo = gui.GUIAR_UsrMod " & vbNewLine
            sql &= " WHERE " & vbNewLine
		    sql &= "GUIAR_Codigo = " + IIf(IsNothing(x_guiar_codigo), "Null", "'" & x_guiar_codigo & "'") & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectBy(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  * " & vbNewLine
            sql &= " FROM Logistica.DIST_GuiasRemision" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of EDIST_GuiasTodas)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of EDIST_GuiasTodas)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getInsert(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_dist_guiasremision.GUIAR_UsrCrea = x_usuario
            x_dist_guiasremision.GUIAR_FecCrea = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of EDIST_GuiasTodas)(_fecha, m_formatofecha)
            sql = _insert.getInsert(Esquema, Tabla, x_dist_guiasremision, x_dist_guiasremision.Hash, New String() {})


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getInsert(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_dist_guiasremision.GUIAR_UsrCrea = x_usuario
            x_dist_guiasremision.GUIAR_FecCrea = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of EDIST_GuiasTodas)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_guiasremision, x_dist_guiasremision.Hash, New String() {}, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getInsert(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_dist_guiasremision.GUIAR_UsrCrea = x_usuario
            x_dist_guiasremision.GUIAR_FecCrea = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of EDIST_GuiasTodas)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_guiasremision, x_dist_guiasremision.Hash, x_excluir, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getUpdate(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_dist_guiasremision.GUIAR_UsrMod = x_usuario
            x_dist_guiasremision.GUIAR_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasTodas)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("GUIAR_Codigo", New ACWhere(x_dist_guiasremision.GUIAR_Codigo, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdate(Esquema, Tabla, x_dist_guiasremision, _where, x_dist_guiasremision.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getUpdate(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_dist_guiasremision.GUIAR_UsrMod = x_usuario
            x_dist_guiasremision.GUIAR_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasTodas)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("GUIAR_Codigo", New ACWhere(x_dist_guiasremision.GUIAR_Codigo, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_guiasremision, _where, x_dist_guiasremision.Hash, New String() {}, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getUpdate(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_where As Hashtable, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_dist_guiasremision.GUIAR_UsrMod = x_usuario
            x_dist_guiasremision.GUIAR_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasTodas)(_fecha, m_formatofecha)
            sql = _update.getUpdate(Esquema, Tabla, x_dist_guiasremision, x_where, x_dist_guiasremision.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getUpdate(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_dist_guiasremision.GUIAR_UsrMod = x_usuario
            x_dist_guiasremision.GUIAR_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasTodas)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("GUIAR_Codigo", New ACWhere(x_dist_guiasremision.GUIAR_Codigo, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_guiasremision, _where, x_dist_guiasremision.Hash, New String() {}, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getUpdate(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_dist_guiasremision.GUIAR_UsrMod = x_usuario
            x_dist_guiasremision.GUIAR_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasTodas)(_fecha, m_formatofecha)
            sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_guiasremision, x_where, x_dist_guiasremision.Hash, x_excluir, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getUpdate(ByVal x_dist_guiasremision As EDIST_GuiasTodas, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_dist_guiasremision.GUIAR_UsrMod = x_usuario
            x_dist_guiasremision.GUIAR_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasTodas)(_fecha, m_formatofecha)
            sql = _update.getUpdate(Esquema, Tabla, x_dist_guiasremision, x_where, x_dist_guiasremision.Hash, x_excluir, x_setfecha, x_setcampos)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDelete(ByVal x_dist_guiasremision As EDIST_GuiasTodas) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM Logistica.DIST_GuiasRemision" & vbNewLine
            sql &= " WHERE "
            sql &= "    GUIAR_Codigo = " & IIf(IsNothing(x_dist_guiasremision.GUIAR_Codigo), "Null", "'" & x_dist_guiasremision.GUIAR_Codigo & "'") & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDelete(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM Logistica.DIST_GuiasRemision" & vbNewLine
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of EDIST_GuiasTodas)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectId(ByVal x_campo As String) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.DIST_GuiasRemision ", x_campo)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectId(ByVal x_campo As String, ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.DIST_GuiasRemision ", x_campo)
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of EDIST_GuiasTodas)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
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
