Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Imports System.Configuration
Imports ACFramework

Public Class BTipoCambio


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
   ''' obtener el ultimo tipo de cambio ingresado
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getUltTipoCambio() As Boolean
      Try
         Dim _where As New Hashtable
         _where.Add("TIPOC_Fecha", New ACWhere("select max(TIPOC_Fecha) from TipoCambio", ACWhere.TipoWhere._In))
         If Cargar(_where) Then
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el ultimo tipo de cambio oficina ingresado
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getUltTipoCambioOficina() As Boolean
      Try
         Dim _where As New Hashtable
         _where.Add("TIPOC_Fecha", New ACWhere("select max(TIPOC_Fecha) from TipoCambio Where IsNull(TIPOC_VentaOficina, 0) > 0", ACWhere.TipoWhere._In))
         If Cargar(_where) Then
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener el tipo de cambio oficina de una fecha
   ''' </summary>
   ''' <param name="x_fecha">fecha de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getTipoCambioOficina(ByVal x_fecha As Date) As Boolean
      Try
         Dim _where As New Hashtable
         _where.Add("TIPOC_Fecha", New ACWhere(String.Format("{0:yyyyMMdd}", x_fecha), ACWhere.TipoWhere.Igual))
         If Cargar(_where) Then
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el ultimo tipo de cambio sunat ingresado
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getUltTipoCambioSunat() As Boolean
      Try
         Dim _where As New Hashtable
         _where.Add("TIPOC_Fecha", New ACWhere("select max(TIPOC_Fecha) from TipoCambio Where IsNull(TIPOC_VentaSunat, 0) <> 0", ACWhere.TipoWhere._In))
         If Cargar(_where) Then
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el ultimo tipo de cambio sunat ingresado
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getTipoCambioSunat() As Boolean
      Try
         Dim _where As New Hashtable
         _where.Add("TIPOC_Fecha", New ACWhere(String.Format("{0:yyyyMMdd}", d_tipocambio.GetFecha()), ACWhere.TipoWhere.Igual))
         If Cargar(_where) Then
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener el tipo de cambio sunat segun fecha
   ''' </summary>
   ''' <param name="x_fecha">fecha de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getTipoCambioSunat(ByVal x_fecha As Date) As Boolean
      Try
         Dim _where As New Hashtable
         _where.Add("TIPOC_Fecha", New ACWhere(String.Format("{0:yyyyMMdd}", x_fecha), ACWhere.TipoWhere.Igual))
         If Cargar(_where) Then
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

