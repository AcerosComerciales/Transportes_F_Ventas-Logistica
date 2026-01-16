Imports ACBVentas
Imports ACDTransporte
Imports ACETransporte
Imports ACEVentas
Imports ACFramework
Imports DAConexion

Public Class BTRAN_ConstanciaVPesosMedidas
    #Region "Variables"
    Private m_tran_constanciasvpesosmedidas As ETRAN_ConstanciaVPesosMedidas
    Private d_tran_constanciasvpesosmedidas As DTRAN_ConstanciaVPesosMedidas
    Private m_listTRAN_ConstanciaVPesosMedidas As List(Of ETRAN_ConstanciaVPesosMedidas)
#End Region
    
#Region " Constructores "
	
    Public Sub New()
        d_tran_constanciasvpesosmedidas = New DTRAN_ConstanciaVPesosMedidas()
    End Sub

#End Region
#Region "Metodos"
    Public Function REPOS_ConstanciasVPesosMedidas(ByVal x_const_codigo As String) As Boolean
        m_tran_constanciasvpesosmedidas = New ETRAN_ConstanciaVPesosMedidas
        Try
            Return d_tran_constanciasvpesosmedidas.REPOSS_ConstanciaVPesosMedidas(m_tran_constanciasvpesosmedidas, x_const_codigo)
        Catch ex As Exception
            Throw ex
        End Try
        End Function
    ''' <summary>
    ''' Obtener el numero correspondiente a la guia de remision
    ''' </summary>
    ''' <param name="x_serie">serie del documento para la busqueda del correlativo</param>
    
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNumero(ByVal x_serie As String) As Integer
        Dim m_dgenerarcontanciaspesosmedidas As New DTRAN_ConstanciaVPesosMedidas
        Try
            Return m_dgenerarcontanciaspesosmedidas.getNumero(x_serie)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: LOG_DISTSS_ObtenerGuiaVenta
    ''' </summary>
    ''' <param name="x_guiar_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function GetConstanciaVPesosMedidas(ByVal x_const_codigo As String) As Boolean
        m_tran_constanciasvpesosmedidas = New ETRAN_ConstanciaVPesosMedidas
        Try
            Return d_tran_constanciasvpesosmedidas.TRAN_ConstanciaVPesosMedidas(m_tran_constanciasvpesosmedidas,x_const_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function Guardar(ByVal x_usuario As String, ByVal x_detalle As Boolean, Optional ByVal x_transaccion As Boolean = True) As Boolean
        Dim i As Integer = 1
        Try
            If x_transaccion Then DAEnterprise.BeginTransaction()
           ' m_tran_constanciasvpesosmedidas.CONST_Numero = getCorrelativo("CONST_Numero")
            m_tran_constanciasvpesosmedidas.CONST_Estado = ETRAN_ConstanciaVPesosMedidas.getEstado(ETRAN_ConstanciaVPesosMedidas.Estado.Ingresado)
            If Guardar(x_usuario) Then
                If x_detalle Then
                    Dim _btran_constanciasvguiasdetalle As New BTRAN_ConstanciaVGuiasDetalle
                    For Each item As ETRAN_ConstanciaVGuiasDetalle In m_tran_constanciasvpesosmedidas.ListETRAN_ConstanciaVGuiasDetalle
            
                        item.CONSGD_Item = i
                        Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                        _btran_constanciasvguiasdetalle.TRAN_ConstanciaVGuiasDetalle = item
                        _btran_constanciasvguiasdetalle.TRAN_ConstanciaVGuiasDetalle.CONST_Codigo = m_tran_constanciasvpesosmedidas.CONST_Codigo
                       
                        _btran_constanciasvguiasdetalle.Guardar(x_usuario)
                        i += 1
                    Next
                End If
                If x_transaccion Then DAEnterprise.CommitTransaction()
                Return True
            End If
        Catch ex As Exception
            If x_transaccion Then DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
    
    Public Function getCorrelativo(ByVal x_campo As String) As Integer
        Try
            Return d_tran_constanciasvpesosmedidas.getCorrelativo(x_campo) + 1 
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Guardar(ByVal x_usuario As String) As Boolean
        Try
            If m_tran_constanciasvpesosmedidas.Nuevo Then
                d_tran_constanciasvpesosmedidas.TRAN_CONSTVPesosMedidasSI_UnReg(m_tran_constanciasvpesosmedidas, x_usuario)
            ElseIf m_tran_constanciasvpesosmedidas.Modificado Then
                d_tran_constanciasvpesosmedidas.TRAN_CONSTVPesosMedidasSU_UnReg(m_tran_constanciasvpesosmedidas, x_usuario)
            ElseIf m_tran_constanciasvpesosmedidas.Eliminado Then
                d_tran_constanciasvpesosmedidas.TRAN_CONSTVPesosMedidasSD_UnReg(m_tran_constanciasvpesosmedidas)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    
    
    Public Function Busqueda(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long,   ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        m_listTRAN_ConstanciaVPesosMedidas = New List(Of ETRAN_ConstanciaVPesosMedidas)
        Try
            Return d_tran_constanciasvpesosmedidas.TRAN_BuscarConstanciasVPesosMedidas(m_listTRAN_ConstanciaVPesosMedidas, x_fecini, x_fecfin, x_pvent_id,   x_cadena, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CargarConstancia(ByVal x_codigo As String) As Boolean
        Try
           
            If Cargar(x_codigo) Then
                m_tran_constanciasvpesosmedidas = TRAN_ConstanciaVPesosMedidas
                Dim _where As New Hashtable()
                _where.Add("CONST_Codigo", New ACWhere(x_codigo))
                Dim m_bdist_docsvguiasdetalle As New BTRAN_ConstanciaVGuiasDetalle()
          
               
                If m_bdist_docsvguiasdetalle.CargarTodos( _where) Then
                    m_tran_constanciasvpesosmedidas.ListETRAN_ConstanciaVGuiasDetalle = New List(Of ETRAN_ConstanciaVGuiasDetalle)(m_bdist_docsvguiasdetalle.ListTRAN_ConstanciaVGuiasDetalle)
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cargar(ByVal x_const_codigo As String) As Boolean
        Try
            m_tran_constanciasvpesosmedidas = New ETRAN_ConstanciaVPesosMedidas()
            Return d_tran_constanciasvpesosmedidas.TRAN_CONSTANCIASVPM_UnReg(m_tran_constanciasvpesosmedidas, x_const_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region " Propiedades "
	
    Public Property TRAN_ConstanciaVPesosMedidas () As ETRAN_ConstanciaVPesosMedidas 
        Get
            return m_tran_constanciasvpesosmedidas
        End Get
        Set(ByVal value As ETRAN_ConstanciaVPesosMedidas )
            m_tran_constanciasvpesosmedidas = value
        End Set
    End Property
    Public Property ListTRAN_ConstanciaVPesosMedidas () As List(Of ETRAN_ConstanciaVPesosMedidas )
        Get
            return m_listTRAN_ConstanciaVPesosMedidas
        End Get
        Set(ByVal value As List(Of ETRAN_ConstanciaVPesosMedidas ))
            m_listTRAN_ConstanciaVPesosMedidas = value
        End Set
    End Property


#End Region
End Class
