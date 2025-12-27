Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DVENT_ListaPrecios

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "VENT_ListaPrecios"
		End Get
	End Property
	Public ReadOnly Property Esquema() As String
		Get
			Return "Ventas"
		End Get
	End Property

#End Region

#Region " Constructores "
	
	Public Sub New()
		m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
	End Sub

#End Region

#Region " Procedimientos Almacenados "
	
	Public Function VENT_LPRECSS_Todos(ByRef listEVENT_ListaPrecios As List(Of EVENT_ListaPrecios)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_ListaPrecios())
					While reader.Read()
						Dim e_vent_listaprecios As New EVENT_ListaPrecios()
						_utilitarios.ACCargarEsquemas(reader, e_vent_listaprecios)
						e_vent_listaprecios.Instanciar(ACEInstancia.Consulta)
						listEVENT_ListaPrecios.Add(e_vent_listaprecios)
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
	Public Function VENT_LPRECSS_Todos(ByRef listEVENT_ListaPrecios As List(Of EVENT_ListaPrecios), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_ListaPrecios())
					While reader.Read()
						Dim e_vent_listaprecios As New EVENT_ListaPrecios()
						_utilitarios.ACCargarEsquemas(reader, e_vent_listaprecios)
						e_vent_listaprecios.Instanciar(ACEInstancia.Consulta)
						listEVENT_ListaPrecios.Add(e_vent_listaprecios)
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
	Public Function VENT_LPRECSS_Todos(ByRef listEVENT_ListaPrecios As List(Of EVENT_ListaPrecios), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_ListaPrecios())
					While reader.Read()
						Dim e_vent_listaprecios As New EVENT_ListaPrecios()
						_utilitarios.ACCargarEsquemas(reader, e_vent_listaprecios)
						e_vent_listaprecios.Instanciar(ACEInstancia.Consulta)
						listEVENT_ListaPrecios.Add(e_vent_listaprecios)
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
	Public Function VENT_LPRECSS_Todos(ByRef listEVENT_ListaPrecios As List(Of EVENT_ListaPrecios), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_ListaPrecios())
					While reader.Read()
						Dim e_vent_listaprecios As New EVENT_ListaPrecios()
						_utilitarios.ACCargarEsquemas(reader, e_vent_listaprecios)
						e_vent_listaprecios.Instanciar(ACEInstancia.Consulta)
						listEVENT_ListaPrecios.Add(e_vent_listaprecios)
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
	Public Function VENT_LPRECSS_Todos(ByRef listEVENT_ListaPrecios As List(Of EVENT_ListaPrecios), ByVal x_zonas_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_zonas_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_ListaPrecios())
					While reader.Read()
						Dim e_vent_listaprecios As New EVENT_ListaPrecios()
						_utilitarios.ACCargarEsquemas(reader, e_vent_listaprecios)
						e_vent_listaprecios.Instanciar(ACEInstancia.Consulta)
						listEVENT_ListaPrecios.Add(e_vent_listaprecios)
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
	Public Function VENT_LPRECSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSS_UnReg(ByRef x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_zonas_codigo As String, ByVal x_lprec_id As Long) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_zonas_codigo, x_lprec_id), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_vent_listaprecios)
					x_vent_listaprecios.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSS_UnReg(ByRef x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_vent_listaprecios)
					x_vent_listaprecios.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSS_UnReg(ByRef x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_vent_listaprecios)
					x_vent_listaprecios.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSI_UnReg(ByRef x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_vent_listaprecios, x_usuario), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSI_UnReg(ByRef x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_vent_listaprecios, x_usuario, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSI_UnReg(ByRef x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_vent_listaprecios, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSU_UnReg(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_listaprecios, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSU_UnReg(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_listaprecios, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSU_UnReg(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_listaprecios, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSU_UnReg(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_listaprecios, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSU_UnReg(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_listaprecios, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSU_UnReg(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_listaprecios, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSD_UnReg(ByVal x_vent_listaprecios As EVENT_ListaPrecios) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_vent_listaprecios), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_LPRECSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Ventas.VENT_ListaPrecios" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Ventas.VENT_ListaPrecios" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EVENT_ListaPrecios)(m_formatofecha)
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
				sql &= " FROM Ventas.VENT_ListaPrecios" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EVENT_ListaPrecios)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EVENT_ListaPrecios)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EVENT_ListaPrecios)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_zonas_codigo As String) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Ventas.VENT_ListaPrecios" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ZONAS_Codigo = " + IIf(IsNothing(x_zonas_codigo), "Null", "'" & x_zonas_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_zonas_codigo As String, ByVal x_lprec_id As Long) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Ventas.VENT_ListaPrecios" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ZONAS_Codigo = " + IIf(IsNothing(x_zonas_codigo), "Null", "'" & x_zonas_codigo & "'") & vbNewLine
				sql &= " AND LPREC_Id = " + x_lprec_id.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_listaprecios.LPREC_UsrCrea = x_usuario
				x_vent_listaprecios.LPREC_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EVENT_ListaPrecios)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_vent_listaprecios, x_vent_listaprecios.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_listaprecios.LPREC_UsrCrea = x_usuario
				x_vent_listaprecios.LPREC_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EVENT_ListaPrecios)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_vent_listaprecios, x_vent_listaprecios.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_listaprecios.LPREC_UsrCrea = x_usuario
				x_vent_listaprecios.LPREC_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EVENT_ListaPrecios)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_vent_listaprecios, x_vent_listaprecios.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_listaprecios.LPREC_UsrMod = x_usuario
				x_vent_listaprecios.LPREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_ListaPrecios)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ZONAS_Codigo", New ACWhere(x_VENT_ListaPrecios.ZONAS_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("LPREC_Id", New ACWhere(x_VENT_ListaPrecios.LPREC_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_vent_listaprecios, _where, x_vent_listaprecios.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_listaprecios.LPREC_UsrMod = x_usuario
				x_vent_listaprecios.LPREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_ListaPrecios)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ZONAS_Codigo", New ACWhere(x_VENT_ListaPrecios.ZONAS_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("LPREC_Id", New ACWhere(x_VENT_ListaPrecios.LPREC_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_vent_listaprecios, _where, x_vent_listaprecios.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_listaprecios.LPREC_UsrMod = x_usuario
				x_vent_listaprecios.LPREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_ListaPrecios)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_vent_listaprecios, x_where, x_vent_listaprecios.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_listaprecios.LPREC_UsrMod = x_usuario
				x_vent_listaprecios.LPREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_ListaPrecios)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ZONAS_Codigo", New ACWhere(x_VENT_ListaPrecios.ZONAS_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("LPREC_Id", New ACWhere(x_VENT_ListaPrecios.LPREC_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_vent_listaprecios, _where, x_vent_listaprecios.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_listaprecios.LPREC_UsrMod = x_usuario
				x_vent_listaprecios.LPREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_ListaPrecios)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_vent_listaprecios, x_where, x_vent_listaprecios.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_vent_listaprecios As EVENT_ListaPrecios, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_listaprecios.LPREC_UsrMod = x_usuario
				x_vent_listaprecios.LPREC_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_ListaPrecios)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_vent_listaprecios, x_where, x_vent_listaprecios.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_vent_listaprecios As EVENT_ListaPrecios) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Ventas.VENT_ListaPrecios" & vbNewLine
				sql &= " WHERE "
				sql &= "    ZONAS_Codigo = " & IIf(IsNothing(x_vent_listaprecios.ZONAS_Codigo), "Null", "'" & x_vent_listaprecios.ZONAS_Codigo & "'") & vbNewLine
				sql &= "And LPREC_Id = " & IIf(x_vent_listaprecios.LPREC_Id = 0, "Null", x_vent_listaprecios.LPREC_Id.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Ventas.VENT_ListaPrecios" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EVENT_ListaPrecios)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Ventas.VENT_ListaPrecios ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Ventas.VENT_ListaPrecios ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EVENT_ListaPrecios)(m_formatofecha) 
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

