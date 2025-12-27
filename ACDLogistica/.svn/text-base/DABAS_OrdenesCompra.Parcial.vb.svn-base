Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DABAS_OrdenesCompra

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "ABAS_OrdenesCompra"
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
	
	Public Function ABAS_ORDCOSS_Todos(ByRef x_listABAS_OrdenesCompra As List(Of EABAS_OrdenesCompra)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_OrdenesCompra())
					While reader.Read()
						Dim x_eabas_ordenescompra As New EABAS_OrdenesCompra()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_ordenescompra)
						x_eabas_ordenescompra.Instanciar(ACEInstancia.Consulta)
						x_listABAS_OrdenesCompra.Add(x_eabas_ordenescompra)
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

	Public Function ABAS_ORDCOSS_Todos(ByRef x_listABAS_OrdenesCompra As List(Of EABAS_OrdenesCompra), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_OrdenesCompra())
					While reader.Read()
						Dim x_eabas_ordenescompra As New EABAS_OrdenesCompra()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_ordenescompra)
						x_eabas_ordenescompra.Instanciar(ACEInstancia.Consulta)
						x_listABAS_OrdenesCompra.Add(x_eabas_ordenescompra)
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

	Public Function ABAS_ORDCOSS_Todos(ByRef x_listABAS_OrdenesCompra As List(Of EABAS_OrdenesCompra), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_OrdenesCompra())
					While reader.Read()
						Dim x_eabas_ordenescompra As New EABAS_OrdenesCompra()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_ordenescompra)
						x_eabas_ordenescompra.Instanciar(ACEInstancia.Consulta)
						x_listABAS_OrdenesCompra.Add(x_eabas_ordenescompra)
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

	Public Function ABAS_ORDCOSS_Todos(ByRef x_listABAS_OrdenesCompra As List(Of EABAS_OrdenesCompra), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_OrdenesCompra())
					While reader.Read()
						Dim x_eabas_ordenescompra As New EABAS_OrdenesCompra()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_ordenescompra)
						x_eabas_ordenescompra.Instanciar(ACEInstancia.Consulta)
						x_listABAS_OrdenesCompra.Add(x_eabas_ordenescompra)
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

	Public Function ABAS_ORDCOSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSS_UnReg(ByRef x_eabas_ordenescompra As EABAS_OrdenesCompra, ByVal x_ordco_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_ordco_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_ordenescompra)
					x_eabas_ordenescompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSS_UnReg(ByRef x_eabas_ordenescompra As EABAS_OrdenesCompra, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_ordenescompra)
					x_eabas_ordenescompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSS_UnReg(ByRef x_eabas_ordenescompra As EABAS_OrdenesCompra, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_ordenescompra)
					x_eabas_ordenescompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSI_UnReg(ByRef x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_abas_ordenescompra, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSI_UnReg(ByRef x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_abas_ordenescompra, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSI_UnReg(ByRef x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_abas_ordenescompra, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSU_UnReg(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ordenescompra, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSU_UnReg(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ordenescompra, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSU_UnReg(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ordenescompra, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSU_UnReg(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ordenescompra, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSU_UnReg(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ordenescompra, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSU_UnReg(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_ordenescompra, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSD_UnReg(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_abas_ordenescompra), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_ORDCOSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Logistica.ABAS_OrdenesCompra" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_OrdenesCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_OrdenesCompra)(m_formatofecha)
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
				sql &= " FROM Logistica.ABAS_OrdenesCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_OrdenesCompra)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_OrdenesCompra)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_OrdenesCompra)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_ordco_codigo As String) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.ABAS_OrdenesCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ORDCO_Codigo = " + IIf(IsNothing(x_ordco_codigo), "Null", "'" & x_ordco_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_OrdenesCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_OrdenesCompra)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_OrdenesCompra)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ordenescompra.ORDCO_UsrCrea = x_usuario
				x_abas_ordenescompra.ORDCO_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_OrdenesCompra)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_abas_ordenescompra, x_abas_ordenescompra.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ordenescompra.ORDCO_UsrCrea = x_usuario
				x_abas_ordenescompra.ORDCO_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_OrdenesCompra)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_abas_ordenescompra, x_abas_ordenescompra.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ordenescompra.ORDCO_UsrCrea = x_usuario
				x_abas_ordenescompra.ORDCO_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_OrdenesCompra)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_abas_ordenescompra, x_abas_ordenescompra.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ordenescompra.ORDCO_UsrMod = x_usuario
				x_abas_ordenescompra.ORDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_OrdenesCompra)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ORDCO_Codigo", New ACWhere(x_ABAS_OrdenesCompra.ORDCO_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_abas_ordenescompra, _where, x_abas_ordenescompra.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ordenescompra.ORDCO_UsrMod = x_usuario
				x_abas_ordenescompra.ORDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_OrdenesCompra)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ORDCO_Codigo", New ACWhere(x_ABAS_OrdenesCompra.ORDCO_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_abas_ordenescompra, _where, x_abas_ordenescompra.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ordenescompra.ORDCO_UsrMod = x_usuario
				x_abas_ordenescompra.ORDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_OrdenesCompra)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_abas_ordenescompra, x_where, x_abas_ordenescompra.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ordenescompra.ORDCO_UsrMod = x_usuario
				x_abas_ordenescompra.ORDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_OrdenesCompra)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ORDCO_Codigo", New ACWhere(x_ABAS_OrdenesCompra.ORDCO_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_abas_ordenescompra, _where, x_abas_ordenescompra.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ordenescompra.ORDCO_UsrMod = x_usuario
				x_abas_ordenescompra.ORDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_OrdenesCompra)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_abas_ordenescompra, x_where, x_abas_ordenescompra.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_ordenescompra.ORDCO_UsrMod = x_usuario
				x_abas_ordenescompra.ORDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_OrdenesCompra)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_abas_ordenescompra, x_where, x_abas_ordenescompra.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_abas_ordenescompra As EABAS_OrdenesCompra) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_OrdenesCompra" & vbNewLine
				sql &= " WHERE "
				sql &= "    ORDCO_Codigo = " & IIf(IsNothing(x_abas_ordenescompra.ORDCO_Codigo), "Null", "'" & x_abas_ordenescompra.ORDCO_Codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_OrdenesCompra" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_OrdenesCompra)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_OrdenesCompra ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_OrdenesCompra ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_OrdenesCompra)(m_formatofecha) 
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

