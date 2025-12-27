Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DDIST_Ordenes

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "DIST_Ordenes"
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
	
	Public Function DIST_ORDENSS_Todos(ByRef x_listDIST_Ordenes As List(Of EDIST_Ordenes)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDIST_Ordenes())
					While reader.Read()
						Dim x_edist_ordenes As New EDIST_Ordenes()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_Ordenes.Add(x_edist_ordenes)
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

	Public Function DIST_ORDENSS_Todos(ByRef x_listDIST_Ordenes As List(Of EDIST_Ordenes), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDIST_Ordenes())
					While reader.Read()
						Dim x_edist_ordenes As New EDIST_Ordenes()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_Ordenes.Add(x_edist_ordenes)
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

	Public Function DIST_ORDENSS_Todos(ByRef x_listDIST_Ordenes As List(Of EDIST_Ordenes), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDIST_Ordenes())
					While reader.Read()
						Dim x_edist_ordenes As New EDIST_Ordenes()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_Ordenes.Add(x_edist_ordenes)
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

	Public Function DIST_ORDENSS_Todos(ByRef x_listDIST_Ordenes As List(Of EDIST_Ordenes), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDIST_Ordenes())
					While reader.Read()
						Dim x_edist_ordenes As New EDIST_Ordenes()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_Ordenes.Add(x_edist_ordenes)
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

	Public Function DIST_ORDENSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSS_UnReg(ByRef x_edist_ordenes As EDIST_Ordenes, ByVal x_orden_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_orden_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_ordenes)
					x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSS_UnReg(ByRef x_edist_ordenes As EDIST_Ordenes, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_ordenes)
					x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSS_UnReg(ByRef x_edist_ordenes As EDIST_Ordenes, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_ordenes)
					x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSI_UnReg(ByRef x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_dist_ordenes, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSI_UnReg(ByRef x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_dist_ordenes, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSI_UnReg(ByRef x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_dist_ordenes, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSU_UnReg(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSU_UnReg(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSU_UnReg(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSU_UnReg(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSU_UnReg(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSU_UnReg(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSD_UnReg(ByVal x_dist_ordenes As EDIST_Ordenes) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_dist_ordenes), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_ORDENSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Logistica.DIST_Ordenes" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.DIST_Ordenes" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EDIST_Ordenes)(m_formatofecha)
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
				sql &= " FROM Logistica.DIST_Ordenes" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EDIST_Ordenes)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EDIST_Ordenes)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EDIST_Ordenes)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_orden_codigo As String) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.DIST_Ordenes" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ORDEN_Codigo = " + IIf(IsNothing(x_orden_codigo), "Null", "'" & x_orden_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.DIST_Ordenes" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EDIST_Ordenes)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EDIST_Ordenes)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.ORDEN_UsrCrea = x_usuario
				x_dist_ordenes.ORDEN_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EDIST_Ordenes)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_dist_ordenes, x_dist_ordenes.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.ORDEN_UsrCrea = x_usuario
				x_dist_ordenes.ORDEN_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EDIST_Ordenes)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_ordenes, x_dist_ordenes.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.ORDEN_UsrCrea = x_usuario
				x_dist_ordenes.ORDEN_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EDIST_Ordenes)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_ordenes, x_dist_ordenes.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.ORDEN_UsrMod = x_usuario
				x_dist_ordenes.ORDEN_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_Ordenes)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ORDEN_Codigo", New ACWhere(x_DIST_Ordenes.ORDEN_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenes, _where, x_dist_ordenes.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.ORDEN_UsrMod = x_usuario
				x_dist_ordenes.ORDEN_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_Ordenes)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ORDEN_Codigo", New ACWhere(x_DIST_Ordenes.ORDEN_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_ordenes, _where, x_dist_ordenes.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.ORDEN_UsrMod = x_usuario
				x_dist_ordenes.ORDEN_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_Ordenes)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenes, x_where, x_dist_ordenes.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.ORDEN_UsrMod = x_usuario
				x_dist_ordenes.ORDEN_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_Ordenes)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ORDEN_Codigo", New ACWhere(x_DIST_Ordenes.ORDEN_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_ordenes, _where, x_dist_ordenes.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.ORDEN_UsrMod = x_usuario
				x_dist_ordenes.ORDEN_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_Ordenes)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_ordenes, x_where, x_dist_ordenes.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EDIST_Ordenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.ORDEN_UsrMod = x_usuario
				x_dist_ordenes.ORDEN_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_Ordenes)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenes, x_where, x_dist_ordenes.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_dist_ordenes As EDIST_Ordenes) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.DIST_Ordenes" & vbNewLine
				sql &= " WHERE "
				sql &= "    ORDEN_Codigo = " & IIf(IsNothing(x_dist_ordenes.ORDEN_Codigo), "Null", "'" & x_dist_ordenes.ORDEN_Codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.DIST_Ordenes" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EDIST_Ordenes)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.DIST_Ordenes ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.DIST_Ordenes ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EDIST_Ordenes)(m_formatofecha) 
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

