Imports ACFramework
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Public Class PImpresion
#Region " Variables "
    Private m_cotiz_codigo As String

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
    Public Sub New(ByVal x_cotiz_codigo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            '' Cargar Impresoras
            m_cotiz_codigo = x_cotiz_codigo

            Dim _printer As String = cargarImpresoras(ComboBox1)
            ComboBox1.Text = _printer
            Me.Text = "Impresion"
        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Inicializar datos", ex)
        End Try
    End Sub


#End Region

#Region " Metodos "

   Public Function cargarImpresoras(ByRef tscmbImpresora As ComboBox) As String
      Try
         Dim _default As String = ""
         tscmbImpresora.Items.Clear()
         ACFramework.ACUtilitarios.ACCargaCombo(tscmbImpresora, Colecciones.ListPrinter, "DeviceName", "DeviceName")
         Return Colecciones.PrinterDefault
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#Region " Metodos de Controles"
   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub

   Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
      Dim _impresion As New Impresion(ComboBox1.Text)
      Try
         If _impresion.Print_CotizacionTransportista(m_cotiz_codigo, True) Then
            ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento con el numero {0}-{1} Impreso satisfactoriamente", m_cotiz_codigo.Substring(2, 3), m_cotiz_codigo.Substring(5, 7)))
         Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede imprimir el documento")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso imprimir Documento", ex)
      End Try
   End Sub

   Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
      Dim _impresion As New Impresion("")
        Try
          

                If _impresion.Print_CotizacionTransportista(m_cotiz_codigo, False) Then
                    'ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), String.Format("Documento con el numero {0}-{1} Impreso satisfactoriamente", m_docpe_codigo.Substring(2, 3), m_docpe_codigo.Substring(5, 7)))
                Else
                    ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), "No se puede imprimir el documento")
                End If

        Catch ex As Exception
            ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso imprimir Documento", ex)
        End Try
   End Sub
#End Region
End Class