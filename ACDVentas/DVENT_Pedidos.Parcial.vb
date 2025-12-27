Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DVENT_Pedidos

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "VENT_Pedidos"
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
	
	Public Function VENT_PEDIDSS_Todos(ByRef x_listVENT_Pedidos As List(Of EVENT_Pedidos)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_Pedidos())
					While reader.Read()
						Dim x_event_pedidos As New EVENT_Pedidos()
						_utilitarios.ACCargarEsquemas(reader, x_event_pedidos)
						x_event_pedidos.Instanciar(ACEInstancia.Consulta)
						x_listVENT_Pedidos.Add(x_event_pedidos)
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

	Public Function VENT_PEDIDSS_Todos(ByRef x_listVENT_Pedidos As List(Of EVENT_Pedidos), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_Pedidos())
					While reader.Read()
						Dim x_event_pedidos As New EVENT_Pedidos()
						_utilitarios.ACCargarEsquemas(reader, x_event_pedidos)
						x_event_pedidos.Instanciar(ACEInstancia.Consulta)
						x_listVENT_Pedidos.Add(x_event_pedidos)
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

	Public Function VENT_PEDIDSS_Todos(ByRef x_listVENT_Pedidos As List(Of EVENT_Pedidos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_Pedidos())
					While reader.Read()
						Dim x_event_pedidos As New EVENT_Pedidos()
						_utilitarios.ACCargarEsquemas(reader, x_event_pedidos)
						x_event_pedidos.Instanciar(ACEInstancia.Consulta)
						x_listVENT_Pedidos.Add(x_event_pedidos)
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

	Public Function VENT_PEDIDSS_Todos(ByRef x_listVENT_Pedidos As List(Of EVENT_Pedidos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_Pedidos())
					While reader.Read()
						Dim x_event_pedidos As New EVENT_Pedidos()
						_utilitarios.ACCargarEsquemas(reader, x_event_pedidos)
						x_event_pedidos.Instanciar(ACEInstancia.Consulta)
						x_listVENT_Pedidos.Add(x_event_pedidos)
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

	Public Function VENT_PEDIDSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSS_UnReg(ByRef x_event_pedidos As EVENT_Pedidos, ByVal x_pedid_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_pedid_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_event_pedidos)
					x_event_pedidos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSS_UnReg(ByRef x_event_pedidos As EVENT_Pedidos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_event_pedidos)
					x_event_pedidos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSS_UnReg(ByRef x_event_pedidos As EVENT_Pedidos, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_event_pedidos)
					x_event_pedidos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSI_UnReg(ByRef x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_vent_pedidos, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSI_UnReg(ByRef x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_vent_pedidos, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSI_UnReg(ByRef x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_vent_pedidos, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSU_UnReg(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_pedidos, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSU_UnReg(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_pedidos, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSU_UnReg(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_pedidos, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSU_UnReg(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_pedidos, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSU_UnReg(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_pedidos, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSU_UnReg(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_pedidos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSD_UnReg(ByVal x_vent_pedidos As EVENT_Pedidos) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_vent_pedidos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function VENT_PEDIDSD_UnReg(ByVal x_where As Hashtable) As Integer
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
			Return CType(m_data.Tables(0).Rows(0)("Id"), Decimal)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    
    Public Function getPV(ByVal x_campo As String) As String
		Try
			DAEnterprise.AsignarProcedure(getSelectTPV(x_campo), CommandType.Text)
			Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
			Return CType(m_data.Tables(0).Rows(0)("PVENT_Descripcion"), String)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    
    Public Function getOC(ByVal x_campo As String) As String
		Try
			DAEnterprise.AsignarProcedure(getSelectOC(x_campo), CommandType.Text)
			Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
            If m_data.Tables(0).Rows.Count>=1
                Return CType(m_data.Tables(0).Rows(0)("PEDID_Codigo"), String)
            Else 
                Return Nothing
            End If

			
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    
    Public Function getTPD(ByVal x_campo As String) As String
		Try
			DAEnterprise.AsignarProcedure(getSelectTPD(x_campo), CommandType.Text)
			Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
			Return CType(m_data.Tables(0).Rows(0)("TIPOS_descCorta"), String)
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
				sql &= " FROM Ventas.VENT_Pedidos" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Ventas.VENT_Pedidos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha)
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
				sql &= " FROM Ventas.VENT_Pedidos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_pedid_codigo As String) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Ventas.VENT_Pedidos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "PEDID_Codigo = " + IIf(IsNothing(x_pedid_codigo), "Null", "'" & x_pedid_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Ventas.VENT_Pedidos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_pedidos.PEDID_UsrCrea = x_usuario
				x_vent_pedidos.PEDID_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EVENT_Pedidos)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_vent_pedidos, x_vent_pedidos.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_pedidos.PEDID_UsrCrea = x_usuario
				x_vent_pedidos.PEDID_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EVENT_Pedidos)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_vent_pedidos, x_vent_pedidos.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_pedidos.PEDID_UsrCrea = x_usuario
				x_vent_pedidos.PEDID_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EVENT_Pedidos)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_vent_pedidos, x_vent_pedidos.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_pedidos.PEDID_UsrMod = x_usuario
				x_vent_pedidos.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_Pedidos)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PEDID_Codigo", New ACWhere(x_VENT_Pedidos.PEDID_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_vent_pedidos, _where, x_vent_pedidos.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_pedidos.PEDID_UsrMod = x_usuario
				x_vent_pedidos.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_Pedidos)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PEDID_Codigo", New ACWhere(x_VENT_Pedidos.PEDID_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_vent_pedidos, _where, x_vent_pedidos.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_pedidos.PEDID_UsrMod = x_usuario
				x_vent_pedidos.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_Pedidos)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_vent_pedidos, x_where, x_vent_pedidos.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_pedidos.PEDID_UsrMod = x_usuario
				x_vent_pedidos.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_Pedidos)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PEDID_Codigo", New ACWhere(x_VENT_Pedidos.PEDID_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_vent_pedidos, _where, x_vent_pedidos.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_pedidos.PEDID_UsrMod = x_usuario
				x_vent_pedidos.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_Pedidos)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_vent_pedidos, x_where, x_vent_pedidos.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_vent_pedidos As EVENT_Pedidos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_pedidos.PEDID_UsrMod = x_usuario
				x_vent_pedidos.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_Pedidos)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_vent_pedidos, x_where, x_vent_pedidos.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_vent_pedidos As EVENT_Pedidos) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Ventas.VENT_Pedidos" & vbNewLine
				sql &= " WHERE "
				sql &= "    PEDID_Codigo = " & IIf(IsNothing(x_vent_pedidos.PEDID_Codigo), "Null", "'" & x_vent_pedidos.PEDID_Codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Ventas.VENT_Pedidos" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Ventas.VENT_Pedidos ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
    
    Private Function getSelectTPD(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format("SELECT TIPOS_descCorta from tipos where TIPOS_Codigo='{0}' ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
    
     Private Function getSelectTPV(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format("SELECT  PVENT_Descripcion from PuntoVenta where PVENT_Id='{0}' ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

     Private Function getSelectOC(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format("SELECT  PEDID_Codigo from Ventas.VENT_Pedidos where PEDID_CodRelacionado='{0}' AND PEDID_Estado<>'X' and TIPOS_CodTipoDocumento='CPDOCT' ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
    


		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Ventas.VENT_Pedidos ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha) 
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

