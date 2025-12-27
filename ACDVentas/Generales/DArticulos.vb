Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DArticulos


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "

   ''' <summary> 
   ''' Capa de Datos: ARTICSS_ProductosPrecios
   ''' </summary>
   ''' <param name="x_linea_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ARTICSS_ProductosPrecios(ByRef m_listarticulos As List(Of EArticulos), ByRef m_listPrecios As List(Of EPPrecios), _
                                            ByRef m_listLPrecios As List(Of EVENT_ListaPrecios), _
                                            ByVal x_zonas_codigo As String, ByVal x_linea_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ARTICSS_ProductosPrecios")
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         If x_linea_codigo.Length > 0 Then
            DAEnterprise.AgregarParametro("@LINEA_Codigo", x_linea_codigo, DbType.String, 10)
         End If
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _articulos As New EArticulos()
                  ACEsquemas.ACCargarEsquema(reader, _articulos)
                  _articulos.Instanciar(ACEInstancia.Consulta)
                  m_listarticulos.Add(_articulos)
               End While
               If reader.NextResult() Then
                  While reader.Read()
                     Dim e_lpprecios As New EPPrecios()
                     ACEsquemas.ACCargarEsquema(reader, e_lpprecios)
                     e_lpprecios.Instanciar(ACEInstancia.Consulta)
                     m_listPrecios.Add(e_lpprecios)
                  End While
               End If
               If reader.NextResult() Then
                  While reader.Read()
                     Dim e_listaprecios As New EVENT_ListaPrecios()
                     ACEsquemas.ACCargarEsquema(reader, e_listaprecios)
                     e_listaprecios.Instanciar(ACEInstancia.Consulta)
                     m_listLPrecios.Add(e_listaprecios)
                  End While
               End If
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

#End Region
#End Region

#Region " Metodos "

   ''' <summary>
   ''' obtener el correlativo
   ''' </summary>
   ''' <param name="x_codlin"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCodCorrelativo(ByVal x_codlin As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectAllN(x_codlin), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("Codigo"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener el nombre
   ''' </summary>
   ''' <param name="x_codartdest"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getName(ByVal x_codartdest As String) As String
      Try
         DAEnterprise.AsignarProcedure(getSelectId(x_codartdest), CommandType.Text)
         Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
         Return CType(m_data.Tables(0).Rows(0)("ARTIC_CodigoDestino"), Integer)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtyener el srtock
   ''' </summary>
   ''' <param name="listEStockArt"></param>
   ''' <param name="x_art_cod"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getStock(ByRef listEStockArt As List(Of EArticulos), ByVal x_art_cod As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAllStock(x_art_cod), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               '' probar con ESotck
               Dim _utilitarios As New ACEsquemas(New ACELogistica.ELOG_Stocks)
               While reader.Read()
                  Dim e_stockart As New EArticulos()
                  _utilitarios.ACCargarEsquemas(reader, e_stockart)
                  e_stockart.Instanciar(ACEInstancia.Consulta)
                  listEStockArt.Add(e_stockart)
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
   ''' Capa de Datos: ARTICSS_UnRegistro
   ''' </summary>
   ''' <param name="x_artic_codigo">Parametro 1: </param> 
   ''' <param name="x_zonas_codigo">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ARTICSS_UnRegistro(ByVal x_articulos As EArticulos, ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ARTICSS_UnRegistro")
         DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 7)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_articulos)
               x_articulos.Instanciar(ACEInstancia.Consulta)
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

   ''' <summary>
   ''' obtener el scrip del proceso ingresar articulo
   ''' </summary>
   ''' <param name="x_articulos"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ARTICSI_UnRegSQL(ByRef x_articulos As EArticulos, ByVal x_usuario As String) As String
      Try
         Return getInsert(x_articulos, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el scrip del proceso ingresar articulo
   ''' </summary>
   ''' <param name="x_articulos"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ARTICSU_UnRegSQL(ByVal x_articulos As EArticulos, ByVal x_usuario As String) As String
      Try
         Return getUpdate(x_articulos, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#Region "Procedimientos Adicionales"

   Private Function getSelectAllN(ByVal x_codlin As String) As String
      Dim sql As String = ""

      Try
         sql &= String.Format(" SELECT max(convert(INTEGER, substring(artic_codigo, 5,3))) as Codigo  from articulos {0}", vbNewLine)
         sql &= String.Format(" Where linea_codigo = '{0}'{1}", x_codlin, vbNewLine)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectID(ByVal x_nom) As String
      Dim sql As String = ""
      Try
         'select Ar.ARTIC_Codigo from Articulos Ar where Ar.ARTIC_Descripcion like '%Lija al Agua 80 9 X 11 X 50U ABRALIT%'

         sql &= String.Format(" select Ar.ARTIC_Codigo from Articulos Ar {0}", vbNewLine)
         sql &= String.Format(" where Ar.ARTIC_Descripcion like '{0}'{1}", x_nom, vbNewLine)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAllStock(ByVal x_cod) As String
      Dim sql As String = ""
      Try

         sql = " SELECT "
         sql &= " AL.ALMAC_Descripcion, ST.STOCK_Inicial, ST.STOCK_Minimo, ST.STOCK_Maximo, ST.STOCK_Cantidad, ST.STOCK_ReOrden"
         sql &= " FROM Stocks ST"
         sql &= " Inner Join Almacenes AL On AL.ALMAC_Id = ST.ALMAC_Id "
         sql &= " WHERE "
         sql &= "ST.ARTIC_Codigo like '%" & x_cod & "%'"

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#End Region

#End Region


End Class

