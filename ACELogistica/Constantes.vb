Imports System.Threading
Imports System.IO


Public Class Constantes
   Private Shared mInstance As Constantes = Nothing
   Private Shared mMutex As New System.Threading.Mutex

   Public Enum TImpresion
      TextoPlano
      CRReporte
   End Enum


   Public Shared Function Initialize() As Constantes
      mMutex.WaitOne()
      If mInstance Is Nothing Then
         mInstance = New Constantes
      End If
      mMutex.ReleaseMutex()
      Return mInstance
   End Function

   Public Shared Function GetTImpresion(ByVal x_timpresion As String) As TImpresion
      Select Case x_timpresion
         Case "C"
            Return TImpresion.CRReporte
         Case "T"
            Return TImpresion.TextoPlano
         Case Else
            Return TImpresion.TextoPlano
      End Select

   End Function

#Region " Empresas "

   Enum NEmpresas
      AcerosActual
      Aceros
      Promasa
   End Enum

   Public Shared ReadOnly Property GetEmpresa(ByVal x_opcion As String) As Constantes.NEmpresas
      Get
         Select Case x_opcion
            Case "ACOLD"
               Return NEmpresas.AcerosActual
            Case "PROMA"
               Return NEmpresas.Promasa
            Case "ACERO"
               Return NEmpresas.Aceros
            Case Else
               Return NEmpresas.AcerosActual
         End Select
      End Get
   End Property


   Enum PVenta
      Transportes
      Variante
      Dolores
      Socabaya
      Huanuco
      Lima
      Tomasa
      Huyaruropata
      Tacna
      Industrial
      Constructores
      Cultura
   End Enum

#End Region

#Region " Monedas "

   Enum TipoMoneda
      Soles = 1
      Dolares = 2
   End Enum

   Public Shared ReadOnly Property Moneda(ByVal x_tipo As TipoMoneda) As String
      Get
         Select Case x_tipo
            Case TipoMoneda.Soles
               Return "S/."
            Case TipoMoneda.Dolares
               Return "US$"
            Case Else
               Return "S/."
         End Select
      End Get
   End Property

#End Region

#Region " Otros Formatos "

   Public Shared ReadOnly Property Formatofecha() As String
      Get
         Return "dd/MM/yyyy"
      End Get
   End Property

#End Region

#Region " Formatos Numericos "

   Enum Formato
      Importe2d
      Importe3d
      Importe4d
   End Enum


   Public Shared ReadOnly Property FormatoNumerico(ByVal x_tipo As Formato) As String
      Get
         Select Case x_tipo
            Case Formato.Importe2d
               Return "#,###,##0.00"
            Case Formato.Importe3d
               Return "#,###,##0.000"
            Case Formato.Importe4d
               Return "#,###,##0.0000"
            Case Else
               Return "#,###,##0.00"
         End Select
      End Get
   End Property

#End Region

#Region " Constantes para Cancelacion de Documentos "

   Enum Pase
      Entrada
      Salida
      Pendiente
      Gasto
   End Enum

   Public Shared ReadOnly Property GetPase(ByVal x_opcion As Pase) As String
      Get
         Select Case x_opcion
            Case Pase.Entrada
               Return "E"
            Case Pase.Salida
               Return "S"
            Case Pase.Pendiente
               Return "P"
            Case Pase.Gasto
               Return "G"
            Case Else
               Return "E"
         End Select
      End Get
   End Property

   Public Shared Function getGlosaTipoDePago(ByVal x_opcion As TipoDePago) As String
      Try
         Select Case x_opcion
            Case ETipos.TipoDePago.Cheque
               Return "Acotación de Cheque / Pendiente de Confirmación de Pago"
            Case ETipos.TipoDePago.DepositoBancario
               Return "Cancelación por Deposito"
            Case ETipos.TipoDePago.Efectivo
               Return "Cancelación de factura"
            Case ETipos.TipoDePago.Letra
               Return "Cancelación por Letra"
            Case ETipos.TipoDePago.NotaCredito
               Return "Cancelación por Nota de Credito"
            Case ETipos.TipoDePago.RecEgreInterno
               Return "Cancelación por Recibo de Egreso Interno"
            Case ETipos.TipoDePago.ReciboEgresoRedondeo
               Return "Redondeo de Pago por Importe Superior"
            Case ETipos.TipoDePago.ReciboIngresoRedondeo
               Return "Redondeo de Pago por Importe Inferior"
            Case Else
               Return "Cancelación por Otro Medio"
         End Select
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " COnstantes "
   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
      Activo
   End Enum

   Public Shared Function getEstado(ByVal x_opcion As Estado)
      Select Case x_opcion
         Case Estado.Anulado
            Return "X"
         Case Estado.Confirmado
            Return "C"
         Case Estado.Eliminado
            Return "E"
         Case Estado.Ingresado
            Return "I"
         Case Estado.Activo
            Return "A"
         Case Else
            Return "I"
      End Select
   End Function

   Enum TCliente
      Blanco
      Anulado
   End Enum

   Public Shared ReadOnly Property Cliente(ByVal x_tcliente As TCliente) As String
      Get
         Select Case x_tcliente
            Case TCliente.Anulado
                    Return "0"
            Case TCliente.Blanco
                    Return "0"
            Case Else
                    Return "0"
         End Select
      End Get
   End Property

   Public Enum TNiveles
      Super
      Administrador
      Normal
   End Enum

   Public Shared ReadOnly Property Nivel(x_tnivel As TNiveles) As String
      Get
         Select Case x_tnivel
            Case TNiveles.Administrador
               Return "001"
            Case TNiveles.Normal
               Return "002"
            Case TNiveles.Super
               Return "000"
            Case Else
               Return "002"
         End Select

      End Get
   End Property


#End Region

#Region " Constantes para entidades "
   Public Shared ReadOnly Property LongitudCodigo() As Integer
      Get
         Return 8
      End Get
   End Property

   Public Shared ReadOnly Property LongitudCodigoVehiculo() As Integer
      Get
         Return 6
      End Get
   End Property

   Public Enum Seteo
      Activar
      Desactivar
   End Enum

   Public Shared ReadOnly Property ClienteAnulado() As String
      Get
         Return "10000000000"
      End Get
   End Property

   Public Shared ReadOnly Property ClienteBlanco() As String
      Get
            Return "0"
      End Get
   End Property
#End Region

#Region " Tipo de Entidad "
   Public Shared ReadOnly Property PersonaNatural() As String
      Get
         Return "N"
      End Get
   End Property

   Public Shared ReadOnly Property PersonaJuridica() As String
      Get
         Return "J"
      End Get
   End Property

   Public Shared ReadOnly Property CodigoPersonaNatural() As String
      Get
         Return "10"
      End Get
   End Property
#End Region

#Region " Neumaticos "

   Enum TipoLlanta
      DeTraccion
      Lineal
      TodasPosiciones
   End Enum

   Public Shared Function getTipoLlanta(ByVal x_opcion As TipoLlanta) As String
      Select Case x_opcion
         Case TipoLlanta.DeTraccion
            Return "NEU001"
         Case TipoLlanta.Lineal
            Return "NEU002"
         Case TipoLlanta.TodasPosiciones
            Return "NEU000"
         Case Else
            Return "NEU001"
      End Select
   End Function

   Enum LadoNeumatico
      Izquierdo
      Derecho
   End Enum

   Public Shared Function getLadoNeumatico(ByVal x_opcion As LadoNeumatico, Optional ByVal x_nombre As Boolean = False) As String
      Select Case x_opcion
         Case LadoNeumatico.Derecho
            Return IIf(x_nombre, "Derecho", "D")
         Case LadoNeumatico.Izquierdo
            Return IIf(x_nombre, "Izquierdo", "I")
         Case Else
            Return IIf(x_nombre, "Derecho", "D")
      End Select
   End Function

   Enum IntExtNeumatico
      Interno
      Externo
   End Enum

   Public Shared Function getIntExt(ByVal x_opcion As IntExtNeumatico, Optional ByVal x_nombre As Boolean = False) As String
      Select Case x_opcion
         Case IntExtNeumatico.Externo
            Return IIf(x_nombre, "Externo", "E")
         Case IntExtNeumatico.Interno
            Return IIf(x_nombre, "Interno", "I")
         Case Else
            Return IIf(x_nombre, "Externo", "E")
      End Select
   End Function

   Enum SeccionNeumatico
      Delanteros
      Posteriores
   End Enum

   Public Shared Function getSeccionNeumatico(ByVal x_opcion As SeccionNeumatico, Optional ByVal x_nombre As Boolean = False) As String
      Select Case x_opcion
         Case SeccionNeumatico.Delanteros
            Return IIf(x_nombre, "Delanteros", "D")
         Case SeccionNeumatico.Posteriores
            Return IIf(x_nombre, "Posteriores", "P")
         Case Else
            Return IIf(x_nombre, "Delanteros", "D")
      End Select
   End Function

#End Region

#Region " Cuentas Contables "

   Enum TRelCuentasContables
      VentasMercaderia = 1
      Percepcion = 3
      DiferenciaCambioGanancia = 4
      DiferenciaCambioPerdida = 5
      DepositoDevolver = 6
      PerdidaPorRedondeo = 7
      GananciaPorRedondeo = 8
      CtasXCobrar = 31
      IGV = 34
      VentaMercaderiaTerceros = 35
      VentaMercaderiaRelacionados = 36
      PrestacionServicios = 37
      PrestacionServiciosRelacionados = 38
      AlquilerTerrenos = 39
      AlquilerEdificaciones = 40
      InmuebleMaqEquipo = 41
   End Enum

#End Region

End Class