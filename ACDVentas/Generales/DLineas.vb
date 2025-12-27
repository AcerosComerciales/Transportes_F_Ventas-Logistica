Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DLineas


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function LINEASS_TodosDT() As DataTable
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
         Return DAEnterprise.ExecuteDataSet().Tables(0)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function LINEASS_Todos(ByRef listEListas As List(Of ELineas), ByRef m_dtLinea As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
         m_dtLinea = DAEnterprise.ExecuteDataSet().Tables(0)

         For Each Item As DataRow In m_dtLinea.Rows
            Dim _utilitarios As New ACEsquemas(New ELineas())
            Dim e_lineas As New ELineas()
            _utilitarios.ACCargarEsquemas(Item, e_lineas)
            e_lineas.Instanciar(ACEInstancia.Consulta)
            listEListas.Add(e_lineas)
         Next
         m_dtLinea.Columns("LINEA_Codigo").ColumnName = "CODIGO"
         m_dtLinea.Columns("LINEA_Nombre").ColumnName = "DESCRIPCION"
         m_dtLinea.Columns("LINEA_CodPadre").ColumnName = "CODPADRE"
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function LINEASS_Todos(ByRef listEListas As List(Of ELineas), ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ELineas())
               While reader.Read()
                  Dim e_lineas As New ELineas()
                  _utilitarios.ACCargarEsquemas(reader, e_lineas)
                  e_lineas.Instanciar(ACEInstancia.Consulta)
                  listEListas.Add(e_lineas)
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

#Region "Procedimientos Adicionales "
   Public Function getSelectAll(ByVal x_cadena As String) As String
      Dim sql As String
      Try

         sql = " SELECT "
         sql &= " LPadre.LINEA_Nombre As LPADRE_NOMBRE, Lin.*"
         sql &= " FROM dbo.Lineas As Lin"
         sql &= " Left Join Lineas as LPadre On LPadre.LINEA_Codigo = Lin.LINEA_CodPadre "
         sql &= " WHERE "
         sql &= " Lin.LINEA_Nombre like '%" & x_cadena & "%'"

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

#Region " Metodos "

#End Region


End Class

