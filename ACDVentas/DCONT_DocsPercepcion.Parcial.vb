Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DCONT_DocsPercepcion

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "CONT_DocsPercepcion"
		End Get
	End Property
	Public ReadOnly Property Esquema() As String
		Get
			Return "Contabilidad"
		End Get
	End Property

#End Region

#Region " Constructores "
	
	Public Sub New()
		m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
	End Sub

#End Region

#Region " Procedimientos Almacenados "
	
	Public Function CONT_DOCPESS_Todos(ByRef x_listCONT_DocsPercepcion As List(Of ECONT_DocsPercepcion)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ECONT_DocsPercepcion())
					While reader.Read()
						Dim x_econt_docspercepcion As New ECONT_DocsPercepcion()
						_utilitarios.ACCargarEsquemas(reader, x_econt_docspercepcion)
						x_econt_docspercepcion.Instanciar(ACEInstancia.Consulta)
						x_listCONT_DocsPercepcion.Add(x_econt_docspercepcion)
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

	Public Function CONT_DOCPESS_Todos(ByRef x_listCONT_DocsPercepcion As List(Of ECONT_DocsPercepcion), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ECONT_DocsPercepcion())
					While reader.Read()
						Dim x_econt_docspercepcion As New ECONT_DocsPercepcion()
						_utilitarios.ACCargarEsquemas(reader, x_econt_docspercepcion)
						x_econt_docspercepcion.Instanciar(ACEInstancia.Consulta)
						x_listCONT_DocsPercepcion.Add(x_econt_docspercepcion)
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

	Public Function CONT_DOCPESS_Todos(ByRef x_listCONT_DocsPercepcion As List(Of ECONT_DocsPercepcion), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ECONT_DocsPercepcion())
					While reader.Read()
						Dim x_econt_docspercepcion As New ECONT_DocsPercepcion()
						_utilitarios.ACCargarEsquemas(reader, x_econt_docspercepcion)
						x_econt_docspercepcion.Instanciar(ACEInstancia.Consulta)
						x_listCONT_DocsPercepcion.Add(x_econt_docspercepcion)
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

	Public Function CONT_DOCPESS_Todos(ByRef x_listCONT_DocsPercepcion As List(Of ECONT_DocsPercepcion), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ECONT_DocsPercepcion())
					While reader.Read()
						Dim x_econt_docspercepcion As New ECONT_DocsPercepcion()
						_utilitarios.ACCargarEsquemas(reader, x_econt_docspercepcion)
						x_econt_docspercepcion.Instanciar(ACEInstancia.Consulta)
						x_listCONT_DocsPercepcion.Add(x_econt_docspercepcion)
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

	Public Function CONT_DOCPESS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
    End Function
    'funcion que recupera las percepciones con su detalle
    Public Function CONT_DOCPEDT_Todos(ByVal x_serie As String, ByVal x_numero As Decimal, ByVal x_itodos As Int16, ByVal x_tipo As String, ByRef m_datos As DataTable, x_fecIni As DateTime, x_fecfin As DateTime) As Boolean
        Try

            DAEnterprise.AsignarProcedure("VENT_PERCSS_Formato")
            DAEnterprise.AgregarParametro("@dIni", x_fecIni, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@dFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@cSerie", x_serie, DbType.String, 4)
            DAEnterprise.AgregarParametro("@cNumero", x_numero, DbType.Decimal, 18)
            DAEnterprise.AgregarParametro("@cTipo", x_tipo, DbType.String, 6)
            DAEnterprise.AgregarParametro("@iTodos", x_itodos, DbType.Int16, 8)

            m_datos = DAEnterprise.ExecuteDataSet().Tables(0)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

	Public Function CONT_DOCPESS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESS_UnReg(ByRef x_econt_docspercepcion As ECONT_DocsPercepcion, ByVal x_docpe_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_docpe_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_econt_docspercepcion)
					x_econt_docspercepcion.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESS_UnReg(ByRef x_econt_docspercepcion As ECONT_DocsPercepcion, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_econt_docspercepcion)
					x_econt_docspercepcion.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESS_UnReg(ByRef x_econt_docspercepcion As ECONT_DocsPercepcion, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_econt_docspercepcion)
					x_econt_docspercepcion.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESI_UnReg(ByRef x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_cont_docspercepcion, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESI_UnReg(ByRef x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_cont_docspercepcion, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESI_UnReg(ByRef x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_cont_docspercepcion, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESU_UnReg(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_cont_docspercepcion, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESU_UnReg(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_cont_docspercepcion, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESU_UnReg(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_cont_docspercepcion, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESU_UnReg(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_cont_docspercepcion, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESU_UnReg(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_cont_docspercepcion, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESU_UnReg(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_cont_docspercepcion, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESD_UnReg(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_cont_docspercepcion), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function CONT_DOCPESD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Contabilidad.CONT_DocsPercepcion" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Contabilidad.CONT_DocsPercepcion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ECONT_DocsPercepcion)(m_formatofecha)
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
				sql &= " FROM Contabilidad.CONT_DocsPercepcion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ECONT_DocsPercepcion)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ECONT_DocsPercepcion)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ECONT_DocsPercepcion)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_docpe_codigo As String) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Contabilidad.CONT_DocsPercepcion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "DOCPE_Codigo = " + IIf(IsNothing(x_docpe_codigo), "Null", "'" & x_docpe_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Contabilidad.CONT_DocsPercepcion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ECONT_DocsPercepcion)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ECONT_DocsPercepcion)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_cont_docspercepcion.DOCPE_UsrCrea = x_usuario
				x_cont_docspercepcion.DOCPE_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ECONT_DocsPercepcion)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_cont_docspercepcion, x_cont_docspercepcion.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_cont_docspercepcion.DOCPE_UsrCrea = x_usuario
				x_cont_docspercepcion.DOCPE_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ECONT_DocsPercepcion)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_cont_docspercepcion, x_cont_docspercepcion.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_cont_docspercepcion.DOCPE_UsrCrea = x_usuario
				x_cont_docspercepcion.DOCPE_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ECONT_DocsPercepcion)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_cont_docspercepcion, x_cont_docspercepcion.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_cont_docspercepcion.DOCPE_UsrMod = x_usuario
				x_cont_docspercepcion.DOCPE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECONT_DocsPercepcion)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCPE_Codigo", New ACWhere(x_CONT_DocsPercepcion.DOCPE_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_cont_docspercepcion, _where, x_cont_docspercepcion.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_cont_docspercepcion.DOCPE_UsrMod = x_usuario
				x_cont_docspercepcion.DOCPE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECONT_DocsPercepcion)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCPE_Codigo", New ACWhere(x_CONT_DocsPercepcion.DOCPE_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_cont_docspercepcion, _where, x_cont_docspercepcion.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_cont_docspercepcion.DOCPE_UsrMod = x_usuario
				x_cont_docspercepcion.DOCPE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECONT_DocsPercepcion)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_cont_docspercepcion, x_where, x_cont_docspercepcion.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_cont_docspercepcion.DOCPE_UsrMod = x_usuario
				x_cont_docspercepcion.DOCPE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECONT_DocsPercepcion)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCPE_Codigo", New ACWhere(x_CONT_DocsPercepcion.DOCPE_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_cont_docspercepcion, _where, x_cont_docspercepcion.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_cont_docspercepcion.DOCPE_UsrMod = x_usuario
				x_cont_docspercepcion.DOCPE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECONT_DocsPercepcion)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_cont_docspercepcion, x_where, x_cont_docspercepcion.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_cont_docspercepcion.DOCPE_UsrMod = x_usuario
				x_cont_docspercepcion.DOCPE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ECONT_DocsPercepcion)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_cont_docspercepcion, x_where, x_cont_docspercepcion.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_cont_docspercepcion As ECONT_DocsPercepcion) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Contabilidad.CONT_DocsPercepcion" & vbNewLine
				sql &= " WHERE "
				sql &= "    DOCPE_Codigo = " & IIf(IsNothing(x_cont_docspercepcion.DOCPE_Codigo), "Null", "'" & x_cont_docspercepcion.DOCPE_Codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Contabilidad.CONT_DocsPercepcion" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ECONT_DocsPercepcion)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Contabilidad.CONT_DocsPercepcion ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Contabilidad.CONT_DocsPercepcion ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ECONT_DocsPercepcion)(m_formatofecha) 
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

