Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DEntidades

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "Entidades"
		End Get
	End Property
	Public ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property

#End Region

#Region " Constructores "
	
	Public Sub New()
		m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
	End Sub

#End Region

#Region " Procedimientos Almacenados "
	
	Public Function ENTIDSS_Todos(ByRef listEEntidades As List(Of EEntidades)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EEntidades())
					While reader.Read()
						Dim e_entidades As New EEntidades()
						_utilitarios.ACCargarEsquemas(reader, e_entidades)
						e_entidades.Instanciar(ACEInstancia.Consulta)
						listEEntidades.Add(e_entidades)
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
	Public Function ENTIDSS_Todos(ByRef listEEntidades As List(Of EEntidades), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EEntidades())
					While reader.Read()
						Dim e_entidades As New EEntidades()
						_utilitarios.ACCargarEsquemas(reader, e_entidades)
						e_entidades.Instanciar(ACEInstancia.Consulta)
						listEEntidades.Add(e_entidades)
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
	Public Function ENTIDSS_Todos(ByRef listEEntidades As List(Of EEntidades), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EEntidades())
					While reader.Read()
						Dim e_entidades As New EEntidades()
						_utilitarios.ACCargarEsquemas(reader, e_entidades)
						e_entidades.Instanciar(ACEInstancia.Consulta)
						listEEntidades.Add(e_entidades)
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
	Public Function ENTIDSS_Todos(ByRef listEEntidades As List(Of EEntidades), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EEntidades())
					While reader.Read()
						Dim e_entidades As New EEntidades()
						_utilitarios.ACCargarEsquemas(reader, e_entidades)
						e_entidades.Instanciar(ACEInstancia.Consulta)
						listEEntidades.Add(e_entidades)
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
	Public Function ENTIDSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSS_UnReg(ByRef x_entidades As EEntidades, ByVal x_entid_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_entid_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_entidades)
					x_entidades.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSS_UnReg(ByRef x_entidades As EEntidades, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_entidades)
					x_entidades.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSS_UnReg(ByRef x_entidades As EEntidades, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_entidades)
					x_entidades.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSI_UnReg(ByRef x_entidades As EEntidades, ByVal x_usuario As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSI_UnReg(ByRef x_entidades As EEntidades, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSI_UnReg(ByRef x_entidades As EEntidades, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSU_UnReg(ByVal x_entidades As EEntidades, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSU_UnReg(ByVal x_entidades As EEntidades, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSU_UnReg(ByVal x_entidades As EEntidades, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSU_UnReg(ByVal x_entidades As EEntidades, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSU_UnReg(ByVal x_entidades As EEntidades, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSU_UnReg(ByVal x_entidades As EEntidades, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSD_UnReg(ByVal x_entidades As EEntidades) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_entidades), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTIDSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM dbo.Entidades" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM dbo.Entidades" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EEntidades)(m_formatofecha)
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
				sql &= " FROM dbo.Entidades" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EEntidades)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EEntidades)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EEntidades)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_entid_codigo As String) As String
			Dim sql As String = ""
			Try
            sql = " SELECT * " & vbNewLine
            sql &= " FROM dbo.Entidades" & vbNewLine
            sql &= " WHERE " & vbNewLine
            sql &= "ENTID_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine

            'R 13/06/2017
            'sql = " SELECT * " & vbNewLine
            'sql &= " FROM dbo.VENT_DocsVenta" & vbNewLine
            'sql &= " WHERE " & vbNewLine
            'sql &= "DOCVE_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine
				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_entidades As EEntidades, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidades.ENTID_UsrCrea = x_usuario
				x_entidades.ENTID_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_entidades, x_entidades.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_entidades As EEntidades, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidades.ENTID_UsrCrea = x_usuario
				x_entidades.ENTID_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_entidades, x_entidades.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_entidades As EEntidades, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidades.ENTID_UsrCrea = x_usuario
				x_entidades.ENTID_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_entidades, x_entidades.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_entidades As EEntidades, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidades.ENTID_UsrMod = x_usuario
				x_entidades.ENTID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ENTID_Codigo", New ACWhere(x_Entidades.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_entidades, _where, x_entidades.Hash, New String() {})
            Debug.WriteLine(sql)
            Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidades As EEntidades, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidades.ENTID_UsrMod = x_usuario
				x_entidades.ENTID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ENTID_Codigo", New ACWhere(x_Entidades.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_entidades, _where, x_entidades.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidades As EEntidades, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidades.ENTID_UsrMod = x_usuario
				x_entidades.ENTID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_entidades, x_where, x_entidades.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidades As EEntidades, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidades.ENTID_UsrMod = x_usuario
				x_entidades.ENTID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ENTID_Codigo", New ACWhere(x_Entidades.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_entidades, _where, x_entidades.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidades As EEntidades, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidades.ENTID_UsrMod = x_usuario
				x_entidades.ENTID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_entidades, x_where, x_entidades.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidades As EEntidades, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidades.ENTID_UsrMod = x_usuario
				x_entidades.ENTID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_entidades, x_where, x_entidades.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_entidades As EEntidades) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM dbo.Entidades" & vbNewLine
				sql &= " WHERE "
				sql &= "    ENTID_Codigo = " & IIf(IsNothing(x_entidades.ENTID_Codigo), "Null", "'" & x_entidades.ENTID_Codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM dbo.Entidades" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EEntidades)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From dbo.Entidades ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From dbo.Entidades ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EEntidades)(m_formatofecha) 
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

