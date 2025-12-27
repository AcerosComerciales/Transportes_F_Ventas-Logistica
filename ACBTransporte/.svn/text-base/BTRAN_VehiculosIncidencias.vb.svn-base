Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration

Imports DAConexion
Imports ACFramework

Public Class BTRAN_VehiculosIncidencias

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function Guardar(ByVal x_usuario As String, ByVal x_documento As Boolean) As Boolean
      Dim m_btran_documentos As New BTRAN_Documentos()
      Try
         DAEnterprise.BeginTransaction()
         If x_documento Then
            m_btran_documentos.TRAN_Documentos = m_tran_vehiculosincidencias.TRAN_Documentos
            m_btran_documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoDocumento.Substring(3, 2) _
                                                                            , m_btran_documentos.TRAN_Documentos.DOCUS_Serie.Trim().PadLeft(3, "0") _
                                                                            , m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0"))
            m_btran_documentos.TRAN_Documentos.ENTID_Codigo = m_tran_vehiculosincidencias.ENTID_CodigoProveedor
            m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_vehiculosincidencias.INCVE_Pago
            m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_vehiculosincidencias.TIPOS_CodTipoMoneda
            m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_vehiculosincidencias.INCVE_Fecha
            m_btran_documentos.crearDocumento(m_tran_vehiculosincidencias.INCVE_Descripcion)
            m_btran_documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)
            If m_btran_documentos.Guardar(x_usuario, True, False) Then
               m_tran_vehiculosincidencias.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo
               m_tran_vehiculosincidencias.ENTID_CodigoProveedor = m_btran_documentos.TRAN_Documentos.ENTID_Codigo
               m_tran_vehiculosincidencias.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
               m_tran_vehiculosincidencias.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
               m_tran_vehiculosincidencias.INCVE_Estado = ETRAN_VehiculosIncidencias.getEstado(ETRAN_VehiculosIncidencias.Estado.Ingresado)
               If Guardar(x_usuario) Then
                  DAEnterprise.CommitTransaction()
                  Return True
               End If
            End If
         Else
            m_tran_vehiculosincidencias.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
            m_tran_vehiculosincidencias.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
            m_tran_vehiculosincidencias.INCVE_Estado = ETRAN_VehiculosIncidencias.getEstado(ETRAN_VehiculosIncidencias.Estado.Ingresado)
            If Guardar(x_usuario) Then
               DAEnterprise.CommitTransaction()
               Return True
            End If
         End If
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   Public Function Incidencias(ByVal x_vehic_id As Integer) As Boolean
      Dim _where As New Hashtable()
      Try
         _where.Add("VEHIC_Id", New ACWhere(x_vehic_id))
         m_listTRAN_VehiculosIncidencias = New List(Of ETRAN_VehiculosIncidencias)
         Return d_tran_vehiculosincidencias.GetIncidencias(m_listTRAN_VehiculosIncidencias, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

