Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DEntidadRelacion

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "EntidadRelacion"
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
	
	Public Function ENTRESS_Todos(ByRef listEEntidadRelacion As List(Of EEntidadRelacion)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EEntidadRelacion())
					While reader.Read()
						Dim e_entidadrelacion As New EEntidadRelacion()
						_utilitarios.ACCargarEsquemas(reader, e_entidadrelacion)
						e_entidadrelacion.Instanciar(ACEInstancia.Consulta)
						listEEntidadRelacion.Add(e_entidadrelacion)
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
	Public Function ENTRESS_Todos(ByRef listEEntidadRelacion As List(Of EEntidadRelacion), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EEntidadRelacion())
					While reader.Read()
						Dim e_entidadrelacion As New EEntidadRelacion()
						_utilitarios.ACCargarEsquemas(reader, e_entidadrelacion)
						e_entidadrelacion.Instanciar(ACEInstancia.Consulta)
						listEEntidadRelacion.Add(e_entidadrelacion)
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
	Public Function ENTRESS_Todos(ByRef listEEntidadRelacion As List(Of EEntidadRelacion), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EEntidadRelacion())
					While reader.Read()
						Dim e_entidadrelacion As New EEntidadRelacion()
						_utilitarios.ACCargarEsquemas(reader, e_entidadrelacion)
						e_entidadrelacion.Instanciar(ACEInstancia.Consulta)
						listEEntidadRelacion.Add(e_entidadrelacion)
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
	Public Function ENTRESS_Todos(ByRef listEEntidadRelacion As List(Of EEntidadRelacion), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EEntidadRelacion())
					While reader.Read()
						Dim e_entidadrelacion As New EEntidadRelacion()
						_utilitarios.ACCargarEsquemas(reader, e_entidadrelacion)
						e_entidadrelacion.Instanciar(ACEInstancia.Consulta)
						listEEntidadRelacion.Add(e_entidadrelacion)
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
	Public Function ENTRESS_Todos(ByRef listEEntidadRelacion As List(Of EEntidadRelacion), ByVal x_entid_codigo As String, ByVal x_entid_codrelacion As String, ByVal x_tipos_codtiporelacion As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_entid_codigo, x_entid_codrelacion, x_tipos_codtiporelacion), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EEntidadRelacion())
					While reader.Read()
						Dim e_entidadrelacion As New EEntidadRelacion()
						_utilitarios.ACCargarEsquemas(reader, e_entidadrelacion)
						e_entidadrelacion.Instanciar(ACEInstancia.Consulta)
						listEEntidadRelacion.Add(e_entidadrelacion)
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
	Public Function ENTRESS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESS_UnReg(ByRef x_entidadrelacion As EEntidadRelacion, ByVal x_entre_numero As Short, ByVal x_entid_codigo As String, ByVal x_entid_codrelacion As String, ByVal x_tipos_codtiporelacion As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_entre_numero, x_entid_codigo, x_entid_codrelacion, x_tipos_codtiporelacion), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_entidadrelacion)
					x_entidadrelacion.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESS_UnReg(ByRef x_entidadrelacion As EEntidadRelacion, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_entidadrelacion)
					x_entidadrelacion.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESS_UnReg(ByRef x_entidadrelacion As EEntidadRelacion, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_entidadrelacion)
					x_entidadrelacion.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESI_UnReg(ByRef x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_entidadrelacion, x_usuario), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESI_UnReg(ByRef x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_entidadrelacion, x_usuario, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESI_UnReg(ByRef x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_entidadrelacion, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESU_UnReg(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidadrelacion, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESU_UnReg(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidadrelacion, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESU_UnReg(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidadrelacion, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESU_UnReg(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidadrelacion, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESU_UnReg(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidadrelacion, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESU_UnReg(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_entidadrelacion, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESD_UnReg(ByVal x_entidadrelacion As EEntidadRelacion) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_entidadrelacion), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function ENTRESD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM dbo.EntidadRelacion" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM dbo.EntidadRelacion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EEntidadRelacion)(m_formatofecha)
				sql &= _where.getWhere(x_where, True)
            Debug.WriteLine(sql)
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
				sql &= " FROM dbo.EntidadRelacion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EEntidadRelacion)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EEntidadRelacion)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EEntidadRelacion)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_entid_codigo As String, ByVal x_entid_codrelacion As String, ByVal x_tipos_codtiporelacion As String) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM dbo.EntidadRelacion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ENTID_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine
				sql &= " AND ENTID_CodRelacion = " + IIf(IsNothing(x_entid_codrelacion), "Null", "'" & x_entid_codrelacion & "'") & vbNewLine
				sql &= " AND TIPOS_CodTipoRelacion = " + IIf(IsNothing(x_tipos_codtiporelacion), "Null", "'" & x_tipos_codtiporelacion & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_entre_numero As Short, ByVal x_entid_codigo As String, ByVal x_entid_codrelacion As String, ByVal x_tipos_codtiporelacion As String) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM dbo.EntidadRelacion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ENTRE_Numero = " + x_entre_numero.ToString() & vbNewLine
				sql &= " AND ENTID_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine
				sql &= " AND ENTID_CodRelacion = " + IIf(IsNothing(x_entid_codrelacion), "Null", "'" & x_entid_codrelacion & "'") & vbNewLine
				sql &= " AND TIPOS_CodTipoRelacion = " + IIf(IsNothing(x_tipos_codtiporelacion), "Null", "'" & x_tipos_codtiporelacion & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidadrelacion.ENTRE_UsrCrea = x_usuario
				x_entidadrelacion.ENTRE_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EEntidadRelacion)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_entidadrelacion, x_entidadrelacion.Hash, New String() {})

                Debug.WriteLine(sql)
				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidadrelacion.ENTRE_UsrCrea = x_usuario
				x_entidadrelacion.ENTRE_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EEntidadRelacion)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_entidadrelacion, x_entidadrelacion.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidadrelacion.ENTRE_UsrCrea = x_usuario
				x_entidadrelacion.ENTRE_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EEntidadRelacion)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_entidadrelacion, x_entidadrelacion.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidadrelacion.ENTRE_UsrMod = x_usuario
				x_entidadrelacion.ENTRE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidadRelacion)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ENTRE_Numero", New ACWhere(x_EntidadRelacion.ENTRE_Numero, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_Codigo", New ACWhere(x_EntidadRelacion.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_CodRelacion", New ACWhere(x_EntidadRelacion.ENTID_CodRelacion, ACWhere.TipoWhere.Igual))
				_where.Add("TIPOS_CodTipoRelacion", New ACWhere(x_EntidadRelacion.TIPOS_CodTipoRelacion, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_entidadrelacion, _where, x_entidadrelacion.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidadrelacion.ENTRE_UsrMod = x_usuario
				x_entidadrelacion.ENTRE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidadRelacion)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ENTRE_Numero", New ACWhere(x_EntidadRelacion.ENTRE_Numero, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_Codigo", New ACWhere(x_EntidadRelacion.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_CodRelacion", New ACWhere(x_EntidadRelacion.ENTID_CodRelacion, ACWhere.TipoWhere.Igual))
				_where.Add("TIPOS_CodTipoRelacion", New ACWhere(x_EntidadRelacion.TIPOS_CodTipoRelacion, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_entidadrelacion, _where, x_entidadrelacion.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidadrelacion.ENTRE_UsrMod = x_usuario
				x_entidadrelacion.ENTRE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidadRelacion)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_entidadrelacion, x_where, x_entidadrelacion.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidadrelacion.ENTRE_UsrMod = x_usuario
				x_entidadrelacion.ENTRE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidadRelacion)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("ENTRE_Numero", New ACWhere(x_EntidadRelacion.ENTRE_Numero, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_Codigo", New ACWhere(x_EntidadRelacion.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_CodRelacion", New ACWhere(x_EntidadRelacion.ENTID_CodRelacion, ACWhere.TipoWhere.Igual))
				_where.Add("TIPOS_CodTipoRelacion", New ACWhere(x_EntidadRelacion.TIPOS_CodTipoRelacion, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_entidadrelacion, _where, x_entidadrelacion.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidadrelacion.ENTRE_UsrMod = x_usuario
				x_entidadrelacion.ENTRE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidadRelacion)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_entidadrelacion, x_where, x_entidadrelacion.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_entidadrelacion As EEntidadRelacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_entidadrelacion.ENTRE_UsrMod = x_usuario
				x_entidadrelacion.ENTRE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EEntidadRelacion)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_entidadrelacion, x_where, x_entidadrelacion.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_entidadrelacion As EEntidadRelacion) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM dbo.EntidadRelacion" & vbNewLine
				sql &= " WHERE "
				sql &= "    ENTRE_Numero = " & IIf(x_entidadrelacion.ENTRE_Numero = 0, "Null", x_entidadrelacion.ENTRE_Numero.ToString()) & vbNewLine
				sql &= "And ENTID_Codigo = " & IIf(IsNothing(x_entidadrelacion.ENTID_Codigo), "Null", "'" & x_entidadrelacion.ENTID_Codigo & "'") & vbNewLine
				sql &= "And ENTID_CodRelacion = " & IIf(IsNothing(x_entidadrelacion.ENTID_CodRelacion), "Null", "'" & x_entidadrelacion.ENTID_CodRelacion & "'") & vbNewLine
				sql &= "And TIPOS_CodTipoRelacion = " & IIf(IsNothing(x_entidadrelacion.TIPOS_CodTipoRelacion), "Null", "'" & x_entidadrelacion.TIPOS_CodTipoRelacion & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM dbo.EntidadRelacion" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EEntidadRelacion)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From dbo.EntidadRelacion ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From dbo.EntidadRelacion ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EEntidadRelacion)(m_formatofecha) 
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

