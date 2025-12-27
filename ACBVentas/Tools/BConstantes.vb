Imports ACDVentas
Imports ACEVentas

Public Class BConstantes

#Region " variables "
   Private Shared m_aplic_codigo As String
   Private Shared m_zonas_codigo As String
   Private Shared m_sucur_id As Short
   Private Shared m_periodo As String
   Private Shared m_pvent_id As Long
   Private Shared m_eusuarioentidad As EEntidades

   Private m_dconstantes As DConstantes
   Private m_fecha As Date
#End Region

#Region " Estados "

   Enum Estados
      Activo
      Inactivo
      Anulado
   End Enum

   Public Shared Function getEstado(ByVal Estado As Estados) As String
      Select Case Estado
         Case Estados.Activo : Return "A"
         Case Estados.Inactivo : Return "I"
         Case Estados.Anulado : Return "X"
         Case Else : Return "I"
      End Select
   End Function

#Region " Relacionados "
   Public Enum EstadoRelacionados
      Activo
      Inactivo
      Anulado
   End Enum

   Public Shared Function getEstado(ByVal Estado As EstadoRelacionados) As String
      Select Case Estado
         Case EstadoRelacionados.Activo : Return "A"
         Case EstadoRelacionados.Inactivo : Return "I"
         Case EstadoRelacionados.Anulado : Return "X"
         Case Else : Return "I"
      End Select
   End Function
#End Region

#Region " Movimientos "

   Enum EstadoMovimientos
      Activo
      Inactivo
      Anulado
      Pendiente
      Asignado
   End Enum

   Public Shared Function getEstado(ByVal x_opcion As EstadoMovimientos)
      Select Case x_opcion
         Case EstadoMovimientos.Activo
            Return "A"
         Case EstadoMovimientos.Inactivo
            Return "I"
         Case EstadoMovimientos.Anulado
            Return "X"
         Case EstadoMovimientos.Pendiente
            Return "P"
         Case EstadoMovimientos.Asignado
            Return "G"
         Case Else
            Return "A"
      End Select
   End Function
#End Region

#Region " Del vehiculos en en viaje "

   Enum EstadosVehiculoViaje
      Disponible
      Ocupado
      Mantenimiento
   End Enum

   Public Shared Function getEstado(ByVal Estado As EstadosVehiculoViaje) As String
      Select Case Estado
         Case EstadosVehiculoViaje.Disponible : Return "D"
         Case EstadosVehiculoViaje.Ocupado : Return "O"
         Case EstadosVehiculoViaje.Mantenimiento : Return "M"
         Case Else : Return "D"
      End Select
   End Function
#End Region

#Region " Del vehiculos en en viaje "


#End Region
#End Region

#Region " Documentos "
   Public Shared Function getDoc_OrdenMovimiento()
      Return "TDI001"
   End Function

#End Region

#Region " Constructor "
   Public Sub New()
      m_dconstantes = New DConstantes
   End Sub
#End Region

#Region " Metodos "
   Public Function getFecha() As Date
      Try
         m_fecha = m_dconstantes.getDateTime()
         Return m_fecha
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Destinos de Neumaticos "
   Public Enum TipoDestino
      Vehiculo
      Ranfla
      Almacen
      Proveedor
   End Enum

   Public Shared Function getOrigenDestino(ByVal x_opcion As TipoDestino) As String
      Select Case x_opcion
         Case TipoDestino.Vehiculo
            Return "TOD001"
         Case TipoDestino.Ranfla
            Return "TOD002"
         Case TipoDestino.Almacen
            Return "TOD003"
         Case TipoDestino.Proveedor
            Return "TOD004"
         Case Else
            Return "TOD001"
      End Select
   End Function

   Public Shared Function getOrigenDestino(ByVal x_opcion As String) As String
      Try
         Dim b_tipos As New BTipos()
         If b_tipos.Cargar(x_opcion) Then
            Return b_tipos.Tipos.TIPOS_Descripcion
         Else
            Return ""
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Valores Iniciales "
   Public Shared Function getUbicacion() As String
      Return "Asignación Inicial"
   End Function

   Public Shared Function getGlosa() As String
      Return "Asignación Inicial"
   End Function

   Public Shared Function getMotivo() As String
      Return "Asignación Inicial"
   End Function
#End Region


   Public Sub setIniciales(ByVal x_aplic_codigo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long _
                        , ByVal x_periodo As String, ByVal x_eusuarioentidad As EEntidades)
      m_aplic_codigo = x_aplic_codigo
      m_sucur_id = x_sucur_id
      m_zonas_codigo = x_zonas_codigo
      m_eusuarioentidad = x_eusuarioentidad
      m_periodo = x_periodo
      m_pvent_id = x_pvent_id
   End Sub


#Region " Propiedades "
   Public Shared ReadOnly Property EUsuarioEntidad() As EEntidades
      Get
         Return m_eusuarioentidad
      End Get
   End Property

   Public Shared ReadOnly Property APLIC_Codigo() As String
      Get
         Return m_aplic_codigo
      End Get
   End Property

   Public Shared ReadOnly Property ZONAS_Codigo() As String
      Get
         Return m_zonas_codigo
      End Get
   End Property

   Public Shared ReadOnly Property SUCUR_Id() As Short
      Get
         Return m_sucur_id
      End Get
   End Property

   Public Shared ReadOnly Property Periodo() As String
      Get
         Return m_periodo
      End Get
   End Property

   Public Shared ReadOnly Property PVENT_Id() As Long
      Get
         Return m_pvent_id
      End Get
   End Property

#End Region

End Class
