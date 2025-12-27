Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte
Imports ACEVentas

Public Class DGCancelacion

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   ' <summary> 
   ' Capa de Datos: TRAN_CAJASS_FacturasXCancelar
   ' </summary>
   ' <param name="x_entid_codigo">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_CAJASS_FacturasXCancelar(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_entid_codigo As String, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_CAJASS_FacturasXCancelar")
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventa As New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                  _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventa.Add(_vent_docsventa)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos "
	
#End Region

End Class

