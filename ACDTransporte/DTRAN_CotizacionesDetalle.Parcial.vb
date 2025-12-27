Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_CotizacionesDetalle

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "TRAN_CotizacionesDetalle"
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
	
	Public Function TRAN_COTDTSS_Todos(ByRef listETRAN_CotizacionesDetalle As List(Of ETRAN_CotizacionesDetalle)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_CotizacionesDetalle())
					While reader.Read()
						Dim e_tran_cotizacionesdetalle As New ETRAN_CotizacionesDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_tran_cotizacionesdetalle)
						e_tran_cotizacionesdetalle.Instanciar(ACEInstancia.Consulta)
						listETRAN_CotizacionesDetalle.Add(e_tran_cotizacionesdetalle)
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
	Public Function TRAN_COTDTSS_Todos(ByRef listETRAN_CotizacionesDetalle As List(Of ETRAN_CotizacionesDetalle), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_CotizacionesDetalle())
					While reader.Read()
						Dim e_tran_cotizacionesdetalle As New ETRAN_CotizacionesDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_tran_cotizacionesdetalle)
						e_tran_cotizacionesdetalle.Instanciar(ACEInstancia.Consulta)
						listETRAN_CotizacionesDetalle.Add(e_tran_cotizacionesdetalle)
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
	Public Function TRAN_COTDTSS_Todos(ByRef listETRAN_CotizacionesDetalle As List(Of ETRAN_CotizacionesDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_CotizacionesDetalle())
					While reader.Read()
						Dim e_tran_cotizacionesdetalle As New ETRAN_CotizacionesDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_tran_cotizacionesdetalle)
						e_tran_cotizacionesdetalle.Instanciar(ACEInstancia.Consulta)
						listETRAN_CotizacionesDetalle.Add(e_tran_cotizacionesdetalle)
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
	Public Function TRAN_COTDTSS_Todos(ByRef listETRAN_CotizacionesDetalle As List(Of ETRAN_CotizacionesDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_CotizacionesDetalle())
					While reader.Read()
						Dim e_tran_cotizacionesdetalle As New ETRAN_CotizacionesDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_tran_cotizacionesdetalle)
						e_tran_cotizacionesdetalle.Instanciar(ACEInstancia.Consulta)
						listETRAN_CotizacionesDetalle.Add(e_tran_cotizacionesdetalle)
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
	Public Function TRAN_COTDTSS_Todos(ByRef listETRAN_CotizacionesDetalle As List(Of ETRAN_CotizacionesDetalle), ByVal x_cotiz_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_cotiz_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New ETRAN_CotizacionesDetalle())
					While reader.Read()
						Dim e_tran_cotizacionesdetalle As New ETRAN_CotizacionesDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_tran_cotizacionesdetalle)
						e_tran_cotizacionesdetalle.Instanciar(ACEInstancia.Consulta)
						listETRAN_CotizacionesDetalle.Add(e_tran_cotizacionesdetalle)
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
	Public Function TRAN_COTDTSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSS_UnReg(ByRef x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_cotiz_codigo As String, ByVal x_cotdt_item As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_cotiz_codigo, x_cotdt_item), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_tran_cotizacionesdetalle)
					x_tran_cotizacionesdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSS_UnReg(ByRef x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_tran_cotizacionesdetalle)
					x_tran_cotizacionesdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSS_UnReg(ByRef x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_tran_cotizacionesdetalle)
					x_tran_cotizacionesdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSI_UnReg(ByRef x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_cotizacionesdetalle, x_usuario), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSI_UnReg(ByRef x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_cotizacionesdetalle, x_usuario, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSI_UnReg(ByRef x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_tran_cotizacionesdetalle, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSU_UnReg(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_cotizacionesdetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSU_UnReg(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_cotizacionesdetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSU_UnReg(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_cotizacionesdetalle, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSU_UnReg(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_cotizacionesdetalle, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSU_UnReg(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_cotizacionesdetalle, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSU_UnReg(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_tran_cotizacionesdetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSD_UnReg(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_tran_cotizacionesdetalle), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function TRAN_COTDTSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Transportes.TRAN_CotizacionesDetalle" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Transportes.TRAN_CotizacionesDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETRAN_CotizacionesDetalle)(m_formatofecha)
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
				sql &= " FROM Transportes.TRAN_CotizacionesDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of ETRAN_CotizacionesDetalle)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETRAN_CotizacionesDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of ETRAN_CotizacionesDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_cotiz_codigo As String) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Transportes.TRAN_CotizacionesDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "COTIZ_Codigo = " + IIf(IsNothing(x_cotiz_codigo), "Null", "'" & x_cotiz_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_cotiz_codigo As String, ByVal x_cotdt_item As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Transportes.TRAN_CotizacionesDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "COTIZ_Codigo = " + IIf(IsNothing(x_cotiz_codigo), "Null", "'" & x_cotiz_codigo & "'") & vbNewLine
				sql &= " AND COTDT_Item = " + x_cotdt_item.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_cotizacionesdetalle.COTDT_UsrCrea = x_usuario
				x_tran_cotizacionesdetalle.COTDT_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_CotizacionesDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_tran_cotizacionesdetalle, x_tran_cotizacionesdetalle.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_cotizacionesdetalle.COTDT_UsrCrea = x_usuario
				x_tran_cotizacionesdetalle.COTDT_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_CotizacionesDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_cotizacionesdetalle, x_tran_cotizacionesdetalle.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_cotizacionesdetalle.COTDT_UsrCrea = x_usuario
				x_tran_cotizacionesdetalle.COTDT_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of ETRAN_CotizacionesDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_cotizacionesdetalle, x_tran_cotizacionesdetalle.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_cotizacionesdetalle.COTDT_UsrMod = x_usuario
				x_tran_cotizacionesdetalle.COTDT_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_CotizacionesDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("COTIZ_Codigo", New ACWhere(x_TRAN_CotizacionesDetalle.COTIZ_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("COTDT_Item", New ACWhere(x_TRAN_CotizacionesDetalle.COTDT_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_tran_cotizacionesdetalle, _where, x_tran_cotizacionesdetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_cotizacionesdetalle.COTDT_UsrMod = x_usuario
				x_tran_cotizacionesdetalle.COTDT_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_CotizacionesDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("COTIZ_Codigo", New ACWhere(x_TRAN_CotizacionesDetalle.COTIZ_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("COTDT_Item", New ACWhere(x_TRAN_CotizacionesDetalle.COTDT_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_cotizacionesdetalle, _where, x_tran_cotizacionesdetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_cotizacionesdetalle.COTDT_UsrMod = x_usuario
				x_tran_cotizacionesdetalle.COTDT_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_CotizacionesDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_tran_cotizacionesdetalle, x_where, x_tran_cotizacionesdetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_cotizacionesdetalle.COTDT_UsrMod = x_usuario
				x_tran_cotizacionesdetalle.COTDT_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_CotizacionesDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("COTIZ_Codigo", New ACWhere(x_TRAN_CotizacionesDetalle.COTIZ_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("COTDT_Item", New ACWhere(x_TRAN_CotizacionesDetalle.COTDT_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_cotizacionesdetalle, _where, x_tran_cotizacionesdetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_cotizacionesdetalle.COTDT_UsrMod = x_usuario
				x_tran_cotizacionesdetalle.COTDT_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_CotizacionesDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_cotizacionesdetalle, x_where, x_tran_cotizacionesdetalle.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_tran_cotizacionesdetalle.COTDT_UsrMod = x_usuario
				x_tran_cotizacionesdetalle.COTDT_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of ETRAN_CotizacionesDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_tran_cotizacionesdetalle, x_where, x_tran_cotizacionesdetalle.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_tran_cotizacionesdetalle As ETRAN_CotizacionesDetalle) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Transportes.TRAN_CotizacionesDetalle" & vbNewLine
				sql &= " WHERE "
				sql &= "    COTIZ_Codigo = " & IIf(IsNothing(x_tran_cotizacionesdetalle.COTIZ_Codigo), "Null", "'" & x_tran_cotizacionesdetalle.COTIZ_Codigo & "'") & vbNewLine
				sql &= "And COTDT_Item = " & IIf(x_tran_cotizacionesdetalle.COTDT_Item = 0, "Null", x_tran_cotizacionesdetalle.COTDT_Item.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Transportes.TRAN_CotizacionesDetalle" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETRAN_CotizacionesDetalle)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_CotizacionesDetalle ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_CotizacionesDetalle ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of ETRAN_CotizacionesDetalle)(m_formatofecha) 
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

