Public Class PImpLinea

#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

#End Region

#Region " Metodos de Controles"

#End Region

   Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
      Me.Close()
   End Sub

   Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
      Try
         Dim _imp As New Impresion(cmbImpresora.Text)
         _imp.ImprimirLinea(txtLinea.Text, txtFilas.Text, txtColumnas.Text, txtInternlineado.Text)

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Imprimir"), ex)
      End Try
   End Sub

   Private Sub tscmbImpresora_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbImpresora.DropDown
      Try
         If IsNothing(Colecciones.ListPrinter) Then
            Colecciones.CargarImpresoras()
         End If
         ACFramework.ACUtilitarios.ACCargaCombo(cmbImpresora, Colecciones.ListPrinter, "DeviceName", "DeviceName")
      Catch ex As Exception

      End Try
   End Sub
End Class