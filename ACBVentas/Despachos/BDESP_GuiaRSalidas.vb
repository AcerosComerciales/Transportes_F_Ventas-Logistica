Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BDESP_GuiaRSalidas

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
   ''' actuializar las guias que se generaron su salida
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GUIASU_ActualizarGuiaRSalidas(ByVal x_usuario As String) As Integer
      Try
         Return d_desp_guiarsalidas.GUIASU_ActualizarGuiaRSalidas(m_edesp_guiarsalidas, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

