Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_DocumentosDetalle

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "TRAN_DocumentosDetalle"
		End Get
	End Property
	Public ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property

#End Region

#Region " Constructores "
	
	Public Sub New()
		m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
	End Sub

#End Region

#Region " Procedimientos Almacenados "

    Public Function TRAN_DCDETSS_Todos(ByRef listETRAN_DocumentosDetalle As List(Of ETRAN_DocumentosDetalle)) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRAN_DocumentosDetalle())
                    While reader.Read()
                        Dim e_tran_documentosdetalle As New ETRAN_DocumentosDetalle()
                        _utilitarios.ACCargarEsquemas(reader, e_tran_documentosdetalle)
                        e_tran_documentosdetalle.Instanciar(ACEInstancia.Consulta)
                        listETRAN_DocumentosDetalle.Add(e_tran_documentosdetalle)
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
    Public Function TRAN_VMAN_ObtenerMantenimientosDocumentos_Detalle(ByRef m_listTRA_DocumentosDetalle As List(Of ETRAN_DocumentosDetalle), ByVal x_docus_codigo As String, ByVal x_entid_codigo As String) As Boolean

        Try
            DAEnterprise.AsignarProcedure("TRAN_VMAN_ObtenerMantenimientosDocumentos_Detalle")
            DAEnterprise.AgregarParametro("@DocusCodigo", x_docus_codigo, DbType.String, 40)
            DAEnterprise.AgregarParametro("@Entid_Codigo", x_entid_codigo, DbType.String, 11)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim e_tran_documentosdetalles As New ETRAN_DocumentosDetalle()
                        ACEsquemas.ACCargarEsquema(reader, e_tran_documentosdetalles)
                        e_tran_documentosdetalles.Instanciar(ACEInstancia.Consulta)
                        m_listTRA_DocumentosDetalle.Add(e_tran_documentosdetalles)
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

    Public Function TRAN_DCDETSS_Todos(ByRef listETRAN_DocumentosDetalle As List(Of ETRAN_DocumentosDetalle), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_DocumentosDetalle())
					While reader.Read()
						Dim e_tran_documentosdetalle As New ETRAN_DocumentosDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_tran_documentosdetalle)
						e_tran_documentosdetalle.Instanciar(ACEInstancia.Consulta)
						listETRAN_DocumentosDetalle.Add(e_tran_documentosdetalle)
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
	Public Function TRAN_DCDETSS_Todos(ByRef listETRAN_DocumentosDetalle As List(Of ETRAN_DocumentosDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_DocumentosDetalle())
					While reader.Read()
						Dim e_tran_documentosdetalle As New ETRAN_DocumentosDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_tran_documentosdetalle)
						e_tran_documentosdetalle.Instanciar(ACEInstancia.Consulta)
						listETRAN_DocumentosDetalle.Add(e_tran_documentosdetalle)
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
	Public Function TRAN_DCDETSS_Todos(ByRef listETRAN_DocumentosDetalle As List(Of ETRAN_DocumentosDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_DocumentosDetalle())
					While reader.Read()
						Dim e_tran_documentosdetalle As New ETRAN_DocumentosDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_tran_documentosdetalle)
						e_tran_documentosdetalle.Instanciar(ACEInstancia.Consulta)
						listETRAN_DocumentosDetalle.Add(e_tran_documentosdetalle)
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
	Public Function TRAN_DCDETSS_Todos(ByRef listETRAN_DocumentosDetalle As List(Of ETRAN_DocumentosDetalle), ByVal x_docus_codigo As String, ByVal x_entid_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_docus_codigo, x_entid_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_DocumentosDetalle())
					While reader.Read()
						Dim e_tran_documentosdetalle As New ETRAN_DocumentosDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_tran_documentosdetalle)
						e_tran_documentosdetalle.Instanciar(ACEInstancia.Consulta)
						listETRAN_DocumentosDetalle.Add(e_tran_documentosdetalle)
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
	Public Function TRAN_DCDETSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSS_UnReg(ByRef x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_dcdet_item As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_docus_codigo, x_entid_codigo, x_dcdet_item), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_tran_documentosdetalle)
					x_tran_documentosdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSS_UnReg(ByRef x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_tran_documentosdetalle)
					x_tran_documentosdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSS_UnReg(ByRef x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_tran_documentosdetalle)
					x_tran_documentosdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSI_UnReg(ByRef x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_documentosdetalle, x_usuario), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSI_UnReg(ByRef x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_documentosdetalle, x_usuario, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSI_UnReg(ByRef x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_documentosdetalle, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSU_UnReg(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_documentosdetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSU_UnReg(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_documentosdetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSU_UnReg(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_documentosdetalle, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSU_UnReg(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_documentosdetalle, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSU_UnReg(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_documentosdetalle, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSU_UnReg(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_documentosdetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSD_UnReg(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_tran_documentosdetalle), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_DCDETSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Transportes.TRAN_DocumentosDetalle" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Transportes.TRAN_DocumentosDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETRAN_DocumentosDetalle)(m_formatofecha)
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
				sql &= " FROM Transportes.TRAN_DocumentosDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETRAN_DocumentosDetalle)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETRAN_DocumentosDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETRAN_DocumentosDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Transportes.TRAN_DocumentosDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "DOCUS_Codigo = " + IIf(IsNothing(x_docus_codigo), "Null", "'" & x_docus_codigo & "'") & vbNewLine
				sql &= " AND ENTID_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_dcdet_item As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Transportes.TRAN_DocumentosDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "DOCUS_Codigo = " + IIf(IsNothing(x_docus_codigo), "Null", "'" & x_docus_codigo & "'") & vbNewLine
				sql &= " AND ENTID_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine
				sql &= " AND DCDET_Item = " + x_dcdet_item.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_documentosdetalle.DCDET_UsrCrea = x_usuario
				x_tran_documentosdetalle.DCDET_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_DocumentosDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_tran_documentosdetalle, x_tran_documentosdetalle.Hash, New String() {})
            Debug.WriteLine(sql)

            Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_documentosdetalle.DCDET_UsrCrea = x_usuario
				x_tran_documentosdetalle.DCDET_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_DocumentosDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_documentosdetalle, x_tran_documentosdetalle.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_documentosdetalle.DCDET_UsrCrea = x_usuario
				x_tran_documentosdetalle.DCDET_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_DocumentosDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_documentosdetalle, x_tran_documentosdetalle.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_documentosdetalle.DCDET_UsrMod = x_usuario
				x_tran_documentosdetalle.DCDET_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_DocumentosDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCUS_Codigo", New ACWhere(x_TRAN_DocumentosDetalle.DOCUS_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_Codigo", New ACWhere(x_TRAN_DocumentosDetalle.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("DCDET_Item", New ACWhere(x_TRAN_DocumentosDetalle.DCDET_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_tran_documentosdetalle, _where, x_tran_documentosdetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_documentosdetalle.DCDET_UsrMod = x_usuario
				x_tran_documentosdetalle.DCDET_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_DocumentosDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCUS_Codigo", New ACWhere(x_TRAN_DocumentosDetalle.DOCUS_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_Codigo", New ACWhere(x_TRAN_DocumentosDetalle.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("DCDET_Item", New ACWhere(x_TRAN_DocumentosDetalle.DCDET_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_documentosdetalle, _where, x_tran_documentosdetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_documentosdetalle.DCDET_UsrMod = x_usuario
				x_tran_documentosdetalle.DCDET_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_DocumentosDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_tran_documentosdetalle, x_where, x_tran_documentosdetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_documentosdetalle.DCDET_UsrMod = x_usuario
				x_tran_documentosdetalle.DCDET_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_DocumentosDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCUS_Codigo", New ACWhere(x_TRAN_DocumentosDetalle.DOCUS_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_Codigo", New ACWhere(x_TRAN_DocumentosDetalle.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("DCDET_Item", New ACWhere(x_TRAN_DocumentosDetalle.DCDET_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_documentosdetalle, _where, x_tran_documentosdetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_documentosdetalle.DCDET_UsrMod = x_usuario
				x_tran_documentosdetalle.DCDET_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_DocumentosDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_documentosdetalle, x_where, x_tran_documentosdetalle.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_documentosdetalle.DCDET_UsrMod = x_usuario
				x_tran_documentosdetalle.DCDET_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_DocumentosDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_tran_documentosdetalle, x_where, x_tran_documentosdetalle.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_tran_documentosdetalle As ETRAN_DocumentosDetalle) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Transportes.TRAN_DocumentosDetalle" & vbNewLine
				sql &= " WHERE "
				sql &= "    DOCUS_Codigo = " & IIf(IsNothing(x_tran_documentosdetalle.DOCUS_Codigo), "Null", "'" & x_tran_documentosdetalle.DOCUS_Codigo & "'") & vbNewLine
				sql &= "And ENTID_Codigo = " & IIf(IsNothing(x_tran_documentosdetalle.ENTID_Codigo), "Null", "'" & x_tran_documentosdetalle.ENTID_Codigo & "'") & vbNewLine
				sql &= "And DCDET_Item = " & IIf(x_tran_documentosdetalle.DCDET_Item = 0, "Null", x_tran_documentosdetalle.DCDET_Item.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Transportes.TRAN_DocumentosDetalle" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETRAN_DocumentosDetalle)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_DocumentosDetalle ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_DocumentosDetalle ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETRAN_DocumentosDetalle)(m_formatofecha) 
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

