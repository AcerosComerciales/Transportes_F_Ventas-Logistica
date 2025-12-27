Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BDESP_Salidas

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "

   ''' <summary> 
   ''' Procedimiento "GUIA_Salidas" por el Generador 18/11/2011
   ''' </summary> 
   ''' <param name="x_fecha">Parametro 1: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_Salidas(ByVal x_fecha As Date) As Boolean
      m_listDESP_Salidas = New List(Of EDESP_Salidas)
      Try
         Return d_desp_salidas.GUIA_Salidas(m_listDESP_Salidas, x_fecha)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Procedimiento "GUIA_SalidasDetalle" por el Generador 14/12/2011
   ''' </summary> 
   ''' <param name="x_fecha">Parametro 1: </param> 
   ''' <param name="x_csalida">Parametro 2: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_SalidasDetalle(ByRef m_listGuia_Remision As List(Of EDIST_GuiasRemision), ByVal x_fecha As Date, ByVal x_csalida As String) As Boolean
      Dim m_dguia_remision As New DDIST_GuiasRemision()
      m_listGuia_Remision = New List(Of EDIST_GuiasRemision)
      Try
         Return d_desp_salidas.GUIA_SalidasDetalle(m_listGuia_Remision, x_fecha, x_csalida)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Actuializar la guia de salida para confirmar su llegada
   ''' </summary>
   ''' <param name="x_desp_salidas"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function DESP_SALIDSU_UnRegActualizarLlegada(ByRef x_desp_salidas As EDESP_Salidas, ByVal x_usuario As String) As Integer
      Dim m_desp_salidas As New DDESP_Salidas()
      Try
         Return m_desp_salidas.DESP_SALIDSU_UnRegActualizarLlegada(x_desp_salidas, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

