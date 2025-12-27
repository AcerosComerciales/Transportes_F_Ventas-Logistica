Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DLOG_Stocks

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "LOG_Stocks"
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
	
	Public Function LOG_STOCKSS_Todos(ByRef x_listLOG_Stocks As List(Of ELOG_Stocks)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ELOG_Stocks())
					While reader.Read()
						Dim x_elog_stocks As New ELOG_Stocks()
						_utilitarios.ACCargarEsquemas(reader, x_elog_stocks)
						x_elog_stocks.Instanciar(ACEInstancia.Consulta)
						x_listLOG_Stocks.Add(x_elog_stocks)
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

	Public Function LOG_STOCKSS_Todos(ByRef x_listLOG_Stocks As List(Of ELOG_Stocks), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ELOG_Stocks())
					While reader.Read()
						Dim x_elog_stocks As New ELOG_Stocks()
						_utilitarios.ACCargarEsquemas(reader, x_elog_stocks)
						x_elog_stocks.Instanciar(ACEInstancia.Consulta)
						x_listLOG_Stocks.Add(x_elog_stocks)
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

	Public Function LOG_STOCKSS_Todos(ByRef x_listLOG_Stocks As List(Of ELOG_Stocks), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ELOG_Stocks())
					While reader.Read()
						Dim x_elog_stocks As New ELOG_Stocks()
						_utilitarios.ACCargarEsquemas(reader, x_elog_stocks)
						x_elog_stocks.Instanciar(ACEInstancia.Consulta)
						x_listLOG_Stocks.Add(x_elog_stocks)
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

	Public Function LOG_STOCKSS_Todos(ByRef x_listLOG_Stocks As List(Of ELOG_Stocks), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ELOG_Stocks())
					While reader.Read()
						Dim x_elog_stocks As New ELOG_Stocks()
						_utilitarios.ACCargarEsquemas(reader, x_elog_stocks)
						x_elog_stocks.Instanciar(ACEInstancia.Consulta)
						x_listLOG_Stocks.Add(x_elog_stocks)
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

	Public Function LOG_STOCKSS_Todos(ByRef x_elog_stocks As ELOG_Stocks, ByVal x_almac_id As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_almac_id), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_elog_stocks)
					x_elog_stocks.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSS_UnReg(ByRef x_elog_stocks As ELOG_Stocks, ByVal x_stock_id As Long, ByVal x_almac_id As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_stock_id, x_almac_id), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_elog_stocks)
					x_elog_stocks.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSS_UnReg(ByRef x_elog_stocks As ELOG_Stocks, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_elog_stocks)
					x_elog_stocks.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSS_UnReg(ByRef x_elog_stocks As ELOG_Stocks, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_elog_stocks)
					x_elog_stocks.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSI_UnReg(ByRef x_log_stocks As ELOG_Stocks, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_log_stocks, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSI_UnReg(ByRef x_log_stocks As ELOG_Stocks, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_log_stocks, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSI_UnReg(ByRef x_log_stocks As ELOG_Stocks, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_log_stocks, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSU_UnReg(ByVal x_log_stocks As ELOG_Stocks, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stocks, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSU_UnReg(ByVal x_log_stocks As ELOG_Stocks, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stocks, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSU_UnReg(ByVal x_log_stocks As ELOG_Stocks, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stocks, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSU_UnReg(ByVal x_log_stocks As ELOG_Stocks, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stocks, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSU_UnReg(ByVal x_log_stocks As ELOG_Stocks, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stocks, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSU_UnReg(ByVal x_log_stocks As ELOG_Stocks, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_log_stocks, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSD_UnReg(ByVal x_log_stocks As ELOG_Stocks) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_log_stocks), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function LOG_STOCKSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Logistica.LOG_Stocks" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.LOG_Stocks" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ELOG_Stocks)(m_formatofecha)
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
				sql &= " FROM Logistica.LOG_Stocks" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ELOG_Stocks)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ELOG_Stocks)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ELOG_Stocks)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_almac_id As Short) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.LOG_Stocks" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ALMAC_Id = " + x_almac_id.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_stock_id As Long, ByVal x_almac_id As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.LOG_Stocks" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "STOCK_Id = " + x_stock_id.ToString() & vbNewLine
				sql &= " AND ALMAC_Id = " + x_almac_id.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.LOG_Stocks" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ELOG_Stocks)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ELOG_Stocks)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_log_stocks As ELOG_Stocks, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stocks.STOCK_UsrCrea = x_usuario
				x_log_stocks.STOCK_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ELOG_Stocks)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_log_stocks, x_log_stocks.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_log_stocks As ELOG_Stocks, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stocks.STOCK_UsrCrea = x_usuario
				x_log_stocks.STOCK_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ELOG_Stocks)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_log_stocks, x_log_stocks.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_log_stocks As ELOG_Stocks, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stocks.STOCK_UsrCrea = x_usuario
				x_log_stocks.STOCK_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ELOG_Stocks)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_log_stocks, x_log_stocks.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stocks As ELOG_Stocks, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stocks.STOCK_UsrMod = x_usuario
				x_log_stocks.STOCK_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_Stocks)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("STOCK_Id", New ACWhere(x_LOG_Stocks.STOCK_Id, ACWhere.TipoWhere.Igual))
				_where.Add("ALMAC_Id", New ACWhere(x_LOG_Stocks.ALMAC_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_log_stocks, _where, x_log_stocks.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stocks As ELOG_Stocks, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stocks.STOCK_UsrMod = x_usuario
				x_log_stocks.STOCK_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_Stocks)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("STOCK_Id", New ACWhere(x_LOG_Stocks.STOCK_Id, ACWhere.TipoWhere.Igual))
				_where.Add("ALMAC_Id", New ACWhere(x_LOG_Stocks.ALMAC_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_log_stocks, _where, x_log_stocks.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stocks As ELOG_Stocks, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stocks.STOCK_UsrMod = x_usuario
				x_log_stocks.STOCK_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_Stocks)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_log_stocks, x_where, x_log_stocks.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stocks As ELOG_Stocks, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stocks.STOCK_UsrMod = x_usuario
				x_log_stocks.STOCK_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_Stocks)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("STOCK_Id", New ACWhere(x_LOG_Stocks.STOCK_Id, ACWhere.TipoWhere.Igual))
				_where.Add("ALMAC_Id", New ACWhere(x_LOG_Stocks.ALMAC_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_log_stocks, _where, x_log_stocks.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stocks As ELOG_Stocks, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stocks.STOCK_UsrMod = x_usuario
				x_log_stocks.STOCK_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_Stocks)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_log_stocks, x_where, x_log_stocks.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_log_stocks As ELOG_Stocks, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_log_stocks.STOCK_UsrMod = x_usuario
				x_log_stocks.STOCK_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ELOG_Stocks)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_log_stocks, x_where, x_log_stocks.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_log_stocks As ELOG_Stocks) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.LOG_Stocks" & vbNewLine
				sql &= " WHERE "
				sql &= "    STOCK_Id = " & IIf(x_log_stocks.STOCK_Id = 0, "Null", x_log_stocks.STOCK_Id.ToString()) & vbNewLine
				sql &= "And ALMAC_Id = " & IIf(x_log_stocks.ALMAC_Id = 0, "Null", x_log_stocks.ALMAC_Id.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.LOG_Stocks" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ELOG_Stocks)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.LOG_Stocks ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.LOG_Stocks ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ELOG_Stocks)(m_formatofecha) 
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

