Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DTipos


#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function TIPOSSS_TodosTrim(ByRef listETipos As List(Of ETipos)) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETipos())
               While reader.Read()
                  Dim e_tipos As New ETipos()
                  _utilitarios.ACCargarEsquemas(reader, e_tipos)
                  e_tipos.Instanciar(ACEInstancia.Consulta)
                  e_tipos.TIPOS_Codigo = e_tipos.TIPOS_Codigo.Trim()
                  listETipos.Add(e_tipos)
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

   Public Function TIPOSS_Todos(ByRef listETipos As List(Of ETipos), ByVal x_cadena As String, ByVal x_tipo_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena, x_tipo_codigo), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETipos())
               While reader.Read()
                  Dim e_tipos As New ETipos()
                  _utilitarios.ACCargarEsquemas(reader, e_tipos)
                  e_tipos.Instanciar(ACEInstancia.Consulta)
                  listETipos.Add(e_tipos)
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

   Public Function TIPOSI_UnRegSP(ByVal x_tipos As ETipos, ByVal x_usuario As String) As Integer
      Dim m_filas As Integer
      Try
         DAEnterprise.AsignarProcedure("TIPOSI_UnReg")
         DAEnterprise.AgregarParametro("@TIPOS_Codigo", x_tipos.TIPOS_Codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@TIPOS_Descripcion", x_tipos.TIPOS_Descripcion, DbType.String, 50)
         DAEnterprise.AgregarParametro("@TIPOS_DescCorta", x_tipos.TIPOS_DescCorta, DbType.String, 10)
         DAEnterprise.AgregarParametro("@TIPOS_Numero", x_tipos.TIPOS_Numero, DbType.Decimal, 5)
         DAEnterprise.AgregarParametro("@TIPOS_ESTADO", x_tipos.TIPOS_Estado, DbType.String, 1)
         DAEnterprise.AgregarParametro("@TIPOS_PROTEGIDO", x_tipos.TIPOS_Protegido, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@Usuario", x_usuario, 20)

         m_filas = DAEnterprise.ExecuteNonQuery()
         x_tipos.TIPOS_Codigo = DAEnterprise.Command.Parameters("@TIPOS_Codigo").Value

         Return m_filas
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#Region "Procedimientos Adicionales "
    Public Function getSelectAll(ByVal x_cadena As String, ByVal x_tipo_codigo As String) As String
        Dim sql As String
        Try
            sql = " SELECT "
            sql &= " TIPOS_Codigo"
            sql &= ",TIPOS_Descripcion"
            sql &= ",TIPOS_DescLarga"
            sql &= ",TIPOS_DescCorta"
            sql &= ",TIPOS_Numero"
            sql &= ",TIPOS_ESTADO"
            sql &= ",TIPOS_PROTEGIDO"
            sql &= " FROM dbo.Tipos"
            sql &= " WHERE "
            sql &= " TIPOS_Codigo Like '" & x_tipo_codigo & "%'"
            sql &= " AND TIPOS_Descripcion Like '%" & x_cadena & "%'"
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#End Region

End Class

