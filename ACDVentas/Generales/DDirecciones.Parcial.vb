Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DDirecciones

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "Direcciones"
		End Get
	End Property
	Public ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property

#End Region

#Region " Constructores "
	
	Public Sub New()
		m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
	End Sub

#End Region

#Region " Procedimientos Almacenados "
	
	Public Function DIRECSS_Todos(ByRef listEDirecciones As List(Of EDirecciones)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDirecciones())
					While reader.Read()
						Dim e_direcciones As New EDirecciones()
						_utilitarios.ACCargarEsquemas(reader, e_direcciones)
						e_direcciones.Instanciar(ACEInstancia.Consulta)
						listEDirecciones.Add(e_direcciones)
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
    Public Function DIRECSS_Todos(ByRef listEDirecciones As List(Of EDirecciones), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New EDirecciones())
                    While reader.Read()
                        Dim e_direcciones As New EDirecciones()
                        _utilitarios.ACCargarEsquemas(reader, e_direcciones)
                        e_direcciones.Instanciar(ACEInstancia.Consulta)
                        listEDirecciones.Add(e_direcciones)
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


    Public Function AYUDASS_Busq_X_UBIGEOS(ByVal m_list_direcciones As List(Of EDirecciones), ByVal x_entid_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("AYUDASS_Busq_X_UBIGEOS")
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _direcciones As New EDirecciones()
                        ACEsquemas.ACCargarEsquema(reader, _direcciones)
                        _direcciones.Instanciar(ACEInstancia.Consulta)
                        m_list_direcciones.Add(_direcciones)
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
    'AYUDASS_Busq_X_UBIGEOS_Descripcion
    Public Function AYUDASS_Busq_X_UBIGEOS_Descripcion(ByVal m_list_direcciones As List(Of EDirecciones), ByVal x_direccion As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("AYUDASS_Busq_X_UBIGEOS_Descripcion")
            DAEnterprise.AgregarParametro("@DIRECCION", x_direccion, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _direcciones As New EDirecciones()
                        ACEsquemas.ACCargarEsquema(reader, _direcciones)
                        _direcciones.Instanciar(ACEInstancia.Consulta)
                        m_list_direcciones.Add(_direcciones)
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

    Public Function DIRECSS_Todos(ByRef listEDirecciones As List(Of EDirecciones), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDirecciones())
					While reader.Read()
						Dim e_direcciones As New EDirecciones()
						_utilitarios.ACCargarEsquemas(reader, e_direcciones)
						e_direcciones.Instanciar(ACEInstancia.Consulta)
						listEDirecciones.Add(e_direcciones)
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
	Public Function DIRECSS_Todos(ByRef listEDirecciones As List(Of EDirecciones), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDirecciones())
					While reader.Read()
						Dim e_direcciones As New EDirecciones()
						_utilitarios.ACCargarEsquemas(reader, e_direcciones)
						e_direcciones.Instanciar(ACEInstancia.Consulta)
						listEDirecciones.Add(e_direcciones)
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
	Public Function DIRECSS_Todos(ByRef listEDirecciones As List(Of EDirecciones), ByVal x_entid_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_entid_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDirecciones())
					While reader.Read()
						Dim e_direcciones As New EDirecciones()
						_utilitarios.ACCargarEsquemas(reader, e_direcciones)
						e_direcciones.Instanciar(ACEInstancia.Consulta)
						listEDirecciones.Add(e_direcciones)
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
	Public Function DIRECSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSS_UnReg(ByRef x_direcciones As EDirecciones, ByVal x_entid_codigo As String, ByVal x_direc_id As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_entid_codigo, x_direc_id), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_direcciones)
					x_direcciones.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSS_UnReg(ByRef x_direcciones As EDirecciones, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_direcciones)
					x_direcciones.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSS_UnReg(ByRef x_direcciones As EDirecciones, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_direcciones)
					x_direcciones.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSI_UnReg(ByRef x_direcciones As EDirecciones, ByVal x_usuario As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_direcciones, x_usuario), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSI_UnReg(ByRef x_direcciones As EDirecciones, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_direcciones, x_usuario, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSI_UnReg(ByRef x_direcciones As EDirecciones, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_direcciones, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSU_UnReg(ByVal x_direcciones As EDirecciones, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_direcciones, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSU_UnReg(ByVal x_direcciones As EDirecciones, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_direcciones, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSU_UnReg(ByVal x_direcciones As EDirecciones, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_direcciones, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSU_UnReg(ByVal x_direcciones As EDirecciones, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_direcciones, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSU_UnReg(ByVal x_direcciones As EDirecciones, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_direcciones, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSU_UnReg(ByVal x_direcciones As EDirecciones, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_direcciones, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSD_UnReg(ByVal x_direcciones As EDirecciones) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_direcciones), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function DIRECSD_UnReg(ByVal x_where As Hashtable) As Integer
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

	#region "Procedimientos Adicionales "
		Private Function getSelectAll() As String
			Dim sql As String = ""
			Try
				sql = " SELECT * "
				sql &= " FROM dbo.Direcciones" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM dbo.Direcciones" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EDirecciones)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal m_campos() As ACCampos, ByVal x_where As HashTable) As String
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
				sql &= " FROM dbo.Direcciones" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EDirecciones)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EDirecciones)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EDirecciones)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_entid_codigo As String) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM dbo.Direcciones" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ENTID_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_entid_codigo As String, ByVal x_direc_id As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM dbo.Direcciones" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ENTID_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine
				sql &= " AND DIREC_Id = " + x_direc_id.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_direcciones As EDirecciones, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_direcciones.DIREC_UsrCrea = x_usuario
				x_direcciones.DIREC_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EDirecciones)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_direcciones, x_direcciones.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_direcciones As EDirecciones, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_direcciones.DIREC_UsrCrea = x_usuario
				x_direcciones.DIREC_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EDirecciones)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_direcciones, x_direcciones.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_direcciones As EDirecciones, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_direcciones.DIREC_UsrCrea = x_usuario
				x_direcciones.DIREC_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EDirecciones)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_direcciones, x_direcciones.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_direcciones As EDirecciones, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_direcciones.DIREC_UsrMod = x_usuario
				x_direcciones.DIREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDirecciones)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ENTID_Codigo", New ACWhere(x_Direcciones.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("DIREC_Id", New ACWhere(x_Direcciones.DIREC_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_direcciones, _where, x_direcciones.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_direcciones As EDirecciones, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_direcciones.DIREC_UsrMod = x_usuario
				x_direcciones.DIREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDirecciones)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ENTID_Codigo", New ACWhere(x_Direcciones.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("DIREC_Id", New ACWhere(x_Direcciones.DIREC_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_direcciones, _where, x_direcciones.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_direcciones As EDirecciones, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_direcciones.DIREC_UsrMod = x_usuario
				x_direcciones.DIREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDirecciones)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_direcciones, x_where, x_direcciones.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_direcciones As EDirecciones, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_direcciones.DIREC_UsrMod = x_usuario
				x_direcciones.DIREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDirecciones)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ENTID_Codigo", New ACWhere(x_Direcciones.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("DIREC_Id", New ACWhere(x_Direcciones.DIREC_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_direcciones, _where, x_direcciones.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_direcciones As EDirecciones, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_direcciones.DIREC_UsrMod = x_usuario
				x_direcciones.DIREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDirecciones)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_direcciones, x_where, x_direcciones.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_direcciones As EDirecciones, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_direcciones.DIREC_UsrMod = x_usuario
				x_direcciones.DIREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDirecciones)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_direcciones, x_where, x_direcciones.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_direcciones As EDirecciones) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM dbo.Direcciones" & vbNewLine
				sql &= " WHERE "
				sql &= "    ENTID_Codigo = " & IIf(IsNothing(x_direcciones.ENTID_Codigo), "Null", "'" & x_direcciones.ENTID_Codigo & "'") & vbNewLine
				sql &= "And DIREC_Id = " & IIf(x_direcciones.DIREC_Id = 0, "Null", x_direcciones.DIREC_Id.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM dbo.Direcciones" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EDirecciones)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From dbo.Direcciones ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From dbo.Direcciones ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EDirecciones)(m_formatofecha) 
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
			DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
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
			DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
			x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
			Dim _fecha As DateTime = x_datos.Rows(0)(0)
			Return _fecha
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

End Class

