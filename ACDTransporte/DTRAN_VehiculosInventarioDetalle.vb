Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_VehiculosInventarioDetalle

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	

   ' <summary> 
   ' Capa de Datos: TRAN_INVSS_TodosObjetosInventario
   ' </summary>
   ' <param name="x_vehic_id">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_INVSS_TodosObjetosInventario(ByVal m_listtran_vehiculosinventariodetalle As List(Of ETRAN_VehiculosInventarioDetalle), ByVal x_vehic_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_INVSS_TodosObjetosInventario")
         DAEnterprise.AgregarParametro("@VEHIC_Id", x_vehic_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _tran_vehiculosinventariodetalle As New ETRAN_VehiculosInventarioDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _tran_vehiculosinventariodetalle)
                  _tran_vehiculosinventariodetalle.Instanciar(ACEInstancia.Consulta)
                  m_listtran_vehiculosinventariodetalle.Add(_tran_vehiculosinventariodetalle)
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

#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
	
#End Region


End Class

