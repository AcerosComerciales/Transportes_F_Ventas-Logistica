Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Imports ACFramework

Partial Public Class BTRAN_Piezas

#Region " Variables "
   Private m_datos As DataSet
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "

   Public Property Datos() As DataSet
      Get
         Return m_datos
      End Get
      Set(ByVal value As DataSet)
         m_datos = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   Public Function Cargar(ByVal x_pieza_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Dim _where As New Hashtable
      Try
         m_tran_piezas = New ETRAN_Piezas()
         _where.Add("PIEZA_Codigo", New ACWhere(x_pieza_codigo))
         If Cargar(_where) Then
            Return True
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Guardar(ByVal x_usuario As String, ByVal x_opcion As Boolean) As Boolean
      Try
         If m_tran_piezas.Nuevo Then
            d_tran_piezas.TRAN_PIEZASI_UnReg(m_tran_piezas, x_usuario)
         ElseIf m_tran_piezas.Modificado Then
            d_tran_piezas.TRAN_PIEZASU_UnReg(m_tran_piezas, x_usuario)
         ElseIf m_tran_piezas.Eliminado Then
            d_tran_piezas.TRAN_PIEZASD_UnReg(TRAN_Piezas)
         End If
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Busqueda(ByVal x_cadena As String) As Boolean
      Dim _where As New Hashtable
      Try
         m_listTRAN_Piezas = New List(Of ETRAN_Piezas)()
         _where.Add("PIEZA_Descripcion", New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         Return CargarTodos(_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   Public Function Ayuda(ByVal x_opcion As String, ByVal x_cadena As String) As Boolean
      m_datos = New DataSet
      Try
         Return d_tran_piezas.getAyuda(m_datos, x_opcion, x_cadena)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

