Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DABAS_DocsCompraDetalle

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "ABAS_DocsCompraDetalle"
		End Get
	End Property
	Public ReadOnly Property Esquema() As String
		Get
			Return "Logistica"
		End Get
	End Property

#End Region

#Region " Constructores "
	
	Public Sub New()
		m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
	End Sub

#End Region

#Region " Procedimientos Almacenados "
	
	Public Function ABAS_DOCCDSS_Todos(ByRef x_listABAS_DocsCompraDetalle As List(Of EABAS_DocsCompraDetalle)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_DocsCompraDetalle())
					While reader.Read()
						Dim x_eabas_docscompradetalle As New EABAS_DocsCompraDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_docscompradetalle)
						x_eabas_docscompradetalle.Instanciar(ACEInstancia.Consulta)
						x_listABAS_DocsCompraDetalle.Add(x_eabas_docscompradetalle)
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

	Public Function ABAS_DOCCDSS_Todos(ByRef x_listABAS_DocsCompraDetalle As List(Of EABAS_DocsCompraDetalle), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_DocsCompraDetalle())
					While reader.Read()
						Dim x_eabas_docscompradetalle As New EABAS_DocsCompraDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_docscompradetalle)
						x_eabas_docscompradetalle.Instanciar(ACEInstancia.Consulta)
						x_listABAS_DocsCompraDetalle.Add(x_eabas_docscompradetalle)
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

	Public Function ABAS_DOCCDSS_Todos(ByRef x_listABAS_DocsCompraDetalle As List(Of EABAS_DocsCompraDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_DocsCompraDetalle())
					While reader.Read()
						Dim x_eabas_docscompradetalle As New EABAS_DocsCompraDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_docscompradetalle)
						x_eabas_docscompradetalle.Instanciar(ACEInstancia.Consulta)
						x_listABAS_DocsCompraDetalle.Add(x_eabas_docscompradetalle)
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

	Public Function ABAS_DOCCDSS_Todos(ByRef x_listABAS_DocsCompraDetalle As List(Of EABAS_DocsCompraDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_DocsCompraDetalle())
					While reader.Read()
						Dim x_eabas_docscompradetalle As New EABAS_DocsCompraDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_eabas_docscompradetalle)
						x_eabas_docscompradetalle.Instanciar(ACEInstancia.Consulta)
						x_listABAS_DocsCompraDetalle.Add(x_eabas_docscompradetalle)
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

	Public Function ABAS_DOCCDSS_Todos(ByRef x_eabas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_docco_codigo As String, ByVal x_entid_codigoproveedor As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_docco_codigo, x_entid_codigoproveedor), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_docscompradetalle)
					x_eabas_docscompradetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSS_UnReg(ByRef x_eabas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_docco_codigo As String, ByVal x_entid_codigoproveedor As String, ByVal x_doccd_item As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_docco_codigo, x_entid_codigoproveedor, x_doccd_item), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_docscompradetalle)
					x_eabas_docscompradetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSS_UnReg(ByRef x_eabas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_docscompradetalle)
					x_eabas_docscompradetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSS_UnReg(ByRef x_eabas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_eabas_docscompradetalle)
					x_eabas_docscompradetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSI_UnReg(ByRef x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_abas_docscompradetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSI_UnReg(ByRef x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_abas_docscompradetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSI_UnReg(ByRef x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_abas_docscompradetalle, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSU_UnReg(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_docscompradetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSU_UnReg(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_docscompradetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSU_UnReg(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_docscompradetalle, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSU_UnReg(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_docscompradetalle, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSU_UnReg(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_docscompradetalle, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSU_UnReg(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_abas_docscompradetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSD_UnReg(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_abas_docscompradetalle), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ABAS_DOCCDSD_UnReg(ByVal x_where As Hashtable) As Integer
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
				sql &= " FROM Logistica.ABAS_DocsCompraDetalle" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_DocsCompraDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_DocsCompraDetalle)(m_formatofecha)
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
				sql &= " FROM Logistica.ABAS_DocsCompraDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_DocsCompraDetalle)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_DocsCompraDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_DocsCompraDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_docco_codigo As String, ByVal x_entid_codigoproveedor As String) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.ABAS_DocsCompraDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "DOCCO_Codigo = " + IIf(IsNothing(x_docco_codigo), "Null", "'" & x_docco_codigo & "'") & vbNewLine
				sql &= " AND ENTID_CodigoProveedor = " + IIf(IsNothing(x_entid_codigoproveedor), "Null", "'" & x_entid_codigoproveedor & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_docco_codigo As String, ByVal x_entid_codigoproveedor As String, ByVal x_doccd_item As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.ABAS_DocsCompraDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "DOCCO_Codigo = " + IIf(IsNothing(x_docco_codigo), "Null", "'" & x_docco_codigo & "'") & vbNewLine
				sql &= " AND ENTID_CodigoProveedor = " + IIf(IsNothing(x_entid_codigoproveedor), "Null", "'" & x_entid_codigoproveedor & "'") & vbNewLine
				sql &= " AND DOCCD_Item = " + x_doccd_item.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_DocsCompraDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_DocsCompraDetalle)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_DocsCompraDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_docscompradetalle.DOCCD_UsrCrea = x_usuario
				x_abas_docscompradetalle.DOCCD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_DocsCompraDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_abas_docscompradetalle, x_abas_docscompradetalle.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_docscompradetalle.DOCCD_UsrCrea = x_usuario
				x_abas_docscompradetalle.DOCCD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_DocsCompraDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_abas_docscompradetalle, x_abas_docscompradetalle.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_docscompradetalle.DOCCD_UsrCrea = x_usuario
				x_abas_docscompradetalle.DOCCD_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_DocsCompraDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_abas_docscompradetalle, x_abas_docscompradetalle.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_docscompradetalle.DOCCD_UsrMod = x_usuario
				x_abas_docscompradetalle.DOCCD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_DocsCompraDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCCO_Codigo", New ACWhere(x_ABAS_DocsCompraDetalle.DOCCO_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_CodigoProveedor", New ACWhere(x_ABAS_DocsCompraDetalle.ENTID_CodigoProveedor, ACWhere.TipoWhere.Igual))
				_where.Add("DOCCD_Item", New ACWhere(x_ABAS_DocsCompraDetalle.DOCCD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_abas_docscompradetalle, _where, x_abas_docscompradetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_docscompradetalle.DOCCD_UsrMod = x_usuario
				x_abas_docscompradetalle.DOCCD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_DocsCompraDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCCO_Codigo", New ACWhere(x_ABAS_DocsCompraDetalle.DOCCO_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_CodigoProveedor", New ACWhere(x_ABAS_DocsCompraDetalle.ENTID_CodigoProveedor, ACWhere.TipoWhere.Igual))
				_where.Add("DOCCD_Item", New ACWhere(x_ABAS_DocsCompraDetalle.DOCCD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_abas_docscompradetalle, _where, x_abas_docscompradetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_docscompradetalle.DOCCD_UsrMod = x_usuario
				x_abas_docscompradetalle.DOCCD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_DocsCompraDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_abas_docscompradetalle, x_where, x_abas_docscompradetalle.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_docscompradetalle.DOCCD_UsrMod = x_usuario
				x_abas_docscompradetalle.DOCCD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_DocsCompraDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("DOCCO_Codigo", New ACWhere(x_ABAS_DocsCompraDetalle.DOCCO_Codigo, ACWhere.TipoWhere.Igual))
				_where.Add("ENTID_CodigoProveedor", New ACWhere(x_ABAS_DocsCompraDetalle.ENTID_CodigoProveedor, ACWhere.TipoWhere.Igual))
				_where.Add("DOCCD_Item", New ACWhere(x_ABAS_DocsCompraDetalle.DOCCD_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_abas_docscompradetalle, _where, x_abas_docscompradetalle.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_docscompradetalle.DOCCD_UsrMod = x_usuario
				x_abas_docscompradetalle.DOCCD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_DocsCompraDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_abas_docscompradetalle, x_where, x_abas_docscompradetalle.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_abas_docscompradetalle.DOCCD_UsrMod = x_usuario
				x_abas_docscompradetalle.DOCCD_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_DocsCompraDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_abas_docscompradetalle, x_where, x_abas_docscompradetalle.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_abas_docscompradetalle As EABAS_DocsCompraDetalle) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_DocsCompraDetalle" & vbNewLine
				sql &= " WHERE "
				sql &= "    DOCCO_Codigo = " & IIf(IsNothing(x_abas_docscompradetalle.DOCCO_Codigo), "Null", "'" & x_abas_docscompradetalle.DOCCO_Codigo & "'") & vbNewLine
				sql &= "And ENTID_CodigoProveedor = " & IIf(IsNothing(x_abas_docscompradetalle.ENTID_CodigoProveedor), "Null", "'" & x_abas_docscompradetalle.ENTID_CodigoProveedor & "'") & vbNewLine
				sql &= "And DOCCD_Item = " & IIf(x_abas_docscompradetalle.DOCCD_Item = 0, "Null", x_abas_docscompradetalle.DOCCD_Item.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_DocsCompraDetalle" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_DocsCompraDetalle)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_DocsCompraDetalle ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_DocsCompraDetalle ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_DocsCompraDetalle)(m_formatofecha) 
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

