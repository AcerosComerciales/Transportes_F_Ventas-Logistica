Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DGenerarControl

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	

#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Datos: REPOSS_GuiasXConductor
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_id_conductor">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function REPOSS_GuiasXConductor(ByVal m_listguia_remision As List(Of EDIST_GuiasRemision), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_id_conductor As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("REPOSS_GuiasXConductor")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Licencia_Conducir", x_id_conductor, DbType.String, 10)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _guia_remision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, _guia_remision)
                  _guia_remision.Instanciar(ACEInstancia.Consulta)
                  m_listguia_remision.Add(_guia_remision)
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


   ''' <summary> 
   ''' Capa de Datos: REPOSS_GuiasXCliente
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_id_cliente">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function REPOSS_GuiasXCliente(ByVal m_listguia_remision As List(Of EDIST_GuiasRemision), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_id_cliente As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("REPOSS_GuiasXCliente")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Id_Cliente", x_id_cliente, DbType.String, 12)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _guia_remision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, _guia_remision)
                  _guia_remision.Instanciar(ACEInstancia.Consulta)
                  m_listguia_remision.Add(_guia_remision)
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

   Public Function CONDSS_Ayuda(ByRef x_datos As DataTable, ByVal x_cadena As String, ByVal x_opcion As Short)
      Try
         DAEnterprise.AsignarProcedure("CONDSS_Ayuda")
         DAEnterprise.AgregarParametro("@Cadena", x_cadena)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return x_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

