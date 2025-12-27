Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlTypes

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DVENT_DocsVentaDetalle

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "VENT_DocsVentaDetalle"
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
	
	Public Function VENT_DOCVDSS_Todos(ByRef listEVENT_DocsVentaDetalle As List(Of EVENT_DocsVentaDetalle)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_DocsVentaDetalle())
					While reader.Read()
						Dim e_vent_docsventadetalle As New EVENT_DocsVentaDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_vent_docsventadetalle)
						e_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
						listEVENT_DocsVentaDetalle.Add(e_vent_docsventadetalle)
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
	Public Function VENT_DOCVDSS_Todos(ByRef listEVENT_DocsVentaDetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_DocsVentaDetalle())
					While reader.Read()
						Dim e_vent_docsventadetalle As New EVENT_DocsVentaDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_vent_docsventadetalle)
						e_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
						listEVENT_DocsVentaDetalle.Add(e_vent_docsventadetalle)
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
	Public Function VENT_DOCVDSS_Todos(ByRef listEVENT_DocsVentaDetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_DocsVentaDetalle())
					While reader.Read()
						Dim e_vent_docsventadetalle As New EVENT_DocsVentaDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_vent_docsventadetalle)
						e_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
						listEVENT_DocsVentaDetalle.Add(e_vent_docsventadetalle)
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
	Public Function VENT_DOCVDSS_Todos(ByRef listEVENT_DocsVentaDetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_DocsVentaDetalle())
					While reader.Read()
						Dim e_vent_docsventadetalle As New EVENT_DocsVentaDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_vent_docsventadetalle)
						e_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
						listEVENT_DocsVentaDetalle.Add(e_vent_docsventadetalle)
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
	Public Function VENT_DOCVDSS_Todos(ByRef listEVENT_DocsVentaDetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_docve_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_docve_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_DocsVentaDetalle())
					While reader.Read()
						Dim e_vent_docsventadetalle As New EVENT_DocsVentaDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_vent_docsventadetalle)
						e_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
						listEVENT_DocsVentaDetalle.Add(e_vent_docsventadetalle)
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
	Public Function VENT_DOCVDSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

        Public Function VENT_DOCVDSS_TodosP(ByRef listEVENT_DocsVentaDetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAllP(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EVENT_DocsVentaDetalle())
					While reader.Read()
						Dim e_vent_docsventadetalle As New EVENT_DocsVentaDetalle()
						_utilitarios.ACCargarEsquemas(reader, e_vent_docsventadetalle)
						e_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
						listEVENT_DocsVentaDetalle.Add(e_vent_docsventadetalle)
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


	Public Function VENT_DOCVDSS_UnReg(ByRef x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_docve_codigo As String, ByVal x_docvd_item As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_docve_codigo, x_docvd_item), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_vent_docsventadetalle)
					x_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSS_UnReg(ByRef x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_vent_docsventadetalle)
					x_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSS_UnReg(ByRef x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_vent_docsventadetalle)
					x_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSI_UnReg(ByRef x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_vent_docsventadetalle, x_usuario), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSI_UnReg(ByRef x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_vent_docsventadetalle, x_usuario, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSI_UnReg(ByRef x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Dim m_filas As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_vent_docsventadetalle, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			m_filas = DAEnterprise.ExecuteNonQuery()
			Return m_filas
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSU_UnReg(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_docsventadetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSU_UnReg(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_docsventadetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSU_UnReg(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_docsventadetalle, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSU_UnReg(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_docsventadetalle, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
    End Function
    Public Function VENT_DOCVDSU_UnReg(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String,
                                       ByVal x_cant As Decimal, ByVal x_almacen As Boolean) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_vent_docsventadetalle, x_usuario, x_cant, x_almacen), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	Public Function VENT_DOCVDSU_UnReg(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_docsventadetalle, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSU_UnReg(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_vent_docsventadetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSD_UnReg(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_vent_docsventadetalle), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function
	Public Function VENT_DOCVDSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Ventas.VENT_DocsVentaDetalle" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Ventas.VENT_DocsVentaDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EVENT_DocsVentaDetalle)(m_formatofecha)
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
				sql &= " FROM Ventas.VENT_DocsVentaDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EVENT_DocsVentaDetalle)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EVENT_DocsVentaDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


           Private Function getSelectAllP(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EVENT_DocsVentaDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)
                sql &= "and (Art.LINEA_Codigo like '100%' or Art.LINEA_Codigo like '0401' or Art.LINEA_Codigo like '0403') "

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EVENT_DocsVentaDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_docve_codigo As String) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Ventas.VENT_DocsVentaDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "DOCVE_Codigo = " + IIf(IsNothing(x_docve_codigo), "Null", "'" & x_docve_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_docve_codigo As String, ByVal x_docvd_item As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Ventas.VENT_DocsVentaDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "DOCVE_Codigo = " + IIf(IsNothing(x_docve_codigo), "Null", "'" & x_docve_codigo & "'") & vbNewLine
				sql &= " AND DOCVD_Item = " + x_docvd_item.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_docsventadetalle.DOCVD_UsrCrea = x_usuario
				x_vent_docsventadetalle.DOCVD_FecCrea = _fecha
                

				Dim _insert As New ACFramework.ACGenerador(Of EVENT_DocsVentaDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_vent_docsventadetalle, x_vent_docsventadetalle.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_docsventadetalle.DOCVD_UsrCrea = x_usuario
				x_vent_docsventadetalle.DOCVD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EVENT_DocsVentaDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_vent_docsventadetalle, x_vent_docsventadetalle.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getInsert(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_docsventadetalle.DOCVD_UsrCrea = x_usuario
				x_vent_docsventadetalle.DOCVD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EVENT_DocsVentaDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_vent_docsventadetalle, x_vent_docsventadetalle.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_docsventadetalle.DOCVD_UsrMod = x_usuario
				x_vent_docsventadetalle.DOCVD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_DocsVentaDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCVE_Codigo", New ACWhere(x_VENT_DocsVentaDetalle.DOCVE_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("DOCVD_Item", New ACWhere(x_VENT_DocsVentaDetalle.DOCVD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_vent_docsventadetalle, _where, x_vent_docsventadetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_docsventadetalle.DOCVD_UsrMod = x_usuario
				x_vent_docsventadetalle.DOCVD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_DocsVentaDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCVE_Codigo", New ACWhere(x_VENT_DocsVentaDetalle.DOCVE_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("DOCVD_Item", New ACWhere(x_VENT_DocsVentaDetalle.DOCVD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_vent_docsventadetalle, _where, x_vent_docsventadetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_docsventadetalle.DOCVD_UsrMod = x_usuario
				x_vent_docsventadetalle.DOCVD_FecMod = _fecha
    

				Dim _update As New ACFramework.ACGenerador(Of EVENT_DocsVentaDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_vent_docsventadetalle, x_where, x_vent_docsventadetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_docsventadetalle.DOCVD_UsrMod = x_usuario
				x_vent_docsventadetalle.DOCVD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_DocsVentaDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCVE_Codigo", New ACWhere(x_VENT_DocsVentaDetalle.DOCVE_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("DOCVD_Item", New ACWhere(x_VENT_DocsVentaDetalle.DOCVD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_vent_docsventadetalle, _where, x_vent_docsventadetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
    End Function
    Private Function getUpdate(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_usuario As String,
                              ByVal x_cant As Decimal, ByVal x_almacen As Boolean) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()

            x_vent_docsventadetalle.DOCVD_UsrMod = x_usuario
            x_vent_docsventadetalle.DOCVD_FecMod = _fecha

            'Dim _update As New ACFramework.ACGenerador(Of EDIST_OrdenesDetalle)(_fecha, m_formatofecha)
            'Dim _where As New Hashtable()
            '_where.Add("ORDEN_Codigo", New ACWhere(x_dist_ordenesdetalle.ORDEN_Codigo, ACWhere.TipoWhere.Igual))
            '_where.Add("ORDET_Item", New ACWhere(x_dist_ordenesdetalle.ORDET_Item, ACWhere.TipoWhere.Igual))
            'sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenesdetalle, _where, x_dist_ordenesdetalle.Hash, New String() {})

            sql = " UPDATE Ventas.VENT_DocsVentaDetalle" & vbNewLine
            sql &= " SET DOCVD_CantidadEntregada = " & IIf(IsNothing(x_vent_docsventadetalle.DOCVD_CantidadEntregada), "Null", "'" & x_vent_docsventadetalle.DOCVD_CantidadEntregada & "'") & vbNewLine
            sql &= " , DOCVD_UsrMod= " & IIf(IsNothing(x_vent_docsventadetalle.DOCVD_UsrMod), "Null", "'" & x_vent_docsventadetalle.DOCVD_UsrMod & "'") & vbNewLine
            sql &= " , DOCVD_FecMod= " & IIf(IsNothing(x_vent_docsventadetalle.DOCVD_FecMod), "Null", "'" & Convert.ToDateTime(x_vent_docsventadetalle.DOCVD_FecMod).ToString("yyyy-MM-dd hh:mm:ss") & "'") & vbNewLine

            sql &= " , DOCVD_Motivo= " & IIf(IsNothing(x_vent_docsventadetalle.DOCVD_Motivo), "Null", "'" & x_vent_docsventadetalle.DOCVD_Motivo & "'") & vbNewLine

            sql &= " WHERE "
            sql &= "    DOCVE_Codigo = " & IIf(IsNothing(x_vent_docsventadetalle.DOCVE_Codigo), "Null", "'" & x_vent_docsventadetalle.DOCVE_Codigo & "'") & vbNewLine
            sql &= "And DOCVD_Item = " & IIf(x_vent_docsventadetalle.DOCVD_Item = 0, "Null", x_vent_docsventadetalle.DOCVD_Item.ToString()) & vbNewLine


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
		Private Function getUpdate(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_docsventadetalle.DOCVD_UsrMod = x_usuario
				x_vent_docsventadetalle.DOCVD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_DocsVentaDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_vent_docsventadetalle, x_where, x_vent_docsventadetalle.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getUpdate(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_vent_docsventadetalle.DOCVD_UsrMod = x_usuario
				x_vent_docsventadetalle.DOCVD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EVENT_DocsVentaDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_vent_docsventadetalle, x_where, x_vent_docsventadetalle.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_vent_docsventadetalle As EVENT_DocsVentaDetalle) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Ventas.VENT_DocsVentaDetalle" & vbNewLine
				sql &= " WHERE "
				sql &= "    DOCVE_Codigo = " & IIf(IsNothing(x_vent_docsventadetalle.DOCVE_Codigo), "Null", "'" & x_vent_docsventadetalle.DOCVE_Codigo & "'") & vbNewLine
				sql &= "And DOCVD_Item = " & IIf(x_vent_docsventadetalle.DOCVD_Item = 0, "Null", x_vent_docsventadetalle.DOCVD_Item.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Ventas.VENT_DocsVentaDetalle" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EVENT_DocsVentaDetalle)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Ventas.VENT_DocsVentaDetalle ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Ventas.VENT_DocsVentaDetalle ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EVENT_DocsVentaDetalle)(m_formatofecha) 
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

