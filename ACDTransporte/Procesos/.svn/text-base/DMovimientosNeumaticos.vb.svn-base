Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Public Class DMovimientosNeumaticos

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function cargarMovimientos(ByVal x_docmt_id As Long, ByRef m_listNeumaticos As List(Of ETRAN_Neumaticos)) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectBy(x_docmt_id), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitariosMNeu As New ACEsquemas(New ETRAN_MovimientosNeumaticos())
               Dim _utilitariosVNeu As New ACEsquemas(New ETRAN_VehiculosNeumaticos())
               Dim _utilitariosNeu As New ACEsquemas(New ETRAN_Neumaticos())
               While reader.Read()
                  Dim e_neu As New ETRAN_Neumaticos(ETRAN_Neumaticos.TipoInicializacion.Movimientos)
                  _utilitariosNeu.ACCargarEsquemas(reader, e_neu)
                  _utilitariosMNeu.ACCargarEsquemas(reader, e_neu.TRAN_MovimientosNeumaticos)
                  _utilitariosVNeu.ACCargarEsquemas(reader, e_neu.TRAN_VehiculosNeumaticos)
                  e_neu.Instanciar(ACEInstancia.Consulta)
                  e_neu.TRAN_VehiculosNeumaticos.Instanciar(ACEInstancia.Consulta)
                  e_neu.TRAN_VehiculosNeumaticos.Instanciar(ACEInstancia.Consulta)
                  m_listNeumaticos.Add(e_neu)
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

#Region " Metodos "
   Public Function getSelectBy(ByVal x_docmt_id As Long) As String
      Dim sql As String = ""
      Try
         sql = " Select MNeu.*, VNeu.*, Neu.* from dbo.Documentos As Doc " & vbNewLine
         sql &= " Inner Join Transportes.TRAN_MovimientosNeumaticos As MNeu On MNeu.DOCMT_IDORDEN = Doc.DOCMT_ID" & vbNewLine
         sql &= " Inner Join Transportes.TRAN_VehiculosNeumaticos VNeu On VNeu.MOVNM_Id = MNeu.MOVNM_Id" & vbNewLine
         sql &= " Inner Join Transportes.TRAN_Neumaticos As Neu On Neu.NEUMA_Id = VNeu.NEUMA_Id" & vbNewLine
         sql &= " " & vbNewLine
         sql &= " " & vbNewLine
         sql &= " WHERE " & vbNewLine
         sql &= "Doc.DOCMT_ID = " + x_docmt_id.ToString() & vbNewLine
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region


End Class

