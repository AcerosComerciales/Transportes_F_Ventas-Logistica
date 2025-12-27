Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACEVentas
Imports ACBVentas
Imports ACDLogistica

Imports DAConexion
Imports ACFramework

Public Class BAdministrarArticulos
#Region " Variables "
   Private d_administrararticulos As DAdministrarArticulos
   Private m_listarticulos As List(Of EArticulos)
#End Region

#Region " Propiedades "

   Public Property ListArticulos() As List(Of EArticulos)
      Get
         Return m_listarticulos
      End Get
      Set(ByVal value As List(Of EArticulos))
         m_listarticulos = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New()
      d_administrararticulos = New DAdministrarArticulos
   End Sub
#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Negocio: ARTICSS_OrdenarProductos
   ''' </summary>
   ''' <param name="x_perio_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_linea">Parametro 4: </param> 
   ''' <param name="x_sublinea">Parametro 5: </param> 
   ''' <param name="x_fecha">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ARTICSS_OrdenarProductos(ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String, ByVal x_linea As String, ByVal x_sublinea As String, ByVal x_fecha As Date) As Boolean
      m_listarticulos = New List(Of EArticulos)
      Try
         Return d_administrararticulos.ARTICSS_OrdenarProductos(m_listarticulos, x_perio_codigo, x_almac_id, x_zonas_codigo, x_linea, x_sublinea, x_fecha)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar listado de articulos
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Grabar(ByVal x_usuario As String) As Boolean
      Try

         For Each item As EArticulos In m_listarticulos
            Dim _articulo As New BArticulos
            _articulo.Articulos = item
            _articulo.Guardar(x_usuario)
         Next

      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Metodos de Controles"

#End Region
End Class
