Public Class Procesos
#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Procesos "
    Enum TipoProcesos
        ModificarVehiculo
        RecalcularPendiente
        AgregarGuia
        AgregarConsumoComb
        QuitarConsumoComb
        AgregarGastosViaje
        QuitarGastosViaje
        ModificarGastosViaje
        AgregarFlete
        QuitarFlete
        ModificarFlete
        ModificarImporteFlete
        AgregarReciboIngreso
        QuitarReciboIngreso
        ModificarReciboIngreso
        ModificarDatosViaje
        AgregarGastoInicial
        QuitarGastoInicial
        ModificarGastoInicial
        AnularViaje
        ActivarViajeAnulado
        EliminarViaje
        ViajesSoloLectura
        ViajeEliminarMantenimiento_SNFactura 'Sin Factura Amarrada Frank 
        Mantenimiento_EliminarMantenimiento 'ELIMINAR MANTENIMIENTOS DEFINITIVAMENTE -- CON DOCUMENTOS FRNAK 
        PermitirFraccionarPago
        CajaAnularPagos
        CajaModFecha
        ModFecComCombustible
        CajaAnularIngresoEgresosEfectivo
        QuitarLiqViaje
        PermitirFacturarFechaAnterior
        EliminarFacturas
        ReimprimirFacturas
        AnularFacturas
        ModFletefacturado
        EliminarGuiaRemision

        CChica_AnulaIngresosMismoDia
        CChica_AnulaIngresosPosterior
        CChica_AnulaIngresosPagos
        CChica_QuitarPago

        RIngEgre_Reimprimir
    End Enum

    Public Shared ReadOnly Property getProceso(ByVal x_opcion As TipoProcesos)
        Get
            Select Case x_opcion
                Case TipoProcesos.ModificarVehiculo
                    Return "VMVEH"
                Case TipoProcesos.RecalcularPendiente
                    Return "VRPEN"
                Case TipoProcesos.AgregarGuia
                    Return "VAGRE"
                Case TipoProcesos.AgregarConsumoComb
                    Return "VACCO"
                Case TipoProcesos.QuitarConsumoComb
                    Return "VQCCO"
                Case TipoProcesos.AgregarGastosViaje
                    Return "VAGVI"
                Case TipoProcesos.QuitarGastosViaje
                    Return "VQGVI"
                Case TipoProcesos.ModificarGastosViaje
                    Return "VMGVI"
                Case TipoProcesos.AgregarFlete
                    Return "VAFLE"
                Case TipoProcesos.QuitarFlete
                    Return "VQFLE"
                Case TipoProcesos.ModificarFlete
                    Return "VMFLE"
                Case TipoProcesos.ModificarImporteFlete
                    Return "VMIFL"
                Case TipoProcesos.AgregarReciboIngreso
                    Return "VARIN"
                Case TipoProcesos.QuitarReciboIngreso
                    Return "VQRIN"
                Case TipoProcesos.ModificarDatosViaje
                    Return "VMDVI"
                Case TipoProcesos.AgregarGastoInicial
                    Return "VAGIN"
                Case TipoProcesos.QuitarGastoInicial
                    Return "VQGIN"
                Case TipoProcesos.ModificarGastoInicial
                    Return "VMGIN"
                Case TipoProcesos.AnularViaje
                    Return "VXVIA"
                Case TipoProcesos.ActivarViajeAnulado
                    Return "VAVIA"
                Case TipoProcesos.EliminarViaje
                    Return "VELIM"
                Case TipoProcesos.ViajesSoloLectura
                    Return "VSLEC"
                Case TipoProcesos.CajaAnularPagos
                    Return "CPXPC"
                Case TipoProcesos.CajaModFecha
                    Return "CMFEC"
                Case TipoProcesos.ModFecComCombustible
                    Return "VMCCO"
                Case TipoProcesos.ModificarReciboIngreso
                    Return "VMRIN"
                Case TipoProcesos.CajaAnularIngresoEgresosEfectivo
                    Return "CXPIE"
                Case TipoProcesos.QuitarLiqViaje
                    Return "VXLVI"
                Case TipoProcesos.PermitirFacturarFechaAnterior
                    Return "VPFFA"
                Case TipoProcesos.EliminarFacturas
                    Return "FELFA"
                Case TipoProcesos.ReimprimirFacturas
                    Return "FPRFA"
                Case TipoProcesos.AnularFacturas
                    Return "FPAFA"
                Case TipoProcesos.ModFletefacturado
                    Return "VMFLF"
                Case TipoProcesos.EliminarGuiaRemision
                    Return "ELIGR"
                Case TipoProcesos.CChica_AnulaIngresosMismoDia
                    Return "XICCH"
                Case TipoProcesos.CChica_AnulaIngresosPosterior
                    Return "XICCD"
                Case TipoProcesos.CChica_AnulaIngresosPagos
                    Return "XIPCC"
                Case TipoProcesos.CChica_QuitarPago
                    Return "QPCCH"
                Case TipoProcesos.RIngEgre_Reimprimir
                    Return "PRIRB"
                Case TipoProcesos.ViajeEliminarMantenimiento_SNFactura
                    Return "VPEMV"
                Case TipoProcesos.Mantenimiento_EliminarMantenimiento
                    Return "BDRMT"
                Case TipoProcesos.PermitirFraccionarPago
                    Return "CPFPD"
                Case Else
                    Return ""
            End Select
        End Get
    End Property
#End Region

End Class