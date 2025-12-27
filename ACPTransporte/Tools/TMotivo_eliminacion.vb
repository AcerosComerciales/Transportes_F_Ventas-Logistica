Public Class TMotivo_eliminacion
#Region " Variables "
    Private m_motivo As String
    Private m_tmotivo As TDocumento

    Enum TDocumento
        GuiaRemision
        PagoCaja
        Recibo
        Orden
        Sencillo
        Factura
        Mantenimiento
    End Enum

#End Region

#Region " Propiedades "

    Public Property Motivo() As String
        Get
            Return m_motivo
        End Get
        Set(ByVal value As String)
            m_motivo = value
        End Set
    End Property

#End Region

#Region " Constructores "
    Public Sub New(ByVal x_tmotivo As TDocumento)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            m_tmotivo = x_tmotivo
            Select Case m_tmotivo
                Case TDocumento.GuiaRemision
                    acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Guia de Remisión")
                Case TDocumento.PagoCaja
                    acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Pago de Caja")
                Case TDocumento.Recibo
                    acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Recibo Egreso/Ingreso")
                Case TDocumento.Orden
                    acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Orden Ingreso/Salida")
                Case TDocumento.Sencillo
                    acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Sencillo")
                Case TDocumento.Factura
                    acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Factura")
                Case TDocumento.Mantenimiento
                    acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "Mantenimiento")
                Case Else
                    acpnlTitulo.ACCaption = String.Format(acpnlTitulo.ACCaption, "")
            End Select
            Me.Text = acpnlTitulo.ACCaption
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
        End Try
    End Sub
#End Region

#Region " Metodos "

#End Region

#Region " Metodos de Controles"

#End Region

    Private Sub acTool_ACBtnSalir_Click(sender As Object, e As EventArgs) Handles acTool.ACBtnSalir_Click
        Me.Close()
    End Sub

    Private Sub acbtnSeleccionar_Click(sender As Object, e As EventArgs) Handles acbtnGrabar.Click
        Try
            If txtMotivo.Text.Trim().Length > 5 Then
                m_motivo = txtMotivo.Text
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Throw New Exception("Se debe ingresar un motivo para poder continuar")
            End If
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Grabar Registro"), ex)
        End Try
    End Sub
End Class