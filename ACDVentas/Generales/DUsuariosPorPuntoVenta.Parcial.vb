Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DUsuariosPorPuntoVenta

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "UsuariosPorPuntoVenta"
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
	
	Public Function USUARSS_Todos(ByRef listEUsuariosPorPuntoVenta As List(Of EUsuariosPorPuntoVenta)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EUsuariosPorPuntoVenta())
					While reader.Read()
						Dim e_usuariosporpuntoventa As New EUsuariosPorPuntoVenta()
						_utilitarios.ACCargarEsquemas(reader, e_usuariosporpuntoventa)
						e_usuariosporpuntoventa.Instanciar(ACEInstancia.Consulta)
						listEUsuariosPorPuntoVenta.Add(e_usuariosporpuntoventa)
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
	Public Function USUARSS_Todos(ByRef listEUsuariosPorPuntoVenta As List(Of EUsuariosPorPuntoVenta), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EUsuariosPorPuntoVenta())
					While reader.Read()
						Dim e_usuariosporpuntoventa As New EUsuariosPorPuntoVenta()
						_utilitarios.ACCargarEsquemas(reader, e_usuariosporpuntoventa)
						e_usuariosporpuntoventa.Instanciar(ACEInstancia.Consulta)
						listEUsuariosPorPuntoVenta.Add(e_usuariosporpuntoventa)
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
	Public Function USUARSS_Todos(ByRef listEUsuariosPorPuntoVenta As List(Of EUsuariosPorPuntoVenta), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EUsuariosPorPuntoVenta())
					While reader.Read()
						Dim e_usuariosporpuntoventa As New EUsuariosPorPuntoVenta()
						_utilitarios.ACCargarEsquemas(reader, e_usuariosporpuntoventa)
						e_usuariosporpuntoventa.Instanciar(ACEInstancia.Consulta)
						listEUsuariosPorPuntoVenta.Add(e_usuariosporpuntoventa)
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
	Public Function USUARSS_Todos(ByRef listEUsuariosPorPuntoVenta As List(Of EUsuariosPorPuntoVenta), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EUsuariosPorPuntoVenta())
					While reader.Read()
						Dim e_usuariosporpuntoventa As New EUsuariosPorPuntoVenta()
						_utilitarios.ACCargarEsquemas(reader, e_usuariosporpuntoventa)
						e_usuariosporpuntoventa.Instanciar(ACEInstancia.Consulta)
						listEUsuariosPorPuntoVenta.Add(e_usuariosporpuntoventa)
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
	Public Function USUARSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function USUARSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function USUARSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function USUARSI_UnReg(ByRef x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_usuario As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_usuariosporpuntoventa, x_usuario), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function USUARSI_UnReg(ByRef x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_usuariosporpuntoventa, x_usuario, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function USUARSI_UnReg(ByRef x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_usuariosporpuntoventa, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function USUARSD_UnReg(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_usuariosporpuntoventa), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function USUARSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM dbo.UsuariosPorPuntoVenta" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		     Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM dbo.UsuariosPorPuntoVenta" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EUsuariosPorPuntoVenta)(m_formatofecha)
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
				sql &= " FROM dbo.UsuariosPorPuntoVenta" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EUsuariosPorPuntoVenta)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EUsuariosPorPuntoVenta)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EUsuariosPorPuntoVenta)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_pvent_id As Long, ByVal x_entid_codigo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short) As String
			Dim sql As String = ""
			Try

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_usuariosporpuntoventa.USPTA_UsrCrea = x_usuario
				x_usuariosporpuntoventa.USPTA_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EUsuariosPorPuntoVenta)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_usuariosporpuntoventa, x_usuariosporpuntoventa.Hash, New String() {})


			Return sql
			Debug.WriteLine(sql)
		Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_usuariosporpuntoventa.USPTA_UsrCrea = x_usuario
				x_usuariosporpuntoventa.USPTA_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EUsuariosPorPuntoVenta)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_usuariosporpuntoventa, x_usuariosporpuntoventa.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_usuariosporpuntoventa.USPTA_UsrCrea = x_usuario
				x_usuariosporpuntoventa.USPTA_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EUsuariosPorPuntoVenta)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_usuariosporpuntoventa, x_usuariosporpuntoventa.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_usuariosporpuntoventa As EUsuariosPorPuntoVenta) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM dbo.UsuariosPorPuntoVenta" & vbNewLine
				sql &= " WHERE "
				sql &= "    PVENT_Id = " & IIf(x_usuariosporpuntoventa.PVENT_Id = 0, "Null", x_usuariosporpuntoventa.PVENT_Id.ToString()) & vbNewLine
				sql &= "And ENTID_Codigo = " & IIf(IsNothing(x_usuariosporpuntoventa.ENTID_Codigo), "Null", "'" & x_usuariosporpuntoventa.ENTID_Codigo & "'") & vbNewLine
				sql &= "And ZONAS_Codigo = " & IIf(IsNothing(x_usuariosporpuntoventa.ZONAS_Codigo), "Null", "'" & x_usuariosporpuntoventa.ZONAS_Codigo & "'") & vbNewLine
				sql &= "And SUCUR_Id = " & IIf(x_usuariosporpuntoventa.SUCUR_Id = 0, "Null", x_usuariosporpuntoventa.SUCUR_Id.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM dbo.UsuariosPorPuntoVenta" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EUsuariosPorPuntoVenta)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From dbo.UsuariosPorPuntoVenta ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From dbo.UsuariosPorPuntoVenta ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EUsuariosPorPuntoVenta)(m_formatofecha) 
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

