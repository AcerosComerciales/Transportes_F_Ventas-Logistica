Imports ACDTransporte
Imports ACETransporte

Public Class BTRAN_ConstanciaVGuiasDetalle
#Region " Variables "
    Private m_tran_constanciavguiasdetalle As ETRAN_ConstanciaVGuiasDetalle
    Private m_listTRAN_constanciavguiasdetalle As List(Of ETRAN_ConstanciaVGuiasDetalle)
    Private d_tran_constanciavguiasdetalle As DTRAN_ConstanciaVGuiasDetalle 

#End Region
#Region " Constructores "
	
    Public Sub New()
        d_tran_constanciavguiasdetalle = New DTRAN_ConstanciaVGuiasDetalle()
        
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
#End Region
End Class
