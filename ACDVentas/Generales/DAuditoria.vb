Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DAuditoria


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   ''' <summary> 
   ''' Capa de Datos: VENT_AUDISS_Autorizaciones
   ''' </summary>
   ''' <param name="x_audit_codigoreferencia">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_AUDISS_Autorizaciones(ByVal m_listauditoria As List(Of EAuditoria), ByVal x_audit_codigoreferencia As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_AUDISS_Autorizaciones")
         DAEnterprise.AgregarParametro("@AUDIT_CodigoReferencia", x_audit_codigoreferencia, DbType.String, 12)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _auditoria As New EAuditoria()
                  ACEsquemas.ACCargarEsquema(reader, _auditoria)
                  _auditoria.Instanciar(ACEInstancia.Consulta)
                  m_listauditoria.Add(_auditoria)
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

