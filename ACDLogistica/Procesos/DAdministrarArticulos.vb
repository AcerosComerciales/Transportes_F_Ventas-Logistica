Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica
Imports ACEVentas


Public Class DAdministrarArticulos
#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Datos: ARTICSS_OrdenarProductos
   ''' </summary>
   ''' <param name="x_perio_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_linea">Parametro 4: </param> 
   ''' <param name="x_sublinea">Parametro 5: </param> 
   ''' <param name="x_fecha">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ARTICSS_OrdenarProductos(ByVal m_listarticulos As List(Of EArticulos), ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String, ByVal x_linea As String, ByVal x_sublinea As String, ByVal x_fecha As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ARTICSS_OrdenarProductos")
         DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@Linea", x_linea, DbType.String, 10)
         DAEnterprise.AgregarParametro("@SubLinea", x_sublinea, DbType.String, 10)
         DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _articulos As New EArticulos()
                  ACEsquemas.ACCargarEsquema(reader, _articulos)
                  _articulos.Instanciar(ACEInstancia.Consulta)
                  m_listarticulos.Add(_articulos)
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
#End Region

#Region " Metodos de Controles"

#End Region
End Class
