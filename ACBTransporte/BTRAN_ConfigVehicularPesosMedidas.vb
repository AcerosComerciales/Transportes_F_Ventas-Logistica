Imports ACDTransporte
Imports ACETransporte

Public Class BTRAN_ConfigVehicularPesosMedidas
#Region "Variables"
    Private m_tran_configvehicularpesosmedidas As ETRAN_ConfigVehicularPesosMedidas
    Private d_tran_configvehicularpesosmedidas As DTRAN_ConfigVehicularPesosMedidas
    Private m_listTRAN_ConfigVehicularPesosMedidas As List(Of ETRAN_ConfigVehicularPesosMedidas)
#End Region
#Region "Metodos"
    ''' <summary>
    ''' Obtener el numero correspondiente a la guia de remision
    ''' </summary>
    ''' <param name="x_serie">serie del documento para la busqueda del correlativo</param>
    
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPesoBrutoMax(ByVal x_tipo As String) As Decimal
        Dim m_dgenerarconfigvehicularpesosmedidas As New DTRAN_ConfigVehicularPesosMedidas
        Try
            Return m_dgenerarconfigvehicularpesosmedidas.getPesoBrutoMax(x_tipo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
