Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DAlmacenes


#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "

   ''' <summary>
   ''' cargar todos los almacenes
   ''' </summary>
   ''' <param name="listETRAN_Almacenes"></param>
   ''' <param name="x_cadena"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ALMASS_Todos(ByRef listETRAN_Almacenes As List(Of EAlmacenes), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EAlmacenes())
               While reader.Read()
                  Dim e_tran_almacenes As New EAlmacenes()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_almacenes)
                  e_tran_almacenes.Instanciar(ACEInstancia.Consulta)
                  listETRAN_Almacenes.Add(e_tran_almacenes)
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
   ''' cargar la ayuda de almacenes
   ''' </summary>
   ''' <param name="dtEEntidades"></param>
   ''' <param name="x_where"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ALMASS_TodosAyuda(ByRef dtEEntidades As DataTable, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_where), CommandType.Text)
         dtEEntidades = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtEEntidades.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "
   Public Function getSelectAll(ByVal x_cadena As String) As String
      Dim sql As String
      Try
         sql = " SELECT "
         sql &= " Alma.*, Suc.SUCUR_Nombre"
         sql &= " FROM Almacenes As Alma"
         sql &= " Inner Join Sucursales As Suc On Suc.SUCUR_Id = Alma.SUCUR_Id "
         sql &= " WHERE "
         sql &= "ALMAC_DESCRIPCION like '%" & x_cadena & "%'"

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAyuda(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         sql = " SELECT "
         sql &= " ALMAC_ID As Interno"
         sql &= ",TAlm.TIPOS_Descripcion As [T. Almacen]"
         sql &= ",ALMAC_DESCRIPCION As Descripción"
         sql &= ",ALMAC_DIRECCION As Dirección"
         sql &= " FROM dbo.Almacenes As Alm"
         sql &= " Inner Join Tipos As TAlm On TAlm.TIPOS_Codigo = Alm.TIPOS_CODTIPOALMACEN "
         sql &= " WHERE "
         Dim _where As New ACGenerador(Of EAlmacenes)(m_formatofecha)
         sql &= _where.getWhere(x_where, True)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

