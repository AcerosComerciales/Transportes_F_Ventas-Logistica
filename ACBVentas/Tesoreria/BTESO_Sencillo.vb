Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_Sencillo

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
   ''' Capa de Negocio: TESO_SENCISS_UnReg
   ''' </summary>
   ''' <param name="x_senci_fecha">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TESO_SENCISS_UnReg(ByVal x_senci_fecha As Date, ByVal x_pvent_id As Long) As Boolean
      m_eteso_sencillo = New ETESO_Sencillo
      Try
         Return d_teso_sencillo.TESO_SENCISS_UnReg(m_eteso_sencillo, x_senci_fecha, x_pvent_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener la fecha del sistema
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetFecha() As DateTime
      Try
         Return d_teso_sencillo.getFecha()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: TESO_SENCISS_VerificarIngreso
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function TESO_SENCISS_VerificarIngreso(ByVal x_fecini As Date) As Boolean
      m_eteso_sencillo = New ETESO_Sencillo
      Try
         Return d_teso_sencillo.TESO_SENCISS_VerificarIngreso(m_eteso_sencillo, x_fecini)
      Catch ex As Exception
         Throw ex
      End Try
    End Function

   
#End Region

End Class

