Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration


Public Class BPrecios

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
   ''' genera un scrip SQl para grabar el precio
   ''' </summary>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GuardarSQL(ByVal x_usuario As String) As String
      Try
         If m_precios.Nuevo Then
            Return d_precios.PRECISI_UnRegSQL(m_precios, x_usuario)
         ElseIf m_precios.Modificado Then
            Return d_precios.PRECISU_UnRegSQL(m_precios, x_usuario)
         ElseIf m_precios.Eliminado Then
            Return d_precios.PRECISD_UnReg(m_precios)
         End If
         Return ""
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

