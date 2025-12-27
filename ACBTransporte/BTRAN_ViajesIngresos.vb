Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports DAConexion
Imports ACFramework

Imports ACEVentas

Public Class BTRAN_ViajesIngresos


#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function Guardar(ByVal x_usuario As String, ByVal x_documento As Boolean, Optional ByVal x_tran As Boolean = True) As Boolean
      Dim m_btran_documentos As New BTRAN_Documentos()
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
         If m_tran_viajesingresos.Nuevo Then
            If x_documento Then
               m_btran_documentos.TRAN_Documentos = m_tran_viajesingresos.TRAN_Documentos
               m_btran_documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoDocumento.Substring(3, 2) _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Serie.Trim().PadLeft(3, "0") _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0"))
               m_btran_documentos.TRAN_Documentos.ENTID_Codigo = m_tran_viajesingresos.ENTID_Codigo
               Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
               m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_viajesingresos.VINGR_Monto / (_igv + 1), 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_viajesingresos.VINGR_Monto / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_viajesingresos.VINGR_Monto
               m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_viajesingresos.TIPOS_CodTipoMoneda
               m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_viajesingresos.VINGR_Fecha
               m_btran_documentos.crearDocumento(m_tran_viajesingresos.VINGR_Descripcion)
               m_btran_documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)

               Dim _where As New Hashtable()
               _where.Add("DOCUS_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.DOCUS_Codigo))
               _where.Add("ENTID_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.ENTID_Codigo))
               If m_btran_documentos.CargarTodos(_where) Then
                  Throw New Exception(String.Format("El Numero del documento {0}-{1}, ya existe para el proveedor: {2}{3}" _
                                                    , m_btran_documentos.TRAN_Documentos.DOCUS_Serie, m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0") _
                                                    , m_btran_documentos.TRAN_Documentos.ENTID_Codigo.Substring(1), vbNewLine))
               End If

               If m_btran_documentos.Guardar(x_usuario, True, False) Then
                  m_tran_viajesingresos.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo
                  m_tran_viajesingresos.ENTID_Codigo = m_btran_documentos.TRAN_Documentos.ENTID_Codigo
                  m_tran_viajesingresos.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
                  m_tran_viajesingresos.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
                  m_tran_viajesingresos.VINGR_Estado = ETRAN_ViajesIngresos.getEstado(ETRAN_ViajesIngresos.Estado.Ingresado)
                  If Guardar(x_usuario) Then
                     If x_tran Then DAEnterprise.CommitTransaction()
                     Return True
                  End If
               End If
            Else
               m_tran_viajesingresos.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
               m_tran_viajesingresos.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
               m_tran_viajesingresos.VINGR_Estado = ETRAN_ViajesIngresos.getEstado(ETRAN_ViajesIngresos.Estado.Ingresado)
               If Guardar(x_usuario) Then
                  If x_tran Then DAEnterprise.CommitTransaction()
                  Return True
               End If
            End If
         ElseIf m_tran_viajesingresos.Modificado Then
            If Guardar(x_usuario) Then
               m_btran_documentos.TRAN_Documentos = m_tran_viajesingresos.TRAN_Documentos
               Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
               m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_viajesingresos.VINGR_Monto / (_igv + 1), 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_viajesingresos.VINGR_Monto / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_viajesingresos.VINGR_Monto
               m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_viajesingresos.TIPOS_CodTipoMoneda
               m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_viajesingresos.VINGR_Fecha
               If m_btran_documentos.Guardar(x_usuario) Then
                  If x_tran Then DAEnterprise.CommitTransaction()
                  Return True
               End If
            End If
         End If
         Return False
      Catch ex As Exception
         If x_tran Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   Public Function GuardarRecibo(ByVal x_usuario As String, ByRef x_recibo As ETRAN_Recibos)
      Try
         DAEnterprise.BeginTransaction()
         Dim m_btran_recibos As New BTRAN_Recibos
         m_btran_recibos.TRAN_Recibos = x_recibo
         m_btran_recibos.TRAN_Recibos.Instanciar(ACEInstancia.Nuevo)
         If m_btran_recibos.Guardar(x_usuario) Then
            Dim m_btran_viajesingresos As New BTRAN_ViajesIngresos
            m_btran_viajesingresos.TRAN_ViajesIngresos = New ETRAN_ViajesIngresos
            m_btran_viajesingresos.TRAN_ViajesIngresos.VINGR_Id = m_tran_viajesingresos.VINGR_Id
            m_btran_viajesingresos.TRAN_ViajesIngresos.VIAJE_Id = m_tran_viajesingresos.VIAJE_Id
            m_btran_viajesingresos.TRAN_ViajesIngresos.RECIB_Codigo = x_recibo.RECIB_Codigo
            m_btran_viajesingresos.TRAN_ViajesIngresos.Instanciar(ACEInstancia.Modificado)
            m_btran_viajesingresos.Guardar(x_usuario)
            DAEnterprise.CommitTransaction()
            Return True
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   Public Function Cargar(ByVal x_viaje_id As Long, ByVal x_vingr_id As Long, ByVal x_detalle As Boolean) As Boolean
      Dim _join As New List(Of ACJoin)
      Dim _where As New Hashtable
      Try
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Left, _
                              New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")}, _
                              New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
         _where.Add("VIAJE_Id", New ACWhere(x_viaje_id))
         _where.Add("VINGR_Id", New ACWhere(x_vingr_id))
         If Cargar(_join, _where) Then
            Dim _documento As New BTRAN_Documentos
            If _documento.Cargar(m_tran_viajesingresos.DOCUS_Codigo, m_tran_viajesingresos.ENTID_Codigo) Then
               m_tran_viajesingresos.TRAN_Documentos = _documento.TRAN_Documentos
               Return True
            Else
               m_tran_viajesingresos.TRAN_Documentos = New ETRAN_Documentos
               Return True
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

