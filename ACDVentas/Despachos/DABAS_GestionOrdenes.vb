Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DABAS_GestionOrdenes

 #Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "

   'Public Function LOG_DISTSS_BuscarOrdenesIngreso(ByVal m_listdist_ordenes As List(Of EABAS_OrdenesProduccion), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   Try
   '      DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesIngresoProduccion")
   '      DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
   '      DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
   '      DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
   '      DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
   '      DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
   '      Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
   '         If reader.HasRows Then
   '            While reader.Read()
   '               Dim _dist_ordenes As New EABAS_OrdenesProduccion()
   '               ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
   '               _dist_ordenes.Instanciar(ACEInstancia.Consulta)
   '               m_listdist_ordenes.Add(_dist_ordenes)
   '            End While
   '            Return True
   '         Else
   '            Return False
   '         End If
   '      End Using
   '      Return False
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function


   'Public Function LOG_DISTSS_ObtenerOrden(ByRef x_dist_ordenes As EABAS_OrdenesProduccion, ByVal x_orden_codigo As String, ByVal x_detalle As Boolean) As Boolean
   '   Try
   '      DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerOrdenProduccion")
   '      DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 13)
   '      DAEnterprise.AgregarParametro("@Detalle", x_detalle, DbType.Boolean, 1)
   '      Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

   '         If reader.HasRows Then
   '            reader.Read()
   '            ACEsquemas.ACCargarEsquema(reader, x_dist_ordenes)
   '            x_dist_ordenes.Instanciar(ACEInstancia.Consulta)
   '         Else
   '            Return False
   '         End If
   '         Dim _peso As Decimal = 0
   '         x_dist_ordenes.ListDIST_OrdenesDetalle = New List(Of EABAS_OrdenesProduccionDetalle)
   '         If reader.NextResult() Then
   '            Dim _utilitariosdet As New ACEsquemas(New EABAS_OrdenesProduccionDetalle)
   '            While reader.Read()
   '               Dim _ordendetalle As New EABAS_OrdenesProduccionDetalle
   '               _utilitariosdet.ACCargarEsquemas(reader, _ordendetalle)
   '               _ordendetalle.Instanciar(ACEInstancia.Consulta)
   '               x_dist_ordenes.ListDIST_OrdenesDetalle.Add(_ordendetalle)
   '               _peso += _ordendetalle.PesoUnitario * _ordendetalle.ORDET_Cantidad
   '            End While
   '         End If
   '         x_dist_ordenes.Peso = _peso
   '         Return True
   '      End Using
   '      Return False
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function


#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "


#End Region
End Class

Partial Public Class DABAS_GestionOrdenes

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "ABAS_GestionOrdenes"
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
	
	Public Function DIST_GESTIONORDSS_Todos(ByRef x_listDIST_GestionOrd As List(Of EABAS_GestionOrdenes)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_GestionOrdenes())
					While reader.Read()
						Dim x_edist_ordenes As New EABAS_GestionOrdenes()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_GestionOrd.Add(x_edist_ordenes)
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

	Public Function DIST_GESTIONORDSS_Todos(ByRef x_listDIST_GestionOrd As List(Of EABAS_GestionOrdenes), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_GestionOrdenes())
					While reader.Read()
						Dim x_edist_ordenes As New EABAS_GestionOrdenes()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_GestionOrd.Add(x_edist_ordenes)
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

	Public Function DIST_GESTIONORDSS_Todos(ByRef x_listDIST_GestionOrd As List(Of EABAS_GestionOrdenes), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_GestionOrdenes())
					While reader.Read()
						Dim x_edist_ordenes As New EABAS_GestionOrdenes()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_GestionOrd.Add(x_edist_ordenes)
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

	Public Function DIST_GESTIONORDSS_Todos(ByRef x_listDIST_GestionOrd As List(Of EABAS_GestionOrdenes), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_GestionOrdenes())
					While reader.Read()
						Dim x_edist_ordenes As New EABAS_GestionOrdenes()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_GestionOrd.Add(x_edist_ordenes)
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

	Public Function DIST_GESTIONORDSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSS_UnReg(ByRef x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_gestor_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_gestor_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_gestionord)
					x_edist_gestionord.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    
	Public Function DIST_GESTIONORDSS_UnReg(ByRef x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_gestionord)
					x_edist_gestionord.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSS_UnReg(ByRef x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_gestionord)
					x_edist_gestionord.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    
      Public Function LOG_DISTSS_ObtenerGestionOrden(ByRef x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_orden_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerGestionOrden")
         DAEnterprise.AgregarParametro("@GESTOR_Codigo", x_orden_codigo, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_dist_ordenes)
               x_dist_ordenes.Instanciar(ACEInstancia.Consulta)
            Else
               Return False
            End If
            Dim _peso As Decimal = 0
            x_dist_ordenes.ListDIST_GestionOrdenesDetalle = New List(Of EABAS_GestionOrdenesDetalle)
            If reader.NextResult() Then
               Dim _utilitariosdet As New ACEsquemas(New EABAS_GestionOrdenesDetalle)
               While reader.Read()
                  Dim _ordendetalle As New EABAS_GestionOrdenesDetalle
                  _utilitariosdet.ACCargarEsquemas(reader, _ordendetalle)
                  _ordendetalle.Instanciar(ACEInstancia.Consulta)
                  x_dist_ordenes.ListDIST_GestionOrdenesDetalle.Add(_ordendetalle)
                  
               End While
            End If
            x_dist_ordenes.Peso = _peso
            Return True
         End Using
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     Public Function LOG_DISTSS_BuscarPedidoTransCANTIDAD(ByVal m_listdist_ordenes As List(Of EABAS_GestionOrdenes),ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_alamacen As Short, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_ABAS_PEDIDTransformacionCantidad")
         DAEnterprise.AgregarParametro("@fecini", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@fecfin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@almacen", x_alamacen, DbType.String, 8)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_pedidos As New EABAS_GestionOrdenes()
                  ACEsquemas.ACCargarEsquema(reader, _dist_pedidos)
                  _dist_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_pedidos)
               End While
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




	Public Function DIST_GESTIONORDSI_UnReg(ByRef x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_edist_gestionord, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSI_UnReg(ByRef x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_edist_gestionord, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSI_UnReg(ByRef x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_edist_gestionord, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSU_UnReg(ByVal x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_gestionord, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSU_UnReg(ByVal x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_gestionord, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSU_UnReg(ByVal x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_gestionord, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSU_UnReg(ByVal x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_gestionord, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSU_UnReg(ByVal x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_gestionord, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSU_UnReg(ByVal x_edist_gestionord As EABAS_GestionOrdenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_edist_gestionord, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSD_UnReg(ByVal x_edist_gestionord As EABAS_GestionOrdenes) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_edist_gestionord), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_GESTIONORDSD_UnReg(ByVal x_where As Hashtable) As Integer
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

    Public Function getUnidadMedida(ByVal x_campo As String) As String
		Try
			DAEnterprise.AsignarProcedure(getSelectunidad(x_campo), CommandType.Text)
			Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
			Return CType(m_data.Tables(0).Rows(0)("TIPOS_CodUnidadMedida"), String)
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
				sql &= " FROM Logistica.ABAS_GestionOrdenes" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_GestionOrdenes" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_GestionOrdenes)(m_formatofecha)
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
				sql &= " FROM Logistica.ABAS_GestionOrdenes" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_GestionOrdenes)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_GestionOrdenes)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_GestionOrdenes)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_orden_codigo As String) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.ABAS_GestionOrdenes" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "GESTOR_Codigo = " + IIf(IsNothing(x_orden_codigo), "Null", "'" & x_orden_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_GestionOrdenes" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_GestionOrdenes)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_GestionOrdenes)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.GESTOR_UsrCrea = x_usuario
				x_dist_ordenes.GESTOR_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_GestionOrdenes)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_dist_ordenes, x_dist_ordenes.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.GESTOR_UsrCrea = x_usuario
				x_dist_ordenes.GESTOR_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_GestionOrdenes)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_ordenes, x_dist_ordenes.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.GESTOR_UsrCrea = x_usuario
				x_dist_ordenes.GESTOR_FecCrea = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_GestionOrdenes)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_ordenes, x_dist_ordenes.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.GESTOR_UsrMod = x_usuario
				x_dist_ordenes.GESTOR_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_GestionOrdenes)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("GESTOR_Codigo", New ACWhere(x_DIST_Ordenes.GESTOR_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenes, _where, x_dist_ordenes.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.GESTOR_UsrMod = x_usuario
				x_dist_ordenes.GESTOR_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_GestionOrdenes)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("GESTOR_Codigo", New ACWhere(x_DIST_Ordenes.GESTOR_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_ordenes, _where, x_dist_ordenes.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.GESTOR_UsrMod = x_usuario
				x_dist_ordenes.GESTOR_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_GestionOrdenes)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenes, x_where, x_dist_ordenes.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.GESTOR_UsrMod = x_usuario
				x_dist_ordenes.GESTOR_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_GestionOrdenes)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("GESTOR_Codigo", New ACWhere(x_DIST_Ordenes.GESTOR_Codigo, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_ordenes, _where, x_dist_ordenes.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.GESTOR_UsrMod = x_usuario
				x_dist_ordenes.GESTOR_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_GestionOrdenes)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_ordenes, x_where, x_dist_ordenes.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.GESTOR_UsrMod = x_usuario
				x_dist_ordenes.GESTOR_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_GestionOrdenes)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenes, x_where, x_dist_ordenes.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_dist_ordenes As EABAS_GestionOrdenes) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_GestionOrdenes" & vbNewLine
				sql &= " WHERE "
				sql &= "    ORDEN_Codigo = " & IIf(IsNothing(x_dist_ordenes.GESTOR_Codigo), "Null", "'" & x_dist_ordenes.GESTOR_Codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_GestionOrdenes" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_GestionOrdenes)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_GestionOrdenes ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

    Private Function getSelectunidad(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" select TIPOS_CodUnidadMedida from Articulos where ARTIC_Codigo='{0}' ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
    

		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_GestionOrdenes ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_GestionOrdenes)(m_formatofecha) 
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
