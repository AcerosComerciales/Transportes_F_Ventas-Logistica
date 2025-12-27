Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DLOG_StockIniciales

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "LOG_StockIniciales"
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
	
	Public Function LOG_STINISS_Todos(ByRef x_listLOG_StockIniciales As List(Of ELOG_StockIniciales)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ELOG_StockIniciales())
					While reader.Read()
						Dim x_elog_stockiniciales As New ELOG_StockIniciales()
						_utilitarios.ACCargarEsquemas(reader, x_elog_stockiniciales)
						x_elog_stockiniciales.Instanciar(ACEInstancia.Consulta)
						x_listLOG_StockIniciales.Add(x_elog_stockiniciales)
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

	Public Function LOG_STINISS_Todos(ByRef x_listLOG_StockIniciales As List(Of ELOG_StockIniciales), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ELOG_StockIniciales())
					While reader.Read()
						Dim x_elog_stockiniciales As New ELOG_StockIniciales()
						_utilitarios.ACCargarEsquemas(reader, x_elog_stockiniciales)
						x_elog_stockiniciales.Instanciar(ACEInstancia.Consulta)
						x_listLOG_StockIniciales.Add(x_elog_stockiniciales)
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

	Public Function LOG_STINISS_Todos(ByRef x_listLOG_StockIniciales As List(Of ELOG_StockIniciales), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ELOG_StockIniciales())
					While reader.Read()
						Dim x_elog_stockiniciales As New ELOG_StockIniciales()
						_utilitarios.ACCargarEsquemas(reader, x_elog_stockiniciales)
						x_elog_stockiniciales.Instanciar(ACEInstancia.Consulta)
						x_listLOG_StockIniciales.Add(x_elog_stockiniciales)
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

	Public Function LOG_STINISS_Todos(ByRef x_listLOG_StockIniciales As List(Of ELOG_StockIniciales), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ELOG_StockIniciales())
					While reader.Read()
						Dim x_elog_stockiniciales As New ELOG_StockIniciales()
						_utilitarios.ACCargarEsquemas(reader, x_elog_stockiniciales)
						x_elog_stockiniciales.Instanciar(ACEInstancia.Consulta)
						x_listLOG_StockIniciales.Add(x_elog_stockiniciales)
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

	Public Function LOG_STINISS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISS_UnReg(ByRef x_elog_stockiniciales As ELOG_StockIniciales, ByVal x_perio_codigo As String, ByVal x_artic_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_perio_codigo, x_artic_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_elog_stockiniciales)
					x_elog_stockiniciales.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISS_UnReg(ByRef x_elog_stockiniciales As ELOG_StockIniciales, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_elog_stockiniciales)
					x_elog_stockiniciales.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISS_UnReg(ByRef x_elog_stockiniciales As ELOG_StockIniciales, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_elog_stockiniciales)
					x_elog_stockiniciales.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISI_UnReg(ByRef x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_log_stockiniciales, x_usuario), CommandType.Text)
			Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
			If m_datos.Rows.Count > 0 Then
				x_log_stockiniciales.STINI_Id = CType(m_datos.Rows(0)(0), Long)
				Return x_log_stockiniciales.STINI_Id
			End If
			Return 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISI_UnReg(ByRef x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_log_stockiniciales, x_usuario, x_setfecha), CommandType.Text)
			Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
			If m_datos.Rows.Count > 0 Then
				x_log_stockiniciales.STINI_Id = CType(m_datos.Rows(0)(0), Long)
				Return x_log_stockiniciales.STINI_Id
			End If
			Return 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISI_UnReg(ByRef x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_log_stockiniciales, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
			If m_datos.Rows.Count > 0 Then
				x_log_stockiniciales.STINI_Id = CType(m_datos.Rows(0)(0), Long)
				Return x_log_stockiniciales.STINI_Id
			End If
			Return 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISU_UnReg(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stockiniciales, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISU_UnReg(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stockiniciales, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISU_UnReg(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stockiniciales, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISU_UnReg(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stockiniciales, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISU_UnReg(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stockiniciales, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISU_UnReg(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stockiniciales, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISD_UnReg(ByVal x_log_stockiniciales As ELOG_StockIniciales) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_log_stockiniciales), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STINISD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Logistica.LOG_StockIniciales" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.LOG_StockIniciales" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ELOG_StockIniciales)(m_formatofecha)
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
				sql &= " FROM Logistica.LOG_StockIniciales" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ELOG_StockIniciales)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ELOG_StockIniciales)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ELOG_StockIniciales)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_perio_codigo As String, ByVal x_artic_codigo As String) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.LOG_StockIniciales" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "PERIO_Codigo = " + IIf(IsNothing(x_perio_codigo), "Null", "'" & x_perio_codigo & "'") & vbNewLine
				sql &= " AND ARTIC_Codigo = " + IIf(IsNothing(x_artic_codigo), "Null", "'" & x_artic_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.LOG_StockIniciales" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ELOG_StockIniciales)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ELOG_StockIniciales)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stockiniciales.STINI_UsrCrea = x_usuario
				x_log_stockiniciales.STINI_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ELOG_StockIniciales)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_log_stockiniciales, x_log_stockiniciales.Hash, New String() {"STINI_Id"})
				sql &= " SELECT @@IDENTITY AS 'Identity'; "

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stockiniciales.STINI_UsrCrea = x_usuario
				x_log_stockiniciales.STINI_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ELOG_StockIniciales)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_log_stockiniciales, x_log_stockiniciales.Hash, New String() {"STINI_Id"}, x_setfecha)
				sql &= " SELECT @@IDENTITY AS 'Identity'; "

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stockiniciales.STINI_UsrCrea = x_usuario
				x_log_stockiniciales.STINI_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ELOG_StockIniciales)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_log_stockiniciales, x_log_stockiniciales.Hash, x_excluir, x_setfecha)
				sql &= " SELECT @@IDENTITY AS 'Identity'; "

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stockiniciales.STINI_UsrMod = x_usuario
				x_log_stockiniciales.SYINI_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_StockIniciales)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PERIO_Codigo", New ACWhere(x_LOG_StockIniciales.PERIO_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ARTIC_Codigo", New ACWhere(x_LOG_StockIniciales.ARTIC_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_log_stockiniciales, _where, x_log_stockiniciales.Hash, New String() {"STINI_Id"})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stockiniciales.STINI_UsrMod = x_usuario
				x_log_stockiniciales.SYINI_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_StockIniciales)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PERIO_Codigo", New ACWhere(x_LOG_StockIniciales.PERIO_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ARTIC_Codigo", New ACWhere(x_LOG_StockIniciales.ARTIC_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_log_stockiniciales, _where, x_log_stockiniciales.Hash, New String() {"STINI_Id"}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stockiniciales.STINI_UsrMod = x_usuario
				x_log_stockiniciales.SYINI_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_StockIniciales)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_log_stockiniciales, x_where, x_log_stockiniciales.Hash, New String() {"STINI_Id"})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stockiniciales.STINI_UsrMod = x_usuario
				x_log_stockiniciales.SYINI_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_StockIniciales)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PERIO_Codigo", New ACWhere(x_LOG_StockIniciales.PERIO_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ARTIC_Codigo", New ACWhere(x_LOG_StockIniciales.ARTIC_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_log_stockiniciales, _where, x_log_stockiniciales.Hash, New String() {"STINI_Id"}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stockiniciales.STINI_UsrMod = x_usuario
				x_log_stockiniciales.SYINI_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_StockIniciales)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_log_stockiniciales, x_where, x_log_stockiniciales.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stockiniciales As ELOG_StockIniciales, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stockiniciales.STINI_UsrMod = x_usuario
				x_log_stockiniciales.SYINI_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_StockIniciales)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_log_stockiniciales, x_where, x_log_stockiniciales.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_log_stockiniciales As ELOG_StockIniciales) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.LOG_StockIniciales" & vbNewLine
				sql &= " WHERE "
				sql &= "    PERIO_Codigo = " & IIf(IsNothing(x_log_stockiniciales.PERIO_Codigo), "Null", "'" & x_log_stockiniciales.PERIO_Codigo & "'") & vbNewLine
				sql &= "And ARTIC_Codigo = " & IIf(IsNothing(x_log_stockiniciales.ARTIC_Codigo), "Null", "'" & x_log_stockiniciales.ARTIC_Codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.LOG_StockIniciales" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ELOG_StockIniciales)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.LOG_StockIniciales ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.LOG_StockIniciales ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ELOG_StockIniciales)(m_formatofecha) 
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

