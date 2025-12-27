Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration

Public Class BCorrelativos


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
   ''' Obtener correlativos segun la sucursal y el año
   ''' </summary>
   ''' <param name="x_sucur_id">codigo de sucursal</param>
   ''' <param name="x_tablas">codigo de la tabla</param>
   ''' <param name="x_ano">año</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetCorrelativo(ByVal x_sucur_id As Long, ByVal x_tablas As ECorrelativos.NTabla, ByVal x_ano As String) As Boolean
      Try
         m_correlativos = New ECorrelativos()
         m_correlativos.CORRE_Tabla = ECorrelativos.getTabla(x_tablas)
         m_correlativos.CORRE_Ano = x_ano
         m_correlativos.SUCUR_Id = x_sucur_id
         If d_correlativos.CORRSS_UnRegGetCorrelativo(m_correlativos) Then
            m_correlativos.Instanciar(ACFramework.ACEInstancia.Modificado)
            m_correlativos.CORRE_Numero += 1
         Else
            m_correlativos.CORRE_Numero = 1
            m_correlativos.CORRE_Ano = x_ano
            m_correlativos.CORRE_Descripcion = String.Format("Correlativo Tabla : {0}", ECorrelativos.getTabla(x_tablas))
            m_correlativos.CORRE_Tabla = ECorrelativos.getTabla(x_tablas)
            m_correlativos.CORRE_Id = GetCorrelativo()
            m_correlativos.Instanciar(ACFramework.ACEInstancia.Nuevo)
         End If
         m_correlativos.Codigo = x_ano & m_correlativos.CORRE_Numero.ToString().PadLeft(8, "0")
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener correlativo segun la sucursal
   ''' </summary>
   ''' <param name="x_sucur_id">codigo de la sucursal</param>
   ''' <param name="x_tablas">codigo de la tabla</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetCorrelativo(ByVal x_sucur_id As Long, ByVal x_tablas As ECorrelativos.NTabla) As Boolean
      Try
         Dim d_correlativos As New DCorrelativos()
         m_correlativos = New ECorrelativos()
         m_correlativos.CORRE_Tabla = ECorrelativos.getTabla(x_tablas)
         m_correlativos.CORRE_Ano = "0000"
         m_correlativos.SUCUR_Id = x_sucur_id
         If d_correlativos.CORRSS_UnRegGetCorrelativo(m_correlativos) Then
            m_correlativos.Instanciar(ACFramework.ACEInstancia.Modificado)
            m_correlativos.CORRE_Numero += 1
         Else
            m_correlativos.CORRE_Numero = 1
            m_correlativos.CORRE_Ano = "0000"
            m_correlativos.CORRE_Descripcion = "Correlativo Tabla : " & ECorrelativos.getTabla(x_tablas)
            m_correlativos.CORRE_Tabla = ECorrelativos.getTabla(x_tablas)
            m_correlativos.CORRE_Id = GetCorrelativo()
            m_correlativos.Instanciar(ACFramework.ACEInstancia.Nuevo)
         End If
         m_correlativos.Codigo = m_correlativos.CORRE_Numero.ToString().PadLeft(8, "0")
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' setear el correlativo en la tabla de correlativos
   ''' </summary>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function SetCorrelativo(ByVal x_usuario As String) As Boolean
      Try
         Dim d_correlativos As New DCorrelativos()
         If m_correlativos.Nuevo Then
            d_correlativos.CORRESI_UnReg(m_correlativos, x_usuario)
         ElseIf m_correlativos.Modificado Then
            d_correlativos.CORRSU_UnRegSetCorrelativo(m_correlativos, x_usuario)
         End If
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region


End Class

