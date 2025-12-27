Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DABAS_IngresosCompra

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "ABAS_IngresosCompra"
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
	
	Public Function ABAS_INGCOSS_Todos(ByRef x_listABAS_IngresosCompra As List(Of EABAS_IngresosCompra)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_IngresosCompra())
					While reader.Read()
						Dim x_eabas_ingresoscompra As New EABAS_IngresosCompra()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_ingresoscompra)
						x_eabas_ingresoscompra.Instanciar(ACEInstancia.Consulta)
						x_listABAS_IngresosCompra.Add(x_eabas_ingresoscompra)
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

	Public Function ABAS_INGCOSS_Todos(ByRef x_listABAS_IngresosCompra As List(Of EABAS_IngresosCompra), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_IngresosCompra())
					While reader.Read()
						Dim x_eabas_ingresoscompra As New EABAS_IngresosCompra()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_ingresoscompra)
						x_eabas_ingresoscompra.Instanciar(ACEInstancia.Consulta)
						x_listABAS_IngresosCompra.Add(x_eabas_ingresoscompra)
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

	Public Function ABAS_INGCOSS_Todos(ByRef x_listABAS_IngresosCompra As List(Of EABAS_IngresosCompra), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_IngresosCompra())
					While reader.Read()
						Dim x_eabas_ingresoscompra As New EABAS_IngresosCompra()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_ingresoscompra)
						x_eabas_ingresoscompra.Instanciar(ACEInstancia.Consulta)
						x_listABAS_IngresosCompra.Add(x_eabas_ingresoscompra)
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

	Public Function ABAS_INGCOSS_Todos(ByRef x_listABAS_IngresosCompra As List(Of EABAS_IngresosCompra), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_IngresosCompra())
					While reader.Read()
						Dim x_eabas_ingresoscompra As New EABAS_IngresosCompra()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_ingresoscompra)
						x_eabas_ingresoscompra.Instanciar(ACEInstancia.Consulta)
						x_listABAS_IngresosCompra.Add(x_eabas_ingresoscompra)
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

	Public Function ABAS_INGCOSS_Todos(ByRef x_eabas_ingresoscompra As EABAS_IngresosCompra, ByVal x_almac_id As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_almac_id), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_ingresoscompra)
					x_eabas_ingresoscompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSS_UnReg(ByRef x_eabas_ingresoscompra As EABAS_IngresosCompra, ByVal x_almac_id As Short, ByVal x_ingco_id As Long) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_almac_id, x_ingco_id), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_ingresoscompra)
					x_eabas_ingresoscompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSS_UnReg(ByRef x_eabas_ingresoscompra As EABAS_IngresosCompra, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_ingresoscompra)
					x_eabas_ingresoscompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSS_UnReg(ByRef x_eabas_ingresoscompra As EABAS_IngresosCompra, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_ingresoscompra)
					x_eabas_ingresoscompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSI_UnReg(ByRef x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_abas_ingresoscompra, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSI_UnReg(ByRef x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_abas_ingresoscompra, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSI_UnReg(ByRef x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_abas_ingresoscompra, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSU_UnReg(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ingresoscompra, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSU_UnReg(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ingresoscompra, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSU_UnReg(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ingresoscompra, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSU_UnReg(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ingresoscompra, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSU_UnReg(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ingresoscompra, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSU_UnReg(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ingresoscompra, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSD_UnReg(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_abas_ingresoscompra), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_INGCOSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Logistica.ABAS_IngresosCompra" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_IngresosCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_IngresosCompra)(m_formatofecha)
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
				sql &= " FROM Logistica.ABAS_IngresosCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_IngresosCompra)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_IngresosCompra)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_IngresosCompra)(m_formatofecha)
 
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
				sql &= " FROM Logistica.ABAS_IngresosCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ALMAC_Id = " + x_almac_id.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_almac_id As Short, ByVal x_ingco_id As Long) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.ABAS_IngresosCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ALMAC_Id = " + x_almac_id.ToString() & vbNewLine
				sql &= " AND INGCO_Id = " + x_ingco_id.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_IngresosCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_IngresosCompra)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_IngresosCompra)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ingresoscompra.INGCO_UsrCrea = x_usuario
				x_abas_ingresoscompra.INGCO_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_IngresosCompra)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_abas_ingresoscompra, x_abas_ingresoscompra.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ingresoscompra.INGCO_UsrCrea = x_usuario
				x_abas_ingresoscompra.INGCO_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_IngresosCompra)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_abas_ingresoscompra, x_abas_ingresoscompra.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ingresoscompra.INGCO_UsrCrea = x_usuario
				x_abas_ingresoscompra.INGCO_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_IngresosCompra)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_abas_ingresoscompra, x_abas_ingresoscompra.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ingresoscompra.INGCO_UsrMod = x_usuario
				x_abas_ingresoscompra.INGCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_IngresosCompra)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ALMAC_Id", New ACWhere(x_ABAS_IngresosCompra.ALMAC_Id, ACWhere.TipoWhere.Igual))
				_where.Add("INGCO_Id", New ACWhere(x_ABAS_IngresosCompra.INGCO_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_abas_ingresoscompra, _where, x_abas_ingresoscompra.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ingresoscompra.INGCO_UsrMod = x_usuario
				x_abas_ingresoscompra.INGCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_IngresosCompra)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ALMAC_Id", New ACWhere(x_ABAS_IngresosCompra.ALMAC_Id, ACWhere.TipoWhere.Igual))
				_where.Add("INGCO_Id", New ACWhere(x_ABAS_IngresosCompra.INGCO_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_abas_ingresoscompra, _where, x_abas_ingresoscompra.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ingresoscompra.INGCO_UsrMod = x_usuario
				x_abas_ingresoscompra.INGCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_IngresosCompra)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_abas_ingresoscompra, x_where, x_abas_ingresoscompra.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ingresoscompra.INGCO_UsrMod = x_usuario
				x_abas_ingresoscompra.INGCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_IngresosCompra)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ALMAC_Id", New ACWhere(x_ABAS_IngresosCompra.ALMAC_Id, ACWhere.TipoWhere.Igual))
				_where.Add("INGCO_Id", New ACWhere(x_ABAS_IngresosCompra.INGCO_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_abas_ingresoscompra, _where, x_abas_ingresoscompra.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ingresoscompra.INGCO_UsrMod = x_usuario
				x_abas_ingresoscompra.INGCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_IngresosCompra)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_abas_ingresoscompra, x_where, x_abas_ingresoscompra.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ingresoscompra.INGCO_UsrMod = x_usuario
				x_abas_ingresoscompra.INGCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_IngresosCompra)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_abas_ingresoscompra, x_where, x_abas_ingresoscompra.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_abas_ingresoscompra As EABAS_IngresosCompra) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_IngresosCompra" & vbNewLine
				sql &= " WHERE "
				sql &= "    ALMAC_Id = " & IIf(x_abas_ingresoscompra.ALMAC_Id = 0, "Null", x_abas_ingresoscompra.ALMAC_Id.ToString()) & vbNewLine
				sql &= "And INGCO_Id = " & IIf(x_abas_ingresoscompra.INGCO_Id = 0, "Null", x_abas_ingresoscompra.INGCO_Id.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_IngresosCompra" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_IngresosCompra)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_IngresosCompra ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_IngresosCompra ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_IngresosCompra)(m_formatofecha) 
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

