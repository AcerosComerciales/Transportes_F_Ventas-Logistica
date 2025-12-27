Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DReporte
#Region " Variables "
   Public Enum TRCuadreCaja
      Nuevo = 1
      Actual = 2
   End Enum
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#Region " Cuadre de Caja "
   ''' <summary> 
   ''' Capa de Datos: VENT_CAJASS_SaldoInicial
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_CAJASS_SaldoInicial(ByRef m_saldocaja As ESaldoCaja, ByVal x_fecini As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
      Try
         Select Case x_trcuadrecaja
            Case TRCuadreCaja.Actual
               DAEnterprise.AsignarProcedure("VENT_CAJASS_SaldoInicial")
            Case TRCuadreCaja.Nuevo
               DAEnterprise.AsignarProcedure("VENT_CCAJASS_SInicial")
            Case Else
               DAEnterprise.AsignarProcedure("VENT_CAJASS_SaldoInicial")
         End Select
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  m_saldocaja = New ESaldoCaja()
                  ACEsquemas.ACCargarEsquema(reader, m_saldocaja)
                  m_saldocaja.Instanciar(ACEInstancia.Consulta)
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
   ''' Capa de Datos: VENT_CAJASS_CuadreCaja_Facturas
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_CAJASS_CuadreCaja_Facturas(ByVal m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
      Try
         Select Case x_trcuadrecaja
            Case TRCuadreCaja.Actual
               DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Facturas")
            Case TRCuadreCaja.Nuevo
               DAEnterprise.AsignarProcedure("VENT_CCAJASS_Facturas")
            Case Else
               DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Facturas")
         End Select
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _ccuadrecaja As New ECCuadreCaja()
                  ACEsquemas.ACCargarEsquema(reader, _ccuadrecaja)
                  _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                  m_listccuadrecaja.Add(_ccuadrecaja)
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
    ''' Capa de Datos: VENT_CAJASS_CuadreCaja_Facturas_Creditos
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadreCaja_Facturas_Creditos(ByVal m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean ', ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        Try
            ' Select Case x_trcuadrecaja
            ' Case TRCuadreCaja.Actual
            DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Facturas_Creditos")
            '    Case TRCuadreCaja.Nuevo
            '        DAEnterprise.AsignarProcedure("VENT_CCAJASS_Facturas")
            '    Case Else
            '        DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Facturas")
            'End Select
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _ccuadrecaja As New ECCuadreCaja()
                        ACEsquemas.ACCargarEsquema(reader, _ccuadrecaja)
                        _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                        m_listccuadrecaja.Add(_ccuadrecaja)
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
   ''' Capa de Datos: VENT_CAJASS_CuadreCaja_Egresos
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_CAJASS_CuadreCaja_Egresos(ByVal m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
      Try
         Select Case x_trcuadrecaja
            Case TRCuadreCaja.Actual
                    DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Egresos")
            Case TRCuadreCaja.Nuevo
               DAEnterprise.AsignarProcedure("VENT_CCAJASS_Egresos")
            Case Else
                    DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Egresos")
         End Select
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 0
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _ccuadrecaja As New ECCuadreCaja()
                  ACEsquemas.ACCargarEsquema(reader, _ccuadrecaja)
                  _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                  m_listccuadrecaja.Add(_ccuadrecaja)
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
    ''' Capa de Datos: VENT_CAJASS_CuadreCaja_Egresos_Creditos
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadreCaja_Egresos_Creditos(ByVal m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean ', ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        Try
            'Select Case x_trcuadrecaja
            ' Case TRCuadreCaja.Actual
            DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Egresos_Creditos")
            '   Case TRCuadreCaja.Nuevo
            '  DAEnterprise.AsignarProcedure("VENT_CCAJASS_Egresos")
            '   Case Else
            ' DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Egresos")
            ' End Select
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 0
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _ccuadrecaja As New ECCuadreCaja()
                        ACEsquemas.ACCargarEsquema(reader, _ccuadrecaja)
                        _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                        m_listccuadrecaja.Add(_ccuadrecaja)
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
   ''' Capa de Datos: VENT_CAJASS_CuadreCaja_Egresos_Trans
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_CAJASS_CuadreCaja_Egresos_Trans(ByVal m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
      Try
         Select Case x_trcuadrecaja
            Case TRCuadreCaja.Actual
                    DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Egresos_Trans")
            Case TRCuadreCaja.Nuevo
               DAEnterprise.AsignarProcedure("VENT_CCAJASS_Egresos")
            Case Else
                    DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Egresos_Trans")
         End Select
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 0
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _ccuadrecaja As New ECCuadreCaja()
                  ACEsquemas.ACCargarEsquema(reader, _ccuadrecaja)
                  _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                  m_listccuadrecaja.Add(_ccuadrecaja)
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
   ''' Capa de Datos: VENT_CAJASS_CuadreCaja_Ingresos
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_CAJASS_CuadreCaja_Ingresos(ByVal m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
      Try
         Select Case x_trcuadrecaja
            Case TRCuadreCaja.Actual
               DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Ingresos")
            Case TRCuadreCaja.Nuevo
               DAEnterprise.AsignarProcedure("VENT_CCAJASS_Ingresos")
            Case Else
               DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Ingresos")
         End Select
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _ccuadrecaja As New ECCuadreCaja()
                  ACEsquemas.ACCargarEsquema(reader, _ccuadrecaja)
                  _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                  m_listccuadrecaja.Add(_ccuadrecaja)
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
    ''' Capa de Datos: VENT_CAJASS_CuadreCaja_Ingresos
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadreCaja_Ingresos_Creditos(ByVal m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean ', ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
        Try
            'Select Case x_trcuadrecaja
            ' Case TRCuadreCaja.Actual
            DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Ingresos_Creditos")
            ' Case TRCuadreCaja.Nuevo
            ' DAEnterprise.AsignarProcedure("VENT_CCAJASS_Ingresos")
            ' Case Else
            ' DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Ingresos")
            ' End Select
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _ccuadrecaja As New ECCuadreCaja()
                        ACEsquemas.ACCargarEsquema(reader, _ccuadrecaja)
                        _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                        m_listccuadrecaja.Add(_ccuadrecaja)
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
   ''' Capa de Datos: VENT_CAJASS_CuadreCaja_Ingresos_Trans
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_CAJASS_CuadreCaja_Ingresos_Trans(ByVal m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_trcuadrecaja As TRCuadreCaja) As Boolean
      Try
         Select Case x_trcuadrecaja
            Case TRCuadreCaja.Actual
               DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Ingresos_Trans")
            Case TRCuadreCaja.Nuevo
               DAEnterprise.AsignarProcedure("VENT_CCAJASS_Ingresos")
            Case Else
               DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadreCaja_Ingresos_Trans")
         End Select
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _ccuadrecaja As New ECCuadreCaja()
                  ACEsquemas.ACCargarEsquema(reader, _ccuadrecaja)
                  _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                  m_listccuadrecaja.Add(_ccuadrecaja)
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
   ''' Capa de Datos: VENT_CAJAS_CuadreCaja_Resumen
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
    Public Function VENT_CAJAS_CuadreCaja_Resumen(ByRef m_data As DataSet, ByRef m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_CAJAS_CuadreCaja_Resumen")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 0
            m_data = DAEnterprise.ExecuteDataSet()

            If m_data.Tables.Count >= 3 Then

                For Each item As DataRow In m_data.Tables(2).Rows
                    Dim _ccuadrecaja As New ECCuadreCaja()
                    ACEsquemas.ACCargarEsquema(item, _ccuadrecaja)
                    _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                    m_listccuadrecaja.Add(_ccuadrecaja)
                Next
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


    ''' <summary> 
    ''' Capa de Datos: VENT_CAJASS_CuadrePendientes
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_pvent_id">Parametro 2: </param> 
    ''' <param name="x_orden">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadrePendientes(ByVal m_listvcuadrependientes As List(Of ECCuadrePendientes), ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_orden As Short, ByVal x_tcuadre As TRCuadreCaja) As Boolean
        Try
            Select Case x_tcuadre
                Case TRCuadreCaja.Actual
                    DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadrePendientes")
                Case TRCuadreCaja.Nuevo
                    DAEnterprise.AsignarProcedure("VENT_CCAJASS_Pendientes")
            End Select
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Orden", x_orden, DbType.Int16, 1)
            DAEnterprise.CommandTimeOut = 0
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vcuadrependientes As New ECCuadrePendientes()
                        ACEsquemas.ACCargarEsquema(reader, _vcuadrependientes)
                        _vcuadrependientes.Instanciar(ACEInstancia.Consulta)
                        m_listvcuadrependientes.Add(_vcuadrependientes)
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
    ''' Capa de Datos: VENT_CAJASS_CuadrePendientesCreditos
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_pvent_id">Parametro 2: </param> 
    ''' <param name="x_orden">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadrePendientesCreditos(ByVal m_listvcuadrependientes As List(Of ECCuadrePendientes), ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_orden As Short) As Boolean ', ByVal x_tcuadre As TRCuadreCaja) As Boolean
        Try
            ' Select Case x_tcuadre
            ' Case TRCuadreCaja.Actual
            DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadrePendientesCreditos")
            '    Case TRCuadreCaja.Nuevo
            '  DAEnterprise.AsignarProcedure("VENT_CCAJASS_Pendientes")
            '  End Select
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Orden", x_orden, DbType.Int16, 1)
            DAEnterprise.CommandTimeOut = 0
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vcuadrependientes As New ECCuadrePendientes()
                        ACEsquemas.ACCargarEsquema(reader, _vcuadrependientes)
                        _vcuadrependientes.Instanciar(ACEInstancia.Consulta)
                        m_listvcuadrependientes.Add(_vcuadrependientes)
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
    ''' Capa de Datos: VENT_CAJASS_CuadrePendientes
    ''' </summary>
    ''' <param name="x_fecfin">Parametro 1: </param> 
    ''' <param name="x_pvent_id">Parametro 2: </param> 
    ''' <param name="x_orden">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CuadrePendientes(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_orden As Short) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_CAJASS_CuadrePendientes")
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Orden", x_orden, DbType.Int16, 1)
            DAEnterprise.CommandTimeOut = 0
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _listCPendientes As New List(Of ECCuadrePendientes)
                    While reader.Read()
                        Dim e_reportecaja As New ECCuadrePendientes()
                        ACEsquemas.ACCargarEsquema(reader, e_reportecaja)
                        e_reportecaja.Instanciar(ACEInstancia.Consulta)
                        _listCPendientes.Add(e_reportecaja)
                    End While

                    If reader.NextResult() Then
                        While reader.Read()
                            Dim _vent_docsventa As New EVENT_DocsVenta()
                            ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                            _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                            m_listvent_docsventa.Add(_vent_docsventa)
                        End While
                    End If

                    Dim _filtrador As New ACFiltrador(Of ECCuadrePendientes)
                    For Each item As EVENT_DocsVenta In m_listvent_docsventa
                        If item.ENTID_CodigoCliente.Equals("20455998094") Then
                            Dim i As Integer = 10000
                        End If
                        _filtrador.ACFiltro = String.Format("ENTID_Codigo={0}", item.ENTID_CodigoCliente.Trim())
                        item.ListCuadrePendientes = _filtrador.ACFiltrar(_listCPendientes)
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
    ''' Capa de Datos: VENT_CAJASS_CobranzaPendiente
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <param name="x_fecha">Parametro 5: </param> 
    ''' <param name="x_entid_codigovendedor">Parametro 6: </param> 
    ''' <param name="x_entid_codigocliente">Parametro 7: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CAJASS_CobranzaPendiente(ByVal m_listccuadrependientes As List(Of ECCuadrePendientes), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_fecha As Boolean, ByVal x_entid_codigovendedor As String, ByVal x_entid_codigocliente As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_CAJASS_CobranzaPendiente")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@ENTID_CodigoVendedor", x_entid_codigovendedor, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entid_codigocliente, DbType.String, 14)
            DAEnterprise.CommandTimeOut = 0
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _ccuadrependientes As New ECCuadrePendientes()
                        ACEsquemas.ACCargarEsquema(reader, _ccuadrependientes)
                        _ccuadrependientes.Instanciar(ACEInstancia.Consulta)
                        m_listccuadrependientes.Add(_ccuadrependientes)
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
    ''' Capa de Datos: LOG_DIST_CuadrePendientesVentas
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_almac_id">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_artic_codigo">Parametro 5: </param> 
    ''' <param name="x_entid_codigo">Parametro 6: </param> 
    ''' <param name="x_fecha">Parametro 7: </param> 
    ''' <param name="x_desbloqueo">Parametro 8: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_CuadrePendientesVentas(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_artic_codigo As String, ByVal x_entid_codigo As String, ByVal x_fecha As Boolean, ByVal x_desbloqueo As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_CuadrePendientesVentas")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
            DAEnterprise.CommandTimeOut = 5
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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

    Public Function LOG_DIST_CuadrePendientesReposicion(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_artic_codigo As String, ByVal x_entid_codigo As String, ByVal x_fecha As Boolean, ByVal x_desbloqueo As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_CuadrePendientesReposiciones")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
            DAEnterprise.CommandTimeOut = 120
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
    ''' facturaelectronica NC_a
    ''' </summary>
    ''' <param name="m_vent_docs"></param>
    ''' <param name="x_docve_codigo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function REPOSS_NotasCre(ByRef m_vent_docs As EVENT_DocsVenta, ByVal x_docve_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOS_NCElectronica")
            DAEnterprise.AgregarParametro("@docve_codigo", x_docve_codigo, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        m_vent_docs = New EVENT_DocsVenta()
                        ACEsquemas.ACCargarEsquema(reader, m_vent_docs)
                        m_vent_docs.Instanciar(ACEInstancia.Consulta)
                    End If
                    If reader.NextResult() Then
                        m_vent_docs.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        While reader.Read()
                            Dim _vent_pedidosdetalle As New EVENT_DocsVentaDetalle()
                            ACEsquemas.ACCargarEsquema(reader, _vent_pedidosdetalle)
                            _vent_pedidosdetalle.Instanciar(ACEInstancia.Consulta)
                            m_vent_docs.ListVENT_DocsVentaDetalle.Add(_vent_pedidosdetalle)
                        End While
                    End If
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

    Public Function REPOSS_Fac(ByRef m_vent_docs As EVENT_DocsVenta, ByVal x_docve_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOS_VentaElectronica")
            DAEnterprise.AgregarParametro("@docve_codigo", x_docve_codigo, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        m_vent_docs = New EVENT_DocsVenta()
                        ACEsquemas.ACCargarEsquema(reader, m_vent_docs)
                        m_vent_docs.Instanciar(ACEInstancia.Consulta)
                    End If
                    If reader.NextResult() Then
                        m_vent_docs.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        While reader.Read()
                            Dim _vent_pedidosdetalle As New EVENT_DocsVentaDetalle()
                            ACEsquemas.ACCargarEsquema(reader, _vent_pedidosdetalle)
                            _vent_pedidosdetalle.Instanciar(ACEInstancia.Consulta)
                            m_vent_docs.ListVENT_DocsVentaDetalle.Add(_vent_pedidosdetalle)
                        End While
                    End If
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
    Public Function REPOSS_Guias(ByRef m_dist_guia As EDIST_GuiasRemision, ByVal x_guiar_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOS_GuiaElectronica")
            DAEnterprise.AgregarParametro("@guiar_codigo", x_guiar_codigo, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        m_dist_guia = New EDIST_GuiasRemision()
                        ACEsquemas.ACCargarEsquema(reader, m_dist_guia)
                        m_dist_guia.Instanciar(ACEInstancia.Consulta)
                    End If
                    If reader.NextResult() Then
                        m_dist_guia.ListDIST_GuiasRemisionDetalle = New List(Of EDIST_GuiasRemisionDetalle)
                        While reader.Read()
                            Dim _dist_guiasdetalle As New EDIST_GuiasRemisionDetalle()
                            ACEsquemas.ACCargarEsquema(reader, _dist_guiasdetalle)
                            _dist_guiasdetalle.Instanciar(ACEInstancia.Consulta)
                            m_dist_guia.ListDIST_GuiasRemisionDetalle.Add(_dist_guiasdetalle)
                        End While
                    End If
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
    ''' Capa de Datos: LOG_DIST_CuadrePendientesOrdenes
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_almac_id">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_artic_codigo">Parametro 5: </param> 
    ''' <param name="x_entid_codigo">Parametro 6: </param> 
    ''' <param name="x_fecha">Parametro 7: </param> 
    ''' <param name="x_desbloqueo">Parametro 8: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    ''' 
    Public Function LOG_DIST_CuadrePendientesOrdenes(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_artic_codigo As String, ByVal x_entid_codigo As String, ByVal x_fecha As Boolean, ByVal x_desbloqueo As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_CuadrePendientesOrdenes")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
            DAEnterprise.CommandTimeOut = 0
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
    ''' Capa de Datos: LOG_DIST_CuadrePendientesIntegrado
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_almac_id">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_artic_codigo">Parametro 5: </param> 
    ''' <param name="x_entid_codigo">Parametro 6: </param> 
    ''' <param name="x_fecha">Parametro 7: </param> 
    ''' <param name="x_desbloqueo">Parametro 8: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_CuadrePendientesIntegrado(ByRef m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_artic_codigo As String, ByVal x_entid_codigo As String, ByVal x_fecha As Boolean, ByVal x_desbloqueo As Boolean) As Boolean
        Try
            'brother
            DAEnterprise.AsignarProcedure("LOG_DIST_CuadrePendientesIntegrado")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
            DAEnterprise.CommandTimeOut = 1200
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
    ''' Capa de Datos: LOG_DISTSS_ReporVentXCliente
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param>  
    ''' <param name="x_usuario">Parametro 3: </param> 
    ''' <param name="x_cliente">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DISTSS_ReporVentXCliente(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_usuario As String, ByVal x_cliente As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DISTSS_ReporVentXCliente")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@Usuario", x_usuario, DbType.String, 20)
            DAEnterprise.AgregarParametro("@Cliente", x_cliente, DbType.String, 11)
            DAEnterprise.CommandTimeOut = 1200
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventa As New EVENT_DocsVenta()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                        _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventa.Add(_vent_docsventa)
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
    ''' Capa de Datos: VENT_CCAJASS_Efectivo
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CCAJASS_Efectivo(ByVal m_listccuadrecaja As List(Of ECCuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_CCAJASS_Efectivo")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 1200
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _ccuadrecaja As New ECCuadreCaja()
                        ACEsquemas.ACCargarEsquema(reader, _ccuadrecaja)
                        _ccuadrecaja.Instanciar(ACEInstancia.Consulta)
                        m_listccuadrecaja.Add(_ccuadrecaja)
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
    ''' Capa de Datos: VENT_CCAJASS_SaldoInicialEfectivo
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_CCAJASS_SaldoInicialEfectivo(ByVal x_saldocaja As ESaldoCaja, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_CCAJASS_SaldoInicialEfectivo")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 1200
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_saldocaja)
                    x_saldocaja.Instanciar(ACEInstancia.Consulta)
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
    ''' Capa de Datos: VENT_REPOSS_MovimientoEfectivo
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_REPOSS_MovimientoEfectivo(ByVal m_listteso_docspagos As List(Of ETESO_DocsPagos), x_saldoInicial As ESaldoCaja, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_REPOSS_MovimientoEfectivo")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 1200
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _teso_docspagos As New ETESO_DocsPagos()
                        ACEsquemas.ACCargarEsquema(reader, _teso_docspagos)
                        _teso_docspagos.Instanciar(ACEInstancia.Consulta)
                        m_listteso_docspagos.Add(_teso_docspagos)
                    End While
                    If reader.NextResult() Then
                        reader.Read()
                        ACEsquemas.ACCargarEsquema(reader, x_saldoInicial)
                        x_saldoInicial.Instanciar(ACEInstancia.Consulta)
                    End If
                    Return True
                Else
                    If reader.NextResult() Then
                        reader.Read()
                        ACEsquemas.ACCargarEsquema(reader, x_saldoInicial)
                        x_saldoInicial.Instanciar(ACEInstancia.Consulta)
                    End If
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Datos: VENTSS_VentasXCliente
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigo">Parametro 3: </param> 
    ''' <param name="x_linea">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENTSS_VentasXCliente(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_linea As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENTSS_VentasXCliente")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 15)
            DAEnterprise.AgregarParametro("@Linea", x_linea, DbType.String, 15)
            DAEnterprise.CommandTimeOut = 1200
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
    ''' Capa de Datos: REPOSS_CuentasCorrientes
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigo">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_fecha">Parametro 5: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_CuentasCorrientes(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_fecha As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_CuentasCorrientes")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)
            DAEnterprise.CommandTimeOut = 2500

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventa As New EVENT_DocsVenta()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                        _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventa.Add(_vent_docsventa)
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

#Region " Reportes de Caja "

    ''' <summary> 
    ''' Capa de Datos: REPOSS_MovimientoCaja
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_MovimientoCaja(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_MovimientoCaja")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Datos: REPOSS_MovimientoCaja
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_ReporteCobranza(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_ReporteCobranza")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary> 
    ''' Capa de Datos: REPOSS_MovimientoCaja
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_ReporteBancarizacion(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_ReporteBancarizacion")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Datos: REPOSS_MovimientoCaja
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_ReporteVentasAnuladas(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_ReporteVentasAnuladas_Esp")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region " Reportes de Despachos "
    ''' <summary> 
    ''' Capa de Datos: REPOSS_MovimientoCaja
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_GuiasTraslado(ByRef m_data As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_GuiasTraslado")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Cotizaciones "
    ' <summary> 
    ' Capa de Datos: Lineas_a
    ' </summary>
    ' <param name="x_perio_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function lineas_Articulos(ByRef m_data As DataTable, ByVal x_articulo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("COTI_LineasArt")
            DAEnterprise.AgregarParametro("@Artic_Codigo", x_articulo, DbType.String, 10)

            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function





    ''' <summary> 
    ''' Capa de Datos: REPOSS_CotizacionVenta
    ''' </summary>
    ''' <param name="x_pedid_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_CotizacionVenta(ByRef m_vent_pedidos As EVENT_Pedidos, ByVal x_pedid_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_CotizacionVenta")
            DAEnterprise.AgregarParametro("@PEDID_Codigo", x_pedid_codigo, DbType.String, 12)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        m_vent_pedidos = New EVENT_Pedidos()
                        ACEsquemas.ACCargarEsquema(reader, m_vent_pedidos)
                        m_vent_pedidos.Instanciar(ACEInstancia.Consulta)
                    End If
                    If reader.NextResult() Then
                        m_vent_pedidos.ListDetPedidos = New List(Of EVENT_PedidosDetalle)
                        While reader.Read()
                            Dim _vent_pedidosdetalle As New EVENT_PedidosDetalle()
                            ACEsquemas.ACCargarEsquema(reader, _vent_pedidosdetalle)
                            _vent_pedidosdetalle.Instanciar(ACEInstancia.Consulta)
                            m_vent_pedidos.ListDetPedidos.Add(_vent_pedidosdetalle)
                        End While
                    End If
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

    Public Function LOG_DISTSS_ObtenerGestionOrdenReport(ByRef x_dist_ordenes As EABAS_GestionOrdenes, ByVal x_orden_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerGestionOrden")
            DAEnterprise.AgregarParametro("@GESTOR_Codigo", x_orden_codigo, DbType.String, 14)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_dist_ordenes)
                    x_dist_ordenes.Instanciar(ACEInstancia.Consulta)
                Else
                    Return False
                End If
                Dim _peso As Decimal = 0
                x_dist_ordenes.ListDIST_GestionOrdenesDetalle = New List(Of EABAS_GestionOrdenesDetalle)
                If reader.NextResult() Then
                    Dim _utilitariosdet As New ACEsquemas(New EABAS_GestionOrdenesDetalle)
                    While reader.Read()
                        Dim _ordendetalle As New EABAS_GestionOrdenesDetalle
                        _utilitariosdet.ACCargarEsquemas(reader, _ordendetalle)
                        _ordendetalle.Instanciar(ACEInstancia.Consulta)
                        x_dist_ordenes.ListDIST_GestionOrdenesDetalle.Add(_ordendetalle)

                    End While
                End If
                x_dist_ordenes.Peso = _peso
                Return True
            End Using
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function



#End Region

#Region " Reporte de Ventas "
    ''' <summary> 
    ''' Capa de Datos: REPOSS_VentasTodos
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_pvent_id">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_VentasTodos(ByRef m_listvent_docsventa As List(Of EVENT_DocsVenta), ByRef m_listvent_docsventacorr As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_opcion As Short, ByVal x_entid_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_VentasTodos")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventa As New EVENT_DocsVenta()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                        _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventa.Add(_vent_docsventa)
                    End While
                    If reader.NextResult() Then
                        While reader.Read()
                            Dim _vent_docsventa As New EVENT_DocsVenta()
                            ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                            _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                            m_listvent_docsventacorr.Add(_vent_docsventa)
                        End While
                    End If

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
    ''' Capa de Datos: REPOSS_EstadoCuentaCorriente
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigo">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function REPOSS_EstadoCuentaCorriente(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_EstadoCuentaCorriente")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventa As New EVENT_DocsVenta()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                        _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventa.Add(_vent_docsventa)
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

#Region " Stocks "

    ''' <summary> 
    ''' Capa de Datos: VENTSS_ListaPrecios
    ''' </summary>
    ''' <param name="x_perio_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <param name="x_zonas_codigo">Parametro 3: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENTSS_ListaPrecios(ByRef m_data As DataTable, ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String, ByVal x_articulo As String, ByVal x_linea As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENTSS_ListaPrecios")
            DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
            DAEnterprise.AgregarParametro("@Articulo", x_articulo, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Linea", x_linea, DbType.String, 10)
            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#End Region

#Region " Metodos de Controles"

#End Region
End Class
