Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_GuiasTransportista

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function GetGuiasRemision(ByRef listETRAN_GuiasTransportista As List(Of ETRAN_GuiasTransportista), ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByVal x_id_cliente As String) As Boolean
      Dim _sql As String = ""
      Try
         _sql &= String.Format("SELECT ID_Guia_Remision As GTRAN_Codigo{0}", vbNewLine)
         _sql &= String.Format("	, nro_serie As GTRAN_Serie{0}", vbNewLine)
         _sql &= String.Format("	, nro_guia As GTRAN_Numero{0}", vbNewLine)
         _sql &= String.Format("	, Venta As DocVenta{0}", vbNewLine)
         _sql &= String.Format("	, Id_Cliente As GTRAN_RucProveedor{0}", vbNewLine)
         _sql &= String.Format("	, Fecha_Emision As GTRAN_Fecha{0}", vbNewLine)
         _sql &= String.Format("	, Direccion_Entrega As GTRAN_DireccionDestinatario{0}", vbNewLine)
         _sql &= String.Format("	, Peso_Total As GTRAN_PesoTotal{0}", vbNewLine)
         _sql &= String.Format("	, (Case Anulada When 1 Then 'X' Else 'I' End) As GTRAN_Estado{0}", vbNewLine)
         _sql &= String.Format("	, Impresa{0}", vbNewLine)
         _sql &= String.Format("	, Fecha_Emision As GTRAN_FechaTraslado{0}", vbNewLine)
         _sql &= String.Format("	, Transportista As GTRAN_DescripcionVehiculo{0}", vbNewLine)
         _sql &= String.Format("FROM   Guia_Remision{0}", vbNewLine)
         _sql &= String.Format("WHERE  (Fecha_Emision BETWEEN '{1}' AND '{2}') AND (Id_Cliente = '{3}'){0}", vbNewLine, x_fecini.ToString("dd/MM/yyyy"), x_fecfin.ToString("dd/MM/yyyy"), x_id_cliente)
         _sql &= String.Format("ORDER BY Nro_Serie, nro_guia{0}", vbNewLine)

         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_GuiasTransportista())
               While reader.Read()
                  Dim e_tran_guiastransportista As New ETRAN_GuiasTransportista()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_guiastransportista)
                  e_tran_guiastransportista.Instanciar(ACEInstancia.Consulta)
                  listETRAN_GuiasTransportista.Add(e_tran_guiastransportista)
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


   ' <summary> 
   ' Capa de Datos: TRAN_GUIASS_RepRecCemento
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <param name="x_opcion">Parametro 3: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_GUIASS_RepRecCemento(ByVal m_listtran_guiastransportista As List(Of ETRAN_GuiasTransportista), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_opcion As Short) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_GUIASS_RepRecCemento")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _tran_guiastransportista As New ETRAN_GuiasTransportista()
                  ACEsquemas.ACCargarEsquema(reader, _tran_guiastransportista)
                  _tran_guiastransportista.Instanciar(ACEInstancia.Consulta)
                  m_listtran_guiastransportista.Add(_tran_guiastransportista)
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

End Class

