Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports ACFramework
Imports ACBVentas

Public Class BTRAN_MovimientosNeumaticos

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function GuardarMovimientoInicial(ByVal x_usuario As String) As Boolean
      Try
         Dim d_tran_movimientosneumaticos As New DTRAN_MovimientosNeumaticos()
         If m_tran_movimientosneumaticos.Nuevo Then
            Dim _fecha As String() = {"MOVNM_Fecha", "MOVNM_FecAsignacion"}
            d_tran_movimientosneumaticos.TRAN_MOVNMSI_UnReg(m_tran_movimientosneumaticos, x_usuario, _fecha)
         End If
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GuardarMovimiento(ByVal x_usuario As String) As Boolean
      Try
         Dim d_tran_movimientosneumaticos As New DTRAN_MovimientosNeumaticos()
         Dim _where As New Hashtable()
         Dim _valor As String = "SELECT IsNull(Max(MOVNM_Id), 0) FROM Transportes.TRAN_MovimientosNeumaticos WHERE NEUMA_Id = " & m_tran_movimientosneumaticos.NEUMA_Id.ToString()
         _where.Add("MOVNM_Id", New ACWhere(_valor, ACWhere.TipoWhere._In))
         Dim _listMN As New List(Of ETRAN_MovimientosNeumaticos)
         '' Busca los movimientos del neumatico
         If d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(_listMN, _where) Then
            If _listMN.Count > 0 Then
               '' Si existe un movimientoanterio le cambia de estado e ingresa el registro
               Dim _reg As ETRAN_MovimientosNeumaticos = _listMN(0)
               _reg.MOVNM_Estado = BConstantes.getEstado(BConstantes.EstadoMovimientos.Inactivo)
               _reg.Instanciar(ACEInstancia.Modificado)
               d_tran_movimientosneumaticos.MOVNSU_UnRegEstado(_reg, x_usuario)
            End If
            '' Si no existe el movimiento directamente lo ingresa
            If m_tran_movimientosneumaticos.Nuevo Then
               d_tran_movimientosneumaticos.MOVNSI_UnRegMovimiento(m_tran_movimientosneumaticos, x_usuario)
               Return True
            End If
         Else
            '' Si no existe el movimiento directamente lo ingresa
            If m_tran_movimientosneumaticos.Nuevo Then
               d_tran_movimientosneumaticos.MOVNSI_UnRegMovimiento(m_tran_movimientosneumaticos, x_usuario)
               Return True
            End If
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarUbicacion(ByVal x_neuma_id As Long, ByRef _movimiento As ETRAN_MovimientosNeumaticos, ByRef m_tipoUbicacion As String, ByRef m_ubicacion As String) As Boolean
      Try
         '' Encontrar el Movimiento
         Dim d_tran_movimientosneumaticos As New DTRAN_MovimientosNeumaticos()
         Dim _where As New Hashtable()
         _where.Add("NEUMA_Id", New ACWhere(x_neuma_id.ToString(), ACWhere.TipoWhere.Igual))
         _where.Add("MOVNM_Estado", New ACWhere("A", ACWhere.TipoWhere.Igual))
         Dim _listMovimientos As New List(Of ETRAN_MovimientosNeumaticos)
         If d_tran_movimientosneumaticos.TRAN_MOVNMSS_Todos(_listMovimientos, _where) Then
            If _listMovimientos.Count > 0 Then
               'Dim _movimiento As New ETRAN_MovimientosNeumaticos()
               _movimiento = _listMovimientos(0)
               m_tipoUbicacion = BConstantes.getOrigenDestino(_movimiento.TIPOS_CodDestino.ToString())
               '' Encontrar la Ubicacion
               Select Case _movimiento.TIPOS_CodDestino
                  Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Almacen)
                     Dim _balmacen As New BAlmacenes()
                     If _balmacen.Cargar(_movimiento.MOVNM_IdDestino) Then
                        m_ubicacion = _balmacen.Almacenes.ALMAC_Direccion
                     End If
                  Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Proveedor)
                     Dim _bproveedor As New BEntidades()
                     If _bproveedor.Cargar(_movimiento.MOVNM_IdDestino) Then
                        m_ubicacion = _bproveedor.Entidades.ENTID_RazonSocial
                     End If
                  Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Ranfla)
                     Dim _branfla As New BTRAN_Ranflas()
                     If _branfla.Cargar(_movimiento.MOVNM_IdDestino) Then
                        m_ubicacion = _branfla.TRAN_Ranflas.RANFL_Placa
                     End If
                  Case BConstantes.getOrigenDestino(BConstantes.TipoDestino.Vehiculo)
                     Dim _bvehiculo As New BTRAN_Vehiculos()
                     If _bvehiculo.Cargar(_movimiento.MOVNM_IdDestino) Then
                        m_ubicacion = _bvehiculo.TRAN_Vehiculos.VEHIC_Placa
                     End If
                  Case Else
                     m_ubicacion = "Desconocido"
               End Select

               Return True
            Else
               m_tipoUbicacion = "No Existe Ubicacion registrada"
            End If
         Else
            m_tipoUbicacion = "No Existe Ubicacion registrada"
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   
#End Region

End Class

