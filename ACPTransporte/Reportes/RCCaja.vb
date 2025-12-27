Imports ACBTransporte

Public Class RCCaja
#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      AcFecha.ACDtpFecha_A.Value = Date.Now
      AcFecha.ACDtpFecha_De.Value = Date.Now
      Me.Icon = Icon.FromHandle(ACPTransportes.My.Resources.ACGastos_16x16.GetHicon)
      ' Add any initialization after the InitializeComponent() call.
      'Me.KeyPreview = True

   End Sub
#End Region

#Region " Metodos "

#End Region

#Region " Metodos de Controles"

   Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      Try
         Dim _reporte As New Reporte()
         If _reporte.CuadreCaja(AcFecha.ACFecha_De.Value.Date, AcFecha.ACFecha_A.Value.Date, False) Then

         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), Colecciones.getError("00000"), ex)
      End Try
   End Sub

   Private Sub AcFecha_ACFecIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecIni_KeyDown
      If e.KeyData = Keys.Enter Then
         AcFecha.ACDtpFecha_A.Focus()
      End If
   End Sub

   Private Sub AcFecha_ACFecFin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcFecha.ACFecFin_KeyDown
      If e.KeyData = Keys.Enter Then
         btnProcesar_Click(Nothing, Nothing)
      End If
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      Me.Close()
   End Sub

   Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Enter Then
         If sender.Name = "txtBusqueda" Then
            Exit Sub
         End If
         If TypeOf ActiveControl Is ACControles.ACTextBoxAyuda And ActiveControl.Name = "NSFechaIni" Then
            Exit Sub
         End If
         If TypeOf ActiveControl Is ACControles.ACTextBoxAyuda And ActiveControl.Name = "NSFechaFin" Then
            Exit Sub
         End If
         SendKeys.Send("{TAB}")
      End If
   End Sub

#End Region

End Class