Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration

Public Class BTRAN_DocumentosDetalle

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "
    Public Function TRAN_VMAN_ObtenerMantenimientosDocumentos_Detalle(ByVal x_docus_codigo As String, ByVal x_entid_codigo As String) As Boolean
        Dim d_TRAN_Vehiculos_DocumentosDetalles As New DTRAN_DocumentosDetalle()
        m_listTRAN_DocumentosDetalle = New List(Of ETRAN_DocumentosDetalle)

        Try
            Return d_tran_documentosdetalle.TRAN_VMAN_ObtenerMantenimientosDocumentos_Detalle(m_listTRAN_DocumentosDetalle, x_docus_codigo, x_entid_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " Metodos "

#End Region

End Class

