
Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DABAS_PedidoTransformacionDetalle


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	


#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
	
#End Region
End Class

Partial Public Class DABAS_PedidoTransformacionDetalle

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "ABAS_PedidoTransformacionDetalle"
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
	
	Public Function DIST_PedidoTransDeta_Todos(ByRef x_listDIST_PedidoDetalle As List(Of EABAS_PedidoTransformacionDetalle)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_PedidoTransformacionDetalle())
					While reader.Read()
						Dim x_edist_pedidostransdetalle As New EABAS_PedidoTransformacionDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_edist_pedidostransdetalle)
						x_edist_pedidostransdetalle.Instanciar(ACEInstancia.Consulta)
						x_listDIST_PedidoDetalle.Add(x_edist_pedidostransdetalle)
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

	Public Function DIST_PedidoTransDeta_Todos(ByRef x_listDIST_PedidoDetalle As List(Of EABAS_PedidoTransformacionDetalle), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_PedidoTransformacionDetalle())
					While reader.Read()
						Dim x_edist_pedidostransdetalle As New EABAS_PedidoTransformacionDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_edist_pedidostransdetalle)
						x_edist_pedidostransdetalle.Instanciar(ACEInstancia.Consulta)
						x_listDIST_PedidoDetalle.Add(x_edist_pedidostransdetalle)
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

	Public Function DIST_PedidoTransDeta_Todos(ByRef x_listDIST_PedidoDetalle As List(Of EABAS_PedidoTransformacionDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_PedidoTransformacionDetalle())
					While reader.Read()
						Dim x_edist_pedidostransdetalle As New EABAS_PedidoTransformacionDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_edist_pedidostransdetalle)
						x_edist_pedidostransdetalle.Instanciar(ACEInstancia.Consulta)
						x_listDIST_PedidoDetalle.Add(x_edist_pedidostransdetalle)
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

	Public Function DIST_PedidoTransDeta_Todos(ByRef x_listDIST_PedidoDetalle As List(Of EABAS_PedidoTransformacionDetalle), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_PedidoTransformacionDetalle())
					While reader.Read()
						Dim x_edist_pedidostransdetalle As New EABAS_PedidoTransformacionDetalle()
						_utilitarios.ACCargarEsquemas(reader, x_edist_pedidostransdetalle)
						x_edist_pedidostransdetalle.Instanciar(ACEInstancia.Consulta)
						x_listDIST_PedidoDetalle.Add(x_edist_pedidostransdetalle)
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

	Public Function DIST_PedidoTransDeta_Todos(ByRef x_edist_pedidostransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_pedidotrans_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_pedidotrans_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_pedidostransdetalle)
					x_edist_pedidostransdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PedidoTransDeta_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PedidoTransDeta_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PedidoTransDeta_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDet_UnReg(ByRef x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_orden_codigo As String, ByVal x_ordet_item As Short) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_orden_codigo, x_ordet_item), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_pedidotransdetalle)
					x_edist_pedidotransdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDet_UnReg(ByRef x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_pedidotransdetalle)
					x_edist_pedidotransdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDet_UnReg(ByRef x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_pedidotransdetalle)
					x_edist_pedidotransdetalle.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSI_UnReg(ByRef x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_edist_pedidotransdetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSI_UnReg(ByRef x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_edist_pedidotransdetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSI_UnReg(ByRef x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_edist_pedidotransdetalle, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSU_UnReg(ByVal x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_pedidotransdetalle, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSU_UnReg(ByVal x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_pedidotransdetalle, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSU_UnReg(ByVal x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_pedidotransdetalle, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSU_UnReg(ByVal x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_pedidotransdetalle, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSU_UnReg(ByVal x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_pedidotransdetalle, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSU_UnReg(ByVal x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_pedidotransdetalle, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSD_UnReg(ByVal x_edist_pedidotransdetalle As EABAS_PedidoTransformacionDetalle) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_edist_pedidotransdetalle), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDOSDetSD_UnReg(ByVal x_where As Hashtable) As Integer
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


    
    Public Function CargarPedidoTransDetalle(ByVal m_listdist_ordenes As  EABAS_PedidoTransformaciondetalle,ByVal x_codigo As String, ByVal x_artic_codigo As String, ByVal x_loteTrans as String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_ABAS_PEDIDTransformaciondetalle")
         DAEnterprise.AgregarParametro("@PEDID_CodigoTrans", x_codigo, DbType.String, 15)
         DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 8)
         DAEnterprise.AgregarParametro("@PEDID_Lote", x_loteTrans, DbType.Int64)
     
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, m_listdist_ordenes)
               m_listdist_ordenes.Instanciar(ACEInstancia.Consulta)
            Return True
            Else
            Return False
            End If
            
         End Using
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function




		Private Function getSelectAll() As String
			Dim sql As String = ""
			Try
				sql = " SELECT * "
				sql &= " FROM Logistica.ABAS_PedidoTransformacionDetalle" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_PedidoTransformacionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacionDetalle)(m_formatofecha)
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
				sql &= " FROM Logistica.ABAS_PedidoTransformacionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacionDetalle)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_PedidoTransformacionDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_PedidoTransformacionDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_orden_codigo As String) As String
			Dim sql As String = ""
			Try
				sql = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.ABAS_PedidoTransformacionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "PEDID_CodigoTrans = " + IIf(IsNothing(x_orden_codigo), "Null", "'" & x_orden_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function


		Private Function getSelectBy(ByVal x_orden_codigo As String, ByVal x_ordet_item As Short) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.ABAS_PedidoTransformacionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "PEDID_CodigoTrans = " + IIf(IsNothing(x_orden_codigo), "Null", "'" & x_orden_codigo & "'") & vbNewLine
				sql &= " AND PEDID_Item = " + x_ordet_item.ToString() & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_PedidoTransformacionDetalle" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacionDetalle)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_PedidoTransformacionDetalle)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_pedidotransformaciondet.PEDID_UsrCrea = x_usuario
				x_dist_pedidotransformaciondet.PEDID_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacionDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_dist_pedidotransformaciondet, x_dist_pedidotransformaciondet.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_pedidotransformaciondet.PEDID_UsrCrea = x_usuario
				x_dist_pedidotransformaciondet.PEDID_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacionDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_pedidotransformaciondet, x_dist_pedidotransformaciondet.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_pedidotransformaciondet.PEDID_UsrCrea = x_usuario
				x_dist_pedidotransformaciondet.PEDID_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacionDetalle)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_pedidotransformaciondet, x_dist_pedidotransformaciondet.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_pedidotransformaciondet.PEDID_UsrMod = x_usuario
				x_dist_pedidotransformaciondet.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacionDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PEDID_CodigoTrans", New ACWhere(x_dist_pedidotransformaciondet.PEDID_CodigoTrans, ACWhere.TipoWhere.Igual))
				_where.Add("PEDID_Item", New ACWhere(x_dist_pedidotransformaciondet.PEDID_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_dist_pedidotransformaciondet, _where, x_dist_pedidotransformaciondet.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_pedidotransformaciondet.PEDID_UsrMod = x_usuario
				x_dist_pedidotransformaciondet.PEDID_UsrMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacionDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PEDID_CodigoTrans", New ACWhere(x_dist_pedidotransformaciondet.PEDID_CodigoTrans, ACWhere.TipoWhere.Igual))
				_where.Add("PEDID_Item", New ACWhere(x_dist_pedidotransformaciondet.PEDID_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_pedidotransformaciondet, _where, x_dist_pedidotransformaciondet.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_pedidotransformaciondet.PEDID_UsrMod = x_usuario
				x_dist_pedidotransformaciondet.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacionDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_pedidotransformaciondet, x_where, x_dist_pedidotransformaciondet.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_pedidotransformaciondet.PEDID_UsrMod = x_usuario
				x_dist_pedidotransformaciondet.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacionDetalle)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PEDID_CodigoTrans", New ACWhere(x_dist_pedidotransformaciondet.PEDID_CodigoTrans, ACWhere.TipoWhere.Igual))
				_where.Add("PEDID_Item", New ACWhere(x_dist_pedidotransformaciondet.PEDID_Item, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_pedidotransformaciondet, _where, x_dist_pedidotransformaciondet.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_pedidotransformaciondet.PEDID_UsrMod = x_usuario
				x_dist_pedidotransformaciondet.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacionDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_pedidotransformaciondet, x_where, x_dist_pedidotransformaciondet.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_pedidotransformaciondet.PEDID_UsrMod = x_usuario
				x_dist_pedidotransformaciondet.PEDID_FecCrea = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacionDetalle)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_pedidotransformaciondet, x_where, x_dist_pedidotransformaciondet.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_dist_pedidotransformaciondet As EABAS_PedidoTransformacionDetalle) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_PedidoTransformacionDetalle" & vbNewLine
				sql &= " WHERE "
				sql &= "    PEDID_CodigoTrans = " & IIf(IsNothing(x_dist_pedidotransformaciondet.PEDID_CodigoTrans), "Null", "'" & x_dist_pedidotransformaciondet.PEDID_CodigoTrans & "'") & vbNewLine
				sql &= "And PEDID_Item = " & IIf(x_dist_pedidotransformaciondet.PEDID_Item = 0, "Null", x_dist_pedidotransformaciondet.PEDID_Item.ToString()) & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_PedidoTransformacionDetalle" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacionDetalle)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_PedidoTransformacionDetalle ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_PedidoTransformacionDetalle ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacionDetalle)(m_formatofecha) 
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
