Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DCTRL_InventarioRotativoDetalle

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "CTRL_InventarioRotativoDetalle"
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
	
	Public Function CTRL_INROTSS_Todos(ByRef x_listCTRL_InventarioRotativoDetalle As List(Of ECTRL_InventarioRotativoDetalle)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ECTRL_InventarioRotativoDetalle())
					While reader.Read()
						Dim x_ectrl_inventariorotativodetalle As New ECTRL_InventarioRotativoDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_ectrl_inventariorotativodetalle)
						x_ectrl_inventariorotativodetalle.Instanciar(ACEInstancia.Consulta)
						x_listCTRL_InventarioRotativoDetalle.Add(x_ectrl_inventariorotativodetalle)
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

	Public Function CTRL_INROTSS_Todos(ByRef x_listCTRL_InventarioRotativoDetalle As List(Of ECTRL_InventarioRotativoDetalle), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ECTRL_InventarioRotativoDetalle())
					While reader.Read()
						Dim x_ectrl_inventariorotativodetalle As New ECTRL_InventarioRotativoDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_ectrl_inventariorotativodetalle)
						x_ectrl_inventariorotativodetalle.Instanciar(ACEInstancia.Consulta)
						x_listCTRL_InventarioRotativoDetalle.Add(x_ectrl_inventariorotativodetalle)
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

	Public Function CTRL_INROTSS_Todos(ByRef x_listCTRL_InventarioRotativoDetalle As List(Of ECTRL_InventarioRotativoDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ECTRL_InventarioRotativoDetalle())
					While reader.Read()
						Dim x_ectrl_inventariorotativodetalle As New ECTRL_InventarioRotativoDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_ectrl_inventariorotativodetalle)
						x_ectrl_inventariorotativodetalle.Instanciar(ACEInstancia.Consulta)
						x_listCTRL_InventarioRotativoDetalle.Add(x_ectrl_inventariorotativodetalle)
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

	Public Function CTRL_INROTSS_Todos(ByRef x_listCTRL_InventarioRotativoDetalle As List(Of ECTRL_InventarioRotativoDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ECTRL_InventarioRotativoDetalle())
					While reader.Read()
						Dim x_ectrl_inventariorotativodetalle As New ECTRL_InventarioRotativoDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_ectrl_inventariorotativodetalle)
						x_ectrl_inventariorotativodetalle.Instanciar(ACEInstancia.Consulta)
						x_listCTRL_InventarioRotativoDetalle.Add(x_ectrl_inventariorotativodetalle)
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

	Public Function CTRL_INROTSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSS_UnReg(ByRef x_ectrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_inrot_codigo As String, ByVal x_inrod_item As Integer) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_inrot_codigo, x_inrod_item), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_ectrl_inventariorotativodetalle)
					x_ectrl_inventariorotativodetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSS_UnReg(ByRef x_ectrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_ectrl_inventariorotativodetalle)
					x_ectrl_inventariorotativodetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSS_UnReg(ByRef x_ectrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_ectrl_inventariorotativodetalle)
					x_ectrl_inventariorotativodetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSI_UnReg(ByRef x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_ctrl_inventariorotativodetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSI_UnReg(ByRef x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_ctrl_inventariorotativodetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSI_UnReg(ByRef x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_ctrl_inventariorotativodetalle, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSU_UnReg(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_ctrl_inventariorotativodetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSU_UnReg(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_ctrl_inventariorotativodetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSU_UnReg(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_ctrl_inventariorotativodetalle, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSU_UnReg(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_ctrl_inventariorotativodetalle, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSU_UnReg(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_ctrl_inventariorotativodetalle, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSU_UnReg(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_ctrl_inventariorotativodetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSD_UnReg(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_ctrl_inventariorotativodetalle), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CTRL_INROTSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Logistica.CTRL_InventarioRotativoDetalle" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.CTRL_InventarioRotativoDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ECTRL_InventarioRotativoDetalle)(m_formatofecha)
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
				sql &= " FROM Logistica.CTRL_InventarioRotativoDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ECTRL_InventarioRotativoDetalle)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ECTRL_InventarioRotativoDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ECTRL_InventarioRotativoDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_inrot_codigo As String, ByVal x_inrod_item As Integer) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.CTRL_InventarioRotativoDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "INROT_Codigo = " + IIf(IsNothing(x_inrot_codigo), "Null", "'" & x_inrot_codigo & "'") & vbNewLine
				sql &= " AND INROD_Item = " + x_inrod_item.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.CTRL_InventarioRotativoDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ECTRL_InventarioRotativoDetalle)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ECTRL_InventarioRotativoDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_ctrl_inventariorotativodetalle.INROD_UsrCrea = x_usuario
				x_ctrl_inventariorotativodetalle.INROD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ECTRL_InventarioRotativoDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_ctrl_inventariorotativodetalle, x_ctrl_inventariorotativodetalle.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_ctrl_inventariorotativodetalle.INROD_UsrCrea = x_usuario
				x_ctrl_inventariorotativodetalle.INROD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ECTRL_InventarioRotativoDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_ctrl_inventariorotativodetalle, x_ctrl_inventariorotativodetalle.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_ctrl_inventariorotativodetalle.INROD_UsrCrea = x_usuario
				x_ctrl_inventariorotativodetalle.INROD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ECTRL_InventarioRotativoDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_ctrl_inventariorotativodetalle, x_ctrl_inventariorotativodetalle.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_ctrl_inventariorotativodetalle.INROD_UsrMod = x_usuario
				x_ctrl_inventariorotativodetalle.INROD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECTRL_InventarioRotativoDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("INROT_Codigo", New ACWhere(x_CTRL_InventarioRotativoDetalle.INROT_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("INROD_Item", New ACWhere(x_CTRL_InventarioRotativoDetalle.INROD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_ctrl_inventariorotativodetalle, _where, x_ctrl_inventariorotativodetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_ctrl_inventariorotativodetalle.INROD_UsrMod = x_usuario
				x_ctrl_inventariorotativodetalle.INROD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECTRL_InventarioRotativoDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("INROT_Codigo", New ACWhere(x_CTRL_InventarioRotativoDetalle.INROT_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("INROD_Item", New ACWhere(x_CTRL_InventarioRotativoDetalle.INROD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_ctrl_inventariorotativodetalle, _where, x_ctrl_inventariorotativodetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_ctrl_inventariorotativodetalle.INROD_UsrMod = x_usuario
				x_ctrl_inventariorotativodetalle.INROD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECTRL_InventarioRotativoDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_ctrl_inventariorotativodetalle, x_where, x_ctrl_inventariorotativodetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_ctrl_inventariorotativodetalle.INROD_UsrMod = x_usuario
				x_ctrl_inventariorotativodetalle.INROD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECTRL_InventarioRotativoDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("INROT_Codigo", New ACWhere(x_CTRL_InventarioRotativoDetalle.INROT_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("INROD_Item", New ACWhere(x_CTRL_InventarioRotativoDetalle.INROD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_ctrl_inventariorotativodetalle, _where, x_ctrl_inventariorotativodetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_ctrl_inventariorotativodetalle.INROD_UsrMod = x_usuario
				x_ctrl_inventariorotativodetalle.INROD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECTRL_InventarioRotativoDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_ctrl_inventariorotativodetalle, x_where, x_ctrl_inventariorotativodetalle.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_ctrl_inventariorotativodetalle.INROD_UsrMod = x_usuario
				x_ctrl_inventariorotativodetalle.INROD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECTRL_InventarioRotativoDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_ctrl_inventariorotativodetalle, x_where, x_ctrl_inventariorotativodetalle.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_ctrl_inventariorotativodetalle As ECTRL_InventarioRotativoDetalle) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.CTRL_InventarioRotativoDetalle" & vbNewLine
				sql &= " WHERE "
				sql &= "    INROT_Codigo = " & IIf(IsNothing(x_ctrl_inventariorotativodetalle.INROT_Codigo), "Null", "'" & x_ctrl_inventariorotativodetalle.INROT_Codigo & "'") & vbNewLine
				sql &= "And INROD_Item = " & IIf(x_ctrl_inventariorotativodetalle.INROD_Item = 0, "Null", x_ctrl_inventariorotativodetalle.INROD_Item.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.CTRL_InventarioRotativoDetalle" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ECTRL_InventarioRotativoDetalle)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.CTRL_InventarioRotativoDetalle ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.CTRL_InventarioRotativoDetalle ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ECTRL_InventarioRotativoDetalle)(m_formatofecha) 
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

