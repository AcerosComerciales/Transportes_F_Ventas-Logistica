Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration

Public Class BVENT_ListaPreciosArticulos


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
   ''' Generar scrip SQL para grabar la lista de precios
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GuardarSQL(ByVal x_usuario As String) As String
      Try
         If m_vent_listapreciosarticulos.Nuevo Then
            Return d_vent_listapreciosarticulos.VENT_ALPRESI_UnRegSQL(m_vent_listapreciosarticulos, x_usuario)
         ElseIf m_vent_listapreciosarticulos.Modificado Then
            Return d_vent_listapreciosarticulos.VENT_ALPRESU_UnRegSQL(m_vent_listapreciosarticulos, x_usuario)
         ElseIf m_vent_listapreciosarticulos.Eliminado Then
            Return d_vent_listapreciosarticulos.VENT_ALPRESD_UnReg(m_vent_listapreciosarticulos)
         End If
         Return ""
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Generar scrip SQl para graba la lista de precios
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GuardarPASQL(ByVal x_usuario As String) As String
      Try
         If m_vent_listapreciosarticulos.Nuevo Then
            Return d_vent_listapreciosarticulos.VENT_ALPRESI_UnRegSQL(m_vent_listapreciosarticulos, x_usuario)
         ElseIf m_vent_listapreciosarticulos.Modificado Then
            Return d_vent_listapreciosarticulos.VENT_ALPRESU_UnRegPASQL(m_vent_listapreciosarticulos, x_usuario)
         ElseIf m_vent_listapreciosarticulos.Eliminado Then
            Return d_vent_listapreciosarticulos.VENT_ALPRESD_UnReg(m_vent_listapreciosarticulos)
         End If
         Return ""
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

