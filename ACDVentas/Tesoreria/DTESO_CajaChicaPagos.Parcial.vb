Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTESO_CajaChicaPagos

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "TESO_CajaChicaPagos"
		End Get
	End Property
	Public ReadOnly Property Esquema() As String
		Get
			Return "Tesoreria"
		End Get
	End Property

#End Region

#Region " Constructores "
	
	Public Sub New()
		m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
	End Sub

#End Region

#Region " Procedimientos Almacenados "
	
	Public Function TESO_CAJAPSS_Todos(ByRef x_listTESO_CajaChicaPagos As List(Of ETESO_CajaChicaPagos)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETESO_CajaChicaPagos())
					While reader.Read()
						Dim x_eteso_cajachicapagos As New ETESO_CajaChicaPagos()
						_utilitarios.ACCargarEsquemas(reader, x_eteso_cajachicapagos)
						x_eteso_cajachicapagos.Instanciar(ACEInstancia.Consulta)
						x_listTESO_CajaChicaPagos.Add(x_eteso_cajachicapagos)
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

	Public Function TESO_CAJAPSS_Todos(ByRef x_listTESO_CajaChicaPagos As List(Of ETESO_CajaChicaPagos), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETESO_CajaChicaPagos())
					While reader.Read()
						Dim x_eteso_cajachicapagos As New ETESO_CajaChicaPagos()
						_utilitarios.ACCargarEsquemas(reader, x_eteso_cajachicapagos)
						x_eteso_cajachicapagos.Instanciar(ACEInstancia.Consulta)
						x_listTESO_CajaChicaPagos.Add(x_eteso_cajachicapagos)
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

	Public Function TESO_CAJAPSS_Todos(ByRef x_listTESO_CajaChicaPagos As List(Of ETESO_CajaChicaPagos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETESO_CajaChicaPagos())
					While reader.Read()
						Dim x_eteso_cajachicapagos As New ETESO_CajaChicaPagos()
						_utilitarios.ACCargarEsquemas(reader, x_eteso_cajachicapagos)
						x_eteso_cajachicapagos.Instanciar(ACEInstancia.Consulta)
						x_listTESO_CajaChicaPagos.Add(x_eteso_cajachicapagos)
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

	Public Function TESO_CAJAPSS_Todos(ByRef x_listTESO_CajaChicaPagos As List(Of ETESO_CajaChicaPagos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETESO_CajaChicaPagos())
					While reader.Read()
						Dim x_eteso_cajachicapagos As New ETESO_CajaChicaPagos()
						_utilitarios.ACCargarEsquemas(reader, x_eteso_cajachicapagos)
						x_eteso_cajachicapagos.Instanciar(ACEInstancia.Consulta)
						x_listTESO_CajaChicaPagos.Add(x_eteso_cajachicapagos)
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

	Public Function TESO_CAJAPSS_Todos(ByRef x_eteso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_pvent_id As Long, ByVal x_cajac_id As Long) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_pvent_id, x_cajac_id), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eteso_cajachicapagos)
					x_eteso_cajachicapagos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSS_UnReg(ByRef x_eteso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_pvent_id As Long, ByVal x_cajac_id As Long, ByVal x_cajap_item As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_pvent_id, x_cajac_id, x_cajap_item), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eteso_cajachicapagos)
					x_eteso_cajachicapagos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSS_UnReg(ByRef x_eteso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eteso_cajachicapagos)
					x_eteso_cajachicapagos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSS_UnReg(ByRef x_eteso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eteso_cajachicapagos)
					x_eteso_cajachicapagos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSI_UnReg(ByRef x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_teso_cajachicapagos, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSI_UnReg(ByRef x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_teso_cajachicapagos, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSI_UnReg(ByRef x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_teso_cajachicapagos, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSU_UnReg(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_cajachicapagos, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSU_UnReg(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_cajachicapagos, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSU_UnReg(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_cajachicapagos, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSU_UnReg(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_cajachicapagos, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSU_UnReg(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_cajachicapagos, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSU_UnReg(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_cajachicapagos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSD_UnReg(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_teso_cajachicapagos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_CAJAPSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Tesoreria.TESO_CajaChicaPagos" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Tesoreria.TESO_CajaChicaPagos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETESO_CajaChicaPagos)(m_formatofecha)
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
				sql &= " FROM Tesoreria.TESO_CajaChicaPagos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETESO_CajaChicaPagos)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETESO_CajaChicaPagos)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETESO_CajaChicaPagos)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_pvent_id As Long, ByVal x_cajac_id As Long) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Tesoreria.TESO_CajaChicaPagos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "PVENT_Id = " + x_pvent_id.ToString() & vbNewLine
				sql &= " AND CAJAC_Id = " + x_cajac_id.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_pvent_id As Long, ByVal x_cajac_id As Long, ByVal x_cajap_item As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Tesoreria.TESO_CajaChicaPagos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "PVENT_Id = " + x_pvent_id.ToString() & vbNewLine
				sql &= " AND CAJAC_Id = " + x_cajac_id.ToString() & vbNewLine
				sql &= " AND CAJAP_Item = " + x_cajap_item.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Tesoreria.TESO_CajaChicaPagos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETESO_CajaChicaPagos)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETESO_CajaChicaPagos)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_cajachicapagos.CAJAP_UsrCrea = x_usuario
				x_teso_cajachicapagos.CAJAP_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETESO_CajaChicaPagos)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_teso_cajachicapagos, x_teso_cajachicapagos.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_cajachicapagos.CAJAP_UsrCrea = x_usuario
				x_teso_cajachicapagos.CAJAP_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETESO_CajaChicaPagos)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_teso_cajachicapagos, x_teso_cajachicapagos.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_cajachicapagos.CAJAP_UsrCrea = x_usuario
				x_teso_cajachicapagos.CAJAP_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETESO_CajaChicaPagos)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_teso_cajachicapagos, x_teso_cajachicapagos.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_cajachicapagos.CAJAP_UsrMod = x_usuario
				x_teso_cajachicapagos.CAJAP_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_CajaChicaPagos)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PVENT_Id", New ACWhere(x_TESO_CajaChicaPagos.PVENT_Id, ACWhere.TipoWhere.Igual))
				_where.Add("CAJAC_Id", New ACWhere(x_TESO_CajaChicaPagos.CAJAC_Id, ACWhere.TipoWhere.Igual))
				_where.Add("CAJAP_Item", New ACWhere(x_TESO_CajaChicaPagos.CAJAP_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_teso_cajachicapagos, _where, x_teso_cajachicapagos.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_cajachicapagos.CAJAP_UsrMod = x_usuario
				x_teso_cajachicapagos.CAJAP_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_CajaChicaPagos)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PVENT_Id", New ACWhere(x_TESO_CajaChicaPagos.PVENT_Id, ACWhere.TipoWhere.Igual))
				_where.Add("CAJAC_Id", New ACWhere(x_TESO_CajaChicaPagos.CAJAC_Id, ACWhere.TipoWhere.Igual))
				_where.Add("CAJAP_Item", New ACWhere(x_TESO_CajaChicaPagos.CAJAP_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_teso_cajachicapagos, _where, x_teso_cajachicapagos.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_cajachicapagos.CAJAP_UsrMod = x_usuario
				x_teso_cajachicapagos.CAJAP_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_CajaChicaPagos)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_teso_cajachicapagos, x_where, x_teso_cajachicapagos.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_cajachicapagos.CAJAP_UsrMod = x_usuario
				x_teso_cajachicapagos.CAJAP_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_CajaChicaPagos)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PVENT_Id", New ACWhere(x_TESO_CajaChicaPagos.PVENT_Id, ACWhere.TipoWhere.Igual))
				_where.Add("CAJAC_Id", New ACWhere(x_TESO_CajaChicaPagos.CAJAC_Id, ACWhere.TipoWhere.Igual))
				_where.Add("CAJAP_Item", New ACWhere(x_TESO_CajaChicaPagos.CAJAP_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_teso_cajachicapagos, _where, x_teso_cajachicapagos.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_cajachicapagos.CAJAP_UsrMod = x_usuario
				x_teso_cajachicapagos.CAJAP_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_CajaChicaPagos)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_teso_cajachicapagos, x_where, x_teso_cajachicapagos.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_cajachicapagos.CAJAP_UsrMod = x_usuario
				x_teso_cajachicapagos.CAJAP_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_CajaChicaPagos)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_teso_cajachicapagos, x_where, x_teso_cajachicapagos.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_teso_cajachicapagos As ETESO_CajaChicaPagos) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Tesoreria.TESO_CajaChicaPagos" & vbNewLine
				sql &= " WHERE "
				sql &= "    PVENT_Id = " & IIf(x_teso_cajachicapagos.PVENT_Id = 0, "Null", x_teso_cajachicapagos.PVENT_Id.ToString()) & vbNewLine
				sql &= "And CAJAC_Id = " & IIf(x_teso_cajachicapagos.CAJAC_Id = 0, "Null", x_teso_cajachicapagos.CAJAC_Id.ToString()) & vbNewLine
				sql &= "And CAJAP_Item = " & IIf(x_teso_cajachicapagos.CAJAP_Item = 0, "Null", x_teso_cajachicapagos.CAJAP_Item.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Tesoreria.TESO_CajaChicaPagos" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETESO_CajaChicaPagos)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Tesoreria.TESO_CajaChicaPagos ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Tesoreria.TESO_CajaChicaPagos ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETESO_CajaChicaPagos)(m_formatofecha) 
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

