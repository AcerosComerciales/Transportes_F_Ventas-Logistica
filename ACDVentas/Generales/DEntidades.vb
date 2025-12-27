Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DEntidades


#Region " Variables "

   Enum TipoProceso
      SQL
      SQL_ID
   End Enum

#End Region

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "

   Public Function ENTISS_UnReg(ByRef x_entidades As EEntidades, ByVal x_entid_dni As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectByUsuario(x_entid_dni), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_entidades)
               x_entidades.Instanciar(ACEInstancia.Consulta)
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ENTISI_UnReg(ByRef x_entidades As EEntidades, ByVal x_usuario As String, ByVal x_tipo As EEntidades.TipoInicializacion) As Integer
      Dim m_filas As Integer
      Try
         Select Case x_tipo
            Case EEntidades.TipoInicializacion.EntTipos_Dir_Tel
               DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario, x_tipo), CommandType.Text)
               Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
               x_entidades.ENTID_Id = CType(m_datos.Rows(0)(0), Long)
            Case Else
               DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario), CommandType.Text)
               m_filas = DAEnterprise.ExecuteNonQuery()
         End Select
         Return m_filas
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ENTISS_TodosAyuda(ByRef dtEEntidades As DataTable, ByVal x_where As Hashtable, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_where, x_tipoentidad), CommandType.Text)
         dtEEntidades = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtEEntidades.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ENTISS_TodosAyudaConductor(ByRef dtEEntidades As DataTable, ByVal x_entid_codigo As String, ByVal x_cadena As String, ByVal x_campo As String, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_entid_codigo, x_cadena, x_campo, x_tipoentidad), CommandType.Text)
         dtEEntidades = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtEEntidades.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ENTISS_TodosAyudaConductor(ByRef dtEEntidades As DataTable, ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ENTISS_TodosAyudaConductor")
         DAEnterprise.AgregarParametro("@ROLES_Id", x_tipoentidad, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         dtEEntidades = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtEEntidades.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ENTISS_TodosAyudaUsuario(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyudaUsuario(x_where), CommandType.Text)
         m_datos = DAEnterprise.ExecuteDataSet()
         Return m_datos.Tables.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ENTISS_CargarDocIden(ByRef x_entidades As EEntidades, ByVal x_entid_nrodocumento As String) As Boolean
      Dim sql As String = ""
      Try
         App.Inicializar()
            sql = String.Format(App.Hash("DEntidades.CargarDocDevo"), x_entid_nrodocumento)
         DAEnterprise.AsignarProcedure(sql, CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_entidades)
               x_entidades.Instanciar(ACEInstancia.Consulta)
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ENTISS_CargarDirecciones(ByRef listEDirecciones As List(Of EDirecciones), ByVal x_entid_codigo As String) As Boolean
      Dim sql As String = ""
      Try
         App.Inicializar()
            sql = String.Format(App.Hash("DEntidades.ENTISS_CargarDirecciones"), x_entid_codigo)
         DAEnterprise.AsignarProcedure(sql, CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EDirecciones())
               While reader.Read()
                  Dim e_direcciones As New EDirecciones()
                  _utilitarios.ACCargarEsquemas(reader, e_direcciones)
                  e_direcciones.Instanciar(ACEInstancia.Consulta)
                  listEDirecciones.Add(e_direcciones)
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

   ''' <summary> 
   ''' Capa de Datos: ENTISS_ObtenerDireccion
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ENTISS_ObtenerDireccion(ByVal x_entidades As EEntidades, ByVal x_entid_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ENTISS_ObtenerDireccion")
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_entidades)
               x_entidades.Instanciar(ACEInstancia.Consulta)
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
    Public Function ENTISS_CargarCotizadores(ByRef dtEEntidades As DataTable, ByVal x_periodo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectCotizadores(x_periodo), CommandType.Text)
            dtEEntidades = DAEnterprise.ExecuteDataSet().Tables(0)
            Return dtEEntidades.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
  

   ''' <summary> 
   ''' Capa de Datos: ENTISS_BuscarClientes
   ''' </summary>
   ''' <param name="x_cadena">Parametro 1: </param> 
   ''' <param name="x_opcion">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ENTISS_BuscarClientes(ByVal m_listentidades As List(Of EEntidades), ByVal x_cadena As String, ByVal x_opcion As Short) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ENTISS_BuscarClientes")
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 200)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _entidades As New EEntidades()
                  ACEsquemas.ACCargarEsquema(reader, _entidades)
                  _entidades.Instanciar(ACEInstancia.Consulta)
                  m_listentidades.Add(_entidades)
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

#Region "Procedimientos Adicionales "
   Public Function getSelectByUsuario(ByVal x_entid_dni As String) As String
      Dim sql As String
      Try
         sql = " SELECT "
         sql &= " * "
         sql &= " FROM Entidades"
         sql &= " WHERE "
         sql &= String.Format("USUAR_CODIGO = '{0}'", x_entid_dni)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    Public Function getSelectCotizadores(ByVal x_periodo As String) As String
        Dim sql As String
        Try
            sql = " SELECT Distinct  V.ENTID_CodigoCotizador"
            sql &= " ,E.ENTID_Nombres"
            sql &= " FROM Ventas.VENT_DocsVenta as V"
            sql &= String.Format(" Inner Join dbo.Entidades As E On E.ENTID_Codigo = V.ENTID_CodigoCotizador")
            sql &= " WHERE "
            sql &= String.Format("YEAR(DOCVE_FechaDocumento)='{0}'", x_periodo)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   Public Function getInsert(ByVal x_entidades As EEntidades, ByVal x_usuario As String, ByVal x_tipo As TipoProceso) As String
      Dim sql As String = ""
      Try
         Dim _fecha As DateTime = getDateTime()
         x_entidades.ENTID_UsrCrea = x_usuario
         x_entidades.ENTID_FecCrea = _fecha

         Dim _insert As New ACFramework.ACGenerador(Of EEntidades)(_fecha, m_formatofecha)
         sql = _insert.getInsert(Esquema, Tabla, x_entidades, x_entidades.Hash, New String() {"ENTID_Id"})
         sql &= " SELECT @@IDENTITY AS 'Identity'; "
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAyuda(ByVal x_where As Hashtable, ByVal x_tipoentidad As EEntidades.TipoEntidad) As String
      Dim sql As String = ""
      Try
         'sql = String.Format(" SELECT Distinct m_Ent.ENTID_Codigo As Codigo, m_Ent.ENTID_RazonSocial As [Razon Social], m_Ent.ENTID_Nombres As Nombre, m_Ent.ENTID_NroDocumento As [Doc./R.U.C.] {0}", vbNewLine)
         'sql &= String.Format(" ,ENTID_Direccion As Dirección, m_Ent.ENTID_Id As Interno{0}, UBIGO_Codigo As Ubigeo", vbNewLine)
         'sql &= String.Format(" FROM Entidades as m_Ent{0}", vbNewLine)
         App.Inicializar()
         sql = App.Hash("DEntidades.getSelectAyuda")
         If Not x_tipoentidad = EEntidades.TipoEntidad.Todos Then
            sql &= String.Format(" Inner Join EntidadesRoles As ERol On ERol.ENTID_Codigo = m_Ent.ENTID_Codigo And ERol.ROLES_Id = {0}{1}", x_tipoentidad.GetHashCode, vbNewLine)
            sql &= String.Format(" Inner Join Roles As Rol On Rol.ROLES_Id = ERol.ROLES_Id{0}", vbNewLine)
         End If
         sql &= String.Format(" WHERE {0}", vbNewLine)
         Dim _where As New ACGenerador(Of EEntidades)(m_formatofecha)
         sql &= _where.getWhere(x_where, "Ent", True)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAyuda(ByVal x_entid_codigo As String, ByVal x_cadena As String, ByVal x_campo As String, ByVal x_tipoentidad As EEntidades.TipoEntidad) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= String.Format(App.Hash("DEntidades.ENTISS_TodosAyudaConductor").ToString(), CType(x_tipoentidad, Integer).ToString(), x_entid_codigo, x_campo, x_cadena)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectAyudaUsuario(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         sql &= " SELECT  ENTID_Codigo As Código " & vbNewLine
         sql &= " ,ENTID_Nombres As Nombres" & vbNewLine
         sql &= " ,ENTID_NroDocumento As Documento" & vbNewLine
         sql &= " ,ENTID_EMail As EMail" & vbNewLine
         sql &= " ,ENTID_Direccion As Dirección" & vbNewLine
         sql &= " ,ENTID_Id As Interno" & vbNewLine
         sql &= " FROM Entidades" & vbNewLine
         sql &= " WHERE " & vbNewLine
         Dim _where As New ACGenerador(Of EUsuariosPorPuntoVenta)(m_formatofecha)
         sql &= _where.getWhere(x_where, True)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region
#End Region

End Class

