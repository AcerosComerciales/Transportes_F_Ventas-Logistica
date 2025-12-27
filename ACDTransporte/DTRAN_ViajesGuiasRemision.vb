Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_ViajesGuiasRemision

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "

   Public Function ObtenerGuias(ByVal x_cadena As String, ByVal x_listTRAN_ViajesGuiasRemision As List(Of ETRAN_ViajesGuiasRemision))
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= String.Format(App.Hash("DTRAN_ViajesGuiasRemision.ObtenerGuias"), x_cadena)
         DAEnterprise.AsignarProcedure(sql, CommandType.Text)

         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_viajesguias As New ETRAN_ViajesGuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, e_viajesguias)
                  e_viajesguias.Instanciar(ACEInstancia.Consulta)
                  x_listTRAN_ViajesGuiasRemision.Add(e_viajesguias)
               End While
               Dim _listGuiaRemision As New List(Of ETRAN_ViajesGuiasRemision)
               Dim _utilitariosdet As New ACEsquemas(New ETRAN_ViajesGuiasRemision)
               If reader.NextResult() Then
                  While reader.Read()
                     Dim _guia_remision As New ETRAN_ViajesGuiasRemision
                     _utilitariosdet.ACCargarEsquemas(reader, _guia_remision)
                     _guia_remision.Instanciar(ACEInstancia.Consulta)
                     _listGuiaRemision.Add(_guia_remision)
                  End While
               End If
               Dim _filtrador As New ACFiltrador(Of ETRAN_ViajesGuiasRemision)
               Dim _order As New ACOrdenador(Of ETRAN_ViajesGuiasRemision)("Serie ASC, Numero ASC")
               _listGuiaRemision.Sort(_order)
               For Each _guia As ETRAN_ViajesGuiasRemision In x_listTRAN_ViajesGuiasRemision
                  _filtrador.ACFiltro = String.Format("ENTID_Codigo={0}", _guia.ENTID_Codigo.Trim)
                  _guia.ListETRAN_ViajesGuiasRemision = _filtrador.ACFiltrar(_listGuiaRemision)
               Next
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

