Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration

Imports ACFramework

Public Class BCuentas


#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "
   Public Property CuentasDT() As DataTable
      Get
         Return m_dtCuentas
      End Get
      Set(ByVal value As DataTable)
         m_dtCuentas = value
      End Set
   End Property
#End Region

#Region " Funciones para obtencion de datos "
   Public Function CargarTodosDT() As DataTable
      Dim d_cuentas As New DCuentas()
      Try
         m_listCuentas = New List(Of ECuentas)()
         Return d_cuentas.CUENTSS_TodosDT
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodosLTD() As Boolean
      Dim d_cuentas As New DCuentas()
      Try
         m_listCuentas = New List(Of ECuentas)()
         m_dtCuentas = New DataTable()
         Return d_cuentas.CUENTSS_Todos(m_listCuentas, m_dtCuentas)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GuardarT(ByVal x_usuario As String) As Boolean

   End Function


#End Region

#Region " Metodos "

   ''' <summary>
   ''' obtener el correltivo de la tabla cuentas
   ''' </summary>
   ''' <param name="x_cuencod">correlativo que se obtendra</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCodCorrelativo(ByRef x_cuencod As Integer) As String
      Try
         x_cuencod = d_cuentas.getCorrelativo() + 1
         Dim x_codigo As String = x_cuencod.ToString()
         Return x_codigo
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' busqueda de cuentas
   ''' </summary>
   ''' <param name="x_cadena">cadenas de busqueda</param>
   ''' <param name="x_todos">mostrar todos los registros incluidos los anulados</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         m_listCuentas = New List(Of ECuentas)()
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EBancos.Esquema, EBancos.Tabla, ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("BANCO_Id", "BANCO_Id")} _
                              , New ACCampos() {New ACCampos("BANCO_Descripcion", "BANCO_Descripcion")}))

         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "Tcuentas", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoCuenta")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoCuenta")}))

         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "Tmonedas", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoMoneda")}))


         Dim _where As New Hashtable()

         If Not x_todos Then
            _where.Add("CUENT_Estado", New ACWhere(ECuentas.getEstado(ECuentas.Estado.Activo), ACWhere.TipoWhere.Igual))
         End If
         Return CargarTodos(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

