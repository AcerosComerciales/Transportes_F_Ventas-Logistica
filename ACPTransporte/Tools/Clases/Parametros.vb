Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel

Imports ACBTransporte
Imports ACETransporte
Imports ACFramework

Imports ACEVentas
Imports ACBVentas

Public Class Parametros
#Region " Variables "
   Private Shared m_instance As Parametros
   Private Shared m_listParametros As List(Of EParametros)
   Private managerParametros As BParametros

   Private Shared m_param_nombre As String
   Private Shared m_param_valor As String

    Private Shared x_existe As Boolean

   Enum TipoParametros
      PIGV
      pg_CondXVehi
      pg_FormatoFecha
      pg_ocultarGrafi
      pg_NeumaMoneda
      pg_FMondo2d
      pg_FMondo3d
      pg_FMondo4d
      pg_FFechaHora
      pg_LongTexAyuda
      pg_VendedorDefa
      pg_NotCredCuot
      Empresa
      EmpresaRS
   End Enum

#End Region

#Region " Propiedades "

   Public Shared Property ListParametros() As List(Of EParametros)
      Get
         Return m_listParametros
      End Get
      Set(ByVal value As List(Of EParametros))
         m_listParametros = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New()

   End Sub

   Private Sub New(ByVal x_zona_codigo As String, ByVal x_sucr_codigo As Integer, ByVal x_para_aplicacion As String)
      m_listParametros = New List(Of EParametros)
      managerParametros = New BParametros
      CargarParametros(x_zona_codigo, x_sucr_codigo, x_para_aplicacion)
   End Sub

   Public Shared Function Inicializar(ByVal x_zona_codigo As String, ByVal x_sucr_codigo As Integer, ByVal x_para_aplicacion As String) As Parametros
      If m_instance Is Nothing Then
         m_instance = New Parametros(x_zona_codigo, x_sucr_codigo, x_para_aplicacion)
      End If
      Return m_instance
   End Function
#End Region

#Region " Metodos "
   Private Sub CargarParametros(ByVal x_zona_codigo As String, ByVal x_sucr_codigo As String, ByVal x_para_aplicacion As String)
      Try
         '' Cargar las Parametros propias
         Dim _where As New Hashtable()
         _where.Add("ZONAS_Codigo", New ACWhere(x_zona_codigo, ACWhere.TipoWhere.Igual))
         _where.Add("SUCUR_Id", New ACWhere(x_sucr_codigo, ACWhere.TipoWhere.Igual))
         _where.Add("APLIC_Codigo", New ACWhere(x_para_aplicacion, ACWhere.TipoWhere.Igual))
         managerParametros.CargarTodos(_where)
         m_listParametros = New List(Of EParametros)(managerParametros.ListParametros)

         '' Cargar las Parametros Globales
         _where = New Hashtable()
         _where.Add("ZONAS_Codigo", New ACWhere("", ACWhere.TipoWhere.Igual))
         _where.Add("SUCUR_Id", New ACWhere(0, ACWhere.TipoWhere.Igual))
         _where.Add("APLIC_Codigo", New ACWhere("", ACWhere.TipoWhere.Igual))
         managerParametros.CargarTodosGlobal()
         '' Cargar
         For Each Item As EParametros In managerParametros.ListParametros
            m_listParametros.Add(Item)
         Next
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Shared Function GetParametro(ByVal x_param_nombre As EParametros.TipoParametros) As Object
      Try
         Return GetParametro(x_param_nombre.ToString(), x_existe)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function GetParametro(ByVal x_param_nombre As EParametros.TipoParametros, ByRef _existe As Boolean) As Object
      Try
         Return GetParametro(x_param_nombre.ToString(), _existe)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function GetOnlyParametro(ByVal x_param_nombre As String) As Object
      Try
         Dim _existe As Boolean
         Return GetParametro(x_param_nombre, _existe)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function GetParametro(ByVal x_param_nombre As String, ByRef _existe As Boolean) As Object
      Try
         Dim _filter As New ACFramework.ACFiltrador(Of EParametros)() With {.ACFiltro = String.Format("PARMT_Id={0}", x_param_nombre)}
         Dim _list As New List(Of EParametros)(_filter.ACFiltrar(m_listParametros))
         If _list.Count > 0 Then
            Try
               _existe = True
               x_existe = True
               Dim TDato As String = _list(0).PARMT_TipoDato
               Select Case TDato
                  Case "Integer"
                     If IsNumeric(_list(0).PARMT_Valor) Then
                        Return CType(_list(0).PARMT_Valor, Integer)
                     Else
                        Throw New Exception("El tipo de datos no es Numerico")
                     End If
                  Case "String"
                     Return CType(_list(0).PARMT_Valor, String)
                  Case "Boolean"
                     Return CType(_list(0).PARMT_Valor, Boolean)
                  Case "Decimal"
                     If IsNumeric(_list(0).PARMT_Valor) Then
                        Return CType(_list(0).PARMT_Valor, Decimal)
                     Else
                        Throw New Exception("El tipo de datos no es Numerico")
                     End If
                  Case Else
                     Return _list(0).PARMT_Valor.ToString()
               End Select
            Catch ex As Exception
               _existe = False
               x_existe = False
               Throw New Exception(String.Format("Tipo de dato erroneo.{0}{1}", vbNewLine, ACFramework.ACUtilitarios.ACGetMensajeError(ex)))
            End Try
         Else
            x_existe = False
            _existe = False
            Return ""
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Metodos de Controles"

#End Region
End Class
