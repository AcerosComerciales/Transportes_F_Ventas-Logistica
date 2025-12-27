Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DGenerarCancelacion


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "

   ''' <summary> 
   ''' Procedimiento "VENT_DOCSS_TodosConSaldo" por el Generador 31/01/2012
   ''' </summary> 
   ''' <param name="m_listVENT_DocsVenta">Lista donde se cargaran los valores</param> 
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function VENT_DOCSS_TodosConSaldo(ByRef m_listVENT_DocsVenta As List(Of EVENT_DocsVenta), ByVal x_entid_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_DOCSS_TodosConSaldo")
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 12)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_vent_docsventa As New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, e_VENT_DocsVenta)
                  e_VENT_DocsVenta.Instanciar(ACEInstancia.Consulta)
                  m_listVENT_DocsVenta.Add(e_VENT_DocsVenta)
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

