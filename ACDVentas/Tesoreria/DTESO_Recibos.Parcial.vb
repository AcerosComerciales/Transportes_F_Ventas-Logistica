Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTESO_Recibos

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "TESO_Recibos"
		End Get
	End Property
	Public ReadOnly Property Esquema() As String
		Get
			Return "Tesoreria"
		End Get
	End Property

#End Region

#Region " Constructores "
	
	Public Sub New()
		m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
	End Sub

#End Region

#Region " Procedimientos Almacenados "
	
	Public Function TESO_RECIBSS_Todos(ByRef x_listTESO_Recibos As List(Of ETESO_Recibos)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETESO_Recibos())
					While reader.Read()
						Dim x_eteso_recibos As New ETESO_Recibos()
						_utilitarios.ACCargarEsquemas(reader, x_eteso_recibos)
						x_eteso_recibos.Instanciar(ACEInstancia.Consulta)
						x_listTESO_Recibos.Add(x_eteso_recibos)
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

	Public Function TESO_RECIBSS_Todos(ByRef x_listTESO_Recibos As List(Of ETESO_Recibos), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETESO_Recibos())
					While reader.Read()
						Dim x_eteso_recibos As New ETESO_Recibos()
						_utilitarios.ACCargarEsquemas(reader, x_eteso_recibos)
						x_eteso_recibos.Instanciar(ACEInstancia.Consulta)
						x_listTESO_Recibos.Add(x_eteso_recibos)
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

	Public Function TESO_RECIBSS_Todos(ByRef x_listTESO_Recibos As List(Of ETESO_Recibos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETESO_Recibos())
					While reader.Read()
						Dim x_eteso_recibos As New ETESO_Recibos()
						_utilitarios.ACCargarEsquemas(reader, x_eteso_recibos)
						x_eteso_recibos.Instanciar(ACEInstancia.Consulta)
						x_listTESO_Recibos.Add(x_eteso_recibos)
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

	Public Function TESO_RECIBSS_Todos(ByRef x_listTESO_Recibos As List(Of ETESO_Recibos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETESO_Recibos())
					While reader.Read()
						Dim x_eteso_recibos As New ETESO_Recibos()
						_utilitarios.ACCargarEsquemas(reader, x_eteso_recibos)
						x_eteso_recibos.Instanciar(ACEInstancia.Consulta)
						x_listTESO_Recibos.Add(x_eteso_recibos)
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

	Public Function TESO_RECIBSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSS_UnReg(ByRef x_eteso_recibos As ETESO_Recibos, ByVal x_recib_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_recib_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eteso_recibos)
					x_eteso_recibos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSS_UnReg(ByRef x_eteso_recibos As ETESO_Recibos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eteso_recibos)
					x_eteso_recibos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSS_UnReg(ByRef x_eteso_recibos As ETESO_Recibos, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eteso_recibos)
					x_eteso_recibos.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSI_UnReg(ByRef x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_teso_recibos, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    Public Function TRAN_CAJASS_ObtenerSaldosAFavorClientePendientes(ByVal m_list_RecibosPendientesAFavor As List(Of ETESO_Recibos), ByVal x_entidCodigoCliente As String) As Boolean
        Try
            'If reader.HasRows Then
            '	Dim _utilitarios As New ACEsquemas(New ETESO_Recibos())
            '	While reader.Read()
            '		Dim x_eteso_recibos As New ETESO_Recibos()
            '		_utilitarios.ACCargarEsquemas(reader, x_eteso_recibos)
            '		x_eteso_recibos.Instanciar(ACEInstancia.Consulta)
            '		x_listTESO_Recibos.Add(x_eteso_recibos)
            '	End While
            '	Return True
            'Else


            DAEnterprise.AsignarProcedure("TRAN_CAJASS_ObtenerSaldosAFavorClientePendientes")
            'DAEnterprise.AgregarParametro("@FecInicio", x_fecini, DbType.DateTime, 8)
            '	DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            '	DAEnterprise.AgregarParametro("@x_campo", x_campo, DbType.Int16, 8)
            DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entidCodigoCliente, DbType.String, 40)

            'DAEnterprise.AgregarParametro("@VEHIC_Id", x_cadena, DbType.Int16, 10)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _tran_RecibosSaldosAFavorPendientes As New ETESO_Recibos()
                        ACEsquemas.ACCargarEsquema(reader, _tran_RecibosSaldosAFavorPendientes)
                        _tran_RecibosSaldosAFavorPendientes.Instanciar(ACEInstancia.Consulta)
                        m_list_RecibosPendientesAFavor.Add(_tran_RecibosSaldosAFavorPendientes)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Function AyudaSaldo(ByRef x_datos As DataSet, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_entid_codigoDoc As String) As Boolean
    Public Function getAyudaSaldo(ByRef x_datos As DataSet, ByVal x_entid_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_CAJASS_ObtenerSaldosAFavorClientePendientes")
            'DAEnterprise.AgregarParametro("@Entid_Codigo", x_fecini, DbType.DateTime, 8)
            'DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entid_codigo, DbType.String, 20)
            'DAEnterprise.AgregarParametro("@ENTID_CodigoDoc", x_entid_codigoDoc, DbType.String, 15)
            x_datos = DAEnterprise.ExecuteDataSet()
            Return x_datos.Tables(0).Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function TESO_RECIBSI_UnReg(ByRef x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_teso_recibos, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSI_UnReg(ByRef x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_teso_recibos, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSU_UnReg(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_recibos, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSU_UnReg(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_recibos, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSU_UnReg(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_recibos, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSU_UnReg(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_recibos, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSU_UnReg(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_recibos, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSU_UnReg(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_teso_recibos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSD_UnReg(ByVal x_teso_recibos As ETESO_Recibos) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_teso_recibos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TESO_RECIBSD_UnReg(ByVal x_where As Hashtable) As Integer
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
    
    Public Function getEntidad(ByVal x_campo As String, ByVal x_where As Hashtable) As String
		Try
			DAEnterprise.AsignarProcedure(getSelectentidad(x_campo, x_where), CommandType.Text)
			Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
			Return CType(m_data.Tables(0).Rows(0)("Id"), String)
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
				sql &= " FROM Tesoreria.TESO_Recibos" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Tesoreria.TESO_Recibos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETESO_Recibos)(m_formatofecha)
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
				sql &= " FROM Tesoreria.TESO_Recibos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETESO_Recibos)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETESO_Recibos)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETESO_Recibos)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_recib_codigo As String) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Tesoreria.TESO_Recibos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "RECIB_Codigo = " + IIf(IsNothing(x_recib_codigo), "Null", "'" & x_recib_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Tesoreria.TESO_Recibos" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETESO_Recibos)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETESO_Recibos)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_recibos.RECIB_UsrCrea = x_usuario
				x_teso_recibos.RECIB_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETESO_Recibos)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_teso_recibos, x_teso_recibos.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_recibos.RECIB_UsrCrea = x_usuario
				x_teso_recibos.RECIB_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETESO_Recibos)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_teso_recibos, x_teso_recibos.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_recibos.RECIB_UsrCrea = x_usuario
				x_teso_recibos.RECIB_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETESO_Recibos)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_teso_recibos, x_teso_recibos.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_recibos.RECIB_UsrMod = x_usuario
				x_teso_recibos.RECIB_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_Recibos)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("RECIB_Codigo", New ACWhere(x_TESO_Recibos.RECIB_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_teso_recibos, _where, x_teso_recibos.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_recibos.RECIB_UsrMod = x_usuario
				x_teso_recibos.RECIB_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_Recibos)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("RECIB_Codigo", New ACWhere(x_TESO_Recibos.RECIB_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_teso_recibos, _where, x_teso_recibos.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_recibos.RECIB_UsrMod = x_usuario
				x_teso_recibos.RECIB_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_Recibos)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_teso_recibos, x_where, x_teso_recibos.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_recibos.RECIB_UsrMod = x_usuario
				x_teso_recibos.RECIB_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_Recibos)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("RECIB_Codigo", New ACWhere(x_TESO_Recibos.RECIB_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_teso_recibos, _where, x_teso_recibos.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_recibos.RECIB_UsrMod = x_usuario
				x_teso_recibos.RECIB_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_Recibos)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_teso_recibos, x_where, x_teso_recibos.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_teso_recibos As ETESO_Recibos, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_teso_recibos.RECIB_UsrMod = x_usuario
				x_teso_recibos.RECIB_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETESO_Recibos)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_teso_recibos, x_where, x_teso_recibos.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_teso_recibos As ETESO_Recibos) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Tesoreria.TESO_Recibos" & vbNewLine
				sql &= " WHERE "
				sql &= "    RECIB_Codigo = " & IIf(IsNothing(x_teso_recibos.RECIB_Codigo), "Null", "'" & x_teso_recibos.RECIB_Codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Tesoreria.TESO_Recibos" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETESO_Recibos)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Tesoreria.TESO_Recibos ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
    
        Private Function getSelectentidad(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT {0} As Id From dbo.Entidades ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EEntidades)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Tesoreria.TESO_Recibos ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETESO_Recibos)(m_formatofecha) 
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

