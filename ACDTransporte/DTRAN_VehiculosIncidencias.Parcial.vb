Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_VehiculosIncidencias

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "TRAN_VehiculosIncidencias"
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
	
	Public Function TRAN_INCVESS_Todos(ByRef listETRAN_VehiculosIncidencias As List(Of ETRAN_VehiculosIncidencias)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosIncidencias())
					While reader.Read()
						Dim e_tran_vehiculosincidencias As New ETRAN_VehiculosIncidencias()
						_utilitarios.ACCargarEsquemas(reader, e_tran_vehiculosincidencias)
						e_tran_vehiculosincidencias.Instanciar(ACEInstancia.Consulta)
						listETRAN_VehiculosIncidencias.Add(e_tran_vehiculosincidencias)
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
	Public Function TRAN_INCVESS_Todos(ByRef listETRAN_VehiculosIncidencias As List(Of ETRAN_VehiculosIncidencias), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosIncidencias())
					While reader.Read()
						Dim e_tran_vehiculosincidencias As New ETRAN_VehiculosIncidencias()
						_utilitarios.ACCargarEsquemas(reader, e_tran_vehiculosincidencias)
						e_tran_vehiculosincidencias.Instanciar(ACEInstancia.Consulta)
						listETRAN_VehiculosIncidencias.Add(e_tran_vehiculosincidencias)
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
	Public Function TRAN_INCVESS_Todos(ByRef listETRAN_VehiculosIncidencias As List(Of ETRAN_VehiculosIncidencias), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosIncidencias())
					While reader.Read()
						Dim e_tran_vehiculosincidencias As New ETRAN_VehiculosIncidencias()
						_utilitarios.ACCargarEsquemas(reader, e_tran_vehiculosincidencias)
						e_tran_vehiculosincidencias.Instanciar(ACEInstancia.Consulta)
						listETRAN_VehiculosIncidencias.Add(e_tran_vehiculosincidencias)
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
	Public Function TRAN_INCVESS_Todos(ByRef listETRAN_VehiculosIncidencias As List(Of ETRAN_VehiculosIncidencias), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosIncidencias())
					While reader.Read()
						Dim e_tran_vehiculosincidencias As New ETRAN_VehiculosIncidencias()
						_utilitarios.ACCargarEsquemas(reader, e_tran_vehiculosincidencias)
						e_tran_vehiculosincidencias.Instanciar(ACEInstancia.Consulta)
						listETRAN_VehiculosIncidencias.Add(e_tran_vehiculosincidencias)
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
	Public Function TRAN_INCVESS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESS_UnReg(ByRef x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_incve_id As Long) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_incve_id), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_tran_vehiculosincidencias)
					x_tran_vehiculosincidencias.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESS_UnReg(ByRef x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_tran_vehiculosincidencias)
					x_tran_vehiculosincidencias.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESS_UnReg(ByRef x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_tran_vehiculosincidencias)
					x_tran_vehiculosincidencias.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESI_UnReg(ByRef x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_vehiculosincidencias, x_usuario), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESI_UnReg(ByRef x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_vehiculosincidencias, x_usuario, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESI_UnReg(ByRef x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_vehiculosincidencias, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESU_UnReg(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosincidencias, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESU_UnReg(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosincidencias, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESU_UnReg(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosincidencias, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESU_UnReg(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosincidencias, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESU_UnReg(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosincidencias, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESU_UnReg(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_vehiculosincidencias, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESD_UnReg(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_tran_vehiculosincidencias), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_INCVESD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Transportes.TRAN_VehiculosIncidencias" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Transportes.TRAN_VehiculosIncidencias" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETRAN_VehiculosIncidencias)(m_formatofecha)
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
				sql &= " FROM Transportes.TRAN_VehiculosIncidencias" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETRAN_VehiculosIncidencias)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETRAN_VehiculosIncidencias)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETRAN_VehiculosIncidencias)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_incve_id As Long) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Transportes.TRAN_VehiculosIncidencias" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "INCVE_Id = " + x_incve_id.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosincidencias.INCVE_UsrCrea = x_usuario
				x_tran_vehiculosincidencias.INCVE_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_VehiculosIncidencias)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_tran_vehiculosincidencias, x_tran_vehiculosincidencias.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosincidencias.INCVE_UsrCrea = x_usuario
				x_tran_vehiculosincidencias.INCVE_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_VehiculosIncidencias)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_vehiculosincidencias, x_tran_vehiculosincidencias.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosincidencias.INCVE_UsrCrea = x_usuario
				x_tran_vehiculosincidencias.INCVE_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_VehiculosIncidencias)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_vehiculosincidencias, x_tran_vehiculosincidencias.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosincidencias.INCVE_UsrMod = x_usuario
				x_tran_vehiculosincidencias.INCVE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosIncidencias)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("INCVE_Id", New ACWhere(x_TRAN_VehiculosIncidencias.INCVE_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_tran_vehiculosincidencias, _where, x_tran_vehiculosincidencias.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosincidencias.INCVE_UsrMod = x_usuario
				x_tran_vehiculosincidencias.INCVE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosIncidencias)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("INCVE_Id", New ACWhere(x_TRAN_VehiculosIncidencias.INCVE_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_vehiculosincidencias, _where, x_tran_vehiculosincidencias.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosincidencias.INCVE_UsrMod = x_usuario
				x_tran_vehiculosincidencias.INCVE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosIncidencias)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_tran_vehiculosincidencias, x_where, x_tran_vehiculosincidencias.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosincidencias.INCVE_UsrMod = x_usuario
				x_tran_vehiculosincidencias.INCVE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosIncidencias)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("INCVE_Id", New ACWhere(x_TRAN_VehiculosIncidencias.INCVE_Id, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_vehiculosincidencias, _where, x_tran_vehiculosincidencias.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosincidencias.INCVE_UsrMod = x_usuario
				x_tran_vehiculosincidencias.INCVE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosIncidencias)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_vehiculosincidencias, x_where, x_tran_vehiculosincidencias.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_vehiculosincidencias.INCVE_UsrMod = x_usuario
				x_tran_vehiculosincidencias.INCVE_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_VehiculosIncidencias)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_tran_vehiculosincidencias, x_where, x_tran_vehiculosincidencias.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_tran_vehiculosincidencias As ETRAN_VehiculosIncidencias) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Transportes.TRAN_VehiculosIncidencias" & vbNewLine
				sql &= " WHERE "
				sql &= "    INCVE_Id = " & IIf(x_tran_vehiculosincidencias.INCVE_Id = 0, "Null", x_tran_vehiculosincidencias.INCVE_Id.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Transportes.TRAN_VehiculosIncidencias" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETRAN_VehiculosIncidencias)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_VehiculosIncidencias ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_VehiculosIncidencias ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETRAN_VehiculosIncidencias)(m_formatofecha) 
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

