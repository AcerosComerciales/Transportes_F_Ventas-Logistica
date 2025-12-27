Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DDESP_Salidas

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   ''' <summary> 
   ''' Procedimiento "GUIA_Salidas" por el Generador 18/11/2011
   ''' </summary> 
   ''' <param name="m_listDESP_Salidas">Lista donde se cargaran los valores</param> 
   ''' <param name="x_fecha">Parametro 1: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_Salidas(ByRef m_listDESP_Salidas As List(Of EDESP_Salidas), ByVal x_fecha As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("GUIA_Salidas")
         DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_desp_salidas As New EDESP_Salidas()
                  ACEsquemas.ACCargarEsquema(reader, e_DESP_Salidas)
                  e_DESP_Salidas.Instanciar(ACEInstancia.Consulta)
                  m_listDESP_Salidas.Add(e_DESP_Salidas)
               End While
               Dim _listGuiaRemision As New List(Of EDIST_GuiasRemision)
               Dim _utilitariosdet As New ACEsquemas(New EDIST_GuiasRemision)
               If reader.NextResult() Then
                  While reader.Read()
                     Dim _guia_remision As New EDIST_GuiasRemision
                     _utilitariosdet.ACCargarEsquemas(reader, _guia_remision)
                     _guia_remision.Instanciar(ACEInstancia.Consulta)
                     _listGuiaRemision.Add(_guia_remision)
                  End While
               End If
               Dim _filtrador As New ACFiltrador(Of EDIST_GuiasRemision)
               For Each _guia As EDESP_Salidas In m_listDESP_Salidas
                  _filtrador.ACFiltro = String.Format("CSalida={0}", _guia.CSalida)
                  _guia.ListGuia_Remision = _filtrador.ACFiltrar(_listGuiaRemision)
               Next
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
   ''' Procedimiento "GUIA_SalidasDetalle" por el Generador 14/12/2011
   ''' </summary> 
   ''' <param name="m_listGuia_Remision">Lista donde se cargaran los valores</param> 
   ''' <param name="x_fecha">Parametro 1: </param> 
   ''' <param name="x_csalida">Parametro 2: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_SalidasDetalle(ByRef m_listGuia_Remision As List(Of EDIST_GuiasRemision), ByVal x_fecha As Date, ByVal x_csalida As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("GUIA_SalidasDetalle")
         DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@CSalida", x_csalida, DbType.String, 12)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_guia_remision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, e_guia_remision)
                  e_guia_remision.Instanciar(ACEInstancia.Consulta)
                  m_listGuia_Remision.Add(e_guia_remision)
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

   Public Function DESP_SALIDSU_UnRegActualizarLlegada(ByRef x_desp_salidas As EDESP_Salidas, ByVal x_usuario As String) As Integer
      Try
         Dim _fecha As DateTime = getDateTime()

         x_desp_salidas.SALID_HoraLlegada = New DateTime(_fecha.Year, _fecha.Month, _fecha.Day, x_desp_salidas.SALID_HoraLlegada.Hour, x_desp_salidas.SALID_HoraLlegada.Minute, x_desp_salidas.SALID_HoraLlegada.Second)

         DAEnterprise.AsignarProcedure("DESP_SALIDSU_UnRegActualizarLlegada")
         DAEnterprise.AgregarParametro("@SALID_Id", x_desp_salidas.SALID_Id, DbType.Int32, 4)
         DAEnterprise.AgregarParametro("@VEHIC_Id", x_desp_salidas.VEHIC_Id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@SALID_HoraLlegada", x_desp_salidas.SALID_HoraLlegada, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Usuario", x_usuario, DbType.String, 20)
         Return DAEnterprise.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
	
#End Region

End Class

