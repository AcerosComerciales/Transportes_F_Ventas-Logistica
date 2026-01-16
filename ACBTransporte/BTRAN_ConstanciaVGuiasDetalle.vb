Imports System.Data.Common
Imports ACDTransporte
Imports ACETransporte
Imports ACFramework
Imports DAConexion

Public Class BTRAN_ConstanciaVGuiasDetalle
#Region " Variables "
    Private m_formatofecha As String
    Private m_tran_constanciavguiasdetalle As ETRAN_ConstanciaVGuiasDetalle
    Private m_listTRAN_constanciavguiasdetalle As List(Of ETRAN_ConstanciaVGuiasDetalle)
    Private d_tran_constanciavguiasdetalle As DTRAN_ConstanciaVGuiasDetalle 
    Public ReadOnly Property Tabla() As String
        Get
            Return "DIST_GuiasRemisionDetalle"
        End Get
    End Property
    Public ReadOnly Property Esquema() As String
        Get
            Return "Logistica"
        End Get
    End Property
#End Region
#Region " Constructores "
	
    Public Sub New()
        d_tran_constanciavguiasdetalle = New DTRAN_ConstanciaVGuiasDetalle()
        m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
    End Sub
    
   
       
   

#End Region

#Region " Propiedades "
    
    Public Property TRAN_ConstanciaVGuiasDetalle() As ETRAN_ConstanciaVGuiasDetalle 
        Get
            return m_tran_constanciavguiasdetalle
        End Get
        Set(ByVal value As ETRAN_ConstanciaVGuiasDetalle)
            m_tran_constanciavguiasdetalle = value
        End Set
    End Property
    Public Property ListTRAN_ConstanciaVGuiasDetalle() As List(Of ETRAN_ConstanciaVGuiasDetalle)
        Get
            return m_listTRAN_constanciavguiasdetalle
        End Get
        Set(ByVal value As List(Of ETRAN_ConstanciaVGuiasDetalle))
            m_listTRAN_constanciavguiasdetalle = value
        End Set
    End Property
#End Region
#Region " Metodos "
    Public Function Guardar(ByVal x_usuario As String) As Boolean
        Try
            If m_tran_constanciavguiasdetalle.Nuevo Then
                d_tran_constanciavguiasdetalle.TRAN_CONSTVGuiasDetalleSI_UnReg(m_tran_constanciavguiasdetalle, x_usuario)
            ElseIf m_tran_constanciavguiasdetalle.Modificado Then
                d_tran_constanciavguiasdetalle.TRAN_CONSTVGuiasDetalleSU_UnReg(m_tran_constanciavguiasdetalle, x_usuario)
            ElseIf m_tran_constanciavguiasdetalle.Eliminado Then
                d_tran_constanciavguiasdetalle.TRAN_CONSTVGuiasDetalleSD_UnReg(m_tran_constanciavguiasdetalle)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CargarTodos( ByVal x_where As Hashtable) As Boolean
        Try
            m_listTRAN_constanciavguiasdetalle = new List(Of ETRAN_ConstanciaVGuiasDetalle)()
            return TRAN_CONSTANCIAVGUIASDETSS_Todos(m_listTRAN_constanciavguiasdetalle,  x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    #Region "Procedimientos Almacenados"
    Public Function TRAN_CONSTANCIAVGUIASDETSS_Todos(ByRef x_listTRAN_ConstanciaVGuiasDetalle As List(Of ETRAN_ConstanciaVGuiasDetalle),  ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectall( x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows
                    Dim _utilitarios As New ACEsquemas(New ETRAN_ConstanciaVGuiasDetalle())
                    While reader.Read()
                        Dim x_etran_guiasdetalle As New ETRAN_ConstanciaVGuiasDetalle()
                        _utilitarios.ACCargarEsquemas(reader, x_etran_guiasdetalle)
                        x_etran_guiasdetalle.Instanciar(ACEInstancia.Consulta)
                        x_listTRAN_ConstanciaVGuiasDetalle.Add(x_etran_guiasdetalle)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    #Region "Procedimientos Adicionales"
    
    

    Private Function getSelectAll(ByVal x_where As HashTable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  * " & vbNewLine
            sql &= " FROM Transportes.TRAN_ConstanciaVGuiasDetalle" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRAN_ConstanciaVGuiasDetalle)(m_formatofecha)
            sql &= _where.getWhere(x_where, True) 

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
