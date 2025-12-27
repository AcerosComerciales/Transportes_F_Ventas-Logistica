Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DDIST_GuiasRemisionDetalle

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "DIST_GuiasRemisionDetalle"
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
	
	Public Function DIST_GUIRDSS_Todos(ByRef x_listDIST_GuiasRemisionDetalle As List(Of EDIST_GuiasRemisionDetalle)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDIST_GuiasRemisionDetalle())
					While reader.Read()
						Dim x_edist_guiasremisiondetalle As New EDIST_GuiasRemisionDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_edist_guiasremisiondetalle)
						x_edist_guiasremisiondetalle.Instanciar(ACEInstancia.Consulta)
						x_listDIST_GuiasRemisionDetalle.Add(x_edist_guiasremisiondetalle)
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

	Public Function DIST_GUIRDSS_Todos(ByRef x_listDIST_GuiasRemisionDetalle As List(Of EDIST_GuiasRemisionDetalle), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDIST_GuiasRemisionDetalle())
					While reader.Read()
						Dim x_edist_guiasremisiondetalle As New EDIST_GuiasRemisionDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_edist_guiasremisiondetalle)
						x_edist_guiasremisiondetalle.Instanciar(ACEInstancia.Consulta)
						x_listDIST_GuiasRemisionDetalle.Add(x_edist_guiasremisiondetalle)
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

	Public Function DIST_GUIRDSS_Todos(ByRef x_listDIST_GuiasRemisionDetalle As List(Of EDIST_GuiasRemisionDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDIST_GuiasRemisionDetalle())
					While reader.Read()
						Dim x_edist_guiasremisiondetalle As New EDIST_GuiasRemisionDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_edist_guiasremisiondetalle)
						x_edist_guiasremisiondetalle.Instanciar(ACEInstancia.Consulta)
						x_listDIST_GuiasRemisionDetalle.Add(x_edist_guiasremisiondetalle)
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

	Public Function DIST_GUIRDSS_Todos(ByRef x_listDIST_GuiasRemisionDetalle As List(Of EDIST_GuiasRemisionDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EDIST_GuiasRemisionDetalle())
					While reader.Read()
						Dim x_edist_guiasremisiondetalle As New EDIST_GuiasRemisionDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_edist_guiasremisiondetalle)
						x_edist_guiasremisiondetalle.Instanciar(ACEInstancia.Consulta)
						x_listDIST_GuiasRemisionDetalle.Add(x_edist_guiasremisiondetalle)
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

	Public Function DIST_GUIRDSS_Todos(ByRef x_edist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_guiar_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_guiar_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_guiasremisiondetalle)
					x_edist_guiasremisiondetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSS_UnReg(ByRef x_edist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_guiar_codigo As String, ByVal x_guird_item As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_guiar_codigo, x_guird_item), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_guiasremisiondetalle)
					x_edist_guiasremisiondetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSS_UnReg(ByRef x_edist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_guiasremisiondetalle)
					x_edist_guiasremisiondetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSS_UnReg(ByRef x_edist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_guiasremisiondetalle)
					x_edist_guiasremisiondetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSI_UnReg(ByRef x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_dist_guiasremisiondetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSI_UnReg(ByRef x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_dist_guiasremisiondetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSI_UnReg(ByRef x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_dist_guiasremisiondetalle, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSU_UnReg(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremisiondetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSU_UnReg(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremisiondetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSU_UnReg(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremisiondetalle, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSU_UnReg(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremisiondetalle, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSU_UnReg(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremisiondetalle, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSU_UnReg(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_guiasremisiondetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSD_UnReg(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_dist_guiasremisiondetalle), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GUIRDSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Logistica.DIST_GuiasRemisionDetalle" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.DIST_GuiasRemisionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EDIST_GuiasRemisionDetalle)(m_formatofecha)
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
				sql &= " FROM Logistica.DIST_GuiasRemisionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EDIST_GuiasRemisionDetalle)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EDIST_GuiasRemisionDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EDIST_GuiasRemisionDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_guiar_codigo As String) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.DIST_GuiasRemisionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "GUIAR_Codigo = " + IIf(IsNothing(x_guiar_codigo), "Null", "'" & x_guiar_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_guiar_codigo As String, ByVal x_guird_item As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.DIST_GuiasRemisionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "GUIAR_Codigo = " + IIf(IsNothing(x_guiar_codigo), "Null", "'" & x_guiar_codigo & "'") & vbNewLine
				sql &= " AND GUIRD_Item = " + x_guird_item.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.DIST_GuiasRemisionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EDIST_GuiasRemisionDetalle)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EDIST_GuiasRemisionDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_guiasremisiondetalle.GUIRD_UsrCrea = x_usuario
				x_dist_guiasremisiondetalle.GUIRD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EDIST_GuiasRemisionDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_dist_guiasremisiondetalle, x_dist_guiasremisiondetalle.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_guiasremisiondetalle.GUIRD_UsrCrea = x_usuario
				x_dist_guiasremisiondetalle.GUIRD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EDIST_GuiasRemisionDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_guiasremisiondetalle, x_dist_guiasremisiondetalle.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_guiasremisiondetalle.GUIRD_UsrCrea = x_usuario
				x_dist_guiasremisiondetalle.GUIRD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EDIST_GuiasRemisionDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_guiasremisiondetalle, x_dist_guiasremisiondetalle.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_guiasremisiondetalle.GUIRD_UsrMod = x_usuario
				x_dist_guiasremisiondetalle.GUIRD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasRemisionDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("GUIAR_Codigo", New ACWhere(x_DIST_GuiasRemisionDetalle.GUIAR_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("GUIRD_Item", New ACWhere(x_DIST_GuiasRemisionDetalle.GUIRD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_dist_guiasremisiondetalle, _where, x_dist_guiasremisiondetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_guiasremisiondetalle.GUIRD_UsrMod = x_usuario
				x_dist_guiasremisiondetalle.GUIRD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasRemisionDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("GUIAR_Codigo", New ACWhere(x_DIST_GuiasRemisionDetalle.GUIAR_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("GUIRD_Item", New ACWhere(x_DIST_GuiasRemisionDetalle.GUIRD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_guiasremisiondetalle, _where, x_dist_guiasremisiondetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_guiasremisiondetalle.GUIRD_UsrMod = x_usuario
				x_dist_guiasremisiondetalle.GUIRD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasRemisionDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_guiasremisiondetalle, x_where, x_dist_guiasremisiondetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_guiasremisiondetalle.GUIRD_UsrMod = x_usuario
				x_dist_guiasremisiondetalle.GUIRD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasRemisionDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("GUIAR_Codigo", New ACWhere(x_DIST_GuiasRemisionDetalle.GUIAR_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("GUIRD_Item", New ACWhere(x_DIST_GuiasRemisionDetalle.GUIRD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_guiasremisiondetalle, _where, x_dist_guiasremisiondetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_guiasremisiondetalle.GUIRD_UsrMod = x_usuario
				x_dist_guiasremisiondetalle.GUIRD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasRemisionDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_guiasremisiondetalle, x_where, x_dist_guiasremisiondetalle.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_guiasremisiondetalle.GUIRD_UsrMod = x_usuario
				x_dist_guiasremisiondetalle.GUIRD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EDIST_GuiasRemisionDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_guiasremisiondetalle, x_where, x_dist_guiasremisiondetalle.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_dist_guiasremisiondetalle As EDIST_GuiasRemisionDetalle) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.DIST_GuiasRemisionDetalle" & vbNewLine
				sql &= " WHERE "
				sql &= "    GUIAR_Codigo = " & IIf(IsNothing(x_dist_guiasremisiondetalle.GUIAR_Codigo), "Null", "'" & x_dist_guiasremisiondetalle.GUIAR_Codigo & "'") & vbNewLine
				sql &= "And GUIRD_Item = " & IIf(x_dist_guiasremisiondetalle.GUIRD_Item = 0, "Null", x_dist_guiasremisiondetalle.GUIRD_Item.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.DIST_GuiasRemisionDetalle" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EDIST_GuiasRemisionDetalle)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.DIST_GuiasRemisionDetalle ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.DIST_GuiasRemisionDetalle ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EDIST_GuiasRemisionDetalle)(m_formatofecha) 
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

