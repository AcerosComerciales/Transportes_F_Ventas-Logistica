Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration

Public Class BTRAN_GuiasTransportista

#Region " Variables "
   Private m_datos As DataTable
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "

   Public Property Datos() As DataTable
      Get
         Return m_datos
      End Get
      Set(ByVal value As DataTable)
         m_datos = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   Public Function GetGuiasRemision(ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByVal x_id_cliente As String) As Boolean
      Try
         m_datos = New DataTable
         m_listTRAN_GuiasTransportista = New List(Of ETRAN_GuiasTransportista)
         Return d_tran_guiastransportista.GetGuiasRemision(m_listTRAN_GuiasTransportista, x_fecini, x_fecfin, x_id_cliente)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Negocio: TRAN_GUIASS_RepRecCemento
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <param name="x_opcion">Parametro 3: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_GUIASS_RepRecCemento(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_opcion As Short) As Boolean
      m_listtran_guiastransportista = New List(Of ETRAN_GuiasTransportista)
      Try
         Return d_tran_guiastransportista.TRAN_GUIASS_RepRecCemento(m_listtran_guiastransportista, x_fecini, x_fecfin, x_opcion)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

