Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DDirecciones


#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "
    Public Function DIRESS_Todos(ByRef listEDirecciones As List(Of EDirecciones), ByVal x_entid_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_entid_codigo), CommandType.Text)
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

    'Procedimineot para listar Clientes por direccion + Ubigeos
    'AYUDASS_Busq_X_UBIGEOS se intnto 

    'Public Function AYUDASS_Busq_X_UBIGEOS(ByRef x_vent_docsventa As EDirecciones, ByVal x_entid_codigo As String) As Boolean
    '    Try
    '        DAEnterprise.AsignarProcedure("VENT_DOCVESS_UnDocumento")
    '        DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 15)
    '        Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
    '            If reader.HasRows Then
    '                While reader.Read()
    '                    ACEsquemas.ACCargarEsquema(reader, x_vent_docsventa)
    '                    x_vent_docsventa.Instanciar(ACEInstancia.Consulta)
    '                End While
    '                If reader.NextResult() Then
    '                    While reader.Read()
    '                        Dim e_vent_docsventadetalle As New EDirecciones()
    '                        ACEsquemas.ACCargarEsquema(reader, e_vent_docsventadetalle)
    '                        e_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
    '                        x_vent_docsventa.ListVENT_DocsVentaDetalle.Add(e_vent_docsventadetalle)
    '                    End While
    '                End If
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        End Using
    '        Return True
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function DIRECS_TodosAyuda(ByRef dtEEntidades As DataTable, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_where), CommandType.Text)
         dtEEntidades = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtEEntidades.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getIdDireccion(ByVal x_entid_codigo As String) As Short
      Dim dtEEntidades As New DataTable()
      Try
         DAEnterprise.AsignarProcedure(GetSelect(x_entid_codigo), CommandType.Text)
         dtEEntidades = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtEEntidades.Rows(0)("Numero")
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#Region "Procedimientos Adicionales "
   Public Function getSelectAll(ByVal x_entid_id As Long) As String
      Dim sql As String = ""
      Try
         sql = " SELECT "
         sql &= " Dir.*, UBIGO_Descripcion "
         sql &= " FROM dbo.Direcciones As Dir"
         sql &= " Inner Join Ubigeos As Ubi On Ubi.UBIGO_Codigo = Dir.UBIGO_Codigo "
         sql &= " WHERE "
         sql &= String.Format("ENTID_Codigo = {0}", x_entid_id)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectAyuda(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         Dim _where As New ACGenerador(Of EEntidades)(m_formatofecha)
         sql &= String.Format(App.Hash("DDirecciones.DIRECS_TodosAyuda").ToString(), _where.getWhere(x_where, "Dir", True))
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function GetSelect(ByVal x_entid_codigo As String) As String
      Dim sql As String = ""
      Try
         sql = String.Format("Select IsNull(Max(DIREC_Id), 0) As Numero from direcciones where entid_codigo = '{0}'", x_entid_codigo)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

