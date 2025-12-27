Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration

Partial Public Class BDocumentos

#Region " Variables "
	
	Private m_documentos As EDocumentos
	Private m_listDocumentos As List(Of EDocumentos)
	Private m_dtDocumentos As DataTable

	Private m_dsDocumentos As DataSet
   Private Shared d_documentos As DDocumentos = Nothing


#End Region

#Region " Constructores "
	
	Public Sub New()
      d_documentos = New DDocumentos
   End Sub

#End Region

#Region " Propiedades "
	
   Public Property Documentos() As EDocumentos
      Get
         Return m_documentos
      End Get
      Set(ByVal value As EDocumentos)
         m_documentos = value
      End Set
   End Property
   Public Property ListDocumentos() As List(Of EDocumentos)
      Get
         Return m_listDocumentos
      End Get
      Set(ByVal value As List(Of EDocumentos))
         m_listDocumentos = value
      End Set
   End Property
   Public Property DTDocumentos() As DataTable
      Get
         Return m_dtDocumentos
      End Get
      Set(ByVal value As DataTable)
         m_dtDocumentos = value
      End Set
   End Property
   Public Property DSDocumentos() As DataSet
      Get
         Return m_dsDocumentos
      End Get
      Set(ByVal value As DataSet)
         m_dsDocumentos = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
	

   Public Function getListDocumentos() As List(Of EDocumentos)
      Return Me.m_listDocumentos
   End Function
   Public Sub setListDocumentos(ByVal _listdocumentos As List(Of EDocumentos))
      Me.m_listDocumentos = m_listDocumentos
   End Sub
   Public Function getDocumentos() As EDocumentos
      Return Me.m_documentos
   End Function
   Public Sub setDocumentos(ByVal x_documentos As EDocumentos)
      Me.m_documentos = x_documentos
   End Sub
#End Region

#Region " Metodos "
	
   Public Function CargarTodos() As Boolean
      Try
         m_listDocumentos = New List(Of EDocumentos)()
         Return d_documentos.DOCMTSS_Todos(m_listDocumentos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
      Try
         m_listDocumentos = New List(Of EDocumentos)()
         Return d_documentos.DOCMTSS_Todos(m_listDocumentos, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
      Try
         m_listDocumentos = New List(Of EDocumentos)()
         Return d_documentos.DOCMTSS_Todos(m_listDocumentos, x_join, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
      Try
         m_listDocumentos = New List(Of EDocumentos)()
         Return d_documentos.DOCMTSS_Todos(m_listDocumentos, x_join, x_where, x_distinct)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
      Try
         m_dsDocumentos = New DataSet()
         Return d_documentos.DOCMTSS_Todos(m_dsDocumentos, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
      Try
         m_dsDocumentos = New DataSet()
         Return d_documentos.DOCMTSS_Todos(m_dsDocumentos, x_join, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
      Try
         m_dsDocumentos = New DataSet()
         Dim _opcion As Boolean = d_documentos.DOCMTSS_Todos(m_dsDocumentos, x_where)
         If _opcion Then
            m_dtDocumentos = m_dsDocumentos.Tables(0)
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarTodosDT(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
      Try
         m_dsDocumentos = New DataSet()
         Dim _opcion As Boolean = d_documentos.DOCMTSS_Todos(m_dsDocumentos, x_join, x_where)
         If _opcion Then
            m_dtDocumentos = m_dsDocumentos.Tables(0)
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Cargar(ByVal x_docmt_id As Long) As Boolean
      Try
         m_documentos = New EDocumentos()
         Return d_documentos.DOCMTSS_UnReg(m_documentos, x_docmt_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function Cargar(ByVal x_where As Hashtable) As Boolean
      Try
         m_documentos = New EDocumentos()
         Return d_documentos.DOCMTSS_UnReg(m_documentos, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
      Try
         m_documentos = New EDocumentos()
         Return d_documentos.DOCMTSS_UnReg(m_documentos, x_join, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function Guardar(ByVal x_usuario As String) As Boolean
      Try
         If m_documentos.Nuevo Then
            d_documentos.DOCMTSI_UnReg(m_documentos, x_usuario)
         ElseIf m_documentos.Modificado Then
            d_documentos.DOCMTSU_UnReg(m_documentos, x_usuario)
         ElseIf m_documentos.Eliminado Then
            d_documentos.DOCMTSD_UnReg(m_documentos)
         End If
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
      Try
         If m_documentos.Nuevo Then
            d_documentos.DOCMTSI_UnReg(m_documentos, x_usuario)
         ElseIf m_documentos.Modificado Then
            d_documentos.DOCMTSU_UnReg(m_documentos, x_where, x_usuario)
         ElseIf m_documentos.Eliminado Then
            d_documentos.DOCMTSD_UnReg(x_where)
         End If
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
      Try
         If m_documentos.Nuevo Then
            d_documentos.DOCMTSI_UnReg(m_documentos, x_usuario, x_setfecha)
         ElseIf m_documentos.Modificado Then
            d_documentos.DOCMTSU_UnReg(m_documentos, x_usuario, x_setfecha)
         ElseIf m_documentos.Eliminado Then
            d_documentos.DOCMTSD_UnReg(m_documentos)
         End If
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
      Try
         m_listDocumentos = New List(Of EDocumentos)()
         Return d_documentos.DOCMTSD_UnReg(x_where) > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getCorrelativo() As Integer
      Try
         Return d_documentos.getCorrelativo("DOCMT_Id") + 1
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function getCorrelativo(ByRef x_id As Integer) As Integer
      Try
         x_id = d_documentos.getCorrelativo("DOCMT_Id")
         Return (x_id + 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function getCorrelativo(ByVal x_campo As String) As Integer
      Try
         Return d_documentos.getCorrelativo(x_campo) + 1
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
      Try
         x_id = d_documentos.getCorrelativo(x_campo)
         Return (x_id + 1)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

