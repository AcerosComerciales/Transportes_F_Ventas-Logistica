Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_VehiculosMantenimientoDocCompra

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "TRAN_VehiculosMantenimientoDocCompra"
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

    Public Function TRAN_VMDCOSS_Todos(ByRef x_listTRAN_VehiculosMantenimientoDocCompra As List(Of ETRAN_VehiculosMantenimientoDocCompra)) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosMantenimientoDocCompra())
                    While reader.Read()
                        Dim x_etran_vehiculosmantenimientodoccompra As New ETRAN_VehiculosMantenimientoDocCompra()
                        _utilitarios.ACCargarEsquemas(reader, x_etran_vehiculosmantenimientodoccompra)
                        x_etran_vehiculosmantenimientodoccompra.Instanciar(ACEInstancia.Consulta)
                        x_listTRAN_VehiculosMantenimientoDocCompra.Add(x_etran_vehiculosmantenimientodoccompra)
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

    Public Function TRAN_VMAN_ObtenerMantenimientosDeleteDocCompra(ByVal x_vehic_id As Long, ByVal x_docus_codigo As String, ByVal x_vman_item As Long) As Boolean

        Try
            DAEnterprise.AsignarProcedure("TRAN_VMAN_ObtenerMantenimientosDeleteDocCompra")

            DAEnterprise.AgregarParametro("@VEHIC_id", x_vehic_id, DbType.Int16)
            DAEnterprise.AgregarParametro("@Docus_Codigo", x_docus_codigo, DbType.String)
            DAEnterprise.AgregarParametro("@VMAN_Item", x_vman_item, DbType.Int16)
            Dim rowsAffected As Integer = DAEnterprise.ExecuteNonQuery()
            ' Si se eliminaron filas, rowsAffected será mayor que 0
            If rowsAffected > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TRAN_VMDCOSS_Todos(ByRef x_listTRAN_VehiculosMantenimientoDocCompra As List(Of ETRAN_VehiculosMantenimientoDocCompra), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosMantenimientoDocCompra())
					While reader.Read()
						Dim x_etran_vehiculosmantenimientodoccompra As New ETRAN_VehiculosMantenimientoDocCompra()
						_utilitarios.ACCargarEsquemas(reader, x_etran_vehiculosmantenimientodoccompra)
						x_etran_vehiculosmantenimientodoccompra.Instanciar(ACEInstancia.Consulta)
						x_listTRAN_VehiculosMantenimientoDocCompra.Add(x_etran_vehiculosmantenimientodoccompra)
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

	Public Function TRAN_VMDCOSS_Todos(ByRef x_listTRAN_VehiculosMantenimientoDocCompra As List(Of ETRAN_VehiculosMantenimientoDocCompra), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosMantenimientoDocCompra())
					While reader.Read()
						Dim x_etran_vehiculosmantenimientodoccompra As New ETRAN_VehiculosMantenimientoDocCompra()
						_utilitarios.ACCargarEsquemas(reader, x_etran_vehiculosmantenimientodoccompra)
						x_etran_vehiculosmantenimientodoccompra.Instanciar(ACEInstancia.Consulta)
						x_listTRAN_VehiculosMantenimientoDocCompra.Add(x_etran_vehiculosmantenimientodoccompra)
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

	Public Function TRAN_VMDCOSS_Todos(ByRef x_listTRAN_VehiculosMantenimientoDocCompra As List(Of ETRAN_VehiculosMantenimientoDocCompra), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosMantenimientoDocCompra())
					While reader.Read()
						Dim x_etran_vehiculosmantenimientodoccompra As New ETRAN_VehiculosMantenimientoDocCompra()
						_utilitarios.ACCargarEsquemas(reader, x_etran_vehiculosmantenimientodoccompra)
						x_etran_vehiculosmantenimientodoccompra.Instanciar(ACEInstancia.Consulta)
						x_listTRAN_VehiculosMantenimientoDocCompra.Add(x_etran_vehiculosmantenimientodoccompra)
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

	Public Function TRAN_VMDCOSS_Todos(ByRef x_etran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_vehic_id As Long, ByVal x_vman_item As Long) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_docus_codigo, x_entid_codigo, x_vehic_id, x_vman_item), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_etran_vehiculosmantenimientodoccompra)
					x_etran_vehiculosmantenimientodoccompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSS_UnReg(ByRef x_etran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_vehic_id As Long, ByVal x_vman_item As Long, ByVal x_vmdco_numero As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_docus_codigo, x_entid_codigo, x_vehic_id, x_vman_item, x_vmdco_numero), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_etran_vehiculosmantenimientodoccompra)
					x_etran_vehiculosmantenimientodoccompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSS_UnReg(ByRef x_etran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_etran_vehiculosmantenimientodoccompra)
					x_etran_vehiculosmantenimientodoccompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSS_UnReg(ByRef x_etran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_etran_vehiculosmantenimientodoccompra)
					x_etran_vehiculosmantenimientodoccompra.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSI_UnReg(ByRef x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_vehiculosmantenimientodoccompra, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSI_UnReg(ByRef x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_vehiculosmantenimientodoccompra, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSI_UnReg(ByRef x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_vehiculosmantenimientodoccompra, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSU_UnReg(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosmantenimientodoccompra, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSU_UnReg(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosmantenimientodoccompra, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSU_UnReg(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosmantenimientodoccompra, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSU_UnReg(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosmantenimientodoccompra, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSU_UnReg(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosmantenimientodoccompra, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSU_UnReg(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosmantenimientodoccompra, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSD_UnReg(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_tran_vehiculosmantenimientodoccompra), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function TRAN_VMDCOSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Transportes.TRAN_VehiculosMantenimientoDocCompra" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Transportes.TRAN_VehiculosMantenimientoDocCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(m_formatofecha)
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
				sql &= " FROM Transportes.TRAN_VehiculosMantenimientoDocCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_vehic_id As Long, ByVal x_vman_item As Long) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Transportes.TRAN_VehiculosMantenimientoDocCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "DOCUS_Codigo = " + IIf(IsNothing(x_docus_codigo), "Null", "'" & x_docus_codigo & "'") & vbNewLine
				sql &= " AND ENTID_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine
				sql &= " AND VEHIC_Id = " + x_vehic_id.ToString() & vbNewLine
				sql &= " AND VMAN_Item = " + x_vman_item.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String, ByVal x_vehic_id As Long, ByVal x_vman_item As Long, ByVal x_vmdco_numero As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Transportes.TRAN_VehiculosMantenimientoDocCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "DOCUS_Codigo = " + IIf(IsNothing(x_docus_codigo), "Null", "'" & x_docus_codigo & "'") & vbNewLine
				sql &= " AND ENTID_Codigo = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine
				sql &= " AND VEHIC_Id = " + x_vehic_id.ToString() & vbNewLine
				sql &= " AND VMAN_Item = " + x_vman_item.ToString() & vbNewLine
				sql &= " AND VMDCO_Numero = " + x_vmdco_numero.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Transportes.TRAN_VehiculosMantenimientoDocCompra" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosmantenimientodoccompra.VMDCO_UsrCrea = x_usuario
				x_tran_vehiculosmantenimientodoccompra.VMDCO_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_tran_vehiculosmantenimientodoccompra, x_tran_vehiculosmantenimientodoccompra.Hash, New String() {})

            Debug.WriteLine(sql)
				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosmantenimientodoccompra.VMDCO_UsrCrea = x_usuario
				x_tran_vehiculosmantenimientodoccompra.VMDCO_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_vehiculosmantenimientodoccompra, x_tran_vehiculosmantenimientodoccompra.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosmantenimientodoccompra.VMDCO_UsrCrea = x_usuario
				x_tran_vehiculosmantenimientodoccompra.VMDCO_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_vehiculosmantenimientodoccompra, x_tran_vehiculosmantenimientodoccompra.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosmantenimientodoccompra.VMDCO_UsrMod = x_usuario
				x_tran_vehiculosmantenimientodoccompra.VMDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCUS_Codigo", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.DOCUS_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_Codigo", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("VEHIC_Id", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.VEHIC_Id, ACWhere.TipoWhere.Igual))
				_where.Add("VMAN_Item", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.VMAN_Item, ACWhere.TipoWhere.Igual))
				_where.Add("VMDCO_Numero", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.VMDCO_Numero, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_tran_vehiculosmantenimientodoccompra, _where, x_tran_vehiculosmantenimientodoccompra.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosmantenimientodoccompra.VMDCO_UsrMod = x_usuario
				x_tran_vehiculosmantenimientodoccompra.VMDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCUS_Codigo", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.DOCUS_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_Codigo", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("VEHIC_Id", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.VEHIC_Id, ACWhere.TipoWhere.Igual))
				_where.Add("VMAN_Item", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.VMAN_Item, ACWhere.TipoWhere.Igual))
				_where.Add("VMDCO_Numero", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.VMDCO_Numero, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_vehiculosmantenimientodoccompra, _where, x_tran_vehiculosmantenimientodoccompra.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosmantenimientodoccompra.VMDCO_UsrMod = x_usuario
				x_tran_vehiculosmantenimientodoccompra.VMDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_tran_vehiculosmantenimientodoccompra, x_where, x_tran_vehiculosmantenimientodoccompra.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosmantenimientodoccompra.VMDCO_UsrMod = x_usuario
				x_tran_vehiculosmantenimientodoccompra.VMDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCUS_Codigo", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.DOCUS_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_Codigo", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.ENTID_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("VEHIC_Id", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.VEHIC_Id, ACWhere.TipoWhere.Igual))
				_where.Add("VMAN_Item", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.VMAN_Item, ACWhere.TipoWhere.Igual))
				_where.Add("VMDCO_Numero", New ACWhere(x_TRAN_VehiculosMantenimientoDocCompra.VMDCO_Numero, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_vehiculosmantenimientodoccompra, _where, x_tran_vehiculosmantenimientodoccompra.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosmantenimientodoccompra.VMDCO_UsrMod = x_usuario
				x_tran_vehiculosmantenimientodoccompra.VMDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_vehiculosmantenimientodoccompra, x_where, x_tran_vehiculosmantenimientodoccompra.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosmantenimientodoccompra.VMDCO_UsrMod = x_usuario
				x_tran_vehiculosmantenimientodoccompra.VMDCO_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_tran_vehiculosmantenimientodoccompra, x_where, x_tran_vehiculosmantenimientodoccompra.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_tran_vehiculosmantenimientodoccompra As ETRAN_VehiculosMantenimientoDocCompra) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Transportes.TRAN_VehiculosMantenimientoDocCompra" & vbNewLine
				sql &= " WHERE "
				sql &= "    DOCUS_Codigo = " & IIf(IsNothing(x_tran_vehiculosmantenimientodoccompra.DOCUS_Codigo), "Null", "'" & x_tran_vehiculosmantenimientodoccompra.DOCUS_Codigo & "'") & vbNewLine
				sql &= "And ENTID_Codigo = " & IIf(IsNothing(x_tran_vehiculosmantenimientodoccompra.ENTID_Codigo), "Null", "'" & x_tran_vehiculosmantenimientodoccompra.ENTID_Codigo & "'") & vbNewLine
				sql &= "And VEHIC_Id = " & IIf(x_tran_vehiculosmantenimientodoccompra.VEHIC_Id = 0, "Null", x_tran_vehiculosmantenimientodoccompra.VEHIC_Id.ToString()) & vbNewLine
				sql &= "And VMAN_Item = " & IIf(x_tran_vehiculosmantenimientodoccompra.VMAN_Item = 0, "Null", x_tran_vehiculosmantenimientodoccompra.VMAN_Item.ToString()) & vbNewLine
				sql &= "And VMDCO_Numero = " & IIf(x_tran_vehiculosmantenimientodoccompra.VMDCO_Numero = 0, "Null", x_tran_vehiculosmantenimientodoccompra.VMDCO_Numero.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Transportes.TRAN_VehiculosMantenimientoDocCompra" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_VehiculosMantenimientoDocCompra ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_VehiculosMantenimientoDocCompra ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETRAN_VehiculosMantenimientoDocCompra)(m_formatofecha) 
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

